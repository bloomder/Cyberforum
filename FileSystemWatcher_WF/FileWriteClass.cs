using System.IO;

namespace FileSystemWatcher_WF
{
    class FileWriteClass
    {
        FileStream fs;
        StreamWriter sw;
        public FileWriteClass()
        {
            if (!Directory.Exists(@"C:\Result"))
            {
                DirectoryInfo di = Directory.CreateDirectory(@"C:\Result");
                di.Attributes = FileAttributes.Directory | FileAttributes.Hidden;
            }
            fs = new FileStream(@"C:\Result\result.txt", FileMode.OpenOrCreate);
            fs.Close();
        }
        public void WriteText(string txt)
        {
            txt += "\r\n";
            //byte[] array = System.Text.Encoding.Default.GetBytes(txt);
            // запись массива байтов в файл
            sw.Write(txt);
        }
        public void OpenText()
        {
            //fs = new FileStream(@"C:\Result\result.txt", FileMode.OpenOrCreate);
            sw = new StreamWriter(@"C:\Result\result.txt", true, System.Text.Encoding.Default);
        }
        public void CloseText()
        {
            sw.Close();
        }
    }
}
