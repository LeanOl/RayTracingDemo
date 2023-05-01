namespace Interface
{
    partial class SignIn
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
            this.lblUsernameText = new System.Windows.Forms.Label();
            this.txtUseraname = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnSignUp = new System.Windows.Forms.Button();
            this.btnSignIn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblUsernameText
            // 
            this.lblUsernameText.AutoSize = true;
            this.lblUsernameText.Location = new System.Drawing.Point(140, 77);
            this.lblUsernameText.Name = "lblUsernameText";
            this.lblUsernameText.Size = new System.Drawing.Size(55, 13);
            this.lblUsernameText.TabIndex = 10;
            this.lblUsernameText.Text = "Username";
            // 
            // txtUseraname
            // 
            this.txtUseraname.Location = new System.Drawing.Point(201, 74);
            this.txtUseraname.Name = "txtUseraname";
            this.txtUseraname.Size = new System.Drawing.Size(156, 20);
            this.txtUseraname.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(140, 115);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Password";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(201, 112);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(156, 20);
            this.txtPassword.TabIndex = 11;
            // 
            // btnSignUp
            // 
            this.btnSignUp.Location = new System.Drawing.Point(359, 211);
            this.btnSignUp.Name = "btnSignUp";
            this.btnSignUp.Size = new System.Drawing.Size(127, 51);
            this.btnSignUp.TabIndex = 13;
            this.btnSignUp.Text = "Sign Up";
            this.btnSignUp.UseVisualStyleBackColor = true;
            this.btnSignUp.Click += new System.EventHandler(this.btnSignUp_Click);
            // 
            // btnSignIn
            // 
            this.btnSignIn.Location = new System.Drawing.Point(104, 211);
            this.btnSignIn.Name = "btnSignIn";
            this.btnSignIn.Size = new System.Drawing.Size(127, 51);
            this.btnSignIn.TabIndex = 14;
            this.btnSignIn.Text = "Sign In";
            this.btnSignIn.UseVisualStyleBackColor = true;
            this.btnSignIn.Click += new System.EventHandler(this.btnSignIn_Click);
            // 
            // SignIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 321);
            this.Controls.Add(this.btnSignIn);
            this.Controls.Add(this.btnSignUp);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblUsernameText);
            this.Controls.Add(this.txtUseraname);
            this.Name = "SignIn";
            this.Text = "SignIn";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SignIn_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUsernameText;
        private System.Windows.Forms.TextBox txtUseraname;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnSignUp;
        private System.Windows.Forms.Button btnSignIn;
    }
}