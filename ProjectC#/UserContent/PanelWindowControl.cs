using Krypton.Toolkit;
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
    public partial class PanelWindowControl : UserControl {
        public int id;
        public PanelWindowControl() {
            InitializeComponent();

            foreach (Control enfant in this.Controls) {
                // On abonne chaque enfant à son propre événement MouseUp
                enfant.MouseClick += (sender, e) => {
                    // L'enfant déclenche manuellement l'événement MouseUp du parent (le UserControl) !
                    this.OnMouseClick(e);
                };

            }
        }

        public void Init(string name, int maxWidth, int _id) {
            this.Width = maxWidth;
            WindowName.Text = name;
            id = _id;
        }

        public void SetName(string name) { 
            WindowName.Text = name;
        }

    }
}
