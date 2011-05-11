namespace Bummer.Schedules.Controls {
	partial class MSSQLDatabaseBackupConfigGUI {
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
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.tbServer = new System.Windows.Forms.TextBox();
			this.tbUsername = new System.Windows.Forms.TextBox();
			this.tbPassword = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.btnRefreshDatabases = new System.Windows.Forms.Button();
			this.label5 = new System.Windows.Forms.Label();
			this.cbSaveType = new System.Windows.Forms.ComboBox();
			this.pnlSaveAsConfig = new System.Windows.Forms.Panel();
			this.tbRemoteTempDir = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.cblDatabases = new System.Windows.Forms.CheckedListBox();
			this.label7 = new System.Windows.Forms.Label();
			this.cbCompress = new System.Windows.Forms.CheckBox();
			this.cbAddDateToFilename = new System.Windows.Forms.CheckBox();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.cbIsLocalServer = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(3, 10);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(38, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Server";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(3, 35);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(55, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "Username";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(3, 63);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(53, 13);
			this.label3.TabIndex = 2;
			this.label3.Text = "Password";
			// 
			// tbServer
			// 
			this.tbServer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbServer.Location = new System.Drawing.Point(97, 7);
			this.tbServer.Name = "tbServer";
			this.tbServer.Size = new System.Drawing.Size(270, 20);
			this.tbServer.TabIndex = 0;
			// 
			// tbUsername
			// 
			this.tbUsername.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbUsername.Location = new System.Drawing.Point(97, 33);
			this.tbUsername.Name = "tbUsername";
			this.tbUsername.Size = new System.Drawing.Size(270, 20);
			this.tbUsername.TabIndex = 1;
			// 
			// tbPassword
			// 
			this.tbPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbPassword.Location = new System.Drawing.Point(97, 60);
			this.tbPassword.Name = "tbPassword";
			this.tbPassword.Size = new System.Drawing.Size(270, 20);
			this.tbPassword.TabIndex = 2;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(3, 200);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(58, 13);
			this.label4.TabIndex = 6;
			this.label4.Text = "Databases";
			// 
			// btnRefreshDatabases
			// 
			this.btnRefreshDatabases.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnRefreshDatabases.Location = new System.Drawing.Point(373, 195);
			this.btnRefreshDatabases.Name = "btnRefreshDatabases";
			this.btnRefreshDatabases.Size = new System.Drawing.Size(75, 23);
			this.btnRefreshDatabases.TabIndex = 7;
			this.btnRefreshDatabases.Text = "Refresh";
			this.btnRefreshDatabases.UseVisualStyleBackColor = true;
			this.btnRefreshDatabases.Click += new System.EventHandler(this.btnRefreshDatabases_Click);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(3, 353);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(44, 13);
			this.label5.TabIndex = 9;
			this.label5.Text = "Save to";
			// 
			// cbSaveType
			// 
			this.cbSaveType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cbSaveType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbSaveType.FormattingEnabled = true;
			this.cbSaveType.Location = new System.Drawing.Point(97, 340);
			this.cbSaveType.Name = "cbSaveType";
			this.cbSaveType.Size = new System.Drawing.Size(270, 21);
			this.cbSaveType.TabIndex = 8;
			this.cbSaveType.SelectedIndexChanged += new System.EventHandler(this.cbSaveType_SelectedIndexChanged);
			// 
			// pnlSaveAsConfig
			// 
			this.pnlSaveAsConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.pnlSaveAsConfig.AutoScroll = true;
			this.pnlSaveAsConfig.AutoSize = true;
			this.pnlSaveAsConfig.Location = new System.Drawing.Point(6, 369);
			this.pnlSaveAsConfig.Name = "pnlSaveAsConfig";
			this.pnlSaveAsConfig.Size = new System.Drawing.Size(442, 189);
			this.pnlSaveAsConfig.TabIndex = 9;
			this.pnlSaveAsConfig.TabStop = true;
			// 
			// tbRemoteTempDir
			// 
			this.tbRemoteTempDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbRemoteTempDir.Location = new System.Drawing.Point(97, 119);
			this.tbRemoteTempDir.Name = "tbRemoteTempDir";
			this.tbRemoteTempDir.Size = new System.Drawing.Size(270, 20);
			this.tbRemoteTempDir.TabIndex = 3;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(3, 122);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(91, 13);
			this.label6.TabIndex = 12;
			this.label6.Text = "Remote TEMP-dir";
			// 
			// cblDatabases
			// 
			this.cblDatabases.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cblDatabases.FormattingEnabled = true;
			this.cblDatabases.Location = new System.Drawing.Point(97, 195);
			this.cblDatabases.Name = "cblDatabases";
			this.cblDatabases.Size = new System.Drawing.Size(270, 139);
			this.cblDatabases.TabIndex = 6;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label7.Location = new System.Drawing.Point(3, 224);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(94, 52);
			this.label7.TabIndex = 15;
			this.label7.Text = "Select none to\r\nbackup all\r\ndatabases except \r\nfor system db\'s";
			// 
			// cbCompress
			// 
			this.cbCompress.AutoSize = true;
			this.cbCompress.Location = new System.Drawing.Point(6, 149);
			this.cbCompress.Name = "cbCompress";
			this.cbCompress.Size = new System.Drawing.Size(115, 17);
			this.cbCompress.TabIndex = 4;
			this.cbCompress.Text = "Compress files (zip)";
			this.cbCompress.UseVisualStyleBackColor = true;
			// 
			// cbAddDateToFilename
			// 
			this.cbAddDateToFilename.AutoSize = true;
			this.cbAddDateToFilename.Location = new System.Drawing.Point(6, 172);
			this.cbAddDateToFilename.Name = "cbAddDateToFilename";
			this.cbAddDateToFilename.Size = new System.Drawing.Size(123, 17);
			this.cbAddDateToFilename.TabIndex = 5;
			this.cbAddDateToFilename.Text = "Add date to filename";
			this.toolTip1.SetToolTip(this.cbAddDateToFilename, "Date and time will be added to the filename.\r\nIf this is selected, each time a ba" +
        "ckup is made it will produce a new file.");
			this.cbAddDateToFilename.UseVisualStyleBackColor = true;
			// 
			// toolTip1
			// 
			this.toolTip1.AutoPopDelay = 5000;
			this.toolTip1.InitialDelay = 50;
			this.toolTip1.IsBalloon = true;
			this.toolTip1.ReshowDelay = 10;
			this.toolTip1.ShowAlways = true;
			this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
			// 
			// cbIsLocalServer
			// 
			this.cbIsLocalServer.AutoSize = true;
			this.cbIsLocalServer.Location = new System.Drawing.Point(6, 96);
			this.cbIsLocalServer.Name = "cbIsLocalServer";
			this.cbIsLocalServer.Size = new System.Drawing.Size(99, 17);
			this.cbIsLocalServer.TabIndex = 16;
			this.cbIsLocalServer.Text = "Local database";
			this.toolTip1.SetToolTip(this.cbIsLocalServer, "Check this if the sql-server is located on the local computer.\r\nThis will speed u" +
        "p the backup process");
			this.cbIsLocalServer.UseVisualStyleBackColor = true;
			this.cbIsLocalServer.CheckedChanged += new System.EventHandler(this.cbIsLocalServer_CheckedChanged);
			// 
			// MSSQLDatabaseBackupConfigGUI
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.cbIsLocalServer);
			this.Controls.Add(this.cbAddDateToFilename);
			this.Controls.Add(this.cbCompress);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.cblDatabases);
			this.Controls.Add(this.tbRemoteTempDir);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.pnlSaveAsConfig);
			this.Controls.Add(this.cbSaveType);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.btnRefreshDatabases);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.tbPassword);
			this.Controls.Add(this.tbUsername);
			this.Controls.Add(this.tbServer);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Name = "MSSQLDatabaseBackupConfigGUI";
			this.Size = new System.Drawing.Size(465, 574);
			this.Load += new System.EventHandler(this.MSSQLDatabaseBackupConfigGUI_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox tbServer;
		private System.Windows.Forms.TextBox tbUsername;
		private System.Windows.Forms.TextBox tbPassword;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button btnRefreshDatabases;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ComboBox cbSaveType;
		private System.Windows.Forms.Panel pnlSaveAsConfig;
		private System.Windows.Forms.TextBox tbRemoteTempDir;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.CheckedListBox cblDatabases;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.CheckBox cbCompress;
		private System.Windows.Forms.CheckBox cbAddDateToFilename;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.CheckBox cbIsLocalServer;

	}
}
