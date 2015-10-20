﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace TAIO.Automata
{
    /// <summary>
    /// Class representing finite, deterministic automaton.
    /// </summary>
    class Automaton
    {
        private List<State> states;

        /// <summary>
        /// Takes alphabet letters as string array convertible to char array and function table for each state.
        /// </summary>
        /// <param name="alphabetLetters"></param>
        /// <param name="functionTables"></param>
        public Automaton(string[] alphabetLetters, string[][] functionTables)
        {
            states = new List<State>();
            char[] alphabet = new char[alphabetLetters.Length];

            // Converting string alphabet to char array
            for (int j = 0; j < alphabetLetters.Length; j++)
                char.TryParse(alphabetLetters[j], out alphabet[j]);

            // Parse each state provided in functionTable
            foreach (string[] function in functionTables)
            {
                int[] stateFunction = new int[function.Length];
                // Converting string function to integer array for State constructor
                for (int j = 0; j < function.Length; j++)
                    int.TryParse(function[j], out stateFunction[j]);

                states.Add(new State(alphabet, stateFunction));
            }
        }

        /// <summary>
        /// Returns number of active state after computations.
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public int GetFinalState(String word)
        {
            State currentState = states[0];
            for (int i = 0; i < word.Length; i++)
                currentState = states.ElementAt(currentState.GetNextStateNumber(word[i]));
            return states.IndexOf(currentState);
        }
    }
}