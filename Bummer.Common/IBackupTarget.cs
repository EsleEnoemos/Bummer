using System;
using System.IO;
using System.Windows.Forms;

namespace Bummer.Common {
	/// <summary>
	/// Definition of a target.
	/// The purpose of a IBackupTarget is to store a file.
	/// Storage can be a directory, but can also be a FTP-server etc.
	/// </summary>
	public interface IBackupTarget : IDisposable {
		/// <summary>
		/// A descriptive name of the target (e.g. Directory if the target saves files to a directory)
		/// </summary>
		string Name { get; }

		/// <summary>
		/// A description of a target
		/// </summary>
		string Description { get; }

		/// <summary>
		/// Called when editing a schedule.
		/// A control should be added to the container to allow the user to select appropriate settings for the target
		/// </summary>
		/// <param name="container"></param>
		/// <param name="configuration"></param>
		void InitiateConfiguration( Control container, string configuration );

		/// <summary>
		/// Called when the editing a job is finished, and the user press the save-button.
		/// If anything is missing in the configuration, an exception should be thrown explaning what's wrong/missing
		/// </summary>
		/// <returns></returns>
		string SaveConfiguration();

		/// <summary>
		/// Called before executing a job.
		/// A new instance of the target should be returned
		/// </summary>
		/// <param name="configuration"></param>
		/// <returns></returns>
		IBackupTarget Prepare( string configuration );

		/// <summary>
		/// Called each time a job needs to store a file
		/// This could be called several times during the run of a job
		/// </summary>
		/// <param name="file">The file to store</param>
		/// <param name="relativePath">Relative path of the file (if applicable)</param>
		void Store( FileInfo file, string relativePath );
	}
}
