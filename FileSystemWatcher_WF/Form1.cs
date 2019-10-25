using System;
using System.Collections.Generic;
using System.IO;
using System.Security.AccessControl;
using System.Threading;
using System.Windows.Forms;

namespace FileSystemWatcher_WF
{
    public partial class Form1 : Form
    {
        FolderBrowserDialog fbd = new FolderBrowserDialog();
        List<string> list_folder_fisrt = new List<string>();
        List<string> list_folder = new List<string>();
        int ar = 0;
        List<FileSystemWatcher> list_fsw = new List<FileSystemWatcher>();
        FileSystemWatcher fsw;
        string str_txt = "";
        FileWriteClass fwc = new FileWriteClass();
        int count = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(fbd.ShowDialog()==DialogResult.OK) { list_folder_fisrt.Add(fbd.SelectedPath); richTextBox1.Text += (string)(fbd.SelectedPath + "\r\n"); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Visible = false; button1.Visible = false; button2.Visible = false; richTextBox1.Visible = false;
            Thread th = new Thread(ThreadMethod);
            if (StartSettings()) { th.Start(); }
            else { MessageBox.Show("Вы не выбрали папки!!!"); this.Visible = true; button1.Visible = true; button2.Visible = true; richTextBox1.Visible = true; }
        }
        private void ThreadMethod()
        {
            foreach (var item in list_folder_fisrt)
            {
                list_folder.Add(item.ToString());
                ReadDir(item.ToString());
            }
            foreach (var item in list_folder)
            {
                fsw = new FileSystemWatcher();                
                fsw.Path = item.ToString();
                SettingFSW();
                list_fsw.Add(fsw);
            }

            while(true)
            {

            }
        }

        private void SettingFSW()
        {
            //fsw.Filter = "*.*";
            fsw.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName;
            fsw.Created += OnCreated;
            fsw.Deleted += OnDeleted;
            fsw.Renamed += OnRenamed;
            try
            {
                fsw.EnableRaisingEvents = true;
            }
            catch(Exception ex) { }
        }

        private void OnRenamed(object sender, RenamedEventArgs e)
        {
            count++;
            str_txt = count + ") Папка: " + e.FullPath + "\r\n" + "Файл: " + e.OldName + " переименован в " + e.Name + " " + DateTime.Now + ".\r\n";
            fwc.OpenText();
            fwc.WriteText(str_txt);
            fwc.CloseText();
            int yp = 0;
        m1: { }
            try
            {
                File.Copy(e.FullPath, (string)(@"C:\Result\"+count.ToString()+".q"));
                str_txt = "Удалось сохранить\r\n";
                fwc.OpenText();
                fwc.WriteText(str_txt);
                fwc.CloseText();
            }
            catch (Exception ex)
            {
                yp++; Thread.Sleep(50);
                if (yp != 10) { goto m1; }
                else
                {
                    str_txt = "Не удалось сохранить\r\n";
                    fwc.OpenText();
                    fwc.WriteText(str_txt);
                    fwc.CloseText();
                }
            }
        }

        private void OnDeleted(object sender, FileSystemEventArgs e)
        {
            //count++;
            str_txt = "Папка: " + e.FullPath + "\r\n" + "Файл: " + e.Name + " удален." + DateTime.Now +"\r\n";
            fwc.OpenText();
            fwc.WriteText(str_txt);
            fwc.CloseText();            
        }

        private void OnCreated(object sender, FileSystemEventArgs e)
        {
            count++;
            str_txt = count + ") Папка: " + e.FullPath + "\r\n" + "Файл: " + e.Name + " создан." + DateTime.Now + "\r\n";
            fwc.OpenText();
            fwc.WriteText(str_txt);
            fwc.CloseText();
            int yp = 0;
        m1: { }
            try
            {
                File.Copy(e.FullPath, (string)(@"C:\Result\" + count.ToString() + ".q"));
                str_txt = "Удалось сохранить\r\n";
                fwc.OpenText();
                fwc.WriteText(str_txt);
                fwc.CloseText();
            }
            catch (Exception ex)
            {
                yp++; Thread.Sleep(50);
                if (yp != 10) { goto m1; }
                else
                {
                    str_txt = "Не удалось сохранить\r\n";
                    fwc.OpenText();
                    fwc.WriteText(str_txt);
                    fwc.CloseText();
                }
            }
        }

        private void ReadDir(string path)
        {
            DirectoryInfo dir = new DirectoryInfo(path);
            foreach (var item in dir.GetDirectories())
            {
                DirectorySecurity ds = item.GetAccessControl();

                if (Directory.Exists(item.FullName))
                {
                    if (item.FullName.Equals(@"C:\Users\Administrator\Documents\My Music")) { ar = ar; }
                    list_folder.Add(item.FullName);
                }
            }
        }

        private bool StartSettings()
        {
            if (list_folder_fisrt.Count == 0) return false;
            return true;
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (ar == 0)
            {
                if (e.KeyChar == 'W' || e.KeyChar=='w')
                {
                    ar = 1;
                }
                else { ar = 0; }
            }
            else
            {
                if (e.KeyChar == 'R' || e.KeyChar == 'r')
                {
                    richTextBox1.Visible = true;
                    button1.Visible = true;
                    button2.Visible = true;
                }
                else 
                {
                    ar = 0;
                }
            }
        }
    }
}
