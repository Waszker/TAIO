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
        private readonly List<State> states;
        private readonly int alphabetLen;

        #region Constructors

        /// <summary>
        /// Takes alphabet letters as string array convertible to char array and function table for each state.
        /// </summary>
        /// <param name="alphabetLetters"></param>
        /// <param name="functionTables"></param>
        public Automaton(string[] alphabetLetters, string[][] functionTables)
        {
            states = CreateAutomaton(alphabetLetters, functionTables);
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

            states = CreateAutomaton(Utils.EnumerateAlphabetSymbols(alphabetLength), functionsTable);
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
            State currentState = states[0];
            for (int i = 0; i < word.Length; i++)
                currentState = states.ElementAt(currentState.GetNextStateNumber(word[i]));
            return states.IndexOf(currentState);
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
            bool[] visited = new bool[states.Count];
            string[,] matrix = GenerateGraphMatrix(ref visited);

            AdjacencyGraph<int, TaggedEdge<int, string>> g = new AdjacencyGraph<int, TaggedEdge<int, string>>(true);
            for (int i = 0; i < states.Count; i++)
            {
                if (visited[i])
                {
                    g.AddVertex(i);
                }
            }

            for (int i = 0; i < states.Count; i++)
                for (int j = 0; j < states.Count; j++)
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

        private string[,] GenerateGraphMatrix(ref bool[] visited)
        {
            string[,] matrix = new string[states.Count, states.Count];
            for (int i = 0; i < states.Count; i++)
                for (int j = 0; j < states.Count; j++)
                    matrix[i, j] = "";

            for (int i = 0; i < states.Count; i++)
            {
                for (int j = 0; j < alphabetLen; j++)
                {
                    matrix[i, states.ElementAt(i).GetNextStateNumber(System.Convert.ToChar(j + 48))] += ("," + j.ToString());
                }
            }
            CheckGraph(matrix, ref visited, 0);
            for (int i = 0; i < states.Count; i++)
            {
                if (!visited[i])
                {
                    for (int j = 0; j < states.Count; j++)
                    {
                        matrix[i, j] = "";
                        matrix[j, i] = "";
                    }
                }
            }


            for (int i = 0; i < states.Count; i++)
                for (int j = 0; j < states.Count; j++)
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
