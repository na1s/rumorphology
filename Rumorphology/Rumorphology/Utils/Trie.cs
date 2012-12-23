namespace Rumorphology.Utils
{
    public class Trie
    {
        public Trie()
        {
            Root = new TrieNode(' ');
        }

        public TrieNode Root { get; set; }

        public void Insert(string id, string word)
        {
            int length = word.Length;
            TrieNode current = Root;

            if (length == 0)
            {
                current.IsWord = true;
            }
            for (int index = 0; index < length; index++)
            {
                char letter = word[index];
                TrieNode child = current.GetChild(letter);

                if (child != null)
                {
                    current = child;
                }
                else
                {
                    current.Children.Add(letter, new TrieNode(letter));
                    current = current.GetChild(letter);
                }
                if (index == length - 1)
                {
                    current.IsWord = true;
                    current.EntityIds.Add(id);
                }
                if (index >= 3)
                {
                    current.EntityIds.Add(id);
                }
            }
        }
    }
}