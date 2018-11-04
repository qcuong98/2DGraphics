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
            this.groupBoxObject = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.radioButtonDigits = new System.Windows.Forms.RadioButton();
            this.radioButtonRectangle = new System.Windows.Forms.RadioButton();
            this.radioButtonCircle = new System.Windows.Forms.RadioButton();
            this.radioButtonLine = new System.Windows.Forms.RadioButton();
            this.radioButtonSelect = new System.Windows.Forms.RadioButton();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.groupBoxColor = new System.Windows.Forms.GroupBox();
            this.radioButtonRed = new System.Windows.Forms.RadioButton();
            this.radioButtonGreen = new System.Windows.Forms.RadioButton();
            this.radioButtonBlue = new System.Windows.Forms.RadioButton();
            this.groupBoxStroke = new System.Windows.Forms.GroupBox();
            this.radioButtonDash = new System.Windows.Forms.RadioButton();
            this.radioButtonDot = new System.Windows.Forms.RadioButton();
            this.radioButtonSolid = new System.Windows.Forms.RadioButton();
            this.radioButtonNull = new System.Windows.Forms.RadioButton();
            this.radioButtonDashDotDot = new System.Windows.Forms.RadioButton();
            this.radioButtonDashDot = new System.Windows.Forms.RadioButton();
            this.textBoxWidth = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.groupBoxObject.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.groupBoxColor.SuspendLayout();
            this.groupBoxStroke.SuspendLayout();
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
            this.splitContainer.Panel1.Controls.Add(this.groupBoxStroke);
            this.splitContainer.Panel1.Controls.Add(this.groupBoxColor);
            this.splitContainer.Panel1.Controls.Add(this.groupBoxObject);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.pictureBox);
            this.splitContainer.Size = new System.Drawing.Size(1216, 549);
            this.splitContainer.SplitterDistance = 329;
            this.splitContainer.TabIndex = 0;
            // 
            // groupBoxObject
            // 
            this.groupBoxObject.Controls.Add(this.textBox1);
            this.groupBoxObject.Controls.Add(this.radioButtonDigits);
            this.groupBoxObject.Controls.Add(this.radioButtonRectangle);
            this.groupBoxObject.Controls.Add(this.radioButtonCircle);
            this.groupBoxObject.Controls.Add(this.radioButtonLine);
            this.groupBoxObject.Controls.Add(this.radioButtonSelect);
            this.groupBoxObject.Location = new System.Drawing.Point(10, 10);
            this.groupBoxObject.Name = "groupBoxObject";
            this.groupBoxObject.Size = new System.Drawing.Size(143, 532);
            this.groupBoxObject.TabIndex = 0;
            this.groupBoxObject.TabStop = false;
            this.groupBoxObject.Text = "Object";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(63, 109);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(74, 20);
            this.textBox1.TabIndex = 5;
            // 
            // radioButtonDigits
            // 
            this.radioButtonDigits.AutoSize = true;
            this.radioButtonDigits.Location = new System.Drawing.Point(6, 112);
            this.radioButtonDigits.Name = "radioButtonDigits";
            this.radioButtonDigits.Size = new System.Drawing.Size(51, 17);
            this.radioButtonDigits.TabIndex = 4;
            this.radioButtonDigits.Text = "Digits";
            this.radioButtonDigits.UseVisualStyleBackColor = true;
            // 
            // radioButtonRectangle
            // 
            this.radioButtonRectangle.AutoSize = true;
            this.radioButtonRectangle.Location = new System.Drawing.Point(7, 89);
            this.radioButtonRectangle.Name = "radioButtonRectangle";
            this.radioButtonRectangle.Size = new System.Drawing.Size(74, 17);
            this.radioButtonRectangle.TabIndex = 3;
            this.radioButtonRectangle.Text = "Rectangle";
            this.radioButtonRectangle.UseVisualStyleBackColor = true;
            // 
            // radioButtonCircle
            // 
            this.radioButtonCircle.AutoSize = true;
            this.radioButtonCircle.Location = new System.Drawing.Point(6, 65);
            this.radioButtonCircle.Name = "radioButtonCircle";
            this.radioButtonCircle.Size = new System.Drawing.Size(51, 17);
            this.radioButtonCircle.TabIndex = 2;
            this.radioButtonCircle.Text = "Circle";
            this.radioButtonCircle.UseVisualStyleBackColor = true;
            // 
            // radioButtonLine
            // 
            this.radioButtonLine.AutoSize = true;
            this.radioButtonLine.Location = new System.Drawing.Point(6, 42);
            this.radioButtonLine.Name = "radioButtonLine";
            this.radioButtonLine.Size = new System.Drawing.Size(45, 17);
            this.radioButtonLine.TabIndex = 1;
            this.radioButtonLine.Text = "Line";
            this.radioButtonLine.UseVisualStyleBackColor = true;
            // 
            // radioButtonSelect
            // 
            this.radioButtonSelect.AutoSize = true;
            this.radioButtonSelect.Checked = true;
            this.radioButtonSelect.Location = new System.Drawing.Point(6, 19);
            this.radioButtonSelect.Name = "radioButtonSelect";
            this.radioButtonSelect.Size = new System.Drawing.Size(55, 17);
            this.radioButtonSelect.TabIndex = 0;
            this.radioButtonSelect.TabStop = true;
            this.radioButtonSelect.Text = "Select";
            this.radioButtonSelect.UseVisualStyleBackColor = true;
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(3, -2);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(873, 544);
            this.pictureBox.TabIndex = 1;
            this.pictureBox.TabStop = false;
            this.pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDown);
            this.pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
            this.pictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseUp);
            // 
            // groupBoxColor
            // 
            this.groupBoxColor.Controls.Add(this.radioButtonBlue);
            this.groupBoxColor.Controls.Add(this.radioButtonGreen);
            this.groupBoxColor.Controls.Add(this.radioButtonRed);
            this.groupBoxColor.Location = new System.Drawing.Point(159, 10);
            this.groupBoxColor.Name = "groupBoxColor";
            this.groupBoxColor.Size = new System.Drawing.Size(163, 93);
            this.groupBoxColor.TabIndex = 1;
            this.groupBoxColor.TabStop = false;
            this.groupBoxColor.Text = "Color";
            // 
            // radioButtonRed
            // 
            this.radioButtonRed.AutoSize = true;
            this.radioButtonRed.Checked = true;
            this.radioButtonRed.Location = new System.Drawing.Point(6, 19);
            this.radioButtonRed.Name = "radioButtonRed";
            this.radioButtonRed.Size = new System.Drawing.Size(45, 17);
            this.radioButtonRed.TabIndex = 0;
            this.radioButtonRed.TabStop = true;
            this.radioButtonRed.Text = "Red";
            this.radioButtonRed.UseVisualStyleBackColor = true;
            // 
            // radioButtonGreen
            // 
            this.radioButtonGreen.AutoSize = true;
            this.radioButtonGreen.Location = new System.Drawing.Point(6, 42);
            this.radioButtonGreen.Name = "radioButtonGreen";
            this.radioButtonGreen.Size = new System.Drawing.Size(54, 17);
            this.radioButtonGreen.TabIndex = 1;
            this.radioButtonGreen.Text = "Green";
            this.radioButtonGreen.UseVisualStyleBackColor = true;
            // 
            // radioButtonBlue
            // 
            this.radioButtonBlue.AutoSize = true;
            this.radioButtonBlue.Location = new System.Drawing.Point(6, 65);
            this.radioButtonBlue.Name = "radioButtonBlue";
            this.radioButtonBlue.Size = new System.Drawing.Size(46, 17);
            this.radioButtonBlue.TabIndex = 2;
            this.radioButtonBlue.Text = "Blue";
            this.radioButtonBlue.UseVisualStyleBackColor = true;
            // 
            // groupBoxStroke
            // 
            this.groupBoxStroke.Controls.Add(this.label1);
            this.groupBoxStroke.Controls.Add(this.textBoxWidth);
            this.groupBoxStroke.Controls.Add(this.radioButtonNull);
            this.groupBoxStroke.Controls.Add(this.radioButtonDashDotDot);
            this.groupBoxStroke.Controls.Add(this.radioButtonDashDot);
            this.groupBoxStroke.Controls.Add(this.radioButtonDash);
            this.groupBoxStroke.Controls.Add(this.radioButtonDot);
            this.groupBoxStroke.Controls.Add(this.radioButtonSolid);
            this.groupBoxStroke.Location = new System.Drawing.Point(160, 110);
            this.groupBoxStroke.Name = "groupBoxStroke";
            this.groupBoxStroke.Size = new System.Drawing.Size(162, 164);
            this.groupBoxStroke.TabIndex = 2;
            this.groupBoxStroke.TabStop = false;
            this.groupBoxStroke.Text = "Stroke";
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
            // textBoxWidth
            // 
            this.textBoxWidth.Location = new System.Drawing.Point(122, 18);
            this.textBoxWidth.Name = "textBoxWidth";
            this.textBoxWidth.Size = new System.Drawing.Size(34, 20);
            this.textBoxWidth.TabIndex = 6;
            this.textBoxWidth.Text = "1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(89, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Width";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1228, 561);
            this.Controls.Add(this.splitContainer);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "2D Graphics";
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.groupBoxObject.ResumeLayout(false);
            this.groupBoxObject.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.groupBoxColor.ResumeLayout(false);
            this.groupBoxColor.PerformLayout();
            this.groupBoxStroke.ResumeLayout(false);
            this.groupBoxStroke.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.GroupBox groupBoxObject;
        private System.Windows.Forms.RadioButton radioButtonCircle;
        private System.Windows.Forms.RadioButton radioButtonLine;
        private System.Windows.Forms.RadioButton radioButtonSelect;
        private System.Windows.Forms.RadioButton radioButtonRectangle;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.RadioButton radioButtonDigits;
        private System.Windows.Forms.GroupBox groupBoxColor;
        private System.Windows.Forms.RadioButton radioButtonBlue;
        private System.Windows.Forms.RadioButton radioButtonGreen;
        private System.Windows.Forms.RadioButton radioButtonRed;
        private System.Windows.Forms.GroupBox groupBoxStroke;
        private System.Windows.Forms.RadioButton radioButtonNull;
        private System.Windows.Forms.RadioButton radioButtonDashDotDot;
        private System.Windows.Forms.RadioButton radioButtonDashDot;
        private System.Windows.Forms.RadioButton radioButtonDash;
        private System.Windows.Forms.RadioButton radioButtonDot;
        private System.Windows.Forms.RadioButton radioButtonSolid;
        private System.Windows.Forms.TextBox textBoxWidth;
        private System.Windows.Forms.Label label1;
    }
}

