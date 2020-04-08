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
                rotationDelta.Normalize();
                var q = (MainViewModel.ViewTime.AltRotate) ? RotationQuaternion.Quaternion * rotationDelta : rotationDelta * RotationQuaternion.Quaternion;
                q.Normalize();

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

        /*    #region Child Bones
        private void Viewport3D_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var el = (UIElement)sender;
            el.ReleaseMouseCapture();

            dragState.isTracking = false;

            var qv = RotationQuaternion.GetValue(QuaternionRotation3D.QuaternionProperty);
            var q = (Quaternion)qv;

            PoseMatrixViewModel.PoseVM.RotateHelperQuaternion(q);
        }
    }
}
