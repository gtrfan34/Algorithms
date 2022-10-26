using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgoritmsConsole.ClassTasks2.Greedy
{
    class AnnAndMinimum
    {
        public void DoWorkA()
        {
            var str = Console.ReadLine().Split(" ");
            var n = int.Parse(str[0]);
            var k = int.Parse(str[1]);

            var s = Console.ReadLine().Select(x => int.Parse(x.ToString())).ToArray();

            if (k > 0)
            {
                if (n == 1)
                {
                    Console.WriteLine(0);
                    return;
                }

                var counter = 0;
                if (s[0] != 1)
                {
                    s[0] = 1;
                    counter++;
                }
                
                var i = 1;
                while (i < n && counter < k)
                {
                    if (s[i] != 0)
                    {
                        s[i] = 0;
                        counter++;
                    }
                    i++;
                }
            }

            foreach (var si in s)
            {
                Console.Write(si);
            }
            Console.WriteLine();
        }
    }
}
