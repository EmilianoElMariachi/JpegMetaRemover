namespace JpegMetaRemover.OtherForms
{
    /// <summary>
    /// Classe Easter Eggs by Emiliano
    /// </summary>
    partial class UCAnimatedText
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

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this._timerAnimation = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // _timerAnimation
            // 
            this._timerAnimation.Interval = 10;
            this._timerAnimation.Tick += new System.EventHandler(this.TimerAnimationTick);
            // 
            // UCAnimatedText
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "UCAnimatedText";
            this.Size = new System.Drawing.Size(189, 35);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer _timerAnimation;
    }
}
