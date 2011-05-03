using System.Windows.Forms;

namespace Bummer.Schedules.Controls {
	public partial class InputDialog : Form {
		public string Value {
			get {
				return textBox1.Text;
			}
		}

		private string title;
		public InputDialog( string title ) {
			this.title = title;
			InitializeComponent();
		}
		public InputDialog()
			: this( null ) {
		}

		private void InputDialog_Load( object sender, System.EventArgs e ) {
			if( title != null ) {
				Text = title;
			}
		}

		private void InputDialog_FormClosing( object sender, FormClosingEventArgs e ) {
			if( DialogResult != DialogResult.OK) {
				return;
			}
			if( string.IsNullOrEmpty( Value ) ) {
				e.Cancel = true;
				MessageBox.Show( "Please enter a value" );
			}
		}
	}
}
