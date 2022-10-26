using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgoritmsConsole.Tasks_week_2
{
    class TaskI
    {
        public void DoWork()
        {
            var str = Console.ReadLine();
            var n = int.Parse(str);

            var dict = new Dictionary<string, int>();
            dict.Add("polycarp", 1);

            for (var i = 0; i < n; i++)
            {
                str = Console.ReadLine();
                var split = str.Split(" ");
                var name = split[0].ToLower();
                var from = split[2].ToLower();

                if (!dict.ContainsKey(name))
                {
                    dict.Add(name, dict[from] + 1);
                }
            }

            Console.WriteLine(dict.Values.Max());
        }
    }
}
