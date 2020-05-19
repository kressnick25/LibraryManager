using LibraryManager;
using NUnit.Framework;
using System.Collections.Generic;

namespace LibraryManagerTests
{
    public class MemberTest
    {
        Member member;
        Dictionary<string, string> d;
        Movie movie;
        [SetUp]
        public void Setup()
        {
            d = new Dictionary<string, string>
            {
                { "givenName", "Test" },
                { "lastName", "Tester" },
                { "address", "29 Classic Cr, Brisbane 4000" },
                { "phoneNumber", "0450934200" },
                { "password", "S%cuReP@$$w0rD1234" }
            };

            member = new Member(d["givenName"], d["lastName"], d["address"], d["phoneNumber"], d["password"]);
            movie = new Movie
                (
                    "Pulp Fiction", 
                    "Quinten Tarantino", 
                    "Other", 
                    new string(Movie.ClassificationEnum["MA"]), 
                    new System.DateTime(1994, 06, 09),
                    new string[] {"John Trevolta", "Samuel L. Jackson", "Uma Thurman", "Bruce Willis"}
                );
        }

        [Test]
        public void MemberProps()
        {
            Assert.AreEqual(d["address"], member.Address);
            Assert.AreEqual(d["phoneNumber"], member.PhoneNumber);
            Assert.AreEqual("Test Tester", member.Name);
            Assert.AreEqual("Test Tester", member.Key);
            Assert.AreEqual("TesterTest", member.UserName);
        }

        [Test]
        public void AddMovie()
        {
            member.AddMovie(movie);
            Assert.AreEqual(movie, member.GetMovie("Pulp Fiction"));
        }

        [Test]
        public void RemoveMovie()
        {
            member.AddMovie(movie);
            member.ReturnMovieToLibrary("Pulp Fiction");
            Assert.IsNull(member.GetMovie("Pulp Fiction"));
        }
    }
}
