using ConceptMatrix.Utility;
using ConceptMatrix.ViewModel;
using MaterialDesignColors;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ConceptMatrix.Views
{
	/// <summary>
	/// Interaction logic for AboutView.xaml
	/// </summary>
	public partial class AboutView : UserControl
	{
		public AboutView()
		{
			InitializeComponent();
            DataContext = new PaletteSelectorViewModel();
            if (SaveSettings.Default.Theme == "Dark") ThemeButton.IsChecked = true;
        }
		private void GitHubButton_OnClick(object sender, RoutedEventArgs e)
		{
			Process.Start("https://github.com/KrisanThyme/CMTool");
		}
		private void DonateButton_OnClick(object sender, RoutedEventArgs e)
		{
			Process.Start("https://ko-fi.com/seibanaut");
		}

		private void DonateButton_OnClick2(object sender, RoutedEventArgs e)
		{
			Process.Start("http://ko-fi.com/leonblade");
		}

		private void DonateButton_OnClick3(object sender, RoutedEventArgs e)
		{
			Process.Start("http://ko-fi.com/krisanthyme");
		}

		private void ChatButton_Click(object sender, RoutedEventArgs e)
		{
			Process.Start("https://twitter.com/KrisanThyme");
		}

		private void AboutDiscordBtn_Click(object sender, RoutedEventArgs e)
		{
			Process.Start("https://discord.gg/hq3DnBa");
		}
	}
}
