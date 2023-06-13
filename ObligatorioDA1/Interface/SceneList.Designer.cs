namespace Interface
{
    partial class SceneList
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
            this.btnAddNewScene = new System.Windows.Forms.Button();
            this.flpMaterials = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();

            this.btnAddNewScene.Location = new System.Drawing.Point(255, 31);
            this.btnAddNewScene.Name = "btnAddNewScene";
            this.btnAddNewScene.Size = new System.Drawing.Size(155, 23);
            this.btnAddNewScene.TabIndex = 2;
            this.btnAddNewScene.Text = "+ Add New Scene";
            this.btnAddNewScene.UseVisualStyleBackColor = true;
            this.btnAddNewScene.Click += new System.EventHandler(this.btnAddNewScene_Click);

            this.flpMaterials.AutoScroll = true;
            this.flpMaterials.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpMaterials.Location = new System.Drawing.Point(135, 104);
            this.flpMaterials.Name = "flpMaterials";
            this.flpMaterials.Size = new System.Drawing.Size(368, 229);
            this.flpMaterials.TabIndex = 5;
            this.flpMaterials.WrapContents = false;

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
