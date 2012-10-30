using System.Collections.Generic;

namespace Rumorphology.OpenCorpora
{
    public class LemmaForm
    {
        public LemmaForm(string text, List<Grammem> grammems)
        {
            Text = text;
            Grammems = grammems;
        }

        public string Text { get; set; }
        public List<Grammem> Grammems { get; set; }
    }
}