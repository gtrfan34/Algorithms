using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgoritmsConsole.Tasks_week_3
{
    class TaskN
    {
        public void DoWork()
        {
            var str = Console.ReadLine();
            var n = int.Parse(str.Split(" ")[0]);
            var k = int.Parse(str.Split(" ")[1]);

            str = Console.ReadLine();
            var list = new List<int>(str.Split(" ").Select(x => int.Parse(x)));

            if (n == k)
            {
                Console.WriteLine("1");
                return;
            }


            var minindex = 0;
            var curSum = list.Take(k).Sum();
            var min = curSum;
            var prevEl = list[0];

            for (int i = 1; i < list.Count - k + 1; i++)
            {
                curSum = curSum - prevEl + list[i + k - 1];
                prevEl = list[i];
                if (curSum < min)
                {
                    minindex = i;
                    min = curSum;
                }
            }

            Console.WriteLine(minindex + 1);
        }
    }
}
