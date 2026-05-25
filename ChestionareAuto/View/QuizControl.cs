using Entities;
using Patterns;
using Repositories;
using Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace View
{
    public partial class QuizControl : UserControl
    {
        private Quiz _currentQuiz;
        private ResultRepository _resultRepository = ResultRepository.Instance();
        private bool _isEvaluated = false;
        public QuizControl()
        {
            InitializeComponent();
        }

        private void QuizControl_Load(object sender, EventArgs e)
        {
            _currentQuiz = QuizManager.Instance.ActiveQuiz;
            if (_currentQuiz.Strategy.HasTimeLimit())
            {
                timerQuiz.Start();
                labelTimeRemained.Visible = true;
            }
            else
            {
                labelTimeRemained.Visible = false;
                timerQuiz.Stop();
            }
            CurrentQuestion();
        }

        private void CurrentQuestion()
        {
            Question question = _currentQuiz.GetCurrentQuestion();

            if (question != null)
            {
                labelQuestion.Text = question.Text;

                checkBoxAnswer1.Text = question.Options[0];
                checkBoxAnswer2.Text = question.Options[1];
                checkBoxAnswer3.Text = question.Options[2];

                checkBoxAnswer1.Checked = false;
                checkBoxAnswer2.Checked = false;
                checkBoxAnswer3.Checked = false;

                checkBoxAnswer1.ForeColor = SystemColors.ControlText;
                checkBoxAnswer2.ForeColor = SystemColors.ControlText;
                checkBoxAnswer3.ForeColor = SystemColors.ControlText;
                _isEvaluated = false;

                if (!string.IsNullOrEmpty(question.Image))
                {
                    string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "images", question.Image);

                    if (File.Exists(path))
                    {
                        pictureBoxQuestion.Image = Image.FromFile(path);
                        pictureBoxQuestion.Visible = true;
                    }
                    else
                    {
                        pictureBoxQuestion.Visible = false;
                    }
                }
                else
                {
                    pictureBoxQuestion.Visible = false;
                }
            }

            labelGoodAnswersCount.Text = $"Răspunsuri corecte: {_currentQuiz.Score}";
            labelBadAnswersCount.Text = $"Răspunsuri greșite: {_currentQuiz.Mistakes}";
        }
        private void checkBoxAnswer2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void timerQuiz_Tick(object sender, EventArgs e)
        {
            if (_currentQuiz.TimeRemained.TotalSeconds > 0)
            {
                _currentQuiz.TimeRemained = _currentQuiz.TimeRemained.Subtract(TimeSpan.FromSeconds(1));
                labelTimeRemained.Text = string.Format("{0:D2}:{1:D2}", _currentQuiz.TimeRemained.Minutes, _currentQuiz.TimeRemained.Seconds);

                if (_currentQuiz.TimeRemained.TotalSeconds < 180)
                    labelTimeRemained.ForeColor = Color.Red;
            }
            else
            {
                timerQuiz.Stop();
                if (_currentQuiz.IsPassed())
                {
                    ExitFromQuiz(StareTest.Admis);
                }
                else
                {
                    ExitFromQuiz(StareTest.Respins);
                }
            }
        }

        private void ExitFromQuiz(StareTest state)
        {
            var currentUser = QuizManager.Instance.CurrentUser;

            QuizMemento memento = (state == StareTest.Nefinalizat) ? _currentQuiz.SaveState() : null;

            if (QuizManager.Instance.ActiveResultId == 0)
            {
                TestResult finalResult = new TestResult(0, currentUser.Id, DateTime.Now,
                                            _currentQuiz.Score, (_currentQuiz.Strategy is ExamenStrategy) ? TipSesiune.Examen : TipSesiune.Invatare,
                                            state, memento);
                _resultRepository.Add(finalResult);
            }
            else
            {
                TestResult updatedResult = new TestResult(QuizManager.Instance.ActiveResultId, currentUser.Id, DateTime.Now,
                                            _currentQuiz.Score, (_currentQuiz.Strategy is ExamenStrategy) ? TipSesiune.Examen : TipSesiune.Invatare,
                                            state, memento);
                _resultRepository.Update(updatedResult);
            }
            var mainForm = (MainForm)this.ParentForm;
            if (mainForm != null)
            {
                mainForm.SwitchWindow(new DashboardUserControl());
            }
        }
        private void buttonNext_Click(object sender, EventArgs e)
        {
            Question currentQuestion = _currentQuiz.GetCurrentQuestion();
            List<int> correctAnswers = currentQuestion.CorrectOptionsIndex;

            bool showFeedback = _currentQuiz.Strategy.ShowImmediateFeedback();

            if (showFeedback && !_isEvaluated)
            {
                List<int> userAnswersTemp = new List<int>();
                if (checkBoxAnswer1.Checked) userAnswersTemp.Add(0);
                if (checkBoxAnswer2.Checked) userAnswersTemp.Add(1);
                if (checkBoxAnswer3.Checked) userAnswersTemp.Add(2);

                bool isCorrectTemp = (userAnswersTemp.Count == correctAnswers.Count) && (!userAnswersTemp.Except(correctAnswers).Any());

                if (isCorrectTemp)
                    _currentQuiz.IncreaseScore();
                else
                    _currentQuiz.IncreaseMistakes();

                labelGoodAnswersCount.Text = $"Răspunsuri corecte: {_currentQuiz.Score}";
                labelBadAnswersCount.Text = $"Răspunsuri greșite: {_currentQuiz.Mistakes}";

                if (correctAnswers.Contains(0))
                    checkBoxAnswer1.ForeColor = Color.Green;
                else if (checkBoxAnswer1.Checked)
                    checkBoxAnswer1.ForeColor = Color.Red;

                if (correctAnswers.Contains(1))
                    checkBoxAnswer2.ForeColor = Color.Green;
                else if (checkBoxAnswer2.Checked)
                    checkBoxAnswer2.ForeColor = Color.Red;

                if (correctAnswers.Contains(2))
                    checkBoxAnswer3.ForeColor = Color.Green;
                else if (checkBoxAnswer3.Checked)
                    checkBoxAnswer3.ForeColor = Color.Red;

                _isEvaluated = true;
                return;
            }

            if (!showFeedback)
            {
                List<int> examAnswers = new List<int>();
                if (checkBoxAnswer1.Checked) examAnswers.Add(0);
                if (checkBoxAnswer2.Checked) examAnswers.Add(1);
                if (checkBoxAnswer3.Checked) examAnswers.Add(2);

                bool examCorrect = (examAnswers.Count == correctAnswers.Count) && (!examAnswers.Except(correctAnswers).Any());

                if (examCorrect) _currentQuiz.IncreaseScore();
                else _currentQuiz.IncreaseMistakes();
            }

            if (!_currentQuiz.CanContinue())
            {
                timerQuiz.Stop();
                MessageBox.Show("Ai depășit limita de greșeli! Test picat.", "Examen Încheiat");
                ExitFromQuiz(StareTest.Respins);
                return;
            }

            if (_currentQuiz.HasNextQuestion())
            {
                _currentQuiz.MoveToNextQuestion();
                CurrentQuestion();
            }
            else
            {
                timerQuiz.Stop();
                if (_currentQuiz.IsPassed())
                {
                    MessageBox.Show("Felicitări! Ai terminat chestionarul!", "Finalizat");
                    ExitFromQuiz(StareTest.Admis);
                }
                else
                {
                    MessageBox.Show("Ai terminat testul, dar nu ai obținut punctajul minim.", "Finalizat");
                    ExitFromQuiz(StareTest.Respins);
                }
            }
        }

        private void buttonAbort_Click(object sender, EventArgs e)
        {
            if (_currentQuiz.Strategy.HasTimeLimit())
            {
                timerQuiz.Stop();
            }
            var dialog = MessageBox.Show(
                "Ești sigur că vrei să întrerupi testul? Progresul tău va fi salvat și vei putea continua mai târziu de unde ai rămas.",
                "Întrerupere Test",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (dialog == DialogResult.Yes)
            {
                ExitFromQuiz(StareTest.Nefinalizat);
            }
            else
            {
                if (_currentQuiz.Strategy.HasTimeLimit())
                {
                    timerQuiz.Start();
                }
            }
        }

        private void buttonHelp_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "help", "ChestionareAuto.chm"));
        }
    }
}
