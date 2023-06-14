namespace Interface
{
    partial class MaterialListElement
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
            this.btnDelete = new System.Windows.Forms.Button();
            this.lblMaterialName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblRed = new System.Windows.Forms.Label();
            this.lblGreen = new System.Windows.Forms.Label();
            this.lblBlue = new System.Windows.Forms.Label();
            this.picColorPreview = new System.Windows.Forms.PictureBox();
            this.lblRoughness = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picColorPreview)).BeginInit();
            this.SuspendLayout();

            this.btnDelete.Location = new System.Drawing.Point(212, 53);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 0;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            this.lblMaterialName.AutoSize = true;
            this.lblMaterialName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lblMaterialName.Location = new System.Drawing.Point(74, 25);
            this.lblMaterialName.Name = "lblMaterialName";
            this.lblMaterialName.Size = new System.Drawing.Size(72, 18);
            this.lblMaterialName.TabIndex = 1;
            this.lblMaterialName.Text = "                ";

            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label1.Location = new System.Drawing.Point(74, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "R:";

            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label2.Location = new System.Drawing.Point(148, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "G:";

            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label3.Location = new System.Drawing.Point(218, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "B:";

            this.lblRed.AutoSize = true;
            this.lblRed.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lblRed.Location = new System.Drawing.Point(100, 95);
            this.lblRed.Name = "lblRed";
            this.lblRed.Size = new System.Drawing.Size(32, 18);
            this.lblRed.TabIndex = 5;
            this.lblRed.Text = "255";

            this.lblGreen.AutoSize = true;
            this.lblGreen.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lblGreen.Location = new System.Drawing.Point(178, 95);
            this.lblGreen.Name = "lblGreen";
            this.lblGreen.Size = new System.Drawing.Size(32, 18);
            this.lblGreen.TabIndex = 6;
            this.lblGreen.Text = "255";

            this.lblBlue.AutoSize = true;
            this.lblBlue.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lblBlue.Location = new System.Drawing.Point(246, 95);
            this.lblBlue.Name = "lblBlue";
            this.lblBlue.Size = new System.Drawing.Size(32, 18);
            this.lblBlue.TabIndex = 7;
            this.lblBlue.Text = "255";
 
            this.picColorPreview.Location = new System.Drawing.Point(3, 38);
            this.picColorPreview.Name = "picColorPreview";
            this.picColorPreview.Size = new System.Drawing.Size(65, 50);
            this.picColorPreview.TabIndex = 8;
            this.picColorPreview.TabStop = false;

            this.lblRoughness.AutoSize = true;
            this.lblRoughness.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lblRoughness.Location = new System.Drawing.Point(74, 61);
            this.lblRoughness.Name = "lblRoughness";
            this.lblRoughness.Size = new System.Drawing.Size(108, 18);
            this.lblRoughness.TabIndex = 9;
            this.lblRoughness.Text = "                         ";

            this.lblType.AutoSize = true;
            this.lblType.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lblType.Location = new System.Drawing.Point(170, 25);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(108, 18);
            this.lblType.TabIndex = 10;
            this.lblType.Text = "                         ";

            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.lblRoughness);
            this.Controls.Add(this.picColorPreview);
            this.Controls.Add(this.lblBlue);
            this.Controls.Add(this.lblGreen);
            this.Controls.Add(this.lblRed);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblMaterialName);
            this.Controls.Add(this.btnDelete);
            this.Name = "MaterialListElement";
            this.Size = new System.Drawing.Size(288, 131);
            ((System.ComponentModel.ISupportInitialize)(this.picColorPreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label lblMaterialName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblRed;
        private System.Windows.Forms.Label lblGreen;
        private System.Windows.Forms.Label lblBlue;
        private System.Windows.Forms.PictureBox picColorPreview;
        private System.Windows.Forms.Label lblRoughness;
        private System.Windows.Forms.Label lblType;
    }
}
