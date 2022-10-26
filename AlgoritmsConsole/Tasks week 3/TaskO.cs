using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace AlgoritmsConsole.Tasks_week_3
{
    class TaskO
    {
        public void DoWork()
        {
            var str = Console.ReadLine().Split(" ");
            var n = int.Parse(str[0]);
            var a = int.Parse(str[1]); //1
            var b = int.Parse(str[2]); //3

            var possibleABs = new List<Tuple<int, int>>();

            //count possible a + 3*b options
            for (int i = 0; i <= a; i++)
            {
                for (int j = 0; j <= b; j++)
                {
                    if (i + 3 * j == n)
                    {
                        possibleABs.Add(new Tuple<int, int>(i, j));
                    }
                }
            }

            var arr = new BigInteger[a + 1, b + 1];

            for (int i = 0; i <= a; i++)
            {
                arr[i, 0] = 1;

            }

            for (int j = 0; j <= b; j++)
            {
                arr[0, j] = 1;
            }

            arr[0, 0] = 0;

            for (int i = 1; i <= a; i++)
            {
                for (int j = 1; j <= b; j++)
                {
                    arr[i, j] = arr[i - 1, j] + arr[i, j - 1];
                }
            }

            BigInteger sum = 0;

            foreach (var item in possibleABs)
            {
                sum += arr[item.Item1, item.Item2];
            }

            Console.WriteLine(sum % 1000000009);
        }
    }
}
