using System;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            int rez = 0;
            int[,] mass = new int[3, 3] { { 1, 7, 4 }, { 4, 5, 12 }, { 3, 6, 8 } };
            for (int i = 0; i < mass.GetUpperBound(0)+1; i++)
            {
                if ((i + 1) % 2 != 0)
                {
                    for (int j = 0; j < mass.Length/ (mass.GetUpperBound(0)+1) ; j++)
                    {
                        if(mass[i,j]%2==0)
                        {
                            rez += mass[i, j];
                        }
                    }
                }
            }
            Console.WriteLine(rez);
            Console.ReadKey();
        }
    }
}
