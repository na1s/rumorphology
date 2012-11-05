using System.Linq;
using Lucene.Net.Analysis;
using Lucene.Net.Analysis.Tokenattributes;
using Rumorphology.OpenCorpora.DictionaryProcessor;

namespace Rumorphology.Lucene
{
    public class OpenCorporaRussianStemFilter : TokenFilter
    {
        private readonly OpenCorporaRussianStemmer stemmer;
        private readonly ITermAttribute termAtt;
        private int _pos;
        private string[] _terms;

        public OpenCorporaRussianStemFilter(TokenStream _in, IWordBaseFormQuery baseFormQuery)
            : base(_in)
        {
            stemmer = new OpenCorporaRussianStemmer(baseFormQuery);
            termAtt = AddAttribute<ITermAttribute>();
        }

        /**
             * Returns the next token in the stream, or null at EOS
             */

        public override bool IncrementToken()
        {
            if (_terms == null)
            {
                if (!input.IncrementToken())
                {
                    return false;
                }
                string term = termAtt.Term;
                _terms = stemmer.Stem(term).ToArray();
            }
            termAtt.SetTermBuffer(_terms[_pos++]);
            if (_pos == _terms.Length)
            {
                _terms = null;
                _pos = 0;
            }
            return true;
        }
    }
}