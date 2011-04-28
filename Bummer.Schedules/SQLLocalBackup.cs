using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.IO;

namespace Bummer.Schedules {
	/// <summary>
	/// All credits for this (exept for implementing Dispose) goes to http://www.codeproject.com/Members/Adrian-Pasik
	/// </summary>
	/// <remarks></remarks>
	/// <example></example>
	public class SQLLocalBackup : IDisposable {
		protected SqlConnection con;
		protected string _address;
		protected string _user;
		protected string _pass;
		protected string _dbname;
		#region public SQLLocalBackup(string Aaddress, string Auser, string Apass, string Adatabasename)
		/// <summary>
		/// Initializes a new instance of the <b>SQLLocalBackup</b> class.
		/// </summary>
		/// <param name="Aaddress"></param>
		/// <param name="Auser"></param>
		/// <param name="Apass"></param>
		/// <param name="Adatabasename"></param>
		public SQLLocalBackup( string Aaddress, string Auser, string Apass, string Adatabasename ) {
			try {
				con = new SqlConnection( String.Format( "Data Source={0};Initial Catalog={1};User Id={2};Password={3};", Aaddress, Adatabasename, Auser, Apass ) );
				con.Open();
				_address = Aaddress;
				_user = Auser;
				_pass = Apass;
				_dbname = Adatabasename;
			} catch( Exception ex ) {
				MessageBox.Show( ex.Message );
				throw;
			}
		}
		#endregion
		#region protected string FindUniqueTemporaryTableName()
		/// <summary>
		/// /// This function checks for temporary tables since we don't want to interfere with other programs/functions
		/// </summary>
		/// <returns></returns>
		protected string FindUniqueTemporaryTableName() {
			string name = "afpTempBackup";
			int counter = 0;
			SqlCommand _mycommand = new SqlCommand();
			_mycommand.Connection = con;
			while( true ) {
				++counter;
				string sql = String.Format( "SELECT OBJECT_ID('tempdb..##{0}') as xyz", name + counter );
				_mycommand.CommandText = sql;
				if( _mycommand.ExecuteScalar().ToString() == "" ) {
					return name + counter;
				}
			}
		}
		#endregion

		/// <summary>
		/// Main backuping function
		/// </summary>
		/// <param name="AremoteTempPath">You can specify what folder do you wish to be set for your backup</param>
		/// <param name="AlocalPath">Local path where copy of your backup file</param>
		/// <param name="addDateToFilename"></param>
		public MSSQLDatabaseBackup.BackupResult DoLocalBackup( string AremoteTempPath, string AlocalPath, bool addDateToFilename ) {
			MSSQLDatabaseBackup.BackupResult ret = new MSSQLDatabaseBackup.BackupResult();
			SqlCommand cmd = null;
			try {
				cmd = new SqlCommand();
				cmd.Connection = con;
				// nice filename on local side, so we know when backup was done
				string fileName = _dbname + (addDateToFilename ? DateTime.Now.ToString( " yyyy-MM-dd HH.mm.ss" ) : "") + ".bak";
				// we invoke this method to ensure we didnt mess up with other programs
				string temporaryTableName = FindUniqueTemporaryTableName();

				DirectoryInfo rd = new DirectoryInfo( AremoteTempPath );

				string remoteFilename = rd.FullName + "\\" + _dbname + ".bak";
				string sql = String.Format( "BACKUP DATABASE {0} TO DISK = N'{1}' WITH FORMAT, COPY_ONLY, INIT, NAME = N'{0} - Full Database Backup', SKIP ", _dbname, remoteFilename );
				cmd.CommandText = sql;
				cmd.ExecuteNonQuery();
				sql = String.Format( "IF OBJECT_ID('tempdb..##{0}') IS NOT NULL DROP TABLE ##{0}", temporaryTableName );
				cmd.CommandText = sql;
				cmd.ExecuteNonQuery();
				sql = String.Format( "CREATE TABLE ##{0} (bck VARBINARY(MAX))", temporaryTableName );
				cmd.CommandText = sql;
				cmd.ExecuteNonQuery();
				sql = String.Format( "INSERT INTO ##{0} SELECT bck.* FROM OPENROWSET(BULK '{1}\\{2}.bak',SINGLE_BLOB) bck", temporaryTableName, AremoteTempPath, _dbname );
				cmd.CommandText = sql;
				cmd.ExecuteNonQuery();
				sql = String.Format( "SELECT bck FROM ##{0}", temporaryTableName );
				SqlDataAdapter da = new SqlDataAdapter( sql, con );
				DataSet ds = new DataSet();
				da.Fill( ds );
				DataRow dr = ds.Tables[ 0 ].Rows[ 0 ];
				byte[] backupFromServer = (byte[])dr[ "bck" ];
				int aSize = backupFromServer.GetUpperBound( 0 ) + 1;
				ret.OutputFilename = String.Format( "{0}\\{1}", AlocalPath, fileName );
				FileStream fs = new FileStream( ret.OutputFilename, FileMode.OpenOrCreate, FileAccess.Write );
				fs.Write( backupFromServer, 0, aSize );
				fs.Close();

				sql = String.Format( "DROP TABLE ##{0}", temporaryTableName );
				cmd.CommandText = sql;
				cmd.ExecuteNonQuery();
				ds.Dispose();
				sql = string.Format( "xp_cmdshell 'del {0}'", remoteFilename );
				cmd.CommandText = sql;
				try {
					cmd.ExecuteNonQuery();
					ret.CleanupOK = true;
				} catch( Exception ) {
					ret.CleanupOK = false;
				}
			} finally {
				if( cmd != null ) {
					cmd.Dispose();
				}
			}
			return ret;
		}

		public void Dispose() {
			if( con != null ) {
				con.Close();
			}
		}
	}
}