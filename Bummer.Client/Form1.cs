using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Bummer.Common;

namespace Bummer.Client {
	public partial class Form1 : Form {
		internal static Form1 Instance;
		public Form1() {
			Instance = this;
			InitializeComponent();
		}

		private void Form1_Load( object sender, EventArgs e ) {
			RefreshJobs();
//            CommandWrapper.Parse( @"hej	hopp
//hej igen	hopp	i	skogen
//hejallabarn" );
		}
		#region internal void RefreshJobs()
		/// <summary>
		/// 
		/// </summary>
		internal void RefreshJobs() {
			panel1.Controls.Clear();
			List<BackupScheduleWrapper> jobs = Configuration.GetSchedules();
			if( jobs.Count == 0 ) {
				panel1.Controls.Add( new Label {
					Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleCenter, Text = "No jobs defined"
				} );
				return;
			}
			ScheduleItemControl last = null;
			foreach( BackupScheduleWrapper job in jobs ) {
				ScheduleItemControl si = new ScheduleItemControl( job );
				last = si;
				si.Dock = DockStyle.Top;
				panel1.Controls.Add( si );
			}
			if( last != null ) {
				last.Focus();
				last.Select();
			}
		}
		#endregion

		#region private void addScheduleToolStripMenuItem_Click( object sender, System.EventArgs e )
		/// <summary>
		/// This method is called when the addScheduleToolStripMenuItem's Click event has been fired.
		/// </summary>
		/// <param name="sender">The <see cref="object"/> that fired the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> of the event.</param>
		private void addScheduleToolStripMenuItem_Click( object sender, EventArgs e ) {
			ScheduleForm sf = new ScheduleForm();
			if( sf.ShowDialog( this ) == DialogResult.OK ) {
				try {
					sf.Job.Persist();
					RefreshJobs();
				} catch( Exception ex ) {
					MessageBox.Show( "Error saving schedule: {0}".FillBlanks( ex.Message ) );
					return;
				}
			}
		}
		#endregion
	}
}
