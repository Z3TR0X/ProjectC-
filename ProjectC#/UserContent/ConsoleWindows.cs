using ScottPlot;
using ScottPlot.AxisRules;
using ScottPlot.Colormaps;
using ScottPlot.Interactivity;
using ScottPlot.Plottables;
using ScottPlot.WinForms;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectC_.UserContent {
    public partial class ConsoleWindow : UserControl{

        public ConsoleWindow() {
            InitializeComponent();
            this.Padding = new Padding(5,0,0,0);

            foreach (Control control in this.Controls) {
                if (control is Krypton.Toolkit.KryptonButton btn) {
                    btn.OverrideDefault.Back.Color1 = btn.StateCommon.Back.Color1;
                    btn.OverrideDefault.Back.ColorStyle = btn.StateCommon.Back.ColorStyle;

                    btn.OverrideDefault.Border.Color1 = btn.StateCommon.Border.Color1;
                    btn.OverrideDefault.Border.ColorStyle = btn.StateCommon.Border.ColorStyle;
                }
            }
        }

        private void ConsoleWindow_SizeChanged(object sender, EventArgs e) {
            int w = this.Width;
            ClearButton.Location = new Point(w-5-28, 3);
            ClearButton.Size = new Size(28, 28);
            ClearButton.OverrideDefault.Back.Color1 = ClearButton.StateCommon.Back.Color1;
            ClearButton.OverrideDefault.Back.ColorStyle = ClearButton.StateCommon.Back.ColorStyle;
            ClearButton.OverrideDefault.Border.Color1 = ClearButton.StateCommon.Border.Color1;
            ClearButton.OverrideDefault.Border.ColorStyle = ClearButton.StateCommon.Border.ColorStyle;

            TimeButton.Location = new Point(w - 5 - 2*28-5, 3);
            TimeButton.Size = new Size(28, 28);
            TimeButton.OverrideDefault.Back.Color1 = TimeButton.StateCommon.Back.Color1;
            TimeButton.OverrideDefault.Back.ColorStyle = TimeButton.StateCommon.Back.ColorStyle;
            TimeButton.OverrideDefault.Border.Color1 = TimeButton.StateCommon.Border.Color1;
            TimeButton.OverrideDefault.Border.ColorStyle = TimeButton.StateCommon.Border.ColorStyle;
            TopPanel.Height = 34;

            ConsoleName.Location = new Point(1, 5);
        }
    }
}


