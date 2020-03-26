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

		public QuaternionEditor()
		{
			InitializeComponent();
			this.Content.DataContext = this;
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

				quaternionEditor.PropertyChanged.Invoke(sender, new PropertyChangedEventArgs(nameof(Value)));
				quaternionEditor.PropertyChanged.Invoke(sender, new PropertyChangedEventArgs(nameof(EulerX)));
				quaternionEditor.PropertyChanged.Invoke(sender, new PropertyChangedEventArgs(nameof(EulerY)));
				quaternionEditor.PropertyChanged.Invoke(sender, new PropertyChangedEventArgs(nameof(EulerZ)));
			}
		}
	}
}
