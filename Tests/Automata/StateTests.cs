using Microsoft.VisualStudio.TestTools.UnitTesting;
using TAIO.Automata;

namespace Tests
{
    /// <summary>
    /// Class testing States of automaton
    /// </summary>
    [TestClass()]
    public class StateTests
    {
        /// <summary>
        /// Test finding next state during analizing word
        /// </summary>
        [TestMethod()]
        public void GetNextStateNumberTest()
        {
            char[] alphabet = new char[] { '0', '1', '2' };
            int[] controlFunction = new int[] { 2, 1, 11 };
            State state = new State(alphabet, controlFunction);
            Assert.AreEqual(state.GetNextStateNumber('2'), 11);
        }
    }
}