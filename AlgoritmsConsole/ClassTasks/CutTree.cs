using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgoritmsConsole.ClassTasks
{
    class CutTree
    {
        public long solveBinary(List<int> A, int B)
        {
            var max = findMax(A);
            var result = binSearch(A, 1, max, B);
            return result;
        }

        private long findSum(List<int> A, long h)
        {
            long sum = 0;
            for (var i = 0; i < A.Count; i++)
            {
                if (A[i] >= h)
                {
                    sum = sum + (A[i] - h);
                }
            }
            return sum;
        }

        private long findMax(List<int> A)
        {
            long max = -1;
            for (var i = 0; i < A.Count; i++)
            {
                if (A[i] > max)
                {
                    max = A[i];
                }
            }
            return max;
        }

        private long binSearch(List<int> A, long l, long r, int B)
        {
            long ans = -1;

            while (l <= r && ans < 0)
            {
                var m = (l + r) / 2;
                var val = findSum(A, m);
                if (val == B)
                {
                    ans = m;
                }
                else if (val < B)
                {
                    if (m - 1 > 0)
                    {
                        var valPrev = findSum(A, m - 1);
                        if (valPrev >= B)
                        {
                            ans = m - 1;
                        }
                    }
                    r = m - 1;
                }
                else
                {
                    l = m + 1;
                }
            }
            return ans;
        }






        public int solve(List<int> A, int B)
        {
            if (A.Count() == 1)
            {
                return A[0] - B;
            }

            ElInfo currentEl, previousEl = null;

            var groups = A.GroupBy(x => x).OrderBy(x => x.Key).ToArray();
            var sum = 0;
            var count = 0;
            for (var i = groups.Count() - 1; i >= 0; i--)
            {
                var lessHeight = 0;
                if (i - 1 >= 0)
                {
                    lessHeight = groups[i - 1].Key;
                }

                var diff = groups[i].Key - lessHeight;
                count += groups[i].Count();
                var difCur = diff * count;
                sum += difCur;
                currentEl = new ElInfo()
                {
                    WoodAmount = sum,
                    TreeHeight = groups[i].Key,
                    CountAllPrevious = count
                };

                if (sum >= B)
                {
                    var el = currentEl;
                    var dif = B;

                    if (previousEl != null)
                    {
                        dif = B - previousEl.WoodAmount;
                    }

                    var cutHeight = dif / el.CountAllPrevious;
                    var left = dif % el.CountAllPrevious;

                    if (left > 0)
                        cutHeight++;

                    var res = el.TreeHeight - cutHeight;

                    return res;
                }

                previousEl = currentEl;

            }

            return 0;

        }

    }

    internal class ElInfo
    {
        public int WoodAmount { get; set; }
        public int TreeHeight { get; set; }
        public int CountAllPrevious { get; set; }
    }
}
