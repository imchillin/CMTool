using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFXIVTool.Utility
{
    public class CmpReader
    {
        public readonly List<Color> Colors = new List<Color>();

        // Thanks to Ioncannon
        public CmpReader(byte[] buffer)
        {
            int at = 0;
            while (at < buffer.Length)
            {
                int b = buffer[at + 2] & 0xFF;
                int g = buffer[at + 1] & 0xFF;
                int r = buffer[at + 0] & 0xFF;
                int a = buffer[at + 3] & 0xFF;
                Colors.Add(Color.FromArgb((a << 24) | (r << 16) | (g << 8) | b));

                at += 4;
            }
        }
    }
}