using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FFXIVTool.Windows
{
    /// <summary>
    /// Interaction logic for GearSave.xaml
    /// </summary>
    public partial class GearSave : Window
    {
        public string Filename;
        public GearSave(string newtitle, string newwatermark)
        {
            InitializeComponent();
            this.Title = newtitle;
            RunText.Text = newwatermark;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Filename = FilenameText.Text;
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
