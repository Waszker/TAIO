using System.Collections.Generic;
using System.Linq;
using System.Net;
using TAIO.PSO;

namespace TAIO.Automata
{
    /// <summary>
    /// This class represents the target function object and used to count error number for given automan. 
    /// </summary>
    class TargetFunction
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
            TargetFunction._trainingSet = trainingSet;
            TargetFunction._testSet = testSet;
        }

        /// <summary>
        /// This function creates automaton instance from given position and counts number of errors. 
        /// </summary>
        public static int GetFunctionValue(Position position)
        {
            Automaton foundAutomaton = new Automaton(position);
            return _trainingSet.Count(word => _secretAutomaton.GetFinalState(word) != foundAutomaton.GetFinalState(word));
        }

        /// <summary>
        /// This function counts number of errors for given automaton instance.
        /// </summary>
        public static int GetFunctionValueForAutomaton(Automaton automaton)
        {
            return _testSet.Count(word => _secretAutomaton.GetFinalState(word) != automaton.GetFinalState(word));
        }
    }
}