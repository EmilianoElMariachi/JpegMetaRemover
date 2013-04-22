namespace JpegMetaRemover
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
            this._listViewMetadatasToRemove = new System.Windows.Forms.ListView();
            this._columnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._groupBoxMetadatasToRemove = new System.Windows.Forms.GroupBox();
            this._buttonSaveSettings = new System.Windows.Forms.Button();
            this._buttonCancel = new System.Windows.Forms.Button();
            this._groupBoxMetadatasToRemove.SuspendLayout();
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
            this._listViewMetadatasToRemove.Location = new System.Drawing.Point(7, 22);
            this._listViewMetadatasToRemove.Margin = new System.Windows.Forms.Padding(4);
            this._listViewMetadatasToRemove.Name = "_listViewMetadatasToRemove";
            this._listViewMetadatasToRemove.Size = new System.Drawing.Size(375, 294);
            this._listViewMetadatasToRemove.TabIndex = 0;
            this._listViewMetadatasToRemove.UseCompatibleStateImageBehavior = false;
            this._listViewMetadatasToRemove.View = System.Windows.Forms.View.Details;
            // 
            // _columnHeader
            // 
            this._columnHeader.Text = "Metadatas Types";
            this._columnHeader.Width = 345;
            // 
            // _groupBoxMetadatasToRemove
            // 
            this._groupBoxMetadatasToRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._groupBoxMetadatasToRemove.Controls.Add(this._listViewMetadatasToRemove);
            this._groupBoxMetadatasToRemove.Location = new System.Drawing.Point(12, 12);
            this._groupBoxMetadatasToRemove.Name = "_groupBoxMetadatasToRemove";
            this._groupBoxMetadatasToRemove.Size = new System.Drawing.Size(389, 323);
            this._groupBoxMetadatasToRemove.TabIndex = 1;
            this._groupBoxMetadatasToRemove.TabStop = false;
            this._groupBoxMetadatasToRemove.Text = "Metadatas to remove";
            // 
            // _buttonSaveSettings
            // 
            this._buttonSaveSettings.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this._buttonSaveSettings.Location = new System.Drawing.Point(238, 341);
            this._buttonSaveSettings.Name = "_buttonSaveSettings";
            this._buttonSaveSettings.Size = new System.Drawing.Size(93, 37);
            this._buttonSaveSettings.TabIndex = 2;
            this._buttonSaveSettings.Text = "Save";
            this._buttonSaveSettings.UseVisualStyleBackColor = true;
            this._buttonSaveSettings.Click += new System.EventHandler(this._buttonSaveSettings_Click);
            // 
            // _buttonCancel
            // 
            this._buttonCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this._buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._buttonCancel.Location = new System.Drawing.Point(99, 341);
            this._buttonCancel.Name = "_buttonCancel";
            this._buttonCancel.Size = new System.Drawing.Size(93, 37);
            this._buttonCancel.TabIndex = 2;
            this._buttonCancel.Text = "Cancel";
            this._buttonCancel.UseVisualStyleBackColor = true;
            // 
            // FormSettings
            // 
            this.AcceptButton = this._buttonSaveSettings;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._buttonCancel;
            this.ClientSize = new System.Drawing.Size(413, 388);
            this.Controls.Add(this._buttonCancel);
            this.Controls.Add(this._buttonSaveSettings);
            this.Controls.Add(this._groupBoxMetadatasToRemove);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormSettings";
            this.Text = "Settings";
            this._groupBoxMetadatasToRemove.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView _listViewMetadatasToRemove;
        private System.Windows.Forms.ColumnHeader _columnHeader;
        private System.Windows.Forms.GroupBox _groupBoxMetadatasToRemove;
        private System.Windows.Forms.Button _buttonSaveSettings;
        private System.Windows.Forms.Button _buttonCancel;
    }
}