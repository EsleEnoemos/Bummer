using System;

namespace Bummer.Schedules {
//    public enum SaveAsTypes {
//        [EnumDescription("Saves results to a directory")]
//        Directory = 1,
//        [EnumDescription("Uploads results to a FTP-server")]
//        FTP = 2,
//        [EnumDescription("Uploads results to a HTTP or HTTPS site", @"The recieving site must be configured to provide a maximum size for each upload.
//This information should be of integer type, and be provided in a HTTP-Header called X-MaximumChunkSize.
//If authentication is required, this must be of Basic type (username/password).
//See further documentation at http://www.someone-else.com/Products/BUMmer")]
//        WWW = 3
//    }
	public enum BackupTypes {
		ModifiedOnly = 1,
		All = 2
	}
	[AttributeUsage( AttributeTargets.Field, AllowMultiple = false )]
	public class EnumDescriptionAttribute : Attribute {
		#region public string Description
		/// <summary>
		/// Get/Sets the Description of the EnumDescriptionAttribute
		/// </summary>
		/// <value></value>
		public string Description {
			get {
				return _description;
			}
			set {
				_description = value;
			}
		}
		private string _description;
		#endregion
		#region public string Comment
		/// <summary>
		/// Get/Sets the Comment of the EnumDescriptionAttribute
		/// </summary>
		/// <value></value>
		public string Comment {
			get {
				return _comment;
			}
			set {
				_comment = value;
			}
		}
		private string _comment;
		#endregion

		public EnumDescriptionAttribute( string description ) {
			_description = description;
			_comment = null;
		}
		#region public EnumDescriptionAttribute( string description, string comment = null )
		/// <summary>
		/// Initializes a new instance of the <b>EnumDescriptionAttribute</b> class.
		/// </summary>
		/// <param name="description"></param>
		/// <param name="comment"></param>
		public EnumDescriptionAttribute( string description, string comment ) {
			_description = description;
			_comment = comment;
		}
		#endregion
	}
	internal static class Exts {
		#region public static string InternalDescription<T>( this T ths )
		/// <summary>
		/// 
		/// </summary>
		/// <param name="ths"></param>
		/// <returns></returns>
		public static string InternalDescription<T>( this T ths ) where T : struct {
			EnumDescriptionAttribute att = GetAttribute( ths );
			return att == null ? null : att.Description;
		}
		#endregion
		#region public static string InternalComment<T>( this T ths )
		/// <summary>
		/// 
		/// </summary>
		/// <param name="ths"></param>
		/// <returns></returns>
		public static string InternalComment<T>( this T ths ) where T : struct {
			EnumDescriptionAttribute att = GetAttribute( ths );
			return att == null ? null : att.Comment;
		}
		#endregion
		#region private static EnumDescriptionAttribute GetAttribute<T>( T that )
		/// <summary>
		/// 
		/// </summary>
		/// <param name="that"></param>
		/// <returns></returns>
		private static EnumDescriptionAttribute GetAttribute<T>( T that ) {
			T v = that;
			object[] attr = v.GetType().GetField( v.ToString() ).GetCustomAttributes( typeof( EnumDescriptionAttribute ), true );
			if( attr.Length > 0 ) {
				foreach( object att in attr ) {
					EnumDescriptionAttribute ina = att as EnumDescriptionAttribute;
					if( ina == null ) {
						continue;
					}
					return ina;
				}
			}
			return null;
		}
		#endregion

	}
}
