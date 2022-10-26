using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoritmsConsole.Tasks_week_2
{
    class TaskG
    {
        public void DoWorkA()
        {
            var str = Console.ReadLine();
            var n = int.Parse(str);

            var hash = new HashSet<string>();
            var arr = new string[n];

            for (var i = 0; i < n; i++)
            {
                str = Console.ReadLine();
                arr[i] = str;
            }

            for (var i = n-1; i >= 0; i--)
            {
                if (!hash.Contains(arr[i]))
                {
                    hash.Add(arr[i]);
                    Console.WriteLine(arr[i]);
                }
            }


        }
    }
}
