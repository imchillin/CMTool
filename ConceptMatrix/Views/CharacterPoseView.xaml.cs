using ConceptMatrix.Models;
using ConceptMatrix.Utility;
using ConceptMatrix.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
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

using static ConceptMatrix.Views.CharacterDetailsView5;

namespace ConceptMatrix.Views
{
	/// <summary>
	/// Interaction logic for CharacterPoseView.xaml
	/// </summary>
	public partial class CharacterPoseView : UserControl
	{
		private PoseViewModel viewModel;

		public CharacterPoseView()
		{
			InitializeComponent();
		}

		public class PoseViewModel : BaseModel
		{
			private static Dictionary<string, Bone> bones = new Dictionary<string, Bone>();

			public CharacterDetails Character { get; set; }
			public Bone CurrentBone { get; set; }

			public string CurrentBoneName
			{
				get
				{
					return this.CurrentBone?.BoneName;
				}
				set
				{
					if (this.CurrentBone?.BoneName == value)
						return;

					if (!bones.ContainsKey(value))
						throw new Exception("Failed to find bone: " + value);

					this.CurrentBone = bones[value];
					this.CurrentBone.GetRotation();
					
				}
			}

			public PoseViewModel(CharacterDetails character)
			{
				this.Character = character;
				GenerateBones();
			}

			// gets all bones defined in BonesOffsets.
			private static void GenerateBones()
			{
				bones.Clear();
				CharacterOffsets c = Settings.Instance.Character;
				PropertyInfo[] boneProperties = typeof(BonesOffsets).GetProperties();
				foreach (PropertyInfo boneProperty in boneProperties)
				{
					string[] parts = boneProperty.Name.Split('_');

					if (parts.Length != 2)
						continue;

					string boneName = parts[0];

					if (!bones.ContainsKey(boneName))
					{
						bones[boneName] = new Bone(boneName);
					}
				}
			}

			// Get the bone address string from the Settings.Instance.Character.Body.Bones lookup.
			private static string GetAddressString(string boneName, string axis)
			{
				Mem mem = MemoryManager.Instance.MemLib;
				CharacterOffsets c = Settings.Instance.Character;

				string propertyName = boneName + "_" + axis.ToUpper();
				PropertyInfo property = c.Body.Bones.GetType().GetProperty(propertyName);

				if (property == null)
					throw new Exception("Failed to get bone axis: \"" + propertyName + "\"");

				string offsetString = (string)property.GetValue(c.Body.Bones);
				return MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, c.Body.Base, offsetString);
			}

			public class Bone : BaseModel
			{
				public readonly string BoneName;

				private float x;
				private float y;
				private float z;

				public Bone(string boneName)
				{
					this.BoneName = boneName;
				}

				public float X 
				{ 
					get
					{
						return this.x;
					}

					set
					{
						this.x = value;
						SetRotation();
					}
				}

				public float Y
				{
					get
					{
						return this.y;
					}

					set
					{
						this.y = value;
						SetRotation();
					}
				}

				public float Z
				{
					get
					{
						return this.z;
					}

					set
					{
						this.z = value;
						SetRotation();
					}
				}

				public void GetRotation()
				{
					Mem mem = MemoryManager.Instance.MemLib;

					byte[] bytearray = mem.readBytes(GetAddress("X"), 16);

					Quaternion q = new Quaternion();
					q.X = BitConverter.ToSingle(bytearray, 0);
					q.Y = BitConverter.ToSingle(bytearray, 4);
					q.Z = BitConverter.ToSingle(bytearray, 8);
					q.W = BitConverter.ToSingle(bytearray, 12);
					Vector3D euler = q.ToEulerAngles();
					this.X = (float)euler.X;
					this.Y = (float)euler.Y;
					this.Z = (float)euler.Z;
				}

				private void SetRotation()
				{
					Vector3D euler = new Vector3D(this.X, this.Y, this.Z);
					Quaternion q = euler.ToQuaternion();

					Mem mem = MemoryManager.Instance.MemLib;
					mem.writeBytes(GetAddress("X"), BitConverter.GetBytes((float)q.X));
					mem.writeBytes(GetAddress("Y"), BitConverter.GetBytes((float)q.Y));
					mem.writeBytes(GetAddress("Z"), BitConverter.GetBytes((float)q.Z));
					mem.writeBytes(GetAddress("W"), BitConverter.GetBytes((float)q.W));
				}

				private string GetAddress(string axis)
				{
					return PoseViewModel.GetAddressString(BoneName, axis);
				}
			}
		}

		private void OnDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
		{
			if (this.DataContext is CharacterDetails details)
			{
				this.viewModel = new PoseViewModel(details);
				this.ContentArea.DataContext = this.viewModel;
			}
		}
	}

	public class StringToBoolConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value is string valueStr && parameter is string paramStr)
			{
				return valueStr == paramStr;
			}

			return false;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return parameter;
		}
	}
}
