using TIMVisor.Helpers;
using TIMVisor.Graphics.Format;

namespace TIMVisor.Graphics.TIMLib
{
    public class TIMDecoder
    {
        public static TIM tim = new();
        public static TIM Decode8BPP(string file)
        {
            FileInfo f = new(file);
            BinaryReader DR = new(f.OpenRead());

            ReadTIMHeader(DR);
            ReadCLUTHeader(DR);
            ReadImageHeader(DR);

            return tim;
        }

        public static TIM Decode4BPP(string file)
        {
            var tim = Decode8BPP(file);
            return tim;
        }

        public static TIM Decode16BPP(string file)
        {
            FileInfo f = new(file);
            BinaryReader DR = new(f.OpenRead());

            ReadTIMHeader(DR);
            ReadImageHeader(DR);

            return tim;
        }

        public static TIM Decode24BPP(string file)
        {
            var tim = Decode16BPP(file);
            return tim;
        }

        public static void ReadTIMHeader(BinaryReader DR)
        {
            DataReader.Seek(DR, 4);
            tim.Version = DR.ReadInt32();
        }

        public static void ReadImageHeader(BinaryReader DR)
        {
            Tex image = new();

            image.Length = DR.ReadInt32();
            image.VRAM_X = DR.ReadUInt16();
            image.VRAM_Y = DR.ReadUInt16();
            image.Width = DR.ReadUInt16();
            image.Height = DR.ReadUInt16();

            for (int i = 0; i < image.Length - 0xC; i++)
            {
                image.Data.Add(DR.ReadByte());
            }

            tim.Image = image;
        }

        public static void ReadCLUTHeader(BinaryReader DR)
        {
            CLUT clut = new();

            clut.Length = DR.ReadInt32();
            clut.VRAM_X = DR.ReadUInt16();
            clut.VRAM_Y = DR.ReadUInt16();
            clut.NumColors = DR.ReadUInt16();
            clut.NumCLUTs = DR.ReadUInt16();

            for (int i = 0; i < clut.NumCLUTs; i++)
            {
                CLUTBlock block = new();
                for (int u = 0; u < clut.NumColors; u++)
                {
                    UInt16 entry = DR.ReadUInt16();
                    block.Entries.Add(GetCLUTEntry(entry));
                }
                clut.Block.Add(block);
            }

            tim.CLUT = clut;
        }

        public static CLUTEntry GetCLUTEntry(UInt16 entry)
        {
            CLUTEntry cColor = new();
            cColor.Entry = entry;
            var color = cColor.Entry;

            cColor.R = (byte)((color >> 0) & 0x1f);
            cColor.G = (byte)((color >> 5) & 0x1f);
            cColor.B = (byte)((color >> 10) & 0x1f);
            cColor.STP = (byte)((color >> 15) & 1);

            return cColor;
        }
    }
}
