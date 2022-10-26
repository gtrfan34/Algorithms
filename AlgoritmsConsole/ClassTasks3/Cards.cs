using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgoritmsConsole.ClassTasks3
{
    class Cards
    {
        class Node {
            public int value;
            public int index;
        }

        public string Check()
        {
            var s = Console.ReadLine().Split(" ");

            var n = int.Parse(s[0]);
            var q = int.Parse(s[1]);

            var a = Console.ReadLine()
                .Split(" ")
                .Select(x => int.Parse(x))
                .ToArray();

            var t = Console.ReadLine()
                .Split(" ")
                .Select(x => int.Parse(x))
                .ToArray();

            var dict = new Dictionary<int, int>();

            for (int i = 0; i < a.Length; i++)
            {
                if (!dict.ContainsKey(a[i]))
                {
                    dict.Add(a[i], i + 1);
                }
            }

            var res = new StringBuilder();
            for (int i = 0; i < t.Length; i++)
            {
                var index = dict[t[i]];
                res.Append(index + " ");
                dict[t[i]] = 1;

                foreach (var item in dict.Keys.ToList())
                {
                    if (item != t[i] && dict[item] < index)
                    {
                        dict[item]++;
                    }
                }
            }

            Console.WriteLine(res);
            return "";
        }

        public void Check2(int[] a, int[] q)
        {
            for (int i = 0; i < q.Length; i++)
            {
                var prev = a[0];
                for (int j = 0; j < a.Length; j++)
                {
                    if (a[j] == q[i])
                    {
                        a[0] = q[i];
                        a[j] = prev;

                        q[i] = j + 1;
                        break;
                    }

                    if (j > 0)
                    {
                        var tmp = a[j];
                        a[j] = prev;
                        prev = tmp;
                    }
                }
            }

            Console.WriteLine(string.Join(' ', q));
        }

    }
}
