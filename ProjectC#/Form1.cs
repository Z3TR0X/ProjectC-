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

        private void kryptonPanel2_MouseDown(object sender, MouseEventArgs e) {

            if (e.Button == MouseButtons.Left){
                KryptonPanel panel = sender as KryptonPanel;
                string var = panel.Tag?.ToString() ?? "Rien";
                panel.DoDragDrop(var, DragDropEffects.Copy);
            }
        }

        private void kryptonPanel1_DragDrop(object sender, DragEventArgs e) {
            string var = (string)e.Data.GetData(DataFormats.StringFormat);

            MessageBox.Show(var);
        }

        private void kryptonPanel1_DragEnter(object sender, DragEventArgs e) {
            if (e.Data.GetDataPresent(DataFormats.StringFormat)) {
                e.Effect = DragDropEffects.Copy;
            } else {
                e.Effect = DragDropEffects.None;
            }
        }
    }
}




