using System.Windows.Forms;

namespace Bummer.Schedules.Controls {
	public partial class MSSQLDatabaseBackupConfigGUIFTPSelector : UserControl {
		public string Server {
			get {
				return tbServer.Text;
			}
		}
		public string Username {
			get {
				return tbUsername.Text;
			}
		}
		public string Password {
			get {
				return tbPassword.Text;
			}
		}
		public string RemoteDirectory {
			get {
				return tbRemoteDir.Text;
			}
		}

		public MSSQLDatabaseBackupConfigGUIFTPSelector( MSSQLDatabaseBackup.MSSQLDatabaseBackupConfig config ) {
			InitializeComponent();
			tbServer.Text = config.FTPServer;
			tbUsername.Text = config.FTPUsername;
			tbPassword.Text = config.FTPPassword;
			tbRemoteDir.Text = config.FTPRemoteDirectory;
		}
		public MSSQLDatabaseBackupConfigGUIFTPSelector()
			: this( new MSSQLDatabaseBackup.MSSQLDatabaseBackupConfig() ) {
		}
	}
}
