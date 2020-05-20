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
            Assert.IsTrue(collection.Exists("Star Wars"));
            Assert.IsTrue(collection.Exists("Forrest Gump"));
        }

        [Test]
        public void Get()
        {
            collection.Add(mov1);
            collection.Add(mov2);
            Assert.AreEqual(mov1, collection.Get("Star Wars"));
            Assert.AreEqual(mov2, collection.Get("Forrest Gump"));
        }

        [Test]
        public void Delete()
        {
            // Add to collection
            Assert.IsFalse(collection.Exists(mov1.Title));
            collection.Add(mov1);
            Assert.IsFalse(collection.Exists(mov2.Title));
            collection.Add(mov2);

            // Remove from collection
            collection.Delete(mov1.Title);
            Assert.IsFalse(collection.Exists(mov1.Title));
            collection.Delete(mov2.Title);
            Assert.IsFalse(collection.Exists(mov2.Title));
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

        [Test]
        public void Count()
        {
            collection.Add(mov1);
            collection.Add(mov2);
            Assert.AreEqual(2, collection.Count());
        }
    }
}
