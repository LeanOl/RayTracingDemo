using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Logic;

namespace Interface
{
    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            try
            {
                Instance.InstanceClientLogic.ValidateConfirmPassword(txtPassword.Text, txtVerifyPassword.Text);
                Instance.InstanceClientLogic.CreateClient(txtUseraname.Text,txtPassword.Text);
                SignIn signIn = new SignIn();
                Hide();
                signIn.Show();
                

            }
            catch (Exception ex)
            {
                lblSignUpMessage.Text = ex.Message;
            }
        }

        private void txtUseraname_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                Instance.InstanceClientLogic.ValidateUsername(txtUseraname.Text);
                lblUsernameMessage.Text = "";
            }
            catch (Exception ex)
            {
                lblUsernameMessage.Text = ex.Message;
            }
        }

        private void txtPassword_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                Instance.InstanceClientLogic.ValidatePassword(txtPassword.Text);
                Instance.InstanceClientLogic.ValidateConfirmPassword(txtPassword.Text, txtVerifyPassword.Text);
                lblPasswordMessage.Text = "";
            }
            catch (PasswordMismatchException ex)
            {
                lblConfirmPasswordMessage.Text = ex.Message;
                lblPasswordMessage.Text = "";
            }
            catch (Exception ex)
            {
                lblPasswordMessage.Text=ex.Message;
            }

        }

        private void txtVerifyPassword_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                Instance.InstanceClientLogic.ValidateConfirmPassword(txtPassword.Text,txtVerifyPassword.Text);
                lblConfirmPasswordMessage.Text = "";
            }
            catch (Exception ex)
            {
                lblConfirmPasswordMessage.Text = ex.Message;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            SignIn signIn = new SignIn();
            Hide();
            signIn.Show();
        }

        private void SignUp_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
