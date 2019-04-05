using Ookii.Dialogs.Wpf;
using System;
using System.ComponentModel;
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
            if (!RequestGamePath())
            {
                MainWindow = null;
                Shutdown(1);
                return;
            }
            base.OnStartup(e);

            this.Exit += App_Exit;
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
            }

            VistaFolderBrowserDialog dlg = null;

            while (!IsValidGamePath(path))
            {
                var result = (dlg ?? (dlg = new VistaFolderBrowserDialog
                {
                    Description = "Please select the directory of your FFXIV:ARR game installation (should contain 'boot' and 'game' directories).",
                    ShowNewFolderButton = false,
                })).ShowDialog();

                if (!result.GetValueOrDefault(false))
                {
                    var msgResult = System.Windows.MessageBox.Show("Cannot continue without a valid game installation, quit the program?", "That's no good", MessageBoxButton.YesNo, MessageBoxImage.Error, MessageBoxResult.No);
                    if (msgResult == MessageBoxResult.Yes)
                        return false;
                }

                path = dlg.SelectedPath;
            }

            FFXIVTool.Properties.Settings.Default.GamePath = path;
            FFXIVTool.Properties.Settings.Default.Save();
            return true;
        }
    }
}
