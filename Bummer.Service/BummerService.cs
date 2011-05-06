using System;
using System.Collections.Generic;
using System.ServiceProcess;
using System.Timers;
using Bummer.Common;
using Bummer.ScheduleRunner;

namespace Bummer.Service {
	partial class BummerService : ServiceBase {
		Timer timer;
		public BummerService() {
			InitializeComponent();
		}

		protected override void OnStart( string[] args ) {
			timer = new Timer( 30000 );
			timer.AutoReset = true;
			timer.Enabled = true;
			timer.Elapsed += timer_Elapsed;
			timer.Start();
		}

		void timer_Elapsed( object sender, ElapsedEventArgs e ) {
			if( timer == null ) {
				return;
			}
			List<BackupScheduleWrapper> schedules = Configuration.GetSchedules();
			foreach( BackupScheduleWrapper schedule in schedules ) {
				if( !schedule.LastStarted.HasValue ) {
					ScheduleJobSpawner.SpawAndRun( schedule );
					continue;
				}
				if( schedule.Interval <= 0 ) {
					continue;
				}
				DateTime next = schedule.LastStarted.Value;
				switch( schedule.IntervalType ) {
					case SchduleIntervalTypes.Minute:
						next = next.AddMinutes( schedule.Interval );
						break;
					case SchduleIntervalTypes.Hour:
						next = next.AddHours( schedule.Interval );
						break;
					case SchduleIntervalTypes.Day:
						next = next.AddDays( schedule.Interval );
						break;
					case SchduleIntervalTypes.Week:
						next = next.AddDays( 7 * schedule.Interval );
						break;
					case SchduleIntervalTypes.Month:
						next = next.AddMonths( schedule.Interval );
						break;
					default:
						continue;
				}
				if( DateTime.Now > next ) {
					if( StartTimeOK( schedule.StartFromTime, schedule.StartToTime ) ) {
						ScheduleJobSpawner.SpawAndRun( schedule );
					}
				}
			}
		}
		private bool StartTimeOK( DateTime startFrom, DateTime startTo ) {
			if( startFrom.Hour == startTo.Hour && startFrom.Minute == startTo.Minute ) {
				return true;
			}
			DateTime start = DateTime.Now.AddHours( startFrom.Hour ).AddMinutes( startFrom.Minute );
			DateTime stop = DateTime.Now.AddHours( startTo.Hour ).AddMinutes( startTo.Minute );
			if( startFrom.Hour > startTo.Hour ) {
				stop = stop.AddDays( 1 );
			}
			DateTime now = DateTime.Now;
			return now >= start && now <= stop;
		}

		protected override void OnStop() {
			timer.Stop();
			timer.Dispose();
			timer = null;
		}
	}
}
