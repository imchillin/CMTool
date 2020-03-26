using ConceptMatrix.Models;
using ConceptMatrix.ViewModel;
using System.Threading;
using System.Windows;
using System.Windows.Controls;

namespace ConceptMatrix.Views
{
	/// <summary>
	/// Interaction logic for CharacterPoseView.xaml
	/// </summary>
	public partial class SimplePoseView : UserControl
	{
		public SimplePoseViewModel ViewModel { get; set; }

		public SimplePoseView()
		{
			InitializeComponent();
			Application.Current.Exit += this.OnApplicationExiting;
		}

		private void OnIsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
		{
			if (this.IsVisible)
			{
				if (this.ViewModel != null)
					this.ViewModel.Refresh();

				ThreadStart ts = new ThreadStart(this.PollChanges);
				Thread th = new Thread(ts);
				th.Start();
			}
		}

		private void PollChanges()
		{
			while (this.IsVisible)
			{
				Thread.Sleep(32);

				if (!this.ViewModel.IsEnabled)
					continue;

				if (this.ViewModel.CurrentBone == null)
					continue;

				this.ViewModel.CurrentBone.SetRotation();
			}
		}

		private void OnDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
		{
			if (this.DataContext is CharacterDetails details)
			{
				this.ViewModel = new SimplePoseViewModel(details);
				this.ContentArea.DataContext = this.ViewModel;
			}
		}

		private void OnApplicationExiting(object sender, ExitEventArgs e)
		{
			this.ViewModel.IsEnabled = false;
		}

		private void OnUnloaded(object sender, RoutedEventArgs e)
		{
			this.ViewModel.IsEnabled = false;
		}
	}
}
