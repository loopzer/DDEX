namespace DDEXNetApp
{
    partial class FrmDDEX
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
			this.tRender = new System.Windows.Forms.Timer(this.components);
			this.picMain = new System.Windows.Forms.PictureBox();
			this.trackSecondValue = new System.Windows.Forms.TrackBar();
			this.btnScreenShot = new System.Windows.Forms.Button();
			this.btnMoreLoad = new System.Windows.Forms.Button();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.lblFrameTime = new System.Windows.Forms.ToolStripStatusLabel();
			this.lblAMemory = new System.Windows.Forms.ToolStripStatusLabel();
			this.btnPreloadAll = new System.Windows.Forms.Button();
			this.tbScene = new System.Windows.Forms.TabControl();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.rbWave = new System.Windows.Forms.RadioButton();
			this.rbSwinging = new System.Windows.Forms.RadioButton();
			this.rbRelief = new System.Windows.Forms.RadioButton();
			this.rbInvertTexture = new System.Windows.Forms.RadioButton();
			this.rbCustom = new System.Windows.Forms.RadioButton();
			this.rbNone = new System.Windows.Forms.RadioButton();
			this.rbBlue = new System.Windows.Forms.RadioButton();
			this.rbGreen = new System.Windows.Forms.RadioButton();
			this.rbRed = new System.Windows.Forms.RadioButton();
			this.rbGrayScale = new System.Windows.Forms.RadioButton();
			this.rbInverColor = new System.Windows.Forms.RadioButton();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.flpPresenterEffects = new System.Windows.Forms.FlowLayoutPanel();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.label4 = new System.Windows.Forms.Label();
			this.trackBlueLight = new System.Windows.Forms.TrackBar();
			this.label3 = new System.Windows.Forms.Label();
			this.trackGreenLight = new System.Windows.Forms.TrackBar();
			this.label2 = new System.Windows.Forms.Label();
			this.trackRedLight = new System.Windows.Forms.TrackBar();
			this.label1 = new System.Windows.Forms.Label();
			this.trackMasterLight = new System.Windows.Forms.TrackBar();
			this.tabPage4 = new System.Windows.Forms.TabPage();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.btnAnimateTime = new System.Windows.Forms.Button();
			this.txtStartTime = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.btnAnimateMasterInvertColor = new System.Windows.Forms.Button();
			this.txtMasterTIme = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.btnAnimateMasterColor = new System.Windows.Forms.Button();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.btnSelectColorTo = new System.Windows.Forms.Button();
			this.btnSelectColorFrom = new System.Windows.Forms.Button();
			this.tabPage5 = new System.Windows.Forms.TabPage();
			this.btnSceneAdd = new System.Windows.Forms.Button();
			this.btnSceneUp = new System.Windows.Forms.Button();
			this.btnSceneDown = new System.Windows.Forms.Button();
			this.btnSceneDelete = new System.Windows.Forms.Button();
			this.flpScene = new System.Windows.Forms.FlowLayoutPanel();
			this.tMasterAnimate = new System.Windows.Forms.Timer(this.components);
			this.trackTest = new System.Windows.Forms.TrackBar();
			this.lblTrackTestValue = new System.Windows.Forms.Label();
			this.lblTestSecondValue = new System.Windows.Forms.Label();
			this.tTree = new System.Windows.Forms.Timer(this.components);
			this.cmsScene = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.mnuAddImageRender = new System.Windows.Forms.ToolStripMenuItem();
			this.lightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuAddSingleFileAnimation = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuAddMultipleFileAnimation = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuAddText = new System.Windows.Forms.ToolStripMenuItem();
			((System.ComponentModel.ISupportInitialize)(this.picMain)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trackSecondValue)).BeginInit();
			this.statusStrip1.SuspendLayout();
			this.tbScene.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.trackBlueLight)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trackGreenLight)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trackRedLight)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trackMasterLight)).BeginInit();
			this.tabPage4.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.tabPage5.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.trackTest)).BeginInit();
			this.cmsScene.SuspendLayout();
			this.SuspendLayout();
			// 
			// tRender
			// 
			this.tRender.Interval = 3;
			this.tRender.Tick += new System.EventHandler(this.tRender_Tick);
			// 
			// picMain
			// 
			this.picMain.Location = new System.Drawing.Point(12, 12);
			this.picMain.Name = "picMain";
			this.picMain.Size = new System.Drawing.Size(839, 559);
			this.picMain.TabIndex = 0;
			this.picMain.TabStop = false;
			// 
			// trackSecondValue
			// 
			this.trackSecondValue.Location = new System.Drawing.Point(859, 497);
			this.trackSecondValue.Maximum = 360;
			this.trackSecondValue.Name = "trackSecondValue";
			this.trackSecondValue.Size = new System.Drawing.Size(421, 45);
			this.trackSecondValue.TabIndex = 3;
			this.trackSecondValue.Scroll += new System.EventHandler(this.trackAngle_Scroll);
			// 
			// btnScreenShot
			// 
			this.btnScreenShot.Location = new System.Drawing.Point(863, 548);
			this.btnScreenShot.Name = "btnScreenShot";
			this.btnScreenShot.Size = new System.Drawing.Size(75, 23);
			this.btnScreenShot.TabIndex = 12;
			this.btnScreenShot.Text = "Screenshot";
			this.btnScreenShot.UseVisualStyleBackColor = true;
			this.btnScreenShot.Click += new System.EventHandler(this.btnScreenShot_Click);
			// 
			// btnMoreLoad
			// 
			this.btnMoreLoad.Location = new System.Drawing.Point(944, 548);
			this.btnMoreLoad.Name = "btnMoreLoad";
			this.btnMoreLoad.Size = new System.Drawing.Size(75, 23);
			this.btnMoreLoad.TabIndex = 13;
			this.btnMoreLoad.Text = "More load";
			this.btnMoreLoad.UseVisualStyleBackColor = true;
			this.btnMoreLoad.Click += new System.EventHandler(this.btnMoreLoad_Click);
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblFrameTime,
            this.lblAMemory});
			this.statusStrip1.Location = new System.Drawing.Point(0, 594);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(1284, 22);
			this.statusStrip1.TabIndex = 14;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// lblFrameTime
			// 
			this.lblFrameTime.Name = "lblFrameTime";
			this.lblFrameTime.Size = new System.Drawing.Size(118, 17);
			this.lblFrameTime.Text = "toolStripStatusLabel1";
			// 
			// lblAMemory
			// 
			this.lblAMemory.Name = "lblAMemory";
			this.lblAMemory.Size = new System.Drawing.Size(118, 17);
			this.lblAMemory.Text = "toolStripStatusLabel1";
			// 
			// btnPreloadAll
			// 
			this.btnPreloadAll.Location = new System.Drawing.Point(1025, 548);
			this.btnPreloadAll.Name = "btnPreloadAll";
			this.btnPreloadAll.Size = new System.Drawing.Size(75, 23);
			this.btnPreloadAll.TabIndex = 15;
			this.btnPreloadAll.Text = "Preload";
			this.btnPreloadAll.UseVisualStyleBackColor = true;
			this.btnPreloadAll.Click += new System.EventHandler(this.btnPreloadAll_Click);
			// 
			// tbScene
			// 
			this.tbScene.Controls.Add(this.tabPage2);
			this.tbScene.Controls.Add(this.tabPage1);
			this.tbScene.Controls.Add(this.tabPage3);
			this.tbScene.Controls.Add(this.tabPage4);
			this.tbScene.Controls.Add(this.tabPage5);
			this.tbScene.Location = new System.Drawing.Point(863, 12);
			this.tbScene.Name = "tbScene";
			this.tbScene.SelectedIndex = 0;
			this.tbScene.Size = new System.Drawing.Size(421, 383);
			this.tbScene.TabIndex = 16;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.groupBox1);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(413, 357);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Render effects";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.rbWave);
			this.groupBox1.Controls.Add(this.rbSwinging);
			this.groupBox1.Controls.Add(this.rbRelief);
			this.groupBox1.Controls.Add(this.rbInvertTexture);
			this.groupBox1.Controls.Add(this.rbCustom);
			this.groupBox1.Controls.Add(this.rbNone);
			this.groupBox1.Controls.Add(this.rbBlue);
			this.groupBox1.Controls.Add(this.rbGreen);
			this.groupBox1.Controls.Add(this.rbRed);
			this.groupBox1.Controls.Add(this.rbGrayScale);
			this.groupBox1.Controls.Add(this.rbInverColor);
			this.groupBox1.Location = new System.Drawing.Point(6, 3);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(100, 301);
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Render effects";
			// 
			// rbWave
			// 
			this.rbWave.AutoSize = true;
			this.rbWave.Location = new System.Drawing.Point(4, 203);
			this.rbWave.Name = "rbWave";
			this.rbWave.Size = new System.Drawing.Size(54, 17);
			this.rbWave.TabIndex = 10;
			this.rbWave.TabStop = true;
			this.rbWave.Text = "Wave";
			this.rbWave.UseVisualStyleBackColor = true;
			// 
			// rbSwinging
			// 
			this.rbSwinging.AutoSize = true;
			this.rbSwinging.Location = new System.Drawing.Point(6, 180);
			this.rbSwinging.Name = "rbSwinging";
			this.rbSwinging.Size = new System.Drawing.Size(68, 17);
			this.rbSwinging.TabIndex = 9;
			this.rbSwinging.TabStop = true;
			this.rbSwinging.Text = "Swinging";
			this.rbSwinging.UseVisualStyleBackColor = true;
			// 
			// rbRelief
			// 
			this.rbRelief.AutoSize = true;
			this.rbRelief.Location = new System.Drawing.Point(6, 157);
			this.rbRelief.Name = "rbRelief";
			this.rbRelief.Size = new System.Drawing.Size(52, 17);
			this.rbRelief.TabIndex = 8;
			this.rbRelief.TabStop = true;
			this.rbRelief.Text = "Relief";
			this.rbRelief.UseVisualStyleBackColor = true;
			// 
			// rbInvertTexture
			// 
			this.rbInvertTexture.AutoSize = true;
			this.rbInvertTexture.Location = new System.Drawing.Point(9, 134);
			this.rbInvertTexture.Name = "rbInvertTexture";
			this.rbInvertTexture.Size = new System.Drawing.Size(87, 17);
			this.rbInvertTexture.TabIndex = 7;
			this.rbInvertTexture.TabStop = true;
			this.rbInvertTexture.Text = "Invert texture";
			this.rbInvertTexture.UseVisualStyleBackColor = true;
			// 
			// rbCustom
			// 
			this.rbCustom.AutoSize = true;
			this.rbCustom.Location = new System.Drawing.Point(5, 256);
			this.rbCustom.Name = "rbCustom";
			this.rbCustom.Size = new System.Drawing.Size(60, 17);
			this.rbCustom.TabIndex = 6;
			this.rbCustom.TabStop = true;
			this.rbCustom.Text = "Custom";
			this.rbCustom.UseVisualStyleBackColor = true;
			// 
			// rbNone
			// 
			this.rbNone.AutoSize = true;
			this.rbNone.Location = new System.Drawing.Point(5, 279);
			this.rbNone.Name = "rbNone";
			this.rbNone.Size = new System.Drawing.Size(51, 17);
			this.rbNone.TabIndex = 5;
			this.rbNone.TabStop = true;
			this.rbNone.Text = "None";
			this.rbNone.UseVisualStyleBackColor = true;
			// 
			// rbBlue
			// 
			this.rbBlue.AutoSize = true;
			this.rbBlue.Location = new System.Drawing.Point(9, 111);
			this.rbBlue.Name = "rbBlue";
			this.rbBlue.Size = new System.Drawing.Size(76, 17);
			this.rbBlue.TabIndex = 4;
			this.rbBlue.TabStop = true;
			this.rbBlue.Text = "Blue Scale";
			this.rbBlue.UseVisualStyleBackColor = true;
			// 
			// rbGreen
			// 
			this.rbGreen.AutoSize = true;
			this.rbGreen.Location = new System.Drawing.Point(9, 88);
			this.rbGreen.Name = "rbGreen";
			this.rbGreen.Size = new System.Drawing.Size(84, 17);
			this.rbGreen.TabIndex = 3;
			this.rbGreen.TabStop = true;
			this.rbGreen.Text = "Green Scale";
			this.rbGreen.UseVisualStyleBackColor = true;
			// 
			// rbRed
			// 
			this.rbRed.AutoSize = true;
			this.rbRed.Location = new System.Drawing.Point(9, 65);
			this.rbRed.Name = "rbRed";
			this.rbRed.Size = new System.Drawing.Size(75, 17);
			this.rbRed.TabIndex = 2;
			this.rbRed.TabStop = true;
			this.rbRed.Text = "Red Scale";
			this.rbRed.UseVisualStyleBackColor = true;
			// 
			// rbGrayScale
			// 
			this.rbGrayScale.AutoSize = true;
			this.rbGrayScale.Location = new System.Drawing.Point(9, 42);
			this.rbGrayScale.Name = "rbGrayScale";
			this.rbGrayScale.Size = new System.Drawing.Size(74, 17);
			this.rbGrayScale.TabIndex = 1;
			this.rbGrayScale.TabStop = true;
			this.rbGrayScale.Text = "GrayScale";
			this.rbGrayScale.UseVisualStyleBackColor = true;
			// 
			// rbInverColor
			// 
			this.rbInverColor.AutoSize = true;
			this.rbInverColor.Location = new System.Drawing.Point(9, 19);
			this.rbInverColor.Name = "rbInverColor";
			this.rbInverColor.Size = new System.Drawing.Size(78, 17);
			this.rbInverColor.TabIndex = 0;
			this.rbInverColor.TabStop = true;
			this.rbInverColor.Text = "Invert color";
			this.rbInverColor.UseVisualStyleBackColor = true;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.flpPresenterEffects);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(413, 357);
			this.tabPage1.TabIndex = 2;
			this.tabPage1.Text = "Present effects";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// flpPresenterEffects
			// 
			this.flpPresenterEffects.AutoScroll = true;
			this.flpPresenterEffects.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.flpPresenterEffects.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flpPresenterEffects.Location = new System.Drawing.Point(4, 0);
			this.flpPresenterEffects.Margin = new System.Windows.Forms.Padding(3, 25, 3, 3);
			this.flpPresenterEffects.Name = "flpPresenterEffects";
			this.flpPresenterEffects.Size = new System.Drawing.Size(404, 351);
			this.flpPresenterEffects.TabIndex = 5;
			this.flpPresenterEffects.WrapContents = false;
			// 
			// tabPage3
			// 
			this.tabPage3.Controls.Add(this.label4);
			this.tabPage3.Controls.Add(this.trackBlueLight);
			this.tabPage3.Controls.Add(this.label3);
			this.tabPage3.Controls.Add(this.trackGreenLight);
			this.tabPage3.Controls.Add(this.label2);
			this.tabPage3.Controls.Add(this.trackRedLight);
			this.tabPage3.Controls.Add(this.label1);
			this.tabPage3.Controls.Add(this.trackMasterLight);
			this.tabPage3.Location = new System.Drawing.Point(4, 22);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage3.Size = new System.Drawing.Size(413, 357);
			this.tabPage3.TabIndex = 3;
			this.tabPage3.Text = "Lights";
			this.tabPage3.UseVisualStyleBackColor = true;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(6, 221);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(61, 13);
			this.label4.TabIndex = 19;
			this.label4.Text = "Master light";
			// 
			// trackBlueLight
			// 
			this.trackBlueLight.Location = new System.Drawing.Point(3, 173);
			this.trackBlueLight.Maximum = 255;
			this.trackBlueLight.Name = "trackBlueLight";
			this.trackBlueLight.Size = new System.Drawing.Size(297, 45);
			this.trackBlueLight.TabIndex = 18;
			this.trackBlueLight.Value = 175;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(6, 157);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(50, 13);
			this.label3.TabIndex = 17;
			this.label3.Text = "Blue light";
			// 
			// trackGreenLight
			// 
			this.trackGreenLight.Location = new System.Drawing.Point(4, 101);
			this.trackGreenLight.Maximum = 255;
			this.trackGreenLight.Name = "trackGreenLight";
			this.trackGreenLight.Size = new System.Drawing.Size(297, 45);
			this.trackGreenLight.TabIndex = 16;
			this.trackGreenLight.Value = 175;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(6, 85);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(58, 13);
			this.label2.TabIndex = 15;
			this.label2.Text = "Green light";
			// 
			// trackRedLight
			// 
			this.trackRedLight.Location = new System.Drawing.Point(3, 29);
			this.trackRedLight.Maximum = 255;
			this.trackRedLight.Name = "trackRedLight";
			this.trackRedLight.Size = new System.Drawing.Size(297, 45);
			this.trackRedLight.TabIndex = 14;
			this.trackRedLight.Value = 175;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(7, 13);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(49, 13);
			this.label1.TabIndex = 13;
			this.label1.Text = "Red light";
			// 
			// trackMasterLight
			// 
			this.trackMasterLight.Location = new System.Drawing.Point(4, 237);
			this.trackMasterLight.Maximum = 255;
			this.trackMasterLight.Name = "trackMasterLight";
			this.trackMasterLight.Size = new System.Drawing.Size(297, 45);
			this.trackMasterLight.TabIndex = 12;
			this.trackMasterLight.Value = 175;
			this.trackMasterLight.Scroll += new System.EventHandler(this.trackMasterLight_Scroll);
			// 
			// tabPage4
			// 
			this.tabPage4.Controls.Add(this.groupBox3);
			this.tabPage4.Location = new System.Drawing.Point(4, 22);
			this.tabPage4.Name = "tabPage4";
			this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage4.Size = new System.Drawing.Size(413, 357);
			this.tabPage4.TabIndex = 4;
			this.tabPage4.Text = "Animates";
			this.tabPage4.UseVisualStyleBackColor = true;
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.btnAnimateTime);
			this.groupBox3.Controls.Add(this.txtStartTime);
			this.groupBox3.Controls.Add(this.label8);
			this.groupBox3.Controls.Add(this.btnAnimateMasterInvertColor);
			this.groupBox3.Controls.Add(this.txtMasterTIme);
			this.groupBox3.Controls.Add(this.label7);
			this.groupBox3.Controls.Add(this.btnAnimateMasterColor);
			this.groupBox3.Controls.Add(this.label6);
			this.groupBox3.Controls.Add(this.label5);
			this.groupBox3.Controls.Add(this.btnSelectColorTo);
			this.groupBox3.Controls.Add(this.btnSelectColorFrom);
			this.groupBox3.Location = new System.Drawing.Point(10, 6);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(291, 168);
			this.groupBox3.TabIndex = 0;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "MasterColorTo";
			// 
			// btnAnimateTime
			// 
			this.btnAnimateTime.Location = new System.Drawing.Point(48, 139);
			this.btnAnimateTime.Name = "btnAnimateTime";
			this.btnAnimateTime.Size = new System.Drawing.Size(75, 23);
			this.btnAnimateTime.TabIndex = 10;
			this.btnAnimateTime.Text = "Animate T";
			this.btnAnimateTime.UseVisualStyleBackColor = true;
			this.btnAnimateTime.Click += new System.EventHandler(this.btnAnimateTime_Click);
			// 
			// txtStartTime
			// 
			this.txtStartTime.Location = new System.Drawing.Point(90, 104);
			this.txtStartTime.Name = "txtStartTime";
			this.txtStartTime.Size = new System.Drawing.Size(195, 20);
			this.txtStartTime.TabIndex = 9;
			this.txtStartTime.Text = "1000";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(6, 109);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(52, 13);
			this.label8.TabIndex = 8;
			this.label8.Text = "StartTime";
			this.label8.Click += new System.EventHandler(this.label8_Click);
			// 
			// btnAnimateMasterInvertColor
			// 
			this.btnAnimateMasterInvertColor.Location = new System.Drawing.Point(210, 139);
			this.btnAnimateMasterInvertColor.Name = "btnAnimateMasterInvertColor";
			this.btnAnimateMasterInvertColor.Size = new System.Drawing.Size(75, 23);
			this.btnAnimateMasterInvertColor.TabIndex = 7;
			this.btnAnimateMasterInvertColor.Text = "!Animate";
			this.btnAnimateMasterInvertColor.UseVisualStyleBackColor = true;
			this.btnAnimateMasterInvertColor.Click += new System.EventHandler(this.btnAnimateMasterInvertColor_Click);
			// 
			// txtMasterTIme
			// 
			this.txtMasterTIme.Location = new System.Drawing.Point(90, 78);
			this.txtMasterTIme.Name = "txtMasterTIme";
			this.txtMasterTIme.Size = new System.Drawing.Size(195, 20);
			this.txtMasterTIme.TabIndex = 6;
			this.txtMasterTIme.Text = "1000";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(6, 83);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(49, 13);
			this.label7.TabIndex = 5;
			this.label7.Text = "Time(ms)";
			// 
			// btnAnimateMasterColor
			// 
			this.btnAnimateMasterColor.Location = new System.Drawing.Point(129, 139);
			this.btnAnimateMasterColor.Name = "btnAnimateMasterColor";
			this.btnAnimateMasterColor.Size = new System.Drawing.Size(75, 23);
			this.btnAnimateMasterColor.TabIndex = 4;
			this.btnAnimateMasterColor.Text = "Animate";
			this.btnAnimateMasterColor.UseVisualStyleBackColor = true;
			this.btnAnimateMasterColor.Click += new System.EventHandler(this.btnAnimateMasterColor_Click);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(6, 53);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(20, 13);
			this.label6.TabIndex = 3;
			this.label6.Text = "To";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(6, 24);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(30, 13);
			this.label5.TabIndex = 2;
			this.label5.Text = "From";
			// 
			// btnSelectColorTo
			// 
			this.btnSelectColorTo.Location = new System.Drawing.Point(90, 48);
			this.btnSelectColorTo.Name = "btnSelectColorTo";
			this.btnSelectColorTo.Size = new System.Drawing.Size(195, 23);
			this.btnSelectColorTo.TabIndex = 1;
			this.btnSelectColorTo.UseVisualStyleBackColor = true;
			this.btnSelectColorTo.Click += new System.EventHandler(this.btnSelectColorTo_Click);
			// 
			// btnSelectColorFrom
			// 
			this.btnSelectColorFrom.Location = new System.Drawing.Point(90, 19);
			this.btnSelectColorFrom.Name = "btnSelectColorFrom";
			this.btnSelectColorFrom.Size = new System.Drawing.Size(195, 23);
			this.btnSelectColorFrom.TabIndex = 0;
			this.btnSelectColorFrom.UseVisualStyleBackColor = true;
			this.btnSelectColorFrom.Click += new System.EventHandler(this.btnSelectColorFrom_Click);
			// 
			// tabPage5
			// 
			this.tabPage5.Controls.Add(this.btnSceneAdd);
			this.tabPage5.Controls.Add(this.btnSceneUp);
			this.tabPage5.Controls.Add(this.btnSceneDown);
			this.tabPage5.Controls.Add(this.btnSceneDelete);
			this.tabPage5.Controls.Add(this.flpScene);
			this.tabPage5.Location = new System.Drawing.Point(4, 22);
			this.tabPage5.Name = "tabPage5";
			this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage5.Size = new System.Drawing.Size(413, 357);
			this.tabPage5.TabIndex = 5;
			this.tabPage5.Text = "Escena";
			this.tabPage5.UseVisualStyleBackColor = true;
			// 
			// btnSceneAdd
			// 
			this.btnSceneAdd.Location = new System.Drawing.Point(6, 6);
			this.btnSceneAdd.Name = "btnSceneAdd";
			this.btnSceneAdd.Size = new System.Drawing.Size(75, 23);
			this.btnSceneAdd.TabIndex = 4;
			this.btnSceneAdd.Text = "Add";
			this.btnSceneAdd.UseVisualStyleBackColor = true;
			this.btnSceneAdd.Click += new System.EventHandler(this.btnSceneAdd_Click);
			// 
			// btnSceneUp
			// 
			this.btnSceneUp.Location = new System.Drawing.Point(170, 6);
			this.btnSceneUp.Name = "btnSceneUp";
			this.btnSceneUp.Size = new System.Drawing.Size(75, 23);
			this.btnSceneUp.TabIndex = 3;
			this.btnSceneUp.Text = "Up";
			this.btnSceneUp.UseVisualStyleBackColor = true;
			this.btnSceneUp.Click += new System.EventHandler(this.btnSceneUp_Click);
			// 
			// btnSceneDown
			// 
			this.btnSceneDown.Location = new System.Drawing.Point(251, 6);
			this.btnSceneDown.Name = "btnSceneDown";
			this.btnSceneDown.Size = new System.Drawing.Size(75, 23);
			this.btnSceneDown.TabIndex = 2;
			this.btnSceneDown.Text = "Down";
			this.btnSceneDown.UseVisualStyleBackColor = true;
			this.btnSceneDown.Click += new System.EventHandler(this.btnSceneDown_Click);
			// 
			// btnSceneDelete
			// 
			this.btnSceneDelete.Location = new System.Drawing.Point(332, 6);
			this.btnSceneDelete.Name = "btnSceneDelete";
			this.btnSceneDelete.Size = new System.Drawing.Size(75, 23);
			this.btnSceneDelete.TabIndex = 1;
			this.btnSceneDelete.Text = "Delete";
			this.btnSceneDelete.UseVisualStyleBackColor = true;
			// 
			// flpScene
			// 
			this.flpScene.AutoScroll = true;
			this.flpScene.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.flpScene.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flpScene.Location = new System.Drawing.Point(6, 39);
			this.flpScene.Margin = new System.Windows.Forms.Padding(3, 25, 3, 3);
			this.flpScene.Name = "flpScene";
			this.flpScene.Size = new System.Drawing.Size(404, 312);
			this.flpScene.TabIndex = 0;
			this.flpScene.WrapContents = false;
			// 
			// tMasterAnimate
			// 
			this.tMasterAnimate.Interval = 5;
			this.tMasterAnimate.Tick += new System.EventHandler(this.tMasterAnimate_Tick);
			// 
			// trackTest
			// 
			this.trackTest.Location = new System.Drawing.Point(857, 433);
			this.trackTest.Maximum = 360;
			this.trackTest.Name = "trackTest";
			this.trackTest.Size = new System.Drawing.Size(423, 45);
			this.trackTest.TabIndex = 17;
			this.trackTest.Scroll += new System.EventHandler(this.trackTest_Scroll);
			// 
			// lblTrackTestValue
			// 
			this.lblTrackTestValue.AutoSize = true;
			this.lblTrackTestValue.Location = new System.Drawing.Point(860, 412);
			this.lblTrackTestValue.Name = "lblTrackTestValue";
			this.lblTrackTestValue.Size = new System.Drawing.Size(0, 13);
			this.lblTrackTestValue.TabIndex = 18;
			// 
			// lblTestSecondValue
			// 
			this.lblTestSecondValue.AutoSize = true;
			this.lblTestSecondValue.Location = new System.Drawing.Point(864, 481);
			this.lblTestSecondValue.Name = "lblTestSecondValue";
			this.lblTestSecondValue.Size = new System.Drawing.Size(0, 13);
			this.lblTestSecondValue.TabIndex = 19;
			// 
			// tTree
			// 
			this.tTree.Enabled = true;
			this.tTree.Interval = 30;
			this.tTree.Tick += new System.EventHandler(this.tTree_Tick);
			// 
			// cmsScene
			// 
			this.cmsScene.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAddImageRender,
            this.lightToolStripMenuItem,
            this.mnuAddSingleFileAnimation,
            this.mnuAddMultipleFileAnimation,
            this.mnuAddText});
			this.cmsScene.Name = "cmsScene";
			this.cmsScene.Size = new System.Drawing.Size(195, 114);
			// 
			// mnuAddImageRender
			// 
			this.mnuAddImageRender.Name = "mnuAddImageRender";
			this.mnuAddImageRender.Size = new System.Drawing.Size(194, 22);
			this.mnuAddImageRender.Text = "Image";
			this.mnuAddImageRender.Click += new System.EventHandler(this.mnuAddImageRender_Click);
			// 
			// lightToolStripMenuItem
			// 
			this.lightToolStripMenuItem.Name = "lightToolStripMenuItem";
			this.lightToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
			this.lightToolStripMenuItem.Text = "Light";
			// 
			// mnuAddSingleFileAnimation
			// 
			this.mnuAddSingleFileAnimation.Name = "mnuAddSingleFileAnimation";
			this.mnuAddSingleFileAnimation.Size = new System.Drawing.Size(194, 22);
			this.mnuAddSingleFileAnimation.Text = "Single file animation";
			this.mnuAddSingleFileAnimation.Click += new System.EventHandler(this.mnuAddSingleFileAnimation_Click);
			// 
			// mnuAddMultipleFileAnimation
			// 
			this.mnuAddMultipleFileAnimation.Name = "mnuAddMultipleFileAnimation";
			this.mnuAddMultipleFileAnimation.Size = new System.Drawing.Size(194, 22);
			this.mnuAddMultipleFileAnimation.Text = "Multiple file animation";
			this.mnuAddMultipleFileAnimation.Click += new System.EventHandler(this.mnuAddMultipleFileAnimation_Click);
			// 
			// mnuAddText
			// 
			this.mnuAddText.Name = "mnuAddText";
			this.mnuAddText.Size = new System.Drawing.Size(194, 22);
			this.mnuAddText.Text = "Text";
			this.mnuAddText.Click += new System.EventHandler(this.mnuAddText_Click);
			// 
			// FrmDDEX
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1284, 616);
			this.Controls.Add(this.lblTestSecondValue);
			this.Controls.Add(this.lblTrackTestValue);
			this.Controls.Add(this.trackTest);
			this.Controls.Add(this.tbScene);
			this.Controls.Add(this.btnPreloadAll);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.btnMoreLoad);
			this.Controls.Add(this.btnScreenShot);
			this.Controls.Add(this.trackSecondValue);
			this.Controls.Add(this.picMain);
			this.Name = "FrmDDEX";
			this.Text = "FrmDDEX";
			this.Load += new System.EventHandler(this.FrmDDEX_Load);
			((System.ComponentModel.ISupportInitialize)(this.picMain)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trackSecondValue)).EndInit();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.tbScene.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.tabPage1.ResumeLayout(false);
			this.tabPage3.ResumeLayout(false);
			this.tabPage3.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.trackBlueLight)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trackGreenLight)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trackRedLight)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trackMasterLight)).EndInit();
			this.tabPage4.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.tabPage5.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.trackTest)).EndInit();
			this.cmsScene.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer tRender;
        private System.Windows.Forms.PictureBox picMain;
        private System.Windows.Forms.TrackBar trackSecondValue;
        private System.Windows.Forms.Button btnScreenShot;
        private System.Windows.Forms.Button btnMoreLoad;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblAMemory;
        private System.Windows.Forms.Button btnPreloadAll;
        private System.Windows.Forms.TabControl tbScene;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbInvertTexture;
        private System.Windows.Forms.RadioButton rbCustom;
        private System.Windows.Forms.RadioButton rbNone;
        private System.Windows.Forms.RadioButton rbBlue;
        private System.Windows.Forms.RadioButton rbGreen;
        private System.Windows.Forms.RadioButton rbRed;
        private System.Windows.Forms.RadioButton rbGrayScale;
        private System.Windows.Forms.RadioButton rbInverColor;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TrackBar trackBlueLight;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TrackBar trackGreenLight;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar trackRedLight;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar trackMasterLight;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSelectColorTo;
        private System.Windows.Forms.Button btnSelectColorFrom;
        private System.Windows.Forms.TextBox txtMasterTIme;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnAnimateMasterColor;
        private System.Windows.Forms.Timer tMasterAnimate;
        private System.Windows.Forms.Button btnAnimateMasterInvertColor;
        private System.Windows.Forms.TrackBar trackTest;
        private System.Windows.Forms.TextBox txtStartTime;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnAnimateTime;
        private System.Windows.Forms.RadioButton rbRelief;
        private System.Windows.Forms.ToolStripStatusLabel lblFrameTime;
        private System.Windows.Forms.Label lblTrackTestValue;
        private System.Windows.Forms.Label lblTestSecondValue;
        private System.Windows.Forms.Timer tTree;
        private System.Windows.Forms.RadioButton rbWave;
        private System.Windows.Forms.RadioButton rbSwinging;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.FlowLayoutPanel flpScene;
        private System.Windows.Forms.Button btnSceneAdd;
        private System.Windows.Forms.Button btnSceneUp;
        private System.Windows.Forms.Button btnSceneDown;
        private System.Windows.Forms.Button btnSceneDelete;
        private System.Windows.Forms.ContextMenuStrip cmsScene;
        private System.Windows.Forms.ToolStripMenuItem mnuAddImageRender;
        private System.Windows.Forms.ToolStripMenuItem lightToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuAddSingleFileAnimation;
        private System.Windows.Forms.ToolStripMenuItem mnuAddMultipleFileAnimation;
        private System.Windows.Forms.FlowLayoutPanel flpPresenterEffects;
        private System.Windows.Forms.ToolStripMenuItem mnuAddText;
    }
}