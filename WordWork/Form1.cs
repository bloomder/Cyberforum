using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WordWork.Resource;
using WordWork.WordFunctions;

namespace WordWork
{
    public partial class Form1 : Form
    {
        Task task; // экземпляр класса Task
        WordFunc wf; // Экземпляр класса WordFunc
        int count_tb = 19;// Количество полей, для написания инфы
        int count_bt = 3;//Количество кнопок, для деактивации во время обработки
        DiagShab form2; // Создаем экземпляр формы DiagShab
        string str = "";// переменная, для проверки всяких путей
        StreamWriter sw;// для записи информации в файл об ИП
        StreamReader sr;// для чтения информации из файла об ИП
        bool bool_tb = false;// знак, что все текстбоксы заполнены.
        bool bool_his = false;// знак кнопки "История"
        DirectoryInfo di;
        string name_comp;
        DateTime dateTime;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (!LocaleFiles()) TroubleShab.Visible = true; // Делаем видимым оповещение label(TroubleShab)
            for (int i = 0; i < Shablons.Shablons.bool_shab.Length; i++)// Цикл на метки шаблонов
            {// При загрузки формы, все метки true
                Shablons.Shablons.bool_shab[i] = true;
            }
            Shablons.Shablons.value_check_shab = Shablons.Shablons.shablons.Length;// указываем количество выбранных шаблонов
            label21.Text = Shablons.Shablons.value_check_shab.ToString();// Кидаем значение на форму
            //DebugMode();// Метод заполнения формы информацией, чтобы при проверке каждый раз не прописывать
            tb19.Text = dtb1.Text; // сохраняем в текстбокс, тем самым избавив себя от лишних условий в различии контролов(все текстбоксы)
            // текстбокс сделал невидимым
        }
        private bool LocaleFiles()// Метод проверяет наличие всех шаблонных файлов на диске "C" в папке "Shablons"             
        {// если отсутствуют, проверяет наличие всех файлов в папке с этим приложением, если всё есть, добавлет в папку на диск "С" 
            // даже если 1 файл остутствует в папке C:\Shablons, он его копирует из папки Shablons с этим приложением
            // и в случае ошибки возврашает false
            string file;
            bool check_def_files = false;// Знак, сигнализирующий, что все файлы имеются в папке Shablons с этим приложением
            bool create_dir = false;// Знак, если папка по каким то причинам не создалась, чтобы в бесконечный цикл не попасть с меткой
            for (int i = 0; i < Shablons.Shablons.shablons.Length; i++)// Цикл на количество файлов шаблона
            {
                m1: { }
                file = @"C:\Shablons\" + Shablons.Shablons.shablons[i]; // В переменную записываем полный путь файла шаблона
                if (!File.Exists(file))// Проверяем наличие
                {// Если нет выполняется этот блок кода
                    if (!Directory.Exists(@"C:\Shablons\")) // Проверяем наличие папки
                    {// Если нет папки, создаем обернув в try catch
                        if (create_dir == false)// проверка, на то что была ли комманда на создание папки
                        {
                            try
                            {
                                Directory.CreateDirectory(@"C:\Shablons\"); // создаем папку
                            }
                            catch (Exception ex)// В случаи ошибки, выскочет окошко с ошибкой
                            {
                                MessageBox.Show(ex.ToString());
                                return false;
                            }
                            create_dir = true;// Помечаем, что команда на создание папки была предпринята
                            goto m1;// скачем на метку
                        }
                        else
                        {
                            MessageBox.Show("Не получается создать папку <Shablons> на диске <С>!");
                            return false; // Возвращаем flase, сигнализируя, что что-то тут не так
                        }
                    }
                    else // Если все таки папка существует
                    {// То проверяем наличие папки рядом с этим приложением
                     // P.S. Я бы попробовал бы содержимое этих файлов записал бы переменные и создавал бы не парясь с проверкой папок и файлов
                     // Если будет нужно могу помозговать и попробовать.
                        if (!Directory.Exists(Application.StartupPath+@"\Shablons\"))
                        {// Если отсутствует папка с этим приложением, оповещаем клиента.
                            MessageBox.Show("Отсутствует папка <Shablons> рядом с этим приложением!!!");
                            return false;
                        }
                        else
                        {// Если все таки присутствует, проверяем наличие всех файлов в этой папке.
                            if (check_def_files == false)
                            {
                                for (int j = 0; j < Shablons.Shablons.shablons.Length; j++)
                                {
                                    file = Application.StartupPath + @"\Shablons\" + Shablons.Shablons.shablons[j];
                                    if (!File.Exists(file))
                                    {// Если отсутствует какой-то файл, оповещаем клиента и прекращаем дальнейшие действия
                                        MessageBox.Show("Не все файлы содержаться в папке <Shablons> рядом с этим приложением");
                                        return false;
                                    }
                                }
                                // Если добрались до этого кода, значит все файлы в наличии
                                check_def_files = true;// Помечаем знак, что все ок, чтобы по нескольку раз не проходить по коду
                                // Копируем файл из папки Shablons с этим приложением в папку Shablons на диске "С"
                                try
                                {
                                    File.Copy((Application.StartupPath + @"\Shablons\" + Shablons.Shablons.shablons[i]), (@"C:\Shablons\" + Shablons.Shablons.shablons[i]));
                                }
                                catch (Exception ec)
                                {
                                    MessageBox.Show(ec.ToString());
                                    return false;
                                }
                            }
                            else
                            {// Копируем файл из папки Shablons с этим приложением в папку Shablons на диске "С"
                                try
                                {
                                    File.Copy((Application.StartupPath + @"\Shablons\" + Shablons.Shablons.shablons[i]), (@"C:\Shablons\" + Shablons.Shablons.shablons[i]));
                                }
                                catch(Exception ec)
                                {
                                    MessageBox.Show(ec.ToString());
                                    return false;
                                }
                            }
                        }

                    }
                }
                // Если да, то смотрим другой файл шаблона
            }// если все файлы на месте и не выскочили из метода в цикли, то все файлы в наличии
            return true;// и возвращаем true - сигнализируя, что все в порядке
        }
        private void DebugMode()
        {
            tb1.Text = "123"; // Номер договора
            tb2.Text = "ООО ИГРА";//место составления
            tb3.Text = "ИП Хворов";//имя компании или ИП
            tb4.Text = "150000";// Стоимость услуг(100 000)
            tb5.Text = "Сто пятдесят тысяч";// сумма прописью 
            tb6.Text = "Хворов Алексей Иванович";//ФИО представителя
            tb7.Text = "г. Москва ул. Минская д.1 корп.1";//адрес обьекта там где работаем
            tb8.Text = "г. Москва ул. Минская д.1 корп.1";//юридический адрес
            tb9.Text = "г. Москва ул. Минская д.1 корп.1"; //фактический адрес
            tb10.Text = "1021545877";//ОГРН
            tb11.Text = "10245889";//ИНН
            tb12.Text = "102314587";//КПП
            tb13.Text = "10325647898";//расчетнй счет
            tb14.Text = "ПАО ВТБ";//наименования банка
            tb15.Text = "103154872001244";//корреспонденсткий счет
            tb16.Text = "1302457";//БИК
            tb17.Text = "+74951234567";//телефон
            tb18.Text = "sergo@yandex.ru";//имейл
            tb19.Text = dtb1.Text;// Дата составления
        }
        private void ReadInfo()// считываем информацию с формы
        {
            for (int i = 1; i <= count_tb; i++)
            {
                SettingsApp.information[i - 1] = (Controls["tb" + i.ToString()] as TextBox).Text;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            form2 = new DiagShab(Shablons.Shablons.bool_shab);// Инициализируем экземпляр и посылаем в конструктор метки шаблонов(bool_shab)
            form2.ShowDialog();// Открываем форму
            label21.Text = Shablons.Shablons.value_check_shab.ToString();// Как форма закроется отображаем количество выбранных чекбоксов
        }

        private void tb_KeyPress(object sender, KeyPressEventArgs e) // Повесил этот метод на событие KeyPress в tb1, в свойстве контрола
        {//  * "" : < > / ?  нельзя эти символы ввести
            if (
                (e.KeyChar != '*') &&
                (e.KeyChar != '"') &&
                (e.KeyChar != ':') &&
                (e.KeyChar != '<') &&
                (e.KeyChar != '>') &&
                (e.KeyChar != '/') &&
                (e.KeyChar != '\\') &&
                (e.KeyChar != '?')
               )
            { return; }
            else e.Handled = true;
        }

        private void tb3_KeyPress(object sender, KeyPressEventArgs e) // Повесил этот метод на событие KeyPress в tb3 в свойстве контрола
        {//  * : < > / ?  нельзя эти символы ввести
            if (
                (e.KeyChar != '*') &&
                //(e.KeyChar != '"') &&
                (e.KeyChar != ':') &&
                (e.KeyChar != '<') &&
                (e.KeyChar != '>') &&
                (e.KeyChar != '/') &&
                (e.KeyChar != '\\') &&
                (e.KeyChar != '?')
               )
            { return; }
            else e.Handled = true;
        }

        private void createDoc_Click(object sender, EventArgs e)
        {
            if(TroubleShab.Visible==true)// Если оповещение видно
            {//  посылаем мессадж клиенту
                MessageBox.Show("Разберитесь с шаблонами или перезапустите программу!!!");
            }
            else
            {// если все в порядке 
                bool_tb = true;// Ставим знак true, если все поля будут написаны, true так и останется
                for (int i = 1; i <= count_tb; i++)// Цикл на количество полей(textbox's)
                {
                    if ((Controls["tb" + i.ToString()] as TextBox).Text.Equals("")) { bool_tb = false; break; }
                    // Если хоть одно поле не будет заполнено знак сменится на false и прервется цикл
                }
                if (bool_tb)// проверка знака
                {// Все поля задействены, идем дальше
                    ReadInfo();// считываем и сохранаем инфу с формы
                    SettingBt(false); // Enabled делаем false во всех кнопках
                    task = new Task(FuncObr);// Инициализируем экземпляр
                    task.Start();// запускаем в отдельном потоке, чтобы форма не лагала
                }
                else
                {// Если все таки проверку не прошли, посылаем мессадж клиенту
                    MessageBox.Show("Не все поля заполнены!!!");
                }
            }
        }
        private void SettingBt(bool b)// Метод чтобы включать и выключать кнопки
        {// Чтобы не возникало ошибки "доступ к контролу не из того потока", использовался invoke
            for (int i = 1; i <= count_bt; i++)
            {
                if((Controls["button"+i.ToString()]as Button).InvokeRequired)
                {
                    (Controls["button" + i.ToString()] as Button).Invoke(new Action(() => (Controls["button" + i.ToString()] as Button).Enabled = b));
                }
                else
                {
                    (Controls["button" + i.ToString()] as Button).Enabled = b;
                }
            }
        }
        private void FuncObr()
        {
            //str = Application.StartupPath + "\\" + SettingsApp.information[2].Replace("\"","") + "\\"; // проверяем наличие папки с названием ИП
            str = @"C:\Shablons" + "\\" + SettingsApp.information[2].Replace("\"", "") + "\\"; // проверяем наличие папки с названием ИП
            // SettingsApp.information[2].Replace("\"","") - кидает имя ИП без кавычек в путь, кавычки заменяются пустым местом(то есть удаляются)
            if (!Obrabotka.CheckDir(str))
            {// Если отсутствует
                try
                {
                    Directory.CreateDirectory(str); // создаем папку с названием ИП
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                WriteInfo(str+"info.txt"); // записываем в файл инфу об этом ИП, обычно для этого используют базы данных
                // внутри этой папки создаем папку с номером договора
                str += SettingsApp.information[0] + "\\";
                try
                {
                    Directory.CreateDirectory(str); // создаем папку с номером договора
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                ObrWord(str);//
            }
            else
            {// Если существует, чекаем папку с номером договора
                //str = Application.StartupPath + "\\" + SettingsApp.information[2].Replace("\"", "") + "\\" + SettingsApp.information[0]+"\\";
                str = @"C:\Shablons" + "\\" + SettingsApp.information[2].Replace("\"", "") + "\\" + SettingsApp.information[0] + "\\";
                if (!Obrabotka.CheckDir(str))
                {// Если отсутствует папка с номером договора
                    try
                    {
                        Directory.CreateDirectory(str); // создаем папку с номером договора
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                    ObrWord(str);
                }
                else// Иначе посылаем мессадж клиенту
                {//
                    MessageBox.Show("Номер договора с этим ИП уже существует!!!");
                }
            }                        
            SettingBt(true); // Enabled делаем true во всех кнопках 
        }
        private void ObrWord(string path)
        {
            for (int i = 0; i < Shablons.Shablons.shablons.Length; i++)
            {
                if(Shablons.Shablons.bool_shab[i])// проверяем с массивом, где отмечали какие шаблоны нам нужны
                {
                    File.Copy((@"C:\Shablons\" + Shablons.Shablons.shablons[i]), (path + Shablons.Shablons.shablons[i])); // Копируем файлы
                    // диска "С:\Shablons" в папку с программой "Название_ИП\Номер_договора"                    
                    wf = new WordFunc(path + Shablons.Shablons.shablons[i]);
                    wf.OpenWordDoc();
                    for (int o = 0; o < Shablons.Shablons.rep_shablons.Length; o++)
                    {
                        wf.ReplaceWords(Shablons.Shablons.rep_shablons[o], SettingsApp.information[o]);
                    }
                    wf.CloseWordDoc();
                    wf.CloseWordApp();                    
                }
            }
        }
        private void WriteInfo(string file)// Запись в файл информации с формы.
        {
            try
            {
                sw = new StreamWriter(file, false, Encoding.Default);
                for (int i = 0; i < SettingsApp.information.Length; i++)
                {
                    sw.WriteLine(SettingsApp.information[i]);
                }
                sw.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void dtb1_ValueChanged(object sender, EventArgs e) // при изменении даты, чтобы инфа в текстбоксе тоже изменилась
        {
            tb19.Text = dtb1.Text;
        }

        private void button2_Click(object sender, EventArgs e)// Кнопка "История"
        {
            if(bool_his)
            {
                bool_his = false;
                listBox1.Visible = false; // Скрываем listbox 
                listBox1.Items.Clear(); // очищаем listbox
            }
            else
            {
                bool_his = true;
                listBox1.Visible = true;// показываем listbox
                //di = new DirectoryInfo(Application.StartupPath); // Получаем инфу по папке, где запущено приложение
                di = new DirectoryInfo(@"C:\Shablons\");// Получаем инфу по папке
                foreach (var item in di.GetDirectories())// Перебираем все папки лежащие внутри папки : "C:\Shablons\"
                {
                    if (File.Exists(item.FullName + @"\info.txt"))// Если внутри этой папки есть файл info.txt
                    {// Добавляем в listbox только имя папки, без полного пути
                        listBox1.Items.Add(item.Name);
                    }
                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //listBox1.SelectedItem.ToString();
            //str = Application.StartupPath + "\\" + listBox1.SelectedItem.ToString() + "\\info.txt"; // полный путь к файлу info.txt
            str = @"C:\Shablons\" + "\\" + listBox1.SelectedItem.ToString() + "\\info.txt"; // полный путь к файлу info.txt
            sr = new StreamReader(str, Encoding.Default); // инициализируем экземпляр StreamReader
            for (int i = 1; i < SettingsApp.information.Length; i++)
            {
                (Controls["tb"+i.ToString()]as TextBox).Text = SettingsApp.information[i-1] = sr.ReadLine();
                //Считываем строку и пишем в контрол, в массив 
            }
            dateTime = DateTime.Parse(tb19.Text);
            dtb1.Text = dateTime.ToString();
        }
    }
}
