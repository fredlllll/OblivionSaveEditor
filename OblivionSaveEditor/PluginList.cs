using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OblivionSaveEditor
{
    public class PluginList
    {
        public string[] plugins;

        public void Load(Stream stream)
        {
            byte count = (byte)stream.ReadByte();
            plugins = new string[count];
            for(int i = 0; i < count; i++)
            {
                plugins[i] = OblivionUtil.LoadBString(stream);
            }
        }
    }
}
