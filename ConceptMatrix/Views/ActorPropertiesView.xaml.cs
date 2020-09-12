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

namespace ConceptMatrix.Views
{
    /// <summary>
    /// Interaction logic for CharacterDetailsView4.xaml
    /// </summary>
    public partial class ActorPropertiesView : UserControl
    {
        public CharacterDetails CharacterDetails { get => (CharacterDetails)BaseViewModel.model; set => BaseViewModel.model = value; }
        public ActorPropertiesView()
        {
            InitializeComponent();
            if (SaveSettings.Default.HasBackground == false) PropBG.Opacity = 0;
            MainViewModel.actorPropView = this;
        }

        private void RedPChanged(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (RedP.Value.HasValue)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.SkinRedPigment), "float", RedP.Value.ToString());
            RedP.ValueChanged -= RedPChanged;
        }

        private void RedP_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (RedP.IsKeyboardFocusWithin || RedP.IsMouseOver)
            {
                RedP.ValueChanged -= RedPChanged;
                RedP.ValueChanged += RedPChanged;
            }
        }

        private void GreenPChanged(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (GreenP.Value.HasValue)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.SkinGreenPigment), "float", GreenP.Value.ToString());
            GreenP.ValueChanged -= GreenPChanged;
        }


        private void GreenP_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (GreenP.IsKeyboardFocusWithin || GreenP.IsMouseOver)
            {
                GreenP.ValueChanged -= GreenPChanged;
                GreenP.ValueChanged += GreenPChanged;
            }
        }

        private void BluePChanged(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (BlueP.Value.HasValue)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.SkinBluePigment), "float", BlueP.Value.ToString());
            BlueP.ValueChanged -= BluePChanged;
        }

        private void BlueP_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (BlueP.IsKeyboardFocusWithin || BlueP.IsMouseOver)
            {
                BlueP.ValueChanged -= BluePChanged;
                BlueP.ValueChanged += BluePChanged;
            }
        }

        private void RedGChanged(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (RedG.Value.HasValue)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.SkinRedGloss), "float", RedG.Value.ToString());
            RedG.ValueChanged -= RedGChanged;
        }

        private void RedG_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (RedG.IsKeyboardFocusWithin || RedG.IsMouseOver)
            {
                RedG.ValueChanged -= RedGChanged;
                RedG.ValueChanged += RedGChanged;
            }
        }

        private void GreenGChanged(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (GreenG.Value.HasValue)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.SkinGreenGloss), "float", GreenG.Value.ToString());
            GreenG.ValueChanged -= GreenGChanged;
        }

        private void GreenG_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (GreenG.IsKeyboardFocusWithin || GreenG.IsMouseOver)
            {
                GreenG.ValueChanged -= GreenGChanged;
                GreenG.ValueChanged += GreenGChanged;
            }
        }

        private void BlueGChanged(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (BlueG.Value.HasValue)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.SkinBlueGloss), "float", BlueG.Value.ToString());
            BlueG.ValueChanged -= BlueGChanged;
        }

        private void BlueG_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (BlueG.IsKeyboardFocusWithin || BlueG.IsMouseOver)
            {
                BlueG.ValueChanged -= BlueGChanged;
                BlueG.ValueChanged += BlueGChanged;
            }
        }

        private void LipsBrightChanged(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (LipsBright.Value.HasValue)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LipsBrightness), "float", LipsBright.Value.ToString());
            LipsBright.ValueChanged -= LipsBrightChanged;
        }

        private void LipsBright_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (LipsBright.IsKeyboardFocusWithin || LipsBright.IsMouseOver)
            {
                LipsBright.ValueChanged -= LipsBrightChanged;
                LipsBright.ValueChanged += LipsBrightChanged;
            }
        }

        private void LipsRedChanged(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (LipsRed.Value.HasValue)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LipsR), "float", LipsRed.Value.ToString());
            LipsRed.ValueChanged -= LipsRedChanged;
        }

        private void LipsRed_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (LipsRed.IsKeyboardFocusWithin || LipsRed.IsMouseOver)
            {
                LipsRed.ValueChanged -= LipsRedChanged;
                LipsRed.ValueChanged += LipsRedChanged;
            }
        }

        private void LipsGreenChanged(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (LipsGreen.Value.HasValue)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LipsG), "float", LipsGreen.Value.ToString());
            LipsGreen.ValueChanged -= LipsGreenChanged;
        }

        private void LipsGreen_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (LipsGreen.IsKeyboardFocusWithin || LipsGreen.IsMouseOver)
            {
                LipsGreen.ValueChanged -= LipsGreenChanged;
                LipsGreen.ValueChanged += LipsGreenChanged;
            }
        }

        private void LipsBlueChanged(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (LipsBlue.Value.HasValue)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LipsB), "float", LipsBlue.Value.ToString());
            LipsBlue.ValueChanged -= LipsBlueChanged;
        }

        private void LipsBlue_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (LipsBlue.IsKeyboardFocusWithin || LipsBlue.IsMouseOver)
            {
                LipsBlue.ValueChanged -= LipsBlueChanged;
                LipsBlue.ValueChanged += LipsBlueChanged;
            }
        }

        private void HairRedChanged(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (HairRed.Value.HasValue)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HairRedPigment), "float", HairRed.Value.ToString());
            HairRed.ValueChanged -= HairRedChanged;
        }

        private void HairRed_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (HairRed.IsKeyboardFocusWithin || HairRed.IsMouseOver)
            {
                HairRed.ValueChanged -= HairRedChanged;
                HairRed.ValueChanged += HairRedChanged;
            }
        }

        private void HairGreenChanged(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (HairGreen.Value.HasValue)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HairGreenPigment), "float", HairGreen.Value.ToString());
        }

        private void HairGreen_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (HairGreen.IsKeyboardFocusWithin || HairGreen.IsMouseOver)
            {
                HairGreen.ValueChanged -= HairGreenChanged;
                HairGreen.ValueChanged += HairGreenChanged;
            }
        }

        private void HairBlueChanged(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (HairBlue.Value.HasValue)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HairBluePigment), "float", HairBlue.Value.ToString());
        }

        private void HairBlue_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (HairBlue.IsKeyboardFocusWithin || HairBlue.IsMouseOver)
            {
                HairBlue.ValueChanged -= HairBlueChanged;
                HairBlue.ValueChanged += HairBlueChanged;
            }
        }

        private void HairRedGChanged(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (HairRedGlow.Value.HasValue)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HairGlowRed), "float", HairRedGlow.Value.ToString());
            HairRedGlow.ValueChanged -= HairRedGChanged;
        }

        private void HairRedGlow_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (HairRedGlow.IsKeyboardFocusWithin || HairRedGlow.IsMouseOver)
            {
                HairRedGlow.ValueChanged -= HairRedGChanged;
                HairRedGlow.ValueChanged += HairRedGChanged;
            }
        }

        private void HairGreenGChanged(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (HairGreenGlow.Value.HasValue)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HairGlowGreen), "float", HairGreenGlow.Value.ToString());
            HairGreenGlow.ValueChanged -= HairGreenGChanged;
        }

        private void HairGreenGlow_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (HairGreenGlow.IsKeyboardFocusWithin || HairGreenGlow.IsMouseOver)
            {
                HairGreenGlow.ValueChanged -= HairGreenGChanged;
                HairGreenGlow.ValueChanged += HairGreenGChanged;
            }
        }

        private void HairBlueGChanged(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (HairBlueGlow.Value.HasValue)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HairGlowBlue), "float", HairBlueGlow.Value.ToString());
        }

        private void HairBlueGlow_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (HairBlueGlow.IsKeyboardFocusWithin || HairBlueGlow.IsMouseOver)
            {
                HairBlueGlow.ValueChanged -= HairBlueGChanged;
                HairBlueGlow.ValueChanged += HairBlueGChanged;
            }
        }

        private void HRPChanged(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (HRP.Value.HasValue)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HighlightRedPigment), "float", HRP.Value.ToString());
            HRP.ValueChanged -= HRPChanged;
        }

        private void HRP_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (HRP.IsKeyboardFocusWithin || HRP.IsMouseOver)
            {
                HRP.ValueChanged -= HRPChanged;
                HRP.ValueChanged += HRPChanged;
            }
        }

        private void HGPChanged(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (HGP.Value.HasValue)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HighlightGreenPigment), "float", HGP.Value.ToString());
            HGP.ValueChanged -= HGPChanged;
        }

        private void HGP_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (HGP.IsKeyboardFocusWithin || HGP.IsMouseOver)
            {
                HGP.ValueChanged -= HGPChanged;
                HGP.ValueChanged += HGPChanged;
            }
        }

        private void HBPChanged(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (HBP.Value.HasValue)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HighlightBluePigment), "float", HBP.Value.ToString());
            HBP.ValueChanged -= HBPChanged;
        }

        private void HBP_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (HBP.IsKeyboardFocusWithin || HBP.IsMouseOver)
            {
                HBP.ValueChanged -= HBPChanged;
                HBP.ValueChanged += HBPChanged;
            }
        }

        private void LeyeRChanged(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (LEyeR.Value.HasValue)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LeftEyeRed), "float", LEyeR.Value.ToString());
            LEyeR.ValueChanged -= LeyeRChanged;
        }

        private void LEyeR_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (LEyeR.IsKeyboardFocusWithin || LEyeR.IsMouseOver)
            {
                LEyeR.ValueChanged -= LeyeRChanged;
                LEyeR.ValueChanged += LeyeRChanged;
            }
        }

        private void LEyeGChanged(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (LeyeG.Value.HasValue)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LeftEyeGreen), "float", LeyeG.Value.ToString());
            LeyeG.ValueChanged -= LEyeGChanged;
        }

        private void LeyeG_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (LeyeG.IsKeyboardFocusWithin || LeyeG.IsMouseOver)
            {
                LeyeG.ValueChanged -= LEyeGChanged;
                LeyeG.ValueChanged += LEyeGChanged;
            }
        }

        private void LeyebChanged(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (LeyeB.Value.HasValue)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LeftEyeBlue), "float", LeyeB.Value.ToString());
            LeyeB.ValueChanged -= LeyebChanged;
        }

        private void LeyeB_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (LeyeB.IsKeyboardFocusWithin || LeyeB.IsMouseOver)
            {
                LeyeB.ValueChanged -= LeyebChanged;
                LeyeB.ValueChanged += LeyebChanged;
            }
        }

        private void ReyeRChanged(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (ReyeR.Value.HasValue)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.RightEyeRed), "float", ReyeR.Value.ToString());
            ReyeR.ValueChanged -= ReyeRChanged;
        }

        private void ReyeR_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (ReyeR.IsKeyboardFocusWithin || ReyeR.IsMouseOver)
            {
                ReyeR.ValueChanged -= ReyeRChanged;
                ReyeR.ValueChanged += ReyeRChanged;
            }
        }

        private void ReyeGChanged(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (ReyeG.Value.HasValue)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.RightEyeGreen), "float", ReyeG.Value.ToString());
            ReyeG.ValueChanged -= ReyeGChanged;
        }

        private void ReyeG_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (ReyeG.IsKeyboardFocusWithin || ReyeG.IsMouseOver)
            {
                ReyeG.ValueChanged -= ReyeGChanged;
                ReyeG.ValueChanged += ReyeGChanged;
            }
        }

        private void ReyeBChanged(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (ReyeB.Value.HasValue)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.RightEyeBlue), "float", ReyeB.Value.ToString());
            ReyeB.ValueChanged -= ReyeBChanged;
        }

        private void ReyeB_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (ReyeB.IsKeyboardFocusWithin || ReyeB.IsMouseOver)
            {
                ReyeB.ValueChanged -= ReyeBChanged;
                ReyeB.ValueChanged += ReyeBChanged;
            }
        }

        private void SkinGreen_Checked(object sender, RoutedEventArgs e)
        {

        }
        private void LRChanged(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (LR.Value.HasValue)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LimbalR), "float", LR.Value.ToString());
            LR.ValueChanged -= LRChanged;
        }

        private void LR_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (LR.IsKeyboardFocusWithin || LR.IsMouseOver)
            {
                LR.ValueChanged -= LRChanged;
                LR.ValueChanged += LRChanged;
            }
        }
        private void GRChanged(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (GR.Value.HasValue)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LimbalG), "float", GR.Value.ToString());
            GR.ValueChanged -= GRChanged;
        }
        private void GR_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (GR.IsKeyboardFocusWithin || GR.IsMouseOver)
            {
                GR.ValueChanged -= GRChanged;
                GR.ValueChanged += GRChanged;
            }
        }

        private void BRCHanged(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (BR.Value.HasValue)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LimbalB), "float", BR.Value.ToString());
            BR.ValueChanged -= BRCHanged;
        }


        private void BR_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (BR.IsKeyboardFocusWithin || BR.IsMouseOver)
            {
                BR.ValueChanged -= BRCHanged;
                BR.ValueChanged += BRCHanged;
            }
        }

        private void ScaleXChanged(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (ScaleX.Value.HasValue)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Scale.X), "float", ScaleX.Value.ToString());
            ScaleX.ValueChanged -= ScaleXChanged;
        }

        private void ScaleX_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (ScaleX.IsKeyboardFocusWithin || ScaleX.IsMouseOver)
            {
                ScaleX.ValueChanged -= ScaleXChanged;
                ScaleX.ValueChanged += ScaleXChanged;
            }
        }

        private void ScaleYChanged(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (ScaleY.Value.HasValue)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Scale.Y), "float", ScaleY.Value.ToString());
            ScaleY.ValueChanged -= ScaleYChanged;
        }


        private void ScaleY_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (ScaleY.IsKeyboardFocusWithin || ScaleY.IsMouseOver)
            {
                ScaleY.ValueChanged -= ScaleYChanged;
                ScaleY.ValueChanged += ScaleYChanged;
            }
        }

        private void ScaleZChanged(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (ScaleZ.Value.HasValue)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Scale.Z), "float", ScaleZ.Value.ToString());
            ScaleZ.ValueChanged -= ScaleZChanged;
        }

        private void ScaleZ_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (ScaleZ.IsKeyboardFocusWithin || ScaleZ.IsMouseOver)
            {
                ScaleZ.ValueChanged -= ScaleZChanged;
                ScaleZ.ValueChanged += ScaleZChanged;
            }
        }
        private void PlayerAoBbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (PlayerAoBbox.Text.Length > PlayerAoBbox.MaxLength)
            {
                e.Handled = true;
                return;
            }
        }

        private void StatusEffectedChanged(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            var m = MemoryManager.Instance.MemLib;
            var c = Settings.Instance.Character;

            string GASG(params string[] args) => MemoryManager.GetAddressString(MemoryManager.Instance.GposeAddress, args);

            m.writeMemory(GASG(c.StatusEffect), "2bytes", (CharacterDetails.StatusEffect.value).ToString());
            StatusEffectBox.ValueChanged -= StatusEffectedChanged;
        }

        private void StatusEffectBox_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (StatusEffectBox.IsMouseOver || StatusEffectBox.IsKeyboardFocusWithin)
            {
                StatusEffectBox.ValueChanged -= StatusEffectedChanged;
                StatusEffectBox.ValueChanged += StatusEffectedChanged;
            }
        }

        private void StatusEffectBox2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var m = MemoryManager.Instance.MemLib;
            var c = Settings.Instance.Character;

            string GASG(params string[] args) => MemoryManager.GetAddressString(MemoryManager.Instance.GposeAddress, args);

            if (StatusEffectBox2.IsKeyboardFocusWithin || StatusEffectBox2.IsMouseOver)
            {
                if (StatusEffectBox2.SelectedIndex >= 0)
                {
                    var status = (ExdCsvReader.CMStatus)StatusEffectBox2.SelectedItem;
                    CharacterDetails.StatusEffect.value = (int)status.Id;
                    m.writeMemory(GASG(c.StatusEffect), "int", status.Id.ToString());
                }
            }
        }

        private void StatusEffectZero_Click(object sender, RoutedEventArgs e)
        {
            var m = MemoryManager.Instance.MemLib;
            var c = Settings.Instance.Character;

            string GASG(params string[] args) => MemoryManager.GetAddressString(MemoryManager.Instance.GposeAddress, args);

            m.writeMemory(GASG(c.StatusEffect), "2bytes", "0");
        }

        private void AoBButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                byte[] haha;
                haha = MemoryManager.StringToByteArray(PlayerAoBbox.Text.Replace(" ", string.Empty));

                if (CharacterDetails.Race.freeze == true) { CharacterDetails.Race.freeze = false; CharacterDetails.Race.Activated = true; }
                if (CharacterDetails.Gender.freeze == true) { CharacterDetails.Gender.freeze = false; CharacterDetails.Gender.Activated = true; }
                if (CharacterDetails.BodyType.freeze == true) { CharacterDetails.BodyType.freeze = false; CharacterDetails.BodyType.Activated = true; }
                if (CharacterDetails.RHeight.freeze == true) { CharacterDetails.RHeight.freeze = false; CharacterDetails.RHeight.Activated = true; }
                if (CharacterDetails.Clan.freeze == true) { CharacterDetails.Clan.freeze = false; CharacterDetails.Clan.Activated = true; }
                if (CharacterDetails.Head.freeze == true) { CharacterDetails.Head.freeze = false; CharacterDetails.Head.Activated = true; }
                if (CharacterDetails.Hair.freeze == true) { CharacterDetails.Hair.freeze = false; CharacterDetails.Hair.Activated = true; }
                if (CharacterDetails.HighlightTone.freeze == true) { CharacterDetails.HighlightTone.freeze = false; CharacterDetails.HighlightTone.Activated = true; }
                if (CharacterDetails.Skintone.freeze == true) { CharacterDetails.Skintone.freeze = false; CharacterDetails.Skintone.Activated = true; }
                if (CharacterDetails.RightEye.freeze == true) { CharacterDetails.RightEye.freeze = false; CharacterDetails.RightEye.Activated = true; }
                if (CharacterDetails.LeftEye.freeze == true) { CharacterDetails.LeftEye.freeze = false; CharacterDetails.LeftEye.Activated = true; }
                if (CharacterDetails.HairTone.freeze == true) { CharacterDetails.HairTone.freeze = false; CharacterDetails.HairTone.Activated = true; }
                if (CharacterDetails.FacePaint.freeze == true) { CharacterDetails.FacePaint.freeze = false; CharacterDetails.FacePaint.Activated = true; }
                if (CharacterDetails.FacePaintColor.freeze == true) { CharacterDetails.FacePaintColor.freeze = false; CharacterDetails.FacePaintColor.Activated = true; }
                if (CharacterDetails.EyeBrowType.freeze == true) { CharacterDetails.EyeBrowType.freeze = false; CharacterDetails.EyeBrowType.Activated = true; }
                if (CharacterDetails.Nose.freeze == true) { CharacterDetails.Nose.freeze = false; CharacterDetails.Nose.Activated = true; }
                if (CharacterDetails.Eye.freeze == true) { CharacterDetails.Eye.freeze = false; CharacterDetails.Eye.Activated = true; }
                if (CharacterDetails.Jaw.freeze == true) { CharacterDetails.Jaw.freeze = false; CharacterDetails.Jaw.Activated = true; }
                if (CharacterDetails.Lips.freeze == true) { CharacterDetails.Lips.freeze = false; CharacterDetails.Lips.Activated = true; }
                if (CharacterDetails.LipsTone.freeze == true) { CharacterDetails.LipsTone.freeze = false; CharacterDetails.LipsTone.Activated = true; }
                if (CharacterDetails.TailorMuscle.freeze == true) { CharacterDetails.TailorMuscle.freeze = false; CharacterDetails.TailorMuscle.Activated = true; }
                if (CharacterDetails.TailType.freeze == true) { CharacterDetails.TailType.freeze = false; CharacterDetails.TailType.Activated = true; }
                if (CharacterDetails.FacialFeatures.freeze == true) { CharacterDetails.FacialFeatures.freeze = false; CharacterDetails.FacialFeatures.Activated = true; }
                if (CharacterDetails.RBust.freeze == true) { CharacterDetails.RBust.freeze = false; CharacterDetails.RBust.Activated = true; }
                WriteCurrentCustomize(haha);
            }
            catch (Exception exc)
            {
                MessageBox.Show("One or more fields were not formatted correctly.\n\n" + exc, " Error " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void WriteCurrentCustomize(byte[] Haha)
        {
            if (Haha == null)
            {

                if (CharacterDetails.Race.Activated == true) { CharacterDetails.Race.freeze = true; CharacterDetails.Race.Activated = false; }
                if (CharacterDetails.Gender.Activated == true) { CharacterDetails.Gender.freeze = true; CharacterDetails.Gender.Activated = false; }
                if (CharacterDetails.BodyType.Activated == true) { CharacterDetails.BodyType.freeze = true; CharacterDetails.BodyType.Activated = false; }
                if (CharacterDetails.RHeight.Activated == true) { CharacterDetails.RHeight.freeze = true; CharacterDetails.RHeight.Activated = false; }
                if (CharacterDetails.Clan.Activated == true) { CharacterDetails.Clan.freeze = true; CharacterDetails.Clan.Activated = false; }
                if (CharacterDetails.Head.Activated == true) { CharacterDetails.Head.freeze = true; CharacterDetails.Head.Activated = false; }
                if (CharacterDetails.Hair.Activated == true) { CharacterDetails.Hair.freeze = true; CharacterDetails.Hair.Activated = false; }
                if (CharacterDetails.HighlightTone.Activated == true) { CharacterDetails.HighlightTone.freeze = true; CharacterDetails.HighlightTone.Activated = false; }
                if (CharacterDetails.Skintone.Activated == true) { CharacterDetails.Skintone.freeze = true; CharacterDetails.Skintone.Activated = false; }
                if (CharacterDetails.RightEye.Activated == true) { CharacterDetails.RightEye.freeze = true; CharacterDetails.RightEye.Activated = false; }
                if (CharacterDetails.LeftEye.Activated == true) { CharacterDetails.LeftEye.freeze = true; CharacterDetails.LeftEye.Activated = false; }
                if (CharacterDetails.HairTone.Activated == true) { CharacterDetails.HairTone.freeze = true; CharacterDetails.HairTone.Activated = false; }
                if (CharacterDetails.FacePaint.Activated == true) { CharacterDetails.FacePaint.freeze = true; CharacterDetails.FacePaint.Activated = false; }
                if (CharacterDetails.FacePaintColor.Activated == true) { CharacterDetails.FacePaintColor.freeze = true; CharacterDetails.FacePaintColor.Activated = false; }
                if (CharacterDetails.EyeBrowType.Activated == true) { CharacterDetails.EyeBrowType.freeze = true; CharacterDetails.EyeBrowType.Activated = false; }
                if (CharacterDetails.Nose.Activated == true) { CharacterDetails.Nose.freeze = true; CharacterDetails.Nose.Activated = false; }
                if (CharacterDetails.Eye.Activated == true) { CharacterDetails.Eye.freeze = true; CharacterDetails.Eye.Activated = false; }
                if (CharacterDetails.Jaw.Activated == true) { CharacterDetails.Jaw.freeze = true; CharacterDetails.Jaw.Activated = false; }
                if (CharacterDetails.Lips.Activated == true) { CharacterDetails.Lips.freeze = true; CharacterDetails.Lips.Activated = false; }
                if (CharacterDetails.LipsTone.Activated == true) { CharacterDetails.LipsTone.freeze = true; CharacterDetails.LipsTone.Activated = false; }
                if (CharacterDetails.TailorMuscle.Activated == true) { CharacterDetails.TailorMuscle.freeze = true; CharacterDetails.TailorMuscle.Activated = false; }
                if (CharacterDetails.TailType.Activated == true) { CharacterDetails.TailType.freeze = true; CharacterDetails.TailType.Activated = false; }
                if (CharacterDetails.FacialFeatures.Activated == true) { CharacterDetails.FacialFeatures.freeze = true; CharacterDetails.FacialFeatures.Activated = false; }
                if (CharacterDetails.RBust.Activated == true) { CharacterDetails.RBust.freeze = true; CharacterDetails.RBust.Activated = false; }
                return;
            }
            MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Race), Haha);
            Task.Delay(25).Wait();

            if (CharacterDetails.Race.Activated == true) { CharacterDetails.Race.freeze = true; CharacterDetails.Race.Activated = false; }
            if (CharacterDetails.Gender.Activated == true) { CharacterDetails.Gender.freeze = true; CharacterDetails.Gender.Activated = false; }
            if (CharacterDetails.BodyType.Activated == true) { CharacterDetails.BodyType.freeze = true; CharacterDetails.BodyType.Activated = false; }
            if (CharacterDetails.RHeight.Activated == true) { CharacterDetails.RHeight.freeze = true; CharacterDetails.RHeight.Activated = false; }
            if (CharacterDetails.Clan.Activated == true) { CharacterDetails.Clan.freeze = true; CharacterDetails.Clan.Activated = false; }
            if (CharacterDetails.Head.Activated == true) { CharacterDetails.Head.freeze = true; CharacterDetails.Head.Activated = false; }
            if (CharacterDetails.Hair.Activated == true) { CharacterDetails.Hair.freeze = true; CharacterDetails.Hair.Activated = false; }
            if (CharacterDetails.HighlightTone.Activated == true) { CharacterDetails.HighlightTone.freeze = true; CharacterDetails.HighlightTone.Activated = false; }
            if (CharacterDetails.Skintone.Activated == true) { CharacterDetails.Skintone.freeze = true; CharacterDetails.Skintone.Activated = false; }
            if (CharacterDetails.RightEye.Activated == true) { CharacterDetails.RightEye.freeze = true; CharacterDetails.RightEye.Activated = false; }
            if (CharacterDetails.LeftEye.Activated == true) { CharacterDetails.LeftEye.freeze = true; CharacterDetails.LeftEye.Activated = false; }
            if (CharacterDetails.HairTone.Activated == true) { CharacterDetails.HairTone.freeze = true; CharacterDetails.HairTone.Activated = false; }
            if (CharacterDetails.FacePaint.Activated == true) { CharacterDetails.FacePaint.freeze = true; CharacterDetails.FacePaint.Activated = false; }
            if (CharacterDetails.FacePaintColor.Activated == true) { CharacterDetails.FacePaintColor.freeze = true; CharacterDetails.FacePaintColor.Activated = false; }
            if (CharacterDetails.EyeBrowType.Activated == true) { CharacterDetails.EyeBrowType.freeze = true; CharacterDetails.EyeBrowType.Activated = false; }
            if (CharacterDetails.Nose.Activated == true) { CharacterDetails.Nose.freeze = true; CharacterDetails.Nose.Activated = false; }
            if (CharacterDetails.Eye.Activated == true) { CharacterDetails.Eye.freeze = true; CharacterDetails.Eye.Activated = false; }
            if (CharacterDetails.Jaw.Activated == true) { CharacterDetails.Jaw.freeze = true; CharacterDetails.Jaw.Activated = false; }
            if (CharacterDetails.Lips.Activated == true) { CharacterDetails.Lips.freeze = true; CharacterDetails.Lips.Activated = false; }
            if (CharacterDetails.LipsTone.Activated == true) { CharacterDetails.LipsTone.freeze = true; CharacterDetails.LipsTone.Activated = false; }
            if (CharacterDetails.TailorMuscle.Activated == true) { CharacterDetails.TailorMuscle.freeze = true; CharacterDetails.TailorMuscle.Activated = false; }
            if (CharacterDetails.TailType.Activated == true) { CharacterDetails.TailType.freeze = true; CharacterDetails.TailType.Activated = false; }
            if (CharacterDetails.FacialFeatures.Activated == true) { CharacterDetails.FacialFeatures.freeze = true; CharacterDetails.FacialFeatures.Activated = false; }
            if (CharacterDetails.RBust.Activated == true) { CharacterDetails.RBust.freeze = true; CharacterDetails.RBust.Activated = false; }
        }
    }
}
