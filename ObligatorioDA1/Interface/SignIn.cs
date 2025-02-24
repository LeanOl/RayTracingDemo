﻿using System;
using System.Windows.Forms;
using Logic;

namespace Interface
{
    public partial class SignIn : Form
    {
        public SignIn()
        {
            InitializeComponent();
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            SignUp signUp = new SignUp();
            Hide();
            signUp.Show();

        }

        private void SignIn_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            try
            {
                string username = txtUseraname.Text;
                string password = txtPassword.Text;
                SessionLogic.Instance.LogIn(username,password);
                MainMenu menu = new MainMenu();
                Hide();
                menu.Show();
            }
            catch (Exception ex)
            {
                lblSignInMessage.Text = ex.Message;
            }
           
            
        }
    
    }
}
