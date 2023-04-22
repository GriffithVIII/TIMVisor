using System.IO;
using TIMVisor.Helpers;
using TIMVisor.Graphics.Format;
using TIMVisor.Graphics.TIMLib;

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

        public static string GetTIMConverted(string file, string type)
        {
            string a = "";
            TIM tim = new();
            //if (type == "4BPP")
            //{
            //    (var tim, var clut) = TIM_MSFactory.GetContainerConverted8BPP4BPP(path);
            //    Bitmap bmp = PNGFactory.GetPNG4BPP(tim, clut);
            //    DisplayConvertedTexture(bmp);
            //}
            if (type == "8BPP")
            {
                tim = TIMFactory.Get8BPPTexture(file);
                Bitmap bmp = PNGFactory.GetPNG8BPP(tim);
            }
            //else if (type == "16BPP")
            //{
            //    var tim = TIM_MSFactory.GetContainerConverted16BPP(path);
            //    Bitmap bmp = PNGFactory.GetImage16BPP(tim);
            //    DisplayConvertedTexture(bmp);
            //}
            //else if (type == "24BPP")
            //{
            //    var tim = TIM_MSFactory.GetContainerConverted16BPP(path);
            //    Bitmap bmp = PNGFactory.GetImage16BPP(tim);
            //    
            //}

            return a;
        }
    }
}
