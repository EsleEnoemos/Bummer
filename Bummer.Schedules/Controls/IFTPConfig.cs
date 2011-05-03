namespace Bummer.Schedules.Controls {
	public interface IFTPConfig {
		string FTPServer { get; }
		string FTPUsername { get; }
		string FTPPassword { get; }
		string FTPRemoteDirectory { get; }
		string FTPLocalTempDirectory { get; }
		int FTPPort { get; }
	}
}
