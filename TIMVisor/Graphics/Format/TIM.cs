namespace TIMVisor.Graphics.Format
{
    public class TIM
    {
        public int MagicNum { get; set; }
        public int Version { get; set; }
        public CLUT CLUT { get; set; }
        public Pixel Image { get; set; }

        public TIM()
        {
            MagicNum = 0x00000010;
            CLUT = new();
            Image = new();
        }
    }

    public class Pixel
    {
        public int Length { get; set; }
        public UInt16 VRAM_X { get; set; }
        public UInt16 VRAM_Y { get; set; }
        public UInt16 Width { get; set; }
        public UInt16 Height { get; set; }
        public List<byte> Data { get; set; }

        public Pixel()
        {
            Data = new();
        }
    }

    public class CLUT
    {
        public int Length { get; set; }
        public UInt16 VRAM_X { get; set; }
        public UInt16 VRAM_Y { get; set; }
        public UInt16 NumColors { get; set; }
        public UInt16 NumCLUTs { get; set; }
        public List<CLUTBlock> Block { get; set; }

        public CLUT()
        {
            Block = new();
        }
    }

    public class CLUTBlock
    {
        public List<CLUTEntry> Entries { get; set; }

        public CLUTBlock()
        {
            Entries = new();
        }
    }

    public class CLUTEntry
    {
        public UInt16 Entry { get; set; }
        public byte STP { get; set; }
        public byte B { get; set; }
        public byte G { get; set; }
        public byte R { get; set; }
    }
}
