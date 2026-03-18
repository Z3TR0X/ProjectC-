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
}
