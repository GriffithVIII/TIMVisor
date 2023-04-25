using TIMVisor.Graphics.Format;

namespace TIMVisor.Graphics.TIMLib
{
    public class TIMFactory
    {
        public static TIM Get4BPPTexture(string file)
        {
            return TIMDecoder.Decode4BPP(file);
        }

        public static TIM Get8BPPTexture(string file)
        {
            return TIMDecoder.Decode8BPP(file);
        }

        public static TIM Get16BPPTexture(string file)
        {
            return TIMDecoder.Decode16BPP(file);
        }

        public static TIM Get24BPPTexture(string file)
        {
            return TIMDecoder.Decode24BPP(file);
        }

        public static TIM Make4BPPTexture(Bitmap bmp)
        {
            return TIMEncoder.Encode4BPP(bmp);
        }

        public static TIM Make8BPPTexture(Bitmap bmp)
        {
            return TIMEncoder.Encode8BPP(bmp);
        }
    }
}
