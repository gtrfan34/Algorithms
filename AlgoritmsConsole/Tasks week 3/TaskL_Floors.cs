using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoritmsConsole.Tasks_week_3
{
    class TaskL_Floors
    {
        public void DoTest()
        {
            //var arr1 = new int[,]
            //{
            //    {0,0,0},
            //    {0,1,0},
            //    {0,1,0},
            //    {0,1,0}
            //};
            //var first1 = DoWorkFunc(4, 3, arr1);
            //return;

            while (true)
            {
                var rand = new Random();
                var n = rand.Next(1, 16);
                
                var rand1 = new Random();
                var m = rand1.Next(3, 103);

                var rand2 = new Random();

                var arr = new int[n, m];

                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        if (j==0 || j == m - 1)
                        {
                            arr[i, j] = 0;
                        }
                        else
                        {
                            arr[i, j] = rand2.Next(0, 2);
                        }
                        Console.Write(arr[i, j]);
                    }
                    Console.WriteLine();
                }

                var first = DoWorkFunc(n, m, arr);
                var second = DoWork2Func(n, m, arr);

                Console.WriteLine(first);
                Console.WriteLine(second);

                if (first != second)
                {
                    Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                    Console.ReadLine();
                }

            }
        }

        public int DoWorkFunc(int n, int m, int[,] arr)
        {
            var list = new List<Tuple<int, int>>(n);
            var lastFloorWithLights = -1;
            for (int i = 0; i < n; i++)
            {
                var first = -1;
                var last = -1;
                for (int j = 0; j < m; j++)
                {
                    if (arr[i, j] == 1)
                    {
                        if (first < 0)
                        {
                            first = j;
                        }
                        last = j;
                        lastFloorWithLights = i;
                    }
                }

                list.Add(new Tuple<int, int>(first, last));
            }

            if (lastFloorWithLights < 0)
            {
                return 0;
            }

            var curIndex = 0;
            var steps = 0;
            var stepsIfNoLight = 0;

            if (list[0].Item2 > 0)
            {
                curIndex = list[0].Item2;
                steps = list[0].Item2;
            }
            else
            {
                //stepsIfNoLight = 1;
            }

            var leftSteps = Recursive(list, true, curIndex, 1, lastFloorWithLights, steps, m, stepsIfNoLight);
            var rightSteps = Recursive(list, false, curIndex, 1, lastFloorWithLights, steps, m, stepsIfNoLight);

            return Math.Min(leftSteps, rightSteps);
        }

        public void DoWork()
        {
            var str = Console.ReadLine();
            var n = int.Parse(str.Split(" ")[0]);
            var m = int.Parse(str.Split(" ")[1]);
            m += 2;
            var arr = new int[n, m];

            for (var i = n - 1; i >= 0; i--)
            {
                str = Console.ReadLine();
                var j = 0;

                foreach (var s in str)
                {
                    arr[i, j] = int.Parse(s.ToString());
                    j++;
                }
            }

            var list = new List<Tuple<int, int>>(n);
            var lastFloorWithLights = -1;
            for (int i = 0; i < n; i++)
            {
                var first = -1;
                var last = -1;
                for (int j = 0; j < m; j++)
                {
                    if (arr[i, j] == 1)
                    {
                        if (first < 0)
                        {
                            first = j;
                        }
                        last = j;
                        lastFloorWithLights = i;
                    }
                }

                list.Add(new Tuple<int, int>(first, last));
            }

            if (lastFloorWithLights < 0)
            {
                Console.WriteLine(0);
                return;
            }

            var curIndex = 0;
            var steps = 0;
            var stepsIfNoLight = 0;

            if (list[0].Item2 > 0)
            {
                curIndex = list[0].Item2;
                steps = list[0].Item2;
            }else
            {
                //stepsIfNoLight = 1;
            }

            var leftSteps = Recursive(list, true, curIndex, 1, lastFloorWithLights, steps, m, stepsIfNoLight);
            var rightSteps = Recursive(list, false, curIndex, 1, lastFloorWithLights, steps, m, stepsIfNoLight);

            Console.WriteLine(Math.Min(leftSteps, rightSteps));
        }

        private int Recursive(List<Tuple<int,int>> list, bool left, int curIndex, int currFloor, int lastFloorWithLights, int steps, int m, int stepIfNoLigths)
        {
            if (currFloor > lastFloorWithLights)
            {
                return steps;
            }

            if (list[currFloor].Item2 < 0)
            {
                stepIfNoLigths++;
            }
            else if (left)
            {
                steps += curIndex + list[currFloor].Item2 + stepIfNoLigths + 1;
                curIndex = list[currFloor].Item2;
                stepIfNoLigths = 0;
            }
            else
            {
                steps += m - 1 - curIndex + m - 1 - list[currFloor].Item1 + stepIfNoLigths + 1;
                curIndex = list[currFloor].Item1;
                stepIfNoLigths = 0;
            }

            var leftSteps = Recursive(list, true, curIndex, currFloor + 1, lastFloorWithLights, steps, m, stepIfNoLigths);
            var rightSteps = Recursive(list, false, curIndex, currFloor + 1, lastFloorWithLights, steps, m, stepIfNoLigths);

            return Math.Min(leftSteps, rightSteps);
        }

        public int DoWork2Func(int n, int m, int[,] arr)
        {
            var list = new List<Tuple<int, int>>(n);

            for (int i = 0; i < n; i++)
            {
                var first = -1;
                var last = -1;
                for (int j = 0; j < m; j++)
                {
                    if (arr[i, j] == 1)
                    {
                        if (first < 0)
                        {
                            first = j;
                        }
                        last = j;
                    }
                }

                list.Add(new Tuple<int, int>(first, last));
            }

            var curIndex = 0;
            var steps = 0;
            var stepsIfNoLight = 0;

            if (list[0].Item2 > 0)
            {
                curIndex = list[0].Item2;
                steps = list[0].Item2;
            }

            for (int i = 0; i < n - 1; i++)
            {
                if (list[i + 1].Item2 < 0)
                {
                    stepsIfNoLight++;
                    continue;
                }

                var stepLeft = curIndex + list[i + 1].Item2;
                var stepRight = m - 1 - curIndex + m - 1 - list[i + 1].Item1;
                if (stepLeft < stepRight)
                {
                    steps += stepLeft;
                    curIndex = list[i + 1].Item2;
                }
                else if (i + 2 > n - 1 || stepLeft > stepRight || list[i + 2].Item2 < 0)
                {
                    steps += stepRight;
                    curIndex = list[i + 1].Item1;
                }
                else
                {
                    var checkStepLeft = list[i + 1].Item2 + list[i + 2].Item2;
                    var checkStepRight = m - 1 - list[i + 1].Item1 + m - 1 - list[i + 2].Item1;
                    if (checkStepLeft < checkStepRight)
                    {
                        steps += stepRight;
                        curIndex = list[i + 1].Item1;
                    }
                    else
                    {
                        steps += stepLeft;
                        curIndex = list[i + 1].Item2;
                    }
                }

                steps += 1 + stepsIfNoLight;
                stepsIfNoLight = 0;
            }

            return steps;
        }
        public void DoWork2()
        {
            var str = Console.ReadLine();
            var n = int.Parse(str.Split(" ")[0]);
            var m = int.Parse(str.Split(" ")[1]);
            m += 2;
            var arr = new int[n, m];

            for (var i = n - 1; i >= 0; i--)
            {
                str = Console.ReadLine();
                var j = 0;

                foreach (var s in str)
                {
                    arr[i, j] = int.Parse(s.ToString());
                    j++;
                }
            }

            var list = new List<Tuple<int, int>>(n);

            for (int i = 0; i < n; i++)
            {
                var first = -1;
                var last = -1;
                for (int j = 0; j < m; j++)
                {
                    if (arr[i, j] == 1)
                    {
                        if (first < 0)
                        {
                            first = j;
                        }
                        last = j;
                    }
                }

                list.Add(new Tuple<int, int>(first, last));
            }

            var curIndex = 0;
            var steps = 0;
            var stepsIfNoLight = 0;

            if (list[0].Item2 > 0)
            {
                curIndex = list[0].Item2;
                steps = list[0].Item2;
            }

            for (int i = 0; i < n - 1; i++)
            {
                if (list[i + 1].Item2 < 0)
                {
                    stepsIfNoLight++;
                    continue;
                }

                var stepLeft = curIndex + list[i + 1].Item2;
                var stepRight = m - 1 - curIndex + m - 1 - list[i + 1].Item1;
                if (stepLeft < stepRight)
                {
                    steps += stepLeft;
                    curIndex = list[i + 1].Item2;
                }
                else if (i + 2 > n - 1 || stepLeft > stepRight || list[i + 2].Item2 < 0)
                {
                    steps += stepRight;
                    curIndex = list[i + 1].Item1;
                }
                else
                {
                    var checkStepLeft = list[i + 1].Item2 + list[i + 2].Item2;
                    var checkStepRight = m - 1 - list[i + 1].Item1 + m - 1 - list[i + 2].Item1;
                    if (checkStepLeft < checkStepRight)
                    {
                        steps += stepRight;
                        curIndex = list[i + 1].Item1;
                    }
                    else
                    {
                        steps += stepLeft;
                        curIndex = list[i + 1].Item2;
                    }
                }

                steps += 1 + stepsIfNoLight;
                stepsIfNoLight = 0;
            }

            Console.WriteLine(steps);
        }
    }
}
