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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this._richTextBoxLog = new System.Windows.Forms.RichTextBox();
            this._contextMenuStripLog = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._statusStrip = new System.Windows.Forms.StatusStrip();
            this._menuStrip = new System.Windows.Forms.MenuStrip();
            this.MenuItemFile = new System.Windows.Forms.ToolStripMenuItem();
            this._selectFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._selectDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._runToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._languageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._backgroundWorkerPurify = new System.ComponentModel.BackgroundWorker();
            this._panelContent = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this._buttonRun = new System.Windows.Forms.Button();
            this._tableLayoutPanelInputPath = new System.Windows.Forms.TableLayoutPanel();
            this._labelInputPath = new System.Windows.Forms.Label();
            this._textBoxInputPath = new System.Windows.Forms.TextBox();
            this._buttonBrowseImageFile = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this._groupBoxOutputParams = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this._checkBoxOverride = new System.Windows.Forms.CheckBox();
            this._checkBoxIncludeSubdirectories = new System.Windows.Forms.CheckBox();
            this._groupBoxInputParams = new System.Windows.Forms.GroupBox();
            this._tableLayoutPanelPurifyParams = new System.Windows.Forms.TableLayoutPanel();
            this._checkBoxRemoveMetadatas = new System.Windows.Forms.CheckBox();
            this._checkBoxRemoveComments = new System.Windows.Forms.CheckBox();
            this._progressBar = new System.Windows.Forms.ProgressBar();
            this._contextMenuStripLog.SuspendLayout();
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
            this._richTextBoxLog.ContextMenuStrip = this._contextMenuStripLog;
            this._richTextBoxLog.Location = new System.Drawing.Point(0, 184);
            this._richTextBoxLog.Name = "_richTextBoxLog";
            this._richTextBoxLog.ReadOnly = true;
            this._richTextBoxLog.Size = new System.Drawing.Size(461, 135);
            this._richTextBoxLog.TabIndex = 0;
            this._richTextBoxLog.Text = "";
            this._richTextBoxLog.WordWrap = false;
            // 
            // _contextMenuStripLog
            // 
            this._contextMenuStripLog.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearToolStripMenuItem,
            this.copyToolStripMenuItem});
            this._contextMenuStripLog.Name = "_contextMenuStripLog";
            this._contextMenuStripLog.Size = new System.Drawing.Size(102, 48);
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.AccessibleName = "ClearLog";
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(101, 22);
            this.clearToolStripMenuItem.Text = "Clear";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.AccessibleName = "CopyLog";
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(101, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // _statusStrip
            // 
            this._statusStrip.Location = new System.Drawing.Point(0, 320);
            this._statusStrip.Name = "_statusStrip";
            this._statusStrip.Size = new System.Drawing.Size(461, 22);
            this._statusStrip.TabIndex = 4;
            // 
            // _menuStrip
            // 
            this._menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemFile,
            this._editToolStripMenuItem,
            this._aboutToolStripMenuItem});
            this._menuStrip.Location = new System.Drawing.Point(0, 0);
            this._menuStrip.Name = "_menuStrip";
            this._menuStrip.Size = new System.Drawing.Size(461, 24);
            this._menuStrip.TabIndex = 5;
            this._menuStrip.Text = "menuStrip1";
            // 
            // MenuItemFile
            // 
            this.MenuItemFile.AccessibleName = "MenuItemFile";
            this.MenuItemFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._selectFileToolStripMenuItem,
            this._selectDirectoryToolStripMenuItem,
            this._exitToolStripMenuItem});
            this.MenuItemFile.Name = "MenuItemFile";
            this.MenuItemFile.Size = new System.Drawing.Size(36, 20);
            this.MenuItemFile.Text = "File";
            // 
            // _selectFileToolStripMenuItem
            // 
            this._selectFileToolStripMenuItem.AccessibleName = "MenuItemSelectImage";
            this._selectFileToolStripMenuItem.Name = "_selectFileToolStripMenuItem";
            this._selectFileToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this._selectFileToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this._selectFileToolStripMenuItem.Text = "Select image ...";
            this._selectFileToolStripMenuItem.Click += new System.EventHandler(this._selectFileToolStripMenuItem_Click);
            // 
            // _selectDirectoryToolStripMenuItem
            // 
            this._selectDirectoryToolStripMenuItem.AccessibleName = "MenuItemSelectFolder";
            this._selectDirectoryToolStripMenuItem.Name = "_selectDirectoryToolStripMenuItem";
            this._selectDirectoryToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.O)));
            this._selectDirectoryToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this._selectDirectoryToolStripMenuItem.Text = "Select folder ...";
            this._selectDirectoryToolStripMenuItem.Click += new System.EventHandler(this._selectDirectoryToolStripMenuItem_Click);
            // 
            // _exitToolStripMenuItem
            // 
            this._exitToolStripMenuItem.AccessibleName = "MenuItemExitApp";
            this._exitToolStripMenuItem.Name = "_exitToolStripMenuItem";
            this._exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this._exitToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this._exitToolStripMenuItem.Text = "Exit";
            // 
            // _editToolStripMenuItem
            // 
            this._editToolStripMenuItem.AccessibleName = "MenuItemEdit";
            this._editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._runToolStripMenuItem,
            this._settingsToolStripMenuItem,
            this._languageToolStripMenuItem});
            this._editToolStripMenuItem.Name = "_editToolStripMenuItem";
            this._editToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this._editToolStripMenuItem.Text = "Edit";
            // 
            // _runToolStripMenuItem
            // 
            this._runToolStripMenuItem.AccessibleName = "MenuItemRun";
            this._runToolStripMenuItem.Name = "_runToolStripMenuItem";
            this._runToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this._runToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this._runToolStripMenuItem.Text = "Run";
            this._runToolStripMenuItem.Click += new System.EventHandler(this._runToolStripMenuItem_Click);
            // 
            // _settingsToolStripMenuItem
            // 
            this._settingsToolStripMenuItem.AccessibleName = "MenuItemSettings";
            this._settingsToolStripMenuItem.Name = "_settingsToolStripMenuItem";
            this._settingsToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F10;
            this._settingsToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this._settingsToolStripMenuItem.Text = "Settings ...";
            this._settingsToolStripMenuItem.Click += new System.EventHandler(this._settingsToolStripMenuItem_Click);
            // 
            // _languageToolStripMenuItem
            // 
            this._languageToolStripMenuItem.AccessibleName = "MenuItemLanguage";
            this._languageToolStripMenuItem.Name = "_languageToolStripMenuItem";
            this._languageToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this._languageToolStripMenuItem.Text = "Language";
            // 
            // _aboutToolStripMenuItem
            // 
            this._aboutToolStripMenuItem.Name = "_aboutToolStripMenuItem";
            this._aboutToolStripMenuItem.Size = new System.Drawing.Size(25, 20);
            this._aboutToolStripMenuItem.Text = "?";
            this._aboutToolStripMenuItem.Click += new System.EventHandler(this._aboutToolStripMenuItem_Click);
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
            this._panelContent.Location = new System.Drawing.Point(0, 27);
            this._panelContent.Name = "_panelContent";
            this._panelContent.Size = new System.Drawing.Size(461, 151);
            this._panelContent.TabIndex = 7;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.78261F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75.21739F));
            this.tableLayoutPanel2.Controls.Add(this._tableLayoutPanelInputPath, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this._progressBar, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this._buttonRun, 0, 1);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 65);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(460, 84);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // _buttonRun
            // 
            this._buttonRun.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this._buttonRun.BackgroundImage = global::JpegMetaRemover.Properties.Resources.Play;
            this._buttonRun.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this._buttonRun.Location = new System.Drawing.Point(3, 49);
            this._buttonRun.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
            this._buttonRun.Name = "_buttonRun";
            this._buttonRun.Size = new System.Drawing.Size(100, 29);
            this._buttonRun.TabIndex = 6;
            this._buttonRun.UseVisualStyleBackColor = true;
            this._buttonRun.Click += new System.EventHandler(this._buttonRun_Click);
            // 
            // _tableLayoutPanelInputPath
            // 
            this._tableLayoutPanelInputPath.ColumnCount = 3;
            this.tableLayoutPanel2.SetColumnSpan(this._tableLayoutPanelInputPath, 2);
            this._tableLayoutPanelInputPath.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this._tableLayoutPanelInputPath.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._tableLayoutPanelInputPath.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this._tableLayoutPanelInputPath.Controls.Add(this._labelInputPath, 0, 0);
            this._tableLayoutPanelInputPath.Controls.Add(this._textBoxInputPath, 1, 0);
            this._tableLayoutPanelInputPath.Controls.Add(this._buttonBrowseImageFile, 2, 0);
            this._tableLayoutPanelInputPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tableLayoutPanelInputPath.Location = new System.Drawing.Point(3, 3);
            this._tableLayoutPanelInputPath.Name = "_tableLayoutPanelInputPath";
            this._tableLayoutPanelInputPath.RowCount = 1;
            this._tableLayoutPanelInputPath.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._tableLayoutPanelInputPath.Size = new System.Drawing.Size(454, 37);
            this._tableLayoutPanelInputPath.TabIndex = 8;
            // 
            // _labelInputPath
            // 
            this._labelInputPath.AccessibleName = "LabelInputPath";
            this._labelInputPath.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this._labelInputPath.AutoSize = true;
            this._labelInputPath.Location = new System.Drawing.Point(3, 12);
            this._labelInputPath.Name = "_labelInputPath";
            this._labelInputPath.Size = new System.Drawing.Size(64, 13);
            this._labelInputPath.TabIndex = 8;
            this._labelInputPath.Text = "File or folder";
            // 
            // _textBoxInputPath
            // 
            this._textBoxInputPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this._textBoxInputPath.Location = new System.Drawing.Point(74, 8);
            this._textBoxInputPath.Margin = new System.Windows.Forms.Padding(4);
            this._textBoxInputPath.Name = "_textBoxInputPath";
            this._textBoxInputPath.Size = new System.Drawing.Size(333, 20);
            this._textBoxInputPath.TabIndex = 9;
            this._textBoxInputPath.Text = "TestResources";
            // 
            // _buttonBrowseImageFile
            // 
            this._buttonBrowseImageFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this._buttonBrowseImageFile.Location = new System.Drawing.Point(414, 4);
            this._buttonBrowseImageFile.Name = "_buttonBrowseImageFile";
            this._buttonBrowseImageFile.Size = new System.Drawing.Size(37, 28);
            this._buttonBrowseImageFile.TabIndex = 10;
            this._buttonBrowseImageFile.Text = "...";
            this._buttonBrowseImageFile.UseVisualStyleBackColor = true;
            this._buttonBrowseImageFile.Click += new System.EventHandler(this._buttonBrowseImageFile_Click);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.AutoSize = true;
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.Controls.Add(this._groupBoxOutputParams, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this._groupBoxInputParams, 0, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 8);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(456, 54);
            this.tableLayoutPanel3.TabIndex = 9;
            // 
            // _groupBoxOutputParams
            // 
            this._groupBoxOutputParams.AccessibleName = "GroupBoxOutputParameters";
            this._groupBoxOutputParams.AutoSize = true;
            this._groupBoxOutputParams.Controls.Add(this.tableLayoutPanel1);
            this._groupBoxOutputParams.Dock = System.Windows.Forms.DockStyle.Fill;
            this._groupBoxOutputParams.Location = new System.Drawing.Point(186, 3);
            this._groupBoxOutputParams.Name = "_groupBoxOutputParams";
            this._groupBoxOutputParams.Size = new System.Drawing.Size(267, 48);
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
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(261, 29);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // _checkBoxOverride
            // 
            this._checkBoxOverride.AccessibleName = "CheckBoxOverrideOriginalFile";
            this._checkBoxOverride.AutoSize = true;
            this._checkBoxOverride.Location = new System.Drawing.Point(140, 3);
            this._checkBoxOverride.Name = "_checkBoxOverride";
            this._checkBoxOverride.Size = new System.Drawing.Size(118, 17);
            this._checkBoxOverride.TabIndex = 3;
            this._checkBoxOverride.Text = "Override original file";
            this._checkBoxOverride.UseVisualStyleBackColor = true;
            this._checkBoxOverride.CheckedChanged += new System.EventHandler(this._checkBoxOverride_CheckedChanged);
            // 
            // _checkBoxIncludeSubdirectories
            // 
            this._checkBoxIncludeSubdirectories.AccessibleName = "CheckBoxSearchSubdirectories";
            this._checkBoxIncludeSubdirectories.AutoSize = true;
            this._checkBoxIncludeSubdirectories.Location = new System.Drawing.Point(3, 3);
            this._checkBoxIncludeSubdirectories.Name = "_checkBoxIncludeSubdirectories";
            this._checkBoxIncludeSubdirectories.Size = new System.Drawing.Size(131, 17);
            this._checkBoxIncludeSubdirectories.TabIndex = 3;
            this._checkBoxIncludeSubdirectories.Text = "Search sub directories";
            this._checkBoxIncludeSubdirectories.UseVisualStyleBackColor = true;
            this._checkBoxIncludeSubdirectories.CheckedChanged += new System.EventHandler(this._checkBoxIncludeSubdirectories_CheckedChanged);
            // 
            // _groupBoxInputParams
            // 
            this._groupBoxInputParams.AccessibleName = "GroupBoxElementsToRemove";
            this._groupBoxInputParams.AutoSize = true;
            this._groupBoxInputParams.Controls.Add(this._tableLayoutPanelPurifyParams);
            this._groupBoxInputParams.Dock = System.Windows.Forms.DockStyle.Fill;
            this._groupBoxInputParams.Location = new System.Drawing.Point(4, 4);
            this._groupBoxInputParams.Margin = new System.Windows.Forms.Padding(4);
            this._groupBoxInputParams.Name = "_groupBoxInputParams";
            this._groupBoxInputParams.Padding = new System.Windows.Forms.Padding(4);
            this._groupBoxInputParams.Size = new System.Drawing.Size(175, 46);
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
            this._tableLayoutPanelPurifyParams.Location = new System.Drawing.Point(4, 17);
            this._tableLayoutPanelPurifyParams.Name = "_tableLayoutPanelPurifyParams";
            this._tableLayoutPanelPurifyParams.RowCount = 1;
            this._tableLayoutPanelPurifyParams.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._tableLayoutPanelPurifyParams.Size = new System.Drawing.Size(167, 25);
            this._tableLayoutPanelPurifyParams.TabIndex = 1;
            // 
            // _checkBoxRemoveMetadatas
            // 
            this._checkBoxRemoveMetadatas.AccessibleName = "CheckBoxRemoveMetadatas";
            this._checkBoxRemoveMetadatas.AutoSize = true;
            this._checkBoxRemoveMetadatas.Location = new System.Drawing.Point(87, 4);
            this._checkBoxRemoveMetadatas.Margin = new System.Windows.Forms.Padding(4);
            this._checkBoxRemoveMetadatas.Name = "_checkBoxRemoveMetadatas";
            this._checkBoxRemoveMetadatas.Size = new System.Drawing.Size(76, 17);
            this._checkBoxRemoveMetadatas.TabIndex = 3;
            this._checkBoxRemoveMetadatas.Text = "Metadatas";
            this._checkBoxRemoveMetadatas.UseVisualStyleBackColor = true;
            this._checkBoxRemoveMetadatas.CheckedChanged += new System.EventHandler(this._checkBoxRemoveMetadatas_CheckedChanged);
            // 
            // _checkBoxRemoveComments
            // 
            this._checkBoxRemoveComments.AccessibleName = "CheckBoxRemoveComments";
            this._checkBoxRemoveComments.AutoSize = true;
            this._checkBoxRemoveComments.Location = new System.Drawing.Point(4, 4);
            this._checkBoxRemoveComments.Margin = new System.Windows.Forms.Padding(4);
            this._checkBoxRemoveComments.Name = "_checkBoxRemoveComments";
            this._checkBoxRemoveComments.Size = new System.Drawing.Size(75, 17);
            this._checkBoxRemoveComments.TabIndex = 3;
            this._checkBoxRemoveComments.Text = "Comments";
            this._checkBoxRemoveComments.UseVisualStyleBackColor = true;
            this._checkBoxRemoveComments.CheckedChanged += new System.EventHandler(this._checkBoxRemoveComments_CheckedChanged);
            // 
            // _progressBar
            // 
            this._progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this._progressBar.Location = new System.Drawing.Point(116, 49);
            this._progressBar.Name = "_progressBar";
            this._progressBar.Size = new System.Drawing.Size(341, 29);
            this._progressBar.Step = 1;
            this._progressBar.TabIndex = 9;
            // 
            // FormMain
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(461, 342);
            this.Controls.Add(this._panelContent);
            this.Controls.Add(this._richTextBoxLog);
            this.Controls.Add(this._statusStrip);
            this.Controls.Add(this._menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this._menuStrip;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormMain";
            this.Text = "Jpeg Metadatas Remover";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMain_FormClosed);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.FormMain_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.OnDragEnter);
            this._contextMenuStripLog.ResumeLayout(false);
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
        private System.Windows.Forms.ToolStripMenuItem MenuItemFile;
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
        private System.Windows.Forms.GroupBox _groupBoxOutputParams;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.CheckBox _checkBoxOverride;
        private System.Windows.Forms.CheckBox _checkBoxIncludeSubdirectories;
        private System.Windows.Forms.GroupBox _groupBoxInputParams;
        private System.Windows.Forms.TableLayoutPanel _tableLayoutPanelPurifyParams;
        private System.Windows.Forms.CheckBox _checkBoxRemoveMetadatas;
        private System.Windows.Forms.CheckBox _checkBoxRemoveComments;
        private System.Windows.Forms.TableLayoutPanel _tableLayoutPanelInputPath;
        private System.Windows.Forms.Label _labelInputPath;
        private System.Windows.Forms.TextBox _textBoxInputPath;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.ToolStripMenuItem _settingsToolStripMenuItem;
        private System.Windows.Forms.Button _buttonBrowseImageFile;
        private System.Windows.Forms.ContextMenuStrip _contextMenuStripLog;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ProgressBar _progressBar;
    }
}

