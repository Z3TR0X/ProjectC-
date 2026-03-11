using Krypton.Toolkit;
using ProjectC_.VarPanel;
using ScottPlot.Triangulation;
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
            Font font = new Font(FontFamily.GenericSansSerif, 10);
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
            if(Datas.Count != DatasName.Count || Datas.Count == 0) {
                return;
            }

            for(int i = 0; i < Datas.Count; i++) {
                PanelVarControl panel = (PanelVarControl)FlowVarPanel.Controls[i];
                int LastElem = (Datas[i].Count) - 1;
                Console.WriteLine(LastElem);
                panel.setCurrentValue(Datas[i][LastElem]);
            }
        }

        private PanelVarMenu menu;
        private ToolStripDropDown menuClicDroit;

        private void createPanelRightClicMenu() {
            menu = new PanelVarMenu(this);

            ToolStripControlHost host = new ToolStripControlHost(menu);
            host.AutoSize = false;
            host.Size = menu.Size + new Size(1, 1);
            host.Margin = Padding.Empty;
            host.Padding = Padding.Empty;
            host.BackColor = Color.DarkGray;

            menuClicDroit = new ToolStripDropDown();
            menuClicDroit.Padding = Padding.Empty;
            menuClicDroit.Margin = Padding.Empty;
            menuClicDroit.DropShadowEnabled = false;
            menuClicDroit.BackColor = Color.FromArgb(50, 50, 50);
            menuClicDroit.Size = menu.Size + new Size(1, 1);

            menuClicDroit.Items.Add(host);


        }

        private ColorPicker menuContentColor;
        private ToolStripDropDown menuColor;

        private void createColorPickerMenu() {
            menuContentColor = new ColorPicker(menu);

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
                menuClicDroit.AutoClose = true;
                menuClicDroit.Close();
                menuClicDroit.SuspendLayout();
                menuClicDroit.Show(PanelVarRightClickPos);
                menuClicDroit.ResumeLayout(true);
            };
           
            menuColor.Items.Add(host);
        }

        public void BeginPickColor() {
            if (menuClicDroit.Visible) {
                isColorPickerOpening = true;
                menuClicDroit.AutoClose = false;

                menuColor.Show(Cursor.Position);
            }

   
        }



    }
}
