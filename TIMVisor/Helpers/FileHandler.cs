using System.IO;
using TIMVisor.Helpers;
using TIMVisor.Graphics.Format;
using TIMVisor.Graphics.TIMLib;
using TIMVisor.Graphics.PNG;
using System.Configuration;
using static System.Net.WebRequestMethods;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using System.Text;
using System.Collections.Generic;

namespace TIMVisor.Helpers
{
    public class TextureInfo
    {
        public FileInfo Info { get; set; }
        public string BPP { get; set; }
        public TextureInfo(FileInfo file, string bpp) 
        {
            Info = file;
            BPP = bpp;
        }
    }
    public class FileHandler
    {
        public static int[] filter = { 0, 1, 8, 9, 2, 3 };
        public static List<TextureInfo> FilterFolderFiles(string folder)
        {
            var files = Directory.GetFiles(folder).OrderBy(f => new FileInfo(f).CreationTime).ToArray();
            
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
                        FileInfo file = new FileInfo(path);
                        filtered.Add(new TextureInfo(file, bpp));
                    }
                }
                DR.Dispose();
            }

            return filtered;
        }

        public static TextureInfo FilterFile(string path)
        {
            FileInfo f = new(path);
            TextureInfo info = new(f, "");
            TIM tim = new TIM();
            BinaryReader DR = new(f.OpenRead());

            //# Check if the file is a TIM...
            DataReader.Seek(DR, 0);
            if (DR.ReadInt32() != tim.MagicNum)
                return null;

            int type = DR.ReadInt32();
            if (filter.Contains(type))
            {
                string bpp = TIMHandler.GetTypeBPP(DR, type);

                if (bpp != "UNSUPPORTED")
                {
                    info.BPP = bpp;
                }
            }
            DR.Dispose();

            return info;
        }

        public static (Bitmap, TIM) GetTIMConverted(string file, string type)
        {
            TIM tim = new();

            if (type == "4BPP")
            {
                tim = TIMFactory.Get4BPPTexture(file);
                Bitmap bmp = PNGFactory.GetPNG4BPP(tim);
                return (bmp, tim);
            }
            else if (type == "8BPP")
            {
                tim = TIMFactory.Get8BPPTexture(file);
                Bitmap bmp = PNGFactory.GetPNG8BPP(tim);
                return (bmp, tim);
            }
            else if (type == "16BPP")
            {
                tim = TIMFactory.Get16BPPTexture(file);
                Bitmap bmp = PNGFactory.GetPNG16BPP(tim);
                return (bmp, tim);
            }
            else if (type == "24BPP")
            {
                tim = TIMFactory.Get24BPPTexture(file);
                Bitmap bmp = PNGFactory.GetPNG24BPP(tim);
                return (bmp, tim);
            }

            return (null, null);
        }

        public static TIM GetPNGConverted(Bitmap bmp, INI ini)
        {
            TIM tim = new TIM();
            string type = $"{ini.BPP}BPP";

            if (type == "4BPP")
            {
                tim = TIMFactory.Make4BPPTexture(bmp);
                tim = TIMHandler.PreserveData(ini, tim);
                return tim;
            }
            else if (type == "8BPP")
            {
                tim = TIMFactory.Make8BPPTexture(bmp);
                tim = TIMHandler.PreserveData(ini, tim);
            }

            return tim;
        }

        public static void ExportTIM(TIM tim, string path)
        {
            FileInfo f = new(path);
            BinaryWriter DW = new(f.OpenWrite());

            DataWriter.Seek(DW, 0);

            //# TIM Header
            DW.Write(tim.MagicNum);
            DW.Write(tim.Version);

            //# CLUT Header
            var CLUT = tim.CLUT;
            DW.Write(CLUT.Length);
            DW.Write(CLUT.VRAM_X);
            DW.Write(CLUT.VRAM_Y);
            DW.Write(CLUT.NumColors);
            DW.Write(CLUT.NumCLUTs);
            foreach (CLUTEntry entry in CLUT.Block[0].Entries)
            {
                DW.Write(entry.Entry);
            }

            //# Texture Header
            var Texture = tim.Image;
            DW.Write(Texture.Length);
            DW.Write(Texture.VRAM_X);
            DW.Write(Texture.VRAM_Y);
            DW.Write(Texture.Width);
            DW.Write(Texture.Height);
            foreach (byte pixel in Texture.Data)
            {
                DW.Write(pixel);
            }

            DW.Flush();
            DW.Dispose();
        }
    }
}
