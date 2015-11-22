using Microsoft.VisualStudio.TestTools.UnitTesting;
using TAIO.Automata;

namespace Tests
{
    [TestClass]
    public class WordSetGeneratorTest
    {
        [TestMethod]
        public void GenerateVariationsTest()
        {
            string[] letters = { "A", "B", "C" };
            WordSetGenerator wordSetGenerator = new WordSetGenerator(letters, letters, 0);
            int maxLength = 3;
            wordSetGenerator.GenerateTrainingWordsSet(new System.Text.StringBuilder(), 0, maxLength);
            var words = wordSetGenerator.TrainingWords;
            int expectedAmount = 0;
            int amountOfLetters = letters.Length;
            int temp = 1;
            for (int i = 0; i < maxLength; i++)
            {
                temp *= amountOfLetters;
                expectedAmount += temp;
            }
            Assert.AreEqual(expectedAmount, words.Count);
        }

        [TestMethod]
        public void GenerateVariationsWithoutRepetTest()
        {
            string[] letters = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J" };
            WordSetGenerator wordSetGenerator = new WordSetGenerator(letters, letters, 1);
            int maxLength = 10;
            wordSetGenerator.GenerateTestingWordsSet(new System.Text.StringBuilder(), 0, maxLength, new bool[letters.Length]);
            var words = wordSetGenerator.TestingWords;
            int expected = 0;
            int amountOfLetters = letters.Length;
            int temp = 1;
            for (int j = 1; j <= maxLength; j++)
            {
                temp = 1;
                for (int i = amountOfLetters; i >= amountOfLetters - j + 1; i--)
                {
                    temp *= i;
                }
                expected += temp;
            }
            Assert.AreEqual(expected, words.Count);
        }
    }
}
