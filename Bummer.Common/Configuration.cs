using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Reflection;
using System.ServiceProcess;

namespace Bummer.Common {
	public static class Configuration {
		#region internal const int ReLoadSchedulesCommand
		/// <summary>
		/// Gets the ReLoadSchedulesCommand of the <see cref="Bummer.Common.Configuration"/>
		/// </summary>
		internal const int ReLoadSchedulesCommand = 150; // a value between 128 and 256
		#endregion
		#region internal static List<IBackupSchedule> JobPlugins
		/// <summary>
		/// Gets the <see cref="IBackupSchedule"/> of the Configuration
		/// </summary>
		/// <value></value>
		internal static List<IBackupSchedule> JobPlugins {
			get {
				if( _jobPlugins == null ) {
					_jobPlugins = new List<IBackupSchedule>();
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
														_jobPlugins.Add( plug );
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
														_jobPlugins.Add( plug );
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
						if( _jobPlugins.Count > 1 ) {
							_jobPlugins.Sort( delegate( IBackupSchedule x, IBackupSchedule y ) {
								return string.Compare( x.Name, y.Name );
							} );
						}
					}
				}
				return _jobPlugins;
			}
		}
		private static List<IBackupSchedule> _jobPlugins;
		#endregion
		#region internal static List<IBackupTarget> TargetPlugins
		/// <summary>
		/// Gets the TargetPlugins of the Configuration
		/// </summary>
		/// <value></value>
		internal static List<IBackupTarget> TargetPlugins {
			get {
				if( _targetPlugins == null ) {
					_targetPlugins = new List<IBackupTarget>();
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
												if( typeof( IBackupTarget ).IsAssignableFrom( type ) ) {
													IBackupTarget plug = ass.CreateInstance( type.FullName ) as IBackupTarget;
													if( plug != null ) {
														_targetPlugins.Add( plug );
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
												if( typeof( IBackupTarget ).IsAssignableFrom( type ) ) {
													IBackupTarget plug = type.Assembly.CreateInstance( type.FullName ) as IBackupTarget;
													if( plug != null ) {
														_targetPlugins.Add( plug );
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
						if( _targetPlugins.Count > 1 ) {
							_targetPlugins.Sort( delegate( IBackupTarget x, IBackupTarget y ) {
								return string.Compare( x.Name, y.Name );
							} );
						}
					}
				}
				return _targetPlugins;
			}
		}
		private static List<IBackupTarget> _targetPlugins;
		#endregion
		#region public static DirectoryInfo DataDirectory
		/// <summary>
		/// The root directory for all data saved to disk by any part of Bummer
		/// </summary>
		/// <value></value>
		public static DirectoryInfo DataDirectory {
			get {
				if( _dataDirectory == null ) {
					//string fp = Environment.GetFolderPath( Environment.SpecialFolder.ApplicationData );
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
					list.Add( new BackupScheduleWrapper( cmd.GetInt( "Schedule_ID" ), cmd.GetString( "Name" ), cmd.GetDateTime( "CreatedDate" ), cmd.GetString( "JobType" ), cmd.GetString( "JobConfiguration" ), cmd.GetString( "TargetType" ), cmd.GetString( "TargetConfiguration" ), cmd.GetString( "PreCommands" ), cmd.GetString( "PostCommands" ), cmd.GetString( "CronConfig" ), cmd.GetNullableDateTime( "LastStarted" ), cmd.GetNullableDateTime( "LastFinished" ) ) );
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
					return new BackupScheduleWrapper( cmd.GetInt( "Schedule_ID" ), cmd.GetString( "Name" ), cmd.GetDateTime( "CreatedDate" ), cmd.GetString( "JobType" ), cmd.GetString( "JobConfiguration" ), cmd.GetString( "TargetType" ), cmd.GetString( "TargetConfiguration" ), cmd.GetString( "PreCommands" ), cmd.GetString( "PostCommands" ), cmd.GetString( "CronConfig" ), cmd.GetNullableDateTime( "LastStarted" ), cmd.GetNullableDateTime( "LastFinished" ) );
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
		internal static void ReloadService() {
			try {
				ServiceController service = new ServiceController( "BummerService" );
				service.ExecuteCommand( ReLoadSchedulesCommand );
				//service.Status == ServiceControllerStatus.Running
			} catch {}
		}
		internal static bool IsServiceRunning() {
			try {
				ServiceController service = new ServiceController( "BummerService" );
				return service.Status == ServiceControllerStatus.Running;
			} catch {
			}
			return false;
		}
	}
}
