using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgoritmsConsole.Tasks_week_1
{
    class TaskD
    {
        public void DoWork()
        {
            var str = Console.ReadLine();
            var k = int.Parse(str);
            var list = new List<List<int>>();
            var listSums = new List<List<int>>();
            for (var i = 0; i < k; i++)
            {
                var count = int.Parse(Console.ReadLine());
                str = Console.ReadLine();
                list.Add(new List<int>(str.Split(" ").Take(count).Select(x => int.Parse(x))));
            }

            var dict = new Dictionary<int, Tuple<int, int>>();
            for (var i = 0; i < k; i++)
            {
                var sum = list[i].Sum();

                for (var j = 0; j < list[i].Count; j++)
                {
                    var curSum = sum - list[i][j];
                    if (!dict.ContainsKey(curSum))
                    {
                        dict.Add(curSum, new Tuple<int, int>(i, j));
                    }
                    else if (dict[curSum].Item1 != i)
                    {
                        Console.WriteLine("YES");
                        Console.WriteLine($"{i + 1} {j + 1}");
                        Console.WriteLine($"{dict[curSum].Item1 + 1} {dict[curSum].Item2 + 1}");
                        return;
                    }
                }
            }

            Console.WriteLine("NO");

        }
    }
}
