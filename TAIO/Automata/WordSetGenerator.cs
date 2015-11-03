using System.Collections.Generic;
using System.Text;

namespace TAIO.Automata
{
    public class WordSetGenerator
    {
        private readonly char[] _letters;
        public List<string> Words { get; set; }

        public WordSetGenerator(char[] letters)
        {
            _letters = letters;
            Words = new List<string>();
        }

        public void GenerateWords(int maxLength)
        {
            StringBuilder stringBuilder = new StringBuilder();
            GenerateRecusivelyVariationsWithRepeats(stringBuilder, 0, 4);
        }

        public void GenerateRecusivelyVariationsWithRepeats(StringBuilder builder, int recursionLevel, int maxRecursionLevel)
        {
            if (recursionLevel == maxRecursionLevel) return;
            for(int i = 0; i < _letters.Length; i++)
            {
                char letter = _letters[i];
                builder.Append(letter);
                Words.Add(builder.ToString());
                GenerateRecusivelyVariationsWithRepeats(builder, recursionLevel+1, maxRecursionLevel);
                builder.Remove(builder.Length - 1, 1);
            }
        }

        public void GenerateRecusivelyVariationsWithoutRepeats(StringBuilder builder, int recursionLevel, int maxRecursionLevel)
        {
            if (recursionLevel == maxRecursionLevel) return;
            for (int i = 0; i < _letters.Length; i++)
            {
                char letter = _letters[i];
                if (!builder.ToString().Contains(letter + ""))
                {
                    builder.Append(letter);
                    Words.Add(builder.ToString());
                    GenerateRecusivelyVariationsWithoutRepeats(builder, recursionLevel + 1, maxRecursionLevel);
                    builder.Remove(builder.Length - 1, 1);
                }
            }
        }
    }
}
