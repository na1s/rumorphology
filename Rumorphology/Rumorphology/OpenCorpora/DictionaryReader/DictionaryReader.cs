using System.Collections.Generic;
using System.Xml;
using Rumorphology.OpenCorpora;

namespace Rumorphology.DictionaryReader
{
    public class DictionaryReader : IDictionaryReader
    {

        public void ProcessDictionary(string filename, IDictionaryProcessor dictionaryProcessor)
        {
            using (XmlReader reader = new XmlTextReader(filename))
            {
                bool openItem = true;
                Lemma currentLemma = null;
                // Loop the reader, till it cant read anymore
                while (reader.Read())
                {
                    // An object with the type Element was found.
                    if (reader.NodeType == XmlNodeType.Element)
                    {
                        // Check name of the node and write the contents in the object accordingly.
                        if (reader.Name == "lemma")
                        {
                            currentLemma = new Lemma();
                            openItem = true;
                        }
                        if (reader.NodeType == XmlNodeType.Element && reader.Name == "l" && openItem)
                        {
                            currentLemma.Text = reader.GetAttribute("t");
                        }
                        if (reader.NodeType == XmlNodeType.Element && reader.Name == "f" && openItem)
                        {
                            currentLemma.Forms.Add(new LemmaForm(reader.GetAttribute("t"),new List<Grammem>()));
                        }
                    }
                    // EndElement was found, check if it is named item, if it is, store the object in the list and set openItem to false.
                    else if (reader.NodeType == XmlNodeType.EndElement && reader.Name == "lemma" && openItem)
                    {
                        openItem = false;
                        dictionaryProcessor.ProcessLemma(currentLemma);

                    }
                }
            }
        }
    }
}