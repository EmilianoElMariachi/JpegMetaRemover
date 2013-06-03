namespace JpegMetaRemover.OtherForms
{
    partial class FormAbout
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
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
            this.okButton = new System.Windows.Forms.Button();
            this._tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this._labelToolName = new System.Windows.Forms.Label();
            this._ucAnimatedText = new JpegMetaRemover.OtherForms.UCAnimatedText();
            this._labelVersion = new System.Windows.Forms.Label();
            this._tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.okButton.BackColor = System.Drawing.SystemColors.Control;
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.okButton.Location = new System.Drawing.Point(95, 99);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(70, 24);
            this.okButton.TabIndex = 26;
            this.okButton.Text = "&OK";
            this.okButton.UseVisualStyleBackColor = true;
            // 
            // _tableLayoutPanel
            // 
            this._tableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._tableLayoutPanel.ColumnCount = 1;
            this._tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this._tableLayoutPanel.Controls.Add(this._labelToolName, 0, 0);
            this._tableLayoutPanel.Controls.Add(this._ucAnimatedText, 0, 3);
            this._tableLayoutPanel.Controls.Add(this._labelVersion, 0, 1);
            this._tableLayoutPanel.Location = new System.Drawing.Point(12, 12);
            this._tableLayoutPanel.Name = "_tableLayoutPanel";
            this._tableLayoutPanel.RowCount = 4;
            this._tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this._tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this._tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this._tableLayoutPanel.Size = new System.Drawing.Size(233, 81);
            this._tableLayoutPanel.TabIndex = 27;
            // 
            // _labelToolName
            // 
            this._labelToolName.Dock = System.Windows.Forms.DockStyle.Fill;
            this._labelToolName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._labelToolName.Location = new System.Drawing.Point(3, 0);
            this._labelToolName.Name = "_labelToolName";
            this._labelToolName.Size = new System.Drawing.Size(227, 23);
            this._labelToolName.TabIndex = 0;
            this._labelToolName.Text = "Jpeg Meta Remover";
            this._labelToolName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _ucAnimatedText
            // 
            this._ucAnimatedText.Dock = System.Windows.Forms.DockStyle.Fill;
            this._ucAnimatedText.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ucAnimatedText.Location = new System.Drawing.Point(3, 64);
            this._ucAnimatedText.Name = "_ucAnimatedText";
            this._ucAnimatedText.Size = new System.Drawing.Size(227, 14);
            this._ucAnimatedText.TabIndex = 3;
            this._ucAnimatedText.Click += new System.EventHandler(this._ucAnimatedText_Click);
            this._ucAnimatedText.MouseLeave += new System.EventHandler(this._ucAnimatedText_MouseLeave);
            this._ucAnimatedText.MouseHover += new System.EventHandler(this._ucAnimatedText_MouseHover);
            // 
            // _labelVersion
            // 
            this._labelVersion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this._labelVersion.AutoSize = true;
            this._labelVersion.Location = new System.Drawing.Point(92, 35);
            this._labelVersion.Name = "_labelVersion";
            this._labelVersion.Size = new System.Drawing.Size(49, 13);
            this._labelVersion.TabIndex = 4;
            this._labelVersion.Text = "v1.X.X.X";
            // 
            // FormAbout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(257, 135);
            this.Controls.Add(this._tableLayoutPanel);
            this.Controls.Add(this.okButton);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAbout";
            this.Padding = new System.Windows.Forms.Padding(9);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "?";
            this.VisibleChanged += new System.EventHandler(this.FormAbout_VisibleChanged);
            this._tableLayoutPanel.ResumeLayout(false);
            this._tableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.TableLayoutPanel _tableLayoutPanel;
        private System.Windows.Forms.Label _labelToolName;
        private JpegMetaRemover.OtherForms.UCAnimatedText _ucAnimatedText;
        private System.Windows.Forms.Label _labelVersion;
    }
}
