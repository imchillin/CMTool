using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;

namespace SSToolsUpdater
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
    }
}
