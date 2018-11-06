namespace Graphics2D
{
    partial class MainForm
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
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.groupBoxFile = new System.Windows.Forms.GroupBox();
            this.buttonLoadFile = new System.Windows.Forms.Button();
            this.buttonSaveFile = new System.Windows.Forms.Button();
            this.groupBoxTypeOfBrush = new System.Windows.Forms.GroupBox();
            this.radioButtonBrushTransparent = new System.Windows.Forms.RadioButton();
            this.radioButtonBrushPattern3 = new System.Windows.Forms.RadioButton();
            this.radioButtonBrushPattern2 = new System.Windows.Forms.RadioButton();
            this.radioButtonBrushPattern1 = new System.Windows.Forms.RadioButton();
            this.pictureBoxBrushColor = new System.Windows.Forms.PictureBox();
            this.radioButtonBrushColor = new System.Windows.Forms.RadioButton();
            this.groupBoxPens = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxWidth = new System.Windows.Forms.TextBox();
            this.radioButtonNull = new System.Windows.Forms.RadioButton();
            this.radioButtonDashDotDot = new System.Windows.Forms.RadioButton();
            this.radioButtonDashDot = new System.Windows.Forms.RadioButton();
            this.radioButtonDash = new System.Windows.Forms.RadioButton();
            this.radioButtonDot = new System.Windows.Forms.RadioButton();
            this.radioButtonSolid = new System.Windows.Forms.RadioButton();
            this.groupBoxColor = new System.Windows.Forms.GroupBox();
            this.pictureBoxPenColor = new System.Windows.Forms.PictureBox();
            this.groupBoxObject = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxPolygon = new System.Windows.Forms.TextBox();
            this.radioButtonEraser = new System.Windows.Forms.RadioButton();
            this.radioButtonPolygon = new System.Windows.Forms.RadioButton();
            this.radioButtonBezier = new System.Windows.Forms.RadioButton();
            this.radioButtonEllipse = new System.Windows.Forms.RadioButton();
            this.textBoxString = new System.Windows.Forms.TextBox();
            this.radioButtonRectangle = new System.Windows.Forms.RadioButton();
            this.radioButtonString = new System.Windows.Forms.RadioButton();
            this.radioButtonCircle = new System.Windows.Forms.RadioButton();
            this.radioButtonLine = new System.Windows.Forms.RadioButton();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.radioButtonRotate = new System.Windows.Forms.RadioButton();
            this.radioButtonZoom = new System.Windows.Forms.RadioButton();
            this.radioButtonMove = new System.Windows.Forms.RadioButton();
            this.radioButtonParabola = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.groupBoxFile.SuspendLayout();
            this.groupBoxTypeOfBrush.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBrushColor)).BeginInit();
            this.groupBoxPens.SuspendLayout();
            this.groupBoxColor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPenColor)).BeginInit();
            this.groupBoxObject.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.groupBoxFile);
            this.splitContainer.Panel1.Controls.Add(this.groupBoxTypeOfBrush);
            this.splitContainer.Panel1.Controls.Add(this.groupBoxPens);
            this.splitContainer.Panel1.Controls.Add(this.groupBoxColor);
            this.splitContainer.Panel1.Controls.Add(this.groupBoxObject);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.pictureBox);
            this.splitContainer.Size = new System.Drawing.Size(1216, 573);
            this.splitContainer.SplitterDistance = 314;
            this.splitContainer.TabIndex = 0;
            // 
            // groupBoxFile
            // 
            this.groupBoxFile.Controls.Add(this.buttonLoadFile);
            this.groupBoxFile.Controls.Add(this.buttonSaveFile);
            this.groupBoxFile.Location = new System.Drawing.Point(160, 487);
            this.groupBoxFile.Name = "groupBoxFile";
            this.groupBoxFile.Size = new System.Drawing.Size(147, 80);
            this.groupBoxFile.TabIndex = 4;
            this.groupBoxFile.TabStop = false;
            this.groupBoxFile.Text = "File";
            // 
            // buttonLoadFile
            // 
            this.buttonLoadFile.Location = new System.Drawing.Point(6, 48);
            this.buttonLoadFile.Name = "buttonLoadFile";
            this.buttonLoadFile.Size = new System.Drawing.Size(135, 23);
            this.buttonLoadFile.TabIndex = 1;
            this.buttonLoadFile.Text = "Load File ...";
            this.buttonLoadFile.UseVisualStyleBackColor = true;
            this.buttonLoadFile.Click += new System.EventHandler(this.buttonLoadFile_Click);
            // 
            // buttonSaveFile
            // 
            this.buttonSaveFile.Location = new System.Drawing.Point(6, 19);
            this.buttonSaveFile.Name = "buttonSaveFile";
            this.buttonSaveFile.Size = new System.Drawing.Size(135, 23);
            this.buttonSaveFile.TabIndex = 0;
            this.buttonSaveFile.Text = "Save File ...";
            this.buttonSaveFile.UseVisualStyleBackColor = true;
            this.buttonSaveFile.Click += new System.EventHandler(this.buttonSaveFile_Click);
            // 
            // groupBoxTypeOfBrush
            // 
            this.groupBoxTypeOfBrush.Controls.Add(this.radioButtonBrushTransparent);
            this.groupBoxTypeOfBrush.Controls.Add(this.radioButtonBrushPattern3);
            this.groupBoxTypeOfBrush.Controls.Add(this.radioButtonBrushPattern2);
            this.groupBoxTypeOfBrush.Controls.Add(this.radioButtonBrushPattern1);
            this.groupBoxTypeOfBrush.Controls.Add(this.pictureBoxBrushColor);
            this.groupBoxTypeOfBrush.Controls.Add(this.radioButtonBrushColor);
            this.groupBoxTypeOfBrush.Location = new System.Drawing.Point(10, 434);
            this.groupBoxTypeOfBrush.Name = "groupBoxTypeOfBrush";
            this.groupBoxTypeOfBrush.Size = new System.Drawing.Size(144, 133);
            this.groupBoxTypeOfBrush.TabIndex = 3;
            this.groupBoxTypeOfBrush.TabStop = false;
            this.groupBoxTypeOfBrush.Text = "Type of Brush";
            // 
            // radioButtonBrushTransparent
            // 
            this.radioButtonBrushTransparent.AutoSize = true;
            this.radioButtonBrushTransparent.Checked = true;
            this.radioButtonBrushTransparent.Location = new System.Drawing.Point(7, 20);
            this.radioButtonBrushTransparent.Name = "radioButtonBrushTransparent";
            this.radioButtonBrushTransparent.Size = new System.Drawing.Size(82, 17);
            this.radioButtonBrushTransparent.TabIndex = 6;
            this.radioButtonBrushTransparent.TabStop = true;
            this.radioButtonBrushTransparent.Text = "Transparent";
            this.radioButtonBrushTransparent.UseVisualStyleBackColor = true;
            // 
            // radioButtonBrushPattern3
            // 
            this.radioButtonBrushPattern3.AutoSize = true;
            this.radioButtonBrushPattern3.Location = new System.Drawing.Point(7, 112);
            this.radioButtonBrushPattern3.Name = "radioButtonBrushPattern3";
            this.radioButtonBrushPattern3.Size = new System.Drawing.Size(68, 17);
            this.radioButtonBrushPattern3.TabIndex = 5;
            this.radioButtonBrushPattern3.Text = "Pattern 3";
            this.radioButtonBrushPattern3.UseVisualStyleBackColor = true;
            // 
            // radioButtonBrushPattern2
            // 
            this.radioButtonBrushPattern2.AutoSize = true;
            this.radioButtonBrushPattern2.Location = new System.Drawing.Point(7, 89);
            this.radioButtonBrushPattern2.Name = "radioButtonBrushPattern2";
            this.radioButtonBrushPattern2.Size = new System.Drawing.Size(68, 17);
            this.radioButtonBrushPattern2.TabIndex = 4;
            this.radioButtonBrushPattern2.Text = "Pattern 2";
            this.radioButtonBrushPattern2.UseVisualStyleBackColor = true;
            // 
            // radioButtonBrushPattern1
            // 
            this.radioButtonBrushPattern1.AutoSize = true;
            this.radioButtonBrushPattern1.Location = new System.Drawing.Point(7, 66);
            this.radioButtonBrushPattern1.Name = "radioButtonBrushPattern1";
            this.radioButtonBrushPattern1.Size = new System.Drawing.Size(68, 17);
            this.radioButtonBrushPattern1.TabIndex = 3;
            this.radioButtonBrushPattern1.Text = "Pattern 1";
            this.radioButtonBrushPattern1.UseVisualStyleBackColor = true;
            // 
            // pictureBoxBrushColor
            // 
            this.pictureBoxBrushColor.Location = new System.Drawing.Point(75, 43);
            this.pictureBoxBrushColor.Name = "pictureBoxBrushColor";
            this.pictureBoxBrushColor.Size = new System.Drawing.Size(62, 17);
            this.pictureBoxBrushColor.TabIndex = 2;
            this.pictureBoxBrushColor.TabStop = false;
            this.pictureBoxBrushColor.Click += new System.EventHandler(this.pictureBoxBrushColor_Click);
            // 
            // radioButtonBrushColor
            // 
            this.radioButtonBrushColor.AutoSize = true;
            this.radioButtonBrushColor.Location = new System.Drawing.Point(7, 43);
            this.radioButtonBrushColor.Name = "radioButtonBrushColor";
            this.radioButtonBrushColor.Size = new System.Drawing.Size(48, 17);
            this.radioButtonBrushColor.TabIndex = 0;
            this.radioButtonBrushColor.Text = "Solid";
            this.radioButtonBrushColor.UseVisualStyleBackColor = true;
            // 
            // groupBoxPens
            // 
            this.groupBoxPens.Controls.Add(this.label1);
            this.groupBoxPens.Controls.Add(this.textBoxWidth);
            this.groupBoxPens.Controls.Add(this.radioButtonNull);
            this.groupBoxPens.Controls.Add(this.radioButtonDashDotDot);
            this.groupBoxPens.Controls.Add(this.radioButtonDashDot);
            this.groupBoxPens.Controls.Add(this.radioButtonDash);
            this.groupBoxPens.Controls.Add(this.radioButtonDot);
            this.groupBoxPens.Controls.Add(this.radioButtonSolid);
            this.groupBoxPens.Location = new System.Drawing.Point(10, 273);
            this.groupBoxPens.Name = "groupBoxPens";
            this.groupBoxPens.Size = new System.Drawing.Size(144, 155);
            this.groupBoxPens.TabIndex = 2;
            this.groupBoxPens.TabStop = false;
            this.groupBoxPens.Text = "Types of Pen";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(81, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Width";
            // 
            // textBoxWidth
            // 
            this.textBoxWidth.Location = new System.Drawing.Point(116, 18);
            this.textBoxWidth.Name = "textBoxWidth";
            this.textBoxWidth.Size = new System.Drawing.Size(22, 20);
            this.textBoxWidth.TabIndex = 6;
            this.textBoxWidth.Text = "1";
            // 
            // radioButtonNull
            // 
            this.radioButtonNull.AutoSize = true;
            this.radioButtonNull.Location = new System.Drawing.Point(6, 134);
            this.radioButtonNull.Name = "radioButtonNull";
            this.radioButtonNull.Size = new System.Drawing.Size(73, 17);
            this.radioButtonNull.TabIndex = 8;
            this.radioButtonNull.Text = "PS_NULL";
            this.radioButtonNull.UseVisualStyleBackColor = true;
            // 
            // radioButtonDashDotDot
            // 
            this.radioButtonDashDotDot.AutoSize = true;
            this.radioButtonDashDotDot.Location = new System.Drawing.Point(6, 111);
            this.radioButtonDashDotDot.Name = "radioButtonDashDotDot";
            this.radioButtonDashDotDot.Size = new System.Drawing.Size(121, 17);
            this.radioButtonDashDotDot.TabIndex = 7;
            this.radioButtonDashDotDot.Text = "PS_DASHDOTDOT";
            this.radioButtonDashDotDot.UseVisualStyleBackColor = true;
            // 
            // radioButtonDashDot
            // 
            this.radioButtonDashDot.AutoSize = true;
            this.radioButtonDashDot.Location = new System.Drawing.Point(6, 88);
            this.radioButtonDashDot.Name = "radioButtonDashDot";
            this.radioButtonDashDot.Size = new System.Drawing.Size(98, 17);
            this.radioButtonDashDot.TabIndex = 6;
            this.radioButtonDashDot.Text = "PS_DASHDOT";
            this.radioButtonDashDot.UseVisualStyleBackColor = true;
            // 
            // radioButtonDash
            // 
            this.radioButtonDash.AutoSize = true;
            this.radioButtonDash.Location = new System.Drawing.Point(6, 65);
            this.radioButtonDash.Name = "radioButtonDash";
            this.radioButtonDash.Size = new System.Drawing.Size(75, 17);
            this.radioButtonDash.TabIndex = 5;
            this.radioButtonDash.Text = "PS_DASH";
            this.radioButtonDash.UseVisualStyleBackColor = true;
            // 
            // radioButtonDot
            // 
            this.radioButtonDot.AutoSize = true;
            this.radioButtonDot.Location = new System.Drawing.Point(6, 42);
            this.radioButtonDot.Name = "radioButtonDot";
            this.radioButtonDot.Size = new System.Drawing.Size(68, 17);
            this.radioButtonDot.TabIndex = 4;
            this.radioButtonDot.Text = "PS_DOT";
            this.radioButtonDot.UseVisualStyleBackColor = true;
            // 
            // radioButtonSolid
            // 
            this.radioButtonSolid.AutoSize = true;
            this.radioButtonSolid.Checked = true;
            this.radioButtonSolid.Location = new System.Drawing.Point(6, 19);
            this.radioButtonSolid.Name = "radioButtonSolid";
            this.radioButtonSolid.Size = new System.Drawing.Size(77, 17);
            this.radioButtonSolid.TabIndex = 3;
            this.radioButtonSolid.TabStop = true;
            this.radioButtonSolid.Text = "PS_SOLID";
            this.radioButtonSolid.UseVisualStyleBackColor = true;
            // 
            // groupBoxColor
            // 
            this.groupBoxColor.Controls.Add(this.pictureBoxPenColor);
            this.groupBoxColor.Location = new System.Drawing.Point(10, 220);
            this.groupBoxColor.Name = "groupBoxColor";
            this.groupBoxColor.Size = new System.Drawing.Size(144, 47);
            this.groupBoxColor.TabIndex = 1;
            this.groupBoxColor.TabStop = false;
            this.groupBoxColor.Text = "Pen Color";
            // 
            // pictureBoxPenColor
            // 
            this.pictureBoxPenColor.Location = new System.Drawing.Point(7, 19);
            this.pictureBoxPenColor.Name = "pictureBoxPenColor";
            this.pictureBoxPenColor.Size = new System.Drawing.Size(130, 17);
            this.pictureBoxPenColor.TabIndex = 3;
            this.pictureBoxPenColor.TabStop = false;
            this.pictureBoxPenColor.Click += new System.EventHandler(this.pictureBoxPenColor_Click);
            // 
            // groupBoxObject
            // 
            this.groupBoxObject.Controls.Add(this.radioButtonParabola);
            this.groupBoxObject.Controls.Add(this.radioButtonRotate);
            this.groupBoxObject.Controls.Add(this.label2);
            this.groupBoxObject.Controls.Add(this.radioButtonZoom);
            this.groupBoxObject.Controls.Add(this.textBoxPolygon);
            this.groupBoxObject.Controls.Add(this.radioButtonMove);
            this.groupBoxObject.Controls.Add(this.radioButtonEraser);
            this.groupBoxObject.Controls.Add(this.radioButtonPolygon);
            this.groupBoxObject.Controls.Add(this.radioButtonBezier);
            this.groupBoxObject.Controls.Add(this.radioButtonEllipse);
            this.groupBoxObject.Controls.Add(this.textBoxString);
            this.groupBoxObject.Controls.Add(this.radioButtonRectangle);
            this.groupBoxObject.Controls.Add(this.radioButtonString);
            this.groupBoxObject.Controls.Add(this.radioButtonCircle);
            this.groupBoxObject.Controls.Add(this.radioButtonLine);
            this.groupBoxObject.Location = new System.Drawing.Point(10, 10);
            this.groupBoxObject.Name = "groupBoxObject";
            this.groupBoxObject.Size = new System.Drawing.Size(297, 185);
            this.groupBoxObject.TabIndex = 0;
            this.groupBoxObject.TabStop = false;
            this.groupBoxObject.Text = "Object";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(92, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "N =";
            // 
            // textBoxPolygon
            // 
            this.textBoxPolygon.Location = new System.Drawing.Point(116, 133);
            this.textBoxPolygon.Name = "textBoxPolygon";
            this.textBoxPolygon.Size = new System.Drawing.Size(21, 20);
            this.textBoxPolygon.TabIndex = 10;
            this.textBoxPolygon.Text = "3";
            this.textBoxPolygon.TextChanged += new System.EventHandler(this.textBoxPolygon_TextChanged);
            // 
            // radioButtonEraser
            // 
            this.radioButtonEraser.AutoSize = true;
            this.radioButtonEraser.Location = new System.Drawing.Point(171, 157);
            this.radioButtonEraser.Name = "radioButtonEraser";
            this.radioButtonEraser.Size = new System.Drawing.Size(55, 17);
            this.radioButtonEraser.TabIndex = 9;
            this.radioButtonEraser.TabStop = true;
            this.radioButtonEraser.Text = "Eraser";
            this.radioButtonEraser.UseVisualStyleBackColor = true;
            // 
            // radioButtonPolygon
            // 
            this.radioButtonPolygon.AutoSize = true;
            this.radioButtonPolygon.Location = new System.Drawing.Point(6, 134);
            this.radioButtonPolygon.Name = "radioButtonPolygon";
            this.radioButtonPolygon.Size = new System.Drawing.Size(63, 17);
            this.radioButtonPolygon.TabIndex = 8;
            this.radioButtonPolygon.TabStop = true;
            this.radioButtonPolygon.Text = "Polygon";
            this.radioButtonPolygon.UseVisualStyleBackColor = true;
            // 
            // radioButtonBezier
            // 
            this.radioButtonBezier.AutoSize = true;
            this.radioButtonBezier.Location = new System.Drawing.Point(6, 111);
            this.radioButtonBezier.Name = "radioButtonBezier";
            this.radioButtonBezier.Size = new System.Drawing.Size(85, 17);
            this.radioButtonBezier.TabIndex = 7;
            this.radioButtonBezier.Text = "Bezier Curve";
            this.radioButtonBezier.UseVisualStyleBackColor = true;
            // 
            // radioButtonEllipse
            // 
            this.radioButtonEllipse.AutoSize = true;
            this.radioButtonEllipse.Location = new System.Drawing.Point(6, 65);
            this.radioButtonEllipse.Name = "radioButtonEllipse";
            this.radioButtonEllipse.Size = new System.Drawing.Size(55, 17);
            this.radioButtonEllipse.TabIndex = 6;
            this.radioButtonEllipse.Text = "Ellipse";
            this.radioButtonEllipse.UseVisualStyleBackColor = true;
            // 
            // textBoxString
            // 
            this.textBoxString.Location = new System.Drawing.Point(63, 156);
            this.textBoxString.Name = "textBoxString";
            this.textBoxString.Size = new System.Drawing.Size(74, 20);
            this.textBoxString.TabIndex = 5;
            this.textBoxString.Text = "qcuong98";
            // 
            // radioButtonRectangle
            // 
            this.radioButtonRectangle.AutoSize = true;
            this.radioButtonRectangle.Location = new System.Drawing.Point(6, 88);
            this.radioButtonRectangle.Name = "radioButtonRectangle";
            this.radioButtonRectangle.Size = new System.Drawing.Size(74, 17);
            this.radioButtonRectangle.TabIndex = 3;
            this.radioButtonRectangle.Text = "Rectangle";
            this.radioButtonRectangle.UseVisualStyleBackColor = true;
            // 
            // radioButtonString
            // 
            this.radioButtonString.AutoSize = true;
            this.radioButtonString.Location = new System.Drawing.Point(6, 157);
            this.radioButtonString.Name = "radioButtonString";
            this.radioButtonString.Size = new System.Drawing.Size(52, 17);
            this.radioButtonString.TabIndex = 4;
            this.radioButtonString.Text = "String";
            this.radioButtonString.UseVisualStyleBackColor = true;
            // 
            // radioButtonCircle
            // 
            this.radioButtonCircle.AutoSize = true;
            this.radioButtonCircle.Location = new System.Drawing.Point(6, 42);
            this.radioButtonCircle.Name = "radioButtonCircle";
            this.radioButtonCircle.Size = new System.Drawing.Size(51, 17);
            this.radioButtonCircle.TabIndex = 2;
            this.radioButtonCircle.Text = "Circle";
            this.radioButtonCircle.UseVisualStyleBackColor = true;
            // 
            // radioButtonLine
            // 
            this.radioButtonLine.AutoSize = true;
            this.radioButtonLine.Checked = true;
            this.radioButtonLine.Location = new System.Drawing.Point(6, 19);
            this.radioButtonLine.Name = "radioButtonLine";
            this.radioButtonLine.Size = new System.Drawing.Size(45, 17);
            this.radioButtonLine.TabIndex = 1;
            this.radioButtonLine.TabStop = true;
            this.radioButtonLine.Text = "Line";
            this.radioButtonLine.UseVisualStyleBackColor = true;
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(3, -2);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(873, 569);
            this.pictureBox.TabIndex = 1;
            this.pictureBox.TabStop = false;
            this.pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDown);
            this.pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
            this.pictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseUp);
            // 
            // radioButtonRotate
            // 
            this.radioButtonRotate.AutoSize = true;
            this.radioButtonRotate.Location = new System.Drawing.Point(171, 134);
            this.radioButtonRotate.Name = "radioButtonRotate";
            this.radioButtonRotate.Size = new System.Drawing.Size(57, 17);
            this.radioButtonRotate.TabIndex = 7;
            this.radioButtonRotate.TabStop = true;
            this.radioButtonRotate.Text = "Rotate";
            this.radioButtonRotate.UseVisualStyleBackColor = true;
            // 
            // radioButtonZoom
            // 
            this.radioButtonZoom.AutoSize = true;
            this.radioButtonZoom.Location = new System.Drawing.Point(171, 111);
            this.radioButtonZoom.Name = "radioButtonZoom";
            this.radioButtonZoom.Size = new System.Drawing.Size(52, 17);
            this.radioButtonZoom.TabIndex = 6;
            this.radioButtonZoom.TabStop = true;
            this.radioButtonZoom.Text = "Zoom";
            this.radioButtonZoom.UseVisualStyleBackColor = true;
            // 
            // radioButtonMove
            // 
            this.radioButtonMove.AutoSize = true;
            this.radioButtonMove.Location = new System.Drawing.Point(171, 88);
            this.radioButtonMove.Name = "radioButtonMove";
            this.radioButtonMove.Size = new System.Drawing.Size(52, 17);
            this.radioButtonMove.TabIndex = 5;
            this.radioButtonMove.TabStop = true;
            this.radioButtonMove.Text = "Move";
            this.radioButtonMove.UseVisualStyleBackColor = true;
            // 
            // radioButtonParabola
            // 
            this.radioButtonParabola.AutoSize = true;
            this.radioButtonParabola.Location = new System.Drawing.Point(171, 19);
            this.radioButtonParabola.Name = "radioButtonParabola";
            this.radioButtonParabola.Size = new System.Drawing.Size(67, 17);
            this.radioButtonParabola.TabIndex = 12;
            this.radioButtonParabola.TabStop = true;
            this.radioButtonParabola.Text = "Parabola";
            this.radioButtonParabola.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1221, 578);
            this.Controls.Add(this.splitContainer);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "2D Graphics";
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.groupBoxFile.ResumeLayout(false);
            this.groupBoxTypeOfBrush.ResumeLayout(false);
            this.groupBoxTypeOfBrush.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBrushColor)).EndInit();
            this.groupBoxPens.ResumeLayout(false);
            this.groupBoxPens.PerformLayout();
            this.groupBoxColor.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPenColor)).EndInit();
            this.groupBoxObject.ResumeLayout(false);
            this.groupBoxObject.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.GroupBox groupBoxObject;
        private System.Windows.Forms.RadioButton radioButtonCircle;
        private System.Windows.Forms.RadioButton radioButtonLine;
        private System.Windows.Forms.RadioButton radioButtonRectangle;
        private System.Windows.Forms.TextBox textBoxString;
        private System.Windows.Forms.RadioButton radioButtonString;
        private System.Windows.Forms.GroupBox groupBoxColor;
        private System.Windows.Forms.GroupBox groupBoxPens;
        private System.Windows.Forms.RadioButton radioButtonNull;
        private System.Windows.Forms.RadioButton radioButtonDashDotDot;
        private System.Windows.Forms.RadioButton radioButtonDashDot;
        private System.Windows.Forms.RadioButton radioButtonDash;
        private System.Windows.Forms.RadioButton radioButtonDot;
        private System.Windows.Forms.RadioButton radioButtonSolid;
        private System.Windows.Forms.TextBox textBoxWidth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBoxTypeOfBrush;
        private System.Windows.Forms.GroupBox groupBoxFile;
        private System.Windows.Forms.Button buttonSaveFile;
        private System.Windows.Forms.Button buttonLoadFile;
        private System.Windows.Forms.RadioButton radioButtonEllipse;
        private System.Windows.Forms.RadioButton radioButtonBrushColor;
        private System.Windows.Forms.PictureBox pictureBoxBrushColor;
        private System.Windows.Forms.PictureBox pictureBoxPenColor;
        private System.Windows.Forms.RadioButton radioButtonBrushPattern1;
        private System.Windows.Forms.RadioButton radioButtonBrushPattern3;
        private System.Windows.Forms.RadioButton radioButtonBrushPattern2;
        private System.Windows.Forms.RadioButton radioButtonBrushTransparent;
        private System.Windows.Forms.RadioButton radioButtonBezier;
        private System.Windows.Forms.RadioButton radioButtonEraser;
        private System.Windows.Forms.RadioButton radioButtonPolygon;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxPolygon;
        private System.Windows.Forms.RadioButton radioButtonRotate;
        private System.Windows.Forms.RadioButton radioButtonZoom;
        private System.Windows.Forms.RadioButton radioButtonMove;
        private System.Windows.Forms.RadioButton radioButtonParabola;
    }
}

