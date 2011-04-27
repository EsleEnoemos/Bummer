using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using Bummer.Common;
using Bummer.Schedules.Controls;

namespace Bummer.Schedules {
	public class MSSQLDatabaseBackup : IBackupSchedule {
		private MSSQLDatabaseBackupConfigGUI gui;
		public string Name {
			get {
				return "Database backup";
			}
		}

		public string Description {
			get {
				return "Backup a Microsoft SQL Server Database";
			}
		}

		public string SaveConfiguration() {
			if( gui == null ) {
				throw new Exception( "GUI not initialized" );
			}
			return gui.Save().Save();
		}

		public string Execute( string config ) {
			MSSQLDatabaseBackupConfig conf = MSSQLDatabaseBackupConfig.Load( config );
			using( SQLLocalBackup lb = new SQLLocalBackup( conf.Server, conf.Username, conf.Password, conf.Database ) ) {
				if( !lb.DoLocalBackup( conf.RemoteTempDir, @"C:\Temp" ) ) {
					return @"{0} was backed up.
Temporary files on the remote server was not deleted.
Enable procedure xp_cmdshell to perform this".FillBlanks( conf.Database );
				}
				return "{0} was backed up".FillBlanks( conf.Database );
			}
		}

		public void InitiateConfiguration( Control container, string config ) {
			gui = new MSSQLDatabaseBackupConfigGUI( MSSQLDatabaseBackupConfig.Load( config ));
			//gui.Dock = DockStyle.Fill;
			//gui.MinimumSize = new Size(500,500);
			container.Controls.Add( gui );
		}
		public enum SaveAsTypes {
			Directory = 1,
			FTP = 2
		}
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
			public string Database;
			public SaveAsTypes SaveAs;
			public string SaveToDir;
			public string RemoteTempDir;
			public string FTPServer;
			public string FTPUsername;
			public string FTPPassword;
			public string FTPRemoteDirectory;

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
	}
}
