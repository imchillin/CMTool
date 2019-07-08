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
        public readonly int CharacterSaveNumber;
        public readonly byte[] CustomizeBytes;

        public DatSaves(byte[] buffer, int filenum)
        {
            using (MemoryStream stream = new MemoryStream(buffer))
            {
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    CharacterSaveNumber = filenum;
               //     Console.WriteLine(ToReadableByteArray(reader.ReadBytes(255)));
                    //    Console.WriteLine(filenum);
                     stream.Seek(0x10, SeekOrigin.Begin);
                    ///  Console.WriteLine(ToReadableByteArray(reader.ReadBytes(26)));
                    CustomizeBytes = reader.ReadBytes(26);

                     stream.Seek(0x30, SeekOrigin.Begin);

                    Description = Regex.Replace(Encoding.ASCII.GetString(reader.ReadBytes(164)), @"(?![ -~]|\r|\n).", "");
                    if (Description.Length <= 0) Description = "No Description.";
                }
            }
        }
        static public string ToReadableByteArray(byte[] bytes)
        {
            return string.Join(", ", bytes);
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
            {
                System.Windows.MessageBox.Show("Could not find FFXIV Directory: " + basePath);
                return output;
            }
            

            var files = Directory.GetFiles(basePath, "FFXIV_CHARA_*.dat");

            foreach (var file in files)
            {
                string numeric = new String(Path.GetFileNameWithoutExtension(file).Where(Char.IsDigit).ToArray());
                int newnum = Int32.Parse(numeric);
                output.Add(new DatSaves(File.ReadAllBytes(file), newnum));
            }

            return output;
        }
    }
}
