using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFXIVTool.Utility
{
    public class MemoryManager
    {

        private static MemoryManager instance;
        /// <summary>
        /// Singleton instance of the MemoryManager
        /// </summary>
        public static MemoryManager Instance
        {
            get
            {
                // create an instance of the MemoryManager if the value is null
                if (instance == null)
                    instance = new MemoryManager();
                return instance;
            }
        }

        /// <summary>
        /// The mem instance
        /// </summary>
        private Mem memLib;
        public Mem MemLib
        {
            get => memLib;
        }

        public string BaseAddress { get; set; }
        public string CameraAddress { get; set; }
        public string GposeAddress { get; set; }
        public string TargetAddress { get; set; }
        public string WeatherAddress { get; set; }
        public string TimeAddress { get; set; }
        public string TerritoryAddress { get; set; }
        public string MusicOffset { get; set; }
        public string GposeFilters { get; set; }
        public string CharacterRenderAddress { get; set; }
        public string CharacterRenderAddress2 { get; set; }
        public string GposeEntityOffset { get; set; }
        /// <summary>
        /// Constructor for the singleton memory manager
        /// </summary>
        public MemoryManager()
        {
            // create a new instance of Mem
            memLib = new Mem();
        }

        /// <summary>
        /// Open the process in MemLib
        /// </summary>
        /// <param name="pid"></param>
        public void OpenProcess(int pid)
        {
            // open the process
            if (!memLib.OpenProcess(pid.ToString()))
                throw new Exception("Couldn't open process!");
        }

        /// <summary>
        /// Get a string for use in memlib
        /// </summary>
        /// <param name="offset"></param>
        /// <returns></returns>
        public bool IsReady()
        {
            return !memLib.theProc.HasExited;
        }
        public string GetBaseAddress(long offset)
        {
            return (memLib.theProc.MainModule.BaseAddress.ToInt64() + offset).ToString("X");
        }

        /// <summary>
        /// Returns if there is a process opened
        /// </summary>
        /// <returns></returns>

        /// <summary>
        /// Adds two hex strings together
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static string Add(string a, string b)
        {
            return (long.Parse(a, NumberStyles.HexNumber) + long.Parse(b, NumberStyles.HexNumber)).ToString("X");
        }

		public static string GetAddressString(string baseAddr, params string[] addr)
		{
			var ret = baseAddr + ",";

			foreach (var a in addr)
				ret += a + ",";

			return ret.TrimEnd(',');
		}

        public static string GetAddressString(params string[] addr)
        {
            var ret = "";

            foreach (var a in addr)
                ret += a + ",";

            return ret.TrimEnd(',');
        }
        public static string ByteArrayToString(byte[] ba)
        {
            if (ba != null)
            {
                StringBuilder hex = new StringBuilder(ba.Length * 2);
                foreach (byte b in ba)
                    hex.AppendFormat("{0:x2} ", b);
                var str = hex.ToString();
                return str.Remove(str.Length - 1);
            }
            else return "0";
        }
        public static string ByteArrayToStringU(byte[] ba)
        {
            if (ba != null)
            {
                StringBuilder hex = new StringBuilder(ba.Length * 2);
                foreach (byte b in ba)
                    hex.AppendFormat("{0:x2} ", b);
                var str = hex.ToString();
                var stre = str.ToUpper();
                return stre.Remove(stre.Length - 1);
            }
            else return "0";
        }
        public static byte[] StringToByteArray(String hex)
        {
            int NumberChars = hex.Length;
            byte[] bytes = new byte[NumberChars / 2];
            for (int i = 0; i < NumberChars; i += 2)
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            return bytes;
        }
    }
}
