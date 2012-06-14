using System.Windows.Forms;
using Bummer.UpdateChecker;

namespace Bummer.Client {
	public partial class UpdateInfoControl : UserControl {
		private Update update;
		public UpdateInfoControl( Update update ) {
			InitializeComponent();
			this.update = update;
		}
		public UpdateInfoControl()
			: this( null ) {
		}

		private void UpdateInfoControl_Load( object sender, System.EventArgs e ) {
			if( update == null ) {
				return;
			}
			lblCurrentVersion.Text = update.CurrentVersion.ToString();
			lblAvailableVersion.Text = update.NewVersion.ToString();
			lblDescription.Text = update.Description;
			lblModule.Text = update.ModuleName;
		}
	}
}
