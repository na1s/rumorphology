using System.Collections.Generic;

namespace Rumorphology.OpenCorpora.DictionaryProcessor
{
    public class InMemoryWordsDictionary : IDictionaryProcessor, IWordBaseFormQuery
    {
        private readonly Dictionary<string, List<Lemma>> _lemmas = new Dictionary<string, List<Lemma>>();

        #region IDictionaryProcessor Members

        public void ProcessGrammem(Grammem grammem)
        {
        }

        public void ProcessLemma(Lemma lemma)
        {
            AddWordToDictionary(lemma, lemma.Text);
            foreach (LemmaForm form in lemma.Forms)
            {
                AddWordToDictionary(lemma, form.Text);
            }
        }

        #endregion

        #region IWordBaseFormQuery Members

        public List<Lemma> GetLemmas(string word)
        {
            if (_lemmas.ContainsKey(word))
            {
                return _lemmas[word];
            }
            return new List<Lemma>();
        }

        #endregion

        private void AddWordToDictionary(Lemma lemma, string word)
        {
            if (_lemmas.ContainsKey(word))
            {
                _lemmas[word] = new List<Lemma>();
            }
            _lemmas[word].Add(lemma);
        }
    }
}