using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgoritmsConsole.Tasks_week_4
{
    class TaskA
    {
        public void DoWorkB()
        {
            var s = Console.ReadLine();
            var m = int.Parse(Console.ReadLine());

            var l = new int[m];
            var r = new int[m];

            var sumAr = new int[s.Length+1];
            sumAr[0] = 0;
            var sum = 0;
            for (var i = 0; i < s.Length -1; i++)
            {
                sum += s[i] == s[i + 1] ? 1 : 0;
                sumAr[i+1] = sum;
            }
            sumAr[s.Length] = sum;

            for (var i = 0; i < m; i++)
            {
                var str = Console.ReadLine();
                l[i] = int.Parse(str.Split(" ")[0]);
                r[i] = int.Parse(str.Split(" ")[1]);
            }

            for (var i = 0; i < m; i++)
            {
                Console.WriteLine(sumAr[r[i] -1] - sumAr[l[i]-1]);
            }

        }
        public void DoWorkA()
        {
            var s = Console.ReadLine();
            var m = int.Parse(Console.ReadLine());

            var l = new int[m];
            var r = new int[m];
            var rMax = new Dictionary<int, int>();

            var dict = new Dictionary<int, Dictionary<int, int>>();

            for (var i = 0; i < m; i++)
            {
                var str = Console.ReadLine();
                l[i] = int.Parse(str.Split(" ")[0]);
                r[i] = int.Parse(str.Split(" ")[1]);

                if (!dict.ContainsKey(l[i]))
                {
                    dict.Add(l[i], new Dictionary<int, int>() { { r[i], 0 } });
                }
                else
                {
                    if (!dict[l[i]].ContainsKey(r[i]))
                    {
                        dict[l[i]].Add(r[i], 0);
                    }
                }

                if (rMax.ContainsKey(l[i]))
                {
                    if (rMax[l[i]] < r[i])
                    {
                        rMax[l[i]] = r[i];
                    }
                }
                else
                {
                    rMax.Add(l[i], r[i]);
                }
            }
            var lKeys = dict.Keys.OrderBy(x => x).ToList();

            for (int i = 0; i < s.Length - 1; i++)
            {
                if (s[i] == s[i + 1])
                {
                    foreach (var lKey in lKeys.Where(x => x <= i + 1))
                    {
                        if (rMax[lKey] >= i + 1)
                        {
                            foreach (var item in dict[lKey].Where(x => x.Key > i + 1).ToList())
                            {
                                dict[lKey][item.Key] += 1;
                            }
                        }
                    }

                }
            }

            for (var i = 0; i < m; i++)
            {
                Console.WriteLine(dict[l[i]][r[i]]);
            }


        }
    }
}
