using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Reflection;

namespace Bummer.Common {
	#region public enum SchduleIntervalTypes
	/// <summary>
	/// Defines the different types of intervals that a schedule can be configured to run with
	/// </summary>
	public enum SchduleIntervalTypes {
		/// <summary>
		/// The schedule is set with minute interval
		/// </summary>
		//Minute = 1,
		/// <summary>
		/// The schedule is set with hour interval
		/// </summary>
		//Hour = 2,
		/// <summary>
		/// The schedule is set with day interval
		/// </summary>
		Day = 3,
		/// <summary>
		/// The schedule is set with week interval
		/// </summary>
		Week = 4,
		/// <summary>
		/// The schedule is set with month interval
		/// </summary>
		Month = 5
	}
	#endregion

	public static class Configuration {
		#region internal static List<IBackupSchedule> Plugins
		/// <summary>
		/// Gets the Plugins of the Configuration
		/// </summary>
		/// <value></value>
		internal static List<IBackupSchedule> Plugins {
			get {
				if( _plugins == null ) {
					_plugins = new List<IBackupSchedule>();
					string pluginDir = "{0}\\Plugins".FillBlanks( DataDirectory.FullName );
					if( Directory.Exists( pluginDir ) ) {
						string[] files = Directory.GetFiles( pluginDir, "*.dll", SearchOption.AllDirectories );
						if( files.Length > 0 ) {
							foreach( string file in files ) {
								try {
									Assembly ass = Assembly.LoadFrom( file );
									Type[] types = ass.GetTypes();
									foreach( Type type in types ) {
										try {
											if( !type.IsAbstract ) {
												if( typeof( IBackupSchedule ).IsAssignableFrom( type ) ) {
													IBackupSchedule plug = ass.CreateInstance( type.FullName ) as IBackupSchedule;
													if( plug != null ) {
														_plugins.Add( plug );
													}
												}
											}
										} catch( Exception ) {
										}
									}

								} catch( ReflectionTypeLoadException rte ) {
									foreach( Type type in rte.Types ) {
										try {
											if( !type.IsAbstract ) {
												if( typeof( IBackupSchedule ).IsAssignableFrom( type ) ) {
													IBackupSchedule plug = type.Assembly.CreateInstance( type.FullName ) as IBackupSchedule;
													if( plug != null ) {
														_plugins.Add( plug );
													}
												}
											}
										} catch( Exception ) {
										}
									}
								} catch( Exception ) {
								}
							}
						}
						if( _plugins.Count > 1 ) {
							_plugins.Sort( delegate( IBackupSchedule x, IBackupSchedule y ) {
								return string.Compare( x.Name, y.Name );
							} );
						}
					}
				}
				return _plugins;
			}
		}
		private static List<IBackupSchedule> _plugins;
		#endregion
		#region public static DirectoryInfo DataDirectory
		/// <summary>
		/// The root directory for all data saved to disk by any part of Bummer
		/// </summary>
		/// <value></value>
		public static DirectoryInfo DataDirectory {
			get {
				if( _dataDirectory == null ) {
					DirectoryInfo d = new DirectoryInfo( Environment.GetFolderPath( Environment.SpecialFolder.CommonApplicationData ) );
					_dataDirectory = new DirectoryInfo( string.Format( "{0}\\SomeoneElse\\Bummer", d.FullName ) );
					if( !Directory.Exists( _dataDirectory.FullName ) ) {
						Directory.CreateDirectory( _dataDirectory.FullName );
						_dataDirectory.Refresh();
					}
				}
				return _dataDirectory;
			}
		}
		private static DirectoryInfo _dataDirectory;
		#endregion
		#region internal static DBCommand GetCommand()
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		internal static DBCommand GetCommand() {
			return DBCommand.Create( string.Format( "{0}\\Schedules.s3db", DataDirectory.FullName ) );
		}
		#endregion
		#region internal static List<BackupScheduleWrapper> GetSchedules()
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		internal static List<BackupScheduleWrapper> GetSchedules() {
			List<BackupScheduleWrapper> list = new List<BackupScheduleWrapper>();
			using( DBCommand cmd = GetCommand() ) {
				cmd.CommandText = "SELECT * FROM Schedules";
				while( cmd.Read() ) {
					list.Add( new BackupScheduleWrapper( cmd.GetInt( "Schedule_ID" ), cmd.GetString( "Name" ), cmd.GetDateTime( "CreatedDate" ), cmd.GetString( "JobType" ), cmd.GetString( "Configuration" ), cmd.GetString( "PreCommands" ), cmd.GetString( "PostCommands" ), (SchduleIntervalTypes)cmd.GetInt( "IntervalType" ), cmd.GetInt( "Interval" ), cmd.GetDateTime( "StartTime" ), cmd.GetNullableDateTime( "LastStarted" ), cmd.GetNullableDateTime( "LastFinished" ) ) );
				}
				if( list.Count > 1 ) {
					list.Sort( delegate( BackupScheduleWrapper x, BackupScheduleWrapper y ) {
						return string.Compare( x.Name, y.Name ) * -1;
					} );
				}
			}
			return list;
		}
		#endregion
		#region internal static BackupScheduleWrapper GetSchedule( int id )
		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		internal static BackupScheduleWrapper GetSchedule( int id ) {
			using( DBCommand cmd = GetCommand() ) {
				cmd.CommandText = "SELECT * FROM Schedules WHERE Schedule_ID = {0}".FillBlanks( id );
				while( cmd.Read() ) {
					return new BackupScheduleWrapper( cmd.GetInt( "Schedule_ID" ), cmd.GetString( "Name" ), cmd.GetDateTime( "CreatedDate" ), cmd.GetString( "JobType" ), cmd.GetString( "Configuration" ), cmd.GetString( "PreCommands" ), cmd.GetString( "PostCommands" ), (SchduleIntervalTypes)cmd.GetInt( "IntervalType" ), cmd.GetInt( "Interval" ), cmd.GetDateTime( "StartTime" ), cmd.GetNullableDateTime( "LastStarted" ), cmd.GetNullableDateTime( "LastFinished" ) );
				}
			}
			return null;
		}
		#endregion
		#region public static DBCommand CreateDBCommand( FileInfo sqLiteFile )
		/// <summary>
		/// Returns a <see cref="DBCommand"/> based on a <see cref="SQLiteConnection"/>
		/// The returned <see cref="DBCommand"/> can be used to perform any kind of operations against the database, including table-creation, inserts, updates, deletes, etc.
		/// </summary>
		/// <param name="sqLiteFile"></param>
		/// <returns></returns>
		public static DBCommand CreateDBCommand( FileInfo sqLiteFile ) {
			SQLiteConnectionStringBuilder cb = new SQLiteConnectionStringBuilder();
			cb.DataSource = sqLiteFile.FullName;
			cb.FailIfMissing = false;
			return new DBCommand( new SQLiteConnection( cb.ToString() ), CommandType.Text );
		}
		#endregion
	}
}
