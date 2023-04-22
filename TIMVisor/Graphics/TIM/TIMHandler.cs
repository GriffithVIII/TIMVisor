using System;
using TIMVisor.Helpers;

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
    }
}
