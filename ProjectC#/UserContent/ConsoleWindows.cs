using System;
using System.Drawing;
using System.Windows.Forms;

namespace ProjectC_.UserContent {
    public partial class ConsoleWindow : UserControl{
        public int id;
        private bool forceBottom = true; //Si le défilement automatique est désactivé
        private bool isTimestampActive = false;

        public ConsoleWindow(int _id) {
            InitializeComponent();
            id = _id;
            this.Padding = new Padding(5,0,0,0);

            foreach (Control control in this.Controls) {
                if (control is Krypton.Toolkit.KryptonButton btn) {
                    btn.OverrideDefault.Back.Color1 = btn.StateCommon.Back.Color1;
                    btn.OverrideDefault.Back.ColorStyle = btn.StateCommon.Back.ColorStyle;

                    btn.OverrideDefault.Border.Color1 = btn.StateCommon.Border.Color1;
                    btn.OverrideDefault.Border.ColorStyle = btn.StateCommon.Border.ColorStyle;
                }
            }
        }

        private void ConsoleWindow_SizeChanged(object sender, EventArgs e) {
            int w = this.Width;
            ClearButton.Location = new Point(w-5-28, 3);
            ClearButton.Size = new Size(28, 28);
            ClearButton.OverrideDefault.Back.Color1 = ClearButton.StateCommon.Back.Color1;
            ClearButton.OverrideDefault.Back.ColorStyle = ClearButton.StateCommon.Back.ColorStyle;
            ClearButton.OverrideDefault.Border.Color1 = ClearButton.StateCommon.Border.Color1;
            ClearButton.OverrideDefault.Border.ColorStyle = ClearButton.StateCommon.Border.ColorStyle;

            TimeButton.Location = new Point(w - 5 - 2*28-5, 3);
            TimeButton.Size = new Size(28, 28);
            TimeButton.OverrideDefault.Back.Color1 = TimeButton.StateCommon.Back.Color1;
            TimeButton.OverrideDefault.Back.ColorStyle = TimeButton.StateCommon.Back.ColorStyle;
            TimeButton.OverrideDefault.Border.Color1 = TimeButton.StateCommon.Border.Color1;
            TimeButton.OverrideDefault.Border.ColorStyle = TimeButton.StateCommon.Border.ColorStyle;

            ScrollButton.Location = new Point(w - 5 - 3 * 28 - 5*2, 3);
            ScrollButton.Size = new Size(28, 28);
            ScrollButton.OverrideDefault.Back.Color1 = ScrollButton.StateCommon.Back.Color1;
            ScrollButton.OverrideDefault.Back.ColorStyle = ScrollButton.StateCommon.Back.ColorStyle;
            ScrollButton.OverrideDefault.Border.Color1 = ScrollButton.StateCommon.Border.Color1;
            ScrollButton.OverrideDefault.Border.ColorStyle = ScrollButton.StateCommon.Border.ColorStyle;
            TopPanel.Height = 34;

            ConsoleName.Location = new Point(1, 5);
        }
    

        public void setName(string name) {
            ConsoleName.Text = name;
        }

        public void addData(string data) {
            string line = "";
            if (isTimestampActive) line += DateTime.Now.ToString("[HH:mm:ss] ");
            line += data;

            LogPanel.AppendText(line + "\n");
            
            if(forceBottom) LogPanel.ScrollToCaret();
        }

        private void ScrollButton_Click(object sender, EventArgs e) {
            if (forceBottom) {
                ScrollButton.Values.Image = Properties.Resources.FreeScroll;
            }else {
                ScrollButton.Values.Image = Properties.Resources.AllowScroll;
            }

            forceBottom = !forceBottom;
        }

        private void ClearButton_Click(object sender, EventArgs e) {
            LogPanel.Clear();
        }

        private void TimeButton_Click(object sender, EventArgs e) {
            if (isTimestampActive) {
                TimeButton.Values.Image = Properties.Resources.StopTime;
            } else {
                TimeButton.Values.Image = Properties.Resources.AddTime;
            }

            isTimestampActive = !isTimestampActive;
        }
    }
}


