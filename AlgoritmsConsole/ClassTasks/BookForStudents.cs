using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgoritmsConsole.ClassTasks
{
    class BookForStudents
    {
        public int books1(List<int> A, int B)
        {
            var l = A.Min();
            var r = A.Sum();
            var min = r;

            if (B == 1)
            {
                return r;
            }
            if (A.Count < B)
            {
                return -1;
            }

            while (l <= r)
            {
                var m = (r + l) / 2;
                var count = GetStudCount(A, m);
                if (count == B && m < min)
                {
                    min = m;
                }

                if (count > B || count == -1)
                {
                    l = m + 1;
                }
                else
                {
                    r = m - 1;
                }
            }

            return min;

        }

        private int GetStudCount(List<int> A, int V)
        {
            var sum = 0;
            var studentCount = 1;

            for (var i = 0; i < A.Count; i++)
            {
                if (A[i] > V)
                {
                    return -1;
                }
                if (sum + A[i] > V)
                {
                    studentCount++;
                    sum = A[i];
                }
                else
                {
                    sum += A[i];
                }

            }

            return studentCount;
        }

        public int books(List<int> A, int B)
        {
            return FindPages(A.ToArray(), A.Count, B);
        }
        bool IsPossible(int[] pages, int numberOfBooks, int numberOfStudents, int halfOfTotalPages)
        {
            int studentsRequired = 1;
            int curr_sum = 0;

            // iterate over all books
            for (int i = 0; i < numberOfBooks; i++)
            {
                // check if current number of pages are greater
                // than curr_min that means we will get the result
                // after mid no. of pages
                if (pages[i] > halfOfTotalPages)
                    return false;

                // count how many students are required
                // to distribute curr_min pages
                if (curr_sum + pages[i] > halfOfTotalPages)
                {
                    // increment student count
                    studentsRequired++;

                    // update curr_sum
                    curr_sum = pages[i];

                    // if students required becomes greater
                    // than given no. of students,return false
                    if (studentsRequired > numberOfStudents)
                        return false;
                }

                // else update curr_sum
                else
                    curr_sum += pages[i];
            }
            return true;
        }

        // function to find minimum pages
        public int FindPages(int[] pages, int numberOfBooks, int numberOfStudents)
        {
            int totalPages = 0;

            // return -1 if no. of books is less than
            // no. of students
            if (numberOfBooks < numberOfStudents)
                return -1;

            // Count total number of pages
            for (int i = 0; i < numberOfBooks; i++)
                totalPages += pages[i];

            // initialize start as 0 pages and end as
            // total pages
            int start = 0, end = totalPages;
            int result = int.MaxValue;

            // traverse until start <= end
            while (start <= end)
            {
                // check if it is possible to distribute
                // books by using mid is current minimum
                int halfOfTotalPages = (start + end) / 2;
                if (IsPossible(pages, numberOfBooks, numberOfStudents, halfOfTotalPages))
                {
                    // if yes then find the minimum distribution
                    result = Math.Min(result, halfOfTotalPages);

                    // as we are finding minimum and books
                    // are sorted so reduce end = mid -1
                    // that means
                    end = halfOfTotalPages - 1;
                }

                else
                    // if not possible means pages should be
                    // increased so update start = mid + 1
                    start = halfOfTotalPages + 1;
            }

            // at-last return minimum no. of  pages
            return result;
        }
    }
}
