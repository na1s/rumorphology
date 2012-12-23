using System.Linq;
using NUnit.Framework;
using Rumorphology.Utils;

namespace Rumorphology.Tests.Utils
{
    [TestFixture]
    public class TrieTest
    {
        [Test]
        public void Test()
        {
            var finder = new Finder();
            finder.InsertObject("id1", "кружка");
            finder.InsertObject("id2", "кружки");
            finder.InsertObject("id3", "кржок");
            finder.InsertObject("id4", "кружками");
            var result = finder.GetSimularNames("Кружки", 0);
            Assert.AreEqual("id2", result.First());
        }

        [Test]
        public void Test1()
        {
            var finder = new Finder();
            finder.InsertObject("id1", "кружка");
            finder.InsertObject("id2", "кружками");
            finder.InsertObject("id3", "кржок");
            finder.InsertObject("id4", "кружками");
            var result = finder.GetSimularNames("кружкамы", 1);
            Assert.AreEqual("id2", result.First());
        }
    }
}