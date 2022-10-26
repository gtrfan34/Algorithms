using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoritmsConsole.ClassTasks2.Dynamic
{
    class Tortoise
    {
        public int GetMaxDandelions(int [,] a)
        {
            var n = a.GetLength(0);
            var m = a.GetLength(1);

            var f = new int[n,m];

            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    f[i, j] = Math.Max(f[i - 1 >= 0 ? i - 1 : 0, j], f[i, j - 1 >= 0 ? j - 1 : 0]) + a[i, j];
                }
            }

            return f[n - 1, m - 1];
        }
    }
}
