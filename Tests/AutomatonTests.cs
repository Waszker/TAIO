using Microsoft.VisualStudio.TestTools.UnitTesting;
using TAIO.PSO;
using TAIO.Automata;

namespace Tests
{
    [TestClass]
    public class AutomatonTests
    {
        /// <summary>
        /// Testing constructing automaton
        /// </summary>
        [TestMethod]
        public void AutomatonConstructionFromPositionObjectTest()
        {
            // Arrange
            Position position = new Position(2, 3, 0) { OnePositions = new[,] { { 1, 2, 1 }, { 2, 2, 1 } } };

            // Act
            Automaton automaton = new Automaton(position);

            // Assert
            Assert.AreEqual(automaton.GetFinalState("101"), 2);
        }

        [TestMethod()]
        public void AutomatonTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void AutomatonTest1()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetFinalStateTest()
        {
            string testingWord = "0101";
            string[] alphabetLetters = new string[] { "0", "1" };
            string[][] states = new string[][] { new string[]{ "1", "2"}, new string[]{ "2", "1"}, new string[]{ "2", "2" } };
            Automaton automaton = new Automaton(alphabetLetters, states);
            int finalState = automaton.GetFinalState(testingWord);
            Assert.AreEqual(2, finalState);
        }

        [TestMethod()]
        public void GetGraphTest()
        {
            Assert.Fail();
        }
    }
}
