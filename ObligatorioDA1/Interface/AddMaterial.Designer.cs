namespace Interface
{
    partial class AddMaterial
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            this.txtMaterialName = new System.Windows.Forms.TextBox();
            this.lblMaterialName = new System.Windows.Forms.Label();
            this.txtRed = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtGreen = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBlue = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblErrorMessage = new System.Windows.Forms.Label();
            this.rbMetallic = new System.Windows.Forms.RadioButton();
            this.rbLambertian = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblRoughness = new System.Windows.Forms.Label();
            this.txtRoughness = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
        
            this.txtMaterialName.Location = new System.Drawing.Point(196, 78);
            this.txtMaterialName.Name = "txtMaterialName";
            this.txtMaterialName.Size = new System.Drawing.Size(135, 20);
            this.txtMaterialName.TabIndex = 1;

            this.lblMaterialName.AutoSize = true;
            this.lblMaterialName.Location = new System.Drawing.Point(193, 51);
            this.lblMaterialName.Name = "lblMaterialName";
            this.lblMaterialName.Size = new System.Drawing.Size(35, 13);
            this.lblMaterialName.TabIndex = 2;
            this.lblMaterialName.Text = "Name";

            this.txtRed.Location = new System.Drawing.Point(196, 148);
            this.txtRed.Name = "txtRed";
            this.txtRed.Size = new System.Drawing.Size(73, 20);
            this.txtRed.TabIndex = 3;

            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(193, 123);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Red";

            this.txtGreen.Location = new System.Drawing.Point(275, 148);
            this.txtGreen.Name = "txtGreen";
            this.txtGreen.Size = new System.Drawing.Size(73, 20);
            this.txtGreen.TabIndex = 5;

            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(272, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Green";

            this.txtBlue.Location = new System.Drawing.Point(354, 148);
            this.txtBlue.Name = "txtBlue";
            this.txtBlue.Size = new System.Drawing.Size(73, 20);
            this.txtBlue.TabIndex = 7;

            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(351, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Blue";

            this.btnAdd.Location = new System.Drawing.Point(196, 250);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(80, 34);
            this.btnAdd.TabIndex = 9;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.TextChanged += new System.EventHandler(this.btnAdd_TextChanged);
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            this.btnCancel.Location = new System.Drawing.Point(354, 250);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 34);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            this.lblErrorMessage.AutoSize = true;
            this.lblErrorMessage.BackColor = System.Drawing.Color.Transparent;
            this.lblErrorMessage.ForeColor = System.Drawing.Color.Red;
            this.lblErrorMessage.Location = new System.Drawing.Point(187, 296);
            this.lblErrorMessage.Name = "lblErrorMessage";
            this.lblErrorMessage.Size = new System.Drawing.Size(82, 13);
            this.lblErrorMessage.TabIndex = 11;
            this.lblErrorMessage.Text = "                         ";

            this.rbMetallic.AutoSize = true;
            this.rbMetallic.Location = new System.Drawing.Point(37, 65);
            this.rbMetallic.Name = "rbMetallic";
            this.rbMetallic.Size = new System.Drawing.Size(61, 17);
            this.rbMetallic.TabIndex = 13;
            this.rbMetallic.Text = "Metallic";
            this.rbMetallic.UseVisualStyleBackColor = true;
            this.rbMetallic.CheckedChanged += new System.EventHandler(this.rbMetallic_CheckedChanged);

            this.rbLambertian.AutoSize = true;
            this.rbLambertian.Checked = true;
            this.rbLambertian.Location = new System.Drawing.Point(37, 42);
            this.rbLambertian.Name = "rbLambertian";
            this.rbLambertian.Size = new System.Drawing.Size(77, 17);
            this.rbLambertian.TabIndex = 14;
            this.rbLambertian.TabStop = true;
            this.rbLambertian.Text = "Lambertian";
            this.rbLambertian.UseVisualStyleBackColor = true;
 
            this.groupBox1.Controls.Add(this.rbMetallic);
            this.groupBox1.Controls.Add(this.rbLambertian);
            this.groupBox1.Location = new System.Drawing.Point(455, 45);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(197, 102);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select material Type";

            this.lblRoughness.AutoSize = true;
            this.lblRoughness.Location = new System.Drawing.Point(198, 185);
            this.lblRoughness.Name = "lblRoughness";
            this.lblRoughness.Size = new System.Drawing.Size(61, 13);
            this.lblRoughness.TabIndex = 16;
            this.lblRoughness.Text = "Roughness";
            this.lblRoughness.Visible = false;

            this.txtRoughness.Location = new System.Drawing.Point(196, 210);
            this.txtRoughness.Name = "txtRoughness";
            this.txtRoughness.Size = new System.Drawing.Size(73, 20);
            this.txtRoughness.TabIndex = 17;
            this.txtRoughness.Visible = false;

            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtRoughness);
            this.Controls.Add(this.lblRoughness);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblErrorMessage);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtBlue);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtGreen);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtRed);
            this.Controls.Add(this.lblMaterialName);
            this.Controls.Add(this.txtMaterialName);
            this.Name = "AddMaterial";
            this.Size = new System.Drawing.Size(677, 351);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMaterialName;
        private System.Windows.Forms.Label lblMaterialName;
        private System.Windows.Forms.TextBox txtRed;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtGreen;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBlue;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblErrorMessage;
        private System.Windows.Forms.RadioButton rbMetallic;
        private System.Windows.Forms.RadioButton rbLambertian;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblRoughness;
        private System.Windows.Forms.TextBox txtRoughness;
    }
}
