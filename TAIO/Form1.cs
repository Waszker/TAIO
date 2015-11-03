﻿using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using TAIO.Automata;
using TAIO.Parser;
using TAIO.PSO;


namespace TAIO
{
    /// <summary>
    /// Main window class
    /// </summary>
    public partial class Form1 : Form
    {
        private Automaton automaton;
        private Automaton foundAutomaton;
        private string[] alphabetLetters;

        public Form1()
        {
            InitializeComponent();

            // Example parser usage
            /*string[][] functionTables = null;
            string[] alphabetLetters = InputFileParser.Parse(
                    @"...\\input.txt",
                    out functionTables);

            Automaton automaton = new Automata.Automaton(alphabetLetters, functionTables);
            int finalState = automaton.GetFinalState("10101011");

            Console.WriteLine(finalState);*/
            
        }

        private void uploadFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog theDialog = new OpenFileDialog
            {
                Title = @"Open Text File",
                Filter = @"TXT files|*.txt",
                InitialDirectory = @"C:\"
            };
            if (theDialog.ShowDialog() == DialogResult.OK)
            {
                string filename = theDialog.FileName;              
                string[][] functionTables = null;
                alphabetLetters = new ImposedInputFileParser().Parse(filename,
                        out functionTables);
                automaton = new Automata.Automaton(alphabetLetters, functionTables);

                showInputPictureButton.Enabled = true;
                findResultButton.Enabled = true;
            }
        }

        private void inputPicture_Click(object sender, EventArgs e)
        {
            automaton.GetGraph("InputAutomaton");
            System.Threading.Thread.Sleep(1000); //CHANGE THIS SHIT
            if (File.Exists("InputAutomaton.jpg"))
            {
                PictureWindow pw = new PictureWindow("Input Automaton", "InputAutomaton.jpg");
                pw.Show();
            }
        }

        private void findResultButton_Click(object sender, EventArgs e)
        {
            string[] alphabet = new String[Math.Max(10, alphabetLetters.Length)];
            if (alphabetLetters.Length < 10)
            {
                for( int i = 0; i < 10; i++)
                {
                    alphabet[i] = alphabetLetters[i % alphabetLetters.Length];
                }
            }
            WordSetGenerator w = new WordSetGenerator(alphabet);
            w.GenerateRecusivelyVariationsWithRepeats(new StringBuilder(), 0, 5);
            w.GenerateRecusivelyVariationsWithoutRepeats(new StringBuilder(), 0, 10);
            TargetFunction targetFunction = new TargetFunction(automaton, w.TrainingWords, w.TestingWords);

            PsoAlgorithm pso = new PsoAlgorithm((double)min_err_level.Value, (int)max_iteration_count.Value, (int)max_state_number.Value, alphabetLetters.Length, 100);
            foundAutomaton = pso.RunAlgorithm();
            showOutputPictureButton.Enabled = true;

        }

        private void showOutputPictureButton_Click(object sender, EventArgs e)
        {
            foundAutomaton.GetGraph("OutputAutomaton");
            System.Threading.Thread.Sleep(1000); //CHANGE THIS SHIT
            if (File.Exists("OutputAutomaton.jpg"))
            {
                PictureWindow pw = new PictureWindow("Output Automaton", "OutputAutomaton.jpg");
                pw.Show();
            }
        }
    }
}