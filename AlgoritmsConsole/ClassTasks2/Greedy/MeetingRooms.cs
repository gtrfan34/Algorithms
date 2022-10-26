using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgoritmsConsole.ClassTasks2.Greedy
{
    class MeetingRooms
    {
        public int solve(List<List<int>> A)
        {
            if (A.Count == 1)
            {
                return 1;
            }

            var ends = new List<int>();

            A = A.OrderBy(x => x[0]).ToList();
            ends.Add(A[0][1]);

            for (var i = 1; i < A.Count; i++)
            {
                ends.Sort();
                if (ends[0] > A[i][0])
                {
                    ends.Add(A[i][1]);
                }
                else
                {
                    var index = ends.BinarySearch(A[i][0]);
                    if (index < 0)
                    {
                        var closest = ~index;
                        index = closest - 1;
                    }

                    ends.RemoveAt(index);
                    ends.Add(A[i][1]);
                }
            }

            return ends.Count;
        }
    }
}
