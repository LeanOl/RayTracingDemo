namespace Interface
{
    partial class ModelList
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
            this.btnAddNewModel = new System.Windows.Forms.Button();
            this.flpModels = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();

            this.btnAddNewModel.Location = new System.Drawing.Point(228, 57);
            this.btnAddNewModel.Name = "btnAddNewModel";
            this.btnAddNewModel.Size = new System.Drawing.Size(155, 23);
            this.btnAddNewModel.TabIndex = 1;
            this.btnAddNewModel.Text = "+ Add New Model";
            this.btnAddNewModel.UseVisualStyleBackColor = true;
            this.btnAddNewModel.Click += new System.EventHandler(this.btnAddNewModel_Click);

            this.flpModels.AutoScroll = true;
            this.flpModels.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpModels.Location = new System.Drawing.Point(130, 119);
            this.flpModels.Name = "flpModels";
            this.flpModels.Size = new System.Drawing.Size(368, 229);
            this.flpModels.TabIndex = 3;
            this.flpModels.WrapContents = false;

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
