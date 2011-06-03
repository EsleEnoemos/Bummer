using System.IO;
using System.Windows.Forms;
using Bummer.Common;

namespace Bummer.Schedules {
	public class NullTarget : IBackupTarget {
		public void Dispose() {
			
		}

		public string Name {
			get {
				return "NullTarget";
			}
		}

		public string Description {
			get {
				return @"Does absolutely nothing.
The only purpose of this is for you to be able to test your repetition settings";
			}
		}

		public void InitiateConfiguration( Control container, string configuration ) {
			
		}

		public string SaveConfiguration() {
			return null;
		}

		public IBackupTarget Prepare( string configuration ) {
			return new NullTarget();
		}

		public void Store( FileInfo file, string relativePath ) {
			
		}
	}
}
