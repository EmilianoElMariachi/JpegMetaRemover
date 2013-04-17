namespace JpegMetaRemover
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
            this._richTextBoxLog = new System.Windows.Forms.RichTextBox();
            this._statusStrip = new System.Windows.Forms.StatusStrip();
            this._menuStrip = new System.Windows.Forms.MenuStrip();
            this._fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._selectFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._selectDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._runToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._languageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._backgroundWorkerPurify = new System.ComponentModel.BackgroundWorker();
            this._panelContent = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this._buttonRun = new System.Windows.Forms.Button();
            this._buttonCancel = new System.Windows.Forms.Button();
            this._progressBar = new System.Windows.Forms.ProgressBar();
            this._tableLayoutPanelInputPath = new System.Windows.Forms.TableLayoutPanel();
            this._labelInputPath = new System.Windows.Forms.Label();
            this._textBoxInputPath = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this._groupBoxOutputParams = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this._checkBoxOverride = new System.Windows.Forms.CheckBox();
            this._checkBoxIncludeSubdirectories = new System.Windows.Forms.CheckBox();
            this._groupBoxInputParams = new System.Windows.Forms.GroupBox();
            this._tableLayoutPanelPurifyParams = new System.Windows.Forms.TableLayoutPanel();
            this._checkBoxRemoveMetadatas = new System.Windows.Forms.CheckBox();
            this._checkBoxRemoveComments = new System.Windows.Forms.CheckBox();
            this._menuStrip.SuspendLayout();
            this._panelContent.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this._tableLayoutPanelInputPath.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this._groupBoxOutputParams.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this._groupBoxInputParams.SuspendLayout();
            this._tableLayoutPanelPurifyParams.SuspendLayout();
            this.SuspendLayout();
            // 
            // _richTextBoxLog
            // 
            this._richTextBoxLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._richTextBoxLog.BackColor = System.Drawing.Color.White;
            this._richTextBoxLog.Location = new System.Drawing.Point(0, 268);
            this._richTextBoxLog.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this._richTextBoxLog.Name = "_richTextBoxLog";
            this._richTextBoxLog.ReadOnly = true;
            this._richTextBoxLog.Size = new System.Drawing.Size(721, 107);
            this._richTextBoxLog.TabIndex = 0;
            this._richTextBoxLog.Text = "";
            this._richTextBoxLog.WordWrap = false;
            // 
            // _statusStrip
            // 
            this._statusStrip.Location = new System.Drawing.Point(0, 382);
            this._statusStrip.Name = "_statusStrip";
            this._statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this._statusStrip.Size = new System.Drawing.Size(723, 22);
            this._statusStrip.TabIndex = 4;
            // 
            // _menuStrip
            // 
            this._menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._fileToolStripMenuItem,
            this._editToolStripMenuItem,
            this._aboutToolStripMenuItem});
            this._menuStrip.Location = new System.Drawing.Point(0, 0);
            this._menuStrip.Name = "_menuStrip";
            this._menuStrip.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this._menuStrip.Size = new System.Drawing.Size(723, 28);
            this._menuStrip.TabIndex = 5;
            this._menuStrip.Text = "menuStrip1";
            // 
            // _fileToolStripMenuItem
            // 
            this._fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._selectFileToolStripMenuItem,
            this._selectDirectoryToolStripMenuItem,
            this._exitToolStripMenuItem});
            this._fileToolStripMenuItem.Name = "_fileToolStripMenuItem";
            this._fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this._fileToolStripMenuItem.Text = "File";
            // 
            // _selectFileToolStripMenuItem
            // 
            this._selectFileToolStripMenuItem.Name = "_selectFileToolStripMenuItem";
            this._selectFileToolStripMenuItem.Size = new System.Drawing.Size(177, 24);
            this._selectFileToolStripMenuItem.Text = "Select image ...";
            // 
            // _selectDirectoryToolStripMenuItem
            // 
            this._selectDirectoryToolStripMenuItem.Name = "_selectDirectoryToolStripMenuItem";
            this._selectDirectoryToolStripMenuItem.Size = new System.Drawing.Size(177, 24);
            this._selectDirectoryToolStripMenuItem.Text = "Select folder ...";
            // 
            // _exitToolStripMenuItem
            // 
            this._exitToolStripMenuItem.Name = "_exitToolStripMenuItem";
            this._exitToolStripMenuItem.Size = new System.Drawing.Size(177, 24);
            this._exitToolStripMenuItem.Text = "Exit";
            // 
            // _editToolStripMenuItem
            // 
            this._editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._runToolStripMenuItem,
            this._languageToolStripMenuItem});
            this._editToolStripMenuItem.Name = "_editToolStripMenuItem";
            this._editToolStripMenuItem.Size = new System.Drawing.Size(47, 24);
            this._editToolStripMenuItem.Text = "Edit";
            // 
            // _runToolStripMenuItem
            // 
            this._runToolStripMenuItem.Name = "_runToolStripMenuItem";
            this._runToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this._runToolStripMenuItem.Size = new System.Drawing.Size(143, 24);
            this._runToolStripMenuItem.Text = "Run";
            this._runToolStripMenuItem.Click += new System.EventHandler(this._runToolStripMenuItem_Click);
            // 
            // _languageToolStripMenuItem
            // 
            this._languageToolStripMenuItem.Name = "_languageToolStripMenuItem";
            this._languageToolStripMenuItem.Size = new System.Drawing.Size(143, 24);
            this._languageToolStripMenuItem.Text = "Language";
            // 
            // _aboutToolStripMenuItem
            // 
            this._aboutToolStripMenuItem.Name = "_aboutToolStripMenuItem";
            this._aboutToolStripMenuItem.Size = new System.Drawing.Size(28, 24);
            this._aboutToolStripMenuItem.Text = "?";
            // 
            // _backgroundWorkerPurify
            // 
            this._backgroundWorkerPurify.WorkerReportsProgress = true;
            this._backgroundWorkerPurify.WorkerSupportsCancellation = true;
            this._backgroundWorkerPurify.DoWork += new System.ComponentModel.DoWorkEventHandler(this._backgroundWorkerPurify_DoWork);
            this._backgroundWorkerPurify.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this._backgroundWorkerPurify_ProgressChanged);
            this._backgroundWorkerPurify.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this._backgroundWorkerPurify_RunWorkerCompleted);
            // 
            // _panelContent
            // 
            this._panelContent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._panelContent.AutoScroll = true;
            this._panelContent.Controls.Add(this.tableLayoutPanel2);
            this._panelContent.Controls.Add(this.tableLayoutPanel3);
            this._panelContent.Location = new System.Drawing.Point(0, 33);
            this._panelContent.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this._panelContent.Name = "_panelContent";
            this._panelContent.Size = new System.Drawing.Size(723, 228);
            this._panelContent.TabIndex = 7;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this._buttonRun, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this._buttonCancel, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this._progressBar, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this._tableLayoutPanelInputPath, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(4, 76);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(715, 140);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // _buttonRun
            // 
            this._buttonRun.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._buttonRun.BackgroundImage = global::JpegMetaRemover.Properties.Resources.Play;
            this._buttonRun.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this._buttonRun.Location = new System.Drawing.Point(211, 58);
            this._buttonRun.Margin = new System.Windows.Forms.Padding(4, 4, 13, 4);
            this._buttonRun.Name = "_buttonRun";
            this._buttonRun.Size = new System.Drawing.Size(133, 44);
            this._buttonRun.TabIndex = 6;
            this._buttonRun.UseVisualStyleBackColor = true;
            this._buttonRun.Click += new System.EventHandler(this._buttonRun_Click);
            // 
            // _buttonCancel
            // 
            this._buttonCancel.BackgroundImage = global::JpegMetaRemover.Properties.Resources.Stop;
            this._buttonCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this._buttonCancel.Location = new System.Drawing.Point(370, 58);
            this._buttonCancel.Margin = new System.Windows.Forms.Padding(13, 4, 4, 4);
            this._buttonCancel.Name = "_buttonCancel";
            this._buttonCancel.Size = new System.Drawing.Size(133, 44);
            this._buttonCancel.TabIndex = 6;
            this._buttonCancel.UseVisualStyleBackColor = true;
            this._buttonCancel.Click += new System.EventHandler(this._buttonCancel_Click);
            // 
            // _progressBar
            // 
            this._progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.SetColumnSpan(this._progressBar, 2);
            this._progressBar.Location = new System.Drawing.Point(4, 110);
            this._progressBar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this._progressBar.Name = "_progressBar";
            this._progressBar.Size = new System.Drawing.Size(707, 26);
            this._progressBar.TabIndex = 7;
            // 
            // _tableLayoutPanelInputPath
            // 
            this._tableLayoutPanelInputPath.ColumnCount = 2;
            this.tableLayoutPanel2.SetColumnSpan(this._tableLayoutPanelInputPath, 2);
            this._tableLayoutPanelInputPath.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this._tableLayoutPanelInputPath.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._tableLayoutPanelInputPath.Controls.Add(this._labelInputPath, 0, 0);
            this._tableLayoutPanelInputPath.Controls.Add(this._textBoxInputPath, 1, 0);
            this._tableLayoutPanelInputPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tableLayoutPanelInputPath.Location = new System.Drawing.Point(4, 4);
            this._tableLayoutPanelInputPath.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this._tableLayoutPanelInputPath.Name = "_tableLayoutPanelInputPath";
            this._tableLayoutPanelInputPath.RowCount = 1;
            this._tableLayoutPanelInputPath.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._tableLayoutPanelInputPath.Size = new System.Drawing.Size(707, 46);
            this._tableLayoutPanelInputPath.TabIndex = 8;
            // 
            // _labelInputPath
            // 
            this._labelInputPath.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this._labelInputPath.AutoSize = true;
            this._labelInputPath.Location = new System.Drawing.Point(4, 14);
            this._labelInputPath.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this._labelInputPath.Name = "_labelInputPath";
            this._labelInputPath.Size = new System.Drawing.Size(87, 17);
            this._labelInputPath.TabIndex = 8;
            this._labelInputPath.Text = "File or folder";
            // 
            // _textBoxInputPath
            // 
            this._textBoxInputPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this._textBoxInputPath.Location = new System.Drawing.Point(99, 12);
            this._textBoxInputPath.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this._textBoxInputPath.Name = "_textBoxInputPath";
            this._textBoxInputPath.Size = new System.Drawing.Size(604, 22);
            this._textBoxInputPath.TabIndex = 9;
            this._textBoxInputPath.Text = "c:\\Test";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.AutoSize = true;
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.Controls.Add(this._groupBoxOutputParams, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this._groupBoxInputParams, 0, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(4, 10);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(717, 66);
            this.tableLayoutPanel3.TabIndex = 9;
            // 
            // _groupBoxOutputParams
            // 
            this._groupBoxOutputParams.AutoSize = true;
            this._groupBoxOutputParams.Controls.Add(this.tableLayoutPanel1);
            this._groupBoxOutputParams.Dock = System.Windows.Forms.DockStyle.Fill;
            this._groupBoxOutputParams.Location = new System.Drawing.Point(316, 4);
            this._groupBoxOutputParams.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this._groupBoxOutputParams.Name = "_groupBoxOutputParams";
            this._groupBoxOutputParams.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this._groupBoxOutputParams.Size = new System.Drawing.Size(397, 58);
            this._groupBoxOutputParams.TabIndex = 7;
            this._groupBoxOutputParams.TabStop = false;
            this._groupBoxOutputParams.Text = "Output parameters";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this._checkBoxOverride, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this._checkBoxIncludeSubdirectories, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(4, 19);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(389, 35);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // _checkBoxOverride
            // 
            this._checkBoxOverride.AutoSize = true;
            this._checkBoxOverride.Location = new System.Drawing.Point(137, 4);
            this._checkBoxOverride.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this._checkBoxOverride.Name = "_checkBoxOverride";
            this._checkBoxOverride.Size = new System.Drawing.Size(85, 21);
            this._checkBoxOverride.TabIndex = 3;
            this._checkBoxOverride.Text = "Override";
            this._checkBoxOverride.UseVisualStyleBackColor = true;
            // 
            // _checkBoxIncludeSubdirectories
            // 
            this._checkBoxIncludeSubdirectories.AutoSize = true;
            this._checkBoxIncludeSubdirectories.Location = new System.Drawing.Point(4, 4);
            this._checkBoxIncludeSubdirectories.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this._checkBoxIncludeSubdirectories.Name = "_checkBoxIncludeSubdirectories";
            this._checkBoxIncludeSubdirectories.Size = new System.Drawing.Size(125, 21);
            this._checkBoxIncludeSubdirectories.TabIndex = 3;
            this._checkBoxIncludeSubdirectories.Text = "Sub directories";
            this._checkBoxIncludeSubdirectories.UseVisualStyleBackColor = true;
            // 
            // _groupBoxInputParams
            // 
            this._groupBoxInputParams.AutoSize = true;
            this._groupBoxInputParams.Controls.Add(this._tableLayoutPanelPurifyParams);
            this._groupBoxInputParams.Dock = System.Windows.Forms.DockStyle.Fill;
            this._groupBoxInputParams.Location = new System.Drawing.Point(4, 4);
            this._groupBoxInputParams.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this._groupBoxInputParams.Name = "_groupBoxInputParams";
            this._groupBoxInputParams.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this._groupBoxInputParams.Size = new System.Drawing.Size(304, 58);
            this._groupBoxInputParams.TabIndex = 6;
            this._groupBoxInputParams.TabStop = false;
            this._groupBoxInputParams.Text = "Elements to remove";
            // 
            // _tableLayoutPanelPurifyParams
            // 
            this._tableLayoutPanelPurifyParams.AutoSize = true;
            this._tableLayoutPanelPurifyParams.ColumnCount = 2;
            this._tableLayoutPanelPurifyParams.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this._tableLayoutPanelPurifyParams.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this._tableLayoutPanelPurifyParams.Controls.Add(this._checkBoxRemoveMetadatas, 1, 0);
            this._tableLayoutPanelPurifyParams.Controls.Add(this._checkBoxRemoveComments, 0, 0);
            this._tableLayoutPanelPurifyParams.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tableLayoutPanelPurifyParams.Location = new System.Drawing.Point(4, 19);
            this._tableLayoutPanelPurifyParams.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this._tableLayoutPanelPurifyParams.Name = "_tableLayoutPanelPurifyParams";
            this._tableLayoutPanelPurifyParams.RowCount = 1;
            this._tableLayoutPanelPurifyParams.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._tableLayoutPanelPurifyParams.Size = new System.Drawing.Size(296, 35);
            this._tableLayoutPanelPurifyParams.TabIndex = 1;
            // 
            // _checkBoxRemoveMetadatas
            // 
            this._checkBoxRemoveMetadatas.AutoSize = true;
            this._checkBoxRemoveMetadatas.Location = new System.Drawing.Point(151, 4);
            this._checkBoxRemoveMetadatas.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this._checkBoxRemoveMetadatas.Name = "_checkBoxRemoveMetadatas";
            this._checkBoxRemoveMetadatas.Size = new System.Drawing.Size(141, 21);
            this._checkBoxRemoveMetadatas.TabIndex = 3;
            this._checkBoxRemoveMetadatas.Text = "Delete metadatas";
            this._checkBoxRemoveMetadatas.UseVisualStyleBackColor = true;
            // 
            // _checkBoxRemoveComments
            // 
            this._checkBoxRemoveComments.AutoSize = true;
            this._checkBoxRemoveComments.Location = new System.Drawing.Point(4, 4);
            this._checkBoxRemoveComments.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this._checkBoxRemoveComments.Name = "_checkBoxRemoveComments";
            this._checkBoxRemoveComments.Size = new System.Drawing.Size(139, 21);
            this._checkBoxRemoveComments.TabIndex = 3;
            this._checkBoxRemoveComments.Text = "Delete comments";
            this._checkBoxRemoveComments.UseVisualStyleBackColor = true;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 404);
            this.Controls.Add(this._panelContent);
            this.Controls.Add(this._richTextBoxLog);
            this.Controls.Add(this._statusStrip);
            this.Controls.Add(this._menuStrip);
            this.MainMenuStrip = this._menuStrip;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FormMain";
            this.Text = "Jpeg Metadatas Remover";
            this._menuStrip.ResumeLayout(false);
            this._menuStrip.PerformLayout();
            this._panelContent.ResumeLayout(false);
            this._panelContent.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this._tableLayoutPanelInputPath.ResumeLayout(false);
            this._tableLayoutPanelInputPath.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this._groupBoxOutputParams.ResumeLayout(false);
            this._groupBoxOutputParams.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this._groupBoxInputParams.ResumeLayout(false);
            this._groupBoxInputParams.PerformLayout();
            this._tableLayoutPanelPurifyParams.ResumeLayout(false);
            this._tableLayoutPanelPurifyParams.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox _richTextBoxLog;
        private System.Windows.Forms.StatusStrip _statusStrip;
        private System.Windows.Forms.MenuStrip _menuStrip;
        private System.Windows.Forms.ToolStripMenuItem _fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _selectFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _selectDirectoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _runToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _languageToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker _backgroundWorkerPurify;
        private System.Windows.Forms.Panel _panelContent;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button _buttonRun;
        private System.Windows.Forms.Button _buttonCancel;
        private System.Windows.Forms.GroupBox _groupBoxOutputParams;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.CheckBox _checkBoxOverride;
        private System.Windows.Forms.CheckBox _checkBoxIncludeSubdirectories;
        private System.Windows.Forms.ProgressBar _progressBar;
        private System.Windows.Forms.GroupBox _groupBoxInputParams;
        private System.Windows.Forms.TableLayoutPanel _tableLayoutPanelPurifyParams;
        private System.Windows.Forms.CheckBox _checkBoxRemoveMetadatas;
        private System.Windows.Forms.CheckBox _checkBoxRemoveComments;
        private System.Windows.Forms.TableLayoutPanel _tableLayoutPanelInputPath;
        private System.Windows.Forms.Label _labelInputPath;
        private System.Windows.Forms.TextBox _textBoxInputPath;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
    }
}

