using ConceptMatrix.Models;
using ConceptMatrix.Utility;
using ConceptMatrix.ViewModel;
using MahApps.Metro.Controls;
using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ConceptMatrix.Views
{
    /// <summary>
    /// Interaction logic for SpecialControl.xaml
    /// </summary>
    public partial class SpecialControl : Flyout
    {
        public CharacterDetails CharacterDetails { get => (CharacterDetails)BaseViewModel.model; set => BaseViewModel.model = value; }
        private ExdCsvReader _reader;
        private int _tribe;
        private int _gender;
        private int _race;
        private int _face;
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
        public class Features
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
        public void CharaMakeColorSelectorLips(CmpReader colorMap, int start, int length)
        {
            colorListView.Items.Clear();
            for (int i = start; i < start + length; i++)
            {
                ListViewItem item = new ListViewItem();
                item.Width = 64;
                item.Height = 64;
                var newColor = new SolidColorBrush(Color.FromArgb(colorMap.Colors[i].A, colorMap.Colors[i].R, colorMap.Colors[i].G, colorMap.Colors[i].B));
                item.Background = newColor;
                item.FontSize = 13;
                item.FontWeight = FontWeights.Bold;
                item.Content = "Dark-" + (i - start);
                colorListView.Items.Add(item);
            }
            for (int i = 0; i < 32; i++)
            {
                ListViewItem item = new ListViewItem();
                item.Width = 64;
                item.Height = 64;
                item.FontSize = 12;
                item.Visibility = Visibility.Collapsed;
                colorListView.Items.Add(item);
            }
            for (int i = 1792; i < 1792 + 96; i++)
            {
                ListViewItem item = new ListViewItem();
                item.Width = 64;
                item.Height = 64;
                var newColor = new SolidColorBrush(Color.FromArgb(colorMap.Colors[i].A, colorMap.Colors[i].R, colorMap.Colors[i].G, colorMap.Colors[i].B));
                item.Background = newColor;
                item.FontSize = 11;
                item.FontWeight = FontWeights.Bold;
                item.Content = "Light-" + (i - (1792 - 128));
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
                    return !Gender ? 28928 : 30208;
                case 12: //Xaela
                    return !Gender ? 31488 : 32768;
                case 13: //Helions
                    return 34048;
                case 14: //The Lost
                    return 35840;
                case 15: // Rava
                    return 40448;
                case 16: // Veena
                    return 43008;
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
                case 13: //Helions
                    return 34304;
                case 14: //The Lost
                    return 36608;
                case 15: // Rava
                    return 40704;
                case 16: // Veena
                    return 43264;
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
        public static bool CheckCustomizeList(ExdCsvReader reader)
        {
            if (reader.CharaMakeFeatures == null)
            {
                reader.MakeCharaMakeFeatureList();
                if (reader.CharaMakeFeatures == null)
                {
                    return false;
                }
            }
            return true;
        }
        public static bool CheckCustomizeList2(ExdCsvReader reader)
        {
            if (reader.CharaMakeFeatures2 == null)
            {
                reader.MakeCharaMakeFeatureFacialList();
                if (reader.CharaMakeFeatures2 == null)
                {
                    return false;
                }
            }
            return true;
        }
        public void CharaMakeFeatureSelector(int tribe, int gender, ExdCsvReader reader)
        {

            if (DidUserInteract) return;
            if (tribe == 0)
            {
                MessageBox.Show("You can't have Clan set to None when using this!", App.ToolName, MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (!CheckCustomizeList(reader))
                return;
            DidUserInteract = true;
            _tribe = tribe;
            _gender = gender;
            _reader = reader;

            FillHairStyle();
        }
        public void CharaMakeFeatureSelector2(int tribe, int gender, ExdCsvReader reader)
        {
            if (DidUserInteract) return;
            if (tribe == 0)
            {
                MessageBox.Show("You can't have Clan set to None when using this!", App.ToolName, MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (!CheckCustomizeList(reader))
                return;
            CheckIncluded.IsChecked = false;
            DidUserInteract = true;
            _tribe = tribe;
            _gender = gender; 
            _reader = reader;

            FillFacePaint();
        }
        public void CharaMakeFeatureSelector3(int face ,int race, int tribe, int gender, ExdCsvReader reader)
        {
            if (DidUserInteract) return;
            if (tribe == 0)
            {
                MessageBox.Show("You can't have Clan set to None when using this!", App.ToolName, MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (!CheckCustomizeList2(reader))
                return;
            DidUserInteract = true;
            _tribe = tribe;
            _gender = gender;
            _reader = reader;
            _race = race;
            _face = face;
            FillFacialFeature(_face, tribe, gender);
        }
        ExdCsvReader.CMCharaMakeCustomizeFeature GetFeature(int startIndex, int length, byte dataKey)
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
                case 13: // The Lost/Helions
                case 14: // The Lost/Helions
                    return 1400;
                case 15: // Rava
                case 16: // Veena
                    return 1500;
            }

            throw new NotImplementedException();
        }
        int GetFacePaintByIndex(int tribeKey, bool isMale)
        {
            switch (tribeKey)
            {
                case 1: // Midlander
                    return isMale ? 1600 : 1650;
                case 2: // Highlander
                    return isMale ? 1700 : 1750;
                case 3: // Wildwood
                    return isMale ? 1800 : 1850;
                case 4: // Duskwight
                    return isMale ? 1900 : 1950;
                case 5: // Plainsfolks
                    return isMale ? 2000 : 2050;
                case 6: // Dunesfolk
                    return isMale ? 2100 : 2150;
                case 7: // Seeker of the Sun
                    return isMale ? 2200 : 2250;
                case 8: // Keeper of the Moon
                    return isMale ? 2300 : 2350;
                case 9: // Sea Wolf
                    return isMale ? 2400 : 2450;
                case 10: // Hellsguard
                    return isMale ? 2500 : 2550;
                case 11: // Raen
                    return isMale ? 2600 : 2650;
                case 12: // Xaela
                    return isMale ? 2700 : 2750;
                case 13: // Helions
                    return 2800;
                case 14: // The Lost
                    return 2850;
                case 15: // Rava
                    return 2900;
                case 16: // Veena
                    return 2950;
            }

            throw new NotImplementedException();
        }
        public void FillFacePaint()
        {
            try
            {
                FacePaintFeature.Items.Clear();
                int added = 0;
                for (int i = 0; i < 200; i++)
                {
                    if (i == 0)
                    {
                        FacePaintFeature.Items.Add(new FeatureSelect() { ID = 0, FeatureImage = GetImageStream((System.Drawing.Image)Properties.Resources.ResourceManager.GetObject("Nope")) });
                        added++;
                        continue;
                    }
                    var feature = GetFeature(GetFacePaintByIndex(_tribe, _gender == 0), 50, (byte)i);

                    if (feature == null)
                        continue;
                    FacePaintFeature.Items.Add(new FeatureSelect() { ID = feature.FeatureID, FeatureImage = feature.Icon });
                    added++;
                }
                DidUserInteract = false;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public void FillHairStyle()
        {
            try
            {
                CharacterFeature.Items.Clear();
                for (var i = 0; i < 200; i++)
                {
                    var feature = GetFeature(GetHairstyleCustomizeIndex(_tribe, _gender == 0), 100, (byte)i);

                    if (feature == null)
                        continue;
                    CharacterFeature.Items.Add(new FeatureSelect() { ID = feature.FeatureID, FeatureImage = feature.Icon });
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
        private void CharacterFeature2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FacePaintFeature.SelectedItem == null)
                return;
            var Value = (FeatureSelect)FacePaintFeature.SelectedItem;
            if (CheckIncluded.IsChecked == true) Value.ID += 128;
            CharacterDetails.FacePaint.value = (byte)Value.ID;
            string hexValue = Value.ID.ToString("X");
            MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.FacePaint), "byte", hexValue);
        }
        private void ModelBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ModelBox.SelectedCells.Count > 0)
            {
                if (ModelBox.SelectedItem == null)
                    return;
                if (CharacterDetails.EntitySub.value == 5 || MemoryManager.Instance.MemLib.readByte(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.EntitySub))==5) return; 
                var Value = (ExdCsvReader.CMMonster)ModelBox.SelectedItem;
                CharacterDetails.ModelType.value = Value.Index;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.ModelType), "int", Value.Index.ToString());
            }
        }

        private void SearchModelBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var filter = SearchModelBox.Text.ToLower();
            ModelBox.Items.Clear();
            foreach (var m in CharacterDetailsView._exdProvider.Monsters.Where(g => g.Name.ToLower().Contains(filter)))
                if (m.Real == true)
                {
                    ModelBox.Items.Add(new ExdCsvReader.CMMonster
                    {
                        Index = Convert.ToInt32(m.Index),
                        Name = m.Name.ToString()
                    });
                }
        }

        private void AnimatedTabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.OriginalSource is TabControl)
            {
                if (HairTab.IsSelected)
                {
                    CharaMakeFeatureSelector(CharacterDetails.Clan.value, CharacterDetails.Gender.value, CharacterDetailsView._exdProvider);
                }
                else if (PaintTab.IsSelected)
                {
                    CheckIncluded.IsChecked = false;
                    CharaMakeFeatureSelector2(CharacterDetails.Clan.value, CharacterDetails.Gender.value, CharacterDetailsView._exdProvider);
                }
                else if(FacialTab.IsSelected)
                {
                    CharaMakeFeatureSelector3(CharacterDetails.Head.value, CharacterDetails.Race.value, CharacterDetails.Clan.value, CharacterDetails.Gender.value, CharacterDetailsView._exdProvider);
                }
            }
            else return;
            e.Handled = true;
        }
        public void HairRandomPick(int tribe, int gender, ExdCsvReader reader)
        {
            if (tribe == 0)
            {
                MessageBox.Show("You can't have Clan set to None when using this!", App.ToolName, MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (DidUserInteract) return;
            DidUserInteract = true;
            if (!CheckCustomizeList(reader)) return;
            _tribe = tribe;
            _gender = gender;
            _reader = reader;
            try
            {
                CharacterFeature.Items.Clear();
                int added = 0;
                for (int i = 0; i < 200; i++)
                {
                    var feature = GetFeature(GetHairstyleCustomizeIndex(_tribe, _gender == 0), 100, (byte)i);

                    if (feature == null)
                        continue;
                    CharacterFeature.Items.Add(new FeatureSelect() { ID = feature.FeatureID, FeatureImage = feature.Icon });
                    added++;
                }
                DidUserInteract = false;
                Random rnd = new Random();
                int Value = rnd.Next(CharacterFeature.Items.Count);
                var featureCheck = (FeatureSelect)CharacterFeature.Items[Value];
                CharacterDetails.Hair.value = (byte)featureCheck.ID;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Hair), "byte", featureCheck.ID.ToString("X"));
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        private enum FacialEnums
        {
            Feature1 = 1,
            Feature2 = 2,
            Feature3 = 4,
            Feature4 = 8,
            Feature5 = 16,
            ExtraFeature = 32,
            ExtraFeature2 = 64
        }
        public void FillFacialFeature(int faceKey, int tribeKey, int gender)
        {
            try
            {
                // Subtract one from the face key to get the proper index for the array.
                faceKey = Math.Max(faceKey - 1, 0);
                // Clear out the facial features list.
                FacialFeatureView.Items.Clear();

                // Get the features that match our tribe and gender.
                var data = _reader.CharaMakeFeatures2.Where(f => f.Tribe == tribeKey && f.Gender == gender).First();

                // Add the no feature option.
                FacialFeatureView.Items.Add(new Features { ID = 0, FeatureImage = GetImageStream((System.Drawing.Image)Properties.Resources.ResourceManager.GetObject("Nope")) });

                // Loop over the 7 facial feature options available.
                for (var i = 0; i < 7; i++)
                    FacialFeatureView.Items.Add(new Features { ID = (int)Math.Pow(2, i), FeatureImage = data.Features[8 * i + faceKey].Icon });

                // Add the legacy mark option.
                FacialFeatureView.Items.Add(new Features { ID = 128, FeatureImage = GetImageStream((System.Drawing.Image)Properties.Resources.ResourceManager.GetObject("Legacy")) });

                // What?
                DidUserInteract = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void FacialFeatureView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FacialFeatureView.SelectedItem == null)
                return;
            byte result = 0;
            foreach (Features r in FacialFeatureView.SelectedItems)
            {
                if (r.ID == 0)
                {
                    FacialFeatureView.SelectedIndex = -1;
                    CharacterDetails.FacialFeatures.value = 0;
                    MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.FacialFeatures), "byte", "0");
                    return;
                }
                else
                    result += (byte)r.ID;
            }
            CharacterDetails.FacialFeatures.value = (byte)result;
            string hexValue = result.ToString("X");
            MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.FacialFeatures), "byte", hexValue);
            e.Handled = true;
        }
    }
}