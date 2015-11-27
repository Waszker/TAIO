using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using TAIO.Automata;
using TAIO.Parser;
using TAIO.PSO;


namespace TAIO
{
    /// <summary>
    /// Main window class.
    /// </summary>
    public partial class Form1 : Form
    {
        #region Fields

        private readonly int defaultTestingWordMaxLength = 10;
        private readonly int defaultTrainingWordMaxLength = 5;
        private readonly int defaultTestingWordMinLength = 6;
        private int testingWordMaxLength = 10;
        private int trainingWordMaxLength = 5;
        private Automaton automaton;
        private Automaton foundAutomaton;
        private string[] alphabetLetters;
        private int automatoncounter;

        #endregion

        public Form1()
        {
            InitializeComponent();
            automatoncounter = 0;
        }

        #region UI event handlers

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

                try
                {
                    alphabetLetters = new ImposedInputFileParser().Parse(filename,
                           out functionTables);
                }
                catch (Exception)
                {
                    MessageBox.Show("Wrong file format!","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                    automaton = null;
                    return;
                }


                automaton = new Automaton(alphabetLetters, functionTables);

                showInputPictureButton.Enabled = true;
                findResultButton.Enabled = true;
            }
        }

        private void findResultButton_Click(object sender, EventArgs e)
        {
            if(wordsInTrainingSet.Value < defaultTrainingWordMaxLength)
            {
                wordsInTrainingSet.Value = defaultTrainingWordMaxLength;
            }
            trainingWordMaxLength = (int) wordsInTrainingSet.Value;
            if(wordsInTestSet.Value < defaultTestingWordMaxLength)
            {
                wordsInTestSet.Value = defaultTestingWordMaxLength;
            }
            testingWordMaxLength = (int) wordsInTestSet.Value;

            // Prepare word sets
            string[] trainingLetters = prepareAlphabet(trainingWordMaxLength);
            string[] testingLetters = prepareAlphabet(testingWordMaxLength);

            WordSetGenerator w = new WordSetGenerator(testingLetters, trainingLetters, defaultTestingWordMinLength);
            Console.WriteLine("Generating training words!");
            // Generate training set
            w.GenerateTrainingWordsSet(new StringBuilder(), 0, trainingWordMaxLength);
            Console.WriteLine("Generating testing words!");
            // Generate testing set
            w.GenerateTestingWordsSet(new StringBuilder(), 0, testingWordMaxLength, new bool[testingLetters.Length]);
            Console.WriteLine("Go go go!");
            TargetFunction targetFunction = new TargetFunction(automaton, w.TrainingWords, w.TestingWords);

            // Start algorithm and then remove unreached states
            PsoAlgorithm pso = new PsoAlgorithm((double)minErrLevel.Value, (int)maxIterationCount.Value, (int)maxStateNumber.Value, alphabetLetters.Length, 100);
            foundAutomaton = pso.RunAlgorithm();

            showOutputPictureButton.Enabled = true;
        }

        private void inputPicture_Click(object sender, EventArgs e)
        {
            automatoncounter++;
            automaton.GetGraph("InputAutomaton" + automatoncounter);

            //TODO: Needs to be changed
            System.Threading.Thread.Sleep(1000);

            if (File.Exists("InputAutomaton" + automatoncounter + ".jpg"))
            {
                PictureWindow pw = new PictureWindow("Input Automaton", "InputAutomaton" + automatoncounter + ".jpg");
                pw.Show();
            }
        }

        private void showOutputPictureButton_Click(object sender, EventArgs e)
        {
            automatoncounter++;
            foundAutomaton.GetGraph("OutputAutomaton" + automatoncounter);

            //TODO: Needs to be changed
            System.Threading.Thread.Sleep(1000);

            if (File.Exists("OutputAutomaton" + automatoncounter + ".jpg"))
            {
                PictureWindow pw = new PictureWindow("Output Automaton", "OutputAutomaton" + automatoncounter + ".jpg");
                pw.Show();
            }
        }

        #endregion

        private string[] prepareAlphabet(int expectedMinAlphabetLength)
        {
            int newLength = Math.Max(alphabetLetters.Length, expectedMinAlphabetLength);
            string[] newAlphabet = new string[newLength];
            for (int i = 0; i < newLength; i++)
            {
                newAlphabet[i] = alphabetLetters[i%alphabetLetters.Length];
            }
            return newAlphabet;
        }
    }
}