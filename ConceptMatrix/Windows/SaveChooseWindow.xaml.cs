using ConceptMatrix.Models;
using ConceptMatrix.Utility;
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
namespace ConceptMatrix.Windows
{
    public class CharSaves
    {
        public string Description { get; set; }
        public string DateCreated { get; set; }
        public WepTuple MainHand { get; set; }
        public WepTuple OffHand { get; set; }
        public string EquipmentBytes { get; set; }
        public string CharacterBytes { get; set; }
        public CharacterDetails characterDetails { get; set; }
    }
    /// <summary>
    /// Interaction logic for SaveChooseWindow.xaml
    /// </summary>
    public partial class SaveChooseWindow : Window
    {
        public List<CharSaves> CharSave;
        public CharSaves Choice = null;
        public SaveChooseWindow(string text)
        {
            InitializeComponent();
            CharDataGrid.ItemsSource = CharSave;
            CharSave = LoadCharSet();
            Title = text;
            foreach (var CharSaved in CharSave)
            {
                CharDataGrid.Items.Add(new CharSaves()
                {
                    Description = CharSaved.Description,
                    EquipmentBytes = CharSaved.EquipmentBytes,
                    CharacterBytes = CharSaved.CharacterBytes,
                    characterDetails = CharSaved.characterDetails,
                    DateCreated = CharSaved.DateCreated,
                    MainHand = CharSaved.MainHand,
                    OffHand = CharSaved.OffHand
                });
            }
        }
        public List<CharSaves> LoadCharSet()
        {
            List<CharSaves> output = new List<CharSaves>();

            string PathX = SaveSettings.Default.ProfileDirectory;

            if (!Directory.Exists(PathX))
            {
                MessageBox.Show("Could not find CMTool/Saves Directory: " + PathX);
                return output;
            }

            var files = Directory.GetFiles(PathX, "*.cma*").Union(Directory.GetFiles(PathX, "*.json*")).ToArray();

            foreach (var file in files)
            {
                CharSaves load = JsonConvert.DeserializeObject<CharSaves>(File.ReadAllText(file));
                output.Add(load);
            }

            return output;
        }

        private void CharDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CharDataGrid.SelectedIndex == -1)
            {
                Close();
                return;
            }

            Choice = (CharSaves)CharDataGrid.SelectedItem;
            Close();
        }

        private void CharSetSearchText_TextChanged(object sender, TextChangedEventArgs e)
        {
            string filter = CharSetSearchText.Text.ToLower();
            CharDataGrid.Items.Clear();
            foreach (CharSaves CharSaved in CharSave.Where(g => g.Description.ToLower().Contains(filter)))
                CharDataGrid.Items.Add(new CharSaves()
                {
                    Description = CharSaved.Description,
                    EquipmentBytes = CharSaved.EquipmentBytes,
                    CharacterBytes = CharSaved.CharacterBytes,
                    characterDetails = CharSaved.characterDetails,
                    DateCreated = CharSaved.DateCreated,
                    MainHand = CharSaved.MainHand,
                    OffHand = CharSaved.OffHand
                });
        }
    }
}
