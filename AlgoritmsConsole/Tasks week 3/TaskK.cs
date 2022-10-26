using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgoritmsConsole.Tasks_week_3
{
    class TaskK
    {
        public void DoWork()
        {
            var arr = new int[5, 5];

            for (var i = 0; i < 5; i++)
            {
                var str = Console.ReadLine();
                var j = 0;
                foreach (var s in str.Split(" "))
                {
                    arr[i, j] = int.Parse(s);
                    j++;
                }
            }

            var fiveArr = new int[] { 0, 1, 2, 3, 4 };
            var max = 0;

            for (int i = 0; i < 5; i++)
            {
                var queue = new int[5];
                queue[0] = fiveArr[i];
                var fourArr = fiveArr.Where(x => x != queue[0]).ToArray();
                for (int j = 0; j < 4; j++)
                {
                    queue[1] = fourArr[j];

                    var threeArr = fourArr.Where(x => x != queue[1]).ToArray();
                    for (int k = 0; k < 3; k++)
                    {
                        queue[2] = threeArr[k];

                        var twoArr = threeArr.Where(x => x != queue[2]).ToArray();
                        for (int l = 0; l < 2; l++)
                        {
                            queue[3] = twoArr[l];
                            queue[4] = twoArr[1 - l];

                            var happines = arr[queue[0], queue[1]] + arr[queue[1], queue[0]] +
                            arr[queue[2], queue[3]] + arr[queue[3], queue[2]] +
                            arr[queue[1], queue[2]] + arr[queue[2], queue[1]] +
                            arr[queue[3], queue[4]] + arr[queue[4], queue[3]] +
                            arr[queue[2], queue[3]] + arr[queue[3], queue[2]] +
                            arr[queue[3], queue[4]] + arr[queue[4], queue[3]]; 

                            if (happines > max)
                            {
                                max = happines;
                            }
                        }
                    }
                }
            }

            Console.WriteLine(max);
        }
    }
}
