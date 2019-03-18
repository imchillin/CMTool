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
using WepTuple = System.Tuple<int, int, int, int>;
namespace FFXIVTool.Windows
{
    /// <summary>
    /// Interaction logic for GearsetChooseWindow.xaml
    /// </summary>
    /// 
    public class GearSaves
    {
        public WepTuple MainHand { get; set; }
        public WepTuple OffHand { get; set; }
        public string EquipmentBytes { get; set; }
        public string Description { get; set; }
        public string DateCreated { get; set; }
    }
    public partial class GearsetChooseWindow : Window
    {

        public List<GearSaves> GearSave;
        public GearSaves Choice = null;
        public GearsetChooseWindow(string text)
        {
            InitializeComponent();
            GearDataGrid.ItemsSource = GearSave;
            GearSave = LoadeGearset();

            foreach (var GearSaves in GearSave)
            {
                GearDataGrid.Items.Add(new GearSaves()
                {
                    Description = GearSaves.Description,
                    EquipmentBytes = GearSaves.EquipmentBytes,
                    DateCreated = GearSaves.DateCreated,
                    MainHand = GearSaves.MainHand,
                    OffHand = GearSaves.OffHand
                });
            }
        }
        public List<GearSaves> LoadeGearset()
        {
            List<GearSaves> output = new List<GearSaves>();

            string PathX = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "SSTool", "Gearsets");

            if (!Directory.Exists(PathX))
                throw new Exception("Could not find any gearset saves in:" + PathX);

            var files = Directory.GetFiles(PathX, "*.json*");

            foreach (var file in files)
            {
                GearSaves load = JsonConvert.DeserializeObject<GearSaves>(File.ReadAllText(file));
                output.Add(load);
            }

            return output;
        }

        private void GearDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (GearDataGrid.SelectedIndex == -1)
            {
                Close();
                return;
            }

            Choice = GearSave[GearDataGrid.SelectedIndex];
            Close();
        }

        private void GearSetSearchText_TextChanged(object sender, TextChangedEventArgs e)
        {
            string filter = GearSetSearchText.Text.ToLower();
            GearDataGrid.Items.Clear();
            foreach (GearSaves Save in GearSave.Where(g => g.Description.ToLower().Contains(filter)))
                GearDataGrid.Items.Add(new GearSaves()
                {
                    Description = Save.Description,
                    EquipmentBytes = Save.EquipmentBytes,
                    DateCreated = Save.DateCreated,
                    MainHand = Save.MainHand,
                    OffHand = Save.OffHand
                });
        }
    }
}
