using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgoritmsConsole.Tasks_week_5
{
    class TaskE
    {
        public void DoWork()
        {
            var s = Console.ReadLine();

            var stack = new Stack<char>();

            var counter = 0;

            foreach (var item in s)
            {
                if (!stack.Any())
                {
                    stack.Push(item);
                }
                else
                {
                    var cur = stack.Peek();
                    if (cur == item)
                    {
                        stack.Pop();
                        counter++;
                    } 
                    else
                    {
                        stack.Push(item);
                    }
                }
            }

            if (counter % 2 == 0)
            {
                Console.WriteLine("No");
            }
            else
            {
                Console.WriteLine("Yes");
            }
        }
    }
}
