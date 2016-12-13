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

        public ChangeRecord[] records;

        public byte[] temporaryEffectsData;

        public uint[] formIDs;

        public uint[] worldSpaces;

        public void Load(Stream stream)
        {
            saveFileHeader.Load(stream);
            saveGameHeader.Load(stream);
            pluginList.Load(stream);
            globalSection.Load(stream);

            records = new ChangeRecord[globalSection.recordsNum];
            for(int i = 0; i < globalSection.recordsNum; i++)
            {
                records[i] = OblivionUtil.LoadChangeRecord(stream);
            }

            uint temporaryEffectsDataSize = OblivionUtil.LoadBinaryCompatible<uint>(stream);
            temporaryEffectsData = new byte[temporaryEffectsDataSize];
            stream.Read(temporaryEffectsData, 0, (int)temporaryEffectsDataSize);

            uint formIDsNum =  OblivionUtil.LoadBinaryCompatible<uint>(stream);
            formIDs = new uint[formIDsNum];
            for(int i = 0; i < formIDsNum; i++)
            {
                formIDs[i] = OblivionUtil.LoadBinaryCompatible<uint>(stream);
            }

            uint worldSpacesNum = OblivionUtil.LoadBinaryCompatible<uint>(stream);
            worldSpaces = new uint[worldSpacesNum];
            for(int i = 0; i < worldSpacesNum; i++)
            {
                worldSpaces[i] = OblivionUtil.LoadBinaryCompatible<uint>(stream);
            }

            //TODO: http://www.uesp.net/wiki/Tes4Mod:Save_File_Format
        }
    }
}
