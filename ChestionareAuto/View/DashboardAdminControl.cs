using Entities;
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
    /// Dashboard-ul administratorului.
    /// </summary>
    public partial class DashboardAdminControl : UserControl
    {
        private QuestionRepository _questionRepository = QuestionRepository.Instance();
        private UserRepository _userRepository = UserRepository.Instance();
        private int _currentEditingQuestionId = 0;

        /// <summary>
        /// Inițializează controlul dashboard-ului de admin.
        /// </summary>
        public DashboardAdminControl()
        {
            InitializeComponent();
        }

        private void DashboardAdminControl_Load(object sender, EventArgs e)
        {
            try
            {
                LoadQuestions();
                LoadUsers();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la încărcarea datelor: {ex.Message}");
            }
        }

        private void LoadQuestions()
        {
            try
            {
                var questions = _questionRepository.GetAll();

                dataGridViewQuestions.DataSource = null;
                dataGridViewQuestions.DataSource = questions;

                if (!dataGridViewQuestions.Columns.Contains("Options"))
                {
                    DataGridViewTextBoxColumn c1 = new DataGridViewTextBoxColumn();
                    c1.Name = "Options";
                    c1.HeaderText = "Variante Răspuns";
                    c1.DataPropertyName = "Options"; // Face legătura cu proprietatea din clasa Question
                    dataGridViewQuestions.Columns.Add(c1);
                }

                if (!dataGridViewQuestions.Columns.Contains("CorrectOptionsIndex"))
                {
                    DataGridViewTextBoxColumn c2 = new DataGridViewTextBoxColumn();
                    c2.Name = "CorrectOptionsIndex";
                    c2.HeaderText = "Răspuns Corect";
                    c2.DataPropertyName = "CorrectOptionsIndex"; // Legătura cu proprietatea din C#
                    dataGridViewQuestions.Columns.Add(c2);
                }

                if (dataGridViewQuestions.Columns["Image"] != null)
                {
                    dataGridViewQuestions.Columns["Image"].Visible = false;
                }

                if (dataGridViewQuestions.Columns["Category"] != null)
                {
                    dataGridViewQuestions.Columns["Category"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la încărcarea întrebărilor: {ex.Message}");
            }
        }
        private void LoadUsers()
        {
            try
            {
                var users = _userRepository.GetAll();

                dataGridViewUsers.DataSource = null;
                dataGridViewUsers.DataSource = users;

                if (dataGridViewUsers.Columns["Password"] != null)
                    dataGridViewUsers.Columns["Password"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la încărcarea utilizatorilor: {ex.Message}");
            }
        }

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

        private void buttonDeleteQuestion_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewQuestions.SelectedRows.Count > 0)
                {
                    Question selectedQuestion = (Question)dataGridViewQuestions.SelectedRows[0].DataBoundItem;

                    var dialog = MessageBox.Show($"Ești sigur că vrei să ștergi întrebarea:\n\"{selectedQuestion.Text}\"?",
                                                 "Confirmare Ștergere", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dialog == DialogResult.Yes)
                    {
                        _questionRepository.Delete(selectedQuestion);

                        MessageBox.Show("Întrebare ștearsă cu succes!");
                        LoadQuestions();
                    }
                }
                else
                {
                    MessageBox.Show("Te rog să selectezi o întrebare din tabel pentru a o șterge.", "Atenție");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la ștergerea întrebării: {ex.Message}");
            }
        }

        private void buttonRemoveUser_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewUsers.SelectedRows.Count > 0)
                {
                    User selectedUser = (User)dataGridViewUsers.SelectedRows[0].DataBoundItem;

                    // Protecție: adminul nu își poate șterge propriul cont
                    if (selectedUser.Id == QuizManager.Instance.CurrentUser.Id)
                    {
                        MessageBox.Show("Nu îți poți șterge propriul cont!", "Acces Interzis", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    var dialog = MessageBox.Show($"Ești sigur că vrei să ștergi definitiv utilizatorul {selectedUser.Name}?",
                                                 "Confirmare Ștergere", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                    if (dialog == DialogResult.Yes)
                    {
                        _userRepository.Delete(selectedUser);

                        MessageBox.Show("Utilizatorul a fost șters.");
                        LoadUsers();
                    }
                    else
                    {
                        MessageBox.Show("Te rog să selectezi un utilizator din tabel pentru a-l șterge.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la ștergerea utilizatorului: {ex.Message}");
            }
        }

        private void buttonChangeRoleUser_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewUsers.SelectedRows.Count > 0)
                {
                    User selectedUser = (User)dataGridViewUsers.SelectedRows[0].DataBoundItem;

                    // Protecție: adminul nu își poate schimba propriul rol
                    if (selectedUser.Id == QuizManager.Instance.CurrentUser.Id)
                    {
                        MessageBox.Show("Nu îți poți schimba propriul rol!", "Acces Interzis", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Dacă userul selectat avea rolul Admin, rolul va fi schimbat în Utilizator și invers
                    if (selectedUser.Role == UserRole.Admin)
                        selectedUser.Role = UserRole.Utilizator;
                    else
                        selectedUser.Role = UserRole.Admin;

                    _userRepository.Update(selectedUser);

                    MessageBox.Show($"Rolul utilizatorului {selectedUser.Name} a fost modificat în {selectedUser.Role}.");
                    LoadUsers();
                }
                else
                {
                    MessageBox.Show("Te rog să selectezi un utilizator din tabel pentru a-i schimba rolul.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la schimbarea rolului: {ex.Message}");
            }
        }

        private void dataGridViewQuestions_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (e.ColumnIndex < 0 || e.ColumnIndex >= dataGridViewQuestions.Columns.Count) return;

                string propertyName = dataGridViewQuestions.Columns[e.ColumnIndex].DataPropertyName;

                if (propertyName == "Options" && e.Value is List<string> optiuni)
                {
                    if (optiuni.Count >= 3)
                    {
                        e.Value = $"A) {optiuni[0]}\nB) {optiuni[1]}\nC) {optiuni[2]}";
                        e.FormattingApplied = true;
                    }
                }

                if (propertyName == "CorrectOptionsIndex" && e.Value is List<int> corecte)
                {
                    List<string> litereCorecte = new List<string>();
                    if (corecte.Contains(0)) litereCorecte.Add("A");
                    if (corecte.Contains(1)) litereCorecte.Add("B");
                    if (corecte.Contains(2)) litereCorecte.Add("C");

                    e.Value = string.Join(", ", litereCorecte);
                    e.FormattingApplied = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Eroare CellFormatting: {ex.Message}");
            }
        }

        private void buttonAddQuestion_Click(object sender, EventArgs e)
        {
            _currentEditingQuestionId = 0;

            textBoxEditQuestion.Clear();
            textBoxEditOpt1.Clear();
            textBoxEditOpt2.Clear();
            textBoxEditOpt3.Clear();
            checkBoxEditOpt1.Checked = false;
            checkBoxEditOpt2.Checked = false;
            checkBoxEditOpt3.Checked = false;

            panelEditQuestion.Visible = true;
            dataGridViewQuestions.Enabled = false;
            panelEditQuestion.BringToFront();
        }

        private void buttonUpdateQuestion_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewQuestions.SelectedRows.Count > 0)
                {
                    Question selectedQuestion = (Question)dataGridViewQuestions.SelectedRows[0].DataBoundItem;

                    _currentEditingQuestionId = selectedQuestion.Id;

                    textBoxEditQuestion.Text = selectedQuestion.Text;
                    if (selectedQuestion.Options.Count >= 3)
                    {
                        textBoxEditOpt1.Text = selectedQuestion.Options[0];
                        textBoxEditOpt2.Text = selectedQuestion.Options[1];
                        textBoxEditOpt3.Text = selectedQuestion.Options[2];
                    }

                    checkBoxEditOpt1.Checked = selectedQuestion.CorrectOptionsIndex.Contains(0);
                    checkBoxEditOpt2.Checked = selectedQuestion.CorrectOptionsIndex.Contains(1);
                    checkBoxEditOpt3.Checked = selectedQuestion.CorrectOptionsIndex.Contains(2);

                    panelEditQuestion.Visible = true;
                    dataGridViewQuestions.Enabled = false;
                    panelEditQuestion.BringToFront();
                }
                else
                {
                    MessageBox.Show("Te rog selectează o întrebare din tabel pentru a o edita.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la deschiderea editorului: {ex.Message}");
            }
        }

        private void buttonSaveQuestion_Click(object sender, EventArgs e)
        {
            try
            {
                // Validare câmpuri obligatorii
                if (string.IsNullOrWhiteSpace(textBoxEditQuestion.Text) ||
            string.IsNullOrWhiteSpace(textBoxEditOpt1.Text) ||
            string.IsNullOrWhiteSpace(textBoxEditOpt2.Text) ||
            string.IsNullOrWhiteSpace(textBoxEditOpt3.Text))
                {
                    MessageBox.Show("Toate textele sunt obligatorii!");
                    return;
                }

                // Validare cel puțin un răspuns corect bifat
                if (!checkBoxEditOpt1.Checked && !checkBoxEditOpt2.Checked && !checkBoxEditOpt3.Checked)
                {
                    MessageBox.Show("Bifează măcar o variantă ca fiind corectă!");
                    return;
                }

                List<string> options = new List<string> { textBoxEditOpt1.Text, textBoxEditOpt2.Text, textBoxEditOpt3.Text };
                List<int> correctIndexes = new List<int>();

                if (checkBoxEditOpt1.Checked) correctIndexes.Add(0);
                if (checkBoxEditOpt2.Checked) correctIndexes.Add(1);
                if (checkBoxEditOpt3.Checked) correctIndexes.Add(2);

                int idToSave = _currentEditingQuestionId;
                if (idToSave == 0)
                {
                    // Generăm Id nou pentru întrebare nouă
                    var allQuestions = _questionRepository.GetAll();
                    idToSave = allQuestions.Count > 0 ? allQuestions.Max(q => q.Id) + 1 : 1;
                }

                Question newQuestionData = new Question(
                    idToSave,
                    textBoxEditQuestion.Text,
                    options,
                    correctIndexes,
                    null,
                    "legislatie" // Categoria implicită la adăugare manuală
                );

                if (_currentEditingQuestionId == 0)
                {
                    _questionRepository.Add(newQuestionData);
                    MessageBox.Show("Întrebare adăugată cu succes!");
                }
                else
                {
                    _questionRepository.Update(newQuestionData);
                    MessageBox.Show("Întrebare actualizată!");
                }
                panelEditQuestion.Visible = false;
                dataGridViewQuestions.Enabled = true;
                LoadQuestions();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la salvarea întrebării: {ex.Message}");
            }
        }

        private void buttonCancelEdit_Click(object sender, EventArgs e)
        {
            panelEditQuestion.Visible = false; 
            dataGridViewQuestions.Enabled = true;
        }
    }
}
