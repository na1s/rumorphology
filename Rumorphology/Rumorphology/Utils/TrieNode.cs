using System.Collections.Generic;

namespace Rumorphology.Utils
{
    public class TrieNode
    {
        public HashSet<string> EntityIds { get; set; }
        public Dictionary<char, TrieNode> Children { get; set; }

        public TrieNode(char letter)
        {
            IsWord = false;
            Letter = letter;
            Children = new Dictionary<char, TrieNode>();
            EntityIds = new HashSet<string>();
        }

        public bool IsWord { get; set; }
        public char Letter { get; set; }

        public TrieNode GetChild(char letter)
        {
            if (Children != null)
            {
                if (Children.ContainsKey(letter))
                {
                    return Children[letter];
                }
            }
            return null;
        }
    }
}