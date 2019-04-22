namespace WordWork.Shablons
{
    static class Shablons
    {
        public static string[] shablons = new string[] // Имена с расширением файлов
        {// При изменении, проверить количество CheckBox'ов в форме DiagShab.cs
            "AUPSISOUL.docx",
            "AUPTIVPV.docx",
            "DPB1.doc",
            "DPB2.doc",
            "KATEGOR2.docx",
            "PTP.docx",
            "RAZDELPB.doc",
            "RISKI1.docx",
            "TEPLOTEH2.docx",
            "VPV.docx"
        };
        public static string[] rep_shablons = new string[] // Имена, которые нужно заменить
        {
            "{nomber}",
            "{mesto}",            
            "{namekompany}",
            "{kolmany}",
            "{summa}",
            "{fioname}",
            "{adresname}",
            "{isnamekompany}",
            "{factnamekompany}",
            "{ogrn}",
            "{inn}",
            "{kpp}",
            "{rastshet}",
            "{bankname}",
            "{komershet}",
            "{bick}",
            "{telefon}",
            "{Eimail}",
            "{data}"
        };
        public static int value_check_shab = shablons.Length;// Количество отмеченных шаблонов
        public static bool[] bool_shab = new bool[shablons.Length]; // Массив, для хранения отмеченных шаблонов
    }

    /*
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
    */

}
