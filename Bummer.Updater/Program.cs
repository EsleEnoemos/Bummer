using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Net;
using System.Reflection;
using System.ServiceProcess;
using System.Windows.Forms;
using System.Xml;
using Ionic.Zip;

namespace Bummer.Updater {
	class Program {
		//private static string[] processNames = new[]{ "Bummer.SysTray", "Bummer.Client" };

		#region private static DirectoryInfo DataDirectory
		/// <summary>
		/// The root directory for all data saved to disk by any part of Bummer
		/// </summary>
		/// <value></value>
		private static DirectoryInfo DataDirectory {
			get {
				if( _dataDirectory == null ) {
					//string fp = Environment.GetFolderPath( Environment.SpecialFolder.ApplicationData );
					DirectoryInfo d = new DirectoryInfo( Environment.GetFolderPath( Environment.SpecialFolder.CommonApplicationData ) );
					_dataDirectory = new DirectoryInfo( string.Format( "{0}\\SomeoneElse\\Bummer", d.FullName ) );
					if( !Directory.Exists( _dataDirectory.FullName ) ) {
						Directory.CreateDirectory( _dataDirectory.FullName );
						_dataDirectory.Refresh();
					}
				}
				return _dataDirectory;
			}
		}
		private static DirectoryInfo _dataDirectory;
		#endregion
		#region private static DirectoryInfo TempDir
		/// <summary>
		/// Gets the TempDir of the Program
		/// </summary>
		/// <value></value>
		private static DirectoryInfo TempDir {
			get {
				if( _tempDir == null ) {
					string tmp = string.Format( "{0}\\DownloadTemp", DataDirectory.FullName );
					if( !Directory.Exists( tmp ) ) {
						Directory.CreateDirectory( tmp );
					}
					_tempDir = new DirectoryInfo( tmp );
				}
				return _tempDir;
			}
		}
		private static DirectoryInfo _tempDir;
		#endregion
		#region private static DirectoryInfo ProgramDir
		/// <summary>
		/// Gets the ProgramDir of the Program
		/// </summary>
		/// <value></value>
		private static DirectoryInfo ProgramDir {
			get {
				if( _programDir == null ) {
					Assembly myAss = Assembly.GetAssembly( typeof( Program ) );
					FileInfo fi = new FileInfo( myAss.Location );
					_programDir = fi.Directory;
				}
				return _programDir;
			}
		}
		private static DirectoryInfo _programDir;
		#endregion

		//private static void ExTest() {
		//    ZipFile zip = new ZipFile( @"D:\Temp\New folder\client.zip" );
		//    zip.ExtractExistingFile = ExtractExistingFileAction.OverwriteSilently;
		//    zip.FlattenFoldersOnExtract = false;
		//    string path = @"D:\Temp\New folder\apa";
		//    Directory.CreateDirectory( path );
		//    zip.ExtractAll( path, ExtractExistingFileAction.OverwriteSilently );
		//    ContinueAfterKey( "About to delete folder..." );
		//    Directory.Delete( path, true );
			
		//}
		#region static void Main()
		/// <summary>
		/// 
		/// </summary>
		static void Main() {
			//ExTest();
			//return;
			//bool hold = true;
			//Console.WriteLine( "Sleeping... attach to continue" );
			//while( hold ) {
			//    Thread.Sleep( 100 );
			//}
			Process[] updaterProcesses = Process.GetProcessesByName( "Bummer.Updater" );
			if( updaterProcesses.Length > 1 ) {
				Print( "Updater already running" );
				return;
			}
			List<Update> updates = GetAvailableUpdateInformations();
			if( updates.Count == 0 ) {
				Console.WriteLine( "No updates found..." );
				return;
			}
			bool sysTrayWasRunning = StopProcess( "Bummer.SysTray" );
			StopProcess( "Bummer.Client" );
			bool serviceWasRunning = false;
			try {
				ServiceController service = new ServiceController( "BummerService" );
				if( service.Status == ServiceControllerStatus.Running ) {
					Print( "Stopping service" );
					service.Stop();
					serviceWasRunning = true;
				} else {
					Print( "Not stopping service" );
				}
			} catch( Exception ex ) {
				Print( "Error stopping service: " + ex.Message );
			}
			List<string> downloadedFiles = DownloadUpdates( updates );
			string path = string.Format( "{0}\\UnPack", TempDir.FullName );
			foreach( string filename in downloadedFiles ) {
				if( Directory.Exists( path ) ) {
					Directory.Delete( path, true );
				}
				Directory.CreateDirectory( path );
				Print( "Opening zip " + filename );
				ZipFile zip = new ZipFile( string.Format( "{0}\\{1}", TempDir.FullName, filename ) );
				Print( "Extracting zip to " + path );
				zip.ExtractExistingFile = ExtractExistingFileAction.OverwriteSilently;
				zip.FlattenFoldersOnExtract = false;
				zip.ExtractAll( path, ExtractExistingFileAction.OverwriteSilently );
				if( Directory.Exists( string.Format( "{0}\\Plugin", path ) ) ) {
					DirectoryInfo source = new DirectoryInfo( string.Format( "{0}\\Plugin", path ) );
					source.CopyContent( DataDirectory );
				}
				if( Directory.Exists( string.Format( "{0}\\Program", path ) ) ) {
					DirectoryInfo source = new DirectoryInfo( string.Format( "{0}\\Program", path ) );
					source.CopyContent( ProgramDir );
				}
			}
			if( serviceWasRunning ) {
				try {
					ServiceController service = new ServiceController( "BummerService" );
					service.Start();
				} catch {
				}
			}
			ContinueAfterKey( "Deleting temp dir" );
			try {
				Directory.Delete( TempDir.FullName, true );
			} catch {}
			if( sysTrayWasRunning ) {
				MessageBox.Show( @"Update is complete.
Please re-start the system tray application manually." );
			} else {
				MessageBox.Show( @"Update is complete." );
			}
			Console.ReadKey();
		}
		#endregion
		private static void ContinueAfterKey( string message ) {
			Console.WriteLine(message);
			Console.WriteLine("Strike a key to continue");
			Console.ReadKey();
		}
		#region private static List<string> DownloadUpdates( List<Update> updates )
		/// <summary>
		/// 
		/// </summary>
		/// <param name="updates"></param>
		/// <returns></returns>
		private static List<string> DownloadUpdates( List<Update> updates ) {
			List<string> list = new List<string>();
			foreach( Update update in updates ) {
				string fn = DownloadFile( update.DownloadURL );
				if( fn != null ) {
					list.Add( fn );
				}
			}
			return list;
		}
		#endregion
		#region private static string DownloadFile( string url )
		/// <summary>
		/// 
		/// </summary>
		/// <param name="url"></param>
		/// <returns></returns>
		private static string DownloadFile( string url ) {
			HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create( url );
			string fn = url.Substring( url.LastIndexOf( "/" ) + 1 );
			const int buffSize = 1024 * 1000;
			byte[] bytes = new byte[ buffSize ];
			Stream s = null;
			try {
				WebResponse res = req.GetResponse();
				Stream rs = res.GetResponseStream();
				if( rs != null ) {
					int read;
					s = File.OpenWrite( string.Format( "{0}\\{1}", TempDir.FullName, fn ) );
					while( (read = rs.Read( bytes, 0, buffSize )) > 0 ) {
						s.Write( bytes, 0, read );
					}
				}
				res.Close();
			} catch( WebException wex ) {
				if( wex.Response != null ) {
					wex.Response.Close();
				}
				return null;
			} catch( Exception ) {
				return null;
			} finally {
				if( s != null ) {
					s.Flush();
					s.Close();
					s.Dispose();
				}
			}
			return fn;
		}
		#endregion
		#region private static bool StopProcess(string processName )
		/// <summary>
		/// 
		/// </summary>
		/// <param name="processName"></param>
		/// <returns></returns>
		private static bool StopProcess( string processName ) {
			Print( "Start StopProcess" );
			Process[] p = Process.GetProcessesByName( processName );
			if( p.Length == 0 ) {
				Print( "StopProcess nothing to stop" );
				return false;
			}
			foreach( Process process in p ) {
				Print( "StopProcess killing " + processName );
				process.Kill();
			}
			return true;
		}
		#endregion

		private static void Print( string that ) {
			Console.WriteLine(that);
		}
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
			Assembly myAss = Assembly.GetAssembly( typeof( Update ) );
			FileInfo fi = new FileInfo( myAss.Location );
			List<Inf> list = new List<Inf>( GetUpdateInfos( fi.Directory ) );
			string pluginDir = string.Format( "{0}\\Plugins", DataDirectory.FullName );
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
								if( IsIUpdateInfo( type ) ) {
									string du = GetDownloadURL( type );
									if( !string.IsNullOrEmpty( du ) ) {
										list.Add( new Inf( type.Assembly.GetName().Name, du, ass.GetName().Version ) );
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
								if( IsIUpdateInfo( type ) ) {
									string du = GetDownloadURL( type );
									if( !string.IsNullOrEmpty( du ) ) {
										list.Add( new Inf( type.Assembly.GetName().Name, du, type.Assembly.GetName().Version ) );
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
		#region private static bool IsIUpdateInfo( Type t )
		/// <summary>
		/// 
		/// </summary>
		/// <param name="t"></param>
		/// <returns>True if i update is info, otherwise false.</returns>
		private static bool IsIUpdateInfo( Type t ) {
			Type[] interfaces = t.GetInterfaces();
			foreach( Type i in interfaces ) {
				if( "IUpdateInfo".Equals( i.Name ) ) {
					return true;
				}
			}
			return false;
		}
		#endregion
		#region private static string GetDownloadURL( Type t )
		/// <summary>
		/// 
		/// </summary>
		/// <param name="t"></param>
		/// <returns></returns>
		private static string GetDownloadURL( Type t ) {
			object inst = t.Assembly.CreateInstance( t.FullName );
			PropertyInfo pi = t.GetProperty( "UpdateInfoURL" );
			// ReSharper disable AssignNullToNotNullAttribute
			string value = pi.GetValue( inst, BindingFlags.Default, null, new object[ 0 ], CultureInfo.CurrentCulture ) as string;
			// ReSharper restore AssignNullToNotNullAttribute
			return value;
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
	public static class Exts {
		#region public static void CopyContent( this DirectoryInfo source, DirectoryInfo target )
		/// <summary>
		/// 
		/// </summary>
		/// <param name="source"></param>
		/// <param name="target"></param>
		public static void CopyContent( this DirectoryInfo source, DirectoryInfo target ) {
			if( !Directory.Exists( target.FullName ) ) {
				Directory.CreateDirectory( target.FullName );
			}
			FileInfo[] files = source.GetFiles();
			foreach( FileInfo file in files ) {
				try {
					string nf = string.Format( "{0}\\{1}", target.FullName, file.Name );
					if( File.Exists( nf ) ) {
						File.SetAttributes( nf, FileAttributes.Normal );
					}
					Console.WriteLine(string.Format( "Copying {0} => {1}", file.FullName, nf ));
					File.Copy( file.FullName, nf, true );
				} catch {
				}
			}
			foreach( DirectoryInfo sub in source.GetDirectories() ) {
				sub.CopyContent( new DirectoryInfo( string.Format( "{0}\\{1}", target.FullName, sub.Name ) ) );
			}
		}
		#endregion
	}
	public class Update {
		public string ModuleName;
		public string DownloadURL;
		public string Description;
		public Version CurrentVersion;
		public Version NewVersion;
	}
}
