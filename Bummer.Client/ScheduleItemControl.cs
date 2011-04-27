using System;
using System.Drawing;
using System.Windows.Forms;
using Bummer.Common;

namespace Bummer.Client {
	public partial class ScheduleItemControl : UserControl {
		private BackupScheduleWrapper job;
		public ScheduleItemControl( BackupScheduleWrapper job ) {
			InitializeComponent();
			this.job = job ?? new BackupScheduleWrapper();
		}
		public ScheduleItemControl()
			: this( new BackupScheduleWrapper() ) {
		}

		private void ScheduleItemControl_Load( object sender, EventArgs e ) {
			lblName.Text = job.Name;
			lblType.Text = job.Job.Name;
			lblLastStarted.Text = "Never";
			if( job.LastStarted.HasValue ) {
				lblLastStarted.Text = job.LastStarted.Value.ToString( "yyyy:MM:dd HH:mm" );
			}
			lblLastFinished.Text = "Never";
			if( job.LastFinished.HasValue ) {
				lblLastFinished.Text = job.LastFinished.Value.ToString( "yyyy:MM:dd HH:mm" );
			}
			if( job.Logs.Count > 0 ) {
				ScheduleJobLog log = job.Logs[ 0 ];
				textBox1.Text = log.Entry;
				if( !log.Success ) {
					textBox1.ForeColor = Color.Red;
				}
			}
		}

		private void btnEdit_Click( object sender, EventArgs e ) {
			ScheduleForm sf = new ScheduleForm( job );
			if( sf.ShowDialog( this ) == DialogResult.OK ) {
				try {
					sf.Job.Persist();
					Form1.Instance.RefreshJobs();
				} catch( Exception ex ) {
					MessageBox.Show( "Error saving schedule: {0}".FillBlanks( ex.Message ) );
					return;
				}
			}
		}

		#region private void btnDelete_Click( object sender, EventArgs e )
		/// <summary>
		/// This method is called when the btnDelete's Click event has been fired.
		/// </summary>
		/// <param name="sender">The <see cref="object"/> that fired the event.</param>
		/// <param name="e">The <see cref="EventArgs"/> of the event.</param>
		private void btnDelete_Click( object sender, EventArgs e ) {
			if( MessageBox.Show( this, "Are you sure that you want to delete the \"{0}\" job?".FillBlanks( job.Name ), "Confirm deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2 ) != DialogResult.Yes ) {
				return;
			}
			try {
				job.Delete();
				Form1.Instance.RefreshJobs();
			} catch( Exception ex ) {
				MessageBox.Show( "Error deleting job: {0}".FillBlanks( ex.Message ) );
			}
		}
		#endregion

		private void btnRunJob_Click( object sender, EventArgs e ) {
			Enabled = false;
			try {
				job.Execute();
				Form1.Instance.RefreshJobs();
			} finally {
				Enabled = true;
			}
		}
	}
}
