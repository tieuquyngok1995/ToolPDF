namespace ToolPDF
{
    public partial class Main : Form
    {
        // Path folder
        string pathFolder;

        private List<string> listFiles;

        public Main()
        {
            listFiles = [];

            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            try
            {
                // get path folder in setting
                pathFolder = Properties.Settings.Default.pathFolder;

                txtPathFolder.Text = !string.IsNullOrEmpty(pathFolder) ? pathFolder : string.Empty;

                txtPathFolder.Select();
                txtPathFolder.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error during processing.\r\nError detail: " + ex.Message, "Error Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtPathFolder_TextChanged(object sender, EventArgs e)
        {
            pathFolder = txtPathFolder.Text.Trim();

            if (!string.IsNullOrEmpty(pathFolder) && !Path.IsPathRooted(pathFolder))
            {
                MessageBox.Show("Invalid Input Folder Path!!!");
                txtPathFolder.Text = string.Empty;
                pathFolder = string.Empty;
            }

            Properties.Settings.Default.pathFolder = pathFolder;
            Properties.Settings.Default.Save();
        }

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
                else
                {
                    txtPathFolder.Text = string.Empty;
                    pathFolder = string.Empty;

                    Properties.Settings.Default.pathFolder = string.Empty;
                    Properties.Settings.Default.Save();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error during processing.\r\nError detail: " + ex.Message, "Error Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            try
            {
                // Set cursor as hourglass
                Cursor.Current = Cursors.WaitCursor;
                if (!string.IsNullOrEmpty(txtPathFolder.Text) && Directory.Exists(txtPathFolder.Text))
                {
                    txtListFile.Text = string.Empty;
                    loadDirectory(txtPathFolder.Text);
                }
                else
                {
                    txtListFile.Text = string.Empty;
                    MessageBox.Show("Select Directory!!!");
                }

                // Set cursor as default arrow
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error during processing.\r\nError detail: " + ex.Message, "Error Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDataSeparation_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (string file in listFiles)
                {
                    string content = Utils.ReadPdfText(file);

                    txtResult.Text += content;
                    txtResult.Text += "\r\n";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error during processing.\r\nError detail: " + ex.Message, "Error Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region Function
        /// <summary>
        /// Load file and folder in directory
        /// </summary>
        /// <param name="pathFolder"></param>
        private void loadDirectory(string pathFolder)
        {
            DirectoryInfo directory = new(pathFolder);
            // Load files in folder
            loadFiles(string.Empty, pathFolder, directory.Name);

            loadSubDirectories(string.Empty, pathFolder);
        }

        /// <summary>
        /// Load files in folder
        /// </summary>
        /// <param name="pathFolder"></param>
        /// <param name="nameFolder"></param>
        private void loadFiles(string pathParentFolder, string pathFolder, string nameFolder)
        {
            string folder = nameFolder;
            if (!string.IsNullOrEmpty(pathParentFolder)) folder = pathFolder.Replace(pathParentFolder, string.Empty);

            string[] Files = Directory.GetFiles(pathFolder, "*.*");
            // Loop through them to see files
            foreach (string file in Files)
            {
                // Get info file
                FileInfo fileInfo = new(file);
                // Add info to data grid view
                txtListFile.Text += fileInfo.Name + "\r\n";
                listFiles.Add(fileInfo.FullName);
            }
        }

        /// <summary>
        /// Load sub folder in folder
        /// </summary>
        /// <param name="pathFolder"></param>
        private void loadSubDirectories(string pathParentFolder, string pathFolder)
        {
            // Get all subdirectories
            string[] pathSubFolder = Directory.GetDirectories(pathFolder);
            // Loop through them to see if they have any other subdirectories
            foreach (string subdirectory in pathSubFolder)
            {
                // Info sub folder
                DirectoryInfo subDirectory = new(subdirectory);
                // Load files in folder
                loadFiles(pathParentFolder, subdirectory, subDirectory.Name);
                // Load sub folder
                loadSubDirectories(pathFolder, subdirectory);
            }
        }
        #endregion
    }
}
