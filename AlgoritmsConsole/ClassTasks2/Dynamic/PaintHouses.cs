using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoritmsConsole.ClassTasks2.Dynamic
{
    class PaintHouses
    {
        public int solve(List<List<int>> A)
        {
            var fr = A[0][0];
            var fb = A[0][1];
            var fg = A[0][2];


            for (int i = 1; i < A.Count; i++)
            {
                var frmin = Math.Min(fb, fg);
                var fbmin = Math.Min(fr, fg);
                var fgmin = Math.Min(fr, fb);

                fr = frmin + A[i][0];
                fb = frmin + A[i][1];
                fg = frmin + A[i][2];
            }

            return Math.Min(fr, Math.Min(fg, fb));
        }
    }
}
