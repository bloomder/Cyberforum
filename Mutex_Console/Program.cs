using System;
using System.Collections.Generic;
using System.Threading;

namespace Mutex_Console
{
    class Program
    {
        static Mutex mutexObj = new Mutex();
        public static int waiting = 0;

        //static int CHAIRS = 5;
        static bool haircut_chair = false; //не занято

        static Semaphore haircut_chairs = new Semaphore(1, 1);
        static Thread hairdresser = new Thread(Hairdresser);
        static Random r = new Random();
        static List<Thread> list = new List<Thread>();

        static void Main(string[] args)
        {
            hairdresser.Name = "Hairdresser ";
            hairdresser.Start();

            int i = 1;
            while (true)
            {
                Thread myThread = new Thread(Customer);
                myThread.Name = "Посетитель " + i.ToString();
                myThread.Start();
                Thread.Sleep(r.Next(1000, 3000));
                i++;
            }

            Console.ReadLine();
        }
        public static void Customer()
        {
            if(haircut_chairs.WaitOne())
            {
                Console.WriteLine(Thread.CurrentThread.Name.ToString() + " пришел.");
                if (haircut_chair == true)
                {
                    if (waiting < 6)
                    {
                        waiting++;
                        Console.WriteLine(Thread.CurrentThread.Name.ToString() + " ожидает на кресле " + waiting.ToString());
                        hairdresser.Join();

                    }
                    else
                    {
                        Console.WriteLine(Thread.CurrentThread.Name.ToString() + " уходит. Нет мест.");
                    }
                }
                if(waiting==0)
                Console.WriteLine(Thread.CurrentThread.Name.ToString() + " занял кресло для стрижки");
                haircut_chair = true;
                hairdresser.Join();
            }
            haircut_chairs.Release();
        }

        public static void Hairdresser()
        {
            while (true)
            {
                if (mutexObj.WaitOne())
                {
                    if ((waiting == 0) && (haircut_chair == false))
                    {
                        Console.WriteLine("Посетителей нету - парикмахер спит");
                        Thread.Sleep(r.Next(500, 1500));

                        switch(r.Next(1,2))
                        {
                            case 1: mutexObj.WaitOne(r.Next(1000, 3000)); break;
                            default:break;
                        }
                    }
                    if (haircut_chair == true)
                    {
                        Console.WriteLine("Парикмахер стрижет");
                        haircut_chairs.Release();
                        Thread.Sleep(r.Next(6000, 8000));
                        Console.WriteLine("Парикмахер  провожает клиента до двери");
                        Thread.Sleep(r.Next(3000, 4000));
                        haircut_chair = false;
                        haircut_chairs.Release();
                    }
                }
                mutexObj.ReleaseMutex();
            }
        }
    }
}
