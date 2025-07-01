using System.Text;
using UglyToad.PdfPig;

namespace ToolPDF
{
    public static class Utils
    {
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
    }
}
