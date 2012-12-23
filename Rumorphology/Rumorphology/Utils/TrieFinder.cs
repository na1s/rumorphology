using System;
using System.Collections.Generic;
using System.Linq;

namespace Rumorphology.Utils
{
    public class Finder
    {
        public Trie TheTrie { get; set; }

        public Finder()
        {
            TheTrie = new Trie();
        }

        public List<string> GetSimularNames(string word, int treshold)
        {
            word = " " + word.ToLower();
            int iWordLength = word.Length;
            var currentRow = new int[iWordLength + 1];

            for (int i = 0; i <= iWordLength; i++)
            {
                currentRow[i] = i;
            }
            var result = new SearchResult(treshold);
            for (int i = 0; i < iWordLength; i++)
            {
                TraverseTrie(TheTrie.Root, word[i], word, currentRow, result);
            }
            return result.EntityIds.ToList();
        }

        private void TraverseTrie(TrieNode node, char letter, string word, int[] previousRow, SearchResult result)
        {
            int size = previousRow.Length;
            var currentRow = new int[size];
            currentRow[0] = previousRow[0] + 1;

            int minimumElement = currentRow[0];

            for (int i = 1; i < size; i++)
            {
                int insertCost = currentRow[i - 1] + 1;
                int deleteCost = previousRow[i] + 1;

                int replaceCost;
                if (word[i - 1] == letter)
                {
                    replaceCost = previousRow[i - 1];
                }
                else
                {
                    replaceCost = previousRow[i - 1] + 1;
                }

                currentRow[i] = Minimum(insertCost, deleteCost, replaceCost);

                if (currentRow[i] < minimumElement)
                {
                    minimumElement = currentRow[i];
                }
            }
            if (result.IsTreshold)
            {
                if (currentRow[size - 1] <= result.Treshold)
                {
                    foreach (var entityId in node.EntityIds)
                    {
                        result.EntityIds.Add(entityId);
                    }
                }
            }

            if (result.IsTreshold)
            {
                if (minimumElement <= result.Treshold)
                {
                    foreach (var c in node.Children.Keys)
                    {
                        TraverseTrie(node.Children[c], c, word, currentRow, result);
                    }
                }
            }

        }


        private static int Minimum(int insertCost, int deleteCost, int replaceCost)
        {
            var m = new[] { insertCost, deleteCost, replaceCost };
            return m.OrderBy(t => t).First();
        }

        public void InsertObject(string id, string word)
        {
            word = word.ToLower();
            string[] strings = word.Split();
            foreach (var s in strings)
            {
                TheTrie.Insert(id, s);

            }

        }

        #region Nested type: SearchResult

        public class SearchResult
        {
            public SearchResult(int treshold)
            {
                Treshold = treshold;
                IsTreshold = true;
                MinDistance = Int32.MaxValue;
                EntityIds = new HashSet<string>();
            }

            public bool IsTreshold { get; set; }

            public int MinDistance { get; set; }
            public HashSet<string> EntityIds { get; set; }
            public int Treshold { get; set; }
        }

        #endregion
    }
}