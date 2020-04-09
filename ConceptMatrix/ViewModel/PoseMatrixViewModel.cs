﻿using ConceptMatrix.Models;
using ConceptMatrix.Utility;
using ConceptMatrix.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

namespace ConceptMatrix.ViewModel
{
    public class PoseMatrixViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public CharacterDetails CharacterDetails { get => (CharacterDetails)BaseViewModel.model; set => BaseViewModel.model = value; }

        private readonly Mem Memory = MemoryManager.Instance.MemLib;
        private string GAS(params string[] args) => MemoryManager.GetAddressString(args);

        public BoneNodes bonetree = null;

        public BoneNodes BNode = null;

        public string TheButton = null;
        public int PointerType { get; set; } = 0;
        public float BoneX { get; set; }
        public float UserBoneX
        {
            get => BoneX;
            set
            {
                BoneX = value;
                RotateHelper();
            }
        }

        public float BoneY { get; set; }
        public float UserBoneY
        {
            get => BoneY;
            set
            {
                BoneY = value;
                RotateHelper();
            }
        }

        public float BoneZ { get; set; }
        public float UserBoneZ
        {
            get => BoneZ;
            set
            {
                BoneZ = value;
                RotateHelper();
            }
        }
        public float CubeBone_X { get; set; }
        public float CubeBone_Y { get; set; }
        public float CubeBone_Z { get; set; }
        public float CubeBone_W { get; set; }

        private string pointerPath;
        public string PointerPath
        {
            get => pointerPath;
            set
            {
                pointerPath = value;
                BoneX = 0;
                BoneY = 0;
                BoneZ = 0;
                CubeBone_X = 0;
                CubeBone_Y = 0;
                CubeBone_Z = 0;
                CubeBone_W = 0;

                if (value != null)
                {
                    byte[] bytearray = Memory.readBytes(GAS(CharacterDetailsViewModel.baseAddr, value), 16);
                    if (PointerType > 0)
                    {
                        if (PointerType == 1)
                        {
                            PoseMatrixView.PosingMatrix.XUpDown.Minimum = -10;
                            PoseMatrixView.PosingMatrix.XUpDown.Maximum = 10;
                            PoseMatrixView.PosingMatrix.YUpDown.Maximum = 10;
                            PoseMatrixView.PosingMatrix.YUpDown.Minimum = -10;
                            PoseMatrixView.PosingMatrix.ZUpDown.Maximum = 10;
                            PoseMatrixView.PosingMatrix.ZUpDown.Minimum = -10;
                            PoseMatrixView.PosingMatrix.BoneSliderX.Maximum = 10;
                            PoseMatrixView.PosingMatrix.BoneSliderX.Minimum = -10;
                            PoseMatrixView.PosingMatrix.BoneSliderY.Maximum = 10;
                            PoseMatrixView.PosingMatrix.BoneSliderY.Minimum = -10;
                            PoseMatrixView.PosingMatrix.BoneSliderZ.Maximum = 10;
                            PoseMatrixView.PosingMatrix.BoneSliderZ.Minimum = -10;
                            PoseMatrixView.PosingMatrix.Cube.IsEnabled = false;
                        }
                        else
                        {
                            PoseMatrixView.PosingMatrix.XUpDown.Minimum = float.MinValue;
                            PoseMatrixView.PosingMatrix.XUpDown.Maximum = float.MaxValue;
                            PoseMatrixView.PosingMatrix.YUpDown.Maximum = float.MaxValue;
                            PoseMatrixView.PosingMatrix.YUpDown.Minimum = float.MinValue;
                            PoseMatrixView.PosingMatrix.ZUpDown.Maximum = float.MaxValue;
                            PoseMatrixView.PosingMatrix.ZUpDown.Minimum = float.MinValue;
                            PoseMatrixView.PosingMatrix.BoneSliderX.IsEnabled = false;
                            PoseMatrixView.PosingMatrix.BoneSliderY.IsEnabled = false;
                            PoseMatrixView.PosingMatrix.BoneSliderZ.IsEnabled = false;
                            PoseMatrixView.PosingMatrix.Cube.IsEnabled = false;
                        }
                        BoneX = BitConverter.ToSingle(bytearray, 0);
                        BoneY = BitConverter.ToSingle(bytearray, 4);
                        BoneZ = BitConverter.ToSingle(bytearray, 8);
                    }
                    else
                    {
                        var euler = new Quaternion(
                        BitConverter.ToSingle(bytearray, 0),
                        BitConverter.ToSingle(bytearray, 4),
                        BitConverter.ToSingle(bytearray, 8),
                        BitConverter.ToSingle(bytearray, 12)).ToEulerAngles();
                        newrot = new Vector3D((float)euler.X, (float)euler.Y, (float)euler.Z);
                        BoneX = (float)euler.X;
                        BoneY = (float)euler.Y;
                        BoneZ = (float)euler.Z;
                        CubeBone_X = BitConverter.ToSingle(bytearray, 0);
                        CubeBone_Y = BitConverter.ToSingle(bytearray, 4);
                        CubeBone_Z = BitConverter.ToSingle(bytearray, 8);
                        CubeBone_W = BitConverter.ToSingle(bytearray, 12);
                    }
                }
            }
        }
        public bool ParentingToggle { get => SaveSettings.Default.RelativeBones; set => SaveSettings.Default.RelativeBones = value; }

        public float BoneInterval { get => SaveSettings.Default.BoneInterval; set => SaveSettings.Default.BoneInterval = value; }

        public bool ReadTetriaryFromRunTime = false;

        public static PoseMatrixViewModel PoseVM;
        enum FaceRace
        {
            Middy,
            Hroth,
            Viera
        }
        private FaceRace face_check = FaceRace.Middy;

        public PoseMatrixViewModel()
        {
            PoseVM = this;
            if (SaveSettings.Default.RelativeBones == true)
            {
                ParentingToggle = true;
            }
        }

        public Vector3D oldrot = new Vector3D(0, 0, 0);
        public Vector3D newrot = new Vector3D(0, 0, 0);

        public Vector3D GetEulerAngles() => new Vector3D(BoneX, BoneY, BoneZ);

        #region Rotation Methods
        public void RotateHelper()
        {
            if (PointerPath == null) return;
            if (PointerType > 0)
            {
                Memory.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, PointerPath), GetBytesX(UserBoneX, UserBoneY, UserBoneZ));
            }
            else
            {
                Quaternion quat = GetEulerAngles().ToQuaternion();
                //     Console.WriteLine($"{(float)quat.X}, {(float)quat.Y}, {(float)quat.Z}, {(float)quat.W}");
                Memory.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, PointerPath), GetBytes(quat));
                CubeBone_X = (float)quat.X;
                CubeBone_Y = (float)quat.Y;
                CubeBone_Z = (float)quat.Z;
                CubeBone_W = (float)quat.W;
                oldrot = newrot;
                newrot = new Vector3D(BoneX, BoneY, BoneZ);
                if (ParentingToggle == true && BNode != null)
                {
                    Bone_Flag_Manager();
                    Quaternion q1_inv = Extensions.QInv(oldrot.ToQuaternion());
                    Quaternion q1_new = newrot.ToQuaternion();
                    Rotate_ChildBone(BNode, q1_inv, q1_new);
                }
            }
        }

        public void RotateHelperQuaternion(Quaternion Rotation)
        {
            if (PointerPath == null) return;
            if (PointerType > 0) return;
            else
            {
                Memory.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, PointerPath), GetBytes(Rotation));
                oldrot = newrot;
                var ConvertToEuler = Rotation.ToEulerAngles();
                BoneX = (float)ConvertToEuler.X;
                BoneY = (float)ConvertToEuler.Y;
                BoneZ = (float)ConvertToEuler.Z;
                newrot = new Vector3D(BoneX, BoneY, BoneZ);
                if (ParentingToggle == true && BNode != null)
                {
                    Bone_Flag_Manager();
                    Quaternion q1_inv = Extensions.QInv(oldrot.ToQuaternion());
                    Rotate_ChildBone(BNode, q1_inv, Rotation);
                }
            }
        }

        public void Rotate_ChildBone(BoneNodes boneParent, Quaternion q1_inv, Quaternion q1_new)
        {
            foreach (BoneNodes boneNode in boneParent)
            {
                ChildBone_Propagator(boneNode, q1_inv, q1_new);
            }
        }
        private void Rotate_UnitBone(string boneOffset, Quaternion q1_inv, Quaternion q1_new)
        {
            byte[] bytearray = Memory.readBytes(GAS(CharacterDetailsViewModel.baseAddr, boneOffset), 16);
            if (bytearray == null) return;
            int ctr = 0;
            while (bytearray.All(singleByte => singleByte == 0) && ctr < 100)
            {
                bytearray = Memory.readBytes(GAS(CharacterDetailsViewModel.baseAddr, boneOffset), 16);
                ctr++;
            }
            Quaternion q2 = new Quaternion(BitConverter.ToSingle(bytearray, 0), BitConverter.ToSingle(bytearray, 4), BitConverter.ToSingle(bytearray, 8), BitConverter.ToSingle(bytearray, 12));
            Quaternion q2_new = Extensions.QuatMult(Extensions.QuatMult(q2, q1_inv), q1_new);
            //  QuatCheck(q2, "q2");
            //  QuatCheck(q1_inv, "q1_inv");
            //  QuatCheck(q1_new, "q1_new");
            Memory.writeBytes(GAS(CharacterDetailsViewModel.baseAddr, boneOffset), GetBytes(q2_new));
        }
        private void ChildBone_Propagator(BoneNodes boneParent, Quaternion q1_inv, Quaternion q1_new)
        {
            Rotate_UnitBone(boneParent.Get(), q1_inv, q1_new);
            Rotate_ChildBone(boneParent, q1_inv, q1_new);
        }

        #endregion

        public void Bone_Flag_Manager()
        {
            if (face_check != FaceRace.Middy && CharacterDetails.Race.value < 7)
            {
                face_check = FaceRace.Middy;
                bone_face = bone_face_middy;
                bone_neck.Remove(bone_face_hroth);
                bone_neck.Remove(bone_face_viera);
                bone_neck.Add(bone_face_middy);
            }
            else if (face_check != FaceRace.Hroth && CharacterDetails.Race.value == 7)
            {
                face_check = FaceRace.Hroth;
                bone_face = bone_face_hroth;
                bone_neck.Remove(bone_face_middy);
                bone_neck.Remove(bone_face_viera);
                bone_neck.Add(bone_face_hroth);
            }
            else if (face_check != FaceRace.Viera && CharacterDetails.Race.value == 8)
            {
                face_check = FaceRace.Viera;
                bone_face = bone_face_viera;
                bone_neck.Remove(bone_face_middy);
                bone_neck.Remove(bone_face_hroth);
                bone_neck.Add(bone_face_viera);
            }
            EnableTertiaryFlags();
        }

        public static byte[] GetBytes(Quaternion q)
        {
            List<byte> bytes = new List<byte>(16);
            bytes.AddRange(BitConverter.GetBytes((float)q.X));
            bytes.AddRange(BitConverter.GetBytes((float)q.Y));
            bytes.AddRange(BitConverter.GetBytes((float)q.Z));
            bytes.AddRange(BitConverter.GetBytes((float)q.W));
            return bytes.ToArray();
        }
        public static byte[] GetBytesX(float X, float Y, float Z)
        {
            List<byte> bytes = new List<byte>(12);
            bytes.AddRange(BitConverter.GetBytes(X));
            bytes.AddRange(BitConverter.GetBytes(Y));
            bytes.AddRange(BitConverter.GetBytes(Z));
            return bytes.ToArray();
        }
        public void EnableTertiaryFlags()
        {
            if (!ReadTetriaryFromRunTime)
            {
                ReadTetriaryFromRunTime = true;
                if (CharacterDetails.Race.value == 4 || CharacterDetails.Race.value == 6 || CharacterDetails.Race.value == 7)
                {
                    PoseMatrixView.PosingMatrix.TailA.IsEnabled = true;
                    PoseMatrixView.PosingMatrix.TailB.IsEnabled = true;
                    PoseMatrixView.PosingMatrix.TailC.IsEnabled = true;
                    PoseMatrixView.PosingMatrix.TailD.IsEnabled = true;
                    PoseMatrixView.PosingMatrix.TailE.IsEnabled = true;
                    bone_waist.Add(bone_tail_a);
                }
                if (CharacterDetails.Race.value == 7)
                {
                    PoseMatrixView.PosingMatrix.HrothWhiskersLeft.IsEnabled = true;
                    PoseMatrixView.PosingMatrix.HrothWhiskersRight.IsEnabled = true;
                }
                if (CharacterDetails.Race.value == 8)
                {
                    PoseMatrixView.PosingMatrix.VieraEarALeft.IsEnabled = true;
                    PoseMatrixView.PosingMatrix.VieraEarARight.IsEnabled = true;
                    PoseMatrixView.PosingMatrix.VieraEarBLeft.IsEnabled = true;
                    PoseMatrixView.PosingMatrix.VieraEarBRight.IsEnabled = true;
                    for (int i = 0; i < bone_viera_ear_l.Length; i++)
                    {
                        bone_face_viera.Remove(bone_viera_ear_l[i]);
                        bone_face_viera.Remove(bone_viera_ear_r[i]);
                    }
                    bone_face_viera.Add(bone_viera_ear_l[CharacterDetails.TailType.value]);
                    bone_face_viera.Add(bone_viera_ear_r[CharacterDetails.TailType.value]);
                }
                #region Exhair
                int exhair_value = Memory.readByte(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExHair_Value));
                for (int i = 0; i < exhair_value - 1; i++)
                {
                    if (i >= 12) break;
                    bone_face.Add(bone_exhair[i]);
                    PoseMatrixView.PosingMatrix.exhair_buttons[i].IsEnabled = true;
                }
                #endregion
                #region ExMet
                int exmet_value = Memory.readByte(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExMet_Value));
                for (int i = 0; i < exmet_value - 1; i++)
                {
                    if (i >= 18) break; // for now keep it like this
                    if (PoseMatrixView.PosingMatrix.HelmToggle.IsChecked == true) bone_face.Add(bone_exmet[i]);

                    PoseMatrixView.PosingMatrix.exmet_buttons[i].IsEnabled = true;
                }
                #endregion
                #region ExTop
                int extop_value = Memory.readByte(GAS(CharacterDetailsViewModel.baseAddr, Settings.Instance.Bones.ExTop_Value));
                for (int i = 0; i < extop_value - 1; i++)
                {
                    if (i >=9) break;
                    PoseMatrixView.PosingMatrix.extop_buttons[i].IsEnabled = true;
                }
                #endregion
            }
        }

        #region Bone Tree
        public class BoneNodes
        {
            private readonly string BonesOffset;
            private HashSet<BoneNodes> children;
            public BoneNodes(string offset)
            {
                BonesOffset = offset;
                children = new HashSet<BoneNodes>();
            }

            public string Get()
            {
                return BonesOffset;
            }
            public BoneNodes Child(string offset)
            {
                BoneNodes childnode = new BoneNodes(offset);
                children.Add(childnode);
                return childnode;
            }
            public void Add(BoneNodes bnode)
            {
                children.Add(bnode);
            }
            public void Remove(BoneNodes bnode)
            {
                children.Remove(bnode);
            }
            public IEnumerator<BoneNodes> GetEnumerator()
            {
                return children.GetEnumerator();
            }
        }
        public BoneNodes
              bone_lumbar,
              bone_thora,
              bone_cerv,
              bone_neck,
              bone_face,
              bone_face_middy,
              bone_face_viera,
              bone_face_hroth,
              bone_clav_l,
              bone_clav_r,
              bone_arm_l,
              bone_arm_r,
              bone_forearm_l,
              bone_forearm_r,
              bone_hand_l,
              bone_hand_r,
              bone_thumb_l,
              bone_thumb_r,
              bone_index_l,
              bone_index_r,
              bone_middle_l,
              bone_middle_r,
              bone_ring_l,
              bone_ring_r,
              bone_pinky_l,
              bone_pinky_r,
              bone_waist,
              bone_leg_l,
              bone_leg_r,
              bone_knee_l,
              bone_knee_r,
              bone_calf_l,
              bone_calf_r,
              bone_foot_l,
              bone_foot_r,
              bone_tail_waist,
              bone_tail_a,
              bone_tail_b,
              bone_tail_c,
              bone_tail_d,
              bone_eye_l,
              bone_eye_r;
        public BoneNodes[] bone_exhair;
        public BoneNodes[] bone_exmet;
        public BoneNodes[] bone_viera_ear_l;
        public BoneNodes[] bone_viera_ear_r;
        public BoneNodes InitBonetree()
        {
            BoneNodes root_tree = new BoneNodes(Settings.Instance.Bones.Root_Bone);
            #region torso tree
            bone_lumbar = root_tree.Child(Settings.Instance.Bones.SpineA_Bone);
            bone_thora = bone_lumbar.Child(Settings.Instance.Bones.SpineB_Bone);
            bone_cerv = bone_thora.Child(Settings.Instance.Bones.SpineC_Bone);
            bone_thora.Child(Settings.Instance.Bones.BreastLeft_Bone);
            bone_thora.Child(Settings.Instance.Bones.BreastRight_Bone);
            bone_thora.Child(Settings.Instance.Bones.ScabbardLeft_Bone);
            bone_thora.Child(Settings.Instance.Bones.ScabbardRight_Bone);
            bone_neck = bone_cerv.Child(Settings.Instance.Bones.Neck_Bone);
            #endregion

            #region clothes tree
            /*
            bone_lumbar.Child(Settings.Instance.Character.Body.Settings.Instance.Bones.ClothBackALeft_X);
            bone_lumbar.Child(Settings.Instance.Character.Body.Settings.Instance.Bones.ClothBackBLeft_X);
            bone_lumbar.Child(Settings.Instance.Character.Body.Settings.Instance.Bones.ClothBackCLeft_X);
            bone_lumbar.Child(Settings.Instance.Character.Body.Settings.Instance.Bones.ClothBackARight_X);
            bone_lumbar.Child(Settings.Instance.Character.Body.Settings.Instance.Bones.ClothBackBRight_X);
            bone_lumbar.Child(Settings.Instance.Character.Body.Settings.Instance.Bones.ClothBackCRight_X);
            bone_lumbar.Child(Settings.Instance.Character.Body.Settings.Instance.Bones.ClothSideALeft_X);
            bone_lumbar.Child(Settings.Instance.Character.Body.Settings.Instance.Bones.ClothSideBLeft_X);
            bone_lumbar.Child(Settings.Instance.Character.Body.Settings.Instance.Bones.ClothSideCLeft_X);
            bone_lumbar.Child(Settings.Instance.Character.Body.Settings.Instance.Bones.ClothSideARight_X);
            bone_lumbar.Child(Settings.Instance.Character.Body.Settings.Instance.Bones.ClothSideBRight_X);
            bone_lumbar.Child(Settings.Instance.Character.Body.Settings.Instance.Bones.ClothSideCRight_X);
            bone_lumbar.Child(Settings.Instance.Character.Body.Settings.Instance.Bones.ClothFrontALeft_X);
            bone_lumbar.Child(Settings.Instance.Character.Body.Settings.Instance.Bones.ClothFrontBLeft_X);
            bone_lumbar.Child(Settings.Instance.Character.Body.Settings.Instance.Bones.ClothFrontCLeft_X);
            bone_lumbar.Child(Settings.Instance.Character.Body.Settings.Instance.Bones.ClothFrontARight_X);
            bone_lumbar.Child(Settings.Instance.Character.Body.Settings.Instance.Bones.ClothFrontBRight_X);
            bone_lumbar.Child(Settings.Instance.Character.Body.Settings.Instance.Bones.ClothFrontCRight_X);
            */
            #endregion

            #region facebone (middy) tree
            bone_face = bone_neck.Child(Settings.Instance.Bones.Head_Bone);
            bone_face.Child(Settings.Instance.Bones.Nose_Bone);
            bone_face.Child(Settings.Instance.Bones.Jaw_Bone);
            bone_face.Child(Settings.Instance.Bones.EyelidLowerLeft_Bone);
            bone_face.Child(Settings.Instance.Bones.EyelidLowerRight_Bone);
            bone_eye_l = bone_face.Child(Settings.Instance.Bones.EyeLeft_Bone);
            bone_eye_l.Child(Settings.Instance.Bones.EyeRight_Bone);
            bone_face.Child(Settings.Instance.Bones.EarLeft_Bone);
            bone_face.Child(Settings.Instance.Bones.EarRight_Bone);
            bone_face.Child(Settings.Instance.Bones.EarringALeft_Bone);
            bone_face.Child(Settings.Instance.Bones.EarringBLeft_Bone);
            bone_face.Child(Settings.Instance.Bones.EarringARight_Bone);
            bone_face.Child(Settings.Instance.Bones.EarringBRight_Bone);
            bone_face.Child(Settings.Instance.Bones.HairFrontLeft_Bone);
            bone_face.Child(Settings.Instance.Bones.HairFrontRight_Bone);
            bone_face.Child(Settings.Instance.Bones.HairA_Bone);
            bone_face.Child(Settings.Instance.Bones.HairB_Bone);
            bone_face.Child(Settings.Instance.Bones.CheekLeft_Bone);
            bone_face.Child(Settings.Instance.Bones.CheekRight_Bone);
            bone_face.Child(Settings.Instance.Bones.LipsLeft_Bone);
            bone_face.Child(Settings.Instance.Bones.LipsRight_Bone);
            bone_face.Child(Settings.Instance.Bones.EyebrowLeft_Bone);
            bone_face.Child(Settings.Instance.Bones.EyebrowRight_Bone);
            bone_face.Child(Settings.Instance.Bones.Bridge_Bone);
            bone_face.Child(Settings.Instance.Bones.BrowLeft_Bone);
            bone_face.Child(Settings.Instance.Bones.BrowRight_Bone);
            bone_face.Child(Settings.Instance.Bones.LipUpperA_Bone);
            bone_face.Child(Settings.Instance.Bones.EyelidUpperLeft_Bone);
            bone_face.Child(Settings.Instance.Bones.EyelidUpperRight_Bone);
            bone_face.Child(Settings.Instance.Bones.LipLowerA_Bone);
            bone_face.Child(Settings.Instance.Bones.LipUpperB_Bone);
            bone_face.Child(Settings.Instance.Bones.LipLowerB_Bone);
            bone_face_middy = bone_face;
            #endregion

            #region facebone hroth tree
            bone_face_hroth = new BoneNodes(Settings.Instance.Bones.Head_Bone);
            bone_face_hroth.Child(Settings.Instance.Bones.Nose_Bone);
            bone_face_hroth.Child(Settings.Instance.Bones.Jaw_Bone);
            bone_face_hroth.Child(Settings.Instance.Bones.EyelidLowerLeft_Bone);
            bone_face_hroth.Child(Settings.Instance.Bones.EyelidLowerRight_Bone);
            bone_face_hroth.Add(bone_eye_l);
            bone_face_hroth.Child(Settings.Instance.Bones.EarLeft_Bone);
            bone_face_hroth.Child(Settings.Instance.Bones.EarRight_Bone);
            bone_face_hroth.Child(Settings.Instance.Bones.EarringALeft_Bone);
            bone_face_hroth.Child(Settings.Instance.Bones.EarringBLeft_Bone);
            bone_face_hroth.Child(Settings.Instance.Bones.EarringARight_Bone);
            bone_face_hroth.Child(Settings.Instance.Bones.EarringBRight_Bone);
            bone_face_hroth.Child(Settings.Instance.Bones.HairFrontLeft_Bone);
            bone_face_hroth.Child(Settings.Instance.Bones.HairFrontRight_Bone);
            bone_face_hroth.Child(Settings.Instance.Bones.HairA_Bone);
            bone_face_hroth.Child(Settings.Instance.Bones.HairB_Bone);
            bone_face_hroth.Child(Settings.Instance.Bones.HrothEyebrowLeft_Bone);
            bone_face_hroth.Child(Settings.Instance.Bones.HrothEyebrowRight_Bone);
            bone_face_hroth.Child(Settings.Instance.Bones.HrothBridge_Bone);
            bone_face_hroth.Child(Settings.Instance.Bones.HrothBrowLeft_Bone);
            bone_face_hroth.Child(Settings.Instance.Bones.HrothBrowRight_Bone);
            bone_face_hroth.Child(Settings.Instance.Bones.HrothJawUpper_Bone);
            bone_face_hroth.Child(Settings.Instance.Bones.HrothLipUpper_Bone);
            bone_face_hroth.Child(Settings.Instance.Bones.HrothEyelidUpperLeft_Bone);
            bone_face_hroth.Child(Settings.Instance.Bones.HrothEyelidUpperRight_Bone);
            bone_face_hroth.Child(Settings.Instance.Bones.HrothLipsLeft_Bone);
            bone_face_hroth.Child(Settings.Instance.Bones.HrothLipsRight_Bone);
            bone_face_hroth.Child(Settings.Instance.Bones.HrothLipUpperLeft_Bone);
            bone_face_hroth.Child(Settings.Instance.Bones.HrothLipUpperRight_Bone);
            bone_face_hroth.Child(Settings.Instance.Bones.HrothLipLower_Bone);
            bone_face_hroth.Child(Settings.Instance.Bones.HrothWhiskersLeft_Bone);
            bone_face_hroth.Child(Settings.Instance.Bones.HrothWhiskersRight_Bone);
            #endregion

            #region facebone viera tree
            bone_face_viera = new BoneNodes(Settings.Instance.Bones.Head_Bone);
            bone_face_viera.Child(Settings.Instance.Bones.Nose_Bone);
            bone_face_viera.Child(Settings.Instance.Bones.Jaw_Bone);
            bone_face_viera.Child(Settings.Instance.Bones.EyelidLowerLeft_Bone);
            bone_face_viera.Child(Settings.Instance.Bones.EyelidLowerRight_Bone);
            bone_face_viera.Add(bone_eye_l);
            bone_face_viera.Child(Settings.Instance.Bones.EarLeft_Bone);
            bone_face_viera.Child(Settings.Instance.Bones.EarRight_Bone);
            bone_face_viera.Child(Settings.Instance.Bones.EarringALeft_Bone);
            bone_face_viera.Child(Settings.Instance.Bones.EarringBLeft_Bone);
            bone_face_viera.Child(Settings.Instance.Bones.EarringARight_Bone);
            bone_face_viera.Child(Settings.Instance.Bones.EarringBRight_Bone);
            bone_face_viera.Child(Settings.Instance.Bones.HairFrontLeft_Bone);
            bone_face_viera.Child(Settings.Instance.Bones.HairFrontRight_Bone);
            bone_face_viera.Child(Settings.Instance.Bones.HairA_Bone);
            bone_face_viera.Child(Settings.Instance.Bones.HairB_Bone);
            bone_face_viera.Child(Settings.Instance.Bones.CheekLeft_Bone);
            bone_face_viera.Child(Settings.Instance.Bones.CheekRight_Bone);
            bone_face_viera.Child(Settings.Instance.Bones.LipsLeft_Bone);
            bone_face_viera.Child(Settings.Instance.Bones.LipsRight_Bone);
            bone_face_viera.Child(Settings.Instance.Bones.EyebrowLeft_Bone);
            bone_face_viera.Child(Settings.Instance.Bones.EyebrowRight_Bone);
            bone_face_viera.Child(Settings.Instance.Bones.Bridge_Bone);
            bone_face_viera.Child(Settings.Instance.Bones.BrowLeft_Bone);
            bone_face_viera.Child(Settings.Instance.Bones.BrowRight_Bone);
            bone_face_viera.Child(Settings.Instance.Bones.LipUpperA_Bone);
            bone_face_viera.Child(Settings.Instance.Bones.EyelidUpperLeft_Bone);
            bone_face_viera.Child(Settings.Instance.Bones.EyelidUpperRight_Bone);
            bone_face_viera.Child(Settings.Instance.Bones.VieraLipLowerA_Bone);
            bone_face_viera.Child(Settings.Instance.Bones.VieraLipUpperB_Bone);
            bone_face_viera.Child(Settings.Instance.Bones.VieraLipLowerB_Bone);
            bone_viera_ear_l = new BoneNodes[5];
            bone_viera_ear_r = new BoneNodes[5];
            bone_viera_ear_l[0] = new BoneNodes(Settings.Instance.Bones.VieraEar01ALeft_Bone);
            bone_viera_ear_r[0] = new BoneNodes(Settings.Instance.Bones.VieraEar01ARight_Bone);
            bone_viera_ear_l[1] = new BoneNodes(Settings.Instance.Bones.VieraEar01ALeft_Bone);
            bone_viera_ear_r[1] = new BoneNodes(Settings.Instance.Bones.VieraEar01ARight_Bone);
            bone_viera_ear_l[2] = new BoneNodes(Settings.Instance.Bones.VieraEar02ALeft_Bone);
            bone_viera_ear_r[2] = new BoneNodes(Settings.Instance.Bones.VieraEar02ARight_Bone);
            bone_viera_ear_l[3] = new BoneNodes(Settings.Instance.Bones.VieraEar03ALeft_Bone);
            bone_viera_ear_r[3] = new BoneNodes(Settings.Instance.Bones.VieraEar03ARight_Bone);
            bone_viera_ear_l[4] = new BoneNodes(Settings.Instance.Bones.VieraEar04ALeft_Bone);
            bone_viera_ear_r[4] = new BoneNodes(Settings.Instance.Bones.VieraEar04ARight_Bone);
            bone_viera_ear_l[0].Child(Settings.Instance.Bones.VieraEar01BLeft_Bone);
            bone_viera_ear_r[0].Child(Settings.Instance.Bones.VieraEar01BRight_Bone);
            bone_viera_ear_l[1].Child(Settings.Instance.Bones.VieraEar01BLeft_Bone);
            bone_viera_ear_r[1].Child(Settings.Instance.Bones.VieraEar01BRight_Bone);
            bone_viera_ear_l[2].Child(Settings.Instance.Bones.VieraEar02BLeft_Bone);
            bone_viera_ear_r[2].Child(Settings.Instance.Bones.VieraEar02BRight_Bone);
            bone_viera_ear_l[3].Child(Settings.Instance.Bones.VieraEar03BLeft_Bone);
            bone_viera_ear_r[3].Child(Settings.Instance.Bones.VieraEar03BRight_Bone);
            bone_viera_ear_l[4].Child(Settings.Instance.Bones.VieraEar04BLeft_Bone);
            bone_viera_ear_r[4].Child(Settings.Instance.Bones.VieraEar04BRight_Bone);
            #endregion

            #region special handler for eyes
            bone_eye_r = new BoneNodes(Settings.Instance.Bones.EyeRight_Bone);
            bone_eye_r.Child(Settings.Instance.Bones.EyeLeft_Bone);
            #endregion

            #region armbone tree
            bone_clav_l = bone_cerv.Child(Settings.Instance.Bones.ClavicleLeft_Bone);
            bone_arm_l = bone_clav_l.Child(Settings.Instance.Bones.ArmLeft_Bone);
            bone_arm_l.Child(Settings.Instance.Bones.ShoulderLeft_Bone);
            bone_arm_l.Child(Settings.Instance.Bones.PauldronLeft_Bone);
            bone_forearm_l = bone_arm_l.Child(Settings.Instance.Bones.ForearmLeft_Bone);
            bone_forearm_l.Child(Settings.Instance.Bones.ElbowLeft_Bone);
            bone_forearm_l.Child(Settings.Instance.Bones.WristLeft_Bone);
            bone_forearm_l.Child(Settings.Instance.Bones.ShieldLeft_Bone);
            bone_forearm_l.Child(Settings.Instance.Bones.CouterLeft_Bone);
            bone_hand_l = bone_forearm_l.Child(Settings.Instance.Bones.HandLeft_Bone);
            bone_hand_l.Child(Settings.Instance.Bones.WeaponLeft_Bone);
            bone_thumb_l = bone_hand_l.Child(Settings.Instance.Bones.ThumbALeft_Bone);
            bone_thumb_l.Child(Settings.Instance.Bones.ThumbBLeft_Bone);
            bone_index_l = bone_hand_l.Child(Settings.Instance.Bones.IndexALeft_Bone);
            bone_index_l.Child(Settings.Instance.Bones.IndexBLeft_Bone);
            bone_middle_l = bone_hand_l.Child(Settings.Instance.Bones.MiddleALeft_Bone);
            bone_middle_l.Child(Settings.Instance.Bones.MiddleBLeft_Bone);
            bone_ring_l = bone_hand_l.Child(Settings.Instance.Bones.RingALeft_Bone);
            bone_ring_l.Child(Settings.Instance.Bones.RingBLeft_Bone);
            bone_pinky_l = bone_hand_l.Child(Settings.Instance.Bones.PinkyALeft_Bone);
            bone_pinky_l.Child(Settings.Instance.Bones.PinkyBLeft_Bone);

            bone_clav_r = bone_cerv.Child(Settings.Instance.Bones.ClavicleRight_Bone);
            bone_arm_r = bone_clav_r.Child(Settings.Instance.Bones.ArmRight_Bone);
            bone_arm_r.Child(Settings.Instance.Bones.ShoulderRight_Bone);
            bone_arm_r.Child(Settings.Instance.Bones.PauldronRight_Bone);
            bone_forearm_r = bone_arm_r.Child(Settings.Instance.Bones.ForearmRight_Bone);
            bone_forearm_r.Child(Settings.Instance.Bones.ElbowRight_Bone);
            bone_forearm_r.Child(Settings.Instance.Bones.WristRight_Bone);
            bone_forearm_r.Child(Settings.Instance.Bones.ShieldRight_Bone);
            bone_forearm_r.Child(Settings.Instance.Bones.CouterRight_Bone);
            bone_hand_r = bone_forearm_r.Child(Settings.Instance.Bones.HandRight_Bone);
            bone_hand_r.Child(Settings.Instance.Bones.WeaponRight_Bone);
            bone_thumb_r = bone_hand_r.Child(Settings.Instance.Bones.ThumbARight_Bone);
            bone_thumb_r.Child(Settings.Instance.Bones.ThumbBRight_Bone);
            bone_index_r = bone_hand_r.Child(Settings.Instance.Bones.IndexARight_Bone);
            bone_index_r.Child(Settings.Instance.Bones.IndexBRight_Bone);
            bone_middle_r = bone_hand_r.Child(Settings.Instance.Bones.MiddleARight_Bone);
            bone_middle_r.Child(Settings.Instance.Bones.MiddleBRight_Bone);
            bone_ring_r = bone_hand_r.Child(Settings.Instance.Bones.RingARight_Bone);
            bone_ring_r.Child(Settings.Instance.Bones.RingBRight_Bone);
            bone_pinky_r = bone_hand_r.Child(Settings.Instance.Bones.PinkyARight_Bone);
            bone_pinky_r.Child(Settings.Instance.Bones.PinkyBRight_Bone);
            #endregion

            #region lower half bones tree
            bone_waist = root_tree.Child(Settings.Instance.Bones.Waist_Bone);
            bone_waist.Child(Settings.Instance.Bones.SheatheLeft_Bone);
            bone_waist.Child(Settings.Instance.Bones.SheatheRight_Bone);
            bone_waist.Child(Settings.Instance.Bones.HolsterLeft_Bone);
            bone_waist.Child(Settings.Instance.Bones.HolsterRight_Bone);
            bone_leg_l = bone_waist.Child(Settings.Instance.Bones.LegsLeft_Bone);
            bone_knee_l = bone_leg_l.Child(Settings.Instance.Bones.KneeLeft_Bone);
            bone_knee_l.Child(Settings.Instance.Bones.PoleynLeft_Bone);
            bone_calf_l = bone_knee_l.Child(Settings.Instance.Bones.CalfLeft_Bone);
            bone_foot_l = bone_calf_l.Child(Settings.Instance.Bones.FootLeft_Bone);
            bone_foot_l.Child(Settings.Instance.Bones.ToesLeft_Bone);

            bone_leg_r = bone_waist.Child(Settings.Instance.Bones.LegsRight_Bone);
            bone_knee_r = bone_leg_r.Child(Settings.Instance.Bones.KneeRight_Bone);
            bone_knee_r.Child(Settings.Instance.Bones.PoleynRight_Bone);
            bone_calf_r = bone_knee_r.Child(Settings.Instance.Bones.CalfRight_Bone);
            bone_foot_r = bone_calf_r.Child(Settings.Instance.Bones.FootRight_Bone);
            bone_foot_r.Child(Settings.Instance.Bones.ToesRight_Bone);
            #endregion

            #region tail bones tree
            bone_tail_a = new BoneNodes(Settings.Instance.Bones.TailA_Bone);
            bone_tail_b = bone_tail_a.Child(Settings.Instance.Bones.TailB_Bone);
            bone_tail_c = bone_tail_b.Child(Settings.Instance.Bones.TailC_Bone);
            bone_tail_c.Child(Settings.Instance.Bones.TailD_Bone);
            #endregion

            #region exhair
            bone_exhair = new BoneNodes[12];
            bone_exhair[0] = new BoneNodes(Settings.Instance.Bones.ExHairA_Bone);
            bone_exhair[1] = new BoneNodes(Settings.Instance.Bones.ExHairB_Bone);
            bone_exhair[2] = new BoneNodes(Settings.Instance.Bones.ExHairC_Bone);
            bone_exhair[3] = new BoneNodes(Settings.Instance.Bones.ExHairD_Bone);
            bone_exhair[4] = new BoneNodes(Settings.Instance.Bones.ExHairE_Bone);
            bone_exhair[5] = new BoneNodes(Settings.Instance.Bones.ExHairF_Bone);
            bone_exhair[6] = new BoneNodes(Settings.Instance.Bones.ExHairG_Bone);
            bone_exhair[7] = new BoneNodes(Settings.Instance.Bones.ExHairH_Bone);
            bone_exhair[8] = new BoneNodes(Settings.Instance.Bones.ExHairI_Bone);
            bone_exhair[9] = new BoneNodes(Settings.Instance.Bones.ExHairJ_Bone);
            bone_exhair[10] = new BoneNodes(Settings.Instance.Bones.ExHairK_Bone);
            bone_exhair[11] = new BoneNodes(Settings.Instance.Bones.ExHairL_Bone);
            #endregion

            #region exmet
            bone_exmet = new BoneNodes[18];
            bone_exmet[0] = new BoneNodes(Settings.Instance.Bones.ExMetA_Bone);
            bone_exmet[1] = new BoneNodes(Settings.Instance.Bones.ExMetB_Bone);
            bone_exmet[2] = new BoneNodes(Settings.Instance.Bones.ExMetC_Bone);
            bone_exmet[3] = new BoneNodes(Settings.Instance.Bones.ExMetD_Bone);
            bone_exmet[4] = new BoneNodes(Settings.Instance.Bones.ExMetE_Bone);
            bone_exmet[5] = new BoneNodes(Settings.Instance.Bones.ExMetF_Bone);
            bone_exmet[6] = new BoneNodes(Settings.Instance.Bones.ExMetG_Bone);
            bone_exmet[7] = new BoneNodes(Settings.Instance.Bones.ExMetH_Bone);
            bone_exmet[8] = new BoneNodes(Settings.Instance.Bones.ExMetI_Bone);
            bone_exmet[9] = new BoneNodes(Settings.Instance.Bones.ExMetJ_Bone);
            bone_exmet[10] = new BoneNodes(Settings.Instance.Bones.ExMetK_Bone);
            bone_exmet[11] = new BoneNodes(Settings.Instance.Bones.ExMetL_Bone);
            bone_exmet[12] = new BoneNodes(Settings.Instance.Bones.ExMetM_Bone);
            bone_exmet[13] = new BoneNodes(Settings.Instance.Bones.ExMetN_Bone);
            bone_exmet[14] = new BoneNodes(Settings.Instance.Bones.ExMetO_Bone);
            bone_exmet[15] = new BoneNodes(Settings.Instance.Bones.ExMetP_Bone);
            bone_exmet[16] = new BoneNodes(Settings.Instance.Bones.ExMetQ_Bone);
            bone_exmet[17] = new BoneNodes(Settings.Instance.Bones.ExMetR_Bone);
            #endregion

            return root_tree;
        }
        #endregion
    }
}