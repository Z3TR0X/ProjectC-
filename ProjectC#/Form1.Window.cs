using Krypton.Toolkit;
using ProjectC_.UserContent;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;



namespace ProjectC_ {
    public partial class Form1 : Form {
        private KryptonContextMenu menuRightClicWindow;
        private List<(Window, PanelWindowControl)> windows = new List<(Window, PanelWindowControl)>();
        private (Window, PanelWindowControl) activeWindow;

        KryptonInputBoxData InputBoxdatas = new Krypton.Toolkit.KryptonInputBoxData {
            Prompt = "Entrez le nouveau nom : ",
            Caption = "Renommer",
            DefaultResponse = "",

        }; // Menu pour la boite de renommage


        private void CreateNewWindow() {
            PanelWindowControl panel = new PanelWindowControl();
            panel.MouseClick += OnClicWindowEvent;
            string name = "Fenêtre " + (windows.Count + 1).ToString();
            panel.Init(name, FlowLayoutWindow.ClientSize.Width, windows.Count);
            Window w = new Window(name, 0);
            if (windows.Count == 0) {
                activeWindow = (w, panel);
                panel.setSelected(true);
            }
            windows.Add((w, panel));
            FlowLayoutWindow.Controls.Add(panel);
        }

        private void DeleteWindow(int windowId) {
            if (windows.Count == 1) {
                MessageBox.Show("Vous devez avoir au\nminimum une fenêtre", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (windows[windowId].Equals(activeWindow)) {
                PanelWindowControl panelToBeActive = windowId == 0 ? windows[1].Item2 : windows[0].Item2;

                selectWindow(panelToBeActive.id);
                panelToBeActive.setSelected(true);
            }


            FlowLayoutWindow.Controls.Remove(windows[windowId].Item2);
            for (int i = windowId + 1; i < windows.Count ; i++) {
                windows[i].Item2.id = i-1;
            }
            windows.RemoveAt(windowId);
        }

        private void OnClicWindowEvent(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) { 
                if(sender.GetType() == typeof(PanelWindowControl)) {
                    selectWindow(((PanelWindowControl) sender).id);
                }else if(sender.GetType() == typeof(PanelConsoleControl)) {
                    SelectConsole(((PanelConsoleControl)sender).id);
                }
            }

            if (e.Button == MouseButtons.Right) {

                menuRightClicWindow = new KryptonContextMenu();
                menuRightClicWindow.PaletteMode = Krypton.Toolkit.PaletteMode.Custom;
                menuRightClicWindow.LocalCustomPalette = CustomPalette;

                KryptonContextMenuItems blocItems = new KryptonContextMenuItems();

                KryptonContextMenuItem createWindow = new KryptonContextMenuItem();
                createWindow.Image = Properties.Resources.AddWindow;
                createWindow.Text = "Nouvelle fenêtre";
                createWindow.Click += (s, ev) => {
                    CreateNewWindow();
                };

                KryptonContextMenuItem createConsole = new KryptonContextMenuItem();
                createConsole.Image = Properties.Resources.AddConsole;
                createConsole.Text = "Nouvelle console";
                createConsole.Click += (s, ev) => {
                    CreateNewConsole();
                };

                if (sender.GetType() == typeof(PanelWindowControl)) {
                    KryptonContextMenuItem RemoveWindow = new KryptonContextMenuItem();
                    RemoveWindow.Image = Properties.Resources.RemoveWindow;
                    RemoveWindow.Text = "Supprimer la fenêtre";
                    RemoveWindow.Click += (s, ev) => {
                        PanelWindowControl panel = (PanelWindowControl) sender;
                        DeleteWindow(panel.id);                   
                    };

                    KryptonContextMenuSeparator sepa = new KryptonContextMenuSeparator();
                    sepa.StateNormal.Back.Color1 = Color.DarkGray;

                    KryptonContextMenuItem RenameWindow = new KryptonContextMenuItem();
                    RenameWindow.Image = Properties.Resources.Rename;
                    RenameWindow.Text = "Renommer la fenêtre";
                    RenameWindow.Click += (s, ev) => {
                        string val = KryptonInputBox.Show(InputBoxdatas);
                        if (val == "" || val == null) {
                            MessageBox.Show("Nom invalide", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        PanelWindowControl panel = (PanelWindowControl) sender;
                        Window win = windows[panel.id].Item1;
                        win.windowName = val;
                        panel.SetName(val);
                    };



                    blocItems.Items.Add(createWindow);
                    blocItems.Items.Add(RemoveWindow);
                    blocItems.Items.Add(createConsole);
                    blocItems.Items.Add(sepa);
                    blocItems.Items.Add(RenameWindow);
                } else if (sender.GetType() == typeof(PanelConsoleControl)) {
                    KryptonContextMenuItem RemoveConsole = new KryptonContextMenuItem();
                    RemoveConsole.Image = Properties.Resources.RemoveConsole;
                    RemoveConsole.Text = "Supprimer la console";
                    RemoveConsole.Click += (s, ev) => {
                        PanelConsoleControl panel = (PanelConsoleControl)sender;
                        DeleteConsole(panel.id);
                    };

                    KryptonContextMenuSeparator sepa = new KryptonContextMenuSeparator();
                    sepa.StateNormal.Back.Color1 = Color.DarkGray;
                    sepa.StateNormal.Back.ColorStyle = PaletteColorStyle.Solid;

                    KryptonContextMenuItem RenameConsole = new KryptonContextMenuItem();
                    RenameConsole.Image = Properties.Resources.Rename;
                    RenameConsole.Text = "Renommer la console";
                    RenameConsole.Click += (s, ev) => {
                        string val = KryptonInputBox.Show(InputBoxdatas);
                        if (val == "" || val == null) {
                            MessageBox.Show("Nom invalide", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        PanelConsoleControl panel = (PanelConsoleControl)sender;
                        ConsoleWindow con = consoles[panel.id].Item1;
                        con.setName(val);
                        panel.setName(val);
                    };

                    blocItems.Items.Add(createWindow);
                    blocItems.Items.Add(createConsole);
                    blocItems.Items.Add(RemoveConsole);
                    blocItems.Items.Add(sepa);
                    blocItems.Items.Add(RenameConsole);
                } else {
                    blocItems.Items.Add(createWindow);
                    blocItems.Items.Add(createConsole);
                }



                menuRightClicWindow.Items.Add(blocItems);

                menuRightClicWindow.Show(LayoutPanel, MousePosition);
            }
        }


        private void selectWindow(int windowsId) {
            for (int i = 0; i < Plots.Count; i++) {
                activeWindow.Item1.plots[i].axisLimit['l'] = Plots[i].GetAxesLimits('l');
                activeWindow.Item1.plots[i].axisLimit['r'] = Plots[i].GetAxesLimits('r');
                activeWindow.Item1.plots[i].axisLimit['b'] = Plots[i].GetAxesLimits('b');
            }
            activeWindow.Item2.setSelected(false);
            activeWindow = windows[windowsId];
            PanelWindowControl panel = activeWindow.Item2;
            panel.setSelected(true);
            Plots = new List<PlotWindows>();
            LayoutPanel.Controls.Clear();
            foreach(List<int> dp in DataFromPlot.Values) {
                dp.Clear();
            }


            foreach (PlotWindow wp in activeWindow.Item1.plots) {

                PlotWindows Plot = new PlotWindows(wp.plotName);
                Plot.RightClicOnPlott += PlotRightClic;
                Plot.NewVariableToPlott += PlotNewVariable;
                Plot.SetAquisitionActive(SerialConn.IsOpen);
                foreach(char axe in new char[] {'l', 'r', 'b'}){
                    Plot.SetAxesLimits(axe, wp.axisLimit[axe]);
                }
                
                foreach(int dp in wp.dataPloted.Keys) {
                    DataFromPlot[dp].Add(wp.plotId);
                    DataInfos info = new DataInfos(DatasName[dp], DatasColor[dp], dp);
                    Plot.PlotNewData(info, wp.dataPloted[dp]);
                }

                Plots.Add(Plot);
                LayoutPanel.Controls.Add(Plot);
            }
            RearrangePlot();
        }
    }
}
