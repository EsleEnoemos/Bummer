using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Bummer.Common;

namespace Bummer.Schedules.Controls {
	public partial class MSSQLDatabaseBackupConfigGUI : UserControl {
		internal MSSQLDatabaseBackup.MSSQLDatabaseBackupConfig Config;

		#region public MSSQLDatabaseBackupConfigGUI( MSSQLDatabaseBackup.MSSQLDatabaseBackupConfig config )
		/// <summary>
		/// Initializes a new instance of the <b>MSSQLDatabaseBackupConfigGUI</b> class.
		/// </summary>
		/// <param name="config"></param>
		public MSSQLDatabaseBackupConfigGUI( MSSQLDatabaseBackup.MSSQLDatabaseBackupConfig config ) {
			InitializeComponent();
			Config = config ?? new MSSQLDatabaseBackup.MSSQLDatabaseBackupConfig();
		}
		#endregion
		#region public MSSQLDatabaseBackupConfigGUI()
		/// <summary>
		/// Initializes a new instance of the <b>MSSQLDatabaseBackupConfigGUI</b> class.
		/// </summary>
		public MSSQLDatabaseBackupConfigGUI()
			: this( null ) {
		}
		#endregion

		#region private void MSSQLDatabaseBackupConfigGUI_Load( object sender, EventArgs e )
		/// <summary>
		/// This method is called when the MSSQLDatabaseBackupConfigGUI's Load event has been fired.
		/// </summary>
		/// <param name="sender">The <see cref="object"/> that fired the event.</param>
		/// <param name="e">The <see cref="EventArgs"/> of the event.</param>
		private void MSSQLDatabaseBackupConfigGUI_Load( object sender, EventArgs e ) {
			tbServer.Text = Config.Server;
			tbUsername.Text = Config.Username;
			tbPassword.Text = Config.Password;
			cbIsLocalServer.Checked = Config.IsLocalServer;
			tbRemoteTempDir.Text = Config.RemoteTempDir;
			cbCompress.Checked = Config.CompressFiles;
			cbAddDateToFilename.Checked = Config.AddDateToFilename;
			RefreshDatabases();
		}
		#endregion
		#region internal MSSQLDatabaseBackup.MSSQLDatabaseBackupConfig Save()
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		internal MSSQLDatabaseBackup.MSSQLDatabaseBackupConfig Save() {
			MSSQLDatabaseBackup.MSSQLDatabaseBackupConfig config = new MSSQLDatabaseBackup.MSSQLDatabaseBackupConfig();
			if( string.IsNullOrEmpty( tbServer.Text ) ) {
				throw new Exception( "You have to specify a database server" );
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
			config.IsLocalServer = cbIsLocalServer.Checked;
			if( !config.IsLocalServer ) {
				if( string.IsNullOrEmpty( tbRemoteTempDir.Text ) ) {
					throw new Exception( "You have to specify a remote TEMP-directory" );
				}
				config.RemoteTempDir = tbRemoteTempDir.Text;
			}
			config.Databases = new List<string>();
			foreach( string db in cblDatabases.CheckedItems ) {
				config.Databases.Add( db );
			}
			config.CompressFiles = cbCompress.Checked;
			config.AddDateToFilename = cbAddDateToFilename.Checked;
			return config;
		}
		#endregion

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

		private void cbIsLocalServer_CheckedChanged( object sender, EventArgs e ) {
			label6.Enabled = !cbIsLocalServer.Checked;
			tbRemoteTempDir.Enabled = !cbIsLocalServer.Checked;
		}

		private void btnBrowseForLocalTemp_Click( object sender, EventArgs e ) {
			FolderBrowserDialog fd = new FolderBrowserDialog();
			fd.SelectedPath = tbLocalTempDir.Text;
			if( fd.ShowDialog( this ) == DialogResult.OK ) {
				tbLocalTempDir.Text = fd.SelectedPath;
			}
		}
	}
}
