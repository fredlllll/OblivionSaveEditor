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

        }
    }
}
