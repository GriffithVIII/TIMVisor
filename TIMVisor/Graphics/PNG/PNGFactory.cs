using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TIMVisor.Graphics.Format;

namespace TIMVisor.Graphics.PNG
{
    public class PNGFactory
    {
        public static Bitmap GetPNG8BPP(TIM tim)
        {
            var pal = GetColors(tim.CLUT.Block[0]);
            Bitmap bmp = GetImage8BPP(timExt, pal);
            return bmp;
        }

        public static List<string> GetColors(CLUTBlock clut)
        {
            List<string> ColorPal = new();

            for (int i = 0; i < clut.ColorData.Count; i++)
            {
                string hColor = GetHtmlColor(clut.ColorData[i]);
                ColorPal.Add(hColor);
            }

            return ColorPal;
        }
    }
}
