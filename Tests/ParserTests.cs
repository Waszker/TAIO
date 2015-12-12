using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using TAIO.Parser;

namespace Tests
{
    [TestClass]
    public class ParserTests
    {
        IParser parser = new ImposedInputFileParser();

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
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
            Assert.AreEqual(functionTables, supposedTables);
        }
    }
}
