using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Thread_Textboxs
{
    public partial class Form1 : Form
    {
        Thread thread1, thread2;
        public static int Num = 0, Num_2 = 0;
        public Form1()
        {
            InitializeComponent();
            thread1 = new Thread(mythread1);
            thread2 = new Thread(mythread2);
            thread1.IsBackground = true;
            thread2.IsBackground = true;
        }
        private void mythread1()
        {
            for (; Num < 10; Num++)
            {
                Thread.Sleep(1000);
                SetTextSafe(textBox1, Num.ToString());
            }
        }
        private void mythread2()
        {
            for (; Num_2 < 10; Num_2++)
            {
                Thread.Sleep(1000);// 1 секунда задержка иначе
                // Цикл очень быстро завершиться
                SetTextSafe(textBox2, Num_2.ToString());
            }
        }        

        private void button1_Click(object sender, EventArgs e)
        {
            thread1.Start();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void button1_KeyPress(object sender, KeyPressEventArgs e)
        {
            KeyLocation(button1, e.KeyChar);
        }
        private void KeyLocation(Control obj, char keyChar)
        {
            if ("Ww".Contains(keyChar.ToString()))
            {
                if (obj.InvokeRequired) obj.Invoke(new Action(() => obj.Location=new Point(obj.Location.X,obj.Location.Y-1)));
                else obj.Location = new Point(obj.Location.X, obj.Location.Y - 1);
            }
            if ("Aa".Contains(keyChar.ToString()))
            {
                if (obj.InvokeRequired) obj.Invoke(new Action(() => obj.Location = new Point(obj.Location.X - 1, obj.Location.Y)));
                else obj.Location = new Point(obj.Location.X - 1, obj.Location.Y);
            }
            if ("Ss".Contains(keyChar.ToString()))
            {
                if (obj.InvokeRequired) obj.Invoke(new Action(() => obj.Location = new Point(obj.Location.X, obj.Location.Y+1)));
                else obj.Location = new Point(obj.Location.X, obj.Location.Y + 1);
            }
            if ("Dd".Contains(keyChar.ToString()))
            {
                if (obj.InvokeRequired) obj.Invoke(new Action(() => obj.Location = new Point(obj.Location.X + 1, obj.Location.Y)));
                else obj.Location = new Point(obj.Location.X + 1, obj.Location.Y);
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            thread2.Start();
        }
        void SetTextSafe(Control obj, string newText)
        {
            if (obj.InvokeRequired) obj.Invoke(new Action<string>((s) => obj.Text = s), newText);
            else obj.Text = newText;
        }
    }
}
