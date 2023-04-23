using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
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
            var pal = PNGHandler.GetColors(tim.CLUT.Block[0]);
            Bitmap bmp = GetImage8BPP(tim.Image, pal);
            return bmp;
        }

        public static Bitmap GetImage8BPP(Pixel tim, List<string> palette)
        {
            tim.Width *= 2;
            int cLen = 0;
            Bitmap bitmap = new(tim.Width, tim.Height, PixelFormat.Format32bppPArgb);

            for (int y = 0; y < tim.Height; y++)
            {
                for (int x = 0; x < tim.Width; x++)
                {
                    byte cPixel = tim.Data[cLen];
                    string hColor = palette[cPixel];
                    Color cColor = ColorTranslator.FromHtml(hColor);
                    bitmap.SetPixel(x, y, cColor);
                    cLen++;
                }
            }

            return bitmap;
        }

        public static Bitmap GetPNG4BPP(TIM tim)
        {
            var pal = PNGHandler.GetColors(tim.CLUT.Block[0]);
            Bitmap bmp = GetImage4BPP(tim.Image, pal);
            return bmp;
        }

        public static Bitmap GetImage4BPP(Pixel tim, List<string> palette)
        {
            tim.Width *= 4;
            int cLen = 0;
            Bitmap bitmap = new(tim.Width, tim.Height, PixelFormat.Format32bppPArgb);

            for (int y = 0; y < tim.Height; y++)
            {
                for (int x = 0; x < tim.Width; x++)
                {
                    byte cPixel = (byte)(tim.Data[cLen] & 0xF);
                    string hColor = palette[cPixel];
                    Color cColor = ColorTranslator.FromHtml(hColor);
                    bitmap.SetPixel(x, y, cColor);

                    x++;
                    cPixel = (byte)(tim.Data[cLen] >> 0x4);
                    hColor = palette[cPixel];
                    cColor = ColorTranslator.FromHtml(hColor);
                    bitmap.SetPixel(x, y, cColor);
                    cLen++;
                }
            }

            return bitmap;
        }

        public static Bitmap GetPNG16BPP(TIM tim)
        {
            Bitmap bmp = GetImage16BPP(tim.Image);
            return bmp;
        }

        public static Bitmap GetImage16BPP(Pixel tim)
        {
            int cLen = 0;
            Bitmap bitmap = new(tim.Width, tim.Height, PixelFormat.Format32bppPArgb);

            for (int y = 0; y < tim.Height; y++)
            {
                for (int x = 0; x < tim.Width; x++)
                {
                    UInt16 cPixel = tim.Data[cLen];
                    cPixel += (ushort)(tim.Data[cLen + 1] << 0x8);

                    var pColor = PNGHandler.GetCLUTColor(cPixel);
                    string hColor = PNGHandler.GetHtmlColor(pColor);

                    Color cColor = ColorTranslator.FromHtml(hColor);
                    bitmap.SetPixel(x, y, cColor);
                    cLen += 2;
                }
            }

            return bitmap;
        }

        public static Bitmap GetPNG24BPP(TIM tim)
        {
            Bitmap bmp = GetImage24BPP(tim.Image);
            return bmp;
        }

        public static Bitmap GetImage24BPP(Pixel tim)
        {
            int cLen = 0;
            Bitmap bitmap = new(tim.Width, tim.Height, PixelFormat.Format32bppPArgb);

            for (int y = 0; y < tim.Height; y++)
            {
                for (int x = 0; x < tim.Width; x++)
                {
                    string r = $"{tim.Data[cLen].ToString("X").PadLeft(2, '0')}";
                    string g = $"{tim.Data[cLen + 1].ToString("X").PadLeft(2, '0')}";
                    string b = $"{tim.Data[cLen + 2].ToString("X").PadLeft(2, '0')}";

                    Color cColor = ColorTranslator.FromHtml($"#{r}{g}{b}");
                    bitmap.SetPixel(x, y, cColor);
                    cLen += 3;
                }
            }

            return bitmap;
        }
    }
}
