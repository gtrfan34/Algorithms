using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace AlgoritmsConsole.Tasks_week_5
{
    class TaskI
    {
        public int DoWorkA(int n, long[] a)
        {
            var max2 = 45;
            var arr2 = new long[max2];
            arr2[0] = 2;

            for (var i = 1; i < max2; i++)
            {
                arr2[i] = arr2[i - 1] * 2;
            }

            var dict = new Dictionary<long, int>();

            var counter = 0;

            for (var i = 0; i < n; i++)
            {
                if (dict.ContainsKey(a[i]))
                {
                    counter += dict[a[i]];

                }

                for (var j = 0; j < max2; j++)
                {
                    var cur = arr2[j] - a[i];
                    if (cur > 0)
                    {
                        if (dict.ContainsKey(cur))
                        {
                            dict[cur]++;
                        }
                        else
                        {
                            dict.Add(cur, 1);
                        }
                    }
                }
            }

            return counter;

        }

        public void DoWorkB()
        {
            var n = int.Parse(Console.ReadLine());

            var a = Console.ReadLine()
                .Split(" ")
                .Select(x => long.Parse(x))
                .ToArray();

            Console.WriteLine(WorkB(n, a));
        }
        public int WorkB(int n, long[] a)
        {
            var counter = 0;

            for (var i = 0; i < n - 1; i++)
            {
                for (var j = i + 1; j < n; j++)
                {
                    var cur = a[i] + a[j];
                    if ((cur & (cur - 1)) == 0)
                    {
                        counter++;
                    }

                }
            }

            return counter;
        }

        public void DoWorkCycle()
        {
            while (true)
            {
                Random random = new Random();
                int n = random.Next(1, 100001);
                var a = new long[n];

                for (int k = 0; k < n; k++)
                {
                    a[k] = random.Next(1, 1000000001);
                }

                var timer = new Stopwatch();
                timer.Start();
                var res = DoWorkA(n, a);
                timer.Stop();
                var fir = timer.ElapsedMilliseconds;
                timer.Restart();
                var sec = WorkB(n, a);
                timer.Stop();
                var secT = timer.ElapsedMilliseconds;

                Console.WriteLine("=====================================================");
                Console.WriteLine($"n = {n}, ResA = {res} - {fir}, ResB = {sec} - {secT}");

                Console.WriteLine("=====================================================");

                if (res != sec)
                {
                    foreach (var item in a)
                    {
                        Console.Write($"{item} ");
                    }
                    Console.ReadLine();
                }
            }
        }
    }
}
