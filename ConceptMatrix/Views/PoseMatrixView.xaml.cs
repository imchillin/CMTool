using ConceptMatrix.Models;
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
        public ToggleButton[] exhair_buttons, exmet_buttons, extop_buttons;
        public ToggleButton ToggleSave;
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
            SaveFileDialog dig = new SaveFileDialog();
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
                BoneSaver.Race = Memory.MemLib.readByte(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Race)).ToString("X2");
                BoneSaver.Clan = Memory.MemLib.readByte(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Clan)).ToString("X2");
                BoneSaver.Body = Memory.MemLib.readByte(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.BodyType)).ToString("X2");
            }
        }

        private void LoadCMP_Click(object sender, RoutedEventArgs e)
        {
            DisableTertiary();
            PoseMatrixViewModel.PoseVM.Bone_Flag_Manager();
            OpenFileDialog dig = new OpenFileDialog();
            //dig.InitialDirectory = SaveSettings.Default.MatrixPoseSaveLoadDirectory;
            dig.Filter = "Concept Matrix Pose File(*.cmp)|*.cmp";
            dig.DefaultExt = ".cmp";
            if (dig.ShowDialog() == true)

            {

            }
            else return;
        }

        private void AdvLoadCMP_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dig = new OpenFileDialog();
            // dig.InitialDirectory = SaveSettings.Default.MatrixPoseSaveLoadDirectory;
            dig.Filter = "Concept Matrix Pose File(*.cmp)|*.cmp";
            dig.DefaultExt = ".cmp";
            if (dig.ShowDialog() == true)
            {
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
            if (EditModeButton.IsChecked == true) LoadstateHead01.IsEnabled = true;
            else return;
            HeadSaved01 = true;
            Race_Sav01 = CharacterDetails.Race.value.ToString("X2");
        }

        private void SavestateHead02_Click(object sender, RoutedEventArgs e)
        {
            if (EditModeButton.IsChecked == true) LoadstateHead02.IsEnabled = true;
            else return;
            HeadSaved02 = true;
            Race_Sav02 = CharacterDetails.Race.value.ToString("X2");
        }

        private void LoadstateHead01_Click(object sender, RoutedEventArgs e)
        {
            UncheckAll();
        }

        private void LoadstateHead02_Click(object sender, RoutedEventArgs e)
        {
            UncheckAll();
        }
        #endregion

        #region Savestate\Loadstate Hair
        private void SavestateHair01_Click(object sender, RoutedEventArgs e)
        {
        }

        private void SavestateHair02_Click(object sender, RoutedEventArgs e)
        {
        }

        private void LoadstateHair01_Click(object sender, RoutedEventArgs e)
        {
        }

        private void LoadstateHair02_Click(object sender, RoutedEventArgs e)
        {
           
        }
        #endregion

        #region Savestate\Loadstate Earrings
        private void SavestateEarrings01_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void SavestateEarrings02_Click(object sender, RoutedEventArgs e)
        {
        }

        private void LoadstateEarrings01_Click(object sender, RoutedEventArgs e)
        {
        
        }

        private void LoadstateEarrings02_Click(object sender, RoutedEventArgs e)
        {
         
        }
        #endregion

        #region Savestate\Loadstate Body
        private void SavestateBody01_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void SavestateBody02_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void LoadstateBody01_Click(object sender, RoutedEventArgs e)
        {
        }

        private void LoadstateBody02_Click(object sender, RoutedEventArgs e)
        {
         
        }
        #endregion

        #region Savestate\Loadstate Left Arm
        private void SavestateLeftArm01_Click(object sender, RoutedEventArgs e)
        {
          
        }

        private void SavestateLeftArm02_Click(object sender, RoutedEventArgs e)
        {
         
        }

        private void LoadstateLeftArm01_Click(object sender, RoutedEventArgs e)
        {
          
        }

        private void LoadstateLeftArm02_Click(object sender, RoutedEventArgs e)
        {
        
        }
        #endregion

        #region Savestate\Loadstate Right Arm
        private void SavestateRightArm01_Click(object sender, RoutedEventArgs e)
        {
          
        }

        private void SavestateRightArm02_Click(object sender, RoutedEventArgs e)
        {
         
        }

        private void LoadstateRightArm01_Click(object sender, RoutedEventArgs e)
        {
         
        }

        private void LoadstateRightArm02_Click(object sender, RoutedEventArgs e)
        {
          
        }
        #endregion

        #region Savestate\Loadstate Clothes
        private void SavestateClothes01_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void SavestateClothes02_Click(object sender, RoutedEventArgs e)
        {

        }

        private void LoadstateClothes01_Click(object sender, RoutedEventArgs e)
        {

        }

        private void LoadstateClothes02_Click(object sender, RoutedEventArgs e)
        {

        }
        #endregion

        #region Savestate\Loadstate Weapons
        private void SavestateWeapons01_Click(object sender, RoutedEventArgs e)
        {
        }

        private void SavestateWeapons02_Click(object sender, RoutedEventArgs e)
        {

        }

        private void LoadstateWeapons01_Click(object sender, RoutedEventArgs e)
        {

        }

        private void LoadstateWeapons02_Click(object sender, RoutedEventArgs e)
        {

        }
        #endregion

        #region Savestate\Loadstate Left Hand
        private void SavestateLeftHand01_Click(object sender, RoutedEventArgs e)
        {
   
        }

        private void SavestateLeftHand02_Click(object sender, RoutedEventArgs e)
        {

        }

        private void LoadstateLeftHand01_Click(object sender, RoutedEventArgs e)
        {
            UncheckAll();

        }

        private void LoadstateLeftHand02_Click(object sender, RoutedEventArgs e)
        {

        }
        #endregion

        #region Savestate\Loadstate Right Hand
        private void SavestateRightHand01_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SavestateRightHand02_Click(object sender, RoutedEventArgs e)
        {
        }

        private void LoadstateRightHand01_Click(object sender, RoutedEventArgs e)
        {
            UncheckAll();
        }

        private void LoadstateRightHand02_Click(object sender, RoutedEventArgs e)
        {
            UncheckAll();
        }
        #endregion

        #region Savestate\Loadstate Waist
        private void SavestateWaist01_Click(object sender, RoutedEventArgs e)
        {
        }

        private void SavestateWaist02_Click(object sender, RoutedEventArgs e)
        {
        }

        private void LoadstateWaist01_Click(object sender, RoutedEventArgs e)
        {
            UncheckAll();
        }

        private void LoadstateWaist02_Click(object sender, RoutedEventArgs e)
        {
            UncheckAll();
        }
        #endregion

        #region Savestate\Loadstate Left Leg
        private void SavestateLeftLeg01_Click(object sender, RoutedEventArgs e)
        {
        }

        private void SavestateLeftLeg02_Click(object sender, RoutedEventArgs e)
        {
        }

        private void LoadstateLeftLeg01_Click(object sender, RoutedEventArgs e)
        {
            UncheckAll();

        }

        private void LoadstateLeftLeg02_Click(object sender, RoutedEventArgs e)
        {
            UncheckAll();
        }
        #endregion

        #region Savestate\Loadstate Right Leg
        private void SavestateRightLeg01_Click(object sender, RoutedEventArgs e)
        {
        }

        private void SavestateRightLeg02_Click(object sender, RoutedEventArgs e)
        {
        }

        private void LoadstateRightLeg01_Click(object sender, RoutedEventArgs e)
        {
            UncheckAll();
        }

        private void LoadstateRightLeg02_Click(object sender, RoutedEventArgs e)
        {
            UncheckAll();
        }
        #endregion

        #region Savestate\Loadstate Helm
        private void SavestateHelm01_Click(object sender, RoutedEventArgs e)
        {
        }

        private void SavestateHelm02_Click(object sender, RoutedEventArgs e)
        {
        }

        private void LoadstateHelm01_Click(object sender, RoutedEventArgs e)
        {
            UncheckAll();
        }

        private void LoadstateHelm02_Click(object sender, RoutedEventArgs e)
        {

        }
        #endregion

        #region Savestate\Loadstate Top
        private void SavestateTop01_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SavestateTop02_Click(object sender, RoutedEventArgs e)
        {

        }

        private void LoadstateTop01_Click(object sender, RoutedEventArgs e)
        {
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

        private void PosZ_SourceUpdated(object sender, DataTransferEventArgs e)
        {

        }

        private void PosY_SourceUpdated(object sender, DataTransferEventArgs e)
        {

        }

        private void PosX_SourceUpdated(object sender, DataTransferEventArgs e)
        {

        }

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