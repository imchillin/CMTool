using ConceptMatrix.Models;
using ConceptMatrix.Utility;
using ConceptMatrix.ViewModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Media3D;

namespace ConceptMatrix.Views
{
    /// <summary>
    /// Interaction logic for PoseRotationView.xaml
    /// </summary>
    public partial class PoseRotationView : UserControl
    {
        struct DragState
        {
            public Point lastPoint;
            public bool isTracking;
            public MouseButton mouseButton;
        }

        public CharacterDetails CharacterDetails { get => (CharacterDetails)BaseViewModel.model; set => BaseViewModel.model = value; }
        private string GAS(params string[] args) => MemoryManager.GetAddressString(args);
        private readonly Mem m = MemoryManager.Instance.MemLib;

        private DragState dragState;
        private Quaternion oldrot, newrot;
 
        public PoseRotationView()
        {
            InitializeComponent();
        }
        private void Viewport3D_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            var el = (UIElement)sender;

            if (el.IsMouseCaptured)
            {
                var curPoint = e.MouseDevice.GetPosition(el);

                var delta = dragState.lastPoint - curPoint;
                var angle = Vector3D.DotProduct(new Vector3D(delta.X, -delta.Y, 0), new Vector3D(1, 1, 0));

                // Dragging the Left Mouse Button changes the pitch (facing up or down)
                // Dragging the Middle Mouse Button changes the yaw (facing left or right)
                // Dragging the Right Mouse Button changes the roll (leaning left or right)
                Vector3D axis;
                switch (dragState.mouseButton)
                {
                    case MouseButton.Middle:
                        axis = new Vector3D(1, 0, 0);
                        break;
                    case MouseButton.Left:
                        axis = new Vector3D(0, 1, 0);
                        angle = -angle;
                        break;
                    case MouseButton.Right:
                        axis = new Vector3D(0, 0, 1);
                        angle = -angle;
                        break;
                    default:
                        return;
                }

                // Applies the desired rotation first then the original rotation second.
                // Not the other way around (which would be rotationDelta * q). This makes it
                // more intuitive to adjust the roll, pitch, and yaw relative to the original
                // rotation.
                var rotationDelta = new Quaternion(axis, angle);
                var q = (MainViewModel.ViewTime.AltRotate) ? RotationQuaternion.Quaternion * rotationDelta : rotationDelta * RotationQuaternion.Quaternion;
                RotationQuaternion.SetCurrentValue(QuaternionRotation3D.QuaternionProperty, q);
                dragState.lastPoint = curPoint;
            }
        }

        private void Viewport3D_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var el = (UIElement)sender;
            if (dragState.isTracking)
                return;
            
            newrot = (Quaternion)RotationQuaternion.GetValue(QuaternionRotation3D.QuaternionProperty);
            dragState.lastPoint = e.MouseDevice.GetPosition(el);
            dragState.isTracking = true;
            dragState.mouseButton = e.ChangedButton;
            el.CaptureMouse();
        }


        public void RotateHelper(Address<float> x, Address<float> y, Address<float> z, Address<float> w, CharacterDetailsView5.BoneNode bnode = null)
        {
            Quaternion q = (Quaternion)RotationQuaternion.GetValue(QuaternionRotation3D.QuaternionProperty);
            x.value = (float)q.X;
            y.value = (float)q.Y;
            z.value = (float)q.Z;
            w.value = (float)q.W;
            #region Child Bones
            if (MainViewModel.ViewTime5.ParentingToggle.IsChecked == true && bnode != null)
            {
                MainViewModel.ViewTime5.Bone_Flag_Manager();
                oldrot = newrot;
                Quaternion q1_inv = CharacterDetailsView5.QInv(oldrot);
                newrot = (Quaternion)RotationQuaternion.GetValue(QuaternionRotation3D.QuaternionProperty);
                MainViewModel.ViewTime5.Rotate_ChildBone(bnode, q1_inv, newrot);
            }
            #endregion
        }

        private void Viewport3D_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var el = (UIElement)sender;
            el.ReleaseMouseCapture();

            dragState.isTracking = false;

            var qv = RotationQuaternion.GetValue(QuaternionRotation3D.QuaternionProperty);
            var q = (Quaternion)qv;

            if (CharacterDetails.Root_Rotate == true)
            {
                RotateHelper(CharacterDetails.Root_X, CharacterDetails.Root_Y, CharacterDetails.Root_Z, CharacterDetails.Root_W);
                CharacterDetails.Root_Toggle = true;
            }
            if (CharacterDetails.Abdomen_Rotate == true)
            {
                RotateHelper(CharacterDetails.Abdomen_X, CharacterDetails.Abdomen_Y, CharacterDetails.Abdomen_Z, CharacterDetails.Abdomen_W);
                CharacterDetails.Abdomen_Toggle = true;
            }
            if (CharacterDetails.Throw_Rotate == true)
            {
                RotateHelper(CharacterDetails.Throw_X, CharacterDetails.Throw_Y, CharacterDetails.Throw_Z, CharacterDetails.Throw_W);
                CharacterDetails.Throw_Toggle = true;
            }
            if (CharacterDetails.Waist_Rotate == true)
            {
                RotateHelper(CharacterDetails.Waist_X, CharacterDetails.Waist_Y, CharacterDetails.Waist_Z, CharacterDetails.Waist_W, MainViewModel.ViewTime5.bone_waist);
                CharacterDetails.Waist_Toggle = true;
            }
            if (CharacterDetails.SpineA_Rotate == true)
            {
                RotateHelper(CharacterDetails.SpineA_X, CharacterDetails.SpineA_Y, CharacterDetails.SpineA_Z, CharacterDetails.SpineA_W, MainViewModel.ViewTime5.bone_lumbar);
                CharacterDetails.SpineA_Toggle = true;
            }
            if (CharacterDetails.LegLeft_Rotate == true)
            {
                RotateHelper(CharacterDetails.LegLeft_X, CharacterDetails.LegLeft_Y, CharacterDetails.LegLeft_Z, CharacterDetails.LegLeft_W, MainViewModel.ViewTime5.bone_leg_l);
                CharacterDetails.LegLeft_Toggle = true;
            }
            if (CharacterDetails.LegRight_Rotate == true)
            {
                RotateHelper(CharacterDetails.LegRight_X, CharacterDetails.LegRight_Y, CharacterDetails.LegRight_Z, CharacterDetails.LegRight_W, MainViewModel.ViewTime5.bone_leg_r);
                CharacterDetails.LegRight_Toggle = true;
            }
            if (CharacterDetails.HolsterLeft_Rotate == true)
            {
                RotateHelper(CharacterDetails.HolsterLeft_X, CharacterDetails.HolsterLeft_Y, CharacterDetails.HolsterLeft_Z, CharacterDetails.HolsterLeft_W);
                CharacterDetails.HolsterLeft_Toggle = true;
            }
            if (CharacterDetails.HolsterRight_Rotate == true)
            {
                RotateHelper(CharacterDetails.HolsterRight_X, CharacterDetails.HolsterRight_Y, CharacterDetails.HolsterRight_Z, CharacterDetails.HolsterRight_W);
                CharacterDetails.HolsterRight_Toggle = true;
            }
            if (CharacterDetails.SheatheLeft_Rotate == true)
            {
                RotateHelper(CharacterDetails.SheatheLeft_X, CharacterDetails.SheatheLeft_Y, CharacterDetails.SheatheLeft_Z, CharacterDetails.SheatheLeft_W);
                CharacterDetails.SheatheLeft_Toggle = true;
            }
            if (CharacterDetails.SheatheRight_Rotate == true)
            {
                RotateHelper(CharacterDetails.SheatheRight_X, CharacterDetails.SheatheRight_Y, CharacterDetails.SheatheRight_Z, CharacterDetails.SheatheRight_W);
                CharacterDetails.SheatheRight_Toggle = true;
            }
            if (CharacterDetails.SpineB_Rotate == true)
            {
                RotateHelper(CharacterDetails.SpineB_X, CharacterDetails.SpineB_Y, CharacterDetails.SpineB_Z, CharacterDetails.SpineB_W, MainViewModel.ViewTime5.bone_thora);
                CharacterDetails.SpineB_Toggle = true;
            }
            if (CharacterDetails.ClothBackALeft_Rotate == true)
            {
                RotateHelper(CharacterDetails.ClothBackALeft_X, CharacterDetails.ClothBackALeft_Y, CharacterDetails.ClothBackALeft_Z, CharacterDetails.ClothBackALeft_W);
                CharacterDetails.ClothBackALeft_Toggle = true;
            }
            if (CharacterDetails.ClothBackARight_Rotate == true)
            {
                RotateHelper(CharacterDetails.ClothBackARight_X, CharacterDetails.ClothBackARight_Y, CharacterDetails.ClothBackARight_Z, CharacterDetails.ClothBackARight_W);
                CharacterDetails.ClothBackARight_Toggle = true;
            }
            if (CharacterDetails.ClothFrontALeft_Rotate == true)
            {
                RotateHelper(CharacterDetails.ClothFrontALeft_X, CharacterDetails.ClothFrontALeft_Y, CharacterDetails.ClothFrontALeft_Z, CharacterDetails.ClothFrontALeft_W);
                CharacterDetails.ClothFrontALeft_Toggle = true;
            }
            if (CharacterDetails.ClothFrontARight_Rotate == true)
            {
                RotateHelper(CharacterDetails.ClothFrontARight_X, CharacterDetails.ClothFrontARight_Y, CharacterDetails.ClothFrontARight_Z, CharacterDetails.ClothFrontARight_W);
                CharacterDetails.ClothFrontARight_Toggle = true;
            }
            if (CharacterDetails.ClothSideALeft_Rotate == true)
            {
                RotateHelper(CharacterDetails.ClothSideALeft_X, CharacterDetails.ClothSideALeft_Y, CharacterDetails.ClothSideALeft_Z, CharacterDetails.ClothSideALeft_W);
                CharacterDetails.ClothSideALeft_Toggle = true;
            }
            if (CharacterDetails.ClothSideARight_Rotate == true)
            {
                RotateHelper(CharacterDetails.ClothSideARight_X, CharacterDetails.ClothSideARight_Y, CharacterDetails.ClothSideARight_Z, CharacterDetails.ClothSideARight_W);
                CharacterDetails.ClothSideARight_Toggle = true;
            }
            if (CharacterDetails.KneeLeft_Rotate == true)
            {
                RotateHelper(CharacterDetails.KneeLeft_X, CharacterDetails.KneeLeft_Y, CharacterDetails.KneeLeft_Z, CharacterDetails.KneeLeft_W, MainViewModel.ViewTime5.bone_knee_l);
                CharacterDetails.KneeLeft_Toggle = true;
            }
            if (CharacterDetails.KneeRight_Rotate == true)
            {
                RotateHelper(CharacterDetails.KneeRight_X, CharacterDetails.KneeRight_Y, CharacterDetails.KneeRight_Z, CharacterDetails.KneeRight_W, MainViewModel.ViewTime5.bone_knee_r);
                CharacterDetails.KneeRight_Toggle = true;
            }
            if (CharacterDetails.BreastLeft_Rotate == true)
            {
                RotateHelper(CharacterDetails.BreastLeft_X, CharacterDetails.BreastLeft_Y, CharacterDetails.BreastLeft_Z, CharacterDetails.BreastLeft_W);
                CharacterDetails.BreastLeft_Toggle = true;
            }
            if (CharacterDetails.BreastRight_Rotate == true)
            {
                RotateHelper(CharacterDetails.BreastRight_X, CharacterDetails.BreastRight_Y, CharacterDetails.BreastRight_Z, CharacterDetails.BreastRight_W);
                CharacterDetails.BreastRight_Toggle = true;
            }
            if (CharacterDetails.SpineC_Rotate == true)
            {
                RotateHelper(CharacterDetails.SpineC_X, CharacterDetails.SpineC_Y, CharacterDetails.SpineC_Z, CharacterDetails.SpineC_W, MainViewModel.ViewTime5.bone_cerv);
                CharacterDetails.SpineC_Toggle = true;
            }
            if (CharacterDetails.ClothBackBLeft_Rotate == true)
            {
                RotateHelper(CharacterDetails.ClothBackBLeft_X, CharacterDetails.ClothBackBLeft_Y, CharacterDetails.ClothBackBLeft_Z, CharacterDetails.ClothBackBLeft_W);
                CharacterDetails.ClothBackBLeft_Toggle = true;
            }
            if (CharacterDetails.ClothBackBRight_Rotate == true)
            {
                RotateHelper(CharacterDetails.ClothBackBRight_X, CharacterDetails.ClothBackBRight_Y, CharacterDetails.ClothBackBRight_Z, CharacterDetails.ClothBackBRight_W);
                CharacterDetails.ClothBackBRight_Toggle = true;
            }
            if (CharacterDetails.ClothFrontBLeft_Rotate == true)
            {
                RotateHelper(CharacterDetails.ClothFrontBLeft_X, CharacterDetails.ClothFrontBLeft_Y, CharacterDetails.ClothFrontBLeft_Z, CharacterDetails.ClothFrontBLeft_W);
                CharacterDetails.ClothFrontBLeft_Toggle = true;
            }
            if (CharacterDetails.ClothFrontBRight_Rotate == true)
            {
                RotateHelper(CharacterDetails.ClothFrontBRight_X, CharacterDetails.ClothFrontBRight_Y, CharacterDetails.ClothFrontBRight_Z, CharacterDetails.ClothFrontBRight_W);
                CharacterDetails.ClothFrontBRight_Toggle = true;
            }
            if (CharacterDetails.ClothSideBLeft_Rotate == true)
            {
                RotateHelper(CharacterDetails.ClothSideBLeft_X, CharacterDetails.ClothSideBLeft_Y, CharacterDetails.ClothSideBLeft_Z, CharacterDetails.ClothSideBLeft_W);
                CharacterDetails.ClothSideBLeft_Toggle = true;
            }
            if (CharacterDetails.ClothSideBRight_Rotate == true)
            {
                RotateHelper(CharacterDetails.ClothSideBRight_X, CharacterDetails.ClothSideBRight_Y, CharacterDetails.ClothSideBRight_Z, CharacterDetails.ClothSideBRight_W);
                CharacterDetails.ClothSideBRight_Toggle = true;
            }
            if (CharacterDetails.CalfLeft_Rotate == true)
            {
                RotateHelper(CharacterDetails.CalfLeft_X, CharacterDetails.CalfLeft_Y, CharacterDetails.CalfLeft_Z, CharacterDetails.CalfLeft_W, MainViewModel.ViewTime5.bone_calf_l);
                CharacterDetails.CalfLeft_Toggle = true;
            }
            if (CharacterDetails.CalfRight_Rotate == true)
            {
                RotateHelper(CharacterDetails.CalfRight_X, CharacterDetails.CalfRight_Y, CharacterDetails.CalfRight_Z, CharacterDetails.CalfRight_W, MainViewModel.ViewTime5.bone_calf_r);
                CharacterDetails.CalfRight_Toggle = true;
            }
            if (CharacterDetails.ScabbardLeft_Rotate == true)
            {
                RotateHelper(CharacterDetails.ScabbardLeft_X, CharacterDetails.ScabbardLeft_Y, CharacterDetails.ScabbardLeft_Z, CharacterDetails.ScabbardLeft_W);
                CharacterDetails.ScabbardLeft_Toggle = true;
            }
            if (CharacterDetails.ScabbardRight_Rotate == true)
            {
                RotateHelper(CharacterDetails.ScabbardRight_X, CharacterDetails.ScabbardRight_Y, CharacterDetails.ScabbardRight_Z, CharacterDetails.ScabbardRight_W);
                CharacterDetails.ScabbardRight_Toggle = true;
            }
            if (CharacterDetails.Neck_Rotate == true)
            {
                RotateHelper(CharacterDetails.Neck_X, CharacterDetails.Neck_Y, CharacterDetails.Neck_Z, CharacterDetails.Neck_W, MainViewModel.ViewTime5.bone_neck);
                CharacterDetails.Neck_Toggle = true;
            }
            if (CharacterDetails.ClavicleLeft_Rotate == true)
            {
                RotateHelper(CharacterDetails.ClavicleLeft_X, CharacterDetails.ClavicleLeft_Y, CharacterDetails.ClavicleLeft_Z, CharacterDetails.ClavicleLeft_W, MainViewModel.ViewTime5.bone_clav_l);
                CharacterDetails.ClavicleLeft_Toggle = true;
            }
            if (CharacterDetails.ClavicleRight_Rotate == true)
            {
                RotateHelper(CharacterDetails.ClavicleRight_X, CharacterDetails.ClavicleRight_Y, CharacterDetails.ClavicleRight_Z, CharacterDetails.ClavicleRight_W, MainViewModel.ViewTime5.bone_clav_l);
                CharacterDetails.ClavicleRight_Toggle = true;
            }
            if (CharacterDetails.ClothBackCLeft_Rotate == true)
            {
                RotateHelper(CharacterDetails.ClothBackCLeft_X, CharacterDetails.ClothBackCLeft_Y, CharacterDetails.ClothBackCLeft_Z, CharacterDetails.ClothBackCLeft_W);
                CharacterDetails.ClothBackCLeft_Toggle = true;
            }
            if (CharacterDetails.ClothBackCRight_Rotate == true)
            {
                RotateHelper(CharacterDetails.ClothBackCRight_X, CharacterDetails.ClothBackCRight_Y, CharacterDetails.ClothBackCRight_Z, CharacterDetails.ClothBackCRight_W);
                CharacterDetails.ClothBackCRight_Toggle = true;
            }
            if (CharacterDetails.ClothFrontCLeft_Rotate == true)
            {
                RotateHelper(CharacterDetails.ClothFrontCLeft_X, CharacterDetails.ClothFrontCLeft_Y, CharacterDetails.ClothFrontCLeft_Z, CharacterDetails.ClothFrontCLeft_W);
                CharacterDetails.ClothFrontCLeft_Toggle = true;
            }
            if (CharacterDetails.ClothFrontCRight_Rotate == true)
            {
                RotateHelper(CharacterDetails.ClothFrontCRight_X, CharacterDetails.ClothFrontCRight_Y, CharacterDetails.ClothFrontCRight_Z, CharacterDetails.ClothFrontCRight_W);
                CharacterDetails.ClothFrontCRight_Toggle = true;
            }
            if (CharacterDetails.ClothSideCLeft_Rotate == true)
            {
                RotateHelper(CharacterDetails.ClothSideCLeft_X, CharacterDetails.ClothSideCLeft_Y, CharacterDetails.ClothSideCLeft_Z, CharacterDetails.ClothSideCLeft_W);
                CharacterDetails.ClothSideCLeft_Toggle = true;
            }
            if (CharacterDetails.ClothSideCRight_Rotate == true)
            {
                RotateHelper(CharacterDetails.ClothSideCRight_X, CharacterDetails.ClothSideCRight_Y, CharacterDetails.ClothSideCRight_Z, CharacterDetails.ClothSideCRight_W);
                CharacterDetails.ClothSideCRight_Toggle = true;
            }
            if (CharacterDetails.PoleynLeft_Rotate == true)
            {
                RotateHelper(CharacterDetails.PoleynLeft_X, CharacterDetails.PoleynLeft_Y, CharacterDetails.PoleynLeft_Z, CharacterDetails.PoleynLeft_W);
                CharacterDetails.PoleynLeft_Toggle = true;
            }
            if (CharacterDetails.PoleynRight_Rotate == true)
            {
                RotateHelper(CharacterDetails.PoleynRight_X, CharacterDetails.PoleynRight_Y, CharacterDetails.PoleynRight_Z, CharacterDetails.PoleynRight_W);
                CharacterDetails.PoleynRight_Toggle = true;
            }
            if (CharacterDetails.FootLeft_Rotate == true)
            {
                RotateHelper(CharacterDetails.FootLeft_X, CharacterDetails.FootLeft_Y, CharacterDetails.FootLeft_Z, CharacterDetails.FootLeft_W, MainViewModel.ViewTime5.bone_foot_l);
                CharacterDetails.FootLeft_Toggle = true;
            }
            if (CharacterDetails.FootRight_Rotate == true)
            {
                RotateHelper(CharacterDetails.FootRight_X, CharacterDetails.FootRight_Y, CharacterDetails.FootRight_Z, CharacterDetails.FootRight_W, MainViewModel.ViewTime5.bone_foot_r);
                CharacterDetails.FootRight_Toggle = true;
            }
            if (CharacterDetails.Head_Rotate == true)
            {
                RotateHelper(CharacterDetails.Head_X, CharacterDetails.Head_Y, CharacterDetails.Head_Z, CharacterDetails.Head_W, MainViewModel.ViewTime5.bone_neck);
                CharacterDetails.Head_Toggle = true;
            }
            if (CharacterDetails.ArmLeft_Rotate == true)
            {
                RotateHelper(CharacterDetails.ArmLeft_X, CharacterDetails.ArmLeft_Y, CharacterDetails.ArmLeft_Z, CharacterDetails.ArmLeft_W, MainViewModel.ViewTime5.bone_arm_l);
                CharacterDetails.ArmLeft_Toggle = true;
            }
            if (CharacterDetails.ArmRight_Rotate == true)
            {
                RotateHelper(CharacterDetails.ArmRight_X, CharacterDetails.ArmRight_Y, CharacterDetails.ArmRight_Z, CharacterDetails.ArmRight_W, MainViewModel.ViewTime5.bone_arm_r);
                CharacterDetails.ArmRight_Toggle = true;
            }
            if (CharacterDetails.PauldronLeft_Rotate == true)
            {
                RotateHelper(CharacterDetails.PauldronLeft_X, CharacterDetails.PauldronLeft_Y, CharacterDetails.PauldronLeft_Z, CharacterDetails.PauldronLeft_W);
                CharacterDetails.PauldronLeft_Toggle = true;
            }
            if (CharacterDetails.PauldronRight_Rotate == true)
            {
                RotateHelper(CharacterDetails.PauldronRight_X, CharacterDetails.PauldronRight_Y, CharacterDetails.PauldronRight_Z, CharacterDetails.PauldronRight_W);
                CharacterDetails.PauldronRight_Toggle = true;
            }
            if (CharacterDetails.Unknown00_Rotate == true)
            {
                RotateHelper(CharacterDetails.Unknown00_X, CharacterDetails.Unknown00_Y, CharacterDetails.Unknown00_Z, CharacterDetails.Unknown00_W);
                CharacterDetails.Unknown00_Toggle = true;
            }
            if (CharacterDetails.ToesLeft_Rotate == true)
            {
                RotateHelper(CharacterDetails.ToesLeft_X, CharacterDetails.ToesLeft_Y, CharacterDetails.ToesLeft_Z, CharacterDetails.ToesLeft_W);
                CharacterDetails.ToesLeft_Toggle = true;
            }
            if (CharacterDetails.ToesRight_Rotate == true)
            {
                RotateHelper(CharacterDetails.ToesRight_X, CharacterDetails.ToesRight_Y, CharacterDetails.ToesRight_Z, CharacterDetails.ToesRight_W);
                CharacterDetails.ToesRight_Toggle = true;
            }
            if (CharacterDetails.HairA_Rotate == true)
            {
                RotateHelper(CharacterDetails.HairA_X, CharacterDetails.HairA_Y, CharacterDetails.HairA_Z, CharacterDetails.HairA_W);
                CharacterDetails.HairA_Toggle = true;
            }
            if (CharacterDetails.HairFrontLeft_Rotate == true)
            {
                RotateHelper(CharacterDetails.HairFrontLeft_X, CharacterDetails.HairFrontLeft_Y, CharacterDetails.HairFrontLeft_Z, CharacterDetails.HairFrontLeft_W);
                CharacterDetails.HairFrontLeft_Toggle = true;
            }
            if (CharacterDetails.HairFrontRight_Rotate == true)
            {
                RotateHelper(CharacterDetails.HairFrontRight_X, CharacterDetails.HairFrontRight_Y, CharacterDetails.HairFrontRight_Z, CharacterDetails.HairFrontRight_W);
                CharacterDetails.HairFrontRight_Toggle = true;
            }
            if (CharacterDetails.EarLeft_Rotate == true)
            {
                RotateHelper(CharacterDetails.EarLeft_X, CharacterDetails.EarLeft_Y, CharacterDetails.EarLeft_Z, CharacterDetails.EarLeft_W);
                CharacterDetails.EarLeft_Toggle = true;
            }
            if (CharacterDetails.EarRight_Rotate == true)
            {
                RotateHelper(CharacterDetails.EarRight_X, CharacterDetails.EarRight_Y, CharacterDetails.EarRight_Z, CharacterDetails.EarRight_W);
                CharacterDetails.EarRight_Toggle = true;
            }
            if (CharacterDetails.ForearmLeft_Rotate == true)
            {
                RotateHelper(CharacterDetails.ForearmLeft_X, CharacterDetails.ForearmLeft_Y, CharacterDetails.ForearmLeft_Z, CharacterDetails.ForearmLeft_W, MainViewModel.ViewTime5.bone_forearm_l);
                CharacterDetails.ForearmLeft_Toggle = true;
            }
            if (CharacterDetails.ForearmRight_Rotate == true)
            {
                RotateHelper(CharacterDetails.ForearmRight_X, CharacterDetails.ForearmRight_Y, CharacterDetails.ForearmRight_Z, CharacterDetails.ForearmRight_W, MainViewModel.ViewTime5.bone_forearm_r);
                CharacterDetails.ForearmRight_Toggle = true;
            }
            if (CharacterDetails.ShoulderLeft_Rotate == true)
            {
                RotateHelper(CharacterDetails.ShoulderLeft_X, CharacterDetails.ShoulderLeft_Y, CharacterDetails.ShoulderLeft_Z, CharacterDetails.ShoulderLeft_W);
                CharacterDetails.ShoulderLeft_Toggle = true;
            }
            if (CharacterDetails.ShoulderRight_Rotate == true)
            {
                RotateHelper(CharacterDetails.ShoulderRight_X, CharacterDetails.ShoulderRight_Y, CharacterDetails.ShoulderRight_Z, CharacterDetails.ShoulderRight_W);
                CharacterDetails.ShoulderRight_Toggle = true;
            }
            if (CharacterDetails.HairB_Rotate == true)
            {
                RotateHelper(CharacterDetails.HairB_X, CharacterDetails.HairB_Y, CharacterDetails.HairB_Z, CharacterDetails.HairB_W);
                CharacterDetails.HairB_Toggle = true;
            }
            if (CharacterDetails.HandLeft_Rotate == true)
            {
                RotateHelper(CharacterDetails.HandLeft_X, CharacterDetails.HandLeft_Y, CharacterDetails.HandLeft_Z, CharacterDetails.HandLeft_W, MainViewModel.ViewTime5.bone_hand_l);
                CharacterDetails.HandLeft_Toggle = true;
            }
            if (CharacterDetails.HandRight_Rotate == true)
            {
                RotateHelper(CharacterDetails.HandRight_X, CharacterDetails.HandRight_Y, CharacterDetails.HandRight_Z, CharacterDetails.HandRight_W, MainViewModel.ViewTime5.bone_hand_r);
                CharacterDetails.HandRight_Toggle = true;
            }
            if (CharacterDetails.ShieldLeft_Rotate == true)
            {
                RotateHelper(CharacterDetails.ShieldLeft_X, CharacterDetails.ShieldLeft_Y, CharacterDetails.ShieldLeft_Z, CharacterDetails.ShieldLeft_W);
                CharacterDetails.ShieldLeft_Toggle = true;
            }
            if (CharacterDetails.ShieldRight_Rotate == true)
            {
                RotateHelper(CharacterDetails.ShieldRight_X, CharacterDetails.ShieldRight_Y, CharacterDetails.ShieldRight_Z, CharacterDetails.ShieldRight_W);
                CharacterDetails.ShieldRight_Toggle = true;
            }
            if (CharacterDetails.EarringALeft_Rotate == true)
            {
                RotateHelper(CharacterDetails.EarringALeft_X, CharacterDetails.EarringALeft_Y, CharacterDetails.EarringALeft_Z, CharacterDetails.EarringALeft_W);
                CharacterDetails.EarringALeft_Toggle = true;
            }
            if (CharacterDetails.EarringARight_Rotate == true)
            {
                RotateHelper(CharacterDetails.EarringARight_X, CharacterDetails.EarringARight_Y, CharacterDetails.EarringARight_Z, CharacterDetails.EarringARight_W);
                CharacterDetails.EarringARight_Toggle = true;
            }
            if (CharacterDetails.ElbowLeft_Rotate == true)
            {
                RotateHelper(CharacterDetails.ElbowLeft_X, CharacterDetails.ElbowLeft_Y, CharacterDetails.ElbowLeft_Z, CharacterDetails.ElbowLeft_W);
                CharacterDetails.ElbowLeft_Toggle = true;
            }
            if (CharacterDetails.ElbowRight_Rotate == true)
            {
                RotateHelper(CharacterDetails.ElbowRight_X, CharacterDetails.ElbowRight_Y, CharacterDetails.ElbowRight_Z, CharacterDetails.ElbowRight_W);
                CharacterDetails.ElbowRight_Toggle = true;
            }
            if (CharacterDetails.CouterLeft_Rotate == true)
            {
                RotateHelper(CharacterDetails.CouterLeft_X, CharacterDetails.CouterLeft_Y, CharacterDetails.CouterLeft_Z, CharacterDetails.CouterLeft_W);
                CharacterDetails.CouterLeft_Toggle = true;
            }
            if (CharacterDetails.CouterRight_Rotate == true)
            {
                RotateHelper(CharacterDetails.CouterRight_X, CharacterDetails.CouterRight_Y, CharacterDetails.CouterRight_Z, CharacterDetails.CouterRight_W);
                CharacterDetails.CouterRight_Toggle = true;
            }
            if (CharacterDetails.WristLeft_Rotate == true)
            {
                RotateHelper(CharacterDetails.WristLeft_X, CharacterDetails.WristLeft_Y, CharacterDetails.WristLeft_Z, CharacterDetails.WristLeft_W);
                CharacterDetails.WristLeft_Toggle = true;
            }
            if (CharacterDetails.WristRight_Rotate == true)
            {
                RotateHelper(CharacterDetails.WristRight_X, CharacterDetails.WristRight_Y, CharacterDetails.WristRight_Z, CharacterDetails.WristRight_W);
                CharacterDetails.WristRight_Toggle = true;
            }
            if (CharacterDetails.IndexALeft_Rotate == true)
            {
                RotateHelper(CharacterDetails.IndexALeft_X, CharacterDetails.IndexALeft_Y, CharacterDetails.IndexALeft_Z, CharacterDetails.IndexALeft_W, MainViewModel.ViewTime5.bone_index_l);
                CharacterDetails.IndexALeft_Toggle = true;
            }
            if (CharacterDetails.IndexARight_Rotate == true)
            {
                RotateHelper(CharacterDetails.IndexARight_X, CharacterDetails.IndexARight_Y, CharacterDetails.IndexARight_Z, CharacterDetails.IndexARight_W, MainViewModel.ViewTime5.bone_index_r);
                CharacterDetails.IndexARight_Toggle = true;
            }
            if (CharacterDetails.PinkyALeft_Rotate == true)
            {
                RotateHelper(CharacterDetails.PinkyALeft_X, CharacterDetails.PinkyALeft_Y, CharacterDetails.PinkyALeft_Z, CharacterDetails.PinkyALeft_W, MainViewModel.ViewTime5.bone_pinky_l);
                CharacterDetails.PinkyALeft_Toggle = true;
            }
            if (CharacterDetails.PinkyARight_Rotate == true)
            {
                RotateHelper(CharacterDetails.PinkyARight_X, CharacterDetails.PinkyARight_Y, CharacterDetails.PinkyARight_Z, CharacterDetails.PinkyARight_W, MainViewModel.ViewTime5.bone_pinky_r);
                CharacterDetails.PinkyARight_Toggle = true;
            }
            if (CharacterDetails.RingALeft_Rotate == true)
            {
                RotateHelper(CharacterDetails.RingALeft_X, CharacterDetails.RingALeft_Y, CharacterDetails.RingALeft_Z, CharacterDetails.RingALeft_W, MainViewModel.ViewTime5.bone_ring_l);
                CharacterDetails.RingALeft_Toggle = true;
            }
            if (CharacterDetails.RingARight_Rotate == true)
            {
                RotateHelper(CharacterDetails.RingARight_X, CharacterDetails.RingARight_Y, CharacterDetails.RingARight_Z, CharacterDetails.RingARight_W, MainViewModel.ViewTime5.bone_ring_r);
                CharacterDetails.RingARight_Toggle = true;
            }
            if (CharacterDetails.MiddleALeft_Rotate == true)
            {
                RotateHelper(CharacterDetails.MiddleALeft_X, CharacterDetails.MiddleALeft_Y, CharacterDetails.MiddleALeft_Z, CharacterDetails.MiddleALeft_W, MainViewModel.ViewTime5.bone_middle_l);
                CharacterDetails.MiddleALeft_Toggle = true;
            }
            if (CharacterDetails.MiddleARight_Rotate == true)
            {
                RotateHelper(CharacterDetails.MiddleARight_X, CharacterDetails.MiddleARight_Y, CharacterDetails.MiddleARight_Z, CharacterDetails.MiddleARight_W, MainViewModel.ViewTime5.bone_middle_r);
                CharacterDetails.MiddleARight_Toggle = true;
            }
            if (CharacterDetails.ThumbALeft_Rotate == true)
            {
                RotateHelper(CharacterDetails.ThumbALeft_X, CharacterDetails.ThumbALeft_Y, CharacterDetails.ThumbALeft_Z, CharacterDetails.ThumbALeft_W, MainViewModel.ViewTime5.bone_thumb_l);
                CharacterDetails.ThumbALeft_Toggle = true;
            }
            if (CharacterDetails.ThumbARight_Rotate == true)
            {
                RotateHelper(CharacterDetails.ThumbARight_X, CharacterDetails.ThumbARight_Y, CharacterDetails.ThumbARight_Z, CharacterDetails.ThumbARight_W, MainViewModel.ViewTime5.bone_thumb_r);
                CharacterDetails.ThumbARight_Toggle = true;
            }
            if (CharacterDetails.WeaponLeft_Rotate == true)
            {
                RotateHelper(CharacterDetails.WeaponLeft_X, CharacterDetails.WeaponLeft_Y, CharacterDetails.WeaponLeft_Z, CharacterDetails.WeaponLeft_W);
                CharacterDetails.WeaponLeft_Toggle = true;
            }
            if (CharacterDetails.WeaponRight_Rotate == true)
            {
                RotateHelper(CharacterDetails.WeaponRight_X, CharacterDetails.WeaponRight_Y, CharacterDetails.WeaponRight_Z, CharacterDetails.WeaponRight_W);
                CharacterDetails.WeaponRight_Toggle = true;
            }
            if (CharacterDetails.EarringBLeft_Rotate == true)
            {
                RotateHelper(CharacterDetails.EarringBLeft_X, CharacterDetails.EarringBLeft_Y, CharacterDetails.EarringBLeft_Z, CharacterDetails.EarringBLeft_W);
                CharacterDetails.EarringBLeft_Toggle = true;
            }
            if (CharacterDetails.EarringBRight_Rotate == true)
            {
                RotateHelper(CharacterDetails.EarringBRight_X, CharacterDetails.EarringBRight_Y, CharacterDetails.EarringBRight_Z, CharacterDetails.EarringBRight_W);
                CharacterDetails.EarringBRight_Toggle = true;
            }
            if (CharacterDetails.IndexBLeft_Rotate == true)
            {
                RotateHelper(CharacterDetails.IndexBLeft_X, CharacterDetails.IndexBLeft_Y, CharacterDetails.IndexBLeft_Z, CharacterDetails.IndexBLeft_W);
                CharacterDetails.IndexBLeft_Toggle = true;
            }
            if (CharacterDetails.IndexBRight_Rotate == true)
            {
                RotateHelper(CharacterDetails.IndexBRight_X, CharacterDetails.IndexBRight_Y, CharacterDetails.IndexBRight_Z, CharacterDetails.IndexBRight_W);
                CharacterDetails.IndexBRight_Toggle = true;
            }
            if (CharacterDetails.PinkyBLeft_Rotate == true)
            {
                RotateHelper(CharacterDetails.PinkyBLeft_X, CharacterDetails.PinkyBLeft_Y, CharacterDetails.PinkyBLeft_Z, CharacterDetails.PinkyBLeft_W);
                CharacterDetails.PinkyBLeft_Toggle = true;
            }
            if (CharacterDetails.PinkyBRight_Rotate == true)
            {
                RotateHelper(CharacterDetails.PinkyBRight_X, CharacterDetails.PinkyBRight_Y, CharacterDetails.PinkyBRight_Z, CharacterDetails.PinkyBRight_W);
                CharacterDetails.PinkyBRight_Toggle = true;
            }
            if (CharacterDetails.RingBLeft_Rotate == true)
            {
                RotateHelper(CharacterDetails.RingBLeft_X, CharacterDetails.RingBLeft_Y, CharacterDetails.RingBLeft_Z, CharacterDetails.RingBLeft_W);
                CharacterDetails.RingBLeft_Toggle = true;
            }
            if (CharacterDetails.RingBRight_Rotate == true)
            {
                RotateHelper(CharacterDetails.RingBRight_X, CharacterDetails.RingBRight_Y, CharacterDetails.RingBRight_Z, CharacterDetails.RingBRight_W);
                CharacterDetails.RingBRight_Toggle = true;
            }
            if (CharacterDetails.MiddleBLeft_Rotate == true)
            {
                RotateHelper(CharacterDetails.MiddleBLeft_X, CharacterDetails.MiddleBLeft_Y, CharacterDetails.MiddleBLeft_Z, CharacterDetails.MiddleBLeft_W);
                CharacterDetails.MiddleBLeft_Toggle = true;
            }
            if (CharacterDetails.MiddleBRight_Rotate == true)
            {
                RotateHelper(CharacterDetails.MiddleBRight_X, CharacterDetails.MiddleBRight_Y, CharacterDetails.MiddleBRight_Z, CharacterDetails.MiddleBRight_W);
                CharacterDetails.MiddleBRight_Toggle = true;
            }
            if (CharacterDetails.ThumbBLeft_Rotate == true)
            {
                RotateHelper(CharacterDetails.ThumbBLeft_X, CharacterDetails.ThumbBLeft_Y, CharacterDetails.ThumbBLeft_Z, CharacterDetails.ThumbBLeft_W);
                CharacterDetails.ThumbBLeft_Toggle = true;
            }
            if (CharacterDetails.ThumbBRight_Rotate == true)
            {
                RotateHelper(CharacterDetails.ThumbBRight_X, CharacterDetails.ThumbBRight_Y, CharacterDetails.ThumbBRight_Z, CharacterDetails.ThumbBRight_W);
                CharacterDetails.ThumbBRight_Toggle = true;
            }
            if (CharacterDetails.TailA_Rotate == true)
            {
                RotateHelper(CharacterDetails.TailA_X, CharacterDetails.TailA_Y, CharacterDetails.TailA_Z, CharacterDetails.TailA_W);
                CharacterDetails.TailA_Toggle = true;
            }
            if (CharacterDetails.TailB_Rotate == true)
            {
                RotateHelper(CharacterDetails.TailB_X, CharacterDetails.TailB_Y, CharacterDetails.TailB_Z, CharacterDetails.TailB_W);
                CharacterDetails.TailB_Toggle = true;
            }
            if (CharacterDetails.TailC_Rotate == true)
            {
                RotateHelper(CharacterDetails.TailC_X, CharacterDetails.TailC_Y, CharacterDetails.TailC_Z, CharacterDetails.TailC_W);
                CharacterDetails.TailC_Toggle = true;
            }
            if (CharacterDetails.TailD_Rotate == true)
            {
                RotateHelper(CharacterDetails.TailD_X, CharacterDetails.TailD_Y, CharacterDetails.TailD_Z, CharacterDetails.TailD_W);
                CharacterDetails.TailD_Toggle = true;
            }
            if (CharacterDetails.TailE_Rotate == true)
            {
                RotateHelper(CharacterDetails.TailE_X, CharacterDetails.TailE_Y, CharacterDetails.TailE_Z, CharacterDetails.TailE_W);
                CharacterDetails.TailE_Toggle = true;
            }
            if (CharacterDetails.RootHead_Rotate == true)
            {
                RotateHelper(CharacterDetails.RootHead_X, CharacterDetails.RootHead_Y, CharacterDetails.RootHead_Z, CharacterDetails.RootHead_W);
                CharacterDetails.RootHead_Toggle = true;
            }
            if (CharacterDetails.Jaw_Rotate == true)
            {
                RotateHelper(CharacterDetails.Jaw_X, CharacterDetails.Jaw_Y, CharacterDetails.Jaw_Z, CharacterDetails.Jaw_W);
                CharacterDetails.Jaw_Toggle = true;
            }
            if (CharacterDetails.EyelidLowerLeft_Rotate == true)
            {
                RotateHelper(CharacterDetails.EyelidLowerLeft_X, CharacterDetails.EyelidLowerLeft_Y, CharacterDetails.EyelidLowerLeft_Z, CharacterDetails.EyelidLowerLeft_W);
                CharacterDetails.EyelidLowerLeft_Toggle = true;
            }
            if (CharacterDetails.EyelidLowerRight_Rotate == true)
            {
                RotateHelper(CharacterDetails.EyelidLowerRight_X, CharacterDetails.EyelidLowerRight_Y, CharacterDetails.EyelidLowerRight_Z, CharacterDetails.EyelidLowerRight_W);
                CharacterDetails.EyelidLowerRight_Toggle = true;
            }
            if (CharacterDetails.EyeLeft_Rotate == true)
            {
                RotateHelper(CharacterDetails.EyeLeft_X, CharacterDetails.EyeLeft_Y, CharacterDetails.EyeLeft_Z, CharacterDetails.EyeLeft_W);
                CharacterDetails.EyeLeft_Toggle = true;
            }
            if (CharacterDetails.EyeRight_Rotate == true)
            {
                RotateHelper(CharacterDetails.EyeRight_X, CharacterDetails.EyeRight_Y, CharacterDetails.EyeRight_Z, CharacterDetails.EyeRight_W);
                CharacterDetails.EyeRight_Toggle = true;
            }
            if (CharacterDetails.Nose_Rotate == true)
            {
                RotateHelper(CharacterDetails.Nose_X, CharacterDetails.Nose_Y, CharacterDetails.Nose_Z, CharacterDetails.Nose_W);
                CharacterDetails.Nose_Toggle = true;
            }
            if (CharacterDetails.CheekLeft_Rotate == true)
            {
                RotateHelper(CharacterDetails.CheekLeft_X, CharacterDetails.CheekLeft_Y, CharacterDetails.CheekLeft_Z, CharacterDetails.CheekLeft_W);
                CharacterDetails.CheekLeft_Toggle = true;
            }
            if (CharacterDetails.HrothWhiskersLeft_Rotate == true)
            {
                RotateHelper(CharacterDetails.HrothWhiskersLeft_X, CharacterDetails.HrothWhiskersLeft_Y, CharacterDetails.HrothWhiskersLeft_Z, CharacterDetails.HrothWhiskersLeft_W);
                CharacterDetails.HrothWhiskersLeft_Toggle = true;
            }
            if (CharacterDetails.CheekRight_Rotate == true)
            {
                RotateHelper(CharacterDetails.CheekRight_X, CharacterDetails.CheekRight_Y, CharacterDetails.CheekRight_Z, CharacterDetails.CheekRight_W);
                CharacterDetails.CheekRight_Toggle = true;
            }
            if (CharacterDetails.HrothWhiskersRight_Rotate == true)
            {
                RotateHelper(CharacterDetails.HrothWhiskersRight_X, CharacterDetails.HrothWhiskersRight_Y, CharacterDetails.HrothWhiskersRight_Z, CharacterDetails.HrothWhiskersRight_W);
                CharacterDetails.HrothWhiskersRight_Toggle = true;
            }
            if (CharacterDetails.LipsLeft_Rotate == true)
            {
                RotateHelper(CharacterDetails.LipsLeft_X, CharacterDetails.LipsLeft_Y, CharacterDetails.LipsLeft_Z, CharacterDetails.LipsLeft_W);
                CharacterDetails.LipsLeft_Toggle = true;
            }
            if (CharacterDetails.HrothEyebrowLeft_Rotate == true)
            {
                RotateHelper(CharacterDetails.HrothEyebrowLeft_X, CharacterDetails.HrothEyebrowLeft_Y, CharacterDetails.HrothEyebrowLeft_Z, CharacterDetails.HrothEyebrowLeft_W);
                CharacterDetails.HrothEyebrowLeft_Toggle = true;
            }
            if (CharacterDetails.LipsRight_Rotate == true)
            {
                RotateHelper(CharacterDetails.LipsRight_X, CharacterDetails.LipsRight_Y, CharacterDetails.LipsRight_Z, CharacterDetails.LipsRight_W);
                CharacterDetails.LipsRight_Toggle = true;
            }
            if (CharacterDetails.HrothEyebrowRight_Rotate == true)
            {
                RotateHelper(CharacterDetails.HrothEyebrowRight_X, CharacterDetails.HrothEyebrowRight_Y, CharacterDetails.HrothEyebrowRight_Z, CharacterDetails.HrothEyebrowRight_W);
                CharacterDetails.HrothEyebrowRight_Toggle = true;
            }
            if (CharacterDetails.EyebrowLeft_Rotate == true)
            {
                RotateHelper(CharacterDetails.EyebrowLeft_X, CharacterDetails.EyebrowLeft_Y, CharacterDetails.EyebrowLeft_Z, CharacterDetails.EyebrowLeft_W);
                CharacterDetails.EyebrowLeft_Toggle = true;
            }
            if (CharacterDetails.HrothBridge_Rotate == true)
            {
                RotateHelper(CharacterDetails.HrothBridge_X, CharacterDetails.HrothBridge_Y, CharacterDetails.HrothBridge_Z, CharacterDetails.HrothBridge_W);
                CharacterDetails.HrothBridge_Toggle = true;
            }
            if (CharacterDetails.EyebrowRight_Rotate == true)
            {
                RotateHelper(CharacterDetails.EyebrowRight_X, CharacterDetails.EyebrowRight_Y, CharacterDetails.EyebrowRight_Z, CharacterDetails.EyebrowRight_W);
                CharacterDetails.EyebrowRight_Toggle = true;
            }
            if (CharacterDetails.HrothBrowLeft_Rotate == true)
            {
                RotateHelper(CharacterDetails.HrothBrowLeft_X, CharacterDetails.HrothBrowLeft_Y, CharacterDetails.HrothBrowLeft_Z, CharacterDetails.HrothBrowLeft_W);
                CharacterDetails.HrothBrowLeft_Toggle = true;
            }
            if (CharacterDetails.Bridge_Rotate == true)
            {
                RotateHelper(CharacterDetails.Bridge_X, CharacterDetails.Bridge_Y, CharacterDetails.Bridge_Z, CharacterDetails.Bridge_W);
                CharacterDetails.Bridge_Toggle = true;
            }
            if (CharacterDetails.HrothBrowRight_Rotate == true)
            {
                RotateHelper(CharacterDetails.HrothBrowRight_X, CharacterDetails.HrothBrowRight_Y, CharacterDetails.HrothBrowRight_Z, CharacterDetails.HrothBrowRight_W);
                CharacterDetails.HrothBrowRight_Toggle = true;
            }
            if (CharacterDetails.BrowLeft_Rotate == true)
            {
                RotateHelper(CharacterDetails.BrowLeft_X, CharacterDetails.BrowLeft_Y, CharacterDetails.BrowLeft_Z, CharacterDetails.BrowLeft_W);
                CharacterDetails.BrowLeft_Toggle = true;
            }
            if (CharacterDetails.HrothJawUpper_Rotate == true)
            {
                RotateHelper(CharacterDetails.HrothJawUpper_X, CharacterDetails.HrothJawUpper_Y, CharacterDetails.HrothJawUpper_Z, CharacterDetails.HrothJawUpper_W);
                CharacterDetails.HrothJawUpper_Toggle = true;
            }
            if (CharacterDetails.BrowRight_Rotate == true)
            {
                RotateHelper(CharacterDetails.BrowRight_X, CharacterDetails.BrowRight_Y, CharacterDetails.BrowRight_Z, CharacterDetails.BrowRight_W);
                CharacterDetails.BrowRight_Toggle = true;
            }
            if (CharacterDetails.HrothLipUpper_Rotate == true)
            {
                RotateHelper(CharacterDetails.HrothLipUpper_X, CharacterDetails.HrothLipUpper_Y, CharacterDetails.HrothLipUpper_Z, CharacterDetails.HrothLipUpper_W);
                CharacterDetails.HrothLipUpper_Toggle = true;
            }
            if (CharacterDetails.LipUpperA_Rotate == true)
            {
                RotateHelper(CharacterDetails.LipUpperA_X, CharacterDetails.LipUpperA_Y, CharacterDetails.LipUpperA_Z, CharacterDetails.LipUpperA_W);
                CharacterDetails.LipUpperA_Toggle = true;
            }
            if (CharacterDetails.HrothEyelidUpperLeft_Rotate == true)
            {
                RotateHelper(CharacterDetails.HrothEyelidUpperLeft_X, CharacterDetails.HrothEyelidUpperLeft_Y, CharacterDetails.HrothEyelidUpperLeft_Z, CharacterDetails.HrothEyelidUpperLeft_W);
                CharacterDetails.HrothEyelidUpperLeft_Toggle = true;
            }
            if (CharacterDetails.EyelidUpperLeft_Rotate == true)
            {
                RotateHelper(CharacterDetails.EyelidUpperLeft_X, CharacterDetails.EyelidUpperLeft_Y, CharacterDetails.EyelidUpperLeft_Z, CharacterDetails.EyelidUpperLeft_W);
                CharacterDetails.EyelidUpperLeft_Toggle = true;
            }
            if (CharacterDetails.HrothEyelidUpperRight_Rotate == true)
            {
                RotateHelper(CharacterDetails.HrothEyelidUpperRight_X, CharacterDetails.HrothEyelidUpperRight_Y, CharacterDetails.HrothEyelidUpperRight_Z, CharacterDetails.HrothEyelidUpperRight_W);
                CharacterDetails.HrothEyelidUpperRight_Toggle = true;
            }
            if (CharacterDetails.EyelidUpperRight_Rotate == true)
            {
                RotateHelper(CharacterDetails.EyelidUpperRight_X, CharacterDetails.EyelidUpperRight_Y, CharacterDetails.EyelidUpperRight_Z, CharacterDetails.EyelidUpperRight_W);
                CharacterDetails.EyelidUpperRight_Toggle = true;
            }
            if (CharacterDetails.HrothLipsLeft_Rotate == true)
            {
                RotateHelper(CharacterDetails.HrothLipsLeft_X, CharacterDetails.HrothLipsLeft_Y, CharacterDetails.HrothLipsLeft_Z, CharacterDetails.HrothLipsLeft_W);
                CharacterDetails.HrothLipsLeft_Toggle = true;
            }
            if (CharacterDetails.LipLowerA_Rotate == true)
            {
                RotateHelper(CharacterDetails.LipLowerA_X, CharacterDetails.LipLowerA_Y, CharacterDetails.LipLowerA_Z, CharacterDetails.LipLowerA_W);
                CharacterDetails.LipLowerA_Toggle = true;
            }
            if (CharacterDetails.HrothLipsRight_Rotate == true)
            {
                RotateHelper(CharacterDetails.HrothLipsRight_X, CharacterDetails.HrothLipsRight_Y, CharacterDetails.HrothLipsRight_Z, CharacterDetails.HrothLipsRight_W);
                CharacterDetails.HrothLipsRight_Toggle = true;
            }
            if (CharacterDetails.VieraEar01ALeft_Rotate == true)
            {
                RotateHelper(CharacterDetails.VieraEar01ALeft_X, CharacterDetails.VieraEar01ALeft_Y, CharacterDetails.VieraEar01ALeft_Z, CharacterDetails.VieraEar01ALeft_W);
                CharacterDetails.VieraEar01ALeft_Toggle = true;
            }
            if (CharacterDetails.LipUpperB_Rotate == true)
            {
                RotateHelper(CharacterDetails.LipUpperB_X, CharacterDetails.LipUpperB_Y, CharacterDetails.LipUpperB_Z, CharacterDetails.LipUpperB_W);
                CharacterDetails.LipUpperB_Toggle = true;
            }
            if (CharacterDetails.HrothLipUpperLeft_Rotate == true)
            {
                RotateHelper(CharacterDetails.HrothLipUpperLeft_X, CharacterDetails.HrothLipUpperLeft_Y, CharacterDetails.HrothLipUpperLeft_Z, CharacterDetails.HrothLipUpperLeft_W);
                CharacterDetails.HrothLipUpperLeft_Toggle = true;
            }
            if (CharacterDetails.VieraEar01ARight_Rotate == true)
            {
                RotateHelper(CharacterDetails.VieraEar01ARight_X, CharacterDetails.VieraEar01ARight_Y, CharacterDetails.VieraEar01ARight_Z, CharacterDetails.VieraEar01ARight_W);
                CharacterDetails.VieraEar01ARight_Toggle = true;
            }
            if (CharacterDetails.LipLowerB_Rotate == true)
            {
                RotateHelper(CharacterDetails.LipLowerB_X, CharacterDetails.LipLowerB_Y, CharacterDetails.LipLowerB_Z, CharacterDetails.LipLowerB_W);
                CharacterDetails.LipLowerB_Toggle = true;
            }
            if (CharacterDetails.HrothLipUpperRight_Rotate == true)
            {
                RotateHelper(CharacterDetails.HrothLipUpperRight_X, CharacterDetails.HrothLipUpperRight_Y, CharacterDetails.HrothLipUpperRight_Z, CharacterDetails.HrothLipUpperRight_W);
                CharacterDetails.HrothLipUpperRight_Toggle = true;
            }
            if (CharacterDetails.VieraEar02ALeft_Rotate == true)
            {
                RotateHelper(CharacterDetails.VieraEar02ALeft_X, CharacterDetails.VieraEar02ALeft_Y, CharacterDetails.VieraEar02ALeft_Z, CharacterDetails.VieraEar02ALeft_W);
                CharacterDetails.VieraEar02ALeft_Toggle = true;
            }
            if (CharacterDetails.HrothLipLower_Rotate == true)
            {
                RotateHelper(CharacterDetails.HrothLipLower_X, CharacterDetails.HrothLipLower_Y, CharacterDetails.HrothLipLower_Z, CharacterDetails.HrothLipLower_W);
                CharacterDetails.HrothLipLower_Toggle = true;
            }
            if (CharacterDetails.VieraEar02ARight_Rotate == true)
            {
                RotateHelper(CharacterDetails.VieraEar02ARight_X, CharacterDetails.VieraEar02ARight_Y, CharacterDetails.VieraEar02ARight_Z, CharacterDetails.VieraEar02ARight_W);
                CharacterDetails.VieraEar02ARight_Toggle = true;
            }
            if (CharacterDetails.VieraEar03ALeft_Rotate == true)
            {
                RotateHelper(CharacterDetails.VieraEar03ALeft_X, CharacterDetails.VieraEar03ALeft_Y, CharacterDetails.VieraEar03ALeft_Z, CharacterDetails.VieraEar03ALeft_W);
                CharacterDetails.VieraEar03ALeft_Toggle = true;
            }
            if (CharacterDetails.VieraEar03ARight_Rotate == true)
            {
                RotateHelper(CharacterDetails.VieraEar03ARight_X, CharacterDetails.VieraEar03ARight_Y, CharacterDetails.VieraEar03ARight_Z, CharacterDetails.VieraEar03ARight_W);
                CharacterDetails.VieraEar03ARight_Toggle = true;
            }
            if (CharacterDetails.VieraEar04ALeft_Rotate == true)
            {
                RotateHelper(CharacterDetails.VieraEar04ALeft_X, CharacterDetails.VieraEar04ALeft_Y, CharacterDetails.VieraEar04ALeft_Z, CharacterDetails.VieraEar04ALeft_W);
                CharacterDetails.VieraEar04ALeft_Toggle = true;
            }
            if (CharacterDetails.VieraEar04ARight_Rotate == true)
            {
                RotateHelper(CharacterDetails.VieraEar04ARight_X, CharacterDetails.VieraEar04ARight_Y, CharacterDetails.VieraEar04ARight_Z, CharacterDetails.VieraEar04ARight_W);
                CharacterDetails.VieraEar04ARight_Toggle = true;
            }
            if (CharacterDetails.VieraLipLowerA_Rotate == true)
            {
                RotateHelper(CharacterDetails.VieraLipLowerA_X, CharacterDetails.VieraLipLowerA_Y, CharacterDetails.VieraLipLowerA_Z, CharacterDetails.VieraLipLowerA_W);
                CharacterDetails.VieraLipLowerA_Toggle = true;
            }
            if (CharacterDetails.VieraLipUpperB_Rotate == true)
            {
                RotateHelper(CharacterDetails.VieraLipUpperB_X, CharacterDetails.VieraLipUpperB_Y, CharacterDetails.VieraLipUpperB_Z, CharacterDetails.VieraLipUpperB_W);
                CharacterDetails.VieraLipUpperB_Toggle = true;
            }
            if (CharacterDetails.VieraEar01BLeft_Rotate == true)
            {
                RotateHelper(CharacterDetails.VieraEar01BLeft_X, CharacterDetails.VieraEar01BLeft_Y, CharacterDetails.VieraEar01BLeft_Z, CharacterDetails.VieraEar01BLeft_W);
                CharacterDetails.VieraEar01BLeft_Toggle = true;
            }
            if (CharacterDetails.VieraEar01BRight_Rotate == true)
            {
                RotateHelper(CharacterDetails.VieraEar01BRight_X, CharacterDetails.VieraEar01BRight_Y, CharacterDetails.VieraEar01BRight_Z, CharacterDetails.VieraEar01BRight_W);
                CharacterDetails.VieraEar01BRight_Toggle = true;
            }
            if (CharacterDetails.VieraEar02BLeft_Rotate == true)
            {
                RotateHelper(CharacterDetails.VieraEar02BLeft_X, CharacterDetails.VieraEar02BLeft_Y, CharacterDetails.VieraEar02BLeft_Z, CharacterDetails.VieraEar02BLeft_W);
                CharacterDetails.VieraEar02BLeft_Toggle = true;
            }
            if (CharacterDetails.VieraEar02BRight_Rotate == true)
            {
                RotateHelper(CharacterDetails.VieraEar02BRight_X, CharacterDetails.VieraEar02BRight_Y, CharacterDetails.VieraEar02BRight_Z, CharacterDetails.VieraEar02BRight_W);
                CharacterDetails.VieraEar02BRight_Toggle = true;
            }
            if (CharacterDetails.VieraEar03BLeft_Rotate == true)
            {
                RotateHelper(CharacterDetails.VieraEar03BLeft_X, CharacterDetails.VieraEar03BLeft_Y, CharacterDetails.VieraEar03BLeft_Z, CharacterDetails.VieraEar03BLeft_W);
                CharacterDetails.VieraEar03BLeft_Toggle = true;
            }
            if (CharacterDetails.VieraEar03BRight_Rotate == true)
            {
                RotateHelper(CharacterDetails.VieraEar03BRight_X, CharacterDetails.VieraEar03BRight_Y, CharacterDetails.VieraEar03BRight_Z, CharacterDetails.VieraEar03BRight_W);
                CharacterDetails.VieraEar03BRight_Toggle = true;
            }
            if (CharacterDetails.VieraEar04BLeft_Rotate == true)
            {
                RotateHelper(CharacterDetails.VieraEar04BLeft_X, CharacterDetails.VieraEar04BLeft_Y, CharacterDetails.VieraEar04BLeft_Z, CharacterDetails.VieraEar04BLeft_W);
                CharacterDetails.VieraEar04BLeft_Toggle = true;
            }
            if (CharacterDetails.VieraEar04BRight_Rotate == true)
            {
                RotateHelper(CharacterDetails.VieraEar04BRight_X, CharacterDetails.VieraEar04BRight_Y, CharacterDetails.VieraEar04BRight_Z, CharacterDetails.VieraEar04BRight_W);
                CharacterDetails.VieraEar04BRight_Toggle = true;
            }
            if (CharacterDetails.VieraLipLowerB_Rotate == true)
            {
                RotateHelper(CharacterDetails.VieraLipLowerB_X, CharacterDetails.VieraLipLowerB_Y, CharacterDetails.VieraLipLowerB_Z, CharacterDetails.VieraLipLowerB_W);
                CharacterDetails.VieraLipLowerB_Toggle = true;
            }
            if (CharacterDetails.ExRootHair_Rotate == true)
            {
                RotateHelper(CharacterDetails.ExRootHair_X, CharacterDetails.ExRootHair_Y, CharacterDetails.ExRootHair_Z, CharacterDetails.ExRootHair_W);
                CharacterDetails.ExRootHair_Toggle = true;
            }
            if (CharacterDetails.ExHairA_Rotate == true)
            {
                RotateHelper(CharacterDetails.ExHairA_X, CharacterDetails.ExHairA_Y, CharacterDetails.ExHairA_Z, CharacterDetails.ExHairA_W);
                CharacterDetails.ExHairA_Toggle = true;
            }
            if (CharacterDetails.ExHairB_Rotate == true)
            {
                RotateHelper(CharacterDetails.ExHairB_X, CharacterDetails.ExHairB_Y, CharacterDetails.ExHairB_Z, CharacterDetails.ExHairB_W);
                CharacterDetails.ExHairB_Toggle = true;
            }
            if (CharacterDetails.ExHairC_Rotate == true)
            {
                RotateHelper(CharacterDetails.ExHairC_X, CharacterDetails.ExHairC_Y, CharacterDetails.ExHairC_Z, CharacterDetails.ExHairC_W);
                CharacterDetails.ExHairC_Toggle = true;
            }
            if (CharacterDetails.ExHairD_Rotate == true)
            {
                RotateHelper(CharacterDetails.ExHairD_X, CharacterDetails.ExHairD_Y, CharacterDetails.ExHairD_Z, CharacterDetails.ExHairD_W);
                CharacterDetails.ExHairD_Toggle = true;
            }
            if (CharacterDetails.ExHairE_Rotate == true)
            {
                RotateHelper(CharacterDetails.ExHairE_X, CharacterDetails.ExHairE_Y, CharacterDetails.ExHairE_Z, CharacterDetails.ExHairE_W);
                CharacterDetails.ExHairE_Toggle = true;
            }
            if (CharacterDetails.ExHairF_Rotate == true)
            {
                RotateHelper(CharacterDetails.ExHairF_X, CharacterDetails.ExHairF_Y, CharacterDetails.ExHairF_Z, CharacterDetails.ExHairF_W);
                CharacterDetails.ExHairF_Toggle = true;
            }
            if (CharacterDetails.ExHairG_Rotate == true)
            {
                RotateHelper(CharacterDetails.ExHairG_X, CharacterDetails.ExHairG_Y, CharacterDetails.ExHairG_Z, CharacterDetails.ExHairG_W);
                CharacterDetails.ExHairG_Toggle = true;
            }
            if (CharacterDetails.ExHairH_Rotate == true)
            {
                RotateHelper(CharacterDetails.ExHairH_X, CharacterDetails.ExHairH_Y, CharacterDetails.ExHairH_Z, CharacterDetails.ExHairH_W);
                CharacterDetails.ExHairH_Toggle = true;
            }
            if (CharacterDetails.ExHairI_Rotate == true)
            {
                RotateHelper(CharacterDetails.ExHairI_X, CharacterDetails.ExHairI_Y, CharacterDetails.ExHairI_Z, CharacterDetails.ExHairI_W);
                CharacterDetails.ExHairI_Toggle = true;
            }
            if (CharacterDetails.ExHairJ_Rotate == true)
            {
                RotateHelper(CharacterDetails.ExHairJ_X, CharacterDetails.ExHairJ_Y, CharacterDetails.ExHairJ_Z, CharacterDetails.ExHairJ_W);
                CharacterDetails.ExHairJ_Toggle = true;
            }
            if (CharacterDetails.ExHairK_Rotate == true)
            {
                RotateHelper(CharacterDetails.ExHairK_X, CharacterDetails.ExHairK_Y, CharacterDetails.ExHairK_Z, CharacterDetails.ExHairK_W);
                CharacterDetails.ExHairK_Toggle = true;
            }
            if (CharacterDetails.ExHairL_Rotate == true)
            {
                RotateHelper(CharacterDetails.ExHairL_X, CharacterDetails.ExHairL_Y, CharacterDetails.ExHairL_Z, CharacterDetails.ExHairL_W);
                CharacterDetails.ExHairL_Toggle = true;
            }
            if (CharacterDetails.ExRootMet_Rotate == true)
            {
                RotateHelper(CharacterDetails.ExRootMet_X, CharacterDetails.ExRootMet_Y, CharacterDetails.ExRootMet_Z, CharacterDetails.ExRootMet_W);
                CharacterDetails.ExRootMet_Toggle = true;
            }
            if (CharacterDetails.ExMetA_Rotate == true)
            {
                RotateHelper(CharacterDetails.ExMetA_X, CharacterDetails.ExMetA_Y, CharacterDetails.ExMetA_Z, CharacterDetails.ExMetA_W);
                CharacterDetails.ExMetA_Toggle = true;
            }
            if (CharacterDetails.ExMetB_Rotate == true)
            {
                RotateHelper(CharacterDetails.ExMetB_X, CharacterDetails.ExMetB_Y, CharacterDetails.ExMetB_Z, CharacterDetails.ExMetB_W);
                CharacterDetails.ExMetB_Toggle = true;
            }
            if (CharacterDetails.ExMetC_Rotate == true)
            {
                RotateHelper(CharacterDetails.ExMetC_X, CharacterDetails.ExMetC_Y, CharacterDetails.ExMetC_Z, CharacterDetails.ExMetC_W);
                CharacterDetails.ExMetC_Toggle = true;
            }
            if (CharacterDetails.ExMetD_Rotate == true)
            {
                RotateHelper(CharacterDetails.ExMetD_X, CharacterDetails.ExMetD_Y, CharacterDetails.ExMetD_Z, CharacterDetails.ExMetD_W);
                CharacterDetails.ExMetD_Toggle = true;
            }
            if (CharacterDetails.ExMetE_Rotate == true)
            {
                RotateHelper(CharacterDetails.ExMetE_X, CharacterDetails.ExMetE_Y, CharacterDetails.ExMetE_Z, CharacterDetails.ExMetE_W);
                CharacterDetails.ExMetE_Toggle = true;
            }
            if (CharacterDetails.ExMetF_Rotate == true)
            {
                RotateHelper(CharacterDetails.ExMetF_X, CharacterDetails.ExMetF_Y, CharacterDetails.ExMetF_Z, CharacterDetails.ExMetF_W);
                CharacterDetails.ExMetF_Toggle = true;
            }
            if (CharacterDetails.ExMetG_Rotate == true)
            {
                RotateHelper(CharacterDetails.ExMetG_X, CharacterDetails.ExMetG_Y, CharacterDetails.ExMetG_Z, CharacterDetails.ExMetG_W);
                CharacterDetails.ExMetG_Toggle = true;
            }
            if (CharacterDetails.ExMetH_Rotate == true)
            {
                RotateHelper(CharacterDetails.ExMetH_X, CharacterDetails.ExMetH_Y, CharacterDetails.ExMetH_Z, CharacterDetails.ExMetH_W);
                CharacterDetails.ExMetH_Toggle = true;
            }
            if (CharacterDetails.ExMetI_Rotate == true)
            {
                RotateHelper(CharacterDetails.ExMetI_X, CharacterDetails.ExMetI_Y, CharacterDetails.ExMetI_Z, CharacterDetails.ExMetI_W);
                CharacterDetails.ExMetI_Toggle = true;
            }
            if (CharacterDetails.ExMetJ_Rotate == true)
            {
                RotateHelper(CharacterDetails.ExMetJ_X, CharacterDetails.ExMetJ_Y, CharacterDetails.ExMetJ_Z, CharacterDetails.ExMetJ_W);
                CharacterDetails.ExMetJ_Toggle = true;
            }
            if (CharacterDetails.ExMetK_Rotate == true)
            {
                RotateHelper(CharacterDetails.ExMetK_X, CharacterDetails.ExMetK_Y, CharacterDetails.ExMetK_Z, CharacterDetails.ExMetK_W);
                CharacterDetails.ExMetK_Toggle = true;
            }
            if (CharacterDetails.ExMetL_Rotate == true)
            {
                RotateHelper(CharacterDetails.ExMetL_X, CharacterDetails.ExMetL_Y, CharacterDetails.ExMetL_Z, CharacterDetails.ExMetL_W);
                CharacterDetails.ExMetL_Toggle = true;
            }
            if (CharacterDetails.ExMetM_Rotate == true)
            {
                RotateHelper(CharacterDetails.ExMetM_X, CharacterDetails.ExMetM_Y, CharacterDetails.ExMetM_Z, CharacterDetails.ExMetM_W);
                CharacterDetails.ExMetM_Toggle = true;
            }
            if (CharacterDetails.ExMetN_Rotate == true)
            {
                RotateHelper(CharacterDetails.ExMetN_X, CharacterDetails.ExMetN_Y, CharacterDetails.ExMetN_Z, CharacterDetails.ExMetN_W);
                CharacterDetails.ExMetN_Toggle = true;
            }
            if (CharacterDetails.ExMetO_Rotate == true)
            {
                RotateHelper(CharacterDetails.ExMetO_X, CharacterDetails.ExMetO_Y, CharacterDetails.ExMetO_Z, CharacterDetails.ExMetO_W);
                CharacterDetails.ExMetO_Toggle = true;
            }
            if (CharacterDetails.ExMetP_Rotate == true)
            {
                RotateHelper(CharacterDetails.ExMetP_X, CharacterDetails.ExMetP_Y, CharacterDetails.ExMetP_Z, CharacterDetails.ExMetP_W);
                CharacterDetails.ExMetP_Toggle = true;
            }
            if (CharacterDetails.ExMetQ_Rotate == true)
            {
                RotateHelper(CharacterDetails.ExMetQ_X, CharacterDetails.ExMetQ_Y, CharacterDetails.ExMetQ_Z, CharacterDetails.ExMetQ_W);
                CharacterDetails.ExMetQ_Toggle = true;
            }
            if (CharacterDetails.ExMetR_Rotate == true)
            {
                RotateHelper(CharacterDetails.ExMetR_X, CharacterDetails.ExMetR_Y, CharacterDetails.ExMetR_Z, CharacterDetails.ExMetR_W);
                CharacterDetails.ExMetR_Toggle = true;
            }
            if (CharacterDetails.ExRootTop_Rotate == true)
            {
                RotateHelper(CharacterDetails.ExRootTop_X, CharacterDetails.ExRootTop_Y, CharacterDetails.ExRootTop_Z, CharacterDetails.ExRootTop_W);
                CharacterDetails.ExRootTop_Toggle = true;
            }
            if (CharacterDetails.ExTopA_Rotate == true)
            {
                RotateHelper(CharacterDetails.ExTopA_X, CharacterDetails.ExTopA_Y, CharacterDetails.ExTopA_Z, CharacterDetails.ExTopA_W);
                CharacterDetails.ExTopA_Toggle = true;
            }
            if (CharacterDetails.ExTopB_Rotate == true)
            {
                RotateHelper(CharacterDetails.ExTopB_X, CharacterDetails.ExTopB_Y, CharacterDetails.ExTopB_Z, CharacterDetails.ExTopB_W);
                CharacterDetails.ExTopB_Toggle = true;
            }
            if (CharacterDetails.ExTopC_Rotate == true)
            {
                RotateHelper(CharacterDetails.ExTopC_X, CharacterDetails.ExTopC_Y, CharacterDetails.ExTopC_Z, CharacterDetails.ExTopC_W);
                CharacterDetails.ExTopC_Toggle = true;
            }
            if (CharacterDetails.ExTopD_Rotate == true)
            {
                RotateHelper(CharacterDetails.ExTopD_X, CharacterDetails.ExTopD_Y, CharacterDetails.ExTopD_Z, CharacterDetails.ExTopD_W);
                CharacterDetails.ExTopD_Toggle = true;
            }
            if (CharacterDetails.ExTopE_Rotate == true)
            {
                RotateHelper(CharacterDetails.ExTopE_X, CharacterDetails.ExTopE_Y, CharacterDetails.ExTopE_Z, CharacterDetails.ExTopE_W);
                CharacterDetails.ExTopE_Toggle = true;
            }
            if (CharacterDetails.ExTopF_Rotate == true)
            {
                RotateHelper(CharacterDetails.ExTopF_X, CharacterDetails.ExTopF_Y, CharacterDetails.ExTopF_Z, CharacterDetails.ExTopF_W);
                CharacterDetails.ExTopF_Toggle = true;
            }
            if (CharacterDetails.ExTopG_Rotate == true)
            {
                RotateHelper(CharacterDetails.ExTopG_X, CharacterDetails.ExTopG_Y, CharacterDetails.ExTopG_Z, CharacterDetails.ExTopG_W);
                CharacterDetails.ExTopG_Toggle = true;
            }
            if (CharacterDetails.ExTopH_Rotate == true)
            {
                RotateHelper(CharacterDetails.ExTopH_X, CharacterDetails.ExTopH_Y, CharacterDetails.ExTopH_Z, CharacterDetails.ExTopH_W);
                CharacterDetails.ExTopH_Toggle = true;
            }
            if (CharacterDetails.ExTopI_Rotate == true)
            {
                RotateHelper(CharacterDetails.ExTopI_X, CharacterDetails.ExTopI_Y, CharacterDetails.ExTopI_Z, CharacterDetails.ExTopI_W);
                CharacterDetails.ExTopI_Toggle = true;
            }
        }
    }
}
