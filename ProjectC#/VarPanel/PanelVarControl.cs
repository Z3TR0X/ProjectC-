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

            foreach (Control enfant in this.Controls) {
                // On abonne chaque enfant à son propre événement MouseUp
                enfant.MouseUp += (sender, e) =>
                {
                    // L'enfant déclenche manuellement l'événement MouseUp du parent (le UserControl) !
                    this.OnMouseUp(e);
                };
            }
        }

        public void Init(String varName, int id, int maxWidth) {
            VarItem.Tag = id;
            VarName.Text = varName;
            this.Width = maxWidth;
        }

        public void setCurrentValue(float value) {
            VarValue.Text = value.ToString();
        }

        public int getCurrentValue() {
            return (int) VarItem.Tag;
        }

        public void setVarName(string varName) {
            VarName.Text = varName;
        }

        public void setColor(Color color) {
            VarColor.StateCommon.Color1 = color;
        }

        private void VarItem_MouseEnter(object sender, EventArgs e) {
            VarItem.StateCommon.Color1 = Color.FromArgb(80, 80, 80);
        }

        private void VarItem_MouseLeave(object sender, EventArgs e) {
            VarItem.StateCommon.Color1 = Color.FromArgb(34, 39, 46);
        }
    }
}
