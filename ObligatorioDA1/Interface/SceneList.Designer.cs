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
            this.flpMaterials = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // btnAddNewScene
            // 
            this.btnAddNewScene.Location = new System.Drawing.Point(255, 31);
            this.btnAddNewScene.Name = "btnAddNewScene";
            this.btnAddNewScene.Size = new System.Drawing.Size(155, 23);
            this.btnAddNewScene.TabIndex = 2;
            this.btnAddNewScene.Text = "+ Add New Scene";
            this.btnAddNewScene.UseVisualStyleBackColor = true;
            this.btnAddNewScene.Click += new System.EventHandler(this.btnAddNewScene_Click);
            // 
            // flpMaterials
            // 
            this.flpMaterials.AutoScroll = true;
            this.flpMaterials.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpMaterials.Location = new System.Drawing.Point(135, 104);
            this.flpMaterials.Name = "flpMaterials";
            this.flpMaterials.Size = new System.Drawing.Size(368, 229);
            this.flpMaterials.TabIndex = 5;
            this.flpMaterials.WrapContents = false;
            // 
            // SceneList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flpMaterials);
            this.Controls.Add(this.btnAddNewScene);
            this.Name = "SceneList";
            this.Size = new System.Drawing.Size(677, 351);
            this.Load += new System.EventHandler(this.SceneList_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAddNewScene;
        private System.Windows.Forms.FlowLayoutPanel flpMaterials;
    }
}
