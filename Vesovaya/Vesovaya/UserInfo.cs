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
    public partial class UserInfo : Form
    {
        public UserInfo()
        {
            UserManager manager = new UserManager();
            var user = manager.GetUser(LocalDataManager.CurrentUserName);
            
            InitializeComponent(); 
            label_age.Text = Convert.ToString(user.Age);
            label_name.Text = user.Name;
            label_surname.Text = user.Surname;
            label_login.Text = user.UserName;
            label_date.Text = user.RegisterDate.ToLongDateString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SignManager manager = new SignManager();
            manager.SignOut(LocalDataManager.CurrentUserName);

            this.Close();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }
    }
}
