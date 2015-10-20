using System;
using System.Collections.Generic;
using System.Linq;

namespace TAIO.Automata
{
    public class WordSetGenerator
    {
        private char[] _letters;
        private List<String> _words; 

        public WordSetGenerator(char[] letters)
        {
            _letters = letters;
            _words = new List<string>();
        }

        public void GenerateWords(int maxLength)
        {
            _words = _letters.Select(letter => letter.ToString()).ToList();
            var produceWithRecursion = ProduceWithRecursion(_words);
            foreach (var word in produceWithRecursion)
            {
                Console.WriteLine(word);
            }
        }

        private void GenerateWordsSpecifiedLength(int length)
        {
            
        }

        private IEnumerable<List<String>> ProduceWithRecursion(List<String> allValues)
        {
            for (var i = 0; i < (1 << allValues.Count); i++)
            {
                yield return ConstructSetFromBits(i).Select(n => allValues[n]).ToList();
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
