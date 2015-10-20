using System;
using NUnit.Framework;
using TAIO.Automata;

namespace TAIOTest
{
    public class WordSetGeneratorTest
    {
        [Test]
        public void GenerateVariationsTest()
        {
            //TODO generate variations with repeats
            char[] letters = {'A', 'B', 'C'};
            WordSetGenerator wordSetGenerator = new WordSetGenerator(letters);
            wordSetGenerator.GenerateWords(3);
            var words = wordSetGenerator.Words;
            foreach (var word in words)
            {
                Console.WriteLine(word);
            }
        }
    }
}

