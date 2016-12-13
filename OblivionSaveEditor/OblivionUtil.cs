using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace OblivionSaveEditor
{
    public static class OblivionUtil
    {
        public static _SYSTEMTIME LoadSystemTime(Stream stream)
        {
            return LoadBinaryCompatible<_SYSTEMTIME>(stream);
        }

        public static _SCREENSHOT LoadScreenshot(Stream stream)
        {
            var ss = new _SCREENSHOT();
            ss.Load(stream);
            return ss;
        }

        public static _PCLOCATION LoadPCLocation(Stream stream)
        {
            return LoadBinaryCompatible<_PCLOCATION>(stream);
        }

        public static _GLOBALVARIABLE LoadGlobalVariable(Stream stream)
        {
            return LoadBinaryCompatible<_GLOBALVARIABLE>(stream);
        }

        public static _DEATHCOUNT LoadDeathCount(Stream stream)
        {
            return LoadBinaryCompatible<_DEATHCOUNT>(stream);
        }

        public static _CREATEDDATA LoadCreatedData(Stream stream)
        {
            var cd = new _CREATEDDATA();
            cd.Load(stream);
            return cd;
        }

        public static _QUICKKEYSDATA LoadQuickKeysData(Stream stream)
        {
            var qkd = new _QUICKKEYSDATA();
            qkd.Load(stream);
            return qkd;
        }

        public static _REGION LoadRegion(Stream stream)
        {
            return LoadBinaryCompatible<_REGION>(stream);
        }

        public static ChangeRecord LoadChangeRecord(Stream stream)
        {
            ChangeRecord cr = new ChangeRecord();
            cr.Load(stream);
            return cr;
        }

        public static string LoadString(Stream stream, int length)
        {
            byte[] buffer = new byte[length];
            stream.Read(buffer, 0, length);
            var encoding = Encoding.GetEncoding("Windows-1252");
            return encoding.GetString(buffer);
        }

        public static string LoadZString(Stream stream)
        {
            List<byte> bytes = new List<byte>();
            while(true)
            {
                int b = stream.ReadByte();
                if(b > 0)
                {
                    bytes.Add((byte)b);
                }
                else
                {
                    break;
                }
            }
            var encoding = Encoding.GetEncoding("Windows-1252");
            return encoding.GetString(bytes.ToArray());
        }

        public static string LoadBString(Stream stream)
        {
            byte len = (byte)stream.ReadByte();
            byte[] buffer = new byte[len];
            stream.Read(buffer, 0, len);
            var encoding = Encoding.GetEncoding("Windows-1252");
            return encoding.GetString(buffer);
        }

        public static string LoadBZString(Stream stream)
        {
            byte len = (byte)stream.ReadByte();
            byte[] buffer = new byte[len];
            stream.Read(buffer, 0, len);
            var encoding = Encoding.GetEncoding("Windows-1252");
            return encoding.GetString(buffer, 0, len - 1);//-1 to get rid of 0 terminator
        }

        public static T LoadBinaryCompatible<T>(Stream stream) where T : struct
        {
            byte size = (byte)Marshal.SizeOf<T>();
            byte[] buffer = new byte[size];
            stream.Read(buffer, 0, size);
            GCHandle handle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
            T retval = (T)Marshal.PtrToStructure<T>(handle.AddrOfPinnedObject());
            handle.Free();
            return retval;
        }
    }
}
