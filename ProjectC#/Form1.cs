using Krypton.Toolkit;
using ScottPlot;
using ScottPlot.Colormaps;
using ScottPlot.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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

        private Stopwatch millis = new Stopwatch();
        private Timer refreshPlotTick = new Timer();


        public Form1() {
            InitializeComponent();
            MenuSerialPort.Renderer = new CustomSelectionRenderer();
            MenuSpeed.Renderer = new CustomSelectionRenderer();
            LeftBar.Enabled = false;
            MenuSeparatorBar.Enabled = false;
            SerialHander = new SerialDataReceivedEventHandler(DataReceivedHandler);
            label1.Visible = false;

            KryptonButtonCorrection(this.Controls);

            DataPanelTimer = new System.Windows.Forms.Timer();
            DataPanelTimer.Interval = 100;
            DataPanelTimer.Tick += new System.EventHandler(UpdateDatasPanels);

            refreshPlotTick.Interval = 100;
            refreshPlotTick.Tick += RenderPlots;
            refreshPlotTick.Stop();

            createPanelRightClicMenu();
            createColorPickerMenu();

            CreateRightClicMenu();

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

        private void label1_Paint(object sender, PaintEventArgs e)
        {
            label1.Text = " Export vers CSV" + Environment.NewLine +
          "Exporter les données vers un fichier CSV, visualisable sur Excel";
            int radius = 10;
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            using (System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath())
            {
                path.AddArc(0, 0, radius, radius, 180, 90);
                path.AddArc(label1.Width - radius - 1, 0, radius, radius, 270, 90);
                path.AddArc(label1.Width - radius - 1, label1.Height - radius - 1, radius, radius, 0, 90);
                path.AddArc(0, label1.Height - radius - 1, radius, radius, 90, 90);
                path.CloseAllFigures();
                label1.Region = new Region(path);
                using (Pen pen = new Pen(System.Drawing.Color.AliceBlue, 2))
                {
                    e.Graphics.DrawPath(pen, path);
                }
              
            }
            

        }

        private void ExportButton_MouseHover(object sender, EventArgs e)
        {
            label1.Visible = true;
        }

        private void ExportButton_MouseLeave(object sender, EventArgs e)
        {
            label1.Visible = false;
        }
    }
}