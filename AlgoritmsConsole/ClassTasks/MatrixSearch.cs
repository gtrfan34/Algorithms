using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoritmsConsole.ClassTasks
{
    class MatrixSearch
    {
        public int searchMatrix(List<List<int>> A, int B)
        {
            var y = 0;

            if (A[0][0] > B || A[A.Count - 1][A[A.Count - 1].Count - 1] < B)
            {
                return 0;
            }

            int l, r;

            if (A.Count > 1)
            {
                l = 0;
                r = A.Count - 1;

                while (r - l > 1)
                {
                    var m = (r + l) / 2;

                    if (A[m][0] == B)
                    {
                        return 1;
                    }

                    if (A[m][0] < B && A[m + 1][0] > B)
                    {
                        y = m;
                        break;
                    }

                    if (A[m][0] > B)
                    {
                        r = m;
                    }
                    else
                    {
                        l = m;
                    }
                }

                if (r-l == 1)
                {
                    if (A[l][0] <= B && A[l + 1][0] > B)
                    {
                        y = l;
                    }
                    else if (A[r][0] <= B && A[r][A[r].Count -1] >= B)
                    {
                        y = r;
                    }
                }
            }

            l = 0;
            r = A[y].Count - 1;

            if (l == r && A[y][l] == B)
            {
                return 1;
            }

            while (r - l > 1)
            {
                var m = (r + l) / 2;

                if (A[y][m] == B)
                {
                    return 1;
                }

                if (A[y][m] > B)
                {
                    r = m;
                }
                else
                {
                    l = m;
                }
            }

            if (r - l == 1)
            {
                if (A[y][l] == B || A[y][r] == B)
                {
                    return 1;
                }
            }

            return 0;
        }
    }
}
