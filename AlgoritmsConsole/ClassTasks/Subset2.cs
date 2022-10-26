using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgoritmsConsole.ClassTasks
{
    class Subset2
    {
        private List<int> _A;
        private List<List<int>> res;
        private HashSet<string> addedOnes;
        public List<List<int>> subsetsWithDup(List<int> A)
        {
            _A = A;
            _A.Sort();
            var list = new List<int>();
            addedOnes = new HashSet<string>();
            res = new List<List<int>>() { list };

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
            var strRepresentation = string.Join("", current.Select(x => x.ToString()));
            if (!addedOnes.Contains(strRepresentation))
            {
                res.Add(current);
                addedOnes.Add(strRepresentation);
            }

            for (int i = index + 1; i < _A.Count; i++)
            {
                Recursive(i, current);
            }
        }
    }
}
