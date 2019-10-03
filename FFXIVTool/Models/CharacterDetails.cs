using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFXIVTool.Models
{
    public class CharacterDetails : BaseModel
    {
        [JsonIgnore] private long size;
        [JsonIgnore]
        public long Size
        {
            get => size;
            set => size = value;
        }

        [JsonIgnore] private ObservableCollection<string> names;
        [JsonIgnore]
        public ObservableCollection<string> Names
        {
            get => names;
            set => names = value;
        }

        [JsonIgnore] private string selectedValue;
        [JsonIgnore]
        public string SelectedValue
        {
            get => selectedValue;
            set => selectedValue = value;
        }

        [JsonIgnore] private int selectedIndex;
        [JsonIgnore]
        public int SelectedIndex
        {
            get => selectedIndex;
            set => selectedIndex = value;
        }


        [JsonIgnore] public bool IsEnabled { get; set; }
        [JsonIgnore] public bool GposeMode { get; set; }
        [JsonIgnore] public Address<float> CharacterRender { get; set; }

		// Target Mode
		[JsonIgnore] private bool TargetMode { get; set; }
		[JsonIgnore] private bool GPoseTargetMode { get; set; } = true;
		[JsonIgnore] public bool TargetModeActive
		{
			get => GposeMode ? GPoseTargetMode : TargetMode;
			set
			{
				if (GposeMode)
					GPoseTargetMode = value;
				else
					TargetMode = value;
			}
		}

        public Address<float> TailSize { get; set; }
        [JsonIgnore] public Address<string> Name { get; set; }
        [JsonIgnore] public Address<string> FCTag { get; set; }
        [JsonIgnore] public Address<int> Title { get; set; }
        [JsonIgnore] public Address<byte> JobIco { get; set; }
        [JsonIgnore] public Address<int> EmoteOld { get; set; }
        [JsonIgnore] public Address<byte> Race { get; set; }
        [JsonIgnore] public Address<byte> Clan { get; set; }
        [JsonIgnore] public Address<byte> Gender { get; set; }
        [JsonIgnore] public Address<float> Wetness { get; set; }
        [JsonIgnore] public Address<float> SWetness { get; set; }
        public Address<float> Height { get; set; }
        public Address<float> BustX { get; set; }
        public Address<float> BustY { get; set; }
        public Address<float> BustZ { get; set; }

		// Position.
        [JsonIgnore] public Address<float> X { get; set; }
        [JsonIgnore] public Address<float> Y { get; set; }
        [JsonIgnore] public Address<float> Z { get; set; }
		// Advance move tool.
		[JsonIgnore] public bool AdvancedMove { get; set; } = false;

        [JsonIgnore] public Address<byte> Head { get; set; }
        [JsonIgnore] public Address<byte> Hair { get; set; }
        [JsonIgnore] public Address<byte> TailType { get; set; }
        [JsonIgnore] public Address<float> ScaleX { get; set; }
        [JsonIgnore] public Address<float> ScaleY { get; set; }
        [JsonIgnore] public Address<float> ScaleZ { get; set; }
        [JsonIgnore] public Address<byte> Jaw { get; set; }
        [JsonIgnore] public Address<byte> RHeight { get; set; }
        [JsonIgnore] public Address<byte> RBust { get; set; }
        [JsonIgnore] public Address<byte> HairTone { get; set; }
        [JsonIgnore] public Address<byte> Highlights { get; set; }
        [JsonIgnore] public Address<byte> HighlightTone { get; set; }
        [JsonIgnore] public Address<byte> Skintone { get; set; }
        [JsonIgnore] public Address<byte> FacialFeatures { get; set; }
        [JsonIgnore] public Address<int> Emote { get; set; }
        [JsonIgnore] public Address<float> EmoteSpeed1 { get; set; }
        [JsonIgnore] public Address<float> EmoteSpeed2 { get; set; }
        [JsonIgnore] public Address<byte> Eye { get; set; }
        [JsonIgnore] public Address<byte> RightEye { get; set; }
        [JsonIgnore] public Address<byte> LeftEye { get; set; }
        [JsonIgnore] public Address<byte> FacePaint { get; set; }
        [JsonIgnore] public Address<byte> FacePaintColor { get; set; }
        [JsonIgnore] public Address<byte> Nose { get; set; }
        [JsonIgnore] public Address<byte> Lips { get; set; }
        [JsonIgnore] public Address<byte> LipsTone { get; set; }
        [JsonIgnore] public Address<byte> EyeBrowType { get; set; }
        public Address<byte> Voices { get; set; }
        [JsonIgnore] public Address<byte> TailorMuscle { get; set; }
        [JsonIgnore] public Address<float> Rotation { get; set; }
        [JsonIgnore] public Address<float> Rotation2 { get; set; }
        [JsonIgnore] public Address<float> Rotation3 { get; set; }
        [JsonIgnore] public Address<float> Rotation4 { get; set; }
        [JsonIgnore] public Address<float> CameraHeight2 { get; set; }
        [JsonIgnore] public Address<float> CamX { get; set; }
        [JsonIgnore] public Address<float> CamY { get; set; }
        [JsonIgnore] public Address<float> CamZ { get; set; }
        [JsonIgnore] public Address<float> CamViewX { get; set; }
        [JsonIgnore] public Address<float> CamViewY { get; set; }
        [JsonIgnore] public Address<float> CamViewZ { get; set; }
        [JsonIgnore] public Address<float> Max { get; set; }
        [JsonIgnore] public Address<float> Min { get; set; }
        [JsonIgnore] public Address<float> CZoom { get; set; }
        [JsonIgnore] public Address<float> FOVC { get; set; }
        [JsonIgnore] public Address<float> FOVMAX { get; set; }
        [JsonIgnore] public Address<float> Transparency { get; set; }
        public Address<float> MuscleTone { get; set; }
        [JsonIgnore] public Address<int> Job { get; set; }
        [JsonIgnore] public Address<int> WeaponBase { get; set; }
        [JsonIgnore] public Address<byte> WeaponV { get; set; }
        [JsonIgnore] public Address<byte> WeaponDye { get; set; }
        public Address<float> WeaponX { get; set; }
        public Address<float> WeaponY { get; set; }
        public Address<float> WeaponZ { get; set; }
        [JsonIgnore] public Address<int> HeadPiece { get; set; }
        [JsonIgnore] public Address<byte> HeadV { get; set; }
        [JsonIgnore] public Address<byte> HeadDye { get; set; }
        [JsonIgnore] public Address<int> Chest { get; set; }
        [JsonIgnore] public Address<byte> ChestV { get; set; }
        [JsonIgnore] public Address<byte> ChestDye { get; set; }
        [JsonIgnore] public Address<int> Arms { get; set; }
        [JsonIgnore] public Address<byte> ArmsV { get; set; }
        [JsonIgnore] public Address<byte> ArmsDye { get; set; }
        [JsonIgnore] public Address<int> Legs { get; set; }
        [JsonIgnore] public Address<byte> LegsV { get; set; }
        [JsonIgnore] public Address<byte> LegsDye { get; set; }
        [JsonIgnore] public Address<int> Feet { get; set; }
        [JsonIgnore] public Address<byte> FeetVa { get; set; }
        [JsonIgnore] public Address<byte> FeetDye { get; set; }
        [JsonIgnore] public Address<int> Ear { get; set; }
        [JsonIgnore] public Address<byte> EarVa { get; set; }
        [JsonIgnore] public Address<int> Neck { get; set; }
        [JsonIgnore] public Address<byte> NeckVa { get; set; }
        [JsonIgnore] public Address<int> Wrist { get; set; }
        [JsonIgnore] public Address<byte> WristVa { get; set; }
        [JsonIgnore] public Address<int> RFinger { get; set; }
        [JsonIgnore] public Address<byte> RFingerVa { get; set; }
        [JsonIgnore] public Address<int> LFinger { get; set; }
        [JsonIgnore] public Address<int> Offhand { get; set; }
        [JsonIgnore] public Address<int> OffhandBase { get; set; }
        [JsonIgnore] public Address<byte> OffhandV { get; set; }
        [JsonIgnore] public Address<byte> OffhandDye { get; set; }
        public Address<float> OffhandX { get; set; }
        public Address<float> OffhandY { get; set; }
        public Address<float> OffhandZ { get; set; }
        public Address<float> OffhandRed { get; set; }
        public Address<float> OffhandGreen { get; set; }
        public Address<float> OffhandBlue { get; set; }
        [JsonIgnore] public Address<byte> LFingerVa { get; set; }
        public Address<float> WeaponRed { get; set; }
        public Address<float> WeaponGreen { get; set; }
        public Address<float> WeaponBlue { get; set; }
        public Address<float> SkinRedPigment { get; set; }
        public Address<float> SkinGreenPigment { get; set; }
        public Address<float> SkinBluePigment { get; set; }
        public Address<float> SkinRedGloss { get; set; }
        public Address<float> SkinGreenGloss { get; set; }
        public Address<float> SkinBlueGloss { get; set; }
        public Address<float> HairRedPigment { get; set; }
        public Address<float> HairGreenPigment { get; set; }
        public Address<float> HairBluePigment { get; set; }
        public Address<float> HairGlowRed { get; set; }
        public Address<float> HairGlowGreen { get; set; }
        public Address<float> HairGlowBlue { get; set; }
        public Address<float> HighlightRedPigment { get; set; }
        public Address<float> HighlightGreenPigment { get; set; }
        public Address<float> HighlightBluePigment { get; set; }
        public Address<float> LeftEyeRed { get; set; }
        public Address<float> LeftEyeGreen { get; set; }
        public Address<float> LeftEyeBlue { get; set; }
        public Address<float> RightEyeRed { get; set; }
        public Address<float> RightEyeGreen { get; set; }
        public Address<float> RightEyeBlue { get; set; }
        public Address<float> LipsBrightness { get; set; }
        public Address<float> LipsR { get; set; }
        public Address<float> LipsB { get; set; }
        public Address<float> LipsG { get; set; }
        public Address<float> LimbalR { get; set; }
        public Address<float> LimbalG { get; set; }
        public Address<float> LimbalB { get; set; }
        [JsonIgnore] public Address<byte> LimbalEyes { get; set; }
        [JsonIgnore] public Address<float> CameraYAMin { get; set; }
        [JsonIgnore] public Address<float> FOV2 { get; set; }
        [JsonIgnore] public Address<float> CameraYAMax { get; set; }
        [JsonIgnore] public Address<float> CameraUpDown { get; set; }
        [JsonIgnore] public Address<string> OffhandSlot { get; set; }
        [JsonIgnore] public Address<string> LFingerSlot { get; set; }
        [JsonIgnore] public Address<string> RFingerSlot { get; set; }
        [JsonIgnore] public Address<string> NeckSlot { get; set; }
        [JsonIgnore] public Address<string> WristSlot { get; set; }
        [JsonIgnore] public Address<string> EarSlot { get; set; }
        [JsonIgnore] public Address<string> WeaponSlot { get; set; }
        [JsonIgnore] public Address<string> LegSlot { get; set; }
        [JsonIgnore] public Address<string> FeetSlot { get; set; }
        [JsonIgnore] public Address<string> HeadSlot { get; set; }
        [JsonIgnore] public Address<string> BodySlot { get; set; }
        [JsonIgnore] public Address<string> ArmSlot { get; set; }
        [JsonIgnore] public Address<int> TimeControl { get; set; }
        [JsonIgnore] public Address<byte> Weather { get; set; }
        [JsonIgnore] public Address<byte> EntityType { get; set; }
        [JsonIgnore] public Address<int> Territoryxd { get; set; }
        [JsonIgnore] public Address<short> DataPath { get; set; }
        [JsonIgnore] public Address<short> NPCName { get; set; }
        [JsonIgnore] public Address<short> NPCModel { get; set; }
        [JsonIgnore] public Address<float> FreezeFacial { get; set; }
        [JsonIgnore] public Address<string> TestArray { get; set; } // Appereance
        [JsonIgnore] public Address<string> TestArray2 { get; set; } // Equipment
        [JsonIgnore] public Address<int> ModelType { get; set; } // Equipment
        [JsonIgnore] public Address<byte> BodyType { get; set; }
        [JsonIgnore] public Address<float> HDR { get; set; }
        [JsonIgnore] public Address<float> Brightness { get; set; }
        [JsonIgnore] public Address<string> FilterAoB { get; set; }
        [JsonIgnore] public Address<float> Contrast { get; set; }
        [JsonIgnore] public Address<float> Exposure { get; set; }
        [JsonIgnore] public Address<float> Filmic { get; set; }
        [JsonIgnore] public Address<float> SHDR { get; set; }
        [JsonIgnore] public Address<float> Colorfulness { get; set; }
        [JsonIgnore] public Address<float> Contrast2 { get; set; }
        [JsonIgnore] public Address<float> Colorfulnesss2 { get; set; }
        [JsonIgnore] public Address<float> Vibrance { get; set; }
        [JsonIgnore] public Address<float> Gamma { get; set; }
        [JsonIgnore] public Address<float> GBlue { get; set; }
        [JsonIgnore] public Address<float> GGreens { get; set; }
        [JsonIgnore] public Address<float> GRed { get; set; }
        [JsonIgnore] public Address<byte> FilterEnable { get; set; }
        [JsonIgnore] public Address<bool> LoadChecked { get; set; }
        [JsonIgnore] public Address<byte> EmoteIsPlayerFrozen { get; set; }
        [JsonIgnore] public Address<float> AltCheckPlayerFrozen { get; set; }
        [JsonIgnore] public Address<int> MusicBGM { get; set; }
        [JsonIgnore] public Address<float> CamAngleX { get; set; }
        [JsonIgnore] public Address<float> CamAngleY { get; set; }
        [JsonIgnore] public Address<byte> DataHead { get; set; }
        [JsonIgnore] public float RotateX { get; set; }
		[JsonIgnore] public float RotateY { get; set; }
		[JsonIgnore] public float RotateZ { get; set; }
		[JsonIgnore] public bool RotateFreeze { get; set; }

		public CharacterDetails()
        {
            CamAngleX = new Address<float>();
            CamAngleY = new Address<float>();
            MusicBGM = new Address<int>();
            AltCheckPlayerFrozen = new Address<float>();
            EmoteIsPlayerFrozen = new Address<byte>();
            LoadChecked = new Address<bool>();
            HDR = new Address<float>();
            Brightness = new Address<float>();
            FilterAoB = new Address<string>();
            FilterEnable = new Address<byte>();
            Contrast = new Address<float>();
            Exposure = new Address<float>();
            Filmic = new Address<float>();
            SHDR = new Address<float>();
            Colorfulness = new Address<float>();
            Contrast2 = new Address<float>();
            Colorfulnesss2 = new Address<float>();
            Vibrance = new Address<float>();
            Gamma = new Address<float>();
            GBlue = new Address<float>();
            GGreens = new Address<float>();
            GRed = new Address<float>();
            BodyType = new Address<byte>();
            LimbalEyes = new Address<byte>();
            ModelType = new Address<int>();
            TestArray2 = new Address<string>();
            TestArray = new Address<string>();
            EntityType = new Address<byte>();
            FreezeFacial = new Address<float>();
            Territoryxd = new Address<int>();
            DataPath = new Address<short>();
            NPCName = new Address<short>();
            NPCModel = new Address<short>();
            ScaleX = new Address<float>();
            ScaleY = new Address<float>();
            ScaleZ = new Address<float>();
            TailorMuscle = new Address<byte>();
            LimbalB = new Address<float>();
            LimbalG = new Address<float>();
            LimbalR = new Address<float>();
            RHeight = new Address<byte>();
            Transparency = new Address<float>();
            Jaw = new Address<byte>();
            RBust = new Address<byte>();
            Jaw = new Address<byte>();
            TimeControl = new Address<int>();
            Weather = new Address<byte>();
            LFingerSlot = new Address<string>();
            RFingerSlot = new Address<string>();
            NeckSlot = new Address<string>();
            WristSlot = new Address<string>();
            EarSlot = new Address<string>();
            WeaponSlot = new Address<string>();
            OffhandSlot = new Address<string>();
            FeetSlot = new Address<string>();
            LegSlot = new Address<string>();
            BodySlot = new Address<string>();
            ArmSlot = new Address<string>();
            HeadSlot = new Address<string>();
            OffhandBase = new Address<int>();
            OffhandV = new Address<byte>();
            EyeBrowType = new Address<byte>();
            OffhandDye = new Address<byte>();
            Offhand = new Address<int>();
            OffhandX = new Address<float>();
            OffhandY = new Address<float>();
            OffhandZ = new Address<float>();
            OffhandRed = new Address<float>();
            OffhandGreen = new Address<float>();
            OffhandBlue = new Address<float>();
            CameraUpDown = new Address<float>();
            Voices = new Address<byte>();
            CameraYAMin = new Address<float>();
            FOV2 = new Address<float>();
            CameraYAMax = new Address<float>();
            SkinRedPigment = new Address<float>();
            SkinGreenPigment = new Address<float>();
            SkinBluePigment = new Address<float>();
            SkinRedGloss = new Address<float>();
            SkinGreenGloss = new Address<float>();
            SkinBlueGloss = new Address<float>();
            HairRedPigment = new Address<float>();
            HairGreenPigment = new Address<float>();
            HairBluePigment = new Address<float>();
            HairGlowRed = new Address<float>();
            HairGlowGreen = new Address<float>();
            HairGlowBlue = new Address<float>();
            HighlightRedPigment = new Address<float>();
            HighlightGreenPigment = new Address<float>();
            HighlightBluePigment = new Address<float>();
            LeftEyeRed = new Address<float>();
            LeftEyeGreen = new Address<float>();
            LeftEyeBlue = new Address<float>();
            RightEyeRed = new Address<float>();
            RightEyeGreen = new Address<float>();
            RightEyeBlue = new Address<float>();
            LipsBrightness = new Address<float>();
            LipsR = new Address<float>();
            LipsG = new Address<float>();
            LipsB = new Address<float>();
            WeaponRed = new Address<float>();
            WeaponGreen = new Address<float>();
            WeaponBlue = new Address<float>();
            LFingerVa = new Address<byte>();
            LFinger = new Address<int>();
            RFingerVa = new Address<byte>();
            RFinger = new Address<int>();
            WristVa = new Address<byte>();
            Wrist = new Address<int>();
            NeckVa = new Address<byte>();
            Neck = new Address<int>();
            EarVa = new Address<byte>();
            Ear = new Address<int>();
            FeetDye = new Address<byte>();
            FeetVa = new Address<byte>();
            Feet = new Address<int>();
            LegsDye = new Address<byte>();
            LegsV = new Address<byte>();
            Legs = new Address<int>();
            ArmsDye = new Address<byte>();
            ArmsV = new Address<byte>();
            Arms = new Address<int>();
            ChestDye = new Address<byte>();
            ChestV = new Address<byte>();
            Chest = new Address<int>();
            HeadV = new Address<byte>();
            HeadDye = new Address<byte>();
            HeadPiece = new Address<int>();
            WeaponX = new Address<float>();
            WeaponY = new Address<float>();
            WeaponZ = new Address<float>();
            WeaponBase = new Address<int>();
            WeaponV = new Address<byte>();
            WeaponDye = new Address<byte>();
            Job = new Address<int>();
            MuscleTone = new Address<float>();
            Max = new Address<float>();
            Min = new Address<float>();
            CZoom = new Address<float>();
            FOVC = new Address<float>();
            FOVMAX = new Address<float>();
            CamX = new Address<float>();
            CamY = new Address<float>();
            CamZ = new Address<float>();
            CamViewX = new Address<float>();
            CamViewY = new Address<float>();
            CamViewZ = new Address<float>();
            CameraHeight2 = new Address<float>();
            CharacterRender = new Address<float>();
            Wetness = new Address<float>();
            SWetness = new Address<float>();
            Height = new Address<float>();
            TailSize = new Address<float>();
            Name = new Address<string>();
            FCTag = new Address<string>();
            Title = new Address<int>();
            JobIco = new Address<byte>();
            Head = new Address<byte>();
            Hair = new Address<byte>();
            Race = new Address<byte>();
            Clan = new Address<byte>();
            Gender = new Address<byte>();
            names = new ObservableCollection<string>();
            BustX = new Address<float>();
            BustY = new Address<float>();
            BustZ = new Address<float>();
            X = new Address<float>();
            Y = new Address<float>();
            Z = new Address<float>();
            Rotation = new Address<float>();
            Rotation2 = new Address<float>();
            Rotation3 = new Address<float>();
            Rotation4 = new Address<float>();
            HairTone = new Address<byte>();
            HairTone = new Address<byte>();
            Highlights = new Address<byte>();
            HighlightTone = new Address<byte>();
            EmoteOld = new Address<int>();
            Skintone = new Address<byte>();
            FacialFeatures = new Address<byte>();
            Eye = new Address<byte>();
            RightEye = new Address<byte>();
            LeftEye = new Address<byte>();
            FacePaint = new Address<byte>();
            FacePaintColor = new Address<byte>();
            Nose = new Address<byte>();
            Lips = new Address<byte>();
            LipsTone = new Address<byte>();
            TailType = new Address<byte>();
            Emote = new Address<int>();
            EmoteSpeed1 = new Address<float>();
            EmoteSpeed2 = new Address<float>();
            Max.Checker = true;
            Min.Checker = true;
            CZoom.Checker = true;
        }
    }
}