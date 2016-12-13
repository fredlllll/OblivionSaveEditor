using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace OblivionSaveEditor
{
    [StructLayout(LayoutKind.Sequential)]
    public struct _REGION
    {
        public uint iref;
        public uint unknown6;
    }
}
