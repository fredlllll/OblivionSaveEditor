using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OblivionSaveEditor
{
    public enum ChangeRecordType : byte
    {
        FACT = 6,
        APPA = 19,
        ARMO = 20,
        BOOK = 21,
        CLOT = 22,
        INGR = 25,
        LIGH = 26,
        MISC = 27,
        WEAP = 33,
        AMMO = 34,
        NPC_ = 35,
        CREA = 36,
        SLGM = 38,
        KEYM = 39,
        ALCH = 40,
        CELL = 48,
        REFR = 49,
        ACHR = 50,
        ACRE = 51,
        INFO = 58,
        QUST = 59,
        PACK = 61
    }

    /*[Flags]
    public enum ChangeRecordFlags : uint
    {
        FormFlags = 1 << 2,
        BaseHealth = 1 << 3,
        BaseAttributes = 1 << 4,
        SpellList = 1 << 5,
        Factions = 1 << 6,
        Skills = 1 << 9,
        BaseModifiers = 1 << 28,
    }*/

    public class ChangeRecord
    {
        public uint formID;
        public ChangeRecordType type;
        public uint flags;
        public byte version;
        public byte[] data;

        public void Load(Stream stream)
        {
            formID = OblivionUtil.LoadBinaryCompatible<uint>(stream);
            type = (ChangeRecordType)OblivionUtil.LoadBinaryCompatible<byte>(stream);
            flags = OblivionUtil.LoadBinaryCompatible<uint>(stream);
            version = (byte)stream.ReadByte();

            ushort dataSize = OblivionUtil.LoadBinaryCompatible<ushort>(stream);
            data = new byte[dataSize];
            stream.Read(data, 0, dataSize);
        }
    }
}
