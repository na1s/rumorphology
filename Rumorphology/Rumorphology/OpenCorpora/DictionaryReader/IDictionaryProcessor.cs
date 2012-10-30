using Rumorphology.OpenCorpora;

namespace Rumorphology.DictionaryReader
{
    public interface IDictionaryProcessor
    {
        void ProcessGrammem(Grammem grammem);
        void ProcessLemma(Lemma lemma);
    }
}