using ProjectC_.UserContent;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        bool pauseSerial;


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
                    pauseSerial = false;

                    foreach (PlotWindows plot in Plots) {
                        plot.AquisitionActive = true;
                    }
                    refreshPlotTick.Start();


                    millis.Start();
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
                        millis.Stop();
                        refreshPlotTick.Stop();

                        foreach(PlotWindows plot in Plots) {
                            plot.AquisitionActive = false;
                        }
                    } catch (Exception ex) {
                        Console.WriteLine("Erreur à la fermeture : " + ex.Message);
                    }
                });


            }

            ComPanel.BringToFront();
            ComPanel.Enabled = true;
            OptionPanel.Enabled = false;
        }

        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e) {
            if (!SerialConn.IsOpen) return;
               try {
                    //Permet de vider le buffer du serial -> ligne necessaire meme si on fait rien avec les données
                    string data = SerialConn.ReadLine().Trim();

                    if (pauseSerial) return;

                    // On vérifie que la com n'est pas fermé ou en cours de fermeture
                    if (!this.IsDisposed && !this.Disposing) {
                        this.Invoke(new MethodInvoker(delegate {
                            //On choisit pas defaut le ; pour séparer les variables
                            string[] values = data.Split(';');


                            //Etre sur que chaque data reçue puisse bien aller dans une variables à plott
                            while (values.Length > Datas.Count) {
                                AddNewDatas();
                            }

                            double timer = millis.ElapsedMilliseconds/1000.0;
                            timeY.Add(timer);

                            for (int i = 0; i < values.Length; i++) {
                                float val = float.Parse(values[i], CultureInfo.InvariantCulture.NumberFormat);
                                Datas[i].Add(val);

                                foreach (int plotNb in DataFromPlot[i]) {

                                    Plots[plotNb].AddDataToPlott(i+1, timer, val);
                                }
                            }

                        }));
                    }
                } catch {
                    //On peut gerer les erreurs ici si yen a.
                }


            

        }

        private void PausContButton_Click(object sender, EventArgs e) {
            if (pauseSerial) {
                PausContButton.StateCommon.Back.Color1 = Color.FromArgb(166, 88, 0);
                PausContButton.StateTracking.Back.Color1 = Color.FromArgb(194, 104, 2);
                PausContButton.StatePressed.Back.Color1 = Color.FromArgb(220, 120, 4);
                PausContButton.OverrideDefault.Back.Color1 = Color.FromArgb(166, 88, 0);
                PausContButton.Values.Text = "Pause";

                DataPanelTimer.Start();

                foreach (PlotWindows plot in Plots) {
                    plot.AquisitionActive = true;
                }

                refreshPlotTick.Start();


                millis.Start();

                pauseSerial = false;
            } else {
                PausContButton.StateCommon.Back.Color1 = Color.DarkGreen;
                PausContButton.StateTracking.Back.Color1 = Color.FromArgb(0, 120, 0);
                PausContButton.StatePressed.Back.Color1 = Color.FromArgb(0, 140, 0);
                PausContButton.OverrideDefault.Back.Color1 = Color.DarkGreen;
                PausContButton.Values.Text = "Lancer";

                DataPanelTimer.Stop();
                millis.Stop();
                refreshPlotTick.Stop();

                foreach (PlotWindows plot in Plots) {
                    plot.AquisitionActive = false;
                }

                pauseSerial = true;
            }
        }
    }        
}
