using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using LibraryManager;
using NuGet.Frameworks;
using System.Xml.Serialization;

namespace LibraryManagerTests
{
    class MemberCollectionTest
    {
        Member m1;
        Member m3;
        Dictionary<string, string> d;
        MemberCollection collection;

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

            m1 = new Member(d["givenName"], d["lastName"], d["address"], d["phoneNumber"], d["password"]);
            m3 = new Member(new string("Super"), d["lastName"], d["address"], d["phoneNumber"], d["password"]);

            collection = new MemberCollection();
        }

        [Test]
        public void Add()
        {
            collection.Add(m1);
            Assert.Throws<KeyNotFoundException>(() => collection.Add(m1));
            collection.Add(m3);
        }

        [Test]
        public void Find()
        {
            Assert.Throws<KeyNotFoundException>(() => collection.Find("Test Tester"));
            collection.Add(m1);
            Assert.Throws<KeyNotFoundException>(() => collection.Find("Test"));
            Member m2 = collection.Find("Test Tester");
            Assert.AreEqual(m1.Name, m2.Name);
            Assert.AreEqual(m1.PhoneNumber, m2.PhoneNumber);
            Assert.AreEqual(m1.Address, m2.Address);
        }

        [Test]
        public void FindUsername()
        {
            Assert.Throws<KeyNotFoundException>(() => collection.FindUsername("TesterTest"));
            collection.Add(m1);
            Assert.Throws<KeyNotFoundException>(() => collection.FindUsername("Test"));
            Member m2 = collection.FindUsername("TesterTest");
            Assert.AreEqual(m1.Name, m2.Name);
            Assert.AreEqual(m1.PhoneNumber, m2.PhoneNumber);
            Assert.AreEqual(m1.Address, m2.Address);
        }

        [Test]
        public void Length()
        {
            collection.Add(m1);
            collection.Add(m3);
            Assert.AreEqual(collection.Length, 2);
        }
    }
}
