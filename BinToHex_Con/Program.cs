using System;

namespace BinToHex_Con
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите число в двоичной системе счисления");
            Console.WriteLine("{0:X}", Convert.ToInt64(Console.ReadLine(), 2));
            Console.ReadKey();
        }
    }
}
