using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using NCalc;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.XPath;

namespace ProjectC_
{
    public partial class Data_Custom : Form
    {
        Data_Custom DataCustom;
        
        public Data_Custom()
        {
            InitializeComponent();
           

        }
        public string resultat { get; set; }
        public string nom { get; set; }

        
            
        

        private void DataEquation_TextChanged(object sender, EventArgs e)
        {
            try 
            {
                var equation = new NCalc.Expression(DataEquation.Text);
                var result = equation.Evaluate();
                label2.Text = result.ToString();
                resultat = label2.Text;
                nom = DataName.Text;
            }
            catch(Exception)
            {
                label2.Text = "...";
            }
            
        }

        private void AddNewData_Click(object sender, EventArgs e)
        {
            if (nom == null || resultat == null) {
                MessageBox.Show("Veuillez entrer une équation valide et un nom pour la donnée.");
                return;
            }
            else
            {
               // AddNewDatas();
                this.DialogResult = DialogResult.OK;
            }
         this.Close();            
        }
        
    }
}
