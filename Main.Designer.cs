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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            groupSetting = new GroupBox();
            dataGridViewSetting = new DataGridView();
            findText = new DataGridViewTextBoxColumn();
            type = new DataGridViewComboBoxColumn();
            btnDataSeparation = new Button();
            btnReload = new Button();
            btnSelectFolder = new Button();
            txtPathFolder = new TextBox();
            label1 = new Label();
            groupBox1 = new GroupBox();
            txtListFile = new RichTextBox();
            groupBox2 = new GroupBox();
            txtResult = new RichTextBox();
            groupSetting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewSetting).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupSetting
            // 
            groupSetting.Controls.Add(dataGridViewSetting);
            groupSetting.Controls.Add(btnDataSeparation);
            groupSetting.Controls.Add(btnReload);
            groupSetting.Controls.Add(btnSelectFolder);
            groupSetting.Controls.Add(txtPathFolder);
            groupSetting.Controls.Add(label1);
            groupSetting.Font = new Font("Verdana", 10F);
            groupSetting.Location = new Point(9, 1);
            groupSetting.Name = "groupSetting";
            groupSetting.Size = new Size(563, 229);
            groupSetting.TabIndex = 0;
            groupSetting.TabStop = false;
            groupSetting.Text = "Input Setting";
            // 
            // dataGridViewSetting
            // 
            dataGridViewSetting.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Verdana", 10F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridViewSetting.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewSetting.ColumnHeadersHeight = 24;
            dataGridViewSetting.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewSetting.Columns.AddRange(new DataGridViewColumn[] { findText, type });
            dataGridViewSetting.Location = new Point(13, 67);
            dataGridViewSetting.MultiSelect = false;
            dataGridViewSetting.Name = "dataGridViewSetting";
            dataGridViewSetting.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewSetting.Size = new Size(474, 126);
            dataGridViewSetting.TabIndex = 5;
            // 
            // findText
            // 
            findText.HeaderText = "Find Text";
            findText.Name = "findText";
            findText.Resizable = DataGridViewTriState.False;
            findText.Width = 170;
            // 
            // type
            // 
            type.HeaderText = "Type";
            type.Items.AddRange(new object[] { "Text", "Number" });
            type.Name = "type";
            type.Resizable = DataGridViewTriState.False;
            type.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // btnDataSeparation
            // 
            btnDataSeparation.Image = Properties.Resources.icon_execute_16x16;
            btnDataSeparation.Location = new Point(406, 18);
            btnDataSeparation.Name = "btnDataSeparation";
            btnDataSeparation.Size = new Size(24, 24);
            btnDataSeparation.TabIndex = 4;
            btnDataSeparation.UseVisualStyleBackColor = true;
            btnDataSeparation.Click += btnDataSeparation_Click;
            // 
            // btnReload
            // 
            btnReload.Image = Properties.Resources.icon_reload_16x16;
            btnReload.Location = new Point(280, 18);
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
            groupBox1.Controls.Add(txtListFile);
            groupBox1.Location = new Point(9, 263);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(563, 83);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "List File PDF";
            // 
            // txtListFile
            // 
            txtListFile.Dock = DockStyle.Fill;
            txtListFile.Location = new Point(3, 20);
            txtListFile.Name = "txtListFile";
            txtListFile.Size = new Size(557, 60);
            txtListFile.TabIndex = 0;
            txtListFile.Text = "";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(txtResult);
            groupBox2.Location = new Point(8, 376);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(563, 93);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Result";
            // 
            // txtResult
            // 
            txtResult.Dock = DockStyle.Fill;
            txtResult.Location = new Point(3, 20);
            txtResult.Name = "txtResult";
            txtResult.Size = new Size(557, 70);
            txtResult.TabIndex = 0;
            txtResult.Text = "";
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(8F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(575, 480);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(groupSetting);
            Font = new Font("Verdana", 10F);
            Name = "Main";
            Text = "Tool PDF";
            Load += Main_Load;
            groupSetting.ResumeLayout(false);
            groupSetting.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewSetting).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
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
        private DataGridViewTextBoxColumn findText;
        private DataGridViewComboBoxColumn type;
    }
}
