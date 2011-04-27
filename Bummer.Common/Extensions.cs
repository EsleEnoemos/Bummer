using System;
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
	}
}
