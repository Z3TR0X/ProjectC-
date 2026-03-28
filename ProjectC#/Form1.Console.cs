using ProjectC_.UserContent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectC_ {
    public partial class Form1 : Form {
        private List<(ConsoleWindow, PanelConsoleControl)> consoles = new List<(ConsoleWindow, PanelConsoleControl)>();
        private (ConsoleWindow, PanelConsoleControl) activeConsole = (null, null);

        private void CreateNewConsole() {
            ConsoleWindow cons = new ConsoleWindow(consoles.Count);
            cons.Dock = DockStyle.Right;
            cons.Padding = new Padding(1, 0, 0, 0);
            cons.Width = 300;
            cons.setName("Console " + (consoles.Count + 1).ToString());

            PanelConsoleControl panel = new PanelConsoleControl();
            panel.MouseClick += OnClicWindowEvent;
            panel.Init(FlowLayoutWindow.ClientSize.Width, consoles.Count);
            panel.setName("Console " + (consoles.Count + 1).ToString());
            FlowLayoutWindow.Controls.Add(panel);

            consoles.Add((cons, panel));
        }

        private void DeleteConsole(int consoleId) {
            if (consoles[consoleId] == activeConsole) {
                MainPage.Controls.Remove(activeConsole.Item1);
                activeConsole = (null, null);
                RearrangePlot();
            }

            FlowLayoutWindow.Controls.Remove(consoles[consoleId].Item2);
            consoles.RemoveAt(consoleId);
        }

        private void SelectConsole(int index) {
            if (activeConsole.Item1 != null && activeConsole.Item1.id == index) {
                MainPage.Controls.Remove(activeConsole.Item1);
                activeConsole.Item2.setSelected(false);
                activeConsole = (null, null);
                RearrangePlot();
            } else {
                if (activeConsole.Item1 != null) {
                    MainPage.Controls.Remove(activeConsole.Item1);
                    activeConsole.Item2.setSelected(false);
                }
                activeConsole = consoles[index];
                activeConsole.Item2.setSelected(true);
                MainPage.Controls.Add(activeConsole.Item1);
                RearrangePlot();
            }
        }
    }
}
