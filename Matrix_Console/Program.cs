using System;
using System.Threading;

namespace Matrix_Console
{
    class Program
    {
        public static int[,] mass;
        public static int a, b,k;
        static void Main(string[] args)
        {
        m1: { }
            Console.WriteLine("Введите размерность матрицы!");
            if( (!ReadConsole(out a)) || (!ReadConsole(out b)) )
            {
                Thread.Sleep(5000);
                Console.Clear();
                goto m1;
            }
            mass = new int[a,b];
            WriteMassive(a,b);
            InfoMartix(mass);
        m2: { }
            Console.Write("Введите число К: ");
            if (!ReadConsole(out k)) goto m2;
            KtoMath(mass, k);
            Console.ReadKey();
        }

        private static void KtoMath(int[,] mass, int k)// Ну тут уже сам
        {// mass[i,j] и само K. Как тебе нужно то и высчитвай))
            Console.WriteLine("Реализуй метод <<KtoMath>>!!!");
        }

        private static void InfoMartix(int[,] mass)
        {
            Console.WriteLine("Ваша матрица:");
            for (int i = 0; i < mass.GetLength(0); i++)
            {
                for (int j = 0; j < mass.GetLength(1); j++)
                {
                    Console.Write("{0,3}", mass[i, j]);
                }
                Console.WriteLine();
            }
        }

        private static void WriteMassive(int c, int v)// Функция записи элементов в матрицу
        {
            for (int i = 0; i < c; i++)
            {
                for (int j = 0; j < v; j++)
                {
                m1: { }
                    Console.Write("Введите [" + i.ToString() + "][" + j.ToString() + "] элемент матрицы:");
                    if (!ReadConsole(out mass[i, j])) goto m1;
                }
                
            }
        }

        private static bool ReadConsole(out int k)// Функция считывания чисел с консоли
        {// Если будет не число, вернет false
            try
            {
                k = Convert.ToInt32(Console.ReadLine());
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString()); k = 0;
                return false;
            }
        }
    }
}
