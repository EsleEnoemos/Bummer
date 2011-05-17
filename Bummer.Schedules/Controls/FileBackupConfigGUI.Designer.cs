namespace Bummer.Schedules.Controls {
	partial class FileBackupConfigGUI {
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
			this.cbCompress = new System.Windows.Forms.CheckBox();
			this.label4 = new System.Windows.Forms.Label();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.tbDirectory = new System.Windows.Forms.TextBox();
			this.btnSelectDirectory = new System.Windows.Forms.Button();
			this.cbBackupType = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.lvFileTypes = new System.Windows.Forms.ListView();
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.label3 = new System.Windows.Forms.Label();
			this.btnAddFileType = new System.Windows.Forms.Button();
			this.btnRemoveFileType = new System.Windows.Forms.Button();
			this.tbZipFilename = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.cbAddDateToZip = new System.Windows.Forms.CheckBox();
			this.label7 = new System.Windows.Forms.Label();
			this.btnBrowseForLocalTemp = new System.Windows.Forms.Button();
			this.tbLocalTempDir = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// cbCompress
			// 
			this.cbCompress.AutoSize = true;
			this.cbCompress.Location = new System.Drawing.Point(13, 237);
			this.cbCompress.Name = "cbCompress";
			this.cbCompress.Size = new System.Drawing.Size(115, 17);
			this.cbCompress.TabIndex = 7;
			this.cbCompress.Text = "Compress files (zip)";
			this.cbCompress.UseVisualStyleBackColor = true;
			this.cbCompress.CheckedChanged += new System.EventHandler(this.cbCompress_CheckedChanged);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(10, 17);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(100, 13);
			this.label4.TabIndex = 24;
			this.label4.Text = "Directory to backup";
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
			// tbDirectory
			// 
			this.tbDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbDirectory.Location = new System.Drawing.Point(116, 14);
			this.tbDirectory.Name = "tbDirectory";
			this.tbDirectory.Size = new System.Drawing.Size(301, 20);
			this.tbDirectory.TabIndex = 1;
			// 
			// btnSelectDirectory
			// 
			this.btnSelectDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSelectDirectory.Location = new System.Drawing.Point(423, 12);
			this.btnSelectDirectory.Name = "btnSelectDirectory";
			this.btnSelectDirectory.Size = new System.Drawing.Size(32, 23);
			this.btnSelectDirectory.TabIndex = 2;
			this.btnSelectDirectory.Text = "...";
			this.btnSelectDirectory.UseVisualStyleBackColor = true;
			this.btnSelectDirectory.Click += new System.EventHandler(this.btnSelectDirectory_Click);
			// 
			// cbBackupType
			// 
			this.cbBackupType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cbBackupType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbBackupType.FormattingEnabled = true;
			this.cbBackupType.Location = new System.Drawing.Point(116, 40);
			this.cbBackupType.Name = "cbBackupType";
			this.cbBackupType.Size = new System.Drawing.Size(270, 21);
			this.cbBackupType.TabIndex = 3;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(10, 43);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(67, 13);
			this.label1.TabIndex = 36;
			this.label1.Text = "Backup type";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(10, 67);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(51, 13);
			this.label2.TabIndex = 38;
			this.label2.Text = "File types";
			// 
			// lvFileTypes
			// 
			this.lvFileTypes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lvFileTypes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
			this.lvFileTypes.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
			this.lvFileTypes.HideSelection = false;
			this.lvFileTypes.Location = new System.Drawing.Point(116, 67);
			this.lvFileTypes.Name = "lvFileTypes";
			this.lvFileTypes.Size = new System.Drawing.Size(270, 164);
			this.lvFileTypes.TabIndex = 4;
			this.lvFileTypes.UseCompatibleStateImageBehavior = false;
			this.lvFileTypes.View = System.Windows.Forms.View.Details;
			this.lvFileTypes.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(10, 93);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(89, 78);
			this.label3.TabIndex = 40;
			this.label3.Text = "E.g. \"*.doc\" to\r\nbackup all files of\r\ntype doc.\r\nAdding no file\r\ntypes will backu" +
    "p\r\nall files";
			// 
			// btnAddFileType
			// 
			this.btnAddFileType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAddFileType.Location = new System.Drawing.Point(393, 67);
			this.btnAddFileType.Name = "btnAddFileType";
			this.btnAddFileType.Size = new System.Drawing.Size(62, 23);
			this.btnAddFileType.TabIndex = 5;
			this.btnAddFileType.Text = "Add...";
			this.btnAddFileType.UseVisualStyleBackColor = true;
			this.btnAddFileType.Click += new System.EventHandler(this.btnAddFileType_Click);
			// 
			// btnRemoveFileType
			// 
			this.btnRemoveFileType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnRemoveFileType.Enabled = false;
			this.btnRemoveFileType.Location = new System.Drawing.Point(393, 96);
			this.btnRemoveFileType.Name = "btnRemoveFileType";
			this.btnRemoveFileType.Size = new System.Drawing.Size(62, 23);
			this.btnRemoveFileType.TabIndex = 6;
			this.btnRemoveFileType.Text = "Remove";
			this.btnRemoveFileType.UseVisualStyleBackColor = true;
			this.btnRemoveFileType.Click += new System.EventHandler(this.btnRemoveFileType_Click);
			// 
			// tbZipFilename
			// 
			this.tbZipFilename.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbZipFilename.Location = new System.Drawing.Point(116, 260);
			this.tbZipFilename.Name = "tbZipFilename";
			this.tbZipFilename.Size = new System.Drawing.Size(270, 20);
			this.tbZipFilename.TabIndex = 8;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(10, 263);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(67, 13);
			this.label6.TabIndex = 43;
			this.label6.Text = "Zip-file name";
			// 
			// cbAddDateToZip
			// 
			this.cbAddDateToZip.AutoSize = true;
			this.cbAddDateToZip.Location = new System.Drawing.Point(13, 286);
			this.cbAddDateToZip.Name = "cbAddDateToZip";
			this.cbAddDateToZip.Size = new System.Drawing.Size(170, 17);
			this.cbAddDateToZip.TabIndex = 6;
			this.cbAddDateToZip.Text = "Add date + time to zip filename";
			this.cbAddDateToZip.UseVisualStyleBackColor = true;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label7.Location = new System.Drawing.Point(388, 263);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(52, 26);
			this.label7.TabIndex = 46;
			this.label7.Text = "without\r\nextension";
			// 
			// btnBrowseForLocalTemp
			// 
			this.btnBrowseForLocalTemp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnBrowseForLocalTemp.Location = new System.Drawing.Point(423, 307);
			this.btnBrowseForLocalTemp.Name = "btnBrowseForLocalTemp";
			this.btnBrowseForLocalTemp.Size = new System.Drawing.Size(32, 23);
			this.btnBrowseForLocalTemp.TabIndex = 10;
			this.btnBrowseForLocalTemp.Text = "...";
			this.btnBrowseForLocalTemp.UseVisualStyleBackColor = true;
			this.btnBrowseForLocalTemp.Click += new System.EventHandler(this.btnBrowseForLocalTemp_Click);
			// 
			// tbLocalTempDir
			// 
			this.tbLocalTempDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbLocalTempDir.Location = new System.Drawing.Point(116, 309);
			this.tbLocalTempDir.Name = "tbLocalTempDir";
			this.tbLocalTempDir.Size = new System.Drawing.Size(301, 20);
			this.tbLocalTempDir.TabIndex = 9;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(10, 312);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(102, 13);
			this.label5.TabIndex = 49;
			this.label5.Text = "Local temp directory";
			// 
			// FileBackupConfigGUI
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.btnBrowseForLocalTemp);
			this.Controls.Add(this.tbLocalTempDir);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.cbAddDateToZip);
			this.Controls.Add(this.tbZipFilename);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.btnRemoveFileType);
			this.Controls.Add(this.btnAddFileType);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.lvFileTypes);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.cbBackupType);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnSelectDirectory);
			this.Controls.Add(this.tbDirectory);
			this.Controls.Add(this.cbCompress);
			this.Controls.Add(this.label4);
			this.Name = "FileBackupConfigGUI";
			this.Size = new System.Drawing.Size(465, 349);
			this.Load += new System.EventHandler(this.FileBackupConfigGUI_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.CheckBox cbCompress;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.TextBox tbDirectory;
		private System.Windows.Forms.Button btnSelectDirectory;
		private System.Windows.Forms.ComboBox cbBackupType;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ListView lvFileTypes;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button btnAddFileType;
		private System.Windows.Forms.Button btnRemoveFileType;
		private System.Windows.Forms.TextBox tbZipFilename;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.CheckBox cbAddDateToZip;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Button btnBrowseForLocalTemp;
		private System.Windows.Forms.TextBox tbLocalTempDir;
		private System.Windows.Forms.Label label5;
	}
}
