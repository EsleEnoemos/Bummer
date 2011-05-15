using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using Bummer.Common;
using Bummer.Schedules.Controls;
using Ionic.Zip;

namespace Bummer.Schedules {
	public class FileBackup : IBackupSchedule {

		private FileBackupConfigGUI gui;
		#region public string Name
		/// <summary>
		/// Gets the Name of the FileBackup
		/// </summary>
		/// <value></value>
		public string Name {
			get {
				return "File backup";
			}
		}
		#endregion

		#region public string Description
		/// <summary>
		/// Gets the Description of the FileBackup
		/// </summary>
		/// <value></value>
		public string Description {
			get {
				return _description ?? (_description = "Backup local files.{0}The files can be stored locally, or be uploaded to an FTP-server.{0}Both complete and modification based backups can be performed.{0}Filters can be configured to only backup specific file types".FillBlanks( Environment.NewLine ));
			}
		}
		private string _description;
		#endregion

		#region public void InitiateConfiguration( Control container, string config )
		/// <summary>
		/// 
		/// </summary>
		/// <param name="container"></param>
		/// <param name="config"></param>
		public void InitiateConfiguration( Control container, string config ) {
			gui = new FileBackupConfigGUI( FileBackupConfig.Load( config ) );
			container.Controls.Add( gui );
		}
		#endregion

		#region public string SaveConfiguration()
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public string SaveConfiguration() {
			if( gui == null ) {
				throw new Exception( "GUI not initialized" );
			}
			return gui.Save().Save();
		}
		#endregion

		#region public string Execute( string config, int jobID, IBackupTarget target )
		/// <summary>
		/// 
		/// </summary>
		/// <param name="config"></param>
		/// <param name="jobID"></param>
		/// <param name="target"></param>
		/// <returns></returns>
		public string Execute( string config, int jobID, IBackupTarget target ) {
			using( BackupRunner br = new BackupRunner( FileBackupConfig.Load( config ), jobID, target ) ) {
				int count = br.Run();
				return "{0} files was backed up".FillBlanks( count );
			}
		}
		#endregion

		#region public void Delete( string config, int jobID )
		/// <summary>
		/// 
		/// </summary>
		/// <param name="config"></param>
		/// <param name="jobID"></param>
		public void Delete( string config, int jobID ) {
			BackupRunner.Cleanup( jobID );
		}
		#endregion

		public class FileBackupConfig {
			#region private static XmlSerializer Serializer
			/// <summary>
			/// Gets the Serializer of the MSSQLDatabaseBackupConfig
			/// </summary>
			/// <value></value>
			private static XmlSerializer Serializer {
				get {
					return _serializer ?? (_serializer = new XmlSerializer( typeof( FileBackupConfig ) ));
				}
			}
			private static XmlSerializer _serializer;
			#endregion
			public BackupTypes BackupType;
			public string Directory;
			#region public List<string> Filetypes
			/// <summary>
			/// Get/Sets the Filetypes of the FileBackupConfig
			/// </summary>
			/// <value></value>
			public List<string> Filetypes {
				get {
					return _filetypes ?? (_filetypes = new List<string>());
				}
				set {
					_filetypes = value;
				}
			}
			private List<string> _filetypes;
			#endregion
			public string LocalTempDirectory;
			public bool CompressFiles;
			public string ZipFilename;
			public bool AddDateToFilename;

			#region public static FileBackupConfig Load( string configuration )
			/// <summary>
			/// 
			/// </summary>
			/// <param name="configuration"></param>
			/// <returns></returns>
			public static FileBackupConfig Load( string configuration ) {
				if( string.IsNullOrEmpty( configuration ) ) {
					return new FileBackupConfig();
				}
				MemoryStream ms = null;
				FileBackupConfig ps = null;
				try {
					ms = new MemoryStream( configuration.ToByteArray() );
					ms.Seek( 0, SeekOrigin.Begin );
					ps = (FileBackupConfig)Serializer.Deserialize( ms );

				} catch {
				} finally {
					if( ms != null ) {
						ms.Close();
						ms.Dispose();
					}
				}
				return ps ?? new FileBackupConfig();
			}
			#endregion
			#region public string Save()
			/// <summary>
			/// 
			/// </summary>
			/// <returns></returns>
			public string Save() {
				MemoryStream ms = null;
				try {
					ms = new MemoryStream();
					Serializer.Serialize( ms, this );
					ms.Flush();
					ms.Seek( 0, SeekOrigin.Begin );
					byte[] bytes = ms.GetBuffer();
					StringBuilder sb = new StringBuilder();
					foreach( byte b in bytes ) {
						sb.Append( (char)b );
					}
					return sb.ToString();
				} catch {
				} finally {
					if( ms != null ) {
						ms.Close();
						ms.Dispose();
					}
				}
				return null;
			}
			#endregion
		}
		private class BackupRunner : IDisposable {
			private readonly FileInfo dbFile;
			private readonly FileBackupConfig config;
			private int count;
			private string backupDirPath;
			private bool isDisposed;
			IBackupTarget target;
			#region private Hashtable ExtensionHash
			/// <summary>
			/// Gets the ExtensionHash of the BackupRunner
			/// </summary>
			/// <value></value>
			private Hashtable ExtensionHash {
				get {
					if( _extensionHash == null ) {
						_extensionHash = new Hashtable();
						foreach( string ft in config.Filetypes ) {
							string ext = ft.Replace( "*", "" ).ToLower();
							if( string.IsNullOrEmpty( ext ) ) {
								continue;
							}
							_extensionHash[ ext ] = null;
						}
					}
					return _extensionHash;
				}
			}
			private Hashtable _extensionHash;
			#endregion
			#region private DBCommand CMD
			/// <summary>
			/// Gets the CMD of the BackupRunner
			/// </summary>
			/// <value></value>
			private DBCommand CMD {
				get {
					if( _cMD == null ) {
						if( !File.Exists( dbFile.FullName ) ) {
							SetupDatabase();
						}
						_cMD = Configuration.CreateDBCommand( dbFile );
					}
					return _cMD;
				}
			}
			private DBCommand _cMD;
			#endregion
			#region private ZipFile Zip
			/// <summary>
			/// Gets the Zip of the BackupRunner
			/// </summary>
			/// <value></value>
			private ZipFile Zip {
				get {
					if( _zip == null ) {
						DirectoryInfo dir = new DirectoryInfo( config.LocalTempDirectory );
						string zn = config.ZipFilename;
						if( config.AddDateToFilename ) {
							zn = "{0} {1}".FillBlanks( zn, DateTime.Now.ToString( "yyyy-MM-dd HH.mm.ss" ) );
						}
						zn += ".zip";
						zn = "{0}\\{1}".FillBlanks( dir.FullName, zn );
						if( File.Exists( zn ) ) {
							File.Delete( zn );
						}
						_zip = new ZipFile( zn );
					}
					return _zip;
				}
			}
			private ZipFile _zip;
			#endregion

			#region public BackupRunner( FileBackupConfig config, int jobID, IBackupTarget target )
			/// <summary>
			/// Initializes a new instance of the <b>BackupRunner</b> class.
			/// </summary>
			/// <param name="config"></param>
			/// <param name="jobID"></param>
			/// <param name="target"></param>
			public BackupRunner( FileBackupConfig config, int jobID, IBackupTarget target ) {
				this.config = config;
				dbFile = new FileInfo( "{0}\\FileBackupDatabases\\{1}.s3db".FillBlanks( Configuration.DataDirectory.FullName, jobID ) );
				backupDirPath = new DirectoryInfo( config.Directory ).FullName + "\\";
				this.target = target;
			}
			#endregion
			#region public static void Cleanup( int jobID )
			/// <summary>
			/// 
			/// </summary>
			/// <param name="jobID"></param>
			public static void Cleanup( int jobID ) {
				string fn = "{0}\\FileBackupDatabases\\{1}.s3db".FillBlanks( Configuration.DataDirectory.FullName, jobID );
				if( File.Exists( fn ) ) {
					File.Delete( fn );
				}
			}
			#endregion
			#region private void SetupDatabase()
			/// <summary>
			/// 
			/// </summary>
			private void SetupDatabase() {
				if( !Directory.Exists( dbFile.DirectoryName ) ) {
					Directory.CreateDirectory( dbFile.DirectoryName );
				}
				SQLiteConnection.CreateFile( dbFile.FullName );
				SQLiteConnectionStringBuilder cb = new SQLiteConnectionStringBuilder();
				cb.DataSource = dbFile.FullName;
				cb.FailIfMissing = false;
				using( SQLiteConnection con = new SQLiteConnection( cb.ToString() ) ) {
					using( SQLiteCommand c = con.CreateCommand() ) {
						c.CommandText = @"CREATE TABLE [BackupFiles] (
[Filename] VARCHAR(3000) NOT NULL,
[ModifiedDate] DATE NOT NULL
);";
						con.Open();
						c.ExecuteNonQuery();
						c.Dispose();
						con.Close();
						con.Dispose();
					}
				}
			}
			#endregion
			#region public int Run()
			/// <summary>
			/// 
			/// </summary>
			/// <returns></returns>
			public int Run() {
				Run( new DirectoryInfo( config.Directory ) );
				return count;
			}
			#endregion
			#region private void Run( DirectoryInfo dir )
			/// <summary>
			/// 
			/// </summary>
			/// <param name="dir"></param>
			private void Run( DirectoryInfo dir ) {
				foreach( FileInfo file in dir.GetFiles() ) {
					Add( file );
				}
				foreach( DirectoryInfo sub in dir.GetDirectories() ) {
					Run( sub );
				}
			}
			#endregion
			#region private void Add( FileInfo fi )
			/// <summary>
			/// 
			/// </summary>
			/// <param name="fi"></param>
			private void Add( FileInfo fi ) {
				if( !Include( fi ) ) {
					return;
				}
				count++;
				string dirName = fi.Directory.FullName + "\\";
				string path = dirName.Replace( backupDirPath, "" );
				Add( fi, path );
			}
			#endregion
			#region private void Add( FileInfo fi, string path )
			/// <summary>
			/// 
			/// </summary>
			/// <param name="fi"></param>
			/// <param name="path"></param>
			private void Add( FileInfo fi, string path ) {
				if( config.CompressFiles ) {
					Zip.AddFile( fi.FullName, path );
				} else {
					target.Store( fi, path );
					//if( config.SaveAs == SaveAsTypes.Directory ) {
					//    DirectoryInfo td = new DirectoryInfo( config.SaveToDir );
					//    if( !string.IsNullOrEmpty( path ) ) {
					//        td = new DirectoryInfo( "{0}\\{1}".FillBlanks( td.FullName, path ) );
					//    }
					//    if( !Directory.Exists( td.FullName ) ) {
					//        Directory.CreateDirectory( td.FullName );
					//    }
					//    string tn = "{0}\\{1}".FillBlanks( td.FullName, fi.Name );
					//    if( File.Exists( tn ) ) {
					//        FileInfo tf = new FileInfo( tn );
					//        if( tf.LastWriteTime == fi.LastWriteTime && tf.Length == fi.Length ) {
					//            // file already exist, is not modified, and is as large as the file being backup, so we consider it already copied
					//            return;
					//        }
					//        File.SetAttributes( tn, FileAttributes.Normal );
					//    }
					//    File.Copy( fi.FullName, tn, true );
					//} else {
					//    string rd = config.FTPRemoteDirectory;
					//    if( !rd.EndsWith( "/" ) ) {
					//        rd += "/";
					//    }
					//    rd += path.Replace( "\\", "/" );
					//    rd = rd.Replace( "//", "/" );
					//    FTPUploader.UploadFile( fi.FullName, rd );
					//}
				}
			}
			#endregion
			#region private bool Include( FileInfo file )
			/// <summary>
			/// 
			/// </summary>
			/// <param name="file"></param>
			/// <returns></returns>
			private bool Include( FileInfo file ) {
				if( config.BackupType == BackupTypes.All ) {
					return IncludeFiletype( file );
				}
				if( !IncludeFiletype( file ) ) {
					return false;
				}
				CMD.ClearParameters();
				CMD.CommandText = "SELECT ModifiedDate FROM BackupFiles WHERE Filename = @Filename";
				CMD.AddWithValue( "@Filename", file.FullName );
				CMD.ExecuteReader();
				if( CMD.Read() ) {
					DateTime md = CMD.GetDateTime( 0 );
					if( file.LastWriteTime > md ) {
						CMD.CommandText = "UPDATE BackupFiles SET ModifiedDate = @ModifiedDate WHERE Filename = @Filename";
						CMD.AddWithValue( "@ModifiedDate", file.LastWriteTime );
						CMD.ExecuteNonQuery();
						return true;
					}
					return false;
				}
				CMD.ClearParameters();
				CMD.CommandText = "INSERT INTO BackupFiles( Filename, ModifiedDate ) VALUES( @Filename, @ModifiedDate )";
				CMD.AddWithValue( "@Filename", file.FullName );
				CMD.AddWithValue( "@ModifiedDate", file.LastWriteTime );
				CMD.ExecuteNonQuery();
				return true;
			}
			#endregion

			#region private bool IncludeFiletype( FileInfo file )
			/// <summary>
			/// 
			/// </summary>
			/// <param name="file"></param>
			/// <returns></returns>
			private bool IncludeFiletype( FileInfo file ) {
				if( ExtensionHash.Count == 0 ) {
					return true;
				}
				string ext = file.Extension;
				if( string.IsNullOrEmpty( ext ) ) {
					return false;
				}
				return ExtensionHash.ContainsKey( ext.ToLower() );
			}
			#endregion

			#region public void Dispose()
			/// <summary>
			/// Releases the resources used by the <b>BackupRunner</b>.
			/// </summary>
			public void Dispose() {
				if( isDisposed ) {
					return;
				}
				isDisposed = true;
				if( _cMD != null ) {
					_cMD.Dispose();
				}
				if( _zip != null ) {
					_zip.Save();
					target.Store( new FileInfo( Zip.Name ), ""  );
					_zip.Dispose();
					try {
						File.Delete( _zip.Name );
					} catch {}
				}
			}
			#endregion
		}
	}
}
