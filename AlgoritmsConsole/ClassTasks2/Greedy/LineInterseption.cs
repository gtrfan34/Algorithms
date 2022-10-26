using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgoritmsConsole.ClassTasks2.Greedy
{
    class LineInterseption
    {
        public int CountAlarm(int[] s, int[] f)
        {
            if (s.Length <= 1)
            {
                return s.Length;
            }

            var list = Enumerable
                .Range(0, s.Length)
                .Select(x => new Tuple<int, int>(s[x], f[x]))
                .ToList();

            var alarms = 1;
            var curEnd = 0;
            foreach (var line in list.OrderBy(x => x.Item1).ThenByDescending(x => x.Item2))
            {
                if (curEnd == 0)
                {
                    curEnd = line.Item2;
                }
                else if (line.Item1 <= curEnd)
                {
                    curEnd = Math.Min(curEnd, line.Item2);
                }
                else
                {
                    curEnd = line.Item2;
                    alarms++;
                }
            }

            return alarms;
        }
    }
}
