using ConceptMatrix.Models;
using ConceptMatrix.Utility;
using ConceptMatrix.ViewModel;
using System;
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
		private SimplePoseViewModel viewModel;

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

				if (this.viewModel.CurrentBone == null)
					continue;

				this.viewModel.CurrentBone.SetRotation();
			}
		}

		private void OnDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
		{
			if (this.DataContext is CharacterDetails details)
			{
				this.viewModel = new SimplePoseViewModel(details);
				this.ContentArea.DataContext = this.viewModel;
			}
		}
	}
}
