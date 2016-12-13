using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OblivionSaveEditor
{
    public class SaveGameHeader
    {
        public uint headerVersion;
        public uint saveHeaderSize;
        public uint saveNum;
        public string pcName;
        public ushort pcLevel;
        public string pcLocation;
        public float gameDays;
        public uint gameTicks;
        public _SYSTEMTIME gameTime;
        public _SCREENSHOT screenshot;

        public void Load(Stream stream)
        {
            headerVersion = OblivionUtil.LoadBinaryCompatible<uint>(stream);
            saveHeaderSize = OblivionUtil.LoadBinaryCompatible<uint>(stream);
            saveNum = OblivionUtil.LoadBinaryCompatible<uint>(stream);
            pcName = OblivionUtil.LoadBZString(stream);
            pcLevel = OblivionUtil.LoadBinaryCompatible<ushort>(stream);
            pcLocation = OblivionUtil.LoadBZString(stream);
            gameDays = OblivionUtil.LoadBinaryCompatible<float>(stream);
            gameTicks = OblivionUtil.LoadBinaryCompatible<uint>(stream);

            gameTime = OblivionUtil.LoadSystemTime(stream);
            screenshot = OblivionUtil.LoadScreenshot(stream);
        }
    }
}
