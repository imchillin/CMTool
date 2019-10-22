using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptMatrix.Models
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

        [JsonIgnore] public Address<float> HeadX { get; set; }
        [JsonIgnore] public Address<float> NoseX { get; set; }
        [JsonIgnore] public Address<float> NostrilsX { get; set; }
        [JsonIgnore] public Address<float> ChinX { get; set; }
        [JsonIgnore] public Address<float> LOutEyebrowX { get; set; }
        [JsonIgnore] public Address<float> ROutEyebrowX { get; set; }
        [JsonIgnore] public Address<float> LInEyebrowX { get; set; }
        [JsonIgnore] public Address<float> RInEyebrowX { get; set; }
        [JsonIgnore] public Address<float> LEyeX { get; set; }
        [JsonIgnore] public Address<float> REyeX { get; set; }
        [JsonIgnore] public Address<float> LEyelidX { get; set; }
        [JsonIgnore] public Address<float> REyelidX { get; set; }
        [JsonIgnore] public Address<float> LLowEyelidX { get; set; }
        [JsonIgnore] public Address<float> RLowEyelidX { get; set; }
        [JsonIgnore] public Address<float> LEarX { get; set; }
        [JsonIgnore] public Address<float> REarX { get; set; }
        [JsonIgnore] public Address<float> LCheekX { get; set; }
        [JsonIgnore] public Address<float> RCheekX { get; set; }
        [JsonIgnore] public Address<float> LMouthX { get; set; }
        [JsonIgnore] public Address<float> RMouthX { get; set; }
        [JsonIgnore] public Address<float> LUpLipX { get; set; }
        [JsonIgnore] public Address<float> RUpLipX { get; set; }
        [JsonIgnore] public Address<float> LLowLipX { get; set; }
        [JsonIgnore] public Address<float> RLowLipX { get; set; }
        [JsonIgnore] public Address<float> NeckX { get; set; }
        [JsonIgnore] public Address<float> SternumX { get; set; }
        [JsonIgnore] public Address<float> TorsoX { get; set; }
        [JsonIgnore] public Address<float> WaistX { get; set; }
        [JsonIgnore] public Address<float> LShoulderX { get; set; }
        [JsonIgnore] public Address<float> RShoulderX { get; set; }
        [JsonIgnore] public Address<float> LClavicleX { get; set; }
        [JsonIgnore] public Address<float> RClavicleX { get; set; }
        [JsonIgnore] public Address<float> LBreastX { get; set; }
        [JsonIgnore] public Address<float> RBreastX { get; set; }
        [JsonIgnore] public Address<float> LArmX { get; set; }
        [JsonIgnore] public Address<float> RArmX { get; set; }
        [JsonIgnore] public Address<float> LElbowX { get; set; }
        [JsonIgnore] public Address<float> RElbowX { get; set; }
        [JsonIgnore] public Address<float> LForearmX { get; set; }
        [JsonIgnore] public Address<float> RForearmX { get; set; }
        [JsonIgnore] public Address<float> LWristX { get; set; }
        [JsonIgnore] public Address<float> RWristX { get; set; }
        [JsonIgnore] public Address<float> LHandX { get; set; }
        [JsonIgnore] public Address<float> RHandX { get; set; }
        [JsonIgnore] public Address<float> LThumbX { get; set; }
        [JsonIgnore] public Address<float> RThumbX { get; set; }
        [JsonIgnore] public Address<float> LThumb2X { get; set; }
        [JsonIgnore] public Address<float> RThumb2X { get; set; }
        [JsonIgnore] public Address<float> LIndexX { get; set; }
        [JsonIgnore] public Address<float> RIndexX { get; set; }
        [JsonIgnore] public Address<float> LIndex2X { get; set; }
        [JsonIgnore] public Address<float> RIndex2X { get; set; }
        [JsonIgnore] public Address<float> LMiddleX { get; set; }
        [JsonIgnore] public Address<float> RMiddleX { get; set; }
        [JsonIgnore] public Address<float> LMiddle2X { get; set; }
        [JsonIgnore] public Address<float> RMiddle2X { get; set; }
        [JsonIgnore] public Address<float> LRingX { get; set; }
        [JsonIgnore] public Address<float> RRingX { get; set; }
        [JsonIgnore] public Address<float> LRing2X { get; set; }
        [JsonIgnore] public Address<float> RRing2X { get; set; }
        [JsonIgnore] public Address<float> LPinkyX { get; set; }
        [JsonIgnore] public Address<float> RPinkyX { get; set; }
        [JsonIgnore] public Address<float> LPinky2X { get; set; }
        [JsonIgnore] public Address<float> RPinky2X { get; set; }
        [JsonIgnore] public Address<float> PelvisX { get; set; }
        [JsonIgnore] public Address<float> TailX { get; set; }
        [JsonIgnore] public Address<float> LThighX { get; set; }
        [JsonIgnore] public Address<float> RThighX { get; set; }
        [JsonIgnore] public Address<float> LKneeX { get; set; }
        [JsonIgnore] public Address<float> RKneeX { get; set; }
        [JsonIgnore] public Address<float> LCalfX { get; set; }
        [JsonIgnore] public Address<float> RCalfX { get; set; }
        [JsonIgnore] public Address<float> LFootX { get; set; }
        [JsonIgnore] public Address<float> RFootX { get; set; }
        [JsonIgnore] public Address<float> LToesX { get; set; }
        [JsonIgnore] public Address<float> RToesX { get; set; }
        [JsonIgnore] public Address<float> HeadY { get; set; }
        [JsonIgnore] public Address<float> NoseY { get; set; }
        [JsonIgnore] public Address<float> NostrilsY { get; set; }
        [JsonIgnore] public Address<float> ChinY { get; set; }
        [JsonIgnore] public Address<float> LOutEyebrowY { get; set; }
        [JsonIgnore] public Address<float> ROutEyebrowY { get; set; }
        [JsonIgnore] public Address<float> LInEyebrowY { get; set; }
        [JsonIgnore] public Address<float> RInEyebrowY { get; set; }
        [JsonIgnore] public Address<float> LEyeY { get; set; }
        [JsonIgnore] public Address<float> REyeY { get; set; }
        [JsonIgnore] public Address<float> LEyelidY { get; set; }
        [JsonIgnore] public Address<float> REyelidY { get; set; }
        [JsonIgnore] public Address<float> LLowEyelidY { get; set; }
        [JsonIgnore] public Address<float> RLowEyelidY { get; set; }
        [JsonIgnore] public Address<float> LEarY { get; set; }
        [JsonIgnore] public Address<float> REarY { get; set; }
        [JsonIgnore] public Address<float> LCheekY { get; set; }
        [JsonIgnore] public Address<float> RCheekY { get; set; }
        [JsonIgnore] public Address<float> LMouthY { get; set; }
        [JsonIgnore] public Address<float> RMouthY { get; set; }
        [JsonIgnore] public Address<float> LUpLipY { get; set; }
        [JsonIgnore] public Address<float> RUpLipY { get; set; }
        [JsonIgnore] public Address<float> LLowLipY { get; set; }
        [JsonIgnore] public Address<float> RLowLipY { get; set; }
        [JsonIgnore] public Address<float> NeckY { get; set; }
        [JsonIgnore] public Address<float> SternumY { get; set; }
        [JsonIgnore] public Address<float> TorsoY { get; set; }
        [JsonIgnore] public Address<float> WaistY { get; set; }
        [JsonIgnore] public Address<float> LShoulderY { get; set; }
        [JsonIgnore] public Address<float> RShoulderY { get; set; }
        [JsonIgnore] public Address<float> LClavicleY { get; set; }
        [JsonIgnore] public Address<float> RClavicleY { get; set; }
        [JsonIgnore] public Address<float> LBreastY { get; set; }
        [JsonIgnore] public Address<float> RBreastY { get; set; }
        [JsonIgnore] public Address<float> LArmY { get; set; }
        [JsonIgnore] public Address<float> RArmY { get; set; }
        [JsonIgnore] public Address<float> LElbowY { get; set; }
        [JsonIgnore] public Address<float> RElbowY { get; set; }
        [JsonIgnore] public Address<float> LForearmY { get; set; }
        [JsonIgnore] public Address<float> RForearmY { get; set; }
        [JsonIgnore] public Address<float> LWristY { get; set; }
        [JsonIgnore] public Address<float> RWristY { get; set; }
        [JsonIgnore] public Address<float> LHandY { get; set; }
        [JsonIgnore] public Address<float> RHandY { get; set; }
        [JsonIgnore] public Address<float> LThumbY { get; set; }
        [JsonIgnore] public Address<float> RThumbY { get; set; }
        [JsonIgnore] public Address<float> LThumb2Y { get; set; }
        [JsonIgnore] public Address<float> RThumb2Y { get; set; }
        [JsonIgnore] public Address<float> LIndexY { get; set; }
        [JsonIgnore] public Address<float> RIndexY { get; set; }
        [JsonIgnore] public Address<float> LIndex2Y { get; set; }
        [JsonIgnore] public Address<float> RIndex2Y { get; set; }
        [JsonIgnore] public Address<float> LMiddleY { get; set; }
        [JsonIgnore] public Address<float> RMiddleY { get; set; }
        [JsonIgnore] public Address<float> LMiddle2Y { get; set; }
        [JsonIgnore] public Address<float> RMiddle2Y { get; set; }
        [JsonIgnore] public Address<float> LRingY { get; set; }
        [JsonIgnore] public Address<float> RRingY { get; set; }
        [JsonIgnore] public Address<float> LRing2Y { get; set; }
        [JsonIgnore] public Address<float> RRing2Y { get; set; }
        [JsonIgnore] public Address<float> LPinkyY { get; set; }
        [JsonIgnore] public Address<float> RPinkyY { get; set; }
        [JsonIgnore] public Address<float> LPinky2Y { get; set; }
        [JsonIgnore] public Address<float> RPinky2Y { get; set; }
        [JsonIgnore] public Address<float> PelvisY { get; set; }
        [JsonIgnore] public Address<float> TailY { get; set; }
        [JsonIgnore] public Address<float> LThighY { get; set; }
        [JsonIgnore] public Address<float> RThighY { get; set; }
        [JsonIgnore] public Address<float> LKneeY { get; set; }
        [JsonIgnore] public Address<float> RKneeY { get; set; }
        [JsonIgnore] public Address<float> LCalfY { get; set; }
        [JsonIgnore] public Address<float> RCalfY { get; set; }
        [JsonIgnore] public Address<float> LFootY { get; set; }
        [JsonIgnore] public Address<float> RFootY { get; set; }
        [JsonIgnore] public Address<float> LToesY { get; set; }
        [JsonIgnore] public Address<float> RToesY { get; set; }
        [JsonIgnore] public Address<float> HeadZ { get; set; }
        [JsonIgnore] public Address<float> NoseZ { get; set; }
        [JsonIgnore] public Address<float> NostrilsZ { get; set; }
        [JsonIgnore] public Address<float> ChinZ { get; set; }
        [JsonIgnore] public Address<float> LOutEyebrowZ { get; set; }
        [JsonIgnore] public Address<float> ROutEyebrowZ { get; set; }
        [JsonIgnore] public Address<float> LInEyebrowZ { get; set; }
        [JsonIgnore] public Address<float> RInEyebrowZ { get; set; }
        [JsonIgnore] public Address<float> LEyeZ { get; set; }
        [JsonIgnore] public Address<float> REyeZ { get; set; }
        [JsonIgnore] public Address<float> LEyelidZ { get; set; }
        [JsonIgnore] public Address<float> REyelidZ { get; set; }
        [JsonIgnore] public Address<float> LLowEyelidZ { get; set; }
        [JsonIgnore] public Address<float> RLowEyelidZ { get; set; }
        [JsonIgnore] public Address<float> LEarZ { get; set; }
        [JsonIgnore] public Address<float> REarZ { get; set; }
        [JsonIgnore] public Address<float> LCheekZ { get; set; }
        [JsonIgnore] public Address<float> RCheekZ { get; set; }
        [JsonIgnore] public Address<float> LMouthZ { get; set; }
        [JsonIgnore] public Address<float> RMouthZ { get; set; }
        [JsonIgnore] public Address<float> LUpLipZ { get; set; }
        [JsonIgnore] public Address<float> RUpLipZ { get; set; }
        [JsonIgnore] public Address<float> LLowLipZ { get; set; }
        [JsonIgnore] public Address<float> RLowLipZ { get; set; }
        [JsonIgnore] public Address<float> NeckZ { get; set; }
        [JsonIgnore] public Address<float> SternumZ { get; set; }
        [JsonIgnore] public Address<float> TorsoZ { get; set; }
        [JsonIgnore] public Address<float> WaistZ { get; set; }
        [JsonIgnore] public Address<float> LShoulderZ { get; set; }
        [JsonIgnore] public Address<float> RShoulderZ { get; set; }
        [JsonIgnore] public Address<float> LClavicleZ { get; set; }
        [JsonIgnore] public Address<float> RClavicleZ { get; set; }
        [JsonIgnore] public Address<float> LBreastZ { get; set; }
        [JsonIgnore] public Address<float> RBreastZ { get; set; }
        [JsonIgnore] public Address<float> LArmZ { get; set; }
        [JsonIgnore] public Address<float> RArmZ { get; set; }
        [JsonIgnore] public Address<float> LElbowZ { get; set; }
        [JsonIgnore] public Address<float> RElbowZ { get; set; }
        [JsonIgnore] public Address<float> LForearmZ { get; set; }
        [JsonIgnore] public Address<float> RForearmZ { get; set; }
        [JsonIgnore] public Address<float> LWristZ { get; set; }
        [JsonIgnore] public Address<float> RWristZ { get; set; }
        [JsonIgnore] public Address<float> LHandZ { get; set; }
        [JsonIgnore] public Address<float> RHandZ { get; set; }
        [JsonIgnore] public Address<float> LThumbZ { get; set; }
        [JsonIgnore] public Address<float> RThumbZ { get; set; }
        [JsonIgnore] public Address<float> LThumb2Z { get; set; }
        [JsonIgnore] public Address<float> RThumb2Z { get; set; }
        [JsonIgnore] public Address<float> LIndexZ { get; set; }
        [JsonIgnore] public Address<float> RIndexZ { get; set; }
        [JsonIgnore] public Address<float> LIndex2Z { get; set; }
        [JsonIgnore] public Address<float> RIndex2Z { get; set; }
        [JsonIgnore] public Address<float> LMiddleZ { get; set; }
        [JsonIgnore] public Address<float> RMiddleZ { get; set; }
        [JsonIgnore] public Address<float> LMiddle2Z { get; set; }
        [JsonIgnore] public Address<float> RMiddle2Z { get; set; }
        [JsonIgnore] public Address<float> LRingZ { get; set; }
        [JsonIgnore] public Address<float> RRingZ { get; set; }
        [JsonIgnore] public Address<float> LRing2Z { get; set; }
        [JsonIgnore] public Address<float> RRing2Z { get; set; }
        [JsonIgnore] public Address<float> LPinkyZ { get; set; }
        [JsonIgnore] public Address<float> RPinkyZ { get; set; }
        [JsonIgnore] public Address<float> LPinky2Z { get; set; }
        [JsonIgnore] public Address<float> RPinky2Z { get; set; }
        [JsonIgnore] public Address<float> PelvisZ { get; set; }
        [JsonIgnore] public Address<float> TailZ { get; set; }
        [JsonIgnore] public Address<float> LThighZ { get; set; }
        [JsonIgnore] public Address<float> RThighZ { get; set; }
        [JsonIgnore] public Address<float> LKneeZ { get; set; }
        [JsonIgnore] public Address<float> RKneeZ { get; set; }
        [JsonIgnore] public Address<float> LCalfZ { get; set; }
        [JsonIgnore] public Address<float> RCalfZ { get; set; }
        [JsonIgnore] public Address<float> LFootZ { get; set; }
        [JsonIgnore] public Address<float> RFootZ { get; set; }
        [JsonIgnore] public Address<float> LToesZ { get; set; }
        [JsonIgnore] public Address<float> RToesZ { get; set; }
        [JsonIgnore] public Address<float> HeadW { get; set; }
        [JsonIgnore] public Address<float> NoseW { get; set; }
        [JsonIgnore] public Address<float> NostrilsW { get; set; }
        [JsonIgnore] public Address<float> ChinW { get; set; }
        [JsonIgnore] public Address<float> LOutEyebrowW { get; set; }
        [JsonIgnore] public Address<float> ROutEyebrowW { get; set; }
        [JsonIgnore] public Address<float> LInEyebrowW { get; set; }
        [JsonIgnore] public Address<float> RInEyebrowW { get; set; }
        [JsonIgnore] public Address<float> LEyeW { get; set; }
        [JsonIgnore] public Address<float> REyeW { get; set; }
        [JsonIgnore] public Address<float> LEyelidW { get; set; }
        [JsonIgnore] public Address<float> REyelidW { get; set; }
        [JsonIgnore] public Address<float> LLowEyelidW { get; set; }
        [JsonIgnore] public Address<float> RLowEyelidW { get; set; }
        [JsonIgnore] public Address<float> LEarW { get; set; }
        [JsonIgnore] public Address<float> REarW { get; set; }
        [JsonIgnore] public Address<float> LCheekW { get; set; }
        [JsonIgnore] public Address<float> RCheekW { get; set; }
        [JsonIgnore] public Address<float> LMouthW { get; set; }
        [JsonIgnore] public Address<float> RMouthW { get; set; }
        [JsonIgnore] public Address<float> LUpLipW { get; set; }
        [JsonIgnore] public Address<float> RUpLipW { get; set; }
        [JsonIgnore] public Address<float> LLowLipW { get; set; }
        [JsonIgnore] public Address<float> RLowLipW { get; set; }
        [JsonIgnore] public Address<float> NeckW { get; set; }
        [JsonIgnore] public Address<float> SternumW { get; set; }
        [JsonIgnore] public Address<float> TorsoW { get; set; }
        [JsonIgnore] public Address<float> WaistW { get; set; }
        [JsonIgnore] public Address<float> LShoulderW { get; set; }
        [JsonIgnore] public Address<float> RShoulderW { get; set; }
        [JsonIgnore] public Address<float> LClavicleW { get; set; }
        [JsonIgnore] public Address<float> RClavicleW { get; set; }
        [JsonIgnore] public Address<float> LBreastW { get; set; }
        [JsonIgnore] public Address<float> RBreastW { get; set; }
        [JsonIgnore] public Address<float> LArmW { get; set; }
        [JsonIgnore] public Address<float> RArmW { get; set; }
        [JsonIgnore] public Address<float> LElbowW { get; set; }
        [JsonIgnore] public Address<float> RElbowW { get; set; }
        [JsonIgnore] public Address<float> LForearmW { get; set; }
        [JsonIgnore] public Address<float> RForearmW { get; set; }
        [JsonIgnore] public Address<float> LWristW { get; set; }
        [JsonIgnore] public Address<float> RWristW { get; set; }
        [JsonIgnore] public Address<float> LHandW { get; set; }
        [JsonIgnore] public Address<float> RHandW { get; set; }
        [JsonIgnore] public Address<float> LThumbW { get; set; }
        [JsonIgnore] public Address<float> RThumbW { get; set; }
        [JsonIgnore] public Address<float> LThumb2W { get; set; }
        [JsonIgnore] public Address<float> RThumb2W { get; set; }
        [JsonIgnore] public Address<float> LIndexW { get; set; }
        [JsonIgnore] public Address<float> RIndexW { get; set; }
        [JsonIgnore] public Address<float> LIndex2W { get; set; }
        [JsonIgnore] public Address<float> RIndex2W { get; set; }
        [JsonIgnore] public Address<float> LMiddleW { get; set; }
        [JsonIgnore] public Address<float> RMiddleW { get; set; }
        [JsonIgnore] public Address<float> LMiddle2W { get; set; }
        [JsonIgnore] public Address<float> RMiddle2W { get; set; }
        [JsonIgnore] public Address<float> LRingW { get; set; }
        [JsonIgnore] public Address<float> RRingW { get; set; }
        [JsonIgnore] public Address<float> LRing2W { get; set; }
        [JsonIgnore] public Address<float> RRing2W { get; set; }
        [JsonIgnore] public Address<float> LPinkyW { get; set; }
        [JsonIgnore] public Address<float> RPinkyW { get; set; }
        [JsonIgnore] public Address<float> LPinky2W { get; set; }
        [JsonIgnore] public Address<float> RPinky2W { get; set; }
        [JsonIgnore] public Address<float> PelvisW { get; set; }
        [JsonIgnore] public Address<float> TailW { get; set; }
        [JsonIgnore] public Address<float> LThighW { get; set; }
        [JsonIgnore] public Address<float> RThighW { get; set; }
        [JsonIgnore] public Address<float> LKneeW { get; set; }
        [JsonIgnore] public Address<float> RKneeW { get; set; }
        [JsonIgnore] public Address<float> LCalfW { get; set; }
        [JsonIgnore] public Address<float> RCalfW { get; set; }
        [JsonIgnore] public Address<float> LFootW { get; set; }
        [JsonIgnore] public Address<float> RFootW { get; set; }
        [JsonIgnore] public Address<float> LToesW { get; set; }
        [JsonIgnore] public Address<float> RToesW { get; set; }

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
        [JsonIgnore] public Address<byte> DataHead { get; set; }
        [JsonIgnore] public float RotateX { get; set; }
        [JsonIgnore] public float RotateY { get; set; }
        [JsonIgnore] public float RotateZ { get; set; }
        [JsonIgnore] public float BoneX { get; set; }
        [JsonIgnore] public float BoneY { get; set; }
        [JsonIgnore] public float BoneZ { get; set; }
        [JsonIgnore] public bool RotateFreeze { get; set; }
        [JsonIgnore] public bool BoneFreeze { get; set; }

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

            HeadX = new Address<float>();
            NoseX = new Address<float>();
            NostrilsX = new Address<float>();
            ChinX = new Address<float>();
            LOutEyebrowX = new Address<float>();
            ROutEyebrowX = new Address<float>();
            LInEyebrowX = new Address<float>();
            RInEyebrowX = new Address<float>();
            LEyeX = new Address<float>();
            REyeX = new Address<float>();
            LEyelidX = new Address<float>();
            REyelidX = new Address<float>();
            LLowEyelidX = new Address<float>();
            RLowEyelidX = new Address<float>();
            LEarX = new Address<float>();
            REarX = new Address<float>();
            LCheekX = new Address<float>();
            RCheekX = new Address<float>();
            LMouthX = new Address<float>();
            RMouthX = new Address<float>();
            LUpLipX = new Address<float>();
            RUpLipX = new Address<float>();
            LLowLipX = new Address<float>();
            RLowLipX = new Address<float>();
            NeckX = new Address<float>();
            SternumX = new Address<float>();
            TorsoX = new Address<float>();
            WaistX = new Address<float>();
            LShoulderX = new Address<float>();
            RShoulderX = new Address<float>();
            LClavicleX = new Address<float>();
            RClavicleX = new Address<float>();
            LBreastX = new Address<float>();
            RBreastX = new Address<float>();
            LArmX = new Address<float>();
            RArmX = new Address<float>();
            LElbowX = new Address<float>();
            RElbowX = new Address<float>();
            LForearmX = new Address<float>();
            RForearmX = new Address<float>();
            LWristX = new Address<float>();
            RWristX = new Address<float>();
            LHandX = new Address<float>();
            RHandX = new Address<float>();
            LThumbX = new Address<float>();
            RThumbX = new Address<float>();
            LThumb2X = new Address<float>();
            RThumb2X = new Address<float>();
            LIndexX = new Address<float>();
            RIndexX = new Address<float>();
            LIndex2X = new Address<float>();
            RIndex2X = new Address<float>();
            LMiddleX = new Address<float>();
            RMiddleX = new Address<float>();
            LMiddle2X = new Address<float>();
            RMiddle2X = new Address<float>();
            LRingX = new Address<float>();
            RRingX = new Address<float>();
            LRing2X = new Address<float>();
            RRing2X = new Address<float>();
            LPinkyX = new Address<float>();
            RPinkyX = new Address<float>();
            LPinky2X = new Address<float>();
            RPinky2X = new Address<float>();
            PelvisX = new Address<float>();
            TailX = new Address<float>();
            LThighX = new Address<float>();
            RThighX = new Address<float>();
            LKneeX = new Address<float>();
            RKneeX = new Address<float>();
            LCalfX = new Address<float>();
            RCalfX = new Address<float>();
            LFootX = new Address<float>();
            RFootX = new Address<float>();
            LToesX = new Address<float>();
            RToesX = new Address<float>();
            HeadY = new Address<float>();
            NoseY = new Address<float>();
            NostrilsY = new Address<float>();
            ChinY = new Address<float>();
            LOutEyebrowY = new Address<float>();
            ROutEyebrowY = new Address<float>();
            LInEyebrowY = new Address<float>();
            RInEyebrowY = new Address<float>();
            LEyeY = new Address<float>();
            REyeY = new Address<float>();
            LEyelidY = new Address<float>();
            REyelidY = new Address<float>();
            LLowEyelidY = new Address<float>();
            RLowEyelidY = new Address<float>();
            LEarY = new Address<float>();
            REarY = new Address<float>();
            LCheekY = new Address<float>();
            RCheekY = new Address<float>();
            LMouthY = new Address<float>();
            RMouthY = new Address<float>();
            LUpLipY = new Address<float>();
            RUpLipY = new Address<float>();
            LLowLipY = new Address<float>();
            RLowLipY = new Address<float>();
            NeckY = new Address<float>();
            SternumY = new Address<float>();
            TorsoY = new Address<float>();
            WaistY = new Address<float>();
            LShoulderY = new Address<float>();
            RShoulderY = new Address<float>();
            LClavicleY = new Address<float>();
            RClavicleY = new Address<float>();
            LBreastY = new Address<float>();
            RBreastY = new Address<float>();
            LArmY = new Address<float>();
            RArmY = new Address<float>();
            LElbowY = new Address<float>();
            RElbowY = new Address<float>();
            LForearmY = new Address<float>();
            RForearmY = new Address<float>();
            LWristY = new Address<float>();
            RWristY = new Address<float>();
            LHandY = new Address<float>();
            RHandY = new Address<float>();
            LThumbY = new Address<float>();
            RThumbY = new Address<float>();
            LThumb2Y = new Address<float>();
            RThumb2Y = new Address<float>();
            LIndexY = new Address<float>();
            RIndexY = new Address<float>();
            LIndex2Y = new Address<float>();
            RIndex2Y = new Address<float>();
            LMiddleY = new Address<float>();
            RMiddleY = new Address<float>();
            LMiddle2Y = new Address<float>();
            RMiddle2Y = new Address<float>();
            LRingY = new Address<float>();
            RRingY = new Address<float>();
            LRing2Y = new Address<float>();
            RRing2Y = new Address<float>();
            LPinkyY = new Address<float>();
            RPinkyY = new Address<float>();
            LPinky2Y = new Address<float>();
            RPinky2Y = new Address<float>();
            PelvisY = new Address<float>();
            TailY = new Address<float>();
            LThighY = new Address<float>();
            RThighY = new Address<float>();
            LKneeY = new Address<float>();
            RKneeY = new Address<float>();
            LCalfY = new Address<float>();
            RCalfY = new Address<float>();
            LFootY = new Address<float>();
            RFootY = new Address<float>();
            LToesY = new Address<float>();
            RToesY = new Address<float>();
            HeadZ = new Address<float>();
            NoseZ = new Address<float>();
            NostrilsZ = new Address<float>();
            ChinZ = new Address<float>();
            LOutEyebrowZ = new Address<float>();
            ROutEyebrowZ = new Address<float>();
            LInEyebrowZ = new Address<float>();
            RInEyebrowZ = new Address<float>();
            LEyeZ = new Address<float>();
            REyeZ = new Address<float>();
            LEyelidZ = new Address<float>();
            REyelidZ = new Address<float>();
            LLowEyelidZ = new Address<float>();
            RLowEyelidZ = new Address<float>();
            LEarZ = new Address<float>();
            REarZ = new Address<float>();
            LCheekZ = new Address<float>();
            RCheekZ = new Address<float>();
            LMouthZ = new Address<float>();
            RMouthZ = new Address<float>();
            LUpLipZ = new Address<float>();
            RUpLipZ = new Address<float>();
            LLowLipZ = new Address<float>();
            RLowLipZ = new Address<float>();
            NeckZ = new Address<float>();
            SternumZ = new Address<float>();
            TorsoZ = new Address<float>();
            WaistZ = new Address<float>();
            LShoulderZ = new Address<float>();
            RShoulderZ = new Address<float>();
            LClavicleZ = new Address<float>();
            RClavicleZ = new Address<float>();
            LBreastZ = new Address<float>();
            RBreastZ = new Address<float>();
            LArmZ = new Address<float>();
            RArmZ = new Address<float>();
            LElbowZ = new Address<float>();
            RElbowZ = new Address<float>();
            LForearmZ = new Address<float>();
            RForearmZ = new Address<float>();
            LWristZ = new Address<float>();
            RWristZ = new Address<float>();
            LHandZ = new Address<float>();
            RHandZ = new Address<float>();
            LThumbZ = new Address<float>();
            RThumbZ = new Address<float>();
            LThumb2Z = new Address<float>();
            RThumb2Z = new Address<float>();
            LIndexZ = new Address<float>();
            RIndexZ = new Address<float>();
            LIndex2Z = new Address<float>();
            RIndex2Z = new Address<float>();
            LMiddleZ = new Address<float>();
            RMiddleZ = new Address<float>();
            LMiddle2Z = new Address<float>();
            RMiddle2Z = new Address<float>();
            LRingZ = new Address<float>();
            RRingZ = new Address<float>();
            LRing2Z = new Address<float>();
            RRing2Z = new Address<float>();
            LPinkyZ = new Address<float>();
            RPinkyZ = new Address<float>();
            LPinky2Z = new Address<float>();
            RPinky2Z = new Address<float>();
            PelvisZ = new Address<float>();
            TailZ = new Address<float>();
            LThighZ = new Address<float>();
            RThighZ = new Address<float>();
            LKneeZ = new Address<float>();
            RKneeZ = new Address<float>();
            LCalfZ = new Address<float>();
            RCalfZ = new Address<float>();
            LFootZ = new Address<float>();
            RFootZ = new Address<float>();
            LToesZ = new Address<float>();
            RToesZ = new Address<float>();
            HeadW = new Address<float>();
            NoseW = new Address<float>();
            NostrilsW = new Address<float>();
            ChinW = new Address<float>();
            LOutEyebrowW = new Address<float>();
            ROutEyebrowW = new Address<float>();
            LInEyebrowW = new Address<float>();
            RInEyebrowW = new Address<float>();
            LEyeW = new Address<float>();
            REyeW = new Address<float>();
            LEyelidW = new Address<float>();
            REyelidW = new Address<float>();
            LLowEyelidW = new Address<float>();
            RLowEyelidW = new Address<float>();
            LEarW = new Address<float>();
            REarW = new Address<float>();
            LCheekW = new Address<float>();
            RCheekW = new Address<float>();
            LMouthW = new Address<float>();
            RMouthW = new Address<float>();
            LUpLipW = new Address<float>();
            RUpLipW = new Address<float>();
            LLowLipW = new Address<float>();
            RLowLipW = new Address<float>();
            NeckW = new Address<float>();
            SternumW = new Address<float>();
            TorsoW = new Address<float>();
            WaistW = new Address<float>();
            LShoulderW = new Address<float>();
            RShoulderW = new Address<float>();
            LClavicleW = new Address<float>();
            RClavicleW = new Address<float>();
            LBreastW = new Address<float>();
            RBreastW = new Address<float>();
            LArmW = new Address<float>();
            RArmW = new Address<float>();
            LElbowW = new Address<float>();
            RElbowW = new Address<float>();
            LForearmW = new Address<float>();
            RForearmW = new Address<float>();
            LWristW = new Address<float>();
            RWristW = new Address<float>();
            LHandW = new Address<float>();
            RHandW = new Address<float>();
            LThumbW = new Address<float>();
            RThumbW = new Address<float>();
            LThumb2W = new Address<float>();
            RThumb2W = new Address<float>();
            LIndexW = new Address<float>();
            RIndexW = new Address<float>();
            LIndex2W = new Address<float>();
            RIndex2W = new Address<float>();
            LMiddleW = new Address<float>();
            RMiddleW = new Address<float>();
            LMiddle2W = new Address<float>();
            RMiddle2W = new Address<float>();
            LRingW = new Address<float>();
            RRingW = new Address<float>();
            LRing2W = new Address<float>();
            RRing2W = new Address<float>();
            LPinkyW = new Address<float>();
            RPinkyW = new Address<float>();
            LPinky2W = new Address<float>();
            RPinky2W = new Address<float>();
            PelvisW = new Address<float>();
            TailW = new Address<float>();
            LThighW = new Address<float>();
            RThighW = new Address<float>();
            LKneeW = new Address<float>();
            RKneeW = new Address<float>();
            LCalfW = new Address<float>();
            RCalfW = new Address<float>();
            LFootW = new Address<float>();
            RFootW = new Address<float>();
            LToesW = new Address<float>();
            RToesW = new Address<float>();

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
        }
    }
}