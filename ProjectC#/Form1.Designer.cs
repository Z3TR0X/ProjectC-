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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.TopBar = new System.Windows.Forms.Panel();
            this.logo = new System.Windows.Forms.PictureBox();
            this.button_minimize = new System.Windows.Forms.Button();
            this.button_maximize = new System.Windows.Forms.Button();
            this.button_close = new System.Windows.Forms.Button();
            this.TopSeparator = new System.Windows.Forms.Panel();
            this.LeftSeparator = new System.Windows.Forms.Panel();
            this.LeftBar = new System.Windows.Forms.Panel();
            this.LeftPanel = new System.Windows.Forms.Panel();
            this.MenuPanel = new System.Windows.Forms.Panel();
            this.PagePanel = new System.Windows.Forms.Panel();
            this.VarPanel = new System.Windows.Forms.Panel();
            this.MenuSeparator = new System.Windows.Forms.Panel();
            this.MenuSeparatorBar = new System.Windows.Forms.Panel();
            this.ComSeparator = new System.Windows.Forms.Panel();
            this.ComPanel = new System.Windows.Forms.Panel();
            this.ButtonConnect = new System.Windows.Forms.Button();
            this.SerialLabel = new System.Windows.Forms.TextBox();
            this.SerialSelectorMargin = new System.Windows.Forms.Panel();
            this.SerialSelector = new System.Windows.Forms.Panel();
            this.SerialText = new System.Windows.Forms.Label();
            this.SerialExpand = new System.Windows.Forms.Button();
            this.BaudLabel = new System.Windows.Forms.TextBox();
            this.BaudSelectorMargin = new System.Windows.Forms.Panel();
            this.BaudSelector = new System.Windows.Forms.Panel();
            this.BaudText = new System.Windows.Forms.Label();
            this.BaudExpand = new System.Windows.Forms.Button();
            this.MainPage = new System.Windows.Forms.Panel();
            this.SerialConn = new System.IO.Ports.SerialPort(this.components);
            this.MenuSerialPort = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MenuSpeed = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TopBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).BeginInit();
            this.LeftSeparator.SuspendLayout();
            this.LeftPanel.SuspendLayout();
            this.MenuPanel.SuspendLayout();
            this.MenuSeparator.SuspendLayout();
            this.ComPanel.SuspendLayout();
            this.SerialSelectorMargin.SuspendLayout();
            this.SerialSelector.SuspendLayout();
            this.BaudSelectorMargin.SuspendLayout();
            this.BaudSelector.SuspendLayout();
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
            this.TopBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
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
            this.LeftSeparator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(39)))), ((int)(((byte)(46)))));
            this.LeftSeparator.Controls.Add(this.LeftBar);
            this.LeftSeparator.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.LeftSeparator.Dock = System.Windows.Forms.DockStyle.Left;
            this.LeftSeparator.Location = new System.Drawing.Point(201, 36);
            this.LeftSeparator.Name = "LeftSeparator";
            this.LeftSeparator.Size = new System.Drawing.Size(3, 815);
            this.LeftSeparator.TabIndex = 3;
            this.LeftSeparator.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LeftSeparator_MouseDown);
            this.LeftSeparator.MouseMove += new System.Windows.Forms.MouseEventHandler(this.LeftSeparator_MouseMove);
            this.LeftSeparator.MouseUp += new System.Windows.Forms.MouseEventHandler(this.LeftSeparator_MouseUp);
            // 
            // LeftBar
            // 
            this.LeftBar.BackColor = System.Drawing.Color.DarkGray;
            this.LeftBar.Location = new System.Drawing.Point(0, 0);
            this.LeftBar.Name = "LeftBar";
            this.LeftBar.Size = new System.Drawing.Size(1, 815);
            this.LeftBar.TabIndex = 0;
            // 
            // LeftPanel
            // 
            this.LeftPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(33)))), ((int)(((byte)(40)))));
            this.LeftPanel.Controls.Add(this.MenuPanel);
            this.LeftPanel.Controls.Add(this.ComSeparator);
            this.LeftPanel.Controls.Add(this.ComPanel);
            this.LeftPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.LeftPanel.Location = new System.Drawing.Point(1, 36);
            this.LeftPanel.Name = "LeftPanel";
            this.LeftPanel.Size = new System.Drawing.Size(200, 815);
            this.LeftPanel.TabIndex = 4;
            // 
            // MenuPanel
            // 
            this.MenuPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.MenuPanel.Controls.Add(this.PagePanel);
            this.MenuPanel.Controls.Add(this.VarPanel);
            this.MenuPanel.Controls.Add(this.MenuSeparator);
            this.MenuPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.MenuPanel.Location = new System.Drawing.Point(0, 201);
            this.MenuPanel.Name = "MenuPanel";
            this.MenuPanel.Size = new System.Drawing.Size(200, 615);
            this.MenuPanel.TabIndex = 1;
            // 
            // PagePanel
            // 
            this.PagePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.PagePanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PagePanel.Location = new System.Drawing.Point(0, 276);
            this.PagePanel.Name = "PagePanel";
            this.PagePanel.Size = new System.Drawing.Size(200, 339);
            this.PagePanel.TabIndex = 2;
            // 
            // VarPanel
            // 
            this.VarPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.VarPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.VarPanel.Location = new System.Drawing.Point(0, 0);
            this.VarPanel.Name = "VarPanel";
            this.VarPanel.Size = new System.Drawing.Size(200, 271);
            this.VarPanel.TabIndex = 1;
            // 
            // MenuSeparator
            // 
            this.MenuSeparator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.MenuSeparator.Controls.Add(this.MenuSeparatorBar);
            this.MenuSeparator.Cursor = System.Windows.Forms.Cursors.SizeNS;
            this.MenuSeparator.Location = new System.Drawing.Point(0, 271);
            this.MenuSeparator.Name = "MenuSeparator";
            this.MenuSeparator.Size = new System.Drawing.Size(250, 5);
            this.MenuSeparator.TabIndex = 0;
            this.MenuSeparator.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MenuSeparator_MouseDown);
            this.MenuSeparator.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MenuSeparator_MouseMove);
            this.MenuSeparator.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MenuSeparator_MouseUp);
            // 
            // MenuSeparatorBar
            // 
            this.MenuSeparatorBar.BackColor = System.Drawing.Color.DarkGray;
            this.MenuSeparatorBar.Location = new System.Drawing.Point(0, 2);
            this.MenuSeparatorBar.Name = "MenuSeparatorBar";
            this.MenuSeparatorBar.Size = new System.Drawing.Size(250, 1);
            this.MenuSeparatorBar.TabIndex = 0;
            // 
            // ComSeparator
            // 
            this.ComSeparator.BackColor = System.Drawing.Color.DarkGray;
            this.ComSeparator.Dock = System.Windows.Forms.DockStyle.Top;
            this.ComSeparator.Location = new System.Drawing.Point(0, 200);
            this.ComSeparator.Name = "ComSeparator";
            this.ComSeparator.Size = new System.Drawing.Size(200, 1);
            this.ComSeparator.TabIndex = 0;
            // 
            // ComPanel
            // 
            this.ComPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.ComPanel.Controls.Add(this.ButtonConnect);
            this.ComPanel.Controls.Add(this.SerialLabel);
            this.ComPanel.Controls.Add(this.SerialSelectorMargin);
            this.ComPanel.Controls.Add(this.BaudLabel);
            this.ComPanel.Controls.Add(this.BaudSelectorMargin);
            this.ComPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.ComPanel.Location = new System.Drawing.Point(0, 0);
            this.ComPanel.Name = "ComPanel";
            this.ComPanel.Size = new System.Drawing.Size(200, 200);
            this.ComPanel.TabIndex = 0;
            // 
            // ButtonConnect
            // 
            this.ButtonConnect.BackColor = System.Drawing.Color.DarkGreen;
            this.ButtonConnect.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.ButtonConnect.FlatAppearance.BorderSize = 0;
            this.ButtonConnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonConnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonConnect.ForeColor = System.Drawing.Color.DarkGray;
            this.ButtonConnect.Location = new System.Drawing.Point(25, 158);
            this.ButtonConnect.Margin = new System.Windows.Forms.Padding(0);
            this.ButtonConnect.Name = "ButtonConnect";
            this.ButtonConnect.Size = new System.Drawing.Size(150, 23);
            this.ButtonConnect.TabIndex = 5;
            this.ButtonConnect.Text = "Connexion";
            this.ButtonConnect.UseVisualStyleBackColor = false;
            this.ButtonConnect.Click += new System.EventHandler(this.ButtonConnect_Click);
            // 
            // SerialLabel
            // 
            this.SerialLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.SerialLabel.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SerialLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SerialLabel.ForeColor = System.Drawing.Color.DarkGray;
            this.SerialLabel.Location = new System.Drawing.Point(10, 5);
            this.SerialLabel.Name = "SerialLabel";
            this.SerialLabel.Size = new System.Drawing.Size(112, 28);
            this.SerialLabel.TabIndex = 2;
            this.SerialLabel.Text = "Port série :";
            // 
            // SerialSelectorMargin
            // 
            this.SerialSelectorMargin.BackColor = System.Drawing.Color.DarkGray;
            this.SerialSelectorMargin.Controls.Add(this.SerialSelector);
            this.SerialSelectorMargin.Location = new System.Drawing.Point(35, 30);
            this.SerialSelectorMargin.Margin = new System.Windows.Forms.Padding(0);
            this.SerialSelectorMargin.Name = "SerialSelectorMargin";
            this.SerialSelectorMargin.Padding = new System.Windows.Forms.Padding(1);
            this.SerialSelectorMargin.Size = new System.Drawing.Size(130, 28);
            this.SerialSelectorMargin.TabIndex = 1;
            // 
            // SerialSelector
            // 
            this.SerialSelector.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(39)))), ((int)(((byte)(46)))));
            this.SerialSelector.Controls.Add(this.SerialText);
            this.SerialSelector.Controls.Add(this.SerialExpand);
            this.SerialSelector.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SerialSelector.Location = new System.Drawing.Point(1, 1);
            this.SerialSelector.Margin = new System.Windows.Forms.Padding(0);
            this.SerialSelector.Name = "SerialSelector";
            this.SerialSelector.Size = new System.Drawing.Size(128, 26);
            this.SerialSelector.TabIndex = 0;
            // 
            // SerialText
            // 
            this.SerialText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SerialText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.SerialText.ForeColor = System.Drawing.Color.DarkGray;
            this.SerialText.Location = new System.Drawing.Point(0, 0);
            this.SerialText.Name = "SerialText";
            this.SerialText.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.SerialText.Size = new System.Drawing.Size(102, 26);
            this.SerialText.TabIndex = 0;
            this.SerialText.Text = "COM1";
            this.SerialText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SerialExpand
            // 
            this.SerialExpand.Dock = System.Windows.Forms.DockStyle.Right;
            this.SerialExpand.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.SerialExpand.FlatAppearance.BorderSize = 0;
            this.SerialExpand.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SerialExpand.Image = global::ProjectC_.Properties.Resources.ExpandArrow;
            this.SerialExpand.Location = new System.Drawing.Point(102, 0);
            this.SerialExpand.Margin = new System.Windows.Forms.Padding(0);
            this.SerialExpand.Name = "SerialExpand";
            this.SerialExpand.Size = new System.Drawing.Size(26, 26);
            this.SerialExpand.TabIndex = 1;
            this.SerialExpand.UseVisualStyleBackColor = true;
            this.SerialExpand.Click += new System.EventHandler(this.SerialExpand_Click);
            // 
            // BaudLabel
            // 
            this.BaudLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.BaudLabel.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.BaudLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BaudLabel.ForeColor = System.Drawing.Color.DarkGray;
            this.BaudLabel.Location = new System.Drawing.Point(10, 70);
            this.BaudLabel.Name = "BaudLabel";
            this.BaudLabel.Size = new System.Drawing.Size(150, 28);
            this.BaudLabel.TabIndex = 3;
            this.BaudLabel.Text = "Vitesse (baud/s)";
            // 
            // BaudSelectorMargin
            // 
            this.BaudSelectorMargin.BackColor = System.Drawing.Color.DarkGray;
            this.BaudSelectorMargin.Controls.Add(this.BaudSelector);
            this.BaudSelectorMargin.Location = new System.Drawing.Point(35, 95);
            this.BaudSelectorMargin.Margin = new System.Windows.Forms.Padding(0);
            this.BaudSelectorMargin.Name = "BaudSelectorMargin";
            this.BaudSelectorMargin.Padding = new System.Windows.Forms.Padding(1);
            this.BaudSelectorMargin.Size = new System.Drawing.Size(130, 28);
            this.BaudSelectorMargin.TabIndex = 4;
            // 
            // BaudSelector
            // 
            this.BaudSelector.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(39)))), ((int)(((byte)(46)))));
            this.BaudSelector.Controls.Add(this.BaudText);
            this.BaudSelector.Controls.Add(this.BaudExpand);
            this.BaudSelector.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BaudSelector.Location = new System.Drawing.Point(1, 1);
            this.BaudSelector.Margin = new System.Windows.Forms.Padding(0);
            this.BaudSelector.Name = "BaudSelector";
            this.BaudSelector.Size = new System.Drawing.Size(128, 26);
            this.BaudSelector.TabIndex = 0;
            // 
            // BaudText
            // 
            this.BaudText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BaudText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.BaudText.ForeColor = System.Drawing.Color.DarkGray;
            this.BaudText.Location = new System.Drawing.Point(0, 0);
            this.BaudText.Name = "BaudText";
            this.BaudText.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.BaudText.Size = new System.Drawing.Size(102, 26);
            this.BaudText.TabIndex = 0;
            this.BaudText.Text = "115200";
            this.BaudText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BaudExpand
            // 
            this.BaudExpand.Dock = System.Windows.Forms.DockStyle.Right;
            this.BaudExpand.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.BaudExpand.FlatAppearance.BorderSize = 0;
            this.BaudExpand.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BaudExpand.Image = global::ProjectC_.Properties.Resources.ExpandArrow;
            this.BaudExpand.Location = new System.Drawing.Point(102, 0);
            this.BaudExpand.Margin = new System.Windows.Forms.Padding(0);
            this.BaudExpand.Name = "BaudExpand";
            this.BaudExpand.Size = new System.Drawing.Size(26, 26);
            this.BaudExpand.TabIndex = 1;
            this.BaudExpand.UseVisualStyleBackColor = true;
            this.BaudExpand.Click += new System.EventHandler(this.BaudExpand_Click);
            // 
            // MainPage
            // 
            this.MainPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(39)))), ((int)(((byte)(46)))));
            this.MainPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.MainPage.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.MainPage.Location = new System.Drawing.Point(204, 36);
            this.MainPage.Name = "MainPage";
            this.MainPage.Padding = new System.Windows.Forms.Padding(0, 1, 0, 1);
            this.MainPage.Size = new System.Drawing.Size(1194, 815);
            this.MainPage.TabIndex = 5;
            // 
            // MenuSerialPort
            // 
            this.MenuSerialPort.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(39)))), ((int)(((byte)(46)))));
            this.MenuSerialPort.ImageScalingSize = new System.Drawing.Size(0, 0);
            this.MenuSerialPort.Name = "MenuSerialPort";
            this.MenuSerialPort.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.MenuSerialPort.ShowImageMargin = false;
            this.MenuSerialPort.Size = new System.Drawing.Size(36, 4);
            this.MenuSerialPort.Text = "couou";
            // 
            // MenuSpeed
            // 
            this.MenuSpeed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(39)))), ((int)(((byte)(46)))));
            this.MenuSpeed.ImageScalingSize = new System.Drawing.Size(0, 0);
            this.MenuSpeed.Name = "MenuSpeed";
            this.MenuSpeed.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.MenuSpeed.ShowImageMargin = false;
            this.MenuSpeed.Size = new System.Drawing.Size(36, 4);
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
            this.Resize += new System.EventHandler(this.Form1_SizeChanged);
            this.TopBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.logo)).EndInit();
            this.LeftSeparator.ResumeLayout(false);
            this.LeftPanel.ResumeLayout(false);
            this.MenuPanel.ResumeLayout(false);
            this.MenuSeparator.ResumeLayout(false);
            this.ComPanel.ResumeLayout(false);
            this.ComPanel.PerformLayout();
            this.SerialSelectorMargin.ResumeLayout(false);
            this.SerialSelector.ResumeLayout(false);
            this.BaudSelectorMargin.ResumeLayout(false);
            this.BaudSelector.ResumeLayout(false);
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
        private System.Windows.Forms.Panel MainPage;
        private System.Windows.Forms.Panel LeftBar;
        private System.Windows.Forms.Panel ComPanel;
        private System.Windows.Forms.Panel MenuPanel;
        private System.Windows.Forms.Panel ComSeparator;
        private System.Windows.Forms.Panel MenuSeparator;
        private System.Windows.Forms.Panel MenuSeparatorBar;
        private System.Windows.Forms.Panel PagePanel;
        private System.Windows.Forms.Panel VarPanel;
        private System.Windows.Forms.TextBox SerialLabel;
        private System.Windows.Forms.Panel SerialSelectorMargin;
        private System.Windows.Forms.Panel SerialSelector;
        private System.Windows.Forms.Label SerialText;
        private System.Windows.Forms.Button SerialExpand;
        private System.Windows.Forms.TextBox BaudLabel;
        private System.Windows.Forms.Panel BaudSelectorMargin;
        private System.Windows.Forms.Panel BaudSelector;
        private System.Windows.Forms.Label BaudText;
        private System.Windows.Forms.Button BaudExpand;
        private System.Windows.Forms.Button ButtonConnect;
        private System.IO.Ports.SerialPort SerialConn;
        private System.Windows.Forms.ContextMenuStrip MenuSerialPort;
        private System.Windows.Forms.ContextMenuStrip MenuSpeed;
    }
}

