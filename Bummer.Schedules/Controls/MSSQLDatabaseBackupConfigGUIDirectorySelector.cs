using System;
using System.Windows.Forms;

namespace Bummer.Schedules.Controls {
	public partial class MSSQLDatabaseBackupConfigGUIDirectorySelector : UserControl {
		public string Directory {
			get {
				return textBox1.Text;
			}
			private set {
				textBox1.Text = value;
			}
		}

		public MSSQLDatabaseBackupConfigGUIDirectorySelector( MSSQLDatabaseBackup.MSSQLDatabaseBackupConfig config ) {
			InitializeComponent();
			textBox1.Text = config.SaveToDir;
		}
		public MSSQLDatabaseBackupConfigGUIDirectorySelector()
			: this( null ) {
		}

		private void btnSelectDirectory_Click( object sender, EventArgs e ) {
			FolderBrowserDialog fd = new FolderBrowserDialog();
			fd.SelectedPath = Directory;
			if( fd.ShowDialog(this) == DialogResult.OK) {
				Directory = fd.SelectedPath;
			}
		}
	}
}
