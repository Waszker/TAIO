using System;
using System.Windows.Forms;
using TAIO.Automata;

/// <summary>
/// Main window class
/// </summary>
namespace TAIO
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // Example parser usage
            string[][] functionTables = null;
            string[] alphabetLetters = InputFileParser.Parse(
                    @"...\\input.txt",
                    out functionTables);

            Automaton automaton = new Automata.Automaton(alphabetLetters, functionTables);
            int finalState = automaton.GetFinalState("10101011");

            Console.WriteLine(finalState);
        }
    }
}