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
            Assert.Fail();
        }

        [TestMethod()]
        public void GetGraphTest()
        {
            Assert.Fail();
        }
    }
}
