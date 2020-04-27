using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace LibraryManager.DataStructures
{
    class LoanOperations
    { // Handles loaning and returning movies with required checks for each operation

        public static void LoanMovie(MovieCollection collection, Member member, Movie movie)
        {
            if (collection.Find(movie.Key) == null)
                throw new ArgumentException($"Movie [{movie.Key}] not found in current collection. Perhaps it is already on loan.");
        }

        public static void ReturnMovie(MovieCollection collection, Member member, Movie movie)
        {

        }
    }
}
