namespace Interface
{
    partial class FigureList
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
            this.btnAddNewFigure = new System.Windows.Forms.Button();
            this.flpFigures = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();

            this.btnAddNewFigure.Location = new System.Drawing.Point(254, 66);
            this.btnAddNewFigure.Name = "btnAddNewFigure";
            this.btnAddNewFigure.Size = new System.Drawing.Size(155, 23);
            this.btnAddNewFigure.TabIndex = 0;
            this.btnAddNewFigure.Text = "+ Add New Figure";
            this.btnAddNewFigure.UseVisualStyleBackColor = true;
            this.btnAddNewFigure.Click += new System.EventHandler(this.btnAddNewFigure_Click);

            this.flpFigures.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpFigures.Location = new System.Drawing.Point(151, 110);
            this.flpFigures.Name = "flpFigures";
            this.flpFigures.Size = new System.Drawing.Size(362, 241);
            this.flpFigures.TabIndex = 1;

            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flpFigures);
            this.Controls.Add(this.btnAddNewFigure);
            this.Name = "FigureList";
            this.Size = new System.Drawing.Size(677, 351);
            this.Load += new System.EventHandler(this.FigureList_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAddNewFigure;
        private System.Windows.Forms.FlowLayoutPanel flpFigures;
    }
}
