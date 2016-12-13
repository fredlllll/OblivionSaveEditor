using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OblivionSaveEditor
{
    public class _SCREENSHOT
    {
        public uint size;
        public uint width;
        public uint height;
        public byte[] data;

        public void Load(Stream stream)
        {
            size = OblivionUtil.LoadBinaryCompatible<uint>(stream);
            width = OblivionUtil.LoadBinaryCompatible<uint>(stream);
            height = OblivionUtil.LoadBinaryCompatible<uint>(stream);
            data = new byte[3*width*height];
            stream.Read(data, 0, data.Length);
        }
    }
}
