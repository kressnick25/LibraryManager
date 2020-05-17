using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using LibraryManager;


namespace LibraryManagerTests
{
    class MovieTest
    {
        Movie mov;
        Member m1;

        [SetUp]
        public void Setup()
        {
            mov =
                new Movie
                (
                    "Star Wars",
                    "George Lucas",
                    Movie.Genre.SciFi,
                    Movie.ClassificationEnum["PG"],
                    new DateTime(2019, 12, 19),
                    new string[] { "Mark Hamill", "Carrie Fischer", "Harrison Ford" }
                );
        }

        [Test]
        public void Props()
        {
            Assert.AreEqual("Star Wars", mov.Title);
            Assert.AreEqual("George Lucas", mov.Director);
            Assert.AreEqual(new DateTime(2019, 12, 19), mov.ReleaseDate);
            Assert.AreEqual("[Mark Hamill, Carrie Fischer, Harrison Ford, ]", mov.Starring);
            Assert.AreEqual("Science Fiction", mov.GetGenre());
        }

        [Test]
        public void LoanTo()
        {

        }
    }
}
