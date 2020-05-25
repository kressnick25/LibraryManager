using System;

namespace LibraryManager
{
    public class Sort
    {
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
                int split = Partition(movies, leftIndex, rightIndex);

                if (split > 1)
                {
                    QuickSort(movies, leftIndex, split - 1);
                }
                if (split + 1 < rightIndex)
                {
                    QuickSort(movies, split + 1, rightIndex);
                }
            }
            // partition is sorted
        }
 
        private static int Partition(Movie[] movies, int leftIndex, int rightIndex)
        {
            
            int middleIndex = (int)Math.Round((double)((rightIndex - leftIndex)/2), 0);
            int pivot = movies[leftIndex + middleIndex].LoanedCount;
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
            }
        }
    }

}
