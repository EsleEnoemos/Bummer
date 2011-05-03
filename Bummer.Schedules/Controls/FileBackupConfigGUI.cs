using System;
using System.Windows.Forms;
using Bummer.Common;

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
			tbDirectory.Text = conf.Directory;
			cbCompress.Checked = conf.CompressFiles;
			tbZipFilename.Visible = cbCompress.Checked;
			cbAddDateToZip.Visible = cbCompress.Checked;
			label6.Visible = cbCompress.Checked;
			label7.Visible = cbCompress.Checked;
			if( cbCompress.Checked ) {
				tbZipFilename.Text = conf.ZipFilename;
				cbAddDateToZip.Checked = conf.AddDateToFilename;
			}
			cbBackupType.Items.Add( BackupTypes.ModifiedOnly );
			cbBackupType.Items.Add( BackupTypes.All );
			cbBackupType.SelectedIndex = conf.BackupType == BackupTypes.All ? 1 : 0;
			foreach( string ft in conf.Filetypes ) {
				lvFileTypes.Items.Add( ft );
			}
			lvFileTypes.AutoResizeColumns( ColumnHeaderAutoResizeStyle.ColumnContent );
			cbSaveType.Items.Add( SaveAsTypes.Directory );
			cbSaveType.Items.Add( SaveAsTypes.FTP );
			switch( conf.SaveAs ) {
				case SaveAsTypes.FTP:
					cbSaveType.SelectedIndex = 1;
					break;
				default:
					cbSaveType.SelectedIndex = 0;
					break;
			}
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
			config.SaveAs = (SaveAsTypes)cbSaveType.SelectedItem;
			config.CompressFiles = cbCompress.Checked;
			if( config.CompressFiles ) {
				if( string.IsNullOrEmpty( tbZipFilename.Text ) ) {
					throw new Exception( "You have to specify a name for the zip-file" );
				}
				config.ZipFilename = tbZipFilename.Text;
				config.AddDateToFilename = cbAddDateToZip.Checked;
			}
			switch( config.SaveAs ) {
				case SaveAsTypes.Directory:
					DirectoryConfigSelector ds = pnlSaveAsConfig.Controls[ 0 ] as DirectoryConfigSelector;
					if( ds == null ) {
						throw new Exception( "Unable to find directory selector" );
					}
					if( string.IsNullOrEmpty( ds.Directory ) ) {
						throw new Exception( "You have to select a directory to save backup to" );
					}
					config.SaveToDir = ds.Directory;
					break;
				case SaveAsTypes.FTP:
					FTPConfigSelector fs = pnlSaveAsConfig.Controls[ 0 ] as FTPConfigSelector;
					if( fs == null ) {
						throw new Exception( "Unable to find FTP selector" );
					}
					if( string.IsNullOrEmpty( fs.Server ) ) {
						throw new Exception( "You have to specify an FTP server" );
					}
					config.FTPServer = fs.Server;
					if( string.IsNullOrEmpty( fs.Username ) ) {
						throw new Exception( "You have to specify a FTP username" );
					}
					config.FTPUsername = fs.Username;
					if( string.IsNullOrEmpty( fs.Password ) ) {
						throw new Exception( "You have to specify a FTP password" );
					}
					config.FTPPassword = fs.Password;
					if( string.IsNullOrEmpty( fs.LocalTemp ) ) {
						throw new Exception( "You have to specify a local TEMP-directory" );
					}
					config.FTPLocalTempDirectory = fs.LocalTemp;
					config.FTPRemoteDirectory = fs.RemoteDirectory;
					int p;
					if( !int.TryParse( fs.Port, out p ) ) {
						throw new Exception( "You have to specify a port" );
					}
					if( p < 1 || p > ushort.MaxValue ) {
						throw new Exception( "Port must have a value between 1 and {0}".FillBlanks( ushort.MaxValue ) );
					}
					config.FTPPort = p;
					break;
				default:
					throw new Exception( "Unknown save as type {0}".FillBlanks( config.SaveAs ) );
			}
			return config;
		}
		#endregion

		#region private void cbSaveType_SelectedIndexChanged( object sender, EventArgs e )
		/// <summary>
		/// This method is called when the cbSaveType's SelectedIndexChanged event has been fired.
		/// </summary>
		/// <param name="sender">The <see cref="object"/> that fired the event.</param>
		/// <param name="e">The <see cref="EventArgs"/> of the event.</param>
		private void cbSaveType_SelectedIndexChanged( object sender, EventArgs e ) {
			SaveAsTypes st = (SaveAsTypes)cbSaveType.SelectedItem;
			pnlSaveAsConfig.Controls.Clear();
			Control c;
			if( st == SaveAsTypes.Directory ) {
				c = new DirectoryConfigSelector( conf.SaveToDir );
			} else {
				c = new FTPConfigSelector( conf );
			}
			c.Dock = DockStyle.Fill;
			pnlSaveAsConfig.Controls.Add( c );
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
		}
	}
}
