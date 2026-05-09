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
            label6 = new Label();
            linkLabelLogIn = new LinkLabel();
            SuspendLayout();
            // 
            // textBoxUsername
            // 
            textBoxUsername.Anchor = AnchorStyles.None;
            textBoxUsername.Location = new Point(385, 187);
            textBoxUsername.Name = "textBoxUsername";
            textBoxUsername.Size = new Size(265, 27);
            textBoxUsername.TabIndex = 0;
            // 
            // textBoxName
            // 
            textBoxName.Anchor = AnchorStyles.None;
            textBoxName.Location = new Point(385, 266);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(265, 27);
            textBoxName.TabIndex = 1;
            // 
            // textBoxEmail
            // 
            textBoxEmail.Anchor = AnchorStyles.None;
            textBoxEmail.Location = new Point(385, 343);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.Size = new Size(265, 27);
            textBoxEmail.TabIndex = 2;
            // 
            // textBoxPassword
            // 
            textBoxPassword.Anchor = AnchorStyles.None;
            textBoxPassword.Location = new Point(385, 410);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.Size = new Size(265, 27);
            textBoxPassword.TabIndex = 3;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            label1.Location = new Point(444, 87);
            label1.Name = "label1";
            label1.Size = new Size(147, 46);
            label1.TabIndex = 4;
            label1.Text = "SIGNUP";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13F);
            label2.Location = new Point(470, 154);
            label2.Name = "label2";
            label2.Size = new Size(111, 30);
            label2.TabIndex = 5;
            label2.Text = "Username";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.None;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 13F);
            label3.Location = new Point(484, 233);
            label3.Name = "label3";
            label3.Size = new Size(71, 30);
            label3.TabIndex = 6;
            label3.Text = "Name";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.None;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 13F);
            label4.Location = new Point(491, 310);
            label4.Name = "label4";
            label4.Size = new Size(64, 30);
            label4.TabIndex = 7;
            label4.Text = "Email";
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.None;
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 13F);
            label5.Location = new Point(470, 377);
            label5.Name = "label5";
            label5.Size = new Size(103, 30);
            label5.TabIndex = 8;
            label5.Text = "Password";
            // 
            // buttonSignUp
            // 
            buttonSignUp.Anchor = AnchorStyles.None;
            buttonSignUp.Font = new Font("Segoe UI", 13F);
            buttonSignUp.Location = new Point(470, 443);
            buttonSignUp.Name = "buttonSignUp";
            buttonSignUp.Size = new Size(103, 53);
            buttonSignUp.TabIndex = 9;
            buttonSignUp.Text = "Signup";
            buttonSignUp.UseVisualStyleBackColor = true;
            buttonSignUp.Click += buttonSignUp_Click;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.None;
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F);
            label6.ForeColor = Color.Red;
            label6.Location = new Point(367, 499);
            label6.Name = "label6";
            label6.Size = new Size(294, 28);
            label6.TabIndex = 10;
            label6.Text = "Error: wrong sign up credentials!";
            // 
            // linkLabelLogIn
            // 
            linkLabelLogIn.Anchor = AnchorStyles.None;
            linkLabelLogIn.AutoSize = true;
            linkLabelLogIn.Font = new Font("Segoe UI", 13F);
            linkLabelLogIn.Location = new Point(333, 535);
            linkLabelLogIn.Name = "linkLabelLogIn";
            linkLabelLogIn.Size = new Size(378, 30);
            linkLabelLogIn.TabIndex = 11;
            linkLabelLogIn.TabStop = true;
            linkLabelLogIn.Text = "Already have an account? Then log in.";
            linkLabelLogIn.LinkClicked += linkLabelLogIn_LinkClicked;
            // 
            // SignUpUserControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(linkLabelLogIn);
            Controls.Add(label6);
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
        private Label label6;
        private LinkLabel linkLabelLogIn;
    }
}
