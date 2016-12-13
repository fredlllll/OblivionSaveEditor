using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OblivionSaveEditor
{
    public class _CREATEDDATA
    {
        public string type;
        public uint flags;
        public uint formID;
        public uint versionControlInfo;
        public byte[] data;

        public void Load(Stream stream)
        {
            //TODO: format same as modfilerecords
            type = OblivionUtil.LoadString(stream,4);

            uint dataSize = OblivionUtil.LoadBinaryCompatible<uint>(stream);
            flags = OblivionUtil.LoadBinaryCompatible<uint>(stream);
            formID = OblivionUtil.LoadBinaryCompatible<uint>(stream);
            versionControlInfo = OblivionUtil.LoadBinaryCompatible<uint>(stream);
            data = new byte[dataSize];
            stream.Read(data, 0, (int)dataSize);
        }
    }
}
