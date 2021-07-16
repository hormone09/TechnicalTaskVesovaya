using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MyIdentity;

namespace Vesovaya
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button_login_Click(object sender, EventArgs e)
        {
            bool IsUserAuthorized = !LocalDataManager.CurrentUserName.Equals("null");

            if(IsUserAuthorized)
            {
                UserInfo userForm = new UserInfo();
                userForm.Show();
            }
            else
            {
                LoginForm loginForm = new LoginForm();
                loginForm.Show();
            }
        }
    }
}
