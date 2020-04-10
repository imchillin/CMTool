using ConceptMatrix.Models;
using ConceptMatrix.Utility;
using ConceptMatrix.ViewModel;
using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Threading;
using Application = System.Windows.Application;
using Clipboard = System.Windows.Clipboard;
namespace ConceptMatrix
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
		public static readonly string ToolName = "ConceptMatrix";
		public static readonly string ToolBin = "CMTool";
		public static readonly string UpdaterName = "Concept Matrix Updater";
		public static readonly string UpdaterBin = "ConceptMatrixUpdater";
		public static readonly string GithubRepo = "imchillin/CMTool";
		public static readonly string TwitterHandle = "ffxivsstool";
		public static readonly string DiscordCode = "hq3DnBa";

		public CharacterDetails CharacterDetails { get => (CharacterDetails)BaseViewModel.model; set => BaseViewModel.model = value; }
        protected override void OnStartup(StartupEventArgs e)
        {
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            Dispatcher.UnhandledException += DispatcherOnUnhandledException;

            Application.Current.DispatcherUnhandledException += CurrentOnDispatcherUnhandledException;

            TaskScheduler.UnobservedTaskException += TaskSchedulerOnUnobservedTaskException;

            GetDotNetFromRegistry();
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
            if (MainViewModel.ViewTime5.EditModeButton.IsChecked == true) MainViewModel.ViewTime5.EditModeButton.IsChecked = false;
        }

        private void TaskSchedulerOnUnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs e)
        {
            var ver = FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).FileVersion;

            const string lineBreak = "\n======================================================\n";

            var errorText = "Concept Matirx ran into an error.\n\n" +
                            "Please submit a bug report with the following information.\n " +
                            lineBreak +
                            e.Exception +
                            lineBreak + "\n" +
                            "Copy to clipboard?";

            if (FlexibleMessageBox.Show(errorText, "Crash Report " + ver, MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
            {
                Clipboard.SetText(e.Exception.ToString());
            }
        }

        private void CurrentOnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            var ver = FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).FileVersion;

            const string lineBreak = "\n======================================================\n";

            var errorText = "Concept Matirx ran into an error.\n\n" +
                            "Please submit a bug report with the following information.\n " +
                            lineBreak +
                            e.Exception +
                            lineBreak + "\n" +
                            "Copy to clipboard?";

            if (FlexibleMessageBox.Show(errorText, "Crash Report " + ver, MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
            {
                Clipboard.SetText(e.Exception.ToString());
            }
        }

        private void DispatcherOnUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            var ver = FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).FileVersion;

            const string lineBreak = "\n======================================================\n";

            var errorText = "Concept Matirx ran into an error.\n\n" +
                            "Please submit a bug report with the following information.\n " +
                            lineBreak +
                            e.Exception +
                            lineBreak + "\n" +
                            "Copy to clipboard?";

            if (FlexibleMessageBox.Show(errorText, "Crash Report " + ver, MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
            {
                Clipboard.SetText(e.Exception.ToString());
            }
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            var ver = FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).FileVersion;

            const string lineBreak = "\n======================================================\n";

            var errorText = "Concept Matirx ran into an error.\n\n" +
                            "Please submit a bug report with the following information.\n " +
                            lineBreak +
                            e.ExceptionObject +
                            lineBreak + "\n" +
                            "Copy to clipboard?";

            if (FlexibleMessageBox.Show(errorText, "Crash Report " + ver, MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
            {
                Clipboard.SetText(e.ExceptionObject.ToString());
            }
        }
    }
}
