using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoritmsConsole.InterviewPrep
{
	//	Given an array arr[][] consisting of pair of integers denoting coordinates.The task is to return unique rectangles that can be formed using given coordinates.

	//Examples:

	//Input: arr[][] = {{0, 0}, { 0, 1}, { 1, 0}, { 1, 1}, { 2, 0}, { 2, 1}, { 11, 11}}
	//Output: (0, 0), (0, 1), (1, 0), (1, 1)
	//(0, 0), (0, 1), (2, 0), (2, 1)
	//(1, 0), (1, 1), (2, 0), (2, 1)

	//Input: arr[][] = { { 10, 0 }, { 0, 10 }, { 11, 11 }, { 0, 11 }, { 12, 10 } }
	//Output: none
	//Explanation: No Rectangles can be formed using these co-ordinates

	class Rectangle 
	{
		public int[,] points = new int[2, 4];
        public override int GetHashCode()
        {
			var isum = 0;
			var jsum = 0;
            for (int i = 0; i < 4; i++)
            {
				isum += points[i, 0];
				jsum += points[i, 1];
			}

			return int.Parse(isum.ToString() + jsum.ToString());
        }

        public override string ToString()
        {
            return $"({points[0,0]},{points[0,1]}),({points[1, 0]},{points[1, 1]}),({points[2, 0]},{points[2, 1]}),({points[3, 0]},{points[3, 1]}),";
        }
    }

	class RectanglesReturn
	{
		public void DoWork()
		{
			var arr = new int[,] { { 0, 0 }, { 0, 1 }, { 1, 0 }, { 1, 1 }, { 2, 0 }, { 2, 1 }, { 11, 11 } };
			//var arr = new int[,] { { 10, 0 }, { 0, 10 }, { 11, 11 }, { 0, 11 }, { 12, 10 } };
			foreach(var rec in GetCount(arr))
            {

				Console.WriteLine(rec);
			}
		}

		private List<Rectangle> GetCount(int[,] arr)
		{
			if (arr == null || arr.Length < 4)
			{
				return new List<Rectangle>();
			}

			var n = arr.GetLength(0);
			var set = new HashSet<KeyValuePair<int, int>>(n);

			for (int i = 0; i < n; i++)
			{
				set.Add(new KeyValuePair<int, int>(arr[i, 0], arr[i, 1]));
			}

			var recs = new List<Rectangle>();
			var hash = new HashSet<int>();

			for (int i = 0; i < n; i++)
			{
				for (int j = 0; j < n; j++)
				{
					if (arr[i, 0] != arr[j,0] &&
						arr[i, 1] != arr[j, 1])
                    {
						if(set.Contains(new KeyValuePair<int, int>(arr[i,0], arr[j,1])) &&
							set.Contains(new KeyValuePair<int, int>(arr[j, 0], arr[i, 1])))
						{
							var rec = new Rectangle();
							rec.points = new int[,] { { arr[i, 0], arr[i, 1] }, { arr[j, 0], arr[j, 1] }, { arr[i, 0], arr[j, 1] }, { arr[j, 0], arr[i, 1] } };
							var hash1 = rec.GetHashCode();
                            if (!hash.Contains(hash1))
                            {
								recs.Add(rec);
								hash.Add(hash1);
                            }
                        }

					}
				}
			}

			return recs;
		}
	}
}