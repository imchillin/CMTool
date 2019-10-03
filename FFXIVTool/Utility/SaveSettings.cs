using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using WepTuple = System.Tuple<int, int, int, int>;

namespace FFXIVTool.Utility
{
    public class SaveSettings
    {
        #region IO Boilerplate
        public static SaveSettings Default { get; } = Load();

        private static string FileName => Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "FFXIVTool", "settings.json");

        private static SaveSettings Load()
        {
            try
            {
                if (File.Exists(FileName))
                {
                    var text = File.ReadAllText(FileName);
                    return JsonConvert.DeserializeObject<SaveSettings>(text) ?? new SaveSettings();
                }
            }
            catch (Exception)
            {
                // Error reading settings.  Return default.
            }

            return new SaveSettings();
        }

        public void Save()
        {
            var path = Path.GetDirectoryName(FileName);
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            var text = JsonConvert.SerializeObject(this, Formatting.Indented);
            try
            {
                File.WriteAllText(FileName, text);
            }
            catch (IOException)
            {
                // Error saving settings.  Ignore.
            }
        }
        #endregion

        public string Theme { get; set; } = "Dark";
        public string Primary { get; set; } = "Blue";
        public string Accent { get; set; } = "Blue";
        public bool TopApp { get; set; }  = false;
        public bool WindowsExplorer { get; set; } = false;
        public bool KeepDyes { get; set; } = true;
        public bool ReminderTool { get; set; } = false;
        public int ClassIndex { get; set; } = 0;
        public float CamAngleX { get; set; } = 0;
        public float CamAngleY { get; set; } = 0;
        public bool RotationSliders { get; set; } = true;
        public string CharacterAoBBytes { get; set; } = "";
        public string EquipmentBytes { get; set; } = "";
        public WepTuple MainHandQuads { get; set; }
        public WepTuple OffHandQuads { get; set; }
        public List<ExdCsvReader.Emote> FavoriteEmotes { get; set; } = new List<ExdCsvReader.Emote>();
    }
}
