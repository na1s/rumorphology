using System.Collections.Generic;

namespace Rumorphology.OpenCorpora.DictionaryProcessor
{
    public interface IWordBaseFormQuery
    {
        List<Lemma> GetLemmas(string word);
    }
}