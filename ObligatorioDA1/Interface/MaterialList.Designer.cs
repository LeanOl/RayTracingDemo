namespace Interface
{
    partial class MaterialList
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
            this.btnAddNewMaterial = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAddNewMaterial
            // 
            this.btnAddNewMaterial.Location = new System.Drawing.Point(91, 23);
            this.btnAddNewMaterial.Name = "btnAddNewMaterial";
            this.btnAddNewMaterial.Size = new System.Drawing.Size(155, 23);
            this.btnAddNewMaterial.TabIndex = 1;
            this.btnAddNewMaterial.Text = "+ Add New Material";
            this.btnAddNewMaterial.UseVisualStyleBackColor = true;
            // 
            // MaterialList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnAddNewMaterial);
            this.Name = "MaterialList";
            this.Size = new System.Drawing.Size(398, 266);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAddNewMaterial;
    }
}
