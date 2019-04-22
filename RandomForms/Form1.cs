using System;
using System.Collections;
using System.Windows.Forms;

namespace RandomForms
{
    class MyForm<T> where T : new()
    {
        public T form = new T();
    }
    public partial class Form1 : Form
    {
        ArrayList myArr;
        int count = 0;
        public Form1()
        {
            InitializeComponent();
            myArr = new ArrayList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //str = str.Replace("/", "");
            myArr.Add(new MyForm<Form2>());
        }
    }
}
