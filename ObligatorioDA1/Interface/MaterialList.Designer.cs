namespace Interface
{
    partial class MaterialList
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
            this.btnAddNewMaterial = new System.Windows.Forms.Button();
            this.flpMaterials = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();

            this.btnAddNewMaterial.Location = new System.Drawing.Point(243, 63);
            this.btnAddNewMaterial.Name = "btnAddNewMaterial";
            this.btnAddNewMaterial.Size = new System.Drawing.Size(155, 23);
            this.btnAddNewMaterial.TabIndex = 1;
            this.btnAddNewMaterial.Text = "+ Add New Material";
            this.btnAddNewMaterial.UseVisualStyleBackColor = true;
            this.btnAddNewMaterial.Click += new System.EventHandler(this.btnAddNewMaterial_Click);

            this.flpMaterials.AutoScroll = true;
            this.flpMaterials.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpMaterials.Location = new System.Drawing.Point(147, 119);
            this.flpMaterials.Name = "flpMaterials";
            this.flpMaterials.Size = new System.Drawing.Size(368, 229);
            this.flpMaterials.TabIndex = 2;
            this.flpMaterials.WrapContents = false;

            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flpMaterials);
            this.Controls.Add(this.btnAddNewMaterial);
            this.Name = "MaterialList";
            this.Size = new System.Drawing.Size(677, 351);
            this.Load += new System.EventHandler(this.MaterialList_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAddNewMaterial;
        private System.Windows.Forms.FlowLayoutPanel flpMaterials;
    }
}
