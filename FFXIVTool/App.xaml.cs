using Microsoft.Win32;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Threading;
namespace FFXIVTool
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            Application.Current.DispatcherUnhandledException += Application_DispatcherUnhandledException;
            GetDotNetFromRegistry();
            if (FFXIVTool.Properties.Settings.Default.UpgradeRequired)
            {
                FFXIVTool.Properties.Settings.Default.Upgrade();
                FFXIVTool.Properties.Settings.Default.UpgradeRequired = false;
                FFXIVTool.Properties.Settings.Default.Save();
            }
            if (!RequestGamePath())
            {
                MainWindow = null;
                Shutdown(1);
                return;
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

            return File.Exists(Path.Combine(path, "game", "ffxivgame.ver"));
        }
        private void App_Exit(object sender, ExitEventArgs e)
        {
            Utility.SaveSettings.Default.Save();
        }
        private static bool RequestGamePath()
        {
            string path = FFXIVTool.Properties.Settings.Default.GamePath;
            if (!IsValidGamePath(path))
            {
                string programDir;
                if (Environment.Is64BitProcess)
                    programDir = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86);
                else
                    programDir = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);

                path = System.IO.Path.Combine(programDir, "SquareEnix", "FINAL FANTASY XIV - A Realm Reborn");

                if (IsValidGamePath(path))
                {
                    var msgResult = System.Windows.MessageBox.Show(string.Format("Found game installation at \"{0}\". Is this correct?", path), "Confirm game installation", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.Yes);
                    if (msgResult == MessageBoxResult.Yes)
                    {
                        FFXIVTool.Properties.Settings.Default.GamePath = path;
                        FFXIVTool.Properties.Settings.Default.Save();

                        return true;
                    }

                    path = null;
                }
                else
                {
                    path = System.IO.Path.Combine(programDir, "Steam", "steamapps", "common", "FINAL FANTASY XIV Online");
                    if (IsValidGamePath(path))
                    {
                        var msgResult = System.Windows.MessageBox.Show(string.Format("Found game installation at \"{0}\". Is this correct?", path), "Confirm game installation", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.Yes);
                        if (msgResult == MessageBoxResult.Yes)
                        {
                            FFXIVTool.Properties.Settings.Default.GamePath = path;
                            FFXIVTool.Properties.Settings.Default.Save();

                            return true;
                        }
                        path = null;
                    }
                    else
                    {
                        path = System.IO.Path.Combine(programDir, "Steam", "steamapps", "common", "FINAL FANTASY XIV - A Realm Reborn");
                        if (IsValidGamePath(path))
                        {
                            var msgResult = System.Windows.MessageBox.Show(string.Format("Found game installation at \"{0}\". Is this correct?", path), "Confirm game installation", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.Yes);
                            if (msgResult == MessageBoxResult.Yes)
                            {
                                FFXIVTool.Properties.Settings.Default.GamePath = path;
                                FFXIVTool.Properties.Settings.Default.Save();

                                return true;
                            }
                            path = null;
                        }
                    }
                }

            }

            System.Windows.Forms.FolderBrowserDialog dig = null;
            while (!IsValidGamePath(path))
            {
                var result = (dig ?? (dig = new System.Windows.Forms.FolderBrowserDialog
                {
                    Description = "Please select the directory of your FFXIV:ARR game installation (should contain 'boot' and 'game' directories).",
                    ShowNewFolderButton = false,
                })).ShowDialog();

                if (result!=System.Windows.Forms.DialogResult.OK&&result!=System.Windows.Forms.DialogResult.Yes)
                {
                    var msgResult = System.Windows.MessageBox.Show("Cannot continue without a valid game installation, quit the program?", "That's no good", MessageBoxButton.YesNo, MessageBoxImage.Error, MessageBoxResult.No);
                    if (msgResult == MessageBoxResult.Yes)
                        return false;
                }
                path = dig.SelectedPath;
            }

            FFXIVTool.Properties.Settings.Default.GamePath = path;
            FFXIVTool.Properties.Settings.Default.Save();
            return true;
        }
    }
}
