using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgoritmsConsole.Tasks_week_2
{
    class TaskB
    {
        public void DoWorkA()
        {
            var str = Console.ReadLine();
            var n = int.Parse(str.Split(" ")[0]);
            var l = int.Parse(str.Split(" ")[1]);
            
            str = Console.ReadLine();
            var a = str.Split(" ").Select(x => int.Parse(x)).ToArray();

            Array.Sort(a);

            var first = a[0];
            var last = l - a[n - 1];

            double longest = 0;

            for (var i = 1; i < n; i++)
            {
                if ((a[i] - a[i - 1]) > longest)
                {
                    longest = a[i] - a[i - 1];
                }
            }

            longest = longest / 2;
            var max = Math.Max(longest, first);
            max = Math.Max(max, last);

            Console.WriteLine(max);
        }
    }
}
