using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgoritmsConsole.Tasks_week_4
{
    class TaskE
    {
        public void DoWorkA()
        {
            var a = Console.ReadLine().Select(x => int.Parse(x.ToString())).ToArray();
            var b = Console.ReadLine().Select(x => int.Parse(x.ToString())).ToArray();

            var dif = new bool[a.Length];
            var difCount = 0;
            for (int i = 0; i < a.Length; i++)
            {
                dif[i] = a[i] != b[i];

                if (dif[i])
                {
                    difCount++;
                }
            }

            if (difCount % 2 > 0)
            {
                Console.WriteLine("impossible");
                return;
            }

            var needChange = difCount / 2;
            for (int i = 0; i < a.Length; i++)
            {
                if(needChange > 0 && dif[i])
                {
                    a[i] = a[i] == 0 ? 1 : 0;
                    needChange--;
                }
                if (needChange <= 0)
                {
                    break;
                }
            }

            Console.WriteLine(string.Join("", a));
        }

    }
}
