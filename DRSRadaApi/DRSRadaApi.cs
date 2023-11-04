using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DRSRadaApi
{

   [StructLayout(LayoutKind.Sequential, Pack = 1)]
   public struct  TRACK_VERSION1
   {
        public float positionX;
        public float positionY;
        public float positionZ;
    }
}
