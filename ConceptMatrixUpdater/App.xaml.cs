using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;

namespace ConceptMatrixUpdater
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        string exepath = Directory.GetParent(Assembly.GetExecutingAssembly().Location).FullName;
        public static bool OpeningXIV;
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            MainWindow mwd = new MainWindow();
            for (int i = 0, arlen = e.Args.Length; i < arlen; i++)
            {
                string temp = e.Args[i];
                if (temp.Contains("-skipLang"))
                    mwd.downloadLang = false;
                else if (temp.Equals("-autolaunch"))
                    mwd.autoLaunchXIV = true;
            }

            mwd.Show();
        }
        public App()
        {
            //Console.WriteLine(CultureInfo.CurrentCulture);
            this.Exit += (s, e) =>
            {

                string version = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).FileVersion;
                if (!OpeningXIV && File.Exists(exepath + "\\Update Files\\ConceptMatrixUpdater.exe")
                    && FileVersionInfo.GetVersionInfo(exepath + "\\Update Files\\ConceptMatrixUpdater.exe").FileVersion.CompareTo(version) != 0)
                {
                    File.Move(exepath + "\\Update Files\\ConceptMatrixUpdater.exe", exepath + "\\ConceptMatrixUpdater NEW.exe");
                    Directory.Delete(exepath + "\\Update Files", true);
                    StreamWriter w = new StreamWriter(exepath + "\\UpdateReplacer.bat");
                    w.WriteLine("@echo off"); // Turn off echo
                    w.WriteLine("@echo Attempting to replace updater, please wait...");
                    w.WriteLine("@ping -n 4 127.0.0.1 > nul"); //Its silly but its the most compatible way to call for a timeout in a batch file, used to give the main updater time to cleanup and exit.
                    w.WriteLine("@del \"" + exepath + "\\ConceptMatrixUpdater.exe" + "\"");
                    w.WriteLine("@ren \"" + exepath + "\\ConceptMatrixUpdater NEW.exe" + "\" \"ConceptMatrixUpdater.exe\"");
                    w.WriteLine("@start " + exepath + "\\ConceptMatrixUpdater.exe"); // Attempt to delete myself without opening a time paradox.
                    w.WriteLine("@DEL \"%~f0\"&exit /b"); // Attempt to delete myself without opening a time paradox.
                    w.Close();

                    Process.Start(exepath + "\\UpdateReplacer.bat");
                }
                else if (File.Exists(exepath + "\\ConceptMatrixUpdater NEW.exe"))
                    File.Delete(exepath + "\\ConceptMatrixUpdater NEW.exe");
                if (Directory.Exists(exepath + "\\Update Files"))
                    Directory.Delete(exepath + "\\Update Files", true);
                if (Directory.Exists(exepath + "\\Updates"))
                    Directory.Delete(exepath + "\\Updates", true);
            };
        }
    }
}
