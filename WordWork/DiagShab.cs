using System.Windows.Forms;

namespace WordWork
{
    public partial class DiagShab : Form
    {       
        bool bt1 = true; // Знак, чтобы обозначить текст кнопки "Снять всё"/"Выделить всё"
        public DiagShab(bool[] mass)// Принимаем массив, какие шаблоны мы отметили
        {
            InitializeComponent();
            CheckedCheckBoxs(mass);
        }
        private void CheckedCheckBoxs(bool[] massive)
        {
            for (int i = 1; i <= massive.Length; i++)// количество элементов массива
            {// должно совпадать с количеством CheckBox'ов
                if (massive[i - 1] == true)// если true
                {
                    // элементы массива начинаются с 0, а цикл начинается с 1
                    // а назавание Чекбоксов с 1, можно сделать с 0, ну тут дело каждого)))
                    (Controls["checkBox" + i.ToString()] as CheckBox).Checked = true; //помечаем чекбокс 
                }
                else // иначе
                {
                    (Controls["checkBox" + i.ToString()] as CheckBox).Checked = false;//не помечаем чекбокс 
                }
            }
            
        }
        private void CheckBoxsEnable()// Активируем все CheckBox'ы
        {
            for (int i = 1; i <= Shablons.Shablons.shablons.Length ; i++)
            {//Shablons.Shablons.shablons.Length - количество шаблонов
                (Controls["checkBox" + i.ToString()] as CheckBox).Checked = true;
            }
        }
        private void CheckBoxsDisable()// Деактивируем все CheckBox'ы
        {
            for (int i = 1; i <= Shablons.Shablons.shablons.Length; i++)// 10 CheckBox'ов
            {//Shablons.Shablons.shablons.Length - количество шаблонов
                (Controls["checkBox" + i.ToString()] as CheckBox).Checked = false;
            }
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            if (bt1 == true)
            {
                bt1 = false;
                button1.Text = "Выделить всё";
                CheckBoxsDisable();
            }
            else
            {
                bt1 = true;
                button1.Text = "Снять всё";
                CheckBoxsEnable();
            }
        }
        private void button2_Click(object sender, System.EventArgs e)
        {
            Shablons.Shablons.value_check_shab = 0;// обнуляем количество выбранных checkbox'ов и в цикле считаем
            for (int i = 1; i <= Shablons.Shablons.shablons.Length; i++)// количество элементов массива
            {// должно совпадать с количеством CheckBox'ов
                if ((Controls["checkBox" + i.ToString()] as CheckBox).Checked == true)// проверяем отметку checkbox'а
                {
                    Shablons.Shablons.bool_shab[i - 1] = true; // помечаем true
                    Shablons.Shablons.value_check_shab++;
                }
                else // иначе
                {
                    Shablons.Shablons.bool_shab[i - 1] = false;// помечаем false
                }
            }
            this.Close();// Закрываем форму(DiagShab)
        }
    }
}
