using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            string[] alphabetLetters =
                InputFileParser.Parse(
                    @"C:\\Users\\Paweł\\Documents\\Visual Studio 2015\\Projects\\TAIO\\TAIO\\input.txt",
                    out functionTables);

            Automaton automaton = new Automaton(alphabetLetters, functionTables);
            int finalState = automaton.GetFinalState("10101011");

            Console.WriteLine(finalState);
        }
    }
}