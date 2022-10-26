using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgoritmsConsole.ClassTasks2
{
    class Combinations
    {
        public List<List<int>> combine(int A, int B)
        {
            var res = new List<List<int>>();
            if (B > A)
            {
                return res;
            }

            if (A == 1)
            {
                return new List<List<int>>() { new List<int> { 1 } };
            }

            var list = new List<int>(A);

            for (var i = 1; i <= A; i++)
            {
                list.Add(i);
            }

            if (A == B)
            {
                res.Add(list);
                return res;
            }

            Recursive(list, -1, B, new List<int>(), res);

            return res;
        }

        private void Recursive(List<int> list, int j, int B, List<int> curList, List<List<int>> res)
        {
            for (var i = j + 1; i < list.Count(); i++)
            {
                var curListCopy = new List<int>(curList);
                curListCopy.Add(list[i]);
                if (curListCopy.Count() == B)
                {
                    res.Add(curListCopy);
                    curListCopy = new List<int>(curList);
                    continue;
                }
                else
                {
                    Recursive(list, i, B, curListCopy, res);
                }
            }
        }
    }
}
