using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgoritmsConsole.Tasks_week_2
{
    class TaskA
    {
        public void DoWorkA()
        {
            var str = Console.ReadLine();
            var n = int.Parse(str);

            str = Console.ReadLine();
            var x = str.Split(" ").Select(x => int.Parse(x)).ToArray();
            Array.Sort(x);

            var sum = 0;
            var groups = x.GroupBy(x => x);
            var groupCount = groups.Count();
            var dicX = new SortedDictionary<int, int>();
            var k = 0;

            foreach (var gr in groups)
            {
                sum += gr.Count();
                dicX.Add(gr.Key, sum);
            }

            var keys = new List<int>(dicX.Keys);

            str = Console.ReadLine();
            var q = int.Parse(str);

            var m = new int[q];
            var dicM = new Dictionary<int, int>();
            var maxEl = keys.Last();
            var minEl = keys.First();

            for (var i = 0; i < q; i++)
            {
                str = Console.ReadLine();
                m[i] = int.Parse(str);

                if (m[i] >= maxEl)
                {
                    m[i] = n;
                    continue;
                }
                else if (m[i] < minEl)
                {
                    m[i] = 0;
                    continue;
                }
                else if (dicX.ContainsKey(m[i]))
                {
                    m[i] = dicX[m[i]];
                    continue;
                }
                else if (dicM.ContainsKey(m[i]))
                {
                    m[i] = dicM[m[i]];
                    continue;
                }

                var index = keys.BinarySearch(m[i]);

                dicM[m[i]] = dicX[keys[~index - 1]];
                m[i] = dicX[keys[~index - 1]];
            }

            for (var i = 0; i < q; i++)
            {
                Console.WriteLine(m[i]);
            }
        }

        public void DoWorkB()
        {
            var str = Console.ReadLine();
            var n = int.Parse(str);

            str = Console.ReadLine();
            var x = str.Split(" ").Select(x => int.Parse(x)).ToArray();
            Array.Sort(x);

            var sum = 0;
            var groups = x.GroupBy(x => x);
            var groupCount = groups.Count();
            var xAr = new Tuple<int, int>[groupCount];
            var k = 0;

            foreach (var gr in groups)
            {
                sum += gr.Count();
                xAr[k++] = new Tuple<int, int>(gr.Key, sum);
            }


            str = Console.ReadLine();
            var q = int.Parse(str);

            var m = new int[q];
            var dicM = new Dictionary<int, int>();
            var maxEl = xAr.Last().Item1;
            var minEl = xAr.First().Item1;

            for (var i = 0; i < q; i++)
            {
                str = Console.ReadLine();
                m[i] = int.Parse(str);

                if (m[i] >= maxEl)
                {
                    m[i] = n;
                    continue;
                }
                else if (m[i] < minEl)
                {
                    m[i] = 0;
                    continue;
                }
                else if (dicM.ContainsKey(m[i]))
                {
                    m[i] = dicM[m[i]];
                    continue;
                }

                var z = 0;
                while (z < groupCount)
                {
                    if (xAr[z].Item1 > m[i])
                    {
                        z--;
                        break;
                    }
                    else z++;
                }

                dicM[m[i]] = xAr[z].Item2;
                m[i] = xAr[z].Item2;
            }

            for (var i = 0; i < q; i++)
            {
                Console.WriteLine(m[i]);
            }
        }
    }
}
