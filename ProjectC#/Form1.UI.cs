using Krypton.Toolkit;
using ProjectC_.VarPanel;
using ScottPlot.Finance;
using ScottPlot.Triangulation;
using ScottPlot.WinForms;
using System;
using System.Drawing;
using System.IO.Ports;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProjectC_
{
    public partial class Form1 {
        private Cursor DragCursor;
        private bool isColorPickerOpening = false;

        private Cursor CreateDragCursor(string text) {
            Font font = new Font(FontFamily.GenericSansSerif, 12);
            Size textSize;

            //Permet de mesurer la taille du texte
            using (Graphics graph = this.CreateGraphics()) {
                var sizeF = graph.MeasureString(text, font);
                textSize = new Size((int)sizeF.Width +10, (int)sizeF.Height+10); // Petite marge autour du texte
            }

            //Recup la taille du curseur
            float ratio = GetDpi() / 96f;
            int cursorWidth = (int) (Cursor.Size.Width * ratio);
            Size cursorSize = new Size(cursorWidth, cursorWidth);


            int cursorGap = 0; // Gap entre le curseur et le rectangle
            Size totalSize = textSize + cursorSize + new Size(cursorGap, 50);


            Bitmap bmp = new Bitmap(totalSize.Width, totalSize.Width);
            Graphics g = Graphics.FromImage(bmp);

            g.Clear(Color.Transparent);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            CURSORINFO pci = new CURSORINFO();
            pci.cbSize = Marshal.SizeOf(typeof(CURSORINFO));

            // 2. On demande à Windows quel est le curseur ACTUEL (couleur, taille custom, etc.)
            if (GetCursorInfo(out pci)) {
                // 3. On récupère la "toile de fond" de notre Graphics (le HDC)
                IntPtr hdc = g.GetHdc();

                // 4. On dessine le curseur. 
                // Mettre 0 et 0 en largeur/hauteur force Windows à utiliser la VRAIE taille du curseur de l'utilisateur !
                DrawIconEx(hdc, 0, 0, pci.hCursor, cursorWidth, cursorWidth, 0, IntPtr.Zero, DI_NORMAL);

                // 5. On libère la toile
                g.ReleaseHdc(hdc);
            }

            

            Brush backBrush = new SolidBrush(Color.FromArgb(200, 34, 39, 46));
            g.FillRectangle(backBrush, (int) (cursorWidth/1.8), cursorWidth/2, textSize.Width - 1, textSize.Height - 1);
            g.DrawRectangle(Pens.White, (int)(cursorWidth / 1.8), cursorWidth / 2, textSize.Width - 1, textSize.Height - 1);

            // On dessine le texte
            g.DrawString(text, font, Brushes.White, (int)(cursorWidth / 1.8) + 5, 5+ cursorWidth / 2);

            g.Dispose();


            IntPtr ptrImageBrute = bmp.GetHbitmap(Color.Transparent);

            // 2. On configure notre curseur "No Limit"
            IconInfo iconInfo = new IconInfo();
            iconInfo.fIcon = false;         // false = Curseur (autorise le hors-format), true = Icône (bridé)
            iconInfo.xHotspot = 0;          // Le clic se fait sur le pixel en haut à gauche (0,0)
            iconInfo.yHotspot = 0;

            // On donne la même image pour la couleur et le masque de transparence
            iconInfo.hbmColor = ptrImageBrute;
            iconInfo.hbmMask = ptrImageBrute;

            // 3. On crée enfin le curseur géant
            IntPtr hCursorLibre = CreateIconIndirect(ref iconInfo);

            // 4. NETTOYAGE VITAL (Sinon ton appli va saturer la RAM après 50 Drag & Drop)
            DeleteObject(ptrImageBrute);

            // 5. On renvoie le vrai curseur complet !
            return new Cursor(hCursorLibre);
        }


        private void UpdateDatasPanels(object sender, EventArgs e) {
            if(Datas.Count != DatasName.Count || Datas.Count == 0 || isClosing) {
                return;
            }


            for (int i = 0; i < Datas.Count; i++) { 
                int LastElem = (Datas[i].Count) - 1;
                if(LastElem > 0) {
                    PanelVarControl panel = (PanelVarControl)FlowVarPanel.Controls[i];
                    panel.setCurrentValue(Datas[i][LastElem]);
                }
                
            }
            
        }

        private PanelVarMenu menuVar;
        private ToolStripDropDown menuClicDroit;

        private void createPanelRightClicMenu() {
            menuVar = new PanelVarMenu(this);

            ToolStripControlHost host = new ToolStripControlHost(menuVar);
            host.AutoSize = false;
            host.Size = menuVar.Size + new Size(1, 1);
            host.Margin = Padding.Empty;
            host.Padding = Padding.Empty;
            host.BackColor = Color.DarkGray;

            menuClicDroit = new ToolStripDropDown();
            menuClicDroit.Padding = Padding.Empty;
            menuClicDroit.Margin = Padding.Empty;
            menuClicDroit.DropShadowEnabled = false;
            menuClicDroit.BackColor = Color.FromArgb(50, 50, 50);
            menuClicDroit.Size = menuVar.Size + new Size(1, 1);

            menuClicDroit.Items.Add(host);


        }

        private MenuCustomVar MenuCustomVar;
        private ToolStripDropDown CustomMenuClicDroit;
        private void createCustomPanelRightClicMenu() {
            MenuCustomVar = new MenuCustomVar(this);

            ToolStripControlHost host = new ToolStripControlHost(MenuCustomVar);
            host.AutoSize = false;
            host.Size = MenuCustomVar.Size + new Size(1, 1);
            host.Margin = Padding.Empty;
            host.Padding = Padding.Empty;
            host.BackColor = Color.DarkGray;

            CustomMenuClicDroit = new ToolStripDropDown();
            CustomMenuClicDroit.Padding = Padding.Empty;
            CustomMenuClicDroit.Margin = Padding.Empty;
            CustomMenuClicDroit.DropShadowEnabled = false;
            CustomMenuClicDroit.BackColor = Color.FromArgb(50, 50, 50);
            CustomMenuClicDroit.Size = MenuCustomVar.Size + new Size(1, 1);

            CustomMenuClicDroit.Items.Add(host);
        }

        private ColorPicker menuContentColor;
        private ToolStripDropDown menuColor;

        private void createColorPickerMenu() {
            menuContentColor = new ColorPicker(menuVar);

            ToolStripControlHost host = new ToolStripControlHost(menuContentColor);
            host.AutoSize = false;
            host.Size = menuContentColor.Size + new Size(1, 1);
            host.Margin = Padding.Empty;
            host.Padding = Padding.Empty;
            host.BackColor = Color.DarkGray;

            menuColor = new ToolStripDropDown();
            menuColor.Padding = Padding.Empty;
            menuColor.Margin = Padding.Empty;
            menuColor.DropShadowEnabled = false;
            menuColor.BackColor = Color.FromArgb(50, 50, 50);
            menuColor.Size = menuContentColor.Size + new Size(1, 1);
            menuColor.Closing += (sender, e) => {
                ToolStripDropDown menu = isOpennedMenuCustom ? CustomMenuClicDroit : menuClicDroit;

                menu.AutoClose = true;
                menu.Close();
                menu.Show(PanelVarRightClickPos);
            };
           
            menuColor.Items.Add(host);
        }

        bool isOpennedMenuCustom = false;
        public void BeginPickColor(bool isCustom) { //La variable booléenne permet de savoir si le menu ouvert est custom ou non
            if (menuClicDroit.Visible || CustomMenuClicDroit.Visible) {
                if (isCustom) {
                    CustomMenuClicDroit.AutoClose = false;
                    isOpennedMenuCustom = true;
                } else {
                    menuClicDroit.AutoClose = false;
                    isOpennedMenuCustom = false;
                }
                isColorPickerOpening = true;

                menuColor.Show(Cursor.Position);
            }

   
        }

        public void ApplyPlotDesign(ScottPlot.Plot formPlot){
            formPlot.FigureBackground.Color = ColorLightDarkBlue;
            formPlot.Axes.Color(ColorDarkGray);

            formPlot.DataBackground.Color = ColorDarkBlue;

            formPlot.Grid.XAxisStyle.MajorLineStyle.Color = ColorDarkGray.WithAlpha(50);
            formPlot.Grid.YAxisStyle.MajorLineStyle.Color = ColorDarkGray.WithAlpha(50);

            formPlot.Grid.XAxisStyle.MajorLineStyle.Width = 1;
            formPlot.Grid.YAxisStyle.MajorLineStyle.Width = 1;

            formPlot.Title("Figure 1");
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


    }
}
