namespace Interface
{
    partial class AddSphere
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
            this.components = new System.ComponentModel.Container();
            this.txtFigureName = new System.Windows.Forms.TextBox();
            this.lblFigureName = new System.Windows.Forms.Label();
            this.txtFigureRadius = new System.Windows.Forms.TextBox();
            this.lblFigureRadius = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.lblErrorMessage = new System.Windows.Forms.Label();
            this.SuspendLayout();

            this.txtFigureName.Location = new System.Drawing.Point(53, 51);
            this.txtFigureName.Name = "txtFigureName";
            this.txtFigureName.Size = new System.Drawing.Size(135, 20);
            this.txtFigureName.TabIndex = 0;

            this.lblFigureName.AutoSize = true;
            this.lblFigureName.Location = new System.Drawing.Point(53, 32);
            this.lblFigureName.Name = "lblFigureName";
            this.lblFigureName.Size = new System.Drawing.Size(35, 13);
            this.lblFigureName.TabIndex = 1;
            this.lblFigureName.Text = "Name";

            this.txtFigureRadius.Location = new System.Drawing.Point(56, 107);
            this.txtFigureRadius.Name = "txtFigureRadius";
            this.txtFigureRadius.Size = new System.Drawing.Size(135, 20);
            this.txtFigureRadius.TabIndex = 2;

            this.lblFigureRadius.AutoSize = true;
            this.lblFigureRadius.Location = new System.Drawing.Point(53, 91);
            this.lblFigureRadius.Name = "lblFigureRadius";
            this.lblFigureRadius.Size = new System.Drawing.Size(40, 13);
            this.lblFigureRadius.TabIndex = 3;
            this.lblFigureRadius.Text = "Radius";

            this.btnAdd.Location = new System.Drawing.Point(97, 194);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(80, 34);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            this.btnCancel.Location = new System.Drawing.Point(324, 194);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 34);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);

            this.lblErrorMessage.AutoSize = true;
            this.lblErrorMessage.ForeColor = System.Drawing.Color.Red;
            this.lblErrorMessage.Location = new System.Drawing.Point(94, 299);
            this.lblErrorMessage.Name = "lblErrorMessage";
            this.lblErrorMessage.Size = new System.Drawing.Size(0, 13);
            this.lblErrorMessage.TabIndex = 6;

            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblErrorMessage);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lblFigureRadius);
            this.Controls.Add(this.txtFigureRadius);
            this.Controls.Add(this.lblFigureName);
            this.Controls.Add(this.txtFigureName);
            this.Name = "AddSphere";
            this.Size = new System.Drawing.Size(677, 351);
            this.Load += new System.EventHandler(this.AddSphere_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFigureName;
        private System.Windows.Forms.Label lblFigureName;
        private System.Windows.Forms.TextBox txtFigureRadius;
        private System.Windows.Forms.Label lblFigureRadius;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Label lblErrorMessage;
    }
}
