﻿using ConceptMatrix.Models;
using ConceptMatrix.Utility;
using ConceptMatrix.ViewModel;
using System;
using Microsoft.Win32;
using Newtonsoft.Json;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media.Media3D;
using System.Windows.Data;

namespace ConceptMatrix.Views
{
    /// <summary>
    /// Interaction logic for PoseMatrixView.xaml
    /// </summary>
    public partial class PoseMatrixView : UserControl
    {
        public static PoseMatrixView PosingMatrix;
        public CharacterDetails CharacterDetails { get => (CharacterDetails)BaseViewModel.model; set => BaseViewModel.model = value; }
        private string GAS(params string[] args) => MemoryManager.GetAddressString(args);

        private MemoryManager Memory = MemoryManager.Instance;
        private readonly Mem m = MemoryManager.Instance.MemLib;
        public ToggleButton[] exhair_buttons, exmet_buttons, extop_buttons;
        public ToggleButton ToggleSave;

        public bool AdvancedMove;

        #region Savestate01 Strings
        public string Race_Sav01;

        public string Root_Sav01;
        public string Abdomen_Sav01;
        public string Throw_Sav01;
        public string Waist_Sav01;
        public string SpineA_Sav01;
        public string LegLeft_Sav01;
        public string LegRight_Sav01;
        public string HolsterLeft_Sav01;
        public string HolsterRight_Sav01;
        public string SheatheLeft_Sav01;
        public string SheatheRight_Sav01;
        public string SpineB_Sav01;
        public string ClothBackALeft_Sav01;
        public string ClothBackARight_Sav01;
        public string ClothFrontALeft_Sav01;
        public string ClothFrontARight_Sav01;
        public string ClothSideALeft_Sav01;
        public string ClothSideARight_Sav01;
        public string KneeLeft_Sav01;
        public string KneeRight_Sav01;
        public string BreastLeft_Sav01;
        public string BreastRight_Sav01;
        public string SpineC_Sav01;
        public string ClothBackBLeft_Sav01;
        public string ClothBackBRight_Sav01;
        public string ClothFrontBLeft_Sav01;
        public string ClothFrontBRight_Sav01;
        public string ClothSideBLeft_Sav01;
        public string ClothSideBRight_Sav01;
        public string CalfLeft_Sav01;
        public string CalfRight_Sav01;
        public string ScabbardLeft_Sav01;
        public string ScabbardRight_Sav01;
        public string Neck_Sav01;
        public string ClavicleLeft_Sav01;
        public string ClavicleRight_Sav01;
        public string ClothBackCLeft_Sav01;
        public string ClothBackCRight_Sav01;
        public string ClothFrontCLeft_Sav01;
        public string ClothFrontCRight_Sav01;
        public string ClothSideCLeft_Sav01;
        public string ClothSideCRight_Sav01;
        public string PoleynLeft_Sav01;
        public string PoleynRight_Sav01;
        public string FootLeft_Sav01;
        public string FootRight_Sav01;
        public string Head_Sav01;
        public string ArmLeft_Sav01;
        public string ArmRight_Sav01;
        public string PauldronLeft_Sav01;
        public string PauldronRight_Sav01;
        public string Unknown00_Sav01;
        public string ToesLeft_Sav01;
        public string ToesRight_Sav01;
        public string HairA_Sav01;
        public string HairFrontLeft_Sav01;
        public string HairFrontRight_Sav01;
        public string EarLeft_Sav01;
        public string EarRight_Sav01;
        public string ForearmLeft_Sav01;
        public string ForearmRight_Sav01;
        public string ShoulderLeft_Sav01;
        public string ShoulderRight_Sav01;
        public string HairB_Sav01;
        public string HandLeft_Sav01;
        public string HandRight_Sav01;
        public string ShieldLeft_Sav01;
        public string ShieldRight_Sav01;
        public string EarringALeft_Sav01;
        public string EarringARight_Sav01;
        public string ElbowLeft_Sav01;
        public string ElbowRight_Sav01;
        public string CouterLeft_Sav01;
        public string CouterRight_Sav01;
        public string WristLeft_Sav01;
        public string WristRight_Sav01;
        public string IndexALeft_Sav01;
        public string IndexARight_Sav01;
        public string PinkyALeft_Sav01;
        public string PinkyARight_Sav01;
        public string RingALeft_Sav01;
        public string RingARight_Sav01;
        public string MiddleALeft_Sav01;
        public string MiddleARight_Sav01;
        public string ThumbALeft_Sav01;
        public string ThumbARight_Sav01;
        public string WeaponLeft_Sav01;
        public string WeaponRight_Sav01;
        public string EarringBLeft_Sav01;
        public string EarringBRight_Sav01;
        public string IndexBLeft_Sav01;
        public string IndexBRight_Sav01;
        public string PinkyBLeft_Sav01;
        public string PinkyBRight_Sav01;
        public string RingBLeft_Sav01;
        public string RingBRight_Sav01;
        public string MiddleBLeft_Sav01;
        public string MiddleBRight_Sav01;
        public string ThumbBLeft_Sav01;
        public string ThumbBRight_Sav01;
        public string TailA_Sav01;
        public string TailB_Sav01;
        public string TailC_Sav01;
        public string TailD_Sav01;
        public string TailE_Sav01;
        public string RootHead_Sav01;
        public string Jaw_Sav01;
        public string EyelidLowerLeft_Sav01;
        public string EyelidLowerRight_Sav01;
        public string EyeLeft_Sav01;
        public string EyeRight_Sav01;
        public string Nose_Sav01;
        public string CheekLeft_Sav01;
        public string HrothWhiskersLeft_Sav01;
        public string CheekRight_Sav01;
        public string HrothWhiskersRight_Sav01;
        public string LipsLeft_Sav01;
        public string HrothEyebrowLeft_Sav01;
        public string LipsRight_Sav01;
        public string HrothEyebrowRight_Sav01;
        public string EyebrowLeft_Sav01;
        public string HrothBridge_Sav01;
        public string EyebrowRight_Sav01;
        public string HrothBrowLeft_Sav01;
        public string Bridge_Sav01;
        public string HrothBrowRight_Sav01;
        public string BrowLeft_Sav01;
        public string HrothJawUpper_Sav01;
        public string BrowRight_Sav01;
        public string HrothLipUpper_Sav01;
        public string LipUpperA_Sav01;
        public string HrothEyelidUpperLeft_Sav01;
        public string EyelidUpperLeft_Sav01;
        public string HrothEyelidUpperRight_Sav01;
        public string EyelidUpperRight_Sav01;
        public string HrothLipsLeft_Sav01;
        public string LipLowerA_Sav01;
        public string HrothLipsRight_Sav01;
        public string VieraEar01ALeft_Sav01;
        public string LipUpperB_Sav01;
        public string HrothLipUpperLeft_Sav01;
        public string VieraEar01ARight_Sav01;
        public string LipLowerB_Sav01;
        public string HrothLipUpperRight_Sav01;
        public string VieraEar02ALeft_Sav01;
        public string HrothLipLower_Sav01;
        public string VieraEar02ARight_Sav01;
        public string VieraEar03ALeft_Sav01;
        public string VieraEar03ARight_Sav01;
        public string VieraEar04ALeft_Sav01;
        public string VieraEar04ARight_Sav01;
        public string VieraLipLowerA_Sav01;
        public string VieraLipUpperB_Sav01;
        public string VieraEar01BLeft_Sav01;
        public string VieraEar01BRight_Sav01;
        public string VieraEar02BLeft_Sav01;
        public string VieraEar02BRight_Sav01;
        public string VieraEar03BLeft_Sav01;
        public string VieraEar03BRight_Sav01;
        public string VieraEar04BLeft_Sav01;
        public string VieraEar04BRight_Sav01;
        public string VieraLipLowerB_Sav01;
        public string ExRootHair_Sav01;
        public string ExHairA_Sav01;
        public string ExHairB_Sav01;
        public string ExHairC_Sav01;
        public string ExHairD_Sav01;
        public string ExHairE_Sav01;
        public string ExHairF_Sav01;
        public string ExHairG_Sav01;
        public string ExHairH_Sav01;
        public string ExHairI_Sav01;
        public string ExHairJ_Sav01;
        public string ExHairK_Sav01;
        public string ExHairL_Sav01;
        public string ExRootMet_Sav01;
        public string ExMetA_Sav01;
        public string ExMetB_Sav01;
        public string ExMetC_Sav01;
        public string ExMetD_Sav01;
        public string ExMetE_Sav01;
        public string ExMetF_Sav01;
        public string ExMetG_Sav01;
        public string ExMetH_Sav01;
        public string ExMetI_Sav01;
        public string ExMetJ_Sav01;
        public string ExMetK_Sav01;
        public string ExMetL_Sav01;
        public string ExMetM_Sav01;
        public string ExMetN_Sav01;
        public string ExMetO_Sav01;
        public string ExMetP_Sav01;
        public string ExMetQ_Sav01;
        public string ExMetR_Sav01;
        public string ExRootTop_Sav01;
        public string ExTopA_Sav01;
        public string ExTopB_Sav01;
        public string ExTopC_Sav01;
        public string ExTopD_Sav01;
        public string ExTopE_Sav01;
        public string ExTopF_Sav01;
        public string ExTopG_Sav01;
        public string ExTopH_Sav01;
        public string ExTopI_Sav01;
        #endregion
        #region Savestate02 Strings
        public string Race_Sav02;

        public string Root_Sav02;
        public string Abdomen_Sav02;
        public string Throw_Sav02;
        public string Waist_Sav02;
        public string SpineA_Sav02;
        public string LegLeft_Sav02;
        public string LegRight_Sav02;
        public string HolsterLeft_Sav02;
        public string HolsterRight_Sav02;
        public string SheatheLeft_Sav02;
        public string SheatheRight_Sav02;
        public string SpineB_Sav02;
        public string ClothBackALeft_Sav02;
        public string ClothBackARight_Sav02;
        public string ClothFrontALeft_Sav02;
        public string ClothFrontARight_Sav02;
        public string ClothSideALeft_Sav02;
        public string ClothSideARight_Sav02;
        public string KneeLeft_Sav02;
        public string KneeRight_Sav02;
        public string BreastLeft_Sav02;
        public string BreastRight_Sav02;
        public string SpineC_Sav02;
        public string ClothBackBLeft_Sav02;
        public string ClothBackBRight_Sav02;
        public string ClothFrontBLeft_Sav02;
        public string ClothFrontBRight_Sav02;
        public string ClothSideBLeft_Sav02;
        public string ClothSideBRight_Sav02;
        public string CalfLeft_Sav02;
        public string CalfRight_Sav02;
        public string ScabbardLeft_Sav02;
        public string ScabbardRight_Sav02;
        public string Neck_Sav02;
        public string ClavicleLeft_Sav02;
        public string ClavicleRight_Sav02;
        public string ClothBackCLeft_Sav02;
        public string ClothBackCRight_Sav02;
        public string ClothFrontCLeft_Sav02;
        public string ClothFrontCRight_Sav02;
        public string ClothSideCLeft_Sav02;
        public string ClothSideCRight_Sav02;
        public string PoleynLeft_Sav02;
        public string PoleynRight_Sav02;
        public string FootLeft_Sav02;
        public string FootRight_Sav02;
        public string Head_Sav02;
        public string ArmLeft_Sav02;
        public string ArmRight_Sav02;
        public string PauldronLeft_Sav02;
        public string PauldronRight_Sav02;
        public string Unknown00_Sav02;
        public string ToesLeft_Sav02;
        public string ToesRight_Sav02;
        public string HairA_Sav02;
        public string HairFrontLeft_Sav02;
        public string HairFrontRight_Sav02;
        public string EarLeft_Sav02;
        public string EarRight_Sav02;
        public string ForearmLeft_Sav02;
        public string ForearmRight_Sav02;
        public string ShoulderLeft_Sav02;
        public string ShoulderRight_Sav02;
        public string HairB_Sav02;
        public string HandLeft_Sav02;
        public string HandRight_Sav02;
        public string ShieldLeft_Sav02;
        public string ShieldRight_Sav02;
        public string EarringALeft_Sav02;
        public string EarringARight_Sav02;
        public string ElbowLeft_Sav02;
        public string ElbowRight_Sav02;
        public string CouterLeft_Sav02;
        public string CouterRight_Sav02;
        public string WristLeft_Sav02;
        public string WristRight_Sav02;
        public string IndexALeft_Sav02;
        public string IndexARight_Sav02;
        public string PinkyALeft_Sav02;
        public string PinkyARight_Sav02;
        public string RingALeft_Sav02;
        public string RingARight_Sav02;
        public string MiddleALeft_Sav02;
        public string MiddleARight_Sav02;
        public string ThumbALeft_Sav02;
        public string ThumbARight_Sav02;
        public string WeaponLeft_Sav02;
        public string WeaponRight_Sav02;
        public string EarringBLeft_Sav02;
        public string EarringBRight_Sav02;
        public string IndexBLeft_Sav02;
        public string IndexBRight_Sav02;
        public string PinkyBLeft_Sav02;
        public string PinkyBRight_Sav02;
        public string RingBLeft_Sav02;
        public string RingBRight_Sav02;
        public string MiddleBLeft_Sav02;
        public string MiddleBRight_Sav02;
        public string ThumbBLeft_Sav02;
        public string ThumbBRight_Sav02;
        public string TailA_Sav02;
        public string TailB_Sav02;
        public string TailC_Sav02;
        public string TailD_Sav02;
        public string TailE_Sav02;
        public string RootHead_Sav02;
        public string Jaw_Sav02;
        public string EyelidLowerLeft_Sav02;
        public string EyelidLowerRight_Sav02;
        public string EyeLeft_Sav02;
        public string EyeRight_Sav02;
        public string Nose_Sav02;
        public string CheekLeft_Sav02;
        public string HrothWhiskersLeft_Sav02;
        public string CheekRight_Sav02;
        public string HrothWhiskersRight_Sav02;
        public string LipsLeft_Sav02;
        public string HrothEyebrowLeft_Sav02;
        public string LipsRight_Sav02;
        public string HrothEyebrowRight_Sav02;
        public string EyebrowLeft_Sav02;
        public string HrothBridge_Sav02;
        public string EyebrowRight_Sav02;
        public string HrothBrowLeft_Sav02;
        public string Bridge_Sav02;
        public string HrothBrowRight_Sav02;
        public string BrowLeft_Sav02;
        public string HrothJawUpper_Sav02;
        public string BrowRight_Sav02;
        public string HrothLipUpper_Sav02;
        public string LipUpperA_Sav02;
        public string HrothEyelidUpperLeft_Sav02;
        public string EyelidUpperLeft_Sav02;
        public string HrothEyelidUpperRight_Sav02;
        public string EyelidUpperRight_Sav02;
        public string HrothLipsLeft_Sav02;
        public string LipLowerA_Sav02;
        public string HrothLipsRight_Sav02;
        public string VieraEar01ALeft_Sav02;
        public string LipUpperB_Sav02;
        public string HrothLipUpperLeft_Sav02;
        public string VieraEar01ARight_Sav02;
        public string LipLowerB_Sav02;
        public string HrothLipUpperRight_Sav02;
        public string VieraEar02ALeft_Sav02;
        public string HrothLipLower_Sav02;
        public string VieraEar02ARight_Sav02;
        public string VieraEar03ALeft_Sav02;
        public string VieraEar03ARight_Sav02;
        public string VieraEar04ALeft_Sav02;
        public string VieraEar04ARight_Sav02;
        public string VieraLipLowerA_Sav02;
        public string VieraLipUpperB_Sav02;
        public string VieraEar01BLeft_Sav02;
        public string VieraEar01BRight_Sav02;
        public string VieraEar02BLeft_Sav02;
        public string VieraEar02BRight_Sav02;
        public string VieraEar03BLeft_Sav02;
        public string VieraEar03BRight_Sav02;
        public string VieraEar04BLeft_Sav02;
        public string VieraEar04BRight_Sav02;
        public string VieraLipLowerB_Sav02;
        public string ExRootHair_Sav02;
        public string ExHairA_Sav02;
        public string ExHairB_Sav02;
        public string ExHairC_Sav02;
        public string ExHairD_Sav02;
        public string ExHairE_Sav02;
        public string ExHairF_Sav02;
        public string ExHairG_Sav02;
        public string ExHairH_Sav02;
        public string ExHairI_Sav02;
        public string ExHairJ_Sav02;
        public string ExHairK_Sav02;
        public string ExHairL_Sav02;
        public string ExRootMet_Sav02;
        public string ExMetA_Sav02;
        public string ExMetB_Sav02;
        public string ExMetC_Sav02;
        public string ExMetD_Sav02;
        public string ExMetE_Sav02;
        public string ExMetF_Sav02;
        public string ExMetG_Sav02;
        public string ExMetH_Sav02;
        public string ExMetI_Sav02;
        public string ExMetJ_Sav02;
        public string ExMetK_Sav02;
        public string ExMetL_Sav02;
        public string ExMetM_Sav02;
        public string ExMetN_Sav02;
        public string ExMetO_Sav02;
        public string ExMetP_Sav02;
        public string ExMetQ_Sav02;
        public string ExMetR_Sav02;
        public string ExRootTop_Sav02;
        public string ExTopA_Sav02;
        public string ExTopB_Sav02;
        public string ExTopC_Sav02;
        public string ExTopD_Sav02;
        public string ExTopE_Sav02;
        public string ExTopF_Sav02;
        public string ExTopG_Sav02;
        public string ExTopH_Sav02;
        public string ExTopI_Sav02;
        #endregion
        #region Savestate Bools
        public bool HeadSaved01;
        public bool HairSaved01;
        public bool EarringsSaved01;
        public bool BodySaved01;
        public bool LeftArmSaved01;
        public bool RightArmSaved01;
        public bool ClothesSaved01;
        public bool WeaponsSaved01;
        public bool LeftHandSaved01;
        public bool RightHandSaved01;
        public bool WaistSaved01;
        public bool LeftLegSaved01;
        public bool RightLegSaved01;
        public bool HelmSaved01;
        public bool TopSaved01;

        public bool HeadSaved02;
        public bool HairSaved02;
        public bool EarringsSaved02;
        public bool BodySaved02;
        public bool LeftArmSaved02;
        public bool RightArmSaved02;
        public bool ClothesSaved02;
        public bool WeaponsSaved02;
        public bool LeftHandSaved02;
        public bool RightHandSaved02;
        public bool WaistSaved02;
        public bool LeftLegSaved02;
        public bool RightLegSaved02;
        public bool HelmSaved02;
        public bool TopSaved02;
        #endregion

        public PoseMatrixView()
        {
            InitializeComponent();
            PosingMatrix = this;
            MainViewModel.ViewTime5 = this;
            if (SaveSettings.Default.HasBackground == false) PoseBG.Opacity = 0;
            exhair_buttons = new ToggleButton[] { ExHairA, ExHairB, ExHairC, ExHairD, ExHairE, ExHairF, ExHairG, ExHairH, ExHairI, ExHairJ, ExHairK, ExHairL };
            exmet_buttons = new ToggleButton[] { ExMetA, ExMetB, ExMetC, ExMetD, ExMetE, ExMetF, ExMetG, ExMetH, ExMetI, ExMetJ, ExMetK, ExMetL, ExMetM, ExMetN, ExMetO, ExMetP, ExMetQ, ExMetR };
            extop_buttons = new ToggleButton[] { ExTopA, ExTopB, ExTopC, ExTopD, ExTopE, ExTopF, ExTopG, ExTopH, ExTopI };
            this.DataContext = new PoseMatrixViewModel();
            if (SaveSettings.Default.ScalingLoad == true)
            {
                ScaleSaveToggle.IsChecked = true;
            }
        }
        private void EditModeButton_Checked(object sender, RoutedEventArgs e)
        {
            PoseMatrixViewModel.PoseVM.ReadTetriaryFromRunTime = false;
            EnableAll();
            PoseMatrixViewModel.PoseVM.Bone_Flag_Manager();
            Memory.MemLib.writeMemory(Memory.SkeletonAddress, "bytes", "0x90 0x90 0x90 0x90 0x90 0x90");
            Memory.MemLib.writeMemory(Memory.SkeletonAddress2, "bytes", "0x90 0x90 0x90 0x90 0x90 0x90");
            Memory.MemLib.writeMemory(Memory.SkeletonAddress3, "bytes", "0x90 0x90 0x90 0x90");
            Memory.MemLib.writeMemory(Memory.PhysicsAddress, "bytes", "0x90 0x90 0x90 0x90");
            Memory.MemLib.writeMemory(Memory.PhysicsAddress2, "bytes", "0x90 0x90 0x90");
        }

        private void EditModeButton_Unchecked(object sender, RoutedEventArgs e)
        {
            PhysicsButton.IsChecked = false;
            WeaponPoSToggle.IsChecked = false;
            ScaleEdit.IsChecked = false;
            ScaleToggle.IsChecked = false;
            HelmToggle.IsChecked = false;
            PoseMatrixViewModel.PoseVM.ReadTetriaryFromRunTime = false;
            UncheckAll();
            DisableAll();
            Memory.MemLib.writeMemory(Memory.SkeletonAddress, "bytes", "0x41 0x0F 0x29 0x5C 0x12 0x10");
            Memory.MemLib.writeMemory(Memory.SkeletonAddress2, "bytes", "0x43 0x0F 0x29 0x5C 0x18 0x10");
            Memory.MemLib.writeMemory(Memory.SkeletonAddress3, "bytes", "0x0F 0x29 0x5E 0x10");
            Memory.MemLib.writeMemory(Memory.SkeletonAddress4, "bytes", "0x41 0x0F 0x29 0x44 0x12 0x20");
            Memory.MemLib.writeMemory(Memory.SkeletonAddress6, "bytes", "0x43 0x0F 0x29 0x44 0x18 0x20");

            Memory.MemLib.writeMemory(Memory.PhysicsAddress, "bytes", "0x0F 0x29 0x48 0x10");
            Memory.MemLib.writeMemory(Memory.PhysicsAddress2, "bytes", "0x0F 0x29 0x00");
            Memory.MemLib.writeMemory(Memory.PhysicsAddress3, "bytes", "0x0F 0x29 0x40 0x20");
        }

        private void ScaleEdit_Checked(object sender, RoutedEventArgs e)
        {
            if (EditModeButton.IsChecked == true)
            {
                ScaleToggle.IsEnabled = true;
                PhysicsButton.IsChecked = false;
                PhysicsButton.IsEnabled = false;
                Memory.MemLib.writeMemory(Memory.SkeletonAddress4, "bytes", "0x90 0x90 0x90 0x90 0x90 0x90");
                Memory.MemLib.writeMemory(Memory.SkeletonAddress6, "bytes", "0x90 0x90 0x90 0x90 0x90 0x90");
                Memory.MemLib.writeMemory(Memory.PhysicsAddress3, "bytes", "0x90 0x90 0x90 0x90");
            }
        }

        private void ScaleEdit_Unchecked(object sender, RoutedEventArgs e)
        {
            if (EditModeButton.IsChecked == true)
            {
                PhysicsButton.IsEnabled = true;
                ScaleToggle.IsEnabled = false;
                Memory.MemLib.writeMemory(Memory.SkeletonAddress4, "bytes", "0x41 0x0F 0x29 0x44 0x12 0x20");
                Memory.MemLib.writeMemory(Memory.SkeletonAddress6, "bytes", "0x43 0x0F 0x29 0x44 0x18 0x20");
                Memory.MemLib.writeMemory(Memory.PhysicsAddress3, "bytes", "0x0F 0x29 0x40 0x20");
                UncheckAll();
                if (ScaleToggle.IsChecked == true)
                {
                    #region Enable Controls
                    Waist.IsEnabled = true;
                    SpineA.IsEnabled = true;
                    LegLeft.IsEnabled = true;
                    LegRight.IsEnabled = true;
                    HolsterLeft.IsEnabled = true;
                    HolsterRight.IsEnabled = true;
                    SheatheLeft.IsEnabled = true;
                    SheatheRight.IsEnabled = true;
                    SpineB.IsEnabled = true;
                    ClothBackALeft.IsEnabled = true;
                    ClothBackARight.IsEnabled = true;
                    ClothFrontALeft.IsEnabled = true;
                    ClothFrontARight.IsEnabled = true;
                    ClothSideALeft.IsEnabled = true;
                    ClothSideARight.IsEnabled = true;
                    KneeLeft.IsEnabled = true;
                    KneeRight.IsEnabled = true;
                    BreastLeft.IsEnabled = true;
                    BreastRight.IsEnabled = true;
                    SpineC.IsEnabled = true;
                    ClothBackBLeft.IsEnabled = true;
                    ClothBackBRight.IsEnabled = true;
                    ClothFrontBLeft.IsEnabled = true;
                    ClothFrontBRight.IsEnabled = true;
                    ClothSideBLeft.IsEnabled = true;
                    ClothSideBRight.IsEnabled = true;
                    CalfLeft.IsEnabled = true;
                    CalfRight.IsEnabled = true;
                    ScabbardLeft.IsEnabled = true;
                    ScabbardRight.IsEnabled = true;
                    Neck.IsEnabled = true;
                    ClavicleLeft.IsEnabled = true;
                    ClavicleRight.IsEnabled = true;
                    ClothBackCLeft.IsEnabled = true;
                    ClothBackCRight.IsEnabled = true;
                    ClothFrontCLeft.IsEnabled = true;
                    ClothFrontCRight.IsEnabled = true;
                    ClothSideCLeft.IsEnabled = true;
                    ClothSideCRight.IsEnabled = true;
                    PoleynLeft.IsEnabled = true;
                    PoleynRight.IsEnabled = true;
                    FootLeft.IsEnabled = true;
                    FootRight.IsEnabled = true;
                    Head.IsEnabled = true;
                    ArmLeft.IsEnabled = true;
                    ArmRight.IsEnabled = true;
                    PauldronLeft.IsEnabled = true;
                    PauldronRight.IsEnabled = true;
                    Unknown00.IsEnabled = true;
                    ToesLeft.IsEnabled = true;
                    ToesRight.IsEnabled = true;
                    HairA.IsEnabled = true;
                    HairFrontLeft.IsEnabled = true;
                    HairFrontRight.IsEnabled = true;
                    EarLeft.IsEnabled = true;
                    EarRight.IsEnabled = true;
                    ForearmLeft.IsEnabled = true;
                    ForearmRight.IsEnabled = true;
                    ShoulderLeft.IsEnabled = true;
                    ShoulderRight.IsEnabled = true;
                    HairB.IsEnabled = true;
                    HandLeft.IsEnabled = true;
                    HandRight.IsEnabled = true;
                    ShieldLeft.IsEnabled = true;
                    ShieldRight.IsEnabled = true;
                    EarringALeft.IsEnabled = true;
                    EarringARight.IsEnabled = true;
                    ElbowLeft.IsEnabled = true;
                    ElbowRight.IsEnabled = true;
                    CouterLeft.IsEnabled = true;
                    CouterRight.IsEnabled = true;
                    WristLeft.IsEnabled = true;
                    WristRight.IsEnabled = true;
                    IndexALeft.IsEnabled = true;
                    IndexARight.IsEnabled = true;
                    PinkyALeft.IsEnabled = true;
                    PinkyARight.IsEnabled = true;
                    RingALeft.IsEnabled = true;
                    RingARight.IsEnabled = true;
                    MiddleALeft.IsEnabled = true;
                    MiddleARight.IsEnabled = true;
                    ThumbALeft.IsEnabled = true;
                    ThumbARight.IsEnabled = true;
                    WeaponLeft.IsEnabled = true;
                    WeaponRight.IsEnabled = true;
                    EarringBLeft.IsEnabled = true;
                    EarringBRight.IsEnabled = true;
                    IndexBLeft.IsEnabled = true;
                    IndexBRight.IsEnabled = true;
                    PinkyBLeft.IsEnabled = true;
                    PinkyBRight.IsEnabled = true;
                    RingBLeft.IsEnabled = true;
                    RingBRight.IsEnabled = true;
                    MiddleBLeft.IsEnabled = true;
                    MiddleBRight.IsEnabled = true;
                    ThumbBLeft.IsEnabled = true;
                    ThumbBRight.IsEnabled = true;

                    Jaw.IsEnabled = true;
                    EyelidLowerLeft.IsEnabled = true;
                    EyelidLowerRight.IsEnabled = true;
                    EyeLeft.IsEnabled = true;
                    EyeRight.IsEnabled = true;
                    Nose.IsEnabled = true;
                    CheekLeft.IsEnabled = true;
                    CheekRight.IsEnabled = true;
                    LipsLeft.IsEnabled = true;
                    LipsRight.IsEnabled = true;
                    EyebrowLeft.IsEnabled = true;
                    EyebrowRight.IsEnabled = true;
                    Bridge.IsEnabled = true;
                    BrowLeft.IsEnabled = true;
                    BrowRight.IsEnabled = true;
                    LipUpperA.IsEnabled = true;
                    EyelidUpperLeft.IsEnabled = true;
                    EyelidUpperRight.IsEnabled = true;
                    LipLowerA.IsEnabled = true;
                    LipUpperB.IsEnabled = true;
                    LipLowerB.IsEnabled = true;

                    EnableTertiary();
                    #endregion
                    ScaleToggle.IsChecked = false;
                }
            }
        }
        private void PhysicsButton_Checked(object sender, RoutedEventArgs e)
        {
            Memory.MemLib.writeMemory(Memory.PhysicsAddress, "bytes", "0x0F 0x29 0x48 0x10");
            Memory.MemLib.writeMemory(Memory.PhysicsAddress2, "bytes", "0x0F 0x29 0x00");
        }

        private void PhysicsButton_Unchecked(object sender, RoutedEventArgs e)
        {
            if (EditModeButton.IsChecked == true)
            {
                Memory.MemLib.writeMemory(Memory.PhysicsAddress, "bytes", "0x90 0x90 0x90 0x90");
                Memory.MemLib.writeMemory(Memory.PhysicsAddress2, "bytes", "0x90 0x90 0x90");
                Memory.MemLib.writeMemory(Memory.PhysicsAddress3, "bytes", "0x90 0x90 0x90 0x90");
            }
        }

        private void Toggles_Unchecked(object sender, RoutedEventArgs e)
        {
            if (sender as ToggleButton == ToggleSave)
            {
                PoseMatrixViewModel.PoseVM.BNode = null;
                PoseMatrixViewModel.PoseVM.PointerPath = null;
                PoseMatrixViewModel.PoseVM.BoneX = 0;
                PoseMatrixViewModel.PoseVM.BoneY = 0;
                PoseMatrixViewModel.PoseVM.BoneZ = 0;
            }
        }

        private void Toggles_Checked(object sender, RoutedEventArgs e)
        {
            SwapToggles(sender as ToggleButton);
            GetPointers((sender as ToggleButton).Name);
            ToggleSave = sender as ToggleButton;
        }
        public void GetPointers(string newActive)
        {
            PoseMatrixViewModel.PoseVM.BNode = null;
            PoseMatrixViewModel.PoseVM.PointerPath = null;
            PoseMatrixViewModel.PoseVM.TheButton = newActive;
            PoseMatrixViewModel.PoseVM.PointerType = 0;
            Cube.IsEnabled = true;
            XUpDown.Minimum = 0;
            XUpDown.Maximum = 360;
            YUpDown.Maximum = 360;
            YUpDown.Minimum = 0;
            ZUpDown.Maximum = 360;
            ZUpDown.Minimum = 0;
            BoneSliderX.Maximum = 360;
            BoneSliderX.Minimum = 0;
            BoneSliderY.Maximum = 360;
            BoneSliderY.Minimum = 0;
            BoneSliderZ.Maximum = 360;
            BoneSliderZ.Minimum = 0;
            //if(newActive == "JawSize")
            switch (newActive)
            {
                #region Head
                case "Head":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.Head_Size;
                    }
                    else
                    {
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.Head_Bone;
                        PoseMatrixViewModel.PoseVM.BNode = PoseMatrixViewModel.PoseVM.bone_face;
                    }
                    break;
                case "EyebrowLeft":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        if (CharacterDetails.Race.value == 7) PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.HrothEyebrowLeft_Size;
                        else PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.EyebrowLeft_Size;
                    }
                    else
                    {
                        if (CharacterDetails.Race.value == 7) PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.HrothEyebrowLeft_Bone;
                        else PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.EyebrowLeft_Bone;
                    }
                    break;
                case "EyebrowRight":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        if (CharacterDetails.Race.value == 7) PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.HrothEyebrowRight_Size;
                        else PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.EyebrowRight_Size;
                    }
                    else
                    {
                        if (CharacterDetails.Race.value == 7) PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.HrothEyebrowRight_Bone;
                        else PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.EyebrowRight_Bone;
                    }
                    break;
                case "EyeLeft":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.EyeLeft_Size;
                    }
                    else
                    {
                        PoseMatrixViewModel.PoseVM.BNode = PoseMatrixViewModel.PoseVM.bone_eye_l;
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.EyeLeft_Bone;
                    }
                    break;
                case "EyeRight":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.EyeRight_Size;
                    }
                    else
                    {
                        PoseMatrixViewModel.PoseVM.BNode = PoseMatrixViewModel.PoseVM.bone_eye_r;
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.EyeRight_Bone;
                    }
                    break;
                case "Bridge":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        if (CharacterDetails.Race.value == 7) PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.HrothBridge_Size;
                        else PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.Bridge_Size;
                    }
                    else
                    {
                        if (CharacterDetails.Race.value == 7) PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.HrothBridge_Bone;
                        else PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.Bridge_Bone;
                    }
                    break;
                case "BrowLeft":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        if (CharacterDetails.Race.value == 7) PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.HrothBrowLeft_Size;
                        else PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.BrowLeft_Bone;
                    }
                    else
                    {
                        if (CharacterDetails.Race.value == 7) PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.HrothBrowLeft_Bone;
                        else PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.BrowLeft_Bone;
                    }
                    break;
                case "BrowRight":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        if (CharacterDetails.Race.value == 7) PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.HrothBrowRight_Size;
                        else PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.BrowRight_Size;
                    }
                    else
                    {
                        if (CharacterDetails.Race.value == 7) PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.HrothBrowRight_Bone;
                        else PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.BrowRight_Bone;
                    }
                    break;
                case "EarLeft":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.EarLeft_Size;
                    }
                    else
                    {
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.EarLeft_Bone;
                    }
                    break;
                case "EarRight":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.EarRight_Size;
                    }
                    else
                    {
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.EarRight_Bone;
                    }
                    break;
                case "Nose":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.Nose_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.Nose_Bone;
                    break;
                case "EyelidUpperLeft":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        if (CharacterDetails.Race.value == 7) PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.HrothEyelidUpperLeft_Size;
                        else PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.EyelidUpperLeft_Bone;
                    }
                    else
                    {
                        if (CharacterDetails.Race.value == 7) PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.HrothEyelidUpperLeft_Bone;
                        else PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.EyelidUpperLeft_Bone;
                    }
                    break;
                case "EyelidUpperRight":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        if (CharacterDetails.Race.value == 7) PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.HrothEyelidUpperRight_Size;
                        else PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.EyelidUpperRight_Size;
                    }
                    else
                    {
                        if (CharacterDetails.Race.value == 7) PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.HrothEyelidUpperRight_Bone;
                        else PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.EyelidUpperRight_Bone;
                    }
                    break;
                case "Jaw":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.Jaw_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.Jaw_Bone;
                    break;
                case "EyelidLowerLeft":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.EyelidLowerLeft_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.EyelidLowerLeft_Bone;
                    break;
                case "EyelidLowerRight":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.EyelidLowerRight_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.EyelidLowerRight_Bone;
                    break;
                case "CheekLeft":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        if (CharacterDetails.Race.value == 7) PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.HrothLipUpperLeft_Size;
                        else PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.CheekLeft_Size;
                    }
                    else
                    {
                        if (CharacterDetails.Race.value == 7) PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.HrothLipUpperLeft_Bone;
                        else PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.CheekLeft_Bone;
                    }
                    break;
                case "CheekRight":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        if (CharacterDetails.Race.value == 7) PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.HrothLipUpperRight_Size;
                        else PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.CheekRight_Size;
                    }
                    else
                    {
                        if (CharacterDetails.Race.value == 7) PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.HrothLipUpperRight_Bone;
                        else PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.CheekRight_Bone;
                    }
                    break;
                case "LipUpperA":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        if (CharacterDetails.Race.value == 7) PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.HrothLipUpper_Size;
                        else PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.LipUpperA_Size;
                    }
                    else
                    {
                        if (CharacterDetails.Race.value == 7) PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.HrothLipUpper_Bone;
                        else PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.LipUpperA_Bone;
                    }
                    break;
                case "LipUpperB":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        if (CharacterDetails.Race.value == 7) PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.HrothJawUpper_Size;
                        else if (CharacterDetails.Race.value == 8) PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.VieraLipUpperB_Size;
                        else PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.LipUpperB_Size;
                    }
                    else
                    {
                        if (CharacterDetails.Race.value == 7) PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.HrothJawUpper_Bone;
                        else if (CharacterDetails.Race.value == 8) PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.VieraLipUpperB_Bone;
                        else PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.LipUpperB_Bone;
                    }
                    break;
                case "LipsLeft":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        if (CharacterDetails.Race.value == 7) PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.HrothLipsLeft_Size;
                        else PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.LipsLeft_Size;
                    }
                    else
                    {
                        if (CharacterDetails.Race.value == 7) PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.HrothLipsLeft_Bone;
                        else PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.LipsLeft_Bone;
                    }
                    break;
                case "LipsRight":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        if (CharacterDetails.Race.value == 7) PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.HrothLipsRight_Size;
                        else PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.LipsRight_Size;
                    }
                    else
                    {
                        if (CharacterDetails.Race.value == 7) PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.HrothLipsRight_Bone;
                        else PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.LipsRight_Bone;
                    }
                    break;
                case "LipLowerA":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        if (CharacterDetails.Race.value == 7) PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.HrothLipLower_Size;
                        else if (CharacterDetails.Race.value == 8) PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.VieraLipLowerA_Size;
                        else PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.LipLowerA_Size;
                    }
                    else
                    {
                        if (CharacterDetails.Race.value == 7) PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.HrothLipLower_Bone;
                        else if (CharacterDetails.Race.value == 8) PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.VieraLipLowerA_Bone;
                        else PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.LipLowerA_Bone;
                    }
                    break;
                case "LipLowerB":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        if (CharacterDetails.Race.value == 8) PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.VieraLipLowerB_Size;
                        else PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.LipLowerB_Size;
                    }
                    else
                    {
                        if (CharacterDetails.Race.value == 8) PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.VieraLipLowerB_Bone;
                        else PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.LipLowerB_Bone;
                    }
                    break;
                case "VieraEarALeft":

                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        if (CharacterDetails.TailType.value == 0) PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.VieraEar01ALeft_Size;
                        else if (CharacterDetails.TailType.value == 1) PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.VieraEar01ALeft_Size;
                        else if (CharacterDetails.TailType.value == 2) PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.VieraEar02ALeft_Size;
                        else if (CharacterDetails.TailType.value == 3) PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.VieraEar03ALeft_Size;
                        else if (CharacterDetails.TailType.value == 4) PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.VieraEar04ALeft_Size;
                    }
                    else
                    {
                        if (CharacterDetails.TailType.value == 0) PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.VieraEar01ALeft_Bone;
                        else if (CharacterDetails.TailType.value == 1) PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.VieraEar01ALeft_Bone;
                        else if (CharacterDetails.TailType.value == 2) PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.VieraEar02ALeft_Bone;
                        else if (CharacterDetails.TailType.value == 3) PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.VieraEar03ALeft_Bone;
                        else if (CharacterDetails.TailType.value == 4) PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.VieraEar04ALeft_Bone;
                    }
                    break;
                case "VieraEarBLeft":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        if (CharacterDetails.TailType.value == 0) PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.VieraEar01BLeft_Bone;
                        else if (CharacterDetails.TailType.value == 1) PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.VieraEar01BLeft_Bone;
                        else if (CharacterDetails.TailType.value == 2) PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.VieraEar02BLeft_Bone;
                        else if (CharacterDetails.TailType.value == 3) PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.VieraEar03BLeft_Bone;
                        else if (CharacterDetails.TailType.value == 4) PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.VieraEar04BLeft_Bone;
                    }
                    else
                    {
                        if (CharacterDetails.TailType.value == 0) PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.VieraEar01BLeft_Bone;
                        else if (CharacterDetails.TailType.value == 1) PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.VieraEar01BLeft_Bone;
                        else if (CharacterDetails.TailType.value == 2) PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.VieraEar02BLeft_Bone;
                        else if (CharacterDetails.TailType.value == 3) PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.VieraEar03BLeft_Bone;
                        else if (CharacterDetails.TailType.value == 4) PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.VieraEar04BLeft_Bone;
                    }
                    break;
                case "VieraEarARight":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        if (CharacterDetails.TailType.value == 0) PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.VieraEar01ARight_Bone;
                        else if (CharacterDetails.TailType.value == 1) PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.VieraEar01ARight_Bone;
                        else if (CharacterDetails.TailType.value == 2) PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.VieraEar02ARight_Bone;
                        else if (CharacterDetails.TailType.value == 3) PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.VieraEar03ARight_Bone;
                        else if (CharacterDetails.TailType.value == 4) PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.VieraEar04ARight_Bone;
                    }
                    else
                    {
                        if (CharacterDetails.TailType.value == 0) PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.VieraEar01ARight_Bone;
                        else if (CharacterDetails.TailType.value == 1) PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.VieraEar01ARight_Bone;
                        else if (CharacterDetails.TailType.value == 2) PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.VieraEar02ARight_Bone;
                        else if (CharacterDetails.TailType.value == 3) PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.VieraEar03ARight_Bone;
                        else if (CharacterDetails.TailType.value == 4) PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.VieraEar04ARight_Bone;
                    }
                    break;
                case "VieraEarBRight":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        if (CharacterDetails.TailType.value == 0) PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.VieraEar01BRight_Bone;
                        else if (CharacterDetails.TailType.value == 1) PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.VieraEar01BRight_Bone;
                        else if (CharacterDetails.TailType.value == 2) PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.VieraEar02BRight_Bone;
                        else if (CharacterDetails.TailType.value == 3) PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.VieraEar03BRight_Bone;
                        else if (CharacterDetails.TailType.value == 4) PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.VieraEar04BRight_Bone;
                    }
                    else
                    {
                        if (CharacterDetails.TailType.value == 0) PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.VieraEar01BRight_Bone;
                        else if (CharacterDetails.TailType.value == 1) PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.VieraEar01BRight_Bone;
                        else if (CharacterDetails.TailType.value == 2) PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.VieraEar02BRight_Bone;
                        else if (CharacterDetails.TailType.value == 3) PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.VieraEar03BRight_Bone;
                        else if (CharacterDetails.TailType.value == 4) PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.VieraEar04BRight_Bone;
                    }
                    break;

                #endregion

                #region Hair & Accessories
                case "HairFrontLeft":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.HairFrontLeft_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.HairFrontLeft_Bone;
                    break;

                case "HairFrontRight":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.HairFrontRight_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.HairFrontRight_Bone;
                    break;

                case "HairA":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.HairA_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.HairA_Bone;
                    break;

                case "HairB":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.HairB_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.HairB_Bone;
                    break;

                case "HrothWhiskersLeft":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.HrothWhiskersLeft_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.HrothWhiskersLeft_Bone;
                    break;

                case "HrothWhiskersRight":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.HrothWhiskersRight_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.HrothWhiskersRight_Bone;
                    break;

                case "EarringALeft":
                    if (WeaponPoSToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 2;
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.EarringALeft_PoS;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.EarringALeft_Bone;
                    break;

                case "EarringARight":
                    if (WeaponPoSToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 2;
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.EarringARight_PoS;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.EarringARight_Bone;
                    break;

                case "EarringBLeft":
                    if (WeaponPoSToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 2;
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.EarringBLeft_PoS;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.EarringBLeft_Bone;
                    break;

                case "EarringBRight":
                    if (WeaponPoSToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 2;
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.EarringBRight_PoS;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.EarringBRight_Bone;
                    break;

                case "ExHairA":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ExHairA_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ExHairA_Bone;
                    break;
                case "ExHairB":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ExHairB_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ExHairB_Bone;
                    break;
                case "ExHairC":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ExHairC_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ExHairC_Bone;
                    break;
                case "ExHairD":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ExHairD_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ExHairD_Bone;
                    break;
                case "ExHairE":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ExHairE_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ExHairE_Bone;
                    break;
                case "ExHairF":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ExHairF_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ExHairF_Bone;
                    break;
                case "ExHairG":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ExHairG_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ExHairG_Bone;
                    break;
                case "ExHairH":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ExHairH_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ExHairH_Bone;
                    break;
                case "ExHairI":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ExHairI_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ExHairI_Bone;
                    break;
                case "ExHairJ":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ExHairJ_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ExHairJ_Bone;
                    break;
                case "ExHairK":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ExHairK_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ExHairK_Bone;
                    break;
                case "ExHairL":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ExHairL_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ExHairL_Bone;
                    break;
                #endregion

                #region Body
                case "Neck":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.Neck_Size;
                    }
                    else
                    {
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.Neck_Bone;
                        PoseMatrixViewModel.PoseVM.BNode = PoseMatrixViewModel.PoseVM.bone_neck;
                    }
                    break;
                case "SpineC":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.SpineC_Size;
                    }
                    else
                    {
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.SpineC_Bone;
                        PoseMatrixViewModel.PoseVM.BNode = PoseMatrixViewModel.PoseVM.bone_cerv;
                    }
                    break;
                case "SpineB":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.SpineB_Size;
                    }
                    else
                    {
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.SpineB_Bone;
                        PoseMatrixViewModel.PoseVM.BNode = PoseMatrixViewModel.PoseVM.bone_thora;
                    }
                    break;
                case "SpineA":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.SpineA_Size;
                    }
                    else
                    {
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.SpineA_Bone;
                        PoseMatrixViewModel.PoseVM.BNode = PoseMatrixViewModel.PoseVM.bone_lumbar;
                    }
                    break;
                case "ScabbardLeft":
                    if (WeaponPoSToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 2;
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ScabbardLeft_PoS;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ScabbardLeft_Bone;
                    break;
                case "ScabbardRight":
                    if (WeaponPoSToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 2;
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ScabbardRight_PoS;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ScabbardRight_Bone;
                    break;
                case "ClavicleLeft":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ClavicleLeft_Size;
                    }
                    else
                    {
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ClavicleLeft_Bone;
                        PoseMatrixViewModel.PoseVM.BNode = PoseMatrixViewModel.PoseVM.bone_clav_l;
                    }
                    break;
                case "ClavicleRight":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ClavicleRight_Size;
                    }
                    else
                    {
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ClavicleRight_Bone;
                        PoseMatrixViewModel.PoseVM.BNode = PoseMatrixViewModel.PoseVM.bone_clav_r;
                    }
                    break;
                case "BreastLeft":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.BreastLeft_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.BreastLeft_Bone;
                    break;
                case "BreastRight":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.BreastRight_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.BreastRight_Bone;
                    break;
                case "PauldronLeft":
                    PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.PauldronLeft_Bone;
                    break;
                case "PauldronRight":
                    PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.PauldronRight_Bone;
                    break;
                case "ShieldLeft":
                    PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ShieldLeft_Bone;
                    break;
                case "ShieldRight":
                    PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ShieldRight_Bone;
                    break;
                case "ShoulderLeft":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ShoulderLeft_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ShoulderLeft_Bone;
                    break;
                case "ShoulderRight":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ShoulderRight_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ShoulderRight_Bone;
                    break;
                case "ArmLeft":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ArmLeft_Size;
                    }
                    else
                    {
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ArmLeft_Bone;
                        PoseMatrixViewModel.PoseVM.BNode = PoseMatrixViewModel.PoseVM.bone_arm_l;
                    }
                    break;
                case "ArmRight":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ArmRight_Size;
                    }
                    else
                    {
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ArmRight_Bone;
                        PoseMatrixViewModel.PoseVM.BNode = PoseMatrixViewModel.PoseVM.bone_arm_r;
                    }
                    break;
                case "CouterLeft":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.CouterLeft_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.CouterLeft_Bone;
                    break;
                case "CouterRight":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.CouterRight_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.CouterRight_Bone;
                    break;
                case "ElbowLeft":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ElbowLeft_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ElbowLeft_Bone;
                    break;
                case "ElbowRight":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ElbowRight_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ElbowRight_Bone;
                    break;
                case "ForearmLeft":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ForearmLeft_Size;
                    }
                    else
                    {
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ForearmLeft_Bone;
                        PoseMatrixViewModel.PoseVM.BNode = PoseMatrixViewModel.PoseVM.bone_forearm_l;
                    }
                    break;
                case "ForearmRight":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ForearmRight_Size;
                    }
                    else
                    {
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ForearmRight_Bone;
                        PoseMatrixViewModel.PoseVM.BNode = PoseMatrixViewModel.PoseVM.bone_forearm_r;
                    }
                    break;

                case "WristLeft":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.WristLeft_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.WristLeft_Bone;
                    break;
                case "WristRight":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.WristRight_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.WristRight_Bone;
                    break;
                #endregion

                #region Clothes
                case "ClothFrontALeft":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ClothFrontALeft_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ClothFrontALeft_Bone;
                    break;
                case "ClothFrontBLeft":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ClothFrontBLeft_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ClothFrontBLeft_Bone;
                    break;
                case "ClothFrontCLeft":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ClothFrontCLeft_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ClothFrontCLeft_Bone;
                    break;
                case "ClothFrontARight":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ClothFrontARight_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ClothFrontARight_Bone;
                    break;
                case "ClothFrontBRight":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ClothFrontBRight_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ClothFrontBRight_Bone;
                    break;
                case "ClothFrontCRight":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ClothFrontCRight_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ClothFrontCRight_Bone;
                    break;

                case "ClothBackALeft":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ClothBackALeft_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ClothBackALeft_Bone;
                    break;
                case "ClothBackBLeft":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ClothBackBLeft_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ClothBackBLeft_Bone;
                    break;
                case "ClothBackCLeft":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ClothBackCLeft_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ClothBackCLeft_Bone;
                    break;

                case "ClothBackARight":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ClothBackARight_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ClothBackARight_Bone;
                    break;
                case "ClothBackBRight":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ClothBackBRight_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ClothBackBRight_Bone;
                    break;
                case "ClothBackCRight":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ClothBackCRight_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ClothBackCRight_Bone;
                    break;

                case "ClothSideALeft":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ClothSideALeft_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ClothSideALeft_Bone;
                    break;
                case "ClothSideBLeft":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ClothSideBLeft_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ClothSideBLeft_Bone;
                    break;
                case "ClothSideCLeft":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ClothSideCLeft_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ClothSideCLeft_Bone;
                    break;
                case "ClothSideARight":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ClothSideARight_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ClothSideARight_Bone;
                    break;
                case "ClothSideBRight":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ClothSideBRight_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ClothSideBRight_Bone;
                    break;
                case "ClothSideCRight":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ClothSideCRight_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ClothSideCRight_Bone;
                    break;
                #endregion

                #region Hands
                case "HandLeft":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.HandLeft_Size;
                    }
                    else
                    {
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.HandLeft_Bone;
                        PoseMatrixViewModel.PoseVM.BNode = PoseMatrixViewModel.PoseVM.bone_hand_l;
                    }
                    break;
                case "HandRight":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.HandRight_Size;
                    }
                    else
                    {
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.HandRight_Bone;
                        PoseMatrixViewModel.PoseVM.BNode = PoseMatrixViewModel.PoseVM.bone_hand_r;
                    }
                    break;
                case "WeaponLeft":
                    if (WeaponPoSToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 2;
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.WeaponLeft_PoS;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.WeaponLeft_Bone;
                    break;
                case "WeaponRight":
                    if (WeaponPoSToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 2;
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.WeaponRight_PoS;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.WeaponRight_Bone;
                    break;
                case "ThumbALeft":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ThumbALeft_Size;
                    }
                    else
                    {
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ThumbALeft_Bone;
                        PoseMatrixViewModel.PoseVM.BNode = PoseMatrixViewModel.PoseVM.bone_thumb_l;
                    }
                    break;
                case "ThumbBLeft":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ThumbBLeft_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ThumbBLeft_Bone;
                    break;
                case "ThumbARight":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ThumbARight_Size;
                    }
                    else
                    {
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ThumbARight_Bone;
                        PoseMatrixViewModel.PoseVM.BNode = PoseMatrixViewModel.PoseVM.bone_thumb_r;
                    }
                    break;
                case "ThumbBRight":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ThumbBRight_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ThumbBRight_Bone;
                    break;

                case "IndexALeft":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.IndexALeft_Size;
                    }
                    else
                    {
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.IndexALeft_Bone;
                        PoseMatrixViewModel.PoseVM.BNode = PoseMatrixViewModel.PoseVM.bone_index_l;
                    }
                    break;
                case "IndexBLeft":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.IndexBLeft_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.IndexBLeft_Bone;
                    break;
                case "IndexARight":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.IndexARight_Size;
                    }
                    else
                    {
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.IndexARight_Bone;
                        PoseMatrixViewModel.PoseVM.BNode = PoseMatrixViewModel.PoseVM.bone_index_r;
                    }
                    break;
                case "IndexBRight":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.IndexBRight_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.IndexBRight_Bone;
                    break;

                case "RingALeft":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.RingALeft_Size;
                    }
                    else
                    {
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.RingALeft_Bone;
                        PoseMatrixViewModel.PoseVM.BNode = PoseMatrixViewModel.PoseVM.bone_ring_l;
                    }
                    break;
                case "RingBLeft":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.RingBLeft_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.RingBLeft_Bone;
                    break;
                case "RingARight":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.RingARight_Size;
                    }
                    else
                    {
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.RingARight_Bone;
                        PoseMatrixViewModel.PoseVM.BNode = PoseMatrixViewModel.PoseVM.bone_ring_r;
                    }
                    break;
                case "RingBRight":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.RingBRight_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.RingBRight_Bone;
                    break;

                case "MiddleALeft":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.MiddleALeft_Size;
                    }
                    else
                    {
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.MiddleALeft_Bone;
                        PoseMatrixViewModel.PoseVM.BNode = PoseMatrixViewModel.PoseVM.bone_middle_l;
                    }
                    break;
                case "MiddleBLeft":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.MiddleBLeft_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.MiddleBLeft_Bone;
                    break;
                case "MiddleARight":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.MiddleARight_Size;
                    }
                    else
                    {
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.MiddleARight_Bone;
                        PoseMatrixViewModel.PoseVM.BNode = PoseMatrixViewModel.PoseVM.bone_middle_r;
                    }
                    break;
                case "MiddleBRight":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.MiddleBRight_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.MiddleBRight_Bone;
                    break;

                case "PinkyALeft":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.PinkyALeft_Size;
                    }
                    else
                    {
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.PinkyALeft_Bone;
                        PoseMatrixViewModel.PoseVM.BNode = PoseMatrixViewModel.PoseVM.bone_pinky_l;
                    }
                    break;
                case "PinkyBLeft":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.PinkyBLeft_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.PinkyBLeft_Bone;
                    break;
                case "PinkyARight":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.PinkyARight_Size;
                    }
                    else
                    {
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.PinkyARight_Bone;
                        PoseMatrixViewModel.PoseVM.BNode = PoseMatrixViewModel.PoseVM.bone_pinky_r;
                    }
                    break;
                case "PinkyBRight":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.PinkyBRight_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.PinkyBRight_Bone;
                    break;
                #endregion

                #region Waist & Legs
                case "Waist":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.Waist_Size;
                    }
                    else
                    {
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.Waist_Bone;
                        PoseMatrixViewModel.PoseVM.BNode = PoseMatrixViewModel.PoseVM.bone_waist;
                    }
                    break;

                case "SheatheLeft":
                    if (WeaponPoSToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 2;
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.SheatheLeft_PoS;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.SheatheLeft_Bone;
                    break;
                case "SheatheRight":
                    if (WeaponPoSToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 2;
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.SheatheRight_PoS;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.SheatheRight_Bone;
                    break;

                case "LegLeft":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.LegsLeft_Size;
                    }
                    else
                    {
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.LegsLeft_Bone;
                        PoseMatrixViewModel.PoseVM.BNode = PoseMatrixViewModel.PoseVM.bone_leg_l;
                    }
                    break;
                case "LegRight":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.LegsRight_Size;
                    }
                    else
                    {
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.LegsRight_Bone;
                        PoseMatrixViewModel.PoseVM.BNode = PoseMatrixViewModel.PoseVM.bone_leg_r;
                    }
                    break;
                case "PoleynLeft":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.PoleynLeft_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.PoleynLeft_Bone;
                    break;
                case "PoleynRight":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.PoleynRight_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.PoleynRight_Bone;
                    break;
                case "FootLeft":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.FootLeft_Size;
                    }
                    else
                    {
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.FootLeft_Bone;
                        PoseMatrixViewModel.PoseVM.BNode = PoseMatrixViewModel.PoseVM.bone_foot_l;
                    }
                    break;
                case "FootRight":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.FootRight_Size;
                    }
                    else
                    {
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.FootRight_Bone;
                        PoseMatrixViewModel.PoseVM.BNode = PoseMatrixViewModel.PoseVM.bone_foot_r;
                    }
                    break;

                case "TailA":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.TailA_Size;
                    }
                    else
                    {
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.TailA_Bone;
                        PoseMatrixViewModel.PoseVM.BNode = PoseMatrixViewModel.PoseVM.bone_tail_a;
                    }
                    break;
                case "TailB":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.TailB_Size;
                    }
                    else
                    {
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.TailB_Bone;
                        PoseMatrixViewModel.PoseVM.BNode = PoseMatrixViewModel.PoseVM.bone_tail_b;
                    }
                    break;
                case "TailC":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.TailC_Size;
                    }
                    else
                    {
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.TailC_Bone;
                        PoseMatrixViewModel.PoseVM.BNode = PoseMatrixViewModel.PoseVM.bone_tail_c;
                    }
                    break;
                case "TailD":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.TailD_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.TailD_Bone;
                    break;
                case "TailE":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.TailE_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.TailE_Bone;
                    break;
                case "HolsterLeft":
                    if (WeaponPoSToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 2;
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.HolsterLeft_PoS;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.HolsterLeft_Bone;
                    break;
                case "HolsterRight":
                    if (WeaponPoSToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 2;
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.HolsterRight_PoS;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.HolsterRight_Bone;
                    break;
                case "KneeLeft":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.KneeLeft_Size;
                    }
                    else
                    {
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.KneeLeft_Bone;
                        PoseMatrixViewModel.PoseVM.BNode = PoseMatrixViewModel.PoseVM.bone_knee_l;
                    }
                    break;
                case "KneeRight":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.KneeRight_Size;
                    }
                    else
                    {
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.KneeRight_Bone;
                        PoseMatrixViewModel.PoseVM.BNode = PoseMatrixViewModel.PoseVM.bone_knee_r;
                    }
                    break;
                case "CalfLeft":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.CalfLeft_Size;
                    }
                    else
                    {
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.CalfLeft_Bone;
                        PoseMatrixViewModel.PoseVM.BNode = PoseMatrixViewModel.PoseVM.bone_calf_l;
                    }
                    break;
                case "CalfRight":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.CalfRight_Size;
                    }
                    else
                    {
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.CalfRight_Bone;
                        PoseMatrixViewModel.PoseVM.BNode = PoseMatrixViewModel.PoseVM.bone_calf_r;
                    }
                    break;
                case "ToesLeft":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ToesLeft_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ToesLeft_Bone;
                    break;
                case "ToesRight":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ToesRight_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ToesRight_Bone;
                    break;
                #endregion

                #region Equipment
                case "ExMetA":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ExMetA_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ExMetA_Bone;
                    break;
                case "ExMetB":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ExMetB_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ExMetB_Bone;
                    break;
                case "ExMetC":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ExMetC_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ExMetC_Bone;
                    break;
                case "ExMetD":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ExMetD_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ExMetD_Bone;
                    break;
                case "ExMetE":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ExMetE_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ExMetE_Bone;
                    break;
                case "ExMetF":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ExMetF_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ExMetF_Bone;
                    break;
                case "ExMetG":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ExMetG_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ExMetG_Bone;
                    break;
                case "ExMetH":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ExMetH_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ExMetH_Bone;
                    break;
                case "ExMetI":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ExMetI_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ExMetI_Bone;
                    break;
                case "ExMetJ":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ExMetJ_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ExMetJ_Bone;
                    break;
                case "ExMetK":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ExMetK_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ExMetK_Bone;
                    break;
                case "ExMetL":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ExMetL_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ExMetL_Bone;
                    break;
                case "ExMetM":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ExMetM_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ExMetM_Bone;
                    break;
                case "ExMetN":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ExMetN_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ExMetN_Bone;
                    break;
                case "ExMetO":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ExMetO_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ExMetO_Bone;
                    break;
                case "ExMetP":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ExMetP_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ExMetP_Bone;
                    break;
                case "ExMetQ":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ExMetQ_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ExMetQ_Bone;
                    break;
                case "ExMetR":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ExMetR_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ExMetR_Bone;
                    break;
                case "ExTopA":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ExTopA_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ExTopA_Bone;
                    break;
                case "ExTopB":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ExTopB_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ExTopB_Bone;
                    break;
                case "ExTopC":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ExTopC_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ExTopC_Bone;
                    break;
                case "ExTopD":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ExTopD_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ExTopD_Bone;
                    break;
                case "ExTopE":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ExTopE_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ExTopE_Bone;
                    break;
                case "ExTopF":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ExTopF_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ExTopF_Bone;
                    break;
                case "ExTopG":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ExTopG_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ExTopG_Bone;
                    break;
                case "ExTopH":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ExTopH_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ExTopH_Bone;
                    break;
                case "ExTopI":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ExTopI_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.ExTopI_Bone;
                    break;
                #endregion

                #region Other
                case "Root":
                    PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.Root_Bone;
                    break;

                case "Abdomen":
                    PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.Abdomen_Bone;
                    break;

                case "Throw":
                    PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.Throw_Bone;
                    break;

                case "RootHead":
                    PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.RootHead_Bone;
                    break;

                case "Unknown00":
                    PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.Unknown00_Bone;
                    break;

                case "Weapon01":
                    //    PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.w;
                    break;
                case "Weapon02":
                    //    PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.w;
                    break;
                case "Weapon03":
                    //    PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.w;
                    break;
                case "Weapon04":
                    //    PoseMatrixViewModel.PoseVM.PointerPath = Settings.Instance.Bones.w;
                    break;
                #endregion

                default:
                    PoseMatrixViewModel.PoseVM.TheButton = null;
                    PoseMatrixViewModel.PoseVM.PointerPath = null;
                    PoseMatrixViewModel.PoseVM.BNode = null;
                    PoseMatrixViewModel.PoseVM.PointerType = 0;
                    Cube.IsEnabled = false;
                    break;

            }
        }
        private void SwapToggles(ToggleButton newActive)
        {
            PoseMatrixViewModel.PoseVM.oldrot = new Vector3D(0, 0, 0);
            PoseMatrixViewModel.PoseVM.newrot = new Vector3D(0, 0, 0);
            PoseMatrixViewModel.PoseVM.PointerPath = null;
            PoseMatrixViewModel.PoseVM.PointerType = 0;
            BoneSliderX.IsEnabled = true;
            BoneSliderY.IsEnabled = true;
            BoneSliderZ.IsEnabled = true;
            XUpDown.Minimum = 0;
            XUpDown.Maximum = 360;
            YUpDown.Maximum = 360;
            YUpDown.Minimum = 0;
            ZUpDown.Maximum = 360;
            ZUpDown.Minimum = 0;
            BoneSliderX.Maximum = 360;
            BoneSliderX.Minimum = 0;
            BoneSliderY.Maximum = 360;
            BoneSliderY.Minimum = 0;
            BoneSliderZ.Maximum = 360;
            BoneSliderZ.Minimum = 0;
            #region ToggleButton Ischecked
            Root.IsChecked = (newActive == Root) ? true : false;
            Abdomen.IsChecked = (newActive == Abdomen) ? true : false;
            Throw.IsChecked = (newActive == Throw) ? true : false;
            Waist.IsChecked = (newActive == Waist) ? true : false;
            SpineA.IsChecked = (newActive == SpineA) ? true : false;
            LegLeft.IsChecked = (newActive == LegLeft) ? true : false;
            LegRight.IsChecked = (newActive == LegRight) ? true : false;
            HolsterLeft.IsChecked = (newActive == HolsterLeft) ? true : false;
            HolsterRight.IsChecked = (newActive == HolsterRight) ? true : false;
            SheatheLeft.IsChecked = (newActive == SheatheLeft) ? true : false;
            SheatheRight.IsChecked = (newActive == SheatheRight) ? true : false;
            SpineB.IsChecked = (newActive == SpineB) ? true : false;
            ClothBackALeft.IsChecked = (newActive == ClothBackALeft) ? true : false;
            ClothBackARight.IsChecked = (newActive == ClothBackARight) ? true : false;
            ClothFrontALeft.IsChecked = (newActive == ClothFrontALeft) ? true : false;
            ClothFrontARight.IsChecked = (newActive == ClothFrontARight) ? true : false;
            ClothSideALeft.IsChecked = (newActive == ClothSideALeft) ? true : false;
            ClothSideARight.IsChecked = (newActive == ClothSideARight) ? true : false;
            KneeLeft.IsChecked = (newActive == KneeLeft) ? true : false;
            KneeRight.IsChecked = (newActive == KneeRight) ? true : false;
            BreastLeft.IsChecked = (newActive == BreastLeft) ? true : false;
            BreastRight.IsChecked = (newActive == BreastRight) ? true : false;
            SpineC.IsChecked = (newActive == SpineC) ? true : false;
            ClothBackBLeft.IsChecked = (newActive == ClothBackBLeft) ? true : false;
            ClothBackBRight.IsChecked = (newActive == ClothBackBRight) ? true : false;
            ClothFrontBLeft.IsChecked = (newActive == ClothFrontBLeft) ? true : false;
            ClothFrontBRight.IsChecked = (newActive == ClothFrontBRight) ? true : false;
            ClothSideBLeft.IsChecked = (newActive == ClothSideBLeft) ? true : false;
            ClothSideBRight.IsChecked = (newActive == ClothSideBRight) ? true : false;
            CalfLeft.IsChecked = (newActive == CalfLeft) ? true : false;
            CalfRight.IsChecked = (newActive == CalfRight) ? true : false;
            ScabbardLeft.IsChecked = (newActive == ScabbardLeft) ? true : false;
            ScabbardRight.IsChecked = (newActive == ScabbardRight) ? true : false;
            Neck.IsChecked = (newActive == Neck) ? true : false;
            ClavicleLeft.IsChecked = (newActive == ClavicleLeft) ? true : false;
            ClavicleRight.IsChecked = (newActive == ClavicleRight) ? true : false;
            ClothBackCLeft.IsChecked = (newActive == ClothBackCLeft) ? true : false;
            ClothBackCRight.IsChecked = (newActive == ClothBackCRight) ? true : false;
            ClothFrontCLeft.IsChecked = (newActive == ClothFrontCLeft) ? true : false;
            ClothFrontCRight.IsChecked = (newActive == ClothFrontCRight) ? true : false;
            ClothSideCLeft.IsChecked = (newActive == ClothSideCLeft) ? true : false;
            ClothSideCRight.IsChecked = (newActive == ClothSideCRight) ? true : false;
            PoleynLeft.IsChecked = (newActive == PoleynLeft) ? true : false;
            PoleynRight.IsChecked = (newActive == PoleynRight) ? true : false;
            FootLeft.IsChecked = (newActive == FootLeft) ? true : false;
            FootRight.IsChecked = (newActive == FootRight) ? true : false;
            Head.IsChecked = (newActive == Head) ? true : false;
            ArmLeft.IsChecked = (newActive == ArmLeft) ? true : false;
            ArmRight.IsChecked = (newActive == ArmRight) ? true : false;
            PauldronLeft.IsChecked = (newActive == PauldronLeft) ? true : false;
            PauldronRight.IsChecked = (newActive == PauldronRight) ? true : false;
            Unknown00.IsChecked = (newActive == Unknown00) ? true : false;
            ToesLeft.IsChecked = (newActive == ToesLeft) ? true : false;
            ToesRight.IsChecked = (newActive == ToesRight) ? true : false;
            HairA.IsChecked = (newActive == HairA) ? true : false;
            HairFrontLeft.IsChecked = (newActive == HairFrontLeft) ? true : false;
            HairFrontRight.IsChecked = (newActive == HairFrontRight) ? true : false;
            EarLeft.IsChecked = (newActive == EarLeft) ? true : false;
            EarRight.IsChecked = (newActive == EarRight) ? true : false;
            ForearmLeft.IsChecked = (newActive == ForearmLeft) ? true : false;
            ForearmRight.IsChecked = (newActive == ForearmRight) ? true : false;
            ShoulderLeft.IsChecked = (newActive == ShoulderLeft) ? true : false;
            ShoulderRight.IsChecked = (newActive == ShoulderRight) ? true : false;
            HairB.IsChecked = (newActive == HairB) ? true : false;
            HandLeft.IsChecked = (newActive == HandLeft) ? true : false;
            HandRight.IsChecked = (newActive == HandRight) ? true : false;
            ShieldLeft.IsChecked = (newActive == ShieldLeft) ? true : false;
            ShieldRight.IsChecked = (newActive == ShieldRight) ? true : false;
            EarringALeft.IsChecked = (newActive == EarringALeft) ? true : false;
            EarringARight.IsChecked = (newActive == EarringARight) ? true : false;
            ElbowLeft.IsChecked = (newActive == ElbowLeft) ? true : false;
            ElbowRight.IsChecked = (newActive == ElbowRight) ? true : false;
            CouterLeft.IsChecked = (newActive == CouterLeft) ? true : false;
            CouterRight.IsChecked = (newActive == CouterRight) ? true : false;
            WristLeft.IsChecked = (newActive == WristLeft) ? true : false;
            WristRight.IsChecked = (newActive == WristRight) ? true : false;
            IndexALeft.IsChecked = (newActive == IndexALeft) ? true : false;
            IndexARight.IsChecked = (newActive == IndexARight) ? true : false;
            PinkyALeft.IsChecked = (newActive == PinkyALeft) ? true : false;
            PinkyARight.IsChecked = (newActive == PinkyARight) ? true : false;
            RingALeft.IsChecked = (newActive == RingALeft) ? true : false;
            RingARight.IsChecked = (newActive == RingARight) ? true : false;
            MiddleALeft.IsChecked = (newActive == MiddleALeft) ? true : false;
            MiddleARight.IsChecked = (newActive == MiddleARight) ? true : false;
            ThumbALeft.IsChecked = (newActive == ThumbALeft) ? true : false;
            ThumbARight.IsChecked = (newActive == ThumbARight) ? true : false;
            WeaponLeft.IsChecked = (newActive == WeaponLeft) ? true : false;
            WeaponRight.IsChecked = (newActive == WeaponRight) ? true : false;
            EarringBLeft.IsChecked = (newActive == EarringBLeft) ? true : false;
            EarringBRight.IsChecked = (newActive == EarringBRight) ? true : false;
            IndexBLeft.IsChecked = (newActive == IndexBLeft) ? true : false;
            IndexBRight.IsChecked = (newActive == IndexBRight) ? true : false;
            PinkyBLeft.IsChecked = (newActive == PinkyBLeft) ? true : false;
            PinkyBRight.IsChecked = (newActive == PinkyBRight) ? true : false;
            RingBLeft.IsChecked = (newActive == RingBLeft) ? true : false;
            RingBRight.IsChecked = (newActive == RingBRight) ? true : false;
            MiddleBLeft.IsChecked = (newActive == MiddleBLeft) ? true : false;
            MiddleBRight.IsChecked = (newActive == MiddleBRight) ? true : false;
            ThumbBLeft.IsChecked = (newActive == ThumbBLeft) ? true : false;
            ThumbBRight.IsChecked = (newActive == ThumbBRight) ? true : false;
            TailA.IsChecked = (newActive == TailA) ? true : false;
            TailB.IsChecked = (newActive == TailB) ? true : false;
            TailC.IsChecked = (newActive == TailC) ? true : false;
            TailD.IsChecked = (newActive == TailD) ? true : false;
            TailE.IsChecked = (newActive == TailE) ? true : false;
            RootHead.IsChecked = (newActive == RootHead) ? true : false;
            Jaw.IsChecked = (newActive == Jaw) ? true : false;
            EyelidLowerLeft.IsChecked = (newActive == EyelidLowerLeft) ? true : false;
            EyelidLowerRight.IsChecked = (newActive == EyelidLowerRight) ? true : false;
            EyeLeft.IsChecked = (newActive == EyeLeft) ? true : false;
            EyeRight.IsChecked = (newActive == EyeRight) ? true : false;
            Nose.IsChecked = (newActive == Nose) ? true : false;
            CheekLeft.IsChecked = (newActive == CheekLeft) ? true : false;
            CheekRight.IsChecked = (newActive == CheekRight) ? true : false;

            LipsLeft.IsChecked = (newActive == LipsLeft) ? true : false;
            LipsRight.IsChecked = (newActive == LipsRight) ? true : false;
            EyebrowLeft.IsChecked = (newActive == EyebrowLeft) ? true : false;
            EyebrowRight.IsChecked = (newActive == EyebrowRight) ? true : false;
            Bridge.IsChecked = (newActive == Bridge) ? true : false;
            BrowLeft.IsChecked = (newActive == BrowLeft) ? true : false;
            BrowRight.IsChecked = (newActive == BrowRight) ? true : false;
            LipUpperA.IsChecked = (newActive == LipUpperA) ? true : false;
            EyelidUpperLeft.IsChecked = (newActive == EyelidUpperLeft) ? true : false;
            EyelidUpperRight.IsChecked = (newActive == EyelidUpperRight) ? true : false;
            LipLowerA.IsChecked = (newActive == LipLowerA) ? true : false;
            LipUpperB.IsChecked = (newActive == LipUpperB) ? true : false;
            LipLowerB.IsChecked = (newActive == LipLowerB) ? true : false;
            HrothWhiskersLeft.IsChecked = (newActive == HrothWhiskersLeft) ? true : false;
            HrothWhiskersRight.IsChecked = (newActive == HrothWhiskersRight) ? true : false;
            VieraEarALeft.IsChecked = (newActive == VieraEarALeft) ? true : false;
            VieraEarARight.IsChecked = (newActive == VieraEarARight) ? true : false;
            VieraEarBLeft.IsChecked = (newActive == VieraEarBLeft) ? true : false;
            VieraEarBRight.IsChecked = (newActive == VieraEarBRight) ? true : false;
            ExHairA.IsChecked = (newActive == ExHairA) ? true : false;
            ExHairB.IsChecked = (newActive == ExHairB) ? true : false;
            ExHairC.IsChecked = (newActive == ExHairC) ? true : false;
            ExHairD.IsChecked = (newActive == ExHairD) ? true : false;
            ExHairE.IsChecked = (newActive == ExHairE) ? true : false;
            ExHairF.IsChecked = (newActive == ExHairF) ? true : false;
            ExHairG.IsChecked = (newActive == ExHairG) ? true : false;
            ExHairH.IsChecked = (newActive == ExHairH) ? true : false;
            ExHairI.IsChecked = (newActive == ExHairI) ? true : false;
            ExHairJ.IsChecked = (newActive == ExHairJ) ? true : false;
            ExHairK.IsChecked = (newActive == ExHairK) ? true : false;
            ExHairL.IsChecked = (newActive == ExHairL) ? true : false;
            ExMetA.IsChecked = (newActive == ExMetA) ? true : false;
            ExMetB.IsChecked = (newActive == ExMetB) ? true : false;
            ExMetC.IsChecked = (newActive == ExMetC) ? true : false;
            ExMetD.IsChecked = (newActive == ExMetD) ? true : false;
            ExMetE.IsChecked = (newActive == ExMetE) ? true : false;
            ExMetF.IsChecked = (newActive == ExMetF) ? true : false;
            ExMetG.IsChecked = (newActive == ExMetG) ? true : false;
            ExMetH.IsChecked = (newActive == ExMetH) ? true : false;
            ExMetI.IsChecked = (newActive == ExMetI) ? true : false;
            ExMetJ.IsChecked = (newActive == ExMetJ) ? true : false;
            ExMetK.IsChecked = (newActive == ExMetK) ? true : false;
            ExMetL.IsChecked = (newActive == ExMetL) ? true : false;
            ExMetM.IsChecked = (newActive == ExMetM) ? true : false;
            ExMetN.IsChecked = (newActive == ExMetN) ? true : false;
            ExMetO.IsChecked = (newActive == ExMetO) ? true : false;
            ExMetP.IsChecked = (newActive == ExMetP) ? true : false;
            ExMetQ.IsChecked = (newActive == ExMetQ) ? true : false;
            ExMetR.IsChecked = (newActive == ExMetR) ? true : false;
            ExTopA.IsChecked = (newActive == ExTopA) ? true : false;
            ExTopB.IsChecked = (newActive == ExTopB) ? true : false;
            ExTopC.IsChecked = (newActive == ExTopC) ? true : false;
            ExTopD.IsChecked = (newActive == ExTopD) ? true : false;
            ExTopE.IsChecked = (newActive == ExTopE) ? true : false;
            ExTopF.IsChecked = (newActive == ExTopF) ? true : false;
            ExTopG.IsChecked = (newActive == ExTopG) ? true : false;
            ExTopH.IsChecked = (newActive == ExTopH) ? true : false;
            ExTopI.IsChecked = (newActive == ExTopI) ? true : false;
            #endregion
        }

        public void UncheckAll()
        {
            PoseMatrixViewModel.PoseVM.oldrot = new Vector3D(0, 0, 0);
            PoseMatrixViewModel.PoseVM.newrot = new Vector3D(0, 0, 0);
            PoseMatrixViewModel.PoseVM.PointerPath = null;
            PoseMatrixViewModel.PoseVM.PointerType = 0;
            PoseMatrixViewModel.PoseVM.BoneX = 0;
            PoseMatrixViewModel.PoseVM.BoneY = 0;
            PoseMatrixViewModel.PoseVM.BoneZ = 0;
            XUpDown.Minimum = 0;
            XUpDown.Maximum = 360;
            YUpDown.Maximum = 360;
            YUpDown.Minimum = 0;
            ZUpDown.Maximum = 360;
            ZUpDown.Minimum = 0;
            BoneSliderX.Maximum = 360;
            BoneSliderX.Minimum = 0;
            BoneSliderY.Maximum = 360;
            BoneSliderY.Minimum = 0;
            BoneSliderZ.Maximum = 360;
            BoneSliderZ.Minimum = 0;
            #region IsChecked = false
            Root.IsChecked = false;
            Abdomen.IsChecked = false;
            Throw.IsChecked = false;
            Waist.IsChecked = false;
            SpineA.IsChecked = false;
            LegLeft.IsChecked = false;
            LegRight.IsChecked = false;
            HolsterLeft.IsChecked = false;
            HolsterRight.IsChecked = false;
            SheatheLeft.IsChecked = false;
            SheatheRight.IsChecked = false;
            SpineB.IsChecked = false;
            ClothBackALeft.IsChecked = false;
            ClothBackARight.IsChecked = false;
            ClothFrontALeft.IsChecked = false;
            ClothFrontARight.IsChecked = false;
            ClothSideALeft.IsChecked = false;
            ClothSideARight.IsChecked = false;
            KneeLeft.IsChecked = false;
            KneeRight.IsChecked = false;
            BreastLeft.IsChecked = false;
            BreastRight.IsChecked = false;
            SpineC.IsChecked = false;
            ClothBackBLeft.IsChecked = false;
            ClothBackBRight.IsChecked = false;
            ClothFrontBLeft.IsChecked = false;
            ClothFrontBRight.IsChecked = false;
            ClothSideBLeft.IsChecked = false;
            ClothSideBRight.IsChecked = false;
            CalfLeft.IsChecked = false;
            CalfRight.IsChecked = false;
            ScabbardLeft.IsChecked = false;
            ScabbardRight.IsChecked = false;
            Neck.IsChecked = false;
            ClavicleLeft.IsChecked = false;
            ClavicleRight.IsChecked = false;
            ClothBackCLeft.IsChecked = false;
            ClothBackCRight.IsChecked = false;
            ClothFrontCLeft.IsChecked = false;
            ClothFrontCRight.IsChecked = false;
            ClothSideCLeft.IsChecked = false;
            ClothSideCRight.IsChecked = false;
            PoleynLeft.IsChecked = false;
            PoleynRight.IsChecked = false;
            FootLeft.IsChecked = false;
            FootRight.IsChecked = false;
            Head.IsChecked = false;
            ArmLeft.IsChecked = false;
            ArmRight.IsChecked = false;
            PauldronLeft.IsChecked = false;
            PauldronRight.IsChecked = false;
            Unknown00.IsChecked = false;
            ToesLeft.IsChecked = false;
            ToesRight.IsChecked = false;
            HairA.IsChecked = false;
            HairFrontLeft.IsChecked = false;
            HairFrontRight.IsChecked = false;
            EarLeft.IsChecked = false;
            EarRight.IsChecked = false;
            ForearmLeft.IsChecked = false;
            ForearmRight.IsChecked = false;
            ShoulderLeft.IsChecked = false;
            ShoulderRight.IsChecked = false;
            HairB.IsChecked = false;
            HandLeft.IsChecked = false;
            HandRight.IsChecked = false;
            ShieldLeft.IsChecked = false;
            ShieldRight.IsChecked = false;
            EarringALeft.IsChecked = false;
            EarringARight.IsChecked = false;
            ElbowLeft.IsChecked = false;
            ElbowRight.IsChecked = false;
            CouterLeft.IsChecked = false;
            CouterRight.IsChecked = false;
            WristLeft.IsChecked = false;
            WristRight.IsChecked = false;
            IndexALeft.IsChecked = false;
            IndexARight.IsChecked = false;
            PinkyALeft.IsChecked = false;
            PinkyARight.IsChecked = false;
            RingALeft.IsChecked = false;
            RingARight.IsChecked = false;
            MiddleALeft.IsChecked = false;
            MiddleARight.IsChecked = false;
            ThumbALeft.IsChecked = false;
            ThumbARight.IsChecked = false;
            WeaponLeft.IsChecked = false;
            WeaponRight.IsChecked = false;
            EarringBLeft.IsChecked = false;
            EarringBRight.IsChecked = false;
            IndexBLeft.IsChecked = false;
            IndexBRight.IsChecked = false;
            PinkyBLeft.IsChecked = false;
            PinkyBRight.IsChecked = false;
            RingBLeft.IsChecked = false;
            RingBRight.IsChecked = false;
            MiddleBLeft.IsChecked = false;
            MiddleBRight.IsChecked = false;
            ThumbBLeft.IsChecked = false;
            ThumbBRight.IsChecked = false;
            TailA.IsChecked = false;
            TailB.IsChecked = false;
            TailC.IsChecked = false;
            TailD.IsChecked = false;
            TailE.IsChecked = false;
            RootHead.IsChecked = false;
            Jaw.IsChecked = false;
            EyelidLowerLeft.IsChecked = false;
            EyelidLowerRight.IsChecked = false;
            EyeLeft.IsChecked = false;
            EyeRight.IsChecked = false;
            Nose.IsChecked = false;
            CheekLeft.IsChecked = false;
            HrothWhiskersLeft.IsChecked = false;
            CheekRight.IsChecked = false;
            HrothWhiskersRight.IsChecked = false;
            LipsLeft.IsChecked = false;
            LipsRight.IsChecked = false;
            EyebrowLeft.IsChecked = false;
            EyebrowRight.IsChecked = false;
            Bridge.IsChecked = false;
            BrowLeft.IsChecked = false;
            BrowRight.IsChecked = false;
            LipUpperA.IsChecked = false;
            EyelidUpperLeft.IsChecked = false;
            EyelidUpperRight.IsChecked = false;
            LipLowerA.IsChecked = false;
            LipUpperB.IsChecked = false;
            LipLowerB.IsChecked = false;
            HrothWhiskersLeft.IsChecked = false;
            HrothWhiskersRight.IsChecked = false;
            VieraEarALeft.IsChecked = false;
            VieraEarARight.IsChecked = false;
            VieraEarBLeft.IsChecked = false;
            VieraEarBRight.IsChecked = false;
            ExHairA.IsChecked = false;
            ExHairB.IsChecked = false;
            ExHairC.IsChecked = false;
            ExHairD.IsChecked = false;
            ExHairE.IsChecked = false;
            ExHairF.IsChecked = false;
            ExHairG.IsChecked = false;
            ExHairH.IsChecked = false;
            ExHairI.IsChecked = false;
            ExHairJ.IsChecked = false;
            ExHairK.IsChecked = false;
            ExHairL.IsChecked = false;
            ExMetA.IsChecked = false;
            ExMetB.IsChecked = false;
            ExMetC.IsChecked = false;
            ExMetD.IsChecked = false;
            ExMetE.IsChecked = false;
            ExMetF.IsChecked = false;
            ExMetG.IsChecked = false;
            ExMetH.IsChecked = false;
            ExMetI.IsChecked = false;
            ExMetJ.IsChecked = false;
            ExMetK.IsChecked = false;
            ExMetL.IsChecked = false;
            ExMetM.IsChecked = false;
            ExMetN.IsChecked = false;
            ExMetO.IsChecked = false;
            ExMetP.IsChecked = false;
            ExMetQ.IsChecked = false;
            ExMetR.IsChecked = false;
            ExTopA.IsChecked = false;
            ExTopB.IsChecked = false;
            ExTopC.IsChecked = false;
            ExTopD.IsChecked = false;
            ExTopE.IsChecked = false;
            ExTopF.IsChecked = false;
            ExTopG.IsChecked = false;
            ExTopH.IsChecked = false;
            ExTopI.IsChecked = false;
            #endregion
        }
        private void EnableAll()
        {
            #region Enable Controls
            PhysicsButton.IsEnabled = true;
            ScaleEdit.IsEnabled = true;
            HelmToggle.IsEnabled = true;
            WeaponPoSToggle.IsEnabled = true;
            //       ScaleToggle.IsEnabled = true;
            // TertiaryButton.IsEnabled = true;
            //Root.IsEnabled = true;
            //Abdomen.IsEnabled = true;
            //Throw.IsEnabled = true;
            Waist.IsEnabled = true;
            SpineA.IsEnabled = true;
            LegLeft.IsEnabled = true;
            LegRight.IsEnabled = true;
            HolsterLeft.IsEnabled = true;
            HolsterRight.IsEnabled = true;
            SheatheLeft.IsEnabled = true;
            SheatheRight.IsEnabled = true;
            SpineB.IsEnabled = true;
            ClothBackALeft.IsEnabled = true;
            ClothBackARight.IsEnabled = true;
            ClothFrontALeft.IsEnabled = true;
            ClothFrontARight.IsEnabled = true;
            ClothSideALeft.IsEnabled = true;
            ClothSideARight.IsEnabled = true;
            KneeLeft.IsEnabled = true;
            KneeRight.IsEnabled = true;
            BreastLeft.IsEnabled = true;
            BreastRight.IsEnabled = true;
            SpineC.IsEnabled = true;
            ClothBackBLeft.IsEnabled = true;
            ClothBackBRight.IsEnabled = true;
            ClothFrontBLeft.IsEnabled = true;
            ClothFrontBRight.IsEnabled = true;
            ClothSideBLeft.IsEnabled = true;
            ClothSideBRight.IsEnabled = true;
            CalfLeft.IsEnabled = true;
            CalfRight.IsEnabled = true;
            ScabbardLeft.IsEnabled = true;
            ScabbardRight.IsEnabled = true;
            Neck.IsEnabled = true;
            ClavicleLeft.IsEnabled = true;
            ClavicleRight.IsEnabled = true;
            ClothBackCLeft.IsEnabled = true;
            ClothBackCRight.IsEnabled = true;
            ClothFrontCLeft.IsEnabled = true;
            ClothFrontCRight.IsEnabled = true;
            ClothSideCLeft.IsEnabled = true;
            ClothSideCRight.IsEnabled = true;
            PoleynLeft.IsEnabled = true;
            PoleynRight.IsEnabled = true;
            FootLeft.IsEnabled = true;
            FootRight.IsEnabled = true;
            Head.IsEnabled = true;
            ArmLeft.IsEnabled = true;
            ArmRight.IsEnabled = true;
            PauldronLeft.IsEnabled = true;
            PauldronRight.IsEnabled = true;
            Unknown00.IsEnabled = true;
            ToesLeft.IsEnabled = true;
            ToesRight.IsEnabled = true;
            HairA.IsEnabled = true;
            HairFrontLeft.IsEnabled = true;
            HairFrontRight.IsEnabled = true;
            EarLeft.IsEnabled = true;
            EarRight.IsEnabled = true;
            ForearmLeft.IsEnabled = true;
            ForearmRight.IsEnabled = true;
            ShoulderLeft.IsEnabled = true;
            ShoulderRight.IsEnabled = true;
            HairB.IsEnabled = true;
            HandLeft.IsEnabled = true;
            HandRight.IsEnabled = true;
            ShieldLeft.IsEnabled = true;
            ShieldRight.IsEnabled = true;
            EarringALeft.IsEnabled = true;
            EarringARight.IsEnabled = true;
            ElbowLeft.IsEnabled = true;
            ElbowRight.IsEnabled = true;
            CouterLeft.IsEnabled = true;
            CouterRight.IsEnabled = true;
            WristLeft.IsEnabled = true;
            WristRight.IsEnabled = true;
            IndexALeft.IsEnabled = true;
            IndexARight.IsEnabled = true;
            PinkyALeft.IsEnabled = true;
            PinkyARight.IsEnabled = true;
            RingALeft.IsEnabled = true;
            RingARight.IsEnabled = true;
            MiddleALeft.IsEnabled = true;
            MiddleARight.IsEnabled = true;
            ThumbALeft.IsEnabled = true;
            ThumbARight.IsEnabled = true;
            WeaponLeft.IsEnabled = true;
            WeaponRight.IsEnabled = true;
            EarringBLeft.IsEnabled = true;
            EarringBRight.IsEnabled = true;
            IndexBLeft.IsEnabled = true;
            IndexBRight.IsEnabled = true;
            PinkyBLeft.IsEnabled = true;
            PinkyBRight.IsEnabled = true;
            RingBLeft.IsEnabled = true;
            RingBRight.IsEnabled = true;
            MiddleBLeft.IsEnabled = true;
            MiddleBRight.IsEnabled = true;
            ThumbBLeft.IsEnabled = true;
            ThumbBRight.IsEnabled = true;
            //TailA.IsEnabled = true;
            //TailB.IsEnabled = true;
            //TailC.IsEnabled = true;
            //TailD.IsEnabled = true;
            //TailE.IsEnabled = true;
            //RootHead.IsEnabled = true;
            Jaw.IsEnabled = true;
            EyelidLowerLeft.IsEnabled = true;
            EyelidLowerRight.IsEnabled = true;
            EyeLeft.IsEnabled = true;
            EyeRight.IsEnabled = true;
            Nose.IsEnabled = true;
            CheekLeft.IsEnabled = true;
            CheekRight.IsEnabled = true;
            LipsLeft.IsEnabled = true;
            LipsRight.IsEnabled = true;
            EyebrowLeft.IsEnabled = true;
            EyebrowRight.IsEnabled = true;
            Bridge.IsEnabled = true;
            BrowLeft.IsEnabled = true;
            BrowRight.IsEnabled = true;
            LipUpperA.IsEnabled = true;
            EyelidUpperLeft.IsEnabled = true;
            EyelidUpperRight.IsEnabled = true;
            LipLowerA.IsEnabled = true;
            LipUpperB.IsEnabled = true;
            LipLowerB.IsEnabled = true;
            //HrothWhiskersLeft.IsEnabled = true;
            //HrothWhiskersRight.IsEnabled = true;
            //VieraEarALeft.IsEnabled = true;
            //VieraEarARight.IsEnabled = true;
            //VieraEarBLeft.IsEnabled = true;
            //VieraEarBRight.IsEnabled = true;
            //ExHairA.IsEnabled = true;
            //ExHairB.IsEnabled = true;
            //ExHairC.IsEnabled = true;
            //ExHairD.IsEnabled = true;
            //ExHairE.IsEnabled = true;
            //ExHairF.IsEnabled = true;
            //ExHairG.IsEnabled = true;
            //ExHairH.IsEnabled = true;
            //ExHairI.IsEnabled = true;
            //ExHairJ.IsEnabled = true;
            //ExHairK.IsEnabled = true;
            //ExHairL.IsEnabled = true;
            //ExMetA.IsEnabled = true;
            //ExMetB.IsEnabled = true;
            //ExMetC.IsEnabled = true;
            //ExMetD.IsEnabled = true;
            //ExMetE.IsEnabled = true;
            //ExMetF.IsEnabled = true;
            //ExMetG.IsEnabled = true;
            //ExMetH.IsEnabled = true;
            //ExMetI.IsEnabled = true;
            //ExMetJ.IsEnabled = true;
            //ExMetK.IsEnabled = true;
            //ExMetL.IsEnabled = true;
            //ExMetM.IsEnabled = true;
            //ExMetN.IsEnabled = true;
            //ExMetO.IsEnabled = true;
            //ExMetP.IsEnabled = true;
            //ExMetQ.IsEnabled = true;
            //ExMetR.IsEnabled = true;
            //ExTopA.IsEnabled = true;
            //ExTopB.IsEnabled = true;
            //ExTopC.IsEnabled = true;
            //ExTopD.IsEnabled = true;
            //ExTopE.IsEnabled = true;
            //ExTopF.IsEnabled = true;
            //ExTopG.IsEnabled = true;
            //ExTopH.IsEnabled = true;
            //ExTopI.IsEnabled = true;

            //if (HeadSaved) LoadHeadButton.IsEnabled = true;
            //if (TorsoSaved) LoadTorsoButton.IsEnabled = true;
            //if (LeftArmSaved) LoadLArmButton.IsEnabled = true;
            //if (RightArmSaved) LoadRArmButton.IsEnabled = true;
            //if (LeftLegSaved) LoadLLegButton.IsEnabled = true;
            //if (RightLegSaved) LoadRLegButton.IsEnabled = true;
            #endregion
        }

        private void DisableAll()
        {
            #region Disable Controls
            WeaponPoSToggle.IsEnabled = false;
            PhysicsButton.IsEnabled = false;
            ScaleToggle.IsEnabled = false;
            ScaleEdit.IsEnabled = false;
            // TertiaryButton.IsEnabled = false;
            Root.IsEnabled = false;
            Abdomen.IsEnabled = false;
            Throw.IsEnabled = false;
            Waist.IsEnabled = false;
            SpineA.IsEnabled = false;
            LegLeft.IsEnabled = false;
            LegRight.IsEnabled = false;
            HolsterLeft.IsEnabled = false;
            HolsterRight.IsEnabled = false;
            SheatheLeft.IsEnabled = false;
            SheatheRight.IsEnabled = false;
            SpineB.IsEnabled = false;
            ClothBackALeft.IsEnabled = false;
            ClothBackARight.IsEnabled = false;
            ClothFrontALeft.IsEnabled = false;
            ClothFrontARight.IsEnabled = false;
            ClothSideALeft.IsEnabled = false;
            ClothSideARight.IsEnabled = false;
            KneeLeft.IsEnabled = false;
            KneeRight.IsEnabled = false;
            BreastLeft.IsEnabled = false;
            BreastRight.IsEnabled = false;
            SpineC.IsEnabled = false;
            ClothBackBLeft.IsEnabled = false;
            ClothBackBRight.IsEnabled = false;
            ClothFrontBLeft.IsEnabled = false;
            ClothFrontBRight.IsEnabled = false;
            ClothSideBLeft.IsEnabled = false;
            ClothSideBRight.IsEnabled = false;
            CalfLeft.IsEnabled = false;
            CalfRight.IsEnabled = false;
            ScabbardLeft.IsEnabled = false;
            ScabbardRight.IsEnabled = false;
            Neck.IsEnabled = false;
            ClavicleLeft.IsEnabled = false;
            ClavicleRight.IsEnabled = false;
            ClothBackCLeft.IsEnabled = false;
            ClothBackCRight.IsEnabled = false;
            ClothFrontCLeft.IsEnabled = false;
            ClothFrontCRight.IsEnabled = false;
            ClothSideCLeft.IsEnabled = false;
            ClothSideCRight.IsEnabled = false;
            PoleynLeft.IsEnabled = false;
            PoleynRight.IsEnabled = false;
            FootLeft.IsEnabled = false;
            FootRight.IsEnabled = false;
            Head.IsEnabled = false;
            ArmLeft.IsEnabled = false;
            ArmRight.IsEnabled = false;
            PauldronLeft.IsEnabled = false;
            PauldronRight.IsEnabled = false;
            Unknown00.IsEnabled = false;
            ToesLeft.IsEnabled = false;
            ToesRight.IsEnabled = false;
            HairA.IsEnabled = false;
            HairFrontLeft.IsEnabled = false;
            HairFrontRight.IsEnabled = false;
            EarLeft.IsEnabled = false;
            EarRight.IsEnabled = false;
            ForearmLeft.IsEnabled = false;
            ForearmRight.IsEnabled = false;
            ShoulderLeft.IsEnabled = false;
            ShoulderRight.IsEnabled = false;
            HairB.IsEnabled = false;
            HandLeft.IsEnabled = false;
            HandRight.IsEnabled = false;
            ShieldLeft.IsEnabled = false;
            ShieldRight.IsEnabled = false;
            EarringALeft.IsEnabled = false;
            EarringARight.IsEnabled = false;
            ElbowLeft.IsEnabled = false;
            ElbowRight.IsEnabled = false;
            CouterLeft.IsEnabled = false;
            CouterRight.IsEnabled = false;
            WristLeft.IsEnabled = false;
            WristRight.IsEnabled = false;
            IndexALeft.IsEnabled = false;
            IndexARight.IsEnabled = false;
            PinkyALeft.IsEnabled = false;
            PinkyARight.IsEnabled = false;
            RingALeft.IsEnabled = false;
            RingARight.IsEnabled = false;
            MiddleALeft.IsEnabled = false;
            MiddleARight.IsEnabled = false;
            ThumbALeft.IsEnabled = false;
            ThumbARight.IsEnabled = false;
            WeaponLeft.IsEnabled = false;
            WeaponRight.IsEnabled = false;
            EarringBLeft.IsEnabled = false;
            EarringBRight.IsEnabled = false;
            IndexBLeft.IsEnabled = false;
            IndexBRight.IsEnabled = false;
            PinkyBLeft.IsEnabled = false;
            PinkyBRight.IsEnabled = false;
            RingBLeft.IsEnabled = false;
            RingBRight.IsEnabled = false;
            MiddleBLeft.IsEnabled = false;
            MiddleBRight.IsEnabled = false;
            ThumbBLeft.IsEnabled = false;
            ThumbBRight.IsEnabled = false;
            RootHead.IsEnabled = false;
            Jaw.IsEnabled = false;
            EyelidLowerLeft.IsEnabled = false;
            EyelidLowerRight.IsEnabled = false;
            EyeLeft.IsEnabled = false;
            EyeRight.IsEnabled = false;
            Nose.IsEnabled = false;
            CheekLeft.IsEnabled = false;
            HrothWhiskersLeft.IsEnabled = false;
            CheekRight.IsEnabled = false;
            HrothWhiskersRight.IsEnabled = false;
            LipsLeft.IsEnabled = false;
            LipsRight.IsEnabled = false;
            EyebrowLeft.IsEnabled = false;
            EyebrowRight.IsEnabled = false;
            Bridge.IsEnabled = false;
            BrowLeft.IsEnabled = false;
            BrowRight.IsEnabled = false;
            LipUpperA.IsEnabled = false;
            EyelidUpperLeft.IsEnabled = false;
            EyelidUpperRight.IsEnabled = false;
            LipLowerA.IsEnabled = false;
            LipUpperB.IsEnabled = false;
            LipLowerB.IsEnabled = false;
            DisableTertiary();

            //LoadHeadButton.IsEnabled = false;
            //LoadTorsoButton.IsEnabled = false;
            //LoadLArmButton.IsEnabled = false;
            //LoadRArmButton.IsEnabled = false;
            //LoadLLegButton.IsEnabled = false;
            //LoadRLegButton.IsEnabled = false;
            #endregion
        }
        private void SaveCMP_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.CurrentlySaving = true;
            SaveFileDialog dig = new SaveFileDialog();
            dig.InitialDirectory = SaveSettings.Default.MatrixPoseSaveLoadDirectory;
            dig.Filter = "Concept Matrix Pose File(*.cmp)|*.cmp";
            if (dig.ShowDialog() == true)
            {
                string extension = Path.GetExtension(".cmp");
                string result = dig.SafeFileName.Substring(0, dig.SafeFileName.Length - extension.Length);
                BoneSaves BoneSaver = new BoneSaves();
                BoneSaver.Description = result;
                BoneSaver.DateCreated = DateTime.Now.ToString("yyyy-MM-dd HH':'mm':'ss");
                BoneSaver.CMPVersion = "2.0";
                SaveSettings.Default.MatrixPoseSaveLoadDirectory = Path.GetDirectoryName(dig.FileName);
                var AppearanceArray = Memory.MemLib.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Race),26);
                BoneSaver.Race = AppearanceArray[0].ToString("X2");
                BoneSaver.Clan = AppearanceArray[4].ToString("X2");
                BoneSaver.Body = AppearanceArray[2].ToString("X2");
                #region Head
                BoneSaver.Head = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.Head_Bone), 16));
                BoneSaver.EarLeft = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EarLeft_Bone), 16));
                BoneSaver.EarRight = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EarRight_Bone), 16));
                BoneSaver.RootHead = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.RootHead_Bone), 16));
                BoneSaver.Jaw = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.Jaw_Bone), 16));
                BoneSaver.EyelidLowerLeft = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyelidLowerLeft_Bone), 16));
                BoneSaver.EyelidLowerRight = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyelidLowerRight_Bone), 16));
                BoneSaver.EyeLeft = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyeLeft_Bone), 16));
                BoneSaver.EyeRight = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyeRight_Bone), 16));
                BoneSaver.Nose = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.Nose_Bone), 16));
                BoneSaver.CheekLeft = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.CheekLeft_Bone), 16));
                BoneSaver.HrothWhiskersLeft = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothWhiskersLeft_Bone), 16));
                BoneSaver.CheekRight = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.CheekRight_Bone), 16));
                BoneSaver.HrothWhiskersRight = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothWhiskersRight_Bone), 16));
                BoneSaver.LipsLeft = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipsLeft_Bone), 16));
                BoneSaver.HrothEyebrowLeft = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothEyebrowLeft_Bone), 16));
                BoneSaver.LipsRight = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipsRight_Bone), 16));
                BoneSaver.HrothEyebrowRight = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothEyebrowRight_Bone), 16));
                BoneSaver.EyebrowLeft = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyebrowLeft_Bone), 16));
                BoneSaver.HrothBridge = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothBridge_Bone), 16));
                BoneSaver.EyebrowRight = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyebrowRight_Bone), 16));
                BoneSaver.HrothBrowLeft = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothBrowLeft_Bone), 16));
                BoneSaver.Bridge = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.Bridge_Bone), 16));
                BoneSaver.HrothBrowRight = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothBrowRight_Bone), 16));
                BoneSaver.BrowLeft = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.BrowLeft_Bone), 16));
                BoneSaver.HrothJawUpper = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothJawUpper_Bone), 16));
                BoneSaver.BrowRight = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.BrowRight_Bone), 16));
                BoneSaver.HrothLipUpper = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothLipUpper_Bone), 16));
                BoneSaver.LipUpperA = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipUpperA_Bone), 16));
                BoneSaver.HrothEyelidUpperLeft = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothEyelidUpperLeft_Bone), 16));
                BoneSaver.EyelidUpperLeft = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyelidUpperLeft_Bone), 16));
                BoneSaver.HrothEyelidUpperRight = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothEyelidUpperRight_Bone), 16));
                BoneSaver.EyelidUpperRight = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyelidUpperRight_Bone), 16));
                BoneSaver.HrothLipsLeft = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothLipsLeft_Bone), 16));
                BoneSaver.LipLowerA = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipLowerA_Bone), 16));
                BoneSaver.HrothLipsRight = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothLipsRight_Bone), 16));
                BoneSaver.VieraEar01ALeft = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar01ALeft_Bone), 16));
                BoneSaver.LipUpperB = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipUpperB_Bone), 16));
                BoneSaver.HrothLipUpperLeft = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothLipUpperLeft_Bone), 16));
                BoneSaver.VieraEar01ARight = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar01ARight_Bone), 16));
                BoneSaver.LipLowerB = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipLowerB_Bone), 16));
                BoneSaver.HrothLipUpperRight = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothLipUpperRight_Bone), 16));
                BoneSaver.VieraEar02ALeft = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar02ALeft_Bone), 16));
                if ( AppearanceArray[0] == 7 ||  AppearanceArray[0] == 8)
                {
                    BoneSaver.HrothLipLower = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothLipLower_Bone), 16));
                    BoneSaver.VieraEar02ARight = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar02ARight_Bone), 16));
                }
                else
                {
                    BoneSaver.HrothLipLower = "null";
                    BoneSaver.VieraEar02ARight = "null";
                }
                if ( AppearanceArray[0] == 8)
                {
                    BoneSaver.VieraEar03ALeft = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar03ALeft_Bone), 16));
                    BoneSaver.VieraEar03ARight = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar03ARight_Bone), 16));
                    BoneSaver.VieraEar04ALeft = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar04ALeft_Bone), 16));
                    BoneSaver.VieraEar04ARight = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar04ARight_Bone), 16));
                    BoneSaver.VieraLipLowerA = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraLipLowerA_Bone), 16));
                    BoneSaver.VieraLipUpperB = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraLipUpperB_Bone), 16));
                    BoneSaver.VieraEar01BLeft = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar01BLeft_Bone), 16));
                    BoneSaver.VieraEar01BRight = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar01BRight_Bone), 16));
                    BoneSaver.VieraEar02BLeft = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar02BLeft_Bone), 16));
                    BoneSaver.VieraEar02BRight = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar02BRight_Bone), 16));
                    BoneSaver.VieraEar03BLeft = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar03BLeft_Bone), 16));
                    BoneSaver.VieraEar03BRight = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar03BRight_Bone), 16));
                    BoneSaver.VieraEar04BLeft = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar04BLeft_Bone), 16));
                    BoneSaver.VieraEar04BRight = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar04BRight_Bone), 16));
                    BoneSaver.VieraLipLowerB = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraLipLowerB_Bone), 16));
                }
                else
                {
                    BoneSaver.VieraEar03ALeft = "null";
                    BoneSaver.VieraEar03ARight = "null";
                    BoneSaver.VieraEar04ALeft = "null";
                    BoneSaver.VieraEar04ARight = "null";
                    BoneSaver.VieraLipLowerA = "null";
                    BoneSaver.VieraLipUpperB = "null";
                    BoneSaver.VieraEar01BLeft = "null";
                    BoneSaver.VieraEar01BRight = "null";
                    BoneSaver.VieraEar02BLeft = "null";
                    BoneSaver.VieraEar02BRight = "null";
                    BoneSaver.VieraEar03BLeft = "null";
                    BoneSaver.VieraEar03BRight = "null";
                    BoneSaver.VieraEar04BLeft = "null";
                    BoneSaver.VieraEar04BRight = "null";
                    BoneSaver.VieraLipLowerB = "null";
                }
                #endregion
                #region Hair
                BoneSaver.HairA = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HairA_Bone), 16));
                BoneSaver.HairFrontLeft = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HairFrontLeft_Bone), 16));
                BoneSaver.HairFrontRight = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HairFrontRight_Bone), 16));
                BoneSaver.HairB = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HairB_Bone), 16));
                var HairValue = m.readByte(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExHair_Value));

                if (HairValue >= 1)
                {
                    BoneSaver.ExRootHair = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExRootHair_Bone), 16));
                }
                if (HairValue >= 2)
                {
                    BoneSaver.ExHairA = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExHairA_Bone), 16));
                }
                else
                {
                    BoneSaver.ExHairA = "null";
                }
                if (HairValue >= 3)
                {
                    BoneSaver.ExHairB = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExHairB_Bone), 16));
                }
                else
                {
                    BoneSaver.ExHairB = "null";
                }
                if (HairValue >= 4)
                {
                    BoneSaver.ExHairC = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExHairC_Bone), 16));
                }
                else
                {
                    BoneSaver.ExHairC = "null";
                }
                if (HairValue >= 5)
                {
                    BoneSaver.ExHairD = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExHairD_Bone), 16));
                }
                else
                {
                    BoneSaver.ExHairD = "null";
                }
                if (HairValue >= 6)
                {
                    BoneSaver.ExHairE = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExHairE_Bone), 16));
                }
                else
                {
                    BoneSaver.ExHairE = "null";
                }
                if (HairValue >= 7)
                {
                    BoneSaver.ExHairF = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExHairF_Bone), 16));
                }
                else
                {
                    BoneSaver.ExHairF = "null";
                }
                if (HairValue >= 8)
                {
                    BoneSaver.ExHairG = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExHairG_Bone), 16));
                }
                else
                {
                    BoneSaver.ExHairG = "null";
                }
                if (HairValue >= 9)
                {
                    BoneSaver.ExHairH = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExHairH_Bone), 16));
                }
                else
                {
                    BoneSaver.ExHairH = "null";
                }
                if (HairValue >= 10)
                {
                    BoneSaver.ExHairI = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExHairI_Bone), 16));
                }
                else
                {
                    BoneSaver.ExHairI = "null";
                }
                if (HairValue >= 11)
                {
                    BoneSaver.ExHairJ = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExHairJ_Bone), 16));
                }
                else
                {
                    BoneSaver.ExHairJ = "null";
                }
                if (HairValue >= 12)
                {
                    BoneSaver.ExHairK = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExHairK_Bone), 16));
                }
                else
                {
                    BoneSaver.ExHairK = "null";
                }
                if (HairValue >= 13)
                {
                    BoneSaver.ExHairL = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExHairL_Bone), 16));
                }
                else
                {
                    BoneSaver.ExHairL = "null";
                }
                if (BoneSaver.ExRootHair == null)
                {
                    BoneSaver.ExRootHair = "null";
                    BoneSaver.ExHairA = "null";
                    BoneSaver.ExHairB = "null";
                    BoneSaver.ExHairC = "null";
                    BoneSaver.ExHairD = "null";
                    BoneSaver.ExHairE = "null";
                    BoneSaver.ExHairF = "null";
                    BoneSaver.ExHairG = "null";
                    BoneSaver.ExHairH = "null";
                    BoneSaver.ExHairI = "null";
                    BoneSaver.ExHairJ = "null";
                    BoneSaver.ExHairK = "null";
                    BoneSaver.ExHairL = "null";
                }
                #endregion
                #region Earrings
                BoneSaver.EarringALeft = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EarringALeft_Bone), 16));
                BoneSaver.EarringARight = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EarringARight_Bone), 16));
                BoneSaver.EarringBLeft = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EarringBLeft_Bone), 16));
                BoneSaver.EarringBRight = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EarringBRight_Bone), 16));
                #endregion
                #region Body
                BoneSaver.SpineA = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.SpineA_Bone), 16));
                BoneSaver.SpineB = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.SpineB_Bone), 16));
                BoneSaver.BreastLeft = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.BreastLeft_Bone), 16));
                BoneSaver.BreastRight = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.BreastRight_Bone), 16));
                BoneSaver.SpineC = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.SpineC_Bone), 16));
                BoneSaver.ScabbardLeft = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ScabbardLeft_Bone), 16));
                BoneSaver.ScabbardRight = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ScabbardRight_Bone), 16));
                BoneSaver.Neck = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.Neck_Bone), 16));
                #endregion
                #region LeftArm
                BoneSaver.ClavicleLeft = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClavicleLeft_Bone), 16));
                BoneSaver.ArmLeft = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ArmLeft_Bone), 16));
                BoneSaver.PauldronLeft = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.PauldronLeft_Bone), 16));
                BoneSaver.ForearmLeft = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ForearmLeft_Bone), 16));
                BoneSaver.ShoulderLeft = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ShoulderLeft_Bone), 16));
                BoneSaver.ShieldLeft = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ShieldLeft_Bone), 16));
                BoneSaver.ElbowLeft = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ElbowLeft_Bone), 16));
                BoneSaver.CouterLeft = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.CouterLeft_Bone), 16));
                BoneSaver.WristLeft = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.WristLeft_Bone), 16));
                #endregion
                #region RightArm
                BoneSaver.ClavicleRight = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClavicleRight_Bone), 16));
                BoneSaver.ArmRight = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ArmRight_Bone), 16));
                BoneSaver.PauldronRight = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.PauldronRight_Bone), 16));
                BoneSaver.ForearmRight = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ForearmRight_Bone), 16));
                BoneSaver.ShoulderRight = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ShoulderRight_Bone), 16));
                BoneSaver.ShieldRight = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ShieldRight_Bone), 16));
                BoneSaver.ElbowRight = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ElbowRight_Bone), 16));
                BoneSaver.CouterRight = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.CouterRight_Bone), 16));
                BoneSaver.WristRight = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.WristRight_Bone), 16));
                #endregion
                #region Clothes
                BoneSaver.ClothBackALeft = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothBackALeft_Bone), 16));
                BoneSaver.ClothBackARight = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothBackARight_Bone), 16));
                BoneSaver.ClothFrontALeft = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothFrontALeft_Bone), 16));
                BoneSaver.ClothFrontARight = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothFrontARight_Bone), 16));
                BoneSaver.ClothSideALeft = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothSideALeft_Bone), 16));
                BoneSaver.ClothSideARight = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothSideARight_Bone), 16));
                BoneSaver.ClothBackBLeft = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothBackBLeft_Bone), 16));
                BoneSaver.ClothBackBRight = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothBackBRight_Bone), 16));
                BoneSaver.ClothFrontBLeft = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothFrontBLeft_Bone), 16));
                BoneSaver.ClothFrontBRight = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothFrontBRight_Bone), 16));
                BoneSaver.ClothSideBLeft = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothSideBLeft_Bone), 16));
                BoneSaver.ClothSideBRight = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothSideBRight_Bone), 16));
                BoneSaver.ClothBackCLeft = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothBackCLeft_Bone), 16));
                BoneSaver.ClothBackCRight = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothBackCRight_Bone), 16));
                BoneSaver.ClothFrontCLeft = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothFrontCLeft_Bone), 16));
                BoneSaver.ClothFrontCRight = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothFrontCRight_Bone), 16));
                BoneSaver.ClothSideCLeft = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothSideCLeft_Bone), 16));
                BoneSaver.ClothSideCRight = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothSideCRight_Bone), 16));
                #endregion
                #region Weapons
                BoneSaver.WeaponLeft = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.WeaponLeft_Bone), 16));
                BoneSaver.WeaponRight = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.WeaponRight_Bone), 16));
                #endregion
                #region LeftHand
                BoneSaver.HandLeft = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HandLeft_Bone), 16));
                BoneSaver.IndexALeft = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.IndexALeft_Bone), 16));
                BoneSaver.PinkyALeft = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.PinkyALeft_Bone), 16));
                BoneSaver.RingALeft = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.RingALeft_Bone), 16));
                BoneSaver.MiddleALeft = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.MiddleALeft_Bone), 16));
                BoneSaver.ThumbALeft = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ThumbALeft_Bone), 16));
                BoneSaver.IndexBLeft = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.IndexBLeft_Bone), 16));
                BoneSaver.PinkyBLeft = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.PinkyBLeft_Bone), 16));
                BoneSaver.RingBLeft = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.RingBLeft_Bone), 16));
                BoneSaver.MiddleBLeft = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.MiddleBLeft_Bone), 16));
                BoneSaver.ThumbBLeft = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ThumbBLeft_Bone), 16));
                #endregion
                #region RightHand
                BoneSaver.HandRight = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HandRight_Bone), 16));
                BoneSaver.IndexARight = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.IndexARight_Bone), 16));
                BoneSaver.PinkyARight = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.PinkyARight_Bone), 16));
                BoneSaver.RingARight = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.RingARight_Bone), 16));
                BoneSaver.MiddleARight = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.MiddleARight_Bone), 16));
                BoneSaver.ThumbARight = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ThumbARight_Bone), 16));
                BoneSaver.IndexBRight = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.IndexBRight_Bone), 16));
                BoneSaver.PinkyBRight = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.PinkyBRight_Bone), 16));
                BoneSaver.RingBRight = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.RingBRight_Bone), 16));
                BoneSaver.MiddleBRight = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.MiddleBRight_Bone), 16));
                BoneSaver.ThumbBRight = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ThumbBRight_Bone), 16));
                #endregion
                #region Waist
                BoneSaver.Waist = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.Waist_Bone), 16));
                BoneSaver.HolsterLeft = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HolsterLeft_Bone), 16));
                BoneSaver.HolsterRight = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HolsterRight_Bone), 16));
                BoneSaver.SheatheLeft = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.SheatheLeft_Bone), 16));
                BoneSaver.SheatheRight = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.SheatheRight_Bone), 16));
                if ( AppearanceArray[0] == 4 ||  AppearanceArray[0] == 6 ||  AppearanceArray[0] == 7)
                {
                    BoneSaver.TailA = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.TailA_Bone), 16));
                    BoneSaver.TailB = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.TailB_Bone), 16));
                    BoneSaver.TailC = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.TailC_Bone), 16));
                    BoneSaver.TailD = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.TailD_Bone), 16));
                    BoneSaver.TailE = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.TailE_Bone), 16));
                }
                else
                {
                    BoneSaver.TailA = "null";
                    BoneSaver.TailB = "null";
                    BoneSaver.TailC = "null";
                    BoneSaver.TailD = "null";
                    BoneSaver.TailE = "null";
                }
                #endregion
                #region LeftLeg
                BoneSaver.LegLeft = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LegsLeft_Bone), 16));
                BoneSaver.KneeLeft = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.KneeLeft_Bone), 16));
                BoneSaver.CalfLeft = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.CalfLeft_Bone), 16));
                BoneSaver.PoleynLeft = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.PoleynLeft_Bone), 16));
                BoneSaver.FootLeft = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.FootLeft_Bone), 16));
                BoneSaver.ToesLeft = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ToesLeft_Bone), 16));
                #endregion
                #region RightLeg
                BoneSaver.LegRight = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LegsRight_Bone), 16));
                BoneSaver.KneeRight = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.KneeRight_Bone), 16));
                BoneSaver.CalfRight = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.CalfRight_Bone), 16));
                BoneSaver.PoleynRight = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.PoleynRight_Bone), 16));
                BoneSaver.FootRight = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.FootRight_Bone), 16));
                BoneSaver.ToesRight = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ToesRight_Bone), 16));
                #endregion
                #region Helm
                var HelmValue = m.readByte(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMet_Value));
                if (HelmValue >= 1)
                {
                    BoneSaver.ExRootMet = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExRootMet_Bone), 16));
                }
                if (HelmValue >= 2)
                {
                    BoneSaver.ExMetA = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetA_Bone), 16));
                }
                else
                {
                    BoneSaver.ExMetA = "null";
                }
                if (HelmValue >= 3)
                {
                    BoneSaver.ExMetB = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetB_Bone), 16));
                }
                else
                {
                    BoneSaver.ExMetB = "null";
                }
                if (HelmValue >= 4)
                {
                    BoneSaver.ExMetC = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetC_Bone), 16));
                }
                else
                {
                    BoneSaver.ExMetC = "null";
                }
                if (HelmValue >= 5)
                {
                    BoneSaver.ExMetD = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetD_Bone), 16));
                }
                else
                {
                    BoneSaver.ExMetD = "null";
                }
                if (HelmValue >= 6)
                {
                    BoneSaver.ExMetE = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetE_Bone), 16));
                }
                else
                {
                    BoneSaver.ExMetE = "null";
                }
                if (HelmValue >= 7)
                {
                    BoneSaver.ExMetF = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetF_Bone), 16));
                }
                else
                {
                    BoneSaver.ExMetF = "null";
                }
                if (HelmValue >= 8)
                {
                    BoneSaver.ExMetG = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetG_Bone), 16));
                }
                else
                {
                    BoneSaver.ExMetG = "null";
                }
                if (HelmValue >= 9)
                {
                    BoneSaver.ExMetH = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetH_Bone), 16));
                }
                else
                {
                    BoneSaver.ExMetH = "null";
                }
                if (HelmValue >= 10)
                {
                    BoneSaver.ExMetI = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetI_Bone), 16));
                }
                else
                {
                    BoneSaver.ExMetI = "null";
                }
                if (HelmValue >= 11)
                {
                    BoneSaver.ExMetJ = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetJ_Bone), 16));
                }
                else
                {
                    BoneSaver.ExMetJ = "null";
                }
                if (HelmValue >= 12)
                {
                    BoneSaver.ExMetK = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetK_Bone), 16));
                }
                else
                {
                    BoneSaver.ExMetK = "null";
                }
                if (HelmValue >= 13)
                {
                    BoneSaver.ExMetL = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetL_Bone), 16));
                }
                else
                {
                    BoneSaver.ExMetL = "null";
                }
                if (HelmValue >= 14)
                {
                    BoneSaver.ExMetM = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetM_Bone), 16));
                }
                else
                {
                    BoneSaver.ExMetM = "null";
                }
                if (HelmValue >= 15)
                {
                    BoneSaver.ExMetN = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetN_Bone), 16));
                }
                else
                {
                    BoneSaver.ExMetN = "null";
                }
                if (HelmValue >= 16)
                {
                    BoneSaver.ExMetO = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetO_Bone), 16));
                }
                else
                {
                    BoneSaver.ExMetO = "null";
                }
                if (HelmValue >= 17)
                {
                    BoneSaver.ExMetP = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetP_Bone), 16));
                }
                else
                {
                    BoneSaver.ExMetP = "null";
                }
                if (HelmValue >= 18)
                {
                    BoneSaver.ExMetQ = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetQ_Bone), 16));
                }
                else
                {
                    BoneSaver.ExMetQ = "null";
                }
                if (HelmValue >= 19)
                {
                    BoneSaver.ExMetR = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetR_Bone), 16));
                }
                else
                {
                    BoneSaver.ExMetR = "null";
                }
                if (BoneSaver.ExRootMet == null)
                {
                    BoneSaver.ExRootMet = "null";
                    BoneSaver.ExMetA = "null";
                    BoneSaver.ExMetB = "null";
                    BoneSaver.ExMetC = "null";
                    BoneSaver.ExMetD = "null";
                    BoneSaver.ExMetE = "null";
                    BoneSaver.ExMetF = "null";
                    BoneSaver.ExMetG = "null";
                    BoneSaver.ExMetH = "null";
                    BoneSaver.ExMetI = "null";
                    BoneSaver.ExMetJ = "null";
                    BoneSaver.ExMetK = "null";
                    BoneSaver.ExMetL = "null";
                    BoneSaver.ExMetM = "null";
                    BoneSaver.ExMetN = "null";
                    BoneSaver.ExMetO = "null";
                    BoneSaver.ExMetP = "null";
                    BoneSaver.ExMetQ = "null";
                    BoneSaver.ExMetR = "null";
                }
                #endregion
                #region Top
                var TopValue = m.readByte(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExTop_Value));
                if (TopValue >= 1)
                {
                    BoneSaver.ExRootTop = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExRootTop_Bone), 16));
                }
                if (TopValue >= 2)
                {
                    BoneSaver.ExTopA = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExTopA_Bone), 16));
                }
                else
                {
                    BoneSaver.ExTopA = "null";
                }
                if (TopValue >= 3)
                {
                    BoneSaver.ExTopB = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExTopB_Bone), 16));
                }
                else
                {
                    BoneSaver.ExTopB = "null";
                }
                if (TopValue >= 4)
                {
                    BoneSaver.ExTopC = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExTopC_Bone), 16));
                }
                else
                {
                    BoneSaver.ExTopC = "null";
                }
                if (TopValue >= 5)
                {
                    BoneSaver.ExTopD = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExTopD_Bone), 16));
                }
                else
                {
                    BoneSaver.ExTopD = "null";
                }
                if (TopValue >= 6)
                {
                    BoneSaver.ExTopE = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExTopE_Bone), 16));
                }
                else
                {
                    BoneSaver.ExTopE = "null";
                }
                if (TopValue >= 7)
                {
                    BoneSaver.ExTopF = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExTopF_Bone), 16));
                }
                else
                {
                    BoneSaver.ExTopF = "null";
                }
                if (TopValue >= 8)
                {
                    BoneSaver.ExTopG = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExTopG_Bone), 16));
                }
                else
                {
                    BoneSaver.ExTopG = "null";
                }
                if (TopValue >= 9)
                {
                    BoneSaver.ExTopH = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExTopH_Bone), 16));
                }
                else
                {
                    BoneSaver.ExTopH = "null";
                }
                if (TopValue >= 10)
                {
                    BoneSaver.ExTopI = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExTopI_Bone), 16));
                }
                else
                {
                    BoneSaver.ExTopI = "null";
                }
                if (BoneSaver.ExRootTop == null)
                {
                    BoneSaver.ExRootTop = "null";
                    BoneSaver.ExTopA = "null";
                    BoneSaver.ExTopB = "null";
                    BoneSaver.ExTopC = "null";
                    BoneSaver.ExTopD = "null";
                    BoneSaver.ExTopE = "null";
                    BoneSaver.ExTopF = "null";
                    BoneSaver.ExTopG = "null";
                    BoneSaver.ExTopH = "null";
                    BoneSaver.ExTopI = "null";
                }
                #endregion
                #region Other
                BoneSaver.Root = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.Root_Bone), 16));
                BoneSaver.Abdomen = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.Abdomen_Bone), 16));
                BoneSaver.Throw = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.Throw_Bone), 16));
                BoneSaver.Unknown00 = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.Unknown00_Bone), 16));
                #endregion

                #region Scale Bones
                #region Head
                BoneSaver.HeadSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.Head_Size), 16));
                BoneSaver.EarLeftSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EarLeft_Size), 16));
                BoneSaver.EarRightSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EarRight_Size), 16));
                BoneSaver.JawSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.Jaw_Size), 16));
                BoneSaver.EyelidLowerLeftSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyelidLowerLeft_Size), 16));
                BoneSaver.EyelidLowerRightSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyelidLowerRight_Size), 16));
                BoneSaver.EyeLeftSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyeLeft_Size), 16));
                BoneSaver.EyeRightSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyeRight_Size), 16));
                BoneSaver.NoseSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.Nose_Size), 16));
                BoneSaver.CheekLeftSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.CheekLeft_Size), 16));
                BoneSaver.HrothWhiskersLeftSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothWhiskersLeft_Size), 16));
                BoneSaver.CheekRightSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.CheekRight_Size), 16));
                BoneSaver.HrothWhiskersRightSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothWhiskersRight_Size), 16));
                BoneSaver.LipsLeftSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipsLeft_Size), 16));
                BoneSaver.HrothEyebrowLeftSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothEyebrowLeft_Size), 16));
                BoneSaver.LipsRightSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipsRight_Size), 16));
                BoneSaver.HrothEyebrowRightSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothEyebrowRight_Size), 16));
                BoneSaver.EyebrowLeftSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyebrowLeft_Size), 16));
                BoneSaver.HrothBridgeSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothBridge_Size), 16));
                BoneSaver.EyebrowRightSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyebrowRight_Size), 16));
                BoneSaver.HrothBrowLeftSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothBrowLeft_Size), 16));
                BoneSaver.BridgeSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.Bridge_Size), 16));
                BoneSaver.HrothBrowRightSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothBrowRight_Size), 16));
                BoneSaver.BrowLeftSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.BrowLeft_Size), 16));
                BoneSaver.HrothJawUpperSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothJawUpper_Size), 16));
                BoneSaver.BrowRightSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.BrowRight_Size), 16));
                BoneSaver.HrothLipUpperSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothLipUpper_Size), 16));
                BoneSaver.LipUpperASize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipUpperA_Size), 16));
                BoneSaver.HrothEyelidUpperLeftSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothEyelidUpperLeft_Size), 16));
                BoneSaver.EyelidUpperLeftSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyelidUpperLeft_Size), 16));
                BoneSaver.HrothEyelidUpperRightSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothEyelidUpperRight_Size), 16));
                BoneSaver.EyelidUpperRightSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyelidUpperRight_Size), 16));
                BoneSaver.HrothLipsLeftSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothLipsLeft_Size), 16));
                BoneSaver.LipLowerASize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipLowerA_Size), 16));
                BoneSaver.HrothLipsRightSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothLipsRight_Size), 16));
                BoneSaver.VieraEar01ALeftSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar01ALeft_Size), 16));
                BoneSaver.LipUpperBSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipUpperB_Size), 16));
                BoneSaver.HrothLipUpperLeftSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothLipUpperLeft_Size), 16));
                BoneSaver.VieraEar01ARightSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar01ARight_Size), 16));
                BoneSaver.LipLowerBSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipLowerB_Size), 16));
                BoneSaver.HrothLipUpperRightSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothLipUpperRight_Size), 16));
                BoneSaver.VieraEar02ALeftSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar02ALeft_Size), 16));
                if (AppearanceArray[0] == 7 || AppearanceArray[0] == 8)
                {
                    BoneSaver.HrothLipLowerSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothLipLower_Size), 16));
                    BoneSaver.VieraEar02ARightSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar02ARight_Size), 16));
                }
                else
                {
                    BoneSaver.HrothLipLower = "null";
                    BoneSaver.VieraEar02ARight = "null";
                }
                if (AppearanceArray[0] == 8)
                {
                    BoneSaver.VieraEar03ALeftSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar03ALeft_Size), 16));
                    BoneSaver.VieraEar03ARightSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar03ARight_Size), 16));
                    BoneSaver.VieraEar04ALeftSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar04ALeft_Size), 16));
                    BoneSaver.VieraEar04ARightSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar04ARight_Size), 16));
                    BoneSaver.VieraLipLowerASize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraLipLowerA_Size), 16));
                    BoneSaver.VieraLipUpperBSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraLipUpperB_Size), 16));
                    BoneSaver.VieraEar01BLeftSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar01BLeft_Size), 16));
                    BoneSaver.VieraEar01BRightSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar01BRight_Size), 16));
                    BoneSaver.VieraEar02BLeftSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar02BLeft_Size), 16));
                    BoneSaver.VieraEar02BRightSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar02BRight_Size), 16));
                    BoneSaver.VieraEar03BLeftSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar03BLeft_Size), 16));
                    BoneSaver.VieraEar03BRightSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar03BRight_Size), 16));
                    BoneSaver.VieraEar04BLeftSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar04BLeft_Size), 16));
                    BoneSaver.VieraEar04BRightSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar04BRight_Size), 16));
                    BoneSaver.VieraLipLowerBSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraLipLowerB_Size), 16));
                }
                else
                {
                    BoneSaver.VieraEar03ALeft = "null";
                    BoneSaver.VieraEar03ARight = "null";
                    BoneSaver.VieraEar04ALeft = "null";
                    BoneSaver.VieraEar04ARight = "null";
                    BoneSaver.VieraLipLowerA = "null";
                    BoneSaver.VieraLipUpperB = "null";
                    BoneSaver.VieraEar01BLeft = "null";
                    BoneSaver.VieraEar01BRight = "null";
                    BoneSaver.VieraEar02BLeft = "null";
                    BoneSaver.VieraEar02BRight = "null";
                    BoneSaver.VieraEar03BLeft = "null";
                    BoneSaver.VieraEar03BRight = "null";
                    BoneSaver.VieraEar04BLeft = "null";
                    BoneSaver.VieraEar04BRight = "null";
                    BoneSaver.VieraLipLowerB = "null";
                }
                #endregion
                #region Hair
                BoneSaver.HairASize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HairA_Size), 16));
                BoneSaver.HairFrontLeftSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HairFrontLeft_Size), 16));
                BoneSaver.HairFrontRightSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HairFrontRight_Size), 16));
                BoneSaver.HairBSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HairB_Size), 16));

                if (HairValue >= 1)
                {
                   // BoneSaver.ExRootHairSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExRootHair_Size), 16));
                }
                if (HairValue >= 2)
                {
                    BoneSaver.ExHairASize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExHairA_Size), 16));
                }
                else
                {
                    BoneSaver.ExHairA = "null";
                }
                if (HairValue >= 3)
                {
                    BoneSaver.ExHairBSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExHairB_Size), 16));
                }
                else
                {
                    BoneSaver.ExHairB = "null";
                }
                if (HairValue >= 4)
                {
                    BoneSaver.ExHairCSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExHairC_Size), 16));
                }
                else
                {
                    BoneSaver.ExHairC = "null";
                }
                if (HairValue >= 5)
                {
                    BoneSaver.ExHairDSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExHairD_Size), 16));
                }
                else
                {
                    BoneSaver.ExHairD = "null";
                }
                if (HairValue >= 6)
                {
                    BoneSaver.ExHairESize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExHairE_Size), 16));
                }
                else
                {
                    BoneSaver.ExHairE = "null";
                }
                if (HairValue >= 7)
                {
                    BoneSaver.ExHairFSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExHairF_Size), 16));
                }
                else
                {
                    BoneSaver.ExHairF = "null";
                }
                if (HairValue >= 8)
                {
                    BoneSaver.ExHairGSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExHairG_Size), 16));
                }
                else
                {
                    BoneSaver.ExHairG = "null";
                }
                if (HairValue >= 9)
                {
                    BoneSaver.ExHairHSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExHairH_Size), 16));
                }
                else
                {
                    BoneSaver.ExHairH = "null";
                }
                if (HairValue >= 10)
                {
                    BoneSaver.ExHairISize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExHairI_Size), 16));
                }
                else
                {
                    BoneSaver.ExHairI = "null";
                }
                if (HairValue >= 11)
                {
                    BoneSaver.ExHairJSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExHairJ_Size), 16));
                }
                else
                {
                    BoneSaver.ExHairJ = "null";
                }
                if (HairValue >= 12)
                {
                    BoneSaver.ExHairKSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExHairK_Size), 16));
                }
                else
                {
                    BoneSaver.ExHairK = "null";
                }
                if (HairValue >= 13)
                {
                    BoneSaver.ExHairLSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExHairL_Size), 16));
                }
                else
                {
                    BoneSaver.ExHairL = "null";
                }
                if (BoneSaver.ExRootHair == null)
                {
                    BoneSaver.ExRootHair = "null";
                    BoneSaver.ExHairA = "null";
                    BoneSaver.ExHairB = "null";
                    BoneSaver.ExHairC = "null";
                    BoneSaver.ExHairD = "null";
                    BoneSaver.ExHairE = "null";
                    BoneSaver.ExHairF = "null";
                    BoneSaver.ExHairG = "null";
                    BoneSaver.ExHairH = "null";
                    BoneSaver.ExHairI = "null";
                    BoneSaver.ExHairJ = "null";
                    BoneSaver.ExHairK = "null";
                    BoneSaver.ExHairL = "null";
                }
                #endregion
                #region Body
                BoneSaver.SpineASize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.SpineA_Size), 16));
                BoneSaver.SpineBSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.SpineB_Size), 16));
                BoneSaver.BreastLeftSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.BreastLeft_Size), 16));
                BoneSaver.BreastRightSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.BreastRight_Size), 16));
                BoneSaver.SpineCSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.SpineC_Size), 16));
                BoneSaver.NeckSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.Neck_Size), 16));
                #endregion
                #region LeftArm
                BoneSaver.ClavicleLeftSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClavicleLeft_Size), 16));
                BoneSaver.ArmLeftSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ArmLeft_Size), 16));
                BoneSaver.ForearmLeftSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ForearmLeft_Size), 16));
                BoneSaver.ShoulderLeftSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ShoulderLeft_Size), 16));
                BoneSaver.ElbowLeftSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ElbowLeft_Size), 16));
                BoneSaver.CouterLeftSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.CouterLeft_Size), 16));
                BoneSaver.WristLeftSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.WristLeft_Size), 16));
                #endregion
                #region RightArm
                BoneSaver.ClavicleRightSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClavicleRight_Size), 16));
                BoneSaver.ArmRightSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ArmRight_Size), 16));
                BoneSaver.ForearmRightSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ForearmRight_Size), 16));
                BoneSaver.ShoulderRightSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ShoulderRight_Size), 16));
                BoneSaver.ElbowRightSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ElbowRight_Size), 16));
                BoneSaver.CouterRightSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.CouterRight_Size), 16));
                BoneSaver.WristRightSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.WristRight_Size), 16));
                #endregion
                #region Clothes
                BoneSaver.ClothBackALeftSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothBackALeft_Size), 16));
                BoneSaver.ClothBackARightSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothBackARight_Size), 16));
                BoneSaver.ClothFrontALeftSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothFrontALeft_Size), 16));
                BoneSaver.ClothFrontARightSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothFrontARight_Size), 16));
                BoneSaver.ClothSideALeftSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothSideALeft_Size), 16));
                BoneSaver.ClothSideARightSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothSideARight_Size), 16));
                BoneSaver.ClothBackBLeftSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothBackBLeft_Size), 16));
                BoneSaver.ClothBackBRightSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothBackBRight_Size), 16));
                BoneSaver.ClothFrontBLeftSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothFrontBLeft_Size), 16));
                BoneSaver.ClothFrontBRightSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothFrontBRight_Size), 16));
                BoneSaver.ClothSideBLeftSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothSideBLeft_Size), 16));
                BoneSaver.ClothSideBRightSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothSideBRight_Size), 16));
                BoneSaver.ClothBackCLeftSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothBackCLeft_Size), 16));
                BoneSaver.ClothBackCRightSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothBackCRight_Size), 16));
                BoneSaver.ClothFrontCLeftSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothFrontCLeft_Size), 16));
                BoneSaver.ClothFrontCRightSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothFrontCRight_Size), 16));
                BoneSaver.ClothSideCLeftSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothSideCLeft_Size), 16));
                BoneSaver.ClothSideCRightSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothSideCRight_Size), 16));
                #endregion
                #region LeftHand
                BoneSaver.HandLeftSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HandLeft_Size), 16));
                BoneSaver.IndexALeftSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.IndexALeft_Size), 16));
                BoneSaver.PinkyALeftSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.PinkyALeft_Size), 16));
                BoneSaver.RingALeftSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.RingALeft_Size), 16));
                BoneSaver.MiddleALeftSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.MiddleALeft_Size), 16));
                BoneSaver.ThumbALeftSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ThumbALeft_Size), 16));
                BoneSaver.IndexBLeftSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.IndexBLeft_Size), 16));
                BoneSaver.PinkyBLeftSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.PinkyBLeft_Size), 16));
                BoneSaver.RingBLeftSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.RingBLeft_Size), 16));
                BoneSaver.MiddleBLeftSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.MiddleBLeft_Size), 16));
                BoneSaver.ThumbBLeftSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ThumbBLeft_Size), 16));
                #endregion
                #region RightHand
                BoneSaver.HandRightSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HandRight_Size), 16));
                BoneSaver.IndexARightSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.IndexARight_Size), 16));
                BoneSaver.PinkyARightSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.PinkyARight_Size), 16));
                BoneSaver.RingARightSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.RingARight_Size), 16));
                BoneSaver.MiddleARightSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.MiddleARight_Size), 16));
                BoneSaver.ThumbARightSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ThumbARight_Size), 16));
                BoneSaver.IndexBRightSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.IndexBRight_Size), 16));
                BoneSaver.PinkyBRightSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.PinkyBRight_Size), 16));
                BoneSaver.RingBRightSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.RingBRight_Size), 16));
                BoneSaver.MiddleBRightSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.MiddleBRight_Size), 16));
                BoneSaver.ThumbBRightSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ThumbBRight_Size), 16));
                #endregion
                #region Waist
                BoneSaver.WaistSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.Waist_Size), 16));
                if (AppearanceArray[0] == 4 || AppearanceArray[0] == 6 || AppearanceArray[0] == 7)
                {
                    BoneSaver.TailASize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.TailA_Size), 16));
                    BoneSaver.TailBSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.TailB_Size), 16));
                    BoneSaver.TailCSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.TailC_Size), 16));
                    BoneSaver.TailDSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.TailD_Size), 16));
                    BoneSaver.TailESize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.TailE_Size), 16));
                }
                else
                {
                    BoneSaver.TailA = "null";
                    BoneSaver.TailB = "null";
                    BoneSaver.TailC = "null";
                    BoneSaver.TailD = "null";
                    BoneSaver.TailE = "null";
                }
                #endregion
                #region LeftLeg
                BoneSaver.LegLeftSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LegsLeft_Size), 16));
                BoneSaver.KneeLeftSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.KneeLeft_Size), 16));
                BoneSaver.CalfLeftSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.CalfLeft_Size), 16));
                BoneSaver.PoleynLeftSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.PoleynLeft_Size), 16));
                BoneSaver.FootLeftSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.FootLeft_Size), 16));
                BoneSaver.ToesLeftSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ToesLeft_Size), 16));
                #endregion
                #region RightLeg
                BoneSaver.LegRightSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LegsRight_Size), 16));
                BoneSaver.KneeRightSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.KneeRight_Size), 16));
                BoneSaver.CalfRightSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.CalfRight_Size), 16));
                BoneSaver.PoleynRightSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.PoleynRight_Size), 16));
                BoneSaver.FootRightSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.FootRight_Size), 16));
                BoneSaver.ToesRightSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ToesRight_Size), 16));
                #endregion
                #region Helm
                if (HelmValue >= 1)
                {
       //             BoneSaver.ExRootMetSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExRootMet_Size), 16));
                }
                if (HelmValue >= 2)
                {
                    BoneSaver.ExMetASize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetA_Size), 16));
                }
                else
                {
                    BoneSaver.ExMetA = "null";
                }
                if (HelmValue >= 3)
                {
                    BoneSaver.ExMetBSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetB_Size), 16));
                }
                else
                {
                    BoneSaver.ExMetB = "null";
                }
                if (HelmValue >= 4)
                {
                    BoneSaver.ExMetCSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetC_Size), 16));
                }
                else
                {
                    BoneSaver.ExMetC = "null";
                }
                if (HelmValue >= 5)
                {
                    BoneSaver.ExMetDSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetD_Size), 16));
                }
                else
                {
                    BoneSaver.ExMetD = "null";
                }
                if (HelmValue >= 6)
                {
                    BoneSaver.ExMetESize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetE_Size), 16));
                }
                else
                {
                    BoneSaver.ExMetE = "null";
                }
                if (HelmValue >= 7)
                {
                    BoneSaver.ExMetFSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetF_Size), 16));
                }
                else
                {
                    BoneSaver.ExMetF = "null";
                }
                if (HelmValue >= 8)
                {
                    BoneSaver.ExMetGSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetG_Size), 16));
                }
                else
                {
                    BoneSaver.ExMetG = "null";
                }
                if (HelmValue >= 9)
                {
                    BoneSaver.ExMetHSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetH_Size), 16));
                }
                else
                {
                    BoneSaver.ExMetH = "null";
                }
                if (HelmValue >= 10)
                {
                    BoneSaver.ExMetISize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetI_Size), 16));
                }
                else
                {
                    BoneSaver.ExMetI = "null";
                }
                if (HelmValue >= 11)
                {
                    BoneSaver.ExMetJSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetJ_Size), 16));
                }
                else
                {
                    BoneSaver.ExMetJ = "null";
                }
                if (HelmValue >= 12)
                {
                    BoneSaver.ExMetKSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetK_Size), 16));
                }
                else
                {
                    BoneSaver.ExMetK = "null";
                }
                if (HelmValue >= 13)
                {
                    BoneSaver.ExMetLSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetL_Size), 16));
                }
                else
                {
                    BoneSaver.ExMetL = "null";
                }
                if (HelmValue >= 14)
                {
                    BoneSaver.ExMetMSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetM_Size), 16));
                }
                else
                {
                    BoneSaver.ExMetM = "null";
                }
                if (HelmValue >= 15)
                {
                    BoneSaver.ExMetNSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetN_Size), 16));
                }
                else
                {
                    BoneSaver.ExMetN = "null";
                }
                if (HelmValue >= 16)
                {
                    BoneSaver.ExMetOSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetO_Size), 16));
                }
                else
                {
                    BoneSaver.ExMetO = "null";
                }
                if (HelmValue >= 17)
                {
                    BoneSaver.ExMetPSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetP_Size), 16));
                }
                else
                {
                    BoneSaver.ExMetP = "null";
                }
                if (HelmValue >= 18)
                {
                    BoneSaver.ExMetQSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetQ_Size), 16));
                }
                else
                {
                    BoneSaver.ExMetQ = "null";
                }
                if (HelmValue >= 19)
                {
                    BoneSaver.ExMetRSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetR_Size), 16));
                }
                else
                {
                    BoneSaver.ExMetR = "null";
                }
                if (BoneSaver.ExRootMet == null)
                {
                    BoneSaver.ExRootMet = "null";
                    BoneSaver.ExMetA = "null";
                    BoneSaver.ExMetB = "null";
                    BoneSaver.ExMetC = "null";
                    BoneSaver.ExMetD = "null";
                    BoneSaver.ExMetE = "null";
                    BoneSaver.ExMetF = "null";
                    BoneSaver.ExMetG = "null";
                    BoneSaver.ExMetH = "null";
                    BoneSaver.ExMetI = "null";
                    BoneSaver.ExMetJ = "null";
                    BoneSaver.ExMetK = "null";
                    BoneSaver.ExMetL = "null";
                    BoneSaver.ExMetM = "null";
                    BoneSaver.ExMetN = "null";
                    BoneSaver.ExMetO = "null";
                    BoneSaver.ExMetP = "null";
                    BoneSaver.ExMetQ = "null";
                    BoneSaver.ExMetR = "null";
                }
                #endregion
                #region Top
                if (TopValue >= 1)
                {
             //       BoneSaver.ExRootTopSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExRootTop_Size), 16));
                }
                if (TopValue >= 2)
                {
                    BoneSaver.ExTopASize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExTopA_Size), 16));
                }
                else
                {
                    BoneSaver.ExTopA = "null";
                }
                if (TopValue >= 3)
                {
                    BoneSaver.ExTopBSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExTopB_Size), 16));
                }
                else
                {
                    BoneSaver.ExTopB = "null";
                }
                if (TopValue >= 4)
                {
                    BoneSaver.ExTopCSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExTopC_Size), 16));
                }
                else
                {
                    BoneSaver.ExTopC = "null";
                }
                if (TopValue >= 5)
                {
                    BoneSaver.ExTopDSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExTopD_Size), 16));
                }
                else
                {
                    BoneSaver.ExTopD = "null";
                }
                if (TopValue >= 6)
                {
                    BoneSaver.ExTopESize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExTopE_Size), 16));
                }
                else
                {
                    BoneSaver.ExTopE = "null";
                }
                if (TopValue >= 7)
                {
                    BoneSaver.ExTopFSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExTopF_Size), 16));
                }
                else
                {
                    BoneSaver.ExTopF = "null";
                }
                if (TopValue >= 8)
                {
                    BoneSaver.ExTopGSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExTopG_Size), 16));
                }
                else
                {
                    BoneSaver.ExTopG = "null";
                }
                if (TopValue >= 9)
                {
                    BoneSaver.ExTopHSize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExTopH_Size), 16));
                }
                else
                {
                    BoneSaver.ExTopH = "null";
                }
                if (TopValue >= 10)
                {
                    BoneSaver.ExTopISize = MemoryManager.ByteArrayToStringU(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExTopI_Size), 16));
                }
                else
                {
                    BoneSaver.ExTopI = "null";
                }
                if (BoneSaver.ExRootTop == null)
                {
                    BoneSaver.ExRootTop = "null";
                    BoneSaver.ExTopA = "null";
                    BoneSaver.ExTopB = "null";
                    BoneSaver.ExTopC = "null";
                    BoneSaver.ExTopD = "null";
                    BoneSaver.ExTopE = "null";
                    BoneSaver.ExTopF = "null";
                    BoneSaver.ExTopG = "null";
                    BoneSaver.ExTopH = "null";
                    BoneSaver.ExTopI = "null";
                }
                #endregion

                #endregion

                string details = JsonConvert.SerializeObject(BoneSaver, Formatting.Indented, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto });
                File.WriteAllText(dig.FileName, details);
                MainWindow.CurrentlySaving = false;
            }
            else MainWindow.CurrentlySaving = false;
        }

        private void LoadCMP_Click(object sender, RoutedEventArgs e)
        {
            DisableTertiary();
            PoseMatrixViewModel.PoseVM.Bone_Flag_Manager();
            OpenFileDialog dig = new OpenFileDialog();
            dig.InitialDirectory = SaveSettings.Default.MatrixPoseSaveLoadDirectory;
            dig.Filter = "Concept Matrix Pose File(*.cmp)|*.cmp";
            dig.DefaultExt = ".cmp";
            if (dig.ShowDialog() == true)

            {
                SaveSettings.Default.MatrixPoseSaveLoadDirectory = Path.GetDirectoryName(dig.FileName);
                if (MemoryManager.Instance.MemLib.readByte(MemoryManager.GetAddressString(MemoryManager.Instance.GposeCheckAddress)) == 1 && MemoryManager.Instance.MemLib.readByte(MemoryManager.GetAddressString(MemoryManager.Instance.GposeCheck2Address)) == 4)
                {
                    UncheckAll();
                    EditModeButton.IsChecked = true;
                    PhysicsButton.IsChecked = false;
                    BoneSaves BoneLoader = JsonConvert.DeserializeObject<BoneSaves>(File.ReadAllText(dig.FileName));

                    #region Head
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.Head_Bone), MemoryManager.StringToByteArray(BoneLoader.Head.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EarLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.EarLeft.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EarRight_Bone), MemoryManager.StringToByteArray(BoneLoader.EarRight.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.Jaw_Bone), MemoryManager.StringToByteArray(BoneLoader.Jaw.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyelidLowerLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.EyelidLowerLeft.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyelidLowerRight_Bone), MemoryManager.StringToByteArray(BoneLoader.EyelidLowerRight.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyeLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.EyeLeft.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyeRight_Bone), MemoryManager.StringToByteArray(BoneLoader.EyeRight.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.Nose_Bone), MemoryManager.StringToByteArray(BoneLoader.Nose.Replace(" ", string.Empty)));
                    if (CharacterDetails.Race.value < 7)
                    {
                        if (BoneLoader.Race == "01" || BoneLoader.Race == "02" || BoneLoader.Race == "03" || BoneLoader.Race == "04" || BoneLoader.Race == "05" || BoneLoader.Race == "06")
                        {
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.CheekLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.CheekLeft.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.CheekRight_Bone), MemoryManager.StringToByteArray(BoneLoader.CheekRight.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipsLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.LipsLeft.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipsRight_Bone), MemoryManager.StringToByteArray(BoneLoader.LipsRight.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyebrowLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.EyebrowLeft.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyebrowRight_Bone), MemoryManager.StringToByteArray(BoneLoader.EyebrowRight.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.Bridge_Bone), MemoryManager.StringToByteArray(BoneLoader.Bridge.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.BrowLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.BrowLeft.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.BrowRight_Bone), MemoryManager.StringToByteArray(BoneLoader.BrowRight.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipUpperA_Bone), MemoryManager.StringToByteArray(BoneLoader.LipUpperA.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyelidUpperLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.EyelidUpperLeft.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyelidUpperRight_Bone), MemoryManager.StringToByteArray(BoneLoader.EyelidUpperRight.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipLowerA_Bone), MemoryManager.StringToByteArray(BoneLoader.LipLowerA.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipUpperB_Bone), MemoryManager.StringToByteArray(BoneLoader.LipUpperB.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipLowerB_Bone), MemoryManager.StringToByteArray(BoneLoader.LipLowerB.Replace(" ", string.Empty)));
                        }
                        if (BoneLoader.Race == "07")
                        {
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.CheekLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.HrothLipUpperLeft.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.CheekRight_Bone), MemoryManager.StringToByteArray(BoneLoader.HrothLipUpperRight.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipsLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.HrothLipsLeft.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipsRight_Bone), MemoryManager.StringToByteArray(BoneLoader.HrothLipsRight.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyebrowLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.HrothEyebrowLeft.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyebrowRight_Bone), MemoryManager.StringToByteArray(BoneLoader.HrothEyebrowRight.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.Bridge_Bone), MemoryManager.StringToByteArray(BoneLoader.HrothBridge.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.BrowLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.HrothBrowLeft.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.BrowRight_Bone), MemoryManager.StringToByteArray(BoneLoader.HrothBrowRight.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipUpperA_Bone), MemoryManager.StringToByteArray(BoneLoader.HrothLipUpper.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyelidUpperLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.HrothEyelidUpperLeft.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyelidUpperRight_Bone), MemoryManager.StringToByteArray(BoneLoader.HrothEyelidUpperRight.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipUpperB_Bone), MemoryManager.StringToByteArray(BoneLoader.HrothJawUpper.Replace(" ", string.Empty)));
                        }
                        if (BoneLoader.Race == "08")
                        {
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.CheekLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.CheekLeft.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.CheekRight_Bone), MemoryManager.StringToByteArray(BoneLoader.CheekRight.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipsLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.LipsLeft.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipsRight_Bone), MemoryManager.StringToByteArray(BoneLoader.LipsRight.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyebrowLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.EyebrowLeft.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyebrowRight_Bone), MemoryManager.StringToByteArray(BoneLoader.EyebrowRight.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.Bridge_Bone), MemoryManager.StringToByteArray(BoneLoader.Bridge.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.BrowLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.BrowLeft.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.BrowRight_Bone), MemoryManager.StringToByteArray(BoneLoader.BrowRight.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipUpperA_Bone), MemoryManager.StringToByteArray(BoneLoader.LipUpperA.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyelidUpperLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.EyelidUpperLeft.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyelidUpperRight_Bone), MemoryManager.StringToByteArray(BoneLoader.EyelidUpperRight.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipLowerA_Bone), MemoryManager.StringToByteArray(BoneLoader.VieraLipLowerA.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipUpperB_Bone), MemoryManager.StringToByteArray(BoneLoader.VieraLipUpperB.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipLowerB_Bone), MemoryManager.StringToByteArray(BoneLoader.VieraLipLowerB.Replace(" ", string.Empty)));
                        }
                    }
                    if (CharacterDetails.Race.value == 7)
                    {
                        if (BoneLoader.Race == "01" || BoneLoader.Race == "02" || BoneLoader.Race == "03" || BoneLoader.Race == "04" || BoneLoader.Race == "05" || BoneLoader.Race == "06")
                        {
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothEyebrowLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.EyebrowLeft.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothEyebrowRight_Bone), MemoryManager.StringToByteArray(BoneLoader.EyebrowRight.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothBridge_Bone), MemoryManager.StringToByteArray(BoneLoader.Bridge.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothBrowLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.BrowLeft.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothBrowRight_Bone), MemoryManager.StringToByteArray(BoneLoader.BrowRight.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothJawUpper_Bone), MemoryManager.StringToByteArray(BoneLoader.LipUpperB.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothLipUpper_Bone), MemoryManager.StringToByteArray(BoneLoader.LipUpperA.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothEyelidUpperLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.EyelidUpperLeft.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothEyelidUpperRight_Bone), MemoryManager.StringToByteArray(BoneLoader.EyelidUpperRight.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothLipsLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.LipsLeft.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothLipsRight_Bone), MemoryManager.StringToByteArray(BoneLoader.LipsRight.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothLipUpperLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.CheekLeft.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothLipUpperRight_Bone), MemoryManager.StringToByteArray(BoneLoader.CheekRight.Replace(" ", string.Empty)));
                        }
                        if (BoneLoader.Race == "07")
                        {
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothWhiskersLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.HrothWhiskersLeft.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothWhiskersRight_Bone), MemoryManager.StringToByteArray(BoneLoader.HrothWhiskersRight.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothEyebrowLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.HrothEyebrowLeft.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothEyebrowRight_Bone), MemoryManager.StringToByteArray(BoneLoader.HrothEyebrowRight.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothBridge_Bone), MemoryManager.StringToByteArray(BoneLoader.HrothBridge.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothBrowLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.HrothBrowLeft.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothBrowRight_Bone), MemoryManager.StringToByteArray(BoneLoader.HrothBrowRight.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothJawUpper_Bone), MemoryManager.StringToByteArray(BoneLoader.HrothJawUpper.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothLipUpper_Bone), MemoryManager.StringToByteArray(BoneLoader.HrothLipUpper.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothEyelidUpperLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.HrothEyelidUpperLeft.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothEyelidUpperRight_Bone), MemoryManager.StringToByteArray(BoneLoader.HrothEyelidUpperRight.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothLipsLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.HrothLipsLeft.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothLipsRight_Bone), MemoryManager.StringToByteArray(BoneLoader.HrothLipsRight.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothLipUpperLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.HrothLipUpperLeft.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothLipUpperRight_Bone), MemoryManager.StringToByteArray(BoneLoader.HrothLipUpperRight.Replace(" ", string.Empty)));
                        }
                        if (BoneLoader.Race == "08")
                        {
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothEyebrowLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.EyebrowLeft.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothEyebrowRight_Bone), MemoryManager.StringToByteArray(BoneLoader.EyebrowRight.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothBridge_Bone), MemoryManager.StringToByteArray(BoneLoader.Bridge.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothBrowLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.BrowLeft.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothBrowRight_Bone), MemoryManager.StringToByteArray(BoneLoader.BrowRight.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothJawUpper_Bone), MemoryManager.StringToByteArray(BoneLoader.VieraLipUpperB.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothLipUpper_Bone), MemoryManager.StringToByteArray(BoneLoader.LipUpperA.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothEyelidUpperLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.EyelidUpperLeft.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothEyelidUpperRight_Bone), MemoryManager.StringToByteArray(BoneLoader.EyelidUpperRight.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothLipsLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.LipsLeft.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothLipsRight_Bone), MemoryManager.StringToByteArray(BoneLoader.LipsRight.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothLipUpperLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.CheekLeft.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothLipUpperRight_Bone), MemoryManager.StringToByteArray(BoneLoader.CheekRight.Replace(" ", string.Empty)));
                        }
                    }
                    if (CharacterDetails.Race.value == 8)
                    {
                        if (BoneLoader.Race == "01" || BoneLoader.Race == "02" || BoneLoader.Race == "03" || BoneLoader.Race == "04" || BoneLoader.Race == "05" || BoneLoader.Race == "06")
                        {
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.CheekLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.CheekLeft.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.CheekRight_Bone), MemoryManager.StringToByteArray(BoneLoader.CheekRight.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipsLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.LipsLeft.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipsRight_Bone), MemoryManager.StringToByteArray(BoneLoader.LipsRight.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyebrowLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.EyebrowLeft.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyebrowRight_Bone), MemoryManager.StringToByteArray(BoneLoader.EyebrowRight.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.Bridge_Bone), MemoryManager.StringToByteArray(BoneLoader.Bridge.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.BrowLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.BrowLeft.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.BrowRight_Bone), MemoryManager.StringToByteArray(BoneLoader.BrowRight.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipUpperA_Bone), MemoryManager.StringToByteArray(BoneLoader.LipUpperA.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyelidUpperLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.EyelidUpperLeft.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyelidUpperRight_Bone), MemoryManager.StringToByteArray(BoneLoader.EyelidUpperRight.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraLipLowerA_Bone), MemoryManager.StringToByteArray(BoneLoader.VieraEar01ALeft.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraLipUpperB_Bone), MemoryManager.StringToByteArray(BoneLoader.VieraEar01ARight.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraLipLowerB_Bone), MemoryManager.StringToByteArray(BoneLoader.VieraEar02ALeft.Replace(" ", string.Empty)));
                        }
                        if (BoneLoader.Race == "07")
                        {
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.CheekLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.HrothLipUpperLeft.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.CheekRight_Bone), MemoryManager.StringToByteArray(BoneLoader.HrothLipUpperRight.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipsLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.HrothLipsLeft.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipsRight_Bone), MemoryManager.StringToByteArray(BoneLoader.HrothLipsRight.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyebrowLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.HrothEyebrowLeft.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyebrowRight_Bone), MemoryManager.StringToByteArray(BoneLoader.HrothEyebrowRight.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.Bridge_Bone), MemoryManager.StringToByteArray(BoneLoader.HrothBridge.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.BrowLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.HrothBrowLeft.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.BrowRight_Bone), MemoryManager.StringToByteArray(BoneLoader.HrothBrowRight.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipUpperA_Bone), MemoryManager.StringToByteArray(BoneLoader.HrothLipUpper.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyelidUpperLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.HrothEyelidUpperLeft.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyelidUpperRight_Bone), MemoryManager.StringToByteArray(BoneLoader.HrothEyelidUpperRight.Replace(" ", string.Empty)));
                        }
                        if (BoneLoader.Race == "08")
                        {
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.CheekLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.CheekLeft.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.CheekRight_Bone), MemoryManager.StringToByteArray(BoneLoader.CheekRight.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipsLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.LipsLeft.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipsRight_Bone), MemoryManager.StringToByteArray(BoneLoader.LipsRight.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyebrowLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.EyebrowLeft.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyebrowRight_Bone), MemoryManager.StringToByteArray(BoneLoader.EyebrowRight.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.Bridge_Bone), MemoryManager.StringToByteArray(BoneLoader.Bridge.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.BrowLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.BrowLeft.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.BrowRight_Bone), MemoryManager.StringToByteArray(BoneLoader.BrowRight.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipUpperA_Bone), MemoryManager.StringToByteArray(BoneLoader.LipUpperA.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyelidUpperLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.EyelidUpperLeft.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyelidUpperRight_Bone), MemoryManager.StringToByteArray(BoneLoader.EyelidUpperRight.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar01ALeft_Bone), MemoryManager.StringToByteArray(BoneLoader.VieraEar01ALeft.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar01ARight_Bone), MemoryManager.StringToByteArray(BoneLoader.VieraEar01ARight.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar02ALeft_Bone), MemoryManager.StringToByteArray(BoneLoader.VieraEar02ALeft.Replace(" ", string.Empty)));
                        }
                    }
                    if (BoneLoader.HrothLipLower != "null" || BoneLoader.VieraEar02ARight != "null")
                    {
                        if (CharacterDetails.Race.value == 7)
                        {
                            if (BoneLoader.Race == "07")
                            {
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothLipLower_Bone), MemoryManager.StringToByteArray(BoneLoader.HrothLipLower.Replace(" ", string.Empty)));
                            }
                        }
                        if (CharacterDetails.Race.value == 8)
                        {
                            if (BoneLoader.Race == "08")
                            {
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar02ARight_Bone), MemoryManager.StringToByteArray(BoneLoader.VieraEar02ARight.Replace(" ", string.Empty)));
                            }
                        }
                    }
                    if (BoneLoader.VieraEar03ALeft != "null")
                    {
                        if (CharacterDetails.Race.value < 7)
                        {
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipLowerA_Bone), MemoryManager.StringToByteArray(BoneLoader.VieraLipLowerA.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipUpperB_Bone), MemoryManager.StringToByteArray(BoneLoader.VieraLipUpperB.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipLowerB_Bone), MemoryManager.StringToByteArray(BoneLoader.VieraLipLowerB.Replace(" ", string.Empty)));
                        }
                        if (CharacterDetails.Race.value == 8)
                        {
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar03ALeft_Bone), MemoryManager.StringToByteArray(BoneLoader.VieraEar03ALeft.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar03ARight_Bone), MemoryManager.StringToByteArray(BoneLoader.VieraEar03ARight.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar04ALeft_Bone), MemoryManager.StringToByteArray(BoneLoader.VieraEar04ALeft.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar04ARight_Bone), MemoryManager.StringToByteArray(BoneLoader.VieraEar04ARight.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraLipLowerA_Bone), MemoryManager.StringToByteArray(BoneLoader.VieraLipLowerA.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraLipUpperB_Bone), MemoryManager.StringToByteArray(BoneLoader.VieraLipUpperB.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar01BLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.VieraEar01BLeft.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar01BRight_Bone), MemoryManager.StringToByteArray(BoneLoader.VieraEar01BRight.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar02BLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.VieraEar02BLeft.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar02BRight_Bone), MemoryManager.StringToByteArray(BoneLoader.VieraEar02BRight.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar03BLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.VieraEar03BLeft.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar03BRight_Bone), MemoryManager.StringToByteArray(BoneLoader.VieraEar03BRight.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar04BLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.VieraEar04BLeft.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar04BRight_Bone), MemoryManager.StringToByteArray(BoneLoader.VieraEar04BRight.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraLipLowerB_Bone), MemoryManager.StringToByteArray(BoneLoader.VieraLipLowerB.Replace(" ", string.Empty)));
                        }
                    }
                    #endregion
                    #region Hair
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HairA_Bone), MemoryManager.StringToByteArray(BoneLoader.HairA.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HairFrontLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.HairFrontLeft.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HairFrontRight_Bone), MemoryManager.StringToByteArray(BoneLoader.HairFrontRight.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HairB_Bone), MemoryManager.StringToByteArray(BoneLoader.HairB.Replace(" ", string.Empty)));
                    var HairValue = m.readByte(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExHair_Value));

                    if (HairValue >= 2)
                    {
                        if (BoneLoader.ExHairA != "null")
                        {
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExHairA_Bone), MemoryManager.StringToByteArray(BoneLoader.ExHairA.Replace(" ", string.Empty)));
                        }
                    }
                    if (HairValue >= 3)
                    {
                        if (BoneLoader.ExHairB != "null")
                        {
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExHairB_Bone), MemoryManager.StringToByteArray(BoneLoader.ExHairB.Replace(" ", string.Empty)));
                        }
                    }
                    if (HairValue >= 4)
                    {
                        if (BoneLoader.ExHairC != "null")
                        {
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExHairC_Bone), MemoryManager.StringToByteArray(BoneLoader.ExHairC.Replace(" ", string.Empty)));
                        }
                    }
                    if (HairValue >= 5)
                    {
                        if (BoneLoader.ExHairD != "null")
                        {
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExHairD_Bone), MemoryManager.StringToByteArray(BoneLoader.ExHairD.Replace(" ", string.Empty)));
                        }
                    }
                    if (HairValue >= 6)
                    {
                        if (BoneLoader.ExHairE != "null")
                        {
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExHairE_Bone), MemoryManager.StringToByteArray(BoneLoader.ExHairE.Replace(" ", string.Empty)));
                        }
                    }
                    if (HairValue >= 7)
                    {
                        if (BoneLoader.ExHairF != "null")
                        {
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExHairF_Bone), MemoryManager.StringToByteArray(BoneLoader.ExHairF.Replace(" ", string.Empty)));
                        }
                    }
                    if (HairValue >= 8)
                    {
                        if (BoneLoader.ExHairG != "null")
                        {
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExHairG_Bone), MemoryManager.StringToByteArray(BoneLoader.ExHairG.Replace(" ", string.Empty)));
                        }
                    }
                    if (HairValue >= 9)
                    {
                        if (BoneLoader.ExHairH != "null")
                        {
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExHairH_Bone), MemoryManager.StringToByteArray(BoneLoader.ExHairH.Replace(" ", string.Empty)));
                        }
                    }
                    if (HairValue >= 10)
                    {
                        if (BoneLoader.ExHairI != "null")
                        {
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExHairI_Bone), MemoryManager.StringToByteArray(BoneLoader.ExHairI.Replace(" ", string.Empty)));
                        }
                    }
                    if (HairValue >= 11)
                    {
                        if (BoneLoader.ExHairJ != "null")
                        {
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExHairJ_Bone), MemoryManager.StringToByteArray(BoneLoader.ExHairJ.Replace(" ", string.Empty)));
                        }
                    }
                    if (HairValue >= 12)
                    {
                        if (BoneLoader.ExHairK != "null")
                        {
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExHairK_Bone), MemoryManager.StringToByteArray(BoneLoader.ExHairK.Replace(" ", string.Empty)));
                        }
                    }
                    if (HairValue >= 13)
                    {
                        if (BoneLoader.ExHairL != "null")
                        {
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExHairL_Bone), MemoryManager.StringToByteArray(BoneLoader.ExHairL.Replace(" ", string.Empty)));
                        }
                    }
                    #endregion
                    #region Earrings
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EarringALeft_Bone), MemoryManager.StringToByteArray(BoneLoader.EarringALeft.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EarringARight_Bone), MemoryManager.StringToByteArray(BoneLoader.EarringARight.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EarringBLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.EarringBLeft.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EarringBRight_Bone), MemoryManager.StringToByteArray(BoneLoader.EarringBRight.Replace(" ", string.Empty)));
                    #endregion
                    #region Body
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.SpineA_Bone), MemoryManager.StringToByteArray(BoneLoader.SpineA.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.SpineB_Bone), MemoryManager.StringToByteArray(BoneLoader.SpineB.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.BreastLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.BreastLeft.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.BreastRight_Bone), MemoryManager.StringToByteArray(BoneLoader.BreastRight.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.SpineC_Bone), MemoryManager.StringToByteArray(BoneLoader.SpineC.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ScabbardLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.ScabbardLeft.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ScabbardRight_Bone), MemoryManager.StringToByteArray(BoneLoader.ScabbardRight.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.Neck_Bone), MemoryManager.StringToByteArray(BoneLoader.Neck.Replace(" ", string.Empty)));
                    #endregion
                    #region LeftArm
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClavicleLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.ClavicleLeft.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ArmLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.ArmLeft.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.PauldronLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.PauldronLeft.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ForearmLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.ForearmLeft.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ShoulderLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.ShoulderLeft.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ShieldLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.ShieldLeft.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ElbowLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.ElbowLeft.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.CouterLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.CouterLeft.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.WristLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.WristLeft.Replace(" ", string.Empty)));
                    #endregion
                    #region RightArm
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClavicleRight_Bone), MemoryManager.StringToByteArray(BoneLoader.ClavicleRight.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ArmRight_Bone), MemoryManager.StringToByteArray(BoneLoader.ArmRight.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.PauldronRight_Bone), MemoryManager.StringToByteArray(BoneLoader.PauldronRight.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ForearmRight_Bone), MemoryManager.StringToByteArray(BoneLoader.ForearmRight.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ShoulderRight_Bone), MemoryManager.StringToByteArray(BoneLoader.ShoulderRight.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ShieldRight_Bone), MemoryManager.StringToByteArray(BoneLoader.ShieldRight.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ElbowRight_Bone), MemoryManager.StringToByteArray(BoneLoader.ElbowRight.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.CouterRight_Bone), MemoryManager.StringToByteArray(BoneLoader.CouterRight.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.WristRight_Bone), MemoryManager.StringToByteArray(BoneLoader.WristRight.Replace(" ", string.Empty)));
                    #endregion
                    #region Clothes
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothBackALeft_Bone), MemoryManager.StringToByteArray(BoneLoader.ClothBackALeft.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothBackARight_Bone), MemoryManager.StringToByteArray(BoneLoader.ClothBackARight.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothFrontALeft_Bone), MemoryManager.StringToByteArray(BoneLoader.ClothFrontALeft.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothFrontARight_Bone), MemoryManager.StringToByteArray(BoneLoader.ClothFrontARight.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothSideALeft_Bone), MemoryManager.StringToByteArray(BoneLoader.ClothSideALeft.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothSideARight_Bone), MemoryManager.StringToByteArray(BoneLoader.ClothSideARight.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothBackBLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.ClothBackBLeft.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothBackBRight_Bone), MemoryManager.StringToByteArray(BoneLoader.ClothBackBRight.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothFrontBLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.ClothFrontBLeft.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothFrontBRight_Bone), MemoryManager.StringToByteArray(BoneLoader.ClothFrontBRight.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothSideBLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.ClothSideBLeft.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothSideBRight_Bone), MemoryManager.StringToByteArray(BoneLoader.ClothSideBRight.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothBackCLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.ClothBackCLeft.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothBackCRight_Bone), MemoryManager.StringToByteArray(BoneLoader.ClothBackCRight.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothFrontCLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.ClothFrontCLeft.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothFrontCRight_Bone), MemoryManager.StringToByteArray(BoneLoader.ClothFrontCRight.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothSideCLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.ClothSideCLeft.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothSideCRight_Bone), MemoryManager.StringToByteArray(BoneLoader.ClothSideCRight.Replace(" ", string.Empty)));
                    #endregion
                    #region Weapons
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.WeaponLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.WeaponLeft.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.WeaponRight_Bone), MemoryManager.StringToByteArray(BoneLoader.WeaponRight.Replace(" ", string.Empty)));
                    #endregion
                    #region LeftHand
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HandLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.HandLeft.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.IndexALeft_Bone), MemoryManager.StringToByteArray(BoneLoader.IndexALeft.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.PinkyALeft_Bone), MemoryManager.StringToByteArray(BoneLoader.PinkyALeft.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.RingALeft_Bone), MemoryManager.StringToByteArray(BoneLoader.RingALeft.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.MiddleALeft_Bone), MemoryManager.StringToByteArray(BoneLoader.MiddleALeft.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ThumbALeft_Bone), MemoryManager.StringToByteArray(BoneLoader.ThumbALeft.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.IndexBLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.IndexBLeft.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.PinkyBLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.PinkyBLeft.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.RingBLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.RingBLeft.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.MiddleBLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.MiddleBLeft.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ThumbBLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.ThumbBLeft.Replace(" ", string.Empty)));
                    #endregion
                    #region RightHand
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HandRight_Bone), MemoryManager.StringToByteArray(BoneLoader.HandRight.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.IndexARight_Bone), MemoryManager.StringToByteArray(BoneLoader.IndexARight.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.PinkyARight_Bone), MemoryManager.StringToByteArray(BoneLoader.PinkyARight.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.RingARight_Bone), MemoryManager.StringToByteArray(BoneLoader.RingARight.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.MiddleARight_Bone), MemoryManager.StringToByteArray(BoneLoader.MiddleARight.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ThumbARight_Bone), MemoryManager.StringToByteArray(BoneLoader.ThumbARight.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.IndexBRight_Bone), MemoryManager.StringToByteArray(BoneLoader.IndexBRight.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.PinkyBRight_Bone), MemoryManager.StringToByteArray(BoneLoader.PinkyBRight.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.RingBRight_Bone), MemoryManager.StringToByteArray(BoneLoader.RingBRight.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.MiddleBRight_Bone), MemoryManager.StringToByteArray(BoneLoader.MiddleBRight.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ThumbBRight_Bone), MemoryManager.StringToByteArray(BoneLoader.ThumbBRight.Replace(" ", string.Empty)));
                    #endregion
                    #region Waist
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.Waist_Bone), MemoryManager.StringToByteArray(BoneLoader.Waist.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HolsterLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.HolsterLeft.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HolsterRight_Bone), MemoryManager.StringToByteArray(BoneLoader.HolsterRight.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.SheatheLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.SheatheLeft.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.SheatheRight_Bone), MemoryManager.StringToByteArray(BoneLoader.SheatheRight.Replace(" ", string.Empty)));
                    if (BoneLoader.TailA != "null")
                    {
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.TailA_Bone), MemoryManager.StringToByteArray(BoneLoader.TailA.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.TailB_Bone), MemoryManager.StringToByteArray(BoneLoader.TailB.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.TailC_Bone), MemoryManager.StringToByteArray(BoneLoader.TailC.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.TailD_Bone), MemoryManager.StringToByteArray(BoneLoader.TailD.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.TailE_Bone), MemoryManager.StringToByteArray(BoneLoader.TailE.Replace(" ", string.Empty)));
                    }
                    #endregion
                    #region LeftLeg
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LegsLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.LegLeft.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.KneeLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.KneeLeft.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.CalfLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.CalfLeft.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.PoleynLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.PoleynLeft.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.FootLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.FootLeft.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ToesLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.ToesLeft.Replace(" ", string.Empty)));
                    #endregion
                    #region RightLeg
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LegsRight_Bone), MemoryManager.StringToByteArray(BoneLoader.LegRight.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.KneeRight_Bone), MemoryManager.StringToByteArray(BoneLoader.KneeRight.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.CalfRight_Bone), MemoryManager.StringToByteArray(BoneLoader.CalfRight.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.PoleynRight_Bone), MemoryManager.StringToByteArray(BoneLoader.PoleynRight.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.FootRight_Bone), MemoryManager.StringToByteArray(BoneLoader.FootRight.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ToesRight_Bone), MemoryManager.StringToByteArray(BoneLoader.ToesRight.Replace(" ", string.Empty)));
                    #endregion
                    #region Helm
                    var HelmValue = m.readByte(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMet_Value));


                    if (HelmValue >= 2)
                    {
                        if (BoneLoader.ExMetA != "null")
                        {
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetA_Bone), MemoryManager.StringToByteArray(BoneLoader.ExMetA.Replace(" ", string.Empty)));
                        }
                    }
                    if (HelmValue >= 3)
                    {
                        if (BoneLoader.ExMetB != "null")
                        {
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetB_Bone), MemoryManager.StringToByteArray(BoneLoader.ExMetB.Replace(" ", string.Empty)));
                        }
                    }
                    if (HelmValue >= 4)
                    {
                        if (BoneLoader.ExMetC != "null")
                        {
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetC_Bone), MemoryManager.StringToByteArray(BoneLoader.ExMetC.Replace(" ", string.Empty)));
                        }
                    }
                    if (HelmValue >= 5)
                    {
                        if (BoneLoader.ExMetD != "null")
                        {
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetD_Bone), MemoryManager.StringToByteArray(BoneLoader.ExMetD.Replace(" ", string.Empty)));
                        }
                    }
                    if (HelmValue >= 6)
                    {
                        if (BoneLoader.ExMetE != "null")
                        {
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetE_Bone), MemoryManager.StringToByteArray(BoneLoader.ExMetE.Replace(" ", string.Empty)));
                        }
                    }
                    if (HelmValue >= 7)
                    {
                        if (BoneLoader.ExMetF != "null")
                        {
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetF_Bone), MemoryManager.StringToByteArray(BoneLoader.ExMetF.Replace(" ", string.Empty)));
                        }
                    }
                    if (HelmValue >= 8)
                    {
                        if (BoneLoader.ExMetG != "null")
                        {
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetG_Bone), MemoryManager.StringToByteArray(BoneLoader.ExMetG.Replace(" ", string.Empty)));
                        }
                    }
                    if (HelmValue >= 9)
                    {
                        if (BoneLoader.ExMetH != "null")
                        {
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetH_Bone), MemoryManager.StringToByteArray(BoneLoader.ExMetH.Replace(" ", string.Empty)));
                        }
                    }
                    if (HelmValue >= 10)
                    {
                        if (BoneLoader.ExMetI != "null")
                        {
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetI_Bone), MemoryManager.StringToByteArray(BoneLoader.ExMetI.Replace(" ", string.Empty)));
                        }
                    }
                    if (HelmValue >= 11)
                    {
                        if (BoneLoader.ExMetJ != "null")
                        {
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetJ_Bone), MemoryManager.StringToByteArray(BoneLoader.ExMetJ.Replace(" ", string.Empty)));
                        }
                    }
                    if (HelmValue >= 12)
                    {
                        if (BoneLoader.ExMetK != "null")
                        {
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetK_Bone), MemoryManager.StringToByteArray(BoneLoader.ExMetK.Replace(" ", string.Empty)));
                        }
                    }
                    if (HelmValue >= 13)
                    {
                        if (BoneLoader.ExMetL != "null")
                        {
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetL_Bone), MemoryManager.StringToByteArray(BoneLoader.ExMetL.Replace(" ", string.Empty)));
                        }
                    }
                    if (HelmValue >= 14)
                    {
                        if (BoneLoader.ExMetM != "null")
                        {
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetM_Bone), MemoryManager.StringToByteArray(BoneLoader.ExMetM.Replace(" ", string.Empty)));
                        }
                    }
                    if (HelmValue >= 15)
                    {
                        if (BoneLoader.ExMetN != "null")
                        {
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetN_Bone), MemoryManager.StringToByteArray(BoneLoader.ExMetN.Replace(" ", string.Empty)));
                        }
                    }
                    if (HelmValue >= 16)
                    {
                        if (BoneLoader.ExMetO != "null")
                        {
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetO_Bone), MemoryManager.StringToByteArray(BoneLoader.ExMetO.Replace(" ", string.Empty)));
                        }
                    }
                    if (HelmValue >= 17)
                    {
                        if (BoneLoader.ExMetP != "null")
                        {
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetP_Bone), MemoryManager.StringToByteArray(BoneLoader.ExMetP.Replace(" ", string.Empty)));
                        }
                    }
                    if (HelmValue >= 18)
                    {
                        if (BoneLoader.ExMetQ != "null")
                        {
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetQ_Bone), MemoryManager.StringToByteArray(BoneLoader.ExMetQ.Replace(" ", string.Empty)));
                        }
                    }
                    if (HelmValue >= 19)
                    {
                        if (BoneLoader.ExMetR != "null")
                        {
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetR_Bone), MemoryManager.StringToByteArray(BoneLoader.ExMetR.Replace(" ", string.Empty)));
                        }
                    }
                    #endregion
                    #region Top
                    var TopValue = m.readByte(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExTop_Value));

                    if (TopValue >= 2)
                    {
                        if (BoneLoader.ExTopA != "null")
                        {
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExTopA_Bone), MemoryManager.StringToByteArray(BoneLoader.ExTopA.Replace(" ", string.Empty)));
                        }
                    }
                    if (TopValue >= 3)
                    {
                        if (BoneLoader.ExTopB != "null")
                        {
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExTopB_Bone), MemoryManager.StringToByteArray(BoneLoader.ExTopB.Replace(" ", string.Empty)));
                        }
                    }
                    if (TopValue >= 4)
                    {
                        if (BoneLoader.ExTopC != "null")
                        {
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExTopC_Bone), MemoryManager.StringToByteArray(BoneLoader.ExTopC.Replace(" ", string.Empty)));
                        }
                    }
                    if (TopValue >= 5)
                    {
                        if (BoneLoader.ExTopD != "null")
                        {
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExTopD_Bone), MemoryManager.StringToByteArray(BoneLoader.ExTopD.Replace(" ", string.Empty)));
                        }
                    }
                    if (TopValue >= 6)
                    {
                        if (BoneLoader.ExTopE != "null")
                        {
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExTopE_Bone), MemoryManager.StringToByteArray(BoneLoader.ExTopE.Replace(" ", string.Empty)));
                        }
                    }
                    if (TopValue >= 7)
                    {
                        if (BoneLoader.ExTopF != "null")
                        {
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExTopF_Bone), MemoryManager.StringToByteArray(BoneLoader.ExTopF.Replace(" ", string.Empty)));
                        }
                    }
                    if (TopValue >= 8)
                    {
                        if (BoneLoader.ExTopG != "null")
                        {
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExTopG_Bone), MemoryManager.StringToByteArray(BoneLoader.ExTopG.Replace(" ", string.Empty)));
                        }
                    }
                    if (TopValue >= 9)
                    {
                        if (BoneLoader.ExTopH != "null")
                        {
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExTopH_Bone), MemoryManager.StringToByteArray(BoneLoader.ExTopH.Replace(" ", string.Empty)));
                        }
                    }
                    if (TopValue >= 10)
                    {
                        if (BoneLoader.ExTopI != "null")
                        {
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExTopI_Bone), MemoryManager.StringToByteArray(BoneLoader.ExTopI.Replace(" ", string.Empty)));
                        }
                    }
                    #endregion

                    #region ScaleBones
                    if (BoneLoader.CMPVersion == "2.0")
                    {
                        if (ScaleSaveToggle.IsChecked == true)
                        {
                            #region Head
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.Head_Size), MemoryManager.StringToByteArray(BoneLoader.HeadSize.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EarLeft_Size), MemoryManager.StringToByteArray(BoneLoader.EarLeftSize.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EarRight_Size), MemoryManager.StringToByteArray(BoneLoader.EarRightSize.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.Jaw_Size), MemoryManager.StringToByteArray(BoneLoader.JawSize.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyelidLowerLeft_Size), MemoryManager.StringToByteArray(BoneLoader.EyelidLowerLeftSize.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyelidLowerRight_Size), MemoryManager.StringToByteArray(BoneLoader.EyelidLowerRightSize.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyeLeft_Size), MemoryManager.StringToByteArray(BoneLoader.EyeLeftSize.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyeRight_Size), MemoryManager.StringToByteArray(BoneLoader.EyeRightSize.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.Nose_Size), MemoryManager.StringToByteArray(BoneLoader.NoseSize.Replace(" ", string.Empty)));
                            if (CharacterDetails.Race.value < 7)
                            {
                                if (BoneLoader.Race == "01" || BoneLoader.Race == "02" || BoneLoader.Race == "03" || BoneLoader.Race == "04" || BoneLoader.Race == "05" || BoneLoader.Race == "06")
                                {
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.CheekLeft_Size), MemoryManager.StringToByteArray(BoneLoader.CheekLeftSize.Replace(" ", string.Empty)));
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.CheekRight_Size), MemoryManager.StringToByteArray(BoneLoader.CheekRightSize.Replace(" ", string.Empty)));
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipsLeft_Size), MemoryManager.StringToByteArray(BoneLoader.LipsLeftSize.Replace(" ", string.Empty)));
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipsRight_Size), MemoryManager.StringToByteArray(BoneLoader.LipsRightSize.Replace(" ", string.Empty)));
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyebrowLeft_Size), MemoryManager.StringToByteArray(BoneLoader.EyebrowLeftSize.Replace(" ", string.Empty)));
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyebrowRight_Size), MemoryManager.StringToByteArray(BoneLoader.EyebrowRightSize.Replace(" ", string.Empty)));
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.Bridge_Size), MemoryManager.StringToByteArray(BoneLoader.BridgeSize.Replace(" ", string.Empty)));
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.BrowLeft_Size), MemoryManager.StringToByteArray(BoneLoader.BrowLeftSize.Replace(" ", string.Empty)));
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.BrowRight_Size), MemoryManager.StringToByteArray(BoneLoader.BrowRightSize.Replace(" ", string.Empty)));
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipUpperA_Size), MemoryManager.StringToByteArray(BoneLoader.LipUpperASize.Replace(" ", string.Empty)));
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyelidUpperLeft_Size), MemoryManager.StringToByteArray(BoneLoader.EyelidUpperLeftSize.Replace(" ", string.Empty)));
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyelidUpperRight_Size), MemoryManager.StringToByteArray(BoneLoader.EyelidUpperRightSize.Replace(" ", string.Empty)));
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipLowerA_Size), MemoryManager.StringToByteArray(BoneLoader.LipLowerASize.Replace(" ", string.Empty)));
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipUpperB_Size), MemoryManager.StringToByteArray(BoneLoader.LipUpperBSize.Replace(" ", string.Empty)));
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipLowerB_Size), MemoryManager.StringToByteArray(BoneLoader.LipLowerBSize.Replace(" ", string.Empty)));
                                }
                                if (BoneLoader.Race == "07")
                                {
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.CheekLeft_Size), MemoryManager.StringToByteArray(BoneLoader.HrothLipUpperLeftSize.Replace(" ", string.Empty)));
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.CheekRight_Size), MemoryManager.StringToByteArray(BoneLoader.HrothLipUpperRightSize.Replace(" ", string.Empty)));
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipsLeft_Size), MemoryManager.StringToByteArray(BoneLoader.HrothLipsLeftSize.Replace(" ", string.Empty)));
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipsRight_Size), MemoryManager.StringToByteArray(BoneLoader.HrothLipsRightSize.Replace(" ", string.Empty)));
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyebrowLeft_Size), MemoryManager.StringToByteArray(BoneLoader.HrothEyebrowLeftSize.Replace(" ", string.Empty)));
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyebrowRight_Size), MemoryManager.StringToByteArray(BoneLoader.HrothEyebrowRightSize.Replace(" ", string.Empty)));
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.Bridge_Size), MemoryManager.StringToByteArray(BoneLoader.HrothBridgeSize.Replace(" ", string.Empty)));
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.BrowLeft_Size), MemoryManager.StringToByteArray(BoneLoader.HrothBrowLeftSize.Replace(" ", string.Empty)));
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.BrowRight_Size), MemoryManager.StringToByteArray(BoneLoader.HrothBrowRightSize.Replace(" ", string.Empty)));
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipUpperA_Size), MemoryManager.StringToByteArray(BoneLoader.HrothLipUpperSize.Replace(" ", string.Empty)));
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyelidUpperLeft_Size), MemoryManager.StringToByteArray(BoneLoader.HrothEyelidUpperLeftSize.Replace(" ", string.Empty)));
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyelidUpperRight_Size), MemoryManager.StringToByteArray(BoneLoader.HrothEyelidUpperRightSize.Replace(" ", string.Empty)));
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipUpperB_Size), MemoryManager.StringToByteArray(BoneLoader.HrothJawUpperSize.Replace(" ", string.Empty)));
                                }
                                if (BoneLoader.Race == "08")
                                {
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.CheekLeft_Size), MemoryManager.StringToByteArray(BoneLoader.CheekLeftSize.Replace(" ", string.Empty)));
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.CheekRight_Size), MemoryManager.StringToByteArray(BoneLoader.CheekRightSize.Replace(" ", string.Empty)));
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipsLeft_Size), MemoryManager.StringToByteArray(BoneLoader.LipsLeftSize.Replace(" ", string.Empty)));
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipsRight_Size), MemoryManager.StringToByteArray(BoneLoader.LipsRightSize.Replace(" ", string.Empty)));
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyebrowLeft_Size), MemoryManager.StringToByteArray(BoneLoader.EyebrowLeftSize.Replace(" ", string.Empty)));
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyebrowRight_Size), MemoryManager.StringToByteArray(BoneLoader.EyebrowRightSize.Replace(" ", string.Empty)));
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.Bridge_Size), MemoryManager.StringToByteArray(BoneLoader.BridgeSize.Replace(" ", string.Empty)));
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.BrowLeft_Size), MemoryManager.StringToByteArray(BoneLoader.BrowLeftSize.Replace(" ", string.Empty)));
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.BrowRight_Size), MemoryManager.StringToByteArray(BoneLoader.BrowRightSize.Replace(" ", string.Empty)));
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipUpperA_Size), MemoryManager.StringToByteArray(BoneLoader.LipUpperASize.Replace(" ", string.Empty)));
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyelidUpperLeft_Size), MemoryManager.StringToByteArray(BoneLoader.EyelidUpperLeftSize.Replace(" ", string.Empty)));
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyelidUpperRight_Size), MemoryManager.StringToByteArray(BoneLoader.EyelidUpperRightSize.Replace(" ", string.Empty)));
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipLowerA_Size), MemoryManager.StringToByteArray(BoneLoader.VieraLipLowerASize.Replace(" ", string.Empty)));
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipUpperB_Size), MemoryManager.StringToByteArray(BoneLoader.VieraLipUpperBSize.Replace(" ", string.Empty)));
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipLowerB_Size), MemoryManager.StringToByteArray(BoneLoader.VieraLipLowerBSize.Replace(" ", string.Empty)));
                                }
                            }
                            if (CharacterDetails.Race.value == 7)
                            {
                                if (BoneLoader.Race == "01" || BoneLoader.Race == "02" || BoneLoader.Race == "03" || BoneLoader.Race == "04" || BoneLoader.Race == "05" || BoneLoader.Race == "06")
                                {
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothEyebrowLeft_Size), MemoryManager.StringToByteArray(BoneLoader.EyebrowLeftSize.Replace(" ", string.Empty)));
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothEyebrowRight_Size), MemoryManager.StringToByteArray(BoneLoader.EyebrowRightSize.Replace(" ", string.Empty)));
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothBridge_Size), MemoryManager.StringToByteArray(BoneLoader.BridgeSize.Replace(" ", string.Empty)));
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothBrowLeft_Size), MemoryManager.StringToByteArray(BoneLoader.BrowLeftSize.Replace(" ", string.Empty)));
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothBrowRight_Size), MemoryManager.StringToByteArray(BoneLoader.BrowRightSize.Replace(" ", string.Empty)));
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothJawUpper_Size), MemoryManager.StringToByteArray(BoneLoader.LipUpperBSize.Replace(" ", string.Empty)));
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothLipUpper_Size), MemoryManager.StringToByteArray(BoneLoader.LipUpperASize.Replace(" ", string.Empty)));
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothEyelidUpperLeft_Size), MemoryManager.StringToByteArray(BoneLoader.EyelidUpperLeftSize.Replace(" ", string.Empty)));
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothEyelidUpperRight_Size), MemoryManager.StringToByteArray(BoneLoader.EyelidUpperRightSize.Replace(" ", string.Empty)));
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothLipsLeft_Size), MemoryManager.StringToByteArray(BoneLoader.LipsLeftSize.Replace(" ", string.Empty)));
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothLipsRight_Size), MemoryManager.StringToByteArray(BoneLoader.LipsRightSize.Replace(" ", string.Empty)));
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothLipUpperLeft_Size), MemoryManager.StringToByteArray(BoneLoader.CheekLeftSize.Replace(" ", string.Empty)));
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothLipUpperRight_Size), MemoryManager.StringToByteArray(BoneLoader.CheekRightSize.Replace(" ", string.Empty)));
                                }
                                if (BoneLoader.Race == "07")
                                {
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothWhiskersLeft_Size), MemoryManager.StringToByteArray(BoneLoader.HrothWhiskersLeftSize.Replace(" ", string.Empty)));
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothWhiskersRight_Size), MemoryManager.StringToByteArray(BoneLoader.HrothWhiskersRightSize.Replace(" ", string.Empty)));
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothEyebrowLeft_Size), MemoryManager.StringToByteArray(BoneLoader.HrothEyebrowLeftSize.Replace(" ", string.Empty)));
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothEyebrowRight_Size), MemoryManager.StringToByteArray(BoneLoader.HrothEyebrowRightSize.Replace(" ", string.Empty)));
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothBridge_Size), MemoryManager.StringToByteArray(BoneLoader.HrothBridgeSize.Replace(" ", string.Empty)));
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothBrowLeft_Size), MemoryManager.StringToByteArray(BoneLoader.HrothBrowLeftSize.Replace(" ", string.Empty)));
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothBrowRight_Size), MemoryManager.StringToByteArray(BoneLoader.HrothBrowRightSize.Replace(" ", string.Empty)));
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothJawUpper_Size), MemoryManager.StringToByteArray(BoneLoader.HrothJawUpperSize.Replace(" ", string.Empty)));
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothLipUpper_Size), MemoryManager.StringToByteArray(BoneLoader.HrothLipUpperSize.Replace(" ", string.Empty)));
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothEyelidUpperLeft_Size), MemoryManager.StringToByteArray(BoneLoader.HrothEyelidUpperLeftSize.Replace(" ", string.Empty)));
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothEyelidUpperRight_Size), MemoryManager.StringToByteArray(BoneLoader.HrothEyelidUpperRightSize.Replace(" ", string.Empty)));
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothLipsLeft_Size), MemoryManager.StringToByteArray(BoneLoader.HrothLipsLeftSize.Replace(" ", string.Empty)));
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothLipsRight_Size), MemoryManager.StringToByteArray(BoneLoader.HrothLipsRightSize.Replace(" ", string.Empty)));
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothLipUpperLeft_Size), MemoryManager.StringToByteArray(BoneLoader.HrothLipUpperLeftSize.Replace(" ", string.Empty)));
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothLipUpperRight_Size), MemoryManager.StringToByteArray(BoneLoader.HrothLipUpperRightSize.Replace(" ", string.Empty)));
                                }
                                if (BoneLoader.Race == "08")
                                {
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothEyebrowLeft_Size), MemoryManager.StringToByteArray(BoneLoader.EyebrowLeftSize.Replace(" ", string.Empty)));
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothEyebrowRight_Size), MemoryManager.StringToByteArray(BoneLoader.EyebrowRightSize.Replace(" ", string.Empty)));
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothBridge_Size), MemoryManager.StringToByteArray(BoneLoader.BridgeSize.Replace(" ", string.Empty)));
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothBrowLeft_Size), MemoryManager.StringToByteArray(BoneLoader.BrowLeftSize.Replace(" ", string.Empty)));
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothBrowRight_Size), MemoryManager.StringToByteArray(BoneLoader.BrowRightSize.Replace(" ", string.Empty)));
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothJawUpper_Size), MemoryManager.StringToByteArray(BoneLoader.VieraLipUpperBSize.Replace(" ", string.Empty)));
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothLipUpper_Size), MemoryManager.StringToByteArray(BoneLoader.LipUpperASize.Replace(" ", string.Empty)));
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothEyelidUpperLeft_Size), MemoryManager.StringToByteArray(BoneLoader.EyelidUpperLeftSize.Replace(" ", string.Empty)));
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothEyelidUpperRight_Size), MemoryManager.StringToByteArray(BoneLoader.EyelidUpperRightSize.Replace(" ", string.Empty)));
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothLipsLeft_Size), MemoryManager.StringToByteArray(BoneLoader.LipsLeftSize.Replace(" ", string.Empty)));
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothLipsRight_Size), MemoryManager.StringToByteArray(BoneLoader.LipsRightSize.Replace(" ", string.Empty)));
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothLipUpperLeft_Size), MemoryManager.StringToByteArray(BoneLoader.CheekLeftSize.Replace(" ", string.Empty)));
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothLipUpperRight_Size), MemoryManager.StringToByteArray(BoneLoader.CheekRightSize.Replace(" ", string.Empty)));
                                }
                            }
                            if (CharacterDetails.Race.value == 8)
                            {
                                if (BoneLoader.Race == "01" || BoneLoader.Race == "02" || BoneLoader.Race == "03" || BoneLoader.Race == "04" || BoneLoader.Race == "05" || BoneLoader.Race == "06")
                                {
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.CheekLeft_Size), MemoryManager.StringToByteArray(BoneLoader.CheekLeftSize.Replace(" ", string.Empty)));
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.CheekRight_Size), MemoryManager.StringToByteArray(BoneLoader.CheekRightSize.Replace(" ", string.Empty)));
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipsLeft_Size), MemoryManager.StringToByteArray(BoneLoader.LipsLeftSize.Replace(" ", string.Empty)));
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipsRight_Size), MemoryManager.StringToByteArray(BoneLoader.LipsRightSize.Replace(" ", string.Empty)));
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyebrowLeft_Size), MemoryManager.StringToByteArray(BoneLoader.EyebrowLeftSize.Replace(" ", string.Empty)));
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyebrowRight_Size), MemoryManager.StringToByteArray(BoneLoader.EyebrowRightSize.Replace(" ", string.Empty)));
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.Bridge_Size), MemoryManager.StringToByteArray(BoneLoader.BridgeSize.Replace(" ", string.Empty)));
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.BrowLeft_Size), MemoryManager.StringToByteArray(BoneLoader.BrowLeftSize.Replace(" ", string.Empty)));
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.BrowRight_Size), MemoryManager.StringToByteArray(BoneLoader.BrowRightSize.Replace(" ", string.Empty)));
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipUpperA_Size), MemoryManager.StringToByteArray(BoneLoader.LipUpperASize.Replace(" ", string.Empty)));
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyelidUpperLeft_Size), MemoryManager.StringToByteArray(BoneLoader.EyelidUpperLeftSize.Replace(" ", string.Empty)));
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyelidUpperRight_Size), MemoryManager.StringToByteArray(BoneLoader.EyelidUpperRightSize.Replace(" ", string.Empty)));
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraLipLowerA_Size), MemoryManager.StringToByteArray(BoneLoader.VieraEar01ALeftSize.Replace(" ", string.Empty)));
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraLipUpperB_Size), MemoryManager.StringToByteArray(BoneLoader.VieraEar01ARightSize.Replace(" ", string.Empty)));
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraLipLowerB_Size), MemoryManager.StringToByteArray(BoneLoader.VieraEar02ALeftSize.Replace(" ", string.Empty)));
                                }
                                if (BoneLoader.Race == "07")
                                {
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.CheekLeft_Size), MemoryManager.StringToByteArray(BoneLoader.HrothLipUpperLeftSize.Replace(" ", string.Empty)));
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.CheekRight_Size), MemoryManager.StringToByteArray(BoneLoader.HrothLipUpperRightSize.Replace(" ", string.Empty)));
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipsLeft_Size), MemoryManager.StringToByteArray(BoneLoader.HrothLipsLeftSize.Replace(" ", string.Empty)));
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipsRight_Size), MemoryManager.StringToByteArray(BoneLoader.HrothLipsRightSize.Replace(" ", string.Empty)));
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyebrowLeft_Size), MemoryManager.StringToByteArray(BoneLoader.HrothEyebrowLeftSize.Replace(" ", string.Empty)));
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyebrowRight_Size), MemoryManager.StringToByteArray(BoneLoader.HrothEyebrowRightSize.Replace(" ", string.Empty)));
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.Bridge_Size), MemoryManager.StringToByteArray(BoneLoader.HrothBridgeSize.Replace(" ", string.Empty)));
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.BrowLeft_Size), MemoryManager.StringToByteArray(BoneLoader.HrothBrowLeftSize.Replace(" ", string.Empty)));
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.BrowRight_Size), MemoryManager.StringToByteArray(BoneLoader.HrothBrowRightSize.Replace(" ", string.Empty)));
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipUpperA_Size), MemoryManager.StringToByteArray(BoneLoader.HrothLipUpperSize.Replace(" ", string.Empty)));
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyelidUpperLeft_Size), MemoryManager.StringToByteArray(BoneLoader.HrothEyelidUpperLeftSize.Replace(" ", string.Empty)));
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyelidUpperRight_Size), MemoryManager.StringToByteArray(BoneLoader.HrothEyelidUpperRightSize.Replace(" ", string.Empty)));
                                }
                                if (BoneLoader.Race == "08")
                                {
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.CheekLeft_Size), MemoryManager.StringToByteArray(BoneLoader.CheekLeftSize.Replace(" ", string.Empty)));
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.CheekRight_Size), MemoryManager.StringToByteArray(BoneLoader.CheekRightSize.Replace(" ", string.Empty)));
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipsLeft_Size), MemoryManager.StringToByteArray(BoneLoader.LipsLeftSize.Replace(" ", string.Empty)));
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipsRight_Size), MemoryManager.StringToByteArray(BoneLoader.LipsRightSize.Replace(" ", string.Empty)));
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyebrowLeft_Size), MemoryManager.StringToByteArray(BoneLoader.EyebrowLeftSize.Replace(" ", string.Empty)));
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyebrowRight_Size), MemoryManager.StringToByteArray(BoneLoader.EyebrowRightSize.Replace(" ", string.Empty)));
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.Bridge_Size), MemoryManager.StringToByteArray(BoneLoader.BridgeSize.Replace(" ", string.Empty)));
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.BrowLeft_Size), MemoryManager.StringToByteArray(BoneLoader.BrowLeftSize.Replace(" ", string.Empty)));
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.BrowRight_Size), MemoryManager.StringToByteArray(BoneLoader.BrowRightSize.Replace(" ", string.Empty)));
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipUpperA_Size), MemoryManager.StringToByteArray(BoneLoader.LipUpperASize.Replace(" ", string.Empty)));
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyelidUpperLeft_Size), MemoryManager.StringToByteArray(BoneLoader.EyelidUpperLeftSize.Replace(" ", string.Empty)));
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyelidUpperRight_Size), MemoryManager.StringToByteArray(BoneLoader.EyelidUpperRightSize.Replace(" ", string.Empty)));
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar01ALeft_Size), MemoryManager.StringToByteArray(BoneLoader.VieraEar01ALeftSize.Replace(" ", string.Empty)));
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar01ARight_Size), MemoryManager.StringToByteArray(BoneLoader.VieraEar01ARightSize.Replace(" ", string.Empty)));
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar02ALeft_Size), MemoryManager.StringToByteArray(BoneLoader.VieraEar02ALeftSize.Replace(" ", string.Empty)));
                                }
                            }
                            if (BoneLoader.HrothLipLower != "null" || BoneLoader.VieraEar02ARight != "null")
                            {
                                if (CharacterDetails.Race.value == 7)
                                {
                                    if (BoneLoader.Race == "07")
                                    {
                                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothLipLower_Size), MemoryManager.StringToByteArray(BoneLoader.HrothLipLowerSize.Replace(" ", string.Empty)));
                                    }
                                }
                                if (CharacterDetails.Race.value == 8)
                                {
                                    if (BoneLoader.Race == "08")
                                    {
                                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar02ARight_Size), MemoryManager.StringToByteArray(BoneLoader.VieraEar02ARightSize.Replace(" ", string.Empty)));
                                    }
                                }
                            }
                            if (BoneLoader.VieraEar03ALeft != "null")
                            {
                                if (CharacterDetails.Race.value < 7)
                                {
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipLowerA_Size), MemoryManager.StringToByteArray(BoneLoader.VieraLipLowerASize.Replace(" ", string.Empty)));
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipUpperB_Size), MemoryManager.StringToByteArray(BoneLoader.VieraLipUpperBSize.Replace(" ", string.Empty)));
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipLowerB_Size), MemoryManager.StringToByteArray(BoneLoader.VieraLipLowerBSize.Replace(" ", string.Empty)));
                                }
                                if (CharacterDetails.Race.value == 8)
                                {
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar03ALeft_Size), MemoryManager.StringToByteArray(BoneLoader.VieraEar03ALeftSize.Replace(" ", string.Empty)));
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar03ARight_Size), MemoryManager.StringToByteArray(BoneLoader.VieraEar03ARightSize.Replace(" ", string.Empty)));
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar04ALeft_Size), MemoryManager.StringToByteArray(BoneLoader.VieraEar04ALeftSize.Replace(" ", string.Empty)));
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar04ARight_Size), MemoryManager.StringToByteArray(BoneLoader.VieraEar04ARightSize.Replace(" ", string.Empty)));
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraLipLowerA_Size), MemoryManager.StringToByteArray(BoneLoader.VieraLipLowerASize.Replace(" ", string.Empty)));
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraLipUpperB_Size), MemoryManager.StringToByteArray(BoneLoader.VieraLipUpperBSize.Replace(" ", string.Empty)));
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar01BLeft_Size), MemoryManager.StringToByteArray(BoneLoader.VieraEar01BLeftSize.Replace(" ", string.Empty)));
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar01BRight_Size), MemoryManager.StringToByteArray(BoneLoader.VieraEar01BRightSize.Replace(" ", string.Empty)));
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar02BLeft_Size), MemoryManager.StringToByteArray(BoneLoader.VieraEar02BLeftSize.Replace(" ", string.Empty)));
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar02BRight_Size), MemoryManager.StringToByteArray(BoneLoader.VieraEar02BRightSize.Replace(" ", string.Empty)));
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar03BLeft_Size), MemoryManager.StringToByteArray(BoneLoader.VieraEar03BLeftSize.Replace(" ", string.Empty)));
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar03BRight_Size), MemoryManager.StringToByteArray(BoneLoader.VieraEar03BRightSize.Replace(" ", string.Empty)));
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar04BLeft_Size), MemoryManager.StringToByteArray(BoneLoader.VieraEar04BLeftSize.Replace(" ", string.Empty)));
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar04BRight_Size), MemoryManager.StringToByteArray(BoneLoader.VieraEar04BRightSize.Replace(" ", string.Empty)));
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraLipLowerB_Size), MemoryManager.StringToByteArray(BoneLoader.VieraLipLowerBSize.Replace(" ", string.Empty)));
                                }
                            }
                            #endregion
                            #region Hair
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HairA_Size), MemoryManager.StringToByteArray(BoneLoader.HairASize.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HairFrontLeft_Size), MemoryManager.StringToByteArray(BoneLoader.HairFrontLeftSize.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HairFrontRight_Size), MemoryManager.StringToByteArray(BoneLoader.HairFrontRightSize.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HairB_Size), MemoryManager.StringToByteArray(BoneLoader.HairBSize.Replace(" ", string.Empty)));

                            if (HairValue >= 2)
                            {
                                if (BoneLoader.ExHairA != "null")
                                {
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExHairA_Size), MemoryManager.StringToByteArray(BoneLoader.ExHairASize.Replace(" ", string.Empty)));
                                }
                            }
                            if (HairValue >= 3)
                            {
                                if (BoneLoader.ExHairB != "null")
                                {
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExHairB_Size), MemoryManager.StringToByteArray(BoneLoader.ExHairBSize.Replace(" ", string.Empty)));
                                }
                            }
                            if (HairValue >= 4)
                            {
                                if (BoneLoader.ExHairC != "null")
                                {
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExHairC_Size), MemoryManager.StringToByteArray(BoneLoader.ExHairCSize.Replace(" ", string.Empty)));
                                }
                            }
                            if (HairValue >= 5)
                            {
                                if (BoneLoader.ExHairD != "null")
                                {
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExHairD_Size), MemoryManager.StringToByteArray(BoneLoader.ExHairDSize.Replace(" ", string.Empty)));
                                }
                            }
                            if (HairValue >= 6)
                            {
                                if (BoneLoader.ExHairE != "null")
                                {
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExHairE_Size), MemoryManager.StringToByteArray(BoneLoader.ExHairESize.Replace(" ", string.Empty)));
                                }
                            }
                            if (HairValue >= 7)
                            {
                                if (BoneLoader.ExHairF != "null")
                                {
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExHairF_Size), MemoryManager.StringToByteArray(BoneLoader.ExHairFSize.Replace(" ", string.Empty)));
                                }
                            }
                            if (HairValue >= 8)
                            {
                                if (BoneLoader.ExHairG != "null")
                                {
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExHairG_Size), MemoryManager.StringToByteArray(BoneLoader.ExHairGSize.Replace(" ", string.Empty)));
                                }
                            }
                            if (HairValue >= 9)
                            {
                                if (BoneLoader.ExHairH != "null")
                                {
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExHairH_Size), MemoryManager.StringToByteArray(BoneLoader.ExHairHSize.Replace(" ", string.Empty)));
                                }
                            }
                            if (HairValue >= 10)
                            {
                                if (BoneLoader.ExHairI != "null")
                                {
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExHairI_Size), MemoryManager.StringToByteArray(BoneLoader.ExHairISize.Replace(" ", string.Empty)));
                                }
                            }
                            if (HairValue >= 11)
                            {
                                if (BoneLoader.ExHairJ != "null")
                                {
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExHairJ_Size), MemoryManager.StringToByteArray(BoneLoader.ExHairJSize.Replace(" ", string.Empty)));
                                }
                            }
                            if (HairValue >= 12)
                            {
                                if (BoneLoader.ExHairK != "null")
                                {
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExHairK_Size), MemoryManager.StringToByteArray(BoneLoader.ExHairKSize.Replace(" ", string.Empty)));
                                }
                            }
                            if (HairValue >= 13)
                            {
                                if (BoneLoader.ExHairL != "null")
                                {
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExHairL_Size), MemoryManager.StringToByteArray(BoneLoader.ExHairLSize.Replace(" ", string.Empty)));
                                }
                            }
                            #endregion
                            #region Body
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.SpineA_Size), MemoryManager.StringToByteArray(BoneLoader.SpineASize.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.SpineB_Size), MemoryManager.StringToByteArray(BoneLoader.SpineBSize.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.BreastLeft_Size), MemoryManager.StringToByteArray(BoneLoader.BreastLeftSize.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.BreastRight_Size), MemoryManager.StringToByteArray(BoneLoader.BreastRightSize.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.SpineC_Size), MemoryManager.StringToByteArray(BoneLoader.SpineCSize.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.Neck_Size), MemoryManager.StringToByteArray(BoneLoader.NeckSize.Replace(" ", string.Empty)));
                            #endregion
                            #region LeftArm
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClavicleLeft_Size), MemoryManager.StringToByteArray(BoneLoader.ClavicleLeftSize.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ArmLeft_Size), MemoryManager.StringToByteArray(BoneLoader.ArmLeftSize.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ForearmLeft_Size), MemoryManager.StringToByteArray(BoneLoader.ForearmLeftSize.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ShoulderLeft_Size), MemoryManager.StringToByteArray(BoneLoader.ShoulderLeftSize.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ElbowLeft_Size), MemoryManager.StringToByteArray(BoneLoader.ElbowLeftSize.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.CouterLeft_Size), MemoryManager.StringToByteArray(BoneLoader.CouterLeftSize.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.WristLeft_Size), MemoryManager.StringToByteArray(BoneLoader.WristLeftSize.Replace(" ", string.Empty)));
                            #endregion
                            #region RightArm
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClavicleRight_Size), MemoryManager.StringToByteArray(BoneLoader.ClavicleRightSize.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ArmRight_Size), MemoryManager.StringToByteArray(BoneLoader.ArmRightSize.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ForearmRight_Size), MemoryManager.StringToByteArray(BoneLoader.ForearmRightSize.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ShoulderRight_Size), MemoryManager.StringToByteArray(BoneLoader.ShoulderRightSize.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ElbowRight_Size), MemoryManager.StringToByteArray(BoneLoader.ElbowRightSize.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.CouterRight_Size), MemoryManager.StringToByteArray(BoneLoader.CouterRightSize.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.WristRight_Size), MemoryManager.StringToByteArray(BoneLoader.WristRightSize.Replace(" ", string.Empty)));
                            #endregion
                            #region Clothes
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothBackALeft_Size), MemoryManager.StringToByteArray(BoneLoader.ClothBackALeftSize.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothBackARight_Size), MemoryManager.StringToByteArray(BoneLoader.ClothBackARightSize.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothFrontALeft_Size), MemoryManager.StringToByteArray(BoneLoader.ClothFrontALeftSize.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothFrontARight_Size), MemoryManager.StringToByteArray(BoneLoader.ClothFrontARightSize.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothSideALeft_Size), MemoryManager.StringToByteArray(BoneLoader.ClothSideALeftSize.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothSideARight_Size), MemoryManager.StringToByteArray(BoneLoader.ClothSideARightSize.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothBackBLeft_Size), MemoryManager.StringToByteArray(BoneLoader.ClothBackBLeftSize.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothBackBRight_Size), MemoryManager.StringToByteArray(BoneLoader.ClothBackBRightSize.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothFrontBLeft_Size), MemoryManager.StringToByteArray(BoneLoader.ClothFrontBLeftSize.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothFrontBRight_Size), MemoryManager.StringToByteArray(BoneLoader.ClothFrontBRightSize.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothSideBLeft_Size), MemoryManager.StringToByteArray(BoneLoader.ClothSideBLeftSize.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothSideBRight_Size), MemoryManager.StringToByteArray(BoneLoader.ClothSideBRightSize.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothBackCLeft_Size), MemoryManager.StringToByteArray(BoneLoader.ClothBackCLeftSize.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothBackCRight_Size), MemoryManager.StringToByteArray(BoneLoader.ClothBackCRightSize.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothFrontCLeft_Size), MemoryManager.StringToByteArray(BoneLoader.ClothFrontCLeftSize.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothFrontCRight_Size), MemoryManager.StringToByteArray(BoneLoader.ClothFrontCRightSize.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothSideCLeft_Size), MemoryManager.StringToByteArray(BoneLoader.ClothSideCLeftSize.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothSideCRight_Size), MemoryManager.StringToByteArray(BoneLoader.ClothSideCRightSize.Replace(" ", string.Empty)));
                            #endregion
                            #region LeftHand
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HandLeft_Size), MemoryManager.StringToByteArray(BoneLoader.HandLeftSize.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.IndexALeft_Size), MemoryManager.StringToByteArray(BoneLoader.IndexALeftSize.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.PinkyALeft_Size), MemoryManager.StringToByteArray(BoneLoader.PinkyALeftSize.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.RingALeft_Size), MemoryManager.StringToByteArray(BoneLoader.RingALeftSize.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.MiddleALeft_Size), MemoryManager.StringToByteArray(BoneLoader.MiddleALeftSize.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ThumbALeft_Size), MemoryManager.StringToByteArray(BoneLoader.ThumbALeftSize.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.IndexBLeft_Size), MemoryManager.StringToByteArray(BoneLoader.IndexBLeftSize.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.PinkyBLeft_Size), MemoryManager.StringToByteArray(BoneLoader.PinkyBLeftSize.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.RingBLeft_Size), MemoryManager.StringToByteArray(BoneLoader.RingBLeftSize.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.MiddleBLeft_Size), MemoryManager.StringToByteArray(BoneLoader.MiddleBLeftSize.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ThumbBLeft_Size), MemoryManager.StringToByteArray(BoneLoader.ThumbBLeftSize.Replace(" ", string.Empty)));
                            #endregion
                            #region RightHand
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HandRight_Size), MemoryManager.StringToByteArray(BoneLoader.HandRightSize.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.IndexARight_Size), MemoryManager.StringToByteArray(BoneLoader.IndexARightSize.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.PinkyARight_Size), MemoryManager.StringToByteArray(BoneLoader.PinkyARightSize.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.RingARight_Size), MemoryManager.StringToByteArray(BoneLoader.RingARightSize.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.MiddleARight_Size), MemoryManager.StringToByteArray(BoneLoader.MiddleARightSize.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ThumbARight_Size), MemoryManager.StringToByteArray(BoneLoader.ThumbARightSize.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.IndexBRight_Size), MemoryManager.StringToByteArray(BoneLoader.IndexBRightSize.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.PinkyBRight_Size), MemoryManager.StringToByteArray(BoneLoader.PinkyBRightSize.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.RingBRight_Size), MemoryManager.StringToByteArray(BoneLoader.RingBRightSize.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.MiddleBRight_Size), MemoryManager.StringToByteArray(BoneLoader.MiddleBRightSize.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ThumbBRight_Size), MemoryManager.StringToByteArray(BoneLoader.ThumbBRightSize.Replace(" ", string.Empty)));
                            #endregion
                            #region Waist
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.Waist_Size), MemoryManager.StringToByteArray(BoneLoader.WaistSize.Replace(" ", string.Empty)));
                            if (BoneLoader.TailA != "null")
                            {
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.TailA_Size), MemoryManager.StringToByteArray(BoneLoader.TailASize.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.TailB_Size), MemoryManager.StringToByteArray(BoneLoader.TailBSize.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.TailC_Size), MemoryManager.StringToByteArray(BoneLoader.TailCSize.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.TailD_Size), MemoryManager.StringToByteArray(BoneLoader.TailDSize.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.TailE_Size), MemoryManager.StringToByteArray(BoneLoader.TailESize.Replace(" ", string.Empty)));
                            }
                            #endregion
                            #region LeftLeg
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LegsLeft_Size), MemoryManager.StringToByteArray(BoneLoader.LegLeftSize.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.KneeLeft_Size), MemoryManager.StringToByteArray(BoneLoader.KneeLeftSize.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.CalfLeft_Size), MemoryManager.StringToByteArray(BoneLoader.CalfLeftSize.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.PoleynLeft_Size), MemoryManager.StringToByteArray(BoneLoader.PoleynLeftSize.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.FootLeft_Size), MemoryManager.StringToByteArray(BoneLoader.FootLeftSize.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ToesLeft_Size), MemoryManager.StringToByteArray(BoneLoader.ToesLeftSize.Replace(" ", string.Empty)));
                            #endregion
                            #region RightLeg
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LegsRight_Size), MemoryManager.StringToByteArray(BoneLoader.LegRightSize.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.KneeRight_Size), MemoryManager.StringToByteArray(BoneLoader.KneeRightSize.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.CalfRight_Size), MemoryManager.StringToByteArray(BoneLoader.CalfRightSize.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.PoleynRight_Size), MemoryManager.StringToByteArray(BoneLoader.PoleynRightSize.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.FootRight_Size), MemoryManager.StringToByteArray(BoneLoader.FootRightSize.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ToesRight_Size), MemoryManager.StringToByteArray(BoneLoader.ToesRightSize.Replace(" ", string.Empty)));
                            #endregion
                            #region Helm

                            if (HelmValue >= 2)
                            {
                                if (BoneLoader.ExMetA != "null")
                                {
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetA_Size), MemoryManager.StringToByteArray(BoneLoader.ExMetASize.Replace(" ", string.Empty)));
                                }
                            }
                            if (HelmValue >= 3)
                            {
                                if (BoneLoader.ExMetB != "null")
                                {
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetB_Size), MemoryManager.StringToByteArray(BoneLoader.ExMetBSize.Replace(" ", string.Empty)));
                                }
                            }
                            if (HelmValue >= 4)
                            {
                                if (BoneLoader.ExMetC != "null")
                                {
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetC_Size), MemoryManager.StringToByteArray(BoneLoader.ExMetCSize.Replace(" ", string.Empty)));
                                }
                            }
                            if (HelmValue >= 5)
                            {
                                if (BoneLoader.ExMetD != "null")
                                {
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetD_Size), MemoryManager.StringToByteArray(BoneLoader.ExMetDSize.Replace(" ", string.Empty)));
                                }
                            }
                            if (HelmValue >= 6)
                            {
                                if (BoneLoader.ExMetE != "null")
                                {
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetE_Size), MemoryManager.StringToByteArray(BoneLoader.ExMetESize.Replace(" ", string.Empty)));
                                }
                            }
                            if (HelmValue >= 7)
                            {
                                if (BoneLoader.ExMetF != "null")
                                {
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetF_Size), MemoryManager.StringToByteArray(BoneLoader.ExMetFSize.Replace(" ", string.Empty)));
                                }
                            }
                            if (HelmValue >= 8)
                            {
                                if (BoneLoader.ExMetG != "null")
                                {
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetG_Size), MemoryManager.StringToByteArray(BoneLoader.ExMetGSize.Replace(" ", string.Empty)));
                                }
                            }
                            if (HelmValue >= 9)
                            {
                                if (BoneLoader.ExMetH != "null")
                                {
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetH_Size), MemoryManager.StringToByteArray(BoneLoader.ExMetHSize.Replace(" ", string.Empty)));
                                }
                            }
                            if (HelmValue >= 10)
                            {
                                if (BoneLoader.ExMetI != "null")
                                {
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetI_Size), MemoryManager.StringToByteArray(BoneLoader.ExMetISize.Replace(" ", string.Empty)));
                                }
                            }
                            if (HelmValue >= 11)
                            {
                                if (BoneLoader.ExMetJ != "null")
                                {
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetJ_Size), MemoryManager.StringToByteArray(BoneLoader.ExMetJSize.Replace(" ", string.Empty)));
                                }
                            }
                            if (HelmValue >= 12)
                            {
                                if (BoneLoader.ExMetK != "null")
                                {
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetK_Size), MemoryManager.StringToByteArray(BoneLoader.ExMetKSize.Replace(" ", string.Empty)));
                                }
                            }
                            if (HelmValue >= 13)
                            {
                                if (BoneLoader.ExMetL != "null")
                                {
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetL_Size), MemoryManager.StringToByteArray(BoneLoader.ExMetLSize.Replace(" ", string.Empty)));
                                }
                            }
                            if (HelmValue >= 14)
                            {
                                if (BoneLoader.ExMetM != "null")
                                {
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetM_Size), MemoryManager.StringToByteArray(BoneLoader.ExMetMSize.Replace(" ", string.Empty)));
                                }
                            }
                            if (HelmValue >= 15)
                            {
                                if (BoneLoader.ExMetN != "null")
                                {
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetN_Size), MemoryManager.StringToByteArray(BoneLoader.ExMetNSize.Replace(" ", string.Empty)));
                                }
                            }
                            if (HelmValue >= 16)
                            {
                                if (BoneLoader.ExMetO != "null")
                                {
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetO_Size), MemoryManager.StringToByteArray(BoneLoader.ExMetOSize.Replace(" ", string.Empty)));
                                }
                            }
                            if (HelmValue >= 17)
                            {
                                if (BoneLoader.ExMetP != "null")
                                {
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetP_Size), MemoryManager.StringToByteArray(BoneLoader.ExMetPSize.Replace(" ", string.Empty)));
                                }
                            }
                            if (HelmValue >= 18)
                            {
                                if (BoneLoader.ExMetQ != "null")
                                {
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetQ_Size), MemoryManager.StringToByteArray(BoneLoader.ExMetQSize.Replace(" ", string.Empty)));
                                }
                            }
                            if (HelmValue >= 19)
                            {
                                if (BoneLoader.ExMetR != "null")
                                {
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetR_Size), MemoryManager.StringToByteArray(BoneLoader.ExMetRSize.Replace(" ", string.Empty)));
                                }
                            }
                            #endregion
                            #region Top

                            if (TopValue >= 2)
                            {
                                if (BoneLoader.ExTopA != "null")
                                {
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExTopA_Size), MemoryManager.StringToByteArray(BoneLoader.ExTopASize.Replace(" ", string.Empty)));
                                }
                            }
                            if (TopValue >= 3)
                            {
                                if (BoneLoader.ExTopB != "null")
                                {
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExTopB_Size), MemoryManager.StringToByteArray(BoneLoader.ExTopBSize.Replace(" ", string.Empty)));
                                }
                            }
                            if (TopValue >= 4)
                            {
                                if (BoneLoader.ExTopC != "null")
                                {
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExTopC_Size), MemoryManager.StringToByteArray(BoneLoader.ExTopCSize.Replace(" ", string.Empty)));
                                }
                            }
                            if (TopValue >= 5)
                            {
                                if (BoneLoader.ExTopD != "null")
                                {
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExTopD_Size), MemoryManager.StringToByteArray(BoneLoader.ExTopDSize.Replace(" ", string.Empty)));
                                }
                            }
                            if (TopValue >= 6)
                            {
                                if (BoneLoader.ExTopE != "null")
                                {
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExTopE_Size), MemoryManager.StringToByteArray(BoneLoader.ExTopESize.Replace(" ", string.Empty)));
                                }
                            }
                            if (TopValue >= 7)
                            {
                                if (BoneLoader.ExTopF != "null")
                                {
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExTopF_Size), MemoryManager.StringToByteArray(BoneLoader.ExTopFSize.Replace(" ", string.Empty)));
                                }
                            }
                            if (TopValue >= 8)
                            {
                                if (BoneLoader.ExTopG != "null")
                                {
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExTopG_Size), MemoryManager.StringToByteArray(BoneLoader.ExTopGSize.Replace(" ", string.Empty)));
                                }
                            }
                            if (TopValue >= 9)
                            {
                                if (BoneLoader.ExTopH != "null")
                                {
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExTopH_Size), MemoryManager.StringToByteArray(BoneLoader.ExTopHSize.Replace(" ", string.Empty)));
                                }
                            }
                            if (TopValue >= 10)
                            {
                                if (BoneLoader.ExTopI != "null")
                                {
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExTopI_Size), MemoryManager.StringToByteArray(BoneLoader.ExTopISize.Replace(" ", string.Empty)));
                                }
                            }
                            #endregion
                        }
                    }
                    #endregion

                }
            }
            else return;
        }

        private void AdvLoadCMP_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dig = new OpenFileDialog();
            dig.InitialDirectory = SaveSettings.Default.MatrixPoseSaveLoadDirectory;
            dig.Filter = "Concept Matrix Pose File(*.cmp)|*.cmp";
            dig.DefaultExt = ".cmp";
            if (dig.ShowDialog() == true)
            {
                SaveSettings.Default.MatrixPoseSaveLoadDirectory = Path.GetDirectoryName(dig.FileName);
                if (MemoryManager.Instance.MemLib.readByte(MemoryManager.GetAddressString(MemoryManager.Instance.GposeCheckAddress)) == 1 && MemoryManager.Instance.MemLib.readByte(MemoryManager.GetAddressString(MemoryManager.Instance.GposeCheck2Address)) == 4)
                {
                    UncheckAll();
                    EditModeButton.IsChecked = true;
                    PhysicsButton.IsChecked = false;
                    BoneSaves BoneLoader = JsonConvert.DeserializeObject<BoneSaves>(File.ReadAllText(dig.FileName));

                    #region Head
                    if (HeadAdvLoad.IsChecked == true)
                    {
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.Head_Bone), MemoryManager.StringToByteArray(BoneLoader.Head.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EarLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.EarLeft.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EarRight_Bone), MemoryManager.StringToByteArray(BoneLoader.EarRight.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.Jaw_Bone), MemoryManager.StringToByteArray(BoneLoader.Jaw.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyelidLowerLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.EyelidLowerLeft.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyelidLowerRight_Bone), MemoryManager.StringToByteArray(BoneLoader.EyelidLowerRight.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyeLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.EyeLeft.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyeRight_Bone), MemoryManager.StringToByteArray(BoneLoader.EyeRight.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.Nose_Bone), MemoryManager.StringToByteArray(BoneLoader.Nose.Replace(" ", string.Empty)));
                        if (CharacterDetails.Race.value < 7)
                        {
                            if (BoneLoader.Race == "01" || BoneLoader.Race == "02" || BoneLoader.Race == "03" || BoneLoader.Race == "04" || BoneLoader.Race == "05" || BoneLoader.Race == "06")
                            {
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.CheekLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.CheekLeft.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.CheekRight_Bone), MemoryManager.StringToByteArray(BoneLoader.CheekRight.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipsLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.LipsLeft.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipsRight_Bone), MemoryManager.StringToByteArray(BoneLoader.LipsRight.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyebrowLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.EyebrowLeft.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyebrowRight_Bone), MemoryManager.StringToByteArray(BoneLoader.EyebrowRight.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.Bridge_Bone), MemoryManager.StringToByteArray(BoneLoader.Bridge.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.BrowLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.BrowLeft.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.BrowRight_Bone), MemoryManager.StringToByteArray(BoneLoader.BrowRight.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipUpperA_Bone), MemoryManager.StringToByteArray(BoneLoader.LipUpperA.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyelidUpperLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.EyelidUpperLeft.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyelidUpperRight_Bone), MemoryManager.StringToByteArray(BoneLoader.EyelidUpperRight.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipLowerA_Bone), MemoryManager.StringToByteArray(BoneLoader.LipLowerA.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipUpperB_Bone), MemoryManager.StringToByteArray(BoneLoader.LipUpperB.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipLowerB_Bone), MemoryManager.StringToByteArray(BoneLoader.LipLowerB.Replace(" ", string.Empty)));
                            }
                            if (BoneLoader.Race == "07")
                            {
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.CheekLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.HrothLipUpperLeft.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.CheekRight_Bone), MemoryManager.StringToByteArray(BoneLoader.HrothLipUpperRight.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipsLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.HrothLipsLeft.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipsRight_Bone), MemoryManager.StringToByteArray(BoneLoader.HrothLipsRight.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyebrowLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.HrothEyebrowLeft.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyebrowRight_Bone), MemoryManager.StringToByteArray(BoneLoader.HrothEyebrowRight.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.Bridge_Bone), MemoryManager.StringToByteArray(BoneLoader.HrothBridge.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.BrowLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.HrothBrowLeft.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.BrowRight_Bone), MemoryManager.StringToByteArray(BoneLoader.HrothBrowRight.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipUpperA_Bone), MemoryManager.StringToByteArray(BoneLoader.HrothLipUpper.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyelidUpperLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.HrothEyelidUpperLeft.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyelidUpperRight_Bone), MemoryManager.StringToByteArray(BoneLoader.HrothEyelidUpperRight.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipUpperB_Bone), MemoryManager.StringToByteArray(BoneLoader.HrothJawUpper.Replace(" ", string.Empty)));
                            }
                            if (BoneLoader.Race == "08")
                            {
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.CheekLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.CheekLeft.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.CheekRight_Bone), MemoryManager.StringToByteArray(BoneLoader.CheekRight.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipsLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.LipsLeft.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipsRight_Bone), MemoryManager.StringToByteArray(BoneLoader.LipsRight.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyebrowLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.EyebrowLeft.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyebrowRight_Bone), MemoryManager.StringToByteArray(BoneLoader.EyebrowRight.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.Bridge_Bone), MemoryManager.StringToByteArray(BoneLoader.Bridge.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.BrowLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.BrowLeft.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.BrowRight_Bone), MemoryManager.StringToByteArray(BoneLoader.BrowRight.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipUpperA_Bone), MemoryManager.StringToByteArray(BoneLoader.LipUpperA.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyelidUpperLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.EyelidUpperLeft.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyelidUpperRight_Bone), MemoryManager.StringToByteArray(BoneLoader.EyelidUpperRight.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipLowerA_Bone), MemoryManager.StringToByteArray(BoneLoader.VieraLipLowerA.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipUpperB_Bone), MemoryManager.StringToByteArray(BoneLoader.VieraLipUpperB.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipLowerB_Bone), MemoryManager.StringToByteArray(BoneLoader.VieraLipLowerB.Replace(" ", string.Empty)));
                            }
                        }
                        if (CharacterDetails.Race.value == 7)
                        {
                            if (BoneLoader.Race == "01" || BoneLoader.Race == "02" || BoneLoader.Race == "03" || BoneLoader.Race == "04" || BoneLoader.Race == "05" || BoneLoader.Race == "06")
                            {
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothEyebrowLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.EyebrowLeft.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothEyebrowRight_Bone), MemoryManager.StringToByteArray(BoneLoader.EyebrowRight.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothBridge_Bone), MemoryManager.StringToByteArray(BoneLoader.Bridge.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothBrowLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.BrowLeft.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothBrowRight_Bone), MemoryManager.StringToByteArray(BoneLoader.BrowRight.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothJawUpper_Bone), MemoryManager.StringToByteArray(BoneLoader.LipUpperB.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothLipUpper_Bone), MemoryManager.StringToByteArray(BoneLoader.LipUpperA.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothEyelidUpperLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.EyelidUpperLeft.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothEyelidUpperRight_Bone), MemoryManager.StringToByteArray(BoneLoader.EyelidUpperRight.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothLipsLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.LipsLeft.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothLipsRight_Bone), MemoryManager.StringToByteArray(BoneLoader.LipsRight.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothLipUpperLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.CheekLeft.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothLipUpperRight_Bone), MemoryManager.StringToByteArray(BoneLoader.CheekRight.Replace(" ", string.Empty)));
                            }
                            if (BoneLoader.Race == "07")
                            {
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothWhiskersLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.HrothWhiskersLeft.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothWhiskersRight_Bone), MemoryManager.StringToByteArray(BoneLoader.HrothWhiskersRight.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothEyebrowLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.HrothEyebrowLeft.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothEyebrowRight_Bone), MemoryManager.StringToByteArray(BoneLoader.HrothEyebrowRight.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothBridge_Bone), MemoryManager.StringToByteArray(BoneLoader.HrothBridge.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothBrowLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.HrothBrowLeft.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothBrowRight_Bone), MemoryManager.StringToByteArray(BoneLoader.HrothBrowRight.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothJawUpper_Bone), MemoryManager.StringToByteArray(BoneLoader.HrothJawUpper.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothLipUpper_Bone), MemoryManager.StringToByteArray(BoneLoader.HrothLipUpper.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothEyelidUpperLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.HrothEyelidUpperLeft.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothEyelidUpperRight_Bone), MemoryManager.StringToByteArray(BoneLoader.HrothEyelidUpperRight.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothLipsLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.HrothLipsLeft.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothLipsRight_Bone), MemoryManager.StringToByteArray(BoneLoader.HrothLipsRight.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothLipUpperLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.HrothLipUpperLeft.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothLipUpperRight_Bone), MemoryManager.StringToByteArray(BoneLoader.HrothLipUpperRight.Replace(" ", string.Empty)));
                            }
                            if (BoneLoader.Race == "08")
                            {
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothEyebrowLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.EyebrowLeft.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothEyebrowRight_Bone), MemoryManager.StringToByteArray(BoneLoader.EyebrowRight.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothBridge_Bone), MemoryManager.StringToByteArray(BoneLoader.Bridge.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothBrowLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.BrowLeft.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothBrowRight_Bone), MemoryManager.StringToByteArray(BoneLoader.BrowRight.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothJawUpper_Bone), MemoryManager.StringToByteArray(BoneLoader.VieraLipUpperB.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothLipUpper_Bone), MemoryManager.StringToByteArray(BoneLoader.LipUpperA.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothEyelidUpperLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.EyelidUpperLeft.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothEyelidUpperRight_Bone), MemoryManager.StringToByteArray(BoneLoader.EyelidUpperRight.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothLipsLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.LipsLeft.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothLipsRight_Bone), MemoryManager.StringToByteArray(BoneLoader.LipsRight.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothLipUpperLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.CheekLeft.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothLipUpperRight_Bone), MemoryManager.StringToByteArray(BoneLoader.CheekRight.Replace(" ", string.Empty)));
                            }
                        }
                        if (CharacterDetails.Race.value == 8)
                        {
                            if (BoneLoader.Race == "01" || BoneLoader.Race == "02" || BoneLoader.Race == "03" || BoneLoader.Race == "04" || BoneLoader.Race == "05" || BoneLoader.Race == "06")
                            {
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.CheekLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.CheekLeft.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.CheekRight_Bone), MemoryManager.StringToByteArray(BoneLoader.CheekRight.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipsLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.LipsLeft.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipsRight_Bone), MemoryManager.StringToByteArray(BoneLoader.LipsRight.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyebrowLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.EyebrowLeft.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyebrowRight_Bone), MemoryManager.StringToByteArray(BoneLoader.EyebrowRight.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.Bridge_Bone), MemoryManager.StringToByteArray(BoneLoader.Bridge.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.BrowLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.BrowLeft.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.BrowRight_Bone), MemoryManager.StringToByteArray(BoneLoader.BrowRight.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipUpperA_Bone), MemoryManager.StringToByteArray(BoneLoader.LipUpperA.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyelidUpperLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.EyelidUpperLeft.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyelidUpperRight_Bone), MemoryManager.StringToByteArray(BoneLoader.EyelidUpperRight.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraLipLowerA_Bone), MemoryManager.StringToByteArray(BoneLoader.VieraEar01ALeft.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraLipUpperB_Bone), MemoryManager.StringToByteArray(BoneLoader.VieraEar01ARight.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraLipLowerB_Bone), MemoryManager.StringToByteArray(BoneLoader.VieraEar02ALeft.Replace(" ", string.Empty)));
                            }
                            if (BoneLoader.Race == "07")
                            {
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.CheekLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.HrothLipUpperLeft.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.CheekRight_Bone), MemoryManager.StringToByteArray(BoneLoader.HrothLipUpperRight.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipsLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.HrothLipsLeft.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipsRight_Bone), MemoryManager.StringToByteArray(BoneLoader.HrothLipsRight.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyebrowLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.HrothEyebrowLeft.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyebrowRight_Bone), MemoryManager.StringToByteArray(BoneLoader.HrothEyebrowRight.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.Bridge_Bone), MemoryManager.StringToByteArray(BoneLoader.HrothBridge.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.BrowLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.HrothBrowLeft.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.BrowRight_Bone), MemoryManager.StringToByteArray(BoneLoader.HrothBrowRight.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipUpperA_Bone), MemoryManager.StringToByteArray(BoneLoader.HrothLipUpper.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyelidUpperLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.HrothEyelidUpperLeft.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyelidUpperRight_Bone), MemoryManager.StringToByteArray(BoneLoader.HrothEyelidUpperRight.Replace(" ", string.Empty)));
                            }
                            if (BoneLoader.Race == "08")
                            {
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.CheekLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.CheekLeft.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.CheekRight_Bone), MemoryManager.StringToByteArray(BoneLoader.CheekRight.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipsLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.LipsLeft.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipsRight_Bone), MemoryManager.StringToByteArray(BoneLoader.LipsRight.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyebrowLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.EyebrowLeft.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyebrowRight_Bone), MemoryManager.StringToByteArray(BoneLoader.EyebrowRight.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.Bridge_Bone), MemoryManager.StringToByteArray(BoneLoader.Bridge.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.BrowLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.BrowLeft.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.BrowRight_Bone), MemoryManager.StringToByteArray(BoneLoader.BrowRight.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipUpperA_Bone), MemoryManager.StringToByteArray(BoneLoader.LipUpperA.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyelidUpperLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.EyelidUpperLeft.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyelidUpperRight_Bone), MemoryManager.StringToByteArray(BoneLoader.EyelidUpperRight.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar01ALeft_Bone), MemoryManager.StringToByteArray(BoneLoader.VieraEar01ALeft.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar01ARight_Bone), MemoryManager.StringToByteArray(BoneLoader.VieraEar01ARight.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar02ALeft_Bone), MemoryManager.StringToByteArray(BoneLoader.VieraEar02ALeft.Replace(" ", string.Empty)));
                            }
                        }
                        if (BoneLoader.HrothLipLower != "null" || BoneLoader.VieraEar02ARight != "null")
                        {
                            if (CharacterDetails.Race.value == 7)
                            {
                                if (BoneLoader.Race == "07")
                                {
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothLipLower_Bone), MemoryManager.StringToByteArray(BoneLoader.HrothLipLower.Replace(" ", string.Empty)));
                                }
                            }
                            if (CharacterDetails.Race.value == 8)
                            {
                                if (BoneLoader.Race == "08")
                                {
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar02ARight_Bone), MemoryManager.StringToByteArray(BoneLoader.VieraEar02ARight.Replace(" ", string.Empty)));
                                }
                            }
                        }
                        if (BoneLoader.VieraEar03ALeft != "null")
                        {
                            if (CharacterDetails.Race.value < 7)
                            {
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipLowerA_Bone), MemoryManager.StringToByteArray(BoneLoader.VieraLipLowerA.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipUpperB_Bone), MemoryManager.StringToByteArray(BoneLoader.VieraLipUpperB.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipLowerB_Bone), MemoryManager.StringToByteArray(BoneLoader.VieraLipLowerB.Replace(" ", string.Empty)));
                            }
                            if (CharacterDetails.Race.value == 8)
                            {
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar03ALeft_Bone), MemoryManager.StringToByteArray(BoneLoader.VieraEar03ALeft.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar03ARight_Bone), MemoryManager.StringToByteArray(BoneLoader.VieraEar03ARight.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar04ALeft_Bone), MemoryManager.StringToByteArray(BoneLoader.VieraEar04ALeft.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar04ARight_Bone), MemoryManager.StringToByteArray(BoneLoader.VieraEar04ARight.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraLipLowerA_Bone), MemoryManager.StringToByteArray(BoneLoader.VieraLipLowerA.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraLipUpperB_Bone), MemoryManager.StringToByteArray(BoneLoader.VieraLipUpperB.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar01BLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.VieraEar01BLeft.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar01BRight_Bone), MemoryManager.StringToByteArray(BoneLoader.VieraEar01BRight.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar02BLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.VieraEar02BLeft.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar02BRight_Bone), MemoryManager.StringToByteArray(BoneLoader.VieraEar02BRight.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar03BLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.VieraEar03BLeft.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar03BRight_Bone), MemoryManager.StringToByteArray(BoneLoader.VieraEar03BRight.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar04BLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.VieraEar04BLeft.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar04BRight_Bone), MemoryManager.StringToByteArray(BoneLoader.VieraEar04BRight.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraLipLowerB_Bone), MemoryManager.StringToByteArray(BoneLoader.VieraLipLowerB.Replace(" ", string.Empty)));
                            }
                        }
                    }
                    #endregion
                    #region Hair
                    if (HairAdvLoad.IsChecked == true)
                    {
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HairA_Bone), MemoryManager.StringToByteArray(BoneLoader.HairA.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HairFrontLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.HairFrontLeft.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HairFrontRight_Bone), MemoryManager.StringToByteArray(BoneLoader.HairFrontRight.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HairB_Bone), MemoryManager.StringToByteArray(BoneLoader.HairB.Replace(" ", string.Empty)));
                        var HairValue = m.readByte(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExHair_Value));

                        if (HairValue >= 2)
                        {
                            if (BoneLoader.ExHairA != "null")
                            {
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExHairA_Bone), MemoryManager.StringToByteArray(BoneLoader.ExHairA.Replace(" ", string.Empty)));
                            }
                        }
                        if (HairValue >= 3)
                        {
                            if (BoneLoader.ExHairB != "null")
                            {
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExHairB_Bone), MemoryManager.StringToByteArray(BoneLoader.ExHairB.Replace(" ", string.Empty)));
                            }
                        }
                        if (HairValue >= 4)
                        {
                            if (BoneLoader.ExHairC != "null")
                            {
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExHairC_Bone), MemoryManager.StringToByteArray(BoneLoader.ExHairC.Replace(" ", string.Empty)));
                            }
                        }
                        if (HairValue >= 5)
                        {
                            if (BoneLoader.ExHairD != "null")
                            {
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExHairD_Bone), MemoryManager.StringToByteArray(BoneLoader.ExHairD.Replace(" ", string.Empty)));
                            }
                        }
                        if (HairValue >= 6)
                        {
                            if (BoneLoader.ExHairE != "null")
                            {
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExHairE_Bone), MemoryManager.StringToByteArray(BoneLoader.ExHairE.Replace(" ", string.Empty)));
                            }
                        }
                        if (HairValue >= 7)
                        {
                            if (BoneLoader.ExHairF != "null")
                            {
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExHairF_Bone), MemoryManager.StringToByteArray(BoneLoader.ExHairF.Replace(" ", string.Empty)));
                            }
                        }
                        if (HairValue >= 8)
                        {
                            if (BoneLoader.ExHairG != "null")
                            {
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExHairG_Bone), MemoryManager.StringToByteArray(BoneLoader.ExHairG.Replace(" ", string.Empty)));
                            }
                        }
                        if (HairValue >= 9)
                        {
                            if (BoneLoader.ExHairH != "null")
                            {
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExHairH_Bone), MemoryManager.StringToByteArray(BoneLoader.ExHairH.Replace(" ", string.Empty)));
                            }
                        }
                        if (HairValue >= 10)
                        {
                            if (BoneLoader.ExHairI != "null")
                            {
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExHairI_Bone), MemoryManager.StringToByteArray(BoneLoader.ExHairI.Replace(" ", string.Empty)));
                            }
                        }
                        if (HairValue >= 11)
                        {
                            if (BoneLoader.ExHairJ != "null")
                            {
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExHairJ_Bone), MemoryManager.StringToByteArray(BoneLoader.ExHairJ.Replace(" ", string.Empty)));
                            }
                        }
                        if (HairValue >= 12)
                        {
                            if (BoneLoader.ExHairK != "null")
                            {
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExHairK_Bone), MemoryManager.StringToByteArray(BoneLoader.ExHairK.Replace(" ", string.Empty)));
                            }
                        }
                        if (HairValue >= 13)
                        {
                            if (BoneLoader.ExHairL != "null")
                            {
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExHairL_Bone), MemoryManager.StringToByteArray(BoneLoader.ExHairL.Replace(" ", string.Empty)));
                            }
                        }
                    }
                    #endregion
                    #region Earrings
                    if (EarringsAdvLoad.IsChecked == true)
                    {
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EarringALeft_Bone), MemoryManager.StringToByteArray(BoneLoader.EarringALeft.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EarringARight_Bone), MemoryManager.StringToByteArray(BoneLoader.EarringARight.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EarringBLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.EarringBLeft.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EarringBRight_Bone), MemoryManager.StringToByteArray(BoneLoader.EarringBRight.Replace(" ", string.Empty)));
                    }
                    #endregion
                    #region Body
                    if (BodyAdvLoad.IsChecked == true)
                    {
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.SpineA_Bone), MemoryManager.StringToByteArray(BoneLoader.SpineA.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.SpineB_Bone), MemoryManager.StringToByteArray(BoneLoader.SpineB.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.BreastLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.BreastLeft.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.BreastRight_Bone), MemoryManager.StringToByteArray(BoneLoader.BreastRight.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.SpineC_Bone), MemoryManager.StringToByteArray(BoneLoader.SpineC.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ScabbardLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.ScabbardLeft.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ScabbardRight_Bone), MemoryManager.StringToByteArray(BoneLoader.ScabbardRight.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.Neck_Bone), MemoryManager.StringToByteArray(BoneLoader.Neck.Replace(" ", string.Empty)));
                    }
                    #endregion
                    #region LeftArm
                    if (LeftArmAdvLoad.IsChecked == true)
                    {
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClavicleLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.ClavicleLeft.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ArmLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.ArmLeft.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.PauldronLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.PauldronLeft.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ForearmLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.ForearmLeft.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ShoulderLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.ShoulderLeft.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ShieldLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.ShieldLeft.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ElbowLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.ElbowLeft.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.CouterLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.CouterLeft.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.WristLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.WristLeft.Replace(" ", string.Empty)));
                    }
                    #endregion
                    #region RightArm
                    if (RightArmAdvLoad.IsChecked == true)
                    {
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClavicleRight_Bone), MemoryManager.StringToByteArray(BoneLoader.ClavicleRight.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ArmRight_Bone), MemoryManager.StringToByteArray(BoneLoader.ArmRight.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.PauldronRight_Bone), MemoryManager.StringToByteArray(BoneLoader.PauldronRight.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ForearmRight_Bone), MemoryManager.StringToByteArray(BoneLoader.ForearmRight.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ShoulderRight_Bone), MemoryManager.StringToByteArray(BoneLoader.ShoulderRight.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ShieldRight_Bone), MemoryManager.StringToByteArray(BoneLoader.ShieldRight.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ElbowRight_Bone), MemoryManager.StringToByteArray(BoneLoader.ElbowRight.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.CouterRight_Bone), MemoryManager.StringToByteArray(BoneLoader.CouterRight.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.WristRight_Bone), MemoryManager.StringToByteArray(BoneLoader.WristRight.Replace(" ", string.Empty)));
                    }
                    #endregion
                    #region Clothes
                    if (ClothesAdvLoad.IsChecked == true)
                    {
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothBackALeft_Bone), MemoryManager.StringToByteArray(BoneLoader.ClothBackALeft.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothBackARight_Bone), MemoryManager.StringToByteArray(BoneLoader.ClothBackARight.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothFrontALeft_Bone), MemoryManager.StringToByteArray(BoneLoader.ClothFrontALeft.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothFrontARight_Bone), MemoryManager.StringToByteArray(BoneLoader.ClothFrontARight.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothSideALeft_Bone), MemoryManager.StringToByteArray(BoneLoader.ClothSideALeft.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothSideARight_Bone), MemoryManager.StringToByteArray(BoneLoader.ClothSideARight.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothBackBLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.ClothBackBLeft.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothBackBRight_Bone), MemoryManager.StringToByteArray(BoneLoader.ClothBackBRight.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothFrontBLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.ClothFrontBLeft.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothFrontBRight_Bone), MemoryManager.StringToByteArray(BoneLoader.ClothFrontBRight.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothSideBLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.ClothSideBLeft.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothSideBRight_Bone), MemoryManager.StringToByteArray(BoneLoader.ClothSideBRight.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothBackCLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.ClothBackCLeft.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothBackCRight_Bone), MemoryManager.StringToByteArray(BoneLoader.ClothBackCRight.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothFrontCLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.ClothFrontCLeft.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothFrontCRight_Bone), MemoryManager.StringToByteArray(BoneLoader.ClothFrontCRight.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothSideCLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.ClothSideCLeft.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothSideCRight_Bone), MemoryManager.StringToByteArray(BoneLoader.ClothSideCRight.Replace(" ", string.Empty)));
                    }
                    #endregion
                    #region Weapons
                    if (WeaponsAdvLoad.IsChecked == true)
                    {
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.WeaponLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.WeaponLeft.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.WeaponRight_Bone), MemoryManager.StringToByteArray(BoneLoader.WeaponRight.Replace(" ", string.Empty)));
                    }
                    #endregion
                    #region LeftHand
                    if (LeftHandAdvLoad.IsChecked == true)
                    {
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HandLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.HandLeft.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.IndexALeft_Bone), MemoryManager.StringToByteArray(BoneLoader.IndexALeft.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.PinkyALeft_Bone), MemoryManager.StringToByteArray(BoneLoader.PinkyALeft.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.RingALeft_Bone), MemoryManager.StringToByteArray(BoneLoader.RingALeft.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.MiddleALeft_Bone), MemoryManager.StringToByteArray(BoneLoader.MiddleALeft.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ThumbALeft_Bone), MemoryManager.StringToByteArray(BoneLoader.ThumbALeft.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.IndexBLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.IndexBLeft.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.PinkyBLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.PinkyBLeft.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.RingBLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.RingBLeft.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.MiddleBLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.MiddleBLeft.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ThumbBLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.ThumbBLeft.Replace(" ", string.Empty)));
                    }
                    #endregion
                    #region RightHand
                    if (RightHandAdvLoad.IsChecked == true)
                    {
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HandRight_Bone), MemoryManager.StringToByteArray(BoneLoader.HandRight.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.IndexARight_Bone), MemoryManager.StringToByteArray(BoneLoader.IndexARight.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.PinkyARight_Bone), MemoryManager.StringToByteArray(BoneLoader.PinkyARight.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.RingARight_Bone), MemoryManager.StringToByteArray(BoneLoader.RingARight.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.MiddleARight_Bone), MemoryManager.StringToByteArray(BoneLoader.MiddleARight.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ThumbARight_Bone), MemoryManager.StringToByteArray(BoneLoader.ThumbARight.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.IndexBRight_Bone), MemoryManager.StringToByteArray(BoneLoader.IndexBRight.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.PinkyBRight_Bone), MemoryManager.StringToByteArray(BoneLoader.PinkyBRight.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.RingBRight_Bone), MemoryManager.StringToByteArray(BoneLoader.RingBRight.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.MiddleBRight_Bone), MemoryManager.StringToByteArray(BoneLoader.MiddleBRight.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ThumbBRight_Bone), MemoryManager.StringToByteArray(BoneLoader.ThumbBRight.Replace(" ", string.Empty)));
                    }
                    #endregion
                    #region Waist
                    if (WaistAdvLoad.IsChecked == true)
                    {
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.Waist_Bone), MemoryManager.StringToByteArray(BoneLoader.Waist.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HolsterLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.HolsterLeft.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HolsterRight_Bone), MemoryManager.StringToByteArray(BoneLoader.HolsterRight.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.SheatheLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.SheatheLeft.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.SheatheRight_Bone), MemoryManager.StringToByteArray(BoneLoader.SheatheRight.Replace(" ", string.Empty)));
                        if (BoneLoader.TailA != "null")
                        {
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.TailA_Bone), MemoryManager.StringToByteArray(BoneLoader.TailA.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.TailB_Bone), MemoryManager.StringToByteArray(BoneLoader.TailB.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.TailC_Bone), MemoryManager.StringToByteArray(BoneLoader.TailC.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.TailD_Bone), MemoryManager.StringToByteArray(BoneLoader.TailD.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.TailE_Bone), MemoryManager.StringToByteArray(BoneLoader.TailE.Replace(" ", string.Empty)));
                        }
                    }
                    #endregion
                    #region LeftLeg
                    if (LeftLegAdvLoad.IsChecked == true)
                    {
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LegsLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.LegLeft.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.KneeLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.KneeLeft.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.CalfLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.CalfLeft.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.PoleynLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.PoleynLeft.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.FootLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.FootLeft.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ToesLeft_Bone), MemoryManager.StringToByteArray(BoneLoader.ToesLeft.Replace(" ", string.Empty)));
                    }
                    #endregion
                    #region RightLeg
                    if (RightLegAdvLoad.IsChecked == true)
                    {
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LegsRight_Bone), MemoryManager.StringToByteArray(BoneLoader.LegRight.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.KneeRight_Bone), MemoryManager.StringToByteArray(BoneLoader.KneeRight.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.CalfRight_Bone), MemoryManager.StringToByteArray(BoneLoader.CalfRight.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.PoleynRight_Bone), MemoryManager.StringToByteArray(BoneLoader.PoleynRight.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.FootRight_Bone), MemoryManager.StringToByteArray(BoneLoader.FootRight.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ToesRight_Bone), MemoryManager.StringToByteArray(BoneLoader.ToesRight.Replace(" ", string.Empty)));
                    }
                    #endregion
                    #region Helm
                    if (HelmAdvLoad.IsChecked == true)
                    {
                        var HelmValue = m.readByte(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMet_Value));

                        if (HelmValue >= 2)
                        {
                            if (BoneLoader.ExMetA != "null")
                            {
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetA_Bone), MemoryManager.StringToByteArray(BoneLoader.ExMetA.Replace(" ", string.Empty)));
                            }
                        }
                        if (HelmValue >= 3)
                        {
                            if (BoneLoader.ExMetB != "null")
                            {
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetB_Bone), MemoryManager.StringToByteArray(BoneLoader.ExMetB.Replace(" ", string.Empty)));
                            }
                        }
                        if (HelmValue >= 4)
                        {
                            if (BoneLoader.ExMetC != "null")
                            {
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetC_Bone), MemoryManager.StringToByteArray(BoneLoader.ExMetC.Replace(" ", string.Empty)));
                            }
                        }
                        if (HelmValue >= 5)
                        {
                            if (BoneLoader.ExMetD != "null")
                            {
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetD_Bone), MemoryManager.StringToByteArray(BoneLoader.ExMetD.Replace(" ", string.Empty)));
                            }
                        }
                        if (HelmValue >= 6)
                        {
                            if (BoneLoader.ExMetE != "null")
                            {
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetE_Bone), MemoryManager.StringToByteArray(BoneLoader.ExMetE.Replace(" ", string.Empty)));
                            }
                        }
                        if (HelmValue >= 7)
                        {
                            if (BoneLoader.ExMetF != "null")
                            {
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetF_Bone), MemoryManager.StringToByteArray(BoneLoader.ExMetF.Replace(" ", string.Empty)));
                            }
                        }
                        if (HelmValue >= 8)
                        {
                            if (BoneLoader.ExMetG != "null")
                            {
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetG_Bone), MemoryManager.StringToByteArray(BoneLoader.ExMetG.Replace(" ", string.Empty)));
                            }
                        }
                        if (HelmValue >= 9)
                        {
                            if (BoneLoader.ExMetH != "null")
                            {
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetH_Bone), MemoryManager.StringToByteArray(BoneLoader.ExMetH.Replace(" ", string.Empty)));
                            }
                        }
                        if (HelmValue >= 10)
                        {
                            if (BoneLoader.ExMetI != "null")
                            {
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetI_Bone), MemoryManager.StringToByteArray(BoneLoader.ExMetI.Replace(" ", string.Empty)));
                            }
                        }
                        if (HelmValue >= 11)
                        {
                            if (BoneLoader.ExMetJ != "null")
                            {
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetJ_Bone), MemoryManager.StringToByteArray(BoneLoader.ExMetJ.Replace(" ", string.Empty)));
                            }
                        }
                        if (HelmValue >= 12)
                        {
                            if (BoneLoader.ExMetK != "null")
                            {
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetK_Bone), MemoryManager.StringToByteArray(BoneLoader.ExMetK.Replace(" ", string.Empty)));
                            }
                        }
                        if (HelmValue >= 13)
                        {
                            if (BoneLoader.ExMetL != "null")
                            {
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetL_Bone), MemoryManager.StringToByteArray(BoneLoader.ExMetL.Replace(" ", string.Empty)));
                            }
                        }
                        if (HelmValue >= 14)
                        {
                            if (BoneLoader.ExMetM != "null")
                            {
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetM_Bone), MemoryManager.StringToByteArray(BoneLoader.ExMetM.Replace(" ", string.Empty)));
                            }
                        }
                        if (HelmValue >= 15)
                        {
                            if (BoneLoader.ExMetN != "null")
                            {
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetN_Bone), MemoryManager.StringToByteArray(BoneLoader.ExMetN.Replace(" ", string.Empty)));
                            }
                        }
                        if (HelmValue >= 16)
                        {
                            if (BoneLoader.ExMetO != "null")
                            {
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetO_Bone), MemoryManager.StringToByteArray(BoneLoader.ExMetO.Replace(" ", string.Empty)));
                            }
                        }
                        if (HelmValue >= 17)
                        {
                            if (BoneLoader.ExMetP != "null")
                            {
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetP_Bone), MemoryManager.StringToByteArray(BoneLoader.ExMetP.Replace(" ", string.Empty)));
                            }
                        }
                        if (HelmValue >= 18)
                        {
                            if (BoneLoader.ExMetQ != "null")
                            {
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetQ_Bone), MemoryManager.StringToByteArray(BoneLoader.ExMetQ.Replace(" ", string.Empty)));
                            }
                        }
                        if (HelmValue >= 19)
                        {
                            if (BoneLoader.ExMetR != "null")
                            {
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetR_Bone), MemoryManager.StringToByteArray(BoneLoader.ExMetR.Replace(" ", string.Empty)));
                            }
                        }
                    }
                    #endregion
                    #region Top
                    if (TopAdvLoad.IsChecked == true)
                    {
                        var TopValue = m.readByte(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExTop_Value));

                        if (TopValue >= 2)
                        {
                            if (BoneLoader.ExTopA != "null")
                            {
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExTopA_Bone), MemoryManager.StringToByteArray(BoneLoader.ExTopA.Replace(" ", string.Empty)));
                            }
                        }
                        if (TopValue >= 3)
                        {
                            if (BoneLoader.ExTopB != "null")
                            {
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExTopB_Bone), MemoryManager.StringToByteArray(BoneLoader.ExTopB.Replace(" ", string.Empty)));
                            }
                        }
                        if (TopValue >= 4)
                        {
                            if (BoneLoader.ExTopC != "null")
                            {
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExTopC_Bone), MemoryManager.StringToByteArray(BoneLoader.ExTopC.Replace(" ", string.Empty)));
                            }
                        }
                        if (TopValue >= 5)
                        {
                            if (BoneLoader.ExTopD != "null")
                            {
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExTopD_Bone), MemoryManager.StringToByteArray(BoneLoader.ExTopD.Replace(" ", string.Empty)));
                            }
                        }
                        if (TopValue >= 6)
                        {
                            if (BoneLoader.ExTopE != "null")
                            {
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExTopE_Bone), MemoryManager.StringToByteArray(BoneLoader.ExTopE.Replace(" ", string.Empty)));
                            }
                        }
                        if (TopValue >= 7)
                        {
                            if (BoneLoader.ExTopF != "null")
                            {
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExTopF_Bone), MemoryManager.StringToByteArray(BoneLoader.ExTopF.Replace(" ", string.Empty)));
                            }
                        }
                        if (TopValue >= 8)
                        {
                            if (BoneLoader.ExTopG != "null")
                            {
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExTopG_Bone), MemoryManager.StringToByteArray(BoneLoader.ExTopG.Replace(" ", string.Empty)));
                            }
                        }
                        if (TopValue >= 9)
                        {
                            if (BoneLoader.ExTopH != "null")
                            {
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExTopH_Bone), MemoryManager.StringToByteArray(BoneLoader.ExTopH.Replace(" ", string.Empty)));
                            }
                        }
                        if (TopValue >= 10)
                        {
                            if (BoneLoader.ExTopI != "null")
                            {
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExTopI_Bone), MemoryManager.StringToByteArray(BoneLoader.ExTopI.Replace(" ", string.Empty)));
                            }
                        }
                    }
                    #endregion

                    #region Scale Bones

                    #region Head
                    if (HeadAdvLoad.IsChecked == true)
                    {
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.Head_Size), MemoryManager.StringToByteArray(BoneLoader.HeadSize.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EarLeft_Size), MemoryManager.StringToByteArray(BoneLoader.EarLeftSize.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EarRight_Size), MemoryManager.StringToByteArray(BoneLoader.EarRightSize.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.Jaw_Size), MemoryManager.StringToByteArray(BoneLoader.JawSize.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyelidLowerLeft_Size), MemoryManager.StringToByteArray(BoneLoader.EyelidLowerLeftSize.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyelidLowerRight_Size), MemoryManager.StringToByteArray(BoneLoader.EyelidLowerRightSize.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyeLeft_Size), MemoryManager.StringToByteArray(BoneLoader.EyeLeftSize.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyeRight_Size), MemoryManager.StringToByteArray(BoneLoader.EyeRightSize.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.Nose_Size), MemoryManager.StringToByteArray(BoneLoader.NoseSize.Replace(" ", string.Empty)));
                        if (CharacterDetails.Race.value < 7)
                        {
                            if (BoneLoader.Race == "01" || BoneLoader.Race == "02" || BoneLoader.Race == "03" || BoneLoader.Race == "04" || BoneLoader.Race == "05" || BoneLoader.Race == "06")
                            {
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.CheekLeft_Size), MemoryManager.StringToByteArray(BoneLoader.CheekLeftSize.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.CheekRight_Size), MemoryManager.StringToByteArray(BoneLoader.CheekRightSize.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipsLeft_Size), MemoryManager.StringToByteArray(BoneLoader.LipsLeftSize.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipsRight_Size), MemoryManager.StringToByteArray(BoneLoader.LipsRightSize.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyebrowLeft_Size), MemoryManager.StringToByteArray(BoneLoader.EyebrowLeftSize.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyebrowRight_Size), MemoryManager.StringToByteArray(BoneLoader.EyebrowRightSize.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.Bridge_Size), MemoryManager.StringToByteArray(BoneLoader.BridgeSize.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.BrowLeft_Size), MemoryManager.StringToByteArray(BoneLoader.BrowLeftSize.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.BrowRight_Size), MemoryManager.StringToByteArray(BoneLoader.BrowRightSize.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipUpperA_Size), MemoryManager.StringToByteArray(BoneLoader.LipUpperASize.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyelidUpperLeft_Size), MemoryManager.StringToByteArray(BoneLoader.EyelidUpperLeftSize.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyelidUpperRight_Size), MemoryManager.StringToByteArray(BoneLoader.EyelidUpperRightSize.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipLowerA_Size), MemoryManager.StringToByteArray(BoneLoader.LipLowerASize.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipUpperB_Size), MemoryManager.StringToByteArray(BoneLoader.LipUpperBSize.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipLowerB_Size), MemoryManager.StringToByteArray(BoneLoader.LipLowerBSize.Replace(" ", string.Empty)));
                            }
                            if (BoneLoader.Race == "07")
                            {
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.CheekLeft_Size), MemoryManager.StringToByteArray(BoneLoader.HrothLipUpperLeftSize.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.CheekRight_Size), MemoryManager.StringToByteArray(BoneLoader.HrothLipUpperRightSize.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipsLeft_Size), MemoryManager.StringToByteArray(BoneLoader.HrothLipsLeftSize.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipsRight_Size), MemoryManager.StringToByteArray(BoneLoader.HrothLipsRightSize.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyebrowLeft_Size), MemoryManager.StringToByteArray(BoneLoader.HrothEyebrowLeftSize.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyebrowRight_Size), MemoryManager.StringToByteArray(BoneLoader.HrothEyebrowRightSize.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.Bridge_Size), MemoryManager.StringToByteArray(BoneLoader.HrothBridgeSize.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.BrowLeft_Size), MemoryManager.StringToByteArray(BoneLoader.HrothBrowLeftSize.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.BrowRight_Size), MemoryManager.StringToByteArray(BoneLoader.HrothBrowRightSize.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipUpperA_Size), MemoryManager.StringToByteArray(BoneLoader.HrothLipUpperSize.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyelidUpperLeft_Size), MemoryManager.StringToByteArray(BoneLoader.HrothEyelidUpperLeftSize.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyelidUpperRight_Size), MemoryManager.StringToByteArray(BoneLoader.HrothEyelidUpperRightSize.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipUpperB_Size), MemoryManager.StringToByteArray(BoneLoader.HrothJawUpperSize.Replace(" ", string.Empty)));
                            }
                            if (BoneLoader.Race == "08")
                            {
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.CheekLeft_Size), MemoryManager.StringToByteArray(BoneLoader.CheekLeftSize.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.CheekRight_Size), MemoryManager.StringToByteArray(BoneLoader.CheekRightSize.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipsLeft_Size), MemoryManager.StringToByteArray(BoneLoader.LipsLeftSize.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipsRight_Size), MemoryManager.StringToByteArray(BoneLoader.LipsRightSize.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyebrowLeft_Size), MemoryManager.StringToByteArray(BoneLoader.EyebrowLeftSize.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyebrowRight_Size), MemoryManager.StringToByteArray(BoneLoader.EyebrowRightSize.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.Bridge_Size), MemoryManager.StringToByteArray(BoneLoader.BridgeSize.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.BrowLeft_Size), MemoryManager.StringToByteArray(BoneLoader.BrowLeftSize.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.BrowRight_Size), MemoryManager.StringToByteArray(BoneLoader.BrowRightSize.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipUpperA_Size), MemoryManager.StringToByteArray(BoneLoader.LipUpperASize.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyelidUpperLeft_Size), MemoryManager.StringToByteArray(BoneLoader.EyelidUpperLeftSize.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyelidUpperRight_Size), MemoryManager.StringToByteArray(BoneLoader.EyelidUpperRightSize.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipLowerA_Size), MemoryManager.StringToByteArray(BoneLoader.VieraLipLowerASize.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipUpperB_Size), MemoryManager.StringToByteArray(BoneLoader.VieraLipUpperBSize.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipLowerB_Size), MemoryManager.StringToByteArray(BoneLoader.VieraLipLowerBSize.Replace(" ", string.Empty)));
                            }
                        }
                        if (CharacterDetails.Race.value == 7)
                        {
                            if (BoneLoader.Race == "01" || BoneLoader.Race == "02" || BoneLoader.Race == "03" || BoneLoader.Race == "04" || BoneLoader.Race == "05" || BoneLoader.Race == "06")
                            {
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothEyebrowLeft_Size), MemoryManager.StringToByteArray(BoneLoader.EyebrowLeftSize.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothEyebrowRight_Size), MemoryManager.StringToByteArray(BoneLoader.EyebrowRightSize.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothBridge_Size), MemoryManager.StringToByteArray(BoneLoader.BridgeSize.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothBrowLeft_Size), MemoryManager.StringToByteArray(BoneLoader.BrowLeftSize.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothBrowRight_Size), MemoryManager.StringToByteArray(BoneLoader.BrowRightSize.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothJawUpper_Size), MemoryManager.StringToByteArray(BoneLoader.LipUpperBSize.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothLipUpper_Size), MemoryManager.StringToByteArray(BoneLoader.LipUpperASize.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothEyelidUpperLeft_Size), MemoryManager.StringToByteArray(BoneLoader.EyelidUpperLeftSize.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothEyelidUpperRight_Size), MemoryManager.StringToByteArray(BoneLoader.EyelidUpperRightSize.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothLipsLeft_Size), MemoryManager.StringToByteArray(BoneLoader.LipsLeftSize.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothLipsRight_Size), MemoryManager.StringToByteArray(BoneLoader.LipsRightSize.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothLipUpperLeft_Size), MemoryManager.StringToByteArray(BoneLoader.CheekLeftSize.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothLipUpperRight_Size), MemoryManager.StringToByteArray(BoneLoader.CheekRightSize.Replace(" ", string.Empty)));
                            }
                            if (BoneLoader.Race == "07")
                            {
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothWhiskersLeft_Size), MemoryManager.StringToByteArray(BoneLoader.HrothWhiskersLeftSize.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothWhiskersRight_Size), MemoryManager.StringToByteArray(BoneLoader.HrothWhiskersRightSize.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothEyebrowLeft_Size), MemoryManager.StringToByteArray(BoneLoader.HrothEyebrowLeftSize.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothEyebrowRight_Size), MemoryManager.StringToByteArray(BoneLoader.HrothEyebrowRightSize.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothBridge_Size), MemoryManager.StringToByteArray(BoneLoader.HrothBridgeSize.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothBrowLeft_Size), MemoryManager.StringToByteArray(BoneLoader.HrothBrowLeftSize.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothBrowRight_Size), MemoryManager.StringToByteArray(BoneLoader.HrothBrowRightSize.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothJawUpper_Size), MemoryManager.StringToByteArray(BoneLoader.HrothJawUpperSize.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothLipUpper_Size), MemoryManager.StringToByteArray(BoneLoader.HrothLipUpperSize.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothEyelidUpperLeft_Size), MemoryManager.StringToByteArray(BoneLoader.HrothEyelidUpperLeftSize.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothEyelidUpperRight_Size), MemoryManager.StringToByteArray(BoneLoader.HrothEyelidUpperRightSize.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothLipsLeft_Size), MemoryManager.StringToByteArray(BoneLoader.HrothLipsLeftSize.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothLipsRight_Size), MemoryManager.StringToByteArray(BoneLoader.HrothLipsRightSize.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothLipUpperLeft_Size), MemoryManager.StringToByteArray(BoneLoader.HrothLipUpperLeftSize.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothLipUpperRight_Size), MemoryManager.StringToByteArray(BoneLoader.HrothLipUpperRightSize.Replace(" ", string.Empty)));
                            }
                            if (BoneLoader.Race == "08")
                            {
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothEyebrowLeft_Size), MemoryManager.StringToByteArray(BoneLoader.EyebrowLeftSize.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothEyebrowRight_Size), MemoryManager.StringToByteArray(BoneLoader.EyebrowRightSize.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothBridge_Size), MemoryManager.StringToByteArray(BoneLoader.BridgeSize.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothBrowLeft_Size), MemoryManager.StringToByteArray(BoneLoader.BrowLeftSize.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothBrowRight_Size), MemoryManager.StringToByteArray(BoneLoader.BrowRightSize.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothJawUpper_Size), MemoryManager.StringToByteArray(BoneLoader.VieraLipUpperBSize.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothLipUpper_Size), MemoryManager.StringToByteArray(BoneLoader.LipUpperASize.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothEyelidUpperLeft_Size), MemoryManager.StringToByteArray(BoneLoader.EyelidUpperLeftSize.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothEyelidUpperRight_Size), MemoryManager.StringToByteArray(BoneLoader.EyelidUpperRightSize.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothLipsLeft_Size), MemoryManager.StringToByteArray(BoneLoader.LipsLeftSize.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothLipsRight_Size), MemoryManager.StringToByteArray(BoneLoader.LipsRightSize.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothLipUpperLeft_Size), MemoryManager.StringToByteArray(BoneLoader.CheekLeftSize.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothLipUpperRight_Size), MemoryManager.StringToByteArray(BoneLoader.CheekRightSize.Replace(" ", string.Empty)));
                            }
                        }
                        if (CharacterDetails.Race.value == 8)
                        {
                            if (BoneLoader.Race == "01" || BoneLoader.Race == "02" || BoneLoader.Race == "03" || BoneLoader.Race == "04" || BoneLoader.Race == "05" || BoneLoader.Race == "06")
                            {
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.CheekLeft_Size), MemoryManager.StringToByteArray(BoneLoader.CheekLeftSize.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.CheekRight_Size), MemoryManager.StringToByteArray(BoneLoader.CheekRightSize.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipsLeft_Size), MemoryManager.StringToByteArray(BoneLoader.LipsLeftSize.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipsRight_Size), MemoryManager.StringToByteArray(BoneLoader.LipsRightSize.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyebrowLeft_Size), MemoryManager.StringToByteArray(BoneLoader.EyebrowLeftSize.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyebrowRight_Size), MemoryManager.StringToByteArray(BoneLoader.EyebrowRightSize.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.Bridge_Size), MemoryManager.StringToByteArray(BoneLoader.BridgeSize.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.BrowLeft_Size), MemoryManager.StringToByteArray(BoneLoader.BrowLeftSize.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.BrowRight_Size), MemoryManager.StringToByteArray(BoneLoader.BrowRightSize.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipUpperA_Size), MemoryManager.StringToByteArray(BoneLoader.LipUpperASize.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyelidUpperLeft_Size), MemoryManager.StringToByteArray(BoneLoader.EyelidUpperLeftSize.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyelidUpperRight_Size), MemoryManager.StringToByteArray(BoneLoader.EyelidUpperRightSize.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraLipLowerA_Size), MemoryManager.StringToByteArray(BoneLoader.VieraEar01ALeftSize.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraLipUpperB_Size), MemoryManager.StringToByteArray(BoneLoader.VieraEar01ARightSize.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraLipLowerB_Size), MemoryManager.StringToByteArray(BoneLoader.VieraEar02ALeftSize.Replace(" ", string.Empty)));
                            }
                            if (BoneLoader.Race == "07")
                            {
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.CheekLeft_Size), MemoryManager.StringToByteArray(BoneLoader.HrothLipUpperLeftSize.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.CheekRight_Size), MemoryManager.StringToByteArray(BoneLoader.HrothLipUpperRightSize.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipsLeft_Size), MemoryManager.StringToByteArray(BoneLoader.HrothLipsLeftSize.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipsRight_Size), MemoryManager.StringToByteArray(BoneLoader.HrothLipsRightSize.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyebrowLeft_Size), MemoryManager.StringToByteArray(BoneLoader.HrothEyebrowLeftSize.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyebrowRight_Size), MemoryManager.StringToByteArray(BoneLoader.HrothEyebrowRightSize.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.Bridge_Size), MemoryManager.StringToByteArray(BoneLoader.HrothBridgeSize.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.BrowLeft_Size), MemoryManager.StringToByteArray(BoneLoader.HrothBrowLeftSize.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.BrowRight_Size), MemoryManager.StringToByteArray(BoneLoader.HrothBrowRightSize.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipUpperA_Size), MemoryManager.StringToByteArray(BoneLoader.HrothLipUpperSize.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyelidUpperLeft_Size), MemoryManager.StringToByteArray(BoneLoader.HrothEyelidUpperLeftSize.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyelidUpperRight_Size), MemoryManager.StringToByteArray(BoneLoader.HrothEyelidUpperRightSize.Replace(" ", string.Empty)));
                            }
                            if (BoneLoader.Race == "08")
                            {
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.CheekLeft_Size), MemoryManager.StringToByteArray(BoneLoader.CheekLeftSize.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.CheekRight_Size), MemoryManager.StringToByteArray(BoneLoader.CheekRightSize.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipsLeft_Size), MemoryManager.StringToByteArray(BoneLoader.LipsLeftSize.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipsRight_Size), MemoryManager.StringToByteArray(BoneLoader.LipsRightSize.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyebrowLeft_Size), MemoryManager.StringToByteArray(BoneLoader.EyebrowLeftSize.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyebrowRight_Size), MemoryManager.StringToByteArray(BoneLoader.EyebrowRightSize.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.Bridge_Size), MemoryManager.StringToByteArray(BoneLoader.BridgeSize.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.BrowLeft_Size), MemoryManager.StringToByteArray(BoneLoader.BrowLeftSize.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.BrowRight_Size), MemoryManager.StringToByteArray(BoneLoader.BrowRightSize.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipUpperA_Size), MemoryManager.StringToByteArray(BoneLoader.LipUpperASize.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyelidUpperLeft_Size), MemoryManager.StringToByteArray(BoneLoader.EyelidUpperLeftSize.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyelidUpperRight_Size), MemoryManager.StringToByteArray(BoneLoader.EyelidUpperRightSize.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar01ALeft_Size), MemoryManager.StringToByteArray(BoneLoader.VieraEar01ALeftSize.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar01ARight_Size), MemoryManager.StringToByteArray(BoneLoader.VieraEar01ARightSize.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar02ALeft_Size), MemoryManager.StringToByteArray(BoneLoader.VieraEar02ALeftSize.Replace(" ", string.Empty)));
                            }
                        }
                        if (BoneLoader.HrothLipLower != "null" || BoneLoader.VieraEar02ARight != "null")
                        {
                            if (CharacterDetails.Race.value == 7)
                            {
                                if (BoneLoader.Race == "07")
                                {
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothLipLower_Size), MemoryManager.StringToByteArray(BoneLoader.HrothLipLowerSize.Replace(" ", string.Empty)));
                                }
                            }
                            if (CharacterDetails.Race.value == 8)
                            {
                                if (BoneLoader.Race == "08")
                                {
                                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar02ARight_Size), MemoryManager.StringToByteArray(BoneLoader.VieraEar02ARightSize.Replace(" ", string.Empty)));
                                }
                            }
                        }
                        if (BoneLoader.VieraEar03ALeft != "null")
                        {
                            if (CharacterDetails.Race.value < 7)
                            {
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipLowerA_Size), MemoryManager.StringToByteArray(BoneLoader.VieraLipLowerASize.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipUpperB_Size), MemoryManager.StringToByteArray(BoneLoader.VieraLipUpperBSize.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipLowerB_Size), MemoryManager.StringToByteArray(BoneLoader.VieraLipLowerBSize.Replace(" ", string.Empty)));
                            }
                            if (CharacterDetails.Race.value == 8)
                            {
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar03ALeft_Size), MemoryManager.StringToByteArray(BoneLoader.VieraEar03ALeftSize.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar03ARight_Size), MemoryManager.StringToByteArray(BoneLoader.VieraEar03ARightSize.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar04ALeft_Size), MemoryManager.StringToByteArray(BoneLoader.VieraEar04ALeftSize.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar04ARight_Size), MemoryManager.StringToByteArray(BoneLoader.VieraEar04ARightSize.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraLipLowerA_Size), MemoryManager.StringToByteArray(BoneLoader.VieraLipLowerASize.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraLipUpperB_Size), MemoryManager.StringToByteArray(BoneLoader.VieraLipUpperBSize.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar01BLeft_Size), MemoryManager.StringToByteArray(BoneLoader.VieraEar01BLeftSize.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar01BRight_Size), MemoryManager.StringToByteArray(BoneLoader.VieraEar01BRightSize.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar02BLeft_Size), MemoryManager.StringToByteArray(BoneLoader.VieraEar02BLeftSize.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar02BRight_Size), MemoryManager.StringToByteArray(BoneLoader.VieraEar02BRightSize.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar03BLeft_Size), MemoryManager.StringToByteArray(BoneLoader.VieraEar03BLeftSize.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar03BRight_Size), MemoryManager.StringToByteArray(BoneLoader.VieraEar03BRightSize.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar04BLeft_Size), MemoryManager.StringToByteArray(BoneLoader.VieraEar04BLeftSize.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar04BRight_Size), MemoryManager.StringToByteArray(BoneLoader.VieraEar04BRightSize.Replace(" ", string.Empty)));
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraLipLowerB_Size), MemoryManager.StringToByteArray(BoneLoader.VieraLipLowerBSize.Replace(" ", string.Empty)));
                            }
                        }
                    }
                    #endregion
                    #region Hair
                    if (HairAdvLoad.IsChecked == true)
                    {
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HairA_Size), MemoryManager.StringToByteArray(BoneLoader.HairASize.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HairFrontLeft_Size), MemoryManager.StringToByteArray(BoneLoader.HairFrontLeftSize.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HairFrontRight_Size), MemoryManager.StringToByteArray(BoneLoader.HairFrontRightSize.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HairB_Size), MemoryManager.StringToByteArray(BoneLoader.HairBSize.Replace(" ", string.Empty)));
                        var HairValue = m.readByte(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExHair_Value));

                        if (HairValue >= 2)
                        {
                            if (BoneLoader.ExHairA != "null")
                            {
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExHairA_Size), MemoryManager.StringToByteArray(BoneLoader.ExHairASize.Replace(" ", string.Empty)));
                            }
                        }
                        if (HairValue >= 3)
                        {
                            if (BoneLoader.ExHairB != "null")
                            {
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExHairB_Size), MemoryManager.StringToByteArray(BoneLoader.ExHairBSize.Replace(" ", string.Empty)));
                            }
                        }
                        if (HairValue >= 4)
                        {
                            if (BoneLoader.ExHairC != "null")
                            {
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExHairC_Size), MemoryManager.StringToByteArray(BoneLoader.ExHairCSize.Replace(" ", string.Empty)));
                            }
                        }
                        if (HairValue >= 5)
                        {
                            if (BoneLoader.ExHairD != "null")
                            {
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExHairD_Size), MemoryManager.StringToByteArray(BoneLoader.ExHairDSize.Replace(" ", string.Empty)));
                            }
                        }
                        if (HairValue >= 6)
                        {
                            if (BoneLoader.ExHairE != "null")
                            {
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExHairE_Size), MemoryManager.StringToByteArray(BoneLoader.ExHairESize.Replace(" ", string.Empty)));
                            }
                        }
                        if (HairValue >= 7)
                        {
                            if (BoneLoader.ExHairF != "null")
                            {
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExHairF_Size), MemoryManager.StringToByteArray(BoneLoader.ExHairFSize.Replace(" ", string.Empty)));
                            }
                        }
                        if (HairValue >= 8)
                        {
                            if (BoneLoader.ExHairG != "null")
                            {
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExHairG_Size), MemoryManager.StringToByteArray(BoneLoader.ExHairGSize.Replace(" ", string.Empty)));
                            }
                        }
                        if (HairValue >= 9)
                        {
                            if (BoneLoader.ExHairH != "null")
                            {
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExHairH_Size), MemoryManager.StringToByteArray(BoneLoader.ExHairHSize.Replace(" ", string.Empty)));
                            }
                        }
                        if (HairValue >= 10)
                        {
                            if (BoneLoader.ExHairI != "null")
                            {
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExHairI_Size), MemoryManager.StringToByteArray(BoneLoader.ExHairISize.Replace(" ", string.Empty)));
                            }
                        }
                        if (HairValue >= 11)
                        {
                            if (BoneLoader.ExHairJ != "null")
                            {
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExHairJ_Size), MemoryManager.StringToByteArray(BoneLoader.ExHairJSize.Replace(" ", string.Empty)));
                            }
                        }
                        if (HairValue >= 12)
                        {
                            if (BoneLoader.ExHairK != "null")
                            {
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExHairK_Size), MemoryManager.StringToByteArray(BoneLoader.ExHairKSize.Replace(" ", string.Empty)));
                            }
                        }
                        if (HairValue >= 13)
                        {
                            if (BoneLoader.ExHairL != "null")
                            {
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExHairL_Size), MemoryManager.StringToByteArray(BoneLoader.ExHairLSize.Replace(" ", string.Empty)));
                            }
                        }
                    }
                    #endregion
                    #region Body
                    if (BodyAdvLoad.IsChecked == true)
                    {
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.SpineA_Size), MemoryManager.StringToByteArray(BoneLoader.SpineASize.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.SpineB_Size), MemoryManager.StringToByteArray(BoneLoader.SpineBSize.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.BreastLeft_Size), MemoryManager.StringToByteArray(BoneLoader.BreastLeftSize.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.BreastRight_Size), MemoryManager.StringToByteArray(BoneLoader.BreastRightSize.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.SpineC_Size), MemoryManager.StringToByteArray(BoneLoader.SpineCSize.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.Neck_Size), MemoryManager.StringToByteArray(BoneLoader.NeckSize.Replace(" ", string.Empty)));
                    }
                    #endregion
                    #region LeftArm
                    if (LeftArmAdvLoad.IsChecked == true)
                    {
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClavicleLeft_Size), MemoryManager.StringToByteArray(BoneLoader.ClavicleLeftSize.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ArmLeft_Size), MemoryManager.StringToByteArray(BoneLoader.ArmLeftSize.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ForearmLeft_Size), MemoryManager.StringToByteArray(BoneLoader.ForearmLeftSize.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ShoulderLeft_Size), MemoryManager.StringToByteArray(BoneLoader.ShoulderLeftSize.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ElbowLeft_Size), MemoryManager.StringToByteArray(BoneLoader.ElbowLeftSize.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.CouterLeft_Size), MemoryManager.StringToByteArray(BoneLoader.CouterLeftSize.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.WristLeft_Size), MemoryManager.StringToByteArray(BoneLoader.WristLeftSize.Replace(" ", string.Empty)));
                    }
                    #endregion
                    #region RightArm
                    if (RightArmAdvLoad.IsChecked == true)
                    {
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClavicleRight_Size), MemoryManager.StringToByteArray(BoneLoader.ClavicleRightSize.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ArmRight_Size), MemoryManager.StringToByteArray(BoneLoader.ArmRightSize.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ForearmRight_Size), MemoryManager.StringToByteArray(BoneLoader.ForearmRightSize.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ShoulderRight_Size), MemoryManager.StringToByteArray(BoneLoader.ShoulderRightSize.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ElbowRight_Size), MemoryManager.StringToByteArray(BoneLoader.ElbowRightSize.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.CouterRight_Size), MemoryManager.StringToByteArray(BoneLoader.CouterRightSize.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.WristRight_Size), MemoryManager.StringToByteArray(BoneLoader.WristRightSize.Replace(" ", string.Empty)));
                    }
                    #endregion
                    #region Clothes
                    if (ClothesAdvLoad.IsChecked == true)
                    {
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothBackALeft_Size), MemoryManager.StringToByteArray(BoneLoader.ClothBackALeftSize.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothBackARight_Size), MemoryManager.StringToByteArray(BoneLoader.ClothBackARightSize.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothFrontALeft_Size), MemoryManager.StringToByteArray(BoneLoader.ClothFrontALeftSize.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothFrontARight_Size), MemoryManager.StringToByteArray(BoneLoader.ClothFrontARightSize.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothSideALeft_Size), MemoryManager.StringToByteArray(BoneLoader.ClothSideALeftSize.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothSideARight_Size), MemoryManager.StringToByteArray(BoneLoader.ClothSideARightSize.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothBackBLeft_Size), MemoryManager.StringToByteArray(BoneLoader.ClothBackBLeftSize.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothBackBRight_Size), MemoryManager.StringToByteArray(BoneLoader.ClothBackBRightSize.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothFrontBLeft_Size), MemoryManager.StringToByteArray(BoneLoader.ClothFrontBLeftSize.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothFrontBRight_Size), MemoryManager.StringToByteArray(BoneLoader.ClothFrontBRightSize.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothSideBLeft_Size), MemoryManager.StringToByteArray(BoneLoader.ClothSideBLeftSize.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothSideBRight_Size), MemoryManager.StringToByteArray(BoneLoader.ClothSideBRightSize.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothBackCLeft_Size), MemoryManager.StringToByteArray(BoneLoader.ClothBackCLeftSize.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothBackCRight_Size), MemoryManager.StringToByteArray(BoneLoader.ClothBackCRightSize.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothFrontCLeft_Size), MemoryManager.StringToByteArray(BoneLoader.ClothFrontCLeftSize.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothFrontCRight_Size), MemoryManager.StringToByteArray(BoneLoader.ClothFrontCRightSize.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothSideCLeft_Size), MemoryManager.StringToByteArray(BoneLoader.ClothSideCLeftSize.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothSideCRight_Size), MemoryManager.StringToByteArray(BoneLoader.ClothSideCRightSize.Replace(" ", string.Empty)));
                    }
                    #endregion
                    #region LeftHand
                    if (LeftHandAdvLoad.IsChecked == true)
                    {
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HandLeft_Size), MemoryManager.StringToByteArray(BoneLoader.HandLeftSize.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.IndexALeft_Size), MemoryManager.StringToByteArray(BoneLoader.IndexALeftSize.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.PinkyALeft_Size), MemoryManager.StringToByteArray(BoneLoader.PinkyALeftSize.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.RingALeft_Size), MemoryManager.StringToByteArray(BoneLoader.RingALeftSize.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.MiddleALeft_Size), MemoryManager.StringToByteArray(BoneLoader.MiddleALeftSize.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ThumbALeft_Size), MemoryManager.StringToByteArray(BoneLoader.ThumbALeftSize.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.IndexBLeft_Size), MemoryManager.StringToByteArray(BoneLoader.IndexBLeftSize.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.PinkyBLeft_Size), MemoryManager.StringToByteArray(BoneLoader.PinkyBLeftSize.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.RingBLeft_Size), MemoryManager.StringToByteArray(BoneLoader.RingBLeftSize.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.MiddleBLeft_Size), MemoryManager.StringToByteArray(BoneLoader.MiddleBLeftSize.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ThumbBLeft_Size), MemoryManager.StringToByteArray(BoneLoader.ThumbBLeftSize.Replace(" ", string.Empty)));
                    }
                    #endregion
                    #region RightHand
                    if (RightHandAdvLoad.IsChecked == true)
                    {
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HandRight_Size), MemoryManager.StringToByteArray(BoneLoader.HandRightSize.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.IndexARight_Size), MemoryManager.StringToByteArray(BoneLoader.IndexARightSize.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.PinkyARight_Size), MemoryManager.StringToByteArray(BoneLoader.PinkyARightSize.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.RingARight_Size), MemoryManager.StringToByteArray(BoneLoader.RingARightSize.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.MiddleARight_Size), MemoryManager.StringToByteArray(BoneLoader.MiddleARightSize.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ThumbARight_Size), MemoryManager.StringToByteArray(BoneLoader.ThumbARightSize.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.IndexBRight_Size), MemoryManager.StringToByteArray(BoneLoader.IndexBRightSize.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.PinkyBRight_Size), MemoryManager.StringToByteArray(BoneLoader.PinkyBRightSize.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.RingBRight_Size), MemoryManager.StringToByteArray(BoneLoader.RingBRightSize.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.MiddleBRight_Size), MemoryManager.StringToByteArray(BoneLoader.MiddleBRightSize.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ThumbBRight_Size), MemoryManager.StringToByteArray(BoneLoader.ThumbBRightSize.Replace(" ", string.Empty)));
                    }
                    #endregion
                    #region Waist
                    if (WaistAdvLoad.IsChecked == true)
                    {
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.Waist_Size), MemoryManager.StringToByteArray(BoneLoader.WaistSize.Replace(" ", string.Empty)));
                        if (BoneLoader.TailA != "null")
                        {
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.TailA_Size), MemoryManager.StringToByteArray(BoneLoader.TailASize.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.TailB_Size), MemoryManager.StringToByteArray(BoneLoader.TailBSize.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.TailC_Size), MemoryManager.StringToByteArray(BoneLoader.TailCSize.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.TailD_Size), MemoryManager.StringToByteArray(BoneLoader.TailDSize.Replace(" ", string.Empty)));
                            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.TailE_Size), MemoryManager.StringToByteArray(BoneLoader.TailESize.Replace(" ", string.Empty)));
                        }
                    }
                    #endregion
                    #region LeftLeg
                    if (LeftLegAdvLoad.IsChecked == true)
                    {
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LegsLeft_Size), MemoryManager.StringToByteArray(BoneLoader.LegLeftSize.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.KneeLeft_Size), MemoryManager.StringToByteArray(BoneLoader.KneeLeftSize.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.CalfLeft_Size), MemoryManager.StringToByteArray(BoneLoader.CalfLeftSize.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.PoleynLeft_Size), MemoryManager.StringToByteArray(BoneLoader.PoleynLeftSize.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.FootLeft_Size), MemoryManager.StringToByteArray(BoneLoader.FootLeftSize.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ToesLeft_Size), MemoryManager.StringToByteArray(BoneLoader.ToesLeftSize.Replace(" ", string.Empty)));
                    }
                    #endregion
                    #region RightLeg
                    if (RightLegAdvLoad.IsChecked == true)
                    {
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LegsRight_Size), MemoryManager.StringToByteArray(BoneLoader.LegRightSize.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.KneeRight_Size), MemoryManager.StringToByteArray(BoneLoader.KneeRightSize.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.CalfRight_Size), MemoryManager.StringToByteArray(BoneLoader.CalfRightSize.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.PoleynRight_Size), MemoryManager.StringToByteArray(BoneLoader.PoleynRightSize.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.FootRight_Size), MemoryManager.StringToByteArray(BoneLoader.FootRightSize.Replace(" ", string.Empty)));
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ToesRight_Size), MemoryManager.StringToByteArray(BoneLoader.ToesRightSize.Replace(" ", string.Empty)));
                    }
                    #endregion
                    #region Helm
                    if (HelmAdvLoad.IsChecked == true)
                    {
                        var HelmValue = m.readByte(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMet_Value));

                        if (HelmValue >= 2)
                        {
                            if (BoneLoader.ExMetA != "null")
                            {
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetA_Size), MemoryManager.StringToByteArray(BoneLoader.ExMetASize.Replace(" ", string.Empty)));
                            }
                        }
                        if (HelmValue >= 3)
                        {
                            if (BoneLoader.ExMetB != "null")
                            {
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetB_Size), MemoryManager.StringToByteArray(BoneLoader.ExMetBSize.Replace(" ", string.Empty)));
                            }
                        }
                        if (HelmValue >= 4)
                        {
                            if (BoneLoader.ExMetC != "null")
                            {
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetC_Size), MemoryManager.StringToByteArray(BoneLoader.ExMetCSize.Replace(" ", string.Empty)));
                            }
                        }
                        if (HelmValue >= 5)
                        {
                            if (BoneLoader.ExMetD != "null")
                            {
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetD_Size), MemoryManager.StringToByteArray(BoneLoader.ExMetDSize.Replace(" ", string.Empty)));
                            }
                        }
                        if (HelmValue >= 6)
                        {
                            if (BoneLoader.ExMetE != "null")
                            {
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetE_Size), MemoryManager.StringToByteArray(BoneLoader.ExMetESize.Replace(" ", string.Empty)));
                            }
                        }
                        if (HelmValue >= 7)
                        {
                            if (BoneLoader.ExMetF != "null")
                            {
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetF_Size), MemoryManager.StringToByteArray(BoneLoader.ExMetFSize.Replace(" ", string.Empty)));
                            }
                        }
                        if (HelmValue >= 8)
                        {
                            if (BoneLoader.ExMetG != "null")
                            {
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetG_Size), MemoryManager.StringToByteArray(BoneLoader.ExMetGSize.Replace(" ", string.Empty)));
                            }
                        }
                        if (HelmValue >= 9)
                        {
                            if (BoneLoader.ExMetH != "null")
                            {
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetH_Size), MemoryManager.StringToByteArray(BoneLoader.ExMetHSize.Replace(" ", string.Empty)));
                            }
                        }
                        if (HelmValue >= 10)
                        {
                            if (BoneLoader.ExMetI != "null")
                            {
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetI_Size), MemoryManager.StringToByteArray(BoneLoader.ExMetISize.Replace(" ", string.Empty)));
                            }
                        }
                        if (HelmValue >= 11)
                        {
                            if (BoneLoader.ExMetJ != "null")
                            {
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetJ_Size), MemoryManager.StringToByteArray(BoneLoader.ExMetJSize.Replace(" ", string.Empty)));
                            }
                        }
                        if (HelmValue >= 12)
                        {
                            if (BoneLoader.ExMetK != "null")
                            {
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetK_Size), MemoryManager.StringToByteArray(BoneLoader.ExMetKSize.Replace(" ", string.Empty)));
                            }
                        }
                        if (HelmValue >= 13)
                        {
                            if (BoneLoader.ExMetL != "null")
                            {
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetL_Size), MemoryManager.StringToByteArray(BoneLoader.ExMetLSize.Replace(" ", string.Empty)));
                            }
                        }
                        if (HelmValue >= 14)
                        {
                            if (BoneLoader.ExMetM != "null")
                            {
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetM_Size), MemoryManager.StringToByteArray(BoneLoader.ExMetMSize.Replace(" ", string.Empty)));
                            }
                        }
                        if (HelmValue >= 15)
                        {
                            if (BoneLoader.ExMetN != "null")
                            {
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetN_Size), MemoryManager.StringToByteArray(BoneLoader.ExMetNSize.Replace(" ", string.Empty)));
                            }
                        }
                        if (HelmValue >= 16)
                        {
                            if (BoneLoader.ExMetO != "null")
                            {
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetO_Size), MemoryManager.StringToByteArray(BoneLoader.ExMetOSize.Replace(" ", string.Empty)));
                            }
                        }
                        if (HelmValue >= 17)
                        {
                            if (BoneLoader.ExMetP != "null")
                            {
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetP_Size), MemoryManager.StringToByteArray(BoneLoader.ExMetPSize.Replace(" ", string.Empty)));
                            }
                        }
                        if (HelmValue >= 18)
                        {
                            if (BoneLoader.ExMetQ != "null")
                            {
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetQ_Size), MemoryManager.StringToByteArray(BoneLoader.ExMetQSize.Replace(" ", string.Empty)));
                            }
                        }
                        if (HelmValue >= 19)
                        {
                            if (BoneLoader.ExMetR != "null")
                            {
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetR_Size), MemoryManager.StringToByteArray(BoneLoader.ExMetRSize.Replace(" ", string.Empty)));
                            }
                        }
                    }
                    #endregion
                    #region Top
                    if (TopAdvLoad.IsChecked == true)
                    {
                        var TopValue = m.readByte(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExTop_Value));

                        if (TopValue >= 2)
                        {
                            if (BoneLoader.ExTopA != "null")
                            {
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExTopA_Size), MemoryManager.StringToByteArray(BoneLoader.ExTopASize.Replace(" ", string.Empty)));
                            }
                        }
                        if (TopValue >= 3)
                        {
                            if (BoneLoader.ExTopB != "null")
                            {
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExTopB_Size), MemoryManager.StringToByteArray(BoneLoader.ExTopBSize.Replace(" ", string.Empty)));
                            }
                        }
                        if (TopValue >= 4)
                        {
                            if (BoneLoader.ExTopC != "null")
                            {
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExTopC_Size), MemoryManager.StringToByteArray(BoneLoader.ExTopCSize.Replace(" ", string.Empty)));
                            }
                        }
                        if (TopValue >= 5)
                        {
                            if (BoneLoader.ExTopD != "null")
                            {
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExTopD_Size), MemoryManager.StringToByteArray(BoneLoader.ExTopDSize.Replace(" ", string.Empty)));
                            }
                        }
                        if (TopValue >= 6)
                        {
                            if (BoneLoader.ExTopE != "null")
                            {
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExTopE_Size), MemoryManager.StringToByteArray(BoneLoader.ExTopESize.Replace(" ", string.Empty)));
                            }
                        }
                        if (TopValue >= 7)
                        {
                            if (BoneLoader.ExTopF != "null")
                            {
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExTopF_Size), MemoryManager.StringToByteArray(BoneLoader.ExTopFSize.Replace(" ", string.Empty)));
                            }
                        }
                        if (TopValue >= 8)
                        {
                            if (BoneLoader.ExTopG != "null")
                            {
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExTopG_Size), MemoryManager.StringToByteArray(BoneLoader.ExTopGSize.Replace(" ", string.Empty)));
                            }
                        }
                        if (TopValue >= 9)
                        {
                            if (BoneLoader.ExTopH != "null")
                            {
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExTopH_Size), MemoryManager.StringToByteArray(BoneLoader.ExTopHSize.Replace(" ", string.Empty)));
                            }
                        }
                        if (TopValue >= 10)
                        {
                            if (BoneLoader.ExTopI != "null")
                            {
                                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExTopI_Size), MemoryManager.StringToByteArray(BoneLoader.ExTopISize.Replace(" ", string.Empty)));
                            }
                        }
                    }
                    #endregion

                    #endregion

                }
            }
            else return;
        }
        private void SelectAll_Click(object sender, RoutedEventArgs e)
        {
            HeadAdvLoad.IsChecked = true;
            HairAdvLoad.IsChecked = true;
            EarringsAdvLoad.IsChecked = true;
            BodyAdvLoad.IsChecked = true;
            LeftArmAdvLoad.IsChecked = true;
            RightArmAdvLoad.IsChecked = true;
            ClothesAdvLoad.IsChecked = true;
            WeaponsAdvLoad.IsChecked = true;
            LeftHandAdvLoad.IsChecked = true;
            RightHandAdvLoad.IsChecked = true;
            WaistAdvLoad.IsChecked = true;
            LeftLegAdvLoad.IsChecked = true;
            RightLegAdvLoad.IsChecked = true;
            HelmAdvLoad.IsChecked = true;
            TopAdvLoad.IsChecked = true;
        }
        private void SelectNone_Click(object sender, RoutedEventArgs e)
        {
            HeadAdvLoad.IsChecked = false;
            HairAdvLoad.IsChecked = false;
            EarringsAdvLoad.IsChecked = false;
            BodyAdvLoad.IsChecked = false;
            LeftArmAdvLoad.IsChecked = false;
            RightArmAdvLoad.IsChecked = false;
            ClothesAdvLoad.IsChecked = false;
            WeaponsAdvLoad.IsChecked = false;
            LeftHandAdvLoad.IsChecked = false;
            RightHandAdvLoad.IsChecked = false;
            WaistAdvLoad.IsChecked = false;
            LeftLegAdvLoad.IsChecked = false;
            RightLegAdvLoad.IsChecked = false;
            HelmAdvLoad.IsChecked = false;
            TopAdvLoad.IsChecked = false;
        }


        #region Savestate\Loadstate Head
        private void SavestateHead01_Click(object sender, RoutedEventArgs e)
        {
            HeadSaved01 = true;
            if (EditModeButton.IsChecked == true) LoadstateHead01.IsEnabled = true;
            Race_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Race), 1));

            Head_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.Head_Bone), 16));
            EarLeft_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EarLeft_Bone), 16));
            EarRight_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EarRight_Bone), 16));
            RootHead_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.RootHead_Bone), 16));
            Jaw_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.Jaw_Bone), 16));
            EyelidLowerLeft_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyelidLowerLeft_Bone), 16));
            EyelidLowerRight_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyelidLowerRight_Bone), 16));
            EyeLeft_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyeLeft_Bone), 16));
            EyeRight_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyeRight_Bone), 16));
            Nose_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.Nose_Bone), 16));
            CheekLeft_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.CheekLeft_Bone), 16));
            HrothWhiskersLeft_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothWhiskersLeft_Bone), 16));
            CheekRight_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.CheekRight_Bone), 16));
            HrothWhiskersRight_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothWhiskersRight_Bone), 16));
            LipsLeft_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipsLeft_Bone), 16));
            HrothEyebrowLeft_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothEyebrowLeft_Bone), 16));
            LipsRight_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipsRight_Bone), 16));
            HrothEyebrowRight_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothEyebrowRight_Bone), 16));
            EyebrowLeft_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyebrowLeft_Bone), 16));
            HrothBridge_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothBridge_Bone), 16));
            EyebrowRight_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyebrowRight_Bone), 16));
            HrothBrowLeft_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothBrowLeft_Bone), 16));
            Bridge_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.Bridge_Bone), 16));
            HrothBrowRight_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothBrowRight_Bone), 16));
            BrowLeft_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.BrowLeft_Bone), 16));
            HrothJawUpper_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothJawUpper_Bone), 16));
            BrowRight_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.BrowRight_Bone), 16));
            HrothLipUpper_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothLipUpper_Bone), 16));
            LipUpperA_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipUpperA_Bone), 16));
            HrothEyelidUpperLeft_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothEyelidUpperLeft_Bone), 16));
            EyelidUpperLeft_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyelidUpperLeft_Bone), 16));
            HrothEyelidUpperRight_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothEyelidUpperRight_Bone), 16));
            EyelidUpperRight_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyelidUpperRight_Bone), 16));
            HrothLipsLeft_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothLipsLeft_Bone), 16));
            LipLowerA_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipLowerA_Bone), 16));
            HrothLipsRight_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothLipsRight_Bone), 16));
            VieraEar01ALeft_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar01ALeft_Bone), 16));
            LipUpperB_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipUpperB_Bone), 16));
            HrothLipUpperLeft_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothLipUpperLeft_Bone), 16));
            VieraEar01ARight_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar01ARight_Bone), 16));
            LipLowerB_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipLowerB_Bone), 16));
            HrothLipUpperRight_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothLipUpperRight_Bone), 16));
            VieraEar02ALeft_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar02ALeft_Bone), 16));
            if (CharacterDetails.Race.value == 7 || CharacterDetails.Race.value == 8)
            {
                HrothLipLower_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothLipLower_Bone), 16));
                VieraEar02ARight_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar02ARight_Bone), 16));
            }
            else
            {
                HrothLipLower_Sav01 = "null";
                VieraEar02ARight_Sav01 = "null";
            }
            if (CharacterDetails.Race.value == 8)
            {
                VieraEar03ALeft_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar03ALeft_Bone), 16));
                VieraEar03ARight_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar03ARight_Bone), 16));
                VieraEar04ALeft_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar04ALeft_Bone), 16));
                VieraEar04ARight_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar04ARight_Bone), 16));
                VieraLipLowerA_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraLipLowerA_Bone), 16));
                VieraLipUpperB_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraLipUpperB_Bone), 16));
                VieraEar01BLeft_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar01BLeft_Bone), 16));
                VieraEar01BRight_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar01BRight_Bone), 16));
                VieraEar02BLeft_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar02BLeft_Bone), 16));
                VieraEar02BRight_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar02BRight_Bone), 16));
                VieraEar03BLeft_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar03BLeft_Bone), 16));
                VieraEar03BRight_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar03BRight_Bone), 16));
                VieraEar04BLeft_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar04BLeft_Bone), 16));
                VieraEar04BRight_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar04BRight_Bone), 16));
                VieraLipLowerB_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraLipLowerB_Bone), 16));
            }
            else
            {
                VieraEar03ALeft_Sav01 = "null";
                VieraEar03ARight_Sav01 = "null";
                VieraEar04ALeft_Sav01 = "null";
                VieraEar04ARight_Sav01 = "null";
                VieraLipLowerA_Sav01 = "null";
                VieraLipUpperB_Sav01 = "null";
                VieraEar01BLeft_Sav01 = "null";
                VieraEar01BRight_Sav01 = "null";
                VieraEar02BLeft_Sav01 = "null";
                VieraEar02BRight_Sav01 = "null";
                VieraEar03BLeft_Sav01 = "null";
                VieraEar03BRight_Sav01 = "null";
                VieraEar04BLeft_Sav01 = "null";
                VieraEar04BRight_Sav01 = "null";
                VieraLipLowerB_Sav01 = "null";
            }
        }
        private void SavestateHead02_Click(object sender, RoutedEventArgs e)
        {
            HeadSaved02 = true;
            if (EditModeButton.IsChecked == true) LoadstateHead02.IsEnabled = true;
            Race_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Race), 1));

            Head_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.Head_Bone), 16));
            EarLeft_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EarLeft_Bone), 16));
            EarRight_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EarRight_Bone), 16));
            RootHead_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.RootHead_Bone), 16));
            Jaw_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.Jaw_Bone), 16));
            EyelidLowerLeft_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyelidLowerLeft_Bone), 16));
            EyelidLowerRight_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyelidLowerRight_Bone), 16));
            EyeLeft_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyeLeft_Bone), 16));
            EyeRight_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyeRight_Bone), 16));
            Nose_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.Nose_Bone), 16));
            CheekLeft_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.CheekLeft_Bone), 16));
            HrothWhiskersLeft_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothWhiskersLeft_Bone), 16));
            CheekRight_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.CheekRight_Bone), 16));
            HrothWhiskersRight_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothWhiskersRight_Bone), 16));
            LipsLeft_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipsLeft_Bone), 16));
            HrothEyebrowLeft_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothEyebrowLeft_Bone), 16));
            LipsRight_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipsRight_Bone), 16));
            HrothEyebrowRight_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothEyebrowRight_Bone), 16));
            EyebrowLeft_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyebrowLeft_Bone), 16));
            HrothBridge_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothBridge_Bone), 16));
            EyebrowRight_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyebrowRight_Bone), 16));
            HrothBrowLeft_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothBrowLeft_Bone), 16));
            Bridge_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.Bridge_Bone), 16));
            HrothBrowRight_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothBrowRight_Bone), 16));
            BrowLeft_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.BrowLeft_Bone), 16));
            HrothJawUpper_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothJawUpper_Bone), 16));
            BrowRight_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.BrowRight_Bone), 16));
            HrothLipUpper_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothLipUpper_Bone), 16));
            LipUpperA_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipUpperA_Bone), 16));
            HrothEyelidUpperLeft_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothEyelidUpperLeft_Bone), 16));
            EyelidUpperLeft_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyelidUpperLeft_Bone), 16));
            HrothEyelidUpperRight_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothEyelidUpperRight_Bone), 16));
            EyelidUpperRight_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyelidUpperRight_Bone), 16));
            HrothLipsLeft_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothLipsLeft_Bone), 16));
            LipLowerA_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipLowerA_Bone), 16));
            HrothLipsRight_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothLipsRight_Bone), 16));
            VieraEar01ALeft_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar01ALeft_Bone), 16));
            LipUpperB_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipUpperB_Bone), 16));
            HrothLipUpperLeft_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothLipUpperLeft_Bone), 16));
            VieraEar01ARight_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar01ARight_Bone), 16));
            LipLowerB_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipLowerB_Bone), 16));
            HrothLipUpperRight_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothLipUpperRight_Bone), 16));
            VieraEar02ALeft_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar02ALeft_Bone), 16));
            if (CharacterDetails.Race.value == 7 || CharacterDetails.Race.value == 8)
            {
                HrothLipLower_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothLipLower_Bone), 16));
                VieraEar02ARight_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar02ARight_Bone), 16));
            }
            else
            {
                HrothLipLower_Sav02 = "null";
                VieraEar02ARight_Sav02 = "null";
            }
            if (CharacterDetails.Race.value == 8)
            {
                VieraEar03ALeft_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar03ALeft_Bone), 16));
                VieraEar03ARight_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar03ARight_Bone), 16));
                VieraEar04ALeft_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar04ALeft_Bone), 16));
                VieraEar04ARight_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar04ARight_Bone), 16));
                VieraLipLowerA_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraLipLowerA_Bone), 16));
                VieraLipUpperB_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraLipUpperB_Bone), 16));
                VieraEar01BLeft_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar01BLeft_Bone), 16));
                VieraEar01BRight_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar01BRight_Bone), 16));
                VieraEar02BLeft_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar02BLeft_Bone), 16));
                VieraEar02BRight_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar02BRight_Bone), 16));
                VieraEar03BLeft_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar03BLeft_Bone), 16));
                VieraEar03BRight_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar03BRight_Bone), 16));
                VieraEar04BLeft_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar04BLeft_Bone), 16));
                VieraEar04BRight_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar04BRight_Bone), 16));
                VieraLipLowerB_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraLipLowerB_Bone), 16));
            }
            else
            {
                VieraEar03ALeft_Sav02 = "null";
                VieraEar03ARight_Sav02 = "null";
                VieraEar04ALeft_Sav02 = "null";
                VieraEar04ARight_Sav02 = "null";
                VieraLipLowerA_Sav02 = "null";
                VieraLipUpperB_Sav02 = "null";
                VieraEar01BLeft_Sav02 = "null";
                VieraEar01BRight_Sav02 = "null";
                VieraEar02BLeft_Sav02 = "null";
                VieraEar02BRight_Sav02 = "null";
                VieraEar03BLeft_Sav02 = "null";
                VieraEar03BRight_Sav02 = "null";
                VieraEar04BLeft_Sav02 = "null";
                VieraEar04BRight_Sav02 = "null";
                VieraLipLowerB_Sav02 = "null";
            }
        }
        private void LoadstateHead01_Click(object sender, RoutedEventArgs e)
        {
            UncheckAll();
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.Head_Bone), MemoryManager.StringToByteArray(Head_Sav01.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EarLeft_Bone), MemoryManager.StringToByteArray(EarLeft_Sav01.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EarRight_Bone), MemoryManager.StringToByteArray(EarRight_Sav01.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.Jaw_Bone), MemoryManager.StringToByteArray(Jaw_Sav01.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyelidLowerLeft_Bone), MemoryManager.StringToByteArray(EyelidLowerLeft_Sav01.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyelidLowerRight_Bone), MemoryManager.StringToByteArray(EyelidLowerRight_Sav01.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyeLeft_Bone), MemoryManager.StringToByteArray(EyeLeft_Sav01.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyeRight_Bone), MemoryManager.StringToByteArray(EyeRight_Sav01.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.Nose_Bone), MemoryManager.StringToByteArray(Nose_Sav01.Replace(" ", string.Empty)));
            if (CharacterDetails.Race.value < 7)
            {
                if (Race_Sav01 == "01" || Race_Sav01 == "02" || Race_Sav01 == "03" || Race_Sav01 == "04" || Race_Sav01 == "05" || Race_Sav01 == "06")
                {
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.CheekLeft_Bone), MemoryManager.StringToByteArray(CheekLeft_Sav01.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.CheekRight_Bone), MemoryManager.StringToByteArray(CheekRight_Sav01.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipsLeft_Bone), MemoryManager.StringToByteArray(LipsLeft_Sav01.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipsRight_Bone), MemoryManager.StringToByteArray(LipsRight_Sav01.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyebrowLeft_Bone), MemoryManager.StringToByteArray(EyebrowLeft_Sav01.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyebrowRight_Bone), MemoryManager.StringToByteArray(EyebrowRight_Sav01.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.Bridge_Bone), MemoryManager.StringToByteArray(Bridge_Sav01.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.BrowLeft_Bone), MemoryManager.StringToByteArray(BrowLeft_Sav01.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.BrowRight_Bone), MemoryManager.StringToByteArray(BrowRight_Sav01.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipUpperA_Bone), MemoryManager.StringToByteArray(LipUpperA_Sav01.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyelidUpperLeft_Bone), MemoryManager.StringToByteArray(EyelidUpperLeft_Sav01.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyelidUpperRight_Bone), MemoryManager.StringToByteArray(EyelidUpperRight_Sav01.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipLowerA_Bone), MemoryManager.StringToByteArray(LipLowerA_Sav01.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipUpperB_Bone), MemoryManager.StringToByteArray(LipUpperB_Sav01.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipLowerB_Bone), MemoryManager.StringToByteArray(LipLowerB_Sav01.Replace(" ", string.Empty)));
                }
                if (Race_Sav01 == "07")
                {
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.CheekLeft_Bone), MemoryManager.StringToByteArray(HrothLipUpperLeft_Sav01.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.CheekRight_Bone), MemoryManager.StringToByteArray(HrothLipUpperRight_Sav01.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipsLeft_Bone), MemoryManager.StringToByteArray(HrothLipsLeft_Sav01.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipsRight_Bone), MemoryManager.StringToByteArray(HrothLipsRight_Sav01.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyebrowLeft_Bone), MemoryManager.StringToByteArray(HrothEyebrowLeft_Sav01.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyebrowRight_Bone), MemoryManager.StringToByteArray(HrothEyebrowRight_Sav01.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.Bridge_Bone), MemoryManager.StringToByteArray(HrothBridge_Sav01.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.BrowLeft_Bone), MemoryManager.StringToByteArray(HrothBrowLeft_Sav01.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.BrowRight_Bone), MemoryManager.StringToByteArray(HrothBrowRight_Sav01.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipUpperA_Bone), MemoryManager.StringToByteArray(HrothLipUpper_Sav01.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyelidUpperLeft_Bone), MemoryManager.StringToByteArray(HrothEyelidUpperLeft_Sav01.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyelidUpperRight_Bone), MemoryManager.StringToByteArray(HrothEyelidUpperRight_Sav01.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipUpperB_Bone), MemoryManager.StringToByteArray(HrothJawUpper_Sav01.Replace(" ", string.Empty)));
                }
                if (Race_Sav01 == "08")
                {
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.CheekLeft_Bone), MemoryManager.StringToByteArray(CheekLeft_Sav01.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.CheekRight_Bone), MemoryManager.StringToByteArray(CheekRight_Sav01.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipsLeft_Bone), MemoryManager.StringToByteArray(LipsLeft_Sav01.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipsRight_Bone), MemoryManager.StringToByteArray(LipsRight_Sav01.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyebrowLeft_Bone), MemoryManager.StringToByteArray(EyebrowLeft_Sav01.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyebrowRight_Bone), MemoryManager.StringToByteArray(EyebrowRight_Sav01.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.Bridge_Bone), MemoryManager.StringToByteArray(Bridge_Sav01.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.BrowLeft_Bone), MemoryManager.StringToByteArray(BrowLeft_Sav01.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.BrowRight_Bone), MemoryManager.StringToByteArray(BrowRight_Sav01.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipUpperA_Bone), MemoryManager.StringToByteArray(LipUpperA_Sav01.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyelidUpperLeft_Bone), MemoryManager.StringToByteArray(EyelidUpperLeft_Sav01.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyelidUpperRight_Bone), MemoryManager.StringToByteArray(EyelidUpperRight_Sav01.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipLowerA_Bone), MemoryManager.StringToByteArray(VieraLipLowerA_Sav01.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipUpperB_Bone), MemoryManager.StringToByteArray(VieraLipUpperB_Sav01.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipLowerB_Bone), MemoryManager.StringToByteArray(VieraLipLowerB_Sav01.Replace(" ", string.Empty)));
                }
            }
            if (CharacterDetails.Race.value == 7)
            {
                if (Race_Sav01 == "01" || Race_Sav01 == "02" || Race_Sav01 == "03" || Race_Sav01 == "04" || Race_Sav01 == "05" || Race_Sav01 == "06")
                {
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothEyebrowLeft_Bone), MemoryManager.StringToByteArray(EyebrowLeft_Sav01.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothEyebrowRight_Bone), MemoryManager.StringToByteArray(EyebrowRight_Sav01.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothBridge_Bone), MemoryManager.StringToByteArray(Bridge_Sav01.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothBrowLeft_Bone), MemoryManager.StringToByteArray(BrowLeft_Sav01.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothBrowRight_Bone), MemoryManager.StringToByteArray(BrowRight_Sav01.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothJawUpper_Bone), MemoryManager.StringToByteArray(LipUpperB_Sav01.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothLipUpper_Bone), MemoryManager.StringToByteArray(LipUpperA_Sav01.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothEyelidUpperLeft_Bone), MemoryManager.StringToByteArray(EyelidUpperLeft_Sav01.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothEyelidUpperRight_Bone), MemoryManager.StringToByteArray(EyelidUpperRight_Sav01.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothLipsLeft_Bone), MemoryManager.StringToByteArray(LipsLeft_Sav01.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothLipsRight_Bone), MemoryManager.StringToByteArray(LipsRight_Sav01.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothLipUpperLeft_Bone), MemoryManager.StringToByteArray(CheekLeft_Sav01.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothLipUpperRight_Bone), MemoryManager.StringToByteArray(CheekRight_Sav01.Replace(" ", string.Empty)));
                }
                if (Race_Sav01 == "07")
                {
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothWhiskersLeft_Bone), MemoryManager.StringToByteArray(HrothWhiskersLeft_Sav01.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothWhiskersRight_Bone), MemoryManager.StringToByteArray(HrothWhiskersRight_Sav01.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothEyebrowLeft_Bone), MemoryManager.StringToByteArray(HrothEyebrowLeft_Sav01.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothEyebrowRight_Bone), MemoryManager.StringToByteArray(HrothEyebrowRight_Sav01.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothBridge_Bone), MemoryManager.StringToByteArray(HrothBridge_Sav01.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothBrowLeft_Bone), MemoryManager.StringToByteArray(HrothBrowLeft_Sav01.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothBrowRight_Bone), MemoryManager.StringToByteArray(HrothBrowRight_Sav01.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothJawUpper_Bone), MemoryManager.StringToByteArray(HrothJawUpper_Sav01.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothLipUpper_Bone), MemoryManager.StringToByteArray(HrothLipUpper_Sav01.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothEyelidUpperLeft_Bone), MemoryManager.StringToByteArray(HrothEyelidUpperLeft_Sav01.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothEyelidUpperRight_Bone), MemoryManager.StringToByteArray(HrothEyelidUpperRight_Sav01.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothLipsLeft_Bone), MemoryManager.StringToByteArray(HrothLipsLeft_Sav01.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothLipsRight_Bone), MemoryManager.StringToByteArray(HrothLipsRight_Sav01.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothLipUpperLeft_Bone), MemoryManager.StringToByteArray(HrothLipUpperLeft_Sav01.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothLipUpperRight_Bone), MemoryManager.StringToByteArray(HrothLipUpperRight_Sav01.Replace(" ", string.Empty)));
                }
                if (Race_Sav01 == "08")
                {
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothEyebrowLeft_Bone), MemoryManager.StringToByteArray(EyebrowLeft_Sav01.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothEyebrowRight_Bone), MemoryManager.StringToByteArray(EyebrowRight_Sav01.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothBridge_Bone), MemoryManager.StringToByteArray(Bridge_Sav01.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothBrowLeft_Bone), MemoryManager.StringToByteArray(BrowLeft_Sav01.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothBrowRight_Bone), MemoryManager.StringToByteArray(BrowRight_Sav01.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothJawUpper_Bone), MemoryManager.StringToByteArray(VieraLipUpperB_Sav01.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothLipUpper_Bone), MemoryManager.StringToByteArray(LipUpperA_Sav01.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothEyelidUpperLeft_Bone), MemoryManager.StringToByteArray(EyelidUpperLeft_Sav01.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothEyelidUpperRight_Bone), MemoryManager.StringToByteArray(EyelidUpperRight_Sav01.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothLipsLeft_Bone), MemoryManager.StringToByteArray(LipsLeft_Sav01.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothLipsRight_Bone), MemoryManager.StringToByteArray(LipsRight_Sav01.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothLipUpperLeft_Bone), MemoryManager.StringToByteArray(CheekLeft_Sav01.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothLipUpperRight_Bone), MemoryManager.StringToByteArray(CheekRight_Sav01.Replace(" ", string.Empty)));
                }
            }
            if (CharacterDetails.Race.value == 8)
            {
                if (Race_Sav01 == "01" || Race_Sav01 == "02" || Race_Sav01 == "03" || Race_Sav01 == "04" || Race_Sav01 == "05" || Race_Sav01 == "06")
                {
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.CheekLeft_Bone), MemoryManager.StringToByteArray(CheekLeft_Sav01.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.CheekRight_Bone), MemoryManager.StringToByteArray(CheekRight_Sav01.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipsLeft_Bone), MemoryManager.StringToByteArray(LipsLeft_Sav01.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipsRight_Bone), MemoryManager.StringToByteArray(LipsRight_Sav01.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyebrowLeft_Bone), MemoryManager.StringToByteArray(EyebrowLeft_Sav01.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyebrowRight_Bone), MemoryManager.StringToByteArray(EyebrowRight_Sav01.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.Bridge_Bone), MemoryManager.StringToByteArray(Bridge_Sav01.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.BrowLeft_Bone), MemoryManager.StringToByteArray(BrowLeft_Sav01.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.BrowRight_Bone), MemoryManager.StringToByteArray(BrowRight_Sav01.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipUpperA_Bone), MemoryManager.StringToByteArray(LipUpperA_Sav01.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyelidUpperLeft_Bone), MemoryManager.StringToByteArray(EyelidUpperLeft_Sav01.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyelidUpperRight_Bone), MemoryManager.StringToByteArray(EyelidUpperRight_Sav01.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraLipLowerA_Bone), MemoryManager.StringToByteArray(VieraEar01ALeft_Sav01.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraLipUpperB_Bone), MemoryManager.StringToByteArray(VieraEar01ARight_Sav01.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraLipLowerB_Bone), MemoryManager.StringToByteArray(VieraEar02ALeft_Sav01.Replace(" ", string.Empty)));
                }
                if (Race_Sav01 == "07")
                {
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.CheekLeft_Bone), MemoryManager.StringToByteArray(HrothLipUpperLeft_Sav01.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.CheekRight_Bone), MemoryManager.StringToByteArray(HrothLipUpperRight_Sav01.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipsLeft_Bone), MemoryManager.StringToByteArray(HrothLipsLeft_Sav01.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipsRight_Bone), MemoryManager.StringToByteArray(HrothLipsRight_Sav01.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyebrowLeft_Bone), MemoryManager.StringToByteArray(HrothEyebrowLeft_Sav01.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyebrowRight_Bone), MemoryManager.StringToByteArray(HrothEyebrowRight_Sav01.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.Bridge_Bone), MemoryManager.StringToByteArray(HrothBridge_Sav01.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.BrowLeft_Bone), MemoryManager.StringToByteArray(HrothBrowLeft_Sav01.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.BrowRight_Bone), MemoryManager.StringToByteArray(HrothBrowRight_Sav01.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipUpperA_Bone), MemoryManager.StringToByteArray(HrothLipUpper_Sav01.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyelidUpperLeft_Bone), MemoryManager.StringToByteArray(HrothEyelidUpperLeft_Sav01.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyelidUpperRight_Bone), MemoryManager.StringToByteArray(HrothEyelidUpperRight_Sav01.Replace(" ", string.Empty)));
                }
                if (Race_Sav01 == "08")
                {
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.CheekLeft_Bone), MemoryManager.StringToByteArray(CheekLeft_Sav01.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.CheekRight_Bone), MemoryManager.StringToByteArray(CheekRight_Sav01.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipsLeft_Bone), MemoryManager.StringToByteArray(LipsLeft_Sav01.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipsRight_Bone), MemoryManager.StringToByteArray(LipsRight_Sav01.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyebrowLeft_Bone), MemoryManager.StringToByteArray(EyebrowLeft_Sav01.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyebrowRight_Bone), MemoryManager.StringToByteArray(EyebrowRight_Sav01.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.Bridge_Bone), MemoryManager.StringToByteArray(Bridge_Sav01.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.BrowLeft_Bone), MemoryManager.StringToByteArray(BrowLeft_Sav01.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.BrowRight_Bone), MemoryManager.StringToByteArray(BrowRight_Sav01.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipUpperA_Bone), MemoryManager.StringToByteArray(LipUpperA_Sav01.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyelidUpperLeft_Bone), MemoryManager.StringToByteArray(EyelidUpperLeft_Sav01.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyelidUpperRight_Bone), MemoryManager.StringToByteArray(EyelidUpperRight_Sav01.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar01ALeft_Bone), MemoryManager.StringToByteArray(VieraEar01ALeft_Sav01.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar01ARight_Bone), MemoryManager.StringToByteArray(VieraEar01ARight_Sav01.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar02ALeft_Bone), MemoryManager.StringToByteArray(VieraEar02ALeft_Sav01.Replace(" ", string.Empty)));
                }
            }
            if (HrothLipLower_Sav01 != "null" || VieraEar02ARight_Sav01 != "null")
            {
                if (CharacterDetails.Race.value == 7)
                {
                    if (Race_Sav01 == "07")
                    {
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothLipLower_Bone), MemoryManager.StringToByteArray(HrothLipLower_Sav01.Replace(" ", string.Empty)));
                    }
                }
                if (CharacterDetails.Race.value == 8)
                {
                    if (Race_Sav01 == "08")
                    {
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar02ARight_Bone), MemoryManager.StringToByteArray(VieraEar02ARight_Sav01.Replace(" ", string.Empty)));
                    }
                }
            }
            if (VieraEar03ALeft_Sav01 != "null")
            {
                if (CharacterDetails.Race.value < 7)
                {
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipLowerA_Bone), MemoryManager.StringToByteArray(VieraLipLowerA_Sav01.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipUpperB_Bone), MemoryManager.StringToByteArray(VieraLipUpperB_Sav01.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipLowerB_Bone), MemoryManager.StringToByteArray(VieraLipLowerB_Sav01.Replace(" ", string.Empty)));
                }
                if (CharacterDetails.Race.value == 8)
                {
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar03ALeft_Bone), MemoryManager.StringToByteArray(VieraEar03ALeft_Sav01.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar03ARight_Bone), MemoryManager.StringToByteArray(VieraEar03ARight_Sav01.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar04ALeft_Bone), MemoryManager.StringToByteArray(VieraEar04ALeft_Sav01.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar04ARight_Bone), MemoryManager.StringToByteArray(VieraEar04ARight_Sav01.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraLipLowerA_Bone), MemoryManager.StringToByteArray(VieraLipLowerA_Sav01.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraLipUpperB_Bone), MemoryManager.StringToByteArray(VieraLipUpperB_Sav01.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar01BLeft_Bone), MemoryManager.StringToByteArray(VieraEar01BLeft_Sav01.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar01BRight_Bone), MemoryManager.StringToByteArray(VieraEar01BRight_Sav01.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar02BLeft_Bone), MemoryManager.StringToByteArray(VieraEar02BLeft_Sav01.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar02BRight_Bone), MemoryManager.StringToByteArray(VieraEar02BRight_Sav01.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar03BLeft_Bone), MemoryManager.StringToByteArray(VieraEar03BLeft_Sav01.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar03BRight_Bone), MemoryManager.StringToByteArray(VieraEar03BRight_Sav01.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar04BLeft_Bone), MemoryManager.StringToByteArray(VieraEar04BLeft_Sav01.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar04BRight_Bone), MemoryManager.StringToByteArray(VieraEar04BRight_Sav01.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraLipLowerB_Bone), MemoryManager.StringToByteArray(VieraLipLowerB_Sav01.Replace(" ", string.Empty)));
                }
            }
        }
        private void LoadstateHead02_Click(object sender, RoutedEventArgs e)
        {
            UncheckAll();
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.Head_Bone), MemoryManager.StringToByteArray(Head_Sav02.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EarLeft_Bone), MemoryManager.StringToByteArray(EarLeft_Sav02.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EarRight_Bone), MemoryManager.StringToByteArray(EarRight_Sav02.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.Jaw_Bone), MemoryManager.StringToByteArray(Jaw_Sav02.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyelidLowerLeft_Bone), MemoryManager.StringToByteArray(EyelidLowerLeft_Sav02.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyelidLowerRight_Bone), MemoryManager.StringToByteArray(EyelidLowerRight_Sav02.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyeLeft_Bone), MemoryManager.StringToByteArray(EyeLeft_Sav02.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyeRight_Bone), MemoryManager.StringToByteArray(EyeRight_Sav02.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.Nose_Bone), MemoryManager.StringToByteArray(Nose_Sav02.Replace(" ", string.Empty)));
            if (CharacterDetails.Race.value < 7)
            {
                if (Race_Sav02 == "01" || Race_Sav02 == "02" || Race_Sav02 == "03" || Race_Sav02 == "04" || Race_Sav02 == "05" || Race_Sav02 == "06")
                {
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.CheekLeft_Bone), MemoryManager.StringToByteArray(CheekLeft_Sav02.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.CheekRight_Bone), MemoryManager.StringToByteArray(CheekRight_Sav02.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipsLeft_Bone), MemoryManager.StringToByteArray(LipsLeft_Sav02.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipsRight_Bone), MemoryManager.StringToByteArray(LipsRight_Sav02.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyebrowLeft_Bone), MemoryManager.StringToByteArray(EyebrowLeft_Sav02.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyebrowRight_Bone), MemoryManager.StringToByteArray(EyebrowRight_Sav02.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.Bridge_Bone), MemoryManager.StringToByteArray(Bridge_Sav02.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.BrowLeft_Bone), MemoryManager.StringToByteArray(BrowLeft_Sav02.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.BrowRight_Bone), MemoryManager.StringToByteArray(BrowRight_Sav02.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipUpperA_Bone), MemoryManager.StringToByteArray(LipUpperA_Sav02.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyelidUpperLeft_Bone), MemoryManager.StringToByteArray(EyelidUpperLeft_Sav02.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyelidUpperRight_Bone), MemoryManager.StringToByteArray(EyelidUpperRight_Sav02.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipLowerA_Bone), MemoryManager.StringToByteArray(LipLowerA_Sav02.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipUpperB_Bone), MemoryManager.StringToByteArray(LipUpperB_Sav02.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipLowerB_Bone), MemoryManager.StringToByteArray(LipLowerB_Sav02.Replace(" ", string.Empty)));
                }
                if (Race_Sav02 == "07")
                {
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.CheekLeft_Bone), MemoryManager.StringToByteArray(HrothLipUpperLeft_Sav02.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.CheekRight_Bone), MemoryManager.StringToByteArray(HrothLipUpperRight_Sav02.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipsLeft_Bone), MemoryManager.StringToByteArray(HrothLipsLeft_Sav02.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipsRight_Bone), MemoryManager.StringToByteArray(HrothLipsRight_Sav02.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyebrowLeft_Bone), MemoryManager.StringToByteArray(HrothEyebrowLeft_Sav02.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyebrowRight_Bone), MemoryManager.StringToByteArray(HrothEyebrowRight_Sav02.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.Bridge_Bone), MemoryManager.StringToByteArray(HrothBridge_Sav02.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.BrowLeft_Bone), MemoryManager.StringToByteArray(HrothBrowLeft_Sav02.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.BrowRight_Bone), MemoryManager.StringToByteArray(HrothBrowRight_Sav02.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipUpperA_Bone), MemoryManager.StringToByteArray(HrothLipUpper_Sav02.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyelidUpperLeft_Bone), MemoryManager.StringToByteArray(HrothEyelidUpperLeft_Sav02.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyelidUpperRight_Bone), MemoryManager.StringToByteArray(HrothEyelidUpperRight_Sav02.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipUpperB_Bone), MemoryManager.StringToByteArray(HrothJawUpper_Sav02.Replace(" ", string.Empty)));
                }
                if (Race_Sav02 == "08")
                {
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.CheekLeft_Bone), MemoryManager.StringToByteArray(CheekLeft_Sav02.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.CheekRight_Bone), MemoryManager.StringToByteArray(CheekRight_Sav02.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipsLeft_Bone), MemoryManager.StringToByteArray(LipsLeft_Sav02.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipsRight_Bone), MemoryManager.StringToByteArray(LipsRight_Sav02.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyebrowLeft_Bone), MemoryManager.StringToByteArray(EyebrowLeft_Sav02.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyebrowRight_Bone), MemoryManager.StringToByteArray(EyebrowRight_Sav02.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.Bridge_Bone), MemoryManager.StringToByteArray(Bridge_Sav02.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.BrowLeft_Bone), MemoryManager.StringToByteArray(BrowLeft_Sav02.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.BrowRight_Bone), MemoryManager.StringToByteArray(BrowRight_Sav02.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipUpperA_Bone), MemoryManager.StringToByteArray(LipUpperA_Sav02.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyelidUpperLeft_Bone), MemoryManager.StringToByteArray(EyelidUpperLeft_Sav02.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyelidUpperRight_Bone), MemoryManager.StringToByteArray(EyelidUpperRight_Sav02.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipLowerA_Bone), MemoryManager.StringToByteArray(VieraLipLowerA_Sav02.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipUpperB_Bone), MemoryManager.StringToByteArray(VieraLipUpperB_Sav02.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipLowerB_Bone), MemoryManager.StringToByteArray(VieraLipLowerB_Sav02.Replace(" ", string.Empty)));
                }
            }
            if (CharacterDetails.Race.value == 7)
            {
                if (Race_Sav02 == "01" || Race_Sav02 == "02" || Race_Sav02 == "03" || Race_Sav02 == "04" || Race_Sav02 == "05" || Race_Sav02 == "06")
                {
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothEyebrowLeft_Bone), MemoryManager.StringToByteArray(EyebrowLeft_Sav02.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothEyebrowRight_Bone), MemoryManager.StringToByteArray(EyebrowRight_Sav02.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothBridge_Bone), MemoryManager.StringToByteArray(Bridge_Sav02.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothBrowLeft_Bone), MemoryManager.StringToByteArray(BrowLeft_Sav02.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothBrowRight_Bone), MemoryManager.StringToByteArray(BrowRight_Sav02.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothJawUpper_Bone), MemoryManager.StringToByteArray(LipUpperB_Sav02.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothLipUpper_Bone), MemoryManager.StringToByteArray(LipUpperA_Sav02.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothEyelidUpperLeft_Bone), MemoryManager.StringToByteArray(EyelidUpperLeft_Sav02.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothEyelidUpperRight_Bone), MemoryManager.StringToByteArray(EyelidUpperRight_Sav02.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothLipsLeft_Bone), MemoryManager.StringToByteArray(LipsLeft_Sav02.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothLipsRight_Bone), MemoryManager.StringToByteArray(LipsRight_Sav02.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothLipUpperLeft_Bone), MemoryManager.StringToByteArray(CheekLeft_Sav02.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothLipUpperRight_Bone), MemoryManager.StringToByteArray(CheekRight_Sav02.Replace(" ", string.Empty)));
                }
                if (Race_Sav02 == "07")
                {
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothWhiskersLeft_Bone), MemoryManager.StringToByteArray(HrothWhiskersLeft_Sav02.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothWhiskersRight_Bone), MemoryManager.StringToByteArray(HrothWhiskersRight_Sav02.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothEyebrowLeft_Bone), MemoryManager.StringToByteArray(HrothEyebrowLeft_Sav02.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothEyebrowRight_Bone), MemoryManager.StringToByteArray(HrothEyebrowRight_Sav02.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothBridge_Bone), MemoryManager.StringToByteArray(HrothBridge_Sav02.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothBrowLeft_Bone), MemoryManager.StringToByteArray(HrothBrowLeft_Sav02.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothBrowRight_Bone), MemoryManager.StringToByteArray(HrothBrowRight_Sav02.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothJawUpper_Bone), MemoryManager.StringToByteArray(HrothJawUpper_Sav02.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothLipUpper_Bone), MemoryManager.StringToByteArray(HrothLipUpper_Sav02.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothEyelidUpperLeft_Bone), MemoryManager.StringToByteArray(HrothEyelidUpperLeft_Sav02.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothEyelidUpperRight_Bone), MemoryManager.StringToByteArray(HrothEyelidUpperRight_Sav02.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothLipsLeft_Bone), MemoryManager.StringToByteArray(HrothLipsLeft_Sav02.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothLipsRight_Bone), MemoryManager.StringToByteArray(HrothLipsRight_Sav02.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothLipUpperLeft_Bone), MemoryManager.StringToByteArray(HrothLipUpperLeft_Sav02.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothLipUpperRight_Bone), MemoryManager.StringToByteArray(HrothLipUpperRight_Sav02.Replace(" ", string.Empty)));
                }
                if (Race_Sav02 == "08")
                {
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothEyebrowLeft_Bone), MemoryManager.StringToByteArray(EyebrowLeft_Sav02.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothEyebrowRight_Bone), MemoryManager.StringToByteArray(EyebrowRight_Sav02.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothBridge_Bone), MemoryManager.StringToByteArray(Bridge_Sav02.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothBrowLeft_Bone), MemoryManager.StringToByteArray(BrowLeft_Sav02.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothBrowRight_Bone), MemoryManager.StringToByteArray(BrowRight_Sav02.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothJawUpper_Bone), MemoryManager.StringToByteArray(VieraLipUpperB_Sav02.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothLipUpper_Bone), MemoryManager.StringToByteArray(LipUpperA_Sav02.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothEyelidUpperLeft_Bone), MemoryManager.StringToByteArray(EyelidUpperLeft_Sav02.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothEyelidUpperRight_Bone), MemoryManager.StringToByteArray(EyelidUpperRight_Sav02.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothLipsLeft_Bone), MemoryManager.StringToByteArray(LipsLeft_Sav02.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothLipsRight_Bone), MemoryManager.StringToByteArray(LipsRight_Sav02.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothLipUpperLeft_Bone), MemoryManager.StringToByteArray(CheekLeft_Sav02.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothLipUpperRight_Bone), MemoryManager.StringToByteArray(CheekRight_Sav02.Replace(" ", string.Empty)));
                }
            }
            if (CharacterDetails.Race.value == 8)
            {
                if (Race_Sav02 == "01" || Race_Sav02 == "02" || Race_Sav02 == "03" || Race_Sav02 == "04" || Race_Sav02 == "05" || Race_Sav02 == "06")
                {
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.CheekLeft_Bone), MemoryManager.StringToByteArray(CheekLeft_Sav02.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.CheekRight_Bone), MemoryManager.StringToByteArray(CheekRight_Sav02.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipsLeft_Bone), MemoryManager.StringToByteArray(LipsLeft_Sav02.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipsRight_Bone), MemoryManager.StringToByteArray(LipsRight_Sav02.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyebrowLeft_Bone), MemoryManager.StringToByteArray(EyebrowLeft_Sav02.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyebrowRight_Bone), MemoryManager.StringToByteArray(EyebrowRight_Sav02.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.Bridge_Bone), MemoryManager.StringToByteArray(Bridge_Sav02.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.BrowLeft_Bone), MemoryManager.StringToByteArray(BrowLeft_Sav02.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.BrowRight_Bone), MemoryManager.StringToByteArray(BrowRight_Sav02.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipUpperA_Bone), MemoryManager.StringToByteArray(LipUpperA_Sav02.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyelidUpperLeft_Bone), MemoryManager.StringToByteArray(EyelidUpperLeft_Sav02.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyelidUpperRight_Bone), MemoryManager.StringToByteArray(EyelidUpperRight_Sav02.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraLipLowerA_Bone), MemoryManager.StringToByteArray(VieraEar01ALeft_Sav02.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraLipUpperB_Bone), MemoryManager.StringToByteArray(VieraEar01ARight_Sav02.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraLipLowerB_Bone), MemoryManager.StringToByteArray(VieraEar02ALeft_Sav02.Replace(" ", string.Empty)));
                }
                if (Race_Sav02 == "07")
                {
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.CheekLeft_Bone), MemoryManager.StringToByteArray(HrothLipUpperLeft_Sav02.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.CheekRight_Bone), MemoryManager.StringToByteArray(HrothLipUpperRight_Sav02.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipsLeft_Bone), MemoryManager.StringToByteArray(HrothLipsLeft_Sav02.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipsRight_Bone), MemoryManager.StringToByteArray(HrothLipsRight_Sav02.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyebrowLeft_Bone), MemoryManager.StringToByteArray(HrothEyebrowLeft_Sav02.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyebrowRight_Bone), MemoryManager.StringToByteArray(HrothEyebrowRight_Sav02.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.Bridge_Bone), MemoryManager.StringToByteArray(HrothBridge_Sav02.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.BrowLeft_Bone), MemoryManager.StringToByteArray(HrothBrowLeft_Sav02.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.BrowRight_Bone), MemoryManager.StringToByteArray(HrothBrowRight_Sav02.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipUpperA_Bone), MemoryManager.StringToByteArray(HrothLipUpper_Sav02.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyelidUpperLeft_Bone), MemoryManager.StringToByteArray(HrothEyelidUpperLeft_Sav02.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyelidUpperRight_Bone), MemoryManager.StringToByteArray(HrothEyelidUpperRight_Sav02.Replace(" ", string.Empty)));
                }
                if (Race_Sav02 == "08")
                {
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.CheekLeft_Bone), MemoryManager.StringToByteArray(CheekLeft_Sav02.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.CheekRight_Bone), MemoryManager.StringToByteArray(CheekRight_Sav02.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipsLeft_Bone), MemoryManager.StringToByteArray(LipsLeft_Sav02.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipsRight_Bone), MemoryManager.StringToByteArray(LipsRight_Sav02.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyebrowLeft_Bone), MemoryManager.StringToByteArray(EyebrowLeft_Sav02.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyebrowRight_Bone), MemoryManager.StringToByteArray(EyebrowRight_Sav02.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.Bridge_Bone), MemoryManager.StringToByteArray(Bridge_Sav02.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.BrowLeft_Bone), MemoryManager.StringToByteArray(BrowLeft_Sav02.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.BrowRight_Bone), MemoryManager.StringToByteArray(BrowRight_Sav02.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipUpperA_Bone), MemoryManager.StringToByteArray(LipUpperA_Sav02.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyelidUpperLeft_Bone), MemoryManager.StringToByteArray(EyelidUpperLeft_Sav02.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EyelidUpperRight_Bone), MemoryManager.StringToByteArray(EyelidUpperRight_Sav02.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar01ALeft_Bone), MemoryManager.StringToByteArray(VieraEar01ALeft_Sav02.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar01ARight_Bone), MemoryManager.StringToByteArray(VieraEar01ARight_Sav02.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar02ALeft_Bone), MemoryManager.StringToByteArray(VieraEar02ALeft_Sav02.Replace(" ", string.Empty)));
                }
            }
            if (HrothLipLower_Sav02 != "null" || VieraEar02ARight_Sav02 != "null")
            {
                if (CharacterDetails.Race.value == 7)
                {
                    if (Race_Sav02 == "07")
                    {
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HrothLipLower_Bone), MemoryManager.StringToByteArray(HrothLipLower_Sav02.Replace(" ", string.Empty)));
                    }
                }
                if (CharacterDetails.Race.value == 8)
                {
                    if (Race_Sav02 == "08")
                    {
                        m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar02ARight_Bone), MemoryManager.StringToByteArray(VieraEar02ARight_Sav02.Replace(" ", string.Empty)));
                    }
                }
            }
            if (VieraEar03ALeft_Sav02 != "null")
            {
                if (CharacterDetails.Race.value < 7)
                {
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipLowerA_Bone), MemoryManager.StringToByteArray(VieraLipLowerA_Sav02.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipUpperB_Bone), MemoryManager.StringToByteArray(VieraLipUpperB_Sav02.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LipLowerB_Bone), MemoryManager.StringToByteArray(VieraLipLowerB_Sav02.Replace(" ", string.Empty)));
                }
                if (CharacterDetails.Race.value == 8)
                {
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar03ALeft_Bone), MemoryManager.StringToByteArray(VieraEar03ALeft_Sav02.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar03ARight_Bone), MemoryManager.StringToByteArray(VieraEar03ARight_Sav02.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar04ALeft_Bone), MemoryManager.StringToByteArray(VieraEar04ALeft_Sav02.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar04ARight_Bone), MemoryManager.StringToByteArray(VieraEar04ARight_Sav02.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraLipLowerA_Bone), MemoryManager.StringToByteArray(VieraLipLowerA_Sav02.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraLipUpperB_Bone), MemoryManager.StringToByteArray(VieraLipUpperB_Sav02.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar01BLeft_Bone), MemoryManager.StringToByteArray(VieraEar01BLeft_Sav02.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar01BRight_Bone), MemoryManager.StringToByteArray(VieraEar01BRight_Sav02.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar02BLeft_Bone), MemoryManager.StringToByteArray(VieraEar02BLeft_Sav02.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar02BRight_Bone), MemoryManager.StringToByteArray(VieraEar02BRight_Sav02.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar03BLeft_Bone), MemoryManager.StringToByteArray(VieraEar03BLeft_Sav02.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar03BRight_Bone), MemoryManager.StringToByteArray(VieraEar03BRight_Sav02.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar04BLeft_Bone), MemoryManager.StringToByteArray(VieraEar04BLeft_Sav02.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraEar04BRight_Bone), MemoryManager.StringToByteArray(VieraEar04BRight_Sav02.Replace(" ", string.Empty)));
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.VieraLipLowerB_Bone), MemoryManager.StringToByteArray(VieraLipLowerB_Sav02.Replace(" ", string.Empty)));
                }
            }
        }
        #endregion
        #region Savestate\Loadstate Hair
        private void SavestateHair01_Click(object sender, RoutedEventArgs e)
        {
            HairSaved01 = true;
            if (EditModeButton.IsChecked == true) LoadstateHair01.IsEnabled = true;

            HairA_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HairA_Bone), 16));
            HairFrontLeft_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HairFrontLeft_Bone), 16));
            HairFrontRight_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HairFrontRight_Bone), 16));
            HairB_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HairB_Bone), 16));
            var HairValue = m.readByte(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExHair_Value));

            if (HairValue >= 1)
            {
                ExRootHair_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExRootHair_Bone), 16));
            }
            if (HairValue >= 2)
            {
                ExHairA_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExHairA_Bone), 16));
            }
            else
            {
                ExHairA_Sav01 = "null";
            }
            if (HairValue >= 3)
            {
                ExHairB_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExHairB_Bone), 16));
            }
            else
            {
                ExHairB_Sav01 = "null";
            }
            if (HairValue >= 4)
            {
                ExHairC_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExHairC_Bone), 16));
            }
            else
            {
                ExHairC_Sav01 = "null";
            }
            if (HairValue >= 5)
            {
                ExHairD_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExHairD_Bone), 16));
            }
            else
            {
                ExHairD_Sav01 = "null";
            }
            if (HairValue >= 6)
            {
                ExHairE_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExHairE_Bone), 16));
            }
            else
            {
                ExHairE_Sav01 = "null";
            }
            if (HairValue >= 7)
            {
                ExHairF_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExHairF_Bone), 16));
            }
            else
            {
                ExHairF_Sav01 = "null";
            }
            if (HairValue >= 8)
            {
                ExHairG_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExHairG_Bone), 16));
            }
            else
            {
                ExHairG_Sav01 = "null";
            }
            if (HairValue >= 9)
            {
                ExHairH_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExHairH_Bone), 16));
            }
            else
            {
                ExHairH_Sav01 = "null";
            }
            if (HairValue >= 10)
            {
                ExHairI_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExHairI_Bone), 16));
            }
            else
            {
                ExHairI_Sav01 = "null";
            }
            if (HairValue >= 11)
            {
                ExHairJ_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExHairJ_Bone), 16));
            }
            else
            {
                ExHairJ_Sav01 = "null";
            }
            if (HairValue >= 12)
            {
                ExHairK_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExHairK_Bone), 16));
            }
            else
            {
                ExHairK_Sav01 = "null";
            }
            if (HairValue >= 13)
            {
                ExHairL_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExHairL_Bone), 16));
            }
            else
            {
                ExHairL_Sav01 = "null";
            }
            if (ExRootHair_Sav01 == null)
            {
                ExRootHair_Sav01 = "null";
                ExHairA_Sav01 = "null";
                ExHairB_Sav01 = "null";
                ExHairC_Sav01 = "null";
                ExHairD_Sav01 = "null";
                ExHairE_Sav01 = "null";
                ExHairF_Sav01 = "null";
                ExHairG_Sav01 = "null";
                ExHairH_Sav01 = "null";
                ExHairI_Sav01 = "null";
                ExHairJ_Sav01 = "null";
                ExHairK_Sav01 = "null";
                ExHairL_Sav01 = "null";
            }
        }
        private void SavestateHair02_Click(object sender, RoutedEventArgs e)
        {
            HairSaved02 = true;
            if (EditModeButton.IsChecked == true) LoadstateHair02.IsEnabled = true;

            HairA_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HairA_Bone), 16));
            HairFrontLeft_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HairFrontLeft_Bone), 16));
            HairFrontRight_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HairFrontRight_Bone), 16));
            HairB_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HairB_Bone), 16));
            var HairValue = m.readByte(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExHair_Value));

            if (HairValue >= 1)
            {
                ExRootHair_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExRootHair_Bone), 16));
            }
            if (HairValue >= 2)
            {
                ExHairA_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExHairA_Bone), 16));
            }
            else
            {
                ExHairA_Sav02 = "null";
            }
            if (HairValue >= 3)
            {
                ExHairB_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExHairB_Bone), 16));
            }
            else
            {
                ExHairB_Sav02 = "null";
            }
            if (HairValue >= 4)
            {
                ExHairC_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExHairC_Bone), 16));
            }
            else
            {
                ExHairC_Sav02 = "null";
            }
            if (HairValue >= 5)
            {
                ExHairD_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExHairD_Bone), 16));
            }
            else
            {
                ExHairD_Sav02 = "null";
            }
            if (HairValue >= 6)
            {
                ExHairE_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExHairE_Bone), 16));
            }
            else
            {
                ExHairE_Sav02 = "null";
            }
            if (HairValue >= 7)
            {
                ExHairF_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExHairF_Bone), 16));
            }
            else
            {
                ExHairF_Sav02 = "null";
            }
            if (HairValue >= 8)
            {
                ExHairG_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExHairG_Bone), 16));
            }
            else
            {
                ExHairG_Sav02 = "null";
            }
            if (HairValue >= 9)
            {
                ExHairH_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExHairH_Bone), 16));
            }
            else
            {
                ExHairH_Sav02 = "null";
            }
            if (HairValue >= 10)
            {
                ExHairI_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExHairI_Bone), 16));
            }
            else
            {
                ExHairI_Sav02 = "null";
            }
            if (HairValue >= 11)
            {
                ExHairJ_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExHairJ_Bone), 16));
            }
            else
            {
                ExHairJ_Sav02 = "null";
            }
            if (HairValue >= 12)
            {
                ExHairK_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExHairK_Bone), 16));
            }
            else
            {
                ExHairK_Sav02 = "null";
            }
            if (HairValue >= 13)
            {
                ExHairL_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExHairL_Bone), 16));
            }
            else
            {
                ExHairL_Sav02 = "null";
            }
            if (ExRootHair_Sav02 == null)
            {
                ExRootHair_Sav02 = "null";
                ExHairA_Sav02 = "null";
                ExHairB_Sav02 = "null";
                ExHairC_Sav02 = "null";
                ExHairD_Sav02 = "null";
                ExHairE_Sav02 = "null";
                ExHairF_Sav02 = "null";
                ExHairG_Sav02 = "null";
                ExHairH_Sav02 = "null";
                ExHairI_Sav02 = "null";
                ExHairJ_Sav02 = "null";
                ExHairK_Sav02 = "null";
                ExHairL_Sav02 = "null";
            }
        }
        private void LoadstateHair01_Click(object sender, RoutedEventArgs e)
        {
            UncheckAll();
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HairA_Bone), MemoryManager.StringToByteArray(HairA_Sav01.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HairFrontLeft_Bone), MemoryManager.StringToByteArray(HairFrontLeft_Sav01.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HairFrontRight_Bone), MemoryManager.StringToByteArray(HairFrontRight_Sav01.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HairB_Bone), MemoryManager.StringToByteArray(HairB_Sav01.Replace(" ", string.Empty)));
            var HairValue = m.readByte(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExHair_Value));

            if (HairValue >= 2)
            {
                if (ExHairA_Sav01 != "null")
                {
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExHairA_Bone), MemoryManager.StringToByteArray(ExHairA_Sav01.Replace(" ", string.Empty)));
                }
            }
            if (HairValue >= 3)
            {
                if (ExHairB_Sav01 != "null")
                {
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExHairB_Bone), MemoryManager.StringToByteArray(ExHairB_Sav01.Replace(" ", string.Empty)));
                }
            }
            if (HairValue >= 4)
            {
                if (ExHairC_Sav01 != "null")
                {
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExHairC_Bone), MemoryManager.StringToByteArray(ExHairC_Sav01.Replace(" ", string.Empty)));
                }
            }
            if (HairValue >= 5)
            {
                if (ExHairD_Sav01 != "null")
                {
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExHairD_Bone), MemoryManager.StringToByteArray(ExHairD_Sav01.Replace(" ", string.Empty)));
                }
            }
            if (HairValue >= 6)
            {
                if (ExHairE_Sav01 != "null")
                {
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExHairE_Bone), MemoryManager.StringToByteArray(ExHairE_Sav01.Replace(" ", string.Empty)));
                }
            }
            if (HairValue >= 7)
            {
                if (ExHairF_Sav01 != "null")
                {
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExHairF_Bone), MemoryManager.StringToByteArray(ExHairF_Sav01.Replace(" ", string.Empty)));
                }
            }
            if (HairValue >= 8)
            {
                if (ExHairG_Sav01 != "null")
                {
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExHairG_Bone), MemoryManager.StringToByteArray(ExHairG_Sav01.Replace(" ", string.Empty)));
                }
            }
            if (HairValue >= 9)
            {
                if (ExHairH_Sav01 != "null")
                {
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExHairH_Bone), MemoryManager.StringToByteArray(ExHairH_Sav01.Replace(" ", string.Empty)));
                }
            }
            if (HairValue >= 10)
            {
                if (ExHairI_Sav01 != "null")
                {
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExHairI_Bone), MemoryManager.StringToByteArray(ExHairI_Sav01.Replace(" ", string.Empty)));
                }
            }
            if (HairValue >= 11)
            {
                if (ExHairJ_Sav01 != "null")
                {
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExHairJ_Bone), MemoryManager.StringToByteArray(ExHairJ_Sav01.Replace(" ", string.Empty)));
                }
            }
            if (HairValue >= 12)
            {
                if (ExHairK_Sav01 != "null")
                {
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExHairK_Bone), MemoryManager.StringToByteArray(ExHairK_Sav01.Replace(" ", string.Empty)));
                }
            }
            if (HairValue >= 13)
            {
                if (ExHairL_Sav01 != "null")
                {
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExHairL_Bone), MemoryManager.StringToByteArray(ExHairL_Sav01.Replace(" ", string.Empty)));
                }
            }
        }
        private void LoadstateHair02_Click(object sender, RoutedEventArgs e)
        {
            UncheckAll();
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HairA_Bone), MemoryManager.StringToByteArray(HairA_Sav02.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HairFrontLeft_Bone), MemoryManager.StringToByteArray(HairFrontLeft_Sav02.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HairFrontRight_Bone), MemoryManager.StringToByteArray(HairFrontRight_Sav02.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HairB_Bone), MemoryManager.StringToByteArray(HairB_Sav02.Replace(" ", string.Empty)));
            var HairValue = m.readByte(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExHair_Value));

            if (HairValue >= 2)
            {
                if (ExHairA_Sav02 != "null")
                {
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExHairA_Bone), MemoryManager.StringToByteArray(ExHairA_Sav02.Replace(" ", string.Empty)));
                }
            }
            if (HairValue >= 3)
            {
                if (ExHairB_Sav02 != "null")
                {
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExHairB_Bone), MemoryManager.StringToByteArray(ExHairB_Sav02.Replace(" ", string.Empty)));
                }
            }
            if (HairValue >= 4)
            {
                if (ExHairC_Sav02 != "null")
                {
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExHairC_Bone), MemoryManager.StringToByteArray(ExHairC_Sav02.Replace(" ", string.Empty)));
                }
            }
            if (HairValue >= 5)
            {
                if (ExHairD_Sav02 != "null")
                {
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExHairD_Bone), MemoryManager.StringToByteArray(ExHairD_Sav02.Replace(" ", string.Empty)));
                }
            }
            if (HairValue >= 6)
            {
                if (ExHairE_Sav02 != "null")
                {
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExHairE_Bone), MemoryManager.StringToByteArray(ExHairE_Sav02.Replace(" ", string.Empty)));
                }
            }
            if (HairValue >= 7)
            {
                if (ExHairF_Sav02 != "null")
                {
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExHairF_Bone), MemoryManager.StringToByteArray(ExHairF_Sav02.Replace(" ", string.Empty)));
                }
            }
            if (HairValue >= 8)
            {
                if (ExHairG_Sav02 != "null")
                {
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExHairG_Bone), MemoryManager.StringToByteArray(ExHairG_Sav02.Replace(" ", string.Empty)));
                }
            }
            if (HairValue >= 9)
            {
                if (ExHairH_Sav02 != "null")
                {
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExHairH_Bone), MemoryManager.StringToByteArray(ExHairH_Sav02.Replace(" ", string.Empty)));
                }
            }
            if (HairValue >= 10)
            {
                if (ExHairI_Sav02 != "null")
                {
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExHairI_Bone), MemoryManager.StringToByteArray(ExHairI_Sav02.Replace(" ", string.Empty)));
                }
            }
            if (HairValue >= 11)
            {
                if (ExHairJ_Sav02 != "null")
                {
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExHairJ_Bone), MemoryManager.StringToByteArray(ExHairJ_Sav02.Replace(" ", string.Empty)));
                }
            }
            if (HairValue >= 12)
            {
                if (ExHairK_Sav02 != "null")
                {
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExHairK_Bone), MemoryManager.StringToByteArray(ExHairK_Sav02.Replace(" ", string.Empty)));
                }
            }
            if (HairValue >= 13)
            {
                if (ExHairL_Sav02 != "null")
                {
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExHairL_Bone), MemoryManager.StringToByteArray(ExHairL_Sav02.Replace(" ", string.Empty)));
                }
            }
        }
        #endregion
        #region Savestate\Loadstate Earrings
        private void SavestateEarrings01_Click(object sender, RoutedEventArgs e)
        {
            EarringsSaved01 = true;
            if (EditModeButton.IsChecked == true) LoadstateEarrings01.IsEnabled = true;

            EarringALeft_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EarringALeft_Bone), 16));
            EarringARight_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EarringARight_Bone), 16));
            EarringBLeft_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EarringBLeft_Bone), 16));
            EarringBRight_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EarringBRight_Bone), 16));
        }
        private void SavestateEarrings02_Click(object sender, RoutedEventArgs e)
        {
            EarringsSaved02 = true;
            if (EditModeButton.IsChecked == true) LoadstateEarrings02.IsEnabled = true;

            EarringALeft_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EarringALeft_Bone), 16));
            EarringARight_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EarringARight_Bone), 16));
            EarringBLeft_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EarringBLeft_Bone), 16));
            EarringBRight_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EarringBRight_Bone), 16));
        }
        private void LoadstateEarrings01_Click(object sender, RoutedEventArgs e)
        {
            UncheckAll();
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EarringALeft_Bone), MemoryManager.StringToByteArray(EarringALeft_Sav01.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EarringARight_Bone), MemoryManager.StringToByteArray(EarringARight_Sav01.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EarringBLeft_Bone), MemoryManager.StringToByteArray(EarringBLeft_Sav01.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EarringBRight_Bone), MemoryManager.StringToByteArray(EarringBRight_Sav01.Replace(" ", string.Empty)));
        }
        private void LoadstateEarrings02_Click(object sender, RoutedEventArgs e)
        {
            UncheckAll();
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EarringALeft_Bone), MemoryManager.StringToByteArray(EarringALeft_Sav02.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EarringARight_Bone), MemoryManager.StringToByteArray(EarringARight_Sav02.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EarringBLeft_Bone), MemoryManager.StringToByteArray(EarringBLeft_Sav02.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.EarringBRight_Bone), MemoryManager.StringToByteArray(EarringBRight_Sav02.Replace(" ", string.Empty)));
        }
        #endregion
        #region Savestate\Loadstate Body
        private void SavestateBody01_Click(object sender, RoutedEventArgs e)
        {
            BodySaved01 = true;
            if (EditModeButton.IsChecked == true) LoadstateBody01.IsEnabled = true;

            SpineA_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.SpineA_Bone), 16));
            SpineB_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.SpineB_Bone), 16));
            BreastLeft_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.BreastLeft_Bone), 16));
            BreastRight_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.BreastRight_Bone), 16));
            SpineC_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.SpineC_Bone), 16));
            ScabbardLeft_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ScabbardLeft_Bone), 16));
            ScabbardRight_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ScabbardRight_Bone), 16));
            Neck_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.Neck_Bone), 16));
        }
        private void SavestateBody02_Click(object sender, RoutedEventArgs e)
        {
            BodySaved02 = true;
            if (EditModeButton.IsChecked == true) LoadstateBody02.IsEnabled = true;

            SpineA_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.SpineA_Bone), 16));
            SpineB_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.SpineB_Bone), 16));
            BreastLeft_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.BreastLeft_Bone), 16));
            BreastRight_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.BreastRight_Bone), 16));
            SpineC_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.SpineC_Bone), 16));
            ScabbardLeft_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ScabbardLeft_Bone), 16));
            ScabbardRight_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ScabbardRight_Bone), 16));
            Neck_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.Neck_Bone), 16));
        }
        private void LoadstateBody01_Click(object sender, RoutedEventArgs e)
        {
            UncheckAll();
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.SpineA_Bone), MemoryManager.StringToByteArray(SpineA_Sav01.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.SpineB_Bone), MemoryManager.StringToByteArray(SpineB_Sav01.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.BreastLeft_Bone), MemoryManager.StringToByteArray(BreastLeft_Sav01.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.BreastRight_Bone), MemoryManager.StringToByteArray(BreastRight_Sav01.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.SpineC_Bone), MemoryManager.StringToByteArray(SpineC_Sav01.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ScabbardLeft_Bone), MemoryManager.StringToByteArray(ScabbardLeft_Sav01.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ScabbardRight_Bone), MemoryManager.StringToByteArray(ScabbardRight_Sav01.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.Neck_Bone), MemoryManager.StringToByteArray(Neck_Sav01.Replace(" ", string.Empty)));
        }
        private void LoadstateBody02_Click(object sender, RoutedEventArgs e)
        {
            UncheckAll();
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.SpineA_Bone), MemoryManager.StringToByteArray(SpineA_Sav02.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.SpineB_Bone), MemoryManager.StringToByteArray(SpineB_Sav02.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.BreastLeft_Bone), MemoryManager.StringToByteArray(BreastLeft_Sav02.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.BreastRight_Bone), MemoryManager.StringToByteArray(BreastRight_Sav02.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.SpineC_Bone), MemoryManager.StringToByteArray(SpineC_Sav02.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ScabbardLeft_Bone), MemoryManager.StringToByteArray(ScabbardLeft_Sav02.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ScabbardRight_Bone), MemoryManager.StringToByteArray(ScabbardRight_Sav02.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.Neck_Bone), MemoryManager.StringToByteArray(Neck_Sav02.Replace(" ", string.Empty)));
        }
        #endregion
        #region Savestate\Loadstate LeftArm
        private void SavestateLeftArm01_Click(object sender, RoutedEventArgs e)
        {
            LeftArmSaved01 = true;
            if (EditModeButton.IsChecked == true) LoadstateLeftArm01.IsEnabled = true;

            ClavicleLeft_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClavicleLeft_Bone), 16));
            ArmLeft_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ArmLeft_Bone), 16));
            ArmRight_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ArmRight_Bone), 16));
            PauldronLeft_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.PauldronLeft_Bone), 16));
            ForearmLeft_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ForearmLeft_Bone), 16));
            ShoulderLeft_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ShoulderLeft_Bone), 16));
            ShieldLeft_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ShieldLeft_Bone), 16));
            ElbowLeft_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ElbowLeft_Bone), 16));
            CouterLeft_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.CouterLeft_Bone), 16));
            WristLeft_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.WristLeft_Bone), 16));
        }
        private void SavestateLeftArm02_Click(object sender, RoutedEventArgs e)
        {
            LeftArmSaved02 = true;
            if (EditModeButton.IsChecked == true) LoadstateLeftArm02.IsEnabled = true;

            ClavicleLeft_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClavicleLeft_Bone), 16));
            ArmLeft_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ArmLeft_Bone), 16));
            ArmRight_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ArmRight_Bone), 16));
            PauldronLeft_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.PauldronLeft_Bone), 16));
            ForearmLeft_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ForearmLeft_Bone), 16));
            ShoulderLeft_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ShoulderLeft_Bone), 16));
            ShieldLeft_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ShieldLeft_Bone), 16));
            ElbowLeft_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ElbowLeft_Bone), 16));
            CouterLeft_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.CouterLeft_Bone), 16));
            WristLeft_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.WristLeft_Bone), 16));
        }
        private void LoadstateLeftArm01_Click(object sender, RoutedEventArgs e)
        {
            UncheckAll();
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClavicleLeft_Bone), MemoryManager.StringToByteArray(ClavicleLeft_Sav01.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ArmLeft_Bone), MemoryManager.StringToByteArray(ArmLeft_Sav01.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.PauldronLeft_Bone), MemoryManager.StringToByteArray(PauldronLeft_Sav01.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ForearmLeft_Bone), MemoryManager.StringToByteArray(ForearmLeft_Sav01.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ShoulderLeft_Bone), MemoryManager.StringToByteArray(ShoulderLeft_Sav01.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ShieldLeft_Bone), MemoryManager.StringToByteArray(ShieldLeft_Sav01.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ElbowLeft_Bone), MemoryManager.StringToByteArray(ElbowLeft_Sav01.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.CouterLeft_Bone), MemoryManager.StringToByteArray(CouterLeft_Sav01.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.WristLeft_Bone), MemoryManager.StringToByteArray(WristLeft_Sav01.Replace(" ", string.Empty)));
        }
        private void LoadstateLeftArm02_Click(object sender, RoutedEventArgs e)
        {
            UncheckAll();
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClavicleLeft_Bone), MemoryManager.StringToByteArray(ClavicleLeft_Sav02.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ArmLeft_Bone), MemoryManager.StringToByteArray(ArmLeft_Sav02.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.PauldronLeft_Bone), MemoryManager.StringToByteArray(PauldronLeft_Sav02.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ForearmLeft_Bone), MemoryManager.StringToByteArray(ForearmLeft_Sav02.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ShoulderLeft_Bone), MemoryManager.StringToByteArray(ShoulderLeft_Sav02.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ShieldLeft_Bone), MemoryManager.StringToByteArray(ShieldLeft_Sav02.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ElbowLeft_Bone), MemoryManager.StringToByteArray(ElbowLeft_Sav02.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.CouterLeft_Bone), MemoryManager.StringToByteArray(CouterLeft_Sav02.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.WristLeft_Bone), MemoryManager.StringToByteArray(WristLeft_Sav02.Replace(" ", string.Empty)));
        }
        #endregion
        #region Savestate\Loadstate RightArm
        private void SavestateRightArm01_Click(object sender, RoutedEventArgs e)
        {
            RightArmSaved01 = true;
            if (EditModeButton.IsChecked == true) LoadstateRightArm01.IsEnabled = true;

            ClavicleRight_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClavicleRight_Bone), 16));
            ArmRight_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ArmRight_Bone), 16));
            ArmRight_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ArmRight_Bone), 16));
            PauldronRight_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.PauldronRight_Bone), 16));
            ForearmRight_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ForearmRight_Bone), 16));
            ShoulderRight_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ShoulderRight_Bone), 16));
            ShieldRight_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ShieldRight_Bone), 16));
            ElbowRight_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ElbowRight_Bone), 16));
            CouterRight_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.CouterRight_Bone), 16));
            WristRight_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.WristRight_Bone), 16));
        }
        private void SavestateRightArm02_Click(object sender, RoutedEventArgs e)
        {
            RightArmSaved02 = true;
            if (EditModeButton.IsChecked == true) LoadstateRightArm02.IsEnabled = true;

            ClavicleRight_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClavicleRight_Bone), 16));
            ArmRight_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ArmRight_Bone), 16));
            ArmRight_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ArmRight_Bone), 16));
            PauldronRight_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.PauldronRight_Bone), 16));
            ForearmRight_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ForearmRight_Bone), 16));
            ShoulderRight_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ShoulderRight_Bone), 16));
            ShieldRight_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ShieldRight_Bone), 16));
            ElbowRight_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ElbowRight_Bone), 16));
            CouterRight_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.CouterRight_Bone), 16));
            WristRight_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.WristRight_Bone), 16));
        }
        private void LoadstateRightArm01_Click(object sender, RoutedEventArgs e)
        {
            UncheckAll();
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClavicleRight_Bone), MemoryManager.StringToByteArray(ClavicleRight_Sav01.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ArmRight_Bone), MemoryManager.StringToByteArray(ArmRight_Sav01.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.PauldronRight_Bone), MemoryManager.StringToByteArray(PauldronRight_Sav01.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ForearmRight_Bone), MemoryManager.StringToByteArray(ForearmRight_Sav01.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ShoulderRight_Bone), MemoryManager.StringToByteArray(ShoulderRight_Sav01.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ShieldRight_Bone), MemoryManager.StringToByteArray(ShieldRight_Sav01.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ElbowRight_Bone), MemoryManager.StringToByteArray(ElbowRight_Sav01.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.CouterRight_Bone), MemoryManager.StringToByteArray(CouterRight_Sav01.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.WristRight_Bone), MemoryManager.StringToByteArray(WristRight_Sav01.Replace(" ", string.Empty)));
        }
        private void LoadstateRightArm02_Click(object sender, RoutedEventArgs e)
        {
            UncheckAll();
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClavicleRight_Bone), MemoryManager.StringToByteArray(ClavicleRight_Sav02.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ArmRight_Bone), MemoryManager.StringToByteArray(ArmRight_Sav02.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.PauldronRight_Bone), MemoryManager.StringToByteArray(PauldronRight_Sav02.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ForearmRight_Bone), MemoryManager.StringToByteArray(ForearmRight_Sav02.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ShoulderRight_Bone), MemoryManager.StringToByteArray(ShoulderRight_Sav02.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ShieldRight_Bone), MemoryManager.StringToByteArray(ShieldRight_Sav02.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ElbowRight_Bone), MemoryManager.StringToByteArray(ElbowRight_Sav02.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.CouterRight_Bone), MemoryManager.StringToByteArray(CouterRight_Sav02.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.WristRight_Bone), MemoryManager.StringToByteArray(WristRight_Sav02.Replace(" ", string.Empty)));
        }
        #endregion
        #region Savestate\Loadstate Clothes
        private void SavestateClothes01_Click(object sender, RoutedEventArgs e)
        {
            ClothesSaved01 = true;
            if (EditModeButton.IsChecked == true) LoadstateClothes01.IsEnabled = true;

            ClothBackALeft_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothBackALeft_Bone), 16));
            ClothBackARight_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothBackARight_Bone), 16));
            ClothFrontALeft_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothFrontALeft_Bone), 16));
            ClothFrontARight_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothFrontARight_Bone), 16));
            ClothSideALeft_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothSideALeft_Bone), 16));
            ClothSideARight_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothSideARight_Bone), 16));
            ClothBackBLeft_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothBackBLeft_Bone), 16));
            ClothBackBRight_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothBackBRight_Bone), 16));
            ClothFrontBLeft_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothFrontBLeft_Bone), 16));
            ClothFrontBRight_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothFrontBRight_Bone), 16));
            ClothSideBLeft_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothSideBLeft_Bone), 16));
            ClothSideBRight_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothSideBRight_Bone), 16));
            ClothBackCLeft_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothBackCLeft_Bone), 16));
            ClothBackCRight_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothBackCRight_Bone), 16));
            ClothFrontCLeft_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothFrontCLeft_Bone), 16));
            ClothFrontCRight_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothFrontCRight_Bone), 16));
            ClothSideCLeft_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothSideCLeft_Bone), 16));
            ClothSideCRight_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothSideCRight_Bone), 16));
        }
        private void SavestateClothes02_Click(object sender, RoutedEventArgs e)
        {
            ClothesSaved02 = true;
            if (EditModeButton.IsChecked == true) LoadstateClothes02.IsEnabled = true;

            ClothBackALeft_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothBackALeft_Bone), 16));
            ClothBackARight_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothBackARight_Bone), 16));
            ClothFrontALeft_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothFrontALeft_Bone), 16));
            ClothFrontARight_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothFrontARight_Bone), 16));
            ClothSideALeft_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothSideALeft_Bone), 16));
            ClothSideARight_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothSideARight_Bone), 16));
            ClothBackBLeft_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothBackBLeft_Bone), 16));
            ClothBackBRight_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothBackBRight_Bone), 16));
            ClothFrontBLeft_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothFrontBLeft_Bone), 16));
            ClothFrontBRight_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothFrontBRight_Bone), 16));
            ClothSideBLeft_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothSideBLeft_Bone), 16));
            ClothSideBRight_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothSideBRight_Bone), 16));
            ClothBackCLeft_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothBackCLeft_Bone), 16));
            ClothBackCRight_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothBackCRight_Bone), 16));
            ClothFrontCLeft_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothFrontCLeft_Bone), 16));
            ClothFrontCRight_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothFrontCRight_Bone), 16));
            ClothSideCLeft_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothSideCLeft_Bone), 16));
            ClothSideCRight_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothSideCRight_Bone), 16));
        }
        private void LoadstateClothes01_Click(object sender, RoutedEventArgs e)
        {
            UncheckAll();
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothBackALeft_Bone), MemoryManager.StringToByteArray(ClothBackALeft_Sav01.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothBackARight_Bone), MemoryManager.StringToByteArray(ClothBackARight_Sav01.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothFrontALeft_Bone), MemoryManager.StringToByteArray(ClothFrontALeft_Sav01.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothFrontARight_Bone), MemoryManager.StringToByteArray(ClothFrontARight_Sav01.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothSideALeft_Bone), MemoryManager.StringToByteArray(ClothSideALeft_Sav01.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothSideARight_Bone), MemoryManager.StringToByteArray(ClothSideARight_Sav01.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothBackBLeft_Bone), MemoryManager.StringToByteArray(ClothBackBLeft_Sav01.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothBackBRight_Bone), MemoryManager.StringToByteArray(ClothBackBRight_Sav01.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothFrontBLeft_Bone), MemoryManager.StringToByteArray(ClothFrontBLeft_Sav01.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothFrontBRight_Bone), MemoryManager.StringToByteArray(ClothFrontBRight_Sav01.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothSideBLeft_Bone), MemoryManager.StringToByteArray(ClothSideBLeft_Sav01.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothSideBRight_Bone), MemoryManager.StringToByteArray(ClothSideBRight_Sav01.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothBackCLeft_Bone), MemoryManager.StringToByteArray(ClothBackCLeft_Sav01.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothBackCRight_Bone), MemoryManager.StringToByteArray(ClothBackCRight_Sav01.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothFrontCLeft_Bone), MemoryManager.StringToByteArray(ClothFrontCLeft_Sav01.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothFrontCRight_Bone), MemoryManager.StringToByteArray(ClothFrontCRight_Sav01.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothSideCLeft_Bone), MemoryManager.StringToByteArray(ClothSideCLeft_Sav01.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothSideCRight_Bone), MemoryManager.StringToByteArray(ClothSideCRight_Sav01.Replace(" ", string.Empty)));
        }
        private void LoadstateClothes02_Click(object sender, RoutedEventArgs e)
        {
            UncheckAll();
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothBackALeft_Bone), MemoryManager.StringToByteArray(ClothBackALeft_Sav02.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothBackARight_Bone), MemoryManager.StringToByteArray(ClothBackARight_Sav02.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothFrontALeft_Bone), MemoryManager.StringToByteArray(ClothFrontALeft_Sav02.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothFrontARight_Bone), MemoryManager.StringToByteArray(ClothFrontARight_Sav02.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothSideALeft_Bone), MemoryManager.StringToByteArray(ClothSideALeft_Sav02.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothSideARight_Bone), MemoryManager.StringToByteArray(ClothSideARight_Sav02.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothBackBLeft_Bone), MemoryManager.StringToByteArray(ClothBackBLeft_Sav02.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothBackBRight_Bone), MemoryManager.StringToByteArray(ClothBackBRight_Sav02.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothFrontBLeft_Bone), MemoryManager.StringToByteArray(ClothFrontBLeft_Sav02.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothFrontBRight_Bone), MemoryManager.StringToByteArray(ClothFrontBRight_Sav02.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothSideBLeft_Bone), MemoryManager.StringToByteArray(ClothSideBLeft_Sav02.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothSideBRight_Bone), MemoryManager.StringToByteArray(ClothSideBRight_Sav02.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothBackCLeft_Bone), MemoryManager.StringToByteArray(ClothBackCLeft_Sav02.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothBackCRight_Bone), MemoryManager.StringToByteArray(ClothBackCRight_Sav02.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothFrontCLeft_Bone), MemoryManager.StringToByteArray(ClothFrontCLeft_Sav02.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothFrontCRight_Bone), MemoryManager.StringToByteArray(ClothFrontCRight_Sav02.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothSideCLeft_Bone), MemoryManager.StringToByteArray(ClothSideCLeft_Sav02.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ClothSideCRight_Bone), MemoryManager.StringToByteArray(ClothSideCRight_Sav02.Replace(" ", string.Empty)));
        }
        #endregion
        #region Savestate\Loadstate Weapons
        private void SavestateWeapons01_Click(object sender, RoutedEventArgs e)
        {
            WeaponsSaved01 = true;
            if (EditModeButton.IsChecked == true) LoadstateWeapons01.IsEnabled = true;

            WeaponLeft_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.WeaponLeft_Bone), 16));
            WeaponRight_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.WeaponRight_Bone), 16));
        }
        private void SavestateWeapons02_Click(object sender, RoutedEventArgs e)
        {
            WeaponsSaved02 = true;
            if (EditModeButton.IsChecked == true) LoadstateWeapons02.IsEnabled = true;

            WeaponLeft_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.WeaponLeft_Bone), 16));
            WeaponRight_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.WeaponRight_Bone), 16));
        }
        private void LoadstateWeapons01_Click(object sender, RoutedEventArgs e)
        {
            UncheckAll();
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.WeaponLeft_Bone), MemoryManager.StringToByteArray(WeaponLeft_Sav01.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.WeaponRight_Bone), MemoryManager.StringToByteArray(WeaponRight_Sav01.Replace(" ", string.Empty)));
        }
        private void LoadstateWeapons02_Click(object sender, RoutedEventArgs e)
        {
            UncheckAll();
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.WeaponLeft_Bone), MemoryManager.StringToByteArray(WeaponLeft_Sav02.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.WeaponRight_Bone), MemoryManager.StringToByteArray(WeaponRight_Sav02.Replace(" ", string.Empty)));
        }
        #endregion
        #region Savestate\Loadstate LeftHand
        private void SavestateLeftHand01_Click(object sender, RoutedEventArgs e)
        {
            LeftHandSaved01 = true;
            if (EditModeButton.IsChecked == true) LoadstateLeftHand01.IsEnabled = true;

            HandLeft_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HandLeft_Bone), 16));
            IndexALeft_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.IndexALeft_Bone), 16));
            PinkyALeft_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.PinkyALeft_Bone), 16));
            RingALeft_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.RingALeft_Bone), 16));
            MiddleALeft_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.MiddleALeft_Bone), 16));
            ThumbALeft_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ThumbALeft_Bone), 16));
            IndexBLeft_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.IndexBLeft_Bone), 16));
            PinkyBLeft_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.PinkyBLeft_Bone), 16));
            RingBLeft_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.RingBLeft_Bone), 16));
            MiddleBLeft_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.MiddleBLeft_Bone), 16));
            ThumbBLeft_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ThumbBLeft_Bone), 16));
        }
        private void SavestateLeftHand02_Click(object sender, RoutedEventArgs e)
        {
            LeftHandSaved02 = true;
            if (EditModeButton.IsChecked == true) LoadstateLeftHand02.IsEnabled = true;

            HandLeft_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HandLeft_Bone), 16));
            IndexALeft_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.IndexALeft_Bone), 16));
            PinkyALeft_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.PinkyALeft_Bone), 16));
            RingALeft_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.RingALeft_Bone), 16));
            MiddleALeft_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.MiddleALeft_Bone), 16));
            ThumbALeft_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ThumbALeft_Bone), 16));
            IndexBLeft_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.IndexBLeft_Bone), 16));
            PinkyBLeft_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.PinkyBLeft_Bone), 16));
            RingBLeft_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.RingBLeft_Bone), 16));
            MiddleBLeft_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.MiddleBLeft_Bone), 16));
            ThumbBLeft_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ThumbBLeft_Bone), 16));
        }
        private void LoadstateLeftHand01_Click(object sender, RoutedEventArgs e)
        {
            UncheckAll();
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HandLeft_Bone), MemoryManager.StringToByteArray(HandLeft_Sav01.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.IndexALeft_Bone), MemoryManager.StringToByteArray(IndexALeft_Sav01.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.PinkyALeft_Bone), MemoryManager.StringToByteArray(PinkyALeft_Sav01.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.RingALeft_Bone), MemoryManager.StringToByteArray(RingALeft_Sav01.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.MiddleALeft_Bone), MemoryManager.StringToByteArray(MiddleALeft_Sav01.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ThumbALeft_Bone), MemoryManager.StringToByteArray(ThumbALeft_Sav01.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.IndexBLeft_Bone), MemoryManager.StringToByteArray(IndexBLeft_Sav01.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.PinkyBLeft_Bone), MemoryManager.StringToByteArray(PinkyBLeft_Sav01.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.RingBLeft_Bone), MemoryManager.StringToByteArray(RingBLeft_Sav01.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.MiddleBLeft_Bone), MemoryManager.StringToByteArray(MiddleBLeft_Sav01.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ThumbBLeft_Bone), MemoryManager.StringToByteArray(ThumbBLeft_Sav01.Replace(" ", string.Empty)));
        }
        private void LoadstateLeftHand02_Click(object sender, RoutedEventArgs e)
        {
            UncheckAll();
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HandLeft_Bone), MemoryManager.StringToByteArray(HandLeft_Sav02.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.IndexALeft_Bone), MemoryManager.StringToByteArray(IndexALeft_Sav02.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.PinkyALeft_Bone), MemoryManager.StringToByteArray(PinkyALeft_Sav02.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.RingALeft_Bone), MemoryManager.StringToByteArray(RingALeft_Sav02.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.MiddleALeft_Bone), MemoryManager.StringToByteArray(MiddleALeft_Sav02.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ThumbALeft_Bone), MemoryManager.StringToByteArray(ThumbALeft_Sav02.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.IndexBLeft_Bone), MemoryManager.StringToByteArray(IndexBLeft_Sav02.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.PinkyBLeft_Bone), MemoryManager.StringToByteArray(PinkyBLeft_Sav02.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.RingBLeft_Bone), MemoryManager.StringToByteArray(RingBLeft_Sav02.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.MiddleBLeft_Bone), MemoryManager.StringToByteArray(MiddleBLeft_Sav02.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ThumbBLeft_Bone), MemoryManager.StringToByteArray(ThumbBLeft_Sav02.Replace(" ", string.Empty)));
        }
        #endregion
        #region Savestate\Loadstate RightHand
        private void SavestateRightHand01_Click(object sender, RoutedEventArgs e)
        {
            RightHandSaved01 = true;
            if (EditModeButton.IsChecked == true) LoadstateRightHand01.IsEnabled = true;

            HandRight_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HandRight_Bone), 16));
            IndexARight_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.IndexARight_Bone), 16));
            PinkyARight_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.PinkyARight_Bone), 16));
            RingARight_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.RingARight_Bone), 16));
            MiddleARight_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.MiddleARight_Bone), 16));
            ThumbARight_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ThumbARight_Bone), 16));
            IndexBRight_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.IndexBRight_Bone), 16));
            PinkyBRight_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.PinkyBRight_Bone), 16));
            RingBRight_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.RingBRight_Bone), 16));
            MiddleBRight_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.MiddleBRight_Bone), 16));
            ThumbBRight_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ThumbBRight_Bone), 16));
        }
        private void SavestateRightHand02_Click(object sender, RoutedEventArgs e)
        {
            RightHandSaved02 = true;
            if (EditModeButton.IsChecked == true) LoadstateRightHand02.IsEnabled = true;

            HandRight_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HandRight_Bone), 16));
            IndexARight_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.IndexARight_Bone), 16));
            PinkyARight_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.PinkyARight_Bone), 16));
            RingARight_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.RingARight_Bone), 16));
            MiddleARight_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.MiddleARight_Bone), 16));
            ThumbARight_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ThumbARight_Bone), 16));
            IndexBRight_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.IndexBRight_Bone), 16));
            PinkyBRight_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.PinkyBRight_Bone), 16));
            RingBRight_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.RingBRight_Bone), 16));
            MiddleBRight_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.MiddleBRight_Bone), 16));
            ThumbBRight_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ThumbBRight_Bone), 16));
        }
        private void LoadstateRightHand01_Click(object sender, RoutedEventArgs e)
        {
            UncheckAll();
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HandRight_Bone), MemoryManager.StringToByteArray(HandRight_Sav01.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.IndexARight_Bone), MemoryManager.StringToByteArray(IndexARight_Sav01.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.PinkyARight_Bone), MemoryManager.StringToByteArray(PinkyARight_Sav01.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.RingARight_Bone), MemoryManager.StringToByteArray(RingARight_Sav01.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.MiddleARight_Bone), MemoryManager.StringToByteArray(MiddleARight_Sav01.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ThumbARight_Bone), MemoryManager.StringToByteArray(ThumbARight_Sav01.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.IndexBRight_Bone), MemoryManager.StringToByteArray(IndexBRight_Sav01.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.PinkyBRight_Bone), MemoryManager.StringToByteArray(PinkyBRight_Sav01.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.RingBRight_Bone), MemoryManager.StringToByteArray(RingBRight_Sav01.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.MiddleBRight_Bone), MemoryManager.StringToByteArray(MiddleBRight_Sav01.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ThumbBRight_Bone), MemoryManager.StringToByteArray(ThumbBRight_Sav01.Replace(" ", string.Empty)));
        }
        private void LoadstateRightHand02_Click(object sender, RoutedEventArgs e)
        {
            UncheckAll();
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HandRight_Bone), MemoryManager.StringToByteArray(HandRight_Sav02.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.IndexARight_Bone), MemoryManager.StringToByteArray(IndexARight_Sav02.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.PinkyARight_Bone), MemoryManager.StringToByteArray(PinkyARight_Sav02.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.RingARight_Bone), MemoryManager.StringToByteArray(RingARight_Sav02.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.MiddleARight_Bone), MemoryManager.StringToByteArray(MiddleARight_Sav02.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ThumbARight_Bone), MemoryManager.StringToByteArray(ThumbARight_Sav02.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.IndexBRight_Bone), MemoryManager.StringToByteArray(IndexBRight_Sav02.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.PinkyBRight_Bone), MemoryManager.StringToByteArray(PinkyBRight_Sav02.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.RingBRight_Bone), MemoryManager.StringToByteArray(RingBRight_Sav02.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.MiddleBRight_Bone), MemoryManager.StringToByteArray(MiddleBRight_Sav02.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ThumbBRight_Bone), MemoryManager.StringToByteArray(ThumbBRight_Sav02.Replace(" ", string.Empty)));
        }
        #endregion
        #region Savestate\Loadstate Waist
        private void SavestateWaist01_Click(object sender, RoutedEventArgs e)
        {
            WaistSaved01 = true;
            if (EditModeButton.IsChecked == true) LoadstateWaist01.IsEnabled = true;

            Waist_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.Waist_Bone), 16));
            HolsterLeft_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HolsterLeft_Bone), 16));
            HolsterRight_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HolsterRight_Bone), 16));
            SheatheLeft_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.SheatheLeft_Bone), 16));
            SheatheRight_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.SheatheRight_Bone), 16));
            if (CharacterDetails.Race.value == 4 || CharacterDetails.Race.value == 6 || CharacterDetails.Race.value == 7)
            {
                TailA_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.TailA_Bone), 16));
                TailB_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.TailB_Bone), 16));
                TailC_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.TailC_Bone), 16));
                TailD_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.TailD_Bone), 16));
                TailE_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.TailE_Bone), 16));
            }
            else
            {
                TailA_Sav01 = "null";
                TailB_Sav01 = "null";
                TailC_Sav01 = "null";
                TailD_Sav01 = "null";
                TailE_Sav01 = "null";
            }
        }
        private void SavestateWaist02_Click(object sender, RoutedEventArgs e)
        {
            WaistSaved02 = true;
            if (EditModeButton.IsChecked == true) LoadstateWaist02.IsEnabled = true;

            Waist_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.Waist_Bone), 16));
            HolsterLeft_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HolsterLeft_Bone), 16));
            HolsterRight_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HolsterRight_Bone), 16));
            SheatheLeft_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.SheatheLeft_Bone), 16));
            SheatheRight_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.SheatheRight_Bone), 16));
            if (CharacterDetails.Race.value == 4 || CharacterDetails.Race.value == 6 || CharacterDetails.Race.value == 7)
            {
                TailA_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.TailA_Bone), 16));
                TailB_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.TailB_Bone), 16));
                TailC_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.TailC_Bone), 16));
                TailD_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.TailD_Bone), 16));
                TailE_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.TailE_Bone), 16));
            }
            else
            {
                TailA_Sav02 = "null";
                TailB_Sav02 = "null";
                TailC_Sav02 = "null";
                TailD_Sav02 = "null";
                TailE_Sav02 = "null";
            }
        }
        private void LoadstateWaist01_Click(object sender, RoutedEventArgs e)
        {
            UncheckAll();
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.Waist_Bone), MemoryManager.StringToByteArray(Waist_Sav01.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HolsterLeft_Bone), MemoryManager.StringToByteArray(HolsterLeft_Sav01.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HolsterRight_Bone), MemoryManager.StringToByteArray(HolsterRight_Sav01.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.SheatheLeft_Bone), MemoryManager.StringToByteArray(SheatheLeft_Sav01.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.SheatheRight_Bone), MemoryManager.StringToByteArray(SheatheRight_Sav01.Replace(" ", string.Empty)));
            if (TailA_Sav01 != "null")
            {
                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.TailA_Bone), MemoryManager.StringToByteArray(TailA_Sav01.Replace(" ", string.Empty)));
                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.TailB_Bone), MemoryManager.StringToByteArray(TailB_Sav01.Replace(" ", string.Empty)));
                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.TailC_Bone), MemoryManager.StringToByteArray(TailC_Sav01.Replace(" ", string.Empty)));
                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.TailD_Bone), MemoryManager.StringToByteArray(TailD_Sav01.Replace(" ", string.Empty)));
                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.TailE_Bone), MemoryManager.StringToByteArray(TailE_Sav01.Replace(" ", string.Empty)));
            }
        }
        private void LoadstateWaist02_Click(object sender, RoutedEventArgs e)
        {
            UncheckAll();
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.Waist_Bone), MemoryManager.StringToByteArray(Waist_Sav02.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HolsterLeft_Bone), MemoryManager.StringToByteArray(HolsterLeft_Sav02.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.HolsterRight_Bone), MemoryManager.StringToByteArray(HolsterRight_Sav02.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.SheatheLeft_Bone), MemoryManager.StringToByteArray(SheatheLeft_Sav02.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.SheatheRight_Bone), MemoryManager.StringToByteArray(SheatheRight_Sav02.Replace(" ", string.Empty)));
            if (TailA_Sav02 != "null")
            {
                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.TailA_Bone), MemoryManager.StringToByteArray(TailA_Sav02.Replace(" ", string.Empty)));
                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.TailB_Bone), MemoryManager.StringToByteArray(TailB_Sav02.Replace(" ", string.Empty)));
                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.TailC_Bone), MemoryManager.StringToByteArray(TailC_Sav02.Replace(" ", string.Empty)));
                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.TailD_Bone), MemoryManager.StringToByteArray(TailD_Sav02.Replace(" ", string.Empty)));
                m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.TailE_Bone), MemoryManager.StringToByteArray(TailE_Sav02.Replace(" ", string.Empty)));
            }
        }
        #endregion
        #region Savestate\Loadstate LeftLeg
        private void SavestateLeftLeg01_Click(object sender, RoutedEventArgs e)
        {
            LeftLegSaved01 = true;
            if (EditModeButton.IsChecked == true) LoadstateLeftLeg01.IsEnabled = true;

            LegLeft_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LegsLeft_Bone), 16));
            KneeLeft_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.KneeLeft_Bone), 16));
            CalfLeft_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.CalfLeft_Bone), 16));
            PoleynLeft_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.PoleynLeft_Bone), 16));
            FootLeft_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.FootLeft_Bone), 16));
            ToesLeft_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ToesLeft_Bone), 16));
        }
        private void SavestateLeftLeg02_Click(object sender, RoutedEventArgs e)
        {
            LeftLegSaved02 = true;
            if (EditModeButton.IsChecked == true) LoadstateLeftLeg02.IsEnabled = true;

            LegLeft_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LegsLeft_Bone), 16));
            KneeLeft_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.KneeLeft_Bone), 16));
            CalfLeft_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.CalfLeft_Bone), 16));
            PoleynLeft_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.PoleynLeft_Bone), 16));
            FootLeft_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.FootLeft_Bone), 16));
            ToesLeft_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ToesLeft_Bone), 16));
        }
        private void LoadstateLeftLeg01_Click(object sender, RoutedEventArgs e)
        {
            UncheckAll();
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LegsLeft_Bone), MemoryManager.StringToByteArray(LegLeft_Sav01.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.KneeLeft_Bone), MemoryManager.StringToByteArray(KneeLeft_Sav01.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.CalfLeft_Bone), MemoryManager.StringToByteArray(CalfLeft_Sav01.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.PoleynLeft_Bone), MemoryManager.StringToByteArray(PoleynLeft_Sav01.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.FootLeft_Bone), MemoryManager.StringToByteArray(FootLeft_Sav01.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ToesLeft_Bone), MemoryManager.StringToByteArray(ToesLeft_Sav01.Replace(" ", string.Empty)));
        }
        private void LoadstateLeftLeg02_Click(object sender, RoutedEventArgs e)
        {
            UncheckAll();
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LegsLeft_Bone), MemoryManager.StringToByteArray(LegLeft_Sav02.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.KneeLeft_Bone), MemoryManager.StringToByteArray(KneeLeft_Sav02.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.CalfLeft_Bone), MemoryManager.StringToByteArray(CalfLeft_Sav02.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.PoleynLeft_Bone), MemoryManager.StringToByteArray(PoleynLeft_Sav02.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.FootLeft_Bone), MemoryManager.StringToByteArray(FootLeft_Sav02.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ToesLeft_Bone), MemoryManager.StringToByteArray(ToesLeft_Sav02.Replace(" ", string.Empty)));
        }
        #endregion
        #region Savestate\Loadstate RightLeg
        private void SavestateRightLeg01_Click(object sender, RoutedEventArgs e)
        {
            RightLegSaved01 = true;
            if (EditModeButton.IsChecked == true) LoadstateRightLeg01.IsEnabled = true;

            LegRight_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LegsRight_Bone), 16));
            KneeRight_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.KneeRight_Bone), 16));
            CalfRight_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.CalfRight_Bone), 16));
            PoleynRight_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.PoleynRight_Bone), 16));
            FootRight_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.FootRight_Bone), 16));
            ToesRight_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ToesRight_Bone), 16));
        }
        private void SavestateRightLeg02_Click(object sender, RoutedEventArgs e)
        {
            RightLegSaved02 = true;
            if (EditModeButton.IsChecked == true) LoadstateRightLeg02.IsEnabled = true;

            LegRight_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LegsRight_Bone), 16));
            KneeRight_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.KneeRight_Bone), 16));
            CalfRight_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.CalfRight_Bone), 16));
            PoleynRight_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.PoleynRight_Bone), 16));
            FootRight_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.FootRight_Bone), 16));
            ToesRight_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ToesRight_Bone), 16));
        }
        private void LoadstateRightLeg01_Click(object sender, RoutedEventArgs e)
        {
            UncheckAll();
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LegsRight_Bone), MemoryManager.StringToByteArray(LegRight_Sav01.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.KneeRight_Bone), MemoryManager.StringToByteArray(KneeRight_Sav01.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.CalfRight_Bone), MemoryManager.StringToByteArray(CalfRight_Sav01.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.PoleynRight_Bone), MemoryManager.StringToByteArray(PoleynRight_Sav01.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.FootRight_Bone), MemoryManager.StringToByteArray(FootRight_Sav01.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ToesRight_Bone), MemoryManager.StringToByteArray(ToesRight_Sav01.Replace(" ", string.Empty)));
        }
        private void LoadstateRightLeg02_Click(object sender, RoutedEventArgs e)
        {
            UncheckAll();
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.LegsRight_Bone), MemoryManager.StringToByteArray(LegRight_Sav02.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.KneeRight_Bone), MemoryManager.StringToByteArray(KneeRight_Sav02.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.CalfRight_Bone), MemoryManager.StringToByteArray(CalfRight_Sav02.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.PoleynRight_Bone), MemoryManager.StringToByteArray(PoleynRight_Sav02.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.FootRight_Bone), MemoryManager.StringToByteArray(FootRight_Sav02.Replace(" ", string.Empty)));
            m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ToesRight_Bone), MemoryManager.StringToByteArray(ToesRight_Sav02.Replace(" ", string.Empty)));
        }
        #endregion
        #region Savestate\Loadstate Helm
        private void SavestateHelm01_Click(object sender, RoutedEventArgs e)
        {
            HelmSaved01 = true;
            if (EditModeButton.IsChecked == true) LoadstateHelm01.IsEnabled = true;
            var HelmValue = m.readByte(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMet_Value));
            if (HelmValue >= 1)
            {
                ExRootMet_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExRootMet_Bone), 16));
            }
            if (HelmValue >= 2)
            {
                ExMetA_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetA_Bone), 16));
            }
            else
            {
                ExMetA_Sav01 = "null";
            }
            if (HelmValue >= 3)
            {
                ExMetB_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetB_Bone), 16));
            }
            else
            {
                ExMetB_Sav01 = "null";
            }
            if (HelmValue >= 4)
            {
                ExMetC_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetC_Bone), 16));
            }
            else
            {
                ExMetC_Sav01 = "null";
            }
            if (HelmValue >= 5)
            {
                ExMetD_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetD_Bone), 16));
            }
            else
            {
                ExMetD_Sav01 = "null";
            }
            if (HelmValue >= 6)
            {
                ExMetE_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetE_Bone), 16));
            }
            else
            {
                ExMetE_Sav01 = "null";
            }
            if (HelmValue >= 7)
            {
                ExMetF_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetF_Bone), 16));
            }
            else
            {
                ExMetF_Sav01 = "null";
            }
            if (HelmValue >= 8)
            {
                ExMetG_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetG_Bone), 16));
            }
            else
            {
                ExMetG_Sav01 = "null";
            }
            if (HelmValue >= 9)
            {
                ExMetH_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetH_Bone), 16));
            }
            else
            {
                ExMetH_Sav01 = "null";
            }
            if (HelmValue >= 10)
            {
                ExMetI_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetI_Bone), 16));
            }
            else
            {
                ExMetI_Sav01 = "null";
            }
            if (HelmValue >= 11)
            {
                ExMetJ_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetJ_Bone), 16));
            }
            else
            {
                ExMetJ_Sav01 = "null";
            }
            if (HelmValue >= 12)
            {
                ExMetK_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetK_Bone), 16));
            }
            else
            {
                ExMetK_Sav01 = "null";
            }
            if (HelmValue >= 13)
            {
                ExMetL_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetL_Bone), 16));
            }
            else
            {
                ExMetL_Sav01 = "null";
            }
            if (HelmValue >= 14)
            {
                ExMetM_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetM_Bone), 16));
            }
            else
            {
                ExMetM_Sav01 = "null";
            }
            if (HelmValue >= 15)
            {
                ExMetN_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetN_Bone), 16));
            }
            else
            {
                ExMetN_Sav01 = "null";
            }
            if (HelmValue >= 16)
            {
                ExMetO_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetO_Bone), 16));
            }
            else
            {
                ExMetO_Sav01 = "null";
            }
            if (HelmValue >= 17)
            {
                ExMetP_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetP_Bone), 16));
            }
            else
            {
                ExMetP_Sav01 = "null";
            }
            if (HelmValue >= 18)
            {
                ExMetQ_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetQ_Bone), 16));
            }
            else
            {
                ExMetQ_Sav01 = "null";
            }
            if (HelmValue >= 19)
            {
                ExMetR_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetR_Bone), 16));
            }
            else
            {
                ExMetR_Sav01 = "null";
            }
            if (ExRootMet_Sav01 == null)
            {
                ExRootMet_Sav01 = "null";
                ExMetA_Sav01 = "null";
                ExMetB_Sav01 = "null";
                ExMetC_Sav01 = "null";
                ExMetD_Sav01 = "null";
                ExMetE_Sav01 = "null";
                ExMetF_Sav01 = "null";
                ExMetG_Sav01 = "null";
                ExMetH_Sav01 = "null";
                ExMetI_Sav01 = "null";
                ExMetJ_Sav01 = "null";
                ExMetK_Sav01 = "null";
                ExMetL_Sav01 = "null";
                ExMetM_Sav01 = "null";
                ExMetN_Sav01 = "null";
                ExMetO_Sav01 = "null";
                ExMetP_Sav01 = "null";
                ExMetQ_Sav01 = "null";
                ExMetR_Sav01 = "null";
            }
        }
        private void SavestateHelm02_Click(object sender, RoutedEventArgs e)
        {
            HelmSaved02 = true;
            if (EditModeButton.IsChecked == true) LoadstateHelm02.IsEnabled = true;
            var HelmValue = m.readByte(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMet_Value));

            if (HelmValue >= 1)
            {
                ExRootMet_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExRootMet_Bone), 16));
            }
            if (HelmValue >= 2)
            {
                ExMetA_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetA_Bone), 16));
            }
            else
            {
                ExMetA_Sav02 = "null";
            }
            if (HelmValue >= 3)
            {
                ExMetB_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetB_Bone), 16));
            }
            else
            {
                ExMetB_Sav02 = "null";
            }
            if (HelmValue >= 4)
            {
                ExMetC_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetC_Bone), 16));
            }
            else
            {
                ExMetC_Sav02 = "null";
            }
            if (HelmValue >= 5)
            {
                ExMetD_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetD_Bone), 16));
            }
            else
            {
                ExMetD_Sav02 = "null";
            }
            if (HelmValue >= 6)
            {
                ExMetE_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetE_Bone), 16));
            }
            else
            {
                ExMetE_Sav02 = "null";
            }
            if (HelmValue >= 7)
            {
                ExMetF_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetF_Bone), 16));
            }
            else
            {
                ExMetF_Sav02 = "null";
            }
            if (HelmValue >= 8)
            {
                ExMetG_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetG_Bone), 16));
            }
            else
            {
                ExMetG_Sav02 = "null";
            }
            if (HelmValue >= 9)
            {
                ExMetH_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetH_Bone), 16));
            }
            else
            {
                ExMetH_Sav02 = "null";
            }
            if (HelmValue >= 10)
            {
                ExMetI_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetI_Bone), 16));
            }
            else
            {
                ExMetI_Sav02 = "null";
            }
            if (HelmValue >= 11)
            {
                ExMetJ_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetJ_Bone), 16));
            }
            else
            {
                ExMetJ_Sav02 = "null";
            }
            if (HelmValue >= 12)
            {
                ExMetK_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetK_Bone), 16));
            }
            else
            {
                ExMetK_Sav02 = "null";
            }
            if (HelmValue >= 13)
            {
                ExMetL_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetL_Bone), 16));
            }
            else
            {
                ExMetL_Sav02 = "null";
            }
            if (HelmValue >= 14)
            {
                ExMetM_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetM_Bone), 16));
            }
            else
            {
                ExMetM_Sav02 = "null";
            }
            if (HelmValue >= 15)
            {
                ExMetN_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetN_Bone), 16));
            }
            else
            {
                ExMetN_Sav02 = "null";
            }
            if (HelmValue >= 16)
            {
                ExMetO_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetO_Bone), 16));
            }
            else
            {
                ExMetO_Sav02 = "null";
            }
            if (HelmValue >= 17)
            {
                ExMetP_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetP_Bone), 16));
            }
            else
            {
                ExMetP_Sav02 = "null";
            }
            if (HelmValue >= 18)
            {
                ExMetQ_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetQ_Bone), 16));
            }
            else
            {
                ExMetQ_Sav02 = "null";
            }
            if (HelmValue >= 19)
            {
                ExMetR_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetR_Bone), 16));
            }
            else
            {
                ExMetR_Sav02 = "null";
            }
            if (ExRootMet_Sav02 == null)
            {
                ExRootMet_Sav02 = "null";
                ExMetA_Sav02 = "null";
                ExMetB_Sav02 = "null";
                ExMetC_Sav02 = "null";
                ExMetD_Sav02 = "null";
                ExMetE_Sav02 = "null";
                ExMetF_Sav02 = "null";
                ExMetG_Sav02 = "null";
                ExMetH_Sav02 = "null";
                ExMetI_Sav02 = "null";
                ExMetJ_Sav02 = "null";
                ExMetK_Sav02 = "null";
                ExMetL_Sav02 = "null";
                ExMetM_Sav02 = "null";
                ExMetN_Sav02 = "null";
                ExMetO_Sav02 = "null";
                ExMetP_Sav02 = "null";
                ExMetQ_Sav02 = "null";
                ExMetR_Sav02 = "null";
            }
        }
        private void LoadstateHelm01_Click(object sender, RoutedEventArgs e)
        {
            UncheckAll();
            var HelmValue = m.readByte(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMet_Value));
            if (HelmValue >= 2)
            {
                if (ExMetA_Sav01 != "null")
                {
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetA_Bone), MemoryManager.StringToByteArray(ExMetA_Sav01.Replace(" ", string.Empty)));
                }
            }
            if (HelmValue >= 3)
            {
                if (ExMetB_Sav01 != "null")
                {
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetB_Bone), MemoryManager.StringToByteArray(ExMetB_Sav01.Replace(" ", string.Empty)));
                }
            }
            if (HelmValue >= 4)
            {
                if (ExMetC_Sav01 != "null")
                {
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetC_Bone), MemoryManager.StringToByteArray(ExMetC_Sav01.Replace(" ", string.Empty)));
                }
            }
            if (HelmValue >= 5)
            {
                if (ExMetD_Sav01 != "null")
                {
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetD_Bone), MemoryManager.StringToByteArray(ExMetD_Sav01.Replace(" ", string.Empty)));
                }
            }
            if (HelmValue >= 6)
            {
                if (ExMetE_Sav01 != "null")
                {
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetE_Bone), MemoryManager.StringToByteArray(ExMetE_Sav01.Replace(" ", string.Empty)));
                }
            }
            if (HelmValue >= 7)
            {
                if (ExMetF_Sav01 != "null")
                {
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetF_Bone), MemoryManager.StringToByteArray(ExMetF_Sav01.Replace(" ", string.Empty)));
                }
            }
            if (HelmValue >= 8)
            {
                if (ExMetG_Sav01 != "null")
                {
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetG_Bone), MemoryManager.StringToByteArray(ExMetG_Sav01.Replace(" ", string.Empty)));
                }
            }
            if (HelmValue >= 9)
            {
                if (ExMetH_Sav01 != "null")
                {
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetH_Bone), MemoryManager.StringToByteArray(ExMetH_Sav01.Replace(" ", string.Empty)));
                }
            }
            if (HelmValue >= 10)
            {
                if (ExMetI_Sav01 != "null")
                {
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetI_Bone), MemoryManager.StringToByteArray(ExMetI_Sav01.Replace(" ", string.Empty)));
                }
            }
            if (HelmValue >= 11)
            {
                if (ExMetJ_Sav01 != "null")
                {
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetJ_Bone), MemoryManager.StringToByteArray(ExMetJ_Sav01.Replace(" ", string.Empty)));
                }
            }
            if (HelmValue >= 12)
            {
                if (ExMetK_Sav01 != "null")
                {
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetK_Bone), MemoryManager.StringToByteArray(ExMetK_Sav01.Replace(" ", string.Empty)));
                }
            }
            if (HelmValue >= 13)
            {
                if (ExMetL_Sav01 != "null")
                {
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetL_Bone), MemoryManager.StringToByteArray(ExMetL_Sav01.Replace(" ", string.Empty)));
                }
            }
            if (HelmValue >= 14)
            {
                if (ExMetM_Sav01 != "null")
                {
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetM_Bone), MemoryManager.StringToByteArray(ExMetM_Sav01.Replace(" ", string.Empty)));
                }
            }
            if (HelmValue >= 15)
            {
                if (ExMetN_Sav01 != "null")
                {
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetN_Bone), MemoryManager.StringToByteArray(ExMetN_Sav01.Replace(" ", string.Empty)));
                }
            }
            if (HelmValue >= 16)
            {
                if (ExMetO_Sav01 != "null")
                {
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetO_Bone), MemoryManager.StringToByteArray(ExMetO_Sav01.Replace(" ", string.Empty)));
                }
            }
            if (HelmValue >= 17)
            {
                if (ExMetP_Sav01 != "null")
                {
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetP_Bone), MemoryManager.StringToByteArray(ExMetP_Sav01.Replace(" ", string.Empty)));
                }
            }
            if (HelmValue >= 18)
            {
                if (ExMetQ_Sav01 != "null")
                {
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetQ_Bone), MemoryManager.StringToByteArray(ExMetQ_Sav01.Replace(" ", string.Empty)));
                }
            }
            if (HelmValue >= 19)
            {
                if (ExMetR_Sav01 != "null")
                {
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetR_Bone), MemoryManager.StringToByteArray(ExMetR_Sav01.Replace(" ", string.Empty)));
                }
            }
        }
        private void LoadstateHelm02_Click(object sender, RoutedEventArgs e)
        {
            UncheckAll();
            var HelmValue = m.readByte(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMet_Value));
            if (HelmValue >= 2)
            {
                if (ExMetA_Sav02 != "null")
                {
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetA_Bone), MemoryManager.StringToByteArray(ExMetA_Sav02.Replace(" ", string.Empty)));
                }
            }
            if (HelmValue >= 3)
            {
                if (ExMetB_Sav02 != "null")
                {
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetB_Bone), MemoryManager.StringToByteArray(ExMetB_Sav02.Replace(" ", string.Empty)));
                }
            }
            if (HelmValue >= 4)
            {
                if (ExMetC_Sav02 != "null")
                {
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetC_Bone), MemoryManager.StringToByteArray(ExMetC_Sav02.Replace(" ", string.Empty)));
                }
            }
            if (HelmValue >= 5)
            {
                if (ExMetD_Sav02 != "null")
                {
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetD_Bone), MemoryManager.StringToByteArray(ExMetD_Sav02.Replace(" ", string.Empty)));
                }
            }
            if (HelmValue >= 6)
            {
                if (ExMetE_Sav02 != "null")
                {
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetE_Bone), MemoryManager.StringToByteArray(ExMetE_Sav02.Replace(" ", string.Empty)));
                }
            }
            if (HelmValue >= 7)
            {
                if (ExMetF_Sav02 != "null")
                {
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetF_Bone), MemoryManager.StringToByteArray(ExMetF_Sav02.Replace(" ", string.Empty)));
                }
            }
            if (HelmValue >= 8)
            {
                if (ExMetG_Sav02 != "null")
                {
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetG_Bone), MemoryManager.StringToByteArray(ExMetG_Sav02.Replace(" ", string.Empty)));
                }
            }
            if (HelmValue >= 9)
            {
                if (ExMetH_Sav02 != "null")
                {
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetH_Bone), MemoryManager.StringToByteArray(ExMetH_Sav02.Replace(" ", string.Empty)));
                }
            }
            if (HelmValue >= 10)
            {
                if (ExMetI_Sav02 != "null")
                {
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetI_Bone), MemoryManager.StringToByteArray(ExMetI_Sav02.Replace(" ", string.Empty)));
                }
            }
            if (HelmValue >= 11)
            {
                if (ExMetJ_Sav02 != "null")
                {
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetJ_Bone), MemoryManager.StringToByteArray(ExMetJ_Sav02.Replace(" ", string.Empty)));
                }
            }
            if (HelmValue >= 12)
            {
                if (ExMetK_Sav02 != "null")
                {
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetK_Bone), MemoryManager.StringToByteArray(ExMetK_Sav02.Replace(" ", string.Empty)));
                }
            }
            if (HelmValue >= 13)
            {
                if (ExMetL_Sav02 != "null")
                {
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetL_Bone), MemoryManager.StringToByteArray(ExMetL_Sav02.Replace(" ", string.Empty)));
                }
            }
            if (HelmValue >= 14)
            {
                if (ExMetM_Sav02 != "null")
                {
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetM_Bone), MemoryManager.StringToByteArray(ExMetM_Sav02.Replace(" ", string.Empty)));
                }
            }
            if (HelmValue >= 15)
            {
                if (ExMetN_Sav02 != "null")
                {
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetN_Bone), MemoryManager.StringToByteArray(ExMetN_Sav02.Replace(" ", string.Empty)));
                }
            }
            if (HelmValue >= 16)
            {
                if (ExMetO_Sav02 != "null")
                {
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetO_Bone), MemoryManager.StringToByteArray(ExMetO_Sav02.Replace(" ", string.Empty)));
                }
            }
            if (HelmValue >= 17)
            {
                if (ExMetP_Sav02 != "null")
                {
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetP_Bone), MemoryManager.StringToByteArray(ExMetP_Sav02.Replace(" ", string.Empty)));
                }
            }
            if (HelmValue >= 18)
            {
                if (ExMetQ_Sav02 != "null")
                {
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetQ_Bone), MemoryManager.StringToByteArray(ExMetQ_Sav02.Replace(" ", string.Empty)));
                }
            }
            if (HelmValue >= 19)
            {
                if (ExMetR_Sav02 != "null")
                {
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMetR_Bone), MemoryManager.StringToByteArray(ExMetR_Sav02.Replace(" ", string.Empty)));
                }
            }
        }
        #endregion
        #region Savestate\Loadstate Top
        private void SavestateTop01_Click(object sender, RoutedEventArgs e)
        {
            TopSaved01 = true;
            if (EditModeButton.IsChecked == true) LoadstateTop01.IsEnabled = true;
            var TopValue = m.readByte(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExTop_Value));

            if (TopValue >= 1)
            {
                ExRootTop_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExRootTop_Bone), 16));
            }
            if (TopValue >= 2)
            {
                ExTopA_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExTopA_Bone), 16));
            }
            else
            {
                ExTopA_Sav01 = "null";
            }
            if (TopValue >= 3)
            {
                ExTopB_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExTopB_Bone), 16));
            }
            else
            {
                ExTopB_Sav01 = "null";
            }
            if (TopValue >= 4)
            {
                ExTopC_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExTopC_Bone), 16));
            }
            else
            {
                ExTopC_Sav01 = "null";
            }
            if (TopValue >= 5)
            {
                ExTopD_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExTopD_Bone), 16));
            }
            else
            {
                ExTopD_Sav01 = "null";
            }
            if (TopValue >= 6)
            {
                ExTopE_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExTopE_Bone), 16));
            }
            else
            {
                ExTopE_Sav01 = "null";
            }
            if (TopValue >= 7)
            {
                ExTopF_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExTopF_Bone), 16));
            }
            else
            {
                ExTopF_Sav01 = "null";
            }
            if (TopValue >= 8)
            {
                ExTopG_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExTopG_Bone), 16));
            }
            else
            {
                ExTopG_Sav01 = "null";
            }
            if (TopValue >= 9)
            {
                ExTopH_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExTopH_Bone), 16));
            }
            else
            {
                ExTopH_Sav01 = "null";
            }
            if (TopValue >= 10)
            {
                ExTopI_Sav01 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExTopI_Bone), 16));
            }
            else
            {
                ExTopI_Sav01 = "null";
            }
            if (ExRootTop_Sav01 == null)
            {
                ExRootTop_Sav01 = "null";
                ExTopA_Sav01 = "null";
                ExTopB_Sav01 = "null";
                ExTopC_Sav01 = "null";
                ExTopD_Sav01 = "null";
                ExTopE_Sav01 = "null";
                ExTopF_Sav01 = "null";
                ExTopG_Sav01 = "null";
                ExTopH_Sav01 = "null";
                ExTopI_Sav01 = "null";
            }
        }
        private void SavestateTop02_Click(object sender, RoutedEventArgs e)
        {
            TopSaved02 = true;
            if (EditModeButton.IsChecked == true) LoadstateTop02.IsEnabled = true;
            var TopValue = m.readByte(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExTop_Value));

            if (TopValue >= 1)
            {
                ExRootTop_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExRootTop_Bone), 16));
            }
            if (TopValue >= 2)
            {
                ExTopA_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExTopA_Bone), 16));
            }
            else
            {
                ExTopA_Sav02 = "null";
            }
            if (TopValue >= 3)
            {
                ExTopB_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExTopB_Bone), 16));
            }
            else
            {
                ExTopB_Sav02 = "null";
            }
            if (TopValue >= 4)
            {
                ExTopC_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExTopC_Bone), 16));
            }
            else
            {
                ExTopC_Sav02 = "null";
            }
            if (TopValue >= 5)
            {
                ExTopD_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExTopD_Bone), 16));
            }
            else
            {
                ExTopD_Sav02 = "null";
            }
            if (TopValue >= 6)
            {
                ExTopE_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExTopE_Bone), 16));
            }
            else
            {
                ExTopE_Sav02 = "null";
            }
            if (TopValue >= 7)
            {
                ExTopF_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExTopF_Bone), 16));
            }
            else
            {
                ExTopF_Sav02 = "null";
            }
            if (TopValue >= 8)
            {
                ExTopG_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExTopG_Bone), 16));
            }
            else
            {
                ExTopG_Sav02 = "null";
            }
            if (TopValue >= 9)
            {
                ExTopH_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExTopH_Bone), 16));
            }
            else
            {
                ExTopH_Sav02 = "null";
            }
            if (TopValue >= 10)
            {
                ExTopI_Sav02 = MemoryManager.ByteArrayToString(m.readBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExTopI_Bone), 16));
            }
            else
            {
                ExTopI_Sav02 = "null";
            }
            if (ExRootTop_Sav02 == null)
            {
                ExRootTop_Sav02 = "null";
                ExTopA_Sav02 = "null";
                ExTopB_Sav02 = "null";
                ExTopC_Sav02 = "null";
                ExTopD_Sav02 = "null";
                ExTopE_Sav02 = "null";
                ExTopF_Sav02 = "null";
                ExTopG_Sav02 = "null";
                ExTopH_Sav02 = "null";
                ExTopI_Sav02 = "null";
            }
        }
        private void LoadstateTop01_Click(object sender, RoutedEventArgs e)
        {
            UncheckAll();
            var TopValue = m.readByte(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExTop_Value));

            if (TopValue >= 2)
            {
                if (ExTopA_Sav01 != "null")
                {
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExTopA_Bone), MemoryManager.StringToByteArray(ExTopA_Sav01.Replace(" ", string.Empty)));
                }
            }
            if (TopValue >= 3)
            {
                if (ExTopB_Sav01 != "null")
                {
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExTopB_Bone), MemoryManager.StringToByteArray(ExTopB_Sav01.Replace(" ", string.Empty)));
                }
            }
            if (TopValue >= 4)
            {
                if (ExTopC_Sav01 != "null")
                {
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExTopC_Bone), MemoryManager.StringToByteArray(ExTopC_Sav01.Replace(" ", string.Empty)));
                }
            }
            if (TopValue >= 5)
            {
                if (ExTopD_Sav01 != "null")
                {
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExTopD_Bone), MemoryManager.StringToByteArray(ExTopD_Sav01.Replace(" ", string.Empty)));
                }
            }
            if (TopValue >= 6)
            {
                if (ExTopE_Sav01 != "null")
                {
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExTopE_Bone), MemoryManager.StringToByteArray(ExTopE_Sav01.Replace(" ", string.Empty)));
                }
            }
            if (TopValue >= 7)
            {
                if (ExTopF_Sav01 != "null")
                {
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExTopF_Bone), MemoryManager.StringToByteArray(ExTopF_Sav01.Replace(" ", string.Empty)));
                }
            }
            if (TopValue >= 8)
            {
                if (ExTopG_Sav01 != "null")
                {
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExTopG_Bone), MemoryManager.StringToByteArray(ExTopG_Sav01.Replace(" ", string.Empty)));
                }
            }
            if (TopValue >= 9)
            {
                if (ExTopH_Sav01 != "null")
                {
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExTopH_Bone), MemoryManager.StringToByteArray(ExTopH_Sav01.Replace(" ", string.Empty)));
                }
            }
            if (TopValue >= 10)
            {
                if (ExTopI_Sav01 != "null")
                {
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExTopI_Bone), MemoryManager.StringToByteArray(ExTopI_Sav01.Replace(" ", string.Empty)));
                }
            }
        }
        private void LoadstateTop02_Click(object sender, RoutedEventArgs e)
        {
            UncheckAll();
            var TopValue = m.readByte(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExTop_Value));

            if (TopValue >= 2)
            {
                if (ExTopA_Sav02 != "null")
                {
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExTopA_Bone), MemoryManager.StringToByteArray(ExTopA_Sav02.Replace(" ", string.Empty)));
                }
            }
            if (TopValue >= 3)
            {
                if (ExTopB_Sav02 != "null")
                {
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExTopB_Bone), MemoryManager.StringToByteArray(ExTopB_Sav02.Replace(" ", string.Empty)));
                }
            }
            if (TopValue >= 4)
            {
                if (ExTopC_Sav02 != "null")
                {
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExTopC_Bone), MemoryManager.StringToByteArray(ExTopC_Sav02.Replace(" ", string.Empty)));
                }
            }
            if (TopValue >= 5)
            {
                if (ExTopD_Sav02 != "null")
                {
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExTopD_Bone), MemoryManager.StringToByteArray(ExTopD_Sav02.Replace(" ", string.Empty)));
                }
            }
            if (TopValue >= 6)
            {
                if (ExTopE_Sav02 != "null")
                {
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExTopE_Bone), MemoryManager.StringToByteArray(ExTopE_Sav02.Replace(" ", string.Empty)));
                }
            }
            if (TopValue >= 7)
            {
                if (ExTopF_Sav02 != "null")
                {
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExTopF_Bone), MemoryManager.StringToByteArray(ExTopF_Sav02.Replace(" ", string.Empty)));
                }
            }
            if (TopValue >= 8)
            {
                if (ExTopG_Sav02 != "null")
                {
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExTopG_Bone), MemoryManager.StringToByteArray(ExTopG_Sav02.Replace(" ", string.Empty)));
                }
            }
            if (TopValue >= 9)
            {
                if (ExTopH_Sav02 != "null")
                {
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExTopH_Bone), MemoryManager.StringToByteArray(ExTopH_Sav02.Replace(" ", string.Empty)));
                }
            }
            if (TopValue >= 10)
            {
                if (ExTopI_Sav02 != "null")
                {
                    m.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExTopI_Bone), MemoryManager.StringToByteArray(ExTopI_Sav02.Replace(" ", string.Empty)));
                }
            }
        }
        #endregion

        public void EnableTertiary()
        {
            DisableTertiary();
            PoseMatrixViewModel.PoseVM.Bone_Flag_Manager();
        }

        private void WeaponPoSToggle_Checked(object sender, RoutedEventArgs e)
        {
            ScaleToggle.IsChecked = false;
            Memory.MemLib.writeMemory(Memory.SkeletonAddress5, "bytes", "0x90 0x90 0x90 0x90 0x90");
            if (WeaponPoSToggle.IsKeyboardFocusWithin || WeaponPoSToggle.IsMouseOver)
            {
                UncheckAll();
                EnableAll();

                #region Disable Controls

                // TertiaryButton.IsEnabled = false;
                Root.IsEnabled = false;
                Abdomen.IsEnabled = false;
                Throw.IsEnabled = false;
                Waist.IsEnabled = false;
                SpineA.IsEnabled = false;
                LegLeft.IsEnabled = false;
                LegRight.IsEnabled = false;
                SpineB.IsEnabled = false;
                ClothBackALeft.IsEnabled = false;
                ClothBackARight.IsEnabled = false;
                ClothFrontALeft.IsEnabled = false;
                ClothFrontARight.IsEnabled = false;
                ClothSideALeft.IsEnabled = false;
                ClothSideARight.IsEnabled = false;
                KneeLeft.IsEnabled = false;
                KneeRight.IsEnabled = false;
                BreastLeft.IsEnabled = false;
                BreastRight.IsEnabled = false;
                SpineC.IsEnabled = false;
                ClothBackBLeft.IsEnabled = false;
                ClothBackBRight.IsEnabled = false;
                ClothFrontBLeft.IsEnabled = false;
                ClothFrontBRight.IsEnabled = false;
                ClothSideBLeft.IsEnabled = false;
                ClothSideBRight.IsEnabled = false;
                CalfLeft.IsEnabled = false;
                CalfRight.IsEnabled = false;
                Neck.IsEnabled = false;
                ClavicleLeft.IsEnabled = false;
                ClavicleRight.IsEnabled = false;
                ClothBackCLeft.IsEnabled = false;
                ClothBackCRight.IsEnabled = false;
                ClothFrontCLeft.IsEnabled = false;
                ClothFrontCRight.IsEnabled = false;
                ClothSideCLeft.IsEnabled = false;
                ClothSideCRight.IsEnabled = false;
                PoleynLeft.IsEnabled = false;
                PoleynRight.IsEnabled = false;
                FootLeft.IsEnabled = false;
                FootRight.IsEnabled = false;
                Head.IsEnabled = false;
                ArmLeft.IsEnabled = false;
                ArmRight.IsEnabled = false;
                PauldronLeft.IsEnabled = false;
                PauldronRight.IsEnabled = false;
                Unknown00.IsEnabled = false;
                ToesLeft.IsEnabled = false;
                ToesRight.IsEnabled = false;
                HairA.IsEnabled = false;
                HairFrontLeft.IsEnabled = false;
                HairFrontRight.IsEnabled = false;
                EarLeft.IsEnabled = false;
                EarRight.IsEnabled = false;
                ForearmLeft.IsEnabled = false;
                ForearmRight.IsEnabled = false;
                ShoulderLeft.IsEnabled = false;
                ShoulderRight.IsEnabled = false;
                HairB.IsEnabled = false;
                HandLeft.IsEnabled = false;
                HandRight.IsEnabled = false;
                ShieldLeft.IsEnabled = false;
                ShieldRight.IsEnabled = false;
                //     EarringALeft.IsEnabled = false;
                //      EarringARight.IsEnabled = false;
                ElbowLeft.IsEnabled = false;
                ElbowRight.IsEnabled = false;
                CouterLeft.IsEnabled = false;
                CouterRight.IsEnabled = false;
                WristLeft.IsEnabled = false;
                WristRight.IsEnabled = false;
                IndexALeft.IsEnabled = false;
                IndexARight.IsEnabled = false;
                PinkyALeft.IsEnabled = false;
                PinkyARight.IsEnabled = false;
                RingALeft.IsEnabled = false;
                RingARight.IsEnabled = false;
                MiddleALeft.IsEnabled = false;
                MiddleARight.IsEnabled = false;
                ThumbALeft.IsEnabled = false;
                ThumbARight.IsEnabled = false;
                //    EarringBLeft.IsEnabled = false;
                //   EarringBRight.IsEnabled = false;
                IndexBLeft.IsEnabled = false;
                IndexBRight.IsEnabled = false;
                PinkyBLeft.IsEnabled = false;
                PinkyBRight.IsEnabled = false;
                RingBLeft.IsEnabled = false;
                RingBRight.IsEnabled = false;
                MiddleBLeft.IsEnabled = false;
                MiddleBRight.IsEnabled = false;
                ThumbBLeft.IsEnabled = false;
                ThumbBRight.IsEnabled = false;
                RootHead.IsEnabled = false;
                Jaw.IsEnabled = false;
                EyelidLowerLeft.IsEnabled = false;
                EyelidLowerRight.IsEnabled = false;
                EyeLeft.IsEnabled = false;
                EyeRight.IsEnabled = false;
                Nose.IsEnabled = false;
                CheekLeft.IsEnabled = false;
                HrothWhiskersLeft.IsEnabled = false;
                CheekRight.IsEnabled = false;
                HrothWhiskersRight.IsEnabled = false;
                LipsLeft.IsEnabled = false;
                LipsRight.IsEnabled = false;
                EyebrowLeft.IsEnabled = false;
                EyebrowRight.IsEnabled = false;
                Bridge.IsEnabled = false;
                BrowLeft.IsEnabled = false;
                BrowRight.IsEnabled = false;
                LipUpperA.IsEnabled = false;
                EyelidUpperLeft.IsEnabled = false;
                EyelidUpperRight.IsEnabled = false;
                LipLowerA.IsEnabled = false;
                LipUpperB.IsEnabled = false;
                LipLowerB.IsEnabled = false;
                DisableTertiary();

                //LoadHeadButton.IsEnabled = false;
                //LoadTorsoButton.IsEnabled = false;
                //LoadLArmButton.IsEnabled = false;
                //LoadRArmButton.IsEnabled = false;
                //LoadLLegButton.IsEnabled = false;
                //LoadRLegButton.IsEnabled = false;
                #endregion
            }
        }

        private void WeaponPoSToggle_Unchecked(object sender, RoutedEventArgs e)
        {
            Memory.MemLib.writeMemory(Memory.SkeletonAddress5, "bytes", "0x41 0x0F 0x29 0x24 0x12");

            if (WeaponPoSToggle.IsKeyboardFocusWithin || WeaponPoSToggle.IsMouseOver)
            {
                UncheckAll();
                #region Enable Controls
                // TertiaryButton.IsEnabled = true;
                //Root.IsEnabled = true;
                //Abdomen.IsEnabled = true;
                //Throw.IsEnabled = true;
                Waist.IsEnabled = true;
                SpineA.IsEnabled = true;
                LegLeft.IsEnabled = true;
                LegRight.IsEnabled = true;
                HolsterLeft.IsEnabled = true;
                HolsterRight.IsEnabled = true;
                SheatheLeft.IsEnabled = true;
                SheatheRight.IsEnabled = true;
                SpineB.IsEnabled = true;
                ClothBackALeft.IsEnabled = true;
                ClothBackARight.IsEnabled = true;
                ClothFrontALeft.IsEnabled = true;
                ClothFrontARight.IsEnabled = true;
                ClothSideALeft.IsEnabled = true;
                ClothSideARight.IsEnabled = true;
                KneeLeft.IsEnabled = true;
                KneeRight.IsEnabled = true;
                BreastLeft.IsEnabled = true;
                BreastRight.IsEnabled = true;
                SpineC.IsEnabled = true;
                ClothBackBLeft.IsEnabled = true;
                ClothBackBRight.IsEnabled = true;
                ClothFrontBLeft.IsEnabled = true;
                ClothFrontBRight.IsEnabled = true;
                ClothSideBLeft.IsEnabled = true;
                ClothSideBRight.IsEnabled = true;
                CalfLeft.IsEnabled = true;
                CalfRight.IsEnabled = true;
                ScabbardLeft.IsEnabled = true;
                ScabbardRight.IsEnabled = true;
                Neck.IsEnabled = true;
                ClavicleLeft.IsEnabled = true;
                ClavicleRight.IsEnabled = true;
                ClothBackCLeft.IsEnabled = true;
                ClothBackCRight.IsEnabled = true;
                ClothFrontCLeft.IsEnabled = true;
                ClothFrontCRight.IsEnabled = true;
                ClothSideCLeft.IsEnabled = true;
                ClothSideCRight.IsEnabled = true;
                PoleynLeft.IsEnabled = true;
                PoleynRight.IsEnabled = true;
                FootLeft.IsEnabled = true;
                FootRight.IsEnabled = true;
                Head.IsEnabled = true;
                ArmLeft.IsEnabled = true;
                ArmRight.IsEnabled = true;
                PauldronLeft.IsEnabled = true;
                PauldronRight.IsEnabled = true;
                Unknown00.IsEnabled = true;
                ToesLeft.IsEnabled = true;
                ToesRight.IsEnabled = true;
                HairA.IsEnabled = true;
                HairFrontLeft.IsEnabled = true;
                HairFrontRight.IsEnabled = true;
                EarLeft.IsEnabled = true;
                EarRight.IsEnabled = true;
                ForearmLeft.IsEnabled = true;
                ForearmRight.IsEnabled = true;
                ShoulderLeft.IsEnabled = true;
                ShoulderRight.IsEnabled = true;
                HairB.IsEnabled = true;
                HandLeft.IsEnabled = true;
                HandRight.IsEnabled = true;
                ShieldLeft.IsEnabled = true;
                ShieldRight.IsEnabled = true;
                EarringALeft.IsEnabled = true;
                EarringARight.IsEnabled = true;
                ElbowLeft.IsEnabled = true;
                ElbowRight.IsEnabled = true;
                CouterLeft.IsEnabled = true;
                CouterRight.IsEnabled = true;
                WristLeft.IsEnabled = true;
                WristRight.IsEnabled = true;
                IndexALeft.IsEnabled = true;
                IndexARight.IsEnabled = true;
                PinkyALeft.IsEnabled = true;
                PinkyARight.IsEnabled = true;
                RingALeft.IsEnabled = true;
                RingARight.IsEnabled = true;
                MiddleALeft.IsEnabled = true;
                MiddleARight.IsEnabled = true;
                ThumbALeft.IsEnabled = true;
                ThumbARight.IsEnabled = true;
                WeaponLeft.IsEnabled = true;
                WeaponRight.IsEnabled = true;
                EarringBLeft.IsEnabled = true;
                EarringBRight.IsEnabled = true;
                IndexBLeft.IsEnabled = true;
                IndexBRight.IsEnabled = true;
                PinkyBLeft.IsEnabled = true;
                PinkyBRight.IsEnabled = true;
                RingBLeft.IsEnabled = true;
                RingBRight.IsEnabled = true;
                MiddleBLeft.IsEnabled = true;
                MiddleBRight.IsEnabled = true;
                ThumbBLeft.IsEnabled = true;
                ThumbBRight.IsEnabled = true;
                //TailA.IsEnabled = true;
                //TailB.IsEnabled = true;
                //TailC.IsEnabled = true;
                //TailD.IsEnabled = true;
                //TailE.IsEnabled = true;
                //RootHead.IsEnabled = true;
                Jaw.IsEnabled = true;
                EyelidLowerLeft.IsEnabled = true;
                EyelidLowerRight.IsEnabled = true;
                EyeLeft.IsEnabled = true;
                EyeRight.IsEnabled = true;
                Nose.IsEnabled = true;
                CheekLeft.IsEnabled = true;
                CheekRight.IsEnabled = true;
                LipsLeft.IsEnabled = true;
                LipsRight.IsEnabled = true;
                EyebrowLeft.IsEnabled = true;
                EyebrowRight.IsEnabled = true;
                Bridge.IsEnabled = true;
                BrowLeft.IsEnabled = true;
                BrowRight.IsEnabled = true;
                LipUpperA.IsEnabled = true;
                EyelidUpperLeft.IsEnabled = true;
                EyelidUpperRight.IsEnabled = true;
                LipLowerA.IsEnabled = true;
                LipUpperB.IsEnabled = true;
                LipLowerB.IsEnabled = true;
                //HrothWhiskersLeft.IsEnabled = true;
                //HrothWhiskersRight.IsEnabled = true;
                //VieraEarALeft.IsEnabled = true;
                //VieraEarARight.IsEnabled = true;
                //VieraEarBLeft.IsEnabled = true;
                //VieraEarBRight.IsEnabled = true;
                //ExHairA.IsEnabled = true;
                //ExHairB.IsEnabled = true;
                //ExHairC.IsEnabled = true;
                //ExHairD.IsEnabled = true;
                //ExHairE.IsEnabled = true;
                //ExHairF.IsEnabled = true;
                //ExHairG.IsEnabled = true;
                //ExHairH.IsEnabled = true;
                //ExHairI.IsEnabled = true;
                //ExHairJ.IsEnabled = true;
                //ExHairK.IsEnabled = true;
                //ExHairL.IsEnabled = true;
                //ExMetA.IsEnabled = true;
                //ExMetB.IsEnabled = true;
                //ExMetC.IsEnabled = true;
                //ExMetD.IsEnabled = true;
                //ExMetE.IsEnabled = true;
                //ExMetF.IsEnabled = true;
                //ExMetG.IsEnabled = true;
                //ExMetH.IsEnabled = true;
                //ExMetI.IsEnabled = true;
                //ExMetJ.IsEnabled = true;
                //ExMetK.IsEnabled = true;
                //ExMetL.IsEnabled = true;
                //ExMetM.IsEnabled = true;
                //ExMetN.IsEnabled = true;
                //ExMetO.IsEnabled = true;
                //ExMetP.IsEnabled = true;
                //ExMetQ.IsEnabled = true;
                //ExMetR.IsEnabled = true;
                //ExTopA.IsEnabled = true;
                //ExTopB.IsEnabled = true;
                //ExTopC.IsEnabled = true;
                //ExTopD.IsEnabled = true;
                //ExTopE.IsEnabled = true;
                //ExTopF.IsEnabled = true;
                //ExTopG.IsEnabled = true;
                //ExTopH.IsEnabled = true;
                //ExTopI.IsEnabled = true;

                //if (HeadSaved) LoadHeadButton.IsEnabled = true;
                //if (TorsoSaved) LoadTorsoButton.IsEnabled = true;
                //if (LeftArmSaved) LoadLArmButton.IsEnabled = true;
                //if (RightArmSaved) LoadRArmButton.IsEnabled = true;
                //if (LeftLegSaved) LoadLLegButton.IsEnabled = true;
                //if (RightLegSaved) LoadRLegButton.IsEnabled = true;

                EnableTertiary();
                #endregion
            }
        }

        private void ScaleToggle_Checked(object sender, RoutedEventArgs e)
        {
            WeaponPoSToggle.IsChecked = false;
            if (ScaleToggle.IsKeyboardFocusWithin || ScaleToggle.IsMouseOver)
            {
                UncheckAll();
                EnableAll();

                #region Disable Controls
                PhysicsButton.IsEnabled = false;
                Root.IsEnabled = false;
                Abdomen.IsEnabled = false;
                Throw.IsEnabled = false;
                //        Waist.IsEnabled = false;
                //   SpineA.IsEnabled = false;
                //    LegLeft.IsEnabled = false;
                //     LegRight.IsEnabled = false;
                HolsterLeft.IsEnabled = false;
                HolsterRight.IsEnabled = false;
                SheatheLeft.IsEnabled = false;
                SheatheRight.IsEnabled = false;
                //     SpineB.IsEnabled = false;
                /*    ClothBackALeft.IsEnabled = false;
                    ClothBackARight.IsEnabled = false;
                    ClothFrontALeft.IsEnabled = false;
                    ClothFrontARight.IsEnabled = false;
                    ClothSideALeft.IsEnabled = false;
                    ClothSideARight.IsEnabled = false;*/
                //     KneeLeft.IsEnabled = false;
                //     KneeRight.IsEnabled = false;
                //      BreastLeft.IsEnabled = false;
                //      BreastRight.IsEnabled = false;
                //      SpineC.IsEnabled = false;
                /*    ClothBackBLeft.IsEnabled = false;
                    ClothBackBRight.IsEnabled = false;
                    ClothFrontBLeft.IsEnabled = false;
                    ClothFrontBRight.IsEnabled = false;
                    ClothSideBLeft.IsEnabled = false;
                    ClothSideBRight.IsEnabled = false;*/
                //    CalfLeft.IsEnabled = false;
                //     CalfRight.IsEnabled = false;
                ScabbardLeft.IsEnabled = false;
                ScabbardRight.IsEnabled = false;
                //      Neck.IsEnabled = false;
                //     ClavicleLeft.IsEnabled = false;
                //      ClavicleRight.IsEnabled = false;
                /*     ClothBackCLeft.IsEnabled = false;
                     ClothBackCRight.IsEnabled = false;
                     ClothFrontCLeft.IsEnabled = false;
                     ClothFrontCRight.IsEnabled = false;
                     ClothSideCLeft.IsEnabled = false;
                     ClothSideCRight.IsEnabled = false;*/
                // PoleynLeft.IsEnabled = false;
                //   PoleynRight.IsEnabled = false;
                //  FootLeft.IsEnabled = false;
                //   FootRight.IsEnabled = false;
                //            Head.IsEnabled = false;
                //    ArmLeft.IsEnabled = false;
                //     ArmRight.IsEnabled = false;
                //  PauldronLeft.IsEnabled = false;
                // PauldronRight.IsEnabled = false;
                Unknown00.IsEnabled = false;
                //  ToesLeft.IsEnabled = false;
                //   ToesRight.IsEnabled = false;
                //     HairA.IsEnabled = false;
                //  HairFrontLeft.IsEnabled = false;
                //  HairFrontRight.IsEnabled = false;
                //   EarLeft.IsEnabled = false;
                //  EarRight.IsEnabled = false;
                //    ForearmLeft.IsEnabled = false;
                //    ForearmRight.IsEnabled = false;
                //   ShoulderLeft.IsEnabled = false;
                //   ShoulderRight.IsEnabled = false;
                //     HairB.IsEnabled = false;
                //    HandLeft.IsEnabled = false;
                //   HandRight.IsEnabled = false;
                //     ShieldLeft.IsEnabled = false;
                //     ShieldRight.IsEnabled = false;
                EarringALeft.IsEnabled = false;
                EarringARight.IsEnabled = false;
                //   ElbowLeft.IsEnabled = false;
                //    ElbowRight.IsEnabled = false;
                //  CouterLeft.IsEnabled = false;
                //      CouterRight.IsEnabled = false;
                //    WristLeft.IsEnabled = false;
                //    WristRight.IsEnabled = false;
                //    IndexALeft.IsEnabled = false;
                //     IndexARight.IsEnabled = false;
                //    PinkyALeft.IsEnabled = false;
                //    PinkyARight.IsEnabled = false;
                //    RingALeft.IsEnabled = false;
                //RingARight.IsEnabled = false;
                //       MiddleALeft.IsEnabled = false;
                //      MiddleARight.IsEnabled = false;
                //  ThumbALeft.IsEnabled = false;
                // ThumbARight.IsEnabled = false;
                WeaponLeft.IsEnabled = false;
                WeaponRight.IsEnabled = false;
                EarringBLeft.IsEnabled = false;
                EarringBRight.IsEnabled = false;
                /*  IndexBLeft.IsEnabled = false;
                  IndexBRight.IsEnabled = false;
                  PinkyBLeft.IsEnabled = false;
                  PinkyBRight.IsEnabled = false;
                  RingBLeft.IsEnabled = false;
                  RingBRight.IsEnabled = false;
                  MiddleBLeft.IsEnabled = false;
                  MiddleBRight.IsEnabled = false;
                  ThumbBLeft.IsEnabled = false;
                  ThumbBRight.IsEnabled = false;*/
                RootHead.IsEnabled = false;
                //   Jaw.IsEnabled = false;
                //   EyelidLowerLeft.IsEnabled = false;
                //   EyelidLowerRight.IsEnabled = false;
                //   EyeLeft.IsEnabled = false;
                //   EyeRight.IsEnabled = false;
                //   Nose.IsEnabled = false;
                //   CheekLeft.IsEnabled = false;
                //  HrothWhiskersLeft.IsEnabled = false;
                //   CheekRight.IsEnabled = false;
                //   HrothWhiskersRight.IsEnabled = false;
                //LipsLeft.IsEnabled = false;
                // LipsRight.IsEnabled = false;
                // EyebrowLeft.IsEnabled = false;
                // EyebrowRight.IsEnabled = false;
                //   Bridge.IsEnabled = false;
                //  BrowLeft.IsEnabled = false;
                //  BrowRight.IsEnabled = false;
                // LipUpperA.IsEnabled = false;
                //    EyelidUpperLeft.IsEnabled = false;
                //   EyelidUpperRight.IsEnabled = false;
                //LipLowerA.IsEnabled = false;
                //  LipUpperB.IsEnabled = false;
                // LipLowerB.IsEnabled = false;
                EnableTertiary();
                #endregion
            }
        }

        private void ScaleToggle_Unchecked(object sender, RoutedEventArgs e)
        {
            if (ScaleToggle.IsKeyboardFocusWithin || ScaleToggle.IsMouseOver)
            {
                UncheckAll();

                #region Enable Controls
                // TertiaryButton.IsEnabled = true;
                //Root.IsEnabled = true;
                //Abdomen.IsEnabled = true;
                //Throw.IsEnabled = true;
                Waist.IsEnabled = true;
                SpineA.IsEnabled = true;
                LegLeft.IsEnabled = true;
                LegRight.IsEnabled = true;
                HolsterLeft.IsEnabled = true;
                HolsterRight.IsEnabled = true;
                SheatheLeft.IsEnabled = true;
                SheatheRight.IsEnabled = true;
                SpineB.IsEnabled = true;
                ClothBackALeft.IsEnabled = true;
                ClothBackARight.IsEnabled = true;
                ClothFrontALeft.IsEnabled = true;
                ClothFrontARight.IsEnabled = true;
                ClothSideALeft.IsEnabled = true;
                ClothSideARight.IsEnabled = true;
                KneeLeft.IsEnabled = true;
                KneeRight.IsEnabled = true;
                BreastLeft.IsEnabled = true;
                BreastRight.IsEnabled = true;
                SpineC.IsEnabled = true;
                ClothBackBLeft.IsEnabled = true;
                ClothBackBRight.IsEnabled = true;
                ClothFrontBLeft.IsEnabled = true;
                ClothFrontBRight.IsEnabled = true;
                ClothSideBLeft.IsEnabled = true;
                ClothSideBRight.IsEnabled = true;
                CalfLeft.IsEnabled = true;
                CalfRight.IsEnabled = true;
                ScabbardLeft.IsEnabled = true;
                ScabbardRight.IsEnabled = true;
                Neck.IsEnabled = true;
                ClavicleLeft.IsEnabled = true;
                ClavicleRight.IsEnabled = true;
                ClothBackCLeft.IsEnabled = true;
                ClothBackCRight.IsEnabled = true;
                ClothFrontCLeft.IsEnabled = true;
                ClothFrontCRight.IsEnabled = true;
                ClothSideCLeft.IsEnabled = true;
                ClothSideCRight.IsEnabled = true;
                PoleynLeft.IsEnabled = true;
                PoleynRight.IsEnabled = true;
                FootLeft.IsEnabled = true;
                FootRight.IsEnabled = true;
                Head.IsEnabled = true;
                ArmLeft.IsEnabled = true;
                ArmRight.IsEnabled = true;
                PauldronLeft.IsEnabled = true;
                PauldronRight.IsEnabled = true;
                Unknown00.IsEnabled = true;
                ToesLeft.IsEnabled = true;
                ToesRight.IsEnabled = true;
                HairA.IsEnabled = true;
                HairFrontLeft.IsEnabled = true;
                HairFrontRight.IsEnabled = true;
                EarLeft.IsEnabled = true;
                EarRight.IsEnabled = true;
                ForearmLeft.IsEnabled = true;
                ForearmRight.IsEnabled = true;
                ShoulderLeft.IsEnabled = true;
                ShoulderRight.IsEnabled = true;
                HairB.IsEnabled = true;
                HandLeft.IsEnabled = true;
                HandRight.IsEnabled = true;
                ShieldLeft.IsEnabled = true;
                ShieldRight.IsEnabled = true;
                EarringALeft.IsEnabled = true;
                EarringARight.IsEnabled = true;
                ElbowLeft.IsEnabled = true;
                ElbowRight.IsEnabled = true;
                CouterLeft.IsEnabled = true;
                CouterRight.IsEnabled = true;
                WristLeft.IsEnabled = true;
                WristRight.IsEnabled = true;
                IndexALeft.IsEnabled = true;
                IndexARight.IsEnabled = true;
                PinkyALeft.IsEnabled = true;
                PinkyARight.IsEnabled = true;
                RingALeft.IsEnabled = true;
                RingARight.IsEnabled = true;
                MiddleALeft.IsEnabled = true;
                MiddleARight.IsEnabled = true;
                ThumbALeft.IsEnabled = true;
                ThumbARight.IsEnabled = true;
                WeaponLeft.IsEnabled = true;
                WeaponRight.IsEnabled = true;
                EarringBLeft.IsEnabled = true;
                EarringBRight.IsEnabled = true;
                IndexBLeft.IsEnabled = true;
                IndexBRight.IsEnabled = true;
                PinkyBLeft.IsEnabled = true;
                PinkyBRight.IsEnabled = true;
                RingBLeft.IsEnabled = true;
                RingBRight.IsEnabled = true;
                MiddleBLeft.IsEnabled = true;
                MiddleBRight.IsEnabled = true;
                ThumbBLeft.IsEnabled = true;
                ThumbBRight.IsEnabled = true;
                //TailA.IsEnabled = true;
                //TailB.IsEnabled = true;
                //TailC.IsEnabled = true;
                //TailD.IsEnabled = true;
                //TailE.IsEnabled = true;
                //RootHead.IsEnabled = true;
                Jaw.IsEnabled = true;
                EyelidLowerLeft.IsEnabled = true;
                EyelidLowerRight.IsEnabled = true;
                EyeLeft.IsEnabled = true;
                EyeRight.IsEnabled = true;
                Nose.IsEnabled = true;
                CheekLeft.IsEnabled = true;
                CheekRight.IsEnabled = true;
                LipsLeft.IsEnabled = true;
                LipsRight.IsEnabled = true;
                EyebrowLeft.IsEnabled = true;
                EyebrowRight.IsEnabled = true;
                Bridge.IsEnabled = true;
                BrowLeft.IsEnabled = true;
                BrowRight.IsEnabled = true;
                LipUpperA.IsEnabled = true;
                EyelidUpperLeft.IsEnabled = true;
                EyelidUpperRight.IsEnabled = true;
                LipLowerA.IsEnabled = true;
                LipUpperB.IsEnabled = true;
                LipLowerB.IsEnabled = true;
                //HrothWhiskersLeft.IsEnabled = true;
                //HrothWhiskersRight.IsEnabled = true;
                //VieraEarALeft.IsEnabled = true;
                //VieraEarARight.IsEnabled = true;
                //VieraEarBLeft.IsEnabled = true;
                //VieraEarBRight.IsEnabled = true;
                //ExHairA.IsEnabled = true;
                //ExHairB.IsEnabled = true;
                //ExHairC.IsEnabled = true;
                //ExHairD.IsEnabled = true;
                //ExHairE.IsEnabled = true;
                //ExHairF.IsEnabled = true;
                //ExHairG.IsEnabled = true;
                //ExHairH.IsEnabled = true;
                //ExHairI.IsEnabled = true;
                //ExHairJ.IsEnabled = true;
                //ExHairK.IsEnabled = true;
                //ExHairL.IsEnabled = true;
                //ExMetA.IsEnabled = true;
                //ExMetB.IsEnabled = true;
                //ExMetC.IsEnabled = true;
                //ExMetD.IsEnabled = true;
                //ExMetE.IsEnabled = true;
                //ExMetF.IsEnabled = true;
                //ExMetG.IsEnabled = true;
                //ExMetH.IsEnabled = true;
                //ExMetI.IsEnabled = true;
                //ExMetJ.IsEnabled = true;
                //ExMetK.IsEnabled = true;
                //ExMetL.IsEnabled = true;
                //ExMetM.IsEnabled = true;
                //ExMetN.IsEnabled = true;
                //ExMetO.IsEnabled = true;
                //ExMetP.IsEnabled = true;
                //ExMetQ.IsEnabled = true;
                //ExMetR.IsEnabled = true;
                //ExTopA.IsEnabled = true;
                //ExTopB.IsEnabled = true;
                //ExTopC.IsEnabled = true;
                //ExTopD.IsEnabled = true;
                //ExTopE.IsEnabled = true;
                //ExTopF.IsEnabled = true;
                //ExTopG.IsEnabled = true;
                //ExTopH.IsEnabled = true;
                //ExTopI.IsEnabled = true;

                //if (HeadSaved) LoadHeadButton.IsEnabled = true;
                //if (TorsoSaved) LoadTorsoButton.IsEnabled = true;
                //if (LeftArmSaved) LoadLArmButton.IsEnabled = true;
                //if (RightArmSaved) LoadRArmButton.IsEnabled = true;
                //if (LeftLegSaved) LoadLLegButton.IsEnabled = true;
                //if (RightLegSaved) LoadRLegButton.IsEnabled = true;

                EnableTertiary();
                #endregion

            }
        }

        private void HelmToggle_Checked(object sender, RoutedEventArgs e)
        {
            int HelmValue = Memory.MemLib.readByte(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMet_Value));
            for (int i = 0; i < HelmValue - 1; i++)
            {
                PoseMatrixViewModel.PoseVM.bone_face.Add(PoseMatrixViewModel.PoseVM.bone_exmet[i]);
            }
        }

        private void HelmToggle_Unchecked(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < PoseMatrixViewModel.PoseVM.bone_exmet.Length; i++)
            {
                PoseMatrixViewModel.PoseVM.bone_face.Remove(PoseMatrixViewModel.PoseVM.bone_exmet[i]);
            }
        }

        #region Actor Rotation
        /// <summary>	
        /// Gets the euler angles from the UI elements.	
        /// </summary>	
        /// <returns>Vector3D representing euler angles.</returns>	
        private Vector3D GetEulerAngles() => new Vector3D(CharacterDetails.RotateX, CharacterDetails.RotateY, CharacterDetails.RotateZ);

        // I'm scared of the above being wrong sometimes (the GUI controls don't always match the real rotation).
        // Using this one based on the raw values until convinced it's safe.
        private Vector3D GetCurrenRotation() => new Quaternion(CharacterDetails.Rotation.value,
                                                                CharacterDetails.Rotation2.value,
                                                                CharacterDetails.Rotation3.value,
                                                                CharacterDetails.Rotation4.value).ToEulerAngles();
        private void RotationUpDown_SourceUpdated(object sender, DataTransferEventArgs e)
        {

            if (RotationSlider.IsKeyboardFocusWithin || RotationSlider.IsMouseOver)
            {
                RotationSlider.ValueChanged -= RotV2;
                RotationSlider.ValueChanged += RotV2;
            }

            if (RotationUpDown.IsKeyboardFocusWithin || RotationUpDown.IsMouseOver)
            {
                RotationUpDown.ValueChanged -= RotV;
                RotationUpDown.ValueChanged += RotV;
            }
        }
        private void RotationUpDown2_SourceUpdated(object sender, DataTransferEventArgs e)
        {
            if (RotationSlider2.IsKeyboardFocusWithin || RotationSlider2.IsMouseOver)
            {
                RotationSlider2.ValueChanged -= RotV2;
                RotationSlider2.ValueChanged += RotV2;
            }

            if (RotationUpDown2.IsKeyboardFocusWithin || RotationUpDown2.IsMouseOver)
            {
                RotationUpDown2.ValueChanged -= RotV;
                RotationUpDown2.ValueChanged += RotV;
            }
        }
        private void RotationUpDown3_SourceUpdated(object sender, DataTransferEventArgs e)
        {
            if (RotationSlider3.IsKeyboardFocusWithin || RotationSlider3.IsMouseOver)
            {
                RotationSlider3.ValueChanged -= RotV2;
                RotationSlider3.ValueChanged += RotV2;
            }

            if (RotationUpDown3.IsKeyboardFocusWithin || RotationUpDown3.IsMouseOver)
            {
                RotationUpDown3.ValueChanged -= RotV;
                RotationUpDown3.ValueChanged += RotV;
            }
        }
        private void RotV(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            lock (CharacterDetails.Rotation)
            {
                CharacterDetails.Rotation.value = (float)quat.X;
                CharacterDetails.Rotation2.value = (float)quat.Y;
                CharacterDetails.Rotation3.value = (float)quat.Z;
                CharacterDetails.Rotation4.value = (float)quat.W;
            }
            // Remove listeners for value changed.	
            RotationUpDown.ValueChanged -= RotV;
            RotationUpDown2.ValueChanged -= RotV;
            RotationUpDown3.ValueChanged -= RotV;
        }
        private void RotV2(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            lock (CharacterDetails.Rotation)
            {
                CharacterDetails.Rotation.value = (float)quat.X;
                CharacterDetails.Rotation2.value = (float)quat.Y;
                CharacterDetails.Rotation3.value = (float)quat.Z;
                CharacterDetails.Rotation4.value = (float)quat.W;
            }
            // Remove listeners for value changed.	
            RotationSlider.ValueChanged -= RotV2;
            RotationSlider2.ValueChanged -= RotV2;
            RotationSlider3.ValueChanged -= RotV2;
            //  Console.WriteLine(CharacterDetails.RotateY);	
        }
        #endregion

        #region position
        private void PosX_SourceUpdated(object sender, DataTransferEventArgs e) => Pos_SourceUpdated(PosX, XPosUpdate);
        private void PosY_SourceUpdated(object sender, DataTransferEventArgs e) => Pos_SourceUpdated(PosY, YPosUpdate);
        private void PosZ_SourceUpdated(object sender, DataTransferEventArgs e) => Pos_SourceUpdated(PosZ, ZPosUpdate);

        /// <summary>
        /// This thing exists because of the way this broken ass system works, the flag is purely to not trigger multiple source update loops.
        /// </summary>
        private bool PosAdvancedWorking = false;

        private void Pos_SourceUpdated(MahApps.Metro.Controls.NumericUpDown control, RoutedPropertyChangedEventHandler<double?> handler)
        {
            if (AdvancedMove && control.Name != PosY.Name)
            {
                // Ensure not in an existing event.
                if (!PosAdvancedWorking)
                {
                    control.ValueChanged -= AdvancedPosUpdate;
                    control.ValueChanged += AdvancedPosUpdate;
                }
            }
            else if (control.IsKeyboardFocusWithin || control.IsMouseOver)
            {
                control.ValueChanged -= handler;
                control.ValueChanged += handler;
            }
        }

        private const double Deg2Rad = (Math.PI * 2) / 360;

        private void AdvancedPosUpdate(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            // Get the control from sender.
            var control = (sender as MahApps.Metro.Controls.NumericUpDown);

            // Remove the event handler (?)
            control.ValueChanged -= AdvancedPosUpdate;

            // Flag that we're working to avoid updates later.
            PosAdvancedWorking = true;

            // Instantiate x and z floats for the vector.
            var x = 0.0;
            var z = 0.0;

            double oldX = 0;
            double oldZ = 0;

            // Set the appropriate axis based on which control this is.
            if (control.Name == PosX.Name)
            {
                z = (double)(e.NewValue - e.OldValue);
                oldX = e.OldValue ?? 0;
                oldZ = PosZ.Value ?? 0;
            }
            else
            {
                x = (double)(e.NewValue - e.OldValue);
                oldX = PosX.Value ?? 0;
                oldZ = e.OldValue ?? 0;
            }

            // Get the angle of the position.
            var degrees = GetEulerAngles().Y;

            // Get the cos and sin of radians.
            var ca = Math.Cos(degrees * Deg2Rad);
            var sa = Math.Sin(degrees * Deg2Rad);

            // Calculate the new vector.
            var newX = x * sa - z * ca;
            var newZ = x * ca + z * sa;

            // Update the values in the text field (yeah I know this is dumb but this whole thing is dumb so i'm gonna leave it like this I should honestly use the databinding but I never know how any of this stuff works because the codebase is all over the place and there's like 5 possible files where something might get read or written to memory and I give up)
            PosX.Value = oldX + newX;
            PosZ.Value = oldZ + newZ;

            MemoryManager.Instance.MemLib.writeMemory(
                MemoryManager.GetAddressString(
                    CharacterDetailsViewModel.baseAddr,
                    Settings.Instance.Character.Body.Base,
                    Settings.Instance.Character.Body.Position.X
                ),
                "float",
                PosX.Value.ToString()
            );

            MemoryManager.Instance.MemLib.writeMemory(
                MemoryManager.GetAddressString(
                    CharacterDetailsViewModel.baseAddr,
                    Settings.Instance.Character.Body.Base,
                    Settings.Instance.Character.Body.Position.Z
                ),
                "float",
                PosZ.Value.ToString()
            );

            // Work is done, future events can trigger now.
            PosAdvancedWorking = false;
        }

        private void XPosUpdate(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (PosX.Value.HasValue)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Position.X), "float", PosX.Value.ToString());
            PosX.ValueChanged -= XPosUpdate;
        }

        private void YPosUpdate(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (PosY.Value.HasValue)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Position.Y), "float", PosY.Value.ToString());
            PosY.ValueChanged -= YPosUpdate;
        }

        private void ZPosUpdate(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (PosZ.Value.HasValue)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Position.Z), "float", PosZ.Value.ToString());
            PosZ.ValueChanged -= ZPosUpdate;
        }

        private void PosRelButton_Checked(object sender, RoutedEventArgs e)
        {
            AdvancedMove = true;
        }

        private void PosRelButton_Unchecked(object sender, RoutedEventArgs e)
        {
            AdvancedMove = false;
        }

        #endregion

        private void ToggleModelView_Checked(object sender, RoutedEventArgs e)
        {
            ActorProperties.Visibility = Visibility.Visible;
            CubeBox.Visibility = Visibility.Hidden;

        }

        private void ToggleModelView_Unchecked(object sender, RoutedEventArgs e)
        {
            ActorProperties.Visibility = Visibility.Hidden;
            CubeBox.Visibility = Visibility.Visible;
        }

        private void ScaleSaveToggle_Checked(object sender, RoutedEventArgs e)
        {
            SaveSettings.Default.ScalingLoad = true;
        }

        private void ScaleSaveToggle_Unchecked(object sender, RoutedEventArgs e)
        {
            SaveSettings.Default.ScalingLoad = false;
        }

        private void DisableTertiary()
        {
            #region Disable Tertiary
            TailA.IsEnabled = false;
            TailB.IsEnabled = false;
            TailC.IsEnabled = false;
            TailD.IsEnabled = false;
            TailE.IsEnabled = false;
            HrothWhiskersLeft.IsEnabled = false;
            HrothWhiskersRight.IsEnabled = false;
            VieraEarALeft.IsEnabled = false;
            VieraEarARight.IsEnabled = false;
            VieraEarBLeft.IsEnabled = false;
            VieraEarBRight.IsEnabled = false;
            ExHairA.IsEnabled = false;
            ExHairB.IsEnabled = false;
            ExHairC.IsEnabled = false;
            ExHairD.IsEnabled = false;
            ExHairE.IsEnabled = false;
            ExHairF.IsEnabled = false;
            ExHairG.IsEnabled = false;
            ExHairH.IsEnabled = false;
            ExHairI.IsEnabled = false;
            ExHairJ.IsEnabled = false;
            ExHairK.IsEnabled = false;
            ExHairL.IsEnabled = false;
            ExMetA.IsEnabled = false;
            ExMetB.IsEnabled = false;
            ExMetC.IsEnabled = false;
            ExMetD.IsEnabled = false;
            ExMetE.IsEnabled = false;
            ExMetF.IsEnabled = false;
            ExMetG.IsEnabled = false;
            ExMetH.IsEnabled = false;
            ExMetI.IsEnabled = false;
            ExMetJ.IsEnabled = false;
            ExMetK.IsEnabled = false;
            ExMetL.IsEnabled = false;
            ExMetM.IsEnabled = false;
            ExMetN.IsEnabled = false;
            ExMetO.IsEnabled = false;
            ExMetP.IsEnabled = false;
            ExMetQ.IsEnabled = false;
            ExMetR.IsEnabled = false;
            ExTopA.IsEnabled = false;
            ExTopB.IsEnabled = false;
            ExTopC.IsEnabled = false;
            ExTopD.IsEnabled = false;
            ExTopE.IsEnabled = false;
            ExTopF.IsEnabled = false;
            ExTopG.IsEnabled = false;
            ExTopH.IsEnabled = false;
            ExTopI.IsEnabled = false;
            TailA.IsChecked = false;
            TailB.IsChecked = false;
            TailC.IsChecked = false;
            TailD.IsChecked = false;
            TailE.IsChecked = false;
            HrothWhiskersLeft.IsChecked = false;
            HrothWhiskersRight.IsChecked = false;
            VieraEarALeft.IsChecked = false;
            VieraEarARight.IsChecked = false;
            VieraEarBLeft.IsChecked = false;
            VieraEarBRight.IsChecked = false;
            ExHairA.IsChecked = false;
            ExHairB.IsChecked = false;
            ExHairC.IsChecked = false;
            ExHairD.IsChecked = false;
            ExHairE.IsChecked = false;
            ExHairF.IsChecked = false;
            ExHairG.IsChecked = false;
            ExHairH.IsChecked = false;
            ExHairI.IsChecked = false;
            ExHairJ.IsChecked = false;
            ExHairK.IsChecked = false;
            ExHairL.IsChecked = false;
            ExMetA.IsChecked = false;
            ExMetB.IsChecked = false;
            ExMetC.IsChecked = false;
            ExMetD.IsChecked = false;
            ExMetE.IsChecked = false;
            ExMetF.IsChecked = false;
            ExMetG.IsChecked = false;
            ExMetH.IsChecked = false;
            ExMetI.IsChecked = false;
            ExMetJ.IsChecked = false;
            ExMetK.IsChecked = false;
            ExMetL.IsChecked = false;
            ExMetM.IsChecked = false;
            ExMetN.IsChecked = false;
            ExMetO.IsChecked = false;
            ExMetP.IsChecked = false;
            ExMetQ.IsChecked = false;
            ExMetR.IsChecked = false;
            ExTopA.IsChecked = false;
            ExTopB.IsChecked = false;
            ExTopC.IsChecked = false;
            ExTopD.IsChecked = false;
            ExTopE.IsChecked = false;
            ExTopF.IsChecked = false;
            ExTopG.IsChecked = false;
            ExTopH.IsChecked = false;
            ExTopI.IsChecked = false;
            PoseMatrixViewModel.PoseVM.bone_waist.Remove(PoseMatrixViewModel.PoseVM.bone_tail_a);
            for (int i = 0; i < PoseMatrixViewModel.PoseVM.bone_exhair.Length; i++)
            {
                PoseMatrixViewModel.PoseVM.bone_face.Remove(PoseMatrixViewModel.PoseVM.bone_exhair[i]);
            }
            for (int i = 0; i < PoseMatrixViewModel.PoseVM.bone_viera_ear_l.Length; i++)
            {
                PoseMatrixViewModel.PoseVM.bone_face_viera.Remove(PoseMatrixViewModel.PoseVM.bone_viera_ear_l[i]);
                PoseMatrixViewModel.PoseVM.bone_face_viera.Remove(PoseMatrixViewModel.PoseVM.bone_viera_ear_r[i]);
            }
            for (int i = 0; i < PoseMatrixViewModel.PoseVM.bone_exmet.Length; i++)
            {
                PoseMatrixViewModel.PoseVM.bone_face.Remove(PoseMatrixViewModel.PoseVM.bone_exmet[i]);
            }
            PoseMatrixViewModel.PoseVM.ReadTetriaryFromRunTime = false;
            #endregion
        }
        public class BoneSaves
        {
            #region BoneSaves
            public string Description { get; set; }
            public string DateCreated { get; set; }
            public string CMPVersion { get; set; }

            public string Race { get; set; }
            public string Clan { get; set; }
            public string Body { get; set; }

            #region Regular Bones
            public string Root { get; set; }
            public string Abdomen { get; set; }
            public string Throw { get; set; }
            public string Waist { get; set; }
            public string SpineA { get; set; }
            public string LegLeft { get; set; }
            public string LegRight { get; set; }
            public string HolsterLeft { get; set; }
            public string HolsterRight { get; set; }
            public string SheatheLeft { get; set; }
            public string SheatheRight { get; set; }
            public string SpineB { get; set; }
            public string ClothBackALeft { get; set; }
            public string ClothBackARight { get; set; }
            public string ClothFrontALeft { get; set; }
            public string ClothFrontARight { get; set; }
            public string ClothSideALeft { get; set; }
            public string ClothSideARight { get; set; }
            public string KneeLeft { get; set; }
            public string KneeRight { get; set; }
            public string BreastLeft { get; set; }
            public string BreastRight { get; set; }
            public string SpineC { get; set; }
            public string ClothBackBLeft { get; set; }
            public string ClothBackBRight { get; set; }
            public string ClothFrontBLeft { get; set; }
            public string ClothFrontBRight { get; set; }
            public string ClothSideBLeft { get; set; }
            public string ClothSideBRight { get; set; }
            public string CalfLeft { get; set; }
            public string CalfRight { get; set; }
            public string ScabbardLeft { get; set; }
            public string ScabbardRight { get; set; }
            public string Neck { get; set; }
            public string ClavicleLeft { get; set; }
            public string ClavicleRight { get; set; }
            public string ClothBackCLeft { get; set; }
            public string ClothBackCRight { get; set; }
            public string ClothFrontCLeft { get; set; }
            public string ClothFrontCRight { get; set; }
            public string ClothSideCLeft { get; set; }
            public string ClothSideCRight { get; set; }
            public string PoleynLeft { get; set; }
            public string PoleynRight { get; set; }
            public string FootLeft { get; set; }
            public string FootRight { get; set; }
            public string Head { get; set; }
            public string ArmLeft { get; set; }
            public string ArmRight { get; set; }
            public string PauldronLeft { get; set; }
            public string PauldronRight { get; set; }
            public string Unknown00 { get; set; }
            public string ToesLeft { get; set; }
            public string ToesRight { get; set; }
            public string HairA { get; set; }
            public string HairFrontLeft { get; set; }
            public string HairFrontRight { get; set; }
            public string EarLeft { get; set; }
            public string EarRight { get; set; }
            public string ForearmLeft { get; set; }
            public string ForearmRight { get; set; }
            public string ShoulderLeft { get; set; }
            public string ShoulderRight { get; set; }
            public string HairB { get; set; }
            public string HandLeft { get; set; }
            public string HandRight { get; set; }
            public string ShieldLeft { get; set; }
            public string ShieldRight { get; set; }
            public string EarringALeft { get; set; }
            public string EarringARight { get; set; }
            public string ElbowLeft { get; set; }
            public string ElbowRight { get; set; }
            public string CouterLeft { get; set; }
            public string CouterRight { get; set; }
            public string WristLeft { get; set; }
            public string WristRight { get; set; }
            public string IndexALeft { get; set; }
            public string IndexARight { get; set; }
            public string PinkyALeft { get; set; }
            public string PinkyARight { get; set; }
            public string RingALeft { get; set; }
            public string RingARight { get; set; }
            public string MiddleALeft { get; set; }
            public string MiddleARight { get; set; }
            public string ThumbALeft { get; set; }
            public string ThumbARight { get; set; }
            public string WeaponLeft { get; set; }
            public string WeaponRight { get; set; }
            public string EarringBLeft { get; set; }
            public string EarringBRight { get; set; }
            public string IndexBLeft { get; set; }
            public string IndexBRight { get; set; }
            public string PinkyBLeft { get; set; }
            public string PinkyBRight { get; set; }
            public string RingBLeft { get; set; }
            public string RingBRight { get; set; }
            public string MiddleBLeft { get; set; }
            public string MiddleBRight { get; set; }
            public string ThumbBLeft { get; set; }
            public string ThumbBRight { get; set; }
            public string TailA { get; set; }
            public string TailB { get; set; }
            public string TailC { get; set; }
            public string TailD { get; set; }
            public string TailE { get; set; }
            public string RootHead { get; set; }
            public string Jaw { get; set; }
            public string EyelidLowerLeft { get; set; }
            public string EyelidLowerRight { get; set; }
            public string EyeLeft { get; set; }
            public string EyeRight { get; set; }
            public string Nose { get; set; }
            public string CheekLeft { get; set; }
            public string HrothWhiskersLeft { get; set; }
            public string CheekRight { get; set; }
            public string HrothWhiskersRight { get; set; }
            public string LipsLeft { get; set; }
            public string HrothEyebrowLeft { get; set; }
            public string LipsRight { get; set; }
            public string HrothEyebrowRight { get; set; }
            public string EyebrowLeft { get; set; }
            public string HrothBridge { get; set; }
            public string EyebrowRight { get; set; }
            public string HrothBrowLeft { get; set; }
            public string Bridge { get; set; }
            public string HrothBrowRight { get; set; }
            public string BrowLeft { get; set; }
            public string HrothJawUpper { get; set; }
            public string BrowRight { get; set; }
            public string HrothLipUpper { get; set; }
            public string LipUpperA { get; set; }
            public string HrothEyelidUpperLeft { get; set; }
            public string EyelidUpperLeft { get; set; }
            public string HrothEyelidUpperRight { get; set; }
            public string EyelidUpperRight { get; set; }
            public string HrothLipsLeft { get; set; }
            public string LipLowerA { get; set; }
            public string HrothLipsRight { get; set; }
            public string VieraEar01ALeft { get; set; }
            public string LipUpperB { get; set; }
            public string HrothLipUpperLeft { get; set; }
            public string VieraEar01ARight { get; set; }
            public string LipLowerB { get; set; }
            public string HrothLipUpperRight { get; set; }
            public string VieraEar02ALeft { get; set; }
            public string HrothLipLower { get; set; }
            public string VieraEar02ARight { get; set; }
            public string VieraEar03ALeft { get; set; }
            public string VieraEar03ARight { get; set; }
            public string VieraEar04ALeft { get; set; }
            public string VieraEar04ARight { get; set; }
            public string VieraLipLowerA { get; set; }
            public string VieraLipUpperB { get; set; }
            public string VieraEar01BLeft { get; set; }
            public string VieraEar01BRight { get; set; }
            public string VieraEar02BLeft { get; set; }
            public string VieraEar02BRight { get; set; }
            public string VieraEar03BLeft { get; set; }
            public string VieraEar03BRight { get; set; }
            public string VieraEar04BLeft { get; set; }
            public string VieraEar04BRight { get; set; }
            public string VieraLipLowerB { get; set; }
            public string ExRootHair { get; set; }
            public string ExHairA { get; set; }
            public string ExHairB { get; set; }
            public string ExHairC { get; set; }
            public string ExHairD { get; set; }
            public string ExHairE { get; set; }
            public string ExHairF { get; set; }
            public string ExHairG { get; set; }
            public string ExHairH { get; set; }
            public string ExHairI { get; set; }
            public string ExHairJ { get; set; }
            public string ExHairK { get; set; }
            public string ExHairL { get; set; }
            public string ExRootMet { get; set; }
            public string ExMetA { get; set; }
            public string ExMetB { get; set; }
            public string ExMetC { get; set; }
            public string ExMetD { get; set; }
            public string ExMetE { get; set; }
            public string ExMetF { get; set; }
            public string ExMetG { get; set; }
            public string ExMetH { get; set; }
            public string ExMetI { get; set; }
            public string ExMetJ { get; set; }
            public string ExMetK { get; set; }
            public string ExMetL { get; set; }
            public string ExMetM { get; set; }
            public string ExMetN { get; set; }
            public string ExMetO { get; set; }
            public string ExMetP { get; set; }
            public string ExMetQ { get; set; }
            public string ExMetR { get; set; }
            public string ExRootTop { get; set; }
            public string ExTopA { get; set; }
            public string ExTopB { get; set; }
            public string ExTopC { get; set; }
            public string ExTopD { get; set; }
            public string ExTopE { get; set; }
            public string ExTopF { get; set; }
            public string ExTopG { get; set; }
            public string ExTopH { get; set; }
            public string ExTopI { get; set; }
            #endregion

            #region Scale Bones
            public string RootSize { get; set; }
            public string AbdomenSize { get; set; }
            public string ThrowSize { get; set; }
            public string WaistSize { get; set; }
            public string SpineASize { get; set; }
            public string LegLeftSize { get; set; }
            public string LegRightSize { get; set; }
            public string HolsterLeftSize { get; set; }
            public string HolsterRightSize { get; set; }
            public string SheatheLeftSize { get; set; }
            public string SheatheRightSize { get; set; }
            public string SpineBSize { get; set; }
            public string ClothBackALeftSize { get; set; }
            public string ClothBackARightSize { get; set; }
            public string ClothFrontALeftSize { get; set; }
            public string ClothFrontARightSize { get; set; }
            public string ClothSideALeftSize { get; set; }
            public string ClothSideARightSize { get; set; }
            public string KneeLeftSize { get; set; }
            public string KneeRightSize { get; set; }
            public string BreastLeftSize { get; set; }
            public string BreastRightSize { get; set; }
            public string SpineCSize { get; set; }
            public string ClothBackBLeftSize { get; set; }
            public string ClothBackBRightSize { get; set; }
            public string ClothFrontBLeftSize { get; set; }
            public string ClothFrontBRightSize { get; set; }
            public string ClothSideBLeftSize { get; set; }
            public string ClothSideBRightSize { get; set; }
            public string CalfLeftSize { get; set; }
            public string CalfRightSize { get; set; }
            public string ScabbardLeftSize { get; set; }
            public string ScabbardRightSize { get; set; }
            public string NeckSize { get; set; }
            public string ClavicleLeftSize { get; set; }
            public string ClavicleRightSize { get; set; }
            public string ClothBackCLeftSize { get; set; }
            public string ClothBackCRightSize { get; set; }
            public string ClothFrontCLeftSize { get; set; }
            public string ClothFrontCRightSize { get; set; }
            public string ClothSideCLeftSize { get; set; }
            public string ClothSideCRightSize { get; set; }
            public string PoleynLeftSize { get; set; }
            public string PoleynRightSize { get; set; }
            public string FootLeftSize { get; set; }
            public string FootRightSize { get; set; }
            public string HeadSize { get; set; }
            public string ArmLeftSize { get; set; }
            public string ArmRightSize { get; set; }
            public string PauldronLeftSize { get; set; }
            public string PauldronRightSize { get; set; }
            public string Unknown00Size { get; set; }
            public string ToesLeftSize { get; set; }
            public string ToesRightSize { get; set; }
            public string HairASize { get; set; }
            public string HairFrontLeftSize { get; set; }
            public string HairFrontRightSize { get; set; }
            public string EarLeftSize { get; set; }
            public string EarRightSize { get; set; }
            public string ForearmLeftSize { get; set; }
            public string ForearmRightSize { get; set; }
            public string ShoulderLeftSize { get; set; }
            public string ShoulderRightSize { get; set; }
            public string HairBSize { get; set; }
            public string HandLeftSize { get; set; }
            public string HandRightSize { get; set; }
            public string ShieldLeftSize { get; set; }
            public string ShieldRightSize { get; set; }
            public string EarringALeftSize { get; set; }
            public string EarringARightSize { get; set; }
            public string ElbowLeftSize { get; set; }
            public string ElbowRightSize { get; set; }
            public string CouterLeftSize { get; set; }
            public string CouterRightSize { get; set; }
            public string WristLeftSize { get; set; }
            public string WristRightSize { get; set; }
            public string IndexALeftSize { get; set; }
            public string IndexARightSize { get; set; }
            public string PinkyALeftSize { get; set; }
            public string PinkyARightSize { get; set; }
            public string RingALeftSize { get; set; }
            public string RingARightSize { get; set; }
            public string MiddleALeftSize { get; set; }
            public string MiddleARightSize { get; set; }
            public string ThumbALeftSize { get; set; }
            public string ThumbARightSize { get; set; }
            public string WeaponLeftSize { get; set; }
            public string WeaponRightSize { get; set; }
            public string EarringBLeftSize { get; set; }
            public string EarringBRightSize { get; set; }
            public string IndexBLeftSize { get; set; }
            public string IndexBRightSize { get; set; }
            public string PinkyBLeftSize { get; set; }
            public string PinkyBRightSize { get; set; }
            public string RingBLeftSize { get; set; }
            public string RingBRightSize { get; set; }
            public string MiddleBLeftSize { get; set; }
            public string MiddleBRightSize { get; set; }
            public string ThumbBLeftSize { get; set; }
            public string ThumbBRightSize { get; set; }
            public string TailASize { get; set; }
            public string TailBSize { get; set; }
            public string TailCSize { get; set; }
            public string TailDSize { get; set; }
            public string TailESize { get; set; }
            public string RootHeadSize { get; set; }
            public string JawSize { get; set; }
            public string EyelidLowerLeftSize { get; set; }
            public string EyelidLowerRightSize { get; set; }
            public string EyeLeftSize { get; set; }
            public string EyeRightSize { get; set; }
            public string NoseSize { get; set; }
            public string CheekLeftSize { get; set; }
            public string HrothWhiskersLeftSize { get; set; }
            public string CheekRightSize { get; set; }
            public string HrothWhiskersRightSize { get; set; }
            public string LipsLeftSize { get; set; }
            public string HrothEyebrowLeftSize { get; set; }
            public string LipsRightSize { get; set; }
            public string HrothEyebrowRightSize { get; set; }
            public string EyebrowLeftSize { get; set; }
            public string HrothBridgeSize { get; set; }
            public string EyebrowRightSize { get; set; }
            public string HrothBrowLeftSize { get; set; }
            public string BridgeSize { get; set; }
            public string HrothBrowRightSize { get; set; }
            public string BrowLeftSize { get; set; }
            public string HrothJawUpperSize { get; set; }
            public string BrowRightSize { get; set; }
            public string HrothLipUpperSize { get; set; }
            public string LipUpperASize { get; set; }
            public string HrothEyelidUpperLeftSize { get; set; }
            public string EyelidUpperLeftSize { get; set; }
            public string HrothEyelidUpperRightSize { get; set; }
            public string EyelidUpperRightSize { get; set; }
            public string HrothLipsLeftSize { get; set; }
            public string LipLowerASize { get; set; }
            public string HrothLipsRightSize { get; set; }
            public string VieraEar01ALeftSize { get; set; }
            public string LipUpperBSize { get; set; }
            public string HrothLipUpperLeftSize { get; set; }
            public string VieraEar01ARightSize { get; set; }
            public string LipLowerBSize { get; set; }
            public string HrothLipUpperRightSize { get; set; }
            public string VieraEar02ALeftSize { get; set; }
            public string HrothLipLowerSize { get; set; }
            public string VieraEar02ARightSize { get; set; }
            public string VieraEar03ALeftSize { get; set; }
            public string VieraEar03ARightSize { get; set; }
            public string VieraEar04ALeftSize { get; set; }
            public string VieraEar04ARightSize { get; set; }
            public string VieraLipLowerASize { get; set; }
            public string VieraLipUpperBSize { get; set; }
            public string VieraEar01BLeftSize { get; set; }
            public string VieraEar01BRightSize { get; set; }
            public string VieraEar02BLeftSize { get; set; }
            public string VieraEar02BRightSize { get; set; }
            public string VieraEar03BLeftSize { get; set; }
            public string VieraEar03BRightSize { get; set; }
            public string VieraEar04BLeftSize { get; set; }
            public string VieraEar04BRightSize { get; set; }
            public string VieraLipLowerBSize { get; set; }
            public string ExRootHairSize { get; set; }
            public string ExHairASize { get; set; }
            public string ExHairBSize { get; set; }
            public string ExHairCSize { get; set; }
            public string ExHairDSize { get; set; }
            public string ExHairESize { get; set; }
            public string ExHairFSize { get; set; }
            public string ExHairGSize { get; set; }
            public string ExHairHSize { get; set; }
            public string ExHairISize { get; set; }
            public string ExHairJSize { get; set; }
            public string ExHairKSize { get; set; }
            public string ExHairLSize { get; set; }
            public string ExRootMetSize { get; set; }
            public string ExMetASize { get; set; }
            public string ExMetBSize { get; set; }
            public string ExMetCSize { get; set; }
            public string ExMetDSize { get; set; }
            public string ExMetESize { get; set; }
            public string ExMetFSize { get; set; }
            public string ExMetGSize { get; set; }
            public string ExMetHSize { get; set; }
            public string ExMetISize { get; set; }
            public string ExMetJSize { get; set; }
            public string ExMetKSize { get; set; }
            public string ExMetLSize { get; set; }
            public string ExMetMSize { get; set; }
            public string ExMetNSize { get; set; }
            public string ExMetOSize { get; set; }
            public string ExMetPSize { get; set; }
            public string ExMetQSize { get; set; }
            public string ExMetRSize { get; set; }
            public string ExRootTopSize { get; set; }
            public string ExTopASize { get; set; }
            public string ExTopBSize { get; set; }
            public string ExTopCSize { get; set; }
            public string ExTopDSize { get; set; }
            public string ExTopESize { get; set; }
            public string ExTopFSize { get; set; }
            public string ExTopGSize { get; set; }
            public string ExTopHSize { get; set; }
            public string ExTopISize { get; set; }
            #endregion 
        }
        #endregion
    }
}