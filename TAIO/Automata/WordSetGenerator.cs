using System.Collections.Generic;
using System.Text;

namespace TAIO.Automata
{
    public class WordSetGenerator
    {
        private readonly string[] _letters;
        public List<string> TestingWords { get; set; }
        public List<string> TrainingWords { get; set; }

        public WordSetGenerator(string[] letters)
        {
            _letters = letters;
            TrainingWords = new List<string>();
            TestingWords = new List<string>();
        }

        public void GenerateRecusivelyVariationsWithRepeats(StringBuilder builder, int recursionLevel, int maxRecursionLevel)
        {
            if (recursionLevel == maxRecursionLevel) return;
            for(int i = 0; i < _letters.Length; i++)
            {
                string letter = _letters[i];
                builder.Append(letter);
                TrainingWords.Add(builder.ToString());
                GenerateRecusivelyVariationsWithRepeats(builder, recursionLevel+1, maxRecursionLevel);
                builder.Remove(builder.Length - 1, 1);
            }
        }

        public void GenerateRecusivelyVariationsWithoutRepeats(StringBuilder builder, int recursionLevel, int maxRecursionLevel)
        {
            if (recursionLevel == maxRecursionLevel) return;
            for (int i = 0; i < _letters.Length; i++)
            {
                string letter = _letters[i];
                if (!builder.ToString().Contains(letter))
                {
                    builder.Append(letter);
                    TestingWords.Add(builder.ToString());
                    GenerateRecusivelyVariationsWithoutRepeats(builder, recursionLevel + 1, maxRecursionLevel);
                    builder.Remove(builder.Length - 1, 1);
                }
            }
        }
    }
}
