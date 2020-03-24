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
		}

		private void OnIsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
		{
			MemoryManager.Instance.MemLib.writeMemory(MemoryManager.Instance.SkeletonAddress, "bytes", "0x90 0x90 0x90 0x90 0x90 0x90");
			MemoryManager.Instance.MemLib.writeMemory(MemoryManager.Instance.SkeletonAddress2, "bytes", "0x90 0x90 0x90 0x90 0x90 0x90");
			MemoryManager.Instance.MemLib.writeMemory(MemoryManager.Instance.SkeletonAddress3, "bytes", "0x90 0x90 0x90 0x90");
			MemoryManager.Instance.MemLib.writeMemory(MemoryManager.Instance.PhysicsAddress, "bytes", "0x90 0x90 0x90 0x90");
			MemoryManager.Instance.MemLib.writeMemory(MemoryManager.Instance.PhysicsAddress2, "bytes", "0x90 0x90 0x90");

			if (this.IsVisible)
			{
				ThreadStart ts = new ThreadStart(this.PollSliders);
				Thread th = new Thread(ts);
				th.Start();
			}
		}

		private void PollSliders()
		{
			while (this.IsVisible)
			{
				Thread.Sleep(8);

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
					label.Content = bone.BoneName;
					Grid.SetColumn(label, 1);
					grid.Children.Add(label);

					ExtraBonesList.Children.Add(grid);
				}
			}
		}
	}
}
