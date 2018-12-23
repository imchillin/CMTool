using FFXIVTool.Models;
using FFXIVTool.Utility;
using FFXIVTool.ViewModel;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Windows.Controls;

namespace FFXIVTool.Views
{
    /// <summary>
    /// Interaction logic for EmoteFlyOut.xaml
    /// </summary>
    public partial class EmoteFlyOut : Flyout
    {
        private ExdCsvReader _exdProvider = new ExdCsvReader();
        public static List<int> integers;
        public CharacterDetails CharacterDetails { get => (CharacterDetails)BaseViewModel.model; set => BaseViewModel.model = value; }
        public EmoteFlyOut()
        {
            InitializeComponent();
            _exdProvider.EmoteList();
            ExdCsvReader.Emotesx = _exdProvider.Emotes.Values.ToArray();
            List<string> FavoriteList = Properties.Settings.Default.FavoriteEmotes.Cast<string>().ToList();
            integers = FavoriteList.ConvertAll(s => int.Parse(s));
            foreach (ExdCsvReader.Emote xD in ExdCsvReader.Emotesx)
            {
                if (integers.Any(p => p == xD.Index))
                {
                    FavoriteBox.Items.Add(new ExdCsvReader.Emote
                    {
                        Index = Convert.ToInt32(xD.Index),
                        Name = xD.Name.ToString()
                    });
                }
                AllBox.Items.Add(new ExdCsvReader.Emote
                {
                    Index = Convert.ToInt32(xD.Index),
                    Name = xD.Name.ToString()
                });
                if (xD.Realist == true)
                {
                    SocialBox.Items.Add(new ExdCsvReader.Emote
                    {
                        Index = Convert.ToInt32(xD.Index),
                        Name = xD.Name.ToString()
                    });
                }
                if (xD.BattleReal == true)
                {
                    BattleBox.Items.Add(new ExdCsvReader.Emote
                    {
                        Index = Convert.ToInt32(xD.Index),
                        Name = xD.Name.ToString()
                    });
                }
                if (xD.SpeacialReal == true)
                {
                    MonsterBox.Items.Add(new ExdCsvReader.Emote
                    {
                        Index = Convert.ToInt32(xD.Index),
                        Name = xD.Name.ToString()
                    });
                }
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string filter = searchTextBox.Text.ToLower();
            SocialBox.Items.Clear();
            foreach (ExdCsvReader.Emote xD in ExdCsvReader.Emotesx.Where(g => g.Name.ToLower().Contains(filter)))
                if (xD.Realist == true)
                {
                    SocialBox.Items.Add(new ExdCsvReader.Emote
                    {
                        Index = Convert.ToInt32(xD.Index),
                        Name = xD.Name.ToString()
                    });
                }
        }

        private void SearchTextBoxMonster_TextChanged(object sender, TextChangedEventArgs e)
        {
            string filter = SearchTextBoxMonster.Text.ToLower();
            MonsterBox.Items.Clear();
            foreach (ExdCsvReader.Emote xD in ExdCsvReader.Emotesx.Where(g => g.Name.ToLower().Contains(filter)))
                if (xD.SpeacialReal == true)
                {
                    MonsterBox.Items.Add(new ExdCsvReader.Emote
                    {
                        Index = Convert.ToInt32(xD.Index),
                        Name = xD.Name.ToString()
                    });
                }
        }

        private void SearchTextBoxAll_TextChanged(object sender, TextChangedEventArgs e)
        {
            string filter = SearchTextBoxAll.Text.ToLower();
            AllBox.Items.Clear();
            foreach (ExdCsvReader.Emote xD in ExdCsvReader.Emotesx.Where(g => g.Name.ToLower().Contains(filter)))
                AllBox.Items.Add(new ExdCsvReader.Emote
                {
                    Index = Convert.ToInt32(xD.Index),
                    Name = xD.Name.ToString()
                });
        }

        private void BattleTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string filter = BattleTextBox.Text.ToLower();
            BattleBox.Items.Clear();
            foreach (ExdCsvReader.Emote xD in ExdCsvReader.Emotesx.Where(g => g.Name.ToLower().Contains(filter)))
                if (xD.BattleReal == true)
                {
                    BattleBox.Items.Add(new ExdCsvReader.Emote
                    {
                        Index = Convert.ToInt32(xD.Index),
                        Name = xD.Name.ToString()
                    });
                }
        }

        private void BoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SocialBox.SelectedCells.Count > 0)
            {
                if (SocialBox.SelectedItem == null)
                    return;
                var Value = (ExdCsvReader.Emote)SocialBox.SelectedItem;
                CharacterDetails.Emote.value = (int)Value.Index;
            }
        }

        private void BattleBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (BattleBox.SelectedCells.Count > 0)
            {
                if (BattleBox.SelectedItem == null)
                    return;
                var Value = (ExdCsvReader.Emote)BattleBox.SelectedItem;
                CharacterDetails.Emote.value = (int)Value.Index;
            }
        }

        private void MonsterBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (MonsterBox.SelectedCells.Count > 0)
            {
                if (MonsterBox.SelectedItem == null)
                    return;
                var Value = (ExdCsvReader.Emote)MonsterBox.SelectedItem;
                CharacterDetails.Emote.value = (int)Value.Index;
            }
        }

        private void AllBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (AllBox.SelectedCells.Count > 0)
            {
                if (AllBox.SelectedItem == null)
                    return;
                var Value = (ExdCsvReader.Emote)AllBox.SelectedItem;
                CharacterDetails.Emote.value = (int)Value.Index;
            }
        }

        private void MenuItem_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (SocialBox.SelectedCells.Count > 0)
            {
                if (SocialBox.SelectedItem == null)
                    return;
                var Value = (ExdCsvReader.Emote)SocialBox.SelectedItem;
                integers.Add(Value.Index);
                FavoriteBox.Items.Add(SocialBox.SelectedItem);
            }
        }

        private void SearchTextBoxFav_TextChanged(object sender, TextChangedEventArgs e)
        {
            string filter = SearchTextBoxAll.Text.ToLower();
            FavoriteBox.Items.Clear();
            foreach (ExdCsvReader.Emote xD in ExdCsvReader.Emotesx.Where(g => g.Name.ToLower().Contains(filter)))
                if (integers.Any(p => p == xD.Index))
                {
                    FavoriteBox.Items.Add(new ExdCsvReader.Emote
                    {
                        Index = Convert.ToInt32(xD.Index),
                        Name = xD.Name.ToString()
                    });
                }
        }

        private void FavoriteBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FavoriteBox.SelectedCells.Count > 0)
            {
                if (FavoriteBox.SelectedItem == null)
                    return;
                var Value = (ExdCsvReader.Emote)FavoriteBox.SelectedItem;
                CharacterDetails.Emote.value = (int)Value.Index;
            }
        }

        private void MenuItem_Click_1(object sender, System.Windows.RoutedEventArgs e)
        {
            if (BattleBox.SelectedCells.Count > 0)
            {
                if (BattleBox.SelectedItem == null)
                    return;
                var Value = (ExdCsvReader.Emote)BattleBox.SelectedItem;
                integers.Add(Value.Index);
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
                integers.Add(Value.Index);
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
                integers.Add(Value.Index);
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
                integers.Remove(Value.Index);
                FavoriteBox.Items.Remove(FavoriteBox.SelectedItem);
            }
        }
    }
}
