using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgoritmsConsole.Tasks_week_3
{
    class Beacon
    {
        public int A { get; set; }
        public int B { get; set; }
    }
    class Beacons
    {
        public void DoWork()
        {
            var n = int.Parse(Console.ReadLine());

            var list = new List<Beacon>(n);
            var f = new Dictionary<int, int>();

            for (int i = 0; i < n; i++)
            {
                var str = Console.ReadLine();
                var beacon = new Beacon()
                {
                    A = int.Parse(str.Split(" ")[0]),
                    B = int.Parse(str.Split(" ")[1])
                };

                list.Add(beacon);
            }

            if (n <= 1)
            {
                Console.WriteLine(0);
                return;
            }

            list.Sort(new CoordinatesBasedComparer());

            var firstBeacon = list[0].A;
            f.Add(firstBeacon, 0);

            for (int i = 1; i < n; i++)
            {
                var dif = list[i].A - list[i].B;

                if (dif < firstBeacon)
                {
                    f.Add(list[i].A, i);
                    continue;
                }


                var index = list.BinarySearch(new Beacon() { A = dif }, new CoordinatesBasedComparer());
                if (index > 0)
                {
                    f.Add(list[i].A, f[list[index - 1].A] + i - index);
                }
                else if (index == 0)
                {
                    f.Add(list[i].A, i);
                }
                else
                {
                    index = ~index - 1;
                    f.Add(list[i].A, (index >= 0 ? f[list[index].A] - index : 0) + i - 1);
                }
            }

            var keys = f.Keys.ToList();
            var minBeacons = 1 + f[keys[n - 2]];
            for (int i = n - 1; i >= 0; i--)
            {
                var currentMin = f[keys[i]] + n - 1 - i;
                if (currentMin < minBeacons)
                {
                    minBeacons = currentMin;
                }
            }

            Console.WriteLine(minBeacons);


        }


        public void DynamicHashCheck()
        {
            var n = int.Parse(Console.ReadLine());

            var list = new List<Beacon>(n);
            var f = new Dictionary<int, int>();

            for (int i = 0; i < n; i++)
            {
                var str = Console.ReadLine();
                var beacon = new Beacon()
                {
                    A = int.Parse(str.Split(" ")[0]),
                    B = int.Parse(str.Split(" ")[1])
                };

                list.Add(beacon);
            }

            list.Sort(new CoordinatesBasedComparer());

            if (n == 1)
            {
                Console.WriteLine(0);
                return;
            }

            var minBeacons = int.MaxValue;
            f.Add(0, 0);

            for (int i = 1; i < n; i++)
            {
                var currentMin = int.MaxValue;
                var dif = list[i].A - list[i].B;
                if (dif < 0 && !f.ContainsKey(i))
                {
                    currentMin = n - 2;
                    f.Add(i, i - 1);
                    continue;
                }
                else
                {
                    var j = i - 1;
                    var c = 0;

                    while (j >= 0 && list[j].A >= dif)
                    {
                        j--;
                        c++;
                    }

                    f.Add(i, c + (j < 0 ? 0 : f[j]));
                    currentMin = c + (j < 0 ? 0 : f[j]) + n - 1 - i;
                }

                if (currentMin < minBeacons)
                {
                    minBeacons = currentMin;
                }
            }

            f.Add(n, 1 + (n - 2 < 0 ? 0 : f[n - 2]));
            var currMin = 1 + (n - 2 < 0 ? 0 : f[n - 2]);

            if (currMin < minBeacons)
            {
                minBeacons = currMin;
            }

            Console.WriteLine(minBeacons);
        }
        public void DynamicCheck()
        {
            var n = int.Parse(Console.ReadLine());

            var list = new List<Beacon>(n);
            var f = new List<int>(n + 1);

            for (int i = 0; i < n; i++)
            {
                var str = Console.ReadLine();
                var beacon = new Beacon()
                {
                    A = int.Parse(str.Split(" ")[0]),
                    B = int.Parse(str.Split(" ")[1])
                };

                list.Add(beacon);
            }

            list.Sort(new CoordinatesBasedComparer());

            if (n == 1)
            {
                Console.WriteLine(0);
                return;
            }

            f.Add(0);

            for (int i = 1; i < n; i++)
            {
                var dif = list[i].A - list[i].B;
                if (dif < 0)
                {
                    f.Add(i);
                    continue;
                }

                var j = i - 1;
                var c = 0;

                while (j >= 0 && list[j].A >= dif)
                {
                    j--;
                    c++;
                }

                f.Add(c + (j < 0 ? 0 : f[j]));
            }

            f.Add(1 + (n - 2 < 0 ? 0 : f[n - 2]));

            var minBeacons = f[n];
            for (int i = n - 1; i >= 0; i--)
            {
                var currentMin = f[i] + n - 1 - i;
                if (currentMin < minBeacons)
                {
                    minBeacons = currentMin;
                }
            }

            Console.WriteLine(minBeacons);
        }

        public void FullCheck()
        {
            var n = int.Parse(Console.ReadLine());

            var a = new List<int>(n);
            var b = new List<int>(n);

            for (int i = 0; i < n; i++)
            {
                var str = Console.ReadLine();

                a.Add(int.Parse(str.Split(" ")[0]));
                b.Add(int.Parse(str.Split(" ")[1]));
            }

            var minBeacons = n;
            for (int i = 0; i < n; i++)
            {
                var currentMin = Explode(a, b, i);
                if (currentMin < minBeacons)
                {
                    minBeacons = currentMin;
                }
            }

            Console.WriteLine(minBeacons);

        }

        private int Explode(List<int> a, List<int> b, int leftCount)
        {
            var destroyedBeacons = 0;
            var currentExplosion = int.MinValue;
            for (int i = a.Count - leftCount - 1; i >= 0; i--)
            {
                if (currentExplosion == int.MinValue || a[i] < currentExplosion)
                {
                    currentExplosion = a[i] - b[i];
                }
                else
                {
                    destroyedBeacons++;
                }
            }

            return destroyedBeacons + leftCount;
        }
    }
    class CoordinatesBasedComparer : IComparer<Beacon>
    {
        public int Compare(Beacon a, Beacon b)
        {
            if (a.A == b.A)
                return 0;
            if (a.A < b.A)
                return -1;

            return 1;
        }
    }
}
