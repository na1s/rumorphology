namespace Rumorphology.OpenCorpora.DictionaryReader
{
    public interface IDictionaryReader
    {
        void ProcessDictionary(string filename, IDictionaryProcessor dictionaryProcessor);
    }
}