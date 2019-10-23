using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystemWatcher_Console
{
    class Program
    {
        static FileSystemWatcher watcher = new FileSystemWatcher();
        static List<String> list = new List<string>();
        public static void Main()
        {
            Console.WriteLine("Ожидание активности....");
            //watcher.SynchronizingObject = this;
            


            watcher.Path = Path.GetDirectoryName(@"C:\Windows"); //не забудьте поменять путь

            //AddEvents();
            Console.WriteLine($"В системе {list.Count} папок");
            Console.ReadLine();
        }
        public void GetNames(String path)
        {
            DirectoryInfo dir = new DirectoryInfo(path);
            foreach (var item in dir.GetDirectories())
            {
                list.Add(item.FullName);
            }
        }
        public static void AddEvents()
        {
            watcher.Filter = "*.*";
            watcher.NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.Size;
            watcher.Deleted += new System.IO.FileSystemEventHandler(OnDelete);
            watcher.Renamed += new System.IO.RenamedEventHandler(OnRenamed);
            watcher.Changed += new System.IO.FileSystemEventHandler(OnChanged);
            watcher.Created += new System.IO.FileSystemEventHandler(OnCreate);
            watcher.EnableRaisingEvents = true;
        }
        public static void OnChanged(object source, FileSystemEventArgs e)
        {
            Console.WriteLine("Файл: {0} {1}", e.FullPath, e.ChangeType.ToString());
        }
        public static void OnRenamed(object source, RenamedEventArgs e)
        {
            Console.WriteLine("Файл переименован из {0} в {1}", e.OldName, e.FullPath);
        }
        public static void OnDelete(object source, FileSystemEventArgs e)
        {
            Console.WriteLine("Файл: {0} удален", e.FullPath);
        }
        public static void OnCreate(object source, FileSystemEventArgs e)
        {
            Console.WriteLine("Файл: {0} создан", e.FullPath);
        }
    }
}
