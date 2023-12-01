namespace DDEXToolKit
{
    partial class FrmLightSimulator
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
            this.components = new System.ComponentModel.Container();
            this.grpLight = new System.Windows.Forms.GroupBox();
            this.lblBlueLightValue = new System.Windows.Forms.Label();
            this.lblGreenLightValue = new System.Windows.Forms.Label();
            this.lblRedLightValue = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.trackBlueLight = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.trackGreenLight = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.trackRedLight = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.trackMasterLight = new System.Windows.Forms.TrackBar();
            this.grpFireLight = new System.Windows.Forms.GroupBox();
            this.lblFireDiameterValue = new System.Windows.Forms.Label();
            this.lblFirediameter = new System.Windows.Forms.Label();
            this.trackFireDiameter = new System.Windows.Forms.TrackBar();
            this.lblBlueFireLightValue = new System.Windows.Forms.Label();
            this.lblGreenFireLightValue = new System.Windows.Forms.Label();
            this.lblRedFireLightValue = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.trackFireBlue = new System.Windows.Forms.TrackBar();
            this.label9 = new System.Windows.Forms.Label();
            this.trackFireGreen = new System.Windows.Forms.TrackBar();
            this.label10 = new System.Windows.Forms.Label();
            this.trackFireRed = new System.Windows.Forms.TrackBar();
            this.label11 = new System.Windows.Forms.Label();
            this.trackFireMaster = new System.Windows.Forms.TrackBar();
            this.picMain = new System.Windows.Forms.PictureBox();
            this.tRender = new System.Windows.Forms.Timer(this.components);
            this.grpLight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBlueLight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackGreenLight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackRedLight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackMasterLight)).BeginInit();
            this.grpFireLight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackFireDiameter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackFireBlue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackFireGreen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackFireRed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackFireMaster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMain)).BeginInit();
            this.SuspendLayout();
            // 
            // grpLight
            // 
            this.grpLight.Controls.Add(this.lblBlueLightValue);
            this.grpLight.Controls.Add(this.lblGreenLightValue);
            this.grpLight.Controls.Add(this.lblRedLightValue);
            this.grpLight.Controls.Add(this.label4);
            this.grpLight.Controls.Add(this.trackBlueLight);
            this.grpLight.Controls.Add(this.label3);
            this.grpLight.Controls.Add(this.trackGreenLight);
            this.grpLight.Controls.Add(this.label2);
            this.grpLight.Controls.Add(this.trackRedLight);
            this.grpLight.Controls.Add(this.label1);
            this.grpLight.Controls.Add(this.trackMasterLight);
            this.grpLight.Location = new System.Drawing.Point(558, 12);
            this.grpLight.Name = "grpLight";
            this.grpLight.Size = new System.Drawing.Size(309, 310);
            this.grpLight.TabIndex = 28;
            this.grpLight.TabStop = false;
            this.grpLight.Text = "Luz";
            // 
            // lblBlueLightValue
            // 
            this.lblBlueLightValue.AutoSize = true;
            this.lblBlueLightValue.Location = new System.Drawing.Point(241, 165);
            this.lblBlueLightValue.Name = "lblBlueLightValue";
            this.lblBlueLightValue.Size = new System.Drawing.Size(0, 13);
            this.lblBlueLightValue.TabIndex = 38;
            // 
            // lblGreenLightValue
            // 
            this.lblGreenLightValue.AutoSize = true;
            this.lblGreenLightValue.Location = new System.Drawing.Point(241, 93);
            this.lblGreenLightValue.Name = "lblGreenLightValue";
            this.lblGreenLightValue.Size = new System.Drawing.Size(0, 13);
            this.lblGreenLightValue.TabIndex = 37;
            // 
            // lblRedLightValue
            // 
            this.lblRedLightValue.AutoSize = true;
            this.lblRedLightValue.Location = new System.Drawing.Point(242, 21);
            this.lblRedLightValue.Name = "lblRedLightValue";
            this.lblRedLightValue.Size = new System.Drawing.Size(0, 13);
            this.lblRedLightValue.TabIndex = 36;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 229);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 13);
            this.label4.TabIndex = 35;
            this.label4.Text = "Todas las luces";
            // 
            // trackBlueLight
            // 
            this.trackBlueLight.Location = new System.Drawing.Point(5, 181);
            this.trackBlueLight.Maximum = 250;
            this.trackBlueLight.Minimum = -50;
            this.trackBlueLight.Name = "trackBlueLight";
            this.trackBlueLight.Size = new System.Drawing.Size(297, 45);
            this.trackBlueLight.TabIndex = 34;
            this.trackBlueLight.Scroll += new System.EventHandler(this.Tracks_Scroll);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 165);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 33;
            this.label3.Text = "Azul";
            // 
            // trackGreenLight
            // 
            this.trackGreenLight.Location = new System.Drawing.Point(6, 109);
            this.trackGreenLight.Maximum = 250;
            this.trackGreenLight.Minimum = -50;
            this.trackGreenLight.Name = "trackGreenLight";
            this.trackGreenLight.Size = new System.Drawing.Size(297, 45);
            this.trackGreenLight.TabIndex = 32;
            this.trackGreenLight.Scroll += new System.EventHandler(this.Tracks_Scroll);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 31;
            this.label2.Text = "Verde";
            // 
            // trackRedLight
            // 
            this.trackRedLight.Location = new System.Drawing.Point(5, 37);
            this.trackRedLight.Maximum = 250;
            this.trackRedLight.Minimum = -50;
            this.trackRedLight.Name = "trackRedLight";
            this.trackRedLight.Size = new System.Drawing.Size(297, 45);
            this.trackRedLight.TabIndex = 30;
            this.trackRedLight.Scroll += new System.EventHandler(this.Tracks_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 29;
            this.label1.Text = "Rojo";
            // 
            // trackMasterLight
            // 
            this.trackMasterLight.Location = new System.Drawing.Point(6, 245);
            this.trackMasterLight.Maximum = 250;
            this.trackMasterLight.Minimum = -50;
            this.trackMasterLight.Name = "trackMasterLight";
            this.trackMasterLight.Size = new System.Drawing.Size(297, 45);
            this.trackMasterLight.TabIndex = 28;
            this.trackMasterLight.Scroll += new System.EventHandler(this.TrackMaster_Scroll);
            // 
            // grpFireLight
            // 
            this.grpFireLight.Controls.Add(this.lblFireDiameterValue);
            this.grpFireLight.Controls.Add(this.lblFirediameter);
            this.grpFireLight.Controls.Add(this.trackFireDiameter);
            this.grpFireLight.Controls.Add(this.lblBlueFireLightValue);
            this.grpFireLight.Controls.Add(this.lblGreenFireLightValue);
            this.grpFireLight.Controls.Add(this.lblRedFireLightValue);
            this.grpFireLight.Controls.Add(this.label8);
            this.grpFireLight.Controls.Add(this.trackFireBlue);
            this.grpFireLight.Controls.Add(this.label9);
            this.grpFireLight.Controls.Add(this.trackFireGreen);
            this.grpFireLight.Controls.Add(this.label10);
            this.grpFireLight.Controls.Add(this.trackFireRed);
            this.grpFireLight.Controls.Add(this.label11);
            this.grpFireLight.Controls.Add(this.trackFireMaster);
            this.grpFireLight.Location = new System.Drawing.Point(873, 12);
            this.grpFireLight.Name = "grpFireLight";
            this.grpFireLight.Size = new System.Drawing.Size(309, 342);
            this.grpFireLight.TabIndex = 39;
            this.grpFireLight.TabStop = false;
            this.grpFireLight.Text = "Fogata";
            // 
            // lblFireDiameterValue
            // 
            this.lblFireDiameterValue.AutoSize = true;
            this.lblFireDiameterValue.Location = new System.Drawing.Point(241, 277);
            this.lblFireDiameterValue.Name = "lblFireDiameterValue";
            this.lblFireDiameterValue.Size = new System.Drawing.Size(0, 13);
            this.lblFireDiameterValue.TabIndex = 41;
            // 
            // lblFirediameter
            // 
            this.lblFirediameter.AutoSize = true;
            this.lblFirediameter.Location = new System.Drawing.Point(9, 277);
            this.lblFirediameter.Name = "lblFirediameter";
            this.lblFirediameter.Size = new System.Drawing.Size(97, 13);
            this.lblFirediameter.TabIndex = 40;
            this.lblFirediameter.Text = "Diametro de fogata";
            // 
            // trackFireDiameter
            // 
            this.trackFireDiameter.Location = new System.Drawing.Point(7, 293);
            this.trackFireDiameter.Maximum = 500;
            this.trackFireDiameter.Minimum = 1;
            this.trackFireDiameter.Name = "trackFireDiameter";
            this.trackFireDiameter.Size = new System.Drawing.Size(297, 45);
            this.trackFireDiameter.TabIndex = 39;
            this.trackFireDiameter.Value = 80;
            this.trackFireDiameter.Scroll += new System.EventHandler(this.Tracks_Scroll);
            // 
            // lblBlueFireLightValue
            // 
            this.lblBlueFireLightValue.AutoSize = true;
            this.lblBlueFireLightValue.Location = new System.Drawing.Point(241, 165);
            this.lblBlueFireLightValue.Name = "lblBlueFireLightValue";
            this.lblBlueFireLightValue.Size = new System.Drawing.Size(0, 13);
            this.lblBlueFireLightValue.TabIndex = 38;
            // 
            // lblGreenFireLightValue
            // 
            this.lblGreenFireLightValue.AutoSize = true;
            this.lblGreenFireLightValue.Location = new System.Drawing.Point(241, 93);
            this.lblGreenFireLightValue.Name = "lblGreenFireLightValue";
            this.lblGreenFireLightValue.Size = new System.Drawing.Size(0, 13);
            this.lblGreenFireLightValue.TabIndex = 37;
            // 
            // lblRedFireLightValue
            // 
            this.lblRedFireLightValue.AutoSize = true;
            this.lblRedFireLightValue.Location = new System.Drawing.Point(242, 21);
            this.lblRedFireLightValue.Name = "lblRedFireLightValue";
            this.lblRedFireLightValue.Size = new System.Drawing.Size(0, 13);
            this.lblRedFireLightValue.TabIndex = 36;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 229);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 13);
            this.label8.TabIndex = 35;
            this.label8.Text = "Todas las luces";
            // 
            // trackFireBlue
            // 
            this.trackFireBlue.Location = new System.Drawing.Point(5, 181);
            this.trackFireBlue.Maximum = 255;
            this.trackFireBlue.Name = "trackFireBlue";
            this.trackFireBlue.Size = new System.Drawing.Size(297, 45);
            this.trackFireBlue.TabIndex = 34;
            this.trackFireBlue.Value = 125;
            this.trackFireBlue.Scroll += new System.EventHandler(this.Tracks_Scroll);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 165);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(27, 13);
            this.label9.TabIndex = 33;
            this.label9.Text = "Azul";
            // 
            // trackFireGreen
            // 
            this.trackFireGreen.Location = new System.Drawing.Point(6, 109);
            this.trackFireGreen.Maximum = 255;
            this.trackFireGreen.Name = "trackFireGreen";
            this.trackFireGreen.Size = new System.Drawing.Size(297, 45);
            this.trackFireGreen.TabIndex = 32;
            this.trackFireGreen.Value = 125;
            this.trackFireGreen.Scroll += new System.EventHandler(this.Tracks_Scroll);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(8, 93);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 13);
            this.label10.TabIndex = 31;
            this.label10.Text = "Verde";
            // 
            // trackFireRed
            // 
            this.trackFireRed.Location = new System.Drawing.Point(5, 37);
            this.trackFireRed.Maximum = 255;
            this.trackFireRed.Name = "trackFireRed";
            this.trackFireRed.Size = new System.Drawing.Size(297, 45);
            this.trackFireRed.TabIndex = 30;
            this.trackFireRed.Value = 125;
            this.trackFireRed.Scroll += new System.EventHandler(this.Tracks_Scroll);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(9, 21);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 13);
            this.label11.TabIndex = 29;
            this.label11.Text = "Rojo";
            // 
            // trackFireMaster
            // 
            this.trackFireMaster.Location = new System.Drawing.Point(6, 245);
            this.trackFireMaster.Maximum = 255;
            this.trackFireMaster.Name = "trackFireMaster";
            this.trackFireMaster.Size = new System.Drawing.Size(297, 45);
            this.trackFireMaster.TabIndex = 28;
            this.trackFireMaster.Value = 125;
            this.trackFireMaster.Scroll += new System.EventHandler(this.FireMaster_Scroll);
            // 
            // picMain
            // 
            this.picMain.Location = new System.Drawing.Point(12, 12);
            this.picMain.Name = "picMain";
            this.picMain.Size = new System.Drawing.Size(540, 418);
            this.picMain.TabIndex = 40;
            this.picMain.TabStop = false;
            // 
            // tRender
            // 
            this.tRender.Interval = 10;
            this.tRender.Tick += new System.EventHandler(this.tRender_Tick);
            // 
            // FrmLightSimulator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1195, 455);
            this.Controls.Add(this.picMain);
            this.Controls.Add(this.grpFireLight);
            this.Controls.Add(this.grpLight);
            this.Name = "FrmLightSimulator";
            this.Text = "Simulador de luces";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmLightSimulator_FormClosed);
            this.Load += new System.EventHandler(this.FrmLightSimulator_Load);
            this.grpLight.ResumeLayout(false);
            this.grpLight.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBlueLight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackGreenLight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackRedLight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackMasterLight)).EndInit();
            this.grpFireLight.ResumeLayout(false);
            this.grpFireLight.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackFireDiameter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackFireBlue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackFireGreen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackFireRed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackFireMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMain)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpLight;
        private System.Windows.Forms.Label lblBlueLightValue;
        private System.Windows.Forms.Label lblGreenLightValue;
        private System.Windows.Forms.Label lblRedLightValue;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TrackBar trackBlueLight;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TrackBar trackGreenLight;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar trackRedLight;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar trackMasterLight;
        private System.Windows.Forms.GroupBox grpFireLight;
        private System.Windows.Forms.Label lblBlueFireLightValue;
        private System.Windows.Forms.Label lblGreenFireLightValue;
        private System.Windows.Forms.Label lblRedFireLightValue;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TrackBar trackFireBlue;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TrackBar trackFireGreen;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TrackBar trackFireRed;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TrackBar trackFireMaster;
        private System.Windows.Forms.PictureBox picMain;
        private System.Windows.Forms.Timer tRender;
        private System.Windows.Forms.Label lblFireDiameterValue;
        private System.Windows.Forms.Label lblFirediameter;
        private System.Windows.Forms.TrackBar trackFireDiameter;
    }
}

