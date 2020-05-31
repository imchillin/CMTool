using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using WepTuple = System.Tuple<int, int, int, int>;

namespace ConceptMatrix.Utility
{
    public class SaveSettings
    {
        #region IO Boilerplate
        public static SaveSettings Default { get; } = Load();

        private static string FileName => Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "ConceptMatrix", "settings.json");

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

        public class CameraSettings
        {
            public string CMCVersion { get; set; } = "1.0";
            public float CurrentZoom { get; set; } = 0;
            public float FOV { get; set; } = 0;
            public float FOV2 { get; set; } = 0;
            // aka CameraHeight2
            public float CameraRotation { get; set; } = 0;
            public float CameraUpDown { get; set; } = 0;
            public float CamAngleX { get; set; } = 0;
            public float CamAngleY { get; set; } = 0;
            public float CamPanX { get; set; } = 0;
            public float CamPanY { get; set; } = 0;

            // Used to rotate Camera Angle X relative to Actor rotation
            public float TargetRotation { get; set; } = 0;

            // These are to help detect user errors loading things relative
            // to the wrong target.
            public string TargetRotationName { get; set; } = "None";
            public int TargetRotationRace { get; set; } = 0;
            public int TargetRotationClan { get; set; } = 0;
        }

        // Use the same type for character position and gpose view so
        // you can sync them to each other via loads if desired.
        public class LocationSettings
        {
            public string CMLVersion { get; set; } = "1.0";

            public float X { get; set; } = 0;
            public float Y { get; set; } = 0;
            public float Z { get; set; } = 0;

            public float OffsetFromViewX { get; set; } = 0;
            public float OffsetFromViewY { get; set; } = 0;
            public float OffsetFromViewZ { get; set; } = 0;
            // Used to rotate Actor relative to camera rotation
            public float OffsetFromCamX { get; set; } = 0;

            // Used to rotate GPose View position relative to Actor rotation
            public float TargetRotation { get; set; } = 0;

            // These are to help detect user errors loading things relative
            // to the wrong target.
            public string TargetRotationName { get; set; } = "None";
            public int TargetRotationRace { get; set; } = 0;
            public int TargetRotationClan { get; set; } = 0;


            public float Rotation1{ get; set; } = float.NaN;
            public float Rotation2 { get; set; } = float.NaN;
            public float Rotation3 { get; set; } = float.NaN;
            public float Rotation4 { get; set; } = float.NaN;

            public float OffsetX { get; set; } = float.NaN;
            public float OffsetY { get; set; } = float.NaN;
            public float OffsetZ { get; set; } = float.NaN;
        }

        public string Language { get; set; } = null;
        public string Theme { get; set; } = "Dark";
        public string Primary { get; set; } = "Blue";
        public string Accent { get; set; } = "Blue";
        public bool TopApp { get; set; }  = false;
        public bool WindowsExplorer { get; set; } = false;
        public bool FreezeLoadedValues { get; set; } = false;
        public bool KeepDyes { get; set; } = true;
        public bool UnfreezeOnGp { get; set; } = true;
        public bool ReminderTool { get; set; } = false;
        public int ClassIndex { get; set; } = 0;
        public bool RotationSliders { get; set; } = true;
        public bool AdvancedMove { get; set; } = true;
        public bool AltRotate { get; set; } = true;
        public bool AltPoseRotate { get; set; } = false;
        public bool RelativeBones { get; set; } = false;
        public bool AltModelView { get; set; } = false;
        public bool ScalingLoad { get; set; } = false;
        public float BoneInterval { get; set; } = (float)0.10;
        public bool KeepModelType { get; set; } = true;
        public bool HasBackground { get; set; } = true;
        public string ProfileDirectory { get; set; } = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDoc‌​uments), App.ToolBin, "Saves");
        public string MatrixPoseDirectory { get; set; } = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDoc‌​uments), App.ToolBin, "Matrix Saves");
        public string GearsetsDirectory { get; set; } = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDoc‌​uments), App.ToolBin, "Gearsets");

        public string MatrixPoseSaveLoadDirectory { get; set; } = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDoc‌​uments), App.ToolBin, "Matrix Saves");

        public string CharacterAoBBytes { get; set; } = "";
        public string EquipmentBytes { get; set; } = "";
        public WepTuple MainHandQuads { get; set; }
        public WepTuple OffHandQuads { get; set; }
        public List<ExdCsvReader.Emote> FavoriteEmotes { get; set; } = new List<ExdCsvReader.Emote>();

        public CameraSettings LastCameraSave { get; set; }
        public double UITransparency { get; set; } = 1000;
    }
}
