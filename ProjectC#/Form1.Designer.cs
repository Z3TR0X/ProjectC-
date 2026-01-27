namespace ProjectC_
{
    partial class Form1
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

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.TopBar = new System.Windows.Forms.Panel();
            this.TopSeparator = new System.Windows.Forms.Panel();
            this.LeftSeparator = new System.Windows.Forms.Panel();
            this.LeftPanel = new System.Windows.Forms.Panel();
            this.PageSeparator = new System.Windows.Forms.Panel();
            this.logo = new System.Windows.Forms.PictureBox();
            this.button_minimize = new System.Windows.Forms.Button();
            this.button_maximize = new System.Windows.Forms.Button();
            this.button_close = new System.Windows.Forms.Button();
            this.MainPage = new System.Windows.Forms.Panel();
            this.TopBar.SuspendLayout();
            this.LeftPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).BeginInit();
            this.SuspendLayout();
            // 
            // TopBar
            // 
            this.TopBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(39)))), ((int)(((byte)(46)))));
            this.TopBar.Controls.Add(this.logo);
            this.TopBar.Controls.Add(this.button_minimize);
            this.TopBar.Controls.Add(this.button_maximize);
            this.TopBar.Controls.Add(this.button_close);
            this.TopBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopBar.Location = new System.Drawing.Point(1, 1);
            this.TopBar.Name = "TopBar";
            this.TopBar.Size = new System.Drawing.Size(1397, 34);
            this.TopBar.TabIndex = 0;
            this.TopBar.Click += new System.EventHandler(this.panel1_Click);
            this.TopBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            // 
            // TopSeparator
            // 
            this.TopSeparator.BackColor = System.Drawing.Color.DarkGray;
            this.TopSeparator.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopSeparator.Location = new System.Drawing.Point(1, 35);
            this.TopSeparator.Name = "TopSeparator";
            this.TopSeparator.Size = new System.Drawing.Size(1397, 1);
            this.TopSeparator.TabIndex = 2;
            // 
            // LeftSeparator
            // 
            this.LeftSeparator.BackColor = System.Drawing.Color.DarkGray;
            this.LeftSeparator.Dock = System.Windows.Forms.DockStyle.Left;
            this.LeftSeparator.Location = new System.Drawing.Point(251, 36);
            this.LeftSeparator.Name = "LeftSeparator";
            this.LeftSeparator.Size = new System.Drawing.Size(1, 815);
            this.LeftSeparator.TabIndex = 3;
            // 
            // LeftPanel
            // 
            this.LeftPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(33)))), ((int)(((byte)(40)))));
            this.LeftPanel.Controls.Add(this.PageSeparator);
            this.LeftPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.LeftPanel.Location = new System.Drawing.Point(1, 36);
            this.LeftPanel.Name = "LeftPanel";
            this.LeftPanel.Size = new System.Drawing.Size(250, 815);
            this.LeftPanel.TabIndex = 4;
            // 
            // PageSeparator
            // 
            this.PageSeparator.BackColor = System.Drawing.Color.White;
            this.PageSeparator.Location = new System.Drawing.Point(0, 360);
            this.PageSeparator.Name = "PageSeparator";
            this.PageSeparator.Size = new System.Drawing.Size(253, 1);
            this.PageSeparator.TabIndex = 0;
            // 
            // logo
            // 
            this.logo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(39)))), ((int)(((byte)(46)))));
            this.logo.Image = ((System.Drawing.Image)(resources.GetObject("logo.Image")));
            this.logo.Location = new System.Drawing.Point(0, 0);
            this.logo.Name = "logo";
            this.logo.Size = new System.Drawing.Size(34, 34);
            this.logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.logo.TabIndex = 1;
            this.logo.TabStop = false;
            // 
            // button_minimize
            // 
            this.button_minimize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(39)))), ((int)(((byte)(46)))));
            this.button_minimize.Dock = System.Windows.Forms.DockStyle.Right;
            this.button_minimize.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(30)))), ((int)(((byte)(33)))));
            this.button_minimize.FlatAppearance.BorderSize = 0;
            this.button_minimize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(63)))), ((int)(((byte)(69)))));
            this.button_minimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_minimize.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(30)))), ((int)(((byte)(33)))));
            this.button_minimize.Image = global::ProjectC_.Properties.Resources.Minimize_white;
            this.button_minimize.Location = new System.Drawing.Point(1268, 0);
            this.button_minimize.Margin = new System.Windows.Forms.Padding(0);
            this.button_minimize.Name = "button_minimize";
            this.button_minimize.Size = new System.Drawing.Size(43, 34);
            this.button_minimize.TabIndex = 3;
            this.button_minimize.UseVisualStyleBackColor = false;
            this.button_minimize.Click += new System.EventHandler(this.button_minimize_Click);
            // 
            // button_maximize
            // 
            this.button_maximize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(39)))), ((int)(((byte)(46)))));
            this.button_maximize.Dock = System.Windows.Forms.DockStyle.Right;
            this.button_maximize.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(30)))), ((int)(((byte)(33)))));
            this.button_maximize.FlatAppearance.BorderSize = 0;
            this.button_maximize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(63)))), ((int)(((byte)(69)))));
            this.button_maximize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_maximize.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(30)))), ((int)(((byte)(33)))));
            this.button_maximize.Image = global::ProjectC_.Properties.Resources.Maximize_White;
            this.button_maximize.Location = new System.Drawing.Point(1311, 0);
            this.button_maximize.Margin = new System.Windows.Forms.Padding(0);
            this.button_maximize.Name = "button_maximize";
            this.button_maximize.Size = new System.Drawing.Size(43, 34);
            this.button_maximize.TabIndex = 2;
            this.button_maximize.UseVisualStyleBackColor = false;
            this.button_maximize.Click += new System.EventHandler(this.button_maximize_Click);
            // 
            // button_close
            // 
            this.button_close.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(39)))), ((int)(((byte)(46)))));
            this.button_close.Dock = System.Windows.Forms.DockStyle.Right;
            this.button_close.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(30)))), ((int)(((byte)(33)))));
            this.button_close.FlatAppearance.BorderSize = 0;
            this.button_close.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(0)))), ((int)(((byte)(40)))));
            this.button_close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_close.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(30)))), ((int)(((byte)(33)))));
            this.button_close.Image = ((System.Drawing.Image)(resources.GetObject("button_close.Image")));
            this.button_close.Location = new System.Drawing.Point(1354, 0);
            this.button_close.Margin = new System.Windows.Forms.Padding(0);
            this.button_close.Name = "button_close";
            this.button_close.Size = new System.Drawing.Size(43, 34);
            this.button_close.TabIndex = 1;
            this.button_close.UseVisualStyleBackColor = false;
            this.button_close.Click += new System.EventHandler(this.button_close_Click);
            // 
            // MainPage
            // 
            this.MainPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(39)))), ((int)(((byte)(46)))));
            this.MainPage.Dock = System.Windows.Forms.DockStyle.Top;
            this.MainPage.Location = new System.Drawing.Point(252, 36);
            this.MainPage.Name = "MainPage";
            this.MainPage.Size = new System.Drawing.Size(1146, 815);
            this.MainPage.TabIndex = 5;
            // 
            // Form1
            // 
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(1399, 852);
            this.Controls.Add(this.MainPage);
            this.Controls.Add(this.LeftSeparator);
            this.Controls.Add(this.LeftPanel);
            this.Controls.Add(this.TopSeparator);
            this.Controls.Add(this.TopBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_SizeChanged);
            this.TopBar.ResumeLayout(false);
            this.LeftPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.logo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel TopBar;
        private System.Windows.Forms.Button button_close;
        private System.Windows.Forms.Button button_minimize;
        private System.Windows.Forms.Button button_maximize;
        private System.Windows.Forms.PictureBox logo;
        private System.Windows.Forms.Panel TopSeparator;
        private System.Windows.Forms.Panel LeftSeparator;
        private System.Windows.Forms.Panel LeftPanel;
        private System.Windows.Forms.Panel PageSeparator;
        private System.Windows.Forms.Panel MainPage;
    }
}

