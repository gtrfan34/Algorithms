using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgoritmsConsole.ClassTasks4
{
    class PatternString
    {
        public void DoWork()
        {
            var n = int.Parse(Console.ReadLine());

            var arr = new List<char>();

            for (var i = 0; i < n; i++)
            {
                var s = Console.ReadLine();

                if (arr.Count == 0)
                {
                    arr.AddRange(Enumerable.Repeat('-', s.Length));
                }

                for (var j = 0; j < s.Length; j++)
                {
                    var cur = s[j];
                    if (arr[j] == '-')
                    {
                        if (cur == '?')
                        {
                            arr[j] = '*';
                        }
                        else
                        {
                            arr[j] = cur;
                        }
                    }
                    else if (arr[j] == '*')
                    {
                        if (cur != '?')
                        {
                            arr[j] = cur;
                        }
                    }
                    else if (arr[j] != cur && cur != '?')
                    {
                        arr[j] = '?';
                    }
                }

            }

            for (var j = 0; j < arr.Count; j++)
            {
                if (arr[j] == '*')
                {
                    arr[j] = 'a';
                }
            }

            Console.WriteLine(string.Join("", arr));


        }
    }
}
