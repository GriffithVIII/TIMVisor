using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIMVisor.Helpers
{
    public class DataWriter
    {
        public static void Seek(BinaryWriter reader, int offset)
        {
            reader.BaseStream.Position = offset;
        }
    }
}
