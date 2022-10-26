using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoritmsConsole.InterviewPrep
{
//	Given an array arr[][] consisting of pair of integers denoting coordinates.The task is to count the total number of rectangles that can be formed using given coordinates.

//Examples:

//Input: arr[][] = {{0, 0}, { 0, 1}, { 1, 0}, { 1, 1}, { 2, 0}, { 2, 1}, { 11, 11}}
//Output: 3
//Explanation: Following are the rectangles formed using given coordinates. 
//First Rectangle(0, 0), (0, 1), (1, 0), (1, 1)
//Second Rectangle(0, 0), (0, 1), (2, 0), (2, 1)
//Third Rectangle(1, 0), (1, 1), (2, 0), (2, 1)

//Input: arr[][] = { { 10, 0 }, { 0, 10 }, { 11, 11 }, { 0, 11 }, { 12, 10 } }
//Output: 0
//Explanation: No Rectangles can be formed using these co-ordinates
	class RectanglesCount
	{
		public void DoWork()
		{
			var arr = new int[,] { { 0, 0 }, { 0, 1 }, { 1, 0 }, { 1, 1 }, { 2, 0 }, { 2, 1 }, { 11, 11 } };
			//var arr = new int[,] { { 10, 0 }, { 0, 10 }, { 11, 11 }, { 0, 11 }, { 12, 10 } };
			Console.WriteLine(GetCount(arr));
		}

		private int GetCount(int[,] arr)
		{
			if (arr == null || arr.Length < 4)
			{
				return 0;
			}

			var n = arr.GetLength(0);
			var set = new HashSet<KeyValuePair<int, int>>(n);

			for (int i = 0; i < n; i++)
			{
				set.Add(new KeyValuePair<int, int>(arr[i, 0], arr[i, 1]));
			}

			var counter = 0;

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
							counter++;
                        }

					}
				}
			}

			return counter / 4;
		}
	}
}