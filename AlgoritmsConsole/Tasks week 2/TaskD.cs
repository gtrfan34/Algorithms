using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgoritmsConsole.Tasks_week_2
{
    class TaskD
    {
        public void DoWorkA()
        {
            var str = Console.ReadLine();
            var n = int.Parse(str);

            str = Console.ReadLine();
            var a = str.Split(" ").Select(x => int.Parse(x)).ToArray();
            Array.Sort(a);

            str = Console.ReadLine();
            var m = int.Parse(str);
            str = Console.ReadLine();
            var q = str.Split(" ").Select(x => int.Parse(x)).ToArray();

            var sum = 0;
            var dict = new SortedDictionary<int, Tuple<int, int>>();

            for (var i = 0; i < n; i++)
            {
                if (dict.ContainsKey(a[i]))
                {
                    sum++;
                    dict[a[i]] = new Tuple<int, int>(sum, dict[a[i]].Item2 + 1);
                }
                else
                {
                    sum++;
                    dict[a[i]] = new Tuple<int, int>(sum, 1);
                }
            }

            var list = dict.Keys.ToList();
            var max = list.Last();
            var min = list.First();

            for (var i = 0; i < m; i++)
            {
                if (q[i] > max)
                {
                    Console.Write($"{sum} ");
                    continue;
                }
                else if (q[i] <= min)
                {
                    Console.Write("0 ");
                    continue;
                }

                var index = list.BinarySearch(q[i]);

                if (index > 0)
                {
                    var el = dict[list[index]];
                    Console.Write($"{el.Item1 - el.Item2} ");
                    continue;
                }
                else if (index == 0)
                {
                    Console.Write("0 ");
                    continue;
                }
                else
                {
                    var el = dict[list[~index - 1]];
                    Console.Write($"{el.Item1} ");
                    continue;
                }
            }

        }
    }
}
