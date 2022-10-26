using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoritmsConsole.Tasks_week_2
{
    class TaskF
    {
        public void DoWorkA()
        {
            var str = Console.ReadLine();
            var n = int.Parse(str.Split(" ")[0]);
            var m = int.Parse(str.Split(" ")[1]);

            var pCount = 0;
            var polshar = new HashSet<string>();
            var vCount = 0;
            var same = 0;

            for (var i = 0; i < n; i++)
            {
                str = Console.ReadLine();
                polshar.Add(str);
                pCount++;
            }

            for (var i = 0; i < m; i++)
            {
                vCount++;

                str = Console.ReadLine();
                if (polshar.Contains(str))
                {
                    same++;
                }
            }

            var diff = pCount - vCount;

            var sameIsEven = same % 2 == 0;

            if (sameIsEven)
            {
                if (diff <= 0)
                {
                    Console.WriteLine("NO");
                }
                else
                {
                    Console.WriteLine("YES");
                }
            }
            else
            {
                if (diff >= 0)
                {
                    Console.WriteLine("YES");
                }
                else
                {
                    Console.WriteLine("NO");
                }
            }
        }
    }
}
