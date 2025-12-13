namespace Cafeteria_Managment_System {
    partial class Login {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            components = new System.ComponentModel.Container();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            panel8 = new Panel();
            LeaveTxtbtn = new Label();
            AdditmBtn = new Button();
            PasswordTB = new Guna.UI2.WinForms.Guna2TextBox();
            UsernameTB = new Guna.UI2.WinForms.Guna2TextBox();
            pictureBox8 = new PictureBox();
            label7 = new Label();
            guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(components);
            guna2Elipse2 = new Guna.UI2.WinForms.Guna2Elipse(components);
            panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).BeginInit();
            SuspendLayout();
            // 
            // panel8
            // 
            panel8.BackColor = Color.FromArgb(127, 79, 36);
            panel8.Controls.Add(LeaveTxtbtn);
            panel8.Controls.Add(AdditmBtn);
            panel8.Controls.Add(PasswordTB);
            panel8.Controls.Add(UsernameTB);
            panel8.Controls.Add(pictureBox8);
            panel8.Controls.Add(label7);
            panel8.Location = new Point(196, 64);
            panel8.Name = "panel8";
            panel8.Size = new Size(389, 339);
            panel8.TabIndex = 20;
            // 
            // LeaveTxtbtn
            // 
            LeaveTxtbtn.AutoSize = true;
            LeaveTxtbtn.Cursor = Cursors.Hand;
            LeaveTxtbtn.Font = new Font("Poppins", 7.8F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            LeaveTxtbtn.ForeColor = Color.Red;
            LeaveTxtbtn.Location = new Point(168, 295);
            LeaveTxtbtn.Margin = new Padding(5, 0, 5, 0);
            LeaveTxtbtn.Name = "LeaveTxtbtn";
            LeaveTxtbtn.Size = new Size(49, 23);
            LeaveTxtbtn.TabIndex = 13;
            LeaveTxtbtn.Text = "Leave";
            LeaveTxtbtn.Click += LeaveTxtbtn_Click;
            // 
            // AdditmBtn
            // 
            AdditmBtn.BackColor = Color.FromArgb(65, 72, 51);
            AdditmBtn.FlatStyle = FlatStyle.Flat;
            AdditmBtn.ForeColor = Color.FromArgb(194, 197, 170);
            AdditmBtn.Location = new Point(20, 246);
            AdditmBtn.Name = "AdditmBtn";
            AdditmBtn.Size = new Size(358, 46);
            AdditmBtn.TabIndex = 12;
            AdditmBtn.Text = "Login";
            AdditmBtn.UseVisualStyleBackColor = false;
            AdditmBtn.Click += AdditmBtn_Click;
            // 
            // PasswordTB
            // 
            PasswordTB.BackColor = Color.Yellow;
            PasswordTB.BorderThickness = 0;
            PasswordTB.CustomizableEdges = customizableEdges1;
            PasswordTB.DefaultText = "";
            PasswordTB.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            PasswordTB.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            PasswordTB.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            PasswordTB.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            PasswordTB.FillColor = Color.FromArgb(164, 172, 134);
            PasswordTB.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            PasswordTB.Font = new Font("Poppins Medium", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            PasswordTB.ForeColor = Color.FromArgb(51, 61, 41);
            PasswordTB.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            PasswordTB.Location = new Point(20, 171);
            PasswordTB.Margin = new Padding(4, 6, 4, 6);
            PasswordTB.Name = "PasswordTB";
            PasswordTB.PasswordChar = '•';
            PasswordTB.PlaceholderForeColor = Color.FromArgb(101, 109, 74);
            PasswordTB.PlaceholderText = "Password";
            PasswordTB.SelectedText = "";
            PasswordTB.ShadowDecoration.CustomizableEdges = customizableEdges2;
            PasswordTB.Size = new Size(358, 57);
            PasswordTB.TabIndex = 10;
            PasswordTB.KeyDown += PasswordTB_KeyDown;
            // 
            // UsernameTB
            // 
            UsernameTB.BackColor = Color.Yellow;
            UsernameTB.BorderThickness = 0;
            UsernameTB.CustomizableEdges = customizableEdges3;
            UsernameTB.DefaultText = "";
            UsernameTB.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            UsernameTB.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            UsernameTB.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            UsernameTB.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            UsernameTB.FillColor = Color.FromArgb(164, 172, 134);
            UsernameTB.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            UsernameTB.Font = new Font("Poppins Medium", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            UsernameTB.ForeColor = Color.FromArgb(51, 61, 41);
            UsernameTB.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            UsernameTB.Location = new Point(20, 105);
            UsernameTB.Margin = new Padding(4, 6, 4, 6);
            UsernameTB.Name = "UsernameTB";
            UsernameTB.PlaceholderForeColor = Color.FromArgb(101, 109, 74);
            UsernameTB.PlaceholderText = "Username";
            UsernameTB.SelectedText = "";
            UsernameTB.ShadowDecoration.CustomizableEdges = customizableEdges4;
            UsernameTB.Size = new Size(358, 57);
            UsernameTB.TabIndex = 5;
            UsernameTB.KeyDown += UsernameTB_KeyDown;
            // 
            // pictureBox8
            // 
            pictureBox8.Image = (Image)resources.GetObject("pictureBox8.Image");
            pictureBox8.Location = new Point(37, 5);
            pictureBox8.Name = "pictureBox8";
            pictureBox8.Size = new Size(86, 91);
            pictureBox8.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox8.TabIndex = 4;
            pictureBox8.TabStop = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Poppins", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.FromArgb(164, 172, 134);
            label7.Location = new Point(131, 32);
            label7.Margin = new Padding(5, 0, 5, 0);
            label7.Name = "label7";
            label7.Size = new Size(177, 50);
            label7.TabIndex = 3;
            label7.Text = "Login Page";
            // 
            // guna2Elipse1
            // 
            guna2Elipse1.BorderRadius = 10;
            guna2Elipse1.TargetControl = panel8;
            // 
            // guna2Elipse2
            // 
            guna2Elipse2.BorderRadius = 15;
            guna2Elipse2.TargetControl = this;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(13F, 36F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(88, 47, 14);
            ClientSize = new Size(789, 468);
            Controls.Add(panel8);
            Font = new Font("Poppins Medium", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(5);
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            panel8.ResumeLayout(false);
            panel8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel8;
        private Button AdditmBtn;
        private Guna.UI2.WinForms.Guna2TextBox PasswordTB;
        private Guna.UI2.WinForms.Guna2TextBox UsernameTB;
        private PictureBox pictureBox8;
        private Label label7;
        private Label LeaveTxtbtn;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse2;
    }
}