namespace Bummer.Client {
	partial class SettingsDialog {
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

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.pnlAvailableUpdates = new System.Windows.Forms.Panel();
			this.btnCheckForUpdates = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnApplyUpdates = new System.Windows.Forms.Button();
			this.tabControl1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControl1
			// 
			this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Location = new System.Drawing.Point(3, 0);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(350, 287);
			this.tabControl1.TabIndex = 0;
			// 
			// tabPage1
			// 
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(342, 261);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Settings";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.btnApplyUpdates);
			this.tabPage2.Controls.Add(this.pnlAvailableUpdates);
			this.tabPage2.Controls.Add(this.btnCheckForUpdates);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(342, 261);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Updates";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// pnlAvailableUpdates
			// 
			this.pnlAvailableUpdates.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.pnlAvailableUpdates.AutoScroll = true;
			this.pnlAvailableUpdates.Location = new System.Drawing.Point(3, 3);
			this.pnlAvailableUpdates.Name = "pnlAvailableUpdates";
			this.pnlAvailableUpdates.Size = new System.Drawing.Size(336, 223);
			this.pnlAvailableUpdates.TabIndex = 1;
			// 
			// btnCheckForUpdates
			// 
			this.btnCheckForUpdates.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCheckForUpdates.Location = new System.Drawing.Point(204, 232);
			this.btnCheckForUpdates.Name = "btnCheckForUpdates";
			this.btnCheckForUpdates.Size = new System.Drawing.Size(129, 23);
			this.btnCheckForUpdates.TabIndex = 0;
			this.btnCheckForUpdates.Text = "Check for updates";
			this.btnCheckForUpdates.UseVisualStyleBackColor = true;
			this.btnCheckForUpdates.Click += new System.EventHandler(this.btnCheckForUpdates_Click);
			// 
			// btnOK
			// 
			this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOK.Location = new System.Drawing.Point(193, 293);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 23);
			this.btnOK.TabIndex = 1;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(274, 293);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 2;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// btnApplyUpdates
			// 
			this.btnApplyUpdates.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnApplyUpdates.Location = new System.Drawing.Point(6, 232);
			this.btnApplyUpdates.Name = "btnApplyUpdates";
			this.btnApplyUpdates.Size = new System.Drawing.Size(192, 23);
			this.btnApplyUpdates.TabIndex = 2;
			this.btnApplyUpdates.Text = "Download and apply updates";
			this.btnApplyUpdates.UseVisualStyleBackColor = true;
			this.btnApplyUpdates.Visible = false;
			this.btnApplyUpdates.Click += new System.EventHandler(this.btnApplyUpdates_Click);
			// 
			// SettingsDialog
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(352, 319);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.tabControl1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.Name = "SettingsDialog";
			this.Text = "Settings";
			this.tabControl1.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnCheckForUpdates;
		private System.Windows.Forms.Panel pnlAvailableUpdates;
		private System.Windows.Forms.Button btnApplyUpdates;
	}
}