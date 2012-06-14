namespace Bummer.Client {
	partial class UpdateInfoControl {
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
			this.lblCurrentVersion = new System.Windows.Forms.Label();
			this.lblAvailableVersion = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.lblDescription = new System.Windows.Forms.Label();
			this.lblModule = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(3, 29);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(81, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Current version:";
			// 
			// lblCurrentVersion
			// 
			this.lblCurrentVersion.AutoSize = true;
			this.lblCurrentVersion.Location = new System.Drawing.Point(100, 29);
			this.lblCurrentVersion.Name = "lblCurrentVersion";
			this.lblCurrentVersion.Size = new System.Drawing.Size(81, 13);
			this.lblCurrentVersion.TabIndex = 1;
			this.lblCurrentVersion.Text = "Current version:";
			// 
			// lblAvailableVersion
			// 
			this.lblAvailableVersion.AutoSize = true;
			this.lblAvailableVersion.Location = new System.Drawing.Point(100, 47);
			this.lblAvailableVersion.Name = "lblAvailableVersion";
			this.lblAvailableVersion.Size = new System.Drawing.Size(89, 13);
			this.lblAvailableVersion.TabIndex = 3;
			this.lblAvailableVersion.Text = "available version:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(3, 47);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(90, 13);
			this.label3.TabIndex = 2;
			this.label3.Text = "Available version:";
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.AutoScroll = true;
			this.panel1.Controls.Add(this.lblDescription);
			this.panel1.Location = new System.Drawing.Point(3, 65);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(490, 100);
			this.panel1.TabIndex = 5;
			// 
			// lblDescription
			// 
			this.lblDescription.AutoSize = true;
			this.lblDescription.Location = new System.Drawing.Point(3, 10);
			this.lblDescription.Name = "lblDescription";
			this.lblDescription.Size = new System.Drawing.Size(58, 13);
			this.lblDescription.TabIndex = 5;
			this.lblDescription.Text = "description";
			// 
			// lblModule
			// 
			this.lblModule.AutoSize = true;
			this.lblModule.Location = new System.Drawing.Point(100, 10);
			this.lblModule.Name = "lblModule";
			this.lblModule.Size = new System.Drawing.Size(41, 13);
			this.lblModule.TabIndex = 7;
			this.lblModule.Text = "module";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(3, 10);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(45, 13);
			this.label4.TabIndex = 6;
			this.label4.Text = "Module:";
			// 
			// UpdateInfoControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Controls.Add(this.lblModule);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.lblAvailableVersion);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.lblCurrentVersion);
			this.Controls.Add(this.label1);
			this.Name = "UpdateInfoControl";
			this.Size = new System.Drawing.Size(496, 168);
			this.Load += new System.EventHandler(this.UpdateInfoControl_Load);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label lblCurrentVersion;
		private System.Windows.Forms.Label lblAvailableVersion;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label lblDescription;
		private System.Windows.Forms.Label lblModule;
		private System.Windows.Forms.Label label4;
	}
}
