﻿using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
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


        /// <summary>
        /// Use quicksort algorithm to sort an array of Movies by title alphabetically
        /// </summary>
        /// <param name="movies">Array of movies, unsorted</param>
        /// <param name="leftIndex"></param>
        /// <param name="rightIndex"></param>
        public static void QuickSort(Movie[] movies, int leftIndex, int rightIndex)
        {
            if (leftIndex < rightIndex)
            {
                // get pivot point
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
            // partition is sorted
        }

        private static int Partition(Movie[] movies, int leftIndex, int rightIndex)
        {
            int pivot = movies[leftIndex + (rightIndex - leftIndex) / 2].LoanedCount;
            // Loop through partition, swapping elements, until sorted
            while (true)
            {
                // move left index to next value less than pivot
                while (movies[leftIndex].LoanedCount > pivot)
                {
                    leftIndex++;
                }
                // move right index to next value greater than pivot
                while (movies[rightIndex].LoanedCount < pivot)
                {
                    rightIndex--;
                }

                if (leftIndex > rightIndex || 
                    movies[leftIndex].LoanedCount == movies[rightIndex].LoanedCount)
                {
                    return rightIndex;
                }
                // swap the two elements
                Movie temp = movies[leftIndex];
                movies[leftIndex] = movies[rightIndex];
                movies[rightIndex] = temp;

                /*
                if (leftIndex < rightIndex)
                {
                    if (movies[leftIndex].LoanedCount == movies[rightIndex].LoanedCount)
                    {
                        return rightIndex;
                    }
                    // swap two elements
                    Movie temp = movies[leftIndex];
                    movies[leftIndex] = movies[rightIndex];
                    movies[rightIndex] = temp;
                }
                else
                {
                    return rightIndex;
                }
                */
            }
        }
    }

}
