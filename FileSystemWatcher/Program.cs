using System;
using System.IO;


namespace FileSystemWatcher
{
    class Program
    {
          public static void Main()
          {
                FileSystemWatcher watcher = new FileSystemWatcher();
                Console.WriteLine("Ожидание активности....");
                //watcher.SynchronizingObject = this;
                watcher.Path = Path.GetDirectoryName(@"C:\Windows"); //не забудьте поменять путь
                //watcher.Filter = Path.GetFileName(@"c:\a.txt");
                watcher.NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.Size;
                watcher.Deleted += new System.IO.FileSystemEventHandler(OnDelete);
                watcher.Renamed += new System.IO.RenamedEventHandler(OnRenamed);
                watcher.Changed += new System.IO.FileSystemEventHandler(OnChanged);
                watcher.Created += new System.IO.FileSystemEventHandler(OnCreate);
                watcher.EnableRaisingEvents = true;
                Console.ReadLine();
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
