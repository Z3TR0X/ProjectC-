namespace ProjectC_ {
    partial class TriggerWindow {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TriggerWindow));
            this.ValueCheck = new System.Windows.Forms.CheckBox();
            this.TimeCheck = new System.Windows.Forms.CheckBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.ValVal = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.TimeVal = new System.Windows.Forms.NumericUpDown();
            this.DataNameCB = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.OkButton = new Krypton.Toolkit.KryptonButton();
            this.CancelButton = new Krypton.Toolkit.KryptonButton();
            this.ValueLabel = new System.Windows.Forms.Label();
            this.TimeLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ValVal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TimeVal)).BeginInit();
            this.SuspendLayout();
            // 
            // ValueCheck
            // 
            this.ValueCheck.AutoSize = true;
            this.ValueCheck.Location = new System.Drawing.Point(176, 18);
            this.ValueCheck.Name = "ValueCheck";
            this.ValueCheck.Size = new System.Drawing.Size(15, 14);
            this.ValueCheck.TabIndex = 2;
            this.ValueCheck.UseVisualStyleBackColor = true;
            this.ValueCheck.CheckedChanged += new System.EventHandler(this.ValueCheck_CheckedChanged);
            // 
            // TimeCheck
            // 
            this.TimeCheck.AutoSize = true;
            this.TimeCheck.Checked = true;
            this.TimeCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.TimeCheck.Location = new System.Drawing.Point(176, 112);
            this.TimeCheck.Name = "TimeCheck";
            this.TimeCheck.Size = new System.Drawing.Size(15, 14);
            this.TimeCheck.TabIndex = 3;
            this.TimeCheck.UseVisualStyleBackColor = true;
            this.TimeCheck.CheckedChanged += new System.EventHandler(this.TimeCheck_CheckedChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            ">",
            "<",
            ">=",
            "<=",
            "="});
            this.comboBox1.Location = new System.Drawing.Point(197, 43);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(47, 21);
            this.comboBox1.TabIndex = 4;
            // 
            // ValVal
            // 
            this.ValVal.DecimalPlaces = 3;
            this.ValVal.Location = new System.Drawing.Point(250, 44);
            this.ValVal.Name = "ValVal";
            this.ValVal.Size = new System.Drawing.Size(82, 20);
            this.ValVal.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(34, 140);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "Timer (en s) :";
            // 
            // TimeVal
            // 
            this.TimeVal.DecimalPlaces = 1;
            this.TimeVal.Location = new System.Drawing.Point(136, 140);
            this.TimeVal.Name = "TimeVal";
            this.TimeVal.Size = new System.Drawing.Size(76, 20);
            this.TimeVal.TabIndex = 7;
            // 
            // DataNameCB
            // 
            this.DataNameCB.FormattingEnabled = true;
            this.DataNameCB.Location = new System.Drawing.Point(62, 44);
            this.DataNameCB.Name = "DataNameCB";
            this.DataNameCB.Size = new System.Drawing.Size(90, 21);
            this.DataNameCB.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(34, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 16);
            this.label2.TabIndex = 9;
            this.label2.Text = "Si ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(163, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 16);
            this.label3.TabIndex = 10;
            this.label3.Text = "est ";
            // 
            // OkButton
            // 
            this.OkButton.Location = new System.Drawing.Point(228, 199);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(61, 25);
            this.OkButton.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.OkButton.StateCommon.Back.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Solid;
            this.OkButton.StateCommon.Border.Color1 = System.Drawing.Color.DarkGray;
            this.OkButton.StateCommon.Border.Rounding = 5F;
            this.OkButton.StatePressed.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(78)))), ((int)(((byte)(85)))));
            this.OkButton.StatePressed.Back.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Solid;
            this.OkButton.StatePressed.Back.ImageStyle = Krypton.Toolkit.PaletteImageStyle.Stretch;
            this.OkButton.StatePressed.Border.Color1 = System.Drawing.Color.DarkGray;
            this.OkButton.StatePressed.Border.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Solid;
            this.OkButton.StateTracking.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(60)))));
            this.OkButton.StateTracking.Content.ShortText.Color1 = System.Drawing.Color.DarkGray;
            this.OkButton.TabIndex = 12;
            this.OkButton.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.OkButton.Values.Text = "Valider";
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(316, 199);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.OverrideDefault.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.CancelButton.OverrideDefault.Back.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Solid;
            this.CancelButton.OverrideDefault.Border.Color1 = System.Drawing.Color.DarkGray;
            this.CancelButton.OverrideDefault.Border.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Solid;
            this.CancelButton.OverrideDefault.Border.Rounding = 5F;
            this.CancelButton.OverrideFocus.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.CancelButton.OverrideFocus.Back.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Solid;
            this.CancelButton.OverrideFocus.Border.Color1 = System.Drawing.Color.DarkGray;
            this.CancelButton.OverrideFocus.Border.Rounding = 5F;
            this.CancelButton.Size = new System.Drawing.Size(58, 25);
            this.CancelButton.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.CancelButton.StateCommon.Back.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Solid;
            this.CancelButton.StateCommon.Border.Color1 = System.Drawing.Color.DarkGray;
            this.CancelButton.StateCommon.Border.Rounding = 5F;
            this.CancelButton.StatePressed.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(78)))), ((int)(((byte)(85)))));
            this.CancelButton.StatePressed.Back.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Solid;
            this.CancelButton.StatePressed.Border.Color1 = System.Drawing.Color.DarkGray;
            this.CancelButton.StatePressed.Border.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Solid;
            this.CancelButton.StatePressed.Content.ShortText.Color1 = System.Drawing.Color.DarkGray;
            this.CancelButton.StateTracking.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(60)))));
            this.CancelButton.StateTracking.Content.ShortText.Color1 = System.Drawing.Color.DarkGray;
            this.CancelButton.TabIndex = 13;
            this.CancelButton.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.CancelButton.Values.Text = "Retour";
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // ValueLabel
            // 
            this.ValueLabel.AutoSize = true;
            this.ValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ValueLabel.Location = new System.Drawing.Point(14, 13);
            this.ValueLabel.Name = "ValueLabel";
            this.ValueLabel.Size = new System.Drawing.Size(146, 20);
            this.ValueLabel.TabIndex = 14;
            this.ValueLabel.Text = "Trigger sur la valeur";
            // 
            // TimeLabel
            // 
            this.TimeLabel.AutoSize = true;
            this.TimeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimeLabel.Location = new System.Drawing.Point(12, 107);
            this.TimeLabel.Name = "TimeLabel";
            this.TimeLabel.Size = new System.Drawing.Size(148, 20);
            this.TimeLabel.TabIndex = 15;
            this.TimeLabel.Text = "Trigger sur le temps";
            // 
            // TriggerWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(39)))), ((int)(((byte)(46)))));
            this.ClientSize = new System.Drawing.Size(386, 236);
            this.Controls.Add(this.TimeLabel);
            this.Controls.Add(this.ValueLabel);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DataNameCB);
            this.Controls.Add(this.TimeVal);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ValVal);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.TimeCheck);
            this.Controls.Add(this.ValueCheck);
            this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TriggerWindow";
            this.Text = "Tigger sur l\'aquisition";
            ((System.ComponentModel.ISupportInitialize)(this.ValVal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TimeVal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox ValueCheck;
        private System.Windows.Forms.CheckBox TimeCheck;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.NumericUpDown ValVal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown TimeVal;
        private System.Windows.Forms.ComboBox DataNameCB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private Krypton.Toolkit.KryptonButton OkButton;
        private Krypton.Toolkit.KryptonButton CancelButton;
        private System.Windows.Forms.Label ValueLabel;
        private System.Windows.Forms.Label TimeLabel;
    }
}