﻿namespace Interface
{
    partial class MainMenu
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.btnFigures = new System.Windows.Forms.Button();
            this.btnMaterials = new System.Windows.Forms.Button();
            this.btnModels = new System.Windows.Forms.Button();
            this.btnScenes = new System.Windows.Forms.Button();
            this.btnSignOut = new System.Windows.Forms.Button();
            this.controlPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // btnFigures
            // 
            this.btnFigures.Location = new System.Drawing.Point(34, 52);
            this.btnFigures.Name = "btnFigures";
            this.btnFigures.Size = new System.Drawing.Size(81, 29);
            this.btnFigures.TabIndex = 0;
            this.btnFigures.Text = "Figures";
            this.btnFigures.UseVisualStyleBackColor = true;
            this.btnFigures.Click += new System.EventHandler(this.btnFigures_Click);
            // 
            // btnMaterials
            // 
            this.btnMaterials.Location = new System.Drawing.Point(34, 87);
            this.btnMaterials.Name = "btnMaterials";
            this.btnMaterials.Size = new System.Drawing.Size(81, 29);
            this.btnMaterials.TabIndex = 1;
            this.btnMaterials.Text = "Materials";
            this.btnMaterials.UseVisualStyleBackColor = true;
            this.btnMaterials.Click += new System.EventHandler(this.btnMaterials_Click);
            // 
            // btnModels
            // 
            this.btnModels.Location = new System.Drawing.Point(34, 122);
            this.btnModels.Name = "btnModels";
            this.btnModels.Size = new System.Drawing.Size(81, 29);
            this.btnModels.TabIndex = 2;
            this.btnModels.Text = "Models";
            this.btnModels.UseVisualStyleBackColor = true;
            this.btnModels.Click += new System.EventHandler(this.btnModels_Click);
            // 
            // btnScenes
            // 
            this.btnScenes.Location = new System.Drawing.Point(34, 157);
            this.btnScenes.Name = "btnScenes";
            this.btnScenes.Size = new System.Drawing.Size(81, 29);
            this.btnScenes.TabIndex = 3;
            this.btnScenes.Text = "Scenes";
            this.btnScenes.UseVisualStyleBackColor = true;
            this.btnScenes.Click += new System.EventHandler(this.btnScenes_Click);
            // 
            // btnSignOut
            // 
            this.btnSignOut.Location = new System.Drawing.Point(34, 279);
            this.btnSignOut.Name = "btnSignOut";
            this.btnSignOut.Size = new System.Drawing.Size(81, 29);
            this.btnSignOut.TabIndex = 4;
            this.btnSignOut.Text = "Sign Out";
            this.btnSignOut.UseVisualStyleBackColor = true;
            this.btnSignOut.Click += new System.EventHandler(this.btnSignOut_Click);
            // 
            // controlPanel
            // 
            this.controlPanel.AutoSize = true;
            this.controlPanel.Location = new System.Drawing.Point(121, 0);
            this.controlPanel.Name = "controlPanel";
            this.controlPanel.Size = new System.Drawing.Size(804, 351);
            this.controlPanel.TabIndex = 5;
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(929, 450);
            this.Controls.Add(this.controlPanel);
            this.Controls.Add(this.btnSignOut);
            this.Controls.Add(this.btnScenes);
            this.Controls.Add(this.btnModels);
            this.Controls.Add(this.btnMaterials);
            this.Controls.Add(this.btnFigures);
            this.Name = "MainMenu";
            this.Text = "RayTracing";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainMenu_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnFigures;
        private System.Windows.Forms.Button btnMaterials;
        private System.Windows.Forms.Button btnModels;
        private System.Windows.Forms.Button btnScenes;
        private System.Windows.Forms.Button btnSignOut;
        private System.Windows.Forms.FlowLayoutPanel controlPanel;
    }
}

