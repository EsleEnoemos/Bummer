using System;
using System.Windows.Forms;

namespace Bummer.Common {
	public interface IBackupSchedule {
		string Name { get; }
		string Description { get; }

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
		/// <param name="config"></param>
		/// <returns></returns>
		string Execute( string config );
	}
}
