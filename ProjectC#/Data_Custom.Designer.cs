namespace ProjectC_
{
    partial class Data_Custom
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.DataName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.DataEquation = new System.Windows.Forms.TextBox();
            this.AddNewData = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name :";
            // 
            // DataName
            // 
            this.DataName.Location = new System.Drawing.Point(133, 22);
            this.DataName.Name = "DataName";
            this.DataName.Size = new System.Drawing.Size(100, 26);
            this.DataName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Equation : ";
            // 
            // DataEquation
            // 
            this.DataEquation.Location = new System.Drawing.Point(133, 71);
            this.DataEquation.Name = "DataEquation";
            this.DataEquation.Size = new System.Drawing.Size(100, 26);
            this.DataEquation.TabIndex = 3;
            this.DataEquation.TextChanged += new System.EventHandler(this.DataEquation_TextChanged);
            // 
            // AddNewData
            // 
            this.AddNewData.ForeColor = System.Drawing.Color.DimGray;
            this.AddNewData.Location = new System.Drawing.Point(120, 185);
            this.AddNewData.Name = "AddNewData";
            this.AddNewData.Size = new System.Drawing.Size(113, 50);
            this.AddNewData.TabIndex = 4;
            this.AddNewData.Text = "Ajouter la donnée ";
            this.AddNewData.UseVisualStyleBackColor = true;
            this.AddNewData.Click += new System.EventHandler(this.AddNewData_Click);
            // 
            // Data_Custom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(373, 310);
            this.Controls.Add(this.AddNewData);
            this.Controls.Add(this.DataEquation);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DataName);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.Silver;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Data_Custom";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "Data_Custom";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox DataName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox DataEquation;
        private System.Windows.Forms.Button AddNewData;
    }
}