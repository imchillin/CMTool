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
	public partial class SimplePoseBoneView : UserControl
	{
		public static readonly DependencyProperty BoneNameProperty = DependencyProperty.Register("BoneName", typeof(string), typeof(SimplePoseBoneView));
		private static readonly ResourceManager ResourceManager = new ResourceManager(typeof(Resx.UISimplePoseStrings));

		private SimplePoseViewModel viewModel;
		private SimplePoseViewModel.Bone bone;

		private static Dictionary<SimplePoseViewModel.Bone, List<SimplePoseBoneView>> boneViews = new Dictionary<SimplePoseViewModel.Bone, List<SimplePoseBoneView>>();
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

		public SimplePoseBoneView()
		{
			InitializeComponent();
			this.OnDataContextChanged(null, default);
		}

		public static bool HasView(SimplePoseViewModel.Bone bone)
		{
			return boneViews.ContainsKey(bone);
		}

		private void OnDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
		{
			try
			{
				if (this.DataContext is SimplePoseViewModel viewModel)
				{
					this.viewModel = viewModel;
					this.viewModel.PropertyChanged += this.OnViewModelPropertyChanged;
					this.bone = viewModel.GetBone(this.BoneName);

					if (!boneViews.ContainsKey(this.bone))
						boneViews.Add(this.bone, new List<SimplePoseBoneView>());

					boneViews[this.bone].Add(this);

					this.ToolTip = GetString(this.BoneName + "_Tooltip");

					this.IsEnabled = true;

					// Wait for all bone views to load, then draw the skeleton
					Application.Current.Dispatcher.InvokeAsync(async () =>
					{
						await Task.Delay(1);
						this.DrawSkeleton();
					});
				}
				else
				{
					this.IsEnabled = false;
				}
			}
			catch (Exception ex)
			{
				this.IsEnabled = false;
				this.ToolTip = ex.Message;
				Console.WriteLine(ex.Message);
				this.BackgroundElipse.Stroke = Brushes.Red;
			}
		}

		private void DrawSkeleton()
		{
			foreach (SimplePoseViewModel.Bone bone in this.bone.Children)
			{
				if (!boneViews.ContainsKey(bone))
					continue;

				foreach (SimplePoseBoneView childView in boneViews[bone])
				{
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
		}

		private void OnViewModelPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			this.UpdateState();
		}

		private static string GetString(string key)
		{
			string value = ResourceManager.GetString(key);

			if (string.IsNullOrEmpty(value))
			{
				Console.WriteLine("Missing string: \"" + key + "\" in resources: \"" + ResourceManager.BaseName + "\"");
				return "[Missing] " + key;
			}

			return value;
		}

		private void OnMouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
		{
			if (!this.IsEnabled)
				return;

			this.viewModel.MouseOverBone = this.bone;
		}

		private void OnMouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
		{
			if (!this.IsEnabled)
				return;

			if (this.viewModel.MouseOverBone == this.bone)
			{
				this.viewModel.MouseOverBone = null;
			}
		}

		private void OnMouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
			if (!this.IsEnabled)
				return;

			if (this.viewModel == null || this.bone == null)
				return;

			this.viewModel.CurrentBone = this.bone;
		}

		private void UpdateState()
		{
			bool selected = this.viewModel.GetIsBoneSelected(this.bone);
			bool parentSelected = this.viewModel.GetIsBoneParentsSelected(this.bone);
			bool hovered = this.viewModel.GetIsBoneParentsHovered(this.bone);

			// TODO: get the current theme FG color instead of sky blue
			Brush color = hovered ? Brushes.SkyBlue : Brushes.Gray;
			int thickenss = parentSelected || selected || hovered ? 2 : 1;

			this.ForegroundElipse.Visibility = selected ? Visibility.Visible : Visibility.Hidden;
			this.ForegroundElipse.Fill = Brushes.SkyBlue;
			SetState(color, thickenss);
		}

		private void SetState(Brush stroke, int thickness)
		{
			if (this.BackgroundElipse.Stroke == stroke && this.BackgroundElipse.StrokeThickness == thickness)
				return;

			this.BackgroundElipse.Stroke = stroke;
			this.BackgroundElipse.StrokeThickness = thickness;

			foreach (Line line in this.linesToChildren)
			{
				line.Stroke = stroke;
				line.StrokeThickness = thickness;
			}
		}
	}
}
