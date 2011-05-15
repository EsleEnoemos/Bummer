using System;
using System.Windows.Forms;

namespace Bummer.Common {
	public interface IBackupSchedule {
		string Name { get; }
		string Description { get; }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="container">Container to add controls for custom configuration</param>
		/// <param name="config">The configuration stored for this job</param>
		void InitiateConfiguration( Control container, string config );

		/// <summary>
		/// Saves the configuration, if any, and returns it as a string.
		/// If something goes wrong, or if some configuration is missing, an <see cref="Exception"/> should be thrown telling what went wrong
		/// </summary>
		/// <returns></returns>
		string SaveConfiguration();

		/// <summary>
		/// Executes the scheduel and returns a message telling of the results.
		/// If something goes wrong, an <see cref="Exception"/> should be thrown telling what happened
		/// </summary>
		/// <param name="config">The configuration stored for this job</param>
		/// <param name="jobID">The ID for this job</param>
		/// <param name="target">The target to save files to</param>
		/// <returns></returns>
		string Execute( string config, int jobID, IBackupTarget target );

		/// <summary>
		/// Called when a job is deleted permanently.
		/// Enabels the job to perform cleanup of any saved data, i.e. data stored on disk etc.
		/// </summary>
		/// <param name="config"></param>
		/// <param name="jobID"></param>
		void Delete( string config, int jobID );
	}
}
