using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MyIdentity.Managers;
using MyIdentity;

namespace Vesovaya
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool IsValid = Handler.ParamsHandler(new string[] { textbox_login.Text, textbox_password.Text });
            if(IsValid)
            {
                SignManager signManager = new SignManager();
                var result = signManager.SignIn(textbox_login.Text, textbox_password.Text);
                if(result)
                {
                    this.Close();
                    UserInfo form = new UserInfo();
                    form.Show();
                }
                else
                {
                    Message.Text = "Данные введены неверно!";
                    Message.Visible = true;
                    Message.ForeColor = Color.Red;
                }
            }
            else
            {
                this.Close();
                var form = new LoginForm();
                form.Show();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
            RegisterForm form = new RegisterForm();
            form.Show();
        }
    }
}
