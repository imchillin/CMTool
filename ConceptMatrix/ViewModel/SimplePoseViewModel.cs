using ConceptMatrix.Models;
using ConceptMatrix.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

namespace ConceptMatrix.ViewModel
{
	public class SimplePoseViewModel : BaseModel
	{
		private Dictionary<string, Bone> bones;
		private Bone currentBone;

		public CharacterDetails Character { get; set; }

		public Bone CurrentBone 
		{ 
			get
			{
				return this.currentBone;
			}

			set
			{
				// Ensure we have written any pending rotations before changing bone targets
				if (this.currentBone != null)
					this.currentBone.SetRotation();

				// Ensure we have the correct rotation for a bone before we edit it
				if (value != null)
					value.GetRotation();

				this.currentBone = value;
			}
		}

		public Bone MouseOverBone { get; set; }

		public IEnumerable<Bone> Bones
		{
			get
			{
				return bones.Values;
			}
		}

		public SimplePoseViewModel(CharacterDetails character)
		{
			this.Character = character;
			GenerateBones();
		}

		public bool GetIsBoneSelected(Bone bone)
		{
			return this.CurrentBone == bone;
		}

		public bool GetIsBoneParentsSelected(Bone bone)
		{
			if (this. GetIsBoneSelected(bone))
				return true;

			if (bone.Parent != null)
			{
				return GetIsBoneParentsSelected(bone.Parent);
			}

			return false;
		}

		public bool GetIsBoneHovered(Bone bone)
		{
			return this.MouseOverBone == bone;
		}

		public bool GetIsBoneParentsHovered(Bone bone)
		{
			if (this.GetIsBoneHovered(bone))
				return true;

			if (bone.Parent != null)
			{
				return GetIsBoneParentsHovered(bone.Parent);
			}

			return false;
		}

		// gets all bones defined in BonesOffsets.
		private void GenerateBones()
		{
			this.bones = new Dictionary<string, Bone>();
			CharacterOffsets c = Settings.Instance.Character;
			PropertyInfo[] boneProperties = typeof(BonesOffsets).GetProperties();
			foreach (PropertyInfo boneProperty in boneProperties)
			{
				string[] parts = boneProperty.Name.Split('_');

				if (parts.Length != 2)
					continue;

				string boneName = parts[0];

				if (!this.bones.ContainsKey(boneName))
				{
					this.bones[boneName] = new Bone(boneName);
				}
			}

			// now that we have all the bones, we make a hierarchy
			// torso tree
			this.ParentBone("Root", "SpineA");
			this.ParentBone("SpineA", "SpineB");
			this.ParentBone("SpineB", "SpineC");
			this.ParentBone("SpineC", "Neck");
			this.ParentBone("Neck", "Head");
			this.ParentBone("SpineB", "BreastLeft");
			this.ParentBone("SpineB", "BreastRight");
			this.ParentBone("SpineB", "ScabbardLeft");
			this.ParentBone("SpineB", "ScabbardRight");

			// clothes tree
			this.ParentBone("SpineA", "ClothBackALeft");
			this.ParentBone("ClothBackALeft", "ClothBackBLeft");
			this.ParentBone("ClothBackBLeft", "ClothBackCLeft");
			this.ParentBone("SpineA", "ClothBackARight");
			this.ParentBone("ClothBackARight", "ClothBackBRight");
			this.ParentBone("ClothBackBRight", "ClothBackCRight");
			this.ParentBone("SpineA", "ClothSideALeft");
			this.ParentBone("ClothSideALeft", "ClothSideBLeft");
			this.ParentBone("ClothSideBLeft", "ClothSideCLeft");
			this.ParentBone("SpineA", "ClothSideARight");
			this.ParentBone("ClothSideARight", "ClothSideBRight");
			this.ParentBone("ClothSideBRight", "ClothSideCRight");
			this.ParentBone("SpineA", "ClothFrontALeft");
			this.ParentBone("ClothFrontALeft", "ClothFrontBLeft");
			this.ParentBone("ClothFrontBLeft", "ClothFrontCLeft");
			this.ParentBone("SpineA", "ClothFrontARight");
			this.ParentBone("ClothFrontARight", "ClothFrontBRight");
			this.ParentBone("ClothFrontBRight", "ClothFrontCRight");

			// Facebone (middy) tree
			this.ParentBone("Head", "Nose");
			this.ParentBone("Head", "Jaw");
			this.ParentBone("Head", "EyelidLowerLeft");
			this.ParentBone("Head", "EyelidLowerRight");
			this.ParentBone("Head", "EyeLeft");
			this.ParentBone("Head", "EyeRight");
			this.ParentBone("Head", "EarLeft");
			this.ParentBone("EarLeft", "EarringALeft");
			this.ParentBone("EarringALeft", "EarringBLeft");
			this.ParentBone("Head", "EarRight");
			this.ParentBone("EarRight", "EarringARight");
			this.ParentBone("EarringARight", "EarringBRight");
			this.ParentBone("Head", "HairFrontLeft");
			this.ParentBone("Head", "HairFrontRight");
			this.ParentBone("Head", "HairA");
			this.ParentBone("Head", "HairB");
			this.ParentBone("Head", "CheekLeft");
			this.ParentBone("Head", "CheekRight");
			this.ParentBone("Head", "LipsLeft");
			this.ParentBone("Head", "LipsRight");
			this.ParentBone("Head", "EyebrowLeft");
			this.ParentBone("Head", "EyebrowRight");
			this.ParentBone("Head", "Bridge");
			this.ParentBone("Head", "BrowLeft");
			this.ParentBone("Head", "BrowRight");
			this.ParentBone("Head", "LipUpperA");
			this.ParentBone("Head", "EyelidUpperLeft");
			this.ParentBone("Head", "EyelidUpperRight");
			this.ParentBone("Jaw", "LipLowerA");
			this.ParentBone("Head", "LipUpperB");
			this.ParentBone("LipLowerA", "LipLowerB");

			this.ParentBone("Head", "ExHairA");
			this.ParentBone("Head", "ExHairB");
			this.ParentBone("Head", "ExHairC");
			this.ParentBone("Head", "ExHairD");
			this.ParentBone("Head", "ExHairE");
			this.ParentBone("Head", "ExHairF");
			this.ParentBone("Head", "ExHairG");
			this.ParentBone("Head", "ExHairH");
			this.ParentBone("Head", "ExHairI");
			this.ParentBone("Head", "ExHairJ");
			this.ParentBone("Head", "ExHairK");
			this.ParentBone("Head", "ExHairL");

			// Facebone hroth tree
			/*this.ParentBone("Head", "HrothEyebrowLeft");
			this.ParentBone("Head", "HrothEyebrowRight");
			this.ParentBone("Head", "HrothBridge");
			this.ParentBone("Head", "HrothBrowLeft");
			this.ParentBone("Head", "HrothBrowRight");
			this.ParentBone("Head", "HrothJawUpper");
			this.ParentBone("Head", "HrothLipUpper");
			this.ParentBone("Head", "HrothEyelidUpperLeft");
			this.ParentBone("Head", "HrothEyelidUpperRight");
			this.ParentBone("Head", "HrothLipsLeft");
			this.ParentBone("Head", "HrothLipsRight");
			this.ParentBone("Head", "HrothLipUpperLeft");
			this.ParentBone("Head", "HrothLipUpperRight");
			this.ParentBone("Head", "HrothLipLower");
			this.ParentBone("Head", "HrothWhiskersLeft");
			this.ParentBone("Head", "HrothWhiskersRight");*/

			// Facebone Viera tree
			this.ParentBone("Head", "VieraLipLowerA");
			this.ParentBone("Head", "VieraLipLowerB");
			this.ParentBone("Head", "VieraLipUpperB");
			////this.ParentBone("Head", "VieraEar01ALeft");
			////this.ParentBone("Head", "VieraEar02ALeft");
			////this.ParentBone("Head", "VieraEar03ALeft");
			////this.ParentBone("Head", "VieraEar04ALeft");
			this.ParentBone("Head", "VieraEar01ARight");
			this.ParentBone("Head", "VieraEar02ARight");
			this.ParentBone("Head", "VieraEar03ARight");
			this.ParentBone("Head", "VieraEar04ARight");
			this.ParentBone("VieraEar01ALeft", "VieraEar01BLeft");
			this.ParentBone("VieraEar02ALeft", "VieraEar02BLeft");
			this.ParentBone("VieraEar03ALeft", "VieraEar03BLeft");
			this.ParentBone("VieraEar04ALeft", "VieraEar04BLeft");
			this.ParentBone("VieraEar01ARight", "VieraEar01BRight");
			this.ParentBone("VieraEar02ARight", "VieraEar02BRight");
			this.ParentBone("VieraEar03ARight", "VieraEar03BRight");
			this.ParentBone("VieraEar04ARight", "VieraEar04BRight");

			// armbone tree
			this.ParentBone("SpineC", "ClavicleLeft");
			this.ParentBone("ClavicleLeft", "ArmLeft");
			this.ParentBone("ArmLeft", "ShoulderLeft");
			this.ParentBone("ArmLeft", "PauldronLeft");
			this.ParentBone("ArmLeft", "ForearmLeft");
			this.ParentBone("ForearmLeft", "ElbowLeft");
			this.ParentBone("ForearmLeft", "WristLeft");
			this.ParentBone("ForearmLeft", "ShieldLeft");
			this.ParentBone("ForearmLeft", "CouterLeft");
			this.ParentBone("ForearmLeft", "WristLeft");
			this.ParentBone("HandLeft", "WeaponLeft");
			this.ParentBone("HandLeft", "ThumbALeft");
			this.ParentBone("ThumbALeft", "ThumbBLeft");
			this.ParentBone("WristLeft", "HandLeft");
			this.ParentBone("HandLeft", "IndexALeft");
			this.ParentBone("IndexALeft", "IndexBLeft");
			this.ParentBone("HandLeft", "MiddleALeft");
			this.ParentBone("MiddleALeft", "MiddleBLeft");
			this.ParentBone("HandLeft", "RingALeft");
			this.ParentBone("RingALeft", "RingBLeft");
			this.ParentBone("HandLeft", "PinkyALeft");
			this.ParentBone("PinkyALeft", "PinkyBLeft");

			this.ParentBone("SpineC", "ClavicleRight");
			this.ParentBone("ClavicleRight", "ArmRight");
			this.ParentBone("ArmRight", "ShoulderRight");
			this.ParentBone("ArmRight", "PauldronRight");
			this.ParentBone("ArmRight", "ForearmRight");
			this.ParentBone("ForearmRight", "ElbowRight");
			this.ParentBone("ForearmRight", "WristRight");
			this.ParentBone("ForearmRight", "ShieldRight");
			this.ParentBone("ForearmRight", "CouterRight");
			this.ParentBone("ForearmRight", "WristRight");
			this.ParentBone("WristRight", "HandRight");
			this.ParentBone("HandRight", "WeaponRight");
			this.ParentBone("HandRight", "ThumbARight");
			this.ParentBone("ThumbARight", "ThumbBRight");
			this.ParentBone("HandRight", "IndexARight");
			this.ParentBone("IndexARight", "IndexBRight");
			this.ParentBone("HandRight", "MiddleARight");
			this.ParentBone("MiddleARight", "MiddleBRight");
			this.ParentBone("HandRight", "RingARight");
			this.ParentBone("RingARight", "RingBRight");
			this.ParentBone("HandRight", "PinkyARight");
			this.ParentBone("PinkyARight", "PinkyBRight");

			// lower half bones tree
			this.ParentBone("Root", "Waist");
			this.ParentBone("Waist", "SheatheLeft");
			this.ParentBone("Waist", "SheatheRight");
			this.ParentBone("Waist", "HolsterLeft");
			this.ParentBone("Waist", "HolsterRight");
			this.ParentBone("Waist", "LegLeft");
			this.ParentBone("CalfLeft", "KneeLeft");
			this.ParentBone("KneeLeft", "PoleynLeft");
			this.ParentBone("LegLeft", "CalfLeft");
			this.ParentBone("CalfLeft", "FootLeft");
			this.ParentBone("FootLeft", "ToesLeft");
			this.ParentBone("Waist", "LegRight");
			this.ParentBone("CalfRight", "KneeRight");
			this.ParentBone("KneeRight", "PoleynRight");
			this.ParentBone("LegRight", "CalfRight");
			this.ParentBone("CalfRight", "FootRight");
			this.ParentBone("FootRight", "ToesRight");

			// tail bones tree
			this.ParentBone("Waist", "TailA");
			this.ParentBone("TailA", "TailB");
			this.ParentBone("TailB", "TailC");
			this.ParentBone("TailC", "TailD");
		}

		private void ParentBone(string parentName, string childName)
		{
			Bone parent = this.GetBone(parentName);
			Bone child = this.GetBone(childName);

			if (parent.Children.Contains(child) || child.Parent == parent)
			{
				Console.WriteLine("Duplicate parenting: " + parentName + " - " + childName);
				return;
			}

			if (child.Parent != null)
				throw new Exception("Attempt to parent bone: " + childName + " to multiple parents: " + parentName + " and " + bones[childName].Parent.BoneName);

			parent.Children.Add(child);
			child.Parent = parent;
		}

		public Bone GetBone(string name)
		{
			if (this.bones == null)
				throw new Exception("Bones not generated");

			if (!this.bones.ContainsKey(name))
				throw new Exception("Unable to locate bone: \"" + name + "\"");

			return this.bones[name];
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
					this.xAddr = SimplePoseViewModel.GetAddressString(BoneName, "X");
					this.yAddr = SimplePoseViewModel.GetAddressString(BoneName, "Y");
					this.zAddr = SimplePoseViewModel.GetAddressString(BoneName, "Z");
					this.wAddr = SimplePoseViewModel.GetAddressString(BoneName, "W");
				}
			}
		}
	}
}
