using System;
using System.IO;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;

namespace WordWork.WordFunctions
{
    class WordFunc
    {// Класс для работы с документами, удобен при модернизации, чтобы не сыпались ошибки, когда код описан в одном классе        
        public Word.Application word_app; // Экзмепляр класса Word.Application
        public Word.Document word_doc;// Экзмепляр класса Word.Document
        Word.Find find;
        string pFile;// Путь к файлу
        public WordFunc(string file) // Конструктор класса,file - путь файла word
        {
            pFile = file; // сохраняем в переменную класса
            SettingsWord();// Настраиваем приложение word
        }
        private void SettingsWord()
        {
            word_app = new Word.Application(); // Инициализируем экземпляо класса
            word_app.Visible = false;// Приложение делаем не видимым, оставляя только процесс
        }
        public void OpenWordDoc()
        {
            if (File.Exists(pFile)) // Проверяем наличия файла, чтобы потом не шерстить весь проект на поиск ошибки
            {
                word_doc = word_app.Documents.Open(pFile); // инициализируем экземпляр класса Word.Document и открываем
            }
            else
            {
                MessageBox.Show($"Нету {pFile}"); // Уведомляем себя что файла не существует
                word_app.Quit(); // Закрываем приложение, так как мы его уже открывали в конструкторе
            }
        }
        public void CloseWordDoc() // Функция для закрытия документа
        {
            word_doc.Close();
        }

        public void CloseWordApp() // Функция для закрытия приложения
        {
            word_app.Quit();
        }

        public void ReplaceWords(string str_old, string str_new)
        {
            try
            {
                find = word_app.Selection.Find;
                //app.Selection.Find;

                find.Text = str_old; // текст поиска
                find.Replacement.Text = str_new; // текст замены

                find.Execute(FindText: Type.Missing, MatchCase: false, MatchWholeWord: false, MatchWildcards: false,
                            MatchSoundsLike: Type.Missing, MatchAllWordForms: false, Forward: true, Wrap: Word.WdFindWrap.wdFindContinue,
                            Format: false, ReplaceWith: Type.Missing, Replace: Word.WdReplace.wdReplaceAll);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
