using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgoritmsConsole
{
    class Program
    {
        class Element
        {
            public int value;
            public Element next;
        }

        static void Main(string[] args)
        {
            var input1 = new[] { 1,4, 6, 30, 100};
            var input2 = 5;
            var input3 = 99;

            var res = coins(input1, input2, input3);
        }

        public static int[] coins (int[] input1, int input2, int input3)
        {
            Array.Sort(input1);
            var res = new Stack<int>();
            var target = input3;
            var i = input2 -1;
            while(target != 0)
            {
                if (target/input1[i] > 0)
                {
                    for (int k = 0; k < target / input1[i]; k++)
                    {
                        res.Push(input1[i]);
                    }
                    target = target % input1[i];
                }
                else
                {
                    i--;
                }

                if(i < 0 && target != 0)
                {
                    var curDel = res.Pop();
                    i = Array.IndexOf(input1, curDel) - 1;
                }
            }

            return res.ToArray();
        }
    }
}
