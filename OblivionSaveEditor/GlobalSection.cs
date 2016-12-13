using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OblivionSaveEditor
{
    public class GlobalSection
    {
        public uint formIDsOffset;
        public uint recordsNum;
        public uint nextObjectID;
        public uint worldID;
        public uint worldX;
        public uint worldY;
        public _PCLOCATION pcLocation;

        public _GLOBALVARIABLE[] globalVariables;

        public ushort tesClassSize;

        public _DEATHCOUNT[] deathCounts;

        public float gameModeSeconds;

        public byte[] processesData;
        public byte[] specEventData;
        public byte[] weatherData;

        public uint playerCombatCount;

        public _CREATEDDATA[] createdData;
        public _QUICKKEYSDATA[] quickKeysData;

        public byte[] reticuleData;
        public byte[] interfaceData;

        public _REGION[] regions;

        public void Load(Stream stream)
        {
            formIDsOffset = OblivionUtil.LoadBinaryCompatible<uint>(stream);
            recordsNum = OblivionUtil.LoadBinaryCompatible<uint>(stream);
            nextObjectID = OblivionUtil.LoadBinaryCompatible<uint>(stream);
            worldID = OblivionUtil.LoadBinaryCompatible<uint>(stream);
            worldX = OblivionUtil.LoadBinaryCompatible<uint>(stream);
            worldY = OblivionUtil.LoadBinaryCompatible<uint>(stream);
            pcLocation = OblivionUtil.LoadPCLocation(stream);

            ushort globalsNum = OblivionUtil.LoadBinaryCompatible<ushort>(stream);
            globalVariables = new _GLOBALVARIABLE[globalsNum];
            for(int i = 0; i < globalsNum; i++)
            {
                globalVariables[i] = OblivionUtil.LoadGlobalVariable(stream);
            }

            tesClassSize = OblivionUtil.LoadBinaryCompatible<ushort>(stream);

            uint deathCountsNum = OblivionUtil.LoadBinaryCompatible<uint>(stream);
            deathCounts = new _DEATHCOUNT[deathCountsNum];
            for(int i = 0; i < deathCountsNum; i++)
            {
                deathCounts[i] = OblivionUtil.LoadDeathCount(stream);
            }

            gameModeSeconds = OblivionUtil.LoadBinaryCompatible<float>(stream);

            ushort processesSize = OblivionUtil.LoadBinaryCompatible<ushort>(stream);
            processesData = new byte[processesSize];
            stream.Read(processesData, 0, processesSize);

            ushort specEventSize = OblivionUtil.LoadBinaryCompatible<ushort>(stream);
            specEventData = new byte[specEventSize];
            stream.Read(specEventData, 0, specEventSize);

            ushort weatherSize = OblivionUtil.LoadBinaryCompatible<ushort>(stream);
            weatherData = new byte[weatherSize];
            stream.Read(weatherData, 0, weatherSize);

            playerCombatCount = OblivionUtil.LoadBinaryCompatible<uint>(stream);

            uint createdNum = OblivionUtil.LoadBinaryCompatible<uint>(stream);
            createdData = new _CREATEDDATA[createdNum];
            for(int i = 0; i < createdNum; i++)
            {
                createdData[i] = OblivionUtil.LoadCreatedData(stream);
            }

            ushort quickKeysNum = OblivionUtil.LoadBinaryCompatible<ushort>(stream);
            quickKeysData = new _QUICKKEYSDATA[quickKeysNum];
            for(int i = 0; i < quickKeysNum; i++)
            {
                quickKeysData[i] = OblivionUtil.LoadQuickKeysData(stream);
            }

            ushort reticuleSize = OblivionUtil.LoadBinaryCompatible<ushort>(stream);
            reticuleData = new byte[reticuleSize];
            stream.Read(reticuleData, 0, reticuleSize);

            ushort interfaceSize = OblivionUtil.LoadBinaryCompatible<ushort>(stream);
            interfaceData = new byte[interfaceSize];
            stream.Read(interfaceData, 0, interfaceSize);

            ushort regionsSize = OblivionUtil.LoadBinaryCompatible<ushort>(stream);
            ushort regionsNum =  OblivionUtil.LoadBinaryCompatible<ushort>(stream);
            regions = new _REGION[regionsNum];
            for(int i = 0; i < regionsNum; i++)
            {
                regions[i] = OblivionUtil.LoadRegion(stream);
            }
        }
    }
}
