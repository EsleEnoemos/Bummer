using System;
using System.Collections.Generic;

namespace Bummer.Common {
	public class ScheduleJobLog {
		#region public int LogID
		/// <summary>
		/// Get/Sets the LogID of the ScheduleJobLog
		/// </summary>
		/// <value></value>
		public int LogID {
			get {
				return _logID;
			}
			set {
				_logID = value;
			}
		}
		private int _logID;
		#endregion
		#region public int ScheduleID
		/// <summary>
		/// Get/Sets the ScheduleID of the ScheduleJobLog
		/// </summary>
		/// <value></value>
		public int ScheduleID {
			get {
				return _scheduleID;
			}
			set {
				_scheduleID = value;
			}
		}
		private int _scheduleID;
		#endregion
		#region public DateTime Date
		/// <summary>
		/// Get/Sets the Date of the ScheduleJobLog
		/// </summary>
		/// <value></value>
		public DateTime Date {
			get {
				return _date;
			}
			set {
				_date = value;
			}
		}
		private DateTime _date;
		#endregion
		#region public bool Success
		/// <summary>
		/// Get/Sets the Success of the ScheduleJobLog
		/// </summary>
		/// <value></value>
		public bool Success {
			get {
				return _success;
			}
			set {
				_success = value;
			}
		}
		private bool _success;
		#endregion
		#region public string Entry
		/// <summary>
		/// Get/Sets the Entry of the ScheduleJobLog
		/// </summary>
		/// <value></value>
		public string Entry {
			get {
				return _entry;
			}
			set {
				_entry = value;
			}
		}
		private string _entry;
		#endregion

		#region public static List<ScheduleJobLog> Load( int scheduleID )
		/// <summary>
		/// 
		/// </summary>
		/// <param name="scheduleID"></param>
		/// <returns></returns>
		public static List<ScheduleJobLog> Load( int scheduleID ) {
			List<ScheduleJobLog> list = new List<ScheduleJobLog>();
			using( DBCommand cmd = Configuration.GetCommand() ) {
				try {
					cmd.CommandText = "SELECT * FROM ScheduleLogs WHERE Schedule_ID = " + scheduleID;
					while( cmd.Read() ) {
						list.Add( new ScheduleJobLog() {
							LogID = cmd.GetInt( "ScheduleLog_ID" ),
							ScheduleID = scheduleID,
							Date = cmd.GetDateTime( "Date" ),
							Success = cmd.GetBit( "Success" ),
							Entry = cmd.GetString( "Entry" )
						} );
					}
					if( list.Count > 1 ) {
						list.Sort( delegate( ScheduleJobLog x, ScheduleJobLog y ) {
							return DateTime.Compare( x.Date, y.Date ) * -1;
						} );
					}
				} catch {
				}
			}
			return list;
		}
		#endregion
	}
}
