using FFXIVTool.Utility;
using System;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace FFXIVTool.ViewModel
{
    public class MainViewModel
    {
        private static Mediator mediator;

        private static BackgroundWorker worker;
        public Mem MemLib = new Mem();
        public static int gameProcId = 0;
        public static ThreadWriting ThreadTime;
        private static CharacterDetailsViewModel characterDetails;
        public CharacterDetailsViewModel CharacterDetails { get => characterDetails; set => characterDetails = value; }

        public MainViewModel()
        {
            mediator = new Mediator();
            MemoryManager.Instance.MemLib.OpenProcess(gameProcId);
            LoadSettings();
            worker = new BackgroundWorker();
            worker.DoWork += Worker_DoWork;
            worker.WorkerSupportsCancellation = true;
            worker.RunWorkerAsync();
            characterDetails = new CharacterDetailsViewModel(mediator);
            CharacterDetailsViewModel.baseAddr = MemoryManager.Add(MemoryManager.Instance.BaseAddress, "8");
            Task.Delay(40).Wait();
            ThreadTime = new ThreadWriting(); // Thread Writing
        }
        public static void ShutDownStuff()
        {
            worker.CancelAsync();
            ThreadTime.worker.CancelAsync();
            characterDetails = null;
            mediator = null;
            ThreadTime = null;
        }
        private void LoadSettings()
        {
            // create an xml serializer
            var serializer = new XmlSerializer(typeof(Settings), "");
            // create namespace to remove it for the serializer
            var ns = new XmlSerializerNamespaces();
            // add blank namespaces
            ns.Add("", "");
            // string xmlData = Properties.Resources.Settings;
            var document = XDocument.Load(@"https://raw.githubusercontent.com/SaberNaut/xd/master/SettingsNew.xml");
            // using a stream reader
            using (StringReader reader = new StringReader(document.ToString()))
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
        }
        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            // no fancy tricks here boi
            MemoryManager.Instance.BaseAddress = MemoryManager.Instance.GetBaseAddress(int.Parse(Settings.Instance.AoBOffset, NumberStyles.HexNumber));
            MemoryManager.Instance.TargetAddress = MemoryManager.Instance.GetBaseAddress(int.Parse(Settings.Instance.TargetOffset, NumberStyles.HexNumber));
            MemoryManager.Instance.CameraAddress = MemoryManager.Instance.GetBaseAddress(int.Parse(Settings.Instance.CameraOffset, NumberStyles.HexNumber));
            MemoryManager.Instance.EmoteAddress = MemoryManager.Instance.GetBaseAddress(int.Parse(Settings.Instance.GposeEmoteOffset, NumberStyles.HexNumber));
            MemoryManager.Instance.GposeAddress = MemoryManager.Instance.GetBaseAddress(int.Parse(Settings.Instance.GposeOffset, NumberStyles.HexNumber));
            MemoryManager.Instance.TimeAddress = MemoryManager.Instance.GetBaseAddress(int.Parse(Settings.Instance.TimeOffset, NumberStyles.HexNumber));
            MemoryManager.Instance.WeatherAddress = MemoryManager.Instance.GetBaseAddress(int.Parse(Settings.Instance.WeatherOffset, NumberStyles.HexNumber));
            MemoryManager.Instance.TerritoryAddress = MemoryManager.Instance.GetBaseAddress(int.Parse(Settings.Instance.TerritoryOffset, NumberStyles.HexNumber));
            MemoryManager.Instance.HousingOffset = MemoryManager.Instance.GetBaseAddress(int.Parse(Settings.Instance.HousingOffset, NumberStyles.HexNumber));
            MemoryManager.Instance.MusicOffset = MemoryManager.Instance.GetBaseAddress(int.Parse(Settings.Instance.MusicOffset, NumberStyles.HexNumber));
            MemoryManager.Instance.GposeFilters = MemoryManager.Instance.GetBaseAddress(int.Parse(Settings.Instance.GposeFilters, NumberStyles.HexNumber));
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
    }
}
