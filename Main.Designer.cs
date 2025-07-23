using System.Windows.Forms;

namespace ToolPDF
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            groupSetting = new GroupBox();
            btnSave = new Button();
            dataGridViewSetting = new DataGridView();
            searchKey = new DataGridViewTextBoxColumn();
            endKey = new DataGridViewTextBoxColumn();
            type = new DataGridViewComboBoxColumn();
            btnDataSeparation = new Button();
            btnReload = new Button();
            btnSelectFolder = new Button();
            txtPathFolder = new TextBox();
            label1 = new Label();
            groupBox1 = new GroupBox();
            lblNumFile = new Label();
            txtListFile = new RichTextBox();
            groupBox2 = new GroupBox();
            btnClear = new Button();
            btnCopy = new Button();
            txtResult = new RichTextBox();
            contextMenuSetting = new ContextMenuStrip(components);
            addRow = new ToolStripMenuItem();
            deleteRow = new ToolStripMenuItem();
            groupSetting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewSetting).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            contextMenuSetting.SuspendLayout();
            SuspendLayout();
            // 
            // groupSetting
            // 
            groupSetting.Controls.Add(btnSave);
            groupSetting.Controls.Add(dataGridViewSetting);
            groupSetting.Controls.Add(btnDataSeparation);
            groupSetting.Controls.Add(btnReload);
            groupSetting.Controls.Add(btnSelectFolder);
            groupSetting.Controls.Add(txtPathFolder);
            groupSetting.Controls.Add(label1);
            groupSetting.Font = new Font("Verdana", 10F);
            groupSetting.Location = new Point(9, 1);
            groupSetting.Name = "groupSetting";
            groupSetting.Size = new Size(460, 188);
            groupSetting.TabIndex = 0;
            groupSetting.TabStop = false;
            groupSetting.Text = "Input Setting";
            // 
            // btnSave
            // 
            btnSave.Image = Properties.Resources.icon_save_16x16;
            btnSave.Location = new Point(399, 19);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(24, 24);
            btnSave.TabIndex = 6;
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // dataGridViewSetting
            // 
            dataGridViewSetting.AllowUserToResizeRows = false;
            dataGridViewSetting.BackgroundColor = SystemColors.Control;
            dataGridViewSetting.BorderStyle = BorderStyle.Fixed3D;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = SystemColors.Control;
            dataGridViewCellStyle4.Font = new Font("Verdana", 10F);
            dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dataGridViewSetting.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewSetting.ColumnHeadersHeight = 24;
            dataGridViewSetting.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewSetting.Columns.AddRange(new DataGridViewColumn[] { searchKey, endKey, type });
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = SystemColors.Control;
            dataGridViewCellStyle6.Font = new Font("Verdana", 10F);
            dataGridViewCellStyle6.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.False;
            dataGridViewSetting.DefaultCellStyle = dataGridViewCellStyle6;
            dataGridViewSetting.Location = new Point(10, 51);
            dataGridViewSetting.MultiSelect = false;
            dataGridViewSetting.Name = "dataGridViewSetting";
            dataGridViewSetting.RowHeadersWidth = 27;
            dataGridViewSetting.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewSetting.ScrollBars = ScrollBars.Vertical;
            dataGridViewSetting.ShowCellToolTips = false;
            dataGridViewSetting.Size = new Size(440, 126);
            dataGridViewSetting.TabIndex = 5;
            dataGridViewSetting.RowsAdded += dataGridViewSetting_RowsAdded;
            dataGridViewSetting.MouseDown += dataGridViewSetting_MouseDown;
            // 
            // searchKey
            // 
            searchKey.HeaderText = "Search Key";
            searchKey.Name = "searchKey";
            searchKey.Resizable = DataGridViewTriState.True;
            searchKey.Width = 150;
            // 
            // endKey
            // 
            endKey.HeaderText = "End Key";
            endKey.Name = "endKey";
            endKey.Width = 150;
            // 
            // type
            // 
            dataGridViewCellStyle5.BackColor = SystemColors.Control;
            type.DefaultCellStyle = dataGridViewCellStyle5;
            type.HeaderText = "Type";
            type.Items.AddRange(new object[] { "Text", "Number" });
            type.Name = "type";
            type.Resizable = DataGridViewTriState.False;
            type.SortMode = DataGridViewColumnSortMode.Automatic;
            type.Width = 110;
            // 
            // btnDataSeparation
            // 
            btnDataSeparation.Image = Properties.Resources.icon_execute_16x16;
            btnDataSeparation.Location = new Point(427, 19);
            btnDataSeparation.Name = "btnDataSeparation";
            btnDataSeparation.Size = new Size(24, 24);
            btnDataSeparation.TabIndex = 4;
            btnDataSeparation.UseVisualStyleBackColor = true;
            btnDataSeparation.Click += btnDataSeparation_Click;
            // 
            // btnReload
            // 
            btnReload.Image = Properties.Resources.icon_reload_16x16;
            btnReload.Location = new Point(280, 19);
            btnReload.Name = "btnReload";
            btnReload.Size = new Size(24, 24);
            btnReload.TabIndex = 3;
            btnReload.UseVisualStyleBackColor = true;
            btnReload.Click += btnReload_Click;
            // 
            // btnSelectFolder
            // 
            btnSelectFolder.Image = Properties.Resources.icon_folder_16x16;
            btnSelectFolder.Location = new Point(252, 19);
            btnSelectFolder.Name = "btnSelectFolder";
            btnSelectFolder.Size = new Size(24, 24);
            btnSelectFolder.TabIndex = 2;
            btnSelectFolder.UseVisualStyleBackColor = true;
            btnSelectFolder.Click += btnSelectFolder_Click;
            // 
            // txtPathFolder
            // 
            txtPathFolder.Location = new Point(129, 18);
            txtPathFolder.Name = "txtPathFolder";
            txtPathFolder.Size = new Size(118, 24);
            txtPathFolder.TabIndex = 1;
            txtPathFolder.TextChanged += txtPathFolder_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 21);
            label1.Name = "label1";
            label1.Size = new Size(119, 17);
            label1.TabIndex = 0;
            label1.Text = "Select Directory";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lblNumFile);
            groupBox1.Controls.Add(txtListFile);
            groupBox1.Location = new Point(9, 189);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(460, 130);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "List File PDF";
            // 
            // lblNumFile
            // 
            lblNumFile.AutoSize = true;
            lblNumFile.Location = new Point(283, 108);
            lblNumFile.Name = "lblNumFile";
            lblNumFile.Size = new Size(148, 17);
            lblNumFile.TabIndex = 7;
            lblNumFile.Text = "Number of pdf files:";
            lblNumFile.TextAlign = ContentAlignment.MiddleRight;
            lblNumFile.Visible = false;
            // 
            // txtListFile
            // 
            txtListFile.Location = new Point(10, 18);
            txtListFile.Name = "txtListFile";
            txtListFile.ReadOnly = true;
            txtListFile.Size = new Size(440, 88);
            txtListFile.TabIndex = 0;
            txtListFile.Text = "";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnClear);
            groupBox2.Controls.Add(btnCopy);
            groupBox2.Controls.Add(txtResult);
            groupBox2.Location = new Point(9, 319);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(460, 148);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Result";
            // 
            // btnClear
            // 
            btnClear.Image = Properties.Resources.icon_clear_16x16;
            btnClear.Location = new Point(427, 114);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(24, 24);
            btnClear.TabIndex = 8;
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnCopy
            // 
            btnCopy.Image = Properties.Resources.icon_copy_16x16;
            btnCopy.Location = new Point(399, 114);
            btnCopy.Name = "btnCopy";
            btnCopy.Size = new Size(24, 24);
            btnCopy.TabIndex = 7;
            btnCopy.UseVisualStyleBackColor = true;
            btnCopy.Click += btnCopy_Click;
            // 
            // txtResult
            // 
            txtResult.Location = new Point(10, 18);
            txtResult.Name = "txtResult";
            txtResult.ReadOnly = true;
            txtResult.Size = new Size(440, 88);
            txtResult.TabIndex = 0;
            txtResult.Text = "";
            // 
            // contextMenuSetting
            // 
            contextMenuSetting.Items.AddRange(new ToolStripItem[] { addRow, deleteRow });
            contextMenuSetting.Name = "contextMenuSetting";
            contextMenuSetting.Size = new Size(181, 70);

            // 
            // addRow
            // 
            addRow.Name = "addRow";
            addRow.Size = new Size(180, 22);
            addRow.Text = "Add row";
            addRow.Click += new System.EventHandler(this.addRowMenu_Click);
            // 
            // deleteRow
            // 
            deleteRow.Name = "deleteRow";
            deleteRow.Size = new Size(180, 22);
            deleteRow.Text = "Delete";
            deleteRow.Click += new System.EventHandler(this.deleteRowMenu_Click);
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(8F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(478, 475);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(groupSetting);
            Font = new Font("Verdana", 10F);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Main";
            Text = "Tool PDF";
            Load += Main_Load;
            groupSetting.ResumeLayout(false);
            groupSetting.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewSetting).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            contextMenuSetting.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupSetting;
        private Label label1;
        private TextBox txtPathFolder;
        private Button btnSelectFolder;
        private GroupBox groupBox1;
        private RichTextBox txtListFile;
        private Button btnReload;
        private Button btnDataSeparation;
        private GroupBox groupBox2;
        private RichTextBox txtResult;
        private DataGridView dataGridViewSetting;
        private Button btnSave;
        private Label lblNumFile;
        private Button btnClear;
        private Button btnCopy;
        private DataGridViewTextBoxColumn searchKey;
        private DataGridViewTextBoxColumn endKey;
        private DataGridViewComboBoxColumn type;
        private ContextMenuStrip contextMenuSetting;
        private ToolStripMenuItem addRow;
        private ToolStripMenuItem deleteRow;
    }
}
