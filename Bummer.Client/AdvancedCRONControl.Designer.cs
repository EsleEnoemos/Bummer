namespace Bummer.Client {
	partial class AdvancedCRONControl {
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
			this.label12 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.tbSeconds = new System.Windows.Forms.TextBox();
			this.tbMinutes = new System.Windows.Forms.TextBox();
			this.tbHours = new System.Windows.Forms.TextBox();
			this.tbDays = new System.Windows.Forms.TextBox();
			this.tbMonths = new System.Windows.Forms.TextBox();
			this.tbDates = new System.Windows.Forms.TextBox();
			this.btnCronTest = new System.Windows.Forms.Button();
			this.linkLabel1 = new System.Windows.Forms.LinkLabel();
			this.SuspendLayout();
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(363, 10);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(70, 13);
			this.label12.TabIndex = 65;
			this.label12.Text = "Day-of-Week";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(291, 10);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(42, 13);
			this.label11.TabIndex = 60;
			this.label11.Text = "Months";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(219, 10);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(71, 13);
			this.label10.TabIndex = 55;
			this.label10.Text = "Day-of-Month";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(156, 10);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(35, 13);
			this.label8.TabIndex = 50;
			this.label8.Text = "Hours";
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Location = new System.Drawing.Point(75, 10);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(44, 13);
			this.label14.TabIndex = 45;
			this.label14.Text = "Minutes";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(3, 10);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(49, 13);
			this.label7.TabIndex = 40;
			this.label7.Text = "Seconds";
			// 
			// tbSeconds
			// 
			this.tbSeconds.Location = new System.Drawing.Point(6, 35);
			this.tbSeconds.Name = "tbSeconds";
			this.tbSeconds.Size = new System.Drawing.Size(66, 20);
			this.tbSeconds.TabIndex = 66;
			this.tbSeconds.TextChanged += new System.EventHandler(this.CronPartChanged);
			// 
			// tbMinutes
			// 
			this.tbMinutes.Location = new System.Drawing.Point(78, 35);
			this.tbMinutes.Name = "tbMinutes";
			this.tbMinutes.Size = new System.Drawing.Size(66, 20);
			this.tbMinutes.TabIndex = 67;
			this.tbMinutes.TextChanged += new System.EventHandler(this.CronPartChanged);
			// 
			// tbHours
			// 
			this.tbHours.Location = new System.Drawing.Point(150, 35);
			this.tbHours.Name = "tbHours";
			this.tbHours.Size = new System.Drawing.Size(66, 20);
			this.tbHours.TabIndex = 68;
			this.tbHours.TextChanged += new System.EventHandler(this.CronPartChanged);
			// 
			// tbDays
			// 
			this.tbDays.Location = new System.Drawing.Point(222, 35);
			this.tbDays.Name = "tbDays";
			this.tbDays.Size = new System.Drawing.Size(66, 20);
			this.tbDays.TabIndex = 69;
			this.tbDays.TextChanged += new System.EventHandler(this.CronPartChanged);
			// 
			// tbMonths
			// 
			this.tbMonths.Location = new System.Drawing.Point(294, 35);
			this.tbMonths.Name = "tbMonths";
			this.tbMonths.Size = new System.Drawing.Size(66, 20);
			this.tbMonths.TabIndex = 70;
			this.tbMonths.TextChanged += new System.EventHandler(this.CronPartChanged);
			// 
			// tbDates
			// 
			this.tbDates.Location = new System.Drawing.Point(366, 35);
			this.tbDates.Name = "tbDates";
			this.tbDates.Size = new System.Drawing.Size(66, 20);
			this.tbDates.TabIndex = 71;
			this.tbDates.TextChanged += new System.EventHandler(this.CronPartChanged);
			// 
			// btnCronTest
			// 
			this.btnCronTest.Location = new System.Drawing.Point(439, 35);
			this.btnCronTest.Name = "btnCronTest";
			this.btnCronTest.Size = new System.Drawing.Size(120, 23);
			this.btnCronTest.TabIndex = 72;
			this.btnCronTest.Text = "View repetition times";
			this.btnCronTest.UseVisualStyleBackColor = true;
			this.btnCronTest.Click += new System.EventHandler(this.btnCronTest_Click);
			// 
			// linkLabel1
			// 
			this.linkLabel1.AutoSize = true;
			this.linkLabel1.Location = new System.Drawing.Point(6, 74);
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.Size = new System.Drawing.Size(128, 13);
			this.linkLabel1.TabIndex = 73;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Text = "Tutorial for CRON-triggers";
			this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
			// 
			// AdvancedCRONControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.linkLabel1);
			this.Controls.Add(this.btnCronTest);
			this.Controls.Add(this.tbDates);
			this.Controls.Add(this.tbMonths);
			this.Controls.Add(this.tbDays);
			this.Controls.Add(this.tbHours);
			this.Controls.Add(this.tbMinutes);
			this.Controls.Add(this.tbSeconds);
			this.Controls.Add(this.label12);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label14);
			this.Controls.Add(this.label7);
			this.Name = "AdvancedCRONControl";
			this.Size = new System.Drawing.Size(571, 478);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox tbSeconds;
		private System.Windows.Forms.TextBox tbMinutes;
		private System.Windows.Forms.TextBox tbHours;
		private System.Windows.Forms.TextBox tbDays;
		private System.Windows.Forms.TextBox tbMonths;
		private System.Windows.Forms.TextBox tbDates;
		private System.Windows.Forms.Button btnCronTest;
		private System.Windows.Forms.LinkLabel linkLabel1;
	}
}
