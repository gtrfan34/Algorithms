using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgoritmsConsole.Tasks_week_4
{
    class TaskD
    {
        public void DoWorkA()
        {
            var n = int.Parse(Console.ReadLine().Split()[0]);

            var max = 0;
            for (var i = 0; i < n; i++)
            {
                var curMin = Console.ReadLine().Split().Select(x => int.Parse(x)).Min();
                max = Math.Max(max, curMin);
            }

            Console.WriteLine(max);
        }
    }

}
