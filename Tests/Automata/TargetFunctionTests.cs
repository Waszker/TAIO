using Microsoft.VisualStudio.TestTools.UnitTesting;
using TAIO.Automata;
using System.Collections.Generic;
using TAIO.PSO;

namespace Tests
{
    /// <summary>
    /// Tests for TargetFunction static methods.
    /// </summary>
    [TestClass()]
    public class TargetFunctionTests
    {
        /// <summary>
        /// Check if two identical automatons show no errors.
        /// </summary>
        [TestMethod()]
        public void GetFunctionValueTest()
        {
            Position particlePosition = new Position(3, 4, 89) { OnePositions = new[,] { { 0, 1, 2, 3 }, { 2, 1, 0, 2 }, { 1, 1, 3, 3 } } };
            List<string> wordsSet = new List<string>();
            wordsSet.Add("012");
            TargetFunction f = new TargetFunction(new Automaton(particlePosition), wordsSet, wordsSet);
            Assert.AreEqual(TargetFunction.GetFunctionValue(particlePosition), 0);
        }

        /// <summary>
        /// Check number of errors for two different automatons.
        /// </summary>
        [TestMethod()]
        public void GetFunctionValueTest2()
        {
            Position automatonPosition = new Position(3, 4, 89) { OnePositions = new[,] { { 0, 1, 2, 3 }, { 2, 1, 0, 2 }, { 1, 1, 3, 3 } } };
            Position particlePosition = new Position(3, 4, 89) { OnePositions = new[,] { { 1, 1, 2, 2 }, { 1, 0, 0, 0 }, { 3, 2, 0, 0 } } };
            List<string> wordsSet = new List<string>();
            wordsSet.Add("012");
            wordsSet.Add("0");
            wordsSet.Add("1");
            wordsSet.Add("2");
            TargetFunction f = new TargetFunction(new Automaton(automatonPosition), wordsSet, wordsSet);
            Assert.AreEqual(TargetFunction.GetFunctionValue(particlePosition), 3);
        }

        /// <summary>
        /// Tests method for automaton error counting.
        /// </summary>
        [TestMethod()]
        public void GetFunctionValueForAutomatonTest()
        {
            Position particlePosition = new Position(3, 4, 89) { OnePositions = new[,] { { 0, 1, 2, 3 }, { 2, 1, 0, 2 }, { 1, 1, 3, 3 } } };
            List<string> wordsSet = new List<string>();
            wordsSet.Add("012");
            TargetFunction f = new TargetFunction(new Automaton(particlePosition), wordsSet, wordsSet);
            Assert.AreEqual(TargetFunction.GetFunctionValueForAutomaton(new Automaton(particlePosition)), 0);
        }

        /// <summary>
        /// Checks if TargetFunction returns good number of words in test set.
        /// </summary>
        [TestMethod()]
        public void GetTestSetCountTest()
        {
            Position particlePosition = new Position(3, 4, 89) { OnePositions = new[,] { { 0, 1, 2, 3 }, { 2, 1, 0, 2 }, { 1, 1, 3, 3 } } };
            List<string> wordsSet = new List<string>();
            wordsSet.Add("012");
            TargetFunction f = new TargetFunction(new Automaton(particlePosition), wordsSet, wordsSet);
            Assert.AreEqual(TargetFunction.GetTestSetCount(), 1);
        }
        
        /// <summary>
        /// Test checks initialized TargetFunction.
        /// </summary>
        [TestMethod()]
        public void IsInitializedTest()
        {
            Position automatonPosition = new Position(3, 4, 89) { OnePositions = new[,] { { 0, 1, 2, 3 }, { 2, 1, 0, 2 }, { 1, 1, 3, 3 } } };
            TargetFunction f = new TargetFunction(new Automaton(automatonPosition), new List<string>(), new List<string>());
            Assert.AreEqual(TargetFunction.IsInitialized(), true);
        }
    }
}