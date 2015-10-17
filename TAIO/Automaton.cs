using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAIO
{
    /// <summary>
    /// Class representing finite, deterministic automaton.
    /// </summary>
    class Automaton
    {
        private List<State> states;

        /// <summary>
        /// Returns number of active state after computations.
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public int GetFinalState(String word)
        {
            State currentState = states[0];
            for (int i = 0; i < states.Count; i++)
                currentState = states.ElementAt(currentState.GetNextStateNumber(word[i]));
            return states.IndexOf(currentState);
        }
    }
}
