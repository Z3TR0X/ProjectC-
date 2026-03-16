namespace ProjectC_.UserContent {
    partial class PlotDesign {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent() {
            this.Background = new Krypton.Toolkit.KryptonGroup();
            this.Plot = new ScottPlot.WinForms.FormsPlot();
            ((System.ComponentModel.ISupportInitialize)(this.Background)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Background.Panel)).BeginInit();
            this.Background.Panel.SuspendLayout();
            this.Background.SuspendLayout();
            this.SuspendLayout();
            // 
            // Background
            // 
            this.Background.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Background.Location = new System.Drawing.Point(0, 0);
            // 
            // Background.Panel
            // 
            this.Background.Panel.Controls.Add(this.Plot);
            this.Background.Size = new System.Drawing.Size(557, 263);
            this.Background.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.Background.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.Background.StateCommon.Border.Rounding = 5F;
            this.Background.TabIndex = 0;
            // 
            // Plot
            // 
            this.Plot.DisplayScale = 0F;
            this.Plot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Plot.Location = new System.Drawing.Point(0, 0);
            this.Plot.Name = "Plot";
            this.Plot.Size = new System.Drawing.Size(551, 257);
            this.Plot.TabIndex = 1;
            // 
            // PlotDesign
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(39)))), ((int)(((byte)(46)))));
            this.Controls.Add(this.Background);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "PlotDesign";
            this.Size = new System.Drawing.Size(557, 263);
            ((System.ComponentModel.ISupportInitialize)(this.Background.Panel)).EndInit();
            this.Background.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Background)).EndInit();
            this.Background.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Krypton.Toolkit.KryptonGroup Background;
        private ScottPlot.WinForms.FormsPlot Plot;
    }
}
