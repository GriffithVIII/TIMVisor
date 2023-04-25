using Microsoft.VisualBasic.Devices;
using Newtonsoft.Json;
using TIMVisor.Graphics.Format;
using TIMVisor.Graphics.PNG;

namespace TIMVisor.Helpers
{
    public class JsonHandler
    {
        public static void ExportINI(string path, INI ini)
        {
            using (StreamWriter file = File.CreateText(path))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Formatting = Formatting.Indented;
                serializer.Serialize(file, ini);
            }
        }

        public static INI ImportINI(string path)
        { 
            using (StreamReader file = File.OpenText(path))
            {
                JsonSerializer serializer = new JsonSerializer();
                INI ini = (INI)serializer.Deserialize(file, typeof(INI));

                return ini;
            }
        }

        public static INI GetINI(TIM tim)
        {
            Version2BPP bpp = new();
            TextureINI iniTex = new();
            CLUTINI iniCLUT = new();
            
            //# To preserve original image information
            iniTex.VRAM_X = tim.Image.VRAM_X;
            iniTex.VRAM_Y = tim.Image.VRAM_Y;

            //# To preserve original palette information
            iniCLUT.VRAM_X = tim.CLUT.VRAM_X;
            iniCLUT.VRAM_Y = tim.CLUT.VRAM_Y;
            iniCLUT.OriginalPalette = GetCLUTasHtml(tim.CLUT.Block[0]);

            INI ini = new();
            ini.BPP = bpp.BitsPerPixel[tim.Version];
            ini.Texture = iniTex;
            ini.CLUT = iniCLUT;

            return ini;
        }

        public static List<string> GetCLUTasHtml(CLUTBlock block)
        {
            List<string> Palette = new();

            foreach(CLUTEntry entry in  block.Entries)
            {
                Palette.Add(PNGHandler.GetHtmlColor(entry));
            }

            return Palette;
        }
    }
}
