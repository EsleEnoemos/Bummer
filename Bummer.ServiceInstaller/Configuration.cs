using System;
using System.Data.SQLite;
using System.IO;
using System.Security.AccessControl;
using System.Security.Principal;

namespace Bummer.ServiceInstaller {
	public static class Configuration {
		#region private static DirectoryInfo DataDirectory
		/// <summary>
		/// The root directory for all data saved to disk by any part of Bummer
		/// </summary>
		/// <value></value>
		private static DirectoryInfo DataDirectory {
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
		#region private static DBCommand GetCommand()
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		private static DBCommand GetCommand() {
			return DBCommand.Create( string.Format( "{0}\\Schedules.s3db", DataDirectory.FullName ) );
		}
		#endregion
		#region internal static void CreateDBFileAndSetPermissions()
		/// <summary>
		/// 
		/// </summary>
		internal static void CreateDBFileAndSetPermissions() {
			DBCommand cmd = GetCommand();
			SQLiteConnectionStringBuilder cb = new SQLiteConnectionStringBuilder( cmd.Con.ConnectionString );
			FileInfo file = new FileInfo( cb.DataSource );
			FileSecurity permissions = file.GetAccessControl();
			string domain = Environment.GetEnvironmentVariable( "USERDOMAIN" );
			if( !string.IsNullOrEmpty( domain ) ) {
				domain = "@" + domain;
			}
			string username = Environment.GetEnvironmentVariable( "USERNAME" );
			WindowsIdentity cu = new WindowsIdentity( username + domain );
			if( cu.User == null ) {
				return;
			}
			permissions.AddAccessRule( new FileSystemAccessRule( cu.User, FileSystemRights.FullControl, AccessControlType.Allow ) );
			file.SetAccessControl( permissions );
		}
		#endregion
	}
}
