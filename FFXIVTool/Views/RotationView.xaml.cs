using FFXIVTool.Utility;
using FFXIVTool.ViewModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Media3D;

namespace FFXIVTool.Views
{
    /// <summary>
    /// Interaction logic for RotationView.xaml
    /// </summary>
    public partial class RotationView : UserControl
    {
        struct DragState
        {
            public Point lastPoint;
            public bool isTracking;
            public MouseButton mouseButton;
        }

        private DragState dragState;

        public RotationView()
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
                var q = RotationQuaternion.Quaternion * rotationDelta;
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

            MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Position.Rotation), "float", ((float)q.X).ToString());
            MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Position.Rotation2), "float", ((float)q.Y).ToString());
            MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Position.Rotation3), "float", ((float)q.Z).ToString());
            MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Body.Base, Settings.Instance.Character.Body.Position.Rotation4), "float", ((float)q.W).ToString());
        }
    }
}
