﻿using System;

namespace TAIO.Parser
{
    /// <summary>
    /// Interface for input file parsers.
    /// </summary>
    public interface IParser
    {
        /// <summary>
        /// Method is used to parse input file with automaton definition.
        /// </summary>
        /// <param name="path">Input file path</param>
        string[] Parse(string path, out string[][] functionTables);
    }
}
