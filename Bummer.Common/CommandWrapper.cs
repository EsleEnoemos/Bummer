using System;
using System.Collections.Generic;

namespace Bummer.Common {
	public class CommandWrapper {
		public string Command;
		public string Arguments;

		public override string ToString() {
			return "{0} {1}".FillBlanks( Command, Arguments );
		}

		public static List<CommandWrapper> Parse( string commands ) {
			List<CommandWrapper> list = new List<CommandWrapper>();
			if( string.IsNullOrEmpty( commands ) ) {
				return list;
			}
			string[] arr = commands.Split( new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries );
			foreach( var s in arr ) {
				string ss = s.Trim();
				string[] ca = ss.Split( new[] { '\t' }, 2 );
				CommandWrapper cw = new CommandWrapper{Command = ca[0], Arguments = ca.Length > 1 ? ca[ 1 ] : null};
				list.Add( cw );
			}
			return list;
		}
	}
}
