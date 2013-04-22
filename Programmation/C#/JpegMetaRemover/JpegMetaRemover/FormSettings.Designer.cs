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
            this.SuspendLayout();
            // 
            // _listViewMetadatasToRemove
            // 
            this._listViewMetadatasToRemove.Location = new System.Drawing.Point(12, 33);
            this._listViewMetadatasToRemove.Name = "_listViewMetadatasToRemove";
            this._listViewMetadatasToRemove.Size = new System.Drawing.Size(121, 97);
            this._listViewMetadatasToRemove.TabIndex = 0;
            this._listViewMetadatasToRemove.UseCompatibleStateImageBehavior = false;
            // 
            // FormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this._listViewMetadatasToRemove);
            this.Name = "FormSettings";
            this.Text = "Settings";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView _listViewMetadatasToRemove;
    }
}