using System;
using System.Collections.Generic;
using System.ServiceProcess;
using Bummer.Common;
using Bummer.ScheduleRunner;
using Quartz;
using Quartz.Impl;

namespace Bummer.Service {
	internal enum LogStatuses {
		Unknown = 0,
		Message = 1,
		Error = 2,
		Startup = 3,
		Reload = 4,
		Shutdown = 5,
		Stop = 6,
		Continue = 7,
		Pause = 8,
		Execute = 9
	}
	partial class BummerService : ServiceBase {
		private bool running;
		IScheduler scheduler;

		public BummerService() {
			InitializeComponent();
		}

		protected override void OnStart( string[] args ) {
			running = true;
			Logger.Log( "Starting", LogStatuses.Startup );
			LoadSchedules( LogStatuses.Startup );
		}
		private void LoadSchedules( LogStatuses status ) {
			Logger.Log( "Loading schedules", status );
			if( !running ) {
				Logger.Log( "Loading schedules aborted. Service is not started.", status );
				return;
			}
			try {
				StdSchedulerFactory schedulerFactory = new StdSchedulerFactory();
				scheduler = schedulerFactory.GetScheduler();
				List<BackupScheduleWrapper> jobs = Configuration.GetSchedules();
				foreach( BackupScheduleWrapper bj in jobs ) {
					JobDetail job = new JobDetail( bj.ID.ToString(), "group1", typeof(MyJobClass) );
					try {
						CronTrigger trigger = new CronTrigger( "trigger {0}".FillBlanks( bj.ID ), "group1", bj.ID.ToString(), "group1", bj.CronConfig );
						scheduler.AddJob( job, true );
						scheduler.ScheduleJob( trigger );
						Logger.Log( string.Format( "Job {0} ({1}) added to schedule", bj.ID, bj.Name ), LogStatuses.Message );
					} catch( Exception ex ) {
						Logger.Log( string.Format( "Error adding job {0} ({1}) to schedule: {2}", bj.ID, bj.Name, ex.Message ), LogStatuses.Error );
					}
				}
				scheduler.Start();
			} catch( Exception oEx ) {
				Logger.Log( string.Format( "Error scheduling jobs: {0}", oEx.Message ), LogStatuses.Error );
			}
		}
		protected override void OnShutdown() {
			running = false;
			base.OnShutdown();
			Logger.Log( "Shutting down", LogStatuses.Shutdown );
			if( scheduler != null ) {
				scheduler.Shutdown( false );
				scheduler = null;
			}
		}
		protected override void OnCustomCommand( int command ) {
			base.OnCustomCommand( command );
			Logger.Log( "Command recieved ({0})".FillBlanks( command ), LogStatuses.Message );
			if( command == Configuration.ReLoadSchedulesCommand ) {
				if( scheduler != null ) {
					scheduler.Shutdown( false );
					scheduler = null;
				}
				LoadSchedules( LogStatuses.Reload );
			}
		}
		protected override void OnStop() {
			running = false;
			Logger.Log( "Stopping", LogStatuses.Stop );
			if( scheduler != null ) {
				scheduler.Shutdown( false );
				scheduler = null;
			}
		}
		protected override void OnPause() {
			running = false;
			base.OnPause();
			Logger.Log( "Continue", LogStatuses.Pause );
			if( scheduler != null ) {
				scheduler.Shutdown( false );
				scheduler = null;
			}
		}
		protected override void OnContinue() {
			running = true;
			base.OnContinue();
			Logger.Log( "Continue", LogStatuses.Continue );
			LoadSchedules( LogStatuses.Continue );
		}
	}
	public class MyJobClass : IJob {
		public void Execute( JobExecutionContext context ) {
			int jobID;
			if( !int.TryParse( context.JobDetail.Name, out jobID ) ) {
				Logger.Log( "Error getting ID for job to execute", LogStatuses.Error );
				return;
			}
			BackupScheduleWrapper schedule = Configuration.GetSchedule( jobID );
			if( schedule == null ) {
				Logger.Log( "Error getting Schedule for {0}".FillBlanks( jobID ), LogStatuses.Error );
				return;
			}
			Logger.Log( "Running schedule {0}".FillBlanks( schedule.Name ), LogStatuses.Execute );
			ScheduleJobSpawner.SpawAndRun( schedule );
		}
	}
	internal static class Logger {
		private static string LogDir {
			get {
				return _logDir ?? (_logDir = Configuration.DataDirectory.FullName + "\\ServiceLogs");
			}
		}
		private static string _logDir;
		static Logger() {
			try {
				if( !System.IO.Directory.Exists( LogDir ) ) {
					System.IO.Directory.CreateDirectory( LogDir );
				}
			} catch {}
		}

		internal static void Log( string message, LogStatuses status ) {
			string logFile = string.Format( "{0}\\{1}.log", LogDir, DateTime.Now.ToString( "yyyy-MM-dd" ) );
			try {
				System.IO.File.AppendAllText( logFile, string.Format( "{0}\t{1}\t{2}{3}", DateTime.Now.ToString( "yyyy-MM-dd HH:mm:ss" ), status, message, Environment.NewLine ) );
			} catch {}
		}
	}
}
