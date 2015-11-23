using System;
using System.Diagnostics;
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
        private readonly int defaultTestingWordMaxLength = 10;
        private readonly int defaultTrainingWordMaxLength = 5;
        private readonly int defaultTestingWordMinLength = 6;
        private int testingWordMaxLength = 10;
        private int trainingWordMaxLength = 5;
        private Automaton automaton;
        private Automaton foundAutomaton;
        private string[] alphabetLetters;
        private int automatoncounter;

        public Form1()
        {
            InitializeComponent();
            automatoncounter = 0;
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

                // Parse input file and generate automaton
                alphabetLetters = new ImposedInputFileParser().Parse(filename,
                        out functionTables);
                automaton = new Automaton(alphabetLetters, functionTables);

                showInputPictureButton.Enabled = true;
                findResultButton.Enabled = true;
            }
        }

        private void findResultButton_Click(object sender, EventArgs e)
        {
            if(words_in_training_set.Value < defaultTrainingWordMaxLength)
            {
                words_in_training_set.Value = defaultTrainingWordMaxLength;
            }
            trainingWordMaxLength = (int) words_in_training_set.Value;
            if(words_in_test_set.Value < defaultTestingWordMaxLength)
            {
                words_in_test_set.Value = defaultTestingWordMaxLength;
            }
            testingWordMaxLength = (int) words_in_test_set.Value;

            // Prepare word sets
            string[] trainingLetters = prepareAlphabet(trainingWordMaxLength);
            string[] testingLetters = prepareAlphabet(testingWordMaxLength);

            WordSetGenerator w = new WordSetGenerator(testingLetters, trainingLetters, defaultTestingWordMinLength);

            // Generate training set
            Debug.WriteLine("Starting word sets generation");
            w.GenerateTrainingWordsSet(new StringBuilder(), 0, trainingWordMaxLength);
            Debug.WriteLine("Finished training word sets generation");

            // Generate testing set
            w.GenerateTestingWordsSet(new StringBuilder(), 0, testingWordMaxLength, new bool[testingLetters.Length]);
            Debug.WriteLine("Finished test word sets generation");

            TargetFunction targetFunction = new TargetFunction(automaton, w.TrainingWords, w.TestingWords);

            // Start algorithm
            Debug.WriteLine("Running PSO");
            PsoAlgorithm pso = new PsoAlgorithm((double)min_err_level.Value, (int)max_iteration_count.Value, (int)max_state_number.Value, alphabetLetters.Length, 100);
            foundAutomaton = pso.RunAlgorithm();
            Debug.WriteLine("Ended PSO");
            Debug.WriteLine("Ended removing unreached states");

            showOutputPictureButton.Enabled = true;
        }

        private string[] prepareAlphabet(int expectedMinAlphabetLength)
        {
            int newLength = Math.Max(alphabetLetters.Length, expectedMinAlphabetLength);
            string[] newAlphabet = new string[newLength];
            for (int i = 0; i < newLength; i++)
            {
                newAlphabet[i] = alphabetLetters[i % alphabetLetters.Length];
            }
            return newAlphabet;
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
    }
}