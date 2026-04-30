namespace SimplePaint
{
    partial class form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(form1));
            lblappname = new Label();
            ShapeGrpBx = new GroupBox();
            btnCircle = new Button();
            btnRectangle = new Button();
            btnLine = new Button();
            cmbColor = new ComboBox();
            ColorGrpBx = new GroupBox();
            WeightGrpBx = new GroupBox();
            trbLineWidth = new TrackBar();
            btnOpenFile = new Button();
            btnSaveFile = new Button();
            picCanvas = new PictureBox();
            panelCanvas = new Panel();
            ShapeGrpBx.SuspendLayout();
            ColorGrpBx.SuspendLayout();
            WeightGrpBx.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trbLineWidth).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picCanvas).BeginInit();
            panelCanvas.SuspendLayout();
            SuspendLayout();
            // 
            // lblappname
            // 
            lblappname.AutoSize = true;
            lblappname.Font = new Font("한컴 말랑말랑 Bold", 27.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 129);
            lblappname.ForeColor = Color.Navy;
            lblappname.Location = new Point(12, 9);
            lblappname.Name = "lblappname";
            lblappname.Size = new Size(233, 47);
            lblappname.TabIndex = 0;
            lblappname.Text = "Simple Paint";
            // 
            // ShapeGrpBx
            // 
            ShapeGrpBx.Controls.Add(btnCircle);
            ShapeGrpBx.Controls.Add(btnRectangle);
            ShapeGrpBx.Controls.Add(btnLine);
            ShapeGrpBx.Font = new Font("한컴 말랑말랑 Bold", 12F, FontStyle.Bold, GraphicsUnit.Point, 129);
            ShapeGrpBx.Location = new Point(12, 82);
            ShapeGrpBx.Name = "ShapeGrpBx";
            ShapeGrpBx.Size = new Size(302, 96);
            ShapeGrpBx.TabIndex = 1;
            ShapeGrpBx.TabStop = false;
            ShapeGrpBx.Text = "도형 선택";
            // 
            // btnCircle
            // 
            btnCircle.Image = (Image)resources.GetObject("btnCircle.Image");
            btnCircle.ImageAlign = ContentAlignment.TopCenter;
            btnCircle.Location = new Point(203, 27);
            btnCircle.Name = "btnCircle";
            btnCircle.Size = new Size(93, 61);
            btnCircle.TabIndex = 2;
            btnCircle.Text = "원";
            btnCircle.TextAlign = ContentAlignment.BottomCenter;
            btnCircle.UseVisualStyleBackColor = true;
            // 
            // btnRectangle
            // 
            btnRectangle.Image = (Image)resources.GetObject("btnRectangle.Image");
            btnRectangle.ImageAlign = ContentAlignment.TopCenter;
            btnRectangle.Location = new Point(105, 27);
            btnRectangle.Name = "btnRectangle";
            btnRectangle.Size = new Size(93, 61);
            btnRectangle.TabIndex = 1;
            btnRectangle.Text = "사각형";
            btnRectangle.TextAlign = ContentAlignment.BottomCenter;
            btnRectangle.UseVisualStyleBackColor = true;
            // 
            // btnLine
            // 
            btnLine.Image = (Image)resources.GetObject("btnLine.Image");
            btnLine.ImageAlign = ContentAlignment.TopCenter;
            btnLine.Location = new Point(6, 27);
            btnLine.Name = "btnLine";
            btnLine.Size = new Size(93, 61);
            btnLine.TabIndex = 0;
            btnLine.Text = "직선";
            btnLine.TextAlign = ContentAlignment.BottomCenter;
            btnLine.UseVisualStyleBackColor = true;
            // 
            // cmbColor
            // 
            cmbColor.FormattingEnabled = true;
            cmbColor.Items.AddRange(new object[] { "Black 검정", "Red 빨강", "Blue 파랑", "Green 녹색" });
            cmbColor.Location = new Point(6, 42);
            cmbColor.Name = "cmbColor";
            cmbColor.Size = new Size(134, 29);
            cmbColor.TabIndex = 2;
            // 
            // ColorGrpBx
            // 
            ColorGrpBx.Controls.Add(cmbColor);
            ColorGrpBx.Font = new Font("한컴 말랑말랑 Bold", 12F, FontStyle.Bold, GraphicsUnit.Point, 129);
            ColorGrpBx.Location = new Point(335, 82);
            ColorGrpBx.Name = "ColorGrpBx";
            ColorGrpBx.Size = new Size(146, 96);
            ColorGrpBx.TabIndex = 3;
            ColorGrpBx.TabStop = false;
            ColorGrpBx.Text = "색 선택";
            // 
            // WeightGrpBx
            // 
            WeightGrpBx.Controls.Add(trbLineWidth);
            WeightGrpBx.Font = new Font("한컴 말랑말랑 Bold", 12F, FontStyle.Bold, GraphicsUnit.Point, 129);
            WeightGrpBx.Location = new Point(502, 83);
            WeightGrpBx.Name = "WeightGrpBx";
            WeightGrpBx.Size = new Size(208, 96);
            WeightGrpBx.TabIndex = 4;
            WeightGrpBx.TabStop = false;
            WeightGrpBx.Text = "굵기 선택";
            // 
            // trbLineWidth
            // 
            trbLineWidth.Location = new Point(6, 42);
            trbLineWidth.Name = "trbLineWidth";
            trbLineWidth.Size = new Size(196, 45);
            trbLineWidth.TabIndex = 0;
            // 
            // btnOpenFile
            // 
            btnOpenFile.BackColor = Color.FromArgb(255, 255, 192);
            btnOpenFile.Font = new Font("한컴 말랑말랑 Bold", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 129);
            btnOpenFile.ForeColor = Color.FromArgb(64, 64, 0);
            btnOpenFile.Location = new Point(731, 108);
            btnOpenFile.Name = "btnOpenFile";
            btnOpenFile.Size = new Size(110, 70);
            btnOpenFile.TabIndex = 6;
            btnOpenFile.Text = "열기";
            btnOpenFile.UseVisualStyleBackColor = false;
            // 
            // btnSaveFile
            // 
            btnSaveFile.BackColor = Color.FromArgb(192, 255, 255);
            btnSaveFile.Font = new Font("한컴 말랑말랑 Bold", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 129);
            btnSaveFile.ForeColor = Color.FromArgb(0, 0, 64);
            btnSaveFile.Location = new Point(847, 108);
            btnSaveFile.Name = "btnSaveFile";
            btnSaveFile.Size = new Size(110, 70);
            btnSaveFile.TabIndex = 7;
            btnSaveFile.Text = "저장";
            btnSaveFile.UseVisualStyleBackColor = false;
            // 
            // picCanvas
            // 
            picCanvas.BackColor = Color.White;
            picCanvas.BorderStyle = BorderStyle.FixedSingle;
            picCanvas.Location = new Point(0, 3);
            picCanvas.Name = "picCanvas";
            picCanvas.Size = new Size(957, 459);
            picCanvas.TabIndex = 8;
            picCanvas.TabStop = false;
            // 
            // panelCanvas
            // 
            panelCanvas.AutoScroll = true;
            panelCanvas.Controls.Add(picCanvas);
            panelCanvas.Location = new Point(12, 184);
            panelCanvas.Name = "panelCanvas";
            panelCanvas.Size = new Size(960, 465);
            panelCanvas.TabIndex = 9;
            // 
            // form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 661);
            Controls.Add(panelCanvas);
            Controls.Add(btnSaveFile);
            Controls.Add(btnOpenFile);
            Controls.Add(WeightGrpBx);
            Controls.Add(ColorGrpBx);
            Controls.Add(ShapeGrpBx);
            Controls.Add(lblappname);
            Name = "form1";
            Text = "Simple Paint v1";
            ShapeGrpBx.ResumeLayout(false);
            ColorGrpBx.ResumeLayout(false);
            WeightGrpBx.ResumeLayout(false);
            WeightGrpBx.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trbLineWidth).EndInit();
            ((System.ComponentModel.ISupportInitialize)picCanvas).EndInit();
            panelCanvas.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblappname;
        private GroupBox ShapeGrpBx;
        private Button btnCircle;
        private Button btnRectangle;
        private Button btnLine;
        private ComboBox cmbColor;
        private GroupBox ColorGrpBx;
        private GroupBox WeightGrpBx;
        private TrackBar trbLineWidth;
        private Button btnOpenFile;
        private Button btnSaveFile;
        private PictureBox picCanvas;
        private Panel panelCanvas;
    }
}
