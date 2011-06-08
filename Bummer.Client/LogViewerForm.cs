using System.Windows.Forms;
using Bummer.Common;

namespace Bummer.Client {
	public partial class LogViewerForm : Form {
		BackupScheduleWrapper job;

		public LogViewerForm( BackupScheduleWrapper job = null ) {
			InitializeComponent();
			this.job = job;
		}

		private void LogViewerForm_Load( object sender, System.EventArgs e ) {
			if( job == null ) {
				return;
			}
			Text = "Log for {0}".FillBlanks( job.Name );
			foreach( ScheduleJobLog scheduleJobLog in job.Logs ) {
				LogViewerControl lvc = new LogViewerControl( scheduleJobLog );
				lvc.Dock = DockStyle.Top;
				panel1.Controls.Add( lvc );
			}
			toolStripStatusLabel1.Text = "{0} items in log".FillBlanks( job.Logs.Count );
		}
	}
}
