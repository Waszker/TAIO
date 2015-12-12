using System.Collections.Generic;
using System.Linq;
using QuickGraph;
using QuickGraph.Graphviz;
using QuickGraph.Graphviz.Dot;
using TAIO.PSO;

namespace TAIO.Automata
{
    /// <summary>
    /// Class representing finite, deterministic automaton.
    /// </summary>
    public class Automaton
    {
        public List<State> States { get; private set;}
        private readonly int _alphabetLength;

        #region Constructors

        /// <summary>
        /// Initializes new instance of Automaton class.
        /// </summary>
        public Automaton(string[] alphabetLetters, string[][] functionTables)
        {
            States = CreateAutomaton(alphabetLetters, functionTables);
            _alphabetLength = alphabetLetters.Length;
        }

        /// <summary>
        /// Initializes new instance of Automaton class.
        /// </summary>
        public Automaton(Position bestPositionSoFar)
        {
            int alphabetLength = bestPositionSoFar.OnePositions.GetLength(0);
            int numberOfStates = bestPositionSoFar.OnePositions.GetLength(1);
            _alphabetLength = alphabetLength;

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

            States = CreateAutomaton(Utils.EnumerateAlphabetSymbols(alphabetLength), functionsTable);
        }

        // Method is used in both constructors
        private List<State> CreateAutomaton(string[] alphabetLetters, string[][] functionTables)
        {
            List<State> automatonStates = new List<State>();
            char[] alphabet = new char[alphabetLetters.Length];

            // Convert string alphabet to char array
            for (int j = 0; j < alphabetLetters.Length; j++)
                char.TryParse(alphabetLetters[j], out alphabet[j]);

            // Parse each state provided in functionTable
            foreach (string[] function in functionTables)
            {
                int[] stateFunction = new int[function.Length];

                for (int j = 0; j < function.Length; j++)
                    int.TryParse(function[j], out stateFunction[j]);

                automatonStates.Add(new State(alphabet, stateFunction));
            }

            return automatonStates;
        }

        #endregion

        /// <summary>
        /// Returns number of active state after computations.
        /// </summary>
        public int GetFinalState(string word)
        {
            State currentState = States[0];
            for (int i = 0; i < word.Length; i++)
                currentState = States.ElementAt(currentState.GetNextStateNumber(word[i]));
            return States.IndexOf(currentState);
        }

        /// <summary>
        /// Makes jpg file with image of graph
        /// </summary>
        /// <param name="automatonName">Name of the automaton to be visualised (InputAutomaton or OutputAutomaton)</param>
        /// <returns></returns>
        public string GetGraph(string automatonName, out AdjacencyGraph<int, TaggedEdge<int, string>> g)
        {
            bool[] visited = new bool[States.Count];
            string[,] matrix = GenerateGraphMatrix(ref visited);

             g = new AdjacencyGraph<int, TaggedEdge<int, string>>(true);
            for (int i = 0; i < States.Count; i++)
            {
                if (visited[i])
                {
                    g.AddVertex(i);
                }
            }

            for (int i = 0; i < States.Count; i++)
                for (int j = 0; j < States.Count; j++)
                {
                    if (matrix[i, j] != "")
                        g.AddEdge(new TaggedEdge<int, string>(i, j, matrix[i, j]));
                }

            
            GraphvizAlgorithm<int, TaggedEdge<int, string>> graphviz = new GraphvizAlgorithm<int, TaggedEdge<int, string>>(g);
            graphviz.ImageType = GraphvizImageType.Png;
            graphviz.FormatEdge += (sender, args) => { args.EdgeFormatter.Label.Value = args.Edge.Tag.ToString(); };
            string output = graphviz.Generate(new FileDotEngine(), automatonName);
            
            return output;
        }

        /// <summary>
        /// Returns some random generated automaton.
        /// </summary>
        /// <param name="numberOfLetters"></param>
        /// <param name="numberOfStates"></param>
        /// <returns></returns>
        static public Automaton GetRandomAutomaton(int numberOfLetters, int numberOfStates)
        {
            string[] alphabetLetters = new string[numberOfLetters];
            for (int i = 0; i < numberOfLetters; i++)
                alphabetLetters[i] = ((char)('0' + i)).ToString();

            string[][] functionTable = new string[numberOfStates][];
            for (int i = 0; i < numberOfStates; i++) functionTable[i] = new string[numberOfLetters];

            for (int i = 0; i < numberOfStates; i++)
                for (int j = 0; j < numberOfLetters; j++)
                {
                    functionTable[i][j] = (new System.Random().Next() % numberOfStates).ToString();
                }

            return new Automaton(alphabetLetters, functionTable);
        }

        private string[,] GenerateGraphMatrix(ref bool[] visited)
        {
            string[,] matrix = new string[States.Count, States.Count];
            for (int i = 0; i < States.Count; i++)
                for (int j = 0; j < States.Count; j++)
                    matrix[i, j] = "";

            for (int i = 0; i < States.Count; i++)
            {
                for (int j = 0; j < _alphabetLength; j++)
                {
                    matrix[i, States.ElementAt(i).GetNextStateNumber(System.Convert.ToChar(j + 48))] += ("," + j.ToString());
                }
            }
            CheckGraph(matrix, ref visited, 0);
            for (int i = 0; i < States.Count; i++)
            {
                if (!visited[i])
                {
                    for (int j = 0; j < States.Count; j++)
                    {
                        matrix[i, j] = "";
                        matrix[j, i] = "";
                    }
                }
            }


            for (int i = 0; i < States.Count; i++)
                for (int j = 0; j < States.Count; j++)
                {
                    if (matrix[i, j] != "")
                        matrix[i, j] = matrix[i, j].Substring(1);
                }
            return matrix;
        }

        /// <summary>
        /// Checks if all vertices can be reached in graph
        /// </summary>
        /// <param name="matrix">Matrix of all edges between vertices in graph</param>
        /// <param name="visited">Array holding information about visited vertices <example>if visited[i] == false means that vertice i is never reached in graph</example></param>
        /// <param name="vIndex">Index of actual vertice</param>
        private void CheckGraph(string[,] matrix, ref bool[] visited, int vIndex)
        {
            visited[vIndex] = true;

            for (int i = 0; i < visited.Length; i++)
            {
                if (matrix[vIndex, i] != null && matrix[vIndex, i] != "")
                {
                    if (!visited[i])
                    {
                        CheckGraph(matrix, ref visited, i);
                    }
                }
            }
        }
    }
}
