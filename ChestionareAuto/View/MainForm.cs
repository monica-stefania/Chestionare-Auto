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
    /// Formularul principal al aplicației Chestionare Auto.
    /// Acționează ca un container care găzduiește un singur UserControl la un moment dat
    /// și gestionează tranzițiile între ecranele aplicației.
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// Inițializează formularul principal.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            SwitchWindow(new LoginUserControl());
        }

        /// <summary>
        /// Înlocuiește controlul curent cu un nou UserControl.
        /// </summary>
        /// <param name="userControl">Noul control de afișat.</param>
        public void SwitchWindow(UserControl userControl)
        {
            try
            {
                this.Controls.Clear();
                userControl.Dock = DockStyle.Fill;

                // Dimensiune mai mică pentru ecranele de autentificare/logare
                if (userControl is LoginUserControl || userControl is SignUpUserControl)
                {
                    this.Size = new Size(600, 800);
                }
                else
                {
                    this.Size = new Size(1200, 800);
                    this.CenterToScreen();
                }

                this.Controls.Add(userControl);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la schimbarea ecranului: {ex.Message}");
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

    }
}
