﻿namespace Bummer.Schedules.Controls {
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
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.tbServer = new System.Windows.Forms.TextBox();
			this.tbUsername = new System.Windows.Forms.TextBox();
			this.tbPassword = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.cbDatabase = new System.Windows.Forms.ComboBox();
			this.btnRefreshDatabases = new System.Windows.Forms.Button();
			this.label5 = new System.Windows.Forms.Label();
			this.cbSaveType = new System.Windows.Forms.ComboBox();
			this.pnlSaveAsConfig = new System.Windows.Forms.Panel();
			this.tbRemoteTempDir = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
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
			this.tbServer.Location = new System.Drawing.Point(97, 7);
			this.tbServer.Name = "tbServer";
			this.tbServer.Size = new System.Drawing.Size(224, 20);
			this.tbServer.TabIndex = 3;
			// 
			// tbUsername
			// 
			this.tbUsername.Location = new System.Drawing.Point(97, 33);
			this.tbUsername.Name = "tbUsername";
			this.tbUsername.Size = new System.Drawing.Size(224, 20);
			this.tbUsername.TabIndex = 4;
			// 
			// tbPassword
			// 
			this.tbPassword.Location = new System.Drawing.Point(97, 60);
			this.tbPassword.Name = "tbPassword";
			this.tbPassword.Size = new System.Drawing.Size(224, 20);
			this.tbPassword.TabIndex = 5;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(3, 118);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(53, 13);
			this.label4.TabIndex = 6;
			this.label4.Text = "Database";
			// 
			// cbDatabase
			// 
			this.cbDatabase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbDatabase.FormattingEnabled = true;
			this.cbDatabase.Location = new System.Drawing.Point(97, 115);
			this.cbDatabase.Name = "cbDatabase";
			this.cbDatabase.Size = new System.Drawing.Size(224, 21);
			this.cbDatabase.TabIndex = 7;
			// 
			// btnRefreshDatabases
			// 
			this.btnRefreshDatabases.Location = new System.Drawing.Point(327, 113);
			this.btnRefreshDatabases.Name = "btnRefreshDatabases";
			this.btnRefreshDatabases.Size = new System.Drawing.Size(75, 23);
			this.btnRefreshDatabases.TabIndex = 8;
			this.btnRefreshDatabases.Text = "Refresh";
			this.btnRefreshDatabases.UseVisualStyleBackColor = true;
			this.btnRefreshDatabases.Click += new System.EventHandler(this.btnRefreshDatabases_Click);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(3, 147);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(44, 13);
			this.label5.TabIndex = 9;
			this.label5.Text = "Save to";
			// 
			// cbSaveType
			// 
			this.cbSaveType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbSaveType.FormattingEnabled = true;
			this.cbSaveType.Location = new System.Drawing.Point(97, 144);
			this.cbSaveType.Name = "cbSaveType";
			this.cbSaveType.Size = new System.Drawing.Size(224, 21);
			this.cbSaveType.TabIndex = 10;
			this.cbSaveType.SelectedIndexChanged += new System.EventHandler(this.cbSaveType_SelectedIndexChanged);
			// 
			// pnlSaveAsConfig
			// 
			this.pnlSaveAsConfig.AutoScroll = true;
			this.pnlSaveAsConfig.Location = new System.Drawing.Point(6, 178);
			this.pnlSaveAsConfig.Name = "pnlSaveAsConfig";
			this.pnlSaveAsConfig.Size = new System.Drawing.Size(371, 91);
			this.pnlSaveAsConfig.TabIndex = 11;
			// 
			// tbRemoteTempDir
			// 
			this.tbRemoteTempDir.Location = new System.Drawing.Point(97, 86);
			this.tbRemoteTempDir.Name = "tbRemoteTempDir";
			this.tbRemoteTempDir.Size = new System.Drawing.Size(224, 20);
			this.tbRemoteTempDir.TabIndex = 13;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(3, 89);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(91, 13);
			this.label6.TabIndex = 12;
			this.label6.Text = "Remote TEMP-dir";
			// 
			// MSSQLDatabaseBackupConfigGUI
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.tbRemoteTempDir);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.pnlSaveAsConfig);
			this.Controls.Add(this.cbSaveType);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.btnRefreshDatabases);
			this.Controls.Add(this.cbDatabase);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.tbPassword);
			this.Controls.Add(this.tbUsername);
			this.Controls.Add(this.tbServer);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Name = "MSSQLDatabaseBackupConfigGUI";
			this.Size = new System.Drawing.Size(480, 283);
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
		private System.Windows.Forms.ComboBox cbDatabase;
		private System.Windows.Forms.Button btnRefreshDatabases;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ComboBox cbSaveType;
		private System.Windows.Forms.Panel pnlSaveAsConfig;
		private System.Windows.Forms.TextBox tbRemoteTempDir;
		private System.Windows.Forms.Label label6;

	}
}
