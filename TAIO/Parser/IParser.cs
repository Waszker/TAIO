using System;

namespace TAIO.Parser
{
    /// <summary>
    /// Interface for input file parsers.
    /// </summary>
    interface IParser
    {
        /// <summary>
        /// Method is used to parse input file with automaton definition.
        /// </summary>
        /// <param name="path">Input file path</param>
        string[] Parse(string path, out string[][] functionTables);
    }

    /// <summary>
    /// Class is used to inform about bad structure of input file.
    /// </summary>
    class BadFileStructureException : Exception
    {
        // NOT USED
        public BadFileStructureException(string message) : base(message)
        {
        }
    }
}
