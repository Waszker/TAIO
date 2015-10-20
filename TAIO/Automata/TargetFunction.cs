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

        public TargetFunction(Automaton automaton)
        {
            _secretAutomaton = automaton;
        }
        
        public static int GetFunctionValue(Position position)
        {
            // TODO: 
            // 1) Generate Automaton
            // 2) Foreach word -> check if compatible
            // 3) Return number of errors
            return 0;
        }
    }
}
