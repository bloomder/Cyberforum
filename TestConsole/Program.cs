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
            int[][] A = new int[][] { new int[] { 1, 2, 3, 4 }, new int[] { 5, 6, 7, 8, 9, 10 }, new int[] { 11, 12, 13 }, new int[] { 14, 15 } };
            int b = A.Length;            
            int[] C = new int[b];
            for (int i = 0; i < b; i++)
            {
                C[i] = A[i].Length;
            }
            int[,] a = new int[,] { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 10, 11, 12 }};
            b = a.GetUpperBound(0)+1;
            int[] c = new int[b];
            for (int i = 0; i < b; i++)
            {
                for (int j = 0; j < a.Length/(b); j++)
                {
                    c[i] += a[i,j];
                }
            }
            Console.ReadKey();
        }
    }
}
