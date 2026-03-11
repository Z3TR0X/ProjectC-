namespace ProjectC_.VarPanel {
    partial class ColorPicker {
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
            this.MainPanel = new Krypton.Toolkit.KryptonPanel();
            this.WheelColorPicker = new Cyotek.Windows.Forms.ColorWheel();
            this.ManualColorPicker = new Cyotek.Windows.Forms.ColorEditor();
            this.LastColorPanel = new Krypton.Toolkit.KryptonPanel();
            this.NewColorPanel = new Krypton.Toolkit.KryptonPanel();
            this.NewColorLabel = new Krypton.Toolkit.KryptonLabel();
            this.LastColorLabel = new Krypton.Toolkit.KryptonLabel();
            ((System.ComponentModel.ISupportInitialize)(this.MainPanel)).BeginInit();
            this.MainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LastColorPanel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NewColorPanel)).BeginInit();
            this.SuspendLayout();
            // 
            // MainPanel
            // 
            this.MainPanel.Controls.Add(this.LastColorLabel);
            this.MainPanel.Controls.Add(this.NewColorLabel);
            this.MainPanel.Controls.Add(this.NewColorPanel);
            this.MainPanel.Controls.Add(this.LastColorPanel);
            this.MainPanel.Controls.Add(this.ManualColorPicker);
            this.MainPanel.Controls.Add(this.WheelColorPicker);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(3, 3);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Padding = new System.Windows.Forms.Padding(3);
            this.MainPanel.Size = new System.Drawing.Size(309, 371);
            this.MainPanel.StateCommon.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.MainPanel.StateCommon.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Solid;
            this.MainPanel.TabIndex = 0;
            // 
            // WheelColorPicker
            // 
            this.WheelColorPicker.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.WheelColorPicker.Location = new System.Drawing.Point(6, 6);
            this.WheelColorPicker.Name = "WheelColorPicker";
            this.WheelColorPicker.Size = new System.Drawing.Size(146, 152);
            this.WheelColorPicker.TabIndex = 0;
            this.WheelColorPicker.ColorChanged += new System.EventHandler(this.WheelColorPicker_ColorChanged);
            // 
            // ManualColorPicker
            // 
            this.ManualColorPicker.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.ManualColorPicker.Color = System.Drawing.Color.DarkGray;
            this.ManualColorPicker.ForeColor = System.Drawing.Color.DarkGray;
            this.ManualColorPicker.Location = new System.Drawing.Point(6, 161);
            this.ManualColorPicker.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ManualColorPicker.Name = "ManualColorPicker";
            this.ManualColorPicker.ShowAlphaChannel = false;
            this.ManualColorPicker.Size = new System.Drawing.Size(296, 202);
            this.ManualColorPicker.TabIndex = 1;
            this.ManualColorPicker.ColorChanged += new System.EventHandler(this.ManualColorPicker_ColorChanged);
            // 
            // LastColorPanel
            // 
            this.LastColorPanel.Location = new System.Drawing.Point(213, 41);
            this.LastColorPanel.Name = "LastColorPanel";
            this.LastColorPanel.Size = new System.Drawing.Size(30, 30);
            this.LastColorPanel.TabIndex = 2;
            // 
            // NewColorPanel
            // 
            this.NewColorPanel.Location = new System.Drawing.Point(211, 128);
            this.NewColorPanel.Name = "NewColorPanel";
            this.NewColorPanel.Size = new System.Drawing.Size(30, 30);
            this.NewColorPanel.TabIndex = 3;
            // 
            // NewColorLabel
            // 
            this.NewColorLabel.Location = new System.Drawing.Point(152, 93);
            this.NewColorLabel.Name = "NewColorLabel";
            this.NewColorLabel.Size = new System.Drawing.Size(154, 29);
            this.NewColorLabel.StateCommon.ShortText.Color1 = System.Drawing.Color.DarkGray;
            this.NewColorLabel.TabIndex = 4;
            this.NewColorLabel.Values.Text = "Nouvelle Couleur";
            // 
            // LastColorLabel
            // 
            this.LastColorLabel.Location = new System.Drawing.Point(149, 6);
            this.LastColorLabel.Name = "LastColorLabel";
            this.LastColorLabel.Size = new System.Drawing.Size(157, 29);
            this.LastColorLabel.StateCommon.ShortText.Color1 = System.Drawing.Color.DarkGray;
            this.LastColorLabel.StateCommon.ShortText.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Solid;
            this.LastColorLabel.TabIndex = 5;
            this.LastColorLabel.Values.Text = "Ancienne Couleur";
            // 
            // ColorPicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.Controls.Add(this.MainPanel);
            this.Name = "ColorPicker";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Size = new System.Drawing.Size(315, 377);
            ((System.ComponentModel.ISupportInitialize)(this.MainPanel)).EndInit();
            this.MainPanel.ResumeLayout(false);
            this.MainPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LastColorPanel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NewColorPanel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Krypton.Toolkit.KryptonPanel MainPanel;
        private Krypton.Toolkit.KryptonLabel LastColorLabel;
        private Krypton.Toolkit.KryptonLabel NewColorLabel;
        private Krypton.Toolkit.KryptonPanel NewColorPanel;
        private Krypton.Toolkit.KryptonPanel LastColorPanel;
        private Cyotek.Windows.Forms.ColorEditor ManualColorPicker;
        private Cyotek.Windows.Forms.ColorWheel WheelColorPicker;
    }
}
