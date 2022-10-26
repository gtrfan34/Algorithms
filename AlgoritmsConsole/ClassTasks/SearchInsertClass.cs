using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoritmsConsole.ClassTasks
{
    class SearchInsertClass
    {
        public int searchInsert(List<int> a, int b)
        {
            var l = 0;
            var r = a.Count - 1;

            if (b < a[0])
            {
                return 0;
            }
            if (b > a[r])
            {
                return r + 1;
            }

            while (r - l > 1)
            {
                var m = (r + l) / 2;
                if (a[m] == b)
                {
                    return m;
                }
                if (a[m] > b)
                {
                    if (a[m - 1] < b)
                    {
                        return m;
                    }

                    r = m-1;
                }
                else
                {
                    l = m;
                }
            }

            if (a[l] == b)
            {
                return l;
            }
            if (a[r] == b)
            {
                return r;
            }
            if (a[l] < b && b < a[r])
            {
                return l;
            }

            return -1;
        }
    }
}
