using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using IWshRuntimeLibrary;
using File = System.IO.File;


namespace Bummer.ServiceInstaller {
	/// <summary>
	/// This entire applications only purpose is to be called by the BummerInstallation.
	/// If called during installation, it sets up a the bummer service, starts it, copies the plugins from program files to app-data folder, and creates a shortcut in the startmenu (for some reason, I can't get this to work with the installer)
	/// Because it creates a shortcut, it has to be a .NET Framework 2.0 project since this uses an interop to an active X control...
	/// 
	/// If called during uninstall, it stop/removes the service, removes files from app-data folder, and removes the shortcut in the startmenu.
	/// </summary>
	class Program {
		#region public static DirectoryInfo DataDirectory
		/// <summary>
		/// Gets the DataDirectory of the Program
		/// </summary>
		/// <value></value>
		public static DirectoryInfo DataDirectory {
			get {
				if( _dataDirectory == null ) {
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
		static void Main( string[] args ) {
			//IDictionary environmentVariables = Environment.GetEnvironmentVariables();
			//foreach( DictionaryEntry de in environmentVariables ) {
			//    Console.WriteLine( "  {0} = {1}", de.Key, de.Value );
			//}
			//Console.ReadKey();
			Log( "Start" );
			if( args == null || args.Length < 1 ) {
				Log( "No args" );
				return;
			}
			switch( args[ 0 ].ToLower() ) {
				case "remove":
					RemoveService();
					break;
				case "install":
					InstallService();
					break;
			}
		}
		public static void Log( string message ) {
			//try {
			//    File.AppendAllText( @"C:\Temp\ServiceInstallerLog.log", message + Environment.NewLine );
			//} catch {
			//}
		}
		#region private static void RemoveService()
		/// <summary>
		/// 
		/// </summary>
		private static void RemoveService() {
			Log( "Before remove" );
			new ServiceInstaller().Remove();
			Log( "After remove" );
		}
		#endregion
		#region private static void InstallService()
		/// <summary>
		/// 
		/// </summary>
		private static void InstallService() {
			Log( "Before install" );
			new ServiceInstaller().Install();
			Log( "After install" );
		}
		#endregion
		#region public static void Copy( DirectoryInfo self, string targetDirectory, bool recursive )
		/// <summary>
		/// This is an extension method from Bummer.Common.Extensions, but since this has to be a framework 2.0 project, it is copied to a static method
		/// </summary>
		/// <param name="self"></param>
		/// <param name="targetDirectory"></param>
		/// <param name="recursive"></param>
		public static void Copy( DirectoryInfo self, string targetDirectory, bool recursive ) {
			if( !Directory.Exists( targetDirectory ) ) {
				Directory.CreateDirectory( targetDirectory );
			}
			DirectoryInfo td = new DirectoryInfo( targetDirectory );
			foreach( FileInfo file in self.GetFiles() ) {
				file.CopyTo( string.Format( "{0}\\{1}", td.FullName, file.Name ), true );
			}
			if( recursive ) {
				foreach( DirectoryInfo sub in self.GetDirectories() ) {
					Copy( sub, string.Format( "{0}\\{1}", td.FullName, sub.Name ), true );
				}
			}
		}
		#endregion

		private class ServiceInstaller {
			#region private string InstallUtil
			/// <summary>
			/// Gets the InstallUtil of the ServiceInstaller
			/// </summary>
			/// <value></value>
			private string InstallUtil {
				get {
					if( _installUtil == null ) {
						Log( "Finding InstallUtil" );
						string windir = Environment.GetEnvironmentVariable( "windir" );
						Log( "Finding InstallUtil, windir: " + windir );
						if( !string.IsNullOrEmpty( windir ) ) {
							DirectoryInfo wd = new DirectoryInfo( windir );
							if( wd.Exists ) {
								DirectoryInfo netFolder = new DirectoryInfo( wd.FullName + @"\Microsoft.NET\Framework" );
								Log( "Finding InstallUtil, netFolder: " + netFolder.FullName );
								if( netFolder.Exists ) {
									Log( "Finding InstallUtil, netFolder exists" );
									DirectoryInfo[] frameworks = netFolder.GetDirectories( "v4.0*" );
									DirectoryInfo fw40 = null;
									foreach( DirectoryInfo framework in frameworks ) {
										if( framework.Name.ToLower().StartsWith( "v4.0" ) ) {
											fw40 = framework;
											break;
										}
									}
									if( fw40 != null ) {
										string tmp = fw40.FullName + "\\InstallUtil.exe";
										if( File.Exists( tmp ) ) {
											_installUtil = tmp;
										}
									}
								}
							}
						}
						Log( "Finding InstallUtil: " + _installUtil );
					}
					return _installUtil;
				}
			}
			private string _installUtil;
			#endregion

			#region public void Install()
			/// <summary>
			/// 
			/// </summary>
			public void Install() {
				try {
					Process startServiceProcess = null;
					Log( "Install starting" );
					DirectoryInfo installDir = GetInstallPath();
					if( installDir == null ) {
						Log( "Install, installdir is null" );
						return;
					}
					if( InstallUtil != null && installDir.Exists ) {
						if( true ) {
							SetTitle( "Installing service" );
							Console.WriteLine( "Installing service..." );
							Process p = new Process();
							p.StartInfo = new ProcessStartInfo( InstallUtil, "\"" + installDir.FullName + "\\Bummer.Service.exe\"" );
							p.StartInfo.CreateNoWindow = true;
							p.StartInfo.UseShellExecute = false;
							p.Start();
							p.WaitForExit();
							DirectoryInfo sys = new DirectoryInfo( Environment.SystemDirectory );
							if( sys.Exists ) {
								FileInfo net = new FileInfo( sys.FullName + "\\net.exe" );
								if( net.Exists ) {
									startServiceProcess = new Process();
									startServiceProcess.StartInfo = new ProcessStartInfo( net.FullName, "start BummerService" );
									startServiceProcess.StartInfo.CreateNoWindow = true;
									startServiceProcess.StartInfo.UseShellExecute = false;
								}
							}
						}
					}
					SetTitle( "Installing plugins" );
					Log( "Install plugins, before plugins" );
					DirectoryInfo pluginsDir = new DirectoryInfo( installDir.FullName + "\\Plugins" );
					if( Directory.Exists( pluginsDir.FullName ) ) {
						Log( "Install plugins, tempPlugins: " + pluginsDir.FullName );
						Log( string.Format( "Install plugins, copying from \"{0}\" to \"{1}\"\\Plugins", pluginsDir.FullName, DataDirectory.FullName ) );
						SetTitle( "Installing plugins" );
						Console.WriteLine( "Installing plugins..." );
						Copy( pluginsDir, DataDirectory.FullName + "\\Plugins", true );
						Log( "Install plugins, removing tempPlugins" );
						Console.WriteLine( "Cleaning up temporary files..." );
						pluginsDir.Delete( true );
						Log( "Install plugins, removed tempPlugins" );
					}
					string clientEXE = string.Format( "{0}\\Bummer.Client.exe", installDir.FullName );
					Log( "About to create shortcut to " + clientEXE );
					if( File.Exists( clientEXE ) ) {
						Log( "EXE for shortcut exists" );
						CreateShortcut( new FileInfo( clientEXE ), "Someone Else", "BUMmer Client", "Launch BUMmer"  );
					} else {
						Log( "EXE does not exist" );
					}
					Log( "After shortcut" );
					if( startServiceProcess != null ) {
						// This will create the database file before the service kicks in and creates it.
						// Since the service runns as Network Service, there might be problems with file permissions for the user when adding schedules
						try {
							Configuration.CreateDBFileAndSetPermissions();
						} catch {}
						Console.WriteLine( "Starting service..." );
						startServiceProcess.Start();
						startServiceProcess.WaitForExit();
					}
				} catch( Exception ex ) {
					Log( "Install error: " + ex.Message );
					//Log( "OnAfterInstall exception: " + ex.Message );
				}
			}
			#endregion
			#region public void Remove()
			/// <summary>
			/// 
			/// </summary>
			public void Remove() {
				Log( "Remove starting" );
				SetTitle( "Removing service" );
				try {
					DirectoryInfo installDir = GetInstallPath();
					if( installDir == null ) {
						Log( "Remove, installDir is null" );
						return;
					}
					if( InstallUtil != null && installDir.Exists ) {
						Console.WriteLine( "Removing service..." );
						Process p = new Process();
						p.StartInfo = new ProcessStartInfo( InstallUtil, "\"" + installDir.FullName + "\\Bummer.Service.exe\" /u" );
						p.StartInfo.CreateNoWindow = true;
						p.StartInfo.UseShellExecute = false;
						p.Start();
						p.WaitForExit();
					}
					SetTitle( "Removing plugins" );
					DirectoryInfo pluginsDir = new DirectoryInfo( DataDirectory.FullName + "\\Plugins" );
					if( Directory.Exists( pluginsDir.FullName ) ) {
						Log( "Removing plugins" );
						Console.WriteLine( "Removing plugins..." );
						pluginsDir.Delete( true );
					}
					if( DataDirectory.Exists ) {
						Log( "Removing data dir" );
						Console.WriteLine( "Removing data..." );
						DataDirectory.Delete( true );
					}
					RemoveShortcut( "Someone Else", "BUMmer Client"  );
				} catch( Exception ex ) {
					Log( "Remove error: " + ex.Message );
				}
			}
			#endregion
			#region private DirectoryInfo GetInstallPath()
			/// <summary>
			/// 
			/// </summary>
			/// <returns></returns>
			private DirectoryInfo GetInstallPath() {
				Log( "GetInstallPath, exe: " + Application.ExecutablePath );
				FileInfo fi = new FileInfo( Application.ExecutablePath );
				return fi.Directory;
			}
			#endregion
			#region private void SetTitle( string title )
			/// <summary>
			/// 
			/// </summary>
			/// <param name="title"></param>
			private void SetTitle( string title ) {
				try {
					Console.Title = title;
				} catch {
				}
			}
			#endregion
			#region private void CreateShortcut( FileInfo target, string folderName, string shortCutName, string description )
			/// <summary>
			/// 
			/// </summary>
			/// <param name="target"></param>
			/// <param name="folderName"></param>
			/// <param name="shortCutName"></param>
			/// <param name="description"></param>
			private void CreateShortcut( FileInfo target, string folderName, string shortCutName, string description ) {
				
				Log( "Start CreateShortcut" );
				try {
					DirectoryInfo startMenu = new DirectoryInfo( Environment.GetFolderPath( Environment.SpecialFolder.StartMenu ) );
					Log( "CreateShortcut startmenu " + startMenu.FullName );
					if( !Directory.Exists( startMenu.FullName ) ) {
						Log( "CreateShortcut no startmenu, aborting" );
						return;
					}
					DirectoryInfo shortCutFolder = startMenu;
					if( !string.IsNullOrEmpty( folderName ) ) {
						shortCutFolder = new DirectoryInfo( string.Format( "{0}\\{1}", startMenu.FullName, folderName ) );
					}
					Log( "CreateShortcut shortcut folder " + shortCutFolder.FullName );
					if( !Directory.Exists( shortCutFolder.FullName ) ) {
						Log( "CreateShortcut creating folder " + shortCutFolder.FullName );
						Directory.CreateDirectory( shortCutFolder.FullName );
					}
					FileInfo lnk = new FileInfo( string.Format( "{0}\\{1}", shortCutFolder.FullName, shortCutName ) );
					if( !string.Equals( ".lnk", lnk.Extension, StringComparison.OrdinalIgnoreCase ) ) {
						lnk = new FileInfo( string.Format( "{0}\\{1}.lnk", shortCutFolder.FullName, shortCutName ) );
					}
					Log( "CreateShortcut link " + lnk.FullName );
					if( File.Exists( lnk.FullName ) ) {
						File.Delete( lnk.FullName );
					}
					Log( "CreateShortcut before shell" );
					WshShellClass shell = new WshShellClass();
					Log( "CreateShortcut before creating shortcut object" );
					IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut( lnk.FullName );
					Log( "CreateShortcut before setting shortcut properties" );
					shortcut.TargetPath = target.FullName;
					shortcut.Description = description;
					shortcut.IconLocation = string.Format( "{0},0", target.FullName );
					Log( "CreateShortcut before save" );
					shortcut.Save();
				} catch( Exception ex ) {
					Log( "Error creating shortcut: " + ex.Message );
				}
				Log( "End CreateShortcut" );
			}
			#endregion
			#region private void RemoveShortcut( string folderName, string shortCutName )
			/// <summary>
			/// 
			/// </summary>
			/// <param name="folderName"></param>
			/// <param name="shortCutName"></param>
			private void RemoveShortcut( string folderName, string shortCutName ) {
				DirectoryInfo startMenu = new DirectoryInfo( Environment.GetFolderPath( Environment.SpecialFolder.StartMenu ) );
				if( !Directory.Exists( startMenu.FullName ) ) {
					return;
				}
				DirectoryInfo shortCutFolder = startMenu;
				if( !string.IsNullOrEmpty( folderName ) ) {
					shortCutFolder = new DirectoryInfo( string.Format( "{0}\\{1}", startMenu.FullName, folderName ) );
				}
				if( !Directory.Exists( shortCutFolder.FullName ) ) {
					return;
				}
				FileInfo lnk = new FileInfo( string.Format( "{0}\\{1}", shortCutFolder.FullName, shortCutName ) );
				if( !string.Equals( ".lnk", lnk.Extension, StringComparison.OrdinalIgnoreCase ) ) {
					lnk = new FileInfo( string.Format( "{0}\\{1}.lnk", shortCutFolder.FullName, shortCutName ) );
				}
				if( File.Exists( lnk.FullName ) ) {
					File.Delete( lnk.FullName );
				}
				if( shortCutFolder.GetFiles().Length > 0 ) {
					return;
				}
				shortCutFolder.Delete( true );
			}
			#endregion
		}
	}
}
