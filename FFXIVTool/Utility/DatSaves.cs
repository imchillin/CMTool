using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FFXIVTool.Utility
{
    class DatSaves
    {
        public readonly string Description;
        public readonly byte[] CustomizeBytes;

        public DatSaves(byte[] buffer)
        {
            using (MemoryStream stream = new MemoryStream(buffer))
            {
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    stream.Seek(0x10, SeekOrigin.Begin);

                    CustomizeBytes = reader.ReadBytes(26);

                    stream.Seek(0x30, SeekOrigin.Begin);

                    Description = Regex.Replace(Encoding.ASCII.GetString(reader.ReadBytes(164)), @"(?![ -~]|\r|\n).", "");
                    if (Description.Length <= 0) Description = "No Description.";
                }
            }
        }
    }
    static class MakeSaveDatList
    {

        public static List<DatSaves> Make()
        {
            List<DatSaves> output = new List<DatSaves>();

            string basePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "My Games",
                "FINAL FANTASY XIV - A Realm Reborn");

            if (!Directory.Exists(basePath))
                throw new Exception("Could not find FFXIV Directory: " + basePath);

            var files = Directory.GetFiles(basePath, "FFXIV_CHARA*.dat");

            foreach (var file in files)
            {
                output.Add(new DatSaves(File.ReadAllBytes(file)));
            }

            return output;
        }
    }
}
