using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager
{
    public class Algorithms
    {
        /// <summary>
        /// Compare two strings alphabetically
        /// </summary>
        /// <param name="a">String 1</param>
        /// <param name="b">String 2</param>
        /// <returns>
        /// -1 if a is less than b,
        /// 0 if a == b,
        /// 1 if a is greater than b
        /// </returns>
        /// <remarks>
        /// Kerighan, B. & Ritchie, D. (1988) strcmp example.
        /// The C Programming Language.Ch 5, p106.
        /// </remarks>
        public static int StringCompare(string a, string b)
        {
            int i;
            for (i=0; a[i] == b[i]; i++)
            {
                if (i < a.Length)
                    return 0;
            }
            int output = a[i] - b[i];
            if (output < 0)
                return -1;
            if (output > 0)
                return 1;
            return 0;
        }

        public static void QuickSort(Movie[] movies, int leftIndex, int rightIndex)
        {
            if (leftIndex < rightIndex)
            {
                int pivot = Partition(movies, leftIndex, rightIndex);

                if (pivot > 1)
                {
                    QuickSort(movies, leftIndex, pivot - 1);
                }
                if (pivot + 1 < rightIndex)
                {
                    QuickSort(movies, pivot + 1, rightIndex);
                }
            }
        }

        private static int Partition(Movie[] movies, int leftIndex, int rightIndex)
        {
            int pivot = movies[leftIndex + (rightIndex - leftIndex) / 2].LoanedCount;
            while (true)
            {

                while (movies[leftIndex].LoanedCount > pivot)
                {
                    leftIndex++;
                }

                while (movies[rightIndex].LoanedCount < pivot)
                {
                    rightIndex--;
                }

                if (leftIndex < rightIndex)
                {
                    if (Equals(movies[leftIndex].LoanedCount, movies[rightIndex].LoanedCount))
                    {
                        return rightIndex;
                    }
                    Movie temp = movies[leftIndex];
                    movies[leftIndex] = movies[rightIndex];
                    movies[rightIndex] = temp;
                }
                else
                {
                    return rightIndex;
                }
            }
        }
    }

}
