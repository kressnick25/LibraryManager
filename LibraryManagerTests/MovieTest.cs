using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using LibraryManager;
using System.Diagnostics;

namespace LibraryManagerTests
{
    class MovieTest
    {
        Movie mov;
        Member m1;
        Dictionary<string, string> d;


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
            d = new Dictionary<string, string>
            {
                { "givenName", "Test" },
                { "lastName", "Tester" },
                { "address", "29 Classic Cr, Brisbane 4000" },
                { "phoneNumber", "0450934200" },
                { "password", "S%cuReP@$$w0rD1234" }
            };
            m1 = new Member(d["givenName"], d["lastName"], d["address"], d["phoneNumber"], d["password"]);
        }

        [Test]
        public void Props()
        {
            Assert.AreEqual("Star Wars", mov.Title);
            Assert.AreEqual("George Lucas", mov.Director);
            Assert.AreEqual(new DateTime(2019, 12, 19), mov.ReleaseDate);
            Assert.AreEqual("Mark Hamill, Carrie Fischer, Harrison Ford, ", mov.Starring);
            Assert.AreEqual("Science Fiction", mov.GetGenre());
        }

        [Test]
        public void LoanTo()
        {
            Assert.False(mov.onLoan);
            mov.LoanTo(m1);
            Assert.AreEqual(mov.LoanedTo, m1);
            Assert.True(mov.onLoan);
        }

        [Test]
        public void TestToString()
        {
            Assert.DoesNotThrow(() =>
            {
                Console.WriteLine(mov.ToString());
            });
        }
    }
}
