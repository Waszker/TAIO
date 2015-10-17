using System.IO;

namespace TAIO
{
    /// <summary>
    /// Implementation of input file parser
    /// </summary>
    class InputFileParser
    {
        /// <summary>
        /// Returns data needed for automaton construction
        /// </summary>
        /// <param name="path">Input file path</param>
        /// <param name="functionTables"></param>
        public static string[] Parse(string path, out string[][] functionTables)
        {
            string[] inputFileLines = File.ReadAllLines(path);

            // Get states number
            int statesNumber = inputFileLines.Length - 1;

            // Get alphabet letters
            string[] alphabetLetters = inputFileLines[0].Split(';');

            // Get function table for each automaton state
            functionTables = new string[statesNumber][];
            for (int i = 0; i < statesNumber; i++)
            {
                string[] states = inputFileLines[i + 1].Split(';');
                functionTables[i] = states;
            }

            return alphabetLetters;
        }
    }
}