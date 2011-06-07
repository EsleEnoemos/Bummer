using System;
using System.Drawing;
using System.Windows.Forms;
using Bummer.Common;
using Bummer.ScheduleRunner;
using Quartz;

namespace Bummer.Client {
	public partial class ScheduleItemControl : UserControl {
		private BackupScheduleWrapper job;
		private Timer timer;
		private bool wasRunning;

		public ScheduleItemControl( BackupScheduleWrapper job ) {
			InitializeComponent();
			this.job = job ?? new BackupScheduleWrapper();
			Disposed += ScheduleItemControl_Disposed;
			timer = new Timer();
			timer.Interval = 1000;
			timer.Tick += timer_Tick;
			timer.Start();
		}
		public ScheduleItemControl()
			: this( new BackupScheduleWrapper() ) {
		}
		void timer_Tick( object sender, EventArgs e ) {
			bool isRunning = ScheduleJobSpawner.IsJobRunning( job );
			if( isRunning ) {
				wasRunning = true;
			} else if( wasRunning ) {
				wasRunning = true;
				job.ReFresh();
				lblLastStarted.Text = job.LastStarted.HasValue ? job.LastStarted.Value.ToString( "yyyy:MM:dd HH:mm:ss" ) : "Never";
				lblLastFinished.Text = job.LastFinished.HasValue ? job.LastFinished.Value.ToString( "yyyy:MM:dd HH:mm:ss" ) : "Never";
				lblNextStart.Text = "";
				if( job.Logs.Count > 0 ) {
					ScheduleJobLog log = job.Logs[ 0 ];
					textBox1.Text = log.Entry;
					textBox1.ForeColor = !log.Success ? Color.Red : SystemColors.WindowText;
					textBox1.Select( 0, 0 );
				}
			}
			UpdateNext();
			btnRunJob.Enabled = !isRunning;
			btnEdit.Enabled = !isRunning;
			btnDelete.Enabled = !isRunning;
			lblLastResult.Visible = !isRunning;
			lblIsRunning.Visible = isRunning;
		}
		private void UpdateNext() {
			//string snr = null;
			if( !Configuration.IsServiceRunning() ) {
				lblNextStart.ForeColor = Color.Red;
				//if( !string.Equals( lblNextStart.Text, "Service is not running" ) ) {
				//    lblNextStart.ForeColor = Color.Red;
				//    //snr = "Service is not running";
				//}
			} else {
				lblNextStart.ForeColor = SystemColors.ControlText;
			}
			try {
				CronExpression ce = new CronExpression( job.CronConfig );
				DateTime? next = ce.GetNextValidTimeAfter( job.LastFinished.HasValue ? job.LastFinished.Value.ToUniversalTime() : DateTime.Now.ToUniversalTime() );
				if( next.HasValue ) {
					string ts = next.Value.ToLocalTime().ToString( "yyyy:MM:dd HH:mm:ss" );
					DateTime lt = next.Value.ToLocalTime();
					if( DateTime.Now > lt ) {
						next = ce.GetNextValidTimeAfter( DateTime.Now.ToUniversalTime() );
						if( next.HasValue ) {
							ts = next.Value.ToLocalTime().ToString( "yyyy:MM:dd HH:mm:ss" );
						}
					} 
					//if( snr != null ) {
					//    ts += " ({0})".FillBlanks( snr );
					//}
					lblNextStart.Text = ts;
				}
			} catch {
			}
		}
		void ScheduleItemControl_Disposed( object sender, EventArgs e ) {
			timer.Stop();
			timer.Dispose();
		}

		private void ScheduleItemControl_Load( object sender, EventArgs e ) {
			lblName.Text = job.Name;
			lblType.Text = job.Job.Name;
			lblTarget.Text = job.Target.Name;
			lblLastStarted.Text = "Never";
			if( job.LastStarted.HasValue ) {
				lblLastStarted.Text = job.LastStarted.Value.ToString( "yyyy:MM:dd HH:mm:ss" );
			}
			lblLastFinished.Text = "Never";
			if( job.LastFinished.HasValue ) {
				lblLastFinished.Text = job.LastFinished.Value.ToString( "yyyy:MM:dd HH:mm:ss" );
			}
			UpdateNext();
			if( job.Logs.Count > 0 ) {
				ScheduleJobLog log = job.Logs[ 0 ];
				textBox1.Text = log.Entry;
				if( !log.Success ) {
					textBox1.ForeColor = Color.Red;
				}
				textBox1.Select( 0, 0 );
			}
		}

		private void btnEdit_Click( object sender, EventArgs e ) {
			ScheduleForm sf = new ScheduleForm( job );
			if( sf.ShowDialog( this ) == DialogResult.OK ) {
				try {
					sf.Job.Persist();
					//if( !string.Equals( job.Name, sf.Job.Name ) ) {
						Form1.Instance.RefreshJobs();
					//}
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
			ScheduleJobSpawner.SpawAndRun( job );
			timer_Tick( timer, new EventArgs() );
			//Enabled = false;
			//try {
			//    job.Execute();
			//    Form1.Instance.RefreshJobs();
			//} finally {
			//    Enabled = true;
			//}
		}
	}
}
