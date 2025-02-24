﻿namespace Interface
{
    partial class SceneListElement
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
            this.picPreview = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblSceneName = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.lblLastModification = new System.Windows.Forms.Label();
            this.btnEdit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).BeginInit();
            this.SuspendLayout();

            this.picPreview.Location = new System.Drawing.Point(3, 16);
            this.picPreview.Name = "picPreview";
            this.picPreview.Size = new System.Drawing.Size(75, 50);
            this.picPreview.TabIndex = 17;
            this.picPreview.TabStop = false;

            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label1.Location = new System.Drawing.Point(3, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 18);
            this.label1.TabIndex = 11;
            this.label1.Text = "Last Modification:";

            this.lblSceneName.AutoSize = true;
            this.lblSceneName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lblSceneName.Location = new System.Drawing.Point(87, 10);
            this.lblSceneName.Name = "lblSceneName";
            this.lblSceneName.Size = new System.Drawing.Size(72, 18);
            this.lblSceneName.TabIndex = 10;
            this.lblSceneName.Text = "                ";

            this.btnDelete.Location = new System.Drawing.Point(208, 83);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 9;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            this.lblLastModification.AutoSize = true;
            this.lblLastModification.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lblLastModification.Location = new System.Drawing.Point(133, 103);
            this.lblLastModification.Name = "lblLastModification";
            this.lblLastModification.Size = new System.Drawing.Size(72, 18);
            this.lblLastModification.TabIndex = 18;
            this.lblLastModification.Text = "                ";

            this.btnEdit.Location = new System.Drawing.Point(207, 29);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 19;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.lblLastModification);
            this.Controls.Add(this.picPreview);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblSceneName);
            this.Controls.Add(this.btnDelete);
            this.Name = "SceneListElement";
            this.Size = new System.Drawing.Size(285, 138);
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picPreview;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblSceneName;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label lblLastModification;
        private System.Windows.Forms.Button btnEdit;
    }
}
