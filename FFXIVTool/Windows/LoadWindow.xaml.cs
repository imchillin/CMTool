using FFXIVTool.Utility;
using System.Windows;

namespace FFXIVTool.Windows
{
    /// <summary>
    /// Interaction logic for LoadWindow.xaml
    /// </summary>
    public partial class LoadWindow : Window
    {
        public string Choice = "";
        public LoadWindow()
        {
            InitializeComponent();
            if (SaveSettings.Default.WindowsExplorer == true) Windowstoggled.IsChecked = true;
        }

        private void All_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key != System.Windows.Input.Key.Enter) return;
            e.Handled = true;
            Choice = All.Name;
            Close();
        }

        private void App_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key != System.Windows.Input.Key.Enter) return;
            e.Handled = true;
            Choice = App.Name;
            Close();
        }

        private void Xuip_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key != System.Windows.Input.Key.Enter) return;
            e.Handled = true;
            Choice = Xuip.Name;
            Close();
        }

        private void All_PreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Choice = All.Name;
            Close();
        }

        private void App_PreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Choice = App.Name;
            Close();
        }

        private void Xuip_PreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Choice = Xuip.Name;
            Close();
        }

        private void Dat_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key != System.Windows.Input.Key.Enter) return;
            e.Handled = true;
            Choice = Dat.Name;
            Close();
        }

        private void Dat_PreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Choice = Dat.Name;
            Close();
        }

        private void Gearset_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key != System.Windows.Input.Key.Enter) return;
            e.Handled = true;
            Choice = Gearset.Name;
            Close();
        }

        private void Gearset_PreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Choice = Gearset.Name;
            Close();
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
    }
}
