using System.Drawing.Imaging;
using TIMVisor.Graphics.Format;

namespace TIMVisor.Graphics.PNG
{
    public class PNGFactory
    {
        public static Bitmap GetPNG8BPP(TIM tim)
        {
            var pal = PNGHandler.GetColors(tim.CLUT.Block[0]);
            Bitmap bmp = PNGEncoder.Encode8BPP(tim.Image, pal);
            return bmp;
        }

        public static Bitmap GetPNG4BPP(TIM tim)
        {
            var pal = PNGHandler.GetColors(tim.CLUT.Block[0]);
            Bitmap bmp = PNGEncoder.Encode4BPP(tim.Image, pal);
            return bmp;
        }

        public static Bitmap GetPNG16BPP(TIM tim)
        {
            Bitmap bmp = PNGEncoder.Encode16BPP(tim.Image);
            return bmp;
        }

        public static Bitmap GetPNG24BPP(TIM tim)
        {
            Bitmap bmp = PNGEncoder.Encode24BPP(tim.Image);
            return bmp;
        }

    }
}
