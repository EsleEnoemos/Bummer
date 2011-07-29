using System;
using System.Drawing;
using System.Windows.Forms;
using Bummer.Common;

namespace Bummer.Client {
	public partial class LogViewerControl : UserControl {
		ScheduleJobLog log;
		public LogViewerControl( ScheduleJobLog log = null ) {
			InitializeComponent();
			this.log = log;
		}

		private void LogViewerControl_Load( object sender, EventArgs e ) {
			if( log == null ) {
				return;
			}
			if( !log.Success ) {
				ForeColor = Color.Red;
				label1.Font = new Font( label1.Font, FontStyle.Bold );
			}
			label1.Text = log.Date.ToString( "yyyy-MM-dd HH:mm:ss" );
			//textBox1.Text = log.Entry;
			label2.Text = log.Entry;
			//Height = label2.Height + 10;
			//textBox1.Select( 0, 0 );
		}
	}
}
