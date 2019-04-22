using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BindingSourceFilter
{
    public partial class Form1 : Form
    {
        List<DataInfo> list;
        Random rand;
        public Form1()
        {
            InitializeComponent();
            list = new List<DataInfo>();
            rand = new Random();
            dataGridView.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Name", HeaderText = "Имя" });
            dataGridView.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Year", HeaderText = "Год" });
            for (int i = 0; i < 100; i++)
            {
                list.Add( new DataInfo( RandomClass.Names[rand.Next(0,99)] , rand.Next(1980,2000) ) );
            }
            dataGridView.DataSource = list;
        }
    }    
}
