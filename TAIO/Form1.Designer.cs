namespace TAIO
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.maxIterationCount = new System.Windows.Forms.NumericUpDown();
            this.minErrLevel = new System.Windows.Forms.NumericUpDown();
            this.maxStateNumber = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.uploadFileButton = new System.Windows.Forms.Button();
            this.showInputPictureButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.showOutputPictureButton = new System.Windows.Forms.Button();
            this.findResultButton = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.wordsInTestSet = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.wordsInTrainingSet = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.NoOfWords = new System.Windows.Forms.NumericUpDown();
            this.WordLenght = new System.Windows.Forms.NumericUpDown();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.ParticlesNumber = new System.Windows.Forms.NumericUpDown();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maxIterationCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minErrLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxStateNumber)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wordsInTestSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wordsInTrainingSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NoOfWords)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WordLenght)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ParticlesNumber)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.ParticlesNumber, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label10, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.maxIterationCount, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.minErrLevel, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.maxStateNumber, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(19, 114);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(256, 208);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(4, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(183, 50);
            this.label2.TabIndex = 2;
            this.label2.Text = "Min error level";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(4, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(183, 50);
            this.label3.TabIndex = 3;
            this.label3.Text = "Max state number";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // maxIterationCount
            // 
            this.maxIterationCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.maxIterationCount.Location = new System.Drawing.Point(194, 16);
            this.maxIterationCount.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.maxIterationCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.maxIterationCount.Name = "maxIterationCount";
            this.maxIterationCount.Size = new System.Drawing.Size(58, 20);
            this.maxIterationCount.TabIndex = 4;
            this.maxIterationCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // minErrLevel
            // 
            this.minErrLevel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.minErrLevel.Location = new System.Drawing.Point(194, 67);
            this.minErrLevel.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.minErrLevel.Name = "minErrLevel";
            this.minErrLevel.Size = new System.Drawing.Size(58, 20);
            this.minErrLevel.TabIndex = 5;
            // 
            // maxStateNumber
            // 
            this.maxStateNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.maxStateNumber.Location = new System.Drawing.Point(194, 118);
            this.maxStateNumber.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.maxStateNumber.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.maxStateNumber.Name = "maxStateNumber";
            this.maxStateNumber.Size = new System.Drawing.Size(58, 20);
            this.maxStateNumber.TabIndex = 6;
            this.maxStateNumber.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(4, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(183, 50);
            this.label1.TabIndex = 1;
            this.label1.Text = "Max iteration count";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uploadFileButton
            // 
            this.uploadFileButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.uploadFileButton.FlatAppearance.BorderSize = 2;
            this.uploadFileButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.uploadFileButton.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.uploadFileButton.Location = new System.Drawing.Point(19, 17);
            this.uploadFileButton.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.uploadFileButton.Name = "uploadFileButton";
            this.uploadFileButton.Size = new System.Drawing.Size(256, 54);
            this.uploadFileButton.TabIndex = 0;
            this.uploadFileButton.Text = "Load automaton file";
            this.uploadFileButton.UseVisualStyleBackColor = true;
            this.uploadFileButton.Click += new System.EventHandler(this.uploadFileButton_Click);
            // 
            // showInputPictureButton
            // 
            this.showInputPictureButton.Enabled = false;
            this.showInputPictureButton.FlatAppearance.BorderSize = 2;
            this.showInputPictureButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.showInputPictureButton.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.showInputPictureButton.Location = new System.Drawing.Point(336, 17);
            this.showInputPictureButton.Name = "showInputPictureButton";
            this.showInputPictureButton.Size = new System.Drawing.Size(318, 40);
            this.showInputPictureButton.TabIndex = 8;
            this.showInputPictureButton.Text = "Show input automaton";
            this.showInputPictureButton.UseVisualStyleBackColor = true;
            this.showInputPictureButton.Click += new System.EventHandler(this.inputPicture_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(22, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(150, 22);
            this.label4.TabIndex = 9;
            this.label4.Text = "PSO parameters";
            // 
            // showOutputPictureButton
            // 
            this.showOutputPictureButton.Enabled = false;
            this.showOutputPictureButton.FlatAppearance.BorderSize = 2;
            this.showOutputPictureButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.showOutputPictureButton.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.showOutputPictureButton.Location = new System.Drawing.Point(336, 66);
            this.showOutputPictureButton.Name = "showOutputPictureButton";
            this.showOutputPictureButton.Size = new System.Drawing.Size(318, 40);
            this.showOutputPictureButton.TabIndex = 10;
            this.showOutputPictureButton.Text = "Show output automaton";
            this.showOutputPictureButton.UseVisualStyleBackColor = true;
            this.showOutputPictureButton.Click += new System.EventHandler(this.showOutputPictureButton_Click);
            // 
            // findResultButton
            // 
            this.findResultButton.Enabled = false;
            this.findResultButton.FlatAppearance.BorderSize = 4;
            this.findResultButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.findResultButton.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.findResultButton.Location = new System.Drawing.Point(19, 348);
            this.findResultButton.Name = "findResultButton";
            this.findResultButton.Size = new System.Drawing.Size(256, 51);
            this.findResultButton.TabIndex = 11;
            this.findResultButton.Text = "Find result automaton";
            this.findResultButton.UseVisualStyleBackColor = true;
            this.findResultButton.Click += new System.EventHandler(this.findResultButton_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(167, 417);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(484, 23);
            this.progressBar1.TabIndex = 12;
            this.progressBar1.Visible = false;
            // 
            // progressBar2
            // 
            this.progressBar2.Location = new System.Drawing.Point(167, 447);
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(484, 23);
            this.progressBar2.TabIndex = 13;
            this.progressBar2.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(16, 417);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(133, 14);
            this.label5.TabIndex = 14;
            this.label5.Text = "Iteration progress";
            this.label5.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label6.Location = new System.Drawing.Point(16, 447);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(147, 14);
            this.label6.TabIndex = 15;
            this.label6.Text = "Computation progress";
            this.label6.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label7.Location = new System.Drawing.Point(339, 126);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(140, 22);
            this.label7.TabIndex = 16;
            this.label7.Text = "Words in sets";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 52.83843F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 47.16157F));
            this.tableLayoutPanel2.Controls.Add(this.wordsInTestSet, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.label9, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.wordsInTrainingSet, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label8, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(336, 151);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(203, 104);
            this.tableLayoutPanel2.TabIndex = 17;
            // 
            // wordsInTestSet
            // 
            this.wordsInTestSet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.wordsInTestSet.Location = new System.Drawing.Point(110, 67);
            this.wordsInTestSet.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.wordsInTestSet.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.wordsInTestSet.Name = "wordsInTestSet";
            this.wordsInTestSet.Size = new System.Drawing.Size(89, 20);
            this.wordsInTestSet.TabIndex = 7;
            this.wordsInTestSet.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label9.Location = new System.Drawing.Point(4, 52);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(99, 51);
            this.label9.TabIndex = 6;
            this.label9.Text = "Testing word max length";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // wordsInTrainingSet
            // 
            this.wordsInTrainingSet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.wordsInTrainingSet.Location = new System.Drawing.Point(110, 16);
            this.wordsInTrainingSet.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.wordsInTrainingSet.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.wordsInTrainingSet.Name = "wordsInTrainingSet";
            this.wordsInTrainingSet.Size = new System.Drawing.Size(89, 20);
            this.wordsInTrainingSet.TabIndex = 5;
            this.wordsInTrainingSet.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label8.Location = new System.Drawing.Point(4, 1);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(99, 50);
            this.label8.TabIndex = 2;
            this.label8.Text = "Training word max length";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // NoOfWords
            // 
            this.NoOfWords.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.NoOfWords.Location = new System.Drawing.Point(110, 16);
            this.NoOfWords.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.NoOfWords.Name = "NoOfWords";
            this.NoOfWords.Size = new System.Drawing.Size(89, 20);
            this.NoOfWords.TabIndex = 18;
            // 
            // WordLenght
            // 
            this.WordLenght.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.WordLenght.Location = new System.Drawing.Point(110, 67);
            this.WordLenght.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.WordLenght.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.WordLenght.Name = "WordLenght";
            this.WordLenght.Size = new System.Drawing.Size(89, 20);
            this.WordLenght.TabIndex = 19;
            this.WordLenght.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 52.83843F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 47.16157F));
            this.tableLayoutPanel3.Controls.Add(this.label12, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.label13, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.WordLenght, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.NoOfWords, 1, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(336, 296);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(203, 103);
            this.tableLayoutPanel3.TabIndex = 22;
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label12.Location = new System.Drawing.Point(4, 52);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(99, 50);
            this.label12.TabIndex = 6;
            this.label12.Text = "Word length";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label13.Location = new System.Drawing.Point(4, 1);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(99, 50);
            this.label13.TabIndex = 2;
            this.label13.Text = "Number of words";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label14.Location = new System.Drawing.Point(339, 269);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(260, 22);
            this.label14.TabIndex = 23;
            this.label14.Text = "Additional training words";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label10.Location = new System.Drawing.Point(4, 154);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(183, 53);
            this.label10.TabIndex = 7;
            this.label10.Text = "Particles number";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ParticlesNumber
            // 
            this.ParticlesNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ParticlesNumber.Location = new System.Drawing.Point(194, 170);
            this.ParticlesNumber.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.ParticlesNumber.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ParticlesNumber.Name = "ParticlesNumber";
            this.ParticlesNumber.Size = new System.Drawing.Size(58, 20);
            this.ParticlesNumber.TabIndex = 24;
            this.ParticlesNumber.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(666, 482);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.tableLayoutPanel3);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.progressBar2);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.findResultButton);
            this.Controls.Add(this.showOutputPictureButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.uploadFileButton);
            this.Controls.Add(this.showInputPictureButton);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Automaton";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maxIterationCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minErrLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxStateNumber)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wordsInTestSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wordsInTrainingSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NoOfWords)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WordLenght)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ParticlesNumber)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button uploadFileButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown maxIterationCount;
        private System.Windows.Forms.NumericUpDown minErrLevel;
        private System.Windows.Forms.NumericUpDown maxStateNumber;
        private System.Windows.Forms.Button showInputPictureButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button showOutputPictureButton;
        private System.Windows.Forms.Button findResultButton;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ProgressBar progressBar2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.NumericUpDown wordsInTestSet;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown wordsInTrainingSet;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown NoOfWords;
        private System.Windows.Forms.NumericUpDown WordLenght;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown ParticlesNumber;
    }
}

