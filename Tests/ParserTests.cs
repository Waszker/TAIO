using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Text;
using TAIO.Parser;

namespace Tests
{
    [TestClass]
    public class ParserTests
    {
        IParser parser = new ImposedInputFileParser();

        [TestMethod]
        [ExpectedException(typeof(IOException))]
        public void NoInputFileTest()
        {
            // Arrange
            string path = Directory.GetCurrentDirectory();

            // Act
            string[][] functionTables = null;
            string[] automaton = parser.Parse($"..\\..\\{path}\\nofile.txt", out functionTables);
        }

        [TestMethod]
        public void ParseInputFileTest()
        {
            // Arrange
            #region Path

            string[] directoryPath = Environment.CurrentDirectory.Split(Path.DirectorySeparatorChar);
            string path = null;
            for (int i = 0; i < directoryPath.Length - 3; i++)
                path += $"{directoryPath[i]}{Path.DirectorySeparatorChar}";

            #endregion

            #region Supposed automaton function tables

            string[][] supposedTables = new string[3][] { new string[] { "1", "2" }, new string[] { "2", "2" }, new string[] { "1", "1" } };

            #endregion

            // Act
            string[][] functionTables = null;
            string[] automaton = parser.Parse($"{path}{Path.DirectorySeparatorChar}{"TAIO"}{Path.DirectorySeparatorChar}test_input.txt", out functionTables);

            // Assert
            Assert.AreEqual(ConvertFunctionTablesToString(functionTables), ConvertFunctionTablesToString(supposedTables));
        }

        private string ConvertFunctionTablesToString(string[][] functionTables)
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < functionTables.Length; i++)
                for (int j = 0; j < functionTables[i].Length; j++)
                    builder.Append(functionTables[i][j]);
            return builder.ToString();
        }
    }
}
