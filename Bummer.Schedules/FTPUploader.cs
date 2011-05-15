using System;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using Bummer.Common;
using Bummer.Schedules.Controls;

namespace Bummer.Schedules {
	public class FTPUploader : IBackupTarget {
		private bool? passive;
		private FTPConfig config;
		private FTPConfigSelector gui;

		public string Name {
			get {
				return "FTP Upload";
			}
		}

		public string Description {
			get {
				return "Upload files to an FTP-server";
			}
		}

		public void InitiateConfiguration( Control container, string configuration ) {
			config = FTPConfig.Load( configuration );
			gui = new FTPConfigSelector( config );
			gui.Dock = DockStyle.Fill;
			container.Controls.Add( gui );
		}

		public string SaveConfiguration() {
			if( gui == null ) {
				throw new Exception( "GUI not initialized" );
			}
			return gui.Save().Save();
		}

		public IBackupTarget Prepare( string configuration ) {
			return new FTPUploader{config = FTPConfig.Load( configuration )};
		}

		#region public void Store( FileInfo file, string relativePath )
		/// <summary>
		/// 
		/// </summary>
		/// <param name="file"></param>
		/// <param name="relativePath"></param>
		public void Store( FileInfo file, string relativePath ) {
			if( !string.IsNullOrEmpty( relativePath ) && relativePath.Contains( "\\" ) ) {
				relativePath = relativePath.Replace( "\\", "/" );
			}
			string url = config.Server;
			if( !url.Contains( "://" ) ) {
				url = "ftp://{0}".FillBlanks( url );
			}
			url = "{0}:{1}".FillBlanks( url, config.Port );

			if( !string.IsNullOrEmpty( relativePath ) ) {
				string rd = relativePath;
				if( !rd.StartsWith( "/" ) ) {
					rd = "/{0}".FillBlanks( rd );
				}
				url = "{0}{1}".FillBlanks( url, rd );
			}
			if( !url.EndsWith( "/" ) ) {
				url = "{0}/".FillBlanks( url );
			}
			url = "{0}{1}".FillBlanks( url, file.Name );

			FtpWebRequest req = (FtpWebRequest)FtpWebRequest.Create( url );
			req.Credentials = new NetworkCredential( config.Username, config.Password );
			req.KeepAlive = false;
			req.Method = WebRequestMethods.Ftp.UploadFile;
			req.UseBinary = true;
			req.ContentLength = file.Length;
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
					req.Credentials = new NetworkCredential( config.Username, config.Password );
					req.KeepAlive = false;
					req.Method = WebRequestMethods.Ftp.UploadFile;
					req.UseBinary = true;
					req.ContentLength = file.Length;
					req.UsePassive = !req.UsePassive;
					outStream = req.GetRequestStream();
					passive = req.UsePassive;
				}
			}
			if( outStream == null ) {
				throw new Exception( "Unable to upload file to FTP-server" );
			}
			FileStream fs = file.OpenRead();
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

		public class FTPConfig {
			#region private static XmlSerializer Serializer
			/// <summary>
			/// Gets the Serializer of the FTPConfig
			/// </summary>
			/// <value></value>
			private static XmlSerializer Serializer {
				get {
					return _serializer ?? (_serializer = new XmlSerializer( typeof( FTPConfig ) ));
				}
			}
			private static XmlSerializer _serializer;
			#endregion
			#region public string Server
			/// <summary>
			/// Get/Sets the Server of the MSSQLDatabaseBackupConfig
			/// </summary>
			/// <value></value>
			public string Server {
				get {
					return _Server;
				}
				set {
					_Server = value;
				}
			}
			private string _Server;
			#endregion
			#region public string Username
			/// <summary>
			/// Get/Sets the Username of the MSSQLDatabaseBackupConfig
			/// </summary>
			/// <value></value>
			public string Username {
				get {
					return _Username;
				}
				set {
					_Username = value;
				}
			}
			private string _Username;
			#endregion
			#region public string Password
			/// <summary>
			/// Get/Sets the Password of the MSSQLDatabaseBackupConfig
			/// </summary>
			/// <value></value>
			public string Password {
				get {
					return _Password;
				}
				set {
					_Password = value;
				}
			}
			private string _Password;
			#endregion
			#region public string RemoteDirectory
			/// <summary>
			/// Get/Sets the RemoteDirectory of the MSSQLDatabaseBackupConfig
			/// </summary>
			/// <value></value>
			public string RemoteDirectory {
				get {
					return _RemoteDirectory;
				}
				set {
					_RemoteDirectory = value;
				}
			}
			private string _RemoteDirectory;
			#endregion
			#region public int Port
			/// <summary>
			/// Get/Sets the Port of the MSSQLDatabaseBackupConfig
			/// </summary>
			/// <value></value>
			public int Port {
				get {
					return _Port;
				}
				set {
					_Port = value;
				}
			}
			private int _Port;
			#endregion

			#region public static FTPConfig Load( string configuration )
			/// <summary>
			/// 
			/// </summary>
			/// <param name="configuration"></param>
			/// <returns></returns>
			public static FTPConfig Load( string configuration ) {
				if( string.IsNullOrEmpty( configuration ) ) {
					return new FTPConfig();
				}
				MemoryStream ms = null;
				FTPConfig ps = null;
				try {
					ms = new MemoryStream( configuration.ToByteArray() );
					ms.Seek( 0, SeekOrigin.Begin );
					ps = (FTPConfig)Serializer.Deserialize( ms );

				} catch {
				} finally {
					if( ms != null ) {
						ms.Close();
						ms.Dispose();
					}
				}
				return ps ?? new FTPConfig();
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
	}
}