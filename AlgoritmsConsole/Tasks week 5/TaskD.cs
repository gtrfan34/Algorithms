using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgoritmsConsole.Tasks_week_5
{
    class TaskD
    {
        public void DoWork()
        {
            var n = int.Parse(Console.ReadLine());

            var a = Console.ReadLine()
                .Split(" ")
                .Select(x => int.Parse(x))
                .ToArray();

            if (n == 1)
            {
                Console.WriteLine(0);
                return;
            }

            var lCounter = 0;
            var rCounter = n-1;
            long lSum = a[lCounter++];
            long rSum = a[rCounter--];

            if (lSum == rSum && n == 2)
            {
                Console.WriteLine(lSum);
                return;
            }

            long max = 0;
            while (lCounter <= rCounter)
            {
                if (lSum > rSum)
                {
                    rSum += a[rCounter--];
                }
                else if (lSum < rSum)
                {
                    lSum += a[lCounter++];
                }

                if (lSum == rSum)
                {
                    max = lSum;
                    lSum += a[lCounter];
                    lCounter++;
                }
            }

            Console.WriteLine(max);
        }
    }
}
