using ConceptMatrix.ViewModel;
using System;
using System.Collections.Generic;
using System.Resources;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

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

		private static Dictionary<SimplePoseViewModel.Bone, SimplePoseViewBone> boneViews = new Dictionary<SimplePoseViewModel.Bone, SimplePoseViewBone>();
		private List<Line> linesToChildren = new List<Line>();

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
				boneViews.Add(this.bone, this);

				this.ToolTip = GetString(this.BoneName + "_Tooltip");

				this.Button.IsEnabled = true;

				Task.Run(DrawSkeletonDelay);
			}
			catch (Exception ex)
			{
				this.Button.IsEnabled = false;
				this.ToolTip = ex.Message;
				Console.WriteLine(ex.Message);
			}
		}

		private async Task DrawSkeletonDelay()
		{
			await Task.Delay(100);
			Application.Current.Dispatcher.Invoke(() => this.DrawSkeleton());
		}

		private void DrawSkeleton()
		{
			foreach (SimplePoseViewModel.Bone bone in this.bone.Children)
			{
				if (!boneViews.ContainsKey(bone))
					continue;

				SimplePoseViewBone childView = boneViews[bone];

				if (this.Parent is Canvas c1 && childView.Parent is Canvas c2 && c1 == c2)
				{
					Line line = new Line();
					line.SnapsToDevicePixels = true;
					line.StrokeThickness = 1;
					line.Stroke = Brushes.Gray;
					line.IsHitTestVisible = false;

					line.X1 = Canvas.GetLeft(this) + (this.Width / 2);
					line.Y1 = Canvas.GetTop(this) + (this.Height / 2);
					line.X2 = Canvas.GetLeft(childView) + (childView.Width / 2);
					line.Y2 = Canvas.GetTop(childView) + (childView.Height / 2);

					c1.Children.Insert(0, line);
					this.linesToChildren.Add(line);
				}
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

		private void OnMouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
		{
			foreach (SimplePoseViewModel.Bone bone in this.bone.Children)
			{
				if (!boneViews.ContainsKey(bone))
					continue;

				SimplePoseViewBone childView = boneViews[bone];
				childView.OnMouseEnter(sender, e);
			}

			foreach (Line line in this.linesToChildren)
			{
				// TODO: get the current theme FG color
				line.Stroke = Brushes.SkyBlue;
				line.StrokeThickness = 2;
			}
		}

		private void OnMouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
		{
			foreach (SimplePoseViewModel.Bone bone in this.bone.Children)
			{
				if (!boneViews.ContainsKey(bone))
					continue;

				SimplePoseViewBone childView = boneViews[bone];
				childView.OnMouseLeave(sender, e);
			}

			foreach (Line line in this.linesToChildren)
			{
				line.Stroke = Brushes.Gray;
				line.StrokeThickness = 1;
			}
		}
	}
}
