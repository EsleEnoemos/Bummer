using System;
using System.Windows.Forms;
using Bummer.Common;

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
		public string Port {
			get {
				return tbPort.Text;
			}
		}

		#region public FTPConfigSelector( FTPTarget.FTPConfig config )
		/// <summary>
		/// Initializes a new instance of the <b>FTPConfigSelector</b> class.
		/// </summary>
		/// <param name="config"></param>
		public FTPConfigSelector( FTPTarget.FTPConfig config ) {
			InitializeComponent();
			if( config != null ) {
				tbServer.Text = config.Server;
				tbUsername.Text = config.Username;
				tbPassword.Text = config.Password;
				tbRemoteDir.Text = config.RemoteDirectory;
				tbPort.Text = config.Port > 0 ? config.Port.ToString() : "";
				cbUseSSL.Checked = config.UseSSL;
				cbIgnoreSSLErrors.Checked = config.IgnoreSSLErrors;
				cbIgnoreSSLErrors.Visible = config.UseSSL;
				cbPassive.Checked = config.Passive;
			}
		}
		#endregion

		#region public FTPConfigSelector()
		/// <summary>
		/// Initializes a new instance of the <b>FTPConfigSelector</b> class.
		/// </summary>
		public FTPConfigSelector()
			: this( null ) {
		}
		#endregion

		#region public FTPTarget.FTPConfig Save()
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public FTPTarget.FTPConfig Save() {
			FTPTarget.FTPConfig config = new FTPTarget.FTPConfig();
			if( string.IsNullOrEmpty( Server ) ) {
				throw new Exception( "You have to specify an FTP server" );
			}
			config.Server = Server;
			if( string.IsNullOrEmpty( Username ) ) {
				throw new Exception( "You have to specify a FTP username" );
			}
			config.Username = Username;
			if( string.IsNullOrEmpty( Password ) ) {
				throw new Exception( "You have to specify a FTP password" );
			}
			config.Password = Password;
			config.RemoteDirectory = RemoteDirectory;
			int p;
			if( !int.TryParse( Port, out p ) ) {
				throw new Exception( "You have to specify a port" );
			}
			if( p < 1 || p > ushort.MaxValue ) {
				throw new Exception( "Port must have a value between 1 and {0}".FillBlanks( ushort.MaxValue ) );
			}
			config.Port = p;
			config.UseSSL = cbUseSSL.Checked;
			config.Passive = cbPassive.Checked;
			return config;
		}
		#endregion

		private void cbUseSSL_CheckedChanged( object sender, EventArgs e ) {
			cbIgnoreSSLErrors.Visible = cbUseSSL.Checked;
		}
	}
}
