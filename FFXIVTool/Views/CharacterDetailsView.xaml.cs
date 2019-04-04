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
        public static bool xyzcheck = false;
        public static bool numbcheck = false;
        public CharacterDetails CharacterDetails { get => (CharacterDetails)BaseViewModel.model; set => BaseViewModel.model = value; }
        public CharacterDetailsView()
        {
            InitializeComponent();
            _exdProvider.MonsterList();
            MainViewModel.ViewTime = this;
            ExdCsvReader.MonsterX = _exdProvider.Monsters.Values.ToArray();
            CharacterDetailsViewModel.Viewtime = this;
            DispatcherTimer timer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(40) };
            timer.Tick += delegate
            {
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
                    SpecialControl.CharaMakeColorSelectorLips(_colorMap, 512, 96);
                    SpecialControl.ClanBox.SelectedIndex = 3;
                }
                else SpecialControl.IsOpen = !SpecialControl.IsOpen;
            }
            else
            {
                SpecialControl.IsOpen = !SpecialControl.IsOpen;
                SpecialControl.ColorTab.IsSelected = true;
                SpecialControl.CharaMakeColorSelectorLips(_colorMap, 512, 96);
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
                    SpecialControl.CharaMakeColorSelectorLips(_colorMap, 512, 96);
                    SpecialControl.ClanBox.SelectedIndex = 6;
                }
                else SpecialControl.IsOpen = !SpecialControl.IsOpen;
            }
            else
            {
                SpecialControl.IsOpen = !SpecialControl.IsOpen;
                SpecialControl.ColorTab.IsSelected = true;
                SpecialControl.CharaMakeColorSelectorLips(_colorMap, 512, 96);
                SpecialControl.ClanBox.SelectedIndex = 6;
            }
        }
        private void FaceSelectButton_Click(object sender, RoutedEventArgs e)
        {
            if (SpecialControl.IsOpen)
            {
                if (!SpecialControl.PaintTab.IsSelected)
                {
                    SpecialControl.PaintTab.IsSelected = true;
                    SpecialControl.CheckIncluded.IsChecked = false;
                    SpecialControl.CharaMakeFeatureSelector2(CharacterDetails.Clan.value, CharacterDetails.Gender.value, _exdProvider);
                }
                else SpecialControl.IsOpen = !SpecialControl.IsOpen;
            }
            else
            {
                SpecialControl.IsOpen = !SpecialControl.IsOpen;
                SpecialControl.PaintTab.IsSelected = true;
                SpecialControl.CheckIncluded.IsChecked = false;
                SpecialControl.CharaMakeFeatureSelector2(CharacterDetails.Clan.value, CharacterDetails.Gender.value, _exdProvider);
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
                if (EmoteBox.Value <= 7421) CharacterDetails.Emote.value = (int)EmoteBox.Value;
            EmoteBox.ValueChanged -= Emotexd;
        }

        private void LimbalEyeSearch_Click(object sender, RoutedEventArgs e)
        {
            if (SpecialControl.IsOpen)
            {
                if (!SpecialControl.ColorTab.IsSelected || SpecialControl.ClanBox.SelectedIndex != 7)
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

        private void Setto0_Click(object sender, RoutedEventArgs e)
        {
            CharacterDetails.EmoteSpeed1.value = 0;
            CharacterDetails.EmoteSpeed2.value = 0;
        }

        private void FreezeXYZ_Click(object sender, RoutedEventArgs e)
        {
            xyzcheck = !xyzcheck;
            CharacterDetails.X.freeze = xyzcheck;
            CharacterDetails.Y.freeze = xyzcheck;
            CharacterDetails.Z.freeze = xyzcheck;
        }

        private void Freeze1234_Click(object sender, RoutedEventArgs e)
        {
            numbcheck = !numbcheck;
            CharacterDetails.Rotation.freeze = numbcheck;
            CharacterDetails.Rotation2.freeze = numbcheck;
            CharacterDetails.Rotation3.freeze = numbcheck;
            CharacterDetails.Rotation4.freeze = numbcheck;
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {

                Random rnd = new Random();
                CharacterDetails.Race.value = (byte)rnd.Next(1, 7);
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Race), CharacterDetails.Race.GetBytes());
                if (CharacterDetails.Race.value == 1) CharacterDetails.Clan.value = (byte)rnd.Next(1, 3);
                else if (CharacterDetails.Race.value == 2) CharacterDetails.Clan.value = (byte)rnd.Next(3, 5);
                else if (CharacterDetails.Race.value == 3) CharacterDetails.Clan.value = (byte)rnd.Next(5, 7);
                else if (CharacterDetails.Race.value == 4) CharacterDetails.Clan.value = (byte)rnd.Next(7, 9);
                else if (CharacterDetails.Race.value == 5) CharacterDetails.Clan.value = (byte)rnd.Next(9, 11);
                else if (CharacterDetails.Race.value == 6) CharacterDetails.Clan.value = (byte)rnd.Next(11, 13);
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Clan), CharacterDetails.Clan.GetBytes());
                CharacterDetails.Gender.value = (byte)rnd.Next(0, 2);
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Gender), CharacterDetails.Gender.GetBytes());
                SpecialControl.HairRandomPick(CharacterDetails.Clan.value, CharacterDetails.Gender.value, _exdProvider);
                if (CharacterDetails.Race.value == 1 && CharacterDetails.Clan.value == 1 && CharacterDetails.Gender.value == 0) CharacterDetails.Head.value = (byte)rnd.Next(0, 8);
                else if (CharacterDetails.Race.value == 1 && CharacterDetails.Clan.value == 1 && CharacterDetails.Gender.value == 1) CharacterDetails.Head.value = (byte)rnd.Next(0, 6);
                else CharacterDetails.Head.value = (byte)rnd.Next(0, 5);
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Head), CharacterDetails.Head.GetBytes());
                CharacterDetails.HairTone.value = (byte)rnd.Next(0, 193);
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HairTone), CharacterDetails.HairTone.GetBytes());
                if (rnd.Next(2) == 1)
                {
                     CharacterDetails.Highlights.value = 128;
                    MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Highlights), CharacterDetails.Highlights.GetBytes());
                     CharacterDetails.HighlightTone.value = (byte)rnd.Next(0, 193);
                    MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HighlightTone), CharacterDetails.HighlightTone.GetBytes());
                }
                else
                 {
                    CharacterDetails.Highlights.value = 0;
                    MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Highlights), CharacterDetails.Highlights.GetBytes());
                    CharacterDetails.HighlightTone.value = 0;
                    MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HighlightTone), CharacterDetails.HighlightTone.GetBytes());
                }
                CharacterDetails.RHeight.value = (byte)rnd.Next(0, 101);
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.RHeight), CharacterDetails.RHeight.GetBytes());
                CharacterDetails.RBust.value = (byte)rnd.Next(0, 101);
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.RBust), CharacterDetails.RBust.GetBytes());
                CharacterDetails.Eye.value = (byte)rnd.Next(0, 6);
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Eye), CharacterDetails.Eye.GetBytes());
                CharacterDetails.EyeBrowType.value = (byte)rnd.Next(0, 5);
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.EyeBrowType), CharacterDetails.EyeBrowType.GetBytes());
                if (rnd.Next(100) < 15) //Checks if there should be Odd Eyes.
                {
                    CharacterDetails.RightEye.value = (byte)rnd.Next(0, 193);
                    MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.RightEye), CharacterDetails.RightEye.GetBytes());
                    CharacterDetails.LeftEye.value = (byte)rnd.Next(0, 193);
                    MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LeftEye), CharacterDetails.LeftEye.GetBytes());
                }
                else
                {
                    CharacterDetails.RightEye.value = (byte)rnd.Next(0, 193);
                    MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.RightEye), CharacterDetails.RightEye.GetBytes());
                    CharacterDetails.LeftEye.value = CharacterDetails.RightEye.value;
                    MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LeftEye), CharacterDetails.LeftEye.GetBytes());
                }
                CharacterDetails.Nose.value = (byte)rnd.Next(0, 6);
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Nose), CharacterDetails.Nose.GetBytes());
                if (rnd.Next(100) < 25) // 25% chance Lip coloring may happen?
                {
                    CharacterDetails.Lips.value = (byte)rnd.Next(128, 134);
                    MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Lips), CharacterDetails.Lips.GetBytes());
                    if (rnd.Next(2) == 1) // 50% chance it'll be dark lips?
                    {
                        CharacterDetails.LipsTone.value = (byte)rnd.Next(0, 96);
                        MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LipsTone), CharacterDetails.LipsTone.GetBytes());
                    }
                    else
                    {
                        CharacterDetails.LipsTone.value = (byte)rnd.Next(128, 224);
                        MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LipsTone), CharacterDetails.LipsTone.GetBytes());
                    }
                }
                else
                {
                    CharacterDetails.Lips.value = (byte)rnd.Next(0, 6);
                    MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Lips), CharacterDetails.Lips.GetBytes());
                    CharacterDetails.LipsTone.value = 0;
                    MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LipsTone), CharacterDetails.LipsTone.GetBytes());
                }
                CharacterDetails.Jaw.value = (byte)rnd.Next(0, 6);
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Jaw), CharacterDetails.Jaw.GetBytes());
                if (rnd.Next(100) < 25) //25% having facial feature?
                {
                    CharacterDetails.FacialFeatures.value = (byte)rnd.Next(0, 256);
                    MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.FacialFeatures), CharacterDetails.FacialFeatures.GetBytes());
                    if (CharacterDetails.Race.value == 6)
                    {
                        CharacterDetails.LimbalEyes.value = (byte)rnd.Next(0, 192);
                        MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LimbalEyes), CharacterDetails.LimbalEyes.GetBytes());
                    }
                }
                else
                {
                    CharacterDetails.FacialFeatures.value = 0;
                    MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.FacialFeatures), CharacterDetails.FacialFeatures.GetBytes());
                    CharacterDetails.LimbalEyes.value = 0;
                    MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LimbalEyes), CharacterDetails.LimbalEyes.GetBytes());
                }
                if (rnd.Next(100) < 25)
                {
                    if (rnd.Next(2) == 1) //50% Chance of being reversed
                    {
                        CharacterDetails.FacePaint.value = (byte)rnd.Next(128, 157);
                        MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.FacePaint), CharacterDetails.FacePaint.GetBytes());
                    }
                    else
                    {
                        CharacterDetails.FacePaint.value = (byte)rnd.Next(0, 29);
                        MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.FacePaint), CharacterDetails.FacePaint.GetBytes());
                    }
                    if (rnd.Next(2) == 1) // 50% chance it'll be dark Paint?
                    {
                        CharacterDetails.FacePaintColor.value = (byte)rnd.Next(0, 96);
                        MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.FacePaintColor), CharacterDetails.FacePaintColor.GetBytes());
                    }
                    else
                    {
                        CharacterDetails.FacePaintColor.value = (byte)rnd.Next(128, 224);
                        MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.FacePaintColor), CharacterDetails.FacePaintColor.GetBytes());
                    }
                }
                else
                {
                    CharacterDetails.FacePaint.value = 0;
                    MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.FacePaint), CharacterDetails.FacePaint.GetBytes());
                    CharacterDetails.FacePaintColor.value = 0;
                    MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.FacePaintColor), CharacterDetails.FacePaintColor.GetBytes());
                }
                if (CharacterDetails.Race.value == 4) CharacterDetails.TailType.value = (byte)rnd.Next(0, 9);
                else if (CharacterDetails.Race.value == 3 || CharacterDetails.Race.value == 2 || CharacterDetails.Race.value == 6) CharacterDetails.TailType.value = (byte)rnd.Next(0, 4);
                else CharacterDetails.TailType.value = 0;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.TailType), CharacterDetails.TailType.GetBytes());
                CharacterDetails.TailorMuscle.value = (byte)rnd.Next(0, 101);
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.TailorMuscle), CharacterDetails.TailorMuscle.GetBytes());
                CharacterDetails.Skintone.value = (byte)rnd.Next(0, 192);
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Skintone), CharacterDetails.Skintone.GetBytes());
            }
            catch (System.Exception ex)
            {
                // Get stack trace for the exception with source file information
                var st = new System.Diagnostics.StackTrace(ex, true);
                // Get the top stack frame
                var frame = st.GetFrame(0);
                // Get the line number from the stack frame
                var line = frame.GetFileLineNumber();
                System.Windows.MessageBox.Show(ex.Message + "\n" + ex.StackTrace + frame + line, "Oh no!");

            }
        }

        private void FacialFeature_Click(object sender, RoutedEventArgs e)
        {
            if (SpecialControl.IsOpen)
            {
                if (!SpecialControl.FacialTab.IsSelected)
                {
                    SpecialControl.FacialTab.IsSelected = true;
                    SpecialControl.CharaMakeFeatureSelector3(CharacterDetails.Head.value, CharacterDetails.Race.value, CharacterDetails.Clan.value, CharacterDetails.Gender.value, _exdProvider);
                }
                else SpecialControl.IsOpen = !SpecialControl.IsOpen;
            }
            else
            {
                SpecialControl.IsOpen = !SpecialControl.IsOpen;
                SpecialControl.FacialTab.IsSelected = true;
                SpecialControl.CharaMakeFeatureSelector3(CharacterDetails.Head.value, CharacterDetails.Race.value, CharacterDetails.Clan.value, CharacterDetails.Gender.value, _exdProvider);
            }
        }
    }
}