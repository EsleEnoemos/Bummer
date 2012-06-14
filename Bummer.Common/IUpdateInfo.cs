namespace Bummer.Common {
	public interface IUpdateInfo {
		/// <summary>
		/// URL from which information about updates can be retrieved.
		/// The URL must give a XML-response with the following format:
		/// <example>
		/// &lt;UpdateInfo&gt;
		/// &lt;AssemblyFilename&gt;Complete name of assembly file, including extension&lt;/AssemblyFilename&gt;
		/// &lt;Version&gt;Version of the available download&lt;/Version&gt;
		/// &lt;VersionDescription&gt;Description about the update. This will be displayed to the user so he can decide if the update should be downloaded&lt;/VersionDescription&gt;
		/// &lt;DownloadURL&gt;Version of the available download&lt;/DownloadURL&gt;
		/// &lt;/UpdateInfo&gt;
		/// </example>
		/// </summary>
		string UpdateInfoURL { get; }
	}
}
