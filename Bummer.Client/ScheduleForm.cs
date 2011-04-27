using System;
using System.Windows.Forms;
using Bummer.Common;

namespace Bummer.Client {
	public partial class ScheduleForm : Form {
		//private IBackupSchedule job;

		#region internal BackupScheduleWrapper Job
		/// <summary>
		/// Gets the Job of the ScheduleForm
		/// </summary>
		/// <value></value>
		internal BackupScheduleWrapper Job {
			get {
				return _job;
			}
		}
		private BackupScheduleWrapper _job;
		#endregion
		#region public ScheduleForm( BackupScheduleWrapper job )
		/// <summary>
		/// Initializes a new instance of the <b>ScheduleForm</b> class.
		/// </summary>
		/// <param name="job"></param>
		public ScheduleForm( BackupScheduleWrapper job ) {
			InitializeComponent();
			_job = job.Clone();
		}
		#endregion
		#region public ScheduleForm()
		/// <summary>
		/// Initializes a new instance of the <b>ScheduleForm</b> class.
		/// </summary>
		public ScheduleForm()
			: this( new BackupScheduleWrapper() ) {
		}
		#endregion

		#region private void ScheduleForm_Load( object sender, EventArgs e )
		/// <summary>
		/// This method is called when the ScheduleForm's Load event has been fired.
		/// </summary>
		/// <param name="sender">The <see cref="object"/> that fired the event.</param>
		/// <param name="e">The <see cref="EventArgs"/> of the event.</param>
		private void ScheduleForm_Load( object sender, EventArgs e ) {
			tbName.Text = Job.Name;
			nuInterval.Value = Job.Interval;
			dpStartFrom.Value = new DateTime( 2000, 1, 1, Job.StartFromTime.Hour, Job.StartFromTime.Minute, 0 );
			dpStartTo.Value = new DateTime( 2000, 1, 1, Job.StartToTime.Hour, Job.StartToTime.Minute, 0 );
			Array arr = Enum.GetValues( typeof( SchduleIntervalTypes ) );
			int ind = -1;
			for( int i = 0; i < arr.Length; i++ ) {
				SchduleIntervalTypes st = (SchduleIntervalTypes)arr.GetValue( i );
				cbIntervalType.Items.Add( st );
				if( st == Job.IntervalType ) {
					ind = i;
				}
			}
			if( ind > -1 ) {
				cbIntervalType.SelectedIndex = ind;
			}
			ind = -1;
			for( int i = 0; i < Configuration.Plugins.Count; i++ ) {
				IBackupSchedule plug = Configuration.Plugins[ i ];
				cbJobType.Items.Add( new PlugWrapper( plug ) );
				if( string.Equals( Job.JobType, plug.GetType().FullName ) ) {
					ind = i;
				}
			}
			if( ind > -1 ) {
				cbJobType.SelectedIndex = ind;
			}
		}
		#endregion

		private class PlugWrapper {
			public IBackupSchedule job;

			public string Name {
				get {
					return job.Name;
				}
			}
			public PlugWrapper( IBackupSchedule job ) {
				this.job = job;
			}
			public override string ToString() {
				return Name;
			}
		}

		#region private void cbJobType_SelectedIndexChanged( object sender, EventArgs e )
		/// <summary>
		/// This method is called when the cbJobType's SelectedIndexChanged event has been fired.
		/// </summary>
		/// <param name="sender">The <see cref="object"/> that fired the event.</param>
		/// <param name="e">The <see cref="EventArgs"/> of the event.</param>
		private void cbJobType_SelectedIndexChanged( object sender, EventArgs e ) {
			PlugWrapper pw = cbJobType.SelectedItem as PlugWrapper;
			pnlJobConfig.Controls.Clear();
			if( pw == null || pw.job == null ) {
				return;
			}
			Job.JobType = pw.job.GetType().FullName;
			pw.job.InitiateConfiguration( pnlJobConfig, Job.Configuration );
		}
		#endregion

		private void ScheduleForm_FormClosing( object sender, FormClosingEventArgs e ) {
			if( DialogResult != DialogResult.OK ) {
				return;
			}
			if( string.IsNullOrEmpty( tbName.Text ) ) {
				MessageBox.Show( "You have to specify a name", "Specify name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation );
				e.Cancel = true;
				return;
			}
			if( cbJobType.SelectedIndex < 0 ) {
				MessageBox.Show( "You have to specify a type", "Specify type", MessageBoxButtons.OK, MessageBoxIcon.Exclamation );
				e.Cancel = true;
				return;
			}
			if( cbIntervalType.SelectedIndex < 0 ) {
				MessageBox.Show( "You have to specify an interval type", "Specify interval type", MessageBoxButtons.OK, MessageBoxIcon.Exclamation );
				e.Cancel = true;
				return;
			}
			int interval = (int)nuInterval.Value;
			if( interval <= 0 ) {
				MessageBox.Show( "You have to specify an interval larger than 0", "Specify interval", MessageBoxButtons.OK, MessageBoxIcon.Exclamation );
				e.Cancel = true;
				return;
			}
			string config;
			try {
				config = Job.Job.SaveConfiguration();
			} catch( Exception ex ) {
				MessageBox.Show( ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation );
				e.Cancel = true;
				return;
			}
			_job = Job.Clone();
			Job.Name = tbName.Text;
			PlugWrapper pw = (PlugWrapper)cbJobType.SelectedItem;
			Job.JobType = pw.job.GetType().FullName;
			Job.Configuration = config;
			Job.IntervalType = (SchduleIntervalTypes)cbIntervalType.SelectedItem;
			Job.Interval = (int)nuInterval.Value;
			Job.StartFromTime = dpStartFrom.Value;
			Job.StartToTime = dpStartTo.Value;

		}
	}
}
