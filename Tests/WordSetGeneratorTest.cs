﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            wordSetGenerator.GenerateRecusivelyVariationsWithRepeats(new System.Text.StringBuilder(), 0, maxLength);
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

        [TestMethod]
        public void GenerateVariationsWithoutRepetTest()
        {
            char[] letters = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J' };
            WordSetGenerator wordSetGenerator = new WordSetGenerator(letters);
            int maxLength = 10;
            wordSetGenerator.GenerateRecusivelyVariationsWithoutRepeats(new System.Text.StringBuilder(), 0, maxLength);
            var words = wordSetGenerator.Words;
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
