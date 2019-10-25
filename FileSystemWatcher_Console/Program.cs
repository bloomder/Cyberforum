using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;

namespace FileSystemWatcher_Console
{
    class Program
    {
        static bool a = true;
        static List<String> list_folder = new List<string>();
        static List<String> list_files = new List<string>();
        static List<FileSystemWatcher> list_fsw = new List<FileSystemWatcher>();
        static FileSystemWatcher fsw;
        static FileStream fs;
        static int ib = 0; 
        public static void Main()
        {            
            Thread th = new Thread(Method);
            //sw = new StreamWriter(@"C:\Result\result.txt", false, Encoding.Default);
            
            th.Start();
            Console.ReadLine();
        }
        static void Method()
        {
            Console.WriteLine("Поток запущен");
            List<String> list = new List<string>();
            list.Add(@"C:\Test");
            list.Add(@"C:\Users\bloom\Downloads");
            list.Add(@"C:\Users\bloom\OneDrive\Рабочий стол");
            foreach (var item in list)
            {
                ReadDir(item);
            }
            Console.WriteLine("Поток завершен");
            Console.ReadLine();
        }
        static void ReadDir(string path)
        {
            var dir = new DirectoryInfo(path);
            fsw = new FileSystemWatcher();
            SettingsFSW(path);
            list_fsw.Add(fsw);
            list_folder.Add(path);
            //Console.WriteLine(path);
            foreach (var item in dir.GetFiles())
            {
                list_files.Add(item.FullName);
            }
            foreach (var item in dir.GetDirectories())
            {
                ReadDir(item.FullName);
            }
        }

        private static void SettingsFSW(string path)
        {
            fsw.Path = path;
            fsw.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName;
            fsw.Filter = "*.*";
            //fsw.Changed += OnChanged;
            fsw.Created += OnCreated;
            fsw.Deleted += OnDeleted;
            fsw.Renamed += OnRenamed;
            fsw.EnableRaisingEvents = true;
        }

        private static void OnRenamed(object sender, RenamedEventArgs e)
        {
            Console.WriteLine($"File: {e.OldName} переименован в {e.Name}");
            CopyFile(e.FullPath, e.Name, e.ChangeType.ToString());
        }

        private static void OnDeleted(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine($"File: {e.Name} удален");
        }

        private static void OnCreated(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine($"File: {e.Name} создан");
            CopyFile(e.FullPath, e.Name, e.ChangeType.ToString());
        }

        static bool CheckFile(string path)
        {
            return true;
        }
        private static void OnChanged(object source, FileSystemEventArgs e)
        {
            // Specify what is done when a file is changed, created, or deleted.
            Console.WriteLine($"File: {e.FullPath} {e.ChangeType}");
            if(e.ChangeType.ToString()=="Created")
            {
                Console.WriteLine("Условие выполнено");
            }
        }
        static void CopyFile(string path, string name, string txt)
        {
            ib++;
            //sw= new StreamWriter(@"C:\Result\result.txt", false, Encoding.Default);
            string text = ib.ToString() +") " + path + " " + txt+" "+DateTime.Now.ToString();
        m1: { }
            try
            {
                File.Copy(path, @"C:\Result");
                Console.WriteLine("File copy");
            }
            catch(Exception ex)
            {
                Thread.Sleep(50);
                Console.WriteLine("File no copy");
                goto m1;
            }
            File.Move((string)(@"C:\Result\" + "name"), (string)(ib.ToString() + ".q"));
            //sw.WriteLine(text);
            //sw.Close();
        }
    }
}
