using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using Bummer.Common;
using Quartz;

namespace Bummer.Client {
	public partial class ScheduleForm : Form {
		//private IBackupSchedule job;
		private IBackupTarget target;
		private Timer timer;

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
			timer = new Timer();
			timer.Interval = 1000;
			timer.Tick += timer_Tick;
			timer.Start();
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
			CronExpression ce;
			try {
				ce = new CronExpression( Job.CronConfig );
			} catch {
				ce = new CronExpression( "* * * * * ?" );
			}
			//CronExpression ce = new CronExpression( "5 * * * * ?" );
			for( int i = 0; i < 60; i++ ) {
				ListViewItem li = lvNotSelectedSeconds.Items.Add( i < 10 ? "0{0}".FillBlanks( i ) : i.ToString() );
				li.Tag = i.ToString();
				if( ce.seconds.Count < 61 && ce.seconds.Contains( i ) ) {
					li.Selected = true;
				}
			}
			if( lvNotSelectedSeconds.SelectedItems.Count > 0 ) {
				MoveListViewItems( lvNotSelectedSeconds, lvSelectedSeconds );
			}
			for( int i = 0; i < 60; i++ ) {
				ListViewItem li = lvNotSelectedMinutes.Items.Add( i < 10 ? "0{0}".FillBlanks( i ) : i.ToString() );
				li.Tag = i.ToString();
				if( ce.minutes.Count < 61 && ce.minutes.Contains( i ) ) {
					li.Selected = true;
				}
			}
			if( lvNotSelectedMinutes.SelectedItems.Count > 0 ) {
				MoveListViewItems( lvNotSelectedMinutes, lvSelectedMinutes );
			}
			for( int i = 0; i < 24; i++ ) {
				ListViewItem li = lvNotSelectedHours.Items.Add( i < 10 ? "0{0}".FillBlanks( i ) : i.ToString() );
				li.Tag = i.ToString();
				if( ce.hours.Count < 25 && ce.hours.Contains( i ) ) {
					li.Selected = true;
				}
			}
			if( lvNotSelectedHours.SelectedItems.Count > 0 ) {
				MoveListViewItems( lvNotSelectedHours, lvSelectedHours );
			}
			for( int i = 1; i < 32; i++ ) {
				ListViewItem li = lvNotSelectedDates.Items.Add( i < 10 ? "0{0}".FillBlanks( i ) : i.ToString() );
				li.Tag = i.ToString();
				if( ce.daysOfMonth.Count < 32 && ce.daysOfMonth.Contains( i ) ) {
					li.Selected = true;
				}
			}
			if( lvNotSelectedDates.SelectedItems.Count > 0 ) {
				MoveListViewItems( lvNotSelectedDates, lvSelectedDates );
			}
			Array arr = Enum.GetValues( typeof( DayOfWeek ) );
			for( int i = 0; i < arr.Length; i++ ) {
				DayOfWeek d = (DayOfWeek)arr.GetValue( i );
				int iv = (int)d + 1;
				ListViewItem li = lvNotSelectedDays.Items.Add( d.ToString() );
				li.Tag = iv.ToString();
				if( ce.daysOfWeek.Count > 0 && ce.daysOfWeek.Contains( iv ) ) {
					li.Selected = true;
				}
			}
			if( lvNotSelectedDays.SelectedItems.Count > 0 ) {
				MoveListViewItems( lvNotSelectedDays, lvSelectedDays );
			}
			lvNotSelectedDays.ListViewItemSorter = new NumberLIComparer();
			lvNotSelectedDays.Sort();

			lvNotSelectedMonths.Items.Add( "January" ).Tag = 1.ToString();
			lvNotSelectedMonths.Items.Add( "February" ).Tag = 2.ToString();
			lvNotSelectedMonths.Items.Add( "Mars" ).Tag = 3.ToString();
			lvNotSelectedMonths.Items.Add( "April" ).Tag = 4.ToString();
			lvNotSelectedMonths.Items.Add( "May" ).Tag = 5.ToString();
			lvNotSelectedMonths.Items.Add( "June" ).Tag = 6.ToString();
			lvNotSelectedMonths.Items.Add( "July" ).Tag = 7.ToString();
			lvNotSelectedMonths.Items.Add( "August" ).Tag = 8.ToString();
			lvNotSelectedMonths.Items.Add( "September" ).Tag = 9.ToString();
			lvNotSelectedMonths.Items.Add( "October" ).Tag = 10.ToString();
			lvNotSelectedMonths.Items.Add( "November" ).Tag = 11.ToString();
			lvNotSelectedMonths.Items.Add( "December" ).Tag = 12.ToString();
			if( ce.months.Count < 13 ) {
				for( int i = 0; i < lvNotSelectedMonths.Items.Count; i++ ) {
					ListViewItem li = lvNotSelectedMonths.Items[ i ];
					int m = int.Parse( li.Tag.ToString() );
					if( ce.months.Contains( m ) ) {
						li.Selected = true;
					}
				}
				MoveListViewItems( lvNotSelectedMonths, lvSelectedMonths );
			}
			lvNotSelectedMonths.ListViewItemSorter = new NumberLIComparer();
			lvNotSelectedMonths.Sort();


			for( int i = 0; i < groupBox3.Controls.Count; i++ ) {
				Control c = groupBox3.Controls[ i ];
				if( !(c is ListView) ) {
					continue;
				}
				ListView lv = (ListView)c;
				lv.Columns[ 0 ].Width = 150;
			}


			//nuInterval.Value = Job.Interval;
			//dpStartTime.Value = new DateTime( 2000, 1, 1, Job.StartTime.Hour, Job.StartTime.Minute, 0 );
			//arr = Enum.GetValues( typeof( SchduleIntervalTypes ) );
			//int ind = -1;
			//for( int i = 0; i < arr.Length; i++ ) {
			//    SchduleIntervalTypes st = (SchduleIntervalTypes)arr.GetValue( i );
			//    cbIntervalType.Items.Add( st );
			//    if( st == Job.IntervalType ) {
			//        ind = i;
			//    }
			//}
			//if( ind > -1 ) {
			//    cbIntervalType.SelectedIndex = ind;
			//}
			int ind = -1;
			for( int i = 0; i < Configuration.JobPlugins.Count; i++ ) {
				IBackupSchedule plug = Configuration.JobPlugins[ i ];
				cbJobType.Items.Add( new PlugWrapper( plug ) );
				if( string.Equals( Job.JobType, plug.GetType().FullName ) ) {
					ind = i;
				}
			}
			if( ind > -1 ) {
				cbJobType.SelectedIndex = ind;
				if( Job.ID > 0 ) {
					cbJobType.Enabled = false;
				}
			}
			lvPreCommands.ListViewItemSorter = new ListViewItemComparer();
			List<CommandWrapper> commands = CommandWrapper.Parse( Job.PreCommands );
			if( commands.Count > 0 ) {
				int index = 0;
				foreach( CommandWrapper cw in commands ) {
					ListViewItem li = lvPreCommands.Items.Add( cw.Command );
					li.Tag = index++;
					li.SubItems.Add( cw.Arguments );
				}
				FixLVSize( lvPreCommands );
			}
			lvPostCommands.ListViewItemSorter = new ListViewItemComparer();
			commands = CommandWrapper.Parse( Job.PostCommands );
			if( commands.Count > 0 ) {
				int index = 0;
				foreach( CommandWrapper cw in commands ) {
					ListViewItem li = lvPostCommands.Items.Add( cw.Command );
					li.Tag = index++;
					li.SubItems.Add( cw.Arguments );
				}
				FixLVSize( lvPostCommands );
			}
			ind = -1;
			for( int i = 0; i < Configuration.TargetPlugins.Count; i++ ) {
				IBackupTarget tt = Configuration.TargetPlugins[ i ];
				cbTargetType.Items.Add( new TargetWrapper( tt ) );
				if( string.Equals( tt.GetType().FullName, Job.TargetType ) ) {
					ind = i;
				}
			}
			if( ind > -1 ) {
				cbTargetType.SelectedIndex = ind;
			}
			UpdateNext();
		}

		private void timer_Tick( object sender, EventArgs e ) {
			//DateTime now = DateTime.Now;
			//toolStripStatusLabel1.Text = string.Format( "Current time is: {0} (UTC), {1} (Local)", now.ToUniversalTime().ToString( "yyyy-MM-dd HH:mm:ss" ), now.ToString( "yyyy-MM-dd HH:mm:ss" ) );
		}

		private string BuildCronString() {
			
			List<string> cron = new List<string>();
			if( lvSelectedSeconds.Items.Count > 0 ) {
				List<string> tmp = new List<string>();
				foreach( ListViewItem li in lvSelectedSeconds.Items ) {
					tmp.Add( li.Tag.ToString() );
				}
				cron.Add( tmp.ToString( "," ) );
			} else {
				cron.Add( "*" );
			}
			if( lvSelectedMinutes.Items.Count > 0 ) {
				List<string> tmp = new List<string>();
				foreach( ListViewItem li in lvSelectedMinutes.Items ) {
					tmp.Add( li.Tag.ToString() );
				}
				cron.Add( tmp.ToString( "," ) );
			} else {
				cron.Add( "*" );
			}
			if( lvSelectedHours.Items.Count > 0 ) {
				List<string> tmp = new List<string>();
				foreach( ListViewItem li in lvSelectedHours.Items ) {
					tmp.Add( li.Tag.ToString() );
				}
				cron.Add( tmp.ToString( "," ) );
			} else {
				cron.Add( "*" );
			}
			if( lvSelectedDates.Items.Count > 0 ) {
				List<string> tmp = new List<string>();
				foreach( ListViewItem li in lvSelectedDates.Items ) {
					tmp.Add( li.Tag.ToString() );
				}
				cron.Add( tmp.ToString( "," ) );
			} else {
				cron.Add( lvSelectedDays.Items.Count > 0 ? "?" : "*" );
			}

			if( lvSelectedMonths.Items.Count > 0 ) {
				List<string> tmp = new List<string>();
				foreach( ListViewItem li in lvSelectedMonths.Items ) {
					tmp.Add( li.Tag.ToString() );
				}
				cron.Add( tmp.ToString( "," ) );
			} else {
				cron.Add( "*" );
			}
			if( lvSelectedDays.Items.Count > 0 ) {
				List<string> tmp = new List<string>();
				foreach( ListViewItem li in lvSelectedDays.Items ) {
					tmp.Add( li.Tag.ToString() );
				}
				cron.Add( tmp.ToString( "," ) );
			} else {
				cron.Add( "?" );
			}
			return cron.ToString( " " );
		}
		private void UpdateNext() {
			lblNextStart.Text = "Never";
			try {
				string cs = BuildCronString();
				CronExpression ce = new CronExpression( cs );
				DateTime? next = ce.GetNextValidTimeAfter( Job.LastFinished.HasValue ? Job.LastFinished.Value.ToUniversalTime() : DateTime.Now.ToUniversalTime() );
				if( next.HasValue ) {
					//lblNextStart.Text = string.Format( "{0} (UTC), {1} (Local)", next.Value.ToString( "yyyy-MM-dd HH:mm:ss" ), next.Value.ToLocalTime().ToString( "yyyy-MM-dd HH:mm:ss" ) );
					lblNextStart.Text = string.Format( "{0}", next.Value.ToLocalTime().ToString( "yyyy-MM-dd HH:mm:ss" ) );
				}
			} catch {}
		}

		#endregion

		private class PlugWrapper {
			public IBackupSchedule job;

			public PlugWrapper( IBackupSchedule job ) {
				this.job = job;
			}
			public override string ToString() {
				return job.Name;
			}
		}
		private class TargetWrapper {
			public IBackupTarget job;

			public TargetWrapper( IBackupTarget job ) {
				this.job = job;
			}
			public override string ToString() {
				return job.Name;
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
			tbDescription.Text = pw.job.Description;
			pw.job.InitiateConfiguration( pnlJobConfig, Job.JobConfiguration );
		}
		#endregion

		#region private void ScheduleForm_FormClosing( object sender, FormClosingEventArgs e )
		/// <summary>
		/// This method is called when the ScheduleForm's FormClosing event has been fired.
		/// </summary>
		/// <param name="sender">The <see cref="object"/> that fired the event.</param>
		/// <param name="e">The <see cref="FormClosingEventArgs"/> of the event.</param>
		private void ScheduleForm_FormClosing( object sender, FormClosingEventArgs e ) {
			if( DialogResult != DialogResult.OK ) {
				timer.Stop();
				timer.Dispose();
				return;
			}
			string cronString = BuildCronString();
			try {
				CronExpression ce = new CronExpression( cronString );
				DateTime? next = ce.GetNextValidTimeAfter( DateTime.Now );
				if( !next.HasValue ) {
					MessageBox.Show( "You have to select repetitions for the job" );
				}
			} catch( Exception ex ) {
				MessageBox.Show( "Repetition error{0}{1}".FillBlanks( Environment.NewLine, ex.Message ), "Repetition error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation );
				e.Cancel = true;
				return;
			}
			if( DialogResult != DialogResult.OK ) {
				return;
			}
			if( string.IsNullOrEmpty( tbName.Text ) ) {
				MessageBox.Show( "You have to specify a name", "Specify name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation );
				e.Cancel = true;
				return;
			}
			if( cbJobType.SelectedIndex < 0 ) {
				MessageBox.Show( "You have to specify a job type", "Specify job type", MessageBoxButtons.OK, MessageBoxIcon.Exclamation );
				e.Cancel = true;
				return;
			}
			if( cbTargetType.SelectedIndex < 0 ) {
				MessageBox.Show( "You have to specify a target type", "Specify target type", MessageBoxButtons.OK, MessageBoxIcon.Exclamation );
				e.Cancel = true;
				return;
			}
			string config;
			string targetConfig;
			try {
				config = Job.Job.SaveConfiguration();
				targetConfig = target.SaveConfiguration();
			} catch( Exception ex ) {
				MessageBox.Show( ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation );
				e.Cancel = true;
				return;
			}
			_job = Job.Clone();
			Job.Name = tbName.Text;
			PlugWrapper pw = (PlugWrapper)cbJobType.SelectedItem;
			Job.JobType = pw.job.GetType().FullName;
			Job.JobConfiguration = config;
			Job.TargetConfiguration = targetConfig;
			Job.CronConfig = cronString;
			Job.PreCommands = null;
			if( lvPreCommands.Items.Count > 0 ) {
				List<string> list = new List<string>();
				foreach( ListViewItem li in lvPreCommands.Items ) {
					list.Add( "{0}\t{1}".FillBlanks( li.Text, li.SubItems[ 1 ].Text ) );
				}
				Job.PreCommands = list.ToString( Environment.NewLine );
			}
			Job.PostCommands = null;
			if( lvPostCommands.Items.Count > 0 ) {
				List<string> list = new List<string>();
				foreach( ListViewItem li in lvPostCommands.Items ) {
					list.Add( "{0}\t{1}".FillBlanks( li.Text, li.SubItems[ 1 ].Text ) );
				}
				Job.PostCommands = list.ToString( Environment.NewLine );
			}
			timer.Stop();
			timer.Dispose();
		}
		#endregion

		#region private void lvPreCommands_SelectedIndexChanged( object sender, EventArgs e )
		/// <summary>
		/// This method is called when the lvPreCommands's SelectedIndexChanged event has been fired.
		/// </summary>
		/// <param name="sender">The <see cref="object"/> that fired the event.</param>
		/// <param name="e">The <see cref="EventArgs"/> of the event.</param>
		private void lvPreCommands_SelectedIndexChanged( object sender, EventArgs e ) {
			btnRemovePreCommand.Enabled = lvPreCommands.SelectedItems.Count > 0;
			btnEditPreCommand.Enabled = lvPreCommands.SelectedItems.Count == 1;
			btnMoveUpPreCommand.Enabled = lvPreCommands.SelectedItems.Count == 1;
			if( btnMoveUpPreCommand.Enabled ) {
				btnMoveUpPreCommand.Enabled = lvPreCommands.SelectedItems[ 0 ].Index > 0;
			}
			btnMoveDownPreCommand.Enabled = lvPreCommands.SelectedItems.Count == 1;
			if( btnMoveDownPreCommand.Enabled ) {
				btnMoveDownPreCommand.Enabled = lvPreCommands.SelectedItems[ 0 ].Index < (lvPreCommands.Items.Count - 1);
			}
		}
		#endregion

		#region private void btnAddPreCommand_Click( object sender, EventArgs e )
		/// <summary>
		/// This method is called when the btnAddPreCommand's Click event has been fired.
		/// </summary>
		/// <param name="sender">The <see cref="object"/> that fired the event.</param>
		/// <param name="e">The <see cref="EventArgs"/> of the event.</param>
		private void btnAddPreCommand_Click( object sender, EventArgs e ) {
			CommandWrapper cw = EditCommand( null );
			if( cw == null ) {
				return;
			}
			ListViewItem li = lvPreCommands.Items.Add( cw.Command );
			li.SubItems.Add( cw.Arguments );
			FixLVSize( lvPreCommands );
		}
		#endregion

		#region private CommandWrapper EditCommand( CommandWrapper cmd )
		/// <summary>
		/// 
		/// </summary>
		/// <param name="cmd"></param>
		/// <returns></returns>
		private CommandWrapper EditCommand( CommandWrapper cmd ) {
			CommandWrapper c = cmd ?? new CommandWrapper();
			CommandDialog cd = new CommandDialog( c.Command, c.Arguments );
			return cd.ShowDialog( this ) != DialogResult.OK ? null : new CommandWrapper {
				Command = cd.Command, Arguments = cd.Arguments
			};
		}
		#endregion

		#region private void btnEditPreCommand_Click( object sender, EventArgs e )
		/// <summary>
		/// This method is called when the btnEditPreCommand's Click event has been fired.
		/// </summary>
		/// <param name="sender">The <see cref="object"/> that fired the event.</param>
		/// <param name="e">The <see cref="EventArgs"/> of the event.</param>
		private void btnEditPreCommand_Click( object sender, EventArgs e ) {
			ListViewItem li = lvPreCommands.SelectedItems[ 0 ];
			CommandWrapper cw = new CommandWrapper {
				Command = li.Text, Arguments = li.SubItems[ 1 ].Text
			};
			cw = EditCommand( cw );
			if( cw == null ) {
				return;
			}
			li.Text = cw.Command;
			li.SubItems[ 1 ].Text = cw.Arguments;
			FixLVSize( lvPreCommands );
		}
		#endregion

		#region private void FixLVSize( ListView lv )
		/// <summary>
		/// 
		/// </summary>
		/// <param name="lv"></param>
		private void FixLVSize( ListView lv ) {
			lv.AutoResizeColumns( ColumnHeaderAutoResizeStyle.ColumnContent );
		}
		#endregion

		#region private void btnTryPreCommands_Click( object sender, EventArgs e )
		/// <summary>
		/// This method is called when the btnTryPreCommands's Click event has been fired.
		/// </summary>
		/// <param name="sender">The <see cref="object"/> that fired the event.</param>
		/// <param name="e">The <see cref="EventArgs"/> of the event.</param>
		private void btnTryPreCommands_Click( object sender, EventArgs e ) {
			if( lvPreCommands.Items.Count == 0 ) {
				MessageBox.Show( "There are no commands to run..." );
				return;
			}
			List<string> list = new List<string>();
			foreach( ListViewItem li in lvPreCommands.Items ) {
				list.Add( "{0}\t{1}".FillBlanks( li.Text, li.SubItems[ 1 ].Text ) );
			}
			string commands = list.ToString( Environment.NewLine );
			try {
				BackupScheduleWrapper.RunCommands( commands );
			} catch( Exception ex ) {
				MessageBox.Show( "Error: {0}".FillBlanks( ex.Message ) );
			}
		}
		#endregion

		#region private void btnAddPostCommand_Click( object sender, EventArgs e )
		/// <summary>
		/// This method is called when the btnAddPostCommand's Click event has been fired.
		/// </summary>
		/// <param name="sender">The <see cref="object"/> that fired the event.</param>
		/// <param name="e">The <see cref="EventArgs"/> of the event.</param>
		private void btnAddPostCommand_Click( object sender, EventArgs e ) {
			CommandWrapper cw = EditCommand( null );
			if( cw == null ) {
				return;
			}
			ListViewItem li = lvPostCommands.Items.Add( cw.Command );
			li.SubItems.Add( cw.Arguments );
			FixLVSize( lvPostCommands );
		}
		#endregion

		#region private void btnEditPostCommand_Click( object sender, EventArgs e )
		/// <summary>
		/// This method is called when the btnEditPostCommand's Click event has been fired.
		/// </summary>
		/// <param name="sender">The <see cref="object"/> that fired the event.</param>
		/// <param name="e">The <see cref="EventArgs"/> of the event.</param>
		private void btnEditPostCommand_Click( object sender, EventArgs e ) {
			ListViewItem li = lvPostCommands.SelectedItems[ 0 ];
			CommandWrapper cw = new CommandWrapper {
				Command = li.Text, Arguments = li.SubItems[ 1 ].Text
			};
			cw = EditCommand( cw );
			if( cw == null ) {
				return;
			}
			li.Text = cw.Command;
			li.SubItems[ 1 ].Text = cw.Arguments;
			FixLVSize( lvPostCommands );
		}
		#endregion

		#region private void btnTryPostCommand_Click( object sender, EventArgs e )
		/// <summary>
		/// This method is called when the btnTryPostCommand's Click event has been fired.
		/// </summary>
		/// <param name="sender">The <see cref="object"/> that fired the event.</param>
		/// <param name="e">The <see cref="EventArgs"/> of the event.</param>
		private void btnTryPostCommand_Click( object sender, EventArgs e ) {
			if( lvPostCommands.Items.Count == 0 ) {
				MessageBox.Show( "There are no commands to run..." );
				return;
			}
			List<string> list = new List<string>();
			foreach( ListViewItem li in lvPostCommands.Items ) {
				list.Add( "{0}\t{1}".FillBlanks( li.Text, li.SubItems[ 1 ].Text ) );
			}
			string commands = list.ToString( Environment.NewLine );
			try {
				BackupScheduleWrapper.RunCommands( commands );
			} catch( Exception ex ) {
				MessageBox.Show( "Error: {0}".FillBlanks( ex.Message ) );
			}
		}
		#endregion

		#region private void lvPostCommands_SelectedIndexChanged( object sender, EventArgs e )
		/// <summary>
		/// This method is called when the lvPostCommands's SelectedIndexChanged event has been fired.
		/// </summary>
		/// <param name="sender">The <see cref="object"/> that fired the event.</param>
		/// <param name="e">The <see cref="EventArgs"/> of the event.</param>
		private void lvPostCommands_SelectedIndexChanged( object sender, EventArgs e ) {
			btnRemovePostCommand.Enabled = lvPostCommands.SelectedItems.Count > 0;
			btnEditPostCommand.Enabled = lvPostCommands.SelectedItems.Count == 1;
			btnMoveUpPostCommand.Enabled = lvPostCommands.SelectedItems.Count == 1;
			if( btnMoveUpPostCommand.Enabled ) {
				btnMoveUpPostCommand.Enabled = lvPostCommands.SelectedItems[ 0 ].Index > 0;
			}
			btnMoveDownPostCommand.Enabled = lvPostCommands.SelectedItems.Count == 1;
			if( btnMoveDownPostCommand.Enabled ) {
				btnMoveDownPostCommand.Enabled = lvPostCommands.SelectedItems[ 0 ].Index < (lvPostCommands.Items.Count - 1);
			}
		}
		#endregion

		#region private void btnMoveUpPreCommand_Click( object sender, EventArgs e )
		/// <summary>
		/// This method is called when the btnMoveUpPreCommand's Click event has been fired.
		/// </summary>
		/// <param name="sender">The <see cref="object"/> that fired the event.</param>
		/// <param name="e">The <see cref="EventArgs"/> of the event.</param>
		private void btnMoveUpPreCommand_Click( object sender, EventArgs e ) {
			ListViewItem si = lvPreCommands.SelectedItems[ 0 ];
			List<ListViewItem> list = new List<ListViewItem>();
			foreach( ListViewItem li in lvPreCommands.Items ) {
				if( li.Index != si.Index ) {
					list.Add( li );
				}
			}
			int ind = (int)si.Tag;
			list.Insert( ind - 1, si );
			for( int i = 0; i < list.Count; i++ ) {
				list[ i ].Tag = i;
			}
			lvPreCommands.Sort();
			lvPreCommands_SelectedIndexChanged( lvPreCommands, new EventArgs() );
		}
		#endregion

		private class ListViewItemComparer : IComparer {
			public int Compare( object x, object y ) {
				if( x is ListViewItem && y is ListViewItem ) {
					return Compare( (ListViewItem)x, (ListViewItem)y );
				}
				return 0;
			}
			private int Compare( ListViewItem x, ListViewItem y ) {
				int ix = (int)x.Tag;
				return ix.CompareTo( (int)y.Tag );
			}
		}

		#region private void btnMoveDownPreCommand_Click( object sender, EventArgs e )
		/// <summary>
		/// This method is called when the btnMoveDownPreCommand's Click event has been fired.
		/// </summary>
		/// <param name="sender">The <see cref="object"/> that fired the event.</param>
		/// <param name="e">The <see cref="EventArgs"/> of the event.</param>
		private void btnMoveDownPreCommand_Click( object sender, EventArgs e ) {
			ListViewItem si = lvPreCommands.SelectedItems[ 0 ];
			List<ListViewItem> list = new List<ListViewItem>();
			foreach( ListViewItem li in lvPreCommands.Items ) {
				if( li.Index != si.Index ) {
					list.Add( li );
				}
			}
			int ind = (int)si.Tag;
			list.Insert( ind + 1, si );
			for( int i = 0; i < list.Count; i++ ) {
				list[ i ].Tag = i;
			}
			lvPreCommands.Sort();
			lvPreCommands_SelectedIndexChanged( lvPreCommands, new EventArgs() );
		}
		#endregion

		#region private void btnMoveUpPostCommand_Click( object sender, EventArgs e )
		/// <summary>
		/// This method is called when the btnMoveUpPostCommand's Click event has been fired.
		/// </summary>
		/// <param name="sender">The <see cref="object"/> that fired the event.</param>
		/// <param name="e">The <see cref="EventArgs"/> of the event.</param>
		private void btnMoveUpPostCommand_Click( object sender, EventArgs e ) {
			ListViewItem si = lvPostCommands.SelectedItems[ 0 ];
			List<ListViewItem> list = new List<ListViewItem>();
			foreach( ListViewItem li in lvPostCommands.Items ) {
				if( li.Index != si.Index ) {
					list.Add( li );
				}
			}
			int ind = (int)si.Tag;
			list.Insert( ind - 1, si );
			for( int i = 0; i < list.Count; i++ ) {
				list[ i ].Tag = i;
			}
			lvPostCommands.Sort();
			lvPostCommands_SelectedIndexChanged( lvPostCommands, new EventArgs() );
		}
		#endregion

		#region private void btnMoveDownPostCommand_Click( object sender, EventArgs e )
		/// <summary>
		/// This method is called when the btnMoveDownPostCommand's Click event has been fired.
		/// </summary>
		/// <param name="sender">The <see cref="object"/> that fired the event.</param>
		/// <param name="e">The <see cref="EventArgs"/> of the event.</param>
		private void btnMoveDownPostCommand_Click( object sender, EventArgs e ) {
			ListViewItem si = lvPostCommands.SelectedItems[ 0 ];
			List<ListViewItem> list = new List<ListViewItem>();
			foreach( ListViewItem li in lvPostCommands.Items ) {
				if( li.Index != si.Index ) {
					list.Add( li );
				}
			}
			int ind = (int)si.Tag;
			list.Insert( ind + 1, si );
			for( int i = 0; i < list.Count; i++ ) {
				list[ i ].Tag = i;
			}
			lvPostCommands.Sort();
			lvPostCommands_SelectedIndexChanged( lvPostCommands, new EventArgs() );
		}
		#endregion

		#region private void btnRemovePreCommand_Click( object sender, EventArgs e )
		/// <summary>
		/// This method is called when the btnRemovePreCommand's Click event has been fired.
		/// </summary>
		/// <param name="sender">The <see cref="object"/> that fired the event.</param>
		/// <param name="e">The <see cref="EventArgs"/> of the event.</param>
		private void btnRemovePreCommand_Click( object sender, EventArgs e ) {
			while( lvPreCommands.SelectedItems.Count > 0 ) {
				lvPreCommands.Items.Remove( lvPreCommands.SelectedItems[ 0 ] );
			}
		}
		#endregion

		#region private void btnRemovePostCommand_Click( object sender, EventArgs e )
		/// <summary>
		/// This method is called when the btnRemovePostCommand's Click event has been fired.
		/// </summary>
		/// <param name="sender">The <see cref="object"/> that fired the event.</param>
		/// <param name="e">The <see cref="EventArgs"/> of the event.</param>
		private void btnRemovePostCommand_Click( object sender, EventArgs e ) {
			while( lvPostCommands.SelectedItems.Count > 0 ) {
				lvPostCommands.Items.Remove( lvPostCommands.SelectedItems[ 0 ] );
			}
		}
		#endregion

		private void MoveListViewItems( ListView from, ListView to ) {
			to.ListViewItemSorter = null;
			while( from.SelectedItems.Count > 0 ) {
				ListViewItem li = from.SelectedItems[ 0 ];
				ListViewItem newLi = to.Items.Add( li.Text ); //.Tag = li.Tag;
				newLi.Tag = li.Tag;
				from.Items.RemoveAt( li.Index );
			}
			to.ListViewItemSorter = new NumberLIComparer();
			to.Sort();
		}

		private void cbTargetType_SelectedIndexChanged( object sender, EventArgs e ) {
			TargetWrapper tw = cbTargetType.SelectedItem as TargetWrapper;
			pnlTargetConfig.Controls.Clear();
			if( tw == null || tw.job == null ) {
				return;
			}
			Job.TargetType = tw.job.GetType().FullName;
			tbTargetDescription.Text = tw.job.Description;
			target = tw.job;
			target.InitiateConfiguration( pnlTargetConfig, Job.TargetConfiguration );
		}

		private void MoveItemsClick( object sender, EventArgs e ) {
			Button btn = sender as Button;
			if( btn == null ) {
				return;
			}
			if( btn.Tag == null ) {
				return;
			}
			string[] lists = btn.Tag.ToString().Split( '|' );
			if( lists.Length != 2 ) {
				return;
			}
			ListView from = groupBox3.Controls[ lists[ 0 ] ] as ListView;
			ListView to = groupBox3.Controls[ lists[ 1 ] ] as ListView;
			MoveListViewItems( from, to );
			UpdateNext();
		}

		private class NumberLIComparer : IComparer {
			public int Compare( object x, object y ) {
				if( x != null && y != null && x is ListViewItem && y is ListViewItem ) {
					return Compare( (ListViewItem)x, (ListViewItem)y );
				}
				return 0;
			}
			private int Compare( ListViewItem x, ListViewItem y ) {
				int xi;
				int.TryParse( x.Tag as string, out xi );
				int yi;
				int.TryParse( y.Tag as string, out yi );
				return xi.CompareTo( yi );
			}
		}

		private void lblNextStart_Click( object sender, EventArgs e ) {
			(new CronNextForm( BuildCronString(), Job.LastFinished )).ShowDialog( this );
		}
	}
}
