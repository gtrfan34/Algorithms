using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoritmsConsole.ClassTasks2.Dynamic
{
    class EditDistance
    {
        public int minDistance(string A, string B)
        {
            if (string.IsNullOrEmpty(A))
            {
                return string.IsNullOrEmpty(B) ? 0 : B.Length; 
            }

            if (string.IsNullOrEmpty(B))
            {
                return string.IsNullOrEmpty(A) ? 0 : A.Length;
            }

            var aLength = A.Length;
            var bLength = B.Length;

            var arr = new int[aLength, bLength];

            if (A[0] == B[0])
            {
                arr[0, 0] = 0;
            }
            else
            {
                arr[0, 0] = 1;
            }

            for (int i = 1; i < aLength; i++)
            {
                if (B[0] == A[i])
                {
                    arr[i, 0] = i;
                }
                else
                {
                    arr[i, 0] = arr[i - 1, 0] + 1;
                }
            }

            for (int j = 1; j < bLength; j++)
            {
                if (B[j] == A[0])
                {
                    arr[0, j] = j;
                }
                else
                {
                    arr[0, j] = arr[0, j-1] + 1;
                }
            }

            for (int i = 1; i < aLength; i++)
            {
                for (int j = 1; j < bLength; j++)
                {
                    int val = 0;
                    if (A[i] == B[j])
                    {
                        val = arr[i - 1, j - 1];
                    }
                    else
                    {
                        val = Math.Min(arr[i - 1, j], Math.Min(arr[i, j - 1], arr[i - 1, j - 1])) + 1;
                    }

                    arr[i, j] = val;
                }
            }

            return arr[aLength - 1, bLength - 1];
        }
    }
}
