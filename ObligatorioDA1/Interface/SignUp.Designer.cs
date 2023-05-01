namespace Interface
{
    partial class SignUp
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
            this.btnSignUp = new System.Windows.Forms.Button();
            this.txtUseraname = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtVerifyPassword = new System.Windows.Forms.TextBox();
            this.lblUsernameMessage = new System.Windows.Forms.Label();
            this.lblPasswordMessage = new System.Windows.Forms.Label();
            this.lblConfirmPasswordMessage = new System.Windows.Forms.Label();
            this.lblUsernameText = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblSignUpMessage = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSignUp
            // 
            this.btnSignUp.Location = new System.Drawing.Point(169, 242);
            this.btnSignUp.Name = "btnSignUp";
            this.btnSignUp.Size = new System.Drawing.Size(127, 51);
            this.btnSignUp.TabIndex = 1;
            this.btnSignUp.Text = "Sign Up";
            this.btnSignUp.UseVisualStyleBackColor = true;
            this.btnSignUp.Click += new System.EventHandler(this.btnSignUp_Click);
            // 
            // txtUseraname
            // 
            this.txtUseraname.Location = new System.Drawing.Point(249, 75);
            this.txtUseraname.Name = "txtUseraname";
            this.txtUseraname.Size = new System.Drawing.Size(156, 20);
            this.txtUseraname.TabIndex = 2;
            this.txtUseraname.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtUseraname_KeyUp);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(249, 117);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(156, 20);
            this.txtPassword.TabIndex = 3;
            this.txtPassword.UseSystemPasswordChar = true;
            this.txtPassword.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtPassword_KeyUp);
            // 
            // txtVerifyPassword
            // 
            this.txtVerifyPassword.Location = new System.Drawing.Point(249, 159);
            this.txtVerifyPassword.Name = "txtVerifyPassword";
            this.txtVerifyPassword.Size = new System.Drawing.Size(156, 20);
            this.txtVerifyPassword.TabIndex = 4;
            this.txtVerifyPassword.UseSystemPasswordChar = true;
            this.txtVerifyPassword.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtVerifyPassword_KeyUp);
            // 
            // lblUsernameMessage
            // 
            this.lblUsernameMessage.AutoSize = true;
            this.lblUsernameMessage.ForeColor = System.Drawing.Color.Red;
            this.lblUsernameMessage.Location = new System.Drawing.Point(256, 98);
            this.lblUsernameMessage.Name = "lblUsernameMessage";
            this.lblUsernameMessage.Size = new System.Drawing.Size(40, 13);
            this.lblUsernameMessage.TabIndex = 5;
            this.lblUsernameMessage.Text = "           ";
            // 
            // lblPasswordMessage
            // 
            this.lblPasswordMessage.AutoSize = true;
            this.lblPasswordMessage.ForeColor = System.Drawing.Color.Red;
            this.lblPasswordMessage.Location = new System.Drawing.Point(256, 140);
            this.lblPasswordMessage.Name = "lblPasswordMessage";
            this.lblPasswordMessage.Size = new System.Drawing.Size(40, 13);
            this.lblPasswordMessage.TabIndex = 6;
            this.lblPasswordMessage.Text = "           ";
            // 
            // lblConfirmPasswordMessage
            // 
            this.lblConfirmPasswordMessage.AutoSize = true;
            this.lblConfirmPasswordMessage.ForeColor = System.Drawing.Color.Red;
            this.lblConfirmPasswordMessage.Location = new System.Drawing.Point(256, 182);
            this.lblConfirmPasswordMessage.Name = "lblConfirmPasswordMessage";
            this.lblConfirmPasswordMessage.Size = new System.Drawing.Size(40, 13);
            this.lblConfirmPasswordMessage.TabIndex = 7;
            this.lblConfirmPasswordMessage.Text = "           ";
            // 
            // lblUsernameText
            // 
            this.lblUsernameText.AutoSize = true;
            this.lblUsernameText.Location = new System.Drawing.Point(188, 78);
            this.lblUsernameText.Name = "lblUsernameText";
            this.lblUsernameText.Size = new System.Drawing.Size(55, 13);
            this.lblUsernameText.TabIndex = 8;
            this.lblUsernameText.Text = "Username";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(419, 242);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(127, 51);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(188, 120);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(152, 162);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Confirm Password";
            // 
            // lblSignUpMessage
            // 
            this.lblSignUpMessage.AutoSize = true;
            this.lblSignUpMessage.ForeColor = System.Drawing.Color.Red;
            this.lblSignUpMessage.Location = new System.Drawing.Point(325, 221);
            this.lblSignUpMessage.Name = "lblSignUpMessage";
            this.lblSignUpMessage.Size = new System.Drawing.Size(43, 13);
            this.lblSignUpMessage.TabIndex = 12;
            this.lblSignUpMessage.Text = "            ";
            // 
            // SignUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 346);
            this.Controls.Add(this.lblSignUpMessage);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblUsernameText);
            this.Controls.Add(this.lblConfirmPasswordMessage);
            this.Controls.Add(this.lblPasswordMessage);
            this.Controls.Add(this.lblUsernameMessage);
            this.Controls.Add(this.txtVerifyPassword);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUseraname);
            this.Controls.Add(this.btnSignUp);
            this.Name = "SignUp";
            this.Text = "SignIn";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SignUp_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnSignUp;
        private System.Windows.Forms.TextBox txtUseraname;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtVerifyPassword;
        private System.Windows.Forms.Label lblUsernameMessage;
        private System.Windows.Forms.Label lblPasswordMessage;
        private System.Windows.Forms.Label lblConfirmPasswordMessage;
        private System.Windows.Forms.Label lblUsernameText;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblSignUpMessage;
    }
}