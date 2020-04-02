using ConceptMatrix.Models;
using ConceptMatrix.Resx;
using ConceptMatrix.ThreeD;
using ConceptMatrix.Utility;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Threading;
using System.Windows;
using System.Windows.Media.Media3D;
using static ConceptMatrix.ViewModel.SimplePoseViewModel.Bone;

namespace ConceptMatrix.ViewModel
{
	public class SimplePoseViewModel : INotifyPropertyChanged
	{
		private Dictionary<string, Bone> bones;
		private Bone currentBone;
		private bool enabled;

		public event PropertyChangedEventHandler PropertyChanged;

		public CharacterDetails Character { get; set; }

		public bool IsEnabled 
		{ 
			get
			{
				return this.enabled;
			}

			set
			{
				this.CurrentBone = null;
				this.enabled = value;

				MemoryManager mem = MemoryManager.Instance;

				// Not sure I want both simple pose and pose matrix trying to edit bones at the same time.
				////CharacterDetails.BoneEditMode = this.enabled;

				if (this.enabled)
				{
					mem.MemLib.writeMemory(mem.SkeletonAddress, "bytes", "0x90 0x90 0x90 0x90 0x90 0x90");
					mem.MemLib.writeMemory(mem.SkeletonAddress2, "bytes", "0x90 0x90 0x90 0x90 0x90 0x90");
					mem.MemLib.writeMemory(mem.SkeletonAddress3, "bytes", "0x90 0x90 0x90 0x90");
					mem.MemLib.writeMemory(mem.PhysicsAddress, "bytes", "0x90 0x90 0x90 0x90");
					mem.MemLib.writeMemory(mem.PhysicsAddress2, "bytes", "0x90 0x90 0x90");

					ThreadStart ts = new ThreadStart(this.WatchCamera);
					Thread t = new Thread(ts);
					t.Start();
				}
				else
				{
					mem.MemLib.writeMemory(mem.SkeletonAddress, "bytes", "0x41 0x0F 0x29 0x5C 0x12 0x10");
					mem.MemLib.writeMemory(mem.SkeletonAddress2, "bytes", "0x43 0x0F 0x29 0x5C 0x18 0x10");
					mem.MemLib.writeMemory(mem.SkeletonAddress3, "bytes", "0x0F 0x29 0x5E 0x10");
					mem.MemLib.writeMemory(mem.PhysicsAddress, "bytes", "0x0F 0x29 0x48 0x10");
					mem.MemLib.writeMemory(mem.PhysicsAddress2, "bytes", "0x0F 0x29 0x00");
				}
			}
		}

		public bool FlipSides
		{
			get;
			set;
		}

		public Bone CurrentBone 
		{ 
			get
			{
				return this.currentBone;
			}

			set
			{
				if (!this.IsEnabled)
					return;

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

		public Quaternion CameraRotation
		{
			get;
			set;
		}

		[DependsOn(nameof(Character))]
		public bool HasTail
		{
			get
			{
				if (this.Character == null)
					return false;

				return this.Character.Race.value == 4 || this.Character.Race.value == 6 || this.Character.Race.value == 7;
			}
		}

		[DependsOn(nameof(Character))]
		public bool IsViera
		{
			get
			{
				if (this.Character == null)
					return false;

				return this.Character.Race.value == 8;
			}
		}

		[DependsOn(nameof(Character))]
		public bool IsVieraEars01
		{
			get
			{
				if (this.Character == null)
					return false;

				return this.Character.Race.value == 8 && this.Character.TailType.value <= 1;
			}
		}

		[DependsOn(nameof(Character))]
		public bool IsVieraEars02
		{
			get
			{
				if (this.Character == null)
					return false;

				return this.Character.Race.value == 8 && this.Character.TailType.value == 2;
			}
		}

		[DependsOn(nameof(Character))]
		public bool IsVieraEars03
		{
			get
			{
				if (this.Character == null)
					return false;

				return this.Character.Race.value == 8 && this.Character.TailType.value == 3;
			}
		}

		[DependsOn(nameof(Character))]
		public bool IsVieraEars04
		{
			get
			{
				if (this.Character == null)
					return false;

				return this.Character.Race.value == 8 && this.Character.TailType.value == 4;
			}
		}

		[DependsOn(nameof(Character))]
		public bool IsHrothgar
		{
			get
			{
				if (this.Character == null)
					return false;

				return this.Character.Race.value == 7;
			}
		}

		[DependsOn(nameof(Character))]
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

		public static string GetBoneName(string name, bool flip)
		{
			if (flip)
			{
				// flip left and right side bones
				if (name.Contains("Left"))
					return name.Replace("Left", "Right");

				if (name.Contains("Right"))
					return name.Replace("Right", "Left");
			}

			return name;
		}

		public void Refresh()
		{
			GenerateBones();

			this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Character)));
			this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Bones)));
			this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.HasTail)));
			this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.IsViera)));
			this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.IsVieraEars01)));
			this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.IsVieraEars02)));
			this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.IsVieraEars03)));
			this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.IsVieraEars04)));
			this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.IsHrothgar)));
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
				if (!boneProperty.Name.Contains("_X"))
					continue;

				string boneName = boneProperty.Name.Replace("_X", string.Empty);

				if (this.bones.ContainsKey(boneName))
					throw new Exception("Duplicate bone: \"" + boneName + "\"");
				
				this.bones[boneName] = new Bone(boneName);

				// bit of a hack...
				if (boneName.Contains("Hroth"))
					this.bones[boneName].IsEnabled = this.IsHrothgar;

				if (boneName.Contains("Viera"))
					this.bones[boneName].IsEnabled = this.IsViera;

				if (boneName.Contains("Tail"))
					this.bones[boneName].IsEnabled = this.HasTail;
			}

			// special case for viera lips
			// disable lip bones if vierra, as they have their own set of lip bones...
			this.GetBone("LipLowerA").IsEnabled = !this.IsViera;
			this.GetBone("LipUpperB").IsEnabled = !this.IsViera;
			this.GetBone("LipLowerB").IsEnabled = !this.IsViera;

            // special case for exhair
            int exhair_value = MemoryManager.Instance.MemLib.readByte(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExHair_Value));
            string[] exhair_str = new string[] { "ExHairA", "ExHairB", "ExHairC", "ExHairD", "ExHairE", "ExHairF", "ExHairG", "ExHairH", "ExHairI", "ExHairJ", "ExHairK", "ExHairL" };
            for (int i = exhair_value; i < exhair_str.Length; i++)
            {
                this.GetBone(exhair_str[i]).IsEnabled = false;
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

			// clothes tree
			this.ParentBone("Waist", "ClothBackALeft");
			this.ParentBone("ClothBackALeft", "ClothBackBLeft");
			this.ParentBone("ClothBackBLeft", "ClothBackCLeft");
			this.ParentBone("Waist", "ClothBackARight");
			this.ParentBone("ClothBackARight", "ClothBackBRight");
			this.ParentBone("ClothBackBRight", "ClothBackCRight");
			this.ParentBone("Waist", "ClothSideALeft");
			this.ParentBone("ClothSideALeft", "ClothSideBLeft");
			this.ParentBone("ClothSideBLeft", "ClothSideCLeft");
			this.ParentBone("Waist", "ClothSideARight");
			this.ParentBone("ClothSideARight", "ClothSideBRight");
			this.ParentBone("ClothSideBRight", "ClothSideCRight");
			this.ParentBone("Waist", "ClothFrontALeft");
			this.ParentBone("ClothFrontALeft", "ClothFrontBLeft");
			this.ParentBone("ClothFrontBLeft", "ClothFrontCLeft");
			this.ParentBone("Waist", "ClothFrontARight");
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
			this.ParentBone("HairA", "HairB");
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

            for (int i = 0; i < exhair_str.Length; i++)
            {
                this.ParentBone("Head", exhair_str[i]);
            }

			// Facebone hroth tree
			this.ParentBone("Head", "HrothEyebrowLeft");
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
			this.ParentBone("Head", "HrothWhiskersRight");

			// Facebone Viera tree
			this.ParentBone("Jaw", "VieraLipLowerA");
			this.ParentBone("Jaw", "VieraLipLowerB");
			this.ParentBone("Head", "VieraLipUpperB");
			this.ParentBone("Head", "VieraEar01ALeft");
			this.ParentBone("Head", "VieraEar02ALeft");
			this.ParentBone("Head", "VieraEar03ALeft");
			this.ParentBone("Head", "VieraEar04ALeft");
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


			this.ParentBone("SpineB", "SheatheLeft");
			this.ParentBone("SpineB", "SheatheRight");
			this.ParentBone("SheatheLeft", "HolsterLeft");
			this.ParentBone("SheatheRight", "HolsterRight");
			this.ParentBone("SheatheLeft", "ScabbardLeft");
			this.ParentBone("SheatheRight", "ScabbardRight");

			// tail bones tree
			this.ParentBone("Waist", "TailA");
			this.ParentBone("TailA", "TailB");
			this.ParentBone("TailB", "TailC");
			this.ParentBone("TailC", "TailD");
			this.ParentBone("TailD", "TailE");
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
		private static string GetAddressString(string boneName)
		{
			Mem mem = MemoryManager.Instance.MemLib;
			CharacterOffsets c = Settings.Instance.Character;

			string propertyName = boneName + "_X";
			PropertyInfo property = c.Body.Bones.GetType().GetProperty(propertyName);

			if (property == null)
				throw new Exception("Failed to get bone axis: \"" + propertyName + "\"");

			string offsetString = (string)property.GetValue(c.Body.Bones);
			return MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, c.Body.Base, offsetString);
		}

		private void WatchCamera()
		{
			string addressStr = MemoryManager.GetAddressString(MemoryManager.Instance.CameraAddress, Settings.Instance.Character.CamAngleX);
			UIntPtr address = MemoryManager.Instance.MemLib.get64bitCode(addressStr);
			FloatMemory xMem = new FloatMemory(address);

			addressStr = MemoryManager.GetAddressString(MemoryManager.Instance.CameraAddress, Settings.Instance.Character.CamAngleY);
			address = MemoryManager.Instance.MemLib.get64bitCode(addressStr);
			FloatMemory yMem = new FloatMemory(address);

			addressStr = MemoryManager.GetAddressString(MemoryManager.Instance.CameraAddress, Settings.Instance.Character.CameraHeight2); //!?
			address = MemoryManager.Instance.MemLib.get64bitCode(addressStr);
			FloatMemory zMem = new FloatMemory(address);

			

			while (this.IsEnabled && Application.Current != null)
			{
				Vector3D camEuler = new Vector3D();

				camEuler.Y = MathUtils.RadiansToDegrees(xMem.Get());
				camEuler.Z = -MathUtils.RadiansToDegrees(yMem.Get());
				camEuler.X = MathUtils.RadiansToDegrees(zMem.Get());

				try
				{
					Application.Current.Dispatcher.Invoke(() =>
					{
						this.CameraRotation = camEuler.ToQuaternion();
					});
				}
				catch (Exception)
				{
				}

				Thread.Sleep(32);
			}
		}

		public class Bone : INotifyPropertyChanged
		{
			public string BoneName{ get; private set; }
			public bool IsEnabled { get; set; } = true;

			public List<Bone> Children = new List<Bone>();
			public Bone Parent;

			private QuaternionMemory rotationMemory;

			public event PropertyChangedEventHandler PropertyChanged;

			public Bone(string boneName)
			{
				this.BoneName = boneName;
			}

			public Quaternion Rotation { get; set; }

			public string Tooltip
			{
				get
				{
					return Strings.GetString<UISimplePoseStrings>(this.BoneName + "_Tooltip");
				}
			}

			public QuaternionMemory RotationMemory
			{
				get
				{
					if (this.rotationMemory == null)
					{
						UIntPtr address = MemoryManager.Instance.MemLib.get64bitCode(SimplePoseViewModel.GetAddressString(BoneName));
						this.rotationMemory = new QuaternionMemory(address);
					}

					return this.rotationMemory;
				}
			}

			public void GetRotation()
			{
				this.Rotation = this.RotationMemory.Get();
			}

			public void SetRotation()
			{
				if (!this.IsEnabled)
					return;

				if (this.RotationMemory.Value == this.Rotation)
					return;

				Quaternion newRotation = this.Rotation;

				Quaternion oldrotation = this.rotationMemory.Get();
				this.RotationMemory.Set(newRotation);
				Quaternion oldRotationConjugate = oldrotation;
				oldRotationConjugate.Conjugate();

				foreach (Bone child in this.Children)
				{
					child.Rotate(oldRotationConjugate, newRotation);
				}
			}

			private void Rotate(Quaternion sourceOldCnj, Quaternion sourceNew)
			{
				if (!this.IsEnabled)
					return;

				this.Rotation = this.RotationMemory.Get();
				Quaternion newRotation = sourceNew * (sourceOldCnj * this.Rotation);

				if (this.Rotation == newRotation)
					return;

				this.Rotation = newRotation;
				this.RotationMemory.Set(this.Rotation);

				foreach (Bone child in this.Children)
				{
					child.Rotate(sourceOldCnj, sourceNew);
				}
			}

			public abstract class Memory<T>
			{
				protected UIntPtr address;

				public Memory(UIntPtr address)
				{
					this.address = address;
				}

				public T Value { get; private set; }

				/// <summary>
				/// Gets the current value from the process.
				/// </summary
				public T Get()
				{
					T newValue = this.Read(MemoryManager.Instance.MemLib);
					this.Value = newValue;
					return newValue;
				}

				/// <summary>
				/// Writes a new value to the process, and returns the old value.
				/// </summary
				public void Set(T value)
				{
					T oldValue = this.Value;
					this.Write(value, MemoryManager.Instance.MemLib);
					this.Value = value;
				}

				protected abstract T Read( Mem memory);
				protected abstract void Write(T value, Mem memory);
			}

			public class QuaternionMemory : Memory<Quaternion>
			{
				public QuaternionMemory(UIntPtr address)
					: base(address)
				{
				}

				protected override Quaternion Read(Mem memory)
				{
					byte[] bytearray = memory.readBytes(this.address, 16);

					Quaternion value = new Quaternion();
					value.X = BitConverter.ToSingle(bytearray, 0);
					value.Y = BitConverter.ToSingle(bytearray, 4);
					value.Z = BitConverter.ToSingle(bytearray, 8);
					value.W = BitConverter.ToSingle(bytearray, 12);
					return value;
				}

				protected override void Write(Quaternion value, Mem memory)
				{
					byte[] bytearray = new byte[16];
					Array.Copy(BitConverter.GetBytes((float)value.X), bytearray, 4);
					Array.Copy(BitConverter.GetBytes((float)value.Y), 0, bytearray, 4, 4);
					Array.Copy(BitConverter.GetBytes((float)value.Z), 0, bytearray, 8, 4);
					Array.Copy(BitConverter.GetBytes((float)value.W), 0, bytearray, 12, 4);
					memory.writeBytes(this.address, bytearray);
				}
			}

			public class FloatMemory : Memory<float>
			{
				public FloatMemory(UIntPtr address)
					: base(address)
				{
				}

				protected override float Read(Mem memory)
				{
					byte[] bytearray = memory.readBytes(this.address, 4);
					return BitConverter.ToSingle(bytearray, 0);
				}

				protected override void Write(float value, Mem memory)
				{
					memory.writeBytes(this.address, BitConverter.GetBytes(value));
				}
			}
		}
	}
}
