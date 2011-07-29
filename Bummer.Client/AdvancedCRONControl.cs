using System;
using System.Diagnostics;
using System.Windows.Forms;
using Bummer.Common;
using Quartz;

namespace Bummer.Client {
	public partial class AdvancedCRONControl : UserControl, ICRONControl {

		public event EventHandler SelectionChanged;
		#region public string CRONString
		/// <summary>
		/// Gets the CRONString of the SimpleCRONControl
		/// </summary>
		/// <value></value>
		public string CRONString {
			get {
				return BuildCronString();
			}
		}
		#endregion

		#region public AdvancedCRONControl( string cronString )
		/// <summary>
		/// Initializes a new instance of the <b>AdvancedCRONControl</b> class.
		/// </summary>
		/// <param name="cronString"></param>
		public AdvancedCRONControl( string cronString ) {
			InitializeComponent();
			InitCron( cronString );
		}
		#endregion
		#region public AdvancedCRONControl()
		/// <summary>
		/// Initializes a new instance of the <b>AdvancedCRONControl</b> class.
		/// </summary>
		public AdvancedCRONControl()
			: this( null ) {
		}
		#endregion
		#region private void InitCron()
		/// <summary>
		/// 
		/// </summary>
		private void InitCron( string cronString ) {
			CronExpression ce;
			try {
				ce = new CronExpression( cronString );
			} catch {
				ce = new CronExpression( "* * * * * ?" );
			}
			string[] parts = ce.CronExpressionString.Split( new[] { ' ' }, StringSplitOptions.None );
			//CronExpression ce = new CronExpression( "5 * * * * ?" );)
			tbSeconds.Text = parts[ 0 ];
			tbMinutes.Text = parts[ 1 ];
			tbHours.Text = parts[ 2 ];
			tbDays.Text = parts[ 3 ];
			tbMonths.Text = parts[ 4 ];
			tbDates.Text = parts[ 5 ];
		}
		#endregion
		#region private string BuildCronString()
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		private string BuildCronString() {
			return string.Format( "{0} {1} {2} {3} {4} {5}",
				tbSeconds.Text.IfNotNullElse( "*" ),
				tbMinutes.Text.IfNotNullElse( "*" ),
				tbHours.Text.IfNotNullElse( "*" ),
				tbDays.Text.IfNotNullElse( "*" ),
				tbMonths.Text.IfNotNullElse( "*" ),
				tbDates.Text.IfNotNullElse( "?" ) );
		}
		#endregion

		#region private void CronPartChanged( object sender, EventArgs e )
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void CronPartChanged( object sender, EventArgs e ) {
			if( SelectionChanged != null ) {
				SelectionChanged( this, e );
			}
		}
		#endregion
		#region private void btnCronTest_Click( object sender, EventArgs e )
		/// <summary>
		/// This method is called when the btnCronTest's Click event has been fired.
		/// </summary>
		/// <param name="sender">The <see cref="object"/> that fired the event.</param>
		/// <param name="e">The <see cref="EventArgs"/> of the event.</param>
		private void btnCronTest_Click( object sender, EventArgs e ) {
			(new CronNextForm( BuildCronString() )).ShowDialog( this );
		}
		#endregion
		#region private void linkLabel1_LinkClicked( object sender, LinkLabelLinkClickedEventArgs e )
		/// <summary>
		/// This method is called when the linkLabel1's LinkClicked event has been fired.
		/// </summary>
		/// <param name="sender">The <see cref="object"/> that fired the event.</param>
		/// <param name="e">The <see cref="LinkLabelLinkClickedEventArgs"/> of the event.</param>
		private void linkLabel1_LinkClicked( object sender, LinkLabelLinkClickedEventArgs e ) {
			Process.Start( "http://quartznet.sourceforge.net/tutorial/lesson_6.html" );
		}
		#endregion
	}
}
