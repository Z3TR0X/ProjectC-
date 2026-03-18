using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using ProjectC_.UserContent;

namespace ProjectC_ {
    public partial class Form1 {
        List<List<float>> Datas = new List<List<float>>();
        List<Double> timeY = new List<Double>();
        List<String> DatasName = new List<string>();
        List<Color> DatasColor = new List<Color>();
        List<PanelVarControl> DatasPanels = new List<PanelVarControl>();
        Point PanelVarRightClickPos;


        private void OnPanelVarRightClic(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Right) {
                PanelVarControl panel = (PanelVarControl)sender;
                int id = panel.getVarIdAssociated() - 1;

                menuVar.setDataId(id);
                menuVar.setColor(DatasColor[id]);
                menuVar.setName(DatasName[id]);
                PanelVarRightClickPos = Cursor.Position;
                menuClicDroit.Show(PanelVarRightClickPos);

            }
        }

        public void ChangeVarName(int id, string newName) {
            DatasName[id] = newName;
            
            foreach(int plotNb in DataFromPlot[id]) {
                DataInfos info = new DataInfos(newName, DatasColor[id], id+1);
                Plots[plotNb].UpdateDataInfo(info);
            }


            PanelVarControl v = (PanelVarControl)FlowVarPanel.Controls[id];
            v.setVarName(newName);
        }
        
        public void ChangeVarColor(int id, Color color) {
            DatasColor[id] = color;

            foreach (int plotNb in DataFromPlot[id]) {
                DataInfos info = new DataInfos(DatasName[id], color, id + 1);
                Plots[plotNb].UpdateDataInfo(info);
            }

            PanelVarControl v = (PanelVarControl)FlowVarPanel.Controls[id];
            v.setColor(color);
        }


        private void AddNewData() {
            String DefaultName = "Data" + (Datas.Count + 1).ToString();
            Datas.Add(new List<float>());
            DatasColor.Add(Color.CadetBlue);
            DatasName.Add(DefaultName);
            DataFromPlot.Add(Datas.Count-1, new List<int>());

            PanelVarControl v = new PanelVarControl();
            v.setColor(Color.CadetBlue);
            v.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnPanelVarRightClic);
            v.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DragAndDropStart);
            v.GiveFeedback += DragFeedback;
            v.Init(DefaultName, Datas.Count, FlowVarPanel.ClientSize.Width);
            FlowVarPanel.Controls.Add(v);
        }

        private void DragAndDropStart(object sender, MouseEventArgs e) {
            if(e.Button == MouseButtons.Left) {
                PanelVarControl panel = sender as PanelVarControl;

                DragCursor = CreateDragCursor(panel.getVarName());

                int varId = panel.getVarIdAssociated();
                DataInfos info = new DataInfos(DatasName[varId-1], DatasColor[varId-1], varId);

                panel.DoDragDrop(info, DragDropEffects.Copy);

                IntPtr hicon = panel.Handle; //Permet de recup le pointeur vers le curseur
                DragCursor = null;
                DestroyIcon(hicon);
            }
        }

        private void DragFeedback(object sender, GiveFeedbackEventArgs e) {
            e.UseDefaultCursors = false;

            if (DragCursor != null) {
                Cursor.Current = DragCursor;
            } else {
                Cursor.Current = Cursors.No;
            }
        }

    }
}
