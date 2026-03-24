using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectC_ {
    public struct DataInfos {
        public String name;
        public Color color;
        public int varIndex;

        public DataInfos(String _name, Color _color, int _varId) {
            name = _name;
            color = _color;
            varIndex = _varId;
        }
    }



    public struct Window {
        public string windowName;
        public int nbPlots;
        public List<PlotWindow> plots;

        public Window(string _name, int _nbPlots) {
            windowName = _name;
            nbPlots = _nbPlots;
            plots = new List<PlotWindow>();
        }
    }

    public struct PlotWindow {
        public string plotName;
        public int plotId;
        public List<int> dataPloted;

        public PlotWindow(string _plotName, int _plotId) {
            plotName = _plotName;
            plotId = _plotId;
            dataPloted = new List<int>();
        }
    }
}
