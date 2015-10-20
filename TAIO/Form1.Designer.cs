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
            this.uploadFileButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.max_iteration_count = new System.Windows.Forms.NumericUpDown();
            this.min_err_level = new System.Windows.Forms.NumericUpDown();
            this.max_state_number = new System.Windows.Forms.NumericUpDown();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.inputPicture = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.max_iteration_count)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.min_err_level)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.max_state_number)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.uploadFileButton, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.max_iteration_count, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.min_err_level, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.max_state_number, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.pictureBox1, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.inputPicture, 2, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30.76923F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 23.07692F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 23.07692F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 23.07692F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 13F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(590, 386);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // uploadFileButton
            // 
            this.uploadFileButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.uploadFileButton.FlatAppearance.BorderSize = 2;
            this.uploadFileButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.uploadFileButton.Location = new System.Drawing.Point(3, 38);
            this.uploadFileButton.Name = "uploadFileButton";
            this.uploadFileButton.Size = new System.Drawing.Size(190, 30);
            this.uploadFileButton.TabIndex = 0;
            this.uploadFileButton.Text = "Upload File";
            this.uploadFileButton.UseVisualStyleBackColor = true;
            this.uploadFileButton.Click += new System.EventHandler(this.uploadFileButton_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(190, 79);
            this.label1.TabIndex = 1;
            this.label1.Text = "max_iteration_count";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 185);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(190, 79);
            this.label2.TabIndex = 2;
            this.label2.Text = "min_err_level";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 264);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(190, 79);
            this.label3.TabIndex = 3;
            this.label3.Text = "max_state_number";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // max_iteration_count
            // 
            this.max_iteration_count.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.max_iteration_count.Location = new System.Drawing.Point(199, 135);
            this.max_iteration_count.Name = "max_iteration_count";
            this.max_iteration_count.Size = new System.Drawing.Size(190, 20);
            this.max_iteration_count.TabIndex = 4;
            // 
            // min_err_level
            // 
            this.min_err_level.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.min_err_level.Location = new System.Drawing.Point(199, 214);
            this.min_err_level.Name = "min_err_level";
            this.min_err_level.Size = new System.Drawing.Size(190, 20);
            this.min_err_level.TabIndex = 5;
            // 
            // max_state_number
            // 
            this.max_state_number.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.max_state_number.Location = new System.Drawing.Point(199, 293);
            this.max_state_number.Name = "max_state_number";
            this.max_state_number.Size = new System.Drawing.Size(190, 20);
            this.max_state_number.TabIndex = 6;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(395, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(192, 100);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // inputPicture
            // 
            this.inputPicture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.inputPicture.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.inputPicture.Location = new System.Drawing.Point(395, 346);
            this.inputPicture.Name = "inputPicture";
            this.inputPicture.Size = new System.Drawing.Size(192, 21);
            this.inputPicture.TabIndex = 8;
            this.inputPicture.Text = "Show Input Automaton";
            this.inputPicture.UseVisualStyleBackColor = true;
            this.inputPicture.Click += new System.EventHandler(this.inputPicture_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 386);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Automaton";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.max_iteration_count)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.min_err_level)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.max_state_number)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button inputPicture;
    }
}

