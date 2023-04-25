using TIMVisor.Graphics.Format;
using TIMVisor.Helpers;
using TIMVisor.Graphics.Palette;

namespace TIMVisor.Graphics.TIMLib
{
    public class TIMHandler
    {
        public static string GetTypeBPP(BinaryReader DR, int type)
        {
            string bpp = "";
            DataReader.Seek(DR, 8);

            if (type == 8)
                bpp = "4BPP";
            else if (type == 9)
                bpp = "8BPP";
            else if (type == 2)
                bpp = "16BPP";
            else if (type == 3)
                bpp = "24BPP";
            else
                bpp = "UNSUPPORTED";

            return bpp;
        }

        public static CLUTBlock MakeCLUTBlock(Bitmap bmp)
        {
            CLUTBlock block = new();

            var palette = PaletteFactory.GetImagePalette(bmp);

            foreach (Color iColor in palette.Values)
            {
                var cColor = PaletteFactory.CLUTFromHTML(iColor);
                block.Entries.Add(cColor);
            }

            return block;
        }

        public static CLUTBlock PreserveCLUTColors(List<string> preserved)
        {
            CLUTBlock block = new();

            var palette = PaletteFactory.GetPreservedPalette(preserved);

            foreach (Color iColor in palette.Values)
            {
                var cColor = PaletteFactory.CLUTFromHTML(iColor);
                block.Entries.Add(cColor);
            }

            return block;
        }

        public static TIM PreserveData(INI ini, TIM tim)
        {
            BPP2Version get = new();

            //# Copy original TIM data
            tim.Version = get.Version[ini.BPP];

            //# Copy original Texture data
            tim.Image.VRAM_X = ini.Texture.VRAM_X;
            tim.Image.VRAM_Y = ini.Texture.VRAM_Y;

            //# Copy original CLUT data
            tim.CLUT.VRAM_X = ini.CLUT.VRAM_X;
            tim.CLUT.VRAM_Y = ini.CLUT.VRAM_Y;

            return tim;
        }
    }
}
