using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KA1
{
    static class Utils
    {
        //меняет местами 2 элемента
        public static void Swap<T>(ref T a, ref T b)
        {
            T r = a;
            a = b;
            b = r;
        }

        //расширение для List
        public static IList<T> Swap<T>(this IList<T> list, int indexA, int indexB)
        {
            T tmp = list[indexA];
            list[indexA] = list[indexB];
            list[indexB] = tmp;
            return list;
        }

        public static long FactNaive(int n)
        {
            long r = 1;
            for (int i = 2; i <= n; ++i)
                r *= i;
            return r;
        }
    }
}
