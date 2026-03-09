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
    public partial class PanelVarMenu : UserControl {
        public PanelVarMenu() {
            InitializeComponent();
            KryptonButtonCorrection(this.Controls);
        }

        private void KryptonButtonCorrection(Control.ControlCollection ctrls) {
            foreach (Control control in ctrls) {
                if (control is Krypton.Toolkit.KryptonButton btn) {
                    btn.OverrideDefault.Back.Color1 = btn.StateCommon.Back.Color1;
                    btn.OverrideDefault.Back.ColorStyle = btn.StateCommon.Back.ColorStyle;

                    btn.OverrideDefault.Border.Color1 = btn.StateCommon.Border.Color1;
                    btn.OverrideDefault.Border.ColorStyle = btn.StateCommon.Border.ColorStyle;
                }

                if (control.HasChildren) {
                    KryptonButtonCorrection(control.Controls);
                }
            }
        }
    }
}

    
