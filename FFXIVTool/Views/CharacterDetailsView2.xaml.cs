using FFXIVTool.Models;
using FFXIVTool.Utility;
using FFXIVTool.ViewModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace FFXIVTool.Views
{
    /// <summary>
    /// Interaction logic for CharacterDetailsView2.xaml
    /// </summary>
    public partial class CharacterDetailsView2 : UserControl
    {
        public CharacterDetails CharacterDetails { get => (CharacterDetails)BaseViewModel.model; set => BaseViewModel.model = value; }
        public CharacterDetailsView2()
        {
            InitializeComponent();
            CharacterDetailsView._exdProvider.DyeList();
            for (int i = 0; i < CharacterDetailsView._exdProvider.Dyes.Count; i++)
            {
                HeadDye.Items.Add(CharacterDetailsView._exdProvider.Dyes[i].Name);
                ChestBox.Items.Add(CharacterDetailsView._exdProvider.Dyes[i].Name);
                ArmBox.Items.Add(CharacterDetailsView._exdProvider.Dyes[i].Name);
                MHBox.Items.Add(CharacterDetailsView._exdProvider.Dyes[i].Name);
                OHBox.Items.Add(CharacterDetailsView._exdProvider.Dyes[i].Name);
                LegBox.Items.Add(CharacterDetailsView._exdProvider.Dyes[i].Name);
                FeetBox.Items.Add(CharacterDetailsView._exdProvider.Dyes[i].Name);
            }
        }

        private void XPos2_V(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (XPos2.Value.HasValue)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.WeaponX), "float", XPos2.Value.ToString());
            XPos2.ValueChanged -= XPos2_V;
        }
        private void XPos2_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (XPos2.IsKeyboardFocusWithin || XPos2.IsMouseOver)
            {
                XPos2.ValueChanged -= XPos2_V;
                XPos2.ValueChanged += XPos2_V;
            }
        }

        private void XPos2_V2(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (XPos2_Copy.Value.HasValue)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.WeaponY), "float", XPos2_Copy.Value.ToString());
            XPos2_Copy.ValueChanged -= XPos2_V2;
        }

        private void XPos2_Copy_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (XPos2_Copy.IsKeyboardFocusWithin || XPos2_Copy.IsMouseOver)
            {
                XPos2_Copy.ValueChanged -= XPos2_V2;
                XPos2_Copy.ValueChanged += XPos2_V2;
            }
        }

        private void XPos2_Copy1v(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (XPos2_Copy1.Value.HasValue)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.WeaponZ), "float", XPos2_Copy1.Value.ToString());
            XPos2_Copy1.ValueChanged -= XPos2_Copy1v;
        }

        private void XPos2_Copy1_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (XPos2_Copy1.IsKeyboardFocusWithin || XPos2_Copy1.IsMouseOver)
            {
                XPos2_Copy1.ValueChanged -= XPos2_Copy1v;
                XPos2_Copy1.ValueChanged += XPos2_Copy1v;
            }
        }

        private void WeaponRedxd(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (WeaponRed.Value.HasValue)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.WeaponRed), "float", WeaponRed.Value.ToString());
            WeaponRed.ValueChanged -= WeaponRedxd;
        }

        private void WeaponRed_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (WeaponRed.IsKeyboardFocusWithin || WeaponRed.IsMouseOver)
            {
                WeaponRed.ValueChanged -= WeaponRedxd;
                WeaponRed.ValueChanged += WeaponRedxd;
            }
        }

        private void WeaponGreenxD(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (WeaponGreen.Value.HasValue)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.WeaponGreen), "float", WeaponGreen.Value.ToString());
            WeaponGreen.ValueChanged -= WeaponGreenxD;
        }

        private void WeaponGreen_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (WeaponGreen.IsKeyboardFocusWithin || WeaponGreen.IsMouseOver)
            {
                WeaponGreen.ValueChanged -= WeaponGreenxD;
                WeaponGreen.ValueChanged += WeaponGreenxD;
            }
        }

        private void WeaponBluexD(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (WeaponBlue.Value.HasValue)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.WeaponBlue), "float", WeaponBlue.Value.ToString());
            WeaponBlue.ValueChanged -= WeaponBluexD;
        }

        private void WeaponBlue_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (WeaponBlue.IsKeyboardFocusWithin || WeaponBlue.IsMouseOver)
            {
                WeaponBlue.ValueChanged -= WeaponBluexD;
                WeaponBlue.ValueChanged += WeaponBluexD;
            }
        }

        private void OXPOSXD(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (OXPos.Value.HasValue)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.OffhandX), "float", OXPos.Value.ToString());
            OXPos.ValueChanged -= OXPOSXD;
        }

        private void OXPos_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (OXPos.IsKeyboardFocusWithin || OXPos.IsMouseOver)
            {
                OXPos.ValueChanged -= OXPOSXD;
                OXPos.ValueChanged += OXPOSXD;
            }
        }

        private void OYPOSXD(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (OYPos.Value.HasValue)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.OffhandY), "float", OYPos.Value.ToString());
            OYPos.ValueChanged -= OYPOSXD;
        }

        private void OYPos_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (OYPos.IsKeyboardFocusWithin || OYPos.IsMouseOver)
            {
                OYPos.ValueChanged -= OYPOSXD;
                OYPos.ValueChanged += OYPOSXD;
            }
        }

        private void OZPosXD(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (OZPos.Value.HasValue)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.OffhandZ), "float", OZPos.Value.ToString());
            OZPos.ValueChanged -= OZPosXD;
        }

        private void OZPos_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (OZPos.IsKeyboardFocusWithin || OZPos.IsMouseOver)
            {
                OZPos.ValueChanged -= OZPosXD;
                OZPos.ValueChanged += OZPosXD;
            }
        }
        private void OFfRedxD(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (OffRed.Value.HasValue)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.OffhandRed), "float", OffRed.Value.ToString());
            OffRed.ValueChanged -= OFfRedxD;
        }
        private void OffRed_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (OffRed.IsKeyboardFocusWithin || OffRed.IsMouseOver)
            {
                OffRed.ValueChanged -= OFfRedxD;
                OffRed.ValueChanged += OFfRedxD;
            }
        }

        private void OFFGXD(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (OffGreen.Value.HasValue)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.OffhandGreen), "float", OffGreen.Value.ToString());
            OffGreen.ValueChanged -= OFFGXD;
        }

        private void OffGreen_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (OffGreen.IsKeyboardFocusWithin || OffGreen.IsMouseOver)
            {
                OffGreen.ValueChanged -= OFFGXD;
                OffGreen.ValueChanged += OFFGXD;
            }
        }

        private void OFFBXD(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (OffBlue.Value.HasValue)
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.OffhandBlue), "float", OffBlue.Value.ToString());
            OffBlue.ValueChanged -= OFFBXD;
        }

        private void OffBlue_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (OffBlue.IsKeyboardFocusWithin || OffBlue.IsMouseOver)
            {
                OffBlue.ValueChanged -= OFFBXD;
                OffBlue.ValueChanged += OFFBXD;
            }
        }
        public static bool CheckItemList()
        {
            if (CharacterDetailsView._exdProvider.Items == null)
            {
                CharacterDetailsView._exdProvider.MakeItemList();
                if (CharacterDetailsView._exdProvider.Items == null)
                {
                    return false;
                }
            }
            return true;
        }
        public static bool CheckPropList()
        {
            if (CharacterDetailsView._exdProvider.ItemsProps == null)
            {
                CharacterDetailsView._exdProvider.MakePropList();
                if (CharacterDetailsView._exdProvider.ItemsProps == null)
                {
                    return false;
                }
            }
            return true;
        }
        private void MainSearch_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckItemList())
                return;
            if (EquipmentControl.IsOpen)
            {
                if(!EquipmentControl.EquipTab.IsSelected || EquipmentControl.EquipBoxC.SelectedIndex != 0)
                {
                    EquipmentControl.EquipTab.IsSelected=true;
                    EquipmentControl.EquipBoxC.SelectedIndex = 0;
                    EquipmentControl.CheckIncluded.Visibility = Visibility.Visible;
                    EquipmentControl.CheckIncluded.Content = "Include OffHand";
                    EquipmentControl.GearPicker(CharacterDetailsView._exdProvider.Items.Values.Where(c => c.Type == ExdCsvReader.ItemType.Wep && !c.ModelMain.Contains("0,0,0,0")).ToArray());
                }
                else EquipmentControl.IsOpen = !EquipmentControl.IsOpen;
            }
            else
            {
                EquipmentControl.IsOpen = !EquipmentControl.IsOpen;
                EquipmentControl.EquipBoxC.SelectedIndex = 0;
                EquipmentControl.EquipTab.IsSelected = true;
                EquipmentControl.CheckIncluded.Visibility = Visibility.Visible;
                EquipmentControl.CheckIncluded.Content = "Include OffHand";
                EquipmentControl.GearPicker(CharacterDetailsView._exdProvider.Items.Values.Where(c => c.Type == ExdCsvReader.ItemType.Wep && !c.ModelMain.Contains("0,0,0,0")).ToArray());
            }
        }

        private void OffSearch_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckItemList())
                return;
            if (EquipmentControl.IsOpen)
            {
                if (!EquipmentControl.EquipTab.IsSelected || EquipmentControl.EquipBoxC.SelectedIndex != 1)
                {
                    EquipmentControl.EquipBoxC.SelectedIndex = 1;
                    EquipmentControl.EquipTab.IsSelected = true;
                    EquipmentControl.CheckIncluded.Visibility = Visibility.Visible;
                    EquipmentControl.CheckIncluded.Content = "Non-Offhand Aesthetics";
                    EquipmentControl.GearPicker(CharacterDetailsView._exdProvider.Items.Values.Where(c => c.Type == ExdCsvReader.ItemType.Wep && !c.ModelMain.Contains("0,0,0,0")).ToArray());
                }
                else EquipmentControl.IsOpen = !EquipmentControl.IsOpen;
            }
            else
            {
                EquipmentControl.IsOpen = !EquipmentControl.IsOpen;
                EquipmentControl.EquipBoxC.SelectedIndex = 1;
                EquipmentControl.EquipTab.IsSelected = true;
                EquipmentControl.CheckIncluded.Visibility = Visibility.Visible;
                EquipmentControl.CheckIncluded.Content = "Non-Offhand Aesthetics";
                EquipmentControl.GearPicker(CharacterDetailsView._exdProvider.Items.Values.Where(c => c.Type == ExdCsvReader.ItemType.Wep && !c.ModelMain.Contains("0,0,0,0")).ToArray());
            }
        }

        private void HeadSearch_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckItemList())
                return;
            if (EquipmentControl.IsOpen)
            {
                if (!EquipmentControl.EquipTab.IsSelected || EquipmentControl.EquipBoxC.SelectedIndex != 2)
                {
                    EquipmentControl.EquipTab.IsSelected = true;
                    EquipmentControl.EquipBoxC.SelectedIndex = 2;
                    EquipmentControl.CheckIncluded.Visibility = Visibility.Hidden;
                    EquipmentControl.GearPicker(CharacterDetailsView._exdProvider.Items.Values.Where(c => c.Type == ExdCsvReader.ItemType.Head).ToArray());
                }
                else EquipmentControl.IsOpen = !EquipmentControl.IsOpen;
            }
            else
            {
                EquipmentControl.IsOpen = !EquipmentControl.IsOpen;
                EquipmentControl.EquipTab.IsSelected = true;
                EquipmentControl.EquipBoxC.SelectedIndex = 2;
                EquipmentControl.CheckIncluded.Visibility = Visibility.Hidden;
                EquipmentControl.GearPicker(CharacterDetailsView._exdProvider.Items.Values.Where(c => c.Type == ExdCsvReader.ItemType.Head).ToArray());
            }
        }

        private void BodySearch_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckItemList())
                return;
            if (EquipmentControl.IsOpen)
            {
                if (!EquipmentControl.EquipTab.IsSelected || EquipmentControl.EquipBoxC.SelectedIndex != 3)
                {
                    EquipmentControl.EquipTab.IsSelected = true;
                    EquipmentControl.EquipBoxC.SelectedIndex = 3;
                    EquipmentControl.CheckIncluded.Visibility = Visibility.Hidden;
                    EquipmentControl.GearPicker(CharacterDetailsView._exdProvider.Items.Values.Where(c => c.Type == ExdCsvReader.ItemType.Body).ToArray());
                }
                else EquipmentControl.IsOpen = !EquipmentControl.IsOpen;
            }
            else
            {
                EquipmentControl.IsOpen = !EquipmentControl.IsOpen;
                EquipmentControl.EquipTab.IsSelected = true;
                EquipmentControl.EquipBoxC.SelectedIndex = 3;
                EquipmentControl.CheckIncluded.Visibility = Visibility.Hidden;
                EquipmentControl.GearPicker(CharacterDetailsView._exdProvider.Items.Values.Where(c => c.Type == ExdCsvReader.ItemType.Body).ToArray());
            }
        }

        private void HandSearch_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckItemList())
                return;
            if (EquipmentControl.IsOpen)
            {
                if (!EquipmentControl.EquipTab.IsSelected || EquipmentControl.EquipBoxC.SelectedIndex != 4)
                {
                    EquipmentControl.EquipTab.IsSelected = true;
                    EquipmentControl.EquipBoxC.SelectedIndex = 4;
                    EquipmentControl.CheckIncluded.Visibility = Visibility.Hidden;
                    EquipmentControl.GearPicker(CharacterDetailsView._exdProvider.Items.Values.Where(c => c.Type == ExdCsvReader.ItemType.Hands).ToArray());
                }
                else EquipmentControl.IsOpen = !EquipmentControl.IsOpen;
            }
            else
            {
                EquipmentControl.IsOpen = !EquipmentControl.IsOpen;
                EquipmentControl.EquipTab.IsSelected = true;
                EquipmentControl.EquipBoxC.SelectedIndex = 4;
                EquipmentControl.CheckIncluded.Visibility = Visibility.Hidden;
                EquipmentControl.GearPicker(CharacterDetailsView._exdProvider.Items.Values.Where(c => c.Type == ExdCsvReader.ItemType.Hands).ToArray());
            }
        }

        private void LegsSearch_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckItemList())
                return;
            if (EquipmentControl.IsOpen)
            {
                if (!EquipmentControl.EquipTab.IsSelected || EquipmentControl.EquipBoxC.SelectedIndex != 5)
                {
                    EquipmentControl.EquipTab.IsSelected = true;
                    EquipmentControl.EquipBoxC.SelectedIndex = 5;
                    EquipmentControl.CheckIncluded.Visibility = Visibility.Hidden;
                    EquipmentControl.GearPicker(CharacterDetailsView._exdProvider.Items.Values.Where(c => c.Type == ExdCsvReader.ItemType.Legs).ToArray());
                }
                else EquipmentControl.IsOpen = !EquipmentControl.IsOpen;
            }
            else
            {
                EquipmentControl.IsOpen = !EquipmentControl.IsOpen;
                EquipmentControl.EquipTab.IsSelected = true;
                EquipmentControl.EquipBoxC.SelectedIndex = 5;
                EquipmentControl.CheckIncluded.Visibility = Visibility.Hidden;
                EquipmentControl.GearPicker(CharacterDetailsView._exdProvider.Items.Values.Where(c => c.Type == ExdCsvReader.ItemType.Legs).ToArray());
            }
        }

        private void FeetSearch_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckItemList())
                return;
            if (EquipmentControl.IsOpen)
            {
                if (!EquipmentControl.EquipTab.IsSelected||EquipmentControl.EquipBoxC.SelectedIndex!=6)
                {
                    EquipmentControl.EquipTab.IsSelected = true;
                    EquipmentControl.EquipBoxC.SelectedIndex = 6;
                    EquipmentControl.CheckIncluded.Visibility = Visibility.Hidden;
                    EquipmentControl.GearPicker(CharacterDetailsView._exdProvider.Items.Values.Where(c => c.Type == ExdCsvReader.ItemType.Feet).ToArray());
                }
                else EquipmentControl.IsOpen = !EquipmentControl.IsOpen;
            }
            else
            {
                EquipmentControl.IsOpen = !EquipmentControl.IsOpen;
                EquipmentControl.EquipTab.IsSelected = true;
                EquipmentControl.EquipBoxC.SelectedIndex = 6;
                EquipmentControl.CheckIncluded.Visibility = Visibility.Hidden;
                EquipmentControl.GearPicker(CharacterDetailsView._exdProvider.Items.Values.Where(c => c.Type == ExdCsvReader.ItemType.Feet).ToArray());
            }
        }

        private void EarSearch_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckItemList())
                return;
            if (EquipmentControl.IsOpen)
            {
                if (!EquipmentControl.EquipTab.IsSelected || EquipmentControl.EquipBoxC.SelectedIndex != 7)
                {
                    EquipmentControl.EquipTab.IsSelected = true;
                    EquipmentControl.EquipBoxC.SelectedIndex = 7;
                    EquipmentControl.CheckIncluded.Visibility = Visibility.Hidden;
                    EquipmentControl.GearPicker(CharacterDetailsView._exdProvider.Items.Values.Where(c => c.Type == ExdCsvReader.ItemType.Ears).ToArray());
                }
                else EquipmentControl.IsOpen = !EquipmentControl.IsOpen;
            }
            else
            {
                EquipmentControl.IsOpen = !EquipmentControl.IsOpen;
                EquipmentControl.EquipTab.IsSelected = true;
                EquipmentControl.EquipBoxC.SelectedIndex = 7;
                EquipmentControl.CheckIncluded.Visibility = Visibility.Hidden;
                EquipmentControl.GearPicker(CharacterDetailsView._exdProvider.Items.Values.Where(c => c.Type == ExdCsvReader.ItemType.Ears).ToArray());
            }
        }

        private void NeckSearch_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckItemList())
                return;
            if (EquipmentControl.IsOpen)
            {
                if (!EquipmentControl.EquipTab.IsSelected || EquipmentControl.EquipBoxC.SelectedIndex != 8)
                {
                    EquipmentControl.EquipTab.IsSelected = true;
                    EquipmentControl.EquipBoxC.SelectedIndex = 8;
                    EquipmentControl.CheckIncluded.Visibility = Visibility.Hidden;
                    EquipmentControl.GearPicker(CharacterDetailsView._exdProvider.Items.Values.Where(c => c.Type == ExdCsvReader.ItemType.Neck).ToArray());
                }
                else EquipmentControl.IsOpen = !EquipmentControl.IsOpen;
            }
            else
            {
                EquipmentControl.IsOpen = !EquipmentControl.IsOpen;
                EquipmentControl.EquipTab.IsSelected = true;
                EquipmentControl.EquipBoxC.SelectedIndex = 8;
                EquipmentControl.CheckIncluded.Visibility = Visibility.Hidden;
                EquipmentControl.GearPicker(CharacterDetailsView._exdProvider.Items.Values.Where(c => c.Type == ExdCsvReader.ItemType.Neck).ToArray());
            }
        }

        private void WristSearch_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckItemList())
                return;
            if (EquipmentControl.IsOpen)
            {
                if (!EquipmentControl.EquipTab.IsSelected || EquipmentControl.EquipBoxC.SelectedIndex != 9)
                {
                    EquipmentControl.EquipTab.IsSelected = true;
                    EquipmentControl.EquipBoxC.SelectedIndex = 9;
                    EquipmentControl.CheckIncluded.Visibility = Visibility.Hidden;
                    EquipmentControl.GearPicker(CharacterDetailsView._exdProvider.Items.Values.Where(c => c.Type == ExdCsvReader.ItemType.Wrists).ToArray());
                }
                else EquipmentControl.IsOpen = !EquipmentControl.IsOpen;
            }
            else
            {
                EquipmentControl.IsOpen = !EquipmentControl.IsOpen;
                EquipmentControl.EquipTab.IsSelected = true;
                EquipmentControl.EquipBoxC.SelectedIndex = 9;
                EquipmentControl.CheckIncluded.Visibility = Visibility.Hidden;
                EquipmentControl.GearPicker(CharacterDetailsView._exdProvider.Items.Values.Where(c => c.Type == ExdCsvReader.ItemType.Wrists).ToArray());
            }
        }

        private void RightSearch_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckItemList())
                return;
            if (EquipmentControl.IsOpen)
            {
                if (!EquipmentControl.EquipTab.IsSelected || EquipmentControl.EquipBoxC.SelectedIndex != 10)
                {
                    EquipmentControl.EquipTab.IsSelected = true;
                    EquipmentControl.EquipBoxC.SelectedIndex = 10;
                    EquipmentControl.CheckIncluded.Visibility = Visibility.Hidden;
                    EquipmentControl.GearPicker(CharacterDetailsView._exdProvider.Items.Values.Where(c => c.Type == ExdCsvReader.ItemType.Ring).ToArray());
                }
                else EquipmentControl.IsOpen = !EquipmentControl.IsOpen;
            }
            else
            {
                EquipmentControl.IsOpen = !EquipmentControl.IsOpen;
                EquipmentControl.EquipBoxC.SelectedIndex = 10;
                EquipmentControl.EquipTab.IsSelected = true;
                EquipmentControl.CheckIncluded.Visibility = Visibility.Hidden;
                EquipmentControl.GearPicker(CharacterDetailsView._exdProvider.Items.Values.Where(c => c.Type == ExdCsvReader.ItemType.Ring).ToArray());
            }
        }

        private void LeftSearch_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckItemList())
                return;
            if (EquipmentControl.IsOpen)
            {
                if (!EquipmentControl.EquipTab.IsSelected||EquipmentControl.EquipBoxC.SelectedIndex!=11)
                {
                    EquipmentControl.EquipTab.IsSelected = true;
                    EquipmentControl.EquipBoxC.SelectedIndex = 11;
                    EquipmentControl.CheckIncluded.Visibility = Visibility.Hidden;
                    EquipmentControl.GearPicker(CharacterDetailsView._exdProvider.Items.Values.Where(c => c.Type == ExdCsvReader.ItemType.Ring).ToArray());
                }
                else EquipmentControl.IsOpen = !EquipmentControl.IsOpen;
            }
            else
            {
                EquipmentControl.IsOpen = !EquipmentControl.IsOpen;
                EquipmentControl.EquipTab.IsSelected = true;
                EquipmentControl.EquipBoxC.SelectedIndex = 11;
                EquipmentControl.CheckIncluded.Visibility = Visibility.Hidden;
                EquipmentControl.GearPicker(CharacterDetailsView._exdProvider.Items.Values.Where(c => c.Type == ExdCsvReader.ItemType.Ring).ToArray());
            }
        }
        public static bool CheckResidentList()
        {
            if (CharacterDetailsView._exdProvider.Residents == null)
            {
                CharacterDetailsView._exdProvider.MakeResidentList();
                if (CharacterDetailsView._exdProvider.Residents == null)
                    return false;
            }
            return true;
        }
        private void NPC_Click2(object sender, RoutedEventArgs e)
        {
            if (!CheckResidentList())
                return;
            if (EquipmentControl.IsOpen)
            {
                if (!EquipmentControl.NPCTab.IsSelected)
                {
                    EquipmentControl.NPCTab.IsSelected = true;
                    if(!EquipmentFlyOut.UserDoneInteraction) EquipmentControl.ResidentSelector(CharacterDetailsView._exdProvider.Residents.Values.Where(c => c.IsGoodNpc()).ToArray());
                }
                else EquipmentControl.IsOpen = !EquipmentControl.IsOpen;
            }
            else
            {
                EquipmentControl.IsOpen = !EquipmentControl.IsOpen;
                EquipmentControl.NPCTab.IsSelected = true;
                if (!EquipmentFlyOut.UserDoneInteraction) EquipmentControl.ResidentSelector(CharacterDetailsView._exdProvider.Residents.Values.Where(c => c.IsGoodNpc()).ToArray());
            }
        }
        private void DigitCheckInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1))
                e.Handled = true;
        }

        private void PropSearch_Click(object sender, RoutedEventArgs e)
        {
           if (!CheckPropList())
                return;
            if (EquipmentControl.IsOpen)
            {
                if (!EquipmentControl.EquipTab.IsSelected || EquipmentControl.EquipBoxC.SelectedIndex != 12)
                {
                    EquipmentControl.EquipTab.IsSelected = true;
                    EquipmentControl.EquipBoxC.SelectedIndex = 12;
                    EquipmentControl.CheckIncluded.Visibility = Visibility.Hidden;
                    EquipmentControl.GearPicker(CharacterDetailsView._exdProvider.ItemsProps.Values.ToArray());
                }
                else EquipmentControl.IsOpen = !EquipmentControl.IsOpen;
            }
            else
            {
                EquipmentControl.IsOpen = !EquipmentControl.IsOpen;
                EquipmentControl.EquipBoxC.SelectedIndex = 12;
                EquipmentControl.EquipTab.IsSelected = true;
                EquipmentControl.CheckIncluded.Visibility = Visibility.Hidden;
                EquipmentControl.GearPicker(CharacterDetailsView._exdProvider.ItemsProps.Values.ToArray());
            }
        }

        private void PropSearchOH_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckPropList())
                return;
            if (EquipmentControl.IsOpen)
            {
                if (!EquipmentControl.EquipTab.IsSelected || EquipmentControl.EquipBoxC.SelectedIndex != 13)
                {
                    EquipmentControl.EquipTab.IsSelected = true;
                    EquipmentControl.EquipBoxC.SelectedIndex = 13;
                    EquipmentControl.CheckIncluded.Visibility = Visibility.Hidden;
                    EquipmentControl.GearPicker(CharacterDetailsView._exdProvider.ItemsProps.Values.ToArray());
                }
                else EquipmentControl.IsOpen = !EquipmentControl.IsOpen;
            }
            else
            {
                EquipmentControl.IsOpen = !EquipmentControl.IsOpen;
                EquipmentControl.EquipBoxC.SelectedIndex = 13;
                EquipmentControl.EquipTab.IsSelected = true;
                EquipmentControl.CheckIncluded.Visibility = Visibility.Hidden;
                EquipmentControl.GearPicker(CharacterDetailsView._exdProvider.ItemsProps.Values.ToArray());
            }
        }
    }
}

