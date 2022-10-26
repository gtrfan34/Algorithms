using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgoritmsConsole.ClassTasks
{
    class Painters
    {
        public int paint(int A, int B, List<int> C)
        {
            var l = C[0];
            var r = C.Sum();
            var min = int.MaxValue;
            long res;

            if (A == 1)
            {
                res = (long)r * B % 10000003 ;
                return (int)res;
            }

            while (r - l > 1)
            {
                var m = (l + r) / 2;

                if (IsPossible(C, A, m))
                {
                    if (m < min)
                    {
                        min = m;
                    }
                    r = m;
                }
                else
                {
                    l = m;
                }
            }

            if (IsPossible(C, A, r))
            {
                if (r < min)
                {
                    min = r;
                }
            }

            if (IsPossible(C, A, l))
            {
                if (l < min)
                {
                    min = l;
                }
            }

            res =  (long)min * B % 10000003;
            return (int)res;
        }

        private bool IsPossible(List<int> c, int a, int m)
        {
            var count = 1;
            var sum = 0;

            for (int i = 0; i < c.Count; i++)
            {
                if(c[i] > m)
                {
                    return false;
                }

                if(c[i] + sum > m)
                {
                    count++;
                    sum = c[i];

                    if (count > a)
                    {
                        return false;
                    }
                }
                else
                {
                    sum += c[i];
                }
            }

            return true;
        }
    }
}
