using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgoritmsConsole.Tasks_week_1
{
    class TaskA
    {
        public void DoWorkA()
        {
            var str = Console.ReadLine();
            var n = int.Parse(str.Split(" ")[0]);
            var m = int.Parse(str.Split(" ")[1]);
            var a = new int[n];
            var b = new int[n];

            var c = new List<Tuple<int, int, int>>();
            long sumA = 0;
            long sumB = 0;

            for (var i = 0; i < n; i++)
            {
                str = Console.ReadLine();
                a[i] = int.Parse(str.Split(" ")[0]);
                b[i] = int.Parse(str.Split(" ")[1]);
                c.Add(new Tuple<int, int, int>(a[i], b[i], a[i] - b[i]));
                sumA += a[i];
                sumB += b[i];
            }

            if (sumA <= m)
            {
                Console.WriteLine("0");
                return;
            }

            if (sumB > m)
            {
                Console.WriteLine("-1");
                return;
            }

            if (sumB == m)
            {
                Console.WriteLine(n);
                return;
            }

            c.Sort((x, y) => y.Item3.CompareTo(x.Item3));

            var sumAll = 0;
            var count = 0;

            for (var i = 0; i < n; i++)
            {
                if (sumA <= m)
                {
                    break;
                }

                sumA -= c[i].Item3;
                count++;
            }

            Console.WriteLine(count);
        }
        public int DoWorkB()
        {
            var str = Console.ReadLine();
            var n = int.Parse(str.Split(" ")[0]);
            var m = int.Parse(str.Split(" ")[1]);
            var a = new int[n];
            var b = new int[n];

            for (var i = 0; i < n; i++)
            {
                str = Console.ReadLine();
                a[i] = int.Parse(str.Split(" ")[0]);
                b[i] = int.Parse(str.Split(" ")[1]);
            }

            var c = new List<Tuple<int, int, int>>(Enumerable.Range(0, n)
                .Select(i => 
                new Tuple<int, int, int>(
                    a[i], 
                    b[i], 
                    a[i] - b[i])));
            
            c.Sort((x, y) => y.Item3.CompareTo(x.Item3));

            if (a.Sum() <= m)
            {
                return 0;
            }
            
            var sumB = b.Sum();
            var count = n;

            if (sumB > m)
            {
                return -1;
            }

            for (var i = n-1; i >= 0; i--)
            {
                if (sumB + c[i].Item3 > m)
                {
                    return count;
                }

                sumB += c[i].Item3;
                count--;
            }

            return 0;
        }
    }
}
