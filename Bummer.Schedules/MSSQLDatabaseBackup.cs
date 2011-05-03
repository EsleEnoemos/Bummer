using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using Bummer.Common;
using Bummer.Schedules.Controls;
using Ionic.Zip;

namespace Bummer.Schedules {
	public class MSSQLDatabaseBackup : IBackupSchedule {
		private bool? passive;
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
				return _decription ?? (_decription="Backup a Microsoft SQL Server Database{0}The database can be located on a remote server, as long as it is reachable from the current computer.{0}Backups can be stored in a specified directory, or be uploaded to an FTP-server.".FillBlanks( Environment.NewLine ));
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

		#region public string Execute( string config, int jobID )
		/// <summary>
		/// 
		/// </summary>
		/// <param name="config"></param>
		/// <param name="jobID"></param>
		/// <returns></returns>
		public string Execute( string config, int jobID ) {
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
			string outputDir = conf.SaveAs == SaveAsTypes.Directory ? conf.SaveToDir : conf.FTPLocalTempDirectory;
			foreach( string db in databases ) {
				BackupResult res;
				using( SQLLocalBackup lb = new SQLLocalBackup( conf.Server, conf.Username, conf.Password, db ) ) {
					res = lb.DoLocalBackup( conf.RemoteTempDir, outputDir, conf.AddDateToFilename );
					if( !res.CleanupOK ) {
						remoteCleanupOK = false;
					}
				}
				if( conf.CompressFiles ) {
					res.OutputFilename = ZipFile( res.OutputFilename );
				}
				if( conf.SaveAs == SaveAsTypes.FTP ) {
					FTPFile( res.OutputFilename, conf );
					try {
						File.Delete( res.OutputFilename );
					} catch {
					}
				}
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
		#region private void FTPFile( string filename, MSSQLDatabaseBackupConfig conf )
		/// <summary>
		/// 
		/// </summary>
		/// <param name="filename"></param>
		/// <param name="conf"></param>
		private void FTPFile( string filename, MSSQLDatabaseBackupConfig conf ) {
			string url = conf.FTPServer;
			if( !url.Contains( "://" ) ) {
				url = "ftp://{0}".FillBlanks( url );
			}
			url = "{0}:{1}".FillBlanks( url, conf.FTPPort );

			if( !string.IsNullOrEmpty( conf.FTPRemoteDirectory ) ) {
				string rd = conf.FTPRemoteDirectory;
				if( !rd.StartsWith( "/" ) ) {
					rd = "/{0}".FillBlanks( rd );
				}
				url = "{0}{1}".FillBlanks( url, rd );
			}
			if( !url.EndsWith( "/" ) ) {
				url = "{0}/".FillBlanks( url );
			}
			FileInfo fi = new FileInfo( filename );
			url = "{0}{1}".FillBlanks( url, fi.Name );

			FtpWebRequest req = (FtpWebRequest)FtpWebRequest.Create( url );
			req.Credentials = new NetworkCredential( conf.FTPUsername, conf.FTPPassword );
			req.KeepAlive = false;
			req.Method = WebRequestMethods.Ftp.UploadFile;
			req.UseBinary = true;
			req.ContentLength = fi.Length;
			if( passive.HasValue ) {
				req.UsePassive = passive.Value;
			}
			const int buffSize = 1024 * 1024;
			byte[] bytes = new byte[ buffSize ];
			Stream outStream = null;
			try {
				outStream = req.GetRequestStream();
				passive = req.UsePassive;
			} catch( Exception ex ) {
				string ml = ex.Message.ToLower();
				if( ml.Contains( "time" ) && ml.Contains( "out" ) ) {
					req = (FtpWebRequest)FtpWebRequest.Create( req.RequestUri );
					req.Credentials = new NetworkCredential( conf.FTPUsername, conf.FTPPassword );
					req.KeepAlive = false;
					req.Method = WebRequestMethods.Ftp.UploadFile;
					req.UseBinary = true;
					req.ContentLength = fi.Length;
					req.UsePassive = !req.UsePassive;
					outStream = req.GetRequestStream();
					passive = req.UsePassive;
				}
			}
			if( outStream == null ) {
				throw new Exception( "Unable to upload file to FTP-server" );
			}
			FileStream fs = fi.OpenRead();
			int read;
			while( (read = fs.Read( bytes, 0, buffSize )) > 0 ) {
				outStream.Write( bytes, 0, read );
			}
			outStream.Flush();
			outStream.Close();
			outStream.Dispose();
			fs.Close();
			fs.Dispose();
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

		public class MSSQLDatabaseBackupConfig : IFTPConfig {
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
			public SaveAsTypes SaveAs;
			public string SaveToDir;
			public string RemoteTempDir;
			#region public string FTPServer
			/// <summary>
			/// Get/Sets the FTPServer of the MSSQLDatabaseBackupConfig
			/// </summary>
			/// <value></value>
			public string FTPServer {
				get {
					return _fTPServer;
				}
				set {
					_fTPServer = value;
				}
			}
			private string _fTPServer;
			#endregion
			#region public string FTPUsername
			/// <summary>
			/// Get/Sets the FTPUsername of the MSSQLDatabaseBackupConfig
			/// </summary>
			/// <value></value>
			public string FTPUsername {
				get {
					return _fTPUsername;
				}
				set {
					_fTPUsername = value;
				}
			}
			private string _fTPUsername;
			#endregion
			#region public string FTPPassword
			/// <summary>
			/// Get/Sets the FTPPassword of the MSSQLDatabaseBackupConfig
			/// </summary>
			/// <value></value>
			public string FTPPassword {
				get {
					return _fTPPassword;
				}
				set {
					_fTPPassword = value;
				}
			}
			private string _fTPPassword;
			#endregion
			#region public string FTPRemoteDirectory
			/// <summary>
			/// Get/Sets the FTPRemoteDirectory of the MSSQLDatabaseBackupConfig
			/// </summary>
			/// <value></value>
			public string FTPRemoteDirectory {
				get {
					return _fTPRemoteDirectory;
				}
				set {
					_fTPRemoteDirectory = value;
				}
			}
			private string _fTPRemoteDirectory;
			#endregion
			#region public string FTPLocalTempDirectory
			/// <summary>
			/// Get/Sets the FTPLocalTempDirectory of the MSSQLDatabaseBackupConfig
			/// </summary>
			/// <value></value>
			public string FTPLocalTempDirectory {
				get {
					return _fTPLocalTempDirectory;
				}
				set {
					_fTPLocalTempDirectory = value;
				}
			}
			private string _fTPLocalTempDirectory;
			#endregion
			#region public int FTPPort
			/// <summary>
			/// Get/Sets the FTPPort of the MSSQLDatabaseBackupConfig
			/// </summary>
			/// <value></value>
			public int FTPPort {
				get {
					return _fTPPort;
				}
				set {
					_fTPPort = value;
				}
			}
			private int _fTPPort;
			#endregion
			public bool CompressFiles;
			public bool AddDateToFilename;

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
