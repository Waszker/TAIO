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
            this.max_iteration_count = new System.Windows.Forms.NumericUpDown();
            this.min_err_level = new System.Windows.Forms.NumericUpDown();
            this.max_state_number = new System.Windows.Forms.NumericUpDown();
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
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.max_iteration_count)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.min_err_level)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.max_state_number)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.max_iteration_count, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.min_err_level, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.max_state_number, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(19, 114);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(256, 156);
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
            this.label3.Size = new System.Drawing.Size(183, 52);
            this.label3.TabIndex = 3;
            this.label3.Text = "Max state number";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // max_iteration_count
            // 
            this.max_iteration_count.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.max_iteration_count.Location = new System.Drawing.Point(194, 16);
            this.max_iteration_count.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.max_iteration_count.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.max_iteration_count.Name = "max_iteration_count";
            this.max_iteration_count.Size = new System.Drawing.Size(58, 20);
            this.max_iteration_count.TabIndex = 4;
            this.max_iteration_count.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // min_err_level
            // 
            this.min_err_level.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.min_err_level.Location = new System.Drawing.Point(194, 67);
            this.min_err_level.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.min_err_level.Name = "min_err_level";
            this.min_err_level.Size = new System.Drawing.Size(58, 20);
            this.min_err_level.TabIndex = 5;
            // 
            // max_state_number
            // 
            this.max_state_number.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.max_state_number.Location = new System.Drawing.Point(194, 119);
            this.max_state_number.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.max_state_number.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.max_state_number.Name = "max_state_number";
            this.max_state_number.Size = new System.Drawing.Size(58, 20);
            this.max_state_number.TabIndex = 6;
            this.max_state_number.Value = new decimal(new int[] {
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
            this.uploadFileButton.Size = new System.Drawing.Size(256, 40);
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
            this.showInputPictureButton.Location = new System.Drawing.Point(413, 40);
            this.showInputPictureButton.Name = "showInputPictureButton";
            this.showInputPictureButton.Size = new System.Drawing.Size(241, 40);
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
            this.showOutputPictureButton.Location = new System.Drawing.Point(413, 89);
            this.showOutputPictureButton.Name = "showOutputPictureButton";
            this.showOutputPictureButton.Size = new System.Drawing.Size(241, 40);
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
            this.findResultButton.Location = new System.Drawing.Point(19, 298);
            this.findResultButton.Name = "findResultButton";
            this.findResultButton.Size = new System.Drawing.Size(256, 51);
            this.findResultButton.TabIndex = 11;
            this.findResultButton.Text = "Find result automaton";
            this.findResultButton.UseVisualStyleBackColor = true;
            this.findResultButton.Click += new System.EventHandler(this.findResultButton_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(170, 375);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(484, 23);
            this.progressBar1.TabIndex = 12;
            // 
            // progressBar2
            // 
            this.progressBar2.Location = new System.Drawing.Point(170, 405);
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(484, 23);
            this.progressBar2.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(19, 375);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(133, 14);
            this.label5.TabIndex = 14;
            this.label5.Text = "Iteration progress";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label6.Location = new System.Drawing.Point(19, 405);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(147, 14);
            this.label6.TabIndex = 15;
            this.label6.Text = "Computation progress";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(666, 438);
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
            ((System.ComponentModel.ISupportInitialize)(this.max_iteration_count)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.min_err_level)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.max_state_number)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button uploadFileButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown max_iteration_count;
        private System.Windows.Forms.NumericUpDown min_err_level;
        private System.Windows.Forms.NumericUpDown max_state_number;
        private System.Windows.Forms.Button showInputPictureButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button showOutputPictureButton;
        private System.Windows.Forms.Button findResultButton;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ProgressBar progressBar2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}

