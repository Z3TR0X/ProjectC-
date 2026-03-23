namespace ProjectC_.UserContent {
    partial class PanelConsoleControl {
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
            this.VarItem = new Krypton.Toolkit.KryptonPanel();
            this.Image = new Krypton.Toolkit.KryptonPanel();
            this.Id = new Krypton.Toolkit.KryptonLabel();
            this.ConsoleName = new Krypton.Toolkit.KryptonLabel();
            ((System.ComponentModel.ISupportInitialize)(this.VarItem)).BeginInit();
            this.VarItem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Image)).BeginInit();
            this.SuspendLayout();
            // 
            // VarItem
            // 
            this.VarItem.Controls.Add(this.Image);
            this.VarItem.Controls.Add(this.Id);
            this.VarItem.Controls.Add(this.ConsoleName);
            this.VarItem.Dock = System.Windows.Forms.DockStyle.Top;
            this.VarItem.Location = new System.Drawing.Point(0, 0);
            this.VarItem.Name = "VarItem";
            this.VarItem.Size = new System.Drawing.Size(265, 45);
            this.VarItem.StateCommon.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(39)))), ((int)(((byte)(46)))));
            this.VarItem.StateCommon.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Solid;
            this.VarItem.TabIndex = 4;
            // 
            // Image
            // 
            this.Image.Location = new System.Drawing.Point(10, 10);
            this.Image.Name = "Image";
            this.Image.Size = new System.Drawing.Size(23, 23);
            this.Image.StateCommon.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(39)))), ((int)(((byte)(46)))));
            this.Image.StateCommon.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Solid;
            this.Image.StateCommon.Image = global::ProjectC_.Properties.Resources.Console;
            this.Image.StateCommon.ImageStyle = Krypton.Toolkit.PaletteImageStyle.CenterMiddle;
            this.Image.TabIndex = 5;
            // 
            // Id
            // 
            this.Id.Location = new System.Drawing.Point(270, 4);
            this.Id.Margin = new System.Windows.Forms.Padding(0);
            this.Id.Name = "Id";
            this.Id.Size = new System.Drawing.Size(28, 33);
            this.Id.StateCommon.ShortText.Color1 = System.Drawing.Color.DarkGray;
            this.Id.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Id.TabIndex = 4;
            this.Id.Values.Text = "1";
            // 
            // ConsoleName
            // 
            this.ConsoleName.Enabled = false;
            this.ConsoleName.Location = new System.Drawing.Point(40, 2);
            this.ConsoleName.Margin = new System.Windows.Forms.Padding(0);
            this.ConsoleName.MaximumSize = new System.Drawing.Size(250, 0);
            this.ConsoleName.Name = "ConsoleName";
            this.ConsoleName.Size = new System.Drawing.Size(200, 32);
            this.ConsoleName.StateCommon.Padding = new System.Windows.Forms.Padding(-1, 3, -1, 1);
            this.ConsoleName.StateCommon.ShortText.Color1 = System.Drawing.Color.DarkGray;
            this.ConsoleName.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConsoleName.TabIndex = 1;
            this.ConsoleName.Values.Text = "Console Test";
            // 
            // PanelConsoleControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.VarItem);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "PanelConsoleControl";
            this.Size = new System.Drawing.Size(265, 45);
            ((System.ComponentModel.ISupportInitialize)(this.VarItem)).EndInit();
            this.VarItem.ResumeLayout(false);
            this.VarItem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Image)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Krypton.Toolkit.KryptonPanel VarItem;
        private Krypton.Toolkit.KryptonPanel Image;
        private Krypton.Toolkit.KryptonLabel Id;
        private Krypton.Toolkit.KryptonLabel ConsoleName;
    }
}
