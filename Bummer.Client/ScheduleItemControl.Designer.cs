﻿namespace Bummer.Client {
	partial class ScheduleItemControl {
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
			this.lblName = new System.Windows.Forms.Label();
			this.lblType = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.lblLastStarted = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.lblLastFinished = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.btnRunJob = new System.Windows.Forms.Button();
			this.btnDelete = new System.Windows.Forms.Button();
			this.btnEdit = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(4, 4);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(35, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Name";
			// 
			// lblName
			// 
			this.lblName.AutoSize = true;
			this.lblName.Location = new System.Drawing.Point(86, 4);
			this.lblName.Name = "lblName";
			this.lblName.Size = new System.Drawing.Size(35, 13);
			this.lblName.TabIndex = 1;
			this.lblName.Text = "Name";
			// 
			// lblType
			// 
			this.lblType.AutoSize = true;
			this.lblType.Location = new System.Drawing.Point(86, 26);
			this.lblType.Name = "lblType";
			this.lblType.Size = new System.Drawing.Size(35, 13);
			this.lblType.TabIndex = 3;
			this.lblType.Text = "Name";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(4, 26);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(31, 13);
			this.label3.TabIndex = 2;
			this.label3.Text = "Type";
			// 
			// lblLastStarted
			// 
			this.lblLastStarted.AutoSize = true;
			this.lblLastStarted.Location = new System.Drawing.Point(86, 49);
			this.lblLastStarted.Name = "lblLastStarted";
			this.lblLastStarted.Size = new System.Drawing.Size(35, 13);
			this.lblLastStarted.TabIndex = 5;
			this.lblLastStarted.Text = "Name";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(4, 49);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(62, 13);
			this.label4.TabIndex = 4;
			this.label4.Text = "Last started";
			// 
			// lblLastFinished
			// 
			this.lblLastFinished.AutoSize = true;
			this.lblLastFinished.Location = new System.Drawing.Point(86, 71);
			this.lblLastFinished.Name = "lblLastFinished";
			this.lblLastFinished.Size = new System.Drawing.Size(35, 13);
			this.lblLastFinished.TabIndex = 7;
			this.lblLastFinished.Text = "Name";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(4, 71);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(66, 13);
			this.label6.TabIndex = 6;
			this.label6.Text = "Last finished";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(280, 4);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(55, 13);
			this.label2.TabIndex = 8;
			this.label2.Text = "Last result";
			// 
			// textBox1
			// 
			this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox1.Location = new System.Drawing.Point(283, 26);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.textBox1.Size = new System.Drawing.Size(331, 58);
			this.textBox1.TabIndex = 9;
			// 
			// btnRunJob
			// 
			this.btnRunJob.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnRunJob.Image = global::Bummer.Client.Properties.Resources.Run;
			this.btnRunJob.Location = new System.Drawing.Point(529, -1);
			this.btnRunJob.Name = "btnRunJob";
			this.btnRunJob.Size = new System.Drawing.Size(24, 24);
			this.btnRunJob.TabIndex = 12;
			this.btnRunJob.Text = "...";
			this.btnRunJob.UseVisualStyleBackColor = true;
			this.btnRunJob.Click += new System.EventHandler(this.btnRunJob_Click);
			// 
			// btnDelete
			// 
			this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnDelete.BackgroundImage = global::Bummer.Client.Properties.Resources.Delete;
			this.btnDelete.Image = global::Bummer.Client.Properties.Resources.Delete;
			this.btnDelete.Location = new System.Drawing.Point(589, -1);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(24, 24);
			this.btnDelete.TabIndex = 11;
			this.btnDelete.Text = "...";
			this.btnDelete.UseVisualStyleBackColor = true;
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			// 
			// btnEdit
			// 
			this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnEdit.Image = global::Bummer.Client.Properties.Resources.Edit;
			this.btnEdit.Location = new System.Drawing.Point(559, -1);
			this.btnEdit.Name = "btnEdit";
			this.btnEdit.Size = new System.Drawing.Size(24, 24);
			this.btnEdit.TabIndex = 10;
			this.btnEdit.Text = "...";
			this.btnEdit.UseVisualStyleBackColor = true;
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			// 
			// ScheduleItemControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.Controls.Add(this.btnRunJob);
			this.Controls.Add(this.btnDelete);
			this.Controls.Add(this.btnEdit);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.lblLastFinished);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.lblLastStarted);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.lblType);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.lblName);
			this.Controls.Add(this.label1);
			this.Name = "ScheduleItemControl";
			this.Size = new System.Drawing.Size(617, 94);
			this.Load += new System.EventHandler(this.ScheduleItemControl_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label lblName;
		private System.Windows.Forms.Label lblType;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label lblLastStarted;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label lblLastFinished;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Button btnEdit;
		private System.Windows.Forms.Button btnDelete;
		private System.Windows.Forms.Button btnRunJob;
	}
}
