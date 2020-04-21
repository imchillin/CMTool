using ConceptMatrix.Utility;
using ConceptMatrix.ViewModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

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
            MainViewModel.AboutTime = this;
            if (SaveSettings.Default.HasBackground == false) AboutBG.Opacity = 0;
        }
		private void GitHubButton_OnClick(object sender, RoutedEventArgs e)
		{
			Process.Start($"https://github.com/{App.GithubRepo}");
		}

		private void LeonDonateButton_OnClick(object sender, RoutedEventArgs e)
		{
			Process.Start("https://ko-fi.com/leonblade");
		}

		private void ChatButton_Click(object sender, RoutedEventArgs e)
		{
			Process.Start($"https://twitter.com/{App.TwitterHandle}");
		}

		private void AboutDiscordBtn_Click(object sender, RoutedEventArgs e)
		{
			Process.Start($"https://discord.gg/{App.DiscordCode}");
		}

        private void EnaDonateButton_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("https://ko-fi.com/enalagrange");
        }
    }
}