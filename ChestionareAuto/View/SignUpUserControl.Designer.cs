namespace View
{
    partial class SignUpUserControl
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
            textBoxUsername = new TextBox();
            textBoxName = new TextBox();
            textBoxEmail = new TextBox();
            textBoxPassword = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            buttonSignUp = new Button();
            labelError = new Label();
            linkLabelLogIn = new LinkLabel();
            SuspendLayout();
            // 
            // textBoxUsername
            // 
            textBoxUsername.Anchor = AnchorStyles.None;
            textBoxUsername.Font = new Font("Segoe UI", 10F);
            textBoxUsername.Location = new Point(367, 169);
            textBoxUsername.Name = "textBoxUsername";
            textBoxUsername.Size = new Size(265, 30);
            textBoxUsername.TabIndex = 0;
            // 
            // textBoxName
            // 
            textBoxName.Anchor = AnchorStyles.None;
            textBoxName.Font = new Font("Segoe UI", 10F);
            textBoxName.Location = new Point(367, 235);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(265, 30);
            textBoxName.TabIndex = 1;
            // 
            // textBoxEmail
            // 
            textBoxEmail.Anchor = AnchorStyles.None;
            textBoxEmail.Font = new Font("Segoe UI", 10F);
            textBoxEmail.Location = new Point(367, 301);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.Size = new Size(265, 30);
            textBoxEmail.TabIndex = 2;
            // 
            // textBoxPassword
            // 
            textBoxPassword.Anchor = AnchorStyles.None;
            textBoxPassword.Font = new Font("Segoe UI", 10F);
            textBoxPassword.Location = new Point(367, 367);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.Size = new Size(265, 30);
            textBoxPassword.TabIndex = 3;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 23F, FontStyle.Bold);
            label1.Location = new Point(411, 54);
            label1.Name = "label1";
            label1.Size = new Size(178, 52);
            label1.TabIndex = 4;
            label1.Text = "SIGN UP";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            label2.Location = new Point(441, 136);
            label2.Name = "label2";
            label2.Size = new Size(117, 30);
            label2.TabIndex = 5;
            label2.Text = "Username";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.None;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            label3.Location = new Point(462, 202);
            label3.Name = "label3";
            label3.Size = new Size(75, 30);
            label3.TabIndex = 6;
            label3.Text = "Nume";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.None;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            label4.Location = new Point(462, 268);
            label4.Name = "label4";
            label4.Size = new Size(69, 30);
            label4.TabIndex = 7;
            label4.Text = "Email";
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.None;
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            label5.Location = new Point(459, 334);
            label5.Name = "label5";
            label5.Size = new Size(78, 30);
            label5.TabIndex = 8;
            label5.Text = "Parola";
            // 
            // buttonSignUp
            // 
            buttonSignUp.Anchor = AnchorStyles.None;
            buttonSignUp.Cursor = Cursors.Hand;
            buttonSignUp.Font = new Font("Segoe UI", 13F);
            buttonSignUp.Location = new Point(448, 403);
            buttonSignUp.Name = "buttonSignUp";
            buttonSignUp.Size = new Size(103, 53);
            buttonSignUp.TabIndex = 9;
            buttonSignUp.Text = "Sign up";
            buttonSignUp.UseVisualStyleBackColor = true;
            buttonSignUp.Click += buttonSignUp_Click;
            // 
            // labelError
            // 
            labelError.Anchor = AnchorStyles.None;
            labelError.Font = new Font("Segoe UI", 9F);
            labelError.ForeColor = Color.Red;
            labelError.Location = new Point(301, 459);
            labelError.Name = "labelError";
            labelError.Size = new Size(400, 20);
            labelError.TabIndex = 10;
            labelError.Text = "Error!";
            labelError.TextAlign = ContentAlignment.MiddleCenter;
            labelError.Click += labelError_Click;
            // 
            // linkLabelLogIn
            // 
            linkLabelLogIn.Anchor = AnchorStyles.None;
            linkLabelLogIn.AutoSize = true;
            linkLabelLogIn.Font = new Font("Segoe UI", 13F);
            linkLabelLogIn.Location = new Point(340, 493);
            linkLabelLogIn.Name = "linkLabelLogIn";
            linkLabelLogIn.Size = new Size(319, 30);
            linkLabelLogIn.TabIndex = 11;
            linkLabelLogIn.TabStop = true;
            linkLabelLogIn.Text = "Ai deja un cont? Conectează-te!";
            linkLabelLogIn.LinkClicked += linkLabelLogIn_LinkClicked;
            // 
            // SignUpUserControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientActiveCaption;
            Controls.Add(linkLabelLogIn);
            Controls.Add(labelError);
            Controls.Add(buttonSignUp);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBoxPassword);
            Controls.Add(textBoxEmail);
            Controls.Add(textBoxName);
            Controls.Add(textBoxUsername);
            Name = "SignUpUserControl";
            Size = new Size(1000, 600);
            Load += SignUpUserControl_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxUsername;
        private TextBox textBoxName;
        private TextBox textBoxEmail;
        private TextBox textBoxPassword;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Button buttonSignUp;
        private Label labelError;
        private LinkLabel linkLabelLogIn;
    }
}
