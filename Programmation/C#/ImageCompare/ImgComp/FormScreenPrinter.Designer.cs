namespace ImgComp
{
    partial class FormScreenPrinter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormScreenPrinter));
            this._textBoxX = new System.Windows.Forms.TextBox();
            this._textBoxY = new System.Windows.Forms.TextBox();
            this._textBoxWidth = new System.Windows.Forms.TextBox();
            this._textBoxHeight = new System.Windows.Forms.TextBox();
            this._labelX = new System.Windows.Forms.Label();
            this._labelY = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this._labelWidth = new System.Windows.Forms.Label();
            this._labelHeight = new System.Windows.Forms.Label();
            this._statusStrip = new System.Windows.Forms.StatusStrip();
            this._toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this._buttonPrint = new System.Windows.Forms.Button();
            this._textBoxDestination = new System.Windows.Forms.TextBox();
            this._labelDestination = new System.Windows.Forms.Label();
            this._panelResult = new System.Windows.Forms.Panel();
            this._pictureBoxResult = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1.SuspendLayout();
            this._statusStrip.SuspendLayout();
            this._panelResult.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._pictureBoxResult)).BeginInit();
            this.SuspendLayout();
            // 
            // _textBoxX
            // 
            this._textBoxX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this._textBoxX.Location = new System.Drawing.Point(69, 3);
            this._textBoxX.Name = "_textBoxX";
            this._textBoxX.Size = new System.Drawing.Size(91, 20);
            this._textBoxX.TabIndex = 0;
            this._textBoxX.Text = "0";
            // 
            // _textBoxY
            // 
            this._textBoxY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this._textBoxY.Location = new System.Drawing.Point(210, 3);
            this._textBoxY.Name = "_textBoxY";
            this._textBoxY.Size = new System.Drawing.Size(91, 20);
            this._textBoxY.TabIndex = 0;
            this._textBoxY.Text = "0";
            // 
            // _textBoxWidth
            // 
            this._textBoxWidth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this._textBoxWidth.Location = new System.Drawing.Point(69, 29);
            this._textBoxWidth.Name = "_textBoxWidth";
            this._textBoxWidth.Size = new System.Drawing.Size(91, 20);
            this._textBoxWidth.TabIndex = 0;
            this._textBoxWidth.Text = "100";
            // 
            // _textBoxHeight
            // 
            this._textBoxHeight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this._textBoxHeight.Location = new System.Drawing.Point(210, 29);
            this._textBoxHeight.Name = "_textBoxHeight";
            this._textBoxHeight.Size = new System.Drawing.Size(91, 20);
            this._textBoxHeight.TabIndex = 0;
            this._textBoxHeight.Text = "50";
            // 
            // _labelX
            // 
            this._labelX.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this._labelX.AutoSize = true;
            this._labelX.Location = new System.Drawing.Point(49, 6);
            this._labelX.Name = "_labelX";
            this._labelX.Size = new System.Drawing.Size(14, 13);
            this._labelX.TabIndex = 1;
            this._labelX.Text = "X";
            // 
            // _labelY
            // 
            this._labelY.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this._labelY.AutoSize = true;
            this._labelY.Location = new System.Drawing.Point(190, 6);
            this._labelY.Name = "_labelY";
            this._labelY.Size = new System.Drawing.Size(14, 13);
            this._labelY.TabIndex = 1;
            this._labelY.Text = "Y";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this._textBoxDestination, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this._textBoxX, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this._textBoxY, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this._labelY, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this._labelX, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this._textBoxHeight, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this._textBoxWidth, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this._labelWidth, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this._labelHeight, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this._labelDestination, 0, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(304, 83);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // _labelWidth
            // 
            this._labelWidth.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this._labelWidth.AutoSize = true;
            this._labelWidth.Location = new System.Drawing.Point(28, 32);
            this._labelWidth.Name = "_labelWidth";
            this._labelWidth.Size = new System.Drawing.Size(35, 13);
            this._labelWidth.TabIndex = 1;
            this._labelWidth.Text = "Width";
            // 
            // _labelHeight
            // 
            this._labelHeight.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this._labelHeight.AutoSize = true;
            this._labelHeight.Location = new System.Drawing.Point(166, 32);
            this._labelHeight.Name = "_labelHeight";
            this._labelHeight.Size = new System.Drawing.Size(38, 13);
            this._labelHeight.TabIndex = 1;
            this._labelHeight.Text = "Height";
            // 
            // _statusStrip
            // 
            this._statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._toolStripStatusLabel});
            this._statusStrip.Location = new System.Drawing.Point(0, 205);
            this._statusStrip.Name = "_statusStrip";
            this._statusStrip.Size = new System.Drawing.Size(328, 22);
            this._statusStrip.TabIndex = 3;
            this._statusStrip.Text = "statusStrip1";
            // 
            // _toolStripStatusLabel
            // 
            this._toolStripStatusLabel.Name = "_toolStripStatusLabel";
            this._toolStripStatusLabel.Size = new System.Drawing.Size(29, 17);
            this._toolStripStatusLabel.Text = "Idle.";
            // 
            // _buttonPrint
            // 
            this._buttonPrint.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this._buttonPrint.Location = new System.Drawing.Point(128, 101);
            this._buttonPrint.Name = "_buttonPrint";
            this._buttonPrint.Size = new System.Drawing.Size(75, 23);
            this._buttonPrint.TabIndex = 4;
            this._buttonPrint.Text = "Print";
            this._buttonPrint.UseVisualStyleBackColor = true;
            this._buttonPrint.Click += new System.EventHandler(this._buttonPrint_Click);
            // 
            // _textBoxDestination
            // 
            this._textBoxDestination.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this._textBoxDestination, 3);
            this._textBoxDestination.Location = new System.Drawing.Point(69, 57);
            this._textBoxDestination.Name = "_textBoxDestination";
            this._textBoxDestination.Size = new System.Drawing.Size(232, 20);
            this._textBoxDestination.TabIndex = 5;
            this._textBoxDestination.Text = "c:\\PrintedImg.bmp";
            // 
            // _labelDestination
            // 
            this._labelDestination.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this._labelDestination.AutoSize = true;
            this._labelDestination.Location = new System.Drawing.Point(3, 61);
            this._labelDestination.Name = "_labelDestination";
            this._labelDestination.Size = new System.Drawing.Size(60, 13);
            this._labelDestination.TabIndex = 1;
            this._labelDestination.Text = "Destination";
            // 
            // _panelResult
            // 
            this._panelResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._panelResult.AutoScroll = true;
            this._panelResult.BackColor = System.Drawing.Color.White;
            this._panelResult.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this._panelResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._panelResult.Controls.Add(this._pictureBoxResult);
            this._panelResult.Location = new System.Drawing.Point(12, 130);
            this._panelResult.Name = "_panelResult";
            this._panelResult.Size = new System.Drawing.Size(304, 72);
            this._panelResult.TabIndex = 6;
            // 
            // _pictureBoxResult
            // 
            this._pictureBoxResult.BackColor = System.Drawing.SystemColors.Control;
            this._pictureBoxResult.Location = new System.Drawing.Point(3, 3);
            this._pictureBoxResult.Name = "_pictureBoxResult";
            this._pictureBoxResult.Size = new System.Drawing.Size(0, 0);
            this._pictureBoxResult.TabIndex = 0;
            this._pictureBoxResult.TabStop = false;
            // 
            // FormScreenPrinter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(328, 227);
            this.Controls.Add(this._panelResult);
            this.Controls.Add(this._buttonPrint);
            this.Controls.Add(this._statusStrip);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormScreenPrinter";
            this.Text = "FormScreenPrinter";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this._statusStrip.ResumeLayout(false);
            this._statusStrip.PerformLayout();
            this._panelResult.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._pictureBoxResult)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox _textBoxX;
        private System.Windows.Forms.TextBox _textBoxY;
        private System.Windows.Forms.TextBox _textBoxWidth;
        private System.Windows.Forms.TextBox _textBoxHeight;
        private System.Windows.Forms.Label _labelX;
        private System.Windows.Forms.Label _labelY;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label _labelWidth;
        private System.Windows.Forms.Label _labelHeight;
        private System.Windows.Forms.StatusStrip _statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel _toolStripStatusLabel;
        private System.Windows.Forms.Button _buttonPrint;
        private System.Windows.Forms.Label _labelDestination;
        private System.Windows.Forms.TextBox _textBoxDestination;
        private System.Windows.Forms.Panel _panelResult;
        private System.Windows.Forms.PictureBox _pictureBoxResult;
    }
}