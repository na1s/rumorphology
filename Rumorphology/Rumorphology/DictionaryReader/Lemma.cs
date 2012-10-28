using System.Collections.Generic;

namespace Rumorphology.DictionaryReader
{
    public class Lemma
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public List<string> Forms { get; set; }

        public Lemma()
        {
            Forms = new List<string>();
        }
    }
}