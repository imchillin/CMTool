using ConceptMatrix.Utility;
using ConceptMatrix.ViewModel;
using ConceptMatrix.Windows;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace ConceptMatrix.Views
{
    /// <summary>
    /// Interaction logic for PaletteView.xaml
    /// </summary>
    public partial class PaletteView : UserControl
    {
        public PaletteView()
        {
            InitializeComponent();
            DataContext = new PaletteSelectorViewModel();
            if (SaveSettings.Default.Theme == "Dark") ThemeButton.IsChecked = true;
            if (SaveSettings.Default.HasBackground == true) BackgroundButton.IsChecked = true;
            if (SaveSettings.Default.WindowsExplorer == true) Windowstoggled.IsChecked = true;
            if (SaveSettings.Default.UnfreezeOnGp == true) ActorDataGpose.IsChecked = true;
            if (SaveSettings.Default.DebugMode == true) DebugMode.IsChecked = true;
            SaveDirectory.Text = SaveSettings.Default.ProfileDirectory;
            SaveDirectory2.Text = SaveSettings.Default.MatrixPoseDirectory;
            SaveDirectory3.Text = SaveSettings.Default.GearsetsDirectory;

            AppTransparencySlider.Maximum = 1000.0;
            AppTransparencySlider.Minimum = 200.0;
            AppTransparencySlider.Value = SaveSettings.Default.UITransparency;
        }

        private void AppTransparencyChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Application.Current.Dispatcher.InvokeAsync(async () =>
            {
                MainViewModel.MainTime.Opacity = AppTransparencySlider.Value/1000.0;
                SaveSettings.Default.UITransparency = AppTransparencySlider.Value;
            });
        }
  
        private void DirectoryButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog dig = new System.Windows.Forms.FolderBrowserDialog();
            dig.SelectedPath = SaveDirectory.Text;
            dig.Description = "Select a folder where you would want Profile Saves to be located in! Profile saves are: Appearances/Equipment.";
            dig.ShowNewFolderButton = true;
            dig.ShowDialog();
            if (dig.SelectedPath == null || dig.SelectedPath== SaveDirectory.Text) return;
            SaveSettings.Default.ProfileDirectory = dig.SelectedPath;

            var msgResult = System.Windows.MessageBox.Show($"Would you like to transfer the data in previous directory: {SaveDirectory.Text} to the newer directory: {dig.SelectedPath}", "Transfer Saves!", MessageBoxButton.YesNo);
            if (msgResult == MessageBoxResult.Yes)
            {
                foreach (var file in new DirectoryInfo(SaveDirectory.Text).GetFiles())
                {
                    file.MoveTo($@"{dig.SelectedPath}\{file.Name}");
                }
            }
            SaveDirectory.Text = dig.SelectedPath;
        }

        private void DirectoryButton2_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog dig = new System.Windows.Forms.FolderBrowserDialog();
            dig.SelectedPath = SaveDirectory2.Text;
            dig.Description = "Select a folder where you would want Concept Matrix Pose Saves to be located in!";
            dig.ShowNewFolderButton = true;
            dig.ShowDialog();
            if (dig.SelectedPath == null || dig.SelectedPath == SaveDirectory2.Text) return;
            SaveSettings.Default.MatrixPoseDirectory = dig.SelectedPath;

            var msgResult = System.Windows.MessageBox.Show($"Would you like to transfer the data in previous directory: {SaveDirectory2.Text} to the newer directory: {dig.SelectedPath}", "Transfer Saves!", MessageBoxButton.YesNo);
            if (msgResult == MessageBoxResult.Yes)
            {
                foreach (var file in new DirectoryInfo(SaveDirectory2.Text).GetFiles())
                {
                    file.MoveTo($@"{dig.SelectedPath}\{file.Name}");
                }
            }
            SaveDirectory2.Text = dig.SelectedPath;
        }

        private void DirectoryButton3_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog dig = new System.Windows.Forms.FolderBrowserDialog();
            dig.SelectedPath = SaveDirectory3.Text;
            dig.Description = "Select a folder where you would want Gearset Saves to be located in!";
            dig.ShowNewFolderButton = true;
            dig.ShowDialog();
            if (dig.SelectedPath == null || dig.SelectedPath == SaveDirectory3.Text) return;
            SaveSettings.Default.GearsetsDirectory = dig.SelectedPath;

            var msgResult = System.Windows.MessageBox.Show($"Would you like to transfer the data in previous directory: {SaveDirectory3.Text} to the newer directory: {dig.SelectedPath}", "Transfer Saves!", MessageBoxButton.YesNo);
            if (msgResult == MessageBoxResult.Yes)
            {
                foreach (var file in new DirectoryInfo(SaveDirectory3.Text).GetFiles())
                {
                    file.MoveTo($@"{dig.SelectedPath}\{file.Name}");
                }
            }
            SaveDirectory3.Text = dig.SelectedPath;
        }
        private void Windowstoggled_Checked(object sender, RoutedEventArgs e)
        {
            if (Windowstoggled.IsKeyboardFocusWithin || Windowstoggled.IsMouseOver)
            {
                SaveSettings.Default.WindowsExplorer = true;
            }
        }

        private void Windowstoggled_Unchecked(object sender, RoutedEventArgs e)
        {
            if (Windowstoggled.IsKeyboardFocusWithin || Windowstoggled.IsMouseOver)
            {
                SaveSettings.Default.WindowsExplorer = false;
            }
        }

        private void Default_Click(object sender, RoutedEventArgs e)
        {
            SaveSettings.Default.ProfileDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDoc‌​uments), App.ToolBin, "Saves");

            var msgResult = System.Windows.MessageBox.Show($"Would you like to transfer the data in previous directory: {SaveDirectory.Text} to the newer directory: {SaveSettings.Default.ProfileDirectory}", "Transfer Saves!", MessageBoxButton.YesNo);
            if (msgResult == MessageBoxResult.Yes)
            {
                foreach (var file in new DirectoryInfo(SaveDirectory.Text).GetFiles())
                {
                    file.MoveTo($@"{SaveSettings.Default.ProfileDirectory}\{file.Name}");
                }
            }

            SaveDirectory.Text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDoc‌​uments), App.ToolBin, "Saves");
        }

        private void Default2_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(SaveDirectory2.Text);
        }

        private void Default3_Click(object sender, RoutedEventArgs e)
        {
            SaveSettings.Default.GearsetsDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDoc‌​uments), App.ToolBin, "Gearsets");

            var msgResult = System.Windows.MessageBox.Show($"Would you like to transfer the data in previous directory: {SaveDirectory3.Text} to the newer directory: {SaveSettings.Default.GearsetsDirectory}", "Transfer Saves!", MessageBoxButton.YesNo);
            if (msgResult == MessageBoxResult.Yes)
            {
                foreach (var file in new DirectoryInfo(SaveDirectory3.Text).GetFiles())
                {
                    file.MoveTo($@"{SaveSettings.Default.GearsetsDirectory}\{file.Name}");
                }
            }

            SaveDirectory3.Text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDoc‌​uments), App.ToolBin, "Gearsets");
        }

        private void ChangeLang_Click(object sender, RoutedEventArgs e)
        {
            var langSelectView = new LanguageSelectView();
            langSelectView.ShowDialog();
            var langCode = langSelectView.LanguageCode;

            if (string.IsNullOrEmpty(langCode)) return;

            SaveSettings.Default.Language = langCode;

            System.Windows.Forms.Application.Restart();
            System.Windows.Application.Current.Shutdown();
        }

        private void ActorDataGpose_Checked(object sender, RoutedEventArgs e)
        {
            SaveSettings.Default.UnfreezeOnGp = true;
        }

        private void ActorDataGpose_Unchecked(object sender, RoutedEventArgs e)
        {
            SaveSettings.Default.UnfreezeOnGp = false;
        }

        private void DebugMode_Checked(object sender, RoutedEventArgs e)
        {
            if (DebugMode.IsKeyboardFocusWithin || DebugMode.IsMouseOver)
            {
                SaveSettings.Default.DebugMode = true;
                System.Windows.Forms.Application.Restart();
                System.Windows.Application.Current.Shutdown();
            }
        }

        private void DebugMode_Unchecked(object sender, RoutedEventArgs e)
        {
            if (DebugMode.IsKeyboardFocusWithin || DebugMode.IsMouseOver)
            {
                SaveSettings.Default.DebugMode = false;
                System.Windows.Forms.Application.Restart();
                System.Windows.Application.Current.Shutdown();
            }
        }
    }
}
