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
            char[] letters = { 'A', 'B', 'C' };
            WordSetGenerator wordSetGenerator = new WordSetGenerator(letters);
            int maxLength = 3;
            wordSetGenerator.GenerateRecusivelyWords(new System.Text.StringBuilder(), 0, maxLength);
            var words = wordSetGenerator.Words;
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
    }
}
