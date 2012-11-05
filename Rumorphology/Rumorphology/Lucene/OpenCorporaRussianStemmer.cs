using System.Collections.Generic;
using System.Linq;
using Rumorphology.OpenCorpora.DictionaryProcessor;

namespace Rumorphology.Lucene
{
    public class OpenCorporaRussianStemmer
    {
        private readonly IWordBaseFormQuery _baseFormQuery;

        public OpenCorporaRussianStemmer(IWordBaseFormQuery baseFormQuery)
        {
            _baseFormQuery = baseFormQuery;
        }

        public IEnumerable<string> Stem(string term)
        {
            return _baseFormQuery.GetLemmas(term).Select(t => t.Text);
        }
    }
}