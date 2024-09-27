using System;

using System.Windows.Forms;


namespace Load_Docs_Free_Spire
{
    public partial class Form1 : Form
    {
        myOpenDocs _myOpenDocs;
        public Form1()
        {
            InitializeComponent();
            _myOpenDocs = new myOpenDocs();
        }

        private void buttonLOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "All files (*.*)|*.*|Word (*.docx)|*.docx|OpenDocument (*.odt)|*.odt|Word (*.doc)|*.doc|Richtext (*.rtf)|*.rtf|Text File (*.txt)|*.txt";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string _filePath = openFileDialog.FileName;

                try
                {                    
                    string _myText = _myOpenDocs.OpenDocument(_filePath);
                    richTextBox1.Text = _myText;    

                }
                catch
                {
                    MessageBox.Show("Error: ");
                }
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Word (*.docx)|*.docx|OpenDocument (*.odt)|*.odt|Word (*.doc)|*.doc|Richtext (*.rtf)|*.rtf";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                string format = System.IO.Path.GetExtension(filePath).ToLower().Replace(".", ""); // Get file extension without the dot

                try
                {

                    //myOpenDocs openDoc = new myOpenDocs();     
                    _myOpenDocs.SaveDocument(filePath, richTextBox1, format);  // Call SaveDocument with file path, richTextBox, and format
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro: " + ex.Message);
                }
            }
        }
    }
}
