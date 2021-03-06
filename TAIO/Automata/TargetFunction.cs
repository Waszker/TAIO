﻿using System.Collections.Generic;
using System.Linq;
using System.Net;
using TAIO.PSO;

namespace TAIO.Automata
{
    /// <summary>
    /// This class represents the target function object and used to count error number for given automan. 
    /// </summary>
    public class TargetFunction
    {
        private static Automaton _secretAutomaton;
        private static List<string> _trainingSet;
        private static List<string> _testSet;

        /// <summary>
        /// Initialize new instance of TargetFunction class.
        /// </summary>
        public TargetFunction(Automaton automaton, List<string> trainingSet, List<string> testSet) 
        {
            _secretAutomaton = automaton;
            _trainingSet = trainingSet;
            _testSet = testSet;
        }

        /// <summary>
        /// This function creates automaton instance from given position and counts number of errors. 
        /// </summary>
        public static int GetFunctionValue(Position position)
        {
            Automaton foundAutomaton = new Automaton(position);
            int count = 0;
            foreach (string word in _trainingSet)
            {
                if (_secretAutomaton.GetFinalState(word) != foundAutomaton.GetFinalState(word))
                    count++;
            }
            return count;
        }

        /// <summary>
        /// This function counts number of errors for given automaton instance.
        /// </summary>
        public static int GetFunctionValueForAutomaton(Automaton automaton)
        {
            return _testSet.Count(word => _secretAutomaton.GetFinalState(word) != automaton.GetFinalState(word));
        }

        /// <summary>
        /// Returns number of words in test set.
        /// </summary>
        /// <returns></returns>
        public static int GetTestSetCount()
        {
            return _testSet.Count();
        }

        /// <summary>
        /// Returns number of words in training set.
        /// </summary>
        /// <returns></returns>
        public static int GetTrainingSetCount()
        {
            return _trainingSet.Count();
        }

        /// <summary>
        /// Returns information if target function has been already initialized.
        /// </summary>
        /// <returns></returns>
        public static bool IsInitialized()
        {
            return _secretAutomaton != null;
        }
    }
}