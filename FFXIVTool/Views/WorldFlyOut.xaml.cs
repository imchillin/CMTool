using FFXIVTool.Models;
using FFXIVTool.Utility;
using FFXIVTool.ViewModel;
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

namespace FFXIVTool.Views
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
            foreach (ExdCsvReader.BGM xD in ExdCsvReader.BGMX)
            {
                BGMBox.Items.Add(new ExdCsvReader.BGM
                {
                    Index = Convert.ToInt32(xD.Index),
                    Name = xD.Name.ToString(),
                    Location = xD.Location.ToString(),
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
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.MusicOffset, Settings.Instance.Character.Music2), "int", Value.Index.ToString());
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(MemoryManager.Instance.MusicOffset, Settings.Instance.Character.Music), "int", Value.Index.ToString());
            }
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string filter = searchTextBox.Text.ToLower();
            BGMBox.Items.Clear();
            foreach (ExdCsvReader.BGM xD in ExdCsvReader.BGMX.Where(g => g.Name.ToLower().Contains(filter)))
                BGMBox.Items.Add(new ExdCsvReader.BGM
                {
                    Index = Convert.ToInt32(xD.Index),
                    Name = xD.Name.ToString(),
                    Location = xD.Location.ToString(),
                });
        }
    }
}
