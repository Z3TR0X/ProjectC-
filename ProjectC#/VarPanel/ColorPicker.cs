using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectC_.VarPanel {

    public partial class ColorPicker : UserControl {
        private Color ActualColor;
        public Color LastColor;

        public ColorPicker() {
            InitializeComponent();
        }

        public void setLastColor(Color color) {
            LastColor = color;
            ActualColor = color;

            LastColorPanel.StateCommon.Color1 = LastColor;
            WheelColorPicker.Color = ActualColor;
            ManualColorPicker.Color = ActualColor; 
            NewColorPanel.StateCommon.Color1 = ActualColor;
        }

        public Color getActualColor() {
            return ActualColor;
        }

        private void WheelColorPicker_ColorChanged(object sender, EventArgs e) {
            ActualColor = WheelColorPicker.Color;

            ManualColorPicker.Color = ActualColor;
            NewColorPanel.StateCommon.Color1 = ActualColor;
        }

        private void ManualColorPicker_ColorChanged(object sender, EventArgs e) {
            ActualColor = ManualColorPicker.Color;

            WheelColorPicker.Color = ActualColor;
            NewColorPanel.StateCommon.Color1 = ActualColor;
        }
    }
}
