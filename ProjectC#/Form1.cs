using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ProjectC_ {

    public partial class Form1 : Form {

        Size last_normal_form_size;
        Point last_normal_form_position;
        bool IsPageResize = false;

        //Fonction pour ajouter l'ombre autour de la fenêtre
        protected override CreateParams CreateParams {
            get {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= 0x20000; // Ombre portée
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        [DllImport("dwmapi.dll")]
        private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

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

            base.WndProc(ref m);
        }

        public Form1() {
            InitializeComponent();
            PageSeparator.Enabled = false; //Permet de désactiver les évents de PageSeparator
        }

        private void button_close_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void button_maximize_Click(object sender, EventArgs e) {
            Size screen_size = Screen.FromControl(this).WorkingArea.Size;
            if (this.Size != screen_size) {
                int preference = 0;
                DwmSetWindowAttribute(this.Handle, 33, ref preference, sizeof(int));

                last_normal_form_size = this.Size;
                last_normal_form_position = this.Location;
                this.Size = Screen.FromControl(this).WorkingArea.Size;
                this.Location = new Point(0, 0);
                this.Padding = new Padding(0, 0, 0, 0);
                button_maximize.Image = Properties.Resources.Restore_white;

            } else {
                int preference = 2;
                DwmSetWindowAttribute(this.Handle, 33, ref preference, sizeof(int));

                this.Size = last_normal_form_size;
                this.Location = last_normal_form_position;
                this.Padding = new Padding(1, 1, 1, 1);
                button_maximize.Image = Properties.Resources.Maximize_White;

            }

        }

        private void Form1_SizeChanged(object sender, EventArgs e) {
            int header_height = 34;
            int header_width = this.Size.Width;
            TopBar.Size = new Size(header_width, header_height);

            int height = PageSeparatorHitBox.Location.Y;
            TopPage.Size = new Size(0, height + 3);
            BotPage.Size = new Size(0, LeftPanel.Size.Height - height);
            
        }

        private void button_minimize_Click(object sender, EventArgs e) {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e) {
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

        private void PageSeparatorHitBox_MouseDown(object sender, MouseEventArgs e) {
            IsPageResize = true;
        }

        private void PageSeparatorHitBox_MouseUp(object sender, MouseEventArgs e) {
            IsPageResize = false;
        }

        private void PageSeparatorHitBox_MouseMove(object sender, MouseEventArgs e) {
            if (IsPageResize) {
                Point clientPoint = this.PointToClient(Cursor.Position);
                PageSeparatorHitBox.Location = new Point(0, clientPoint.Y-35);
                int height = PageSeparatorHitBox.Location.Y;
                TopPage.Size = new Size(0, height + 3);
                BotPage.Size = new Size(0, LeftPanel.Size.Height - height);
            }
        }
        
    }
}





