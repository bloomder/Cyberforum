using System;

namespace Matrix_Con
{
    class Program
    {
        static void Main(string[] args)
        {
            int a=1, count=0, numb;
            int[,] mass;
            m1: { }
            Console.Write("Введите размерность квадратичной матрицы(1 число)!: ");
            try
            {
                a = int.Parse(Console.ReadLine());
                if(a<1)
                {
                    Console.WriteLine("Размерность квадратичной матрицы не должна быть меньше 2!");
                    goto m1;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                goto m1;
            }
            mass = new int[a, a];
            count = 0;
            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < a; j++)
                {
                    count++;
                    m2: { }
                    Console.Write("Введите " + count.ToString() + " элемент матрицы: ");
                    try
                    {
                        numb = int.Parse(Console.ReadLine());
                        if(numb>=0)
                        {
                            Console.WriteLine("Вы ввели отрицательное число!!!");
                            goto m2;
                        }
                        mass[i, j] = numb;
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex);
                        goto m1;
                    }
                }
            }
            Console.WriteLine("Ваша матрица:");
            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < a; j++)
                {
                    Console.Write("{0}\t", mass[i, j]);
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
