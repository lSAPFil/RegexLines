using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Web;
using Newtonsoft.Json;
using System.Net.Http;
using System.Diagnostics;
using System.Text.RegularExpressions;
namespace RegexLines
{
    class Program
    {
        public static string line = "[2021.05.25 20:15] HTTP: 500\n" +
                        "Сообщение не было обработано по причине сторонней ошибки.\n" +
                        "[2021.05.25 20:16] HTTP: 200\n" +
                        "[2021.05.25 21:17] HTTP: 500\n" +
                        "Некорректный регион Пермь_88-RU.\n" +
                        "[2021.05.26 10:03] HTTP: 401\n" +
                        "Ошибка авторизации пользователя.\n" +
                        "[2021.05.26 11:41] HTTP: 200\n" +
                        "[2021.06.01 20:15] HTTP: 503\n" +
                        "Таймаут получения информации по региону Крым_91-RU.\n" +
                        "[2021.06.02 14:28] HTTP: 401\n" +
                        "Невалидный пользователь.\n" +
                        "[2021.06.02 14:28] HTTP: 200\n" +
                        "Авторизация успешна\n" +
                        "[2021.06.03 09:10] HTTP: 200\n" +
                        "[2021.06.04 12:32] HTTP: 500\n" +
                        "автоматическая обработка сообщений невозможна\n";
        static void Main(string[] args)
        {

            Regex logs = new Regex(@".*\n[А-я].*|.*\d"); // Вывод логов
            Regex logDate = new Regex(@"\d{4}.\d{2}.\d{2}"); //Дата лога, без текста
            Regex line = new Regex(@"[А-я].*"); //Текст лога без даты
            Regex logWithCode = new Regex(@"(?<=401\s)[А-я].*(?=\S)"); //Вывод записей с кодом 401
            Regex regex = new Regex(@"[Аа].*[Аа](?=\s)"); //Вывод записи лога которая начинается и заканчивается на А
            Regex regions = new Regex(@"[А-Я]\S*[A-Z]"); //Вывод региона
            Regex regionsCode = new Regex(@"(?<=\d.)[A-Z]\w"); //Вывод кода страны


            Return(logs);
            Return(logDate);
            Return(line);
            Return(logWithCode);
            Return(regex);
            Return(regions);
            Return(regionsCode);
        }
        public static void Return(Regex regex)
        {
            MatchCollection matches = regex.Matches(line);

            foreach (Match match in matches)
            {
                System.Console.OutputEncoding = System.Text.Encoding.UTF8;
                Console.WriteLine(match.Value +"\n");
            }
            Console.WriteLine("\n");
        }
    }
}
