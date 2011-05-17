﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using Bummer.Common;

namespace Bummer.Client {
	public partial class ScheduleForm : Form {
		//private IBackupSchedule job;
		private IBackupTarget target;

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
			dpStartTime.Value = new DateTime( 2000, 1, 1, Job.StartTime.Hour, Job.StartTime.Minute, 0 );
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
				IBackupTarget target = Configuration.TargetPlugins[ i ];
				cbTargetType.Items.Add( new TargetWrapper( target ) );
				if( string.Equals( target.GetType().FullName, Job.TargetType ) ) {
					ind = i;
				}
			}
			if( ind > -1 ) {
				cbTargetType.SelectedIndex = ind;
			}
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
			if( cbIntervalType.SelectedIndex < 0 ) {
				MessageBox.Show( "You have to specify an interval type", "Specify interval type", MessageBoxButtons.OK, MessageBoxIcon.Exclamation );
				e.Cancel = true;
				return;
			}
			if( cbTargetType.SelectedIndex < 0 ) {
				MessageBox.Show( "You have to specify a target type", "Specify target type", MessageBoxButtons.OK, MessageBoxIcon.Exclamation );
				e.Cancel = true;
				return;
			}
			//int interval = (int)nuInterval.Value;
			//if( interval <= 0 ) {
			//    MessageBox.Show( "You have to specify an interval larger than 0", "Specify interval", MessageBoxButtons.OK, MessageBoxIcon.Exclamation );
			//    e.Cancel = true;
			//    return;
			//}
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
			Job.IntervalType = (SchduleIntervalTypes)cbIntervalType.SelectedItem;
			Job.Interval = 1;// (int)nuInterval.Value;
			Job.StartTime = dpStartTime.Value;
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
	}
}
