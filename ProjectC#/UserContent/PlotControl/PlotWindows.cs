using ScottPlot;
using ScottPlot.AxisRules;
using ScottPlot.Interactivity;
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
        private Dictionary<int, char> location = new Dictionary<int, char>(); // Chaque variable est soit r, l ou b
        private Dictionary<int, ScottPlot.LegendItem> legends = new Dictionary<int, LegendItem>();

        private bool dataReceive;

        MaximumSpan maxSpanRule;
        MinimumSpan minSpanRule;
        LockedHorizontal lockHorizRule;

        //Variable qui indique si on va recevoir des données ou non. Si elle est a true c'est que la form recoit des données dans le 
        //Port série et donc que l'on est susceptible d'en recevoir aussi. 
        //!!! si elle est a vrai ça ne veut pas dire qu'on recoit FORCEMENT des données, si le plot n'est abonné a aucune variable, alors on ne recoit rien.
        private bool AquisitionActive; 

        public PlotWindows(String title) {
            InitializeComponent();
            Plot.Menu?.Clear();

            FigureTitle = title;


            ApplyDesignToPlot(Plot.Plot);
            Plot.Plot.RenderManager.RenderActions.Add(this);

            timerEndResize.Interval = 200;
            timerEndResize.Tick += TickEndResize;
            timerEndResize.Start(); //POur que les rectangles soient dessiné une première fois

            maxSpanRule = new MaximumSpan(
                    xAxis: Plot.Plot.Axes.Bottom,
                    yAxis: Plot.Plot.Axes.Left,
                    xSpan: 5,
                    ySpan: double.MaxValue
                );
            minSpanRule = new MinimumSpan(
                    xAxis: Plot.Plot.Axes.Bottom,
                    yAxis: Plot.Plot.Axes.Left,
                    xSpan: 5,
                    ySpan: double.MinValue);
            lockHorizRule = new LockedHorizontal(Plot.Plot.Axes.Bottom, 0, 0);

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
            if (!loggers.ContainsKey(varId)) return;
            loggers[varId].Add(x, y);
            //Debug.WriteLine("var id: " + varId.ToString());
        }

        private void Plot_DragDrop(object sender, DragEventArgs e) {
            DataInfos var = (DataInfos) e.Data.GetData(typeof(DataInfos));
            char loc;


            Point posCursor = Plot.PointToClient(new Point(e.X, e.Y));
            if (rects[3].Contains(posCursor.X, posCursor.Y)) {
                //Zone du bas
                loc = 'l';
            } else if (rects[2].Contains(posCursor.X, posCursor.Y)) {
                //Zone Droite
                loc = 'r';
            } else if (rects[1].Contains(posCursor.X, posCursor.Y)) {
                //Zone Gauche
                loc = 'l';
            } else {
                loc = 'l';
            }

            PlotNewData(var, loc);
            NewVariableToPlott.Invoke(this, e);

        }


        public void PlotNewData(DataInfos info, char loc) {
            if (loggers.ContainsKey(info.varIndex)) return;


            DataLogger logger = Plot.Plot.Add.DataLogger();
            logger.ManageAxisLimits = false;
            logger.Color = ScottPlot.Color.FromColor(info.color);

            legends.Add(info.varIndex, new LegendItem());
            legends[info.varIndex].MarkerColor = ScottPlot.Color.FromColor(info.color);
            legends[info.varIndex].MarkerShape = ScottPlot.MarkerShape.FilledSquare;
            legends[info.varIndex].MarkerSize = 15;
            legends[info.varIndex].LineWidth = 0;
            legends[info.varIndex].LabelText = info.name;

            Plot.Plot.Legend.ManualItems.Add(legends[info.varIndex]);
            switch (loc) {
                case 'r':
                    logger.Axes.YAxis = Plot.Plot.Axes.Right;
                    location.Add(info.varIndex, 'r');
                    break;
                default:
                    logger.Axes.YAxis = Plot.Plot.Axes.Left;
                    location.Add(info.varIndex, 'l');
                    break;
            }

            loggers.Add(info.varIndex, logger);

            zone = 0;
            isRectDraw = false;
            Plot.Refresh();
        }

        public List<int> GetVariablePlotted() {
            return new List<int>(loggers.Keys);
        }

        public char getPosition(int varId) {
            return location[varId];
        }


        public void RefreshPlot(double last_value) {
            Plot.Plot.Axes.SetLimitsX(last_value - 5, last_value);

            Plot.Plot.Axes.Rules.Clear();
            Plot.Plot.Axes.Rules.Add(maxSpanRule);
            Plot.Plot.Axes.Rules.Add(minSpanRule);
            lockHorizRule.XMin = last_value-5;
            lockHorizRule.XMax = last_value;
            Plot.Plot.Axes.Rules.Add(lockHorizRule);


            Plot.Refresh();
        }

        public void SetAquisitionActive(bool state) {
            AquisitionActive = state;
            Plot.Plot.Axes.Rules.Clear();
        }

        public (double, double) GetAxesLimits(char axe) {
            AxisManager Axes = Plot.Plot.Axes;
            switch (axe) {
                case 'r':
                    return (Axes.Right.Min, Axes.Right.Max);
                case 'b':
                    return (Axes.Bottom.Min, Axes.Bottom.Max);
                default:
                    return (Axes.Left.Min, Axes.Left.Max);
            }
        }

        public void SetAxesLimits(char axe, (double,double) limit) {
            AxisManager Axes = Plot.Plot.Axes;
            switch (axe) {
                case 'r':
                    Axes.Right.Min = limit.Item1;
                    Axes.Right.Max = limit.Item2;
                    return;
                case 'l':
                    Axes.Left.Min = limit.Item1;
                    Axes.Left.Max = limit.Item2;
                    return;
                case 'b':
                    Axes.Bottom.Min = limit.Item1;
                    Axes.Bottom.Max = limit.Item2;
                    return;
                default:
                    return;
            }
        }
    } 
}

