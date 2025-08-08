using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace EdicoTI
{
    public static class MathpixXMLProcessor
    {
        /// <summary>
        /// Converts an HTML file to XHTML format with specific processing rules
        /// </summary>
        /// <returns>True if conversion was successful, false otherwise</returns>
        public static bool ConvertHtmlToXhtml()
        {
            try
            {
                // Open file dialog to select input file
                OpenFileDialog openFileDialog = new OpenFileDialog
                {
                    Title = "Apri file HTML",
                    Filter = "Formato HTML Mathpix (*.html)|*.html|Tutti i file (*.*)|*.*",
                    FilterIndex = 1,
                    RestoreDirectory = true
                };

                if (openFileDialog.ShowDialog() != DialogResult.OK)
                {
                    return false; // User cancelled
                }

                string inputFileName = openFileDialog.FileName;

                // Read the input file
                string body;
                using (StreamReader reader = new StreamReader(inputFileName, System.Text.Encoding.UTF8))
                {
                    body = reader.ReadToEnd();
                }

                // Extract content between body tags
                Match bodyMatch = Regex.Match(body, @"<body.*?>(.*?)</body>", RegexOptions.Singleline);
                if (!bodyMatch.Success)
                {
                    MessageBox.Show("Errore: impossibile trovare il tag <body> nel file.", "Errore di conversione",
                                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                body = bodyMatch.Groups[1].Value;

                string[,] replacements = new string[,]
{
            { "<mathmlword.*?</mathmlword>", "" },
            { "<asciimath.*?</asciimath>", "" },
            { "<tsv.*?</tsv>", "" },
            { "<figure.*?</figure>", "" },
            { "<latex.*?</latex>", "" },
            { "<mjx-container.*?</mjx-container>", "" },
            { "<br>", "<br/>" },
            { "<h1.*?>", "<p>" },
            { "<h2.*?>", "<p>" },
            { "<h3.*?>", "<p>" },
            { "<div[^>]*/>", "<p/>" },
            { "<div id=\"preview-content\">", "<p id=\"main\">" },
            { "<div.*?>", "<p>" },
            { "<ol.*?>", "" },
            { "<ul.*?>", "" },
            { "<li>", "<p>" },
            { "</li>", "</p>" },
            { "<td.*?>", "<p>" },
            { "</td>", "</p>" },
            { "</ol>", "" },
            { "</ul>", "" },
            { "</h1>", "</p>" },
            { "</h2>", "</p>" },
            { "</h3>", "</p>" },
            { "</div>", "</p>" },
            { "<span.*?>", "" },
            { "</span>", "" },
            { "<mathml.*?>", "" },
            { "</mathml>", "" },
            { "<table-markdown.*?>", "" },
            { "</table-markdown>", "" },
            { "<table.*?>", "" },
            { "</table>", "" },
            { "<tbody.*?>", "" },
            { "</tbody>", "" },
            { "<blockquote.*?>", "" },
            { "</blockquote>", "" },
            { "<tr.*?>", "" },
            { "</tr>", "" }
};

                for (int i = 0; i < replacements.GetLength(0); i++)
                {
                    body = Regex.Replace(body, replacements[i, 0], replacements[i, 1], RegexOptions.Singleline);
                }

                // Extract main content
                body = ExtractMainContent(body);
                if (body == null)
                {
                    return false; // Error already shown in ExtractMainContent
                }

                // Add XHTML header and footer
                string header = @"<?xml version=""1.0"" encoding=""utf-8""?>
<!DOCTYPE html PUBLIC ""-//W3C//DTD XHTML 1.1//EN"" ""http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd"">
<html xmlns=""http://www.w3.org/1999/xhtml"">
<head>
<title>converted</title>
</head>
<body>";

                string footer = "\n</body>\n</html>";
                body = header + "\n" + body + footer;

                // Convert hexadecimal entities to uppercase
                MatchCollection hexMatches = Regex.Matches(body, @"&#x[0-9a-fA-F]+;");
                foreach (Match match in hexMatches)
                {
                    string hexValue = match.Value.Replace("&#x", "").Replace(";", "");
                    int intValue = Convert.ToInt32(hexValue, 16);
                    string upperHexValue = $"&#x{intValue:X4};";
                    body = body.Replace(match.Value, upperHexValue);
                }

                // Generate output filename
                string outputFileName = Path.ChangeExtension(inputFileName, ".xhtml");

                // Write the output file
                using (StreamWriter writer = new StreamWriter(outputFileName, false, System.Text.Encoding.UTF8))
                {
                    writer.Write(body);
                    writer.Flush();
                }

                MessageBox.Show($"Conversione completata con successo!\nGenerato il file: {Path.GetFileName(outputFileName)}",
                               "Operazione completata", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Errore durante la conversione del file: {ex.Message}", "Errore di conversione",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Extracts content between <p id="main"> and the last </p> in the document
        /// </summary>
        /// <param name="htmlContent">HTML content to process</param>
        /// <returns>Extracted content without the main p tags, or null if error</returns>
        private static string ExtractMainContent(string htmlContent)
        {
            try
            {
                // Find <p id="main">
                int mainStart = htmlContent.IndexOf("<p id=\"main\">");
                if (mainStart == -1)
                {
                    MessageBox.Show("Errore: Impossibile individuare il segmento iniziale. Documento Mathpix non valido.", "Errore di conversione",
                                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }

                // Find the end of the opening tag <p id="main">
                int contentStart = htmlContent.IndexOf('>', mainStart) + 1;

                // Find the last </p> in the document
                int lastPEnd = htmlContent.LastIndexOf("</p>");
                if (lastPEnd == -1 || lastPEnd <= contentStart)
                {
                    MessageBox.Show("Errore: Impossibile individuare il segmento finale. Documento Mathpix non valido.", "Errore di conversione",
                                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }

                // Extract content between <p id="main"> and the last </p>
                string extractedContent = htmlContent.Substring(contentStart, lastPEnd - contentStart);

                return extractedContent;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error extracting main content: {ex.Message}", "Conversion Error",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}