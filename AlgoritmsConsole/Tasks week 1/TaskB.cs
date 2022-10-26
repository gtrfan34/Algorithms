using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgoritmsConsole.Tasks_week_1
{
    class TaskB
    {
        public void ParcelRobot()
        {
            var allN = int.Parse(Console.ReadLine());

            var list = new List<List<Point>>();
            
            for (var k = 0; k < allN; k++)
            {
                var n = int.Parse(Console.ReadLine());
                var listPoint = new List<Point>();
                
                for (var i = 0; i < n; i++)
                {
                    var str = Console.ReadLine();
                    listPoint.Add(new Point() { x = int.Parse(str.Split(" ")[0]), y = int.Parse(str.Split(" ")[1])});
                }

                listPoint = listPoint.OrderBy(x => x.x).ThenBy(x => x.y).ToList();
                list.Add(listPoint);
            }

            for (var k = 0; k < allN; k++)
            {
                var listCur = list[k];
                var canPass = true;
                var route = new List<string>();
                var curX = 0;
                var curY = 0;

                for (var i = 0; i < listCur.Count; i++)
                {
                    var curParcel = listCur[i];
                    if (curParcel.x > curX)
                    {
                        var dif = curParcel.x - curX;
                        route.AddRange(Enumerable.Repeat("R", dif));
                        curX += dif;
                    }
                    else if (curParcel.x < curX)
                    {
                        canPass = false;
                        break;
                    }
                    if (curParcel.y > curY)
                    {
                        var dif = curParcel.y - curY;
                        route.AddRange(Enumerable.Repeat("U", dif));
                        curY += dif;
                    }
                    else if (curParcel.y < curY)
                    {
                        canPass = false;
                        break;
                    }
                }

                if (canPass)
                {
                    Console.WriteLine("YES");
                    Console.WriteLine(string.Join("", route.Select(x => x)));
                }
                else
                {
                    Console.WriteLine("NO");
                }
            }
        }

        public class Point
        {
            public int x;
            public int y;
        }
    }
}
