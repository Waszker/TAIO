using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAIO.PSO;

namespace TAIO.Automata
{
    class TargetFunction
    {
        private static Automaton _secretAutomaton;
        private static List<string> _trainingSet;
        private static List<string> _testSet;

        public TargetFunction(Automaton automaton, List<string> trainingSet, List<string> testSet) 
        {
            _secretAutomaton = automaton;
            _trainingSet = trainingSet;
            _testSet = testSet;
        }
        
        public static int GetFunctionValue(Position position)
        {
            int errorNumber = 0;
            Automaton foundAutomaton = new Automaton(position);

            foreach (string word in _trainingSet)
                if (_secretAutomaton.GetFinalState(word) != foundAutomaton.GetFinalState(word))
                    errorNumber++;

            return errorNumber;
        }

        public static int GetFunctionValueForAutomaton(Automaton automaton)
        {
            int errorNumber = 0;

            foreach (string word in _testSet)
                if (_secretAutomaton.GetFinalState(word) != automaton.GetFinalState(word))
                    errorNumber++;

            return errorNumber;
        }
    }
}
