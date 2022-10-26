using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgoritmsConsole.Tasks_week_4
{
    class TaskB
    {
        public void DoWorkA()
        {
            var k = long.Parse(Console.ReadLine());
            var nString = Console.ReadLine();
            long sum = 0;
            var digs = Enumerable.Repeat(0, 10).ToArray();

            for (int i = 0; i < nString.Length; i++)
            {
                var dig = int.Parse(nString[i].ToString());
                sum += dig;
                if (sum >= k)
                {
                    Console.WriteLine(0);
                    return;
                }
                digs[dig]++;
            }
            
            long modifiedSum = sum;
            long modifiedCount = 0;

            for (int i = 0; i < digs.Count() - 1; i++)
            {
                if (digs[i] == 0)
                {
                    continue;
                }

                long oldDigSum = digs[i] * i;
                long newDigSum = digs[i] * 9;
                
                long dif = newDigSum - oldDigSum; 

                if (modifiedSum + dif < k)
                {
                    modifiedSum += dif;
                    modifiedCount += digs[i];
                }
                else
                {
                    var target = k - modifiedSum;
                    var digDif = 9 - i;
                    var x = target / digDif;
                    if (target % digDif > 0)
                    {
                        x++;
                    }
                    modifiedCount += x;
                    break;
                }
            }

            Console.WriteLine(modifiedCount);
        }
    }
}
