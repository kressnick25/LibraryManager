using BSTreeInterface;
using BSTreeClass;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager
{
    class MovieCollection
    {
        IBSTree collection;

        public MovieCollection()
        {
            this.collection = new BSTree();
        }

        public bool IsEmpty()
        {
            return collection.IsEmpty();
        }

        public bool Search(Movie movie)
        {
            return collection.Search(movie);
        }

        public void Insert(Movie movie)
        {
            collection.Insert(movie);
        }

        public void Delete(Movie movie)
        {
            collection.Delete(movie);
        }

        public void Clear()
        {
            collection.Clear();
        }
    }
}
