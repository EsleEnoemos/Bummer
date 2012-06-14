using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Reflection;
using System.Xml;
using Bummer.Common;

namespace Bummer.UpdateChecker {
	public static class UpdaterChecker {
		#region public static List<Update> GetAvailableUpdateInformations()
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public static List<Update> GetAvailableUpdateInformations() {
			List<Update> list = new List<Update>();
			List<Inf> infos = GetUpdateInfos();

			foreach( Inf updateInfo in infos ) {
				try {
					HttpWebRequest req = HttpWebRequest.Create( updateInfo.URL ) as HttpWebRequest;
					if( req == null ) {
						continue;
					}
					WebResponse res = req.GetResponse();
					XmlDocument doc = new XmlDocument();
					Stream str = res.GetResponseStream();
					if( str == null ) {
						res.Close();
						continue;
					}
					doc.Load( str );
					res.Close();
					XmlNode node = doc.FirstChild;
					XmlNode vn = node.SelectSingleNode( "Version" );
					if( vn == null ) {
						continue;
					}
					Version v;
					if( !Version.TryParse( vn.InnerText, out v ) ) {
						continue;
					}
					if( v <= updateInfo.Version ) {
						continue;
					}
					XmlNode dn = node.SelectSingleNode( "DownloadURL" );
					if( dn == null || string.IsNullOrEmpty( dn.InnerText ) ) {
						continue;
					}
					XmlNode vd = node.SelectSingleNode( "VersionDescription" );
					if( vd == null || string.IsNullOrEmpty( vd.InnerText ) ) {
						continue;
					}
					list.Add( new Update {
						CurrentVersion = updateInfo.Version, NewVersion = v, DownloadURL = dn.InnerText, Description = vd.InnerText, ModuleName = updateInfo.Name
					} );
				} catch( WebException wex ) {
					if( wex.Response != null ) {
						wex.Response.Close();
					}
				}
			}

			return list;
		}
		#endregion

		#region private static List<Inf> GetUpdateInfos()
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		private static List<Inf> GetUpdateInfos() {
			Assembly myAss = Assembly.GetAssembly( typeof( UpdaterChecker ) );
			FileInfo fi = new FileInfo( myAss.Location );
			List<Inf> list = new List<Inf>( GetUpdateInfos( fi.Directory ) );
			string pluginDir = "{0}\\Plugins".FillBlanks( Configuration.DataDirectory.FullName );
			list.AddRange( GetUpdateInfos( new DirectoryInfo( pluginDir ) ) );
			return list;
		}
		#endregion
		#region private static List<Inf> GetUpdateInfos( DirectoryInfo baseDir )
		/// <summary>
		/// 
		/// </summary>
		/// <param name="baseDir"></param>
		/// <returns></returns>
		private static List<Inf> GetUpdateInfos( DirectoryInfo baseDir ) {
			List<Inf> list = new List<Inf>();
			FileInfo[] files = baseDir.GetFiles();
			foreach( FileInfo file in files ) {
				if( !string.Equals( ".dll", file.Extension, StringComparison.OrdinalIgnoreCase ) && !string.Equals( ".exe", file.Extension, StringComparison.OrdinalIgnoreCase ) ) {
					continue;
				}
				try {
					Assembly ass = Assembly.LoadFrom( file.FullName );
					Type[] types = ass.GetTypes();
					foreach( Type type in types ) {
						try {
							if( !type.IsAbstract ) {
								if( typeof( IUpdateInfo ).IsAssignableFrom( type ) ) {
									IUpdateInfo ui = ass.CreateInstance( type.FullName ) as IUpdateInfo;
									if( ui != null && !string.IsNullOrEmpty( ui.UpdateInfoURL ) ) {
										list.Add( new Inf( ui.GetType().Assembly.GetName().Name, ui.UpdateInfoURL, ass.GetName().Version ) );
									}
								}
							}
						} catch( Exception ) {
						}
					}
				} catch( ReflectionTypeLoadException rte ) {
					foreach( Type type in rte.Types ) {
						try {
							if( !type.IsAbstract ) {
								if( typeof( IUpdateInfo ).IsAssignableFrom( type ) ) {
									IUpdateInfo ui = type.Assembly.CreateInstance( type.FullName ) as IUpdateInfo;
									if( ui != null && !string.IsNullOrEmpty( ui.UpdateInfoURL ) ) {
										list.Add( new Inf( ui.GetType().Assembly.GetName().Name, ui.UpdateInfoURL, type.Assembly.GetName().Version ) );
									}
								}
							}
						} catch( Exception ) {
						}
					}
				} catch( Exception ) {
				}
			}
			return list;
		}
		#endregion

		private class Inf {
			public string Name;
			public string URL;
			public Version Version;
			public Inf( string name, string url, Version version ) {
				Name = name;
				URL = url;
				Version = version;
			}
		}
	}
	public class Update {
		public string ModuleName;
		public string DownloadURL;
		public string Description;
		public Version CurrentVersion;
		public Version NewVersion;
	}
}