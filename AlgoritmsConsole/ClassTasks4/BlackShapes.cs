using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoritmsConsole.ClassTasks4
{
    class BlackShapes
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

        public int black(List<string> A)
        {
            var n = A.Count;
            var m = A[0].Length;
            var arr = new int[n, m];
            var shapeCounter = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    arr[i, j] = A[i][j] == 'X' ? 1 : 0;
                }
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (arr[i, j] == 1)
                    {
                        var q = new Queue<Node>();
                        q.Enqueue(new Node(i, j));
                        DFS(q, arr, n,m);
                        shapeCounter++;
                    }
                }
            }

            return shapeCounter;

        }

        private void DFS(Queue<Node> que, int[,] arr, int n, int m)
        {

            while( que.Count > 0)
            {
                var cur = que.Dequeue();
                var i = cur.x;
                var j = cur.y;
                arr[i,j] = 2;

                if (i-1 >= 0 && arr[i-1, j] == 1)
                {
                    que.Enqueue(new Node(i - 1, j));
                }
                if (j - 1 >= 0 && arr[i, j-1] == 1)
                {
                    que.Enqueue(new Node(i, j-1));
                }
                if (i + 1 < n && arr[i +1,j] == 1)
                {
                    que.Enqueue(new Node(i+1, j));
                }
                if (j + 1 < m && arr[i, j+1] == 1)
                {
                    que.Enqueue(new Node(i, j+1));
                }

                DFS(que, arr, n, m);
            }
        }
    }
}
