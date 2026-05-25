using Entities;
using Patterns;
using Repositories;
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
    /// <summary>
    /// Control de interfață pentru desfășurarea unui chestionar activ.
    /// </summary>
    public partial class QuizControl : UserControl
    {
        private Quiz _currentQuiz;
        private ResultRepository _resultRepository = ResultRepository.Instance();
        private bool _isEvaluated = false;

        /// <summary>
        /// Inițializează controlul de quiz.
        /// </summary>
        public QuizControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// La încărcarea controlului preia chestionarul activ din QuizManager,
        /// </summary>
        private void QuizControl_Load(object sender, EventArgs e)
        {
            try
            {
                _currentQuiz = QuizManager.Instance.ActiveQuiz;

                if (_currentQuiz == null)
                {
                    throw new InvalidOperationException("Nu există un chestionar activ.");
                }

                // Pornim timer-ul doar pentru sesiunile cu limită de timp (Examen)
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
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la încărcarea chestionarului: {ex.Message}");
            }
        }

        /// <summary>
        /// Afișează întrebarea curentă: textul, cele 3 opțiuni de răspuns,
        /// imaginea asociată (dacă există) și resetează starea checkbox-urilor.
        /// </summary>
        private void CurrentQuestion()
        {
            try
            {
                Question question = _currentQuiz.GetCurrentQuestion();

                if (question != null)
                {
                    labelQuestion.Text = question.Text;

                    checkBoxAnswer1.Text = question.Options[0];
                    checkBoxAnswer2.Text = question.Options[1];
                    checkBoxAnswer3.Text = question.Options[2];

                    // Resetăm starea checkbox-urilor
                    checkBoxAnswer1.Checked = false;
                    checkBoxAnswer2.Checked = false;
                    checkBoxAnswer3.Checked = false;

                    checkBoxAnswer1.ForeColor = SystemColors.ControlText;
                    checkBoxAnswer2.ForeColor = SystemColors.ControlText;
                    checkBoxAnswer3.ForeColor = SystemColors.ControlText;
                    _isEvaluated = false;

                    // Afișăm imaginea asociată întrebării dacă există
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
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la afișarea întrebării: {ex.Message}");
            }
        }

        /// <summary>
        /// Gestionează tick-ul timer-ului (se execută la fiecare secundă).
        /// </summary>
        private void timerQuiz_Tick(object sender, EventArgs e)
        {
            try
            {
                if (_currentQuiz.TimeRemained.TotalSeconds > 0)
                {
                    _currentQuiz.TimeRemained = _currentQuiz.TimeRemained.Subtract(TimeSpan.FromSeconds(1));
                    labelTimeRemained.Text = string.Format("{0:D2}:{1:D2}", _currentQuiz.TimeRemained.Minutes, _currentQuiz.TimeRemained.Seconds);

                    // Avertizare vizuală când rămân mai puțin de 3 minute
                    if (_currentQuiz.TimeRemained.TotalSeconds < 180)
                        labelTimeRemained.ForeColor = Color.Red;
                }
                else
                {
                    // Timpul a expirat — finalizăm testul
                    timerQuiz.Stop();
                    ExitFromQuiz(_currentQuiz.IsPassed() ? StareTest.Admis : StareTest.Respins);
                    new ResultsForm(_currentQuiz.Score, _currentQuiz.Mistakes, _currentQuiz.IsPassed()).ShowDialog();
                }
            }
            catch (Exception ex)
            {
                timerQuiz.Stop();
                Console.WriteLine($"Eroare timer: {ex.Message}");
            }
        }

        /// <summary>
        /// Finalizează sesiunea curentă, salvează sau actualizează rezultatul în repository
        /// și navighează înapoi la dashboard-ul utilizatorului.
        /// </summary>
        /// <param name="state">Starea finală a testului (Admis, Respins sau Nefinalizat).</param>
        private void ExitFromQuiz(StareTest state)
        {
            try
            {
                var currentUser = QuizManager.Instance.CurrentUser;

                if (currentUser == null)
                {
                    throw new InvalidOperationException("Nu există un utilizator autentificat.");
                }

                // Salvăm starea Memento doar dacă testul este nefinalizat
                QuizMemento memento = (state == StareTest.Nefinalizat) ? _currentQuiz.SaveState() : null;

                if (QuizManager.Instance.ActiveResultId == 0)
                {
                    // Test nou — adăugăm un rezultat nou în repository
                    TestResult finalResult = new TestResult(0, currentUser.Id, DateTime.Now,
                                                _currentQuiz.Score, (_currentQuiz.Strategy is ExamenStrategy) ? TipSesiune.Examen : TipSesiune.Invatare,
                                                state, memento);
                    _resultRepository.Add(finalResult);
                }
                else
                {
                    // Test reluat — actualizăm rezultatul existent
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
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la salvarea rezultatului: {ex.Message}");
            }
        }

        /// <summary>
        /// Gestionează apăsarea butonului "Următoarea întrebare" / "Verifică".
        /// </summary>
        private void buttonNext_Click(object sender, EventArgs e)
        {
            try
            {
                Question currentQuestion = _currentQuiz.GetCurrentQuestion();
                List<int> correctAnswers = currentQuestion.CorrectOptionsIndex;

                bool showFeedback = _currentQuiz.Strategy.ShowImmediateFeedback();

                if (showFeedback && !_isEvaluated)
                {
                    // în modul învățare, după ce apăsăm pentru prima oară butonul next,
                    // trebuie să colorăm răspunsurile corecte și greșite
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

                    // Colorăm variantele: verde = corect, roșu = greșit
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
                    return; // A doua apăsare va avansa la întrebarea următoare
                }

                if (!showFeedback)
                {
                    //în modul examen nu trebuie arătat răspunsurile corecte/greșite
                    List<int> examAnswers = new List<int>();
                    if (checkBoxAnswer1.Checked) examAnswers.Add(0);
                    if (checkBoxAnswer2.Checked) examAnswers.Add(1);
                    if (checkBoxAnswer3.Checked) examAnswers.Add(2);

                    bool examCorrect = (examAnswers.Count == correctAnswers.Count) && (!examAnswers.Except(correctAnswers).Any());

                    if (examCorrect) _currentQuiz.IncreaseScore();
                    else _currentQuiz.IncreaseMistakes();
                }

                // Verificăm dacă s-a atins limita de greșeli
                if (!_currentQuiz.CanContinue())
                {
                    timerQuiz.Stop();
                    ExitFromQuiz(StareTest.Respins);
                    new ResultsForm(_currentQuiz.Score, _currentQuiz.Mistakes, false).ShowDialog();
                    return;
                }

                // Avansăm la întrebarea următoare sau finalizăm testul
                if (_currentQuiz.HasNextQuestion())
                {
                    _currentQuiz.MoveToNextQuestion();
                    CurrentQuestion();
                }
                else
                {
                    timerQuiz.Stop();
                    StareTest stare = _currentQuiz.IsPassed() ? StareTest.Admis : StareTest.Respins;
                    ExitFromQuiz(stare);
                    new ResultsForm(_currentQuiz.Score, _currentQuiz.Mistakes, _currentQuiz.IsPassed()).ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la procesarea răspunsului: {ex.Message}");
            }
        }

        /// <summary>
        /// Gestionează apăsarea butonului "Abandonează".
        /// </summary>
        private void buttonAbort_Click(object sender, EventArgs e)
        {
            try
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
                    // Salvăm starea prin Memento și ieșim
                    ExitFromQuiz(StareTest.Nefinalizat);
                }
                else
                {
                    // Utilizatorul a anulat — repornești timer-ul dacă era activ
                    if (_currentQuiz.Strategy.HasTimeLimit())
                    {
                        timerQuiz.Start();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la întreruperea testului: {ex.Message}");
            }
        }

        /// <summary>
        /// Deschide fișierul de help al aplicației.
        /// </summary>
        private void buttonHelp_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "help", "ChestionareAuto.chm"));
        }
    }
}
