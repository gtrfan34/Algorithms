using System;

namespace AlgoritmsConsole.Tasks_week_1
{
    class TaskC
    {
        public void DoWork()
        {
            var str = Console.ReadLine();
            var n = int.Parse(str.Split(" ")[0]);
            var k = int.Parse(str.Split(" ")[1]);
            var a = new int[n];

            str = Console.ReadLine();
            var i = 0;

            foreach (var el in str.Split(" "))
            {
                a[i++] = int.Parse(el);
            }

            Array.Sort(a);

            if (k == 0)
            {
                if (a[0] == 1)
                    Console.WriteLine(-1);
                else
                    Console.WriteLine(a[0] - 1);
            }
            else if (k == n || a[k - 1] < a[k])
            {
                Console.WriteLine(a[k - 1]);
            }
            else if (a[k - 1] >= a[k])
            {
                Console.WriteLine(-1);
            }


        }
    }
}
