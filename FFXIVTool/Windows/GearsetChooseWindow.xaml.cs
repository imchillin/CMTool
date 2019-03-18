using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for GearsetChooseWindow.xaml
    /// </summary>
    public partial class GearsetChooseWindow : Window
    {
        private List<Views.CharacterDetailsView2.GearSaves> GearSave;
        public Views.CharacterDetailsView2.GearSaves Choice = null;
        public GearsetChooseWindow(string text)
        {
            InitializeComponent();
            GearSave = LoadeGearset();

            foreach (var GearSaves in GearSave)
            {
                GearListBox.Items.Add($"{GearSaves.Description} - Date Created: {GearSaves.DateCreated}");
            }
        }
        public List<Views.CharacterDetailsView2.GearSaves> LoadeGearset()
        {
            List<Views.CharacterDetailsView2.GearSaves> output = new List<Views.CharacterDetailsView2.GearSaves>();

            string PathX = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "SSTool", "Gearsets");

            if (!Directory.Exists(PathX))
                throw new Exception("Could not find any gearset saves in:" + PathX);

            var files = Directory.GetFiles(PathX, "*.json*");

            foreach (var file in files)
            {
                Views.CharacterDetailsView2.GearSaves load = JsonConvert.DeserializeObject<Views.CharacterDetailsView2.GearSaves>(File.ReadAllText(file));
                output.Add(load);
            }

            return output;
        }

        private void GearListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (GearListBox.SelectedIndex == -1)
            {
                Close();
                return;
            }

            Choice = GearSave[GearListBox.SelectedIndex];
            Close();
        }
    }
}
