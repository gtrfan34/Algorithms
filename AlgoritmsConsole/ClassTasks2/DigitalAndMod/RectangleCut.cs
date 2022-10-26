namespace AlgoritmsConsole.ClassTasks2.DigitalAndMod
{
    class RectangleCut
    {
        public int Cut(int n, int m) 
        {
            if (m > n) 
            {
                return Cut(m, n);
            }
            if (m == n) 
            {
                return m;
            }

            if (n == 1) { return m; }

            if (m == 1) { return n; }

            var count = 0;

            var y = 1;
            for (var i = 1; i <= n; i++) 
            {
                if ((m * i) / n < y || i == n)
                {
                    count++;
                }
                else if ((m * i) / n == y && (m * i) % n == 0)
                {
                    continue;
                }
                else 
                { 
                    count += 2;
                    y++;
                }
            }

            return count;
        }

        public int CutLog(int n, int m)
        {
            var gcd = GCD(n, m);

            return n + m - gcd;
        }

        private int GCD(int n, int m)
        {
            if (m > n) 
            {
                return GCD(m, n);
            }

            if (n % m == 0) 
            {
                return m;
            }
            else
            {
                return GCD(m, n % m);
            }
        }
    }
}
