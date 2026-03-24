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
        Dictionary<int, List<int>> DataFromPlot = new Dictionary<int, List<int>>(); //Liste qui associe a chaque variable les plots qui la dessine
        
        private void AddNewPlot() {
            if (Plots.Count >= 4) return;

            string name = "Figure " + (Plots.Count + 1);
            PlotWindows Plot = new PlotWindows(name);
            Plot.RightClicOnPlott += PlotRightClic;
            Plot.NewVariableToPlott += PlotNewVariable;
            Plot.AquisitionActive = SerialConn.IsOpen;

            PlotWindow pw = new PlotWindow(name, Plots.Count);
            activeWindow.plots.Add(pw);

            Plots.Add(Plot);
            MainPage.Controls.Add(Plot);
            RearrangePlot();



        }

        private void RemovePlot() {
            if (Plots.Count == 0) return;

            int index = Plots.Count - 1;

            Plots[index].RightClicOnPlott -= PlotRightClic;
            Plots.RemoveAt(index);
            MainPage.Controls.RemoveAt(index);
            RearrangePlot();

            activeWindow.plots.RemoveAt(index);
        }

        private void RearrangePlot() {
            switch (Plots.Count) {
                case 1:
                    Plots[0].Size = MainPage.Size - new Size(PaddingPlotMainPage*2, PaddingPlotMainPage*2);
                    Plots[0].Location = new Point(PaddingPlotMainPage, PaddingPlotMainPage);
                    break;
                case 2:
                    Plots[0].Size = new Size(MainPage.Width, MainPage.Height/2)
                        - new Size(PaddingPlotMainPage*2, PaddingPlotPlot + PaddingPlotMainPage);
                    Plots[0].Location = new Point(PaddingPlotMainPage, PaddingPlotMainPage);

                    Plots[1].Size = new Size(MainPage.Width, MainPage.Height / 2)
                        - new Size(PaddingPlotMainPage * 2, PaddingPlotMainPage + PaddingPlotPlot);
                    Plots[1].Location = new Point(PaddingPlotMainPage, MainPage.Height / 2 + PaddingPlotPlot);
                    break;

                case 3:
                    Plots[0].Size = new Size(MainPage.Width/2, MainPage.Height / 2)
                        - new Size(PaddingPlotMainPage + PaddingPlotPlot, PaddingPlotPlot + PaddingPlotMainPage);
                    Plots[0].Location = new Point(PaddingPlotMainPage, PaddingPlotMainPage);

                    Plots[2].Size = new Size(MainPage.Width/2, MainPage.Height / 2)
                        - new Size(PaddingPlotMainPage + PaddingPlotPlot, PaddingPlotPlot + PaddingPlotMainPage);
                    Plots[2].Location = new Point(MainPage.Width / 2 + PaddingPlotPlot, PaddingPlotMainPage);


                    Plots[1].Size = new Size(MainPage.Width, MainPage.Height / 2)
                        - new Size(PaddingPlotMainPage * 2, PaddingPlotMainPage + PaddingPlotPlot);
                    Plots[1].Location = new Point(PaddingPlotMainPage, MainPage.Height / 2 + PaddingPlotPlot);
                    break;

                case 4:
                    Plots[0].Size = new Size(MainPage.Width / 2, MainPage.Height / 2)
                        - new Size(PaddingPlotMainPage + PaddingPlotPlot, PaddingPlotPlot + PaddingPlotMainPage);
                    Plots[0].Location = new Point(PaddingPlotMainPage, PaddingPlotMainPage);

                    Plots[2].Size = new Size(MainPage.Width / 2, MainPage.Height / 2)
                        - new Size(PaddingPlotMainPage + PaddingPlotPlot, PaddingPlotPlot + PaddingPlotMainPage);
                    Plots[2].Location = new Point(MainPage.Width / 2 + PaddingPlotPlot, PaddingPlotMainPage);


                    Plots[1].Size = new Size(MainPage.Width / 2, MainPage.Height / 2)
                        - new Size(PaddingPlotMainPage + PaddingPlotPlot, PaddingPlotPlot + PaddingPlotMainPage);
                    Plots[1].Location = new Point(PaddingPlotMainPage, MainPage.Height / 2 + PaddingPlotPlot);

                    Plots[3].Size = new Size(MainPage.Width / 2, MainPage.Height / 2)
                        - new Size(PaddingPlotMainPage + PaddingPlotPlot, PaddingPlotPlot + PaddingPlotMainPage);
                    Plots[3].Location = new Point(MainPage.Width / 2 + PaddingPlotPlot, MainPage.Height / 2 + PaddingPlotPlot);
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
            for (int PlotsNumber = 0; PlotsNumber < Plots.Count; PlotsNumber++) {
                if (Plots[PlotsNumber].Equals(sender)) {
                    foreach(int VarId in Plots[PlotsNumber].GetVariablePlotted()) {
                        DataFromPlot[VarId-1].Add(PlotsNumber);
                        activeWindow.plots[PlotsNumber].dataPloted.Add(VarId-1);
                    }
                }
            }
        }


        private void PlotRightClic(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Right) {
                menuPlot.Show(MainPage, MousePosition);
            }
        }
    
        private void RenderPlots(object sender, EventArgs e) {
            foreach(PlotWindows plot in Plots) {
                plot.RefreshPlot(timeY[timeY.Count-1]);
            }
        }
    
    }
}
