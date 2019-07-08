using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MouseMoveBot
{
    public class Waypoints
    {
        public Bitmap bitIcon { get; set; }
        public State state { get; set; }
        public Function function { get; set; }
        public LabelWp label { get; set; }

        public string name { get; set; }
    }
}
