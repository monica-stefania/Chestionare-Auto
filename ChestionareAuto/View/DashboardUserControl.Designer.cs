namespace View
{
    partial class DashboardUserControl
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
            buttonStartExamen = new Button();
            buttonHelp = new Button();
            buttonLogOut = new Button();
            labelWelcome = new Label();
            dataGridViewHistory = new DataGridView();
            dataTest = new DataGridViewTextBoxColumn();
            tipTest = new DataGridViewTextBoxColumn();
            punctaj = new DataGridViewTextBoxColumn();
            stare = new DataGridViewTextBoxColumn();
            colReluare = new DataGridViewButtonColumn();
            buttonStartInvatare = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewHistory).BeginInit();
            SuspendLayout();
            // 
            // buttonStartExamen
            // 
            buttonStartExamen.Anchor = AnchorStyles.None;
            buttonStartExamen.Font = new Font("Segoe UI", 13F);
            buttonStartExamen.Location = new Point(994, 79);
            buttonStartExamen.Margin = new Padding(4);
            buttonStartExamen.Name = "buttonStartExamen";
            buttonStartExamen.Size = new Size(186, 64);
            buttonStartExamen.TabIndex = 0;
            buttonStartExamen.Text = "Start Examen";
            buttonStartExamen.UseVisualStyleBackColor = true;
            buttonStartExamen.Click += buttonStartExamen_Click;
            // 
            // buttonHelp
            // 
            buttonHelp.Anchor = AnchorStyles.None;
            buttonHelp.Font = new Font("Segoe UI", 12F);
            buttonHelp.Location = new Point(1029, 560);
            buttonHelp.Margin = new Padding(4);
            buttonHelp.Name = "buttonHelp";
            buttonHelp.Size = new Size(114, 48);
            buttonHelp.TabIndex = 1;
            buttonHelp.Text = "Help";
            buttonHelp.UseVisualStyleBackColor = true;
            buttonHelp.Click += buttonHelp_Click;
            // 
            // buttonLogOut
            // 
            buttonLogOut.Anchor = AnchorStyles.None;
            buttonLogOut.Font = new Font("Segoe UI", 12F);
            buttonLogOut.Location = new Point(1029, 628);
            buttonLogOut.Margin = new Padding(4);
            buttonLogOut.Name = "buttonLogOut";
            buttonLogOut.Size = new Size(114, 50);
            buttonLogOut.TabIndex = 4;
            buttonLogOut.Text = "Log Out";
            buttonLogOut.UseVisualStyleBackColor = true;
            buttonLogOut.Click += buttonLogOut_Click;
            // 
            // labelWelcome
            // 
            labelWelcome.Anchor = AnchorStyles.None;
            labelWelcome.Font = new Font("Verdana", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelWelcome.ForeColor = Color.Navy;
            labelWelcome.Location = new Point(29, 11);
            labelWelcome.Margin = new Padding(4, 0, 4, 0);
            labelWelcome.Name = "labelWelcome";
            labelWelcome.Size = new Size(1100, 64);
            labelWelcome.TabIndex = 6;
            labelWelcome.Text = "welcome";
            // 
            // dataGridViewHistory
            // 
            dataGridViewHistory.AllowUserToAddRows = false;
            dataGridViewHistory.AllowUserToDeleteRows = false;
            dataGridViewHistory.Anchor = AnchorStyles.None;
            dataGridViewHistory.BackgroundColor = Color.Azure;
            dataGridViewHistory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewHistory.Columns.AddRange(new DataGridViewColumn[] { dataTest, tipTest, punctaj, stare, colReluare });
            dataGridViewHistory.Location = new Point(29, 79);
            dataGridViewHistory.Margin = new Padding(4);
            dataGridViewHistory.Name = "dataGridViewHistory";
            dataGridViewHistory.RowHeadersWidth = 51;
            dataGridViewHistory.Size = new Size(938, 599);
            dataGridViewHistory.TabIndex = 7;
            dataGridViewHistory.CellContentClick += dataGridViewHistory_CellContentClick;
            // 
            // dataTest
            // 
            dataTest.HeaderText = "Data";
            dataTest.MinimumWidth = 6;
            dataTest.Name = "dataTest";
            dataTest.Width = 125;
            // 
            // tipTest
            // 
            tipTest.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            tipTest.HeaderText = "Tipul Testului";
            tipTest.MinimumWidth = 6;
            tipTest.Name = "tipTest";
            // 
            // punctaj
            // 
            punctaj.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            punctaj.HeaderText = "Punctaj";
            punctaj.MinimumWidth = 6;
            punctaj.Name = "punctaj";
            // 
            // stare
            // 
            stare.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            stare.HeaderText = "Stare";
            stare.MinimumWidth = 6;
            stare.Name = "stare";
            // 
            // colReluare
            // 
            colReluare.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colReluare.HeaderText = "Acțiune";
            colReluare.MinimumWidth = 6;
            colReluare.Name = "colReluare";
            colReluare.Text = "Reluare";
            colReluare.UseColumnTextForButtonValue = true;
            // 
            // buttonStartInvatare
            // 
            buttonStartInvatare.Anchor = AnchorStyles.None;
            buttonStartInvatare.Font = new Font("Segoe UI", 13F);
            buttonStartInvatare.Location = new Point(994, 167);
            buttonStartInvatare.Margin = new Padding(4);
            buttonStartInvatare.Name = "buttonStartInvatare";
            buttonStartInvatare.Size = new Size(186, 64);
            buttonStartInvatare.TabIndex = 8;
            buttonStartInvatare.Text = "Start Învățare";
            buttonStartInvatare.UseVisualStyleBackColor = true;
            buttonStartInvatare.Click += buttonStartInvatare_Click;
            // 
            // DashboardUserControl
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.InactiveCaption;
            Controls.Add(buttonStartInvatare);
            Controls.Add(dataGridViewHistory);
            Controls.Add(labelWelcome);
            Controls.Add(buttonLogOut);
            Controls.Add(buttonHelp);
            Controls.Add(buttonStartExamen);
            Font = new Font("Segoe UI", 11F);
            Margin = new Padding(4);
            Name = "DashboardUserControl";
            Size = new Size(1200, 700);
            Load += DashboardUserControl_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewHistory).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button buttonStartExamen;
        private Button buttonHelp;
        private Button buttonLogOut;
        private Label labelWelcome;
        private DataGridView dataGridViewHistory;
        private Button buttonStartInvatare;
        private DataGridViewTextBoxColumn dataTest;
        private DataGridViewTextBoxColumn tipTest;
        private DataGridViewTextBoxColumn punctaj;
        private DataGridViewTextBoxColumn stare;
        private DataGridViewButtonColumn colReluare;
    }
}
