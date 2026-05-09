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
            this.Width = 900;
            this.Width = 650;
            SwitchWindow(new LoginUserControl());
        }

        public void SwitchWindow(UserControl userControl)
        {
            this.Controls.Clear();
            userControl.Dock = DockStyle.Fill;
            this.Controls.Add(userControl);
        }
    }
}
