using ConceptMatrix.Utility;
using ConceptMatrix.Views;
using MaterialDesignThemes.Wpf;
using SaintCoinach;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Media;
using System.Xml.Serialization;

namespace ConceptMatrix.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private static Mediator mediator;

        private static BackgroundWorker worker;
        public Mem MemLib = new Mem();
        public static int gameProcId = 0;
        public static ThreadWriting ThreadTime;
        public static RotationView RotTime;
        public static PoseMatrixView ViewTime5;
        public static CharacterDetailsView4 ViewTime4;
        public static CharacterDetailsView3 ViewTime3;
        public static CharacterDetailsView2 ViewTime2;
        public static CharacterDetailsView ViewTime;
        public static AboutView AboutTime;
        public static MainWindow MainTime;
        public static MainViewModel MainViewModelX;
        private static CharacterDetailsViewModel characterDetails;
        public static string RegionType = "Live";
		public event PropertyChangedEventHandler PropertyChanged;
        public static string GameDirectory = "";
		public CharacterDetailsViewModel CharacterDetails { get => characterDetails; set => characterDetails = value; }

        public PackIconKind AOTToggleStatus { get; set; } = PackIconKind.ToggleSwitchOffOutline;
		public Brush ToggleForeground { get; set; } = new SolidColorBrush(Color.FromArgb(0x75, 0xFF, 0xFF, 0xFF));

		public MainViewModel()
        {
            try
            {
                if (!MainWindow.HasRead)
                {
                    if (!App.IsValidGamePath(GameDirectory))
                    {
                        FlexibleMessageBox.Show($"Please make sure ffxivgame.ver is in \n\n{GameDirectory}/game diirectory", $"ValidGamePath Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    ARealmReversed realm = null;
                    if (File.Exists(Path.Combine(GameDirectory, "FFXIVBoot.exe")) || File.Exists(Path.Combine(GameDirectory, "rail_files", "rail_game_identify.json")))
                    {
                        RegionType = "zh";
                        File.WriteAllText("Definitions/Item.json", Properties.Resources.ItemCN);
                        File.WriteAllText("Definitions/Stain.json", Properties.Resources.StainCN);
                        realm = new ARealmReversed(GameDirectory, SaintCoinach.Ex.Language.ChineseSimplified);
                    }
                    else if (File.Exists(Path.Combine(GameDirectory, "boot", "FFXIV_Boot.exe")))
                    {
                        RegionType = "ko";
                        File.WriteAllText("Definitions/Item.json", Properties.Resources.ItemKR);
                        File.WriteAllText("Definitions/Stain.json", Properties.Resources.StainKR);
                        realm = new ARealmReversed(GameDirectory, SaintCoinach.Ex.Language.Korean);
                    }
                    if (RegionType == "Live")
                    {
                        File.WriteAllText("Definitions/Item.json", Properties.Resources.Item);
                        File.WriteAllText("Definitions/Stain.json", Properties.Resources.Stain);
                        if (SaveSettings.Default.Language == "en") realm = new ARealmReversed(GameDirectory, SaintCoinach.Ex.Language.English);
                        else if (SaveSettings.Default.Language == "ja") realm = new ARealmReversed(GameDirectory, SaintCoinach.Ex.Language.Japanese);
                        else if (SaveSettings.Default.Language == "de") realm = new ARealmReversed(GameDirectory, SaintCoinach.Ex.Language.German);
                        else if (SaveSettings.Default.Language == "fr") realm = new ARealmReversed(GameDirectory, SaintCoinach.Ex.Language.French);
                        else realm = new ARealmReversed(GameDirectory, SaintCoinach.Ex.Language.English);
                    }
                    Initialize(realm, RegionType);
                    MainWindow.HasRead = true;
                }
                mediator = new Mediator();
                MainViewModelX = this;
                MemoryManager.Instance.MemLib.OpenProcess(gameProcId);
                LoadSettings(RegionType);
                worker = new BackgroundWorker();
                worker.DoWork += Worker_DoWork;
                worker.WorkerSupportsCancellation = true;
                worker.RunWorkerAsync();
                characterDetails = new CharacterDetailsViewModel(mediator);
                CharacterDetailsViewModel.baseAddr = MemoryManager.Add(MemoryManager.Instance.BaseAddress, "8");
                //  ViewTime5.bonetree = ViewTime5.InitBonetree();
                PoseMatrixViewModel.PoseVM.InitBonetree();
                Task.Delay(40).Wait();
                ThreadTime = new ThreadWriting(); // Thread Writing
                ViewTime5.RotationUpDown.DataContext = this;
                ViewTime5.RotationUpDown2.DataContext = this;
                ViewTime5.RotationUpDown3.DataContext = this;
                ViewTime5.RotationSlider.DataContext = this;
                ViewTime5.RotationSlider2.DataContext = this;
                ViewTime5.RotationSlider3.DataContext = this;
                ViewTime5.RotateCheckBox1.DataContext = this;
                ViewTime5.RotateCheckBox2.DataContext = this;
                ViewTime5.RotateCheckBox3.DataContext = this;
                ViewTime5.PosX.DataContext = this;
                ViewTime5.PosY.DataContext = this;
                ViewTime5.PosZ.DataContext = this;
                ViewTime5.XCheck.DataContext = this;
                ViewTime5.YCheck.DataContext = this;
                ViewTime5.ZCheck.DataContext = this;
                ViewTime5.PosRelButton.DataContext = this;
                if (SaveSettings.Default.AdvancedMove == true)
                {
                    CharacterDetails.CharacterDetails.RelativePositioning = true;
                }
            }
            catch(Exception)
            {
            }
        }
        public static void ShutDownStuff()
        {
            worker.CancelAsync();
            ThreadTime.worker.CancelAsync();
            characterDetails = null;
            mediator = null;
            ThreadTime = null;
        }
        
        private void Initialize(ARealmReversed realm, string Determination)
        {
            if (!realm.IsCurrentVersion)
            {
                try
                {
                    if (File.Exists("SaintCoinach.History.zip"))
                        File.Delete("SaintCoinach.History.zip");
                    if (File.Exists(Path.Combine(GameDirectory, "FFXIVBoot.exe")) || File.Exists(Path.Combine(GameDirectory, "rail_files", "rail_game_identify.json")))
                    {
                        File.WriteAllText("Definitions/Item.json", Properties.Resources.ItemCN);
                        File.WriteAllText("Definitions/Stain.json", Properties.Resources.StainCN);
                        realm = new ARealmReversed(GameDirectory, SaintCoinach.Ex.Language.ChineseSimplified);
                    }
                    else if (File.Exists(Path.Combine(GameDirectory, "boot", "FFXIV_Boot.exe")))
                    {
                        File.WriteAllText("Definitions/Item.json", Properties.Resources.ItemKR);
                        File.WriteAllText("Definitions/Stain.json", Properties.Resources.StainKR);
                        realm = new ARealmReversed(GameDirectory, SaintCoinach.Ex.Language.Korean);
                    }
                    if (Determination == "Live")
                    {
                        File.WriteAllText("Definitions/Item.json", Properties.Resources.Item);
                        File.WriteAllText("Definitions/Stain.json", Properties.Resources.Stain);
                        if (SaveSettings.Default.Language == "en") realm = new ARealmReversed(GameDirectory, SaintCoinach.Ex.Language.English);
                        else if (SaveSettings.Default.Language == "ja") realm = new ARealmReversed(GameDirectory, SaintCoinach.Ex.Language.Japanese);
                        else if (SaveSettings.Default.Language == "de") realm = new ARealmReversed(GameDirectory, SaintCoinach.Ex.Language.German);
                        else if (SaveSettings.Default.Language == "fr") realm = new ARealmReversed(GameDirectory, SaintCoinach.Ex.Language.French);
                        else realm = new ARealmReversed(GameDirectory, SaintCoinach.Ex.Language.English);
                    }
                }
                catch
                {
                    System.Windows.MessageBox.Show("Unable to delete SaintCoinach.History.zip! Please don't open zip or use it.", "Oh wow!");
                }
            }
            try
            {
                realm.Packs.GetPack(new SaintCoinach.IO.PackIdentifier("exd", SaintCoinach.IO.PackIdentifier.DefaultExpansion, 0)).KeepInMemory = true;
                MainWindow.Realm = realm;
                CharacterDetailsView._exdProvider.RaceList();
                CharacterDetailsView._exdProvider.TribeList();
                CharacterDetailsView._exdProvider.DyeList();
                CharacterDetailsView._exdProvider.MonsterList();
                ExdCsvReader.MonsterX = CharacterDetailsView._exdProvider.Monsters.Values.ToArray();
                for (int i = 0; i < CharacterDetailsView._exdProvider.Dyes.Count; i++)
                {
                    ViewTime2.HeadDye.Items.Add(CharacterDetailsView._exdProvider.Dyes[i].Name);
                    ViewTime2.ChestBox.Items.Add(CharacterDetailsView._exdProvider.Dyes[i].Name);
                    ViewTime2.ArmBox.Items.Add(CharacterDetailsView._exdProvider.Dyes[i].Name);
                    ViewTime2.MHBox.Items.Add(CharacterDetailsView._exdProvider.Dyes[i].Name);
                    ViewTime2.OHBox.Items.Add(CharacterDetailsView._exdProvider.Dyes[i].Name);
                    ViewTime2.LegBox.Items.Add(CharacterDetailsView._exdProvider.Dyes[i].Name);
                    ViewTime2.FeetBox.Items.Add(CharacterDetailsView._exdProvider.Dyes[i].Name);
                }
                foreach (ExdCsvReader.Monster xD in ExdCsvReader.MonsterX)
                {
                    if (xD.Real == true)
                    {
                        ViewTime.SpecialControl.ModelBox.Items.Add(new ExdCsvReader.Monster
                        {
                            Index = Convert.ToInt32(xD.Index),
                            Name = xD.Name.ToString()
                        });
                    }
                }
                for (int i = 0; i < CharacterDetailsView._exdProvider.Races.Count; i++)
                {
                    ViewTime.RaceBox.Items.Add(CharacterDetailsView._exdProvider.Races[i].Name);
                }
                for (int i = 0; i < CharacterDetailsView._exdProvider.Tribes.Count; i++)
                {
                    ViewTime.ClanBox.Items.Add(CharacterDetailsView._exdProvider.Tribes[i].Name);
                }
                var WeatherSheet = MainWindow.Realm.GameData.GetSheet<SaintCoinach.Xiv.Weather>();
                foreach (SaintCoinach.Xiv.Weather weather in WeatherSheet)
                {
                    if (weather.Key == 0 || weather.Icon == null)
                    {
                        byte[] Bytes = { (byte)weather.Key, (byte)weather.Key };
                        ViewTime3.ForceWeatherBox.Items.Add(new ExdCsvReader.Weather
                        {
                            Index = Convert.ToInt32(weather.Key),
                            Key = BitConverter.ToUInt16(Bytes, 0),
                            Name = weather.Name.ToString(),
                            Icon = null
                        });
                    }
                    else
                    {
                        byte[] Bytes = { (byte)weather.Key, (byte)weather.Key };
                        try
                        {
                            ViewTime3.ForceWeatherBox.Items.Add(new ExdCsvReader.Weather
                            {
                                Index = Convert.ToInt32(weather.Key),
                                Name = weather.Name.ToString(),
                                Key = BitConverter.ToUInt16(Bytes, 0),
                                Icon = ExdCsvReader.CreateSource(weather.Icon)
                            });
                        }
                        catch
                        {
                            ViewTime3.ForceWeatherBox.Items.Add(new ExdCsvReader.Weather
                            {
                                Index = Convert.ToInt32(weather.Key),
                                Name = weather.Name.ToString(),
                                Key = BitConverter.ToUInt16(Bytes, 0),
                                Icon = null
                            });
                        }
                    }
                }
                var StatusSheet = MainWindow.Realm.GameData.GetSheet<SaintCoinach.Xiv.Status>();
                HashSet<byte> Sets = new HashSet<byte>();
                foreach (SaintCoinach.Xiv.Status status in StatusSheet)
                {
                    if (status.Key == 0)
                    {
                        ViewTime4.StatusEffectBox2.Items.Add(new ComboBoxItem() { Content = "None", Tag = 0 });
                    }
                    if (Sets.Contains(status.VFX) || status.VFX <= 0) continue;
                    Sets.Add(status.VFX);
                    string name = status.Name.ToString();
                    if (name.Length <= 0) name = "None";
                    ViewTime4.StatusEffectBox2.Items.Add(new ComboBoxItem() { Content = name, Tag = status.Key });
                }
                var TitleSheet = MainWindow.Realm.GameData.GetSheet<SaintCoinach.Xiv.Title>();
                foreach (SaintCoinach.Xiv.Title title in TitleSheet)
                {
                    string Title = title.Feminine;
                    if (Title.Length <= 0) Title = "No Title";
                    ViewTime.TitleBox.Items.Add(Title);
                }
            }
            catch(Exception)
            {
            
            }
        }
        private void LoadSettings(string region)
        {
            // create an xml serializer
            var serializer = new XmlSerializer(typeof(Settings), "");
            // create namespace to remove it for the serializer
            var ns = new XmlSerializerNamespaces();
            // add blank namespaces
            ns.Add("", "");
            if (region=="Live")
            {
                using (var reader = new StreamReader(@"./OffsetSettings.xml"))
                {
                    try
                    {
                        Settings.Instance = (Settings)serializer.Deserialize(reader);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                }
                if (CheckUpdate(region) == true)
                {
                    System.Windows.MessageBox.Show("We successfully updated offsets automatically for you! Please Restart the program or Press Find New Process on the top right of the application if this doesn't work!", "Oh wow!");
                }
            }
            else if (region == "zh")
            {
                using (var reader = new StreamReader(@"./OffsetSettingsCN.xml"))
                {
                    try
                    {
                        Settings.Instance = (Settings)serializer.Deserialize(reader);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                }
                if (CheckUpdate(region) == true)
                {
                    System.Windows.MessageBox.Show("We successfully updated offsets automatically for you! Please Restart the program or Press Find New Process on the top right of the application if this doesn't work!", "Oh wow!");
                }
            }
            else if (region == "ko")
            {
                using (var reader = new StreamReader(@"./OffsetSettingsKO.xml"))
                {
                    try
                    {
                        Settings.Instance = (Settings)serializer.Deserialize(reader);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                }
                if (CheckUpdate(region) == true)
                {
                    System.Windows.MessageBox.Show("We successfully updated offsets automatically for you! Please Restart the program or Press Find New Process on the top right of the application if this doesn't work!", "Oh wow!");
                }
            }
        }
        private bool CheckUpdate(string region)
        {
            if (region == "Live")
            {
                try
                {
                    string xmlStr;
                    ServicePointManager.SecurityProtocol = (ServicePointManager.SecurityProtocol & SecurityProtocolType.Ssl3) | (SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12);
                    using (var HAH = new WebClient())
                    {
                        xmlStr = HAH.DownloadString(@"https://raw.githubusercontent.com/imchillin/CMTool/master/ConceptMatrix/OffsetSettings.xml");
                    }
                    var serializer = new XmlSerializer(typeof(Settings), "");
                    var xmlDoc = new System.Xml.XmlDocument();
                    xmlDoc.LoadXml(xmlStr);
                    var offset = (Settings)serializer.Deserialize(new StringReader(xmlDoc.InnerXml));
                    if (!string.Equals(Settings.Instance.LastUpdated, offset.LastUpdated))
                    {
                        File.WriteAllText(@"./OffsetSettings.xml", xmlDoc.InnerXml);
                        Settings.Instance = offset;
                        return true;
                    }
                    else return false;
                }
                catch
                {
                    return false;
                }
            }
            else if (region == "zh")
            {
                try
                {
                    string xmlStr;
                    ServicePointManager.SecurityProtocol = (ServicePointManager.SecurityProtocol & SecurityProtocolType.Ssl3) | (SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12);
                    using (var HAH = new WebClient())
                    {
                        xmlStr = HAH.DownloadString(@"https://raw.githubusercontent.com/imchillin/CMTool/master/ConceptMatrix/OffsetSettingsCN.xml");
                    }
                    var serializer = new XmlSerializer(typeof(Settings), "");
                    var xmlDoc = new System.Xml.XmlDocument();
                    xmlDoc.LoadXml(xmlStr);
                    var offset = (Settings)serializer.Deserialize(new StringReader(xmlDoc.InnerXml));
                    if (!string.Equals(Settings.Instance.LastUpdated, offset.LastUpdated))
                    {
                        File.WriteAllText(@"./OffsetSettingsCN.xml", xmlDoc.InnerXml);
                        Settings.Instance = offset;
                        return true;
                    }
                    else return false;
                }
                catch
                {
                    return false;
                }
            }
            else if (region == "ko")
            {
                try
                {
                    string xmlStr;
                    ServicePointManager.SecurityProtocol = (ServicePointManager.SecurityProtocol & SecurityProtocolType.Ssl3) | (SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12);
                    using (var HAH = new WebClient())
                    {
                        xmlStr = HAH.DownloadString(@"https://raw.githubusercontent.com/imchillin/CMTool/master/ConceptMatrix/OffsetSettingsKO.xml");
                    }
                    var serializer = new XmlSerializer(typeof(Settings), "");
                    var xmlDoc = new System.Xml.XmlDocument();
                    xmlDoc.LoadXml(xmlStr);
                    var offset = (Settings)serializer.Deserialize(new StringReader(xmlDoc.InnerXml));
                    if (!string.Equals(Settings.Instance.LastUpdated, offset.LastUpdated))
                    {
                        File.WriteAllText(@"./OffsetSettingsKO.xml", xmlDoc.InnerXml);
                        Settings.Instance = offset;
                        return true;
                    }
                    else return false;
                }
                catch
                {
                    return false;
                }
            }
            else return false;
        }
        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            // no fancy tricks here boi
            MemoryManager.Instance.BaseAddress = MemoryManager.Instance.GetBaseAddress(int.Parse(Settings.Instance.AoBOffset, NumberStyles.HexNumber));
            MemoryManager.Instance.TargetAddress = MemoryManager.Instance.GetBaseAddress(int.Parse(Settings.Instance.TargetOffset, NumberStyles.HexNumber));
            MemoryManager.Instance.CameraAddress = MemoryManager.Instance.GetBaseAddress(int.Parse(Settings.Instance.CameraOffset, NumberStyles.HexNumber));
            MemoryManager.Instance.GposeAddress = MemoryManager.Instance.GetBaseAddress(int.Parse(Settings.Instance.GposeOffset, NumberStyles.HexNumber));
            MemoryManager.Instance.GposeEntityOffset = MemoryManager.Instance.GetBaseAddress(int.Parse(Settings.Instance.GposeEntityOffset, NumberStyles.HexNumber));
            MemoryManager.Instance.GposeCheckAddress = MemoryManager.Instance.GetBaseAddress(int.Parse(Settings.Instance.GposeCheckOffset, NumberStyles.HexNumber));
            MemoryManager.Instance.GposeCheck2Address = MemoryManager.Instance.GetBaseAddress(int.Parse(Settings.Instance.GposeCheck2Offset, NumberStyles.HexNumber));
            MemoryManager.Instance.TimeAddress = MemoryManager.Instance.GetBaseAddress(int.Parse(Settings.Instance.TimeOffset, NumberStyles.HexNumber));
            MemoryManager.Instance.WeatherAddress = MemoryManager.Instance.GetBaseAddress(int.Parse(Settings.Instance.WeatherOffset, NumberStyles.HexNumber));
            MemoryManager.Instance.TerritoryAddress = MemoryManager.Instance.GetBaseAddress(int.Parse(Settings.Instance.TerritoryOffset, NumberStyles.HexNumber));
            MemoryManager.Instance.MusicOffset = MemoryManager.Instance.GetBaseAddress(int.Parse(Settings.Instance.MusicOffset, NumberStyles.HexNumber));
            MemoryManager.Instance.GposeFilters = MemoryManager.Instance.GetBaseAddress(int.Parse(Settings.Instance.GposeFilters, NumberStyles.HexNumber));
            MemoryManager.Instance.SkeletonAddress = MemoryManager.Instance.GetBaseAddress(int.Parse(Settings.Instance.SkeletonOffset, NumberStyles.HexNumber));
            MemoryManager.Instance.SkeletonAddress2 = MemoryManager.Instance.GetBaseAddress(int.Parse(Settings.Instance.SkeletonOffset2, NumberStyles.HexNumber));
            MemoryManager.Instance.SkeletonAddress3 = MemoryManager.Instance.GetBaseAddress(int.Parse(Settings.Instance.SkeletonOffset3, NumberStyles.HexNumber));
            MemoryManager.Instance.SkeletonAddress4 = MemoryManager.Instance.GetBaseAddress(int.Parse(Settings.Instance.SkeletonOffset4, NumberStyles.HexNumber));
            MemoryManager.Instance.SkeletonAddress5 = MemoryManager.Instance.GetBaseAddress(int.Parse(Settings.Instance.SkeletonOffset5, NumberStyles.HexNumber));
            MemoryManager.Instance.SkeletonAddress6 = MemoryManager.Instance.GetBaseAddress(int.Parse(Settings.Instance.SkeletonOffset6, NumberStyles.HexNumber));
            MemoryManager.Instance.PhysicsAddress = MemoryManager.Instance.GetBaseAddress(int.Parse(Settings.Instance.PhysicsOffset, NumberStyles.HexNumber));
            MemoryManager.Instance.PhysicsAddress2 = MemoryManager.Instance.GetBaseAddress(int.Parse(Settings.Instance.PhysicsOffset2, NumberStyles.HexNumber));
            MemoryManager.Instance.PhysicsAddress3 = MemoryManager.Instance.GetBaseAddress(int.Parse(Settings.Instance.PhysicsOffset3, NumberStyles.HexNumber));
            MemoryManager.Instance.CharacterRenderAddress = MemoryManager.Instance.GetBaseAddress(int.Parse(Settings.Instance.CharacterRenderOffset, NumberStyles.HexNumber));
            MemoryManager.Instance.CharacterRenderAddress2 = MemoryManager.Instance.GetBaseAddress(int.Parse(Settings.Instance.CharacterRenderOffset2, NumberStyles.HexNumber));
            while (true)
            {
                if (worker.CancellationPending)
                {
                    e.Cancel = true;
                }
                // sleep for 50 ms
                Thread.Sleep(50);
                // check if our memory manager is set /saving
                if (!MainWindow.CurrentlySaving) mediator.SendWork();
            }
        }

		public void ToggleStatus(bool on)
		{
			ToggleForeground = on ? new SolidColorBrush(Color.FromArgb(255, 255, 255, 255)) : new SolidColorBrush(Color.FromArgb(0x75, 0xFF, 0xFF, 0xFF));
			AOTToggleStatus = on ? PackIconKind.ToggleSwitch : PackIconKind.ToggleSwitchOffOutline;
		}
    }
}
