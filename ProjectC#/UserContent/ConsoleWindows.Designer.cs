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
            this.Separator = new Krypton.Toolkit.KryptonPanel();
            this.TopPanel = new Krypton.Toolkit.KryptonPanel();
            this.ConsoleName = new Krypton.Toolkit.KryptonLabel();
            this.TimeButton = new Krypton.Toolkit.KryptonButton();
            this.ScrollButton = new Krypton.Toolkit.KryptonButton();
            this.ClearButton = new Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.Background)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Background.Panel)).BeginInit();
            this.Background.Panel.SuspendLayout();
            this.Background.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Separator)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TopPanel)).BeginInit();
            this.TopPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // Background
            // 
            this.Background.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Background.Location = new System.Drawing.Point(3, 0);
            this.Background.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            // 
            // Background.Panel
            // 
            this.Background.Panel.Controls.Add(this.LogPanel);
            this.Background.Panel.Controls.Add(this.Separator);
            this.Background.Panel.Controls.Add(this.TopPanel);
            this.Background.Size = new System.Drawing.Size(368, 171);
            this.Background.StateCommon.Back.Color1 = System.Drawing.Color.DarkGray;
            this.Background.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.Background.TabIndex = 0;
            // 
            // LogPanel
            // 
            this.LogPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LogPanel.Location = new System.Drawing.Point(0, 26);
            this.LogPanel.Margin = new System.Windows.Forms.Padding(0);
            this.LogPanel.Name = "LogPanel";
            this.LogPanel.ReadOnly = true;
            this.LogPanel.Size = new System.Drawing.Size(366, 143);
            this.LogPanel.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(39)))), ((int)(((byte)(46)))));
            this.LogPanel.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(39)))), ((int)(((byte)(46)))));
            this.LogPanel.StateCommon.Border.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Solid;
            this.LogPanel.TabIndex = 0;
            this.LogPanel.Text = "";
            // 
            // Separator
            // 
            this.Separator.Dock = System.Windows.Forms.DockStyle.Top;
            this.Separator.Location = new System.Drawing.Point(0, 25);
            this.Separator.Margin = new System.Windows.Forms.Padding(0);
            this.Separator.Name = "Separator";
            this.Separator.Size = new System.Drawing.Size(366, 1);
            this.Separator.StateCommon.Color1 = System.Drawing.Color.DarkGray;
            this.Separator.TabIndex = 2;
            // 
            // TopPanel
            // 
            this.TopPanel.Controls.Add(this.ConsoleName);
            this.TopPanel.Controls.Add(this.TimeButton);
            this.TopPanel.Controls.Add(this.ScrollButton);
            this.TopPanel.Controls.Add(this.ClearButton);
            this.TopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopPanel.Location = new System.Drawing.Point(0, 0);
            this.TopPanel.Margin = new System.Windows.Forms.Padding(0);
            this.TopPanel.Name = "TopPanel";
            this.TopPanel.Size = new System.Drawing.Size(366, 25);
            this.TopPanel.StateCommon.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.TopPanel.StateCommon.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Solid;
            this.TopPanel.TabIndex = 1;
            // 
            // ConsoleName
            // 
            this.ConsoleName.Location = new System.Drawing.Point(3, 2);
            this.ConsoleName.Margin = new System.Windows.Forms.Padding(2);
            this.ConsoleName.Name = "ConsoleName";
            this.ConsoleName.Size = new System.Drawing.Size(97, 19);
            this.ConsoleName.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConsoleName.TabIndex = 2;
            this.ConsoleName.Values.Text = "kryptonLabel1";
            // 
            // TimeButton
            // 
            this.TimeButton.Location = new System.Drawing.Point(317, 3);
            this.TimeButton.Margin = new System.Windows.Forms.Padding(2);
            this.TimeButton.Name = "TimeButton";
            this.TimeButton.Size = new System.Drawing.Size(19, 18);
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
            this.TimeButton.Values.Image = global::ProjectC_.Properties.Resources.StopTime;
            this.TimeButton.Values.Text = "";
            this.TimeButton.Click += new System.EventHandler(this.TimeButton_Click);
            // 
            // ScrollButton
            // 
            this.ScrollButton.Location = new System.Drawing.Point(294, 3);
            this.ScrollButton.Margin = new System.Windows.Forms.Padding(2);
            this.ScrollButton.Name = "ScrollButton";
            this.ScrollButton.Size = new System.Drawing.Size(19, 18);
            this.ScrollButton.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(39)))), ((int)(((byte)(46)))));
            this.ScrollButton.StateCommon.Back.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Solid;
            this.ScrollButton.StateCommon.Border.Color1 = System.Drawing.Color.DarkGray;
            this.ScrollButton.StateCommon.Border.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Solid;
            this.ScrollButton.StatePressed.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(78)))), ((int)(((byte)(85)))));
            this.ScrollButton.StatePressed.Back.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Solid;
            this.ScrollButton.StateTracking.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(60)))));
            this.ScrollButton.StateTracking.Back.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Solid;
            this.ScrollButton.TabIndex = 3;
            this.ScrollButton.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.ScrollButton.Values.Image = global::ProjectC_.Properties.Resources.AllowScroll;
            this.ScrollButton.Values.Text = "";
            this.ScrollButton.Click += new System.EventHandler(this.ScrollButton_Click);
            // 
            // ClearButton
            // 
            this.ClearButton.Location = new System.Drawing.Point(343, 3);
            this.ClearButton.Margin = new System.Windows.Forms.Padding(2);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(19, 18);
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
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // ConsoleWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.Controls.Add(this.Background);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ConsoleWindow";
            this.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.Size = new System.Drawing.Size(371, 171);
            this.SizeChanged += new System.EventHandler(this.ConsoleWindow_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.Background.Panel)).EndInit();
            this.Background.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Background)).EndInit();
            this.Background.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Separator)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TopPanel)).EndInit();
            this.TopPanel.ResumeLayout(false);
            this.TopPanel.PerformLayout();
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
        private Krypton.Toolkit.KryptonButton ScrollButton;
    }
}
