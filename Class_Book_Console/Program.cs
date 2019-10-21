using System;
using System.Collections.Generic;

namespace Class_Book_Console
{
    //http://www.cyberforum.ru/csharp-beginners/thread2516577.html
    class Program
    {
        static void Main(string[] args)
        {
            List<BookClass> ListBooks = new List<BookClass>();
            ListBooks.Add(new BookClass("Клочков","Души из ада", "Дрофа", 1958, 120));
            ListBooks.Add(new BookClass("Мелков", "Души из рая", "Бест", 1960, 90));
            ListBooks.Add(new BookClass("Сунина", "Край ворот", "Гуголь", 2000 , 500));
            ListBooks.Add(new BookClass("Мелков","Демон", "Глория", 1985 , 170));
            ListBooks.Add(new BookClass("Клочков", "Катафалк", "Гербот", 1980, 170));
            ListBooks.Add(new BookClass("Сунина", "Грамм", "Дрофа", 1990, 220));

            Zaglavie();
            
            foreach (var item in ListBooks)
            {
                item.Show();
            }
            Console.WriteLine();
            bool a = true;
            string txt;
            int x;
            while (a)
            {
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1)Вывести список книг заданного автора");
                Console.WriteLine("2)Вывести список книг, выпущенное заданным издательством");
                Console.WriteLine("3)Вывести список книг, выпущенных после заданного года");
                Console.WriteLine("Чтобы выйти из программы нажмите 4, а потом 2 раза Enter");
                x =Convert.ToInt32(Console.ReadLine());
                switch (x)
                {
                    case 1:
                        Console.WriteLine("Введите фамилию:");
                        txt = Console.ReadLine();
                        Console.Clear(); Zaglavie();
                        foreach (var item in ListBooks)
                        {
                            if (item.Author.Equals(txt)) item.Show();
                        }
                        Console.WriteLine();
                        break;
                    case 2:
                        Console.WriteLine("Введите издательствао:");
                        txt = Console.ReadLine();
                        Console.Clear(); Zaglavie();
                        foreach (var item in ListBooks)
                        {
                            if (item.Publishing.Equals(txt)) item.Show();
                        }
                        Console.WriteLine();
                        break;
                    case 3:
                        Console.WriteLine("Введите год:");
                        txt = Console.ReadLine();
                        Console.Clear(); Zaglavie();
                        foreach (var item in ListBooks)
                        {
                            if (item.Year>=Convert.ToInt32(txt)) item.Show();
                        }
                        Console.WriteLine();
                        break;
                    default:
                        a = false;
                        break;
                }
            }
            Console.ReadKey();
        }
        static void Zaglavie()
        {
            Console.Write("Автор\t");
            Console.Write("    Название\t");
            Console.Write("         Издательство\t");
            Console.Write("Год\t");
            Console.Write("Страниц\t\r\n\r\n");
        }
    }
}
