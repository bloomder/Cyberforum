using System;

namespace Switch
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите 1-ое число");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите 2-ое число");
            int b = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите знак между ними");
            char znak = Convert.ToChar(Console.ReadLine());
            switch (znak)
            {
                case '+':
                    Console.WriteLine($"Результат - {a + b}");
                    break;
                case '-':
                    Console.WriteLine($"Результат - {a - b}");
                    break;
                default:
                    Console.WriteLine("Знак не распознан!");
                    break;
            }
            Console.ReadKey();
        }
    }
}
