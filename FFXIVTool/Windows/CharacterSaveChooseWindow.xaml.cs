using FFXIVTool.Utility;
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
    /// Interaction logic for CharacterSaveChooseWindow.xaml
    /// </summary>
    public partial class CharacterSaveChooseWindow : Window
    {
        private List<DatSaves> _dats;

        public byte[] Choice = null;
        public CharacterSaveChooseWindow(string text)
        {
            InitializeComponent();
            _dats = MakeSaveDatList.Make();

            foreach (var saveDat in _dats)
            {
                var gender = saveDat.CustomizeBytes[1] == 1 ? "♀️" : "♂️";
                CharacterListbox.Items.Add(
                    $"{ByteToRaceDict[saveDat.CustomizeBytes[0]]} - {ByteToTribeDict[saveDat.CustomizeBytes[4]]} {gender} - {saveDat.Description}");
            }
        }
        private readonly Dictionary<byte, string> ByteToRaceDict = new Dictionary<byte, string>
        {
            {0, "Unknown"},
            {1, "Hyur"},
            {2, "Elezen"},
            {3, "Lalafell" },
            {4, "Miqo'te" },
            {5, "Roegadyn"},
            {6, "Au Ra"}
        };
        private readonly Dictionary<byte, string> ByteToTribeDict = new Dictionary<byte, string>
        {
            {0, "Unknown"},
            {1, "Midlander"},
            {2, "Highlander"},
            {3, "Wildwood" },
            {4, "Duskwight" },
            {5, "Plainsfolk"},
            {6, "Dunesfolk"},
            {7, "Seeker of the Sun"},
            {8, "Keeper of the Moon"},
            {9, "Sea Wolf"},
            {10, "Hellsguard"},
            {11, "Raen"},
            {12, "Xaela"},
        };
        private void CharacterListbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CharacterListbox.SelectedIndex == -1)
            {
                Close();
                return;
            }

            Choice = _dats[CharacterListbox.SelectedIndex].CustomizeBytes;
            Close();
        }
    }
}
