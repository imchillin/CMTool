using ConceptMatrix.Models;
using ConceptMatrix.Utility;
using ConceptMatrix.ViewModel;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Windows.Input;
using System.Windows.Controls;

namespace ConceptMatrix.Views
{
    /// <summary>
    /// Interaction logic for EmoteFlyOut.xaml
    /// </summary>
    public partial class EmoteFlyOut : Flyout
    {
        private ExdCsvReader _exdProvider = new ExdCsvReader();
        public CharacterDetails CharacterDetails { get => (CharacterDetails)BaseViewModel.model; set => BaseViewModel.model = value; }
        public EmoteFlyOut()
        {
            InitializeComponent();
            _exdProvider.EmoteList();
            ExdCsvReader.Emotesx = _exdProvider.Emotes.Values.ToArray();
            foreach (var emote in ExdCsvReader.Emotesx)
            {
                AllBox.Items.Add(new ExdCsvReader.Emote
                {
                    Index = Convert.ToInt32(emote.Index),
                    Name = emote.Name.ToString()
                });
                if (emote.Realist == true)
                {
                    SocialBox.Items.Add(new ExdCsvReader.Emote
                    {
                        Index = Convert.ToInt32(emote.Index),
                        Name = emote.Name.ToString()
                    });
                }
                if (emote.BattleReal == true)
                {
                    BattleBox.Items.Add(new ExdCsvReader.Emote
                    {
                        Index = Convert.ToInt32(emote.Index),
                        Name = emote.Name.ToString()
                    });
                }
                if (emote.SpeacialReal == true)
                {
                    MonsterBox.Items.Add(new ExdCsvReader.Emote
                    {
                        Index = Convert.ToInt32(emote.Index),
                        Name = emote.Name.ToString()
                    });
                }
            }
            if (SaveSettings.Default.FavoriteEmotes.Count > 0)
            {
                foreach (var emote in SaveSettings.Default.FavoriteEmotes)
                {
                    FavoriteBox.Items.Add(new ExdCsvReader.Emote
                    {
                        Index = Convert.ToInt32(emote.Index),
                        Name = emote.Name.ToString()
                    });
                }
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var filter = searchTextBox.Text.ToLower();
            SocialBox.Items.Clear();
            foreach (var emote in ExdCsvReader.Emotesx.Where(g => g.Name.ToLower().Contains(filter)))
                if (emote.Realist == true)
                {
                    SocialBox.Items.Add(new ExdCsvReader.Emote
                    {
                        Index = Convert.ToInt32(emote.Index),
                        Name = emote.Name.ToString()
                    });
                }
        }

        private void SearchTextBoxMonster_TextChanged(object sender, TextChangedEventArgs e)
        {
            var filter = SearchTextBoxMonster.Text.ToLower();
            MonsterBox.Items.Clear();
            foreach (var emote in ExdCsvReader.Emotesx.Where(g => g.Name.ToLower().Contains(filter)))
                if (emote.SpeacialReal == true)
                {
                    MonsterBox.Items.Add(new ExdCsvReader.Emote
                    {
                        Index = Convert.ToInt32(emote.Index),
                        Name = emote.Name.ToString()
                    });
                }
        }

        private void SearchTextBoxAll_TextChanged(object sender, TextChangedEventArgs e)
        {
            var filter = SearchTextBoxAll.Text.ToLower();
            AllBox.Items.Clear();
            foreach (var emote in ExdCsvReader.Emotesx.Where(g => g.Name.ToLower().Contains(filter)))
                AllBox.Items.Add(new ExdCsvReader.Emote
                {
                    Index = Convert.ToInt32(emote.Index),
                    Name = emote.Name.ToString()
                });
        }

        private void BattleTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var filter = BattleTextBox.Text.ToLower();
            BattleBox.Items.Clear();
            foreach (var emote in ExdCsvReader.Emotesx.Where(g => g.Name.ToLower().Contains(filter)))
                if (emote.BattleReal == true)
                {
                    BattleBox.Items.Add(new ExdCsvReader.Emote
                    {
                        Index = Convert.ToInt32(emote.Index),
                        Name = emote.Name.ToString()
                    });
                }
        }

        private void BoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SocialBox.SelectedCells.Count > 0)
            {
                if (SocialBox.SelectedItem == null)
                    return;
                if (AnimBox.SelectedIndex == 0)
                {
                    var Value = (ExdCsvReader.Emote)SocialBox.SelectedItem;
                    CharacterDetails.Emote.value = Value.Index;
                }
                if (AnimBox.SelectedIndex == 1)
                {
                    var Value = (ExdCsvReader.Emote)SocialBox.SelectedItem;
                    CharacterDetails.EmoteOld.value = Value.Index;
                }
            }
        }

        private void BattleBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (BattleBox.SelectedCells.Count > 0)
            {
                if (BattleBox.SelectedItem == null)
                    return;
                if (AnimBox.SelectedIndex == 0)
                {
                    var Value = (ExdCsvReader.Emote)BattleBox.SelectedItem;
                    CharacterDetails.Emote.value = Value.Index;
                }
                if (AnimBox.SelectedIndex == 1)
                {
                    var Value = (ExdCsvReader.Emote)BattleBox.SelectedItem;
                    CharacterDetails.EmoteOld.value = Value.Index;
                }
            }
        }

        private void MonsterBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (MonsterBox.SelectedCells.Count > 0)
            {
                if (MonsterBox.SelectedItem == null)
                    return;
                if (AnimBox.SelectedIndex == 0)
                {
                    var Value = (ExdCsvReader.Emote)MonsterBox.SelectedItem;
                    CharacterDetails.Emote.value = Value.Index;
                }
                if (AnimBox.SelectedIndex == 1)
                {
                    var Value = (ExdCsvReader.Emote)MonsterBox.SelectedItem;
                    CharacterDetails.EmoteOld.value = Value.Index;
                }
            }
        }

        private void AllBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (AllBox.SelectedCells.Count > 0)
            {
                if (AllBox.SelectedItem == null)
                    return;
                if (AnimBox.SelectedIndex == 0)
                {
                    var Value = (ExdCsvReader.Emote)AllBox.SelectedItem;
                    CharacterDetails.Emote.value = Value.Index;
                }
                if (AnimBox.SelectedIndex == 1)
                {
                    var Value = (ExdCsvReader.Emote)AllBox.SelectedItem;
                    CharacterDetails.EmoteOld.value = Value.Index;
                }
            }
        }

        private void MenuItem_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (SocialBox.SelectedCells.Count > 0)
            {
                if (SocialBox.SelectedItem == null)
                    return;
                var Value = (ExdCsvReader.Emote)SocialBox.SelectedItem;
                if (SaveSettings.Default.FavoriteEmotes.Any(p => p.Index == Value.Index)) return;
                SaveSettings.Default.FavoriteEmotes.Add(Value);
                FavoriteBox.Items.Add(SocialBox.SelectedItem);
            }
        }

        private void SearchTextBoxFav_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (SaveSettings.Default.FavoriteEmotes.Count <= 0) return;
            var filter = SearchTextBoxFav.Text.ToLower();
            FavoriteBox.Items.Clear();
            foreach (var emote in SaveSettings.Default.FavoriteEmotes.Where(g => g.Name.ToLower().Contains(filter)))
            {
                FavoriteBox.Items.Add(new ExdCsvReader.Emote
                {
                    Index = Convert.ToInt32(emote.Index),
                    Name = emote.Name.ToString()
                });
            }
        }

        private void FavoriteBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FavoriteBox.SelectedCells.Count > 0)
            {
                if (FavoriteBox.SelectedItem == null)
                    return;
                if (AnimBox.SelectedIndex == 0)
                {
                    var Value = (ExdCsvReader.Emote)FavoriteBox.SelectedItem;
                    CharacterDetails.Emote.value = (int)Value.Index;
                }
                if (AnimBox.SelectedIndex == 1)
                {
                    var Value = (ExdCsvReader.Emote)FavoriteBox.SelectedItem;
                    CharacterDetails.EmoteOld.value = (int)Value.Index;
                }
            }
        }

        private void MenuItem_Click_1(object sender, System.Windows.RoutedEventArgs e)
        {
            if (BattleBox.SelectedCells.Count > 0)
            {
                if (BattleBox.SelectedItem == null)
                    return;
                var Value = (ExdCsvReader.Emote)BattleBox.SelectedItem;
                if (SaveSettings.Default.FavoriteEmotes.Any(p => p.Index == Value.Index)) return;
                SaveSettings.Default.FavoriteEmotes.Add(Value);
                FavoriteBox.Items.Add(BattleBox.SelectedItem);
            }
        }

        private void MenuItem_Click_2(object sender, System.Windows.RoutedEventArgs e)
        {
            if (MonsterBox.SelectedCells.Count > 0)
            {
                if (MonsterBox.SelectedItem == null)
                    return;
                var Value = (ExdCsvReader.Emote)MonsterBox.SelectedItem;
                if (SaveSettings.Default.FavoriteEmotes.Any(p => p.Index == Value.Index)) return;
                SaveSettings.Default.FavoriteEmotes.Add(Value);
                FavoriteBox.Items.Add(MonsterBox.SelectedItem);
            }
        }

        private void MenuItem_Click_3(object sender, System.Windows.RoutedEventArgs e)
        {
            if (AllBox.SelectedCells.Count > 0)
            {
                if (AllBox.SelectedItem == null)
                    return;
                var Value = (ExdCsvReader.Emote)AllBox.SelectedItem;
                if (SaveSettings.Default.FavoriteEmotes.Any(p => p.Index == Value.Index)) return;
                SaveSettings.Default.FavoriteEmotes.Add(Value);
                FavoriteBox.Items.Add(AllBox.SelectedItem);
            }
        }

        private void MenuItem_Click_4(object sender, System.Windows.RoutedEventArgs e)
        {
            if (FavoriteBox.SelectedCells.Count > 0)
            {
                if (FavoriteBox.SelectedItem == null)
                    return;
                var Value = (ExdCsvReader.Emote)FavoriteBox.SelectedItem;
                var itemToRemove = SaveSettings.Default.FavoriteEmotes.SingleOrDefault(r => r.Index == Value.Index);
                SaveSettings.Default.FavoriteEmotes.Remove(itemToRemove);
                FavoriteBox.Items.Remove(FavoriteBox.SelectedItem);
            }
        }
    }
}
