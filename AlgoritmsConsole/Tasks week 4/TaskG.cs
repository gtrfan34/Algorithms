using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgoritmsConsole.Tasks_week_4
{
    class TaskG
    {
        public void DoWorkA()
        {
            var n = int.Parse(Console.ReadLine());
            
            var arr = Console.ReadLine().Select(x => int.Parse(x.ToString())).ToArray();
            var start = new List<int>(arr.Take(n));
            var end = new List<int>(arr.Skip(n).Take(n));

            start.Sort();
            end.Sort();

            var flag = 0;

            for (int i = 0; i < n; i++)
            {
                if (flag == 0)
                {
                    if (start[i] > end[i])
                    {
                        flag = 1;
                    }
                    else if (start[i] < end[i])
                    {
                        flag = -1;
                    }
                    else
                    {
                        Console.WriteLine("NO");
                        return;
                    }

                    continue;
                }

                if ((start[i] > end[i] && flag == -1) ||
                    (start[i] == end[i]) ||
                    (start[i] < end[i] && flag == 1) )
                {
                    Console.WriteLine("NO");
                    return;
                }
            }

            Console.WriteLine("YES");
        }
    }
}
