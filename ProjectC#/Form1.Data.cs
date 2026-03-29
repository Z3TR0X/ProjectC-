using DynamicExpresso;
using Krypton.Toolkit;
using NCalc;
using NCalc.Domain;
using ProjectC_.UserContent;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectC_ {
    public partial class Form1 {
        List<List<float>> Datas = new List<List<float>>();
        List<Double> timeY = new List<Double>();
        List<String> DatasName = new List<string>();
        List<Color> DatasColor = new List<Color>();
        List<bool> isDataCutomised = new List<bool>(); //liste qui permet de savoir si la data i est custom ou non
        List<String> expressions = new List<string>(); //liste qui repertorie d'expression des varaibles (les variables non custom ont une expression vide
        List<Lambda> functions = new List<Lambda>(); //liste qui contient les fonctions qui vont nous permettre de calculer les customs vars
        List<List<int>> datasParameters = new List<List<int>>(); //liste qui contient les id des datas dont on n'a besoin pour calculer la fonction
        //Par exemple si i est l'index de la data i, on change l'expression de la 3eme variable par data1 + data2, on aura datasParameters[2] = [1, 2];


        Point PanelVarRightClickPos;

        List<PanelVarControl> DatasPanels = new List<PanelVarControl>();
        List<PanelCustomVar> CustomsDatasPanels = new List<PanelCustomVar>();


        KryptonContextMenu menuData;
        private void FlowVarPanel_MouseDown(object sender, MouseEventArgs e) {
            if (e.Button != MouseButtons.Right) return;

            menuData.Show(Cursor.Position);
        }

        private void CreateMenuCustomData() {
            menuData = new KryptonContextMenu();

            menuData.PaletteMode = Krypton.Toolkit.PaletteMode.Custom;
            menuData.LocalCustomPalette = CustomPalette;

            KryptonContextMenuItems blocItems = new KryptonContextMenuItems();

            KryptonContextMenuItem addCustomData = new KryptonContextMenuItem();
            addCustomData.Image = Properties.Resources.AddCustomData;
            addCustomData.Text = "Ajouter une donnée personnalisée";
            addCustomData.Click += (s, ev) => {
                AddNewCustomData();
            };


            blocItems.Items.Add(addCustomData);

            menuData.Items.Add(blocItems);
        }

        private void AddNewCustomData() {
            String DefaultName = "Custom Data" + (Datas.Count + 1).ToString();
            Datas.Add(new List<float>());
            DatasColor.Add(Color.CadetBlue);
            DatasName.Add(DefaultName);
            DataFromPlot.Add(Datas.Count - 1, new List<int>());
            isDataCutomised.Add(true);
            expressions.Add("helooo");
            functions.Add(null);
            datasParameters.Add(null);


            PanelCustomVar v = new PanelCustomVar();
            v.setColor(Color.CadetBlue);
            v.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnPanelVarRightClic);
            //v.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DragAndDropStart);
            //v.GiveFeedback += DragFeedback;
            v.Init(DefaultName, Datas.Count, FlowVarPanel.ClientSize.Width);
            CustomsDatasPanels.Add(v);
            FlowVarPanel.Controls.Add(v);
        }

        private void OnPanelVarRightClic(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Right) {
                PanelVarMenu menuInfo = menuVar;
                ToolStripDropDown menu = menuClicDroit;

                PanelVarControl panel = (PanelVarControl)sender;
                int id = panel.getVarIdAssociated() - 1;

                if (sender.GetType() == typeof(PanelCustomVar)) {
                    menu = CustomMenuClicDroit;
                    MenuCustomVar.SetExpression(expressions[id]);
                    menuInfo = MenuCustomVar;

                }
                
                menuInfo.setDataId(id);
                menuInfo.setColor(DatasColor[id]);
                menuInfo.setName(DatasName[id]);
                PanelVarRightClickPos = Cursor.Position;
                menu.Show(PanelVarRightClickPos);
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

        public void ChangeExpression(int id, String exp) {
            string pattern = @"\b[a-zA-Z_][a-zA-Z0-9_]*\b(?!\s*\()"; //Partern créé par Gemini, il cherche un mot qui ne commencent pas par (

            var resultats = Regex.Matches(exp, pattern);

            List<string> varNames = resultats.Cast<Match>().Select(m => m.Value).Distinct().ToList(); // Permet d'obtenir la liste des variables que l'utilisateur à tapé dans l'expression
            List<int> varIndexes = new List<int>();

            bool isVarFind;
            foreach (string varName in varNames) {
                isVarFind = false;
                for (int i = 0; i < DatasName.Count; i++) {
                    if (varName == DatasName[i]) {
                        isVarFind = true;
                        varIndexes.Add(i);
                    }
                }
                if (!isVarFind) {
                    MessageBox.Show("Aucune variable ne porte\nle nom de : " + varName, "Erreur dans la formule", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if(varIndexes.Count != varNames.Count) {
                MessageBox.Show("Erreur", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            expressions[id] = exp;
            datasParameters[id] = varIndexes;

            Interpreter interpreter = new Interpreter();

            List<Parameter> parameters = new List<Parameter>();
            foreach(string varName in varNames) {
                parameters.Add(new Parameter(varName, typeof(float)));
            }

            functions[id] = interpreter.Parse(exp, parameters.ToArray());
        }

        private void AddNewData() {
            String DefaultName = "Data" + (Datas.Count + 1).ToString();
            Datas.Add(new List<float>());
            DatasColor.Add(Color.CadetBlue);
            DatasName.Add(DefaultName);
            DataFromPlot.Add(Datas.Count-1, new List<int>());
            isDataCutomised.Add(false);
            expressions.Add("");
            functions.Add(null);
            datasParameters.Add(null);


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
                DataInfos info = new DataInfos(DatasName[varId-1], DatasColor[varId-1], varId-1);

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

        private void ExportToCSV(object sender, EventArgs e) {
            if(SerialConn.IsOpen && !pauseSerial) {
                MessageBox.Show("Pour exporter les données,\nveuillez vous deconnecter\nou mettre en pause l'aquisition", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog FileDialog = new SaveFileDialog();
            FileDialog.Filter = "Fichier Excel CSV (*.csv)|*.csv";
            FileDialog.Title = "Exporter les données";
            FileDialog.FileName = "Export_Serial.csv";

            if(FileDialog.ShowDialog() == DialogResult.OK) {
                try {
                    using (StreamWriter file = new StreamWriter(FileDialog.FileName)) {
                        string line = "";

                        line += "time;";
                        line += string.Join(";", DatasName);

                        file.WriteLine(line);

                        List<string> vars = new List<string>();
                        for (int i = 0; i < Datas[0].Count; i++) {
                            vars.Clear();
                            vars.Add(timeY[i].ToString());
                            foreach (List<float> d in Datas) {
                                vars.Add(d[i].ToString());
                            }
                            line = string.Join(";", vars);
                            file.WriteLine(line);
                        }
                    }

                    MessageBox.Show("Exportation terminée !", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                } catch (Exception) {
                    MessageBox.Show("Oups, il y a eu un problème pendant l'exportation", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
