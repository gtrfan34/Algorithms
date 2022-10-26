using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgoritmsConsole.ClassTasks2
{
    class CombinationSum
    {
        public List<List<int>> combinationSum(List<int> A, int B)
        {
            var res = new List<List<int>>();

            var list = A.Distinct().ToList();
            list.Sort();
            
            if (list.Count < 0 || B < list.First())
            {
                return res;
            }

            Recursive(list, 0, B, new List<int>(), res);

            return res;
        }

        private void Recursive(List<int> list, int j, int B, List<int> curList, List<List<int>> res)
        {
            for (var i = j; i < list.Count(); i++)
            {
                var curListCopy = new List<int>(curList);
                curListCopy.Add(list[i]);
                var sum = curListCopy.Sum();
                if (sum > B)
                {
                    return;
                }
                else if (sum == B)
                {
                    res.Add(curListCopy);
                    return;
                }
                else
                {
                    Recursive(list, i, B, curListCopy, res);
                }
            }
        }
    }
}
