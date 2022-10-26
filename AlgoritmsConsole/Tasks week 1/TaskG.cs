using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace AlgoritmsConsole.Tasks_week_1
{
    class TaskG
    {
        public void DoWork()
        {
            var str = Console.ReadLine();
            str = Console.ReadLine();
            var list = new List<int>(str.Split(" ").Select(x => int.Parse(x)));

            var isEven = false;
            var isOdd = false;

            for (var i = 0; i < list.Count; i++)
            {
                if (isEven && isOdd)
                {
                    break;
                }
                var odd = list[i] % 2 == 1;
                isOdd = isOdd || odd;
                isEven = isEven || !odd;
            }

            if (isEven && isOdd)
            {
                list.Sort();
            }

            Console.WriteLine(string.Join(" ", list.Select(x => x)));
        }
    }
}
