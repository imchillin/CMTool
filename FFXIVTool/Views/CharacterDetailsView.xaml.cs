using FFXIVTool.Models;
using FFXIVTool.Utility;
using FFXIVTool.ViewModel;
using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Threading;

namespace FFXIVTool.Views
{
    /// <summary>
    /// Interaction logic for CharacterDetailsView.xaml
    /// </summary>
    public partial class CharacterDetailsView : UserControl
    {
        public static CmpReader _colorMap = new CmpReader(Properties.Resources.human);
        public static ExdCsvReader _exdProvider = new ExdCsvReader();
        public CharacterDetails CharacterDetails { get => (CharacterDetails)BaseViewModel.model; set => BaseViewModel.model = value; }
        public CharacterDetailsView()
        {
            InitializeComponent();
            _exdProvider.RaceList();
            _exdProvider.TribeList();
            _exdProvider.MakeCharaMakeFeatureList();
            _exdProvider.MonsterList();
            _exdProvider.MakeWeatherList();
            _exdProvider.MakeWeatherRateList();
            _exdProvider.MakeTerritoryTypeList();
            ExdCsvReader.MonsterX = _exdProvider.Monsters.Values.ToArray();
            DispatcherTimer timer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(40) };
            timer.Tick += delegate
            {
                for (int i = 0; i < _exdProvider.Races.Count; i++)
                {
                    RaceBox.Items.Add(_exdProvider.Races[i].Name);
                }
                for (int i = 0; i < _exdProvider.Tribes.Count; i++)
                {
                    ClanBox.Items.Add(_exdProvider.Tribes[i].Name);
                }
                foreach (ExdCsvReader.Monster xD in ExdCsvReader.MonsterX)
                {
                    if (xD.Real == true)
                    {
                        SpecialControl.ModelBox.Items.Add(new ExdCsvReader.Monster
                        {
                            Index = Convert.ToInt32(xD.Index),
                            Name = xD.Name.ToString()
                        });
                    }
                }
                timer.IsEnabled = false;
            };
            timer.Start();
        }

        private void NumericUpDown_TextInput(object sender, TextCompositionEventArgs e)
        {

        }
        private void Height2x_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (Height2x.Value.HasValue)
                if (Height2x.Value > 0) MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Height), "float", Height2x.Value.ToString());
            Height2x.ValueChanged -= Height2x_ValueChanged;
        }
        private void Height2_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (Height2x.Value.HasValue)
                if (Height2x.Value > 0) MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Height), "float", Height2x.Value.ToString());
            HeightSlider.ValueChanged -= Height2_ValueChanged;
        }
        private void Height2x_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (Height2x.IsMouseOver || Height2x.IsKeyboardFocusWithin)
            {
                Height2x.ValueChanged -= Height2x_ValueChanged;
                Height2x.ValueChanged += Height2x_ValueChanged;
            }
            if (HeightSlider.IsKeyboardFocusWithin || HeightSlider.IsMouseOver)
            {
                HeightSlider.ValueChanged -= Height2_ValueChanged;
                HeightSlider.ValueChanged += Height2_ValueChanged;
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

        private void AoBButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                byte[] haha;
                haha = MemoryManager.StringToByteArray(PlayerAoBbox.Text.Replace(" ", string.Empty));
                if (CharacterDetails.Highlights.Activated == true) { CharacterDetails.Highlights.freeze = true; CharacterDetails.Highlights.Activated = false; }
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
                MessageBox.Show("One or more fields were not formatted correctly.\n\n" + exc, " Error " + Assembly.GetExecutingAssembly().GetName().Version, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void WriteCurrentCustomize(byte[] Haha)
        {
            if (Haha == null)
            {
                if (CharacterDetails.Highlights.Activated == true) { CharacterDetails.Highlights.freeze = true; CharacterDetails.Highlights.Activated = false; }
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
            if (CharacterDetails.Highlights.Activated == true) { CharacterDetails.Highlights.freeze = true; CharacterDetails.Highlights.Activated = false; }
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
        private void DigitCheckInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1))
                e.Handled = true;
        }

        private void NameBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key != System.Windows.Input.Key.Enter) return;
            e.Handled = true;
            CharacterDetails.Name.value = NameBox.Text.Replace("\0", string.Empty);
            MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Name), "string", NameBox.Text + "\0\0\0\0");
        }

        private void BustXUpDown_SourceUpdated(object sender, DataTransferEventArgs e)
        {
            if (BustXSlider.IsKeyboardFocusWithin || BustXSlider.IsMouseOver)
            {
                BustXSlider.ValueChanged -= BustX2a;
                BustXSlider.ValueChanged += BustX2a;
            }
            if (BustXUpDown.IsMouseOver || BustXUpDown.IsKeyboardFocusWithin)
            {
                BustXUpDown.ValueChanged -= BustX2s;
                BustXUpDown.ValueChanged += BustX2s;
            }
        }
        private void BustX2s(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (BustXUpDown.Value > 0)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bust.Base, Settings.Instance.Character.Body.Bust.X), "float", BustXUpDown.Value.ToString());
            BustXUpDown.ValueChanged -= BustX2s;
        }
        private void BustX2a(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (BustXUpDown.Value > 0)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bust.Base, Settings.Instance.Character.Body.Bust.X), "float", BustXSlider.Value.ToString());
            BustXSlider.ValueChanged -= BustX2a;
        }

        private void BustYUpDown_SourceUpdated(object sender, DataTransferEventArgs e)
        {
            if (BustYSlider.IsKeyboardFocusWithin || BustYSlider.IsMouseOver)
            {
                BustYSlider.ValueChanged -= BustY1;
                BustYSlider.ValueChanged += BustY1;
            }
            if (BustYUpDown.IsKeyboardFocusWithin || BustYUpDown.IsMouseOver)
            {
                BustYUpDown.ValueChanged -= BustY2_;
                BustYUpDown.ValueChanged += BustY2_;
            }
        }
        private void BustY2_(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (BustYUpDown.Value > 0)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bust.Base, Settings.Instance.Character.Body.Bust.Y), "float", BustYUpDown.Value.ToString());
            BustYUpDown.ValueChanged -= BustY2_;
        }
        private void BustY1(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (BustYUpDown.Value > 0)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bust.Base, Settings.Instance.Character.Body.Bust.Y), "float", BustYSlider.Value.ToString());
            BustYSlider.ValueChanged -= BustY1;
        }

        private void BustZUpDown_SourceUpdated(object sender, DataTransferEventArgs e)
        {
            if (BustZUpDown.IsKeyboardFocusWithin || BustZUpDown.IsMouseOver)
            {
                BustZUpDown.ValueChanged -= BustZ2_;
                BustZUpDown.ValueChanged += BustZ2_;
            }
            if (BustZSlider.IsKeyboardFocusWithin || BustZSlider.IsMouseOver)
            {
                BustZSlider.ValueChanged -= BustZ1;
                BustZSlider.ValueChanged += BustZ1;
            }
        }
        private void BustZ2_(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (BustZUpDown.Value > 0)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bust.Base, Settings.Instance.Character.Body.Bust.Z), "float", BustZUpDown.Value.ToString());
            BustZUpDown.ValueChanged -= BustZ2_;
        }
        private void BustZ1(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (BustZUpDown.Value > 0)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bust.Base, Settings.Instance.Character.Body.Bust.Z), "float", BustZSlider.Value.ToString());
            BustZSlider.ValueChanged -= BustZ1;
        }

        private void RotationUpDown_SourceUpdated(object sender, DataTransferEventArgs e)
        {
            if (RotationUpDown.IsKeyboardFocusWithin || RotationUpDown.IsMouseOver)
            {
                RotationUpDown.ValueChanged -= Rot1V;
                RotationUpDown.ValueChanged += Rot1V;
            }
        }
        private void Rot1V(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (RotationUpDown.Value.HasValue)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Position.Rotation), "float", RotationUpDown.Value.ToString());
            RotationUpDown.ValueChanged -= Rot1V;
        }

        private void RotationUpDown2_SourceUpdated(object sender, DataTransferEventArgs e)
        {
            if (RotationUpDown2.IsKeyboardFocusWithin || RotationUpDown2.IsMouseOver)
            {
                RotationUpDown2.ValueChanged -= Rot2V;
                RotationUpDown2.ValueChanged += Rot2V;
            }
        }
        private void Rot2V(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (RotationUpDown2.Value.HasValue)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Position.Rotation2), "float", RotationUpDown2.Value.ToString());
            RotationUpDown2.ValueChanged -= Rot2V;
        }

        private void RotationUpDown3_SourceUpdated(object sender, DataTransferEventArgs e)
        {
            if (RotationUpDown3.IsKeyboardFocusWithin || RotationUpDown3.IsMouseOver)
            {
                RotationUpDown3.ValueChanged -= Rot3V;
                RotationUpDown3.ValueChanged += Rot3V;
            }
        }
        private void Rot3V(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (RotationUpDown3.Value.HasValue)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Position.Rotation3), "float", RotationUpDown3.Value.ToString());
            RotationUpDown3.ValueChanged -= Rot3V;
        }
        private void RotationUpDown4_SourceUpdated(object sender, DataTransferEventArgs e)
        {
            if (RotationUpDown4.IsKeyboardFocusWithin || RotationUpDown4.IsMouseOver)
            {
                RotationUpDown4.ValueChanged -= Rot4V;
                RotationUpDown4.ValueChanged += Rot4V;
            }
        }
        private void Rot4V(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (RotationUpDown4.Value.HasValue)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Position.Rotation4), "float", RotationUpDown4.Value.ToString());
            RotationUpDown4.ValueChanged -= Rot4V;
        }

        private void PosX_SourceUpdated(object sender, DataTransferEventArgs e)
        {
            if (PosX.IsKeyboardFocusWithin || PosX.IsMouseOver)
            {
                PosX.ValueChanged -= XPos2_V;
                PosX.ValueChanged += XPos2_V;
            }
        }
        private void XPos2_V(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (PosX.Value.HasValue)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Position.X), "float", PosX.Value.ToString());
            PosX.ValueChanged -= XPos2_V;
        }

        private void PosY_SourceUpdated(object sender, DataTransferEventArgs e)
        {
            if (PosY.IsKeyboardFocusWithin || PosY.IsMouseOver)
            {
                PosY.ValueChanged -= Ypos2_V;
                PosY.ValueChanged += Ypos2_V;
            }
        }
        private void Ypos2_V(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (PosY.Value.HasValue)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Position.Y), "float", PosY.Value.ToString());
            PosY.ValueChanged -= Ypos2_V;
        }

        private void PosZ_SourceUpdated(object sender, DataTransferEventArgs e)
        {
            if (PosZ.IsKeyboardFocusWithin || PosZ.IsMouseOver)
            {
                PosZ.ValueChanged -= Zpos2_V;
                PosZ.ValueChanged += Zpos2_V;
            }
        }
        private void Zpos2_V(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (PosZ.Value.HasValue)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Position.Z), "float", PosZ.Value.ToString());
            PosZ.ValueChanged -= Zpos2_V;
        }

        private void TailSz(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (TailSize.Value.HasValue)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.TailSize), "float", TailSize.Value.ToString());
            TailSize.ValueChanged -= TailSz;
        }

        private void TailSize_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (TailSize.IsMouseOver || TailSize.IsKeyboardFocusWithin)
            {
                TailSize.ValueChanged -= TailSz;
                TailSize.ValueChanged += TailSz;
            }
        }

        private void MuscleT(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (Muscletone.Value.HasValue)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.MuscleTone), "float", Muscletone.Value.ToString());
            Muscletone.ValueChanged -= MuscleT;
        }

        private void Muscletone_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (Muscletone.IsMouseOver || Muscletone.IsKeyboardFocusWithin)
            {
                Muscletone.ValueChanged -= MuscleT;
                Muscletone.ValueChanged += MuscleT;
            }
        }

        private void Transparency_SourceUpdated(object sender, DataTransferEventArgs e)
        {
            if (Transparency.IsMouseOver || Transparency.IsKeyboardFocusWithin)
            {
                Transparency.ValueChanged -= Transps;
                Transparency.ValueChanged += Transps;
            }
        }
        private void Transps(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (Transparency.Value.HasValue)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Transparency), "float", Transparency.Value.ToString());
            Transparency.ValueChanged -= Transps;
        }

        private void EmoteSearch_Click(object sender, RoutedEventArgs e)
        {
            EmoteFlyouts.IsOpen = !EmoteFlyouts.IsOpen;
        }

        private void CameraHeight_SourceUpdated(object sender, DataTransferEventArgs e)
        {
            if (CameraHeight.IsMouseOver || CameraHeight.IsKeyboardFocusWithin)
            {
                CameraHeight.ValueChanged -= CameraHeight_;
                CameraHeight.ValueChanged += CameraHeight_;
            }
        }

        private void CameraHeight_(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (CameraHeight.Value.HasValue)
                if (CameraHeight.IsMouseOver || CameraHeight.IsKeyboardFocusWithin)
                    MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.GposeAddress, Settings.Instance.Character.CameraHeight), "float", CameraHeight.Value.ToString());
            CameraHeight.ValueChanged -= CameraHeight_;
        }

        private void CamX_SourceUpdated(object sender, DataTransferEventArgs e)
        {
            if (CamX.IsMouseOver || CamX.IsKeyboardFocusWithin)
            {
                CamX.ValueChanged -= CamX_;
                CamX.ValueChanged += CamX_;
            }
        }

        private void CamX_(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (CamX.Value.HasValue)
                if (CamX.IsMouseOver || CamX.IsKeyboardFocusWithin)
                    MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.GposeAddress, Settings.Instance.Character.CamX), "float", CamX.Value.ToString());
            CamX.ValueChanged -= CamX_;
        }

        private void CamY_SourceUpdated(object sender, DataTransferEventArgs e)
        {
            if (CamY.IsMouseOver || CamY.IsKeyboardFocusWithin)
            {
                CamY.ValueChanged -= CamY_;
                CamY.ValueChanged += CamY_;
            }
        }

        private void CamY_(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (CamY.Value.HasValue)
                if (CamY.IsMouseOver || CamY.IsKeyboardFocusWithin)
                    MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.GposeAddress, Settings.Instance.Character.CamY), "float", CamY.Value.ToString());
            CamY.ValueChanged -= CamY_;
        }

        private void CamZ_SourceUpdated(object sender, DataTransferEventArgs e)
        {
            if (CamZ.IsMouseOver || CamZ.IsKeyboardFocusWithin)
            {
                CamZ.ValueChanged -= CamZ_;
                CamZ.ValueChanged += CamZ_;
            }
        }

        private void CamZ_(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (CamZ.Value.HasValue)
                if (CamZ.IsMouseOver || CamZ.IsKeyboardFocusWithin)
                    MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.GposeAddress, Settings.Instance.Character.CamZ), "float", CamZ.Value.ToString());
            CamZ.ValueChanged -= CamZ_;
        }

        private void SkinSearch_Click(object sender, RoutedEventArgs e)
        {
            if (SpecialControl.IsOpen)
            {
                if (!SpecialControl.ColorTab.IsSelected || SpecialControl.ClanBox.SelectedIndex != 0)
                {
                    SpecialControl.ColorTab.IsSelected = true;
                    SpecialControl.CharaMakeColorSelector(_colorMap, SpecialControl.GetSkin(CharacterDetails.Clan.value, Convert.ToBoolean(CharacterDetails.Gender.value)), 192);
                    SpecialControl.ClanBox.SelectedIndex = 0;
                }
                else SpecialControl.IsOpen = !SpecialControl.IsOpen;
            }
            else
            {
                SpecialControl.IsOpen = !SpecialControl.IsOpen;
                SpecialControl.ColorTab.IsSelected = true;
                SpecialControl.CharaMakeColorSelector(_colorMap, SpecialControl.GetSkin(CharacterDetails.Clan.value, Convert.ToBoolean(CharacterDetails.Gender.value)), 192);
                SpecialControl.ClanBox.SelectedIndex = 0;
            }
        }

        private void HairSelectButton_Click(object sender, RoutedEventArgs e)
        {
            if (SpecialControl.IsOpen)
            {
                if (!SpecialControl.ColorTab.IsSelected || SpecialControl.ClanBox.SelectedIndex != 1)
                {
                    SpecialControl.ColorTab.IsSelected = true;
                    SpecialControl.CharaMakeColorSelector(_colorMap, SpecialControl.GetHair(CharacterDetails.Clan.value, Convert.ToBoolean(CharacterDetails.Gender.value)), 192);
                    SpecialControl.ClanBox.SelectedIndex = 1;
                }
                else SpecialControl.IsOpen = !SpecialControl.IsOpen;
            } else
            {
                SpecialControl.IsOpen = !SpecialControl.IsOpen;
                SpecialControl.ColorTab.IsSelected = true;
                SpecialControl.CharaMakeColorSelector(_colorMap, SpecialControl.GetHair(CharacterDetails.Clan.value, Convert.ToBoolean(CharacterDetails.Gender.value)), 192);
                SpecialControl.ClanBox.SelectedIndex = 1;
            }
        }

        private void HighlightcolorSearch_Click(object sender, RoutedEventArgs e)
        {
            if (SpecialControl.IsOpen)
            {
                if (!SpecialControl.ColorTab.IsSelected || SpecialControl.ClanBox.SelectedIndex != 2)
                {
                    SpecialControl.ColorTab.IsSelected = true;
                    SpecialControl.CharaMakeColorSelector(_colorMap, 256, 192);
                    SpecialControl.ClanBox.SelectedIndex = 2;
                }
                else SpecialControl.IsOpen = !SpecialControl.IsOpen;
            }
            else
            {
                SpecialControl.IsOpen = !SpecialControl.IsOpen;
                SpecialControl.ColorTab.IsSelected = true;
                SpecialControl.CharaMakeColorSelector(_colorMap, 256, 192);
                SpecialControl.ClanBox.SelectedIndex = 2;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (SpecialControl.IsOpen)
            {
                if (!SpecialControl.ColorTab.IsSelected || SpecialControl.ClanBox.SelectedIndex != 3)
                {
                    SpecialControl.ColorTab.IsSelected = true;
                    SpecialControl.CharaMakeColorSelector(_colorMap, 512, 96);
                    SpecialControl.ClanBox.SelectedIndex = 3;
                }
                else SpecialControl.IsOpen = !SpecialControl.IsOpen;
            }
            else
            {
                SpecialControl.IsOpen = !SpecialControl.IsOpen;
                SpecialControl.ColorTab.IsSelected = true;
                SpecialControl.CharaMakeColorSelector(_colorMap, 512, 96);
                SpecialControl.ClanBox.SelectedIndex = 3;
            }
        }

        private void RightEyeSearch_Click(object sender, RoutedEventArgs e)
        {
            if (SpecialControl.IsOpen)
            {
                if (!SpecialControl.ColorTab.IsSelected || SpecialControl.ClanBox.SelectedIndex != 4)
                {
                    SpecialControl.ColorTab.IsSelected = true;
                    SpecialControl.CharaMakeColorSelector(_colorMap, 0, 192);
                    SpecialControl.ClanBox.SelectedIndex = 4;
                }
                else SpecialControl.IsOpen = !SpecialControl.IsOpen;
            }
            else
            {
                SpecialControl.IsOpen = !SpecialControl.IsOpen;
                SpecialControl.ColorTab.IsSelected = true;
                SpecialControl.CharaMakeColorSelector(_colorMap, 0, 192);
                SpecialControl.ClanBox.SelectedIndex = 4;
            }
        }

        private void LeftEyeSearch_Click(object sender, RoutedEventArgs e)
        {
            if (SpecialControl.IsOpen)
            {
                if (!SpecialControl.ColorTab.IsSelected || SpecialControl.ClanBox.SelectedIndex != 5)
                {
                    SpecialControl.ColorTab.IsSelected = true;
                    SpecialControl.CharaMakeColorSelector(_colorMap, 0, 192);
                    SpecialControl.ClanBox.SelectedIndex = 5;
                }
                else SpecialControl.IsOpen = !SpecialControl.IsOpen;
            }
            else
            {
                SpecialControl.IsOpen = !SpecialControl.IsOpen;
                SpecialControl.ColorTab.IsSelected = true;
                SpecialControl.CharaMakeColorSelector(_colorMap, 0, 192);
                SpecialControl.ClanBox.SelectedIndex = 5;
            }
        }

        private void FacePaint_Color_Click(object sender, RoutedEventArgs e)
        {
            if (SpecialControl.IsOpen)
            {
                if (!SpecialControl.ColorTab.IsSelected || SpecialControl.ClanBox.SelectedIndex != 6)
                {
                    SpecialControl.ColorTab.IsSelected = true;
                    SpecialControl.CharaMakeColorSelector(_colorMap, 1152, 96);
                    SpecialControl.ClanBox.SelectedIndex = 6;
                }
                else SpecialControl.IsOpen = !SpecialControl.IsOpen;
            }
            else
            {
                SpecialControl.IsOpen = !SpecialControl.IsOpen;
                SpecialControl.ColorTab.IsSelected = true;
                SpecialControl.CharaMakeColorSelector(_colorMap, 1152, 96);
                SpecialControl.ClanBox.SelectedIndex = 6;
            }
        }

        private void HairSelectButton_Click_1(object sender, RoutedEventArgs e)
        {
            if (SpecialControl.IsOpen)
            {
                if (!SpecialControl.HairTab.IsSelected)
                {
                    SpecialControl.HairTab.IsSelected = true;
                    SpecialControl.CharaMakeFeatureSelector(CharacterDetails.Clan.value, CharacterDetails.Gender.value, _exdProvider);
                }
                else SpecialControl.IsOpen = !SpecialControl.IsOpen;
            }
            else
            {
                SpecialControl.IsOpen = !SpecialControl.IsOpen;
                SpecialControl.HairTab.IsSelected = true;
                SpecialControl.CharaMakeFeatureSelector(CharacterDetails.Clan.value, CharacterDetails.Gender.value, _exdProvider);
            }
        }

        private void ModelTypeButton_Click(object sender, RoutedEventArgs e)
        {
            if (SpecialControl.IsOpen)
            {
                if (!SpecialControl.ModelType.IsSelected)
                {
                    SpecialControl.ModelType.IsSelected = true;
                }
                else SpecialControl.IsOpen = !SpecialControl.IsOpen;
            }
            else
            {
                SpecialControl.IsOpen = !SpecialControl.IsOpen;
                SpecialControl.ModelType.IsSelected = true;
            }
        }

        private void HighLightButton_Checked(object sender, RoutedEventArgs e)
        {
            CharacterDetails.Highlights.value = 128;
            MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Highlights), "byte", "80");
        }

        private void HighLightButton_Unchecked(object sender, RoutedEventArgs e)
        {
            CharacterDetails.Highlights.value = 0;
            MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Highlights), "byte", "0");
        }

        private void EmoteBox_SourceUpdated(object sender, DataTransferEventArgs e)
        {
            if (EmoteBox.IsMouseOver || EmoteBox.IsKeyboardFocusWithin)
            {
                EmoteBox.ValueChanged -= Emotexd;
                EmoteBox.ValueChanged += Emotexd;
            }
        }
        private void Emotexd(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (EmoteBox.Value.HasValue)
                if (EmoteBox.Value <= 7121) CharacterDetails.Emote.value = (int)EmoteBox.Value;
            EmoteBox.ValueChanged -= Emotexd;
        }

        private void LimbalEyeSearch_Click(object sender, RoutedEventArgs e)
        {
            if (SpecialControl.IsOpen)
            {
                if (!SpecialControl.ColorTab.IsSelected || SpecialControl.ClanBox.SelectedIndex!=7)
                {
                    SpecialControl.ColorTab.IsSelected = true;
                    SpecialControl.CharaMakeColorSelector(_colorMap, 0, 192);
                    SpecialControl.ClanBox.SelectedIndex = 7;
                }
                else SpecialControl.IsOpen = !SpecialControl.IsOpen;
            }
            else
            {
                SpecialControl.IsOpen = !SpecialControl.IsOpen;
                SpecialControl.ColorTab.IsSelected = true;
                SpecialControl.CharaMakeColorSelector(_colorMap, 0, 192);
                SpecialControl.ClanBox.SelectedIndex = 7;
            }
        }
    }
}