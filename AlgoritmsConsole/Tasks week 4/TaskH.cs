using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgoritmsConsole.Tasks_week_4
{
    class TaskH
    {
        private List<int> Range;
        public void DoWorkA()
        {
            var s = Console.ReadLine().Split(" ");
            var n = int.Parse(s[0]);
            var m = int.Parse(s[1]);
            Range = Enumerable.Range(1, n).ToList();

            var count = Recursive(n, m, 0, new List<int>());

            Console.WriteLine(count);
        }

        private int Recursive(int n, int m, int curI, List<int> curList)
        {
            var curCount = curList.Count;

            if (curCount + 1 > m)
            {
                return 0;
            }

            var curSum = curList.Sum();
            var count = 0;

            for (int i = curI; i < Range.Count; i++)
            {
                var list = new List<int>(curList);
                list.Add(Range[i]);
                var newSum = curSum + Range[i];

                if (newSum == n)
                {
                    count++;
                    return count;
                }
                else if (newSum > n)
                {
                    return count;
                }
                else
                {
                    count += Recursive(n, m, i, list);
                }

            }

            return count;
        }
    }
}
