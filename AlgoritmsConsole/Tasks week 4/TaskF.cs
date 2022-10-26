using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgoritmsConsole.Tasks_week_4
{
    class TaskF
    {
        public void DoWorkA()
        {
            var b = long.Parse(Console.ReadLine().Split(" ")[1]);
            var arrString = Console.ReadLine().Split(" ");
            var n = arrString.Length;
            var a = arrString.Select(x => int.Parse(x)).ToArray();
            var seps = new List<int>(n / 2);
            var curString = 0;

            for (int i = 0; i < n; i++)
            {
                curString += a[i] % 2 > 0 ? -1 : 1;

                if (curString == 0 && i < n-1)
                {
                    seps.Add(Math.Abs(a[i + 1] - a[i]));
                    curString = 0;
                }
            }

            if (seps.Count == 0)
            {
                Console.WriteLine(0);
                return;
            }

            seps.Sort();
            var count = 0;
            var cost = 0;
            for (int i = 0; i < seps.Count; i++)
            {
                if (cost + seps[i] > b)
                {
                    Console.WriteLine(count);
                    return;
                }

                cost += seps[i];
                count++;
            }

            Console.WriteLine(count);
        }
    }
}
