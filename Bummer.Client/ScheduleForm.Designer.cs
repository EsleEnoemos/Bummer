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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScheduleForm));
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
			this.dpStartTime = new System.Windows.Forms.DateTimePicker();
			this.btnSave = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.tbDescription = new System.Windows.Forms.TextBox();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.label9 = new System.Windows.Forms.Label();
			this.btnTryPostCommand = new System.Windows.Forms.Button();
			this.btnTryPreCommands = new System.Windows.Forms.Button();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.btnEditPostCommand = new System.Windows.Forms.Button();
			this.btnMoveDownPostCommand = new System.Windows.Forms.Button();
			this.btnMoveUpPostCommand = new System.Windows.Forms.Button();
			this.btnRemovePostCommand = new System.Windows.Forms.Button();
			this.btnAddPostCommand = new System.Windows.Forms.Button();
			this.lvPostCommands = new System.Windows.Forms.ListView();
			this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btnEditPreCommand = new System.Windows.Forms.Button();
			this.btnMoveDownPreCommand = new System.Windows.Forms.Button();
			this.btnMoveUpPreCommand = new System.Windows.Forms.Button();
			this.btnRemovePreCommand = new System.Windows.Forms.Button();
			this.btnAddPreCommand = new System.Windows.Forms.Button();
			this.lvPreCommands = new System.Windows.Forms.ListView();
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			((System.ComponentModel.ISupportInitialize)(this.nuInterval)).BeginInit();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 14);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(35, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Name";
			// 
			// tbName
			// 
			this.tbName.Location = new System.Drawing.Point(83, 11);
			this.tbName.Name = "tbName";
			this.tbName.Size = new System.Drawing.Size(288, 20);
			this.tbName.TabIndex = 0;
			// 
			// pnlJobConfig
			// 
			this.pnlJobConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.pnlJobConfig.AutoScroll = true;
			this.pnlJobConfig.BackColor = System.Drawing.SystemColors.Window;
			this.pnlJobConfig.Location = new System.Drawing.Point(15, 180);
			this.pnlJobConfig.Name = "pnlJobConfig";
			this.pnlJobConfig.Size = new System.Drawing.Size(592, 311);
			this.pnlJobConfig.TabIndex = 6;
			this.pnlJobConfig.TabStop = true;
			// 
			// cbJobType
			// 
			this.cbJobType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbJobType.FormattingEnabled = true;
			this.cbJobType.Location = new System.Drawing.Point(83, 42);
			this.cbJobType.Name = "cbJobType";
			this.cbJobType.Size = new System.Drawing.Size(214, 21);
			this.cbJobType.TabIndex = 1;
			this.cbJobType.SelectedIndexChanged += new System.EventHandler(this.cbJobType_SelectedIndexChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 45);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(31, 13);
			this.label2.TabIndex = 5;
			this.label2.Text = "Type";
			// 
			// cbIntervalType
			// 
			this.cbIntervalType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbIntervalType.FormattingEnabled = true;
			this.cbIntervalType.Location = new System.Drawing.Point(83, 69);
			this.cbIntervalType.Name = "cbIntervalType";
			this.cbIntervalType.Size = new System.Drawing.Size(214, 21);
			this.cbIntervalType.TabIndex = 2;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 72);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(65, 13);
			this.label3.TabIndex = 7;
			this.label3.Text = "Interval type";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(12, 102);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(42, 13);
			this.label4.TabIndex = 8;
			this.label4.Text = "Interval";
			// 
			// nuInterval
			// 
			this.nuInterval.Location = new System.Drawing.Point(83, 100);
			this.nuInterval.Name = "nuInterval";
			this.nuInterval.Size = new System.Drawing.Size(214, 20);
			this.nuInterval.TabIndex = 3;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(12, 161);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(69, 13);
			this.label5.TabIndex = 10;
			this.label5.Text = "Configuration";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(12, 133);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(52, 13);
			this.label6.TabIndex = 11;
			this.label6.Text = "Start from";
			// 
			// dpStartTime
			// 
			this.dpStartTime.CustomFormat = "HH:mm";
			this.dpStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dpStartTime.Location = new System.Drawing.Point(83, 127);
			this.dpStartTime.Name = "dpStartTime";
			this.dpStartTime.ShowUpDown = true;
			this.dpStartTime.Size = new System.Drawing.Size(214, 20);
			this.dpStartTime.TabIndex = 4;
			// 
			// btnSave
			// 
			this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnSave.Location = new System.Drawing.Point(456, 575);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(75, 23);
			this.btnSave.TabIndex = 7;
			this.btnSave.Text = "Save";
			this.btnSave.UseVisualStyleBackColor = true;
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(537, 575);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 8;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// tbDescription
			// 
			this.tbDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbDescription.Location = new System.Drawing.Point(322, 42);
			this.tbDescription.Multiline = true;
			this.tbDescription.Name = "tbDescription";
			this.tbDescription.ReadOnly = true;
			this.tbDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.tbDescription.Size = new System.Drawing.Size(285, 132);
			this.tbDescription.TabIndex = 19;
			this.tbDescription.TabStop = false;
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Location = new System.Drawing.Point(1, 3);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(624, 566);
			this.tabControl1.TabIndex = 20;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.label1);
			this.tabPage1.Controls.Add(this.tbDescription);
			this.tabPage1.Controls.Add(this.tbName);
			this.tabPage1.Controls.Add(this.pnlJobConfig);
			this.tabPage1.Controls.Add(this.cbJobType);
			this.tabPage1.Controls.Add(this.label2);
			this.tabPage1.Controls.Add(this.dpStartTime);
			this.tabPage1.Controls.Add(this.cbIntervalType);
			this.tabPage1.Controls.Add(this.label3);
			this.tabPage1.Controls.Add(this.label6);
			this.tabPage1.Controls.Add(this.label4);
			this.tabPage1.Controls.Add(this.label5);
			this.tabPage1.Controls.Add(this.nuInterval);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(616, 540);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Settings";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.label9);
			this.tabPage2.Controls.Add(this.btnTryPostCommand);
			this.tabPage2.Controls.Add(this.btnTryPreCommands);
			this.tabPage2.Controls.Add(this.groupBox2);
			this.tabPage2.Controls.Add(this.groupBox1);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(616, 540);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Pre- post commands";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label9.Location = new System.Drawing.Point(5, 472);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(280, 52);
			this.label9.TabIndex = 5;
			this.label9.Text = resources.GetString("label9.Text");
			// 
			// btnTryPostCommand
			// 
			this.btnTryPostCommand.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnTryPostCommand.Location = new System.Drawing.Point(468, 475);
			this.btnTryPostCommand.Name = "btnTryPostCommand";
			this.btnTryPostCommand.Size = new System.Drawing.Size(139, 23);
			this.btnTryPostCommand.TabIndex = 12;
			this.btnTryPostCommand.Text = "Try post-commands";
			this.btnTryPostCommand.UseVisualStyleBackColor = true;
			this.btnTryPostCommand.Click += new System.EventHandler(this.btnTryPostCommand_Click);
			// 
			// btnTryPreCommands
			// 
			this.btnTryPreCommands.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnTryPreCommands.Location = new System.Drawing.Point(468, 225);
			this.btnTryPreCommands.Name = "btnTryPreCommands";
			this.btnTryPreCommands.Size = new System.Drawing.Size(139, 23);
			this.btnTryPreCommands.TabIndex = 6;
			this.btnTryPreCommands.Text = "Try pre-commands";
			this.btnTryPreCommands.UseVisualStyleBackColor = true;
			this.btnTryPreCommands.Click += new System.EventHandler(this.btnTryPreCommands_Click);
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox2.Controls.Add(this.btnEditPostCommand);
			this.groupBox2.Controls.Add(this.btnMoveDownPostCommand);
			this.groupBox2.Controls.Add(this.btnMoveUpPostCommand);
			this.groupBox2.Controls.Add(this.btnRemovePostCommand);
			this.groupBox2.Controls.Add(this.btnAddPostCommand);
			this.groupBox2.Controls.Add(this.lvPostCommands);
			this.groupBox2.Location = new System.Drawing.Point(8, 254);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(599, 215);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Post-commands. These commands will be executed after running job";
			// 
			// btnEditPostCommand
			// 
			this.btnEditPostCommand.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnEditPostCommand.Enabled = false;
			this.btnEditPostCommand.Location = new System.Drawing.Point(505, 48);
			this.btnEditPostCommand.Name = "btnEditPostCommand";
			this.btnEditPostCommand.Size = new System.Drawing.Size(85, 23);
			this.btnEditPostCommand.TabIndex = 8;
			this.btnEditPostCommand.Text = "Edit...";
			this.btnEditPostCommand.UseVisualStyleBackColor = true;
			this.btnEditPostCommand.Click += new System.EventHandler(this.btnEditPostCommand_Click);
			// 
			// btnMoveDownPostCommand
			// 
			this.btnMoveDownPostCommand.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnMoveDownPostCommand.Enabled = false;
			this.btnMoveDownPostCommand.Location = new System.Drawing.Point(505, 182);
			this.btnMoveDownPostCommand.Name = "btnMoveDownPostCommand";
			this.btnMoveDownPostCommand.Size = new System.Drawing.Size(85, 23);
			this.btnMoveDownPostCommand.TabIndex = 11;
			this.btnMoveDownPostCommand.Text = "Move down";
			this.btnMoveDownPostCommand.UseVisualStyleBackColor = true;
			this.btnMoveDownPostCommand.Click += new System.EventHandler(this.btnMoveDownPostCommand_Click);
			// 
			// btnMoveUpPostCommand
			// 
			this.btnMoveUpPostCommand.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnMoveUpPostCommand.Enabled = false;
			this.btnMoveUpPostCommand.Location = new System.Drawing.Point(505, 153);
			this.btnMoveUpPostCommand.Name = "btnMoveUpPostCommand";
			this.btnMoveUpPostCommand.Size = new System.Drawing.Size(85, 23);
			this.btnMoveUpPostCommand.TabIndex = 10;
			this.btnMoveUpPostCommand.Text = "Move up";
			this.btnMoveUpPostCommand.UseVisualStyleBackColor = true;
			this.btnMoveUpPostCommand.Click += new System.EventHandler(this.btnMoveUpPostCommand_Click);
			// 
			// btnRemovePostCommand
			// 
			this.btnRemovePostCommand.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnRemovePostCommand.Enabled = false;
			this.btnRemovePostCommand.Location = new System.Drawing.Point(505, 77);
			this.btnRemovePostCommand.Name = "btnRemovePostCommand";
			this.btnRemovePostCommand.Size = new System.Drawing.Size(85, 23);
			this.btnRemovePostCommand.TabIndex = 9;
			this.btnRemovePostCommand.Text = "Remove";
			this.btnRemovePostCommand.UseVisualStyleBackColor = true;
			this.btnRemovePostCommand.Click += new System.EventHandler(this.btnRemovePostCommand_Click);
			// 
			// btnAddPostCommand
			// 
			this.btnAddPostCommand.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAddPostCommand.Location = new System.Drawing.Point(505, 19);
			this.btnAddPostCommand.Name = "btnAddPostCommand";
			this.btnAddPostCommand.Size = new System.Drawing.Size(85, 23);
			this.btnAddPostCommand.TabIndex = 7;
			this.btnAddPostCommand.Text = "Add...";
			this.btnAddPostCommand.UseVisualStyleBackColor = true;
			this.btnAddPostCommand.Click += new System.EventHandler(this.btnAddPostCommand_Click);
			// 
			// lvPostCommands
			// 
			this.lvPostCommands.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lvPostCommands.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4});
			this.lvPostCommands.FullRowSelect = true;
			this.lvPostCommands.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.lvPostCommands.HideSelection = false;
			this.lvPostCommands.Location = new System.Drawing.Point(3, 18);
			this.lvPostCommands.Name = "lvPostCommands";
			this.lvPostCommands.Size = new System.Drawing.Size(496, 193);
			this.lvPostCommands.TabIndex = 6;
			this.lvPostCommands.UseCompatibleStateImageBehavior = false;
			this.lvPostCommands.View = System.Windows.Forms.View.Details;
			this.lvPostCommands.SelectedIndexChanged += new System.EventHandler(this.lvPostCommands_SelectedIndexChanged);
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "Command";
			this.columnHeader3.Width = 222;
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "Arguments";
			this.columnHeader4.Width = 260;
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.btnEditPreCommand);
			this.groupBox1.Controls.Add(this.btnMoveDownPreCommand);
			this.groupBox1.Controls.Add(this.btnMoveUpPreCommand);
			this.groupBox1.Controls.Add(this.btnRemovePreCommand);
			this.groupBox1.Controls.Add(this.btnAddPreCommand);
			this.groupBox1.Controls.Add(this.lvPreCommands);
			this.groupBox1.Location = new System.Drawing.Point(8, 7);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(599, 212);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Pre-commands. These commands will be executed before running job";
			// 
			// btnEditPreCommand
			// 
			this.btnEditPreCommand.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnEditPreCommand.Enabled = false;
			this.btnEditPreCommand.Location = new System.Drawing.Point(508, 49);
			this.btnEditPreCommand.Name = "btnEditPreCommand";
			this.btnEditPreCommand.Size = new System.Drawing.Size(85, 23);
			this.btnEditPreCommand.TabIndex = 2;
			this.btnEditPreCommand.Text = "Edit...";
			this.btnEditPreCommand.UseVisualStyleBackColor = true;
			this.btnEditPreCommand.Click += new System.EventHandler(this.btnEditPreCommand_Click);
			// 
			// btnMoveDownPreCommand
			// 
			this.btnMoveDownPreCommand.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnMoveDownPreCommand.Enabled = false;
			this.btnMoveDownPreCommand.Location = new System.Drawing.Point(508, 183);
			this.btnMoveDownPreCommand.Name = "btnMoveDownPreCommand";
			this.btnMoveDownPreCommand.Size = new System.Drawing.Size(85, 23);
			this.btnMoveDownPreCommand.TabIndex = 5;
			this.btnMoveDownPreCommand.Text = "Move down";
			this.btnMoveDownPreCommand.UseVisualStyleBackColor = true;
			this.btnMoveDownPreCommand.Click += new System.EventHandler(this.btnMoveDownPreCommand_Click);
			// 
			// btnMoveUpPreCommand
			// 
			this.btnMoveUpPreCommand.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnMoveUpPreCommand.Enabled = false;
			this.btnMoveUpPreCommand.Location = new System.Drawing.Point(508, 154);
			this.btnMoveUpPreCommand.Name = "btnMoveUpPreCommand";
			this.btnMoveUpPreCommand.Size = new System.Drawing.Size(85, 23);
			this.btnMoveUpPreCommand.TabIndex = 4;
			this.btnMoveUpPreCommand.Text = "Move up";
			this.btnMoveUpPreCommand.UseVisualStyleBackColor = true;
			this.btnMoveUpPreCommand.Click += new System.EventHandler(this.btnMoveUpPreCommand_Click);
			// 
			// btnRemovePreCommand
			// 
			this.btnRemovePreCommand.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnRemovePreCommand.Enabled = false;
			this.btnRemovePreCommand.Location = new System.Drawing.Point(508, 78);
			this.btnRemovePreCommand.Name = "btnRemovePreCommand";
			this.btnRemovePreCommand.Size = new System.Drawing.Size(85, 23);
			this.btnRemovePreCommand.TabIndex = 3;
			this.btnRemovePreCommand.Text = "Remove";
			this.btnRemovePreCommand.UseVisualStyleBackColor = true;
			this.btnRemovePreCommand.Click += new System.EventHandler(this.btnRemovePreCommand_Click);
			// 
			// btnAddPreCommand
			// 
			this.btnAddPreCommand.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAddPreCommand.Location = new System.Drawing.Point(508, 20);
			this.btnAddPreCommand.Name = "btnAddPreCommand";
			this.btnAddPreCommand.Size = new System.Drawing.Size(85, 23);
			this.btnAddPreCommand.TabIndex = 1;
			this.btnAddPreCommand.Text = "Add...";
			this.btnAddPreCommand.UseVisualStyleBackColor = true;
			this.btnAddPreCommand.Click += new System.EventHandler(this.btnAddPreCommand_Click);
			// 
			// lvPreCommands
			// 
			this.lvPreCommands.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lvPreCommands.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
			this.lvPreCommands.FullRowSelect = true;
			this.lvPreCommands.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.lvPreCommands.HideSelection = false;
			this.lvPreCommands.Location = new System.Drawing.Point(6, 19);
			this.lvPreCommands.Name = "lvPreCommands";
			this.lvPreCommands.Size = new System.Drawing.Size(496, 187);
			this.lvPreCommands.TabIndex = 0;
			this.lvPreCommands.UseCompatibleStateImageBehavior = false;
			this.lvPreCommands.View = System.Windows.Forms.View.Details;
			this.lvPreCommands.SelectedIndexChanged += new System.EventHandler(this.lvPreCommands_SelectedIndexChanged);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Command";
			this.columnHeader1.Width = 222;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Arguments";
			this.columnHeader2.Width = 260;
			// 
			// ScheduleForm
			// 
			this.AcceptButton = this.btnSave;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(624, 610);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnSave);
			this.MinimizeBox = false;
			this.Name = "ScheduleForm";
			this.ShowInTaskbar = false;
			this.Text = "ScheduleForm";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ScheduleForm_FormClosing);
			this.Load += new System.EventHandler(this.ScheduleForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.nuInterval)).EndInit();
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.tabPage2.ResumeLayout(false);
			this.tabPage2.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

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
		private System.Windows.Forms.DateTimePicker dpStartTime;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.TextBox tbDescription;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Button btnTryPostCommand;
		private System.Windows.Forms.Button btnTryPreCommands;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button btnMoveDownPreCommand;
		private System.Windows.Forms.Button btnMoveUpPreCommand;
		private System.Windows.Forms.Button btnRemovePreCommand;
		private System.Windows.Forms.Button btnAddPreCommand;
		private System.Windows.Forms.ListView lvPreCommands;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.Button btnEditPreCommand;
		private System.Windows.Forms.Button btnEditPostCommand;
		private System.Windows.Forms.Button btnMoveDownPostCommand;
		private System.Windows.Forms.Button btnMoveUpPostCommand;
		private System.Windows.Forms.Button btnRemovePostCommand;
		private System.Windows.Forms.Button btnAddPostCommand;
		private System.Windows.Forms.ListView lvPostCommands;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader4;
	}
}