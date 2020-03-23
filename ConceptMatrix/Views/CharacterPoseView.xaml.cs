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
using System.Threading;
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

					// Ensure we have written any pending rotations before changing bone targets
					if (this.CurrentBone != null)
						this.CurrentBone.SetRotation();

					if (!bones.ContainsKey(value))
						throw new Exception("Failed to find bone: " + value);

					bones[value].GetRotation();
					this.CurrentBone = bones[value];
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

				// now that we have all the bones, we make a hierarchy
				// torso tree
				ParentBone("Root", "SpineA");
				ParentBone("SpineA", "SpineB");
				ParentBone("SpineB", "SpineC");
				ParentBone("SpineC", "Neck");
				ParentBone("Neck", "Head");
				ParentBone("SpineB", "BreastLeft");
				ParentBone("SpineB", "BreastRight");
				ParentBone("SpineB", "ScabbardLeft");
				ParentBone("SpineB", "ScabbardRight");

				// clothes tree
				ParentBone("SpineA", "ClothBackALeft");
				ParentBone("SpineA", "ClothBackBLeft");
				ParentBone("SpineA", "ClothBackCLeft");
				ParentBone("SpineA", "ClothBackARight");
				ParentBone("SpineA", "ClothBackBRight");
				ParentBone("SpineA", "ClothBackCRight");
				ParentBone("SpineA", "ClothSideALeft");
				ParentBone("SpineA", "ClothSideBLeft");
				ParentBone("SpineA", "ClothSideCLeft");
				ParentBone("SpineA", "ClothSideARight");
				ParentBone("SpineA", "ClothSideBRight");
				ParentBone("SpineA", "ClothSideCRight");
				ParentBone("SpineA", "ClothFrontALeft");
				ParentBone("SpineA", "ClothFrontBLeft");
				ParentBone("SpineA", "ClothFrontCLeft");
				ParentBone("SpineA", "ClothFrontARight");
				ParentBone("SpineA", "ClothFrontBRight");
				ParentBone("SpineA", "ClothFrontCRight");

				// Facebone (middy) tree
				ParentBone("Head", "Nose");
				ParentBone("Head", "Jaw");
				ParentBone("Head", "EyelidLowerLeft");
				ParentBone("Head", "EyelidLowerRight");
				ParentBone("Head", "EyeLeft");
				ParentBone("EyeLeft", "EyeRight");
				ParentBone("Head", "EarLeft");
				ParentBone("Head", "EarRight");
				ParentBone("Head", "EarringALeft");
				ParentBone("Head", "EarringBLeft");
				ParentBone("Head", "EarringARight");
				ParentBone("Head", "EarringBRight");
				ParentBone("Head", "HairFrontLeft");
				ParentBone("Head", "HairFrontRight");
				ParentBone("Head", "HairA");
				ParentBone("Head", "HairB");
				ParentBone("Head", "CheekLeft");
				ParentBone("Head", "CheekRight");
				ParentBone("Head", "LipsLeft");
				ParentBone("Head", "LipsRight");
				ParentBone("Head", "EyebrowLeft");
				ParentBone("Head", "EyebrowRight");
				ParentBone("Head", "Bridge");
				ParentBone("Head", "BrowLeft");
				ParentBone("Head", "BrowRight");
				ParentBone("Head", "LipUpperA");
				ParentBone("Head", "EyelidUpperLeft");
				ParentBone("Head", "EyelidUpperRight");
				ParentBone("Head", "LipLowerA");
				ParentBone("Head", "LipUpperB");
				ParentBone("Head", "LipLowerB");

				ParentBone("Head", "ExHairA");
				ParentBone("Head", "ExHairB");
				ParentBone("Head", "ExHairC");
				ParentBone("Head", "ExHairD");
				ParentBone("Head", "ExHairE");
				ParentBone("Head", "ExHairF");
				ParentBone("Head", "ExHairG");
				ParentBone("Head", "ExHairH");
				ParentBone("Head", "ExHairI");
				ParentBone("Head", "ExHairJ");
				ParentBone("Head", "ExHairK");
				ParentBone("Head", "ExHairL");

				// Facebone hroth tree
				/*ParentBone("Head", "HrothEyebrowLeft");
				ParentBone("Head", "HrothEyebrowRight");
				ParentBone("Head", "HrothBridge");
				ParentBone("Head", "HrothBrowLeft");
				ParentBone("Head", "HrothBrowRight");
				ParentBone("Head", "HrothJawUpper");
				ParentBone("Head", "HrothLipUpper");
				ParentBone("Head", "HrothEyelidUpperLeft");
				ParentBone("Head", "HrothEyelidUpperRight");
				ParentBone("Head", "HrothLipsLeft");
				ParentBone("Head", "HrothLipsRight");
				ParentBone("Head", "HrothLipUpperLeft");
				ParentBone("Head", "HrothLipUpperRight");
				ParentBone("Head", "HrothLipLower");
				ParentBone("Head", "HrothWhiskersLeft");
				ParentBone("Head", "HrothWhiskersRight");*/

				// Facebone Viera tree
				ParentBone("Head", "VieraLipLowerA");
				ParentBone("Head", "VieraLipLowerB");
				ParentBone("Head", "VieraLipUpperB");
				////ParentBone("Head", "VieraEar01ALeft");
				////ParentBone("Head", "VieraEar02ALeft");
				////ParentBone("Head", "VieraEar03ALeft");
				////ParentBone("Head", "VieraEar04ALeft");
				ParentBone("Head", "VieraEar01ARight");
				ParentBone("Head", "VieraEar02ARight");
				ParentBone("Head", "VieraEar03ARight");
				ParentBone("Head", "VieraEar04ARight");
				ParentBone("VieraEar01ALeft", "VieraEar01BLeft");
				ParentBone("VieraEar02ALeft", "VieraEar02BLeft");
				ParentBone("VieraEar03ALeft", "VieraEar03BLeft");
				ParentBone("VieraEar04ALeft", "VieraEar04BLeft");
				ParentBone("VieraEar01ARight", "VieraEar01BRight");
				ParentBone("VieraEar02ARight", "VieraEar02BRight");
				ParentBone("VieraEar03ARight", "VieraEar03BRight");
				ParentBone("VieraEar04ARight", "VieraEar04BRight");

				// Special handler for eyes
				////ParentBone("EyeRight", "EyeLeft");

				// armbone tree
				ParentBone("SpineC", "ClavicleLeft");
				ParentBone("ClavicleLeft", "ArmLeft");
				ParentBone("ArmLeft", "ShoulderLeft");
				ParentBone("ArmLeft", "PauldronLeft");
				ParentBone("ArmLeft", "ForearmLeft");
				ParentBone("ForearmLeft", "ElbowLeft");
				ParentBone("ForearmLeft", "WristLeft");
				ParentBone("ForearmLeft", "ShieldLeft");
				ParentBone("ForearmLeft", "CouterLeft");
				ParentBone("ForearmLeft", "HandLeft");
				ParentBone("HandLeft", "WeaponLeft");
				ParentBone("HandLeft", "ThumbALeft");
				ParentBone("ThumbALeft", "ThumbBLeft");
				ParentBone("HandLeft", "IndexALeft");
				ParentBone("IndexALeft", "IndexBLeft");
				ParentBone("HandLeft", "MiddleALeft");
				ParentBone("MiddleALeft", "MiddleBLeft");
				ParentBone("HandLeft", "RingALeft");
				ParentBone("RingALeft", "RingBLeft");
				ParentBone("HandLeft", "PinkyALeft");
				ParentBone("PinkyALeft", "PinkyBLeft");

				ParentBone("SpineC", "ClavicleRight");
				ParentBone("ClavicleRight", "ArmRight");
				ParentBone("ArmRight", "ShoulderRight");
				ParentBone("ArmRight", "PauldronRight");
				ParentBone("ArmRight", "ForearmRight");
				ParentBone("ForearmRight", "ElbowRight");
				ParentBone("ForearmRight", "WristRight");
				ParentBone("ForearmRight", "ShieldRight");
				ParentBone("ForearmRight", "CouterRight");
				ParentBone("ForearmRight", "HandRight");
				ParentBone("HandRight", "WeaponRight");
				ParentBone("HandRight", "ThumbARight");
				ParentBone("ThumbARight", "ThumbBRight");
				ParentBone("HandRight", "IndexARight");
				ParentBone("IndexARight", "IndexBRight");
				ParentBone("HandRight", "MiddleARight");
				ParentBone("MiddleARight", "MiddleBRight");
				ParentBone("HandRight", "RingARight");
				ParentBone("RingARight", "RingBRight");
				ParentBone("HandRight", "PinkyARight");
				ParentBone("PinkyARight", "PinkyBRight");

				// lower half bones tree
				ParentBone("Root", "Waist");
				ParentBone("Waist", "SheatheLeft");
				ParentBone("Waist", "SheatheRight");
				ParentBone("Waist", "HolsterLeft");
				ParentBone("Waist", "HolsterRight");
				ParentBone("Waist", "LegLeft");
				ParentBone("LegLeft", "KneeLeft");
				ParentBone("KneeLeft", "PoleynLeft");
				ParentBone("KneeLeft", "CalfLeft");
				ParentBone("KneeLeft", "FootLeft");
				ParentBone("FootLeft", "ToesLeft");
				ParentBone("Waist", "LegRight");
				ParentBone("LegRight", "KneeRight");
				ParentBone("KneeRight", "PoleynRight");
				ParentBone("KneeRight", "CalfRight");
				ParentBone("KneeRight", "FootRight");
				ParentBone("FootRight", "ToesRight");

				// tail bones tree
				ParentBone("Waist", "TailA");
				ParentBone("TailA", "TailB");
				ParentBone("TailB", "TailC");
				ParentBone("TailC", "TailD");
			}

			private static void ParentBone(string parentName, string childName)
			{
				Bone parent = GetBone(parentName);
				Bone child = GetBone(childName);

				if (parent.Children.Contains(child) || child.Parent == parent)
				{
					Console.WriteLine("Duplicate parenting: " + parentName + " - " + childName);
					return;
				}

				if (child.Parent != null)
					throw new Exception("Attempt to parent bone: " + childName + " to multiple parents: " + parentName + " and " + bones[childName].Parent);

				parent.Children.Add(child);
				child.Parent = parent;
			}

			private static Bone GetBone(string name)
			{
				if (!bones.ContainsKey(name))
					throw new Exception("Unable to locate bone: \"" + name + "\"");

				return bones[name];
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

				public List<Bone> Children = new List<Bone>();
				public Bone Parent;

				private Quaternion oldQuaternion = Quaternion.Identity;
				private Quaternion quaternion = Quaternion.Identity;
				private Vector3D euler;

				private string xAddr;
				private string yAddr;
				private string zAddr;
				private string wAddr;

				public Bone(string boneName)
				{
					this.BoneName = boneName;
				}

				public double X 
				{ 
					get
					{
						return this.euler.X;
					}

					set
					{
						this.euler.X = value;
					}
				}

				public double Y
				{
					get
					{
						return this.euler.Y;
					}

					set
					{
						this.euler.Y = value;
						
					}
				}

				public double Z
				{
					get
					{
						return this.euler.Z;
					}

					set
					{
						this.euler.Z = value;
					}
				}

				public void GetRotation(bool suppressPropertyChanged = false)
				{
					Mem mem = MemoryManager.Instance.MemLib;

					GetAddress();
					byte[] bytearray = mem.readBytes(this.xAddr, 16);

					this.quaternion.X = BitConverter.ToSingle(bytearray, 0);
					this.quaternion.Y = BitConverter.ToSingle(bytearray, 4);
					this.quaternion.Z = BitConverter.ToSingle(bytearray, 8);
					this.quaternion.W = BitConverter.ToSingle(bytearray, 12);
					this.euler = this.quaternion.ToEulerAngles();

					if (!suppressPropertyChanged)
					{
						this.X = euler.X;
						this.Y = euler.Y;
						this.Z = euler.Z;
					}

					this.oldQuaternion = this.quaternion;
				}

				public void SetRotation()
				{
					this.quaternion = this.euler.ToQuaternion();

					if (this.oldQuaternion == this.quaternion)
						return;

					this.WriteRotation();

					this.oldQuaternion.Conjugate();

					foreach (Bone child in this.Children)
					{
						child.Rotate(this.oldQuaternion, this.quaternion);
					}

					this.oldQuaternion = this.quaternion;
				}

				private void WriteRotation()
				{
					Mem mem = MemoryManager.Instance.MemLib;
					GetAddress();
					mem.writeBytes(this.xAddr, BitConverter.GetBytes((float)this.quaternion.X));
					mem.writeBytes(this.yAddr, BitConverter.GetBytes((float)this.quaternion.Y));
					mem.writeBytes(this.zAddr, BitConverter.GetBytes((float)this.quaternion.Z));
					mem.writeBytes(this.wAddr, BitConverter.GetBytes((float)this.quaternion.W));
				}

				private void Rotate(Quaternion sourceOldCnj, Quaternion sourceNew)
				{
					this.GetRotation(true);

					this.oldQuaternion = this.quaternion;
					this.quaternion = sourceNew * (sourceOldCnj * this.quaternion);
					this.euler = this.quaternion.ToEulerAngles();

					this.WriteRotation();

					foreach (Bone child in this.Children)
					{
						child.Rotate(sourceOldCnj, sourceNew);
					}
				}

				private void GetAddress()
				{
					if (this.xAddr == null)
					{
						this.xAddr = PoseViewModel.GetAddressString(BoneName, "X");
						this.yAddr = PoseViewModel.GetAddressString(BoneName, "Y");
						this.zAddr = PoseViewModel.GetAddressString(BoneName, "Z");
						this.wAddr = PoseViewModel.GetAddressString(BoneName, "W");
					}
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
