using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IF_app_con
{
    class Program
    {
        static void Main(string[] args)
        {
            int f1 = 90;
            int f2 = 100;
            int f3 = 150;

            if(met(f1,f2)==met(f1,f3))
            {
                Console.Write("f1 " + (f2>f3?"f2 f3":"f3 f2"));                
            }
            else
            {
                if(met(f2,f1)==met(f2,f3))
                {
                    Console.Write("f2 " + (f1 > f3 ? "f1 f3" : "f3 f1"));
                }
                else
                {
                    if (met(f3, f1) == met(f3, f2))
                    {
                        Console.Write("f3 " + (f1 > f2 ? "f1 f2" : "f2 f1"));
                    }
                }
            }

            Console.ReadKey();
        }
        private static int met(int a, int b)
        {
            return a > b ? a : b;
        }
    }
}
