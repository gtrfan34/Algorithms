using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoritmsConsole.ClassTasks4
{
    class SumRootTree
    {
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { this.val = x; this.left = this.right = null; }
        }

        public int sumNumbers(TreeNode A)
        {
            var sum = 0;
            var list = new List<string>();
            var cur = A.val.ToString();
            SumTree(A, cur, list);

            foreach (var s in list)
            {
                var c = ulong.Parse(s) % 1003; 
                sum = (sum + (int)c) % 1003;
            }

            return sum;
        }

        private void SumTree(TreeNode a, string cur, List<string> list)
        {
            if (a.left == null && a.right == null)
            {
                list.Add(cur);
            }

            if (a.left != null)
            {
                SumTree(a.left, cur + a.left.val, list);
            }
            if (a.right != null)
            {
                SumTree(a.right, cur + a.right.val, list);
            }
        }
    }
}
