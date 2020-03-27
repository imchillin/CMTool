using ConceptMatrix.Three3D;
using ConceptMatrix.ThreeD;
using ConceptMatrix.ThreeD.Lines;
using ConceptMatrix.Utility;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ConceptMatrix.Controls
{
	/// <summary>
	/// Interaction logic for QuaternionEditor.xaml
	/// </summary>
	public partial class QuaternionEditor : UserControl, INotifyPropertyChanged
	{
		public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(nameof(Value), typeof(Quaternion), typeof(QuaternionEditor), new FrameworkPropertyMetadata(new PropertyChangedCallback(OnValueChanged)));

		private Vector3D euler;
		private bool eulerLock = false;
		private RotationGizmo rotationGizmo;

		public QuaternionEditor()
		{
			InitializeComponent();
			this.Content.DataContext = this;

			this.rotationGizmo = new RotationGizmo();
			this.Viewport.Children.Add(this.rotationGizmo);
		}

		[AlsoNotifyFor(nameof(EulerX), nameof(EulerY), nameof(EulerZ))]
		public Quaternion Value
		{
			get
			{
				return (Quaternion)this.GetValue(ValueProperty);
			}

			set
			{
				if (!this.eulerLock)
					this.euler = value.ToEulerAngles();

				this.SetValue(ValueProperty, value);

				this.rotationGizmo.Transform = new RotateTransform3D(new QuaternionRotation3D(value));
			}
		}

		public double EulerX
		{
			get
			{
				return this.euler.X;
			}
			set
			{
				this.eulerLock = true;
				this.euler.X = value;
				this.Value = this.euler.ToQuaternion();
				this.eulerLock = false;
			}
		}

		public double EulerY
		{
			get
			{
				return this.euler.Y;
			}
			set
			{
				this.eulerLock = true;
				this.euler.Y = value;
				this.Value = this.euler.ToQuaternion();
				this.eulerLock = false;
			}
		}

		public double EulerZ
		{
			get
			{
				return this.euler.Z;
			}
			set
			{
				this.eulerLock = true;
				this.euler.Z = value;
				this.Value = this.euler.ToQuaternion();
				this.eulerLock = false;
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		private static void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
		{
			if (sender is QuaternionEditor quaternionEditor)
			{
				if (quaternionEditor.eulerLock)
					return;

				quaternionEditor.euler = quaternionEditor.Value.ToEulerAngles();
				quaternionEditor.rotationGizmo.Transform = new RotateTransform3D(new QuaternionRotation3D(quaternionEditor.Value));

				quaternionEditor.PropertyChanged.Invoke(sender, new PropertyChangedEventArgs(nameof(Value)));
				quaternionEditor.PropertyChanged.Invoke(sender, new PropertyChangedEventArgs(nameof(EulerX)));
				quaternionEditor.PropertyChanged.Invoke(sender, new PropertyChangedEventArgs(nameof(EulerY)));
				quaternionEditor.PropertyChanged.Invoke(sender, new PropertyChangedEventArgs(nameof(EulerZ)));
			}
		}

		private void OnViewportMouseMove(object sender, MouseEventArgs e)
		{

			Point mousePosition = e.GetPosition(this.Viewport);
			HitTestResult result = VisualTreeHelper.HitTest(this.Viewport, mousePosition);

			this.rotationGizmo.Hover(result.VisualHit);
		}

		private void OnViewportMouseLeave(object sender, MouseEventArgs e)
		{
			this.rotationGizmo.Hover(null);
		}

		private class RotationGizmo : ModelVisual3D
		{
			private AxisGizmo hoveredGizmo;

			public RotationGizmo()
			{
				Sphere sphere = new Sphere();
				sphere.Radius = 0.48;
				Color c = Colors.Black;
				c.A = 128;
				sphere.Material = new DiffuseMaterial(new SolidColorBrush(c));
				this.Children.Add(sphere);

				this.Children.Add(new AxisGizmo(Colors.Blue, new Vector3D(1, 0, 0)));
				this.Children.Add(new AxisGizmo(Colors.Green, new Vector3D(0, 1, 0)));
				this.Children.Add(new AxisGizmo(Colors.Red, new Vector3D(0, 0, 1)));
			}

			public bool Hover(DependencyObject visual)
			{
				AxisGizmo gizmo = null;
				if (visual is Circle r)
				{
					gizmo = (AxisGizmo)VisualTreeHelper.GetParent(r);
				}
				else if (visual is Cylinder c)
				{
					gizmo = (AxisGizmo)VisualTreeHelper.GetParent(c);
				}

				if (this.hoveredGizmo != null)
					this.hoveredGizmo.Hovered = false;

				this.hoveredGizmo = gizmo;

				if (this.hoveredGizmo != null)
				{
					this.hoveredGizmo.Hovered = true;
					return true;
				}

				return false;
			}
		}

		private class AxisGizmo : ModelVisual3D
		{
			private Circle circle;
			private Cylinder cylinder;
			private bool hovered;
			private Color color;

			public AxisGizmo(Color color, Vector3D axis)
			{
				this.color = color;

				this.circle = new Circle();
				this.circle.Thickness = 1;
				this.circle.Color = color;
				this.circle.Radius = 0.5;
				this.circle.Transform = new RotateTransform3D(new AxisAngleRotation3D(axis, 90));
				this.Children.Add(this.circle);

				cylinder = new Cylinder();
				cylinder.Radius = 0.49;
				cylinder.Length = 0.15;
				cylinder.Transform = new RotateTransform3D(new AxisAngleRotation3D(axis, 90));
				cylinder.Material = new DiffuseMaterial(new SolidColorBrush(Colors.Transparent));
				this.Children.Add(cylinder);
			}

			public bool Hovered
			{
				get
				{
					return this.hovered;
				}

				set
				{
					this.hovered = value;

					if (!value)
					{
						this.circle.Color = color;
						this.circle.Thickness = 1;
					}
					else
					{
						this.circle.Color = Colors.Yellow;
						this.circle.Thickness = 3;
					}
				}
			}
		}
	}
}
