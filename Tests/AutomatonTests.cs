using Microsoft.VisualStudio.TestTools.UnitTesting;
using TAIO.PSO;
using TAIO.Automata;
using System.IO;
using QuickGraph;

namespace Tests
{
    /// <summary>
    /// Class testing automaton construction and automaton methodes
    /// </summary>
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

        /// <summary>
        /// Test receiving final state for input word
        /// </summary>
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

        /// <summary>
        /// Test generating graph for automaton
        /// </summary>
        [TestMethod()]
        public void GetGraphTest()
        {
            string testingWord = "01212";
            string autonatonName = "testowyAutomat";
            string[] alphabetLetters = new string[] { "0", "1", "2" };
            string[][] states = new string[][] { new string[] { "1", "0", "0" }, new string[] { "1", "1", "2" }, new string[] { "2", "2", "3" }, new string[] { "3", "3", "3"} };
            Automaton automaton = new Automaton(alphabetLetters, states);
            int finalState = automaton.GetFinalState(testingWord);
            Assert.AreEqual(3, finalState);
            File.Create(autonatonName).Close();
            AdjacencyGraph<int, TaggedEdge<int, string>> graph;
            automaton.GetGraph(autonatonName, out graph);
            File.Delete(autonatonName);
        }
    }
}
