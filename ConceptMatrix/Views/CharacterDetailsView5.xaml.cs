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
        public bool HeadRotate;
        public bool NoseRotate;
        public bool NostrilsRotate;
        public bool ChinRotate;
        public bool LOutEyebrowRotate;
        public bool ROutEyebrowRotate;
        public bool LInEyebrowRotate;
        public bool RInEyebrowRotate;
        public bool LEyeRotate;
        public bool REyeRotate;
        public bool LEyelidRotate;
        public bool REyelidRotate;
        public bool LLowEyelidRotate;
        public bool RLowEyelidRotate;
        public bool LEarRotate;
        public bool REarRotate;
        public bool LCheekRotate;
        public bool RCheekRotate;
        public bool LMouthRotate;
        public bool RMouthRotate;
        public bool LUpLipRotate;
        public bool RUpLipRotate;
        public bool LLowLipRotate;
        public bool RLowLipRotate;
        public bool NeckRotate;
        public bool SternumRotate;
        public bool TorsoRotate;
        public bool WaistRotate;
        public bool LShoulderRotate;
        public bool RShoulderRotate;
        public bool LClavicleRotate;
        public bool RClavicleRotate;
        public bool LBreastRotate;
        public bool RBreastRotate;
        public bool LArmRotate;
        public bool RArmRotate;
        public bool LElbowRotate;
        public bool RElbowRotate;
        public bool LForearmRotate;
        public bool RForearmRotate;
        public bool LWristRotate;
        public bool RWristRotate;
        public bool LHandRotate;
        public bool RHandRotate;
        public bool LThumbRotate;
        public bool RThumbRotate;
        public bool LThumb2Rotate;
        public bool RThumb2Rotate;
        public bool LIndexRotate;
        public bool RIndexRotate;
        public bool LIndex2Rotate;
        public bool RIndex2Rotate;
        public bool LMiddleRotate;
        public bool RMiddleRotate;
        public bool LMiddle2Rotate;
        public bool RMiddle2Rotate;
        public bool LRingRotate;
        public bool RRingRotate;
        public bool LRing2Rotate;
        public bool RRing2Rotate;
        public bool LPinkyRotate;
        public bool RPinkyRotate;
        public bool LPinky2Rotate;
        public bool RPinky2Rotate;
        public bool PelvisRotate;
        public bool TailRotate;
        public bool LThighRotate;
        public bool RThighRotate;
        public bool LKneeRotate;
        public bool RKneeRotate;
        public bool LCalfRotate;
        public bool RCalfRotate;
        public bool LFootRotate;
        public bool RFootRotate;
        public bool LToesRotate;
        public bool RToesRotate;
        public bool HeadCheck;
        public bool NoseCheck;
        public bool NostrilsCheck;
        public bool ChinCheck;
        public bool LOutEyebrowCheck;
        public bool ROutEyebrowCheck;
        public bool LInEyebrowCheck;
        public bool RInEyebrowCheck;
        public bool LEyeCheck;
        public bool REyeCheck;
        public bool LEyelidCheck;
        public bool REyelidCheck;
        public bool LLowEyelidCheck;
        public bool RLowEyelidCheck;
        public bool LEarCheck;
        public bool REarCheck;
        public bool LCheekCheck;
        public bool RCheekCheck;
        public bool LMouthCheck;
        public bool RMouthCheck;
        public bool LUpLipCheck;
        public bool RUpLipCheck;
        public bool LLowLipCheck;
        public bool RLowLipCheck;
        public bool NeckCheck;
        public bool SternumCheck;
        public bool TorsoCheck;
        public bool WaistCheck;
        public bool LShoulderCheck;
        public bool RShoulderCheck;
        public bool LClavicleCheck;
        public bool RClavicleCheck;
        public bool LBreastCheck;
        public bool RBreastCheck;
        public bool LArmCheck;
        public bool RArmCheck;
        public bool LElbowCheck;
        public bool RElbowCheck;
        public bool LForearmCheck;
        public bool RForearmCheck;
        public bool LWristCheck;
        public bool RWristCheck;
        public bool LHandCheck;
        public bool RHandCheck;
        public bool LThumbCheck;
        public bool RThumbCheck;
        public bool LThumb2Check;
        public bool RThumb2Check;
        public bool LIndexCheck;
        public bool RIndexCheck;
        public bool LIndex2Check;
        public bool RIndex2Check;
        public bool LMiddleCheck;
        public bool RMiddleCheck;
        public bool LMiddle2Check;
        public bool RMiddle2Check;
        public bool LRingCheck;
        public bool RRingCheck;
        public bool LRing2Check;
        public bool RRing2Check;
        public bool LPinkyCheck;
        public bool RPinkyCheck;
        public bool LPinky2Check;
        public bool RPinky2Check;
        public bool PelvisCheck;
        public bool TailCheck;
        public bool LThighCheck;
        public bool RThighCheck;
        public bool LKneeCheck;
        public bool RKneeCheck;
        public bool LCalfCheck;
        public bool RCalfCheck;
        public bool LFootCheck;
        public bool RFootCheck;
        public bool LToesCheck;
        public bool RToesCheck;
        public bool EditMode = false;
        public byte[] SkeletonValue;
        public byte[] SkeletonValue2;
        public byte[] SkeletonValue3;
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
            if (HeadRotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= HeadRot;
                    BoneSlider.ValueChanged += HeadRot;
                }
            }

            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= NoseRot;
                    BoneSlider.ValueChanged += NoseRot;
                }
            }

            if (NostrilsRotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= NostrilsRot;
                    BoneSlider.ValueChanged += NostrilsRot;
                }
            }

            if (ChinRotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= ChinRot;
                    BoneSlider.ValueChanged += ChinRot;
                }
            }

            if (LOutEyebrowRotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= LOutEyebrowRot;
                    BoneSlider.ValueChanged += LOutEyebrowRot;
                }
            }

            if (ROutEyebrowRotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= ROutEyebrowRot;
                    BoneSlider.ValueChanged += ROutEyebrowRot;
                }
            }

            if (LInEyebrowRotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= LInEyebrowRot;
                    BoneSlider.ValueChanged += LInEyebrowRot;
                }
            }

            if (RInEyebrowRotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= RInEyebrowRot;
                    BoneSlider.ValueChanged += RInEyebrowRot;
                }
            }

            if (LEyeRotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= LEyeRot;
                    BoneSlider.ValueChanged += LEyeRot;
                }
            }

            if (REyeRotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= REyeRot;
                    BoneSlider.ValueChanged += REyeRot;
                }
            }

            if (LEyelidRotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= LEyelidRot;
                    BoneSlider.ValueChanged += LEyelidRot;
                }
            }

            if (REyelidRotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= REyelidRot;
                    BoneSlider.ValueChanged += REyelidRot;
                }
            }

            if (LLowEyelidRotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= LLowEyelidRot;
                    BoneSlider.ValueChanged += LLowEyelidRot;
                }
            }

            if (RLowEyelidRotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= RLowEyelidRot;
                    BoneSlider.ValueChanged += RLowEyelidRot;
                }
            }

            if (LEarRotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= LEarRot;
                    BoneSlider.ValueChanged += LEarRot;
                }
            }

            if (REarRotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= REarRot;
                    BoneSlider.ValueChanged += REarRot;
                }
            }

            if (LCheekRotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= LCheekRot;
                    BoneSlider.ValueChanged += LCheekRot;
                }
            }

            if (RCheekRotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= RCheekRot;
                    BoneSlider.ValueChanged += RCheekRot;
                }
            }

            if (LMouthRotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= LMouthRot;
                    BoneSlider.ValueChanged += LMouthRot;
                }
            }

            if (RMouthRotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= RMouthRot;
                    BoneSlider.ValueChanged += RMouthRot;
                }
            }

            if (LUpLipRotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= LUpLipRot;
                    BoneSlider.ValueChanged += LUpLipRot;
                }
            }

            if (RUpLipRotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= RUpLipRot;
                    BoneSlider.ValueChanged += RUpLipRot;
                }
            }

            if (LLowLipRotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= LLowLipRot;
                    BoneSlider.ValueChanged += LLowLipRot;
                }
            }

            if (RLowLipRotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= RLowLipRot;
                    BoneSlider.ValueChanged += RLowLipRot;
                }
            }

            if (NeckRotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= NeckRot;
                    BoneSlider.ValueChanged += NeckRot;
                }
            }

            if (SternumRotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= SternumRot;
                    BoneSlider.ValueChanged += SternumRot;
                }
            }

            if (TorsoRotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= TorsoRot;
                    BoneSlider.ValueChanged += TorsoRot;
                }
            }

            if (WaistRotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= WaistRot;
                    BoneSlider.ValueChanged += WaistRot;
                }
            }

            if (LShoulderRotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= LShoulderRot;
                    BoneSlider.ValueChanged += LShoulderRot;
                }
            }

            if (RShoulderRotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= RShoulderRot;
                    BoneSlider.ValueChanged += RShoulderRot;
                }
            }

            if (LClavicleRotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= LClavicleRot;
                    BoneSlider.ValueChanged += LClavicleRot;
                }
            }

            if (RClavicleRotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= RClavicleRot;
                    BoneSlider.ValueChanged += RClavicleRot;
                }
            }

            if (LBreastRotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= LBreastRot;
                    BoneSlider.ValueChanged += LBreastRot;
                }
            }

            if (RBreastRotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= RBreastRot;
                    BoneSlider.ValueChanged += RBreastRot;
                }
            }

            if (LArmRotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= LArmRot;
                    BoneSlider.ValueChanged += LArmRot;
                }
            }

            if (RArmRotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= RArmRot;
                    BoneSlider.ValueChanged += RArmRot;
                }
            }

            if (LElbowRotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= LElbowRot;
                    BoneSlider.ValueChanged += LElbowRot;
                }
            }

            if (RElbowRotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= RElbowRot;
                    BoneSlider.ValueChanged += RElbowRot;
                }
            }

            if (LForearmRotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= LForearmRot;
                    BoneSlider.ValueChanged += LForearmRot;
                }
            }

            if (RForearmRotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= RForearmRot;
                    BoneSlider.ValueChanged += RForearmRot;
                }
            }

            if (LWristRotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= LWristRot;
                    BoneSlider.ValueChanged += LWristRot;
                }
            }

            if (RWristRotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= RWristRot;
                    BoneSlider.ValueChanged += RWristRot;
                }
            }

            if (LHandRotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= LHandRot;
                    BoneSlider.ValueChanged += LHandRot;
                }
            }

            if (RHandRotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= RHandRot;
                    BoneSlider.ValueChanged += RHandRot;
                }
            }

            if (LThumbRotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= LThumbRot;
                    BoneSlider.ValueChanged += LThumbRot;
                }
            }

            if (RThumbRotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= RThumbRot;
                    BoneSlider.ValueChanged += RThumbRot;
                }
            }

            if (LThumb2Rotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= LThumb2Rot;
                    BoneSlider.ValueChanged += LThumb2Rot;
                }
            }

            if (RThumb2Rotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= RThumb2Rot;
                    BoneSlider.ValueChanged += RThumb2Rot;
                }
            }

            if (LIndexRotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= LIndexRot;
                    BoneSlider.ValueChanged += LIndexRot;
                }
            }

            if (RIndexRotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= RIndexRot;
                    BoneSlider.ValueChanged += RIndexRot;
                }
            }

            if (LIndex2Rotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= LIndex2Rot;
                    BoneSlider.ValueChanged += LIndex2Rot;
                }
            }

            if (RIndex2Rotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= RIndex2Rot;
                    BoneSlider.ValueChanged += RIndex2Rot;
                }
            }

            if (LMiddleRotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= LMiddleRot;
                    BoneSlider.ValueChanged += LMiddleRot;
                }
            }

            if (RMiddleRotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= RMiddleRot;
                    BoneSlider.ValueChanged += RMiddleRot;
                }
            }

            if (LMiddle2Rotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= LMiddle2Rot;
                    BoneSlider.ValueChanged += LMiddle2Rot;
                }
            }

            if (RMiddle2Rotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= RMiddle2Rot;
                    BoneSlider.ValueChanged += RMiddle2Rot;
                }
            }

            if (LRingRotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= LRingRot;
                    BoneSlider.ValueChanged += LRingRot;
                }
            }

            if (RRingRotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= RRingRot;
                    BoneSlider.ValueChanged += RRingRot;
                }
            }

            if (LRing2Rotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= LRing2Rot;
                    BoneSlider.ValueChanged += LRing2Rot;
                }
            }

            if (RRing2Rotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= RRing2Rot;
                    BoneSlider.ValueChanged += RRing2Rot;
                }
            }

            if (LPinkyRotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= LPinkyRot;
                    BoneSlider.ValueChanged += LPinkyRot;
                }
            }

            if (RPinkyRotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= RPinkyRot;
                    BoneSlider.ValueChanged += RPinkyRot;
                }
            }

            if (LPinky2Rotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= LPinky2Rot;
                    BoneSlider.ValueChanged += LPinky2Rot;
                }
            }

            if (RPinky2Rotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= RPinky2Rot;
                    BoneSlider.ValueChanged += RPinky2Rot;
                }
            }

            if (PelvisRotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= PelvisRot;
                    BoneSlider.ValueChanged += PelvisRot;
                }
            }

            if (TailRotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= TailRot;
                    BoneSlider.ValueChanged += TailRot;
                }
            }

            if (LThighRotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= LThighRot;
                    BoneSlider.ValueChanged += LThighRot;
                }
            }

            if (RThighRotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= RThighRot;
                    BoneSlider.ValueChanged += RThighRot;
                }
            }

            if (LKneeRotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= LKneeRot;
                    BoneSlider.ValueChanged += LKneeRot;
                }
            }

            if (RKneeRotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= RKneeRot;
                    BoneSlider.ValueChanged += RKneeRot;
                }
            }

            if (LCalfRotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= LCalfRot;
                    BoneSlider.ValueChanged += LCalfRot;
                }
            }

            if (RCalfRotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= RCalfRot;
                    BoneSlider.ValueChanged += RCalfRot;
                }
            }

            if (LFootRotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= LFootRot;
                    BoneSlider.ValueChanged += LFootRot;
                }
            }

            if (RFootRotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= RFootRot;
                    BoneSlider.ValueChanged += RFootRot;
                }
            }

            if (LToesRotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= LToesRot;
                    BoneSlider.ValueChanged += LToesRot;
                }
            }

            if (RToesRotate)
            {
                if (BoneSlider.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider.ValueChanged -= RToesRot;
                    BoneSlider.ValueChanged += RToesRot;
                }
            }
        }


        private void BoneSliders2_SourceUpdated(object sender, DataTransferEventArgs e)
        {
            if (HeadRotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= HeadRot;
                    BoneSlider2.ValueChanged += HeadRot;
                }
            }

            if (NoseRotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= NoseRot;
                    BoneSlider2.ValueChanged += NoseRot;
                }
            }

            if (NostrilsRotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= NostrilsRot;
                    BoneSlider2.ValueChanged += NostrilsRot;
                }
            }

            if (ChinRotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= ChinRot;
                    BoneSlider2.ValueChanged += ChinRot;
                }
            }

            if (LOutEyebrowRotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= LOutEyebrowRot;
                    BoneSlider2.ValueChanged += LOutEyebrowRot;
                }
            }

            if (ROutEyebrowRotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= ROutEyebrowRot;
                    BoneSlider2.ValueChanged += ROutEyebrowRot;
                }
            }

            if (LInEyebrowRotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= LInEyebrowRot;
                    BoneSlider2.ValueChanged += LInEyebrowRot;
                }
            }

            if (RInEyebrowRotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= RInEyebrowRot;
                    BoneSlider2.ValueChanged += RInEyebrowRot;
                }
            }

            if (LEyeRotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= LEyeRot;
                    BoneSlider2.ValueChanged += LEyeRot;
                }
            }

            if (REyeRotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= REyeRot;
                    BoneSlider2.ValueChanged += REyeRot;
                }
            }

            if (LEyelidRotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= LEyelidRot;
                    BoneSlider2.ValueChanged += LEyelidRot;
                }
            }

            if (REyelidRotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= REyelidRot;
                    BoneSlider2.ValueChanged += REyelidRot;
                }
            }

            if (LLowEyelidRotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= LLowEyelidRot;
                    BoneSlider2.ValueChanged += LLowEyelidRot;
                }
            }

            if (RLowEyelidRotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= RLowEyelidRot;
                    BoneSlider2.ValueChanged += RLowEyelidRot;
                }
            }

            if (LEarRotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= LEarRot;
                    BoneSlider2.ValueChanged += LEarRot;
                }
            }

            if (REarRotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= REarRot;
                    BoneSlider2.ValueChanged += REarRot;
                }
            }

            if (LCheekRotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= LCheekRot;
                    BoneSlider2.ValueChanged += LCheekRot;
                }
            }

            if (RCheekRotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= RCheekRot;
                    BoneSlider2.ValueChanged += RCheekRot;
                }
            }

            if (LMouthRotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= LMouthRot;
                    BoneSlider2.ValueChanged += LMouthRot;
                }
            }

            if (RMouthRotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= RMouthRot;
                    BoneSlider2.ValueChanged += RMouthRot;
                }
            }

            if (LUpLipRotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= LUpLipRot;
                    BoneSlider2.ValueChanged += LUpLipRot;
                }
            }

            if (RUpLipRotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= RUpLipRot;
                    BoneSlider2.ValueChanged += RUpLipRot;
                }
            }

            if (LLowLipRotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= LLowLipRot;
                    BoneSlider2.ValueChanged += LLowLipRot;
                }
            }

            if (RLowLipRotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= RLowLipRot;
                    BoneSlider2.ValueChanged += RLowLipRot;
                }
            }

            if (NeckRotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= NeckRot;
                    BoneSlider2.ValueChanged += NeckRot;
                }
            }

            if (SternumRotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= SternumRot;
                    BoneSlider2.ValueChanged += SternumRot;
                }
            }

            if (TorsoRotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= TorsoRot;
                    BoneSlider2.ValueChanged += TorsoRot;
                }
            }

            if (WaistRotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= WaistRot;
                    BoneSlider2.ValueChanged += WaistRot;
                }
            }

            if (LShoulderRotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= LShoulderRot;
                    BoneSlider2.ValueChanged += LShoulderRot;
                }
            }

            if (RShoulderRotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= RShoulderRot;
                    BoneSlider2.ValueChanged += RShoulderRot;
                }
            }

            if (LClavicleRotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= LClavicleRot;
                    BoneSlider2.ValueChanged += LClavicleRot;
                }
            }

            if (RClavicleRotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= RClavicleRot;
                    BoneSlider2.ValueChanged += RClavicleRot;
                }
            }

            if (LBreastRotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= LBreastRot;
                    BoneSlider2.ValueChanged += LBreastRot;
                }
            }

            if (RBreastRotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= RBreastRot;
                    BoneSlider2.ValueChanged += RBreastRot;
                }
            }

            if (LArmRotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= LArmRot;
                    BoneSlider2.ValueChanged += LArmRot;
                }
            }

            if (RArmRotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= RArmRot;
                    BoneSlider2.ValueChanged += RArmRot;
                }
            }

            if (LElbowRotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= LElbowRot;
                    BoneSlider2.ValueChanged += LElbowRot;
                }
            }

            if (RElbowRotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= RElbowRot;
                    BoneSlider2.ValueChanged += RElbowRot;
                }
            }

            if (LForearmRotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= LForearmRot;
                    BoneSlider2.ValueChanged += LForearmRot;
                }
            }

            if (RForearmRotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= RForearmRot;
                    BoneSlider2.ValueChanged += RForearmRot;
                }
            }

            if (LWristRotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= LWristRot;
                    BoneSlider2.ValueChanged += LWristRot;
                }
            }

            if (RWristRotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= RWristRot;
                    BoneSlider2.ValueChanged += RWristRot;
                }
            }

            if (LHandRotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= LHandRot;
                    BoneSlider2.ValueChanged += LHandRot;
                }
            }

            if (RHandRotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= RHandRot;
                    BoneSlider2.ValueChanged += RHandRot;
                }
            }

            if (LThumbRotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= LThumbRot;
                    BoneSlider2.ValueChanged += LThumbRot;
                }
            }

            if (RThumbRotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= RThumbRot;
                    BoneSlider2.ValueChanged += RThumbRot;
                }
            }

            if (LThumb2Rotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= LThumb2Rot;
                    BoneSlider2.ValueChanged += LThumb2Rot;
                }
            }

            if (RThumb2Rotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= RThumb2Rot;
                    BoneSlider2.ValueChanged += RThumb2Rot;
                }
            }

            if (LIndexRotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= LIndexRot;
                    BoneSlider2.ValueChanged += LIndexRot;
                }
            }

            if (RIndexRotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= RIndexRot;
                    BoneSlider2.ValueChanged += RIndexRot;
                }
            }

            if (LIndex2Rotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= LIndex2Rot;
                    BoneSlider2.ValueChanged += LIndex2Rot;
                }
            }

            if (RIndex2Rotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= RIndex2Rot;
                    BoneSlider2.ValueChanged += RIndex2Rot;
                }
            }

            if (LMiddleRotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= LMiddleRot;
                    BoneSlider2.ValueChanged += LMiddleRot;
                }
            }

            if (RMiddleRotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= RMiddleRot;
                    BoneSlider2.ValueChanged += RMiddleRot;
                }
            }

            if (LMiddle2Rotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= LMiddle2Rot;
                    BoneSlider2.ValueChanged += LMiddle2Rot;
                }
            }

            if (RMiddle2Rotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= RMiddle2Rot;
                    BoneSlider2.ValueChanged += RMiddle2Rot;
                }
            }

            if (LRingRotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= LRingRot;
                    BoneSlider2.ValueChanged += LRingRot;
                }
            }

            if (RRingRotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= RRingRot;
                    BoneSlider2.ValueChanged += RRingRot;
                }
            }

            if (LRing2Rotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= LRing2Rot;
                    BoneSlider2.ValueChanged += LRing2Rot;
                }
            }

            if (RRing2Rotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= RRing2Rot;
                    BoneSlider2.ValueChanged += RRing2Rot;
                }
            }

            if (LPinkyRotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= LPinkyRot;
                    BoneSlider2.ValueChanged += LPinkyRot;
                }
            }

            if (RPinkyRotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= RPinkyRot;
                    BoneSlider2.ValueChanged += RPinkyRot;
                }
            }

            if (LPinky2Rotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= LPinky2Rot;
                    BoneSlider2.ValueChanged += LPinky2Rot;
                }
            }

            if (RPinky2Rotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= RPinky2Rot;
                    BoneSlider2.ValueChanged += RPinky2Rot;
                }
            }

            if (PelvisRotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= PelvisRot;
                    BoneSlider2.ValueChanged += PelvisRot;
                }
            }

            if (TailRotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= TailRot;
                    BoneSlider2.ValueChanged += TailRot;
                }
            }

            if (LThighRotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= LThighRot;
                    BoneSlider2.ValueChanged += LThighRot;
                }
            }

            if (RThighRotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= RThighRot;
                    BoneSlider2.ValueChanged += RThighRot;
                }
            }

            if (LKneeRotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= LKneeRot;
                    BoneSlider2.ValueChanged += LKneeRot;
                }
            }

            if (RKneeRotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= RKneeRot;
                    BoneSlider2.ValueChanged += RKneeRot;
                }
            }

            if (LCalfRotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= LCalfRot;
                    BoneSlider2.ValueChanged += LCalfRot;
                }
            }

            if (RCalfRotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= RCalfRot;
                    BoneSlider2.ValueChanged += RCalfRot;
                }
            }

            if (LFootRotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= LFootRot;
                    BoneSlider2.ValueChanged += LFootRot;
                }
            }

            if (RFootRotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= RFootRot;
                    BoneSlider2.ValueChanged += RFootRot;
                }
            }

            if (LToesRotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= LToesRot;
                    BoneSlider2.ValueChanged += LToesRot;
                }
            }

            if (RToesRotate)
            {
                if (BoneSlider2.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider2.ValueChanged -= RToesRot;
                    BoneSlider2.ValueChanged += RToesRot;
                }
            }
        }


        private void BoneSliders3_SourceUpdated(object sender, DataTransferEventArgs e)
        {
            if (HeadRotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= HeadRot;
                    BoneSlider3.ValueChanged += HeadRot;
                }
            }

            if (NoseRotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= NoseRot;
                    BoneSlider3.ValueChanged += NoseRot;
                }
            }

            if (NostrilsRotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= NostrilsRot;
                    BoneSlider3.ValueChanged += NostrilsRot;
                }
            }

            if (ChinRotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= ChinRot;
                    BoneSlider3.ValueChanged += ChinRot;
                }
            }

            if (LOutEyebrowRotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= LOutEyebrowRot;
                    BoneSlider3.ValueChanged += LOutEyebrowRot;
                }
            }

            if (ROutEyebrowRotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= ROutEyebrowRot;
                    BoneSlider3.ValueChanged += ROutEyebrowRot;
                }
            }

            if (LInEyebrowRotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= LInEyebrowRot;
                    BoneSlider3.ValueChanged += LInEyebrowRot;
                }
            }

            if (RInEyebrowRotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= RInEyebrowRot;
                    BoneSlider3.ValueChanged += RInEyebrowRot;
                }
            }

            if (LEyeRotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= LEyeRot;
                    BoneSlider3.ValueChanged += LEyeRot;
                }
            }

            if (REyeRotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= REyeRot;
                    BoneSlider3.ValueChanged += REyeRot;
                }
            }

            if (LEyelidRotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= LEyelidRot;
                    BoneSlider3.ValueChanged += LEyelidRot;
                }
            }

            if (REyelidRotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= REyelidRot;
                    BoneSlider3.ValueChanged += REyelidRot;
                }
            }

            if (LLowEyelidRotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= LLowEyelidRot;
                    BoneSlider3.ValueChanged += LLowEyelidRot;
                }
            }

            if (RLowEyelidRotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= RLowEyelidRot;
                    BoneSlider3.ValueChanged += RLowEyelidRot;
                }
            }

            if (LEarRotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= LEarRot;
                    BoneSlider3.ValueChanged += LEarRot;
                }
            }

            if (REarRotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= REarRot;
                    BoneSlider3.ValueChanged += REarRot;
                }
            }

            if (LCheekRotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= LCheekRot;
                    BoneSlider3.ValueChanged += LCheekRot;
                }
            }

            if (RCheekRotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= RCheekRot;
                    BoneSlider3.ValueChanged += RCheekRot;
                }
            }

            if (LMouthRotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= LMouthRot;
                    BoneSlider3.ValueChanged += LMouthRot;
                }
            }

            if (RMouthRotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= RMouthRot;
                    BoneSlider3.ValueChanged += RMouthRot;
                }
            }

            if (LUpLipRotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= LUpLipRot;
                    BoneSlider3.ValueChanged += LUpLipRot;
                }
            }

            if (RUpLipRotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= RUpLipRot;
                    BoneSlider3.ValueChanged += RUpLipRot;
                }
            }

            if (LLowLipRotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= LLowLipRot;
                    BoneSlider3.ValueChanged += LLowLipRot;
                }
            }

            if (RLowLipRotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= RLowLipRot;
                    BoneSlider3.ValueChanged += RLowLipRot;
                }
            }

            if (NeckRotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= NeckRot;
                    BoneSlider3.ValueChanged += NeckRot;
                }
            }

            if (SternumRotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= SternumRot;
                    BoneSlider3.ValueChanged += SternumRot;
                }
            }

            if (TorsoRotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= TorsoRot;
                    BoneSlider3.ValueChanged += TorsoRot;
                }
            }

            if (WaistRotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= WaistRot;
                    BoneSlider3.ValueChanged += WaistRot;
                }
            }

            if (LShoulderRotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= LShoulderRot;
                    BoneSlider3.ValueChanged += LShoulderRot;
                }
            }

            if (RShoulderRotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= RShoulderRot;
                    BoneSlider3.ValueChanged += RShoulderRot;
                }
            }

            if (LClavicleRotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= LClavicleRot;
                    BoneSlider3.ValueChanged += LClavicleRot;
                }
            }

            if (RClavicleRotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= RClavicleRot;
                    BoneSlider3.ValueChanged += RClavicleRot;
                }
            }

            if (LBreastRotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= LBreastRot;
                    BoneSlider3.ValueChanged += LBreastRot;
                }
            }

            if (RBreastRotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= RBreastRot;
                    BoneSlider3.ValueChanged += RBreastRot;
                }
            }

            if (LArmRotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= LArmRot;
                    BoneSlider3.ValueChanged += LArmRot;
                }
            }

            if (RArmRotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= RArmRot;
                    BoneSlider3.ValueChanged += RArmRot;
                }
            }

            if (LElbowRotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= LElbowRot;
                    BoneSlider3.ValueChanged += LElbowRot;
                }
            }

            if (RElbowRotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= RElbowRot;
                    BoneSlider3.ValueChanged += RElbowRot;
                }
            }

            if (LForearmRotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= LForearmRot;
                    BoneSlider3.ValueChanged += LForearmRot;
                }
            }

            if (RForearmRotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= RForearmRot;
                    BoneSlider3.ValueChanged += RForearmRot;
                }
            }

            if (LWristRotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= LWristRot;
                    BoneSlider3.ValueChanged += LWristRot;
                }
            }

            if (RWristRotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= RWristRot;
                    BoneSlider3.ValueChanged += RWristRot;
                }
            }

            if (LHandRotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= LHandRot;
                    BoneSlider3.ValueChanged += LHandRot;
                }
            }

            if (RHandRotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= RHandRot;
                    BoneSlider3.ValueChanged += RHandRot;
                }
            }

            if (LThumbRotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= LThumbRot;
                    BoneSlider3.ValueChanged += LThumbRot;
                }
            }

            if (RThumbRotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= RThumbRot;
                    BoneSlider3.ValueChanged += RThumbRot;
                }
            }

            if (LThumb2Rotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= LThumb2Rot;
                    BoneSlider3.ValueChanged += LThumb2Rot;
                }
            }

            if (RThumb2Rotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= RThumb2Rot;
                    BoneSlider3.ValueChanged += RThumb2Rot;
                }
            }

            if (LIndexRotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= LIndexRot;
                    BoneSlider3.ValueChanged += LIndexRot;
                }
            }

            if (RIndexRotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= RIndexRot;
                    BoneSlider3.ValueChanged += RIndexRot;
                }
            }

            if (LIndex2Rotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= LIndex2Rot;
                    BoneSlider3.ValueChanged += LIndex2Rot;
                }
            }

            if (RIndex2Rotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= RIndex2Rot;
                    BoneSlider3.ValueChanged += RIndex2Rot;
                }
            }

            if (LMiddleRotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= LMiddleRot;
                    BoneSlider3.ValueChanged += LMiddleRot;
                }
            }

            if (RMiddleRotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= RMiddleRot;
                    BoneSlider3.ValueChanged += RMiddleRot;
                }
            }

            if (LMiddle2Rotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= LMiddle2Rot;
                    BoneSlider3.ValueChanged += LMiddle2Rot;
                }
            }

            if (RMiddle2Rotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= RMiddle2Rot;
                    BoneSlider3.ValueChanged += RMiddle2Rot;
                }
            }

            if (LRingRotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= LRingRot;
                    BoneSlider3.ValueChanged += LRingRot;
                }
            }

            if (RRingRotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= RRingRot;
                    BoneSlider3.ValueChanged += RRingRot;
                }
            }

            if (LRing2Rotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= LRing2Rot;
                    BoneSlider3.ValueChanged += LRing2Rot;
                }
            }

            if (RRing2Rotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= RRing2Rot;
                    BoneSlider3.ValueChanged += RRing2Rot;
                }
            }

            if (LPinkyRotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= LPinkyRot;
                    BoneSlider3.ValueChanged += LPinkyRot;
                }
            }

            if (RPinkyRotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= RPinkyRot;
                    BoneSlider3.ValueChanged += RPinkyRot;
                }
            }

            if (LPinky2Rotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= LPinky2Rot;
                    BoneSlider3.ValueChanged += LPinky2Rot;
                }
            }

            if (RPinky2Rotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= RPinky2Rot;
                    BoneSlider3.ValueChanged += RPinky2Rot;
                }
            }

            if (PelvisRotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= PelvisRot;
                    BoneSlider3.ValueChanged += PelvisRot;
                }
            }

            if (TailRotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= TailRot;
                    BoneSlider3.ValueChanged += TailRot;
                }
            }

            if (LThighRotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= LThighRot;
                    BoneSlider3.ValueChanged += LThighRot;
                }
            }

            if (RThighRotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= RThighRot;
                    BoneSlider3.ValueChanged += RThighRot;
                }
            }

            if (LKneeRotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= LKneeRot;
                    BoneSlider3.ValueChanged += LKneeRot;
                }
            }

            if (RKneeRotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= RKneeRot;
                    BoneSlider3.ValueChanged += RKneeRot;
                }
            }

            if (LCalfRotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= LCalfRot;
                    BoneSlider3.ValueChanged += LCalfRot;
                }
            }

            if (RCalfRotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= RCalfRot;
                    BoneSlider3.ValueChanged += RCalfRot;
                }
            }

            if (LFootRotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= LFootRot;
                    BoneSlider3.ValueChanged += LFootRot;
                }
            }

            if (RFootRotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= RFootRot;
                    BoneSlider3.ValueChanged += RFootRot;
                }
            }

            if (LToesRotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= LToesRot;
                    BoneSlider3.ValueChanged += LToesRot;
                }
            }

            if (RToesRotate)
            {
                if (BoneSlider3.IsKeyboardFocusWithin || BoneSlider.IsMouseOver)
                {
                    BoneSlider3.ValueChanged -= RToesRot;
                    BoneSlider3.ValueChanged += RToesRot;
                }
            }
        }

        #endregion

        #region UpDowns
        private void BoneUpDown_SourceUpdated(object sender, DataTransferEventArgs e)
        {
            if (HeadRotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= HeadRot2;
                    BoneUpDown.ValueChanged += HeadRot2;
                }
            }

            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= NoseRot2;
                    BoneUpDown.ValueChanged += NoseRot2;
                }
            }

            if (NostrilsRotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= NostrilsRot2;
                    BoneUpDown.ValueChanged += NostrilsRot2;
                }
            }

            if (ChinRotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= ChinRot2;
                    BoneUpDown.ValueChanged += ChinRot2;
                }
            }

            if (LOutEyebrowRotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= LOutEyebrowRot2;
                    BoneUpDown.ValueChanged += LOutEyebrowRot2;
                }
            }

            if (ROutEyebrowRotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= ROutEyebrowRot2;
                    BoneUpDown.ValueChanged += ROutEyebrowRot2;
                }
            }

            if (LInEyebrowRotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= LInEyebrowRot2;
                    BoneUpDown.ValueChanged += LInEyebrowRot2;
                }
            }

            if (RInEyebrowRotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= RInEyebrowRot2;
                    BoneUpDown.ValueChanged += RInEyebrowRot2;
                }
            }

            if (LEyeRotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= LEyeRot2;
                    BoneUpDown.ValueChanged += LEyeRot2;
                }
            }

            if (REyeRotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= REyeRot2;
                    BoneUpDown.ValueChanged += REyeRot2;
                }
            }

            if (LEyelidRotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= LEyelidRot2;
                    BoneUpDown.ValueChanged += LEyelidRot2;
                }
            }

            if (REyelidRotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= REyelidRot2;
                    BoneUpDown.ValueChanged += REyelidRot2;
                }
            }

            if (LLowEyelidRotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= LLowEyelidRot2;
                    BoneUpDown.ValueChanged += LLowEyelidRot2;
                }
            }

            if (RLowEyelidRotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= RLowEyelidRot2;
                    BoneUpDown.ValueChanged += RLowEyelidRot2;
                }
            }

            if (LEarRotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= LEarRot2;
                    BoneUpDown.ValueChanged += LEarRot2;
                }
            }

            if (REarRotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= REarRot2;
                    BoneUpDown.ValueChanged += REarRot2;
                }
            }

            if (LCheekRotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= LCheekRot2;
                    BoneUpDown.ValueChanged += LCheekRot2;
                }
            }

            if (RCheekRotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= RCheekRot2;
                    BoneUpDown.ValueChanged += RCheekRot2;
                }
            }

            if (LMouthRotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= LMouthRot2;
                    BoneUpDown.ValueChanged += LMouthRot2;
                }
            }

            if (RMouthRotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= RMouthRot2;
                    BoneUpDown.ValueChanged += RMouthRot2;
                }
            }

            if (LUpLipRotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= LUpLipRot2;
                    BoneUpDown.ValueChanged += LUpLipRot2;
                }
            }

            if (RUpLipRotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= RUpLipRot2;
                    BoneUpDown.ValueChanged += RUpLipRot2;
                }
            }

            if (LLowLipRotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= LLowLipRot2;
                    BoneUpDown.ValueChanged += LLowLipRot2;
                }
            }

            if (RLowLipRotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= RLowLipRot2;
                    BoneUpDown.ValueChanged += RLowLipRot2;
                }
            }

            if (NeckRotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= NeckRot2;
                    BoneUpDown.ValueChanged += NeckRot2;
                }
            }

            if (SternumRotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= SternumRot2;
                    BoneUpDown.ValueChanged += SternumRot2;
                }
            }

            if (TorsoRotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= TorsoRot2;
                    BoneUpDown.ValueChanged += TorsoRot2;
                }
            }

            if (WaistRotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= WaistRot2;
                    BoneUpDown.ValueChanged += WaistRot2;
                }
            }

            if (LShoulderRotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= LShoulderRot2;
                    BoneUpDown.ValueChanged += LShoulderRot2;
                }
            }

            if (RShoulderRotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= RShoulderRot2;
                    BoneUpDown.ValueChanged += RShoulderRot2;
                }
            }

            if (LClavicleRotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= LClavicleRot2;
                    BoneUpDown.ValueChanged += LClavicleRot2;
                }
            }

            if (RClavicleRotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= RClavicleRot2;
                    BoneUpDown.ValueChanged += RClavicleRot2;
                }
            }

            if (LBreastRotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= LBreastRot2;
                    BoneUpDown.ValueChanged += LBreastRot2;
                }
            }

            if (RBreastRotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= RBreastRot2;
                    BoneUpDown.ValueChanged += RBreastRot2;
                }
            }

            if (LArmRotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= LArmRot2;
                    BoneUpDown.ValueChanged += LArmRot2;
                }
            }

            if (RArmRotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= RArmRot2;
                    BoneUpDown.ValueChanged += RArmRot2;
                }
            }

            if (LElbowRotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= LElbowRot2;
                    BoneUpDown.ValueChanged += LElbowRot2;
                }
            }

            if (RElbowRotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= RElbowRot2;
                    BoneUpDown.ValueChanged += RElbowRot2;
                }
            }

            if (LForearmRotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= LForearmRot2;
                    BoneUpDown.ValueChanged += LForearmRot2;
                }
            }

            if (RForearmRotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= RForearmRot2;
                    BoneUpDown.ValueChanged += RForearmRot2;
                }
            }

            if (LWristRotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= LWristRot2;
                    BoneUpDown.ValueChanged += LWristRot2;
                }
            }

            if (RWristRotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= RWristRot2;
                    BoneUpDown.ValueChanged += RWristRot2;
                }
            }

            if (LHandRotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= LHandRot2;
                    BoneUpDown.ValueChanged += LHandRot2;
                }
            }

            if (RHandRotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= RHandRot2;
                    BoneUpDown.ValueChanged += RHandRot2;
                }
            }

            if (LThumbRotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= LThumbRot2;
                    BoneUpDown.ValueChanged += LThumbRot2;
                }
            }

            if (RThumbRotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= RThumbRot2;
                    BoneUpDown.ValueChanged += RThumbRot2;
                }
            }

            if (LThumb2Rotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= LThumb2Rot2;
                    BoneUpDown.ValueChanged += LThumb2Rot2;
                }
            }

            if (RThumb2Rotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= RThumb2Rot2;
                    BoneUpDown.ValueChanged += RThumb2Rot2;
                }
            }

            if (LIndexRotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= LIndexRot2;
                    BoneUpDown.ValueChanged += LIndexRot2;
                }
            }

            if (RIndexRotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= RIndexRot2;
                    BoneUpDown.ValueChanged += RIndexRot2;
                }
            }

            if (LIndex2Rotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= LIndex2Rot2;
                    BoneUpDown.ValueChanged += LIndex2Rot2;
                }
            }

            if (RIndex2Rotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= RIndex2Rot2;
                    BoneUpDown.ValueChanged += RIndex2Rot2;
                }
            }

            if (LMiddleRotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= LMiddleRot2;
                    BoneUpDown.ValueChanged += LMiddleRot2;
                }
            }

            if (RMiddleRotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= RMiddleRot2;
                    BoneUpDown.ValueChanged += RMiddleRot2;
                }
            }

            if (LMiddle2Rotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= LMiddle2Rot2;
                    BoneUpDown.ValueChanged += LMiddle2Rot2;
                }
            }

            if (RMiddle2Rotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= RMiddle2Rot2;
                    BoneUpDown.ValueChanged += RMiddle2Rot2;
                }
            }

            if (LRingRotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= LRingRot2;
                    BoneUpDown.ValueChanged += LRingRot2;
                }
            }

            if (RRingRotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= RRingRot2;
                    BoneUpDown.ValueChanged += RRingRot2;
                }
            }

            if (LRing2Rotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= LRing2Rot2;
                    BoneUpDown.ValueChanged += LRing2Rot2;
                }
            }

            if (RRing2Rotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= RRing2Rot2;
                    BoneUpDown.ValueChanged += RRing2Rot2;
                }
            }

            if (LPinkyRotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= LPinkyRot2;
                    BoneUpDown.ValueChanged += LPinkyRot2;
                }
            }

            if (RPinkyRotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= RPinkyRot2;
                    BoneUpDown.ValueChanged += RPinkyRot2;
                }
            }

            if (LPinky2Rotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= LPinky2Rot2;
                    BoneUpDown.ValueChanged += LPinky2Rot2;
                }
            }

            if (RPinky2Rotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= RPinky2Rot2;
                    BoneUpDown.ValueChanged += RPinky2Rot2;
                }
            }

            if (PelvisRotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= PelvisRot2;
                    BoneUpDown.ValueChanged += PelvisRot2;
                }
            }

            if (TailRotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= TailRot2;
                    BoneUpDown.ValueChanged += TailRot2;
                }
            }

            if (LThighRotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= LThighRot2;
                    BoneUpDown.ValueChanged += LThighRot2;
                }
            }

            if (RThighRotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= RThighRot2;
                    BoneUpDown.ValueChanged += RThighRot2;
                }
            }

            if (LKneeRotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= LKneeRot2;
                    BoneUpDown.ValueChanged += LKneeRot2;
                }
            }

            if (RKneeRotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= RKneeRot2;
                    BoneUpDown.ValueChanged += RKneeRot2;
                }
            }

            if (LCalfRotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= LCalfRot2;
                    BoneUpDown.ValueChanged += LCalfRot2;
                }
            }

            if (RCalfRotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= RCalfRot2;
                    BoneUpDown.ValueChanged += RCalfRot2;
                }
            }

            if (LFootRotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= LFootRot2;
                    BoneUpDown.ValueChanged += LFootRot2;
                }
            }

            if (RFootRotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= RFootRot2;
                    BoneUpDown.ValueChanged += RFootRot2;
                }
            }

            if (LToesRotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= LToesRot2;
                    BoneUpDown.ValueChanged += LToesRot2;
                }
            }

            if (RToesRotate)
            {
                if (BoneUpDown.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown.ValueChanged -= RToesRot2;
                    BoneUpDown.ValueChanged += RToesRot2;
                }
            }
        }


        private void BoneUpDown2_SourceUpdated(object sender, DataTransferEventArgs e)
        {
            if (HeadRotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= HeadRot2;
                    BoneUpDown2.ValueChanged += HeadRot2;
                }
            }

            if (NoseRotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= NoseRot2;
                    BoneUpDown2.ValueChanged += NoseRot2;
                }
            }

            if (NostrilsRotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= NostrilsRot2;
                    BoneUpDown2.ValueChanged += NostrilsRot2;
                }
            }

            if (ChinRotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= ChinRot2;
                    BoneUpDown2.ValueChanged += ChinRot2;
                }
            }

            if (LOutEyebrowRotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= LOutEyebrowRot2;
                    BoneUpDown2.ValueChanged += LOutEyebrowRot2;
                }
            }

            if (ROutEyebrowRotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= ROutEyebrowRot2;
                    BoneUpDown2.ValueChanged += ROutEyebrowRot2;
                }
            }

            if (LInEyebrowRotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= LInEyebrowRot2;
                    BoneUpDown2.ValueChanged += LInEyebrowRot2;
                }
            }

            if (RInEyebrowRotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= RInEyebrowRot2;
                    BoneUpDown2.ValueChanged += RInEyebrowRot2;
                }
            }

            if (LEyeRotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= LEyeRot2;
                    BoneUpDown2.ValueChanged += LEyeRot2;
                }
            }

            if (REyeRotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= REyeRot2;
                    BoneUpDown2.ValueChanged += REyeRot2;
                }
            }

            if (LEyelidRotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= LEyelidRot2;
                    BoneUpDown2.ValueChanged += LEyelidRot2;
                }
            }

            if (REyelidRotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= REyelidRot2;
                    BoneUpDown2.ValueChanged += REyelidRot2;
                }
            }

            if (LLowEyelidRotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= LLowEyelidRot2;
                    BoneUpDown2.ValueChanged += LLowEyelidRot2;
                }
            }

            if (RLowEyelidRotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= RLowEyelidRot2;
                    BoneUpDown2.ValueChanged += RLowEyelidRot2;
                }
            }

            if (LEarRotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= LEarRot2;
                    BoneUpDown2.ValueChanged += LEarRot2;
                }
            }

            if (REarRotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= REarRot2;
                    BoneUpDown2.ValueChanged += REarRot2;
                }
            }

            if (LCheekRotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= LCheekRot2;
                    BoneUpDown2.ValueChanged += LCheekRot2;
                }
            }

            if (RCheekRotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= RCheekRot2;
                    BoneUpDown2.ValueChanged += RCheekRot2;
                }
            }

            if (LMouthRotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= LMouthRot2;
                    BoneUpDown2.ValueChanged += LMouthRot2;
                }
            }

            if (RMouthRotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= RMouthRot2;
                    BoneUpDown2.ValueChanged += RMouthRot2;
                }
            }

            if (LUpLipRotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= LUpLipRot2;
                    BoneUpDown2.ValueChanged += LUpLipRot2;
                }
            }

            if (RUpLipRotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= RUpLipRot2;
                    BoneUpDown2.ValueChanged += RUpLipRot2;
                }
            }

            if (LLowLipRotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= LLowLipRot2;
                    BoneUpDown2.ValueChanged += LLowLipRot2;
                }
            }

            if (RLowLipRotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= RLowLipRot2;
                    BoneUpDown2.ValueChanged += RLowLipRot2;
                }
            }

            if (NeckRotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= NeckRot2;
                    BoneUpDown2.ValueChanged += NeckRot2;
                }
            }

            if (SternumRotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= SternumRot2;
                    BoneUpDown2.ValueChanged += SternumRot2;
                }
            }

            if (TorsoRotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= TorsoRot2;
                    BoneUpDown2.ValueChanged += TorsoRot2;
                }
            }

            if (WaistRotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= WaistRot2;
                    BoneUpDown2.ValueChanged += WaistRot2;
                }
            }

            if (LShoulderRotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= LShoulderRot2;
                    BoneUpDown2.ValueChanged += LShoulderRot2;
                }
            }

            if (RShoulderRotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= RShoulderRot2;
                    BoneUpDown2.ValueChanged += RShoulderRot2;
                }
            }

            if (LClavicleRotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= LClavicleRot2;
                    BoneUpDown2.ValueChanged += LClavicleRot2;
                }
            }

            if (RClavicleRotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= RClavicleRot2;
                    BoneUpDown2.ValueChanged += RClavicleRot2;
                }
            }

            if (LBreastRotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= LBreastRot2;
                    BoneUpDown2.ValueChanged += LBreastRot2;
                }
            }

            if (RBreastRotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= RBreastRot2;
                    BoneUpDown2.ValueChanged += RBreastRot2;
                }
            }

            if (LArmRotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= LArmRot2;
                    BoneUpDown2.ValueChanged += LArmRot2;
                }
            }

            if (RArmRotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= RArmRot2;
                    BoneUpDown2.ValueChanged += RArmRot2;
                }
            }

            if (LElbowRotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= LElbowRot2;
                    BoneUpDown2.ValueChanged += LElbowRot2;
                }
            }

            if (RElbowRotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= RElbowRot2;
                    BoneUpDown2.ValueChanged += RElbowRot2;
                }
            }

            if (LForearmRotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= LForearmRot2;
                    BoneUpDown2.ValueChanged += LForearmRot2;
                }
            }

            if (RForearmRotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= RForearmRot2;
                    BoneUpDown2.ValueChanged += RForearmRot2;
                }
            }

            if (LWristRotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= LWristRot2;
                    BoneUpDown2.ValueChanged += LWristRot2;
                }
            }

            if (RWristRotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= RWristRot2;
                    BoneUpDown2.ValueChanged += RWristRot2;
                }
            }

            if (LHandRotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= LHandRot2;
                    BoneUpDown2.ValueChanged += LHandRot2;
                }
            }

            if (RHandRotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= RHandRot2;
                    BoneUpDown2.ValueChanged += RHandRot2;
                }
            }

            if (LThumbRotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= LThumbRot2;
                    BoneUpDown2.ValueChanged += LThumbRot2;
                }
            }

            if (RThumbRotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= RThumbRot2;
                    BoneUpDown2.ValueChanged += RThumbRot2;
                }
            }

            if (LThumb2Rotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= LThumb2Rot2;
                    BoneUpDown2.ValueChanged += LThumb2Rot2;
                }
            }

            if (RThumb2Rotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= RThumb2Rot2;
                    BoneUpDown2.ValueChanged += RThumb2Rot2;
                }
            }

            if (LIndexRotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= LIndexRot2;
                    BoneUpDown2.ValueChanged += LIndexRot2;
                }
            }

            if (RIndexRotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= RIndexRot2;
                    BoneUpDown2.ValueChanged += RIndexRot2;
                }
            }

            if (LIndex2Rotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= LIndex2Rot2;
                    BoneUpDown2.ValueChanged += LIndex2Rot2;
                }
            }

            if (RIndex2Rotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= RIndex2Rot2;
                    BoneUpDown2.ValueChanged += RIndex2Rot2;
                }
            }

            if (LMiddleRotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= LMiddleRot2;
                    BoneUpDown2.ValueChanged += LMiddleRot2;
                }
            }

            if (RMiddleRotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= RMiddleRot2;
                    BoneUpDown2.ValueChanged += RMiddleRot2;
                }
            }

            if (LMiddle2Rotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= LMiddle2Rot2;
                    BoneUpDown2.ValueChanged += LMiddle2Rot2;
                }
            }

            if (RMiddle2Rotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= RMiddle2Rot2;
                    BoneUpDown2.ValueChanged += RMiddle2Rot2;
                }
            }

            if (LRingRotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= LRingRot2;
                    BoneUpDown2.ValueChanged += LRingRot2;
                }
            }

            if (RRingRotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= RRingRot2;
                    BoneUpDown2.ValueChanged += RRingRot2;
                }
            }

            if (LRing2Rotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= LRing2Rot2;
                    BoneUpDown2.ValueChanged += LRing2Rot2;
                }
            }

            if (RRing2Rotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= RRing2Rot2;
                    BoneUpDown2.ValueChanged += RRing2Rot2;
                }
            }

            if (LPinkyRotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= LPinkyRot2;
                    BoneUpDown2.ValueChanged += LPinkyRot2;
                }
            }

            if (RPinkyRotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= RPinkyRot2;
                    BoneUpDown2.ValueChanged += RPinkyRot2;
                }
            }

            if (LPinky2Rotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= LPinky2Rot2;
                    BoneUpDown2.ValueChanged += LPinky2Rot2;
                }
            }

            if (RPinky2Rotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= RPinky2Rot2;
                    BoneUpDown2.ValueChanged += RPinky2Rot2;
                }
            }

            if (PelvisRotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= PelvisRot2;
                    BoneUpDown2.ValueChanged += PelvisRot2;
                }
            }

            if (TailRotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= TailRot2;
                    BoneUpDown2.ValueChanged += TailRot2;
                }
            }

            if (LThighRotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= LThighRot2;
                    BoneUpDown2.ValueChanged += LThighRot2;
                }
            }

            if (RThighRotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= RThighRot2;
                    BoneUpDown2.ValueChanged += RThighRot2;
                }
            }

            if (LKneeRotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= LKneeRot2;
                    BoneUpDown2.ValueChanged += LKneeRot2;
                }
            }

            if (RKneeRotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= RKneeRot2;
                    BoneUpDown2.ValueChanged += RKneeRot2;
                }
            }

            if (LCalfRotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= LCalfRot2;
                    BoneUpDown2.ValueChanged += LCalfRot2;
                }
            }

            if (RCalfRotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= RCalfRot2;
                    BoneUpDown2.ValueChanged += RCalfRot2;
                }
            }

            if (LFootRotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= LFootRot2;
                    BoneUpDown2.ValueChanged += LFootRot2;
                }
            }

            if (RFootRotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= RFootRot2;
                    BoneUpDown2.ValueChanged += RFootRot2;
                }
            }

            if (LToesRotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= LToesRot2;
                    BoneUpDown2.ValueChanged += LToesRot2;
                }
            }

            if (RToesRotate)
            {
                if (BoneUpDown2.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown2.ValueChanged -= RToesRot2;
                    BoneUpDown2.ValueChanged += RToesRot2;
                }
            }
        }


        private void BoneUpDown3_SourceUpdated(object sender, DataTransferEventArgs e)
        {
            if (HeadRotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= HeadRot2;
                    BoneUpDown3.ValueChanged += HeadRot2;
                }
            }

            if (NoseRotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= NoseRot2;
                    BoneUpDown3.ValueChanged += NoseRot2;
                }
            }

            if (NostrilsRotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= NostrilsRot2;
                    BoneUpDown3.ValueChanged += NostrilsRot2;
                }
            }

            if (ChinRotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= ChinRot2;
                    BoneUpDown3.ValueChanged += ChinRot2;
                }
            }

            if (LOutEyebrowRotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= LOutEyebrowRot2;
                    BoneUpDown3.ValueChanged += LOutEyebrowRot2;
                }
            }

            if (ROutEyebrowRotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= ROutEyebrowRot2;
                    BoneUpDown3.ValueChanged += ROutEyebrowRot2;
                }
            }

            if (LInEyebrowRotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= LInEyebrowRot2;
                    BoneUpDown3.ValueChanged += LInEyebrowRot2;
                }
            }

            if (RInEyebrowRotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= RInEyebrowRot2;
                    BoneUpDown3.ValueChanged += RInEyebrowRot2;
                }
            }

            if (LEyeRotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= LEyeRot2;
                    BoneUpDown3.ValueChanged += LEyeRot2;
                }
            }

            if (REyeRotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= REyeRot2;
                    BoneUpDown3.ValueChanged += REyeRot2;
                }
            }

            if (LEyelidRotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= LEyelidRot2;
                    BoneUpDown3.ValueChanged += LEyelidRot2;
                }
            }

            if (REyelidRotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= REyelidRot2;
                    BoneUpDown3.ValueChanged += REyelidRot2;
                }
            }

            if (LLowEyelidRotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= LLowEyelidRot2;
                    BoneUpDown3.ValueChanged += LLowEyelidRot2;
                }
            }

            if (RLowEyelidRotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= RLowEyelidRot2;
                    BoneUpDown3.ValueChanged += RLowEyelidRot2;
                }
            }

            if (LEarRotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= LEarRot2;
                    BoneUpDown3.ValueChanged += LEarRot2;
                }
            }

            if (REarRotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= REarRot2;
                    BoneUpDown3.ValueChanged += REarRot2;
                }
            }

            if (LCheekRotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= LCheekRot2;
                    BoneUpDown3.ValueChanged += LCheekRot2;
                }
            }

            if (RCheekRotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= RCheekRot2;
                    BoneUpDown3.ValueChanged += RCheekRot2;
                }
            }

            if (LMouthRotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= LMouthRot2;
                    BoneUpDown3.ValueChanged += LMouthRot2;
                }
            }

            if (RMouthRotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= RMouthRot2;
                    BoneUpDown3.ValueChanged += RMouthRot2;
                }
            }

            if (LUpLipRotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= LUpLipRot2;
                    BoneUpDown3.ValueChanged += LUpLipRot2;
                }
            }

            if (RUpLipRotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= RUpLipRot2;
                    BoneUpDown3.ValueChanged += RUpLipRot2;
                }
            }

            if (LLowLipRotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= LLowLipRot2;
                    BoneUpDown3.ValueChanged += LLowLipRot2;
                }
            }

            if (RLowLipRotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= RLowLipRot2;
                    BoneUpDown3.ValueChanged += RLowLipRot2;
                }
            }

            if (NeckRotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= NeckRot2;
                    BoneUpDown3.ValueChanged += NeckRot2;
                }
            }

            if (SternumRotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= SternumRot2;
                    BoneUpDown3.ValueChanged += SternumRot2;
                }
            }

            if (TorsoRotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= TorsoRot2;
                    BoneUpDown3.ValueChanged += TorsoRot2;
                }
            }

            if (WaistRotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= WaistRot2;
                    BoneUpDown3.ValueChanged += WaistRot2;
                }
            }

            if (LShoulderRotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= LShoulderRot2;
                    BoneUpDown3.ValueChanged += LShoulderRot2;
                }
            }

            if (RShoulderRotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= RShoulderRot2;
                    BoneUpDown3.ValueChanged += RShoulderRot2;
                }
            }

            if (LClavicleRotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= LClavicleRot2;
                    BoneUpDown3.ValueChanged += LClavicleRot2;
                }
            }

            if (RClavicleRotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= RClavicleRot2;
                    BoneUpDown3.ValueChanged += RClavicleRot2;
                }
            }

            if (LBreastRotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= LBreastRot2;
                    BoneUpDown3.ValueChanged += LBreastRot2;
                }
            }

            if (RBreastRotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= RBreastRot2;
                    BoneUpDown3.ValueChanged += RBreastRot2;
                }
            }

            if (LArmRotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= LArmRot2;
                    BoneUpDown3.ValueChanged += LArmRot2;
                }
            }

            if (RArmRotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= RArmRot2;
                    BoneUpDown3.ValueChanged += RArmRot2;
                }
            }

            if (LElbowRotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= LElbowRot2;
                    BoneUpDown3.ValueChanged += LElbowRot2;
                }
            }

            if (RElbowRotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= RElbowRot2;
                    BoneUpDown3.ValueChanged += RElbowRot2;
                }
            }

            if (LForearmRotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= LForearmRot2;
                    BoneUpDown3.ValueChanged += LForearmRot2;
                }
            }

            if (RForearmRotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= RForearmRot2;
                    BoneUpDown3.ValueChanged += RForearmRot2;
                }
            }

            if (LWristRotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= LWristRot2;
                    BoneUpDown3.ValueChanged += LWristRot2;
                }
            }

            if (RWristRotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= RWristRot2;
                    BoneUpDown3.ValueChanged += RWristRot2;
                }
            }

            if (LHandRotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= LHandRot2;
                    BoneUpDown3.ValueChanged += LHandRot2;
                }
            }

            if (RHandRotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= RHandRot2;
                    BoneUpDown3.ValueChanged += RHandRot2;
                }
            }

            if (LThumbRotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= LThumbRot2;
                    BoneUpDown3.ValueChanged += LThumbRot2;
                }
            }

            if (RThumbRotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= RThumbRot2;
                    BoneUpDown3.ValueChanged += RThumbRot2;
                }
            }

            if (LThumb2Rotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= LThumb2Rot2;
                    BoneUpDown3.ValueChanged += LThumb2Rot2;
                }
            }

            if (RThumb2Rotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= RThumb2Rot2;
                    BoneUpDown3.ValueChanged += RThumb2Rot2;
                }
            }

            if (LIndexRotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= LIndexRot2;
                    BoneUpDown3.ValueChanged += LIndexRot2;
                }
            }

            if (RIndexRotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= RIndexRot2;
                    BoneUpDown3.ValueChanged += RIndexRot2;
                }
            }

            if (LIndex2Rotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= LIndex2Rot2;
                    BoneUpDown3.ValueChanged += LIndex2Rot2;
                }
            }

            if (RIndex2Rotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= RIndex2Rot2;
                    BoneUpDown3.ValueChanged += RIndex2Rot2;
                }
            }

            if (LMiddleRotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= LMiddleRot2;
                    BoneUpDown3.ValueChanged += LMiddleRot2;
                }
            }

            if (RMiddleRotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= RMiddleRot2;
                    BoneUpDown3.ValueChanged += RMiddleRot2;
                }
            }

            if (LMiddle2Rotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= LMiddle2Rot2;
                    BoneUpDown3.ValueChanged += LMiddle2Rot2;
                }
            }

            if (RMiddle2Rotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= RMiddle2Rot2;
                    BoneUpDown3.ValueChanged += RMiddle2Rot2;
                }
            }

            if (LRingRotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= LRingRot2;
                    BoneUpDown3.ValueChanged += LRingRot2;
                }
            }

            if (RRingRotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= RRingRot2;
                    BoneUpDown3.ValueChanged += RRingRot2;
                }
            }

            if (LRing2Rotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= LRing2Rot2;
                    BoneUpDown3.ValueChanged += LRing2Rot2;
                }
            }

            if (RRing2Rotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= RRing2Rot2;
                    BoneUpDown3.ValueChanged += RRing2Rot2;
                }
            }

            if (LPinkyRotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= LPinkyRot2;
                    BoneUpDown3.ValueChanged += LPinkyRot2;
                }
            }

            if (RPinkyRotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= RPinkyRot2;
                    BoneUpDown3.ValueChanged += RPinkyRot2;
                }
            }

            if (LPinky2Rotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= LPinky2Rot2;
                    BoneUpDown3.ValueChanged += LPinky2Rot2;
                }
            }

            if (RPinky2Rotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= RPinky2Rot2;
                    BoneUpDown3.ValueChanged += RPinky2Rot2;
                }
            }

            if (PelvisRotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= PelvisRot2;
                    BoneUpDown3.ValueChanged += PelvisRot2;
                }
            }

            if (TailRotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= TailRot2;
                    BoneUpDown3.ValueChanged += TailRot2;
                }
            }

            if (LThighRotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= LThighRot2;
                    BoneUpDown3.ValueChanged += LThighRot2;
                }
            }

            if (RThighRotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= RThighRot2;
                    BoneUpDown3.ValueChanged += RThighRot2;
                }
            }

            if (LKneeRotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= LKneeRot2;
                    BoneUpDown3.ValueChanged += LKneeRot2;
                }
            }

            if (RKneeRotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= RKneeRot2;
                    BoneUpDown3.ValueChanged += RKneeRot2;
                }
            }

            if (LCalfRotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= LCalfRot2;
                    BoneUpDown3.ValueChanged += LCalfRot2;
                }
            }

            if (RCalfRotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= RCalfRot2;
                    BoneUpDown3.ValueChanged += RCalfRot2;
                }
            }

            if (LFootRotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= LFootRot2;
                    BoneUpDown3.ValueChanged += LFootRot2;
                }
            }

            if (RFootRotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= RFootRot2;
                    BoneUpDown3.ValueChanged += RFootRot2;
                }
            }

            if (LToesRotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= LToesRot2;
                    BoneUpDown3.ValueChanged += LToesRot2;
                }
            }

            if (RToesRotate)
            {
                if (BoneUpDown3.IsKeyboardFocusWithin || BoneUpDown.IsMouseOver)
                {
                    BoneUpDown3.ValueChanged -= RToesRot2;
                    BoneUpDown3.ValueChanged += RToesRot2;
                }
            }
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

        private void HeadButton_Checked(object sender, RoutedEventArgs e)
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

            //Load Current Values for Slider
            HeadCheck = true;
            System.Threading.Tasks.Task.Delay(150).Wait();
            HeadCheck = false;

            HeadRotate = true;
        }
        private void HeadButton_Unchecked(object sender, RoutedEventArgs e)
        {
            HeadRotate = false;
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

            //Load Current Values for Slider
            NoseCheck = true;
            System.Threading.Tasks.Task.Delay(150).Wait();
            NoseCheck = false;

            NoseRotate = true;
        }
        private void NoseButton_Unchecked(object sender, RoutedEventArgs e)
        {
            NoseRotate = false;
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

            //Load Current Values for Slider
            NostrilsCheck = true;
            System.Threading.Tasks.Task.Delay(150).Wait();
            NostrilsCheck = false;

            NostrilsRotate = true;
        }
        private void NostrilsButton_Unchecked(object sender, RoutedEventArgs e)
        {
            NostrilsRotate = false;
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

            //Load Current Values for Slider
            ChinCheck = true;
            System.Threading.Tasks.Task.Delay(150).Wait();
            ChinCheck = false;

            ChinRotate = true;
        }
        private void ChinButton_Unchecked(object sender, RoutedEventArgs e)
        {
            ChinRotate = false;
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

            //Load Current Values for Slider
            LOutEyebrowCheck = true;
            System.Threading.Tasks.Task.Delay(150).Wait();
            LOutEyebrowCheck = false;

            LOutEyebrowRotate = true;
        }
        private void LOutEyebrowButton_Unchecked(object sender, RoutedEventArgs e)
        {
            LOutEyebrowRotate = false;
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

            //Load Current Values for Slider
            ROutEyebrowCheck = true;
            System.Threading.Tasks.Task.Delay(150).Wait();
            ROutEyebrowCheck = false;

            ROutEyebrowRotate = true;
        }
        private void ROutEyebrowButton_Unchecked(object sender, RoutedEventArgs e)
        {
            ROutEyebrowRotate = false;
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

            //Load Current Values for Slider
            LInEyebrowCheck = true;
            System.Threading.Tasks.Task.Delay(150).Wait();
            LInEyebrowCheck = false;

            LInEyebrowRotate = true;
        }
        private void LInEyebrowButton_Unchecked(object sender, RoutedEventArgs e)
        {
            LInEyebrowRotate = false;
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

            //Load Current Values for Slider
            RInEyebrowCheck = true;
            System.Threading.Tasks.Task.Delay(150).Wait();
            RInEyebrowCheck = false;

            RInEyebrowRotate = true;
        }
        private void RInEyebrowButton_Unchecked(object sender, RoutedEventArgs e)
        {
            RInEyebrowRotate = false;
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

            //Load Current Values for Slider
            LEyeCheck = true;
            System.Threading.Tasks.Task.Delay(150).Wait();
            LEyeCheck = false;

            LEyeRotate = true;
        }
        private void LEyeButton_Unchecked(object sender, RoutedEventArgs e)
        {
            LEyeRotate = false;
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

            //Load Current Values for Slider
            REyeCheck = true;
            System.Threading.Tasks.Task.Delay(150).Wait();
            REyeCheck = false;

            REyeRotate = true;
        }
        private void REyeButton_Unchecked(object sender, RoutedEventArgs e)
        {
            REyeRotate = false;
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

            //Load Current Values for Slider
            LEyelidCheck = true;
            System.Threading.Tasks.Task.Delay(150).Wait();
            LEyelidCheck = false;

            LEyelidRotate = true;
        }
        private void LEyelidButton_Unchecked(object sender, RoutedEventArgs e)
        {
            LEyelidRotate = false;
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

            //Load Current Values for Slider
            REyelidCheck = true;
            System.Threading.Tasks.Task.Delay(150).Wait();
            REyelidCheck = false;

            REyelidRotate = true;
        }
        private void REyelidButton_Unchecked(object sender, RoutedEventArgs e)
        {
            REyelidRotate = false;
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

            //Load Current Values for Slider
            LLowEyelidCheck = true;
            System.Threading.Tasks.Task.Delay(150).Wait();
            LLowEyelidCheck = false;

            LLowEyelidRotate = true;
        }
        private void LLowEyelidButton_Unchecked(object sender, RoutedEventArgs e)
        {
            LLowEyelidRotate = false;
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

            //Load Current Values for Slider
            RLowEyelidCheck = true;
            System.Threading.Tasks.Task.Delay(150).Wait();
            RLowEyelidCheck = false;

            RLowEyelidRotate = true;
        }
        private void RLowEyelidButton_Unchecked(object sender, RoutedEventArgs e)
        {
            RLowEyelidRotate = false;
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

            //Load Current Values for Slider
            LEarCheck = true;
            System.Threading.Tasks.Task.Delay(150).Wait();
            LEarCheck = false;

            LEarRotate = true;
        }
        private void LEarButton_Unchecked(object sender, RoutedEventArgs e)
        {
            LEarRotate = false;
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

            //Load Current Values for Slider
            REarCheck = true;
            System.Threading.Tasks.Task.Delay(150).Wait();
            REarCheck = false;

            REarRotate = true;
        }
        private void REarButton_Unchecked(object sender, RoutedEventArgs e)
        {
            REarRotate = false;
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

            //Load Current Values for Slider
            LCheekCheck = true;
            System.Threading.Tasks.Task.Delay(150).Wait();
            LCheekCheck = false;

            LCheekRotate = true;
        }
        private void LCheekButton_Unchecked(object sender, RoutedEventArgs e)
        {
            LCheekRotate = false;
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

            //Load Current Values for Slider
            RCheekCheck = true;
            System.Threading.Tasks.Task.Delay(150).Wait();
            RCheekCheck = false;

            RCheekRotate = true;
        }
        private void RCheekButton_Unchecked(object sender, RoutedEventArgs e)
        {
            RCheekRotate = false;
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

            //Load Current Values for Slider
            LMouthCheck = true;
            System.Threading.Tasks.Task.Delay(150).Wait();
            LMouthCheck = false;

            LMouthRotate = true;
        }
        private void LMouthButton_Unchecked(object sender, RoutedEventArgs e)
        {
            LMouthRotate = false;
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

            //Load Current Values for Slider
            RMouthCheck = true;
            System.Threading.Tasks.Task.Delay(150).Wait();
            RMouthCheck = false;

            RMouthRotate = true;
        }
        private void RMouthButton_Unchecked(object sender, RoutedEventArgs e)
        {
            RMouthRotate = false;
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

            //Load Current Values for Slider
            LUpLipCheck = true;
            System.Threading.Tasks.Task.Delay(150).Wait();
            LUpLipCheck = false;

            LUpLipRotate = true;
        }
        private void LUpLipButton_Unchecked(object sender, RoutedEventArgs e)
        {
            LUpLipRotate = false;
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

            //Load Current Values for Slider
            RUpLipCheck = true;
            System.Threading.Tasks.Task.Delay(150).Wait();
            RUpLipCheck = false;

            RUpLipRotate = true;
        }
        private void RUpLipButton_Unchecked(object sender, RoutedEventArgs e)
        {
            RUpLipRotate = false;
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

            //Load Current Values for Slider
            LLowLipCheck = true;
            System.Threading.Tasks.Task.Delay(150).Wait();
            LLowLipCheck = false;

            LLowLipRotate = true;
        }
        private void LLowLipButton_Unchecked(object sender, RoutedEventArgs e)
        {
            LLowLipRotate = false;
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

            //Load Current Values for Slider
            RLowLipCheck = true;
            System.Threading.Tasks.Task.Delay(150).Wait();
            RLowLipCheck = false;

            RLowLipRotate = true;
        }
        private void RLowLipButton_Unchecked(object sender, RoutedEventArgs e)
        {
            RLowLipRotate = false;
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

            //Load Current Values for Slider
            NeckCheck = true;
            System.Threading.Tasks.Task.Delay(150).Wait();
            NeckCheck = false;

            NeckRotate = true;
        }
        private void NeckButton_Unchecked(object sender, RoutedEventArgs e)
        {
            NeckRotate = false;
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

            //Load Current Values for Slider
            SternumCheck = true;
            System.Threading.Tasks.Task.Delay(150).Wait();
            SternumCheck = false;

            SternumRotate = true;
        }
        private void SternumButton_Unchecked(object sender, RoutedEventArgs e)
        {
            SternumRotate = false;
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

            //Load Current Values for Slider
            TorsoCheck = true;
            System.Threading.Tasks.Task.Delay(150).Wait();
            TorsoCheck = false;

            TorsoRotate = true;
        }
        private void TorsoButton_Unchecked(object sender, RoutedEventArgs e)
        {
            TorsoRotate = false;
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

            //Load Current Values for Slider
            WaistCheck = true;
            System.Threading.Tasks.Task.Delay(150).Wait();
            WaistCheck = false;

            WaistRotate = true;
        }
        private void WaistButton_Unchecked(object sender, RoutedEventArgs e)
        {
            WaistRotate = false;
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

            //Load Current Values for Slider
            LShoulderCheck = true;
            System.Threading.Tasks.Task.Delay(150).Wait();
            LShoulderCheck = false;

            LShoulderRotate = true;
        }
        private void LShoulderButton_Unchecked(object sender, RoutedEventArgs e)
        {
            LShoulderRotate = false;
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

            //Load Current Values for Slider
            RShoulderCheck = true;
            System.Threading.Tasks.Task.Delay(150).Wait();
            RShoulderCheck = false;

            RShoulderRotate = true;
        }
        private void RShoulderButton_Unchecked(object sender, RoutedEventArgs e)
        {
            RShoulderRotate = false;
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

            //Load Current Values for Slider
            LClavicleCheck = true;
            System.Threading.Tasks.Task.Delay(150).Wait();
            LClavicleCheck = false;

            LClavicleRotate = true;
        }
        private void LClavicleButton_Unchecked(object sender, RoutedEventArgs e)
        {
            LClavicleRotate = false;
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

            //Load Current Values for Slider
            RClavicleCheck = true;
            System.Threading.Tasks.Task.Delay(150).Wait();
            RClavicleCheck = false;

            RClavicleRotate = true;
        }
        private void RClavicleButton_Unchecked(object sender, RoutedEventArgs e)
        {
            RClavicleRotate = false;
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

            //Load Current Values for Slider
            LBreastCheck = true;
            System.Threading.Tasks.Task.Delay(150).Wait();
            LBreastCheck = false;

            LBreastRotate = true;
        }
        private void LBreastButton_Unchecked(object sender, RoutedEventArgs e)
        {
            LBreastRotate = false;
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

            //Load Current Values for Slider
            RBreastCheck = true;
            System.Threading.Tasks.Task.Delay(150).Wait();
            RBreastCheck = false;

            RBreastRotate = true;
        }
        private void RBreastButton_Unchecked(object sender, RoutedEventArgs e)
        {
            RBreastRotate = false;
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

            //Load Current Values for Slider
            LArmCheck = true;
            System.Threading.Tasks.Task.Delay(150).Wait();
            LArmCheck = false;

            LArmRotate = true;
        }
        private void LArmButton_Unchecked(object sender, RoutedEventArgs e)
        {
            LArmRotate = false;
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

            //Load Current Values for Slider
            RArmCheck = true;
            System.Threading.Tasks.Task.Delay(150).Wait();
            RArmCheck = false;

            RArmRotate = true;
        }
        private void RArmButton_Unchecked(object sender, RoutedEventArgs e)
        {
            RArmRotate = false;
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

            //Load Current Values for Slider
            LElbowCheck = true;
            System.Threading.Tasks.Task.Delay(150).Wait();
            LElbowCheck = false;

            LElbowRotate = true;
        }
        private void LElbowButton_Unchecked(object sender, RoutedEventArgs e)
        {
            LElbowRotate = false;
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

            //Load Current Values for Slider
            RElbowCheck = true;
            System.Threading.Tasks.Task.Delay(150).Wait();
            RElbowCheck = false;

            RElbowRotate = true;
        }
        private void RElbowButton_Unchecked(object sender, RoutedEventArgs e)
        {
            RElbowRotate = false;
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

            //Load Current Values for Slider
            LForearmCheck = true;
            System.Threading.Tasks.Task.Delay(150).Wait();
            LForearmCheck = false;

            LForearmRotate = true;
        }
        private void LForearmButton_Unchecked(object sender, RoutedEventArgs e)
        {
            LForearmRotate = false;
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

            //Load Current Values for Slider
            RForearmCheck = true;
            System.Threading.Tasks.Task.Delay(150).Wait();
            RForearmCheck = false;

            RForearmRotate = true;
        }
        private void RForearmButton_Unchecked(object sender, RoutedEventArgs e)
        {
            RForearmRotate = false;
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

            //Load Current Values for Slider
            LWristCheck = true;
            System.Threading.Tasks.Task.Delay(150).Wait();
            LWristCheck = false;

            LWristRotate = true;
        }
        private void LWristButton_Unchecked(object sender, RoutedEventArgs e)
        {
            LWristRotate = false;
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

            //Load Current Values for Slider
            RWristCheck = true;
            System.Threading.Tasks.Task.Delay(150).Wait();
            RWristCheck = false;

            RWristRotate = true;
        }
        private void RWristButton_Unchecked(object sender, RoutedEventArgs e)
        {
            RWristRotate = false;
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

            //Load Current Values for Slider
            LHandCheck = true;
            System.Threading.Tasks.Task.Delay(150).Wait();
            LHandCheck = false;

            LHandRotate = true;
        }
        private void LHandButton_Unchecked(object sender, RoutedEventArgs e)
        {
            LHandRotate = false;
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

            //Load Current Values for Slider
            RHandCheck = true;
            System.Threading.Tasks.Task.Delay(150).Wait();
            RHandCheck = false;

            RHandRotate = true;
        }
        private void RHandButton_Unchecked(object sender, RoutedEventArgs e)
        {
            RHandRotate = false;
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

            //Load Current Values for Slider
            LThumbCheck = true;
            System.Threading.Tasks.Task.Delay(150).Wait();
            LThumbCheck = false;

            LThumbRotate = true;
        }
        private void LThumbButton_Unchecked(object sender, RoutedEventArgs e)
        {
            LThumbRotate = false;
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

            //Load Current Values for Slider
            RThumbCheck = true;
            System.Threading.Tasks.Task.Delay(150).Wait();
            RThumbCheck = false;

            RThumbRotate = true;
        }
        private void RThumbButton_Unchecked(object sender, RoutedEventArgs e)
        {
            RThumbRotate = false;
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

            //Load Current Values for Slider
            LThumb2Check = true;
            System.Threading.Tasks.Task.Delay(150).Wait();
            LThumb2Check = false;

            LThumb2Rotate = true;
        }
        private void LThumb2Button_Unchecked(object sender, RoutedEventArgs e)
        {
            LThumb2Rotate = false;
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

            //Load Current Values for Slider
            RThumb2Check = true;
            System.Threading.Tasks.Task.Delay(150).Wait();
            RThumb2Check = false;

            RThumb2Rotate = true;
        }
        private void RThumb2Button_Unchecked(object sender, RoutedEventArgs e)
        {
            RThumb2Rotate = false;
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

            //Load Current Values for Slider
            LIndexCheck = true;
            System.Threading.Tasks.Task.Delay(150).Wait();
            LIndexCheck = false;

            LIndexRotate = true;
        }
        private void LIndexButton_Unchecked(object sender, RoutedEventArgs e)
        {
            LIndexRotate = false;
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

            //Load Current Values for Slider
            RIndexCheck = true;
            System.Threading.Tasks.Task.Delay(150).Wait();
            RIndexCheck = false;

            RIndexRotate = true;
        }
        private void RIndexButton_Unchecked(object sender, RoutedEventArgs e)
        {
            RIndexRotate = false;
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

            //Load Current Values for Slider
            LIndex2Check = true;
            System.Threading.Tasks.Task.Delay(150).Wait();
            LIndex2Check = false;

            LIndex2Rotate = true;
        }
        private void LIndex2Button_Unchecked(object sender, RoutedEventArgs e)
        {
            LIndex2Rotate = false;
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

            //Load Current Values for Slider
            RIndex2Check = true;
            System.Threading.Tasks.Task.Delay(150).Wait();
            RIndex2Check = false;

            RIndex2Rotate = true;
        }
        private void RIndex2Button_Unchecked(object sender, RoutedEventArgs e)
        {
            RIndex2Rotate = false;
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

            //Load Current Values for Slider
            LMiddleCheck = true;
            System.Threading.Tasks.Task.Delay(150).Wait();
            LMiddleCheck = false;

            LMiddleRotate = true;
        }
        private void LMiddleButton_Unchecked(object sender, RoutedEventArgs e)
        {
            LMiddleRotate = false;
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

            //Load Current Values for Slider
            RMiddleCheck = true;
            System.Threading.Tasks.Task.Delay(150).Wait();
            RMiddleCheck = false;

            RMiddleRotate = true;
        }
        private void RMiddleButton_Unchecked(object sender, RoutedEventArgs e)
        {
            RMiddleRotate = false;
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

            //Load Current Values for Slider
            LMiddle2Check = true;
            System.Threading.Tasks.Task.Delay(150).Wait();
            LMiddle2Check = false;

            LMiddle2Rotate = true;
        }
        private void LMiddle2Button_Unchecked(object sender, RoutedEventArgs e)
        {
            LMiddle2Rotate = false;
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

            //Load Current Values for Slider
            RMiddle2Check = true;
            System.Threading.Tasks.Task.Delay(150).Wait();
            RMiddle2Check = false;

            RMiddle2Rotate = true;
        }
        private void RMiddle2Button_Unchecked(object sender, RoutedEventArgs e)
        {
            RMiddle2Rotate = false;
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

            //Load Current Values for Slider
            LRingCheck = true;
            System.Threading.Tasks.Task.Delay(150).Wait();
            LRingCheck = false;

            LRingRotate = true;
        }
        private void LRingButton_Unchecked(object sender, RoutedEventArgs e)
        {
            LRingRotate = false;
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

            //Load Current Values for Slider
            RRingCheck = true;
            System.Threading.Tasks.Task.Delay(150).Wait();
            RRingCheck = false;

            RRingRotate = true;
        }
        private void RRingButton_Unchecked(object sender, RoutedEventArgs e)
        {
            RRingRotate = false;
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

            //Load Current Values for Slider
            LRing2Check = true;
            System.Threading.Tasks.Task.Delay(150).Wait();
            LRing2Check = false;

            LRing2Rotate = true;
        }
        private void LRing2Button_Unchecked(object sender, RoutedEventArgs e)
        {
            LRing2Rotate = false;
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

            //Load Current Values for Slider
            RRing2Check = true;
            System.Threading.Tasks.Task.Delay(150).Wait();
            RRing2Check = false;

            RRing2Rotate = true;
        }
        private void RRing2Button_Unchecked(object sender, RoutedEventArgs e)
        {
            RRing2Rotate = false;
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

            //Load Current Values for Slider
            LPinkyCheck = true;
            System.Threading.Tasks.Task.Delay(150).Wait();
            LPinkyCheck = false;

            LPinkyRotate = true;
        }
        private void LPinkyButton_Unchecked(object sender, RoutedEventArgs e)
        {
            LPinkyRotate = false;
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

            //Load Current Values for Slider
            RPinkyCheck = true;
            System.Threading.Tasks.Task.Delay(150).Wait();
            RPinkyCheck = false;

            RPinkyRotate = true;
        }
        private void RPinkyButton_Unchecked(object sender, RoutedEventArgs e)
        {
            RPinkyRotate = false;
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

            //Load Current Values for Slider
            LPinky2Check = true;
            System.Threading.Tasks.Task.Delay(150).Wait();
            LPinky2Check = false;

            LPinky2Rotate = true;
        }
        private void LPinky2Button_Unchecked(object sender, RoutedEventArgs e)
        {
            LPinky2Rotate = false;
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

            //Load Current Values for Slider
            RPinky2Check = true;
            System.Threading.Tasks.Task.Delay(150).Wait();
            RPinky2Check = false;

            RPinky2Rotate = true;
        }
        private void RPinky2Button_Unchecked(object sender, RoutedEventArgs e)
        {
            RPinky2Rotate = false;
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

            //Load Current Values for Slider
            PelvisCheck = true;
            System.Threading.Tasks.Task.Delay(150).Wait();
            PelvisCheck = false;

            PelvisRotate = true;
        }
        private void PelvisButton_Unchecked(object sender, RoutedEventArgs e)
        {
            PelvisRotate = false;
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

            //Load Current Values for Slider
            TailCheck = true;
            System.Threading.Tasks.Task.Delay(150).Wait();
            TailCheck = false;

            TailRotate = true;
        }
        private void TailButton_Unchecked(object sender, RoutedEventArgs e)
        {
            TailRotate = false;
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
            RThighButton.IsChecked = false;
            LKneeButton.IsChecked = false;
            RKneeButton.IsChecked = false;
            LCalfButton.IsChecked = false;
            RCalfButton.IsChecked = false;
            LFootButton.IsChecked = false;
            RFootButton.IsChecked = false;
            LToesButton.IsChecked = false;
            RToesButton.IsChecked = false;

            //Load Current Values for Slider
            LThighCheck = true;
            System.Threading.Tasks.Task.Delay(150).Wait();
            LThighCheck = false;

            LThighRotate = true;
        }
        private void LThighButton_Unchecked(object sender, RoutedEventArgs e)
        {
            LThighRotate = false;
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
            LThighButton.IsChecked = false;
            LKneeButton.IsChecked = false;
            RKneeButton.IsChecked = false;
            LCalfButton.IsChecked = false;
            RCalfButton.IsChecked = false;
            LFootButton.IsChecked = false;
            RFootButton.IsChecked = false;
            LToesButton.IsChecked = false;
            RToesButton.IsChecked = false;

            //Load Current Values for Slider
            RThighCheck = true;
            System.Threading.Tasks.Task.Delay(150).Wait();
            RThighCheck = false;

            RThighRotate = true;
        }
        private void RThighButton_Unchecked(object sender, RoutedEventArgs e)
        {
            RThighRotate = false;
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
            LThighButton.IsChecked = false;
            RThighButton.IsChecked = false;
            RKneeButton.IsChecked = false;
            LCalfButton.IsChecked = false;
            RCalfButton.IsChecked = false;
            LFootButton.IsChecked = false;
            RFootButton.IsChecked = false;
            LToesButton.IsChecked = false;
            RToesButton.IsChecked = false;

            //Load Current Values for Slider
            LKneeCheck = true;
            System.Threading.Tasks.Task.Delay(150).Wait();
            LKneeCheck = false;

            LKneeRotate = true;
        }
        private void LKneeButton_Unchecked(object sender, RoutedEventArgs e)
        {
            LKneeRotate = false;
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
            LThighButton.IsChecked = false;
            RThighButton.IsChecked = false;
            LKneeButton.IsChecked = false;
            LCalfButton.IsChecked = false;
            RCalfButton.IsChecked = false;
            LFootButton.IsChecked = false;
            RFootButton.IsChecked = false;
            LToesButton.IsChecked = false;
            RToesButton.IsChecked = false;

            //Load Current Values for Slider
            RKneeCheck = true;
            System.Threading.Tasks.Task.Delay(150).Wait();
            RKneeCheck = false;

            RKneeRotate = true;
        }
        private void RKneeButton_Unchecked(object sender, RoutedEventArgs e)
        {
            RKneeRotate = false;
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
            LThighButton.IsChecked = false;
            RThighButton.IsChecked = false;
            LKneeButton.IsChecked = false;
            RKneeButton.IsChecked = false;
            RCalfButton.IsChecked = false;
            LFootButton.IsChecked = false;
            RFootButton.IsChecked = false;
            LToesButton.IsChecked = false;
            RToesButton.IsChecked = false;

            //Load Current Values for Slider
            LCalfCheck = true;
            System.Threading.Tasks.Task.Delay(150).Wait();
            LCalfCheck = false;

            LCalfRotate = true;
        }
        private void LCalfButton_Unchecked(object sender, RoutedEventArgs e)
        {
            LCalfRotate = false;
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
            LThighButton.IsChecked = false;
            RThighButton.IsChecked = false;
            LKneeButton.IsChecked = false;
            RKneeButton.IsChecked = false;
            LCalfButton.IsChecked = false;
            LFootButton.IsChecked = false;
            RFootButton.IsChecked = false;
            LToesButton.IsChecked = false;
            RToesButton.IsChecked = false;

            //Load Current Values for Slider
            RCalfCheck = true;
            System.Threading.Tasks.Task.Delay(150).Wait();
            RCalfCheck = false;

            RCalfRotate = true;
        }
        private void RCalfButton_Unchecked(object sender, RoutedEventArgs e)
        {
            RCalfRotate = false;
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
            LThighButton.IsChecked = false;
            RThighButton.IsChecked = false;
            LKneeButton.IsChecked = false;
            RKneeButton.IsChecked = false;
            LCalfButton.IsChecked = false;
            RCalfButton.IsChecked = false;
            RFootButton.IsChecked = false;
            LToesButton.IsChecked = false;
            RToesButton.IsChecked = false;

            //Load Current Values for Slider
            LFootCheck = true;
            System.Threading.Tasks.Task.Delay(150).Wait();
            LFootCheck = false;

            LFootRotate = true;
        }
        private void LFootButton_Unchecked(object sender, RoutedEventArgs e)
        {
            LFootRotate = false;
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
            LThighButton.IsChecked = false;
            RThighButton.IsChecked = false;
            LKneeButton.IsChecked = false;
            RKneeButton.IsChecked = false;
            LCalfButton.IsChecked = false;
            RCalfButton.IsChecked = false;
            LFootButton.IsChecked = false;
            LToesButton.IsChecked = false;
            RToesButton.IsChecked = false;

            //Load Current Values for Slider
            RFootCheck = true;
            System.Threading.Tasks.Task.Delay(150).Wait();
            RFootCheck = false;

            RFootRotate = true;
        }
        private void RFootButton_Unchecked(object sender, RoutedEventArgs e)
        {
            RFootRotate = false;
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
            LThighButton.IsChecked = false;
            RThighButton.IsChecked = false;
            LKneeButton.IsChecked = false;
            RKneeButton.IsChecked = false;
            LCalfButton.IsChecked = false;
            RCalfButton.IsChecked = false;
            LFootButton.IsChecked = false;
            RFootButton.IsChecked = false;
            RToesButton.IsChecked = false;

            //Load Current Values for Slider
            LToesCheck = true;
            System.Threading.Tasks.Task.Delay(150).Wait();
            LToesCheck = false;

            LToesRotate = true;
        }
        private void LToesButton_Unchecked(object sender, RoutedEventArgs e)
        {
            LToesRotate = false;
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
            LThighButton.IsChecked = false;
            RThighButton.IsChecked = false;
            LKneeButton.IsChecked = false;
            RKneeButton.IsChecked = false;
            LCalfButton.IsChecked = false;
            RCalfButton.IsChecked = false;
            LFootButton.IsChecked = false;
            RFootButton.IsChecked = false;
            LToesButton.IsChecked = false;

            //Load Current Values for Slider
            RToesCheck = true;
            System.Threading.Tasks.Task.Delay(150).Wait();
            RToesCheck = false;

            RToesRotate = true;
        }
        private void RToesButton_Unchecked(object sender, RoutedEventArgs e)
        {
            RToesRotate = false;
        }
        #endregion


        private void EditModeButton_Checked(object sender, RoutedEventArgs e)
        {
            var seklval1 = System.BitConverter.GetBytes(MemoryManager.Instance.MemLib.readLong(MemoryManager.Instance.SkeletonAddress));
            var seklval2 = System.BitConverter.GetBytes(MemoryManager.Instance.MemLib.readLong(MemoryManager.Instance.SkeletonAddress2));
            var seklval3 = System.BitConverter.GetBytes(MemoryManager.Instance.MemLib.readLong(MemoryManager.Instance.SkeletonAddress3));
            SkeletonValue = seklval1;
            SkeletonValue2 = seklval2;
            SkeletonValue3 = seklval3;
            CharacterDetails.BoneFreeze = true;
            MemoryManager.Instance.MemLib.writeMemory(MemoryManager.Instance.SkeletonAddress, "bytes", "0x90 0x90 0x90 0x90 0x90 0x90");
            MemoryManager.Instance.MemLib.writeMemory(MemoryManager.Instance.SkeletonAddress2, "bytes", "0x90 0x90 0x90 0x90 0x90 0x90");
            MemoryManager.Instance.MemLib.writeMemory(MemoryManager.Instance.SkeletonAddress3, "bytes", "0x90 0x90 0x90 0x90");
            EditMode = true;

            EnableAll();
        }
        private void EditModeButton_Unchecked(object sender, RoutedEventArgs e)
        {
            CharacterDetails.BoneFreeze = false;
            MemoryManager.Instance.MemLib.writeBytes(MemoryManager.Instance.SkeletonAddress, SkeletonValue);
            MemoryManager.Instance.MemLib.writeBytes(MemoryManager.Instance.SkeletonAddress2, SkeletonValue2);
            MemoryManager.Instance.MemLib.writeBytes(MemoryManager.Instance.SkeletonAddress3, SkeletonValue3);
            EditMode = false;

            //Clear Slider Values
            CharacterDetails.BoneX = 0;
            CharacterDetails.BoneY = 0;
            CharacterDetails.BoneZ = 0;

            UncheckAll();
            DisableAll();
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
            TPoseX();
            TPoseY();
            TPoseZ();
            TPoseW();
        }

        private void UncheckAll()
        {
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
        }

        private void EnableAll()
        {
            TPoseButton.IsEnabled = true;
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
        }

        private void DisableAll()
        {
            TPoseButton.IsEnabled = false;
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
        }

        private void TPoseX()
        {
            var m = MemoryManager.Instance.MemLib;
            var c = Settings.Instance.Character;

            string GAS(params string[] args) => MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, args);

            m.writeMemory(GAS(c.Body.Base, c.Body.Position.HeadX), "float", "0.7071064711");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.NoseX), "float", "0.7071064711");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.NostrilsX), "float", "0.7071064711");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.ChinX), "float", "0.7010570765");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.LOutEyebrowX), "float", "0.803856492");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.ROutEyebrowX), "float", "0.594822526");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.LInEyebrowX), "float", "0.7071064711");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.RInEyebrowX), "float", "0.7071064711");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.LEyeX), "float", "0.7071064711");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.REyeX), "float", "0.7071064711");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.LEyelidX), "float", "0.731854558");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.REyelidX), "float", "0.6589646935");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.LLowEyelidX), "float", "0.7395583391");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.RLowEyelidX), "float", "0.6428881288");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.LEarX), "float", "-0.3030564189");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.REarX), "float", "0.3502247632");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.LCheekX), "float", "0.7933529615");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.RCheekX), "float", "0.6087611914");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.LMouthX), "float", "0.8191515803");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.RMouthX), "float", "0.5735763311");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.LUpLipX), "float", "0.7070794702");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.RUpLipX), "float", "0.7071062922");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.LLowLipX), "float", "0.7071064711");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.RLowLipX), "float", "0.7018356919");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.NeckX), "float", "0.6045512557");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.SternumX), "float", "0.5119624138");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.TorsoX), "float", "0.4947781861");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.WaistX), "float", "0.4738240242");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.LShoulderX), "float", "-0.6383195519");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.RShoulderX), "float", "-0.2362460941");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.LClavicleX), "float", "2.980232239E-8");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.RClavicleX), "float", "-1.490116119E-8");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.LBreastX), "float", "-0.03088223934");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.RBreastX), "float", "-0.03088220209");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.LArmX), "float", "-0.6383193135");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.RArmX), "float", "-0.236246109");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.LElbowX), "float", "-0.6540370584");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.RElbowX), "float", "0.2724279761");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.LForearmX), "float", "-0.6677876711");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.RForearmX), "float", "0.3077905476");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.LWristX), "float", "-0.6532810926");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.RWristX), "float", "-0.2705979645");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.LHandX), "float", "-0.6532812119");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.RHandX), "float", "-0.2705982924");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.LThumbX), "float", "0.4309564829");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.RThumbX), "float", "0.2627345026");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.LThumb2X), "float", "0.4309564829");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.RThumb2X), "float", "0.2627344429");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.LIndexX), "float", "2.980232239E-8");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.RIndexX), "float", "-0.3826832771");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.LIndex2X), "float", "1.149457951E-8");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.RIndex2X), "float", "-0.3826832473");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.LMiddleX), "float", "2.980232239E-8");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.RMiddleX), "float", "-0.3826832771");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.LMiddle2X), "float", "1.149457951E-8");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.RMiddle2X), "float", "-0.3826832473");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.LRingX), "float", "0");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.RRingX), "float", "-0.3826832175");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.LRing2X), "float", "6.836367028E-10");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.RRing2X), "float", "-0.3826831877");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.LPinkyX), "float", "0");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.RPinkyX), "float", "-0.3826832175");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.LPinky2X), "float", "6.836367028E-10");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.RPinky2X), "float", "-0.3826831877");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.PelvisX), "float", "0.550806284");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.TailX), "float", "-0.184204489");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.LThighX), "float", "0.5075724125");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.RThighX), "float", "0.5075724125");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.LKneeX), "float", "-0.4967896044");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.RKneeX), "float", "-0.4967896044");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.LCalfX), "float", "-0.4709248245");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.RCalfX), "float", "-0.4709248245");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.LFootX), "float", "0.6834150553");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.RFootX), "float", "0.6834150553");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.LToesX), "float", "0.7071067095");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.RToesX), "float", "0.7071067095");
        }

        private void TPoseY()
        {
            var m = MemoryManager.Instance.MemLib;
            var c = Settings.Instance.Character;

            string GAS(params string[] args) => MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, args);

            m.writeMemory(GAS(c.Body.Base, c.Body.Position.HeadY), "float", "2.980232239E-8");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.NoseY), "float", "2.967532708E-8");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.NostrilsY), "float", "2.967532708E-8");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.ChinY), "float", "-0.09229586273");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.LOutEyebrowY), "float", "2.367235652E-8");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.ROutEyebrowY), "float", "3.493174816E-8");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.LInEyebrowY), "float", "2.967532708E-8");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.RInEyebrowY), "float", "2.967532708E-8");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.LEyeY), "float", "2.967532708E-8");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.REyeY), "float", "2.967532708E-8");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.LEyelidY), "float", "0.1290455163");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.REyelidY), "float", "0.1161931232");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.LLowEyelidY), "float", "-0.1504644901");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.RLowEyelidY), "float", "-0.1307967603");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.LEarY), "float", "0.2961898446");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.REarY), "float", "0.8353264332");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.LCheekY), "float", "2.427711721E-8");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.RCheekY), "float", "3.451231834E-8");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.LMouthY), "float", "2.549330702E-8");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.RMouthY), "float", "3.55409604E-8");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.LUpLipY), "float", "0.006170331966");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.RUpLipY), "float", "3.026798368E-8");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.LLowLipY), "float", "2.980232239E-8");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.RLowLipY), "float", "-0.08617512882");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.NeckY), "float", "0.366766274");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.SternumY), "float", "0.4877440631");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.TorsoY), "float", "0.5051676631");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.WaistY), "float", "0.5248720646");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.LShoulderY), "float", "0.3042170703");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.RShoulderY), "float", "0.6664740443");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.LClavicleY), "float", "0");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.RClavicleY), "float", "0.9999997616");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.LBreastY), "float", "-0.6213850379");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.RBreastY), "float", "-0.782286942");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.LArmY), "float", "0.3042170107");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.RArmY), "float", "0.6664740443");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.LElbowY), "float", "0.2687657475");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.RElbowY), "float", "-0.6525203586");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.LForearmY), "float", "0.2325061858");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.RForearmY), "float", "-0.6366041303");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.LWristY), "float", "0.2705978751");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.RWristY), "float", "0.6532813907");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.LHandY), "float", "0.2705976069");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.RHandY), "float", "0.6532812119");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.LThumbY), "float", "-0.5649164915");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.RThumbY), "float", "-0.6527751088");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.LThumb2Y), "float", "-0.5649165511");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.RThumb2Y), "float", "-0.6527751684");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.LIndexY), "float", "-4.917383194E-7");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.RIndexY), "float", "0.9238792062");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.LIndex2Y), "float", "-4.648088918E-7");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.RIndex2Y), "float", "0.9238791466");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.LMiddleY), "float", "-4.917383194E-7");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.RMiddleY), "float", "0.9238792062");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.LMiddle2Y), "float", "-4.648088918E-7");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.RMiddle2Y), "float", "0.9238791466");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.LRingY), "float", "-1.490116119E-8");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.RRingY), "float", "0.923879087");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.LRing2Y), "float", "-1.625886092E-9");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.RRing2Y), "float", "0.9238790274");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.LPinkyY), "float", "-1.490116119E-8");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.RPinkyY), "float", "0.923879087");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.LPinky2Y), "float", "-1.625886092E-9");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.RPinky2Y), "float", "0.9238790274");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.PelvisY), "float", "-0.4434098899");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.TailY), "float", "0.6826921701");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.LThighY), "float", "-0.4923109114");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.RThighY), "float", "-0.4923109114");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.LKneeY), "float", "0.503189683");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.RKneeY), "float", "0.503189683");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.LCalfY), "float", "0.5274748206");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.RCalfY), "float", "0.5274748206");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.LFootY), "float", "-0.181504041");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.RFootY), "float", "-0.181504041");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.LToesY), "float", "-1.490116119E-8");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.RToesY), "float", "-1.490116119E-8");
        }

        private void TPoseZ()
        {
            var m = MemoryManager.Instance.MemLib;
            var c = Settings.Instance.Character;

            string GAS(params string[] args) => MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, args);

            m.writeMemory(GAS(c.Body.Base, c.Body.Position.HeadZ), "float", "0.7071065903");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.NoseZ), "float", "0.7071065903");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.NostrilsZ), "float", "0.7071065903");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.ChinZ), "float", "0.7010571957");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.LOutEyebrowZ), "float", "0.5948226452");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.ROutEyebrowZ), "float", "0.8038566113");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.LInEyebrowZ), "float", "0.7071065903");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.RInEyebrowZ), "float", "0.7071065903");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.LEyeZ), "float", "0.7071065903");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.REyeZ), "float", "0.7071065903");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.LEyelidZ), "float", "0.6589648724");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.REyelidZ), "float", "0.7318546176");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.LLowEyelidZ), "float", "0.6428883076");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.RLowEyelidZ), "float", "0.7395585179");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.LEarZ), "float", "0.3502247334");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.REarZ), "float", "-0.3030564487");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.LCheekZ), "float", "0.6087613106");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.RCheekZ), "float", "0.7933530807");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.LMouthZ), "float", "0.5735765696");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.RMouthZ), "float", "0.8191516399");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.LUpLipZ), "float", "0.7070795894");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.RUpLipZ), "float", "0.7071064115");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.LLowLipZ), "float", "0.7071065903");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.RLowLipZ), "float", "0.7018358111");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.NeckZ), "float", "0.6045513153");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.SternumZ), "float", "0.5119624734");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.TorsoZ), "float", "0.4947781861");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.WaistZ), "float", "0.4738240242");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.LShoulderZ), "float", "-0.2362460047");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.RShoulderZ), "float", "-0.6383191943");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.LClavicleZ), "float", "0");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.RClavicleZ), "float", "2.980232239E-8");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.LBreastZ), "float", "0.03088222817");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.RBreastZ), "float", "0.03088220209");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.LArmZ), "float", "-0.236246109");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.RArmZ), "float", "-0.6383193135");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.LElbowZ), "float", "-0.2724279761");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.RElbowZ), "float", "0.6540369987");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.LForearmZ), "float", "-0.3077905178");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.RForearmZ), "float", "0.6677876711");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.LWristZ), "float", "-0.2705979943");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.RWristZ), "float", "-0.6532810926");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.LHandZ), "float", "-0.2705982327");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.RHandZ), "float", "-0.6532812119");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.LThumbZ), "float", "-0.2627345026");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.RThumbZ), "float", "-0.4309565127");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.LThumb2Z), "float", "-0.2627344728");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.RThumb2Z), "float", "-0.4309565723");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.LIndexZ), "float", "-0.3826832771");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.RIndexZ), "float", "0");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.LIndex2Z), "float", "-0.3826832473");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.RIndex2Z), "float", "1.752551704E-8");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.LMiddleZ), "float", "-0.3826832771");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.RMiddleZ), "float", "0");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.LMiddle2Z), "float", "-0.3826832473");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.RMiddle2Z), "float", "1.752551704E-8");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.LRingZ), "float", "-0.3826832175");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.RRingZ), "float", "0");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.LRing2Z), "float", "-0.3826832175");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.RRing2Z), "float", "-6.725038304E-10");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.LPinkyZ), "float", "-0.3826832175");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.RPinkyZ), "float", "0");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.LPinky2Z), "float", "-0.3826832175");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.RPinky2Z), "float", "-6.725038304E-10");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.PelvisZ), "float", "0.550806284");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.TailZ), "float", "-0.184204489");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.LThighZ), "float", "0.5075724125");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.RThighZ), "float", "0.5075724125");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.LKneeZ), "float", "-0.496789515");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.RKneeZ), "float", "-0.496789515");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.LCalfZ), "float", "-0.4709247351");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.RCalfZ), "float", "-0.4709247351");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.LFootZ), "float", "0.6834150553");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.RFootZ), "float", "0.6834150553");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.LToesZ), "float", "0.7071067691");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.RToesZ), "float", "0.7071067691");
        }

        private void TPoseW()
        {
            var m = MemoryManager.Instance.MemLib;
            var c = Settings.Instance.Character;

            string GAS(params string[] args) => MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, args);

            m.writeMemory(GAS(c.Body.Base, c.Body.Position.HeadW), "float", "2.980232239E-8");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.NoseW), "float", "2.967532708E-8");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.NostrilsW), "float", "2.967532708E-8");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.ChinW), "float", "-0.09229589254");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.LOutEyebrowW), "float", "3.28294476E-8");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.ROutEyebrowW), "float", "2.646828356E-8");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.LInEyebrowW), "float", "2.967532708E-8");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.RInEyebrowW), "float", "2.967532708E-8");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.LEyeW), "float", "2.967532708E-8");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.REyeW), "float", "2.967532708E-8");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.LEyelidW), "float", "0.1161931381");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.REyelidW), "float", "0.129045561");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.LLowEyelidW), "float", "-0.1307968199");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.RLowEyelidW), "float", "-0.150464505");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.LEarW), "float", "0.8353263736");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.REarW), "float", "0.2961899042");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.LCheekW), "float", "3.236348078E-8");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.RCheekW), "float", "2.703848878E-8");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.LMouthW), "float", "3.539162208E-8");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.RMouthW), "float", "2.559784917E-8");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.LUpLipW), "float", "0.006170333829");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.RUpLipW), "float", "3.026798368E-8");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.LLowLipW), "float", "2.980232239E-8");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.RLowLipW), "float", "-0.08617514372");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.NeckW), "float", "0.3667662442");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.SternumW), "float", "0.4877440631");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.TorsoW), "float", "0.5051677227");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.WaistW), "float", "0.5248720646");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.LShoulderW), "float", "0.6664738059");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.RShoulderW), "float", "0.3042169213");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.LClavicleW), "float", "0.9999997616");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.RClavicleW), "float", "1.490116119E-8");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.LBreastW), "float", "0.7822870016");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.RBreastW), "float", "0.6213850975");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.LArmW), "float", "0.6664740443");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.RArmW), "float", "0.3042169809");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.LElbowW), "float", "0.652520299");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.RElbowW), "float", "-0.2687657475");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.LForearmW), "float", "0.6366040707");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.RForearmW), "float", "-0.232506156");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.LWristW), "float", "0.6532813907");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.RWristW), "float", "0.2705978751");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.LHandW), "float", "0.6532812119");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.RHandW), "float", "0.2705976367");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.LThumbW), "float", "0.652775228");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.RThumbW), "float", "0.5649167299");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.LThumb2W), "float", "0.6527751684");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.RThumb2W), "float", "0.5649166703");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.LIndexW), "float", "0.9238791466");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.RIndexW), "float", "-4.768371582E-7");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.LIndex2W), "float", "0.9238791466");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.RIndex2W), "float", "-4.644691955E-7");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.LMiddleW), "float", "0.9238791466");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.RMiddleW), "float", "-4.768371582E-7");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.LMiddle2W), "float", "0.9238791466");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.RMiddle2W), "float", "-4.644691955E-7");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.LRingW), "float", "0.9238790274");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.RRingW), "float", "-1.490116119E-8");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.LRing2W), "float", "0.9238790274");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.RRing2W), "float", "1.644958836E-9");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.LPinkyW), "float", "0.9238790274");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.RPinkyW), "float", "-1.490116119E-8");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.LPinky2W), "float", "0.9238790274");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.RPinky2W), "float", "1.644958836E-9");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.PelvisW), "float", "-0.4434098899");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.TailW), "float", "0.6826921701");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.LThighW), "float", "-0.4923109114");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.RThighW), "float", "-0.4923109114");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.LKneeW), "float", "0.5031898022");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.RKneeW), "float", "0.5031898022");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.LCalfW), "float", "0.5274748206");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.RCalfW), "float", "0.5274748206");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.LFootW), "float", "-0.1815040112");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.RFootW), "float", "-0.1815040112");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.LToesW), "float", "-1.490116119E-8");
            m.writeMemory(GAS(c.Body.Base, c.Body.Position.RToesW), "float", "-1.490116119E-8");
        }
    }
}
