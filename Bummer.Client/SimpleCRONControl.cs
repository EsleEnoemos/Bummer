using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Bummer.Common;
using Quartz;

namespace Bummer.Client {
	public partial class SimpleCRONControl : UserControl, ICRONControl {
		#region public string CRONString
		/// <summary>
		/// Gets the CRONString of the SimpleCRONControl
		/// </summary>
		/// <value></value>
		public string CRONString {
			get {
				return _cRONString ?? (_cRONString=BuildCronString());
			}
		}
		private string _cRONString;
		#endregion

		#region public SimpleCRONControl( string cronString )
		/// <summary>
		/// Initializes a new instance of the <b>SimpleCRONControl</b> class.
		/// </summary>
		/// <param name="cronString"></param>
		public SimpleCRONControl( string cronString ) {
			_cRONString = cronString;
			InitializeComponent();
			CronExpression ce = null;
			if( !string.IsNullOrEmpty( cronString ) ) {
				ce = new CronExpression( cronString );
			}

			Array days = Enum.GetValues( typeof( DayOfWeek ) );
			for( int i = 0; i < days.Length; i++ ) {
				DayOfWeek dow = (DayOfWeek)days.GetValue( i );
				bool ischecked = (ce != null && ce.daysOfWeek.Contains( (int)dow + 1 ));
				CheckBox cb = new CheckBox();
				cb.Tag = dow;
				cb.Checked = ischecked;
				cb.Text = dow.ToString();
				cb.Top = 20*i + 12;
				cb.Left = 5;
				cb.CheckedChanged += cb_CheckedChanged;
				groupBox1.Controls.Add( cb );
			}
			DateTime date = DateTime.Now;
			if( ce != null ) {
				DateTime n = DateTime.Now;
				if( ce.hours.Count > 0 && ce.minutes.Count > 0 ) {
					date = new DateTime( n.Year, n.Month, n.Day, (int)ce.hours[ 0 ], (int)ce.minutes[ 0 ], 0 );
				} else {
					date = n;
				}
			}
			dateTimePicker1.Value = date;
			
		}
		#endregion
		void cb_CheckedChanged( object sender, EventArgs e ) {
			OnSelectionChanged( null );
		}
		#region public SimpleCRONControl()
		/// <summary>
		/// Initializes a new instance of the <b>SimpleCRONControl</b> class.
		/// </summary>
		public SimpleCRONControl()
			: this( null ) {
		}
		#endregion

		#region public event EventHandler SelectionChanged
		/// <summary>
		/// This event is fired when the Selection property is changed.
		/// </summary>
		public event EventHandler SelectionChanged;
		#endregion
		#region protected virtual void OnSelectionChanged(EventArgs e)
		/// <summary>
		/// Notifies the listeners of the SelectionChanged event
		/// </summary>
		/// <param name="e">The argument to send to the listeners</param>
		protected virtual void OnSelectionChanged(EventArgs e) {
			_cRONString = null;
			if(SelectionChanged != null) {
				SelectionChanged(this,e);
			}
		}
		#endregion

		private void dateTimePicker1_ValueChanged( object sender, EventArgs e ) {
			OnSelectionChanged( null );
		}
		#region private string BuildCronString()
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		private string BuildCronString() {
			
			List<string> cron = new List<string>();
			cron.Add( "0" );
			cron.Add( dateTimePicker1.Value.Minute.ToString() );
			cron.Add( dateTimePicker1.Value.Hour.ToString() );
			List<DayOfWeek> days = GetCheckedDays();
			cron.Add( days.Count > 0 ? "?" : "*" );
	
			cron.Add( "*" );
			
			if( days.Count > 0 ) {
				List<string> tmp = new List<string>();
				foreach( DayOfWeek li in days ) {
					int i = (int)li;
					i++;
					tmp.Add( i.ToString() );
				}
				cron.Add( tmp.ToString( "," ) );
			} else {
				cron.Add( "?" );
			}

			return cron.ToString( " " );
		}
		#endregion
		List<DayOfWeek> GetCheckedDays() {
			List<DayOfWeek> list = new List<DayOfWeek>();
			foreach( Control c in groupBox1.Controls ) {
				if( !(c is CheckBox) ) {
					continue;
				}
				CheckBox cb = (CheckBox)c;
				if( cb.Checked ) {
					list.Add( (DayOfWeek)cb.Tag );
				}
			}
			return list;
		}
	}
}
