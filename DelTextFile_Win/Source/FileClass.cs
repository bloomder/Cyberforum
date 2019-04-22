using System.IO;
using System.Text;
using System.Windows.Forms;

namespace DelTextFile_Win.Source
{
    class FileClass
    {
        StreamReader sr;
        StreamWriter sw;
        string file;
        public FileClass(string a)
        {
            file = a;
        }
        private bool SW()
        {
            return true;
        }
        public void Read(ref string a)
        {            
            if (!File.Exists(file)) { sw = new StreamWriter(file, false, Encoding.Default); sw.Close(); sw = null; }
            sr = new StreamReader(file, Encoding.Default);
            if (sr.BaseStream.Length == 0) { MessageBox.Show("Файл пуст!!!"); sr.Close(); sr = null; }
            else
            {
                a = sr.ReadToEnd(); sr.Close(); sr = null;
                MessageBox.Show("Файл считан!!!");
            }
        }
        public void WriteEnd(string a)
        {
            sw = new StreamWriter(file, true, Encoding.Default);            
            sw.WriteLine(a);
            sw.Close(); sw = null;
        }
        public void ReWrite()
        {
            sw = new StreamWriter(file, false, Encoding.Default);            
            sw.Close(); sw = null;
        }
    }
}
