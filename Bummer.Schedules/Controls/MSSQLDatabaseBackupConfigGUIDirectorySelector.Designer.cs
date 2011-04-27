namespace Bummer.Schedules.Controls {
	partial class MSSQLDatabaseBackupConfigGUIDirectorySelector {
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose( bool disposing ) {
			if( disposing && (components != null) ) {
				components.Dispose();
			}
			base.Dispose( disposing );
		}

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.label1 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.btnSelectDirectory = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(3, 7);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(49, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Directory";
			// 
			// textBox1
			// 
			this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox1.Location = new System.Drawing.Point(60, 4);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(364, 20);
			this.textBox1.TabIndex = 1;
			// 
			// btnSelectDirectory
			// 
			this.btnSelectDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSelectDirectory.Location = new System.Drawing.Point(430, 2);
			this.btnSelectDirectory.Name = "btnSelectDirectory";
			this.btnSelectDirectory.Size = new System.Drawing.Size(31, 23);
			this.btnSelectDirectory.TabIndex = 2;
			this.btnSelectDirectory.Text = "...";
			this.btnSelectDirectory.UseVisualStyleBackColor = true;
			this.btnSelectDirectory.Click += new System.EventHandler(this.btnSelectDirectory_Click);
			// 
			// MSSQLDatabaseBackupConfigGUIDirectorySelector
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.btnSelectDirectory);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.label1);
			this.Name = "MSSQLDatabaseBackupConfigGUIDirectorySelector";
			this.Size = new System.Drawing.Size(464, 32);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Button btnSelectDirectory;
	}
}
