using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using Bummer.Common;
using Bummer.Schedules.Controls;
using Ionic.Zip;

namespace Bummer.Schedules {
	public class MSSQLDatabaseBackup : IBackupSchedule {
		private MSSQLDatabaseBackupConfigGUI gui;
		#region public string Name
		/// <summary>
		/// Gets the Name of the MSSQLDatabaseBackup
		/// </summary>
		/// <value></value>
		public string Name {
			get {
				return "Database backup";
			}
		}
		#endregion
		#region public string Description
		/// <summary>
		/// Gets the Description of the MSSQLDatabaseBackup
		/// </summary>
		/// <value></value>
		public string Description {
			get {
				return _decription ?? (_decription=@"Backup one or mote Microsoft SQL Server Databases.
The databases can be located on the same machine or a remote server, as long as it can be reached current computer.");
			}
		}
		private string _decription;
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
			MSSQLDatabaseBackupConfig conf = MSSQLDatabaseBackupConfig.Load( config );
			List<string> databases = conf.Databases;
			if( databases == null || databases.Count == 0 ) {
				databases = new List<string>();
				List<string> tmp = MSSQLDatabaseBackupConfigGUI.GetDatabases( conf.Server, conf.Username, conf.Password );
				foreach( string s in tmp ) {
					if( !s.EqualsAny( StringComparison.OrdinalIgnoreCase, "master", "model", "msdb", "tempdb" ) ) {
						databases.Add( s );
					}
				}
			}
			bool remoteCleanupOK = true;
			string outputDir = conf.LocalTempDirectory;
			string remoteDir = conf.RemoteTempDir;
			if( conf.IsLocalServer ) {
				remoteDir = outputDir;
				outputDir = null;
			}
			foreach( string db in databases ) {
				BackupResult res;
				using( SQLLocalBackup lb = new SQLLocalBackup( conf.Server, conf.Username, conf.Password, db ) ) {
					res = lb.DoLocalBackup( remoteDir, outputDir, conf.AddDateToFilename );
					if( !res.CleanupOK ) {
						remoteCleanupOK = false;
					}
				}
				if( conf.CompressFiles ) {
					res.OutputFilename = ZipFile( res.OutputFilename );
				}
				target.Store( new FileInfo( res.OutputFilename ), "" );
				//if( conf.SaveAs == SaveAsTypes.FTP ) {
				//    FTPFile( res.OutputFilename, conf );
				//    try {
				//        File.Delete( res.OutputFilename );
				//    } catch {
				//    }
				//}
			}
			if( !remoteCleanupOK ) {
				return @"{0} was backed up.
Temporary files on the remote server was not deleted.
Enable procedure xp_cmdshell to perform this".FillBlanks( databases.ToString( ", " ) );
			}
			return "{0} was backuped.".FillBlanks( databases.ToString( ", " ) );
		}
		#endregion
		#region private string ZipFile( string filename )
		/// <summary>
		/// 
		/// </summary>
		/// <param name="filename"></param>
		/// <returns></returns>
		private string ZipFile( string filename ) {
			if( string.IsNullOrEmpty( filename ) || !File.Exists( filename ) ) {
				return filename;
			}
			string fn = "{0}.zip".FillBlanks( filename );
			if( File.Exists( fn ) ) {
				File.Delete( fn );
			}
			ZipFile zip = new ZipFile( fn );
			zip.UseZip64WhenSaving = Zip64Option.AsNecessary;
			zip.AddFile( filename, "" );
			zip.Save();
			try {
				File.Delete( filename );
			} catch {
			}
			return fn;
		}
		#endregion
		#region public void InitiateConfiguration( Control container, string config )
		/// <summary>
		/// 
		/// </summary>
		/// <param name="container"></param>
		/// <param name="config"></param>
		public void InitiateConfiguration( Control container, string config ) {
			gui = new MSSQLDatabaseBackupConfigGUI( MSSQLDatabaseBackupConfig.Load( config ) );
			//gui.Dock = DockStyle.Fill;
			//gui.MinimumSize = new Size(500,500);
			container.Controls.Add( gui );
		}
		#endregion
		#region public void Delete( string config, int jobID )
		/// <summary>
		/// 
		/// </summary>
		/// <param name="config"></param>
		/// <param name="jobID"></param>
		public void Delete( string config, int jobID ) {
		}
		#endregion

		public class MSSQLDatabaseBackupConfig {
			#region private static XmlSerializer Serializer
			/// <summary>
			/// Gets the Serializer of the MSSQLDatabaseBackupConfig
			/// </summary>
			/// <value></value>
			private static XmlSerializer Serializer {
				get {
					return _serializer ?? (_serializer = new XmlSerializer( typeof( MSSQLDatabaseBackupConfig ) ));
				}
			}
			private static XmlSerializer _serializer;
			#endregion
			public string Server;
			public string Username;
			public string Password;
			#region public List<string> Databases
			/// <summary>
			/// Get/Sets the Databases of the MSSQLDatabaseBackupConfig
			/// </summary>
			/// <value></value>
			public List<string> Databases {
				get {
					return _databases ?? (_databases = new List<string>());
				}
				set {
					_databases = value;
				}
			}
			#endregion
			private List<string> _databases;
			public string LocalTempDirectory;
			public string RemoteTempDir;
			public bool CompressFiles;
			public bool AddDateToFilename;
			public bool IsLocalServer;

			#region public static ParameterSettings Load( string configuration )
			/// <summary>
			/// 
			/// </summary>
			/// <param name="configuration"></param>
			/// <returns></returns>
			public static MSSQLDatabaseBackupConfig Load( string configuration ) {
				if( string.IsNullOrEmpty( configuration ) ) {
					return new MSSQLDatabaseBackupConfig();
				}
				MemoryStream ms = null;
				MSSQLDatabaseBackupConfig ps = null;
				try {
					ms = new MemoryStream( configuration.ToByteArray() );
					ms.Seek( 0, SeekOrigin.Begin );
					ps = (MSSQLDatabaseBackupConfig)Serializer.Deserialize( ms );

				} catch {
				} finally {
					if( ms != null ) {
						ms.Close();
						ms.Dispose();
					}
				}
				return ps ?? new MSSQLDatabaseBackupConfig();
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
		public struct BackupResult {
			public bool CleanupOK;
			public string OutputFilename;
		}
	}
}
