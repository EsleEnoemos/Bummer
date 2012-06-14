using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using Bummer.UpdateChecker;

namespace Bummer.Client {
	public partial class SettingsDialog : Form {
		public SettingsDialog() {
			InitializeComponent();
		}

		private void btnCheckForUpdates_Click( object sender, EventArgs e ) {
			btnCheckForUpdates.Enabled = false;
			pnlAvailableUpdates.Controls.Clear();
			btnApplyUpdates.Visible = false;
			List<Update> updates = UpdaterChecker.GetAvailableUpdateInformations();
			btnCheckForUpdates.Enabled = true;
			if( updates.Count == 0 ) {
				pnlAvailableUpdates.Controls.Add( new Label{Text = "There are no updates available", AutoSize = true} );
				return;
			}
			btnApplyUpdates.Visible = true;
			foreach( Update update in updates ) {
				pnlAvailableUpdates.Controls.Add( new UpdateInfoControl(update){Dock = DockStyle.Top} );
			}
		}

		private void btnApplyUpdates_Click( object sender, EventArgs e ) {
			const string exe = @"D:\GIT\Bummer\Bummer.Updater\bin\Debug\Bummer.Updater.exe";
			try {
				Process p = Process.Start( exe );
				MessageBox.Show( "Started..." );
			} catch( Exception ex ) {
				MessageBox.Show( ex.Message );
			}
		}
	}
}
