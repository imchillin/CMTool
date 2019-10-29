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
        }
		private void GitHubButton_OnClick(object sender, RoutedEventArgs e)
		{
			Process.Start("https://github.com/KrisanThyme/CMTool");
		}
		private void DonateButton_OnClick(object sender, RoutedEventArgs e)
		{
			Process.Start("http://ko-fi.com/krisanthyme");
		}

		private void DonateButton_OnClick2(object sender, RoutedEventArgs e)
		{
			Process.Start("https://www.patreon.com/krisanthyme");
		}

		private void DonateButton_OnClick3(object sender, RoutedEventArgs e)
		{
			Process.Start("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=MPB9SS72FZHVU&source=url");
		}

		private void ChatButton_Click(object sender, RoutedEventArgs e)
		{
			Process.Start("https://twitter.com/KrisanThyme");
		}

		private void AboutDiscordBtn_Click(object sender, RoutedEventArgs e)
		{
			Process.Start("https://discord.gg/P9FWWAr");
		}
	}
}
