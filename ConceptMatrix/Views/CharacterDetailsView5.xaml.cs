using ConceptMatrix.Models;
using ConceptMatrix.Utility;
using ConceptMatrix.ViewModel;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Media.Media3D;

namespace ConceptMatrix.Views
{
    /// <summary>
    /// Interaction logic for CharacterDetailsView5.xaml
    /// </summary>
    public partial class CharacterDetailsView5 : UserControl
    {
        private readonly Mem m = MemoryManager.Instance.MemLib;
        private CharacterOffsets c = Settings.Instance.Character;

        private string GAS(params string[] args) => MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, args);

        public bool EditMode;
        public byte[] SkeletonValue;
        public byte[] SkeletonValue2;
        public byte[] SkeletonValue3;
        public byte[] PhysicsValue;
        public CharacterDetails CharacterDetails { get => (CharacterDetails)BaseViewModel.model; set => BaseViewModel.model = value; }
        public CharacterDetailsView5()
        {
            InitializeComponent();
            MainViewModel.ViewTime5 = this;
        }


        private Vector3D GetEulerAngles() => new Vector3D(CharacterDetails.BoneX, CharacterDetails.BoneY, CharacterDetails.BoneZ);

        #region Sliders
        private void BoneSliders_SourceUpdated(object sender, DataTransferEventArgs e)
        {
            if (CharacterDetails.DebugRotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= DebugRot;
                    BoneSlider.ValueChanged += DebugRot;
                }
            }

            if (CharacterDetails.HeadRotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= HeadRot;
                    BoneSlider.ValueChanged += HeadRot;
                }
            }

            if (CharacterDetails.NoseRotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= NoseRot;
                    BoneSlider.ValueChanged += NoseRot;
                }
            }

            if (CharacterDetails.NostrilsRotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= NostrilsRot;
                    BoneSlider.ValueChanged += NostrilsRot;
                }
            }

            if (CharacterDetails.ChinRotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= ChinRot;
                    BoneSlider.ValueChanged += ChinRot;
                }
            }

            if (CharacterDetails.LOutEyebrowRotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= LOutEyebrowRot;
                    BoneSlider.ValueChanged += LOutEyebrowRot;
                }
            }

            if (CharacterDetails.ROutEyebrowRotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= ROutEyebrowRot;
                    BoneSlider.ValueChanged += ROutEyebrowRot;
                }
            }

            if (CharacterDetails.LInEyebrowRotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= LInEyebrowRot;
                    BoneSlider.ValueChanged += LInEyebrowRot;
                }
            }

            if (CharacterDetails.RInEyebrowRotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= RInEyebrowRot;
                    BoneSlider.ValueChanged += RInEyebrowRot;
                }
            }

            if (CharacterDetails.LEyeRotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= LEyeRot;
                    BoneSlider.ValueChanged += LEyeRot;
                }
            }

            if (CharacterDetails.REyeRotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= REyeRot;
                    BoneSlider.ValueChanged += REyeRot;
                }
            }

            if (CharacterDetails.LEyelidRotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= LEyelidRot;
                    BoneSlider.ValueChanged += LEyelidRot;
                }
            }

            if (CharacterDetails.REyelidRotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= REyelidRot;
                    BoneSlider.ValueChanged += REyelidRot;
                }
            }

            if (CharacterDetails.LLowEyelidRotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= LLowEyelidRot;
                    BoneSlider.ValueChanged += LLowEyelidRot;
                }
            }

            if (CharacterDetails.RLowEyelidRotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= RLowEyelidRot;
                    BoneSlider.ValueChanged += RLowEyelidRot;
                }
            }

            if (CharacterDetails.LEarRotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= LEarRot;
                    BoneSlider.ValueChanged += LEarRot;
                }
            }

            if (CharacterDetails.REarRotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= REarRot;
                    BoneSlider.ValueChanged += REarRot;
                }
            }

            if (CharacterDetails.LCheekRotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= LCheekRot;
                    BoneSlider.ValueChanged += LCheekRot;
                }
            }

            if (CharacterDetails.RCheekRotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= RCheekRot;
                    BoneSlider.ValueChanged += RCheekRot;
                }
            }

            if (CharacterDetails.LMouthRotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= LMouthRot;
                    BoneSlider.ValueChanged += LMouthRot;
                }
            }

            if (CharacterDetails.RMouthRotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= RMouthRot;
                    BoneSlider.ValueChanged += RMouthRot;
                }
            }

            if (CharacterDetails.LUpLipRotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= LUpLipRot;
                    BoneSlider.ValueChanged += LUpLipRot;
                }
            }

            if (CharacterDetails.RUpLipRotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= RUpLipRot;
                    BoneSlider.ValueChanged += RUpLipRot;
                }
            }

            if (CharacterDetails.LLowLipRotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= LLowLipRot;
                    BoneSlider.ValueChanged += LLowLipRot;
                }
            }

            if (CharacterDetails.RLowLipRotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= RLowLipRot;
                    BoneSlider.ValueChanged += RLowLipRot;
                }
            }

            if (CharacterDetails.NeckRotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= NeckRot;
                    BoneSlider.ValueChanged += NeckRot;
                }
            }

            if (CharacterDetails.SternumRotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= SternumRot;
                    BoneSlider.ValueChanged += SternumRot;
                }
            }

            if (CharacterDetails.TorsoRotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= TorsoRot;
                    BoneSlider.ValueChanged += TorsoRot;
                }
            }

            if (CharacterDetails.WaistRotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= WaistRot;
                    BoneSlider.ValueChanged += WaistRot;
                }
            }

            if (CharacterDetails.LShoulderRotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= LShoulderRot;
                    BoneSlider.ValueChanged += LShoulderRot;
                }
            }

            if (CharacterDetails.RShoulderRotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= RShoulderRot;
                    BoneSlider.ValueChanged += RShoulderRot;
                }
            }

            if (CharacterDetails.LClavicleRotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= LClavicleRot;
                    BoneSlider.ValueChanged += LClavicleRot;
                }
            }

            if (CharacterDetails.RClavicleRotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= RClavicleRot;
                    BoneSlider.ValueChanged += RClavicleRot;
                }
            }

            if (CharacterDetails.LBreastRotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= LBreastRot;
                    BoneSlider.ValueChanged += LBreastRot;
                }
            }

            if (CharacterDetails.RBreastRotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= RBreastRot;
                    BoneSlider.ValueChanged += RBreastRot;
                }
            }

            if (CharacterDetails.LArmRotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= LArmRot;
                    BoneSlider.ValueChanged += LArmRot;
                }
            }

            if (CharacterDetails.RArmRotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= RArmRot;
                    BoneSlider.ValueChanged += RArmRot;
                }
            }

            if (CharacterDetails.LElbowRotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= LElbowRot;
                    BoneSlider.ValueChanged += LElbowRot;
                }
            }

            if (CharacterDetails.RElbowRotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= RElbowRot;
                    BoneSlider.ValueChanged += RElbowRot;
                }
            }

            if (CharacterDetails.LForearmRotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= LForearmRot;
                    BoneSlider.ValueChanged += LForearmRot;
                }
            }

            if (CharacterDetails.RForearmRotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= RForearmRot;
                    BoneSlider.ValueChanged += RForearmRot;
                }
            }

            if (CharacterDetails.LWristRotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= LWristRot;
                    BoneSlider.ValueChanged += LWristRot;
                }
            }

            if (CharacterDetails.RWristRotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= RWristRot;
                    BoneSlider.ValueChanged += RWristRot;
                }
            }

            if (CharacterDetails.LHandRotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= LHandRot;
                    BoneSlider.ValueChanged += LHandRot;
                }
            }

            if (CharacterDetails.RHandRotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= RHandRot;
                    BoneSlider.ValueChanged += RHandRot;
                }
            }

            if (CharacterDetails.LThumbRotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= LThumbRot;
                    BoneSlider.ValueChanged += LThumbRot;
                }
            }

            if (CharacterDetails.RThumbRotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= RThumbRot;
                    BoneSlider.ValueChanged += RThumbRot;
                }
            }

            if (CharacterDetails.LThumb2Rotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= LThumb2Rot;
                    BoneSlider.ValueChanged += LThumb2Rot;
                }
            }

            if (CharacterDetails.RThumb2Rotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= RThumb2Rot;
                    BoneSlider.ValueChanged += RThumb2Rot;
                }
            }

            if (CharacterDetails.LIndexRotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= LIndexRot;
                    BoneSlider.ValueChanged += LIndexRot;
                }
            }

            if (CharacterDetails.RIndexRotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= RIndexRot;
                    BoneSlider.ValueChanged += RIndexRot;
                }
            }

            if (CharacterDetails.LIndex2Rotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= LIndex2Rot;
                    BoneSlider.ValueChanged += LIndex2Rot;
                }
            }

            if (CharacterDetails.RIndex2Rotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= RIndex2Rot;
                    BoneSlider.ValueChanged += RIndex2Rot;
                }
            }

            if (CharacterDetails.LMiddleRotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= LMiddleRot;
                    BoneSlider.ValueChanged += LMiddleRot;
                }
            }

            if (CharacterDetails.RMiddleRotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= RMiddleRot;
                    BoneSlider.ValueChanged += RMiddleRot;
                }
            }

            if (CharacterDetails.LMiddle2Rotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= LMiddle2Rot;
                    BoneSlider.ValueChanged += LMiddle2Rot;
                }
            }

            if (CharacterDetails.RMiddle2Rotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= RMiddle2Rot;
                    BoneSlider.ValueChanged += RMiddle2Rot;
                }
            }

            if (CharacterDetails.LRingRotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= LRingRot;
                    BoneSlider.ValueChanged += LRingRot;
                }
            }

            if (CharacterDetails.RRingRotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= RRingRot;
                    BoneSlider.ValueChanged += RRingRot;
                }
            }

            if (CharacterDetails.LRing2Rotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= LRing2Rot;
                    BoneSlider.ValueChanged += LRing2Rot;
                }
            }

            if (CharacterDetails.RRing2Rotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= RRing2Rot;
                    BoneSlider.ValueChanged += RRing2Rot;
                }
            }

            if (CharacterDetails.LPinkyRotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= LPinkyRot;
                    BoneSlider.ValueChanged += LPinkyRot;
                }
            }

            if (CharacterDetails.RPinkyRotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= RPinkyRot;
                    BoneSlider.ValueChanged += RPinkyRot;
                }
            }

            if (CharacterDetails.LPinky2Rotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= LPinky2Rot;
                    BoneSlider.ValueChanged += LPinky2Rot;
                }
            }

            if (CharacterDetails.RPinky2Rotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= RPinky2Rot;
                    BoneSlider.ValueChanged += RPinky2Rot;
                }
            }

            if (CharacterDetails.PelvisRotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= PelvisRot;
                    BoneSlider.ValueChanged += PelvisRot;
                }
            }

            if (CharacterDetails.TailRotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= TailRot;
                    BoneSlider.ValueChanged += TailRot;
                }
            }

            if (CharacterDetails.Tail2Rotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= Tail2Rot;
                    BoneSlider.ValueChanged += Tail2Rot;
                }
            }

            if (CharacterDetails.Tail3Rotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= Tail3Rot;
                    BoneSlider.ValueChanged += Tail3Rot;
                }
            }

            if (CharacterDetails.Tail4Rotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= Tail4Rot;
                    BoneSlider.ValueChanged += Tail4Rot;
                }
            }

            if (CharacterDetails.LThighRotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= LThighRot;
                    BoneSlider.ValueChanged += LThighRot;
                }
            }

            if (CharacterDetails.Tail4Rotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= Tail4Rot;
                    BoneSlider.ValueChanged += Tail4Rot;
                }
            }

            if (CharacterDetails.RThighRotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= RThighRot;
                    BoneSlider.ValueChanged += RThighRot;
                }
            }

            if (CharacterDetails.LKneeRotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= LKneeRot;
                    BoneSlider.ValueChanged += LKneeRot;
                }
            }

            if (CharacterDetails.RKneeRotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= RKneeRot;
                    BoneSlider.ValueChanged += RKneeRot;
                }
            }

            if (CharacterDetails.LCalfRotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= LCalfRot;
                    BoneSlider.ValueChanged += LCalfRot;
                }
            }

            if (CharacterDetails.RCalfRotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= RCalfRot;
                    BoneSlider.ValueChanged += RCalfRot;
                }
            }

            if (CharacterDetails.LFootRotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= LFootRot;
                    BoneSlider.ValueChanged += LFootRot;
                }
            }

            if (CharacterDetails.RFootRotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= RFootRot;
                    BoneSlider.ValueChanged += RFootRot;
                }
            }

            if (CharacterDetails.LToesRotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= LToesRot;
                    BoneSlider.ValueChanged += LToesRot;
                }
            }

            if (CharacterDetails.RToesRotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= RToesRot;
                    BoneSlider.ValueChanged += RToesRot;
                }
            }

            if (CharacterDetails.LEarringRotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= LEarringRot;
                    BoneSlider.ValueChanged += LEarringRot;
                }
            }

            if (CharacterDetails.REarringRotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= REarringRot;
                    BoneSlider.ValueChanged += REarringRot;
                }
            }

            if (CharacterDetails.LEarring2Rotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= LEarring2Rot;
                    BoneSlider.ValueChanged += LEarring2Rot;
                }
            }

            if (CharacterDetails.REarring2Rotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= REarring2Rot;
                    BoneSlider.ValueChanged += REarring2Rot;
                }
            }
        }


        private void BoneSliders2_SourceUpdated(object sender, DataTransferEventArgs e)
        {
            if (CharacterDetails.DebugRotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= DebugRot;
                    BoneSlider2.ValueChanged += DebugRot;
                }
            }

            if (CharacterDetails.HeadRotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= HeadRot;
                    BoneSlider2.ValueChanged += HeadRot;
                }
            }

            if (CharacterDetails.NoseRotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= NoseRot;
                    BoneSlider2.ValueChanged += NoseRot;
                }
            }

            if (CharacterDetails.NostrilsRotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= NostrilsRot;
                    BoneSlider2.ValueChanged += NostrilsRot;
                }
            }

            if (CharacterDetails.ChinRotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= ChinRot;
                    BoneSlider2.ValueChanged += ChinRot;
                }
            }

            if (CharacterDetails.LOutEyebrowRotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= LOutEyebrowRot;
                    BoneSlider2.ValueChanged += LOutEyebrowRot;
                }
            }

            if (CharacterDetails.ROutEyebrowRotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= ROutEyebrowRot;
                    BoneSlider2.ValueChanged += ROutEyebrowRot;
                }
            }

            if (CharacterDetails.LInEyebrowRotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= LInEyebrowRot;
                    BoneSlider2.ValueChanged += LInEyebrowRot;
                }
            }

            if (CharacterDetails.RInEyebrowRotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= RInEyebrowRot;
                    BoneSlider2.ValueChanged += RInEyebrowRot;
                }
            }

            if (CharacterDetails.LEyeRotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= LEyeRot;
                    BoneSlider2.ValueChanged += LEyeRot;
                }
            }

            if (CharacterDetails.REyeRotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= REyeRot;
                    BoneSlider2.ValueChanged += REyeRot;
                }
            }

            if (CharacterDetails.LEyelidRotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= LEyelidRot;
                    BoneSlider2.ValueChanged += LEyelidRot;
                }
            }

            if (CharacterDetails.REyelidRotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= REyelidRot;
                    BoneSlider2.ValueChanged += REyelidRot;
                }
            }

            if (CharacterDetails.LLowEyelidRotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= LLowEyelidRot;
                    BoneSlider2.ValueChanged += LLowEyelidRot;
                }
            }

            if (CharacterDetails.RLowEyelidRotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= RLowEyelidRot;
                    BoneSlider2.ValueChanged += RLowEyelidRot;
                }
            }

            if (CharacterDetails.LEarRotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= LEarRot;
                    BoneSlider2.ValueChanged += LEarRot;
                }
            }

            if (CharacterDetails.REarRotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= REarRot;
                    BoneSlider2.ValueChanged += REarRot;
                }
            }

            if (CharacterDetails.LCheekRotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= LCheekRot;
                    BoneSlider2.ValueChanged += LCheekRot;
                }
            }

            if (CharacterDetails.RCheekRotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= RCheekRot;
                    BoneSlider2.ValueChanged += RCheekRot;
                }
            }

            if (CharacterDetails.LMouthRotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= LMouthRot;
                    BoneSlider2.ValueChanged += LMouthRot;
                }
            }

            if (CharacterDetails.RMouthRotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= RMouthRot;
                    BoneSlider2.ValueChanged += RMouthRot;
                }
            }

            if (CharacterDetails.LUpLipRotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= LUpLipRot;
                    BoneSlider2.ValueChanged += LUpLipRot;
                }
            }

            if (CharacterDetails.RUpLipRotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= RUpLipRot;
                    BoneSlider2.ValueChanged += RUpLipRot;
                }
            }

            if (CharacterDetails.LLowLipRotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= LLowLipRot;
                    BoneSlider2.ValueChanged += LLowLipRot;
                }
            }

            if (CharacterDetails.RLowLipRotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= RLowLipRot;
                    BoneSlider2.ValueChanged += RLowLipRot;
                }
            }

            if (CharacterDetails.NeckRotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= NeckRot;
                    BoneSlider2.ValueChanged += NeckRot;
                }
            }

            if (CharacterDetails.SternumRotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= SternumRot;
                    BoneSlider2.ValueChanged += SternumRot;
                }
            }

            if (CharacterDetails.TorsoRotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= TorsoRot;
                    BoneSlider2.ValueChanged += TorsoRot;
                }
            }

            if (CharacterDetails.WaistRotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= WaistRot;
                    BoneSlider2.ValueChanged += WaistRot;
                }
            }

            if (CharacterDetails.LShoulderRotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= LShoulderRot;
                    BoneSlider2.ValueChanged += LShoulderRot;
                }
            }

            if (CharacterDetails.RShoulderRotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= RShoulderRot;
                    BoneSlider2.ValueChanged += RShoulderRot;
                }
            }

            if (CharacterDetails.LClavicleRotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= LClavicleRot;
                    BoneSlider2.ValueChanged += LClavicleRot;
                }
            }

            if (CharacterDetails.RClavicleRotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= RClavicleRot;
                    BoneSlider2.ValueChanged += RClavicleRot;
                }
            }

            if (CharacterDetails.LBreastRotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= LBreastRot;
                    BoneSlider2.ValueChanged += LBreastRot;
                }
            }

            if (CharacterDetails.RBreastRotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= RBreastRot;
                    BoneSlider2.ValueChanged += RBreastRot;
                }
            }

            if (CharacterDetails.LArmRotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= LArmRot;
                    BoneSlider2.ValueChanged += LArmRot;
                }
            }

            if (CharacterDetails.RArmRotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= RArmRot;
                    BoneSlider2.ValueChanged += RArmRot;
                }
            }

            if (CharacterDetails.LElbowRotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= LElbowRot;
                    BoneSlider2.ValueChanged += LElbowRot;
                }
            }

            if (CharacterDetails.RElbowRotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= RElbowRot;
                    BoneSlider2.ValueChanged += RElbowRot;
                }
            }

            if (CharacterDetails.LForearmRotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= LForearmRot;
                    BoneSlider2.ValueChanged += LForearmRot;
                }
            }

            if (CharacterDetails.RForearmRotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= RForearmRot;
                    BoneSlider2.ValueChanged += RForearmRot;
                }
            }

            if (CharacterDetails.LWristRotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= LWristRot;
                    BoneSlider2.ValueChanged += LWristRot;
                }
            }

            if (CharacterDetails.RWristRotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= RWristRot;
                    BoneSlider2.ValueChanged += RWristRot;
                }
            }

            if (CharacterDetails.LHandRotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= LHandRot;
                    BoneSlider2.ValueChanged += LHandRot;
                }
            }

            if (CharacterDetails.RHandRotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= RHandRot;
                    BoneSlider2.ValueChanged += RHandRot;
                }
            }

            if (CharacterDetails.LThumbRotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= LThumbRot;
                    BoneSlider2.ValueChanged += LThumbRot;
                }
            }

            if (CharacterDetails.RThumbRotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= RThumbRot;
                    BoneSlider2.ValueChanged += RThumbRot;
                }
            }

            if (CharacterDetails.LThumb2Rotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= LThumb2Rot;
                    BoneSlider2.ValueChanged += LThumb2Rot;
                }
            }

            if (CharacterDetails.RThumb2Rotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= RThumb2Rot;
                    BoneSlider2.ValueChanged += RThumb2Rot;
                }
            }

            if (CharacterDetails.LIndexRotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= LIndexRot;
                    BoneSlider2.ValueChanged += LIndexRot;
                }
            }

            if (CharacterDetails.RIndexRotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= RIndexRot;
                    BoneSlider2.ValueChanged += RIndexRot;
                }
            }

            if (CharacterDetails.LIndex2Rotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= LIndex2Rot;
                    BoneSlider2.ValueChanged += LIndex2Rot;
                }
            }

            if (CharacterDetails.RIndex2Rotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= RIndex2Rot;
                    BoneSlider2.ValueChanged += RIndex2Rot;
                }
            }

            if (CharacterDetails.LMiddleRotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= LMiddleRot;
                    BoneSlider2.ValueChanged += LMiddleRot;
                }
            }

            if (CharacterDetails.RMiddleRotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= RMiddleRot;
                    BoneSlider2.ValueChanged += RMiddleRot;
                }
            }

            if (CharacterDetails.LMiddle2Rotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= LMiddle2Rot;
                    BoneSlider2.ValueChanged += LMiddle2Rot;
                }
            }

            if (CharacterDetails.RMiddle2Rotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= RMiddle2Rot;
                    BoneSlider2.ValueChanged += RMiddle2Rot;
                }
            }

            if (CharacterDetails.LRingRotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= LRingRot;
                    BoneSlider2.ValueChanged += LRingRot;
                }
            }

            if (CharacterDetails.RRingRotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= RRingRot;
                    BoneSlider2.ValueChanged += RRingRot;
                }
            }

            if (CharacterDetails.LRing2Rotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= LRing2Rot;
                    BoneSlider2.ValueChanged += LRing2Rot;
                }
            }

            if (CharacterDetails.RRing2Rotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= RRing2Rot;
                    BoneSlider2.ValueChanged += RRing2Rot;
                }
            }

            if (CharacterDetails.LPinkyRotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= LPinkyRot;
                    BoneSlider2.ValueChanged += LPinkyRot;
                }
            }

            if (CharacterDetails.RPinkyRotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= RPinkyRot;
                    BoneSlider2.ValueChanged += RPinkyRot;
                }
            }

            if (CharacterDetails.LPinky2Rotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= LPinky2Rot;
                    BoneSlider2.ValueChanged += LPinky2Rot;
                }
            }

            if (CharacterDetails.RPinky2Rotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= RPinky2Rot;
                    BoneSlider2.ValueChanged += RPinky2Rot;
                }
            }

            if (CharacterDetails.PelvisRotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= PelvisRot;
                    BoneSlider2.ValueChanged += PelvisRot;
                }
            }

            if (CharacterDetails.TailRotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= TailRot;
                    BoneSlider2.ValueChanged += TailRot;
                }
            }

            if (CharacterDetails.Tail2Rotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= Tail2Rot;
                    BoneSlider2.ValueChanged += Tail2Rot;
                }
            }

            if (CharacterDetails.Tail3Rotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= Tail3Rot;
                    BoneSlider2.ValueChanged += Tail3Rot;
                }
            }

            if (CharacterDetails.Tail4Rotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= Tail4Rot;
                    BoneSlider2.ValueChanged += Tail4Rot;
                }
            }

            if (CharacterDetails.LThighRotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= LThighRot;
                    BoneSlider2.ValueChanged += LThighRot;
                }
            }

            if (CharacterDetails.RThighRotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= RThighRot;
                    BoneSlider2.ValueChanged += RThighRot;
                }
            }

            if (CharacterDetails.LKneeRotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= LKneeRot;
                    BoneSlider2.ValueChanged += LKneeRot;
                }
            }

            if (CharacterDetails.RKneeRotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= RKneeRot;
                    BoneSlider2.ValueChanged += RKneeRot;
                }
            }

            if (CharacterDetails.LCalfRotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= LCalfRot;
                    BoneSlider2.ValueChanged += LCalfRot;
                }
            }

            if (CharacterDetails.RCalfRotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= RCalfRot;
                    BoneSlider2.ValueChanged += RCalfRot;
                }
            }

            if (CharacterDetails.LFootRotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= LFootRot;
                    BoneSlider2.ValueChanged += LFootRot;
                }
            }

            if (CharacterDetails.RFootRotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= RFootRot;
                    BoneSlider2.ValueChanged += RFootRot;
                }
            }

            if (CharacterDetails.LToesRotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= LToesRot;
                    BoneSlider2.ValueChanged += LToesRot;
                }
            }

            if (CharacterDetails.RToesRotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= RToesRot;
                    BoneSlider2.ValueChanged += RToesRot;
                }
            }

            if (CharacterDetails.LEarringRotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= LEarringRot;
                    BoneSlider2.ValueChanged += LEarringRot;
                }
            }

            if (CharacterDetails.REarringRotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= REarringRot;
                    BoneSlider2.ValueChanged += REarringRot;
                }
            }

            if (CharacterDetails.LEarring2Rotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= LEarring2Rot;
                    BoneSlider2.ValueChanged += LEarring2Rot;
                }
            }

            if (CharacterDetails.REarring2Rotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= REarring2Rot;
                    BoneSlider2.ValueChanged += REarring2Rot;
                }
            }
        }


        private void BoneSliders3_SourceUpdated(object sender, DataTransferEventArgs e)
        {
            if (CharacterDetails.DebugRotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= DebugRot;
                    BoneSlider3.ValueChanged += DebugRot;
                }
            }

            if (CharacterDetails.HeadRotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= HeadRot;
                    BoneSlider3.ValueChanged += HeadRot;
                }
            }

            if (CharacterDetails.NoseRotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= NoseRot;
                    BoneSlider3.ValueChanged += NoseRot;
                }
            }

            if (CharacterDetails.NostrilsRotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= NostrilsRot;
                    BoneSlider3.ValueChanged += NostrilsRot;
                }
            }

            if (CharacterDetails.ChinRotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= ChinRot;
                    BoneSlider3.ValueChanged += ChinRot;
                }
            }

            if (CharacterDetails.LOutEyebrowRotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= LOutEyebrowRot;
                    BoneSlider3.ValueChanged += LOutEyebrowRot;
                }
            }

            if (CharacterDetails.ROutEyebrowRotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= ROutEyebrowRot;
                    BoneSlider3.ValueChanged += ROutEyebrowRot;
                }
            }

            if (CharacterDetails.LInEyebrowRotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= LInEyebrowRot;
                    BoneSlider3.ValueChanged += LInEyebrowRot;
                }
            }

            if (CharacterDetails.RInEyebrowRotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= RInEyebrowRot;
                    BoneSlider3.ValueChanged += RInEyebrowRot;
                }
            }

            if (CharacterDetails.LEyeRotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= LEyeRot;
                    BoneSlider3.ValueChanged += LEyeRot;
                }
            }

            if (CharacterDetails.REyeRotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= REyeRot;
                    BoneSlider3.ValueChanged += REyeRot;
                }
            }

            if (CharacterDetails.LEyelidRotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= LEyelidRot;
                    BoneSlider3.ValueChanged += LEyelidRot;
                }
            }

            if (CharacterDetails.REyelidRotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= REyelidRot;
                    BoneSlider3.ValueChanged += REyelidRot;
                }
            }

            if (CharacterDetails.LLowEyelidRotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= LLowEyelidRot;
                    BoneSlider3.ValueChanged += LLowEyelidRot;
                }
            }

            if (CharacterDetails.RLowEyelidRotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= RLowEyelidRot;
                    BoneSlider3.ValueChanged += RLowEyelidRot;
                }
            }

            if (CharacterDetails.LEarRotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= LEarRot;
                    BoneSlider3.ValueChanged += LEarRot;
                }
            }

            if (CharacterDetails.REarRotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= REarRot;
                    BoneSlider3.ValueChanged += REarRot;
                }
            }

            if (CharacterDetails.LCheekRotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= LCheekRot;
                    BoneSlider3.ValueChanged += LCheekRot;
                }
            }

            if (CharacterDetails.RCheekRotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= RCheekRot;
                    BoneSlider3.ValueChanged += RCheekRot;
                }
            }

            if (CharacterDetails.LMouthRotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= LMouthRot;
                    BoneSlider3.ValueChanged += LMouthRot;
                }
            }

            if (CharacterDetails.RMouthRotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= RMouthRot;
                    BoneSlider3.ValueChanged += RMouthRot;
                }
            }

            if (CharacterDetails.LUpLipRotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= LUpLipRot;
                    BoneSlider3.ValueChanged += LUpLipRot;
                }
            }

            if (CharacterDetails.RUpLipRotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= RUpLipRot;
                    BoneSlider3.ValueChanged += RUpLipRot;
                }
            }

            if (CharacterDetails.LLowLipRotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= LLowLipRot;
                    BoneSlider3.ValueChanged += LLowLipRot;
                }
            }

            if (CharacterDetails.RLowLipRotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= RLowLipRot;
                    BoneSlider3.ValueChanged += RLowLipRot;
                }
            }

            if (CharacterDetails.NeckRotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= NeckRot;
                    BoneSlider3.ValueChanged += NeckRot;
                }
            }

            if (CharacterDetails.SternumRotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= SternumRot;
                    BoneSlider3.ValueChanged += SternumRot;
                }
            }

            if (CharacterDetails.TorsoRotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= TorsoRot;
                    BoneSlider3.ValueChanged += TorsoRot;
                }
            }

            if (CharacterDetails.WaistRotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= WaistRot;
                    BoneSlider3.ValueChanged += WaistRot;
                }
            }

            if (CharacterDetails.LShoulderRotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= LShoulderRot;
                    BoneSlider3.ValueChanged += LShoulderRot;
                }
            }

            if (CharacterDetails.RShoulderRotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= RShoulderRot;
                    BoneSlider3.ValueChanged += RShoulderRot;
                }
            }

            if (CharacterDetails.LClavicleRotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= LClavicleRot;
                    BoneSlider3.ValueChanged += LClavicleRot;
                }
            }

            if (CharacterDetails.RClavicleRotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= RClavicleRot;
                    BoneSlider3.ValueChanged += RClavicleRot;
                }
            }

            if (CharacterDetails.LBreastRotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= LBreastRot;
                    BoneSlider3.ValueChanged += LBreastRot;
                }
            }

            if (CharacterDetails.RBreastRotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= RBreastRot;
                    BoneSlider3.ValueChanged += RBreastRot;
                }
            }

            if (CharacterDetails.LArmRotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= LArmRot;
                    BoneSlider3.ValueChanged += LArmRot;
                }
            }

            if (CharacterDetails.RArmRotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= RArmRot;
                    BoneSlider3.ValueChanged += RArmRot;
                }
            }

            if (CharacterDetails.LElbowRotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= LElbowRot;
                    BoneSlider3.ValueChanged += LElbowRot;
                }
            }

            if (CharacterDetails.RElbowRotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= RElbowRot;
                    BoneSlider3.ValueChanged += RElbowRot;
                }
            }

            if (CharacterDetails.LForearmRotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= LForearmRot;
                    BoneSlider3.ValueChanged += LForearmRot;
                }
            }

            if (CharacterDetails.RForearmRotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= RForearmRot;
                    BoneSlider3.ValueChanged += RForearmRot;
                }
            }

            if (CharacterDetails.LWristRotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= LWristRot;
                    BoneSlider3.ValueChanged += LWristRot;
                }
            }

            if (CharacterDetails.RWristRotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= RWristRot;
                    BoneSlider3.ValueChanged += RWristRot;
                }
            }

            if (CharacterDetails.LHandRotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= LHandRot;
                    BoneSlider3.ValueChanged += LHandRot;
                }
            }

            if (CharacterDetails.RHandRotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= RHandRot;
                    BoneSlider3.ValueChanged += RHandRot;
                }
            }

            if (CharacterDetails.LThumbRotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= LThumbRot;
                    BoneSlider3.ValueChanged += LThumbRot;
                }
            }

            if (CharacterDetails.RThumbRotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= RThumbRot;
                    BoneSlider3.ValueChanged += RThumbRot;
                }
            }

            if (CharacterDetails.LThumb2Rotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= LThumb2Rot;
                    BoneSlider3.ValueChanged += LThumb2Rot;
                }
            }

            if (CharacterDetails.RThumb2Rotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= RThumb2Rot;
                    BoneSlider3.ValueChanged += RThumb2Rot;
                }
            }

            if (CharacterDetails.LIndexRotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= LIndexRot;
                    BoneSlider3.ValueChanged += LIndexRot;
                }
            }

            if (CharacterDetails.RIndexRotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= RIndexRot;
                    BoneSlider3.ValueChanged += RIndexRot;
                }
            }

            if (CharacterDetails.LIndex2Rotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= LIndex2Rot;
                    BoneSlider3.ValueChanged += LIndex2Rot;
                }
            }

            if (CharacterDetails.RIndex2Rotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= RIndex2Rot;
                    BoneSlider3.ValueChanged += RIndex2Rot;
                }
            }

            if (CharacterDetails.LMiddleRotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= LMiddleRot;
                    BoneSlider3.ValueChanged += LMiddleRot;
                }
            }

            if (CharacterDetails.RMiddleRotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= RMiddleRot;
                    BoneSlider3.ValueChanged += RMiddleRot;
                }
            }

            if (CharacterDetails.LMiddle2Rotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= LMiddle2Rot;
                    BoneSlider3.ValueChanged += LMiddle2Rot;
                }
            }

            if (CharacterDetails.RMiddle2Rotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= RMiddle2Rot;
                    BoneSlider3.ValueChanged += RMiddle2Rot;
                }
            }

            if (CharacterDetails.LRingRotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= LRingRot;
                    BoneSlider3.ValueChanged += LRingRot;
                }
            }

            if (CharacterDetails.RRingRotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= RRingRot;
                    BoneSlider3.ValueChanged += RRingRot;
                }
            }

            if (CharacterDetails.LRing2Rotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= LRing2Rot;
                    BoneSlider3.ValueChanged += LRing2Rot;
                }
            }

            if (CharacterDetails.RRing2Rotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= RRing2Rot;
                    BoneSlider3.ValueChanged += RRing2Rot;
                }
            }

            if (CharacterDetails.LPinkyRotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= LPinkyRot;
                    BoneSlider3.ValueChanged += LPinkyRot;
                }
            }

            if (CharacterDetails.RPinkyRotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= RPinkyRot;
                    BoneSlider3.ValueChanged += RPinkyRot;
                }
            }

            if (CharacterDetails.LPinky2Rotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= LPinky2Rot;
                    BoneSlider3.ValueChanged += LPinky2Rot;
                }
            }

            if (CharacterDetails.RPinky2Rotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= RPinky2Rot;
                    BoneSlider3.ValueChanged += RPinky2Rot;
                }
            }

            if (CharacterDetails.PelvisRotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= PelvisRot;
                    BoneSlider3.ValueChanged += PelvisRot;
                }
            }

            if (CharacterDetails.TailRotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= TailRot;
                    BoneSlider3.ValueChanged += TailRot;
                }
            }

            if (CharacterDetails.Tail2Rotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= Tail2Rot;
                    BoneSlider3.ValueChanged += Tail2Rot;
                }
            }

            if (CharacterDetails.Tail3Rotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= Tail3Rot;
                    BoneSlider3.ValueChanged += Tail3Rot;
                }
            }

            if (CharacterDetails.Tail4Rotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= Tail4Rot;
                    BoneSlider3.ValueChanged += Tail4Rot;
                }
            }

            if (CharacterDetails.LThighRotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= LThighRot;
                    BoneSlider3.ValueChanged += LThighRot;
                }
            }

            if (CharacterDetails.RThighRotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= RThighRot;
                    BoneSlider3.ValueChanged += RThighRot;
                }
            }

            if (CharacterDetails.LKneeRotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= LKneeRot;
                    BoneSlider3.ValueChanged += LKneeRot;
                }
            }

            if (CharacterDetails.RKneeRotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= RKneeRot;
                    BoneSlider3.ValueChanged += RKneeRot;
                }
            }

            if (CharacterDetails.LCalfRotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= LCalfRot;
                    BoneSlider3.ValueChanged += LCalfRot;
                }
            }

            if (CharacterDetails.RCalfRotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= RCalfRot;
                    BoneSlider3.ValueChanged += RCalfRot;
                }
            }

            if (CharacterDetails.LFootRotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= LFootRot;
                    BoneSlider3.ValueChanged += LFootRot;
                }
            }

            if (CharacterDetails.RFootRotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= RFootRot;
                    BoneSlider3.ValueChanged += RFootRot;
                }
            }

            if (CharacterDetails.LToesRotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= LToesRot;
                    BoneSlider3.ValueChanged += LToesRot;
                }
            }

            if (CharacterDetails.RToesRotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= RToesRot;
                    BoneSlider3.ValueChanged += RToesRot;
                }
            }

            if (CharacterDetails.LEarringRotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= LEarringRot;
                    BoneSlider3.ValueChanged += LEarringRot;
                }
            }

            if (CharacterDetails.REarringRotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= REarringRot;
                    BoneSlider3.ValueChanged += REarringRot;
                }
            }

            if (CharacterDetails.LEarring2Rotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= LEarring2Rot;
                    BoneSlider3.ValueChanged += LEarring2Rot;
                }
            }

            if (CharacterDetails.REarring2Rotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= REarring2Rot;
                    BoneSlider3.ValueChanged += REarring2Rot;
                }
            }
        }

        #endregion

        #region UpDowns
        private void BoneUpDown_SourceUpdated(object sender, DataTransferEventArgs e)
        {
            if (CharacterDetails.DebugRotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= DebugRot2;
                    BoneUpDown.ValueChanged += DebugRot2;
                }
            }

            if (CharacterDetails.HeadRotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= HeadRot2;
                    BoneUpDown.ValueChanged += HeadRot2;
                }
            }

            if (CharacterDetails.NoseRotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= NoseRot2;
                    BoneUpDown.ValueChanged += NoseRot2;
                }
            }

            if (CharacterDetails.NostrilsRotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= NostrilsRot2;
                    BoneUpDown.ValueChanged += NostrilsRot2;
                }
            }

            if (CharacterDetails.ChinRotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= ChinRot2;
                    BoneUpDown.ValueChanged += ChinRot2;
                }
            }

            if (CharacterDetails.LOutEyebrowRotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= LOutEyebrowRot2;
                    BoneUpDown.ValueChanged += LOutEyebrowRot2;
                }
            }

            if (CharacterDetails.ROutEyebrowRotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= ROutEyebrowRot2;
                    BoneUpDown.ValueChanged += ROutEyebrowRot2;
                }
            }

            if (CharacterDetails.LInEyebrowRotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= LInEyebrowRot2;
                    BoneUpDown.ValueChanged += LInEyebrowRot2;
                }
            }

            if (CharacterDetails.RInEyebrowRotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= RInEyebrowRot2;
                    BoneUpDown.ValueChanged += RInEyebrowRot2;
                }
            }

            if (CharacterDetails.LEyeRotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= LEyeRot2;
                    BoneUpDown.ValueChanged += LEyeRot2;
                }
            }

            if (CharacterDetails.REyeRotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= REyeRot2;
                    BoneUpDown.ValueChanged += REyeRot2;
                }
            }

            if (CharacterDetails.LEyelidRotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= LEyelidRot2;
                    BoneUpDown.ValueChanged += LEyelidRot2;
                }
            }

            if (CharacterDetails.REyelidRotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= REyelidRot2;
                    BoneUpDown.ValueChanged += REyelidRot2;
                }
            }

            if (CharacterDetails.LLowEyelidRotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= LLowEyelidRot2;
                    BoneUpDown.ValueChanged += LLowEyelidRot2;
                }
            }

            if (CharacterDetails.RLowEyelidRotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= RLowEyelidRot2;
                    BoneUpDown.ValueChanged += RLowEyelidRot2;
                }
            }

            if (CharacterDetails.LEarRotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= LEarRot2;
                    BoneUpDown.ValueChanged += LEarRot2;
                }
            }

            if (CharacterDetails.REarRotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= REarRot2;
                    BoneUpDown.ValueChanged += REarRot2;
                }
            }

            if (CharacterDetails.LCheekRotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= LCheekRot2;
                    BoneUpDown.ValueChanged += LCheekRot2;
                }
            }

            if (CharacterDetails.RCheekRotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= RCheekRot2;
                    BoneUpDown.ValueChanged += RCheekRot2;
                }
            }

            if (CharacterDetails.LMouthRotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= LMouthRot2;
                    BoneUpDown.ValueChanged += LMouthRot2;
                }
            }

            if (CharacterDetails.RMouthRotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= RMouthRot2;
                    BoneUpDown.ValueChanged += RMouthRot2;
                }
            }

            if (CharacterDetails.LUpLipRotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= LUpLipRot2;
                    BoneUpDown.ValueChanged += LUpLipRot2;
                }
            }

            if (CharacterDetails.RUpLipRotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= RUpLipRot2;
                    BoneUpDown.ValueChanged += RUpLipRot2;
                }
            }

            if (CharacterDetails.LLowLipRotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= LLowLipRot2;
                    BoneUpDown.ValueChanged += LLowLipRot2;
                }
            }

            if (CharacterDetails.RLowLipRotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= RLowLipRot2;
                    BoneUpDown.ValueChanged += RLowLipRot2;
                }
            }

            if (CharacterDetails.NeckRotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= NeckRot2;
                    BoneUpDown.ValueChanged += NeckRot2;
                }
            }

            if (CharacterDetails.SternumRotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= SternumRot2;
                    BoneUpDown.ValueChanged += SternumRot2;
                }
            }

            if (CharacterDetails.TorsoRotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= TorsoRot2;
                    BoneUpDown.ValueChanged += TorsoRot2;
                }
            }

            if (CharacterDetails.WaistRotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= WaistRot2;
                    BoneUpDown.ValueChanged += WaistRot2;
                }
            }

            if (CharacterDetails.LShoulderRotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= LShoulderRot2;
                    BoneUpDown.ValueChanged += LShoulderRot2;
                }
            }

            if (CharacterDetails.RShoulderRotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= RShoulderRot2;
                    BoneUpDown.ValueChanged += RShoulderRot2;
                }
            }

            if (CharacterDetails.LClavicleRotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= LClavicleRot2;
                    BoneUpDown.ValueChanged += LClavicleRot2;
                }
            }

            if (CharacterDetails.RClavicleRotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= RClavicleRot2;
                    BoneUpDown.ValueChanged += RClavicleRot2;
                }
            }

            if (CharacterDetails.LBreastRotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= LBreastRot2;
                    BoneUpDown.ValueChanged += LBreastRot2;
                }
            }

            if (CharacterDetails.RBreastRotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= RBreastRot2;
                    BoneUpDown.ValueChanged += RBreastRot2;
                }
            }

            if (CharacterDetails.LArmRotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= LArmRot2;
                    BoneUpDown.ValueChanged += LArmRot2;
                }
            }

            if (CharacterDetails.RArmRotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= RArmRot2;
                    BoneUpDown.ValueChanged += RArmRot2;
                }
            }

            if (CharacterDetails.LElbowRotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= LElbowRot2;
                    BoneUpDown.ValueChanged += LElbowRot2;
                }
            }

            if (CharacterDetails.RElbowRotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= RElbowRot2;
                    BoneUpDown.ValueChanged += RElbowRot2;
                }
            }

            if (CharacterDetails.LForearmRotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= LForearmRot2;
                    BoneUpDown.ValueChanged += LForearmRot2;
                }
            }

            if (CharacterDetails.RForearmRotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= RForearmRot2;
                    BoneUpDown.ValueChanged += RForearmRot2;
                }
            }

            if (CharacterDetails.LWristRotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= LWristRot2;
                    BoneUpDown.ValueChanged += LWristRot2;
                }
            }

            if (CharacterDetails.RWristRotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= RWristRot2;
                    BoneUpDown.ValueChanged += RWristRot2;
                }
            }

            if (CharacterDetails.LHandRotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= LHandRot2;
                    BoneUpDown.ValueChanged += LHandRot2;
                }
            }

            if (CharacterDetails.RHandRotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= RHandRot2;
                    BoneUpDown.ValueChanged += RHandRot2;
                }
            }

            if (CharacterDetails.LThumbRotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= LThumbRot2;
                    BoneUpDown.ValueChanged += LThumbRot2;
                }
            }

            if (CharacterDetails.RThumbRotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= RThumbRot2;
                    BoneUpDown.ValueChanged += RThumbRot2;
                }
            }

            if (CharacterDetails.LThumb2Rotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= LThumb2Rot2;
                    BoneUpDown.ValueChanged += LThumb2Rot2;
                }
            }

            if (CharacterDetails.RThumb2Rotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= RThumb2Rot2;
                    BoneUpDown.ValueChanged += RThumb2Rot2;
                }
            }

            if (CharacterDetails.LIndexRotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= LIndexRot2;
                    BoneUpDown.ValueChanged += LIndexRot2;
                }
            }

            if (CharacterDetails.RIndexRotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= RIndexRot2;
                    BoneUpDown.ValueChanged += RIndexRot2;
                }
            }

            if (CharacterDetails.LIndex2Rotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= LIndex2Rot2;
                    BoneUpDown.ValueChanged += LIndex2Rot2;
                }
            }

            if (CharacterDetails.RIndex2Rotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= RIndex2Rot2;
                    BoneUpDown.ValueChanged += RIndex2Rot2;
                }
            }

            if (CharacterDetails.LMiddleRotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= LMiddleRot2;
                    BoneUpDown.ValueChanged += LMiddleRot2;
                }
            }

            if (CharacterDetails.RMiddleRotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= RMiddleRot2;
                    BoneUpDown.ValueChanged += RMiddleRot2;
                }
            }

            if (CharacterDetails.LMiddle2Rotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= LMiddle2Rot2;
                    BoneUpDown.ValueChanged += LMiddle2Rot2;
                }
            }

            if (CharacterDetails.RMiddle2Rotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= RMiddle2Rot2;
                    BoneUpDown.ValueChanged += RMiddle2Rot2;
                }
            }

            if (CharacterDetails.LRingRotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= LRingRot2;
                    BoneUpDown.ValueChanged += LRingRot2;
                }
            }

            if (CharacterDetails.RRingRotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= RRingRot2;
                    BoneUpDown.ValueChanged += RRingRot2;
                }
            }

            if (CharacterDetails.LRing2Rotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= LRing2Rot2;
                    BoneUpDown.ValueChanged += LRing2Rot2;
                }
            }

            if (CharacterDetails.RRing2Rotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= RRing2Rot2;
                    BoneUpDown.ValueChanged += RRing2Rot2;
                }
            }

            if (CharacterDetails.LPinkyRotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= LPinkyRot2;
                    BoneUpDown.ValueChanged += LPinkyRot2;
                }
            }

            if (CharacterDetails.RPinkyRotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= RPinkyRot2;
                    BoneUpDown.ValueChanged += RPinkyRot2;
                }
            }

            if (CharacterDetails.LPinky2Rotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= LPinky2Rot2;
                    BoneUpDown.ValueChanged += LPinky2Rot2;
                }
            }

            if (CharacterDetails.RPinky2Rotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= RPinky2Rot2;
                    BoneUpDown.ValueChanged += RPinky2Rot2;
                }
            }

            if (CharacterDetails.PelvisRotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= PelvisRot2;
                    BoneUpDown.ValueChanged += PelvisRot2;
                }
            }

            if (CharacterDetails.TailRotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= TailRot2;
                    BoneUpDown.ValueChanged += TailRot2;
                }
            }

            if (CharacterDetails.Tail2Rotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= Tail2Rot2;
                    BoneUpDown.ValueChanged += Tail2Rot2;
                }
            }

            if (CharacterDetails.Tail3Rotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= Tail3Rot2;
                    BoneUpDown.ValueChanged += Tail3Rot2;
                }
            }

            if (CharacterDetails.Tail4Rotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= Tail4Rot2;
                    BoneUpDown.ValueChanged += Tail4Rot2;
                }
            }

            if (CharacterDetails.LThighRotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= LThighRot2;
                    BoneUpDown.ValueChanged += LThighRot2;
                }
            }

            if (CharacterDetails.RThighRotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= RThighRot2;
                    BoneUpDown.ValueChanged += RThighRot2;
                }
            }

            if (CharacterDetails.LKneeRotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= LKneeRot2;
                    BoneUpDown.ValueChanged += LKneeRot2;
                }
            }

            if (CharacterDetails.RKneeRotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= RKneeRot2;
                    BoneUpDown.ValueChanged += RKneeRot2;
                }
            }

            if (CharacterDetails.LCalfRotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= LCalfRot2;
                    BoneUpDown.ValueChanged += LCalfRot2;
                }
            }

            if (CharacterDetails.RCalfRotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= RCalfRot2;
                    BoneUpDown.ValueChanged += RCalfRot2;
                }
            }

            if (CharacterDetails.LFootRotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= LFootRot2;
                    BoneUpDown.ValueChanged += LFootRot2;
                }
            }

            if (CharacterDetails.RFootRotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= RFootRot2;
                    BoneUpDown.ValueChanged += RFootRot2;
                }
            }

            if (CharacterDetails.LToesRotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= LToesRot2;
                    BoneUpDown.ValueChanged += LToesRot2;
                }
            }

            if (CharacterDetails.RToesRotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= RToesRot2;
                    BoneUpDown.ValueChanged += RToesRot2;
                }
            }

            if (CharacterDetails.LEarringRotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= LEarringRot2;
                    BoneUpDown.ValueChanged += LEarringRot2;
                }
            }

            if (CharacterDetails.REarringRotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= REarringRot2;
                    BoneUpDown.ValueChanged += REarringRot2;
                }
            }

            if (CharacterDetails.LEarring2Rotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= LEarring2Rot2;
                    BoneUpDown.ValueChanged += LEarring2Rot2;
                }
            }

            if (CharacterDetails.REarring2Rotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= REarring2Rot2;
                    BoneUpDown.ValueChanged += REarring2Rot2;
                }
            }
        }


        private void BoneUpDown2_SourceUpdated(object sender, DataTransferEventArgs e)
        {
            if (CharacterDetails.DebugRotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= DebugRot2;
                    BoneUpDown2.ValueChanged += DebugRot2;
                }
            }

            if (CharacterDetails.HeadRotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= HeadRot2;
                    BoneUpDown2.ValueChanged += HeadRot2;
                }
            }

            if (CharacterDetails.NoseRotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= NoseRot2;
                    BoneUpDown2.ValueChanged += NoseRot2;
                }
            }

            if (CharacterDetails.NostrilsRotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= NostrilsRot2;
                    BoneUpDown2.ValueChanged += NostrilsRot2;
                }
            }

            if (CharacterDetails.ChinRotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= ChinRot2;
                    BoneUpDown2.ValueChanged += ChinRot2;
                }
            }

            if (CharacterDetails.LOutEyebrowRotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= LOutEyebrowRot2;
                    BoneUpDown2.ValueChanged += LOutEyebrowRot2;
                }
            }

            if (CharacterDetails.ROutEyebrowRotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= ROutEyebrowRot2;
                    BoneUpDown2.ValueChanged += ROutEyebrowRot2;
                }
            }

            if (CharacterDetails.LInEyebrowRotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= LInEyebrowRot2;
                    BoneUpDown2.ValueChanged += LInEyebrowRot2;
                }
            }

            if (CharacterDetails.RInEyebrowRotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= RInEyebrowRot2;
                    BoneUpDown2.ValueChanged += RInEyebrowRot2;
                }
            }

            if (CharacterDetails.LEyeRotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= LEyeRot2;
                    BoneUpDown2.ValueChanged += LEyeRot2;
                }
            }

            if (CharacterDetails.REyeRotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= REyeRot2;
                    BoneUpDown2.ValueChanged += REyeRot2;
                }
            }

            if (CharacterDetails.LEyelidRotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= LEyelidRot2;
                    BoneUpDown2.ValueChanged += LEyelidRot2;
                }
            }

            if (CharacterDetails.REyelidRotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= REyelidRot2;
                    BoneUpDown2.ValueChanged += REyelidRot2;
                }
            }

            if (CharacterDetails.LLowEyelidRotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= LLowEyelidRot2;
                    BoneUpDown2.ValueChanged += LLowEyelidRot2;
                }
            }

            if (CharacterDetails.RLowEyelidRotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= RLowEyelidRot2;
                    BoneUpDown2.ValueChanged += RLowEyelidRot2;
                }
            }

            if (CharacterDetails.LEarRotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= LEarRot2;
                    BoneUpDown2.ValueChanged += LEarRot2;
                }
            }

            if (CharacterDetails.REarRotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= REarRot2;
                    BoneUpDown2.ValueChanged += REarRot2;
                }
            }

            if (CharacterDetails.LCheekRotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= LCheekRot2;
                    BoneUpDown2.ValueChanged += LCheekRot2;
                }
            }

            if (CharacterDetails.RCheekRotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= RCheekRot2;
                    BoneUpDown2.ValueChanged += RCheekRot2;
                }
            }

            if (CharacterDetails.LMouthRotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= LMouthRot2;
                    BoneUpDown2.ValueChanged += LMouthRot2;
                }
            }

            if (CharacterDetails.RMouthRotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= RMouthRot2;
                    BoneUpDown2.ValueChanged += RMouthRot2;
                }
            }

            if (CharacterDetails.LUpLipRotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= LUpLipRot2;
                    BoneUpDown2.ValueChanged += LUpLipRot2;
                }
            }

            if (CharacterDetails.RUpLipRotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= RUpLipRot2;
                    BoneUpDown2.ValueChanged += RUpLipRot2;
                }
            }

            if (CharacterDetails.LLowLipRotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= LLowLipRot2;
                    BoneUpDown2.ValueChanged += LLowLipRot2;
                }
            }

            if (CharacterDetails.RLowLipRotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= RLowLipRot2;
                    BoneUpDown2.ValueChanged += RLowLipRot2;
                }
            }

            if (CharacterDetails.NeckRotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= NeckRot2;
                    BoneUpDown2.ValueChanged += NeckRot2;
                }
            }

            if (CharacterDetails.SternumRotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= SternumRot2;
                    BoneUpDown2.ValueChanged += SternumRot2;
                }
            }

            if (CharacterDetails.TorsoRotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= TorsoRot2;
                    BoneUpDown2.ValueChanged += TorsoRot2;
                }
            }

            if (CharacterDetails.WaistRotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= WaistRot2;
                    BoneUpDown2.ValueChanged += WaistRot2;
                }
            }

            if (CharacterDetails.LShoulderRotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= LShoulderRot2;
                    BoneUpDown2.ValueChanged += LShoulderRot2;
                }
            }

            if (CharacterDetails.RShoulderRotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= RShoulderRot2;
                    BoneUpDown2.ValueChanged += RShoulderRot2;
                }
            }

            if (CharacterDetails.LClavicleRotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= LClavicleRot2;
                    BoneUpDown2.ValueChanged += LClavicleRot2;
                }
            }

            if (CharacterDetails.RClavicleRotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= RClavicleRot2;
                    BoneUpDown2.ValueChanged += RClavicleRot2;
                }
            }

            if (CharacterDetails.LBreastRotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= LBreastRot2;
                    BoneUpDown2.ValueChanged += LBreastRot2;
                }
            }

            if (CharacterDetails.RBreastRotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= RBreastRot2;
                    BoneUpDown2.ValueChanged += RBreastRot2;
                }
            }

            if (CharacterDetails.LArmRotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= LArmRot2;
                    BoneUpDown2.ValueChanged += LArmRot2;
                }
            }

            if (CharacterDetails.RArmRotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= RArmRot2;
                    BoneUpDown2.ValueChanged += RArmRot2;
                }
            }

            if (CharacterDetails.LElbowRotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= LElbowRot2;
                    BoneUpDown2.ValueChanged += LElbowRot2;
                }
            }

            if (CharacterDetails.RElbowRotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= RElbowRot2;
                    BoneUpDown2.ValueChanged += RElbowRot2;
                }
            }

            if (CharacterDetails.LForearmRotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= LForearmRot2;
                    BoneUpDown2.ValueChanged += LForearmRot2;
                }
            }

            if (CharacterDetails.RForearmRotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= RForearmRot2;
                    BoneUpDown2.ValueChanged += RForearmRot2;
                }
            }

            if (CharacterDetails.LWristRotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= LWristRot2;
                    BoneUpDown2.ValueChanged += LWristRot2;
                }
            }

            if (CharacterDetails.RWristRotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= RWristRot2;
                    BoneUpDown2.ValueChanged += RWristRot2;
                }
            }

            if (CharacterDetails.LHandRotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= LHandRot2;
                    BoneUpDown2.ValueChanged += LHandRot2;
                }
            }

            if (CharacterDetails.RHandRotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= RHandRot2;
                    BoneUpDown2.ValueChanged += RHandRot2;
                }
            }

            if (CharacterDetails.LThumbRotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= LThumbRot2;
                    BoneUpDown2.ValueChanged += LThumbRot2;
                }
            }

            if (CharacterDetails.RThumbRotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= RThumbRot2;
                    BoneUpDown2.ValueChanged += RThumbRot2;
                }
            }

            if (CharacterDetails.LThumb2Rotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= LThumb2Rot2;
                    BoneUpDown2.ValueChanged += LThumb2Rot2;
                }
            }

            if (CharacterDetails.RThumb2Rotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= RThumb2Rot2;
                    BoneUpDown2.ValueChanged += RThumb2Rot2;
                }
            }

            if (CharacterDetails.LIndexRotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= LIndexRot2;
                    BoneUpDown2.ValueChanged += LIndexRot2;
                }
            }

            if (CharacterDetails.RIndexRotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= RIndexRot2;
                    BoneUpDown2.ValueChanged += RIndexRot2;
                }
            }

            if (CharacterDetails.LIndex2Rotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= LIndex2Rot2;
                    BoneUpDown2.ValueChanged += LIndex2Rot2;
                }
            }

            if (CharacterDetails.RIndex2Rotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= RIndex2Rot2;
                    BoneUpDown2.ValueChanged += RIndex2Rot2;
                }
            }

            if (CharacterDetails.LMiddleRotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= LMiddleRot2;
                    BoneUpDown2.ValueChanged += LMiddleRot2;
                }
            }

            if (CharacterDetails.RMiddleRotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= RMiddleRot2;
                    BoneUpDown2.ValueChanged += RMiddleRot2;
                }
            }

            if (CharacterDetails.LMiddle2Rotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= LMiddle2Rot2;
                    BoneUpDown2.ValueChanged += LMiddle2Rot2;
                }
            }

            if (CharacterDetails.RMiddle2Rotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= RMiddle2Rot2;
                    BoneUpDown2.ValueChanged += RMiddle2Rot2;
                }
            }

            if (CharacterDetails.LRingRotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= LRingRot2;
                    BoneUpDown2.ValueChanged += LRingRot2;
                }
            }

            if (CharacterDetails.RRingRotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= RRingRot2;
                    BoneUpDown2.ValueChanged += RRingRot2;
                }
            }

            if (CharacterDetails.LRing2Rotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= LRing2Rot2;
                    BoneUpDown2.ValueChanged += LRing2Rot2;
                }
            }

            if (CharacterDetails.RRing2Rotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= RRing2Rot2;
                    BoneUpDown2.ValueChanged += RRing2Rot2;
                }
            }

            if (CharacterDetails.LPinkyRotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= LPinkyRot2;
                    BoneUpDown2.ValueChanged += LPinkyRot2;
                }
            }

            if (CharacterDetails.RPinkyRotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= RPinkyRot2;
                    BoneUpDown2.ValueChanged += RPinkyRot2;
                }
            }

            if (CharacterDetails.LPinky2Rotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= LPinky2Rot2;
                    BoneUpDown2.ValueChanged += LPinky2Rot2;
                }
            }

            if (CharacterDetails.RPinky2Rotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= RPinky2Rot2;
                    BoneUpDown2.ValueChanged += RPinky2Rot2;
                }
            }

            if (CharacterDetails.PelvisRotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= PelvisRot2;
                    BoneUpDown2.ValueChanged += PelvisRot2;
                }
            }

            if (CharacterDetails.TailRotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= TailRot2;
                    BoneUpDown2.ValueChanged += TailRot2;
                }
            }

            if (CharacterDetails.Tail2Rotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= Tail2Rot2;
                    BoneUpDown2.ValueChanged += Tail2Rot2;
                }
            }

            if (CharacterDetails.Tail3Rotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= Tail3Rot2;
                    BoneUpDown2.ValueChanged += Tail3Rot2;
                }
            }

            if (CharacterDetails.Tail4Rotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= Tail4Rot2;
                    BoneUpDown2.ValueChanged += Tail4Rot2;
                }
            }

            if (CharacterDetails.LThighRotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= LThighRot2;
                    BoneUpDown2.ValueChanged += LThighRot2;
                }
            }

            if (CharacterDetails.RThighRotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= RThighRot2;
                    BoneUpDown2.ValueChanged += RThighRot2;
                }
            }

            if (CharacterDetails.LKneeRotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= LKneeRot2;
                    BoneUpDown2.ValueChanged += LKneeRot2;
                }
            }

            if (CharacterDetails.RKneeRotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= RKneeRot2;
                    BoneUpDown2.ValueChanged += RKneeRot2;
                }
            }

            if (CharacterDetails.LCalfRotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= LCalfRot2;
                    BoneUpDown2.ValueChanged += LCalfRot2;
                }
            }

            if (CharacterDetails.RCalfRotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= RCalfRot2;
                    BoneUpDown2.ValueChanged += RCalfRot2;
                }
            }

            if (CharacterDetails.LFootRotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= LFootRot2;
                    BoneUpDown2.ValueChanged += LFootRot2;
                }
            }

            if (CharacterDetails.RFootRotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= RFootRot2;
                    BoneUpDown2.ValueChanged += RFootRot2;
                }
            }

            if (CharacterDetails.LToesRotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= LToesRot2;
                    BoneUpDown2.ValueChanged += LToesRot2;
                }
            }

            if (CharacterDetails.RToesRotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= RToesRot2;
                    BoneUpDown2.ValueChanged += RToesRot2;
                }
            }

            if (CharacterDetails.LEarringRotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= LEarringRot2;
                    BoneUpDown2.ValueChanged += LEarringRot2;
                }
            }

            if (CharacterDetails.REarringRotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= REarringRot2;
                    BoneUpDown2.ValueChanged += REarringRot2;
                }
            }

            if (CharacterDetails.LEarring2Rotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= LEarring2Rot2;
                    BoneUpDown2.ValueChanged += LEarring2Rot2;
                }
            }

            if (CharacterDetails.REarring2Rotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= REarring2Rot2;
                    BoneUpDown2.ValueChanged += REarring2Rot2;
                }
            }
        }


        private void BoneUpDown3_SourceUpdated(object sender, DataTransferEventArgs e)
        {
            if (CharacterDetails.DebugRotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= DebugRot2;
                    BoneUpDown3.ValueChanged += DebugRot2;
                }
            }

            if (CharacterDetails.HeadRotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= HeadRot2;
                    BoneUpDown3.ValueChanged += HeadRot2;
                }
            }

            if (CharacterDetails.NoseRotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= NoseRot2;
                    BoneUpDown3.ValueChanged += NoseRot2;
                }
            }

            if (CharacterDetails.NostrilsRotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= NostrilsRot2;
                    BoneUpDown3.ValueChanged += NostrilsRot2;
                }
            }

            if (CharacterDetails.ChinRotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= ChinRot2;
                    BoneUpDown3.ValueChanged += ChinRot2;
                }
            }

            if (CharacterDetails.LOutEyebrowRotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= LOutEyebrowRot2;
                    BoneUpDown3.ValueChanged += LOutEyebrowRot2;
                }
            }

            if (CharacterDetails.ROutEyebrowRotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= ROutEyebrowRot2;
                    BoneUpDown3.ValueChanged += ROutEyebrowRot2;
                }
            }

            if (CharacterDetails.LInEyebrowRotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= LInEyebrowRot2;
                    BoneUpDown3.ValueChanged += LInEyebrowRot2;
                }
            }

            if (CharacterDetails.RInEyebrowRotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= RInEyebrowRot2;
                    BoneUpDown3.ValueChanged += RInEyebrowRot2;
                }
            }

            if (CharacterDetails.LEyeRotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= LEyeRot2;
                    BoneUpDown3.ValueChanged += LEyeRot2;
                }
            }

            if (CharacterDetails.REyeRotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= REyeRot2;
                    BoneUpDown3.ValueChanged += REyeRot2;
                }
            }

            if (CharacterDetails.LEyelidRotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= LEyelidRot2;
                    BoneUpDown3.ValueChanged += LEyelidRot2;
                }
            }

            if (CharacterDetails.REyelidRotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= REyelidRot2;
                    BoneUpDown3.ValueChanged += REyelidRot2;
                }
            }

            if (CharacterDetails.LLowEyelidRotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= LLowEyelidRot2;
                    BoneUpDown3.ValueChanged += LLowEyelidRot2;
                }
            }

            if (CharacterDetails.RLowEyelidRotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= RLowEyelidRot2;
                    BoneUpDown3.ValueChanged += RLowEyelidRot2;
                }
            }

            if (CharacterDetails.LEarRotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= LEarRot2;
                    BoneUpDown3.ValueChanged += LEarRot2;
                }
            }

            if (CharacterDetails.REarRotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= REarRot2;
                    BoneUpDown3.ValueChanged += REarRot2;
                }
            }

            if (CharacterDetails.LCheekRotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= LCheekRot2;
                    BoneUpDown3.ValueChanged += LCheekRot2;
                }
            }

            if (CharacterDetails.RCheekRotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= RCheekRot2;
                    BoneUpDown3.ValueChanged += RCheekRot2;
                }
            }

            if (CharacterDetails.LMouthRotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= LMouthRot2;
                    BoneUpDown3.ValueChanged += LMouthRot2;
                }
            }

            if (CharacterDetails.RMouthRotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= RMouthRot2;
                    BoneUpDown3.ValueChanged += RMouthRot2;
                }
            }

            if (CharacterDetails.LUpLipRotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= LUpLipRot2;
                    BoneUpDown3.ValueChanged += LUpLipRot2;
                }
            }

            if (CharacterDetails.RUpLipRotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= RUpLipRot2;
                    BoneUpDown3.ValueChanged += RUpLipRot2;
                }
            }

            if (CharacterDetails.LLowLipRotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= LLowLipRot2;
                    BoneUpDown3.ValueChanged += LLowLipRot2;
                }
            }

            if (CharacterDetails.RLowLipRotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= RLowLipRot2;
                    BoneUpDown3.ValueChanged += RLowLipRot2;
                }
            }

            if (CharacterDetails.NeckRotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= NeckRot2;
                    BoneUpDown3.ValueChanged += NeckRot2;
                }
            }

            if (CharacterDetails.SternumRotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= SternumRot2;
                    BoneUpDown3.ValueChanged += SternumRot2;
                }
            }

            if (CharacterDetails.TorsoRotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= TorsoRot2;
                    BoneUpDown3.ValueChanged += TorsoRot2;
                }
            }

            if (CharacterDetails.WaistRotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= WaistRot2;
                    BoneUpDown3.ValueChanged += WaistRot2;
                }
            }

            if (CharacterDetails.LShoulderRotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= LShoulderRot2;
                    BoneUpDown3.ValueChanged += LShoulderRot2;
                }
            }

            if (CharacterDetails.RShoulderRotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= RShoulderRot2;
                    BoneUpDown3.ValueChanged += RShoulderRot2;
                }
            }

            if (CharacterDetails.LClavicleRotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= LClavicleRot2;
                    BoneUpDown3.ValueChanged += LClavicleRot2;
                }
            }

            if (CharacterDetails.RClavicleRotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= RClavicleRot2;
                    BoneUpDown3.ValueChanged += RClavicleRot2;
                }
            }

            if (CharacterDetails.LBreastRotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= LBreastRot2;
                    BoneUpDown3.ValueChanged += LBreastRot2;
                }
            }

            if (CharacterDetails.RBreastRotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= RBreastRot2;
                    BoneUpDown3.ValueChanged += RBreastRot2;
                }
            }

            if (CharacterDetails.LArmRotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= LArmRot2;
                    BoneUpDown3.ValueChanged += LArmRot2;
                }
            }

            if (CharacterDetails.RArmRotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= RArmRot2;
                    BoneUpDown3.ValueChanged += RArmRot2;
                }
            }

            if (CharacterDetails.LElbowRotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= LElbowRot2;
                    BoneUpDown3.ValueChanged += LElbowRot2;
                }
            }

            if (CharacterDetails.RElbowRotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= RElbowRot2;
                    BoneUpDown3.ValueChanged += RElbowRot2;
                }
            }

            if (CharacterDetails.LForearmRotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= LForearmRot2;
                    BoneUpDown3.ValueChanged += LForearmRot2;
                }
            }

            if (CharacterDetails.RForearmRotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= RForearmRot2;
                    BoneUpDown3.ValueChanged += RForearmRot2;
                }
            }

            if (CharacterDetails.LWristRotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= LWristRot2;
                    BoneUpDown3.ValueChanged += LWristRot2;
                }
            }

            if (CharacterDetails.RWristRotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= RWristRot2;
                    BoneUpDown3.ValueChanged += RWristRot2;
                }
            }

            if (CharacterDetails.LHandRotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= LHandRot2;
                    BoneUpDown3.ValueChanged += LHandRot2;
                }
            }

            if (CharacterDetails.RHandRotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= RHandRot2;
                    BoneUpDown3.ValueChanged += RHandRot2;
                }
            }

            if (CharacterDetails.LThumbRotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= LThumbRot2;
                    BoneUpDown3.ValueChanged += LThumbRot2;
                }
            }

            if (CharacterDetails.RThumbRotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= RThumbRot2;
                    BoneUpDown3.ValueChanged += RThumbRot2;
                }
            }

            if (CharacterDetails.LThumb2Rotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= LThumb2Rot2;
                    BoneUpDown3.ValueChanged += LThumb2Rot2;
                }
            }

            if (CharacterDetails.RThumb2Rotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= RThumb2Rot2;
                    BoneUpDown3.ValueChanged += RThumb2Rot2;
                }
            }

            if (CharacterDetails.LIndexRotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= LIndexRot2;
                    BoneUpDown3.ValueChanged += LIndexRot2;
                }
            }

            if (CharacterDetails.RIndexRotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= RIndexRot2;
                    BoneUpDown3.ValueChanged += RIndexRot2;
                }
            }

            if (CharacterDetails.LIndex2Rotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= LIndex2Rot2;
                    BoneUpDown3.ValueChanged += LIndex2Rot2;
                }
            }

            if (CharacterDetails.RIndex2Rotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= RIndex2Rot2;
                    BoneUpDown3.ValueChanged += RIndex2Rot2;
                }
            }

            if (CharacterDetails.LMiddleRotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= LMiddleRot2;
                    BoneUpDown3.ValueChanged += LMiddleRot2;
                }
            }

            if (CharacterDetails.RMiddleRotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= RMiddleRot2;
                    BoneUpDown3.ValueChanged += RMiddleRot2;
                }
            }

            if (CharacterDetails.LMiddle2Rotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= LMiddle2Rot2;
                    BoneUpDown3.ValueChanged += LMiddle2Rot2;
                }
            }

            if (CharacterDetails.RMiddle2Rotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= RMiddle2Rot2;
                    BoneUpDown3.ValueChanged += RMiddle2Rot2;
                }
            }

            if (CharacterDetails.LRingRotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= LRingRot2;
                    BoneUpDown3.ValueChanged += LRingRot2;
                }
            }

            if (CharacterDetails.RRingRotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= RRingRot2;
                    BoneUpDown3.ValueChanged += RRingRot2;
                }
            }

            if (CharacterDetails.LRing2Rotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= LRing2Rot2;
                    BoneUpDown3.ValueChanged += LRing2Rot2;
                }
            }

            if (CharacterDetails.RRing2Rotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= RRing2Rot2;
                    BoneUpDown3.ValueChanged += RRing2Rot2;
                }
            }

            if (CharacterDetails.LPinkyRotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= LPinkyRot2;
                    BoneUpDown3.ValueChanged += LPinkyRot2;
                }
            }

            if (CharacterDetails.RPinkyRotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= RPinkyRot2;
                    BoneUpDown3.ValueChanged += RPinkyRot2;
                }
            }

            if (CharacterDetails.LPinky2Rotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= LPinky2Rot2;
                    BoneUpDown3.ValueChanged += LPinky2Rot2;
                }
            }

            if (CharacterDetails.RPinky2Rotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= RPinky2Rot2;
                    BoneUpDown3.ValueChanged += RPinky2Rot2;
                }
            }

            if (CharacterDetails.PelvisRotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= PelvisRot2;
                    BoneUpDown3.ValueChanged += PelvisRot2;
                }
            }

            if (CharacterDetails.TailRotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= TailRot2;
                    BoneUpDown3.ValueChanged += TailRot2;
                }
            }

            if (CharacterDetails.Tail2Rotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= Tail2Rot2;
                    BoneUpDown3.ValueChanged += Tail2Rot2;
                }
            }

            if (CharacterDetails.Tail3Rotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= Tail3Rot2;
                    BoneUpDown3.ValueChanged += Tail3Rot2;
                }
            }

            if (CharacterDetails.TailRotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= Tail4Rot2;
                    BoneUpDown3.ValueChanged += Tail4Rot2;
                }
            }

            if (CharacterDetails.LThighRotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= LThighRot2;
                    BoneUpDown3.ValueChanged += LThighRot2;
                }
            }

            if (CharacterDetails.RThighRotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= RThighRot2;
                    BoneUpDown3.ValueChanged += RThighRot2;
                }
            }

            if (CharacterDetails.LKneeRotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= LKneeRot2;
                    BoneUpDown3.ValueChanged += LKneeRot2;
                }
            }

            if (CharacterDetails.RKneeRotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= RKneeRot2;
                    BoneUpDown3.ValueChanged += RKneeRot2;
                }
            }

            if (CharacterDetails.LCalfRotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= LCalfRot2;
                    BoneUpDown3.ValueChanged += LCalfRot2;
                }
            }

            if (CharacterDetails.RCalfRotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= RCalfRot2;
                    BoneUpDown3.ValueChanged += RCalfRot2;
                }
            }

            if (CharacterDetails.LFootRotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= LFootRot2;
                    BoneUpDown3.ValueChanged += LFootRot2;
                }
            }

            if (CharacterDetails.RFootRotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= RFootRot2;
                    BoneUpDown3.ValueChanged += RFootRot2;
                }
            }

            if (CharacterDetails.LToesRotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= LToesRot2;
                    BoneUpDown3.ValueChanged += LToesRot2;
                }
            }

            if (CharacterDetails.RToesRotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= RToesRot2;
                    BoneUpDown3.ValueChanged += RToesRot2;
                }
            }

            if (CharacterDetails.LEarringRotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= LEarringRot2;
                    BoneUpDown3.ValueChanged += LEarringRot2;
                }
            }

            if (CharacterDetails.REarringRotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= REarringRot2;
                    BoneUpDown3.ValueChanged += REarringRot2;
                }
            }

            if (CharacterDetails.LEarring2Rotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= LEarring2Rot2;
                    BoneUpDown3.ValueChanged += LEarring2Rot2;
                }
            }

            if (CharacterDetails.REarring2Rotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= REarring2Rot2;
                    BoneUpDown3.ValueChanged += REarring2Rot2;
                }
            }
        }

        #endregion

        #region Debug
        private void DebugRot(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.DebugX.value = (float)quat.X;
            CharacterDetails.DebugY.value = (float)quat.Y;
            CharacterDetails.DebugZ.value = (float)quat.Z;
            CharacterDetails.DebugW.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneSlider.ValueChanged -= DebugRot;
            BoneSlider2.ValueChanged -= DebugRot;
            BoneSlider3.ValueChanged -= DebugRot;
        }

        private void DebugRot2(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.DebugX.value = (float)quat.X;
            CharacterDetails.DebugY.value = (float)quat.Y;
            CharacterDetails.DebugZ.value = (float)quat.Z;
            CharacterDetails.DebugW.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneUpDown.ValueChanged -= DebugRot2;
            BoneUpDown2.ValueChanged -= DebugRot2;
            BoneUpDown3.ValueChanged -= DebugRot2;
        }

        private void DebugButton_Checked(object sender, RoutedEventArgs e)
        {
            //Disable Other Selections
            HeadButton.IsChecked = false;
            NoseButton.IsChecked = false;
            NostrilsButton.IsChecked = false;
            ChinButton.IsChecked = false;
            LOutEyebrowButton.IsChecked = false;
            ROutEyebrowButton.IsChecked = false;
            LInEyebrowButton.IsChecked = false;
            RInEyebrowButton.IsChecked = false;
            LEyeButton.IsChecked = false;
            REyeButton.IsChecked = false;
            LEyelidButton.IsChecked = false;
            REyelidButton.IsChecked = false;
            LLowEyelidButton.IsChecked = false;
            RLowEyelidButton.IsChecked = false;
            LEarButton.IsChecked = false;
            REarButton.IsChecked = false;
            LCheekButton.IsChecked = false;
            RCheekButton.IsChecked = false;
            LMouthButton.IsChecked = false;
            RMouthButton.IsChecked = false;
            LUpLipButton.IsChecked = false;
            RUpLipButton.IsChecked = false;
            LLowLipButton.IsChecked = false;
            RLowLipButton.IsChecked = false;
            NeckButton.IsChecked = false;
            SternumButton.IsChecked = false;
            TorsoButton.IsChecked = false;
            WaistButton.IsChecked = false;
            LShoulderButton.IsChecked = false;
            RShoulderButton.IsChecked = false;
            LClavicleButton.IsChecked = false;
            RClavicleButton.IsChecked = false;
            LBreastButton.IsChecked = false;
            RBreastButton.IsChecked = false;
            LArmButton.IsChecked = false;
            RArmButton.IsChecked = false;
            LElbowButton.IsChecked = false;
            RElbowButton.IsChecked = false;
            LForearmButton.IsChecked = false;
            RForearmButton.IsChecked = false;
            LWristButton.IsChecked = false;
            RWristButton.IsChecked = false;
            LHandButton.IsChecked = false;
            RHandButton.IsChecked = false;
            LThumbButton.IsChecked = false;
            RThumbButton.IsChecked = false;
            LThumb2Button.IsChecked = false;
            RThumb2Button.IsChecked = false;
            LIndexButton.IsChecked = false;
            RIndexButton.IsChecked = false;
            LIndex2Button.IsChecked = false;
            RIndex2Button.IsChecked = false;
            LMiddleButton.IsChecked = false;
            RMiddleButton.IsChecked = false;
            LMiddle2Button.IsChecked = false;
            RMiddle2Button.IsChecked = false;
            LRingButton.IsChecked = false;
            RRingButton.IsChecked = false;
            LRing2Button.IsChecked = false;
            RRing2Button.IsChecked = false;
            LPinkyButton.IsChecked = false;
            RPinkyButton.IsChecked = false;
            LPinky2Button.IsChecked = false;
            RPinky2Button.IsChecked = false;
            PelvisButton.IsChecked = false;
            TailButton.IsChecked = false;
            Tail2Button.IsChecked = false;
            Tail3Button.IsChecked = false;
            Tail4Button.IsChecked = false;
            LThighButton.IsChecked = false;
            RThighButton.IsChecked = false;
            LKneeButton.IsChecked = false;
            RKneeButton.IsChecked = false;
            LCalfButton.IsChecked = false;
            RCalfButton.IsChecked = false;
            LFootButton.IsChecked = false;
            RFootButton.IsChecked = false;
            LToesButton.IsChecked = false;
            RToesButton.IsChecked = false;
            LEarringButton.IsChecked = false;
            REarringButton.IsChecked = false;
            LEarring2Button.IsChecked = false;
            REarring2Button.IsChecked = false;

            //Load Current Values for Slider
            CharacterDetails.DebugCheck = true;
        }
        private void DebugButton_Unchecked(object sender, RoutedEventArgs e)
        {
            CharacterDetails.DebugRotate = false;
        }
        #endregion

        #region Head
        private void HeadRot(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.HeadX.value = (float)quat.X;
            CharacterDetails.HeadY.value = (float)quat.Y;
            CharacterDetails.HeadZ.value = (float)quat.Z;
            CharacterDetails.HeadW.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneSlider.ValueChanged -= HeadRot;
            BoneSlider2.ValueChanged -= HeadRot;
            BoneSlider3.ValueChanged -= HeadRot;
        }

        private void HeadRot2(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.HeadX.value = (float)quat.X;
            CharacterDetails.HeadY.value = (float)quat.Y;
            CharacterDetails.HeadZ.value = (float)quat.Z;
            CharacterDetails.HeadW.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneUpDown.ValueChanged -= HeadRot2;
            BoneUpDown2.ValueChanged -= HeadRot2;
            BoneUpDown3.ValueChanged -= HeadRot2;
        }

        public void HeadButton_Checked(object sender, RoutedEventArgs e)
        {
            //Disable Other Selections
            NoseButton.IsChecked = false;
            NostrilsButton.IsChecked = false;
            ChinButton.IsChecked = false;
            LOutEyebrowButton.IsChecked = false;
            ROutEyebrowButton.IsChecked = false;
            LInEyebrowButton.IsChecked = false;
            RInEyebrowButton.IsChecked = false;
            LEyeButton.IsChecked = false;
            REyeButton.IsChecked = false;
            LEyelidButton.IsChecked = false;
            REyelidButton.IsChecked = false;
            LLowEyelidButton.IsChecked = false;
            RLowEyelidButton.IsChecked = false;
            LEarButton.IsChecked = false;
            REarButton.IsChecked = false;
            LCheekButton.IsChecked = false;
            RCheekButton.IsChecked = false;
            LMouthButton.IsChecked = false;
            RMouthButton.IsChecked = false;
            LUpLipButton.IsChecked = false;
            RUpLipButton.IsChecked = false;
            LLowLipButton.IsChecked = false;
            RLowLipButton.IsChecked = false;
            NeckButton.IsChecked = false;
            SternumButton.IsChecked = false;
            TorsoButton.IsChecked = false;
            WaistButton.IsChecked = false;
            LShoulderButton.IsChecked = false;
            RShoulderButton.IsChecked = false;
            LClavicleButton.IsChecked = false;
            RClavicleButton.IsChecked = false;
            LBreastButton.IsChecked = false;
            RBreastButton.IsChecked = false;
            LArmButton.IsChecked = false;
            RArmButton.IsChecked = false;
            LElbowButton.IsChecked = false;
            RElbowButton.IsChecked = false;
            LForearmButton.IsChecked = false;
            RForearmButton.IsChecked = false;
            LWristButton.IsChecked = false;
            RWristButton.IsChecked = false;
            LHandButton.IsChecked = false;
            RHandButton.IsChecked = false;
            LThumbButton.IsChecked = false;
            RThumbButton.IsChecked = false;
            LThumb2Button.IsChecked = false;
            RThumb2Button.IsChecked = false;
            LIndexButton.IsChecked = false;
            RIndexButton.IsChecked = false;
            LIndex2Button.IsChecked = false;
            RIndex2Button.IsChecked = false;
            LMiddleButton.IsChecked = false;
            RMiddleButton.IsChecked = false;
            LMiddle2Button.IsChecked = false;
            RMiddle2Button.IsChecked = false;
            LRingButton.IsChecked = false;
            RRingButton.IsChecked = false;
            LRing2Button.IsChecked = false;
            RRing2Button.IsChecked = false;
            LPinkyButton.IsChecked = false;
            RPinkyButton.IsChecked = false;
            LPinky2Button.IsChecked = false;
            RPinky2Button.IsChecked = false;
            PelvisButton.IsChecked = false;
            TailButton.IsChecked = false;
            Tail2Button.IsChecked = false;
            Tail3Button.IsChecked = false;
            Tail4Button.IsChecked = false;
            LThighButton.IsChecked = false;
            RThighButton.IsChecked = false;
            LKneeButton.IsChecked = false;
            RKneeButton.IsChecked = false;
            LCalfButton.IsChecked = false;
            RCalfButton.IsChecked = false;
            LFootButton.IsChecked = false;
            RFootButton.IsChecked = false;
            LToesButton.IsChecked = false;
            RToesButton.IsChecked = false;
            LEarringButton.IsChecked = false;
            REarringButton.IsChecked = false;
            LEarring2Button.IsChecked = false;
            REarring2Button.IsChecked = false;

            //Load Current Values for Slider
            CharacterDetails.HeadCheck = true;
        }
        private void HeadButton_Unchecked(object sender, RoutedEventArgs e)
        {
            CharacterDetails.HeadRotate = false;
        }
        #endregion

        #region Nose
        private void NoseRot(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.NoseX.value = (float)quat.X;
            CharacterDetails.NoseY.value = (float)quat.Y;
            CharacterDetails.NoseZ.value = (float)quat.Z;
            CharacterDetails.NoseW.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneSlider.ValueChanged -= NoseRot;
            BoneSlider2.ValueChanged -= NoseRot;
            BoneSlider3.ValueChanged -= NoseRot;
        }

        private void NoseRot2(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.NoseX.value = (float)quat.X;
            CharacterDetails.NoseY.value = (float)quat.Y;
            CharacterDetails.NoseZ.value = (float)quat.Z;
            CharacterDetails.NoseW.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneUpDown.ValueChanged -= NoseRot2;
            BoneUpDown2.ValueChanged -= NoseRot2;
            BoneUpDown3.ValueChanged -= NoseRot2;
        }

        private void NoseButton_Checked(object sender, RoutedEventArgs e)
        {
            //Disable Other Selections
            HeadButton.IsChecked = false;
            NostrilsButton.IsChecked = false;
            ChinButton.IsChecked = false;
            LOutEyebrowButton.IsChecked = false;
            ROutEyebrowButton.IsChecked = false;
            LInEyebrowButton.IsChecked = false;
            RInEyebrowButton.IsChecked = false;
            LEyeButton.IsChecked = false;
            REyeButton.IsChecked = false;
            LEyelidButton.IsChecked = false;
            REyelidButton.IsChecked = false;
            LLowEyelidButton.IsChecked = false;
            RLowEyelidButton.IsChecked = false;
            LEarButton.IsChecked = false;
            REarButton.IsChecked = false;
            LCheekButton.IsChecked = false;
            RCheekButton.IsChecked = false;
            LMouthButton.IsChecked = false;
            RMouthButton.IsChecked = false;
            LUpLipButton.IsChecked = false;
            RUpLipButton.IsChecked = false;
            LLowLipButton.IsChecked = false;
            RLowLipButton.IsChecked = false;
            NeckButton.IsChecked = false;
            SternumButton.IsChecked = false;
            TorsoButton.IsChecked = false;
            WaistButton.IsChecked = false;
            LShoulderButton.IsChecked = false;
            RShoulderButton.IsChecked = false;
            LClavicleButton.IsChecked = false;
            RClavicleButton.IsChecked = false;
            LBreastButton.IsChecked = false;
            RBreastButton.IsChecked = false;
            LArmButton.IsChecked = false;
            RArmButton.IsChecked = false;
            LElbowButton.IsChecked = false;
            RElbowButton.IsChecked = false;
            LForearmButton.IsChecked = false;
            RForearmButton.IsChecked = false;
            LWristButton.IsChecked = false;
            RWristButton.IsChecked = false;
            LHandButton.IsChecked = false;
            RHandButton.IsChecked = false;
            LThumbButton.IsChecked = false;
            RThumbButton.IsChecked = false;
            LThumb2Button.IsChecked = false;
            RThumb2Button.IsChecked = false;
            LIndexButton.IsChecked = false;
            RIndexButton.IsChecked = false;
            LIndex2Button.IsChecked = false;
            RIndex2Button.IsChecked = false;
            LMiddleButton.IsChecked = false;
            RMiddleButton.IsChecked = false;
            LMiddle2Button.IsChecked = false;
            RMiddle2Button.IsChecked = false;
            LRingButton.IsChecked = false;
            RRingButton.IsChecked = false;
            LRing2Button.IsChecked = false;
            RRing2Button.IsChecked = false;
            LPinkyButton.IsChecked = false;
            RPinkyButton.IsChecked = false;
            LPinky2Button.IsChecked = false;
            RPinky2Button.IsChecked = false;
            PelvisButton.IsChecked = false;
            TailButton.IsChecked = false;
            Tail2Button.IsChecked = false;
            Tail3Button.IsChecked = false;
            Tail4Button.IsChecked = false;
            LThighButton.IsChecked = false;
            RThighButton.IsChecked = false;
            LKneeButton.IsChecked = false;
            RKneeButton.IsChecked = false;
            LCalfButton.IsChecked = false;
            RCalfButton.IsChecked = false;
            LFootButton.IsChecked = false;
            RFootButton.IsChecked = false;
            LToesButton.IsChecked = false;
            RToesButton.IsChecked = false;
            LEarringButton.IsChecked = false;
            REarringButton.IsChecked = false;
            LEarring2Button.IsChecked = false;
            REarring2Button.IsChecked = false;

            //Load Current Values for Slider
            CharacterDetails.NoseCheck = true;
        }
        private void NoseButton_Unchecked(object sender, RoutedEventArgs e)
        {
            CharacterDetails.NoseRotate = false;
        }
        #endregion

        #region Nostrils
        private void NostrilsRot(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.NostrilsX.value = (float)quat.X;
            CharacterDetails.NostrilsY.value = (float)quat.Y;
            CharacterDetails.NostrilsZ.value = (float)quat.Z;
            CharacterDetails.NostrilsW.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneSlider.ValueChanged -= NostrilsRot;
            BoneSlider2.ValueChanged -= NostrilsRot;
            BoneSlider3.ValueChanged -= NostrilsRot;
        }

        private void NostrilsRot2(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.NostrilsX.value = (float)quat.X;
            CharacterDetails.NostrilsY.value = (float)quat.Y;
            CharacterDetails.NostrilsZ.value = (float)quat.Z;
            CharacterDetails.NostrilsW.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneUpDown.ValueChanged -= NostrilsRot2;
            BoneUpDown2.ValueChanged -= NostrilsRot2;
            BoneUpDown3.ValueChanged -= NostrilsRot2;
        }

        private void NostrilsButton_Checked(object sender, RoutedEventArgs e)
        {
            //Disable Other Selections
            HeadButton.IsChecked = false;
            NoseButton.IsChecked = false;
            ChinButton.IsChecked = false;
            LOutEyebrowButton.IsChecked = false;
            ROutEyebrowButton.IsChecked = false;
            LInEyebrowButton.IsChecked = false;
            RInEyebrowButton.IsChecked = false;
            LEyeButton.IsChecked = false;
            REyeButton.IsChecked = false;
            LEyelidButton.IsChecked = false;
            REyelidButton.IsChecked = false;
            LLowEyelidButton.IsChecked = false;
            RLowEyelidButton.IsChecked = false;
            LEarButton.IsChecked = false;
            REarButton.IsChecked = false;
            LCheekButton.IsChecked = false;
            RCheekButton.IsChecked = false;
            LMouthButton.IsChecked = false;
            RMouthButton.IsChecked = false;
            LUpLipButton.IsChecked = false;
            RUpLipButton.IsChecked = false;
            LLowLipButton.IsChecked = false;
            RLowLipButton.IsChecked = false;
            NeckButton.IsChecked = false;
            SternumButton.IsChecked = false;
            TorsoButton.IsChecked = false;
            WaistButton.IsChecked = false;
            LShoulderButton.IsChecked = false;
            RShoulderButton.IsChecked = false;
            LClavicleButton.IsChecked = false;
            RClavicleButton.IsChecked = false;
            LBreastButton.IsChecked = false;
            RBreastButton.IsChecked = false;
            LArmButton.IsChecked = false;
            RArmButton.IsChecked = false;
            LElbowButton.IsChecked = false;
            RElbowButton.IsChecked = false;
            LForearmButton.IsChecked = false;
            RForearmButton.IsChecked = false;
            LWristButton.IsChecked = false;
            RWristButton.IsChecked = false;
            LHandButton.IsChecked = false;
            RHandButton.IsChecked = false;
            LThumbButton.IsChecked = false;
            RThumbButton.IsChecked = false;
            LThumb2Button.IsChecked = false;
            RThumb2Button.IsChecked = false;
            LIndexButton.IsChecked = false;
            RIndexButton.IsChecked = false;
            LIndex2Button.IsChecked = false;
            RIndex2Button.IsChecked = false;
            LMiddleButton.IsChecked = false;
            RMiddleButton.IsChecked = false;
            LMiddle2Button.IsChecked = false;
            RMiddle2Button.IsChecked = false;
            LRingButton.IsChecked = false;
            RRingButton.IsChecked = false;
            LRing2Button.IsChecked = false;
            RRing2Button.IsChecked = false;
            LPinkyButton.IsChecked = false;
            RPinkyButton.IsChecked = false;
            LPinky2Button.IsChecked = false;
            RPinky2Button.IsChecked = false;
            PelvisButton.IsChecked = false;
            TailButton.IsChecked = false;
            Tail2Button.IsChecked = false;
            Tail3Button.IsChecked = false;
            Tail4Button.IsChecked = false;
            LThighButton.IsChecked = false;
            RThighButton.IsChecked = false;
            LKneeButton.IsChecked = false;
            RKneeButton.IsChecked = false;
            LCalfButton.IsChecked = false;
            RCalfButton.IsChecked = false;
            LFootButton.IsChecked = false;
            RFootButton.IsChecked = false;
            LToesButton.IsChecked = false;
            RToesButton.IsChecked = false;
            LEarringButton.IsChecked = false;
            REarringButton.IsChecked = false;
            LEarring2Button.IsChecked = false;
            REarring2Button.IsChecked = false;

            //Load Current Values for Slider
            CharacterDetails.NostrilsCheck = true;
        }
        private void NostrilsButton_Unchecked(object sender, RoutedEventArgs e)
        {
            CharacterDetails.NostrilsRotate = false;
        }
        #endregion

        #region Chin
        private void ChinRot(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.ChinX.value = (float)quat.X;
            CharacterDetails.ChinY.value = (float)quat.Y;
            CharacterDetails.ChinZ.value = (float)quat.Z;
            CharacterDetails.ChinW.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneSlider.ValueChanged -= ChinRot;
            BoneSlider2.ValueChanged -= ChinRot;
            BoneSlider3.ValueChanged -= ChinRot;
        }

        private void ChinRot2(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.ChinX.value = (float)quat.X;
            CharacterDetails.ChinY.value = (float)quat.Y;
            CharacterDetails.ChinZ.value = (float)quat.Z;
            CharacterDetails.ChinW.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneUpDown.ValueChanged -= ChinRot2;
            BoneUpDown2.ValueChanged -= ChinRot2;
            BoneUpDown3.ValueChanged -= ChinRot2;
        }

        private void ChinButton_Checked(object sender, RoutedEventArgs e)
        {
            //Disable Other Selections
            HeadButton.IsChecked = false;
            NoseButton.IsChecked = false;
            NostrilsButton.IsChecked = false;
            LOutEyebrowButton.IsChecked = false;
            ROutEyebrowButton.IsChecked = false;
            LInEyebrowButton.IsChecked = false;
            RInEyebrowButton.IsChecked = false;
            LEyeButton.IsChecked = false;
            REyeButton.IsChecked = false;
            LEyelidButton.IsChecked = false;
            REyelidButton.IsChecked = false;
            LLowEyelidButton.IsChecked = false;
            RLowEyelidButton.IsChecked = false;
            LEarButton.IsChecked = false;
            REarButton.IsChecked = false;
            LCheekButton.IsChecked = false;
            RCheekButton.IsChecked = false;
            LMouthButton.IsChecked = false;
            RMouthButton.IsChecked = false;
            LUpLipButton.IsChecked = false;
            RUpLipButton.IsChecked = false;
            LLowLipButton.IsChecked = false;
            RLowLipButton.IsChecked = false;
            NeckButton.IsChecked = false;
            SternumButton.IsChecked = false;
            TorsoButton.IsChecked = false;
            WaistButton.IsChecked = false;
            LShoulderButton.IsChecked = false;
            RShoulderButton.IsChecked = false;
            LClavicleButton.IsChecked = false;
            RClavicleButton.IsChecked = false;
            LBreastButton.IsChecked = false;
            RBreastButton.IsChecked = false;
            LArmButton.IsChecked = false;
            RArmButton.IsChecked = false;
            LElbowButton.IsChecked = false;
            RElbowButton.IsChecked = false;
            LForearmButton.IsChecked = false;
            RForearmButton.IsChecked = false;
            LWristButton.IsChecked = false;
            RWristButton.IsChecked = false;
            LHandButton.IsChecked = false;
            RHandButton.IsChecked = false;
            LThumbButton.IsChecked = false;
            RThumbButton.IsChecked = false;
            LThumb2Button.IsChecked = false;
            RThumb2Button.IsChecked = false;
            LIndexButton.IsChecked = false;
            RIndexButton.IsChecked = false;
            LIndex2Button.IsChecked = false;
            RIndex2Button.IsChecked = false;
            LMiddleButton.IsChecked = false;
            RMiddleButton.IsChecked = false;
            LMiddle2Button.IsChecked = false;
            RMiddle2Button.IsChecked = false;
            LRingButton.IsChecked = false;
            RRingButton.IsChecked = false;
            LRing2Button.IsChecked = false;
            RRing2Button.IsChecked = false;
            LPinkyButton.IsChecked = false;
            RPinkyButton.IsChecked = false;
            LPinky2Button.IsChecked = false;
            RPinky2Button.IsChecked = false;
            PelvisButton.IsChecked = false;
            TailButton.IsChecked = false;
            Tail2Button.IsChecked = false;
            Tail3Button.IsChecked = false;
            Tail4Button.IsChecked = false;
            LThighButton.IsChecked = false;
            RThighButton.IsChecked = false;
            LKneeButton.IsChecked = false;
            RKneeButton.IsChecked = false;
            LCalfButton.IsChecked = false;
            RCalfButton.IsChecked = false;
            LFootButton.IsChecked = false;
            RFootButton.IsChecked = false;
            LToesButton.IsChecked = false;
            RToesButton.IsChecked = false;
            LEarringButton.IsChecked = false;
            REarringButton.IsChecked = false;
            LEarring2Button.IsChecked = false;
            REarring2Button.IsChecked = false;

            //Load Current Values for Slider
            CharacterDetails.ChinCheck = true;
        }
        private void ChinButton_Unchecked(object sender, RoutedEventArgs e)
        {
            CharacterDetails.ChinRotate = false;
        }
        #endregion

        #region LOutEyebrow
        private void LOutEyebrowRot(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.LOutEyebrowX.value = (float)quat.X;
            CharacterDetails.LOutEyebrowY.value = (float)quat.Y;
            CharacterDetails.LOutEyebrowZ.value = (float)quat.Z;
            CharacterDetails.LOutEyebrowW.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneSlider.ValueChanged -= LOutEyebrowRot;
            BoneSlider2.ValueChanged -= LOutEyebrowRot;
            BoneSlider3.ValueChanged -= LOutEyebrowRot;
        }

        private void LOutEyebrowRot2(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.LOutEyebrowX.value = (float)quat.X;
            CharacterDetails.LOutEyebrowY.value = (float)quat.Y;
            CharacterDetails.LOutEyebrowZ.value = (float)quat.Z;
            CharacterDetails.LOutEyebrowW.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneUpDown.ValueChanged -= LOutEyebrowRot2;
            BoneUpDown2.ValueChanged -= LOutEyebrowRot2;
            BoneUpDown3.ValueChanged -= LOutEyebrowRot2;
        }

        private void LOutEyebrowButton_Checked(object sender, RoutedEventArgs e)
        {
            //Disable Other Selections
            HeadButton.IsChecked = false;
            NoseButton.IsChecked = false;
            NostrilsButton.IsChecked = false;
            ChinButton.IsChecked = false;
            ROutEyebrowButton.IsChecked = false;
            LInEyebrowButton.IsChecked = false;
            RInEyebrowButton.IsChecked = false;
            LEyeButton.IsChecked = false;
            REyeButton.IsChecked = false;
            LEyelidButton.IsChecked = false;
            REyelidButton.IsChecked = false;
            LLowEyelidButton.IsChecked = false;
            RLowEyelidButton.IsChecked = false;
            LEarButton.IsChecked = false;
            REarButton.IsChecked = false;
            LCheekButton.IsChecked = false;
            RCheekButton.IsChecked = false;
            LMouthButton.IsChecked = false;
            RMouthButton.IsChecked = false;
            LUpLipButton.IsChecked = false;
            RUpLipButton.IsChecked = false;
            LLowLipButton.IsChecked = false;
            RLowLipButton.IsChecked = false;
            NeckButton.IsChecked = false;
            SternumButton.IsChecked = false;
            TorsoButton.IsChecked = false;
            WaistButton.IsChecked = false;
            LShoulderButton.IsChecked = false;
            RShoulderButton.IsChecked = false;
            LClavicleButton.IsChecked = false;
            RClavicleButton.IsChecked = false;
            LBreastButton.IsChecked = false;
            RBreastButton.IsChecked = false;
            LArmButton.IsChecked = false;
            RArmButton.IsChecked = false;
            LElbowButton.IsChecked = false;
            RElbowButton.IsChecked = false;
            LForearmButton.IsChecked = false;
            RForearmButton.IsChecked = false;
            LWristButton.IsChecked = false;
            RWristButton.IsChecked = false;
            LHandButton.IsChecked = false;
            RHandButton.IsChecked = false;
            LThumbButton.IsChecked = false;
            RThumbButton.IsChecked = false;
            LThumb2Button.IsChecked = false;
            RThumb2Button.IsChecked = false;
            LIndexButton.IsChecked = false;
            RIndexButton.IsChecked = false;
            LIndex2Button.IsChecked = false;
            RIndex2Button.IsChecked = false;
            LMiddleButton.IsChecked = false;
            RMiddleButton.IsChecked = false;
            LMiddle2Button.IsChecked = false;
            RMiddle2Button.IsChecked = false;
            LRingButton.IsChecked = false;
            RRingButton.IsChecked = false;
            LRing2Button.IsChecked = false;
            RRing2Button.IsChecked = false;
            LPinkyButton.IsChecked = false;
            RPinkyButton.IsChecked = false;
            LPinky2Button.IsChecked = false;
            RPinky2Button.IsChecked = false;
            PelvisButton.IsChecked = false;
            TailButton.IsChecked = false;
            Tail2Button.IsChecked = false;
            Tail3Button.IsChecked = false;
            Tail4Button.IsChecked = false;
            LThighButton.IsChecked = false;
            RThighButton.IsChecked = false;
            LKneeButton.IsChecked = false;
            RKneeButton.IsChecked = false;
            LCalfButton.IsChecked = false;
            RCalfButton.IsChecked = false;
            LFootButton.IsChecked = false;
            RFootButton.IsChecked = false;
            LToesButton.IsChecked = false;
            RToesButton.IsChecked = false;
            LEarringButton.IsChecked = false;
            REarringButton.IsChecked = false;
            LEarring2Button.IsChecked = false;
            REarring2Button.IsChecked = false;

            //Load Current Values for Slider
            CharacterDetails.LOutEyebrowCheck = true;
        }
        private void LOutEyebrowButton_Unchecked(object sender, RoutedEventArgs e)
        {
            CharacterDetails.LOutEyebrowRotate = false;
        }
        #endregion

        #region ROutEyebrow
        private void ROutEyebrowRot(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.ROutEyebrowX.value = (float)quat.X;
            CharacterDetails.ROutEyebrowY.value = (float)quat.Y;
            CharacterDetails.ROutEyebrowZ.value = (float)quat.Z;
            CharacterDetails.ROutEyebrowW.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneSlider.ValueChanged -= ROutEyebrowRot;
            BoneSlider2.ValueChanged -= ROutEyebrowRot;
            BoneSlider3.ValueChanged -= ROutEyebrowRot;
        }

        private void ROutEyebrowRot2(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.ROutEyebrowX.value = (float)quat.X;
            CharacterDetails.ROutEyebrowY.value = (float)quat.Y;
            CharacterDetails.ROutEyebrowZ.value = (float)quat.Z;
            CharacterDetails.ROutEyebrowW.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneUpDown.ValueChanged -= ROutEyebrowRot2;
            BoneUpDown2.ValueChanged -= ROutEyebrowRot2;
            BoneUpDown3.ValueChanged -= ROutEyebrowRot2;
        }

        private void ROutEyebrowButton_Checked(object sender, RoutedEventArgs e)
        {
            //Disable Other Selections
            HeadButton.IsChecked = false;
            NoseButton.IsChecked = false;
            NostrilsButton.IsChecked = false;
            ChinButton.IsChecked = false;
            LOutEyebrowButton.IsChecked = false;
            LInEyebrowButton.IsChecked = false;
            RInEyebrowButton.IsChecked = false;
            LEyeButton.IsChecked = false;
            REyeButton.IsChecked = false;
            LEyelidButton.IsChecked = false;
            REyelidButton.IsChecked = false;
            LLowEyelidButton.IsChecked = false;
            RLowEyelidButton.IsChecked = false;
            LEarButton.IsChecked = false;
            REarButton.IsChecked = false;
            LCheekButton.IsChecked = false;
            RCheekButton.IsChecked = false;
            LMouthButton.IsChecked = false;
            RMouthButton.IsChecked = false;
            LUpLipButton.IsChecked = false;
            RUpLipButton.IsChecked = false;
            LLowLipButton.IsChecked = false;
            RLowLipButton.IsChecked = false;
            NeckButton.IsChecked = false;
            SternumButton.IsChecked = false;
            TorsoButton.IsChecked = false;
            WaistButton.IsChecked = false;
            LShoulderButton.IsChecked = false;
            RShoulderButton.IsChecked = false;
            LClavicleButton.IsChecked = false;
            RClavicleButton.IsChecked = false;
            LBreastButton.IsChecked = false;
            RBreastButton.IsChecked = false;
            LArmButton.IsChecked = false;
            RArmButton.IsChecked = false;
            LElbowButton.IsChecked = false;
            RElbowButton.IsChecked = false;
            LForearmButton.IsChecked = false;
            RForearmButton.IsChecked = false;
            LWristButton.IsChecked = false;
            RWristButton.IsChecked = false;
            LHandButton.IsChecked = false;
            RHandButton.IsChecked = false;
            LThumbButton.IsChecked = false;
            RThumbButton.IsChecked = false;
            LThumb2Button.IsChecked = false;
            RThumb2Button.IsChecked = false;
            LIndexButton.IsChecked = false;
            RIndexButton.IsChecked = false;
            LIndex2Button.IsChecked = false;
            RIndex2Button.IsChecked = false;
            LMiddleButton.IsChecked = false;
            RMiddleButton.IsChecked = false;
            LMiddle2Button.IsChecked = false;
            RMiddle2Button.IsChecked = false;
            LRingButton.IsChecked = false;
            RRingButton.IsChecked = false;
            LRing2Button.IsChecked = false;
            RRing2Button.IsChecked = false;
            LPinkyButton.IsChecked = false;
            RPinkyButton.IsChecked = false;
            LPinky2Button.IsChecked = false;
            RPinky2Button.IsChecked = false;
            PelvisButton.IsChecked = false;
            TailButton.IsChecked = false;
            Tail2Button.IsChecked = false;
            Tail3Button.IsChecked = false;
            Tail4Button.IsChecked = false;
            LThighButton.IsChecked = false;
            RThighButton.IsChecked = false;
            LKneeButton.IsChecked = false;
            RKneeButton.IsChecked = false;
            LCalfButton.IsChecked = false;
            RCalfButton.IsChecked = false;
            LFootButton.IsChecked = false;
            RFootButton.IsChecked = false;
            LToesButton.IsChecked = false;
            RToesButton.IsChecked = false;
            LEarringButton.IsChecked = false;
            REarringButton.IsChecked = false;
            LEarring2Button.IsChecked = false;
            REarring2Button.IsChecked = false;

            //Load Current Values for Slider
            CharacterDetails.ROutEyebrowCheck = true;
        }
        private void ROutEyebrowButton_Unchecked(object sender, RoutedEventArgs e)
        {
            CharacterDetails.ROutEyebrowRotate = false;
        }
        #endregion

        #region LInEyebrow
        private void LInEyebrowRot(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.LInEyebrowX.value = (float)quat.X;
            CharacterDetails.LInEyebrowY.value = (float)quat.Y;
            CharacterDetails.LInEyebrowZ.value = (float)quat.Z;
            CharacterDetails.LInEyebrowW.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneSlider.ValueChanged -= LInEyebrowRot;
            BoneSlider2.ValueChanged -= LInEyebrowRot;
            BoneSlider3.ValueChanged -= LInEyebrowRot;
        }

        private void LInEyebrowRot2(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.LInEyebrowX.value = (float)quat.X;
            CharacterDetails.LInEyebrowY.value = (float)quat.Y;
            CharacterDetails.LInEyebrowZ.value = (float)quat.Z;
            CharacterDetails.LInEyebrowW.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneUpDown.ValueChanged -= LInEyebrowRot2;
            BoneUpDown2.ValueChanged -= LInEyebrowRot2;
            BoneUpDown3.ValueChanged -= LInEyebrowRot2;
        }

        private void LInEyebrowButton_Checked(object sender, RoutedEventArgs e)
        {
            //Disable Other Selections
            HeadButton.IsChecked = false;
            NoseButton.IsChecked = false;
            NostrilsButton.IsChecked = false;
            ChinButton.IsChecked = false;
            LOutEyebrowButton.IsChecked = false;
            ROutEyebrowButton.IsChecked = false;
            RInEyebrowButton.IsChecked = false;
            LEyeButton.IsChecked = false;
            REyeButton.IsChecked = false;
            LEyelidButton.IsChecked = false;
            REyelidButton.IsChecked = false;
            LLowEyelidButton.IsChecked = false;
            RLowEyelidButton.IsChecked = false;
            LEarButton.IsChecked = false;
            REarButton.IsChecked = false;
            LCheekButton.IsChecked = false;
            RCheekButton.IsChecked = false;
            LMouthButton.IsChecked = false;
            RMouthButton.IsChecked = false;
            LUpLipButton.IsChecked = false;
            RUpLipButton.IsChecked = false;
            LLowLipButton.IsChecked = false;
            RLowLipButton.IsChecked = false;
            NeckButton.IsChecked = false;
            SternumButton.IsChecked = false;
            TorsoButton.IsChecked = false;
            WaistButton.IsChecked = false;
            LShoulderButton.IsChecked = false;
            RShoulderButton.IsChecked = false;
            LClavicleButton.IsChecked = false;
            RClavicleButton.IsChecked = false;
            LBreastButton.IsChecked = false;
            RBreastButton.IsChecked = false;
            LArmButton.IsChecked = false;
            RArmButton.IsChecked = false;
            LElbowButton.IsChecked = false;
            RElbowButton.IsChecked = false;
            LForearmButton.IsChecked = false;
            RForearmButton.IsChecked = false;
            LWristButton.IsChecked = false;
            RWristButton.IsChecked = false;
            LHandButton.IsChecked = false;
            RHandButton.IsChecked = false;
            LThumbButton.IsChecked = false;
            RThumbButton.IsChecked = false;
            LThumb2Button.IsChecked = false;
            RThumb2Button.IsChecked = false;
            LIndexButton.IsChecked = false;
            RIndexButton.IsChecked = false;
            LIndex2Button.IsChecked = false;
            RIndex2Button.IsChecked = false;
            LMiddleButton.IsChecked = false;
            RMiddleButton.IsChecked = false;
            LMiddle2Button.IsChecked = false;
            RMiddle2Button.IsChecked = false;
            LRingButton.IsChecked = false;
            RRingButton.IsChecked = false;
            LRing2Button.IsChecked = false;
            RRing2Button.IsChecked = false;
            LPinkyButton.IsChecked = false;
            RPinkyButton.IsChecked = false;
            LPinky2Button.IsChecked = false;
            RPinky2Button.IsChecked = false;
            PelvisButton.IsChecked = false;
            TailButton.IsChecked = false;
            Tail2Button.IsChecked = false;
            Tail3Button.IsChecked = false;
            Tail4Button.IsChecked = false;
            LThighButton.IsChecked = false;
            RThighButton.IsChecked = false;
            LKneeButton.IsChecked = false;
            RKneeButton.IsChecked = false;
            LCalfButton.IsChecked = false;
            RCalfButton.IsChecked = false;
            LFootButton.IsChecked = false;
            RFootButton.IsChecked = false;
            LToesButton.IsChecked = false;
            RToesButton.IsChecked = false;
            LEarringButton.IsChecked = false;
            REarringButton.IsChecked = false;
            LEarring2Button.IsChecked = false;
            REarring2Button.IsChecked = false;

            //Load Current Values for Slider
            CharacterDetails.LInEyebrowCheck = true;
        }
        private void LInEyebrowButton_Unchecked(object sender, RoutedEventArgs e)
        {
            CharacterDetails.LInEyebrowRotate = false;
        }
        #endregion

        #region RInEyebrow
        private void RInEyebrowRot(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.RInEyebrowX.value = (float)quat.X;
            CharacterDetails.RInEyebrowY.value = (float)quat.Y;
            CharacterDetails.RInEyebrowZ.value = (float)quat.Z;
            CharacterDetails.RInEyebrowW.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneSlider.ValueChanged -= RInEyebrowRot;
            BoneSlider2.ValueChanged -= RInEyebrowRot;
            BoneSlider3.ValueChanged -= RInEyebrowRot;
        }

        private void RInEyebrowRot2(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.RInEyebrowX.value = (float)quat.X;
            CharacterDetails.RInEyebrowY.value = (float)quat.Y;
            CharacterDetails.RInEyebrowZ.value = (float)quat.Z;
            CharacterDetails.RInEyebrowW.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneUpDown.ValueChanged -= RInEyebrowRot2;
            BoneUpDown2.ValueChanged -= RInEyebrowRot2;
            BoneUpDown3.ValueChanged -= RInEyebrowRot2;
        }

        private void RInEyebrowButton_Checked(object sender, RoutedEventArgs e)
        {
            //Disable Other Selections
            HeadButton.IsChecked = false;
            NoseButton.IsChecked = false;
            NostrilsButton.IsChecked = false;
            ChinButton.IsChecked = false;
            LOutEyebrowButton.IsChecked = false;
            ROutEyebrowButton.IsChecked = false;
            LInEyebrowButton.IsChecked = false;
            LEyeButton.IsChecked = false;
            REyeButton.IsChecked = false;
            LEyelidButton.IsChecked = false;
            REyelidButton.IsChecked = false;
            LLowEyelidButton.IsChecked = false;
            RLowEyelidButton.IsChecked = false;
            LEarButton.IsChecked = false;
            REarButton.IsChecked = false;
            LCheekButton.IsChecked = false;
            RCheekButton.IsChecked = false;
            LMouthButton.IsChecked = false;
            RMouthButton.IsChecked = false;
            LUpLipButton.IsChecked = false;
            RUpLipButton.IsChecked = false;
            LLowLipButton.IsChecked = false;
            RLowLipButton.IsChecked = false;
            NeckButton.IsChecked = false;
            SternumButton.IsChecked = false;
            TorsoButton.IsChecked = false;
            WaistButton.IsChecked = false;
            LShoulderButton.IsChecked = false;
            RShoulderButton.IsChecked = false;
            LClavicleButton.IsChecked = false;
            RClavicleButton.IsChecked = false;
            LBreastButton.IsChecked = false;
            RBreastButton.IsChecked = false;
            LArmButton.IsChecked = false;
            RArmButton.IsChecked = false;
            LElbowButton.IsChecked = false;
            RElbowButton.IsChecked = false;
            LForearmButton.IsChecked = false;
            RForearmButton.IsChecked = false;
            LWristButton.IsChecked = false;
            RWristButton.IsChecked = false;
            LHandButton.IsChecked = false;
            RHandButton.IsChecked = false;
            LThumbButton.IsChecked = false;
            RThumbButton.IsChecked = false;
            LThumb2Button.IsChecked = false;
            RThumb2Button.IsChecked = false;
            LIndexButton.IsChecked = false;
            RIndexButton.IsChecked = false;
            LIndex2Button.IsChecked = false;
            RIndex2Button.IsChecked = false;
            LMiddleButton.IsChecked = false;
            RMiddleButton.IsChecked = false;
            LMiddle2Button.IsChecked = false;
            RMiddle2Button.IsChecked = false;
            LRingButton.IsChecked = false;
            RRingButton.IsChecked = false;
            LRing2Button.IsChecked = false;
            RRing2Button.IsChecked = false;
            LPinkyButton.IsChecked = false;
            RPinkyButton.IsChecked = false;
            LPinky2Button.IsChecked = false;
            RPinky2Button.IsChecked = false;
            PelvisButton.IsChecked = false;
            TailButton.IsChecked = false;
            Tail2Button.IsChecked = false;
            Tail3Button.IsChecked = false;
            Tail4Button.IsChecked = false;
            LThighButton.IsChecked = false;
            RThighButton.IsChecked = false;
            LKneeButton.IsChecked = false;
            RKneeButton.IsChecked = false;
            LCalfButton.IsChecked = false;
            RCalfButton.IsChecked = false;
            LFootButton.IsChecked = false;
            RFootButton.IsChecked = false;
            LToesButton.IsChecked = false;
            RToesButton.IsChecked = false;
            LEarringButton.IsChecked = false;
            REarringButton.IsChecked = false;
            LEarring2Button.IsChecked = false;
            REarring2Button.IsChecked = false;

            //Load Current Values for Slider
            CharacterDetails.RInEyebrowCheck = true;
        }
        private void RInEyebrowButton_Unchecked(object sender, RoutedEventArgs e)
        {
            CharacterDetails.RInEyebrowRotate = false;
        }
        #endregion

        #region LEye
        private void LEyeRot(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.LEyeX.value = (float)quat.X;
            CharacterDetails.LEyeY.value = (float)quat.Y;
            CharacterDetails.LEyeZ.value = (float)quat.Z;
            CharacterDetails.LEyeW.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneSlider.ValueChanged -= LEyeRot;
            BoneSlider2.ValueChanged -= LEyeRot;
            BoneSlider3.ValueChanged -= LEyeRot;
        }

        private void LEyeRot2(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.LEyeX.value = (float)quat.X;
            CharacterDetails.LEyeY.value = (float)quat.Y;
            CharacterDetails.LEyeZ.value = (float)quat.Z;
            CharacterDetails.LEyeW.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneUpDown.ValueChanged -= LEyeRot2;
            BoneUpDown2.ValueChanged -= LEyeRot2;
            BoneUpDown3.ValueChanged -= LEyeRot2;
        }

        private void LEyeButton_Checked(object sender, RoutedEventArgs e)
        {
            //Disable Other Selections
            HeadButton.IsChecked = false;
            NoseButton.IsChecked = false;
            NostrilsButton.IsChecked = false;
            ChinButton.IsChecked = false;
            LOutEyebrowButton.IsChecked = false;
            ROutEyebrowButton.IsChecked = false;
            LInEyebrowButton.IsChecked = false;
            RInEyebrowButton.IsChecked = false;
            REyeButton.IsChecked = false;
            LEyelidButton.IsChecked = false;
            REyelidButton.IsChecked = false;
            LLowEyelidButton.IsChecked = false;
            RLowEyelidButton.IsChecked = false;
            LEarButton.IsChecked = false;
            REarButton.IsChecked = false;
            LCheekButton.IsChecked = false;
            RCheekButton.IsChecked = false;
            LMouthButton.IsChecked = false;
            RMouthButton.IsChecked = false;
            LUpLipButton.IsChecked = false;
            RUpLipButton.IsChecked = false;
            LLowLipButton.IsChecked = false;
            RLowLipButton.IsChecked = false;
            NeckButton.IsChecked = false;
            SternumButton.IsChecked = false;
            TorsoButton.IsChecked = false;
            WaistButton.IsChecked = false;
            LShoulderButton.IsChecked = false;
            RShoulderButton.IsChecked = false;
            LClavicleButton.IsChecked = false;
            RClavicleButton.IsChecked = false;
            LBreastButton.IsChecked = false;
            RBreastButton.IsChecked = false;
            LArmButton.IsChecked = false;
            RArmButton.IsChecked = false;
            LElbowButton.IsChecked = false;
            RElbowButton.IsChecked = false;
            LForearmButton.IsChecked = false;
            RForearmButton.IsChecked = false;
            LWristButton.IsChecked = false;
            RWristButton.IsChecked = false;
            LHandButton.IsChecked = false;
            RHandButton.IsChecked = false;
            LThumbButton.IsChecked = false;
            RThumbButton.IsChecked = false;
            LThumb2Button.IsChecked = false;
            RThumb2Button.IsChecked = false;
            LIndexButton.IsChecked = false;
            RIndexButton.IsChecked = false;
            LIndex2Button.IsChecked = false;
            RIndex2Button.IsChecked = false;
            LMiddleButton.IsChecked = false;
            RMiddleButton.IsChecked = false;
            LMiddle2Button.IsChecked = false;
            RMiddle2Button.IsChecked = false;
            LRingButton.IsChecked = false;
            RRingButton.IsChecked = false;
            LRing2Button.IsChecked = false;
            RRing2Button.IsChecked = false;
            LPinkyButton.IsChecked = false;
            RPinkyButton.IsChecked = false;
            LPinky2Button.IsChecked = false;
            RPinky2Button.IsChecked = false;
            PelvisButton.IsChecked = false;
            TailButton.IsChecked = false;
            Tail2Button.IsChecked = false;
            Tail3Button.IsChecked = false;
            Tail4Button.IsChecked = false;
            LThighButton.IsChecked = false;
            RThighButton.IsChecked = false;
            LKneeButton.IsChecked = false;
            RKneeButton.IsChecked = false;
            LCalfButton.IsChecked = false;
            RCalfButton.IsChecked = false;
            LFootButton.IsChecked = false;
            RFootButton.IsChecked = false;
            LToesButton.IsChecked = false;
            RToesButton.IsChecked = false;
            LEarringButton.IsChecked = false;
            REarringButton.IsChecked = false;
            LEarring2Button.IsChecked = false;
            REarring2Button.IsChecked = false;

            //Load Current Values for Slider
            CharacterDetails.LEyeCheck = true;
        }
        private void LEyeButton_Unchecked(object sender, RoutedEventArgs e)
        {
            CharacterDetails.LEyeRotate = false;
        }
        #endregion

        #region REye
        private void REyeRot(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.REyeX.value = (float)quat.X;
            CharacterDetails.REyeY.value = (float)quat.Y;
            CharacterDetails.REyeZ.value = (float)quat.Z;
            CharacterDetails.REyeW.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneSlider.ValueChanged -= REyeRot;
            BoneSlider2.ValueChanged -= REyeRot;
            BoneSlider3.ValueChanged -= REyeRot;

        }

        private void REyeRot2(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.REyeX.value = (float)quat.X;
            CharacterDetails.REyeY.value = (float)quat.Y;
            CharacterDetails.REyeZ.value = (float)quat.Z;
            CharacterDetails.REyeW.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneUpDown.ValueChanged -= REyeRot2;
            BoneUpDown2.ValueChanged -= REyeRot2;
            BoneUpDown3.ValueChanged -= REyeRot2;
        }

        private void REyeButton_Checked(object sender, RoutedEventArgs e)
        {
            //Disable Other Selections
            HeadButton.IsChecked = false;
            NoseButton.IsChecked = false;
            NostrilsButton.IsChecked = false;
            ChinButton.IsChecked = false;
            LOutEyebrowButton.IsChecked = false;
            ROutEyebrowButton.IsChecked = false;
            LInEyebrowButton.IsChecked = false;
            RInEyebrowButton.IsChecked = false;
            LEyeButton.IsChecked = false;
            LEyelidButton.IsChecked = false;
            REyelidButton.IsChecked = false;
            LLowEyelidButton.IsChecked = false;
            RLowEyelidButton.IsChecked = false;
            LEarButton.IsChecked = false;
            REarButton.IsChecked = false;
            LCheekButton.IsChecked = false;
            RCheekButton.IsChecked = false;
            LMouthButton.IsChecked = false;
            RMouthButton.IsChecked = false;
            LUpLipButton.IsChecked = false;
            RUpLipButton.IsChecked = false;
            LLowLipButton.IsChecked = false;
            RLowLipButton.IsChecked = false;
            NeckButton.IsChecked = false;
            SternumButton.IsChecked = false;
            TorsoButton.IsChecked = false;
            WaistButton.IsChecked = false;
            LShoulderButton.IsChecked = false;
            RShoulderButton.IsChecked = false;
            LClavicleButton.IsChecked = false;
            RClavicleButton.IsChecked = false;
            LBreastButton.IsChecked = false;
            RBreastButton.IsChecked = false;
            LArmButton.IsChecked = false;
            RArmButton.IsChecked = false;
            LElbowButton.IsChecked = false;
            RElbowButton.IsChecked = false;
            LForearmButton.IsChecked = false;
            RForearmButton.IsChecked = false;
            LWristButton.IsChecked = false;
            RWristButton.IsChecked = false;
            LHandButton.IsChecked = false;
            RHandButton.IsChecked = false;
            LThumbButton.IsChecked = false;
            RThumbButton.IsChecked = false;
            LThumb2Button.IsChecked = false;
            RThumb2Button.IsChecked = false;
            LIndexButton.IsChecked = false;
            RIndexButton.IsChecked = false;
            LIndex2Button.IsChecked = false;
            RIndex2Button.IsChecked = false;
            LMiddleButton.IsChecked = false;
            RMiddleButton.IsChecked = false;
            LMiddle2Button.IsChecked = false;
            RMiddle2Button.IsChecked = false;
            LRingButton.IsChecked = false;
            RRingButton.IsChecked = false;
            LRing2Button.IsChecked = false;
            RRing2Button.IsChecked = false;
            LPinkyButton.IsChecked = false;
            RPinkyButton.IsChecked = false;
            LPinky2Button.IsChecked = false;
            RPinky2Button.IsChecked = false;
            PelvisButton.IsChecked = false;
            TailButton.IsChecked = false;
            Tail2Button.IsChecked = false;
            Tail3Button.IsChecked = false;
            Tail4Button.IsChecked = false;
            LThighButton.IsChecked = false;
            RThighButton.IsChecked = false;
            LKneeButton.IsChecked = false;
            RKneeButton.IsChecked = false;
            LCalfButton.IsChecked = false;
            RCalfButton.IsChecked = false;
            LFootButton.IsChecked = false;
            RFootButton.IsChecked = false;
            LToesButton.IsChecked = false;
            RToesButton.IsChecked = false;
            LEarringButton.IsChecked = false;
            REarringButton.IsChecked = false;
            LEarring2Button.IsChecked = false;
            REarring2Button.IsChecked = false;

            //Load Current Values for Slider
            CharacterDetails.REyeCheck = true;
        }
        private void REyeButton_Unchecked(object sender, RoutedEventArgs e)
        {
            CharacterDetails.REyeRotate = false;
        }
        #endregion

        #region LEyelid
        private void LEyelidRot(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.LEyelidX.value = (float)quat.X;
            CharacterDetails.LEyelidY.value = (float)quat.Y;
            CharacterDetails.LEyelidZ.value = (float)quat.Z;
            CharacterDetails.LEyelidW.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneSlider.ValueChanged -= LEyelidRot;
            BoneSlider2.ValueChanged -= LEyelidRot;
            BoneSlider3.ValueChanged -= LEyelidRot;
        }

        private void LEyelidRot2(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.LEyelidX.value = (float)quat.X;
            CharacterDetails.LEyelidY.value = (float)quat.Y;
            CharacterDetails.LEyelidZ.value = (float)quat.Z;
            CharacterDetails.LEyelidW.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneUpDown.ValueChanged -= LEyelidRot2;
            BoneUpDown2.ValueChanged -= LEyelidRot2;
            BoneUpDown3.ValueChanged -= LEyelidRot2;
        }

        private void LEyelidButton_Checked(object sender, RoutedEventArgs e)
        {
            //Disable Other Selections
            HeadButton.IsChecked = false;
            NoseButton.IsChecked = false;
            NostrilsButton.IsChecked = false;
            ChinButton.IsChecked = false;
            LOutEyebrowButton.IsChecked = false;
            ROutEyebrowButton.IsChecked = false;
            LInEyebrowButton.IsChecked = false;
            RInEyebrowButton.IsChecked = false;
            LEyeButton.IsChecked = false;
            REyeButton.IsChecked = false;
            REyelidButton.IsChecked = false;
            LLowEyelidButton.IsChecked = false;
            RLowEyelidButton.IsChecked = false;
            LEarButton.IsChecked = false;
            REarButton.IsChecked = false;
            LCheekButton.IsChecked = false;
            RCheekButton.IsChecked = false;
            LMouthButton.IsChecked = false;
            RMouthButton.IsChecked = false;
            LUpLipButton.IsChecked = false;
            RUpLipButton.IsChecked = false;
            LLowLipButton.IsChecked = false;
            RLowLipButton.IsChecked = false;
            NeckButton.IsChecked = false;
            SternumButton.IsChecked = false;
            TorsoButton.IsChecked = false;
            WaistButton.IsChecked = false;
            LShoulderButton.IsChecked = false;
            RShoulderButton.IsChecked = false;
            LClavicleButton.IsChecked = false;
            RClavicleButton.IsChecked = false;
            LBreastButton.IsChecked = false;
            RBreastButton.IsChecked = false;
            LArmButton.IsChecked = false;
            RArmButton.IsChecked = false;
            LElbowButton.IsChecked = false;
            RElbowButton.IsChecked = false;
            LForearmButton.IsChecked = false;
            RForearmButton.IsChecked = false;
            LWristButton.IsChecked = false;
            RWristButton.IsChecked = false;
            LHandButton.IsChecked = false;
            RHandButton.IsChecked = false;
            LThumbButton.IsChecked = false;
            RThumbButton.IsChecked = false;
            LThumb2Button.IsChecked = false;
            RThumb2Button.IsChecked = false;
            LIndexButton.IsChecked = false;
            RIndexButton.IsChecked = false;
            LIndex2Button.IsChecked = false;
            RIndex2Button.IsChecked = false;
            LMiddleButton.IsChecked = false;
            RMiddleButton.IsChecked = false;
            LMiddle2Button.IsChecked = false;
            RMiddle2Button.IsChecked = false;
            LRingButton.IsChecked = false;
            RRingButton.IsChecked = false;
            LRing2Button.IsChecked = false;
            RRing2Button.IsChecked = false;
            LPinkyButton.IsChecked = false;
            RPinkyButton.IsChecked = false;
            LPinky2Button.IsChecked = false;
            RPinky2Button.IsChecked = false;
            PelvisButton.IsChecked = false;
            TailButton.IsChecked = false;
            Tail2Button.IsChecked = false;
            Tail3Button.IsChecked = false;
            Tail4Button.IsChecked = false;
            LThighButton.IsChecked = false;
            RThighButton.IsChecked = false;
            LKneeButton.IsChecked = false;
            RKneeButton.IsChecked = false;
            LCalfButton.IsChecked = false;
            RCalfButton.IsChecked = false;
            LFootButton.IsChecked = false;
            RFootButton.IsChecked = false;
            LToesButton.IsChecked = false;
            RToesButton.IsChecked = false;
            LEarringButton.IsChecked = false;
            REarringButton.IsChecked = false;
            LEarring2Button.IsChecked = false;
            REarring2Button.IsChecked = false;

            //Load Current Values for Slider
            CharacterDetails.LEyelidCheck = true;
        }
        private void LEyelidButton_Unchecked(object sender, RoutedEventArgs e)
        {
            CharacterDetails.LEyelidRotate = false;
        }
        #endregion

        #region REyelid
        private void REyelidRot(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.REyelidX.value = (float)quat.X;
            CharacterDetails.REyelidY.value = (float)quat.Y;
            CharacterDetails.REyelidZ.value = (float)quat.Z;
            CharacterDetails.REyelidW.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneSlider.ValueChanged -= REyelidRot;
            BoneSlider2.ValueChanged -= REyelidRot;
            BoneSlider3.ValueChanged -= REyelidRot;
        }

        private void REyelidRot2(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.REyelidX.value = (float)quat.X;
            CharacterDetails.REyelidY.value = (float)quat.Y;
            CharacterDetails.REyelidZ.value = (float)quat.Z;
            CharacterDetails.REyelidW.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneUpDown.ValueChanged -= REyelidRot2;
            BoneUpDown2.ValueChanged -= REyelidRot2;
            BoneUpDown3.ValueChanged -= REyelidRot2;
        }

        private void REyelidButton_Checked(object sender, RoutedEventArgs e)
        {
            //Disable Other Selections
            HeadButton.IsChecked = false;
            NoseButton.IsChecked = false;
            NostrilsButton.IsChecked = false;
            ChinButton.IsChecked = false;
            LOutEyebrowButton.IsChecked = false;
            ROutEyebrowButton.IsChecked = false;
            LInEyebrowButton.IsChecked = false;
            RInEyebrowButton.IsChecked = false;
            LEyeButton.IsChecked = false;
            REyeButton.IsChecked = false;
            LEyelidButton.IsChecked = false;
            LLowEyelidButton.IsChecked = false;
            RLowEyelidButton.IsChecked = false;
            LEarButton.IsChecked = false;
            REarButton.IsChecked = false;
            LCheekButton.IsChecked = false;
            RCheekButton.IsChecked = false;
            LMouthButton.IsChecked = false;
            RMouthButton.IsChecked = false;
            LUpLipButton.IsChecked = false;
            RUpLipButton.IsChecked = false;
            LLowLipButton.IsChecked = false;
            RLowLipButton.IsChecked = false;
            NeckButton.IsChecked = false;
            SternumButton.IsChecked = false;
            TorsoButton.IsChecked = false;
            WaistButton.IsChecked = false;
            LShoulderButton.IsChecked = false;
            RShoulderButton.IsChecked = false;
            LClavicleButton.IsChecked = false;
            RClavicleButton.IsChecked = false;
            LBreastButton.IsChecked = false;
            RBreastButton.IsChecked = false;
            LArmButton.IsChecked = false;
            RArmButton.IsChecked = false;
            LElbowButton.IsChecked = false;
            RElbowButton.IsChecked = false;
            LForearmButton.IsChecked = false;
            RForearmButton.IsChecked = false;
            LWristButton.IsChecked = false;
            RWristButton.IsChecked = false;
            LHandButton.IsChecked = false;
            RHandButton.IsChecked = false;
            LThumbButton.IsChecked = false;
            RThumbButton.IsChecked = false;
            LThumb2Button.IsChecked = false;
            RThumb2Button.IsChecked = false;
            LIndexButton.IsChecked = false;
            RIndexButton.IsChecked = false;
            LIndex2Button.IsChecked = false;
            RIndex2Button.IsChecked = false;
            LMiddleButton.IsChecked = false;
            RMiddleButton.IsChecked = false;
            LMiddle2Button.IsChecked = false;
            RMiddle2Button.IsChecked = false;
            LRingButton.IsChecked = false;
            RRingButton.IsChecked = false;
            LRing2Button.IsChecked = false;
            RRing2Button.IsChecked = false;
            LPinkyButton.IsChecked = false;
            RPinkyButton.IsChecked = false;
            LPinky2Button.IsChecked = false;
            RPinky2Button.IsChecked = false;
            PelvisButton.IsChecked = false;
            TailButton.IsChecked = false;
            Tail2Button.IsChecked = false;
            Tail3Button.IsChecked = false;
            Tail4Button.IsChecked = false;
            LThighButton.IsChecked = false;
            RThighButton.IsChecked = false;
            LKneeButton.IsChecked = false;
            RKneeButton.IsChecked = false;
            LCalfButton.IsChecked = false;
            RCalfButton.IsChecked = false;
            LFootButton.IsChecked = false;
            RFootButton.IsChecked = false;
            LToesButton.IsChecked = false;
            RToesButton.IsChecked = false;
            LEarringButton.IsChecked = false;
            REarringButton.IsChecked = false;
            LEarring2Button.IsChecked = false;
            REarring2Button.IsChecked = false;

            //Load Current Values for Slider
            CharacterDetails.REyelidCheck = true;
        }
        private void REyelidButton_Unchecked(object sender, RoutedEventArgs e)
        {
            CharacterDetails.REyelidRotate = false;
        }
        #endregion

        #region LLowEyelid
        private void LLowEyelidRot(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.LLowEyelidX.value = (float)quat.X;
            CharacterDetails.LLowEyelidY.value = (float)quat.Y;
            CharacterDetails.LLowEyelidZ.value = (float)quat.Z;
            CharacterDetails.LLowEyelidW.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneSlider.ValueChanged -= LLowEyelidRot;
            BoneSlider2.ValueChanged -= LLowEyelidRot;
            BoneSlider3.ValueChanged -= LLowEyelidRot;
        }

        private void LLowEyelidRot2(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.LLowEyelidX.value = (float)quat.X;
            CharacterDetails.LLowEyelidY.value = (float)quat.Y;
            CharacterDetails.LLowEyelidZ.value = (float)quat.Z;
            CharacterDetails.LLowEyelidW.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneUpDown.ValueChanged -= LLowEyelidRot2;
            BoneUpDown2.ValueChanged -= LLowEyelidRot2;
            BoneUpDown3.ValueChanged -= LLowEyelidRot2;
        }

        private void LLowEyelidButton_Checked(object sender, RoutedEventArgs e)
        {
            //Disable Other Selections
            HeadButton.IsChecked = false;
            NoseButton.IsChecked = false;
            NostrilsButton.IsChecked = false;
            ChinButton.IsChecked = false;
            LOutEyebrowButton.IsChecked = false;
            ROutEyebrowButton.IsChecked = false;
            LInEyebrowButton.IsChecked = false;
            RInEyebrowButton.IsChecked = false;
            LEyeButton.IsChecked = false;
            REyeButton.IsChecked = false;
            LEyelidButton.IsChecked = false;
            REyelidButton.IsChecked = false;
            RLowEyelidButton.IsChecked = false;
            LEarButton.IsChecked = false;
            REarButton.IsChecked = false;
            LCheekButton.IsChecked = false;
            RCheekButton.IsChecked = false;
            LMouthButton.IsChecked = false;
            RMouthButton.IsChecked = false;
            LUpLipButton.IsChecked = false;
            RUpLipButton.IsChecked = false;
            LLowLipButton.IsChecked = false;
            RLowLipButton.IsChecked = false;
            NeckButton.IsChecked = false;
            SternumButton.IsChecked = false;
            TorsoButton.IsChecked = false;
            WaistButton.IsChecked = false;
            LShoulderButton.IsChecked = false;
            RShoulderButton.IsChecked = false;
            LClavicleButton.IsChecked = false;
            RClavicleButton.IsChecked = false;
            LBreastButton.IsChecked = false;
            RBreastButton.IsChecked = false;
            LArmButton.IsChecked = false;
            RArmButton.IsChecked = false;
            LElbowButton.IsChecked = false;
            RElbowButton.IsChecked = false;
            LForearmButton.IsChecked = false;
            RForearmButton.IsChecked = false;
            LWristButton.IsChecked = false;
            RWristButton.IsChecked = false;
            LHandButton.IsChecked = false;
            RHandButton.IsChecked = false;
            LThumbButton.IsChecked = false;
            RThumbButton.IsChecked = false;
            LThumb2Button.IsChecked = false;
            RThumb2Button.IsChecked = false;
            LIndexButton.IsChecked = false;
            RIndexButton.IsChecked = false;
            LIndex2Button.IsChecked = false;
            RIndex2Button.IsChecked = false;
            LMiddleButton.IsChecked = false;
            RMiddleButton.IsChecked = false;
            LMiddle2Button.IsChecked = false;
            RMiddle2Button.IsChecked = false;
            LRingButton.IsChecked = false;
            RRingButton.IsChecked = false;
            LRing2Button.IsChecked = false;
            RRing2Button.IsChecked = false;
            LPinkyButton.IsChecked = false;
            RPinkyButton.IsChecked = false;
            LPinky2Button.IsChecked = false;
            RPinky2Button.IsChecked = false;
            PelvisButton.IsChecked = false;
            TailButton.IsChecked = false;
            Tail2Button.IsChecked = false;
            Tail3Button.IsChecked = false;
            Tail4Button.IsChecked = false;
            LThighButton.IsChecked = false;
            RThighButton.IsChecked = false;
            LKneeButton.IsChecked = false;
            RKneeButton.IsChecked = false;
            LCalfButton.IsChecked = false;
            RCalfButton.IsChecked = false;
            LFootButton.IsChecked = false;
            RFootButton.IsChecked = false;
            LToesButton.IsChecked = false;
            RToesButton.IsChecked = false;
            LEarringButton.IsChecked = false;
            REarringButton.IsChecked = false;
            LEarring2Button.IsChecked = false;
            REarring2Button.IsChecked = false;

            //Load Current Values for Slider
            CharacterDetails.LLowEyelidCheck = true;
        }
        private void LLowEyelidButton_Unchecked(object sender, RoutedEventArgs e)
        {
            CharacterDetails.LLowEyelidRotate = false;
        }
        #endregion

        #region RLowEyelid
        private void RLowEyelidRot(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.RLowEyelidX.value = (float)quat.X;
            CharacterDetails.RLowEyelidY.value = (float)quat.Y;
            CharacterDetails.RLowEyelidZ.value = (float)quat.Z;
            CharacterDetails.RLowEyelidW.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneSlider.ValueChanged -= RLowEyelidRot;
            BoneSlider2.ValueChanged -= RLowEyelidRot;
            BoneSlider3.ValueChanged -= RLowEyelidRot;
        }

        private void RLowEyelidRot2(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.RLowEyelidX.value = (float)quat.X;
            CharacterDetails.RLowEyelidY.value = (float)quat.Y;
            CharacterDetails.RLowEyelidZ.value = (float)quat.Z;
            CharacterDetails.RLowEyelidW.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneUpDown.ValueChanged -= RLowEyelidRot2;
            BoneUpDown2.ValueChanged -= RLowEyelidRot2;
            BoneUpDown3.ValueChanged -= RLowEyelidRot2;
        }

        private void RLowEyelidButton_Checked(object sender, RoutedEventArgs e)
        {
            //Disable Other Selections
            HeadButton.IsChecked = false;
            NoseButton.IsChecked = false;
            NostrilsButton.IsChecked = false;
            ChinButton.IsChecked = false;
            LOutEyebrowButton.IsChecked = false;
            ROutEyebrowButton.IsChecked = false;
            LInEyebrowButton.IsChecked = false;
            RInEyebrowButton.IsChecked = false;
            LEyeButton.IsChecked = false;
            REyeButton.IsChecked = false;
            LEyelidButton.IsChecked = false;
            REyelidButton.IsChecked = false;
            LLowEyelidButton.IsChecked = false;
            LEarButton.IsChecked = false;
            REarButton.IsChecked = false;
            LCheekButton.IsChecked = false;
            RCheekButton.IsChecked = false;
            LMouthButton.IsChecked = false;
            RMouthButton.IsChecked = false;
            LUpLipButton.IsChecked = false;
            RUpLipButton.IsChecked = false;
            LLowLipButton.IsChecked = false;
            RLowLipButton.IsChecked = false;
            NeckButton.IsChecked = false;
            SternumButton.IsChecked = false;
            TorsoButton.IsChecked = false;
            WaistButton.IsChecked = false;
            LShoulderButton.IsChecked = false;
            RShoulderButton.IsChecked = false;
            LClavicleButton.IsChecked = false;
            RClavicleButton.IsChecked = false;
            LBreastButton.IsChecked = false;
            RBreastButton.IsChecked = false;
            LArmButton.IsChecked = false;
            RArmButton.IsChecked = false;
            LElbowButton.IsChecked = false;
            RElbowButton.IsChecked = false;
            LForearmButton.IsChecked = false;
            RForearmButton.IsChecked = false;
            LWristButton.IsChecked = false;
            RWristButton.IsChecked = false;
            LHandButton.IsChecked = false;
            RHandButton.IsChecked = false;
            LThumbButton.IsChecked = false;
            RThumbButton.IsChecked = false;
            LThumb2Button.IsChecked = false;
            RThumb2Button.IsChecked = false;
            LIndexButton.IsChecked = false;
            RIndexButton.IsChecked = false;
            LIndex2Button.IsChecked = false;
            RIndex2Button.IsChecked = false;
            LMiddleButton.IsChecked = false;
            RMiddleButton.IsChecked = false;
            LMiddle2Button.IsChecked = false;
            RMiddle2Button.IsChecked = false;
            LRingButton.IsChecked = false;
            RRingButton.IsChecked = false;
            LRing2Button.IsChecked = false;
            RRing2Button.IsChecked = false;
            LPinkyButton.IsChecked = false;
            RPinkyButton.IsChecked = false;
            LPinky2Button.IsChecked = false;
            RPinky2Button.IsChecked = false;
            PelvisButton.IsChecked = false;
            TailButton.IsChecked = false;
            Tail2Button.IsChecked = false;
            Tail3Button.IsChecked = false;
            Tail4Button.IsChecked = false;
            LThighButton.IsChecked = false;
            RThighButton.IsChecked = false;
            LKneeButton.IsChecked = false;
            RKneeButton.IsChecked = false;
            LCalfButton.IsChecked = false;
            RCalfButton.IsChecked = false;
            LFootButton.IsChecked = false;
            RFootButton.IsChecked = false;
            LToesButton.IsChecked = false;
            RToesButton.IsChecked = false;
            LEarringButton.IsChecked = false;
            REarringButton.IsChecked = false;
            LEarring2Button.IsChecked = false;
            REarring2Button.IsChecked = false;

            //Load Current Values for Slider
            CharacterDetails.RLowEyelidCheck = true;
        }
        private void RLowEyelidButton_Unchecked(object sender, RoutedEventArgs e)
        {
            CharacterDetails.RLowEyelidRotate = false;
        }
        #endregion

        #region LEar
        private void LEarRot(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.LEarX.value = (float)quat.X;
            CharacterDetails.LEarY.value = (float)quat.Y;
            CharacterDetails.LEarZ.value = (float)quat.Z;
            CharacterDetails.LEarW.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneSlider.ValueChanged -= LEarRot;
            BoneSlider2.ValueChanged -= LEarRot;
            BoneSlider3.ValueChanged -= LEarRot;
        }

        private void LEarRot2(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.LEarX.value = (float)quat.X;
            CharacterDetails.LEarY.value = (float)quat.Y;
            CharacterDetails.LEarZ.value = (float)quat.Z;
            CharacterDetails.LEarW.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneUpDown.ValueChanged -= LEarRot2;
            BoneUpDown2.ValueChanged -= LEarRot2;
            BoneUpDown3.ValueChanged -= LEarRot2;
        }

        private void LEarButton_Checked(object sender, RoutedEventArgs e)
        {
            //Disable Other Selections
            HeadButton.IsChecked = false;
            NoseButton.IsChecked = false;
            NostrilsButton.IsChecked = false;
            ChinButton.IsChecked = false;
            LOutEyebrowButton.IsChecked = false;
            ROutEyebrowButton.IsChecked = false;
            LInEyebrowButton.IsChecked = false;
            RInEyebrowButton.IsChecked = false;
            LEyeButton.IsChecked = false;
            REyeButton.IsChecked = false;
            LEyelidButton.IsChecked = false;
            REyelidButton.IsChecked = false;
            LLowEyelidButton.IsChecked = false;
            RLowEyelidButton.IsChecked = false;
            REarButton.IsChecked = false;
            LCheekButton.IsChecked = false;
            RCheekButton.IsChecked = false;
            LMouthButton.IsChecked = false;
            RMouthButton.IsChecked = false;
            LUpLipButton.IsChecked = false;
            RUpLipButton.IsChecked = false;
            LLowLipButton.IsChecked = false;
            RLowLipButton.IsChecked = false;
            NeckButton.IsChecked = false;
            SternumButton.IsChecked = false;
            TorsoButton.IsChecked = false;
            WaistButton.IsChecked = false;
            LShoulderButton.IsChecked = false;
            RShoulderButton.IsChecked = false;
            LClavicleButton.IsChecked = false;
            RClavicleButton.IsChecked = false;
            LBreastButton.IsChecked = false;
            RBreastButton.IsChecked = false;
            LArmButton.IsChecked = false;
            RArmButton.IsChecked = false;
            LElbowButton.IsChecked = false;
            RElbowButton.IsChecked = false;
            LForearmButton.IsChecked = false;
            RForearmButton.IsChecked = false;
            LWristButton.IsChecked = false;
            RWristButton.IsChecked = false;
            LHandButton.IsChecked = false;
            RHandButton.IsChecked = false;
            LThumbButton.IsChecked = false;
            RThumbButton.IsChecked = false;
            LThumb2Button.IsChecked = false;
            RThumb2Button.IsChecked = false;
            LIndexButton.IsChecked = false;
            RIndexButton.IsChecked = false;
            LIndex2Button.IsChecked = false;
            RIndex2Button.IsChecked = false;
            LMiddleButton.IsChecked = false;
            RMiddleButton.IsChecked = false;
            LMiddle2Button.IsChecked = false;
            RMiddle2Button.IsChecked = false;
            LRingButton.IsChecked = false;
            RRingButton.IsChecked = false;
            LRing2Button.IsChecked = false;
            RRing2Button.IsChecked = false;
            LPinkyButton.IsChecked = false;
            RPinkyButton.IsChecked = false;
            LPinky2Button.IsChecked = false;
            RPinky2Button.IsChecked = false;
            PelvisButton.IsChecked = false;
            TailButton.IsChecked = false;
            Tail2Button.IsChecked = false;
            Tail3Button.IsChecked = false;
            Tail4Button.IsChecked = false;
            LThighButton.IsChecked = false;
            RThighButton.IsChecked = false;
            LKneeButton.IsChecked = false;
            RKneeButton.IsChecked = false;
            LCalfButton.IsChecked = false;
            RCalfButton.IsChecked = false;
            LFootButton.IsChecked = false;
            RFootButton.IsChecked = false;
            LToesButton.IsChecked = false;
            RToesButton.IsChecked = false;
            LEarringButton.IsChecked = false;
            REarringButton.IsChecked = false;
            LEarring2Button.IsChecked = false;
            REarring2Button.IsChecked = false;

            //Load Current Values for Slider
            CharacterDetails.LEarCheck = true;
        }
        private void LEarButton_Unchecked(object sender, RoutedEventArgs e)
        {
            CharacterDetails.LEarRotate = false;
        }
        #endregion

        #region REar
        private void REarRot(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.REarX.value = (float)quat.X;
            CharacterDetails.REarY.value = (float)quat.Y;
            CharacterDetails.REarZ.value = (float)quat.Z;
            CharacterDetails.REarW.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneSlider.ValueChanged -= REarRot;
            BoneSlider2.ValueChanged -= REarRot;
            BoneSlider3.ValueChanged -= REarRot;
        }

        private void REarRot2(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.REarX.value = (float)quat.X;
            CharacterDetails.REarY.value = (float)quat.Y;
            CharacterDetails.REarZ.value = (float)quat.Z;
            CharacterDetails.REarW.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneUpDown.ValueChanged -= REarRot2;
            BoneUpDown2.ValueChanged -= REarRot2;
            BoneUpDown3.ValueChanged -= REarRot2;
        }

        private void REarButton_Checked(object sender, RoutedEventArgs e)
        {
            //Disable Other Selections
            HeadButton.IsChecked = false;
            NoseButton.IsChecked = false;
            NostrilsButton.IsChecked = false;
            ChinButton.IsChecked = false;
            LOutEyebrowButton.IsChecked = false;
            ROutEyebrowButton.IsChecked = false;
            LInEyebrowButton.IsChecked = false;
            RInEyebrowButton.IsChecked = false;
            LEyeButton.IsChecked = false;
            REyeButton.IsChecked = false;
            LEyelidButton.IsChecked = false;
            REyelidButton.IsChecked = false;
            LLowEyelidButton.IsChecked = false;
            RLowEyelidButton.IsChecked = false;
            LEarButton.IsChecked = false;
            LCheekButton.IsChecked = false;
            RCheekButton.IsChecked = false;
            LMouthButton.IsChecked = false;
            RMouthButton.IsChecked = false;
            LUpLipButton.IsChecked = false;
            RUpLipButton.IsChecked = false;
            LLowLipButton.IsChecked = false;
            RLowLipButton.IsChecked = false;
            NeckButton.IsChecked = false;
            SternumButton.IsChecked = false;
            TorsoButton.IsChecked = false;
            WaistButton.IsChecked = false;
            LShoulderButton.IsChecked = false;
            RShoulderButton.IsChecked = false;
            LClavicleButton.IsChecked = false;
            RClavicleButton.IsChecked = false;
            LBreastButton.IsChecked = false;
            RBreastButton.IsChecked = false;
            LArmButton.IsChecked = false;
            RArmButton.IsChecked = false;
            LElbowButton.IsChecked = false;
            RElbowButton.IsChecked = false;
            LForearmButton.IsChecked = false;
            RForearmButton.IsChecked = false;
            LWristButton.IsChecked = false;
            RWristButton.IsChecked = false;
            LHandButton.IsChecked = false;
            RHandButton.IsChecked = false;
            LThumbButton.IsChecked = false;
            RThumbButton.IsChecked = false;
            LThumb2Button.IsChecked = false;
            RThumb2Button.IsChecked = false;
            LIndexButton.IsChecked = false;
            RIndexButton.IsChecked = false;
            LIndex2Button.IsChecked = false;
            RIndex2Button.IsChecked = false;
            LMiddleButton.IsChecked = false;
            RMiddleButton.IsChecked = false;
            LMiddle2Button.IsChecked = false;
            RMiddle2Button.IsChecked = false;
            LRingButton.IsChecked = false;
            RRingButton.IsChecked = false;
            LRing2Button.IsChecked = false;
            RRing2Button.IsChecked = false;
            LPinkyButton.IsChecked = false;
            RPinkyButton.IsChecked = false;
            LPinky2Button.IsChecked = false;
            RPinky2Button.IsChecked = false;
            PelvisButton.IsChecked = false;
            TailButton.IsChecked = false;
            Tail2Button.IsChecked = false;
            Tail3Button.IsChecked = false;
            Tail4Button.IsChecked = false;
            LThighButton.IsChecked = false;
            RThighButton.IsChecked = false;
            LKneeButton.IsChecked = false;
            RKneeButton.IsChecked = false;
            LCalfButton.IsChecked = false;
            RCalfButton.IsChecked = false;
            LFootButton.IsChecked = false;
            RFootButton.IsChecked = false;
            LToesButton.IsChecked = false;
            RToesButton.IsChecked = false;
            LEarringButton.IsChecked = false;
            REarringButton.IsChecked = false;
            LEarring2Button.IsChecked = false;
            REarring2Button.IsChecked = false;

            //Load Current Values for Slider
            CharacterDetails.REarCheck = true;
        }
        private void REarButton_Unchecked(object sender, RoutedEventArgs e)
        {
            CharacterDetails.REarRotate = false;
        }
        #endregion

        #region LCheek
        private void LCheekRot(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.LCheekX.value = (float)quat.X;
            CharacterDetails.LCheekY.value = (float)quat.Y;
            CharacterDetails.LCheekZ.value = (float)quat.Z;
            CharacterDetails.LCheekW.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneSlider.ValueChanged -= LCheekRot;
            BoneSlider2.ValueChanged -= LCheekRot;
            BoneSlider3.ValueChanged -= LCheekRot;
        }

        private void LCheekRot2(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.LCheekX.value = (float)quat.X;
            CharacterDetails.LCheekY.value = (float)quat.Y;
            CharacterDetails.LCheekZ.value = (float)quat.Z;
            CharacterDetails.LCheekW.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneUpDown.ValueChanged -= LCheekRot2;
            BoneUpDown2.ValueChanged -= LCheekRot2;
            BoneUpDown3.ValueChanged -= LCheekRot2;
        }

        private void LCheekButton_Checked(object sender, RoutedEventArgs e)
        {
            //Disable Other Selections
            HeadButton.IsChecked = false;
            NoseButton.IsChecked = false;
            NostrilsButton.IsChecked = false;
            ChinButton.IsChecked = false;
            LOutEyebrowButton.IsChecked = false;
            ROutEyebrowButton.IsChecked = false;
            LInEyebrowButton.IsChecked = false;
            RInEyebrowButton.IsChecked = false;
            LEyeButton.IsChecked = false;
            REyeButton.IsChecked = false;
            LEyelidButton.IsChecked = false;
            REyelidButton.IsChecked = false;
            LLowEyelidButton.IsChecked = false;
            RLowEyelidButton.IsChecked = false;
            LEarButton.IsChecked = false;
            REarButton.IsChecked = false;
            RCheekButton.IsChecked = false;
            LMouthButton.IsChecked = false;
            RMouthButton.IsChecked = false;
            LUpLipButton.IsChecked = false;
            RUpLipButton.IsChecked = false;
            LLowLipButton.IsChecked = false;
            RLowLipButton.IsChecked = false;
            NeckButton.IsChecked = false;
            SternumButton.IsChecked = false;
            TorsoButton.IsChecked = false;
            WaistButton.IsChecked = false;
            LShoulderButton.IsChecked = false;
            RShoulderButton.IsChecked = false;
            LClavicleButton.IsChecked = false;
            RClavicleButton.IsChecked = false;
            LBreastButton.IsChecked = false;
            RBreastButton.IsChecked = false;
            LArmButton.IsChecked = false;
            RArmButton.IsChecked = false;
            LElbowButton.IsChecked = false;
            RElbowButton.IsChecked = false;
            LForearmButton.IsChecked = false;
            RForearmButton.IsChecked = false;
            LWristButton.IsChecked = false;
            RWristButton.IsChecked = false;
            LHandButton.IsChecked = false;
            RHandButton.IsChecked = false;
            LThumbButton.IsChecked = false;
            RThumbButton.IsChecked = false;
            LThumb2Button.IsChecked = false;
            RThumb2Button.IsChecked = false;
            LIndexButton.IsChecked = false;
            RIndexButton.IsChecked = false;
            LIndex2Button.IsChecked = false;
            RIndex2Button.IsChecked = false;
            LMiddleButton.IsChecked = false;
            RMiddleButton.IsChecked = false;
            LMiddle2Button.IsChecked = false;
            RMiddle2Button.IsChecked = false;
            LRingButton.IsChecked = false;
            RRingButton.IsChecked = false;
            LRing2Button.IsChecked = false;
            RRing2Button.IsChecked = false;
            LPinkyButton.IsChecked = false;
            RPinkyButton.IsChecked = false;
            LPinky2Button.IsChecked = false;
            RPinky2Button.IsChecked = false;
            PelvisButton.IsChecked = false;
            TailButton.IsChecked = false;
            Tail2Button.IsChecked = false;
            Tail3Button.IsChecked = false;
            Tail4Button.IsChecked = false;
            LThighButton.IsChecked = false;
            RThighButton.IsChecked = false;
            LKneeButton.IsChecked = false;
            RKneeButton.IsChecked = false;
            LCalfButton.IsChecked = false;
            RCalfButton.IsChecked = false;
            LFootButton.IsChecked = false;
            RFootButton.IsChecked = false;
            LToesButton.IsChecked = false;
            RToesButton.IsChecked = false;
            LEarringButton.IsChecked = false;
            REarringButton.IsChecked = false;
            LEarring2Button.IsChecked = false;
            REarring2Button.IsChecked = false;

            //Load Current Values for Slider
            CharacterDetails.LCheekCheck = true;
        }
        private void LCheekButton_Unchecked(object sender, RoutedEventArgs e)
        {
            CharacterDetails.LCheekRotate = false;
        }
        #endregion

        #region RCheek
        private void RCheekRot(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.RCheekX.value = (float)quat.X;
            CharacterDetails.RCheekY.value = (float)quat.Y;
            CharacterDetails.RCheekZ.value = (float)quat.Z;
            CharacterDetails.RCheekW.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneSlider.ValueChanged -= RCheekRot;
            BoneSlider2.ValueChanged -= RCheekRot;
            BoneSlider3.ValueChanged -= RCheekRot;
        }

        private void RCheekRot2(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.RCheekX.value = (float)quat.X;
            CharacterDetails.RCheekY.value = (float)quat.Y;
            CharacterDetails.RCheekZ.value = (float)quat.Z;
            CharacterDetails.RCheekW.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneUpDown.ValueChanged -= RCheekRot2;
            BoneUpDown2.ValueChanged -= RCheekRot2;
            BoneUpDown3.ValueChanged -= RCheekRot2;
        }

        private void RCheekButton_Checked(object sender, RoutedEventArgs e)
        {
            //Disable Other Selections
            HeadButton.IsChecked = false;
            NoseButton.IsChecked = false;
            NostrilsButton.IsChecked = false;
            ChinButton.IsChecked = false;
            LOutEyebrowButton.IsChecked = false;
            ROutEyebrowButton.IsChecked = false;
            LInEyebrowButton.IsChecked = false;
            RInEyebrowButton.IsChecked = false;
            LEyeButton.IsChecked = false;
            REyeButton.IsChecked = false;
            LEyelidButton.IsChecked = false;
            REyelidButton.IsChecked = false;
            LLowEyelidButton.IsChecked = false;
            RLowEyelidButton.IsChecked = false;
            LEarButton.IsChecked = false;
            REarButton.IsChecked = false;
            LCheekButton.IsChecked = false;
            LMouthButton.IsChecked = false;
            RMouthButton.IsChecked = false;
            LUpLipButton.IsChecked = false;
            RUpLipButton.IsChecked = false;
            LLowLipButton.IsChecked = false;
            RLowLipButton.IsChecked = false;
            NeckButton.IsChecked = false;
            SternumButton.IsChecked = false;
            TorsoButton.IsChecked = false;
            WaistButton.IsChecked = false;
            LShoulderButton.IsChecked = false;
            RShoulderButton.IsChecked = false;
            LClavicleButton.IsChecked = false;
            RClavicleButton.IsChecked = false;
            LBreastButton.IsChecked = false;
            RBreastButton.IsChecked = false;
            LArmButton.IsChecked = false;
            RArmButton.IsChecked = false;
            LElbowButton.IsChecked = false;
            RElbowButton.IsChecked = false;
            LForearmButton.IsChecked = false;
            RForearmButton.IsChecked = false;
            LWristButton.IsChecked = false;
            RWristButton.IsChecked = false;
            LHandButton.IsChecked = false;
            RHandButton.IsChecked = false;
            LThumbButton.IsChecked = false;
            RThumbButton.IsChecked = false;
            LThumb2Button.IsChecked = false;
            RThumb2Button.IsChecked = false;
            LIndexButton.IsChecked = false;
            RIndexButton.IsChecked = false;
            LIndex2Button.IsChecked = false;
            RIndex2Button.IsChecked = false;
            LMiddleButton.IsChecked = false;
            RMiddleButton.IsChecked = false;
            LMiddle2Button.IsChecked = false;
            RMiddle2Button.IsChecked = false;
            LRingButton.IsChecked = false;
            RRingButton.IsChecked = false;
            LRing2Button.IsChecked = false;
            RRing2Button.IsChecked = false;
            LPinkyButton.IsChecked = false;
            RPinkyButton.IsChecked = false;
            LPinky2Button.IsChecked = false;
            RPinky2Button.IsChecked = false;
            PelvisButton.IsChecked = false;
            TailButton.IsChecked = false;
            Tail2Button.IsChecked = false;
            Tail3Button.IsChecked = false;
            Tail4Button.IsChecked = false;
            LThighButton.IsChecked = false;
            RThighButton.IsChecked = false;
            LKneeButton.IsChecked = false;
            RKneeButton.IsChecked = false;
            LCalfButton.IsChecked = false;
            RCalfButton.IsChecked = false;
            LFootButton.IsChecked = false;
            RFootButton.IsChecked = false;
            LToesButton.IsChecked = false;
            RToesButton.IsChecked = false;
            LEarringButton.IsChecked = false;
            REarringButton.IsChecked = false;
            LEarring2Button.IsChecked = false;
            REarring2Button.IsChecked = false;

            //Load Current Values for Slider
            CharacterDetails.RCheekCheck = true;
        }
        private void RCheekButton_Unchecked(object sender, RoutedEventArgs e)
        {
            CharacterDetails.RCheekRotate = false;
        }
        #endregion

        #region LMouth
        private void LMouthRot(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.LMouthX.value = (float)quat.X;
            CharacterDetails.LMouthY.value = (float)quat.Y;
            CharacterDetails.LMouthZ.value = (float)quat.Z;
            CharacterDetails.LMouthW.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneSlider.ValueChanged -= LMouthRot;
            BoneSlider2.ValueChanged -= LMouthRot;
            BoneSlider3.ValueChanged -= LMouthRot;
        }

        private void LMouthRot2(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.LMouthX.value = (float)quat.X;
            CharacterDetails.LMouthY.value = (float)quat.Y;
            CharacterDetails.LMouthZ.value = (float)quat.Z;
            CharacterDetails.LMouthW.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneUpDown.ValueChanged -= LMouthRot2;
            BoneUpDown2.ValueChanged -= LMouthRot2;
            BoneUpDown3.ValueChanged -= LMouthRot2;
        }

        private void LMouthButton_Checked(object sender, RoutedEventArgs e)
        {
            //Disable Other Selections
            HeadButton.IsChecked = false;
            NoseButton.IsChecked = false;
            NostrilsButton.IsChecked = false;
            ChinButton.IsChecked = false;
            LOutEyebrowButton.IsChecked = false;
            ROutEyebrowButton.IsChecked = false;
            LInEyebrowButton.IsChecked = false;
            RInEyebrowButton.IsChecked = false;
            LEyeButton.IsChecked = false;
            REyeButton.IsChecked = false;
            LEyelidButton.IsChecked = false;
            REyelidButton.IsChecked = false;
            LLowEyelidButton.IsChecked = false;
            RLowEyelidButton.IsChecked = false;
            LEarButton.IsChecked = false;
            REarButton.IsChecked = false;
            LCheekButton.IsChecked = false;
            RCheekButton.IsChecked = false;
            RMouthButton.IsChecked = false;
            LUpLipButton.IsChecked = false;
            RUpLipButton.IsChecked = false;
            LLowLipButton.IsChecked = false;
            RLowLipButton.IsChecked = false;
            NeckButton.IsChecked = false;
            SternumButton.IsChecked = false;
            TorsoButton.IsChecked = false;
            WaistButton.IsChecked = false;
            LShoulderButton.IsChecked = false;
            RShoulderButton.IsChecked = false;
            LClavicleButton.IsChecked = false;
            RClavicleButton.IsChecked = false;
            LBreastButton.IsChecked = false;
            RBreastButton.IsChecked = false;
            LArmButton.IsChecked = false;
            RArmButton.IsChecked = false;
            LElbowButton.IsChecked = false;
            RElbowButton.IsChecked = false;
            LForearmButton.IsChecked = false;
            RForearmButton.IsChecked = false;
            LWristButton.IsChecked = false;
            RWristButton.IsChecked = false;
            LHandButton.IsChecked = false;
            RHandButton.IsChecked = false;
            LThumbButton.IsChecked = false;
            RThumbButton.IsChecked = false;
            LThumb2Button.IsChecked = false;
            RThumb2Button.IsChecked = false;
            LIndexButton.IsChecked = false;
            RIndexButton.IsChecked = false;
            LIndex2Button.IsChecked = false;
            RIndex2Button.IsChecked = false;
            LMiddleButton.IsChecked = false;
            RMiddleButton.IsChecked = false;
            LMiddle2Button.IsChecked = false;
            RMiddle2Button.IsChecked = false;
            LRingButton.IsChecked = false;
            RRingButton.IsChecked = false;
            LRing2Button.IsChecked = false;
            RRing2Button.IsChecked = false;
            LPinkyButton.IsChecked = false;
            RPinkyButton.IsChecked = false;
            LPinky2Button.IsChecked = false;
            RPinky2Button.IsChecked = false;
            PelvisButton.IsChecked = false;
            TailButton.IsChecked = false;
            Tail2Button.IsChecked = false;
            Tail3Button.IsChecked = false;
            Tail4Button.IsChecked = false;
            LThighButton.IsChecked = false;
            RThighButton.IsChecked = false;
            LKneeButton.IsChecked = false;
            RKneeButton.IsChecked = false;
            LCalfButton.IsChecked = false;
            RCalfButton.IsChecked = false;
            LFootButton.IsChecked = false;
            RFootButton.IsChecked = false;
            LToesButton.IsChecked = false;
            RToesButton.IsChecked = false;
            LEarringButton.IsChecked = false;
            REarringButton.IsChecked = false;
            LEarring2Button.IsChecked = false;
            REarring2Button.IsChecked = false;

            //Load Current Values for Slider
            CharacterDetails.LMouthCheck = true;
        }
        private void LMouthButton_Unchecked(object sender, RoutedEventArgs e)
        {
            CharacterDetails.LMouthRotate = false;
        }
        #endregion

        #region RMouth
        private void RMouthRot(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.RMouthX.value = (float)quat.X;
            CharacterDetails.RMouthY.value = (float)quat.Y;
            CharacterDetails.RMouthZ.value = (float)quat.Z;
            CharacterDetails.RMouthW.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneSlider.ValueChanged -= RMouthRot;
            BoneSlider2.ValueChanged -= RMouthRot;
            BoneSlider3.ValueChanged -= RMouthRot;
        }

        private void RMouthRot2(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.RMouthX.value = (float)quat.X;
            CharacterDetails.RMouthY.value = (float)quat.Y;
            CharacterDetails.RMouthZ.value = (float)quat.Z;
            CharacterDetails.RMouthW.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneUpDown.ValueChanged -= RMouthRot2;
            BoneUpDown2.ValueChanged -= RMouthRot2;
            BoneUpDown3.ValueChanged -= RMouthRot2;
        }

        private void RMouthButton_Checked(object sender, RoutedEventArgs e)
        {
            //Disable Other Selections
            HeadButton.IsChecked = false;
            NoseButton.IsChecked = false;
            NostrilsButton.IsChecked = false;
            ChinButton.IsChecked = false;
            LOutEyebrowButton.IsChecked = false;
            ROutEyebrowButton.IsChecked = false;
            LInEyebrowButton.IsChecked = false;
            RInEyebrowButton.IsChecked = false;
            LEyeButton.IsChecked = false;
            REyeButton.IsChecked = false;
            LEyelidButton.IsChecked = false;
            REyelidButton.IsChecked = false;
            LLowEyelidButton.IsChecked = false;
            RLowEyelidButton.IsChecked = false;
            LEarButton.IsChecked = false;
            REarButton.IsChecked = false;
            LCheekButton.IsChecked = false;
            RCheekButton.IsChecked = false;
            LMouthButton.IsChecked = false;
            LUpLipButton.IsChecked = false;
            RUpLipButton.IsChecked = false;
            LLowLipButton.IsChecked = false;
            RLowLipButton.IsChecked = false;
            NeckButton.IsChecked = false;
            SternumButton.IsChecked = false;
            TorsoButton.IsChecked = false;
            WaistButton.IsChecked = false;
            LShoulderButton.IsChecked = false;
            RShoulderButton.IsChecked = false;
            LClavicleButton.IsChecked = false;
            RClavicleButton.IsChecked = false;
            LBreastButton.IsChecked = false;
            RBreastButton.IsChecked = false;
            LArmButton.IsChecked = false;
            RArmButton.IsChecked = false;
            LElbowButton.IsChecked = false;
            RElbowButton.IsChecked = false;
            LForearmButton.IsChecked = false;
            RForearmButton.IsChecked = false;
            LWristButton.IsChecked = false;
            RWristButton.IsChecked = false;
            LHandButton.IsChecked = false;
            RHandButton.IsChecked = false;
            LThumbButton.IsChecked = false;
            RThumbButton.IsChecked = false;
            LThumb2Button.IsChecked = false;
            RThumb2Button.IsChecked = false;
            LIndexButton.IsChecked = false;
            RIndexButton.IsChecked = false;
            LIndex2Button.IsChecked = false;
            RIndex2Button.IsChecked = false;
            LMiddleButton.IsChecked = false;
            RMiddleButton.IsChecked = false;
            LMiddle2Button.IsChecked = false;
            RMiddle2Button.IsChecked = false;
            LRingButton.IsChecked = false;
            RRingButton.IsChecked = false;
            LRing2Button.IsChecked = false;
            RRing2Button.IsChecked = false;
            LPinkyButton.IsChecked = false;
            RPinkyButton.IsChecked = false;
            LPinky2Button.IsChecked = false;
            RPinky2Button.IsChecked = false;
            PelvisButton.IsChecked = false;
            TailButton.IsChecked = false;
            Tail2Button.IsChecked = false;
            Tail3Button.IsChecked = false;
            Tail4Button.IsChecked = false;
            LThighButton.IsChecked = false;
            RThighButton.IsChecked = false;
            LKneeButton.IsChecked = false;
            RKneeButton.IsChecked = false;
            LCalfButton.IsChecked = false;
            RCalfButton.IsChecked = false;
            LFootButton.IsChecked = false;
            RFootButton.IsChecked = false;
            LToesButton.IsChecked = false;
            RToesButton.IsChecked = false;
            LEarringButton.IsChecked = false;
            REarringButton.IsChecked = false;
            LEarring2Button.IsChecked = false;
            REarring2Button.IsChecked = false;

            //Load Current Values for Slider
            CharacterDetails.RMouthCheck = true;
        }
        private void RMouthButton_Unchecked(object sender, RoutedEventArgs e)
        {
            CharacterDetails.RMouthRotate = false;
        }
        #endregion

        #region LUpLip
        private void LUpLipRot(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.LUpLipX.value = (float)quat.X;
            CharacterDetails.LUpLipY.value = (float)quat.Y;
            CharacterDetails.LUpLipZ.value = (float)quat.Z;
            CharacterDetails.LUpLipW.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneSlider.ValueChanged -= LUpLipRot;
            BoneSlider2.ValueChanged -= LUpLipRot;
            BoneSlider3.ValueChanged -= LUpLipRot;
        }

        private void LUpLipRot2(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.LUpLipX.value = (float)quat.X;
            CharacterDetails.LUpLipY.value = (float)quat.Y;
            CharacterDetails.LUpLipZ.value = (float)quat.Z;
            CharacterDetails.LUpLipW.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneUpDown.ValueChanged -= LUpLipRot2;
            BoneUpDown2.ValueChanged -= LUpLipRot2;
            BoneUpDown3.ValueChanged -= LUpLipRot2;
        }

        private void LUpLipButton_Checked(object sender, RoutedEventArgs e)
        {
            //Disable Other Selections
            HeadButton.IsChecked = false;
            NoseButton.IsChecked = false;
            NostrilsButton.IsChecked = false;
            ChinButton.IsChecked = false;
            LOutEyebrowButton.IsChecked = false;
            ROutEyebrowButton.IsChecked = false;
            LInEyebrowButton.IsChecked = false;
            RInEyebrowButton.IsChecked = false;
            LEyeButton.IsChecked = false;
            REyeButton.IsChecked = false;
            LEyelidButton.IsChecked = false;
            REyelidButton.IsChecked = false;
            LLowEyelidButton.IsChecked = false;
            RLowEyelidButton.IsChecked = false;
            LEarButton.IsChecked = false;
            REarButton.IsChecked = false;
            LCheekButton.IsChecked = false;
            RCheekButton.IsChecked = false;
            LMouthButton.IsChecked = false;
            RMouthButton.IsChecked = false;
            RUpLipButton.IsChecked = false;
            LLowLipButton.IsChecked = false;
            RLowLipButton.IsChecked = false;
            NeckButton.IsChecked = false;
            SternumButton.IsChecked = false;
            TorsoButton.IsChecked = false;
            WaistButton.IsChecked = false;
            LShoulderButton.IsChecked = false;
            RShoulderButton.IsChecked = false;
            LClavicleButton.IsChecked = false;
            RClavicleButton.IsChecked = false;
            LBreastButton.IsChecked = false;
            RBreastButton.IsChecked = false;
            LArmButton.IsChecked = false;
            RArmButton.IsChecked = false;
            LElbowButton.IsChecked = false;
            RElbowButton.IsChecked = false;
            LForearmButton.IsChecked = false;
            RForearmButton.IsChecked = false;
            LWristButton.IsChecked = false;
            RWristButton.IsChecked = false;
            LHandButton.IsChecked = false;
            RHandButton.IsChecked = false;
            LThumbButton.IsChecked = false;
            RThumbButton.IsChecked = false;
            LThumb2Button.IsChecked = false;
            RThumb2Button.IsChecked = false;
            LIndexButton.IsChecked = false;
            RIndexButton.IsChecked = false;
            LIndex2Button.IsChecked = false;
            RIndex2Button.IsChecked = false;
            LMiddleButton.IsChecked = false;
            RMiddleButton.IsChecked = false;
            LMiddle2Button.IsChecked = false;
            RMiddle2Button.IsChecked = false;
            LRingButton.IsChecked = false;
            RRingButton.IsChecked = false;
            LRing2Button.IsChecked = false;
            RRing2Button.IsChecked = false;
            LPinkyButton.IsChecked = false;
            RPinkyButton.IsChecked = false;
            LPinky2Button.IsChecked = false;
            RPinky2Button.IsChecked = false;
            PelvisButton.IsChecked = false;
            TailButton.IsChecked = false;
            Tail2Button.IsChecked = false;
            Tail3Button.IsChecked = false;
            Tail4Button.IsChecked = false;
            LThighButton.IsChecked = false;
            RThighButton.IsChecked = false;
            LKneeButton.IsChecked = false;
            RKneeButton.IsChecked = false;
            LCalfButton.IsChecked = false;
            RCalfButton.IsChecked = false;
            LFootButton.IsChecked = false;
            RFootButton.IsChecked = false;
            LToesButton.IsChecked = false;
            RToesButton.IsChecked = false;
            LEarringButton.IsChecked = false;
            REarringButton.IsChecked = false;
            LEarring2Button.IsChecked = false;
            REarring2Button.IsChecked = false;

            //Load Current Values for Slider
            CharacterDetails.LUpLipCheck = true;
        }
        private void LUpLipButton_Unchecked(object sender, RoutedEventArgs e)
        {
            CharacterDetails.LUpLipRotate = false;
        }
        #endregion

        #region RUpLip
        private void RUpLipRot(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.RUpLipX.value = (float)quat.X;
            CharacterDetails.RUpLipY.value = (float)quat.Y;
            CharacterDetails.RUpLipZ.value = (float)quat.Z;
            CharacterDetails.RUpLipW.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneSlider.ValueChanged -= RUpLipRot;
            BoneSlider2.ValueChanged -= RUpLipRot;
            BoneSlider3.ValueChanged -= RUpLipRot;
        }

        private void RUpLipRot2(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.RUpLipX.value = (float)quat.X;
            CharacterDetails.RUpLipY.value = (float)quat.Y;
            CharacterDetails.RUpLipZ.value = (float)quat.Z;
            CharacterDetails.RUpLipW.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneUpDown.ValueChanged -= RUpLipRot2;
            BoneUpDown2.ValueChanged -= RUpLipRot2;
            BoneUpDown3.ValueChanged -= RUpLipRot2;
        }

        private void RUpLipButton_Checked(object sender, RoutedEventArgs e)
        {
            //Disable Other Selections
            HeadButton.IsChecked = false;
            NoseButton.IsChecked = false;
            NostrilsButton.IsChecked = false;
            ChinButton.IsChecked = false;
            LOutEyebrowButton.IsChecked = false;
            ROutEyebrowButton.IsChecked = false;
            LInEyebrowButton.IsChecked = false;
            RInEyebrowButton.IsChecked = false;
            LEyeButton.IsChecked = false;
            REyeButton.IsChecked = false;
            LEyelidButton.IsChecked = false;
            REyelidButton.IsChecked = false;
            LLowEyelidButton.IsChecked = false;
            RLowEyelidButton.IsChecked = false;
            LEarButton.IsChecked = false;
            REarButton.IsChecked = false;
            LCheekButton.IsChecked = false;
            RCheekButton.IsChecked = false;
            LMouthButton.IsChecked = false;
            RMouthButton.IsChecked = false;
            LUpLipButton.IsChecked = false;
            LLowLipButton.IsChecked = false;
            RLowLipButton.IsChecked = false;
            NeckButton.IsChecked = false;
            SternumButton.IsChecked = false;
            TorsoButton.IsChecked = false;
            WaistButton.IsChecked = false;
            LShoulderButton.IsChecked = false;
            RShoulderButton.IsChecked = false;
            LClavicleButton.IsChecked = false;
            RClavicleButton.IsChecked = false;
            LBreastButton.IsChecked = false;
            RBreastButton.IsChecked = false;
            LArmButton.IsChecked = false;
            RArmButton.IsChecked = false;
            LElbowButton.IsChecked = false;
            RElbowButton.IsChecked = false;
            LForearmButton.IsChecked = false;
            RForearmButton.IsChecked = false;
            LWristButton.IsChecked = false;
            RWristButton.IsChecked = false;
            LHandButton.IsChecked = false;
            RHandButton.IsChecked = false;
            LThumbButton.IsChecked = false;
            RThumbButton.IsChecked = false;
            LThumb2Button.IsChecked = false;
            RThumb2Button.IsChecked = false;
            LIndexButton.IsChecked = false;
            RIndexButton.IsChecked = false;
            LIndex2Button.IsChecked = false;
            RIndex2Button.IsChecked = false;
            LMiddleButton.IsChecked = false;
            RMiddleButton.IsChecked = false;
            LMiddle2Button.IsChecked = false;
            RMiddle2Button.IsChecked = false;
            LRingButton.IsChecked = false;
            RRingButton.IsChecked = false;
            LRing2Button.IsChecked = false;
            RRing2Button.IsChecked = false;
            LPinkyButton.IsChecked = false;
            RPinkyButton.IsChecked = false;
            LPinky2Button.IsChecked = false;
            RPinky2Button.IsChecked = false;
            PelvisButton.IsChecked = false;
            TailButton.IsChecked = false;
            Tail2Button.IsChecked = false;
            Tail3Button.IsChecked = false;
            Tail4Button.IsChecked = false;
            LThighButton.IsChecked = false;
            RThighButton.IsChecked = false;
            LKneeButton.IsChecked = false;
            RKneeButton.IsChecked = false;
            LCalfButton.IsChecked = false;
            RCalfButton.IsChecked = false;
            LFootButton.IsChecked = false;
            RFootButton.IsChecked = false;
            LToesButton.IsChecked = false;
            RToesButton.IsChecked = false;
            LEarringButton.IsChecked = false;
            REarringButton.IsChecked = false;
            LEarring2Button.IsChecked = false;
            REarring2Button.IsChecked = false;

            //Load Current Values for Slider
            CharacterDetails.RUpLipCheck = true;
        }
        private void RUpLipButton_Unchecked(object sender, RoutedEventArgs e)
        {
            CharacterDetails.RUpLipRotate = false;
        }
        #endregion

        #region LLowLip
        private void LLowLipRot(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.LLowLipX.value = (float)quat.X;
            CharacterDetails.LLowLipY.value = (float)quat.Y;
            CharacterDetails.LLowLipZ.value = (float)quat.Z;
            CharacterDetails.LLowLipW.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneSlider.ValueChanged -= LLowLipRot;
            BoneSlider2.ValueChanged -= LLowLipRot;
            BoneSlider3.ValueChanged -= LLowLipRot;
        }

        private void LLowLipRot2(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.LLowLipX.value = (float)quat.X;
            CharacterDetails.LLowLipY.value = (float)quat.Y;
            CharacterDetails.LLowLipZ.value = (float)quat.Z;
            CharacterDetails.LLowLipW.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneUpDown.ValueChanged -= LLowLipRot2;
            BoneUpDown2.ValueChanged -= LLowLipRot2;
            BoneUpDown3.ValueChanged -= LLowLipRot2;
        }

        private void LLowLipButton_Checked(object sender, RoutedEventArgs e)
        {
            //Disable Other Selections
            HeadButton.IsChecked = false;
            NoseButton.IsChecked = false;
            NostrilsButton.IsChecked = false;
            ChinButton.IsChecked = false;
            LOutEyebrowButton.IsChecked = false;
            ROutEyebrowButton.IsChecked = false;
            LInEyebrowButton.IsChecked = false;
            RInEyebrowButton.IsChecked = false;
            LEyeButton.IsChecked = false;
            REyeButton.IsChecked = false;
            LEyelidButton.IsChecked = false;
            REyelidButton.IsChecked = false;
            LLowEyelidButton.IsChecked = false;
            RLowEyelidButton.IsChecked = false;
            LEarButton.IsChecked = false;
            REarButton.IsChecked = false;
            LCheekButton.IsChecked = false;
            RCheekButton.IsChecked = false;
            LMouthButton.IsChecked = false;
            RMouthButton.IsChecked = false;
            LUpLipButton.IsChecked = false;
            RUpLipButton.IsChecked = false;
            RLowLipButton.IsChecked = false;
            NeckButton.IsChecked = false;
            SternumButton.IsChecked = false;
            TorsoButton.IsChecked = false;
            WaistButton.IsChecked = false;
            LShoulderButton.IsChecked = false;
            RShoulderButton.IsChecked = false;
            LClavicleButton.IsChecked = false;
            RClavicleButton.IsChecked = false;
            LBreastButton.IsChecked = false;
            RBreastButton.IsChecked = false;
            LArmButton.IsChecked = false;
            RArmButton.IsChecked = false;
            LElbowButton.IsChecked = false;
            RElbowButton.IsChecked = false;
            LForearmButton.IsChecked = false;
            RForearmButton.IsChecked = false;
            LWristButton.IsChecked = false;
            RWristButton.IsChecked = false;
            LHandButton.IsChecked = false;
            RHandButton.IsChecked = false;
            LThumbButton.IsChecked = false;
            RThumbButton.IsChecked = false;
            LThumb2Button.IsChecked = false;
            RThumb2Button.IsChecked = false;
            LIndexButton.IsChecked = false;
            RIndexButton.IsChecked = false;
            LIndex2Button.IsChecked = false;
            RIndex2Button.IsChecked = false;
            LMiddleButton.IsChecked = false;
            RMiddleButton.IsChecked = false;
            LMiddle2Button.IsChecked = false;
            RMiddle2Button.IsChecked = false;
            LRingButton.IsChecked = false;
            RRingButton.IsChecked = false;
            LRing2Button.IsChecked = false;
            RRing2Button.IsChecked = false;
            LPinkyButton.IsChecked = false;
            RPinkyButton.IsChecked = false;
            LPinky2Button.IsChecked = false;
            RPinky2Button.IsChecked = false;
            PelvisButton.IsChecked = false;
            TailButton.IsChecked = false;
            Tail2Button.IsChecked = false;
            Tail3Button.IsChecked = false;
            Tail4Button.IsChecked = false;
            LThighButton.IsChecked = false;
            RThighButton.IsChecked = false;
            LKneeButton.IsChecked = false;
            RKneeButton.IsChecked = false;
            LCalfButton.IsChecked = false;
            RCalfButton.IsChecked = false;
            LFootButton.IsChecked = false;
            RFootButton.IsChecked = false;
            LToesButton.IsChecked = false;
            RToesButton.IsChecked = false;
            LEarringButton.IsChecked = false;
            REarringButton.IsChecked = false;
            LEarring2Button.IsChecked = false;
            REarring2Button.IsChecked = false;

            //Load Current Values for Slider
            CharacterDetails.LLowLipCheck = true;
        }
        private void LLowLipButton_Unchecked(object sender, RoutedEventArgs e)
        {
            CharacterDetails.LLowLipRotate = false;
        }
        #endregion

        #region RLowLip
        private void RLowLipRot(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.RLowLipX.value = (float)quat.X;
            CharacterDetails.RLowLipY.value = (float)quat.Y;
            CharacterDetails.RLowLipZ.value = (float)quat.Z;
            CharacterDetails.RLowLipW.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneSlider.ValueChanged -= RLowLipRot;
            BoneSlider2.ValueChanged -= RLowLipRot;
            BoneSlider3.ValueChanged -= RLowLipRot;
        }

        private void RLowLipRot2(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.RLowLipX.value = (float)quat.X;
            CharacterDetails.RLowLipY.value = (float)quat.Y;
            CharacterDetails.RLowLipZ.value = (float)quat.Z;
            CharacterDetails.RLowLipW.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneUpDown.ValueChanged -= RLowLipRot2;
            BoneUpDown2.ValueChanged -= RLowLipRot2;
            BoneUpDown3.ValueChanged -= RLowLipRot2;
            //  Console.WriteLine(CharacterDetails.RotateY);	
        }

        private void RLowLipButton_Checked(object sender, RoutedEventArgs e)
        {
            //Disable Other Selections
            HeadButton.IsChecked = false;
            NoseButton.IsChecked = false;
            NostrilsButton.IsChecked = false;
            ChinButton.IsChecked = false;
            LOutEyebrowButton.IsChecked = false;
            ROutEyebrowButton.IsChecked = false;
            LInEyebrowButton.IsChecked = false;
            RInEyebrowButton.IsChecked = false;
            LEyeButton.IsChecked = false;
            REyeButton.IsChecked = false;
            LEyelidButton.IsChecked = false;
            REyelidButton.IsChecked = false;
            LLowEyelidButton.IsChecked = false;
            RLowEyelidButton.IsChecked = false;
            LEarButton.IsChecked = false;
            REarButton.IsChecked = false;
            LCheekButton.IsChecked = false;
            RCheekButton.IsChecked = false;
            LMouthButton.IsChecked = false;
            RMouthButton.IsChecked = false;
            LUpLipButton.IsChecked = false;
            RUpLipButton.IsChecked = false;
            LLowLipButton.IsChecked = false;
            NeckButton.IsChecked = false;
            SternumButton.IsChecked = false;
            TorsoButton.IsChecked = false;
            WaistButton.IsChecked = false;
            LShoulderButton.IsChecked = false;
            RShoulderButton.IsChecked = false;
            LClavicleButton.IsChecked = false;
            RClavicleButton.IsChecked = false;
            LBreastButton.IsChecked = false;
            RBreastButton.IsChecked = false;
            LArmButton.IsChecked = false;
            RArmButton.IsChecked = false;
            LElbowButton.IsChecked = false;
            RElbowButton.IsChecked = false;
            LForearmButton.IsChecked = false;
            RForearmButton.IsChecked = false;
            LWristButton.IsChecked = false;
            RWristButton.IsChecked = false;
            LHandButton.IsChecked = false;
            RHandButton.IsChecked = false;
            LThumbButton.IsChecked = false;
            RThumbButton.IsChecked = false;
            LThumb2Button.IsChecked = false;
            RThumb2Button.IsChecked = false;
            LIndexButton.IsChecked = false;
            RIndexButton.IsChecked = false;
            LIndex2Button.IsChecked = false;
            RIndex2Button.IsChecked = false;
            LMiddleButton.IsChecked = false;
            RMiddleButton.IsChecked = false;
            LMiddle2Button.IsChecked = false;
            RMiddle2Button.IsChecked = false;
            LRingButton.IsChecked = false;
            RRingButton.IsChecked = false;
            LRing2Button.IsChecked = false;
            RRing2Button.IsChecked = false;
            LPinkyButton.IsChecked = false;
            RPinkyButton.IsChecked = false;
            LPinky2Button.IsChecked = false;
            RPinky2Button.IsChecked = false;
            PelvisButton.IsChecked = false;
            TailButton.IsChecked = false;
            Tail2Button.IsChecked = false;
            Tail3Button.IsChecked = false;
            Tail4Button.IsChecked = false;
            LThighButton.IsChecked = false;
            RThighButton.IsChecked = false;
            LKneeButton.IsChecked = false;
            RKneeButton.IsChecked = false;
            LCalfButton.IsChecked = false;
            RCalfButton.IsChecked = false;
            LFootButton.IsChecked = false;
            RFootButton.IsChecked = false;
            LToesButton.IsChecked = false;
            RToesButton.IsChecked = false;
            LEarringButton.IsChecked = false;
            REarringButton.IsChecked = false;
            LEarring2Button.IsChecked = false;
            REarring2Button.IsChecked = false;

            //Load Current Values for Slider
            CharacterDetails.RLowLipCheck = true;
        }
        private void RLowLipButton_Unchecked(object sender, RoutedEventArgs e)
        {
            CharacterDetails.RLowLipRotate = false;
        }
        #endregion

        #region Neck
        private void NeckRot(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.NeckX.value = (float)quat.X;
            CharacterDetails.NeckY.value = (float)quat.Y;
            CharacterDetails.NeckZ.value = (float)quat.Z;
            CharacterDetails.NeckW.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneSlider.ValueChanged -= NeckRot;
            BoneSlider2.ValueChanged -= NeckRot;
            BoneSlider3.ValueChanged -= NeckRot;
        }

        private void NeckRot2(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.NeckX.value = (float)quat.X;
            CharacterDetails.NeckY.value = (float)quat.Y;
            CharacterDetails.NeckZ.value = (float)quat.Z;
            CharacterDetails.NeckW.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneUpDown.ValueChanged -= NeckRot2;
            BoneUpDown2.ValueChanged -= NeckRot2;
            BoneUpDown3.ValueChanged -= NeckRot2;
        }

        private void NeckButton_Checked(object sender, RoutedEventArgs e)
        {
            //Disable Other Selections
            HeadButton.IsChecked = false;
            NoseButton.IsChecked = false;
            NostrilsButton.IsChecked = false;
            ChinButton.IsChecked = false;
            LOutEyebrowButton.IsChecked = false;
            ROutEyebrowButton.IsChecked = false;
            LInEyebrowButton.IsChecked = false;
            RInEyebrowButton.IsChecked = false;
            LEyeButton.IsChecked = false;
            REyeButton.IsChecked = false;
            LEyelidButton.IsChecked = false;
            REyelidButton.IsChecked = false;
            LLowEyelidButton.IsChecked = false;
            RLowEyelidButton.IsChecked = false;
            LEarButton.IsChecked = false;
            REarButton.IsChecked = false;
            LCheekButton.IsChecked = false;
            RCheekButton.IsChecked = false;
            LMouthButton.IsChecked = false;
            RMouthButton.IsChecked = false;
            LUpLipButton.IsChecked = false;
            RUpLipButton.IsChecked = false;
            LLowLipButton.IsChecked = false;
            RLowLipButton.IsChecked = false;
            SternumButton.IsChecked = false;
            TorsoButton.IsChecked = false;
            WaistButton.IsChecked = false;
            LShoulderButton.IsChecked = false;
            RShoulderButton.IsChecked = false;
            LClavicleButton.IsChecked = false;
            RClavicleButton.IsChecked = false;
            LBreastButton.IsChecked = false;
            RBreastButton.IsChecked = false;
            LArmButton.IsChecked = false;
            RArmButton.IsChecked = false;
            LElbowButton.IsChecked = false;
            RElbowButton.IsChecked = false;
            LForearmButton.IsChecked = false;
            RForearmButton.IsChecked = false;
            LWristButton.IsChecked = false;
            RWristButton.IsChecked = false;
            LHandButton.IsChecked = false;
            RHandButton.IsChecked = false;
            LThumbButton.IsChecked = false;
            RThumbButton.IsChecked = false;
            LThumb2Button.IsChecked = false;
            RThumb2Button.IsChecked = false;
            LIndexButton.IsChecked = false;
            RIndexButton.IsChecked = false;
            LIndex2Button.IsChecked = false;
            RIndex2Button.IsChecked = false;
            LMiddleButton.IsChecked = false;
            RMiddleButton.IsChecked = false;
            LMiddle2Button.IsChecked = false;
            RMiddle2Button.IsChecked = false;
            LRingButton.IsChecked = false;
            RRingButton.IsChecked = false;
            LRing2Button.IsChecked = false;
            RRing2Button.IsChecked = false;
            LPinkyButton.IsChecked = false;
            RPinkyButton.IsChecked = false;
            LPinky2Button.IsChecked = false;
            RPinky2Button.IsChecked = false;
            PelvisButton.IsChecked = false;
            TailButton.IsChecked = false;
            Tail2Button.IsChecked = false;
            Tail3Button.IsChecked = false;
            Tail4Button.IsChecked = false;
            LThighButton.IsChecked = false;
            RThighButton.IsChecked = false;
            LKneeButton.IsChecked = false;
            RKneeButton.IsChecked = false;
            LCalfButton.IsChecked = false;
            RCalfButton.IsChecked = false;
            LFootButton.IsChecked = false;
            RFootButton.IsChecked = false;
            LToesButton.IsChecked = false;
            RToesButton.IsChecked = false;
            LEarringButton.IsChecked = false;
            REarringButton.IsChecked = false;
            LEarring2Button.IsChecked = false;
            REarring2Button.IsChecked = false;

            //Load Current Values for Slider
            CharacterDetails.NeckCheck = true;
        }
        private void NeckButton_Unchecked(object sender, RoutedEventArgs e)
        {
            CharacterDetails.NeckRotate = false;
        }
        #endregion

        #region Sternum
        private void SternumRot(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.SternumX.value = (float)quat.X;
            CharacterDetails.SternumY.value = (float)quat.Y;
            CharacterDetails.SternumZ.value = (float)quat.Z;
            CharacterDetails.SternumW.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneSlider.ValueChanged -= SternumRot;
            BoneSlider2.ValueChanged -= SternumRot;
            BoneSlider3.ValueChanged -= SternumRot;
        }

        private void SternumRot2(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.SternumX.value = (float)quat.X;
            CharacterDetails.SternumY.value = (float)quat.Y;
            CharacterDetails.SternumZ.value = (float)quat.Z;
            CharacterDetails.SternumW.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneUpDown.ValueChanged -= SternumRot2;
            BoneUpDown2.ValueChanged -= SternumRot2;
            BoneUpDown3.ValueChanged -= SternumRot2;
        }

        private void SternumButton_Checked(object sender, RoutedEventArgs e)
        {
            //Disable Other Selections
            HeadButton.IsChecked = false;
            NoseButton.IsChecked = false;
            NostrilsButton.IsChecked = false;
            ChinButton.IsChecked = false;
            LOutEyebrowButton.IsChecked = false;
            ROutEyebrowButton.IsChecked = false;
            LInEyebrowButton.IsChecked = false;
            RInEyebrowButton.IsChecked = false;
            LEyeButton.IsChecked = false;
            REyeButton.IsChecked = false;
            LEyelidButton.IsChecked = false;
            REyelidButton.IsChecked = false;
            LLowEyelidButton.IsChecked = false;
            RLowEyelidButton.IsChecked = false;
            LEarButton.IsChecked = false;
            REarButton.IsChecked = false;
            LCheekButton.IsChecked = false;
            RCheekButton.IsChecked = false;
            LMouthButton.IsChecked = false;
            RMouthButton.IsChecked = false;
            LUpLipButton.IsChecked = false;
            RUpLipButton.IsChecked = false;
            LLowLipButton.IsChecked = false;
            RLowLipButton.IsChecked = false;
            NeckButton.IsChecked = false;
            TorsoButton.IsChecked = false;
            WaistButton.IsChecked = false;
            LShoulderButton.IsChecked = false;
            RShoulderButton.IsChecked = false;
            LClavicleButton.IsChecked = false;
            RClavicleButton.IsChecked = false;
            LBreastButton.IsChecked = false;
            RBreastButton.IsChecked = false;
            LArmButton.IsChecked = false;
            RArmButton.IsChecked = false;
            LElbowButton.IsChecked = false;
            RElbowButton.IsChecked = false;
            LForearmButton.IsChecked = false;
            RForearmButton.IsChecked = false;
            LWristButton.IsChecked = false;
            RWristButton.IsChecked = false;
            LHandButton.IsChecked = false;
            RHandButton.IsChecked = false;
            LThumbButton.IsChecked = false;
            RThumbButton.IsChecked = false;
            LThumb2Button.IsChecked = false;
            RThumb2Button.IsChecked = false;
            LIndexButton.IsChecked = false;
            RIndexButton.IsChecked = false;
            LIndex2Button.IsChecked = false;
            RIndex2Button.IsChecked = false;
            LMiddleButton.IsChecked = false;
            RMiddleButton.IsChecked = false;
            LMiddle2Button.IsChecked = false;
            RMiddle2Button.IsChecked = false;
            LRingButton.IsChecked = false;
            RRingButton.IsChecked = false;
            LRing2Button.IsChecked = false;
            RRing2Button.IsChecked = false;
            LPinkyButton.IsChecked = false;
            RPinkyButton.IsChecked = false;
            LPinky2Button.IsChecked = false;
            RPinky2Button.IsChecked = false;
            PelvisButton.IsChecked = false;
            TailButton.IsChecked = false;
            Tail2Button.IsChecked = false;
            Tail3Button.IsChecked = false;
            Tail4Button.IsChecked = false;
            LThighButton.IsChecked = false;
            RThighButton.IsChecked = false;
            LKneeButton.IsChecked = false;
            RKneeButton.IsChecked = false;
            LCalfButton.IsChecked = false;
            RCalfButton.IsChecked = false;
            LFootButton.IsChecked = false;
            RFootButton.IsChecked = false;
            LToesButton.IsChecked = false;
            RToesButton.IsChecked = false;
            LEarringButton.IsChecked = false;
            REarringButton.IsChecked = false;
            LEarring2Button.IsChecked = false;
            REarring2Button.IsChecked = false;

            //Load Current Values for Slider
            CharacterDetails.SternumCheck = true;
        }
        private void SternumButton_Unchecked(object sender, RoutedEventArgs e)
        {
            CharacterDetails.SternumRotate = false;
        }
        #endregion

        #region Torso
        private void TorsoRot(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.TorsoX.value = (float)quat.X;
            CharacterDetails.TorsoY.value = (float)quat.Y;
            CharacterDetails.TorsoZ.value = (float)quat.Z;
            CharacterDetails.TorsoW.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneSlider.ValueChanged -= TorsoRot;
            BoneSlider2.ValueChanged -= TorsoRot;
            BoneSlider3.ValueChanged -= TorsoRot;
        }

        private void TorsoRot2(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.TorsoX.value = (float)quat.X;
            CharacterDetails.TorsoY.value = (float)quat.Y;
            CharacterDetails.TorsoZ.value = (float)quat.Z;
            CharacterDetails.TorsoW.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneUpDown.ValueChanged -= TorsoRot2;
            BoneUpDown2.ValueChanged -= TorsoRot2;
            BoneUpDown3.ValueChanged -= TorsoRot2;
        }

        private void TorsoButton_Checked(object sender, RoutedEventArgs e)
        {
            //Disable Other Selections
            HeadButton.IsChecked = false;
            NoseButton.IsChecked = false;
            NostrilsButton.IsChecked = false;
            ChinButton.IsChecked = false;
            LOutEyebrowButton.IsChecked = false;
            ROutEyebrowButton.IsChecked = false;
            LInEyebrowButton.IsChecked = false;
            RInEyebrowButton.IsChecked = false;
            LEyeButton.IsChecked = false;
            REyeButton.IsChecked = false;
            LEyelidButton.IsChecked = false;
            REyelidButton.IsChecked = false;
            LLowEyelidButton.IsChecked = false;
            RLowEyelidButton.IsChecked = false;
            LEarButton.IsChecked = false;
            REarButton.IsChecked = false;
            LCheekButton.IsChecked = false;
            RCheekButton.IsChecked = false;
            LMouthButton.IsChecked = false;
            RMouthButton.IsChecked = false;
            LUpLipButton.IsChecked = false;
            RUpLipButton.IsChecked = false;
            LLowLipButton.IsChecked = false;
            RLowLipButton.IsChecked = false;
            NeckButton.IsChecked = false;
            SternumButton.IsChecked = false;
            WaistButton.IsChecked = false;
            LShoulderButton.IsChecked = false;
            RShoulderButton.IsChecked = false;
            LClavicleButton.IsChecked = false;
            RClavicleButton.IsChecked = false;
            LBreastButton.IsChecked = false;
            RBreastButton.IsChecked = false;
            LArmButton.IsChecked = false;
            RArmButton.IsChecked = false;
            LElbowButton.IsChecked = false;
            RElbowButton.IsChecked = false;
            LForearmButton.IsChecked = false;
            RForearmButton.IsChecked = false;
            LWristButton.IsChecked = false;
            RWristButton.IsChecked = false;
            LHandButton.IsChecked = false;
            RHandButton.IsChecked = false;
            LThumbButton.IsChecked = false;
            RThumbButton.IsChecked = false;
            LThumb2Button.IsChecked = false;
            RThumb2Button.IsChecked = false;
            LIndexButton.IsChecked = false;
            RIndexButton.IsChecked = false;
            LIndex2Button.IsChecked = false;
            RIndex2Button.IsChecked = false;
            LMiddleButton.IsChecked = false;
            RMiddleButton.IsChecked = false;
            LMiddle2Button.IsChecked = false;
            RMiddle2Button.IsChecked = false;
            LRingButton.IsChecked = false;
            RRingButton.IsChecked = false;
            LRing2Button.IsChecked = false;
            RRing2Button.IsChecked = false;
            LPinkyButton.IsChecked = false;
            RPinkyButton.IsChecked = false;
            LPinky2Button.IsChecked = false;
            RPinky2Button.IsChecked = false;
            PelvisButton.IsChecked = false;
            TailButton.IsChecked = false;
            Tail2Button.IsChecked = false;
            Tail3Button.IsChecked = false;
            Tail4Button.IsChecked = false;
            LThighButton.IsChecked = false;
            RThighButton.IsChecked = false;
            LKneeButton.IsChecked = false;
            RKneeButton.IsChecked = false;
            LCalfButton.IsChecked = false;
            RCalfButton.IsChecked = false;
            LFootButton.IsChecked = false;
            RFootButton.IsChecked = false;
            LToesButton.IsChecked = false;
            RToesButton.IsChecked = false;
            LEarringButton.IsChecked = false;
            REarringButton.IsChecked = false;
            LEarring2Button.IsChecked = false;
            REarring2Button.IsChecked = false;

            //Load Current Values for Slider
            CharacterDetails.TorsoCheck = true;
        }
        private void TorsoButton_Unchecked(object sender, RoutedEventArgs e)
        {
            CharacterDetails.TorsoRotate = false;
        }
        #endregion

        #region Waist
        private void WaistRot(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.WaistX.value = (float)quat.X;
            CharacterDetails.WaistY.value = (float)quat.Y;
            CharacterDetails.WaistZ.value = (float)quat.Z;
            CharacterDetails.WaistW.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneSlider.ValueChanged -= WaistRot;
            BoneSlider2.ValueChanged -= WaistRot;
            BoneSlider3.ValueChanged -= WaistRot;
        }

        private void WaistRot2(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.WaistX.value = (float)quat.X;
            CharacterDetails.WaistY.value = (float)quat.Y;
            CharacterDetails.WaistZ.value = (float)quat.Z;
            CharacterDetails.WaistW.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneUpDown.ValueChanged -= WaistRot2;
            BoneUpDown2.ValueChanged -= WaistRot2;
            BoneUpDown3.ValueChanged -= WaistRot2;
        }

        private void WaistButton_Checked(object sender, RoutedEventArgs e)
        {
            //Disable Other Selections
            HeadButton.IsChecked = false;
            NoseButton.IsChecked = false;
            NostrilsButton.IsChecked = false;
            ChinButton.IsChecked = false;
            LOutEyebrowButton.IsChecked = false;
            ROutEyebrowButton.IsChecked = false;
            LInEyebrowButton.IsChecked = false;
            RInEyebrowButton.IsChecked = false;
            LEyeButton.IsChecked = false;
            REyeButton.IsChecked = false;
            LEyelidButton.IsChecked = false;
            REyelidButton.IsChecked = false;
            LLowEyelidButton.IsChecked = false;
            RLowEyelidButton.IsChecked = false;
            LEarButton.IsChecked = false;
            REarButton.IsChecked = false;
            LCheekButton.IsChecked = false;
            RCheekButton.IsChecked = false;
            LMouthButton.IsChecked = false;
            RMouthButton.IsChecked = false;
            LUpLipButton.IsChecked = false;
            RUpLipButton.IsChecked = false;
            LLowLipButton.IsChecked = false;
            RLowLipButton.IsChecked = false;
            NeckButton.IsChecked = false;
            SternumButton.IsChecked = false;
            TorsoButton.IsChecked = false;
            LShoulderButton.IsChecked = false;
            RShoulderButton.IsChecked = false;
            LClavicleButton.IsChecked = false;
            RClavicleButton.IsChecked = false;
            LBreastButton.IsChecked = false;
            RBreastButton.IsChecked = false;
            LArmButton.IsChecked = false;
            RArmButton.IsChecked = false;
            LElbowButton.IsChecked = false;
            RElbowButton.IsChecked = false;
            LForearmButton.IsChecked = false;
            RForearmButton.IsChecked = false;
            LWristButton.IsChecked = false;
            RWristButton.IsChecked = false;
            LHandButton.IsChecked = false;
            RHandButton.IsChecked = false;
            LThumbButton.IsChecked = false;
            RThumbButton.IsChecked = false;
            LThumb2Button.IsChecked = false;
            RThumb2Button.IsChecked = false;
            LIndexButton.IsChecked = false;
            RIndexButton.IsChecked = false;
            LIndex2Button.IsChecked = false;
            RIndex2Button.IsChecked = false;
            LMiddleButton.IsChecked = false;
            RMiddleButton.IsChecked = false;
            LMiddle2Button.IsChecked = false;
            RMiddle2Button.IsChecked = false;
            LRingButton.IsChecked = false;
            RRingButton.IsChecked = false;
            LRing2Button.IsChecked = false;
            RRing2Button.IsChecked = false;
            LPinkyButton.IsChecked = false;
            RPinkyButton.IsChecked = false;
            LPinky2Button.IsChecked = false;
            RPinky2Button.IsChecked = false;
            PelvisButton.IsChecked = false;
            TailButton.IsChecked = false;
            Tail2Button.IsChecked = false;
            Tail3Button.IsChecked = false;
            Tail4Button.IsChecked = false;
            LThighButton.IsChecked = false;
            RThighButton.IsChecked = false;
            LKneeButton.IsChecked = false;
            RKneeButton.IsChecked = false;
            LCalfButton.IsChecked = false;
            RCalfButton.IsChecked = false;
            LFootButton.IsChecked = false;
            RFootButton.IsChecked = false;
            LToesButton.IsChecked = false;
            RToesButton.IsChecked = false;
            LEarringButton.IsChecked = false;
            REarringButton.IsChecked = false;
            LEarring2Button.IsChecked = false;
            REarring2Button.IsChecked = false;

            //Load Current Values for Slider
            CharacterDetails.WaistCheck = true;
        }
        private void WaistButton_Unchecked(object sender, RoutedEventArgs e)
        {
            CharacterDetails.WaistRotate = false;
        }
        #endregion

        #region LShoulder
        private void LShoulderRot(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.LShoulderX.value = (float)quat.X;
            CharacterDetails.LShoulderY.value = (float)quat.Y;
            CharacterDetails.LShoulderZ.value = (float)quat.Z;
            CharacterDetails.LShoulderW.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneSlider.ValueChanged -= LShoulderRot;
            BoneSlider2.ValueChanged -= LShoulderRot;
            BoneSlider3.ValueChanged -= LShoulderRot;
        }

        private void LShoulderRot2(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.LShoulderX.value = (float)quat.X;
            CharacterDetails.LShoulderY.value = (float)quat.Y;
            CharacterDetails.LShoulderZ.value = (float)quat.Z;
            CharacterDetails.LShoulderW.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneUpDown.ValueChanged -= LShoulderRot2;
            BoneUpDown2.ValueChanged -= LShoulderRot2;
            BoneUpDown3.ValueChanged -= LShoulderRot2;
        }

        private void LShoulderButton_Checked(object sender, RoutedEventArgs e)
        {
            //Disable Other Selections
            HeadButton.IsChecked = false;
            NoseButton.IsChecked = false;
            NostrilsButton.IsChecked = false;
            ChinButton.IsChecked = false;
            LOutEyebrowButton.IsChecked = false;
            ROutEyebrowButton.IsChecked = false;
            LInEyebrowButton.IsChecked = false;
            RInEyebrowButton.IsChecked = false;
            LEyeButton.IsChecked = false;
            REyeButton.IsChecked = false;
            LEyelidButton.IsChecked = false;
            REyelidButton.IsChecked = false;
            LLowEyelidButton.IsChecked = false;
            RLowEyelidButton.IsChecked = false;
            LEarButton.IsChecked = false;
            REarButton.IsChecked = false;
            LCheekButton.IsChecked = false;
            RCheekButton.IsChecked = false;
            LMouthButton.IsChecked = false;
            RMouthButton.IsChecked = false;
            LUpLipButton.IsChecked = false;
            RUpLipButton.IsChecked = false;
            LLowLipButton.IsChecked = false;
            RLowLipButton.IsChecked = false;
            NeckButton.IsChecked = false;
            SternumButton.IsChecked = false;
            TorsoButton.IsChecked = false;
            WaistButton.IsChecked = false;
            RShoulderButton.IsChecked = false;
            LClavicleButton.IsChecked = false;
            RClavicleButton.IsChecked = false;
            LBreastButton.IsChecked = false;
            RBreastButton.IsChecked = false;
            LArmButton.IsChecked = false;
            RArmButton.IsChecked = false;
            LElbowButton.IsChecked = false;
            RElbowButton.IsChecked = false;
            LForearmButton.IsChecked = false;
            RForearmButton.IsChecked = false;
            LWristButton.IsChecked = false;
            RWristButton.IsChecked = false;
            LHandButton.IsChecked = false;
            RHandButton.IsChecked = false;
            LThumbButton.IsChecked = false;
            RThumbButton.IsChecked = false;
            LThumb2Button.IsChecked = false;
            RThumb2Button.IsChecked = false;
            LIndexButton.IsChecked = false;
            RIndexButton.IsChecked = false;
            LIndex2Button.IsChecked = false;
            RIndex2Button.IsChecked = false;
            LMiddleButton.IsChecked = false;
            RMiddleButton.IsChecked = false;
            LMiddle2Button.IsChecked = false;
            RMiddle2Button.IsChecked = false;
            LRingButton.IsChecked = false;
            RRingButton.IsChecked = false;
            LRing2Button.IsChecked = false;
            RRing2Button.IsChecked = false;
            LPinkyButton.IsChecked = false;
            RPinkyButton.IsChecked = false;
            LPinky2Button.IsChecked = false;
            RPinky2Button.IsChecked = false;
            PelvisButton.IsChecked = false;
            TailButton.IsChecked = false;
            Tail2Button.IsChecked = false;
            Tail3Button.IsChecked = false;
            Tail4Button.IsChecked = false;
            LThighButton.IsChecked = false;
            RThighButton.IsChecked = false;
            LKneeButton.IsChecked = false;
            RKneeButton.IsChecked = false;
            LCalfButton.IsChecked = false;
            RCalfButton.IsChecked = false;
            LFootButton.IsChecked = false;
            RFootButton.IsChecked = false;
            LToesButton.IsChecked = false;
            RToesButton.IsChecked = false;
            LEarringButton.IsChecked = false;
            REarringButton.IsChecked = false;
            LEarring2Button.IsChecked = false;
            REarring2Button.IsChecked = false;

            //Load Current Values for Slider
            CharacterDetails.LShoulderCheck = true;
        }
        private void LShoulderButton_Unchecked(object sender, RoutedEventArgs e)
        {
            CharacterDetails.LShoulderRotate = false;
        }
        #endregion

        #region RShoulder
        private void RShoulderRot(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.RShoulderX.value = (float)quat.X;
            CharacterDetails.RShoulderY.value = (float)quat.Y;
            CharacterDetails.RShoulderZ.value = (float)quat.Z;
            CharacterDetails.RShoulderW.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneSlider.ValueChanged -= RShoulderRot;
            BoneSlider2.ValueChanged -= RShoulderRot;
            BoneSlider3.ValueChanged -= RShoulderRot;
        }

        private void RShoulderRot2(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.RShoulderX.value = (float)quat.X;
            CharacterDetails.RShoulderY.value = (float)quat.Y;
            CharacterDetails.RShoulderZ.value = (float)quat.Z;
            CharacterDetails.RShoulderW.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneUpDown.ValueChanged -= RShoulderRot2;
            BoneUpDown2.ValueChanged -= RShoulderRot2;
            BoneUpDown3.ValueChanged -= RShoulderRot2;
        }

        private void RShoulderButton_Checked(object sender, RoutedEventArgs e)
        {
            //Disable Other Selections
            HeadButton.IsChecked = false;
            NoseButton.IsChecked = false;
            NostrilsButton.IsChecked = false;
            ChinButton.IsChecked = false;
            LOutEyebrowButton.IsChecked = false;
            ROutEyebrowButton.IsChecked = false;
            LInEyebrowButton.IsChecked = false;
            RInEyebrowButton.IsChecked = false;
            LEyeButton.IsChecked = false;
            REyeButton.IsChecked = false;
            LEyelidButton.IsChecked = false;
            REyelidButton.IsChecked = false;
            LLowEyelidButton.IsChecked = false;
            RLowEyelidButton.IsChecked = false;
            LEarButton.IsChecked = false;
            REarButton.IsChecked = false;
            LCheekButton.IsChecked = false;
            RCheekButton.IsChecked = false;
            LMouthButton.IsChecked = false;
            RMouthButton.IsChecked = false;
            LUpLipButton.IsChecked = false;
            RUpLipButton.IsChecked = false;
            LLowLipButton.IsChecked = false;
            RLowLipButton.IsChecked = false;
            NeckButton.IsChecked = false;
            SternumButton.IsChecked = false;
            TorsoButton.IsChecked = false;
            WaistButton.IsChecked = false;
            LShoulderButton.IsChecked = false;
            LClavicleButton.IsChecked = false;
            RClavicleButton.IsChecked = false;
            LBreastButton.IsChecked = false;
            RBreastButton.IsChecked = false;
            LArmButton.IsChecked = false;
            RArmButton.IsChecked = false;
            LElbowButton.IsChecked = false;
            RElbowButton.IsChecked = false;
            LForearmButton.IsChecked = false;
            RForearmButton.IsChecked = false;
            LWristButton.IsChecked = false;
            RWristButton.IsChecked = false;
            LHandButton.IsChecked = false;
            RHandButton.IsChecked = false;
            LThumbButton.IsChecked = false;
            RThumbButton.IsChecked = false;
            LThumb2Button.IsChecked = false;
            RThumb2Button.IsChecked = false;
            LIndexButton.IsChecked = false;
            RIndexButton.IsChecked = false;
            LIndex2Button.IsChecked = false;
            RIndex2Button.IsChecked = false;
            LMiddleButton.IsChecked = false;
            RMiddleButton.IsChecked = false;
            LMiddle2Button.IsChecked = false;
            RMiddle2Button.IsChecked = false;
            LRingButton.IsChecked = false;
            RRingButton.IsChecked = false;
            LRing2Button.IsChecked = false;
            RRing2Button.IsChecked = false;
            LPinkyButton.IsChecked = false;
            RPinkyButton.IsChecked = false;
            LPinky2Button.IsChecked = false;
            RPinky2Button.IsChecked = false;
            PelvisButton.IsChecked = false;
            TailButton.IsChecked = false;
            Tail2Button.IsChecked = false;
            Tail3Button.IsChecked = false;
            Tail4Button.IsChecked = false;
            LThighButton.IsChecked = false;
            RThighButton.IsChecked = false;
            LKneeButton.IsChecked = false;
            RKneeButton.IsChecked = false;
            LCalfButton.IsChecked = false;
            RCalfButton.IsChecked = false;
            LFootButton.IsChecked = false;
            RFootButton.IsChecked = false;
            LToesButton.IsChecked = false;
            RToesButton.IsChecked = false;
            LEarringButton.IsChecked = false;
            REarringButton.IsChecked = false;
            LEarring2Button.IsChecked = false;
            REarring2Button.IsChecked = false;

            //Load Current Values for Slider
            CharacterDetails.RShoulderCheck = true;
        }
        private void RShoulderButton_Unchecked(object sender, RoutedEventArgs e)
        {
            CharacterDetails.RShoulderRotate = false;
        }
        #endregion

        #region LClavicle
        private void LClavicleRot(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.LClavicleX.value = (float)quat.X;
            CharacterDetails.LClavicleY.value = (float)quat.Y;
            CharacterDetails.LClavicleZ.value = (float)quat.Z;
            CharacterDetails.LClavicleW.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneSlider.ValueChanged -= LClavicleRot;
            BoneSlider2.ValueChanged -= LClavicleRot;
            BoneSlider3.ValueChanged -= LClavicleRot;
        }

        private void LClavicleRot2(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.LClavicleX.value = (float)quat.X;
            CharacterDetails.LClavicleY.value = (float)quat.Y;
            CharacterDetails.LClavicleZ.value = (float)quat.Z;
            CharacterDetails.LClavicleW.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneUpDown.ValueChanged -= LClavicleRot2;
            BoneUpDown2.ValueChanged -= LClavicleRot2;
            BoneUpDown3.ValueChanged -= LClavicleRot2;
        }

        private void LClavicleButton_Checked(object sender, RoutedEventArgs e)
        {
            //Disable Other Selections
            HeadButton.IsChecked = false;
            NoseButton.IsChecked = false;
            NostrilsButton.IsChecked = false;
            ChinButton.IsChecked = false;
            LOutEyebrowButton.IsChecked = false;
            ROutEyebrowButton.IsChecked = false;
            LInEyebrowButton.IsChecked = false;
            RInEyebrowButton.IsChecked = false;
            LEyeButton.IsChecked = false;
            REyeButton.IsChecked = false;
            LEyelidButton.IsChecked = false;
            REyelidButton.IsChecked = false;
            LLowEyelidButton.IsChecked = false;
            RLowEyelidButton.IsChecked = false;
            LEarButton.IsChecked = false;
            REarButton.IsChecked = false;
            LCheekButton.IsChecked = false;
            RCheekButton.IsChecked = false;
            LMouthButton.IsChecked = false;
            RMouthButton.IsChecked = false;
            LUpLipButton.IsChecked = false;
            RUpLipButton.IsChecked = false;
            LLowLipButton.IsChecked = false;
            RLowLipButton.IsChecked = false;
            NeckButton.IsChecked = false;
            SternumButton.IsChecked = false;
            TorsoButton.IsChecked = false;
            WaistButton.IsChecked = false;
            LShoulderButton.IsChecked = false;
            RShoulderButton.IsChecked = false;
            RClavicleButton.IsChecked = false;
            LBreastButton.IsChecked = false;
            RBreastButton.IsChecked = false;
            LArmButton.IsChecked = false;
            RArmButton.IsChecked = false;
            LElbowButton.IsChecked = false;
            RElbowButton.IsChecked = false;
            LForearmButton.IsChecked = false;
            RForearmButton.IsChecked = false;
            LWristButton.IsChecked = false;
            RWristButton.IsChecked = false;
            LHandButton.IsChecked = false;
            RHandButton.IsChecked = false;
            LThumbButton.IsChecked = false;
            RThumbButton.IsChecked = false;
            LThumb2Button.IsChecked = false;
            RThumb2Button.IsChecked = false;
            LIndexButton.IsChecked = false;
            RIndexButton.IsChecked = false;
            LIndex2Button.IsChecked = false;
            RIndex2Button.IsChecked = false;
            LMiddleButton.IsChecked = false;
            RMiddleButton.IsChecked = false;
            LMiddle2Button.IsChecked = false;
            RMiddle2Button.IsChecked = false;
            LRingButton.IsChecked = false;
            RRingButton.IsChecked = false;
            LRing2Button.IsChecked = false;
            RRing2Button.IsChecked = false;
            LPinkyButton.IsChecked = false;
            RPinkyButton.IsChecked = false;
            LPinky2Button.IsChecked = false;
            RPinky2Button.IsChecked = false;
            PelvisButton.IsChecked = false;
            TailButton.IsChecked = false;
            Tail2Button.IsChecked = false;
            Tail3Button.IsChecked = false;
            Tail4Button.IsChecked = false;
            LThighButton.IsChecked = false;
            RThighButton.IsChecked = false;
            LKneeButton.IsChecked = false;
            RKneeButton.IsChecked = false;
            LCalfButton.IsChecked = false;
            RCalfButton.IsChecked = false;
            LFootButton.IsChecked = false;
            RFootButton.IsChecked = false;
            LToesButton.IsChecked = false;
            RToesButton.IsChecked = false;
            LEarringButton.IsChecked = false;
            REarringButton.IsChecked = false;
            LEarring2Button.IsChecked = false;
            REarring2Button.IsChecked = false;

            //Load Current Values for Slider
            CharacterDetails.LClavicleCheck = true;
        }
        private void LClavicleButton_Unchecked(object sender, RoutedEventArgs e)
        {
            CharacterDetails.LClavicleRotate = false;
        }
        #endregion

        #region RClavicle
        private void RClavicleRot(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.RClavicleX.value = (float)quat.X;
            CharacterDetails.RClavicleY.value = (float)quat.Y;
            CharacterDetails.RClavicleZ.value = (float)quat.Z;
            CharacterDetails.RClavicleW.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneSlider.ValueChanged -= RClavicleRot;
            BoneSlider2.ValueChanged -= RClavicleRot;
            BoneSlider3.ValueChanged -= RClavicleRot;
        }

        private void RClavicleRot2(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.RClavicleX.value = (float)quat.X;
            CharacterDetails.RClavicleY.value = (float)quat.Y;
            CharacterDetails.RClavicleZ.value = (float)quat.Z;
            CharacterDetails.RClavicleW.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneUpDown.ValueChanged -= RClavicleRot2;
            BoneUpDown2.ValueChanged -= RClavicleRot2;
            BoneUpDown3.ValueChanged -= RClavicleRot2;
        }

        private void RClavicleButton_Checked(object sender, RoutedEventArgs e)
        {
            //Disable Other Selections
            HeadButton.IsChecked = false;
            NoseButton.IsChecked = false;
            NostrilsButton.IsChecked = false;
            ChinButton.IsChecked = false;
            LOutEyebrowButton.IsChecked = false;
            ROutEyebrowButton.IsChecked = false;
            LInEyebrowButton.IsChecked = false;
            RInEyebrowButton.IsChecked = false;
            LEyeButton.IsChecked = false;
            REyeButton.IsChecked = false;
            LEyelidButton.IsChecked = false;
            REyelidButton.IsChecked = false;
            LLowEyelidButton.IsChecked = false;
            RLowEyelidButton.IsChecked = false;
            LEarButton.IsChecked = false;
            REarButton.IsChecked = false;
            LCheekButton.IsChecked = false;
            RCheekButton.IsChecked = false;
            LMouthButton.IsChecked = false;
            RMouthButton.IsChecked = false;
            LUpLipButton.IsChecked = false;
            RUpLipButton.IsChecked = false;
            LLowLipButton.IsChecked = false;
            RLowLipButton.IsChecked = false;
            NeckButton.IsChecked = false;
            SternumButton.IsChecked = false;
            TorsoButton.IsChecked = false;
            WaistButton.IsChecked = false;
            LShoulderButton.IsChecked = false;
            RShoulderButton.IsChecked = false;
            LClavicleButton.IsChecked = false;
            LBreastButton.IsChecked = false;
            RBreastButton.IsChecked = false;
            LArmButton.IsChecked = false;
            RArmButton.IsChecked = false;
            LElbowButton.IsChecked = false;
            RElbowButton.IsChecked = false;
            LForearmButton.IsChecked = false;
            RForearmButton.IsChecked = false;
            LWristButton.IsChecked = false;
            RWristButton.IsChecked = false;
            LHandButton.IsChecked = false;
            RHandButton.IsChecked = false;
            LThumbButton.IsChecked = false;
            RThumbButton.IsChecked = false;
            LThumb2Button.IsChecked = false;
            RThumb2Button.IsChecked = false;
            LIndexButton.IsChecked = false;
            RIndexButton.IsChecked = false;
            LIndex2Button.IsChecked = false;
            RIndex2Button.IsChecked = false;
            LMiddleButton.IsChecked = false;
            RMiddleButton.IsChecked = false;
            LMiddle2Button.IsChecked = false;
            RMiddle2Button.IsChecked = false;
            LRingButton.IsChecked = false;
            RRingButton.IsChecked = false;
            LRing2Button.IsChecked = false;
            RRing2Button.IsChecked = false;
            LPinkyButton.IsChecked = false;
            RPinkyButton.IsChecked = false;
            LPinky2Button.IsChecked = false;
            RPinky2Button.IsChecked = false;
            PelvisButton.IsChecked = false;
            TailButton.IsChecked = false;
            Tail2Button.IsChecked = false;
            Tail3Button.IsChecked = false;
            Tail4Button.IsChecked = false;
            LThighButton.IsChecked = false;
            RThighButton.IsChecked = false;
            LKneeButton.IsChecked = false;
            RKneeButton.IsChecked = false;
            LCalfButton.IsChecked = false;
            RCalfButton.IsChecked = false;
            LFootButton.IsChecked = false;
            RFootButton.IsChecked = false;
            LToesButton.IsChecked = false;
            RToesButton.IsChecked = false;
            LEarringButton.IsChecked = false;
            REarringButton.IsChecked = false;
            LEarring2Button.IsChecked = false;
            REarring2Button.IsChecked = false;

            //Load Current Values for Slider
            CharacterDetails.RClavicleCheck = true;
        }
        private void RClavicleButton_Unchecked(object sender, RoutedEventArgs e)
        {
            CharacterDetails.RClavicleRotate = false;
        }
        #endregion

        #region LBreast
        private void LBreastRot(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.LBreastX.value = (float)quat.X;
            CharacterDetails.LBreastY.value = (float)quat.Y;
            CharacterDetails.LBreastZ.value = (float)quat.Z;
            CharacterDetails.LBreastW.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneSlider.ValueChanged -= LBreastRot;
            BoneSlider2.ValueChanged -= LBreastRot;
            BoneSlider3.ValueChanged -= LBreastRot;
        }

        private void LBreastRot2(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.LBreastX.value = (float)quat.X;
            CharacterDetails.LBreastY.value = (float)quat.Y;
            CharacterDetails.LBreastZ.value = (float)quat.Z;
            CharacterDetails.LBreastW.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneUpDown.ValueChanged -= LBreastRot2;
            BoneUpDown2.ValueChanged -= LBreastRot2;
            BoneUpDown3.ValueChanged -= LBreastRot2;
        }

        private void LBreastButton_Checked(object sender, RoutedEventArgs e)
        {
            //Disable Other Selections
            HeadButton.IsChecked = false;
            NoseButton.IsChecked = false;
            NostrilsButton.IsChecked = false;
            ChinButton.IsChecked = false;
            LOutEyebrowButton.IsChecked = false;
            ROutEyebrowButton.IsChecked = false;
            LInEyebrowButton.IsChecked = false;
            RInEyebrowButton.IsChecked = false;
            LEyeButton.IsChecked = false;
            REyeButton.IsChecked = false;
            LEyelidButton.IsChecked = false;
            REyelidButton.IsChecked = false;
            LLowEyelidButton.IsChecked = false;
            RLowEyelidButton.IsChecked = false;
            LEarButton.IsChecked = false;
            REarButton.IsChecked = false;
            LCheekButton.IsChecked = false;
            RCheekButton.IsChecked = false;
            LMouthButton.IsChecked = false;
            RMouthButton.IsChecked = false;
            LUpLipButton.IsChecked = false;
            RUpLipButton.IsChecked = false;
            LLowLipButton.IsChecked = false;
            RLowLipButton.IsChecked = false;
            NeckButton.IsChecked = false;
            SternumButton.IsChecked = false;
            TorsoButton.IsChecked = false;
            WaistButton.IsChecked = false;
            LShoulderButton.IsChecked = false;
            RShoulderButton.IsChecked = false;
            LClavicleButton.IsChecked = false;
            RClavicleButton.IsChecked = false;
            RBreastButton.IsChecked = false;
            LArmButton.IsChecked = false;
            RArmButton.IsChecked = false;
            LElbowButton.IsChecked = false;
            RElbowButton.IsChecked = false;
            LForearmButton.IsChecked = false;
            RForearmButton.IsChecked = false;
            LWristButton.IsChecked = false;
            RWristButton.IsChecked = false;
            LHandButton.IsChecked = false;
            RHandButton.IsChecked = false;
            LThumbButton.IsChecked = false;
            RThumbButton.IsChecked = false;
            LThumb2Button.IsChecked = false;
            RThumb2Button.IsChecked = false;
            LIndexButton.IsChecked = false;
            RIndexButton.IsChecked = false;
            LIndex2Button.IsChecked = false;
            RIndex2Button.IsChecked = false;
            LMiddleButton.IsChecked = false;
            RMiddleButton.IsChecked = false;
            LMiddle2Button.IsChecked = false;
            RMiddle2Button.IsChecked = false;
            LRingButton.IsChecked = false;
            RRingButton.IsChecked = false;
            LRing2Button.IsChecked = false;
            RRing2Button.IsChecked = false;
            LPinkyButton.IsChecked = false;
            RPinkyButton.IsChecked = false;
            LPinky2Button.IsChecked = false;
            RPinky2Button.IsChecked = false;
            PelvisButton.IsChecked = false;
            TailButton.IsChecked = false;
            Tail2Button.IsChecked = false;
            Tail3Button.IsChecked = false;
            Tail4Button.IsChecked = false;
            LThighButton.IsChecked = false;
            RThighButton.IsChecked = false;
            LKneeButton.IsChecked = false;
            RKneeButton.IsChecked = false;
            LCalfButton.IsChecked = false;
            RCalfButton.IsChecked = false;
            LFootButton.IsChecked = false;
            RFootButton.IsChecked = false;
            LToesButton.IsChecked = false;
            RToesButton.IsChecked = false;
            LEarringButton.IsChecked = false;
            REarringButton.IsChecked = false;
            LEarring2Button.IsChecked = false;
            REarring2Button.IsChecked = false;

            //Load Current Values for Slider
            CharacterDetails.LBreastCheck = true;
        }
        private void LBreastButton_Unchecked(object sender, RoutedEventArgs e)
        {
            CharacterDetails.LBreastRotate = false;
        }
        #endregion

        #region RBreast
        private void RBreastRot(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.RBreastX.value = (float)quat.X;
            CharacterDetails.RBreastY.value = (float)quat.Y;
            CharacterDetails.RBreastZ.value = (float)quat.Z;
            CharacterDetails.RBreastW.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneSlider.ValueChanged -= RBreastRot;
            BoneSlider2.ValueChanged -= RBreastRot;
            BoneSlider3.ValueChanged -= RBreastRot;
        }

        private void RBreastRot2(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.RBreastX.value = (float)quat.X;
            CharacterDetails.RBreastY.value = (float)quat.Y;
            CharacterDetails.RBreastZ.value = (float)quat.Z;
            CharacterDetails.RBreastW.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneUpDown.ValueChanged -= RBreastRot2;
            BoneUpDown2.ValueChanged -= RBreastRot2;
            BoneUpDown3.ValueChanged -= RBreastRot2;
        }

        private void RBreastButton_Checked(object sender, RoutedEventArgs e)
        {
            //Disable Other Selections
            HeadButton.IsChecked = false;
            NoseButton.IsChecked = false;
            NostrilsButton.IsChecked = false;
            ChinButton.IsChecked = false;
            LOutEyebrowButton.IsChecked = false;
            ROutEyebrowButton.IsChecked = false;
            LInEyebrowButton.IsChecked = false;
            RInEyebrowButton.IsChecked = false;
            LEyeButton.IsChecked = false;
            REyeButton.IsChecked = false;
            LEyelidButton.IsChecked = false;
            REyelidButton.IsChecked = false;
            LLowEyelidButton.IsChecked = false;
            RLowEyelidButton.IsChecked = false;
            LEarButton.IsChecked = false;
            REarButton.IsChecked = false;
            LCheekButton.IsChecked = false;
            RCheekButton.IsChecked = false;
            LMouthButton.IsChecked = false;
            RMouthButton.IsChecked = false;
            LUpLipButton.IsChecked = false;
            RUpLipButton.IsChecked = false;
            LLowLipButton.IsChecked = false;
            RLowLipButton.IsChecked = false;
            NeckButton.IsChecked = false;
            SternumButton.IsChecked = false;
            TorsoButton.IsChecked = false;
            WaistButton.IsChecked = false;
            LShoulderButton.IsChecked = false;
            RShoulderButton.IsChecked = false;
            LClavicleButton.IsChecked = false;
            RClavicleButton.IsChecked = false;
            LBreastButton.IsChecked = false;
            LArmButton.IsChecked = false;
            RArmButton.IsChecked = false;
            LElbowButton.IsChecked = false;
            RElbowButton.IsChecked = false;
            LForearmButton.IsChecked = false;
            RForearmButton.IsChecked = false;
            LWristButton.IsChecked = false;
            RWristButton.IsChecked = false;
            LHandButton.IsChecked = false;
            RHandButton.IsChecked = false;
            LThumbButton.IsChecked = false;
            RThumbButton.IsChecked = false;
            LThumb2Button.IsChecked = false;
            RThumb2Button.IsChecked = false;
            LIndexButton.IsChecked = false;
            RIndexButton.IsChecked = false;
            LIndex2Button.IsChecked = false;
            RIndex2Button.IsChecked = false;
            LMiddleButton.IsChecked = false;
            RMiddleButton.IsChecked = false;
            LMiddle2Button.IsChecked = false;
            RMiddle2Button.IsChecked = false;
            LRingButton.IsChecked = false;
            RRingButton.IsChecked = false;
            LRing2Button.IsChecked = false;
            RRing2Button.IsChecked = false;
            LPinkyButton.IsChecked = false;
            RPinkyButton.IsChecked = false;
            LPinky2Button.IsChecked = false;
            RPinky2Button.IsChecked = false;
            PelvisButton.IsChecked = false;
            TailButton.IsChecked = false;
            Tail2Button.IsChecked = false;
            Tail3Button.IsChecked = false;
            Tail4Button.IsChecked = false;
            LThighButton.IsChecked = false;
            RThighButton.IsChecked = false;
            LKneeButton.IsChecked = false;
            RKneeButton.IsChecked = false;
            LCalfButton.IsChecked = false;
            RCalfButton.IsChecked = false;
            LFootButton.IsChecked = false;
            RFootButton.IsChecked = false;
            LToesButton.IsChecked = false;
            RToesButton.IsChecked = false;
            LEarringButton.IsChecked = false;
            REarringButton.IsChecked = false;
            LEarring2Button.IsChecked = false;
            REarring2Button.IsChecked = false;

            //Load Current Values for Slider
            CharacterDetails.RBreastCheck = true;
        }
        private void RBreastButton_Unchecked(object sender, RoutedEventArgs e)
        {
            CharacterDetails.RBreastRotate = false;
        }
        #endregion

        #region LArm
        private void LArmRot(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.LArmX.value = (float)quat.X;
            CharacterDetails.LArmY.value = (float)quat.Y;
            CharacterDetails.LArmZ.value = (float)quat.Z;
            CharacterDetails.LArmW.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneSlider.ValueChanged -= LArmRot;
            BoneSlider2.ValueChanged -= LArmRot;
            BoneSlider3.ValueChanged -= LArmRot;
        }

        private void LArmRot2(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.LArmX.value = (float)quat.X;
            CharacterDetails.LArmY.value = (float)quat.Y;
            CharacterDetails.LArmZ.value = (float)quat.Z;
            CharacterDetails.LArmW.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneUpDown.ValueChanged -= LArmRot2;
            BoneUpDown2.ValueChanged -= LArmRot2;
            BoneUpDown3.ValueChanged -= LArmRot2;
        }

        private void LArmButton_Checked(object sender, RoutedEventArgs e)
        {
            //Disable Other Selections
            HeadButton.IsChecked = false;
            NoseButton.IsChecked = false;
            NostrilsButton.IsChecked = false;
            ChinButton.IsChecked = false;
            LOutEyebrowButton.IsChecked = false;
            ROutEyebrowButton.IsChecked = false;
            LInEyebrowButton.IsChecked = false;
            RInEyebrowButton.IsChecked = false;
            LEyeButton.IsChecked = false;
            REyeButton.IsChecked = false;
            LEyelidButton.IsChecked = false;
            REyelidButton.IsChecked = false;
            LLowEyelidButton.IsChecked = false;
            RLowEyelidButton.IsChecked = false;
            LEarButton.IsChecked = false;
            REarButton.IsChecked = false;
            LCheekButton.IsChecked = false;
            RCheekButton.IsChecked = false;
            LMouthButton.IsChecked = false;
            RMouthButton.IsChecked = false;
            LUpLipButton.IsChecked = false;
            RUpLipButton.IsChecked = false;
            LLowLipButton.IsChecked = false;
            RLowLipButton.IsChecked = false;
            NeckButton.IsChecked = false;
            SternumButton.IsChecked = false;
            TorsoButton.IsChecked = false;
            WaistButton.IsChecked = false;
            LShoulderButton.IsChecked = false;
            RShoulderButton.IsChecked = false;
            LClavicleButton.IsChecked = false;
            RClavicleButton.IsChecked = false;
            LBreastButton.IsChecked = false;
            RBreastButton.IsChecked = false;
            RArmButton.IsChecked = false;
            LElbowButton.IsChecked = false;
            RElbowButton.IsChecked = false;
            LForearmButton.IsChecked = false;
            RForearmButton.IsChecked = false;
            LWristButton.IsChecked = false;
            RWristButton.IsChecked = false;
            LHandButton.IsChecked = false;
            RHandButton.IsChecked = false;
            LThumbButton.IsChecked = false;
            RThumbButton.IsChecked = false;
            LThumb2Button.IsChecked = false;
            RThumb2Button.IsChecked = false;
            LIndexButton.IsChecked = false;
            RIndexButton.IsChecked = false;
            LIndex2Button.IsChecked = false;
            RIndex2Button.IsChecked = false;
            LMiddleButton.IsChecked = false;
            RMiddleButton.IsChecked = false;
            LMiddle2Button.IsChecked = false;
            RMiddle2Button.IsChecked = false;
            LRingButton.IsChecked = false;
            RRingButton.IsChecked = false;
            LRing2Button.IsChecked = false;
            RRing2Button.IsChecked = false;
            LPinkyButton.IsChecked = false;
            RPinkyButton.IsChecked = false;
            LPinky2Button.IsChecked = false;
            RPinky2Button.IsChecked = false;
            PelvisButton.IsChecked = false;
            TailButton.IsChecked = false;
            Tail2Button.IsChecked = false;
            Tail3Button.IsChecked = false;
            Tail4Button.IsChecked = false;
            LThighButton.IsChecked = false;
            RThighButton.IsChecked = false;
            LKneeButton.IsChecked = false;
            RKneeButton.IsChecked = false;
            LCalfButton.IsChecked = false;
            RCalfButton.IsChecked = false;
            LFootButton.IsChecked = false;
            RFootButton.IsChecked = false;
            LToesButton.IsChecked = false;
            RToesButton.IsChecked = false;
            LEarringButton.IsChecked = false;
            REarringButton.IsChecked = false;
            LEarring2Button.IsChecked = false;
            REarring2Button.IsChecked = false;

            //Load Current Values for Slider
            CharacterDetails.LArmCheck = true;
        }
        private void LArmButton_Unchecked(object sender, RoutedEventArgs e)
        {
            CharacterDetails.LArmRotate = false;
        }
        #endregion

        #region RArm
        private void RArmRot(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.RArmX.value = (float)quat.X;
            CharacterDetails.RArmY.value = (float)quat.Y;
            CharacterDetails.RArmZ.value = (float)quat.Z;
            CharacterDetails.RArmW.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneSlider.ValueChanged -= RArmRot;
            BoneSlider2.ValueChanged -= RArmRot;
            BoneSlider3.ValueChanged -= RArmRot;
        }

        private void RArmRot2(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.RArmX.value = (float)quat.X;
            CharacterDetails.RArmY.value = (float)quat.Y;
            CharacterDetails.RArmZ.value = (float)quat.Z;
            CharacterDetails.RArmW.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneUpDown.ValueChanged -= RArmRot2;
            BoneUpDown2.ValueChanged -= RArmRot2;
            BoneUpDown3.ValueChanged -= RArmRot2;
        }

        private void RArmButton_Checked(object sender, RoutedEventArgs e)
        {
            //Disable Other Selections
            HeadButton.IsChecked = false;
            NoseButton.IsChecked = false;
            NostrilsButton.IsChecked = false;
            ChinButton.IsChecked = false;
            LOutEyebrowButton.IsChecked = false;
            ROutEyebrowButton.IsChecked = false;
            LInEyebrowButton.IsChecked = false;
            RInEyebrowButton.IsChecked = false;
            LEyeButton.IsChecked = false;
            REyeButton.IsChecked = false;
            LEyelidButton.IsChecked = false;
            REyelidButton.IsChecked = false;
            LLowEyelidButton.IsChecked = false;
            RLowEyelidButton.IsChecked = false;
            LEarButton.IsChecked = false;
            REarButton.IsChecked = false;
            LCheekButton.IsChecked = false;
            RCheekButton.IsChecked = false;
            LMouthButton.IsChecked = false;
            RMouthButton.IsChecked = false;
            LUpLipButton.IsChecked = false;
            RUpLipButton.IsChecked = false;
            LLowLipButton.IsChecked = false;
            RLowLipButton.IsChecked = false;
            NeckButton.IsChecked = false;
            SternumButton.IsChecked = false;
            TorsoButton.IsChecked = false;
            WaistButton.IsChecked = false;
            LShoulderButton.IsChecked = false;
            RShoulderButton.IsChecked = false;
            LClavicleButton.IsChecked = false;
            RClavicleButton.IsChecked = false;
            LBreastButton.IsChecked = false;
            RBreastButton.IsChecked = false;
            LArmButton.IsChecked = false;
            LElbowButton.IsChecked = false;
            RElbowButton.IsChecked = false;
            LForearmButton.IsChecked = false;
            RForearmButton.IsChecked = false;
            LWristButton.IsChecked = false;
            RWristButton.IsChecked = false;
            LHandButton.IsChecked = false;
            RHandButton.IsChecked = false;
            LThumbButton.IsChecked = false;
            RThumbButton.IsChecked = false;
            LThumb2Button.IsChecked = false;
            RThumb2Button.IsChecked = false;
            LIndexButton.IsChecked = false;
            RIndexButton.IsChecked = false;
            LIndex2Button.IsChecked = false;
            RIndex2Button.IsChecked = false;
            LMiddleButton.IsChecked = false;
            RMiddleButton.IsChecked = false;
            LMiddle2Button.IsChecked = false;
            RMiddle2Button.IsChecked = false;
            LRingButton.IsChecked = false;
            RRingButton.IsChecked = false;
            LRing2Button.IsChecked = false;
            RRing2Button.IsChecked = false;
            LPinkyButton.IsChecked = false;
            RPinkyButton.IsChecked = false;
            LPinky2Button.IsChecked = false;
            RPinky2Button.IsChecked = false;
            PelvisButton.IsChecked = false;
            TailButton.IsChecked = false;
            Tail2Button.IsChecked = false;
            Tail3Button.IsChecked = false;
            Tail4Button.IsChecked = false;
            LThighButton.IsChecked = false;
            RThighButton.IsChecked = false;
            LKneeButton.IsChecked = false;
            RKneeButton.IsChecked = false;
            LCalfButton.IsChecked = false;
            RCalfButton.IsChecked = false;
            LFootButton.IsChecked = false;
            RFootButton.IsChecked = false;
            LToesButton.IsChecked = false;
            RToesButton.IsChecked = false;
            LEarringButton.IsChecked = false;
            REarringButton.IsChecked = false;
            LEarring2Button.IsChecked = false;
            REarring2Button.IsChecked = false;

            //Load Current Values for Slider
            CharacterDetails.RArmCheck = true;
        }
        private void RArmButton_Unchecked(object sender, RoutedEventArgs e)
        {
            CharacterDetails.RArmRotate = false;
        }
        #endregion

        #region LElbow
        private void LElbowRot(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.LElbowX.value = (float)quat.X;
            CharacterDetails.LElbowY.value = (float)quat.Y;
            CharacterDetails.LElbowZ.value = (float)quat.Z;
            CharacterDetails.LElbowW.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneSlider.ValueChanged -= LElbowRot;
            BoneSlider2.ValueChanged -= LElbowRot;
            BoneSlider3.ValueChanged -= LElbowRot;
        }

        private void LElbowRot2(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.LElbowX.value = (float)quat.X;
            CharacterDetails.LElbowY.value = (float)quat.Y;
            CharacterDetails.LElbowZ.value = (float)quat.Z;
            CharacterDetails.LElbowW.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneUpDown.ValueChanged -= LElbowRot2;
            BoneUpDown2.ValueChanged -= LElbowRot2;
            BoneUpDown3.ValueChanged -= LElbowRot2;
        }

        private void LElbowButton_Checked(object sender, RoutedEventArgs e)
        {
            //Disable Other Selections
            HeadButton.IsChecked = false;
            NoseButton.IsChecked = false;
            NostrilsButton.IsChecked = false;
            ChinButton.IsChecked = false;
            LOutEyebrowButton.IsChecked = false;
            ROutEyebrowButton.IsChecked = false;
            LInEyebrowButton.IsChecked = false;
            RInEyebrowButton.IsChecked = false;
            LEyeButton.IsChecked = false;
            REyeButton.IsChecked = false;
            LEyelidButton.IsChecked = false;
            REyelidButton.IsChecked = false;
            LLowEyelidButton.IsChecked = false;
            RLowEyelidButton.IsChecked = false;
            LEarButton.IsChecked = false;
            REarButton.IsChecked = false;
            LCheekButton.IsChecked = false;
            RCheekButton.IsChecked = false;
            LMouthButton.IsChecked = false;
            RMouthButton.IsChecked = false;
            LUpLipButton.IsChecked = false;
            RUpLipButton.IsChecked = false;
            LLowLipButton.IsChecked = false;
            RLowLipButton.IsChecked = false;
            NeckButton.IsChecked = false;
            SternumButton.IsChecked = false;
            TorsoButton.IsChecked = false;
            WaistButton.IsChecked = false;
            LShoulderButton.IsChecked = false;
            RShoulderButton.IsChecked = false;
            LClavicleButton.IsChecked = false;
            RClavicleButton.IsChecked = false;
            LBreastButton.IsChecked = false;
            RBreastButton.IsChecked = false;
            LArmButton.IsChecked = false;
            RArmButton.IsChecked = false;
            RElbowButton.IsChecked = false;
            LForearmButton.IsChecked = false;
            RForearmButton.IsChecked = false;
            LWristButton.IsChecked = false;
            RWristButton.IsChecked = false;
            LHandButton.IsChecked = false;
            RHandButton.IsChecked = false;
            LThumbButton.IsChecked = false;
            RThumbButton.IsChecked = false;
            LThumb2Button.IsChecked = false;
            RThumb2Button.IsChecked = false;
            LIndexButton.IsChecked = false;
            RIndexButton.IsChecked = false;
            LIndex2Button.IsChecked = false;
            RIndex2Button.IsChecked = false;
            LMiddleButton.IsChecked = false;
            RMiddleButton.IsChecked = false;
            LMiddle2Button.IsChecked = false;
            RMiddle2Button.IsChecked = false;
            LRingButton.IsChecked = false;
            RRingButton.IsChecked = false;
            LRing2Button.IsChecked = false;
            RRing2Button.IsChecked = false;
            LPinkyButton.IsChecked = false;
            RPinkyButton.IsChecked = false;
            LPinky2Button.IsChecked = false;
            RPinky2Button.IsChecked = false;
            PelvisButton.IsChecked = false;
            TailButton.IsChecked = false;
            Tail2Button.IsChecked = false;
            Tail3Button.IsChecked = false;
            Tail4Button.IsChecked = false;
            LThighButton.IsChecked = false;
            RThighButton.IsChecked = false;
            LKneeButton.IsChecked = false;
            RKneeButton.IsChecked = false;
            LCalfButton.IsChecked = false;
            RCalfButton.IsChecked = false;
            LFootButton.IsChecked = false;
            RFootButton.IsChecked = false;
            LToesButton.IsChecked = false;
            RToesButton.IsChecked = false;
            LEarringButton.IsChecked = false;
            REarringButton.IsChecked = false;
            LEarring2Button.IsChecked = false;
            REarring2Button.IsChecked = false;

            //Load Current Values for Slider
            CharacterDetails.LElbowCheck = true;
        }
        private void LElbowButton_Unchecked(object sender, RoutedEventArgs e)
        {
            CharacterDetails.LElbowRotate = false;
        }
        #endregion

        #region RElbow
        private void RElbowRot(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.RElbowX.value = (float)quat.X;
            CharacterDetails.RElbowY.value = (float)quat.Y;
            CharacterDetails.RElbowZ.value = (float)quat.Z;
            CharacterDetails.RElbowW.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneSlider.ValueChanged -= RElbowRot;
            BoneSlider2.ValueChanged -= RElbowRot;
            BoneSlider3.ValueChanged -= RElbowRot;
        }

        private void RElbowRot2(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.RElbowX.value = (float)quat.X;
            CharacterDetails.RElbowY.value = (float)quat.Y;
            CharacterDetails.RElbowZ.value = (float)quat.Z;
            CharacterDetails.RElbowW.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneUpDown.ValueChanged -= RElbowRot2;
            BoneUpDown2.ValueChanged -= RElbowRot2;
            BoneUpDown3.ValueChanged -= RElbowRot2;
        }

        private void RElbowButton_Checked(object sender, RoutedEventArgs e)
        {
            //Disable Other Selections
            HeadButton.IsChecked = false;
            NoseButton.IsChecked = false;
            NostrilsButton.IsChecked = false;
            ChinButton.IsChecked = false;
            LOutEyebrowButton.IsChecked = false;
            ROutEyebrowButton.IsChecked = false;
            LInEyebrowButton.IsChecked = false;
            RInEyebrowButton.IsChecked = false;
            LEyeButton.IsChecked = false;
            REyeButton.IsChecked = false;
            LEyelidButton.IsChecked = false;
            REyelidButton.IsChecked = false;
            LLowEyelidButton.IsChecked = false;
            RLowEyelidButton.IsChecked = false;
            LEarButton.IsChecked = false;
            REarButton.IsChecked = false;
            LCheekButton.IsChecked = false;
            RCheekButton.IsChecked = false;
            LMouthButton.IsChecked = false;
            RMouthButton.IsChecked = false;
            LUpLipButton.IsChecked = false;
            RUpLipButton.IsChecked = false;
            LLowLipButton.IsChecked = false;
            RLowLipButton.IsChecked = false;
            NeckButton.IsChecked = false;
            SternumButton.IsChecked = false;
            TorsoButton.IsChecked = false;
            WaistButton.IsChecked = false;
            LShoulderButton.IsChecked = false;
            RShoulderButton.IsChecked = false;
            LClavicleButton.IsChecked = false;
            RClavicleButton.IsChecked = false;
            LBreastButton.IsChecked = false;
            RBreastButton.IsChecked = false;
            LArmButton.IsChecked = false;
            RArmButton.IsChecked = false;
            LElbowButton.IsChecked = false;
            LForearmButton.IsChecked = false;
            RForearmButton.IsChecked = false;
            LWristButton.IsChecked = false;
            RWristButton.IsChecked = false;
            LHandButton.IsChecked = false;
            RHandButton.IsChecked = false;
            LThumbButton.IsChecked = false;
            RThumbButton.IsChecked = false;
            LThumb2Button.IsChecked = false;
            RThumb2Button.IsChecked = false;
            LIndexButton.IsChecked = false;
            RIndexButton.IsChecked = false;
            LIndex2Button.IsChecked = false;
            RIndex2Button.IsChecked = false;
            LMiddleButton.IsChecked = false;
            RMiddleButton.IsChecked = false;
            LMiddle2Button.IsChecked = false;
            RMiddle2Button.IsChecked = false;
            LRingButton.IsChecked = false;
            RRingButton.IsChecked = false;
            LRing2Button.IsChecked = false;
            RRing2Button.IsChecked = false;
            LPinkyButton.IsChecked = false;
            RPinkyButton.IsChecked = false;
            LPinky2Button.IsChecked = false;
            RPinky2Button.IsChecked = false;
            PelvisButton.IsChecked = false;
            TailButton.IsChecked = false;
            Tail2Button.IsChecked = false;
            Tail3Button.IsChecked = false;
            Tail4Button.IsChecked = false;
            LThighButton.IsChecked = false;
            RThighButton.IsChecked = false;
            LKneeButton.IsChecked = false;
            RKneeButton.IsChecked = false;
            LCalfButton.IsChecked = false;
            RCalfButton.IsChecked = false;
            LFootButton.IsChecked = false;
            RFootButton.IsChecked = false;
            LToesButton.IsChecked = false;
            RToesButton.IsChecked = false;
            LEarringButton.IsChecked = false;
            REarringButton.IsChecked = false;
            LEarring2Button.IsChecked = false;
            REarring2Button.IsChecked = false;

            //Load Current Values for Slider
            CharacterDetails.RElbowCheck = true;
        }
        private void RElbowButton_Unchecked(object sender, RoutedEventArgs e)
        {
            CharacterDetails.RElbowRotate = false;
        }
        #endregion

        #region LForearm
        private void LForearmRot(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.LForearmX.value = (float)quat.X;
            CharacterDetails.LForearmY.value = (float)quat.Y;
            CharacterDetails.LForearmZ.value = (float)quat.Z;
            CharacterDetails.LForearmW.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneSlider.ValueChanged -= LForearmRot;
            BoneSlider2.ValueChanged -= LForearmRot;
            BoneSlider3.ValueChanged -= LForearmRot;
        }

        private void LForearmRot2(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.LForearmX.value = (float)quat.X;
            CharacterDetails.LForearmY.value = (float)quat.Y;
            CharacterDetails.LForearmZ.value = (float)quat.Z;
            CharacterDetails.LForearmW.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneUpDown.ValueChanged -= LForearmRot2;
            BoneUpDown2.ValueChanged -= LForearmRot2;
            BoneUpDown3.ValueChanged -= LForearmRot2;
        }

        private void LForearmButton_Checked(object sender, RoutedEventArgs e)
        {
            //Disable Other Selections
            HeadButton.IsChecked = false;
            NoseButton.IsChecked = false;
            NostrilsButton.IsChecked = false;
            ChinButton.IsChecked = false;
            LOutEyebrowButton.IsChecked = false;
            ROutEyebrowButton.IsChecked = false;
            LInEyebrowButton.IsChecked = false;
            RInEyebrowButton.IsChecked = false;
            LEyeButton.IsChecked = false;
            REyeButton.IsChecked = false;
            LEyelidButton.IsChecked = false;
            REyelidButton.IsChecked = false;
            LLowEyelidButton.IsChecked = false;
            RLowEyelidButton.IsChecked = false;
            LEarButton.IsChecked = false;
            REarButton.IsChecked = false;
            LCheekButton.IsChecked = false;
            RCheekButton.IsChecked = false;
            LMouthButton.IsChecked = false;
            RMouthButton.IsChecked = false;
            LUpLipButton.IsChecked = false;
            RUpLipButton.IsChecked = false;
            LLowLipButton.IsChecked = false;
            RLowLipButton.IsChecked = false;
            NeckButton.IsChecked = false;
            SternumButton.IsChecked = false;
            TorsoButton.IsChecked = false;
            WaistButton.IsChecked = false;
            LShoulderButton.IsChecked = false;
            RShoulderButton.IsChecked = false;
            LClavicleButton.IsChecked = false;
            RClavicleButton.IsChecked = false;
            LBreastButton.IsChecked = false;
            RBreastButton.IsChecked = false;
            LArmButton.IsChecked = false;
            RArmButton.IsChecked = false;
            LElbowButton.IsChecked = false;
            RElbowButton.IsChecked = false;
            RForearmButton.IsChecked = false;
            LWristButton.IsChecked = false;
            RWristButton.IsChecked = false;
            LHandButton.IsChecked = false;
            RHandButton.IsChecked = false;
            LThumbButton.IsChecked = false;
            RThumbButton.IsChecked = false;
            LThumb2Button.IsChecked = false;
            RThumb2Button.IsChecked = false;
            LIndexButton.IsChecked = false;
            RIndexButton.IsChecked = false;
            LIndex2Button.IsChecked = false;
            RIndex2Button.IsChecked = false;
            LMiddleButton.IsChecked = false;
            RMiddleButton.IsChecked = false;
            LMiddle2Button.IsChecked = false;
            RMiddle2Button.IsChecked = false;
            LRingButton.IsChecked = false;
            RRingButton.IsChecked = false;
            LRing2Button.IsChecked = false;
            RRing2Button.IsChecked = false;
            LPinkyButton.IsChecked = false;
            RPinkyButton.IsChecked = false;
            LPinky2Button.IsChecked = false;
            RPinky2Button.IsChecked = false;
            PelvisButton.IsChecked = false;
            TailButton.IsChecked = false;
            Tail2Button.IsChecked = false;
            Tail3Button.IsChecked = false;
            Tail4Button.IsChecked = false;
            LThighButton.IsChecked = false;
            RThighButton.IsChecked = false;
            LKneeButton.IsChecked = false;
            RKneeButton.IsChecked = false;
            LCalfButton.IsChecked = false;
            RCalfButton.IsChecked = false;
            LFootButton.IsChecked = false;
            RFootButton.IsChecked = false;
            LToesButton.IsChecked = false;
            RToesButton.IsChecked = false;
            LEarringButton.IsChecked = false;
            REarringButton.IsChecked = false;
            LEarring2Button.IsChecked = false;
            REarring2Button.IsChecked = false;

            //Load Current Values for Slider
            CharacterDetails.LForearmCheck = true;
        }
        private void LForearmButton_Unchecked(object sender, RoutedEventArgs e)
        {
            CharacterDetails.LForearmRotate = false;
        }
        #endregion

        #region RForearm
        private void RForearmRot(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.RForearmX.value = (float)quat.X;
            CharacterDetails.RForearmY.value = (float)quat.Y;
            CharacterDetails.RForearmZ.value = (float)quat.Z;
            CharacterDetails.RForearmW.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneSlider.ValueChanged -= RForearmRot;
            BoneSlider2.ValueChanged -= RForearmRot;
            BoneSlider3.ValueChanged -= RForearmRot;
        }

        private void RForearmRot2(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.RForearmX.value = (float)quat.X;
            CharacterDetails.RForearmY.value = (float)quat.Y;
            CharacterDetails.RForearmZ.value = (float)quat.Z;
            CharacterDetails.RForearmW.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneUpDown.ValueChanged -= RForearmRot2;
            BoneUpDown2.ValueChanged -= RForearmRot2;
            BoneUpDown3.ValueChanged -= RForearmRot2;
        }

        private void RForearmButton_Checked(object sender, RoutedEventArgs e)
        {
            //Disable Other Selections
            HeadButton.IsChecked = false;
            NoseButton.IsChecked = false;
            NostrilsButton.IsChecked = false;
            ChinButton.IsChecked = false;
            LOutEyebrowButton.IsChecked = false;
            ROutEyebrowButton.IsChecked = false;
            LInEyebrowButton.IsChecked = false;
            RInEyebrowButton.IsChecked = false;
            LEyeButton.IsChecked = false;
            REyeButton.IsChecked = false;
            LEyelidButton.IsChecked = false;
            REyelidButton.IsChecked = false;
            LLowEyelidButton.IsChecked = false;
            RLowEyelidButton.IsChecked = false;
            LEarButton.IsChecked = false;
            REarButton.IsChecked = false;
            LCheekButton.IsChecked = false;
            RCheekButton.IsChecked = false;
            LMouthButton.IsChecked = false;
            RMouthButton.IsChecked = false;
            LUpLipButton.IsChecked = false;
            RUpLipButton.IsChecked = false;
            LLowLipButton.IsChecked = false;
            RLowLipButton.IsChecked = false;
            NeckButton.IsChecked = false;
            SternumButton.IsChecked = false;
            TorsoButton.IsChecked = false;
            WaistButton.IsChecked = false;
            LShoulderButton.IsChecked = false;
            RShoulderButton.IsChecked = false;
            LClavicleButton.IsChecked = false;
            RClavicleButton.IsChecked = false;
            LBreastButton.IsChecked = false;
            RBreastButton.IsChecked = false;
            LArmButton.IsChecked = false;
            RArmButton.IsChecked = false;
            LElbowButton.IsChecked = false;
            RElbowButton.IsChecked = false;
            LForearmButton.IsChecked = false;
            LWristButton.IsChecked = false;
            RWristButton.IsChecked = false;
            LHandButton.IsChecked = false;
            RHandButton.IsChecked = false;
            LThumbButton.IsChecked = false;
            RThumbButton.IsChecked = false;
            LThumb2Button.IsChecked = false;
            RThumb2Button.IsChecked = false;
            LIndexButton.IsChecked = false;
            RIndexButton.IsChecked = false;
            LIndex2Button.IsChecked = false;
            RIndex2Button.IsChecked = false;
            LMiddleButton.IsChecked = false;
            RMiddleButton.IsChecked = false;
            LMiddle2Button.IsChecked = false;
            RMiddle2Button.IsChecked = false;
            LRingButton.IsChecked = false;
            RRingButton.IsChecked = false;
            LRing2Button.IsChecked = false;
            RRing2Button.IsChecked = false;
            LPinkyButton.IsChecked = false;
            RPinkyButton.IsChecked = false;
            LPinky2Button.IsChecked = false;
            RPinky2Button.IsChecked = false;
            PelvisButton.IsChecked = false;
            TailButton.IsChecked = false;
            Tail2Button.IsChecked = false;
            Tail3Button.IsChecked = false;
            Tail4Button.IsChecked = false;
            LThighButton.IsChecked = false;
            RThighButton.IsChecked = false;
            LKneeButton.IsChecked = false;
            RKneeButton.IsChecked = false;
            LCalfButton.IsChecked = false;
            RCalfButton.IsChecked = false;
            LFootButton.IsChecked = false;
            RFootButton.IsChecked = false;
            LToesButton.IsChecked = false;
            RToesButton.IsChecked = false;
            LEarringButton.IsChecked = false;
            REarringButton.IsChecked = false;
            LEarring2Button.IsChecked = false;
            REarring2Button.IsChecked = false;

            //Load Current Values for Slider
            CharacterDetails.RForearmCheck = true;
        }
        private void RForearmButton_Unchecked(object sender, RoutedEventArgs e)
        {
            CharacterDetails.RForearmRotate = false;
        }
        #endregion

        #region LWrist
        private void LWristRot(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.LWristX.value = (float)quat.X;
            CharacterDetails.LWristY.value = (float)quat.Y;
            CharacterDetails.LWristZ.value = (float)quat.Z;
            CharacterDetails.LWristW.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneSlider.ValueChanged -= LWristRot;
            BoneSlider2.ValueChanged -= LWristRot;
            BoneSlider3.ValueChanged -= LWristRot;
        }

        private void LWristRot2(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.LWristX.value = (float)quat.X;
            CharacterDetails.LWristY.value = (float)quat.Y;
            CharacterDetails.LWristZ.value = (float)quat.Z;
            CharacterDetails.LWristW.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneUpDown.ValueChanged -= LWristRot2;
            BoneUpDown2.ValueChanged -= LWristRot2;
            BoneUpDown3.ValueChanged -= LWristRot2;
        }

        private void LWristButton_Checked(object sender, RoutedEventArgs e)
        {
            //Disable Other Selections
            HeadButton.IsChecked = false;
            NoseButton.IsChecked = false;
            NostrilsButton.IsChecked = false;
            ChinButton.IsChecked = false;
            LOutEyebrowButton.IsChecked = false;
            ROutEyebrowButton.IsChecked = false;
            LInEyebrowButton.IsChecked = false;
            RInEyebrowButton.IsChecked = false;
            LEyeButton.IsChecked = false;
            REyeButton.IsChecked = false;
            LEyelidButton.IsChecked = false;
            REyelidButton.IsChecked = false;
            LLowEyelidButton.IsChecked = false;
            RLowEyelidButton.IsChecked = false;
            LEarButton.IsChecked = false;
            REarButton.IsChecked = false;
            LCheekButton.IsChecked = false;
            RCheekButton.IsChecked = false;
            LMouthButton.IsChecked = false;
            RMouthButton.IsChecked = false;
            LUpLipButton.IsChecked = false;
            RUpLipButton.IsChecked = false;
            LLowLipButton.IsChecked = false;
            RLowLipButton.IsChecked = false;
            NeckButton.IsChecked = false;
            SternumButton.IsChecked = false;
            TorsoButton.IsChecked = false;
            WaistButton.IsChecked = false;
            LShoulderButton.IsChecked = false;
            RShoulderButton.IsChecked = false;
            LClavicleButton.IsChecked = false;
            RClavicleButton.IsChecked = false;
            LBreastButton.IsChecked = false;
            RBreastButton.IsChecked = false;
            LArmButton.IsChecked = false;
            RArmButton.IsChecked = false;
            LElbowButton.IsChecked = false;
            RElbowButton.IsChecked = false;
            LForearmButton.IsChecked = false;
            RForearmButton.IsChecked = false;
            RWristButton.IsChecked = false;
            LHandButton.IsChecked = false;
            RHandButton.IsChecked = false;
            LThumbButton.IsChecked = false;
            RThumbButton.IsChecked = false;
            LThumb2Button.IsChecked = false;
            RThumb2Button.IsChecked = false;
            LIndexButton.IsChecked = false;
            RIndexButton.IsChecked = false;
            LIndex2Button.IsChecked = false;
            RIndex2Button.IsChecked = false;
            LMiddleButton.IsChecked = false;
            RMiddleButton.IsChecked = false;
            LMiddle2Button.IsChecked = false;
            RMiddle2Button.IsChecked = false;
            LRingButton.IsChecked = false;
            RRingButton.IsChecked = false;
            LRing2Button.IsChecked = false;
            RRing2Button.IsChecked = false;
            LPinkyButton.IsChecked = false;
            RPinkyButton.IsChecked = false;
            LPinky2Button.IsChecked = false;
            RPinky2Button.IsChecked = false;
            PelvisButton.IsChecked = false;
            TailButton.IsChecked = false;
            Tail2Button.IsChecked = false;
            Tail3Button.IsChecked = false;
            Tail4Button.IsChecked = false;
            LThighButton.IsChecked = false;
            RThighButton.IsChecked = false;
            LKneeButton.IsChecked = false;
            RKneeButton.IsChecked = false;
            LCalfButton.IsChecked = false;
            RCalfButton.IsChecked = false;
            LFootButton.IsChecked = false;
            RFootButton.IsChecked = false;
            LToesButton.IsChecked = false;
            RToesButton.IsChecked = false;
            LEarringButton.IsChecked = false;
            REarringButton.IsChecked = false;
            LEarring2Button.IsChecked = false;
            REarring2Button.IsChecked = false;

            //Load Current Values for Slider
            CharacterDetails.LWristCheck = true;
        }
        private void LWristButton_Unchecked(object sender, RoutedEventArgs e)
        {
            CharacterDetails.LWristRotate = false;
        }
        #endregion

        #region RWrist
        private void RWristRot(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.RWristX.value = (float)quat.X;
            CharacterDetails.RWristY.value = (float)quat.Y;
            CharacterDetails.RWristZ.value = (float)quat.Z;
            CharacterDetails.RWristW.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneSlider.ValueChanged -= RWristRot;
            BoneSlider2.ValueChanged -= RWristRot;
            BoneSlider3.ValueChanged -= RWristRot;
        }

        private void RWristRot2(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.RWristX.value = (float)quat.X;
            CharacterDetails.RWristY.value = (float)quat.Y;
            CharacterDetails.RWristZ.value = (float)quat.Z;
            CharacterDetails.RWristW.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneUpDown.ValueChanged -= RWristRot2;
            BoneUpDown2.ValueChanged -= RWristRot2;
            BoneUpDown3.ValueChanged -= RWristRot2;
        }

        private void RWristButton_Checked(object sender, RoutedEventArgs e)
        {
            //Disable Other Selections
            HeadButton.IsChecked = false;
            NoseButton.IsChecked = false;
            NostrilsButton.IsChecked = false;
            ChinButton.IsChecked = false;
            LOutEyebrowButton.IsChecked = false;
            ROutEyebrowButton.IsChecked = false;
            LInEyebrowButton.IsChecked = false;
            RInEyebrowButton.IsChecked = false;
            LEyeButton.IsChecked = false;
            REyeButton.IsChecked = false;
            LEyelidButton.IsChecked = false;
            REyelidButton.IsChecked = false;
            LLowEyelidButton.IsChecked = false;
            RLowEyelidButton.IsChecked = false;
            LEarButton.IsChecked = false;
            REarButton.IsChecked = false;
            LCheekButton.IsChecked = false;
            RCheekButton.IsChecked = false;
            LMouthButton.IsChecked = false;
            RMouthButton.IsChecked = false;
            LUpLipButton.IsChecked = false;
            RUpLipButton.IsChecked = false;
            LLowLipButton.IsChecked = false;
            RLowLipButton.IsChecked = false;
            NeckButton.IsChecked = false;
            SternumButton.IsChecked = false;
            TorsoButton.IsChecked = false;
            WaistButton.IsChecked = false;
            LShoulderButton.IsChecked = false;
            RShoulderButton.IsChecked = false;
            LClavicleButton.IsChecked = false;
            RClavicleButton.IsChecked = false;
            LBreastButton.IsChecked = false;
            RBreastButton.IsChecked = false;
            LArmButton.IsChecked = false;
            RArmButton.IsChecked = false;
            LElbowButton.IsChecked = false;
            RElbowButton.IsChecked = false;
            LForearmButton.IsChecked = false;
            RForearmButton.IsChecked = false;
            LWristButton.IsChecked = false;
            LHandButton.IsChecked = false;
            RHandButton.IsChecked = false;
            LThumbButton.IsChecked = false;
            RThumbButton.IsChecked = false;
            LThumb2Button.IsChecked = false;
            RThumb2Button.IsChecked = false;
            LIndexButton.IsChecked = false;
            RIndexButton.IsChecked = false;
            LIndex2Button.IsChecked = false;
            RIndex2Button.IsChecked = false;
            LMiddleButton.IsChecked = false;
            RMiddleButton.IsChecked = false;
            LMiddle2Button.IsChecked = false;
            RMiddle2Button.IsChecked = false;
            LRingButton.IsChecked = false;
            RRingButton.IsChecked = false;
            LRing2Button.IsChecked = false;
            RRing2Button.IsChecked = false;
            LPinkyButton.IsChecked = false;
            RPinkyButton.IsChecked = false;
            LPinky2Button.IsChecked = false;
            RPinky2Button.IsChecked = false;
            PelvisButton.IsChecked = false;
            TailButton.IsChecked = false;
            Tail2Button.IsChecked = false;
            Tail3Button.IsChecked = false;
            Tail4Button.IsChecked = false;
            LThighButton.IsChecked = false;
            RThighButton.IsChecked = false;
            LKneeButton.IsChecked = false;
            RKneeButton.IsChecked = false;
            LCalfButton.IsChecked = false;
            RCalfButton.IsChecked = false;
            LFootButton.IsChecked = false;
            RFootButton.IsChecked = false;
            LToesButton.IsChecked = false;
            RToesButton.IsChecked = false;
            LEarringButton.IsChecked = false;
            REarringButton.IsChecked = false;
            LEarring2Button.IsChecked = false;
            REarring2Button.IsChecked = false;

            //Load Current Values for Slider
            CharacterDetails.RWristCheck = true;
        }
        private void RWristButton_Unchecked(object sender, RoutedEventArgs e)
        {
            CharacterDetails.RWristRotate = false;
        }
        #endregion

        #region LHand
        private void LHandRot(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.LHandX.value = (float)quat.X;
            CharacterDetails.LHandY.value = (float)quat.Y;
            CharacterDetails.LHandZ.value = (float)quat.Z;
            CharacterDetails.LHandW.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneSlider.ValueChanged -= LHandRot;
            BoneSlider2.ValueChanged -= LHandRot;
            BoneSlider3.ValueChanged -= LHandRot;
        }

        private void LHandRot2(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.LHandX.value = (float)quat.X;
            CharacterDetails.LHandY.value = (float)quat.Y;
            CharacterDetails.LHandZ.value = (float)quat.Z;
            CharacterDetails.LHandW.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneUpDown.ValueChanged -= LHandRot2;
            BoneUpDown2.ValueChanged -= LHandRot2;
            BoneUpDown3.ValueChanged -= LHandRot2;
        }

        private void LHandButton_Checked(object sender, RoutedEventArgs e)
        {
            //Disable Other Selections
            HeadButton.IsChecked = false;
            NoseButton.IsChecked = false;
            NostrilsButton.IsChecked = false;
            ChinButton.IsChecked = false;
            LOutEyebrowButton.IsChecked = false;
            ROutEyebrowButton.IsChecked = false;
            LInEyebrowButton.IsChecked = false;
            RInEyebrowButton.IsChecked = false;
            LEyeButton.IsChecked = false;
            REyeButton.IsChecked = false;
            LEyelidButton.IsChecked = false;
            REyelidButton.IsChecked = false;
            LLowEyelidButton.IsChecked = false;
            RLowEyelidButton.IsChecked = false;
            LEarButton.IsChecked = false;
            REarButton.IsChecked = false;
            LCheekButton.IsChecked = false;
            RCheekButton.IsChecked = false;
            LMouthButton.IsChecked = false;
            RMouthButton.IsChecked = false;
            LUpLipButton.IsChecked = false;
            RUpLipButton.IsChecked = false;
            LLowLipButton.IsChecked = false;
            RLowLipButton.IsChecked = false;
            NeckButton.IsChecked = false;
            SternumButton.IsChecked = false;
            TorsoButton.IsChecked = false;
            WaistButton.IsChecked = false;
            LShoulderButton.IsChecked = false;
            RShoulderButton.IsChecked = false;
            LClavicleButton.IsChecked = false;
            RClavicleButton.IsChecked = false;
            LBreastButton.IsChecked = false;
            RBreastButton.IsChecked = false;
            LArmButton.IsChecked = false;
            RArmButton.IsChecked = false;
            LElbowButton.IsChecked = false;
            RElbowButton.IsChecked = false;
            LForearmButton.IsChecked = false;
            RForearmButton.IsChecked = false;
            LWristButton.IsChecked = false;
            RWristButton.IsChecked = false;
            RHandButton.IsChecked = false;
            LThumbButton.IsChecked = false;
            RThumbButton.IsChecked = false;
            LThumb2Button.IsChecked = false;
            RThumb2Button.IsChecked = false;
            LIndexButton.IsChecked = false;
            RIndexButton.IsChecked = false;
            LIndex2Button.IsChecked = false;
            RIndex2Button.IsChecked = false;
            LMiddleButton.IsChecked = false;
            RMiddleButton.IsChecked = false;
            LMiddle2Button.IsChecked = false;
            RMiddle2Button.IsChecked = false;
            LRingButton.IsChecked = false;
            RRingButton.IsChecked = false;
            LRing2Button.IsChecked = false;
            RRing2Button.IsChecked = false;
            LPinkyButton.IsChecked = false;
            RPinkyButton.IsChecked = false;
            LPinky2Button.IsChecked = false;
            RPinky2Button.IsChecked = false;
            PelvisButton.IsChecked = false;
            TailButton.IsChecked = false;
            Tail2Button.IsChecked = false;
            Tail3Button.IsChecked = false;
            Tail4Button.IsChecked = false;
            LThighButton.IsChecked = false;
            RThighButton.IsChecked = false;
            LKneeButton.IsChecked = false;
            RKneeButton.IsChecked = false;
            LCalfButton.IsChecked = false;
            RCalfButton.IsChecked = false;
            LFootButton.IsChecked = false;
            RFootButton.IsChecked = false;
            LToesButton.IsChecked = false;
            RToesButton.IsChecked = false;
            LEarringButton.IsChecked = false;
            REarringButton.IsChecked = false;
            LEarring2Button.IsChecked = false;
            REarring2Button.IsChecked = false;

            //Load Current Values for Slider
            CharacterDetails.LHandCheck = true;
        }
        private void LHandButton_Unchecked(object sender, RoutedEventArgs e)
        {
            CharacterDetails.LHandRotate = false;
        }
        #endregion

        #region RHand
        private void RHandRot(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.RHandX.value = (float)quat.X;
            CharacterDetails.RHandY.value = (float)quat.Y;
            CharacterDetails.RHandZ.value = (float)quat.Z;
            CharacterDetails.RHandW.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneSlider.ValueChanged -= RHandRot;
            BoneSlider2.ValueChanged -= RHandRot;
            BoneSlider3.ValueChanged -= RHandRot;
        }

        private void RHandRot2(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.RHandX.value = (float)quat.X;
            CharacterDetails.RHandY.value = (float)quat.Y;
            CharacterDetails.RHandZ.value = (float)quat.Z;
            CharacterDetails.RHandW.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneUpDown.ValueChanged -= RHandRot2;
            BoneUpDown2.ValueChanged -= RHandRot2;
            BoneUpDown3.ValueChanged -= RHandRot2;
        }

        private void RHandButton_Checked(object sender, RoutedEventArgs e)
        {
            //Disable Other Selections
            HeadButton.IsChecked = false;
            NoseButton.IsChecked = false;
            NostrilsButton.IsChecked = false;
            ChinButton.IsChecked = false;
            LOutEyebrowButton.IsChecked = false;
            ROutEyebrowButton.IsChecked = false;
            LInEyebrowButton.IsChecked = false;
            RInEyebrowButton.IsChecked = false;
            LEyeButton.IsChecked = false;
            REyeButton.IsChecked = false;
            LEyelidButton.IsChecked = false;
            REyelidButton.IsChecked = false;
            LLowEyelidButton.IsChecked = false;
            RLowEyelidButton.IsChecked = false;
            LEarButton.IsChecked = false;
            REarButton.IsChecked = false;
            LCheekButton.IsChecked = false;
            RCheekButton.IsChecked = false;
            LMouthButton.IsChecked = false;
            RMouthButton.IsChecked = false;
            LUpLipButton.IsChecked = false;
            RUpLipButton.IsChecked = false;
            LLowLipButton.IsChecked = false;
            RLowLipButton.IsChecked = false;
            NeckButton.IsChecked = false;
            SternumButton.IsChecked = false;
            TorsoButton.IsChecked = false;
            WaistButton.IsChecked = false;
            LShoulderButton.IsChecked = false;
            RShoulderButton.IsChecked = false;
            LClavicleButton.IsChecked = false;
            RClavicleButton.IsChecked = false;
            LBreastButton.IsChecked = false;
            RBreastButton.IsChecked = false;
            LArmButton.IsChecked = false;
            RArmButton.IsChecked = false;
            LElbowButton.IsChecked = false;
            RElbowButton.IsChecked = false;
            LForearmButton.IsChecked = false;
            RForearmButton.IsChecked = false;
            LWristButton.IsChecked = false;
            RWristButton.IsChecked = false;
            LHandButton.IsChecked = false;
            LThumbButton.IsChecked = false;
            RThumbButton.IsChecked = false;
            LThumb2Button.IsChecked = false;
            RThumb2Button.IsChecked = false;
            LIndexButton.IsChecked = false;
            RIndexButton.IsChecked = false;
            LIndex2Button.IsChecked = false;
            RIndex2Button.IsChecked = false;
            LMiddleButton.IsChecked = false;
            RMiddleButton.IsChecked = false;
            LMiddle2Button.IsChecked = false;
            RMiddle2Button.IsChecked = false;
            LRingButton.IsChecked = false;
            RRingButton.IsChecked = false;
            LRing2Button.IsChecked = false;
            RRing2Button.IsChecked = false;
            LPinkyButton.IsChecked = false;
            RPinkyButton.IsChecked = false;
            LPinky2Button.IsChecked = false;
            RPinky2Button.IsChecked = false;
            PelvisButton.IsChecked = false;
            TailButton.IsChecked = false;
            Tail2Button.IsChecked = false;
            Tail3Button.IsChecked = false;
            Tail4Button.IsChecked = false;
            LThighButton.IsChecked = false;
            RThighButton.IsChecked = false;
            LKneeButton.IsChecked = false;
            RKneeButton.IsChecked = false;
            LCalfButton.IsChecked = false;
            RCalfButton.IsChecked = false;
            LFootButton.IsChecked = false;
            RFootButton.IsChecked = false;
            LToesButton.IsChecked = false;
            RToesButton.IsChecked = false;
            LEarringButton.IsChecked = false;
            REarringButton.IsChecked = false;
            LEarring2Button.IsChecked = false;
            REarring2Button.IsChecked = false;

            //Load Current Values for Slider
            CharacterDetails.RHandCheck = true;
        }
        private void RHandButton_Unchecked(object sender, RoutedEventArgs e)
        {
            CharacterDetails.RHandRotate = false;
        }
        #endregion

        #region LThumb
        private void LThumbRot(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.LThumbX.value = (float)quat.X;
            CharacterDetails.LThumbY.value = (float)quat.Y;
            CharacterDetails.LThumbZ.value = (float)quat.Z;
            CharacterDetails.LThumbW.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneSlider.ValueChanged -= LThumbRot;
            BoneSlider2.ValueChanged -= LThumbRot;
            BoneSlider3.ValueChanged -= LThumbRot;
        }

        private void LThumbRot2(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.LThumbX.value = (float)quat.X;
            CharacterDetails.LThumbY.value = (float)quat.Y;
            CharacterDetails.LThumbZ.value = (float)quat.Z;
            CharacterDetails.LThumbW.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneUpDown.ValueChanged -= LThumbRot2;
            BoneUpDown2.ValueChanged -= LThumbRot2;
            BoneUpDown3.ValueChanged -= LThumbRot2;
        }

        private void LThumbButton_Checked(object sender, RoutedEventArgs e)
        {
            //Disable Other Selections
            HeadButton.IsChecked = false;
            NoseButton.IsChecked = false;
            NostrilsButton.IsChecked = false;
            ChinButton.IsChecked = false;
            LOutEyebrowButton.IsChecked = false;
            ROutEyebrowButton.IsChecked = false;
            LInEyebrowButton.IsChecked = false;
            RInEyebrowButton.IsChecked = false;
            LEyeButton.IsChecked = false;
            REyeButton.IsChecked = false;
            LEyelidButton.IsChecked = false;
            REyelidButton.IsChecked = false;
            LLowEyelidButton.IsChecked = false;
            RLowEyelidButton.IsChecked = false;
            LEarButton.IsChecked = false;
            REarButton.IsChecked = false;
            LCheekButton.IsChecked = false;
            RCheekButton.IsChecked = false;
            LMouthButton.IsChecked = false;
            RMouthButton.IsChecked = false;
            LUpLipButton.IsChecked = false;
            RUpLipButton.IsChecked = false;
            LLowLipButton.IsChecked = false;
            RLowLipButton.IsChecked = false;
            NeckButton.IsChecked = false;
            SternumButton.IsChecked = false;
            TorsoButton.IsChecked = false;
            WaistButton.IsChecked = false;
            LShoulderButton.IsChecked = false;
            RShoulderButton.IsChecked = false;
            LClavicleButton.IsChecked = false;
            RClavicleButton.IsChecked = false;
            LBreastButton.IsChecked = false;
            RBreastButton.IsChecked = false;
            LArmButton.IsChecked = false;
            RArmButton.IsChecked = false;
            LElbowButton.IsChecked = false;
            RElbowButton.IsChecked = false;
            LForearmButton.IsChecked = false;
            RForearmButton.IsChecked = false;
            LWristButton.IsChecked = false;
            RWristButton.IsChecked = false;
            LHandButton.IsChecked = false;
            RHandButton.IsChecked = false;
            RThumbButton.IsChecked = false;
            LThumb2Button.IsChecked = false;
            RThumb2Button.IsChecked = false;
            LIndexButton.IsChecked = false;
            RIndexButton.IsChecked = false;
            LIndex2Button.IsChecked = false;
            RIndex2Button.IsChecked = false;
            LMiddleButton.IsChecked = false;
            RMiddleButton.IsChecked = false;
            LMiddle2Button.IsChecked = false;
            RMiddle2Button.IsChecked = false;
            LRingButton.IsChecked = false;
            RRingButton.IsChecked = false;
            LRing2Button.IsChecked = false;
            RRing2Button.IsChecked = false;
            LPinkyButton.IsChecked = false;
            RPinkyButton.IsChecked = false;
            LPinky2Button.IsChecked = false;
            RPinky2Button.IsChecked = false;
            PelvisButton.IsChecked = false;
            TailButton.IsChecked = false;
            Tail2Button.IsChecked = false;
            Tail3Button.IsChecked = false;
            Tail4Button.IsChecked = false;
            LThighButton.IsChecked = false;
            RThighButton.IsChecked = false;
            LKneeButton.IsChecked = false;
            RKneeButton.IsChecked = false;
            LCalfButton.IsChecked = false;
            RCalfButton.IsChecked = false;
            LFootButton.IsChecked = false;
            RFootButton.IsChecked = false;
            LToesButton.IsChecked = false;
            RToesButton.IsChecked = false;
            LEarringButton.IsChecked = false;
            REarringButton.IsChecked = false;
            LEarring2Button.IsChecked = false;
            REarring2Button.IsChecked = false;

            //Load Current Values for Slider
            CharacterDetails.LThumbCheck = true;
        }
        private void LThumbButton_Unchecked(object sender, RoutedEventArgs e)
        {
            CharacterDetails.LThumbRotate = false;
        }
        #endregion

        #region RThumb
        private void RThumbRot(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.RThumbX.value = (float)quat.X;
            CharacterDetails.RThumbY.value = (float)quat.Y;
            CharacterDetails.RThumbZ.value = (float)quat.Z;
            CharacterDetails.RThumbW.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneSlider.ValueChanged -= RThumbRot;
            BoneSlider2.ValueChanged -= RThumbRot;
            BoneSlider3.ValueChanged -= RThumbRot;
        }

        private void RThumbRot2(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.RThumbX.value = (float)quat.X;
            CharacterDetails.RThumbY.value = (float)quat.Y;
            CharacterDetails.RThumbZ.value = (float)quat.Z;
            CharacterDetails.RThumbW.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneUpDown.ValueChanged -= RThumbRot2;
            BoneUpDown2.ValueChanged -= RThumbRot2;
            BoneUpDown3.ValueChanged -= RThumbRot2;
        }

        private void RThumbButton_Checked(object sender, RoutedEventArgs e)
        {
            //Disable Other Selections
            HeadButton.IsChecked = false;
            NoseButton.IsChecked = false;
            NostrilsButton.IsChecked = false;
            ChinButton.IsChecked = false;
            LOutEyebrowButton.IsChecked = false;
            ROutEyebrowButton.IsChecked = false;
            LInEyebrowButton.IsChecked = false;
            RInEyebrowButton.IsChecked = false;
            LEyeButton.IsChecked = false;
            REyeButton.IsChecked = false;
            LEyelidButton.IsChecked = false;
            REyelidButton.IsChecked = false;
            LLowEyelidButton.IsChecked = false;
            RLowEyelidButton.IsChecked = false;
            LEarButton.IsChecked = false;
            REarButton.IsChecked = false;
            LCheekButton.IsChecked = false;
            RCheekButton.IsChecked = false;
            LMouthButton.IsChecked = false;
            RMouthButton.IsChecked = false;
            LUpLipButton.IsChecked = false;
            RUpLipButton.IsChecked = false;
            LLowLipButton.IsChecked = false;
            RLowLipButton.IsChecked = false;
            NeckButton.IsChecked = false;
            SternumButton.IsChecked = false;
            TorsoButton.IsChecked = false;
            WaistButton.IsChecked = false;
            LShoulderButton.IsChecked = false;
            RShoulderButton.IsChecked = false;
            LClavicleButton.IsChecked = false;
            RClavicleButton.IsChecked = false;
            LBreastButton.IsChecked = false;
            RBreastButton.IsChecked = false;
            LArmButton.IsChecked = false;
            RArmButton.IsChecked = false;
            LElbowButton.IsChecked = false;
            RElbowButton.IsChecked = false;
            LForearmButton.IsChecked = false;
            RForearmButton.IsChecked = false;
            LWristButton.IsChecked = false;
            RWristButton.IsChecked = false;
            LHandButton.IsChecked = false;
            RHandButton.IsChecked = false;
            LThumbButton.IsChecked = false;
            LThumb2Button.IsChecked = false;
            RThumb2Button.IsChecked = false;
            LIndexButton.IsChecked = false;
            RIndexButton.IsChecked = false;
            LIndex2Button.IsChecked = false;
            RIndex2Button.IsChecked = false;
            LMiddleButton.IsChecked = false;
            RMiddleButton.IsChecked = false;
            LMiddle2Button.IsChecked = false;
            RMiddle2Button.IsChecked = false;
            LRingButton.IsChecked = false;
            RRingButton.IsChecked = false;
            LRing2Button.IsChecked = false;
            RRing2Button.IsChecked = false;
            LPinkyButton.IsChecked = false;
            RPinkyButton.IsChecked = false;
            LPinky2Button.IsChecked = false;
            RPinky2Button.IsChecked = false;
            PelvisButton.IsChecked = false;
            TailButton.IsChecked = false;
            Tail2Button.IsChecked = false;
            Tail3Button.IsChecked = false;
            Tail4Button.IsChecked = false;
            LThighButton.IsChecked = false;
            RThighButton.IsChecked = false;
            LKneeButton.IsChecked = false;
            RKneeButton.IsChecked = false;
            LCalfButton.IsChecked = false;
            RCalfButton.IsChecked = false;
            LFootButton.IsChecked = false;
            RFootButton.IsChecked = false;
            LToesButton.IsChecked = false;
            RToesButton.IsChecked = false;
            LEarringButton.IsChecked = false;
            REarringButton.IsChecked = false;
            LEarring2Button.IsChecked = false;
            REarring2Button.IsChecked = false;

            //Load Current Values for Slider
            CharacterDetails.RThumbCheck = true;
        }
        private void RThumbButton_Unchecked(object sender, RoutedEventArgs e)
        {
            CharacterDetails.RThumbRotate = false;
        }
        #endregion

        #region LThumb2
        private void LThumb2Rot(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.LThumb2X.value = (float)quat.X;
            CharacterDetails.LThumb2Y.value = (float)quat.Y;
            CharacterDetails.LThumb2Z.value = (float)quat.Z;
            CharacterDetails.LThumb2W.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneSlider.ValueChanged -= LThumb2Rot;
            BoneSlider2.ValueChanged -= LThumb2Rot;
            BoneSlider3.ValueChanged -= LThumb2Rot;
        }

        private void LThumb2Rot2(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.LThumb2X.value = (float)quat.X;
            CharacterDetails.LThumb2Y.value = (float)quat.Y;
            CharacterDetails.LThumb2Z.value = (float)quat.Z;
            CharacterDetails.LThumb2W.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneUpDown.ValueChanged -= LThumb2Rot2;
            BoneUpDown2.ValueChanged -= LThumb2Rot2;
            BoneUpDown3.ValueChanged -= LThumb2Rot2;
        }

        private void LThumb2Button_Checked(object sender, RoutedEventArgs e)
        {
            //Disable Other Selections
            HeadButton.IsChecked = false;
            NoseButton.IsChecked = false;
            NostrilsButton.IsChecked = false;
            ChinButton.IsChecked = false;
            LOutEyebrowButton.IsChecked = false;
            ROutEyebrowButton.IsChecked = false;
            LInEyebrowButton.IsChecked = false;
            RInEyebrowButton.IsChecked = false;
            LEyeButton.IsChecked = false;
            REyeButton.IsChecked = false;
            LEyelidButton.IsChecked = false;
            REyelidButton.IsChecked = false;
            LLowEyelidButton.IsChecked = false;
            RLowEyelidButton.IsChecked = false;
            LEarButton.IsChecked = false;
            REarButton.IsChecked = false;
            LCheekButton.IsChecked = false;
            RCheekButton.IsChecked = false;
            LMouthButton.IsChecked = false;
            RMouthButton.IsChecked = false;
            LUpLipButton.IsChecked = false;
            RUpLipButton.IsChecked = false;
            LLowLipButton.IsChecked = false;
            RLowLipButton.IsChecked = false;
            NeckButton.IsChecked = false;
            SternumButton.IsChecked = false;
            TorsoButton.IsChecked = false;
            WaistButton.IsChecked = false;
            LShoulderButton.IsChecked = false;
            RShoulderButton.IsChecked = false;
            LClavicleButton.IsChecked = false;
            RClavicleButton.IsChecked = false;
            LBreastButton.IsChecked = false;
            RBreastButton.IsChecked = false;
            LArmButton.IsChecked = false;
            RArmButton.IsChecked = false;
            LElbowButton.IsChecked = false;
            RElbowButton.IsChecked = false;
            LForearmButton.IsChecked = false;
            RForearmButton.IsChecked = false;
            LWristButton.IsChecked = false;
            RWristButton.IsChecked = false;
            LHandButton.IsChecked = false;
            RHandButton.IsChecked = false;
            LThumbButton.IsChecked = false;
            RThumbButton.IsChecked = false;
            RThumb2Button.IsChecked = false;
            LIndexButton.IsChecked = false;
            RIndexButton.IsChecked = false;
            LIndex2Button.IsChecked = false;
            RIndex2Button.IsChecked = false;
            LMiddleButton.IsChecked = false;
            RMiddleButton.IsChecked = false;
            LMiddle2Button.IsChecked = false;
            RMiddle2Button.IsChecked = false;
            LRingButton.IsChecked = false;
            RRingButton.IsChecked = false;
            LRing2Button.IsChecked = false;
            RRing2Button.IsChecked = false;
            LPinkyButton.IsChecked = false;
            RPinkyButton.IsChecked = false;
            LPinky2Button.IsChecked = false;
            RPinky2Button.IsChecked = false;
            PelvisButton.IsChecked = false;
            TailButton.IsChecked = false;
            Tail2Button.IsChecked = false;
            Tail3Button.IsChecked = false;
            Tail4Button.IsChecked = false;
            LThighButton.IsChecked = false;
            RThighButton.IsChecked = false;
            LKneeButton.IsChecked = false;
            RKneeButton.IsChecked = false;
            LCalfButton.IsChecked = false;
            RCalfButton.IsChecked = false;
            LFootButton.IsChecked = false;
            RFootButton.IsChecked = false;
            LToesButton.IsChecked = false;
            RToesButton.IsChecked = false;
            LEarringButton.IsChecked = false;
            REarringButton.IsChecked = false;
            LEarring2Button.IsChecked = false;
            REarring2Button.IsChecked = false;

            //Load Current Values for Slider
            CharacterDetails.LThumb2Check = true;
        }
        private void LThumb2Button_Unchecked(object sender, RoutedEventArgs e)
        {
            CharacterDetails.LThumb2Rotate = false;
        }
        #endregion

        #region RThumb2
        private void RThumb2Rot(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.RThumb2X.value = (float)quat.X;
            CharacterDetails.RThumb2Y.value = (float)quat.Y;
            CharacterDetails.RThumb2Z.value = (float)quat.Z;
            CharacterDetails.RThumb2W.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneSlider.ValueChanged -= RThumb2Rot;
            BoneSlider2.ValueChanged -= RThumb2Rot;
            BoneSlider3.ValueChanged -= RThumb2Rot;
        }

        private void RThumb2Rot2(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.RThumb2X.value = (float)quat.X;
            CharacterDetails.RThumb2Y.value = (float)quat.Y;
            CharacterDetails.RThumb2Z.value = (float)quat.Z;
            CharacterDetails.RThumb2W.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneUpDown.ValueChanged -= RThumb2Rot2;
            BoneUpDown2.ValueChanged -= RThumb2Rot2;
            BoneUpDown3.ValueChanged -= RThumb2Rot2;
        }

        private void RThumb2Button_Checked(object sender, RoutedEventArgs e)
        {
            //Disable Other Selections
            HeadButton.IsChecked = false;
            NoseButton.IsChecked = false;
            NostrilsButton.IsChecked = false;
            ChinButton.IsChecked = false;
            LOutEyebrowButton.IsChecked = false;
            ROutEyebrowButton.IsChecked = false;
            LInEyebrowButton.IsChecked = false;
            RInEyebrowButton.IsChecked = false;
            LEyeButton.IsChecked = false;
            REyeButton.IsChecked = false;
            LEyelidButton.IsChecked = false;
            REyelidButton.IsChecked = false;
            LLowEyelidButton.IsChecked = false;
            RLowEyelidButton.IsChecked = false;
            LEarButton.IsChecked = false;
            REarButton.IsChecked = false;
            LCheekButton.IsChecked = false;
            RCheekButton.IsChecked = false;
            LMouthButton.IsChecked = false;
            RMouthButton.IsChecked = false;
            LUpLipButton.IsChecked = false;
            RUpLipButton.IsChecked = false;
            LLowLipButton.IsChecked = false;
            RLowLipButton.IsChecked = false;
            NeckButton.IsChecked = false;
            SternumButton.IsChecked = false;
            TorsoButton.IsChecked = false;
            WaistButton.IsChecked = false;
            LShoulderButton.IsChecked = false;
            RShoulderButton.IsChecked = false;
            LClavicleButton.IsChecked = false;
            RClavicleButton.IsChecked = false;
            LBreastButton.IsChecked = false;
            RBreastButton.IsChecked = false;
            LArmButton.IsChecked = false;
            RArmButton.IsChecked = false;
            LElbowButton.IsChecked = false;
            RElbowButton.IsChecked = false;
            LForearmButton.IsChecked = false;
            RForearmButton.IsChecked = false;
            LWristButton.IsChecked = false;
            RWristButton.IsChecked = false;
            LHandButton.IsChecked = false;
            RHandButton.IsChecked = false;
            LThumbButton.IsChecked = false;
            RThumbButton.IsChecked = false;
            LThumb2Button.IsChecked = false;
            LIndexButton.IsChecked = false;
            RIndexButton.IsChecked = false;
            LIndex2Button.IsChecked = false;
            RIndex2Button.IsChecked = false;
            LMiddleButton.IsChecked = false;
            RMiddleButton.IsChecked = false;
            LMiddle2Button.IsChecked = false;
            RMiddle2Button.IsChecked = false;
            LRingButton.IsChecked = false;
            RRingButton.IsChecked = false;
            LRing2Button.IsChecked = false;
            RRing2Button.IsChecked = false;
            LPinkyButton.IsChecked = false;
            RPinkyButton.IsChecked = false;
            LPinky2Button.IsChecked = false;
            RPinky2Button.IsChecked = false;
            PelvisButton.IsChecked = false;
            TailButton.IsChecked = false;
            Tail2Button.IsChecked = false;
            Tail3Button.IsChecked = false;
            Tail4Button.IsChecked = false;
            LThighButton.IsChecked = false;
            RThighButton.IsChecked = false;
            LKneeButton.IsChecked = false;
            RKneeButton.IsChecked = false;
            LCalfButton.IsChecked = false;
            RCalfButton.IsChecked = false;
            LFootButton.IsChecked = false;
            RFootButton.IsChecked = false;
            LToesButton.IsChecked = false;
            RToesButton.IsChecked = false;
            LEarringButton.IsChecked = false;
            REarringButton.IsChecked = false;
            LEarring2Button.IsChecked = false;
            REarring2Button.IsChecked = false;

            //Load Current Values for Slider
            CharacterDetails.RThumb2Check = true;
        }
        private void RThumb2Button_Unchecked(object sender, RoutedEventArgs e)
        {
            CharacterDetails.RThumb2Rotate = false;
        }
        #endregion

        #region LIndex
        private void LIndexRot(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.LIndexX.value = (float)quat.X;
            CharacterDetails.LIndexY.value = (float)quat.Y;
            CharacterDetails.LIndexZ.value = (float)quat.Z;
            CharacterDetails.LIndexW.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneSlider.ValueChanged -= LIndexRot;
            BoneSlider2.ValueChanged -= LIndexRot;
            BoneSlider3.ValueChanged -= LIndexRot;
        }

        private void LIndexRot2(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.LIndexX.value = (float)quat.X;
            CharacterDetails.LIndexY.value = (float)quat.Y;
            CharacterDetails.LIndexZ.value = (float)quat.Z;
            CharacterDetails.LIndexW.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneUpDown.ValueChanged -= LIndexRot2;
            BoneUpDown2.ValueChanged -= LIndexRot2;
            BoneUpDown3.ValueChanged -= LIndexRot2;
        }

        private void LIndexButton_Checked(object sender, RoutedEventArgs e)
        {
            //Disable Other Selections
            HeadButton.IsChecked = false;
            NoseButton.IsChecked = false;
            NostrilsButton.IsChecked = false;
            ChinButton.IsChecked = false;
            LOutEyebrowButton.IsChecked = false;
            ROutEyebrowButton.IsChecked = false;
            LInEyebrowButton.IsChecked = false;
            RInEyebrowButton.IsChecked = false;
            LEyeButton.IsChecked = false;
            REyeButton.IsChecked = false;
            LEyelidButton.IsChecked = false;
            REyelidButton.IsChecked = false;
            LLowEyelidButton.IsChecked = false;
            RLowEyelidButton.IsChecked = false;
            LEarButton.IsChecked = false;
            REarButton.IsChecked = false;
            LCheekButton.IsChecked = false;
            RCheekButton.IsChecked = false;
            LMouthButton.IsChecked = false;
            RMouthButton.IsChecked = false;
            LUpLipButton.IsChecked = false;
            RUpLipButton.IsChecked = false;
            LLowLipButton.IsChecked = false;
            RLowLipButton.IsChecked = false;
            NeckButton.IsChecked = false;
            SternumButton.IsChecked = false;
            TorsoButton.IsChecked = false;
            WaistButton.IsChecked = false;
            LShoulderButton.IsChecked = false;
            RShoulderButton.IsChecked = false;
            LClavicleButton.IsChecked = false;
            RClavicleButton.IsChecked = false;
            LBreastButton.IsChecked = false;
            RBreastButton.IsChecked = false;
            LArmButton.IsChecked = false;
            RArmButton.IsChecked = false;
            LElbowButton.IsChecked = false;
            RElbowButton.IsChecked = false;
            LForearmButton.IsChecked = false;
            RForearmButton.IsChecked = false;
            LWristButton.IsChecked = false;
            RWristButton.IsChecked = false;
            LHandButton.IsChecked = false;
            RHandButton.IsChecked = false;
            LThumbButton.IsChecked = false;
            RThumbButton.IsChecked = false;
            LThumb2Button.IsChecked = false;
            RThumb2Button.IsChecked = false;
            RIndexButton.IsChecked = false;
            LIndex2Button.IsChecked = false;
            RIndex2Button.IsChecked = false;
            LMiddleButton.IsChecked = false;
            RMiddleButton.IsChecked = false;
            LMiddle2Button.IsChecked = false;
            RMiddle2Button.IsChecked = false;
            LRingButton.IsChecked = false;
            RRingButton.IsChecked = false;
            LRing2Button.IsChecked = false;
            RRing2Button.IsChecked = false;
            LPinkyButton.IsChecked = false;
            RPinkyButton.IsChecked = false;
            LPinky2Button.IsChecked = false;
            RPinky2Button.IsChecked = false;
            PelvisButton.IsChecked = false;
            TailButton.IsChecked = false;
            Tail2Button.IsChecked = false;
            Tail3Button.IsChecked = false;
            Tail4Button.IsChecked = false;
            LThighButton.IsChecked = false;
            RThighButton.IsChecked = false;
            LKneeButton.IsChecked = false;
            RKneeButton.IsChecked = false;
            LCalfButton.IsChecked = false;
            RCalfButton.IsChecked = false;
            LFootButton.IsChecked = false;
            RFootButton.IsChecked = false;
            LToesButton.IsChecked = false;
            RToesButton.IsChecked = false;
            LEarringButton.IsChecked = false;
            REarringButton.IsChecked = false;
            LEarring2Button.IsChecked = false;
            REarring2Button.IsChecked = false;

            //Load Current Values for Slider
            CharacterDetails.LIndexCheck = true;
        }
        private void LIndexButton_Unchecked(object sender, RoutedEventArgs e)
        {
            CharacterDetails.LIndexRotate = false;
        }
        #endregion

        #region RIndex
        private void RIndexRot(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.RIndexX.value = (float)quat.X;
            CharacterDetails.RIndexY.value = (float)quat.Y;
            CharacterDetails.RIndexZ.value = (float)quat.Z;
            CharacterDetails.RIndexW.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneSlider.ValueChanged -= RIndexRot;
            BoneSlider2.ValueChanged -= RIndexRot;
            BoneSlider3.ValueChanged -= RIndexRot;
        }

        private void RIndexRot2(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.RIndexX.value = (float)quat.X;
            CharacterDetails.RIndexY.value = (float)quat.Y;
            CharacterDetails.RIndexZ.value = (float)quat.Z;
            CharacterDetails.RIndexW.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneUpDown.ValueChanged -= RIndexRot2;
            BoneUpDown2.ValueChanged -= RIndexRot2;
            BoneUpDown3.ValueChanged -= RIndexRot2;
        }

        private void RIndexButton_Checked(object sender, RoutedEventArgs e)
        {
            //Disable Other Selections
            HeadButton.IsChecked = false;
            NoseButton.IsChecked = false;
            NostrilsButton.IsChecked = false;
            ChinButton.IsChecked = false;
            LOutEyebrowButton.IsChecked = false;
            ROutEyebrowButton.IsChecked = false;
            LInEyebrowButton.IsChecked = false;
            RInEyebrowButton.IsChecked = false;
            LEyeButton.IsChecked = false;
            REyeButton.IsChecked = false;
            LEyelidButton.IsChecked = false;
            REyelidButton.IsChecked = false;
            LLowEyelidButton.IsChecked = false;
            RLowEyelidButton.IsChecked = false;
            LEarButton.IsChecked = false;
            REarButton.IsChecked = false;
            LCheekButton.IsChecked = false;
            RCheekButton.IsChecked = false;
            LMouthButton.IsChecked = false;
            RMouthButton.IsChecked = false;
            LUpLipButton.IsChecked = false;
            RUpLipButton.IsChecked = false;
            LLowLipButton.IsChecked = false;
            RLowLipButton.IsChecked = false;
            NeckButton.IsChecked = false;
            SternumButton.IsChecked = false;
            TorsoButton.IsChecked = false;
            WaistButton.IsChecked = false;
            LShoulderButton.IsChecked = false;
            RShoulderButton.IsChecked = false;
            LClavicleButton.IsChecked = false;
            RClavicleButton.IsChecked = false;
            LBreastButton.IsChecked = false;
            RBreastButton.IsChecked = false;
            LArmButton.IsChecked = false;
            RArmButton.IsChecked = false;
            LElbowButton.IsChecked = false;
            RElbowButton.IsChecked = false;
            LForearmButton.IsChecked = false;
            RForearmButton.IsChecked = false;
            LWristButton.IsChecked = false;
            RWristButton.IsChecked = false;
            LHandButton.IsChecked = false;
            RHandButton.IsChecked = false;
            LThumbButton.IsChecked = false;
            RThumbButton.IsChecked = false;
            LThumb2Button.IsChecked = false;
            RThumb2Button.IsChecked = false;
            LIndexButton.IsChecked = false;
            LIndex2Button.IsChecked = false;
            RIndex2Button.IsChecked = false;
            LMiddleButton.IsChecked = false;
            RMiddleButton.IsChecked = false;
            LMiddle2Button.IsChecked = false;
            RMiddle2Button.IsChecked = false;
            LRingButton.IsChecked = false;
            RRingButton.IsChecked = false;
            LRing2Button.IsChecked = false;
            RRing2Button.IsChecked = false;
            LPinkyButton.IsChecked = false;
            RPinkyButton.IsChecked = false;
            LPinky2Button.IsChecked = false;
            RPinky2Button.IsChecked = false;
            PelvisButton.IsChecked = false;
            TailButton.IsChecked = false;
            Tail2Button.IsChecked = false;
            Tail3Button.IsChecked = false;
            Tail4Button.IsChecked = false;
            LThighButton.IsChecked = false;
            RThighButton.IsChecked = false;
            LKneeButton.IsChecked = false;
            RKneeButton.IsChecked = false;
            LCalfButton.IsChecked = false;
            RCalfButton.IsChecked = false;
            LFootButton.IsChecked = false;
            RFootButton.IsChecked = false;
            LToesButton.IsChecked = false;
            RToesButton.IsChecked = false;
            LEarringButton.IsChecked = false;
            REarringButton.IsChecked = false;
            LEarring2Button.IsChecked = false;
            REarring2Button.IsChecked = false;

            //Load Current Values for Slider
            CharacterDetails.RIndexCheck = true;
        }
        private void RIndexButton_Unchecked(object sender, RoutedEventArgs e)
        {
            CharacterDetails.RIndexRotate = false;
        }
        #endregion

        #region LIndex2
        private void LIndex2Rot(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.LIndex2X.value = (float)quat.X;
            CharacterDetails.LIndex2Y.value = (float)quat.Y;
            CharacterDetails.LIndex2Z.value = (float)quat.Z;
            CharacterDetails.LIndex2W.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneSlider.ValueChanged -= LIndex2Rot;
            BoneSlider2.ValueChanged -= LIndex2Rot;
            BoneSlider3.ValueChanged -= LIndex2Rot;
        }

        private void LIndex2Rot2(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.LIndex2X.value = (float)quat.X;
            CharacterDetails.LIndex2Y.value = (float)quat.Y;
            CharacterDetails.LIndex2Z.value = (float)quat.Z;
            CharacterDetails.LIndex2W.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneUpDown.ValueChanged -= LIndex2Rot2;
            BoneUpDown2.ValueChanged -= LIndex2Rot2;
            BoneUpDown3.ValueChanged -= LIndex2Rot2;
        }

        private void LIndex2Button_Checked(object sender, RoutedEventArgs e)
        {
            //Disable Other Selections
            HeadButton.IsChecked = false;
            NoseButton.IsChecked = false;
            NostrilsButton.IsChecked = false;
            ChinButton.IsChecked = false;
            LOutEyebrowButton.IsChecked = false;
            ROutEyebrowButton.IsChecked = false;
            LInEyebrowButton.IsChecked = false;
            RInEyebrowButton.IsChecked = false;
            LEyeButton.IsChecked = false;
            REyeButton.IsChecked = false;
            LEyelidButton.IsChecked = false;
            REyelidButton.IsChecked = false;
            LLowEyelidButton.IsChecked = false;
            RLowEyelidButton.IsChecked = false;
            LEarButton.IsChecked = false;
            REarButton.IsChecked = false;
            LCheekButton.IsChecked = false;
            RCheekButton.IsChecked = false;
            LMouthButton.IsChecked = false;
            RMouthButton.IsChecked = false;
            LUpLipButton.IsChecked = false;
            RUpLipButton.IsChecked = false;
            LLowLipButton.IsChecked = false;
            RLowLipButton.IsChecked = false;
            NeckButton.IsChecked = false;
            SternumButton.IsChecked = false;
            TorsoButton.IsChecked = false;
            WaistButton.IsChecked = false;
            LShoulderButton.IsChecked = false;
            RShoulderButton.IsChecked = false;
            LClavicleButton.IsChecked = false;
            RClavicleButton.IsChecked = false;
            LBreastButton.IsChecked = false;
            RBreastButton.IsChecked = false;
            LArmButton.IsChecked = false;
            RArmButton.IsChecked = false;
            LElbowButton.IsChecked = false;
            RElbowButton.IsChecked = false;
            LForearmButton.IsChecked = false;
            RForearmButton.IsChecked = false;
            LWristButton.IsChecked = false;
            RWristButton.IsChecked = false;
            LHandButton.IsChecked = false;
            RHandButton.IsChecked = false;
            LThumbButton.IsChecked = false;
            RThumbButton.IsChecked = false;
            LThumb2Button.IsChecked = false;
            RThumb2Button.IsChecked = false;
            LIndexButton.IsChecked = false;
            RIndexButton.IsChecked = false;
            RIndex2Button.IsChecked = false;
            LMiddleButton.IsChecked = false;
            RMiddleButton.IsChecked = false;
            LMiddle2Button.IsChecked = false;
            RMiddle2Button.IsChecked = false;
            LRingButton.IsChecked = false;
            RRingButton.IsChecked = false;
            LRing2Button.IsChecked = false;
            RRing2Button.IsChecked = false;
            LPinkyButton.IsChecked = false;
            RPinkyButton.IsChecked = false;
            LPinky2Button.IsChecked = false;
            RPinky2Button.IsChecked = false;
            PelvisButton.IsChecked = false;
            TailButton.IsChecked = false;
            Tail2Button.IsChecked = false;
            Tail3Button.IsChecked = false;
            Tail4Button.IsChecked = false;
            LThighButton.IsChecked = false;
            RThighButton.IsChecked = false;
            LKneeButton.IsChecked = false;
            RKneeButton.IsChecked = false;
            LCalfButton.IsChecked = false;
            RCalfButton.IsChecked = false;
            LFootButton.IsChecked = false;
            RFootButton.IsChecked = false;
            LToesButton.IsChecked = false;
            RToesButton.IsChecked = false;
            LEarringButton.IsChecked = false;
            REarringButton.IsChecked = false;
            LEarring2Button.IsChecked = false;
            REarring2Button.IsChecked = false;

            //Load Current Values for Slider
            CharacterDetails.LIndex2Check = true;
        }
        private void LIndex2Button_Unchecked(object sender, RoutedEventArgs e)
        {
            CharacterDetails.LIndex2Rotate = false;
        }
        #endregion

        #region RIndex2
        private void RIndex2Rot(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.RIndex2X.value = (float)quat.X;
            CharacterDetails.RIndex2Y.value = (float)quat.Y;
            CharacterDetails.RIndex2Z.value = (float)quat.Z;
            CharacterDetails.RIndex2W.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneSlider.ValueChanged -= RIndex2Rot;
            BoneSlider2.ValueChanged -= RIndex2Rot;
            BoneSlider3.ValueChanged -= RIndex2Rot;
        }

        private void RIndex2Rot2(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.RIndex2X.value = (float)quat.X;
            CharacterDetails.RIndex2Y.value = (float)quat.Y;
            CharacterDetails.RIndex2Z.value = (float)quat.Z;
            CharacterDetails.RIndex2W.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneUpDown.ValueChanged -= RIndex2Rot2;
            BoneUpDown2.ValueChanged -= RIndex2Rot2;
            BoneUpDown3.ValueChanged -= RIndex2Rot2;
        }

        private void RIndex2Button_Checked(object sender, RoutedEventArgs e)
        {
            //Disable Other Selections
            HeadButton.IsChecked = false;
            NoseButton.IsChecked = false;
            NostrilsButton.IsChecked = false;
            ChinButton.IsChecked = false;
            LOutEyebrowButton.IsChecked = false;
            ROutEyebrowButton.IsChecked = false;
            LInEyebrowButton.IsChecked = false;
            RInEyebrowButton.IsChecked = false;
            LEyeButton.IsChecked = false;
            REyeButton.IsChecked = false;
            LEyelidButton.IsChecked = false;
            REyelidButton.IsChecked = false;
            LLowEyelidButton.IsChecked = false;
            RLowEyelidButton.IsChecked = false;
            LEarButton.IsChecked = false;
            REarButton.IsChecked = false;
            LCheekButton.IsChecked = false;
            RCheekButton.IsChecked = false;
            LMouthButton.IsChecked = false;
            RMouthButton.IsChecked = false;
            LUpLipButton.IsChecked = false;
            RUpLipButton.IsChecked = false;
            LLowLipButton.IsChecked = false;
            RLowLipButton.IsChecked = false;
            NeckButton.IsChecked = false;
            SternumButton.IsChecked = false;
            TorsoButton.IsChecked = false;
            WaistButton.IsChecked = false;
            LShoulderButton.IsChecked = false;
            RShoulderButton.IsChecked = false;
            LClavicleButton.IsChecked = false;
            RClavicleButton.IsChecked = false;
            LBreastButton.IsChecked = false;
            RBreastButton.IsChecked = false;
            LArmButton.IsChecked = false;
            RArmButton.IsChecked = false;
            LElbowButton.IsChecked = false;
            RElbowButton.IsChecked = false;
            LForearmButton.IsChecked = false;
            RForearmButton.IsChecked = false;
            LWristButton.IsChecked = false;
            RWristButton.IsChecked = false;
            LHandButton.IsChecked = false;
            RHandButton.IsChecked = false;
            LThumbButton.IsChecked = false;
            RThumbButton.IsChecked = false;
            LThumb2Button.IsChecked = false;
            RThumb2Button.IsChecked = false;
            LIndexButton.IsChecked = false;
            RIndexButton.IsChecked = false;
            LIndex2Button.IsChecked = false;
            LMiddleButton.IsChecked = false;
            RMiddleButton.IsChecked = false;
            LMiddle2Button.IsChecked = false;
            RMiddle2Button.IsChecked = false;
            LRingButton.IsChecked = false;
            RRingButton.IsChecked = false;
            LRing2Button.IsChecked = false;
            RRing2Button.IsChecked = false;
            LPinkyButton.IsChecked = false;
            RPinkyButton.IsChecked = false;
            LPinky2Button.IsChecked = false;
            RPinky2Button.IsChecked = false;
            PelvisButton.IsChecked = false;
            TailButton.IsChecked = false;
            Tail2Button.IsChecked = false;
            Tail3Button.IsChecked = false;
            Tail4Button.IsChecked = false;
            LThighButton.IsChecked = false;
            RThighButton.IsChecked = false;
            LKneeButton.IsChecked = false;
            RKneeButton.IsChecked = false;
            LCalfButton.IsChecked = false;
            RCalfButton.IsChecked = false;
            LFootButton.IsChecked = false;
            RFootButton.IsChecked = false;
            LToesButton.IsChecked = false;
            RToesButton.IsChecked = false;
            LEarringButton.IsChecked = false;
            REarringButton.IsChecked = false;
            LEarring2Button.IsChecked = false;
            REarring2Button.IsChecked = false;

            //Load Current Values for Slider
            CharacterDetails.RIndex2Check = true;
        }
        private void RIndex2Button_Unchecked(object sender, RoutedEventArgs e)
        {
            CharacterDetails.RIndex2Rotate = false;
        }
        #endregion

        #region LMiddle
        private void LMiddleRot(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.LMiddleX.value = (float)quat.X;
            CharacterDetails.LMiddleY.value = (float)quat.Y;
            CharacterDetails.LMiddleZ.value = (float)quat.Z;
            CharacterDetails.LMiddleW.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneSlider.ValueChanged -= LMiddleRot;
            BoneSlider2.ValueChanged -= LMiddleRot;
            BoneSlider3.ValueChanged -= LMiddleRot;
        }

        private void LMiddleRot2(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.LMiddleX.value = (float)quat.X;
            CharacterDetails.LMiddleY.value = (float)quat.Y;
            CharacterDetails.LMiddleZ.value = (float)quat.Z;
            CharacterDetails.LMiddleW.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneUpDown.ValueChanged -= LMiddleRot2;
            BoneUpDown2.ValueChanged -= LMiddleRot2;
            BoneUpDown3.ValueChanged -= LMiddleRot2;
        }

        private void LMiddleButton_Checked(object sender, RoutedEventArgs e)
        {
            //Disable Other Selections
            HeadButton.IsChecked = false;
            NoseButton.IsChecked = false;
            NostrilsButton.IsChecked = false;
            ChinButton.IsChecked = false;
            LOutEyebrowButton.IsChecked = false;
            ROutEyebrowButton.IsChecked = false;
            LInEyebrowButton.IsChecked = false;
            RInEyebrowButton.IsChecked = false;
            LEyeButton.IsChecked = false;
            REyeButton.IsChecked = false;
            LEyelidButton.IsChecked = false;
            REyelidButton.IsChecked = false;
            LLowEyelidButton.IsChecked = false;
            RLowEyelidButton.IsChecked = false;
            LEarButton.IsChecked = false;
            REarButton.IsChecked = false;
            LCheekButton.IsChecked = false;
            RCheekButton.IsChecked = false;
            LMouthButton.IsChecked = false;
            RMouthButton.IsChecked = false;
            LUpLipButton.IsChecked = false;
            RUpLipButton.IsChecked = false;
            LLowLipButton.IsChecked = false;
            RLowLipButton.IsChecked = false;
            NeckButton.IsChecked = false;
            SternumButton.IsChecked = false;
            TorsoButton.IsChecked = false;
            WaistButton.IsChecked = false;
            LShoulderButton.IsChecked = false;
            RShoulderButton.IsChecked = false;
            LClavicleButton.IsChecked = false;
            RClavicleButton.IsChecked = false;
            LBreastButton.IsChecked = false;
            RBreastButton.IsChecked = false;
            LArmButton.IsChecked = false;
            RArmButton.IsChecked = false;
            LElbowButton.IsChecked = false;
            RElbowButton.IsChecked = false;
            LForearmButton.IsChecked = false;
            RForearmButton.IsChecked = false;
            LWristButton.IsChecked = false;
            RWristButton.IsChecked = false;
            LHandButton.IsChecked = false;
            RHandButton.IsChecked = false;
            LThumbButton.IsChecked = false;
            RThumbButton.IsChecked = false;
            LThumb2Button.IsChecked = false;
            RThumb2Button.IsChecked = false;
            LIndexButton.IsChecked = false;
            RIndexButton.IsChecked = false;
            LIndex2Button.IsChecked = false;
            RIndex2Button.IsChecked = false;
            RMiddleButton.IsChecked = false;
            LMiddle2Button.IsChecked = false;
            RMiddle2Button.IsChecked = false;
            LRingButton.IsChecked = false;
            RRingButton.IsChecked = false;
            LRing2Button.IsChecked = false;
            RRing2Button.IsChecked = false;
            LPinkyButton.IsChecked = false;
            RPinkyButton.IsChecked = false;
            LPinky2Button.IsChecked = false;
            RPinky2Button.IsChecked = false;
            PelvisButton.IsChecked = false;
            TailButton.IsChecked = false;
            Tail2Button.IsChecked = false;
            Tail3Button.IsChecked = false;
            Tail4Button.IsChecked = false;
            LThighButton.IsChecked = false;
            RThighButton.IsChecked = false;
            LKneeButton.IsChecked = false;
            RKneeButton.IsChecked = false;
            LCalfButton.IsChecked = false;
            RCalfButton.IsChecked = false;
            LFootButton.IsChecked = false;
            RFootButton.IsChecked = false;
            LToesButton.IsChecked = false;
            RToesButton.IsChecked = false;
            LEarringButton.IsChecked = false;
            REarringButton.IsChecked = false;
            LEarring2Button.IsChecked = false;
            REarring2Button.IsChecked = false;

            //Load Current Values for Slider
            CharacterDetails.LMiddleCheck = true;
        }
        private void LMiddleButton_Unchecked(object sender, RoutedEventArgs e)
        {
            CharacterDetails.LMiddleRotate = false;
        }
        #endregion

        #region RMiddle
        private void RMiddleRot(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.RMiddleX.value = (float)quat.X;
            CharacterDetails.RMiddleY.value = (float)quat.Y;
            CharacterDetails.RMiddleZ.value = (float)quat.Z;
            CharacterDetails.RMiddleW.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneSlider.ValueChanged -= RMiddleRot;
            BoneSlider2.ValueChanged -= RMiddleRot;
            BoneSlider3.ValueChanged -= RMiddleRot;
        }

        private void RMiddleRot2(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.RMiddleX.value = (float)quat.X;
            CharacterDetails.RMiddleY.value = (float)quat.Y;
            CharacterDetails.RMiddleZ.value = (float)quat.Z;
            CharacterDetails.RMiddleW.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneUpDown.ValueChanged -= RMiddleRot2;
            BoneUpDown2.ValueChanged -= RMiddleRot2;
            BoneUpDown3.ValueChanged -= RMiddleRot2;
        }

        private void RMiddleButton_Checked(object sender, RoutedEventArgs e)
        {
            //Disable Other Selections
            HeadButton.IsChecked = false;
            NoseButton.IsChecked = false;
            NostrilsButton.IsChecked = false;
            ChinButton.IsChecked = false;
            LOutEyebrowButton.IsChecked = false;
            ROutEyebrowButton.IsChecked = false;
            LInEyebrowButton.IsChecked = false;
            RInEyebrowButton.IsChecked = false;
            LEyeButton.IsChecked = false;
            REyeButton.IsChecked = false;
            LEyelidButton.IsChecked = false;
            REyelidButton.IsChecked = false;
            LLowEyelidButton.IsChecked = false;
            RLowEyelidButton.IsChecked = false;
            LEarButton.IsChecked = false;
            REarButton.IsChecked = false;
            LCheekButton.IsChecked = false;
            RCheekButton.IsChecked = false;
            LMouthButton.IsChecked = false;
            RMouthButton.IsChecked = false;
            LUpLipButton.IsChecked = false;
            RUpLipButton.IsChecked = false;
            LLowLipButton.IsChecked = false;
            RLowLipButton.IsChecked = false;
            NeckButton.IsChecked = false;
            SternumButton.IsChecked = false;
            TorsoButton.IsChecked = false;
            WaistButton.IsChecked = false;
            LShoulderButton.IsChecked = false;
            RShoulderButton.IsChecked = false;
            LClavicleButton.IsChecked = false;
            RClavicleButton.IsChecked = false;
            LBreastButton.IsChecked = false;
            RBreastButton.IsChecked = false;
            LArmButton.IsChecked = false;
            RArmButton.IsChecked = false;
            LElbowButton.IsChecked = false;
            RElbowButton.IsChecked = false;
            LForearmButton.IsChecked = false;
            RForearmButton.IsChecked = false;
            LWristButton.IsChecked = false;
            RWristButton.IsChecked = false;
            LHandButton.IsChecked = false;
            RHandButton.IsChecked = false;
            LThumbButton.IsChecked = false;
            RThumbButton.IsChecked = false;
            LThumb2Button.IsChecked = false;
            RThumb2Button.IsChecked = false;
            LIndexButton.IsChecked = false;
            RIndexButton.IsChecked = false;
            LIndex2Button.IsChecked = false;
            RIndex2Button.IsChecked = false;
            LMiddleButton.IsChecked = false;
            LMiddle2Button.IsChecked = false;
            RMiddle2Button.IsChecked = false;
            LRingButton.IsChecked = false;
            RRingButton.IsChecked = false;
            LRing2Button.IsChecked = false;
            RRing2Button.IsChecked = false;
            LPinkyButton.IsChecked = false;
            RPinkyButton.IsChecked = false;
            LPinky2Button.IsChecked = false;
            RPinky2Button.IsChecked = false;
            PelvisButton.IsChecked = false;
            TailButton.IsChecked = false;
            Tail2Button.IsChecked = false;
            Tail3Button.IsChecked = false;
            Tail4Button.IsChecked = false;
            LThighButton.IsChecked = false;
            RThighButton.IsChecked = false;
            LKneeButton.IsChecked = false;
            RKneeButton.IsChecked = false;
            LCalfButton.IsChecked = false;
            RCalfButton.IsChecked = false;
            LFootButton.IsChecked = false;
            RFootButton.IsChecked = false;
            LToesButton.IsChecked = false;
            RToesButton.IsChecked = false;
            LEarringButton.IsChecked = false;
            REarringButton.IsChecked = false;
            LEarring2Button.IsChecked = false;
            REarring2Button.IsChecked = false;

            //Load Current Values for Slider
            CharacterDetails.RMiddleCheck = true;
        }
        private void RMiddleButton_Unchecked(object sender, RoutedEventArgs e)
        {
            CharacterDetails.RMiddleRotate = false;
        }
        #endregion

        #region LMiddle2
        private void LMiddle2Rot(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.LMiddle2X.value = (float)quat.X;
            CharacterDetails.LMiddle2Y.value = (float)quat.Y;
            CharacterDetails.LMiddle2Z.value = (float)quat.Z;
            CharacterDetails.LMiddle2W.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneSlider.ValueChanged -= LMiddle2Rot;
            BoneSlider2.ValueChanged -= LMiddle2Rot;
            BoneSlider3.ValueChanged -= LMiddle2Rot;
        }

        private void LMiddle2Rot2(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.LMiddle2X.value = (float)quat.X;
            CharacterDetails.LMiddle2Y.value = (float)quat.Y;
            CharacterDetails.LMiddle2Z.value = (float)quat.Z;
            CharacterDetails.LMiddle2W.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneUpDown.ValueChanged -= LMiddle2Rot2;
            BoneUpDown2.ValueChanged -= LMiddle2Rot2;
            BoneUpDown3.ValueChanged -= LMiddle2Rot2;
        }

        private void LMiddle2Button_Checked(object sender, RoutedEventArgs e)
        {
            //Disable Other Selections
            HeadButton.IsChecked = false;
            NoseButton.IsChecked = false;
            NostrilsButton.IsChecked = false;
            ChinButton.IsChecked = false;
            LOutEyebrowButton.IsChecked = false;
            ROutEyebrowButton.IsChecked = false;
            LInEyebrowButton.IsChecked = false;
            RInEyebrowButton.IsChecked = false;
            LEyeButton.IsChecked = false;
            REyeButton.IsChecked = false;
            LEyelidButton.IsChecked = false;
            REyelidButton.IsChecked = false;
            LLowEyelidButton.IsChecked = false;
            RLowEyelidButton.IsChecked = false;
            LEarButton.IsChecked = false;
            REarButton.IsChecked = false;
            LCheekButton.IsChecked = false;
            RCheekButton.IsChecked = false;
            LMouthButton.IsChecked = false;
            RMouthButton.IsChecked = false;
            LUpLipButton.IsChecked = false;
            RUpLipButton.IsChecked = false;
            LLowLipButton.IsChecked = false;
            RLowLipButton.IsChecked = false;
            NeckButton.IsChecked = false;
            SternumButton.IsChecked = false;
            TorsoButton.IsChecked = false;
            WaistButton.IsChecked = false;
            LShoulderButton.IsChecked = false;
            RShoulderButton.IsChecked = false;
            LClavicleButton.IsChecked = false;
            RClavicleButton.IsChecked = false;
            LBreastButton.IsChecked = false;
            RBreastButton.IsChecked = false;
            LArmButton.IsChecked = false;
            RArmButton.IsChecked = false;
            LElbowButton.IsChecked = false;
            RElbowButton.IsChecked = false;
            LForearmButton.IsChecked = false;
            RForearmButton.IsChecked = false;
            LWristButton.IsChecked = false;
            RWristButton.IsChecked = false;
            LHandButton.IsChecked = false;
            RHandButton.IsChecked = false;
            LThumbButton.IsChecked = false;
            RThumbButton.IsChecked = false;
            LThumb2Button.IsChecked = false;
            RThumb2Button.IsChecked = false;
            LIndexButton.IsChecked = false;
            RIndexButton.IsChecked = false;
            LIndex2Button.IsChecked = false;
            RIndex2Button.IsChecked = false;
            LMiddleButton.IsChecked = false;
            RMiddleButton.IsChecked = false;
            RMiddle2Button.IsChecked = false;
            LRingButton.IsChecked = false;
            RRingButton.IsChecked = false;
            LRing2Button.IsChecked = false;
            RRing2Button.IsChecked = false;
            LPinkyButton.IsChecked = false;
            RPinkyButton.IsChecked = false;
            LPinky2Button.IsChecked = false;
            RPinky2Button.IsChecked = false;
            PelvisButton.IsChecked = false;
            TailButton.IsChecked = false;
            Tail2Button.IsChecked = false;
            Tail3Button.IsChecked = false;
            Tail4Button.IsChecked = false;
            LThighButton.IsChecked = false;
            RThighButton.IsChecked = false;
            LKneeButton.IsChecked = false;
            RKneeButton.IsChecked = false;
            LCalfButton.IsChecked = false;
            RCalfButton.IsChecked = false;
            LFootButton.IsChecked = false;
            RFootButton.IsChecked = false;
            LToesButton.IsChecked = false;
            RToesButton.IsChecked = false;
            LEarringButton.IsChecked = false;
            REarringButton.IsChecked = false;
            LEarring2Button.IsChecked = false;
            REarring2Button.IsChecked = false;

            //Load Current Values for Slider
            CharacterDetails.LMiddle2Check = true;
        }
        private void LMiddle2Button_Unchecked(object sender, RoutedEventArgs e)
        {
            CharacterDetails.LMiddle2Rotate = false;
        }
        #endregion

        #region RMiddle2
        private void RMiddle2Rot(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.RMiddle2X.value = (float)quat.X;
            CharacterDetails.RMiddle2Y.value = (float)quat.Y;
            CharacterDetails.RMiddle2Z.value = (float)quat.Z;
            CharacterDetails.RMiddle2W.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneSlider.ValueChanged -= RMiddle2Rot;
            BoneSlider2.ValueChanged -= RMiddle2Rot;
            BoneSlider3.ValueChanged -= RMiddle2Rot;
        }

        private void RMiddle2Rot2(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.RMiddle2X.value = (float)quat.X;
            CharacterDetails.RMiddle2Y.value = (float)quat.Y;
            CharacterDetails.RMiddle2Z.value = (float)quat.Z;
            CharacterDetails.RMiddle2W.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneUpDown.ValueChanged -= RMiddle2Rot2;
            BoneUpDown2.ValueChanged -= RMiddle2Rot2;
            BoneUpDown3.ValueChanged -= RMiddle2Rot2;
        }

        private void RMiddle2Button_Checked(object sender, RoutedEventArgs e)
        {
            //Disable Other Selections
            HeadButton.IsChecked = false;
            NoseButton.IsChecked = false;
            NostrilsButton.IsChecked = false;
            ChinButton.IsChecked = false;
            LOutEyebrowButton.IsChecked = false;
            ROutEyebrowButton.IsChecked = false;
            LInEyebrowButton.IsChecked = false;
            RInEyebrowButton.IsChecked = false;
            LEyeButton.IsChecked = false;
            REyeButton.IsChecked = false;
            LEyelidButton.IsChecked = false;
            REyelidButton.IsChecked = false;
            LLowEyelidButton.IsChecked = false;
            RLowEyelidButton.IsChecked = false;
            LEarButton.IsChecked = false;
            REarButton.IsChecked = false;
            LCheekButton.IsChecked = false;
            RCheekButton.IsChecked = false;
            LMouthButton.IsChecked = false;
            RMouthButton.IsChecked = false;
            LUpLipButton.IsChecked = false;
            RUpLipButton.IsChecked = false;
            LLowLipButton.IsChecked = false;
            RLowLipButton.IsChecked = false;
            NeckButton.IsChecked = false;
            SternumButton.IsChecked = false;
            TorsoButton.IsChecked = false;
            WaistButton.IsChecked = false;
            LShoulderButton.IsChecked = false;
            RShoulderButton.IsChecked = false;
            LClavicleButton.IsChecked = false;
            RClavicleButton.IsChecked = false;
            LBreastButton.IsChecked = false;
            RBreastButton.IsChecked = false;
            LArmButton.IsChecked = false;
            RArmButton.IsChecked = false;
            LElbowButton.IsChecked = false;
            RElbowButton.IsChecked = false;
            LForearmButton.IsChecked = false;
            RForearmButton.IsChecked = false;
            LWristButton.IsChecked = false;
            RWristButton.IsChecked = false;
            LHandButton.IsChecked = false;
            RHandButton.IsChecked = false;
            LThumbButton.IsChecked = false;
            RThumbButton.IsChecked = false;
            LThumb2Button.IsChecked = false;
            RThumb2Button.IsChecked = false;
            LIndexButton.IsChecked = false;
            RIndexButton.IsChecked = false;
            LIndex2Button.IsChecked = false;
            RIndex2Button.IsChecked = false;
            LMiddleButton.IsChecked = false;
            RMiddleButton.IsChecked = false;
            LMiddle2Button.IsChecked = false;
            LRingButton.IsChecked = false;
            RRingButton.IsChecked = false;
            LRing2Button.IsChecked = false;
            RRing2Button.IsChecked = false;
            LPinkyButton.IsChecked = false;
            RPinkyButton.IsChecked = false;
            LPinky2Button.IsChecked = false;
            RPinky2Button.IsChecked = false;
            PelvisButton.IsChecked = false;
            TailButton.IsChecked = false;
            Tail2Button.IsChecked = false;
            Tail3Button.IsChecked = false;
            Tail4Button.IsChecked = false;
            LThighButton.IsChecked = false;
            RThighButton.IsChecked = false;
            LKneeButton.IsChecked = false;
            RKneeButton.IsChecked = false;
            LCalfButton.IsChecked = false;
            RCalfButton.IsChecked = false;
            LFootButton.IsChecked = false;
            RFootButton.IsChecked = false;
            LToesButton.IsChecked = false;
            RToesButton.IsChecked = false;
            LEarringButton.IsChecked = false;
            REarringButton.IsChecked = false;
            LEarring2Button.IsChecked = false;
            REarring2Button.IsChecked = false;

            //Load Current Values for Slider
            CharacterDetails.RMiddle2Check = true;
        }
        private void RMiddle2Button_Unchecked(object sender, RoutedEventArgs e)
        {
            CharacterDetails.RMiddle2Rotate = false;
        }
        #endregion

        #region LRing
        private void LRingRot(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.LRingX.value = (float)quat.X;
            CharacterDetails.LRingY.value = (float)quat.Y;
            CharacterDetails.LRingZ.value = (float)quat.Z;
            CharacterDetails.LRingW.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneSlider.ValueChanged -= LRingRot;
            BoneSlider2.ValueChanged -= LRingRot;
            BoneSlider3.ValueChanged -= LRingRot;
        }

        private void LRingRot2(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.LRingX.value = (float)quat.X;
            CharacterDetails.LRingY.value = (float)quat.Y;
            CharacterDetails.LRingZ.value = (float)quat.Z;
            CharacterDetails.LRingW.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneUpDown.ValueChanged -= LRingRot2;
            BoneUpDown2.ValueChanged -= LRingRot2;
            BoneUpDown3.ValueChanged -= LRingRot2;
        }

        private void LRingButton_Checked(object sender, RoutedEventArgs e)
        {
            //Disable Other Selections
            HeadButton.IsChecked = false;
            NoseButton.IsChecked = false;
            NostrilsButton.IsChecked = false;
            ChinButton.IsChecked = false;
            LOutEyebrowButton.IsChecked = false;
            ROutEyebrowButton.IsChecked = false;
            LInEyebrowButton.IsChecked = false;
            RInEyebrowButton.IsChecked = false;
            LEyeButton.IsChecked = false;
            REyeButton.IsChecked = false;
            LEyelidButton.IsChecked = false;
            REyelidButton.IsChecked = false;
            LLowEyelidButton.IsChecked = false;
            RLowEyelidButton.IsChecked = false;
            LEarButton.IsChecked = false;
            REarButton.IsChecked = false;
            LCheekButton.IsChecked = false;
            RCheekButton.IsChecked = false;
            LMouthButton.IsChecked = false;
            RMouthButton.IsChecked = false;
            LUpLipButton.IsChecked = false;
            RUpLipButton.IsChecked = false;
            LLowLipButton.IsChecked = false;
            RLowLipButton.IsChecked = false;
            NeckButton.IsChecked = false;
            SternumButton.IsChecked = false;
            TorsoButton.IsChecked = false;
            WaistButton.IsChecked = false;
            LShoulderButton.IsChecked = false;
            RShoulderButton.IsChecked = false;
            LClavicleButton.IsChecked = false;
            RClavicleButton.IsChecked = false;
            LBreastButton.IsChecked = false;
            RBreastButton.IsChecked = false;
            LArmButton.IsChecked = false;
            RArmButton.IsChecked = false;
            LElbowButton.IsChecked = false;
            RElbowButton.IsChecked = false;
            LForearmButton.IsChecked = false;
            RForearmButton.IsChecked = false;
            LWristButton.IsChecked = false;
            RWristButton.IsChecked = false;
            LHandButton.IsChecked = false;
            RHandButton.IsChecked = false;
            LThumbButton.IsChecked = false;
            RThumbButton.IsChecked = false;
            LThumb2Button.IsChecked = false;
            RThumb2Button.IsChecked = false;
            LIndexButton.IsChecked = false;
            RIndexButton.IsChecked = false;
            LIndex2Button.IsChecked = false;
            RIndex2Button.IsChecked = false;
            LMiddleButton.IsChecked = false;
            RMiddleButton.IsChecked = false;
            LMiddle2Button.IsChecked = false;
            RMiddle2Button.IsChecked = false;
            RRingButton.IsChecked = false;
            LRing2Button.IsChecked = false;
            RRing2Button.IsChecked = false;
            LPinkyButton.IsChecked = false;
            RPinkyButton.IsChecked = false;
            LPinky2Button.IsChecked = false;
            RPinky2Button.IsChecked = false;
            PelvisButton.IsChecked = false;
            TailButton.IsChecked = false;
            Tail2Button.IsChecked = false;
            Tail3Button.IsChecked = false;
            Tail4Button.IsChecked = false;
            LThighButton.IsChecked = false;
            RThighButton.IsChecked = false;
            LKneeButton.IsChecked = false;
            RKneeButton.IsChecked = false;
            LCalfButton.IsChecked = false;
            RCalfButton.IsChecked = false;
            LFootButton.IsChecked = false;
            RFootButton.IsChecked = false;
            LToesButton.IsChecked = false;
            RToesButton.IsChecked = false;
            LEarringButton.IsChecked = false;
            REarringButton.IsChecked = false;
            LEarring2Button.IsChecked = false;
            REarring2Button.IsChecked = false;

            //Load Current Values for Slider
            CharacterDetails.LRingCheck = true;
        }
        private void LRingButton_Unchecked(object sender, RoutedEventArgs e)
        {
            CharacterDetails.LRingRotate = false;
        }
        #endregion

        #region RRing
        private void RRingRot(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.RRingX.value = (float)quat.X;
            CharacterDetails.RRingY.value = (float)quat.Y;
            CharacterDetails.RRingZ.value = (float)quat.Z;
            CharacterDetails.RRingW.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneSlider.ValueChanged -= RRingRot;
            BoneSlider2.ValueChanged -= RRingRot;
            BoneSlider3.ValueChanged -= RRingRot;
        }

        private void RRingRot2(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.RRingX.value = (float)quat.X;
            CharacterDetails.RRingY.value = (float)quat.Y;
            CharacterDetails.RRingZ.value = (float)quat.Z;
            CharacterDetails.RRingW.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneUpDown.ValueChanged -= RRingRot2;
            BoneUpDown2.ValueChanged -= RRingRot2;
            BoneUpDown3.ValueChanged -= RRingRot2;
        }

        private void RRingButton_Checked(object sender, RoutedEventArgs e)
        {
            //Disable Other Selections
            HeadButton.IsChecked = false;
            NoseButton.IsChecked = false;
            NostrilsButton.IsChecked = false;
            ChinButton.IsChecked = false;
            LOutEyebrowButton.IsChecked = false;
            ROutEyebrowButton.IsChecked = false;
            LInEyebrowButton.IsChecked = false;
            RInEyebrowButton.IsChecked = false;
            LEyeButton.IsChecked = false;
            REyeButton.IsChecked = false;
            LEyelidButton.IsChecked = false;
            REyelidButton.IsChecked = false;
            LLowEyelidButton.IsChecked = false;
            RLowEyelidButton.IsChecked = false;
            LEarButton.IsChecked = false;
            REarButton.IsChecked = false;
            LCheekButton.IsChecked = false;
            RCheekButton.IsChecked = false;
            LMouthButton.IsChecked = false;
            RMouthButton.IsChecked = false;
            LUpLipButton.IsChecked = false;
            RUpLipButton.IsChecked = false;
            LLowLipButton.IsChecked = false;
            RLowLipButton.IsChecked = false;
            NeckButton.IsChecked = false;
            SternumButton.IsChecked = false;
            TorsoButton.IsChecked = false;
            WaistButton.IsChecked = false;
            LShoulderButton.IsChecked = false;
            RShoulderButton.IsChecked = false;
            LClavicleButton.IsChecked = false;
            RClavicleButton.IsChecked = false;
            LBreastButton.IsChecked = false;
            RBreastButton.IsChecked = false;
            LArmButton.IsChecked = false;
            RArmButton.IsChecked = false;
            LElbowButton.IsChecked = false;
            RElbowButton.IsChecked = false;
            LForearmButton.IsChecked = false;
            RForearmButton.IsChecked = false;
            LWristButton.IsChecked = false;
            RWristButton.IsChecked = false;
            LHandButton.IsChecked = false;
            RHandButton.IsChecked = false;
            LThumbButton.IsChecked = false;
            RThumbButton.IsChecked = false;
            LThumb2Button.IsChecked = false;
            RThumb2Button.IsChecked = false;
            LIndexButton.IsChecked = false;
            RIndexButton.IsChecked = false;
            LIndex2Button.IsChecked = false;
            RIndex2Button.IsChecked = false;
            LMiddleButton.IsChecked = false;
            RMiddleButton.IsChecked = false;
            LMiddle2Button.IsChecked = false;
            RMiddle2Button.IsChecked = false;
            LRingButton.IsChecked = false;
            LRing2Button.IsChecked = false;
            RRing2Button.IsChecked = false;
            LPinkyButton.IsChecked = false;
            RPinkyButton.IsChecked = false;
            LPinky2Button.IsChecked = false;
            RPinky2Button.IsChecked = false;
            PelvisButton.IsChecked = false;
            TailButton.IsChecked = false;
            Tail2Button.IsChecked = false;
            Tail3Button.IsChecked = false;
            Tail4Button.IsChecked = false;
            LThighButton.IsChecked = false;
            RThighButton.IsChecked = false;
            LKneeButton.IsChecked = false;
            RKneeButton.IsChecked = false;
            LCalfButton.IsChecked = false;
            RCalfButton.IsChecked = false;
            LFootButton.IsChecked = false;
            RFootButton.IsChecked = false;
            LToesButton.IsChecked = false;
            RToesButton.IsChecked = false;
            LEarringButton.IsChecked = false;
            REarringButton.IsChecked = false;
            LEarring2Button.IsChecked = false;
            REarring2Button.IsChecked = false;

            //Load Current Values for Slider
            CharacterDetails.RRingCheck = true;
        }
        private void RRingButton_Unchecked(object sender, RoutedEventArgs e)
        {
            CharacterDetails.RRingRotate = false;
        }
        #endregion

        #region LRing2
        private void LRing2Rot(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.LRing2X.value = (float)quat.X;
            CharacterDetails.LRing2Y.value = (float)quat.Y;
            CharacterDetails.LRing2Z.value = (float)quat.Z;
            CharacterDetails.LRing2W.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneSlider.ValueChanged -= LRing2Rot;
            BoneSlider2.ValueChanged -= LRing2Rot;
            BoneSlider3.ValueChanged -= LRing2Rot;
        }

        private void LRing2Rot2(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.LRing2X.value = (float)quat.X;
            CharacterDetails.LRing2Y.value = (float)quat.Y;
            CharacterDetails.LRing2Z.value = (float)quat.Z;
            CharacterDetails.LRing2W.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneUpDown.ValueChanged -= LRing2Rot2;
            BoneUpDown2.ValueChanged -= LRing2Rot2;
            BoneUpDown3.ValueChanged -= LRing2Rot2;
        }

        private void LRing2Button_Checked(object sender, RoutedEventArgs e)
        {
            //Disable Other Selections
            HeadButton.IsChecked = false;
            NoseButton.IsChecked = false;
            NostrilsButton.IsChecked = false;
            ChinButton.IsChecked = false;
            LOutEyebrowButton.IsChecked = false;
            ROutEyebrowButton.IsChecked = false;
            LInEyebrowButton.IsChecked = false;
            RInEyebrowButton.IsChecked = false;
            LEyeButton.IsChecked = false;
            REyeButton.IsChecked = false;
            LEyelidButton.IsChecked = false;
            REyelidButton.IsChecked = false;
            LLowEyelidButton.IsChecked = false;
            RLowEyelidButton.IsChecked = false;
            LEarButton.IsChecked = false;
            REarButton.IsChecked = false;
            LCheekButton.IsChecked = false;
            RCheekButton.IsChecked = false;
            LMouthButton.IsChecked = false;
            RMouthButton.IsChecked = false;
            LUpLipButton.IsChecked = false;
            RUpLipButton.IsChecked = false;
            LLowLipButton.IsChecked = false;
            RLowLipButton.IsChecked = false;
            NeckButton.IsChecked = false;
            SternumButton.IsChecked = false;
            TorsoButton.IsChecked = false;
            WaistButton.IsChecked = false;
            LShoulderButton.IsChecked = false;
            RShoulderButton.IsChecked = false;
            LClavicleButton.IsChecked = false;
            RClavicleButton.IsChecked = false;
            LBreastButton.IsChecked = false;
            RBreastButton.IsChecked = false;
            LArmButton.IsChecked = false;
            RArmButton.IsChecked = false;
            LElbowButton.IsChecked = false;
            RElbowButton.IsChecked = false;
            LForearmButton.IsChecked = false;
            RForearmButton.IsChecked = false;
            LWristButton.IsChecked = false;
            RWristButton.IsChecked = false;
            LHandButton.IsChecked = false;
            RHandButton.IsChecked = false;
            LThumbButton.IsChecked = false;
            RThumbButton.IsChecked = false;
            LThumb2Button.IsChecked = false;
            RThumb2Button.IsChecked = false;
            LIndexButton.IsChecked = false;
            RIndexButton.IsChecked = false;
            LIndex2Button.IsChecked = false;
            RIndex2Button.IsChecked = false;
            LMiddleButton.IsChecked = false;
            RMiddleButton.IsChecked = false;
            LMiddle2Button.IsChecked = false;
            RMiddle2Button.IsChecked = false;
            LRingButton.IsChecked = false;
            RRingButton.IsChecked = false;
            RRing2Button.IsChecked = false;
            LPinkyButton.IsChecked = false;
            RPinkyButton.IsChecked = false;
            LPinky2Button.IsChecked = false;
            RPinky2Button.IsChecked = false;
            PelvisButton.IsChecked = false;
            TailButton.IsChecked = false;
            Tail2Button.IsChecked = false;
            Tail3Button.IsChecked = false;
            Tail4Button.IsChecked = false;
            LThighButton.IsChecked = false;
            RThighButton.IsChecked = false;
            LKneeButton.IsChecked = false;
            RKneeButton.IsChecked = false;
            LCalfButton.IsChecked = false;
            RCalfButton.IsChecked = false;
            LFootButton.IsChecked = false;
            RFootButton.IsChecked = false;
            LToesButton.IsChecked = false;
            RToesButton.IsChecked = false;
            LEarringButton.IsChecked = false;
            REarringButton.IsChecked = false;
            LEarring2Button.IsChecked = false;
            REarring2Button.IsChecked = false;

            //Load Current Values for Slider
            CharacterDetails.LRing2Check = true;
        }
        private void LRing2Button_Unchecked(object sender, RoutedEventArgs e)
        {
            CharacterDetails.LRing2Rotate = false;
        }
        #endregion

        #region RRing2
        private void RRing2Rot(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.RRing2X.value = (float)quat.X;
            CharacterDetails.RRing2Y.value = (float)quat.Y;
            CharacterDetails.RRing2Z.value = (float)quat.Z;
            CharacterDetails.RRing2W.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneSlider.ValueChanged -= RRing2Rot;
            BoneSlider2.ValueChanged -= RRing2Rot;
            BoneSlider3.ValueChanged -= RRing2Rot;
        }

        private void RRing2Rot2(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.RRing2X.value = (float)quat.X;
            CharacterDetails.RRing2Y.value = (float)quat.Y;
            CharacterDetails.RRing2Z.value = (float)quat.Z;
            CharacterDetails.RRing2W.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneUpDown.ValueChanged -= RRing2Rot2;
            BoneUpDown2.ValueChanged -= RRing2Rot2;
            BoneUpDown3.ValueChanged -= RRing2Rot2;
        }

        private void RRing2Button_Checked(object sender, RoutedEventArgs e)
        {
            //Disable Other Selections
            HeadButton.IsChecked = false;
            NoseButton.IsChecked = false;
            NostrilsButton.IsChecked = false;
            ChinButton.IsChecked = false;
            LOutEyebrowButton.IsChecked = false;
            ROutEyebrowButton.IsChecked = false;
            LInEyebrowButton.IsChecked = false;
            RInEyebrowButton.IsChecked = false;
            LEyeButton.IsChecked = false;
            REyeButton.IsChecked = false;
            LEyelidButton.IsChecked = false;
            REyelidButton.IsChecked = false;
            LLowEyelidButton.IsChecked = false;
            RLowEyelidButton.IsChecked = false;
            LEarButton.IsChecked = false;
            REarButton.IsChecked = false;
            LCheekButton.IsChecked = false;
            RCheekButton.IsChecked = false;
            LMouthButton.IsChecked = false;
            RMouthButton.IsChecked = false;
            LUpLipButton.IsChecked = false;
            RUpLipButton.IsChecked = false;
            LLowLipButton.IsChecked = false;
            RLowLipButton.IsChecked = false;
            NeckButton.IsChecked = false;
            SternumButton.IsChecked = false;
            TorsoButton.IsChecked = false;
            WaistButton.IsChecked = false;
            LShoulderButton.IsChecked = false;
            RShoulderButton.IsChecked = false;
            LClavicleButton.IsChecked = false;
            RClavicleButton.IsChecked = false;
            LBreastButton.IsChecked = false;
            RBreastButton.IsChecked = false;
            LArmButton.IsChecked = false;
            RArmButton.IsChecked = false;
            LElbowButton.IsChecked = false;
            RElbowButton.IsChecked = false;
            LForearmButton.IsChecked = false;
            RForearmButton.IsChecked = false;
            LWristButton.IsChecked = false;
            RWristButton.IsChecked = false;
            LHandButton.IsChecked = false;
            RHandButton.IsChecked = false;
            LThumbButton.IsChecked = false;
            RThumbButton.IsChecked = false;
            LThumb2Button.IsChecked = false;
            RThumb2Button.IsChecked = false;
            LIndexButton.IsChecked = false;
            RIndexButton.IsChecked = false;
            LIndex2Button.IsChecked = false;
            RIndex2Button.IsChecked = false;
            LMiddleButton.IsChecked = false;
            RMiddleButton.IsChecked = false;
            LMiddle2Button.IsChecked = false;
            RMiddle2Button.IsChecked = false;
            LRingButton.IsChecked = false;
            RRingButton.IsChecked = false;
            LRing2Button.IsChecked = false;
            LPinkyButton.IsChecked = false;
            RPinkyButton.IsChecked = false;
            LPinky2Button.IsChecked = false;
            RPinky2Button.IsChecked = false;
            PelvisButton.IsChecked = false;
            TailButton.IsChecked = false;
            Tail2Button.IsChecked = false;
            Tail3Button.IsChecked = false;
            Tail4Button.IsChecked = false;
            LThighButton.IsChecked = false;
            RThighButton.IsChecked = false;
            LKneeButton.IsChecked = false;
            RKneeButton.IsChecked = false;
            LCalfButton.IsChecked = false;
            RCalfButton.IsChecked = false;
            LFootButton.IsChecked = false;
            RFootButton.IsChecked = false;
            LToesButton.IsChecked = false;
            RToesButton.IsChecked = false;
            LEarringButton.IsChecked = false;
            REarringButton.IsChecked = false;
            LEarring2Button.IsChecked = false;
            REarring2Button.IsChecked = false;

            //Load Current Values for Slider
            CharacterDetails.RRing2Check = true;
        }
        private void RRing2Button_Unchecked(object sender, RoutedEventArgs e)
        {
            CharacterDetails.RRing2Rotate = false;
        }
        #endregion

        #region LPinky
        private void LPinkyRot(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.LPinkyX.value = (float)quat.X;
            CharacterDetails.LPinkyY.value = (float)quat.Y;
            CharacterDetails.LPinkyZ.value = (float)quat.Z;
            CharacterDetails.LPinkyW.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneSlider.ValueChanged -= LPinkyRot;
            BoneSlider2.ValueChanged -= LPinkyRot;
            BoneSlider3.ValueChanged -= LPinkyRot;
        }

        private void LPinkyRot2(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.LPinkyX.value = (float)quat.X;
            CharacterDetails.LPinkyY.value = (float)quat.Y;
            CharacterDetails.LPinkyZ.value = (float)quat.Z;
            CharacterDetails.LPinkyW.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneUpDown.ValueChanged -= LPinkyRot2;
            BoneUpDown2.ValueChanged -= LPinkyRot2;
            BoneUpDown3.ValueChanged -= LPinkyRot2;
        }

        private void LPinkyButton_Checked(object sender, RoutedEventArgs e)
        {
            //Disable Other Selections
            HeadButton.IsChecked = false;
            NoseButton.IsChecked = false;
            NostrilsButton.IsChecked = false;
            ChinButton.IsChecked = false;
            LOutEyebrowButton.IsChecked = false;
            ROutEyebrowButton.IsChecked = false;
            LInEyebrowButton.IsChecked = false;
            RInEyebrowButton.IsChecked = false;
            LEyeButton.IsChecked = false;
            REyeButton.IsChecked = false;
            LEyelidButton.IsChecked = false;
            REyelidButton.IsChecked = false;
            LLowEyelidButton.IsChecked = false;
            RLowEyelidButton.IsChecked = false;
            LEarButton.IsChecked = false;
            REarButton.IsChecked = false;
            LCheekButton.IsChecked = false;
            RCheekButton.IsChecked = false;
            LMouthButton.IsChecked = false;
            RMouthButton.IsChecked = false;
            LUpLipButton.IsChecked = false;
            RUpLipButton.IsChecked = false;
            LLowLipButton.IsChecked = false;
            RLowLipButton.IsChecked = false;
            NeckButton.IsChecked = false;
            SternumButton.IsChecked = false;
            TorsoButton.IsChecked = false;
            WaistButton.IsChecked = false;
            LShoulderButton.IsChecked = false;
            RShoulderButton.IsChecked = false;
            LClavicleButton.IsChecked = false;
            RClavicleButton.IsChecked = false;
            LBreastButton.IsChecked = false;
            RBreastButton.IsChecked = false;
            LArmButton.IsChecked = false;
            RArmButton.IsChecked = false;
            LElbowButton.IsChecked = false;
            RElbowButton.IsChecked = false;
            LForearmButton.IsChecked = false;
            RForearmButton.IsChecked = false;
            LWristButton.IsChecked = false;
            RWristButton.IsChecked = false;
            LHandButton.IsChecked = false;
            RHandButton.IsChecked = false;
            LThumbButton.IsChecked = false;
            RThumbButton.IsChecked = false;
            LThumb2Button.IsChecked = false;
            RThumb2Button.IsChecked = false;
            LIndexButton.IsChecked = false;
            RIndexButton.IsChecked = false;
            LIndex2Button.IsChecked = false;
            RIndex2Button.IsChecked = false;
            LMiddleButton.IsChecked = false;
            RMiddleButton.IsChecked = false;
            LMiddle2Button.IsChecked = false;
            RMiddle2Button.IsChecked = false;
            LRingButton.IsChecked = false;
            RRingButton.IsChecked = false;
            LRing2Button.IsChecked = false;
            RRing2Button.IsChecked = false;
            RPinkyButton.IsChecked = false;
            LPinky2Button.IsChecked = false;
            RPinky2Button.IsChecked = false;
            PelvisButton.IsChecked = false;
            TailButton.IsChecked = false;
            Tail2Button.IsChecked = false;
            Tail3Button.IsChecked = false;
            Tail4Button.IsChecked = false;
            LThighButton.IsChecked = false;
            RThighButton.IsChecked = false;
            LKneeButton.IsChecked = false;
            RKneeButton.IsChecked = false;
            LCalfButton.IsChecked = false;
            RCalfButton.IsChecked = false;
            LFootButton.IsChecked = false;
            RFootButton.IsChecked = false;
            LToesButton.IsChecked = false;
            RToesButton.IsChecked = false;
            LEarringButton.IsChecked = false;
            REarringButton.IsChecked = false;
            LEarring2Button.IsChecked = false;
            REarring2Button.IsChecked = false;

            //Load Current Values for Slider
            CharacterDetails.LPinkyCheck = true;
        }
        private void LPinkyButton_Unchecked(object sender, RoutedEventArgs e)
        {
            CharacterDetails.LPinkyRotate = false;
        }
        #endregion

        #region RPinky
        private void RPinkyRot(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.RPinkyX.value = (float)quat.X;
            CharacterDetails.RPinkyY.value = (float)quat.Y;
            CharacterDetails.RPinkyZ.value = (float)quat.Z;
            CharacterDetails.RPinkyW.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneSlider.ValueChanged -= RPinkyRot;
            BoneSlider2.ValueChanged -= RPinkyRot;
            BoneSlider3.ValueChanged -= RPinkyRot;
        }

        private void RPinkyRot2(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.RPinkyX.value = (float)quat.X;
            CharacterDetails.RPinkyY.value = (float)quat.Y;
            CharacterDetails.RPinkyZ.value = (float)quat.Z;
            CharacterDetails.RPinkyW.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneUpDown.ValueChanged -= RPinkyRot2;
            BoneUpDown2.ValueChanged -= RPinkyRot2;
            BoneUpDown3.ValueChanged -= RPinkyRot2;
        }

        private void RPinkyButton_Checked(object sender, RoutedEventArgs e)
        {
            //Disable Other Selections
            HeadButton.IsChecked = false;
            NoseButton.IsChecked = false;
            NostrilsButton.IsChecked = false;
            ChinButton.IsChecked = false;
            LOutEyebrowButton.IsChecked = false;
            ROutEyebrowButton.IsChecked = false;
            LInEyebrowButton.IsChecked = false;
            RInEyebrowButton.IsChecked = false;
            LEyeButton.IsChecked = false;
            REyeButton.IsChecked = false;
            LEyelidButton.IsChecked = false;
            REyelidButton.IsChecked = false;
            LLowEyelidButton.IsChecked = false;
            RLowEyelidButton.IsChecked = false;
            LEarButton.IsChecked = false;
            REarButton.IsChecked = false;
            LCheekButton.IsChecked = false;
            RCheekButton.IsChecked = false;
            LMouthButton.IsChecked = false;
            RMouthButton.IsChecked = false;
            LUpLipButton.IsChecked = false;
            RUpLipButton.IsChecked = false;
            LLowLipButton.IsChecked = false;
            RLowLipButton.IsChecked = false;
            NeckButton.IsChecked = false;
            SternumButton.IsChecked = false;
            TorsoButton.IsChecked = false;
            WaistButton.IsChecked = false;
            LShoulderButton.IsChecked = false;
            RShoulderButton.IsChecked = false;
            LClavicleButton.IsChecked = false;
            RClavicleButton.IsChecked = false;
            LBreastButton.IsChecked = false;
            RBreastButton.IsChecked = false;
            LArmButton.IsChecked = false;
            RArmButton.IsChecked = false;
            LElbowButton.IsChecked = false;
            RElbowButton.IsChecked = false;
            LForearmButton.IsChecked = false;
            RForearmButton.IsChecked = false;
            LWristButton.IsChecked = false;
            RWristButton.IsChecked = false;
            LHandButton.IsChecked = false;
            RHandButton.IsChecked = false;
            LThumbButton.IsChecked = false;
            RThumbButton.IsChecked = false;
            LThumb2Button.IsChecked = false;
            RThumb2Button.IsChecked = false;
            LIndexButton.IsChecked = false;
            RIndexButton.IsChecked = false;
            LIndex2Button.IsChecked = false;
            RIndex2Button.IsChecked = false;
            LMiddleButton.IsChecked = false;
            RMiddleButton.IsChecked = false;
            LMiddle2Button.IsChecked = false;
            RMiddle2Button.IsChecked = false;
            LRingButton.IsChecked = false;
            RRingButton.IsChecked = false;
            LRing2Button.IsChecked = false;
            RRing2Button.IsChecked = false;
            LPinkyButton.IsChecked = false;
            LPinky2Button.IsChecked = false;
            RPinky2Button.IsChecked = false;
            PelvisButton.IsChecked = false;
            TailButton.IsChecked = false;
            Tail2Button.IsChecked = false;
            Tail3Button.IsChecked = false;
            Tail4Button.IsChecked = false;
            LThighButton.IsChecked = false;
            RThighButton.IsChecked = false;
            LKneeButton.IsChecked = false;
            RKneeButton.IsChecked = false;
            LCalfButton.IsChecked = false;
            RCalfButton.IsChecked = false;
            LFootButton.IsChecked = false;
            RFootButton.IsChecked = false;
            LToesButton.IsChecked = false;
            RToesButton.IsChecked = false;
            LEarringButton.IsChecked = false;
            REarringButton.IsChecked = false;
            LEarring2Button.IsChecked = false;
            REarring2Button.IsChecked = false;

            //Load Current Values for Slider
            CharacterDetails.RPinkyCheck = true;
        }
        private void RPinkyButton_Unchecked(object sender, RoutedEventArgs e)
        {
            CharacterDetails.RPinkyRotate = false;
        }
        #endregion

        #region LPinky2
        private void LPinky2Rot(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.LPinky2X.value = (float)quat.X;
            CharacterDetails.LPinky2Y.value = (float)quat.Y;
            CharacterDetails.LPinky2Z.value = (float)quat.Z;
            CharacterDetails.LPinky2W.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneSlider.ValueChanged -= LPinky2Rot;
            BoneSlider2.ValueChanged -= LPinky2Rot;
            BoneSlider3.ValueChanged -= LPinky2Rot;
        }

        private void LPinky2Rot2(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.LPinky2X.value = (float)quat.X;
            CharacterDetails.LPinky2Y.value = (float)quat.Y;
            CharacterDetails.LPinky2Z.value = (float)quat.Z;
            CharacterDetails.LPinky2W.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneUpDown.ValueChanged -= LPinky2Rot2;
            BoneUpDown2.ValueChanged -= LPinky2Rot2;
            BoneUpDown3.ValueChanged -= LPinky2Rot2;
        }

        private void LPinky2Button_Checked(object sender, RoutedEventArgs e)
        {
            //Disable Other Selections
            HeadButton.IsChecked = false;
            NoseButton.IsChecked = false;
            NostrilsButton.IsChecked = false;
            ChinButton.IsChecked = false;
            LOutEyebrowButton.IsChecked = false;
            ROutEyebrowButton.IsChecked = false;
            LInEyebrowButton.IsChecked = false;
            RInEyebrowButton.IsChecked = false;
            LEyeButton.IsChecked = false;
            REyeButton.IsChecked = false;
            LEyelidButton.IsChecked = false;
            REyelidButton.IsChecked = false;
            LLowEyelidButton.IsChecked = false;
            RLowEyelidButton.IsChecked = false;
            LEarButton.IsChecked = false;
            REarButton.IsChecked = false;
            LCheekButton.IsChecked = false;
            RCheekButton.IsChecked = false;
            LMouthButton.IsChecked = false;
            RMouthButton.IsChecked = false;
            LUpLipButton.IsChecked = false;
            RUpLipButton.IsChecked = false;
            LLowLipButton.IsChecked = false;
            RLowLipButton.IsChecked = false;
            NeckButton.IsChecked = false;
            SternumButton.IsChecked = false;
            TorsoButton.IsChecked = false;
            WaistButton.IsChecked = false;
            LShoulderButton.IsChecked = false;
            RShoulderButton.IsChecked = false;
            LClavicleButton.IsChecked = false;
            RClavicleButton.IsChecked = false;
            LBreastButton.IsChecked = false;
            RBreastButton.IsChecked = false;
            LArmButton.IsChecked = false;
            RArmButton.IsChecked = false;
            LElbowButton.IsChecked = false;
            RElbowButton.IsChecked = false;
            LForearmButton.IsChecked = false;
            RForearmButton.IsChecked = false;
            LWristButton.IsChecked = false;
            RWristButton.IsChecked = false;
            LHandButton.IsChecked = false;
            RHandButton.IsChecked = false;
            LThumbButton.IsChecked = false;
            RThumbButton.IsChecked = false;
            LThumb2Button.IsChecked = false;
            RThumb2Button.IsChecked = false;
            LIndexButton.IsChecked = false;
            RIndexButton.IsChecked = false;
            LIndex2Button.IsChecked = false;
            RIndex2Button.IsChecked = false;
            LMiddleButton.IsChecked = false;
            RMiddleButton.IsChecked = false;
            LMiddle2Button.IsChecked = false;
            RMiddle2Button.IsChecked = false;
            LRingButton.IsChecked = false;
            RRingButton.IsChecked = false;
            LRing2Button.IsChecked = false;
            RRing2Button.IsChecked = false;
            LPinkyButton.IsChecked = false;
            RPinkyButton.IsChecked = false;
            RPinky2Button.IsChecked = false;
            PelvisButton.IsChecked = false;
            TailButton.IsChecked = false;
            Tail2Button.IsChecked = false;
            Tail3Button.IsChecked = false;
            Tail4Button.IsChecked = false;
            LThighButton.IsChecked = false;
            RThighButton.IsChecked = false;
            LKneeButton.IsChecked = false;
            RKneeButton.IsChecked = false;
            LCalfButton.IsChecked = false;
            RCalfButton.IsChecked = false;
            LFootButton.IsChecked = false;
            RFootButton.IsChecked = false;
            LToesButton.IsChecked = false;
            RToesButton.IsChecked = false;
            LEarringButton.IsChecked = false;
            REarringButton.IsChecked = false;
            LEarring2Button.IsChecked = false;
            REarring2Button.IsChecked = false;

            //Load Current Values for Slider
            CharacterDetails.LPinky2Check = true;
        }
        private void LPinky2Button_Unchecked(object sender, RoutedEventArgs e)
        {
            CharacterDetails.LPinky2Rotate = false;
        }
        #endregion

        #region RPinky2
        private void RPinky2Rot(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.RPinky2X.value = (float)quat.X;
            CharacterDetails.RPinky2Y.value = (float)quat.Y;
            CharacterDetails.RPinky2Z.value = (float)quat.Z;
            CharacterDetails.RPinky2W.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneSlider.ValueChanged -= RPinky2Rot;
            BoneSlider2.ValueChanged -= RPinky2Rot;
            BoneSlider3.ValueChanged -= RPinky2Rot;
        }

        private void RPinky2Rot2(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.RPinky2X.value = (float)quat.X;
            CharacterDetails.RPinky2Y.value = (float)quat.Y;
            CharacterDetails.RPinky2Z.value = (float)quat.Z;
            CharacterDetails.RPinky2W.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneUpDown.ValueChanged -= RPinky2Rot2;
            BoneUpDown2.ValueChanged -= RPinky2Rot2;
            BoneUpDown3.ValueChanged -= RPinky2Rot2;
        }

        private void RPinky2Button_Checked(object sender, RoutedEventArgs e)
        {
            //Disable Other Selections
            HeadButton.IsChecked = false;
            NoseButton.IsChecked = false;
            NostrilsButton.IsChecked = false;
            ChinButton.IsChecked = false;
            LOutEyebrowButton.IsChecked = false;
            ROutEyebrowButton.IsChecked = false;
            LInEyebrowButton.IsChecked = false;
            RInEyebrowButton.IsChecked = false;
            LEyeButton.IsChecked = false;
            REyeButton.IsChecked = false;
            LEyelidButton.IsChecked = false;
            REyelidButton.IsChecked = false;
            LLowEyelidButton.IsChecked = false;
            RLowEyelidButton.IsChecked = false;
            LEarButton.IsChecked = false;
            REarButton.IsChecked = false;
            LCheekButton.IsChecked = false;
            RCheekButton.IsChecked = false;
            LMouthButton.IsChecked = false;
            RMouthButton.IsChecked = false;
            LUpLipButton.IsChecked = false;
            RUpLipButton.IsChecked = false;
            LLowLipButton.IsChecked = false;
            RLowLipButton.IsChecked = false;
            NeckButton.IsChecked = false;
            SternumButton.IsChecked = false;
            TorsoButton.IsChecked = false;
            WaistButton.IsChecked = false;
            LShoulderButton.IsChecked = false;
            RShoulderButton.IsChecked = false;
            LClavicleButton.IsChecked = false;
            RClavicleButton.IsChecked = false;
            LBreastButton.IsChecked = false;
            RBreastButton.IsChecked = false;
            LArmButton.IsChecked = false;
            RArmButton.IsChecked = false;
            LElbowButton.IsChecked = false;
            RElbowButton.IsChecked = false;
            LForearmButton.IsChecked = false;
            RForearmButton.IsChecked = false;
            LWristButton.IsChecked = false;
            RWristButton.IsChecked = false;
            LHandButton.IsChecked = false;
            RHandButton.IsChecked = false;
            LThumbButton.IsChecked = false;
            RThumbButton.IsChecked = false;
            LThumb2Button.IsChecked = false;
            RThumb2Button.IsChecked = false;
            LIndexButton.IsChecked = false;
            RIndexButton.IsChecked = false;
            LIndex2Button.IsChecked = false;
            RIndex2Button.IsChecked = false;
            LMiddleButton.IsChecked = false;
            RMiddleButton.IsChecked = false;
            LMiddle2Button.IsChecked = false;
            RMiddle2Button.IsChecked = false;
            LRingButton.IsChecked = false;
            RRingButton.IsChecked = false;
            LRing2Button.IsChecked = false;
            RRing2Button.IsChecked = false;
            LPinkyButton.IsChecked = false;
            RPinkyButton.IsChecked = false;
            LPinky2Button.IsChecked = false;
            PelvisButton.IsChecked = false;
            TailButton.IsChecked = false;
            Tail2Button.IsChecked = false;
            Tail3Button.IsChecked = false;
            Tail4Button.IsChecked = false;
            LThighButton.IsChecked = false;
            RThighButton.IsChecked = false;
            LKneeButton.IsChecked = false;
            RKneeButton.IsChecked = false;
            LCalfButton.IsChecked = false;
            RCalfButton.IsChecked = false;
            LFootButton.IsChecked = false;
            RFootButton.IsChecked = false;
            LToesButton.IsChecked = false;
            RToesButton.IsChecked = false;
            LEarringButton.IsChecked = false;
            REarringButton.IsChecked = false;
            LEarring2Button.IsChecked = false;
            REarring2Button.IsChecked = false;

            //Load Current Values for Slider
            CharacterDetails.RPinky2Check = true;
        }
        private void RPinky2Button_Unchecked(object sender, RoutedEventArgs e)
        {
            CharacterDetails.RPinky2Rotate = false;
        }
        #endregion

        #region Pelvis
        private void PelvisRot(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.PelvisX.value = (float)quat.X;
            CharacterDetails.PelvisY.value = (float)quat.Y;
            CharacterDetails.PelvisZ.value = (float)quat.Z;
            CharacterDetails.PelvisW.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneSlider.ValueChanged -= PelvisRot;
            BoneSlider2.ValueChanged -= PelvisRot;
            BoneSlider3.ValueChanged -= PelvisRot;
        }

        private void PelvisRot2(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.PelvisX.value = (float)quat.X;
            CharacterDetails.PelvisY.value = (float)quat.Y;
            CharacterDetails.PelvisZ.value = (float)quat.Z;
            CharacterDetails.PelvisW.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneUpDown.ValueChanged -= PelvisRot2;
            BoneUpDown2.ValueChanged -= PelvisRot2;
            BoneUpDown3.ValueChanged -= PelvisRot2;
        }

        private void PelvisButton_Checked(object sender, RoutedEventArgs e)
        {
            //Disable Other Selections
            HeadButton.IsChecked = false;
            NoseButton.IsChecked = false;
            NostrilsButton.IsChecked = false;
            ChinButton.IsChecked = false;
            LOutEyebrowButton.IsChecked = false;
            ROutEyebrowButton.IsChecked = false;
            LInEyebrowButton.IsChecked = false;
            RInEyebrowButton.IsChecked = false;
            LEyeButton.IsChecked = false;
            REyeButton.IsChecked = false;
            LEyelidButton.IsChecked = false;
            REyelidButton.IsChecked = false;
            LLowEyelidButton.IsChecked = false;
            RLowEyelidButton.IsChecked = false;
            LEarButton.IsChecked = false;
            REarButton.IsChecked = false;
            LCheekButton.IsChecked = false;
            RCheekButton.IsChecked = false;
            LMouthButton.IsChecked = false;
            RMouthButton.IsChecked = false;
            LUpLipButton.IsChecked = false;
            RUpLipButton.IsChecked = false;
            LLowLipButton.IsChecked = false;
            RLowLipButton.IsChecked = false;
            NeckButton.IsChecked = false;
            SternumButton.IsChecked = false;
            TorsoButton.IsChecked = false;
            WaistButton.IsChecked = false;
            LShoulderButton.IsChecked = false;
            RShoulderButton.IsChecked = false;
            LClavicleButton.IsChecked = false;
            RClavicleButton.IsChecked = false;
            LBreastButton.IsChecked = false;
            RBreastButton.IsChecked = false;
            LArmButton.IsChecked = false;
            RArmButton.IsChecked = false;
            LElbowButton.IsChecked = false;
            RElbowButton.IsChecked = false;
            LForearmButton.IsChecked = false;
            RForearmButton.IsChecked = false;
            LWristButton.IsChecked = false;
            RWristButton.IsChecked = false;
            LHandButton.IsChecked = false;
            RHandButton.IsChecked = false;
            LThumbButton.IsChecked = false;
            RThumbButton.IsChecked = false;
            LThumb2Button.IsChecked = false;
            RThumb2Button.IsChecked = false;
            LIndexButton.IsChecked = false;
            RIndexButton.IsChecked = false;
            LIndex2Button.IsChecked = false;
            RIndex2Button.IsChecked = false;
            LMiddleButton.IsChecked = false;
            RMiddleButton.IsChecked = false;
            LMiddle2Button.IsChecked = false;
            RMiddle2Button.IsChecked = false;
            LRingButton.IsChecked = false;
            RRingButton.IsChecked = false;
            LRing2Button.IsChecked = false;
            RRing2Button.IsChecked = false;
            LPinkyButton.IsChecked = false;
            RPinkyButton.IsChecked = false;
            LPinky2Button.IsChecked = false;
            RPinky2Button.IsChecked = false;
            TailButton.IsChecked = false;
            Tail2Button.IsChecked = false;
            Tail3Button.IsChecked = false;
            Tail4Button.IsChecked = false;
            LThighButton.IsChecked = false;
            RThighButton.IsChecked = false;
            LKneeButton.IsChecked = false;
            RKneeButton.IsChecked = false;
            LCalfButton.IsChecked = false;
            RCalfButton.IsChecked = false;
            LFootButton.IsChecked = false;
            RFootButton.IsChecked = false;
            LToesButton.IsChecked = false;
            RToesButton.IsChecked = false;
            LEarringButton.IsChecked = false;
            REarringButton.IsChecked = false;
            LEarring2Button.IsChecked = false;
            REarring2Button.IsChecked = false;

            //Load Current Values for Slider
            CharacterDetails.PelvisCheck = true;
        }
        private void PelvisButton_Unchecked(object sender, RoutedEventArgs e)
        {
            CharacterDetails.PelvisRotate = false;
        }
        #endregion

        #region Tail
        private void TailRot(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.TailX.value = (float)quat.X;
            CharacterDetails.TailY.value = (float)quat.Y;
            CharacterDetails.TailZ.value = (float)quat.Z;
            CharacterDetails.TailW.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneSlider.ValueChanged -= TailRot;
            BoneSlider2.ValueChanged -= TailRot;
            BoneSlider3.ValueChanged -= TailRot;
        }

        private void TailRot2(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.TailX.value = (float)quat.X;
            CharacterDetails.TailY.value = (float)quat.Y;
            CharacterDetails.TailZ.value = (float)quat.Z;
            CharacterDetails.TailW.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneUpDown.ValueChanged -= TailRot2;
            BoneUpDown2.ValueChanged -= TailRot2;
            BoneUpDown3.ValueChanged -= TailRot2;
        }

        private void TailButton_Checked(object sender, RoutedEventArgs e)
        {
            //Disable Other Selections
            HeadButton.IsChecked = false;
            NoseButton.IsChecked = false;
            NostrilsButton.IsChecked = false;
            ChinButton.IsChecked = false;
            LOutEyebrowButton.IsChecked = false;
            ROutEyebrowButton.IsChecked = false;
            LInEyebrowButton.IsChecked = false;
            RInEyebrowButton.IsChecked = false;
            LEyeButton.IsChecked = false;
            REyeButton.IsChecked = false;
            LEyelidButton.IsChecked = false;
            REyelidButton.IsChecked = false;
            LLowEyelidButton.IsChecked = false;
            RLowEyelidButton.IsChecked = false;
            LEarButton.IsChecked = false;
            REarButton.IsChecked = false;
            LCheekButton.IsChecked = false;
            RCheekButton.IsChecked = false;
            LMouthButton.IsChecked = false;
            RMouthButton.IsChecked = false;
            LUpLipButton.IsChecked = false;
            RUpLipButton.IsChecked = false;
            LLowLipButton.IsChecked = false;
            RLowLipButton.IsChecked = false;
            NeckButton.IsChecked = false;
            SternumButton.IsChecked = false;
            TorsoButton.IsChecked = false;
            WaistButton.IsChecked = false;
            LShoulderButton.IsChecked = false;
            RShoulderButton.IsChecked = false;
            LClavicleButton.IsChecked = false;
            RClavicleButton.IsChecked = false;
            LBreastButton.IsChecked = false;
            RBreastButton.IsChecked = false;
            LArmButton.IsChecked = false;
            RArmButton.IsChecked = false;
            LElbowButton.IsChecked = false;
            RElbowButton.IsChecked = false;
            LForearmButton.IsChecked = false;
            RForearmButton.IsChecked = false;
            LWristButton.IsChecked = false;
            RWristButton.IsChecked = false;
            LHandButton.IsChecked = false;
            RHandButton.IsChecked = false;
            LThumbButton.IsChecked = false;
            RThumbButton.IsChecked = false;
            LThumb2Button.IsChecked = false;
            RThumb2Button.IsChecked = false;
            LIndexButton.IsChecked = false;
            RIndexButton.IsChecked = false;
            LIndex2Button.IsChecked = false;
            RIndex2Button.IsChecked = false;
            LMiddleButton.IsChecked = false;
            RMiddleButton.IsChecked = false;
            LMiddle2Button.IsChecked = false;
            RMiddle2Button.IsChecked = false;
            LRingButton.IsChecked = false;
            RRingButton.IsChecked = false;
            LRing2Button.IsChecked = false;
            RRing2Button.IsChecked = false;
            LPinkyButton.IsChecked = false;
            RPinkyButton.IsChecked = false;
            LPinky2Button.IsChecked = false;
            RPinky2Button.IsChecked = false;
            PelvisButton.IsChecked = false;
            Tail2Button.IsChecked = false;
            Tail3Button.IsChecked = false;
            Tail4Button.IsChecked = false;
            LThighButton.IsChecked = false;
            RThighButton.IsChecked = false;
            LKneeButton.IsChecked = false;
            RKneeButton.IsChecked = false;
            LCalfButton.IsChecked = false;
            RCalfButton.IsChecked = false;
            LFootButton.IsChecked = false;
            RFootButton.IsChecked = false;
            LToesButton.IsChecked = false;
            RToesButton.IsChecked = false;
            LEarringButton.IsChecked = false;
            REarringButton.IsChecked = false;
            LEarring2Button.IsChecked = false;
            REarring2Button.IsChecked = false;

            //Load Current Values for Slider
            CharacterDetails.TailCheck = true;
        }
        private void TailButton_Unchecked(object sender, RoutedEventArgs e)
        {
            CharacterDetails.TailRotate = false;
        }
        #endregion

        #region Tail2
        private void Tail2Rot(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.Tail2X.value = (float)quat.X;
            CharacterDetails.Tail2Y.value = (float)quat.Y;
            CharacterDetails.Tail2Z.value = (float)quat.Z;
            CharacterDetails.Tail2W.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneSlider.ValueChanged -= Tail2Rot;
            BoneSlider2.ValueChanged -= Tail2Rot;
            BoneSlider3.ValueChanged -= Tail2Rot;
        }

        private void Tail2Rot2(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.Tail2X.value = (float)quat.X;
            CharacterDetails.Tail2Y.value = (float)quat.Y;
            CharacterDetails.Tail2Z.value = (float)quat.Z;
            CharacterDetails.Tail2W.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneUpDown.ValueChanged -= Tail2Rot2;
            BoneUpDown2.ValueChanged -= Tail2Rot2;
            BoneUpDown3.ValueChanged -= Tail2Rot2;
        }

        private void Tail2Button_Checked(object sender, RoutedEventArgs e)
        {
            //Disable Other Selections
            HeadButton.IsChecked = false;
            NoseButton.IsChecked = false;
            NostrilsButton.IsChecked = false;
            ChinButton.IsChecked = false;
            LOutEyebrowButton.IsChecked = false;
            ROutEyebrowButton.IsChecked = false;
            LInEyebrowButton.IsChecked = false;
            RInEyebrowButton.IsChecked = false;
            LEyeButton.IsChecked = false;
            REyeButton.IsChecked = false;
            LEyelidButton.IsChecked = false;
            REyelidButton.IsChecked = false;
            LLowEyelidButton.IsChecked = false;
            RLowEyelidButton.IsChecked = false;
            LEarButton.IsChecked = false;
            REarButton.IsChecked = false;
            LCheekButton.IsChecked = false;
            RCheekButton.IsChecked = false;
            LMouthButton.IsChecked = false;
            RMouthButton.IsChecked = false;
            LUpLipButton.IsChecked = false;
            RUpLipButton.IsChecked = false;
            LLowLipButton.IsChecked = false;
            RLowLipButton.IsChecked = false;
            NeckButton.IsChecked = false;
            SternumButton.IsChecked = false;
            TorsoButton.IsChecked = false;
            WaistButton.IsChecked = false;
            LShoulderButton.IsChecked = false;
            RShoulderButton.IsChecked = false;
            LClavicleButton.IsChecked = false;
            RClavicleButton.IsChecked = false;
            LBreastButton.IsChecked = false;
            RBreastButton.IsChecked = false;
            LArmButton.IsChecked = false;
            RArmButton.IsChecked = false;
            LElbowButton.IsChecked = false;
            RElbowButton.IsChecked = false;
            LForearmButton.IsChecked = false;
            RForearmButton.IsChecked = false;
            LWristButton.IsChecked = false;
            RWristButton.IsChecked = false;
            LHandButton.IsChecked = false;
            RHandButton.IsChecked = false;
            LThumbButton.IsChecked = false;
            RThumbButton.IsChecked = false;
            LThumb2Button.IsChecked = false;
            RThumb2Button.IsChecked = false;
            LIndexButton.IsChecked = false;
            RIndexButton.IsChecked = false;
            LIndex2Button.IsChecked = false;
            RIndex2Button.IsChecked = false;
            LMiddleButton.IsChecked = false;
            RMiddleButton.IsChecked = false;
            LMiddle2Button.IsChecked = false;
            RMiddle2Button.IsChecked = false;
            LRingButton.IsChecked = false;
            RRingButton.IsChecked = false;
            LRing2Button.IsChecked = false;
            RRing2Button.IsChecked = false;
            LPinkyButton.IsChecked = false;
            RPinkyButton.IsChecked = false;
            LPinky2Button.IsChecked = false;
            RPinky2Button.IsChecked = false;
            PelvisButton.IsChecked = false;
            TailButton.IsChecked = false;
            Tail3Button.IsChecked = false;
            Tail4Button.IsChecked = false;
            LThighButton.IsChecked = false;
            RThighButton.IsChecked = false;
            LKneeButton.IsChecked = false;
            RKneeButton.IsChecked = false;
            LCalfButton.IsChecked = false;
            RCalfButton.IsChecked = false;
            LFootButton.IsChecked = false;
            RFootButton.IsChecked = false;
            LToesButton.IsChecked = false;
            RToesButton.IsChecked = false;
            LEarringButton.IsChecked = false;
            REarringButton.IsChecked = false;
            LEarring2Button.IsChecked = false;
            REarring2Button.IsChecked = false;

            //Load Current Values for Slider
            CharacterDetails.Tail2Check = true;
        }
        private void Tail2Button_Unchecked(object sender, RoutedEventArgs e)
        {
            CharacterDetails.Tail2Rotate = false;
        }
        #endregion

        #region Tail3
        private void Tail3Rot(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.Tail3X.value = (float)quat.X;
            CharacterDetails.Tail3Y.value = (float)quat.Y;
            CharacterDetails.Tail3Z.value = (float)quat.Z;
            CharacterDetails.Tail3W.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneSlider.ValueChanged -= Tail3Rot;
            BoneSlider2.ValueChanged -= Tail3Rot;
            BoneSlider3.ValueChanged -= Tail3Rot;
        }

        private void Tail3Rot2(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.Tail3X.value = (float)quat.X;
            CharacterDetails.Tail3Y.value = (float)quat.Y;
            CharacterDetails.Tail3Z.value = (float)quat.Z;
            CharacterDetails.Tail3W.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneUpDown.ValueChanged -= Tail3Rot2;
            BoneUpDown2.ValueChanged -= Tail3Rot2;
            BoneUpDown3.ValueChanged -= Tail3Rot2;
        }

        private void Tail3Button_Checked(object sender, RoutedEventArgs e)
        {
            //Disable Other Selections
            HeadButton.IsChecked = false;
            NoseButton.IsChecked = false;
            NostrilsButton.IsChecked = false;
            ChinButton.IsChecked = false;
            LOutEyebrowButton.IsChecked = false;
            ROutEyebrowButton.IsChecked = false;
            LInEyebrowButton.IsChecked = false;
            RInEyebrowButton.IsChecked = false;
            LEyeButton.IsChecked = false;
            REyeButton.IsChecked = false;
            LEyelidButton.IsChecked = false;
            REyelidButton.IsChecked = false;
            LLowEyelidButton.IsChecked = false;
            RLowEyelidButton.IsChecked = false;
            LEarButton.IsChecked = false;
            REarButton.IsChecked = false;
            LCheekButton.IsChecked = false;
            RCheekButton.IsChecked = false;
            LMouthButton.IsChecked = false;
            RMouthButton.IsChecked = false;
            LUpLipButton.IsChecked = false;
            RUpLipButton.IsChecked = false;
            LLowLipButton.IsChecked = false;
            RLowLipButton.IsChecked = false;
            NeckButton.IsChecked = false;
            SternumButton.IsChecked = false;
            TorsoButton.IsChecked = false;
            WaistButton.IsChecked = false;
            LShoulderButton.IsChecked = false;
            RShoulderButton.IsChecked = false;
            LClavicleButton.IsChecked = false;
            RClavicleButton.IsChecked = false;
            LBreastButton.IsChecked = false;
            RBreastButton.IsChecked = false;
            LArmButton.IsChecked = false;
            RArmButton.IsChecked = false;
            LElbowButton.IsChecked = false;
            RElbowButton.IsChecked = false;
            LForearmButton.IsChecked = false;
            RForearmButton.IsChecked = false;
            LWristButton.IsChecked = false;
            RWristButton.IsChecked = false;
            LHandButton.IsChecked = false;
            RHandButton.IsChecked = false;
            LThumbButton.IsChecked = false;
            RThumbButton.IsChecked = false;
            LThumb2Button.IsChecked = false;
            RThumb2Button.IsChecked = false;
            LIndexButton.IsChecked = false;
            RIndexButton.IsChecked = false;
            LIndex2Button.IsChecked = false;
            RIndex2Button.IsChecked = false;
            LMiddleButton.IsChecked = false;
            RMiddleButton.IsChecked = false;
            LMiddle2Button.IsChecked = false;
            RMiddle2Button.IsChecked = false;
            LRingButton.IsChecked = false;
            RRingButton.IsChecked = false;
            LRing2Button.IsChecked = false;
            RRing2Button.IsChecked = false;
            LPinkyButton.IsChecked = false;
            RPinkyButton.IsChecked = false;
            LPinky2Button.IsChecked = false;
            RPinky2Button.IsChecked = false;
            PelvisButton.IsChecked = false;
            TailButton.IsChecked = false;
            Tail2Button.IsChecked = false;
            Tail4Button.IsChecked = false;
            LThighButton.IsChecked = false;
            RThighButton.IsChecked = false;
            LKneeButton.IsChecked = false;
            RKneeButton.IsChecked = false;
            LCalfButton.IsChecked = false;
            RCalfButton.IsChecked = false;
            LFootButton.IsChecked = false;
            RFootButton.IsChecked = false;
            LToesButton.IsChecked = false;
            RToesButton.IsChecked = false;
            LEarringButton.IsChecked = false;
            REarringButton.IsChecked = false;
            LEarring2Button.IsChecked = false;
            REarring2Button.IsChecked = false;

            //Load Current Values for Slider
            CharacterDetails.Tail3Check = true;
        }
        private void Tail3Button_Unchecked(object sender, RoutedEventArgs e)
        {
            CharacterDetails.Tail3Rotate = false;
        }
        #endregion

        #region Tail4
        private void Tail4Rot(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.Tail4X.value = (float)quat.X;
            CharacterDetails.Tail4Y.value = (float)quat.Y;
            CharacterDetails.Tail4Z.value = (float)quat.Z;
            CharacterDetails.Tail4W.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneSlider.ValueChanged -= Tail4Rot;
            BoneSlider2.ValueChanged -= Tail4Rot;
            BoneSlider3.ValueChanged -= Tail4Rot;
        }

        private void Tail4Rot2(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.Tail4X.value = (float)quat.X;
            CharacterDetails.Tail4Y.value = (float)quat.Y;
            CharacterDetails.Tail4Z.value = (float)quat.Z;
            CharacterDetails.Tail4W.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneUpDown.ValueChanged -= Tail4Rot2;
            BoneUpDown2.ValueChanged -= Tail4Rot2;
            BoneUpDown3.ValueChanged -= Tail4Rot2;
        }

        private void Tail4Button_Checked(object sender, RoutedEventArgs e)
        {
            //Disable Other Selections
            HeadButton.IsChecked = false;
            NoseButton.IsChecked = false;
            NostrilsButton.IsChecked = false;
            ChinButton.IsChecked = false;
            LOutEyebrowButton.IsChecked = false;
            ROutEyebrowButton.IsChecked = false;
            LInEyebrowButton.IsChecked = false;
            RInEyebrowButton.IsChecked = false;
            LEyeButton.IsChecked = false;
            REyeButton.IsChecked = false;
            LEyelidButton.IsChecked = false;
            REyelidButton.IsChecked = false;
            LLowEyelidButton.IsChecked = false;
            RLowEyelidButton.IsChecked = false;
            LEarButton.IsChecked = false;
            REarButton.IsChecked = false;
            LCheekButton.IsChecked = false;
            RCheekButton.IsChecked = false;
            LMouthButton.IsChecked = false;
            RMouthButton.IsChecked = false;
            LUpLipButton.IsChecked = false;
            RUpLipButton.IsChecked = false;
            LLowLipButton.IsChecked = false;
            RLowLipButton.IsChecked = false;
            NeckButton.IsChecked = false;
            SternumButton.IsChecked = false;
            TorsoButton.IsChecked = false;
            WaistButton.IsChecked = false;
            LShoulderButton.IsChecked = false;
            RShoulderButton.IsChecked = false;
            LClavicleButton.IsChecked = false;
            RClavicleButton.IsChecked = false;
            LBreastButton.IsChecked = false;
            RBreastButton.IsChecked = false;
            LArmButton.IsChecked = false;
            RArmButton.IsChecked = false;
            LElbowButton.IsChecked = false;
            RElbowButton.IsChecked = false;
            LForearmButton.IsChecked = false;
            RForearmButton.IsChecked = false;
            LWristButton.IsChecked = false;
            RWristButton.IsChecked = false;
            LHandButton.IsChecked = false;
            RHandButton.IsChecked = false;
            LThumbButton.IsChecked = false;
            RThumbButton.IsChecked = false;
            LThumb2Button.IsChecked = false;
            RThumb2Button.IsChecked = false;
            LIndexButton.IsChecked = false;
            RIndexButton.IsChecked = false;
            LIndex2Button.IsChecked = false;
            RIndex2Button.IsChecked = false;
            LMiddleButton.IsChecked = false;
            RMiddleButton.IsChecked = false;
            LMiddle2Button.IsChecked = false;
            RMiddle2Button.IsChecked = false;
            LRingButton.IsChecked = false;
            RRingButton.IsChecked = false;
            LRing2Button.IsChecked = false;
            RRing2Button.IsChecked = false;
            LPinkyButton.IsChecked = false;
            RPinkyButton.IsChecked = false;
            LPinky2Button.IsChecked = false;
            RPinky2Button.IsChecked = false;
            PelvisButton.IsChecked = false;
            TailButton.IsChecked = false;
            Tail2Button.IsChecked = false;
            Tail3Button.IsChecked = false;
            LThighButton.IsChecked = false;
            RThighButton.IsChecked = false;
            LKneeButton.IsChecked = false;
            RKneeButton.IsChecked = false;
            LCalfButton.IsChecked = false;
            RCalfButton.IsChecked = false;
            LFootButton.IsChecked = false;
            RFootButton.IsChecked = false;
            LToesButton.IsChecked = false;
            RToesButton.IsChecked = false;
            LEarringButton.IsChecked = false;
            REarringButton.IsChecked = false;
            LEarring2Button.IsChecked = false;
            REarring2Button.IsChecked = false;

            //Load Current Values for Slider
            CharacterDetails.Tail4Check = true;
        }
        private void Tail4Button_Unchecked(object sender, RoutedEventArgs e)
        {
            CharacterDetails.Tail4Rotate = false;
        }
        #endregion

        #region LThigh
        private void LThighRot(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.LThighX.value = (float)quat.X;
            CharacterDetails.LThighY.value = (float)quat.Y;
            CharacterDetails.LThighZ.value = (float)quat.Z;
            CharacterDetails.LThighW.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneSlider.ValueChanged -= LThighRot;
            BoneSlider2.ValueChanged -= LThighRot;
            BoneSlider3.ValueChanged -= LThighRot;
        }

        private void LThighRot2(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.LThighX.value = (float)quat.X;
            CharacterDetails.LThighY.value = (float)quat.Y;
            CharacterDetails.LThighZ.value = (float)quat.Z;
            CharacterDetails.LThighW.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneUpDown.ValueChanged -= LThighRot2;
            BoneUpDown2.ValueChanged -= LThighRot2;
            BoneUpDown3.ValueChanged -= LThighRot2;
        }

        private void LThighButton_Checked(object sender, RoutedEventArgs e)
        {
            //Disable Other Selections
            HeadButton.IsChecked = false;
            NoseButton.IsChecked = false;
            NostrilsButton.IsChecked = false;
            ChinButton.IsChecked = false;
            LOutEyebrowButton.IsChecked = false;
            ROutEyebrowButton.IsChecked = false;
            LInEyebrowButton.IsChecked = false;
            RInEyebrowButton.IsChecked = false;
            LEyeButton.IsChecked = false;
            REyeButton.IsChecked = false;
            LEyelidButton.IsChecked = false;
            REyelidButton.IsChecked = false;
            LLowEyelidButton.IsChecked = false;
            RLowEyelidButton.IsChecked = false;
            LEarButton.IsChecked = false;
            REarButton.IsChecked = false;
            LCheekButton.IsChecked = false;
            RCheekButton.IsChecked = false;
            LMouthButton.IsChecked = false;
            RMouthButton.IsChecked = false;
            LUpLipButton.IsChecked = false;
            RUpLipButton.IsChecked = false;
            LLowLipButton.IsChecked = false;
            RLowLipButton.IsChecked = false;
            NeckButton.IsChecked = false;
            SternumButton.IsChecked = false;
            TorsoButton.IsChecked = false;
            WaistButton.IsChecked = false;
            LShoulderButton.IsChecked = false;
            RShoulderButton.IsChecked = false;
            LClavicleButton.IsChecked = false;
            RClavicleButton.IsChecked = false;
            LBreastButton.IsChecked = false;
            RBreastButton.IsChecked = false;
            LArmButton.IsChecked = false;
            RArmButton.IsChecked = false;
            LElbowButton.IsChecked = false;
            RElbowButton.IsChecked = false;
            LForearmButton.IsChecked = false;
            RForearmButton.IsChecked = false;
            LWristButton.IsChecked = false;
            RWristButton.IsChecked = false;
            LHandButton.IsChecked = false;
            RHandButton.IsChecked = false;
            LThumbButton.IsChecked = false;
            RThumbButton.IsChecked = false;
            LThumb2Button.IsChecked = false;
            RThumb2Button.IsChecked = false;
            LIndexButton.IsChecked = false;
            RIndexButton.IsChecked = false;
            LIndex2Button.IsChecked = false;
            RIndex2Button.IsChecked = false;
            LMiddleButton.IsChecked = false;
            RMiddleButton.IsChecked = false;
            LMiddle2Button.IsChecked = false;
            RMiddle2Button.IsChecked = false;
            LRingButton.IsChecked = false;
            RRingButton.IsChecked = false;
            LRing2Button.IsChecked = false;
            RRing2Button.IsChecked = false;
            LPinkyButton.IsChecked = false;
            RPinkyButton.IsChecked = false;
            LPinky2Button.IsChecked = false;
            RPinky2Button.IsChecked = false;
            PelvisButton.IsChecked = false;
            TailButton.IsChecked = false;
            Tail2Button.IsChecked = false;
            Tail3Button.IsChecked = false;
            Tail4Button.IsChecked = false;
            RThighButton.IsChecked = false;
            LKneeButton.IsChecked = false;
            RKneeButton.IsChecked = false;
            LCalfButton.IsChecked = false;
            RCalfButton.IsChecked = false;
            LFootButton.IsChecked = false;
            RFootButton.IsChecked = false;
            LToesButton.IsChecked = false;
            RToesButton.IsChecked = false;
            LEarringButton.IsChecked = false;
            REarringButton.IsChecked = false;
            LEarring2Button.IsChecked = false;
            REarring2Button.IsChecked = false;

            //Load Current Values for Slider
            CharacterDetails.LThighCheck = true;
        }
        private void LThighButton_Unchecked(object sender, RoutedEventArgs e)
        {
            CharacterDetails.LThighRotate = false;
        }
        #endregion

        #region RThigh
        private void RThighRot(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.RThighX.value = (float)quat.X;
            CharacterDetails.RThighY.value = (float)quat.Y;
            CharacterDetails.RThighZ.value = (float)quat.Z;
            CharacterDetails.RThighW.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneSlider.ValueChanged -= RThighRot;
            BoneSlider2.ValueChanged -= RThighRot;
            BoneSlider3.ValueChanged -= RThighRot;
        }

        private void RThighRot2(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.RThighX.value = (float)quat.X;
            CharacterDetails.RThighY.value = (float)quat.Y;
            CharacterDetails.RThighZ.value = (float)quat.Z;
            CharacterDetails.RThighW.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneUpDown.ValueChanged -= RThighRot2;
            BoneUpDown2.ValueChanged -= RThighRot2;
            BoneUpDown3.ValueChanged -= RThighRot2;
        }

        private void RThighButton_Checked(object sender, RoutedEventArgs e)
        {
            //Disable Other Selections
            HeadButton.IsChecked = false;
            NoseButton.IsChecked = false;
            NostrilsButton.IsChecked = false;
            ChinButton.IsChecked = false;
            LOutEyebrowButton.IsChecked = false;
            ROutEyebrowButton.IsChecked = false;
            LInEyebrowButton.IsChecked = false;
            RInEyebrowButton.IsChecked = false;
            LEyeButton.IsChecked = false;
            REyeButton.IsChecked = false;
            LEyelidButton.IsChecked = false;
            REyelidButton.IsChecked = false;
            LLowEyelidButton.IsChecked = false;
            RLowEyelidButton.IsChecked = false;
            LEarButton.IsChecked = false;
            REarButton.IsChecked = false;
            LCheekButton.IsChecked = false;
            RCheekButton.IsChecked = false;
            LMouthButton.IsChecked = false;
            RMouthButton.IsChecked = false;
            LUpLipButton.IsChecked = false;
            RUpLipButton.IsChecked = false;
            LLowLipButton.IsChecked = false;
            RLowLipButton.IsChecked = false;
            NeckButton.IsChecked = false;
            SternumButton.IsChecked = false;
            TorsoButton.IsChecked = false;
            WaistButton.IsChecked = false;
            LShoulderButton.IsChecked = false;
            RShoulderButton.IsChecked = false;
            LClavicleButton.IsChecked = false;
            RClavicleButton.IsChecked = false;
            LBreastButton.IsChecked = false;
            RBreastButton.IsChecked = false;
            LArmButton.IsChecked = false;
            RArmButton.IsChecked = false;
            LElbowButton.IsChecked = false;
            RElbowButton.IsChecked = false;
            LForearmButton.IsChecked = false;
            RForearmButton.IsChecked = false;
            LWristButton.IsChecked = false;
            RWristButton.IsChecked = false;
            LHandButton.IsChecked = false;
            RHandButton.IsChecked = false;
            LThumbButton.IsChecked = false;
            RThumbButton.IsChecked = false;
            LThumb2Button.IsChecked = false;
            RThumb2Button.IsChecked = false;
            LIndexButton.IsChecked = false;
            RIndexButton.IsChecked = false;
            LIndex2Button.IsChecked = false;
            RIndex2Button.IsChecked = false;
            LMiddleButton.IsChecked = false;
            RMiddleButton.IsChecked = false;
            LMiddle2Button.IsChecked = false;
            RMiddle2Button.IsChecked = false;
            LRingButton.IsChecked = false;
            RRingButton.IsChecked = false;
            LRing2Button.IsChecked = false;
            RRing2Button.IsChecked = false;
            LPinkyButton.IsChecked = false;
            RPinkyButton.IsChecked = false;
            LPinky2Button.IsChecked = false;
            RPinky2Button.IsChecked = false;
            PelvisButton.IsChecked = false;
            TailButton.IsChecked = false;
            Tail2Button.IsChecked = false;
            Tail3Button.IsChecked = false;
            Tail4Button.IsChecked = false;
            LThighButton.IsChecked = false;
            LKneeButton.IsChecked = false;
            RKneeButton.IsChecked = false;
            LCalfButton.IsChecked = false;
            RCalfButton.IsChecked = false;
            LFootButton.IsChecked = false;
            RFootButton.IsChecked = false;
            LToesButton.IsChecked = false;
            RToesButton.IsChecked = false;
            LEarringButton.IsChecked = false;
            REarringButton.IsChecked = false;
            LEarring2Button.IsChecked = false;
            REarring2Button.IsChecked = false;

            //Load Current Values for Slider
            CharacterDetails.RThighCheck = true;
        }
        private void RThighButton_Unchecked(object sender, RoutedEventArgs e)
        {
            CharacterDetails.RThighRotate = false;
        }
        #endregion

        #region LKnee
        private void LKneeRot(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.LKneeX.value = (float)quat.X;
            CharacterDetails.LKneeY.value = (float)quat.Y;
            CharacterDetails.LKneeZ.value = (float)quat.Z;
            CharacterDetails.LKneeW.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneSlider.ValueChanged -= LKneeRot;
            BoneSlider2.ValueChanged -= LKneeRot;
            BoneSlider3.ValueChanged -= LKneeRot;
        }

        private void LKneeRot2(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.LKneeX.value = (float)quat.X;
            CharacterDetails.LKneeY.value = (float)quat.Y;
            CharacterDetails.LKneeZ.value = (float)quat.Z;
            CharacterDetails.LKneeW.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneUpDown.ValueChanged -= LKneeRot2;
            BoneUpDown2.ValueChanged -= LKneeRot2;
            BoneUpDown3.ValueChanged -= LKneeRot2;
        }

        private void LKneeButton_Checked(object sender, RoutedEventArgs e)
        {
            //Disable Other Selections
            HeadButton.IsChecked = false;
            NoseButton.IsChecked = false;
            NostrilsButton.IsChecked = false;
            ChinButton.IsChecked = false;
            LOutEyebrowButton.IsChecked = false;
            ROutEyebrowButton.IsChecked = false;
            LInEyebrowButton.IsChecked = false;
            RInEyebrowButton.IsChecked = false;
            LEyeButton.IsChecked = false;
            REyeButton.IsChecked = false;
            LEyelidButton.IsChecked = false;
            REyelidButton.IsChecked = false;
            LLowEyelidButton.IsChecked = false;
            RLowEyelidButton.IsChecked = false;
            LEarButton.IsChecked = false;
            REarButton.IsChecked = false;
            LCheekButton.IsChecked = false;
            RCheekButton.IsChecked = false;
            LMouthButton.IsChecked = false;
            RMouthButton.IsChecked = false;
            LUpLipButton.IsChecked = false;
            RUpLipButton.IsChecked = false;
            LLowLipButton.IsChecked = false;
            RLowLipButton.IsChecked = false;
            NeckButton.IsChecked = false;
            SternumButton.IsChecked = false;
            TorsoButton.IsChecked = false;
            WaistButton.IsChecked = false;
            LShoulderButton.IsChecked = false;
            RShoulderButton.IsChecked = false;
            LClavicleButton.IsChecked = false;
            RClavicleButton.IsChecked = false;
            LBreastButton.IsChecked = false;
            RBreastButton.IsChecked = false;
            LArmButton.IsChecked = false;
            RArmButton.IsChecked = false;
            LElbowButton.IsChecked = false;
            RElbowButton.IsChecked = false;
            LForearmButton.IsChecked = false;
            RForearmButton.IsChecked = false;
            LWristButton.IsChecked = false;
            RWristButton.IsChecked = false;
            LHandButton.IsChecked = false;
            RHandButton.IsChecked = false;
            LThumbButton.IsChecked = false;
            RThumbButton.IsChecked = false;
            LThumb2Button.IsChecked = false;
            RThumb2Button.IsChecked = false;
            LIndexButton.IsChecked = false;
            RIndexButton.IsChecked = false;
            LIndex2Button.IsChecked = false;
            RIndex2Button.IsChecked = false;
            LMiddleButton.IsChecked = false;
            RMiddleButton.IsChecked = false;
            LMiddle2Button.IsChecked = false;
            RMiddle2Button.IsChecked = false;
            LRingButton.IsChecked = false;
            RRingButton.IsChecked = false;
            LRing2Button.IsChecked = false;
            RRing2Button.IsChecked = false;
            LPinkyButton.IsChecked = false;
            RPinkyButton.IsChecked = false;
            LPinky2Button.IsChecked = false;
            RPinky2Button.IsChecked = false;
            PelvisButton.IsChecked = false;
            TailButton.IsChecked = false;
            Tail2Button.IsChecked = false;
            Tail3Button.IsChecked = false;
            Tail4Button.IsChecked = false;
            LThighButton.IsChecked = false;
            RThighButton.IsChecked = false;
            RKneeButton.IsChecked = false;
            LCalfButton.IsChecked = false;
            RCalfButton.IsChecked = false;
            LFootButton.IsChecked = false;
            RFootButton.IsChecked = false;
            LToesButton.IsChecked = false;
            RToesButton.IsChecked = false;
            LEarringButton.IsChecked = false;
            REarringButton.IsChecked = false;
            LEarring2Button.IsChecked = false;
            REarring2Button.IsChecked = false;

            //Load Current Values for Slider
            CharacterDetails.LKneeCheck = true;
        }
        private void LKneeButton_Unchecked(object sender, RoutedEventArgs e)
        {
            CharacterDetails.LKneeRotate = false;
        }
        #endregion

        #region RKnee
        private void RKneeRot(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.RKneeX.value = (float)quat.X;
            CharacterDetails.RKneeY.value = (float)quat.Y;
            CharacterDetails.RKneeZ.value = (float)quat.Z;
            CharacterDetails.RKneeW.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneSlider.ValueChanged -= RKneeRot;
            BoneSlider2.ValueChanged -= RKneeRot;
            BoneSlider3.ValueChanged -= RKneeRot;
        }

        private void RKneeRot2(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.RKneeX.value = (float)quat.X;
            CharacterDetails.RKneeY.value = (float)quat.Y;
            CharacterDetails.RKneeZ.value = (float)quat.Z;
            CharacterDetails.RKneeW.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneUpDown.ValueChanged -= RKneeRot2;
            BoneUpDown2.ValueChanged -= RKneeRot2;
            BoneUpDown3.ValueChanged -= RKneeRot2;
        }

        private void RKneeButton_Checked(object sender, RoutedEventArgs e)
        {
            //Disable Other Selections
            HeadButton.IsChecked = false;
            NoseButton.IsChecked = false;
            NostrilsButton.IsChecked = false;
            ChinButton.IsChecked = false;
            LOutEyebrowButton.IsChecked = false;
            ROutEyebrowButton.IsChecked = false;
            LInEyebrowButton.IsChecked = false;
            RInEyebrowButton.IsChecked = false;
            LEyeButton.IsChecked = false;
            REyeButton.IsChecked = false;
            LEyelidButton.IsChecked = false;
            REyelidButton.IsChecked = false;
            LLowEyelidButton.IsChecked = false;
            RLowEyelidButton.IsChecked = false;
            LEarButton.IsChecked = false;
            REarButton.IsChecked = false;
            LCheekButton.IsChecked = false;
            RCheekButton.IsChecked = false;
            LMouthButton.IsChecked = false;
            RMouthButton.IsChecked = false;
            LUpLipButton.IsChecked = false;
            RUpLipButton.IsChecked = false;
            LLowLipButton.IsChecked = false;
            RLowLipButton.IsChecked = false;
            NeckButton.IsChecked = false;
            SternumButton.IsChecked = false;
            TorsoButton.IsChecked = false;
            WaistButton.IsChecked = false;
            LShoulderButton.IsChecked = false;
            RShoulderButton.IsChecked = false;
            LClavicleButton.IsChecked = false;
            RClavicleButton.IsChecked = false;
            LBreastButton.IsChecked = false;
            RBreastButton.IsChecked = false;
            LArmButton.IsChecked = false;
            RArmButton.IsChecked = false;
            LElbowButton.IsChecked = false;
            RElbowButton.IsChecked = false;
            LForearmButton.IsChecked = false;
            RForearmButton.IsChecked = false;
            LWristButton.IsChecked = false;
            RWristButton.IsChecked = false;
            LHandButton.IsChecked = false;
            RHandButton.IsChecked = false;
            LThumbButton.IsChecked = false;
            RThumbButton.IsChecked = false;
            LThumb2Button.IsChecked = false;
            RThumb2Button.IsChecked = false;
            LIndexButton.IsChecked = false;
            RIndexButton.IsChecked = false;
            LIndex2Button.IsChecked = false;
            RIndex2Button.IsChecked = false;
            LMiddleButton.IsChecked = false;
            RMiddleButton.IsChecked = false;
            LMiddle2Button.IsChecked = false;
            RMiddle2Button.IsChecked = false;
            LRingButton.IsChecked = false;
            RRingButton.IsChecked = false;
            LRing2Button.IsChecked = false;
            RRing2Button.IsChecked = false;
            LPinkyButton.IsChecked = false;
            RPinkyButton.IsChecked = false;
            LPinky2Button.IsChecked = false;
            RPinky2Button.IsChecked = false;
            PelvisButton.IsChecked = false;
            TailButton.IsChecked = false;
            Tail2Button.IsChecked = false;
            Tail3Button.IsChecked = false;
            Tail4Button.IsChecked = false;
            LThighButton.IsChecked = false;
            RThighButton.IsChecked = false;
            LKneeButton.IsChecked = false;
            LCalfButton.IsChecked = false;
            RCalfButton.IsChecked = false;
            LFootButton.IsChecked = false;
            RFootButton.IsChecked = false;
            LToesButton.IsChecked = false;
            RToesButton.IsChecked = false;
            LEarringButton.IsChecked = false;
            REarringButton.IsChecked = false;
            LEarring2Button.IsChecked = false;
            REarring2Button.IsChecked = false;

            //Load Current Values for Slider
            CharacterDetails.RKneeCheck = true;
        }
        private void RKneeButton_Unchecked(object sender, RoutedEventArgs e)
        {
            CharacterDetails.RKneeRotate = false;
        }
        #endregion

        #region LCalf
        private void LCalfRot(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.LCalfX.value = (float)quat.X;
            CharacterDetails.LCalfY.value = (float)quat.Y;
            CharacterDetails.LCalfZ.value = (float)quat.Z;
            CharacterDetails.LCalfW.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneSlider.ValueChanged -= LCalfRot;
            BoneSlider2.ValueChanged -= LCalfRot;
            BoneSlider3.ValueChanged -= LCalfRot;
        }

        private void LCalfRot2(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.LCalfX.value = (float)quat.X;
            CharacterDetails.LCalfY.value = (float)quat.Y;
            CharacterDetails.LCalfZ.value = (float)quat.Z;
            CharacterDetails.LCalfW.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneUpDown.ValueChanged -= LCalfRot2;
            BoneUpDown2.ValueChanged -= LCalfRot2;
            BoneUpDown3.ValueChanged -= LCalfRot2;
        }

        private void LCalfButton_Checked(object sender, RoutedEventArgs e)
        {
            //Disable Other Selections
            HeadButton.IsChecked = false;
            NoseButton.IsChecked = false;
            NostrilsButton.IsChecked = false;
            ChinButton.IsChecked = false;
            LOutEyebrowButton.IsChecked = false;
            ROutEyebrowButton.IsChecked = false;
            LInEyebrowButton.IsChecked = false;
            RInEyebrowButton.IsChecked = false;
            LEyeButton.IsChecked = false;
            REyeButton.IsChecked = false;
            LEyelidButton.IsChecked = false;
            REyelidButton.IsChecked = false;
            LLowEyelidButton.IsChecked = false;
            RLowEyelidButton.IsChecked = false;
            LEarButton.IsChecked = false;
            REarButton.IsChecked = false;
            LCheekButton.IsChecked = false;
            RCheekButton.IsChecked = false;
            LMouthButton.IsChecked = false;
            RMouthButton.IsChecked = false;
            LUpLipButton.IsChecked = false;
            RUpLipButton.IsChecked = false;
            LLowLipButton.IsChecked = false;
            RLowLipButton.IsChecked = false;
            NeckButton.IsChecked = false;
            SternumButton.IsChecked = false;
            TorsoButton.IsChecked = false;
            WaistButton.IsChecked = false;
            LShoulderButton.IsChecked = false;
            RShoulderButton.IsChecked = false;
            LClavicleButton.IsChecked = false;
            RClavicleButton.IsChecked = false;
            LBreastButton.IsChecked = false;
            RBreastButton.IsChecked = false;
            LArmButton.IsChecked = false;
            RArmButton.IsChecked = false;
            LElbowButton.IsChecked = false;
            RElbowButton.IsChecked = false;
            LForearmButton.IsChecked = false;
            RForearmButton.IsChecked = false;
            LWristButton.IsChecked = false;
            RWristButton.IsChecked = false;
            LHandButton.IsChecked = false;
            RHandButton.IsChecked = false;
            LThumbButton.IsChecked = false;
            RThumbButton.IsChecked = false;
            LThumb2Button.IsChecked = false;
            RThumb2Button.IsChecked = false;
            LIndexButton.IsChecked = false;
            RIndexButton.IsChecked = false;
            LIndex2Button.IsChecked = false;
            RIndex2Button.IsChecked = false;
            LMiddleButton.IsChecked = false;
            RMiddleButton.IsChecked = false;
            LMiddle2Button.IsChecked = false;
            RMiddle2Button.IsChecked = false;
            LRingButton.IsChecked = false;
            RRingButton.IsChecked = false;
            LRing2Button.IsChecked = false;
            RRing2Button.IsChecked = false;
            LPinkyButton.IsChecked = false;
            RPinkyButton.IsChecked = false;
            LPinky2Button.IsChecked = false;
            RPinky2Button.IsChecked = false;
            PelvisButton.IsChecked = false;
            TailButton.IsChecked = false;
            Tail2Button.IsChecked = false;
            Tail3Button.IsChecked = false;
            Tail4Button.IsChecked = false;
            LThighButton.IsChecked = false;
            RThighButton.IsChecked = false;
            LKneeButton.IsChecked = false;
            RKneeButton.IsChecked = false;
            RCalfButton.IsChecked = false;
            LFootButton.IsChecked = false;
            RFootButton.IsChecked = false;
            LToesButton.IsChecked = false;
            RToesButton.IsChecked = false;
            LEarringButton.IsChecked = false;
            REarringButton.IsChecked = false;
            LEarring2Button.IsChecked = false;
            REarring2Button.IsChecked = false;

            //Load Current Values for Slider
            CharacterDetails.LCalfCheck = true;
        }
        private void LCalfButton_Unchecked(object sender, RoutedEventArgs e)
        {
            CharacterDetails.LCalfRotate = false;
        }
        #endregion

        #region RCalf
        private void RCalfRot(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.RCalfX.value = (float)quat.X;
            CharacterDetails.RCalfY.value = (float)quat.Y;
            CharacterDetails.RCalfZ.value = (float)quat.Z;
            CharacterDetails.RCalfW.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneSlider.ValueChanged -= RCalfRot;
            BoneSlider2.ValueChanged -= RCalfRot;
            BoneSlider3.ValueChanged -= RCalfRot;
        }

        private void RCalfRot2(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.RCalfX.value = (float)quat.X;
            CharacterDetails.RCalfY.value = (float)quat.Y;
            CharacterDetails.RCalfZ.value = (float)quat.Z;
            CharacterDetails.RCalfW.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneUpDown.ValueChanged -= RCalfRot2;
            BoneUpDown2.ValueChanged -= RCalfRot2;
            BoneUpDown3.ValueChanged -= RCalfRot2;
        }

        private void RCalfButton_Checked(object sender, RoutedEventArgs e)
        {
            //Disable Other Selections
            HeadButton.IsChecked = false;
            NoseButton.IsChecked = false;
            NostrilsButton.IsChecked = false;
            ChinButton.IsChecked = false;
            LOutEyebrowButton.IsChecked = false;
            ROutEyebrowButton.IsChecked = false;
            LInEyebrowButton.IsChecked = false;
            RInEyebrowButton.IsChecked = false;
            LEyeButton.IsChecked = false;
            REyeButton.IsChecked = false;
            LEyelidButton.IsChecked = false;
            REyelidButton.IsChecked = false;
            LLowEyelidButton.IsChecked = false;
            RLowEyelidButton.IsChecked = false;
            LEarButton.IsChecked = false;
            REarButton.IsChecked = false;
            LCheekButton.IsChecked = false;
            RCheekButton.IsChecked = false;
            LMouthButton.IsChecked = false;
            RMouthButton.IsChecked = false;
            LUpLipButton.IsChecked = false;
            RUpLipButton.IsChecked = false;
            LLowLipButton.IsChecked = false;
            RLowLipButton.IsChecked = false;
            NeckButton.IsChecked = false;
            SternumButton.IsChecked = false;
            TorsoButton.IsChecked = false;
            WaistButton.IsChecked = false;
            LShoulderButton.IsChecked = false;
            RShoulderButton.IsChecked = false;
            LClavicleButton.IsChecked = false;
            RClavicleButton.IsChecked = false;
            LBreastButton.IsChecked = false;
            RBreastButton.IsChecked = false;
            LArmButton.IsChecked = false;
            RArmButton.IsChecked = false;
            LElbowButton.IsChecked = false;
            RElbowButton.IsChecked = false;
            LForearmButton.IsChecked = false;
            RForearmButton.IsChecked = false;
            LWristButton.IsChecked = false;
            RWristButton.IsChecked = false;
            LHandButton.IsChecked = false;
            RHandButton.IsChecked = false;
            LThumbButton.IsChecked = false;
            RThumbButton.IsChecked = false;
            LThumb2Button.IsChecked = false;
            RThumb2Button.IsChecked = false;
            LIndexButton.IsChecked = false;
            RIndexButton.IsChecked = false;
            LIndex2Button.IsChecked = false;
            RIndex2Button.IsChecked = false;
            LMiddleButton.IsChecked = false;
            RMiddleButton.IsChecked = false;
            LMiddle2Button.IsChecked = false;
            RMiddle2Button.IsChecked = false;
            LRingButton.IsChecked = false;
            RRingButton.IsChecked = false;
            LRing2Button.IsChecked = false;
            RRing2Button.IsChecked = false;
            LPinkyButton.IsChecked = false;
            RPinkyButton.IsChecked = false;
            LPinky2Button.IsChecked = false;
            RPinky2Button.IsChecked = false;
            PelvisButton.IsChecked = false;
            TailButton.IsChecked = false;
            Tail2Button.IsChecked = false;
            Tail3Button.IsChecked = false;
            Tail4Button.IsChecked = false;
            LThighButton.IsChecked = false;
            RThighButton.IsChecked = false;
            LKneeButton.IsChecked = false;
            RKneeButton.IsChecked = false;
            LCalfButton.IsChecked = false;
            LFootButton.IsChecked = false;
            RFootButton.IsChecked = false;
            LToesButton.IsChecked = false;
            RToesButton.IsChecked = false;
            LEarringButton.IsChecked = false;
            REarringButton.IsChecked = false;
            LEarring2Button.IsChecked = false;
            REarring2Button.IsChecked = false;

            //Load Current Values for Slider
            CharacterDetails.RCalfCheck = true;
        }
        private void RCalfButton_Unchecked(object sender, RoutedEventArgs e)
        {
            CharacterDetails.RCalfRotate = false;
        }
        #endregion

        #region LFoot
        private void LFootRot(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.LFootX.value = (float)quat.X;
            CharacterDetails.LFootY.value = (float)quat.Y;
            CharacterDetails.LFootZ.value = (float)quat.Z;
            CharacterDetails.LFootW.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneSlider.ValueChanged -= LFootRot;
            BoneSlider2.ValueChanged -= LFootRot;
            BoneSlider3.ValueChanged -= LFootRot;
        }

        private void LFootRot2(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.LFootX.value = (float)quat.X;
            CharacterDetails.LFootY.value = (float)quat.Y;
            CharacterDetails.LFootZ.value = (float)quat.Z;
            CharacterDetails.LFootW.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneUpDown.ValueChanged -= LFootRot2;
            BoneUpDown2.ValueChanged -= LFootRot2;
            BoneUpDown3.ValueChanged -= LFootRot2;
        }

        private void LFootButton_Checked(object sender, RoutedEventArgs e)
        {
            //Disable Other Selections
            HeadButton.IsChecked = false;
            NoseButton.IsChecked = false;
            NostrilsButton.IsChecked = false;
            ChinButton.IsChecked = false;
            LOutEyebrowButton.IsChecked = false;
            ROutEyebrowButton.IsChecked = false;
            LInEyebrowButton.IsChecked = false;
            RInEyebrowButton.IsChecked = false;
            LEyeButton.IsChecked = false;
            REyeButton.IsChecked = false;
            LEyelidButton.IsChecked = false;
            REyelidButton.IsChecked = false;
            LLowEyelidButton.IsChecked = false;
            RLowEyelidButton.IsChecked = false;
            LEarButton.IsChecked = false;
            REarButton.IsChecked = false;
            LCheekButton.IsChecked = false;
            RCheekButton.IsChecked = false;
            LMouthButton.IsChecked = false;
            RMouthButton.IsChecked = false;
            LUpLipButton.IsChecked = false;
            RUpLipButton.IsChecked = false;
            LLowLipButton.IsChecked = false;
            RLowLipButton.IsChecked = false;
            NeckButton.IsChecked = false;
            SternumButton.IsChecked = false;
            TorsoButton.IsChecked = false;
            WaistButton.IsChecked = false;
            LShoulderButton.IsChecked = false;
            RShoulderButton.IsChecked = false;
            LClavicleButton.IsChecked = false;
            RClavicleButton.IsChecked = false;
            LBreastButton.IsChecked = false;
            RBreastButton.IsChecked = false;
            LArmButton.IsChecked = false;
            RArmButton.IsChecked = false;
            LElbowButton.IsChecked = false;
            RElbowButton.IsChecked = false;
            LForearmButton.IsChecked = false;
            RForearmButton.IsChecked = false;
            LWristButton.IsChecked = false;
            RWristButton.IsChecked = false;
            LHandButton.IsChecked = false;
            RHandButton.IsChecked = false;
            LThumbButton.IsChecked = false;
            RThumbButton.IsChecked = false;
            LThumb2Button.IsChecked = false;
            RThumb2Button.IsChecked = false;
            LIndexButton.IsChecked = false;
            RIndexButton.IsChecked = false;
            LIndex2Button.IsChecked = false;
            RIndex2Button.IsChecked = false;
            LMiddleButton.IsChecked = false;
            RMiddleButton.IsChecked = false;
            LMiddle2Button.IsChecked = false;
            RMiddle2Button.IsChecked = false;
            LRingButton.IsChecked = false;
            RRingButton.IsChecked = false;
            LRing2Button.IsChecked = false;
            RRing2Button.IsChecked = false;
            LPinkyButton.IsChecked = false;
            RPinkyButton.IsChecked = false;
            LPinky2Button.IsChecked = false;
            RPinky2Button.IsChecked = false;
            PelvisButton.IsChecked = false;
            TailButton.IsChecked = false;
            Tail2Button.IsChecked = false;
            Tail3Button.IsChecked = false;
            Tail4Button.IsChecked = false;
            LThighButton.IsChecked = false;
            RThighButton.IsChecked = false;
            LKneeButton.IsChecked = false;
            RKneeButton.IsChecked = false;
            LCalfButton.IsChecked = false;
            RCalfButton.IsChecked = false;
            RFootButton.IsChecked = false;
            LToesButton.IsChecked = false;
            RToesButton.IsChecked = false;
            LEarringButton.IsChecked = false;
            REarringButton.IsChecked = false;
            LEarring2Button.IsChecked = false;
            REarring2Button.IsChecked = false;

            //Load Current Values for Slider
            CharacterDetails.LFootCheck = true;
        }
        private void LFootButton_Unchecked(object sender, RoutedEventArgs e)
        {
            CharacterDetails.LFootRotate = false;
        }
        #endregion

        #region RFoot
        private void RFootRot(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.RFootX.value = (float)quat.X;
            CharacterDetails.RFootY.value = (float)quat.Y;
            CharacterDetails.RFootZ.value = (float)quat.Z;
            CharacterDetails.RFootW.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneSlider.ValueChanged -= RFootRot;
            BoneSlider2.ValueChanged -= RFootRot;
            BoneSlider3.ValueChanged -= RFootRot;
        }

        private void RFootRot2(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.RFootX.value = (float)quat.X;
            CharacterDetails.RFootY.value = (float)quat.Y;
            CharacterDetails.RFootZ.value = (float)quat.Z;
            CharacterDetails.RFootW.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneUpDown.ValueChanged -= RFootRot2;
            BoneUpDown2.ValueChanged -= RFootRot2;
            BoneUpDown3.ValueChanged -= RFootRot2;
        }

        private void RFootButton_Checked(object sender, RoutedEventArgs e)
        {
            //Disable Other Selections
            HeadButton.IsChecked = false;
            NoseButton.IsChecked = false;
            NostrilsButton.IsChecked = false;
            ChinButton.IsChecked = false;
            LOutEyebrowButton.IsChecked = false;
            ROutEyebrowButton.IsChecked = false;
            LInEyebrowButton.IsChecked = false;
            RInEyebrowButton.IsChecked = false;
            LEyeButton.IsChecked = false;
            REyeButton.IsChecked = false;
            LEyelidButton.IsChecked = false;
            REyelidButton.IsChecked = false;
            LLowEyelidButton.IsChecked = false;
            RLowEyelidButton.IsChecked = false;
            LEarButton.IsChecked = false;
            REarButton.IsChecked = false;
            LCheekButton.IsChecked = false;
            RCheekButton.IsChecked = false;
            LMouthButton.IsChecked = false;
            RMouthButton.IsChecked = false;
            LUpLipButton.IsChecked = false;
            RUpLipButton.IsChecked = false;
            LLowLipButton.IsChecked = false;
            RLowLipButton.IsChecked = false;
            NeckButton.IsChecked = false;
            SternumButton.IsChecked = false;
            TorsoButton.IsChecked = false;
            WaistButton.IsChecked = false;
            LShoulderButton.IsChecked = false;
            RShoulderButton.IsChecked = false;
            LClavicleButton.IsChecked = false;
            RClavicleButton.IsChecked = false;
            LBreastButton.IsChecked = false;
            RBreastButton.IsChecked = false;
            LArmButton.IsChecked = false;
            RArmButton.IsChecked = false;
            LElbowButton.IsChecked = false;
            RElbowButton.IsChecked = false;
            LForearmButton.IsChecked = false;
            RForearmButton.IsChecked = false;
            LWristButton.IsChecked = false;
            RWristButton.IsChecked = false;
            LHandButton.IsChecked = false;
            RHandButton.IsChecked = false;
            LThumbButton.IsChecked = false;
            RThumbButton.IsChecked = false;
            LThumb2Button.IsChecked = false;
            RThumb2Button.IsChecked = false;
            LIndexButton.IsChecked = false;
            RIndexButton.IsChecked = false;
            LIndex2Button.IsChecked = false;
            RIndex2Button.IsChecked = false;
            LMiddleButton.IsChecked = false;
            RMiddleButton.IsChecked = false;
            LMiddle2Button.IsChecked = false;
            RMiddle2Button.IsChecked = false;
            LRingButton.IsChecked = false;
            RRingButton.IsChecked = false;
            LRing2Button.IsChecked = false;
            RRing2Button.IsChecked = false;
            LPinkyButton.IsChecked = false;
            RPinkyButton.IsChecked = false;
            LPinky2Button.IsChecked = false;
            RPinky2Button.IsChecked = false;
            PelvisButton.IsChecked = false;
            TailButton.IsChecked = false;
            Tail2Button.IsChecked = false;
            Tail3Button.IsChecked = false;
            Tail4Button.IsChecked = false;
            LThighButton.IsChecked = false;
            RThighButton.IsChecked = false;
            LKneeButton.IsChecked = false;
            RKneeButton.IsChecked = false;
            LCalfButton.IsChecked = false;
            RCalfButton.IsChecked = false;
            LFootButton.IsChecked = false;
            LToesButton.IsChecked = false;
            RToesButton.IsChecked = false;
            LEarringButton.IsChecked = false;
            REarringButton.IsChecked = false;
            LEarring2Button.IsChecked = false;
            REarring2Button.IsChecked = false;

            //Load Current Values for Slider
            CharacterDetails.RFootCheck = true;
        }
        private void RFootButton_Unchecked(object sender, RoutedEventArgs e)
        {
            CharacterDetails.RFootRotate = false;
        }
        #endregion

        #region LToes
        private void LToesRot(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.LToesX.value = (float)quat.X;
            CharacterDetails.LToesY.value = (float)quat.Y;
            CharacterDetails.LToesZ.value = (float)quat.Z;
            CharacterDetails.LToesW.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneSlider.ValueChanged -= LToesRot;
            BoneSlider2.ValueChanged -= LToesRot;
            BoneSlider3.ValueChanged -= LToesRot;
        }

        private void LToesRot2(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.LToesX.value = (float)quat.X;
            CharacterDetails.LToesY.value = (float)quat.Y;
            CharacterDetails.LToesZ.value = (float)quat.Z;
            CharacterDetails.LToesW.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneUpDown.ValueChanged -= LToesRot2;
            BoneUpDown2.ValueChanged -= LToesRot2;
            BoneUpDown3.ValueChanged -= LToesRot2;
        }

        private void LToesButton_Checked(object sender, RoutedEventArgs e)
        {
            //Disable Other Selections
            HeadButton.IsChecked = false;
            NoseButton.IsChecked = false;
            NostrilsButton.IsChecked = false;
            ChinButton.IsChecked = false;
            LOutEyebrowButton.IsChecked = false;
            ROutEyebrowButton.IsChecked = false;
            LInEyebrowButton.IsChecked = false;
            RInEyebrowButton.IsChecked = false;
            LEyeButton.IsChecked = false;
            REyeButton.IsChecked = false;
            LEyelidButton.IsChecked = false;
            REyelidButton.IsChecked = false;
            LLowEyelidButton.IsChecked = false;
            RLowEyelidButton.IsChecked = false;
            LEarButton.IsChecked = false;
            REarButton.IsChecked = false;
            LCheekButton.IsChecked = false;
            RCheekButton.IsChecked = false;
            LMouthButton.IsChecked = false;
            RMouthButton.IsChecked = false;
            LUpLipButton.IsChecked = false;
            RUpLipButton.IsChecked = false;
            LLowLipButton.IsChecked = false;
            RLowLipButton.IsChecked = false;
            NeckButton.IsChecked = false;
            SternumButton.IsChecked = false;
            TorsoButton.IsChecked = false;
            WaistButton.IsChecked = false;
            LShoulderButton.IsChecked = false;
            RShoulderButton.IsChecked = false;
            LClavicleButton.IsChecked = false;
            RClavicleButton.IsChecked = false;
            LBreastButton.IsChecked = false;
            RBreastButton.IsChecked = false;
            LArmButton.IsChecked = false;
            RArmButton.IsChecked = false;
            LElbowButton.IsChecked = false;
            RElbowButton.IsChecked = false;
            LForearmButton.IsChecked = false;
            RForearmButton.IsChecked = false;
            LWristButton.IsChecked = false;
            RWristButton.IsChecked = false;
            LHandButton.IsChecked = false;
            RHandButton.IsChecked = false;
            LThumbButton.IsChecked = false;
            RThumbButton.IsChecked = false;
            LThumb2Button.IsChecked = false;
            RThumb2Button.IsChecked = false;
            LIndexButton.IsChecked = false;
            RIndexButton.IsChecked = false;
            LIndex2Button.IsChecked = false;
            RIndex2Button.IsChecked = false;
            LMiddleButton.IsChecked = false;
            RMiddleButton.IsChecked = false;
            LMiddle2Button.IsChecked = false;
            RMiddle2Button.IsChecked = false;
            LRingButton.IsChecked = false;
            RRingButton.IsChecked = false;
            LRing2Button.IsChecked = false;
            RRing2Button.IsChecked = false;
            LPinkyButton.IsChecked = false;
            RPinkyButton.IsChecked = false;
            LPinky2Button.IsChecked = false;
            RPinky2Button.IsChecked = false;
            PelvisButton.IsChecked = false;
            TailButton.IsChecked = false;
            Tail2Button.IsChecked = false;
            Tail3Button.IsChecked = false;
            Tail4Button.IsChecked = false;
            LThighButton.IsChecked = false;
            RThighButton.IsChecked = false;
            LKneeButton.IsChecked = false;
            RKneeButton.IsChecked = false;
            LCalfButton.IsChecked = false;
            RCalfButton.IsChecked = false;
            LFootButton.IsChecked = false;
            RFootButton.IsChecked = false;
            RToesButton.IsChecked = false;
            LEarringButton.IsChecked = false;
            REarringButton.IsChecked = false;
            LEarring2Button.IsChecked = false;
            REarring2Button.IsChecked = false;

            //Load Current Values for Slider
            CharacterDetails.LToesCheck = true;
        }
        private void LToesButton_Unchecked(object sender, RoutedEventArgs e)
        {
            CharacterDetails.LToesRotate = false;
        }
        #endregion

        #region RToes
        private void RToesRot(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.RToesX.value = (float)quat.X;
            CharacterDetails.RToesY.value = (float)quat.Y;
            CharacterDetails.RToesZ.value = (float)quat.Z;
            CharacterDetails.RToesW.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneSlider.ValueChanged -= RToesRot;
            BoneSlider2.ValueChanged -= RToesRot;
            BoneSlider3.ValueChanged -= RToesRot;
        }

        private void RToesRot2(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.RToesX.value = (float)quat.X;
            CharacterDetails.RToesY.value = (float)quat.Y;
            CharacterDetails.RToesZ.value = (float)quat.Z;
            CharacterDetails.RToesW.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneUpDown.ValueChanged -= RToesRot2;
            BoneUpDown2.ValueChanged -= RToesRot2;
            BoneUpDown3.ValueChanged -= RToesRot2;
        }

        private void RToesButton_Checked(object sender, RoutedEventArgs e)
        {
            //Disable Other Selections
            HeadButton.IsChecked = false;
            NoseButton.IsChecked = false;
            NostrilsButton.IsChecked = false;
            ChinButton.IsChecked = false;
            LOutEyebrowButton.IsChecked = false;
            ROutEyebrowButton.IsChecked = false;
            LInEyebrowButton.IsChecked = false;
            RInEyebrowButton.IsChecked = false;
            LEyeButton.IsChecked = false;
            REyeButton.IsChecked = false;
            LEyelidButton.IsChecked = false;
            REyelidButton.IsChecked = false;
            LLowEyelidButton.IsChecked = false;
            RLowEyelidButton.IsChecked = false;
            LEarButton.IsChecked = false;
            REarButton.IsChecked = false;
            LCheekButton.IsChecked = false;
            RCheekButton.IsChecked = false;
            LMouthButton.IsChecked = false;
            RMouthButton.IsChecked = false;
            LUpLipButton.IsChecked = false;
            RUpLipButton.IsChecked = false;
            LLowLipButton.IsChecked = false;
            RLowLipButton.IsChecked = false;
            NeckButton.IsChecked = false;
            SternumButton.IsChecked = false;
            TorsoButton.IsChecked = false;
            WaistButton.IsChecked = false;
            LShoulderButton.IsChecked = false;
            RShoulderButton.IsChecked = false;
            LClavicleButton.IsChecked = false;
            RClavicleButton.IsChecked = false;
            LBreastButton.IsChecked = false;
            RBreastButton.IsChecked = false;
            LArmButton.IsChecked = false;
            RArmButton.IsChecked = false;
            LElbowButton.IsChecked = false;
            RElbowButton.IsChecked = false;
            LForearmButton.IsChecked = false;
            RForearmButton.IsChecked = false;
            LWristButton.IsChecked = false;
            RWristButton.IsChecked = false;
            LHandButton.IsChecked = false;
            RHandButton.IsChecked = false;
            LThumbButton.IsChecked = false;
            RThumbButton.IsChecked = false;
            LThumb2Button.IsChecked = false;
            RThumb2Button.IsChecked = false;
            LIndexButton.IsChecked = false;
            RIndexButton.IsChecked = false;
            LIndex2Button.IsChecked = false;
            RIndex2Button.IsChecked = false;
            LMiddleButton.IsChecked = false;
            RMiddleButton.IsChecked = false;
            LMiddle2Button.IsChecked = false;
            RMiddle2Button.IsChecked = false;
            LRingButton.IsChecked = false;
            RRingButton.IsChecked = false;
            LRing2Button.IsChecked = false;
            RRing2Button.IsChecked = false;
            LPinkyButton.IsChecked = false;
            RPinkyButton.IsChecked = false;
            LPinky2Button.IsChecked = false;
            RPinky2Button.IsChecked = false;
            PelvisButton.IsChecked = false;
            TailButton.IsChecked = false;
            Tail2Button.IsChecked = false;
            Tail3Button.IsChecked = false;
            Tail4Button.IsChecked = false;
            LThighButton.IsChecked = false;
            RThighButton.IsChecked = false;
            LKneeButton.IsChecked = false;
            RKneeButton.IsChecked = false;
            LCalfButton.IsChecked = false;
            RCalfButton.IsChecked = false;
            LFootButton.IsChecked = false;
            RFootButton.IsChecked = false;
            LToesButton.IsChecked = false;
            LEarringButton.IsChecked = false;
            REarringButton.IsChecked = false;
            LEarring2Button.IsChecked = false;
            REarring2Button.IsChecked = false;

            //Load Current Values for Slider
            CharacterDetails.RToesCheck = true;
        }
        private void RToesButton_Unchecked(object sender, RoutedEventArgs e)
        {
            CharacterDetails.RToesRotate = false;
        }
        #endregion

        #region LEarring
        private void LEarringRot(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.LEarringX.value = (float)quat.X;
            CharacterDetails.LEarringY.value = (float)quat.Y;
            CharacterDetails.LEarringZ.value = (float)quat.Z;
            CharacterDetails.LEarringW.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneSlider.ValueChanged -= LEarringRot;
            BoneSlider2.ValueChanged -= LEarringRot;
            BoneSlider3.ValueChanged -= LEarringRot;
        }

        private void LEarringRot2(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.LEarringX.value = (float)quat.X;
            CharacterDetails.LEarringY.value = (float)quat.Y;
            CharacterDetails.LEarringZ.value = (float)quat.Z;
            CharacterDetails.LEarringW.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneUpDown.ValueChanged -= LEarringRot2;
            BoneUpDown2.ValueChanged -= LEarringRot2;
            BoneUpDown3.ValueChanged -= LEarringRot2;
        }

        private void LEarringButton_Checked(object sender, RoutedEventArgs e)
        {
            //Disable Other Selections
            HeadButton.IsChecked = false;
            NoseButton.IsChecked = false;
            NostrilsButton.IsChecked = false;
            ChinButton.IsChecked = false;
            LOutEyebrowButton.IsChecked = false;
            ROutEyebrowButton.IsChecked = false;
            LInEyebrowButton.IsChecked = false;
            RInEyebrowButton.IsChecked = false;
            LEyeButton.IsChecked = false;
            REyeButton.IsChecked = false;
            LEyelidButton.IsChecked = false;
            REyelidButton.IsChecked = false;
            LLowEyelidButton.IsChecked = false;
            RLowEyelidButton.IsChecked = false;
            LEarButton.IsChecked = false;
            REarButton.IsChecked = false;
            LCheekButton.IsChecked = false;
            RCheekButton.IsChecked = false;
            LMouthButton.IsChecked = false;
            RMouthButton.IsChecked = false;
            LUpLipButton.IsChecked = false;
            RUpLipButton.IsChecked = false;
            LLowLipButton.IsChecked = false;
            RLowLipButton.IsChecked = false;
            NeckButton.IsChecked = false;
            SternumButton.IsChecked = false;
            TorsoButton.IsChecked = false;
            WaistButton.IsChecked = false;
            LShoulderButton.IsChecked = false;
            RShoulderButton.IsChecked = false;
            LClavicleButton.IsChecked = false;
            RClavicleButton.IsChecked = false;
            LBreastButton.IsChecked = false;
            RBreastButton.IsChecked = false;
            LArmButton.IsChecked = false;
            RArmButton.IsChecked = false;
            LElbowButton.IsChecked = false;
            RElbowButton.IsChecked = false;
            LForearmButton.IsChecked = false;
            RForearmButton.IsChecked = false;
            LWristButton.IsChecked = false;
            RWristButton.IsChecked = false;
            LHandButton.IsChecked = false;
            RHandButton.IsChecked = false;
            LThumbButton.IsChecked = false;
            RThumbButton.IsChecked = false;
            LThumb2Button.IsChecked = false;
            RThumb2Button.IsChecked = false;
            LIndexButton.IsChecked = false;
            RIndexButton.IsChecked = false;
            LIndex2Button.IsChecked = false;
            RIndex2Button.IsChecked = false;
            LMiddleButton.IsChecked = false;
            RMiddleButton.IsChecked = false;
            LMiddle2Button.IsChecked = false;
            RMiddle2Button.IsChecked = false;
            LRingButton.IsChecked = false;
            RRingButton.IsChecked = false;
            LRing2Button.IsChecked = false;
            RRing2Button.IsChecked = false;
            LPinkyButton.IsChecked = false;
            RPinkyButton.IsChecked = false;
            LPinky2Button.IsChecked = false;
            RPinky2Button.IsChecked = false;
            PelvisButton.IsChecked = false;
            TailButton.IsChecked = false;
            Tail2Button.IsChecked = false;
            Tail3Button.IsChecked = false;
            Tail4Button.IsChecked = false;
            LThighButton.IsChecked = false;
            RThighButton.IsChecked = false;
            LKneeButton.IsChecked = false;
            RKneeButton.IsChecked = false;
            LCalfButton.IsChecked = false;
            RCalfButton.IsChecked = false;
            LFootButton.IsChecked = false;
            RFootButton.IsChecked = false;
            LToesButton.IsChecked = false;
            RToesButton.IsChecked = false;
            REarringButton.IsChecked = false;
            LEarring2Button.IsChecked = false;
            REarring2Button.IsChecked = false;

            //Load Current Values for Slider
            CharacterDetails.LEarringCheck = true;
        }
        private void LEarringButton_Unchecked(object sender, RoutedEventArgs e)
        {
            CharacterDetails.LEarringRotate = false;
        }
        #endregion

        #region REarring
        private void REarringRot(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.REarringX.value = (float)quat.X;
            CharacterDetails.REarringY.value = (float)quat.Y;
            CharacterDetails.REarringZ.value = (float)quat.Z;
            CharacterDetails.REarringW.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneSlider.ValueChanged -= REarringRot;
            BoneSlider2.ValueChanged -= REarringRot;
            BoneSlider3.ValueChanged -= REarringRot;
        }

        private void REarringRot2(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.REarringX.value = (float)quat.X;
            CharacterDetails.REarringY.value = (float)quat.Y;
            CharacterDetails.REarringZ.value = (float)quat.Z;
            CharacterDetails.REarringW.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneUpDown.ValueChanged -= REarringRot2;
            BoneUpDown2.ValueChanged -= REarringRot2;
            BoneUpDown3.ValueChanged -= REarringRot2;
        }

        private void REarringButton_Checked(object sender, RoutedEventArgs e)
        {
            //Disable Other Selections
            HeadButton.IsChecked = false;
            NoseButton.IsChecked = false;
            NostrilsButton.IsChecked = false;
            ChinButton.IsChecked = false;
            LOutEyebrowButton.IsChecked = false;
            ROutEyebrowButton.IsChecked = false;
            LInEyebrowButton.IsChecked = false;
            RInEyebrowButton.IsChecked = false;
            LEyeButton.IsChecked = false;
            REyeButton.IsChecked = false;
            LEyelidButton.IsChecked = false;
            REyelidButton.IsChecked = false;
            LLowEyelidButton.IsChecked = false;
            RLowEyelidButton.IsChecked = false;
            LEarButton.IsChecked = false;
            REarButton.IsChecked = false;
            LCheekButton.IsChecked = false;
            RCheekButton.IsChecked = false;
            LMouthButton.IsChecked = false;
            RMouthButton.IsChecked = false;
            LUpLipButton.IsChecked = false;
            RUpLipButton.IsChecked = false;
            LLowLipButton.IsChecked = false;
            RLowLipButton.IsChecked = false;
            NeckButton.IsChecked = false;
            SternumButton.IsChecked = false;
            TorsoButton.IsChecked = false;
            WaistButton.IsChecked = false;
            LShoulderButton.IsChecked = false;
            RShoulderButton.IsChecked = false;
            LClavicleButton.IsChecked = false;
            RClavicleButton.IsChecked = false;
            LBreastButton.IsChecked = false;
            RBreastButton.IsChecked = false;
            LArmButton.IsChecked = false;
            RArmButton.IsChecked = false;
            LElbowButton.IsChecked = false;
            RElbowButton.IsChecked = false;
            LForearmButton.IsChecked = false;
            RForearmButton.IsChecked = false;
            LWristButton.IsChecked = false;
            RWristButton.IsChecked = false;
            LHandButton.IsChecked = false;
            RHandButton.IsChecked = false;
            LThumbButton.IsChecked = false;
            RThumbButton.IsChecked = false;
            LThumb2Button.IsChecked = false;
            RThumb2Button.IsChecked = false;
            LIndexButton.IsChecked = false;
            RIndexButton.IsChecked = false;
            LIndex2Button.IsChecked = false;
            RIndex2Button.IsChecked = false;
            LMiddleButton.IsChecked = false;
            RMiddleButton.IsChecked = false;
            LMiddle2Button.IsChecked = false;
            RMiddle2Button.IsChecked = false;
            LRingButton.IsChecked = false;
            RRingButton.IsChecked = false;
            LRing2Button.IsChecked = false;
            RRing2Button.IsChecked = false;
            LPinkyButton.IsChecked = false;
            RPinkyButton.IsChecked = false;
            LPinky2Button.IsChecked = false;
            RPinky2Button.IsChecked = false;
            PelvisButton.IsChecked = false;
            TailButton.IsChecked = false;
            Tail2Button.IsChecked = false;
            Tail3Button.IsChecked = false;
            Tail4Button.IsChecked = false;
            LThighButton.IsChecked = false;
            RThighButton.IsChecked = false;
            LKneeButton.IsChecked = false;
            RKneeButton.IsChecked = false;
            LCalfButton.IsChecked = false;
            RCalfButton.IsChecked = false;
            LFootButton.IsChecked = false;
            RFootButton.IsChecked = false;
            LToesButton.IsChecked = false;
            RToesButton.IsChecked = false;
            LEarringButton.IsChecked = false;
            LEarring2Button.IsChecked = false;
            REarring2Button.IsChecked = false;

            //Load Current Values for Slider
            CharacterDetails.REarringCheck = true;
        }
        private void REarringButton_Unchecked(object sender, RoutedEventArgs e)
        {
            CharacterDetails.REarringRotate = false;
        }
        #endregion

        #region LEarring2
        private void LEarring2Rot(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.LEarring2X.value = (float)quat.X;
            CharacterDetails.LEarring2Y.value = (float)quat.Y;
            CharacterDetails.LEarring2Z.value = (float)quat.Z;
            CharacterDetails.LEarring2W.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneSlider.ValueChanged -= LEarring2Rot;
            BoneSlider2.ValueChanged -= LEarring2Rot;
            BoneSlider3.ValueChanged -= LEarring2Rot;
        }

        private void LEarring2Rot2(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.LEarring2X.value = (float)quat.X;
            CharacterDetails.LEarring2Y.value = (float)quat.Y;
            CharacterDetails.LEarring2Z.value = (float)quat.Z;
            CharacterDetails.LEarring2W.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneUpDown.ValueChanged -= LEarring2Rot2;
            BoneUpDown2.ValueChanged -= LEarring2Rot2;
            BoneUpDown3.ValueChanged -= LEarring2Rot2;
        }

        private void LEarring2Button_Checked(object sender, RoutedEventArgs e)
        {
            //Disable Other Selections
            HeadButton.IsChecked = false;
            NoseButton.IsChecked = false;
            NostrilsButton.IsChecked = false;
            ChinButton.IsChecked = false;
            LOutEyebrowButton.IsChecked = false;
            ROutEyebrowButton.IsChecked = false;
            LInEyebrowButton.IsChecked = false;
            RInEyebrowButton.IsChecked = false;
            LEyeButton.IsChecked = false;
            REyeButton.IsChecked = false;
            LEyelidButton.IsChecked = false;
            REyelidButton.IsChecked = false;
            LLowEyelidButton.IsChecked = false;
            RLowEyelidButton.IsChecked = false;
            LEarButton.IsChecked = false;
            REarButton.IsChecked = false;
            LCheekButton.IsChecked = false;
            RCheekButton.IsChecked = false;
            LMouthButton.IsChecked = false;
            RMouthButton.IsChecked = false;
            LUpLipButton.IsChecked = false;
            RUpLipButton.IsChecked = false;
            LLowLipButton.IsChecked = false;
            RLowLipButton.IsChecked = false;
            NeckButton.IsChecked = false;
            SternumButton.IsChecked = false;
            TorsoButton.IsChecked = false;
            WaistButton.IsChecked = false;
            LShoulderButton.IsChecked = false;
            RShoulderButton.IsChecked = false;
            LClavicleButton.IsChecked = false;
            RClavicleButton.IsChecked = false;
            LBreastButton.IsChecked = false;
            RBreastButton.IsChecked = false;
            LArmButton.IsChecked = false;
            RArmButton.IsChecked = false;
            LElbowButton.IsChecked = false;
            RElbowButton.IsChecked = false;
            LForearmButton.IsChecked = false;
            RForearmButton.IsChecked = false;
            LWristButton.IsChecked = false;
            RWristButton.IsChecked = false;
            LHandButton.IsChecked = false;
            RHandButton.IsChecked = false;
            LThumbButton.IsChecked = false;
            RThumbButton.IsChecked = false;
            LThumb2Button.IsChecked = false;
            RThumb2Button.IsChecked = false;
            LIndexButton.IsChecked = false;
            RIndexButton.IsChecked = false;
            LIndex2Button.IsChecked = false;
            RIndex2Button.IsChecked = false;
            LMiddleButton.IsChecked = false;
            RMiddleButton.IsChecked = false;
            LMiddle2Button.IsChecked = false;
            RMiddle2Button.IsChecked = false;
            LRingButton.IsChecked = false;
            RRingButton.IsChecked = false;
            LRing2Button.IsChecked = false;
            RRing2Button.IsChecked = false;
            LPinkyButton.IsChecked = false;
            RPinkyButton.IsChecked = false;
            LPinky2Button.IsChecked = false;
            RPinky2Button.IsChecked = false;
            PelvisButton.IsChecked = false;
            TailButton.IsChecked = false;
            Tail2Button.IsChecked = false;
            Tail3Button.IsChecked = false;
            Tail4Button.IsChecked = false;
            LThighButton.IsChecked = false;
            RThighButton.IsChecked = false;
            LKneeButton.IsChecked = false;
            RKneeButton.IsChecked = false;
            LCalfButton.IsChecked = false;
            RCalfButton.IsChecked = false;
            LFootButton.IsChecked = false;
            RFootButton.IsChecked = false;
            LToesButton.IsChecked = false;
            RToesButton.IsChecked = false;
            LEarringButton.IsChecked = false;
            REarringButton.IsChecked = false;
            REarring2Button.IsChecked = false;

            //Load Current Values for Slider
            CharacterDetails.LEarring2Check = true;
        }
        private void LEarring2Button_Unchecked(object sender, RoutedEventArgs e)
        {
            CharacterDetails.LEarring2Rotate = false;
        }
        #endregion

        #region REarring2
        private void REarring2Rot(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.REarring2X.value = (float)quat.X;
            CharacterDetails.REarring2Y.value = (float)quat.Y;
            CharacterDetails.REarring2Z.value = (float)quat.Z;
            CharacterDetails.REarring2W.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneSlider.ValueChanged -= REarring2Rot;
            BoneSlider2.ValueChanged -= REarring2Rot;
            BoneSlider3.ValueChanged -= REarring2Rot;
        }

        private void REarring2Rot2(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            // Get the euler angles from UI.	
            var quat = GetEulerAngles().ToQuaternion();

            CharacterDetails.REarring2X.value = (float)quat.X;
            CharacterDetails.REarring2Y.value = (float)quat.Y;
            CharacterDetails.REarring2Z.value = (float)quat.Z;
            CharacterDetails.REarring2W.value = (float)quat.W;
            // Remove listeners for value changed.	
            BoneUpDown.ValueChanged -= REarring2Rot2;
            BoneUpDown2.ValueChanged -= REarring2Rot2;
            BoneUpDown3.ValueChanged -= REarring2Rot2;
        }

        private void REarring2Button_Checked(object sender, RoutedEventArgs e)
        {
            //Disable Other Selections
            HeadButton.IsChecked = false;
            NoseButton.IsChecked = false;
            NostrilsButton.IsChecked = false;
            ChinButton.IsChecked = false;
            LOutEyebrowButton.IsChecked = false;
            ROutEyebrowButton.IsChecked = false;
            LInEyebrowButton.IsChecked = false;
            RInEyebrowButton.IsChecked = false;
            LEyeButton.IsChecked = false;
            REyeButton.IsChecked = false;
            LEyelidButton.IsChecked = false;
            REyelidButton.IsChecked = false;
            LLowEyelidButton.IsChecked = false;
            RLowEyelidButton.IsChecked = false;
            LEarButton.IsChecked = false;
            REarButton.IsChecked = false;
            LCheekButton.IsChecked = false;
            RCheekButton.IsChecked = false;
            LMouthButton.IsChecked = false;
            RMouthButton.IsChecked = false;
            LUpLipButton.IsChecked = false;
            RUpLipButton.IsChecked = false;
            LLowLipButton.IsChecked = false;
            RLowLipButton.IsChecked = false;
            NeckButton.IsChecked = false;
            SternumButton.IsChecked = false;
            TorsoButton.IsChecked = false;
            WaistButton.IsChecked = false;
            LShoulderButton.IsChecked = false;
            RShoulderButton.IsChecked = false;
            LClavicleButton.IsChecked = false;
            RClavicleButton.IsChecked = false;
            LBreastButton.IsChecked = false;
            RBreastButton.IsChecked = false;
            LArmButton.IsChecked = false;
            RArmButton.IsChecked = false;
            LElbowButton.IsChecked = false;
            RElbowButton.IsChecked = false;
            LForearmButton.IsChecked = false;
            RForearmButton.IsChecked = false;
            LWristButton.IsChecked = false;
            RWristButton.IsChecked = false;
            LHandButton.IsChecked = false;
            RHandButton.IsChecked = false;
            LThumbButton.IsChecked = false;
            RThumbButton.IsChecked = false;
            LThumb2Button.IsChecked = false;
            RThumb2Button.IsChecked = false;
            LIndexButton.IsChecked = false;
            RIndexButton.IsChecked = false;
            LIndex2Button.IsChecked = false;
            RIndex2Button.IsChecked = false;
            LMiddleButton.IsChecked = false;
            RMiddleButton.IsChecked = false;
            LMiddle2Button.IsChecked = false;
            RMiddle2Button.IsChecked = false;
            LRingButton.IsChecked = false;
            RRingButton.IsChecked = false;
            LRing2Button.IsChecked = false;
            RRing2Button.IsChecked = false;
            LPinkyButton.IsChecked = false;
            RPinkyButton.IsChecked = false;
            LPinky2Button.IsChecked = false;
            RPinky2Button.IsChecked = false;
            PelvisButton.IsChecked = false;
            TailButton.IsChecked = false;
            Tail2Button.IsChecked = false;
            Tail3Button.IsChecked = false;
            Tail4Button.IsChecked = false;
            LThighButton.IsChecked = false;
            RThighButton.IsChecked = false;
            LKneeButton.IsChecked = false;
            RKneeButton.IsChecked = false;
            LCalfButton.IsChecked = false;
            RCalfButton.IsChecked = false;
            LFootButton.IsChecked = false;
            RFootButton.IsChecked = false;
            LToesButton.IsChecked = false;
            RToesButton.IsChecked = false;
            LEarringButton.IsChecked = false;
            REarringButton.IsChecked = false;
            LEarring2Button.IsChecked = false;

            //Load Current Values for Slider
            CharacterDetails.REarring2Check = true;
        }
        private void REarring2Button_Unchecked(object sender, RoutedEventArgs e)
        {
            CharacterDetails.REarring2Rotate = false;
        }
        #endregion


        private void EditModeButton_Checked(object sender, RoutedEventArgs e)
        {
            EditMode = true;
            EnableAll();

            var seklval1 = System.BitConverter.GetBytes(MemoryManager.Instance.MemLib.readLong(MemoryManager.Instance.SkeletonAddress));
            var seklval2 = System.BitConverter.GetBytes(MemoryManager.Instance.MemLib.readLong(MemoryManager.Instance.SkeletonAddress2));
            var seklval3 = System.BitConverter.GetBytes(MemoryManager.Instance.MemLib.readLong(MemoryManager.Instance.SkeletonAddress3));
            var physval = System.BitConverter.GetBytes(MemoryManager.Instance.MemLib.readLong(MemoryManager.Instance.PhysicsAddress));
            SkeletonValue = seklval1;
            SkeletonValue2 = seklval2;
            SkeletonValue3 = seklval3;
            PhysicsValue = physval;

            CharacterDetails.BoneEditMode = true;
            MemoryManager.Instance.MemLib.writeMemory(MemoryManager.Instance.SkeletonAddress, "bytes", "0x90 0x90 0x90 0x90 0x90 0x90");
            MemoryManager.Instance.MemLib.writeMemory(MemoryManager.Instance.SkeletonAddress2, "bytes", "0x90 0x90 0x90 0x90 0x90 0x90");
            MemoryManager.Instance.MemLib.writeMemory(MemoryManager.Instance.SkeletonAddress3, "bytes", "0x90 0x90 0x90 0x90");
            MemoryManager.Instance.MemLib.writeMemory(MemoryManager.Instance.PhysicsAddress, "bytes", "0x90 0x90 0x90 0x90");
        }
        private void EditModeButton_Unchecked(object sender, RoutedEventArgs e)
        {
            EditMode = false;
            UncheckAll();
            DisableAll();

            CharacterDetails.BoneEditMode = false;
            MemoryManager.Instance.MemLib.writeBytes(MemoryManager.Instance.SkeletonAddress, SkeletonValue);
            MemoryManager.Instance.MemLib.writeBytes(MemoryManager.Instance.SkeletonAddress2, SkeletonValue2);
            MemoryManager.Instance.MemLib.writeBytes(MemoryManager.Instance.SkeletonAddress3, SkeletonValue3);
            MemoryManager.Instance.MemLib.writeBytes(MemoryManager.Instance.PhysicsAddress, PhysicsValue);

            //Clear Slider Values
            CharacterDetails.BoneX = 0;
            CharacterDetails.BoneY = 0;
            CharacterDetails.BoneZ = 0;
        }

        private void PhysicsButton_Checked(object sender, RoutedEventArgs e)
        {
            MemoryManager.Instance.MemLib.writeBytes(MemoryManager.Instance.PhysicsAddress, PhysicsValue);
        }
        private void PhysicsButton_Unchecked(object sender, RoutedEventArgs e)
        {
            if (EditMode)
            {
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.Instance.PhysicsAddress, "bytes", "0x90 0x90 0x90 0x90");
            }
        }

        private void BoneSliderButton_Checked(object sender, RoutedEventArgs e)
        {
            BoneUpDown.Visibility = Visibility.Hidden;
            BoneUpDown.IsEnabled = false;
            BoneUpDown2.Visibility = Visibility.Hidden;
            BoneUpDown2.IsEnabled = false;
            BoneUpDown3.Visibility = Visibility.Hidden;
            BoneUpDown3.IsEnabled = false;

            BoneSlider.Visibility = Visibility.Visible;
            BoneSlider.IsEnabled = true;
            BoneSlider2.Visibility = Visibility.Visible;
            BoneSlider2.IsEnabled = true;
            BoneSlider3.Visibility = Visibility.Visible;
            BoneSlider3.IsEnabled = true;
        }
        private void BoneSliderButton_Unchecked(object sender, RoutedEventArgs e)
        {
            BoneUpDown.Visibility = Visibility.Visible;
            BoneUpDown.IsEnabled = true;
            BoneUpDown2.Visibility = Visibility.Visible;
            BoneUpDown2.IsEnabled = true;
            BoneUpDown3.Visibility = Visibility.Visible;
            BoneUpDown3.IsEnabled = true;

            BoneSlider.Visibility = Visibility.Hidden;
            BoneSlider.IsEnabled = false;
            BoneSlider2.Visibility = Visibility.Hidden;
            BoneSlider2.IsEnabled = false;
            BoneSlider3.Visibility = Visibility.Hidden;
            BoneSlider3.IsEnabled = false;
        }

        private void TPoseButton_Click(object sender, RoutedEventArgs e)
        {
            EnableRotations();
            TPoseX();
            TPoseY();
            TPoseZ();
            TPoseW();
            DisableRotations();
        }

        private void UncheckAll()
        {
            PhysicsButton.IsChecked = false;
            //DebugButton.IsChecked = false;
            HeadButton.IsChecked = false;
            NoseButton.IsChecked = false;
            NostrilsButton.IsChecked = false;
            ChinButton.IsChecked = false;
            LOutEyebrowButton.IsChecked = false;
            ROutEyebrowButton.IsChecked = false;
            LInEyebrowButton.IsChecked = false;
            RInEyebrowButton.IsChecked = false;
            LEyeButton.IsChecked = false;
            REyeButton.IsChecked = false;
            LEyelidButton.IsChecked = false;
            REyelidButton.IsChecked = false;
            LLowEyelidButton.IsChecked = false;
            RLowEyelidButton.IsChecked = false;
            LEarButton.IsChecked = false;
            REarButton.IsChecked = false;
            LCheekButton.IsChecked = false;
            RCheekButton.IsChecked = false;
            LMouthButton.IsChecked = false;
            RMouthButton.IsChecked = false;
            LUpLipButton.IsChecked = false;
            RUpLipButton.IsChecked = false;
            LLowLipButton.IsChecked = false;
            RLowLipButton.IsChecked = false;
            NeckButton.IsChecked = false;
            SternumButton.IsChecked = false;
            TorsoButton.IsChecked = false;
            WaistButton.IsChecked = false;
            LShoulderButton.IsChecked = false;
            RShoulderButton.IsChecked = false;
            LClavicleButton.IsChecked = false;
            RClavicleButton.IsChecked = false;
            LBreastButton.IsChecked = false;
            RBreastButton.IsChecked = false;
            LArmButton.IsChecked = false;
            RArmButton.IsChecked = false;
            LElbowButton.IsChecked = false;
            RElbowButton.IsChecked = false;
            LForearmButton.IsChecked = false;
            RForearmButton.IsChecked = false;
            LWristButton.IsChecked = false;
            RWristButton.IsChecked = false;
            LHandButton.IsChecked = false;
            RHandButton.IsChecked = false;
            LThumbButton.IsChecked = false;
            RThumbButton.IsChecked = false;
            LThumb2Button.IsChecked = false;
            RThumb2Button.IsChecked = false;
            LIndexButton.IsChecked = false;
            RIndexButton.IsChecked = false;
            LIndex2Button.IsChecked = false;
            RIndex2Button.IsChecked = false;
            LMiddleButton.IsChecked = false;
            RMiddleButton.IsChecked = false;
            LMiddle2Button.IsChecked = false;
            RMiddle2Button.IsChecked = false;
            LRingButton.IsChecked = false;
            RRingButton.IsChecked = false;
            LRing2Button.IsChecked = false;
            RRing2Button.IsChecked = false;
            LPinkyButton.IsChecked = false;
            RPinkyButton.IsChecked = false;
            LPinky2Button.IsChecked = false;
            RPinky2Button.IsChecked = false;
            PelvisButton.IsChecked = false;
            TailButton.IsChecked = false;
            Tail2Button.IsChecked = false;
            Tail3Button.IsChecked = false;
            Tail4Button.IsChecked = false;
            LThighButton.IsChecked = false;
            RThighButton.IsChecked = false;
            LKneeButton.IsChecked = false;
            RKneeButton.IsChecked = false;
            LCalfButton.IsChecked = false;
            RCalfButton.IsChecked = false;
            LFootButton.IsChecked = false;
            RFootButton.IsChecked = false;
            LToesButton.IsChecked = false;
            RToesButton.IsChecked = false;
            LEarringButton.IsChecked = false;
            REarringButton.IsChecked = false;
            LEarring2Button.IsChecked = false;
            REarring2Button.IsChecked = false;
        }

        private void EnableAll()
        {
            PhysicsButton.IsEnabled = true;
            TPoseButton.IsEnabled = true;
            //DebugButton.IsEnabled = true;
            HeadButton.IsEnabled = true;
            NoseButton.IsEnabled = true;
            NostrilsButton.IsEnabled = true;
            ChinButton.IsEnabled = true;
            LOutEyebrowButton.IsEnabled = true;
            ROutEyebrowButton.IsEnabled = true;
            LInEyebrowButton.IsEnabled = true;
            RInEyebrowButton.IsEnabled = true;
            LEyeButton.IsEnabled = true;
            REyeButton.IsEnabled = true;
            LEyelidButton.IsEnabled = true;
            REyelidButton.IsEnabled = true;
            LLowEyelidButton.IsEnabled = true;
            RLowEyelidButton.IsEnabled = true;
            LEarButton.IsEnabled = true;
            REarButton.IsEnabled = true;
            LCheekButton.IsEnabled = true;
            RCheekButton.IsEnabled = true;
            LMouthButton.IsEnabled = true;
            RMouthButton.IsEnabled = true;
            LUpLipButton.IsEnabled = true;
            RUpLipButton.IsEnabled = true;
            LLowLipButton.IsEnabled = true;
            RLowLipButton.IsEnabled = true;
            NeckButton.IsEnabled = true;
            SternumButton.IsEnabled = true;
            TorsoButton.IsEnabled = true;
            WaistButton.IsEnabled = true;
            LShoulderButton.IsEnabled = true;
            RShoulderButton.IsEnabled = true;
            LClavicleButton.IsEnabled = true;
            RClavicleButton.IsEnabled = true;
            LBreastButton.IsEnabled = true;
            RBreastButton.IsEnabled = true;
            LArmButton.IsEnabled = true;
            RArmButton.IsEnabled = true;
            LElbowButton.IsEnabled = true;
            RElbowButton.IsEnabled = true;
            LForearmButton.IsEnabled = true;
            RForearmButton.IsEnabled = true;
            LWristButton.IsEnabled = true;
            RWristButton.IsEnabled = true;
            LHandButton.IsEnabled = true;
            RHandButton.IsEnabled = true;
            LThumbButton.IsEnabled = true;
            RThumbButton.IsEnabled = true;
            LThumb2Button.IsEnabled = true;
            RThumb2Button.IsEnabled = true;
            LIndexButton.IsEnabled = true;
            RIndexButton.IsEnabled = true;
            LIndex2Button.IsEnabled = true;
            RIndex2Button.IsEnabled = true;
            LMiddleButton.IsEnabled = true;
            RMiddleButton.IsEnabled = true;
            LMiddle2Button.IsEnabled = true;
            RMiddle2Button.IsEnabled = true;
            LRingButton.IsEnabled = true;
            RRingButton.IsEnabled = true;
            LRing2Button.IsEnabled = true;
            RRing2Button.IsEnabled = true;
            LPinkyButton.IsEnabled = true;
            RPinkyButton.IsEnabled = true;
            LPinky2Button.IsEnabled = true;
            RPinky2Button.IsEnabled = true;
            PelvisButton.IsEnabled = true;
            TailButton.IsEnabled = true;
            Tail2Button.IsEnabled = true;
            Tail3Button.IsEnabled = true;
            Tail4Button.IsEnabled = true;
            LThighButton.IsEnabled = true;
            RThighButton.IsEnabled = true;
            LKneeButton.IsEnabled = true;
            RKneeButton.IsEnabled = true;
            LCalfButton.IsEnabled = true;
            RCalfButton.IsEnabled = true;
            LFootButton.IsEnabled = true;
            RFootButton.IsEnabled = true;
            LToesButton.IsEnabled = true;
            RToesButton.IsEnabled = true;
            LEarringButton.IsEnabled = true;
            REarringButton.IsEnabled = true;
            LEarring2Button.IsEnabled = true;
            REarring2Button.IsEnabled = true;
        }

        private void DisableAll()
        {
            PhysicsButton.IsEnabled = false;
            TPoseButton.IsEnabled = false;
            //DebugButton.IsEnabled = false;
            HeadButton.IsEnabled = false;
            NoseButton.IsEnabled = false;
            NostrilsButton.IsEnabled = false;
            ChinButton.IsEnabled = false;
            LOutEyebrowButton.IsEnabled = false;
            ROutEyebrowButton.IsEnabled = false;
            LInEyebrowButton.IsEnabled = false;
            RInEyebrowButton.IsEnabled = false;
            LEyeButton.IsEnabled = false;
            REyeButton.IsEnabled = false;
            LEyelidButton.IsEnabled = false;
            REyelidButton.IsEnabled = false;
            LLowEyelidButton.IsEnabled = false;
            RLowEyelidButton.IsEnabled = false;
            LEarButton.IsEnabled = false;
            REarButton.IsEnabled = false;
            LCheekButton.IsEnabled = false;
            RCheekButton.IsEnabled = false;
            LMouthButton.IsEnabled = false;
            RMouthButton.IsEnabled = false;
            LUpLipButton.IsEnabled = false;
            RUpLipButton.IsEnabled = false;
            LLowLipButton.IsEnabled = false;
            RLowLipButton.IsEnabled = false;
            NeckButton.IsEnabled = false;
            SternumButton.IsEnabled = false;
            TorsoButton.IsEnabled = false;
            WaistButton.IsEnabled = false;
            LShoulderButton.IsEnabled = false;
            RShoulderButton.IsEnabled = false;
            LClavicleButton.IsEnabled = false;
            RClavicleButton.IsEnabled = false;
            LBreastButton.IsEnabled = false;
            RBreastButton.IsEnabled = false;
            LArmButton.IsEnabled = false;
            RArmButton.IsEnabled = false;
            LElbowButton.IsEnabled = false;
            RElbowButton.IsEnabled = false;
            LForearmButton.IsEnabled = false;
            RForearmButton.IsEnabled = false;
            LWristButton.IsEnabled = false;
            RWristButton.IsEnabled = false;
            LHandButton.IsEnabled = false;
            RHandButton.IsEnabled = false;
            LThumbButton.IsEnabled = false;
            RThumbButton.IsEnabled = false;
            LThumb2Button.IsEnabled = false;
            RThumb2Button.IsEnabled = false;
            LIndexButton.IsEnabled = false;
            RIndexButton.IsEnabled = false;
            LIndex2Button.IsEnabled = false;
            RIndex2Button.IsEnabled = false;
            LMiddleButton.IsEnabled = false;
            RMiddleButton.IsEnabled = false;
            LMiddle2Button.IsEnabled = false;
            RMiddle2Button.IsEnabled = false;
            LRingButton.IsEnabled = false;
            RRingButton.IsEnabled = false;
            LRing2Button.IsEnabled = false;
            RRing2Button.IsEnabled = false;
            LPinkyButton.IsEnabled = false;
            RPinkyButton.IsEnabled = false;
            LPinky2Button.IsEnabled = false;
            RPinky2Button.IsEnabled = false;
            PelvisButton.IsEnabled = false;
            TailButton.IsEnabled = false;
            Tail2Button.IsEnabled = false;
            Tail3Button.IsEnabled = false;
            Tail4Button.IsEnabled = false;
            LThighButton.IsEnabled = false;
            RThighButton.IsEnabled = false;
            LKneeButton.IsEnabled = false;
            RKneeButton.IsEnabled = false;
            LCalfButton.IsEnabled = false;
            RCalfButton.IsEnabled = false;
            LFootButton.IsEnabled = false;
            RFootButton.IsEnabled = false;
            LToesButton.IsEnabled = false;
            RToesButton.IsEnabled = false;
            LEarringButton.IsEnabled = false;
            REarringButton.IsEnabled = false;
            LEarring2Button.IsEnabled = false;
            REarring2Button.IsEnabled = false;
        }

        private void TPoseX()
        {
            //CharacterDetails.HeadX.value = 0.7071064711f;
            //CharacterDetails.NoseX.value = 0.7071064711f;
            //CharacterDetails.NostrilsX.value = 0.7071064711f;
            //CharacterDetails.ChinX.value = 0.7010570765f;
            //CharacterDetails.LOutEyebrowX.value = 0.803856492f;
            //CharacterDetails.ROutEyebrowX.value = 0.594822526f;
            //CharacterDetails.LInEyebrowX.value = 0.7071064711f;
            //CharacterDetails.RInEyebrowX.value = 0.7071064711f;
            //CharacterDetails.LEyeX.value = 0.7071064711f;
            //CharacterDetails.REyeX.value = 0.7071064711f;
            //CharacterDetails.LEyelidX.value = 0.731854558f;
            //CharacterDetails.REyelidX.value = 0.6589646935f;
            //CharacterDetails.LLowEyelidX.value = 0.7395583391f;
            //CharacterDetails.RLowEyelidX.value = 0.6428881288f;
            //CharacterDetails.LEarX.value = -0.3030564189f;
            //CharacterDetails.REarX.value = 0.3502247632f;
            //CharacterDetails.LCheekX.value = 0.7933529615f;
            //CharacterDetails.RCheekX.value = 0.6087611914f;
            //CharacterDetails.LMouthX.value = 0.8191515803f;
            //CharacterDetails.RMouthX.value = 0.5735763311f;
            //CharacterDetails.LUpLipX.value = 0.7070794702f;
            //CharacterDetails.RUpLipX.value = 0.7071062922f;
            //CharacterDetails.LLowLipX.value = 0.7071064711f;
            //CharacterDetails.RLowLipX.value = 0.7018356919f;
            CharacterDetails.NeckX.value = 0.6045512557f;
            CharacterDetails.SternumX.value = 0.5119624138f;
            CharacterDetails.TorsoX.value = 0.4947781861f;
            CharacterDetails.WaistX.value = 0.4738240242f;
            CharacterDetails.LShoulderX.value = -0.6383195519f;
            CharacterDetails.RShoulderX.value = -0.2362460941f;
            CharacterDetails.LClavicleX.value = 2.980232239E-8f;
            CharacterDetails.RClavicleX.value = -1.490116119E-8f;
            CharacterDetails.LBreastX.value = -0.03088223934f;
            CharacterDetails.RBreastX.value = -0.03088220209f;
            CharacterDetails.LArmX.value = -0.6383193135f;
            CharacterDetails.RArmX.value = -0.236246109f;
            CharacterDetails.LElbowX.value = -0.6540370584f;
            CharacterDetails.RElbowX.value = 0.2724279761f;
            CharacterDetails.LForearmX.value = -0.6677876711f;
            CharacterDetails.RForearmX.value = 0.3077905476f;
            CharacterDetails.LWristX.value = -0.6532810926f;
            CharacterDetails.RWristX.value = -0.2705979645f;
            CharacterDetails.LHandX.value = -0.6532812119f;
            CharacterDetails.RHandX.value = -0.2705982924f;
            CharacterDetails.LThumbX.value = 0.4309564829f;
            CharacterDetails.RThumbX.value = 0.2627345026f;
            CharacterDetails.LThumb2X.value = 0.4309564829f;
            CharacterDetails.RThumb2X.value = 0.2627344429f;
            CharacterDetails.LIndexX.value = 2.980232239E-8f;
            CharacterDetails.RIndexX.value = -0.3826832771f;
            CharacterDetails.LIndex2X.value = 1.149457951E-8f;
            CharacterDetails.RIndex2X.value = -0.3826832473f;
            CharacterDetails.LMiddleX.value = 2.980232239E-8f;
            CharacterDetails.RMiddleX.value = -0.3826832771f;
            CharacterDetails.LMiddle2X.value = 1.149457951E-8f;
            CharacterDetails.RMiddle2X.value = -0.3826832473f;
            CharacterDetails.LRingX.value = 0f;
            CharacterDetails.RRingX.value = -0.3826832175f;
            CharacterDetails.LRing2X.value = 6.836367028E-10f;
            CharacterDetails.RRing2X.value = -0.3826831877f;
            CharacterDetails.LPinkyX.value = 0f;
            CharacterDetails.RPinkyX.value = -0.3826832175f;
            CharacterDetails.LPinky2X.value = 6.836367028E-10f;
            CharacterDetails.RPinky2X.value = -0.3826831877f;
            CharacterDetails.PelvisX.value = 0.550806284f;
            CharacterDetails.TailX.value = -0.184204489f;
            CharacterDetails.LThighX.value = 0.5075724125f;
            CharacterDetails.RThighX.value = 0.5075724125f;
            CharacterDetails.LKneeX.value = -0.4967896044f;
            CharacterDetails.RKneeX.value = -0.4967896044f;
            CharacterDetails.LCalfX.value = -0.4709248245f;
            CharacterDetails.RCalfX.value = -0.4709248245f;
            CharacterDetails.LFootX.value = 0.6834150553f;
            CharacterDetails.RFootX.value = 0.6834150553f;
            CharacterDetails.LToesX.value = 0.7071067095f;
            CharacterDetails.RToesX.value = 0.7071067095f;
        }

        private void TPoseY()
        {
            //CharacterDetails.HeadY.value = 2.980232239E-8f;
            //CharacterDetails.NoseY.value = 2.967532708E-8f;
            //CharacterDetails.NostrilsY.value = 2.967532708E-8f;
            //CharacterDetails.ChinY.value = -0.09229586273f;
            //CharacterDetails.LOutEyebrowY.value = 2.367235652E-8f;
            //CharacterDetails.ROutEyebrowY.value = 3.493174816E-8f;
            //CharacterDetails.LInEyebrowY.value = 2.967532708E-8f;
            //CharacterDetails.RInEyebrowY.value = 2.967532708E-8f;
            //CharacterDetails.LEyeY.value = 2.967532708E-8f;
            //CharacterDetails.REyeY.value = 2.967532708E-8f;
            //CharacterDetails.LEyelidY.value = 0.1290455163f;
            //CharacterDetails.REyelidY.value = 0.1161931232f;
            //CharacterDetails.LLowEyelidY.value = -0.1504644901f;
            //CharacterDetails.RLowEyelidY.value = -0.1307967603f;
            //CharacterDetails.LEarY.value = 0.2961898446f;
            //CharacterDetails.REarY.value = 0.8353264332f;
            //CharacterDetails.LCheekY.value = 2.427711721E-8f;
            //CharacterDetails.RCheekY.value = 3.451231834E-8f;
            //CharacterDetails.LMouthY.value = 2.549330702E-8f;
            //CharacterDetails.RMouthY.value = 3.55409604E-8f;
            //CharacterDetails.LUpLipY.value = 0.006170331966f;
            //CharacterDetails.RUpLipY.value = 3.026798368E-8f;
            //CharacterDetails.LLowLipY.value = 2.980232239E-8f;
            //CharacterDetails.RLowLipY.value = -0.08617512882f;
            CharacterDetails.NeckY.value = 0.366766274f;
            CharacterDetails.SternumY.value = 0.4877440631f;
            CharacterDetails.TorsoY.value = 0.5051676631f;
            CharacterDetails.WaistY.value = 0.5248720646f;
            CharacterDetails.LShoulderY.value = 0.3042170703f;
            CharacterDetails.RShoulderY.value = 0.6664740443f;
            CharacterDetails.LClavicleY.value = 0f;
            CharacterDetails.RClavicleY.value = 0.9999997616f;
            CharacterDetails.LBreastY.value = -0.6213850379f;
            CharacterDetails.RBreastY.value = -0.782286942f;
            CharacterDetails.LArmY.value = 0.3042170107f;
            CharacterDetails.RArmY.value = 0.6664740443f;
            CharacterDetails.LElbowY.value = 0.2687657475f;
            CharacterDetails.RElbowY.value = -0.6525203586f;
            CharacterDetails.LForearmY.value = 0.2325061858f;
            CharacterDetails.RForearmY.value = -0.6366041303f;
            CharacterDetails.LWristY.value = 0.2705978751f;
            CharacterDetails.RWristY.value = 0.6532813907f;
            CharacterDetails.LHandY.value = 0.2705976069f;
            CharacterDetails.RHandY.value = 0.6532812119f;
            CharacterDetails.LThumbY.value = -0.5649164915f;
            CharacterDetails.RThumbY.value = -0.6527751088f;
            CharacterDetails.LThumb2Y.value = -0.5649165511f;
            CharacterDetails.RThumb2Y.value = -0.6527751684f;
            CharacterDetails.LIndexY.value = -4.917383194E-7f;
            CharacterDetails.RIndexY.value = 0.9238792062f;
            CharacterDetails.LIndex2Y.value = -4.648088918E-7f;
            CharacterDetails.RIndex2Y.value = 0.9238791466f;
            CharacterDetails.LMiddleY.value = -4.917383194E-7f;
            CharacterDetails.RMiddleY.value = 0.9238792062f;
            CharacterDetails.LMiddle2Y.value = -4.648088918E-7f;
            CharacterDetails.RMiddle2Y.value = 0.9238791466f;
            CharacterDetails.LRingY.value = -1.490116119E-8f;
            CharacterDetails.RRingY.value = 0.923879087f;
            CharacterDetails.LRing2Y.value = -1.625886092E-9f;
            CharacterDetails.RRing2Y.value = 0.9238790274f;
            CharacterDetails.LPinkyY.value = -1.490116119E-8f;
            CharacterDetails.RPinkyY.value = 0.923879087f;
            CharacterDetails.LPinky2Y.value = -1.625886092E-9f;
            CharacterDetails.RPinky2Y.value = 0.9238790274f;
            CharacterDetails.PelvisY.value = -0.4434098899f;
            CharacterDetails.TailY.value = 0.6826921701f;
            CharacterDetails.LThighY.value = -0.4923109114f;
            CharacterDetails.RThighY.value = -0.4923109114f;
            CharacterDetails.LKneeY.value = 0.503189683f;
            CharacterDetails.RKneeY.value = 0.503189683f;
            CharacterDetails.LCalfY.value = 0.5274748206f;
            CharacterDetails.RCalfY.value = 0.5274748206f;
            CharacterDetails.LFootY.value = -0.181504041f;
            CharacterDetails.RFootY.value = -0.181504041f;
            CharacterDetails.LToesY.value = -1.490116119E-8f;
            CharacterDetails.RToesY.value = -1.490116119E-8f;
        }

        private void TPoseZ()
        {
            //CharacterDetails.HeadZ.value = 0.7071065903f;
            //CharacterDetails.NoseZ.value = 0.7071065903f;
            //CharacterDetails.NostrilsZ.value = 0.7071065903f;
            //CharacterDetails.ChinZ.value = 0.7010571957f;
            //CharacterDetails.LOutEyebrowZ.value = 0.5948226452f;
            //CharacterDetails.ROutEyebrowZ.value = 0.8038566113f;
            //CharacterDetails.LInEyebrowZ.value = 0.7071065903f;
            //CharacterDetails.RInEyebrowZ.value = 0.7071065903f;
            //CharacterDetails.LEyeZ.value = 0.7071065903f;
            //CharacterDetails.REyeZ.value = 0.7071065903f;
            //CharacterDetails.LEyelidZ.value = 0.6589648724f;
            //CharacterDetails.REyelidZ.value = 0.7318546176f;
            //CharacterDetails.LLowEyelidZ.value = 0.6428883076f;
            //CharacterDetails.RLowEyelidZ.value = 0.7395585179f;
            //CharacterDetails.LEarZ.value = 0.3502247334f;
            //CharacterDetails.REarZ.value = -0.3030564487f;
            //CharacterDetails.LCheekZ.value = 0.6087613106f;
            //CharacterDetails.RCheekZ.value = 0.7933530807f;
            //CharacterDetails.LMouthZ.value = 0.5735765696f;
            //CharacterDetails.RMouthZ.value = 0.8191516399f;
            //CharacterDetails.LUpLipZ.value = 0.7070795894f;
            //CharacterDetails.RUpLipZ.value = 0.7071064115f;
            //CharacterDetails.LLowLipZ.value = 0.7071065903f;
            //CharacterDetails.RLowLipZ.value = 0.7018358111f;
            CharacterDetails.NeckZ.value = 0.6045513153f;
            CharacterDetails.SternumZ.value = 0.5119624734f;
            CharacterDetails.TorsoZ.value = 0.4947781861f;
            CharacterDetails.WaistZ.value = 0.4738240242f;
            CharacterDetails.LShoulderZ.value = -0.2362460047f;
            CharacterDetails.RShoulderZ.value = -0.6383191943f;
            CharacterDetails.LClavicleZ.value = 0f;
            CharacterDetails.RClavicleZ.value = 2.980232239E-8f;
            CharacterDetails.LBreastZ.value = 0.03088222817f;
            CharacterDetails.RBreastZ.value = 0.03088220209f;
            CharacterDetails.LArmZ.value = -0.236246109f;
            CharacterDetails.RArmZ.value = -0.6383193135f;
            CharacterDetails.LElbowZ.value = -0.2724279761f;
            CharacterDetails.RElbowZ.value = 0.6540369987f;
            CharacterDetails.LForearmZ.value = -0.3077905178f;
            CharacterDetails.RForearmZ.value = 0.6677876711f;
            CharacterDetails.LWristZ.value = -0.2705979943f;
            CharacterDetails.RWristZ.value = -0.6532810926f;
            CharacterDetails.LHandZ.value = -0.2705982327f;
            CharacterDetails.RHandZ.value = -0.6532812119f;
            CharacterDetails.LThumbZ.value = -0.2627345026f;
            CharacterDetails.RThumbZ.value = -0.4309565127f;
            CharacterDetails.LThumb2Z.value = -0.2627344728f;
            CharacterDetails.RThumb2Z.value = -0.4309565723f;
            CharacterDetails.LIndexZ.value = -0.3826832771f;
            CharacterDetails.RIndexZ.value = 0f;
            CharacterDetails.LIndex2Z.value = -0.3826832473f;
            CharacterDetails.RIndex2Z.value = 1.752551704E-8f;
            CharacterDetails.LMiddleZ.value = -0.3826832771f;
            CharacterDetails.RMiddleZ.value = 0f;
            CharacterDetails.LMiddle2Z.value = -0.3826832473f;
            CharacterDetails.RMiddle2Z.value = 1.752551704E-8f;
            CharacterDetails.LRingZ.value = -0.3826832175f;
            CharacterDetails.RRingZ.value = 0f;
            CharacterDetails.LRing2Z.value = -0.3826832175f;
            CharacterDetails.RRing2Z.value = -6.725038304E-10f;
            CharacterDetails.LPinkyZ.value = -0.3826832175f;
            CharacterDetails.RPinkyZ.value = 0f;
            CharacterDetails.LPinky2Z.value = -0.3826832175f;
            CharacterDetails.RPinky2Z.value = -6.725038304E-10f;
            CharacterDetails.PelvisZ.value = 0.550806284f;
            CharacterDetails.TailZ.value = -0.184204489f;
            CharacterDetails.LThighZ.value = 0.5075724125f;
            CharacterDetails.RThighZ.value = 0.5075724125f;
            CharacterDetails.LKneeZ.value = -0.496789515f;
            CharacterDetails.RKneeZ.value = -0.496789515f;
            CharacterDetails.LCalfZ.value = -0.4709247351f;
            CharacterDetails.RCalfZ.value = -0.4709247351f;
            CharacterDetails.LFootZ.value = 0.6834150553f;
            CharacterDetails.RFootZ.value = 0.6834150553f;
            CharacterDetails.LToesZ.value = 0.7071067691f;
            CharacterDetails.RToesZ.value = 0.7071067691f;
        }

        private void TPoseW()
        {
            //CharacterDetails.HeadW.value = 2.980232239E-8f;
            //CharacterDetails.NoseW.value = 2.967532708E-8f;
            //CharacterDetails.NostrilsW.value = 2.967532708E-8f;
            //CharacterDetails.ChinW.value = -0.09229589254f;
            //CharacterDetails.LOutEyebrowW.value = 3.28294476E-8f;
            //CharacterDetails.ROutEyebrowW.value = 2.646828356E-8f;
            //CharacterDetails.LInEyebrowW.value = 2.967532708E-8f;
            //CharacterDetails.RInEyebrowW.value = 2.967532708E-8f;
            //CharacterDetails.LEyeW.value = 2.967532708E-8f;
            //CharacterDetails.REyeW.value = 2.967532708E-8f;
            //CharacterDetails.LEyelidW.value = 0.1161931381f;
            //CharacterDetails.REyelidW.value = 0.129045561f;
            //CharacterDetails.LLowEyelidW.value = -0.1307968199f;
            //CharacterDetails.RLowEyelidW.value = -0.150464505f;
            //CharacterDetails.LEarW.value = 0.8353263736f;
            //CharacterDetails.REarW.value = 0.2961899042f;
            //CharacterDetails.LCheekW.value = 3.236348078E-8f;
            //CharacterDetails.RCheekW.value = 2.703848878E-8f;
            //CharacterDetails.LMouthW.value = 3.539162208E-8f;
            //CharacterDetails.RMouthW.value = 2.559784917E-8f;
            //CharacterDetails.LUpLipW.value = 0.006170333829f;
            //CharacterDetails.RUpLipW.value = 3.026798368E-8f;
            //CharacterDetails.LLowLipW.value = 2.980232239E-8f;
            //CharacterDetails.RLowLipW.value = -0.08617514372f;
            CharacterDetails.NeckW.value = 0.3667662442f;
            CharacterDetails.SternumW.value = 0.4877440631f;
            CharacterDetails.TorsoW.value = 0.5051677227f;
            CharacterDetails.WaistW.value = 0.5248720646f;
            CharacterDetails.LShoulderW.value = 0.6664738059f;
            CharacterDetails.RShoulderW.value = 0.3042169213f;
            CharacterDetails.LClavicleW.value = 0.9999997616f;
            CharacterDetails.RClavicleW.value = 1.490116119E-8f;
            CharacterDetails.LBreastW.value = 0.7822870016f;
            CharacterDetails.RBreastW.value = 0.6213850975f;
            CharacterDetails.LArmW.value = 0.6664740443f;
            CharacterDetails.RArmW.value = 0.3042169809f;
            CharacterDetails.LElbowW.value = 0.652520299f;
            CharacterDetails.RElbowW.value = -0.2687657475f;
            CharacterDetails.LForearmW.value = 0.6366040707f;
            CharacterDetails.RForearmW.value = -0.232506156f;
            CharacterDetails.LWristW.value = 0.6532813907f;
            CharacterDetails.RWristW.value = 0.2705978751f;
            CharacterDetails.LHandW.value = 0.6532812119f;
            CharacterDetails.RHandW.value = 0.2705976367f;
            CharacterDetails.LThumbW.value = 0.652775228f;
            CharacterDetails.RThumbW.value = 0.5649167299f;
            CharacterDetails.LThumb2W.value = 0.6527751684f;
            CharacterDetails.RThumb2W.value = 0.5649166703f;
            CharacterDetails.LIndexW.value = 0.9238791466f;
            CharacterDetails.RIndexW.value = -4.768371582E-7f;
            CharacterDetails.LIndex2W.value = 0.9238791466f;
            CharacterDetails.RIndex2W.value = -4.644691955E-7f;
            CharacterDetails.LMiddleW.value = 0.9238791466f;
            CharacterDetails.RMiddleW.value = -4.768371582E-7f;
            CharacterDetails.LMiddle2W.value = 0.9238791466f;
            CharacterDetails.RMiddle2W.value = -4.644691955E-7f;
            CharacterDetails.LRingW.value = 0.9238790274f;
            CharacterDetails.RRingW.value = -1.490116119E-8f;
            CharacterDetails.LRing2W.value = 0.9238790274f;
            CharacterDetails.RRing2W.value = 1.644958836E-9f;
            CharacterDetails.LPinkyW.value = 0.9238790274f;
            CharacterDetails.RPinkyW.value = -1.490116119E-8f;
            CharacterDetails.LPinky2W.value = 0.9238790274f;
            CharacterDetails.RPinky2W.value = 1.644958836E-9f;
            CharacterDetails.PelvisW.value = -0.4434098899f;
            CharacterDetails.TailW.value = 0.6826921701f;
            CharacterDetails.LThighW.value = -0.4923109114f;
            CharacterDetails.RThighW.value = -0.4923109114f;
            CharacterDetails.LKneeW.value = 0.5031898022f;
            CharacterDetails.RKneeW.value = 0.5031898022f;
            CharacterDetails.LCalfW.value = 0.5274748206f;
            CharacterDetails.RCalfW.value = 0.5274748206f;
            CharacterDetails.LFootW.value = -0.1815040112f;
            CharacterDetails.RFootW.value = -0.1815040112f;
            CharacterDetails.LToesW.value = -1.490116119E-8f;
            CharacterDetails.RToesW.value = -1.490116119E-8f;
        }

        private void EnableRotations()
        {
            CharacterDetails.DebugRotate = true;
            CharacterDetails.HeadRotate = true;
            CharacterDetails.NoseRotate = true;
            CharacterDetails.NostrilsRotate = true;
            CharacterDetails.ChinRotate = true;
            CharacterDetails.LOutEyebrowRotate = true;
            CharacterDetails.ROutEyebrowRotate = true;
            CharacterDetails.LInEyebrowRotate = true;
            CharacterDetails.RInEyebrowRotate = true;
            CharacterDetails.LEyeRotate = true;
            CharacterDetails.REyeRotate = true;
            CharacterDetails.LEyelidRotate = true;
            CharacterDetails.REyelidRotate = true;
            CharacterDetails.LLowEyelidRotate = true;
            CharacterDetails.RLowEyelidRotate = true;
            CharacterDetails.LEarRotate = true;
            CharacterDetails.REarRotate = true;
            CharacterDetails.LCheekRotate = true;
            CharacterDetails.RCheekRotate = true;
            CharacterDetails.LMouthRotate = true;
            CharacterDetails.RMouthRotate = true;
            CharacterDetails.LUpLipRotate = true;
            CharacterDetails.RUpLipRotate = true;
            CharacterDetails.LLowLipRotate = true;
            CharacterDetails.RLowLipRotate = true;
            CharacterDetails.NeckRotate = true;
            CharacterDetails.SternumRotate = true;
            CharacterDetails.TorsoRotate = true;
            CharacterDetails.WaistRotate = true;
            CharacterDetails.LShoulderRotate = true;
            CharacterDetails.RShoulderRotate = true;
            CharacterDetails.LClavicleRotate = true;
            CharacterDetails.RClavicleRotate = true;
            CharacterDetails.LBreastRotate = true;
            CharacterDetails.RBreastRotate = true;
            CharacterDetails.LArmRotate = true;
            CharacterDetails.RArmRotate = true;
            CharacterDetails.LElbowRotate = true;
            CharacterDetails.RElbowRotate = true;
            CharacterDetails.LForearmRotate = true;
            CharacterDetails.RForearmRotate = true;
            CharacterDetails.LWristRotate = true;
            CharacterDetails.RWristRotate = true;
            CharacterDetails.LHandRotate = true;
            CharacterDetails.RHandRotate = true;
            CharacterDetails.LThumbRotate = true;
            CharacterDetails.RThumbRotate = true;
            CharacterDetails.LThumb2Rotate = true;
            CharacterDetails.RThumb2Rotate = true;
            CharacterDetails.LIndexRotate = true;
            CharacterDetails.RIndexRotate = true;
            CharacterDetails.LIndex2Rotate = true;
            CharacterDetails.RIndex2Rotate = true;
            CharacterDetails.LMiddleRotate = true;
            CharacterDetails.RMiddleRotate = true;
            CharacterDetails.LMiddle2Rotate = true;
            CharacterDetails.RMiddle2Rotate = true;
            CharacterDetails.LRingRotate = true;
            CharacterDetails.RRingRotate = true;
            CharacterDetails.LRing2Rotate = true;
            CharacterDetails.RRing2Rotate = true;
            CharacterDetails.LPinkyRotate = true;
            CharacterDetails.RPinkyRotate = true;
            CharacterDetails.LPinky2Rotate = true;
            CharacterDetails.RPinky2Rotate = true;
            CharacterDetails.PelvisRotate = true;
            CharacterDetails.TailRotate = true;
            CharacterDetails.Tail2Rotate = true;
            CharacterDetails.Tail3Rotate = true;
            CharacterDetails.Tail4Rotate = true;
            CharacterDetails.LThighRotate = true;
            CharacterDetails.RThighRotate = true;
            CharacterDetails.LKneeRotate = true;
            CharacterDetails.RKneeRotate = true;
            CharacterDetails.LCalfRotate = true;
            CharacterDetails.RCalfRotate = true;
            CharacterDetails.LFootRotate = true;
            CharacterDetails.RFootRotate = true;
            CharacterDetails.LToesRotate = true;
            CharacterDetails.RToesRotate = true;
            CharacterDetails.LEarringRotate = true;
            CharacterDetails.REarringRotate = true;
            CharacterDetails.LEarring2Rotate = true;
            CharacterDetails.REarring2Rotate = true;
        }

        private void DisableRotations()
        {
            CharacterDetails.DebugRotate = false;
            CharacterDetails.HeadRotate = false;
            CharacterDetails.NoseRotate = false;
            CharacterDetails.NostrilsRotate = false;
            CharacterDetails.ChinRotate = false;
            CharacterDetails.LOutEyebrowRotate = false;
            CharacterDetails.ROutEyebrowRotate = false;
            CharacterDetails.LInEyebrowRotate = false;
            CharacterDetails.RInEyebrowRotate = false;
            CharacterDetails.LEyeRotate = false;
            CharacterDetails.REyeRotate = false;
            CharacterDetails.LEyelidRotate = false;
            CharacterDetails.REyelidRotate = false;
            CharacterDetails.LLowEyelidRotate = false;
            CharacterDetails.RLowEyelidRotate = false;
            CharacterDetails.LEarRotate = false;
            CharacterDetails.REarRotate = false;
            CharacterDetails.LCheekRotate = false;
            CharacterDetails.RCheekRotate = false;
            CharacterDetails.LMouthRotate = false;
            CharacterDetails.RMouthRotate = false;
            CharacterDetails.LUpLipRotate = false;
            CharacterDetails.RUpLipRotate = false;
            CharacterDetails.LLowLipRotate = false;
            CharacterDetails.RLowLipRotate = false;
            CharacterDetails.NeckRotate = false;
            CharacterDetails.SternumRotate = false;
            CharacterDetails.TorsoRotate = false;
            CharacterDetails.WaistRotate = false;
            CharacterDetails.LShoulderRotate = false;
            CharacterDetails.RShoulderRotate = false;
            CharacterDetails.LClavicleRotate = false;
            CharacterDetails.RClavicleRotate = false;
            CharacterDetails.LBreastRotate = false;
            CharacterDetails.RBreastRotate = false;
            CharacterDetails.LArmRotate = false;
            CharacterDetails.RArmRotate = false;
            CharacterDetails.LElbowRotate = false;
            CharacterDetails.RElbowRotate = false;
            CharacterDetails.LForearmRotate = false;
            CharacterDetails.RForearmRotate = false;
            CharacterDetails.LWristRotate = false;
            CharacterDetails.RWristRotate = false;
            CharacterDetails.LHandRotate = false;
            CharacterDetails.RHandRotate = false;
            CharacterDetails.LThumbRotate = false;
            CharacterDetails.RThumbRotate = false;
            CharacterDetails.LThumb2Rotate = false;
            CharacterDetails.RThumb2Rotate = false;
            CharacterDetails.LIndexRotate = false;
            CharacterDetails.RIndexRotate = false;
            CharacterDetails.LIndex2Rotate = false;
            CharacterDetails.RIndex2Rotate = false;
            CharacterDetails.LMiddleRotate = false;
            CharacterDetails.RMiddleRotate = false;
            CharacterDetails.LMiddle2Rotate = false;
            CharacterDetails.RMiddle2Rotate = false;
            CharacterDetails.LRingRotate = false;
            CharacterDetails.RRingRotate = false;
            CharacterDetails.LRing2Rotate = false;
            CharacterDetails.RRing2Rotate = false;
            CharacterDetails.LPinkyRotate = false;
            CharacterDetails.RPinkyRotate = false;
            CharacterDetails.LPinky2Rotate = false;
            CharacterDetails.RPinky2Rotate = false;
            CharacterDetails.PelvisRotate = false;
            CharacterDetails.TailRotate = false;
            CharacterDetails.Tail2Rotate = false;
            CharacterDetails.Tail3Rotate = false;
            CharacterDetails.Tail4Rotate = false;
            CharacterDetails.LThighRotate = false;
            CharacterDetails.RThighRotate = false;
            CharacterDetails.LKneeRotate = false;
            CharacterDetails.RKneeRotate = false;
            CharacterDetails.LCalfRotate = false;
            CharacterDetails.RCalfRotate = false;
            CharacterDetails.LFootRotate = false;
            CharacterDetails.RFootRotate = false;
            CharacterDetails.LToesRotate = false;
            CharacterDetails.RToesRotate = false;
            CharacterDetails.LEarringRotate = false;
            CharacterDetails.REarringRotate = false;
            CharacterDetails.LEarring2Rotate = false;
            CharacterDetails.REarring2Rotate = false;
        }
    }
}
