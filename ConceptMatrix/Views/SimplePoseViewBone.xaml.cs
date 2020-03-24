using ConceptMatrix.ViewModel;
using System;
using System.Resources;
using System.Windows;
using System.Windows.Controls;

namespace ConceptMatrix.Views
{
	/// <summary>
	/// Interaction logic for SimplePoseViewBone.xaml
	/// </summary>
	public partial class SimplePoseViewBone : UserControl
	{
		public static readonly DependencyProperty BoneNameProperty = DependencyProperty.Register("BoneName", typeof(string), typeof(SimplePoseViewBone));
		private static readonly ResourceManager ResourceManager = new ResourceManager(typeof(Resx.UISimplePoseStrings));

		private SimplePoseViewModel viewModel;
		private SimplePoseViewModel.Bone bone;

		public string BoneName
		{ 
			get
			{
				return (string)GetValue(BoneNameProperty);
			}

			set
			{
				this.SetValue(BoneNameProperty, value);
			}
		}

		public SimplePoseViewBone()
		{
			InitializeComponent();
			this.OnDataContextChanged(null, default);
		}

		private void OnDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
		{
			if (this.DataContext is null)
			{
				this.Button.IsEnabled = false;
				return;
			}

			try
			{
				this.viewModel = this.DataContext as SimplePoseViewModel;
				this.viewModel.PropertyChanged += this.OnViewModelPropertyChanged;
				this.bone = viewModel.GetBone(this.BoneName);

				this.ToolTip = GetString(this.BoneName + "_Tooltip");

				this.Button.IsEnabled = true;
			}
			catch (Exception ex)
			{
				this.Button.IsEnabled = false;
				this.ToolTip = ex.Message;
				Console.WriteLine(ex.Message);
			}
		}

		private void OnViewModelPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			if (e.PropertyName == nameof(SimplePoseViewModel.CurrentBone))
			{
				Button.IsChecked = this.viewModel.CurrentBone == this.bone;
			}
		}

		private static string GetString(string key)
		{
			string value = ResourceManager.GetString(key);

			if (string.IsNullOrEmpty(value))
				return "[Missing] " + key;
				////throw new Exception("Missing string: \"" + key + "\" in resources: \"" + ResourceManager.BaseName + "\"");

			return value;
		}

		private void OnChecked(object sender, RoutedEventArgs e)
		{
			if (this.viewModel is null || this.bone is null)
				return;

			this.viewModel.CurrentBone = this.bone;
		}
	}
}
