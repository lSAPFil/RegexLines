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
            

            Regex logDate = new Regex(@"\d{4}.\d{2}.\d{2}"); //Дата лога, без текста
            Regex line = new Regex(@"[А-я](\w*\s\w*)*(\D[a-zA-Z]*\S)(?=[^\w])"); //Текст лога без даты
            Regex regex = new Regex(@"(?<=\s)[Аа](\w*\s\w*)*[Аа](?=\s)"); //Вывод записи лога которая начинается и заканчивается на А
            Regex logWithCode = new Regex(@"(?<=401\s)(\w*\s\w*)*\S(?=[^\w])"); //Вывод записей с кодом 401
            Regex logs = new Regex(@"(?=\D\d{4})(\S*\s){2}(\D*\d{3})\s[А-я](\w*\s\w*)*(\D[a-zA-Z]*\S)(?=[^\w])"); //Вывод логов
            Regex regions = new Regex(@"[А-Я]\S*[A-Z]"); //Вывод региона
            Regex regionsCode = new Regex(@"(?<=[А-Я]\S*)[A-Z]{2}"); //Вывод кода региона

            Return(logDate);
            Return(line);
            Return(regex);
            Return(logWithCode);
            Return(logs);
            Return(regions);
            Return(regionsCode);
        }
        public static void Return(Regex regex)
        {
            MatchCollection matches = regex.Matches(line);

            foreach (Match match in matches)
            {
                Console.WriteLine(match.Value);
            }
        }
    }
}
