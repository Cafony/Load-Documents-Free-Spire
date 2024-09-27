using Spire.Doc;
using Spire.Doc.Documents;
using System;
using System.Windows.Forms;

namespace Load_Docs_Free_Spire
{
    public class myOpenDocs
    {

        // Function to open DOCX or ODT files
        public string OpenDocument(string filePath)
        {
            // Create a new document object
            Document document = new Document();
            string _docText = string.Empty;

            try
            {
                // Load the DOCX or ODT file into the document object
                document.LoadFromFile(filePath);

                // Convert the document content to text (or you can display it in a richer format)
                _docText = document.GetText();               
             
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error opening document: " + ex.Message);
            }
            return _docText;
        }


        public void SaveDocument(string filePath, RichTextBox richTextBox, string format)
        {
            try
            {
                // Create a new document object
                Document document = new Document();
                               
                // Add a section and a paragraph
                Section section = document.AddSection();                
                Paragraph paragraph = section.AddParagraph();
                paragraph.AppendText(richTextBox.Text);
                
                // Determine the format to save in
                switch (format.ToLower())
                {
                    case "odt":
                        document.SaveToFile(filePath, FileFormat.Odt);
                        break;

                    case "docx":
                        document.SaveToFile(filePath, FileFormat.Docx);
                        break;

                    case "doc":
                        document.SaveToFile(filePath, FileFormat.Doc);
                        break;

                    case "rtf":
                        document.SaveToFile(filePath, FileFormat.Rtf);
                        break;

                    case "txt":
                        document.SaveToFile(filePath, FileFormat.Txt);
                        break;

                    default:
                        throw new ArgumentException("Erro");
                }

                MessageBox.Show("Documento salvo!");
            }
            catch (Exception ex)
            {
                throw new Exception("Erro  ao guardar documento: " + ex.Message);
            }
        }



    }
}
