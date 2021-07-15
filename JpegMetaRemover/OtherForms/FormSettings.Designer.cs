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
            this.ContextMenuStripMetaTypesToRemove = new System.Windows.Forms.ContextMenuStrip(this.components);
            this._selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._deselectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GroupBoxMetadatasToRemove = new System.Windows.Forms.GroupBox();
            this.CheckedListBoxMetadataToRemove = new System.Windows.Forms.CheckedListBox();
            this.ButtonSaveSettings = new System.Windows.Forms.Button();
            this.GroupBoxClearSavedSettings = new System.Windows.Forms.GroupBox();
            this.CheckBoxCleanOnDragAndDrop = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.ButtonResetSettings = new System.Windows.Forms.Button();
            this.ContextMenuStripMetaTypesToRemove.SuspendLayout();
            this.GroupBoxMetadatasToRemove.SuspendLayout();
            this.GroupBoxClearSavedSettings.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ContextMenuStripMetaTypesToRemove
            // 
            this.ContextMenuStripMetaTypesToRemove.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._selectAllToolStripMenuItem,
            this._deselectAllToolStripMenuItem});
            this.ContextMenuStripMetaTypesToRemove.Name = "_contextMenuStripMetaTypesToRemove";
            this.ContextMenuStripMetaTypesToRemove.Size = new System.Drawing.Size(136, 48);
            // 
            // _selectAllToolStripMenuItem
            // 
            this._selectAllToolStripMenuItem.AccessibleName = "SettingsContextMenuItemSelectAll";
            this._selectAllToolStripMenuItem.Name = "_selectAllToolStripMenuItem";
            this._selectAllToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this._selectAllToolStripMenuItem.Text = "Select All";
            this._selectAllToolStripMenuItem.Click += new System.EventHandler(this.SelectAllToolStripMenuItem_Click);
            // 
            // _deselectAllToolStripMenuItem
            // 
            this._deselectAllToolStripMenuItem.AccessibleName = "SettingsContextMenuItemDeselectAll";
            this._deselectAllToolStripMenuItem.Name = "_deselectAllToolStripMenuItem";
            this._deselectAllToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this._deselectAllToolStripMenuItem.Text = "Deselect All";
            this._deselectAllToolStripMenuItem.Click += new System.EventHandler(this.DeselectAllToolStripMenuItem_Click);
            // 
            // GroupBoxMetadatasToRemove
            // 
            this.GroupBoxMetadatasToRemove.AccessibleName = "GroupBoxSettingsMetaTypesToRemove";
            this.GroupBoxMetadatasToRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupBoxMetadatasToRemove.Controls.Add(this.CheckedListBoxMetadataToRemove);
            this.GroupBoxMetadatasToRemove.Location = new System.Drawing.Point(9, 10);
            this.GroupBoxMetadatasToRemove.Margin = new System.Windows.Forms.Padding(2);
            this.GroupBoxMetadatasToRemove.Name = "GroupBoxMetadatasToRemove";
            this.GroupBoxMetadatasToRemove.Padding = new System.Windows.Forms.Padding(2);
            this.GroupBoxMetadatasToRemove.Size = new System.Drawing.Size(286, 195);
            this.GroupBoxMetadatasToRemove.TabIndex = 1;
            this.GroupBoxMetadatasToRemove.TabStop = false;
            this.GroupBoxMetadatasToRemove.Text = "Metadata types to remove";
            // 
            // CheckedListBoxMetadataToRemove
            // 
            this.CheckedListBoxMetadataToRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CheckedListBoxMetadataToRemove.ContextMenuStrip = this.ContextMenuStripMetaTypesToRemove;
            this.CheckedListBoxMetadataToRemove.FormattingEnabled = true;
            this.CheckedListBoxMetadataToRemove.Location = new System.Drawing.Point(5, 18);
            this.CheckedListBoxMetadataToRemove.Name = "CheckedListBoxMetadataToRemove";
            this.CheckedListBoxMetadataToRemove.Size = new System.Drawing.Size(276, 169);
            this.CheckedListBoxMetadataToRemove.TabIndex = 1;
            // 
            // ButtonSaveSettings
            // 
            this.ButtonSaveSettings.AccessibleName = "ButtonSettingsSave";
            this.ButtonSaveSettings.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ButtonSaveSettings.AutoSize = true;
            this.ButtonSaveSettings.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ButtonSaveSettings.Location = new System.Drawing.Point(227, 7);
            this.ButtonSaveSettings.Margin = new System.Windows.Forms.Padding(11, 2, 2, 2);
            this.ButtonSaveSettings.MinimumSize = new System.Drawing.Size(60, 0);
            this.ButtonSaveSettings.Name = "ButtonSaveSettings";
            this.ButtonSaveSettings.Size = new System.Drawing.Size(60, 23);
            this.ButtonSaveSettings.TabIndex = 2;
            this.ButtonSaveSettings.Text = "Save";
            this.ButtonSaveSettings.UseVisualStyleBackColor = true;
            this.ButtonSaveSettings.Click += new System.EventHandler(this.ButtonSaveSettings_Click);
            // 
            // GroupBoxClearSavedSettings
            // 
            this.GroupBoxClearSavedSettings.AccessibleName = "GroupBoxSaveSettings";
            this.GroupBoxClearSavedSettings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupBoxClearSavedSettings.Controls.Add(this.CheckBoxCleanOnDragAndDrop);
            this.GroupBoxClearSavedSettings.Location = new System.Drawing.Point(9, 209);
            this.GroupBoxClearSavedSettings.Margin = new System.Windows.Forms.Padding(2);
            this.GroupBoxClearSavedSettings.Name = "GroupBoxClearSavedSettings";
            this.GroupBoxClearSavedSettings.Padding = new System.Windows.Forms.Padding(2);
            this.GroupBoxClearSavedSettings.Size = new System.Drawing.Size(286, 46);
            this.GroupBoxClearSavedSettings.TabIndex = 3;
            this.GroupBoxClearSavedSettings.TabStop = false;
            this.GroupBoxClearSavedSettings.Text = "Misc.";
            // 
            // CheckBoxCleanOnDragAndDrop
            // 
            this.CheckBoxCleanOnDragAndDrop.AccessibleName = "CheckBoxCleanOnDragAndDrop";
            this.CheckBoxCleanOnDragAndDrop.AutoSize = true;
            this.CheckBoxCleanOnDragAndDrop.Location = new System.Drawing.Point(5, 18);
            this.CheckBoxCleanOnDragAndDrop.Name = "CheckBoxCleanOnDragAndDrop";
            this.CheckBoxCleanOnDragAndDrop.Size = new System.Drawing.Size(182, 17);
            this.CheckBoxCleanOnDragAndDrop.TabIndex = 6;
            this.CheckBoxCleanOnDragAndDrop.Text = "Clean immediately on drag && drop";
            this.CheckBoxCleanOnDragAndDrop.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.ButtonSaveSettings, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.ButtonCancel, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.ButtonResetSettings, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 274);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(304, 38);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.AccessibleName = "ButtonSettingsCancel";
            this.ButtonCancel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.ButtonCancel.AutoSize = true;
            this.ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ButtonCancel.Location = new System.Drawing.Point(124, 7);
            this.ButtonCancel.Margin = new System.Windows.Forms.Padding(2, 2, 11, 2);
            this.ButtonCancel.MinimumSize = new System.Drawing.Size(60, 0);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(67, 23);
            this.ButtonCancel.TabIndex = 3;
            this.ButtonCancel.Text = "Cancel";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            // 
            // ButtonResetSettings
            // 
            this.ButtonResetSettings.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ButtonResetSettings.Location = new System.Drawing.Point(13, 7);
            this.ButtonResetSettings.MinimumSize = new System.Drawing.Size(60, 0);
            this.ButtonResetSettings.Name = "ButtonResetSettings";
            this.ButtonResetSettings.Size = new System.Drawing.Size(75, 23);
            this.ButtonResetSettings.TabIndex = 4;
            this.ButtonResetSettings.Text = "Reset";
            this.ButtonResetSettings.UseVisualStyleBackColor = true;
            this.ButtonResetSettings.Click += new System.EventHandler(this.ButtonResetSettings_Click);
            // 
            // FormSettings
            // 
            this.AcceptButton = this.ButtonSaveSettings;
            this.AccessibleName = "FormSettings";
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 312);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.GroupBoxClearSavedSettings);
            this.Controls.Add(this.GroupBoxMetadatasToRemove);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(320, 350);
            this.Name = "FormSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormSettings_FormClosing);
            this.ContextMenuStripMetaTypesToRemove.ResumeLayout(false);
            this.GroupBoxMetadatasToRemove.ResumeLayout(false);
            this.GroupBoxClearSavedSettings.ResumeLayout(false);
            this.GroupBoxClearSavedSettings.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox GroupBoxMetadatasToRemove;
        private System.Windows.Forms.Button ButtonSaveSettings;
        private System.Windows.Forms.GroupBox GroupBoxClearSavedSettings;
        private System.Windows.Forms.ContextMenuStrip ContextMenuStripMetaTypesToRemove;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ToolStripMenuItem _selectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _deselectAllToolStripMenuItem;
        private System.Windows.Forms.CheckBox CheckBoxCleanOnDragAndDrop;
        private System.Windows.Forms.CheckedListBox CheckedListBoxMetadataToRemove;
        private System.Windows.Forms.Button ButtonCancel;
        private System.Windows.Forms.Button ButtonResetSettings;
    }
}