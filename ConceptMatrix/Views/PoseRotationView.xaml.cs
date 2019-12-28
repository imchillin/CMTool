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

        private DragState dragState;

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

            dragState.lastPoint = e.MouseDevice.GetPosition(el);
            dragState.isTracking = true;
            dragState.mouseButton = e.ChangedButton;
            el.CaptureMouse();
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
                CharacterDetails.Root_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.Root_X), "float", ((float)q.X).ToString());
                CharacterDetails.Root_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.Root_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.Root_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.Root_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.Root_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.Root_W), "float", ((float)q.W).ToString());
                CharacterDetails.Root_Toggle = true;
            }
            if (CharacterDetails.Abdomen_Rotate == true)
            {
                CharacterDetails.Abdomen_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.Abdomen_X), "float", ((float)q.X).ToString());
                CharacterDetails.Abdomen_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.Abdomen_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.Abdomen_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.Abdomen_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.Abdomen_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.Abdomen_W), "float", ((float)q.W).ToString());
                CharacterDetails.Abdomen_Toggle = true;
            }
            if (CharacterDetails.Throw_Rotate == true)
            {
                CharacterDetails.Throw_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.Throw_X), "float", ((float)q.X).ToString());
                CharacterDetails.Throw_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.Throw_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.Throw_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.Throw_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.Throw_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.Throw_W), "float", ((float)q.W).ToString());
                CharacterDetails.Throw_Toggle = true;
            }
            if (CharacterDetails.Waist_Rotate == true)
            {
                MainViewModel.ViewTime5.RotateHelper(q, CharacterDetails.Waist_X, CharacterDetails.Waist_Y, CharacterDetails.Waist_Z, CharacterDetails.Waist_W, MainViewModel.ViewTime5.bone_waist);
                CharacterDetails.Waist_Toggle = true;
            }
            if (CharacterDetails.SpineA_Rotate == true)
            {
                CharacterDetails.SpineA_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.SpineA_X), "float", ((float)q.X).ToString());
                CharacterDetails.SpineA_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.SpineA_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.SpineA_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.SpineA_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.SpineA_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.SpineA_W), "float", ((float)q.W).ToString());
                CharacterDetails.SpineA_Toggle = true;
            }
            if (CharacterDetails.LegLeft_Rotate == true)
            {
                CharacterDetails.LegLeft_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.LegLeft_X), "float", ((float)q.X).ToString());
                CharacterDetails.LegLeft_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.LegLeft_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.LegLeft_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.LegLeft_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.LegLeft_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.LegLeft_W), "float", ((float)q.W).ToString());
                CharacterDetails.LegLeft_Toggle = true;
            }
            if (CharacterDetails.LegRight_Rotate == true)
            {
                CharacterDetails.LegRight_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.LegRight_X), "float", ((float)q.X).ToString());
                CharacterDetails.LegRight_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.LegRight_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.LegRight_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.LegRight_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.LegRight_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.LegRight_W), "float", ((float)q.W).ToString());
                CharacterDetails.LegRight_Toggle = true;
            }
            if (CharacterDetails.HolsterLeft_Rotate == true)
            {
                CharacterDetails.HolsterLeft_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.HolsterLeft_X), "float", ((float)q.X).ToString());
                CharacterDetails.HolsterLeft_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.HolsterLeft_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.HolsterLeft_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.HolsterLeft_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.HolsterLeft_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.HolsterLeft_W), "float", ((float)q.W).ToString());
                CharacterDetails.HolsterLeft_Toggle = true;
            }
            if (CharacterDetails.HolsterRight_Rotate == true)
            {
                CharacterDetails.HolsterRight_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.HolsterRight_X), "float", ((float)q.X).ToString());
                CharacterDetails.HolsterRight_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.HolsterRight_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.HolsterRight_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.HolsterRight_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.HolsterRight_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.HolsterRight_W), "float", ((float)q.W).ToString());
                CharacterDetails.HolsterRight_Toggle = true;
            }
            if (CharacterDetails.SheatheLeft_Rotate == true)
            {
                CharacterDetails.SheatheLeft_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.SheatheLeft_X), "float", ((float)q.X).ToString());
                CharacterDetails.SheatheLeft_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.SheatheLeft_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.SheatheLeft_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.SheatheLeft_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.SheatheLeft_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.SheatheLeft_W), "float", ((float)q.W).ToString());
                CharacterDetails.SheatheLeft_Toggle = true;
            }
            if (CharacterDetails.SheatheRight_Rotate == true)
            {
                CharacterDetails.SheatheRight_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.SheatheRight_X), "float", ((float)q.X).ToString());
                CharacterDetails.SheatheRight_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.SheatheRight_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.SheatheRight_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.SheatheRight_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.SheatheRight_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.SheatheRight_W), "float", ((float)q.W).ToString());
                CharacterDetails.SheatheRight_Toggle = true;
            }
            if (CharacterDetails.SpineB_Rotate == true)
            {
                CharacterDetails.SpineB_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.SpineB_X), "float", ((float)q.X).ToString());
                CharacterDetails.SpineB_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.SpineB_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.SpineB_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.SpineB_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.SpineB_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.SpineB_W), "float", ((float)q.W).ToString());
                CharacterDetails.SpineB_Toggle = true;
            }
            if (CharacterDetails.ClothBackALeft_Rotate == true)
            {
                CharacterDetails.ClothBackALeft_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ClothBackALeft_X), "float", ((float)q.X).ToString());
                CharacterDetails.ClothBackALeft_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ClothBackALeft_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.ClothBackALeft_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ClothBackALeft_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.ClothBackALeft_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ClothBackALeft_W), "float", ((float)q.W).ToString());
                CharacterDetails.ClothBackALeft_Toggle = true;
            }
            if (CharacterDetails.ClothBackARight_Rotate == true)
            {
                CharacterDetails.ClothBackARight_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ClothBackARight_X), "float", ((float)q.X).ToString());
                CharacterDetails.ClothBackARight_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ClothBackARight_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.ClothBackARight_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ClothBackARight_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.ClothBackARight_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ClothBackARight_W), "float", ((float)q.W).ToString());
                CharacterDetails.ClothBackARight_Toggle = true;
            }
            if (CharacterDetails.ClothFrontALeft_Rotate == true)
            {
                CharacterDetails.ClothFrontALeft_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ClothFrontALeft_X), "float", ((float)q.X).ToString());
                CharacterDetails.ClothFrontALeft_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ClothFrontALeft_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.ClothFrontALeft_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ClothFrontALeft_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.ClothFrontALeft_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ClothFrontALeft_W), "float", ((float)q.W).ToString());
                CharacterDetails.ClothFrontALeft_Toggle = true;
            }
            if (CharacterDetails.ClothFrontARight_Rotate == true)
            {
                CharacterDetails.ClothFrontARight_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ClothFrontARight_X), "float", ((float)q.X).ToString());
                CharacterDetails.ClothFrontARight_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ClothFrontARight_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.ClothFrontARight_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ClothFrontARight_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.ClothFrontARight_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ClothFrontARight_W), "float", ((float)q.W).ToString());
                CharacterDetails.ClothFrontARight_Toggle = true;
            }
            if (CharacterDetails.ClothSideALeft_Rotate == true)
            {
                CharacterDetails.ClothSideALeft_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ClothSideALeft_X), "float", ((float)q.X).ToString());
                CharacterDetails.ClothSideALeft_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ClothSideALeft_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.ClothSideALeft_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ClothSideALeft_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.ClothSideALeft_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ClothSideALeft_W), "float", ((float)q.W).ToString());
                CharacterDetails.ClothSideALeft_Toggle = true;
            }
            if (CharacterDetails.ClothSideARight_Rotate == true)
            {
                CharacterDetails.ClothSideARight_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ClothSideARight_X), "float", ((float)q.X).ToString());
                CharacterDetails.ClothSideARight_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ClothSideARight_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.ClothSideARight_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ClothSideARight_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.ClothSideARight_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ClothSideARight_W), "float", ((float)q.W).ToString());
                CharacterDetails.ClothSideARight_Toggle = true;
            }
            if (CharacterDetails.KneeLeft_Rotate == true)
            {
                CharacterDetails.KneeLeft_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.KneeLeft_X), "float", ((float)q.X).ToString());
                CharacterDetails.KneeLeft_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.KneeLeft_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.KneeLeft_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.KneeLeft_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.KneeLeft_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.KneeLeft_W), "float", ((float)q.W).ToString());
                CharacterDetails.KneeLeft_Toggle = true;
            }
            if (CharacterDetails.KneeRight_Rotate == true)
            {
                CharacterDetails.KneeRight_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.KneeRight_X), "float", ((float)q.X).ToString());
                CharacterDetails.KneeRight_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.KneeRight_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.KneeRight_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.KneeRight_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.KneeRight_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.KneeRight_W), "float", ((float)q.W).ToString());
                CharacterDetails.KneeRight_Toggle = true;
            }
            if (CharacterDetails.BreastLeft_Rotate == true)
            {
                CharacterDetails.BreastLeft_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.BreastLeft_X), "float", ((float)q.X).ToString());
                CharacterDetails.BreastLeft_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.BreastLeft_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.BreastLeft_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.BreastLeft_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.BreastLeft_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.BreastLeft_W), "float", ((float)q.W).ToString());
                CharacterDetails.BreastLeft_Toggle = true;
            }
            if (CharacterDetails.BreastRight_Rotate == true)
            {
                CharacterDetails.BreastRight_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.BreastRight_X), "float", ((float)q.X).ToString());
                CharacterDetails.BreastRight_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.BreastRight_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.BreastRight_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.BreastRight_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.BreastRight_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.BreastRight_W), "float", ((float)q.W).ToString());
                CharacterDetails.BreastRight_Toggle = true;
            }
            if (CharacterDetails.SpineC_Rotate == true)
            {
                CharacterDetails.SpineC_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.SpineC_X), "float", ((float)q.X).ToString());
                CharacterDetails.SpineC_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.SpineC_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.SpineC_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.SpineC_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.SpineC_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.SpineC_W), "float", ((float)q.W).ToString());
                CharacterDetails.SpineC_Toggle = true;
            }
            if (CharacterDetails.ClothBackBLeft_Rotate == true)
            {
                CharacterDetails.ClothBackBLeft_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ClothBackBLeft_X), "float", ((float)q.X).ToString());
                CharacterDetails.ClothBackBLeft_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ClothBackBLeft_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.ClothBackBLeft_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ClothBackBLeft_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.ClothBackBLeft_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ClothBackBLeft_W), "float", ((float)q.W).ToString());
                CharacterDetails.ClothBackBLeft_Toggle = true;
            }
            if (CharacterDetails.ClothBackBRight_Rotate == true)
            {
                CharacterDetails.ClothBackBRight_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ClothBackBRight_X), "float", ((float)q.X).ToString());
                CharacterDetails.ClothBackBRight_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ClothBackBRight_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.ClothBackBRight_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ClothBackBRight_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.ClothBackBRight_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ClothBackBRight_W), "float", ((float)q.W).ToString());
                CharacterDetails.ClothBackBRight_Toggle = true;
            }
            if (CharacterDetails.ClothFrontBLeft_Rotate == true)
            {
                CharacterDetails.ClothFrontBLeft_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ClothFrontBLeft_X), "float", ((float)q.X).ToString());
                CharacterDetails.ClothFrontBLeft_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ClothFrontBLeft_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.ClothFrontBLeft_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ClothFrontBLeft_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.ClothFrontBLeft_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ClothFrontBLeft_W), "float", ((float)q.W).ToString());
                CharacterDetails.ClothFrontBLeft_Toggle = true;
            }
            if (CharacterDetails.ClothFrontBRight_Rotate == true)
            {
                CharacterDetails.ClothFrontBRight_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ClothFrontBRight_X), "float", ((float)q.X).ToString());
                CharacterDetails.ClothFrontBRight_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ClothFrontBRight_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.ClothFrontBRight_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ClothFrontBRight_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.ClothFrontBRight_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ClothFrontBRight_W), "float", ((float)q.W).ToString());
                CharacterDetails.ClothFrontBRight_Toggle = true;
            }
            if (CharacterDetails.ClothSideBLeft_Rotate == true)
            {
                CharacterDetails.ClothSideBLeft_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ClothSideBLeft_X), "float", ((float)q.X).ToString());
                CharacterDetails.ClothSideBLeft_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ClothSideBLeft_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.ClothSideBLeft_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ClothSideBLeft_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.ClothSideBLeft_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ClothSideBLeft_W), "float", ((float)q.W).ToString());
                CharacterDetails.ClothSideBLeft_Toggle = true;
            }
            if (CharacterDetails.ClothSideBRight_Rotate == true)
            {
                CharacterDetails.ClothSideBRight_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ClothSideBRight_X), "float", ((float)q.X).ToString());
                CharacterDetails.ClothSideBRight_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ClothSideBRight_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.ClothSideBRight_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ClothSideBRight_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.ClothSideBRight_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ClothSideBRight_W), "float", ((float)q.W).ToString());
                CharacterDetails.ClothSideBRight_Toggle = true;
            }
            if (CharacterDetails.CalfLeft_Rotate == true)
            {
                CharacterDetails.CalfLeft_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.CalfLeft_X), "float", ((float)q.X).ToString());
                CharacterDetails.CalfLeft_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.CalfLeft_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.CalfLeft_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.CalfLeft_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.CalfLeft_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.CalfLeft_W), "float", ((float)q.W).ToString());
                CharacterDetails.CalfLeft_Toggle = true;
            }
            if (CharacterDetails.CalfRight_Rotate == true)
            {
                CharacterDetails.CalfRight_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.CalfRight_X), "float", ((float)q.X).ToString());
                CharacterDetails.CalfRight_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.CalfRight_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.CalfRight_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.CalfRight_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.CalfRight_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.CalfRight_W), "float", ((float)q.W).ToString());
                CharacterDetails.CalfRight_Toggle = true;
            }
            if (CharacterDetails.ScabbardLeft_Rotate == true)
            {
                CharacterDetails.ScabbardLeft_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ScabbardLeft_X), "float", ((float)q.X).ToString());
                CharacterDetails.ScabbardLeft_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ScabbardLeft_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.ScabbardLeft_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ScabbardLeft_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.ScabbardLeft_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ScabbardLeft_W), "float", ((float)q.W).ToString());
                CharacterDetails.ScabbardLeft_Toggle = true;
            }
            if (CharacterDetails.ScabbardRight_Rotate == true)
            {
                CharacterDetails.ScabbardRight_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ScabbardRight_X), "float", ((float)q.X).ToString());
                CharacterDetails.ScabbardRight_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ScabbardRight_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.ScabbardRight_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ScabbardRight_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.ScabbardRight_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ScabbardRight_W), "float", ((float)q.W).ToString());
                CharacterDetails.ScabbardRight_Toggle = true;
            }
            if (CharacterDetails.Neck_Rotate == true)
            {
                CharacterDetails.Neck_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.Neck_X), "float", ((float)q.X).ToString());
                CharacterDetails.Neck_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.Neck_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.Neck_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.Neck_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.Neck_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.Neck_W), "float", ((float)q.W).ToString());
                CharacterDetails.Neck_Toggle = true;
            }
            if (CharacterDetails.ClavicleLeft_Rotate == true)
            {
                CharacterDetails.ClavicleLeft_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ClavicleLeft_X), "float", ((float)q.X).ToString());
                CharacterDetails.ClavicleLeft_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ClavicleLeft_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.ClavicleLeft_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ClavicleLeft_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.ClavicleLeft_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ClavicleLeft_W), "float", ((float)q.W).ToString());
                CharacterDetails.ClavicleLeft_Toggle = true;
            }
            if (CharacterDetails.ClavicleRight_Rotate == true)
            {
                CharacterDetails.ClavicleRight_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ClavicleRight_X), "float", ((float)q.X).ToString());
                CharacterDetails.ClavicleRight_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ClavicleRight_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.ClavicleRight_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ClavicleRight_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.ClavicleRight_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ClavicleRight_W), "float", ((float)q.W).ToString());
                CharacterDetails.ClavicleRight_Toggle = true;
            }
            if (CharacterDetails.ClothBackCLeft_Rotate == true)
            {
                CharacterDetails.ClothBackCLeft_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ClothBackCLeft_X), "float", ((float)q.X).ToString());
                CharacterDetails.ClothBackCLeft_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ClothBackCLeft_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.ClothBackCLeft_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ClothBackCLeft_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.ClothBackCLeft_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ClothBackCLeft_W), "float", ((float)q.W).ToString());
                CharacterDetails.ClothBackCLeft_Toggle = true;
            }
            if (CharacterDetails.ClothBackCRight_Rotate == true)
            {
                CharacterDetails.ClothBackCRight_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ClothBackCRight_X), "float", ((float)q.X).ToString());
                CharacterDetails.ClothBackCRight_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ClothBackCRight_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.ClothBackCRight_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ClothBackCRight_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.ClothBackCRight_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ClothBackCRight_W), "float", ((float)q.W).ToString());
                CharacterDetails.ClothBackCRight_Toggle = true;
            }
            if (CharacterDetails.ClothFrontCLeft_Rotate == true)
            {
                CharacterDetails.ClothFrontCLeft_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ClothFrontCLeft_X), "float", ((float)q.X).ToString());
                CharacterDetails.ClothFrontCLeft_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ClothFrontCLeft_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.ClothFrontCLeft_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ClothFrontCLeft_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.ClothFrontCLeft_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ClothFrontCLeft_W), "float", ((float)q.W).ToString());
                CharacterDetails.ClothFrontCLeft_Toggle = true;
            }
            if (CharacterDetails.ClothFrontCRight_Rotate == true)
            {
                CharacterDetails.ClothFrontCRight_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ClothFrontCRight_X), "float", ((float)q.X).ToString());
                CharacterDetails.ClothFrontCRight_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ClothFrontCRight_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.ClothFrontCRight_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ClothFrontCRight_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.ClothFrontCRight_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ClothFrontCRight_W), "float", ((float)q.W).ToString());
                CharacterDetails.ClothFrontCRight_Toggle = true;
            }
            if (CharacterDetails.ClothSideCLeft_Rotate == true)
            {
                CharacterDetails.ClothSideCLeft_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ClothSideCLeft_X), "float", ((float)q.X).ToString());
                CharacterDetails.ClothSideCLeft_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ClothSideCLeft_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.ClothSideCLeft_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ClothSideCLeft_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.ClothSideCLeft_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ClothSideCLeft_W), "float", ((float)q.W).ToString());
                CharacterDetails.ClothSideCLeft_Toggle = true;
            }
            if (CharacterDetails.ClothSideCRight_Rotate == true)
            {
                CharacterDetails.ClothSideCRight_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ClothSideCRight_X), "float", ((float)q.X).ToString());
                CharacterDetails.ClothSideCRight_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ClothSideCRight_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.ClothSideCRight_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ClothSideCRight_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.ClothSideCRight_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ClothSideCRight_W), "float", ((float)q.W).ToString());
                CharacterDetails.ClothSideCRight_Toggle = true;
            }
            if (CharacterDetails.PoleynLeft_Rotate == true)
            {
                CharacterDetails.PoleynLeft_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.PoleynLeft_X), "float", ((float)q.X).ToString());
                CharacterDetails.PoleynLeft_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.PoleynLeft_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.PoleynLeft_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.PoleynLeft_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.PoleynLeft_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.PoleynLeft_W), "float", ((float)q.W).ToString());
                CharacterDetails.PoleynLeft_Toggle = true;
            }
            if (CharacterDetails.PoleynRight_Rotate == true)
            {
                CharacterDetails.PoleynRight_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.PoleynRight_X), "float", ((float)q.X).ToString());
                CharacterDetails.PoleynRight_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.PoleynRight_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.PoleynRight_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.PoleynRight_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.PoleynRight_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.PoleynRight_W), "float", ((float)q.W).ToString());
                CharacterDetails.PoleynRight_Toggle = true;
            }
            if (CharacterDetails.FootLeft_Rotate == true)
            {
                CharacterDetails.FootLeft_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.FootLeft_X), "float", ((float)q.X).ToString());
                CharacterDetails.FootLeft_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.FootLeft_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.FootLeft_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.FootLeft_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.FootLeft_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.FootLeft_W), "float", ((float)q.W).ToString());
                CharacterDetails.FootLeft_Toggle = true;
            }
            if (CharacterDetails.FootRight_Rotate == true)
            {
                CharacterDetails.FootRight_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.FootRight_X), "float", ((float)q.X).ToString());
                CharacterDetails.FootRight_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.FootRight_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.FootRight_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.FootRight_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.FootRight_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.FootRight_W), "float", ((float)q.W).ToString());
                CharacterDetails.FootRight_Toggle = true;
            }
            if (CharacterDetails.Head_Rotate == true)
            {
                CharacterDetails.Head_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.Head_X), "float", ((float)q.X).ToString());
                CharacterDetails.Head_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.Head_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.Head_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.Head_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.Head_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.Head_W), "float", ((float)q.W).ToString());
                CharacterDetails.Head_Toggle = true;
            }
            if (CharacterDetails.ArmLeft_Rotate == true)
            {
                CharacterDetails.ArmLeft_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ArmLeft_X), "float", ((float)q.X).ToString());
                CharacterDetails.ArmLeft_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ArmLeft_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.ArmLeft_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ArmLeft_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.ArmLeft_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ArmLeft_W), "float", ((float)q.W).ToString());
                CharacterDetails.ArmLeft_Toggle = true;
            }
            if (CharacterDetails.ArmRight_Rotate == true)
            {
                CharacterDetails.ArmRight_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ArmRight_X), "float", ((float)q.X).ToString());
                CharacterDetails.ArmRight_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ArmRight_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.ArmRight_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ArmRight_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.ArmRight_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ArmRight_W), "float", ((float)q.W).ToString());
                CharacterDetails.ArmRight_Toggle = true;
            }
            if (CharacterDetails.PauldronLeft_Rotate == true)
            {
                CharacterDetails.PauldronLeft_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.PauldronLeft_X), "float", ((float)q.X).ToString());
                CharacterDetails.PauldronLeft_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.PauldronLeft_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.PauldronLeft_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.PauldronLeft_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.PauldronLeft_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.PauldronLeft_W), "float", ((float)q.W).ToString());
                CharacterDetails.PauldronLeft_Toggle = true;
            }
            if (CharacterDetails.PauldronRight_Rotate == true)
            {
                CharacterDetails.PauldronRight_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.PauldronRight_X), "float", ((float)q.X).ToString());
                CharacterDetails.PauldronRight_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.PauldronRight_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.PauldronRight_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.PauldronRight_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.PauldronRight_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.PauldronRight_W), "float", ((float)q.W).ToString());
                CharacterDetails.PauldronRight_Toggle = true;
            }
            if (CharacterDetails.Unknown00_Rotate == true)
            {
                CharacterDetails.Unknown00_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.Unknown00_X), "float", ((float)q.X).ToString());
                CharacterDetails.Unknown00_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.Unknown00_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.Unknown00_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.Unknown00_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.Unknown00_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.Unknown00_W), "float", ((float)q.W).ToString());
                CharacterDetails.Unknown00_Toggle = true;
            }
            if (CharacterDetails.ToesLeft_Rotate == true)
            {
                CharacterDetails.ToesLeft_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ToesLeft_X), "float", ((float)q.X).ToString());
                CharacterDetails.ToesLeft_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ToesLeft_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.ToesLeft_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ToesLeft_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.ToesLeft_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ToesLeft_W), "float", ((float)q.W).ToString());
                CharacterDetails.ToesLeft_Toggle = true;
            }
            if (CharacterDetails.ToesRight_Rotate == true)
            {
                CharacterDetails.ToesRight_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ToesRight_X), "float", ((float)q.X).ToString());
                CharacterDetails.ToesRight_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ToesRight_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.ToesRight_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ToesRight_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.ToesRight_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ToesRight_W), "float", ((float)q.W).ToString());
                CharacterDetails.ToesRight_Toggle = true;
            }
            if (CharacterDetails.HairA_Rotate == true)
            {
                CharacterDetails.HairA_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.HairA_X), "float", ((float)q.X).ToString());
                CharacterDetails.HairA_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.HairA_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.HairA_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.HairA_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.HairA_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.HairA_W), "float", ((float)q.W).ToString());
                CharacterDetails.HairA_Toggle = true;
            }
            if (CharacterDetails.HairFrontLeft_Rotate == true)
            {
                CharacterDetails.HairFrontLeft_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.HairFrontLeft_X), "float", ((float)q.X).ToString());
                CharacterDetails.HairFrontLeft_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.HairFrontLeft_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.HairFrontLeft_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.HairFrontLeft_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.HairFrontLeft_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.HairFrontLeft_W), "float", ((float)q.W).ToString());
                CharacterDetails.HairFrontLeft_Toggle = true;
            }
            if (CharacterDetails.HairFrontRight_Rotate == true)
            {
                CharacterDetails.HairFrontRight_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.HairFrontRight_X), "float", ((float)q.X).ToString());
                CharacterDetails.HairFrontRight_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.HairFrontRight_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.HairFrontRight_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.HairFrontRight_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.HairFrontRight_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.HairFrontRight_W), "float", ((float)q.W).ToString());
                CharacterDetails.HairFrontRight_Toggle = true;
            }
            if (CharacterDetails.EarLeft_Rotate == true)
            {
                CharacterDetails.EarLeft_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.EarLeft_X), "float", ((float)q.X).ToString());
                CharacterDetails.EarLeft_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.EarLeft_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.EarLeft_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.EarLeft_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.EarLeft_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.EarLeft_W), "float", ((float)q.W).ToString());
                CharacterDetails.EarLeft_Toggle = true;
            }
            if (CharacterDetails.EarRight_Rotate == true)
            {
                CharacterDetails.EarRight_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.EarRight_X), "float", ((float)q.X).ToString());
                CharacterDetails.EarRight_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.EarRight_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.EarRight_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.EarRight_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.EarRight_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.EarRight_W), "float", ((float)q.W).ToString());
                CharacterDetails.EarRight_Toggle = true;
            }
            if (CharacterDetails.ForearmLeft_Rotate == true)
            {
                CharacterDetails.ForearmLeft_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ForearmLeft_X), "float", ((float)q.X).ToString());
                CharacterDetails.ForearmLeft_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ForearmLeft_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.ForearmLeft_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ForearmLeft_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.ForearmLeft_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ForearmLeft_W), "float", ((float)q.W).ToString());
                CharacterDetails.ForearmLeft_Toggle = true;
            }
            if (CharacterDetails.ForearmRight_Rotate == true)
            {
                CharacterDetails.ForearmRight_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ForearmRight_X), "float", ((float)q.X).ToString());
                CharacterDetails.ForearmRight_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ForearmRight_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.ForearmRight_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ForearmRight_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.ForearmRight_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ForearmRight_W), "float", ((float)q.W).ToString());
                CharacterDetails.ForearmRight_Toggle = true;
            }
            if (CharacterDetails.ShoulderLeft_Rotate == true)
            {
                CharacterDetails.ShoulderLeft_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ShoulderLeft_X), "float", ((float)q.X).ToString());
                CharacterDetails.ShoulderLeft_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ShoulderLeft_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.ShoulderLeft_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ShoulderLeft_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.ShoulderLeft_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ShoulderLeft_W), "float", ((float)q.W).ToString());
                CharacterDetails.ShoulderLeft_Toggle = true;
            }
            if (CharacterDetails.ShoulderRight_Rotate == true)
            {
                CharacterDetails.ShoulderRight_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ShoulderRight_X), "float", ((float)q.X).ToString());
                CharacterDetails.ShoulderRight_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ShoulderRight_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.ShoulderRight_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ShoulderRight_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.ShoulderRight_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ShoulderRight_W), "float", ((float)q.W).ToString());
                CharacterDetails.ShoulderRight_Toggle = true;
            }
            if (CharacterDetails.HairB_Rotate == true)
            {
                CharacterDetails.HairB_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.HairB_X), "float", ((float)q.X).ToString());
                CharacterDetails.HairB_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.HairB_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.HairB_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.HairB_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.HairB_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.HairB_W), "float", ((float)q.W).ToString());
                CharacterDetails.HairB_Toggle = true;
            }
            if (CharacterDetails.HandLeft_Rotate == true)
            {
                CharacterDetails.HandLeft_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.HandLeft_X), "float", ((float)q.X).ToString());
                CharacterDetails.HandLeft_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.HandLeft_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.HandLeft_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.HandLeft_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.HandLeft_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.HandLeft_W), "float", ((float)q.W).ToString());
                CharacterDetails.HandLeft_Toggle = true;
            }
            if (CharacterDetails.HandRight_Rotate == true)
            {
                CharacterDetails.HandRight_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.HandRight_X), "float", ((float)q.X).ToString());
                CharacterDetails.HandRight_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.HandRight_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.HandRight_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.HandRight_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.HandRight_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.HandRight_W), "float", ((float)q.W).ToString());
                CharacterDetails.HandRight_Toggle = true;
            }
            if (CharacterDetails.ShieldLeft_Rotate == true)
            {
                CharacterDetails.ShieldLeft_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ShieldLeft_X), "float", ((float)q.X).ToString());
                CharacterDetails.ShieldLeft_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ShieldLeft_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.ShieldLeft_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ShieldLeft_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.ShieldLeft_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ShieldLeft_W), "float", ((float)q.W).ToString());
                CharacterDetails.ShieldLeft_Toggle = true;
            }
            if (CharacterDetails.ShieldRight_Rotate == true)
            {
                CharacterDetails.ShieldRight_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ShieldRight_X), "float", ((float)q.X).ToString());
                CharacterDetails.ShieldRight_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ShieldRight_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.ShieldRight_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ShieldRight_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.ShieldRight_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ShieldRight_W), "float", ((float)q.W).ToString());
                CharacterDetails.ShieldRight_Toggle = true;
            }
            if (CharacterDetails.EarringALeft_Rotate == true)
            {
                CharacterDetails.EarringALeft_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.EarringALeft_X), "float", ((float)q.X).ToString());
                CharacterDetails.EarringALeft_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.EarringALeft_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.EarringALeft_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.EarringALeft_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.EarringALeft_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.EarringALeft_W), "float", ((float)q.W).ToString());
                CharacterDetails.EarringALeft_Toggle = true;
            }
            if (CharacterDetails.EarringARight_Rotate == true)
            {
                CharacterDetails.EarringARight_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.EarringARight_X), "float", ((float)q.X).ToString());
                CharacterDetails.EarringARight_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.EarringARight_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.EarringARight_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.EarringARight_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.EarringARight_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.EarringARight_W), "float", ((float)q.W).ToString());
                CharacterDetails.EarringARight_Toggle = true;
            }
            if (CharacterDetails.ElbowLeft_Rotate == true)
            {
                CharacterDetails.ElbowLeft_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ElbowLeft_X), "float", ((float)q.X).ToString());
                CharacterDetails.ElbowLeft_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ElbowLeft_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.ElbowLeft_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ElbowLeft_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.ElbowLeft_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ElbowLeft_W), "float", ((float)q.W).ToString());
                CharacterDetails.ElbowLeft_Toggle = true;
            }
            if (CharacterDetails.ElbowRight_Rotate == true)
            {
                CharacterDetails.ElbowRight_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ElbowRight_X), "float", ((float)q.X).ToString());
                CharacterDetails.ElbowRight_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ElbowRight_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.ElbowRight_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ElbowRight_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.ElbowRight_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ElbowRight_W), "float", ((float)q.W).ToString());
                CharacterDetails.ElbowRight_Toggle = true;
            }
            if (CharacterDetails.CouterLeft_Rotate == true)
            {
                CharacterDetails.CouterLeft_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.CouterLeft_X), "float", ((float)q.X).ToString());
                CharacterDetails.CouterLeft_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.CouterLeft_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.CouterLeft_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.CouterLeft_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.CouterLeft_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.CouterLeft_W), "float", ((float)q.W).ToString());
                CharacterDetails.CouterLeft_Toggle = true;
            }
            if (CharacterDetails.CouterRight_Rotate == true)
            {
                CharacterDetails.CouterRight_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.CouterRight_X), "float", ((float)q.X).ToString());
                CharacterDetails.CouterRight_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.CouterRight_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.CouterRight_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.CouterRight_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.CouterRight_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.CouterRight_W), "float", ((float)q.W).ToString());
                CharacterDetails.CouterRight_Toggle = true;
            }
            if (CharacterDetails.WristLeft_Rotate == true)
            {
                CharacterDetails.WristLeft_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.WristLeft_X), "float", ((float)q.X).ToString());
                CharacterDetails.WristLeft_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.WristLeft_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.WristLeft_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.WristLeft_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.WristLeft_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.WristLeft_W), "float", ((float)q.W).ToString());
                CharacterDetails.WristLeft_Toggle = true;
            }
            if (CharacterDetails.WristRight_Rotate == true)
            {
                CharacterDetails.WristRight_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.WristRight_X), "float", ((float)q.X).ToString());
                CharacterDetails.WristRight_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.WristRight_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.WristRight_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.WristRight_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.WristRight_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.WristRight_W), "float", ((float)q.W).ToString());
                CharacterDetails.WristRight_Toggle = true;
            }
            if (CharacterDetails.IndexALeft_Rotate == true)
            {
                CharacterDetails.IndexALeft_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.IndexALeft_X), "float", ((float)q.X).ToString());
                CharacterDetails.IndexALeft_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.IndexALeft_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.IndexALeft_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.IndexALeft_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.IndexALeft_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.IndexALeft_W), "float", ((float)q.W).ToString());
                CharacterDetails.IndexALeft_Toggle = true;
            }
            if (CharacterDetails.IndexARight_Rotate == true)
            {
                CharacterDetails.IndexARight_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.IndexARight_X), "float", ((float)q.X).ToString());
                CharacterDetails.IndexARight_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.IndexARight_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.IndexARight_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.IndexARight_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.IndexARight_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.IndexARight_W), "float", ((float)q.W).ToString());
                CharacterDetails.IndexARight_Toggle = true;
            }
            if (CharacterDetails.PinkyALeft_Rotate == true)
            {
                CharacterDetails.PinkyALeft_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.PinkyALeft_X), "float", ((float)q.X).ToString());
                CharacterDetails.PinkyALeft_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.PinkyALeft_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.PinkyALeft_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.PinkyALeft_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.PinkyALeft_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.PinkyALeft_W), "float", ((float)q.W).ToString());
                CharacterDetails.PinkyALeft_Toggle = true;
            }
            if (CharacterDetails.PinkyARight_Rotate == true)
            {
                CharacterDetails.PinkyARight_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.PinkyARight_X), "float", ((float)q.X).ToString());
                CharacterDetails.PinkyARight_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.PinkyARight_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.PinkyARight_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.PinkyARight_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.PinkyARight_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.PinkyARight_W), "float", ((float)q.W).ToString());
                CharacterDetails.PinkyARight_Toggle = true;
            }
            if (CharacterDetails.RingALeft_Rotate == true)
            {
                CharacterDetails.RingALeft_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.RingALeft_X), "float", ((float)q.X).ToString());
                CharacterDetails.RingALeft_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.RingALeft_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.RingALeft_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.RingALeft_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.RingALeft_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.RingALeft_W), "float", ((float)q.W).ToString());
                CharacterDetails.RingALeft_Toggle = true;
            }
            if (CharacterDetails.RingARight_Rotate == true)
            {
                CharacterDetails.RingARight_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.RingARight_X), "float", ((float)q.X).ToString());
                CharacterDetails.RingARight_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.RingARight_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.RingARight_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.RingARight_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.RingARight_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.RingARight_W), "float", ((float)q.W).ToString());
                CharacterDetails.RingARight_Toggle = true;
            }
            if (CharacterDetails.MiddleALeft_Rotate == true)
            {
                CharacterDetails.MiddleALeft_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.MiddleALeft_X), "float", ((float)q.X).ToString());
                CharacterDetails.MiddleALeft_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.MiddleALeft_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.MiddleALeft_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.MiddleALeft_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.MiddleALeft_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.MiddleALeft_W), "float", ((float)q.W).ToString());
                CharacterDetails.MiddleALeft_Toggle = true;
            }
            if (CharacterDetails.MiddleARight_Rotate == true)
            {
                CharacterDetails.MiddleARight_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.MiddleARight_X), "float", ((float)q.X).ToString());
                CharacterDetails.MiddleARight_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.MiddleARight_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.MiddleARight_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.MiddleARight_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.MiddleARight_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.MiddleARight_W), "float", ((float)q.W).ToString());
                CharacterDetails.MiddleARight_Toggle = true;
            }
            if (CharacterDetails.ThumbALeft_Rotate == true)
            {
                CharacterDetails.ThumbALeft_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ThumbALeft_X), "float", ((float)q.X).ToString());
                CharacterDetails.ThumbALeft_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ThumbALeft_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.ThumbALeft_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ThumbALeft_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.ThumbALeft_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ThumbALeft_W), "float", ((float)q.W).ToString());
                CharacterDetails.ThumbALeft_Toggle = true;
            }
            if (CharacterDetails.ThumbARight_Rotate == true)
            {
                CharacterDetails.ThumbARight_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ThumbARight_X), "float", ((float)q.X).ToString());
                CharacterDetails.ThumbARight_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ThumbARight_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.ThumbARight_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ThumbARight_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.ThumbARight_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ThumbARight_W), "float", ((float)q.W).ToString());
                CharacterDetails.ThumbARight_Toggle = true;
            }
            if (CharacterDetails.WeaponLeft_Rotate == true)
            {
                CharacterDetails.WeaponLeft_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.WeaponLeft_X), "float", ((float)q.X).ToString());
                CharacterDetails.WeaponLeft_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.WeaponLeft_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.WeaponLeft_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.WeaponLeft_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.WeaponLeft_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.WeaponLeft_W), "float", ((float)q.W).ToString());
                CharacterDetails.WeaponLeft_Toggle = true;
            }
            if (CharacterDetails.WeaponRight_Rotate == true)
            {
                CharacterDetails.WeaponRight_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.WeaponRight_X), "float", ((float)q.X).ToString());
                CharacterDetails.WeaponRight_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.WeaponRight_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.WeaponRight_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.WeaponRight_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.WeaponRight_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.WeaponRight_W), "float", ((float)q.W).ToString());
                CharacterDetails.WeaponRight_Toggle = true;
            }
            if (CharacterDetails.EarringBLeft_Rotate == true)
            {
                CharacterDetails.EarringBLeft_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.EarringBLeft_X), "float", ((float)q.X).ToString());
                CharacterDetails.EarringBLeft_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.EarringBLeft_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.EarringBLeft_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.EarringBLeft_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.EarringBLeft_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.EarringBLeft_W), "float", ((float)q.W).ToString());
                CharacterDetails.EarringBLeft_Toggle = true;
            }
            if (CharacterDetails.EarringBRight_Rotate == true)
            {
                CharacterDetails.EarringBRight_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.EarringBRight_X), "float", ((float)q.X).ToString());
                CharacterDetails.EarringBRight_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.EarringBRight_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.EarringBRight_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.EarringBRight_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.EarringBRight_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.EarringBRight_W), "float", ((float)q.W).ToString());
                CharacterDetails.EarringBRight_Toggle = true;
            }
            if (CharacterDetails.IndexBLeft_Rotate == true)
            {
                CharacterDetails.IndexBLeft_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.IndexBLeft_X), "float", ((float)q.X).ToString());
                CharacterDetails.IndexBLeft_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.IndexBLeft_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.IndexBLeft_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.IndexBLeft_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.IndexBLeft_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.IndexBLeft_W), "float", ((float)q.W).ToString());
                CharacterDetails.IndexBLeft_Toggle = true;
            }
            if (CharacterDetails.IndexBRight_Rotate == true)
            {
                CharacterDetails.IndexBRight_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.IndexBRight_X), "float", ((float)q.X).ToString());
                CharacterDetails.IndexBRight_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.IndexBRight_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.IndexBRight_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.IndexBRight_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.IndexBRight_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.IndexBRight_W), "float", ((float)q.W).ToString());
                CharacterDetails.IndexBRight_Toggle = true;
            }
            if (CharacterDetails.PinkyBLeft_Rotate == true)
            {
                CharacterDetails.PinkyBLeft_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.PinkyBLeft_X), "float", ((float)q.X).ToString());
                CharacterDetails.PinkyBLeft_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.PinkyBLeft_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.PinkyBLeft_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.PinkyBLeft_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.PinkyBLeft_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.PinkyBLeft_W), "float", ((float)q.W).ToString());
                CharacterDetails.PinkyBLeft_Toggle = true;
            }
            if (CharacterDetails.PinkyBRight_Rotate == true)
            {
                CharacterDetails.PinkyBRight_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.PinkyBRight_X), "float", ((float)q.X).ToString());
                CharacterDetails.PinkyBRight_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.PinkyBRight_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.PinkyBRight_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.PinkyBRight_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.PinkyBRight_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.PinkyBRight_W), "float", ((float)q.W).ToString());
                CharacterDetails.PinkyBRight_Toggle = true;
            }
            if (CharacterDetails.RingBLeft_Rotate == true)
            {
                CharacterDetails.RingBLeft_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.RingBLeft_X), "float", ((float)q.X).ToString());
                CharacterDetails.RingBLeft_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.RingBLeft_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.RingBLeft_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.RingBLeft_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.RingBLeft_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.RingBLeft_W), "float", ((float)q.W).ToString());
                CharacterDetails.RingBLeft_Toggle = true;
            }
            if (CharacterDetails.RingBRight_Rotate == true)
            {
                CharacterDetails.RingBRight_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.RingBRight_X), "float", ((float)q.X).ToString());
                CharacterDetails.RingBRight_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.RingBRight_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.RingBRight_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.RingBRight_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.RingBRight_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.RingBRight_W), "float", ((float)q.W).ToString());
                CharacterDetails.RingBRight_Toggle = true;
            }
            if (CharacterDetails.MiddleBLeft_Rotate == true)
            {
                CharacterDetails.MiddleBLeft_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.MiddleBLeft_X), "float", ((float)q.X).ToString());
                CharacterDetails.MiddleBLeft_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.MiddleBLeft_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.MiddleBLeft_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.MiddleBLeft_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.MiddleBLeft_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.MiddleBLeft_W), "float", ((float)q.W).ToString());
                CharacterDetails.MiddleBLeft_Toggle = true;
            }
            if (CharacterDetails.MiddleBRight_Rotate == true)
            {
                CharacterDetails.MiddleBRight_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.MiddleBRight_X), "float", ((float)q.X).ToString());
                CharacterDetails.MiddleBRight_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.MiddleBRight_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.MiddleBRight_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.MiddleBRight_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.MiddleBRight_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.MiddleBRight_W), "float", ((float)q.W).ToString());
                CharacterDetails.MiddleBRight_Toggle = true;
            }
            if (CharacterDetails.ThumbBLeft_Rotate == true)
            {
                CharacterDetails.ThumbBLeft_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ThumbBLeft_X), "float", ((float)q.X).ToString());
                CharacterDetails.ThumbBLeft_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ThumbBLeft_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.ThumbBLeft_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ThumbBLeft_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.ThumbBLeft_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ThumbBLeft_W), "float", ((float)q.W).ToString());
                CharacterDetails.ThumbBLeft_Toggle = true;
            }
            if (CharacterDetails.ThumbBRight_Rotate == true)
            {
                CharacterDetails.ThumbBRight_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ThumbBRight_X), "float", ((float)q.X).ToString());
                CharacterDetails.ThumbBRight_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ThumbBRight_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.ThumbBRight_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ThumbBRight_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.ThumbBRight_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ThumbBRight_W), "float", ((float)q.W).ToString());
                CharacterDetails.ThumbBRight_Toggle = true;
            }
            if (CharacterDetails.TailA_Rotate == true)
            {
                CharacterDetails.TailA_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.TailA_X), "float", ((float)q.X).ToString());
                CharacterDetails.TailA_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.TailA_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.TailA_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.TailA_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.TailA_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.TailA_W), "float", ((float)q.W).ToString());
                CharacterDetails.TailA_Toggle = true;
            }
            if (CharacterDetails.TailB_Rotate == true)
            {
                CharacterDetails.TailB_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.TailB_X), "float", ((float)q.X).ToString());
                CharacterDetails.TailB_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.TailB_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.TailB_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.TailB_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.TailB_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.TailB_W), "float", ((float)q.W).ToString());
                CharacterDetails.TailB_Toggle = true;
            }
            if (CharacterDetails.TailC_Rotate == true)
            {
                CharacterDetails.TailC_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.TailC_X), "float", ((float)q.X).ToString());
                CharacterDetails.TailC_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.TailC_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.TailC_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.TailC_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.TailC_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.TailC_W), "float", ((float)q.W).ToString());
                CharacterDetails.TailC_Toggle = true;
            }
            if (CharacterDetails.TailD_Rotate == true)
            {
                CharacterDetails.TailD_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.TailD_X), "float", ((float)q.X).ToString());
                CharacterDetails.TailD_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.TailD_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.TailD_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.TailD_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.TailD_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.TailD_W), "float", ((float)q.W).ToString());
                CharacterDetails.TailD_Toggle = true;
            }
            if (CharacterDetails.TailE_Rotate == true)
            {
                CharacterDetails.TailE_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.TailE_X), "float", ((float)q.X).ToString());
                CharacterDetails.TailE_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.TailE_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.TailE_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.TailE_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.TailE_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.TailE_W), "float", ((float)q.W).ToString());
                CharacterDetails.TailE_Toggle = true;
            }
            if (CharacterDetails.RootHead_Rotate == true)
            {
                CharacterDetails.RootHead_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.RootHead_X), "float", ((float)q.X).ToString());
                CharacterDetails.RootHead_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.RootHead_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.RootHead_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.RootHead_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.RootHead_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.RootHead_W), "float", ((float)q.W).ToString());
                CharacterDetails.RootHead_Toggle = true;
            }
            if (CharacterDetails.Jaw_Rotate == true)
            {
                CharacterDetails.Jaw_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.Jaw_X), "float", ((float)q.X).ToString());
                CharacterDetails.Jaw_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.Jaw_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.Jaw_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.Jaw_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.Jaw_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.Jaw_W), "float", ((float)q.W).ToString());
                CharacterDetails.Jaw_Toggle = true;
            }
            if (CharacterDetails.EyelidLowerLeft_Rotate == true)
            {
                CharacterDetails.EyelidLowerLeft_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.EyelidLowerLeft_X), "float", ((float)q.X).ToString());
                CharacterDetails.EyelidLowerLeft_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.EyelidLowerLeft_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.EyelidLowerLeft_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.EyelidLowerLeft_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.EyelidLowerLeft_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.EyelidLowerLeft_W), "float", ((float)q.W).ToString());
                CharacterDetails.EyelidLowerLeft_Toggle = true;
            }
            if (CharacterDetails.EyelidLowerRight_Rotate == true)
            {
                CharacterDetails.EyelidLowerRight_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.EyelidLowerRight_X), "float", ((float)q.X).ToString());
                CharacterDetails.EyelidLowerRight_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.EyelidLowerRight_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.EyelidLowerRight_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.EyelidLowerRight_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.EyelidLowerRight_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.EyelidLowerRight_W), "float", ((float)q.W).ToString());
                CharacterDetails.EyelidLowerRight_Toggle = true;
            }
            if (CharacterDetails.EyeLeft_Rotate == true)
            {
                CharacterDetails.EyeLeft_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.EyeLeft_X), "float", ((float)q.X).ToString());
                CharacterDetails.EyeLeft_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.EyeLeft_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.EyeLeft_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.EyeLeft_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.EyeLeft_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.EyeLeft_W), "float", ((float)q.W).ToString());
                CharacterDetails.EyeLeft_Toggle = true;
            }
            if (CharacterDetails.EyeRight_Rotate == true)
            {
                CharacterDetails.EyeRight_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.EyeRight_X), "float", ((float)q.X).ToString());
                CharacterDetails.EyeRight_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.EyeRight_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.EyeRight_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.EyeRight_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.EyeRight_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.EyeRight_W), "float", ((float)q.W).ToString());
                CharacterDetails.EyeRight_Toggle = true;
            }
            if (CharacterDetails.Nose_Rotate == true)
            {
                CharacterDetails.Nose_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.Nose_X), "float", ((float)q.X).ToString());
                CharacterDetails.Nose_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.Nose_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.Nose_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.Nose_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.Nose_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.Nose_W), "float", ((float)q.W).ToString());
                CharacterDetails.Nose_Toggle = true;
            }
            if (CharacterDetails.CheekLeft_Rotate == true)
            {
                CharacterDetails.CheekLeft_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.CheekLeft_X), "float", ((float)q.X).ToString());
                CharacterDetails.CheekLeft_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.CheekLeft_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.CheekLeft_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.CheekLeft_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.CheekLeft_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.CheekLeft_W), "float", ((float)q.W).ToString());
                CharacterDetails.CheekLeft_Toggle = true;
            }
            if (CharacterDetails.HrothWhiskersLeft_Rotate == true)
            {
                CharacterDetails.HrothWhiskersLeft_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.HrothWhiskersLeft_X), "float", ((float)q.X).ToString());
                CharacterDetails.HrothWhiskersLeft_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.HrothWhiskersLeft_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.HrothWhiskersLeft_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.HrothWhiskersLeft_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.HrothWhiskersLeft_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.HrothWhiskersLeft_W), "float", ((float)q.W).ToString());
                CharacterDetails.HrothWhiskersLeft_Toggle = true;
            }
            if (CharacterDetails.CheekRight_Rotate == true)
            {
                CharacterDetails.CheekRight_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.CheekRight_X), "float", ((float)q.X).ToString());
                CharacterDetails.CheekRight_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.CheekRight_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.CheekRight_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.CheekRight_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.CheekRight_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.CheekRight_W), "float", ((float)q.W).ToString());
                CharacterDetails.CheekRight_Toggle = true;
            }
            if (CharacterDetails.HrothWhiskersRight_Rotate == true)
            {
                CharacterDetails.HrothWhiskersRight_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.HrothWhiskersRight_X), "float", ((float)q.X).ToString());
                CharacterDetails.HrothWhiskersRight_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.HrothWhiskersRight_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.HrothWhiskersRight_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.HrothWhiskersRight_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.HrothWhiskersRight_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.HrothWhiskersRight_W), "float", ((float)q.W).ToString());
                CharacterDetails.HrothWhiskersRight_Toggle = true;
            }
            if (CharacterDetails.LipsLeft_Rotate == true)
            {
                CharacterDetails.LipsLeft_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.LipsLeft_X), "float", ((float)q.X).ToString());
                CharacterDetails.LipsLeft_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.LipsLeft_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.LipsLeft_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.LipsLeft_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.LipsLeft_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.LipsLeft_W), "float", ((float)q.W).ToString());
                CharacterDetails.LipsLeft_Toggle = true;
            }
            if (CharacterDetails.HrothEyebrowLeft_Rotate == true)
            {
                CharacterDetails.HrothEyebrowLeft_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.HrothEyebrowLeft_X), "float", ((float)q.X).ToString());
                CharacterDetails.HrothEyebrowLeft_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.HrothEyebrowLeft_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.HrothEyebrowLeft_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.HrothEyebrowLeft_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.HrothEyebrowLeft_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.HrothEyebrowLeft_W), "float", ((float)q.W).ToString());
                CharacterDetails.HrothEyebrowLeft_Toggle = true;
            }
            if (CharacterDetails.LipsRight_Rotate == true)
            {
                CharacterDetails.LipsRight_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.LipsRight_X), "float", ((float)q.X).ToString());
                CharacterDetails.LipsRight_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.LipsRight_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.LipsRight_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.LipsRight_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.LipsRight_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.LipsRight_W), "float", ((float)q.W).ToString());
                CharacterDetails.LipsRight_Toggle = true;
            }
            if (CharacterDetails.HrothEyebrowRight_Rotate == true)
            {
                CharacterDetails.HrothEyebrowRight_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.HrothEyebrowRight_X), "float", ((float)q.X).ToString());
                CharacterDetails.HrothEyebrowRight_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.HrothEyebrowRight_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.HrothEyebrowRight_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.HrothEyebrowRight_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.HrothEyebrowRight_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.HrothEyebrowRight_W), "float", ((float)q.W).ToString());
                CharacterDetails.HrothEyebrowRight_Toggle = true;
            }
            if (CharacterDetails.EyebrowLeft_Rotate == true)
            {
                CharacterDetails.EyebrowLeft_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.EyebrowLeft_X), "float", ((float)q.X).ToString());
                CharacterDetails.EyebrowLeft_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.EyebrowLeft_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.EyebrowLeft_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.EyebrowLeft_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.EyebrowLeft_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.EyebrowLeft_W), "float", ((float)q.W).ToString());
                CharacterDetails.EyebrowLeft_Toggle = true;
            }
            if (CharacterDetails.HrothBridge_Rotate == true)
            {
                CharacterDetails.HrothBridge_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.HrothBridge_X), "float", ((float)q.X).ToString());
                CharacterDetails.HrothBridge_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.HrothBridge_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.HrothBridge_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.HrothBridge_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.HrothBridge_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.HrothBridge_W), "float", ((float)q.W).ToString());
                CharacterDetails.HrothBridge_Toggle = true;
            }
            if (CharacterDetails.EyebrowRight_Rotate == true)
            {
                CharacterDetails.EyebrowRight_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.EyebrowRight_X), "float", ((float)q.X).ToString());
                CharacterDetails.EyebrowRight_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.EyebrowRight_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.EyebrowRight_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.EyebrowRight_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.EyebrowRight_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.EyebrowRight_W), "float", ((float)q.W).ToString());
                CharacterDetails.EyebrowRight_Toggle = true;
            }
            if (CharacterDetails.HrothBrowLeft_Rotate == true)
            {
                CharacterDetails.HrothBrowLeft_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.HrothBrowLeft_X), "float", ((float)q.X).ToString());
                CharacterDetails.HrothBrowLeft_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.HrothBrowLeft_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.HrothBrowLeft_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.HrothBrowLeft_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.HrothBrowLeft_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.HrothBrowLeft_W), "float", ((float)q.W).ToString());
                CharacterDetails.HrothBrowLeft_Toggle = true;
            }
            if (CharacterDetails.Bridge_Rotate == true)
            {
                CharacterDetails.Bridge_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.Bridge_X), "float", ((float)q.X).ToString());
                CharacterDetails.Bridge_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.Bridge_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.Bridge_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.Bridge_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.Bridge_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.Bridge_W), "float", ((float)q.W).ToString());
                CharacterDetails.Bridge_Toggle = true;
            }
            if (CharacterDetails.HrothBrowRight_Rotate == true)
            {
                CharacterDetails.HrothBrowRight_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.HrothBrowRight_X), "float", ((float)q.X).ToString());
                CharacterDetails.HrothBrowRight_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.HrothBrowRight_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.HrothBrowRight_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.HrothBrowRight_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.HrothBrowRight_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.HrothBrowRight_W), "float", ((float)q.W).ToString());
                CharacterDetails.HrothBrowRight_Toggle = true;
            }
            if (CharacterDetails.BrowLeft_Rotate == true)
            {
                CharacterDetails.BrowLeft_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.BrowLeft_X), "float", ((float)q.X).ToString());
                CharacterDetails.BrowLeft_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.BrowLeft_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.BrowLeft_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.BrowLeft_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.BrowLeft_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.BrowLeft_W), "float", ((float)q.W).ToString());
                CharacterDetails.BrowLeft_Toggle = true;
            }
            if (CharacterDetails.HrothJawUpper_Rotate == true)
            {
                CharacterDetails.HrothJawUpper_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.HrothJawUpper_X), "float", ((float)q.X).ToString());
                CharacterDetails.HrothJawUpper_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.HrothJawUpper_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.HrothJawUpper_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.HrothJawUpper_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.HrothJawUpper_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.HrothJawUpper_W), "float", ((float)q.W).ToString());
                CharacterDetails.HrothJawUpper_Toggle = true;
            }
            if (CharacterDetails.BrowRight_Rotate == true)
            {
                CharacterDetails.BrowRight_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.BrowRight_X), "float", ((float)q.X).ToString());
                CharacterDetails.BrowRight_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.BrowRight_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.BrowRight_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.BrowRight_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.BrowRight_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.BrowRight_W), "float", ((float)q.W).ToString());
                CharacterDetails.BrowRight_Toggle = true;
            }
            if (CharacterDetails.HrothLipUpper_Rotate == true)
            {
                CharacterDetails.HrothLipUpper_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.HrothLipUpper_X), "float", ((float)q.X).ToString());
                CharacterDetails.HrothLipUpper_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.HrothLipUpper_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.HrothLipUpper_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.HrothLipUpper_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.HrothLipUpper_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.HrothLipUpper_W), "float", ((float)q.W).ToString());
                CharacterDetails.HrothLipUpper_Toggle = true;
            }
            if (CharacterDetails.LipUpperA_Rotate == true)
            {
                CharacterDetails.LipUpperA_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.LipUpperA_X), "float", ((float)q.X).ToString());
                CharacterDetails.LipUpperA_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.LipUpperA_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.LipUpperA_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.LipUpperA_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.LipUpperA_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.LipUpperA_W), "float", ((float)q.W).ToString());
                CharacterDetails.LipUpperA_Toggle = true;
            }
            if (CharacterDetails.HrothEyelidUpperLeft_Rotate == true)
            {
                CharacterDetails.HrothEyelidUpperLeft_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.HrothEyelidUpperLeft_X), "float", ((float)q.X).ToString());
                CharacterDetails.HrothEyelidUpperLeft_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.HrothEyelidUpperLeft_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.HrothEyelidUpperLeft_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.HrothEyelidUpperLeft_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.HrothEyelidUpperLeft_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.HrothEyelidUpperLeft_W), "float", ((float)q.W).ToString());
                CharacterDetails.HrothEyelidUpperLeft_Toggle = true;
            }
            if (CharacterDetails.EyelidUpperLeft_Rotate == true)
            {
                CharacterDetails.EyelidUpperLeft_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.EyelidUpperLeft_X), "float", ((float)q.X).ToString());
                CharacterDetails.EyelidUpperLeft_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.EyelidUpperLeft_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.EyelidUpperLeft_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.EyelidUpperLeft_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.EyelidUpperLeft_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.EyelidUpperLeft_W), "float", ((float)q.W).ToString());
                CharacterDetails.EyelidUpperLeft_Toggle = true;
            }
            if (CharacterDetails.HrothEyelidUpperRight_Rotate == true)
            {
                CharacterDetails.HrothEyelidUpperRight_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.HrothEyelidUpperRight_X), "float", ((float)q.X).ToString());
                CharacterDetails.HrothEyelidUpperRight_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.HrothEyelidUpperRight_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.HrothEyelidUpperRight_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.HrothEyelidUpperRight_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.HrothEyelidUpperRight_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.HrothEyelidUpperRight_W), "float", ((float)q.W).ToString());
                CharacterDetails.HrothEyelidUpperRight_Toggle = true;
            }
            if (CharacterDetails.EyelidUpperRight_Rotate == true)
            {
                CharacterDetails.EyelidUpperRight_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.EyelidUpperRight_X), "float", ((float)q.X).ToString());
                CharacterDetails.EyelidUpperRight_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.EyelidUpperRight_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.EyelidUpperRight_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.EyelidUpperRight_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.EyelidUpperRight_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.EyelidUpperRight_W), "float", ((float)q.W).ToString());
                CharacterDetails.EyelidUpperRight_Toggle = true;
            }
            if (CharacterDetails.HrothLipsLeft_Rotate == true)
            {
                CharacterDetails.HrothLipsLeft_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.HrothLipsLeft_X), "float", ((float)q.X).ToString());
                CharacterDetails.HrothLipsLeft_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.HrothLipsLeft_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.HrothLipsLeft_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.HrothLipsLeft_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.HrothLipsLeft_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.HrothLipsLeft_W), "float", ((float)q.W).ToString());
                CharacterDetails.HrothLipsLeft_Toggle = true;
            }
            if (CharacterDetails.LipLowerA_Rotate == true)
            {
                CharacterDetails.LipLowerA_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.LipLowerA_X), "float", ((float)q.X).ToString());
                CharacterDetails.LipLowerA_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.LipLowerA_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.LipLowerA_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.LipLowerA_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.LipLowerA_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.LipLowerA_W), "float", ((float)q.W).ToString());
                CharacterDetails.LipLowerA_Toggle = true;
            }
            if (CharacterDetails.HrothLipsRight_Rotate == true)
            {
                CharacterDetails.HrothLipsRight_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.HrothLipsRight_X), "float", ((float)q.X).ToString());
                CharacterDetails.HrothLipsRight_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.HrothLipsRight_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.HrothLipsRight_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.HrothLipsRight_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.HrothLipsRight_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.HrothLipsRight_W), "float", ((float)q.W).ToString());
                CharacterDetails.HrothLipsRight_Toggle = true;
            }
            if (CharacterDetails.VieraEar01ALeft_Rotate == true)
            {
                CharacterDetails.VieraEar01ALeft_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.VieraEar01ALeft_X), "float", ((float)q.X).ToString());
                CharacterDetails.VieraEar01ALeft_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.VieraEar01ALeft_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.VieraEar01ALeft_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.VieraEar01ALeft_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.VieraEar01ALeft_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.VieraEar01ALeft_W), "float", ((float)q.W).ToString());
                CharacterDetails.VieraEar01ALeft_Toggle = true;
            }
            if (CharacterDetails.LipUpperB_Rotate == true)
            {
                CharacterDetails.LipUpperB_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.LipUpperB_X), "float", ((float)q.X).ToString());
                CharacterDetails.LipUpperB_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.LipUpperB_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.LipUpperB_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.LipUpperB_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.LipUpperB_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.LipUpperB_W), "float", ((float)q.W).ToString());
                CharacterDetails.LipUpperB_Toggle = true;
            }
            if (CharacterDetails.HrothLipUpperLeft_Rotate == true)
            {
                CharacterDetails.HrothLipUpperLeft_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.HrothLipUpperLeft_X), "float", ((float)q.X).ToString());
                CharacterDetails.HrothLipUpperLeft_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.HrothLipUpperLeft_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.HrothLipUpperLeft_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.HrothLipUpperLeft_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.HrothLipUpperLeft_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.HrothLipUpperLeft_W), "float", ((float)q.W).ToString());
                CharacterDetails.HrothLipUpperLeft_Toggle = true;
            }
            if (CharacterDetails.VieraEar01ARight_Rotate == true)
            {
                CharacterDetails.VieraEar01ARight_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.VieraEar01ARight_X), "float", ((float)q.X).ToString());
                CharacterDetails.VieraEar01ARight_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.VieraEar01ARight_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.VieraEar01ARight_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.VieraEar01ARight_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.VieraEar01ARight_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.VieraEar01ARight_W), "float", ((float)q.W).ToString());
                CharacterDetails.VieraEar01ARight_Toggle = true;
            }
            if (CharacterDetails.LipLowerB_Rotate == true)
            {
                CharacterDetails.LipLowerB_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.LipLowerB_X), "float", ((float)q.X).ToString());
                CharacterDetails.LipLowerB_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.LipLowerB_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.LipLowerB_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.LipLowerB_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.LipLowerB_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.LipLowerB_W), "float", ((float)q.W).ToString());
                CharacterDetails.LipLowerB_Toggle = true;
            }
            if (CharacterDetails.HrothLipUpperRight_Rotate == true)
            {
                CharacterDetails.HrothLipUpperRight_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.HrothLipUpperRight_X), "float", ((float)q.X).ToString());
                CharacterDetails.HrothLipUpperRight_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.HrothLipUpperRight_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.HrothLipUpperRight_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.HrothLipUpperRight_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.HrothLipUpperRight_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.HrothLipUpperRight_W), "float", ((float)q.W).ToString());
                CharacterDetails.HrothLipUpperRight_Toggle = true;
            }
            if (CharacterDetails.VieraEar02ALeft_Rotate == true)
            {
                CharacterDetails.VieraEar02ALeft_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.VieraEar02ALeft_X), "float", ((float)q.X).ToString());
                CharacterDetails.VieraEar02ALeft_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.VieraEar02ALeft_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.VieraEar02ALeft_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.VieraEar02ALeft_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.VieraEar02ALeft_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.VieraEar02ALeft_W), "float", ((float)q.W).ToString());
                CharacterDetails.VieraEar02ALeft_Toggle = true;
            }
            if (CharacterDetails.HrothLipLower_Rotate == true)
            {
                CharacterDetails.HrothLipLower_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.HrothLipLower_X), "float", ((float)q.X).ToString());
                CharacterDetails.HrothLipLower_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.HrothLipLower_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.HrothLipLower_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.HrothLipLower_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.HrothLipLower_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.HrothLipLower_W), "float", ((float)q.W).ToString());
                CharacterDetails.HrothLipLower_Toggle = true;
            }
            if (CharacterDetails.VieraEar02ARight_Rotate == true)
            {
                CharacterDetails.VieraEar02ARight_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.VieraEar02ARight_X), "float", ((float)q.X).ToString());
                CharacterDetails.VieraEar02ARight_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.VieraEar02ARight_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.VieraEar02ARight_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.VieraEar02ARight_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.VieraEar02ARight_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.VieraEar02ARight_W), "float", ((float)q.W).ToString());
                CharacterDetails.VieraEar02ARight_Toggle = true;
            }
            if (CharacterDetails.VieraEar03ALeft_Rotate == true)
            {
                CharacterDetails.VieraEar03ALeft_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.VieraEar03ALeft_X), "float", ((float)q.X).ToString());
                CharacterDetails.VieraEar03ALeft_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.VieraEar03ALeft_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.VieraEar03ALeft_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.VieraEar03ALeft_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.VieraEar03ALeft_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.VieraEar03ALeft_W), "float", ((float)q.W).ToString());
                CharacterDetails.VieraEar03ALeft_Toggle = true;
            }
            if (CharacterDetails.VieraEar03ARight_Rotate == true)
            {
                CharacterDetails.VieraEar03ARight_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.VieraEar03ARight_X), "float", ((float)q.X).ToString());
                CharacterDetails.VieraEar03ARight_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.VieraEar03ARight_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.VieraEar03ARight_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.VieraEar03ARight_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.VieraEar03ARight_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.VieraEar03ARight_W), "float", ((float)q.W).ToString());
                CharacterDetails.VieraEar03ARight_Toggle = true;
            }
            if (CharacterDetails.VieraEar04ALeft_Rotate == true)
            {
                CharacterDetails.VieraEar04ALeft_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.VieraEar04ALeft_X), "float", ((float)q.X).ToString());
                CharacterDetails.VieraEar04ALeft_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.VieraEar04ALeft_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.VieraEar04ALeft_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.VieraEar04ALeft_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.VieraEar04ALeft_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.VieraEar04ALeft_W), "float", ((float)q.W).ToString());
                CharacterDetails.VieraEar04ALeft_Toggle = true;
            }
            if (CharacterDetails.VieraEar04ARight_Rotate == true)
            {
                CharacterDetails.VieraEar04ARight_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.VieraEar04ARight_X), "float", ((float)q.X).ToString());
                CharacterDetails.VieraEar04ARight_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.VieraEar04ARight_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.VieraEar04ARight_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.VieraEar04ARight_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.VieraEar04ARight_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.VieraEar04ARight_W), "float", ((float)q.W).ToString());
                CharacterDetails.VieraEar04ARight_Toggle = true;
            }
            if (CharacterDetails.VieraLipLowerA_Rotate == true)
            {
                CharacterDetails.VieraLipLowerA_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.VieraLipLowerA_X), "float", ((float)q.X).ToString());
                CharacterDetails.VieraLipLowerA_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.VieraLipLowerA_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.VieraLipLowerA_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.VieraLipLowerA_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.VieraLipLowerA_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.VieraLipLowerA_W), "float", ((float)q.W).ToString());
                CharacterDetails.VieraLipLowerA_Toggle = true;
            }
            if (CharacterDetails.VieraLipUpperB_Rotate == true)
            {
                CharacterDetails.VieraLipUpperB_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.VieraLipUpperB_X), "float", ((float)q.X).ToString());
                CharacterDetails.VieraLipUpperB_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.VieraLipUpperB_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.VieraLipUpperB_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.VieraLipUpperB_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.VieraLipUpperB_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.VieraLipUpperB_W), "float", ((float)q.W).ToString());
                CharacterDetails.VieraLipUpperB_Toggle = true;
            }
            if (CharacterDetails.VieraEar01BLeft_Rotate == true)
            {
                CharacterDetails.VieraEar01BLeft_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.VieraEar01BLeft_X), "float", ((float)q.X).ToString());
                CharacterDetails.VieraEar01BLeft_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.VieraEar01BLeft_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.VieraEar01BLeft_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.VieraEar01BLeft_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.VieraEar01BLeft_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.VieraEar01BLeft_W), "float", ((float)q.W).ToString());
                CharacterDetails.VieraEar01BLeft_Toggle = true;
            }
            if (CharacterDetails.VieraEar01BRight_Rotate == true)
            {
                CharacterDetails.VieraEar01BRight_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.VieraEar01BRight_X), "float", ((float)q.X).ToString());
                CharacterDetails.VieraEar01BRight_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.VieraEar01BRight_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.VieraEar01BRight_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.VieraEar01BRight_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.VieraEar01BRight_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.VieraEar01BRight_W), "float", ((float)q.W).ToString());
                CharacterDetails.VieraEar01BRight_Toggle = true;
            }
            if (CharacterDetails.VieraEar02BLeft_Rotate == true)
            {
                CharacterDetails.VieraEar02BLeft_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.VieraEar02BLeft_X), "float", ((float)q.X).ToString());
                CharacterDetails.VieraEar02BLeft_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.VieraEar02BLeft_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.VieraEar02BLeft_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.VieraEar02BLeft_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.VieraEar02BLeft_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.VieraEar02BLeft_W), "float", ((float)q.W).ToString());
                CharacterDetails.VieraEar02BLeft_Toggle = true;
            }
            if (CharacterDetails.VieraEar02BRight_Rotate == true)
            {
                CharacterDetails.VieraEar02BRight_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.VieraEar02BRight_X), "float", ((float)q.X).ToString());
                CharacterDetails.VieraEar02BRight_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.VieraEar02BRight_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.VieraEar02BRight_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.VieraEar02BRight_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.VieraEar02BRight_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.VieraEar02BRight_W), "float", ((float)q.W).ToString());
                CharacterDetails.VieraEar02BRight_Toggle = true;
            }
            if (CharacterDetails.VieraEar03BLeft_Rotate == true)
            {
                CharacterDetails.VieraEar03BLeft_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.VieraEar03BLeft_X), "float", ((float)q.X).ToString());
                CharacterDetails.VieraEar03BLeft_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.VieraEar03BLeft_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.VieraEar03BLeft_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.VieraEar03BLeft_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.VieraEar03BLeft_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.VieraEar03BLeft_W), "float", ((float)q.W).ToString());
                CharacterDetails.VieraEar03BLeft_Toggle = true;
            }
            if (CharacterDetails.VieraEar03BRight_Rotate == true)
            {
                CharacterDetails.VieraEar03BRight_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.VieraEar03BRight_X), "float", ((float)q.X).ToString());
                CharacterDetails.VieraEar03BRight_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.VieraEar03BRight_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.VieraEar03BRight_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.VieraEar03BRight_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.VieraEar03BRight_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.VieraEar03BRight_W), "float", ((float)q.W).ToString());
                CharacterDetails.VieraEar03BRight_Toggle = true;
            }
            if (CharacterDetails.VieraEar04BLeft_Rotate == true)
            {
                CharacterDetails.VieraEar04BLeft_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.VieraEar04BLeft_X), "float", ((float)q.X).ToString());
                CharacterDetails.VieraEar04BLeft_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.VieraEar04BLeft_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.VieraEar04BLeft_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.VieraEar04BLeft_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.VieraEar04BLeft_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.VieraEar04BLeft_W), "float", ((float)q.W).ToString());
                CharacterDetails.VieraEar04BLeft_Toggle = true;
            }
            if (CharacterDetails.VieraEar04BRight_Rotate == true)
            {
                CharacterDetails.VieraEar04BRight_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.VieraEar04BRight_X), "float", ((float)q.X).ToString());
                CharacterDetails.VieraEar04BRight_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.VieraEar04BRight_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.VieraEar04BRight_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.VieraEar04BRight_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.VieraEar04BRight_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.VieraEar04BRight_W), "float", ((float)q.W).ToString());
                CharacterDetails.VieraEar04BRight_Toggle = true;
            }
            if (CharacterDetails.VieraLipLowerB_Rotate == true)
            {
                CharacterDetails.VieraLipLowerB_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.VieraLipLowerB_X), "float", ((float)q.X).ToString());
                CharacterDetails.VieraLipLowerB_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.VieraLipLowerB_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.VieraLipLowerB_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.VieraLipLowerB_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.VieraLipLowerB_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.VieraLipLowerB_W), "float", ((float)q.W).ToString());
                CharacterDetails.VieraLipLowerB_Toggle = true;
            }
            if (CharacterDetails.ExRootHair_Rotate == true)
            {
                CharacterDetails.ExRootHair_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExRootHair_X), "float", ((float)q.X).ToString());
                CharacterDetails.ExRootHair_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExRootHair_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.ExRootHair_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExRootHair_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.ExRootHair_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExRootHair_W), "float", ((float)q.W).ToString());
                CharacterDetails.ExRootHair_Toggle = true;
            }
            if (CharacterDetails.ExHairA_Rotate == true)
            {
                CharacterDetails.ExHairA_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExHairA_X), "float", ((float)q.X).ToString());
                CharacterDetails.ExHairA_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExHairA_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.ExHairA_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExHairA_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.ExHairA_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExHairA_W), "float", ((float)q.W).ToString());
                CharacterDetails.ExHairA_Toggle = true;
            }
            if (CharacterDetails.ExHairB_Rotate == true)
            {
                CharacterDetails.ExHairB_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExHairB_X), "float", ((float)q.X).ToString());
                CharacterDetails.ExHairB_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExHairB_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.ExHairB_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExHairB_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.ExHairB_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExHairB_W), "float", ((float)q.W).ToString());
                CharacterDetails.ExHairB_Toggle = true;
            }
            if (CharacterDetails.ExHairC_Rotate == true)
            {
                CharacterDetails.ExHairC_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExHairC_X), "float", ((float)q.X).ToString());
                CharacterDetails.ExHairC_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExHairC_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.ExHairC_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExHairC_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.ExHairC_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExHairC_W), "float", ((float)q.W).ToString());
                CharacterDetails.ExHairC_Toggle = true;
            }
            if (CharacterDetails.ExHairD_Rotate == true)
            {
                CharacterDetails.ExHairD_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExHairD_X), "float", ((float)q.X).ToString());
                CharacterDetails.ExHairD_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExHairD_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.ExHairD_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExHairD_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.ExHairD_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExHairD_W), "float", ((float)q.W).ToString());
                CharacterDetails.ExHairD_Toggle = true;
            }
            if (CharacterDetails.ExHairE_Rotate == true)
            {
                CharacterDetails.ExHairE_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExHairE_X), "float", ((float)q.X).ToString());
                CharacterDetails.ExHairE_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExHairE_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.ExHairE_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExHairE_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.ExHairE_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExHairE_W), "float", ((float)q.W).ToString());
                CharacterDetails.ExHairE_Toggle = true;
            }
            if (CharacterDetails.ExHairF_Rotate == true)
            {
                CharacterDetails.ExHairF_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExHairF_X), "float", ((float)q.X).ToString());
                CharacterDetails.ExHairF_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExHairF_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.ExHairF_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExHairF_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.ExHairF_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExHairF_W), "float", ((float)q.W).ToString());
                CharacterDetails.ExHairF_Toggle = true;
            }
            if (CharacterDetails.ExHairG_Rotate == true)
            {
                CharacterDetails.ExHairG_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExHairG_X), "float", ((float)q.X).ToString());
                CharacterDetails.ExHairG_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExHairG_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.ExHairG_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExHairG_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.ExHairG_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExHairG_W), "float", ((float)q.W).ToString());
                CharacterDetails.ExHairG_Toggle = true;
            }
            if (CharacterDetails.ExHairH_Rotate == true)
            {
                CharacterDetails.ExHairH_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExHairH_X), "float", ((float)q.X).ToString());
                CharacterDetails.ExHairH_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExHairH_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.ExHairH_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExHairH_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.ExHairH_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExHairH_W), "float", ((float)q.W).ToString());
                CharacterDetails.ExHairH_Toggle = true;
            }
            if (CharacterDetails.ExHairI_Rotate == true)
            {
                CharacterDetails.ExHairI_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExHairI_X), "float", ((float)q.X).ToString());
                CharacterDetails.ExHairI_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExHairI_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.ExHairI_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExHairI_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.ExHairI_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExHairI_W), "float", ((float)q.W).ToString());
                CharacterDetails.ExHairI_Toggle = true;
            }
            if (CharacterDetails.ExHairJ_Rotate == true)
            {
                CharacterDetails.ExHairJ_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExHairJ_X), "float", ((float)q.X).ToString());
                CharacterDetails.ExHairJ_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExHairJ_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.ExHairJ_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExHairJ_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.ExHairJ_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExHairJ_W), "float", ((float)q.W).ToString());
                CharacterDetails.ExHairJ_Toggle = true;
            }
            if (CharacterDetails.ExHairK_Rotate == true)
            {
                CharacterDetails.ExHairK_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExHairK_X), "float", ((float)q.X).ToString());
                CharacterDetails.ExHairK_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExHairK_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.ExHairK_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExHairK_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.ExHairK_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExHairK_W), "float", ((float)q.W).ToString());
                CharacterDetails.ExHairK_Toggle = true;
            }
            if (CharacterDetails.ExHairL_Rotate == true)
            {
                CharacterDetails.ExHairL_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExHairL_X), "float", ((float)q.X).ToString());
                CharacterDetails.ExHairL_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExHairL_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.ExHairL_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExHairL_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.ExHairL_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExHairL_W), "float", ((float)q.W).ToString());
                CharacterDetails.ExHairL_Toggle = true;
            }
            if (CharacterDetails.ExRootMet_Rotate == true)
            {
                CharacterDetails.ExRootMet_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExRootMet_X), "float", ((float)q.X).ToString());
                CharacterDetails.ExRootMet_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExRootMet_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.ExRootMet_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExRootMet_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.ExRootMet_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExRootMet_W), "float", ((float)q.W).ToString());
                CharacterDetails.ExRootMet_Toggle = true;
            }
            if (CharacterDetails.ExMetA_Rotate == true)
            {
                CharacterDetails.ExMetA_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExMetA_X), "float", ((float)q.X).ToString());
                CharacterDetails.ExMetA_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExMetA_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.ExMetA_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExMetA_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.ExMetA_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExMetA_W), "float", ((float)q.W).ToString());
                CharacterDetails.ExMetA_Toggle = true;
            }
            if (CharacterDetails.ExMetB_Rotate == true)
            {
                CharacterDetails.ExMetB_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExMetB_X), "float", ((float)q.X).ToString());
                CharacterDetails.ExMetB_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExMetB_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.ExMetB_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExMetB_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.ExMetB_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExMetB_W), "float", ((float)q.W).ToString());
                CharacterDetails.ExMetB_Toggle = true;
            }
            if (CharacterDetails.ExMetC_Rotate == true)
            {
                CharacterDetails.ExMetC_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExMetC_X), "float", ((float)q.X).ToString());
                CharacterDetails.ExMetC_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExMetC_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.ExMetC_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExMetC_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.ExMetC_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExMetC_W), "float", ((float)q.W).ToString());
                CharacterDetails.ExMetC_Toggle = true;
            }
            if (CharacterDetails.ExMetD_Rotate == true)
            {
                CharacterDetails.ExMetD_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExMetD_X), "float", ((float)q.X).ToString());
                CharacterDetails.ExMetD_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExMetD_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.ExMetD_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExMetD_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.ExMetD_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExMetD_W), "float", ((float)q.W).ToString());
                CharacterDetails.ExMetD_Toggle = true;
            }
            if (CharacterDetails.ExMetE_Rotate == true)
            {
                CharacterDetails.ExMetE_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExMetE_X), "float", ((float)q.X).ToString());
                CharacterDetails.ExMetE_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExMetE_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.ExMetE_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExMetE_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.ExMetE_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExMetE_W), "float", ((float)q.W).ToString());
                CharacterDetails.ExMetE_Toggle = true;
            }
            if (CharacterDetails.ExMetF_Rotate == true)
            {
                CharacterDetails.ExMetF_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExMetF_X), "float", ((float)q.X).ToString());
                CharacterDetails.ExMetF_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExMetF_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.ExMetF_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExMetF_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.ExMetF_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExMetF_W), "float", ((float)q.W).ToString());
                CharacterDetails.ExMetF_Toggle = true;
            }
            if (CharacterDetails.ExMetG_Rotate == true)
            {
                CharacterDetails.ExMetG_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExMetG_X), "float", ((float)q.X).ToString());
                CharacterDetails.ExMetG_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExMetG_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.ExMetG_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExMetG_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.ExMetG_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExMetG_W), "float", ((float)q.W).ToString());
                CharacterDetails.ExMetG_Toggle = true;
            }
            if (CharacterDetails.ExMetH_Rotate == true)
            {
                CharacterDetails.ExMetH_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExMetH_X), "float", ((float)q.X).ToString());
                CharacterDetails.ExMetH_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExMetH_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.ExMetH_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExMetH_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.ExMetH_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExMetH_W), "float", ((float)q.W).ToString());
                CharacterDetails.ExMetH_Toggle = true;
            }
            if (CharacterDetails.ExMetI_Rotate == true)
            {
                CharacterDetails.ExMetI_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExMetI_X), "float", ((float)q.X).ToString());
                CharacterDetails.ExMetI_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExMetI_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.ExMetI_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExMetI_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.ExMetI_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExMetI_W), "float", ((float)q.W).ToString());
                CharacterDetails.ExMetI_Toggle = true;
            }
            if (CharacterDetails.ExMetJ_Rotate == true)
            {
                CharacterDetails.ExMetJ_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExMetJ_X), "float", ((float)q.X).ToString());
                CharacterDetails.ExMetJ_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExMetJ_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.ExMetJ_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExMetJ_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.ExMetJ_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExMetJ_W), "float", ((float)q.W).ToString());
                CharacterDetails.ExMetJ_Toggle = true;
            }
            if (CharacterDetails.ExMetK_Rotate == true)
            {
                CharacterDetails.ExMetK_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExMetK_X), "float", ((float)q.X).ToString());
                CharacterDetails.ExMetK_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExMetK_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.ExMetK_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExMetK_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.ExMetK_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExMetK_W), "float", ((float)q.W).ToString());
                CharacterDetails.ExMetK_Toggle = true;
            }
            if (CharacterDetails.ExMetL_Rotate == true)
            {
                CharacterDetails.ExMetL_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExMetL_X), "float", ((float)q.X).ToString());
                CharacterDetails.ExMetL_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExMetL_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.ExMetL_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExMetL_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.ExMetL_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExMetL_W), "float", ((float)q.W).ToString());
                CharacterDetails.ExMetL_Toggle = true;
            }
            if (CharacterDetails.ExMetM_Rotate == true)
            {
                CharacterDetails.ExMetM_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExMetM_X), "float", ((float)q.X).ToString());
                CharacterDetails.ExMetM_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExMetM_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.ExMetM_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExMetM_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.ExMetM_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExMetM_W), "float", ((float)q.W).ToString());
                CharacterDetails.ExMetM_Toggle = true;
            }
            if (CharacterDetails.ExMetN_Rotate == true)
            {
                CharacterDetails.ExMetN_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExMetN_X), "float", ((float)q.X).ToString());
                CharacterDetails.ExMetN_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExMetN_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.ExMetN_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExMetN_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.ExMetN_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExMetN_W), "float", ((float)q.W).ToString());
                CharacterDetails.ExMetN_Toggle = true;
            }
            if (CharacterDetails.ExMetO_Rotate == true)
            {
                CharacterDetails.ExMetO_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExMetO_X), "float", ((float)q.X).ToString());
                CharacterDetails.ExMetO_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExMetO_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.ExMetO_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExMetO_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.ExMetO_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExMetO_W), "float", ((float)q.W).ToString());
                CharacterDetails.ExMetO_Toggle = true;
            }
            if (CharacterDetails.ExMetP_Rotate == true)
            {
                CharacterDetails.ExMetP_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExMetP_X), "float", ((float)q.X).ToString());
                CharacterDetails.ExMetP_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExMetP_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.ExMetP_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExMetP_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.ExMetP_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExMetP_W), "float", ((float)q.W).ToString());
                CharacterDetails.ExMetP_Toggle = true;
            }
            if (CharacterDetails.ExMetQ_Rotate == true)
            {
                CharacterDetails.ExMetQ_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExMetQ_X), "float", ((float)q.X).ToString());
                CharacterDetails.ExMetQ_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExMetQ_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.ExMetQ_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExMetQ_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.ExMetQ_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExMetQ_W), "float", ((float)q.W).ToString());
                CharacterDetails.ExMetQ_Toggle = true;
            }
            if (CharacterDetails.ExMetR_Rotate == true)
            {
                CharacterDetails.ExMetR_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExMetR_X), "float", ((float)q.X).ToString());
                CharacterDetails.ExMetR_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExMetR_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.ExMetR_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExMetR_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.ExMetR_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExMetR_W), "float", ((float)q.W).ToString());
                CharacterDetails.ExMetR_Toggle = true;
            }
            if (CharacterDetails.ExRootTop_Rotate == true)
            {
                CharacterDetails.ExRootTop_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExRootTop_X), "float", ((float)q.X).ToString());
                CharacterDetails.ExRootTop_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExRootTop_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.ExRootTop_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExRootTop_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.ExRootTop_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExRootTop_W), "float", ((float)q.W).ToString());
                CharacterDetails.ExRootTop_Toggle = true;
            }
            if (CharacterDetails.ExTopA_Rotate == true)
            {
                CharacterDetails.ExTopA_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExTopA_X), "float", ((float)q.X).ToString());
                CharacterDetails.ExTopA_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExTopA_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.ExTopA_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExTopA_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.ExTopA_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExTopA_W), "float", ((float)q.W).ToString());
                CharacterDetails.ExTopA_Toggle = true;
            }
            if (CharacterDetails.ExTopB_Rotate == true)
            {
                CharacterDetails.ExTopB_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExTopB_X), "float", ((float)q.X).ToString());
                CharacterDetails.ExTopB_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExTopB_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.ExTopB_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExTopB_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.ExTopB_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExTopB_W), "float", ((float)q.W).ToString());
                CharacterDetails.ExTopB_Toggle = true;
            }
            if (CharacterDetails.ExTopC_Rotate == true)
            {
                CharacterDetails.ExTopC_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExTopC_X), "float", ((float)q.X).ToString());
                CharacterDetails.ExTopC_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExTopC_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.ExTopC_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExTopC_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.ExTopC_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExTopC_W), "float", ((float)q.W).ToString());
                CharacterDetails.ExTopC_Toggle = true;
            }
            if (CharacterDetails.ExTopD_Rotate == true)
            {
                CharacterDetails.ExTopD_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExTopD_X), "float", ((float)q.X).ToString());
                CharacterDetails.ExTopD_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExTopD_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.ExTopD_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExTopD_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.ExTopD_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExTopD_W), "float", ((float)q.W).ToString());
                CharacterDetails.ExTopD_Toggle = true;
            }
            if (CharacterDetails.ExTopE_Rotate == true)
            {
                CharacterDetails.ExTopE_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExTopE_X), "float", ((float)q.X).ToString());
                CharacterDetails.ExTopE_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExTopE_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.ExTopE_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExTopE_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.ExTopE_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExTopE_W), "float", ((float)q.W).ToString());
                CharacterDetails.ExTopE_Toggle = true;
            }
            if (CharacterDetails.ExTopF_Rotate == true)
            {
                CharacterDetails.ExTopF_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExTopF_X), "float", ((float)q.X).ToString());
                CharacterDetails.ExTopF_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExTopF_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.ExTopF_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExTopF_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.ExTopF_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExTopF_W), "float", ((float)q.W).ToString());
                CharacterDetails.ExTopF_Toggle = true;
            }
            if (CharacterDetails.ExTopG_Rotate == true)
            {
                CharacterDetails.ExTopG_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExTopG_X), "float", ((float)q.X).ToString());
                CharacterDetails.ExTopG_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExTopG_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.ExTopG_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExTopG_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.ExTopG_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExTopG_W), "float", ((float)q.W).ToString());
                CharacterDetails.ExTopG_Toggle = true;
            }
            if (CharacterDetails.ExTopH_Rotate == true)
            {
                CharacterDetails.ExTopH_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExTopH_X), "float", ((float)q.X).ToString());
                CharacterDetails.ExTopH_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExTopH_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.ExTopH_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExTopH_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.ExTopH_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExTopH_W), "float", ((float)q.W).ToString());
                CharacterDetails.ExTopH_Toggle = true;
            }
            if (CharacterDetails.ExTopI_Rotate == true)
            {
                CharacterDetails.ExTopI_X.value = (float)q.X;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExTopI_X), "float", ((float)q.X).ToString());
                CharacterDetails.ExTopI_Y.value = (float)q.Y;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExTopI_Y), "float", ((float)q.Y).ToString());
                CharacterDetails.ExTopI_Z.value = (float)q.Z;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExTopI_Z), "float", ((float)q.Z).ToString());
                CharacterDetails.ExTopI_W.value = (float)q.W;
                MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Bones.ExTopI_W), "float", ((float)q.W).ToString());
                CharacterDetails.ExTopI_Toggle = true;
            }
        }
    }
}
