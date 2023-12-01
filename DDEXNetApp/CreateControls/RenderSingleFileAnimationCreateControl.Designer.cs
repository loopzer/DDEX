namespace DDEXNetApp.CreateControls
{
    partial class RenderSingleFileAnimationCreateControl
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.nudRows = new System.Windows.Forms.NumericUpDown();
            this.nudCols = new System.Windows.Forms.NumericUpDown();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAccept = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.nudFrameTime = new System.Windows.Forms.NumericUpDown();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.ImageView = new System.Windows.Forms.ListView();
            ((System.ComponentModel.ISupportInitialize)(this.nudRows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCols)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFrameTime)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(543, 457);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Rows";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(456, 457);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Cols";
            // 
            // nudRows
            // 
            this.nudRows.Location = new System.Drawing.Point(583, 454);
            this.nudRows.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudRows.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudRows.Name = "nudRows";
            this.nudRows.Size = new System.Drawing.Size(43, 20);
            this.nudRows.TabIndex = 17;
            this.nudRows.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nudCols
            // 
            this.nudCols.Location = new System.Drawing.Point(489, 454);
            this.nudCols.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudCols.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudCols.Name = "nudCols";
            this.nudCols.Size = new System.Drawing.Size(47, 20);
            this.nudCols.TabIndex = 16;
            this.nudCols.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(906, 452);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(825, 452);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(75, 23);
            this.btnAccept.TabIndex = 12;
            this.btnAccept.Text = "Accept";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(624, 458);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "FrameTime";
            // 
            // nudFrameTime
            // 
            this.nudFrameTime.Location = new System.Drawing.Point(684, 455);
            this.nudFrameTime.Maximum = new decimal(new int[] {
            65000,
            0,
            0,
            0});
            this.nudFrameTime.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudFrameTime.Name = "nudFrameTime";
            this.nudFrameTime.Size = new System.Drawing.Size(73, 20);
            this.nudFrameTime.TabIndex = 20;
            this.nudFrameTime.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // imageList
            // 
            this.imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList.ImageSize = new System.Drawing.Size(100, 100);
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // ImageView
            // 
            this.ImageView.LargeImageList = this.imageList;
            this.ImageView.Location = new System.Drawing.Point(12, 12);
            this.ImageView.Name = "ImageView";
            this.ImageView.Size = new System.Drawing.Size(969, 434);
            this.ImageView.SmallImageList = this.imageList;
            this.ImageView.TabIndex = 22;
            this.ImageView.UseCompatibleStateImageBehavior = false;
            // 
            // RenderSingleFileAnimationCreateControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(986, 484);
            this.Controls.Add(this.ImageView);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nudFrameTime);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nudRows);
            this.Controls.Add(this.nudCols);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAccept);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RenderSingleFileAnimationCreateControl";
            this.Text = "RenderSingleFileAnimationCreateControl";
            this.Load += new System.EventHandler(this.RenderSingleFileAnimationCreateControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudRows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCols)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFrameTime)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudRows;
        private System.Windows.Forms.NumericUpDown nudCols;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudFrameTime;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.ListView ImageView;
    }
}