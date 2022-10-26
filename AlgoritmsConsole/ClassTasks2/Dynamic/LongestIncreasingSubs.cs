using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgoritmsConsole.ClassTasks2.Dynamic
{
    class LongestIncreasingSubs
    {
        public int lis(List<int> A)
        {
            //  [1, 2, 1, 5]
            //   1, 2, 1  0
            var res = new List<int>(A.Select(x => 0));
            res[0] = 1;
            for (int i = 1; i < A.Count; i++)
            {
                var curVal = A[i];
                for (int j = 0; j < res.Count; j++)
                {
                    if (A[j] < curVal)
                    {
                        if(res[i] < res[j] + 1)
                            res[i] = res[j] + 1;
                    }
                    else
                    {
                        if (res[i] < 1)
                            res[i] = 1;
                    }
                }
            }

            return res.Max();
        }
    }
}
