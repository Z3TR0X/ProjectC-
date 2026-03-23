using Krypton.Toolkit;
using ProjectC_.UserContent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;



namespace ProjectC_ {
    public partial class Form1 : Form {
        private KryptonContextMenu menuRightClicWindow;

        private void CreateNewWindow() {
            PanelWindowControl panel = new PanelWindowControl();
            panel.MouseClick += OnRightClicWindowEvent;
            panel.Init(FlowLayoutWindow.ClientSize.Width);
            FlowLayoutWindow.Controls.Add(panel);
        }

        private void CreateNewConsole() {
            PanelConsoleControl panel = new PanelConsoleControl();
            panel.MouseClick += OnRightClicWindowEvent;
            panel.Init(FlowLayoutWindow.ClientSize.Width);
            FlowLayoutWindow.Controls.Add(panel);
        }


        KryptonInputBoxData InputBoxdatas = new Krypton.Toolkit.KryptonInputBoxData {
            Prompt = "Entrez le nouveau nom : ",
            Caption = "Renommer",
            DefaultResponse = "",

        };
        private void OnRightClicWindowEvent(object sender, MouseEventArgs e) {
            if (e.Button != MouseButtons.Right) return;

            menuRightClicWindow = new KryptonContextMenu();
            menuRightClicWindow.PaletteMode = Krypton.Toolkit.PaletteMode.Custom;
            menuRightClicWindow.LocalCustomPalette = CustomPalette;

            KryptonContextMenuItems blocItems = new KryptonContextMenuItems();

            KryptonContextMenuItem createWindow = new KryptonContextMenuItem();
            createWindow.Image = Properties.Resources.AddWindow;
            createWindow.Text = "Nouvelle fenêtre";

            KryptonContextMenuItem createConsole = new KryptonContextMenuItem();
            createConsole.Image = Properties.Resources.AddConsole;
            createConsole.Text = "Nouvelle console";

            if(sender.GetType() == typeof(PanelWindowControl)) {
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
            } else if(sender.GetType() == typeof(PanelConsoleControl)) {
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
}
