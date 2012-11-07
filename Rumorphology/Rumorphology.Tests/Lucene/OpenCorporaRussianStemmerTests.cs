using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;
using Rumorphology.Lucene;
using Rumorphology.OpenCorpora;
using Rumorphology.OpenCorpora.DictionaryProcessor;

namespace Rumorphology.Tests.Lucene
{
    [TestFixture]
    public class OpenCorporaRussianStemmerTests
    {
        [Test]
        public void Test()
        {
            var baseFormQuery = new Mock<IWordBaseFormQuery>();
            baseFormQuery.Setup(b => b.GetLemmas("смеси")).Returns(new List<Lemma>
                                                                       {
                                                                           new Lemma
                                                                               {
                                                                                   Text = "смесь"
                                                                               },
                                                                           new Lemma
                                                                               {
                                                                                   Text = "смесить"
                                                                               }
                                                                       });
            var stemmer = new OpenCorporaRussianStemmer(baseFormQuery.Object);
            Assert.AreEqual(new[] { "смесь", "смесить" }.OrderBy(t => t), stemmer.Stem("смеси").OrderBy(t => t));
        }
    }
}