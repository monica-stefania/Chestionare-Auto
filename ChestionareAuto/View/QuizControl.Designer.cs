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
            components = new System.ComponentModel.Container();
            checkBoxAnswer1 = new CheckBox();
            checkBoxAnswer3 = new CheckBox();
            checkBoxAnswer2 = new CheckBox();
            labelQuestion = new Label();
            pictureBoxQuestion = new PictureBox();
            labelGoodAnswersCount = new Label();
            labelBadAnswersCount = new Label();
            labelTimeRemained = new Label();
            buttonNext = new Button();
            buttonHelp = new Button();
            buttonAbort = new Button();
            timerQuiz = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)pictureBoxQuestion).BeginInit();
            SuspendLayout();
            // 
            // checkBoxAnswer1
            // 
            checkBoxAnswer1.Anchor = AnchorStyles.None;
            checkBoxAnswer1.Font = new Font("Segoe UI", 12F);
            checkBoxAnswer1.Location = new Point(90, 447);
            checkBoxAnswer1.Name = "checkBoxAnswer1";
            checkBoxAnswer1.Size = new Size(750, 60);
            checkBoxAnswer1.TabIndex = 0;
            checkBoxAnswer1.Text = "raspuns_1";
            checkBoxAnswer1.UseVisualStyleBackColor = true;
            // 
            // checkBoxAnswer3
            // 
            checkBoxAnswer3.Anchor = AnchorStyles.None;
            checkBoxAnswer3.Font = new Font("Segoe UI", 12F);
            checkBoxAnswer3.Location = new Point(90, 586);
            checkBoxAnswer3.Name = "checkBoxAnswer3";
            checkBoxAnswer3.Size = new Size(750, 60);
            checkBoxAnswer3.TabIndex = 1;
            checkBoxAnswer3.Text = "raspuns_3";
            checkBoxAnswer3.UseVisualStyleBackColor = true;
            // 
            // checkBoxAnswer2
            // 
            checkBoxAnswer2.Anchor = AnchorStyles.None;
            checkBoxAnswer2.Font = new Font("Segoe UI", 12F);
            checkBoxAnswer2.Location = new Point(90, 515);
            checkBoxAnswer2.Name = "checkBoxAnswer2";
            checkBoxAnswer2.Size = new Size(750, 60);
            checkBoxAnswer2.TabIndex = 2;
            checkBoxAnswer2.Text = "raspuns_2";
            checkBoxAnswer2.UseVisualStyleBackColor = true;
            // 
            // labelQuestion
            // 
            labelQuestion.Anchor = AnchorStyles.None;
            labelQuestion.AutoSize = true;
            labelQuestion.Font = new Font("Segoe UI", 14F);
            labelQuestion.Location = new Point(73, 402);
            labelQuestion.MaximumSize = new Size(1000, 0);
            labelQuestion.Name = "labelQuestion";
            labelQuestion.Size = new Size(326, 32);
            labelQuestion.TabIndex = 3;
            labelQuestion.Text = "Aici va fi introdusa intrebarea";
            // 
            // pictureBoxQuestion
            // 
            pictureBoxQuestion.Anchor = AnchorStyles.None;
            pictureBoxQuestion.Location = new Point(73, 84);
            pictureBoxQuestion.Name = "pictureBoxQuestion";
            pictureBoxQuestion.Size = new Size(794, 306);
            pictureBoxQuestion.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxQuestion.TabIndex = 4;
            pictureBoxQuestion.TabStop = false;
            // 
            // labelGoodAnswersCount
            // 
            labelGoodAnswersCount.Anchor = AnchorStyles.None;
            labelGoodAnswersCount.Font = new Font("Segoe UI", 13F);
            labelGoodAnswersCount.ForeColor = Color.FromArgb(0, 192, 0);
            labelGoodAnswersCount.Location = new Point(73, 34);
            labelGoodAnswersCount.Name = "labelGoodAnswersCount";
            labelGoodAnswersCount.Size = new Size(280, 35);
            labelGoodAnswersCount.TabIndex = 5;
            labelGoodAnswersCount.Text = "Raspunsuri corecte:";
            // 
            // labelBadAnswersCount
            // 
            labelBadAnswersCount.Anchor = AnchorStyles.None;
            labelBadAnswersCount.Font = new Font("Segoe UI", 13F);
            labelBadAnswersCount.ForeColor = Color.Red;
            labelBadAnswersCount.Location = new Point(415, 34);
            labelBadAnswersCount.Name = "labelBadAnswersCount";
            labelBadAnswersCount.Size = new Size(280, 35);
            labelBadAnswersCount.TabIndex = 6;
            labelBadAnswersCount.Text = "Raspunsuri gresite:";
            // 
            // labelTimeRemained
            // 
            labelTimeRemained.Anchor = AnchorStyles.None;
            labelTimeRemained.Font = new Font("Segoe UI", 13F);
            labelTimeRemained.ForeColor = Color.Black;
            labelTimeRemained.Location = new Point(833, 34);
            labelTimeRemained.Name = "labelTimeRemained";
            labelTimeRemained.Size = new Size(141, 35);
            labelTimeRemained.TabIndex = 7;
            labelTimeRemained.Text = "Timp ramas:";
            // 
            // buttonNext
            // 
            buttonNext.Anchor = AnchorStyles.None;
            buttonNext.Cursor = Cursors.Hand;
            buttonNext.Font = new Font("Segoe UI", 12F);
            buttonNext.Location = new Point(1008, 402);
            buttonNext.Name = "buttonNext";
            buttonNext.Size = new Size(160, 40);
            buttonNext.TabIndex = 8;
            buttonNext.Text = "Next";
            buttonNext.UseVisualStyleBackColor = true;
            buttonNext.Click += buttonNext_Click;
            // 
            // buttonHelp
            // 
            buttonHelp.Anchor = AnchorStyles.None;
            buttonHelp.Cursor = Cursors.Hand;
            buttonHelp.Font = new Font("Segoe UI", 12F);
            buttonHelp.Location = new Point(1008, 586);
            buttonHelp.Name = "buttonHelp";
            buttonHelp.Size = new Size(160, 40);
            buttonHelp.TabIndex = 9;
            buttonHelp.Text = "Help";
            buttonHelp.UseVisualStyleBackColor = true;
            buttonHelp.Click += buttonHelp_Click;
            // 
            // buttonAbort
            // 
            buttonAbort.Anchor = AnchorStyles.None;
            buttonAbort.Cursor = Cursors.Hand;
            buttonAbort.Font = new Font("Segoe UI", 12F);
            buttonAbort.Location = new Point(1008, 643);
            buttonAbort.Name = "buttonAbort";
            buttonAbort.Size = new Size(160, 40);
            buttonAbort.TabIndex = 10;
            buttonAbort.Text = "Abort ";
            buttonAbort.UseVisualStyleBackColor = true;
            buttonAbort.Click += buttonAbort_Click;
            // 
            // timerQuiz
            // 
            timerQuiz.Interval = 1000;
            timerQuiz.Tick += timerQuiz_Tick;
            // 
            // QuizControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Azure;
            Controls.Add(buttonAbort);
            Controls.Add(buttonHelp);
            Controls.Add(buttonNext);
            Controls.Add(labelTimeRemained);
            Controls.Add(labelBadAnswersCount);
            Controls.Add(labelGoodAnswersCount);
            Controls.Add(pictureBoxQuestion);
            Controls.Add(labelQuestion);
            Controls.Add(checkBoxAnswer2);
            Controls.Add(checkBoxAnswer3);
            Controls.Add(checkBoxAnswer1);
            Name = "QuizControl";
            Size = new Size(1200, 700);
            Load += QuizControl_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBoxQuestion).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckBox checkBoxAnswer1;
        private CheckBox checkBoxAnswer3;
        private CheckBox checkBoxAnswer2;
        private Label labelQuestion;
        private PictureBox pictureBoxQuestion;
        private Label labelGoodAnswersCount;
        private Label labelBadAnswersCount;
        private Label labelTimeRemained;
        private Button buttonNext;
        private Button buttonHelp;
        private Button buttonAbort;
        private System.Windows.Forms.Timer timerQuiz;
    }
}
