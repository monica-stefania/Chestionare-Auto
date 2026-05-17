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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            SwitchWindow(new LoginUserControl());
        }

        public void SwitchWindow(UserControl userControl)
        {
            this.Controls.Clear();
            userControl.Dock = DockStyle.Fill;
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
    }
}
