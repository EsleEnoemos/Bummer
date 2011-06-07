using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using Bummer.Common;
using Quartz;

namespace Bummer.Client {
	public partial class AdvancedCRONControl : UserControl, ICRONControl {

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

		#region public AdvancedCRONControl( string cronString )
		/// <summary>
		/// Initializes a new instance of the <b>AdvancedCRONControl</b> class.
		/// </summary>
		/// <param name="cronString"></param>
		public AdvancedCRONControl( string cronString ) {
			_cRONString = cronString;
			InitializeComponent();
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
		private void InitCron() {
			CronExpression ce;
			try {
				ce = new CronExpression( CRONString );
			} catch {
				ce = new CronExpression( "* * * * * ?" );
			}
			//CronExpression ce = new CronExpression( "5 * * * * ?" );
			for( int i = 0; i < 60; i++ ) {
				ListViewItem li = lvNotSelectedSeconds.Items.Add( i < 10 ? "0{0}".FillBlanks( i ) : i.ToString() );
				li.Tag = i.ToString();
				if( ce.seconds.Count < 61 && ce.seconds.Contains( i ) ) {
					li.Selected = true;
				}
			}
			if( lvNotSelectedSeconds.SelectedItems.Count > 0 ) {
				MoveListViewItems( lvNotSelectedSeconds, lvSelectedSeconds );
			}
			for( int i = 0; i < 60; i++ ) {
				ListViewItem li = lvNotSelectedMinutes.Items.Add( i < 10 ? "0{0}".FillBlanks( i ) : i.ToString() );
				li.Tag = i.ToString();
				if( ce.minutes.Count < 61 && ce.minutes.Contains( i ) ) {
					li.Selected = true;
				}
			}
			if( lvNotSelectedMinutes.SelectedItems.Count > 0 ) {
				MoveListViewItems( lvNotSelectedMinutes, lvSelectedMinutes );
			}
			for( int i = 0; i < 24; i++ ) {
				ListViewItem li = lvNotSelectedHours.Items.Add( i < 10 ? "0{0}".FillBlanks( i ) : i.ToString() );
				li.Tag = i.ToString();
				if( ce.hours.Count < 25 && ce.hours.Contains( i ) ) {
					li.Selected = true;
				}
			}
			if( lvNotSelectedHours.SelectedItems.Count > 0 ) {
				MoveListViewItems( lvNotSelectedHours, lvSelectedHours );
			}
			for( int i = 1; i < 32; i++ ) {
				ListViewItem li = lvNotSelectedDates.Items.Add( i < 10 ? "0{0}".FillBlanks( i ) : i.ToString() );
				li.Tag = i.ToString();
				if( ce.daysOfMonth.Count < 32 && ce.daysOfMonth.Contains( i ) ) {
					li.Selected = true;
				}
			}
			if( lvNotSelectedDates.SelectedItems.Count > 0 ) {
				MoveListViewItems( lvNotSelectedDates, lvSelectedDates );
			}
			Array arr = Enum.GetValues( typeof( DayOfWeek ) );
			for( int i = 0; i < arr.Length; i++ ) {
				DayOfWeek d = (DayOfWeek)arr.GetValue( i );
				int iv = (int)d + 1;
				ListViewItem li = lvNotSelectedDays.Items.Add( d.ToString() );
				li.Tag = iv.ToString();
				if( ce.daysOfWeek.Count > 0 && ce.daysOfWeek.Contains( iv ) ) {
					li.Selected = true;
				}
			}
			if( lvNotSelectedDays.SelectedItems.Count > 0 ) {
				MoveListViewItems( lvNotSelectedDays, lvSelectedDays );
			}
			lvNotSelectedDays.ListViewItemSorter = new NumberLIComparer();
			lvNotSelectedDays.Sort();

			lvNotSelectedMonths.Items.Add( "January" ).Tag = 1.ToString();
			lvNotSelectedMonths.Items.Add( "February" ).Tag = 2.ToString();
			lvNotSelectedMonths.Items.Add( "Mars" ).Tag = 3.ToString();
			lvNotSelectedMonths.Items.Add( "April" ).Tag = 4.ToString();
			lvNotSelectedMonths.Items.Add( "May" ).Tag = 5.ToString();
			lvNotSelectedMonths.Items.Add( "June" ).Tag = 6.ToString();
			lvNotSelectedMonths.Items.Add( "July" ).Tag = 7.ToString();
			lvNotSelectedMonths.Items.Add( "August" ).Tag = 8.ToString();
			lvNotSelectedMonths.Items.Add( "September" ).Tag = 9.ToString();
			lvNotSelectedMonths.Items.Add( "October" ).Tag = 10.ToString();
			lvNotSelectedMonths.Items.Add( "November" ).Tag = 11.ToString();
			lvNotSelectedMonths.Items.Add( "December" ).Tag = 12.ToString();
			if( ce.months.Count < 13 ) {
				for( int i = 0; i < lvNotSelectedMonths.Items.Count; i++ ) {
					ListViewItem li = lvNotSelectedMonths.Items[ i ];
					int m = int.Parse( li.Tag.ToString() );
					if( ce.months.Contains( m ) ) {
						li.Selected = true;
					}
				}
				MoveListViewItems( lvNotSelectedMonths, lvSelectedMonths );
			}
			lvNotSelectedMonths.ListViewItemSorter = new NumberLIComparer();
			lvNotSelectedMonths.Sort();
			for( int i = 0; i < Controls.Count; i++ ) {
				Control c = Controls[ i ];
				if( !(c is ListView) ) {
					continue;
				}
				ListView lv = (ListView)c;
				lv.Columns[ 0 ].Width = 150;
			}

		}
		#endregion
		#region private void MoveItemsClick( object sender, EventArgs e )
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void MoveItemsClick( object sender, EventArgs e ) {
			Button btn = sender as Button;
			if( btn == null ) {
				return;
			}
			if( btn.Tag == null ) {
				return;
			}
			string[] lists = btn.Tag.ToString().Split( '|' );
			if( lists.Length != 2 ) {
				return;
			}
			ListView from = Controls[ lists[ 0 ] ] as ListView;
			ListView to = Controls[ lists[ 1 ] ] as ListView;
			MoveListViewItems( from, to );
			OnSelectionChanged( new EventArgs() );
		}
		#endregion
		#region private void MoveListViewItems( ListView from, ListView to )
		/// <summary>
		/// 
		/// </summary>
		/// <param name="from"></param>
		/// <param name="to"></param>
		private void MoveListViewItems( ListView from, ListView to ) {
			to.ListViewItemSorter = null;
			while( from.SelectedItems.Count > 0 ) {
				ListViewItem li = from.SelectedItems[ 0 ];
				ListViewItem newLi = to.Items.Add( li.Text ); //.Tag = li.Tag;
				newLi.Tag = li.Tag;
				from.Items.RemoveAt( li.Index );
			}
			to.ListViewItemSorter = new NumberLIComparer();
			to.Sort();
		}
		#endregion
		#region private string BuildCronString()
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		private string BuildCronString() {
			List<string> cron = new List<string>();
			if( lvSelectedSeconds.Items.Count > 0 ) {
				List<string> tmp = new List<string>();
				foreach( ListViewItem li in lvSelectedSeconds.Items ) {
					tmp.Add( li.Tag.ToString() );
				}
				cron.Add( tmp.ToString( "," ) );
			} else {
				cron.Add( "*" );
			}
			if( lvSelectedMinutes.Items.Count > 0 ) {
				List<string> tmp = new List<string>();
				foreach( ListViewItem li in lvSelectedMinutes.Items ) {
					tmp.Add( li.Tag.ToString() );
				}
				cron.Add( tmp.ToString( "," ) );
			} else {
				cron.Add( "*" );
			}
			if( lvSelectedHours.Items.Count > 0 ) {
				List<string> tmp = new List<string>();
				foreach( ListViewItem li in lvSelectedHours.Items ) {
					tmp.Add( li.Tag.ToString() );
				}
				cron.Add( tmp.ToString( "," ) );
			} else {
				cron.Add( "*" );
			}
			if( lvSelectedDates.Items.Count > 0 ) {
				List<string> tmp = new List<string>();
				foreach( ListViewItem li in lvSelectedDates.Items ) {
					tmp.Add( li.Tag.ToString() );
				}
				cron.Add( tmp.ToString( "," ) );
			} else {
				cron.Add( lvSelectedDays.Items.Count > 0 ? "?" : "*" );
			}

			if( lvSelectedMonths.Items.Count > 0 ) {
				List<string> tmp = new List<string>();
				foreach( ListViewItem li in lvSelectedMonths.Items ) {
					tmp.Add( li.Tag.ToString() );
				}
				cron.Add( tmp.ToString( "," ) );
			} else {
				cron.Add( "*" );
			}
			if( lvSelectedDays.Items.Count > 0 ) {
				List<string> tmp = new List<string>();
				foreach( ListViewItem li in lvSelectedDays.Items ) {
					tmp.Add( li.Tag.ToString() );
				}
				cron.Add( tmp.ToString( "," ) );
			} else {
				cron.Add( "?" );
			}
			return cron.ToString( " " );
		}
		#endregion
		private class NumberLIComparer : IComparer {
			#region public int Compare( object x, object y )
			/// <summary>
			/// Compares two objects and returns a value indicating whether one is less than,
			/// equal to, or greater than the other.
			/// </summary>
			/// <param name="x">The first object to compare.</param>
			/// <param name="y">The second object to compare.</param>
			/// <returns>A 32-bit signed integer that indicates the relative order 
			/// of the objects being compared. The return value has these meanings: 
			/// <table>
			/// 		<tr><th>Value</th><th>Meaning</th></tr>
			/// 		<tr><td>Less than zero</td><td>x less than y.</td></tr>
			/// 		<tr><td>Zero</td><td>x is equal to y.</td></tr>
			/// 		<tr><td>Greater than zero</td><td>x is greater than y.</td></tr>
			/// 	</table>
			/// </returns>
			public int Compare( object x, object y ) {
				if( x != null && y != null && x is ListViewItem && y is ListViewItem ) {
					return Compare( (ListViewItem)x, (ListViewItem)y );
				}
				return 0;
			}
			#endregion
			private int Compare( ListViewItem x, ListViewItem y ) {
				int xi;
				int.TryParse( x.Tag as string, out xi );
				int yi;
				int.TryParse( y.Tag as string, out yi );
				return xi.CompareTo( yi );
			}
		}

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
		protected virtual void OnSelectionChanged( EventArgs e ) {
			_cRONString = null;
			if( SelectionChanged != null ) {
				SelectionChanged( this, e );
			}
		}
		#endregion

		private void AdvancedCRONControl_Load( object sender, EventArgs e ) {
			InitCron();
		}

	}
}
