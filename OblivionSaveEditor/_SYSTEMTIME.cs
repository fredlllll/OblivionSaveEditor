using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace OblivionSaveEditor
{
    [StructLayout(LayoutKind.Sequential)]
    public struct _SYSTEMTIME
    {
        public short year, month, dayofweek, day, hour, minute, second, milliseconds;
    }
}
