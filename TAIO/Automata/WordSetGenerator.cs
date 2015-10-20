using System;
using System.Collections.Generic;
using System.Linq;

namespace TAIO.Automata
{
    public class WordSetGenerator
    {
        private readonly char[] _letters;
        public List<String> Words { get; private set; }

        public WordSetGenerator(char[] letters)
        {
            _letters = letters;
            Words = new List<string>();
        }

        public void GenerateWords(int maxLength)
        {
            List<String> alphabet = new List<string>();
            alphabet.AddRange(_letters.Select(letter => letter.ToString()).ToList());
            foreach (string word in ProduceWithRecursion(alphabet))
            {
                Words.Add(word);
            }
        }

        private IEnumerable<string> ProduceWithRecursion(List<string> allValues)
        {
            for (var i = 0; i < (1 << allValues.Count); i++)
            {
                var list = ConstructSetFromBits(i).Select(n => allValues[n]).ToList();
                var word = "";
                foreach (var letter in list)
                {
                    word = word + letter;
                }
                yield return word;
            }
        }

        private IEnumerable<int> ConstructSetFromBits(int i)
        {
            var n = 0;
            for (; i != 0; i /= 2)
            {
                if ((i & 1) != 0) yield return n;
                n++;
            }
        }
    }
}
