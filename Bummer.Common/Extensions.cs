using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Bummer.Common {
	public static class Extensions {
		#region public static string FillBlanks( this string self, params object[] args )
		/// <summary>
		/// 
		/// </summary>
		/// <param name="self"></param>
		/// <param name="args"></param>
		/// <returns></returns>
		public static string FillBlanks( this string self, params object[] args ) {
			return string.Format( self, args );
		}
		#endregion
		#region public static byte[] ToByteArray( this string ths )
		/// <summary>
		/// 
		/// </summary>
		/// <param name="ths"></param>
		/// <returns></returns>
		public static byte[] ToByteArray( this string ths ) {
			if( string.IsNullOrEmpty( ths ) ) {
				return new byte[ 0 ];
			}
			ByteBuffer bb = new ByteBuffer();
			foreach( char c in ths ) {
				if( c > 255 ) {
					byte[] bytes = Encoding.UTF8.GetBytes( new[] { c } );
					bb.Append( bytes );
				} else {
					bb.Append( Convert.ToByte( c ) );
				}
			}
			return bb.GetBytes();
		}
		#endregion
		#region public static bool EqualsAny( this string ths, StringComparison sc, params string[] args )
		/// <summary>
		/// 
		/// </summary>
		/// <param name="ths"></param>
		/// <param name="sc"></param>
		/// <param name="args"></param>
		/// <returns></returns>
		public static bool EqualsAny( this string ths, StringComparison sc, params string[] args ) {
			if( ths == null ) {
				return false;
			}
			foreach( string s in args ) {
				if( string.Equals( ths, s, sc ) ) {
					return true;
				}
			}
			return false;
		}
		#endregion
		#region public static string ToString( this List<string> ths, string separator )
		/// <summary>
		/// Returns a <see cref="string"/> that represents the current <see cref="Bummer.Common.Extensions"/>.
		/// </summary>
		/// <param name="ths"></param>
		/// <param name="separator"></param>
		/// <returns>A <see cref="string"/> that represents the current <see cref="Bummer.Common.Extensions"/>.</returns>
		public static string ToString( this List<string> ths, string separator ) {
			if( ths == null ) {
				return "";
			}
			StringBuilder sb = new StringBuilder();
			for( int i = 0; i < ths.Count; i++ ) {
				sb.Append( ths[ i ] );
				if( (i + 1) < ths.Count ) {
					sb.Append( separator );
				}
			}
			return sb.ToString();
		}
		#endregion
		#region public static void Copy( this DirectoryInfo self, string targetDirectory, bool recursive )
		/// <summary>
		/// 
		/// </summary>
		/// <param name="self"></param>
		/// <param name="targetDirectory"></param>
		/// <param name="recursive"></param>
		public static void Copy( this DirectoryInfo self, string targetDirectory, bool recursive ) {
			if( !Directory.Exists( targetDirectory ) ) {
				Directory.CreateDirectory( targetDirectory );
			}
			DirectoryInfo td = new DirectoryInfo( targetDirectory );
			foreach( FileInfo file in self.GetFiles() ) {
				file.CopyTo( "{0}\\{1}".FillBlanks( td.FullName, file.Name ), true );
			}
			if( recursive ) {
				foreach( DirectoryInfo sub in self.GetDirectories() ) {
					sub.Copy( "{0}\\{1}".FillBlanks( td.FullName, sub.Name ), true );
				}
			}
		}
		#endregion
	}
}
