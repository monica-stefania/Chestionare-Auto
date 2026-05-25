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
    /// Formularul care arată rezultatele finale după terminarea testului.
    /// </summary>
    public partial class ResultsForm : Form
    {
        /// <summary>
        /// Inițializează formularul de rezultate cu datele sesiunii finalizate.
        /// </summary>
        /// <param name="score">Numărul de răspunsuri corecte.</param>
        /// <param name="mistakes">Numărul de răspunsuri greșite.</param>
        /// <param name="isPassed">True dacă utilizatorul a promovat.</param>
        public ResultsForm(int score, int mistakes, bool isPassed)
        {
            InitializeComponent();

            label1.Text = $"Răspunsuri corecte: {score} / 26";
            label2.Text = $"Răspunsuri greșite: {mistakes}";

            // Colorăm titlul în funcție de rezultat
            if (isPassed)
            {
                label3.Text = "ADMIS";
                label3.ForeColor = Color.Green;
            }
            else
            {
                label3.Text = "RESPINS";
                label3.ForeColor = Color.Red;
            }

            button1.Click += (s, e) => this.Close();
        }

        private void ResultsForm_Load(object sender, EventArgs e)
        {

        }
    }
}
