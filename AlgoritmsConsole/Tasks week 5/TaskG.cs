using System;
using System.Collections.Generic;

namespace AlgoritmsConsole.Tasks_week_5
{
    class TaskG
    {
        public void DoWork()
        {
            var n = int.Parse(Console.ReadLine()); 

            var dict = new Dictionary<string,int>(n);
            var arr = new string[n];
            
            for (var i = 0; i < n; i++)
            {
                var s = Console.ReadLine();

                arr[i] = s;
                if (dict.ContainsKey(s))
                {
                    dict[s]--;
                }
                else
                {
                    dict.Add(s, 0);
                }
            }

            for (var i = 0; i < n; i++)
            {
                if (dict[arr[i]] == 0)
                {
                    Console.WriteLine("OK");
                }
                else if (dict[arr[i]] < 0)
                {
                    dict[arr[i]] = 1;
                    Console.WriteLine($"OK");
                }
                else
                {
                    
                    Console.WriteLine($"{arr[i]}{dict[arr[i]]}");
                    dict[arr[i]]++;
                }
            }

        }
    }
}
