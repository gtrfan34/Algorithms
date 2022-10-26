using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgoritmsConsole.Tasks_week_1
{
    class TaskF
    {
        public void DoWork()
        {
            var str = Console.ReadLine();
            var t = int.Parse(str);
            var list = new List<List<int>>();

            for (var i = 0; i < t; i++)
            {
                Console.ReadLine();
                str = Console.ReadLine();
                list.Add(str.Split(" ").Select(x => int.Parse(x)).ToList());
            }

            for (var i = 0; i < t; i++)
            {
                var grouped = list[i].GroupBy(x => x).OrderBy(x => x.Key);
                var increment = 0;
                var count = 0;
                foreach (var gr in grouped)
                {
                    count += (gr.Count() + increment) / gr.Key;
                    increment = (gr.Count() + increment) % gr.Key;
                }

                Console.WriteLine(count);
            }


        }
    }
}
