using ProjectC_.UserContent;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectC_ {
    public partial class MenuCustomVar : PanelVarMenu  {

        private string expression;

        public MenuCustomVar(Form1 mainForm) : base(mainForm) {
            InitializeComponent();
        }

        public void SetExpression(string ex) {
            expression = ex;
            ExpressionText.Text = expression;
        }

        public string GetExpression() {
            return expression;
        }

        protected override void ColorChooser_Click(object sender, EventArgs e) {
            mainForm.BeginPickColor(true);
        }

        private void ExpressionEnterPress(object sender, KeyPressEventArgs e) {
            if(e.KeyChar == (char)Keys.Enter) {
                mainForm.ChangeExpression(this.dataId, ExpressionText.Text);
            }
        }
    }
}
