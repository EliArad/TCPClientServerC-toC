using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TCPClientServerC_Api
{
    public class Utils
    {

        public static T StructFromByteArray<T>(byte[] bytes) where T : struct
        {
            int sz = Marshal.SizeOf(typeof(T));
            IntPtr buff = Marshal.AllocHGlobal(sz);
            Marshal.Copy(bytes, 0, buff, sz);
            T ret = (T)Marshal.PtrToStructure(buff, typeof(T));
            Marshal.FreeHGlobal(buff);
            return ret;
        }
 

        public static byte[] StructToByteArray<T>(T structVal) where T : struct
        {
            int size = Marshal.SizeOf(structVal);
            byte[] arr = new byte[size];
            IntPtr ptr = Marshal.AllocHGlobal(size);
            Marshal.StructureToPtr(structVal, ptr, true);
            Marshal.Copy(ptr, arr, 0, size);
            Marshal.FreeHGlobal(ptr);
            return arr;
        }
 
    }
}
