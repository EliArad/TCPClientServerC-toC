using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DRSRadaApi
{

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct DRSRadaHeader
    {        
        public uint messageCounter;
        public uint messageOpcode;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct  TRACK_VERSION1
    {
        public DRSRadaHeader header;
        public float positionX;
        public float positionY;
        public float positionZ;
    }


    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct MODE_REQUEST
    {
        public DRSRadaHeader header;
        public int mode;

    }
}
