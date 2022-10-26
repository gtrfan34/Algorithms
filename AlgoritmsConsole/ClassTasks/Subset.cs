using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoritmsConsole.ClassTasks
{
    class Subset
    {
        private List<int> _A;
        private List<List<int>> res;
        public List<List<int>> subsets(List<int> A)
        {
            _A = A;
            _A.Sort();
            var list = new List<int>();
            res = new List<List<int>>() { list};

            for (int i = 0; i < _A.Count; i++)
            {
                Recursive(i, list);
            }

            return res;
        }

        private void Recursive(int index, List<int> old)
        {
            var current = new List<int>(old);
            current.Add(_A[index]);
            res.Add(current);

            for (int i = index + 1; i < _A.Count; i++)
            {
                Recursive(i,current);
            }
        }
    }
}
