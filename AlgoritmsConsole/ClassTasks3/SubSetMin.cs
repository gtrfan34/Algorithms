using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoritmsConsole.ClassTasks3
{
    class SubSetMin
    {
        public List<int> Mins(List<int> arr, int k)
        {
            var que = new Queue<int>(k);
            var stack = new Stack<int>(k);
            var res = new List<int>(arr.Count);

            for (int i = 0; i < k; i++)
            {
                que.Enqueue(arr[i]);
                if (stack.Count == 0 || stack.Peek() >= arr[i])
                {
                    stack.Push(arr[i]); 
                }
            }
            res.Add(stack.Peek());

            for (int i = k; i < arr.Count; i++)
            {
                var ex = que.Dequeue();
                que.Enqueue(arr[i]);

                if (ex == stack.Peek()) 
                {
                    stack.Pop();
                }

                if (arr[i] <= stack.Peek())
                {
                    stack.Push(arr[i]);
                }

                res.Add(stack.Peek());

            }

            return res;

        }
    }
}
