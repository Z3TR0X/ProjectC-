using Krypton.Toolkit;
using ScottPlot.Colormaps;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ProjectC_ {

    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            MenuSerialPort.Renderer = new CustomSelectionRenderer();
            MenuSpeed.Renderer = new CustomSelectionRenderer();
            LeftBar.Enabled = false;
            MenuSeparatorBar.Enabled = false;
            SerialHander = new SerialDataReceivedEventHandler(DataReceivedHandler);

            KryptonButtonCorrection(this.Controls);

            String[] names = {"coucou", "aninaninano", "szyenfolie", "Nain"};
            for (int i = 0; i < names.Length; i++) {
                PanelVarControl v = new PanelVarControl();
                v.Init(names[i], i, FlowVarPanel.ClientSize.Width);
                FlowVarPanel.Controls.Add(v);
            }


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

        private void kryptonColorButton1_SelectedColorChanged(object sender, ColorEventArgs e)
        {
            this.MainPage.BackColor = e.Color;
            this.FlowVarPanel.BackColor = e.Color;
            this.ComPanel.BackColor = e.Color; 
            this.PagePanel.BackColor = e.Color;
        }
    }
}




