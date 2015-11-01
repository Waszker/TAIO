using System.Collections.Generic;

namespace TAIO
{
    public static class Utils
    {
        public static string[] EnumerateAlphabetSymbols(int numberOfAlphabetSymbols)
        {
            List<string> alphabetLetters = new List<string>();

            for (int i = 0; i < numberOfAlphabetSymbols; i++)
                alphabetLetters.Add(i.ToString());

            return alphabetLetters.ToArray();
        }
    }
}
