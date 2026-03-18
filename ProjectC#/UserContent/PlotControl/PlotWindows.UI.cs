using ScottPlot;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



//Fichier qui gère la partie UI des PlotWindows, de l'affichage des carrés jaune lorsque l'on fait un Drag&Drop au dessus du Plot au
//style général du plot

namespace ProjectC_.UserContent {
    public partial class PlotWindows : UserControl, IRenderAction {
        public event EventHandler<MouseEventArgs> RightClicOnPlott;


        #region Colors
        ScottPlot.Color ColorDarkGray = new ScottPlot.Color("#adadad");
        ScottPlot.Color ColorDarkBlue = new ScottPlot.Color("#22272e");
        ScottPlot.Color ColorLightDarkBlue = new ScottPlot.Color("#2c323c");
        #endregion

        private int zone = 0; //0 -> Rien | 1 -> Tout | 2 -> Gauche | 3 -> Droit | 4 -> Bas
        private bool isRectDraw = false;
        SkiaSharp.SKRect[] rects = new SKRect[4];
        SKPaint styloJaune = new SKPaint {
            Color = SKColors.Yellow,
            Style = SKPaintStyle.Stroke, // Stroke veut dire qu'on ne dessine que le contour (pas rempli)
            StrokeWidth = 2,
            IsAntialias = true
        };
        Timer timerEndResize = new Timer();

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

        private void Plot_DragOver(object sender, DragEventArgs e) {
            Point posCursor = Plot.PointToClient(new Point(e.X, e.Y));

            if (rects[3].Contains(posCursor.X, posCursor.Y) && ((zone != 4 && isRectDraw) || !isRectDraw)) {
                zone = 4;
                isRectDraw = false;
                Plot.Refresh();
            } else if (rects[2].Contains(posCursor.X, posCursor.Y) && ((zone != 3 && isRectDraw) || !isRectDraw)) {
                zone = 3;
                isRectDraw = false;
                Plot.Refresh();
            } else if (rects[1].Contains(posCursor.X, posCursor.Y) && ((zone != 2 && isRectDraw) || !isRectDraw)) {
                zone = 2;
                isRectDraw = false;
                Plot.Refresh();
            } else if (!rects[3].Contains(posCursor.X, posCursor.Y) & !rects[2].Contains(posCursor.X, posCursor.Y) & !rects[1].Contains(posCursor.X, posCursor.Y) && ((zone != 1 && isRectDraw) || !isRectDraw)) {
                zone = 1;
                isRectDraw = false;
                Plot.Refresh();
            }
        }

        
        public void Render(RenderPack rp) {
            if (zone == 0 || (!AquisitionActive && isRectDraw)) return;

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
        }

        private void Plot_DragEnter(object sender, DragEventArgs e) {
            e.Effect = DragDropEffects.Copy;
        }
        
        private void Plot_DragLeave(object sender, EventArgs e) {
            zone = 0;
            isRectDraw = false;
            Plot.Refresh();
        }

        //On ne redessine les rectangles que si la taille a fini de changer !
        private void Plot_SizeChanged(object sender, EventArgs e) {
            timerEndResize.Stop();
            timerEndResize.Start();
        }

        private void TickEndResize(object sender, EventArgs e) {
            //N'est appelé, qu'à la fin d'un resize (200ms après le dernier appel de SizeChanged)
            timerEndResize.Stop();

            if (Plot.Plot.RenderManager.RenderCount == 0) return;

            RenderDetails rd = Plot.Plot.RenderManager.LastRender;

            int x, y, w, h;
            rects[0] = SKRect.Create(3, 3, rd.FigureRect.Width - 6, rd.FigureRect.Height - 6);

            x = 7;
            y = (int)rd.DataRect.Top - 10;
            w = (int)rd.DataRect.Left - 10;
            h = (int)(rd.DataRect.Bottom - rd.DataRect.Top) + 20;
            rects[1] = SKRect.Create(x, y, w, h);

            x = (int)rd.DataRect.Right;
            y = (int)rd.DataRect.Top - 10;
            w = rd.FigureRect.Right - rd.DataRect.Right > 20 ? (int)rd.DataRect.Left - 10 : 13;
            h = (int)(rd.DataRect.Bottom - rd.DataRect.Top) + 16;
            rects[2] = SKRect.Create(x, y, w, h);

            x = (int)rd.DataRect.Left - 10;
            y = (int)rd.DataRect.Bottom;
            w = (int)(rd.DataRect.Right - rd.DataRect.Left) + 20;
            h = (int)rd.DataRect.Left - 12;
            rects[3] = SKRect.Create(x, y, w, h);
        }
    
        public void UpdateDataInfo(DataInfos info) {
            legends[info.varIndex].MarkerColor = ScottPlot.Color.FromColor(info.color);
            legends[info.varIndex].LabelText = info.name;
            loggers[info.varIndex].Color = ScottPlot.Color.FromColor(info.color);

            if(!AquisitionActive) Plot.Refresh(); //Car si l'aquisition est active le graphique se refresh tout seul

        }
    }
}
