using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Bummer.Common;

namespace Bummer.Schedules.Controls {
	public partial class MSSQLDatabaseBackupConfigGUI : UserControl {
		internal MSSQLDatabaseBackup.MSSQLDatabaseBackupConfig Config;

		public MSSQLDatabaseBackupConfigGUI( MSSQLDatabaseBackup.MSSQLDatabaseBackupConfig config ) {
			InitializeComponent();
			Config = config ?? new MSSQLDatabaseBackup.MSSQLDatabaseBackupConfig();
		}
		public MSSQLDatabaseBackupConfigGUI() : this( null ) {
		}

		private void MSSQLDatabaseBackupConfigGUI_Load( object sender, EventArgs e ) {
			tbServer.Text = Config.Server;
			tbUsername.Text = Config.Username;
			tbPassword.Text = Config.Password;
			tbRemoteTempDir.Text = Config.RemoteTempDir;
			cbCompress.Checked = Config.CompressFiles;
			cbAddDateToFilename.Checked = Config.AddDateToFilename;
			cbSaveType.Items.Add( MSSQLDatabaseBackup.SaveAsTypes.Directory );
			cbSaveType.Items.Add( MSSQLDatabaseBackup.SaveAsTypes.FTP );
			cbSaveType.SelectedIndex = Config.SaveAs == MSSQLDatabaseBackup.SaveAsTypes.FTP ? 1 : 0;
			RefreshDatabases();
		}
		internal MSSQLDatabaseBackup.MSSQLDatabaseBackupConfig Save() {
			MSSQLDatabaseBackup.MSSQLDatabaseBackupConfig config = new MSSQLDatabaseBackup.MSSQLDatabaseBackupConfig();
			if( string.IsNullOrEmpty( tbServer.Text ) ) {
				throw new Exception("You have to specify a database server");
			}
			config.Server = tbServer.Text;
			if( string.IsNullOrEmpty( tbUsername.Text ) ) {
				throw new Exception( "You have to specify a database username" );
			}
			config.Username = tbUsername.Text;
			if( string.IsNullOrEmpty( tbPassword.Text ) ) {
				throw new Exception( "You have to specify a database password" );
			}
			config.Password = tbPassword.Text;
			if( cbSaveType.SelectedIndex < 0 ) {
				throw new Exception( "You have to specify a save type" );
			}
			if( string.IsNullOrEmpty( tbRemoteTempDir.Text ) ) {
				throw new Exception( "You have to specify a remote TEMP-directory" );
			}
			config.RemoteTempDir = tbRemoteTempDir.Text;
			config.Databases = new List<string>();
			foreach( string db in cblDatabases.CheckedItems ) {
				config.Databases.Add( db );
			}
			config.CompressFiles = cbCompress.Checked;
			config.AddDateToFilename = cbAddDateToFilename.Checked;
			config.SaveAs = (MSSQLDatabaseBackup.SaveAsTypes)cbSaveType.SelectedItem;
			switch( config.SaveAs ) {
				case MSSQLDatabaseBackup.SaveAsTypes.Directory:
					MSSQLDatabaseBackupConfigGUIDirectorySelector ds = pnlSaveAsConfig.Controls[ 0 ] as MSSQLDatabaseBackupConfigGUIDirectorySelector;
					if( ds == null ) {
						throw new Exception( "Unable to find directory selector" );
					}
					if( string.IsNullOrEmpty( ds.Directory ) ) {
						throw new Exception( "You have to select a directory to save backup to" );
					}
					config.SaveToDir = ds.Directory;
					break;
				case MSSQLDatabaseBackup.SaveAsTypes.FTP:
					MSSQLDatabaseBackupConfigGUIFTPSelector fs = pnlSaveAsConfig.Controls[ 0 ] as MSSQLDatabaseBackupConfigGUIFTPSelector;
					if( fs == null ) {
						throw new Exception( "Unable to find FTP selector" );
					}
					if( string.IsNullOrEmpty( fs.Server ) ) {
						throw new Exception( "You have to specify an FTP server" );
					}
					config.FTPServer = fs.Server;
					if( string.IsNullOrEmpty( fs.Username ) ) {
						throw new Exception( "You have to specify a FTP username" );
					}
					config.FTPUsername = fs.Username;
					if( string.IsNullOrEmpty( fs.Password ) ) {
						throw new Exception( "You have to specify a FTP password" );
					}
					config.FTPPassword = fs.Password;
					if( string.IsNullOrEmpty( fs.LocalTemp ) ) {
						throw new Exception( "You have to specify a local TEMP-directory" );
					}
					config.FTPLocalTempDirectory = fs.LocalTemp;
					config.FTPRemoteDirectory = fs.RemoteDirectory;
					int p;
					if( !int.TryParse( fs.Port, out p ) ) {
						throw new Exception( "You have to specify a port" );
					}
					if( p < 1 || p > ushort.MaxValue ) {
						throw new Exception( "Port must have a value between 1 and {0}".FillBlanks( ushort.MaxValue ) );
					}
					config.FTPPort = p;
					break;
				default:
					throw new Exception( "Unknown save as type {0}".FillBlanks( config.SaveAs ) );
			}
			return config;
		}

		#region private List<string> GetDatabases()
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		private List<string> GetDatabases() {
			return GetDatabases( tbServer.Text, tbUsername.Text, tbPassword.Text );
		}
		#endregion
		#region internal static List<string> GetDatabases( string server, string username, string password )
		/// <summary>
		/// 
		/// </summary>
		/// <param name="server"></param>
		/// <param name="username"></param>
		/// <param name="password"></param>
		/// <returns></returns>
		internal static List<string> GetDatabases( string server, string username, string password ) {
			if( string.IsNullOrEmpty( server ) || string.IsNullOrEmpty( username ) || string.IsNullOrEmpty( password ) ) {
				return new List<string>();
			}
			SqlConnectionStringBuilder cb = new SqlConnectionStringBuilder();
			cb.DataSource = server;
			cb.UserID = username;
			cb.Password = password;
			SqlConnection con = new SqlConnection( cb.ToString() );
			SqlDataReader reader = null;
			List<string> list = new List<string>();
			try {
				SqlCommand cmd = con.CreateCommand();
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT name FROM sys.databases";
				con.Open();
				reader = cmd.ExecuteReader();
				while( reader.Read() ) {
					list.Add( reader.GetString( 0 ) );
				}
			} catch( Exception ex ) {
				MessageBox.Show( ex.Message );
			} finally {
				try {
					con.Close();
					con.Dispose();
					if( reader != null ) {
						reader.Close();
						reader.Dispose();
					}
				} catch {
				}
			}
			return list;
		}
		#endregion

		#region private void btnRefreshDatabases_Click( object sender, EventArgs e )
		/// <summary>
		/// This method is called when the btnRefreshDatabases's Click event has been fired.
		/// </summary>
		/// <param name="sender">The <see cref="object"/> that fired the event.</param>
		/// <param name="e">The <see cref="EventArgs"/> of the event.</param>
		private void btnRefreshDatabases_Click( object sender, EventArgs e ) {
			RefreshDatabases();
		}
		#endregion
		#region private void RefreshDatabases()
		/// <summary>
		/// 
		/// </summary>
		private void RefreshDatabases() {
			cblDatabases.Items.Clear();
			List<string> databases = GetDatabases();
			for( int i = 0; i < databases.Count; i++ ) {
				string db = databases[ i ];
				cblDatabases.Items.Add( db, db.EqualsAny( StringComparison.OrdinalIgnoreCase, Config.Databases.ToArray() ) );
			}
		}
		#endregion

		private void cbSaveType_SelectedIndexChanged( object sender, EventArgs e ) {
			MSSQLDatabaseBackup.SaveAsTypes st = (MSSQLDatabaseBackup.SaveAsTypes)cbSaveType.SelectedItem;
			pnlSaveAsConfig.Controls.Clear();
			Control c;
			if( st == MSSQLDatabaseBackup.SaveAsTypes.Directory ) {
				c = new MSSQLDatabaseBackupConfigGUIDirectorySelector( Config );
			} else {
				c = new MSSQLDatabaseBackupConfigGUIFTPSelector( Config );
			}
			c.Dock = DockStyle.Fill;
			pnlSaveAsConfig.Controls.Add( c );
		}
	}
}
