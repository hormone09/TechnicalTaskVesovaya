
namespace Vesovaya
{
    partial class LoginForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Authorization = new System.Windows.Forms.Label();
            this.label_login = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textbox_login = new System.Windows.Forms.TextBox();
            this.textbox_password = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.Message = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Authorization
            // 
            this.Authorization.AutoSize = true;
            this.Authorization.Font = new System.Drawing.Font("Sitka Small", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Authorization.Location = new System.Drawing.Point(44, 33);
            this.Authorization.Name = "Authorization";
            this.Authorization.Size = new System.Drawing.Size(301, 59);
            this.Authorization.TabIndex = 0;
            this.Authorization.Text = "Авторизация";
            // 
            // label_login
            // 
            this.label_login.AutoSize = true;
            this.label_login.Font = new System.Drawing.Font("Sitka Small", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_login.Location = new System.Drawing.Point(44, 143);
            this.label_login.Name = "label_login";
            this.label_login.Size = new System.Drawing.Size(64, 24);
            this.label_login.TabIndex = 1;
            this.label_login.Text = "Логин";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Sitka Small", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(44, 221);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "Пароль";
            // 
            // textbox_login
            // 
            this.textbox_login.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textbox_login.Location = new System.Drawing.Point(134, 147);
            this.textbox_login.Name = "textbox_login";
            this.textbox_login.Size = new System.Drawing.Size(179, 29);
            this.textbox_login.TabIndex = 3;
            // 
            // textbox_password
            // 
            this.textbox_password.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textbox_password.Location = new System.Drawing.Point(134, 216);
            this.textbox_password.Name = "textbox_password";
            this.textbox_password.Size = new System.Drawing.Size(179, 29);
            this.textbox_password.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button1.Location = new System.Drawing.Point(134, 277);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(179, 39);
            this.button1.TabIndex = 5;
            this.button1.Text = "Войти";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.linkLabel1.LinkColor = System.Drawing.Color.Black;
            this.linkLabel1.Location = new System.Drawing.Point(175, 376);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(100, 21);
            this.linkLabel1.TabIndex = 6;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Регистарция";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // Message
            // 
            this.Message.AutoSize = true;
            this.Message.Location = new System.Drawing.Point(198, 342);
            this.Message.Name = "Message";
            this.Message.Size = new System.Drawing.Size(53, 15);
            this.Message.TabIndex = 16;
            this.Message.Text = "Message";
            this.Message.UseMnemonic = false;
            this.Message.Visible = false;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(395, 450);
            this.Controls.Add(this.Message);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textbox_password);
            this.Controls.Add(this.textbox_login);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label_login);
            this.Controls.Add(this.Authorization);
            this.Name = "LoginForm";
            this.Text = "LoginForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Authorization;
        private System.Windows.Forms.Label label_login;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textbox_login;
        private System.Windows.Forms.TextBox textbox_password;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label Message;
    }
}