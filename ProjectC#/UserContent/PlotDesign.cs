using ScottPlot.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectC_.UserContent {
    public partial class PlotDesign : UserControl {
        ScottPlot.Color ColorDarkGray = new ScottPlot.Color("#adadad");
        ScottPlot.Color ColorDarkBlue = new ScottPlot.Color("#22272e");
        ScottPlot.Color ColorLightDarkBlue = new ScottPlot.Color("#2c323c");

        public event EventHandler<MouseEventArgs> RightClicOnPlott;

        String FigureTitle;

        public PlotDesign(String title) {
            InitializeComponent();
            Plot.Menu?.Clear();

            FigureTitle = title;

            ApplyDesignToPlot(Plot.Plot);
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
    }
}
