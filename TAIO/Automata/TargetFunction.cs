using System.Collections.Generic;
using System.Linq;
using TAIO.PSO;

namespace TAIO.Automata
{
    /// <summary>
    /// This class represents the target function object and used to count error number for given automan. 
    /// </summary>
    class TargetFunction
    {
        private static Automaton secretAutomaton;
        private static List<string> trainingSet;
        private static List<string> testSet;

        /// <summary>
        /// Initialize a new instance of the TargetFunction class.
        /// </summary>
        public TargetFunction(Automaton automaton, List<string> trainingSet, List<string> testSet) 
        {
            secretAutomaton = automaton;
            TargetFunction.trainingSet = trainingSet;
            TargetFunction.testSet = testSet;
        }
        
        /// <summary>
        /// This function creates automaton object from given position and counts number of errors. 
        /// </summary>
        public static int GetFunctionValue(Position position)
        {
            Automaton foundAutomaton = new Automaton(position);
            return trainingSet.Count(word => secretAutomaton.GetFinalState(word) != foundAutomaton.GetFinalState(word));
        }

        /// <summary>
        /// This function counts number of errors for given automaton object.
        /// </summary>
        public static int GetFunctionValueForAutomaton(Automaton automaton)
        {
            return testSet.Count(word => secretAutomaton.GetFinalState(word) != automaton.GetFinalState(word));
        }
    }
}