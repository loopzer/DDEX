namespace DDEXNetApp
{
    partial class PresenterEffectControl
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
            this.chkEffect = new System.Windows.Forms.CheckBox();
            this.nudValue1 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nudValue2 = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.nudValue3 = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nudValue1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudValue2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudValue3)).BeginInit();
            this.SuspendLayout();
            // 
            // chkEffect
            // 
            this.chkEffect.AutoSize = true;
            this.chkEffect.Location = new System.Drawing.Point(3, 3);
            this.chkEffect.Name = "chkEffect";
            this.chkEffect.Size = new System.Drawing.Size(15, 14);
            this.chkEffect.TabIndex = 0;
            this.chkEffect.UseVisualStyleBackColor = true;
            // 
            // nudValue1
            // 
            this.nudValue1.Location = new System.Drawing.Point(156, 1);
            this.nudValue1.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.nudValue1.Minimum = new decimal(new int[] {
            2000,
            0,
            0,
            -2147483648});
            this.nudValue1.Name = "nudValue1";
            this.nudValue1.Size = new System.Drawing.Size(54, 20);
            this.nudValue1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(107, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Value 1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(216, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Value 2";
            // 
            // nudValue2
            // 
            this.nudValue2.Location = new System.Drawing.Point(265, 1);
            this.nudValue2.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.nudValue2.Minimum = new decimal(new int[] {
            2000,
            0,
            0,
            -2147483648});
            this.nudValue2.Name = "nudValue2";
            this.nudValue2.Size = new System.Drawing.Size(54, 20);
            this.nudValue2.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(324, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Value 3";
            // 
            // nudValue3
            // 
            this.nudValue3.Location = new System.Drawing.Point(373, 1);
            this.nudValue3.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.nudValue3.Minimum = new decimal(new int[] {
            2000,
            0,
            0,
            -2147483648});
            this.nudValue3.Name = "nudValue3";
            this.nudValue3.Size = new System.Drawing.Size(54, 20);
            this.nudValue3.TabIndex = 5;
            // 
            // PresenterEffectControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nudValue3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nudValue2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nudValue1);
            this.Controls.Add(this.chkEffect);
            this.Name = "PresenterEffectControl";
            this.Size = new System.Drawing.Size(433, 23);
            ((System.ComponentModel.ISupportInitialize)(this.nudValue1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudValue2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudValue3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkEffect;
        private System.Windows.Forms.NumericUpDown nudValue1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudValue2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudValue3;
    }
}
