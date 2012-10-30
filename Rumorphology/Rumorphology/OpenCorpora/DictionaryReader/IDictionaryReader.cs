using System.Collections.Generic;

namespace Rumorphology.DictionaryReader
{
    public interface IDictionaryReader
    {
        void ProcessDictionary(string filename, IDictionaryProcessor dictionaryProcessor);
    }
}