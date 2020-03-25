using ConceptMatrix.Models;
using ConceptMatrix.Utility;
using ConceptMatrix.ViewModel;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

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

				foreach (SimplePoseViewModel.Bone bone in this.ViewModel.Bones)
				{
					if (SimplePoseBoneView.HasView(bone))
						continue;

					Grid grid = new Grid();
					grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(20) });
					grid.ColumnDefinitions.Add(new ColumnDefinition());

					SimplePoseBoneView boneView = new SimplePoseBoneView();
					boneView.BoneName = bone.BoneName;
					boneView.DataContext = this.ViewModel;
					Grid.SetColumn(boneView, 0);
					grid.Children.Add(boneView);

					Label label = new Label();
					label.Content = boneView.ToolTip;
					Grid.SetColumn(label, 1);
					grid.Children.Add(label);

					ExtraBonesList.Children.Add(grid);
				}
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
