using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgoritmsConsole.ClassTasks2.Greedy
{
    class AllPermutations
    {
        private List<List<int>> All;
        public List<List<int>> permute(List<int> A)
        {
            All = new List<List<int>>();
            Recursive(A, new List<int>(), A.Count);
            return All;
        }

        public void Recursive(List<int> available, List<int> current, int n)
        {
            for (int i = 0; i < available.Count; i++)
            {
                var list = new List<int>(current);
                var cur = available[i];
                list.Add(cur);

                if(list.Count == n)
                {
                    All.Add(list);
                }
                else
                {
                    Recursive(available.Where(x => x != cur).ToList(), list, n);
                }
            }
        } 
    }
}
