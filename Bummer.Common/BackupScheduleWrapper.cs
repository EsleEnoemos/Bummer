using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Bummer.Common {
	public class BackupScheduleWrapper {
		#region public int ID
		/// <summary>
		/// Get/Sets the ID of the BackupScheduleWrapper
		/// </summary>
		/// <value></value>
		public int ID {
			get { return _iD; }
			internal set { _iD = value; }
		}
		private int _iD;
		#endregion
		#region public string Name
		/// <summary>
		/// Get/Sets the Name of the BackupScheduleWrapper
		/// </summary>
		/// <value></value>
		public string Name {
			get {
				return _name;
			}
			set {
				_name = value;
			}
		}
		private string _name;
		#endregion
		#region public DateTime CreatedDate
		/// <summary>
		/// Get/Sets the CreatedDate of the BackupScheduleWrapper
		/// </summary>
		/// <value></value>
		public DateTime CreatedDate {
			get {
				return _createdDate;
			}
			set {
				_createdDate = value;
			}
		}
		private DateTime _createdDate;
		#endregion
		#region public string JobType
		/// <summary>
		/// Get/Sets the JobType of the BackupScheduleWrapper
		/// </summary>
		/// <value></value>
		public string JobType {
			get {
				return _jobType;
			}
			set {
				_jobType = value;
				_job = null;
			}
		}
		private string _jobType;
		#endregion
		#region public string Configuration
		/// <summary>
		/// Get/Sets the Configuration of the BackupScheduleWrapper
		/// </summary>
		/// <value></value>
		public string Configuration {
			get {
				return _configuration;
			}
			set {
				_configuration = value;
			}
		}
		private string _configuration;
		#endregion
		#region public SchduleIntervalTypes IntervalType
		/// <summary>
		/// Get/Sets the IntervalType of the BackupScheduleWrapper
		/// </summary>
		/// <value></value>
		public SchduleIntervalTypes IntervalType {
			get {
				return _intervalType;
			}
			set {
				_intervalType = value;
			}
		}
		private SchduleIntervalTypes _intervalType;
		#endregion
		#region public int Interval
		/// <summary>
		/// Get/Sets the Interval of the BackupScheduleWrapper
		/// </summary>
		/// <value></value>
		public int Interval {
			get {
				return _interval;
			}
			set {
				_interval = value;
			}
		}
		private int _interval;
		#endregion
		#region public DateTime StartFromTime
		/// <summary>
		/// Get/Sets the StartFromTime of the BackupScheduleWrapper
		/// </summary>
		/// <value></value>
		public DateTime StartFromTime {
			get {
				return _startFromTime;
			}
			set {
				_startFromTime = value;
			}
		}
		private DateTime _startFromTime;
		#endregion
		#region public DateTime StartToTime
		/// <summary>
		/// Get/Sets the StartToTime of the BackupScheduleWrapper
		/// </summary>
		/// <value></value>
		public DateTime StartToTime {
			get {
				return _startToTime;
			}
			set {
				_startToTime = value;
			}
		}
		private DateTime _startToTime;
		#endregion
		#region public DateTime? LastStarted
		/// <summary>
		/// Get/Sets the LastStarted of the BackupScheduleWrapper
		/// </summary>
		/// <value></value>
		public DateTime? LastStarted {
			get {
				return _lastStarted;
			}
			set {
				_lastStarted = value;
			}
		}
		private DateTime? _lastStarted;
		#endregion
		#region public DateTime? LastFinished
		/// <summary>
		/// Get/Sets the LastFinished of the BackupScheduleWrapper
		/// </summary>
		/// <value></value>
		public DateTime? LastFinished {
			get {
				return _lastFinished;
			}
			set {
				_lastFinished = value;
			}
		}
		private DateTime? _lastFinished;
		#endregion
		#region public IBackupSchedule Job
		/// <summary>
		/// Gets the Job of the BackupScheduleWrapper
		/// </summary>
		/// <value></value>
		[XmlIgnore]
		public IBackupSchedule Job {
			get {
				if( _job == null && JobType != null ) {
					foreach( IBackupSchedule plug in Common.Configuration.Plugins ) {
						if( string.Equals( plug.GetType().FullName, JobType ) ) {
							_job = plug;
							break;
						}
					}
				}
				return _job;
			}
		}
		private IBackupSchedule _job;
		#endregion
		#region public List<ScheduleJobLog> Logs
		/// <summary>
		/// Gets the Logs of the BackupScheduleWrapper
		/// </summary>
		/// <value></value>
		public List<ScheduleJobLog> Logs {
			get {
				return _logs ?? (_logs = ScheduleJobLog.Load( ID ));
			}
		}
		#endregion
		private List<ScheduleJobLog> _logs;

		#region public BackupScheduleWrapper( int id, string name, DateTime createdDate, string jobType, string configuration, SchduleIntervalTypes intervalType, int interval, DateTime startFromTime, DateTime startToTime, DateTime? lastStarted, DateTime? lastFinished )
		/// <summary>
		/// Initializes a new instance of the <b>BackupScheduleWrapper</b> class.
		/// </summary>
		/// <param name="id"></param>
		/// <param name="name"></param>
		/// <param name="createdDate"></param>
		/// <param name="jobType"></param>
		/// <param name="configuration"></param>
		/// <param name="intervalType"></param>
		/// <param name="interval"></param>
		/// <param name="startFromTime"></param>
		/// <param name="startToTime"></param>
		/// <param name="lastStarted"></param>
		/// <param name="lastFinished"></param>
		public BackupScheduleWrapper( int id, string name, DateTime createdDate, string jobType, string configuration, SchduleIntervalTypes intervalType, int interval, DateTime startFromTime, DateTime startToTime, DateTime? lastStarted, DateTime? lastFinished ) {
			_iD = id;
			_name = name;
			_createdDate = createdDate;
			_jobType = jobType;
			_configuration = configuration;
			_intervalType = intervalType;
			_interval = interval;
			_startFromTime = startFromTime;
			_startToTime = startToTime;
			_lastStarted = lastStarted;
			_lastFinished = lastFinished;
		}
		#endregion
		#region internal BackupScheduleWrapper()
		/// <summary>
		/// Initializes a new instance of the <b>BackupScheduleWrapper</b> class.
		/// </summary>
		internal BackupScheduleWrapper() {
		}
		#endregion

		#region internal BackupScheduleWrapper Clone()
		/// <summary>
		/// Creates a new object that is a copy of the current instance.
		/// </summary>
		/// <returns>A new object that is a copy of this instance.</returns>
		internal BackupScheduleWrapper Clone() {
			return new BackupScheduleWrapper( ID, Name, CreatedDate, JobType, Configuration, IntervalType, Interval, StartFromTime, StartToTime, LastStarted, LastFinished );
		}
		#endregion

		#region public void Persist()
		/// <summary>
		/// 
		/// </summary>
		public void Persist() {
			if( ID <= 0 ) {
				CreatedDate = DateTime.Now;
			}
			using( DBCommand cmd = Common.Configuration.GetCommand() ) {
				if( ID <= 0 ) {
					cmd.CommandText = "INSERT INTO Schedules( Name, CreatedDate, JobType, Configuration, IntervalType, Interval, StartFromTime, StartToTime ) VALUES( @Name, @CreatedDate, @JobType, @Configuration, @IntervalType, @Interval, @StartFromTime, @StartToTime );";
					cmd.AddWithValue( "@Name", Name );
					cmd.AddWithValue( "@CreatedDate", CreatedDate );
					cmd.AddWithValue( "@JobType", JobType );
					cmd.AddWithValue( "@Configuration", Configuration );
					cmd.AddWithValue( "@IntervalType", (int)IntervalType );
					cmd.AddWithValue( "@Interval", Interval );
					cmd.AddWithValue( "@StartFromTime", StartFromTime );
					cmd.AddWithValue( "@StartToTime", StartToTime );
					cmd.ExecuteNonQuery();
					ID = cmd.GetLastAutoIncrement();
				} else {
					cmd.CommandText = @"
UPDATE Schedules
SET
Name = @Name,
JobType = @JobType,
Configuration = @Configuration,
IntervalType = @IntervalType,
Interval = @Interval,
StartFromTime = @StartFromTime,
StartToTime = @StartToTime
WHERE
Schedule_ID = @Schedule_ID";
					cmd.AddWithValue( "@Name", Name );
					cmd.AddWithValue( "@JobType", JobType );
					cmd.AddWithValue( "@Configuration", Configuration );
					cmd.AddWithValue( "@IntervalType", (int)IntervalType );
					cmd.AddWithValue( "@Interval", Interval );
					cmd.AddWithValue( "@StartFromTime", StartFromTime );
					cmd.AddWithValue( "@StartToTime", StartToTime );
					cmd.AddWithValue( "@Schedule_ID", ID );
					cmd.ExecuteNonQuery();
				}
			}
		}
		#endregion

		#region public void Delete()
		/// <summary>
		/// 
		/// </summary>
		public void Delete() {
			using( DBCommand cmd = Common.Configuration.GetCommand() ) {
				cmd.CommandText = "DELETE FROM Schedules WHERE Schedule_ID = {0}".FillBlanks( ID );
				cmd.ExecuteNonQuery();
			}
		}
		#endregion

		public void Execute() {
			DateTime start = DateTime.Now;
			bool success = true;
			string message = null;
			try {
				message = Job.Execute( Configuration );
			} catch( Exception ex ) {
				success = false;
				message = ex.Message;
			}
			using( DBCommand cmd = Common.Configuration.GetCommand() ) {
				DateTime now = DateTime.Now;
				try {
				cmd.CommandText = "UPDATE Schedules SET LastStarted = @start, LastFinished = @now WHERE Schedule_ID = @ID";
				cmd.AddWithValue( "@start", start );
				cmd.AddWithValue( "@now", now );
					cmd.AddWithValue( "@ID", ID );
					cmd.ExecuteNonQuery();
					cmd.ClearParameters();
					cmd.CommandText = "INSERT INTO ScheduleLogs( Schedule_ID, Date, Success, Entry ) VALUES( @ID, @now, @Success, @Entry )";
					cmd.AddWithValue( "@ID", ID );
					cmd.AddWithValue( "@now", now );
					cmd.AddWithValue( "@Success", success ? 1 : 0 );
					cmd.AddWithValue( "@Entry", message ?? "" );
					cmd.ExecuteNonQuery();
					_logs = null;
				} catch {
				}
			}
		}
	}
}
