using FFXIVTool.Models;
using FFXIVTool.Utility;
using FFXIVTool.ViewModel;
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

namespace FFXIVTool.Views
{
    /// <summary>
    /// Interaction logic for CharacterDetailsView4.xaml
    /// </summary>
    public partial class CharacterDetailsView4 : UserControl
    {
        public CharacterDetails CharacterDetails { get => (CharacterDetails)BaseViewModel.model; set => BaseViewModel.model = value; }
        public CharacterDetailsView4()
        {
            InitializeComponent();
        }

        private void RedPxD(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (RedP.Value.HasValue)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.SkinRedPigment), "float", RedP.Value.ToString());
            RedP.ValueChanged -= RedPxD;
        }

        private void RedP_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (RedP.IsKeyboardFocusWithin || RedP.IsMouseOver)
            {
                RedP.ValueChanged -= RedPxD;
                RedP.ValueChanged += RedPxD;
            }
        }

        private void GreenPxd(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (GreenP.Value.HasValue)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.SkinGreenPigment), "float", GreenP.Value.ToString());
            GreenP.ValueChanged -= GreenPxd;
        }


        private void GreenP_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (GreenP.IsKeyboardFocusWithin || GreenP.IsMouseOver)
            {
                GreenP.ValueChanged -= GreenPxd;
                GreenP.ValueChanged += GreenPxd;
            }
        }

        private void BluePxd(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (BlueP.Value.HasValue)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.SkinBluePigment), "float", BlueP.Value.ToString());
            BlueP.ValueChanged -= BluePxd;
        }

        private void BlueP_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (BlueP.IsKeyboardFocusWithin || BlueP.IsMouseOver)
            {
                BlueP.ValueChanged -= BluePxd;
                BlueP.ValueChanged += BluePxd;
            }
        }

        private void RedGxd(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (RedG.Value.HasValue)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.SkinRedGloss), "float", RedG.Value.ToString());
            RedG.ValueChanged -= RedGxd;
        }

        private void RedG_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (RedG.IsKeyboardFocusWithin || RedG.IsMouseOver)
            {
                RedG.ValueChanged -= RedGxd;
                RedG.ValueChanged += RedGxd;
            }
        }

        private void GreenGxD(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (GreenG.Value.HasValue)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.SkinGreenGloss), "float", GreenG.Value.ToString());
            GreenG.ValueChanged -= GreenGxD;
        }

        private void GreenG_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (GreenG.IsKeyboardFocusWithin || GreenG.IsMouseOver)
            {
                GreenG.ValueChanged -= GreenGxD;
                GreenG.ValueChanged += GreenGxD;
            }
        }

        private void BlueGxd(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (BlueG.Value.HasValue)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.SkinBlueGloss), "float", BlueG.Value.ToString());
            BlueG.ValueChanged -= BlueGxd;
        }

        private void BlueG_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (BlueG.IsKeyboardFocusWithin || BlueG.IsMouseOver)
            {
                BlueG.ValueChanged -= BlueGxd;
                BlueG.ValueChanged += BlueGxd;
            }
        }

        private void LipsBrightxd(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (LipsBright.Value.HasValue)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LipsBrightness), "float", LipsBright.Value.ToString());
            LipsBright.ValueChanged -= LipsBrightxd;
        }

        private void LipsBright_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (LipsBright.IsKeyboardFocusWithin || LipsBright.IsMouseOver)
            {
                LipsBright.ValueChanged -= LipsBrightxd;
                LipsBright.ValueChanged += LipsBrightxd;
            }
        }

        private void LipsRedxd(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (LipsRed.Value.HasValue)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LipsR), "float", LipsRed.Value.ToString());
            LipsRed.ValueChanged -= LipsRedxd;
        }

        private void LipsRed_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (LipsRed.IsKeyboardFocusWithin || LipsRed.IsMouseOver)
            {
                LipsRed.ValueChanged -= LipsRedxd;
                LipsRed.ValueChanged += LipsRedxd;
            }
        }

        private void LipsGreenxd(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (LipsGreen.Value.HasValue)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LipsG), "float", LipsGreen.Value.ToString());
            LipsGreen.ValueChanged -= LipsGreenxd;
        }

        private void LipsGreen_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (LipsGreen.IsKeyboardFocusWithin || LipsGreen.IsMouseOver)
            {
                LipsGreen.ValueChanged -= LipsGreenxd;
                LipsGreen.ValueChanged += LipsGreenxd;
            }
        }

        private void LipsBluexd(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (LipsBlue.Value.HasValue)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LipsB), "float", LipsBlue.Value.ToString());
            LipsBlue.ValueChanged -= LipsBluexd;
        }

        private void LipsBlue_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (LipsBlue.IsKeyboardFocusWithin || LipsBlue.IsMouseOver)
            {
                LipsBlue.ValueChanged -= LipsBluexd;
                LipsBlue.ValueChanged += LipsBluexd;
            }
        }

        private void HairRedxD(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (HairRed.Value.HasValue)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HairRedPigment), "float", HairRed.Value.ToString());
            HairRed.ValueChanged -= HairRedxD;
        }

        private void HairRed_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (HairRed.IsKeyboardFocusWithin || HairRed.IsMouseOver)
            {
                HairRed.ValueChanged -= HairRedxD;
                HairRed.ValueChanged += HairRedxD;
            }
        }

        private void HairGreenXD(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (HairGreen.Value.HasValue)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HairGreenPigment), "float", HairGreen.Value.ToString());
        }

        private void HairGreen_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (HairGreen.IsKeyboardFocusWithin || HairGreen.IsMouseOver)
            {
                HairGreen.ValueChanged -= HairGreenXD;
                HairGreen.ValueChanged += HairGreenXD;
            }
        }

        private void HairBluexd(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (HairBlue.Value.HasValue)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HairBluePigment), "float", HairBlue.Value.ToString());
        }

        private void HairBlue_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (HairBlue.IsKeyboardFocusWithin || HairBlue.IsMouseOver)
            {
                HairBlue.ValueChanged -= HairBluexd;
                HairBlue.ValueChanged += HairBluexd;
            }
        }

        private void HairRedGxd(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (HairRedGlow.Value.HasValue)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HairGlowRed), "float", HairRedGlow.Value.ToString());
            HairRedGlow.ValueChanged -= HairRedGxd;
        }

        private void HairRedGlow_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (HairRedGlow.IsKeyboardFocusWithin || HairRedGlow.IsMouseOver)
            {
                HairRedGlow.ValueChanged -= HairRedGxd;
                HairRedGlow.ValueChanged += HairRedGxd;
            }
        }

        private void HairGreenGxD(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (HairGreenGlow.Value.HasValue)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HairGlowGreen), "float", HairGreenGlow.Value.ToString());
            HairGreenGlow.ValueChanged -= HairGreenGxD;
        }

        private void HairGreenGlow_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (HairGreenGlow.IsKeyboardFocusWithin || HairGreenGlow.IsMouseOver)
            {
                HairGreenGlow.ValueChanged -= HairGreenGxD;
                HairGreenGlow.ValueChanged += HairGreenGxD;
            }
        }

        private void HairBlueGxD(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (HairBlueGlow.Value.HasValue)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HairGlowBlue), "float", HairBlueGlow.Value.ToString());
        }

        private void HairBlueGlow_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (HairBlueGlow.IsKeyboardFocusWithin || HairBlueGlow.IsMouseOver)
            {
                HairBlueGlow.ValueChanged -= HairBlueGxD;
                HairBlueGlow.ValueChanged += HairBlueGxD;
            }
        }

        private void HRPXD(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (HRP.Value.HasValue)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HighlightRedPigment), "float", HRP.Value.ToString());
            HRP.ValueChanged -= HRPXD;
        }

        private void HRP_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (HRP.IsKeyboardFocusWithin || HRP.IsMouseOver)
            {
                HRP.ValueChanged -= HRPXD;
                HRP.ValueChanged += HRPXD;
            }
        }

        private void HGPxd(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (HGP.Value.HasValue)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HighlightGreenPigment), "float", HGP.Value.ToString());
            HGP.ValueChanged -= HGPxd;
        }

        private void HGP_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (HGP.IsKeyboardFocusWithin || HGP.IsMouseOver)
            {
                HGP.ValueChanged -= HGPxd;
                HGP.ValueChanged += HGPxd;
            }
        }

        private void HBPXD(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (HBP.Value.HasValue)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HighlightBluePigment), "float", HBP.Value.ToString());
            HBP.ValueChanged -= HBPXD;
        }

        private void HBP_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (HBP.IsKeyboardFocusWithin || HBP.IsMouseOver)
            {
                HBP.ValueChanged -= HBPXD;
                HBP.ValueChanged += HBPXD;
            }
        }

        private void LeyeRxd(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (LEyeR.Value.HasValue)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LeftEyeRed), "float", LEyeR.Value.ToString());
            LEyeR.ValueChanged -= LeyeRxd;
        }

        private void LEyeR_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (LEyeR.IsKeyboardFocusWithin || LEyeR.IsMouseOver)
            {
                LEyeR.ValueChanged -= LeyeRxd;
                LEyeR.ValueChanged += LeyeRxd;
            }
        }

        private void LEyeGxd(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (LeyeG.Value.HasValue)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LeftEyeGreen), "float", LeyeG.Value.ToString());
            LeyeG.ValueChanged -= LEyeGxd;
        }

        private void LeyeG_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (LeyeG.IsKeyboardFocusWithin || LeyeG.IsMouseOver)
            {
                LeyeG.ValueChanged -= LEyeGxd;
                LeyeG.ValueChanged += LEyeGxd;
            }
        }

        private void LeyebXD(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (LeyeB.Value.HasValue)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LeftEyeBlue), "float", LeyeB.Value.ToString());
            LeyeB.ValueChanged -= LeyebXD;
        }

        private void LeyeB_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (LeyeB.IsKeyboardFocusWithin || LeyeB.IsMouseOver)
            {
                LeyeB.ValueChanged -= LeyebXD;
                LeyeB.ValueChanged += LeyebXD;
            }
        }

        private void ReyeRxd(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (ReyeR.Value.HasValue)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.RightEyeRed), "float", ReyeR.Value.ToString());
            ReyeR.ValueChanged -= ReyeRxd;
        }

        private void ReyeR_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (ReyeR.IsKeyboardFocusWithin || ReyeR.IsMouseOver)
            {
                ReyeR.ValueChanged -= ReyeRxd;
                ReyeR.ValueChanged += ReyeRxd;
            }
        }

        private void ReyeGxd(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (ReyeG.Value.HasValue)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.RightEyeGreen), "float", ReyeG.Value.ToString());
            ReyeG.ValueChanged -= ReyeGxd;
        }

        private void ReyeG_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (ReyeG.IsKeyboardFocusWithin || ReyeG.IsMouseOver)
            {
                ReyeG.ValueChanged -= ReyeGxd;
                ReyeG.ValueChanged += ReyeGxd;
            }
        }

        private void ReyeBxd(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (ReyeB.Value.HasValue)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.RightEyeBlue), "float", ReyeB.Value.ToString());
            ReyeB.ValueChanged -= ReyeBxd;
        }

        private void ReyeB_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (ReyeB.IsKeyboardFocusWithin || ReyeB.IsMouseOver)
            {
                ReyeB.ValueChanged -= ReyeBxd;
                ReyeB.ValueChanged += ReyeBxd;
            }
        }

        private void SkinGreen_Checked(object sender, RoutedEventArgs e)
        {

        }
        private void LRXD(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (LR.Value.HasValue)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LimbalR), "float", LR.Value.ToString());
            LR.ValueChanged -= LRXD;
        }

        private void LR_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (LR.IsKeyboardFocusWithin || LR.IsMouseOver)
            {
                LR.ValueChanged -= LRXD;
                LR.ValueChanged += LRXD;
            }
        }
        private void GRXD(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (GR.Value.HasValue)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LimbalG), "float", GR.Value.ToString());
            GR.ValueChanged -= GRXD;
        }
        private void GR_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (GR.IsKeyboardFocusWithin || GR.IsMouseOver)
            {
                GR.ValueChanged -= GRXD;
                GR.ValueChanged += GRXD;
            }
        }

        private void BRXD(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (BR.Value.HasValue)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LimbalB), "float", BR.Value.ToString());
            BR.ValueChanged -= BRXD;
        }


        private void BR_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (BR.IsKeyboardFocusWithin || BR.IsMouseOver)
            {
                BR.ValueChanged -= BRXD;
                BR.ValueChanged += BRXD;
            }
        }

        private void ScaleXxD(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (ScaleX.Value.HasValue)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Scale.X), "float", ScaleX.Value.ToString());
            ScaleX.ValueChanged -= ScaleXxD;
        }

        private void ScaleX_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (ScaleX.IsKeyboardFocusWithin || ScaleX.IsMouseOver)
            {
                ScaleX.ValueChanged -= ScaleXxD;
                ScaleX.ValueChanged += ScaleXxD;
            }
        }

        private void ScaleYXd(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (ScaleY.Value.HasValue)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Scale.Y), "float", ScaleY.Value.ToString());
            ScaleY.ValueChanged -= ScaleYXd;
        }


        private void ScaleY_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (ScaleY.IsKeyboardFocusWithin || ScaleY.IsMouseOver)
            {
                ScaleY.ValueChanged -= ScaleYXd;
                ScaleY.ValueChanged += ScaleYXd;
            }
        }

        private void ScaleZxD(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (ScaleZ.Value.HasValue)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Scale.Z), "float", ScaleZ.Value.ToString());
            ScaleZ.ValueChanged -= ScaleZxD;
        }

        private void ScaleZ_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (ScaleZ.IsKeyboardFocusWithin || ScaleZ.IsMouseOver)
            {
                ScaleZ.ValueChanged -= ScaleZxD;
                ScaleZ.ValueChanged += ScaleZxD;
            }
        }
    }
}
