using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automata
{
    /// <summary>
    /// Class representing automaton state during computation.
    /// </summary>
    class State
    {
        private bool isAccepting;
        private Dictionary<char, int> controlFunction;

        /// <summary>
        /// Initializes class with provided information.
        /// </summary>
        /// <param name="isAccepting"></param>
        /// <param name="controlFunctionArray"></param>
        public State(bool isAccepting, char[] alphabet, int[] controlFunctionArray)
        {
            this.isAccepting = isAccepting;
            controlFunction = new Dictionary<char, int>();

            for (int i = 0; i < controlFunctionArray.Length; i++)
                controlFunction.Add(alphabet[i], controlFunctionArray[i]);
        }

        /// <summary>
        /// Returns next state number according to controlFunction associated with this state.
        /// </summary>
        /// <param name="letter"></param>
        /// <returns></returns>
        public int GetNextStateNumber(char letter)
        {
            int nextStateNumber;
            controlFunction.TryGetValue(letter, out nextStateNumber);
            return nextStateNumber;
        }
    }
}
