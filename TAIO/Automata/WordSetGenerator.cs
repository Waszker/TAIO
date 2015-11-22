using System.Collections.Generic;
using System.Text;

namespace TAIO.Automata
{
    /// <summary>
    /// Generates testing words set and training words set
    /// </summary>
    public class WordSetGenerator
    {
        private readonly string[] _testingLetters;
        private readonly string[] _trainingLetters;
        private readonly int _minTestingWordLength;
        public List<string> TestingWords { get; set; }
        public List<string> TrainingWords { get; set; }

        /// <summary>
        /// Creates instance of <see cref="WordSetGenerator"/>
        /// </summary>
        /// <param name="testingLetters">alphabet used to generate testing words set, no need to care about duplicating letters, already done</param>
        /// <param name="trainingLetters">alphabet used to generate training words set, no need to care about duplicating letters, already done</param>
        /// <param name="minTestingWordLength">min length of testing word, used to avoid repeating words in training and testing words sets</param>
        public WordSetGenerator(string[] testingLetters, string[] trainingLetters, int minTestingWordLength)
        {
            _testingLetters = testingLetters;
            _trainingLetters = trainingLetters;
            _minTestingWordLength = minTestingWordLength;
            TrainingWords = new List<string>();
            TestingWords = new List<string>();
        }

        /// <summary>
        /// Add to TrainingWords generated words with algorithm of variations with repeats
        /// </summary>
        /// <param name="builder">Word waiting to be added to TrainigWords</param>
        /// <param name="recursionLevel">Actual length of word added to TrainigWords</param>
        /// <param name="maxRecursionLevel">Max length of word added to TrainigWords</param>
        public void GenerateTrainingWordsSet(StringBuilder builder, int recursionLevel, int maxRecursionLevel)
        {
            if (recursionLevel == maxRecursionLevel) return;
            for (int i = 0; i < _trainingLetters.Length; i++)
            {
                string letter = _trainingLetters[i];
                builder.Append(letter);
                TrainingWords.Add(builder.ToString());
                GenerateTrainingWordsSet(builder, recursionLevel + 1, maxRecursionLevel);
                builder.Remove(builder.Length - 1, 1);
            }
        }

        /// <summary>
        /// Add to TestingWords generated words with algorithm of variations without repeats
        /// </summary>
        /// <param name="builder">Word waiting to be added to TestingWords</param>
        /// <param name="recursionLevel">Actual length of word added to TestingWords</param>
        /// <param name="maxRecursionLevel">Max length of word added to TestingWords</param>
        /// <param name="filled">Helpful array to avoid repeating letters in generated word</param>
        public void GenerateTestingWordsSet(StringBuilder builder, int recursionLevel, int maxRecursionLevel, bool[] filled)
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
                    GenerateTestingWordsSet(builder, recursionLevel + 1, maxRecursionLevel, filled);
                    builder.Remove(builder.Length - 1, 1);
                    filled[i] = false;
                }
            }
        }
    }
}
