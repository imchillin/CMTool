using MahApps.Metro.Controls;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Shell;

namespace SSToolsUpdater
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        WebClient wc = new WebClient(), subwc = new WebClient();
        protected string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\FFXIVTool";
        string exepath = Directory.GetParent(Assembly.GetExecutingAssembly().Location).FullName;
        string version = "0", newversion = "0";
        bool downloading = false;
        private int round = 1;
        public bool downloadLang = false;
        private bool backup;
        private string outputUpdatePath = "";
        private string updatesFolder = "";
        public bool autoLaunchXIV = false;
        [DllImport("Shell32.dll")]
        private static extern int SHGetKnownFolderPath(
        [MarshalAs(UnmanagedType.LPStruct)]Guid rfid, uint dwFlags, IntPtr hToken,
        out IntPtr ppszPath);
        public MainWindow()
        {
            InitializeComponent();

            ServicePointManager.SecurityProtocol = (ServicePointManager.SecurityProtocol & SecurityProtocolType.Ssl3) | (SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12);
            if (File.Exists(exepath + "\\FFXIVTool.exe"))
                version = FileVersionInfo.GetVersionInfo(exepath + "\\FFXIVTool.exe").FileVersion;

            if (AdminNeeded())
                label1.Content = "Please re-run with admin rights";
            else
            {
                try
                {
                    string[] files = Directory.GetFiles(exepath);

                    for (int i = 0, arlen = files.Length; i < arlen; i++)
                    {
                        string tempFile = Path.GetFileName(files[i]);
                        if ("FFXIVTool.zip" == tempFile)
                        {
                            File.Delete(files[i]);
                        }
                    }

                    if (Directory.Exists(exepath + "\\Update Files"))
                        Directory.Delete(exepath + "\\Update Files", true);

                    if (!Directory.Exists(Path.Combine(exepath, "Updates")))
                        Directory.CreateDirectory(Path.Combine(exepath, "Updates"));

                    updatesFolder = Path.Combine(exepath, "Updates");
                }
                catch (IOException) { label1.Content = "Cannot save download at this time"; return; }

                if (File.Exists(exepath + "\\Profiles.xml"))
                    path = exepath;

                if (File.Exists(path + "\\version.txt"))
                {
                    newversion = File.ReadAllText(path + "\\version.txt");
                    newversion = newversion.Trim();
                }
                else if (File.Exists(exepath + "\\version.txt"))
                {
                    newversion = File.ReadAllText(exepath + "\\version.txt");
                    newversion = newversion.Trim();
                }
                else
                {
                    Uri urlv = new Uri("https://raw.githubusercontent.com/imchillin/SSTool/master/version.txt");
                    WebClient wc2 = new WebClient();
                    downloading = true;
                    subwc.DownloadFileAsync(urlv, exepath + "\\version.txt");
                    subwc.DownloadFileCompleted += subwc_DownloadFileCompleted;
                    label1.Content = "Getting Update info";
                }

                if (!downloading && version.Replace(',', '.').CompareTo(newversion) != 0)
                {
                    Uri url = new Uri($"https://github.com/imchillin/SSTool/releases/download/{newversion}/FFXIVTool.zip");
                    sw.Start();
                    outputUpdatePath = Path.Combine(updatesFolder, $"FFXIVTool.zip");
                    try { wc.DownloadFileAsync(url, outputUpdatePath); }
                    catch (Exception e) { label1.Content = e.Message; }
                    wc.DownloadFileCompleted += wc_DownloadFileCompleted;
                    wc.DownloadProgressChanged += wc_DownloadProgressChanged;
                }
                else if (!downloading)
                {
                    label1.Content = "FFXIVTool is up to date";
                    try
                    {
                        File.Delete(path + "\\version.txt");
                        File.Delete(exepath + "\\version.txt");
                    }
                    catch { }
                    OpenXIVBTN.IsEnabled = true;
                }
            }
        }
        public bool AdminNeeded()
        {
            try
            {
                File.WriteAllText(exepath + "\\test.txt", "test");
                File.Delete(exepath + "\\test.txt");
                return false;
            }
            catch (UnauthorizedAccessException)
            {
                return true;
            }
        }
        void subwc_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            newversion = File.ReadAllText(exepath + "\\version.txt");
            newversion = newversion.Trim();
            File.Delete(exepath + "\\version.txt");
            if (version.Replace(',', '.').CompareTo(newversion) != 0)
            {
                Uri url = new Uri($"https://github.com/imchillin/SSTool/releases/download/{newversion}/FFXIVTool.zip");
                sw.Start();
                outputUpdatePath = Path.Combine(updatesFolder, $"FFXIVTool.zip");
                try { wc.DownloadFileAsync(url, outputUpdatePath); }
                catch (Exception ec) { label1.Content = ec.Message; }
                wc.DownloadFileCompleted += wc_DownloadFileCompleted;
                wc.DownloadProgressChanged += wc_DownloadProgressChanged;
            }
            else
            {
                label1.Content = "FFXIVTool is up to date";
                try
                {
                    File.Delete(path + "\\version.txt");
                    File.Delete(exepath + "\\version.txt");
                    Directory.Delete(exepath + "\\Updates", true);
                }
                catch { }

                if (autoLaunchXIV)
                {
                    label1.Content = "Launching FFXIVTool soon";
                    OpenXIVBTN.IsEnabled = false;
                    Task.Delay(7500).ContinueWith((t) =>
                    {
                        AutoOpenXIV();
                    });
                }
                else
                {
                    OpenXIVBTN.IsEnabled = true;
                }
            }
        }

        private bool IsAdministrator()
        {
            var identity = WindowsIdentity.GetCurrent();
            var principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }

        Stopwatch sw = new Stopwatch();
        private void wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            label2.Opacity = 1;
            double speed = e.BytesReceived / sw.Elapsed.TotalSeconds;
            double timeleft = (e.TotalBytesToReceive - e.BytesReceived) / speed;
            if (timeleft > 3660)
                label2.Content = (int)timeleft / 3600 + "h left";
            else if (timeleft > 90)
                label2.Content = (int)timeleft / 60 + "m left";
            else
                label2.Content = (int)timeleft + "s left";

            UpdaterBar.Value = e.ProgressPercentage;
            TaskbarItemInfo.ProgressValue = UpdaterBar.Value / 106d;
            string convertedrev, convertedtotal;
            if (e.BytesReceived > 1024 * 1024 * 5) convertedrev = (int)(e.BytesReceived / 1024d / 1024d) + "MB";
            else convertedrev = (int)(e.BytesReceived / 1024d) + "kB";

            if (e.TotalBytesToReceive > 1024 * 1024 * 5) convertedtotal = (int)(e.TotalBytesToReceive / 1024d / 1024d) + "MB";
            else convertedtotal = (int)(e.TotalBytesToReceive / 1024d) + "kB";

            if (round == 1) label1.Content = "Downloading update: " + convertedrev + " / " + convertedtotal;
            else label1.Content = "Downloading Laugauge Pack: " + convertedrev + " / " + convertedtotal;
        }

        private void wc_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            sw.Reset();
            string lang = CultureInfo.CurrentCulture.ToString();

            if (new FileInfo(outputUpdatePath).Length > 0)
            {
                Process[] processes = Process.GetProcessesByName("FFXIVTool");
                label1.Content = "Download Complete";
                if (processes.Length > 0)
                {
                    if (MessageBox.Show("It will be closed to continue this update.", "FFXIVTool is still running", MessageBoxButton.OKCancel, MessageBoxImage.Exclamation) == MessageBoxResult.OK)
                    {
                        label1.Content = "Deleting old files";
                        foreach (Process p in processes)
                            p.Kill();
                        System.Threading.Thread.Sleep(5000);
                    }
                    else
                    {
                        this.Close();
                        return;
                    }
                }

                while (processes.Length > 0)
                {
                    label1.Content = "Waiting for FFXIVTool to close";
                    processes = Process.GetProcessesByName("FFXIVTool");
                    System.Threading.Thread.Sleep(10);
                }

                label2.Opacity = 0;
                label1.Content = "Deleting old files";
                UpdaterBar.Value = 102;
                TaskbarItemInfo.ProgressValue = UpdaterBar.Value / 106d;
                try
                {
                    File.Delete(exepath + "\\FFXIVTool.exe");
                    File.Delete(exepath + "\\ex.json");
                    File.Delete(exepath + "\\exview.json");
                    File.Delete(exepath + "\\LICENSE.txt");
                    File.Delete(exepath + "\\README.txt");
                    File.Delete(exepath + "\\OffsetSettings.xml");
                    Directory.Delete(exepath + "\\Definitions", true);
                    Directory.Delete(exepath + "\\Update Files", true);
                }
                catch { }

                label1.Content = "Installing new files";
                UpdaterBar.Value = 104;
                TaskbarItemInfo.ProgressValue = UpdaterBar.Value / 106d;

                try
                {
                    Directory.CreateDirectory(exepath + "\\Update Files");
                    ZipFile.ExtractToDirectory(outputUpdatePath, exepath + "\\Update Files");
                }
                catch (IOException) { }

                try
                {
                    File.Delete(exepath + "\\version.txt");
                    File.Delete(path + "\\version.txt");
                }
                catch { }

                string[] files = Directory.GetFiles(exepath + "\\Update Files");
                string version = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).FileVersion;
                if (File.Exists(exepath + "\\Update Files\\SSToolsUpdater.exe")
                    && FileVersionInfo.GetVersionInfo(exepath + "\\Update Files\\SSToolsUpdater.exe").FileVersion.CompareTo(version) != 0)
                {
                    App.Current.Shutdown();
                    return;
                }
   
                for (int i = files.Length - 1; i >= 0; i--)
                {
                    if (Path.GetFileNameWithoutExtension(files[i]) != "SSToolsUpdater")
                    {
                        string tempDestPath = $"{exepath}\\{Path.GetFileName(files[i])}";
                        if (File.Exists(tempDestPath))
                        {
                            File.Delete(tempDestPath);
                        }

                        File.Move(files[i], tempDestPath);
                    }
                }
                Directory.Move(exepath + "\\Update Files\\Definitions", exepath + "\\Definitions");

                string sstoolwinversion = FileVersionInfo.GetVersionInfo(exepath + "\\FFXIVTool.exe").FileVersion;
                if ((File.Exists(exepath + "\\FFXIVTool.exe")) &&
                    sstoolwinversion == newversion.Trim())
                {
                    label1.Content = $"FFXIVTool has been updated to v{newversion}";
                   // Directory.Delete(exepath + "\\Update Files", true);
                   // Directory.Delete(exepath + "\\Updates", true);
                }
                else if (File.Exists(exepath + "\\FFXIVTool.exe"))
                {
                    label1.Content = "Could not replace FFXIVTool, please manually unzip";
                }
                else
                    label1.Content = "Could not unpack zip, please manually unzip";

                UpdaterBar.Value = 106;
                TaskbarItemInfo.ProgressState = TaskbarItemProgressState.None;

                if (autoLaunchXIV)
                {
                    label1.Content = "Launching FFXIVTool soon";
                    OpenXIVBTN.IsEnabled = false;
                    Task.Delay(7500).ContinueWith((t) =>
                    {
                        AutoOpenXIV();
                    });
                }
                else
                {
                    OpenXIVBTN.IsEnabled = true;
                }
            }
            else if (!backup)
            {
                Uri url = new Uri($"https://github.com/imchillin/SSTool/releases/download/{newversion}/FFXIVTool.zip");

                sw.Start();
                outputUpdatePath = Path.Combine(updatesFolder, $"FFXIVTool.zip");
                try { wc.DownloadFileAsync(url, outputUpdatePath); }
                catch (Exception ex) { label1.Content = ex.Message; }
                backup = true;
            }
            else
            {
                label1.Content = "Could not download update";
                try
                {
                    File.Delete(exepath + "\\version.txt");
                    File.Delete(path + "\\version.txt");
                }
                catch { }
                OpenXIVBTN.IsEnabled = true;
            }
        }

        private void DiscordBTN_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("https://discord.gg/hq3DnBa");
        }

        private void GithubBTN_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("https://github.com/imchillin/SSTool");
        }

        private void OpenXIVBTN_Click(object sender, RoutedEventArgs e)
        {
            if (File.Exists(exepath + "\\FFXIVTool.exe"))
                Process.Start(exepath + "\\FFXIVTool.exe");
            else
                Process.Start(exepath);

            App.OpeningXIV = true;
            this.Close();
        }

        private void AutoOpenXIV()
        {
            if (File.Exists(exepath + "\\FFXIVTool.exe"))
                Process.Start(exepath + "\\FFXIVTool.exe");
            else
                Process.Start(exepath);

            App.OpeningXIV = true;
            Dispatcher.BeginInvoke((Action)(() =>
            {
                this.Close();
            }));
        }
    }
}
