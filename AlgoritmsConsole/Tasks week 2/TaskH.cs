using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgoritmsConsole.Tasks_week_2
{
    class TaskH
    {
        public void DoWorkA()
        {
            var str = Console.ReadLine();
            var n = int.Parse(str.Split(" ")[0]);
            var s = int.Parse(str.Split(" ")[1]);

            var buyDict = new SortedDictionary<int, int>();
            var sellDict = new SortedDictionary<int, int>();

            for (var i = 0; i < n; i++)
            {
                str = Console.ReadLine();
                var split = str.Split(" ");
                var dir = split[0];
                var p = int.Parse(split[1]);
                var q = int.Parse(split[2]);
                SortedDictionary<int, int> dicToAdd;

                if (dir == "B")
                {
                    dicToAdd = buyDict;
                }
                else
                {
                    dicToAdd = sellDict;
                }

                if (dicToAdd.ContainsKey(p))
                {
                    dicToAdd[p] += q;
                }
                else
                {
                    dicToAdd.Add(p, q);
                }
            }

            var sList = sellDict.Keys.ToList();
            var bList = buyDict.Keys.ToList();

            var k = sList.Count - 1;

            if (sList.Count > s)
            {
                k = s - 1;
            }

            for (var i = k; i >= 0; i--)
            {
                Console.WriteLine($"S {sList[i]} {sellDict[sList[i]]}");
            }


            k = bList.Count - 1;

            if (bList.Count > s)
            {
                k = s - 1;
            }

            var counter = 0;
            for (var j = bList.Count - 1; j >= 0; j--)
            {
                if (counter++ == s)
                {
                    break;
                }

                Console.WriteLine($"B {bList[j]} {buyDict[bList[j]]}");
            }
        }
    }
}
