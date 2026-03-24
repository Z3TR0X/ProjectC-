using Krypton.Toolkit;
using ProjectC_.UserContent;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;



namespace ProjectC_ {
    public partial class Form1 : Form {
        private KryptonContextMenu menuRightClicWindow;
        private List<Window> windows = new List<Window>();
        private Window activeWindow;

        private void CreateNewWindow() {
            PanelWindowControl panel = new PanelWindowControl();
            panel.MouseClick += OnClicWindowEvent;
            string name = "Fenêtre " + windows.Count.ToString();
            panel.Init(name, FlowLayoutWindow.ClientSize.Width, windows.Count);
            Window w = new Window(name, 0);
            windows.Add(w);
            activeWindow = w;
            FlowLayoutWindow.Controls.Add(panel);
        }

        private void CreateNewConsole() {
            PanelConsoleControl panel = new PanelConsoleControl();
            panel.MouseClick += OnClicWindowEvent;
            panel.Init(FlowLayoutWindow.ClientSize.Width);
            FlowLayoutWindow.Controls.Add(panel);
        }


        KryptonInputBoxData InputBoxdatas = new Krypton.Toolkit.KryptonInputBoxData {
            Prompt = "Entrez le nouveau nom : ",
            Caption = "Renommer",
            DefaultResponse = "",

        };
        private void OnClicWindowEvent(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) { 
                if(sender.GetType() == typeof(PanelWindowControl)) {
                    selectWindow((PanelWindowControl) sender);
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

                if (sender.GetType() == typeof(PanelWindowControl)) {
                    KryptonContextMenuItem RemoveWindow = new KryptonContextMenuItem();
                    RemoveWindow.Image = Properties.Resources.RemoveWindow;
                    RemoveWindow.Text = "Supprimer la fenêtre";

                    KryptonContextMenuSeparator sepa = new KryptonContextMenuSeparator();
                    sepa.StateNormal.Back.Color1 = Color.DarkGray;

                    KryptonContextMenuItem RenameWindow = new KryptonContextMenuItem();
                    RenameWindow.Image = Properties.Resources.Rename;
                    RenameWindow.Text = "Renommer la fenêtre";



                    blocItems.Items.Add(createWindow);
                    blocItems.Items.Add(RemoveWindow);
                    blocItems.Items.Add(createConsole);
                    blocItems.Items.Add(sepa);
                    blocItems.Items.Add(RenameWindow);
                } else if (sender.GetType() == typeof(PanelConsoleControl)) {
                    KryptonContextMenuItem RemoveConsole = new KryptonContextMenuItem();
                    RemoveConsole.Image = Properties.Resources.RemoveConsole;
                    RemoveConsole.Text = "Supprimer la console";

                    KryptonContextMenuSeparator sepa = new KryptonContextMenuSeparator();
                    sepa.StateNormal.Back.Color1 = Color.DarkGray;
                    sepa.StateNormal.Back.ColorStyle = PaletteColorStyle.Solid;

                    KryptonContextMenuItem RenameConsole = new KryptonContextMenuItem();
                    RenameConsole.Image = Properties.Resources.Rename;
                    RenameConsole.Text = "Renommer la console";
                    RenameConsole.Click += (s, ev) => {

                        string val = KryptonInputBox.Show(InputBoxdatas);
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

                menuRightClicWindow.Show(MainPage, MousePosition);
            }
        }


        private void selectWindow(PanelWindowControl panel) {
            int id = panel.id;
            activeWindow = windows[id];
            Plots = new List<PlotWindows>();
            MainPage.Controls.Clear();
            foreach(List<int> dp in DataFromPlot.Values) {
                dp.Clear();
            }


            foreach (PlotWindow wp in activeWindow.plots) {

                PlotWindows Plot = new PlotWindows(wp.plotName);
                Plot.RightClicOnPlott += PlotRightClic;
                Plot.NewVariableToPlott += PlotNewVariable;
                Plot.AquisitionActive = SerialConn.IsOpen;
                
                foreach(int dp in wp.dataPloted) {
                    DataFromPlot[dp].Add(wp.plotId);
                }

                Plots.Add(Plot);
                MainPage.Controls.Add(Plot);
                RearrangePlot();
            }
        }
    }
}
