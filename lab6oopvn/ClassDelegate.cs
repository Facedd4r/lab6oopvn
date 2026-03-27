using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6oopvn
{
    static public class ClassDelegate
    {
        public delegate double MyDel(int[] a);
        public static MyDel avgResult => delegate (int[] a)
        {
            if (a is null || a.Length == 0)
            {
                throw new ArgumentException("Массив не может быть null");
            }
            return a.Average();
        };

    }
}
