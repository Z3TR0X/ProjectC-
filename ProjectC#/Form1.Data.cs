using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace ProjectC_ {
    public partial class Form1 {
        List<List<float>> Datas = new List<List<float>>();
        List<String> DatasName = new List<string>();
        List<Color> DatasColor = new List<Color>();
        List<PanelVarControl> DatasPanels = new List<PanelVarControl>();
        Point PanelVarRightClickPos;


        private void OnPanelVarRightClic(object sender, MouseEventArgs e) {
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


            PanelVarControl v = (PanelVarControl)FlowVarPanel.Controls[id];
            v.setVarName(newName);
        }
        
        public void ChangeVarColor(int id, Color color) {
            DatasColor[id] = color;

            PanelVarControl v = (PanelVarControl)FlowVarPanel.Controls[id];
            v.setColor(color);
        }

        private void AddNewData() {
            String DefaultName = "Data" + (Datas.Count + 1).ToString();
            Datas.Add(new List<float>());
            DatasColor.Add(Color.CadetBlue);
            DatasName.Add(DefaultName);

            PanelVarControl v = new PanelVarControl();
            v.setColor(Color.CadetBlue);
            v.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnPanelVarRightClic);
            v.Init(DefaultName, Datas.Count, FlowVarPanel.ClientSize.Width);
            FlowVarPanel.Controls.Add(v);
        }
    }
}
