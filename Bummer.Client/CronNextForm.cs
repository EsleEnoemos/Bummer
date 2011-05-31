using System;
using System.Windows.Forms;
using Quartz;

namespace Bummer.Client {
	public partial class CronNextForm : Form {
		private string cronString;
		private DateTime? lastFinished;
		public CronNextForm( string cronString = null, DateTime? lastFinished = null ) {
			this.cronString = cronString;
			this.lastFinished = lastFinished;
			InitializeComponent();
		}

		private void CronNextForm_Load( object sender, EventArgs e ) {
			if( !string.IsNullOrEmpty( cronString ) ) {
				try {
					CronExpression ce = new CronExpression( cronString );
					DateTime dt = lastFinished.HasValue ? lastFinished.Value.ToUniversalTime() : DateTime.Now.ToUniversalTime();
					for( int i = 0; i < 10; i++ ) {
						DateTime? next = ce.GetNextValidTimeAfter( dt );
						if( !next.HasValue ) {
							break;
						}
						dt = next.Value;
						listView1.Items.Add( dt.ToLocalTime().ToString( "yyyy-MM-dd HH:mm:ss" ) );
					}
					listView1.AutoResizeColumns( ColumnHeaderAutoResizeStyle.ColumnContent );
				} catch {}
			}
		}
	}
}
