using Microsoft.VisualBasic;
using System;

namespace Calculyamber
{
    class Program
    {
        static void Main(string[] args)
        {
            bool error = false;
            //снимаем настройки из конфига
            if (!(System.IO.File.Exists(@"config.ini"))) //проверяем существует ли файл с настройками если нет создаём
            {
                Config.CreateConfig(Config.lang, Config.round);
                error = true;
            }
            else
            {
                string config = System.IO.File.ReadAllText(@"config.ini"); //снимаем настройки из файла 
                for (int i = 0; i < config.Length; i++) //очищаем файл от лишней мишуры 
                {
                    if ((config[i] != '0') && (config[i] != '1') && (config[i] != '2') && (config[i] != '3') &&
                        (config[i] != '4') && (config[i] != '5') && (config[i] != '6') && (config[i] != '7') &&
                        (config[i] != '8') && (config[i] != '9') && (config[i] != '\n') && (config[i] != '-'))
                    {
                        config = config.Remove(i, 1);
                        i--;
                    }
                }
                string[] configs = config.Split('\n'); //разделяем строку на отдельные настройки 
                if (configs.Length < 2) { error = true; }
                else
                {
                    int z1, z2; //временные значения
                    error = !int.TryParse(configs[0], out z1); //проверяем возможность считывания значения конфига
                    error = !int.TryParse(configs[1], out z2);
                    if (!error) //проверяем правильность считанных данных
                    {
                        if ((z1 < 0) || (z1 > 3)) { error = true; }
                        if ((z2 < -15) || (z2 > 0)) { error = true; }
                    }
                    if (!error) //вводим полученные значения в программу
                    {
                        Config.lang = z1;
                        Config.round = z2;
                    }
                }
            }


            //выбор языка
            //если в конфиге 0 запрашиваем язык
            bool selected = false;
            void viboryazika()
            {
                Console.Write("\nПожалуйста, выберете язык/Please, select language/Будь ласка, виберiть мову \n\n" +
                    "   1 - Русский \n" +
                    "   2 - English \n" +
                    "   3 - Український \n\n" +
                    "Введите число, соответствующее языку/\n" +
                    "Enter the number corresponding to the language, that you want to select/\n" +
                    "Введiть число, вiдповiдне мовi \n");
                while (!(int.TryParse(Console.ReadLine(), out Config.lang)) || !((Config.lang >= 1) && (Config.lang <= 3))) //ввод значения
                {
                    Console.ForegroundColor = ConsoleColor.Red; // устанавливаем цвет
                    Console.WriteLine("Неверный формат/Wrong format/Невiрний формат");
                    Console.ResetColor(); // сбрасываем в стандартный
                }
                Console.Clear();
            }
            if (Config.lang == 0) 
            {
                viboryazika();
                Console.Clear();
                selected = true;
            }
            //вводим настрокий языка
            void nastroikayazika()
            {
                switch (Config.lang)
                {
                    case 1:
                        Lang.stroka1 = "Введите число, корень которого хотите получить\n" +
                            "Для выхода в меню напишите \"menu\"\n" +
                            "Для выхода из программы введите \"exit\".";
                        Lang.zapros = "Сохранить выбор?\n" +
                            "1 - Да \n" +
                            "2 - Нет \n";
                        Lang.errorformat = "Неверный формат";
                        Lang.vihod = "Для выхода нажмите любую клавишу";
                        Lang.menu = "\nВведите число, соответствующее пункту меню\n\n" +
                            "   1 - Начать работу\n" +
                            "   2 - Настройки\n" +
                            "   3 - О программе\n" +
                            "   4 - Выход на рабочий стол\n\n";
                        Lang.errorconfig = "\nНЕПРАВИЛЬНЫЙ ФОРМАТ CONFIG ФАЙЛА! ИСПОЛЬЗОВАНЫ СТАНДАРТНЫЕ НАСТРОЙКИ \n" +
                            "ЗАЙДИТЕ В НАСТРОЙКИ, ЧТОБЫ ЭТО СООБЩЕНИЕ ИСЧЕЗЛО";
                        Lang.Oproge = "";
                        Lang.settings = "\nВведите число, соответствующее пункту меню\n\n";
                        Lang.settingsstroka1 = "    1 - Выбор языка                   Текущее значение: Русский";
                        Lang.settingsstroka2 = "    2 - Выбор разряда округления      Текущее значение: ";
                        Lang.settingsback = "    3 - Вернуться в главное меню и сохранить настройки";
                        Lang.predlozhenie_vvoda = "Пункт меню: ";
                        Lang.menuzagl = "\nГЛАВНОЕ МЕНЮ";
                        Lang.settingszagl = "\nМЕНЮ НАСТРОЕК";
                        Lang.Oprogezagl = "\nО ПРОГРАММЕ";
                        Lang.settingsstroka2_1 = "\nВведите значение разряда округления.\n\n" +
                            "Минимальное значение разряда -15.\n";
                        Lang.predlozhenie_vvoda2 = "Введите занчение: ";
                        Lang.settingsback2 = "    4 - Вернуться в главное меню без сохранения настройек";
                        break;
                    case 2:
                        Lang.stroka1 = "Enter the number to calculate its square root";
                        Lang.zapros = "Save selection?\n" +
                            "1 - Yes \n" +
                            "2 - No \n";
                        Lang.errorformat = "Wrong format";
                        Lang.vihod = "Press any key to exit";
                        Lang.menu = "\nEnter the number, corresponding to the menu item:\n\n" +
                            "   1 - Start program\n" +
                            "   2 - Settings\n" +
                            "   3 - About\n" +
                            "   4 - Exit to desktop\n\n" +
                            "Menu item: ";
                        Lang.errorconfig = "\nWRONG CONFIG FILE FORMAT! DEFAULT SETTINGS WILL BE USED \n" +
                            "";
                        break;
                    case 3:
                        /*Lang.stroka1 = "Введiть число, корiнь якого хочете отримати";
                        Lang.zapros = "Зберегти вибiр?\n" +
                            "1 - Так \n" +
                            "2 - Нi \n";
                        Lang.errorformat = "Невiрний формат";
                        Lang.vihod = "Для виходу натиснiть будь-яку клавiшу";*/
                        break;
                }
            }
            nastroikayazika();
            //если в конфиге 0 запрашиваем сохранение языка
            if (selected)
            {
                int tf;
                Console.WriteLine(Lang.zapros); //Запрос на сохранение языка
                while (!(int.TryParse(Console.ReadLine(), out tf)) || !((tf >= 1) && (tf <= 2))) { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine(Lang.errorformat); Console.ResetColor(); } //ввод значения
                if (tf == 1) { Config.CreateConfig(Config.lang, Config.round); } //Сохранение в файл конфига
                Console.Clear();
            }
            
            
            //Меню 
            void menu()
            {
                bool exit = true;
                while (exit)
                {
                    int vvod;
                    if (error)
                    {
                        Console.ForegroundColor = ConsoleColor.Red; // устанавливаем цвет
                        Console.WriteLine(Lang.errorconfig);
                        Console.ResetColor(); // сбрасываем в стандартный
                    }
                    Console.ForegroundColor = ConsoleColor.Blue; Console.WriteLine(Lang.menuzagl); Console.ResetColor();
                    Console.Write(Lang.menu);
                    Console.Write(Lang.predlozhenie_vvoda);
                    while (!(int.TryParse(Console.ReadLine(), out vvod)) || !((vvod >= 1) && (vvod <= 4))) 
                        { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine(Lang.errorformat); Console.ResetColor(); Console.Write(Lang.predlozhenie_vvoda); } //ввод значения
                    Console.Clear();
                    switch (vvod)
                    {
                        case 1: //калькулямбер
                            exit = false;
                            break;
                        case 2: //настройки 
                            {
                                bool exit1 = true;
                                int tf;
                                int conflang = Config.lang;
                                int confround = Config.round;
                                while (exit1)
                                {
                                    error = false;
                                    Console.ForegroundColor = ConsoleColor.Blue; Console.WriteLine(Lang.settingszagl); Console.ResetColor();
                                    Console.Write(Lang.settings);
                                    Console.WriteLine(Lang.settingsstroka1);
                                    Console.WriteLine(Lang.settingsstroka2 + Config.round.ToString());
                                    Console.WriteLine(Lang.settingsback);
                                    Console.WriteLine(Lang.settingsback2);
                                    Console.WriteLine('\n');
                                    Console.Write(Lang.predlozhenie_vvoda);
                                    while (!(int.TryParse(Console.ReadLine(), out tf)) || !((tf >= 1) && (tf <= 4)))
                                    { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine(Lang.errorformat); Console.ResetColor(); } //ввод значения
                                    switch (tf)
                                    {
                                        case 1: //выбор языка
                                            Console.Clear();
                                            viboryazika();
                                            nastroikayazika();
                                            break;
                                        case 2: //округление
                                            Console.Clear();
                                            Console.WriteLine(Lang.settingsstroka2_1);
                                            Console.Write(Lang.predlozhenie_vvoda2);
                                            while (!(int.TryParse(Console.ReadLine(), out Config.round)) || !(Config.round >= -15) || !(Config.round <= 0))
                                                { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine(Lang.errorformat); Console.ResetColor(); Console.Write(Lang.predlozhenie_vvoda2); } //ввод значения
                                            break;
                                        case 3: //выход с сохиранением
                                            exit1 = false;
                                            Config.CreateConfig(Config.lang, Config.round);
                                            break;
                                        case 4: //выход без сохаранения
                                            exit1 = false;
                                            Config.lang = conflang;
                                            Config.round = confround;
                                            break;
                                    }
                                    Console.Clear();
                                }
                            }
                            break;
                        case 3: //о программе
                            Console.ForegroundColor = ConsoleColor.Blue; Console.WriteLine(Lang.Oprogezagl); Console.ResetColor();
                            Console.WriteLine(Lang.Oproge);
                            Console.Write(Lang.vihod);
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case 4: //выход
                            Console.Write(Lang.vihod);
                            Console.ReadKey();
                            Console.Clear();
                            Environment.Exit(0);
                            break;
                    }
                }
            }
            menu();

            //калькулямбер
            double chislo;
            bool exit = true;
            string s;
            Console.WriteLine(Lang.stroka1);
            while (exit)
            {
                s = Console.ReadLine();
                if (s.Contains("exit")) { exit = false;  }
                else if (s.Contains("menu")) { Console.Clear(); menu(); Console.WriteLine(Lang.stroka1); }
                else if (!double.TryParse(s, out chislo)) { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine(Lang.errorformat); Console.ResetColor(); }
                else if (chislo < 0)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow; // устанавливаем цвет
                    Console.WriteLine(Math.Round(Math.Sqrt(-chislo), -Config.round).ToString() + "i"); 
                    Console.ResetColor(); // сбрасываем в стандартный
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow; // устанавливаем цвет
                    Console.WriteLine(Math.Round(Math.Sqrt(chislo), -Config.round));
                    Console.ResetColor(); // сбрасываем в стандартный
                }
            }

            //Выход
            Console.Write(Lang.vihod);
            Console.ReadKey();
            Console.Clear();
        }

        public static class Lang //класс со значениями языка
        {
            public static string stroka1 = "";
            public static string zapros = "";
            public static string errorformat = "";
            public static string vihod = "";
            public static string menu = "";
            public static string menuzagl = "";
            public static string Oproge = "";
            public static string errorconfig = "";
            public static string settings = "";
            public static string settingszagl = "";
            public static string settingsstroka1 = "";
            public static string settingsstroka2 = "";
            public static string settingsback = "";
            public static string predlozhenie_vvoda = "";
            public static string Oprogezagl = "";
            public static string settingsstroka2_1 = "";
            public static string predlozhenie_vvoda2 = "";
            public static string settingsback2 = "";
        }

        public static class Config //класс с настройками
        {
            public static int lang = 0;
            public static int round = -15; //0 итерпретируется как округление до целого, 1 то же, 2 десятки и тд
            public static void CreateConfig(int lang, int okrug) //Создает файл настроек 
            {
                System.IO.File.WriteAllText(@"config.ini",
                    "lang=" + lang.ToString() + "\n" +
                    "round=" + okrug.ToString() + "\n");
            }
        }
    }
}
