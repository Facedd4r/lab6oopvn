using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6oopvn
{
    
    internal static class StringExtensions
    {
        /// <summary>
        /// Extension метод для типа string, удаляющий русские буквы
        /// </summary>
        public static string RemoveRussianLetters(this string str)
        {
            // проверка на null
            if (string.IsNullOrEmpty(str))
            {
                return str;
            }
            // фильтрация символов исходной строки str и возврат новой строки, из которой удалены все русские буквы.
            return new string(str.Where(c => !(c >= 'А' && c <= 'я') && c != 'ё' && c != 'Ё').ToArray());
        }
    }
}
