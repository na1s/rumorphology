using System.Collections.Generic;

namespace Rumorphology.OpenCorpora
{
    public class Lemma
    {
        public string RevisionNum { get; set; }
        public string Id { get; set; }
        public string Text { get; set; }
        public List<Grammem> Grammems { get; set; }
        public List<LemmaForm> Forms { get; set; }
    }
}