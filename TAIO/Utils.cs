using System.Collections.Generic;

namespace TAIO
{
    /// <summary>
    /// Class stores some help methods.
    /// </summary>
    public static class Utils
    {
        /// <summary>
        /// Enumerates alphabet letters.
        /// </summary>
        public static string[] EnumerateAlphabetSymbols(int numberOfAlphabetSymbols)
        {
            List<string> alphabetLetters = new List<string>();

            for (int i = 0; i < numberOfAlphabetSymbols; i++)
                alphabetLetters.Add(i.ToString());

            return alphabetLetters.ToArray();
        }
    }
}
