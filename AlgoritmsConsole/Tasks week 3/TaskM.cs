using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoritmsConsole.Tasks_week_3
{
    class TaskM
    {
        public void DoWork()
        {
            var str = Console.ReadLine();
            var n = int.Parse(str);
            
            var arr = new int[n, n];
            var res = new int[n, n];

            for (var i = 0; i < n; i++)
            {
                str = Console.ReadLine();
                var j = 0;
                foreach (var s in str.Split(" "))
                {
                    arr[i, j] = int.Parse(s);
                    j++;
                }
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    res[i, j] = Math.Max((i > 0) ? res[i - 1, j] : 0, j > 0 ? res[i, j - 1] : 0) + arr[i, j];
                }
            }

            Console.WriteLine(res[n - 1, n - 1]);

        }
    }
}
