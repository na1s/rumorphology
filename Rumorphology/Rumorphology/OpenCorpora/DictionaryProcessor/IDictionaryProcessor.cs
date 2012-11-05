namespace Rumorphology.OpenCorpora.DictionaryProcessor
{
    public interface IDictionaryProcessor
    {
        void ProcessGrammem(Grammem grammem);
        void ProcessLemma(Lemma lemma);
    }
}