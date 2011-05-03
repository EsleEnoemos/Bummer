namespace Bummer.Client {
	partial class ScheduleForm {
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
			this.label1 = new System.Windows.Forms.Label();
			this.tbName = new System.Windows.Forms.TextBox();
			this.pnlJobConfig = new System.Windows.Forms.Panel();
			this.cbJobType = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.cbIntervalType = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.nuInterval = new System.Windows.Forms.NumericUpDown();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.dpStartFrom = new System.Windows.Forms.DateTimePicker();
			this.dpStartTo = new System.Windows.Forms.DateTimePicker();
			this.btnSave = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.tbDescription = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.nuInterval)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(13, 13);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(35, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Name";
			// 
			// tbName
			// 
			this.tbName.Location = new System.Drawing.Point(84, 10);
			this.tbName.Name = "tbName";
			this.tbName.Size = new System.Drawing.Size(288, 20);
			this.tbName.TabIndex = 1;
			// 
			// pnlJobConfig
			// 
			this.pnlJobConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.pnlJobConfig.AutoScroll = true;
			this.pnlJobConfig.BackColor = System.Drawing.SystemColors.Window;
			this.pnlJobConfig.Location = new System.Drawing.Point(16, 202);
			this.pnlJobConfig.Name = "pnlJobConfig";
			this.pnlJobConfig.Size = new System.Drawing.Size(592, 188);
			this.pnlJobConfig.TabIndex = 2;
			// 
			// cbJobType
			// 
			this.cbJobType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbJobType.FormattingEnabled = true;
			this.cbJobType.Location = new System.Drawing.Point(84, 41);
			this.cbJobType.Name = "cbJobType";
			this.cbJobType.Size = new System.Drawing.Size(214, 21);
			this.cbJobType.TabIndex = 4;
			this.cbJobType.SelectedIndexChanged += new System.EventHandler(this.cbJobType_SelectedIndexChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(13, 44);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(31, 13);
			this.label2.TabIndex = 5;
			this.label2.Text = "Type";
			// 
			// cbIntervalType
			// 
			this.cbIntervalType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbIntervalType.FormattingEnabled = true;
			this.cbIntervalType.Location = new System.Drawing.Point(84, 68);
			this.cbIntervalType.Name = "cbIntervalType";
			this.cbIntervalType.Size = new System.Drawing.Size(214, 21);
			this.cbIntervalType.TabIndex = 6;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(13, 71);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(65, 13);
			this.label3.TabIndex = 7;
			this.label3.Text = "Interval type";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(13, 101);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(42, 13);
			this.label4.TabIndex = 8;
			this.label4.Text = "Interval";
			// 
			// nuInterval
			// 
			this.nuInterval.Location = new System.Drawing.Point(84, 99);
			this.nuInterval.Name = "nuInterval";
			this.nuInterval.Size = new System.Drawing.Size(214, 20);
			this.nuInterval.TabIndex = 9;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(13, 186);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(69, 13);
			this.label5.TabIndex = 10;
			this.label5.Text = "Configuration";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(13, 132);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(52, 13);
			this.label6.TabIndex = 11;
			this.label6.Text = "Start from";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(13, 159);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(41, 13);
			this.label7.TabIndex = 12;
			this.label7.Text = "Start to";
			// 
			// dpStartFrom
			// 
			this.dpStartFrom.CustomFormat = "HH:mm";
			this.dpStartFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dpStartFrom.Location = new System.Drawing.Point(84, 126);
			this.dpStartFrom.Name = "dpStartFrom";
			this.dpStartFrom.ShowUpDown = true;
			this.dpStartFrom.Size = new System.Drawing.Size(214, 20);
			this.dpStartFrom.TabIndex = 15;
			// 
			// dpStartTo
			// 
			this.dpStartTo.CustomFormat = "HH:mm";
			this.dpStartTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dpStartTo.Location = new System.Drawing.Point(84, 153);
			this.dpStartTo.Name = "dpStartTo";
			this.dpStartTo.ShowUpDown = true;
			this.dpStartTo.Size = new System.Drawing.Size(214, 20);
			this.dpStartTo.TabIndex = 16;
			// 
			// btnSave
			// 
			this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnSave.Location = new System.Drawing.Point(452, 396);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(75, 23);
			this.btnSave.TabIndex = 17;
			this.btnSave.Text = "Save";
			this.btnSave.UseVisualStyleBackColor = true;
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(533, 396);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 18;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// tbDescription
			// 
			this.tbDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbDescription.Location = new System.Drawing.Point(323, 41);
			this.tbDescription.Multiline = true;
			this.tbDescription.Name = "tbDescription";
			this.tbDescription.ReadOnly = true;
			this.tbDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.tbDescription.Size = new System.Drawing.Size(285, 132);
			this.tbDescription.TabIndex = 19;
			// 
			// ScheduleForm
			// 
			this.AcceptButton = this.btnSave;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(620, 431);
			this.Controls.Add(this.tbDescription);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.dpStartTo);
			this.Controls.Add(this.dpStartFrom);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.nuInterval);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.cbIntervalType);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.cbJobType);
			this.Controls.Add(this.pnlJobConfig);
			this.Controls.Add(this.tbName);
			this.Controls.Add(this.label1);
			this.MinimizeBox = false;
			this.Name = "ScheduleForm";
			this.ShowInTaskbar = false;
			this.Text = "ScheduleForm";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ScheduleForm_FormClosing);
			this.Load += new System.EventHandler(this.ScheduleForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.nuInterval)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox tbName;
		private System.Windows.Forms.Panel pnlJobConfig;
		private System.Windows.Forms.ComboBox cbJobType;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox cbIntervalType;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.NumericUpDown nuInterval;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.DateTimePicker dpStartFrom;
		private System.Windows.Forms.DateTimePicker dpStartTo;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.TextBox tbDescription;
	}
}