namespace Rumorphology.OpenCorpora.DictionaryReader
{
    public interface IDictionaryProcessor
    {
        void ProcessGrammem(Grammem grammem);
        void ProcessLemma(Lemma lemma);
    }
}