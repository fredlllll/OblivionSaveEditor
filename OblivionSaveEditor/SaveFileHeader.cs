using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OblivionSaveEditor
{
    public class SaveFileHeader
    {
        public string fileID;
        public byte majorVersion;
        public byte minorVersion;
        public _SYSTEMTIME exeTime;

        public void Load(Stream stream)
        {
            byte[] buffer = new byte[12];
            stream.Read(buffer, 0, 12);
            fileID = Encoding.ASCII.GetString(buffer);
            majorVersion = (byte) stream.ReadByte();
            minorVersion = (byte)stream.ReadByte();
            exeTime = OblivionUtil.LoadSystemTime(stream);
        }
    }
}
