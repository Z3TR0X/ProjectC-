using ScottPlot;
using ScottPlot.Plottables;
using ScottPlot.WinForms;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectC_.UserContent {
    public partial class PlotWindows : UserControl, IRenderAction {

        public event EventHandler<EventArgs> NewVariableToPlott;

        String FigureTitle;
        //Chaque variable à son propre Data Logger et le data logger loggers[i] correspond a la variable varId[i]
        private Dictionary<int, DataLogger> loggers = new Dictionary<int, DataLogger>();
        private Dictionary<int, ScottPlot.LegendItem> legends = new Dictionary<int, LegendItem>();

        private bool dataReceive;

        //Variable qui indique si on va recevoir des données ou non. Si elle est a true c'est que la form recoit des données dans le 
        //Port série et donc que l'on est susceptible d'en recevoir aussi. 
        //!!! si elle est a vrai ça ne veut pas dire qu'on recoit FORCEMENT des données, si le plot n'est abonné a aucune variable, alors on ne recoit rien.
        public bool AquisitionActive; 

        public PlotWindows(String title) {
            InitializeComponent();
            Plot.Menu?.Clear();

            FigureTitle = title;


            ApplyDesignToPlot(Plot.Plot);
            Plot.Plot.RenderManager.RenderActions.Add(this);

            timerEndResize.Interval = 200;
            timerEndResize.Tick += TickEndResize;
            timerEndResize.Start(); //POur que les rectangles soient dessiné une première fois


            Plot.Refresh();

            this.Disposed += Destructor;
        }


        private void Destructor(object sender, EventArgs e) {
            //Permet de liberer de la mémoire le timer à la destuction du UserContent
            if(timerEndResize != null) {
                timerEndResize.Stop();
                timerEndResize.Tick -= TickEndResize;

                timerEndResize.Dispose();
            }

            styloJaune.Dispose();
        }

        public void AddDataToPlott(int varId, double x, double y) {
            Debug.WriteLine("coucou");
            if (!loggers.ContainsKey(varId)) return;
            loggers[varId].Add(x, y);
        }

        private void Plot_DragDrop(object sender, DragEventArgs e) {
            DataInfos var = (DataInfos) e.Data.GetData(typeof(DataInfos));        

            if (loggers.ContainsKey(var.varIndex)) return;


            DataLogger logger = Plot.Plot.Add.DataLogger();
            logger.ManageAxisLimits = false;
            logger.Color = ScottPlot.Color.FromColor(var.color);

            legends.Add(var.varIndex, new LegendItem());
            legends[var.varIndex].MarkerColor = ScottPlot.Color.FromColor(var.color);
            legends[var.varIndex].MarkerShape = ScottPlot.MarkerShape.FilledSquare;
            legends[var.varIndex].MarkerSize = 15;
            legends[var.varIndex].LineWidth = 0;
            legends[var.varIndex].LabelText = var.name;

            Plot.Plot.Legend.ManualItems.Add(legends[var.varIndex]);
            

            Point posCursor = Plot.PointToClient(new Point(e.X, e.Y));
            if (rects[3].Contains(posCursor.X, posCursor.Y)) {
                //Zone du bas
            } else if (rects[2].Contains(posCursor.X, posCursor.Y)) {
                //Zone Droite
                logger.Axes.YAxis = Plot.Plot.Axes.Right;
            } else if (rects[1].Contains(posCursor.X, posCursor.Y)) {
                //Zone Gauche
                logger.Axes.YAxis = Plot.Plot.Axes.Left;
            } else {
            }


            loggers.Add(var.varIndex, logger);
            NewVariableToPlott.Invoke(this, e);

            zone = 0;
            isRectDraw = false;
            Plot.Refresh();
        }


        public List<int> GetVariablePlotted() {
            return new List<int>(loggers.Keys);
        }


        public void RefreshPlot(double last_value) {
            Plot.Plot.Axes.SetLimitsX(last_value - 5, last_value);

            Plot.Refresh();
        }
    }
}

