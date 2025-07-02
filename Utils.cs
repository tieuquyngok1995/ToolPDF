using System.Collections.Specialized;
using System.Text;
using System.Text.RegularExpressions;
using UglyToad.PdfPig;

namespace ToolPDF
{
    public static partial class Utils
    {

        [GeneratedRegex(@"(?<=[^.])\.(\s+|$)", RegexOptions.Compiled)]
        private static partial Regex DotSplitRegex();

        public static List<SettingRow> CachedSettings { get; } = [];

        /// <summary>
        /// Saves the current column settings (e.g., width, order, visibility) of the specified <see cref="DataGridView"/>
        /// to a persistent storage (e.g., config file, database).
        /// </summary>
        /// <param name="dataGrid">The <see cref="DataGridView"/> whose settings will be saved.</param>
        /// <remarks>
        /// This method is typically used to preserve user preferences or layout customizations across sessions.
        /// </remarks>
        public static void SaveGridToSettings(DataGridView dataGrid)
        {
            var rows = new StringCollection();
            CachedSettings.Clear();

            foreach (DataGridViewRow row in dataGrid.Rows)
            {
                if (row.IsNewRow) continue;

                string col1 = row.Cells[0].Value?.ToString() ?? "";
                string col2 = row.Cells[1].Value?.ToString() ?? "";
                string col3 = row.Cells[2].Value?.ToString() ?? "";

                if (string.IsNullOrWhiteSpace(col1) && string.IsNullOrWhiteSpace(col3))
                    continue;

                rows.Add($"{col1}||{col2}||{col3}");
                CachedSettings.Add(new SettingRow
                {
                    SearchKey = col1,
                    EndKey = col2,
                    Type = col3
                });
            }

            Properties.Settings.Default.gridSetting = rows;
            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// Applies saved column settings (e.g., width, order, visibility) to the specified <see cref="DataGridView"/>.
        /// </summary>
        /// <param name="dataGrid">The <see cref="DataGridView"/> to which the settings will be applied.</param>
        /// <remarks>
        /// This method typically loads user preferences or application-defined defaults from a config file, 
        /// database, or other storage mechanism and updates the grid accordingly.
        /// </remarks>
        public static void LoadGridFromSettings(DataGridView dataGrid)
        {
            var rows = Properties.Settings.Default.gridSetting;
            if (rows == null) return;

            dataGrid.Rows.Clear();
            CachedSettings.Clear();

            foreach (string? line in rows)
            {
                if (string.IsNullOrWhiteSpace(line)) continue;
                string[] parts = line.Split(["||"], StringSplitOptions.None);
                if (parts.Length >= 3)
                {
                    dataGrid.Rows.Add(parts[0], parts[1], parts[2]);

                    CachedSettings.Add(new SettingRow
                    {
                        SearchKey = parts[0],
                        EndKey = parts[1],
                        Type = parts[2]
                    });
                }
            }
        }

        /// <summary>
        /// Reads and extracts all text content from a PDF file at the specified path.
        /// </summary>
        /// <param name="filePath">The full path to the PDF file.</param>
        /// <returns>The extracted text content from the PDF, or an empty string if the file is empty or unreadable.</returns>
        public static string ReadPdfText(string filePath)
        {
            var text = new StringBuilder();

            using (var document = PdfDocument.Open(filePath))
            {
                foreach (var page in document.GetPages())
                {
                    text.AppendLine(page.Text.Trim());
                    text.AppendLine();
                }
            }

            return text.ToString();
        }

        public static string? ExtractValueBetweenKeysWithType(string input, string startKey, string type, string? endKey)
        {
            if (string.IsNullOrEmpty(input) || string.IsNullOrEmpty(startKey))
                return null;

            int startIndex = input.IndexOf(startKey);
            if (startIndex == -1) return null;

            startIndex += startKey.Length;

            int endIndex = !string.IsNullOrEmpty(endKey)
                ? input.IndexOf(endKey, startIndex)
                : input.IndexOf(' ', startIndex);

            if (endIndex == -1) endIndex = input.Length;

            string value = input[startIndex..endIndex].Trim();

            return type switch
            {
                "Text" => value,
                "Number" => value.Replace(",", string.Empty),
                _ => null
            };
        }

        #region Message 
        public static void ShowMessage(string message, string title = "Information",
                                   MessageBoxButtons buttons = MessageBoxButtons.OK,
                                   MessageBoxIcon icon = MessageBoxIcon.Information)
        {
            MessageBox.Show(AutoNewLine(message), title, buttons, icon);
        }

        public static DialogResult Confirm(string message, string title = "Confirmation")
        {
            return MessageBox.Show(AutoNewLine(message), title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        public static void ShowError(string message, string title = "Error")
        {
            MessageBox.Show(AutoNewLine(message), title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void ShowWarning(string message, string title = "Warning")
        {
            MessageBox.Show(AutoNewLine(message), title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private static string AutoNewLine(string message)
        {
            if (string.IsNullOrWhiteSpace(message)) return message;

            return DotSplitRegex().Replace(message, ".\r\n");
        }
        #endregion
    }
}
