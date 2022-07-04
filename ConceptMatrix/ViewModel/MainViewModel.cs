using ConceptMatrix.Sheets;
using ConceptMatrix.Utility;
using ConceptMatrix.Views;
using Lumina;
using Lumina.Extensions;
using MaterialDesignThemes.Wpf;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Forms;
using System.Windows.Media;

namespace ConceptMatrix.ViewModel
{
  public class MainViewModel : INotifyPropertyChanged
  {
    public static Mediator mediator;
    public static GameData gameData;

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

    public static ImageSource Corrupted = App.GetImageStream((System.Drawing.Image)Properties.Resources.ResourceManager.GetObject("Corrupted"));

    public CharacterDetailsViewModel CharacterDetails { get => characterDetails; set => characterDetails = value; }

    public static Thread luminaThread;
    private static bool threadAlive = true;

    public PackIconKind AOTToggleStatus { get; set; } = PackIconKind.ToggleSwitchOffOutline;
    public Brush ToggleForeground { get; set; } = new SolidColorBrush(Color.FromArgb(0x75, 0xFF, 0xFF, 0xFF));

    public MainViewModel()
    {
      Console.WriteLine($"Time taken to reach MainViewModel.ctor() {App.sw.ElapsedMilliseconds}ms");
      App.sw.Stop();

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
          gameData = new GameData(Path.Combine(GameDirectory, "game", "sqpack"));
          // Thread for handling Lumina file queueing.
          luminaThread = new Thread(() =>
          {
            while (luminaThread.IsAlive && threadAlive)
            {
              gameData.ProcessFileHandleQueue();
              Thread.Yield();
            }
          });

          // Start the Lumina file thread.
          luminaThread.Start();

          if (File.Exists(Path.Combine(GameDirectory, "FFXIVBoot.exe")) || File.Exists(Path.Combine(GameDirectory, "rail_files", "rail_game_identify.json")))
          {
            RegionType = "zh";
            gameData.Options.DefaultExcelLanguage = Lumina.Data.Language.ChineseSimplified;
          }
          else if (File.Exists(Path.Combine(GameDirectory, "boot", "FFXIV_Boot.exe")))
          {
            RegionType = "ko";
            gameData.Options.DefaultExcelLanguage = Lumina.Data.Language.Korean;
          }
          if (RegionType == "Live")
          {
            if (SaveSettings.Default.Language == "en")
              gameData.Options.DefaultExcelLanguage = Lumina.Data.Language.English;
            else if (SaveSettings.Default.Language == "ja")
              gameData.Options.DefaultExcelLanguage = Lumina.Data.Language.Japanese;
            else if (SaveSettings.Default.Language == "de")
              gameData.Options.DefaultExcelLanguage = Lumina.Data.Language.German;
            else if (SaveSettings.Default.Language == "fr")
              gameData.Options.DefaultExcelLanguage = Lumina.Data.Language.French;
            else
              gameData.Options.DefaultExcelLanguage = Lumina.Data.Language.English;
          }

          Initialize(RegionType);
          MainWindow.HasRead = true;
        }
        MainViewModelX = this;
        if (!MemoryManager.Instance.MemLib.OpenProcess(gameProcId))
        {
          MessageBox.Show("Could not open process!", App.ToolName);
          App.Current.Shutdown();
        }
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
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message, "Error occured in MainViewModel");
        MessageBox.Show(ex.StackTrace);
      }
    }

    public static ImageSource GetLuminaIconImage(ushort icon)
    {
      try
      {
        return gameData.GetIcon(icon).GetImage();
      }
      catch
      {
        return Corrupted;
      }
    }

    public static void Shutdown()
    {
      try
      {
        worker.CancelAsync();
        threadWriting?.worker.CancelAsync();
        characterDetails = null;
        threadWriting = null;

        // Turn off the time stop code.
        MemoryManager.Instance.MemLib.writeBytes(MemoryManager.Instance.TimeStopAsm.ToString("X"), MemoryManager.Instance.TimeAsm);
        // Turn off the emote hack.
        MemoryManager.Instance.MemLib.writeBytes(MemoryManager.Instance.EmoteHack, new byte[] { 0x66, 0x89, 0x8B, 0xD0, 0x00, 0x00, 0x00 });

        // Remove nops for skeleton instructions.
        MemoryManager.Instance.MemLib.writeMemory(MemoryManager.Instance.SkeletonAddress, "bytes", "0x41 0x0F 0x29 0x5C 0x12 0x10");
        MemoryManager.Instance.MemLib.writeMemory(MemoryManager.Instance.SkeletonAddress2, "bytes", "0x43 0x0F 0x29 0x5C 0x18 0x10");
        MemoryManager.Instance.MemLib.writeMemory(MemoryManager.Instance.SkeletonAddress3, "bytes", "0x0F 0x29 0x5E 0x10");
        MemoryManager.Instance.MemLib.writeMemory(MemoryManager.Instance.SkeletonAddress4, "bytes", "0x41 0x0F 0x29 0x44 0x12 0x20");
        MemoryManager.Instance.MemLib.writeMemory(MemoryManager.Instance.SkeletonAddress5, "bytes", "0x41 0x0F 0x29 0x24 0x12");
        MemoryManager.Instance.MemLib.writeMemory(MemoryManager.Instance.SkeletonAddress6, "bytes", "0x43 0x0F 0x29 0x44 0x18 0x20");
        MemoryManager.Instance.MemLib.writeMemory(MemoryManager.Instance.SkeletonAddress7, "bytes", "0x43 0x0F 0x29 0x24 0x18");

        MemoryManager.Instance.MemLib.writeMemory(MemoryManager.Instance.PhysicsAddress, "bytes", "0x0F 0x29 0x48 0x10");
        MemoryManager.Instance.MemLib.writeMemory(MemoryManager.Instance.PhysicsAddress2, "bytes", "0x0F 0x29 0x00");
        MemoryManager.Instance.MemLib.writeMemory(MemoryManager.Instance.PhysicsAddress3, "bytes", "0x0F 0x29 0x40 0x20");

        MemoryManager.Instance.MemLib.writeMemory(MemoryManager.Instance.CharacterRenderAddress, "bytes", "0xE9 0xB8 0x00 0x00 0x00");

        // Kill the Lumina thread.
        threadAlive = false;
      }
      catch (Exception ex)
      {
        MessageBox.Show("Crashed while shutting down! You may experience some bugs with the game if you clicked reload process and may require a game restart!");
        MessageBox.Show(ex.Message);
        MessageBox.Show(ex.StackTrace);
      }
    }

    private IEnumerable<string> races, tribes;

    private void Initialize(string _)
    {
      // Local stopwatch used for timing the startup lumina processes.
      var sw = Stopwatch.StartNew();

      Task.Run(() =>
      {
        this.races = from r in gameData.GetExcelSheet<Race>() select r.Feminine.RawString.DefaultIfEmpty("None");
        this.tribes = from t in gameData.GetExcelSheet<Tribe>() select t.Feminine.RawString.DefaultIfEmpty("None");

        App.Current.Dispatcher.Invoke(() =>
              {
                characterView.RaceBox.ItemsSource = races;
                characterView.ClanBox.ItemsSource = tribes;
              });

        try
        {
          var voices = new List<ExdCsvReader.CMVoice>();
          var cmtSheet = gameData.GetExcelSheet<CharaMakeType>().Where(c => c.Tribe != 0);
          var r = this.races.ToArray();
          var t = this.tribes.ToArray();
          var male = Resx.MiscStrings.Male;
          var female = Resx.MiscStrings.Female;

          foreach (var cmt in cmtSheet)
            for (var i = 0; i < cmt.VoiceStruct.Length; i++)
              voices.Add(new ExdCsvReader.CMVoice() { Voice = cmt.VoiceStruct[i], Name = $"Voice {i + 1} ({cmt.VoiceStruct[i]})", Group = $"{r[cmt.Race]}, {t[cmt.Tribe]} ({(cmt.Gender == 0 ? male : female)})" });

          var lcv = new ListCollectionView(voices);
          lcv.GroupDescriptions.Add(new PropertyGroupDescription("Group"));

          App.Current.Dispatcher.Invoke(() => characterView.Voices.ItemsSource = lcv);
        }
        catch (Exception ex)
        {
          MessageBox.Show(ex.Message + "\n" + ex.StackTrace + "\n" + ex.InnerException.StackTrace, "Error fetching voices sheet!");
        }
      });
      Task.Run(() => CharacterDetailsView.dataProvider.MakeItemList());
      Task.Run(() => CharacterDetailsView.dataProvider.MakePropList());
      Task.Run(() => CharacterDetailsView.dataProvider.MakeResidentList());
      Task.Run(() => CharacterDetailsView.dataProvider.MakeCharaMakeFeatureFacialList());
      Task.Run(() => CharacterDetailsView.dataProvider.MakeCharaMakeFeatureList());
      Task.Run(() =>
      {
        CharacterDetailsView.dataProvider.EmoteList();
        App.Current.Dispatcher.Invoke(() => characterView.EmoteFlyouts.Initialize());
      });
      Task.Run(() =>
      {
        CharacterDetailsView.dataProvider.MonsterList();
        App.Current.Dispatcher.Invoke(() => characterView.SpecialControl.ModelBox.ItemsSource = CharacterDetailsView.dataProvider.Monsters);
      });
      Task.Run(() => CharacterDetailsView.dataProvider.MakeTerritoryTypeList());
      Task.Run(() =>
      {
        CharacterDetailsView.dataProvider.GetStatuses();
        App.Current.Dispatcher.Invoke(() => actorPropView.StatusEffectBox2.ItemsSource = CharacterDetailsView.dataProvider.Statuses);
      });
      Task.Run(() =>
      {
        CharacterDetailsView.dataProvider.GetStains();
        App.Current.Dispatcher.Invoke(() =>
              {
                // Assign the item sources for the dye combo boxes.
                equipView.MHBox.ItemsSource = CharacterDetailsView.dataProvider.Stains;
                equipView.OHBox.ItemsSource = CharacterDetailsView.dataProvider.Stains;
                equipView.HeadDye.ItemsSource = CharacterDetailsView.dataProvider.Stains;
                equipView.ChestBox.ItemsSource = CharacterDetailsView.dataProvider.Stains;
                equipView.ArmBox.ItemsSource = CharacterDetailsView.dataProvider.Stains;
                equipView.LegBox.ItemsSource = CharacterDetailsView.dataProvider.Stains;
                equipView.FeetBox.ItemsSource = CharacterDetailsView.dataProvider.Stains;
              });
      });
      Task.Run(() =>
      {
        try
        {
          var weatherList = from w in gameData.GetExcelSheet<Weather>()
                            select new ExdCsvReader.CMWeather
                            {
                              Id = (ushort)w.RowId,
                              Name = $"{w.Name.RawString.DefaultIfEmpty("None")} ({w.RowId})",
                              Icon = gameData.GetIcon(w.Icon).GetImage()
                            };

          App.Current.Dispatcher.Invoke(() =>
                {
                  worldView.ForceWeatherBox.ItemsSource = weatherList;
                });
        }
        catch (Exception ex)
        {
          MessageBox.Show("There was a problem fetching the weather list!");
        }
      });
      Task.Run(() =>
      {
        var titleSheet = gameData.GetExcelSheet<Title>().Select(title => title.Feminine.RawString.DefaultIfEmpty("None"));
        App.Current.Dispatcher.Invoke(() => characterView.TitleBox.ItemsSource = titleSheet);
      });

      sw.Stop();
      Console.WriteLine($"Lumina initialalize sheet fetching took {sw.ElapsedMilliseconds}ms");
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
          MessageBox.Show("Could not load settings!");
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
        ServicePointManager.SecurityProtocol = (ServicePointManager.SecurityProtocol & SecurityProtocolType.Ssl3) | (SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12);
        using (var wc = new WebClient())
        {
          var jsonStr = wc.DownloadString(@"https://raw.githubusercontent.com/imchillin/CMTool/master/ConceptMatrix/" + file + "?" + DateTime.Now);
          var offset = JsonConvert.DeserializeObject<Settings>(jsonStr);

          if (Settings.Instance.Version == null)
          {
            MessageBox.Show("Please update CMTool to get the latest offsets!", "Concept Matrix", MessageBoxButtons.OK);
            return false;
          }

          if (string.Compare(offset.Version, Settings.Instance.Version) > 0)
          {
            File.WriteAllText($"./{file}", jsonStr);
            Settings.Instance = offset;
            return true;
          }
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
      while (!worker.CancellationPending)
      {
        if (worker.CancellationPending)
        {
          e.Cancel = true;
          return;
        }
        // sleep for 50 ms
        Thread.Sleep(50);
        // check if our memory manager is set /saving
        if (!MainWindow.CurrentlySaving)
          mediator?.SendWork();
      }
    }

    public void ToggleStatus(bool on)
    {
      ToggleForeground = on ? new SolidColorBrush(Color.FromArgb(255, 255, 255, 255)) : new SolidColorBrush(Color.FromArgb(0x75, 0xFF, 0xFF, 0xFF));
      AOTToggleStatus = on ? PackIconKind.ToggleSwitch : PackIconKind.ToggleSwitchOffOutline;
    }
  }
}
