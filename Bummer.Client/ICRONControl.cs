using System;

namespace Bummer.Client {
	public interface ICRONControl {
		string CRONString { get; }
		event EventHandler SelectionChanged;
	}
}
