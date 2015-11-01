using System;
using System.IO;
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
                string[] alphabetLetters = new ImposedInputFileParser().Parse(filename,
                        out functionTables);
                automaton = new Automata.Automaton(alphabetLetters, functionTables);

                Position position = new Position(2, 3) { OnePositions = new[,] { { 1, 2, 1 }, { 2, 2, 1 } } };
                Automaton testAutomaton = new Automaton(position);

                Type automatonType = testAutomaton.GetType();

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
    }
}