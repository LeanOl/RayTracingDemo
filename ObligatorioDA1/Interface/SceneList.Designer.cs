namespace Interface
{
    partial class SceneList
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
            this.btnAddNewScene = new System.Windows.Forms.Button();
            this.lstbScenes = new System.Windows.Forms.ListBox();
            this.btnDeleteSelected = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAddNewScene
            // 
            this.btnAddNewScene.Location = new System.Drawing.Point(115, 37);
            this.btnAddNewScene.Name = "btnAddNewScene";
            this.btnAddNewScene.Size = new System.Drawing.Size(155, 23);
            this.btnAddNewScene.TabIndex = 2;
            this.btnAddNewScene.Text = "+ Add New Scene";
            this.btnAddNewScene.UseVisualStyleBackColor = true;
            // 
            // lstbScenes
            // 
            this.lstbScenes.FormattingEnabled = true;
            this.lstbScenes.Location = new System.Drawing.Point(115, 76);
            this.lstbScenes.Name = "lstbScenes";
            this.lstbScenes.Size = new System.Drawing.Size(155, 147);
            this.lstbScenes.TabIndex = 3;
            // 
            // btnDeleteSelected
            // 
            this.btnDeleteSelected.Location = new System.Drawing.Point(308, 76);
            this.btnDeleteSelected.Name = "btnDeleteSelected";
            this.btnDeleteSelected.Size = new System.Drawing.Size(104, 23);
            this.btnDeleteSelected.TabIndex = 4;
            this.btnDeleteSelected.Text = "- Delete Selected ";
            this.btnDeleteSelected.UseVisualStyleBackColor = true;
            // 
            // SceneList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnDeleteSelected);
            this.Controls.Add(this.lstbScenes);
            this.Controls.Add(this.btnAddNewScene);
            this.Name = "SceneList";
            this.Size = new System.Drawing.Size(424, 262);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAddNewScene;
        private System.Windows.Forms.ListBox lstbScenes;
        private System.Windows.Forms.Button btnDeleteSelected;
    }
}
