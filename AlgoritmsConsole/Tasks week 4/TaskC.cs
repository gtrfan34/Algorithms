using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgoritmsConsole.Tasks_week_4
{
    class TaskC
    {
        public void DoWorkA()
        {
            var n = int.Parse(Console.ReadLine());

            var dict = new Dictionary<int, Dictionary<int, int>>();
            var str = Console.ReadLine();
            var a = str.Split(" ").Select(x => int.Parse(x)).ToArray();
            var countAr = Enumerable.Repeat(0, n).ToArray();

            for (var i = 0; i < n; i++)
            {
                if (a[i] <= n)
                {
                    countAr[a[i]-1]++;
                }
            }

            var res = countAr.Where(x => x == 0).Count();
            
            Console.WriteLine(res);
        }
    }
}
