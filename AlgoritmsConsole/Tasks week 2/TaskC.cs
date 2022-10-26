using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoritmsConsole.Tasks_week_2
{
    class TaskC
    {
        public void DoWorkA()
        {
            var str = Console.ReadLine();
            var n = int.Parse(str.Split(" ")[0]);
            var s = int.Parse(str.Split(" ")[1]);

            var dict = new SortedDictionary<int, int>();
            var totalSum = s;

            for (var i = 0; i < n; i++)
            {
                str = Console.ReadLine();
                var split = str.Split(" ");
                var x = int.Parse(split[0]);
                var y = int.Parse(split[1]);
                var val = int.Parse(split[2]);
                var key = x * x + y * y;
                totalSum += val;

                if (dict.ContainsKey(key))
                {
                    dict[key] += val;
                }
                else
                {
                    dict.Add(key, val);
                }
            }

            if (totalSum < 1000000)
            {
                Console.WriteLine(-1);
                return;
            }
            totalSum = s;

            foreach (var el in dict)
            {
                totalSum += el.Value;
                if (totalSum >= 1000000)
                {
                    Console.WriteLine(Math.Sqrt(el.Key));
                    return;
                }
            }

            Console.WriteLine(-1);
            return;
        }
    }
}
