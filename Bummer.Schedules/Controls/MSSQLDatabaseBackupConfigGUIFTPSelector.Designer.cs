namespace Bummer.Schedules.Controls {
	partial class MSSQLDatabaseBackupConfigGUIFTPSelector {
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
			this.tbServer = new System.Windows.Forms.TextBox();
			this.tbUsername = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.tbPassword = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.tbRemoteDir = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(4, 4);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(30, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "FTP";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(7, 21);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(38, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "Server";
			// 
			// tbServer
			// 
			this.tbServer.Location = new System.Drawing.Point(100, 18);
			this.tbServer.Name = "tbServer";
			this.tbServer.Size = new System.Drawing.Size(240, 20);
			this.tbServer.TabIndex = 2;
			// 
			// tbUsername
			// 
			this.tbUsername.Location = new System.Drawing.Point(100, 44);
			this.tbUsername.Name = "tbUsername";
			this.tbUsername.Size = new System.Drawing.Size(240, 20);
			this.tbUsername.TabIndex = 4;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(7, 47);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(55, 13);
			this.label3.TabIndex = 3;
			this.label3.Text = "Username";
			// 
			// tbPassword
			// 
			this.tbPassword.Location = new System.Drawing.Point(100, 70);
			this.tbPassword.Name = "tbPassword";
			this.tbPassword.Size = new System.Drawing.Size(240, 20);
			this.tbPassword.TabIndex = 6;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(7, 73);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(53, 13);
			this.label4.TabIndex = 5;
			this.label4.Text = "Password";
			// 
			// tbRemoteDir
			// 
			this.tbRemoteDir.Location = new System.Drawing.Point(100, 96);
			this.tbRemoteDir.Name = "tbRemoteDir";
			this.tbRemoteDir.Size = new System.Drawing.Size(240, 20);
			this.tbRemoteDir.TabIndex = 8;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(7, 99);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(87, 13);
			this.label5.TabIndex = 7;
			this.label5.Text = "Remote directory";
			// 
			// MSSQLDatabaseBackupConfigGUIFTPSelector
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.tbRemoteDir);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.tbPassword);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.tbUsername);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.tbServer);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Name = "MSSQLDatabaseBackupConfigGUIFTPSelector";
			this.Size = new System.Drawing.Size(376, 131);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox tbServer;
		private System.Windows.Forms.TextBox tbUsername;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox tbPassword;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox tbRemoteDir;
		private System.Windows.Forms.Label label5;
	}
}
