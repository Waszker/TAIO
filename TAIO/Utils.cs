using System.Collections.Generic;

namespace TAIO
{
    /// <summary>
    /// Store some help methods
    /// </summary>
    public static class Utils
    {
        /// <summary>
        /// Enumerates alphabet letters
        /// </summary>
        /// <param name="numberOfAlphabetSymbols">Number of letters in alphabet</param>
        /// <returns></returns>
        public static string[] EnumerateAlphabetSymbols(int numberOfAlphabetSymbols)
        {
            List<string> alphabetLetters = new List<string>();

            for (int i = 0; i < numberOfAlphabetSymbols; i++)
                alphabetLetters.Add(i.ToString());

            return alphabetLetters.ToArray();
        }
    }
}
