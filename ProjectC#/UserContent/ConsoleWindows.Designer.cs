namespace ProjectC_.UserContent {
    partial class ConsoleWindow {
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
            this.LogPanel = new Krypton.Toolkit.KryptonRichTextBox();
            this.TopPanel = new Krypton.Toolkit.KryptonPanel();
            this.ClearButton = new Krypton.Toolkit.KryptonButton();
            this.TimeButton = new Krypton.Toolkit.KryptonButton();
            this.Separator = new Krypton.Toolkit.KryptonPanel();
            this.ConsoleName = new Krypton.Toolkit.KryptonLabel();
            ((System.ComponentModel.ISupportInitialize)(this.Background)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Background.Panel)).BeginInit();
            this.Background.Panel.SuspendLayout();
            this.Background.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TopPanel)).BeginInit();
            this.TopPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Separator)).BeginInit();
            this.SuspendLayout();
            // 
            // Background
            // 
            this.Background.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Background.Location = new System.Drawing.Point(5, 0);
            this.Background.Margin = new System.Windows.Forms.Padding(5, 0, 0, 0);
            // 
            // Background.Panel
            // 
            this.Background.Panel.Controls.Add(this.Separator);
            this.Background.Panel.Controls.Add(this.TopPanel);
            this.Background.Panel.Controls.Add(this.LogPanel);
            this.Background.Size = new System.Drawing.Size(552, 263);
            this.Background.StateCommon.Back.Color1 = System.Drawing.Color.DarkGray;
            this.Background.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.Background.TabIndex = 0;
            // 
            // LogPanel
            // 
            this.LogPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LogPanel.Location = new System.Drawing.Point(0, 0);
            this.LogPanel.Margin = new System.Windows.Forms.Padding(0);
            this.LogPanel.Name = "LogPanel";
            this.LogPanel.ReadOnly = true;
            this.LogPanel.Size = new System.Drawing.Size(550, 261);
            this.LogPanel.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(39)))), ((int)(((byte)(46)))));
            this.LogPanel.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(39)))), ((int)(((byte)(46)))));
            this.LogPanel.StateCommon.Border.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Solid;
            this.LogPanel.TabIndex = 0;
            this.LogPanel.Text = "kryptonRichTextBox1";
            // 
            // TopPanel
            // 
            this.TopPanel.Controls.Add(this.ConsoleName);
            this.TopPanel.Controls.Add(this.TimeButton);
            this.TopPanel.Controls.Add(this.ClearButton);
            this.TopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopPanel.Location = new System.Drawing.Point(0, 0);
            this.TopPanel.Margin = new System.Windows.Forms.Padding(0);
            this.TopPanel.Name = "TopPanel";
            this.TopPanel.Size = new System.Drawing.Size(550, 38);
            this.TopPanel.StateCommon.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.TopPanel.StateCommon.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Solid;
            this.TopPanel.TabIndex = 1;
            // 
            // ClearButton
            // 
            this.ClearButton.Location = new System.Drawing.Point(515, 5);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(28, 28);
            this.ClearButton.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(39)))), ((int)(((byte)(46)))));
            this.ClearButton.StateCommon.Back.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Solid;
            this.ClearButton.StateCommon.Border.Color1 = System.Drawing.Color.DarkGray;
            this.ClearButton.StateCommon.Border.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Solid;
            this.ClearButton.StatePressed.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(78)))), ((int)(((byte)(85)))));
            this.ClearButton.StateTracking.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(60)))));
            this.ClearButton.StateTracking.Back.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Solid;
            this.ClearButton.TabIndex = 0;
            this.ClearButton.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.ClearButton.Values.Image = global::ProjectC_.Properties.Resources.Clear_Data;
            this.ClearButton.Values.Text = "";
            // 
            // TimeButton
            // 
            this.TimeButton.Location = new System.Drawing.Point(475, 5);
            this.TimeButton.Name = "TimeButton";
            this.TimeButton.Size = new System.Drawing.Size(28, 28);
            this.TimeButton.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(39)))), ((int)(((byte)(46)))));
            this.TimeButton.StateCommon.Back.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Solid;
            this.TimeButton.StateCommon.Border.Color1 = System.Drawing.Color.DarkGray;
            this.TimeButton.StateCommon.Border.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Solid;
            this.TimeButton.StatePressed.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(78)))), ((int)(((byte)(85)))));
            this.TimeButton.StatePressed.Back.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Solid;
            this.TimeButton.StateTracking.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(60)))));
            this.TimeButton.StateTracking.Back.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Solid;
            this.TimeButton.TabIndex = 1;
            this.TimeButton.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.TimeButton.Values.Image = global::ProjectC_.Properties.Resources.AddTime;
            this.TimeButton.Values.Text = "";
            // 
            // Separator
            // 
            this.Separator.Dock = System.Windows.Forms.DockStyle.Top;
            this.Separator.Location = new System.Drawing.Point(0, 38);
            this.Separator.Margin = new System.Windows.Forms.Padding(0);
            this.Separator.Name = "Separator";
            this.Separator.Size = new System.Drawing.Size(550, 1);
            this.Separator.StateCommon.Color1 = System.Drawing.Color.DarkGray;
            this.Separator.TabIndex = 2;
            // 
            // ConsoleName
            // 
            this.ConsoleName.Location = new System.Drawing.Point(4, 3);
            this.ConsoleName.Name = "ConsoleName";
            this.ConsoleName.Size = new System.Drawing.Size(143, 28);
            this.ConsoleName.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConsoleName.TabIndex = 2;
            this.ConsoleName.Values.Text = "kryptonLabel1";
            // 
            // ConsoleWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.Controls.Add(this.Background);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ConsoleWindow";
            this.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.Size = new System.Drawing.Size(557, 263);
            this.SizeChanged += new System.EventHandler(this.ConsoleWindow_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.Background.Panel)).EndInit();
            this.Background.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Background)).EndInit();
            this.Background.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TopPanel)).EndInit();
            this.TopPanel.ResumeLayout(false);
            this.TopPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Separator)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Krypton.Toolkit.KryptonGroup Background;
        private Krypton.Toolkit.KryptonPanel TopPanel;
        private Krypton.Toolkit.KryptonButton ClearButton;
        private Krypton.Toolkit.KryptonRichTextBox LogPanel;
        private Krypton.Toolkit.KryptonButton TimeButton;
        private Krypton.Toolkit.KryptonPanel Separator;
        private Krypton.Toolkit.KryptonLabel ConsoleName;
    }
}
