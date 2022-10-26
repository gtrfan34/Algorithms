using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgoritmsConsole.ClassTasks2.Greedy
{
    class KthPermutation
    {
        public string getPermutation(int A, int B)
        {
            var avail = new List<int>(Enumerable.Range(1,A));
            var factorial = new int[A+1];
            factorial[0] = 1;
            for (int i = 1; i <= A; i++)
            {
                if(factorial[i-1] > B)
                {
                    factorial[i] = int.MaxValue;
                }
                else
                {
                    factorial[i] = factorial[i - 1] * i;
                }
            }

            var res = "";
            var reminder = B;
            var iter = A;

            while (reminder > 0 && iter > 0)
            {
                var divide = reminder / factorial[iter - 1];
                reminder = reminder % factorial[iter - 1];
                iter--;

                if (reminder > 0)
                {
                    divide++;
                }

                res += avail[(int)divide - 1];
                avail.Remove(avail[(int)divide - 1]);

            }

            if (iter > 0)
            {
                avail.Reverse();
                foreach (var item in avail)
                {
                    res += item;
                }
            }

            return res;
        }
    }
}
