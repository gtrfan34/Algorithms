using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AlgoritmsConsole.Tasks_week_5
{
    class TaskF
    {
        public void DoWork()
        {
            var s = Console.ReadLine().Split(" ");

            var n = int.Parse(s[0]);
            var kL = long.Parse(s[1]);
            var k = kL >= 500 ? 500 : (int)kL;

            var a = Console.ReadLine().Split(" ").Select(x => int.Parse(x)).ToArray();
            var res = OptionA(n, k, a);
            var sec = OptionB(n, k, a);

            Console.WriteLine($"{res}      {sec}"); 
        }

        public void DoWorkCycle()
        {
            for (int i = 2; i < 500; i++)
            {
                for (int k = 2; k < i; k++)
                {
                    var a = Shuf(i);
                    var n = a.Length;
                    var res = OptionA(n, k, a);
                    var sec = OptionB(n, k, a);

                    Console.WriteLine("=====================================================");
                    Console.WriteLine($"n = {n}, k = {k}, ResA = {res}, ResB = {sec}");
                    foreach (var item in a)
                    {
                        Console.Write($"{item} ");
                    }

                    Console.WriteLine("=====================================================");

                    if (res != sec)
                    {
                        Console.ReadLine();
                    }
                }
            }
        }

        public int[] Shuf(int n)
        {
            int[] array = new int[n];
            for (int i = 0; i < n; i++)
            {
                array[i] = i+1;
            }
            Shuffle(array);

            return array;
        }
        public void Shuffle(int[] array)
        {
            Random random = new Random();
            int n = array.Count();
            while (n > 1)
            {
                n--;
                int i = random.Next(n + 1);
                int temp = array[i];
                array[i] = array[n];
                array[n] = temp;
            }
        }

        private int OptionA(int n, int k, int[] a)
        {
            if (a[0] == n || k + 1 >= n)
            {
                return n;
            }

            var chFrom = k + 1;

            for (var i = 0; i < n; i++)
            {
                if (a[i] == n)
                {
                    return n;
                }

                if (a[i] >= chFrom)
                {
                    var cur = a[i];
                    var counter = k;
                    for (var j = i + 1; j < n; j++)
                    {
                        if (a[j] < cur)
                        {
                            counter--;
                        }
                        else
                        {
                            break;
                        }
                        if (counter == 0)
                        {
                            return cur;
                        }
                    }
                }
            }

            return n;
        }
        private int OptionB(int n, int k, int[] a)
        {
            var que = new Queue<int>(a);

            while (true) {
                var cur = que.Dequeue();
                var counter = 0;
                while (counter < k && que.Peek() < cur)
                {
                    counter++;
                    que.Enqueue(que.Dequeue());
                }

                if (counter == k)
                {
                    return cur;
                }
                else
                {
                    que.Enqueue(cur);
                } 
            }

            
        }
    }
}
