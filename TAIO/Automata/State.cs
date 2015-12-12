using System.Collections.Generic;

namespace TAIO.Automata
{
    /// <summary>
    /// Class representing automaton state during computation.
    /// </summary>
    public class State
    {
        private readonly Dictionary<char, int> _controlFunction;

        /// <summary>
        /// Initializes new instance of State class.
        /// </summary>
        public State(char[] alphabet, int[] controlFunctionArray)
        {
            _controlFunction = new Dictionary<char, int>();
            for (int i = 0; i < controlFunctionArray.Length; i++)
                _controlFunction.Add(alphabet[i], controlFunctionArray[i]);
        }

        /// <summary>
        /// Returns next state number according to controlFunction.
        /// </summary>
        public int GetNextStateNumber(char letter)
        {
            int nextStateNumber;
            _controlFunction.TryGetValue(letter, out nextStateNumber);
            return nextStateNumber;
        }
    }
}
