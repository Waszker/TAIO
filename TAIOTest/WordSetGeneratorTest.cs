using NUnit.Framework;
using TAIO;
using TAIO.Automata;

namespace TAIOTest
{
    public class WordSetGeneratorTest
    {
        [Test]
        public void GenerateVariationsTest()
        {
            char[] letters = {'A', 'B', 'C'};
            WordSetGenerator wordSetGenerator = new WordSetGenerator(letters);
            wordSetGenerator.GenerateWords(10);

        }
    }
}

