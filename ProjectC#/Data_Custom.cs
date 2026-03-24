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

namespace ProjectC_
{
    public partial class Data_Custom : Form
    {
        public Data_Custom()
        {
            InitializeComponent();
        }

        private void DataEquation_TextChanged(object sender, EventArgs e)
        {
            try 
            {
                var equation = new NCalc.Expression(DataEquation.Text);
                var result = equation.Evaluate();
                label2.Text = result.ToString();
            }
            catch(Exception)
            {
                label2.Text = "...";
            }
            
        }

        private void AddNewData_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
