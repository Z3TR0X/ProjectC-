using ScottPlot.Triangulation;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectC_ {
    public partial class Form1 {
        [DllImport("user32.dll")]
        private static extern bool DestroyIcon(IntPtr hIcon);

        //Bloc compliqué pour récuprer la vraie taille du curseur car windows ment !
        [DllImport("gdi32.dll")]
        private static extern int GetDeviceCaps(IntPtr hdc, int nIndex);

        [DllImport("user32.dll")]
        private static extern IntPtr GetDC(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

        [DllImport("dwmapi.dll")]
        private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        public struct IconInfo {
            public bool fIcon;
            public int xHotspot;
            public int yHotspot;
            public IntPtr hbmMask;
            public IntPtr hbmColor;
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern IntPtr CreateIconIndirect(ref IconInfo icon);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool GetIconInfo(IntPtr hIcon, ref IconInfo pIconInfo);

        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        public static extern bool DeleteObject(IntPtr hObject);
        [StructLayout(LayoutKind.Sequential)]
        public struct CURSORINFO {
            public int cbSize;
            public int flags;
            public IntPtr hCursor;
            public Point ptScreenPos;
        }

        [DllImport("user32.dll")]
        public static extern bool GetCursorInfo(out CURSORINFO pci);

        [DllImport("user32.dll")]
        public static extern bool DrawIconEx(IntPtr hdc, int xLeft, int yTop, IntPtr hIcon,
                                             int cxWidth, int cyWidth, int istepIfAniCur,
                                             IntPtr hbrFlickerFreeDraw, int diFlags);

        private const int DI_NORMAL = 0x0003;

        //Fonction pour ajouter l'ombre autour de la fenêtre
        protected override CreateParams CreateParams {
            get {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= 0x20000; // Ombre portée
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }


        private int GetDpi() {
            IntPtr hdc = GetDC(IntPtr.Zero);

            // Ce que Windows fait croire à ton application (ex: 1066)
            int virtualHeight = GetDeviceCaps(hdc, 10);

            // La vraie taille physique de ton écran (ex: 1600)
            int physicalHeight = GetDeviceCaps(hdc, 117);

            ReleaseDC(IntPtr.Zero, hdc);

            // On calcule le vrai ratio de zoom (ex: 1600 / 1066 = 1.5)
            float realScale = (float)physicalHeight / (float)virtualHeight;

            return (int) (realScale * 96f);
        }
    }
}