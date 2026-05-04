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
            startQuizButton = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            listView1 = new ListView();
            label1 = new Label();
            SuspendLayout();
            // 
            // startQuizButton
            // 
            startQuizButton.Font = new Font("Segoe UI", 15F);
            startQuizButton.Location = new Point(756, 134);
            startQuizButton.Name = "startQuizButton";
            startQuizButton.Size = new Size(207, 69);
            startQuizButton.TabIndex = 0;
            startQuizButton.Text = "Start Quiz";
            startQuizButton.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 15F);
            button2.Location = new Point(756, 232);
            button2.Name = "button2";
            button2.Size = new Size(207, 69);
            button2.TabIndex = 1;
            button2.Text = "Help";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Font = new Font("Segoe UI", 15F);
            button3.Location = new Point(756, 320);
            button3.Name = "button3";
            button3.Size = new Size(207, 69);
            button3.TabIndex = 2;
            button3.Text = "Admin";
            button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Font = new Font("Segoe UI", 15F);
            button4.Location = new Point(756, 406);
            button4.Name = "button4";
            button4.Size = new Size(207, 69);
            button4.TabIndex = 3;
            button4.Text = "Admin Help";
            button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.Font = new Font("Segoe UI", 15F);
            button5.Location = new Point(756, 492);
            button5.Name = "button5";
            button5.Size = new Size(207, 69);
            button5.TabIndex = 4;
            button5.Text = "Log Out";
            button5.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            listView1.Location = new Point(30, 136);
            listView1.Name = "listView1";
            listView1.Size = new Size(695, 425);
            listView1.TabIndex = 5;
            listView1.UseCompatibleStateImageBehavior = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            label1.Location = new Point(30, 61);
            label1.Name = "label1";
            label1.Size = new Size(204, 46);
            label1.TabIndex = 6;
            label1.Text = "Main Menu";
            // 
            // DashboardUserControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label1);
            Controls.Add(listView1);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(startQuizButton);
            Name = "DashboardUserControl";
            Size = new Size(1000, 600);
            Load += DashboardUserControl_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button startQuizButton;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private ListView listView1;
        private Label label1;
    }
}
