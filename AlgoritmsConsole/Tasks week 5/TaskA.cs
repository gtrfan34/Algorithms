using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgoritmsConsole.Tasks_week_5
{
    class TaskA
    {
        public void DoWorkB()
        {
            var s = Console.ReadLine().Split(" ");

            var n = int.Parse(s[0]); 
            var m = int.Parse(s[1]);

            var x = new HashSet<int>();
            var y = new HashSet<int>();
            var res = new long[m];
            
            for (var i = 0; i < m; i++)
            {
                s = Console.ReadLine().Split(" ");

                x.Add(int.Parse(s[0]));
                y.Add(int.Parse(s[1]));
                res[i] = (n - x.Count) * (long)(n - y.Count);
            }


            for (var i = 0; i < m; i++)
            {
                Console.Write(res[i] + " ");
            }

        }
    }
}
