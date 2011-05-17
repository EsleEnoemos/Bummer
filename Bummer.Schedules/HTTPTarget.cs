using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using Bummer.Common;
using Bummer.Schedules.Controls;

namespace Bummer.Schedules {
	public class HTTPTarget : IBackupTarget {
		private WWWConfig config;
		private WWWConfigSelector gui;

		public string Name {
			get {
				return "HTTP Upload";
			}
		}

		public string Description {
			get {
				return @"Upload files to a web (HTTP/HTTPS) server.
Supports HTTPS with self-signed certificates";
			}
		}

		public void InitiateConfiguration( Control container, string configuration ) {
			config = WWWConfig.Load( configuration );
			gui = new WWWConfigSelector( config );
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
			return new HTTPTarget {
				config = WWWConfig.Load( configuration )
			};
		}

		public void Store( FileInfo file, string relativePath ) {
			throw new NotImplementedException();
		}

		public class WWWConfig {
			#region private static XmlSerializer Serializer
			/// <summary>
			/// Gets the Serializer of the WWWConfig
			/// </summary>
			/// <value></value>
			private static XmlSerializer Serializer {
				get {
					return _serializer ?? (_serializer = new XmlSerializer( typeof( WWWConfig ) ));
				}
			}
			private static XmlSerializer _serializer;
			#endregion
			public string URL;
			public string Username;
			public string Password;

			#region public static WWWConfig Load( string configuration )
			/// <summary>
			/// 
			/// </summary>
			/// <param name="configuration"></param>
			/// <returns></returns>
			public static WWWConfig Load( string configuration ) {
				if( string.IsNullOrEmpty( configuration ) ) {
					return new WWWConfig();
				}
				MemoryStream ms = null;
				WWWConfig ps = null;
				try {
					ms = new MemoryStream( configuration.ToByteArray() );
					ms.Seek( 0, SeekOrigin.Begin );
					ps = (WWWConfig)Serializer.Deserialize( ms );

				} catch {
				} finally {
					if( ms != null ) {
						ms.Close();
						ms.Dispose();
					}
				}
				return ps ?? new WWWConfig();
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
