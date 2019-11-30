using ConceptMatrix.Utility;
using ConceptMatrix.ViewModel;
using System.Windows.Controls;

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
        }
    }
}
