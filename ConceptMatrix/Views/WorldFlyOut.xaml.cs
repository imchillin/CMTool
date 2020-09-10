using ConceptMatrix.Models;
using ConceptMatrix.Utility;
using ConceptMatrix.ViewModel;
using MahApps.Metro.Controls;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ConceptMatrix.Views
{
    /// <summary>
    /// Interaction logic for WorldFlyOut.xaml
    /// </summary>
    public partial class WorldFlyOut : Flyout
    {
        private ExdCsvReader _exdProvider = new ExdCsvReader();
        public CharacterDetails CharacterDetails { get => (CharacterDetails)BaseViewModel.model; set => BaseViewModel.model = value; }
        public WorldFlyOut()
        {
            InitializeComponent();
            _exdProvider.BGMList();
            ExdCsvReader.BGMX = _exdProvider.BGMs.Values.ToArray();
            foreach (var bgm in ExdCsvReader.BGMX)
            {
                BGMBox.Items.Add(new ExdCsvReader.BGM
                {
                    Index = Convert.ToInt32(bgm.Index),
                    Name = bgm.Name.ToString(),
                    Location = bgm.Location.ToString(),
                });
            }
        }

        private void BGMBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (BGMBox.SelectedCells.Count > 0)
            {
                if (BGMBox.SelectedItem == null)
                    return;
                var Value = (ExdCsvReader.BGM)BGMBox.SelectedItem;
                CharacterDetails.MusicBGM.value = Value.Index;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.MusicOffset, Settings.Instance.Character.Music2), "int", Value.Index.ToString());
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.MusicOffset, Settings.Instance.Character.Music), "int", Value.Index.ToString());
            }
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string filter = searchTextBox.Text.ToLower();
            BGMBox.Items.Clear();
            foreach (var bgm in ExdCsvReader.BGMX.Where(g => g.Name.ToLower().Contains(filter)))
                BGMBox.Items.Add(new ExdCsvReader.BGM
                {
                    Index = Convert.ToInt32(bgm.Index),
                    Name = bgm.Name.ToString(),
                    Location = bgm.Location.ToString(),
                });
        }
    }
}
