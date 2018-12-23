using FFXIVTool.ViewModel;
using MaterialDesignColors;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FFXIVTool.Views
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
            if (Properties.Settings.Default.Theme == "Dark") ThemeButton.IsChecked = true;
        }
    }
}
