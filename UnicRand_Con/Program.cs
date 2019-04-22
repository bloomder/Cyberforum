using System;

namespace UnicRand_Con
{
    class Program
    {
        static Random rand;
        static void Main(string[] args)
        {
            rand = new Random();
            int[] arr = new int[10];
            for (int i = 0; i < arr.Length; i++)// Цикл на создание уникальных чисел
            {
                arr[i] = i;
            }

            for (int i = 0; i < 10; i++) // цикл на количество сортировки
            {
                Randomize(ref arr);
            }

            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }
            Console.ReadKey();
        }
        static void Randomize(ref int[] mas)
        {
            int el1, el2, temp;
            el1 = rand.Next(9);
        m1: { }
            el2 = rand.Next(9);
            if (el1 == el2) goto m1;
            temp = mas[el1];
            mas[el1] = mas[el2];
            mas[el2] = temp;
        }
    }
}
