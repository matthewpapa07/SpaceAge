using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace SpaceAge
{
    static class GraphicsLib
    {
        public static void ApplyListviewProperties(ListView lv)
        {
            lv.View = View.Details;
            lv.FullRowSelect = true;
            lv.GridLines = true;
        }

        public static Color ColorMix(Color c1, Color c2)
        {

            int _r = Math.Min((c1.R + c2.R), 255);
            int _g = Math.Min((c1.G + c2.G), 255);
            int _b = Math.Min((c1.B + c2.B), 255);

            return Color.FromArgb(Convert.ToByte(_r),
                             Convert.ToByte(_g),
                             Convert.ToByte(_b));
        }
    }
}
