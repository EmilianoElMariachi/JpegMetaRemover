namespace ImgComp
{
    partial class FormMain
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this._trackBarColorTolerance = new System.Windows.Forms.TrackBar();
            this._textBoxRefImage = new System.Windows.Forms.TextBox();
            this._labelReferenceImagePath = new System.Windows.Forms.Label();
            this._textBoxComparedImage = new System.Windows.Forms.TextBox();
            this._labelComparedImagePath = new System.Windows.Forms.Label();
            this._menuStrip = new System.Windows.Forms.MenuStrip();
            this._fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._compareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._labelColorTolerancePerPixel = new System.Windows.Forms.Label();
            this._textBoxColorTolerancePerPixel = new System.Windows.Forms.TextBox();
            this._groupBoxParameters = new System.Windows.Forms.GroupBox();
            this._checkBoxIgnoreTransparentPixels = new System.Windows.Forms.CheckBox();
            this._flowLayoutPanelColorCompare = new System.Windows.Forms.FlowLayoutPanel();
            this._labelColor2 = new System.Windows.Forms.Label();
            this._labelColor1 = new System.Windows.Forms.Label();
            this._labelPourcentageOfAcceptablePixels = new System.Windows.Forms.Label();
            this._textBoxPourcentageOfAcceptablePixels = new System.Windows.Forms.TextBox();
            this._trackBarPourcentageOfAcceptablePixels = new System.Windows.Forms.TrackBar();
            this._richTextBoxLog = new System.Windows.Forms.RichTextBox();
            this._buttonCompare = new System.Windows.Forms.Button();
            this._backgroundWorkerCompareImages = new System.ComponentModel.BackgroundWorker();
            this._colorDialog = new System.Windows.Forms.ColorDialog();
            this._printScreenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this._trackBarColorTolerance)).BeginInit();
            this._menuStrip.SuspendLayout();
            this._groupBoxParameters.SuspendLayout();
            this._flowLayoutPanelColorCompare.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._trackBarPourcentageOfAcceptablePixels)).BeginInit();
            this.SuspendLayout();
            // 
            // _trackBarColorTolerance
            // 
            this._trackBarColorTolerance.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._trackBarColorTolerance.AutoSize = false;
            this._trackBarColorTolerance.Location = new System.Drawing.Point(10, 32);
            this._trackBarColorTolerance.Maximum = 100;
            this._trackBarColorTolerance.Name = "_trackBarColorTolerance";
            this._trackBarColorTolerance.Size = new System.Drawing.Size(426, 24);
            this._trackBarColorTolerance.TabIndex = 0;
            this._trackBarColorTolerance.Value = 5;
            this._trackBarColorTolerance.Scroll += new System.EventHandler(this._trackBarColorTolerance_Scroll);
            // 
            // _textBoxRefImage
            // 
            this._textBoxRefImage.AllowDrop = true;
            this._textBoxRefImage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._textBoxRefImage.Location = new System.Drawing.Point(109, 181);
            this._textBoxRefImage.Name = "_textBoxRefImage";
            this._textBoxRefImage.Size = new System.Drawing.Size(341, 20);
            this._textBoxRefImage.TabIndex = 1;
            this._textBoxRefImage.Text = "TestResources\\RefOracleTextField-119x23.png";
            this._textBoxRefImage.DragDrop += new System.Windows.Forms.DragEventHandler(this.OnTextBox_DragDrop);
            this._textBoxRefImage.DragEnter += new System.Windows.Forms.DragEventHandler(this.OnTextBox_DragEnter);
            // 
            // _labelReferenceImagePath
            // 
            this._labelReferenceImagePath.AutoSize = true;
            this._labelReferenceImagePath.Location = new System.Drawing.Point(17, 184);
            this._labelReferenceImagePath.Name = "_labelReferenceImagePath";
            this._labelReferenceImagePath.Size = new System.Drawing.Size(88, 13);
            this._labelReferenceImagePath.TabIndex = 2;
            this._labelReferenceImagePath.Text = "Reference image";
            // 
            // _textBoxComparedImage
            // 
            this._textBoxComparedImage.AllowDrop = true;
            this._textBoxComparedImage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._textBoxComparedImage.Location = new System.Drawing.Point(109, 207);
            this._textBoxComparedImage.Name = "_textBoxComparedImage";
            this._textBoxComparedImage.Size = new System.Drawing.Size(341, 20);
            this._textBoxComparedImage.TabIndex = 1;
            this._textBoxComparedImage.Text = "TestResources\\WidgetOracleTextField.png";
            this._textBoxComparedImage.DragDrop += new System.Windows.Forms.DragEventHandler(this.OnTextBox_DragDrop);
            this._textBoxComparedImage.DragEnter += new System.Windows.Forms.DragEventHandler(this.OnTextBox_DragEnter);
            // 
            // _labelComparedImagePath
            // 
            this._labelComparedImagePath.AutoSize = true;
            this._labelComparedImagePath.Location = new System.Drawing.Point(17, 210);
            this._labelComparedImagePath.Name = "_labelComparedImagePath";
            this._labelComparedImagePath.Size = new System.Drawing.Size(86, 13);
            this._labelComparedImagePath.TabIndex = 2;
            this._labelComparedImagePath.Text = "Compared image";
            // 
            // _menuStrip
            // 
            this._menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._fileToolStripMenuItem,
            this._editToolStripMenuItem});
            this._menuStrip.Location = new System.Drawing.Point(0, 0);
            this._menuStrip.Name = "_menuStrip";
            this._menuStrip.Size = new System.Drawing.Size(534, 24);
            this._menuStrip.TabIndex = 3;
            this._menuStrip.Text = "menuStrip1";
            // 
            // _fileToolStripMenuItem
            // 
            this._fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._exitToolStripMenuItem});
            this._fileToolStripMenuItem.Name = "_fileToolStripMenuItem";
            this._fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this._fileToolStripMenuItem.Text = "File";
            // 
            // _exitToolStripMenuItem
            // 
            this._exitToolStripMenuItem.Name = "_exitToolStripMenuItem";
            this._exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this._exitToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this._exitToolStripMenuItem.Text = "Exit";
            // 
            // _editToolStripMenuItem
            // 
            this._editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._compareToolStripMenuItem,
            this._printScreenToolStripMenuItem});
            this._editToolStripMenuItem.Name = "_editToolStripMenuItem";
            this._editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this._editToolStripMenuItem.Text = "Edit";
            // 
            // _compareToolStripMenuItem
            // 
            this._compareToolStripMenuItem.Name = "_compareToolStripMenuItem";
            this._compareToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.C)));
            this._compareToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this._compareToolStripMenuItem.Text = "Compare";
            this._compareToolStripMenuItem.Click += new System.EventHandler(this._compareToolStripMenuItem_Click);
            // 
            // _labelColorTolerancePerPixel
            // 
            this._labelColorTolerancePerPixel.AutoSize = true;
            this._labelColorTolerancePerPixel.Location = new System.Drawing.Point(16, 16);
            this._labelColorTolerancePerPixel.Name = "_labelColorTolerancePerPixel";
            this._labelColorTolerancePerPixel.Size = new System.Drawing.Size(276, 13);
            this._labelColorTolerancePerPixel.TabIndex = 4;
            this._labelColorTolerancePerPixel.Text = "Maximum threshold of acceptable delta color per pixel (%)";
            // 
            // _textBoxColorTolerancePerPixel
            // 
            this._textBoxColorTolerancePerPixel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._textBoxColorTolerancePerPixel.Location = new System.Drawing.Point(440, 32);
            this._textBoxColorTolerancePerPixel.Name = "_textBoxColorTolerancePerPixel";
            this._textBoxColorTolerancePerPixel.Size = new System.Drawing.Size(62, 20);
            this._textBoxColorTolerancePerPixel.TabIndex = 6;
            this._textBoxColorTolerancePerPixel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this._textBoxColorTolerancePerPixel.TextChanged += new System.EventHandler(this._textBoxColorTolerancePerPixel_TextChanged);
            // 
            // _groupBoxParameters
            // 
            this._groupBoxParameters.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._groupBoxParameters.Controls.Add(this._checkBoxIgnoreTransparentPixels);
            this._groupBoxParameters.Controls.Add(this._flowLayoutPanelColorCompare);
            this._groupBoxParameters.Controls.Add(this._labelPourcentageOfAcceptablePixels);
            this._groupBoxParameters.Controls.Add(this._labelColorTolerancePerPixel);
            this._groupBoxParameters.Controls.Add(this._textBoxPourcentageOfAcceptablePixels);
            this._groupBoxParameters.Controls.Add(this._textBoxColorTolerancePerPixel);
            this._groupBoxParameters.Controls.Add(this._trackBarPourcentageOfAcceptablePixels);
            this._groupBoxParameters.Controls.Add(this._trackBarColorTolerance);
            this._groupBoxParameters.Location = new System.Drawing.Point(15, 27);
            this._groupBoxParameters.Name = "_groupBoxParameters";
            this._groupBoxParameters.Size = new System.Drawing.Size(507, 148);
            this._groupBoxParameters.TabIndex = 7;
            this._groupBoxParameters.TabStop = false;
            this._groupBoxParameters.Text = "Tolerances Specification";
            // 
            // _checkBoxIgnoreTransparentPixels
            // 
            this._checkBoxIgnoreTransparentPixels.AutoSize = true;
            this._checkBoxIgnoreTransparentPixels.Location = new System.Drawing.Point(19, 109);
            this._checkBoxIgnoreTransparentPixels.Name = "_checkBoxIgnoreTransparentPixels";
            this._checkBoxIgnoreTransparentPixels.Size = new System.Drawing.Size(141, 17);
            this._checkBoxIgnoreTransparentPixels.TabIndex = 9;
            this._checkBoxIgnoreTransparentPixels.Text = "Ignore transparent pixels";
            this._checkBoxIgnoreTransparentPixels.UseVisualStyleBackColor = true;
            // 
            // _flowLayoutPanelColorCompare
            // 
            this._flowLayoutPanelColorCompare.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._flowLayoutPanelColorCompare.AutoSize = true;
            this._flowLayoutPanelColorCompare.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._flowLayoutPanelColorCompare.BackColor = System.Drawing.Color.Lime;
            this._flowLayoutPanelColorCompare.Controls.Add(this._labelColor2);
            this._flowLayoutPanelColorCompare.Controls.Add(this._labelColor1);
            this._flowLayoutPanelColorCompare.Location = new System.Drawing.Point(440, 12);
            this._flowLayoutPanelColorCompare.Margin = new System.Windows.Forms.Padding(0);
            this._flowLayoutPanelColorCompare.Name = "_flowLayoutPanelColorCompare";
            this._flowLayoutPanelColorCompare.Padding = new System.Windows.Forms.Padding(1);
            this._flowLayoutPanelColorCompare.Size = new System.Drawing.Size(62, 17);
            this._flowLayoutPanelColorCompare.TabIndex = 8;
            // 
            // _labelColor2
            // 
            this._labelColor2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this._labelColor2.Location = new System.Drawing.Point(1, 1);
            this._labelColor2.Margin = new System.Windows.Forms.Padding(0);
            this._labelColor2.Name = "_labelColor2";
            this._labelColor2.Size = new System.Drawing.Size(30, 15);
            this._labelColor2.TabIndex = 7;
            this._labelColor2.Click += new System.EventHandler(this.OnLabelBackgroundColor_Click);
            // 
            // _labelColor1
            // 
            this._labelColor1.BackColor = System.Drawing.Color.Yellow;
            this._labelColor1.Location = new System.Drawing.Point(31, 1);
            this._labelColor1.Margin = new System.Windows.Forms.Padding(0);
            this._labelColor1.Name = "_labelColor1";
            this._labelColor1.Size = new System.Drawing.Size(30, 15);
            this._labelColor1.TabIndex = 7;
            this._labelColor1.Click += new System.EventHandler(this.OnLabelBackgroundColor_Click);
            // 
            // _labelPourcentageOfAcceptablePixels
            // 
            this._labelPourcentageOfAcceptablePixels.AutoSize = true;
            this._labelPourcentageOfAcceptablePixels.Location = new System.Drawing.Point(16, 63);
            this._labelPourcentageOfAcceptablePixels.Name = "_labelPourcentageOfAcceptablePixels";
            this._labelPourcentageOfAcceptablePixels.Size = new System.Drawing.Size(217, 13);
            this._labelPourcentageOfAcceptablePixels.TabIndex = 4;
            this._labelPourcentageOfAcceptablePixels.Text = "Minimum pourcentage of accepted pixels (%)";
            // 
            // _textBoxPourcentageOfAcceptablePixels
            // 
            this._textBoxPourcentageOfAcceptablePixels.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._textBoxPourcentageOfAcceptablePixels.Location = new System.Drawing.Point(442, 79);
            this._textBoxPourcentageOfAcceptablePixels.Name = "_textBoxPourcentageOfAcceptablePixels";
            this._textBoxPourcentageOfAcceptablePixels.Size = new System.Drawing.Size(60, 20);
            this._textBoxPourcentageOfAcceptablePixels.TabIndex = 6;
            this._textBoxPourcentageOfAcceptablePixels.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this._textBoxPourcentageOfAcceptablePixels.TextChanged += new System.EventHandler(this._textBoxPourcentageOfAcceptablePixels_TextChanged);
            // 
            // _trackBarPourcentageOfAcceptablePixels
            // 
            this._trackBarPourcentageOfAcceptablePixels.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._trackBarPourcentageOfAcceptablePixels.AutoSize = false;
            this._trackBarPourcentageOfAcceptablePixels.Location = new System.Drawing.Point(10, 79);
            this._trackBarPourcentageOfAcceptablePixels.Maximum = 100;
            this._trackBarPourcentageOfAcceptablePixels.Name = "_trackBarPourcentageOfAcceptablePixels";
            this._trackBarPourcentageOfAcceptablePixels.Size = new System.Drawing.Size(426, 24);
            this._trackBarPourcentageOfAcceptablePixels.TabIndex = 0;
            this._trackBarPourcentageOfAcceptablePixels.Value = 98;
            this._trackBarPourcentageOfAcceptablePixels.Scroll += new System.EventHandler(this._trackBarPourcentageOfAcceptablePixels_Scroll);
            // 
            // _richTextBoxLog
            // 
            this._richTextBoxLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._richTextBoxLog.BackColor = System.Drawing.Color.White;
            this._richTextBoxLog.Location = new System.Drawing.Point(12, 233);
            this._richTextBoxLog.Name = "_richTextBoxLog";
            this._richTextBoxLog.ReadOnly = true;
            this._richTextBoxLog.Size = new System.Drawing.Size(510, 148);
            this._richTextBoxLog.TabIndex = 8;
            this._richTextBoxLog.Text = "";
            this._richTextBoxLog.WordWrap = false;
            // 
            // _buttonCompare
            // 
            this._buttonCompare.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._buttonCompare.Location = new System.Drawing.Point(462, 181);
            this._buttonCompare.Name = "_buttonCompare";
            this._buttonCompare.Size = new System.Drawing.Size(60, 46);
            this._buttonCompare.TabIndex = 9;
            this._buttonCompare.Text = "Compare";
            this._buttonCompare.UseVisualStyleBackColor = true;
            this._buttonCompare.Click += new System.EventHandler(this._buttonCompare_Click);
            // 
            // _backgroundWorkerCompareImages
            // 
            this._backgroundWorkerCompareImages.DoWork += new System.ComponentModel.DoWorkEventHandler(this._backgroundWorkerCompareImages_DoWork);
            this._backgroundWorkerCompareImages.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this._backgroundWorkerCompareImages_RunWorkerCompleted);
            // 
            // _printScreenToolStripMenuItem
            // 
            this._printScreenToolStripMenuItem.Name = "_printScreenToolStripMenuItem";
            this._printScreenToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.P)));
            this._printScreenToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this._printScreenToolStripMenuItem.Text = "Print screen ...";
            this._printScreenToolStripMenuItem.Click += new System.EventHandler(this._printScreenToolStripMenuItem_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 393);
            this.Controls.Add(this._buttonCompare);
            this.Controls.Add(this._richTextBoxLog);
            this.Controls.Add(this._groupBoxParameters);
            this.Controls.Add(this._labelComparedImagePath);
            this.Controls.Add(this._labelReferenceImagePath);
            this.Controls.Add(this._textBoxComparedImage);
            this.Controls.Add(this._textBoxRefImage);
            this.Controls.Add(this._menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this._menuStrip;
            this.Name = "FormMain";
            this.Text = "Image Compare";
            ((System.ComponentModel.ISupportInitialize)(this._trackBarColorTolerance)).EndInit();
            this._menuStrip.ResumeLayout(false);
            this._menuStrip.PerformLayout();
            this._groupBoxParameters.ResumeLayout(false);
            this._groupBoxParameters.PerformLayout();
            this._flowLayoutPanelColorCompare.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._trackBarPourcentageOfAcceptablePixels)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar _trackBarColorTolerance;
        private System.Windows.Forms.TextBox _textBoxRefImage;
        private System.Windows.Forms.Label _labelReferenceImagePath;
        private System.Windows.Forms.TextBox _textBoxComparedImage;
        private System.Windows.Forms.Label _labelComparedImagePath;
        private System.Windows.Forms.MenuStrip _menuStrip;
        private System.Windows.Forms.ToolStripMenuItem _fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _compareToolStripMenuItem;
        private System.Windows.Forms.Label _labelColorTolerancePerPixel;
        private System.Windows.Forms.TextBox _textBoxColorTolerancePerPixel;
        private System.Windows.Forms.GroupBox _groupBoxParameters;
        private System.Windows.Forms.RichTextBox _richTextBoxLog;
        private System.Windows.Forms.TextBox _textBoxPourcentageOfAcceptablePixels;
        private System.Windows.Forms.TrackBar _trackBarPourcentageOfAcceptablePixels;
        private System.Windows.Forms.Label _labelPourcentageOfAcceptablePixels;
        private System.Windows.Forms.Button _buttonCompare;
        private System.ComponentModel.BackgroundWorker _backgroundWorkerCompareImages;
        private System.Windows.Forms.ColorDialog _colorDialog;
        private System.Windows.Forms.Label _labelColor1;
        private System.Windows.Forms.Label _labelColor2;
        private System.Windows.Forms.FlowLayoutPanel _flowLayoutPanelColorCompare;
        private System.Windows.Forms.CheckBox _checkBoxIgnoreTransparentPixels;
        private System.Windows.Forms.ToolStripMenuItem _printScreenToolStripMenuItem;
    }
}

