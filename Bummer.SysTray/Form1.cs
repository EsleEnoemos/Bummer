using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using Bummer.Common;

namespace Bummer.SysTray {
	public partial class Form1 : Form {
		private bool baloonVisible;
		private bool runningCheckInProgress;
		private DirectoryInfo AppDir {
			get {
				return _appDir ?? (_appDir = new DirectoryInfo( Application.StartupPath ));
			}
		}
		private DirectoryInfo _appDir;

		public Form1() {
			InitializeComponent();
		}

		private void Form1_Load( object sender, EventArgs e ) {
			Close();
			ContextMenu cm = new ContextMenu();
			MenuItem em = new MenuItem("Exit" );
			em.Click += ExitClick;
			cm.MenuItems.Add( em );
			cm.MenuItems.Add( 0, new MenuItem( "-" ) );
			MenuItem openClientMenu = new MenuItem("Open BUMmer client...");
			openClientMenu.Click += openClientMenu_Click;
			openClientMenu.Enabled = File.Exists( "{0}\\Bummer.Client.exe".FillBlanks( AppDir.FullName ) );
			cm.MenuItems.Add( 0, openClientMenu );
			notifyIcon1.ContextMenu = cm;
		}

		void openClientMenu_Click( object sender, EventArgs e ) {
			FileInfo fi = new FileInfo( "{0}\\Bummer.Client.exe".FillBlanks( AppDir.FullName ) );
			if( !fi.Exists ) {
				MessageBox.Show( "Unable to locate client.{0}Consider re-installing...".FillBlanks( Environment.NewLine ) );
				return;
			}
			Process.Start( fi.FullName );
		}

		void ExitClick( object sender, EventArgs e ) {
			Application.Exit();
		}

		void notifyIcon1_MouseMove( object sender, MouseEventArgs e ) {
			if( baloonVisible || runningCheckInProgress ) {
				return;
			}
			runningCheckInProgress = true;
			List<BackupScheduleWrapper> jobs = Configuration.GetSchedules();
			List<string> msg = new List<string>();
			foreach( BackupScheduleWrapper job in jobs ) {
				if( ScheduleRunner.ScheduleJobSpawner.IsJobRunning( job ) ) {
					msg.Add( job.Name );
				}
			}
			if( msg.Count > 0 ) {
				Text = "";
				notifyIcon1.BalloonTipTitle = "Running schedules";
				notifyIcon1.BalloonTipText = msg.ToString( Environment.NewLine );
				notifyIcon1.ShowBalloonTip( 1000 );
			} else {
				Text = "No schedules are running";
			}
			runningCheckInProgress = false;
		}

		private void Form1_FormClosing( object sender, FormClosingEventArgs e ) {
			if( e.CloseReason == CloseReason.ApplicationExitCall ) {
				return;
			}
			e.Cancel = true;
			Hide();
		}

		private void notifyIcon1_BalloonTipShown( object sender, EventArgs e ) {
			baloonVisible = true;
		}

		private void notifyIcon1_BalloonTipClosed( object sender, EventArgs e ) {
			baloonVisible = false;
		}

		private void notifyIcon1_BalloonTipClicked( object sender, EventArgs e ) {
			baloonVisible = false;
		}
	}
}
