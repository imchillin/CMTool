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
using WepTuple = System.Tuple<int, int, int, int>;
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
            AutoUpdater.Start("https://raw.githubusercontent.com/imchillin/SSTool/master/UpdateLog.xml");
            if (!File.Exists(@"./OffsetSettings.xml"))
            {
                try
                {
                    string xmlStr;
                    using (var wc = new WebClient())
                    {
                        xmlStr = wc.DownloadString(@"https://raw.githubusercontent.com/imchillin/SSTool/master/FFXIVTool/OffsetSettings.xml");
                    }
                    var xmlDoc = new System.Xml.XmlDocument();
                    xmlDoc.LoadXml(xmlStr);
                    File.WriteAllText(@"./OffsetSettings.xml", xmlDoc.InnerXml);
                }
                catch
                {
                    System.Windows.MessageBox.Show("Unable to connect to the remote server - No connection could be made because the target machine actively refused it! \n If you wish to pursue using this application please download an updated OffsetSettings via discord.", "Oh no!");
                    Close();
                    return;
                }
            }
            List<ProcessLooker.Game> GameList = new  List<ProcessLooker.Game>();
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
            this.Title = "SSTool v" + version + " By: Johto & LeonBlade";
            DataContext = new MainViewModel();
            var accentColor = Properties.Settings.Default.Accent;
            new PaletteHelper().ReplaceAccentColor(accentColor);
            var primaryColor = Properties.Settings.Default.Primary;
            new PaletteHelper().ReplacePrimaryColor(primaryColor);
            var theme = Properties.Settings.Default.Theme;
            new PaletteHelper().SetLightDark(theme != "Light");
            this.Topmost = Properties.Settings.Default.TopApp;
			// toggle status
			(DataContext as MainViewModel).ToggleStatus(Properties.Settings.Default.TopApp);
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
            Process.Start("https://twitter.com/ffxivsstool");
        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            CurrentlySaving = true;
            var c = new Windows.GearSave("Save Character Save", "Write Character Save name here...");
            c.Owner = Application.Current.MainWindow;
            c.ShowDialog();
            if (c.Filename == null) { CurrentlySaving = false; return; }
            else
            {
                string path = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDoc‌​uments), "SSTool", "Saves");
                if (Directory.Exists(path))
                {
                    CharSaves Save1 = new CharSaves(); // Gearsave is class with all address
                    Save1.Description = c.Filename;
                    Save1.DateCreated = (DateTime.Today.ToString("dd-MM-yyyy") + "-" + DateTime.Now.ToString("HH:mm:ss"));
                    Save1.MainHand = new WepTuple(CharacterDetails.Job.value, CharacterDetails.WeaponBase.value, CharacterDetails.WeaponV.value, CharacterDetails.WeaponDye.value);
                    Save1.OffHand = new WepTuple(CharacterDetails.Offhand.value, CharacterDetails.OffhandBase.value, CharacterDetails.OffhandV.value, CharacterDetails.OffhandDye.value);
                    Save1.EquipmentBytes = CharacterDetails.TestArray2.value;
                    Save1.CharacterBytes = CharacterDetails.TestArray.value;
                    Save1.characterDetails = CharacterDetails;
                    string details = JsonConvert.SerializeObject(Save1, Formatting.Indented);
                    File.WriteAllText(Path.Combine(path, c.Filename + ".json"), details);
                    CurrentlySaving = false;
                }
                else
                {
                    System.IO.Directory.CreateDirectory(path);
                    CharSaves Save1 = new CharSaves(); // Gearsave is class with all address
                    Save1.Description = c.Filename;
                    Save1.DateCreated = (DateTime.Today.ToString("dd-MM-yyyy") + "-" + DateTime.Now.ToString("HH:mm:ss"));
                    Save1.MainHand = new WepTuple(CharacterDetails.Job.value, CharacterDetails.WeaponBase.value, CharacterDetails.WeaponV.value, CharacterDetails.WeaponDye.value);
                    Save1.OffHand = new WepTuple(CharacterDetails.Offhand.value, CharacterDetails.OffhandBase.value, CharacterDetails.OffhandV.value, CharacterDetails.OffhandDye.value);
                    Save1.EquipmentBytes = CharacterDetails.TestArray2.value;
                    Save1.CharacterBytes = CharacterDetails.TestArray.value;
                    Save1.characterDetails = CharacterDetails;
                    string details = JsonConvert.SerializeObject(Save1, Formatting.Indented);
                    File.WriteAllText(Path.Combine(path, c.Filename + ".json"), details);
                    CurrentlySaving = false;
                }
            }
        }
        private void Load_Click(object sender, RoutedEventArgs e)
        {
            var c = new LoadWindow();
            c.Owner = this;
            c.ShowDialog();
            if (c.Choice == null) return;
            if (c.Choice == "All") AllSaves();
            if (c.Choice == "App") Appereanco();
            if (c.Choice == "Xuip") Equipo();
            if (c.Choice == "Dat") LetsGoDats();
        }
        private void LetsGoDats()
        {
            CharacterSaveChooseWindow fam = new CharacterSaveChooseWindow("Select the saved character you want to load.");
            fam.Owner = this;
            fam.ShowDialog();
            if (fam.Choice != null)
            {
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
                WriteCurrentCustomize(fam.Choice);
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
        private void AllSaves()
        {
            Windows.SaveChooseWindow fam = new Windows.SaveChooseWindow("Select the saved Character[All] Save you want to load.");
            fam.Owner = Application.Current.MainWindow;
            fam.ShowDialog();
            if (fam.Choice != null)
            {
                LoadTime(fam.Choice, 0);
            }
            else return;
        }
        private void Appereanco()
        {
            Windows.SaveChooseWindow fam = new Windows.SaveChooseWindow("Select the saved Character[Appearance] Save you want to load.");
            fam.Owner = Application.Current.MainWindow;
            fam.ShowDialog();
            if (fam.Choice != null)
            {
                LoadTime(fam.Choice, 1);
            }
            else return;
        }
        private void Equipo()
        {
            Windows.SaveChooseWindow fam = new Windows.SaveChooseWindow("Select the saved Character[Equipment] Save you want to load.");
            fam.Owner = Application.Current.MainWindow;
            fam.ShowDialog();
            if (fam.Choice != null)
            {
                LoadTime(fam.Choice, 2);
            }
            else return;
        }
        private void LoadTime(CharSaves charSaves, int savechoice)
        {
            try
            {
                if(savechoice==0 || savechoice==1)
                {
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
                } // 0 = All ; 1= Appearance; 2=Equipment
                if (savechoice==0 || savechoice==2)
                {
                    if (CharacterDetails.HeadPiece.freeze == true) { CharacterDetails.HeadPiece.freeze = false; CharacterDetails.HeadPiece.Cantbeused = true; }
                    if (CharacterDetails.Chest.freeze == true) { CharacterDetails.Chest.freeze = false; CharacterDetails.Chest.Cantbeused = true; }
                    if (CharacterDetails.Arms.freeze == true) { CharacterDetails.Arms.freeze = false; CharacterDetails.Arms.Cantbeused = true; }
                    if (CharacterDetails.Legs.freeze == true) { CharacterDetails.Legs.freeze = false; CharacterDetails.Legs.Cantbeused = true; }
                    if (CharacterDetails.Feet.freeze == true) { CharacterDetails.Feet.freeze = false; CharacterDetails.Feet.Cantbeused = true; }
                    if (CharacterDetails.Neck.freeze == true) { CharacterDetails.Neck.freeze = false; CharacterDetails.Neck.Cantbeused = true; }
                    if (CharacterDetails.Ear.freeze == true) { CharacterDetails.Ear.freeze = false; CharacterDetails.Ear.Cantbeused = true; }
                    if (CharacterDetails.Wrist.freeze == true) { CharacterDetails.Wrist.freeze = false; CharacterDetails.Wrist.Cantbeused = true; }
                    if (CharacterDetails.RFinger.freeze == true) { CharacterDetails.RFinger.freeze = false; CharacterDetails.RFinger.Cantbeused = true; }
                    if (CharacterDetails.LFinger.freeze == true) { CharacterDetails.LFinger.freeze = false; CharacterDetails.LFinger.Cantbeused = true; }
                    if (CharacterDetails.Job.freeze == true) { CharacterDetails.Job.freeze = false; CharacterDetails.Job.Cantbeused = true; }
                    if (CharacterDetails.Offhand.freeze == true) { CharacterDetails.Offhand.freeze = false; CharacterDetails.Offhand.Cantbeused = true; }
                    if (CharacterDetails.WeaponGreen.freeze == true) { CharacterDetails.WeaponGreen.freeze = false; CharacterDetails.WeaponGreen.Cantbeused = true; }
                    if (CharacterDetails.WeaponBlue.freeze == true) { CharacterDetails.WeaponBlue.freeze = false; CharacterDetails.WeaponBlue.Cantbeused = true; }
                    if (CharacterDetails.WeaponRed.freeze == true) { CharacterDetails.WeaponRed.freeze = false; CharacterDetails.WeaponRed.Cantbeused = true; }
                    if (CharacterDetails.WeaponZ.freeze == true) { CharacterDetails.WeaponZ.freeze = false; CharacterDetails.WeaponZ.Cantbeused = true; }
                    if (CharacterDetails.WeaponY.freeze == true) { CharacterDetails.WeaponY.freeze = false; CharacterDetails.WeaponY.Cantbeused = true; }
                    if (CharacterDetails.WeaponX.freeze == true) { CharacterDetails.WeaponX.freeze = false; CharacterDetails.WeaponX.Cantbeused = true; }
                    if (CharacterDetails.OffhandZ.freeze == true) { CharacterDetails.OffhandZ.freeze = false; CharacterDetails.OffhandZ.Cantbeused = true; }
                    if (CharacterDetails.OffhandY.freeze == true) { CharacterDetails.OffhandY.freeze = false; CharacterDetails.OffhandY.Cantbeused = true; }
                    if (CharacterDetails.OffhandX.freeze == true) { CharacterDetails.OffhandX.freeze = false; CharacterDetails.OffhandX.Cantbeused = true; }
                    if (CharacterDetails.OffhandRed.freeze == true) { CharacterDetails.OffhandRed.freeze = false; CharacterDetails.OffhandRed.Cantbeused = true; }
                    if (CharacterDetails.OffhandBlue.freeze == true) { CharacterDetails.OffhandBlue.freeze = false; CharacterDetails.OffhandBlue.Cantbeused = true; }
                    if (CharacterDetails.OffhandGreen.freeze == true) { CharacterDetails.OffhandGreen.freeze = false; CharacterDetails.OffhandGreen.Cantbeused = true; }
                }
                System.Threading.Tasks.Task.Delay(45).Wait();
                {
                    if(savechoice==0 || savechoice==1)
                    {
                        byte[] CharacterBytes;
                        CharacterBytes = MemoryManager.StringToByteArray(charSaves.CharacterBytes.Replace(" ", string.Empty));
                        MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Race), CharacterBytes);
                        if (charSaves.characterDetails.Height.value != 0.000)
                        {
                            CharacterDetails.Height.value = charSaves.characterDetails.Height.value;
                            MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Height), "float", charSaves.characterDetails.Height.value.ToString());
                        }
                        CharacterDetails.Voices.value = charSaves.characterDetails.Voices.value;
                        MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Voices), charSaves.characterDetails.Voices.GetBytes());
                        CharacterDetails.MuscleTone.value = charSaves.characterDetails.MuscleTone.value;
                        MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.MuscleTone), "float", charSaves.characterDetails.MuscleTone.value.ToString());
                        CharacterDetails.TailSize.value = charSaves.characterDetails.TailSize.value;
                        MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.TailSize), "float", charSaves.characterDetails.TailSize.value.ToString());
                        CharacterDetails.BustX.value = charSaves.characterDetails.BustX.value;
                        MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bust.Base, Settings.Instance.Character.Body.Bust.X), "float", charSaves.characterDetails.BustX.value.ToString());
                        CharacterDetails.BustY.value = charSaves.characterDetails.BustY.value;
                        MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bust.Base, Settings.Instance.Character.Body.Bust.Y), "float", charSaves.characterDetails.BustY.value.ToString());
                        CharacterDetails.BustZ.value = charSaves.characterDetails.BustZ.value;
                        MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bust.Base, Settings.Instance.Character.Body.Bust.Z), "float", charSaves.characterDetails.BustZ.value.ToString());
                        CharacterDetails.HairRedPigment.value = charSaves.characterDetails.HairRedPigment.value;
                        MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HairRedPigment), "float", charSaves.characterDetails.HairRedPigment.value.ToString());
                        CharacterDetails.HairBluePigment.value = charSaves.characterDetails.HairBluePigment.value;
                        MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HairBluePigment), "float", charSaves.characterDetails.HairBluePigment.value.ToString());
                        CharacterDetails.HairGreenPigment.value = charSaves.characterDetails.HairGreenPigment.value;
                        MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HairGreenPigment), "float", charSaves.characterDetails.HairGreenPigment.value.ToString());
                        CharacterDetails.HairGlowRed.value = charSaves.characterDetails.HairGlowRed.value;
                        MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HairGlowRed), "float", charSaves.characterDetails.HairGlowRed.value.ToString());
                        CharacterDetails.HairGlowGreen.value = charSaves.characterDetails.HairGlowGreen.value;
                        MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HairGlowGreen), "float", charSaves.characterDetails.HairGlowGreen.value.ToString());
                        CharacterDetails.HairGlowBlue.value = charSaves.characterDetails.HairGlowBlue.value;
                        MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HairGlowBlue), "float", charSaves.characterDetails.HairGlowBlue.value.ToString());
                        CharacterDetails.HighlightRedPigment.value = charSaves.characterDetails.HighlightRedPigment.value;
                        MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HighlightRedPigment), "float", charSaves.characterDetails.HighlightRedPigment.value.ToString());
                        CharacterDetails.HighlightGreenPigment.value = charSaves.characterDetails.HighlightGreenPigment.value;
                        MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HighlightGreenPigment), "float", charSaves.characterDetails.HighlightGreenPigment.value.ToString());
                        CharacterDetails.HighlightBluePigment.value = charSaves.characterDetails.HighlightBluePigment.value;
                        MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HighlightBluePigment), "float", charSaves.characterDetails.HighlightBluePigment.value.ToString());
                        CharacterDetails.SkinRedPigment.value = charSaves.characterDetails.SkinRedPigment.value;
                        MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.SkinRedPigment), "float", charSaves.characterDetails.SkinRedPigment.value.ToString());
                        CharacterDetails.SkinGreenPigment.value = charSaves.characterDetails.SkinGreenPigment.value;
                        MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.SkinGreenPigment), "float", charSaves.characterDetails.SkinGreenPigment.value.ToString());
                        CharacterDetails.SkinBluePigment.value = charSaves.characterDetails.SkinBluePigment.value;
                        MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.SkinBluePigment), "float", charSaves.characterDetails.SkinBluePigment.value.ToString());
                        CharacterDetails.SkinRedGloss.value = charSaves.characterDetails.SkinRedGloss.value;
                        MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.SkinRedGloss), "float", charSaves.characterDetails.SkinRedGloss.value.ToString());
                        CharacterDetails.SkinGreenGloss.value = charSaves.characterDetails.SkinGreenGloss.value;
                        MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.SkinGreenGloss), "float", charSaves.characterDetails.SkinGreenGloss.value.ToString());
                        CharacterDetails.SkinBlueGloss.value = charSaves.characterDetails.SkinBlueGloss.value;
                        MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.SkinBlueGloss), "float", charSaves.characterDetails.SkinBlueGloss.value.ToString());
                        CharacterDetails.LipsBrightness.value = charSaves.characterDetails.LipsBrightness.value;
                        MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LipsBrightness), "float", charSaves.characterDetails.LipsBrightness.value.ToString());
                        CharacterDetails.LipsR.value = charSaves.characterDetails.LipsR.value;
                        MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LipsR), "float", charSaves.characterDetails.LipsR.value.ToString());
                        CharacterDetails.LipsG.value = charSaves.characterDetails.LipsG.value;
                        MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LipsG), "float", charSaves.characterDetails.LipsG.value.ToString());
                        CharacterDetails.LipsB.value = charSaves.characterDetails.LipsB.value;
                        MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LipsB), "float", charSaves.characterDetails.LipsB.value.ToString());
                        CharacterDetails.LimbalR.value = charSaves.characterDetails.LimbalR.value;
                        MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LimbalR), "float", charSaves.characterDetails.LimbalR.value.ToString());
                        CharacterDetails.LimbalG.value = charSaves.characterDetails.LimbalG.value;
                        MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LimbalG), "float", charSaves.characterDetails.LimbalG.value.ToString());
                        CharacterDetails.LimbalB.value = charSaves.characterDetails.LimbalB.value;
                        MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LimbalB), "float", charSaves.characterDetails.LimbalB.value.ToString());
                        CharacterDetails.LeftEyeRed.value = charSaves.characterDetails.LeftEyeRed.value;
                        MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LeftEyeRed), "float", charSaves.characterDetails.LeftEyeRed.value.ToString());
                        CharacterDetails.LeftEyeGreen.value = charSaves.characterDetails.LeftEyeGreen.value;
                        MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LeftEyeGreen), "float", charSaves.characterDetails.LeftEyeGreen.value.ToString());
                        CharacterDetails.LeftEyeBlue.value = charSaves.characterDetails.LeftEyeBlue.value;
                        MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LeftEyeBlue), "float", charSaves.characterDetails.LeftEyeBlue.value.ToString());
                        CharacterDetails.RightEyeRed.value = charSaves.characterDetails.RightEyeRed.value;
                        MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.RightEyeRed), "float", charSaves.characterDetails.RightEyeRed.value.ToString());
                        CharacterDetails.RightEyeGreen.value = charSaves.characterDetails.RightEyeGreen.value;
                        MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.RightEyeGreen), "float", charSaves.characterDetails.RightEyeGreen.value.ToString());
                        CharacterDetails.RightEyeBlue.value = charSaves.characterDetails.RightEyeBlue.value;
                        MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.RightEyeBlue), "float", charSaves.characterDetails.RightEyeBlue.value.ToString());
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
                    if (savechoice == 0 || savechoice == 2)
                    {
                        byte[] EquipmentArray;
                        EquipmentArray = MemoryManager.StringToByteArray(charSaves.EquipmentBytes.Replace(" ", string.Empty));
                        MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HeadPiece), EquipmentArray);
                        CharacterDetails.Job.value = charSaves.MainHand.Item1;
                        CharacterDetails.WeaponBase.value = (byte)charSaves.MainHand.Item2;
                        CharacterDetails.WeaponV.value = (byte)charSaves.MainHand.Item3;
                        CharacterDetails.WeaponDye.value = (byte)charSaves.MainHand.Item4;
                        MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Job), EquipmentFlyOut.WepTupleToByteAry(charSaves.MainHand));
                        CharacterDetails.Offhand.value = charSaves.OffHand.Item1;
                        CharacterDetails.OffhandBase.value = (byte)charSaves.OffHand.Item2;
                        CharacterDetails.OffhandV.value = (byte)charSaves.OffHand.Item3;
                        CharacterDetails.OffhandDye.value = (byte)charSaves.OffHand.Item4;
                        CharacterDetails.WeaponX.value = charSaves.characterDetails.WeaponX.value;
                        MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.WeaponX), "float", charSaves.characterDetails.WeaponX.value.ToString());
                        CharacterDetails.WeaponY.value = charSaves.characterDetails.WeaponY.value;
                        MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.WeaponY), "float", charSaves.characterDetails.WeaponY.value.ToString());
                        CharacterDetails.WeaponZ.value = charSaves.characterDetails.WeaponZ.value;
                        MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.WeaponZ), "float", charSaves.characterDetails.WeaponZ.value.ToString());
                        CharacterDetails.WeaponRed.value = charSaves.characterDetails.WeaponRed.value;
                        MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.WeaponRed), "float", charSaves.characterDetails.WeaponRed.value.ToString());
                        CharacterDetails.WeaponBlue.value = charSaves.characterDetails.WeaponBlue.value;
                        MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.WeaponBlue), "float", charSaves.characterDetails.WeaponBlue.value.ToString());
                        CharacterDetails.WeaponGreen.value = charSaves.characterDetails.WeaponGreen.value;
                        MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.WeaponGreen), "float", charSaves.characterDetails.WeaponGreen.value.ToString());
                        CharacterDetails.OffhandBlue.value = charSaves.characterDetails.OffhandBlue.value;
                        MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.OffhandBlue), "float", charSaves.characterDetails.OffhandBlue.value.ToString());
                        CharacterDetails.OffhandGreen.value = charSaves.characterDetails.OffhandGreen.value;
                        MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.OffhandGreen), "float", charSaves.characterDetails.OffhandGreen.value.ToString());
                        CharacterDetails.OffhandRed.value = charSaves.characterDetails.OffhandRed.value;
                        MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.OffhandRed), "float", charSaves.characterDetails.OffhandRed.value.ToString());
                        CharacterDetails.OffhandX.value = charSaves.characterDetails.OffhandX.value;
                        MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.OffhandX), "float", charSaves.characterDetails.OffhandX.value.ToString());
                        CharacterDetails.OffhandY.value = charSaves.characterDetails.OffhandY.value;
                        MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.OffhandY), "float", charSaves.characterDetails.OffhandY.value.ToString());
                        CharacterDetails.OffhandZ.value = charSaves.characterDetails.OffhandZ.value;
                        MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.OffhandZ), "float", charSaves.characterDetails.OffhandZ.value.ToString());
                        MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Offhand), EquipmentFlyOut.WepTupleToByteAry(charSaves.OffHand));
                        if (CharacterDetails.HeadPiece.Cantbeused == true) { CharacterDetails.HeadPiece.freeze = true; CharacterDetails.HeadPiece.Cantbeused = false; }
                        if (CharacterDetails.Chest.Cantbeused == true) { CharacterDetails.Chest.freeze = true; CharacterDetails.Chest.Cantbeused = false; }
                        if (CharacterDetails.Arms.Cantbeused == true) { CharacterDetails.Arms.freeze = true; CharacterDetails.Arms.Cantbeused = false; }
                        if (CharacterDetails.Legs.Cantbeused == true) { CharacterDetails.Legs.freeze = true; CharacterDetails.Legs.Cantbeused = false; }
                        if (CharacterDetails.Feet.Cantbeused == true) { CharacterDetails.Feet.freeze = true; CharacterDetails.Feet.Cantbeused = false; }
                        if (CharacterDetails.Neck.Cantbeused == true) { CharacterDetails.Neck.freeze = true; CharacterDetails.Neck.Cantbeused = false; }
                        if (CharacterDetails.Ear.Cantbeused == true) { CharacterDetails.Ear.freeze = true; CharacterDetails.Ear.Cantbeused = false; }
                        if (CharacterDetails.Wrist.Cantbeused == true) { CharacterDetails.Wrist.freeze = true; CharacterDetails.Wrist.Cantbeused = false; }
                        if (CharacterDetails.RFinger.Cantbeused == true) { CharacterDetails.RFinger.freeze = true; CharacterDetails.RFinger.Cantbeused = false; }
                        if (CharacterDetails.LFinger.Cantbeused == true) { CharacterDetails.LFinger.freeze = true; CharacterDetails.LFinger.Cantbeused = false; }
                        if (CharacterDetails.Job.Cantbeused == true) { CharacterDetails.Job.freeze = true; CharacterDetails.Job.Cantbeused = false; }
                        if (CharacterDetails.Offhand.Cantbeused == true) { CharacterDetails.Offhand.freeze = true; CharacterDetails.Offhand.Cantbeused = false; }
                        if (CharacterDetails.WeaponGreen.Cantbeused == true) { CharacterDetails.WeaponGreen.freeze = true; CharacterDetails.WeaponGreen.Cantbeused = false; }
                        if (CharacterDetails.WeaponBlue.Cantbeused == true) { CharacterDetails.WeaponBlue.freeze = true; CharacterDetails.WeaponBlue.Cantbeused = false; }
                        if (CharacterDetails.WeaponRed.Cantbeused == true) { CharacterDetails.WeaponRed.freeze = true; CharacterDetails.WeaponRed.Cantbeused = false; }
                        if (CharacterDetails.WeaponZ.Cantbeused == true) { CharacterDetails.WeaponZ.freeze = true; CharacterDetails.WeaponZ.Cantbeused = false; }
                        if (CharacterDetails.WeaponY.Cantbeused == true) { CharacterDetails.WeaponY.freeze = true; CharacterDetails.WeaponY.Cantbeused = false; }
                        if (CharacterDetails.WeaponX.Cantbeused == true) { CharacterDetails.WeaponX.freeze = true; CharacterDetails.WeaponX.Cantbeused = false; }
                        if (CharacterDetails.OffhandZ.Cantbeused == true) { CharacterDetails.OffhandZ.freeze = true; CharacterDetails.OffhandZ.Cantbeused = false; }
                        if (CharacterDetails.OffhandY.Cantbeused == true) { CharacterDetails.OffhandY.freeze = true; CharacterDetails.OffhandY.Cantbeused = false; }
                        if (CharacterDetails.OffhandX.Cantbeused == true) { CharacterDetails.OffhandX.freeze = true; CharacterDetails.OffhandX.Cantbeused = false; }
                        if (CharacterDetails.OffhandRed.Cantbeused == true) { CharacterDetails.OffhandRed.freeze = true; CharacterDetails.OffhandRed.Cantbeused = false; }
                        if (CharacterDetails.OffhandBlue.Cantbeused == true) { CharacterDetails.OffhandBlue.freeze = true; CharacterDetails.OffhandBlue.Cantbeused = false; }
                        if (CharacterDetails.OffhandGreen.Cantbeused == true) { CharacterDetails.OffhandGreen.freeze = true; CharacterDetails.OffhandGreen.Cantbeused = false; }
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("One or more fields were not formatted correctly.\n\n" + exc, " Error " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version, MessageBoxButton.OK, MessageBoxImage.Error);
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
            CharacterDetails.X.freeze = false;
            CharacterDetails.Y.freeze = false;
            CharacterDetails.Z.freeze = false;
            CharacterDetails.Rotation.freeze = false;
            CharacterDetails.Rotation2.freeze = false;
            CharacterDetails.Rotation3.freeze = false;
            CharacterDetails.Rotation4.freeze = false;
            CharacterDetailsView.xyzcheck = false;
            CharacterDetailsView.numbcheck = false;
        }

		private void AlwaysOnTop_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)Properties.Settings.Default.TopApp == false)
            {
                Properties.Settings.Default.TopApp = true;
                Properties.Settings.Default.Save();
                this.Topmost = true;
				(DataContext as MainViewModel).ToggleStatus(true);
            }
            else
            {
                Properties.Settings.Default.TopApp = false;
                Properties.Settings.Default.Save();
                this.Topmost = false;
				(DataContext as MainViewModel).ToggleStatus(false);
			}
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            ServicePointManager.SecurityProtocol = (ServicePointManager.SecurityProtocol & SecurityProtocolType.Ssl3) | (SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12);
            AutoUpdater.RunUpdateAsAdmin = true;
            AutoUpdater.DownloadPath = Environment.CurrentDirectory;
            AutoUpdater.Mandatory = true;
            AutoUpdater.ShowRemindLaterButton = false;
            AutoUpdater.Start("https://raw.githubusercontent.com/imchillin/SSTool/master/UpdateLog.xml");
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

        private void ActualDiscordButton_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("https://discord.gg/hq3DnBa");
        }
    }
}
