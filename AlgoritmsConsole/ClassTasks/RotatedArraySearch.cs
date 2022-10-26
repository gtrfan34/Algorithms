using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoritmsConsole.ClassTasks
{
    class RotatedArraySearch
    {
        public int search(List<int> A, int B)
        {
            var rotationIndex = 0;

            if (A.Count == 1)
            {
                if (A[0] == B)
                {
                    return 0;
                }
                else return -1;
            }

            for (var i = 0; i< A.Count-1; i++)
            {
                if (A[i+1] < A[i])
                {
                    rotationIndex = i + 1;
                    break;
                }
            }

            var firstPartL = 0;
            var firstPartR = rotationIndex - 1 > 0 ? rotationIndex - 1 : 0;

            var secondPartL = rotationIndex;
            var secondPartR = A.Count - 1;
            int l, r;

            if (A[firstPartL] <= B && B <= A[firstPartR])
            {
                l = firstPartL;
                r = firstPartR;
            }
            else if (A[secondPartL] <= B && B <= A[secondPartR])
            {
                l = secondPartL;
                r = secondPartR;
            }
            else
            {
                return -1;
            }

            while (r-l > 1)
            {
                var m = (r + l) / 2;

                if (A[m] == B)
                {
                    return m;
                }
                if (A[m] < B)
                {
                    l = m;
                }
                else
                {
                    r = m;
                }
            }

            if (A[l] == B)
            {
                return l;
            }
            if (A[r] == B)
            {
                return r;
            }

            return -1;
        }
    }
}
