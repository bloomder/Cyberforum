using System;

namespace Random_Con
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(new Random().Next(0, 10));
            }
            Console.ReadKey();
        }
    }
}
