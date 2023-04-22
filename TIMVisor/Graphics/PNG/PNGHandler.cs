using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TIMVisor.Graphics.Format;

namespace TIMVisor.Graphics.PNG
{
    public class PNGHandler
    {
        public static List<string> GetColors(CLUTBlock clut)
        {
            List<string> ColorPal = new();

            for (int i = 0; i < clut.Entries.Count; i++)
            {
                string hColor = GetHtmlColor(clut.Entries[i]);
                ColorPal.Add(hColor);
            }

            return ColorPal;
        }

        public static string GetHtmlColor(CLUTEntry color)
        {
            var r = color.R << 0x3;
            var g = color.G << 0x3;
            var b = color.B << 0x3;

            return $"#{r.ToString("X").PadLeft(2, '0')}" +
                   $"{g.ToString("X").PadLeft(2, '0')}" +
                   $"{b.ToString("X").PadLeft(2, '0')}";
        }
    }
}
