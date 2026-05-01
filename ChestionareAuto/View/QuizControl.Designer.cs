namespace View
{
    partial class QuizControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            checkBoxAnswer1 = new CheckBox();
            checkBoxAnswer3 = new CheckBox();
            checkBoxAnswer2 = new CheckBox();
            labelQuestion = new Label();
            pictureBoxQuestion = new PictureBox();
            labelGoodAnswersCount = new Label();
            labelBadAnswerCount = new Label();
            labelTimeRemained = new Label();
            buttonNext = new Button();
            buttonHelp = new Button();
            buttonAbort = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBoxQuestion).BeginInit();
            SuspendLayout();
            // 
            // checkBoxAnswer1
            // 
            checkBoxAnswer1.Font = new Font("Segoe UI", 12F);
            checkBoxAnswer1.Location = new Point(29, 342);
            checkBoxAnswer1.Name = "checkBoxAnswer1";
            checkBoxAnswer1.Size = new Size(750, 60);
            checkBoxAnswer1.TabIndex = 0;
            checkBoxAnswer1.Text = "raspuns_1";
            checkBoxAnswer1.UseVisualStyleBackColor = true;
            // 
            // checkBoxAnswer3
            // 
            checkBoxAnswer3.Font = new Font("Segoe UI", 12F);
            checkBoxAnswer3.Location = new Point(29, 474);
            checkBoxAnswer3.Name = "checkBoxAnswer3";
            checkBoxAnswer3.Size = new Size(750, 60);
            checkBoxAnswer3.TabIndex = 1;
            checkBoxAnswer3.Text = "raspuns_3";
            checkBoxAnswer3.UseVisualStyleBackColor = true;
            // 
            // checkBoxAnswer2
            // 
            checkBoxAnswer2.Font = new Font("Segoe UI", 12F);
            checkBoxAnswer2.Location = new Point(29, 408);
            checkBoxAnswer2.Name = "checkBoxAnswer2";
            checkBoxAnswer2.Size = new Size(750, 60);
            checkBoxAnswer2.TabIndex = 2;
            checkBoxAnswer2.Text = "raspuns_2";
            checkBoxAnswer2.UseVisualStyleBackColor = true;
            // 
            // labelQuestion
            // 
            labelQuestion.Font = new Font("Segoe UI", 14F);
            labelQuestion.Location = new Point(29, 283);
            labelQuestion.Name = "labelQuestion";
            labelQuestion.Size = new Size(914, 42);
            labelQuestion.TabIndex = 3;
            labelQuestion.Text = "Aici va fi introdusa intrebarea";
            // 
            // pictureBoxQuestion
            // 
            pictureBoxQuestion.Location = new Point(29, 14);
            pictureBoxQuestion.Name = "pictureBoxQuestion";
            pictureBoxQuestion.Size = new Size(637, 251);
            pictureBoxQuestion.TabIndex = 4;
            pictureBoxQuestion.TabStop = false;
            // 
            // labelGoodAnswersCount
            // 
            labelGoodAnswersCount.Font = new Font("Segoe UI", 13F);
            labelGoodAnswersCount.ForeColor = Color.FromArgb(0, 192, 0);
            labelGoodAnswersCount.Location = new Point(695, 75);
            labelGoodAnswersCount.Name = "labelGoodAnswersCount";
            labelGoodAnswersCount.Size = new Size(280, 35);
            labelGoodAnswersCount.TabIndex = 5;
            labelGoodAnswersCount.Text = "Raspunsuri corecte:";
            // 
            // labelBadAnswerCount
            // 
            labelBadAnswerCount.Font = new Font("Segoe UI", 13F);
            labelBadAnswerCount.ForeColor = Color.Red;
            labelBadAnswerCount.Location = new Point(695, 122);
            labelBadAnswerCount.Name = "labelBadAnswerCount";
            labelBadAnswerCount.Size = new Size(280, 35);
            labelBadAnswerCount.TabIndex = 6;
            labelBadAnswerCount.Text = "Raspunsuri gresite:";
            // 
            // labelTimeRemained
            // 
            labelTimeRemained.Font = new Font("Segoe UI", 13F);
            labelTimeRemained.ForeColor = Color.Black;
            labelTimeRemained.Location = new Point(695, 168);
            labelTimeRemained.Name = "labelTimeRemained";
            labelTimeRemained.Size = new Size(280, 35);
            labelTimeRemained.TabIndex = 7;
            labelTimeRemained.Text = "Timp ramas:";
            // 
            // buttonNext
            // 
            buttonNext.Font = new Font("Segoe UI", 12F);
            buttonNext.Location = new Point(798, 362);
            buttonNext.Name = "buttonNext";
            buttonNext.Size = new Size(160, 40);
            buttonNext.TabIndex = 8;
            buttonNext.Text = "Next";
            buttonNext.UseVisualStyleBackColor = true;
            // 
            // buttonHelp
            // 
            buttonHelp.Font = new Font("Segoe UI", 12F);
            buttonHelp.Location = new Point(798, 417);
            buttonHelp.Name = "buttonHelp";
            buttonHelp.Size = new Size(160, 40);
            buttonHelp.TabIndex = 9;
            buttonHelp.Text = "Help";
            buttonHelp.UseVisualStyleBackColor = true;
            // 
            // buttonAbort
            // 
            buttonAbort.Font = new Font("Segoe UI", 12F);
            buttonAbort.Location = new Point(798, 474);
            buttonAbort.Name = "buttonAbort";
            buttonAbort.Size = new Size(160, 40);
            buttonAbort.TabIndex = 10;
            buttonAbort.Text = "Abort Sesion";
            buttonAbort.UseVisualStyleBackColor = true;
            // 
            // QuizControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(buttonAbort);
            Controls.Add(buttonHelp);
            Controls.Add(buttonNext);
            Controls.Add(labelTimeRemained);
            Controls.Add(labelBadAnswerCount);
            Controls.Add(labelGoodAnswersCount);
            Controls.Add(pictureBoxQuestion);
            Controls.Add(labelQuestion);
            Controls.Add(checkBoxAnswer2);
            Controls.Add(checkBoxAnswer3);
            Controls.Add(checkBoxAnswer1);
            Name = "QuizControl";
            Size = new Size(1000, 600);
            ((System.ComponentModel.ISupportInitialize)pictureBoxQuestion).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private CheckBox checkBoxAnswer1;
        private CheckBox checkBoxAnswer3;
        private CheckBox checkBoxAnswer2;
        private Label labelQuestion;
        private PictureBox pictureBoxQuestion;
        private Label labelGoodAnswersCount;
        private Label labelBadAnswerCount;
        private Label labelTimeRemained;
        private Button buttonNext;
        private Button buttonHelp;
        private Button buttonAbort;
    }
}
