using System;
using System.IO;
using System.Text;

namespace ConReadWriteFile
{
    class Program
    {
        static void Main(string[] args)
        {
            String one_file = "ReadFile.in";
            string str = "";
            StreamWriter sw1 = new StreamWriter(one_file,false, Encoding.Default);
            sw1.WriteLine("one");
            sw1.WriteLine("two");
            sw1.WriteLine("three");
            sw1.Close();
            StreamReader sr1 = new StreamReader(one_file, Encoding.Default);
            while ((str = sr1.ReadLine()) != null)
            {
                Console.WriteLine(str);
            }
            sr1.Close();
            Console.ReadKey();
        }
    }
}
