namespace Interface
{
    partial class MainMenu
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
            // 
            // btnMaterials
            // 
            this.btnMaterials.Location = new System.Drawing.Point(34, 87);
            this.btnMaterials.Name = "btnMaterials";
            this.btnMaterials.Size = new System.Drawing.Size(81, 29);
            this.btnMaterials.TabIndex = 1;
            this.btnMaterials.Text = "Materials";
            this.btnMaterials.UseVisualStyleBackColor = true;
            // 
            // btnModels
            // 
            this.btnModels.Location = new System.Drawing.Point(34, 122);
            this.btnModels.Name = "btnModels";
            this.btnModels.Size = new System.Drawing.Size(81, 29);
            this.btnModels.TabIndex = 2;
            this.btnModels.Text = "Models";
            this.btnModels.UseVisualStyleBackColor = true;
            // 
            // btnScenes
            // 
            this.btnScenes.Location = new System.Drawing.Point(34, 157);
            this.btnScenes.Name = "btnScenes";
            this.btnScenes.Size = new System.Drawing.Size(81, 29);
            this.btnScenes.TabIndex = 3;
            this.btnScenes.Text = "Scenes";
            this.btnScenes.UseVisualStyleBackColor = true;
            // 
            // btnSignOut
            // 
            this.btnSignOut.Location = new System.Drawing.Point(34, 279);
            this.btnSignOut.Name = "btnSignOut";
            this.btnSignOut.Size = new System.Drawing.Size(81, 29);
            this.btnSignOut.TabIndex = 4;
            this.btnSignOut.Text = "Sign Out";
            this.btnSignOut.UseVisualStyleBackColor = true;
            // 
            // controlPanel
            // 
            this.controlPanel.Location = new System.Drawing.Point(121, 0);
            this.controlPanel.Name = "controlPanel";
            this.controlPanel.Size = new System.Drawing.Size(677, 351);
            this.controlPanel.TabIndex = 5;
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.controlPanel);
            this.Controls.Add(this.btnSignOut);
            this.Controls.Add(this.btnScenes);
            this.Controls.Add(this.btnModels);
            this.Controls.Add(this.btnMaterials);
            this.Controls.Add(this.btnFigures);
            this.Name = "MainMenu";
            this.Text = "RayTracing";
            this.ResumeLayout(false);

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

