using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgoritmsConsole.ClassTasks2.Dynamic
{
    class LongestIncrDecrSubs
    {
        public int longestSubsequenceLength(List<int> A)
        {
            //  [1, 2, 1, 5]
            //   1, 2, 1  3
            // [ 1, 2, 3, 1, 2, 1]
            //   1  2  3  4  4  5

            if (A.Count() < 2)
            {
                return A.Count();
            }

            var resInc = new List<int>(A.Select(x => 0));
            //var resDecr = new List<int>(A.Select(x => 0));

            resInc[0] = 1;
            for (int i = 1; i < A.Count; i++)
            {
                var curVal = A[i];
                for (int j = 0; j < resInc.Count; j++)
                {
                    if (A[j] < curVal)
                    {
                        if(resInc[i] < resInc[j] + 1)
                            resInc[i] = resInc[j] + 1;
                    }
                    else
                    {
                        if (resInc[i] < 1)
                            resInc[i] = 1;
                    }
                }
            }

            for (int i = 1; i < A.Count; i++)
            {
                var curVal = A[i];
                for (int j = 0; j < i; j++)
                {
                    if (A[j] > curVal)
                    {
                        if (resInc[i] < resInc[j] + 1)
                            resInc[i] = resInc[j] + 1;
                    }
                    
                }
            }



            return resInc.Max();
        }
    }
}
