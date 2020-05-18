using BSTreeInterface;
using BSTreeClass;
using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace LibraryManager
{
    public class MovieCollection
    {
        BSTree collection;

        public MovieCollection()
        {
            this.collection = new BSTree();
        }

        public bool IsEmpty()
        {
            return collection.IsEmpty();
        }

        public Movie Get(Movie movie)
        {
            return (Movie)collection.Get(movie);
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

        public void PrintMovies(bool descending)
        {
            if (descending)
            {
                collection.InOrderTraverse();
            }
            else
            {
                collection.PostOrderTraverse();
            }
        }
    }
}
