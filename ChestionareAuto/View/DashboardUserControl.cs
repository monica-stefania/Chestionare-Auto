using Entities;
using Model;
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
    public partial class DashboardUserControl : UserControl
    {
        private ResultRepository _resultRepository = new ResultRepository();
        public DashboardUserControl()
        {
            InitializeComponent();
        }

        private void DashboardUserControl_Load(object sender, EventArgs e)
        {
            labelWelcome.Text = $"Bine ai venit, {QuizManager.Instance.CurrentUser.Name}!\nEști pregătit pentru un nou chestionar?";
            LoadHistory();
        }

        private void LoadHistory()
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

                if (res.State == StareTest.Admis)
                    dataGridViewHistory.Rows[rowIndex].Cells[3].Style.ForeColor = Color.Green;
                else if (res.State == StareTest.Respins)
                    dataGridViewHistory.Rows[rowIndex].Cells[3].Style.ForeColor = Color.Red;
                else
                    dataGridViewHistory.Rows[rowIndex].Cells[3].Style.ForeColor = Color.Orange;

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
        private void buttonLogOut_Click(object sender, EventArgs e)
        {
            QuizManager.Instance.CurrentUser = null;
            var mainForm = (MainForm)this.ParentForm;
            if (mainForm != null)
            {
                mainForm.SwitchWindow(new LoginUserControl());
            }
        }

        private void buttonHelp_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "help", "ChestionareAuto.chm"));
        }

        private void buttonStartExamen_Click(object sender, EventArgs e)
        {
            QuizManager.Instance.ActiveResultId = 0;

            var questionRepository = new QuestionRepository();
            List<Question> questionList = questionRepository.GenereazaTestExamen();

            Quiz newQuiz = new Quiz(new ExamenStrategy(), questionList, TipSesiune.Examen);
            QuizManager.Instance.ActiveQuiz = newQuiz;

            var mainForm = (MainForm)this.ParentForm;
            if (mainForm != null)
            {
                mainForm.SwitchWindow(new QuizControl());
            }
        }

        private void buttonStartInvatare_Click(object sender, EventArgs e)
        {
            QuizManager.Instance.ActiveResultId = 0;

            var questionRepository = new QuestionRepository();
            List<Question> questionList = questionRepository.GenereazaTestExamen();

            Quiz newQuiz = new Quiz(new PracticeStrategy(), questionList, TipSesiune.Invatare);
            QuizManager.Instance.ActiveQuiz = newQuiz;

            var mainForm = (MainForm)this.ParentForm;
            if (mainForm != null)
            {
                mainForm.SwitchWindow(new QuizControl());
            }
        }

        private void dataGridViewHistory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridViewHistory.Columns[e.ColumnIndex].Name == "colReluare")
            {
                if (dataGridViewHistory.Rows[e.RowIndex].IsNewRow) return;

                TestResult result = (TestResult)dataGridViewHistory.Rows[e.RowIndex].Tag;

                if (result != null)
                {
                    if (result.State == StareTest.Nefinalizat && result.DateSalvate != null)
                    {
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
        }
    }
}
