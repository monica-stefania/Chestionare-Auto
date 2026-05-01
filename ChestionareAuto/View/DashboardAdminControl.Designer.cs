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
            listView1 = new ListView();
            listView2 = new ListView();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            button7 = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // listView1
            // 
            listView1.Location = new Point(59, 105);
            listView1.Name = "listView1";
            listView1.Size = new Size(373, 323);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            // 
            // listView2
            // 
            listView2.Location = new Point(552, 106);
            listView2.Name = "listView2";
            listView2.Size = new Size(396, 322);
            listView2.TabIndex = 1;
            listView2.UseCompatibleStateImageBehavior = false;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 12F);
            button1.Location = new Point(59, 446);
            button1.Name = "button1";
            button1.Size = new Size(149, 47);
            button1.TabIndex = 2;
            button1.Text = "Reset Progress";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 12F);
            button2.Location = new Point(283, 446);
            button2.Name = "button2";
            button2.Size = new Size(149, 47);
            button2.TabIndex = 3;
            button2.Text = "Change Role";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Font = new Font("Segoe UI", 12F);
            button3.Location = new Point(59, 517);
            button3.Name = "button3";
            button3.Size = new Size(149, 47);
            button3.TabIndex = 4;
            button3.Text = "Remove User";
            button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Font = new Font("Segoe UI", 13F);
            button4.Location = new Point(283, 517);
            button4.Name = "button4";
            button4.Size = new Size(149, 47);
            button4.TabIndex = 5;
            button4.Text = "Help";
            button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.Font = new Font("Segoe UI", 12F);
            button5.Location = new Point(552, 446);
            button5.Name = "button5";
            button5.Size = new Size(149, 47);
            button5.TabIndex = 6;
            button5.Text = "Remove Quiz";
            button5.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            button6.Font = new Font("Segoe UI", 13F);
            button6.Location = new Point(799, 446);
            button6.Name = "button6";
            button6.Size = new Size(149, 47);
            button6.TabIndex = 7;
            button6.Text = "Create Quiz";
            button6.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            button7.Font = new Font("Segoe UI", 13F);
            button7.Location = new Point(799, 527);
            button7.Name = "button7";
            button7.Size = new Size(149, 47);
            button7.TabIndex = 8;
            button7.Text = "User Panel";
            button7.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 25F, FontStyle.Bold);
            label1.Location = new Point(58, 32);
            label1.Name = "label1";
            label1.Size = new Size(276, 57);
            label1.TabIndex = 9;
            label1.Text = "Admin Panel";
            // 
            // DashboardAdminControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label1);
            Controls.Add(button7);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(listView2);
            Controls.Add(listView1);
            Name = "DashboardAdminControl";
            Size = new Size(1000, 600);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListView listView1;
        private ListView listView2;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button button7;
        private Label label1;
    }
}
