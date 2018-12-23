using FFXIVTool.Models;
using FFXIVTool.Utility;
using FFXIVTool.ViewModel;
using MahApps.Metro.Controls;
using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace FFXIVTool.Views
{
    /// <summary>
    /// Interaction logic for SpecialControl.xaml
    /// </summary>
    public partial class SpecialControl : Flyout
    {
        private bool Userinteraction2 = false;
        public CharacterDetails CharacterDetails { get => (CharacterDetails)BaseViewModel.model; set => BaseViewModel.model = value; }
        private ExdCsvReader _reader;
        private int _tribe;
        private int _gender;
        private int _startIndex;
        public int Choice = -1;
        private bool DidUserInteract = false;
        private bool isUserInteraction;
        [DllImport("gdi32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool DeleteObject(IntPtr value);

        public class FeatureSelect
        {
            public int ID { get; set; }
            public ImageSource FeatureImage { get; set; }
        }
        public SpecialControl()
        {
            InitializeComponent();
        }

        public void CharaMakeColorSelector(CmpReader colorMap, int start, int length)
        {
            colorListView.Items.Clear();
            for (int i = start; i < start + length; i++)
            {
                ListViewItem item = new ListViewItem();
                item.Width = 64;
                item.Height = 64;
                var newColor = new SolidColorBrush(Color.FromArgb(colorMap.Colors[i].A, colorMap.Colors[i].R, colorMap.Colors[i].G, colorMap.Colors[i].B));
                item.Background = newColor;
                item.FontSize = 24;
                item.FontWeight = FontWeights.Bold;
                item.Content = (i - start);
                colorListView.Items.Add(item);
            }

            _startIndex = start;
        }

        private void colorListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (colorListView.SelectedItem == null)
                return;
            string hexValue = colorListView.SelectedIndex.ToString("X");
            if (ClanBox.SelectedIndex == 0)
            {
                CharacterDetails.Skintone.value = (byte)colorListView.SelectedIndex;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Skintone),"byte", hexValue);
            }
            if (ClanBox.SelectedIndex == 1)
            {
                CharacterDetails.HairTone.value = (byte)colorListView.SelectedIndex;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HairTone), "byte", hexValue);
            }
            if (ClanBox.SelectedIndex == 2)
            {
                CharacterDetails.HighlightTone.value = (byte)colorListView.SelectedIndex;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HighlightTone), "byte", hexValue);
            }
            if (ClanBox.SelectedIndex == 3)
            {
                CharacterDetails.LipsTone.value = (byte)colorListView.SelectedIndex;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LipsTone), "byte", hexValue);
            }
            if (ClanBox.SelectedIndex == 4)
            {
                CharacterDetails.RightEye.value = (byte)colorListView.SelectedIndex;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.RightEye), "byte", hexValue);
            }
            if (ClanBox.SelectedIndex == 5)
            {
                CharacterDetails.LeftEye.value = (byte)colorListView.SelectedIndex;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LeftEye), "byte", hexValue);
            }
            if (ClanBox.SelectedIndex == 6)
            {
                CharacterDetails.FacePaintColor.value = (byte)colorListView.SelectedIndex;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.FacePaintColor), "byte", hexValue);
            }
            if (ClanBox.SelectedIndex == 7)
            {
                CharacterDetails.LimbalEyes.value = (byte)colorListView.SelectedIndex;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LimbalEyes), "byte", hexValue);
            }
        }

        public static int GetSkin(int Clan, bool Gender)
        {
            switch (Clan)
            {
                case 1: //Midlander
                    return !Gender ? 4608 : 3328;
                case 2: //Highlander
                    return !Gender ? 7168 : 5888;
                case 3: //Wildwood
                    return !Gender ? 9728 : 8448;
                case 4: //Duskwight
                    return !Gender ? 12288 : 11008;
                case 5: //Plainsfolk
                    return !Gender ? 14848 : 13568;
                case 6: //Dunesfolk
                    return !Gender ? 17408 : 16128;
                case 7: //Seeker of the Sun
                    return !Gender ? 19968 : 18688;
                case 8: //Keeper of the Moon
                    return !Gender ? 22528 : 21248;
                case 9: //Sea Wolf
                    return !Gender ? 25088 : 23808;
                case 10: //Hellsguard
                    return !Gender ? 27648 : 26368;
                case 11: //Raen
                    return !Gender ? 30208 : 28928;
                case 12: //Xaela
                    return !Gender ? 32768 : 31488;
                default:
                    throw new NotImplementedException();
            }
        }

        public static int GetHair(int clan, bool gender)
        {
            switch (clan)
            {
                case 1: //Midlander
                    return !gender ? 4864 : 3584;
                case 2: //Highlander
                    return !gender ? 7424 : 6144;
                case 3: //Wildwood
                    return !gender ? 9984 : 8704;
                case 4: //Duskwight
                    return !gender ? 12544 : 11264;
                case 5: //Plainsfolk
                    return !gender ? 15104 : 13824;
                case 6: //Dunesfolk
                    return !gender ? 17664 : 16384;
                case 7: //Seeker of the Sun
                    return !gender ? 20224 : 18944;
                case 8: //Keeper of the Moon
                    return !gender ? 22784 : 21504;
                case 9: // Sea Wolf
                    return !gender ? 25344 : 24064;
                case 10: //Hellsguard
                    return !gender ? 27904 : 26624;
                case 11: // Raen
                    return !gender ? 30464 : 29184;
                case 12: // Xaela
                    return !gender ? 33024 : 31744;
                default:
                    throw new NotImplementedException();
            }
        }

        private void ClanBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (isUserInteraction)
            {
                if (ClanBox.SelectedIndex == 0) CharaMakeColorSelector(CharacterDetailsView._colorMap, GetSkin(CharacterDetails.Clan.value, Convert.ToBoolean(CharacterDetails.Gender.value)), 192);
                if (ClanBox.SelectedIndex == 1) CharaMakeColorSelector(CharacterDetailsView._colorMap, GetHair(CharacterDetails.Clan.value, Convert.ToBoolean(CharacterDetails.Gender.value)), 192);
                if (ClanBox.SelectedIndex == 2) CharaMakeColorSelector(CharacterDetailsView._colorMap, 256, 192);
                if (ClanBox.SelectedIndex == 3) CharaMakeColorSelector(CharacterDetailsView._colorMap, 512, 96);
                if (ClanBox.SelectedIndex == 4) CharaMakeColorSelector(CharacterDetailsView._colorMap, 0, 192);
                if (ClanBox.SelectedIndex == 5) CharaMakeColorSelector(CharacterDetailsView._colorMap, 0, 192);
                if (ClanBox.SelectedIndex == 6) CharaMakeColorSelector(CharacterDetailsView._colorMap, 1152, 96);
                if (ClanBox.SelectedIndex == 7) CharaMakeColorSelector(CharacterDetailsView._colorMap, 0, 192);
                isUserInteraction = false;
            }
        }

        private void ClanBox_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            isUserInteraction = true;
        }

        public void CharaMakeFeatureSelector(int tribe, int gender, ExdCsvReader reader)
        {
            if (DidUserInteract) return;
            DidUserInteract = true;
            _tribe = tribe;
            _gender = gender;
            _reader = reader;

            FillHairStyle();
        }

        ExdCsvReader.CharaMakeCustomizeFeature GetFeature(int startIndex, int length, byte dataKey)
        {
            if (dataKey == 0)
                return null; // Custom or not specified.

            for (var i = 1; i < length; i++)
            {
               // Debug.WriteLine(startIndex + i);
                var feature = _reader.CharaMakeFeatures[startIndex + i];

                if (feature.FeatureID == dataKey)
                {
                    return feature;
                }
            }

            return null; // Not found - custom.
        }

        int GetHairstyleCustomizeIndex(int tribeKey, bool isMale)
        {
            switch (tribeKey)
            {
                case 1: // Midlander
                    return isMale ? 0 : 100;
                case 2: // Highlander
                    return isMale ? 200 : 300;
                case 3: // Wildwood
                case 4: // Duskwight
                    return isMale ? 400 : 500;
                case 5: // Plainsfolks
                case 6: // Dunesfolk
                    return isMale ? 600 : 700;
                case 7: // Seeker of the Sun
                case 8: // Keeper of the Moon
                    return isMale ? 800 : 900;
                case 9: // Sea Wolf
                case 10: // Hellsguard
                    return isMale ? 1000 : 1100;
                case 11: // Raen
                case 12: // Xaela
                    return isMale ? 1200 : 1300;
            }

            throw new NotImplementedException();
        }

        public void FillHairStyle()
        {
            try
            {
                CharacterFeature.Items.Clear();
                int added = 0;
                for (int i = 0; i < 200; i++)
                {
                    var feature = GetFeature(GetHairstyleCustomizeIndex(_tribe, _gender == 0), 100, (byte)i);

                    if (feature == null)
                        continue;
                    CharacterFeature.Items.Add(new FeatureSelect() { ID = feature.FeatureID, FeatureImage = GetImageStream(feature.Icon) });
                    added++;
                }
                DidUserInteract = false;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static BitmapSource GetImageStream(System.Drawing.Image myImage)
        {
            var bitmap = new System.Drawing.Bitmap(myImage);
            IntPtr bmpPt = bitmap.GetHbitmap();
            BitmapSource bitmapSource =
             System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
                   bmpPt,
                   IntPtr.Zero,
                   Int32Rect.Empty,
                   BitmapSizeOptions.FromEmptyOptions());

            //freeze bitmapSource and clear memory to avoid memory leaks
            bitmapSource.Freeze();
            DeleteObject(bmpPt);

            return bitmapSource;
        }

        private void CharacterFeature_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CharacterFeature.SelectedItem == null)
                return;
            var Value = (FeatureSelect)CharacterFeature.SelectedItem;
            CharacterDetails.Hair.value = (byte)Value.ID;
            string hexValue = Value.ID.ToString("X");
            MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Hair),"byte", hexValue);
        }

        private void ModelBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ModelBox.SelectedCells.Count > 0)
            {
                if (ModelBox.SelectedItem == null)
                    return;
                var Value = (ExdCsvReader.Monster)ModelBox.SelectedItem;
                CharacterDetails.ModelType.value = (int)Value.Index;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.ModelType), "int", Value.Index.ToString());
            }
        }

        private void SearchModelBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string filter = SearchModelBox.Text.ToLower();
            ModelBox.Items.Clear();
            foreach (ExdCsvReader.Monster xD in ExdCsvReader.MonsterX.Where(g => g.Name.ToLower().Contains(filter)))
                if (xD.Real == true)
                {
                    ModelBox.Items.Add(new ExdCsvReader.Monster
                    {
                        Index = Convert.ToInt32(xD.Index),
                        Name = xD.Name.ToString()
                    });
                }
        }

        private void AnimatedTabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (HairTab.IsSelected&&Userinteraction2)
            {
                CharaMakeFeatureSelector(CharacterDetails.Clan.value, CharacterDetails.Gender.value, CharacterDetailsView._exdProvider);
            }
            Userinteraction2 = false;
        }
        private void AnimatedTabControl_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Userinteraction2 = true;
        }
    }
}