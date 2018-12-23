using FFXIVTool.Utility;
using FFXIVTool.ViewModel;
using FFXIVTool.Windows;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Interop;
using Microsoft.Win32;
using FFXIVTool.Models;
using Newtonsoft.Json;
using System.IO;
using MaterialDesignThemes.Wpf;
using AutoUpdaterDotNET;
using System.Net;
using System.Runtime.InteropServices;
using System.Windows.Data;
using FFXIVTool.Views;
using System.Collections.Specialized;
using System.Linq;
using System.Configuration;

namespace FFXIVTool
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {

        public int Processcheck = 0;
        public static bool CurrentlySaving = false;
        public CharacterDetails CharacterDetails { get => (CharacterDetails)BaseViewModel.model; set => BaseViewModel.model = value; }
        Version version = Assembly.GetExecutingAssembly().GetName().Version;
        public MainWindow()
        {
            ServicePointManager.SecurityProtocol = (ServicePointManager.SecurityProtocol & SecurityProtocolType.Ssl3) | (SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12);
            AutoUpdater.RunUpdateAsAdmin = true;
            AutoUpdater.DownloadPath = Environment.CurrentDirectory;
            AutoUpdater.Start("https://raw.githubusercontent.com/SaberNaut/xd/master/UpdateTest.xml");
            List<ProcessLooker.Game> GameList = new List<ProcessLooker.Game>();

            Process[] processlist = Process.GetProcesses();
            Processcheck = 0;
            foreach (Process theprocess in processlist)
            {
                if (theprocess.ProcessName.Contains("ffxiv_dx11"))
                {
                    Processcheck++;
                    GameList.Add(new ProcessLooker.Game() { ProcessName = theprocess.ProcessName, ID = theprocess.Id, StartTime = theprocess.StartTime, AppIcon = IconToImageSource(System.Drawing.Icon.ExtractAssociatedIcon(theprocess.MainModule.FileName)) });
                }
            }
            if (Processcheck > 1)
            {
                ProcessLooker f = new ProcessLooker(GameList);
                f.ShowDialog();
                if (f.Choice == null)
                {
                    Close();
                    return;
                }
                MainViewModel.gameProcId = f.Choice.ID;
            }
            if (Processcheck == 1)
                MainViewModel.gameProcId = GameList[0].ID;
            if (Processcheck <= 0)
            {
                ProcessLooker f = new ProcessLooker(GameList);
                f.ShowDialog();
                if (f.Choice == null)
                {
                    Close();
                    return;
                }
                MainViewModel.gameProcId = f.Choice.ID;
            }
            if (Properties.Settings.Default.UpgradeRequired)
            {
                Properties.Settings.Default.Upgrade();
                Properties.Settings.Default.UpgradeRequired = false;
                Properties.Settings.Default.Save();
            }
            var path = Path.Combine(Directory.GetCurrentDirectory(), "FFXIVTool.zip");
            var path2 = Path.Combine(Directory.GetCurrentDirectory(), "ZipExtractor.exe");
            if (File.Exists(path)) File.Delete(path);
            if (File.Exists(path2)) File.Delete(path2);
            InitializeComponent();
        }
        public static ImageSource IconToImageSource(System.Drawing.Icon icon)
        {
            return Imaging.CreateBitmapSourceFromHIcon(
                icon.Handle,
                new Int32Rect(0, 0, icon.Width, icon.Height),
                BitmapSizeOptions.FromEmptyOptions());
        }
        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            this.Title = "FFXIV Screenshot Tool - v" + version + "- Made By: Johto";
            DataContext = new MainViewModel();
            var accentColor = Properties.Settings.Default.Accent;
            new PaletteHelper().ReplaceAccentColor(accentColor);
            var primaryColor = Properties.Settings.Default.Primary;
            new PaletteHelper().ReplacePrimaryColor(primaryColor);
            var theme = Properties.Settings.Default.Theme;
            new PaletteHelper().SetLightDark(theme != "Light");
            this.Topmost = Properties.Settings.Default.TopApp;
        }

        private void CharacterRefreshButton_Click(object sender, RoutedEventArgs e)
        {
            MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.RenderToggle), "int", "2");
            Task.Delay(50).Wait();
            MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.RenderToggle), "int", "0");
        }

        private void FindProcess_Click(object sender, RoutedEventArgs e)
        {
            List<ProcessLooker.Game> GameList = new List<ProcessLooker.Game>();

            Process[] processlist = Process.GetProcesses();
            Processcheck = 0;
            foreach (Process theprocess in processlist)
            {
                if (theprocess.ProcessName.Contains("ffxiv_dx11"))
                {
                    Processcheck++;
                    GameList.Add(new ProcessLooker.Game() { ProcessName = theprocess.ProcessName, ID = theprocess.Id, StartTime = theprocess.StartTime, AppIcon = IconToImageSource(System.Drawing.Icon.ExtractAssociatedIcon(theprocess.MainModule.FileName)) });
                }
            }
            if (Processcheck > 1)
            {
                ProcessLooker f = new ProcessLooker(GameList);
                f.ShowDialog();
                if (f.Choice == null)
                    return;
                MainViewModel.ShutDownStuff();
                MainViewModel.gameProcId = f.Choice.ID;
                DataContext = new MainViewModel();
            }
            if (Processcheck == 1)
            {
                MainViewModel.ShutDownStuff();
                MainViewModel.gameProcId = GameList[0].ID;
                DataContext = new MainViewModel();
            }
        }

        private void NPCRefresh_Click(object sender, RoutedEventArgs e)
        {
            var xdad = (byte)MemoryManager.Instance.MemLib.readByte(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.EntityType));
            if (xdad == 1)
            {
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.EntityType), "byte", "2");
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.RenderToggle), "int", "2");
                Task.Delay(50).Wait();
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.RenderToggle), "int", "0");
                Task.Delay(50).Wait();
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.EntityType), "byte", "1");
            }
        }

        private void DiscordButton_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("https://discord.gg/nxu2Ydp");
        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            CurrentlySaving = true;
            SaveFileDialog dig = new SaveFileDialog();
            dig.Filter = "Json File(*.json)|*.json";
            dig.InitialDirectory = Environment.CurrentDirectory;
            if (dig.ShowDialog() == true)
            {
                CharacterDetails Save1 = new CharacterDetails(); // CharacterDetails is class with all address
                Save1 = CharacterDetails;
                string details = JsonConvert.SerializeObject(Save1, Formatting.Indented);
                File.WriteAllText(dig.FileName, details);
                CurrentlySaving = false;
            }
            else CurrentlySaving = false;
        }
        private void Load_Click(object sender, RoutedEventArgs e)
        {
            var c = new LoadWindow();
            c.Owner = this;
            c.ShowDialog();
            if (c.Choice == null) return;
            if (c.Choice == "All") dqwewqw();
            if (c.Choice == "App") Appereanco();
            if (c.Choice == "Xuip") Equipo();
        }

        private void dqwewqw()
        {
            OpenFileDialog dig = new OpenFileDialog();
            dig.Filter = "Json File(*.json)|*.json";
            dig.DefaultExt = ".json";
            if (dig.ShowDialog() == true)
            {
                CharacterDetails load1 = JsonConvert.DeserializeObject<CharacterDetails>(File.ReadAllText(dig.FileName));
                Load.IsEnabled = false;
                {
                    if (CharacterDetails.LimbalEyes.freeze == true) { CharacterDetails.LimbalEyes.freeze = false; CharacterDetails.LimbalEyes.freezetest = true; }
                    if (CharacterDetails.MuscleTone.freeze == true) { CharacterDetails.MuscleTone.freeze = false; CharacterDetails.MuscleTone.freezetest = true; }
                    if (CharacterDetails.TailSize.freeze == true) { CharacterDetails.TailSize.freeze = false; CharacterDetails.TailSize.freezetest = true; }
                    if (CharacterDetails.BustX.freeze == true) { CharacterDetails.BustX.freeze = false; CharacterDetails.BustX.freezetest = true; }
                    if (CharacterDetails.BustY.freeze == true) { CharacterDetails.BustY.freeze = false; CharacterDetails.BustY.freezetest = true; }
                    if (CharacterDetails.BustZ.freeze == true) { CharacterDetails.BustZ.freeze = false; CharacterDetails.BustZ.freezetest = true; }
                    if (CharacterDetails.LipsBrightness.freeze == true) { CharacterDetails.LipsBrightness.freeze = false; CharacterDetails.LipsBrightness.freezetest = true; }
                    if (CharacterDetails.SkinBlueGloss.freeze == true) { CharacterDetails.SkinBlueGloss.freeze = false; CharacterDetails.SkinBlueGloss.freezetest = true; }
                    if (CharacterDetails.SkinGreenGloss.freeze == true) { CharacterDetails.SkinGreenGloss.freeze = false; CharacterDetails.SkinGreenGloss.freezetest = true; }
                    if (CharacterDetails.SkinRedGloss.freeze == true) { CharacterDetails.SkinRedGloss.freeze = false; CharacterDetails.SkinRedGloss.freezetest = true; }
                    if (CharacterDetails.SkinBluePigment.freeze == true) { CharacterDetails.SkinBluePigment.freeze = false; CharacterDetails.SkinBluePigment.freezetest = true; }
                    if (CharacterDetails.SkinGreenPigment.freeze == true) { CharacterDetails.SkinGreenPigment.freeze = false; CharacterDetails.SkinGreenPigment.freezetest = true; }
                    if (CharacterDetails.SkinRedPigment.freeze == true) { CharacterDetails.SkinRedPigment.freeze = false; CharacterDetails.SkinRedPigment.freezetest = true; }
                    if (CharacterDetails.HighlightBluePigment.freeze == true) { CharacterDetails.HighlightBluePigment.freeze = false; CharacterDetails.HighlightBluePigment.freezetest = true; }
                    if (CharacterDetails.HighlightGreenPigment.freeze == true) { CharacterDetails.HighlightGreenPigment.freeze = false; CharacterDetails.HighlightGreenPigment.freezetest = true; }
                    if (CharacterDetails.HighlightRedPigment.freeze == true) { CharacterDetails.HighlightRedPigment.freeze = false; CharacterDetails.HighlightRedPigment.freezetest = true; }
                    if (CharacterDetails.HairGlowBlue.freeze == true) { CharacterDetails.HairGlowBlue.freeze = false; CharacterDetails.HairGlowBlue.freezetest = true; }
                    if (CharacterDetails.HairGlowGreen.freeze == true) { CharacterDetails.HairGlowGreen.freeze = false; CharacterDetails.HairGlowGreen.freezetest = true; }
                    if (CharacterDetails.HairGlowRed.freeze == true) { CharacterDetails.HairGlowRed.freeze = false; CharacterDetails.HairGlowRed.freezetest = true; }
                    if (CharacterDetails.HairGreenPigment.freeze == true) { CharacterDetails.HairGreenPigment.freeze = false; CharacterDetails.HairGreenPigment.freezetest = true; }
                    if (CharacterDetails.HairBluePigment.freeze == true) { CharacterDetails.HairBluePigment.freeze = false; CharacterDetails.HairBluePigment.freezetest = true; }
                    if (CharacterDetails.HairRedPigment.freeze == true) { CharacterDetails.HairRedPigment.freeze = false; CharacterDetails.HairRedPigment.freezetest = true; }
                    if (CharacterDetails.Height.freeze == true) { CharacterDetails.Height.freeze = false; CharacterDetails.Height.freezetest = true; }
                    if (CharacterDetails.WeaponGreen.freeze == true) { CharacterDetails.WeaponGreen.freeze = false; CharacterDetails.WeaponGreen.freezetest = true; }
                    if (CharacterDetails.WeaponBlue.freeze == true) { CharacterDetails.WeaponBlue.freeze = false; CharacterDetails.WeaponBlue.freezetest = true; }
                    if (CharacterDetails.WeaponRed.freeze == true) { CharacterDetails.WeaponRed.freeze = false; CharacterDetails.WeaponRed.freezetest = true; }
                    if (CharacterDetails.WeaponZ.freeze == true) { CharacterDetails.WeaponZ.freeze = false; CharacterDetails.WeaponZ.freezetest = true; }
                    if (CharacterDetails.WeaponY.freeze == true) { CharacterDetails.WeaponY.freeze = false; CharacterDetails.WeaponY.freezetest = true; }
                    if (CharacterDetails.WeaponX.freeze == true) { CharacterDetails.WeaponX.freeze = false; CharacterDetails.WeaponX.freezetest = true; }
                    if (CharacterDetails.OffhandZ.freeze == true) { CharacterDetails.OffhandZ.freeze = false; CharacterDetails.OffhandZ.freezetest = true; }
                    if (CharacterDetails.OffhandY.freeze == true) { CharacterDetails.OffhandY.freeze = false; CharacterDetails.OffhandY.freezetest = true; }
                    if (CharacterDetails.OffhandX.freeze == true) { CharacterDetails.OffhandX.freeze = false; CharacterDetails.OffhandX.freezetest = true; }
                    if (CharacterDetails.OffhandRed.freeze == true) { CharacterDetails.OffhandRed.freeze = false; CharacterDetails.OffhandRed.freezetest = true; }
                    if (CharacterDetails.OffhandBlue.freeze == true) { CharacterDetails.OffhandBlue.freeze = false; CharacterDetails.OffhandBlue.freezetest = true; }
                    if (CharacterDetails.OffhandGreen.freeze == true) { CharacterDetails.OffhandGreen.freeze = false; CharacterDetails.OffhandGreen.freezetest = true; }
                    if (CharacterDetails.RightEyeBlue.freeze == true) { CharacterDetails.RightEyeBlue.freeze = false; CharacterDetails.RightEyeBlue.freezetest = true; }
                    if (CharacterDetails.RightEyeGreen.freeze == true) { CharacterDetails.RightEyeGreen.freeze = false; CharacterDetails.RightEyeGreen.freezetest = true; }
                    if (CharacterDetails.RightEyeRed.freeze == true) { CharacterDetails.RightEyeRed.freeze = false; CharacterDetails.RightEyeRed.freezetest = true; }
                    if (CharacterDetails.LeftEyeBlue.freeze == true) { CharacterDetails.LeftEyeBlue.freeze = false; CharacterDetails.LeftEyeBlue.freezetest = true; }
                    if (CharacterDetails.LeftEyeGreen.freeze == true) { CharacterDetails.LeftEyeGreen.freeze = false; CharacterDetails.LeftEyeGreen.freezetest = true; }
                    if (CharacterDetails.LeftEyeRed.freeze == true) { CharacterDetails.LeftEyeRed.freeze = false; CharacterDetails.LeftEyeRed.freezetest = true; }
                    if (CharacterDetails.LipsB.freeze == true) { CharacterDetails.LipsB.freeze = false; CharacterDetails.LipsB.freezetest = true; }
                    if (CharacterDetails.LipsG.freeze == true) { CharacterDetails.LipsG.freeze = false; CharacterDetails.LipsG.freezetest = true; }
                    if (CharacterDetails.LipsR.freeze == true) { CharacterDetails.LipsR.freeze = false; CharacterDetails.LipsR.freezetest = true; }
                    if (CharacterDetails.LimbalB.freeze == true) { CharacterDetails.LimbalB.freeze = false; CharacterDetails.LimbalB.freezetest = true; }
                    if (CharacterDetails.LimbalG.freeze == true) { CharacterDetails.LimbalG.freeze = false; CharacterDetails.LimbalG.freezetest = true; }
                    if (CharacterDetails.LimbalR.freeze == true) { CharacterDetails.LimbalR.freeze = false; CharacterDetails.LimbalR.freezetest = true; }
                }
                CharacterDetails.Highlights.freeze = true;
                CharacterDetails.Race.freeze = true;
                CharacterDetails.Clan.freeze = true;
                CharacterDetails.Gender.freeze = true;
                CharacterDetails.Head.freeze = true;
                CharacterDetails.TailType.freeze = true;
                CharacterDetails.Nose.freeze = true;
                CharacterDetails.LimbalEyes.freeze = true;
                CharacterDetails.Lips.freeze = true;
                CharacterDetails.BodyType.freeze = true;
                CharacterDetails.Voices.freeze = true;
                CharacterDetails.Hair.freeze = true;
                CharacterDetails.HairTone.freeze = true;
                CharacterDetails.HighlightTone.freeze = true;
                CharacterDetails.Jaw.freeze = true;
                CharacterDetails.RBust.freeze = true;
                CharacterDetails.RHeight.freeze = true;
                CharacterDetails.LipsTone.freeze = true;
                CharacterDetails.Skintone.freeze = true;
                CharacterDetails.FacialFeatures.freeze = true;
                CharacterDetails.TailorMuscle.freeze = true;
                CharacterDetails.Eye.freeze = true;
                CharacterDetails.RightEye.freeze = true;
                CharacterDetails.EyeBrowType.freeze = true;
                CharacterDetails.LeftEye.freeze = true;
                CharacterDetails.Offhand.freeze = true;
                CharacterDetails.FacePaint.freeze = true;
                CharacterDetails.FacePaintColor.freeze = true;
                CharacterDetails.Job.freeze = true;
                CharacterDetails.HeadPiece.freeze = true;
                CharacterDetails.Chest.freeze = true;
                CharacterDetails.Arms.freeze = true;
                CharacterDetails.Legs.freeze = true;
                CharacterDetails.Feet.freeze = true;
                CharacterDetails.Ear.freeze = true;
                CharacterDetails.Neck.freeze = true;
                CharacterDetails.Wrist.freeze = true;
                CharacterDetails.RFinger.freeze = true;
                CharacterDetails.LFinger.freeze = true;
                Task.Delay(450).Wait();
                if (load1.Height.value != 0.000)
                {
                    CharacterDetails.Height.value = load1.Height.value;
                    MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Height), "float", load1.Height.value.ToString());
                }
                CharacterDetails.MuscleTone.value = load1.MuscleTone.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.MuscleTone), "float", load1.MuscleTone.value.ToString());
                CharacterDetails.TailSize.value = load1.TailSize.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.TailSize), "float", load1.TailSize.value.ToString());
                CharacterDetails.BustX.value = load1.BustX.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bust.Base, Settings.Instance.Character.Body.Bust.X), "float", load1.BustX.value.ToString());
                CharacterDetails.BustY.value = load1.BustY.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bust.Base, Settings.Instance.Character.Body.Bust.Y), "float", load1.BustY.value.ToString());
                CharacterDetails.BustZ.value = load1.BustZ.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bust.Base, Settings.Instance.Character.Body.Bust.Z), "float", load1.BustZ.value.ToString());
                CharacterDetails.HairRedPigment.value = load1.HairRedPigment.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HairRedPigment), "float", load1.HairRedPigment.value.ToString());
                CharacterDetails.HairBluePigment.value = load1.HairBluePigment.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HairBluePigment), "float", load1.HairBluePigment.value.ToString());
                CharacterDetails.HairGreenPigment.value = load1.HairGreenPigment.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HairGreenPigment), "float", load1.HairGreenPigment.value.ToString());
                CharacterDetails.HairGlowRed.value = load1.HairGlowRed.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HairGlowRed), "float", load1.HairGlowRed.value.ToString());
                CharacterDetails.HairGlowGreen.value = load1.HairGlowGreen.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HairGlowGreen), "float", load1.HairGlowGreen.value.ToString());
                CharacterDetails.HairGlowBlue.value = load1.HairGlowBlue.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HairGlowBlue), "float", load1.HairGlowBlue.value.ToString());
                CharacterDetails.HighlightRedPigment.value = load1.HighlightRedPigment.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HighlightRedPigment), "float", load1.HighlightRedPigment.value.ToString());
                CharacterDetails.HighlightGreenPigment.value = load1.HighlightGreenPigment.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HighlightGreenPigment), "float", load1.HighlightGreenPigment.value.ToString());
                CharacterDetails.HighlightBluePigment.value = load1.HighlightBluePigment.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HighlightBluePigment), "float", load1.HighlightBluePigment.value.ToString());
                CharacterDetails.LimbalEyes.value = load1.LimbalEyes.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LimbalEyes), load1.LimbalEyes.GetBytes());
                CharacterDetails.SkinRedPigment.value = load1.SkinRedPigment.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.SkinRedPigment), "float", load1.SkinRedPigment.value.ToString());
                CharacterDetails.SkinGreenPigment.value = load1.SkinGreenPigment.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.SkinGreenPigment), "float", load1.SkinGreenPigment.value.ToString());
                CharacterDetails.SkinBluePigment.value = load1.SkinBluePigment.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.SkinBluePigment), "float", load1.SkinBluePigment.value.ToString());
                CharacterDetails.SkinRedGloss.value = load1.SkinRedGloss.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.SkinRedGloss), "float", load1.SkinRedGloss.value.ToString());
                CharacterDetails.SkinGreenGloss.value = load1.SkinGreenGloss.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.SkinGreenGloss), "float", load1.SkinGreenGloss.value.ToString());
                CharacterDetails.SkinBlueGloss.value = load1.SkinBlueGloss.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.SkinBlueGloss), "float", load1.SkinBlueGloss.value.ToString());
                CharacterDetails.LipsBrightness.value = load1.LipsBrightness.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LipsBrightness), "float", load1.LipsBrightness.value.ToString());
                CharacterDetails.LipsR.value = load1.LipsR.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LipsR), "float", load1.LipsR.value.ToString());
                CharacterDetails.LipsG.value = load1.LipsG.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LipsG), "float", load1.LipsG.value.ToString());
                CharacterDetails.LipsB.value = load1.LipsB.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LipsB), "float", load1.LipsB.value.ToString());
                CharacterDetails.LimbalR.value = load1.LimbalR.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LimbalR), "float", load1.LimbalR.value.ToString());
                CharacterDetails.LimbalG.value = load1.LimbalG.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LimbalG), "float", load1.LimbalG.value.ToString());
                CharacterDetails.LimbalB.value = load1.LimbalB.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LimbalB), "float", load1.LimbalB.value.ToString());
                CharacterDetails.LeftEyeRed.value = load1.LeftEyeRed.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LeftEyeRed), "float", load1.LeftEyeRed.value.ToString());
                CharacterDetails.LeftEyeGreen.value = load1.LeftEyeGreen.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LeftEyeGreen), "float", load1.LeftEyeGreen.value.ToString());
                CharacterDetails.LeftEyeBlue.value = load1.LeftEyeBlue.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LeftEyeBlue), "float", load1.LeftEyeBlue.value.ToString());
                CharacterDetails.RightEyeRed.value = load1.RightEyeRed.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.RightEyeRed), "float", load1.RightEyeRed.value.ToString());
                CharacterDetails.RightEyeGreen.value = load1.RightEyeGreen.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.RightEyeGreen), "float", load1.RightEyeGreen.value.ToString());
                CharacterDetails.RightEyeBlue.value = load1.RightEyeBlue.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.RightEyeBlue), "float", load1.RightEyeBlue.value.ToString());
                CharacterDetails.WeaponX.value = load1.WeaponX.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.WeaponX), "float", load1.WeaponX.value.ToString());
                CharacterDetails.WeaponY.value = load1.WeaponY.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.WeaponY), "float", load1.WeaponY.value.ToString());
                CharacterDetails.WeaponZ.value = load1.WeaponZ.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.WeaponZ), "float", load1.WeaponZ.value.ToString());
                CharacterDetails.WeaponRed.value = load1.WeaponRed.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.WeaponRed), "float", load1.WeaponRed.value.ToString());
                CharacterDetails.WeaponBlue.value = load1.WeaponBlue.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.WeaponBlue), "float", load1.WeaponBlue.value.ToString());
                CharacterDetails.WeaponGreen.value = load1.WeaponGreen.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.WeaponGreen), "float", load1.WeaponGreen.value.ToString());
                CharacterDetails.OffhandBlue.value = load1.OffhandBlue.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.OffhandBlue), "float", load1.OffhandBlue.value.ToString());
                CharacterDetails.OffhandGreen.value = load1.OffhandGreen.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.OffhandGreen), "float", load1.OffhandGreen.value.ToString());
                CharacterDetails.OffhandRed.value = load1.OffhandRed.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.OffhandRed), "float", load1.OffhandRed.value.ToString());
                CharacterDetails.OffhandX.value = load1.OffhandX.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.OffhandX), "float", load1.OffhandX.value.ToString());
                CharacterDetails.OffhandY.value = load1.OffhandY.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.OffhandY), "float", load1.OffhandY.value.ToString());
                CharacterDetails.OffhandZ.value = load1.OffhandZ.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.OffhandZ), "float", load1.OffhandZ.value.ToString());
                CharacterDetails.Jaw.value = load1.Jaw.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Jaw), load1.Jaw.GetBytes());
                CharacterDetails.RHeight.value = load1.RHeight.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.RHeight), load1.RHeight.GetBytes());
                CharacterDetails.EyeBrowType.value = load1.EyeBrowType.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.EyeBrowType), load1.EyeBrowType.GetBytes());
                CharacterDetails.RBust.value = load1.RBust.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.RBust), load1.RBust.GetBytes());
                CharacterDetails.Ear.value = load1.Ear.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Ear), load1.Ear.GetBytes());
                CharacterDetails.EarVa.value = load1.EarVa.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.EarVa), load1.EarVa.GetBytes());
                CharacterDetails.Neck.value = load1.Neck.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Neck), load1.Neck.GetBytes());
                CharacterDetails.NeckVa.value = load1.NeckVa.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.NeckVa), load1.NeckVa.GetBytes());
                CharacterDetails.Wrist.value = load1.Wrist.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Wrist), load1.Wrist.GetBytes());
                CharacterDetails.WristVa.value = load1.WristVa.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.WristVa), load1.WristVa.GetBytes());
                CharacterDetails.RFinger.value = load1.RFinger.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.RFinger), load1.RFinger.GetBytes());
                CharacterDetails.RFingerVa.value = load1.RFingerVa.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.RFingerVa), load1.RFingerVa.GetBytes());
                CharacterDetails.LFinger.value = load1.LFinger.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LFinger), load1.LFinger.GetBytes());
                CharacterDetails.LFingerVa.value = load1.LFingerVa.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LFingerVa), load1.LFingerVa.GetBytes());
                CharacterDetails.Job.value = load1.Job.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Job), load1.Job.GetBytes());
                CharacterDetails.WeaponBase.value = load1.WeaponBase.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.WeaponBase), load1.WeaponBase.GetBytes());
                CharacterDetails.WeaponV.value = load1.WeaponV.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.WeaponV), load1.WeaponV.GetBytes());
                CharacterDetails.WeaponDye.value = load1.WeaponDye.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.WeaponDye), load1.WeaponDye.GetBytes());
                CharacterDetails.HeadPiece.value = load1.HeadPiece.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HeadPiece), load1.HeadPiece.GetBytes());
                CharacterDetails.HeadV.value = load1.HeadV.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HeadV), load1.HeadV.GetBytes());
                CharacterDetails.HeadDye.value = load1.HeadDye.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HeadDye), load1.HeadDye.GetBytes());
                CharacterDetails.Chest.value = load1.Chest.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Chest), load1.Chest.GetBytes());
                CharacterDetails.ChestV.value = load1.ChestV.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.ChestV), load1.ChestV.GetBytes());
                CharacterDetails.ChestDye.value = load1.ChestDye.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.ChestDye), load1.ChestDye.GetBytes());
                CharacterDetails.Arms.value = load1.Arms.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Arms), load1.Arms.GetBytes());
                CharacterDetails.ArmsV.value = load1.ArmsV.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.ArmsV), load1.ArmsV.GetBytes());
                CharacterDetails.ArmsDye.value = load1.ArmsDye.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.ArmsDye), load1.ArmsDye.GetBytes());
                CharacterDetails.Legs.value = load1.Legs.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Legs), load1.Legs.GetBytes());
                CharacterDetails.LegsV.value = load1.LegsV.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LegsV), load1.LegsV.GetBytes());
                CharacterDetails.LegsDye.value = load1.LegsDye.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LegsDye), load1.LegsDye.GetBytes());
                CharacterDetails.Feet.value = load1.Feet.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Feet), load1.Feet.GetBytes());
                CharacterDetails.FeetVa.value = load1.FeetVa.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.FeetVa), load1.FeetVa.GetBytes());
                CharacterDetails.FeetDye.value = load1.FeetDye.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.FeetDye), load1.FeetDye.GetBytes());
                CharacterDetails.Race.value = load1.Race.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Race), load1.Race.GetBytes());
                CharacterDetails.TailorMuscle.value = load1.TailorMuscle.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.TailorMuscle), load1.TailorMuscle.GetBytes());
                CharacterDetails.Clan.value = load1.Clan.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Clan), load1.Clan.GetBytes());
                CharacterDetails.Gender.value = load1.Gender.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Gender), load1.Gender.GetBytes());
                CharacterDetails.Head.value = load1.Head.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Head), load1.Head.GetBytes());
                CharacterDetails.TailType.value = load1.TailType.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.TailType), load1.TailType.GetBytes());
                CharacterDetails.Nose.value = load1.Nose.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Nose), load1.Nose.GetBytes());
                CharacterDetails.Lips.value = load1.Lips.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Lips), load1.Lips.GetBytes());
                CharacterDetails.LipsTone.value = load1.LipsTone.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LipsTone), load1.LipsTone.GetBytes());
                CharacterDetails.Voices.value = load1.Voices.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Voices), load1.Voices.GetBytes());
                CharacterDetails.Hair.value = load1.Hair.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Hair), load1.Hair.GetBytes());
                CharacterDetails.HairTone.value = load1.HairTone.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HairTone), load1.HairTone.GetBytes());
                CharacterDetails.Highlights.value = load1.Highlights.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Highlights), load1.Highlights.GetBytes());
                CharacterDetails.HighlightTone.value = load1.HighlightTone.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HighlightTone), load1.HighlightTone.GetBytes());
                CharacterDetails.Skintone.value = load1.Skintone.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Skintone), load1.Skintone.GetBytes());
                CharacterDetails.FacialFeatures.value = load1.FacialFeatures.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.FacialFeatures), load1.FacialFeatures.GetBytes());
                CharacterDetails.Eye.value = load1.Eye.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Eye), load1.Eye.GetBytes());
                CharacterDetails.RightEye.value = load1.RightEye.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.RightEye), load1.RightEye.GetBytes());
                CharacterDetails.LeftEye.value = load1.LeftEye.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LeftEye), load1.LeftEye.GetBytes());
                CharacterDetails.FacePaint.value = load1.FacePaint.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.FacePaint), load1.FacePaint.GetBytes());
                CharacterDetails.FacePaintColor.value = load1.FacePaintColor.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.FacePaintColor), load1.FacePaintColor.GetBytes());
                CharacterDetails.Offhand.value = load1.Offhand.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Offhand), load1.Offhand.GetBytes());
                CharacterDetails.OffhandBase.value = load1.OffhandBase.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.OffhandBase), load1.OffhandBase.GetBytes());
                CharacterDetails.OffhandV.value = load1.OffhandV.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.OffhandV), load1.OffhandV.GetBytes());
                CharacterDetails.OffhandDye.value = load1.OffhandDye.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.OffhandV), load1.OffhandDye.GetBytes());
                byte? NullableCheck = load1.BodyType.value;
                if (NullableCheck != null)
                {
                    CharacterDetails.BodyType.value = load1.BodyType.value;
                    MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.BodyType), load1.BodyType.GetBytes());
                }
                else
                {
                    CharacterDetails.BodyType.value = 1;
                    MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.BodyType), CharacterDetails.BodyType.GetBytes());
                }
                Task.Delay(400).Wait();
                {
                    if (CharacterDetails.LimbalEyes.freezetest == true) { CharacterDetails.LimbalEyes.freeze = false; CharacterDetails.LimbalEyes.freezetest = false; }
                    if (CharacterDetails.Highlights.freezetest == true) { CharacterDetails.Highlights.freeze = false; CharacterDetails.Highlights.freezetest = false; }
                    if (CharacterDetails.MuscleTone.freezetest == true) { CharacterDetails.MuscleTone.freeze = true; CharacterDetails.MuscleTone.freezetest = false; }
                    if (CharacterDetails.TailSize.freezetest == true) { CharacterDetails.TailSize.freeze = true; CharacterDetails.TailSize.freezetest = false; }
                    if (CharacterDetails.BustX.freezetest == true) { CharacterDetails.BustX.freeze = true; CharacterDetails.BustX.freezetest = false; }
                    if (CharacterDetails.BustY.freezetest == true) { CharacterDetails.BustY.freeze = true; CharacterDetails.BustY.freezetest = false; }
                    if (CharacterDetails.BustZ.freezetest == true) { CharacterDetails.BustZ.freeze = true; CharacterDetails.BustZ.freezetest = false; }
                    if (CharacterDetails.LipsBrightness.freezetest == true) { CharacterDetails.LipsBrightness.freeze = true; CharacterDetails.LipsBrightness.freezetest = false; }
                    if (CharacterDetails.SkinBlueGloss.freezetest == true) { CharacterDetails.SkinBlueGloss.freeze = true; CharacterDetails.SkinBlueGloss.freezetest = false; }
                    if (CharacterDetails.SkinGreenGloss.freezetest == true) { CharacterDetails.SkinGreenGloss.freeze = true; CharacterDetails.SkinGreenGloss.freezetest = false; }
                    if (CharacterDetails.SkinRedGloss.freezetest == true) { CharacterDetails.SkinRedGloss.freeze = true; CharacterDetails.SkinRedGloss.freezetest = false; }
                    if (CharacterDetails.SkinBluePigment.freezetest == true) { CharacterDetails.SkinBluePigment.freeze = true; CharacterDetails.SkinBluePigment.freezetest = false; }
                    if (CharacterDetails.SkinGreenPigment.freezetest == true) { CharacterDetails.SkinGreenPigment.freeze = true; CharacterDetails.SkinGreenPigment.freezetest = false; }
                    if (CharacterDetails.SkinRedPigment.freezetest == true) { CharacterDetails.SkinRedPigment.freeze = true; CharacterDetails.SkinRedPigment.freezetest = false; }
                    if (CharacterDetails.HighlightBluePigment.freezetest == true) { CharacterDetails.HighlightBluePigment.freeze = true; CharacterDetails.HighlightBluePigment.freezetest = false; }
                    if (CharacterDetails.HighlightGreenPigment.freezetest == true) { CharacterDetails.HighlightGreenPigment.freeze = true; CharacterDetails.HighlightGreenPigment.freezetest = false; }
                    if (CharacterDetails.HighlightRedPigment.freezetest == true) { CharacterDetails.HighlightRedPigment.freeze = true; CharacterDetails.HighlightRedPigment.freezetest = false; }
                    if (CharacterDetails.HairGlowBlue.freezetest == true) { CharacterDetails.HairGlowBlue.freeze = true; CharacterDetails.HairGlowBlue.freezetest = false; }
                    if (CharacterDetails.HairGlowGreen.freezetest == true) { CharacterDetails.HairGlowGreen.freeze = true; CharacterDetails.HairGlowGreen.freezetest = false; }
                    if (CharacterDetails.HairGlowRed.freezetest == true) { CharacterDetails.HairGlowRed.freeze = true; CharacterDetails.HairGlowRed.freezetest = false; }
                    if (CharacterDetails.HairGreenPigment.freezetest == true) { CharacterDetails.HairGreenPigment.freeze = true; CharacterDetails.HairGreenPigment.freezetest = false; }
                    if (CharacterDetails.HairBluePigment.freezetest == true) { CharacterDetails.HairBluePigment.freeze = true; CharacterDetails.HairBluePigment.freezetest = false; }
                    if (CharacterDetails.HairRedPigment.freezetest == true) { CharacterDetails.HairRedPigment.freeze = true; CharacterDetails.HairRedPigment.freezetest = false; }
                    if (CharacterDetails.Height.freezetest == true) { CharacterDetails.Height.freeze = true; CharacterDetails.Height.freezetest = false; }
                    if (CharacterDetails.WeaponGreen.freezetest == true) { CharacterDetails.WeaponGreen.freeze = true; CharacterDetails.WeaponGreen.freezetest = false; }
                    if (CharacterDetails.WeaponBlue.freezetest == true) { CharacterDetails.WeaponBlue.freeze = true; CharacterDetails.WeaponBlue.freezetest = false; }
                    if (CharacterDetails.WeaponRed.freezetest == true) { CharacterDetails.WeaponRed.freeze = true; CharacterDetails.WeaponRed.freezetest = false; }
                    if (CharacterDetails.WeaponZ.freezetest == true) { CharacterDetails.WeaponZ.freeze = true; CharacterDetails.WeaponZ.freezetest = false; }
                    if (CharacterDetails.WeaponY.freezetest == true) { CharacterDetails.WeaponY.freeze = true; CharacterDetails.WeaponY.freezetest = false; }
                    if (CharacterDetails.WeaponX.freezetest == true) { CharacterDetails.WeaponX.freeze = true; CharacterDetails.WeaponX.freezetest = false; }
                    if (CharacterDetails.OffhandZ.freezetest == true) { CharacterDetails.OffhandZ.freeze = true; CharacterDetails.OffhandZ.freezetest = false; }
                    if (CharacterDetails.OffhandY.freezetest == true) { CharacterDetails.OffhandY.freeze = true; CharacterDetails.OffhandY.freezetest = false; }
                    if (CharacterDetails.OffhandX.freezetest == true) { CharacterDetails.OffhandX.freeze = true; CharacterDetails.OffhandX.freezetest = false; }
                    if (CharacterDetails.OffhandRed.freezetest == true) { CharacterDetails.OffhandRed.freeze = true; CharacterDetails.OffhandRed.freezetest = false; }
                    if (CharacterDetails.OffhandBlue.freezetest == true) { CharacterDetails.OffhandBlue.freeze = true; CharacterDetails.OffhandBlue.freezetest = false; }
                    if (CharacterDetails.OffhandGreen.freezetest == true) { CharacterDetails.OffhandGreen.freeze = true; CharacterDetails.OffhandGreen.freezetest = false; }
                    if (CharacterDetails.RightEyeBlue.freezetest == true) { CharacterDetails.RightEyeBlue.freeze = true; CharacterDetails.RightEyeBlue.freezetest = false; }
                    if (CharacterDetails.RightEyeGreen.freezetest == true) { CharacterDetails.RightEyeGreen.freeze = true; CharacterDetails.RightEyeGreen.freezetest = false; }
                    if (CharacterDetails.RightEyeRed.freezetest == true) { CharacterDetails.RightEyeRed.freeze = true; CharacterDetails.RightEyeRed.freezetest = false; }
                    if (CharacterDetails.LeftEyeBlue.freezetest == true) { CharacterDetails.LeftEyeBlue.freeze = true; CharacterDetails.LeftEyeBlue.freezetest = false; }
                    if (CharacterDetails.LeftEyeGreen.freezetest == true) { CharacterDetails.LeftEyeGreen.freeze = true; CharacterDetails.LeftEyeGreen.freezetest = false; }
                    if (CharacterDetails.LeftEyeRed.freezetest == true) { CharacterDetails.LeftEyeRed.freeze = true; CharacterDetails.LeftEyeRed.freezetest = false; }
                    if (CharacterDetails.LipsB.freezetest == true) { CharacterDetails.LipsB.freeze = true; CharacterDetails.LipsB.freezetest = false; }
                    if (CharacterDetails.LipsG.freezetest == true) { CharacterDetails.LipsG.freeze = true; CharacterDetails.LipsG.freezetest = false; }
                    if (CharacterDetails.LipsR.freezetest == true) { CharacterDetails.LipsR.freeze = true; CharacterDetails.LipsR.freezetest = false; }
                    if (CharacterDetails.LimbalR.freezetest == true) { CharacterDetails.LimbalR.freeze = true; CharacterDetails.LimbalR.freezetest = false; }
                    if (CharacterDetails.LimbalB.freezetest == true) { CharacterDetails.LimbalB.freeze = true; CharacterDetails.LimbalB.freezetest = false; }
                    if (CharacterDetails.LimbalG.freezetest == true) { CharacterDetails.LimbalG.freeze = true; CharacterDetails.LimbalG.freezetest = false; }
                }
                Load.IsEnabled = true;
            }
        }
        private void Equipo()
        {
            OpenFileDialog dig = new OpenFileDialog();
            dig.Filter = "Json File(*.json)|*.json";
            dig.DefaultExt = ".json";
            if (dig.ShowDialog() == true)
            {
                CharacterDetails load1 = JsonConvert.DeserializeObject<CharacterDetails>(File.ReadAllText(dig.FileName));
                Load.IsEnabled = false;
                {
                    if (CharacterDetails.WeaponGreen.freeze == true) { CharacterDetails.WeaponGreen.freeze = false; CharacterDetails.WeaponGreen.freezetest = true; }
                    if (CharacterDetails.WeaponBlue.freeze == true) { CharacterDetails.WeaponBlue.freeze = false; CharacterDetails.WeaponBlue.freezetest = true; }
                    if (CharacterDetails.WeaponRed.freeze == true) { CharacterDetails.WeaponRed.freeze = false; CharacterDetails.WeaponRed.freezetest = true; }
                    if (CharacterDetails.WeaponZ.freeze == true) { CharacterDetails.WeaponZ.freeze = false; CharacterDetails.WeaponZ.freezetest = true; }
                    if (CharacterDetails.WeaponY.freeze == true) { CharacterDetails.WeaponY.freeze = false; CharacterDetails.WeaponY.freezetest = true; }
                    if (CharacterDetails.WeaponX.freeze == true) { CharacterDetails.WeaponX.freeze = false; CharacterDetails.WeaponX.freezetest = true; }
                    if (CharacterDetails.OffhandZ.freeze == true) { CharacterDetails.OffhandZ.freeze = false; CharacterDetails.OffhandZ.freezetest = true; }
                    if (CharacterDetails.OffhandY.freeze == true) { CharacterDetails.OffhandY.freeze = false; CharacterDetails.OffhandY.freezetest = true; }
                    if (CharacterDetails.OffhandX.freeze == true) { CharacterDetails.OffhandX.freeze = false; CharacterDetails.OffhandX.freezetest = true; }
                    if (CharacterDetails.OffhandRed.freeze == true) { CharacterDetails.OffhandRed.freeze = false; CharacterDetails.OffhandRed.freezetest = true; }
                    if (CharacterDetails.OffhandBlue.freeze == true) { CharacterDetails.OffhandBlue.freeze = false; CharacterDetails.OffhandBlue.freezetest = true; }
                    if (CharacterDetails.OffhandGreen.freeze == true) { CharacterDetails.OffhandGreen.freeze = false; CharacterDetails.OffhandGreen.freezetest = true; }
                }
                CharacterDetails.Offhand.freeze = true;
                CharacterDetails.Job.freeze = true;
                CharacterDetails.HeadPiece.freeze = true;
                CharacterDetails.Chest.freeze = true;
                CharacterDetails.Arms.freeze = true;
                CharacterDetails.Legs.freeze = true;
                CharacterDetails.Feet.freeze = true;
                CharacterDetails.Ear.freeze = true;
                CharacterDetails.Neck.freeze = true;
                CharacterDetails.Wrist.freeze = true;
                CharacterDetails.RFinger.freeze = true;
                CharacterDetails.LFinger.freeze = true;
                Task.Delay(450).Wait();
                CharacterDetails.WeaponX.value = load1.WeaponX.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.WeaponX), "float", load1.WeaponX.value.ToString());
                CharacterDetails.WeaponY.value = load1.WeaponY.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.WeaponY), "float", load1.WeaponY.value.ToString());
                CharacterDetails.WeaponZ.value = load1.WeaponZ.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.WeaponZ), "float", load1.WeaponZ.value.ToString());
                CharacterDetails.WeaponRed.value = load1.WeaponRed.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.WeaponRed), "float", load1.WeaponRed.value.ToString());
                CharacterDetails.WeaponBlue.value = load1.WeaponBlue.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.WeaponBlue), "float", load1.WeaponBlue.value.ToString());
                CharacterDetails.WeaponGreen.value = load1.WeaponGreen.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.WeaponGreen), "float", load1.WeaponGreen.value.ToString());
                CharacterDetails.OffhandBlue.value = load1.OffhandBlue.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.OffhandBlue), "float", load1.OffhandBlue.value.ToString());
                CharacterDetails.OffhandGreen.value = load1.OffhandGreen.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.OffhandGreen), "float", load1.OffhandGreen.value.ToString());
                CharacterDetails.OffhandRed.value = load1.OffhandRed.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.OffhandRed), "float", load1.OffhandRed.value.ToString());
                CharacterDetails.OffhandX.value = load1.OffhandX.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.OffhandX), "float", load1.OffhandX.value.ToString());
                CharacterDetails.OffhandY.value = load1.OffhandY.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.OffhandY), "float", load1.OffhandY.value.ToString());
                CharacterDetails.OffhandZ.value = load1.OffhandZ.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.OffhandZ), "float", load1.OffhandZ.value.ToString());
                CharacterDetails.Ear.value = load1.Ear.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Ear), load1.Ear.GetBytes());
                CharacterDetails.EarVa.value = load1.EarVa.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.EarVa), load1.EarVa.GetBytes());
                CharacterDetails.Neck.value = load1.Neck.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Neck), load1.Neck.GetBytes());
                CharacterDetails.NeckVa.value = load1.NeckVa.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.NeckVa), load1.NeckVa.GetBytes());
                CharacterDetails.Wrist.value = load1.Wrist.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Wrist), load1.Wrist.GetBytes());
                CharacterDetails.WristVa.value = load1.WristVa.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.WristVa), load1.WristVa.GetBytes());
                CharacterDetails.RFinger.value = load1.RFinger.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.RFinger), load1.RFinger.GetBytes());
                CharacterDetails.RFingerVa.value = load1.RFingerVa.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.RFingerVa), load1.RFingerVa.GetBytes());
                CharacterDetails.LFinger.value = load1.LFinger.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LFinger), load1.LFinger.GetBytes());
                CharacterDetails.LFingerVa.value = load1.LFingerVa.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LFingerVa), load1.LFingerVa.GetBytes());
                CharacterDetails.Job.value = load1.Job.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Job), load1.Job.GetBytes());
                CharacterDetails.WeaponBase.value = load1.WeaponBase.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.WeaponBase), load1.WeaponBase.GetBytes());
                CharacterDetails.WeaponV.value = load1.WeaponV.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.WeaponV), load1.WeaponV.GetBytes());
                CharacterDetails.WeaponDye.value = load1.WeaponDye.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.WeaponDye), load1.WeaponDye.GetBytes());
                CharacterDetails.HeadPiece.value = load1.HeadPiece.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HeadPiece), load1.HeadPiece.GetBytes());
                CharacterDetails.HeadV.value = load1.HeadV.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HeadV), load1.HeadV.GetBytes());
                CharacterDetails.HeadDye.value = load1.HeadDye.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HeadDye), load1.HeadDye.GetBytes());
                CharacterDetails.Chest.value = load1.Chest.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Chest), load1.Chest.GetBytes());
                CharacterDetails.ChestV.value = load1.ChestV.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.ChestV), load1.ChestV.GetBytes());
                CharacterDetails.ChestDye.value = load1.ChestDye.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.ChestDye), load1.ChestDye.GetBytes());
                CharacterDetails.Arms.value = load1.Arms.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Arms), load1.Arms.GetBytes());
                CharacterDetails.ArmsV.value = load1.ArmsV.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.ArmsV), load1.ArmsV.GetBytes());
                CharacterDetails.ArmsDye.value = load1.ArmsDye.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.ArmsDye), load1.ArmsDye.GetBytes());
                CharacterDetails.Legs.value = load1.Legs.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Legs), load1.Legs.GetBytes());
                CharacterDetails.LegsV.value = load1.LegsV.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LegsV), load1.LegsV.GetBytes());
                CharacterDetails.LegsDye.value = load1.LegsDye.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LegsDye), load1.LegsDye.GetBytes());
                CharacterDetails.Feet.value = load1.Feet.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Feet), load1.Feet.GetBytes());
                CharacterDetails.FeetVa.value = load1.FeetVa.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.FeetVa), load1.FeetVa.GetBytes());
                CharacterDetails.FeetDye.value = load1.FeetDye.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.FeetDye), load1.FeetDye.GetBytes());
                CharacterDetails.Offhand.value = load1.Offhand.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Offhand), load1.Offhand.GetBytes());
                CharacterDetails.OffhandBase.value = load1.OffhandBase.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.OffhandBase), load1.OffhandBase.GetBytes());
                CharacterDetails.OffhandV.value = load1.OffhandV.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.OffhandV), load1.OffhandV.GetBytes());
                CharacterDetails.OffhandDye.value = load1.OffhandDye.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.OffhandV), load1.OffhandDye.GetBytes());
                Task.Delay(400).Wait();
                {
                    if (CharacterDetails.WeaponGreen.freezetest == true) { CharacterDetails.WeaponGreen.freeze = true; CharacterDetails.WeaponGreen.freezetest = false; }
                    if (CharacterDetails.WeaponBlue.freezetest == true) { CharacterDetails.WeaponBlue.freeze = true; CharacterDetails.WeaponBlue.freezetest = false; }
                    if (CharacterDetails.WeaponRed.freezetest == true) { CharacterDetails.WeaponRed.freeze = true; CharacterDetails.WeaponRed.freezetest = false; }
                    if (CharacterDetails.WeaponZ.freezetest == true) { CharacterDetails.WeaponZ.freeze = true; CharacterDetails.WeaponZ.freezetest = false; }
                    if (CharacterDetails.WeaponY.freezetest == true) { CharacterDetails.WeaponY.freeze = true; CharacterDetails.WeaponY.freezetest = false; }
                    if (CharacterDetails.WeaponX.freezetest == true) { CharacterDetails.WeaponX.freeze = true; CharacterDetails.WeaponX.freezetest = false; }
                    if (CharacterDetails.OffhandZ.freezetest == true) { CharacterDetails.OffhandZ.freeze = true; CharacterDetails.OffhandZ.freezetest = false; }
                    if (CharacterDetails.OffhandY.freezetest == true) { CharacterDetails.OffhandY.freeze = true; CharacterDetails.OffhandY.freezetest = false; }
                    if (CharacterDetails.OffhandX.freezetest == true) { CharacterDetails.OffhandX.freeze = true; CharacterDetails.OffhandX.freezetest = false; }
                    if (CharacterDetails.OffhandRed.freezetest == true) { CharacterDetails.OffhandRed.freeze = true; CharacterDetails.OffhandRed.freezetest = false; }
                    if (CharacterDetails.OffhandBlue.freezetest == true) { CharacterDetails.OffhandBlue.freeze = true; CharacterDetails.OffhandBlue.freezetest = false; }
                    if (CharacterDetails.OffhandGreen.freezetest == true) { CharacterDetails.OffhandGreen.freeze = true; CharacterDetails.OffhandGreen.freezetest = false; }
                }
                Load.IsEnabled = true;
            }
        }
        private void Appereanco()
        {
            OpenFileDialog dig = new OpenFileDialog();
            dig.Filter = "Json File(*.json)|*.json";
            dig.DefaultExt = ".json";
            if (dig.ShowDialog() == true)
            {
                CharacterDetails load1 = JsonConvert.DeserializeObject<CharacterDetails>(File.ReadAllText(dig.FileName));
                Load.IsEnabled = false;
                {
                    if (CharacterDetails.LimbalEyes.freeze == true) { CharacterDetails.LimbalEyes.freeze = false; CharacterDetails.LimbalEyes.freezetest = true; }
                    if (CharacterDetails.MuscleTone.freeze == true) { CharacterDetails.MuscleTone.freeze = false; CharacterDetails.MuscleTone.freezetest = true; }
                    if (CharacterDetails.TailSize.freeze == true) { CharacterDetails.TailSize.freeze = false; CharacterDetails.TailSize.freezetest = true; }
                    if (CharacterDetails.BustX.freeze == true) { CharacterDetails.BustX.freeze = false; CharacterDetails.BustX.freezetest = true; }
                    if (CharacterDetails.BustY.freeze == true) { CharacterDetails.BustY.freeze = false; CharacterDetails.BustY.freezetest = true; }
                    if (CharacterDetails.BustZ.freeze == true) { CharacterDetails.BustZ.freeze = false; CharacterDetails.BustZ.freezetest = true; }
                    if (CharacterDetails.LipsBrightness.freeze == true) { CharacterDetails.LipsBrightness.freeze = false; CharacterDetails.LipsBrightness.freezetest = true; }
                    if (CharacterDetails.SkinBlueGloss.freeze == true) { CharacterDetails.SkinBlueGloss.freeze = false; CharacterDetails.SkinBlueGloss.freezetest = true; }
                    if (CharacterDetails.SkinGreenGloss.freeze == true) { CharacterDetails.SkinGreenGloss.freeze = false; CharacterDetails.SkinGreenGloss.freezetest = true; }
                    if (CharacterDetails.SkinRedGloss.freeze == true) { CharacterDetails.SkinRedGloss.freeze = false; CharacterDetails.SkinRedGloss.freezetest = true; }
                    if (CharacterDetails.SkinBluePigment.freeze == true) { CharacterDetails.SkinBluePigment.freeze = false; CharacterDetails.SkinBluePigment.freezetest = true; }
                    if (CharacterDetails.SkinGreenPigment.freeze == true) { CharacterDetails.SkinGreenPigment.freeze = false; CharacterDetails.SkinGreenPigment.freezetest = true; }
                    if (CharacterDetails.SkinRedPigment.freeze == true) { CharacterDetails.SkinRedPigment.freeze = false; CharacterDetails.SkinRedPigment.freezetest = true; }
                    if (CharacterDetails.HighlightBluePigment.freeze == true) { CharacterDetails.HighlightBluePigment.freeze = false; CharacterDetails.HighlightBluePigment.freezetest = true; }
                    if (CharacterDetails.HighlightGreenPigment.freeze == true) { CharacterDetails.HighlightGreenPigment.freeze = false; CharacterDetails.HighlightGreenPigment.freezetest = true; }
                    if (CharacterDetails.HighlightRedPigment.freeze == true) { CharacterDetails.HighlightRedPigment.freeze = false; CharacterDetails.HighlightRedPigment.freezetest = true; }
                    if (CharacterDetails.HairGlowBlue.freeze == true) { CharacterDetails.HairGlowBlue.freeze = false; CharacterDetails.HairGlowBlue.freezetest = true; }
                    if (CharacterDetails.HairGlowGreen.freeze == true) { CharacterDetails.HairGlowGreen.freeze = false; CharacterDetails.HairGlowGreen.freezetest = true; }
                    if (CharacterDetails.HairGlowRed.freeze == true) { CharacterDetails.HairGlowRed.freeze = false; CharacterDetails.HairGlowRed.freezetest = true; }
                    if (CharacterDetails.HairGreenPigment.freeze == true) { CharacterDetails.HairGreenPigment.freeze = false; CharacterDetails.HairGreenPigment.freezetest = true; }
                    if (CharacterDetails.HairBluePigment.freeze == true) { CharacterDetails.HairBluePigment.freeze = false; CharacterDetails.HairBluePigment.freezetest = true; }
                    if (CharacterDetails.HairRedPigment.freeze == true) { CharacterDetails.HairRedPigment.freeze = false; CharacterDetails.HairRedPigment.freezetest = true; }
                    if (CharacterDetails.Height.freeze == true) { CharacterDetails.Height.freeze = false; CharacterDetails.Height.freezetest = true; }
                    if (CharacterDetails.RightEyeBlue.freeze == true) { CharacterDetails.RightEyeBlue.freeze = false; CharacterDetails.RightEyeBlue.freezetest = true; }
                    if (CharacterDetails.RightEyeGreen.freeze == true) { CharacterDetails.RightEyeGreen.freeze = false; CharacterDetails.RightEyeGreen.freezetest = true; }
                    if (CharacterDetails.RightEyeRed.freeze == true) { CharacterDetails.RightEyeRed.freeze = false; CharacterDetails.RightEyeRed.freezetest = true; }
                    if (CharacterDetails.LeftEyeBlue.freeze == true) { CharacterDetails.LeftEyeBlue.freeze = false; CharacterDetails.LeftEyeBlue.freezetest = true; }
                    if (CharacterDetails.LeftEyeGreen.freeze == true) { CharacterDetails.LeftEyeGreen.freeze = false; CharacterDetails.LeftEyeGreen.freezetest = true; }
                    if (CharacterDetails.LeftEyeRed.freeze == true) { CharacterDetails.LeftEyeRed.freeze = false; CharacterDetails.LeftEyeRed.freezetest = true; }
                    if (CharacterDetails.LipsB.freeze == true) { CharacterDetails.LipsB.freeze = false; CharacterDetails.LipsB.freezetest = true; }
                    if (CharacterDetails.LipsG.freeze == true) { CharacterDetails.LipsG.freeze = false; CharacterDetails.LipsG.freezetest = true; }
                    if (CharacterDetails.LipsR.freeze == true) { CharacterDetails.LipsR.freeze = false; CharacterDetails.LipsR.freezetest = true; }
                    if (CharacterDetails.LimbalB.freeze == true) { CharacterDetails.LimbalB.freeze = false; CharacterDetails.LimbalB.freezetest = true; }
                    if (CharacterDetails.LimbalG.freeze == true) { CharacterDetails.LimbalG.freeze = false; CharacterDetails.LimbalG.freezetest = true; }
                    if (CharacterDetails.LimbalR.freeze == true) { CharacterDetails.LimbalR.freeze = false; CharacterDetails.LimbalR.freezetest = true; }
                }
                CharacterDetails.Race.freeze = true;
                CharacterDetails.Clan.freeze = true;
                CharacterDetails.Gender.freeze = true;
                CharacterDetails.Head.freeze = true;
                CharacterDetails.TailType.freeze = true;
                CharacterDetails.LimbalEyes.freeze = true;
                CharacterDetails.Nose.freeze = true;
                CharacterDetails.Lips.freeze = true;
                CharacterDetails.BodyType.freeze = true;
                CharacterDetails.Highlights.freeze = true;
                CharacterDetails.Voices.freeze = true;
                CharacterDetails.Hair.freeze = true;
                CharacterDetails.HairTone.freeze = true;
                CharacterDetails.HighlightTone.freeze = true;
                CharacterDetails.Jaw.freeze = true;
                CharacterDetails.RBust.freeze = true;
                CharacterDetails.RHeight.freeze = true;
                CharacterDetails.LipsTone.freeze = true;
                CharacterDetails.Skintone.freeze = true;
                CharacterDetails.FacialFeatures.freeze = true;
                CharacterDetails.TailorMuscle.freeze = true;
                CharacterDetails.Eye.freeze = true;
                CharacterDetails.RightEye.freeze = true;
                CharacterDetails.EyeBrowType.freeze = true;
                CharacterDetails.LeftEye.freeze = true;
                CharacterDetails.FacePaint.freeze = true;
                CharacterDetails.FacePaintColor.freeze = true;
                Task.Delay(450).Wait();
                if (load1.Height.value != 0.000)
                {
                    CharacterDetails.Height.value = load1.Height.value;
                    MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Height), "float", load1.Height.value.ToString());
                }
                CharacterDetails.MuscleTone.value = load1.MuscleTone.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.MuscleTone), "float", load1.MuscleTone.value.ToString());
                CharacterDetails.TailSize.value = load1.TailSize.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.TailSize), "float", load1.TailSize.value.ToString());
                CharacterDetails.BustX.value = load1.BustX.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bust.Base, Settings.Instance.Character.Body.Bust.X), "float", load1.BustX.value.ToString());
                CharacterDetails.BustY.value = load1.BustY.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bust.Base, Settings.Instance.Character.Body.Bust.Y), "float", load1.BustY.value.ToString());
                CharacterDetails.BustZ.value = load1.BustZ.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bust.Base, Settings.Instance.Character.Body.Bust.Z), "float", load1.BustZ.value.ToString());
                CharacterDetails.HairRedPigment.value = load1.HairRedPigment.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HairRedPigment), "float", load1.HairRedPigment.value.ToString());
                CharacterDetails.HairBluePigment.value = load1.HairBluePigment.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HairBluePigment), "float", load1.HairBluePigment.value.ToString());
                CharacterDetails.HairGreenPigment.value = load1.HairGreenPigment.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HairGreenPigment), "float", load1.HairGreenPigment.value.ToString());
                CharacterDetails.HairGlowRed.value = load1.HairGlowRed.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HairGlowRed), "float", load1.HairGlowRed.value.ToString());
                CharacterDetails.HairGlowGreen.value = load1.HairGlowGreen.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HairGlowGreen), "float", load1.HairGlowGreen.value.ToString());
                CharacterDetails.HairGlowBlue.value = load1.HairGlowBlue.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HairGlowBlue), "float", load1.HairGlowBlue.value.ToString());
                CharacterDetails.HighlightRedPigment.value = load1.HighlightRedPigment.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HighlightRedPigment), "float", load1.HighlightRedPigment.value.ToString());
                CharacterDetails.HighlightGreenPigment.value = load1.HighlightGreenPigment.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HighlightGreenPigment), "float", load1.HighlightGreenPigment.value.ToString());
                CharacterDetails.HighlightBluePigment.value = load1.HighlightBluePigment.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HighlightBluePigment), "float", load1.HighlightBluePigment.value.ToString());
                CharacterDetails.SkinRedPigment.value = load1.SkinRedPigment.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.SkinRedPigment), "float", load1.SkinRedPigment.value.ToString());
                CharacterDetails.SkinGreenPigment.value = load1.SkinGreenPigment.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.SkinGreenPigment), "float", load1.SkinGreenPigment.value.ToString());
                CharacterDetails.SkinBluePigment.value = load1.SkinBluePigment.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.SkinBluePigment), "float", load1.SkinBluePigment.value.ToString());
                CharacterDetails.SkinRedGloss.value = load1.SkinRedGloss.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.SkinRedGloss), "float", load1.SkinRedGloss.value.ToString());
                CharacterDetails.SkinGreenGloss.value = load1.SkinGreenGloss.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.SkinGreenGloss), "float", load1.SkinGreenGloss.value.ToString());
                CharacterDetails.SkinBlueGloss.value = load1.SkinBlueGloss.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.SkinBlueGloss), "float", load1.SkinBlueGloss.value.ToString());
                CharacterDetails.LipsBrightness.value = load1.LipsBrightness.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LipsBrightness), "float", load1.LipsBrightness.value.ToString());
                CharacterDetails.LipsR.value = load1.LipsR.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LipsR), "float", load1.LipsR.value.ToString());
                CharacterDetails.LipsG.value = load1.LipsG.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LipsG), "float", load1.LipsG.value.ToString());
                CharacterDetails.LipsB.value = load1.LipsB.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LipsB), "float", load1.LipsB.value.ToString());
                CharacterDetails.LimbalR.value = load1.LimbalR.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LimbalR), "float", load1.LimbalR.value.ToString());
                CharacterDetails.LimbalG.value = load1.LimbalG.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LimbalG), "float", load1.LimbalG.value.ToString());
                CharacterDetails.LimbalB.value = load1.LimbalB.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LimbalB), "float", load1.LimbalB.value.ToString());
                CharacterDetails.LeftEyeRed.value = load1.LeftEyeRed.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LeftEyeRed), "float", load1.LeftEyeRed.value.ToString());
                CharacterDetails.LeftEyeGreen.value = load1.LeftEyeGreen.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LeftEyeGreen), "float", load1.LeftEyeGreen.value.ToString());
                CharacterDetails.LeftEyeBlue.value = load1.LeftEyeBlue.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LeftEyeBlue), "float", load1.LeftEyeBlue.value.ToString());
                CharacterDetails.RightEyeRed.value = load1.RightEyeRed.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.RightEyeRed), "float", load1.RightEyeRed.value.ToString());
                CharacterDetails.RightEyeGreen.value = load1.RightEyeGreen.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.RightEyeGreen), "float", load1.RightEyeGreen.value.ToString());
                CharacterDetails.RightEyeBlue.value = load1.RightEyeBlue.value;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.RightEyeBlue), "float", load1.RightEyeBlue.value.ToString());
                CharacterDetails.Jaw.value = load1.Jaw.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Jaw), load1.Jaw.GetBytes());
                CharacterDetails.RHeight.value = load1.RHeight.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.RHeight), load1.RHeight.GetBytes());
                CharacterDetails.EyeBrowType.value = load1.EyeBrowType.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.EyeBrowType), load1.EyeBrowType.GetBytes());
                CharacterDetails.RBust.value = load1.RBust.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.RBust), load1.RBust.GetBytes());
                CharacterDetails.Race.value = load1.Race.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Race), load1.Race.GetBytes());
                CharacterDetails.LimbalEyes.value = load1.LimbalEyes.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LimbalEyes), load1.LimbalEyes.GetBytes());
                CharacterDetails.TailorMuscle.value = load1.TailorMuscle.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.TailorMuscle), load1.TailorMuscle.GetBytes());
                CharacterDetails.Clan.value = load1.Clan.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Clan), load1.Clan.GetBytes());
                CharacterDetails.Gender.value = load1.Gender.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Gender), load1.Gender.GetBytes());
                CharacterDetails.Head.value = load1.Head.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Head), load1.Head.GetBytes());
                CharacterDetails.TailType.value = load1.TailType.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.TailType), load1.TailType.GetBytes());
                CharacterDetails.Nose.value = load1.Nose.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Nose), load1.Nose.GetBytes());
                CharacterDetails.Lips.value = load1.Lips.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Lips), load1.Lips.GetBytes());
                CharacterDetails.LipsTone.value = load1.LipsTone.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LipsTone), load1.LipsTone.GetBytes());
                CharacterDetails.Voices.value = load1.Voices.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Voices), load1.Voices.GetBytes());
                CharacterDetails.Hair.value = load1.Hair.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Hair), load1.Hair.GetBytes());
                CharacterDetails.HairTone.value = load1.HairTone.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HairTone), load1.HairTone.GetBytes());
                CharacterDetails.Highlights.value = load1.Highlights.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Highlights), load1.Highlights.GetBytes());
                CharacterDetails.HighlightTone.value = load1.HighlightTone.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HighlightTone), load1.HighlightTone.GetBytes());
                CharacterDetails.Skintone.value = load1.Skintone.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Skintone), load1.Skintone.GetBytes());
                CharacterDetails.FacialFeatures.value = load1.FacialFeatures.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.FacialFeatures), load1.FacialFeatures.GetBytes());
                CharacterDetails.Eye.value = load1.Eye.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Eye), load1.Eye.GetBytes());
                CharacterDetails.RightEye.value = load1.RightEye.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.RightEye), load1.RightEye.GetBytes());
                CharacterDetails.LeftEye.value = load1.LeftEye.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LeftEye), load1.LeftEye.GetBytes());
                CharacterDetails.FacePaint.value = load1.FacePaint.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.FacePaint), load1.FacePaint.GetBytes());
                CharacterDetails.FacePaintColor.value = load1.FacePaintColor.value;
                MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.FacePaintColor), load1.FacePaintColor.GetBytes());
                byte? NullableCheck = load1.BodyType.value;
                if (NullableCheck != null)
                {
                    CharacterDetails.BodyType.value = load1.BodyType.value;
                    MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.BodyType), load1.BodyType.GetBytes());
                }
                else
                {
                    CharacterDetails.BodyType.value = 1;
                    MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.BodyType), CharacterDetails.BodyType.GetBytes());
                }
                Task.Delay(400).Wait();
                {
                    if (CharacterDetails.LimbalEyes.freezetest == true) { CharacterDetails.LimbalEyes.freeze = false; CharacterDetails.LimbalEyes.freezetest = false; }
                    if (CharacterDetails.Highlights.freezetest == true) { CharacterDetails.Highlights.freeze = false; CharacterDetails.Highlights.freezetest = false; }
                    if (CharacterDetails.MuscleTone.freezetest == true) { CharacterDetails.MuscleTone.freeze = true; CharacterDetails.MuscleTone.freezetest = false; }
                    if (CharacterDetails.TailSize.freezetest == true) { CharacterDetails.TailSize.freeze = true; CharacterDetails.TailSize.freezetest = false; }
                    if (CharacterDetails.BustX.freezetest == true) { CharacterDetails.BustX.freeze = true; CharacterDetails.BustX.freezetest = false; }
                    if (CharacterDetails.BustY.freezetest == true) { CharacterDetails.BustY.freeze = true; CharacterDetails.BustY.freezetest = false; }
                    if (CharacterDetails.BustZ.freezetest == true) { CharacterDetails.BustZ.freeze = true; CharacterDetails.BustZ.freezetest = false; }
                    if (CharacterDetails.LipsBrightness.freezetest == true) { CharacterDetails.LipsBrightness.freeze = true; CharacterDetails.LipsBrightness.freezetest = false; }
                    if (CharacterDetails.SkinBlueGloss.freezetest == true) { CharacterDetails.SkinBlueGloss.freeze = true; CharacterDetails.SkinBlueGloss.freezetest = false; }
                    if (CharacterDetails.SkinGreenGloss.freezetest == true) { CharacterDetails.SkinGreenGloss.freeze = true; CharacterDetails.SkinGreenGloss.freezetest = false; }
                    if (CharacterDetails.SkinRedGloss.freezetest == true) { CharacterDetails.SkinRedGloss.freeze = true; CharacterDetails.SkinRedGloss.freezetest = false; }
                    if (CharacterDetails.SkinBluePigment.freezetest == true) { CharacterDetails.SkinBluePigment.freeze = true; CharacterDetails.SkinBluePigment.freezetest = false; }
                    if (CharacterDetails.SkinGreenPigment.freezetest == true) { CharacterDetails.SkinGreenPigment.freeze = true; CharacterDetails.SkinGreenPigment.freezetest = false; }
                    if (CharacterDetails.SkinRedPigment.freezetest == true) { CharacterDetails.SkinRedPigment.freeze = true; CharacterDetails.SkinRedPigment.freezetest = false; }
                    if (CharacterDetails.HighlightBluePigment.freezetest == true) { CharacterDetails.HighlightBluePigment.freeze = true; CharacterDetails.HighlightBluePigment.freezetest = false; }
                    if (CharacterDetails.HighlightGreenPigment.freezetest == true) { CharacterDetails.HighlightGreenPigment.freeze = true; CharacterDetails.HighlightGreenPigment.freezetest = false; }
                    if (CharacterDetails.HighlightRedPigment.freezetest == true) { CharacterDetails.HighlightRedPigment.freeze = true; CharacterDetails.HighlightRedPigment.freezetest = false; }
                    if (CharacterDetails.HairGlowBlue.freezetest == true) { CharacterDetails.HairGlowBlue.freeze = true; CharacterDetails.HairGlowBlue.freezetest = false; }
                    if (CharacterDetails.HairGlowGreen.freezetest == true) { CharacterDetails.HairGlowGreen.freeze = true; CharacterDetails.HairGlowGreen.freezetest = false; }
                    if (CharacterDetails.HairGlowRed.freezetest == true) { CharacterDetails.HairGlowRed.freeze = true; CharacterDetails.HairGlowRed.freezetest = false; }
                    if (CharacterDetails.HairGreenPigment.freezetest == true) { CharacterDetails.HairGreenPigment.freeze = true; CharacterDetails.HairGreenPigment.freezetest = false; }
                    if (CharacterDetails.HairBluePigment.freezetest == true) { CharacterDetails.HairBluePigment.freeze = true; CharacterDetails.HairBluePigment.freezetest = false; }
                    if (CharacterDetails.HairRedPigment.freezetest == true) { CharacterDetails.HairRedPigment.freeze = true; CharacterDetails.HairRedPigment.freezetest = false; }
                    if (CharacterDetails.Height.freezetest == true) { CharacterDetails.Height.freeze = true; CharacterDetails.Height.freezetest = false; }
                    if (CharacterDetails.RightEyeBlue.freezetest == true) { CharacterDetails.RightEyeBlue.freeze = true; CharacterDetails.RightEyeBlue.freezetest = false; }
                    if (CharacterDetails.RightEyeGreen.freezetest == true) { CharacterDetails.RightEyeGreen.freeze = true; CharacterDetails.RightEyeGreen.freezetest = false; }
                    if (CharacterDetails.RightEyeRed.freezetest == true) { CharacterDetails.RightEyeRed.freeze = true; CharacterDetails.RightEyeRed.freezetest = false; }
                    if (CharacterDetails.LeftEyeBlue.freezetest == true) { CharacterDetails.LeftEyeBlue.freeze = true; CharacterDetails.LeftEyeBlue.freezetest = false; }
                    if (CharacterDetails.LeftEyeGreen.freezetest == true) { CharacterDetails.LeftEyeGreen.freeze = true; CharacterDetails.LeftEyeGreen.freezetest = false; }
                    if (CharacterDetails.LeftEyeRed.freezetest == true) { CharacterDetails.LeftEyeRed.freeze = true; CharacterDetails.LeftEyeRed.freezetest = false; }
                    if (CharacterDetails.LipsB.freezetest == true) { CharacterDetails.LipsB.freeze = true; CharacterDetails.LipsB.freezetest = false; }
                    if (CharacterDetails.LipsG.freezetest == true) { CharacterDetails.LipsG.freeze = true; CharacterDetails.LipsG.freezetest = false; }
                    if (CharacterDetails.LipsR.freezetest == true) { CharacterDetails.LipsR.freeze = true; CharacterDetails.LipsR.freezetest = false; }
                    if (CharacterDetails.LimbalR.freezetest == true) { CharacterDetails.LimbalR.freeze = true; CharacterDetails.LimbalR.freezetest = false; }
                    if (CharacterDetails.LimbalB.freezetest == true) { CharacterDetails.LimbalB.freeze = true; CharacterDetails.LimbalB.freezetest = false; }
                    if (CharacterDetails.LimbalG.freezetest == true) { CharacterDetails.LimbalG.freeze = true; CharacterDetails.LimbalG.freezetest = false; }
                }
                Load.IsEnabled = true;
            }
        }

        private void Uncheck_Click(object sender, RoutedEventArgs e)
        {
            CharacterDetails.TimeControl.freeze = false;
            CharacterDetails.Weather.freeze = false;
            CharacterDetails.CZoom.freeze = false;
            CharacterDetails.CameraYAMax.freeze = false;
            CharacterDetails.FOVC.freeze = false;
            CharacterDetails.CameraHeight2.freeze = false;
            CharacterDetails.CameraUpDown.freeze = false;
            CharacterDetails.CameraYAMin.freeze = false;
            CharacterDetails.CameraYAMax.freeze = false;
            CharacterDetails.Min.freeze = false;
            CharacterDetails.FOVMAX.freeze = false;
            CharacterDetails.Max.freeze = false;
            CharacterDetails.CamZ.freeze = false;
            CharacterDetails.CamY.freeze = false;
            CharacterDetails.CamX.freeze = false;
            CharacterDetails.CameraHeight.freeze = false;
            CharacterDetails.EmoteSpeed1.freeze = false;
            CharacterDetails.Emote.freeze = false;
            CharacterDetails.MuscleTone.freeze = false;
            CharacterDetails.TailSize.freeze = false;
            CharacterDetails.LimbalEyes.freeze = false;
            CharacterDetails.BustX.freeze = false;
            CharacterDetails.BustY.freeze = false;
            CharacterDetails.BustZ.freeze = false;
            CharacterDetails.LipsBrightness.freeze = false;
            CharacterDetails.SkinBlueGloss.freeze = false;
            CharacterDetails.SkinGreenGloss.freeze = false;
            CharacterDetails.SkinRedGloss.freeze = false;
            CharacterDetails.SkinBluePigment.freeze = false;
            CharacterDetails.SkinGreenPigment.freeze = false;
            CharacterDetails.SkinRedPigment.freeze = false;
            CharacterDetails.HighlightBluePigment.freeze = false;
            CharacterDetails.HighlightGreenPigment.freeze = false;
            CharacterDetails.HighlightRedPigment.freeze = false;
            CharacterDetails.HairGlowBlue.freeze = false;
            CharacterDetails.HairGlowGreen.freeze = false;
            CharacterDetails.HairGlowRed.freeze = false;
            CharacterDetails.HairGreenPigment.freeze = false;
            CharacterDetails.HairBluePigment.freeze = false;
            CharacterDetails.HairRedPigment.freeze = false;
            CharacterDetails.Height.freeze = false;
            CharacterDetails.WeaponGreen.freeze = false;
            CharacterDetails.WeaponBlue.freeze = false;
            CharacterDetails.WeaponRed.freeze = false;
            CharacterDetails.WeaponZ.freeze = false;
            CharacterDetails.WeaponY.freeze = false;
            CharacterDetails.WeaponX.freeze = false;
            CharacterDetails.OffhandZ.freeze = false;
            CharacterDetails.OffhandY.freeze = false;
            CharacterDetails.OffhandX.freeze = false;
            CharacterDetails.OffhandRed.freeze = false;
            CharacterDetails.OffhandBlue.freeze = false;
            CharacterDetails.OffhandGreen.freeze = false;
            CharacterDetails.RightEyeBlue.freeze = false;
            CharacterDetails.RightEyeGreen.freeze = false;
            CharacterDetails.RightEyeRed.freeze = false;
            CharacterDetails.LeftEyeBlue.freeze = false;
            CharacterDetails.LeftEyeGreen.freeze = false;
            CharacterDetails.LeftEyeRed.freeze = false;
            CharacterDetails.LipsB.freeze = false;
            CharacterDetails.LipsG.freeze = false;
            CharacterDetails.LipsR.freeze = false;
            CharacterDetails.LimbalB.freeze = false;
            CharacterDetails.LimbalG.freeze = false;
            CharacterDetails.LimbalR.freeze = false;
            CharacterDetails.Race.freeze = false;
            CharacterDetails.Clan.freeze = false;
            CharacterDetails.Gender.freeze = false;
            CharacterDetails.Head.freeze = false;
            CharacterDetails.TailType.freeze = false;
            CharacterDetails.Nose.freeze = false;
            CharacterDetails.Lips.freeze = false;
            CharacterDetails.Voices.freeze = false;
            CharacterDetails.Hair.freeze = false;
            CharacterDetails.HairTone.freeze = false;
            CharacterDetails.HighlightTone.freeze = false;
            CharacterDetails.Jaw.freeze = false;
            CharacterDetails.RBust.freeze = false;
            CharacterDetails.RHeight.freeze = false;
            CharacterDetails.LipsTone.freeze = false;
            CharacterDetails.Skintone.freeze = false;
            CharacterDetails.FacialFeatures.freeze = false;
            CharacterDetails.TailorMuscle.freeze = false;
            CharacterDetails.Eye.freeze = false;
            CharacterDetails.RightEye.freeze = false;
            CharacterDetails.EyeBrowType.freeze = false;
            CharacterDetails.LeftEye.freeze = false;
            CharacterDetails.Offhand.freeze = false;
            CharacterDetails.FacePaint.freeze = false;
            CharacterDetails.FacePaintColor.freeze = false;
            CharacterDetails.Job.freeze = false;
            CharacterDetails.HeadPiece.freeze = false;
            CharacterDetails.Chest.freeze = false;
            CharacterDetails.Arms.freeze = false;
            CharacterDetails.Legs.freeze = false;
            CharacterDetails.Feet.freeze = false;
            CharacterDetails.Ear.freeze = false;
            CharacterDetails.Neck.freeze = false;
            CharacterDetails.Wrist.freeze = false;
            CharacterDetails.Highlights.freeze = false;
            CharacterDetails.RFinger.freeze = false;
            CharacterDetails.LFinger.freeze = false;
            CharacterDetails.ScaleX.freeze = false;
            CharacterDetails.ScaleY.freeze = false;
            CharacterDetails.ScaleZ.freeze = false;
            CharacterDetails.Transparency.freeze = false;
            CharacterDetails.ModelType.freeze = false;
            CharacterDetails.TestArray.freeze = false;
            CharacterDetails.TestArray2.freeze = false;
            CharacterDetails.BodyType.freeze = false;
        }

        private void AlwaysOnTop_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)Properties.Settings.Default.TopApp == false)
            {
                Properties.Settings.Default.TopApp = true;
                Properties.Settings.Default.Save();
                this.Topmost = true;
            }
            else
            {
                Properties.Settings.Default.TopApp = false;
                Properties.Settings.Default.Save();
                this.Topmost = false;
            }
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            ServicePointManager.SecurityProtocol = (ServicePointManager.SecurityProtocol & SecurityProtocolType.Ssl3) | (SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12);
            AutoUpdater.RunUpdateAsAdmin = true;
            AutoUpdater.DownloadPath = Environment.CurrentDirectory;
            AutoUpdater.Mandatory = true;
            AutoUpdater.ShowRemindLaterButton = false;
            AutoUpdater.Start("https://raw.githubusercontent.com/SaberNaut/xd/master/UpdateTest.xml");
        }

        private void GposeButton_Checked(object sender, RoutedEventArgs e)
        {
            if (TargetButton.IsChecked == true) TargetButton.IsChecked = false;
            CharacterRefreshButton.IsEnabled = false;
            NPCRefresh.IsEnabled = false;
            CharacterDetailsViewModel.baseAddr = MemoryManager.Instance.GposeAddress;
        }

        private void GposeButton_Unchecked(object sender, RoutedEventArgs e)
        {
            CharacterRefreshButton.IsEnabled = true;
            NPCRefresh.IsEnabled = true;
            if (GposeButton.IsKeyboardFocusWithin || GposeButton.IsMouseOver)
                CharacterDetailsViewModel.baseAddr = MemoryManager.Add(MemoryManager.Instance.BaseAddress, CharacterDetailsViewModel.eOffset);
        }

        private void TargetButton_Checked(object sender, RoutedEventArgs e)
        {
            if (GposeButton.IsChecked == true) GposeButton.IsChecked = false;
            CharacterRefreshButton.IsEnabled = false;
            NPCRefresh.IsEnabled = false;
            CharacterDetailsViewModel.baseAddr = MemoryManager.Instance.TargetAddress;
        }

        private void TargetButton_Unchecked(object sender, RoutedEventArgs e)
        {
            CharacterRefreshButton.IsEnabled = true;
            NPCRefresh.IsEnabled = true;
            if (TargetButton.IsKeyboardFocusWithin || TargetButton.IsMouseOver)
                CharacterDetailsViewModel.baseAddr = MemoryManager.Add(MemoryManager.Instance.BaseAddress, CharacterDetailsViewModel.eOffset);
        }

        private void MetroWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Properties.Settings.Default.FavoriteEmotes.Clear();
            StringCollection collection = new StringCollection();
            List<int> distinct = EmoteFlyOut.integers.Distinct().ToList(); //remove any repeaters
            collection.AddRange(distinct.Select(x => x.ToString()).ToArray());
            Properties.Settings.Default.FavoriteEmotes = collection;
            Properties.Settings.Default.Save();
        }
    }
}