namespace Interface
{
    partial class ModelList
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
            this.btnAddNewModel = new System.Windows.Forms.Button();
            this.lstbModels = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // btnAddNewModel
            // 
            this.btnAddNewModel.Location = new System.Drawing.Point(228, 57);
            this.btnAddNewModel.Name = "btnAddNewModel";
            this.btnAddNewModel.Size = new System.Drawing.Size(155, 23);
            this.btnAddNewModel.TabIndex = 1;
            this.btnAddNewModel.Text = "+ Add New Model";
            this.btnAddNewModel.UseVisualStyleBackColor = true;
            // 
            // lstbModels
            // 
            this.lstbModels.FormattingEnabled = true;
            this.lstbModels.Location = new System.Drawing.Point(185, 106);
            this.lstbModels.Name = "lstbModels";
            this.lstbModels.Size = new System.Drawing.Size(289, 147);
            this.lstbModels.TabIndex = 4;
            // 
            // ModelList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lstbModels);
            this.Controls.Add(this.btnAddNewModel);
            this.Name = "ModelList";
            this.Size = new System.Drawing.Size(677, 351);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAddNewModel;
        private System.Windows.Forms.ListBox lstbModels;
    }
}
