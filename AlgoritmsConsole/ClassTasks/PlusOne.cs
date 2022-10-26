using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoritmsConsole.ClassTasks
{
    class PlusOne
    {
        public List<int> plusOne(List<int> A)
        {
            var needToAdd = false;
            for (var i = A.Count - 1; i >= 0; i--)
            {
                if ((A[i] + 1) == 10)
                {
                    A[i] = 0;
                    needToAdd = true;
                }
                else
                {
                    A[i]++;
                    needToAdd = false;
                    break;
                }
            }

            if (needToAdd)
            {
                A[0] = 1;
                A.Add(0);
            }
            else
            {
                for (var i = 0; i < A.Count && A.Count != 1; i++)
                {
                    if ((A[i]) == 0)
                    {
                        A.Remove(A[i]);
                        i--;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            return A;
        }
    }
}
