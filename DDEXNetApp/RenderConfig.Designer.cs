namespace DDEXNetApp
{
    partial class RenderConfig
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cbEffects = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.picLocation = new System.Windows.Forms.PictureBox();
            this.lblColor = new System.Windows.Forms.Label();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.btnColor = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.nudAlpha = new System.Windows.Forms.NumericUpDown();
            this.lblTrackValue2 = new System.Windows.Forms.Label();
            this.lblTrackValue1 = new System.Windows.Forms.Label();
            this.trackValue1 = new System.Windows.Forms.TrackBar();
            this.trackValue2 = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.nudRadius = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.chkAsLight = new System.Windows.Forms.CheckBox();
            this.chkNegativeLight = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.picLocation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAlpha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackValue1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackValue2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRadius)).BeginInit();
            this.SuspendLayout();
            // 
            // cbEffects
            // 
            this.cbEffects.FormattingEnabled = true;
            this.cbEffects.Location = new System.Drawing.Point(42, 12);
            this.cbEffects.Name = "cbEffects";
            this.cbEffects.Size = new System.Drawing.Size(121, 21);
            this.cbEffects.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Effect";
            // 
            // picLocation
            // 
            this.picLocation.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picLocation.Location = new System.Drawing.Point(363, 15);
            this.picLocation.Name = "picLocation";
            this.picLocation.Size = new System.Drawing.Size(187, 85);
            this.picLocation.TabIndex = 2;
            this.picLocation.TabStop = false;
            this.picLocation.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picLocation_MouseDown);
            this.picLocation.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picLocation_MouseMove);
            this.picLocation.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picLocation_MouseUp);
            // 
            // lblColor
            // 
            this.lblColor.AutoSize = true;
            this.lblColor.Location = new System.Drawing.Point(1, 46);
            this.lblColor.Name = "lblColor";
            this.lblColor.Size = new System.Drawing.Size(31, 13);
            this.lblColor.TabIndex = 3;
            this.lblColor.Text = "Color";
            // 
            // colorDialog
            // 
            this.colorDialog.Color = System.Drawing.Color.White;
            this.colorDialog.FullOpen = true;
            // 
            // btnColor
            // 
            this.btnColor.Location = new System.Drawing.Point(38, 41);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(125, 23);
            this.btnColor.TabIndex = 4;
            this.btnColor.UseVisualStyleBackColor = true;
            this.btnColor.Click += new System.EventHandler(this.btnColor_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(169, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Alpha";
            // 
            // nudAlpha
            // 
            this.nudAlpha.Location = new System.Drawing.Point(209, 44);
            this.nudAlpha.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudAlpha.Name = "nudAlpha";
            this.nudAlpha.Size = new System.Drawing.Size(50, 20);
            this.nudAlpha.TabIndex = 6;
            this.nudAlpha.ValueChanged += new System.EventHandler(this.nudAlpha_ValueChanged);
            // 
            // lblTrackValue2
            // 
            this.lblTrackValue2.AutoSize = true;
            this.lblTrackValue2.Location = new System.Drawing.Point(11, 174);
            this.lblTrackValue2.Name = "lblTrackValue2";
            this.lblTrackValue2.Size = new System.Drawing.Size(0, 13);
            this.lblTrackValue2.TabIndex = 23;
            // 
            // lblTrackValue1
            // 
            this.lblTrackValue1.AutoSize = true;
            this.lblTrackValue1.Location = new System.Drawing.Point(7, 105);
            this.lblTrackValue1.Name = "lblTrackValue1";
            this.lblTrackValue1.Size = new System.Drawing.Size(0, 13);
            this.lblTrackValue1.TabIndex = 22;
            // 
            // trackValue1
            // 
            this.trackValue1.Location = new System.Drawing.Point(-1, 178);
            this.trackValue1.Maximum = 360;
            this.trackValue1.Name = "trackValue1";
            this.trackValue1.Size = new System.Drawing.Size(343, 45);
            this.trackValue1.TabIndex = 21;
            this.trackValue1.Scroll += new System.EventHandler(this.trackValue1_Scroll);
            // 
            // trackValue2
            // 
            this.trackValue2.Location = new System.Drawing.Point(1, 242);
            this.trackValue2.Maximum = 360;
            this.trackValue2.Name = "trackValue2";
            this.trackValue2.Size = new System.Drawing.Size(341, 45);
            this.trackValue2.TabIndex = 20;
            this.trackValue2.Scroll += new System.EventHandler(this.trackValue2_Scroll);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "Effect values";
            // 
            // nudRadius
            // 
            this.nudRadius.Location = new System.Drawing.Point(209, 77);
            this.nudRadius.Maximum = new decimal(new int[] {
            4000,
            0,
            0,
            0});
            this.nudRadius.Name = "nudRadius";
            this.nudRadius.Size = new System.Drawing.Size(50, 20);
            this.nudRadius.TabIndex = 26;
            this.nudRadius.ValueChanged += new System.EventHandler(this.nudRadius_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(169, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 25;
            this.label4.Text = "Radius";
            // 
            // chkAsLight
            // 
            this.chkAsLight.AutoSize = true;
            this.chkAsLight.Location = new System.Drawing.Point(4, 78);
            this.chkAsLight.Name = "chkAsLight";
            this.chkAsLight.Size = new System.Drawing.Size(60, 17);
            this.chkAsLight.TabIndex = 28;
            this.chkAsLight.Text = "As light";
            this.chkAsLight.UseVisualStyleBackColor = true;
            this.chkAsLight.CheckedChanged += new System.EventHandler(this.chkAsLight_CheckedChanged);
            // 
            // chkNegativeLight
            // 
            this.chkNegativeLight.AutoSize = true;
            this.chkNegativeLight.Location = new System.Drawing.Point(70, 78);
            this.chkNegativeLight.Name = "chkNegativeLight";
            this.chkNegativeLight.Size = new System.Drawing.Size(69, 17);
            this.chkNegativeLight.TabIndex = 29;
            this.chkNegativeLight.Text = "Negative";
            this.chkNegativeLight.UseVisualStyleBackColor = true;
            this.chkNegativeLight.CheckedChanged += new System.EventHandler(this.chkNegativeLight_CheckedChanged);
            // 
            // RenderConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 296);
            this.Controls.Add(this.chkNegativeLight);
            this.Controls.Add(this.chkAsLight);
            this.Controls.Add(this.nudRadius);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblTrackValue2);
            this.Controls.Add(this.lblTrackValue1);
            this.Controls.Add(this.trackValue1);
            this.Controls.Add(this.trackValue2);
            this.Controls.Add(this.nudAlpha);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnColor);
            this.Controls.Add(this.lblColor);
            this.Controls.Add(this.picLocation);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbEffects);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "RenderConfig";
            this.Text = "RenderConfig";
            ((System.ComponentModel.ISupportInitialize)(this.picLocation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAlpha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackValue1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackValue2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRadius)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbEffects;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox picLocation;
        private System.Windows.Forms.Label lblColor;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.Button btnColor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudAlpha;
        private System.Windows.Forms.Label lblTrackValue2;
        private System.Windows.Forms.Label lblTrackValue1;
        private System.Windows.Forms.TrackBar trackValue1;
        private System.Windows.Forms.TrackBar trackValue2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudRadius;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkAsLight;
        private System.Windows.Forms.CheckBox chkNegativeLight;
    }
}