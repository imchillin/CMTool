using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

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

        public string Theme { get; set; } = "Light";
        public string Primary { get; set; } = "Blue";
        public string Accent { get; set; } = "Blue";
        public bool TopApp { get; set; }  = false;
        public bool WindowsExplorer { get; set; } = false;
        public List<ExdCsvReader.Emote> FavoriteEmotes { get; set; } = new List<ExdCsvReader.Emote>();
    }
}
