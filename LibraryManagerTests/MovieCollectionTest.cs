using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using LibraryManager;
using NUnit.Framework.Constraints;

namespace LibraryManagerTests
{
    class MovieCollectionTest
    {
        MovieCollection collection;
        Movie mov1;
        Movie mov2;

        [SetUp]
        public void Setup()
        {
            collection = new MovieCollection();
            mov1 =
                new Movie
                (
                    "Star Wars",
                    "George Lucas",
                    "Science Fiction",
                    Movie.ClassificationEnum["PG"],
                    new DateTime(1977, 10, 27),
                    new string[] { "Mark Hamill", "Carrie Fischer", "Harrison Ford" }
                );
            mov2 =
                new Movie
                (
                    "Forrest Gump",
                    "Robert Zemeckis",
                    "Drama",
                    Movie.ClassificationEnum["PG"],
                    new DateTime(1994, 11, 17),
                    new string[] { "Tom Hanks", "Robin Wright", "Sally Field" }
                );
        }

        [Test]
        public void Insert()
        {
            Assert.DoesNotThrow(() =>
            {
                collection.Add(mov1);
                collection.Add(mov2);
            });
        }

        [Test]
        public void Search()
        {
            collection.Add(mov1);
            collection.Add(mov2);
            Assert.IsTrue(collection.Search(new Movie("Star Wars")));
            Assert.IsTrue(collection.Search(new Movie("Forrest Gump")));
        }

        [Test]
        public void Get()
        {
            collection.Add(mov1);
            collection.Add(mov2);
            Assert.AreEqual(mov1, collection.Get(new Movie("Star Wars")));
            Assert.AreEqual(mov2, collection.Get(new Movie("Forrest Gump")));
        }

        [Test]
        public void Delete()
        {
            // Add to collection
            Assert.IsFalse(collection.Search(mov1));
            collection.Add(mov1);
            Assert.IsFalse(collection.Search(mov2));
            collection.Add(mov2);

            // Remove from collection
            collection.Delete(mov1);
            Assert.IsFalse(collection.Search(mov1));
            collection.Delete(mov2);
            Assert.IsFalse(collection.Search(mov2));
        }

        [Test]
        public void Print()
        {
            collection.Add(mov1);
            collection.Add(mov2);
            Assert.DoesNotThrow(() =>
            {
                collection.PrintMovies(true);
            });
        }
    }
}
