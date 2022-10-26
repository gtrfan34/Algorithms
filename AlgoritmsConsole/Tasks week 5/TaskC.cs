using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgoritmsConsole.Tasks_week_5
{
    class TaskC
    {
        class B
        {
            public int val;
            public int index;
        }

        public void DoWork()
        {
            var s = Console.ReadLine().Split(" ");

            var n = int.Parse(s[0]);
            var m = int.Parse(s[1]);

            var a = Console.ReadLine()
                .Split(" ")
                .Select(x => int.Parse(x))
                .OrderBy(x => x)
                .ToArray();

            var b = Console.ReadLine()
                .Split(" ")
                .Select((x,i) => new B { val = int.Parse(x), index = i })
                .OrderBy(x => x.val)
                .ToArray();

            var aCounter = 0;
            var bCounter = 0;
            while (bCounter < m)
            {
                if (b[bCounter].val < a[0])
                {
                    b[bCounter].val = 0;
                    bCounter++;
                    continue;
                }

                while (aCounter < n && b[bCounter].val >= a[aCounter])
                {
                    aCounter++;
                }

                b[bCounter].val = aCounter;
                bCounter++;
            }


            foreach (var bval in b.OrderBy(x => x.index))
            {
                Console.Write(bval.val + " ");
            }
        }
    }
}
