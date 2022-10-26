using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgoritmsConsole.ClassTasks2.Dynamic
{
    class Knapsack
    {
        public int solve(List<int> A, List<int> B, int C)
        {
            var dict = new SortedDictionary<int, int>();
            dict.Add(0, 0);
            for (int i = 0; i < A.Count; i++)
            {
                var keys = dict.Keys;
                foreach (var item in keys.Reverse())
                {
                    var weight = B[i] + item;
                    var val = A[i] + dict[item];
                    if (weight <= C)
                    {
                        if (dict.ContainsKey(weight))
                        {
                            if (dict[weight] < val)
                            {
                                dict[weight] = val;
                            }
                        }
                        else
                        {
                            dict.Add(weight,val);
                        }
                    }
                }
            }

            return dict.Values.Max();
        }
    }
}
