using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAIO
{
    /// <summary>
    /// Class representing automaton state during computation.
    /// </summary>
    class State
    {
        private bool isAccepting;
        private Dictionary<char, int> controlFunction;

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
