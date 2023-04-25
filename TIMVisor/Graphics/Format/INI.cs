using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIMVisor.Graphics.Format
{
    public class INI
    {
        public int BPP { get; set; }
        public TextureINI Texture { get; set; }
        public CLUTINI CLUT { get; set; }

        public INI()
        {
            Texture = new();
            CLUT = new();
        }
    }

    public class TextureINI
    {
        public UInt16 VRAM_X { get; set; }
        public UInt16 VRAM_Y { get; set; }
    }

    public class CLUTINI
    {
        public UInt16 VRAM_X { get; set; }
        public UInt16 VRAM_Y { get; set; }
        public List<string> OriginalPalette { get; set; }
        public CLUTINI()
        {
            OriginalPalette = new();
        }
    }
}
