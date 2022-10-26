using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgoritmsConsole.Tasks_week_2
{
    class TaskE
    {
        public void DoWorkA()
        {
            var str = Console.ReadLine();
            var n = int.Parse(str.Split(" ")[0]);
            var m = int.Parse(str.Split(" ")[1]);

            var curIndex = 0;
            var list = new List<Tuple<int, int>>();

            for (var i = 0; i < n; i++)
            {
                str = Console.ReadLine();
                var split = str.Split(" ");
                var c = int.Parse(split[0]);
                var t = int.Parse(split[1]);
                curIndex += c * t;
                list.Add(new Tuple<int, int>(curIndex, i + 1));
            }

            str = Console.ReadLine();
            var v = str.Split(" ")
                .Select(x => int.Parse(x))
                .ToArray();

            curIndex = 0;
            for (var i = 0; i < m; i++)
            {
                while (v[i] > list[curIndex].Item1)
                {
                    curIndex++;
                }

                Console.WriteLine(list[curIndex].Item2);
            }
        }
    }
}
