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
    public partial class PlotDesign : UserControl, IRenderAction {
        ScottPlot.Color ColorDarkGray = new ScottPlot.Color("#adadad");
        ScottPlot.Color ColorDarkBlue = new ScottPlot.Color("#22272e");
        ScottPlot.Color ColorLightDarkBlue = new ScottPlot.Color("#2c323c");

        public event EventHandler<MouseEventArgs> RightClicOnPlott;
        public event EventHandler<EventArgs> NewVariableToPlott;

        //Chaque variable à son propre Data Logger et le data logger loggers[i] correspond a la variable varId[i]
        private Dictionary<int,DataLogger> loggers = new Dictionary<int, DataLogger>();

        String FigureTitle;

        public PlotDesign(String title) {
            InitializeComponent();
            Plot.Menu?.Clear();

            FigureTitle = title;


            ApplyDesignToPlot(Plot.Plot);
            Plot.Plot.RenderManager.RenderActions.Add(this);


            Plot.Refresh();
        }

        private void ApplyDesignToPlot(ScottPlot.Plot formPlot) {
            formPlot.FigureBackground.Color = ColorLightDarkBlue;
            formPlot.Axes.Color(ColorDarkGray);

            formPlot.DataBackground.Color = ColorDarkBlue;

            formPlot.Grid.XAxisStyle.MajorLineStyle.Color = ColorDarkGray.WithAlpha(50);
            formPlot.Grid.YAxisStyle.MajorLineStyle.Color = ColorDarkGray.WithAlpha(50);

            formPlot.Grid.XAxisStyle.MajorLineStyle.Width = 1;
            formPlot.Grid.YAxisStyle.MajorLineStyle.Width = 1;

            formPlot.Title(FigureTitle);
            formPlot.Axes.Title.Label.FontName = "Microsoft Sans Serif";
            formPlot.Axes.Title.Label.FontSize = 15;
            formPlot.Axes.Title.Label.Bold = true;

            formPlot.XLabel("Temps (s)");
            formPlot.Axes.Bottom.Label.FontName = "Microsoft Sans Serif";
            formPlot.Axes.Bottom.Label.FontSize = 14;
            formPlot.Axes.Bottom.Label.Bold = false;
            formPlot.Axes.Bottom.Label.OffsetY = 0;


            formPlot.Axes.Bottom.MinimumSize = 50;
        }

        private void Plot_MouseUp(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Right) RightClicOnPlott.Invoke(this, e);
        }


        private int zone = 0; //0 -> Rien | 1 -> Tout | 2 -> Gauche | 3 -> Droit | 4 -> Bas
        private bool isRectDraw = false;
        private void Plot_DragOver(object sender, DragEventArgs e) {
            Point posCursor = Plot.PointToClient(new Point(e.X, e.Y));

            if (rects[3].Contains(posCursor.X, posCursor.Y) && ((zone != 4 && isRectDraw) || !isRectDraw)) {
                zone = 4;
                isRectDraw = false;
                Plot.Refresh();
            }else if (rects[2].Contains(posCursor.X, posCursor.Y) && ((zone != 3 && isRectDraw) || !isRectDraw)) {
                zone = 3;
                isRectDraw = false;
                Plot.Refresh();
            }else if (rects[1].Contains(posCursor.X, posCursor.Y) && ((zone != 2 && isRectDraw) || !isRectDraw)) {
                zone = 2;
                isRectDraw = false;
                Plot.Refresh();
            }else if(!rects[3].Contains(posCursor.X, posCursor.Y) & !rects[2].Contains(posCursor.X, posCursor.Y) & !rects[1].Contains(posCursor.X, posCursor.Y) && ((zone != 1 && isRectDraw) || !isRectDraw)) {
                zone = 1;
                isRectDraw = false;
                Plot.Refresh();
            }
        }

        SkiaSharp.SKRect[] rects = new SKRect[4];
        public void Render(RenderPack rp) {
            if (zone == 0 || isRectDraw) return;

            SKPaint styloJaune = new SKPaint {
                Color = SKColors.Yellow,
                Style = SKPaintStyle.Stroke, // "Stroke" veut dire qu'on ne dessine que le contour (pas rempli)
                StrokeWidth = 2,
                IsAntialias = true
            };

            int x, y, w, h;
            rects[0] = SKRect.Create(3, 3, rp.FigureRect.Width - 6, rp.FigureRect.Height - 6);

            x = 7;
            y = (int)rp.DataRect.Top - 10;
            w = (int)rp.DataRect.Left - 10;
            h = (int)(rp.DataRect.Bottom - rp.DataRect.Top) + 20;
            rects[1] = SKRect.Create(x, y, w, h);

            x = (int)rp.DataRect.Right;
            y = (int)rp.DataRect.Top - 10;
            w = rp.FigureRect.Right - rp.DataRect.Right > 20 ? (int)rp.DataRect.Left - 10 : 13;
            h = (int)(rp.DataRect.Bottom - rp.DataRect.Top) + 16;
            rects[2] = SKRect.Create(x, y, w, h);

            x = (int)rp.DataRect.Left - 10;
            y = (int)rp.DataRect.Bottom;
            w = (int)(rp.DataRect.Right - rp.DataRect.Left) + 20;
            h = (int)rp.DataRect.Left - 12;
            rects[3] = SKRect.Create(x, y, w, h);



            switch (zone) {
                case 1:
                    rp.Canvas.DrawRect(rects[0], styloJaune);
                    break;
                case 2:
                    rp.Canvas.DrawRect(rects[1], styloJaune);
                    break;
                case 3:
                    rp.Canvas.DrawRect(rects[2], styloJaune);
                    break;
                case 4:
                    rp.Canvas.DrawRect(rects[3], styloJaune);
                    break;
                default:
                    break;
            }
            

            isRectDraw = true;
            styloJaune.Dispose();
        }

        private void Plot_DragLeave(object sender, EventArgs e) {
            zone = 0;
            isRectDraw = false;
            Plot.Refresh();
        }


        public void AddDataToPlott(int varId, double x, double y) {
            Debug.WriteLine("coucou");
            if (!loggers.ContainsKey(varId)) return;
            loggers[varId].Add(x, y);
        }

        private void Plot_DragDrop(object sender, DragEventArgs e) {
            int var = int.Parse((string) e.Data.GetData(DataFormats.StringFormat));
            

            if (loggers.ContainsKey(var)) return;

            DataLogger logger = Plot.Plot.Add.DataLogger();
            logger.ManageAxisLimits = false;
            loggers.Add(var, logger);

            NewVariableToPlott.Invoke(this, e);

            zone = 0;
            isRectDraw = false;
            Plot.Refresh();
        }


        public List<int> GetVariablePlotted() {
            return new List<int>(loggers.Keys);
        }

        private void Plot_DragEnter(object sender, DragEventArgs e) {
            e.Effect = DragDropEffects.Copy;
        }

        public void RefreshPlot(double last_value) {
            Plot.Plot.Axes.SetLimitsX(last_value - 5, last_value);

            Debug.WriteLine(last_value.ToString());

            Plot.Refresh();
        }
    }
}

