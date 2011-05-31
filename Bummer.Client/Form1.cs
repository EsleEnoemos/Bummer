using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;
using System.Xml.Serialization;
using Bummer.Common;

namespace Bummer.Client {
	public partial class Form1 : Form {
		internal static Form1 Instance;
		public Form1() {
			Instance = this;
			InitializeComponent();
		}

		private void Form1_Load( object sender, EventArgs e ) {
			RefreshJobs();
		}
		#region internal void RefreshJobs()
		/// <summary>
		/// 
		/// </summary>
		internal void RefreshJobs() {
			panel1.Controls.Clear();
			List<BackupScheduleWrapper> jobs = Configuration.GetSchedules();
			if( jobs.Count == 0 ) {
				panel1.Controls.Add( new Label {
					Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleCenter, Text = "No jobs defined"
				} );
				return;
			}
			ScheduleItemControl last = null;
			foreach( BackupScheduleWrapper job in jobs ) {
				ScheduleItemControl si = new ScheduleItemControl( job );
				last = si;
				si.Dock = DockStyle.Top;
				panel1.Controls.Add( si );
			}
			if( last != null ) {
				last.Focus();
				last.Select();
			}
		}
		#endregion

		#region private void addScheduleToolStripMenuItem_Click( object sender, System.EventArgs e )
		/// <summary>
		/// This method is called when the addScheduleToolStripMenuItem's Click event has been fired.
		/// </summary>
		/// <param name="sender">The <see cref="object"/> that fired the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> of the event.</param>
		private void addScheduleToolStripMenuItem_Click( object sender, EventArgs e ) {
			ScheduleForm sf = new ScheduleForm();
			if( sf.ShowDialog( this ) == DialogResult.OK ) {
				try {
					sf.Job.Persist();
					RefreshJobs();
				} catch( Exception ex ) {
					MessageBox.Show( "Error saving schedule: {0}{1}".FillBlanks( Environment.NewLine, ex.Message ) );
					return;
				}
			}
		}
		#endregion

		private void aboutToolStripMenuItem_Click( object sender, EventArgs e ) {
			new About().ShowDialog( this );
		}

		private void exitToolStripMenuItem_Click( object sender, EventArgs e ) {
			Close();
		}

		private void checkForUpdatesToolStripMenuItem_Click( object sender, EventArgs e ) {
			//List<Module> mods = new List<Module>();
			//mods.Add( new Module() {Assembly="myass", Filename="myfile", Name="myname",Type="mytype",Version="myver"} );
			XmlSerializer ser = new XmlSerializer( typeof( ModuleList ) );
			//StringWriter sw = new StringWriter();
			//ser.Serialize( sw, mods );
			WebRequest wr = WebRequest.Create( "http://products.someone-else.com/Bummer/package.xml" );
			try {
				using( WebResponse res = wr.GetResponse() ) {
					if( res == null ) {
						return;
					}
					ModuleList modules = ModuleList.Load( res.GetResponseStream() );
					//Stream s = res.GetResponseStream();
					//if( s == null ) {
					//    return;
					//}
					//StreamReader sr = new StreamReader( s );
					//string text = sr.ReadToEnd();
					//StringReader ss = new StringReader( text );
					//ModuleList list = (ModuleList)ser.Deserialize( ss );

				}
			} catch( WebException ex ) {
				MessageBox.Show( "Error checking for updates: {0}".FillBlanks( ex.Message ) );
				if( ex.Response != null ) {
					ex.Response.Close();
				}
			} catch( Exception ex ) {
				MessageBox.Show( "Error checking for updates: {0}".FillBlanks( ex.Message ) );
			}
			MessageBox.Show( "Still working on this..." );
		}

		[XmlType( TypeName = "Modules" )]
		public class ModuleList : List<Module> {
			#region private static XmlSerializer Serializer
			/// <summary>
			/// Gets the Serializer of the ModuleList
			/// </summary>
			/// <value></value>
			private static XmlSerializer Serializer {
				get {
					return _serializer ?? (_serializer = new XmlSerializer( typeof( ModuleList ) ));
				}
			}
			private static XmlSerializer _serializer;
			#endregion
			public static ModuleList Load( Stream s ) {
				try {
					return (ModuleList)Serializer.Deserialize( s );
				} catch {
					
				}
				return null;
			}
		}
		public class Module {
			[XmlAttribute("type")]
			public string Type;
			[XmlAttribute("name")]
			public string Name;
			[XmlAttribute("assembly")]
			public string Assembly;
			[XmlAttribute("filename")]
			public string Filename;
			[XmlAttribute("version")]
			public string Version;
			[XmlAttribute("url")]
			public string DownloadURL;
		}
	}
}
