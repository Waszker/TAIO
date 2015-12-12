﻿using QuickGraph;
using System;
using System.Diagnostics.CodeAnalysis;
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
    [ExcludeFromCodeCoverage]
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
                    alphabetLetters = new InputFileParser().Parse(filename,
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
            //MessageBox.Show($"Best automaton found with error rate: {errorRate}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            AdjacencyGraph<int, TaggedEdge<int, string>> g;
            foundAutomaton.GetGraph("OutputAutomaton" + automatoncounter, out g);
            GenerateFile(g, errorRate, automaton.States.Count);
        }

        private void inputPicture_Click(object sender, EventArgs e)
        {
            automatoncounter++;
            AdjacencyGraph<int, TaggedEdge<int, string>> g;
            automaton.GetGraph("InputAutomaton" + automatoncounter, out g);

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
            AdjacencyGraph<int, TaggedEdge<int, string>> g;
            foundAutomaton.GetGraph("OutputAutomaton" + automatoncounter, out g);

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
            int automataAmount = 10;
            int maxNumberOfLetters = 5;
            alphabetLetters = new string[] { "0", "1", "2", "3", "4" };
            for (int i = 0; i < automataAmount; i++)
            {
                for (int j = 0; j < basicStates.Length; j++)
                {
                    automaton = Automaton.GetRandomAutomaton(alphabetLetters, basicStates[j]);
                    showInputPictureButton.Enabled = true;
                    findResultButton_Click(sender, e);
                }
            }
        }

        private void GenerateFile(AdjacencyGraph<int, TaggedEdge<int, string>> g, string errorRate, int originalStatesCount)
        {
            string path = @"resultAutomaton" + (DateTime.Now.ToString()).Replace(" ", "-").Replace(":","-") + ".txt"; 
            StringBuilder output = new StringBuilder();
            File.Create(path).Dispose();

            int stateCounter = g.VertexCount;

            int[,] stateTable = new int[stateCounter, alphabetLetters.Length];
            for (int i = 0; i < stateCounter; i++)
                for (int j = 0; j < alphabetLetters.Length; j++)
                    stateTable[i, j] = -1;
            int[] vertices = new int[g.VertexCount];

           
            int jj=0;
            foreach (int v in g.Vertices)
            {
                vertices[jj] = v;
                jj++;
            }
   
            foreach (TaggedEdge<int, string> e in g.Edges)
            {
                string[] states = e.Tag.Split(',');

                for (int k = 0; k < states.Length; k++)
                {
                    int source = -1;
                    int target = -1;
                    for(int l=0;l<vertices.Length;l++)
                    {
                        if (vertices[l] == e.Source)
                            source = l;
                        if (vertices[l] == e.Target)
                            target = l;
                    }
                    stateTable[source, Int32.Parse(states[k])] = target;
                }
                    
            }

            for (int i = 0; i < stateCounter; i++)
            {
                StringBuilder row = new StringBuilder();
                for (int j = 0; j < alphabetLetters.Length; j++)
                {
                    if (j > 0)
                        row.Append(", ");
                    row.Append(stateTable[i, j]);
                }
                output.Append("\r\n");
                output.Append(row);
            }
                

            using (TextWriter tw = new StreamWriter(path))
            {
                tw.Write(stateCounter + ", " + alphabetLetters.Length);
                tw.WriteLine(output);
                tw.WriteLine("Error rate: " +errorRate);
                tw.WriteLine("Number of states in input automaton: " + originalStatesCount);
                tw.Close();
            }
        }
    }
}