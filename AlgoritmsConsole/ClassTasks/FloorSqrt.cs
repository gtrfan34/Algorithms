using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoritmsConsole.ClassTasks
{
    class FloorSqrt
    {
        public int sqrt(int A)
        {
            long l = 1;
            long r = A;

            while (r - l > 1)
            {
                long m = (l + r) / 2;

                if (m * m <= A && A < (m + 1) * (m + 1))
                {
                    return (int)m;
                }

                if (m * m > A)
                {
                    r = m;
                }
                else
                {
                    l = m;
                }
                Console.WriteLine($"m={m},{Environment.NewLine} l={l}, r={r}");
            }

            if (l * l <= A && A < (l + 1) * (l + 1))
                return (int)l;
            else 
                return (int)r;
        }

        public static int sqrt1(int A)
        {

            if (A == 1 || A == 2 || A == 3)
            {
                return 1;
            }
            if (A == 4 || A == 5 || A == 6 || A == 7 || A == 8)
            {
                return 2;
            }

            long l = 1;
            long r = A / 2;

            while (r - l > 1)
            {
                long m = (l + r) / 2;

                if (m * m <= A && A < (m + 1) * (m + 1))
                {
                    return (int)m;
                }

                if (m * m > A)
                {
                    r = m;
                }
                else
                {
                    l = m;
                }
                Console.WriteLine($"m={m},{Environment.NewLine} l={l}, r={r}");
            }

            if (l * l <= A && A < (l + 1) * (l + 1))
                return (int)l;
            else return (int)r;
        }
    }
}
