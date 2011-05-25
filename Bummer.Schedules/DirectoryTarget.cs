using System;
using System.IO;
using System.Windows.Forms;
using Bummer.Common;
using Bummer.Schedules.Controls;

namespace Bummer.Schedules {
	public class DirectoryTarget : IBackupTarget {
		public string dir;

		private DirectoryConfigSelector gui;

		public string Name {
			get {
				return "Directory";
			}
		}

		public string Description {
			get {
				return "Save files to a directory";
			}
		}

		public void InitiateConfiguration( Control container, string configuration ) {
			gui = new DirectoryConfigSelector( configuration );
			gui.Dock = DockStyle.Fill;
			container.Controls.Add( gui );
		}

		public string SaveConfiguration() {
			if( gui == null ) {
				throw new Exception( "GUI not initialized" );
			}
			if( string.IsNullOrEmpty( gui.Directory ) ) {
				throw new Exception( "You have to choose a target directory" );
			}
			return gui.Directory;
		}

		public IBackupTarget Prepare( string configuration ) {
			return new DirectoryTarget{dir = configuration};
		}

		public void Store( FileInfo file, string relativePath ) {
			DirectoryInfo baseDir = new DirectoryInfo( dir );
			if( !string.IsNullOrEmpty( relativePath ) ) {
				if( relativePath.StartsWith( "\\" ) ) {
					relativePath = relativePath.Substring( 1 );
				}
				baseDir = new DirectoryInfo( "{0}\\{1}".FillBlanks( baseDir.FullName, relativePath ) );
			}
			if( !Directory.Exists( baseDir.FullName ) ) {
				Directory.CreateDirectory( baseDir.FullName );
			}
			string targetFile = "{0}\\{1}".FillBlanks( baseDir.FullName, file.Name );
			if( File.Exists( targetFile ) ) {
				FileInfo fi = new FileInfo( targetFile );
				if( fi.Length == file.Length && file.LastWriteTime == fi.LastWriteTime ) {
					return;
				}
			}
			File.Copy( file.FullName, targetFile, true );
		}

		public void Dispose() {
			
		}
	}
}
