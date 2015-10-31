using System;
using System.IO;

namespace TAIO.Parser
{
    /// <summary>
    /// Implementation of input file parser
    /// </summary>
    public class InputFileParser : IParser
    {
        /// <summary>
        /// Returns data needed for automaton construction
        /// </summary>
        /// <param name="path">Input file path</param>
        /// <param name="functionTables"></param>
        public string[] Parse(string path, out string[][] functionTables)
        {
            string[] inputFileLines = null;

            try
            {
                inputFileLines = File.ReadAllLines(path);
            }
            catch (Exception ex)
            {
                throw new IOException(ex.Message);
            }

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