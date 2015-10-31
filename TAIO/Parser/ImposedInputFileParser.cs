using System;
using System.IO;

namespace TAIO.Parser
{
    /// <summary>
    /// Implementation of parser for input file defined by prof
    /// </summary>
    class ImposedInputFileParser : IParser
    {
        /// <summary>
        /// Method is used to parse input file with automaton definition
        /// </summary>
        /// <param name="path">Input file path</param>
        /// <param name="functionTables"></param>
        /// <returns></returns>
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
            int statesNumber = int.Parse(inputFileLines[0].Split(',')[0]);

            //Get number of alphabet letters
            int numberOfAlphabetLetters = int.Parse(inputFileLines[0].Split(',')[1]);

            // Get function table for each automaton state
            functionTables = new string[statesNumber][];
            for (int i = 0; i < statesNumber; i++)
            {
                string[] states = inputFileLines[i + 1].Split(',');
                functionTables[i] = states;
            }

            // We don't have information about letters
            return new string[numberOfAlphabetLetters];
        }
    }
}