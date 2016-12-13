using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OblivionSaveEditor
{
    public class _QUICKKEYSDATA
    {
        public bool flag;
        public uint iref;

        public void Load(Stream stream)
        {
            flag = stream.ReadByte() > 0;
            if(flag)
            {
                iref = OblivionUtil.LoadBinaryCompatible<uint>(stream);
            }
        }
    }
}
