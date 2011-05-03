using System;
using System.IO;
using System.Windows.Forms;
using Bummer.Common;

namespace Bummer.Client {
	public partial class CommandDialog : Form {
		private string command;
		private string args;

		public string Command {
			get {
				return tbCommand.Text;
			}
		}
		public string Arguments {
			get {
				return tbArgs.Text;
			}
		}
		public CommandDialog( string command, string args ) {
			this.command = command;
			this.args = args;
			InitializeComponent();
		}
		#region public CommandDialog()
		/// <summary>
		/// Initializes a new instance of the <b>CommandDialog</b> class.
		/// </summary>
		public CommandDialog()
			: this( null, null ) {
		}
		#endregion

		private void CommandDialog_Load( object sender, System.EventArgs e ) {
			tbCommand.Text = command;
			tbArgs.Text = args;
			Text = string.IsNullOrEmpty( command ) ? "Add command" : "Edit command";
		}

		private void CommandDialog_FormClosing( object sender, FormClosingEventArgs e ) {
			if( DialogResult != DialogResult.OK ) {
				return;
			}
			if( string.IsNullOrEmpty( Command ) ) {
				e.Cancel = true;
				MessageBox.Show( "You have to enter a command" );
				return;
			}
			if( !File.Exists( Command ) ) {
				e.Cancel = true;
				MessageBox.Show( "Unable to find specified command.{0}Please enter complete path to executable!".FillBlanks( Environment.NewLine ) );
				return;
			}
		}
	}
}
