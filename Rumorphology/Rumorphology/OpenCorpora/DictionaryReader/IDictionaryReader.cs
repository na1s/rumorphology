using System.Collections.Generic;
using Rumorphology.OpenCorpora.DictionaryProcessor;

namespace Rumorphology.OpenCorpora.DictionaryReader
{
    public interface IDictionaryReader
    {
        void ProcessDictionary(string filename, IEnumerable<IDictionaryProcessor> dictionaryProcessors);
    }
}