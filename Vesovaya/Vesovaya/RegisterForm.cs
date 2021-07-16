using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MyIdentity;
using MyIdentity.Managers;

namespace Vesovaya
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool IsValid = Handler.ParamsHandler(new string[] { textbox_login.Text, textbox_name.Text, textbox_surname.Text, 
                textbox_password.Text, textbox_password2.Text }) && numeric_age.Value > 15;
            bool IsPasswordsEquals = textbox_password.Text.Equals(textbox_password2.Text);

            if (IsValid && IsPasswordsEquals)
            {
                UserManager userManager = new UserManager();
                bool IsNewUserName = userManager.GetUser(textbox_login.Text) == null;
                if(IsNewUserName)
                {
                    User newUser = new User();
                    newUser.Name = textbox_name.Text;
                    newUser.Surname = textbox_surname.Text;
                    newUser.Age = Convert.ToInt32(numeric_age.Value);
                    newUser.UserName = textbox_login.Text;
                    newUser.RegisterDate = DateTime.Now;
                    bool result = userManager.CreateUserAsync(newUser, textbox_password.Text, Roles.user.ToString());
                    if(result)
                    {
                        Message.Visible = true;
                        Message.Text = "Пользователь добавлен!";
                        Message.ForeColor = Color.Green;
                        this.Close();
                        LoginForm loginForm = new LoginForm();
                        loginForm.Show();
                    }
                    else
                    {
                        if(Message.Visible != true)
                            Message.Visible = true;
                        Message.Text = "Произошла ошибка!";
                        Message.ForeColor = Color.Red;
                    }
                }
            }
            else
            {
                Message.Visible = true;
                Message.Text = "Данные заполнены неверно!";
                Message.ForeColor = Color.Red;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
            LoginForm form = new LoginForm();
            form.Show();
        }
    }
}
