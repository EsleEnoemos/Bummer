using System;
using System.IO;
using System.Net;
using Bummer.Common;
using Bummer.Schedules.Controls;

namespace Bummer.Schedules {
	public class FTPUploader {
		private IFTPConfig conf;
		private bool? passive;
		public FTPUploader( IFTPConfig config ) {
			conf = config;
		}
		#region public void UploadFile( string filename )
		/// <summary>
		/// 
		/// </summary>
		/// <param name="filename"></param>
		public void UploadFile( string filename ) {
			UploadFile( filename, conf.FTPRemoteDirectory );
		}
		#endregion
		#region public void UploadFile( string filename, string remotePath )
		/// <summary>
		/// 
		/// </summary>
		/// <param name="filename"></param>
		/// <param name="remotePath"></param>
		public void UploadFile( string filename, string remotePath ) {
			string url = conf.FTPServer;
			if( !url.Contains( "://" ) ) {
				url = "ftp://{0}".FillBlanks( url );
			}
			url = "{0}:{1}".FillBlanks( url, conf.FTPPort );

			if( !string.IsNullOrEmpty( remotePath ) ) {
				string rd = remotePath;
				if( !rd.StartsWith( "/" ) ) {
					rd = "/{0}".FillBlanks( rd );
				}
				url = "{0}{1}".FillBlanks( url, rd );
			}
			if( !url.EndsWith( "/" ) ) {
				url = "{0}/".FillBlanks( url );
			}
			FileInfo fi = new FileInfo( filename );
			url = "{0}{1}".FillBlanks( url, fi.Name );

			FtpWebRequest req = (FtpWebRequest)FtpWebRequest.Create( url );
			req.Credentials = new NetworkCredential( conf.FTPUsername, conf.FTPPassword );
			req.KeepAlive = false;
			req.Method = WebRequestMethods.Ftp.UploadFile;
			req.UseBinary = true;
			req.ContentLength = fi.Length;
			if( passive.HasValue ) {
				req.UsePassive = passive.Value;
			}
			const int buffSize = 1024 * 1024;
			byte[] bytes = new byte[ buffSize ];
			Stream outStream = null;
			try {
				outStream = req.GetRequestStream();
				passive = req.UsePassive;
			} catch( Exception ex ) {
				string ml = ex.Message.ToLower();
				if( ml.Contains( "time" ) && ml.Contains( "out" ) ) {
					req = (FtpWebRequest)FtpWebRequest.Create( req.RequestUri );
					req.Credentials = new NetworkCredential( conf.FTPUsername, conf.FTPPassword );
					req.KeepAlive = false;
					req.Method = WebRequestMethods.Ftp.UploadFile;
					req.UseBinary = true;
					req.ContentLength = fi.Length;
					req.UsePassive = !req.UsePassive;
					outStream = req.GetRequestStream();
					passive = req.UsePassive;
				}
			}
			if( outStream == null ) {
				throw new Exception( "Unable to upload file to FTP-server" );
			}
			FileStream fs = fi.OpenRead();
			int read;
			while( (read = fs.Read( bytes, 0, buffSize )) > 0 ) {
				outStream.Write( bytes, 0, read );
			}
			outStream.Flush();
			outStream.Close();
			outStream.Dispose();
			fs.Close();
			fs.Dispose();
		}
		#endregion
	}
}