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
            this.SuspendLayout();
            // 
            // btnAddNewModel
            // 
            this.btnAddNewModel.Location = new System.Drawing.Point(123, 39);
            this.btnAddNewModel.Name = "btnAddNewModel";
            this.btnAddNewModel.Size = new System.Drawing.Size(155, 23);
            this.btnAddNewModel.TabIndex = 1;
            this.btnAddNewModel.Text = "+ Add New Model";
            this.btnAddNewModel.UseVisualStyleBackColor = true;
            // 
            // ModelList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnAddNewModel);
            this.Name = "ModelList";
            this.Size = new System.Drawing.Size(469, 284);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAddNewModel;
    }
}
