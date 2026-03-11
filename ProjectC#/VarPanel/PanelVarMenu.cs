using Krypton.Toolkit;
using ProjectC_.VarPanel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectC_ {  

    public partial class PanelVarMenu : UserControl {

        int dataId;
        Form1 mainForm;

        public PanelVarMenu(Form1 mainForm) {
            InitializeComponent();
            KryptonButtonCorrection(this.Controls);
            this.mainForm = mainForm;
            this.DoubleBuffered = true;
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

        public void setDataId(int id) {
            dataId = id;
        }

        private void NameTextBox_KeyPress(object sender, KeyPressEventArgs e) {
            if(e.KeyChar == (char) Keys.Enter) {
                mainForm.ChangeVarName(dataId, NameTextBox.Text);
            }
        }

        private void ColorChooser_Click(object sender, EventArgs e) {
            mainForm.BeginPickColor();
        }

        public void setColor(Color color){
            ColorChooser.StateCommon.Back.Color1 = color;
            ColorChooser.StateCommon.Border.Color1 = color;
            mainForm.ChangeVarColor(dataId, color);
        }
    }
}

    
