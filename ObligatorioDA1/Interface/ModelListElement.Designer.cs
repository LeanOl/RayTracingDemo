namespace Interface
{
    partial class ModelListElement
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.picPreview = new System.Windows.Forms.PictureBox();
            this.lblMaterial = new System.Windows.Forms.Label();
            this.lblFigure = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblModelName = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // picPreview
            // 
            this.picPreview.Location = new System.Drawing.Point(-1, 30);
            this.picPreview.Name = "picPreview";
            this.picPreview.Size = new System.Drawing.Size(75, 50);
            this.picPreview.TabIndex = 17;
            this.picPreview.TabStop = false;
            // 
            // lblMaterial
            // 
            this.lblMaterial.AutoSize = true;
            this.lblMaterial.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lblMaterial.Location = new System.Drawing.Point(153, 92);
            this.lblMaterial.Name = "lblMaterial";
            this.lblMaterial.Size = new System.Drawing.Size(101, 18);
            this.lblMaterial.TabIndex = 15;
            this.lblMaterial.Text = "Material name";
            // 
            // lblFigure
            // 
            this.lblFigure.AutoSize = true;
            this.lblFigure.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lblFigure.Location = new System.Drawing.Point(134, 69);
            this.lblFigure.Name = "lblFigure";
            this.lblFigure.Size = new System.Drawing.Size(90, 18);
            this.lblFigure.TabIndex = 14;
            this.lblFigure.Text = "Figure name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label2.Location = new System.Drawing.Point(76, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 18);
            this.label2.TabIndex = 12;
            this.label2.Text = "Material:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label1.Location = new System.Drawing.Point(75, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 18);
            this.label1.TabIndex = 11;
            this.label1.Text = "Figure:";
            // 
            // lblModelName
            // 
            this.lblModelName.AutoSize = true;
            this.lblModelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lblModelName.Location = new System.Drawing.Point(76, 15);
            this.lblModelName.Name = "lblModelName";
            this.lblModelName.Size = new System.Drawing.Size(72, 18);
            this.lblModelName.TabIndex = 10;
            this.lblModelName.Text = "                ";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(208, 45);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 9;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // ModelListElement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.picPreview);
            this.Controls.Add(this.lblMaterial);
            this.Controls.Add(this.lblFigure);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblModelName);
            this.Controls.Add(this.btnDelete);
            this.Name = "ModelListElement";
            this.Size = new System.Drawing.Size(282, 122);
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picPreview;
        private System.Windows.Forms.Label lblMaterial;
        private System.Windows.Forms.Label lblFigure;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblModelName;
        private System.Windows.Forms.Button btnDelete;
    }
}
