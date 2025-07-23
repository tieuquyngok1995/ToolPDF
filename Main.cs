namespace ToolPDF
{
    public partial class Main : Form
    {
        // Path folder
        private string pathFolder;
        private readonly List<string> listFiles;

        /// <summary>
        /// Initializes a new instance of the <see cref="Main"/> form,
        /// setting up UI components and loading initial state or configuration as needed.
        /// </summary>
        public Main()
        {
            pathFolder = string.Empty;
            listFiles = [];

            InitializeComponent();
        }

        /// <summary>
        /// Handles the Load event of the <see cref="Main"/> form.
        /// Performs initial setup tasks such as loading data, applying user settings,
        /// or initializing controls when the form is first displayed.
        /// </summary>
        /// <param name="sender">The source of the event (typically the form itself).</param>
        /// <param name="e">The event data.</param>
        private void Main_Load(object sender, EventArgs e)
        {
            try
            {
                // Get path folder in setting
                pathFolder = Properties.Settings.Default.pathFolder;
                txtPathFolder.Text = !string.IsNullOrEmpty(pathFolder) ? pathFolder : string.Empty;
                txtPathFolder.Select();
                txtPathFolder.Focus();

                // Get setting
                Utils.LoadGridFromSettings(dataGridViewSetting);
                AdjustLastColumnWidth();
            }
            catch (Exception ex)
            {
                Utils.ShowError("There was an error during processing.Error detail: " + ex.Message);
            }
        }

        /// <summary>
        /// Handles the TextChanged event of the <see cref="txtPathFolder"/> control.
        /// Triggered when the text in the folder path textbox changes.
        /// Typically used to validate the input or update related UI elements based on the new path.
        /// </summary>
        /// <param name="sender">The source of the event (usually the <see cref="TextBox"/> control).</param>
        /// <param name="e">The event data.</param>
        private void txtPathFolder_TextChanged(object sender, EventArgs e)
        {
            pathFolder = txtPathFolder.Text.Trim();

            if (!string.IsNullOrEmpty(pathFolder) && !Path.IsPathRooted(pathFolder))
            {
                Utils.ShowWarning("Folder path is missing. Please provide a valid path.");
                txtPathFolder.Text = string.Empty;
                pathFolder = string.Empty;
            }

            Properties.Settings.Default.pathFolder = pathFolder;
            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// Handles the Click event of the <see cref="btnSelectFolder"/> button.
        /// Opens a folder browser dialog for the user to select a folder, and updates the related UI with the selected path.
        /// </summary>
        /// <param name="sender">The source of the event (typically the button itself).</param>
        /// <param name="e">The event data.</param>
        private void btnSelectFolder_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog fbd = new();
                if (!string.IsNullOrEmpty(pathFolder)) fbd.SelectedPath = pathFolder;

                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    txtPathFolder.Text = fbd.SelectedPath;
                    pathFolder = fbd.SelectedPath;

                    Properties.Settings.Default.pathFolder = fbd.SelectedPath;
                    Properties.Settings.Default.Save();
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError("There was an error during processing.Error detail: " + ex.Message);
            }
        }

        /// <summary>
        /// Handles the Click event of the <see cref="btnReload"/> button.
        /// Reloads the contents of the currently selected folder, including files and subdirectories.
        /// </summary>
        /// <param name="sender">The source of the event (typically the reload button).</param>
        /// <param name="e">The event data.</param>
        private void btnReload_Click(object sender, EventArgs e)
        {
            try
            {
                // Set cursor as hourglass
                Cursor.Current = Cursors.WaitCursor;
                listFiles.Clear();

                if (!string.IsNullOrEmpty(txtPathFolder.Text) && Directory.Exists(txtPathFolder.Text))
                {
                    txtListFile.Text = string.Empty;
                    LoadDirectory(txtPathFolder.Text);
                }
                else
                {
                    txtListFile.Text = string.Empty;
                    Utils.ShowWarning("Please browse and select a folder path.");
                }

                lblNumFile.Visible = false;
                if (listFiles.Count > 0)
                {
                    lblNumFile.Text = lblNumFile.Text.Split(':')[0] + $": {listFiles.Count}";
                    lblNumFile.Visible = true;
                }
                // Set cursor as default arrow
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Utils.ShowError("There was an error during processing.Error detail: " + ex.Message);
            }
        }

        /// <summary>
        /// Handles the <c>RowsAdded</c> event of the <see cref="dataGridViewSetting"/> control.
        /// Triggered when one or more new rows are added to the DataGridView.
        /// This can be used to initialize default values, adjust formatting, or perform validation on the added rows.
        /// </summary>
        /// <param name="sender">The source of the event (usually the <see cref="DataGridView"/> control).</param>
        /// <param name="e">Provides data for the <c>RowsAdded</c> event, including the index and number of rows added.</param>
        private void dataGridViewSetting_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            AdjustLastColumnWidth();
        }

        private void dataGridViewSetting_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hit = dataGridViewSetting.HitTest(e.X, e.Y);
                if (hit.RowIndex >= 0)
                {
                    dataGridViewSetting.ClearSelection();
                    dataGridViewSetting.Rows[hit.RowIndex].Selected = true;

                    contextMenuSetting.Show(dataGridViewSetting, e.Location);
                }
            }
        }
        private void addRowMenu_Click(object sender, EventArgs e)
        {
            if (dataGridViewSetting.SelectedRows.Count > 1)
            {
                int selectedRowIndex = dataGridViewSetting.SelectedRows[0].Index;
                dataGridViewSetting.Rows.Insert(selectedRowIndex + 1, 1);
            }
            else
            {
                dataGridViewSetting.Rows.Add();
            }
        }

        private void deleteRowMenu_Click(object sender, EventArgs e)
        {
            if (dataGridViewSetting.Rows.Count == 1 || dataGridViewSetting.Rows.Count - 1 == dataGridViewSetting.SelectedRows[0].Index) return;

            if (dataGridViewSetting.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dataGridViewSetting.SelectedRows)
                {
                    dataGridViewSetting.Rows.Remove(row);
                }
            }
        }

        /// <summary>
        /// Handles the Click event of the <see cref="btnSave"/> button.
        /// Saves the current grid settings or application state, typically to a configuration file or persistent storage.
        /// </summary>
        /// <param name="sender">The source of the event (usually the Save button).</param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewSetting.Rows.Count < 2)
                {
                    Utils.ShowWarning("Settings have not been input. Unable to save.");
                    return;
                }
                Utils.SaveGridToSettings(dataGridViewSetting);
                if (Utils.CachedSettings.Count > 0) Utils.ShowMessage("The settings have been saved successfully.");
            }
            catch (Exception ex)
            {
                Utils.ShowError("There was an error during processing.Error detail: " + ex.Message);
            }
        }

        /// <summary>
        /// Handles the Click event of the <see cref="btnDataSeparation"/> button.
        /// Initiates the data separation process, typically based on user-defined criteria or current configuration settings.
        /// </summary>
        /// <param name="sender">The source of the event (usually the Data Separation button).</param>
        /// <param name="e">The event data.</param>
        private void btnDataSeparation_Click(object sender, EventArgs e)
        {
            try
            {
                if (listFiles.Count < 1) Utils.ShowWarning("No PDF files found. Please load the file list before proceeding.");

                txtResult.Text = string.Empty;
                foreach (string file in listFiles)
                {
                    string content = Utils.ReadPdfText(file);

                    string result = string.Empty;
                    foreach (SettingRow row in Utils.CachedSettings)
                    {
                        result += Utils.ExtractValueBetweenKeysWithType(content, row.SearchKey, row.Type, row.EndKey) + "\t";
                    }

                    txtResult.Text += result.TrimEnd('\t') + "\r\n";
                }
                txtResult.Text = txtResult.Text.TrimEnd('\r', '\n');
            }
            catch (Exception ex)
            {
                Utils.ShowError("There was an error during processing.Error detail: " + ex.Message);
            }
        }

        /// <summary>
        /// Handles the Click event of the <see cref="btnCopy"/> button.
        /// Copies selected data (e.g., text, rows, or cell values) to the clipboard,
        /// allowing the user to paste it elsewhere.
        /// </summary>
        /// <param name="sender">The source of the event (typically the Copy button).</param>
        /// <param name="e">The event data.</param>
        private void btnCopy_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtResult.Text)) return;

                Clipboard.SetText(txtResult.Text);
            }
            catch (Exception ex)
            {
                Utils.ShowError("There was an error during processing.Error detail: " + ex.Message);
            }
        }

        /// <summary>
        /// Handles the Click event of the <see cref="btnClear"/> button.
        /// Clears relevant input fields, selections, or data displays to reset the form to its initial state.
        /// </summary>
        /// <param name="sender">The source of the event (typically the Clear button).</param>
        /// <param name="e">The event data.</param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                listFiles.Clear();
                txtListFile.Clear();
                lblNumFile.Visible = false;

                txtResult.Text = string.Empty;
            }
            catch (Exception ex)
            {
                Utils.ShowError("There was an error during processing.Error detail: " + ex.Message);
            }
        }

        #region Function
        /// <summary>
        /// Loads the contents of the specified directory, including both files and immediate subdirectories.
        /// Internally calls <see cref="LoadSubDirectories"/> and <see cref="LoadFiles"/>.
        /// </summary>
        /// <param name="pathFolder">The full path of the directory to load.</param>
        private void LoadDirectory(string pathFolder)
        {
            // Load files in folder
            LoadFiles(pathFolder);
            // Load sub folder
            LoadSubDirectories(pathFolder);
        }

        /// <summary>
        /// Loads files from the specified folder path, with optional support for subdirectory loading.
        /// </summary>
        /// <param name="pathFolder">The full path of the folder to scan for files.</param>
        /// <param name="isSub">
        /// If set to <c>true</c>, indicates that the call is for a subdirectory (recursive load or special handling);
        /// otherwise, loads files from the main folder.
        /// </param>
        private void LoadFiles(string pathFolder, bool isSub = false)
        {
            string[] Files = Directory.GetFiles(pathFolder, "*.*");
            // Loop through them to see files
            foreach (string file in Files)
            {
                // Get info file
                FileInfo fileInfo = new(file);
                string displayName = isSub ? $"{fileInfo.Directory?.Name}\\{fileInfo.Name}" : fileInfo.Name;
                // Add info to data grid view
                txtListFile.Text += displayName + "\r\n";
                listFiles.Add(fileInfo.FullName);
            }
        }

        /// <summary>
        /// Loads all immediate subdirectories from the specified folder path
        /// and performs necessary operations on each of them (e.g., display, processing, etc.).
        /// </summary>
        /// <param name="pathFolder">The full path of the folder to scan for subdirectories.</param>
        private void LoadSubDirectories(string pathFolder)
        {
            // Get all subdirectories
            string[] pathSubFolder = Directory.GetDirectories(pathFolder);
            // Loop through them to see if they have any other subdirectories
            foreach (string subdirectory in pathSubFolder)
            {
                // Load files in folder
                LoadFiles(subdirectory, true);
                // Load sub folder
                LoadSubDirectories(subdirectory);
            }
        }

        /// <summary>
        /// Adjusts the width of the last visible column in the grid so that the total width 
        /// of all visible columns fits the available space without horizontal scrolling.
        /// 
        /// This method is typically used when the number of rows exceeds a certain threshold 
        /// (e.g., more than 5 rows) and ensures that no extra empty space remains at the end 
        /// of the grid.
        /// </summary>
        private void AdjustLastColumnWidth()
        {
            int columnIndex = 2;
            if (dataGridViewSetting.Columns.Count <= columnIndex) return;
            // Get width
            int scrollBarWidth = SystemInformation.VerticalScrollBarWidth;
            int availableWidth = dataGridViewSetting.ClientSize.Width;
            // Calculate width
            int totalWidth = dataGridViewSetting.RowHeadersVisible ? dataGridViewSetting.RowHeadersWidth : 0;
            totalWidth = totalWidth + dataGridViewSetting.Columns[0].Width + dataGridViewSetting.Columns[0].Width;

            int typeWidth = availableWidth - totalWidth;
            bool hasVerticalScroll = dataGridViewSetting.RowCount > 4;
            if (hasVerticalScroll)
            {
                typeWidth -= scrollBarWidth;
            }

            dataGridViewSetting.Columns[columnIndex].Width = Math.Max(10, typeWidth - 2);
        }
        #endregion
    }
}