using System.Windows.Forms;

namespace Bummer.Schedules.Controls {
	public partial class FTPConfigSelector : UserControl {
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
		public string LocalTemp {
			get {
				return tbLocalTemp.Text;
			}
		}
		public string Port {
			get {
				return tbPort.Text;
			}
		}

		public FTPConfigSelector( IFTPConfig config ) {
			InitializeComponent();
			if( config != null ) {
				tbServer.Text = config.FTPServer;
				tbUsername.Text = config.FTPUsername;
				tbPassword.Text = config.FTPPassword;
				tbRemoteDir.Text = config.FTPRemoteDirectory;
				tbLocalTemp.Text = config.FTPLocalTempDirectory;
				tbPort.Text = config.FTPPort > 0 ? config.FTPPort.ToString() : "";
			}
		}

		public FTPConfigSelector()
			: this( null ) {
		}

		private void btnBrowseForLocalTempDirectory_Click( object sender, System.EventArgs e ) {
			FolderBrowserDialog fd = new FolderBrowserDialog();
			fd.SelectedPath = tbLocalTemp.Text;
			if( fd.ShowDialog(this) == DialogResult.OK ) {
				tbLocalTemp.Text = fd.SelectedPath;
			}
		}
	}
}
