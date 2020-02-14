using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptMatrix.Models
{
    public class LinkedActorInfo
    {
        public string Name;

        public string DataOffset;

        public float X;
        public float Y;
        public float Z;

        public float Rotation1;
        public float Rotation2;
        public float Rotation3;
        public float Rotation4;
    }

    public class CharacterDetails : BaseModel
    {
        [JsonIgnore]
        public List<LinkedActorInfo> LinkedActors { get; set; } = new List<LinkedActorInfo>();

        [JsonIgnore] public bool IsLinked { get; set; } = false;

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
        [JsonIgnore]
        public bool TargetModeActive
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
        [JsonIgnore] public Address<float> FaceCamX { get; set; }
        [JsonIgnore] public Address<float> FaceCamY { get; set; }
        [JsonIgnore] public Address<float> FaceCamZ { get; set; }
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
        [JsonIgnore] public Address<ushort> ForceWeather { get; set; }
        [JsonIgnore] public Address<byte> EntityType { get; set; }
        [JsonIgnore] public Address<int> Territoryxd { get; set; }
        [JsonIgnore] public Address<short> DataPath { get; set; }
        [JsonIgnore] public Address<short> NPCName { get; set; }
        [JsonIgnore] public Address<short> NPCModel { get; set; }
        [JsonIgnore] public Address<short> StatusEffect { get; set; }
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
        [JsonIgnore] public Address<float> CamPanX { get; set; }
        [JsonIgnore] public Address<float> CamPanY { get; set; }
        [JsonIgnore] public Address<byte> DataHead { get; set; }
        [JsonIgnore] public float RotateX { get; set; }
        [JsonIgnore] public float RotateY { get; set; }
        [JsonIgnore] public float RotateZ { get; set; }
        [JsonIgnore] public float BoneX { get; set; }
        [JsonIgnore] public float BoneY { get; set; }
        [JsonIgnore] public float BoneZ { get; set; }

        [JsonIgnore] public bool RotateFreeze { get; set; }
        [JsonIgnore] public bool BoneEditMode { get; set; }

        #region Bone
        [JsonIgnore] public Address<float> CubeBone_X { get; set; }
        [JsonIgnore] public Address<float> CubeBone_Y { get; set; }
        [JsonIgnore] public Address<float> CubeBone_Z { get; set; }
        [JsonIgnore] public Address<float> CubeBone_W { get; set; }

        [JsonIgnore] public Address<float> Root_X { get; set; }
        [JsonIgnore] public Address<float> Root_Y { get; set; }
        [JsonIgnore] public Address<float> Root_Z { get; set; }
        [JsonIgnore] public Address<float> Root_W { get; set; }
        [JsonIgnore] public Address<float> Abdomen_X { get; set; }
        [JsonIgnore] public Address<float> Abdomen_Y { get; set; }
        [JsonIgnore] public Address<float> Abdomen_Z { get; set; }
        [JsonIgnore] public Address<float> Abdomen_W { get; set; }
        [JsonIgnore] public Address<float> Throw_X { get; set; }
        [JsonIgnore] public Address<float> Throw_Y { get; set; }
        [JsonIgnore] public Address<float> Throw_Z { get; set; }
        [JsonIgnore] public Address<float> Throw_W { get; set; }
        [JsonIgnore] public Address<float> Waist_X { get; set; }
        [JsonIgnore] public Address<float> Waist_Y { get; set; }
        [JsonIgnore] public Address<float> Waist_Z { get; set; }
        [JsonIgnore] public Address<float> Waist_W { get; set; }
        [JsonIgnore] public Address<float> SpineA_X { get; set; }
        [JsonIgnore] public Address<float> SpineA_Y { get; set; }
        [JsonIgnore] public Address<float> SpineA_Z { get; set; }
        [JsonIgnore] public Address<float> SpineA_W { get; set; }
        [JsonIgnore] public Address<float> LegLeft_X { get; set; }
        [JsonIgnore] public Address<float> LegLeft_Y { get; set; }
        [JsonIgnore] public Address<float> LegLeft_Z { get; set; }
        [JsonIgnore] public Address<float> LegLeft_W { get; set; }
        [JsonIgnore] public Address<float> LegRight_X { get; set; }
        [JsonIgnore] public Address<float> LegRight_Y { get; set; }
        [JsonIgnore] public Address<float> LegRight_Z { get; set; }
        [JsonIgnore] public Address<float> LegRight_W { get; set; }
        [JsonIgnore] public Address<float> HolsterLeft_X { get; set; }
        [JsonIgnore] public Address<float> HolsterLeft_Y { get; set; }
        [JsonIgnore] public Address<float> HolsterLeft_Z { get; set; }
        [JsonIgnore] public Address<float> HolsterLeft_W { get; set; }
        [JsonIgnore] public Address<float> HolsterRight_X { get; set; }
        [JsonIgnore] public Address<float> HolsterRight_Y { get; set; }
        [JsonIgnore] public Address<float> HolsterRight_Z { get; set; }
        [JsonIgnore] public Address<float> HolsterRight_W { get; set; }
        [JsonIgnore] public Address<float> SheatheLeft_X { get; set; }
        [JsonIgnore] public Address<float> SheatheLeft_Y { get; set; }
        [JsonIgnore] public Address<float> SheatheLeft_Z { get; set; }
        [JsonIgnore] public Address<float> SheatheLeft_W { get; set; }
        [JsonIgnore] public Address<float> SheatheRight_X { get; set; }
        [JsonIgnore] public Address<float> SheatheRight_Y { get; set; }
        [JsonIgnore] public Address<float> SheatheRight_Z { get; set; }
        [JsonIgnore] public Address<float> SheatheRight_W { get; set; }
        [JsonIgnore] public Address<float> SpineB_X { get; set; }
        [JsonIgnore] public Address<float> SpineB_Y { get; set; }
        [JsonIgnore] public Address<float> SpineB_Z { get; set; }
        [JsonIgnore] public Address<float> SpineB_W { get; set; }
        [JsonIgnore] public Address<float> ClothBackALeft_X { get; set; }
        [JsonIgnore] public Address<float> ClothBackALeft_Y { get; set; }
        [JsonIgnore] public Address<float> ClothBackALeft_Z { get; set; }
        [JsonIgnore] public Address<float> ClothBackALeft_W { get; set; }
        [JsonIgnore] public Address<float> ClothBackARight_X { get; set; }
        [JsonIgnore] public Address<float> ClothBackARight_Y { get; set; }
        [JsonIgnore] public Address<float> ClothBackARight_Z { get; set; }
        [JsonIgnore] public Address<float> ClothBackARight_W { get; set; }
        [JsonIgnore] public Address<float> ClothFrontALeft_X { get; set; }
        [JsonIgnore] public Address<float> ClothFrontALeft_Y { get; set; }
        [JsonIgnore] public Address<float> ClothFrontALeft_Z { get; set; }
        [JsonIgnore] public Address<float> ClothFrontALeft_W { get; set; }
        [JsonIgnore] public Address<float> ClothFrontARight_X { get; set; }
        [JsonIgnore] public Address<float> ClothFrontARight_Y { get; set; }
        [JsonIgnore] public Address<float> ClothFrontARight_Z { get; set; }
        [JsonIgnore] public Address<float> ClothFrontARight_W { get; set; }
        [JsonIgnore] public Address<float> ClothSideALeft_X { get; set; }
        [JsonIgnore] public Address<float> ClothSideALeft_Y { get; set; }
        [JsonIgnore] public Address<float> ClothSideALeft_Z { get; set; }
        [JsonIgnore] public Address<float> ClothSideALeft_W { get; set; }
        [JsonIgnore] public Address<float> ClothSideARight_X { get; set; }
        [JsonIgnore] public Address<float> ClothSideARight_Y { get; set; }
        [JsonIgnore] public Address<float> ClothSideARight_Z { get; set; }
        [JsonIgnore] public Address<float> ClothSideARight_W { get; set; }
        [JsonIgnore] public Address<float> KneeLeft_X { get; set; }
        [JsonIgnore] public Address<float> KneeLeft_Y { get; set; }
        [JsonIgnore] public Address<float> KneeLeft_Z { get; set; }
        [JsonIgnore] public Address<float> KneeLeft_W { get; set; }
        [JsonIgnore] public Address<float> KneeRight_X { get; set; }
        [JsonIgnore] public Address<float> KneeRight_Y { get; set; }
        [JsonIgnore] public Address<float> KneeRight_Z { get; set; }
        [JsonIgnore] public Address<float> KneeRight_W { get; set; }
        [JsonIgnore] public Address<float> BreastLeft_X { get; set; }
        [JsonIgnore] public Address<float> BreastLeft_Y { get; set; }
        [JsonIgnore] public Address<float> BreastLeft_Z { get; set; }
        [JsonIgnore] public Address<float> BreastLeft_W { get; set; }
        [JsonIgnore] public Address<float> BreastRight_X { get; set; }
        [JsonIgnore] public Address<float> BreastRight_Y { get; set; }
        [JsonIgnore] public Address<float> BreastRight_Z { get; set; }
        [JsonIgnore] public Address<float> BreastRight_W { get; set; }
        [JsonIgnore] public Address<float> SpineC_X { get; set; }
        [JsonIgnore] public Address<float> SpineC_Y { get; set; }
        [JsonIgnore] public Address<float> SpineC_Z { get; set; }
        [JsonIgnore] public Address<float> SpineC_W { get; set; }
        [JsonIgnore] public Address<float> ClothBackBLeft_X { get; set; }
        [JsonIgnore] public Address<float> ClothBackBLeft_Y { get; set; }
        [JsonIgnore] public Address<float> ClothBackBLeft_Z { get; set; }
        [JsonIgnore] public Address<float> ClothBackBLeft_W { get; set; }
        [JsonIgnore] public Address<float> ClothBackBRight_X { get; set; }
        [JsonIgnore] public Address<float> ClothBackBRight_Y { get; set; }
        [JsonIgnore] public Address<float> ClothBackBRight_Z { get; set; }
        [JsonIgnore] public Address<float> ClothBackBRight_W { get; set; }
        [JsonIgnore] public Address<float> ClothFrontBLeft_X { get; set; }
        [JsonIgnore] public Address<float> ClothFrontBLeft_Y { get; set; }
        [JsonIgnore] public Address<float> ClothFrontBLeft_Z { get; set; }
        [JsonIgnore] public Address<float> ClothFrontBLeft_W { get; set; }
        [JsonIgnore] public Address<float> ClothFrontBRight_X { get; set; }
        [JsonIgnore] public Address<float> ClothFrontBRight_Y { get; set; }
        [JsonIgnore] public Address<float> ClothFrontBRight_Z { get; set; }
        [JsonIgnore] public Address<float> ClothFrontBRight_W { get; set; }
        [JsonIgnore] public Address<float> ClothSideBLeft_X { get; set; }
        [JsonIgnore] public Address<float> ClothSideBLeft_Y { get; set; }
        [JsonIgnore] public Address<float> ClothSideBLeft_Z { get; set; }
        [JsonIgnore] public Address<float> ClothSideBLeft_W { get; set; }
        [JsonIgnore] public Address<float> ClothSideBRight_X { get; set; }
        [JsonIgnore] public Address<float> ClothSideBRight_Y { get; set; }
        [JsonIgnore] public Address<float> ClothSideBRight_Z { get; set; }
        [JsonIgnore] public Address<float> ClothSideBRight_W { get; set; }
        [JsonIgnore] public Address<float> CalfLeft_X { get; set; }
        [JsonIgnore] public Address<float> CalfLeft_Y { get; set; }
        [JsonIgnore] public Address<float> CalfLeft_Z { get; set; }
        [JsonIgnore] public Address<float> CalfLeft_W { get; set; }
        [JsonIgnore] public Address<float> CalfRight_X { get; set; }
        [JsonIgnore] public Address<float> CalfRight_Y { get; set; }
        [JsonIgnore] public Address<float> CalfRight_Z { get; set; }
        [JsonIgnore] public Address<float> CalfRight_W { get; set; }
        [JsonIgnore] public Address<float> ScabbardLeft_X { get; set; }
        [JsonIgnore] public Address<float> ScabbardLeft_Y { get; set; }
        [JsonIgnore] public Address<float> ScabbardLeft_Z { get; set; }
        [JsonIgnore] public Address<float> ScabbardLeft_W { get; set; }
        [JsonIgnore] public Address<float> ScabbardRight_X { get; set; }
        [JsonIgnore] public Address<float> ScabbardRight_Y { get; set; }
        [JsonIgnore] public Address<float> ScabbardRight_Z { get; set; }
        [JsonIgnore] public Address<float> ScabbardRight_W { get; set; }
        [JsonIgnore] public Address<float> Neck_X { get; set; }
        [JsonIgnore] public Address<float> Neck_Y { get; set; }
        [JsonIgnore] public Address<float> Neck_Z { get; set; }
        [JsonIgnore] public Address<float> Neck_W { get; set; }
        [JsonIgnore] public Address<float> ClavicleLeft_X { get; set; }
        [JsonIgnore] public Address<float> ClavicleLeft_Y { get; set; }
        [JsonIgnore] public Address<float> ClavicleLeft_Z { get; set; }
        [JsonIgnore] public Address<float> ClavicleLeft_W { get; set; }
        [JsonIgnore] public Address<float> ClavicleRight_X { get; set; }
        [JsonIgnore] public Address<float> ClavicleRight_Y { get; set; }
        [JsonIgnore] public Address<float> ClavicleRight_Z { get; set; }
        [JsonIgnore] public Address<float> ClavicleRight_W { get; set; }
        [JsonIgnore] public Address<float> ClothBackCLeft_X { get; set; }
        [JsonIgnore] public Address<float> ClothBackCLeft_Y { get; set; }
        [JsonIgnore] public Address<float> ClothBackCLeft_Z { get; set; }
        [JsonIgnore] public Address<float> ClothBackCLeft_W { get; set; }
        [JsonIgnore] public Address<float> ClothBackCRight_X { get; set; }
        [JsonIgnore] public Address<float> ClothBackCRight_Y { get; set; }
        [JsonIgnore] public Address<float> ClothBackCRight_Z { get; set; }
        [JsonIgnore] public Address<float> ClothBackCRight_W { get; set; }
        [JsonIgnore] public Address<float> ClothFrontCLeft_X { get; set; }
        [JsonIgnore] public Address<float> ClothFrontCLeft_Y { get; set; }
        [JsonIgnore] public Address<float> ClothFrontCLeft_Z { get; set; }
        [JsonIgnore] public Address<float> ClothFrontCLeft_W { get; set; }
        [JsonIgnore] public Address<float> ClothFrontCRight_X { get; set; }
        [JsonIgnore] public Address<float> ClothFrontCRight_Y { get; set; }
        [JsonIgnore] public Address<float> ClothFrontCRight_Z { get; set; }
        [JsonIgnore] public Address<float> ClothFrontCRight_W { get; set; }
        [JsonIgnore] public Address<float> ClothSideCLeft_X { get; set; }
        [JsonIgnore] public Address<float> ClothSideCLeft_Y { get; set; }
        [JsonIgnore] public Address<float> ClothSideCLeft_Z { get; set; }
        [JsonIgnore] public Address<float> ClothSideCLeft_W { get; set; }
        [JsonIgnore] public Address<float> ClothSideCRight_X { get; set; }
        [JsonIgnore] public Address<float> ClothSideCRight_Y { get; set; }
        [JsonIgnore] public Address<float> ClothSideCRight_Z { get; set; }
        [JsonIgnore] public Address<float> ClothSideCRight_W { get; set; }
        [JsonIgnore] public Address<float> PoleynLeft_X { get; set; }
        [JsonIgnore] public Address<float> PoleynLeft_Y { get; set; }
        [JsonIgnore] public Address<float> PoleynLeft_Z { get; set; }
        [JsonIgnore] public Address<float> PoleynLeft_W { get; set; }
        [JsonIgnore] public Address<float> PoleynRight_X { get; set; }
        [JsonIgnore] public Address<float> PoleynRight_Y { get; set; }
        [JsonIgnore] public Address<float> PoleynRight_Z { get; set; }
        [JsonIgnore] public Address<float> PoleynRight_W { get; set; }
        [JsonIgnore] public Address<float> FootLeft_X { get; set; }
        [JsonIgnore] public Address<float> FootLeft_Y { get; set; }
        [JsonIgnore] public Address<float> FootLeft_Z { get; set; }
        [JsonIgnore] public Address<float> FootLeft_W { get; set; }
        [JsonIgnore] public Address<float> FootRight_X { get; set; }
        [JsonIgnore] public Address<float> FootRight_Y { get; set; }
        [JsonIgnore] public Address<float> FootRight_Z { get; set; }
        [JsonIgnore] public Address<float> FootRight_W { get; set; }
        [JsonIgnore] public Address<float> Head_X { get; set; }
        [JsonIgnore] public Address<float> Head_Y { get; set; }
        [JsonIgnore] public Address<float> Head_Z { get; set; }
        [JsonIgnore] public Address<float> Head_W { get; set; }
        [JsonIgnore] public Address<float> ArmLeft_X { get; set; }
        [JsonIgnore] public Address<float> ArmLeft_Y { get; set; }
        [JsonIgnore] public Address<float> ArmLeft_Z { get; set; }
        [JsonIgnore] public Address<float> ArmLeft_W { get; set; }
        [JsonIgnore] public Address<float> ArmRight_X { get; set; }
        [JsonIgnore] public Address<float> ArmRight_Y { get; set; }
        [JsonIgnore] public Address<float> ArmRight_Z { get; set; }
        [JsonIgnore] public Address<float> ArmRight_W { get; set; }
        [JsonIgnore] public Address<float> PauldronLeft_X { get; set; }
        [JsonIgnore] public Address<float> PauldronLeft_Y { get; set; }
        [JsonIgnore] public Address<float> PauldronLeft_Z { get; set; }
        [JsonIgnore] public Address<float> PauldronLeft_W { get; set; }
        [JsonIgnore] public Address<float> PauldronRight_X { get; set; }
        [JsonIgnore] public Address<float> PauldronRight_Y { get; set; }
        [JsonIgnore] public Address<float> PauldronRight_Z { get; set; }
        [JsonIgnore] public Address<float> PauldronRight_W { get; set; }
        [JsonIgnore] public Address<float> Unknown00_X { get; set; }
        [JsonIgnore] public Address<float> Unknown00_Y { get; set; }
        [JsonIgnore] public Address<float> Unknown00_Z { get; set; }
        [JsonIgnore] public Address<float> Unknown00_W { get; set; }
        [JsonIgnore] public Address<float> ToesLeft_X { get; set; }
        [JsonIgnore] public Address<float> ToesLeft_Y { get; set; }
        [JsonIgnore] public Address<float> ToesLeft_Z { get; set; }
        [JsonIgnore] public Address<float> ToesLeft_W { get; set; }
        [JsonIgnore] public Address<float> ToesRight_X { get; set; }
        [JsonIgnore] public Address<float> ToesRight_Y { get; set; }
        [JsonIgnore] public Address<float> ToesRight_Z { get; set; }
        [JsonIgnore] public Address<float> ToesRight_W { get; set; }
        [JsonIgnore] public Address<float> HairA_X { get; set; }
        [JsonIgnore] public Address<float> HairA_Y { get; set; }
        [JsonIgnore] public Address<float> HairA_Z { get; set; }
        [JsonIgnore] public Address<float> HairA_W { get; set; }
        [JsonIgnore] public Address<float> HairFrontLeft_X { get; set; }
        [JsonIgnore] public Address<float> HairFrontLeft_Y { get; set; }
        [JsonIgnore] public Address<float> HairFrontLeft_Z { get; set; }
        [JsonIgnore] public Address<float> HairFrontLeft_W { get; set; }
        [JsonIgnore] public Address<float> HairFrontRight_X { get; set; }
        [JsonIgnore] public Address<float> HairFrontRight_Y { get; set; }
        [JsonIgnore] public Address<float> HairFrontRight_Z { get; set; }
        [JsonIgnore] public Address<float> HairFrontRight_W { get; set; }
        [JsonIgnore] public Address<float> EarLeft_X { get; set; }
        [JsonIgnore] public Address<float> EarLeft_Y { get; set; }
        [JsonIgnore] public Address<float> EarLeft_Z { get; set; }
        [JsonIgnore] public Address<float> EarLeft_W { get; set; }
        [JsonIgnore] public Address<float> EarRight_X { get; set; }
        [JsonIgnore] public Address<float> EarRight_Y { get; set; }
        [JsonIgnore] public Address<float> EarRight_Z { get; set; }
        [JsonIgnore] public Address<float> EarRight_W { get; set; }
        [JsonIgnore] public Address<float> ForearmLeft_X { get; set; }
        [JsonIgnore] public Address<float> ForearmLeft_Y { get; set; }
        [JsonIgnore] public Address<float> ForearmLeft_Z { get; set; }
        [JsonIgnore] public Address<float> ForearmLeft_W { get; set; }
        [JsonIgnore] public Address<float> ForearmRight_X { get; set; }
        [JsonIgnore] public Address<float> ForearmRight_Y { get; set; }
        [JsonIgnore] public Address<float> ForearmRight_Z { get; set; }
        [JsonIgnore] public Address<float> ForearmRight_W { get; set; }
        [JsonIgnore] public Address<float> ShoulderLeft_X { get; set; }
        [JsonIgnore] public Address<float> ShoulderLeft_Y { get; set; }
        [JsonIgnore] public Address<float> ShoulderLeft_Z { get; set; }
        [JsonIgnore] public Address<float> ShoulderLeft_W { get; set; }
        [JsonIgnore] public Address<float> ShoulderRight_X { get; set; }
        [JsonIgnore] public Address<float> ShoulderRight_Y { get; set; }
        [JsonIgnore] public Address<float> ShoulderRight_Z { get; set; }
        [JsonIgnore] public Address<float> ShoulderRight_W { get; set; }
        [JsonIgnore] public Address<float> HairB_X { get; set; }
        [JsonIgnore] public Address<float> HairB_Y { get; set; }
        [JsonIgnore] public Address<float> HairB_Z { get; set; }
        [JsonIgnore] public Address<float> HairB_W { get; set; }
        [JsonIgnore] public Address<float> HandLeft_X { get; set; }
        [JsonIgnore] public Address<float> HandLeft_Y { get; set; }
        [JsonIgnore] public Address<float> HandLeft_Z { get; set; }
        [JsonIgnore] public Address<float> HandLeft_W { get; set; }
        [JsonIgnore] public Address<float> HandRight_X { get; set; }
        [JsonIgnore] public Address<float> HandRight_Y { get; set; }
        [JsonIgnore] public Address<float> HandRight_Z { get; set; }
        [JsonIgnore] public Address<float> HandRight_W { get; set; }
        [JsonIgnore] public Address<float> ShieldLeft_X { get; set; }
        [JsonIgnore] public Address<float> ShieldLeft_Y { get; set; }
        [JsonIgnore] public Address<float> ShieldLeft_Z { get; set; }
        [JsonIgnore] public Address<float> ShieldLeft_W { get; set; }
        [JsonIgnore] public Address<float> ShieldRight_X { get; set; }
        [JsonIgnore] public Address<float> ShieldRight_Y { get; set; }
        [JsonIgnore] public Address<float> ShieldRight_Z { get; set; }
        [JsonIgnore] public Address<float> ShieldRight_W { get; set; }
        [JsonIgnore] public Address<float> EarringALeft_X { get; set; }
        [JsonIgnore] public Address<float> EarringALeft_Y { get; set; }
        [JsonIgnore] public Address<float> EarringALeft_Z { get; set; }
        [JsonIgnore] public Address<float> EarringALeft_W { get; set; }
        [JsonIgnore] public Address<float> EarringARight_X { get; set; }
        [JsonIgnore] public Address<float> EarringARight_Y { get; set; }
        [JsonIgnore] public Address<float> EarringARight_Z { get; set; }
        [JsonIgnore] public Address<float> EarringARight_W { get; set; }
        [JsonIgnore] public Address<float> ElbowLeft_X { get; set; }
        [JsonIgnore] public Address<float> ElbowLeft_Y { get; set; }
        [JsonIgnore] public Address<float> ElbowLeft_Z { get; set; }
        [JsonIgnore] public Address<float> ElbowLeft_W { get; set; }
        [JsonIgnore] public Address<float> ElbowRight_X { get; set; }
        [JsonIgnore] public Address<float> ElbowRight_Y { get; set; }
        [JsonIgnore] public Address<float> ElbowRight_Z { get; set; }
        [JsonIgnore] public Address<float> ElbowRight_W { get; set; }
        [JsonIgnore] public Address<float> CouterLeft_X { get; set; }
        [JsonIgnore] public Address<float> CouterLeft_Y { get; set; }
        [JsonIgnore] public Address<float> CouterLeft_Z { get; set; }
        [JsonIgnore] public Address<float> CouterLeft_W { get; set; }
        [JsonIgnore] public Address<float> CouterRight_X { get; set; }
        [JsonIgnore] public Address<float> CouterRight_Y { get; set; }
        [JsonIgnore] public Address<float> CouterRight_Z { get; set; }
        [JsonIgnore] public Address<float> CouterRight_W { get; set; }
        [JsonIgnore] public Address<float> WristLeft_X { get; set; }
        [JsonIgnore] public Address<float> WristLeft_Y { get; set; }
        [JsonIgnore] public Address<float> WristLeft_Z { get; set; }
        [JsonIgnore] public Address<float> WristLeft_W { get; set; }
        [JsonIgnore] public Address<float> WristRight_X { get; set; }
        [JsonIgnore] public Address<float> WristRight_Y { get; set; }
        [JsonIgnore] public Address<float> WristRight_Z { get; set; }
        [JsonIgnore] public Address<float> WristRight_W { get; set; }
        [JsonIgnore] public Address<float> IndexALeft_X { get; set; }
        [JsonIgnore] public Address<float> IndexALeft_Y { get; set; }
        [JsonIgnore] public Address<float> IndexALeft_Z { get; set; }
        [JsonIgnore] public Address<float> IndexALeft_W { get; set; }
        [JsonIgnore] public Address<float> IndexARight_X { get; set; }
        [JsonIgnore] public Address<float> IndexARight_Y { get; set; }
        [JsonIgnore] public Address<float> IndexARight_Z { get; set; }
        [JsonIgnore] public Address<float> IndexARight_W { get; set; }
        [JsonIgnore] public Address<float> PinkyALeft_X { get; set; }
        [JsonIgnore] public Address<float> PinkyALeft_Y { get; set; }
        [JsonIgnore] public Address<float> PinkyALeft_Z { get; set; }
        [JsonIgnore] public Address<float> PinkyALeft_W { get; set; }
        [JsonIgnore] public Address<float> PinkyARight_X { get; set; }
        [JsonIgnore] public Address<float> PinkyARight_Y { get; set; }
        [JsonIgnore] public Address<float> PinkyARight_Z { get; set; }
        [JsonIgnore] public Address<float> PinkyARight_W { get; set; }
        [JsonIgnore] public Address<float> RingALeft_X { get; set; }
        [JsonIgnore] public Address<float> RingALeft_Y { get; set; }
        [JsonIgnore] public Address<float> RingALeft_Z { get; set; }
        [JsonIgnore] public Address<float> RingALeft_W { get; set; }
        [JsonIgnore] public Address<float> RingARight_X { get; set; }
        [JsonIgnore] public Address<float> RingARight_Y { get; set; }
        [JsonIgnore] public Address<float> RingARight_Z { get; set; }
        [JsonIgnore] public Address<float> RingARight_W { get; set; }
        [JsonIgnore] public Address<float> MiddleALeft_X { get; set; }
        [JsonIgnore] public Address<float> MiddleALeft_Y { get; set; }
        [JsonIgnore] public Address<float> MiddleALeft_Z { get; set; }
        [JsonIgnore] public Address<float> MiddleALeft_W { get; set; }
        [JsonIgnore] public Address<float> MiddleARight_X { get; set; }
        [JsonIgnore] public Address<float> MiddleARight_Y { get; set; }
        [JsonIgnore] public Address<float> MiddleARight_Z { get; set; }
        [JsonIgnore] public Address<float> MiddleARight_W { get; set; }
        [JsonIgnore] public Address<float> ThumbALeft_X { get; set; }
        [JsonIgnore] public Address<float> ThumbALeft_Y { get; set; }
        [JsonIgnore] public Address<float> ThumbALeft_Z { get; set; }
        [JsonIgnore] public Address<float> ThumbALeft_W { get; set; }
        [JsonIgnore] public Address<float> ThumbARight_X { get; set; }
        [JsonIgnore] public Address<float> ThumbARight_Y { get; set; }
        [JsonIgnore] public Address<float> ThumbARight_Z { get; set; }
        [JsonIgnore] public Address<float> ThumbARight_W { get; set; }
        [JsonIgnore] public Address<float> WeaponLeft_X { get; set; }
        [JsonIgnore] public Address<float> WeaponLeft_Y { get; set; }
        [JsonIgnore] public Address<float> WeaponLeft_Z { get; set; }
        [JsonIgnore] public Address<float> WeaponLeft_W { get; set; }
        [JsonIgnore] public Address<float> WeaponRight_X { get; set; }
        [JsonIgnore] public Address<float> WeaponRight_Y { get; set; }
        [JsonIgnore] public Address<float> WeaponRight_Z { get; set; }
        [JsonIgnore] public Address<float> WeaponRight_W { get; set; }
        [JsonIgnore] public Address<float> EarringBLeft_X { get; set; }
        [JsonIgnore] public Address<float> EarringBLeft_Y { get; set; }
        [JsonIgnore] public Address<float> EarringBLeft_Z { get; set; }
        [JsonIgnore] public Address<float> EarringBLeft_W { get; set; }
        [JsonIgnore] public Address<float> EarringBRight_X { get; set; }
        [JsonIgnore] public Address<float> EarringBRight_Y { get; set; }
        [JsonIgnore] public Address<float> EarringBRight_Z { get; set; }
        [JsonIgnore] public Address<float> EarringBRight_W { get; set; }
        [JsonIgnore] public Address<float> IndexBLeft_X { get; set; }
        [JsonIgnore] public Address<float> IndexBLeft_Y { get; set; }
        [JsonIgnore] public Address<float> IndexBLeft_Z { get; set; }
        [JsonIgnore] public Address<float> IndexBLeft_W { get; set; }
        [JsonIgnore] public Address<float> IndexBRight_X { get; set; }
        [JsonIgnore] public Address<float> IndexBRight_Y { get; set; }
        [JsonIgnore] public Address<float> IndexBRight_Z { get; set; }
        [JsonIgnore] public Address<float> IndexBRight_W { get; set; }
        [JsonIgnore] public Address<float> PinkyBLeft_X { get; set; }
        [JsonIgnore] public Address<float> PinkyBLeft_Y { get; set; }
        [JsonIgnore] public Address<float> PinkyBLeft_Z { get; set; }
        [JsonIgnore] public Address<float> PinkyBLeft_W { get; set; }
        [JsonIgnore] public Address<float> PinkyBRight_X { get; set; }
        [JsonIgnore] public Address<float> PinkyBRight_Y { get; set; }
        [JsonIgnore] public Address<float> PinkyBRight_Z { get; set; }
        [JsonIgnore] public Address<float> PinkyBRight_W { get; set; }
        [JsonIgnore] public Address<float> RingBLeft_X { get; set; }
        [JsonIgnore] public Address<float> RingBLeft_Y { get; set; }
        [JsonIgnore] public Address<float> RingBLeft_Z { get; set; }
        [JsonIgnore] public Address<float> RingBLeft_W { get; set; }
        [JsonIgnore] public Address<float> RingBRight_X { get; set; }
        [JsonIgnore] public Address<float> RingBRight_Y { get; set; }
        [JsonIgnore] public Address<float> RingBRight_Z { get; set; }
        [JsonIgnore] public Address<float> RingBRight_W { get; set; }
        [JsonIgnore] public Address<float> MiddleBLeft_X { get; set; }
        [JsonIgnore] public Address<float> MiddleBLeft_Y { get; set; }
        [JsonIgnore] public Address<float> MiddleBLeft_Z { get; set; }
        [JsonIgnore] public Address<float> MiddleBLeft_W { get; set; }
        [JsonIgnore] public Address<float> MiddleBRight_X { get; set; }
        [JsonIgnore] public Address<float> MiddleBRight_Y { get; set; }
        [JsonIgnore] public Address<float> MiddleBRight_Z { get; set; }
        [JsonIgnore] public Address<float> MiddleBRight_W { get; set; }
        [JsonIgnore] public Address<float> ThumbBLeft_X { get; set; }
        [JsonIgnore] public Address<float> ThumbBLeft_Y { get; set; }
        [JsonIgnore] public Address<float> ThumbBLeft_Z { get; set; }
        [JsonIgnore] public Address<float> ThumbBLeft_W { get; set; }
        [JsonIgnore] public Address<float> ThumbBRight_X { get; set; }
        [JsonIgnore] public Address<float> ThumbBRight_Y { get; set; }
        [JsonIgnore] public Address<float> ThumbBRight_Z { get; set; }
        [JsonIgnore] public Address<float> ThumbBRight_W { get; set; }
        [JsonIgnore] public Address<float> TailA_X { get; set; }
        [JsonIgnore] public Address<float> TailA_Y { get; set; }
        [JsonIgnore] public Address<float> TailA_Z { get; set; }
        [JsonIgnore] public Address<float> TailA_W { get; set; }
        [JsonIgnore] public Address<float> TailB_X { get; set; }
        [JsonIgnore] public Address<float> TailB_Y { get; set; }
        [JsonIgnore] public Address<float> TailB_Z { get; set; }
        [JsonIgnore] public Address<float> TailB_W { get; set; }
        [JsonIgnore] public Address<float> TailC_X { get; set; }
        [JsonIgnore] public Address<float> TailC_Y { get; set; }
        [JsonIgnore] public Address<float> TailC_Z { get; set; }
        [JsonIgnore] public Address<float> TailC_W { get; set; }
        [JsonIgnore] public Address<float> TailD_X { get; set; }
        [JsonIgnore] public Address<float> TailD_Y { get; set; }
        [JsonIgnore] public Address<float> TailD_Z { get; set; }
        [JsonIgnore] public Address<float> TailD_W { get; set; }
        [JsonIgnore] public Address<float> TailE_X { get; set; }
        [JsonIgnore] public Address<float> TailE_Y { get; set; }
        [JsonIgnore] public Address<float> TailE_Z { get; set; }
        [JsonIgnore] public Address<float> TailE_W { get; set; }
        [JsonIgnore] public Address<float> RootHead_X { get; set; }
        [JsonIgnore] public Address<float> RootHead_Y { get; set; }
        [JsonIgnore] public Address<float> RootHead_Z { get; set; }
        [JsonIgnore] public Address<float> RootHead_W { get; set; }
        [JsonIgnore] public Address<float> Jaw_X { get; set; }
        [JsonIgnore] public Address<float> Jaw_Y { get; set; }
        [JsonIgnore] public Address<float> Jaw_Z { get; set; }
        [JsonIgnore] public Address<float> Jaw_W { get; set; }
        [JsonIgnore] public Address<float> EyelidLowerLeft_X { get; set; }
        [JsonIgnore] public Address<float> EyelidLowerLeft_Y { get; set; }
        [JsonIgnore] public Address<float> EyelidLowerLeft_Z { get; set; }
        [JsonIgnore] public Address<float> EyelidLowerLeft_W { get; set; }
        [JsonIgnore] public Address<float> EyelidLowerRight_X { get; set; }
        [JsonIgnore] public Address<float> EyelidLowerRight_Y { get; set; }
        [JsonIgnore] public Address<float> EyelidLowerRight_Z { get; set; }
        [JsonIgnore] public Address<float> EyelidLowerRight_W { get; set; }
        [JsonIgnore] public Address<float> EyeLeft_X { get; set; }
        [JsonIgnore] public Address<float> EyeLeft_Y { get; set; }
        [JsonIgnore] public Address<float> EyeLeft_Z { get; set; }
        [JsonIgnore] public Address<float> EyeLeft_W { get; set; }
        [JsonIgnore] public Address<float> EyeRight_X { get; set; }
        [JsonIgnore] public Address<float> EyeRight_Y { get; set; }
        [JsonIgnore] public Address<float> EyeRight_Z { get; set; }
        [JsonIgnore] public Address<float> EyeRight_W { get; set; }
        [JsonIgnore] public Address<float> Nose_X { get; set; }
        [JsonIgnore] public Address<float> Nose_Y { get; set; }
        [JsonIgnore] public Address<float> Nose_Z { get; set; }
        [JsonIgnore] public Address<float> Nose_W { get; set; }
        [JsonIgnore] public Address<float> CheekLeft_X { get; set; }
        [JsonIgnore] public Address<float> CheekLeft_Y { get; set; }
        [JsonIgnore] public Address<float> CheekLeft_Z { get; set; }
        [JsonIgnore] public Address<float> CheekLeft_W { get; set; }
        [JsonIgnore] public Address<float> HrothWhiskersLeft_X { get; set; }
        [JsonIgnore] public Address<float> HrothWhiskersLeft_Y { get; set; }
        [JsonIgnore] public Address<float> HrothWhiskersLeft_Z { get; set; }
        [JsonIgnore] public Address<float> HrothWhiskersLeft_W { get; set; }
        [JsonIgnore] public Address<float> CheekRight_X { get; set; }
        [JsonIgnore] public Address<float> CheekRight_Y { get; set; }
        [JsonIgnore] public Address<float> CheekRight_Z { get; set; }
        [JsonIgnore] public Address<float> CheekRight_W { get; set; }
        [JsonIgnore] public Address<float> HrothWhiskersRight_X { get; set; }
        [JsonIgnore] public Address<float> HrothWhiskersRight_Y { get; set; }
        [JsonIgnore] public Address<float> HrothWhiskersRight_Z { get; set; }
        [JsonIgnore] public Address<float> HrothWhiskersRight_W { get; set; }
        [JsonIgnore] public Address<float> LipsLeft_X { get; set; }
        [JsonIgnore] public Address<float> LipsLeft_Y { get; set; }
        [JsonIgnore] public Address<float> LipsLeft_Z { get; set; }
        [JsonIgnore] public Address<float> LipsLeft_W { get; set; }
        [JsonIgnore] public Address<float> HrothEyebrowLeft_X { get; set; }
        [JsonIgnore] public Address<float> HrothEyebrowLeft_Y { get; set; }
        [JsonIgnore] public Address<float> HrothEyebrowLeft_Z { get; set; }
        [JsonIgnore] public Address<float> HrothEyebrowLeft_W { get; set; }
        [JsonIgnore] public Address<float> LipsRight_X { get; set; }
        [JsonIgnore] public Address<float> LipsRight_Y { get; set; }
        [JsonIgnore] public Address<float> LipsRight_Z { get; set; }
        [JsonIgnore] public Address<float> LipsRight_W { get; set; }
        [JsonIgnore] public Address<float> HrothEyebrowRight_X { get; set; }
        [JsonIgnore] public Address<float> HrothEyebrowRight_Y { get; set; }
        [JsonIgnore] public Address<float> HrothEyebrowRight_Z { get; set; }
        [JsonIgnore] public Address<float> HrothEyebrowRight_W { get; set; }
        [JsonIgnore] public Address<float> EyebrowLeft_X { get; set; }
        [JsonIgnore] public Address<float> EyebrowLeft_Y { get; set; }
        [JsonIgnore] public Address<float> EyebrowLeft_Z { get; set; }
        [JsonIgnore] public Address<float> EyebrowLeft_W { get; set; }
        [JsonIgnore] public Address<float> HrothBridge_X { get; set; }
        [JsonIgnore] public Address<float> HrothBridge_Y { get; set; }
        [JsonIgnore] public Address<float> HrothBridge_Z { get; set; }
        [JsonIgnore] public Address<float> HrothBridge_W { get; set; }
        [JsonIgnore] public Address<float> EyebrowRight_X { get; set; }
        [JsonIgnore] public Address<float> EyebrowRight_Y { get; set; }
        [JsonIgnore] public Address<float> EyebrowRight_Z { get; set; }
        [JsonIgnore] public Address<float> EyebrowRight_W { get; set; }
        [JsonIgnore] public Address<float> HrothBrowLeft_X { get; set; }
        [JsonIgnore] public Address<float> HrothBrowLeft_Y { get; set; }
        [JsonIgnore] public Address<float> HrothBrowLeft_Z { get; set; }
        [JsonIgnore] public Address<float> HrothBrowLeft_W { get; set; }
        [JsonIgnore] public Address<float> Bridge_X { get; set; }
        [JsonIgnore] public Address<float> Bridge_Y { get; set; }
        [JsonIgnore] public Address<float> Bridge_Z { get; set; }
        [JsonIgnore] public Address<float> Bridge_W { get; set; }
        [JsonIgnore] public Address<float> HrothBrowRight_X { get; set; }
        [JsonIgnore] public Address<float> HrothBrowRight_Y { get; set; }
        [JsonIgnore] public Address<float> HrothBrowRight_Z { get; set; }
        [JsonIgnore] public Address<float> HrothBrowRight_W { get; set; }
        [JsonIgnore] public Address<float> BrowLeft_X { get; set; }
        [JsonIgnore] public Address<float> BrowLeft_Y { get; set; }
        [JsonIgnore] public Address<float> BrowLeft_Z { get; set; }
        [JsonIgnore] public Address<float> BrowLeft_W { get; set; }
        [JsonIgnore] public Address<float> HrothJawUpper_X { get; set; }
        [JsonIgnore] public Address<float> HrothJawUpper_Y { get; set; }
        [JsonIgnore] public Address<float> HrothJawUpper_Z { get; set; }
        [JsonIgnore] public Address<float> HrothJawUpper_W { get; set; }
        [JsonIgnore] public Address<float> BrowRight_X { get; set; }
        [JsonIgnore] public Address<float> BrowRight_Y { get; set; }
        [JsonIgnore] public Address<float> BrowRight_Z { get; set; }
        [JsonIgnore] public Address<float> BrowRight_W { get; set; }
        [JsonIgnore] public Address<float> HrothLipUpper_X { get; set; }
        [JsonIgnore] public Address<float> HrothLipUpper_Y { get; set; }
        [JsonIgnore] public Address<float> HrothLipUpper_Z { get; set; }
        [JsonIgnore] public Address<float> HrothLipUpper_W { get; set; }
        [JsonIgnore] public Address<float> LipUpperA_X { get; set; }
        [JsonIgnore] public Address<float> LipUpperA_Y { get; set; }
        [JsonIgnore] public Address<float> LipUpperA_Z { get; set; }
        [JsonIgnore] public Address<float> LipUpperA_W { get; set; }
        [JsonIgnore] public Address<float> HrothEyelidUpperLeft_X { get; set; }
        [JsonIgnore] public Address<float> HrothEyelidUpperLeft_Y { get; set; }
        [JsonIgnore] public Address<float> HrothEyelidUpperLeft_Z { get; set; }
        [JsonIgnore] public Address<float> HrothEyelidUpperLeft_W { get; set; }
        [JsonIgnore] public Address<float> EyelidUpperLeft_X { get; set; }
        [JsonIgnore] public Address<float> EyelidUpperLeft_Y { get; set; }
        [JsonIgnore] public Address<float> EyelidUpperLeft_Z { get; set; }
        [JsonIgnore] public Address<float> EyelidUpperLeft_W { get; set; }
        [JsonIgnore] public Address<float> HrothEyelidUpperRight_X { get; set; }
        [JsonIgnore] public Address<float> HrothEyelidUpperRight_Y { get; set; }
        [JsonIgnore] public Address<float> HrothEyelidUpperRight_Z { get; set; }
        [JsonIgnore] public Address<float> HrothEyelidUpperRight_W { get; set; }
        [JsonIgnore] public Address<float> EyelidUpperRight_X { get; set; }
        [JsonIgnore] public Address<float> EyelidUpperRight_Y { get; set; }
        [JsonIgnore] public Address<float> EyelidUpperRight_Z { get; set; }
        [JsonIgnore] public Address<float> EyelidUpperRight_W { get; set; }
        [JsonIgnore] public Address<float> HrothLipsLeft_X { get; set; }
        [JsonIgnore] public Address<float> HrothLipsLeft_Y { get; set; }
        [JsonIgnore] public Address<float> HrothLipsLeft_Z { get; set; }
        [JsonIgnore] public Address<float> HrothLipsLeft_W { get; set; }
        [JsonIgnore] public Address<float> LipLowerA_X { get; set; }
        [JsonIgnore] public Address<float> LipLowerA_Y { get; set; }
        [JsonIgnore] public Address<float> LipLowerA_Z { get; set; }
        [JsonIgnore] public Address<float> LipLowerA_W { get; set; }
        [JsonIgnore] public Address<float> HrothLipsRight_X { get; set; }
        [JsonIgnore] public Address<float> HrothLipsRight_Y { get; set; }
        [JsonIgnore] public Address<float> HrothLipsRight_Z { get; set; }
        [JsonIgnore] public Address<float> HrothLipsRight_W { get; set; }
        [JsonIgnore] public Address<float> VieraEar01ALeft_X { get; set; }
        [JsonIgnore] public Address<float> VieraEar01ALeft_Y { get; set; }
        [JsonIgnore] public Address<float> VieraEar01ALeft_Z { get; set; }
        [JsonIgnore] public Address<float> VieraEar01ALeft_W { get; set; }
        [JsonIgnore] public Address<float> LipUpperB_X { get; set; }
        [JsonIgnore] public Address<float> LipUpperB_Y { get; set; }
        [JsonIgnore] public Address<float> LipUpperB_Z { get; set; }
        [JsonIgnore] public Address<float> LipUpperB_W { get; set; }
        [JsonIgnore] public Address<float> HrothLipUpperLeft_X { get; set; }
        [JsonIgnore] public Address<float> HrothLipUpperLeft_Y { get; set; }
        [JsonIgnore] public Address<float> HrothLipUpperLeft_Z { get; set; }
        [JsonIgnore] public Address<float> HrothLipUpperLeft_W { get; set; }
        [JsonIgnore] public Address<float> VieraEar01ARight_X { get; set; }
        [JsonIgnore] public Address<float> VieraEar01ARight_Y { get; set; }
        [JsonIgnore] public Address<float> VieraEar01ARight_Z { get; set; }
        [JsonIgnore] public Address<float> VieraEar01ARight_W { get; set; }
        [JsonIgnore] public Address<float> LipLowerB_X { get; set; }
        [JsonIgnore] public Address<float> LipLowerB_Y { get; set; }
        [JsonIgnore] public Address<float> LipLowerB_Z { get; set; }
        [JsonIgnore] public Address<float> LipLowerB_W { get; set; }
        [JsonIgnore] public Address<float> HrothLipUpperRight_X { get; set; }
        [JsonIgnore] public Address<float> HrothLipUpperRight_Y { get; set; }
        [JsonIgnore] public Address<float> HrothLipUpperRight_Z { get; set; }
        [JsonIgnore] public Address<float> HrothLipUpperRight_W { get; set; }
        [JsonIgnore] public Address<float> VieraEar02ALeft_X { get; set; }
        [JsonIgnore] public Address<float> VieraEar02ALeft_Y { get; set; }
        [JsonIgnore] public Address<float> VieraEar02ALeft_Z { get; set; }
        [JsonIgnore] public Address<float> VieraEar02ALeft_W { get; set; }
        [JsonIgnore] public Address<float> HrothLipLower_X { get; set; }
        [JsonIgnore] public Address<float> HrothLipLower_Y { get; set; }
        [JsonIgnore] public Address<float> HrothLipLower_Z { get; set; }
        [JsonIgnore] public Address<float> HrothLipLower_W { get; set; }
        [JsonIgnore] public Address<float> VieraEar02ARight_X { get; set; }
        [JsonIgnore] public Address<float> VieraEar02ARight_Y { get; set; }
        [JsonIgnore] public Address<float> VieraEar02ARight_Z { get; set; }
        [JsonIgnore] public Address<float> VieraEar02ARight_W { get; set; }
        [JsonIgnore] public Address<float> VieraEar03ALeft_X { get; set; }
        [JsonIgnore] public Address<float> VieraEar03ALeft_Y { get; set; }
        [JsonIgnore] public Address<float> VieraEar03ALeft_Z { get; set; }
        [JsonIgnore] public Address<float> VieraEar03ALeft_W { get; set; }
        [JsonIgnore] public Address<float> VieraEar03ARight_X { get; set; }
        [JsonIgnore] public Address<float> VieraEar03ARight_Y { get; set; }
        [JsonIgnore] public Address<float> VieraEar03ARight_Z { get; set; }
        [JsonIgnore] public Address<float> VieraEar03ARight_W { get; set; }
        [JsonIgnore] public Address<float> VieraEar04ALeft_X { get; set; }
        [JsonIgnore] public Address<float> VieraEar04ALeft_Y { get; set; }
        [JsonIgnore] public Address<float> VieraEar04ALeft_Z { get; set; }
        [JsonIgnore] public Address<float> VieraEar04ALeft_W { get; set; }
        [JsonIgnore] public Address<float> VieraEar04ARight_X { get; set; }
        [JsonIgnore] public Address<float> VieraEar04ARight_Y { get; set; }
        [JsonIgnore] public Address<float> VieraEar04ARight_Z { get; set; }
        [JsonIgnore] public Address<float> VieraEar04ARight_W { get; set; }
        [JsonIgnore] public Address<float> VieraLipLowerA_X { get; set; }
        [JsonIgnore] public Address<float> VieraLipLowerA_Y { get; set; }
        [JsonIgnore] public Address<float> VieraLipLowerA_Z { get; set; }
        [JsonIgnore] public Address<float> VieraLipLowerA_W { get; set; }
        [JsonIgnore] public Address<float> VieraLipUpperB_X { get; set; }
        [JsonIgnore] public Address<float> VieraLipUpperB_Y { get; set; }
        [JsonIgnore] public Address<float> VieraLipUpperB_Z { get; set; }
        [JsonIgnore] public Address<float> VieraLipUpperB_W { get; set; }
        [JsonIgnore] public Address<float> VieraEar01BLeft_X { get; set; }
        [JsonIgnore] public Address<float> VieraEar01BLeft_Y { get; set; }
        [JsonIgnore] public Address<float> VieraEar01BLeft_Z { get; set; }
        [JsonIgnore] public Address<float> VieraEar01BLeft_W { get; set; }
        [JsonIgnore] public Address<float> VieraEar01BRight_X { get; set; }
        [JsonIgnore] public Address<float> VieraEar01BRight_Y { get; set; }
        [JsonIgnore] public Address<float> VieraEar01BRight_Z { get; set; }
        [JsonIgnore] public Address<float> VieraEar01BRight_W { get; set; }
        [JsonIgnore] public Address<float> VieraEar02BLeft_X { get; set; }
        [JsonIgnore] public Address<float> VieraEar02BLeft_Y { get; set; }
        [JsonIgnore] public Address<float> VieraEar02BLeft_Z { get; set; }
        [JsonIgnore] public Address<float> VieraEar02BLeft_W { get; set; }
        [JsonIgnore] public Address<float> VieraEar02BRight_X { get; set; }
        [JsonIgnore] public Address<float> VieraEar02BRight_Y { get; set; }
        [JsonIgnore] public Address<float> VieraEar02BRight_Z { get; set; }
        [JsonIgnore] public Address<float> VieraEar02BRight_W { get; set; }
        [JsonIgnore] public Address<float> VieraEar03BLeft_X { get; set; }
        [JsonIgnore] public Address<float> VieraEar03BLeft_Y { get; set; }
        [JsonIgnore] public Address<float> VieraEar03BLeft_Z { get; set; }
        [JsonIgnore] public Address<float> VieraEar03BLeft_W { get; set; }
        [JsonIgnore] public Address<float> VieraEar03BRight_X { get; set; }
        [JsonIgnore] public Address<float> VieraEar03BRight_Y { get; set; }
        [JsonIgnore] public Address<float> VieraEar03BRight_Z { get; set; }
        [JsonIgnore] public Address<float> VieraEar03BRight_W { get; set; }
        [JsonIgnore] public Address<float> VieraEar04BLeft_X { get; set; }
        [JsonIgnore] public Address<float> VieraEar04BLeft_Y { get; set; }
        [JsonIgnore] public Address<float> VieraEar04BLeft_Z { get; set; }
        [JsonIgnore] public Address<float> VieraEar04BLeft_W { get; set; }
        [JsonIgnore] public Address<float> VieraEar04BRight_X { get; set; }
        [JsonIgnore] public Address<float> VieraEar04BRight_Y { get; set; }
        [JsonIgnore] public Address<float> VieraEar04BRight_Z { get; set; }
        [JsonIgnore] public Address<float> VieraEar04BRight_W { get; set; }
        [JsonIgnore] public Address<float> VieraLipLowerB_X { get; set; }
        [JsonIgnore] public Address<float> VieraLipLowerB_Y { get; set; }
        [JsonIgnore] public Address<float> VieraLipLowerB_Z { get; set; }
        [JsonIgnore] public Address<float> VieraLipLowerB_W { get; set; }
        [JsonIgnore] public Address<float> ExRootHair_X { get; set; }
        [JsonIgnore] public Address<float> ExRootHair_Y { get; set; }
        [JsonIgnore] public Address<float> ExRootHair_Z { get; set; }
        [JsonIgnore] public Address<float> ExRootHair_W { get; set; }
        [JsonIgnore] public Address<float> ExHairA_X { get; set; }
        [JsonIgnore] public Address<float> ExHairA_Y { get; set; }
        [JsonIgnore] public Address<float> ExHairA_Z { get; set; }
        [JsonIgnore] public Address<float> ExHairA_W { get; set; }
        [JsonIgnore] public Address<float> ExHairB_X { get; set; }
        [JsonIgnore] public Address<float> ExHairB_Y { get; set; }
        [JsonIgnore] public Address<float> ExHairB_Z { get; set; }
        [JsonIgnore] public Address<float> ExHairB_W { get; set; }
        [JsonIgnore] public Address<float> ExHairC_X { get; set; }
        [JsonIgnore] public Address<float> ExHairC_Y { get; set; }
        [JsonIgnore] public Address<float> ExHairC_Z { get; set; }
        [JsonIgnore] public Address<float> ExHairC_W { get; set; }
        [JsonIgnore] public Address<float> ExHairD_X { get; set; }
        [JsonIgnore] public Address<float> ExHairD_Y { get; set; }
        [JsonIgnore] public Address<float> ExHairD_Z { get; set; }
        [JsonIgnore] public Address<float> ExHairD_W { get; set; }
        [JsonIgnore] public Address<float> ExHairE_X { get; set; }
        [JsonIgnore] public Address<float> ExHairE_Y { get; set; }
        [JsonIgnore] public Address<float> ExHairE_Z { get; set; }
        [JsonIgnore] public Address<float> ExHairE_W { get; set; }
        [JsonIgnore] public Address<float> ExHairF_X { get; set; }
        [JsonIgnore] public Address<float> ExHairF_Y { get; set; }
        [JsonIgnore] public Address<float> ExHairF_Z { get; set; }
        [JsonIgnore] public Address<float> ExHairF_W { get; set; }
        [JsonIgnore] public Address<float> ExHairG_X { get; set; }
        [JsonIgnore] public Address<float> ExHairG_Y { get; set; }
        [JsonIgnore] public Address<float> ExHairG_Z { get; set; }
        [JsonIgnore] public Address<float> ExHairG_W { get; set; }
        [JsonIgnore] public Address<float> ExHairH_X { get; set; }
        [JsonIgnore] public Address<float> ExHairH_Y { get; set; }
        [JsonIgnore] public Address<float> ExHairH_Z { get; set; }
        [JsonIgnore] public Address<float> ExHairH_W { get; set; }
        [JsonIgnore] public Address<float> ExHairI_X { get; set; }
        [JsonIgnore] public Address<float> ExHairI_Y { get; set; }
        [JsonIgnore] public Address<float> ExHairI_Z { get; set; }
        [JsonIgnore] public Address<float> ExHairI_W { get; set; }
        [JsonIgnore] public Address<float> ExHairJ_X { get; set; }
        [JsonIgnore] public Address<float> ExHairJ_Y { get; set; }
        [JsonIgnore] public Address<float> ExHairJ_Z { get; set; }
        [JsonIgnore] public Address<float> ExHairJ_W { get; set; }
        [JsonIgnore] public Address<float> ExHairK_X { get; set; }
        [JsonIgnore] public Address<float> ExHairK_Y { get; set; }
        [JsonIgnore] public Address<float> ExHairK_Z { get; set; }
        [JsonIgnore] public Address<float> ExHairK_W { get; set; }
        [JsonIgnore] public Address<float> ExHairL_X { get; set; }
        [JsonIgnore] public Address<float> ExHairL_Y { get; set; }
        [JsonIgnore] public Address<float> ExHairL_Z { get; set; }
        [JsonIgnore] public Address<float> ExHairL_W { get; set; }
        [JsonIgnore] public Address<float> ExRootMet_X { get; set; }
        [JsonIgnore] public Address<float> ExRootMet_Y { get; set; }
        [JsonIgnore] public Address<float> ExRootMet_Z { get; set; }
        [JsonIgnore] public Address<float> ExRootMet_W { get; set; }
        [JsonIgnore] public Address<float> ExMetA_X { get; set; }
        [JsonIgnore] public Address<float> ExMetA_Y { get; set; }
        [JsonIgnore] public Address<float> ExMetA_Z { get; set; }
        [JsonIgnore] public Address<float> ExMetA_W { get; set; }
        [JsonIgnore] public Address<float> ExMetB_X { get; set; }
        [JsonIgnore] public Address<float> ExMetB_Y { get; set; }
        [JsonIgnore] public Address<float> ExMetB_Z { get; set; }
        [JsonIgnore] public Address<float> ExMetB_W { get; set; }
        [JsonIgnore] public Address<float> ExMetC_X { get; set; }
        [JsonIgnore] public Address<float> ExMetC_Y { get; set; }
        [JsonIgnore] public Address<float> ExMetC_Z { get; set; }
        [JsonIgnore] public Address<float> ExMetC_W { get; set; }
        [JsonIgnore] public Address<float> ExMetD_X { get; set; }
        [JsonIgnore] public Address<float> ExMetD_Y { get; set; }
        [JsonIgnore] public Address<float> ExMetD_Z { get; set; }
        [JsonIgnore] public Address<float> ExMetD_W { get; set; }
        [JsonIgnore] public Address<float> ExMetE_X { get; set; }
        [JsonIgnore] public Address<float> ExMetE_Y { get; set; }
        [JsonIgnore] public Address<float> ExMetE_Z { get; set; }
        [JsonIgnore] public Address<float> ExMetE_W { get; set; }
        [JsonIgnore] public Address<float> ExMetF_X { get; set; }
        [JsonIgnore] public Address<float> ExMetF_Y { get; set; }
        [JsonIgnore] public Address<float> ExMetF_Z { get; set; }
        [JsonIgnore] public Address<float> ExMetF_W { get; set; }
        [JsonIgnore] public Address<float> ExMetG_X { get; set; }
        [JsonIgnore] public Address<float> ExMetG_Y { get; set; }
        [JsonIgnore] public Address<float> ExMetG_Z { get; set; }
        [JsonIgnore] public Address<float> ExMetG_W { get; set; }
        [JsonIgnore] public Address<float> ExMetH_X { get; set; }
        [JsonIgnore] public Address<float> ExMetH_Y { get; set; }
        [JsonIgnore] public Address<float> ExMetH_Z { get; set; }
        [JsonIgnore] public Address<float> ExMetH_W { get; set; }
        [JsonIgnore] public Address<float> ExMetI_X { get; set; }
        [JsonIgnore] public Address<float> ExMetI_Y { get; set; }
        [JsonIgnore] public Address<float> ExMetI_Z { get; set; }
        [JsonIgnore] public Address<float> ExMetI_W { get; set; }
        [JsonIgnore] public Address<float> ExMetJ_X { get; set; }
        [JsonIgnore] public Address<float> ExMetJ_Y { get; set; }
        [JsonIgnore] public Address<float> ExMetJ_Z { get; set; }
        [JsonIgnore] public Address<float> ExMetJ_W { get; set; }
        [JsonIgnore] public Address<float> ExMetK_X { get; set; }
        [JsonIgnore] public Address<float> ExMetK_Y { get; set; }
        [JsonIgnore] public Address<float> ExMetK_Z { get; set; }
        [JsonIgnore] public Address<float> ExMetK_W { get; set; }
        [JsonIgnore] public Address<float> ExMetL_X { get; set; }
        [JsonIgnore] public Address<float> ExMetL_Y { get; set; }
        [JsonIgnore] public Address<float> ExMetL_Z { get; set; }
        [JsonIgnore] public Address<float> ExMetL_W { get; set; }
        [JsonIgnore] public Address<float> ExMetM_X { get; set; }
        [JsonIgnore] public Address<float> ExMetM_Y { get; set; }
        [JsonIgnore] public Address<float> ExMetM_Z { get; set; }
        [JsonIgnore] public Address<float> ExMetM_W { get; set; }
        [JsonIgnore] public Address<float> ExMetN_X { get; set; }
        [JsonIgnore] public Address<float> ExMetN_Y { get; set; }
        [JsonIgnore] public Address<float> ExMetN_Z { get; set; }
        [JsonIgnore] public Address<float> ExMetN_W { get; set; }
        [JsonIgnore] public Address<float> ExMetO_X { get; set; }
        [JsonIgnore] public Address<float> ExMetO_Y { get; set; }
        [JsonIgnore] public Address<float> ExMetO_Z { get; set; }
        [JsonIgnore] public Address<float> ExMetO_W { get; set; }
        [JsonIgnore] public Address<float> ExMetP_X { get; set; }
        [JsonIgnore] public Address<float> ExMetP_Y { get; set; }
        [JsonIgnore] public Address<float> ExMetP_Z { get; set; }
        [JsonIgnore] public Address<float> ExMetP_W { get; set; }
        [JsonIgnore] public Address<float> ExMetQ_X { get; set; }
        [JsonIgnore] public Address<float> ExMetQ_Y { get; set; }
        [JsonIgnore] public Address<float> ExMetQ_Z { get; set; }
        [JsonIgnore] public Address<float> ExMetQ_W { get; set; }
        [JsonIgnore] public Address<float> ExMetR_X { get; set; }
        [JsonIgnore] public Address<float> ExMetR_Y { get; set; }
        [JsonIgnore] public Address<float> ExMetR_Z { get; set; }
        [JsonIgnore] public Address<float> ExMetR_W { get; set; }
        [JsonIgnore] public Address<float> ExRootTop_X { get; set; }
        [JsonIgnore] public Address<float> ExRootTop_Y { get; set; }
        [JsonIgnore] public Address<float> ExRootTop_Z { get; set; }
        [JsonIgnore] public Address<float> ExRootTop_W { get; set; }
        [JsonIgnore] public Address<float> ExTopA_X { get; set; }
        [JsonIgnore] public Address<float> ExTopA_Y { get; set; }
        [JsonIgnore] public Address<float> ExTopA_Z { get; set; }
        [JsonIgnore] public Address<float> ExTopA_W { get; set; }
        [JsonIgnore] public Address<float> ExTopB_X { get; set; }
        [JsonIgnore] public Address<float> ExTopB_Y { get; set; }
        [JsonIgnore] public Address<float> ExTopB_Z { get; set; }
        [JsonIgnore] public Address<float> ExTopB_W { get; set; }
        [JsonIgnore] public Address<float> ExTopC_X { get; set; }
        [JsonIgnore] public Address<float> ExTopC_Y { get; set; }
        [JsonIgnore] public Address<float> ExTopC_Z { get; set; }
        [JsonIgnore] public Address<float> ExTopC_W { get; set; }
        [JsonIgnore] public Address<float> ExTopD_X { get; set; }
        [JsonIgnore] public Address<float> ExTopD_Y { get; set; }
        [JsonIgnore] public Address<float> ExTopD_Z { get; set; }
        [JsonIgnore] public Address<float> ExTopD_W { get; set; }
        [JsonIgnore] public Address<float> ExTopE_X { get; set; }
        [JsonIgnore] public Address<float> ExTopE_Y { get; set; }
        [JsonIgnore] public Address<float> ExTopE_Z { get; set; }
        [JsonIgnore] public Address<float> ExTopE_W { get; set; }
        [JsonIgnore] public Address<float> ExTopF_X { get; set; }
        [JsonIgnore] public Address<float> ExTopF_Y { get; set; }
        [JsonIgnore] public Address<float> ExTopF_Z { get; set; }
        [JsonIgnore] public Address<float> ExTopF_W { get; set; }
        [JsonIgnore] public Address<float> ExTopG_X { get; set; }
        [JsonIgnore] public Address<float> ExTopG_Y { get; set; }
        [JsonIgnore] public Address<float> ExTopG_Z { get; set; }
        [JsonIgnore] public Address<float> ExTopG_W { get; set; }
        [JsonIgnore] public Address<float> ExTopH_X { get; set; }
        [JsonIgnore] public Address<float> ExTopH_Y { get; set; }
        [JsonIgnore] public Address<float> ExTopH_Z { get; set; }
        [JsonIgnore] public Address<float> ExTopH_W { get; set; }
        [JsonIgnore] public Address<float> ExTopI_X { get; set; }
        [JsonIgnore] public Address<float> ExTopI_Y { get; set; }
        [JsonIgnore] public Address<float> ExTopI_Z { get; set; }
        [JsonIgnore] public Address<float> ExTopI_W { get; set; }
        #endregion
        #region Bone Values
        [JsonIgnore] public Address<byte> ExHair_Value { get; set; }
        [JsonIgnore] public Address<byte> ExMet_Value { get; set; }
        [JsonIgnore] public Address<byte> ExTop_Value { get; set; }
        #endregion
        #region Bone Rotate
        [JsonIgnore] public bool Root_Rotate { get; set; }
        [JsonIgnore] public bool Abdomen_Rotate { get; set; }
        [JsonIgnore] public bool Throw_Rotate { get; set; }
        [JsonIgnore] public bool Waist_Rotate { get; set; }
        [JsonIgnore] public bool SpineA_Rotate { get; set; }
        [JsonIgnore] public bool LegLeft_Rotate { get; set; }
        [JsonIgnore] public bool LegRight_Rotate { get; set; }
        [JsonIgnore] public bool HolsterLeft_Rotate { get; set; }
        [JsonIgnore] public bool HolsterRight_Rotate { get; set; }
        [JsonIgnore] public bool SheatheLeft_Rotate { get; set; }
        [JsonIgnore] public bool SheatheRight_Rotate { get; set; }
        [JsonIgnore] public bool SpineB_Rotate { get; set; }
        [JsonIgnore] public bool ClothBackALeft_Rotate { get; set; }
        [JsonIgnore] public bool ClothBackARight_Rotate { get; set; }
        [JsonIgnore] public bool ClothFrontALeft_Rotate { get; set; }
        [JsonIgnore] public bool ClothFrontARight_Rotate { get; set; }
        [JsonIgnore] public bool ClothSideALeft_Rotate { get; set; }
        [JsonIgnore] public bool ClothSideARight_Rotate { get; set; }
        [JsonIgnore] public bool KneeLeft_Rotate { get; set; }
        [JsonIgnore] public bool KneeRight_Rotate { get; set; }
        [JsonIgnore] public bool BreastLeft_Rotate { get; set; }
        [JsonIgnore] public bool BreastRight_Rotate { get; set; }
        [JsonIgnore] public bool SpineC_Rotate { get; set; }
        [JsonIgnore] public bool ClothBackBLeft_Rotate { get; set; }
        [JsonIgnore] public bool ClothBackBRight_Rotate { get; set; }
        [JsonIgnore] public bool ClothFrontBLeft_Rotate { get; set; }
        [JsonIgnore] public bool ClothFrontBRight_Rotate { get; set; }
        [JsonIgnore] public bool ClothSideBLeft_Rotate { get; set; }
        [JsonIgnore] public bool ClothSideBRight_Rotate { get; set; }
        [JsonIgnore] public bool CalfLeft_Rotate { get; set; }
        [JsonIgnore] public bool CalfRight_Rotate { get; set; }
        [JsonIgnore] public bool ScabbardLeft_Rotate { get; set; }
        [JsonIgnore] public bool ScabbardRight_Rotate { get; set; }
        [JsonIgnore] public bool Neck_Rotate { get; set; }
        [JsonIgnore] public bool ClavicleLeft_Rotate { get; set; }
        [JsonIgnore] public bool ClavicleRight_Rotate { get; set; }
        [JsonIgnore] public bool ClothBackCLeft_Rotate { get; set; }
        [JsonIgnore] public bool ClothBackCRight_Rotate { get; set; }
        [JsonIgnore] public bool ClothFrontCLeft_Rotate { get; set; }
        [JsonIgnore] public bool ClothFrontCRight_Rotate { get; set; }
        [JsonIgnore] public bool ClothSideCLeft_Rotate { get; set; }
        [JsonIgnore] public bool ClothSideCRight_Rotate { get; set; }
        [JsonIgnore] public bool PoleynLeft_Rotate { get; set; }
        [JsonIgnore] public bool PoleynRight_Rotate { get; set; }
        [JsonIgnore] public bool FootLeft_Rotate { get; set; }
        [JsonIgnore] public bool FootRight_Rotate { get; set; }
        [JsonIgnore] public bool Head_Rotate { get; set; }
        [JsonIgnore] public bool ArmLeft_Rotate { get; set; }
        [JsonIgnore] public bool ArmRight_Rotate { get; set; }
        [JsonIgnore] public bool PauldronLeft_Rotate { get; set; }
        [JsonIgnore] public bool PauldronRight_Rotate { get; set; }
        [JsonIgnore] public bool Unknown00_Rotate { get; set; }
        [JsonIgnore] public bool ToesLeft_Rotate { get; set; }
        [JsonIgnore] public bool ToesRight_Rotate { get; set; }
        [JsonIgnore] public bool HairA_Rotate { get; set; }
        [JsonIgnore] public bool HairFrontLeft_Rotate { get; set; }
        [JsonIgnore] public bool HairFrontRight_Rotate { get; set; }
        [JsonIgnore] public bool EarLeft_Rotate { get; set; }
        [JsonIgnore] public bool EarRight_Rotate { get; set; }
        [JsonIgnore] public bool ForearmLeft_Rotate { get; set; }
        [JsonIgnore] public bool ForearmRight_Rotate { get; set; }
        [JsonIgnore] public bool ShoulderLeft_Rotate { get; set; }
        [JsonIgnore] public bool ShoulderRight_Rotate { get; set; }
        [JsonIgnore] public bool HairB_Rotate { get; set; }
        [JsonIgnore] public bool HandLeft_Rotate { get; set; }
        [JsonIgnore] public bool HandRight_Rotate { get; set; }
        [JsonIgnore] public bool ShieldLeft_Rotate { get; set; }
        [JsonIgnore] public bool ShieldRight_Rotate { get; set; }
        [JsonIgnore] public bool EarringALeft_Rotate { get; set; }
        [JsonIgnore] public bool EarringARight_Rotate { get; set; }
        [JsonIgnore] public bool ElbowLeft_Rotate { get; set; }
        [JsonIgnore] public bool ElbowRight_Rotate { get; set; }
        [JsonIgnore] public bool CouterLeft_Rotate { get; set; }
        [JsonIgnore] public bool CouterRight_Rotate { get; set; }
        [JsonIgnore] public bool WristLeft_Rotate { get; set; }
        [JsonIgnore] public bool WristRight_Rotate { get; set; }
        [JsonIgnore] public bool IndexALeft_Rotate { get; set; }
        [JsonIgnore] public bool IndexARight_Rotate { get; set; }
        [JsonIgnore] public bool PinkyALeft_Rotate { get; set; }
        [JsonIgnore] public bool PinkyARight_Rotate { get; set; }
        [JsonIgnore] public bool RingALeft_Rotate { get; set; }
        [JsonIgnore] public bool RingARight_Rotate { get; set; }
        [JsonIgnore] public bool MiddleALeft_Rotate { get; set; }
        [JsonIgnore] public bool MiddleARight_Rotate { get; set; }
        [JsonIgnore] public bool ThumbALeft_Rotate { get; set; }
        [JsonIgnore] public bool ThumbARight_Rotate { get; set; }
        [JsonIgnore] public bool WeaponLeft_Rotate { get; set; }
        [JsonIgnore] public bool WeaponRight_Rotate { get; set; }
        [JsonIgnore] public bool EarringBLeft_Rotate { get; set; }
        [JsonIgnore] public bool EarringBRight_Rotate { get; set; }
        [JsonIgnore] public bool IndexBLeft_Rotate { get; set; }
        [JsonIgnore] public bool IndexBRight_Rotate { get; set; }
        [JsonIgnore] public bool PinkyBLeft_Rotate { get; set; }
        [JsonIgnore] public bool PinkyBRight_Rotate { get; set; }
        [JsonIgnore] public bool RingBLeft_Rotate { get; set; }
        [JsonIgnore] public bool RingBRight_Rotate { get; set; }
        [JsonIgnore] public bool MiddleBLeft_Rotate { get; set; }
        [JsonIgnore] public bool MiddleBRight_Rotate { get; set; }
        [JsonIgnore] public bool ThumbBLeft_Rotate { get; set; }
        [JsonIgnore] public bool ThumbBRight_Rotate { get; set; }
        [JsonIgnore] public bool TailA_Rotate { get; set; }
        [JsonIgnore] public bool TailB_Rotate { get; set; }
        [JsonIgnore] public bool TailC_Rotate { get; set; }
        [JsonIgnore] public bool TailD_Rotate { get; set; }
        [JsonIgnore] public bool TailE_Rotate { get; set; }
        [JsonIgnore] public bool RootHead_Rotate { get; set; }
        [JsonIgnore] public bool Jaw_Rotate { get; set; }
        [JsonIgnore] public bool EyelidLowerLeft_Rotate { get; set; }
        [JsonIgnore] public bool EyelidLowerRight_Rotate { get; set; }
        [JsonIgnore] public bool EyeLeft_Rotate { get; set; }
        [JsonIgnore] public bool EyeRight_Rotate { get; set; }
        [JsonIgnore] public bool Nose_Rotate { get; set; }
        [JsonIgnore] public bool CheekLeft_Rotate { get; set; }
        [JsonIgnore] public bool HrothWhiskersLeft_Rotate { get; set; }
        [JsonIgnore] public bool CheekRight_Rotate { get; set; }
        [JsonIgnore] public bool HrothWhiskersRight_Rotate { get; set; }
        [JsonIgnore] public bool LipsLeft_Rotate { get; set; }
        [JsonIgnore] public bool HrothEyebrowLeft_Rotate { get; set; }
        [JsonIgnore] public bool LipsRight_Rotate { get; set; }
        [JsonIgnore] public bool HrothEyebrowRight_Rotate { get; set; }
        [JsonIgnore] public bool EyebrowLeft_Rotate { get; set; }
        [JsonIgnore] public bool HrothBridge_Rotate { get; set; }
        [JsonIgnore] public bool EyebrowRight_Rotate { get; set; }
        [JsonIgnore] public bool HrothBrowLeft_Rotate { get; set; }
        [JsonIgnore] public bool Bridge_Rotate { get; set; }
        [JsonIgnore] public bool HrothBrowRight_Rotate { get; set; }
        [JsonIgnore] public bool BrowLeft_Rotate { get; set; }
        [JsonIgnore] public bool HrothJawUpper_Rotate { get; set; }
        [JsonIgnore] public bool BrowRight_Rotate { get; set; }
        [JsonIgnore] public bool HrothLipUpper_Rotate { get; set; }
        [JsonIgnore] public bool LipUpperA_Rotate { get; set; }
        [JsonIgnore] public bool HrothEyelidUpperLeft_Rotate { get; set; }
        [JsonIgnore] public bool EyelidUpperLeft_Rotate { get; set; }
        [JsonIgnore] public bool HrothEyelidUpperRight_Rotate { get; set; }
        [JsonIgnore] public bool EyelidUpperRight_Rotate { get; set; }
        [JsonIgnore] public bool HrothLipsLeft_Rotate { get; set; }
        [JsonIgnore] public bool LipLowerA_Rotate { get; set; }
        [JsonIgnore] public bool HrothLipsRight_Rotate { get; set; }
        [JsonIgnore] public bool VieraEar01ALeft_Rotate { get; set; }
        [JsonIgnore] public bool LipUpperB_Rotate { get; set; }
        [JsonIgnore] public bool HrothLipUpperLeft_Rotate { get; set; }
        [JsonIgnore] public bool VieraEar01ARight_Rotate { get; set; }
        [JsonIgnore] public bool LipLowerB_Rotate { get; set; }
        [JsonIgnore] public bool HrothLipUpperRight_Rotate { get; set; }
        [JsonIgnore] public bool VieraEar02ALeft_Rotate { get; set; }
        [JsonIgnore] public bool HrothLipLower_Rotate { get; set; }
        [JsonIgnore] public bool VieraEar02ARight_Rotate { get; set; }
        [JsonIgnore] public bool VieraEar03ALeft_Rotate { get; set; }
        [JsonIgnore] public bool VieraEar03ARight_Rotate { get; set; }
        [JsonIgnore] public bool VieraEar04ALeft_Rotate { get; set; }
        [JsonIgnore] public bool VieraEar04ARight_Rotate { get; set; }
        [JsonIgnore] public bool VieraLipLowerA_Rotate { get; set; }
        [JsonIgnore] public bool VieraLipUpperB_Rotate { get; set; }
        [JsonIgnore] public bool VieraEar01BLeft_Rotate { get; set; }
        [JsonIgnore] public bool VieraEar01BRight_Rotate { get; set; }
        [JsonIgnore] public bool VieraEar02BLeft_Rotate { get; set; }
        [JsonIgnore] public bool VieraEar02BRight_Rotate { get; set; }
        [JsonIgnore] public bool VieraEar03BLeft_Rotate { get; set; }
        [JsonIgnore] public bool VieraEar03BRight_Rotate { get; set; }
        [JsonIgnore] public bool VieraEar04BLeft_Rotate { get; set; }
        [JsonIgnore] public bool VieraEar04BRight_Rotate { get; set; }
        [JsonIgnore] public bool VieraLipLowerB_Rotate { get; set; }
        [JsonIgnore] public bool ExRootHair_Rotate { get; set; }
        [JsonIgnore] public bool ExHairA_Rotate { get; set; }
        [JsonIgnore] public bool ExHairB_Rotate { get; set; }
        [JsonIgnore] public bool ExHairC_Rotate { get; set; }
        [JsonIgnore] public bool ExHairD_Rotate { get; set; }
        [JsonIgnore] public bool ExHairE_Rotate { get; set; }
        [JsonIgnore] public bool ExHairF_Rotate { get; set; }
        [JsonIgnore] public bool ExHairG_Rotate { get; set; }
        [JsonIgnore] public bool ExHairH_Rotate { get; set; }
        [JsonIgnore] public bool ExHairI_Rotate { get; set; }
        [JsonIgnore] public bool ExHairJ_Rotate { get; set; }
        [JsonIgnore] public bool ExHairK_Rotate { get; set; }
        [JsonIgnore] public bool ExHairL_Rotate { get; set; }
        [JsonIgnore] public bool ExRootMet_Rotate { get; set; }
        [JsonIgnore] public bool ExMetA_Rotate { get; set; }
        [JsonIgnore] public bool ExMetB_Rotate { get; set; }
        [JsonIgnore] public bool ExMetC_Rotate { get; set; }
        [JsonIgnore] public bool ExMetD_Rotate { get; set; }
        [JsonIgnore] public bool ExMetE_Rotate { get; set; }
        [JsonIgnore] public bool ExMetF_Rotate { get; set; }
        [JsonIgnore] public bool ExMetG_Rotate { get; set; }
        [JsonIgnore] public bool ExMetH_Rotate { get; set; }
        [JsonIgnore] public bool ExMetI_Rotate { get; set; }
        [JsonIgnore] public bool ExMetJ_Rotate { get; set; }
        [JsonIgnore] public bool ExMetK_Rotate { get; set; }
        [JsonIgnore] public bool ExMetL_Rotate { get; set; }
        [JsonIgnore] public bool ExMetM_Rotate { get; set; }
        [JsonIgnore] public bool ExMetN_Rotate { get; set; }
        [JsonIgnore] public bool ExMetO_Rotate { get; set; }
        [JsonIgnore] public bool ExMetP_Rotate { get; set; }
        [JsonIgnore] public bool ExMetQ_Rotate { get; set; }
        [JsonIgnore] public bool ExMetR_Rotate { get; set; }
        [JsonIgnore] public bool ExRootTop_Rotate { get; set; }
        [JsonIgnore] public bool ExTopA_Rotate { get; set; }
        [JsonIgnore] public bool ExTopB_Rotate { get; set; }
        [JsonIgnore] public bool ExTopC_Rotate { get; set; }
        [JsonIgnore] public bool ExTopD_Rotate { get; set; }
        [JsonIgnore] public bool ExTopE_Rotate { get; set; }
        [JsonIgnore] public bool ExTopF_Rotate { get; set; }
        [JsonIgnore] public bool ExTopG_Rotate { get; set; }
        [JsonIgnore] public bool ExTopH_Rotate { get; set; }
        [JsonIgnore] public bool ExTopI_Rotate { get; set; }
        #endregion
        #region Bone Toggle
        [JsonIgnore] public bool Root_Toggle { get; set; }
        [JsonIgnore] public bool Abdomen_Toggle { get; set; }
        [JsonIgnore] public bool Throw_Toggle { get; set; }
        [JsonIgnore] public bool Waist_Toggle { get; set; }
        [JsonIgnore] public bool SpineA_Toggle { get; set; }
        [JsonIgnore] public bool LegLeft_Toggle { get; set; }
        [JsonIgnore] public bool LegRight_Toggle { get; set; }
        [JsonIgnore] public bool HolsterLeft_Toggle { get; set; }
        [JsonIgnore] public bool HolsterRight_Toggle { get; set; }
        [JsonIgnore] public bool SheatheLeft_Toggle { get; set; }
        [JsonIgnore] public bool SheatheRight_Toggle { get; set; }
        [JsonIgnore] public bool SpineB_Toggle { get; set; }
        [JsonIgnore] public bool ClothBackALeft_Toggle { get; set; }
        [JsonIgnore] public bool ClothBackARight_Toggle { get; set; }
        [JsonIgnore] public bool ClothFrontALeft_Toggle { get; set; }
        [JsonIgnore] public bool ClothFrontARight_Toggle { get; set; }
        [JsonIgnore] public bool ClothSideALeft_Toggle { get; set; }
        [JsonIgnore] public bool ClothSideARight_Toggle { get; set; }
        [JsonIgnore] public bool KneeLeft_Toggle { get; set; }
        [JsonIgnore] public bool KneeRight_Toggle { get; set; }
        [JsonIgnore] public bool BreastLeft_Toggle { get; set; }
        [JsonIgnore] public bool BreastRight_Toggle { get; set; }
        [JsonIgnore] public bool SpineC_Toggle { get; set; }
        [JsonIgnore] public bool ClothBackBLeft_Toggle { get; set; }
        [JsonIgnore] public bool ClothBackBRight_Toggle { get; set; }
        [JsonIgnore] public bool ClothFrontBLeft_Toggle { get; set; }
        [JsonIgnore] public bool ClothFrontBRight_Toggle { get; set; }
        [JsonIgnore] public bool ClothSideBLeft_Toggle { get; set; }
        [JsonIgnore] public bool ClothSideBRight_Toggle { get; set; }
        [JsonIgnore] public bool CalfLeft_Toggle { get; set; }
        [JsonIgnore] public bool CalfRight_Toggle { get; set; }
        [JsonIgnore] public bool ScabbardLeft_Toggle { get; set; }
        [JsonIgnore] public bool ScabbardRight_Toggle { get; set; }
        [JsonIgnore] public bool Neck_Toggle { get; set; }
        [JsonIgnore] public bool ClavicleLeft_Toggle { get; set; }
        [JsonIgnore] public bool ClavicleRight_Toggle { get; set; }
        [JsonIgnore] public bool ClothBackCLeft_Toggle { get; set; }
        [JsonIgnore] public bool ClothBackCRight_Toggle { get; set; }
        [JsonIgnore] public bool ClothFrontCLeft_Toggle { get; set; }
        [JsonIgnore] public bool ClothFrontCRight_Toggle { get; set; }
        [JsonIgnore] public bool ClothSideCLeft_Toggle { get; set; }
        [JsonIgnore] public bool ClothSideCRight_Toggle { get; set; }
        [JsonIgnore] public bool PoleynLeft_Toggle { get; set; }
        [JsonIgnore] public bool PoleynRight_Toggle { get; set; }
        [JsonIgnore] public bool FootLeft_Toggle { get; set; }
        [JsonIgnore] public bool FootRight_Toggle { get; set; }
        [JsonIgnore] public bool Head_Toggle { get; set; }
        [JsonIgnore] public bool ArmLeft_Toggle { get; set; }
        [JsonIgnore] public bool ArmRight_Toggle { get; set; }
        [JsonIgnore] public bool PauldronLeft_Toggle { get; set; }
        [JsonIgnore] public bool PauldronRight_Toggle { get; set; }
        [JsonIgnore] public bool Unknown00_Toggle { get; set; }
        [JsonIgnore] public bool ToesLeft_Toggle { get; set; }
        [JsonIgnore] public bool ToesRight_Toggle { get; set; }
        [JsonIgnore] public bool HairA_Toggle { get; set; }
        [JsonIgnore] public bool HairFrontLeft_Toggle { get; set; }
        [JsonIgnore] public bool HairFrontRight_Toggle { get; set; }
        [JsonIgnore] public bool EarLeft_Toggle { get; set; }
        [JsonIgnore] public bool EarRight_Toggle { get; set; }
        [JsonIgnore] public bool ForearmLeft_Toggle { get; set; }
        [JsonIgnore] public bool ForearmRight_Toggle { get; set; }
        [JsonIgnore] public bool ShoulderLeft_Toggle { get; set; }
        [JsonIgnore] public bool ShoulderRight_Toggle { get; set; }
        [JsonIgnore] public bool HairB_Toggle { get; set; }
        [JsonIgnore] public bool HandLeft_Toggle { get; set; }
        [JsonIgnore] public bool HandRight_Toggle { get; set; }
        [JsonIgnore] public bool ShieldLeft_Toggle { get; set; }
        [JsonIgnore] public bool ShieldRight_Toggle { get; set; }
        [JsonIgnore] public bool EarringALeft_Toggle { get; set; }
        [JsonIgnore] public bool EarringARight_Toggle { get; set; }
        [JsonIgnore] public bool ElbowLeft_Toggle { get; set; }
        [JsonIgnore] public bool ElbowRight_Toggle { get; set; }
        [JsonIgnore] public bool CouterLeft_Toggle { get; set; }
        [JsonIgnore] public bool CouterRight_Toggle { get; set; }
        [JsonIgnore] public bool WristLeft_Toggle { get; set; }
        [JsonIgnore] public bool WristRight_Toggle { get; set; }
        [JsonIgnore] public bool IndexALeft_Toggle { get; set; }
        [JsonIgnore] public bool IndexARight_Toggle { get; set; }
        [JsonIgnore] public bool PinkyALeft_Toggle { get; set; }
        [JsonIgnore] public bool PinkyARight_Toggle { get; set; }
        [JsonIgnore] public bool RingALeft_Toggle { get; set; }
        [JsonIgnore] public bool RingARight_Toggle { get; set; }
        [JsonIgnore] public bool MiddleALeft_Toggle { get; set; }
        [JsonIgnore] public bool MiddleARight_Toggle { get; set; }
        [JsonIgnore] public bool ThumbALeft_Toggle { get; set; }
        [JsonIgnore] public bool ThumbARight_Toggle { get; set; }
        [JsonIgnore] public bool WeaponLeft_Toggle { get; set; }
        [JsonIgnore] public bool WeaponRight_Toggle { get; set; }
        [JsonIgnore] public bool EarringBLeft_Toggle { get; set; }
        [JsonIgnore] public bool EarringBRight_Toggle { get; set; }
        [JsonIgnore] public bool IndexBLeft_Toggle { get; set; }
        [JsonIgnore] public bool IndexBRight_Toggle { get; set; }
        [JsonIgnore] public bool PinkyBLeft_Toggle { get; set; }
        [JsonIgnore] public bool PinkyBRight_Toggle { get; set; }
        [JsonIgnore] public bool RingBLeft_Toggle { get; set; }
        [JsonIgnore] public bool RingBRight_Toggle { get; set; }
        [JsonIgnore] public bool MiddleBLeft_Toggle { get; set; }
        [JsonIgnore] public bool MiddleBRight_Toggle { get; set; }
        [JsonIgnore] public bool ThumbBLeft_Toggle { get; set; }
        [JsonIgnore] public bool ThumbBRight_Toggle { get; set; }
        [JsonIgnore] public bool TailA_Toggle { get; set; }
        [JsonIgnore] public bool TailB_Toggle { get; set; }
        [JsonIgnore] public bool TailC_Toggle { get; set; }
        [JsonIgnore] public bool TailD_Toggle { get; set; }
        [JsonIgnore] public bool TailE_Toggle { get; set; }
        [JsonIgnore] public bool RootHead_Toggle { get; set; }
        [JsonIgnore] public bool Jaw_Toggle { get; set; }
        [JsonIgnore] public bool EyelidLowerLeft_Toggle { get; set; }
        [JsonIgnore] public bool EyelidLowerRight_Toggle { get; set; }
        [JsonIgnore] public bool EyeLeft_Toggle { get; set; }
        [JsonIgnore] public bool EyeRight_Toggle { get; set; }
        [JsonIgnore] public bool Nose_Toggle { get; set; }
        [JsonIgnore] public bool CheekLeft_Toggle { get; set; }
        [JsonIgnore] public bool HrothWhiskersLeft_Toggle { get; set; }
        [JsonIgnore] public bool CheekRight_Toggle { get; set; }
        [JsonIgnore] public bool HrothWhiskersRight_Toggle { get; set; }
        [JsonIgnore] public bool LipsLeft_Toggle { get; set; }
        [JsonIgnore] public bool HrothEyebrowLeft_Toggle { get; set; }
        [JsonIgnore] public bool LipsRight_Toggle { get; set; }
        [JsonIgnore] public bool HrothEyebrowRight_Toggle { get; set; }
        [JsonIgnore] public bool EyebrowLeft_Toggle { get; set; }
        [JsonIgnore] public bool HrothBridge_Toggle { get; set; }
        [JsonIgnore] public bool EyebrowRight_Toggle { get; set; }
        [JsonIgnore] public bool HrothBrowLeft_Toggle { get; set; }
        [JsonIgnore] public bool Bridge_Toggle { get; set; }
        [JsonIgnore] public bool HrothBrowRight_Toggle { get; set; }
        [JsonIgnore] public bool BrowLeft_Toggle { get; set; }
        [JsonIgnore] public bool HrothJawUpper_Toggle { get; set; }
        [JsonIgnore] public bool BrowRight_Toggle { get; set; }
        [JsonIgnore] public bool HrothLipUpper_Toggle { get; set; }
        [JsonIgnore] public bool LipUpperA_Toggle { get; set; }
        [JsonIgnore] public bool HrothEyelidUpperLeft_Toggle { get; set; }
        [JsonIgnore] public bool EyelidUpperLeft_Toggle { get; set; }
        [JsonIgnore] public bool HrothEyelidUpperRight_Toggle { get; set; }
        [JsonIgnore] public bool EyelidUpperRight_Toggle { get; set; }
        [JsonIgnore] public bool HrothLipsLeft_Toggle { get; set; }
        [JsonIgnore] public bool LipLowerA_Toggle { get; set; }
        [JsonIgnore] public bool HrothLipsRight_Toggle { get; set; }
        [JsonIgnore] public bool VieraEar01ALeft_Toggle { get; set; }
        [JsonIgnore] public bool LipUpperB_Toggle { get; set; }
        [JsonIgnore] public bool HrothLipUpperLeft_Toggle { get; set; }
        [JsonIgnore] public bool VieraEar01ARight_Toggle { get; set; }
        [JsonIgnore] public bool LipLowerB_Toggle { get; set; }
        [JsonIgnore] public bool HrothLipUpperRight_Toggle { get; set; }
        [JsonIgnore] public bool VieraEar02ALeft_Toggle { get; set; }
        [JsonIgnore] public bool HrothLipLower_Toggle { get; set; }
        [JsonIgnore] public bool VieraEar02ARight_Toggle { get; set; }
        [JsonIgnore] public bool VieraEar03ALeft_Toggle { get; set; }
        [JsonIgnore] public bool VieraEar03ARight_Toggle { get; set; }
        [JsonIgnore] public bool VieraEar04ALeft_Toggle { get; set; }
        [JsonIgnore] public bool VieraEar04ARight_Toggle { get; set; }
        [JsonIgnore] public bool VieraLipLowerA_Toggle { get; set; }
        [JsonIgnore] public bool VieraLipUpperB_Toggle { get; set; }
        [JsonIgnore] public bool VieraEar01BLeft_Toggle { get; set; }
        [JsonIgnore] public bool VieraEar01BRight_Toggle { get; set; }
        [JsonIgnore] public bool VieraEar02BLeft_Toggle { get; set; }
        [JsonIgnore] public bool VieraEar02BRight_Toggle { get; set; }
        [JsonIgnore] public bool VieraEar03BLeft_Toggle { get; set; }
        [JsonIgnore] public bool VieraEar03BRight_Toggle { get; set; }
        [JsonIgnore] public bool VieraEar04BLeft_Toggle { get; set; }
        [JsonIgnore] public bool VieraEar04BRight_Toggle { get; set; }
        [JsonIgnore] public bool VieraLipLowerB_Toggle { get; set; }
        [JsonIgnore] public bool ExRootHair_Toggle { get; set; }
        [JsonIgnore] public bool ExHairA_Toggle { get; set; }
        [JsonIgnore] public bool ExHairB_Toggle { get; set; }
        [JsonIgnore] public bool ExHairC_Toggle { get; set; }
        [JsonIgnore] public bool ExHairD_Toggle { get; set; }
        [JsonIgnore] public bool ExHairE_Toggle { get; set; }
        [JsonIgnore] public bool ExHairF_Toggle { get; set; }
        [JsonIgnore] public bool ExHairG_Toggle { get; set; }
        [JsonIgnore] public bool ExHairH_Toggle { get; set; }
        [JsonIgnore] public bool ExHairI_Toggle { get; set; }
        [JsonIgnore] public bool ExHairJ_Toggle { get; set; }
        [JsonIgnore] public bool ExHairK_Toggle { get; set; }
        [JsonIgnore] public bool ExHairL_Toggle { get; set; }
        [JsonIgnore] public bool ExRootMet_Toggle { get; set; }
        [JsonIgnore] public bool ExMetA_Toggle { get; set; }
        [JsonIgnore] public bool ExMetB_Toggle { get; set; }
        [JsonIgnore] public bool ExMetC_Toggle { get; set; }
        [JsonIgnore] public bool ExMetD_Toggle { get; set; }
        [JsonIgnore] public bool ExMetE_Toggle { get; set; }
        [JsonIgnore] public bool ExMetF_Toggle { get; set; }
        [JsonIgnore] public bool ExMetG_Toggle { get; set; }
        [JsonIgnore] public bool ExMetH_Toggle { get; set; }
        [JsonIgnore] public bool ExMetI_Toggle { get; set; }
        [JsonIgnore] public bool ExMetJ_Toggle { get; set; }
        [JsonIgnore] public bool ExMetK_Toggle { get; set; }
        [JsonIgnore] public bool ExMetL_Toggle { get; set; }
        [JsonIgnore] public bool ExMetM_Toggle { get; set; }
        [JsonIgnore] public bool ExMetN_Toggle { get; set; }
        [JsonIgnore] public bool ExMetO_Toggle { get; set; }
        [JsonIgnore] public bool ExMetP_Toggle { get; set; }
        [JsonIgnore] public bool ExMetQ_Toggle { get; set; }
        [JsonIgnore] public bool ExMetR_Toggle { get; set; }
        [JsonIgnore] public bool ExRootTop_Toggle { get; set; }
        [JsonIgnore] public bool ExTopA_Toggle { get; set; }
        [JsonIgnore] public bool ExTopB_Toggle { get; set; }
        [JsonIgnore] public bool ExTopC_Toggle { get; set; }
        [JsonIgnore] public bool ExTopD_Toggle { get; set; }
        [JsonIgnore] public bool ExTopE_Toggle { get; set; }
        [JsonIgnore] public bool ExTopF_Toggle { get; set; }
        [JsonIgnore] public bool ExTopG_Toggle { get; set; }
        [JsonIgnore] public bool ExTopH_Toggle { get; set; }
        [JsonIgnore] public bool ExTopI_Toggle { get; set; }
        #endregion

        public CharacterDetails()
        {
            CamAngleX = new Address<float>();
            CamAngleY = new Address<float>();
            CamPanX = new Address<float>();
            CamPanY = new Address<float>();
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
            DataHead = new Address<byte>();
            NPCName = new Address<short>();
            NPCModel = new Address<short>();
            StatusEffect = new Address<short>();
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
            ForceWeather = new Address<ushort>();
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
            FaceCamX = new Address<float>();
            FaceCamY = new Address<float>();
            FaceCamZ = new Address<float>();
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
            RotateFreeze = false;
            BoneEditMode = false;

            #region Bones
            CubeBone_X = new Address<float>();
            CubeBone_Y = new Address<float>();
            CubeBone_Z = new Address<float>();
            CubeBone_W = new Address<float>();

            Root_X = new Address<float>();
            Root_Y = new Address<float>();
            Root_Z = new Address<float>();
            Root_W = new Address<float>();
            Abdomen_X = new Address<float>();
            Abdomen_Y = new Address<float>();
            Abdomen_Z = new Address<float>();
            Abdomen_W = new Address<float>();
            Throw_X = new Address<float>();
            Throw_Y = new Address<float>();
            Throw_Z = new Address<float>();
            Throw_W = new Address<float>();
            Waist_X = new Address<float>();
            Waist_Y = new Address<float>();
            Waist_Z = new Address<float>();
            Waist_W = new Address<float>();
            SpineA_X = new Address<float>();
            SpineA_Y = new Address<float>();
            SpineA_Z = new Address<float>();
            SpineA_W = new Address<float>();
            LegLeft_X = new Address<float>();
            LegLeft_Y = new Address<float>();
            LegLeft_Z = new Address<float>();
            LegLeft_W = new Address<float>();
            LegRight_X = new Address<float>();
            LegRight_Y = new Address<float>();
            LegRight_Z = new Address<float>();
            LegRight_W = new Address<float>();
            HolsterLeft_X = new Address<float>();
            HolsterLeft_Y = new Address<float>();
            HolsterLeft_Z = new Address<float>();
            HolsterLeft_W = new Address<float>();
            HolsterRight_X = new Address<float>();
            HolsterRight_Y = new Address<float>();
            HolsterRight_Z = new Address<float>();
            HolsterRight_W = new Address<float>();
            SheatheLeft_X = new Address<float>();
            SheatheLeft_Y = new Address<float>();
            SheatheLeft_Z = new Address<float>();
            SheatheLeft_W = new Address<float>();
            SheatheRight_X = new Address<float>();
            SheatheRight_Y = new Address<float>();
            SheatheRight_Z = new Address<float>();
            SheatheRight_W = new Address<float>();
            SpineB_X = new Address<float>();
            SpineB_Y = new Address<float>();
            SpineB_Z = new Address<float>();
            SpineB_W = new Address<float>();
            ClothBackALeft_X = new Address<float>();
            ClothBackALeft_Y = new Address<float>();
            ClothBackALeft_Z = new Address<float>();
            ClothBackALeft_W = new Address<float>();
            ClothBackARight_X = new Address<float>();
            ClothBackARight_Y = new Address<float>();
            ClothBackARight_Z = new Address<float>();
            ClothBackARight_W = new Address<float>();
            ClothFrontALeft_X = new Address<float>();
            ClothFrontALeft_Y = new Address<float>();
            ClothFrontALeft_Z = new Address<float>();
            ClothFrontALeft_W = new Address<float>();
            ClothFrontARight_X = new Address<float>();
            ClothFrontARight_Y = new Address<float>();
            ClothFrontARight_Z = new Address<float>();
            ClothFrontARight_W = new Address<float>();
            ClothSideALeft_X = new Address<float>();
            ClothSideALeft_Y = new Address<float>();
            ClothSideALeft_Z = new Address<float>();
            ClothSideALeft_W = new Address<float>();
            ClothSideARight_X = new Address<float>();
            ClothSideARight_Y = new Address<float>();
            ClothSideARight_Z = new Address<float>();
            ClothSideARight_W = new Address<float>();
            KneeLeft_X = new Address<float>();
            KneeLeft_Y = new Address<float>();
            KneeLeft_Z = new Address<float>();
            KneeLeft_W = new Address<float>();
            KneeRight_X = new Address<float>();
            KneeRight_Y = new Address<float>();
            KneeRight_Z = new Address<float>();
            KneeRight_W = new Address<float>();
            BreastLeft_X = new Address<float>();
            BreastLeft_Y = new Address<float>();
            BreastLeft_Z = new Address<float>();
            BreastLeft_W = new Address<float>();
            BreastRight_X = new Address<float>();
            BreastRight_Y = new Address<float>();
            BreastRight_Z = new Address<float>();
            BreastRight_W = new Address<float>();
            SpineC_X = new Address<float>();
            SpineC_Y = new Address<float>();
            SpineC_Z = new Address<float>();
            SpineC_W = new Address<float>();
            ClothBackBLeft_X = new Address<float>();
            ClothBackBLeft_Y = new Address<float>();
            ClothBackBLeft_Z = new Address<float>();
            ClothBackBLeft_W = new Address<float>();
            ClothBackBRight_X = new Address<float>();
            ClothBackBRight_Y = new Address<float>();
            ClothBackBRight_Z = new Address<float>();
            ClothBackBRight_W = new Address<float>();
            ClothFrontBLeft_X = new Address<float>();
            ClothFrontBLeft_Y = new Address<float>();
            ClothFrontBLeft_Z = new Address<float>();
            ClothFrontBLeft_W = new Address<float>();
            ClothFrontBRight_X = new Address<float>();
            ClothFrontBRight_Y = new Address<float>();
            ClothFrontBRight_Z = new Address<float>();
            ClothFrontBRight_W = new Address<float>();
            ClothSideBLeft_X = new Address<float>();
            ClothSideBLeft_Y = new Address<float>();
            ClothSideBLeft_Z = new Address<float>();
            ClothSideBLeft_W = new Address<float>();
            ClothSideBRight_X = new Address<float>();
            ClothSideBRight_Y = new Address<float>();
            ClothSideBRight_Z = new Address<float>();
            ClothSideBRight_W = new Address<float>();
            CalfLeft_X = new Address<float>();
            CalfLeft_Y = new Address<float>();
            CalfLeft_Z = new Address<float>();
            CalfLeft_W = new Address<float>();
            CalfRight_X = new Address<float>();
            CalfRight_Y = new Address<float>();
            CalfRight_Z = new Address<float>();
            CalfRight_W = new Address<float>();
            ScabbardLeft_X = new Address<float>();
            ScabbardLeft_Y = new Address<float>();
            ScabbardLeft_Z = new Address<float>();
            ScabbardLeft_W = new Address<float>();
            ScabbardRight_X = new Address<float>();
            ScabbardRight_Y = new Address<float>();
            ScabbardRight_Z = new Address<float>();
            ScabbardRight_W = new Address<float>();
            Neck_X = new Address<float>();
            Neck_Y = new Address<float>();
            Neck_Z = new Address<float>();
            Neck_W = new Address<float>();
            ClavicleLeft_X = new Address<float>();
            ClavicleLeft_Y = new Address<float>();
            ClavicleLeft_Z = new Address<float>();
            ClavicleLeft_W = new Address<float>();
            ClavicleRight_X = new Address<float>();
            ClavicleRight_Y = new Address<float>();
            ClavicleRight_Z = new Address<float>();
            ClavicleRight_W = new Address<float>();
            ClothBackCLeft_X = new Address<float>();
            ClothBackCLeft_Y = new Address<float>();
            ClothBackCLeft_Z = new Address<float>();
            ClothBackCLeft_W = new Address<float>();
            ClothBackCRight_X = new Address<float>();
            ClothBackCRight_Y = new Address<float>();
            ClothBackCRight_Z = new Address<float>();
            ClothBackCRight_W = new Address<float>();
            ClothFrontCLeft_X = new Address<float>();
            ClothFrontCLeft_Y = new Address<float>();
            ClothFrontCLeft_Z = new Address<float>();
            ClothFrontCLeft_W = new Address<float>();
            ClothFrontCRight_X = new Address<float>();
            ClothFrontCRight_Y = new Address<float>();
            ClothFrontCRight_Z = new Address<float>();
            ClothFrontCRight_W = new Address<float>();
            ClothSideCLeft_X = new Address<float>();
            ClothSideCLeft_Y = new Address<float>();
            ClothSideCLeft_Z = new Address<float>();
            ClothSideCLeft_W = new Address<float>();
            ClothSideCRight_X = new Address<float>();
            ClothSideCRight_Y = new Address<float>();
            ClothSideCRight_Z = new Address<float>();
            ClothSideCRight_W = new Address<float>();
            PoleynLeft_X = new Address<float>();
            PoleynLeft_Y = new Address<float>();
            PoleynLeft_Z = new Address<float>();
            PoleynLeft_W = new Address<float>();
            PoleynRight_X = new Address<float>();
            PoleynRight_Y = new Address<float>();
            PoleynRight_Z = new Address<float>();
            PoleynRight_W = new Address<float>();
            FootLeft_X = new Address<float>();
            FootLeft_Y = new Address<float>();
            FootLeft_Z = new Address<float>();
            FootLeft_W = new Address<float>();
            FootRight_X = new Address<float>();
            FootRight_Y = new Address<float>();
            FootRight_Z = new Address<float>();
            FootRight_W = new Address<float>();
            Head_X = new Address<float>();
            Head_Y = new Address<float>();
            Head_Z = new Address<float>();
            Head_W = new Address<float>();
            ArmLeft_X = new Address<float>();
            ArmLeft_Y = new Address<float>();
            ArmLeft_Z = new Address<float>();
            ArmLeft_W = new Address<float>();
            ArmRight_X = new Address<float>();
            ArmRight_Y = new Address<float>();
            ArmRight_Z = new Address<float>();
            ArmRight_W = new Address<float>();
            PauldronLeft_X = new Address<float>();
            PauldronLeft_Y = new Address<float>();
            PauldronLeft_Z = new Address<float>();
            PauldronLeft_W = new Address<float>();
            PauldronRight_X = new Address<float>();
            PauldronRight_Y = new Address<float>();
            PauldronRight_Z = new Address<float>();
            PauldronRight_W = new Address<float>();
            Unknown00_X = new Address<float>();
            Unknown00_Y = new Address<float>();
            Unknown00_Z = new Address<float>();
            Unknown00_W = new Address<float>();
            ToesLeft_X = new Address<float>();
            ToesLeft_Y = new Address<float>();
            ToesLeft_Z = new Address<float>();
            ToesLeft_W = new Address<float>();
            ToesRight_X = new Address<float>();
            ToesRight_Y = new Address<float>();
            ToesRight_Z = new Address<float>();
            ToesRight_W = new Address<float>();
            HairA_X = new Address<float>();
            HairA_Y = new Address<float>();
            HairA_Z = new Address<float>();
            HairA_W = new Address<float>();
            HairFrontLeft_X = new Address<float>();
            HairFrontLeft_Y = new Address<float>();
            HairFrontLeft_Z = new Address<float>();
            HairFrontLeft_W = new Address<float>();
            HairFrontRight_X = new Address<float>();
            HairFrontRight_Y = new Address<float>();
            HairFrontRight_Z = new Address<float>();
            HairFrontRight_W = new Address<float>();
            EarLeft_X = new Address<float>();
            EarLeft_Y = new Address<float>();
            EarLeft_Z = new Address<float>();
            EarLeft_W = new Address<float>();
            EarRight_X = new Address<float>();
            EarRight_Y = new Address<float>();
            EarRight_Z = new Address<float>();
            EarRight_W = new Address<float>();
            ForearmLeft_X = new Address<float>();
            ForearmLeft_Y = new Address<float>();
            ForearmLeft_Z = new Address<float>();
            ForearmLeft_W = new Address<float>();
            ForearmRight_X = new Address<float>();
            ForearmRight_Y = new Address<float>();
            ForearmRight_Z = new Address<float>();
            ForearmRight_W = new Address<float>();
            ShoulderLeft_X = new Address<float>();
            ShoulderLeft_Y = new Address<float>();
            ShoulderLeft_Z = new Address<float>();
            ShoulderLeft_W = new Address<float>();
            ShoulderRight_X = new Address<float>();
            ShoulderRight_Y = new Address<float>();
            ShoulderRight_Z = new Address<float>();
            ShoulderRight_W = new Address<float>();
            HairB_X = new Address<float>();
            HairB_Y = new Address<float>();
            HairB_Z = new Address<float>();
            HairB_W = new Address<float>();
            HandLeft_X = new Address<float>();
            HandLeft_Y = new Address<float>();
            HandLeft_Z = new Address<float>();
            HandLeft_W = new Address<float>();
            HandRight_X = new Address<float>();
            HandRight_Y = new Address<float>();
            HandRight_Z = new Address<float>();
            HandRight_W = new Address<float>();
            ShieldLeft_X = new Address<float>();
            ShieldLeft_Y = new Address<float>();
            ShieldLeft_Z = new Address<float>();
            ShieldLeft_W = new Address<float>();
            ShieldRight_X = new Address<float>();
            ShieldRight_Y = new Address<float>();
            ShieldRight_Z = new Address<float>();
            ShieldRight_W = new Address<float>();
            EarringALeft_X = new Address<float>();
            EarringALeft_Y = new Address<float>();
            EarringALeft_Z = new Address<float>();
            EarringALeft_W = new Address<float>();
            EarringARight_X = new Address<float>();
            EarringARight_Y = new Address<float>();
            EarringARight_Z = new Address<float>();
            EarringARight_W = new Address<float>();
            ElbowLeft_X = new Address<float>();
            ElbowLeft_Y = new Address<float>();
            ElbowLeft_Z = new Address<float>();
            ElbowLeft_W = new Address<float>();
            ElbowRight_X = new Address<float>();
            ElbowRight_Y = new Address<float>();
            ElbowRight_Z = new Address<float>();
            ElbowRight_W = new Address<float>();
            CouterLeft_X = new Address<float>();
            CouterLeft_Y = new Address<float>();
            CouterLeft_Z = new Address<float>();
            CouterLeft_W = new Address<float>();
            CouterRight_X = new Address<float>();
            CouterRight_Y = new Address<float>();
            CouterRight_Z = new Address<float>();
            CouterRight_W = new Address<float>();
            WristLeft_X = new Address<float>();
            WristLeft_Y = new Address<float>();
            WristLeft_Z = new Address<float>();
            WristLeft_W = new Address<float>();
            WristRight_X = new Address<float>();
            WristRight_Y = new Address<float>();
            WristRight_Z = new Address<float>();
            WristRight_W = new Address<float>();
            IndexALeft_X = new Address<float>();
            IndexALeft_Y = new Address<float>();
            IndexALeft_Z = new Address<float>();
            IndexALeft_W = new Address<float>();
            IndexARight_X = new Address<float>();
            IndexARight_Y = new Address<float>();
            IndexARight_Z = new Address<float>();
            IndexARight_W = new Address<float>();
            PinkyALeft_X = new Address<float>();
            PinkyALeft_Y = new Address<float>();
            PinkyALeft_Z = new Address<float>();
            PinkyALeft_W = new Address<float>();
            PinkyARight_X = new Address<float>();
            PinkyARight_Y = new Address<float>();
            PinkyARight_Z = new Address<float>();
            PinkyARight_W = new Address<float>();
            RingALeft_X = new Address<float>();
            RingALeft_Y = new Address<float>();
            RingALeft_Z = new Address<float>();
            RingALeft_W = new Address<float>();
            RingARight_X = new Address<float>();
            RingARight_Y = new Address<float>();
            RingARight_Z = new Address<float>();
            RingARight_W = new Address<float>();
            MiddleALeft_X = new Address<float>();
            MiddleALeft_Y = new Address<float>();
            MiddleALeft_Z = new Address<float>();
            MiddleALeft_W = new Address<float>();
            MiddleARight_X = new Address<float>();
            MiddleARight_Y = new Address<float>();
            MiddleARight_Z = new Address<float>();
            MiddleARight_W = new Address<float>();
            ThumbALeft_X = new Address<float>();
            ThumbALeft_Y = new Address<float>();
            ThumbALeft_Z = new Address<float>();
            ThumbALeft_W = new Address<float>();
            ThumbARight_X = new Address<float>();
            ThumbARight_Y = new Address<float>();
            ThumbARight_Z = new Address<float>();
            ThumbARight_W = new Address<float>();
            WeaponLeft_X = new Address<float>();
            WeaponLeft_Y = new Address<float>();
            WeaponLeft_Z = new Address<float>();
            WeaponLeft_W = new Address<float>();
            WeaponRight_X = new Address<float>();
            WeaponRight_Y = new Address<float>();
            WeaponRight_Z = new Address<float>();
            WeaponRight_W = new Address<float>();
            EarringBLeft_X = new Address<float>();
            EarringBLeft_Y = new Address<float>();
            EarringBLeft_Z = new Address<float>();
            EarringBLeft_W = new Address<float>();
            EarringBRight_X = new Address<float>();
            EarringBRight_Y = new Address<float>();
            EarringBRight_Z = new Address<float>();
            EarringBRight_W = new Address<float>();
            IndexBLeft_X = new Address<float>();
            IndexBLeft_Y = new Address<float>();
            IndexBLeft_Z = new Address<float>();
            IndexBLeft_W = new Address<float>();
            IndexBRight_X = new Address<float>();
            IndexBRight_Y = new Address<float>();
            IndexBRight_Z = new Address<float>();
            IndexBRight_W = new Address<float>();
            PinkyBLeft_X = new Address<float>();
            PinkyBLeft_Y = new Address<float>();
            PinkyBLeft_Z = new Address<float>();
            PinkyBLeft_W = new Address<float>();
            PinkyBRight_X = new Address<float>();
            PinkyBRight_Y = new Address<float>();
            PinkyBRight_Z = new Address<float>();
            PinkyBRight_W = new Address<float>();
            RingBLeft_X = new Address<float>();
            RingBLeft_Y = new Address<float>();
            RingBLeft_Z = new Address<float>();
            RingBLeft_W = new Address<float>();
            RingBRight_X = new Address<float>();
            RingBRight_Y = new Address<float>();
            RingBRight_Z = new Address<float>();
            RingBRight_W = new Address<float>();
            MiddleBLeft_X = new Address<float>();
            MiddleBLeft_Y = new Address<float>();
            MiddleBLeft_Z = new Address<float>();
            MiddleBLeft_W = new Address<float>();
            MiddleBRight_X = new Address<float>();
            MiddleBRight_Y = new Address<float>();
            MiddleBRight_Z = new Address<float>();
            MiddleBRight_W = new Address<float>();
            ThumbBLeft_X = new Address<float>();
            ThumbBLeft_Y = new Address<float>();
            ThumbBLeft_Z = new Address<float>();
            ThumbBLeft_W = new Address<float>();
            ThumbBRight_X = new Address<float>();
            ThumbBRight_Y = new Address<float>();
            ThumbBRight_Z = new Address<float>();
            ThumbBRight_W = new Address<float>();
            TailA_X = new Address<float>();
            TailA_Y = new Address<float>();
            TailA_Z = new Address<float>();
            TailA_W = new Address<float>();
            TailB_X = new Address<float>();
            TailB_Y = new Address<float>();
            TailB_Z = new Address<float>();
            TailB_W = new Address<float>();
            TailC_X = new Address<float>();
            TailC_Y = new Address<float>();
            TailC_Z = new Address<float>();
            TailC_W = new Address<float>();
            TailD_X = new Address<float>();
            TailD_Y = new Address<float>();
            TailD_Z = new Address<float>();
            TailD_W = new Address<float>();
            TailE_X = new Address<float>();
            TailE_Y = new Address<float>();
            TailE_Z = new Address<float>();
            TailE_W = new Address<float>();
            RootHead_X = new Address<float>();
            RootHead_Y = new Address<float>();
            RootHead_Z = new Address<float>();
            RootHead_W = new Address<float>();
            Jaw_X = new Address<float>();
            Jaw_Y = new Address<float>();
            Jaw_Z = new Address<float>();
            Jaw_W = new Address<float>();
            EyelidLowerLeft_X = new Address<float>();
            EyelidLowerLeft_Y = new Address<float>();
            EyelidLowerLeft_Z = new Address<float>();
            EyelidLowerLeft_W = new Address<float>();
            EyelidLowerRight_X = new Address<float>();
            EyelidLowerRight_Y = new Address<float>();
            EyelidLowerRight_Z = new Address<float>();
            EyelidLowerRight_W = new Address<float>();
            EyeLeft_X = new Address<float>();
            EyeLeft_Y = new Address<float>();
            EyeLeft_Z = new Address<float>();
            EyeLeft_W = new Address<float>();
            EyeRight_X = new Address<float>();
            EyeRight_Y = new Address<float>();
            EyeRight_Z = new Address<float>();
            EyeRight_W = new Address<float>();
            Nose_X = new Address<float>();
            Nose_Y = new Address<float>();
            Nose_Z = new Address<float>();
            Nose_W = new Address<float>();
            CheekLeft_X = new Address<float>();
            CheekLeft_Y = new Address<float>();
            CheekLeft_Z = new Address<float>();
            CheekLeft_W = new Address<float>();
            HrothWhiskersLeft_X = new Address<float>();
            HrothWhiskersLeft_Y = new Address<float>();
            HrothWhiskersLeft_Z = new Address<float>();
            HrothWhiskersLeft_W = new Address<float>();
            CheekRight_X = new Address<float>();
            CheekRight_Y = new Address<float>();
            CheekRight_Z = new Address<float>();
            CheekRight_W = new Address<float>();
            HrothWhiskersRight_X = new Address<float>();
            HrothWhiskersRight_Y = new Address<float>();
            HrothWhiskersRight_Z = new Address<float>();
            HrothWhiskersRight_W = new Address<float>();
            LipsLeft_X = new Address<float>();
            LipsLeft_Y = new Address<float>();
            LipsLeft_Z = new Address<float>();
            LipsLeft_W = new Address<float>();
            HrothEyebrowLeft_X = new Address<float>();
            HrothEyebrowLeft_Y = new Address<float>();
            HrothEyebrowLeft_Z = new Address<float>();
            HrothEyebrowLeft_W = new Address<float>();
            LipsRight_X = new Address<float>();
            LipsRight_Y = new Address<float>();
            LipsRight_Z = new Address<float>();
            LipsRight_W = new Address<float>();
            HrothEyebrowRight_X = new Address<float>();
            HrothEyebrowRight_Y = new Address<float>();
            HrothEyebrowRight_Z = new Address<float>();
            HrothEyebrowRight_W = new Address<float>();
            EyebrowLeft_X = new Address<float>();
            EyebrowLeft_Y = new Address<float>();
            EyebrowLeft_Z = new Address<float>();
            EyebrowLeft_W = new Address<float>();
            HrothBridge_X = new Address<float>();
            HrothBridge_Y = new Address<float>();
            HrothBridge_Z = new Address<float>();
            HrothBridge_W = new Address<float>();
            EyebrowRight_X = new Address<float>();
            EyebrowRight_Y = new Address<float>();
            EyebrowRight_Z = new Address<float>();
            EyebrowRight_W = new Address<float>();
            HrothBrowLeft_X = new Address<float>();
            HrothBrowLeft_Y = new Address<float>();
            HrothBrowLeft_Z = new Address<float>();
            HrothBrowLeft_W = new Address<float>();
            Bridge_X = new Address<float>();
            Bridge_Y = new Address<float>();
            Bridge_Z = new Address<float>();
            Bridge_W = new Address<float>();
            HrothBrowRight_X = new Address<float>();
            HrothBrowRight_Y = new Address<float>();
            HrothBrowRight_Z = new Address<float>();
            HrothBrowRight_W = new Address<float>();
            BrowLeft_X = new Address<float>();
            BrowLeft_Y = new Address<float>();
            BrowLeft_Z = new Address<float>();
            BrowLeft_W = new Address<float>();
            HrothJawUpper_X = new Address<float>();
            HrothJawUpper_Y = new Address<float>();
            HrothJawUpper_Z = new Address<float>();
            HrothJawUpper_W = new Address<float>();
            BrowRight_X = new Address<float>();
            BrowRight_Y = new Address<float>();
            BrowRight_Z = new Address<float>();
            BrowRight_W = new Address<float>();
            HrothLipUpper_X = new Address<float>();
            HrothLipUpper_Y = new Address<float>();
            HrothLipUpper_Z = new Address<float>();
            HrothLipUpper_W = new Address<float>();
            LipUpperA_X = new Address<float>();
            LipUpperA_Y = new Address<float>();
            LipUpperA_Z = new Address<float>();
            LipUpperA_W = new Address<float>();
            HrothEyelidUpperLeft_X = new Address<float>();
            HrothEyelidUpperLeft_Y = new Address<float>();
            HrothEyelidUpperLeft_Z = new Address<float>();
            HrothEyelidUpperLeft_W = new Address<float>();
            EyelidUpperLeft_X = new Address<float>();
            EyelidUpperLeft_Y = new Address<float>();
            EyelidUpperLeft_Z = new Address<float>();
            EyelidUpperLeft_W = new Address<float>();
            HrothEyelidUpperRight_X = new Address<float>();
            HrothEyelidUpperRight_Y = new Address<float>();
            HrothEyelidUpperRight_Z = new Address<float>();
            HrothEyelidUpperRight_W = new Address<float>();
            EyelidUpperRight_X = new Address<float>();
            EyelidUpperRight_Y = new Address<float>();
            EyelidUpperRight_Z = new Address<float>();
            EyelidUpperRight_W = new Address<float>();
            HrothLipsLeft_X = new Address<float>();
            HrothLipsLeft_Y = new Address<float>();
            HrothLipsLeft_Z = new Address<float>();
            HrothLipsLeft_W = new Address<float>();
            LipLowerA_X = new Address<float>();
            LipLowerA_Y = new Address<float>();
            LipLowerA_Z = new Address<float>();
            LipLowerA_W = new Address<float>();
            HrothLipsRight_X = new Address<float>();
            HrothLipsRight_Y = new Address<float>();
            HrothLipsRight_Z = new Address<float>();
            HrothLipsRight_W = new Address<float>();
            VieraEar01ALeft_X = new Address<float>();
            VieraEar01ALeft_Y = new Address<float>();
            VieraEar01ALeft_Z = new Address<float>();
            VieraEar01ALeft_W = new Address<float>();
            LipUpperB_X = new Address<float>();
            LipUpperB_Y = new Address<float>();
            LipUpperB_Z = new Address<float>();
            LipUpperB_W = new Address<float>();
            HrothLipUpperLeft_X = new Address<float>();
            HrothLipUpperLeft_Y = new Address<float>();
            HrothLipUpperLeft_Z = new Address<float>();
            HrothLipUpperLeft_W = new Address<float>();
            VieraEar01ARight_X = new Address<float>();
            VieraEar01ARight_Y = new Address<float>();
            VieraEar01ARight_Z = new Address<float>();
            VieraEar01ARight_W = new Address<float>();
            LipLowerB_X = new Address<float>();
            LipLowerB_Y = new Address<float>();
            LipLowerB_Z = new Address<float>();
            LipLowerB_W = new Address<float>();
            HrothLipUpperRight_X = new Address<float>();
            HrothLipUpperRight_Y = new Address<float>();
            HrothLipUpperRight_Z = new Address<float>();
            HrothLipUpperRight_W = new Address<float>();
            VieraEar02ALeft_X = new Address<float>();
            VieraEar02ALeft_Y = new Address<float>();
            VieraEar02ALeft_Z = new Address<float>();
            VieraEar02ALeft_W = new Address<float>();
            HrothLipLower_X = new Address<float>();
            HrothLipLower_Y = new Address<float>();
            HrothLipLower_Z = new Address<float>();
            HrothLipLower_W = new Address<float>();
            VieraEar02ARight_X = new Address<float>();
            VieraEar02ARight_Y = new Address<float>();
            VieraEar02ARight_Z = new Address<float>();
            VieraEar02ARight_W = new Address<float>();
            VieraEar03ALeft_X = new Address<float>();
            VieraEar03ALeft_Y = new Address<float>();
            VieraEar03ALeft_Z = new Address<float>();
            VieraEar03ALeft_W = new Address<float>();
            VieraEar03ARight_X = new Address<float>();
            VieraEar03ARight_Y = new Address<float>();
            VieraEar03ARight_Z = new Address<float>();
            VieraEar03ARight_W = new Address<float>();
            VieraEar04ALeft_X = new Address<float>();
            VieraEar04ALeft_Y = new Address<float>();
            VieraEar04ALeft_Z = new Address<float>();
            VieraEar04ALeft_W = new Address<float>();
            VieraEar04ARight_X = new Address<float>();
            VieraEar04ARight_Y = new Address<float>();
            VieraEar04ARight_Z = new Address<float>();
            VieraEar04ARight_W = new Address<float>();
            VieraLipLowerA_X = new Address<float>();
            VieraLipLowerA_Y = new Address<float>();
            VieraLipLowerA_Z = new Address<float>();
            VieraLipLowerA_W = new Address<float>();
            VieraLipUpperB_X = new Address<float>();
            VieraLipUpperB_Y = new Address<float>();
            VieraLipUpperB_Z = new Address<float>();
            VieraLipUpperB_W = new Address<float>();
            VieraEar01BLeft_X = new Address<float>();
            VieraEar01BLeft_Y = new Address<float>();
            VieraEar01BLeft_Z = new Address<float>();
            VieraEar01BLeft_W = new Address<float>();
            VieraEar01BRight_X = new Address<float>();
            VieraEar01BRight_Y = new Address<float>();
            VieraEar01BRight_Z = new Address<float>();
            VieraEar01BRight_W = new Address<float>();
            VieraEar02BLeft_X = new Address<float>();
            VieraEar02BLeft_Y = new Address<float>();
            VieraEar02BLeft_Z = new Address<float>();
            VieraEar02BLeft_W = new Address<float>();
            VieraEar02BRight_X = new Address<float>();
            VieraEar02BRight_Y = new Address<float>();
            VieraEar02BRight_Z = new Address<float>();
            VieraEar02BRight_W = new Address<float>();
            VieraEar03BLeft_X = new Address<float>();
            VieraEar03BLeft_Y = new Address<float>();
            VieraEar03BLeft_Z = new Address<float>();
            VieraEar03BLeft_W = new Address<float>();
            VieraEar03BRight_X = new Address<float>();
            VieraEar03BRight_Y = new Address<float>();
            VieraEar03BRight_Z = new Address<float>();
            VieraEar03BRight_W = new Address<float>();
            VieraEar04BLeft_X = new Address<float>();
            VieraEar04BLeft_Y = new Address<float>();
            VieraEar04BLeft_Z = new Address<float>();
            VieraEar04BLeft_W = new Address<float>();
            VieraEar04BRight_X = new Address<float>();
            VieraEar04BRight_Y = new Address<float>();
            VieraEar04BRight_Z = new Address<float>();
            VieraEar04BRight_W = new Address<float>();
            VieraLipLowerB_X = new Address<float>();
            VieraLipLowerB_Y = new Address<float>();
            VieraLipLowerB_Z = new Address<float>();
            VieraLipLowerB_W = new Address<float>();
            ExRootHair_X = new Address<float>();
            ExRootHair_Y = new Address<float>();
            ExRootHair_Z = new Address<float>();
            ExRootHair_W = new Address<float>();
            ExHairA_X = new Address<float>();
            ExHairA_Y = new Address<float>();
            ExHairA_Z = new Address<float>();
            ExHairA_W = new Address<float>();
            ExHairB_X = new Address<float>();
            ExHairB_Y = new Address<float>();
            ExHairB_Z = new Address<float>();
            ExHairB_W = new Address<float>();
            ExHairC_X = new Address<float>();
            ExHairC_Y = new Address<float>();
            ExHairC_Z = new Address<float>();
            ExHairC_W = new Address<float>();
            ExHairD_X = new Address<float>();
            ExHairD_Y = new Address<float>();
            ExHairD_Z = new Address<float>();
            ExHairD_W = new Address<float>();
            ExHairE_X = new Address<float>();
            ExHairE_Y = new Address<float>();
            ExHairE_Z = new Address<float>();
            ExHairE_W = new Address<float>();
            ExHairF_X = new Address<float>();
            ExHairF_Y = new Address<float>();
            ExHairF_Z = new Address<float>();
            ExHairF_W = new Address<float>();
            ExHairG_X = new Address<float>();
            ExHairG_Y = new Address<float>();
            ExHairG_Z = new Address<float>();
            ExHairG_W = new Address<float>();
            ExHairH_X = new Address<float>();
            ExHairH_Y = new Address<float>();
            ExHairH_Z = new Address<float>();
            ExHairH_W = new Address<float>();
            ExHairI_X = new Address<float>();
            ExHairI_Y = new Address<float>();
            ExHairI_Z = new Address<float>();
            ExHairI_W = new Address<float>();
            ExHairJ_X = new Address<float>();
            ExHairJ_Y = new Address<float>();
            ExHairJ_Z = new Address<float>();
            ExHairJ_W = new Address<float>();
            ExHairK_X = new Address<float>();
            ExHairK_Y = new Address<float>();
            ExHairK_Z = new Address<float>();
            ExHairK_W = new Address<float>();
            ExHairL_X = new Address<float>();
            ExHairL_Y = new Address<float>();
            ExHairL_Z = new Address<float>();
            ExHairL_W = new Address<float>();
            ExRootMet_X = new Address<float>();
            ExRootMet_Y = new Address<float>();
            ExRootMet_Z = new Address<float>();
            ExRootMet_W = new Address<float>();
            ExMetA_X = new Address<float>();
            ExMetA_Y = new Address<float>();
            ExMetA_Z = new Address<float>();
            ExMetA_W = new Address<float>();
            ExMetB_X = new Address<float>();
            ExMetB_Y = new Address<float>();
            ExMetB_Z = new Address<float>();
            ExMetB_W = new Address<float>();
            ExMetC_X = new Address<float>();
            ExMetC_Y = new Address<float>();
            ExMetC_Z = new Address<float>();
            ExMetC_W = new Address<float>();
            ExMetD_X = new Address<float>();
            ExMetD_Y = new Address<float>();
            ExMetD_Z = new Address<float>();
            ExMetD_W = new Address<float>();
            ExMetE_X = new Address<float>();
            ExMetE_Y = new Address<float>();
            ExMetE_Z = new Address<float>();
            ExMetE_W = new Address<float>();
            ExMetF_X = new Address<float>();
            ExMetF_Y = new Address<float>();
            ExMetF_Z = new Address<float>();
            ExMetF_W = new Address<float>();
            ExMetG_X = new Address<float>();
            ExMetG_Y = new Address<float>();
            ExMetG_Z = new Address<float>();
            ExMetG_W = new Address<float>();
            ExMetH_X = new Address<float>();
            ExMetH_Y = new Address<float>();
            ExMetH_Z = new Address<float>();
            ExMetH_W = new Address<float>();
            ExMetI_X = new Address<float>();
            ExMetI_Y = new Address<float>();
            ExMetI_Z = new Address<float>();
            ExMetI_W = new Address<float>();
            ExMetJ_X = new Address<float>();
            ExMetJ_Y = new Address<float>();
            ExMetJ_Z = new Address<float>();
            ExMetJ_W = new Address<float>();
            ExMetK_X = new Address<float>();
            ExMetK_Y = new Address<float>();
            ExMetK_Z = new Address<float>();
            ExMetK_W = new Address<float>();
            ExMetL_X = new Address<float>();
            ExMetL_Y = new Address<float>();
            ExMetL_Z = new Address<float>();
            ExMetL_W = new Address<float>();
            ExMetM_X = new Address<float>();
            ExMetM_Y = new Address<float>();
            ExMetM_Z = new Address<float>();
            ExMetM_W = new Address<float>();
            ExMetN_X = new Address<float>();
            ExMetN_Y = new Address<float>();
            ExMetN_Z = new Address<float>();
            ExMetN_W = new Address<float>();
            ExMetO_X = new Address<float>();
            ExMetO_Y = new Address<float>();
            ExMetO_Z = new Address<float>();
            ExMetO_W = new Address<float>();
            ExMetP_X = new Address<float>();
            ExMetP_Y = new Address<float>();
            ExMetP_Z = new Address<float>();
            ExMetP_W = new Address<float>();
            ExMetQ_X = new Address<float>();
            ExMetQ_Y = new Address<float>();
            ExMetQ_Z = new Address<float>();
            ExMetQ_W = new Address<float>();
            ExMetR_X = new Address<float>();
            ExMetR_Y = new Address<float>();
            ExMetR_Z = new Address<float>();
            ExMetR_W = new Address<float>();
            ExRootTop_X = new Address<float>();
            ExRootTop_Y = new Address<float>();
            ExRootTop_Z = new Address<float>();
            ExRootTop_W = new Address<float>();
            ExTopA_X = new Address<float>();
            ExTopA_Y = new Address<float>();
            ExTopA_Z = new Address<float>();
            ExTopA_W = new Address<float>();
            ExTopB_X = new Address<float>();
            ExTopB_Y = new Address<float>();
            ExTopB_Z = new Address<float>();
            ExTopB_W = new Address<float>();
            ExTopC_X = new Address<float>();
            ExTopC_Y = new Address<float>();
            ExTopC_Z = new Address<float>();
            ExTopC_W = new Address<float>();
            ExTopD_X = new Address<float>();
            ExTopD_Y = new Address<float>();
            ExTopD_Z = new Address<float>();
            ExTopD_W = new Address<float>();
            ExTopE_X = new Address<float>();
            ExTopE_Y = new Address<float>();
            ExTopE_Z = new Address<float>();
            ExTopE_W = new Address<float>();
            ExTopF_X = new Address<float>();
            ExTopF_Y = new Address<float>();
            ExTopF_Z = new Address<float>();
            ExTopF_W = new Address<float>();
            ExTopG_X = new Address<float>();
            ExTopG_Y = new Address<float>();
            ExTopG_Z = new Address<float>();
            ExTopG_W = new Address<float>();
            ExTopH_X = new Address<float>();
            ExTopH_Y = new Address<float>();
            ExTopH_Z = new Address<float>();
            ExTopH_W = new Address<float>();
            ExTopI_X = new Address<float>();
            ExTopI_Y = new Address<float>();
            ExTopI_Z = new Address<float>();
            ExTopI_W = new Address<float>();
            #endregion
            #region Bone Values
            ExHair_Value = new Address<byte>();
            ExMet_Value = new Address<byte>();
            ExTop_Value = new Address<byte>();
            #endregion
        }
    }
}