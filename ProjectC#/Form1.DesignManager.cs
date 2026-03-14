using Krypton.Toolkit;
using System;
using System.Drawing;
using System.IO.Ports;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectC_ {
    public partial class Form1 {
        Size last_normal_form_size;
        Point last_normal_form_position;
        float leftMenuRatio = 0.5f;


        //Fonction pour mettre les bords ronds
        protected override void OnHandleCreated(EventArgs e) {
            base.OnHandleCreated(e);
            int preference = 2;
            DwmSetWindowAttribute(this.Handle, 33, ref preference, sizeof(int));
        }

        //Fonction pour resize la fenètre si la souris est dans un coin
        protected override void WndProc(ref Message m) {

            if (m.Msg == 0x84) {
                Point clientPoint = this.PointToClient(Cursor.Position);

                int tolerance = 100; //Zone dans laquelle le curseur est compté comme étant sur le bord.

                /*
                 10	Bord gauche
                 11	Bord droit
                 12	Bord haut
                 14	Coin haut-droit
                 15	Bord bas
                 16	Coin bas-gauche
                 17	Coin bas-droit
                 */

                // Haut Gauche
                if (clientPoint.X <= tolerance && clientPoint.Y <= tolerance) { m.Result = (IntPtr)13; return; }

                // Haut Droit
                if (clientPoint.X >= this.Size.Width - tolerance && clientPoint.Y <= tolerance) { m.Result = (IntPtr)14; return; }

                // Bas Gauche
                if (clientPoint.X <= tolerance && clientPoint.Y >= this.Size.Height - tolerance) { m.Result = (IntPtr)16; return; }

                // Bas Droit
                if (clientPoint.X >= this.Size.Width - tolerance && clientPoint.Y >= this.Size.Height - tolerance) { m.Result = (IntPtr)17; return; }

                // Bord Gauche
                if (clientPoint.X <= tolerance) { m.Result = (IntPtr)10; return; }

                // Bord Droit
                if (clientPoint.X >= this.Size.Width - tolerance) { m.Result = (IntPtr)11; return; }

                // Bord Haut
                if (clientPoint.Y <= tolerance) { m.Result = (IntPtr)12; return; }

                // Bord Bas
                if (clientPoint.Y >= this.Size.Height - tolerance) { m.Result = (IntPtr)15; return; }
            }
            const int WM_SYSCOMMAND = 0x0112;
            const int SC_RESTORE = 0xF120;

            if (m.Msg == WM_SYSCOMMAND && (int)m.WParam == SC_RESTORE) {
                Force_Drawing();
            }

            base.WndProc(ref m);
        }

        private bool isClosing = false;
        private async void button_close_Click(object sender, EventArgs e) {

            DataPanelTimer.Tick -= UpdateDatasPanels;

            DataPanelTimer.Stop();
            DataPanelTimer.Dispose();

            isClosing = true;

            if (SerialConn.IsOpen) {
                await Task.Run(() => {
                    try {
                        SerialConn.DataReceived -= SerialHander;
                        SerialConn.DiscardInBuffer();
                        SerialConn.Close();
                    } catch (Exception ex) {
                        Console.WriteLine("Erreur à la fermeture : " + ex.Message);
                    }
                });

            }
            this.Close();
        }

        private void button_maximize_Click(object sender, EventArgs e) {
            if (this.WindowState == FormWindowState.Normal)
            {
                button_maximize.Image = Properties.Resources.Restore_white;
                int preference = 1;
                DwmSetWindowAttribute(this.Handle, 33, ref preference, sizeof(int));
                this.Padding = new Padding(0);
                this.MaximizedBounds = Screen.FromControl(this).WorkingArea;
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                button_maximize.Image = Properties.Resources.Maximize_White;
                int preference = 2;
                DwmSetWindowAttribute(this.Handle, 33, ref preference, sizeof(int));
                this.Padding = new Padding(1);
                this.WindowState = FormWindowState.Normal;
            }

            this.Invalidate();
            this.Update();
        }

        private void Form1_SizeChanged(object sender, EventArgs e) {
            int header_height = 34;
            int header_width = this.Size.Width;
            TopBar.Size = new Size(header_width, header_height);


            LeftBar.Size = new Size(1, MainPage.Size.Height);

            MenuPanel.Size = new Size(MenuPanel.Size.Width, MainPage.Size.Height - ComPanel.Height);

            int MenuLocY = (int)Math.Round(MenuPanel.Height * leftMenuRatio);
            if (MenuLocY <= 100) {
                MenuLocY = 100;
            }
            MenuSeparator.Location = new Point(0, MenuLocY);
            VarPanel.Size = new Size(VarPanel.Width, MenuLocY);
            PagePanel.Size = new Size(PagePanel.Width, MenuPanel.Height - MenuLocY - 5);


            TopBar.Refresh();
        }

        private void button_minimize_Click(object sender, EventArgs e) {
            this.WindowState = FormWindowState.Minimized;
        }

        private void DragTopBar(object sender, MouseEventArgs e) {
            if (this.Size == Screen.FromControl(this).WorkingArea.Size) {
                int preference = 2;
                DwmSetWindowAttribute(this.Handle, 33, ref preference, sizeof(int));

                this.Size = last_normal_form_size;
                double ratio = (double)e.X / (double)Screen.GetWorkingArea(this).Size.Width;
                Point cursorPoint = Cursor.Position;
                int newX = cursorPoint.X - (int)(this.Width * ratio);
                int newY = cursorPoint.Y - e.Y;

                this.Location = new Point(newX, newY);
                this.Padding = new Padding(1, 1, 1, 1);

                button_maximize.Image = Properties.Resources.Maximize_White;
            }

            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }


        //Fonction pour forcer la fênetre à se redessiner
        private void Force_Drawing() {
            this.BeginInvoke(new Action(() => {
                this.Refresh();
            }));
        }

    }
}

public class CustomSelectionRenderer : ToolStripProfessionalRenderer {
    //Permet de changer l'apparence de la custom combo box quand on clique sur expand

    protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e) {
        if (e.Item.Selected) {

            Rectangle rect = new Rectangle(2, 1, e.ToolStrip.ClientRectangle.Width - 4, e.Item.Height - 2);

            using (SolidBrush brush = new SolidBrush(Color.FromArgb(50, 120, 220))) {
                e.Graphics.FillRectangle(brush, rect);
            }
        } else {
            // Si l'item n'est pas sélectionné, on laisse le comportement normal (fond transparent)
            base.OnRenderMenuItemBackground(e);
        }
    }
}