using System.IO;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;
namespace WordWin
{
    class WordClass
    {
        public Word.Application word_app;
        public Word.Document word_doc;
        string pFile;
        public WordClass(string file)
        {            
            pFile = file;
            SettingsWord();
        }
        private void SettingsWord()
        {
            word_app = new Word.Application();
            word_app.Visible = false;            
        }
        public void OpenWordDoc()
        {
            if (File.Exists(pFile))
            {
                word_doc = word_app.Documents.Open(pFile);
            }
            else
            {
                MessageBox.Show("Нету Two.docx");
                word_app.Quit();
            }
        }
        public void CloseWordDoc()
        {
            word_doc.Close();
            word_app.Quit();
        }
    }
}
