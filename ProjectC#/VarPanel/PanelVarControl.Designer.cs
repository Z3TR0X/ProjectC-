namespace ProjectC_ {
    partial class PanelVarControl {
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
            this.VarValue = new Krypton.Toolkit.KryptonLabel();
            this.VarSeparator = new Krypton.Toolkit.KryptonPanel();
            this.VarName = new Krypton.Toolkit.KryptonLabel();
            this.VarColor = new Krypton.Toolkit.KryptonPanel();
            ((System.ComponentModel.ISupportInitialize)(this.VarItem)).BeginInit();
            this.VarItem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VarSeparator)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VarColor)).BeginInit();
            this.SuspendLayout();
            // 
            // VarItem
            // 
            this.VarItem.Controls.Add(this.VarValue);
            this.VarItem.Controls.Add(this.VarSeparator);
            this.VarItem.Controls.Add(this.VarName);
            this.VarItem.Controls.Add(this.VarColor);
            this.VarItem.Dock = System.Windows.Forms.DockStyle.Top;
            this.VarItem.Location = new System.Drawing.Point(0, 0);
            this.VarItem.Name = "VarItem";
            this.VarItem.Size = new System.Drawing.Size(265, 45);
            this.VarItem.StateCommon.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(39)))), ((int)(((byte)(46)))));
            this.VarItem.StateCommon.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Solid;
            this.VarItem.TabIndex = 2;
            this.VarItem.MouseEnter += new System.EventHandler(this.VarItem_MouseEnter);
            this.VarItem.MouseLeave += new System.EventHandler(this.VarItem_MouseLeave);
            // 
            // VarValue
            // 
            this.VarValue.Enabled = false;
            this.VarValue.Location = new System.Drawing.Point(180, 3);
            this.VarValue.Margin = new System.Windows.Forms.Padding(0);
            this.VarValue.MaximumSize = new System.Drawing.Size(80, 0);
            this.VarValue.Name = "VarValue";
            this.VarValue.Size = new System.Drawing.Size(80, 32);
            this.VarValue.StateCommon.Padding = new System.Windows.Forms.Padding(-1, 3, -1, -1);
            this.VarValue.StateCommon.ShortText.Color1 = System.Drawing.Color.DarkGray;
            this.VarValue.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VarValue.TabIndex = 3;
            this.VarValue.Values.Text = "-280.142";
            // 
            // VarSeparator
            // 
            this.VarSeparator.Enabled = false;
            this.VarSeparator.Location = new System.Drawing.Point(176, 5);
            this.VarSeparator.Name = "VarSeparator";
            this.VarSeparator.Size = new System.Drawing.Size(1, 30);
            this.VarSeparator.TabIndex = 2;
            // 
            // VarName
            // 
            this.VarName.Enabled = false;
            this.VarName.Location = new System.Drawing.Point(30, 3);
            this.VarName.Margin = new System.Windows.Forms.Padding(0);
            this.VarName.MaximumSize = new System.Drawing.Size(135, 0);
            this.VarName.Name = "VarName";
            this.VarName.Size = new System.Drawing.Size(135, 32);
            this.VarName.StateCommon.Padding = new System.Windows.Forms.Padding(-1, 3, -1, 1);
            this.VarName.StateCommon.ShortText.Color1 = System.Drawing.Color.DarkGray;
            this.VarName.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VarName.TabIndex = 1;
            this.VarName.Values.Text = "kryptonLabel1sqdddddddddddddddddddd";
            // 
            // VarColor
            // 
            this.VarColor.Enabled = false;
            this.VarColor.Location = new System.Drawing.Point(10, 10);
            this.VarColor.Margin = new System.Windows.Forms.Padding(30, 7, 3, 8);
            this.VarColor.Name = "VarColor";
            this.VarColor.Size = new System.Drawing.Size(20, 20);
            this.VarColor.TabIndex = 0;
            // 
            // PanelVarControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.VarItem);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "PanelVarControl";
            this.Size = new System.Drawing.Size(265, 45);
            ((System.ComponentModel.ISupportInitialize)(this.VarItem)).EndInit();
            this.VarItem.ResumeLayout(false);
            this.VarItem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VarSeparator)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VarColor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Krypton.Toolkit.KryptonPanel VarItem;
        private Krypton.Toolkit.KryptonLabel VarValue;
        private Krypton.Toolkit.KryptonPanel VarSeparator;
        private Krypton.Toolkit.KryptonLabel VarName;
        private Krypton.Toolkit.KryptonPanel VarColor;
    }
}
