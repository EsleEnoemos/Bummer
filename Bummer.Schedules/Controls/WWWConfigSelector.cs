using System;
using System.Windows.Forms;

namespace Bummer.Schedules.Controls {
	public partial class WWWConfigSelector : UserControl {
		public WWWConfigSelector( HTTPTarget.WWWConfig config ) {
			InitializeComponent();
			if( config != null ) {
				tbURL.Text = config.URL;
				tbUsername.Text = config.Username;
				tbPassword.Text = config.Password;
			}
		}
		public WWWConfigSelector()
			: this( null ) {
		}

		public HTTPTarget.WWWConfig Save() {
			HTTPTarget.WWWConfig config = new HTTPTarget.WWWConfig();
			if( string.IsNullOrEmpty( tbURL.Text ) ) {
				throw new Exception( "You have to specify an URL for the target" );
			}
			if( !tbURL.Text.Contains( "://" ) ) {
				throw new Exception( "The URL must contain protocol (e.g. http:// or https://) in the target" );
			}
			config.URL = tbURL.Text;
			config.Username = tbUsername.Text;
			config.Password = tbPassword.Text;
			return config;
		}
	}
}
