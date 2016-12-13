using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OblivionSaveEditor
{
    public class SaveFile
    {
        public SaveFileHeader saveFileHeader = new SaveFileHeader();
        public SaveGameHeader saveGameHeader = new SaveGameHeader();
        public PluginList pluginList = new PluginList();
        public GlobalSection globalSection = new GlobalSection();

        public void Load(Stream stream)
        {
            saveFileHeader.Load(stream);
            saveGameHeader.Load(stream);
            pluginList.Load(stream);
            globalSection.Load(stream);

            //TODO: http://www.uesp.net/wiki/Tes4Mod:Save_File_Format
        }
    }
}
