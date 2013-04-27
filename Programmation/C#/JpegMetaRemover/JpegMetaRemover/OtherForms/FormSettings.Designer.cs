namespace JpegMetaRemover.OtherForms
{
    partial class FormSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSettings));
            this._listViewMetadatasToRemove = new System.Windows.Forms.ListView();
            this._columnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._contextMenuStripMetaTypesToRemove = new System.Windows.Forms.ContextMenuStrip(this.components);
            this._selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._deselectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._groupBoxMetadatasToRemove = new System.Windows.Forms.GroupBox();
            this._buttonSaveSettings = new System.Windows.Forms.Button();
            this._buttonCancel = new System.Windows.Forms.Button();
            this._groupBoxClearSavedSettings = new System.Windows.Forms.GroupBox();
            this._checkBoxCleanSavedSettingsOnClose = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this._contextMenuStripMetaTypesToRemove.SuspendLayout();
            this._groupBoxMetadatasToRemove.SuspendLayout();
            this._groupBoxClearSavedSettings.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _listViewMetadatasToRemove
            // 
            this._listViewMetadatasToRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._listViewMetadatasToRemove.CheckBoxes = true;
            this._listViewMetadatasToRemove.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this._columnHeader});
            this._listViewMetadatasToRemove.ContextMenuStrip = this._contextMenuStripMetaTypesToRemove;
            this._listViewMetadatasToRemove.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this._listViewMetadatasToRemove.Location = new System.Drawing.Point(5, 18);
            this._listViewMetadatasToRemove.Name = "_listViewMetadatasToRemove";
            this._listViewMetadatasToRemove.Size = new System.Drawing.Size(277, 190);
            this._listViewMetadatasToRemove.TabIndex = 0;
            this._listViewMetadatasToRemove.UseCompatibleStateImageBehavior = false;
            this._listViewMetadatasToRemove.View = System.Windows.Forms.View.Details;
            // 
            // _columnHeader
            // 
            this._columnHeader.Text = "Metadatas Types";
            this._columnHeader.Width = 200;
            // 
            // _contextMenuStripMetaTypesToRemove
            // 
            this._contextMenuStripMetaTypesToRemove.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._selectAllToolStripMenuItem,
            this._deselectAllToolStripMenuItem});
            this._contextMenuStripMetaTypesToRemove.Name = "_contextMenuStripMetaTypesToRemove";
            this._contextMenuStripMetaTypesToRemove.Size = new System.Drawing.Size(138, 48);
            // 
            // _selectAllToolStripMenuItem
            // 
            this._selectAllToolStripMenuItem.AccessibleName = "SettingsContextMenuItemSelectAll";
            this._selectAllToolStripMenuItem.Name = "_selectAllToolStripMenuItem";
            this._selectAllToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this._selectAllToolStripMenuItem.Text = "Select All";
            this._selectAllToolStripMenuItem.Click += new System.EventHandler(this._selectAllToolStripMenuItem_Click);
            // 
            // _deselectAllToolStripMenuItem
            // 
            this._deselectAllToolStripMenuItem.AccessibleName = "SettingsContextMenuItemDeselectAll";
            this._deselectAllToolStripMenuItem.Name = "_deselectAllToolStripMenuItem";
            this._deselectAllToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this._deselectAllToolStripMenuItem.Text = "Deselect All";
            this._deselectAllToolStripMenuItem.Click += new System.EventHandler(this._deselectAllToolStripMenuItem_Click);
            // 
            // _groupBoxMetadatasToRemove
            // 
            this._groupBoxMetadatasToRemove.AccessibleName = "GroupBoxSettingsMetaTypesToRemove";
            this._groupBoxMetadatasToRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._groupBoxMetadatasToRemove.Controls.Add(this._listViewMetadatasToRemove);
            this._groupBoxMetadatasToRemove.Location = new System.Drawing.Point(9, 10);
            this._groupBoxMetadatasToRemove.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this._groupBoxMetadatasToRemove.Name = "_groupBoxMetadatasToRemove";
            this._groupBoxMetadatasToRemove.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this._groupBoxMetadatasToRemove.Size = new System.Drawing.Size(286, 212);
            this._groupBoxMetadatasToRemove.TabIndex = 1;
            this._groupBoxMetadatasToRemove.TabStop = false;
            this._groupBoxMetadatasToRemove.Text = "Metadata types to remove";
            // 
            // _buttonSaveSettings
            // 
            this._buttonSaveSettings.AccessibleName = "ButtonSettingsSave";
            this._buttonSaveSettings.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this._buttonSaveSettings.AutoSize = true;
            this._buttonSaveSettings.Location = new System.Drawing.Point(163, 7);
            this._buttonSaveSettings.Margin = new System.Windows.Forms.Padding(11, 2, 2, 2);
            this._buttonSaveSettings.Name = "_buttonSaveSettings";
            this._buttonSaveSettings.Size = new System.Drawing.Size(89, 23);
            this._buttonSaveSettings.TabIndex = 2;
            this._buttonSaveSettings.Text = "Save";
            this._buttonSaveSettings.UseVisualStyleBackColor = true;
            this._buttonSaveSettings.Click += new System.EventHandler(this._buttonSaveSettings_Click);
            // 
            // _buttonCancel
            // 
            this._buttonCancel.AccessibleName = "ButtonSettingsCancel";
            this._buttonCancel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this._buttonCancel.AutoSize = true;
            this._buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._buttonCancel.Location = new System.Drawing.Point(52, 7);
            this._buttonCancel.Margin = new System.Windows.Forms.Padding(2, 2, 11, 2);
            this._buttonCancel.Name = "_buttonCancel";
            this._buttonCancel.Size = new System.Drawing.Size(89, 23);
            this._buttonCancel.TabIndex = 2;
            this._buttonCancel.Text = "Cancel";
            this._buttonCancel.UseVisualStyleBackColor = true;
            // 
            // _groupBoxClearSavedSettings
            // 
            this._groupBoxClearSavedSettings.AccessibleName = "GroupBoxSaveSettings";
            this._groupBoxClearSavedSettings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._groupBoxClearSavedSettings.Controls.Add(this._checkBoxCleanSavedSettingsOnClose);
            this._groupBoxClearSavedSettings.Location = new System.Drawing.Point(9, 227);
            this._groupBoxClearSavedSettings.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this._groupBoxClearSavedSettings.Name = "_groupBoxClearSavedSettings";
            this._groupBoxClearSavedSettings.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this._groupBoxClearSavedSettings.Size = new System.Drawing.Size(286, 42);
            this._groupBoxClearSavedSettings.TabIndex = 3;
            this._groupBoxClearSavedSettings.TabStop = false;
            this._groupBoxClearSavedSettings.Text = "Saved settings";
            // 
            // _checkBoxCleanSavedSettingsOnClose
            // 
            this._checkBoxCleanSavedSettingsOnClose.AccessibleName = "CheckBoxCleanSavedSettings";
            this._checkBoxCleanSavedSettingsOnClose.AutoSize = true;
            this._checkBoxCleanSavedSettingsOnClose.Location = new System.Drawing.Point(5, 17);
            this._checkBoxCleanSavedSettingsOnClose.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this._checkBoxCleanSavedSettingsOnClose.Name = "_checkBoxCleanSavedSettingsOnClose";
            this._checkBoxCleanSavedSettingsOnClose.Size = new System.Drawing.Size(167, 17);
            this._checkBoxCleanSavedSettingsOnClose.TabIndex = 0;
            this._checkBoxCleanSavedSettingsOnClose.Text = "Clean saved settings on close";
            this._checkBoxCleanSavedSettingsOnClose.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this._buttonCancel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this._buttonSaveSettings, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 274);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(304, 38);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // FormSettings
            // 
            this.AcceptButton = this._buttonSaveSettings;
            this.AccessibleName = "FormSettings";
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._buttonCancel;
            this.ClientSize = new System.Drawing.Size(304, 312);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this._groupBoxClearSavedSettings);
            this.Controls.Add(this._groupBoxMetadatasToRemove);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(320, 350);
            this.Name = "FormSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormSettings_FormClosing);
            this._contextMenuStripMetaTypesToRemove.ResumeLayout(false);
            this._groupBoxMetadatasToRemove.ResumeLayout(false);
            this._groupBoxClearSavedSettings.ResumeLayout(false);
            this._groupBoxClearSavedSettings.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView _listViewMetadatasToRemove;
        private System.Windows.Forms.ColumnHeader _columnHeader;
        private System.Windows.Forms.GroupBox _groupBoxMetadatasToRemove;
        private System.Windows.Forms.Button _buttonSaveSettings;
        private System.Windows.Forms.Button _buttonCancel;
        private System.Windows.Forms.GroupBox _groupBoxClearSavedSettings;
        private System.Windows.Forms.CheckBox _checkBoxCleanSavedSettingsOnClose;
        private System.Windows.Forms.ContextMenuStrip _contextMenuStripMetaTypesToRemove;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ToolStripMenuItem _selectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _deselectAllToolStripMenuItem;
    }
}