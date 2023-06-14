namespace Interface
{
    partial class EditScene
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
            this.picRenderedImage = new System.Windows.Forms.PictureBox();
            this.lblPositionedModels = new System.Windows.Forms.Label();
            this.lblModels = new System.Windows.Forms.Label();
            this.btnRender = new System.Windows.Forms.Button();
            this.txtLookFromX = new System.Windows.Forms.TextBox();
            this.txtLookFromY = new System.Windows.Forms.TextBox();
            this.txtLookFromZ = new System.Windows.Forms.TextBox();
            this.txtLookAtZ = new System.Windows.Forms.TextBox();
            this.txtLookAtY = new System.Windows.Forms.TextBox();
            this.txtLookAtX = new System.Windows.Forms.TextBox();
            this.txtFov = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblSceneName = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.lblLastRendered = new System.Windows.Forms.Label();
            this.lblOutdatedWarning = new System.Windows.Forms.Label();
            this.flpModels = new System.Windows.Forms.FlowLayoutPanel();
            this.flpPositionedModels = new System.Windows.Forms.FlowLayoutPanel();
            this.btnUpdateCamera = new System.Windows.Forms.Button();
            this.txtAperture = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btnRenderDefocus = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picRenderedImage)).BeginInit();
            this.SuspendLayout();
            // 
            // picRenderedImage
            // 
            this.picRenderedImage.Location = new System.Drawing.Point(196, 80);
            this.picRenderedImage.Name = "picRenderedImage";
            this.picRenderedImage.Size = new System.Drawing.Size(300, 200);
            this.picRenderedImage.TabIndex = 0;
            this.picRenderedImage.TabStop = false;
            // 
            // lblPositionedModels
            // 
            this.lblPositionedModels.AutoSize = true;
            this.lblPositionedModels.Location = new System.Drawing.Point(594, 66);
            this.lblPositionedModels.Name = "lblPositionedModels";
            this.lblPositionedModels.Size = new System.Drawing.Size(93, 13);
            this.lblPositionedModels.TabIndex = 3;
            this.lblPositionedModels.Text = "Positioned Models";
            // 
            // lblModels
            // 
            this.lblModels.AutoSize = true;
            this.lblModels.Location = new System.Drawing.Point(22, 79);
            this.lblModels.Name = "lblModels";
            this.lblModels.Size = new System.Drawing.Size(87, 13);
            this.lblModels.TabIndex = 4;
            this.lblModels.Text = "Available Models";
            // 
            // btnRender
            // 
            this.btnRender.Location = new System.Drawing.Point(412, 286);
            this.btnRender.Name = "btnRender";
            this.btnRender.Size = new System.Drawing.Size(75, 23);
            this.btnRender.TabIndex = 5;
            this.btnRender.Text = "Render";
            this.btnRender.UseVisualStyleBackColor = true;
            this.btnRender.Click += new System.EventHandler(this.btnRender_Click);
            // 
            // txtLookFromX
            // 
            this.txtLookFromX.Location = new System.Drawing.Point(156, 42);
            this.txtLookFromX.Name = "txtLookFromX";
            this.txtLookFromX.Size = new System.Drawing.Size(23, 20);
            this.txtLookFromX.TabIndex = 6;
            // 
            // txtLookFromY
            // 
            this.txtLookFromY.Location = new System.Drawing.Point(185, 42);
            this.txtLookFromY.Name = "txtLookFromY";
            this.txtLookFromY.Size = new System.Drawing.Size(23, 20);
            this.txtLookFromY.TabIndex = 7;
            // 
            // txtLookFromZ
            // 
            this.txtLookFromZ.Location = new System.Drawing.Point(214, 42);
            this.txtLookFromZ.Name = "txtLookFromZ";
            this.txtLookFromZ.Size = new System.Drawing.Size(23, 20);
            this.txtLookFromZ.TabIndex = 8;
            // 
            // txtLookAtZ
            // 
            this.txtLookAtZ.Location = new System.Drawing.Point(313, 42);
            this.txtLookAtZ.Name = "txtLookAtZ";
            this.txtLookAtZ.Size = new System.Drawing.Size(23, 20);
            this.txtLookAtZ.TabIndex = 11;
            // 
            // txtLookAtY
            // 
            this.txtLookAtY.Location = new System.Drawing.Point(284, 42);
            this.txtLookAtY.Name = "txtLookAtY";
            this.txtLookAtY.Size = new System.Drawing.Size(23, 20);
            this.txtLookAtY.TabIndex = 10;
            // 
            // txtLookAtX
            // 
            this.txtLookAtX.Location = new System.Drawing.Point(255, 42);
            this.txtLookAtX.Name = "txtLookAtX";
            this.txtLookAtX.Size = new System.Drawing.Size(23, 20);
            this.txtLookAtX.TabIndex = 9;
            // 
            // txtFov
            // 
            this.txtFov.Location = new System.Drawing.Point(359, 42);
            this.txtFov.Name = "txtFov";
            this.txtFov.Size = new System.Drawing.Size(49, 20);
            this.txtFov.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(356, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "FOV";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(252, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "LookAt";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(155, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Look From";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(158, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(14, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "X";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(188, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(14, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Y";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(219, 65);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(14, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Z";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(319, 65);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(14, 13);
            this.label7.TabIndex = 21;
            this.label7.Text = "Z";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(288, 65);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(14, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "Y";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(258, 65);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(14, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "X";
            // 
            // lblSceneName
            // 
            this.lblSceneName.AutoSize = true;
            this.lblSceneName.Location = new System.Drawing.Point(167, 7);
            this.lblSceneName.Name = "lblSceneName";
            this.lblSceneName.Size = new System.Drawing.Size(97, 13);
            this.lblSceneName.TabIndex = 22;
            this.lblSceneName.Text = "Name of the scene";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(34, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 30);
            this.button1.TabIndex = 23;
            this.button1.Text = "←";
            this.button1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(211, 338);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(80, 13);
            this.label10.TabIndex = 24;
            this.label10.Text = "Last Rendered:";
            // 
            // lblLastRendered
            // 
            this.lblLastRendered.AutoSize = true;
            this.lblLastRendered.Location = new System.Drawing.Point(297, 338);
            this.lblLastRendered.Name = "lblLastRendered";
            this.lblLastRendered.Size = new System.Drawing.Size(36, 13);
            this.lblLastRendered.TabIndex = 25;
            this.lblLastRendered.Text = "Never";
            // 
            // lblOutdatedWarning
            // 
            this.lblOutdatedWarning.AutoSize = true;
            this.lblOutdatedWarning.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.lblOutdatedWarning.Location = new System.Drawing.Point(213, 318);
            this.lblOutdatedWarning.Name = "lblOutdatedWarning";
            this.lblOutdatedWarning.Size = new System.Drawing.Size(119, 13);
            this.lblOutdatedWarning.TabIndex = 26;
            this.lblOutdatedWarning.Text = "⚠️ OUTDATED IMAGE";
            this.lblOutdatedWarning.Visible = false;
            // 
            // flpModels
            // 
            this.flpModels.AutoScroll = true;
            this.flpModels.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpModels.Location = new System.Drawing.Point(3, 95);
            this.flpModels.Name = "flpModels";
            this.flpModels.Size = new System.Drawing.Size(183, 241);
            this.flpModels.TabIndex = 27;
            this.flpModels.WrapContents = false;
            // 
            // flpPositionedModels
            // 
            this.flpPositionedModels.AutoScroll = true;
            this.flpPositionedModels.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpPositionedModels.Location = new System.Drawing.Point(509, 95);
            this.flpPositionedModels.Name = "flpPositionedModels";
            this.flpPositionedModels.Size = new System.Drawing.Size(169, 241);
            this.flpPositionedModels.TabIndex = 28;
            this.flpPositionedModels.WrapContents = false;
            // 
            // btnUpdateCamera
            // 
            this.btnUpdateCamera.Location = new System.Drawing.Point(482, 39);
            this.btnUpdateCamera.Name = "btnUpdateCamera";
            this.btnUpdateCamera.Size = new System.Drawing.Size(96, 23);
            this.btnUpdateCamera.TabIndex = 29;
            this.btnUpdateCamera.Text = "Update Values";
            this.btnUpdateCamera.UseVisualStyleBackColor = true;
            this.btnUpdateCamera.Click += new System.EventHandler(this.btnUpdateCamera_Click);
            // 
            // txtAperture
            // 
            this.txtAperture.Location = new System.Drawing.Point(422, 42);
            this.txtAperture.Name = "txtAperture";
            this.txtAperture.Size = new System.Drawing.Size(49, 20);
            this.txtAperture.TabIndex = 30;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(421, 26);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(47, 13);
            this.label11.TabIndex = 31;
            this.label11.Text = "Aperture";
            // 
            // btnRenderDefocus
            // 
            this.btnRenderDefocus.Location = new System.Drawing.Point(369, 313);
            this.btnRenderDefocus.Name = "btnRenderDefocus";
            this.btnRenderDefocus.Size = new System.Drawing.Size(118, 23);
            this.btnRenderDefocus.TabIndex = 32;
            this.btnRenderDefocus.Text = "Render with defocus";
            this.btnRenderDefocus.UseVisualStyleBackColor = true;
            this.btnRenderDefocus.Click += new System.EventHandler(this.btnRenderDefocus_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(197, 280);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(96, 23);
            this.btnSave.TabIndex = 33;
            this.btnSave.Text = "Save Render";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // EditScene
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnRenderDefocus);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtAperture);
            this.Controls.Add(this.btnUpdateCamera);
            this.Controls.Add(this.flpPositionedModels);
            this.Controls.Add(this.flpModels);
            this.Controls.Add(this.lblOutdatedWarning);
            this.Controls.Add(this.lblLastRendered);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblSceneName);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtFov);
            this.Controls.Add(this.txtLookAtZ);
            this.Controls.Add(this.txtLookAtY);
            this.Controls.Add(this.txtLookAtX);
            this.Controls.Add(this.txtLookFromZ);
            this.Controls.Add(this.txtLookFromY);
            this.Controls.Add(this.txtLookFromX);
            this.Controls.Add(this.btnRender);
            this.Controls.Add(this.lblModels);
            this.Controls.Add(this.lblPositionedModels);
            this.Controls.Add(this.picRenderedImage);
            this.Name = "EditScene";
            this.Size = new System.Drawing.Size(846, 390);
            this.Load += new System.EventHandler(this.EditScene_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picRenderedImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picRenderedImage;
        private System.Windows.Forms.Label lblPositionedModels;
        private System.Windows.Forms.Label lblModels;
        private System.Windows.Forms.Button btnRender;
        private System.Windows.Forms.TextBox txtLookFromX;
        private System.Windows.Forms.TextBox txtLookFromY;
        private System.Windows.Forms.TextBox txtLookFromZ;
        private System.Windows.Forms.TextBox txtLookAtZ;
        private System.Windows.Forms.TextBox txtLookAtY;
        private System.Windows.Forms.TextBox txtLookAtX;
        private System.Windows.Forms.TextBox txtFov;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblSceneName;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblLastRendered;
        private System.Windows.Forms.Label lblOutdatedWarning;
        private System.Windows.Forms.FlowLayoutPanel flpModels;
        private System.Windows.Forms.FlowLayoutPanel flpPositionedModels;
        private System.Windows.Forms.Button btnUpdateCamera;
        private System.Windows.Forms.TextBox txtAperture;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnRenderDefocus;
        private System.Windows.Forms.Button btnSave;
    }
}
