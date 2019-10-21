using System;

namespace Class_Book_Console
{
    class BookClass
    {
        public String Author { get; set; }
        public String NameBook { get; set; }
        public String Publishing { get; set; }
        public int Year { get; set; }
        public int PageCount { get; set; }
        public BookClass(String author, String name_book, String publishing, int year, int page_count)
        {
            Author = author;
            NameBook = name_book;
            Publishing = publishing;
            Year = year;
            PageCount = page_count;
        }
        public void Show()
        {
            Console.Write($"{Author}\t");
            Console.Write($"    {NameBook}\t");
            Console.Write($"         {Publishing}\t");
            Console.Write($"        {Year}\t");
            Console.Write($"{PageCount}\t\r\n");
        }
    }
}
