namespace Interface
{
    partial class AddSphere
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
            this.components = new System.ComponentModel.Container();
            this.txtFigureName = new System.Windows.Forms.TextBox();
            this.lblFigureName = new System.Windows.Forms.Label();
            this.txtFigureRadius = new System.Windows.Forms.TextBox();
            this.lblFigureRadius = new System.Windows.Forms.Label();
            this.btnAddSphere = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.SuspendLayout();
            // 
            // txtFigureName
            // 
            this.txtFigureName.Location = new System.Drawing.Point(53, 51);
            this.txtFigureName.Name = "txtFigureName";
            this.txtFigureName.Size = new System.Drawing.Size(135, 20);
            this.txtFigureName.TabIndex = 0;
            // 
            // lblFigureName
            // 
            this.lblFigureName.AutoSize = true;
            this.lblFigureName.Location = new System.Drawing.Point(53, 32);
            this.lblFigureName.Name = "lblFigureName";
            this.lblFigureName.Size = new System.Drawing.Size(44, 13);
            this.lblFigureName.TabIndex = 1;
            this.lblFigureName.Text = "Nombre";
            // 
            // txtFigureRadius
            // 
            this.txtFigureRadius.Location = new System.Drawing.Point(56, 107);
            this.txtFigureRadius.Name = "txtFigureRadius";
            this.txtFigureRadius.Size = new System.Drawing.Size(135, 20);
            this.txtFigureRadius.TabIndex = 2;
            // 
            // lblFigureRadius
            // 
            this.lblFigureRadius.AutoSize = true;
            this.lblFigureRadius.Location = new System.Drawing.Point(53, 91);
            this.lblFigureRadius.Name = "lblFigureRadius";
            this.lblFigureRadius.Size = new System.Drawing.Size(35, 13);
            this.lblFigureRadius.TabIndex = 3;
            this.lblFigureRadius.Text = "Radio";
            // 
            // btnAddSphere
            // 
            this.btnAddSphere.Location = new System.Drawing.Point(97, 194);
            this.btnAddSphere.Name = "btnAddSphere";
            this.btnAddSphere.Size = new System.Drawing.Size(80, 34);
            this.btnAddSphere.TabIndex = 4;
            this.btnAddSphere.Text = "Agregar";
            this.btnAddSphere.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(324, 194);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 34);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            // 
            // AddSphere
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAddSphere);
            this.Controls.Add(this.lblFigureRadius);
            this.Controls.Add(this.txtFigureRadius);
            this.Controls.Add(this.lblFigureName);
            this.Controls.Add(this.txtFigureName);
            this.Name = "AddSphere";
            this.Size = new System.Drawing.Size(470, 281);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFigureName;
        private System.Windows.Forms.Label lblFigureName;
        private System.Windows.Forms.TextBox txtFigureRadius;
        private System.Windows.Forms.Label lblFigureRadius;
        private System.Windows.Forms.Button btnAddSphere;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    }
}
