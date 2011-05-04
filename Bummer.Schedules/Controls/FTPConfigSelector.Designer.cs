namespace Bummer.Schedules.Controls {
	partial class FTPConfigSelector {
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
			this.components = new System.ComponentModel.Container();
			this.label2 = new System.Windows.Forms.Label();
			this.tbServer = new System.Windows.Forms.TextBox();
			this.tbUsername = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.tbPassword = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.tbRemoteDir = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.tbLocalTemp = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.btnBrowseForLocalTempDirectory = new System.Windows.Forms.Button();
			this.tbPort = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.SuspendLayout();
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(7, 12);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(38, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "Server";
			// 
			// tbServer
			// 
			this.tbServer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbServer.Location = new System.Drawing.Point(122, 12);
			this.tbServer.Name = "tbServer";
			this.tbServer.Size = new System.Drawing.Size(235, 20);
			this.tbServer.TabIndex = 0;
			// 
			// tbUsername
			// 
			this.tbUsername.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbUsername.Location = new System.Drawing.Point(122, 64);
			this.tbUsername.Name = "tbUsername";
			this.tbUsername.Size = new System.Drawing.Size(235, 20);
			this.tbUsername.TabIndex = 2;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(7, 64);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(55, 13);
			this.label3.TabIndex = 3;
			this.label3.Text = "Username";
			// 
			// tbPassword
			// 
			this.tbPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbPassword.Location = new System.Drawing.Point(122, 90);
			this.tbPassword.Name = "tbPassword";
			this.tbPassword.Size = new System.Drawing.Size(235, 20);
			this.tbPassword.TabIndex = 3;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(7, 90);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(53, 13);
			this.label4.TabIndex = 5;
			this.label4.Text = "Password";
			// 
			// tbRemoteDir
			// 
			this.tbRemoteDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbRemoteDir.Location = new System.Drawing.Point(122, 116);
			this.tbRemoteDir.Name = "tbRemoteDir";
			this.tbRemoteDir.Size = new System.Drawing.Size(235, 20);
			this.tbRemoteDir.TabIndex = 4;
			this.toolTip1.SetToolTip(this.tbRemoteDir, "Make sure that the remote directory exists.\r\nIf not, uploading the file will fail" +
        "");
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(7, 116);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(87, 13);
			this.label5.TabIndex = 7;
			this.label5.Text = "Remote directory";
			// 
			// tbLocalTemp
			// 
			this.tbLocalTemp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbLocalTemp.Location = new System.Drawing.Point(122, 142);
			this.tbLocalTemp.Name = "tbLocalTemp";
			this.tbLocalTemp.Size = new System.Drawing.Size(200, 20);
			this.tbLocalTemp.TabIndex = 5;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(7, 142);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(109, 13);
			this.label6.TabIndex = 9;
			this.label6.Text = "Local TEMP-directory";
			// 
			// btnBrowseForLocalTempDirectory
			// 
			this.btnBrowseForLocalTempDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnBrowseForLocalTempDirectory.Location = new System.Drawing.Point(329, 142);
			this.btnBrowseForLocalTempDirectory.Name = "btnBrowseForLocalTempDirectory";
			this.btnBrowseForLocalTempDirectory.Size = new System.Drawing.Size(28, 23);
			this.btnBrowseForLocalTempDirectory.TabIndex = 6;
			this.btnBrowseForLocalTempDirectory.Text = "...";
			this.btnBrowseForLocalTempDirectory.UseVisualStyleBackColor = true;
			this.btnBrowseForLocalTempDirectory.Click += new System.EventHandler(this.btnBrowseForLocalTempDirectory_Click);
			// 
			// tbPort
			// 
			this.tbPort.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbPort.Location = new System.Drawing.Point(122, 38);
			this.tbPort.Name = "tbPort";
			this.tbPort.Size = new System.Drawing.Size(235, 20);
			this.tbPort.TabIndex = 1;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(7, 38);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(26, 13);
			this.label7.TabIndex = 12;
			this.label7.Text = "Port";
			// 
			// toolTip1
			// 
			this.toolTip1.AutoPopDelay = 5000;
			this.toolTip1.InitialDelay = 50;
			this.toolTip1.IsBalloon = true;
			this.toolTip1.ReshowDelay = 10;
			this.toolTip1.ShowAlways = true;
			this.toolTip1.StripAmpersands = true;
			this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
			// 
			// FTPConfigSelector
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.tbPort);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.btnBrowseForLocalTempDirectory);
			this.Controls.Add(this.tbLocalTemp);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.tbRemoteDir);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.tbPassword);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.tbUsername);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.tbServer);
			this.Controls.Add(this.label2);
			this.Name = "FTPConfigSelector";
			this.Size = new System.Drawing.Size(376, 175);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox tbServer;
		private System.Windows.Forms.TextBox tbUsername;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox tbPassword;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox tbRemoteDir;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox tbLocalTemp;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Button btnBrowseForLocalTempDirectory;
		private System.Windows.Forms.TextBox tbPort;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.ToolTip toolTip1;
	}
}
