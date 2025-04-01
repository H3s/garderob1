using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Button = System.Windows.Forms.Button;
using TextBox = System.Windows.Forms.TextBox;
using ToolTip = System.Windows.Forms.ToolTip;

namespace garderob1
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblPhone;
        private MaskedTextBox txtPhone;
        private Label lblPassword;
        private TextBox txtPassword;
        private Button btnLogin;
        private Button btnRegister;
        private Label lblFullName;
        private TextBox txtFullName;
        private Label lblGroup;
        private TextBox txtGroup;
        private LinkLabel linkRegister;
        private LinkLabel linkBackToLogin;
        private ToolTip toolTip1 = new ToolTip();

        private void InitializeComponent()
        {
            lblPhone = new Label();
            txtPhone = new MaskedTextBox();
            lblPassword = new Label();
            txtPassword = new TextBox();
            btnLogin = new Button();
            btnRegister = new Button();
            lblFullName = new Label();
            txtFullName = new TextBox();
            lblGroup = new Label();
            txtGroup = new TextBox();
            linkRegister = new LinkLabel();
            linkBackToLogin = new LinkLabel();
            SuspendLayout();
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Location = new Point(25, 20);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(104, 15);
            lblPhone.TabIndex = 0;
            lblPhone.Text = "Номер телефона:";
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(25, 38);
            txtPhone.Mask = "+7(000)000-00-00";
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(300, 23);
            txtPhone.TabIndex = 1;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(25, 73);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(52, 15);
            lblPassword.TabIndex = 2;
            lblPassword.Text = "Пароль:";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(25, 91);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(300, 23);
            txtPassword.TabIndex = 3;
            // 
            // btnLogin
            // 
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Location = new Point(99, 121);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(150, 35);
            btnLogin.TabIndex = 4;
            btnLogin.Text = "Войти";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnRegister
            // 
            btnRegister.FlatStyle = FlatStyle.Flat;
            btnRegister.Location = new Point(99, 215);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(169, 35);
            btnRegister.TabIndex = 5;
            btnRegister.Text = "Зарегистрироваться";
            btnRegister.UseVisualStyleBackColor = true;
            btnRegister.Visible = false;
            btnRegister.Click += btnRegister_Click;
            // 
            // lblFullName
            // 
            lblFullName.AutoSize = true;
            lblFullName.Location = new Point(25, 121);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new Size(37, 15);
            lblFullName.TabIndex = 8;
            lblFullName.Text = "ФИО:";
            lblFullName.Visible = false;
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(25, 141);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(300, 23);
            txtFullName.TabIndex = 9;
            txtFullName.Visible = false;
            // 
            // lblGroup
            // 
            lblGroup.AutoSize = true;
            lblGroup.Location = new Point(25, 167);
            lblGroup.Name = "lblGroup";
            lblGroup.Size = new Size(49, 15);
            lblGroup.TabIndex = 10;
            lblGroup.Text = "Группа:";
            lblGroup.Visible = false;
            // 
            // txtGroup
            // 
            txtGroup.Location = new Point(25, 186);
            txtGroup.Name = "txtGroup";
            txtGroup.Size = new Size(300, 23);
            txtGroup.TabIndex = 11;
            txtGroup.Visible = false;
            // 
            // linkRegister
            // 
            linkRegister.AutoSize = true;
            linkRegister.Location = new Point(99, 159);
            linkRegister.Name = "linkRegister";
            linkRegister.Size = new Size(129, 15);
            linkRegister.TabIndex = 6;
            linkRegister.TabStop = true;
            linkRegister.Text = "Нет аккаунта? Создать";
            linkRegister.LinkClicked += linkRegister_LinkClicked;
            // 
            // linkBackToLogin
            // 
            linkBackToLogin.AutoSize = true;
            linkBackToLogin.Location = new Point(121, 253);
            linkBackToLogin.Name = "linkBackToLogin";
            linkBackToLogin.Size = new Size(106, 15);
            linkBackToLogin.TabIndex = 7;
            linkBackToLogin.TabStop = true;
            linkBackToLogin.Text = "Вернуться к входу";
            linkBackToLogin.Visible = false;
            linkBackToLogin.LinkClicked += linkBackToLogin_LinkClicked;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(347, 299);
            Controls.Add(txtGroup);
            Controls.Add(lblGroup);
            Controls.Add(txtFullName);
            Controls.Add(lblFullName);
            Controls.Add(linkBackToLogin);
            Controls.Add(linkRegister);
            Controls.Add(btnRegister);
            Controls.Add(btnLogin);
            Controls.Add(txtPassword);
            Controls.Add(lblPassword);
            Controls.Add(txtPhone);
            Controls.Add(lblPhone);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Авторизация";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}