namespace View
{
    partial class LoginUserControl
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
            textBoxPassword = new TextBox();
            buttonLogin = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            linkLabelSignUp = new LinkLabel();
            label4 = new Label();
            SuspendLayout();
            // 
            // textBoxUsername
            // 
            textBoxUsername.Anchor = AnchorStyles.None;
            textBoxUsername.Location = new Point(404, 224);
            textBoxUsername.Name = "textBoxUsername";
            textBoxUsername.Size = new Size(221, 27);
            textBoxUsername.TabIndex = 0;
            // 
            // textBoxPassword
            // 
            textBoxPassword.Anchor = AnchorStyles.None;
            textBoxPassword.Location = new Point(404, 313);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.Size = new Size(221, 27);
            textBoxPassword.TabIndex = 1;
            // 
            // buttonLogin
            // 
            buttonLogin.Anchor = AnchorStyles.None;
            buttonLogin.Font = new Font("Segoe UI", 15F);
            buttonLogin.Location = new Point(446, 452);
            buttonLogin.Name = "buttonLogin";
            buttonLogin.Size = new Size(130, 44);
            buttonLogin.TabIndex = 2;
            buttonLogin.Text = "Login";
            buttonLogin.UseVisualStyleBackColor = true;
            buttonLogin.Click += buttonLogin_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            label1.Location = new Point(446, 71);
            label1.Name = "label1";
            label1.Size = new Size(130, 53);
            label1.TabIndex = 6;
            label1.Text = "LOGIN";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15F);
            label2.Location = new Point(458, 186);
            label2.Name = "label2";
            label2.Size = new Size(118, 35);
            label2.TabIndex = 7;
            label2.Text = "Usename";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.None;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 15F);
            label3.Location = new Point(456, 275);
            label3.Name = "label3";
            label3.Size = new Size(120, 35);
            label3.TabIndex = 8;
            label3.Text = "Password";
            // 
            // linkLabelSignUp
            // 
            linkLabelSignUp.Anchor = AnchorStyles.None;
            linkLabelSignUp.Font = new Font("Segoe UI", 13F);
            linkLabelSignUp.Location = new Point(404, 406);
            linkLabelSignUp.Name = "linkLabelSignUp";
            linkLabelSignUp.Size = new Size(221, 43);
            linkLabelSignUp.TabIndex = 9;
            linkLabelSignUp.TabStop = true;
            linkLabelSignUp.Text = "Create an account";
            linkLabelSignUp.TextAlign = ContentAlignment.TopCenter;
            linkLabelSignUp.LinkClicked += linkLabelSignUp_LinkClicked;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.None;
            label4.AutoSize = true;
            label4.ForeColor = Color.Red;
            label4.Location = new Point(423, 343);
            label4.Name = "label4";
            label4.Size = new Size(180, 20);
            label4.TabIndex = 10;
            label4.Text = "Wrong name or password";
            // 
            // LoginUserControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label4);
            Controls.Add(linkLabelSignUp);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(buttonLogin);
            Controls.Add(textBoxPassword);
            Controls.Add(textBoxUsername);
            Name = "LoginUserControl";
            Size = new Size(1000, 600);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxUsername;
        private TextBox textBoxPassword;
        private Button buttonLogin;
        private Label label1;
        private Label label2;
        private Label label3;
        private LinkLabel linkLabelSignUp;
        private Label label4;
    }
}
