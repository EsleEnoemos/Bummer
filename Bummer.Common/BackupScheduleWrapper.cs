using System;
using System.Collections.Generic;
using System.Diagnostics;
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
		#region public string PreCommands
		/// <summary>
		/// Get/Sets the PreCommands of the BackupScheduleWrapper
		/// </summary>
		/// <value></value>
		public string PreCommands {
			get {
				return _preCommands;
			}
			set {
				_preCommands = value;
			}
		}
		private string _preCommands;
		#endregion
		#region public string PostCommands
		/// <summary>
		/// Get/Sets the PostCommands of the BackupScheduleWrapper
		/// </summary>
		/// <value></value>
		public string PostCommands {
			get {
				return _postCommands;
			}
			set {
				_postCommands = value;
			}
		}
		private string _postCommands;
		#endregion
		#region public string JobConfiguration
		/// <summary>
		/// Get/Sets the JobConfiguration of the BackupScheduleWrapper
		/// </summary>
		/// <value></value>
		public string JobConfiguration {
			get {
				return _jobConfiguration;
			}
			set {
				_jobConfiguration = value;
			}
		}
		private string _jobConfiguration;
		#endregion
		#region public string TargetType
		/// <summary>
		/// Get/Sets the TargetType of the BackupScheduleWrapper
		/// </summary>
		/// <value></value>
		public string TargetType {
			get {
				return _targetType;
			}
			set {
				_targetType = value;
			}
		}
		private string _targetType;
		#endregion
		#region public string TargetConfiguration
		/// <summary>
		/// Get/Sets the TargetConfiguration of the BackupScheduleWrapper
		/// </summary>
		/// <value></value>
		public string TargetConfiguration {
			get {
				return _targetConfiguration;
			}
			set {
				_targetConfiguration = value;
			}
		}
		private string _targetConfiguration;
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
		#region public DateTime StartTime
		/// <summary>
		/// Get/Sets the StartTime of the BackupScheduleWrapper
		/// </summary>
		/// <value></value>
		public DateTime StartTime {
			get {
				return _startTime;
			}
			set {
				_startTime = value;
			}
		}
		private DateTime _startTime;
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
					foreach( IBackupSchedule plug in Configuration.JobPlugins ) {
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
		#region public IBackupTarget Target
		/// <summary>
		/// Gets the Target of the BackupScheduleWrapper
		/// </summary>
		/// <value></value>
		public IBackupTarget Target {
			get {
				if( _target == null && TargetType != null ) {
					foreach( IBackupTarget tp in Configuration.TargetPlugins ) {
						if( string.Equals( tp.GetType().FullName, TargetType ) ) {
							_target = tp;
							break;
						}
					}
				}
				return _target;
			}
		}
		private IBackupTarget _target;
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
		private List<ScheduleJobLog> _logs;
		#endregion

		#region public BackupScheduleWrapper( int id, string name, DateTime createdDate, string jobType, string jobConfiguration, string targetType, string targetConfiguration, string preCommands, string postCommands, SchduleIntervalTypes intervalType, int interval, DateTime startTime, DateTime? lastStarted, DateTime? lastFinished )
		/// <summary>
		/// Initializes a new instance of the <b>BackupScheduleWrapper</b> class.
		/// </summary>
		/// <param name="id"></param>
		/// <param name="name"></param>
		/// <param name="createdDate"></param>
		/// <param name="jobType"></param>
		/// <param name="jobConfiguration"></param>
		/// <param name="targetType"></param>
		/// <param name="targetConfiguration"></param>
		/// <param name="preCommands"></param>
		/// <param name="postCommands"></param>
		/// <param name="intervalType"></param>
		/// <param name="interval"></param>
		/// <param name="startTime"></param>
		/// <param name="lastStarted"></param>
		/// <param name="lastFinished"></param>
		public BackupScheduleWrapper( int id, string name, DateTime createdDate, string jobType, string jobConfiguration, string targetType, string targetConfiguration, string preCommands, string postCommands, SchduleIntervalTypes intervalType, int interval, DateTime startTime, DateTime? lastStarted, DateTime? lastFinished ) {
			_iD = id;
			_name = name;
			_createdDate = createdDate;
			_jobType = jobType;
			_preCommands = preCommands;
			_postCommands = postCommands;
			_jobConfiguration = jobConfiguration;
			_targetType = targetType;
			_targetConfiguration = targetConfiguration;
			_intervalType = intervalType;
			_interval = interval;
			_startTime = startTime;
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
			return new BackupScheduleWrapper( ID, Name, CreatedDate, JobType, JobConfiguration, TargetType, TargetConfiguration, PreCommands, PostCommands, IntervalType, Interval, StartTime, LastStarted, LastFinished );
		}
		#endregion

		#region public void ReFresh()
		/// <summary>
		/// 
		/// </summary>
		public void ReFresh() {
			_logs = null;
			BackupScheduleWrapper rf = Configuration.GetSchedule( ID );
			if( rf == null ) {
				return;
			}
			_lastStarted = rf._lastStarted;
			_lastFinished = rf._lastFinished;
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
			using( DBCommand cmd = Configuration.GetCommand() ) {
				if( ID <= 0 ) {
					cmd.CommandText = "INSERT INTO Schedules( Name, CreatedDate, JobType, JobConfiguration, TargetType, TargetConfiguration PreCommands, PostCommands, IntervalType, Interval, StartTime ) VALUES( @Name, @CreatedDate, @JobType, @JobConfiguration, @TargetType, @TargetConfiguration, @PreCommands, @PostCommands, @IntervalType, @Interval, @StartTime );";
					cmd.AddWithValue( "@Name", Name );
					cmd.AddWithValue( "@CreatedDate", CreatedDate );
					cmd.AddWithValue( "@JobType", JobType );
					cmd.AddWithValue( "@JobConfiguration", JobConfiguration );
					cmd.AddWithValue( "@TargetType", TargetType );
					cmd.AddWithValue( "@TargetConfiguration", TargetConfiguration );
					cmd.AddWithValue( "@PreCommands", NZ( PreCommands ) );
					cmd.AddWithValue( "@PostCommands", NZ( PostCommands ) );
					cmd.AddWithValue( "@IntervalType", (int)IntervalType );
					cmd.AddWithValue( "@Interval", Interval );
					cmd.AddWithValue( "@StartTime", StartTime );
					cmd.ExecuteNonQuery();
					ID = cmd.GetLastAutoIncrement();
				} else {
					cmd.CommandText = @"
UPDATE Schedules
SET
Name = @Name,
JobType = @JobType,
PreCommands = @PreCommands,
PostCommands = @PostCommands,
JobConfiguration = @JobConfiguration,
TargetType = @TargetType,
TargetConfiguration = @TargetConfiguration,
IntervalType = @IntervalType,
Interval = @Interval,
StartTime = @StartTime,
WHERE
Schedule_ID = @Schedule_ID";
					cmd.AddWithValue( "@Name", Name );
					cmd.AddWithValue( "@JobType", JobType );
					cmd.AddWithValue( "@PreCommands", NZ( PreCommands ) );
					cmd.AddWithValue( "@PostCommands", NZ( PostCommands ) );
					cmd.AddWithValue( "@JobConfiguration", JobConfiguration );
					cmd.AddWithValue( "@TargetType", TargetType );
					cmd.AddWithValue( "@TargetConfiguration", TargetConfiguration );
					cmd.AddWithValue( "@IntervalType", (int)IntervalType );
					cmd.AddWithValue( "@Interval", Interval );
					cmd.AddWithValue( "@StartTime", StartTime );
					cmd.AddWithValue( "@Schedule_ID", ID );
					cmd.ExecuteNonQuery();
				}
			}
		}
		#endregion
		#region private static object NZ( string that )
		/// <summary>
		/// 
		/// </summary>
		/// <param name="that"></param>
		/// <returns></returns>
		private static object NZ( string that ) {
			if( string.IsNullOrEmpty( that ) ) {
				return DBNull.Value;
			}
			return that;
		}
		#endregion
		#region public void Delete()
		/// <summary>
		/// 
		/// </summary>
		public void Delete() {
			try {
				Job.Delete( JobConfiguration, ID );
			} catch {
			}
			using( DBCommand cmd = Configuration.GetCommand() ) {
				cmd.CommandText = "DELETE FROM Schedules WHERE Schedule_ID = {0}".FillBlanks( ID );
				cmd.ExecuteNonQuery();
				cmd.CommandText = "DELETE FROM ScheduleLogs WHERE Schedule_ID = {0}".FillBlanks( ID );
			}
		}
		#endregion

		#region public void Execute()
		/// <summary>
		/// 
		/// </summary>
		public void Execute() {
			DateTime start = DateTime.Now;
			bool success = true;
			string message;
			using( DBCommand cmd = Configuration.GetCommand() ) {
				try {
					cmd.CommandText = "UPDATE Schedules SET LastStarted = @start WHERE Schedule_ID = @ID";
					cmd.AddWithValue( "@start", start );
					cmd.AddWithValue( "@ID", ID );
					cmd.ExecuteNonQuery();
				} catch {
				}
			}
			try {
				if( !string.IsNullOrEmpty( PreCommands ) ) {
					RunCommands( PreCommands );
				}
				message = Job.Execute( JobConfiguration, ID, Target );
				if( !string.IsNullOrEmpty( PostCommands ) ) {
					RunCommands( PostCommands );
				}
			} catch( Exception ex ) {
				success = false;
				message = ex.Message;
			}
			using( DBCommand cmd = Configuration.GetCommand() ) {
				DateTime now = DateTime.Now;
				try {
					cmd.CommandText = "UPDATE Schedules SET LastFinished = @now WHERE Schedule_ID = @ID";
					cmd.AddWithValue( "@ID", ID );
					cmd.AddWithValue( "@now", now );
					cmd.ExecuteNonQuery();
					cmd.CommandText = "INSERT INTO ScheduleLogs( Schedule_ID, Date, Success, Entry ) VALUES( @ID, @now, @Success, @Entry )";
					cmd.AddWithValue( "@Success", success ? 1 : 0 );
					cmd.AddWithValue( "@Entry", message ?? "" );
					cmd.ExecuteNonQuery();
					_logs = null;
				} catch {
				}
			}
		}
		#endregion

		#region public static void RunCommands( string commands )
		/// <summary>
		/// 
		/// </summary>
		/// <param name="commands"></param>
		public static void RunCommands( string commands ) {
			if( string.IsNullOrEmpty( commands ) ) {
				return;
			}
			List<CommandWrapper> cmds = CommandWrapper.Parse( commands );
			foreach( CommandWrapper command in cmds ) {
				Process p = new Process();
				p.StartInfo = new ProcessStartInfo( command.Command, command.Arguments );
				p.StartInfo.CreateNoWindow = true;
				p.StartInfo.UseShellExecute = false;
				p.Start();
				p.WaitForExit();
			}
		}
		#endregion
	}
}
