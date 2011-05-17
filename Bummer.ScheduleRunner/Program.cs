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
			Process p = Process.GetCurrentProcess();
			string n = p.ProcessName.Replace( "Bummer.ScheduleRunner.", "" );
			int id;
			if( !int.TryParse( n, out id ) ) {
				Console.WriteLine( "Invalid start of ScheduleRunner" );
				Console.Error.WriteLine( "Invalid start of ScheduleRunner" );
				return;
			}
			BackupScheduleWrapper sc = Configuration.GetSchedule( id );
			if( sc == null ) {
				Console.WriteLine( "ScheduleRunner is unable to find schedule to run" );
				Console.Error.WriteLine( "ScheduleRunner is unable to find schedule to run" );
				return;
			}
			Process[] processesRunning = Process.GetProcessesByName( p.ProcessName );
			if( processesRunning.Length > 1 ) {
				Console.WriteLine( "ScheduleRunner's schedule is already running" );
				Console.Error.WriteLine( "ScheduleRunner's schedule is already running" );
				return;
			}
			sc.Execute();
		}
	}
	public sealed class ScheduleJobSpawner {
		public static bool IsJobRunning( BackupScheduleWrapper job ) {
			string procName = "Bummer.ScheduleRunner.{0}".FillBlanks( job.ID );
			Process[] processes = Process.GetProcessesByName( procName );
			return processes.Length > 0;
		}
		public static bool SpawAndRun( BackupScheduleWrapper job ) {
			string procName = "Bummer.ScheduleRunner.{0}".FillBlanks( job.ID );
			Process[] processes = Process.GetProcessesByName( procName );
			if( processes.Length > 0 ) {
				return false;
			}
			DirectoryInfo dir = new DirectoryInfo( Configuration.DataDirectory.FullName + "\\" + job.ID );
			if( Directory.Exists( dir.FullName ) ) {
				try {
					Directory.Delete( dir.FullName, true );
				} catch {
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
