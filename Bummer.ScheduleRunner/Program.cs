using System;
using System.Diagnostics;
using System.IO;
using Bummer.Common;

namespace Bummer.ScheduleRunner {
	public class Program {
		static void Main() {
			//bool s = true;
			//while( s ) {
			//    Thread.Sleep( 100 );
			//}
			SpawnLogger.Log( "Spawn starting" );
			Process p = Process.GetCurrentProcess();
			string n = p.ProcessName.Replace( "Bummer.ScheduleRunner.", "" );
			int id;
			if( !int.TryParse( n, out id ) ) {
				SpawnLogger.Log( "Spawn failed to parse ID from {0}".FillBlanks( n ) );
				Console.WriteLine( "Invalid start of ScheduleRunner" );
				Console.Error.WriteLine( "Invalid start of ScheduleRunner" );
				return;
			}
			BackupScheduleWrapper sc = Configuration.GetSchedule( id );
			if( sc == null ) {
				SpawnLogger.Log( "Spawn unable to find schedule {0}".FillBlanks( id ) );
				Console.WriteLine( "ScheduleRunner is unable to find schedule to run" );
				Console.Error.WriteLine( "ScheduleRunner is unable to find schedule to run" );
				return;
			}
			Process[] processesRunning = Process.GetProcessesByName( p.ProcessName );
			if( processesRunning.Length > 1 ) {
				SpawnLogger.Log( "Spawn {0} already running".FillBlanks( id ) );
				Console.WriteLine( "ScheduleRunner's schedule is already running" );
				Console.Error.WriteLine( "ScheduleRunner's schedule is already running" );
				return;
			}
			SpawnLogger.Log( "Spawn executing schedule {0}".FillBlanks( sc.Name ) );
			try {
				sc.Execute();
			} catch( Exception ex ) {
				SpawnLogger.Log( "Spawn execution error for schedule {0}: {1}".FillBlanks( sc.Name, ex.Message ) );
			}
		}
		
	}
	internal static class SpawnLogger {
		private static string LogDir {
			get {
				return _logDir ?? (_logDir = Configuration.DataDirectory.FullName + "\\SpawnLogs");
			}
		}
		private static string _logDir;
		static SpawnLogger() {
			try {
				if( !Directory.Exists( LogDir ) ) {
					Directory.CreateDirectory( LogDir );
				}
			} catch {
			}
		}

		internal static void Log( string message ) {
			string logFile = string.Format( "{0}\\{1}.log", LogDir, DateTime.Now.ToString( "yyyy-MM-dd" ) );
			try {
				File.AppendAllText( logFile, string.Format( "{0}\t{1}{2}", DateTime.Now.ToString( "yyyy-MM-dd HH:mm:ss" ), message, Environment.NewLine ) );
			} catch {
			}
		}
	}
	public sealed class ScheduleJobSpawner {
		public static bool IsJobRunning( BackupScheduleWrapper job ) {
			string procName = "Bummer.ScheduleRunner.{0}".FillBlanks( job.ID );
			Process[] processes = Process.GetProcessesByName( procName );
			return processes.Length > 0;
		}
		public static bool SpawAndRun( BackupScheduleWrapper job ) {
			SpawnLogger.Log( "Spawn request {0}".FillBlanks( job.Name ) );
			string procName = "Bummer.ScheduleRunner.{0}".FillBlanks( job.ID );
			Process[] processes = Process.GetProcessesByName( procName );
			if( processes.Length > 0 ) {
				SpawnLogger.Log( "Spawn request, already running {0}".FillBlanks( job.Name ) );
				return false;
			}
			DirectoryInfo dir = new DirectoryInfo( Configuration.DataDirectory.FullName + "\\" + job.ID );
			if( Directory.Exists( dir.FullName ) ) {
				try {
					Directory.Delete( dir.FullName, true );
				} catch( Exception ex ) {
					SpawnLogger.Log( "Spawn request, cleanup failed {0}: {1}".FillBlanks( job.Name, ex.Message ) );
					return false;
				}
			}
			Type t = typeof(ScheduleJobSpawner);
			FileInfo fi = new FileInfo( t.Assembly.Location );
			DirectoryInfo binDir = new DirectoryInfo( fi.DirectoryName );
			binDir.Copy( dir.FullName, true );
			string exeName = "{0}\\{1}.exe".FillBlanks( dir.FullName, procName );
			fi.CopyTo( exeName, true );
			FileInfo[] configs = binDir.GetFiles( "*.config" );
			foreach( FileInfo configFile in configs ) {
				if( configFile.Name.Contains( ".vshost." ) ) {
					continue;
				}
				configFile.CopyTo( exeName + ".config" );
				break;
			}
			SpawnLogger.Log( "Spawn request spawning {0}".FillBlanks( job.Name ) );
			Process p = new Process();
			p.StartInfo = new ProcessStartInfo( exeName );
			p.StartInfo.CreateNoWindow = true;
			p.StartInfo.UseShellExecute = false;
			p.EnableRaisingEvents = true;
			p.Exited += p_Exited;
			p.Start();
			return true;
		}

		static void p_Exited( object sender, EventArgs e ) {
			Process p = sender as Process;
			if( p == null ) {
				return;
			}
			FileInfo fi = new FileInfo( p.StartInfo.FileName );
			Directory.Delete( fi.DirectoryName, true );
		}
	}
}
