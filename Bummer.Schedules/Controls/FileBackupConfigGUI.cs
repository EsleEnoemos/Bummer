using System;
using System.Windows.Forms;

namespace Bummer.Schedules.Controls {
	public partial class FileBackupConfigGUI : UserControl {
		private FileBackup.FileBackupConfig conf;
		#region public FileBackupConfigGUI( FileBackup.FileBackupConfig config )
		/// <summary>
		/// Initializes a new instance of the <b>FileBackupConfigGUI</b> class.
		/// </summary>
		/// <param name="config"></param>
		public FileBackupConfigGUI( FileBackup.FileBackupConfig config ) {
			InitializeComponent();
			conf = config ?? new FileBackup.FileBackupConfig();
			tbDirectory.Text = conf.Directory;
			cbCompress.Checked = conf.CompressFiles;
			tbZipFilename.Visible = cbCompress.Checked;
			cbAddDateToZip.Visible = cbCompress.Checked;
			label6.Visible = cbCompress.Checked;
			label7.Visible = cbCompress.Checked;
			label5.Visible = cbCompress.Checked;
			tbLocalTempDir.Visible = cbCompress.Checked;
			btnBrowseForLocalTemp.Visible = cbCompress.Checked;
			if( cbCompress.Checked ) {
				tbZipFilename.Text = conf.ZipFilename;
				cbAddDateToZip.Checked = conf.AddDateToFilename;
				tbLocalTempDir.Text = conf.LocalTempDirectory;
			}
			cbBackupType.Items.Add( BackupTypes.ModifiedOnly );
			cbBackupType.Items.Add( BackupTypes.All );
			cbBackupType.SelectedIndex = conf.BackupType == BackupTypes.All ? 1 : 0;
			foreach( string ft in conf.Filetypes ) {
				lvFileTypes.Items.Add( ft );
			}
			lvFileTypes.AutoResizeColumns( ColumnHeaderAutoResizeStyle.ColumnContent );
		}
		#endregion
		#region public FileBackupConfigGUI()
		/// <summary>
		/// Initializes a new instance of the <b>FileBackupConfigGUI</b> class.
		/// </summary>
		public FileBackupConfigGUI()
			: this( null ) {
		}
		#endregion

		#region private void btnSelectDirectory_Click( object sender, EventArgs e )
		/// <summary>
		/// This method is called when the btnSelectDirectory's Click event has been fired.
		/// </summary>
		/// <param name="sender">The <see cref="object"/> that fired the event.</param>
		/// <param name="e">The <see cref="EventArgs"/> of the event.</param>
		private void btnSelectDirectory_Click( object sender, EventArgs e ) {
			FolderBrowserDialog fd = new FolderBrowserDialog();
			fd.SelectedPath = tbDirectory.Text;
			if( fd.ShowDialog( this ) == DialogResult.OK ) {
				tbDirectory.Text = fd.SelectedPath;
			}
		}
		#endregion

		#region private void listView1_SelectedIndexChanged( object sender, EventArgs e )
		/// <summary>
		/// This method is called when the listView1's SelectedIndexChanged event has been fired.
		/// </summary>
		/// <param name="sender">The <see cref="object"/> that fired the event.</param>
		/// <param name="e">The <see cref="EventArgs"/> of the event.</param>
		private void listView1_SelectedIndexChanged( object sender, EventArgs e ) {
			btnRemoveFileType.Enabled = lvFileTypes.SelectedItems.Count > 0;
		}
		#endregion

		#region private void FileBackupConfigGUI_Load( object sender, EventArgs e )
		/// <summary>
		/// This method is called when the FileBackupConfigGUI's Load event has been fired.
		/// </summary>
		/// <param name="sender">The <see cref="object"/> that fired the event.</param>
		/// <param name="e">The <see cref="EventArgs"/> of the event.</param>
		private void FileBackupConfigGUI_Load( object sender, EventArgs e ) {
		}
		#endregion

		#region internal FileBackup.FileBackupConfig Save()
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		internal FileBackup.FileBackupConfig Save() {
			FileBackup.FileBackupConfig config = new FileBackup.FileBackupConfig();
			if( string.IsNullOrEmpty( tbDirectory.Text ) ) {
				throw new Exception( "You must specify a directory to backup" );
			}
			config.Directory = tbDirectory.Text;
			config.BackupType = (BackupTypes)cbBackupType.SelectedItem;
			foreach( ListViewItem li in lvFileTypes.Items ) {
				config.Filetypes.Add( li.Text );
			}
			config.CompressFiles = cbCompress.Checked;
			if( config.CompressFiles ) {
				if( string.IsNullOrEmpty( tbZipFilename.Text ) ) {
					throw new Exception( "You have to specify a name for the zip-file" );
				}
				if( string.IsNullOrEmpty( tbLocalTempDir.Text ) ) {
					throw new Exception( "You have to specify a local temp-directory" );
				}
				config.LocalTempDirectory = tbLocalTempDir.Text;
				config.ZipFilename = tbZipFilename.Text;
				config.AddDateToFilename = cbAddDateToZip.Checked;
			}
			return config;
		}
		#endregion

		#region private void btnAddFileType_Click( object sender, EventArgs e )
		/// <summary>
		/// This method is called when the btnAddFileType's Click event has been fired.
		/// </summary>
		/// <param name="sender">The <see cref="object"/> that fired the event.</param>
		/// <param name="e">The <see cref="EventArgs"/> of the event.</param>
		private void btnAddFileType_Click( object sender, EventArgs e ) {
			InputDialog id = new InputDialog( "Enter a file type (extension)" );
			if( id.ShowDialog( this ) != DialogResult.OK ) {
				return;
			}
			if( FileTypeAdded( id.Value ) ) {
				MessageBox.Show( "Duplicate file types can not be added" );
				return;
			}
			lvFileTypes.Items.Add( id.Value );
			lvFileTypes.AutoResizeColumns( ColumnHeaderAutoResizeStyle.ColumnContent );
		}
		#endregion
		#region private bool FileTypeAdded( string that )
		/// <summary>
		/// 
		/// </summary>
		/// <param name="that"></param>
		/// <returns></returns>
		private bool FileTypeAdded( string that ) {
			foreach( ListViewItem li in lvFileTypes.Items ) {
				if( string.Equals( li.Text, that, StringComparison.OrdinalIgnoreCase ) ) {
					return true;
				}
			}
			return false;
		}
		#endregion

		#region private void btnRemoveFileType_Click( object sender, EventArgs e )
		/// <summary>
		/// This method is called when the btnRemoveFileType's Click event has been fired.
		/// </summary>
		/// <param name="sender">The <see cref="object"/> that fired the event.</param>
		/// <param name="e">The <see cref="EventArgs"/> of the event.</param>
		private void btnRemoveFileType_Click( object sender, EventArgs e ) {
			while( lvFileTypes.SelectedItems.Count > 0 ) {
				lvFileTypes.Items.Remove( lvFileTypes.SelectedItems[ 0 ] );
			}
		}
		#endregion

		private void cbCompress_CheckedChanged( object sender, EventArgs e ) {
			tbZipFilename.Visible = cbCompress.Checked;
			cbAddDateToZip.Visible = cbCompress.Checked;
			label6.Visible = cbCompress.Checked;
			label7.Visible = cbCompress.Checked;
			label5.Visible = cbCompress.Checked;
			tbLocalTempDir.Visible = cbCompress.Checked;
			btnBrowseForLocalTemp.Visible = cbCompress.Checked;
		}

		private void btnBrowseForLocalTemp_Click( object sender, EventArgs e ) {
			FolderBrowserDialog fd = new FolderBrowserDialog();
			fd.SelectedPath = tbLocalTempDir.Text;
			if( fd.ShowDialog( this ) == DialogResult.OK ) {
				tbLocalTempDir.Text = fd.SelectedPath;
			}
		}
	}
}
