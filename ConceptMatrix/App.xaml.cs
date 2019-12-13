using ConceptMatrix.Models;
using ConceptMatrix.ViewModel;
using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Threading;
namespace ConceptMatrix
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
		public static readonly string ToolName = "Concept Matrix";
		public static readonly string ToolBin = "CMTool";
		public static readonly string UpdaterName = "Concept Matrix Updater";
		public static readonly string UpdaterBin = "ConceptMatrixUpdater";
		public static readonly string GithubRepo = "imchillin/CMTool";
		public static readonly string TwitterHandle = "ffxivsstool";
		public static readonly string DiscordCode = "hq3DnBa";

		public CharacterDetails CharacterDetails { get => (CharacterDetails)BaseViewModel.model; set => BaseViewModel.model = value; }
        protected override void OnStartup(StartupEventArgs e)
        {
            Application.Current.DispatcherUnhandledException += Application_DispatcherUnhandledException;
            GetDotNetFromRegistry();
            if (ConceptMatrix.Properties.Settings.Default.UpgradeRequired)
            {
                ConceptMatrix.Properties.Settings.Default.Upgrade();
                ConceptMatrix.Properties.Settings.Default.UpgradeRequired = false;
                ConceptMatrix.Properties.Settings.Default.Save();
            }
            base.OnStartup(e);

            this.Exit += App_Exit;
        }

        private static void GetDotNetFromRegistry()
        {
            const string subkey = @"SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full\";

            using (var ndpKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32).OpenSubKey(subkey))
            {
                if (ndpKey != null && ndpKey.GetValue("Release") != null)
                {
                    if ((int)ndpKey.GetValue("Release") <= 394801)
                    {
                        var msgResult = System.Windows.MessageBox.Show(".NET Framework Version 4.6.2 or later is not detected. Please install", ".Net Framework not installed", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.Yes);
                        if (msgResult == MessageBoxResult.Yes)
                        {

                            Process.Start("https://dotnet.microsoft.com/download/dotnet-framework/net472");
                            Application.Current.Shutdown();
                        }
                    }
                }
                else
                {
                    var msgResult = System.Windows.MessageBox.Show(".NET Framework Version 4.6.2 or later is not detected. Please install", ".Net Framework not installed", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.Yes);
                    if (msgResult == MessageBoxResult.Yes)
                    {

                        Process.Start("https://dotnet.microsoft.com/download/dotnet-framework/net472");
                        Application.Current.Shutdown();
                    }
                }
            }
        }
        private void Application_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            if (e.Exception != null)
            {
                using (StreamWriter writer = new StreamWriter("ErrorLog.txt", true))
                {
                    writer.WriteLine("-----------Start-----------" + DateTime.Now);
                    writer.WriteLine("Error Message: " + e.Exception.Message);
                    writer.WriteLine("Stack Trace: " + e.Exception.StackTrace);
                    if (e.Exception.InnerException != null)
                    {
                        writer.WriteLine("-----------Inner Exception-----------" + DateTime.Now);
                        writer.WriteLine("Inner Exception Message: " + e.Exception.InnerException.Message);
                        writer.WriteLine("Inner Exception Message: " + e.Exception.InnerException.StackTrace);
                    }
                    writer.WriteLine("-----------End-----------" + DateTime.Now);
                }
            }
            e.Handled = true;
        }

        public static bool IsValidGamePath(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
                return false;

            if (!Directory.Exists(path))
                return false;

            if (File.Exists(Path.Combine(path, "game", "ffxivgame.ver")))
                return File.Exists(Path.Combine(path, "game", "ffxivgame.ver"));

            return false;
        }

        private void App_Exit(object sender, ExitEventArgs e)
        {
            Utility.SaveSettings.Default.Save();
            if (CharacterDetails.BoneEditMode) MainViewModel.ViewTime5.EditModeButton.IsChecked = false;
        }
    }
}
