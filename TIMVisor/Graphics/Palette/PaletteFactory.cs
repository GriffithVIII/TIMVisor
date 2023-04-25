using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TIMVisor.Graphics.Format;

namespace TIMVisor.Graphics.Palette
{
    public class PaletteFactory
    {
        public static Dictionary<string, Color> GetImagePalette(Bitmap bitmap)
        {
            Dictionary<string, Color> pal = new();

            for (int y = 0; y < bitmap.Height; y++)
            {
                for (int x = 0; x < bitmap.Width; x++)
                {
                    var iColor = bitmap.GetPixel(x, y);

                    if (!pal.ContainsKey(iColor.Name))
                        pal.Add(iColor.Name, iColor);
                }
            }

            return pal;
        }

        public static Dictionary<string, Color> GetPreservedPalette(List<string> palette)
        {
            Dictionary<string, Color> pal = new();

            foreach(string col in palette)
            {
                pal.Add(col, ColorTranslator.FromHtml(col));
            }

            return pal;
        }

        public static Dictionary<Color, int> GetCLUTOrder(CLUTBlock block)
        {
            Dictionary<Color, int> order = new();

            foreach(CLUTEntry entry in block.Entries)
            {
                var color = GetHtmlColor(entry);
                order.Add(ColorTranslator.FromHtml(color), order.Count);
            }

            return order;
        }

        public static CLUTEntry CLUTFromHTML(Color color)
        {
            CLUTEntry clut = new();
            int entry = 0;

            var tps = color.A == 255 ? 0 : 1;
            var b = color.B >> 0x3;
            var g = color.G >> 0x3;
            var r = color.R >> 0x3;

            entry += tps << 15;
            entry += b << 10;
            entry += g << 5;
            entry += r << 0;

            clut.Entry = (UInt16)entry;
            clut.STP = (byte)tps;
            clut.B = (byte)b;
            clut.G = (byte)g;
            clut.R = (byte)r;

            return clut;
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
