using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Bummer.Client {
	public partial class About : Form {
		public About() {
			InitializeComponent();
		}

		private void About_Load( object sender, EventArgs e ) {
			webBrowser1.DocumentText = string.Format( @"
<html>
	<head>
		<title>About</title>
		<style type=""text/css"">
			a {{color: Blue;}}
		</style>
	</head>
	<body>
		BUMmer is Copyright &copy; Someone Else {0}<br />
		BUMmer used technology from <a target=""_blank"" href=""http://quartznet.sourceforge.net/"">Quartz.NET</a><br />
		A full license for Quartz.NET is available <a target=""_blank"" href=""http://quartznet.sourceforge.net/license.html"">here</a>.<br />
		I have re-compiled, and slightly modified, the version of Quartz.NET I'm using to be able to limit the system requirements of this application to .NET Framework 4.0 Client Profile.<br />
		For a complete list of changes, please contact me at <a target=""_blank"" href=""mailto:lja@someone-else.com"">lja@someone-else.com</a><br /><br />
		BUMmer is free to use for anyone, in any situation.<br />
		It comes with absolutely no warranty, so don't blame be if something gets messed up by using it.<br />
		If you find it useful, or have suggestions/wishes, please drop me a line at the above mail address.<br /><br />
		You're also more than welcome to join me at <a target=""_blank"" href=""http://github.com/EsleEnoemos/Bummer"">github</a> to contribute to the project!
	</body>
</html>", DateTime.Now.Year );
		}

		private void webBrowser1_NewWindow( object sender, System.ComponentModel.CancelEventArgs e ) {
			if( !string.IsNullOrEmpty( webBrowser1.StatusText ) ) {
				try {
					new Uri( webBrowser1.StatusText );
					Process.Start( webBrowser1.StatusText );
					e.Cancel = true;
				} catch {}
			}
			
		}

		private void webBrowser1_Navigating( object sender, WebBrowserNavigatingEventArgs e ) {
		}

		private void webBrowser1_LocationChanged( object sender, EventArgs e ) {

		}
	}
}
