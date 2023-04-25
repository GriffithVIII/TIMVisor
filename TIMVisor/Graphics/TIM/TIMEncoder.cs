using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TIMVisor.Graphics.Format;
using TIMVisor.Graphics.Palette;
using TIMVisor.Helpers;

namespace TIMVisor.Graphics.TIMLib
{
    public class TIMEncoder
    {
        public static TIM tim = new();
        public static TIM Encode8BPP(Bitmap bmp)
        {
            MakeCLUTHeader(bmp);
            var order = PaletteFactory.GetCLUTOrder(tim.CLUT.Block[0]);

            //# Make Image
            for (int y = 0; y < bmp.Height; y++)
            {
                for (int x = 0; x < bmp.Width; x++)
                {
                    var iPixel = bmp.GetPixel(x, y);
                    byte cPixel = (byte)order[iPixel];
                    tim.Image.Data.Add(cPixel);
                }
            }

            tim.CLUT.Block[0] = CheckLength(tim.CLUT.Block[0], "8BPP");
            tim.CLUT.NumColors = 256;
            tim.CLUT.Length = tim.CLUT.NumColors * 2 + 0xC;
            MakeImageHeader(bmp);
            tim.Image.Width /= 2;
            return tim;
        }

        public static TIM Encode4BPP(Bitmap bmp)
        {
            MakeCLUTHeader(bmp);
            var order = PaletteFactory.GetCLUTOrder(tim.CLUT.Block[0]);

            //# Make Image
            for (int y = 0; y < bmp.Height; y++)
            {
                for (int x = 0; x < bmp.Width; x++)
                {
                    var iPixel = bmp.GetPixel(x, y);
                    byte cPixel = (byte)(order[iPixel] & 0xF);

                    x++;
                    iPixel = bmp.GetPixel(x, y);
                    cPixel += (byte)(order[iPixel] << 0x4);
                    tim.Image.Data.Add(cPixel);
                }
            }

            tim.CLUT.Block[0] = CheckLength(tim.CLUT.Block[0], "4BPP");
            tim.CLUT.NumColors = 16;
            tim.CLUT.Length = tim.CLUT.NumColors * 2 + 0xC;
            MakeImageHeader(bmp);
            tim.Image.Width /= 4;
            return tim;
        }

        public static void MakeCLUTHeader(Bitmap bmp)
        {
            var block = TIMHandler.MakeCLUTBlock(bmp);
            CLUT clut = new();

            clut.NumCLUTs = 1;
            clut.Block.Add(block);
            clut.Length = block.Entries.Count;

            tim.CLUT = clut;
        }

        public static CLUTBlock CheckLength(CLUTBlock block, string type)
        {
            switch(type)
            {
                case "4BPP":
                    if (block.Entries.Count == 16)
                        break;
                    for (int i = block.Entries.Count; i < 16; i++)
                        block.Entries.Add(new CLUTEntry() { Entry = 0 });
                    break;

                case "8BPP":
                    if (block.Entries.Count == 256)
                        break;
                    for (int i = block.Entries.Count; i < 256; i++)
                        block.Entries.Add(new CLUTEntry() { Entry = 0 });
                    break;
            }

            return block;
        }

        public static void MakeImageHeader(Bitmap bmp)
        {
            tim.Image.Width = (ushort)bmp.Width;
            tim.Image.Height = (ushort)bmp.Height;
            tim.Image.Length = tim.Image.Data.Count + 0xC; 
        }
    }
}
