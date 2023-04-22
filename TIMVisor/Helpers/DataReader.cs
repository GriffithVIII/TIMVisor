using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIMVisor.Helpers
{
    public class DataReader
    {
        public static void Seek(BinaryReader reader, int offset)
        {
            reader.BaseStream.Position = offset;
        }
    }
}
