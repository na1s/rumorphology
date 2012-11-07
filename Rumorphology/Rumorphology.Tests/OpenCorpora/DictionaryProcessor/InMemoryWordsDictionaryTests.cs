using System.Collections.Generic;
using NUnit.Framework;
using Rumorphology.OpenCorpora;
using Rumorphology.OpenCorpora.DictionaryProcessor;

namespace Rumorphology.Tests.OpenCorpora.DictionaryProcessor
{
    [TestFixture]
    public class InMemoryWordsDictionaryTests
    {
        [Test]
        public void Test()
        {
            var v = new InMemoryWordsDictionary();
            v.ProcessLemma(new Lemma()
                               {
                                   Text = "смесь",
                                   Forms = new List<LemmaForm>()
                                               {
                                                   new LemmaForm("смеси",new List<Grammem>()),
                                                    new LemmaForm("смесей",new List<Grammem>()),
                                               }
                               });
        }
    }
}