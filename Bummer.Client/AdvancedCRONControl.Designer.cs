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
			this.btnRemoveDates = new System.Windows.Forms.Button();
			this.btnAddDates = new System.Windows.Forms.Button();
			this.lvSelectedDates = new System.Windows.Forms.ListView();
			this.columnHeader15 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.lvNotSelectedDates = new System.Windows.Forms.ListView();
			this.columnHeader16 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.label12 = new System.Windows.Forms.Label();
			this.btnRemoveMonths = new System.Windows.Forms.Button();
			this.btnAddMonths = new System.Windows.Forms.Button();
			this.lvSelectedMonths = new System.Windows.Forms.ListView();
			this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.lvNotSelectedMonths = new System.Windows.Forms.ListView();
			this.columnHeader14 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.label11 = new System.Windows.Forms.Label();
			this.btnRemoveDays = new System.Windows.Forms.Button();
			this.btnAddDays = new System.Windows.Forms.Button();
			this.lvSelectedDays = new System.Windows.Forms.ListView();
			this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.lvNotSelectedDays = new System.Windows.Forms.ListView();
			this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.label10 = new System.Windows.Forms.Label();
			this.btnRemoveHours = new System.Windows.Forms.Button();
			this.btnAddHours = new System.Windows.Forms.Button();
			this.lvSelectedHours = new System.Windows.Forms.ListView();
			this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.lvNotSelectedHours = new System.Windows.Forms.ListView();
			this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.label8 = new System.Windows.Forms.Label();
			this.btnRemoveMinutes = new System.Windows.Forms.Button();
			this.btnAddMinutes = new System.Windows.Forms.Button();
			this.lvSelectedMinutes = new System.Windows.Forms.ListView();
			this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.lvNotSelectedMinutes = new System.Windows.Forms.ListView();
			this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.label14 = new System.Windows.Forms.Label();
			this.btnRemoveSeconds = new System.Windows.Forms.Button();
			this.btnAddSeconds = new System.Windows.Forms.Button();
			this.lvSelectedSeconds = new System.Windows.Forms.ListView();
			this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.lvNotSelectedSeconds = new System.Windows.Forms.ListView();
			this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.label7 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// btnRemoveDates
			// 
			this.btnRemoveDates.Location = new System.Drawing.Point(271, 379);
			this.btnRemoveDates.Name = "btnRemoveDates";
			this.btnRemoveDates.Size = new System.Drawing.Size(75, 23);
			this.btnRemoveDates.TabIndex = 69;
			this.btnRemoveDates.Tag = "lvSelectedDates|lvNotSelectedDates";
			this.btnRemoveDates.Text = "<<<";
			this.btnRemoveDates.UseVisualStyleBackColor = true;
			this.btnRemoveDates.Click += new System.EventHandler(this.MoveItemsClick);
			// 
			// btnAddDates
			// 
			this.btnAddDates.Location = new System.Drawing.Point(271, 350);
			this.btnAddDates.Name = "btnAddDates";
			this.btnAddDates.Size = new System.Drawing.Size(75, 23);
			this.btnAddDates.TabIndex = 68;
			this.btnAddDates.Tag = "lvNotSelectedDates|lvSelectedDates";
			this.btnAddDates.Text = ">>>";
			this.btnAddDates.UseVisualStyleBackColor = true;
			this.btnAddDates.Click += new System.EventHandler(this.MoveItemsClick);
			// 
			// lvSelectedDates
			// 
			this.lvSelectedDates.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader15});
			this.lvSelectedDates.FullRowSelect = true;
			this.lvSelectedDates.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
			this.lvSelectedDates.HideSelection = false;
			this.lvSelectedDates.Location = new System.Drawing.Point(359, 350);
			this.lvSelectedDates.Name = "lvSelectedDates";
			this.lvSelectedDates.Size = new System.Drawing.Size(206, 62);
			this.lvSelectedDates.Sorting = System.Windows.Forms.SortOrder.Ascending;
			this.lvSelectedDates.TabIndex = 67;
			this.lvSelectedDates.UseCompatibleStateImageBehavior = false;
			this.lvSelectedDates.View = System.Windows.Forms.View.Details;
			// 
			// lvNotSelectedDates
			// 
			this.lvNotSelectedDates.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader16});
			this.lvNotSelectedDates.FullRowSelect = true;
			this.lvNotSelectedDates.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
			this.lvNotSelectedDates.HideSelection = false;
			this.lvNotSelectedDates.Location = new System.Drawing.Point(59, 350);
			this.lvNotSelectedDates.Name = "lvNotSelectedDates";
			this.lvNotSelectedDates.Size = new System.Drawing.Size(206, 62);
			this.lvNotSelectedDates.Sorting = System.Windows.Forms.SortOrder.Ascending;
			this.lvNotSelectedDates.TabIndex = 66;
			this.lvNotSelectedDates.UseCompatibleStateImageBehavior = false;
			this.lvNotSelectedDates.View = System.Windows.Forms.View.Details;
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(3, 350);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(35, 13);
			this.label12.TabIndex = 65;
			this.label12.Text = "Dates";
			// 
			// btnRemoveMonths
			// 
			this.btnRemoveMonths.Location = new System.Drawing.Point(271, 311);
			this.btnRemoveMonths.Name = "btnRemoveMonths";
			this.btnRemoveMonths.Size = new System.Drawing.Size(75, 23);
			this.btnRemoveMonths.TabIndex = 64;
			this.btnRemoveMonths.Tag = "lvSelectedMonths|lvNotSelectedMonths";
			this.btnRemoveMonths.Text = "<<<";
			this.btnRemoveMonths.UseVisualStyleBackColor = true;
			this.btnRemoveMonths.Click += new System.EventHandler(this.MoveItemsClick);
			// 
			// btnAddMonths
			// 
			this.btnAddMonths.Location = new System.Drawing.Point(271, 282);
			this.btnAddMonths.Name = "btnAddMonths";
			this.btnAddMonths.Size = new System.Drawing.Size(75, 23);
			this.btnAddMonths.TabIndex = 63;
			this.btnAddMonths.Tag = "lvNotSelectedMonths|lvSelectedMonths";
			this.btnAddMonths.Text = ">>>";
			this.btnAddMonths.UseVisualStyleBackColor = true;
			this.btnAddMonths.Click += new System.EventHandler(this.MoveItemsClick);
			// 
			// lvSelectedMonths
			// 
			this.lvSelectedMonths.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader13});
			this.lvSelectedMonths.FullRowSelect = true;
			this.lvSelectedMonths.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
			this.lvSelectedMonths.HideSelection = false;
			this.lvSelectedMonths.Location = new System.Drawing.Point(359, 282);
			this.lvSelectedMonths.Name = "lvSelectedMonths";
			this.lvSelectedMonths.Size = new System.Drawing.Size(206, 62);
			this.lvSelectedMonths.Sorting = System.Windows.Forms.SortOrder.Ascending;
			this.lvSelectedMonths.TabIndex = 62;
			this.lvSelectedMonths.UseCompatibleStateImageBehavior = false;
			this.lvSelectedMonths.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader13
			// 
			this.columnHeader13.Width = 150;
			// 
			// lvNotSelectedMonths
			// 
			this.lvNotSelectedMonths.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader14});
			this.lvNotSelectedMonths.FullRowSelect = true;
			this.lvNotSelectedMonths.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
			this.lvNotSelectedMonths.HideSelection = false;
			this.lvNotSelectedMonths.Location = new System.Drawing.Point(59, 282);
			this.lvNotSelectedMonths.Name = "lvNotSelectedMonths";
			this.lvNotSelectedMonths.Size = new System.Drawing.Size(206, 62);
			this.lvNotSelectedMonths.Sorting = System.Windows.Forms.SortOrder.Ascending;
			this.lvNotSelectedMonths.TabIndex = 61;
			this.lvNotSelectedMonths.UseCompatibleStateImageBehavior = false;
			this.lvNotSelectedMonths.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader14
			// 
			this.columnHeader14.Width = 150;
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(3, 282);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(42, 13);
			this.label11.TabIndex = 60;
			this.label11.Text = "Months";
			// 
			// btnRemoveDays
			// 
			this.btnRemoveDays.Location = new System.Drawing.Point(271, 243);
			this.btnRemoveDays.Name = "btnRemoveDays";
			this.btnRemoveDays.Size = new System.Drawing.Size(75, 23);
			this.btnRemoveDays.TabIndex = 59;
			this.btnRemoveDays.Tag = "lvSelectedDays|lvNotSelectedDays";
			this.btnRemoveDays.Text = "<<<";
			this.btnRemoveDays.UseVisualStyleBackColor = true;
			this.btnRemoveDays.Click += new System.EventHandler(this.MoveItemsClick);
			// 
			// btnAddDays
			// 
			this.btnAddDays.Location = new System.Drawing.Point(271, 214);
			this.btnAddDays.Name = "btnAddDays";
			this.btnAddDays.Size = new System.Drawing.Size(75, 23);
			this.btnAddDays.TabIndex = 58;
			this.btnAddDays.Tag = "lvNotSelectedDays|lvSelectedDays";
			this.btnAddDays.Text = ">>>";
			this.btnAddDays.UseVisualStyleBackColor = true;
			this.btnAddDays.Click += new System.EventHandler(this.MoveItemsClick);
			// 
			// lvSelectedDays
			// 
			this.lvSelectedDays.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader11});
			this.lvSelectedDays.FullRowSelect = true;
			this.lvSelectedDays.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
			this.lvSelectedDays.HideSelection = false;
			this.lvSelectedDays.Location = new System.Drawing.Point(359, 214);
			this.lvSelectedDays.Name = "lvSelectedDays";
			this.lvSelectedDays.Size = new System.Drawing.Size(206, 62);
			this.lvSelectedDays.Sorting = System.Windows.Forms.SortOrder.Ascending;
			this.lvSelectedDays.TabIndex = 57;
			this.lvSelectedDays.UseCompatibleStateImageBehavior = false;
			this.lvSelectedDays.View = System.Windows.Forms.View.Details;
			// 
			// lvNotSelectedDays
			// 
			this.lvNotSelectedDays.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader12});
			this.lvNotSelectedDays.FullRowSelect = true;
			this.lvNotSelectedDays.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
			this.lvNotSelectedDays.HideSelection = false;
			this.lvNotSelectedDays.Location = new System.Drawing.Point(59, 214);
			this.lvNotSelectedDays.Name = "lvNotSelectedDays";
			this.lvNotSelectedDays.Size = new System.Drawing.Size(206, 62);
			this.lvNotSelectedDays.Sorting = System.Windows.Forms.SortOrder.Ascending;
			this.lvNotSelectedDays.TabIndex = 56;
			this.lvNotSelectedDays.UseCompatibleStateImageBehavior = false;
			this.lvNotSelectedDays.View = System.Windows.Forms.View.Details;
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(3, 214);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(31, 13);
			this.label10.TabIndex = 55;
			this.label10.Text = "Days";
			// 
			// btnRemoveHours
			// 
			this.btnRemoveHours.Location = new System.Drawing.Point(271, 175);
			this.btnRemoveHours.Name = "btnRemoveHours";
			this.btnRemoveHours.Size = new System.Drawing.Size(75, 23);
			this.btnRemoveHours.TabIndex = 54;
			this.btnRemoveHours.Tag = "lvSelectedHours|lvNotSelectedHours";
			this.btnRemoveHours.Text = "<<<";
			this.btnRemoveHours.UseVisualStyleBackColor = true;
			this.btnRemoveHours.Click += new System.EventHandler(this.MoveItemsClick);
			// 
			// btnAddHours
			// 
			this.btnAddHours.Location = new System.Drawing.Point(271, 146);
			this.btnAddHours.Name = "btnAddHours";
			this.btnAddHours.Size = new System.Drawing.Size(75, 23);
			this.btnAddHours.TabIndex = 53;
			this.btnAddHours.Tag = "lvNotSelectedHours|lvSelectedHours";
			this.btnAddHours.Text = ">>>";
			this.btnAddHours.UseVisualStyleBackColor = true;
			this.btnAddHours.Click += new System.EventHandler(this.MoveItemsClick);
			// 
			// lvSelectedHours
			// 
			this.lvSelectedHours.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader9});
			this.lvSelectedHours.FullRowSelect = true;
			this.lvSelectedHours.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
			this.lvSelectedHours.HideSelection = false;
			this.lvSelectedHours.Location = new System.Drawing.Point(359, 146);
			this.lvSelectedHours.Name = "lvSelectedHours";
			this.lvSelectedHours.Size = new System.Drawing.Size(206, 62);
			this.lvSelectedHours.Sorting = System.Windows.Forms.SortOrder.Ascending;
			this.lvSelectedHours.TabIndex = 52;
			this.lvSelectedHours.UseCompatibleStateImageBehavior = false;
			this.lvSelectedHours.View = System.Windows.Forms.View.Details;
			// 
			// lvNotSelectedHours
			// 
			this.lvNotSelectedHours.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader10});
			this.lvNotSelectedHours.FullRowSelect = true;
			this.lvNotSelectedHours.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
			this.lvNotSelectedHours.HideSelection = false;
			this.lvNotSelectedHours.Location = new System.Drawing.Point(59, 146);
			this.lvNotSelectedHours.Name = "lvNotSelectedHours";
			this.lvNotSelectedHours.Size = new System.Drawing.Size(206, 62);
			this.lvNotSelectedHours.Sorting = System.Windows.Forms.SortOrder.Ascending;
			this.lvNotSelectedHours.TabIndex = 51;
			this.lvNotSelectedHours.UseCompatibleStateImageBehavior = false;
			this.lvNotSelectedHours.View = System.Windows.Forms.View.Details;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(3, 146);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(35, 13);
			this.label8.TabIndex = 50;
			this.label8.Text = "Hours";
			// 
			// btnRemoveMinutes
			// 
			this.btnRemoveMinutes.Location = new System.Drawing.Point(271, 107);
			this.btnRemoveMinutes.Name = "btnRemoveMinutes";
			this.btnRemoveMinutes.Size = new System.Drawing.Size(75, 23);
			this.btnRemoveMinutes.TabIndex = 49;
			this.btnRemoveMinutes.Tag = "lvSelectedMinutes|lvNotSelectedMinutes";
			this.btnRemoveMinutes.Text = "<<<";
			this.btnRemoveMinutes.UseVisualStyleBackColor = true;
			this.btnRemoveMinutes.Click += new System.EventHandler(this.MoveItemsClick);
			// 
			// btnAddMinutes
			// 
			this.btnAddMinutes.Location = new System.Drawing.Point(271, 78);
			this.btnAddMinutes.Name = "btnAddMinutes";
			this.btnAddMinutes.Size = new System.Drawing.Size(75, 23);
			this.btnAddMinutes.TabIndex = 48;
			this.btnAddMinutes.Tag = "lvNotSelectedMinutes|lvSelectedMinutes";
			this.btnAddMinutes.Text = ">>>";
			this.btnAddMinutes.UseVisualStyleBackColor = true;
			this.btnAddMinutes.Click += new System.EventHandler(this.MoveItemsClick);
			// 
			// lvSelectedMinutes
			// 
			this.lvSelectedMinutes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader7});
			this.lvSelectedMinutes.FullRowSelect = true;
			this.lvSelectedMinutes.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
			this.lvSelectedMinutes.HideSelection = false;
			this.lvSelectedMinutes.Location = new System.Drawing.Point(359, 78);
			this.lvSelectedMinutes.Name = "lvSelectedMinutes";
			this.lvSelectedMinutes.Size = new System.Drawing.Size(206, 62);
			this.lvSelectedMinutes.Sorting = System.Windows.Forms.SortOrder.Ascending;
			this.lvSelectedMinutes.TabIndex = 47;
			this.lvSelectedMinutes.UseCompatibleStateImageBehavior = false;
			this.lvSelectedMinutes.View = System.Windows.Forms.View.Details;
			// 
			// lvNotSelectedMinutes
			// 
			this.lvNotSelectedMinutes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader8});
			this.lvNotSelectedMinutes.FullRowSelect = true;
			this.lvNotSelectedMinutes.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
			this.lvNotSelectedMinutes.HideSelection = false;
			this.lvNotSelectedMinutes.Location = new System.Drawing.Point(59, 78);
			this.lvNotSelectedMinutes.Name = "lvNotSelectedMinutes";
			this.lvNotSelectedMinutes.Size = new System.Drawing.Size(206, 62);
			this.lvNotSelectedMinutes.Sorting = System.Windows.Forms.SortOrder.Ascending;
			this.lvNotSelectedMinutes.TabIndex = 46;
			this.lvNotSelectedMinutes.UseCompatibleStateImageBehavior = false;
			this.lvNotSelectedMinutes.View = System.Windows.Forms.View.Details;
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Location = new System.Drawing.Point(3, 78);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(44, 13);
			this.label14.TabIndex = 45;
			this.label14.Text = "Minutes";
			// 
			// btnRemoveSeconds
			// 
			this.btnRemoveSeconds.Location = new System.Drawing.Point(271, 39);
			this.btnRemoveSeconds.Name = "btnRemoveSeconds";
			this.btnRemoveSeconds.Size = new System.Drawing.Size(75, 23);
			this.btnRemoveSeconds.TabIndex = 44;
			this.btnRemoveSeconds.Tag = "lvSelectedSeconds|lvNotSelectedSeconds";
			this.btnRemoveSeconds.Text = "<<<";
			this.btnRemoveSeconds.UseVisualStyleBackColor = true;
			this.btnRemoveSeconds.Click += new System.EventHandler(this.MoveItemsClick);
			// 
			// btnAddSeconds
			// 
			this.btnAddSeconds.Location = new System.Drawing.Point(271, 10);
			this.btnAddSeconds.Name = "btnAddSeconds";
			this.btnAddSeconds.Size = new System.Drawing.Size(75, 23);
			this.btnAddSeconds.TabIndex = 43;
			this.btnAddSeconds.Tag = "lvNotSelectedSeconds|lvSelectedSeconds";
			this.btnAddSeconds.Text = ">>>";
			this.btnAddSeconds.UseVisualStyleBackColor = true;
			this.btnAddSeconds.Click += new System.EventHandler(this.MoveItemsClick);
			// 
			// lvSelectedSeconds
			// 
			this.lvSelectedSeconds.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader6});
			this.lvSelectedSeconds.FullRowSelect = true;
			this.lvSelectedSeconds.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
			this.lvSelectedSeconds.HideSelection = false;
			this.lvSelectedSeconds.Location = new System.Drawing.Point(359, 10);
			this.lvSelectedSeconds.Name = "lvSelectedSeconds";
			this.lvSelectedSeconds.Size = new System.Drawing.Size(206, 62);
			this.lvSelectedSeconds.Sorting = System.Windows.Forms.SortOrder.Ascending;
			this.lvSelectedSeconds.TabIndex = 42;
			this.lvSelectedSeconds.UseCompatibleStateImageBehavior = false;
			this.lvSelectedSeconds.View = System.Windows.Forms.View.Details;
			// 
			// lvNotSelectedSeconds
			// 
			this.lvNotSelectedSeconds.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5});
			this.lvNotSelectedSeconds.FullRowSelect = true;
			this.lvNotSelectedSeconds.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
			this.lvNotSelectedSeconds.HideSelection = false;
			this.lvNotSelectedSeconds.Location = new System.Drawing.Point(59, 10);
			this.lvNotSelectedSeconds.Name = "lvNotSelectedSeconds";
			this.lvNotSelectedSeconds.Size = new System.Drawing.Size(206, 62);
			this.lvNotSelectedSeconds.Sorting = System.Windows.Forms.SortOrder.Ascending;
			this.lvNotSelectedSeconds.TabIndex = 41;
			this.lvNotSelectedSeconds.UseCompatibleStateImageBehavior = false;
			this.lvNotSelectedSeconds.View = System.Windows.Forms.View.Details;
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
			// AdvancedCRONControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.btnRemoveDates);
			this.Controls.Add(this.btnAddDates);
			this.Controls.Add(this.lvSelectedDates);
			this.Controls.Add(this.lvNotSelectedDates);
			this.Controls.Add(this.label12);
			this.Controls.Add(this.btnRemoveMonths);
			this.Controls.Add(this.btnAddMonths);
			this.Controls.Add(this.lvSelectedMonths);
			this.Controls.Add(this.lvNotSelectedMonths);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.btnRemoveDays);
			this.Controls.Add(this.btnAddDays);
			this.Controls.Add(this.lvSelectedDays);
			this.Controls.Add(this.lvNotSelectedDays);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.btnRemoveHours);
			this.Controls.Add(this.btnAddHours);
			this.Controls.Add(this.lvSelectedHours);
			this.Controls.Add(this.lvNotSelectedHours);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.btnRemoveMinutes);
			this.Controls.Add(this.btnAddMinutes);
			this.Controls.Add(this.lvSelectedMinutes);
			this.Controls.Add(this.lvNotSelectedMinutes);
			this.Controls.Add(this.label14);
			this.Controls.Add(this.btnRemoveSeconds);
			this.Controls.Add(this.btnAddSeconds);
			this.Controls.Add(this.lvSelectedSeconds);
			this.Controls.Add(this.lvNotSelectedSeconds);
			this.Controls.Add(this.label7);
			this.Name = "AdvancedCRONControl";
			this.Size = new System.Drawing.Size(590, 434);
			this.Load += new System.EventHandler(this.AdvancedCRONControl_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnRemoveDates;
		private System.Windows.Forms.Button btnAddDates;
		private System.Windows.Forms.ListView lvSelectedDates;
		private System.Windows.Forms.ColumnHeader columnHeader15;
		private System.Windows.Forms.ListView lvNotSelectedDates;
		private System.Windows.Forms.ColumnHeader columnHeader16;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Button btnRemoveMonths;
		private System.Windows.Forms.Button btnAddMonths;
		private System.Windows.Forms.ListView lvSelectedMonths;
		private System.Windows.Forms.ColumnHeader columnHeader13;
		private System.Windows.Forms.ListView lvNotSelectedMonths;
		private System.Windows.Forms.ColumnHeader columnHeader14;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Button btnRemoveDays;
		private System.Windows.Forms.Button btnAddDays;
		private System.Windows.Forms.ListView lvSelectedDays;
		private System.Windows.Forms.ColumnHeader columnHeader11;
		private System.Windows.Forms.ListView lvNotSelectedDays;
		private System.Windows.Forms.ColumnHeader columnHeader12;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Button btnRemoveHours;
		private System.Windows.Forms.Button btnAddHours;
		private System.Windows.Forms.ListView lvSelectedHours;
		private System.Windows.Forms.ColumnHeader columnHeader9;
		private System.Windows.Forms.ListView lvNotSelectedHours;
		private System.Windows.Forms.ColumnHeader columnHeader10;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Button btnRemoveMinutes;
		private System.Windows.Forms.Button btnAddMinutes;
		private System.Windows.Forms.ListView lvSelectedMinutes;
		private System.Windows.Forms.ColumnHeader columnHeader7;
		private System.Windows.Forms.ListView lvNotSelectedMinutes;
		private System.Windows.Forms.ColumnHeader columnHeader8;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Button btnRemoveSeconds;
		private System.Windows.Forms.Button btnAddSeconds;
		private System.Windows.Forms.ListView lvSelectedSeconds;
		private System.Windows.Forms.ColumnHeader columnHeader6;
		private System.Windows.Forms.ListView lvNotSelectedSeconds;
		private System.Windows.Forms.ColumnHeader columnHeader5;
		private System.Windows.Forms.Label label7;
	}
}
