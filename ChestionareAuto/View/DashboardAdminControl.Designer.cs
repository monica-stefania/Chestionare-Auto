namespace View
{
    partial class DashboardAdminControl
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            tabControlAdmin = new TabControl();
            tabPageQuestions = new TabPage();
            panelEditQuestion = new Panel();
            buttonCancelEdit = new Button();
            buttonSaveQuestion = new Button();
            checkBoxEditOpt3 = new CheckBox();
            checkBoxEditOpt2 = new CheckBox();
            checkBoxEditOpt1 = new CheckBox();
            textBoxEditOpt3 = new TextBox();
            textBoxEditOpt2 = new TextBox();
            textBoxEditOpt1 = new TextBox();
            textBoxEditQuestion = new TextBox();
            buttonUpdateQuestion = new Button();
            buttonDeleteQuestion = new Button();
            buttonAddQuestion = new Button();
            dataGridViewQuestions = new DataGridView();
            tabPageUsers = new TabPage();
            buttonChangeRoleUser = new Button();
            buttonRemoveUser = new Button();
            dataGridViewUsers = new DataGridView();
            buttonLogOut = new Button();
            buttonHelp = new Button();
            tabControlAdmin.SuspendLayout();
            tabPageQuestions.SuspendLayout();
            panelEditQuestion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewQuestions).BeginInit();
            tabPageUsers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewUsers).BeginInit();
            SuspendLayout();
            // 
            // tabControlAdmin
            // 
            tabControlAdmin.Controls.Add(tabPageQuestions);
            tabControlAdmin.Controls.Add(tabPageUsers);
            tabControlAdmin.Font = new Font("Segoe UI", 10F);
            tabControlAdmin.Location = new Point(16, 37);
            tabControlAdmin.Name = "tabControlAdmin";
            tabControlAdmin.SelectedIndex = 0;
            tabControlAdmin.Size = new Size(1083, 587);
            tabControlAdmin.TabIndex = 10;
            // 
            // tabPageQuestions
            // 
            tabPageQuestions.Controls.Add(panelEditQuestion);
            tabPageQuestions.Controls.Add(buttonUpdateQuestion);
            tabPageQuestions.Controls.Add(buttonDeleteQuestion);
            tabPageQuestions.Controls.Add(buttonAddQuestion);
            tabPageQuestions.Controls.Add(dataGridViewQuestions);
            tabPageQuestions.Location = new Point(4, 32);
            tabPageQuestions.Name = "tabPageQuestions";
            tabPageQuestions.Padding = new Padding(3);
            tabPageQuestions.Size = new Size(1075, 551);
            tabPageQuestions.TabIndex = 0;
            tabPageQuestions.Text = "Gestionare Întrebări";
            tabPageQuestions.UseVisualStyleBackColor = true;
            // 
            // panelEditQuestion
            // 
            panelEditQuestion.BorderStyle = BorderStyle.FixedSingle;
            panelEditQuestion.Controls.Add(buttonCancelEdit);
            panelEditQuestion.Controls.Add(buttonSaveQuestion);
            panelEditQuestion.Controls.Add(checkBoxEditOpt3);
            panelEditQuestion.Controls.Add(checkBoxEditOpt2);
            panelEditQuestion.Controls.Add(checkBoxEditOpt1);
            panelEditQuestion.Controls.Add(textBoxEditOpt3);
            panelEditQuestion.Controls.Add(textBoxEditOpt2);
            panelEditQuestion.Controls.Add(textBoxEditOpt1);
            panelEditQuestion.Controls.Add(textBoxEditQuestion);
            panelEditQuestion.Location = new Point(111, 6);
            panelEditQuestion.Name = "panelEditQuestion";
            panelEditQuestion.Size = new Size(600, 494);
            panelEditQuestion.TabIndex = 12;
            panelEditQuestion.Visible = false;
            // 
            // buttonCancelEdit
            // 
            buttonCancelEdit.Location = new Point(365, 433);
            buttonCancelEdit.Name = "buttonCancelEdit";
            buttonCancelEdit.Size = new Size(94, 29);
            buttonCancelEdit.TabIndex = 8;
            buttonCancelEdit.Text = "Anulează";
            buttonCancelEdit.UseVisualStyleBackColor = true;
            buttonCancelEdit.Click += buttonCancelEdit_Click;
            // 
            // buttonSaveQuestion
            // 
            buttonSaveQuestion.Location = new Point(112, 433);
            buttonSaveQuestion.Name = "buttonSaveQuestion";
            buttonSaveQuestion.Size = new Size(94, 29);
            buttonSaveQuestion.TabIndex = 7;
            buttonSaveQuestion.Text = "Salvează";
            buttonSaveQuestion.UseVisualStyleBackColor = true;
            buttonSaveQuestion.Click += buttonSaveQuestion_Click;
            // 
            // checkBoxEditOpt3
            // 
            checkBoxEditOpt3.AutoSize = true;
            checkBoxEditOpt3.Location = new Point(82, 344);
            checkBoxEditOpt3.Name = "checkBoxEditOpt3";
            checkBoxEditOpt3.Size = new Size(18, 17);
            checkBoxEditOpt3.TabIndex = 6;
            checkBoxEditOpt3.UseVisualStyleBackColor = true;
            // 
            // checkBoxEditOpt2
            // 
            checkBoxEditOpt2.AutoSize = true;
            checkBoxEditOpt2.Location = new Point(82, 281);
            checkBoxEditOpt2.Name = "checkBoxEditOpt2";
            checkBoxEditOpt2.Size = new Size(18, 17);
            checkBoxEditOpt2.TabIndex = 5;
            checkBoxEditOpt2.UseVisualStyleBackColor = true;
            // 
            // checkBoxEditOpt1
            // 
            checkBoxEditOpt1.AutoSize = true;
            checkBoxEditOpt1.Location = new Point(82, 212);
            checkBoxEditOpt1.Name = "checkBoxEditOpt1";
            checkBoxEditOpt1.Size = new Size(18, 17);
            checkBoxEditOpt1.TabIndex = 4;
            checkBoxEditOpt1.UseVisualStyleBackColor = true;
            // 
            // textBoxEditOpt3
            // 
            textBoxEditOpt3.Location = new Point(133, 337);
            textBoxEditOpt3.Name = "textBoxEditOpt3";
            textBoxEditOpt3.Size = new Size(265, 30);
            textBoxEditOpt3.TabIndex = 3;
            // 
            // textBoxEditOpt2
            // 
            textBoxEditOpt2.Location = new Point(133, 274);
            textBoxEditOpt2.Name = "textBoxEditOpt2";
            textBoxEditOpt2.Size = new Size(265, 30);
            textBoxEditOpt2.TabIndex = 2;
            // 
            // textBoxEditOpt1
            // 
            textBoxEditOpt1.Location = new Point(133, 205);
            textBoxEditOpt1.Name = "textBoxEditOpt1";
            textBoxEditOpt1.Size = new Size(265, 30);
            textBoxEditOpt1.TabIndex = 1;
            // 
            // textBoxEditQuestion
            // 
            textBoxEditQuestion.Location = new Point(34, 58);
            textBoxEditQuestion.Name = "textBoxEditQuestion";
            textBoxEditQuestion.Size = new Size(532, 30);
            textBoxEditQuestion.TabIndex = 0;
            // 
            // buttonUpdateQuestion
            // 
            buttonUpdateQuestion.Font = new Font("Segoe UI", 11F);
            buttonUpdateQuestion.Location = new Point(285, 489);
            buttonUpdateQuestion.Name = "buttonUpdateQuestion";
            buttonUpdateQuestion.Size = new Size(98, 37);
            buttonUpdateQuestion.TabIndex = 4;
            buttonUpdateQuestion.Text = "Modifică";
            buttonUpdateQuestion.UseVisualStyleBackColor = true;
            buttonUpdateQuestion.Click += buttonUpdateQuestion_Click;
            // 
            // buttonDeleteQuestion
            // 
            buttonDeleteQuestion.Font = new Font("Segoe UI", 11F);
            buttonDeleteQuestion.Location = new Point(158, 489);
            buttonDeleteQuestion.Name = "buttonDeleteQuestion";
            buttonDeleteQuestion.Size = new Size(99, 37);
            buttonDeleteQuestion.TabIndex = 3;
            buttonDeleteQuestion.Text = "Șterge";
            buttonDeleteQuestion.UseVisualStyleBackColor = true;
            buttonDeleteQuestion.Click += buttonDeleteQuestion_Click;
            // 
            // buttonAddQuestion
            // 
            buttonAddQuestion.Font = new Font("Segoe UI", 11F);
            buttonAddQuestion.Location = new Point(29, 489);
            buttonAddQuestion.Name = "buttonAddQuestion";
            buttonAddQuestion.Size = new Size(99, 37);
            buttonAddQuestion.TabIndex = 2;
            buttonAddQuestion.Text = "Adaugă";
            buttonAddQuestion.UseVisualStyleBackColor = true;
            buttonAddQuestion.Click += buttonAddQuestion_Click;
            // 
            // dataGridViewQuestions
            // 
            dataGridViewQuestions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewQuestions.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewQuestions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.Padding = new Padding(5);
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridViewQuestions.DefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewQuestions.Location = new Point(29, 19);
            dataGridViewQuestions.Name = "dataGridViewQuestions";
            dataGridViewQuestions.RowHeadersWidth = 51;
            dataGridViewQuestions.Size = new Size(983, 441);
            dataGridViewQuestions.TabIndex = 1;
            dataGridViewQuestions.CellFormatting += dataGridViewQuestions_CellFormatting;
            // 
            // tabPageUsers
            // 
            tabPageUsers.Controls.Add(buttonChangeRoleUser);
            tabPageUsers.Controls.Add(buttonRemoveUser);
            tabPageUsers.Controls.Add(dataGridViewUsers);
            tabPageUsers.Location = new Point(4, 32);
            tabPageUsers.Name = "tabPageUsers";
            tabPageUsers.Padding = new Padding(3);
            tabPageUsers.Size = new Size(1075, 551);
            tabPageUsers.TabIndex = 1;
            tabPageUsers.Text = "Gestionare Utilizatori";
            tabPageUsers.UseVisualStyleBackColor = true;
            // 
            // buttonChangeRoleUser
            // 
            buttonChangeRoleUser.Location = new Point(207, 496);
            buttonChangeRoleUser.Name = "buttonChangeRoleUser";
            buttonChangeRoleUser.Size = new Size(175, 34);
            buttonChangeRoleUser.TabIndex = 2;
            buttonChangeRoleUser.Text = "Schimbă Rolul";
            buttonChangeRoleUser.UseVisualStyleBackColor = true;
            buttonChangeRoleUser.Click += buttonChangeRoleUser_Click;
            // 
            // buttonRemoveUser
            // 
            buttonRemoveUser.Location = new Point(33, 496);
            buttonRemoveUser.Name = "buttonRemoveUser";
            buttonRemoveUser.Size = new Size(138, 34);
            buttonRemoveUser.TabIndex = 1;
            buttonRemoveUser.Text = "Șterge";
            buttonRemoveUser.UseVisualStyleBackColor = true;
            buttonRemoveUser.Click += buttonRemoveUser_Click;
            // 
            // dataGridViewUsers
            // 
            dataGridViewUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewUsers.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 11F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.Padding = new Padding(5);
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dataGridViewUsers.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewUsers.Location = new Point(33, 31);
            dataGridViewUsers.Name = "dataGridViewUsers";
            dataGridViewUsers.RowHeadersWidth = 51;
            dataGridViewUsers.Size = new Size(983, 441);
            dataGridViewUsers.TabIndex = 0;
            // 
            // buttonLogOut
            // 
            buttonLogOut.Font = new Font("Segoe UI", 11F);
            buttonLogOut.Location = new Point(1081, 646);
            buttonLogOut.Name = "buttonLogOut";
            buttonLogOut.Size = new Size(104, 36);
            buttonLogOut.TabIndex = 5;
            buttonLogOut.Text = "Log Out";
            buttonLogOut.UseVisualStyleBackColor = true;
            buttonLogOut.Click += buttonLogOut_Click;
            // 
            // buttonHelp
            // 
            buttonHelp.Font = new Font("Segoe UI", 11F);
            buttonHelp.Location = new Point(16, 646);
            buttonHelp.Name = "buttonHelp";
            buttonHelp.Size = new Size(104, 36);
            buttonHelp.TabIndex = 11;
            buttonHelp.Text = "Help";
            buttonHelp.UseVisualStyleBackColor = true;
            // 
            // DashboardAdminControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.InactiveCaption;
            Controls.Add(buttonHelp);
            Controls.Add(buttonLogOut);
            Controls.Add(tabControlAdmin);
            Name = "DashboardAdminControl";
            Size = new Size(1200, 700);
            Load += DashboardAdminControl_Load;
            tabControlAdmin.ResumeLayout(false);
            tabPageQuestions.ResumeLayout(false);
            panelEditQuestion.ResumeLayout(false);
            panelEditQuestion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewQuestions).EndInit();
            tabPageUsers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewUsers).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private TabControl tabControlAdmin;
        private TabPage tabPageQuestions;
        private TabPage tabPageUsers;
        private DataGridView dataGridViewQuestions;
        private Button buttonChangeRoleUser;
        private Button buttonRemoveUser;
        private DataGridView dataGridViewUsers;
        private Button buttonUpdateQuestion;
        private Button buttonDeleteQuestion;
        private Button buttonAddQuestion;
        private Button buttonLogOut;
        private Button buttonHelp;
        private Panel panelEditQuestion;
        private Button buttonCancelEdit;
        private Button buttonSaveQuestion;
        private CheckBox checkBoxEditOpt3;
        private CheckBox checkBoxEditOpt2;
        private CheckBox checkBoxEditOpt1;
        private TextBox textBoxEditOpt3;
        private TextBox textBoxEditOpt2;
        private TextBox textBoxEditOpt1;
        private TextBox textBoxEditQuestion;
    }
}
