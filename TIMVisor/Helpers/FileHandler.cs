using System.IO;
using TIMVisor.Helpers;
using TIMVisor.Graphics.Format;
using TIMVisor.Graphics.TIMLib;
using TIMVisor.Graphics.PNG;

namespace TIMVisor.Helpers
{
    public class TextureInfo
    {
        public FileInfo Info { get; set; }
        public string BPP { get; set; }
    }
    public class FileHandler
    {
        public static List<TextureInfo> FilterFolderFiles(string folder)
        {
            var files = Directory.GetFiles(folder).OrderBy(f => new FileInfo(f).CreationTime).ToArray();
            int[] filter = { 0, 1, 8, 9, 2, 3 };
            List<TextureInfo> filtered = new();
            TIM tim = new TIM();

            foreach (string path in files)
            {
                FileInfo f = new(path);
                BinaryReader DR = new(f.OpenRead());

                //# Check if the file is a TIM...
                DataReader.Seek(DR, 0);
                if (DR.ReadInt32() != tim.MagicNum)
                    continue;

                int type = DR.ReadInt32();
                if (filter.Contains(type))
                {
                    string bpp = TIMHandler.GetTypeBPP(DR, type);
                
                    if (bpp != "UNSUPPORTED")
                    {
                        filtered.Add(new TextureInfo()
                        {
                            Info = new FileInfo(path),
                            BPP = bpp
                        });
                    }
                }
                DR.Dispose();
            }

            return filtered;
        }

        public static Bitmap GetTIMConverted(string file, string type)
        {
            TIM tim = new();
            if (type == "4BPP")
            {
                tim = TIMFactory.Get4BPPTexture(file);
                Bitmap bmp = PNGFactory.GetPNG4BPP(tim);
                return bmp;
            }
            else if (type == "8BPP")
            {
                tim = TIMFactory.Get8BPPTexture(file);
                Bitmap bmp = PNGFactory.GetPNG8BPP(tim);
                return bmp;
            }
            else if (type == "16BPP")
            {
                tim = TIMFactory.Get16BPPTexture(file);
                Bitmap bmp = PNGFactory.GetPNG16BPP(tim);
                return bmp;
            }
            else if (type == "24BPP")
            {
                tim = TIMFactory.Get24BPPTexture(file);
                Bitmap bmp = PNGFactory.GetPNG24BPP(tim);
                return bmp;
            }

            return null;
        }
    }
}
