using System.Collections.Generic;

namespace TAIO.Automata
{
    /// <summary>
    /// Class representing automaton state during computation.
    /// </summary>
    class State
    {
        private Dictionary<char, int> _controlFunction;

        /// <summary>
        /// Initializes class with provided information.
        /// </summary>
        /// <param name="controlFunctionArray"></param>
        public State(char[] alphabet, int[] controlFunctionArray)
        {
            _controlFunction = new Dictionary<char, int>();
            for (int i = 0; i < controlFunctionArray.Length; i++)
                _controlFunction.Add(alphabet[i], controlFunctionArray[i]);
        }

        /// <summary>
        /// Returns next state number according to controlFunction associated with this state.
        /// </summary>
        /// <param name="letter"></param>
        /// <returns></returns>
        public int GetNextStateNumber(char letter)
        {
            int nextStateNumber;
            _controlFunction.TryGetValue(letter, out nextStateNumber);
            return nextStateNumber;
        }
    }
}
