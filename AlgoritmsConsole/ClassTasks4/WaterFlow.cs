using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgoritmsConsole.ClassTasks4
{
    class WaterFlow
    {

        class Node
        {
            public int x;
            public int y;

            public Node(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }
        public int solve(List<List<int>> A)
        {
            var n = A.Count;
            var m = A[0].Count;

            var arr = new int[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (i == 0 || j == 0)
                    {
                        arr[i, j] = 1;
                    }
                    if (i == n - 1 || j == m - 1)
                    {
                        arr[i, j] = 2;
                    }
                }
            }

            arr[0, m - 1] = 3;
            arr[n - 1, 0] = 3;


            for (int j = 0; j < m; j++)
            {
                var q = new Queue<Node>();
                q.Enqueue(new Node(0, j));
                DFS(q, A, arr, n, m, 1, new List<Node>());
            }
            for (int i = 0; i < n; i++)
            {
                var q = new Queue<Node>();
                q.Enqueue(new Node(i, 0));
                DFS(q, A, arr, n, m, 1, new List<Node>());
            }

            for (int j = 0; j < m; j++)
            {
                var q = new Queue<Node>();
                q.Enqueue(new Node(n - 1, j));
                DFS(q, A, arr, n, m, 2, new List<Node>());
            }
            for (int i = 0; i < n; i++)
            {
                var q = new Queue<Node>();
                q.Enqueue(new Node(i, m - 1));
                DFS(q, A, arr, n, m, 2, new List<Node>());
            }

            var counter = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (arr[i, j] == 3)
                    {
                        counter++;
                    }
                }
            }

            return counter;
        }

        private void DFS(Queue<Node> que, List<List<int>> A, int[,] arr, int n, int m, int color, List<Node> used)
        {

            while (que.Count > 0)
            {
                var cur = que.Dequeue();

                var i = cur.x;
                var j = cur.y;
                var curVal = A[i][j];
                if (used.Any(x => x.x == i && x.y == j))
                {
                    return;
                }
                used.Add(cur);
                if (arr[i, j] == 0)
                {
                    arr[i, j] = color;
                }
                else if (arr[i, j] + color == 3)
                {
                    arr[i, j] = 3;
                }

                if (/*j != 0 && j != m-1 &&*/ i - 1 >= 0 && A[i - 1][j] >= curVal)
                {
                    que.Enqueue(new Node(i - 1, j));
                }
                if (/*i != 0 && i != n - 1 &&*/ j - 1 >= 0 && A[i][j - 1] >= curVal /*&& arr[i, j-1] != color*/)
                {
                    que.Enqueue(new Node(i, j - 1));
                }
                if (/*j != 0 && j != m - 1 && */i + 1 < n && A[i + 1][j] >= curVal /*&& arr[i + 1, j] != color*/)
                {
                    que.Enqueue(new Node(i + 1, j));
                }
                if (/*i != 0 && i != n - 1 &&*/ j + 1 < m && A[i][j + 1] >= curVal /*&& arr[i, j+1] != color*/)
                {
                    que.Enqueue(new Node(i, j + 1));
                }

                DFS(que, A, arr, n, m, color, used);
            }
        }
    }
}
