using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BinReadWrite_Win_
{
    public partial class Form1 : Form
    {
        FileStream fs;
        BinaryReader br;
        BinaryWriter bw;
        string file = "One.bin";
        long count = 0;
        string str = "";
        byte[] b_int16 = new byte[2];
        byte[] b_char = new byte[2];
        char a = 'A';
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ////////////////////////////////////////////////////////////////////////////////////////////
            ///           FileStream
            /// fs.Seek - перемещяет указатель в потоке
            m1: { }
            fs = new FileStream(file,FileMode.OpenOrCreate,FileAccess.ReadWrite);
            
            if (fs.Length != 0)
            {
                count = 0;
                for(;count<fs.Length;)
                {
                    
                    fs.Read(b_int16, 0, 2);
                    count += 2;
                    fs.Read(b_char, 0, 2);
                    count += 2;
                    comboBox1.Items.Add(BitConverter.ToInt16(b_int16,0));
                    comboBox2.Items.Add(BitConverter.ToChar(b_char,0));
                }
                fs.Close();
            }
            else
            {
                for (int i = 1; i < 6; i++)
                {
                    b_int16 = BitConverter.GetBytes((UInt16)i);
                    b_char = BitConverter.GetBytes((byte)(a)); a++;
                    fs.Write(b_int16, 0, 2);
                    fs.Write(b_char, 0, 2);
                }
                fs.Close();
                goto m1;
            }
            //////////////////////////////////////////////////////////////////////////
            ///          BinaryReader и BinaryWriter
            ///  br.BaseStream.Seek - перемещяет указатель в потоке
            file = "Two.bin";
            m2: { }            

            if (File.Exists(file))
            {
                count = 0;
                br = new BinaryReader(File.Open(file, FileMode.Open));
                
                for (; count < br.BaseStream.Length;)
                {
                    comboBox3.Items.Add(br.ReadInt16()); count += 2;
                    comboBox4.Items.Add(br.ReadChar()); count += 2;
                }
                br.Close();
            }
            else
            {
                bw = new BinaryWriter(File.Open(file,FileMode.Create));
                for (int i = 1; i < 7; i++) // Единственный минус, последнюю итерацию он не записывает.
                {// Или я что-то упустил
                    bw.Write((Int16)i);
                    bw.Write((Char)a); a++;
                }
                bw.Close();
                goto m2;
            }
        }
    }
}
