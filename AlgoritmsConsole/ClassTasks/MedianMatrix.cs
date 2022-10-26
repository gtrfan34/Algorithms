using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoritmsConsole.ClassTasks
{
    class MedianMatrix
    {
        public int findMedian(List<List<int>> A)
        {
            int min = int.MaxValue;
            int max = int.MinValue;

            for (int i = 0; i < A.Count; i++)
            {
                if (A[i][0] < min)
                    min = A[i][0];
                if (A[i][A[i].Count - 1] > max)
                    max = A[i][A[i].Count - 1];
            }

            int l = min, r = max;

            if (min == max)
                return min;

            int half = (A.Count * A[0].Count) / 2 + 1;

            while (r - l > 1)
            {
                int m = (r + l) / 2;

                int countLess = CountAllLessThanX(A, m);

                if (countLess >= half)
                {
                    int f = CountAllLessThanX(A, m - 1);
                    if (f < half)
                        return m;
                }

                if (countLess >= half)
                {
                    r = m;
                }
                else
                {
                    l = m;
                }

            }

            int countLessf = CountAllLessThanX(A, l);
            if (countLessf >= half)
            {
                int f = CountAllLessThanX(A, l - 1);
                if (f < half)
                    return l;
            }
            return r;

        }

        public int CountAllLessThanX(List<List<int>> list, int x)
        {
            int f = 0;
            for (int i = 0; i < list.Count; i++)
            {
                f += CountLessThanX(list[i], x);
            }
            return f;
        }

        public int CountLessThanX(List<int> list, int x)
        {
            int l = 0;
            int r = list.Count - 1;

            if (r == l)
            {
                if (list[0] <= x)
                    return 1;
                else
                    return 0;
            }

            while (r - l > 1)
            {
                int m = (r + l) / 2;

                if (list[m] <= x && list[m + 1] > x)
                {
                    return m + 1;
                }

                if (list[m] <= x)
                {
                    l = m;
                }

                if (list[m] > x)
                {
                    r = m;
                }
            }

            if (list[l] <= x && list[l + 1] > x)
            {
                return l + 1;
            }
            else if (list[r] <= x)
            {
                return r + 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
