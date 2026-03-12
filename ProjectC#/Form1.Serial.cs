using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO.Ports;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectC_ 
{
    public partial class Form1 {

        int[] speed = { 3600, 9600, 19200, 38400, 56000, 57600, 76800, 115200, 460800, 921600 };
        string SerialComChoosed = "";
        int SerialSpeedChoosed = 0;
        SerialDataReceivedEventHandler SerialHander;


        List<List<float>> Datas = new List<List<float>>();
        List<String> DatasName = new List<string>();
        List<Color> DatasColor = new List<Color>();
        List<PanelVarControl> DatasPanels = new List<PanelVarControl>();

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

                    DataPanelTimer.Start();

                    SerialConn.Open();

                    OptionPanel.BringToFront();
                    OptionPanel.Enabled = true;
                    ComPanel.Enabled = false;
                } catch (Exception ex) {
                    MessageBox.Show("Erreur de connexion : " + ex.Message);
                    SerialConn.DataReceived -= SerialHander;
                }
            }

            
        }

        private void DeconnectButton_Click(object sender, EventArgs e) {
            if (SerialConn.IsOpen) {
                Task.Run(() => {
                    try {
                        SerialConn.DataReceived -= SerialHander;
                        SerialConn.DiscardInBuffer();
                        DataPanelTimer.Stop();
                        SerialConn.Close();
                    } catch (Exception ex) {
                        Console.WriteLine("Erreur à la fermeture : " + ex.Message);
                    }
                });

                //MessageBox.Show(Datas[0].Count.ToString());

            }

            ComPanel.BringToFront();
            ComPanel.Enabled = true;
            OptionPanel.Enabled = false;
        }

        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e) {
            if (!SerialConn.IsOpen) return;
               try {
                    string data = SerialConn.ReadLine();

                    // On vérifie que la com n'est pas fermé ou en cours de fermeture
                    if (!this.IsDisposed && !this.Disposing) {
                        this.Invoke(new MethodInvoker(delegate {
                            //On choisit pas defaut le ; pour séparer les variables
                            string[] values = data.Split(';');


                            //Etre sur que chaque data reçue puisse bien aller dans une variables à plott
                            while (values.Length > Datas.Count) {
                                AddNewData();
                            }

                            for (int i = 0; i < values.Length; i++) {
                                float val = float.Parse(values[i], CultureInfo.InvariantCulture.NumberFormat);
                                Datas[i].Add(val);
                            }
                        }));
                    }
                } catch {
                    //On peut gerer les erreurs ici si yen a.
                }


            

        }

        private void AddNewData() {
            String DefaultName = "Data" + (Datas.Count + 1).ToString();
            Datas.Add(new List<float>());
            DatasColor.Add(Color.CadetBlue);
            DatasName.Add(DefaultName);

            PanelVarControl v = new PanelVarControl();
            v.setColor(Color.CadetBlue);
            v.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MainPage_MouseUp);
            v.Init(DefaultName, Datas.Count, FlowVarPanel.ClientSize.Width);
            FlowVarPanel.Controls.Add(v);
        }

        Point PanelVarRightClickPos;
        private void MainPage_MouseUp(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Right) {
                PanelVarControl panel = (PanelVarControl)sender;
                int id = panel.getCurrentValue() - 1;

                menu.setDataId(id);
                menu.setColor(DatasColor[id]);
                menu.setName(DatasName[id]);
                PanelVarRightClickPos = Cursor.Position;
                menuClicDroit.Show(PanelVarRightClickPos);

            }
        }

        public void ChangeVarName(int id, string newName) {
            DatasName[id] = newName;


            PanelVarControl v = (PanelVarControl) FlowVarPanel.Controls[id];
            v.setVarName(newName);
        }
        public void ChangeVarColor(int id, Color color) { 
            DatasColor[id] = color;

            PanelVarControl v = (PanelVarControl)FlowVarPanel.Controls[id];
            v.setColor(color);
        }
    }        
}