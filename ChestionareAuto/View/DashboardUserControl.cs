using Entities;
using Logic;
using Patterns;
using Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace View
{
    /// <summary>
    /// Dashboard-ul utilizatorului normal.
    /// </summary>
    public partial class DashboardUserControl : UserControl
    {
        private ResultRepository _resultRepository = ResultRepository.Instance();

        /// <summary>
        /// Inițializează controlul dashboard-ului.
        /// </summary>
        public DashboardUserControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// La încărcarea controlului afișează mesajul de bun venit
        /// și încarcă istoricul testelor utilizatorului curent.
        /// </summary>
        private void DashboardUserControl_Load(object sender, EventArgs e)
        {
            labelWelcome.Text = $"Bine ai venit, {QuizManager.Instance.CurrentUser.Name}!\nEști pregătit pentru un nou chestionar?";
            LoadHistory();
        }

        /// <summary>
        /// Încarcă și afișează istoricul testelor utilizatorului curent în grid,
        /// ordonate descrescător după dată.
        /// </summary>
        private void LoadHistory()
        {
            try
            {
                dataGridViewHistory.Rows.Clear();

                var allResults = _resultRepository.GetAll();
                var userResults = allResults.Where(r => r.UserId == QuizManager.Instance.CurrentUser.Id).OrderByDescending(r => r.Date).ToList();

                foreach (var res in userResults)
                {
                    string stareText = res.State.ToString();

                    int rowIndex = dataGridViewHistory.Rows.Add(
                        res.Date.ToString("dd.MM.yyyy HH:mm"),
                        res.SessionType.ToString(),
                        $"{res.Score} / 26",
                        stareText
                    );

                    dataGridViewHistory.Rows[rowIndex].Tag = res;

                    // Colorăm celula de stare în funcție de rezultat
                    if (res.State == StareTest.Admis)
                        dataGridViewHistory.Rows[rowIndex].Cells[3].Style.ForeColor = Color.Green;
                    else if (res.State == StareTest.Respins)
                        dataGridViewHistory.Rows[rowIndex].Cells[3].Style.ForeColor = Color.Red;
                    else
                        dataGridViewHistory.Rows[rowIndex].Cells[3].Style.ForeColor = Color.Orange;

                    // Afișăm butonul de "Reluare" doar pentru teste nefinalizate
                    if (res.State != StareTest.Nefinalizat)
                    {
                        var cellButon = new DataGridViewTextBoxCell();
                        cellButon.Value = "-";
                        dataGridViewHistory.Rows[rowIndex].Cells[4] = cellButon;
                    }
                    else
                    {
                        dataGridViewHistory.Rows[rowIndex].Cells[4].Value = "Reluare";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la încărcarea istoricului: {ex.Message}");
            }
        }

        /// <summary>
        /// Delogează utilizatorul curent, resetează QuizManager și navighează la Login.
        /// </summary>
        private void buttonLogOut_Click(object sender, EventArgs e)
        {
            try
            {
                QuizManager.Instance.CurrentUser = null;
                var mainForm = (MainForm)this.ParentForm;
                if (mainForm != null)
                {
                    mainForm.SwitchWindow(new LoginUserControl());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la delogare: {ex.Message}");
            }
        }

        /// <summary>
        /// Deschide fișierul de help al aplicației (.chm).
        /// </summary>
        private void buttonHelp_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "help", "ChestionareAuto.chm"));
        }

        /// <summary>
        /// Pornește un test nou de tip Examen.
        /// </summary>
        private void buttonStartExamen_Click(object sender, EventArgs e)
        {
            try
            {
                QuizManager.Instance.ActiveResultId = 0;

                var questionRepository = QuestionRepository.Instance();
                List<Question> questionList = questionRepository.GenereazaTestExamen();

                if (questionList.Count == 0)
                {
                    MessageBox.Show("Nu există întrebări disponibile pentru examen. Contactați administratorul.");
                    return;
                }

                Quiz newQuiz = new Quiz(new ExamenStrategy(), questionList, TipSesiune.Examen);
                QuizManager.Instance.ActiveQuiz = newQuiz;

                var mainForm = (MainForm)this.ParentForm;
                if (mainForm != null)
                {
                    mainForm.SwitchWindow(new QuizControl());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la pornirea examenului: {ex.Message}");
            }
        }

        /// <summary>
        /// Pornește o sesiune nouă de tip Învățare.
        /// </summary>
        private void buttonStartInvatare_Click(object sender, EventArgs e)
        {
            try
            {
                QuizManager.Instance.ActiveResultId = 0;

                var questionRepository = QuestionRepository.Instance();
                List<Question> questionList = questionRepository.GenereazaTestExamen();

                if (questionList.Count == 0)
                {
                    MessageBox.Show("Nu există întrebări disponibile pentru examen. Contactați administratorul.");
                    return;
                }

                Quiz newQuiz = new Quiz(new PracticeStrategy(), questionList, TipSesiune.Invatare);
                QuizManager.Instance.ActiveQuiz = newQuiz;

                var mainForm = (MainForm)this.ParentForm;
                if (mainForm != null)
                {
                    mainForm.SwitchWindow(new QuizControl());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la pornirea sesiunii de învățare: {ex.Message}");
            }
        }


        /// <summary>
        /// Gestionează click-ul pe celulele din grid-ul de istoric.
        /// </summary>
        private void dataGridViewHistory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && dataGridViewHistory.Columns[e.ColumnIndex].Name == "colReluare")
                {
                    if (dataGridViewHistory.Rows[e.RowIndex].IsNewRow) return;

                    TestResult result = (TestResult)dataGridViewHistory.Rows[e.RowIndex].Tag;

                    // dacă se apasă pe butonul de "Reluare"
                    if (result != null && result.State == StareTest.Nefinalizat && result.DateSalvate != null)
                    {
                        // Restaurăm starea salvată prin Memento
                        QuizManager.Instance.ActiveResultId = result.Id;
                        Quiz quizRestore = new Quiz(result.DateSalvate);
                        QuizManager.Instance.ActiveQuiz = quizRestore;

                        var mainForm = (MainForm)this.ParentForm;
                        if (mainForm != null)
                        {
                            mainForm.SwitchWindow(new QuizControl());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la reluarea testului: {ex.Message}");
            }
        }

    }
}
