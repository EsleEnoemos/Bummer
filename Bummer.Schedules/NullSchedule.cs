using System;
using System.Windows.Forms;
using Bummer.Common;

namespace Bummer.Schedules {
	public class NullSchedule : IBackupSchedule {
		public string Name {
			get {
				return "NullSchedule";
			}
		}

		public string Description {
			get {
				return @"Does absolutely nothing.
The only purpose of this is for you to be able to test your repetition settings";
			}
		}

		public void InitiateConfiguration( Control container, string config ) {
			
		}

		public string SaveConfiguration() {
			return null;
		}

		public string Execute( string config, int jobID, IBackupTarget target ) {
			//bool t = true;
			//while( t ) {
			//    System.Threading.Thread.Sleep( 200 );
			//}
			return "NullSchedule {0} executed".FillBlanks( jobID );
		}

		public void Delete( string config, int jobID ) {
			
		}
	}
}
