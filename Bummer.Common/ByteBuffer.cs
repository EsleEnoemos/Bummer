using System;

namespace Bummer.Common {
	/// <summary>
	/// 
	/// </summary>
	/// <remarks></remarks>
	/// <example></example>
	public class ByteBuffer {
		private byte[] buffer = new byte[ 8096 ];
		private int position;
		#region private int FreeSpace
		/// <summary>
		/// Gets the FreeSpace of the ByteBuffer
		/// </summary>
		/// <value></value>
		private int FreeSpace {
			get {
				return buffer.Length - position;
			}
		}
		#endregion
		#region public int Length
		/// <summary>
		/// Gets the Length of the ByteBuffer
		/// </summary>
		/// <value></value>
		public int Length {
			get {
				return position;
			}
		}
		#endregion

		#region public void Append( byte b )
		/// <summary>
		/// 
		/// </summary>
		/// <param name="b"></param>
		public void Append( byte b ) {
			if( FreeSpace < 1 ) {
				Expand( 1024 );
			}
			buffer[ position++ ] = b;
		}
		#endregion
		#region public void Append( byte[] bytes )
		/// <summary>
		/// 
		/// </summary>
		/// <param name="bytes"></param>
		public void Append( byte[] bytes ) {
			Append( bytes, bytes.Length );
		}
		#endregion
		#region public void Append( byte[] bytes, int length )
		/// <summary>
		/// 
		/// </summary>
		/// <param name="bytes"></param>
		/// <param name="length"></param>
		public void Append( byte[] bytes, int length ) {
			if( length > FreeSpace ) {
				Expand( length );
			}
			for( int i = 0; i < length; i++ ) {
				buffer[ position++ ] = bytes[ i ];
			}
		}
		#endregion

		#region private void Expand( int neededSpace )
		/// <summary>
		/// 
		/// </summary>
		/// <param name="neededSpace"></param>
		private void Expand( int neededSpace ) {
			byte[] tmp = new byte[ buffer.Length + neededSpace ];
			buffer.CopyTo( tmp, 0 );
			buffer = tmp;
		}
		#endregion

		#region public byte[] GetBytes()
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public byte[] GetBytes() {
			byte[] bytes = new byte[ position ];
			Array.Copy( buffer, bytes, position );
			//for( int i = 0; i < position; i++ ) {
			//    bytes[ i ] = buffer[ i ];
			//}
			return bytes;
		}
		#endregion
	}
}
