using LibraryManager.DataStructures;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager
{
    /*
     * Represents a collection of movie DVDs
     * Uses a binary tree as a class member to store the movie DVDs
     */
    class MovieCollection
    {
        private BinaryTree<Movie> collection;
        public MovieCollection()
        {
            this.collection = new BinaryTree<Movie>(null);
        }

        public Movie Find(string key)
        {
            return (Movie)collection.Find(key);
        }

        public void Add(Movie movie)
        {
            collection.Insert(movie);
        }
        public void Remove(Movie movie)
        {
            collection.Remove(movie.Key);
        }

        public bool InCollection(Movie movie)
        {
            return collection.Find(movie.Key) != null;
        }
    }
}
