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

namespace ProjectC_
{
    public partial class Form1 : Form
    {

        Size last_normal_form_size;
        Point last_normal_form_position;

        //Fonction pour ajouter l'ombre autour de la fenêtre
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= 0x20000; // Ombre portée
                return cp;
            }
        }

        [DllImport("dwmapi.dll")]
        private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            int preference = 2;
            DwmSetWindowAttribute(this.Handle, 33, ref preference, sizeof(int));
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == 0x84)
            {
                Point screenPoint = new Point(m.LParam.ToInt32());
                Point clientPoint = this.PointToClient(screenPoint);

                //Si la souris est dans le coin inférieur gauche dans une zone de 16 pixels (pour la marge)
                if (clientPoint.X >= this.Size.Width - 20 && clientPoint.Y >= this.Size.Height - 20)
                {
                    m.Result = (IntPtr)17;
                    return;
                }
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void button_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_maximize_Click(object sender, EventArgs e)
        {
            Size screen_size = Screen.FromControl(this).WorkingArea.Size;
            if (this.Size != screen_size)
            {
                int preference = 0;
                DwmSetWindowAttribute(this.Handle, 33, ref preference, sizeof(int));

                last_normal_form_size = this.Size;
                last_normal_form_position = this.Location;
                this.Size = Screen.FromControl(this).WorkingArea.Size;
                this.Location = new Point(0, 0);
                button_maximize.Image = Properties.Resources.Restore_white;
                
            }
            else
            {
                int preference = 2;
                DwmSetWindowAttribute(this.Handle, 33, ref preference, sizeof(int));

                this.Size = last_normal_form_size;
                this.Location = last_normal_form_position;
                button_maximize.Image = Properties.Resources.Maximize_White;
                
            }

        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            int header_height = 34;
            int header_width = this.Size.Width;
            Size button_size = new Size(34, header_height);
            TopBar.Size = new Size(header_width, header_height);
            button_close.Size = button_size;
            button_maximize.Size = button_size;
            button_minimize.Size = button_size;
            logo.Size = new Size(34,34);
        }

        private void button_minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.Size == Screen.FromControl(this).WorkingArea.Size)
            {
                int preference = 2;
                DwmSetWindowAttribute(this.Handle, 33, ref preference, sizeof(int));

                this.Size = last_normal_form_size;
                double ratio = (double)e.X / (double)Screen.GetWorkingArea(this).Size.Width;
                Point cursorPoint = Cursor.Position;
                int newX = cursorPoint.X - (int)(this.Width * ratio);
                int newY = cursorPoint.Y - e.Y;

                this.Location = new Point(newX, newY);

                button_maximize.Image = Properties.Resources.Maximize_White;
            }
            
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            this.Size = last_normal_form_size;
            this.Location = last_normal_form_position;
            button_maximize.Image = Properties.Resources.Maximize_White;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}



