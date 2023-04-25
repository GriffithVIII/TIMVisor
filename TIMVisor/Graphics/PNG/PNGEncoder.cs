using System.Drawing.Imaging;
using TIMVisor.Graphics.Format;

namespace TIMVisor.Graphics.PNG
{
    public class PNGEncoder
    {
        public static Bitmap Encode8BPP(Tex tim, List<string> palette)
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

        public static Bitmap Encode4BPP(Tex tim, List<string> palette)
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

        public static Bitmap Encode16BPP(Tex tim)
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

        public static Bitmap Encode24BPP(Tex tim)
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
