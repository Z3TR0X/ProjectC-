using Krypton.Toolkit;
using ScottPlot;
using ScottPlot.Colormaps;
using ScottPlot.WinForms;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


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

            DataPanelTimer = new System.Windows.Forms.Timer();
            DataPanelTimer.Interval = 100;
            DataPanelTimer.Tick += new System.EventHandler(UpdateDatasPanels);

            createPanelRightClicMenu();
            createColorPickerMenu();

            ApplyPlotDesign(formsPlot1.Plot);
            formsPlot1.Refresh();
          
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