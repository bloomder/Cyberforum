using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace BinWriteRead2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Test tst = new Test();
            Test[] tests = new Test[16];
            tests[0] = new Test("Germany", "Berlin", 357168, 80.8);
            tests[1] = new Test("France", "Paris", 640679, 64.7);
            tests[2] = new Test("Germany1", "Berlin1", 357168, 80.8);
            tests[3] = new Test("France1", "Paris1", 640679, 64.7);
            tests[4] = new Test("Germany2", "Berlin2", 357168, 80.8);
            tests[5] = new Test("France2", "Paris2", 640679, 64.7);
            tests[6] = new Test("Germany3", "Berlin3", 357168, 80.8);
            tests[7] = new Test("France3", "Paris3", 640679, 64.7);
            tests[8] = new Test("Germany4", "Berlin4", 357168, 80.8);
            tests[9] = new Test("France4", "Paris4", 640679, 64.7);
            tests[10] = new Test("Germany5", "Berlin5", 357168, 80.8);
            tests[11] = new Test("France5", "Paris5", 640679, 64.7);
            tests[12] = new Test("Germany6", "Berlin6", 357168, 80.8);
            tests[13] = new Test("France6", "Paris6", 640679, 64.7);
            tests[14] = new Test("Germany7", "Berlin7", 357168, 80.8);
            tests[15] = new Test("France7", "Paris7", 640679, 64.7);
            string path = @"C:\test.dat";
            BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.Create));
            foreach (Test s in tests)
            {
                writer.Write(s.Name);
                writer.Write(s.Capital);
                writer.Write(s.Area);
                writer.Write(s.People);
            }
            writer.Close();
            BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open));
            long count = 0;
            while (reader.PeekChar() > -1)
            {
                tst.Name = reader.ReadString();
                tst.Capital = reader.ReadString();
                tst.Area = reader.ReadInt32();
                tst.People = reader.ReadDouble();
                count++;
                dataGridView1.Rows.Add(tst.Name, tst.Capital, tst.Area, tst.People);
            }
            reader.Close();
        }
    }
    class Test
    {
        public string Name { get; set; }
        public string Capital { get; set; }
        public int Area { get; set; }
        public double People { get; set; }
        public Test(){}
        public Test(string name, string capital, int area, double people)
        {
            Name = name;
            Capital = capital;
            Area = area;
            People = people;
        }
    }
}
