using System.Collections.Generic;
using System.Xml;

namespace Rumorphology.DictionaryReader
{
    public class DictionaryReader : IDictionaryReader
    {
        private Dictionary<string, HashSet<string>> _convertions;

        public DictionaryReader()
        {
            _convertions = new Dictionary<string, HashSet<string>>();
        }
        public void LoadDictionary(string filename)
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
                            currentLemma.Forms.Add(reader.GetAttribute("t"));
                        }
                    }
                        // EndElement was found, check if it is named item, if it is, store the object in the list and set openItem to false.
                    else if (reader.NodeType == XmlNodeType.EndElement && reader.Name == "lemma" && openItem)
                    {
                        openItem = false;
                        if (!_convertions.ContainsKey(currentLemma.Text))
                        {
                            _convertions[currentLemma.Text] = new HashSet<string>();
                        }
                        _convertions[currentLemma.Text].Add(currentLemma.Text);
                        foreach (var form in currentLemma.Forms)
                        {
                            if (!_convertions.ContainsKey(form))
                            {
                                _convertions[form] = new HashSet<string>();
                            }
                            _convertions[form].Add(currentLemma.Text);
                        }
                        
                    }
                }
            }

        }
    }
}