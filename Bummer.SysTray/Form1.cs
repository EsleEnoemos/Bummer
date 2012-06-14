using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using Bummer.Client;
using Bummer.Common;
using Quartz;

namespace Bummer.SysTray {
	public partial class Form1 : Form {
		private MenuItem schedulesMenu;
		#region private DirectoryInfo AppDir
		/// <summary>
		/// Gets the AppDir of the Form1
		/// </summary>
		/// <value></value>
		private DirectoryInfo AppDir {
			get {
				return _appDir ?? (_appDir = new DirectoryInfo( Application.StartupPath ));
			}
		}
		private DirectoryInfo _appDir;
		#endregion

		#region public Form1()
		/// <summary>
		/// Initializes a new instance of the <b>Form1</b> class.
		/// </summary>
		public Form1() {
			InitializeComponent();
		}
		#endregion

		#region private void Form1_Load( object sender, EventArgs e )
		/// <summary>
		/// This method is called when the Form1's Load event has been fired.
		/// </summary>
		/// <param name="sender">The <see cref="object"/> that fired the event.</param>
		/// <param name="e">The <see cref="EventArgs"/> of the event.</param>
		private void Form1_Load( object sender, EventArgs e ) {
			Close();
			ContextMenu cm = new ContextMenu();
			MenuItem em = new MenuItem( "Exit" );
			em.Click += ExitClick;
			cm.MenuItems.Add( em );
			cm.MenuItems.Add( 0, new MenuItem( "-" ) );
			MenuItem openClientMenu = new MenuItem( "Open BUMmer client..." );
			openClientMenu.Click += openClientMenu_Click;
			openClientMenu.Enabled = File.Exists( "{0}\\Bummer.Client.exe".FillBlanks( AppDir.FullName ) );
			cm.MenuItems.Add( 0, openClientMenu );

			em = new MenuItem( "Schedules" );
			schedulesMenu = em;
			cm.MenuItems.Add( 2, em );
			cm.MenuItems.Add( 3, new MenuItem( "-" ) );
			cm.MenuItems.Add( 4, new MenuItem( "Settings...", ShowSettings ) );
			cm.MenuItems.Add( 5, new MenuItem( "-" ) );
			cm.Popup += ContextMenuShow;
			notifyIcon1.ContextMenu = cm;
		}
		#endregion

		void ShowSettings( object sender, EventArgs e ) {
			SettingsDialog sd = new SettingsDialog();
			sd.ShowDialog( this );
		}

		#region void openClientMenu_Click( object sender, EventArgs e )
		/// <summary>
		/// This method is called when the openClientMenu's Click event has been fired.
		/// </summary>
		/// <param name="sender">The <see cref="object"/> that fired the event.</param>
		/// <param name="e">The <see cref="EventArgs"/> of the event.</param>
		void openClientMenu_Click( object sender, EventArgs e ) {
			FileInfo fi = new FileInfo( "{0}\\Bummer.Client.exe".FillBlanks( AppDir.FullName ) );
			if( !fi.Exists ) {
				MessageBox.Show( "Unable to locate client.{0}Consider re-installing...".FillBlanks( Environment.NewLine ) );
				return;
			}
			Process.Start( fi.FullName );
		}
		#endregion

		#region void ExitClick( object sender, EventArgs e )
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void ExitClick( object sender, EventArgs e ) {
			Application.Exit();
		}
		#endregion


		#region private void Form1_FormClosing( object sender, FormClosingEventArgs e )
		/// <summary>
		/// This method is called when the Form1's FormClosing event has been fired.
		/// </summary>
		/// <param name="sender">The <see cref="object"/> that fired the event.</param>
		/// <param name="e">The <see cref="FormClosingEventArgs"/> of the event.</param>
		private void Form1_FormClosing( object sender, FormClosingEventArgs e ) {
			if( e.CloseReason == CloseReason.ApplicationExitCall ) {
				return;
			}
			e.Cancel = true;
			Hide();
		}
		#endregion

		#region void ContextMenuShow( object sender, EventArgs e )
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void ContextMenuShow( object sender, EventArgs e ) {
			schedulesMenu.MenuItems.Clear();
			List<BackupScheduleWrapper> jobs = Configuration.GetSchedules();
			foreach( BackupScheduleWrapper job in jobs ) {
				MenuItem mi = new MenuItem( job.Name );
				schedulesMenu.MenuItems.Add( mi );
				MenuItem si = new MenuItem( "Last started:\t{0}".FillBlanks( job.LastStarted.HasValue ? job.LastStarted.Value.ToString( "yyyy-MM-dd HH:mm:ss" ) : "Never" ) );
				si.Enabled = false;
				mi.MenuItems.Add( si );
				si = new MenuItem( "Last finished:\t{0}".FillBlanks( job.LastFinished.HasValue ? job.LastFinished.Value.ToString( "yyyy-MM-dd HH:mm:ss" ) : "Never" ) );
				si.Enabled = false;
				mi.MenuItems.Add( si );
				si = new MenuItem( "Next run:\t{0}".FillBlanks( GetNextRun( job.LastStarted, job.CronConfig ) ) );
				si.Enabled = false;
				mi.MenuItems.Add( si );
				si = new MenuItem( "Settings..." );
				si.Enabled = true;
				si.Tag = job.ID;
				si.Click += ShowJobSettings;
				mi.MenuItems.Add( si );
				if( !ScheduleRunner.ScheduleJobSpawner.IsJobRunning( job ) ) {
					si = new MenuItem( "Run now!" );
					si.Enabled = true;
					si.Tag = job.ID;
					si.Click += RunJobNow;
					mi.MenuItems.Add( si );
				} else {
					si = new MenuItem( "Job is currently running" );
					si.Enabled = false;
					mi.MenuItems.Add( si );
				}
			}
		}
		#endregion
		void ShowJobSettings( object sender, EventArgs e ) {
			MenuItem si = sender as MenuItem;
			if( si == null ) {
				return;
			}
			BackupScheduleWrapper job = Configuration.GetSchedule( (int)si.Tag );
			ScheduleForm sf = new ScheduleForm( job );
			sf.ShowInTaskbar = true;
			if( sf.ShowDialog( this ) == DialogResult.OK ) {
				try {
					sf.Job.Persist();
				} catch( Exception ex ) {
					MessageBox.Show( "Error saving schedule: {0}".FillBlanks( ex.Message ) );
					return;
				}
			}
		}

		#region void RunJobNow( object sender, EventArgs e )
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void RunJobNow( object sender, EventArgs e ) {
			MenuItem si = sender as MenuItem;
			if( si == null ) {
				return;
			}
			ScheduleRunner.ScheduleJobSpawner.SpawAndRun( Configuration.GetSchedule( (int)si.Tag ) );
		}
		#endregion
		#region private string GetNextRun( DateTime? lastRun, string cronString )
		/// <summary>
		/// 
		/// </summary>
		/// <param name="lastRun"></param>
		/// <param name="cronString"></param>
		/// <returns></returns>
		private string GetNextRun( DateTime? lastRun, string cronString ) {
			try {
				CronExpression ce = new CronExpression( cronString );
				DateTime dt = lastRun.HasValue ? lastRun.Value.ToUniversalTime() : DateTime.Now.ToUniversalTime();
				if( DateTime.Now > dt ) {
					dt = DateTime.Now.ToUniversalTime();
				}
				DateTime? next = ce.GetNextValidTimeAfter( dt );
				return next.HasValue ? next.Value.ToLocalTime().ToString( "yyyy-MM-dd HH:mm:ss" ) : "Never";
			} catch {
				return "Never";
			}
		}
		#endregion
	}
}
