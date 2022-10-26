using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoritmsConsole.ClassTasks3
{
    class QueueTasks
    {
        public string solve(string A)
        {
            var dict = new Dictionary<char, int>();
            var queue = new Queue<char>();
            var res = "";

            for( var i = 0; i< A.Length; i++)
            {
                if (dict.ContainsKey(A[i]))
                {
                    dict[A[i]]++;
                }
                else
                {
                    dict.Add(A[i], 1);
                }

                if (dict[A[i]] <= 1) 
                {
                    queue.Enqueue(A[i]);
                }

                char next = '#';

                while (queue.Count > 0) 
                {
                    next = queue.Peek();
                    if (dict[next] != 1)
                    {
                        queue.Dequeue();
                    }
                    else
                    {
                        break;
                    }

                }
                if (queue.Count == 0)
                {
                    next = '#';
                }
                
                res += next;
                
            }

            return res;


        }
    }
}
