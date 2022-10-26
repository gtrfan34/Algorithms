using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgoritmsConsole.Tasks_week_1
{
    class TaskE
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
                list[i].Sort();
                var count = list[i].Count();
                int x, y = 0;
                if (count % 2 == 1)
                {
                    Console.Write(list[i][count / 2] + " ");
                    x = count / 2 - 1;
                    y = count / 2 + 1;
                }
                else
                {
                    x = count / 2 - 1;
                    y = count / 2;
                }

                while(x >= 0 && y < count)
                {
                    Console.Write(list[i][y++] + " " + list[i][x--] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
