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
    public partial class PanelConsoleControl : UserControl {
        public PanelConsoleControl() {
            InitializeComponent();

            foreach (Control enfant in this.Controls) {
                // On abonne chaque enfant à son propre événement MouseUp
                enfant.MouseClick += (sender, e) => {
                    // L'enfant déclenche manuellement l'événement MouseUp du parent (le UserControl) !
                    this.OnMouseClick(e);
                };

            }
        }

        public void Init(int maxWidth) {
            this.Width = maxWidth;
        }
    }
}
