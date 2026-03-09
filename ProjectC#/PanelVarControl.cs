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
    public partial class PanelVarControl : UserControl {
        public PanelVarControl() {
            InitializeComponent();
        }

        public void Init(String varName, int id, int maxWidth) {
            VarItem.Tag = id;
            VarName.Text = varName;
            this.Width = maxWidth;
        }

        public void setCurrentValue(float value) {
            VarValue.Text = value.ToString();
        }

        private void VarItem_MouseEnter(object sender, EventArgs e) {
            VarItem.StateCommon.Color1 = Color.FromArgb(80, 80, 80);
        }

        private void VarItem_MouseLeave(object sender, EventArgs e) {
            VarItem.StateCommon.Color1 = Color.FromArgb(34, 39, 46);
        }
    }
}
