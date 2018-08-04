using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace com.youran.cheat
{
    class plug
    {
        #region   对windowsAPI的调用
        public const int PROCESS_ALL_ACCESS = 2035711;
        public const int PAGE_EXECUTE_READWRITE = 64;
        public const int PAGE_READWRITE = 4;
        private const int MEM_COMMIT = 0x1000;

        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        public static extern UInt32 GetWindowThreadProcessId(int hWnd,out UInt32 lpdwProcessId);
       
        [DllImport("Kernel32.dll")]
        public static extern int OpenProcess(
            uint dwDesiredAccess, //渴望得到的访问权限（标志）
            bool bInheritHandle, // 是否继承句柄
            uint dwProcessId// 进程标示符
            );



        [DllImport("Kernel32.dll")]
        public static extern bool CloseHandle(int hObject);

        [DllImport("Kernel32.dll")]
        public static extern void ReadProcessMemory(int handle, uint address, [Out] byte[] data, int size, [Out] int read);

        [DllImport("Kernel32.dll")]
        public static extern bool WriteProcessMemory(int hProcess, uint lpBaseAddress, byte[] lpBuffer, uint nSize, [Out] int lpNumberOfBytesWritten);

        [DllImport("kernel32.dll")]
        public static extern bool WriteProcessMemory(int hProcess, int lpBaseAddress, char[] lpBuffer, int nSize, [Out] int lpNumberOfBytesWritten);
        [DllImport("kernel32.dll")]
        public static extern int GetModuleHandle(string lpModuleName);
        [DllImport("kernel32.dll")]
        public static extern bool VirtualProtectEx(int hProcess, UInt32 lpAddress, UInt32 dwSize, UInt32 flNewProtect, [Out] UInt32 lpflOldProtect);
        [DllImport("kernel32.dll")]
        public static extern int VirtualAllocEx(int hProcess, int lpAddress, int dwSize, int flAllocationType=MEM_COMMIT, int flProtect=PAGE_READWRITE);
        [DllImport("kernel32.dll")]
        public static extern int GetProcAddress(int hModule, char [] funName);
        [DllImport("kernel32.dll")]
        public static extern int CreateRemoteThread(int hProcess, int lpThreadAttributes, int dwStackSize, int lpStartAddress, int lpParameter, int dwCreationFlags, int lpThreadId);
        [DllImport("kernel32.dll")]
        public static extern int GetLastError();



        #endregion

        #region 对部分Windows API的重写

        public static int OpenProcessByName(string lpClassName, string lpWindowName)
        {
            uint pid = 0;
            int hwnd = plug.FindWindow(lpClassName, lpWindowName).ToInt32();
            plug.GetWindowThreadProcessId(hwnd, out pid);
            return plug.OpenProcess(plug.PROCESS_ALL_ACCESS, false, pid);
        }

        public static void ReadProcessMemory(int handle, string mHexAddress, out Int32 value)
        {
            //将地址中的16进制转化为10进制
            //Int32 mDctAdress = Int32.Parse(mHexAddress, System.Globalization.NumberStyles.HexNumber);
            UInt32 mDctAdress = Convert.ToUInt32(mHexAddress, 16);
            byte[] data = new byte[4];
            int read = 0;
            ReadProcessMemory(handle, mDctAdress, data, 4, read);
            value = System.BitConverter.ToInt32(data, 0);
        }

        public static void ReadProcessMemory(int handle, string mHexAddress, out double value)
        {
            //将地址中的16进制转化为10进制
            //Int32 mDctAdress = Int32.Parse(mHexAddress, System.Globalization.NumberStyles.HexNumber);
            UInt32 mDctAdress = Convert.ToUInt32(mHexAddress, 16);
            byte[] data = new byte[8];
            int read = 0;
            ReadProcessMemory(handle, mDctAdress, data, 8, read);
            value = System.BitConverter.ToDouble(data, 0);
        }

        public static void ReadProcessMemory(int handle, string mHexAddress, out float value)
        {
            UInt32 mDctAdress = Convert.ToUInt32(mHexAddress, 16);
            byte[] data = new byte[4];
            int read = 0;
            ReadProcessMemory(handle, mDctAdress, data, 4, read);
            value = System.BitConverter.ToSingle(data, 4);
        }

        public static void ReadProcessMemory(int handle, string mHexAddress, out byte value)
        {
            UInt32 mDctAdress = Convert.ToUInt32(mHexAddress, 16);
            byte[] data = new byte[1];
            int read = 0;
            ReadProcessMemory(handle, mDctAdress, data, 1, read);
            value = data[0];
        }

        public static void ReadProcessMemory(int handle, string mHexAddress, out Int16 value)
        {
            UInt32 mDctAdress = Convert.ToUInt32(mHexAddress, 16);
            byte[] data = new byte[2];
            int read = 0;
            ReadProcessMemory(handle, mDctAdress, data, 2, read);
            value = System.BitConverter.ToInt16(data,0);
        }
        #endregion
        static public class ProcessTools
        {
            public static Int32 findWindow(string lpClassName, string lpWindowName)
            { 
                return FindWindow(lpClassName, lpWindowName).ToInt32();
            }

            public static uint getProcessID(int hwnd)
            {
                uint pid = 0;
                plug.GetWindowThreadProcessId(hwnd, out pid);
                return pid;
            }

            public static uint getProcessID(string lpClassName, string lpWindowName)
            {
                uint pid = 0;
                int hwnd = plug.FindWindow(lpClassName, lpWindowName).ToInt32();
                plug.GetWindowThreadProcessId(hwnd, out pid);
                return pid;
            }

            public static int OpenProcess(string lpClassName, string lpWindowName)
            {
                uint pid = 0;
                int hwnd = plug.FindWindow(lpClassName, lpWindowName).ToInt32();
                plug.GetWindowThreadProcessId(hwnd, out pid);
                return plug.OpenProcess(plug.PROCESS_ALL_ACCESS, false, pid);
            }

            public static int OpenProcess(int hwnd)
            {
                uint pid = 0;
                plug.GetWindowThreadProcessId(hwnd, out pid);
                return plug.OpenProcess(plug.PROCESS_ALL_ACCESS, false, pid);
            }

            public static bool CloseProcess(int handle)
            {
                return CloseHandle(handle);
            }

            public static int GetModuleAdress(string lpModuleName)
            { 
                return  GetModuleHandle(lpModuleName);
            }
        
        }
        static public class MemoryTools 
        {
            public static byte  readByte(int handle, string mHexAddress)
            {
                UInt32 mDctAdress = Convert.ToUInt32(mHexAddress, 16);
                byte[] data = new byte[1];
                int read = 0;
                ReadProcessMemory(handle, mDctAdress, data, 1, read);
                return data[0];             
            }
            public static byte readByte(int handle, string mHexAddress, params string[] offset)
            {
                byte value = 0;
                //获得起始地址
                Int32 buffer = readInt32(handle, mHexAddress);
                int i = 0;
                //偏移结果计算
                for (i = 0; i < offset.Length - 1; i++)
                {
                    buffer = readInt32(handle, (buffer + Convert.ToInt32(offset[i], 16)).ToString("x8"));
                }
                //获得目标值
                value = readByte(handle, (buffer + Convert.ToInt32(offset[i], 16)).ToString("x8"));
                return value;
            }
            public static Int16 readInt16(int handle, string mHexAddress)
            {
                UInt32 mDctAdress = Convert.ToUInt32(mHexAddress, 16);
                byte[] data = new byte[2];
                int read = 0;
                ReadProcessMemory(handle, mDctAdress, data, 2, read);
                return System.BitConverter.ToInt16(data, 0);
            }
            public static Int16 readInt16(int handle, string mHexAddress,params string[]offset)
            {
                Int16 value = 0;
                //获得起始地址
                Int32 buffer = readInt32(handle, mHexAddress);
                int i = 0;
                //偏移结果计算
                for (i = 0; i < offset.Length - 1; i++)
                {
                    buffer = readInt32(handle, (buffer + Convert.ToInt32(offset[i], 16)).ToString("x8"));
                }
                //获得目标值
                value = readInt16(handle, (buffer + Convert.ToInt32(offset[i], 16)).ToString("x8"));
                return value;
            }
            public static Int32 readInt32(int handle, string mHexAddress)
            {
                UInt32 mDctAdress = Convert.ToUInt32(mHexAddress, 16);
                byte[] data = new byte[4];
                int read = 0;
                ReadProcessMemory(handle, mDctAdress, data, 4, read);
                return System.BitConverter.ToInt32(data, 0);
            }

            public static Int32 readInt32(int handle, string mHexAddress,params string[] offset)
            {
                Int32 value = 0;
                //获得起始地址
                Int32 buffer = readInt32(handle, mHexAddress);
                int i = 0;
                //偏移结果计算
                for(i=0; i<offset.Length-1; i++)
                {
                    buffer = readInt32(handle, (buffer + Convert.ToInt32(offset[i], 16)).ToString("x8"));    
                }
                //获得目标值
                value = readInt32(handle, (buffer + Convert.ToInt32(offset[i], 16)).ToString("x8"));    
                return value;
            }
            public static float readFloat(int handle, string mHexAddress)
            {
                UInt32 mDctAdress = Convert.ToUInt32(mHexAddress, 16);
                byte[] data = new byte[4];
                int read = 0;
                ReadProcessMemory(handle, mDctAdress, data, 4, read);
                return System.BitConverter.ToSingle(data, 0);         
            }
            public static float readFloat(int handle, string mHexAddress, params string[] offset)
            {
                float value = 0;
                //获得起始地址
                Int32 buffer = readInt32(handle, mHexAddress);
                int i = 0;
                //偏移结果计算
                for (i = 0; i < offset.Length - 1; i++)
                {
                    buffer = readInt32(handle, (buffer + Convert.ToInt32(offset[i], 16)).ToString("x8"));
                }
                //获得目标值
                value = readFloat(handle, (buffer + Convert.ToInt32(offset[i], 16)).ToString("x8"));
                return value;
            }
            public static double readDouble(int handle, string mHexAddress)
            {
                UInt32 mDctAdress = Convert.ToUInt32(mHexAddress, 16);
                byte[] data = new byte[8];
                int read = 0;
                ReadProcessMemory(handle, mDctAdress, data, 8, read);
                return System.BitConverter.ToDouble(data, 0);
            }
            public static double readDouble(int handle, string mHexAddress, params string[] offset)
            {
                double value = 0;
                //获得起始地址
                Int32 buffer = readInt32(handle, mHexAddress);
                int i = 0;
                //偏移结果计算
                for (i = 0; i < offset.Length - 1; i++)
                {
                    buffer = readInt32(handle, (buffer + Convert.ToInt32(offset[i], 16)).ToString("x8"));
                }
                //获得目标值
                value = readDouble(handle, (buffer + Convert.ToInt32(offset[i], 16)).ToString("x8"));
                return value;
            }
            public static bool writeByte(int handle, string mHexAddress,byte value)
            {
                UInt32 mDctAdress = Convert.ToUInt32(mHexAddress, 16);
                int writeSize = 0;
                byte[]buffer = new byte[1];
                buffer[0] = value;
                return WriteProcessMemory(handle, mDctAdress, buffer, 1, writeSize);
            }
            public static bool writeByte(int handle, string mHexAddress, byte value, params string[] offset)
            {
                //获得起始地址
                Int32 buffer = readInt32(handle, mHexAddress);
                int i = 0;
                //偏移结果计算
                for (i = 0; i < offset.Length - 1; i++)
                {
                    buffer = readInt32(handle, (buffer + Convert.ToInt32(offset[i], 16)).ToString("x8"));
                }
                //获得目标值
                return writeByte(handle, (buffer + Convert.ToInt32(offset[i], 16)).ToString("x8"), value);           
            }

            public static bool writeInt16(int handle, string mHexAddress, Int16 value)
            {
                UInt32 mDctAdress = Convert.ToUInt32(mHexAddress, 16);
                int writeSize = 0;
                byte[] buffer = new byte[2];
                buffer = System.BitConverter.GetBytes(value);
                return WriteProcessMemory(handle, mDctAdress, buffer, 2, writeSize);            
            }

            public static bool writeInt16(int handle, string mHexAddress, Int16 value, params string[] offset)
            {
                //获得起始地址
                Int32 buffer = readInt32(handle, mHexAddress);
                int i = 0;
                //偏移结果计算
                for (i = 0; i < offset.Length - 1; i++)
                {
                    buffer = readInt32(handle, (buffer + Convert.ToInt32(offset[i], 16)).ToString("x8"));
                }
                //获得目标值
                return writeInt16(handle, (buffer + Convert.ToInt32(offset[i], 16)).ToString("x8"), value);            
            }
            public static bool writeInt32(int handle, string mHexAddress, Int32 value)
            {
                UInt32 mDctAdress = Convert.ToUInt32(mHexAddress, 16);
                int writeSize = 0;
                byte[] buffer = new byte[4];
                buffer = System.BitConverter.GetBytes(value);
                return WriteProcessMemory(handle, mDctAdress, buffer, 4, writeSize);
            }

            public static bool writeInt32(int handle, string mHexAddress, Int32 value,params string[] offset)
            {
                //获得起始地址
                Int32 buffer = readInt32(handle, mHexAddress);
                int i = 0;
                //偏移结果计算
                for (i = 0; i < offset.Length - 1; i++)
                {
                    buffer = readInt32(handle, (buffer + Convert.ToInt32(offset[i], 16)).ToString("x8"));
                }
                //获得目标值
                return writeInt32(handle, (buffer + Convert.ToInt32(offset[i], 16)).ToString("x8"), value);
            }
            public static bool writeFloat(int handle, string mHexAddress, float value)
            {
                UInt32 mDctAdress = Convert.ToUInt32(mHexAddress, 16);
                int writeSize = 0;
                byte[] buffer = new byte[4];
                buffer = System.BitConverter.GetBytes(value);
                return WriteProcessMemory(handle, mDctAdress, buffer, 4, writeSize);
            }
            public static bool writeFloat(int handle, string mHexAddress, float value, params string[] offset)
            {
                //获得起始地址
                Int32 buffer = readInt32(handle, mHexAddress);
                int i = 0;
                //偏移结果计算
                for (i = 0; i < offset.Length - 1; i++)
                {
                    buffer = readInt32(handle, (buffer + Convert.ToInt32(offset[i], 16)).ToString("x8"));
                }
                //获得目标值
                return writeFloat(handle, (buffer + Convert.ToInt32(offset[i], 16)).ToString("x8"), value);
            }
            public static bool writeDouble(int handle, string mHexAddress, double value)
            {
                UInt32 mDctAdress = Convert.ToUInt32(mHexAddress, 16);
                int writeSize = 0;
                byte[] buffer = new byte[8];
                buffer = System.BitConverter.GetBytes(value);
                return WriteProcessMemory(handle, mDctAdress, buffer, 8, writeSize);
            }
            public static bool writeDouble(int handle, string mHexAddress, double value, params string[] offset)
            {
                //获得起始地址
                Int32 buffer = readInt32(handle, mHexAddress);
                int i = 0;
                //偏移结果计算
                for (i = 0; i < offset.Length - 1; i++)
                {
                    buffer = readInt32(handle, (buffer + Convert.ToInt32(offset[i], 16)).ToString("x8"));
                }
                //获得目标值
                return writeDouble(handle, (buffer + Convert.ToInt32(offset[i], 16)).ToString("x8"), value);
            }
            
            //-----------------------------------------------------------------------------------------------------
            //方法名:setMemoryCanWrite
            //方法描述：使内存页可写，写默认为8个字节,返回修改前的内存页模式
            //-----------------------------------------------------------------------------------------------------
            public static UInt32 setMemoryCanWrite(int hProcess, string lpAdress, UInt32 size = 8)
            {
                UInt32 oldType = 0;
                UInt32 adress = Convert.ToUInt32(lpAdress, 16);
                VirtualProtectEx(hProcess,adress,size,PAGE_EXECUTE_READWRITE,oldType);
                return oldType;
            }

            public static UInt32 setMemoryType(int hProcess, string lpAdress, UInt32 type, UInt32 size = 8)
            {
                UInt32 oldType = 0;
                UInt32 adress = Convert.ToUInt32(lpAdress, 16);
                VirtualProtectEx(hProcess, adress, size, type, oldType);
                return oldType;
            }
        }
        static public class DLLTools
        {
            //通过远程线程注入Dll到目标进程
            public static bool injectDllByRemoteThread(int hwnd, string DllName)
            {
                string pFunName = "LoadLibraryA";
                //1.判断参数是否合法
                if (hwnd == 0 || DllName == null)
                {
                    return false;
                }
                //2.打开目标进程
                int handle = plug.ProcessTools.OpenProcess(hwnd);
                if (handle == 0)
                {
                    return false;
                }
                //3.计算注入文件的长度
                int nDllsize = DllName.Length + sizeof(char);
                //4.申请内存空间
                int pDlladdr = plug.VirtualAllocEx(handle, 0, nDllsize);
                //5.写入内存
                int num = 0;
                plug.WriteProcessMemory(handle, pDlladdr, DllName.ToCharArray(), nDllsize, num);
                int pFunAddr = plug.GetProcAddress(plug.GetModuleHandle("kernel32.dll"), pFunName.ToCharArray());
                //6.创建远程线程
                int hThread = plug.CreateRemoteThread(handle, 0, 0, pFunAddr, pDlladdr, 0, 0);
                plug.CloseHandle(hThread);
                plug.CloseHandle(handle);
                return true;
            }
        }


    }
    
}
