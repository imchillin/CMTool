using ConceptMatrix.Utility;
using ConceptMatrix.Views;
using Lumina;
using Lumina.Data.Files;
using Lumina.Excel.GeneratedSheets;
using Lumina.Extensions;
using MaterialDesignThemes.Wpf;
using Newtonsoft.Json;
using SaintCoinach;
using SaintCoinach.Imaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Xml.Serialization;

namespace ConceptMatrix.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private static Mediator mediator;
        public static Lumina.Lumina lumina;

        public static BackgroundWorker worker;
        public Mem MemLib = new Mem();
        public static int gameProcId = 0;
        public static ThreadWriting threadWriting;
        public static RotationView rotationView;
        public static PosingOldView posingView;
        public static PoseMatrixView posing2View;
        public static PoseMatrixViewModel PoseMatrixVM;
        public static ActorPropertiesView actorPropView;
        public static WorldView worldView;
        public static EquipmentView equipView;
        public static CharacterDetailsView characterView;
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
                        FlexibleMessageBox.Show($"Please make sure ffxivgame.ver is in \n\n{GameDirectory}/game directory", $"ValidGamePath Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Set up Lumina for the game.
                    lumina = new Lumina.Lumina(Path.Combine(GameDirectory, "game", "sqpack"));

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
                Task.Delay(40).Wait();
                threadWriting = new ThreadWriting(); // Thread Writing

                PoseMatrixVM = new PoseMatrixViewModel();
                PoseMatrixViewModel.PoseVM.InitBonetree();
                posing2View.DataContext = PoseMatrixVM;
                posingView.DataContext = PoseMatrixVM;
                posing2View.RotationUpDown.DataContext = this;
                posing2View.RotationUpDown2.DataContext = this;
                posing2View.RotationUpDown3.DataContext = this;
                posing2View.RotationSlider.DataContext = this;
                posing2View.RotationSlider2.DataContext = this;
                posing2View.RotationSlider3.DataContext = this;
                posing2View.RotateCheckBox1.DataContext = this;
                posing2View.RotateCheckBox2.DataContext = this;
                posing2View.RotateCheckBox3.DataContext = this;
                posing2View.PosX.DataContext = this;
                posing2View.PosY.DataContext = this;
                posing2View.PosZ.DataContext = this;
                posing2View.XCheck.DataContext = this;
                posing2View.YCheck.DataContext = this;
                posing2View.ZCheck.DataContext = this;
                posing2View.PosRelButton.DataContext = this;
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
            threadWriting.worker.CancelAsync();
            characterDetails = null;
            mediator = null;
            threadWriting = null;
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

			#region My stuff

			// Get the stains (dyes).
            var stains = new List<CMStain>();
            // Loop through the Stains to add to a list.
            foreach (var stain in lumina.GetExcelSheet<Stain>())
            {
                // Convert color to bytes to turn into a solid color brush.
                var colorBytes = BitConverter.GetBytes(stain.Color);
                stains.Add(
                    new CMStain()
                    {
                        Id = stain.RowId,
                        Color = new SolidColorBrush(Color.FromRgb(colorBytes[2], colorBytes[1], colorBytes[0])), 
                        Name = stain.Name.DefaultIfEmpty("None")
                    }
                );
            }

            // Assign the item sources for the dye combo boxes.
            equipView.MHBox.ItemsSource = stains;
            equipView.OHBox.ItemsSource = stains;
            equipView.HeadDye.ItemsSource = stains;
            equipView.ChestBox.ItemsSource = stains;
            equipView.ArmBox.ItemsSource = stains;
            equipView.LegBox.ItemsSource = stains;
            equipView.FeetBox.ItemsSource = stains;

            // Race and Tribes.
            characterView.RaceBox.ItemsSource = from r in lumina.GetExcelSheet<Race>() select r.Feminine.DefaultIfEmpty("None");
            characterView.ClanBox.ItemsSource = from t in lumina.GetExcelSheet<Tribe>() select t.Feminine.DefaultIfEmpty("None");

            // Setting weather lists.
            var weatherList = new List<CMWeather>();
            // Loop through the weathers to add to a list.
            foreach (var weather in lumina.GetExcelSheet<Weather>())
            {
                var icon = lumina.GetIcon(weather.Icon);
                var cmw = new CMWeather()
                {
                    Id = (byte)weather.RowId,
                    Name = weather.Name.DefaultIfEmpty("None"),
                    Icon = icon.GetImage()
                };

                weatherList.Add(cmw);
            }

            // Assign the item sources for the weather combo boxes.
            worldView.ForceWeatherBox.ItemsSource = weatherList;
            worldView.WeatherBox.ItemsSource = weatherList;

            // Get status sheet.
            var statusList = from s in lumina.GetExcelSheet<Status>()
                             where s.VFX.Row != 0 || s.RowId == 0
                             select new CMStatus()
                             {
                                 Id = s.RowId,
                                 Name = s.Name.DefaultIfEmpty("None"),
                                 Description = s.Description,
                                 Icon = lumina.GetIcon(s.Icon).GetImage()
                             };
            actorPropView.StatusEffectBox2.ItemsSource = statusList;

            #endregion

            try
            {
                realm.Packs.GetPack(new SaintCoinach.IO.PackIdentifier("exd", SaintCoinach.IO.PackIdentifier.DefaultExpansion, 0)).KeepInMemory = true;
                MainWindow.Realm = realm;
                CharacterDetailsView._exdProvider.MonsterList();
                CharacterDetailsView._exdProvider.MakeTerritoryTypeList();

                var sw = Stopwatch.StartNew();
                CharacterDetailsView._exdProvider.MakeItemList();
                sw.Stop();

                Console.WriteLine($"MakeItemList took {sw.ElapsedMilliseconds}ms");
                
                foreach (var m in CharacterDetailsView._exdProvider.Monsters)
                {
                    if (m.Real == true)
                    {
                        characterView.SpecialControl.ModelBox.Items.Add(new ExdCsvReader.CMMonster
                        {
                            Index = Convert.ToInt32(m.Index),
                            Name = m.Name.ToString()
                        });
                    }
                }

                var TitleSheet = MainWindow.Realm.GameData.GetSheet<SaintCoinach.Xiv.Title>();
                foreach (SaintCoinach.Xiv.Title title in TitleSheet)
                {
                    string Title = title.Feminine;
                    if (Title.Length <= 0) Title = "No Title";
                    characterView.TitleBox.Items.Add(Title);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private void LoadSettings(string region)
        {
            // Why wasn't this done before... seriously?
            var file = @"./OffsetSettings";
            switch (region)
            {
                case "zh":
                    file += "CN";
                    break;
                case "ko":
                    file += "KO";
                    break;
            }
            file += ".json";

            using (var reader = new StreamReader(file))
            {
                try
                {
                    Settings.Instance = JsonConvert.DeserializeObject<Settings>(reader.ReadToEnd());
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
        private bool CheckUpdate(string region)
        {
            // Why wasn't this done before... seriously?
            var file = @"OffsetSettings";
            switch (region)
            {
                case "zh":
                    file += "CN";
                    break;
                case "ko":
                    file += "KO";
                    break;
            }
            file += ".json";

            try
            {
                string jsonStr;
                ServicePointManager.SecurityProtocol = (ServicePointManager.SecurityProtocol & SecurityProtocolType.Ssl3) | (SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12);
                using (var HAH = new WebClient())
                {
                    jsonStr = HAH.DownloadString(@"https://raw.githubusercontent.com/imchillin/CMTool/master/ConceptMatrix/" + file);
                }
                var offset = JsonConvert.DeserializeObject<Settings>(jsonStr);
                
                if (string.Compare(offset.LastUpdated, Settings.Instance.LastUpdated) > 0)
                {
                    File.WriteAllText($"./{file}", jsonStr);
                    Settings.Instance = offset;
                    return true;
                }
            }
            catch
            {
                return false;
            }

            return false;
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
            MemoryManager.Instance.SkeletonAddress7 = MemoryManager.Instance.GetBaseAddress(int.Parse(Settings.Instance.SkeletonOffset7, NumberStyles.HexNumber));
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
                    break;
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
