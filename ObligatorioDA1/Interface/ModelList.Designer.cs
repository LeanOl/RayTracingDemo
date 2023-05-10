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
            this.flpModels = new System.Windows.Forms.FlowLayoutPanel();
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
            this.btnAddNewModel.Click += new System.EventHandler(this.btnAddNewModel_Click);
            // 
            // flpModels
            // 
            this.flpModels.AutoScroll = true;
            this.flpModels.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpModels.Location = new System.Drawing.Point(130, 119);
            this.flpModels.Name = "flpModels";
            this.flpModels.Size = new System.Drawing.Size(368, 229);
            this.flpModels.TabIndex = 3;
            this.flpModels.WrapContents = false;
            // 
            // ModelList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flpModels);
            this.Controls.Add(this.btnAddNewModel);
            this.Name = "ModelList";
            this.Size = new System.Drawing.Size(677, 351);
            this.Load += new System.EventHandler(this.ModelList_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAddNewModel;
        private System.Windows.Forms.FlowLayoutPanel flpModels;
    }
}
