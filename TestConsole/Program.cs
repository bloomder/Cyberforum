using System;

namespace TestConsole
{
    class Program
    {
        static double[] mass;
        static int razm;
        static Random rand = new Random();
        
        static void Main(string[] args)
        {
            m1: { }
            Console.Write("Введите размерность одномерного массива: ");
            try
            {
                razm = int.Parse(Console.ReadLine());
                if(razm<2)
                {
                    Console.WriteLine("Размерность массива, должна быть больше 1");
                    goto m1;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                goto m1;
            }
            mass = new double[razm];
            Console.WriteLine("Ваш массив:");
            for (int j = 0; j < razm; j++)
            {//-15.6, 53.3
                m2: { }
                mass[j] = rand.Next(-15,53)+(rand.Next(1,99)/(double)100);
                if ((mass[j] < 15.6) && (mass[j] > 53.3)) { goto m2; }
                Console.Write("{0}\t", mass[j]);
            }
            Console.ReadKey();
        }
    }
}
