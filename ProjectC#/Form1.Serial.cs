using System;
using System.Drawing;
using System.IO.Ports;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ProjectC_ 
{
    public partial class Form1 {

        int[] speed = { 3600, 9600, 19200, 38400, 56000, 57600, 76800, 115200, 460800, 921600 };
        string SerialComChoosed = "";
        int SerialSpeedChoosed = 0;
        SerialDataReceivedEventHandler SerialHander;

        private void SerialExpand_Click(object sender, EventArgs e) {
            MenuSerialPort.Items.Clear();
            string[] array = SerialPort.GetPortNames();
            int height = array.Length <= 6 ? array.Length : 6;
            MenuSerialPort.MinimumSize = new Size(SerialSelectorMargin.Width, 0);
            MenuSerialPort.ForeColor = Color.DarkGray;

            foreach (string port in array) {
                ToolStripItem item = MenuSerialPort.Items.Add(port, null, (s, ea) => {
                    SerialText.Text = port;
                    SerialComChoosed = port;
                });
                item.AutoSize = false;
                item.Width = SerialSelectorMargin.Width;
            }
            MenuSerialPort.Show(SerialSelectorMargin, new Point(0, SerialExpand.Height));
        }

        private void BaudExpand_Click(object sender, EventArgs e) {
            MenuSpeed.Items.Clear();

            int height = speed.Length <= 6 ? speed.Length : 6;
            MenuSpeed.MinimumSize = new Size(BaudSelectorMargin.Width, 0);
            MenuSpeed.ForeColor = Color.DarkGray;

            foreach (int sped in speed) {
                ToolStripItem item = MenuSpeed.Items.Add(sped.ToString(), null, (s, ea) => {
                    BaudText.Text = sped.ToString();
                    SerialSpeedChoosed = sped;
                });
                item.AutoSize = false;
                item.Width = BaudSelectorMargin.Width;
            }
            MenuSpeed.Show(BaudSelectorMargin, new Point(0, BaudExpand.Height));
        }

        private void ButtonConnect_Click(object sender, EventArgs e) {
            if (!SerialConn.IsOpen) {
                try {

                    SerialConn.PortName = SerialComChoosed;
                    SerialConn.BaudRate = SerialSpeedChoosed;

                    SerialConn.Parity = Parity.None;
                    SerialConn.DataBits = 8;
                    SerialConn.StopBits = StopBits.One;
                    SerialConn.Handshake = Handshake.None;

                    SerialConn.DataReceived += SerialHander;

                    SerialConn.Open();

                    ButtonConnect.Text = "Deconnexion";
                    ButtonConnect.BackColor = Color.FromArgb(200, 50, 50); // Rouge
                } catch (Exception ex) {
                    MessageBox.Show("Erreur de connexion : " + ex.Message);
                    SerialConn.DataReceived -= SerialHander;
                }
            } else {
                SerialConn.DataReceived -= SerialHander;

                System.Threading.Thread.Sleep(50);

                SerialConn.DiscardInBuffer();
                SerialConn.Close();
                ButtonConnect.Text = "Connexion";
                ButtonConnect.BackColor = Color.DarkGreen;
            }
        }

        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e) {
            if (!SerialConn.IsOpen) return;

            try {
                string data = SerialConn.ReadLine();

                // On vérifie que la com n'est pas fermé ou en cours de fermeture
                if (!this.IsDisposed && !this.Disposing) {
                    this.Invoke(new MethodInvoker(delegate {

                    }));
                }
            } catch {
                //Potentielle erreurs
            }

        }
    }
}