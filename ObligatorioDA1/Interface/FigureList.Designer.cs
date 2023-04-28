namespace Interface
{
    partial class FigureList
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
            this.btnAddNewFigure = new System.Windows.Forms.Button();
            this.lstbFigures = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // btnAddNewFigure
            // 
            this.btnAddNewFigure.Location = new System.Drawing.Point(254, 66);
            this.btnAddNewFigure.Name = "btnAddNewFigure";
            this.btnAddNewFigure.Size = new System.Drawing.Size(155, 23);
            this.btnAddNewFigure.TabIndex = 0;
            this.btnAddNewFigure.Text = "+ Add New Figure";
            this.btnAddNewFigure.UseVisualStyleBackColor = true;
            // 
            // lstbFigures
            // 
            this.lstbFigures.FormattingEnabled = true;
            this.lstbFigures.Location = new System.Drawing.Point(254, 95);
            this.lstbFigures.Name = "lstbFigures";
            this.lstbFigures.Size = new System.Drawing.Size(155, 147);
            this.lstbFigures.TabIndex = 4;
            // 
            // FigureList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lstbFigures);
            this.Controls.Add(this.btnAddNewFigure);
            this.Name = "FigureList";
            this.Size = new System.Drawing.Size(677, 351);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAddNewFigure;
        private System.Windows.Forms.ListBox lstbFigures;
    }
}
