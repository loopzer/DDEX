namespace DDEXNetApp
{
    partial class FrmMain
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
            this.btnLoadPlugins = new System.Windows.Forms.Button();
            this.listBoxPlugins = new System.Windows.Forms.ListBox();
            this.btnLaunch = new System.Windows.Forms.Button();
            this.btnLaunchDefferal = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnLoadPlugins
            // 
            this.btnLoadPlugins.Location = new System.Drawing.Point(12, 113);
            this.btnLoadPlugins.Name = "btnLoadPlugins";
            this.btnLoadPlugins.Size = new System.Drawing.Size(195, 23);
            this.btnLoadPlugins.TabIndex = 0;
            this.btnLoadPlugins.Text = "Load plugins";
            this.btnLoadPlugins.UseVisualStyleBackColor = true;
            this.btnLoadPlugins.Click += new System.EventHandler(this.btnLoadPlugins_Click);
            // 
            // listBoxPlugins
            // 
            this.listBoxPlugins.FormattingEnabled = true;
            this.listBoxPlugins.Location = new System.Drawing.Point(12, 12);
            this.listBoxPlugins.Name = "listBoxPlugins";
            this.listBoxPlugins.Size = new System.Drawing.Size(195, 95);
            this.listBoxPlugins.TabIndex = 1;
            // 
            // btnLaunch
            // 
            this.btnLaunch.Location = new System.Drawing.Point(12, 142);
            this.btnLaunch.Name = "btnLaunch";
            this.btnLaunch.Size = new System.Drawing.Size(195, 23);
            this.btnLaunch.TabIndex = 2;
            this.btnLaunch.Text = "Launch";
            this.btnLaunch.UseVisualStyleBackColor = true;
            this.btnLaunch.Click += new System.EventHandler(this.btnLaunch_Click);
            // 
            // btnLaunchDefferal
            // 
            this.btnLaunchDefferal.Location = new System.Drawing.Point(12, 171);
            this.btnLaunchDefferal.Name = "btnLaunchDefferal";
            this.btnLaunchDefferal.Size = new System.Drawing.Size(195, 23);
            this.btnLaunchDefferal.TabIndex = 3;
            this.btnLaunchDefferal.Text = "Launch defferal";
            this.btnLaunchDefferal.UseVisualStyleBackColor = true;
            this.btnLaunchDefferal.Click += new System.EventHandler(this.btnLaunchDefferal_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 287);
            this.Controls.Add(this.btnLaunchDefferal);
            this.Controls.Add(this.btnLaunch);
            this.Controls.Add(this.listBoxPlugins);
            this.Controls.Add(this.btnLoadPlugins);
            this.Name = "FrmMain";
            this.Text = "DDEX App";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLoadPlugins;
        private System.Windows.Forms.ListBox listBoxPlugins;
        private System.Windows.Forms.Button btnLaunch;
        private System.Windows.Forms.Button btnLaunchDefferal;
    }
}

