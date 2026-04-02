using Krypton.Toolkit;
using ProjectC_.UserContent;
using ScottPlot;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ProjectC_ {

    public partial class Form1 : Form {
        List<PlotWindows> Plots = new List<PlotWindows>();
        public Dictionary<int, List<int>> DataFromPlot = new Dictionary<int, List<int>>(); //Liste qui associe a chaque variable les plots qui la dessine
        
        private void AddNewPlot() {
            if (Plots.Count >= 4) return;

            string name = "Figure " + (Plots.Count + 1);
            PlotWindows Plot = new PlotWindows(name);
            Plot.RightClicOnPlott += PlotRightClic;
            Plot.NewVariableToPlott += PlotNewVariable;
            Plot.SetAquisitionActive(SerialConn.IsOpen);

            PlotWindow pw = new PlotWindow(name, Plots.Count);
            pw.axisLimit.Add('l', (0, 0)); // Axe Y gauche
            pw.axisLimit.Add('r', (0, 0)); // Axe Y droit
            pw.axisLimit.Add('b', (0, 0)); // Axe X
            activeWindow.Item1.plots.Add(pw);

            Plots.Add(Plot);
            LayoutPanel.Controls.Add(Plot);
            RearrangePlot();



        }

        private void RemovePlot() {
            if (Plots.Count == 0) return;

            int index = Plots.Count - 1;

            Plots[index].RightClicOnPlott -= PlotRightClic;
            Plots.RemoveAt(index);
            LayoutPanel.Controls.RemoveAt(index);
            RearrangePlot();

            foreach (List<int> graphs in DataFromPlot.Values) {
                for (int i = 0; i < graphs.Count; i++) {
                    if (graphs[i] == index) {
                        graphs.RemoveAt(i);
                    }
                }
            }
            activeWindow.Item1.plots.RemoveAt(index);
        }

        private void RearrangePlot() {
            switch (Plots.Count) {
                case 1:
                    Plots[0].Size = LayoutPanel.Size - new Size(PaddingPlotMainPage*2, PaddingPlotMainPage*2);
                    Plots[0].Location = new Point(PaddingPlotMainPage, PaddingPlotMainPage);
                    break;
                case 2:
                    Plots[0].Size = new Size(LayoutPanel.Width, LayoutPanel.Height/2)
                        - new Size(PaddingPlotMainPage*2, PaddingPlotPlot + PaddingPlotMainPage);
                    Plots[0].Location = new Point(PaddingPlotMainPage, PaddingPlotMainPage);

                    Plots[1].Size = new Size(LayoutPanel.Width, LayoutPanel.Height / 2)
                        - new Size(PaddingPlotMainPage * 2, PaddingPlotMainPage + PaddingPlotPlot);
                    Plots[1].Location = new Point(PaddingPlotMainPage, LayoutPanel.Height / 2 + PaddingPlotPlot);
                    break;

                case 3:
                    Plots[0].Size = new Size(LayoutPanel.Width/2, LayoutPanel.Height / 2)
                        - new Size(PaddingPlotMainPage + PaddingPlotPlot, PaddingPlotPlot + PaddingPlotMainPage);
                    Plots[0].Location = new Point(PaddingPlotMainPage, PaddingPlotMainPage);

                    Plots[2].Size = new Size(LayoutPanel.Width/2, LayoutPanel.Height / 2)
                        - new Size(PaddingPlotMainPage + PaddingPlotPlot, PaddingPlotPlot + PaddingPlotMainPage);
                    Plots[2].Location = new Point(LayoutPanel.Width / 2 + PaddingPlotPlot, PaddingPlotMainPage);


                    Plots[1].Size = new Size(LayoutPanel.Width, LayoutPanel.Height / 2)
                        - new Size(PaddingPlotMainPage * 2, PaddingPlotMainPage + PaddingPlotPlot);
                    Plots[1].Location = new Point(PaddingPlotMainPage, LayoutPanel.Height / 2 + PaddingPlotPlot);
                    break;

                case 4:
                    Plots[0].Size = new Size(LayoutPanel.Width / 2, LayoutPanel.Height / 2)
                        - new Size(PaddingPlotMainPage + PaddingPlotPlot, PaddingPlotPlot + PaddingPlotMainPage);
                    Plots[0].Location = new Point(PaddingPlotMainPage, PaddingPlotMainPage);

                    Plots[2].Size = new Size(LayoutPanel.Width / 2, LayoutPanel.Height / 2)
                        - new Size(PaddingPlotMainPage + PaddingPlotPlot, PaddingPlotPlot + PaddingPlotMainPage);
                    Plots[2].Location = new Point(LayoutPanel.Width / 2 + PaddingPlotPlot, PaddingPlotMainPage);


                    Plots[1].Size = new Size(LayoutPanel.Width / 2, LayoutPanel.Height / 2)
                        - new Size(PaddingPlotMainPage + PaddingPlotPlot, PaddingPlotPlot + PaddingPlotMainPage);
                    Plots[1].Location = new Point(PaddingPlotMainPage, LayoutPanel.Height / 2 + PaddingPlotPlot);

                    Plots[3].Size = new Size(LayoutPanel.Width / 2, LayoutPanel.Height / 2)
                        - new Size(PaddingPlotMainPage + PaddingPlotPlot, PaddingPlotPlot + PaddingPlotMainPage);
                    Plots[3].Location = new Point(LayoutPanel.Width / 2 + PaddingPlotPlot, LayoutPanel.Height / 2 + PaddingPlotPlot);
                    break;


                default:
                    break;
            }
        }


        private KryptonContextMenu menuPlot;

        private void CreateRightClicMenu() {
            menuPlot = new KryptonContextMenu();

            menuPlot.PaletteMode = Krypton.Toolkit.PaletteMode.Custom;
            menuPlot.LocalCustomPalette = CustomPalette;

            KryptonContextMenuItems blocItems = new KryptonContextMenuItems();

            KryptonContextMenuItem createPlot = new KryptonContextMenuItem();
            createPlot.Image = Properties.Resources.AddChart;
            createPlot.Text = "Ajouter une figure";
            createPlot.Click += (s, e) => {
                AddNewPlot();
            };

            KryptonContextMenuItem deletePlot = new KryptonContextMenuItem();
            deletePlot.Image = Properties.Resources.RemoveChart;
            deletePlot.Text = "Retirer une figure";
            deletePlot.Click += (s, e) => {
                RemovePlot();
            };

            blocItems.Items.Add(createPlot);
            blocItems.Items.Add(deletePlot);

            menuPlot.Items.Add(blocItems);
        }

        private void PlotNewVariable(object sender, EventArgs e) {
            EqualizeDatas();
            for (int PlotsNumber = 0; PlotsNumber < Plots.Count; PlotsNumber++) {
                if (Plots[PlotsNumber].Equals(sender)) {
                    foreach(int VarId in Plots[PlotsNumber].GetVariablePlotted()) {
                        if (DataFromPlot[VarId].Contains(PlotsNumber)) continue;
                        DataFromPlot[VarId].Add(PlotsNumber);
                        activeWindow.Item1.plots[PlotsNumber].dataPloted[VarId] = Plots[PlotsNumber].getPosition(VarId);
                        Plots[PlotsNumber].PlotCurve(VarId, timeY.ToArray(), Array.ConvertAll(Datas[VarId].ToArray(), x => (double)x));
                    }
                }
            }
        }

        public void DeleteVarFromPlots(int dataId) {
            foreach (int plotNumber in DataFromPlot[dataId]) {
                Plots[plotNumber].StopPlottingData(dataId);
            }
            foreach(var win in windows) {
                Window window = win.Item1;
                foreach(PlotWindow plot in window.plots) {
                    if(plot.dataPloted.ContainsKey(dataId)) plot.dataPloted.Remove(dataId);
                }
            }
            DataFromPlot[dataId] = new List<int>();
        }

        private void PlotRightClic(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Right) {
                menuPlot.Show(LayoutPanel, MousePosition);
            }
        }
    
        private void RenderPlots(object sender, EventArgs e) {
            if (timeY.Count == 0) return;

            foreach(PlotWindows plot in Plots) {
                plot.RefreshPlot(timeY[timeY.Count-1]);
            }
        }
    
    }
}
