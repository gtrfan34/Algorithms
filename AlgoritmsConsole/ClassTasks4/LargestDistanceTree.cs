using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgoritmsConsole.ClassTasks4
{
    class LargestDistanceTree
    {
        public class Node
        {
            public List<Node> Children { get; set; }
        }

        public int solve(List<int> A)
        {
            var list = new List<Node>(A.Count);
            for (var i = 0; i < A.Count; i++)
            {
                list.Add(new Node() { Children = new List<Node>() });
            }

            Node root = null;
            for (var i = 0; i < A.Count; i++)
            {
                var parent = A[i];
                if (parent == -1)
                {
                    root = list[i];
                }
                else
                {
                    list[parent].Children.Add(list[i]);
                }
            }
            DFS(root);
            return MaxDist;
        }

        private static int MaxDist = 0;

        public int DFS(Node root)
        {
            if (root.Children.Count == 0)
            {
                return 0;
            }

            var depth = new List<int>();
            foreach (var n in root.Children)
            {
                depth.Add(DFS(n) + 1);
            }

            depth = depth.OrderByDescending(x => x).ToList();
            var maxDist = depth.Take(2).Sum();
            if (MaxDist < maxDist)
            {
                MaxDist = maxDist;
            }

            return depth.First();
        }
    }
}
