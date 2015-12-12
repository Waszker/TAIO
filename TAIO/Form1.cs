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
        private int trainingWordMaxLength = 8;
        private Automaton automaton;
        private Automaton foundAutomaton;
        private string[] alphabetLetters;
        private int automatoncounter;

        #endregion


        /// <summary>
        /// Creates main window
        /// </summary>
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
                InitialDirectory = Directory.GetCurrentDirectory()
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
            if(wordsInTrainingSet.Value > defaultTrainingWordMaxLength)
            {
                wordsInTrainingSet.Value = defaultTrainingWordMaxLength;
            }
            trainingWordMaxLength = (int) wordsInTrainingSet.Value;
            if(wordsInTestSet.Value > defaultTestingWordMaxLength)
            {
                wordsInTestSet.Value = defaultTestingWordMaxLength;
            }
            if (wordsInTestSet.Value < defaultTestingWordMinLength)
            {
                wordsInTestSet.Value = defaultTestingWordMinLength;
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
            for(int i = 0;  i< NoOfWords.Value; i++)
            {
                StringBuilder word = new StringBuilder();
                StringBuilder word2 = new StringBuilder();
                Random random = new Random();
                int length = random.Next((int)wordsInTrainingSet.Value, (int)WordLenght.Value + 1);
                for(int j = 0; j < length; j++)
                {
                    word.Append(alphabetLetters[random.Next() % alphabetLetters.Length]);
                    word2.Append(alphabetLetters[random.Next() % alphabetLetters.Length]);
                }
                w.TrainingWords.Add(word.ToString());
                w.TestingWords.Add(word2.ToString());
            }
            Console.WriteLine("Go go go!");
            TargetFunction targetFunction = new TargetFunction(automaton, w.TrainingWords, w.TestingWords);

            // Start algorithm and then remove unreached states
            PsoAlgorithm pso = new PsoAlgorithm((double)minErrLevel.Value, (int)maxIterationCount.Value, (int)maxStateNumber.Value, alphabetLetters.Length, (int)ParticlesNumber.Value);
            System.Tuple<Automaton, double> result = pso.RunAlgorithm();
            foundAutomaton = result.Item1;

            showOutputPictureButton.Enabled = true;
            string errorRate = result.Item2.ToString("N2");
            MessageBox.Show($"Best automaton found with error rate: {errorRate}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void button1_Click(object sender, EventArgs e)
        {
            GenerateTests(sender, e);
        }

        private void GenerateTests(object sender, EventArgs e)
        {
            int[] basicStates = new int[] { 4, 6, 10, 15 };
            int automataAmount = 1;
            int maxNumberOfLetters = 5;
            alphabetLetters = new string[] { "0", "1", "2", "3", "4" };
            for (int i = 0; i < automataAmount; i++)
            {
                for (int j = 0; j < basicStates.Length; j++)
                {
                    automaton = Automaton.GetRandomAutomaton(maxNumberOfLetters, basicStates[j]);
                    findResultButton_Click(sender, e);
                    int state = foundAutomaton.GetFinalState("01");
                }
            }
        }
    }
}