using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace ConceptMatrix.Windows
{
    /// <summary>
    /// Interaction logic for ProcessLooker.xaml
    /// </summary>
    public partial class ProcessLooker : Window
    {
        public class Game
        {
            public string ProcessName { get; set; }
            public int ID { get; set; }
            public DateTime StartTime { get; set; }
            public ImageSource AppIcon { get; set; }
            public string GameDirectory { get; set; }
        }
        public Game Choice = null;
        public ProcessLooker(List<Game> GameList)
        {
            InitializeComponent();

            ProcessGrid.ItemsSource = GameList;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (ProcessGrid.SelectedItem == null)
                Close();
            Choice = ProcessGrid.SelectedItem as Game;
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            List<Game> GameListX = new List<Game>();
            Process[] processlist = Process.GetProcesses();
            foreach (Process theprocess in processlist)
            {
                if (theprocess.ProcessName.ToLower().Contains("ffxiv_dx11"))
                {
                    GameListX.Add(new ProcessLooker.Game()
                    {
                        ProcessName = theprocess.ProcessName,
                        ID = theprocess.Id,
                        StartTime = theprocess.StartTime,
                        AppIcon = MainWindow.IconToImageSource(System.Drawing.Icon.ExtractAssociatedIcon(theprocess.MainModule.FileName)),
                        GameDirectory = Path.GetFullPath(Path.Combine(theprocess.MainModule.FileName, "..", "..")).ToString()
                    });
                }
            }
            ProcessGrid.ItemsSource = GameListX;
        }

        private void ProcessGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (ProcessGrid.SelectedCells.Count > 0)
            {
                if (ProcessGrid.SelectedItem == null)
                    Close();
                Choice = ProcessGrid.SelectedItem as Game;
                Close();
            }
        }
    }
}