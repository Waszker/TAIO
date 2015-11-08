using System.Collections.Generic;
using System.Linq;
using QuickGraph;
using QuickGraph.Graphviz;
using QuickGraph.Graphviz.Dot;
using System.IO;
using TAIO.PSO;

namespace TAIO.Automata
{
    /// <summary>
    /// Class representing finite, deterministic automaton.
    /// </summary>
    public class Automaton
    {
        //TODO: Automaton class needs to be changed

        private readonly List<State> _states;
        private readonly int alphabetLen;

        #region Constructors

        /// <summary>
        /// Takes alphabet letters as string array convertible to char array and function table for each state.
        /// </summary>
        /// <param name="alphabetLetters"></param>
        /// <param name="functionTables"></param>
        public Automaton(string[] alphabetLetters, string[][] functionTables)
        {
            _states = CreateAutomaton(alphabetLetters, functionTables);
            alphabetLen = alphabetLetters.Length;
        }

        /// <summary>
        /// Takes Position object as parameter and creates instance of Automaton class
        /// </summary>
        /// <param name="bestPositionSoFar"></param>
        public Automaton(Position bestPositionSoFar)
        {
            int alphabetLength = bestPositionSoFar.OnePositions.GetLength(0);
            int numberOfStates = bestPositionSoFar.OnePositions.GetLength(1);
            alphabetLen = alphabetLength;

            string[][] functionsTable = new string[numberOfStates][];

            #region Temp Structure

            List<string>[] functions = new List<string>[numberOfStates];

            for (int i = 0; i < numberOfStates; i++)
                functions[i] = new List<string>();

            #endregion

            for (int i = 0; i < bestPositionSoFar.OnePositions.GetLength(1); i++)
                for (int j = 0; j < bestPositionSoFar.OnePositions.GetLength(0); j++)
                    functions[i].Add(bestPositionSoFar.OnePositions[j, i].ToString());

            for (int i = 0; i < numberOfStates; i++)
                functionsTable[i] = functions[i].ToArray();

            _states = CreateAutomaton(Utils.EnumerateAlphabetSymbols(alphabetLength), functionsTable);
        }

        private List<State> CreateAutomaton(string[] alphabetLetters, string[][] functionTables)
        {
            List<State> states = new List<State>();
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

            return states;
        }

        #endregion

        /// <summary>
        /// Returns number of active state after computations.
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public int GetFinalState(string word)
        {
            State currentState = _states[0];
            for (int i = 0; i < word.Length; i++)
                currentState = _states.ElementAt(currentState.GetNextStateNumber(word[i]));
            return _states.IndexOf(currentState);
        }

        public sealed class FileDotEngine : IDotEngine
        {
            public string Run(GraphvizImageType imageType, string dot, string outputFileName)
            {
                string output = outputFileName;
                File.WriteAllText(output, dot);
                var args = string.Format(@"{0} -Tjpg -O", output);
                System.Diagnostics.Process.Start("TAIO_Execs\\dot.exe", args);
                return output;
            }
        }


        public string GetGraph(string automatonName)
        {
            string[,] matrix = new string[_states.Count, _states.Count];
            for (int i = 0; i < _states.Count; i++)
                for (int j = 0; j < _states.Count; j++)
                    matrix[i, j] = "";

            for (int i = 0; i < _states.Count; i++)
            {
                for (int j = 0; j < alphabetLen; j++)
                {
                    matrix[i, _states.ElementAt(i).GetNextStateNumber(System.Convert.ToChar(j + 48))] += (","+j.ToString());
                }
            }

            for (int i = 0; i < _states.Count; i++)
                for (int j = 0; j < _states.Count; j++)
                    if(matrix[i, j]!="")
                        matrix[i, j]=matrix[i,j].Substring(1);


            AdjacencyGraph<int, TaggedEdge<int, string>> g = new AdjacencyGraph<int, TaggedEdge<int, string>>(true);
            for (int i = 0; i < _states.Count; i++)
                g.AddVertex(i);
            

            for (int i = 0; i < _states.Count; i++)
                for (int j = 0; j < _states.Count; j++)
                {
                    if (matrix[i, j] != "")
                        g.AddEdge(new TaggedEdge<int, string>(i, j, matrix[i,j]));
                }

            GraphvizAlgorithm<int, TaggedEdge<int, string>> graphviz = new GraphvizAlgorithm<int, TaggedEdge<int, string>>(g);
            graphviz.ImageType = GraphvizImageType.Png;
            graphviz.FormatEdge += (sender, args) => { args.EdgeFormatter.Label.Value = args.Edge.Tag.ToString(); };
            string output = graphviz.Generate(new FileDotEngine(), automatonName);
            return output;
        }
    }
}
