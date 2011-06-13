using System;
using System.Collections.Generic;
using Ionic.Zip;

namespace Zipper {
	class Program {
		#region static void Main( string[] args )
		/// <summary>
		/// 
		/// </summary>
		/// <param name="args"></param>
		static void Main( string[] args ) {
			if( args == null || args.Length < 2 ) {
				ShowUsage();
				return;
			}
			string rp = "";
			foreach( string arg in args ) {
				if( arg.StartsWith( "-p" ) ) {
					if( !arg.Contains( "=" ) ) {
						ShowUsage();
						return;
					}
					rp = arg.Split( '=' )[ 1 ];
				}
			}
			if( !string.IsNullOrEmpty( rp ) ) {
				if( args.Length < 3 ) {
					ShowUsage();
					return;
				}
			}
			string filename = null;
			foreach( string s in args ) {
				if( s.StartsWith( "-p=" ) ) {
					continue;
				}
				filename = s;
				break;
			}
			List<string> files = new List<string>();
			int filesIndex = 1;
			if( args[ 0 ].StartsWith( "-p=" ) ) {
				filesIndex = 2;
			}
			for( int i = filesIndex; i < args.Length; i++ ) {
				files.Add( args[ i ] );
			}
			ZipFile zip = new ZipFile( filename );
			foreach( string file in files ) {
				try {
					zip.AddFile( file, rp );
					Console.WriteLine( string.Format( "Adding {0}", file ) );
				} catch {}
			}
			Console.WriteLine( "Saving..." );
			zip.Save();
			Console.WriteLine( "Done" );
		}

		#endregion
		#region private static void ShowUsage()
		/// <summary>
		/// 
		/// </summary>
		private static void ShowUsage() {
			Console.WriteLine( @"Zipper usage:
Zipper [-p=relativePathInZip] <ZipFile> <Files to include>
Use -p to add files to a relative internal path in the zip-file" );
		}
		#endregion
	}
}
