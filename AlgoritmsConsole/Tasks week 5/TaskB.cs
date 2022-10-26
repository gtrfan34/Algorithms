using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgoritmsConsole.Tasks_week_5
{
    class TaskB
    {
        public void DoWork()
        {

            var n = int.Parse(Console.ReadLine()); 

            var s = Console.ReadLine();
            
            if (n % 2 == 1)
            {
                Console.WriteLine("No");
                return;
            }

            var correct = 0;
            var incor = 0;

            for (var i = 0; i < n; i++)
            {
                var curOpen = s[i] == '(';
                if (curOpen)
                {
                    correct++;
                }
                else
                {
                    if (correct > 0)
                    {
                        correct--;
                    }
                    else
                    {
                        incor++;
                    }
                }
            }

            if ((correct == 0 && incor == 0) || (correct == 1 && incor == 1))
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }
        }
    }
}
