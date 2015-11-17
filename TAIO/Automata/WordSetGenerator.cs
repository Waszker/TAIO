using System.Collections.Generic;
using System.Text;

namespace TAIO.Automata
{
    public class WordSetGenerator
    {
        private readonly string[] _testingLetters;
        private readonly string[] _trainingLetters;
        private readonly int _minTestingWordLength;
        public List<string> TestingWords { get; set; }
        public List<string> TrainingWords { get; set; }

        public WordSetGenerator(string[] testingLetters, string[] trainingLetters, int minTestingWordLength)
        {
            _testingLetters = testingLetters;
            _trainingLetters = trainingLetters;
            _minTestingWordLength = minTestingWordLength;
            TrainingWords = new List<string>();
            TestingWords = new List<string>();
        }

        public void GenerateRecusivelyVariationsWithRepeats(StringBuilder builder, int recursionLevel, int maxRecursionLevel)
        {
            if (recursionLevel == maxRecursionLevel) return;
            for (int i = 0; i < _trainingLetters.Length; i++)
            {
                string letter = _trainingLetters[i];
                builder.Append(letter);
                TrainingWords.Add(builder.ToString());
                GenerateRecusivelyVariationsWithRepeats(builder, recursionLevel+1, maxRecursionLevel);
                builder.Remove(builder.Length - 1, 1);
            }
        }

        public void GenerateRecusivelyVariationsWithoutRepeats(StringBuilder builder, int recursionLevel, int maxRecursionLevel, bool[] filled)
        {
            if (recursionLevel == maxRecursionLevel) return;
            for (int i = 0; i < _testingLetters.Length; i++)
            {
                if (!filled[i])
                {
                    string letter = _testingLetters[i];
                    filled[i] = true;
                    builder.Append(letter);
                    if (builder.Length >= _minTestingWordLength)
                    {
                        TestingWords.Add(builder.ToString());
                    }
                    GenerateRecusivelyVariationsWithoutRepeats(builder, recursionLevel + 1, maxRecursionLevel, filled);
                    builder.Remove(builder.Length - 1, 1);
                    filled[i] = false;
                }
            }
        }
    }
}
