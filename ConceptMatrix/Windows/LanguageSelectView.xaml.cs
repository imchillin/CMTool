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

namespace ConceptMatrix.Windows
{
    /// <summary>
    /// Interaction logic for LanguageSelectView.xaml
    /// </summary>
    public partial class LanguageSelectView : Window
    {
        public LanguageSelectView()
        {
            InitializeComponent();
        }

        public string LanguageCode { get; set; }

        private void EnglishBtn_Click(object sender, RoutedEventArgs e)
        {
            LanguageCode = "en";
            Close();
        }

        private void JapaneseBtn_Click(object sender, RoutedEventArgs e)
        {
            LanguageCode = "ja";
            Close();
        }

        private void GermanBtn_Click(object sender, RoutedEventArgs e)
        {
            LanguageCode = "de";
            Close();
        }

        private void FrenchBtn_Click(object sender, RoutedEventArgs e)
        {
            LanguageCode = "fr";
            Close();
        }

        private void KoreanBtn_Click(object sender, RoutedEventArgs e)
        {
            LanguageCode = "ko";
            Close();
        }

        private void ChineseBtn_Click(object sender, RoutedEventArgs e)
        {
            LanguageCode = "zh";
            Close();
        }
    }
}
