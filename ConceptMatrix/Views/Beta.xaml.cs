using ConceptMatrix.Converters;
using ConceptMatrix.Models;
using ConceptMatrix.Utility;
using ConceptMatrix.ViewModel;
using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Media3D;

namespace ConceptMatrix.Views
{
	/// <summary>
	/// Interaction logic for Beta.xaml
	/// </summary>
	public partial class Beta : UserControl, INotifyPropertyChanged
	{
		public static readonly DependencyProperty FrozenProperty = DependencyProperty.Register("Frozen", typeof(bool), typeof(Beta), new UIPropertyMetadata(false));

		public event PropertyChangedEventHandler PropertyChanged;

		public CharacterDetails CharacterDetails { get => (CharacterDetails)BaseViewModel.model; set => BaseViewModel.model = value; }

		public double X { get; set; }
		public double Y { get; set; }
		public double Z { get; set; }

		public double QX { get; set; }
		public double QY { get; set; }
		public double QZ { get; set; }
		public double QW { get; set; }

		public bool Frozen
		{
			get => (bool)GetValue(FrozenProperty);
			set
			{
				SetValue(FrozenProperty, value);
				
				// Set the rotation freeze values to the Frozen value
				CharacterDetails.Rotation.freeze = value;
				CharacterDetails.Rotation2.freeze = value;
				CharacterDetails.Rotation3.freeze = value;
				CharacterDetails.Rotation4.freeze = value;
			}
		}

		public Beta()
		{
			InitializeComponent();
			DataContext = this;

			var worker = new BackgroundWorker();

			worker.DoWork += (_, __) =>
			{
				while (true)
				{
					try
					{
						Dispatcher.Invoke(() =>
						{
							if (CharacterDetails == null)
								return;

							if (!Frozen)
							{
								var q = new Quaternion(
									CharacterDetails.Rotation.value,
									CharacterDetails.Rotation2.value,
									CharacterDetails.Rotation3.value,
									CharacterDetails.Rotation4.value
								);

								var v = GetEulerAngles(q);

								X = (float)v.X;
								Y = (float)v.Y;
								Z = (float)v.Z;
							}
							else
							{
								var q = GetQuaternion(new Vector3D(X, Y, Z));

								CharacterDetails.Rotation.value = (float)q.X;
								CharacterDetails.Rotation2.value = (float)q.Y;
								CharacterDetails.Rotation3.value = (float)q.Z;
								CharacterDetails.Rotation4.value = (float)q.W;
							}

							var _q = GetQuaternion(new Vector3D(X, Y, Z));

							QX = _q.X;
							QY = _q.Y;
							QZ = _q.Z;
							QW = _q.W;
						});
						
					}
					catch (Exception ex)
					{
						Console.WriteLine(ex.Message);
					}

					Thread.Sleep(100);
				}
			};

			worker.RunWorkerAsync();
		}

		private Vector3D GetEulerAngles(Quaternion q1)
		{
			var v = new Vector3D();

			var test = q1.X * q1.Y + q1.Z * q1.W;

			if (test > 0.4995f)
			{
				v.Y = 2f * Math.Atan2(q1.X, q1.Y);
				v.X = Math.PI / 2;
				v.Z = 0;
				return NormalizeAngles(v * Rad2Deg);
			}

			if (test < -0.4995f)
			{
				v.Y = -2f * Math.Atan2(q1.X, q1.W);
				v.X = -Math.PI / 2;
				v.Z = 0;
				return NormalizeAngles(v * Rad2Deg);
			}

			var sqx = q1.X * q1.X;
			var sqy = q1.Y * q1.Y;
			var sqz = q1.Z * q1.Z;

			v.Y = Math.Atan2(2 * q1.Y * q1.W - 2 * q1.X * q1.Z, 1 - 2 * sqy - 2 * sqz);
			v.X = Math.Asin(2 * test);
			v.Z = Math.Atan2(2 * q1.X * q1.W - 2 * q1.Y * q1.Z, 1 - 2 * sqx - 2 * sqz);

			return NormalizeAngles(v * Rad2Deg);
		}

		private Quaternion GetQuaternion(Vector3D v)
		{
			var yaw = v.Y * Deg2Rad;
			var pitch = v.X * Deg2Rad;
			var roll = v.Z * Deg2Rad;

			var c1 = Math.Cos(yaw / 2);
			var s1 = Math.Sin(yaw / 2);
			var c2 = Math.Cos(pitch / 2);
			var s2 = Math.Sin(pitch / 2);
			var c3 = Math.Cos(roll / 2);
			var s3 = Math.Sin(roll / 2);

			var c1c2 = c1 * c2;
			var s1s2 = s1 * s2;

			return new Quaternion(
				c1c2 * s3 + s1s2 * c3,
				s1 * c2 * c3 + c1 * s2 * s3,
				c1 * s2 * c3 - s1 * c2 * s3,
				c1c2 * c3 - s1s2 * s3
			);
		}

		private Vector3D NormalizeAngles(Vector3D angles)
		{
			angles.X = NormalizeAngle(angles.X);
			angles.Y = NormalizeAngle(angles.Y);
			angles.Z = NormalizeAngle(angles.Z);
			return angles;
		}

		private readonly double Rad2Deg = 360 / (Math.PI * 2);
		private readonly double Deg2Rad = (Math.PI * 2) / 360;

		private double NormalizeAngle(double angle)
		{
			while (angle > 360)
				angle -= 360;
			while (angle < 0)
				angle += 360;
			return angle;
		}

	}

}
